#version 330 core
out vec4 FragColor;

in vec3 FragPos;//����ռ�����
in vec3 Normal;

uniform float mixValue;


uniform vec3 viewPos;//���λ��
uniform vec3 lightColor;
uniform vec3 objectColor;
uniform vec3 lightPos;//��Դλ��

void main()
{
	//��������
	float ambientStrength = 0.1;
	vec3 ambient = ambientStrength * lightColor;//��������

	//��ӹ��ռ���
	vec3 norm = normalize(Normal);//��������׼��
	vec3 lightDir = normalize(lightPos - FragPos);//���շ���
	
	//�������������
	float diff = max(dot(norm,lightDir),0.0);
	vec3 diffuse = diff*lightColor;

	//���þ���ǿ��
	float specularStrenght = 0.5;
	vec3 viewDir = normalize(viewPos - FragPos);//���߷���
	vec3 reflectDir = reflect(-lightDir, norm);//�������������߷���ȡ��
	//���㾵�����ǿ��
	float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32);//ȡ32���ݵķ����
	vec3 specular = specularStrenght * spec * lightColor;
	

	//��ɫ���
	vec3 result = (ambient+diffuse+specular)*objectColor;
	FragColor = vec4(result,1.0);
}