# AndroidTools

## 目的

安卓的小工具,方便操作,就是一些简单的命令,可以解放双手,用c#写的

现把该项目结合到AndroidKiller去,移除部分路径,移除部分功能,针对AndroidKiller的多dex问题进行修复

## 主要功能

+ [AndroidKiller](https://pan.baidu.com/s/1IWuohN2GEH7vhs6WRkcD0w)    提取码：avg7

+ 基本命令
  - 获取设备（如果有多个手机连接电脑，可以通过获取设备来区分）
  - 获取包名（获取当前app，卸载app、清除数据、截屏都是基于该app执行的）

+ 无线连接
  - 默认的用了一些模拟器，可以自定义ip连接

+ pull和push（某些目录可能会拿不到权限)
  - pull：从手机中拉取些文件到本地
  - push：从本地向手机传输某些文件

+ anr/crash：获取anr和crash信息

ADB命令截图：

![ADB命令截图](1.png)

![ADB命令截图](2.png)

![简单反编译](3.png)

apk信息以及查壳截图（添加AndroidKiller多个dex不能定位到源码的问题）：

![简单反编译](4.png)
