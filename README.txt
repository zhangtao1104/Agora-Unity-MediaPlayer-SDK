一： 编译 Unity Android SDK：

1: cd sdk/Projects/Android/

2: 下载 native sdk，解压拷贝到 prebuilt/ 目录下

3: ./build.sh

4: 产物在 bin 目录。


二：运行 Demo：

拷贝第一步 bin/ 目录下的内容到 ./Hello-Video-Unity-Agora/Assets/AgoraEngine/Plugins/Android/AgoraRtcEngineKit.plugin/libs/ 下。

用 Unity 打开 Hello-Video-Unity-Agora 项目，在 Test.cs 文件报错处上填入 appId, build Andorid 运行。