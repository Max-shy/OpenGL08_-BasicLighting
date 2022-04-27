#version 330 core
out vec4 FragColor;

in vec3 FragPos;//世界空间坐标
in vec3 Normal;

uniform float mixValue;


uniform vec3 viewPos;//相机位置
uniform vec3 lightColor;
uniform vec3 objectColor;
uniform vec3 lightPos;//光源位置

void main()
{
	//环境因子
	float ambientStrength = 0.1;
	vec3 ambient = ambientStrength * lightColor;//环境反射

	//添加光照计算
	vec3 norm = normalize(Normal);//法向量标准化
	vec3 lightDir = normalize(lightPos - FragPos);//光照方向
	
	//计算漫反射分量
	float diff = max(dot(norm,lightDir),0.0);
	vec3 diffuse = diff*lightColor;

	//设置镜面强度
	float specularStrenght = 0.5;
	vec3 viewDir = normalize(viewPos - FragPos);//视线方向
	vec3 reflectDir = reflect(-lightDir, norm);//反射向量，视线方向取反
	//计算镜面分量强度
	float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32);//取32次幂的反光度
	vec3 specular = specularStrenght * spec * lightColor;
	

	//着色结果
	vec3 result = (ambient+diffuse+specular)*objectColor;
	FragColor = vec4(result,1.0);
}