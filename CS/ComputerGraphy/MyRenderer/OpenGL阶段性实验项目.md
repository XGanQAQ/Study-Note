## 概述：
项目目标：可编辑场景3D渲染引擎，完成基本光照功能，并能在此之上方便的添加高级功能，可用于个人复用方便学习各种图形学知识。
使用C++、OpenGL、Im GUI编写的小型3D渲染学习项目、
专注于OpenGL与计算机图形学的学习

## 设计理念
- 简单
- 专注于方便学习渲染

## 计划
 - [ ] 基本渲染功能
	 - [x]  基本抽象封装
		 - [x] VAO,VBO抽象
		 - [x] Shaderprogram抽象
		 - [x] Model、Mesh抽象
		 - [x] Material抽象
		 - [x] Scene、SceneNode抽象
		 - [x] Camera抽象
		 - [x] Renderer抽象
		 - [x] Application抽象
	 - [x] 便捷几何体
		 - [x] 矩阵栈
		 - [x] 基本几何体类的封装
	- [ ] 纹理
		- [x] 简单纹理
		- [ ] 高级纹理
	- [ ] 模型
		- [x] obj模型读取
	- [ ] 光照
		- [ ] 光源
			- [ ] 全局光
			- [ ] 定向光
			- [ ] 位置光
			- [ ] 聚光灯
		- [ ] 光照材质模型
	- [ ] 天空盒
	- [ ] 阴影
	- [ ] 高级效果
- [ ] UI
	- [x] 节点树
	- [x] 节点属性
	- [ ] 相机移动
- [ ] 高级效果
	- [ ] PBR材质
	- [ ] SSAO
	- [ ] 持久化场景信息
	- [ ] 程序动态读取/生成/配置场景

## 程序架构
### 依赖库
GLFW：窗口管理
GLM：数学运算
Im GUI：UI界面
SOIL：纹理图形加载库

### 项目结构
```
/OpenGLExperiment
	/src
		/base 对opengl的封装
			baseAll.h
			ElementBuffer.cpp
			ElementBuffer.h
			Mesh.cpp
			Mesh.h
			ShaderProgram.cpp
			ShaderProgram.h
			Texture.cpp
			Texture.h
			VertexArrayObject.cpp
			VertexArrayObject.h
			VertexBuffer.cpp
			VertexBuffer.h
			VertexBufferElement.cpp
			VertexBufferElement.h
		/component 组件
			Material.cpp
			Material.h
			Model.cpp
			Model.h
		/core 核心
		    Application.cpp
		    Application.h
		    Renderer.cpp
		    Renderer.h
		    Scene.cpp
		    Scene.h
		/objects 对象
		    Camera.h
		    Camera.cpp
		    SceneNode.cpp
		    SceneNode.cpp
		    Light.h
		    Light.cpp
		    Skybox.h
		    Skybox.cpp
		/resources 资源管理
		    ModelLoader.h
		    ModelLoader.cpp
		    TextureManager.h
		    TextureManager.cpp
		    ShaderManager.h
		    ShaderManager.cpp
		/tools
		    GeometryGenerator.h 创建基本几何体
		    GeometryGenerator.cpp
			ImportedModel.cpp 读取模型
			ImportedModel.h
			Utils.cpp 老旧工具
			Utils.h
		/advanced
		    ShadowMapping.h
		    ShadowMapping.cpp
		    AdvancedTexturing.h
		    AdvancedTexturing.cpp
		/ui
		    ImGUI.h
		    ImGUI.cpp
	/assets
	    /models
	    /textures
	    /shaders
	/include
	(公共的头文件)
	/lib
    (外部库引用)
    /x64
    (x64的可执行文件)
	    /debug
	/docs
	(可阅读文档)
	/test
	(测试模块)
	

```
### 核心运行逻辑
- main
	- application
		- Scene
			- SceneNode 管理场景中的对象（例如位置、旋转、缩放）
				- Model 管理多个 Mesh
					- VertexArrayObject VAO封装
					- Mesh 网格 管理顶点数据和顶点属性配置
						- 第一个Mesh固定为顶点坐标网格
						- VertexBuffer VBO封装
						- VretexBufferElement 结构体记录vbo配置信息
				- Material 材质信息
					- ShaderProgram
					- Texture
			- Camera
			- Light
		- Renderer 
			- 从SceneNode的Model和Material得到vao进行绘制
			- MainScene 注入的场景，用于绘制
			- MainCamera 从场景中获得主相机



