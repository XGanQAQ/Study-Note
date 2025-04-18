
不同于我们常用的2D显示屏上，利用透视显示场景，让用户可以真实地感知对象的位置和相对大小。VR设备是利用，**双目机制**观看场景，这种机制能产生更真实的深度假象，通常称作**立体视觉**。

### 双目机制的原理
在现实世界中，我们会体验到“深度感”，因为人的两只眼睛在物理上处于略微不同的位置。大脑能够将两只眼睛略有不同的视点组合成一个单一的 3D 体验。要想从机制上复制这种体验，需要类似地为每只眼睛提供所**渲染场景的略有不同的视图**。

### 实现不同的视图的流行技术
- **并排式**——个人头显（即是VR 头显设备）
- 色差式，即眼镜镜片有两种不同的颜色，通常是红色和青色。
- 偏振式，即眼镜两侧镜片的偏振方向不同
- 快门式，即投影的图像交替显示左右图像。

### 双目视图和投影矩阵
合适的眼间距（InterOcular Distance，IOD），即两只眼睛瞳孔之间的距离。

推导准确的透视投影矩阵
![[VR透视矩阵.png]]

### 并排式渲染
渲染每个图像的只有一半的屏幕宽度，应用程序需要考虑这一点，更改视场或纵横比。

### 头显的镜头畸变
可以通过多种方法对渲染的场景应用畸变校正。最有效的方法之一叫作顶点位移，在场景中渲染每个元素时，都对其所有顶点应用所需的畸变校正。
![[VR的镜头畸变.png]]