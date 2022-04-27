#version 330 core
layout (location=0) in vec3 aPos;
layout (location=1) in vec3 aNormal;

//计算世界空间坐标
out vec3 FragPos;
//法向量
out vec3 Normal;


uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main(){
	
	FragPos = vec3(model*vec4(aPos,1.0));//世界空间坐标
	//Normal = aNormal;//法向量
	Normal = mat3(transpose(inverse(model))) * aNormal;//自己生成法线矩阵

	gl_Position = projection * view * vec4(FragPos,1.0);
	
	
}