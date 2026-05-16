## 苏黎世仪器 MFLI 用户手册

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//eaba2a69-1e36-47f7-a629-a568e7030af8/markdown_0/imgs/img_in_image_box_103_1122_431_1319.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A13Z%2F-1%2F%2F7f1d43a4b6088f6bc457cee80471612eea2922abec271902884397ceef2e4c41" alt="Image" width="27%" /></div>


Zurich Instruments

#### MFLI 用户手册

Zurich Instruments AG

21.08 修订版

© 2008-2021 Zurich Instruments AG 版权所有

本文档内容由 Zurich Instruments AG (ZI)提供。ZI保留随时更改规范和产品描述的权利，恕不另行通知。

LabVIEW 是 National Instruments Inc. 的注册商标。MATLAB 是 The MathWorks, Inc. 的注册商标。其他商标均为其各自所有人的注册。

## 目录

白求    
    
MFLI 用户手册的新增内容 ..... 5    
符合性声明 ..... 6    
第 1 章.入门指南 ..... 7    
1.1.快速入门指南 ..... 8    
1.2.检查包装内容 ..... 9    
1.3.搬运和安全说明 ..... 11    
1.4.连接到 MFLI 仪器 ..... 13    
1.5.在独立 PC 上运行 LabOne ..... 25    
1.6.LabOne 软件启动 ..... 32    
1.7.使用 LabOne 编程接口 ..... 38    
1.8.软件更新 ..... 39    
1.9.故障诊断 ..... 43    
第 2 章.功能概述 ..... 46    
2.1.特征 ..... 47    
2.2.前面板介绍 ..... 50    
2.3.后面板介绍 ..... 52    
2.4.订购指南 ..... 53    
2.5.机架安装 ..... 54    
第 3 章.教程 ..... 58    
3.1.简易回路 ..... 59    
3.2.外部参考 ..... 64    
3.3.Sweeper（参数扫描仪） ..... 69    
3.4.基本阻抗测量 ..... 74    
3.5.高级阻抗测量 ..... 80    
3.6.补偿 ..... 85    
3.7.锁相环 ..... 89    
3.8.自动增益控制 ..... 94    
3.9.成像 ..... 100    
第 4 章.LabOne 用户界面的功能描述 ..... 104    
4.1.用户界面概述 ..... 105    
4.2.保存和加载数据 ..... 116    
4.3.Lock-in（锁相）选项卡 ..... 134    
4.4.Lock-in（锁相）选项卡（MF-MD 选件） ..... 142    
4.5.Numeric（数值）选项卡 ..... 150    
4.6.Plotter（绘图仪）选项卡 ..... 152    
4.7.Scope（示波器）选项卡 ..... 154    
4.8.Data Acquisition（数据采集）选项卡 ..... 164    
4.9.Spectrum Analyzer（频谱分析仪）选项卡 ..... 170    
4.10.Sweeper（参数扫描仪）选项卡 ..... 173    
4.11.Auxiliary（辅助）选项卡 ..... 179    
4.12.Inputs/Outputs（输入/输出）选项卡 ..... 181    
4.13.DIO 选项卡 ..... 182    
4.14.Impedance Analyzer（阻抗分析仪）选项卡 ..... 184    
4.15.Config（配置）选项卡 ..... 194    
4.16.Device（设备）选项卡 ..... 199    
4.17.File Manager（文件管理器）选项卡 ..... 203    
4.18.PID/PLL 选项卡 ..... 204    
4.19.Threshold（阈值）选项卡 ..... 214    
4.20.MOD 选项卡 ..... 218    
4.21.Multi Device Sync（多设备同步）选项卡 ..... 221    
4.22.ZI Labs（ZI 实验室）选项卡 ..... 224    
4.23.Upgrade（升级）选项卡 ..... 225    
第 5 章.规格 ..... 226    
5.1.一般规格 ..... 227    
5.2.性能图 ..... 235    
第 6 章.信号处理基础信息 ..... 239    
6.1.锁相检测的原理 ..... 240    
6.2.信号带宽 ..... 242

6.3. 离散时间滤波器 ..... 243    
6.4. 满量程灵敏度 ..... 245    
6.5. 正弦滤波 ..... 246    
6.6. 选带傅里叶变换 ..... 248    
第 7 章. 设备节点树 ..... 249    
7.1. 引言 ..... 250    
7.2. 参考节点文档 ..... 253    
术语表 ..... 312    
索引 ..... 316

### MFLI 用户手册的新增内容

## 21.08 版

发布日期：2021年8月31日

一 用户手册：LabOne 用户界面和在线文档提供 HTML 版本。

LabOne 软件：支持在 ARM64 架构和苹果 M1 处理器上运行的 GNU/Linux 和 macOS。

一 阻抗分析仪：电流区调整量程功能可设置电流输入范围的开关频率限制。

## 21.02 版

发布日期：2021年2月28日

LabOne API：新增在线的编程手册和文档。

Sweeper：同时显示标准图和 X-Y 图，以同时显示奈奎斯特图和波特图。

一 Sweeper：扫描渲染得到改进，有 2000 多个点。

## 20.07 版

发布日期：2020年8月20日

LabOne：趋势图用于跟踪 Math（数学）子选项卡中一段时间内的读数。

LabOne：Device（设备）选项卡中提供设备信息报告。

— LabOne：改进用于 2D 绘图的颜色映射表。

一 PID Advisor：将最大建议带宽维持在硬件限制范围内，以确保稳定性。

## 20.01 版

发布日期：2020年2月28日

一 MD 选件：外部参考模式可用于所有解调器路径。

一 MOD 选件：当由外部参考提供载波和边带频率时，启用两个边带的同时解调。

一 PID 选件：添加了控制按钮，用于在 PID 控制器停止和重启时保持或重置积分器值。

LabOne：在 Sweeper（参数扫描仪）和 DAQ 选项卡的 Math（数学）子选项卡添加了线性拟合。

— LabOne：支持以 CSV 格式保存直方图数据。

LabOne：添加了在 Plotter（绘图仪）选项卡中显示直方图的正态分布或莱斯分布拟合的选项。

一 LabOne：改进了将保存的 SVG 图导入主要矢量图编辑器的功能。

### 符合性声明

制造商

Zurich Instruments

地址：Technoparkstrasse 1

8005 Zurich

Switzerland

声明

MFLI 锁相放大器 500 kHz/5 MHz, 60 MSa/s

符合欧盟的要求

一 2004/108/欧盟电磁兼容性

一 2006/95/欧盟低电压

一 2011/65/欧盟限制使用有害物质 (RoHS) 指令

一 1907/2006/欧盟关于化学品注册、评估、许可和限制法案 (REACH)

根据表 1 中列出的指令执行评估。

<div style="text-align: center;"><div style="text-align: center;">表 1. 满足如下标准</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>EN 61326-1:2006</td><td style='text-align: center; word-wrap: break-word;'>工业环境用辐射，工业环境用抗扰度</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>EN 61000-6-4</td><td style='text-align: center; word-wrap: break-word;'>工业环境用辐射标准</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>EN 61000-6-2</td><td style='text-align: center; word-wrap: break-word;'>工业环境用抗扰度</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>EN 55011</td><td style='text-align: center; word-wrap: break-word;'>1组，A类和B类（产品在典型配置下测试）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>EN 61000-4-2</td><td style='text-align: center; word-wrap: break-word;'>CD 4 kV、AD 8 kV</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>EN 61000-4-3</td><td style='text-align: center; word-wrap: break-word;'>10 V/m 80% AM 80 MHz - 1 GHz\n3 V/m 80% AM 1 GHz - 2 GHz\n1 V/m 80% AM 2 GHz - 2.7 GHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>EN 61000-4-4</td><td style='text-align: center; word-wrap: break-word;'>2 kV 电源线</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>1 kV USB 线</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>EN 61000-4-5</td><td style='text-align: center; word-wrap: break-word;'>线-线为1 kV，线-地为2 kV</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>EN 61000-4-6</td><td style='text-align: center; word-wrap: break-word;'>10 V 150 kHz - 80 MHz 80% AM，电源线</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>EN 61000-4-11</td><td style='text-align: center; word-wrap: break-word;'>100% 骤降（1个周期），30% 骤降（25个周期），60% 骤降（10个周期），100% 短时中断（250个周期）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>IEC 61010-1:2010 + AMD1:2016</td><td style='text-align: center; word-wrap: break-word;'>测量、控制和实验室用电气设备的安全要求</td></tr></table>

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//17a76570-0cf9-42f2-8b75-bed345a7c462/markdown_0/imgs/img_in_image_box_213_1231_414_1375.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A21Z%2F-1%2F%2F80d60ab483e0b87760a94431547e6bc51fcd27fd70656cec9907f6495a2dff35" alt="Image" width="16%" /></div>


### 第 1 章.入门指南

第 1 章可指导您完成对 MFLI 仪器的初始设置，以便进行第一次测量。本章包含以下内容：

一 快速入门指南

一 包装内容清单

一 搬运及安全说明

一 MFLI 仪器连接说明

一 在独立 PC 上运行 LabOne 的说明

一 LabOne API 说明

一 故障处理指南

MFLI的纸质版用户手册在交货时随仪器一同提供，随机文件是MFLI的快速入门指南。

### 1.1. 快速入门指南

当崭新的仪器到货并希望立即运行仪器时，请参阅本快速入门指南。如果 MFLI 仪器将通过 DHCP 服务器集成到 LAN，则其无需安装软件便已准备就绪。请按以下步骤继续操作：

1. 检查包装内容。除仪器外，包装内还应包含国家/地区特定的电力电缆、USB 电缆、以太网电缆以及纸质版用户手册第 1 章。

2. 查看 1.3 节中的搬运和安全说明。

3. 将仪器与电源线连接。接通电源，使用以太网电缆将其连接至 LAN 中的一台交换机，或者使用 USB 电缆直接将其连接至主机。前面板上的 LED 在短暂闪烁绿色后将变为蓝色常亮。如果 LED 持续闪烁绿色，则重启 MFLI 仪器并等待 LED 变成蓝色。如果 LED 一直不变为蓝色，请联系 Zurich Instruments 获取帮助。

4. 以太网：在 LAN 中的计算机上打开 Web 浏览器（Chrome、Edge、Firefox、Safari 或 Opera），然后在地址栏中输入以下内容：

http://<instrument-serial>/

其中 <instrument-serial> 为仪器的序列号，可以在仪器的后面板上找到。使用 http:// 前缀和尾部斜杠可避免触发搜索引擎。浏览器地址栏（左）和仪器序列号标签（右）示例如下所示。在此特定示例中，序列号为 MF-DEV3026。



<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>× LabOne User Interface ×</td><td style='text-align: center; word-wrap: break-word;'>S/N MF-DEV3026 MAC 80:2F:DE:00:07:EA</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>← → C http://mf-dev3026/</td><td style='text-align: center; word-wrap: break-word;'>...</td></tr></table>

还可以使用其他方法：输入 http://<instrument-serial>.<domain>/，其中 <domain> 是仪器所处的网络域、http://<instrument-serial>.local/，或者如果 IP 地址已知，则输入 http://192.168.11.2/。

USB (Windows)：通过 USB 连接时，MFLI 用作类似于 U 盘的闪存盘。在该闪存盘上找到适合您的操作系统的 USB 驱动程序，然后通过双击 MF-Device-Finder64.msi 等方式进行安装。通用串行总线 (USB) 连接提供更详细的说明。在 Windows 10 中，安装驱动程序时会在以下路径中创建一个开始菜单项 $ ^{1} $：Start Menu（开始菜单）→ Zurich Instruments → MF Device Finder。单击此链接打开 MF Device Finder 应用程序，其中列出了可用的所有仪器。双击仪器对应的菜单项会打开默认的 Web 浏览器，其中显示 LabOne 用户界面启动画面。

USB (Linux/Mac)：Linux 计算机通常不需要安装 USB 驱动程序。在 Macintosh 计算机上，根据通用串行总线 (USB) 连接中的安装方法来安装 USB 驱动程序。打开 Web 浏览器，然后在地址栏中输入 http://<instrument-serial>/，其中采用 MF-DEV3026 格式的仪器序列号可以在仪器的后面板上找到。

5. LabOne 用户界面启动画面将出现。单击页面右下方的 Open（打开）按钮。将加载默认配置，并且可执行第一次测量。如果用户界面无法成功启动，请参见第 1.5 节。

如果设置仪器和软件的过程中遇到任何问题，请参见本章末尾的第 1.9 节。如需在使用后关闭仪器，建议在关闭仪器后面板上的电源开关之前，先点击用户界面屏幕左下方的 ☑ 按钮来使用软关机功能。

一旦仪器启动并运行，我们建议您阅读第 3 章中的相关内容。此外，第 2 章概括介绍了各种工具和设置选项卡，并且各章节附有详细说明每个 UI 元素的表格。对于特定的应用程序知识，Zurich Instruments 网页的博客版块可提供极具价值的资源，并且这些资源还在不断更新和扩展。

### 1.2. 检查包装内容

如果运输包装出现损坏，请保留该包装，直至检查完运输物的内容并测试基本功能。

一 收到 1 台 Zurich Instruments MFLI 仪器

一 收到 1 件 Zurich Instruments MFITF 阻抗测试夹具

一 收到 1 根电源线和 1 个适合您所在国家/地区的电源插头

一 收到 1 根 USB 电缆和/或 1 根 LAN 电缆（要求为 5/6 类）

一 收到 1 个 WiFi USB 适配器

一 收到 1 本入门手册

仪器后面板上的“下一次校准”标签指示约2年后执行校准。Zurich Instruments建议校准间隔为2年

一 仪器的 MAC 地址和序列号显示在后面板上的标签上

##### 表 1.1.MFLI 仪器的包装内容

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//17a76570-0cf9-42f2-8b75-bed345a7c462/markdown_3/imgs/img_in_image_box_218_545_1080_1337.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A24Z%2F-1%2F%2F2abbc65e84e891623b6ac5c60168763dd17990f2e20ca7db0d29842ad75e8820" alt="Image" width="72%" /></div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//17a76570-0cf9-42f2-8b75-bed345a7c462/markdown_4/imgs/img_in_image_box_293_142_578_315.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A26Z%2F-1%2F%2F919c753e2e24c2288afeeec48cf210ff4d7647afce63e66fefa77e11ffe509d9" alt="Image" width="23%" /></div>


电源插口，带电源开关和保险丝座

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//17a76570-0cf9-42f2-8b75-bed345a7c462/markdown_4/imgs/img_in_image_box_689_143_1050_429.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A26Z%2F-1%2F%2F98d26fc10372f24341db9145edf6890fe89d46defb4e69b7445f8cce49b71e63" alt="Image" width="30%" /></div>


LAN/以太网电缆（要求为 5/6 类）

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//17a76570-0cf9-42f2-8b75-bed345a7c462/markdown_4/imgs/img_in_image_box_580_519_704_604.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A26Z%2F-1%2F%2F7b4397d39969b41aeb14c22ed5648547cb454f87f5c1a0e283bd83208f816649" alt="Image" width="10%" /></div>


# WiFi USB 适配器

S/N MF-DEV3026

MAC 80:2F:DE:00:07:EA

仪器后面板上的 S/N 和 MAC 地址标签

Next Calibration

Apr 2022

仪器后面板上的“下一次校准”标签

MFLI 仪器配有一个多路开关电源，可与全球大多数电力系统连接。保险丝座与电源插口集成，利用两个小螺丝刀同时夹住顶部和底部可将其抽出。保险丝座中包含一个备用保险丝。有关保险丝的说明，请参见《规范》章节。

仔细检查您的仪器。如果仪器存在机械损坏或未能通过基本测试，请立即发送电子邮件至support@zhinst.com 通知 Zurich Instruments 支持团队。

### 1.3.搬运和安全说明

MFLI 仪器是灵敏的电子设备，由于其中的高压部件可能对人体造成损害，任何情况下都不得将其外壳拆开。仪器内没有备用零件。请勿安装替代零件或未经授权对产品进行任何修改。拆开仪器后，Zurich Instruments 提供的质保立即失效。

请勿以任何制造商未指定的方式使用本产品。若以操作说明中未指定的方式使用本产品，产品的保护功能将可能受到影响。

在仪器的操作、维修和搬运的各个阶段，都必须遵守以下一般安全说明。忽视这些注意事项和本手册中的其他特定警告将对设备的操作及其使用寿命造成负面影响。

对于用户未能遵守本用户手册说明的行为，Zurich Instruments 不承担任何责任。

<div style="text-align: center;"><div style="text-align: center;">表 1.2. 安全说明</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>将仪器接地</td><td style='text-align: center; word-wrap: break-word;'>必须将仪器底架通过提供的电源线正确接地。电源线插头的接地引脚必须与电源插座上的电气接地（安全接地）端子紧密连接。保护接地导体中断或保护接地端子连接断开将造成潜在触电危险，可能导致人身伤害和仪器损坏。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>测量类别</td><td style='text-align: center; word-wrap: break-word;'>本设备的测量类别为 I(CAT I)。请勿将其用于 CAT II、III 或 IV。请勿将测量端子连接至电源插座。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>最大额定值</td><td style='text-align: center; word-wrap: break-word;'>操作过程中始终不得超过仪器连接器的规定电气额定值。有关完整的额定值列表，请参见第 5 章。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>请勿自行维修或调整任何部件</td><td style='text-align: center; word-wrap: break-word;'>仪器内没有备用零件。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>软件更新</td><td style='text-align: center; word-wrap: break-word;'>经常进行软件更新可为用户提供许多重要改进和新特性。Zurich Instruments 仅支持最新发布的软件版本。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>警告</td><td style='text-align: center; word-wrap: break-word;'>对于仪器通过软件、图形用户界面、仪器上的说明或本手册发布的所有警告，用户都必须遵守其中包含的说明。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>注释</td><td style='text-align: center; word-wrap: break-word;'>本用户手册的注释中包含的说明对于正确解读获取的测量数据十分重要。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>浮动屏蔽连接器</td><td style='text-align: center; word-wrap: break-word;'>信号输入连接器屏蔽被允许相对于接地浮动。这些屏蔽通过内部电路互相连接。尝试将其驱动至不同电势的行为可能会产生高电流，从而损坏您的仪器。信号输入连接器屏蔽仅允许在特定电压范围内相对于接地浮动，请参见第 5 章。建议在连接前对测试设备进行放电或仅在信号源已连接至仪器的情况下启动浮动信号输入屏蔽。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>电感负荷引起的高压瞬态</td><td style='text-align: center; word-wrap: break-word;'>在测量高电感设备时，应采取足够的措施来保护信号输入连接器免受电感负荷开关瞬态的高压影响。这些电压可能超过信号输入的最大额定电压并导致损坏。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>位置和通风</td><td style='text-align: center; word-wrap: break-word;'>本仪器或系统适合在 IEC 61010-1 规定的安装类别 II 和污染等级 2 的环境下进行室内使用。请仅在第 5 章规定的环境条件下操作和储存仪器。请勿堵塞背面的通风口或底架侧面的进气口，并留出合理的空间以便让空气流通。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>清洁</td><td style='text-align: center; word-wrap: break-word;'>为了防止触电，在清洁前请断开仪器交流电源，并断开所有测试引线。用柔软的无线抹布蘸水清洁仪器的外部。请勿使用清洁剂或溶剂。请勿尝试清洁内部。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>交流电源连接和电源线路保险丝</td><td style='text-align: center; word-wrap: break-word;'>为了避免发生火灾，请仅使用规定型号和额定值的保险丝来更换线路保险丝。仅使用针对本产品规定并通过所处国家/地区使用认证的电源线。始终将设备放置在适当位置，确保电源开关和电源线在操作中触手可及。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>断开主电源</td><td style='text-align: center; word-wrap: break-word;'>从墙壁电源插座上拔下产品，并在维修前移除电源线。仅允许接受过维修培训的合格人员从仪器上拆下盖板。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>操作和储存</td><td style='text-align: center; word-wrap: break-word;'>请仅在第 5 章规定的环境条件下操作和储存仪器。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>搬运和放置</td><td style='text-align: center; word-wrap: break-word;'>小心搬运。请勿使仪器掉落。请勿在设备上储存液体，避免溢出导致损坏。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>安全关键系统</td><td style='text-align: center; word-wrap: break-word;'>请勿在其故障可能导致人员伤亡、重大财产损失或破坏环境的系统中使用该设备。</td></tr></table>





当您发现下述情形之一时，请立即停止操作仪器，断开电源线，并通过网站表单或发送电子邮件至support@zhinst.com 联系 Zurich Instruments 的支持团队。

<div style="text-align: center;"><div style="text-align: center;">表 1.3.异常情况</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>风扇工作异常或无法工作</td><td style='text-align: center; word-wrap: break-word;'>立即关闭仪器，防止敏感的电子元件过热。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>电源线或仪器上的电源插头损坏</td><td style='text-align: center; word-wrap: break-word;'>立即关闭仪器，防止过热、触电或火灾。请仅使用针对本产品规定并通过所处国家/地区使用认证的电源线进行更换。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>仪器产生异响、异味或火花</td><td style='text-align: center; word-wrap: break-word;'>立即关闭仪器，避免进一步损坏。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>仪器损坏</td><td style='text-align: center; word-wrap: break-word;'>立即关闭仪器，并确保在修复之前不会再次使用。</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">表 1.4.符号</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>接地</td></tr><tr><td rowspan="3"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//a6b6e56a-5599-4c52-8763-262077215a75/markdown_1/imgs/img_in_image_box_219_493_421_959.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A16Z%2F-1%2F%2F72249f713a1fadd9e37e5aec38448be8feef38093eb1b4adecf95f9a3d79976b" alt="Image"" /></td><td style='text-align: center; word-wrap: break-word;'>外壳接地</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>警告。请参见随附的文档</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DC（直流）</td></tr></table>

### 1.4. 连接到 MFLI 仪器

Zurich Instruments MFLI 希望能最大程度上提高易用性。Zurich Instruments LabOne 软件在 MFLI 仪器的嵌入式 PC 上运行，交货前已预装。嵌入式 PC 上运行的程序之一为 LabOne Web 服务器，在与仪器建立合适的物理和逻辑连接时，可通过 Web 浏览器进行连接。

##### 注释

支持以下 Web 浏览器（最新版本）：

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//a6b6e56a-5599-4c52-8763-262077215a75/markdown_2/imgs/img_in_image_box_233_387_295_446.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A17Z%2F-1%2F%2F382c1f26c2812db05670abf18199dc2379edb734d721a59abdc6a4ec2921406e" alt="Image" width="5%" /></div>


Chrome

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//a6b6e56a-5599-4c52-8763-262077215a75/markdown_2/imgs/img_in_image_box_332_387_395_448.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A17Z%2F-1%2F%2F76c873691af9aae2ef352fc5e815bde32aaeb95a1bee90e70201423b90f0e2e0" alt="Image" width="5%" /></div>


Firefox

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//a6b6e56a-5599-4c52-8763-262077215a75/markdown_2/imgs/img_in_image_box_427_389_487_449.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A18Z%2F-1%2F%2F8ad2be175b91f2eb79389811f7360976a410a0c0564fb90852f8a6094ce3017a" alt="Image" width="5%" /></div>


Opera

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//a6b6e56a-5599-4c52-8763-262077215a75/markdown_2/imgs/img_in_image_box_515_390_569_447.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A18Z%2F-1%2F%2F16a811feb73af3003442f765a6f379516f30a1ddbbc56c5f8b0bffda2165521b" alt="Image" width="4%" /></div>


Edge

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//a6b6e56a-5599-4c52-8763-262077215a75/markdown_2/imgs/img_in_image_box_605_387_665_447.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A18Z%2F-1%2F%2F9994dd3ed8ffa619e2c63d2d9038022ad299c57b25eebf711d8df65d6a7b69dd" alt="Image" width="5%" /></div>


<div style="text-align: center;"><div style="text-align: center;">Safari</div> </div>


有两种方法可与仪器进行物理连接：

以太网（无需软件安装）。通过用以太网电缆将仪器连接至局域网(LAN)中的交换机，将仪器集成到现有LAN中。这样便可通过同一LAN中的任意设备上运行的Web浏览器访问仪器。以太网连接也可为点对点形式，但这需要对主机网卡设置进行一些调整。根据网络配置和安装的网卡，总有一个更适合的连接方案。

通用串行总线 (USB)。USB 连接为仪器和主机之间的点对点连接，这两者通过 USB 电缆连接。这需要在主机上安装 RNDIS 驱动程序。对于 PC 用户，此驱动程序可在仪器闪存上找到，当仪器通过 USB 连接至您的 PC 后，它将以新驱动器的形式出现在文件资源管理器中。Mac 用户可在线获取驱动程序。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//a6b6e56a-5599-4c52-8763-262077215a75/markdown_2/imgs/img_in_image_box_298_795_1071_1405.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A18Z%2F-1%2F%2F05cfbb8f5c9397c20debfd0670ab6e0493014d7b1bdb5571aeaf4bb2ea48078d" alt="Image" width="64%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.1. 连接</div> </div>


<div style="text-align: center;"><div style="text-align: center;">图 1.1 给出了一些计算机与仪器之间可能的连接配置的示例。</div> </div>


#### 1.4.1. 以太网 TCP/IP 连接

最简单的连接方法是将仪器集成到支持域名系统 (DNS) 和动态 DNS 更新的现有 LAN 中。在这类网络中，可使用仪器序列号而非其 IP 地址来访问 MFLI 仪器。用一根以太网电缆将仪器与 LAN 网络交换机连接。要启动 LabOne 用户界面，可在 LAN 中的一台计算机上打开 Web 浏览器并在地址栏中输入如下文本：

http://<instrument-serial><domain>/，或

http://<instrument-serial>.local/，或

http://<instrument-serial>/

其中 <instrument-serial> 是仪器的序列号，<domain> 是仪器所处的网络域。

本方法使用 DNS 查找来解析仪器的 IP 地址，此地址默认配置为该网络名。由于特殊网络政策或其他原因，本方法也可能失败，此时可采用其他方法配置仪器的 TCP/IP 连接。这些将在第 1.4.4 节高级 TCP/IP 配置中介绍。

通过 LAN 进行连接后，多个 Web 浏览器和 API 客户端会话可对仪器进行同时访问和控制。因此，利用 API 通过 Python 等程序对仪器设置进行的更改可在连接至该仪器的 Web 浏览器中看到。仪器数据可同时传输到多个客户端会话。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//a6b6e56a-5599-4c52-8763-262077215a75/markdown_3/imgs/img_in_image_box_217_682_1066_930.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A19Z%2F-1%2F%2F4ff6404b681ba1619c9d35faa6c050ce0e028f4b7472d266eb200307d3ec631d" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.2.MFLI 仪器的最简单连接</div> </div>


#### 1.4.2. 通用串行总线 (USB) 连接

要通过 USB 控制仪器，可利用随附的 USB 电缆将仪器连接到您正在使用的 PC。根据您正在使用的操作系统，可能需要在 PC 上安装 USB RNDIS 设备驱动程序。RNDIS 提供到仪器虚拟以太网链接，使仪器能通过使用正常 IP 地址和主机名机制进行访问。不同操作系统的 RNDIS 驱动程序安装步骤如下所示。

##### Windows 下的 USB RNDIS 设备驱动程序

Zurich Instruments 提供了一个 Microsoft MSI 安装程序来简化 Windows RNDIS 驱动程序安装。在 MFLI 仪器的设计中，插入 USB 电缆时将出现一个标签为 MF-DRIVER 的闪存盘分区，其中包含 USB RNDIS 设备驱动程序所需的 Windows MSI 安装程序以及 PDF 版仪器用户手册和一份本 “入门指南” 章节。

按照下述步骤继续安装设备驱动程序：

1. 以管理员的身份登录至 PC。安装 USB RNDIS 设备驱动程序需要管理员权限。

2. 确认 USB 电缆已将 PC 和 MFLI 仪器相连。

3. 重启 MFLI 仪器并等待约 20 秒，直到仪器初始化完成。此时将弹出一个自动播放窗口，显示新检测到的 MFLI 驱动器。

4. 在此自动播放窗口中，选择 Open folder to view files（打开文件夹以查看文件）。

5. Windows 资源管理器中可看到两个安装程序：双击适用于您的操作系统的 .msi 安装程序，即用于 64 位操作系统的 MF-Device-Finder64.msi，或用于 32 位操作系统的 MF-Device-Finder32.msi。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//a6b6e56a-5599-4c52-8763-262077215a75/markdown_4/imgs/img_in_image_box_250_227_816_464.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A20Z%2F-1%2F%2Fca6efb7276482e247fb10586c3ecd1f94a4112054b2023bf674a2d542083074b" alt="Image" width="47%" /></div>


图 1.3. 文件资源管理器中显示的 MFLI 只读驱动器

6. 在欢迎屏幕中单击 Next（下一步）按钮。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//a6b6e56a-5599-4c52-8763-262077215a75/markdown_4/imgs/img_in_image_box_251_551_678_882.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A21Z%2F-1%2F%2Fc1a69b18066373f34318cc72f4f6926f82f8bc32a2aac33fe195bd14c5641f00" alt="Image" width="35%" /></div>


##### 图 1.4. 安装欢迎屏幕

7. 通读 Zurich Instruments 许可协议后，请选中 “I accept the terms in the License Agreement”（我接受许可协议中的条款）复选框，然后单击 Next（下一步）按钮。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//a6b6e56a-5599-4c52-8763-262077215a75/markdown_4/imgs/img_in_image_box_249_999_675_1326.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A21Z%2F-1%2F%2F2216810fcf12096b0b77dd285d9a40e416df40d1ae77ec6d9e1d23a81d59dac9" alt="Image" width="35%" /></div>


##### 图 1.5. 安装许可协议

8. 在自定义安装屏幕中单击 Next（下一步）按钮。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f31f40ec-c230-4f32-9e4b-12510c16f3fc/markdown_0/imgs/img_in_image_box_250_112_676_441.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A40Z%2F-1%2F%2F1348727aa4a71de86a517ba2739672c14873da094a92a1e05699aa972d476d0e" alt="Image" width="35%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.6. 自定义安装屏幕</div> </div>


9. 单击 Install（安装）按钮开始安装。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f31f40ec-c230-4f32-9e4b-12510c16f3fc/markdown_0/imgs/img_in_image_box_250_535_678_865.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A40Z%2F-1%2F%2F0954756973c181f3d2aa2f29c60e31144a1d57b5cb3650fc1249dcb59a1acb68" alt="Image" width="35%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.7. 安装确认</div> </div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f31f40ec-c230-4f32-9e4b-12510c16f3fc/markdown_0/imgs/img_in_image_box_251_916_678_1248.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A40Z%2F-1%2F%2F84dfda9f44abd531d14c454ff1235a7fb1012d80b571a4f93c570c9aa1d1f760" alt="Image" width="35%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.8. 安装进度</div> </div>


如果出现用户帐户控制弹出窗口，单击 Yes（是）来允许安装程序对计算机进行更改。

10. 在 Windows Server 2008 和 Windows 7 中，需要同受信任的发行商 Zurich Instruments 确认安装最多 2 个驱动程序。单击 Install（安装）。您也可以单击 Always trust software from "Zurich Instruments AG"（始终信任 “Zurich Instruments AG” 的软件）复选框以阻止该消息再次出现。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f31f40ec-c230-4f32-9e4b-12510c16f3fc/markdown_1/imgs/img_in_image_box_251_114_677_297.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A41Z%2F-1%2F%2F20688a31396dbfa4b28add1fb149c74ff451e32357e4b5b6cd9afbb19eaeeb0d" alt="Image" width="35%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.9. 安装驱动程序接受</div> </div>


11. 单击 Finish（完成）按钮以完成安装。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f31f40ec-c230-4f32-9e4b-12510c16f3fc/markdown_1/imgs/img_in_image_box_249_392_678_720.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A41Z%2F-1%2F%2F4cdcab94a0693c0a0166fb4eae03a7dcaba071c272fd398c33d986605f93bd0a" alt="Image" width="36%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.10. 安装完成</div> </div>


安装

Zurich Ins.

对话框。在设备列

浏览器，其中显示如图 1.1

点击画面右下方的 Open（打开），

设备连接）对话框。单

此番会话。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f31f40ec-c230-4f32-9e4b-12510c16f3fc/markdown_1/imgs/img_in_image_box_218_916_495_1073.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A41Z%2F-1%2F%2F4b641160c41e67366d86daf0fd1181e306f937edbb98c53bb4d4fe8e9d9a279b" alt="Image" width="23%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.11. 用于启动 Zurich Instruments MF Device Finder 的 Windows Start 菜单项</div> </div>


##### 注释

本节中介绍的步骤对 1GbE 和 USB 连接均适用。如果您使用的是 1GbE 连接，也可以仅使用 Web 浏览器连接到仪器，而无需安装软件。为此，请按照第 1.4.1 节中的说明进行操作。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f31f40ec-c230-4f32-9e4b-12510c16f3fc/markdown_2/imgs/img_in_image_box_223_113_740_557.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A42Z%2F-1%2F%2Fd389156efdfdbb92150c1b58f2e35313bef6a99ea775b68302ca2a87a3da4db3" alt="Image" width="43%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.12.MF Device Finder</div> </div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f31f40ec-c230-4f32-9e4b-12510c16f3fc/markdown_2/imgs/img_in_image_box_223_610_835_894.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A42Z%2F-1%2F%2F1395a3330a749c4e41b91cffcea267da143b080d399fe6d140edf7719c1d3bd9" alt="Image" width="51%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.13. 启动 LabOne 用户界面后的 Device Connection 对话框</div> </div>


##### Linux 下的 USB RNDIS 设备驱动程序

利用最新的 UBUNTU Linux 发行版，无需安装任何特殊驱动程序，USB 连接可开机即用。

其他 Linux 发行版也可使用，但需要其他安装步骤。由于可供使用的 Linux 发行版众多，此处无法给出详细说明。

##### OS X 下的 USB RNDIS 设备驱动程序

要在 Macintosh 计算机上安装所需的 USB RNDIS 设备驱动程序，请按照如下步骤操作：

1. 打开 Web 浏览器，转到 http://joshuawise.com/horndis 页面，然后单击链接下载最新的二进制包。编写时，此链接指向文件 HoRNDIS-rel7.pkg，该文件需下载。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f31f40ec-c230-4f32-9e4b-12510c16f3fc/markdown_2/imgs/img_in_image_box_245_1291_660_1381.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A43Z%2F-1%2F%2Fba1cefc607c01fd9072a39b3e72357568c8b019e91a2caea854a0bfe351653c9" alt="Image" width="34%" /></div>


2. 利用 Finder 定位下载的文件。文件通常可在下载文件夹中找到。双击文件运行安装程序。

3. 安装程序将引导您执行安装过程。在各对话框中选择标准选项，然后单击 Continue（继续）以继续安装。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f31f40ec-c230-4f32-9e4b-12510c16f3fc/markdown_3/imgs/img_in_image_box_249_116_664_408.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A44Z%2F-1%2F%2F2b1624e55e4b073b32b4e9605d96d249a6de943ab5a92b060785d20c48d900e4" alt="Image" width="34%" /></div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f31f40ec-c230-4f32-9e4b-12510c16f3fc/markdown_3/imgs/img_in_image_box_251_434_666_726.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A44Z%2F-1%2F%2Fb7017c5e616b2f830964b4ce4a48ec749fa26cb3dc4d9dedf322b8af2c449fda" alt="Image" width="34%" /></div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f31f40ec-c230-4f32-9e4b-12510c16f3fc/markdown_3/imgs/img_in_image_box_250_751_667_1046.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A44Z%2F-1%2F%2F49dfdda6db6d33a12255c2af8a17f656d38dc90fda81cd98e680a27f58d94e46" alt="Image" width="35%" /></div>


# 4. 安装程序完成安装前，需要管理员权限。提供必需的认证信息以完成安装。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f31f40ec-c230-4f32-9e4b-12510c16f3fc/markdown_3/imgs/img_in_image_box_294_1169_631_1345.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A44Z%2F-1%2F%2F92f01bb07a5ae3db70e15f35e61b739ece27e8a2022cd8aad565d4544d50b17d" alt="Image" width="28%" /></div>


# 5. 安装完成后将显示安装汇总信息。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f31f40ec-c230-4f32-9e4b-12510c16f3fc/markdown_4/imgs/img_in_image_box_257_152_676_448.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A45Z%2F-1%2F%2Faa84d42543f2570ce67a82101038496dda282b6fee44192c835de2a107e42f90" alt="Image" width="35%" /></div>


6. 此时建议重启计算机。

7. 用 USB 电缆将 MFLI 仪器与计算机相连并通电。等待 MFLI 仪器前面板上的蓝色 LED 点亮。

8. 为了验证计算机是否正确检测到 MFLI，打开 System Preferences（系统偏好）并选择 Network（网络）类别。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f31f40ec-c230-4f32-9e4b-12510c16f3fc/markdown_4/imgs/img_in_image_box_252_612_657_1096.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A45Z%2F-1%2F%2F5405dd87d6d03c117add574ade8e5805af0352d6ee527222bfe234e809572360" alt="Image" width="34%" /></div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f31f40ec-c230-4f32-9e4b-12510c16f3fc/markdown_4/imgs/img_in_image_box_253_1115_682_1486.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A45Z%2F-1%2F%2Ff4df573ab87571570f4482ae043977e959568c4e764db365e0d7061e92b00692" alt="Image" width="36%" /></div>


此时，带绿色图标的 MFLI 设备应显示在接口列表中，且标记为 Connected（已连接）。选择该接口后，右侧边栏中的信息应更新为显示接口使用 DHCP，且 IP 地址应采用 192.168.x.x 形式。

9. 此时可利用 Web 浏览器通过在地址栏中输入下列文本来连接至设备：

<instrument-serial>.local/

其中 <instrument-serial> 为采用 mf-dev3000 形式的仪器序列号。

或者，也可使用仪器的 IP 地址。仪器的 IP 地址为上一步中显示的 IP 地址在最右侧的八位字节上加 1。例如，如果显示的 IP 地址为 192.168.47.57，则要输入到地址栏中的仪器 IP 地址为 192.168.47.58。

#### 1.4.3. 无线连接

可以使用仪器随附的 WiFi USB 适配器，通过无线网络对 MFLI 进行控制。首先必须通过 1GbE 或 USB 电缆与仪器相连，以启用无线网络，连接完成后，仅使用无线网络即可对仪器进行控制。当仪器在实验室内频繁移动时，或者在连接电缆很麻烦的地方使用仪器时，用无线网络控制会很方便。此外，用移动设备控制仪器可以使辅导、讲座或测量演示更具互动性、也更有效。

有两种方法可与仪器进行连接：Client（客户端）模式和 Access Point（接入点）模式。在 Access Point（接入点）模式下，MFLI 会创建自己的无线网络，移动设备可以连接到该网络。在 Client（客户端）模式下，MFLI 和主机都连接到现有的无线网络。要使用 Access Point（接入点）模式，无线网络必须是开放的（不加密）或 WPA2-Personal 加密（也称为 WPA2-PSK），并且需要支持 DNS 名称解析。

##### 注释

在 17.06 LabOne 发布之前发货的仪器未随附 WiFi USB 适配器。如果您希望使用无线网络功能，而仪器发货时未随附 WiFi USB 适配器，请发送电子邮件至 support@zhinst.com 联系 Zurich Instruments 获得帮助。

##### Access Point（接入点）模式

1. 将 WiFi USB 适配器连接到仪器后面板上的其中一个 USB 端口。

2. 通过仪器上运行的 Web 服务器，使用 1GbE 或 USB 电缆连接该仪器，分别如第 1.4.1 节和第 1.4.2 节所述。

3. 单击 Device Connection（设备连接）对话框中的 “Open”（打开）按钮，打开 LabOne 用户界面。

4. 在 Device（设备）选项卡中，找到 Wireless Network（无线网络）部分。在默认情况下，此部分处于折叠状态。可使用  $ [+] $ 按钮将其展开。

5. 将 Mode（模式）设置为 Access Point（接入点）并选中 Enable WiFi（启用 WiFi）复选框以启用无线网络。

6. 或者单击 Program（编程）按钮将 WiFi 设置永久保存在设备上。

7. 在移动设备上，连接到 MFLI 仪器的无线网络。网络名称 (SSID) 和密码显示在 Device（设备）选项卡中。

8. 在移动设备上，打开浏览器窗口并输入 IP 地址 192.168.20.1（不含前缀 http:// 和尾部斜杠 /），打开 Device Connection（设备连接）对话框。

9. 单击 “Open”（打开），启动 LabOne 用户界面。

##### Client（客户端）模式

1. 将 WiFi USB 适配器连接到仪器后面板上的其中一个 USB 端口。

2. 使用 1GbE 或 USB 电缆连接仪器，分别如第 1.4.1 节和第 1.4.2 节所述。

3. 单击 Device Connection（设备连接）对话框中的 “Open”（打开）按钮，打开 LabOne 用户界面。

4. 在 Device（设备）选项卡中，找到 Wireless Network（无线网络）部分。在默认情况下，此部分处于折叠状态。可使用 [+] 按钮将其展开。

5. 将 Mode（模式）设置为 Client（客户端）。可用的开放式无线网络或 WPA2-Personal 加密无线网络随后应显示为 SSID 下的下拉列表。

6. 选择主机 PC 要连接的网络，必要时输入密码。选中 Enable WiFi（启用 WiFi）复选框以加入无线网络。

7. 或者单击 Program（编程）按钮将 WiFi 设置永久保存在设备上。

10. 现在可以断开 1GbE 或 USB 电缆。在主机 PC 上，打开浏览器窗口并输入设备的序列号 http://<instrument-serial>/，其中 <instrument-serial> 是可以在仪器后面板上找到的 MF-DEV3026 形式的仪器序列号。也可以直接使用设备的 IP 地址。要想获取 IP 地址，可以在与 MFLI 位于同一网络的 PC 上运行 MF Device Finder 实用程序，实用程序获取地址为 www.zhinst.com/downloads。

8. 单击 “Open”（打开），启动 LabOne 用户界面。

#### 1.4.4. 高级 TCP/IP 配置

通过 TCP/IP 与 MFLI 仪器进行逻辑连接的方法有多种。

一 DHCP（对用户而言最简易的方案，也是默认方案）

一 静态 IP（DHCP 失败时的备份方案）

一点对点 $ (P2P) $

DHCP 是最简单的首选连接方法。使用的网络配置与本地策略冲突时，可能需要使用其他连接方法。

##### DHCP

最直接的以太网连接方法是依靠 LAN 配置来识别 MFLI 仪器。这是 MFLI 仪器的默认配置。将仪器连入 LAN 后，将为仪器分配动态 IP 地址，就像 DHCP 服务器分配给其他 PC 一样。在受限网络中，网络管理员可能需要通过 MAC 地址在网络上注册仪器。MAC 地址指示在仪器的后面板上。如果网络配置不允许或不支持 DHCP，则必须使用下述静态 IP 设置。

##### 静态仪器 IP

向仪器分配静态 IP 地址的最佳方法是先通过 USB 连接，这一点在 LAN 中无可用 DHCP 的情况下尤其必要。

1. 通过 USB 与仪器相连，然后按照第 1.4.2 节中的描述启动 Zurich Instruments - MF Device Finder。

2. 双击列表中仪器对应的条目，打开 LabOne Device and Settings（LabOne 设备和设置）对话框。单击右下角的 Open（打开）按钮，启动 LabOne 用户界面。

3. 打开 Device（设备）选项卡。

4. 在 Communication（通信）部分中，设置所需的 IP4 地址、掩码和网关。

5. 启用 Static IP（静态 IP）复选框。

6. 单击 Program（编程）按钮，保存更改后的参数。

7. 用以太网电缆将 LAN 中的交换机与 MFLI 仪器后面板上的 1GbE 端口相连。

8. 重启 MFLI 仪器。

9. （可选）为验证主机与 MFLI 仪器之间的连接，打开 DOS 命令窗口，然后 ping 上面输入的 IP 地址。

10. 在 LAN 中一台计算机的 Web 浏览器地址栏中输入下述文本：

http://<Static IP Address>/
其中 <Static IP Address> 为上面输入的静态 IP 地址。此时会显示 LabOne Device Connection（LabOne 设备连接）对话框。

##### 要求

一 所选静态 IP 地址在 LAN 中必须唯一。

一 带动态 IP 配置的网络需要网络管理员支持（静态 IP 地址需保留）。

##### 点对点  $ (P2P) $

若创建一个仅由主机和 MFLI 组成的点对点网络，可避免与特殊网络政策相关的问题。由于仍然需要保持互联网连接，建议在计算机中安装两块网卡，一块用于网络连接，另一块用于连接 MFLI 仪器。笔记本通常可利用无线 LAN 连接互联网。

1. 使用其中一个网卡，并在 TCP/IPv4 中将 IP 地址设置为静态地址 192.168.1.n，其中 n=[2..9]，掩码为 255.255.255.0，参见图 1.14（转到 Control Panel（控制面板）→ Internet Options（互联网选项）→ Network and Internet（网络和互联网）→ Network and Sharing Center（网络和共享中心）→ Local Area Connection（本地连接）→ Properties（属性））。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//126a8fb9-f620-4276-a5d5-f3d15d103cec/markdown_2/imgs/img_in_image_box_250_759_682_1231.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A15Z%2F-1%2F%2F4bde616ce41495fd903d69cab269accae7e6688ac8e58751a702fd9a82837229" alt="Image" width="36%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.14.PC 的静态 IP 配置</div> </div>


2. 按照上一节中的描述将 MFLI 的 IP 地址设置为静态值 192.168.1.10。为了连接 MFLI 仪器并启动 LabOne 用户界面，在 Web 浏览器的地址栏中输入下列内容：

 $$ \mathrm{http://192.168.1.10/} $$ 

##### 要求

一 需要第二块网卡来连接到互联网

一 与仪器连接的网络适配器必须采用静态 IP4 配置

##### 注释

如果 MFLI 仪器之前连接过网络，且该网络向仪器提供了一个 IP 地址，随后用户决定使用静态 IP 配置运行仪器，则必须重启仪器。

##### 注释

当前仅支持 IP v4，不支持 IP v6。

##### 注释

如果 LabOne 检测到仪器但无法建立连接，可能是因为防火墙阻止了连接。建议将 P2P 连接从公共改为私人。

##### 警告

手动更改您网络适配器的 IP 设置会影响后续使用，必须将适配器重新设置为动态 IP，否则其无法用于网络连接。

### 1.5. 在独立 PC 上运行 LabOne

默认情况下，LabOne Web 服务器和数据服务器皆在仪器中的嵌入式计算机上运行。在独立 PC 上运行两个服务器具有一定优势，在使用高数据传输率或记录高分辨率 FFT 谱时尤为如此。笔记本和台式计算机具有更高的处理能力，可提高 UI 响应速度，在频谱分析仪工具中获得更多的频率点，同时降低数据丢失的概率。

若要在独立 PC 上运行数据服务器，此 PC 必须安装 LabOne 软件。LabOne 安装说明见第 1.5.1 节。软件架构一节概述了 LabOne 软件架构，尤其适用于使用多仪器控制或编程接口。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//126a8fb9-f620-4276-a5d5-f3d15d103cec/markdown_4/imgs/img_in_image_box_217_372_1065_697.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A18Z%2F-1%2F%2Fb8b4867ebc79386da9cb873569451d548ed126623219a854a131924c94387d90" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.15. 在独立 PC 上运行的 LabOne 数据服务器和 Web 服务器</div> </div>


#### 1.5.1. 软件安装

MFLI 仪器预装 LabOne 软件，开机即可使用。LabOne 软件也可安装在 Windows 和 Linux PC 中。这在性能方面具有一定优势，该仪器必须与 MATLAB、LabVIEW 或 Python API 结合使用。在 PC 上安装 LabOne 软件需要管理员权限。使用常规用户帐户便足以轻松运行软件。有关从 Zurich Instruments 网站下载正确软件包版本的说明，请参见下文有关平台的章节。建议定期更新至 Zurich Instruments 提供的最新软件版本。得益于 Automatic Update Check（自动更新检查）功能，只需在用户界面中单击即可启动更新，如第 1.8 节所示。

##### 在 Windows 中安装 LabOne

本节介绍如何在 Windows 中另外安装 LabOne 软件。仅在您希望使用 PC（而非 MFLI 自身）中运行的 Web 服务器访问用户界面，以使用其中一个 LabOne API 或实现多设备同步时才有必要了解相关内容。Zurich Instruments LabOne 软件的安装包可作为 Windows 安装程序 .msi 软件包使用。欲下载该软件，请访问 Zurich Instruments 下载中心。请确保您对要安装该软件的 PC 拥有管理员权限。有关支持的 Windows 系统综合列表，请参见 LabOne 兼容性。

##### Windows LabOne 安装

1. 在 LabOne 软件安装过程中，MFLI 不应与计算机相连。

2. 双击启动 LabOne 安装程序，其名称形式为 LabOne64-XX.XX.XXXX.msi，然后按照说明操作。安装时需要 Windows 管理员权限。安装过程如下：

一 单击欢迎屏幕中的 Next（下一步）按钮。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f0abdc57-014f-4848-a4db-80089e81aed6/markdown_0/imgs/img_in_image_box_290_113_1057_689.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A32Z%2F-1%2F%2Fb904c29d63d0619631a2b0f4b8f3a3627966e709609e4c6c19b50eaaaa7376ad" alt="Image" width="64%" /></div>


##### 图 1.16. 安装欢迎屏幕

一 通读 Zurich Instruments 许可协议后，请选中 “I accept the terms in the License Agreement”（我接受许可协议中的条款）复选框，然后单击 Next（下一步）按钮。

查看需要安装的功能。MFLI 仪器需要 “MF 系列设备、LabOne 用户界面” 和 “LabOne API” 功能。请根据需要同时安装其他设备类型的功能。为了继续安装，请单击 Next（下一步）按钮。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f0abdc57-014f-4848-a4db-80089e81aed6/markdown_0/imgs/img_in_image_box_288_895_1029_1465.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A33Z%2F-1%2F%2F264f065503df33e7dc27b6a28fcfb5aae466aafaa8ee3f14625c8b73ebc727bd" alt="Image" width="62%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.17. 自定义安装屏幕</div> </div>


选择软件是否应定期检查更新。请注意，该软件仍然不会自动更新。后续可以在用户界面中更改该设置。

如需在桌面区域安装快捷方式，请选中“Create a shortcut for this program on the desktop”（在桌面上创建此程序的快捷方式）。为了继续安装，请单击 Next（下一步）按钮。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f0abdc57-014f-4848-a4db-80089e81aed6/markdown_1/imgs/img_in_image_box_289_229_1034_850.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A34Z%2F-1%2F%2F383e16ec3ace397de4e810344e500589ee6bfc9f98eeba448c5bbdbf0002fa80" alt="Image" width="62%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.18. 自动更新检查</div> </div>


一 单击 Install（安装）按钮启动安装过程。

一 如果需要升级，Windows 最多询问两次重启计算机。确保计算机中的所有工作已保存。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f0abdc57-014f-4848-a4db-80089e81aed6/markdown_1/imgs/img_in_image_box_291_973_860_1227.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A34Z%2F-1%2F%2Fd9a5bc084676e3be6af74cc1d78a6674bcaec75cf62f2d72ca896953745b328e" alt="Image" width="47%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.19. 安装重启请求</div> </div>


首次安装 LabOne 时，需要确认安装了受信任的发行商 Zurich Instruments 的部分驱动程序。单击 Install（安装）。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f0abdc57-014f-4848-a4db-80089e81aed6/markdown_2/imgs/img_in_image_box_291_112_1036_459.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A35Z%2F-1%2F%2F373a98a86b88e76c7b5a2c9e33221c921ab2142014b9f494f1848c79b011877c" alt="Image" width="62%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.20. 安装驱动程序接受</div> </div>


一 单击以下通知对话框中的 OK（确定）。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f0abdc57-014f-4848-a4db-80089e81aed6/markdown_2/imgs/img_in_image_box_294_551_856_808.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A36Z%2F-1%2F%2Fc96c2493222355f61f5b4aba3a7e25ef9ce3f799003aa59377fe97baccd91091" alt="Image" width="47%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.21. 安装完成画面</div> </div>


3. 单击 Finish（完成）关闭 Zurich Instruments LabOne 安装程序。

4. 现在可以按第 1.6 节所述启动 LabOne 用户界面并通过 Device Connection（设备连接）对话框选择待连接仪器，如 Device Connection（设备连接）对话框所示。

##### 警告

请勿安装除 Zurich Instruments 之外的其他来源的驱动程序。

##### 在 Linux 中安装 LabOne

本节介绍如何在 Linux 中另外安装 LabOne 软件。仅适用于希望在 PC 中，而非 MFLI 上运行 Web 服务器的情况。

尝试安装 LabOne 软件包前，请确保满足以下要求：

##### 要求

1. LabOne 软件支持常见的现代 GNU/Linux 发行版（Ubuntu 14.04+、CentOS 7+、Debian 8+）。最低版本要求：glibc 2.17+ 和内核 3.10+。

2. 用户应具备系统管理员权限。

3. 适用于用户操作系统和平台的正确 LabOne 安装包版本已通过 Zurich Instruments 下载中心下载：

LabOneLinux<arch>-<release>.<revision>.tar.gz,

请确保下载 LabOne 安装程序的正确架构（x86-64 或 arm64）。可以使用 uname 命令确定正在使用的架构，具体方法是在命令行终端运行：

uname -m

如果命令输出 x86_64，需要使用 LabOne 软件包的 x86-64 版本；如果显示 aarch64，需要使用 ARM64 版本。

##### Linux LabOne 安装

在命令行 shell 中继续按如下所示进行安装：

1. 在以下临时目录中提取 LabOne tarball:

tar xzvf LabOneLinux<arch>-<release>-<revision>.tar.gz

2. 导航至提取的目录。

cd LabOneLinux<arch>-<release>-<revision>

3. 以管理员权限运行安装脚本，在可能的情况下使用默认安装路径继续执行所有引导安装步骤：sudo bash install.sh

安装脚本允许在以下三种模式之间进行选择：

键入 “a” 安装数据服务器程序、Web 服务器程序、文档和 API。

键入 “u” 安装 udev 支持（仅在 HF2 仪器将与此 LabOne 安装程序搭配使用且与其他仪器类别无关时需要）。

一 键入 “ENTER” 同时安装选项 “a” 和 “u”。

4. 按下一章节所述，通过运行软件测试安装。

##### 在 Linux 中运行该软件

以下步骤介绍如何启动 LabOne 软件，从而通过用户界面访问并使用仪器。

1. 在命令提示符中启动 LabOne 数据服务器程序：

$ ziDataServer

用户应具备仪器的访问权限。如果出现问题，请查阅本章末尾的第 1.9 节。

2. 在命令提示符中启动 Web 服务器程序：

$ ziWebServer

3. 启动最新的 Web 浏览器并在浏览器地址栏中输入 127.0.0.1:8006，访问 Web 服务器程序并启动 LabOne 用户界面。PC 中安装的 LabOne Web 服务器默认通过端口 8006（而非端口 80）进行监听，以最大限度降低冲突概率。

4. 现在可以按第 1.6 节所述启动 LabOne 用户界面并通过 Device Connection（设备连接）对话框选择待连接仪器，如 Device Connection（设备连接）对话框所示。

##### 注意事项

请勿使用并行运行的两个数据服务器实例，每次仅可运行一个实例。

##### 卸载 Linux 中安装的 LabOne

LabOne 软件包将卸载脚本复制到基本安装路径（默认安装目录为 /opt/zi/）。要卸载 LabOne 软件包，请在命令行 shell 中执行以下步骤：

1. 导航至 LabOne 的安装路径。例如，如果 LabOne 安装于默认安装路径：

$ cd /opt/zi/

2. 以管理员权限运行卸载脚本并继续执行所有引导步骤：

$ sudo bash uninstall_LabOne<arch>-<release>-<revision>.sh

##### 在命令行中手动启动 LabOne

安装 LabOne 软件后，可以使用命令行手动启动 Web 服务器和数据服务器。Windows 中较为常用的 LabOne 启动方法请参见第 1.6 节。使用命令行的优点是能够观察和更改 Web 服务器和数据服务

器的行为。要手动启动上述服务器，请打开命令行终端（命令提示符、PowerShell（Windows）或Bash（Linux））。在 Windows 中，当前工作目录必须是 Web 服务器和数据服务器的安装目录。这些服务器分别安装在 Program Files 文件夹（通常是 C:\Program Files）的 \Zurich Instruments\LabOne 下的 WebServer 或 DataServer 文件夹中。Web 服务器和数据服务器（ziDataServer）通过在每个文件夹中运行各自的可执行文件来启动。请注意，每台计算机一次只能运行每个服务器的一个实例。服务器的行为可以通过提供命令行参数来更改。有关所有参数的详细列表，请参见命令行帮助说明：

$ ziWebServer --help

对于数据服务器：

$ ziDataServer --help

#### 1.5.2. LabOne 软件架构

通过 Zurich Instruments LabOne 软件可对仪器进行快捷访问。LabOne 还支持多个软件客户端（即 LabOne 用户界面客户端和/或 API 客户端）同时访问的高级配置，甚至是在不同计算机上工作的多个用户同时访问。接下来，我们将对 LabOne 软件的架构进行简单概述。本节介绍 LabOne 在独立 PC 而非 MFLI 仪器的嵌入式计算机中运行的情况。

Zurich Instruments 设备软件基于服务器。服务器和其他软件构件是在多个层面上组织的，参见图1.22。

一 在 PC 上运行的最底层是 LabOne 数据服务器，其为连接的仪器的接口。

一 中间层包含 LabOne Web 服务器，其为基于浏览器的 LabOne 用户界面的服务器。

一 图形用户界面与编程用户界面一同包含于顶层。

带一个中央数据服务器的架构允许多个客户端利用同步设置访问同一设备。下面的章节将详细介绍不同层面及其功能。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f0abdc57-014f-4848-a4db-80089e81aed6/markdown_4/imgs/img_in_image_box_218_836_1068_1341.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A38Z%2F-1%2F%2F2d470639f2ab461baf5c7f38ba077eb4f66f14d5bd394268f16faa9be3108ba3" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.22.LabOne 软件架构</div> </div>


##### LabOne 数据服务器

LabOne 数据服务器程序是一个专用服务器，负责设备的双向通信。数据服务器可控制单个或多个仪器。其将向所有订阅它的客户端发送来自仪器的测量数据，还可确保某个客户端对设置的更改传达给其他客户端，因此所有客户端的设备设置都是同步的。当 PC 启动时，服务会自动启动数据服

务器。当不存在活动会话时，尽管数据服务器仅占用少量资源，但如有必要，仍可禁用该服务。在PC上，只应运行LabOne数据服务器的单个实例。

##### LabOne Web 服务器

LabOne Web 服务器是一个专用应用程序，提供组成 LabOne 用户界面的网页。用户界面可在任何带 Web 浏览器的设备上打开。由于 LabOne 用户界面通过触摸启用，因此其可在平板电脑

等移动设备上使用。LabOne Web 服务器同时支持多个客户端，也就是说，可使用多个会话查看数据和操纵仪器。您可在装有 LabOne 软件的计算机的浏览器中运行一个会话，而这个会话在一个远程设备的浏览器中也同样可以良好运行。

在有一个 LabOne Web 服务器运行并访问仪器的情况下，您可在浏览器地址栏中输入网址和端口号来打开一个新的会话。如果 LabOne 在仪器的嵌入式计算机中运行，请参见第 1.4 节了解

访问 Web 服务器的地址。若 Web 服务器与浏览器在同一台计算机中运行，地址为本地主机地址（两者相同）：

一 127.0.0.1:8006（仅当 LabOne 在独立 PC 中运行时有效）

- localhost:8006（仅当 LabOne 在独立 PC 中运行时有效）

若 Web 服务器在远程计算机上运行，地址为远程计算机的 IP 地址或网络名：

192.168.x.y:8006

myPC.company.com:8006

请注意，后者在技术上等同于 Web 服务器在仪器的嵌入式计算机中运行的情况。此时，使用仪器的 IP 地址。支持常用浏览器的最新版本：Chrome、Firefox、Edge、Safari 和 Opera。

##### LabOne API 层

该仪器还可通过 Zurich Instruments 提供的应用程序接口 (API) 进行控制。在以下编程环境中，API 以 DLL 的形式提供：

一 MATLAB

一 Python

LabVIEW

一 .NET

- C

因此，外部程序可控制仪器并处理结果数据。可通过一个或多个 API 和用户界面同时访问设备，这样便可轻松集成到大型实验室装置中。有关更多信息，请参见 LabOne 编程手册。利用 API，用户可访问所有 LabOne 用户界面提供的所有功能。

### 1.6. LabOne 软件启动

本节介绍用于控制 MFLI 仪器的 LabOne 用户界面的启动。本启动会因 LabOne 软件是否安装在 PC 上（请参见第 1.5 节），或者是否使用仪器中的软件而稍有不同。无需在 PC 上安装 LabOne 即可操作仪器。如果使用仪器中的软件，一开始如何连接仪器并打开显示 LabOne 启动画面的浏览器窗口的步骤请参见第 1.4 节。

如果 PC 上安装了 LabOne，LabOne 用户界面启动链接可以在 Windows 10 开始菜单下找到（在 Windows 7 和 8 中，LabOne 用户界面启动链接可以通过以下路径找到：Start Menu（开始菜单）→ all programs/all apps（所有程序/所有应用程序）→ Zurich Instruments LabOne）。如图 1.23 所示，单击 Start Menu（开始菜单）→ Zurich Instruments LabOne。默认 Web 浏览器的新选项卡中将显示用户界面，同时在后台启动 LabOne 数据服务器和 LabOne Web 服务器程序。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//02abd3a6-555f-4c32-8229-57947cc6b45c/markdown_1/imgs/img_in_image_box_216_437_719_721.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A17Z%2F-1%2F%2F1f75ecae380588d1c9be8d29d325be94a9542be201bbef4bb41e49231b66c3f3" alt="Image" width="42%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.23.链接到 Windows 10 开始菜单中的 LabOne 用户界面（仅在 PC 上已安装 LabOne 时）</div> </div>


启动 LabOne 后，将显示图 1.24 中的 Device Connection（设备连接）对话框，从而为会话选择设备。术语“会话”是指用户界面与设备之间的活动连接。此类会话由设备设置和用户界面设置定义。可以同时启动多个会话。会话在共享的 LabOne Web 服务器中运行。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//02abd3a6-555f-4c32-8229-57947cc6b45c/markdown_1/imgs/img_in_image_box_216_905_1069_1299.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A18Z%2F-1%2F%2Fe60bb8db062bfb587a4cd3eaedbf9fbb9ad27d30a8c1becb552582184ad90cd5" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.24.Device Connection（设备连接）对话框</div> </div>


默认情况下，Device Connection（设备连接）对话框在 Basic（基本）视图中打开。在此视图中，可连接的所有设备均由带有序列号和状态信息的图标表示。如果需要，图标上会出现一个按钮来执行固件升级。否则，可以通过双击图标或单击对话框右下角的 Open 按钮来连接设备。

某些情况下建议单击 “Advanced”（高级）按钮，切换到 Device Connection（设备连接）对话框的 Advanced（高级）视图。Advanced（高级）视图让用户可以为新会话选择自定义设备和 UI 设置，并提供了适用于多仪器设置的进一步连接选项。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//02abd3a6-555f-4c32-8229-57947cc6b45c/markdown_2/imgs/img_in_image_box_218_119_1065_808.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A19Z%2F-1%2F%2F8d08ede52f54f9bb0f2b25dc31cbaf1d015159045cb0022323894efe8b840696" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.25.Device Connection（设备连接）对话框（Advanced（高级）视图）</div> </div>


Advanced（高级）视图由三部分组成：

Data Server Connectivity（数据服务器连接）

一 Available Devices（可用设备）

— Saved Settings（已保存设置）

Available Devices（可用设备）表格有一个显示过滤器，通常设置为 Default Data Server（默认数据服务器），可通过表格标题行中的下拉菜单访问。将其更改为 Local Data Servers（本地数据服务器）时，Available Devices（可用设备）表格将仅显示通过主机 PC 上的数据服务器进行的连接，并将包含通过 USB 直接连接主机 PC 或通过 1GbE 连接本地网络的所有仪器。使用 All Data Servers（所有数据服务器）过滤器时，也可以访问通过网络中其他 PC 上运行的数据服务器进行的连接。用户的仪器在 Available Devices（可用设备）表格中显示后，请执行以下步骤来启动新会话：

1. 在 Available Devices（可用设备）表格中选择一个仪器。

2. 除非您想使用默认设置，否则请在 Saved Settings（已保存设置）列表中选择设置文件。

3. 单击 Open 启动会话。

##### 注释

默认情况下，打开新会话将仅加载 UI 设置（例如绘图范围），而不是已保存设置文件中的设备设置（例如信号幅值）。为包括设备设置，请启用 Include Device Settings（包括设备设置）复选框。请注意，这可能会影响现有会话，因为设备设置会在不同会话之间共享。

##### 注释

如果并行使用 Zurich Instruments 的其他设备系列（UHF、HF2、MF、HDAWG、PQSC 或 SHF），Available Devices（可用设备）部分的列表也会包含这些设备。

以下章节将详细介绍 Device Connection（设备连接）对话框的功能。

#### 1.6.1. 数据服务器连接

Device Connection（设备连接）对话框会显示 Web 服务器。但在启动时，Web 服务器尚未连接到 LabOne 数据服务器。使用 Connect/Disconnect（连接/断开）按钮可以打开或关闭与数据服务器的连接。

仅使用一台 MFLI 仪器和一台主机时，该功能通常可以忽略。对于通过远程 PC（即不同于运行数据服务器的 PC）操作仪器或使用多台仪器的用户而言，数据服务器连接至关重要。随后，数据服务器连接功能支持 Web 服务器自由连接可供访问的数据服务器之一。这包括在远程计算机中运行的数据服务器，以及在 MF 系列仪器中运行的数据服务器。

将显示过滤器设置为 “Local Data Server”（本地数据服务器）后，显示可通过数据服务器（位于同一台计算机以及连接到 PC 的 MFLI 仪器）进行访问的所有仪器。将过滤器设置为 “All Data Servers”（所有数据服务器）时，将显示网络中所有可访问的数据服务器，包括在其他 PC 上运行的数据服务器。

##### 注释

使用 “All Data Servers”（所有数据服务器）过滤器时，请务必注意连接正确仪器，在大型本地网络中时尤其如此。请始终根据仪器后面板处 DEV0000 形式的设备序列号识别仪器。

#### 1.6.2. Available Devices（可用设备）

Available Devices（可用设备）表格概略显示可见设备。如果标记为“Free”（可用）或“Connected”（已连接），设备即可使用。该列表的第一列包含控制设备与数据服务器连接的Enable（启用）按钮。在使用Connect按钮将数据服务器连接到LabOne Web服务器前，该按钮始终灰显。若设备连接到数据服务器，则在另一台PC上运行的其他数据服务器无法访问该设备。

第二列指示序列号，而第三列显示仪器类型。第四列显示控制设备的 LabOne 数据服务器的主机名。下一列显示接口类型。对于 MF 仪器，提供 USB 或 1GbE 接口，如果以物理方式连接，则会列出该接口。对于 MF 系列仪器，如果数据服务器在仪器上运行，则接口表示为 PCIe，即使 PC 和仪器之间的物理连接是 USB 或 1GbE。PCIe 对应嵌入式 PC 与 MF 仪器内部测量单元之间的连接。LabOne 数据服务器将逐秒扫描可用设备和接口。如果设备刚刚开机或以物理方式连接，LabOne 数据服务器最长可能需要等待 20 秒才会显示。

<div style="text-align: center;"><div style="text-align: center;">表 1.5. 设备状态信息</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>Connected（已连接）</td><td style='text-align: center; word-wrap: break-word;'>该设备连接到 LabOne 数据服务器。该服务器可位于同一台 PC（指示为本地）或远程 PC（由其 IP 地址指示）。用户可以启动会话以使用该设备。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Free（可用）</td><td style='text-align: center; word-wrap: break-word;'>该设备未被任何 LabOne 数据服务器使用，可以单击 Open（打开）按钮进行连接。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>In Use（正在使用）</td><td style='text-align: center; word-wrap: break-word;'>该设备正由 LabOne 数据服务器使用。因此，设备无法通过特定接口进行访问。如需访问设备，需要断开连接。仅适用于 UHF 仪器。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Device FW upgrade required/available（需要/可以进行设备固件升级）</td><td style='text-align: center; word-wrap: break-word;'>设备固件已过期。请先按照第 1.8 节所述升级固件。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Device not yet ready（设备尚未准备就绪）</td><td style='text-align: center; word-wrap: break-word;'>设备显示并正在启动。</td></tr></table>





#### 1.6.3. Saved Settings（已保存设置）

设置文件可同时包含 UI 和设备设置。UI 设置控制 LabOne 用户界面的结构。例如打开的选项卡的位置和顺序。设备设置指定设备的安装。设备设置在设备上持续，直至下一次上电或通过加载其他设置文件覆盖。

这些列在表 1.6 中进行说明。通过单击需要排序的列标题排序表格行。默认按时间排序。因此，最新设置位于顶部。按“收藏”标记或设置文件名排序也是一种有效方法。

<div style="text-align: center;"><div style="text-align: center;">表 1.6. 列说明</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>★★</td><td style='text-align: center; word-wrap: break-word;'>允许将收藏的设置文件列为一组。通过激活设置文件相邻的星形图标并单击列标题，所选文件将在列表顶部或底部相应地归为一组。“收藏”标记将在设置文件中保存。当 LabOne 用户界面再次启动后，该行将再次标记为“收藏”。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Name（名称）</td><td style='text-align: center; word-wrap: break-word;'>设置文件的名称。在文件系统中，文件名的扩展名为 .xml。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Date（日期）</td><td style='text-align: center; word-wrap: break-word;'>上次写入设置文件的日期和时间。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Comment（注释）</td><td style='text-align: center; word-wrap: break-word;'>允许将注释存储于设置文件中。单击 Comment（注释）字段，可以输入文本，随后将其存储于设置文件。该注释对于说明特定测量条件非常有用。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Device Type（设备类型）</td><td style='text-align: center; word-wrap: break-word;'>保存此设置文件的仪器类型。</td></tr></table>

##### 特殊设置文件

某些文件名的前缀为“last_session”。当会话由用户明确终止或出现严重错误条件，LabOne Web 服务器自动创建此类文件并保存当前 UI 和设备设置。该前缀前置于最近使用的设置文件名称。这允许在启动新会话后恢复所有未保存的变更。

如果用户加载此类最后一个会话设置文件，“last_session_”前缀将从文件名中删除。否则，将存在自动保存覆盖用户明确保存设置的风险。

名称为 “Default Settings” 的设置文件包含默认 UI 设置。请参见表 1.7 中的按钮说明。

<div style="text-align: center;"><div style="text-align: center;">表 1.7. 按钮说明</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>Open（打开）</td><td style='text-align: center; word-wrap: break-word;'>将加载所选设置文件中存储的设置。“Include Device Settings”（包括设备设置）按钮控制是否只加载 UI 设置，或者是否包括设备设置。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Include Device Settings（包括设备设置）</td><td style='text-align: center; word-wrap: break-word;'>控制单击 Open（打开）时加载所选设置文件的哪一部分。一旦启用，设备和 UI 设置都会被加载。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Auto Start（自动启动）</td><td style='text-align: center; word-wrap: break-word;'>如果所选设备可用，请在启动时跳过会话对话框。默认 UI 设置将以原有设备设置进行加载。</td></tr></table>

##### 注释

用户设置文件将保存到目录结构的应用特定文件夹中。管理这些文件的最佳方法是使用 File Manager（文件管理器）选项卡。

##### 注释

在 LabOne 会话启动并建立所需 UI 设置后，可通过在 Config（配置）选项卡中保存名为“default_ui”的文件来自定义默认出厂 UI 设置。如需再次使用出厂默认值，必须使用 File Manager（文件管理器）选项卡来删除用户设置目录中的“default_ui”文件。

##### 注释

双击 Available Devices（可用设备）表格中的设备行是一种启动默认 LabOne UI 的快捷方式。该操作相当于选择所需设备，然后单击 Open（打开）按钮。

双击 Saved Settings（已保存设置）表格中的行是一种使用这些 UI 设置和（取决于 “Include Device Settings”（包括设备设置）复选框）设备设置来加载 LabOne UI 的快速方式。该操作相当于选择所需设置文件，然后单击 Open（打开）按钮。

#### 1.6.4. 托盘图标

LabOne 启动时，屏幕右下角默认出现托盘图标，如下图所示。右键单击该图标后，可以快速打开一个新的 Web 服务器会话，或者单击 Exit（退出）可以停止 LabOne Web 和数据服务器。双击该图标也会打开一个新的 Web 服务器会话，举例而言，这一操作尤其适用于设置与多个仪器的连接。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//33f930c9-b364-4375-b6e9-322fa3cec90e/markdown_0/imgs/img_in_image_box_218_632_523_726.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A08Z%2F-1%2F%2F07567ba25d76f824fe03e644ee7f59b34ff2734371fa2c0351933b4213f30ebf" alt="Image" width="25%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.26. Windows 10 中的 LabOne 托盘图标</div> </div>


#### 1.6.5. 消息

LabOne Web 服务器将在组件丢失或故障条件下显示附加消息。这些消息显示有关故障条件的信息。以下段落列出这些消息，提供解决问题所需用户操作的详细信息。

##### 与 LabOne Web 服务器连接丢失

在这种情况下，浏览器将无法连接到 LabOne Web 服务器。如果 Web 服务器和数据服务器在不同 PC 中运行并且网络连接中断，可能出现这种情况。只要 Web 服务器正在运行并且会话尚未超时，即可连接现有会话并继续。因此，在约 15 秒内，可以使用 Retry（重试）恢复原有会话连接。可通过 Reload（重新加载）按钮打开图 1.24 所示的 Device Connection（设备连接）对话框。下图显示了 Connection Lost（连接丢失）对话框的示例。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//33f930c9-b364-4375-b6e9-322fa3cec90e/markdown_0/imgs/img_in_image_box_218_1145_619_1300.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A08Z%2F-1%2F%2F6172577bbd0114ad63e888510956497c5207bb37d2dfdb0f811601ddf463b046" alt="Image" width="33%" /></div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//33f930c9-b364-4375-b6e9-322fa3cec90e/markdown_0/imgs/img_in_image_box_852_1148_1068_1301.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A09Z%2F-1%2F%2Fb7edf168f373b4d7b368ce32161b0e906e52af77c2b5f623a9136271fac16078" alt="Image" width="18%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.27. 对话框：连接丢失</div> </div>


##### 重新加载...

如果无法处理会话错误，LabOne Web 服务器将重新启动，以显示新的 Device Connection（设备连接）对话框，如图 1.24 所示。重启过程中将显示一个窗口，指示 LabOne 用户界面将重新加载。如果未重新加载，可按下键盘的 F5 键触发相同效果。下图显示了该对话框的示例。

Reloading...

[Info] LabOne User Interface is reloading...

##### 图 1.28. 对话框：重新加载

### 1.7. 使用 LabOne 编程接口

LabOne 可为 MATLAB、LabVIEW、Python、C 和 .NET 提供应用程序编程接口 (API)。这些 API 需要安装到 PC 上，具体使用方法如下文所述。Zurich Instruments 下载页面 www.zhinst.com/downloads 上提供了所需的安装程序。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//33f930c9-b364-4375-b6e9-322fa3cec90e/markdown_2/imgs/img_in_image_box_216_272_1070_834.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A10Z%2F-1%2F%2F9abe67f5749fb25b167d4229cd6a0fe41c76bcc2472f58911c77bd9ebbabe876" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.29. 安装在独立 PC 上的 LabOne API</div> </div>


LabOne API 通过 IP 端口 8004 与 MFLI 仪器上运行的数据服务器直接通信。

设备地址可为 <instrument-serial>、mf-<instrument-serial>、mf-<instrument-

serial>.<domain> 或 <IP address>。如果地址非完全限定，即未添加域名，API 将利用多播执行网络发现来获取 IP 地址。这可确保通过 USB 连接的设备可采用与通过 1GbE 连接的设备相同的方法进行访问。

#### 1.7.1. 使用 MATLAB 和 LabVIEW API

将 MATLAB 和 LabVIEW API 安装到 PC 时，有两种选择：第一种是安装包含上述 API 的 LabOne 主安装包。如果您想按第 1.5 节所述在此 PC 上运行数据服务器，这是一个不错的选择。有关安装 LabOne 主安装包的信息，请参见软件安装部分。第二种选择是仅安装所需的 API 安装包。有关安装和使用 MATLAB 和 LabVIEW API 的详细信息，请参见 LabOne 编程手册。

#### 1.7.2. 使用 Python API

要使用 Python API，需要安装单独的 Zurich Instruments LabOne Python 安装包。有关 LabOne Python API 安装和入门的详细信息，请参见 LabOne 编程手册。

#### 1.7.3. 使用 .NET 和 C API

若要使用 .NET 和 C API，需要安装包含所述 API 以及 MATLAB 和 LabVIEW API 的 LabOne 主安装包。有关安装 LabOne 主安装包的信息，请参见软件安装部分。

### 1.8. 软件更新

#### 1.8.1. 概览

建议定期将 MFLI 仪器中的 LabOne 软件更新到最新版本。如果仪器可以访问互联网，更新变得非常简单。仅需在软件中单击即可完成更新，如第 1.8.2 节所示。如果无法访问互联网，或禁用了 Automatic Update Check（自动更新检查）功能，则可通过拖放过程或使用 USB 大容量存储设备（例如记忆棒）更新软件。上述方法将在第 1.8.3 节和第 1.8.4 节中进行讲解。如果您通过独立安装程序使用其中一个 LabOne API，请谨记更新这部分软件。

### 1.8.2. 使用 Automatic Update Check（自动更新检查）功能更新 LabOne

更新软件分两步完成。第一步，通过从 Zurich Instruments 下载页面下载并安装 LabOne 软件更新 PC 中的 LabOne。第二步，启动 LabOne 后，需要通过 Device Connection（设备连接）对话框更新仪器固件，如第 1.8.5 节所示。如果在 LabOne 的安装过程中启用了“定期检查更新”，而且 LabOne 可以访问互联网，则只要有新版软件可供下载，Device Connection（设备连接）对话框中即会显示通知。后续可以在 LabOne 用户界面的 Config（配置）选项卡中更改该设置。如果禁用了 Automatic Update Check（自动更新检查）功能，用户可以随时通过单击 Device Connection（设备连接）对话框中的 Check For Update（检查更新）按钮来手动检查更新。如果发现更新，单击图 1.30 中显示的“Update Available”（更新可用）按钮将开始在 MFLI 仪器中下载和安装最新版 LabOne 软件。如果 LabOne 软件在独立 PC 中运行（请参见第 1.5 节），可通过单击“Update Available”（更新可用）下载适用于 Windows 或 Linux 的最新版 LabOne 安装程序，请参见图 1.31。下载后，按照软件安装中的说明更新 LabOne。更新软件后，还需要按照第 1.8.5 节所述更新仪器固件。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//33f930c9-b364-4375-b6e9-322fa3cec90e/markdown_3/imgs/img_in_image_box_216_878_692_1015.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A11Z%2F-1%2F%2Fd87e5101da748a808977bc90162883143aef5eee37bc2854d977aff7f8c94142" alt="Image" width="39%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.30.Device Connection（设备连接）对话框：提供的 LabOne 更新</div> </div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//33f930c9-b364-4375-b6e9-322fa3cec90e/markdown_3/imgs/img_in_image_box_216_1102_813_1300.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A11Z%2F-1%2F%2F7aa57e88a084d71b348d8b0e66125645b38fc27c4e8eb7eed3a8b03ff8d914e2" alt="Image" width="50%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.31. 使用 Automatic Update Check（自动更新检查）功能下载 LabOne MSI</div> </div>


#### 1.8.3. 通过拖放更新 LabOne

注释

更新仪器中的 LabOne 软件要求浏览器与 MFLI 仪器中运行的 Web 服务器相连。

从 Zurich Instruments 下载中心下载最新 LabOne 软件版本。选择 MFLI 仪器需要的版本。该文件的形式为 LabOneXX-00.00.00000.tar。

打开 Windows 资源管理器窗口并导航至下载的 LabOne 安装文件的位置（Windows 中通常是 Downloads 文件夹）。在 Linux 中，可以使用 Files 应用程序或其他支持拖放的文件管理器实用程序。自此，本说明将使用术语“资源管理器窗口”。

在 Web 浏览器中启动 LabOne 用户界面（通过在地址栏中键入序列号连接仪器中运行的 Web 服务器）。

一 打开 LabOne Config（配置）选项卡。

放置/重新设置资源管理器窗口和 Web 浏览器，以便显示 Config（配置）选项卡的 File Upload（文件上传）部分下的虚线矩形。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//33f930c9-b364-4375-b6e9-322fa3cec90e/markdown_4/imgs/img_in_image_box_257_434_1057_619.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A11Z%2F-1%2F%2Faa19fa56338b7117f8c6b69b403d2984d9d1a30c8a6739abb337198fa247eef2" alt="Image" width="67%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.32.Config（配置）选项卡显示软件更新的放置区域</div> </div>


将下载的 LabOne 安装文件从资源管理器窗口拖放至虚线矩形中。随即显示 Upload（上传）弹出窗口，指示上传进度。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//33f930c9-b364-4375-b6e9-322fa3cec90e/markdown_4/imgs/img_in_image_box_255_736_1053_995.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A11Z%2F-1%2F%2Faef6a26911a99eca1d58bcc730b61cc02a0140ae6a39ba29f4aac9d189dad50a" alt="Image" width="67%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.33.Upload（上传）弹出窗口</div> </div>


上传完毕后，将显示 LabOne Software Update（LabOne 软件更新）弹出窗口。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//33f930c9-b364-4375-b6e9-322fa3cec90e/markdown_4/imgs/img_in_image_box_255_1126_1052_1387.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A12Z%2F-1%2F%2Ffa7e0e270c9ebaee69dcd18799b1e299260c39eaff6d0d460f35369c7bce8d17" alt="Image" width="66%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.34.LabOne Software Update（LabOne 软件更新）弹出窗口</div> </div>


单击 LabOne Software Update（LabOne 软件更新）弹出窗口中的 OK（确定）。该操作将完成软件更新。

仪器中运行的服务器将重新启动，需要重新加载 LabOne 用户界面。将出现一个 Error（错误）弹出窗口，显示“The connection with the LabOne Web Server is lost”（与 LabOne Web 服务器的连接已丢失）的文本。* 单击 Reload（重新加载）按钮重新加载 LabOne 用户界面。

#### 1.8.4. 通过 USB 记忆棒更新 LabOne

##### 注释

更新仪器中的 LabOne 软件要求浏览器与 MFLI 仪器中运行的 Web 服务器相连。

从 Zurich Instruments 下载中心下载最新 LabOne 软件版本并将其复制至 USB 大容量存储设备。选择 MFLI 仪器需要的版本。该文件的形式为 LabOneMF-00.00.00000.tar。

在 Web 浏览器中启动 LabOne 用户界面（通过在地址栏中键入序列号连接仪器中运行的 Web 服务器）。

一 将 USB 大容量存储设备插入 MFLI 仪器背面的 USB 插口之一。

一 打开 LabOne File Manager（文件管理器）选项卡。

一 标有“USB1”的文件夹将在 File Manager（文件管理器）选项卡中显示，对应于插入的 USB 设备。展开 USB1 分支以查看其内容（双击文件夹图标）。

一 右键单击 LabOne 更新的 .tar 文件，然后选择 SW Update（软件更新）更新软件。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//3ac8a9e5-53f0-48d3-ab0c-5efa42f27ae0/markdown_0/imgs/img_in_image_box_256_711_1053_1067.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A47Z%2F-1%2F%2Ffe786f0074db76975fe5fee2adff430606465d95f7077d76c62671e449ed8c43" alt="Image" width="66%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.35.File Manager（文件管理器）选项卡</div> </div>


随即显示 Upload（上传）弹出窗口，指示上传进度。上传完毕后，将显示 LabOne Software Update（LabOne 软件更新）弹出窗口。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//3ac8a9e5-53f0-48d3-ab0c-5efa42f27ae0/markdown_0/imgs/img_in_image_box_257_1226_1053_1484.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A47Z%2F-1%2F%2F84d62d05ab9516291863133a4fa88b1c8f59a7a0fba690b6923738af1863f75a" alt="Image" width="66%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.36.LabOne Software Update（LabOne 软件更新）弹出窗口</div> </div>


单击 LabOne Software Update（LabOne 软件更新）弹出窗口中的 OK（确定）。该操作将完成软件更新。仪器中运行的服务器将重新启动，需要重新加载 LabOne 用户界面。将出现一个 Error（错误）弹出窗口，显示“The connection with the LabOne Web Server is lost”（与 LabOne Web 服务器的连接已丢失）的文本。

一 单击 Reload（重新加载）按钮重新加载 LabOne 用户界面。

#### 1.8.5. 更新仪器固件

即使 LabOne 软件在独立 PC 中运行，该软件仍有一部分在仪器中运行。为了区分二者，本文档余下部分将后者称为固件。软件升级至最新版本后，还应将仪器固件进行相应更新。

如果固件需要更新，Windows 下的 LabOne 用户界面的 Device Connection（设备连接）对话框中将进行提示。

在该对话框的 Basic（基本）视图中，“Upgrade FW”（更新固件）按钮与仪器图标一同显示，如图 1.37 所示。在 Advanced（高级）视图中，Available Devices（可用设备）表格的“Upgrade”（更新）列中将显示一项“Upgrade FW”（更新固件）链接。分别点击 Upgrade FW（更新固件），以打开固件更新启动对话框，如图 1.38 所示。固件升级大约需要 2 分钟。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//3ac8a9e5-53f0-48d3-ab0c-5efa42f27ae0/markdown_1/imgs/img_in_image_box_216_590_826_875.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A48Z%2F-1%2F%2Fc1557b1cc55c6941a9e9a4283fd16ea9f2b4017168d1b73d61a87035e7f03be3" alt="Image" width="51%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.37. 提供可用固件更新的 Device Connection（设备连接）对话框</div> </div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//3ac8a9e5-53f0-48d3-ab0c-5efa42f27ae0/markdown_1/imgs/img_in_image_box_214_959_1069_1248.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A48Z%2F-1%2F%2F9b6cd047a26643a3bd976ec3b8e1dde9e29487752187ac272d24446f6bfd468d" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.38.Device Firmware Update（设备固件更新）启动对话框</div> </div>


##### 注意事项

在固件更新过程中，请勿断开 USB 或 1GbE 电缆与仪器之间的连接或重新启动仪器。

如果在仪器固件升级过程中遇到任何问题，请通过 support@zhinst.com 与 Zurich Instruments 联系。

### 1.9. 故障诊断

本节旨在帮助用户解决和避免在软件使用和仪器操作过程中遇到的问题。

#### 1.9.1. 常见问题

MFLI 仪器是一种先进的实验室设备，具有远多于传统锁相放大器的特征和功能。要充分利用这些特征和功能，用户需要使用 LabOne 用户界面中的诸多设置。然而这些设置较为复杂，可能会令新手用户束手无措，某些设置组合甚至让专家用户都感到惊讶。为避免出现问题，最好的方法是使用 Config（配置）选项卡中的设置保存和加载功能。这样，用户可基于已知配置来操作仪器，实现对仪器的总体掌控。本节提供了一份简单易行的检查清单，来帮助解决最常见的问题。

<div style="text-align: center;"><div style="text-align: center;">表 1.8. 常见问题</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>问题</td><td style='text-align: center; word-wrap: break-word;'>检查项</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>软件无法安装或卸载</td><td style='text-align: center; word-wrap: break-word;'>请确认您拥有管理员/root权限。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>软件无法更新</td><td style='text-align: center; word-wrap: break-word;'>请使用Windows Apps &amp; Features（Windows应用程序与功能）功能中的Modify（修改）选项。在软件安装程序中选择Repair（修复），然后卸载旧软件版本，安装新版本。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>仪器无法开机</td><td style='text-align: center; word-wrap: break-word;'>请检查电源连接和保险丝。保险丝座集成在仪器后面板上的电源连接器中。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>仪器在单端模式中性能表现不好</td><td style='text-align: center; word-wrap: break-word;'>原因可能是仪器的信号输入端被设置为差分模式。请确保在Lock-in（锁相）选项卡或In/Out（输入/输出）选项卡中关闭差分输入模式。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>仪器出现高输入本底噪声（通过USB连接至主机时）</td><td style='text-align: center; word-wrap: break-word;'>USB电缆将仪器接地端连接至计算机接地端，这可能会将一些不必要的噪声引入测量结果中。在这种情况下，建议使用以UTPCat5类或6类电缆（UTP代表“非屏蔽双绞线”）实现电气隔离的以太网连接。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>仪器在低频下性能表现不好（100 Hz以下）：</td><td style='text-align: center; word-wrap: break-word;'>原因可能是仪器的信号输入端被设置为交流模式。请确认在Lock-in（锁相）选项卡或In/Out（输入/输出）选项卡中关闭交流耦合。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>仪器在工作期间性能表现不好</td><td style='text-align: center; word-wrap: break-word;'>对于当前应用而言，解调滤波器的带宽可能设置得过宽（噪声过多）或过窄（响应慢）。请确认解调滤波器设置与您的频率噪声方案是否相符。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>仪器在工作期间性能表现不好</td><td style='text-align: center; word-wrap: break-word;'>原因可能是输入信号出现削波现象。检测方法：观察仪器前面板上的红色LED灯或用户界面STATUS_TAB上的输入溢出（OVI）标志。这种情况可通过针对输入范围设置增加足够的裕量（例如最大信号峰值的50%至70%）来避免。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>使用MF-MD多解调器选件时，仪器表现异常</td><td style='text-align: center; word-wrap: break-word;'>原因很可能是开启了过多的信号发生器。可通过集成的示波器检查产生的信号输出，并检查同时激活的振荡器电压的数量。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>仪器测量结果不稳定</td><td style='text-align: center; word-wrap: break-word;'>请检查Status（状态）选项卡，以确认是否正在发生警告（红色标志）或者曾经发生警告（黄色标志）。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>仪器没有输出信号</td><td style='text-align: center; word-wrap: break-word;'>确认Lock-in（锁相）选项卡或In/Out（输入/输出）选项卡中的信号输出开关已开启。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>仪器以数字量I/O作为参考信号时锁相性能不好</td><td style='text-align: center; word-wrap: break-word;'>确保数字量输入信号具有高转换速率和保持阈值稳定。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>仪器以辅助模拟输入作为参考信号时锁相性能不好</td><td style='text-align: center; word-wrap: break-word;'>输入信号幅值可能过小。请选择合适的输入通道增益设置。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>从仪器到主机的数据流盘不连续</td><td style='text-align: center; word-wrap: break-word;'>请检查状态栏中的通信(COM)标志。三个标志分别指示偶尔样本损失、数据包丢失或停止。如果采样率设置得过高，会发生样本损失（仪器发送的样本数量多于接口和主机所能接收的数量）。数据包丢失表示仪器与主机之间的通信出现重大故障，这会危及仪器的性能。以上两个问题可通过减小设置的样本率来加以控制。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>以避免。停止标志表示，为防止用户界面崩溃，系统主动更改了某项设置。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>LabOne 用户界面无法启动（在 PC 中运行 LabOne 时）</td><td style='text-align: center; word-wrap: break-word;'>通过 Windows 任务管理器验证 LabOne 数据服务器 (ziDataServer.exe) 和 LabOne Web 服务器 (ziWebServer.exe) 是否正在运行。数据服务器应该由 ziService.exe 自动启动，Web 服务器应通过在 Windows 开始菜单中单击“Zurich Instruments LabOne”启动。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>如果两者都在运行，但是单击开始菜单未在默认浏览器的新选项卡中打开一个新用户界面会话，则可尝试在浏览器地址栏中输入 127.0.0.1:8006 手动创建一个新会话。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>用户界面不启动，或者能启动但保持空闲状态</td><td style='text-align: center; word-wrap: break-word;'>请确认数据服务器在主机上已经启动并且正在运行。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>用户界面运行缓慢，Web 浏览器进程的 CPU 占用率过高</td><td style='text-align: center; word-wrap: break-word;'>请确保针对用于 LabOne 的 Web 浏览器启用硬件加速。对于 Windows 操作系统，可通过如下路径启用硬件加速：Control Panel（控制面板）→ Display（显示）→ Screen Resolution（屏幕分辨率）。依次进入 Advanced Settings（高级设置）和 Trouble Shoot（疑难解答）。如果使用的是 NVIDIA 显卡，则需要使用 NVIDIA 控制面板。依次进入 Manage 3D Settings（管理 3D 设置）和 Program Settings（程序设置），并选择您要自定义的程序。</td></tr></table>





#### 1.9.2. 日志文件的位置

通过单击用户界面的 LabOne Device Connection（设备连接）对话框中的 Logs，能用最便捷的方式访问 LabOne Web 和数据服务器程序的最新日志文件。Device Connection（设备连接）对话框在软件启动时或在用户界面的 Config（配置）选项卡中单击 Session Manager 时打开。

如果 Web 和/或数据服务器在 MFLI 设备中运行（而不是在 PC 中），则日志文件以物理方式存储在 MFLI 仪器上，可以通过 LabOne 用户界面的第 4.17 节中的 Log（日志）文件夹访问这些日志文件。如果 Web 和/或数据服务器在 PC 中运行，而不是在 MFLI 的嵌入式计算机上运行（请参见第 1.5 节），则磁盘上的日志文件位置请见下文所述。

##### Windows

如果 Web 和/或数据服务器在 Windows PC 中运行，则可以在以下目录中找到它们的日志文件。

##### 注释

在 Windows 中，C:\Users\[USER]\AppData 文件夹默认隐藏。快速访问方法是在 Windows 文件资源管理器的地址栏中输入 %AppData%\\...。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//3ac8a9e5-53f0-48d3-ab0c-5efa42f27ae0/markdown_4/imgs/img_in_image_box_213_112_1073_380.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A51Z%2F-1%2F%2F91e91016d3d36ebd4364eb7f0f647d0576b8ae69d90b9abfc127f71fb129223a" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 1.39. 在 Windows 资源管理器中使用 %AppData%\.. 快捷方式访问隐藏文件夹。</div> </div>


##### Linux 和 macOS

如果 Web 和/或数据服务器在 Linux 或 macOS 中运行，则可以在以下目录中找到它们的日志文件。

LabOne 数据服务器 (ziDataServer): /tmp/ziDataServerLog_[USER]

LabOne Web 服务器 (ziWebServer): /tmp/ziWebServerLog_[USER]

### 第 2 章.功能概述

本章概述了 MFLI 仪器的功能。第一节包含图形概述以及硬件和软件功能列表。然后是对测量仪器前面板和后面板的详细介绍。最后一节是产品选择和订购支持。

### 2.1.特征

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//1cc7b26c-6a80-4ede-9679-7de3d13a3a8e/markdown_1/imgs/img_in_image_box_221_188_1067_766.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A29Z%2F-1%2F%2F66dcfdd915ad2e53363e664792612c0879f23893efe3b65c853a716433b397c0" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 2.1.MFLI 仪器概述</div> </div>


图 2.1 中显示的每台 MF 仪器（MFLI、MFIA）都由几个内部单元（浅蓝色）组成，周围是几个接口单元（深蓝色），左侧是前面板，右侧是后面板。橙色块是可选单元，可以一开始就订购或之后在现场升级。面板和接口单元之间的箭头表示物理连接和数据方向流。图中仅显示了一小部分内部连接。

期望信号连接到 MF 仪器的低噪声电流或电压输入，然后被放大到规定范围并迅速数字化。安装 MF-MD 选件后，可同时使用两个输入，例如启用 4 端子测量。产生的样本被送入由多达 4 个双相解调器组成的数字信号处理器。解调器输出样本在提供 LabOne 网络服务器的嵌入式处理器上进一步处理，用户可以通过任何运行浏览器的设备（PC、平板电脑或智能手机）连接到该服务器。无需安装软件。支持以太网和 USB。解调器样本也可作为模拟信号在 MF 仪器前面板上的辅助输出上使用。

数值振荡器生成正弦和余弦信号对，用于解调输入样本和生成 MF 输出信号。安装 MF-MD 选件后，输出加法器可以生成振荡器输出的线性组合，以生成多频输出信号：支持数模转换和信号缩放（范围）。

硬件触发和参考信号用于仪器内部的各种用途，例如触发解调、触发示波器数据采集，或生成外部参考时钟或触发向其他设备发送的信号。

##### 锁相工作模式

一 内部参考模式

一 外部参考模式

一 自动参考模式

一 阻抗模式，同时测量电流输入和电压输入（可选）

一 多谐波模式（可选，同时测量多达四个谐波频率）

一 任意频率模式（可选，以 4 个任意频率同时测量）

中频电压输入    
    
- 1 个低噪声中频 (MF) 电压输入、单端或差分、5 MHz 带宽    
- 可变输入范围    
- 可切换的输入阻抗    
- 可选择的交流/直流耦合    
- 可选择的仪器接地或浮动    
    
中频电流输入    
    
- 1 个低噪声中频电流输入、单端、5 MHz 带宽    
- 可变输入范围    
    
中频信号输出    
    
- 低失真中频输出、单端、差分、5 MHz 带宽    
- 可变输出范围    
- 数字和模拟偏移    
    
解调器和参考    
    
- 多达 4 个双相解调器    
- 多达 4 个可编程数值振荡器    
- 最多 2 个外部参考信号    
- 可单独编程的解调器滤波器    
- 128 位内部处理    
- 64 位分辨率解调器样本    
- 48 位内部参考分辨率    
    
辅助输入、输出和触发器    
    
- 4 个辅助输出，用户自定义信号    
- 2 个辅助输入，通用    
- 2 个输入和 2 个输出触发信号    
    
高速连接    
    
- USB 2.0 设备高速 480 Mbit/s 接口    
- 双 USB 2.0 Host 高速接口    
- LAN 1 Gbit/s 控制器接口    
- DIO: 32 位数字输入输出端口    
- 时钟输入连接器 (10 MHz)    
- 时钟输出连接器 (10 MHz)    
    
LabOne 工具箱    
    
- Sweeper    
- Scope    
- Numeric    
- Spectrum

一 Plotter

##### Data Acquisition

##### 软件连接

一 支持多客户端的数据服务器

一 适用于基于 C、LabVIEW、MATLAB、Python 的仪器编程的 API

### 2.2. 前面板介绍

前面板 BNC 连接器和控制 LED 的排列如图 2.2 所示，并在表 2.1 中列出。

##### 注释

图 2.2 显示了序列号为 MF-DEV3200 及以上的 MF 仪器的前面板（参见第 1.2 节）。在序列号较小的仪器上，+V 和 -V Diff 连接器（C* 和 D*）互换，并且几个连接器的间距不同。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//1cc7b26c-6a80-4ede-9679-7de3d13a3a8e/markdown_4/imgs/img_in_image_box_764_359_991_421.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A32Z%2F-1%2F%2F0dad1b740ea2bf35efe587b2246b4090687e6c197c1f47a03eeda5934b7a2099" alt="Image" width="19%" /></div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//1cc7b26c-6a80-4ede-9679-7de3d13a3a8e/markdown_4/imgs/img_in_image_box_229_401_1067_837.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A32Z%2F-1%2F%2F111e041294708d86851d4a322c2323d507de4222ae197c9a8a8e84ab73fb4cf9" alt="Image" width="70%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 2.2.MF 仪器前面板</div> </div>


<div style="text-align: center;"><div style="text-align: center;">表 2.1.MF 仪器前面板描述</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>位置</td><td style='text-align: center; word-wrap: break-word;'>标签/名称</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>A</td><td style='text-align: center; word-wrap: break-word;'>Signal Input I</td><td style='text-align: center; word-wrap: break-word;'>单端电流输入</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>B</td><td style='text-align: center; word-wrap: break-word;'>Current Input Signal Over</td><td style='text-align: center; word-wrap: break-word;'>此红色 LED 灯表示电流输入信号使 A/D 转换器饱和，因此必须扩大电流输入范围或衰减信号</td></tr><tr><td rowspan="3">C*（序列号在 3200 以上）</td><td rowspan="3">Signal Input -V Diff</td><td style='text-align: center; word-wrap: break-word;'>电压输入</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>单端模式：内部对地短路</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>差分模式：负电压输入</td></tr><tr><td rowspan="3">D*（序列号在 3200 以上）</td><td rowspan="3">Signal Input +V</td><td style='text-align: center; word-wrap: break-word;'>电压输入</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>单端模式：单端电压输入</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>差分模式：正电压输入</td></tr><tr><td rowspan="3">C*（序列号在 3200 以下）</td><td rowspan="3">Signal Input +V</td><td style='text-align: center; word-wrap: break-word;'>电压输入</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>单端模式：单端电压输入</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>差分模式：正电压输入</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>位置</td><td style='text-align: center; word-wrap: break-word;'>标签/名称</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td rowspan="3">D*（序列号在 3200 以下）</td><td rowspan="3">Signal Input -V Diff</td><td style='text-align: center; word-wrap: break-word;'>电压输入</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>单端模式：内部对地短路</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>差分模式：负电压输入</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>E</td><td style='text-align: center; word-wrap: break-word;'>Voltage Input Signal Over</td><td style='text-align: center; word-wrap: break-word;'>此红色 LED 灯表示电压输入信号使 A/D 转换器饱和，因此必须扩大电流输入范围或衰减信号</td></tr><tr><td rowspan="3">F</td><td rowspan="3">Signal Output +V</td><td style='text-align: center; word-wrap: break-word;'>电压输出</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>单端模式：单端电压输出</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>差分模式：正电压输出</td></tr></table>

## 2.2 前面板介绍



<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>位置</td><td style='text-align: center; word-wrap: break-word;'>标签/名称</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td rowspan="3">G</td><td rowspan="3">Signal Output -V Diff</td><td style='text-align: center; word-wrap: break-word;'>电压输出</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>单端模式：内部对地短路</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>差分模式：负电压输出</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>H</td><td style='text-align: center; word-wrap: break-word;'>Signal Output ON</td><td style='text-align: center; word-wrap: break-word;'>此蓝色 LED 灯表示信号输出由仪器主动驱动</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>I</td><td style='text-align: center; word-wrap: break-word;'>Aux Input 2 Ref</td><td style='text-align: center; word-wrap: break-word;'>辅助输入 2，可用作支持设备全带宽的外部参考输入</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>J</td><td style='text-align: center; word-wrap: break-word;'>Aux Output 2</td><td style='text-align: center; word-wrap: break-word;'>辅助输出 2，此连接器提供用户自定义信号，通常用于输出解调样本 (X,Y) 或 (R,THETA)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>K</td><td style='text-align: center; word-wrap: break-word;'>Aux Output 4</td><td style='text-align: center; word-wrap: break-word;'>辅助输出 4，此连接器提供用户自定义信号，通常用于输出解调样本 (X,Y) 或 (R,THETA)</td></tr><tr><td rowspan="6">L</td><td rowspan="6">Power</td><td style='text-align: center; word-wrap: break-word;'>此 LED 灯指示仪器已通电</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>蓝色：设备与 LabOne 数据服务器之间已建立活动连接并准备运行。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>绿色闪烁：固件准备就绪，等待 LabOne 数据服务器连接。这个过程大约需要 20 秒。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>红色：设备未初始化，分别在执行内部自动校准进程。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>紫色闪烁：正在更新固件。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>紫色：启动进程失败。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>M</td><td style='text-align: center; word-wrap: break-word;'>Aux Input 1 Ref</td><td style='text-align: center; word-wrap: break-word;'>辅助输入 1，可作为支持仪器全带宽的外部参考输入；辅助输入 1 的值可作为偏移添加到信号输出</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>N</td><td style='text-align: center; word-wrap: break-word;'>Aux Output 1</td><td style='text-align: center; word-wrap: break-word;'>辅助输出 1，此连接器提供用户自定义信号，通常用于输出解调样本 (X,Y) 或 (R,Theta)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>O</td><td style='text-align: center; word-wrap: break-word;'>Aux Output 3</td><td style='text-align: center; word-wrap: break-word;'>辅助输出 3，此连接器提供用户自定义信号，通常用于输出解调样本 (X,Y) 或 (R,Theta)</td></tr></table>

有关电源 LED 颜色含义的更多信息，请参阅故障处理部分。

### 2.3. 后面板介绍

后面板是电源、控制、服务以及与其他 ZI 仪器连接的主要接口。各项的详细说明请参见图 2.3 和表 2.2。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//2a79df9b-359c-417b-9e90-a72e64d19582/markdown_1/imgs/img_in_image_box_217_241_1069_728.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A46Z%2F-1%2F%2F0f4d635413f37eda0d2edbdf275cfedc54c372d11a266c71f3fd7f319ee5a43a" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 2.3.MF 仪器后面板</div> </div>


<div style="text-align: center;"><div style="text-align: center;">表 2.2.MF 仪器后面板描述</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>位置</td><td style='text-align: center; word-wrap: break-word;'>标签/名称</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>A</td><td style='text-align: center; word-wrap: break-word;'>DC In</td><td style='text-align: center; word-wrap: break-word;'>外部 12 V 直流电源</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>B</td><td style='text-align: center; word-wrap: break-word;'>DIO</td><td style='text-align: center; word-wrap: break-word;'>32 位数字输入/输出连接器</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>C</td><td style='text-align: center; word-wrap: break-word;'>USB 2.0 Host</td><td style='text-align: center; word-wrap: break-word;'>通用串行总线主机连接器</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>D</td><td style='text-align: center; word-wrap: break-word;'>USB 2.0 Device</td><td style='text-align: center; word-wrap: break-word;'>连接计算机的通用串行总线设备连接器</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>E</td><td style='text-align: center; word-wrap: break-word;'>LAN 1GbE</td><td style='text-align: center; word-wrap: break-word;'>1 Gbit 以太网 LAN 连接器</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>F</td><td style='text-align: center; word-wrap: break-word;'>Trigger In 2</td><td style='text-align: center; word-wrap: break-word;'>数字 TTL 触发输入 2</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>G</td><td style='text-align: center; word-wrap: break-word;'>Trigger Out 2</td><td style='text-align: center; word-wrap: break-word;'>数字 TTL 触发输出 2</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>H</td><td style='text-align: center; word-wrap: break-word;'>Clk 10 MHz In</td><td style='text-align: center; word-wrap: break-word;'>用于与外部仪器同步的时钟输入 (10 MHz)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>I</td><td style='text-align: center; word-wrap: break-word;'>Clk 10 MHz Out</td><td style='text-align: center; word-wrap: break-word;'>用于与外部仪器同步的时钟输出 (10 MHz)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>J</td><td style='text-align: center; word-wrap: break-word;'>Earth ground</td><td style='text-align: center; word-wrap: break-word;'>用于接地的 4 mm 蕉形插孔连接器，电气连接到底架和电源插口的接地销针</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>K</td><td style='text-align: center; word-wrap: break-word;'>USB 2.0 Host</td><td style='text-align: center; word-wrap: break-word;'>通用串行总线主机连接器</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>L</td><td style='text-align: center; word-wrap: break-word;'>Power inlet</td><td style='text-align: center; word-wrap: break-word;'>带 ON/OFF 开关的电源插口</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>M</td><td style='text-align: center; word-wrap: break-word;'>Trigger In 1</td><td style='text-align: center; word-wrap: break-word;'>数字 TTL 触发输入 1</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>N</td><td style='text-align: center; word-wrap: break-word;'>Trigger Out 1</td><td style='text-align: center; word-wrap: break-word;'>数字 TTL 触发输出 1</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>O</td><td style='text-align: center; word-wrap: break-word;'>Cooling outlet</td><td style='text-align: center; word-wrap: break-word;'>通风口（注意：切勿堵塞）</td></tr></table>

### 2.4. 订购指南

表 2.3 概述了可订购的 MF 产品。可以随时购买升级选件，无需将仪器寄给 Zurich Instruments。

<div style="text-align: center;"><div style="text-align: center;">表 2.3. 可订购的 MF 仪器产品代码</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>产品代码</td><td style='text-align: center; word-wrap: break-word;'>产品名称</td><td style='text-align: center; word-wrap: break-word;'>描述</td><td style='text-align: center; word-wrap: break-word;'>是否支持现场升级</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>MFLI 500 kHz</td><td style='text-align: center; word-wrap: break-word;'>MFLI 500 kHz 锁相放大器</td><td style='text-align: center; word-wrap: break-word;'>基础产品</td><td style='text-align: center; word-wrap: break-word;'>-</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>MFLI 5 MHz</td><td style='text-align: center; word-wrap: break-word;'>MFLI 5 MHz 锁相放大器</td><td style='text-align: center; word-wrap: break-word;'>捆绑产品</td><td style='text-align: center; word-wrap: break-word;'>-</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>MF-MD</td><td style='text-align: center; word-wrap: break-word;'>MF-MD 多解调器</td><td style='text-align: center; word-wrap: break-word;'>选件</td><td style='text-align: center; word-wrap: break-word;'>支持</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>MF-F5M</td><td style='text-align: center; word-wrap: break-word;'>MF-F5M 频率扩展</td><td style='text-align: center; word-wrap: break-word;'>选件</td><td style='text-align: center; word-wrap: break-word;'>支持</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>MF-DIG</td><td style='text-align: center; word-wrap: break-word;'>MF-DIG 数字转换器</td><td style='text-align: center; word-wrap: break-word;'>选件</td><td style='text-align: center; word-wrap: break-word;'>支持</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>MF-IA</td><td style='text-align: center; word-wrap: break-word;'>MF-IA 阻抗分析仪</td><td style='text-align: center; word-wrap: break-word;'>选件（包括 MFITF）</td><td style='text-align: center; word-wrap: break-word;'>支持</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>MFITF</td><td style='text-align: center; word-wrap: break-word;'>阻抗测试夹具</td><td style='text-align: center; word-wrap: break-word;'>附件（MFIA 和 MF-IA 随附）</td><td style='text-align: center; word-wrap: break-word;'>-</td></tr></table>

MF 产品线包括 MFLI 锁相放大器系列和 MFIA 阻抗分析仪系列。MFLI 5 Mhz 和 MF-IA 的组合相当于 MFIA 5 Mhz 产品，MFLI 500 kHz 和 MF-IA 的组合相当于 MFIA 500 kHz 产品。下表概述了针对最重要的产品配置的功能。

<div style="text-align: center;"><div style="text-align: center;">表 2.4. 产品选择器</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>功能</td><td style='text-align: center; word-wrap: break-word;'>MFLI</td><td style='text-align: center; word-wrap: break-word;'>MFLI +MF-MD</td><td style='text-align: center; word-wrap: break-word;'>MFLI +MF-F5M</td><td style='text-align: center; word-wrap: break-word;'>MFLI +MF-MD +MF-F5M</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>内部参考模式</td><td style='text-align: center; word-wrap: break-word;'>支持</td><td style='text-align: center; word-wrap: break-word;'>支持</td><td style='text-align: center; word-wrap: break-word;'>支持</td><td style='text-align: center; word-wrap: break-word;'>支持</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>外部参考模式</td><td style='text-align: center; word-wrap: break-word;'>支持</td><td style='text-align: center; word-wrap: break-word;'>支持</td><td style='text-align: center; word-wrap: break-word;'>支持</td><td style='text-align: center; word-wrap: break-word;'>支持</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>自动参考模式</td><td style='text-align: center; word-wrap: break-word;'>支持</td><td style='text-align: center; word-wrap: break-word;'>支持</td><td style='text-align: center; word-wrap: break-word;'>支持</td><td style='text-align: center; word-wrap: break-word;'>支持</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>阻抗模式（独立测量电压和电流信号输入）</td><td style='text-align: center; word-wrap: break-word;'>-</td><td style='text-align: center; word-wrap: break-word;'>支持</td><td style='text-align: center; word-wrap: break-word;'>-</td><td style='text-align: center; word-wrap: break-word;'>支持</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>信号发生器</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>1</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>每个发生器的叠加输出正弦曲线</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>最多4个</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>最多4个</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>四次谐波模式</td><td style='text-align: center; word-wrap: break-word;'>-</td><td style='text-align: center; word-wrap: break-word;'>支持</td><td style='text-align: center; word-wrap: break-word;'>-</td><td style='text-align: center; word-wrap: break-word;'>支持</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>多频模式</td><td style='text-align: center; word-wrap: break-word;'>-</td><td style='text-align: center; word-wrap: break-word;'>支持</td><td style='text-align: center; word-wrap: break-word;'>-</td><td style='text-align: center; word-wrap: break-word;'>支持</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>任意频率模式</td><td style='text-align: center; word-wrap: break-word;'>-</td><td style='text-align: center; word-wrap: break-word;'>支持</td><td style='text-align: center; word-wrap: break-word;'>-</td><td style='text-align: center; word-wrap: break-word;'>支持</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>解调器数量</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>4</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>4</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>同时频率</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>4</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>4</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>同时谐波</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>4</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>4</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>功能</td><td style='text-align: center; word-wrap: break-word;'>MFLI</td><td style='text-align: center; word-wrap: break-word;'>MFLI +MF-MD</td><td style='text-align: center; word-wrap: break-word;'>MFLI +MF-F5M</td><td style='text-align: center; word-wrap: break-word;'>MFLI +MF-MD +MF-F5M</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>外部参考</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>2</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>2</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>动态储备</td><td style='text-align: center; word-wrap: break-word;'>120 dB</td><td style='text-align: center; word-wrap: break-word;'>120 dB</td><td style='text-align: center; word-wrap: break-word;'>120 dB</td><td style='text-align: center; word-wrap: break-word;'>120 dB</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>频率范围</td><td style='text-align: center; word-wrap: break-word;'>500 kHz</td><td style='text-align: center; word-wrap: break-word;'>500 kHz</td><td style='text-align: center; word-wrap: break-word;'>5 MHz</td><td style='text-align: center; word-wrap: break-word;'>5 MHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>USB 2.0 480 Mbit/s</td><td style='text-align: center; word-wrap: break-word;'>支持</td><td style='text-align: center; word-wrap: break-word;'>支持</td><td style='text-align: center; word-wrap: break-word;'>支持</td><td style='text-align: center; word-wrap: break-word;'>支持</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>以太网 1 GbE</td><td style='text-align: center; word-wrap: break-word;'>支持</td><td style='text-align: center; word-wrap: break-word;'>支持</td><td style='text-align: center; word-wrap: break-word;'>支持</td><td style='text-align: center; word-wrap: break-word;'>支持</td></tr></table>

### 2.5. 机架安装

可通过 support@zhinst.com 向 Zurich Instruments 索取用于在 19" 机架中安装 MFLI 的零件。可以将一台 MFLI 或两台 MFLI 仪器并排安装装入机架，详见以下说明。

#### 2.5.1. 单台仪器的安装说明

<div style="text-align: center;"><div style="text-align: center;">表 2.5. 单台仪器机架安装需要的零件</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>描述</td><td style='text-align: center; word-wrap: break-word;'>数量</td><td style='text-align: center; word-wrap: break-word;'>单位</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>19&quot; 角托架 Magic 2U RAL 9003</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>19&quot; 转接板 2U RAL 9003</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>盘头螺钉 M6 x 16 ISO 14583 A2 T30</td><td style='text-align: center; word-wrap: break-word;'>4</td><td style='text-align: center; word-wrap: break-word;'>件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DIN 125 A 6.4 钢制镀锌垫圈</td><td style='text-align: center; word-wrap: break-word;'>4</td><td style='text-align: center; word-wrap: break-word;'>件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>卡式螺母 KM 6</td><td style='text-align: center; word-wrap: break-word;'>4</td><td style='text-align: center; word-wrap: break-word;'>件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>ISO 7380 M4x12 梅花头镀锌螺钉</td><td style='text-align: center; word-wrap: break-word;'>2</td><td style='text-align: center; word-wrap: break-word;'>件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DIN 9021 Ø 4.3 镀锌垫圈</td><td style='text-align: center; word-wrap: break-word;'>2</td><td style='text-align: center; word-wrap: break-word;'>件</td></tr></table>

1. 卸下 4 颗 M3×7 螺钉

2. 卸下 2 个装饰件

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//2a79df9b-359c-417b-9e90-a72e64d19582/markdown_3/imgs/img_in_image_box_340_674_948_936.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A48Z%2F-1%2F%2Fb821dd3abb641ad37288369351322be29b6a61652be09764159e5c73c1322128" alt="Image" width="51%" /></div>


3. 使用第 1 步卸下的螺钉安装 2 个 19" 角支架 Magic 2U RAL 9003

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//2a79df9b-359c-417b-9e90-a72e64d19582/markdown_3/imgs/img_in_image_box_341_1048_957_1317.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A48Z%2F-1%2F%2F9271cabdf376a0f0c5a807db59a1250a028b68ace9f4ed51a51e9ba5845cd7b7" alt="Image" width="51%" /></div>


4. 使用 2 颗 ISO 7380 M4×12 梅花头螺钉和 DIN 9021 ∅ 4.3 垫圈安装 19" 转接板 2U RAL 9003

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//2a79df9b-359c-417b-9e90-a72e64d19582/markdown_4/imgs/img_in_image_box_342_117_995_462.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A49Z%2F-1%2F%2F8e73ee5b7049eb7cd8804f681b71052e0764aba0e385ab2af6f086705ed9679b" alt="Image" width="54%" /></div>


5. 安装 4 个 DIN 125 A 6.4 垫圈和 4 颗 ISO 14583 M6×16 梅花头螺钉进行机架安装

6. 将 4 个卡式螺母 KM6 安装到机柜上

7. 将仪器安装到机柜上

#### 2.5.2. 两台仪器的安装说明

<div style="text-align: center;"><div style="text-align: center;">表 2.6. 两台仪器机架安装需要的零件</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>描述</td><td style='text-align: center; word-wrap: break-word;'>数量</td><td style='text-align: center; word-wrap: break-word;'>单位</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>外部 Magic 2U 连接条</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>内部 Magic 2U 连接条</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>19&quot; 角托架 Magic 2U RAL 9003</td><td style='text-align: center; word-wrap: break-word;'>2</td><td style='text-align: center; word-wrap: break-word;'>件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>背面 Magic 2U 连接条</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>梅花头开槽螺钉DIN 965 M2.5x10 A2</td><td style='text-align: center; word-wrap: break-word;'>2</td><td style='text-align: center; word-wrap: break-word;'>件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>锁紧式开槽螺钉DIN 7985 M3x12 Torx A2</td><td style='text-align: center; word-wrap: break-word;'>2</td><td style='text-align: center; word-wrap: break-word;'>件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>盘头螺钉 M6 x 16 ISO 14583 A2 T30</td><td style='text-align: center; word-wrap: break-word;'>4</td><td style='text-align: center; word-wrap: break-word;'>件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DIN 125 A 6.4 钢制镀锌垫圈</td><td style='text-align: center; word-wrap: break-word;'>4</td><td style='text-align: center; word-wrap: break-word;'>件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>卡式螺母 KM 6</td><td style='text-align: center; word-wrap: break-word;'>4</td><td style='text-align: center; word-wrap: break-word;'>件</td></tr></table>

#### 组装说明：左底架

1. 卸下左侧的 2 颗 M3×7 螺钉和左侧装饰件

2. 卸下右侧的 2 颗 M3×7 螺钉

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//2a79df9b-359c-417b-9e90-a72e64d19582/markdown_4/imgs/img_in_image_box_305_1159_906_1414.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A49Z%2F-1%2F%2Fde5caf14c72246fec71df466980f9f3e75c092fe1105925d11c578a6ed65e960" alt="Image" width="50%" /></div>


3. 使用第 1 步卸下的 2 颗 M3×7 螺钉，将 19" 角支架 Magic 2U RAL 9003 安装到左侧

4. 用 2 颗 DIN 7985 梅花头螺钉 M3×12 将连接条 Magic 2U 从外部安装到右侧

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//77ad3fe5-d4f6-4c96-8a57-d43922cd8cc0/markdown_0/imgs/img_in_image_box_301_122_948_385.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A19Z%2F-1%2F%2F3080e264a7e967dd9f1f88a2cca780853758788753f31235c1b376c2033151e6" alt="Image" width="54%" /></div>


##### 组装说明：右底架

1. 卸下右侧的 2 颗 M3×7 螺钉和右侧装饰件

2. 卸下左侧的 2 颗 M3×7 螺钉

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//77ad3fe5-d4f6-4c96-8a57-d43922cd8cc0/markdown_0/imgs/img_in_image_box_301_561_895_822.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A19Z%2F-1%2F%2F5ee0e3035898926d9957aa7035b3d93fc7f2c57f18d55137a857ecb9d772a60b" alt="Image" width="49%" /></div>


3. 使用第 1 步卸下的 2 颗 M3×7 螺钉，将 19" 角支架 Magic 2U RAL 9003 安装到右侧

4. 用圆柱头螺钉 M3×12 Torx 将连接条 Magic 2U 从内部安装到左侧

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//77ad3fe5-d4f6-4c96-8a57-d43922cd8cc0/markdown_0/imgs/img_in_image_box_251_947_885_1217.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A19Z%2F-1%2F%2Fca149ca8800618321820647fd8a01562b48c2c12ccfab4ca8e0fb32425c18c05" alt="Image" width="53%" /></div>


##### 底架组装

1. 将两个底架安装在一起，并用 2 颗 DIN 965 M2.5×10 梅花头螺钉穿过连接条进行固定

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//77ad3fe5-d4f6-4c96-8a57-d43922cd8cc0/markdown_1/imgs/img_in_image_box_301_119_997_406.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A20Z%2F-1%2F%2Ff42d4e5cc3ed45108c4e3bd6f6e422c6be06a98ba24fb950634ea1e9475f12d1" alt="Image" width="58%" /></div>


# 2. 卸下 4 颗螺钉和 2 个塑料内盖

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//77ad3fe5-d4f6-4c96-8a57-d43922cd8cc0/markdown_1/imgs/img_in_image_box_305_478_869_725.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A21Z%2F-1%2F%2F1661cf132eefbfe4b1dfe29a990d97b5385f064dd5abff860cac52967f6dd148" alt="Image" width="47%" /></div>


3. 用第 2 步卸下的螺钉安装后连接条

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//77ad3fe5-d4f6-4c96-8a57-d43922cd8cc0/markdown_1/imgs/img_in_image_box_358_813_919_1056.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A21Z%2F-1%2F%2F92078bb1684f52eb375bd5c72b0ccdfd87b3ff7d836ad7ef6e02470de5c91ffa" alt="Image" width="47%" /></div>


# 4. 将卡式螺母 KM6 安装到机柜上

### 第 3 章.教程

本章中的教程旨在让用户更加熟悉锁相放大的基本技术、基于主机的锁相放大器的操作、基于LabOne Web 浏览器的用户界面以及一些更高级的锁相测量技术。为了更快掌握教程的内容，用户需要具备一定的实验室设备和基本设备操作知识。设备清单如下。

##### 注释

在所有教程中，您必须按照第 1 章中的说明安装 LabOne。我们使用系统命名法来描述 LabOne 图形用户界面的不同控件和元素。该命名法在第 4.1 节中进行了说明。

一 1 根 USB 或 LAN 电缆

一 5 根 BNC 电缆

一 1 个示波器（可选）

一 2 个 BNC T 型件

一 仅带 MF-IA 选件

一 1 个开尔文探针电缆组以及 1 Ω 和 10 Ω 通孔电阻器（用于“补偿”教程）

一 1 MΩ 通孔电阻器和焊接设备（用于“高级阻抗测量”教程）

### 3.1. 简易回路

注释

本教程适用于所有 MFLI 仪器。无需特定选件。

#### 3.1.1. 目标和要求

本教程适用于不熟悉 Zurich Instruments 锁定放大器的人群。通过使用非常基本的测量设置，本教程以分步实践的方式展示了 MFLI 仪器和 LabOne UI 的基本工作原理。

本教程没有特殊要求。

#### 3.1.2. 准备

在本教程中，您需要使用 MFLI 仪器生成单端信号，并在同一仪器上使用内部参考来测量生成的信号。方法是使用较短的 BNC 电缆（理想情况下 < 30 cm）将 Signal Output +V 连接到 Signal Input +V。或者，也可以使用 T 型件和额外的 BNC 电缆将 Signal Output +V 处生成的信号连接到示波器。图 3.1 显示了硬件设置的草图。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//77ad3fe5-d4f6-4c96-8a57-d43922cd8cc0/markdown_3/imgs/img_in_image_box_219_658_1058_962.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A22Z%2F-1%2F%2F8b1e61ee89228f499aff669c720e35071ca62b35c8a9d4e6fda5ba70a5ef4a77" alt="Image" width="70%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.1.简易回路教程需要的设置（显示 LAN 连接）</div> </div>


##### 注释

本教程适用于所有 MFLI，与安装了哪套特定的选件无关。如果安装的是 MF-MD 多解调器选件，须注意说明中的一些更改。

如上所述连接电缆。确保 MFLI 仪器已通电，然后通过 USB 将 MFLI 直接连接到主机或通过以太网连接到主机所在的局域网 (LAN)。使用 Web 浏览器地址并通过 Web 浏览器连接到仪器后，LabOne 图形用户界面打开。有关详细说明，请查看第 1 章。本教程可以使用默认仪器配置（例如，重启后）和默认用户界面设置（即在浏览器中按 F5 键后）启动。

#### 3.1.3. 生成测试信号

执行以下步骤，在 Signal Output +V 上生成 0.5 V 峰值幅度的 300 kHz 信号。我们使用图形 Lock-in（锁相）选项卡。请注意，此选项卡中的控件元素会根据 Web 浏览器窗口大小动态调整其外观。请务必在全屏尺寸下进行此测试。

1. 在 Lock-in（锁相）选项卡中，选择屏幕左侧的子选项卡 1。在 Reference（参考）部分，将振荡器 1 的频率值更改为 300 kHz：单击该字段，输入 300000 或 300 k，然后按键盘上的 <TAB> 或 <ENTER> 键以激活设置。

2. 在 Output Amplitudes（输出幅值）部分，将幅值设置为 500 mV（峰值）并通过单击标有“En”的按钮启用信号。顶部的单个绿色 LED 灯指示已启用的信号。

3. 在 Signal Output 1（信号输出 1）部分（Lock-in（锁相）选项卡的右侧），将 Range（范围）下拉列表设置为 1 V，将 Offset（偏移）设置为 0 V。不要选中 Add（添加）和 Diff（差分）按钮。

4. 默认情况下，MFLI 的所有物理输出都处于非活动状态，以防 MFLI 或与 MFLI 连接的设备损坏。现在通过单击标有“On”（打开）的按钮来打开主输出。

表 3.1 总结了要完成的仪器设置。如果将示波器连接到装置，现在应该能够看到生成的正弦信号，其峰峰幅值为 1 V。确保在示波器上选择高输入阻抗。无需额外的设备，因为 MFLI 带有内置示波器。在第 3.1.4 节中，我们介绍了使用方法。

<div style="text-align: center;"><div style="text-align: center;">表 3.1. 设置：生成测试信号</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Oscillator（振荡器）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Frequency（频率）</td><td style='text-align: center; word-wrap: break-word;'>300 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Output（输出）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Amplitude（幅值）</td><td style='text-align: center; word-wrap: break-word;'>500 mV</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Output（输出）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Offset（偏移）</td><td style='text-align: center; word-wrap: break-word;'>0 V</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Output（输出）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>On（打开）</td><td style='text-align: center; word-wrap: break-word;'>On（打开）</td></tr></table>

#### 3.1.4. 检查测试输入信号

接下来，我们从 Lock-in（锁相）选项卡配置 MFLI 的信号输入端，然后使用 Scope（示波器）选项卡来显示输入信号。在 Lock-in（锁相）选项卡的 Signal Input（信号输入）部分，从下拉菜单中选择 Sig In 1（信号输入 1）。将范围设置为 1.0 V，并确保未选中 AC（交流）、50  $ \Omega $、Diff（差分）和 Float（浮动）按钮。

范围设置确保 Signal Input +V 上的模拟放大设置为有效使用输入模数转换器的分辨率而不会导致信号出现削波现象。这样可以优化动态范围。

现在可以使用 Scope（示波器）选项卡来观察一段时间内的输入信号。通过单击左侧边栏中的图标或将 Scope（示波器）图标拖到其中一个打开的选项卡行，将 Scope（示波器）视图置于 Web 浏览器中。在 Scope（示波器）选项卡上选择以下设置以显示进入 Signal Input +V 的信号：

<div style="text-align: center;"><div style="text-align: center;">表 3.2. 设置：检查测试信号</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Signal Input（信号输入）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Float（浮动）</td><td style='text-align: center; word-wrap: break-word;'>Off（关闭）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Signal Input（信号输入）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Diff（差分）</td><td style='text-align: center; word-wrap: break-word;'>Off（关闭）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Signal Input（信号输入）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>50 \Omega</td><td style='text-align: center; word-wrap: break-word;'>Off（关闭）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Signal Input（信号输入）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>AC（交流）</td><td style='text-align: center; word-wrap: break-word;'>Off（关闭）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Scope（示波器）</td><td style='text-align: center; word-wrap: break-word;'>Horizontal（水平）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Sampling Rate（采样率）</td><td style='text-align: center; word-wrap: break-word;'>60 MHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Scope（示波器）</td><td style='text-align: center; word-wrap: break-word;'>Horizontal（水平）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Length（长度）</td><td style='text-align: center; word-wrap: break-word;'>4096 pts</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Scope（示波器）</td><td style='text-align: center; word-wrap: break-word;'>Vertical（垂直）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Channel 1（通道 1）</td><td style='text-align: center; word-wrap: break-word;'>Signal Input 1（信号输入 1）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Scope（示波器）</td><td style='text-align: center; word-wrap: break-word;'>Trigger（触发）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Enable（启用）</td><td style='text-align: center; word-wrap: break-word;'>On（打开）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Scope（示波器）</td><td style='text-align: center; word-wrap: break-word;'>Trigger（触发）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Level（电平）</td><td style='text-align: center; word-wrap: break-word;'>0 V</td></tr></table>

Scope（示波器）工具现在显示 Signal Input +V 的单次触发，时间距离由延迟时间给出。图形顶部和左侧的尺度表示方向的缩放级别。通过图中左侧和下方的图标可以访问主要的缩放属性，并允许将测量数据存储为 SVG 图像文件或纯数据文本文件。此外还可以通过在移动鼠标的同时在图形内单击并按住鼠标左键来实现平移。

#### 注释

可以通过鼠标滚轮实现沿水平维度的放大和缩小。如果要垂直缩放，需要按下 Shift 键并再次使用鼠标滚轮进行调整。另一种快速放大的方法是按住 Shift 键并使用鼠标右键在图形区域内定义一个水平、垂直或类似方框的区域。

将 Input Range（输入范围）设置为 1 V 可确保不会发生信号削波。如果将 Input Range（输入范围）设置为 0.1 V，则可以立即在示波器窗口上看到削波，同时 LabOne 用户界面底部的状态栏上也会出现红色 OVI 错误标志。同时，仪器前面板上 Signal Input +V BNC 连接器旁边的 LED 灯将变成红色。

Scope（示波器）是一个非常方便的工具，可以快速检查输入信号的质量并调整合适的输入范围设置。有关 Scope（示波器）工具的完整说明，请参阅第 4.7 节。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//4e023533-ab86-4daa-b58b-a474fa59212b/markdown_0/imgs/img_in_chart_box_216_462_1072_912.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A22Z%2F-1%2F%2F365fde5c5f269d417400fd29f1e8c3a639425481a943a026f3f7d84698f99a1a" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.2. LabOne 示波器显示了 MFLI 生成的原始信号</div> </div>


#### 3.1.5. 测量测试输入信号

现在我们准备用 MFLI 来解调输入信号并测量其幅值和相位。我们将用到 LabOne 用户界面的两个工具：Numeric（数值）和 Plotter（绘图仪）选项卡。

首先，在解调器 1 的图形 Lock-in（锁相）选项卡上调整下表中列出的参数。

<div style="text-align: center;"><div style="text-align: center;">表 3.3. 测量测试输入信号的设置</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Signal Input（信号输入）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Signal Input 1（信号输入 1）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Low-Pass Filter（低通滤波器）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Sinc</td><td style='text-align: center; word-wrap: break-word;'>Off（关闭）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Low-Pass Filter（低通滤波器）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Order（阶数）</td><td style='text-align: center; word-wrap: break-word;'>3 (18 dB/Oct)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Low-Pass Filter（低通滤波器）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>BW 3 dB</td><td style='text-align: center; word-wrap: break-word;'>10.6 Hz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>PC Data Transfer（PC 数据传输）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>En</td><td style='text-align: center; word-wrap: break-word;'>On（打开）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>PC Data Transfer（PC 数据传输）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Rate（速率）</td><td style='text-align: center; word-wrap: break-word;'>100 Sa/s（自动调整为104.6 Sa/s）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>PC Data Transfer（PC 数据传输）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Trigger（触发）</td><td style='text-align: center; word-wrap: break-word;'>Continuous（连续）</td></tr></table>

上述设置将解调滤波器配置为具有 10.6 Hz 3 dB 滤波器带宽 (BW 3dB) 的三阶低通操作。此外还可以显示和输入相应的噪声等效带宽 (BW NEP) 或积分时间常数 (TC)。解调器滤波器的输出以 104.6 Hz 的速率读出，这意味着每秒有 104.6 个数据样本以等距间隔发送至内部 MFLI 计算机。这些样本可以在我们现在要检查的 Numeric（数值）和 Plotter（绘图仪）工具中查看。

#### 注释

1. 该速率应比 Low-Pass Filter（低通滤波器）部分中选择的滤波器带宽高出 7 到 10 倍。在 Rate（速率）字段中输入数字时，新速率会自动设置为最接近的可用值 - 在本例中为 104.6  Sa/s。

2. 如果在 Plotter（绘图仪）、Numeric（数值）、Spectrum（频谱）、DAQ 或 Sweeper（参数扫描仪）选项卡中没有看到任何信号，首先要检查是否启用了相应的数据流。

Numeric（数值）工具可容纳 16 个或更多测量面板。每个面板都可以选择以笛卡尔坐标（X,Y）或极坐标（R,THETA）显示样本，以及其他物理量，例如振荡器频率和辅助输入。（X,Y,R）值的单位默认为 V<sub>RMS</sub>。可以在 Lock-in（锁相）选项卡的 Signal Input（信号输入）部分更改缩放比例和显示单位。图形尺度条指示器便于用户查看数值，例如用于对齐程序的指示器。有些用户可能会发现数字在快速变化。这是因为您正在测量的热噪声可能在 μV 甚至 nV 范围内，这取决于滤波器设置。这可以让您初步了解 MFLI 仪器提供的测量精度水平。如果您想修改设置，现在可以更改生成信号的幅值，并观察解调器输出受到的影响。

接下来，我们来了解下 Plotter（绘图仪）工具。用户借助该工具可以观察作为时间函数的解调器信号。可以在两个方向上调整图形的缩放比例，或者在每个方向上使用 2 个光标进行具体测量。您可以在 Math（数学）子选项卡中找到各种方便的工具进行即时分析，准确测量噪声幅值、峰值位置和高度、信号背景等等。图 3.3 显示了信号以及其他图形元素，在使用 Math（数学）子选项卡中的直方图功能时，这些元素会动态添加到绘图中。

相同单位的信号会自动添加到同一个默认 y 轴组中。这样可确保轴缩放一致。信号可以在组之间移动。有关 y 轴组的更多信息，请参见绘图功能。尝试使用鼠标滚轮或绘图下方的图标，沿时间维度放大以显示大约一秒钟的数据流。放大时，显示数据的模式将从最小-最大包络图变为线性点插值。LabOne Web 服务器根据水平轴上的点密度与屏幕上显示的像素数做出选择。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//4e023533-ab86-4daa-b58b-a474fa59212b/markdown_1/imgs/img_in_chart_box_215_928_1068_1276.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A23Z%2F-1%2F%2F53392210459ab540ff2a478ca3866d04529d47a6322a88d2c0dd47f7357a2586" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.3. LabOne 用户界面绘图仪在一段时间内连续显示解调器结果（滚动模式）</div> </div>


Plotter（绘图仪）中显示的数据也可以连续保存到仪器存储器中，并轻松传输给主机。有关数据保存和记录功能的详细说明，请查看第 4.2 节。可以使用 Config（配置）选项卡（Settings（设置）部分）保存和加载仪器及用户界面设置。

##### 注释

MFLI 能够通过将振荡器频率设置为 0 Hz 来测量直流信号。在本例中，解调器 R 信号与输入上的实际直流电压相差  $ \sqrt{2} $ 倍，需要考虑到这一点。可以通过在 Lock-in（锁相）选项卡的 Signal Inputs（信号输入）部分输入比例因子 0.7071 来系统地校正。

#### 3.1.6. 不同的滤波器设置

在本教程接下来的介绍中，您将学习如何更改滤波器设置并查看它们对测量结果的影响。在这次练习中，我们将 3 dB 带宽更改为 1 kHz。

<div style="text-align: center;"><div style="text-align: center;">表 3.4. 设置：更改滤波器参数</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Low-Pass Filter（低通滤波器）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Order（阶数）</td><td style='text-align: center; word-wrap: break-word;'>3 (18 dB/Oct)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Low-Pass Filter（低通滤波器）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>BW 3dB</td><td style='text-align: center; word-wrap: break-word;'>1 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>PC Data Transfer（PC 数据传输）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Rate（速率）</td><td style='text-align: center; word-wrap: break-word;'>6.7 kSa/s</td></tr></table>

增加滤波器带宽会减少解调器的积分时间。这将提高有效的时间分辨率，但反过来会使信号噪声更大，在 Plotter（绘图仪）选项卡中可以清楚地观察到这一点。请注意，我们建议将采样率保持为滤波器 3 dB 带宽的 7 到 10 倍。采样率将四舍五入到下一个有效的采样频率。比方说，在 Rate（速率）字段中输入 7 k 将显示为 6.7 kSa/s，这不仅有利于正确解析信号，还可以避免混叠效应。

此外，您可以更改通过测试信号幅值来“干扰”解调器，例如从 0.5 V 更改为 0.7 V，再从 0.7 V 调整为 0.5 V。绘图将超出显示范围，可通过点击“Rescale”（重新缩放）按钮重新调整显示范围。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//4e023533-ab86-4daa-b58b-a474fa59212b/markdown_2/imgs/img_in_chart_box_213_843_1068_1194.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A24Z%2F-1%2F%2F0d2de2b83a829f4c8ca0137d549825f6b0dd2faae8d0fa9256290241d2ef0ad6" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.4. LabOne 用户界面绘图仪显示解调器结果，同时将滤波器带宽从 10 Hz 更改为 1 kHz</div> </div>


### 3.2. 外部参考

##### 注释

本教程适用于所有 MFLI 仪器。无需特定选件。根据是否安装了 MF-MD 多解调器选件，用户界面略有不同。本教程针对这两种情况分别做了说明。

#### 3.2.1. 目标和要求

本教程介绍了如何将内部振荡器锁定到外部参考频率，然后按该频率的谐波来解调测量信号。要遵循本教程，您需要一个光学斩波器以及一对标准的光学检测器/发射器。但是，本教程适用于任何具有可比性的设置，在这些设置中可以使用单独的参考通道和信号通道。参考通道应具有足够大的幅值（例如 TTL 电平）以实现可靠锁定。

#### 3.2.2. 准备

连接电缆，如图 3.5 所示。确保 MFLI 已通电，然后通过 USB 将 MFLI 连接到 PC 或主机所在的局域网 (LAN)。使用 Web 浏览器地址并通过 Web 浏览器连接到仪器后，LabOne 图形用户界面打开。有关详细说明，请查看第 1 章。本教程可以使用默认仪器配置（例如，重启后）和默认用户界面设置（即在浏览器中按 F5 键后）启动。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//4e023533-ab86-4daa-b58b-a474fa59212b/markdown_3/imgs/img_in_image_box_219_738_1027_1113.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A25Z%2F-1%2F%2F0e65a2c481dd5d67b2c941a6ae632bf856b3e3cbcac941dabde003b6259353ec" alt="Image" width="67%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.5. 使用光学斩波器、LED 灯和光电二极管进行外部参考测量的设置。</div> </div>


#### 3.2.3. 激活外部参考模式

参考信号从光学斩波器的 Sync Output 连接到 MFLI 的 Aux Input 1/Ref。在本例中，参考信号是一个在 0 V 和 5 V 之间切换的方波信号。我们在斩波器上选择 80 Hz 的基频。您可以通过进入 Scope（示波器）选项卡并选择 Aux In 1 Ch 1（辅助输入 1 通道 1）作为输入信号来轻松检查信号。

根据安装的选件，特别是是否安装了 MF-MD 多解调器选件，将内部振荡器锁定到外部信号的操作略有不同。因此，我们对这两种情况需要执行的步骤进行了分别说明。

未安装 MF-MD 多解调器选件：打开图形 Lock-in（锁相）选项卡。在该选项卡底行的 Internal/External Reference（内部/外部参考）部分，该部分的标签实际上是一个控件，可以在 Internal Reference（内部参考）（默认）和 External Reference（外部参考）之间切换。将其设置为 External Reference（外部参考）。在该控件的右侧，您现在可以选择输入信号。选择 Aux In 1（辅助输入 1）作为输入信号。这些设置也显示在图 3.6 中。参考部分中心处显示的频率值应快速

转换为斩波器的 80 Hz。下表显示了在未安装 MF-MD 多解调器选件的情况下，用于锁定到外部参考的 Lock-in（锁相）设置。

<div style="text-align: center;"><div style="text-align: center;">表 3.5. 设置：设置外部参考模式（未安装 MF-MD 选件）</div> </div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//4e023533-ab86-4daa-b58b-a474fa59212b/markdown_4/imgs/img_in_image_box_215_264_1085_679.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A26Z%2F-1%2F%2Fbfaf055b687d4b3fbda973c346afbd6b64ca016770356b932aefac63683e8a28" alt="Image" width="73%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.6. 具有外部参考设置的 Lock-in（锁相）选项卡（未安装 MF-MD 选件）</div> </div>


已安装 MF-MD 多解调器选件：打开第二个解调器的图形 Lock-in（锁相）选项卡。我们使用该解调器在内部振荡器 1 和外部信号之间建立锁相环（PLL）。在 Lock-in（锁相）选项卡左下方的 Reference（参考）部分，在 Mode（模式）字段中选择 ExtRef（外部参考）和振荡器编号 1。在左上方的 Signal Input（信号输入）部分，选择 Aux In 1（辅助输入 1）作为输入信号。这些设置也显示在图 3.7 中。Reference（参考）部分中显示的振荡器 1 的频率应迅速转换为斩波器的 80 Hz。有关在安装 MF-MD 多解调器选件的情况下启用锁定到外部参考的 Lock-in（锁相）设置，如表 3.6 所示。

<div style="text-align: center;"><div style="text-align: center;">表 3.6. 设置：设置外部参考模式（已安装 MF-MD 选件）</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Reference（参考）</td><td style='text-align: center; word-wrap: break-word;'>2</td><td style='text-align: center; word-wrap: break-word;'>Mode（模式）</td><td style='text-align: center; word-wrap: break-word;'>ExtRef（外部参考）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Reference（参考）</td><td style='text-align: center; word-wrap: break-word;'>2</td><td style='text-align: center; word-wrap: break-word;'>Osc（振荡器）</td><td style='text-align: center; word-wrap: break-word;'>1</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Signal Input（信号输入）</td><td style='text-align: center; word-wrap: break-word;'>2</td><td style='text-align: center; word-wrap: break-word;'>Signal（信号）</td><td style='text-align: center; word-wrap: break-word;'>Aux In 1（辅助输入 1）</td></tr></table>

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//4e023533-ab86-4daa-b58b-a474fa59212b/markdown_4/imgs/img_in_image_box_216_1166_1082_1345.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A26Z%2F-1%2F%2F6381012ac20cb74ef6b05e13961eefc1054654a162a8346055d3dc0d30022654" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.7. 具有外部参考设置的 Lock-in（锁相）选项卡（已安装 MF-MD 选件）</div> </div>


有一点要注意，外部参考信号从不直接用于解调。相反，外部参考信号的频率和相位通过内部锁相环映射到其中的一个内部振荡器。因此，该内部振荡器可以用作任何解调器的参考。

这一映射程序通过自动带宽调整来完成，调整后可快速锁定整个仪器带宽。因此从频率稳定性和信噪比等方面确保了信号质量。在自动调整过程中，相关解调器 2 或 4 的低通滤波器带宽通常会下降，直至几秒钟后达到最终值。指示的带宽也代表着锁相环带宽的上限，锁相环将外部信号映射到内部振荡器。图 3.8 显示了 Plotter（绘图仪）打开后立即进行频率跟踪的典型结果。对于这类测量，打

开 Plotter（绘图仪）选项卡并将相应的信号添加到绘图上（Control（控制）子选项卡、Vertical Axis Groups（垂直轴组）、Frequency（频率）、Channel 1（通道 1）、Add Signal（添加信号））。

##### 注释

安装 MF-MD 多解调器选件后，您还可以查看相位误差（Control（控制）子选项卡、Vertical Axis Groups（垂直轴组）、Demod Theta（解调器 Theta）、Channel 2（通道 2）、Add Signal（添加信号））。请务必在相应 Lock-in（锁相）选项卡的 PC Data Transfer（PC 数据传输）部分启用相应的数据流。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//57f38cc8-614a-4e6a-8765-ca1ce19bff16/markdown_0/imgs/img_in_chart_box_215_399_1078_647.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A47Z%2F-1%2F%2F081071024236af97be8a396e05706ff4d5ac5febdffe343d15d362c087ec5a84" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.8. 一段时间内的内部振荡器频率与自动带宽逐步调整</div> </div>


#### 3.2.4. 在参考频率的谐波处进行测量

在光学演示测量中，我们使用一对 Vishay TCRT5000 红外检测器/发射器，其光束会通过光学斩波器。检测器是一个光电二极管，发射器是一个 LED 灯，两者都由 Auxiliary Output 2（辅助输出 2）通过一个简单的电路直接偏置，如图 3.5 所示。我们通过在 500 Ω 电阻器上施加 5 V 电压对 LED 施加 10 mA 电流偏置。与光电二极管串联的 1 kΩ 电阻器只是一个限制器。请注意，设计电路不能超过 MFLI 的损坏阈值（50 Ω I 输入上为 5 V）。

光电二极管产生的电流包含通常由环境光造成的偏移影响和由斩波器造成的调制影响。在本例中，两者都在某个  $ \mu A $ 的范围内，我们可以使用  $ 100 \mu A $ 而非  $ 10 mA $ 的更高输入灵敏度，从而改善输入噪声。本实验所用的斩波轮的倍频为 10，因此光信号的实际调制频率为 800 Hz。这远大于 50/60 Hz 标称频率，无需使用高转速的斩波器。

我们将使用谐波功能，从 80 Hz 外部参考在内部生成 800 Hz 解调参考。根据所装选件的不同，再次进行设置会略有差异，因此我们针对安装和未安装 MF-MD 多解调器选件的不同情况对需要执行的步骤进行了说明。

未安装 MF-MD 多解调器选件：在图形 Lock-in（锁相）选项卡的 Signal Input（信号输入）部分，选择 Current Input 1（电流输入 1）并将输入范围更改为 100 μA。在 External Reference（外部参考）部分，将 Harm（谐波）设置为 10/1。请注意，默认情况下此设置是隐藏的。您可以通过单击该部分右上角的“+”符号展开该部分来访问这一设置。您现在应该观察到解调器参考频率接近 800 Hz 的数字显示，如图 3.9 所示。最后，将 Low-Pass Filter（低通滤波器）设置为 100 Hz（三阶）并在 PC Data Transfer（PC 数据传输）部分启用数据流。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//57f38cc8-614a-4e6a-8765-ca1ce19bff16/markdown_1/imgs/img_in_image_box_215_114_1075_373.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A48Z%2F-1%2F%2F267441ab73de3e7acdb440685fdaea86f276077e4caad7c413249bb9f83fe48e" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.9. 在 800 Hz 下进行测量的 Lock-in（锁相）选项卡设置（未安装 MF-MD 选件）</div> </div>


<div style="text-align: center;"><div style="text-align: center;">表 3.7. 设置：在外部参考频率的谐波处进行锁相检测（未安装 MF-MD 选件）</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>External Reference（外部参考）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Harm（谐波）</td><td style='text-align: center; word-wrap: break-word;'>10 / 1</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Signal Input（信号输入）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Signal（信号）</td><td style='text-align: center; word-wrap: break-word;'>Current Input 1（电流输入 1）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Signal Input（信号输入）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Range（范围）</td><td style='text-align: center; word-wrap: break-word;'>100  $ \mu $A</td></tr></table>

*安装 MF-MD 多解调器选件：*打开第一个解调器的图形 Lock-in（锁相）选项卡。我们使用这个解调器来执行锁相检测。在图形 Lock-in（锁相）选项卡的 Signal Input（信号输入）部分，选择 Current Input 1（电流输入 1）并将输入范围更改为 100 μA。在 Reference（参考）部分，选择 Oscillator 1（振荡器 1）并将 Harm（谐波）设置为 10，请参见图 3.10。在图形 Lock-in（锁相）选项卡的电路图中，您应该能看到解调频率的数值为 800 Hz。将 Low-Pass Filter（低通滤波器）设置为 100 Hz（三阶）并在 PC Data Transfer（PC 数据传输）部分启用数据流。

<div style="text-align: center;"><div style="text-align: center;">表 3.8. 设置：在外部参考频率的谐波处进行锁相检测（已安装 MF-MD 选件）</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Reference（参考）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Harm（谐波）</td><td style='text-align: center; word-wrap: break-word;'>10</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Signal Input（信号输入）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Signal（信号）</td><td style='text-align: center; word-wrap: break-word;'>Current Input 1（电流输入 1）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Signal Input（信号输入）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Range（范围）</td><td style='text-align: center; word-wrap: break-word;'>100  $ \mu A $</td></tr></table>

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//57f38cc8-614a-4e6a-8765-ca1ce19bff16/markdown_1/imgs/img_in_image_box_218_1160_1074_1371.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A48Z%2F-1%2F%2F8e221f97dc403cdc5023c7e1c4735a9e332d338d2942418896fe09bd2cb751ab" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.10. 在 800 Hz 下进行测量的 Lock-in（锁相）选项卡设置（已安装 MF-MD 选件）</div> </div>


##### 注释

滤波器带宽应远低于调制频率 OMEGA，以抑制 2 OMEGA 信号分量（请参见 Sinc 滤波）。在这里，我们在 800 Hz 的调制频率 OMEGA 下使用 100 Hz 的滤波器带宽。

#### 3.2.5. 绘制测量结果

在 800 Hz 频率下设置解调后，我们准备查看测量数据。打开 Plotter（绘图仪）选项卡。在 Control（控制）子选项卡中，选择 Presets（预设）列表中的 Enabled Demods R（已启用解调器 R）设置。图 3.11 显示了光电二极管电流图，其中发射器和检测器之间的光路被手动交叉多次以显示测量反差。当光路打开时（斩波轮除外），我们测量出恒定均方根电流约为 15.5 μA，每当我们阻挡光路时，电流就降至零。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//57f38cc8-614a-4e6a-8765-ca1ce19bff16/markdown_2/imgs/img_in_chart_box_213_354_1077_602.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A49Z%2F-1%2F%2Fe786bca21ed3b88805654ab7d49ab8bebf69e0027454c609e994a5c6c314b1cf" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.11. 使用 LabOne Plotter（绘图仪）连续绘制光电二极管信号</div> </div>


### 3.3. Sweeper（参数扫描仪）

##### 注释

本教程适用于所有安装了 MF-MD 多解调器选件的 MFLI 仪器。同时检测电压和电流的 4 端子测量需要 MD 选件。

#### 3.3.1. 目标和要求

本教程介绍了如何使用 LabOne Sweeper（参数扫描仪）对 MOSFET（金属氧化物半导体场效应晶体管）进行测量。本教程的目标是使用 LabOne 工具箱并将 MOSFET 用作演示系统，演示锁相测量操作流程的典型步骤。要学习本教程，您需要一个规格与 IRLML2502 相似的 MOSFET。然而，许多操作步骤具有通用性，适用于多种输运测量场景。

本教程的目的不是提供有关 MOSFET 表征的说明。因为这是一项复杂的测量工作，超出了本教程的范围。

#### 3.3.2. 准备

我们在 International Rectifier 制造的 IRLML2502 功率 MOSFET 上进行这些测量，但许多其他 MOSFET 也能通过对参数进行某些调整来进行类似的测量。连接电缆，如图 3.12 所示。确保 MFLI 仪器已通电，然后通过 USB 将 MFLI 连接到 PC 或通过以太网电缆连接到主机所在的局域网 (LAN)。使用 Web 浏览器地址并通过 Web 浏览器连接到仪器后，LabOne 图形用户界面在浏览器中打开。有关详细说明，请查看第 1 章。本教程可以使用默认仪器配置（例如，重启后）和默认用户界面设置（即在浏览器中按 F5 键后）启动。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//57f38cc8-614a-4e6a-8765-ca1ce19bff16/markdown_3/imgs/img_in_image_box_224_819_663_1083.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A49Z%2F-1%2F%2F766ed8770cef3a2bcd4723b86615684fa2025e7f685121bb45e638210a79e883" alt="Image" width="36%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.12. 针对 MOSFET 测量的设置。</div> </div>


#### 3.3.3. 调整栅源电压

我们首先配置 Lock-in（锁相）选项卡以检测 MOSFET 的源极电流。打开第一个解调器的 Lock-in（锁相）选项卡。在 Reference（参考）部分选择振荡器 1 并将频率设置为 1 kHz。在 Signal Input（信号输入）部分，选择 Current Input 1（电流输入 1）作为信号并将范围设置为 10 mA。在 Low-Pass Filter（低通滤波器）部分，将滤波器 3 dB 带宽设置为 10 Hz。

我们将使用负漏源偏移电压操作 MOSFET。请注意，我们施加的是一个小的交流漏源电压。对于 MOSFET 来说，这种操作并不常见。但这样可以在一个对交流漏源电压进行线性响应的配置中操作该设备，同时在 MFLI Signal Input I 的范围内有偏移电流。

在 Output Amplitudes（输出幅值）部分，将 Amplitude 1（幅值 1）设置为 10 mVrms 并启用该输出。在 Signal Output（信号输出）部分，将 Offset（偏移）设置为 -100 mV 并打开该输出。最后，在 PC Data Transfer（PC 数据传输）部分启用解调器 1 的数据传输。下表总结了要完成的设置。

<div style="text-align: center;"><div style="text-align: center;">表 3.9. 设置：MOSFET 源极电流测量</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Reference（参考）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Osc（振荡器）</td><td style='text-align: center; word-wrap: break-word;'>1</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Reference（参考）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Freq（频率）</td><td style='text-align: center; word-wrap: break-word;'>1 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Signal Input（信号输入）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Signal Input（信号输入）</td><td style='text-align: center; word-wrap: break-word;'>Curr In 1（电流输入 1）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Signal Input（信号输入）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Range（范围）</td><td style='text-align: center; word-wrap: break-word;'>10 mA</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Low-Pass Filter（低通滤波器）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>BW 3dB</td><td style='text-align: center; word-wrap: break-word;'>100 Hz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Output Amplitudes（输出幅值）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Amp 1（放大器 1）（Vrms）</td><td style='text-align: center; word-wrap: break-word;'>100 mVrms</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Output Amplitudes（输出幅值）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>En</td><td style='text-align: center; word-wrap: break-word;'>On（打开）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Signal Output（信号输出）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Offset（偏移）</td><td style='text-align: center; word-wrap: break-word;'>-100 mV</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Signal Output（信号输出）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>On（打开）</td><td style='text-align: center; word-wrap: break-word;'>On（打开）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>PC Data Transfer（PC 数据传输）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>En</td><td style='text-align: center; word-wrap: break-word;'>On（打开）</td></tr></table>

MOSFET 栅极连接到 Auxiliary Output 1。使用 Aux（辅助）选项卡，我们可以配置此输出以生成恒定电压。在 Aux Output（辅助输出）部分，将第一个 Auxiliary Output（辅助输出）的 Signal（信号）设置为 Manual（手动）。现在可以使用 Offset（偏移）字段输出任意电压。如果您一边观察 Plotter（绘图仪）或 Numeric（数值）选项卡中的 MOSFET 电流，一边调整该值，您就可以了解 MOSFET 作为可调电阻器的行为。我们的模型是一个 n 通道设备，因此负栅源电压会抑制电流，而几伏的正电压会打开 MOSFET 通道。下表总结了要完成的设置。

我们先简短讨论下串联电阻在测量设置中的作用。快速浏览图 3.12，记住 Signal Input I 代表虚拟接地。我们可以得出结论，Signal Output +V 上的电压等于 MOSFET 的漏源电压，Auxiliary Output 1 上的电压等于栅源电压。但实际上这并不准确，因为 Signal Output +V、Signal Input I 和 Auxiliary Output 有 50 Ω 的内部串联阻抗。一旦三个连接器中的任何一个上出现大量电流，相应 MOSFET 触点的实际电位就会改变。对于本质上就是电隔离的栅极触点，这种校正可以忽略不计，但对于源极和漏极触点来说可能很重要。

在本教程的第一部分，我们将重点关注 MOSFET 通道部分关闭的区域。在这种高阻抗配置中，我们可以假设电流和校正都很小。在本教程的第二部分，我们将主要讨论 MOSFET 通道打开的区域。在这种低阻抗配置中，我们改为使用 4 端子测量来适当考虑校正。

#### 3.3.4. 扫描栅源电压

我们现在来设置 MOSFET 栅极电压的扫描。打开 Sweeper（参数扫描仪）选项卡，然后在 Control（控制）子选项卡中，选择 Aux Out 1 Offset（辅助输出 1 偏移）作为 Sweep Parameter（扫描参数）。将 Start（起始）和 Stop（结束）的值分别设为 0 V 和 1 V，并将 Length（长度）设置为 100 点。取消选中 Log（日志）复选框，以便测量点在 0 V 和 1 V 之间的间隔内线性分布。

在 Sweeper（参数扫描仪）测量中，必须注意选择与测量带宽兼容的扫描速度。如果每个点的时间太短，可能会由于测量值不够稳定而出现系统性误差。通常您可以让 LabOne Sweeper（参数扫描仪）来处理这个问题。在 Settings（设置）子选项卡的 Filter（滤波器）字段中选择 Application Mode（应用模式）。然后，Sweeper（参数扫描仪）会选择有用的扫描参数并针对各种预定义的应用实例调整解调器滤波器设置。我们在 Application（应用）字段中选择通用的“Parameter Sweep Averaged”（参数扫描求平均）实例。请参见第 4.10 节了解更多信息。

##### 注释

可能测量带宽是受被测设备而非解调器滤波器的限制。从 Sweeper（参数扫描仪）上无法找到原因，因为它只知道解调器滤波器带宽，而不知道设备的属性。如果您不确定扫描速度是否太快，请在Control（控制）子选项卡中将 Sweep Mode（扫描模式）设置为 Bidirectional（双向），然后检查测量滞后。如果需要自定义扫描设置，您可以在 Settings（设置）子选项卡的 Advanced Mode（高级模式）中访问这些设置。

<div style="text-align: center;"><div style="text-align: center;">表 3.10. 设置：MOSFET 栅极电压扫描</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Sweep Param（扫描参数）</td><td style='text-align: center; word-wrap: break-word;'>Aux Out 1 Offset（辅助输出 1 偏移）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Start（起始）</td><td style='text-align: center; word-wrap: break-word;'>0 V</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Stop（结束）</td><td style='text-align: center; word-wrap: break-word;'>1 V</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Length（长度）</td><td style='text-align: center; word-wrap: break-word;'>100 点</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Log（日志）</td><td style='text-align: center; word-wrap: break-word;'>Off（关闭）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Settings（设置）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Filter（滤波器）</td><td style='text-align: center; word-wrap: break-word;'>Application Mode（应用模式）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Settings（设置）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Application（应用）</td><td style='text-align: center; word-wrap: break-word;'>Parameter Sweep Averaged（参数扫描求平均）</td></tr></table>

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//0479a301-6b97-4470-ab98-aeee49634923/markdown_0/imgs/img_in_chart_box_215_783_1070_1233.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A16Z%2F-1%2F%2F23803d9145314fb1186eb6e19080cea511a2ed8a37eabffd366e037124a0f7a5" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.13. 使用 LabOne Sweeper（参数扫描仪）测量的 MOSFET 源极电流的栅极电压相关性</div> </div>


图 3.13 显示了栅极电压扫描的结果。对于低于约 0.5 V 的栅极电压，我们观察到漏极电流的指数抑制。对于更高的电压，电流最终会在达到约 0.1 mA 时饱和。该值由 10 mV 的 Signal Output +V 幅值和 MFLI 输入与输出阻抗的累积 100 Ω 串联电阻（即 50 Ω 的两倍）决定。请注意在这张绘图中，信号幅值下降到大约 10 nA，相对于 10 mA 的输入范围，大约是 -120 dB 的电平！这让您对 MFLI 仪器的可访问动态范围有一个了解。

#### 3.3.5.4 端子电阻测量

在本教程前面介绍的测量中，我们有效采用了 2 端子测量方法。只要被测设备是大陆抗，例如通道部分关闭的 MOSFET，这种方法就足够了，而且操作简单。相反，若是小阻抗设备，布线以及 Signal Output 与 Signal Input 串联阻抗可能会受到比较大的影响。在这种情况下采用 4 端子方法会更合适。

在本例中，我们可能会关注 On（导通）状态下的 MOSFET 属性，在这个状态下，其通道电阻远低于 1 Ω。为了测量这个导通电阻，我们会跟之前的操作一样，继续测量交流电流。我们使用 MFLI 的差分 Signal Input 添加了对 MOSFET 通道上交流压降的测量。

我们配置第二个解调器来执行此电压测量任务。打开第二个解调器的 Lock-in（锁相）选项卡。在 Reference（参考）部分，选择 Oscillator 1（振荡器 1）。在 Signal Input（信号输入）部分，选择 Signal Input 1（信号输入 1）并通过选中标记为 Diff（差分）的复选框来启用差分测量。将范围设置为 1 mV，并在 PC Data Transfer（PC 数据传输）部分启用解调器 1 的数据传输。下表总结了要完成的设置。

<div style="text-align: center;"><div style="text-align: center;">表 3.11. 设置：MOSFET 栅极电压扫描</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Signal Input（信号输入）</td><td style='text-align: center; word-wrap: break-word;'>2</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Sig In 1（信号输入 1）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Signal Input（信号输入）</td><td style='text-align: center; word-wrap: break-word;'>2</td><td style='text-align: center; word-wrap: break-word;'>Diff（差分）</td><td style='text-align: center; word-wrap: break-word;'>ON（打开）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Signal Input（信号输入）</td><td style='text-align: center; word-wrap: break-word;'>2</td><td style='text-align: center; word-wrap: break-word;'>Range（范围）</td><td style='text-align: center; word-wrap: break-word;'>1 mV</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>Reference（参考）</td><td style='text-align: center; word-wrap: break-word;'>2</td><td style='text-align: center; word-wrap: break-word;'>Osc（振荡器）</td><td style='text-align: center; word-wrap: break-word;'>1</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>PC Data Transfer（PC 数据传输）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>En</td><td style='text-align: center; word-wrap: break-word;'>ON（打开）</td></tr></table>

为了获得明确的 4 端子测量结果，MOSFET 源极和漏极上的电压探针应尽可能靠近被测设备。最好是直接在 MOSFET 触点上使用点探针，以消除焊点电阻的影响。

在 4 V 栅极电压 (Aux Output 1) 和 100 mVrms (Signal Output 1) 激励电压下，我们可以在 Numeric（数值）选项卡上查看测量数据。我们测量了 1.00 mA 的源极电流和 0.027 mV 的源漏电压。根据设备规格，这相当于 27 mΩ 的导通电阻。图 3.14 和图 3.15 显示了 MOSFET 在更大栅极电压范围内的源极电流和 2 端子漏源电压。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//0479a301-6b97-4470-ab98-aeee49634923/markdown_1/imgs/img_in_chart_box_216_995_1080_1358.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A17Z%2F-1%2F%2F3219ec2380627fbe8922c271e9bf7ddeebf3a3e2089843a731b47fdaa6246868" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.14. 在 4 端子设置中使用 LabOne Sweeper（参数扫描仪）测量的 MOSFET 源极电流的栅极电压相关性</div> </div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//0479a301-6b97-4470-ab98-aeee49634923/markdown_2/imgs/img_in_chart_box_204_107_1067_475.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A18Z%2F-1%2F%2F1b2db59237b139509c6e0f5307e8a5a16c003dfeeff401e16a1dcb599232c1f4" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.15. 在 4 端子设置中使用 LabOne Sweeper（参数扫描仪）测量的 MOSFET 漏源电压的栅极电压相关性</div> </div>


### 3.4. 基本阻抗测量

##### 注释

本教程适用于所有 MFIA 仪器和安装了 MF-IA 阻抗分析仪选件的 MFLI 仪器。

#### 3.4.1. 目标和要求

本教程适用于不熟悉 Zurich Instruments 阻抗分析仪的人群。通过使用非常基本的测量设置，本教程以分步实践的方式展示了 MFLI 仪器和 LabOne 用户界面的基本工作原理。

本教程需要用到 MFITF 阻抗测试夹具。

#### 3.4.2. 准备

本教程将指导您通过基本步骤，对随附了 MFITF 阻抗测试夹具的 1 kΩ 测试电阻器进行简单测量。首先将 MFITF 连接到 MFLI 前面板上的 BNC 连接器，然后将标有“1k 0.05%”的电阻器插入测试夹具正面的 8 针连接器。图 3.16 显示了硬件设置图。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//0479a301-6b97-4470-ab98-aeee49634923/markdown_3/imgs/img_in_image_box_226_635_1045_923.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A19Z%2F-1%2F%2F625df5718f336e443139ad75d27f1ba17b6214f79006d6293b9adeded2e76e13" alt="Image" width="68%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.16. 阻抗测量教程的设置</div> </div>


确保 MFLI 仪器已通电，然后通过 USB 将 MFLI 直接连接到主机或通过以太网连接到主机所在的局域网 (LAN)。使用 Web 浏览器地址并通过 Web 浏览器连接到仪器后，LabOne 图形用户界面打开。有关详细说明，请查看第 1 章。本教程可以使用默认仪器配置（例如，重启后）和默认用户界面设置（即在浏览器中按 F5 键后）启动。

#### 3.4.3. 配置阻抗分析仪

图 3.17 显示的 Impedance Analyzer（阻抗分析仪）选项卡为您提供了开始测量阻抗所需的设置。通过单击用户界面左侧的相应图标打开该选项卡。要对 1 kΩ 被测设备 (DUT) 进行快速测量，默认设置是合适的。我们要做的就是单击 Impedance Analyzer（阻抗分析仪）选项卡左上角的 Enable（启用）按钮，以打开驱动信号并开始测量。这将覆盖

在 Lock-in（锁相）选项卡中所做的一些设置。由于默认启用自动范围控制，电流和电压输入范围将在几秒钟内进行调整并开始测量。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//0479a301-6b97-4470-ab98-aeee49634923/markdown_4/imgs/img_in_image_box_216_110_1070_286.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A20Z%2F-1%2F%2F6166f80570b0fb2e017ed836fb6a1303cadc79671faa655e7e11997fdb22a4ae" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.17.Impedance Analyzer（阻抗分析仪）选项卡（Application（应用）模式）</div> </div>


测量结果现在显示在该选项卡的 Measurement Results（测量结果）部分。此外，第 4.5 节提供了更具可配置性的数据显示。通过单击屏幕左侧的相应图标打开选项卡。在 Presets（预设）子选项卡中选择 Impedance（阻抗）预设。图 3.18 中显示的 Numeric（数值）选项卡呈现为多个面板，这些面板以笛卡尔坐标和极坐标的形式显示阻抗  $ Z_{DUT} $ 和其他参数。如果您想监控偏置电压等其他物理量，您可以使用右侧的树状选择器添加更多面板。图形尺度条指示器方便用户更清楚地查看每个数值。我们看到阻抗绝对值 Abs(Z) 为 999.8 Z，复相位 Phase(Z) 接近 0 度，与我们插入的 1 kΩ DUT 形成了很好的对应。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//0479a301-6b97-4470-ab98-aeee49634923/markdown_4/imgs/img_in_image_box_215_585_1064_919.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A20Z%2F-1%2F%2F3cc283d76a48b87beef087ba0262e869c5ddea43ee1b46c763decb60bd275fe2" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.18. Numerical（数值）选项卡显示测量的阻抗和电路表示参数</div> </div>


#### 3.4.4. 测量频率相关性

频率是一个关键的测量参数。可以通过单击 Osc Frequency（振荡器频率）字段手动更改频率，键入一个值，例如 1000 或 1k，在键盘上轻敲 <TAB> 或 <ENTER> 键，然后应用该设置。为了更系统地测量频率相关性，我们将用到之前在第 3.3 节中介绍的 Sweeper（参数扫描仪）工具。

通过单击用户界面左侧的相应图标打开 Sweeper（参数扫描仪）选项卡。在 Sweeper（参数扫描仪）的 Settings（设置）子选项卡中选择 Application Mode（应用模式），并选择 Impedance（阻抗）作为 Application（应用）。选择“IA Abs(Z)”作为 Signal Type（信号类型），单击“Add Signal”（添加信号），将阻抗的测量绝对值添加到绘图中。在 Control（控制）子选项卡中，您可以配置扫描参数、扫描范围和分辨率。将起始和结束频率设置为 1 kHz 和 1 MHz。默认情况下，Sweeper（参数扫描仪）设置将此范围划分为对数网格上的 100 个点。这两个设置以及 Sweep Parameter（扫描参数）都是可配置的。下表总结了我们使用的 Sweeper（参数扫描仪）设置。

<div style="text-align: center;"><div style="text-align: center;">表 3.12. 设置：配置 Sweeper（参数扫描仪）进行频率相关性测量</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>子选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Settings（设置）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Filter（滤波器）</td><td style='text-align: center; word-wrap: break-word;'>Application Mode（应用模式）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Settings（设置）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Application（应用）</td><td style='text-align: center; word-wrap: break-word;'>Impedance（阻抗）</td></tr></table>



<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'>Horizontal（水平）</td><td style='text-align: center; word-wrap: break-word;'>Sweep Param（扫描参数）</td><td style='text-align: center; word-wrap: break-word;'>Osc 1 Frequency（振荡器 1 频率）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'>Horizontal（水平）</td><td style='text-align: center; word-wrap: break-word;'>Start / Stop（起始/结束）</td><td style='text-align: center; word-wrap: break-word;'>1k / 1M</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'>Horizontal（水平）</td><td style='text-align: center; word-wrap: break-word;'>Length（长度）</td><td style='text-align: center; word-wrap: break-word;'>100 点</td></tr></table>

单击 Single 开始频率扫描。图 3.19 中的屏幕截图显示了 Sweeper（参数扫描仪）选项卡绘图部分的测量。从截图上可以看到，1 kΩ 的阻抗 Abs(Z) 实部在 0.05% 误差范围内，呈现完美平坦曲线，如垂直轴的光标所示。虽然我们的 1 kΩ DUT 在 1 Hz 和 1 MHz 之间没有显著的频率相关性，但因寄生电容或电感的存在，非常大或非常小的电阻器通常会在高频处显示 Abs(Z) 的变化。

绘图部分具有多迹线和双绘图功能，用于表示不同单位（例如欧姆( $ \Omega $)和法拉(F))或不同数量的多条曲线。LabOne的绘图功能在绘图功能中有更详细的描述。这一部分还介绍了光标和数学函数，以便对测量数据进行快速定量分析。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f22da2fe-f5f7-4c4c-a175-8f6b1419faa5/markdown_0/imgs/img_in_chart_box_216_492_1067_869.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A17Z%2F-1%2F%2Feb75c8a19fb345511234228ea60dbe3bc39967322c9b2efd5f19d3ac2a8342d9" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.19.LabOne Sweeper（参数扫描仪）显示 1 kΩ DUT 的频率相关性</div> </div>


#### 3.4.5. 电路表示和测量模式

在继续测量之前，每位用户都应了解两个设置：Equivalent Circuit Mode（等效电路模式）和 DUT Representation（DUT 表示）。这些设置确定了当前有效的测量配置。Impedance Analyzer（阻抗分析仪）选项卡中动态更新的电路图以图形方式表示该配置。

1. Measurement Mode（测量模式）（2 端子或 4 端子）对应的是 DUT 与仪器连接器连接的方式。这明确了测量 DUT 电压 V 的位置：在 Signal Input - 和 Signal Input +V 上，或在 Signal Output +V 上。电压测量与 Signal Input I 上的电流 I 测量一起构成阻抗 Z=V/I 的测量。对于 1 kΩ DUT，测量模式为 4 端子，因为所有四个连接器 Signal Output +V、Signal Input I、Signal Input +V 和 Signal Input -V 都连接到 DUT。

2. DUT Representation（DUT 表示）表明如何将测得的复值阻抗  $ Z_{DUT} = V/I $ 转换为 DUT 电路参数，例如电阻和电容。对于我们的 1 kΩ 电阻器，并联电阻电容表示  $ R_p \parallel C_p $ 是不可少的，即使并联电容可以忽略不计。

DUT 表示参数（在本例中，Representation Parameter 1（表示参数 1）= Rp，Representation Parameter 2（表示参数 2）= Cp）可显示在用户界面的其他地方，例如在 Numeric（数值）或 Sweeper（参数扫描仪）选项卡中显示。在图 3.18 所示的 Numeric（数值）选项卡中，Model Parameter 1（模型参数 1）（Rp）读数为 999.8 Ω。Model Parameter 2（模型参数 2）（Cp）的面板没有显示数字读数，而是显示消息“Suppression”（抑制）。当其中一个 Model Parameter（模型参数）无法确定时，LabOne 置信度指示器会向您发送这条消息。在本例中，与通过电阻器本身的电

流相比，通过电阻器电极之间的杂散电容的电流太小。“Suppression”（抑制）警告不显示没有意义的计算数值，而是防止出现系统性的测量误差。

除了“Suppression”（抑制）外，还可能出现其他置信度指示器警告。例如，置信度指示器能够检测丢失的连接（例如仅连接到2个端子，却想要在4端子模式下测量DUT时），或者信号下溢和上溢情况。置信度指示器提供的警告消息列表总结了不同警告的含义，请参见功能说明一章。

#### 3.4.6. 时间相关性和滤波

接下来，我们将看看 Plotter（绘图仪）选项卡，它让用户可以观察测量数据随时间变化的函数关系，例如测量分量阻抗的长期稳定性。单击左侧相应的图标，打开 Plotter（绘图仪）选项卡，然后在 Control（控制）子选项卡中选择 Impedance（阻抗）预设，以便将一组有用的物理量添加到绘图中。为方便整体观察，请使用 Vertical Axis Group（垂直轴组）部分中的复选框禁用除电阻（Impedance 1 Representation Parameter 1（阻抗 1 表示参数 1））之外的所有迹线。

Plotter（绘图仪）是观察测量结果中噪声的好工具。低通滤波可以有效地消除噪声。MFLI提供自动带宽控制，通常可以有效降噪，而且不会降低测量速度。尽管如此，手动优化滤波有时也是有好处的，例如在电噪声比较强的时候。如需手动调整，应禁用Impedance Analyzer（阻抗分析仪）选项卡中的Bandwidth Control（带宽控制）按钮。在Measurement Control（测量控制）部分将Mode（模式）设置为Advanced（高级）后，此设置仅在IA选项卡的下半部分可见，请参见图3.20。Low-Pass Filters（低通滤波器）部分现在从禁用（灰显）状态变为可编辑（白色）状态。尝试不同的滤波器带宽，例如1 Hz和100 Hz，以查看对数据的实时影响，如图3.21所示。有关滤波器参数的更多信息，请参见第6章。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f22da2fe-f5f7-4c4c-a175-8f6b1419faa5/markdown_1/imgs/img_in_image_box_216_695_1069_986.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A18Z%2F-1%2F%2F1d37392f7de6a12aa463b8ba977d3107bae065fac6f3a974696f0b88d70517c0" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.20.Impedance Analyzer（阻抗分析仪）选项卡（Advanced（高级）模式）</div> </div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f22da2fe-f5f7-4c4c-a175-8f6b1419faa5/markdown_2/imgs/img_in_chart_box_243_115_1063_574.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A18Z%2F-1%2F%2Ffe741f33512bb0704d417f755505386d57eb25a2624a228fbac2ddb1305990df" alt="Image" width="68%" /></div>


时间(s)

<div style="text-align: center;"><div style="text-align: center;">图 3.21.LabOne Plotter（绘图仪）显示一段时间内的电阻测量值。手动更改滤波器设置会导致噪声发生变化。</div> </div>


下表总结了我们使用的 Plotter（绘图仪）设置。

<div style="text-align: center;"><div style="text-align: center;">表 3.13. 设置：配置 Sweeper（参数扫描仪）进行频率相关性测量</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>子选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Plotter（绘图仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'>Select a Preset（选择预设）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Impedance（阻抗）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>IA</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Measurement Control（测量控制）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Mode（模式）</td><td style='text-align: center; word-wrap: break-word;'>Advanced（高级）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>IA</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Bandwidth Control（带宽控制）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Auto（自动）</td><td style='text-align: center; word-wrap: break-word;'>OFF（关闭）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>IA</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Low-Pass Filters（低通滤波器）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>BW 3dB</td><td style='text-align: center; word-wrap: break-word;'>1 Hz / 100 Hz</td></tr></table>

#### 3.4.7. 测量精度

测量精度是阻抗分析仪的关键技术指标之一。它关系到测得的和实际的 DUT 阻抗。所提供的 1 kΩ DUT 与理想的 1 kΩ 电阻器相比，在 MFLI 频率范围内的实际阻抗误差在 0.05% 以内，因此适合判断测量结果的准确性。

测量精度不是一个通用数字，而是取决于频率和绝对阻抗 |Z_{DUT}|。图 3.22 显示了 MFLI 所涵盖的整个参数空间的精度。该阻抗精度图是一个很方便的工具，不仅可以获得测量精度，还能快速了解某个频率下电容或电感的绝对阻抗。对于 1 kΩ（垂直轴）和 1 kHz（水平轴），我们使用 0.05% 的精度。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f22da2fe-f5f7-4c4c-a175-8f6b1419faa5/markdown_3/imgs/img_in_chart_box_220_127_656_754.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A19Z%2F-1%2F%2F34aab505887e1c672419f599f3aca8bccc6c99534146f736cf408e82266f6c46" alt="Image" width="36%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.22. 阻抗精度图</div> </div>


##### 注释

仪器的相对精度规格适用于测得的总阻抗。它既不单独阻抗的实部或虚部，也不适用于电路表示参数。需要30分钟的预热和300 mV的测试信号才能达到最大精度。

### 3.5. 高级阻抗测量

##### 注释

本教程适用于所有 MFIA 仪器和安装了 MF-IA 阻抗分析仪选件的 MFLI 仪器。

#### 3.5.1. 目标和要求

本教程的目标是通过指导您测量与频率相关的阻抗来展示 LabOne 用户界面的一些更高级的功能。我们介绍了有关阻抗测量的重要实际内容，例如寄生效应的影响或参数抑制的作用。

本教程适用于对 Zurich Instruments 阻抗分析仪掌握了一些初步经验的人群。要学习本教程，您需要一个装有 MFITF 阻抗测试夹具的 1 MΩ DUT。比较简单的方法是将一个 1 MΩ 通孔电阻器焊接到 MFITF 随附的一个 DUT 载体上。

#### 3.5.2. 准备

首先将 MFITF 测试夹具连接到 MFLI 前面板上的 BNC 连接器，然后将 DUT 插入测试夹具正面的 8 针连接器。图 3.23 显示了硬件设置图。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f22da2fe-f5f7-4c4c-a175-8f6b1419faa5/markdown_4/imgs/img_in_image_box_225_662_1046_953.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A20Z%2F-1%2F%2F2ec6b64aaabc2506f75a2650b38ec0c43e3b32ce4b04e1af0d9606bf525435af" alt="Image" width="68%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.23. 阻抗测量教程的设置。被测设备是一个电阻器，焊接在 MFITF 随附的其中一个通孔 DUT 载体上。</div> </div>


确保 MFLI 仪器已通电，然后通过 USB 将 MFLI 直接连接到主机或通过以太网连接到主机所在的局域网 (LAN)。使用 Web 浏览器地址或 MF Device Finder 连接到仪器后，LabOne 图形用户界面打开。有关详细说明，请查看第 1 章。本教程可以使用默认仪器配置（例如，重启后）和默认用户界面设置（即在浏览器中按 F5 键后）启动。

#### 3.5.3. 阻抗和表示参数

DUT（如 1 MΩ 电阻器）的实际阻抗不一定等于其标称值或理想值。首先，DUT 阻抗值仅指定在某些精度范围内，例如 1%。除了这种缺陷之外，还有寄生阻抗分量，例如引线电感或并联电容。对于给定的 1 MΩ 电阻器，实际阻抗确实接近并联 Rp||Cp 电路的阻抗，并联电容器 Cp 为数百 fF。这种实际阻抗，包括设备缺陷，就是 MFLI 要测量的。

为了测量 1 MΩ DUT，我们使用合适的等效电路表示 Rp||Cp 来配置阻抗分析仪。由于我们使用的 DUT 载体仅连接到 2 条引线，因此我们将测量模式更改为 2 Terminal（2 端子）。此外，我们将 Range Control（范围控制）设置为 Auto（自动）。这会将输入电流和电压范围设置为合适的值。

表 3.14 总结了我们使用的仪器设置。

<div style="text-align: center;"><div style="text-align: center;">表 3.14. 设置：配置和启用阻抗分析仪</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>子选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>IA</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Equivalent Circuit（等效电路）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Mode（模式）</td><td style='text-align: center; word-wrap: break-word;'>2 Terminal（2 端子）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>IA</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Equivalent Circuit（等效电路）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Representation（表示）</td><td style='text-align: center; word-wrap: break-word;'>Rp  $ \parallel $ Cp</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>IA</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Measurement Control（测量控制）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Osc Frequency（振荡器频率）</td><td style='text-align: center; word-wrap: break-word;'>1 k</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>IA</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Measurement Control（测量控制）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Enable（启用）</td><td style='text-align: center; word-wrap: break-word;'>ON（打开）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>IA</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Range Control（范围控制）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Input Control（输入控制）</td><td style='text-align: center; word-wrap: break-word;'>Auto（自动）</td></tr></table>

#### 3.5.4. 测量频率相关性

打开 Sweeper（参数扫描仪）选项卡（Settings（设置）子选项卡），选择 Application Mode（应用模式），将 Impedance（阻抗）作为 Application（应用）。在 Control（控制）子选项卡中，您可以配置扫描参数、扫描范围和分辨率。我们选择在 1 kHz 到 1 MHz 范围内的对数频率扫描参数。我们首先测量绝对阻抗  $ |Z_{DUT}| $。选择“IA Abs(Z)”（IA 绝对值 (Z)）作为 Signal Type（信号类型），然后单击“Add Signal”（添加信号），将此参数添加到绘图中。下表总结了我们使用的 Sweeper（参数扫描仪）设置。

<div style="text-align: center;"><div style="text-align: center;">表 3.15. 设置：配置 Sweeper（参数扫描仪）进行频率相关性测量</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>子选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Settings（设置）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Filter（滤波器）</td><td style='text-align: center; word-wrap: break-word;'>Application Mode（应用模式）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Settings（设置）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Application（应用）</td><td style='text-align: center; word-wrap: break-word;'>Impedance（阻抗）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'>Horizontal（水平）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Sweep Param（扫描参数）</td><td style='text-align: center; word-wrap: break-word;'>Osc 1 Frequency（振荡器 1 频率）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'>Horizontal（水平）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Start / Stop（起始/结束）</td><td style='text-align: center; word-wrap: break-word;'>1k / 1M</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'>Horizontal（水平）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Length（长度）</td><td style='text-align: center; word-wrap: break-word;'>100 点</td></tr></table>

单击 Single 开始频率扫描。通过在 Vertical Axis Groups（垂直轴组）部分中选择“Impedance 1 Sample Abs(Z)”（阻抗 1 样本绝对值 (Z)），显示绝对阻抗  $ |Z_{DUT}| $。我们可能期望这个参数保持在 1 MΩ 不变，但实际上它在 500 kHz 频率下降低了大约 50%。图 3.24 中的绘图显示了  $ |Z_{DUT}| $ 的测量结果，即 Sweeper（参数扫描仪）选项卡绘图部分中的红色曲线。绝对阻抗的下降是由于寄生并联电容造成的。在足够高的频率下，该电容形成电流旁路，因此导致阻抗降低。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//d3273320-c378-4624-8a4c-87b8113c0bbd/markdown_1/imgs/img_in_chart_box_242_115_1062_516.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A20Z%2F-1%2F%2Fc474f30c46356b911bcfc5a76b28d0174e0f7f985a3efc6759c790dc46f20d04" alt="Image" width="68%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.24. 使用 LabOne Sweeper（参数扫描仪）测量的 1 MΩ 通孔设备的绝对阻抗  $ |Z_{DUT}| $ 和替换电路电阻</div> </div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//d3273320-c378-4624-8a4c-87b8113c0bbd/markdown_1/imgs/img_in_chart_box_243_609_1062_1011.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A20Z%2F-1%2F%2F65c94cee9498eeeaf75b3611506cef958425859b24e7dbb30583096c8aa3ddec" alt="Image" width="68%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.25. 使用 LabOne Sweeper（参数扫描仪）测量的 1 MΩ 通孔设备的替换电路电容</div> </div>


借助 Rp || Cp 电路表示，我们可以分别提取并联电阻 Rp 和电容 Cp。即使在 Sweep（扫描）完成后，我们也可以通过选择 IA Parameter 1（IA 参数 1）或 IA Parameter 2（IA 参数 2）作为 Signal Type（信号类型），然后单击“Add Signal”（添加信号）来将这些信号添加到绘图中。在 Vertical Axis Groups（垂直轴组）部分中选择相应的 Impedance 1 Sample Rep Parameter 1（阻抗 1 采样代表参数 1）或 Impedance 1 Sample Rep Parameter 2（阻抗 1 采样代表参数 2），将更改法拉（F）和欧姆（Ω）尺度之间的轴。

理想情况下，电阻和电容都与频率无关。看看图 3.24 (Rp) 中的蓝色曲线和图 3.25 (Cp) 中的绿色曲线，这确实是测量中经常出现的情况：在频率高达数个 100 kHz 的情况下，Rp 平稳保持在 1 MΩ 左右，而 Cp 保持在大约 0.5 pF。但是，两条曲线的几段都标有置信度指示器警告“Suppression”（抑制）。这表示电容测量结果在高频时最可靠，电阻测量结果在低频时最可靠。

#### 3.5.5. 测量奈奎斯特图

与传统频率相关性（水平轴为频率，垂直轴为阻抗参数）不同，Sweeper（参数扫描仪）还提供奈奎斯特图测量功能。奈奎斯特图是阻抗随频率变化的参数绘图，阻抗的实部（电阻）在水平轴上，虚部（电抗）在垂直轴上。要获取奈奎斯特图，请按照以下说明操作。

在 Sweeper（参数扫描仪）的 Control（控制）子选项卡中，选择所需的起始频率和结束频率。将 XY Mode（XY 模式）设置为 On-Invert（打开 - 取反）并从选择树中选择 Real(Z)（实部(Z)）作为 X Signal（X 信号）。在 Vertical Axis Groups（垂直轴组）中选择 Z 的虚部，将 IA Imag(Z)（IA 虚部(Z)）作为 Signal Type（信号类型）并将其添加到绘图中。单击 Single 开始扫描。通过将绘图左侧的轴缩放模式设置为 Auto（自动）来缩放垂直轴，请参见绘图区域元素。通过使用 Track（跟踪）（而不是 FS、Manual（手动）或 Auto（自动））轴缩放模式，可以固定水平轴以匹配垂直轴的缩放。这可确保复平面中的圆形在绘图中仍显示为圆形，与窗口纵横比无关。

下表总结了获取奈奎斯特图所需的设置。

<div style="text-align: center;"><div style="text-align: center;">表 3.16. 设置：配置 Sweeper（参数扫描仪）进行频率相关性测量</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>子选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>XY Mode（XY 模式）</td><td style='text-align: center; word-wrap: break-word;'>On - Invert（打开 - 取反）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>X Signal（X 信号）</td><td style='text-align: center; word-wrap: break-word;'>Impedances / Impedance 1 Sample / Real(Z)（阻抗/阻抗 1 样本/实部(Z)）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'>Vertical Axis Groups（垂直轴组）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Signal Type（信号类型）</td><td style='text-align: center; word-wrap: break-word;'>IA Imag(Z)（IA 虚部(Z)）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'>Vertical Axis Group（垂直轴组）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Add Signal（添加信号）</td><td style='text-align: center; word-wrap: break-word;'>Click（单击）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Plot Area（绘图区域）（左）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Axis Scaling Mode（轴缩放模式）</td><td style='text-align: center; word-wrap: break-word;'>Auto（自动）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Plot Area（绘图区域）（底部）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Axis Scaling Mode（轴缩放模式）</td><td style='text-align: center; word-wrap: break-word;'>Track（跟踪）</td></tr></table>

如本教程的图 3.23 所示，设置中作为 DUT 连接的 1 MΩ 电阻器具有相对来说特性不太明显的线性奈奎斯特图。为了更好地说明奈奎斯特图的特性，我们展示了半圆形的 R-R-C 电路的测量结果。如 84 所示，通过将通孔组件的样本焊接到通孔 DUT 载体上，可以轻松重现83 所示的测量结果。此处使用的组件为 R_p = 6.8 kΩ、R_s = 2.2 kΩ 和 C = 1 μF。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//d3273320-c378-4624-8a4c-87b8113c0bbd/markdown_2/imgs/img_in_chart_box_235_1095_1073_1502.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A21Z%2F-1%2F%2F4b174c2a053f6b5b3f57ec28c27e26be1081e437ed859b47f3e5107cb64392b9" alt="Image" width="70%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.26.R-R-C 样本奈奎斯特图</div> </div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//d3273320-c378-4624-8a4c-87b8113c0bbd/markdown_3/imgs/img_in_image_box_212_163_637_342.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A22Z%2F-1%2F%2F30db3c487bbdb7cf9523096da49c05ba9459b2e91cc5ef48bfede2c4b256f15c" alt="Image" width="35%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.27.R-R-C 样本电路图</div> </div>


#### 3.5.6. 保存和导出数据

使用 Sweeper（参数扫描仪）采集的数据可以轻松保存为逗号分隔值 (CSV)、MATLAB 和 ZView 格式。特别是 ZView 格式非常适用于使用专门的软件工具进行进一步的等效电路建模。这种分析通常能够精确表征 DUT 电路，远远超出提取一对表示参数得出的结果。

所有之前的扫描都列在 Sweeper（参数扫描仪）的 History（历史记录）子选项卡中，最多可达 History Length（历史记录长度）参数指定的最大列表条目数。单击 Save 将存储当前包含在 History（历史记录）列表中的所有扫描。数据存储在 LabOne Data（LabOne 数据）文件夹的子文件夹中，按照第 4.17 节的说明即可轻松访问。每个 History（历史记录）条目旁边的 Enable（启用）按钮控制绘图显示，但不控制保存哪些扫描。有关更多信息，例如有关如何使用“参考”功能，请参见第 4.10 节。从 Sweeper（参数扫描仪）的 History（历史记录）子选项卡底部的下拉列表中选择首选的文件格式。此设置是全局的，也适用于 Plotter（绘图仪）和 DAQ 选项卡。

此外，Sweeper（参数扫描仪）选项卡的绘图区域中的📐和📐按钮允许您将选定的图形迹线保存为文本文件或矢量图。

### 3.6. 补偿

##### 注释

本教程适用于所有 MFIA 仪器和安装了 MF-IA 阻抗分析仪选件的 MFLI 仪器。

#### 3.6.1. 目标和要求

本教程的目的是演示使用 MFLI 仪器进行阻抗测量的用户补偿。使用定制阻抗夹具时，补偿可提高测量精度。

学习本教程需要对 Zurich Instruments 阻抗分析仪有一些初步经验。您还需要一个开尔文探针电缆组和一个  $ 1 \Omega $ 通孔电阻器、一个  $ 10 \Omega $ 电阻器和一根简单的电线。您可以使用一组 BNC 电缆和鳄鱼夹来代替开尔文探针组。

#### 3.6.2. 准备

首先将开尔文探针组连接到 MFLI 前面板上的 BNC 连接器，注意不要混淆连接器。一个夹子应与 Signal Output +V 和 Signal Input +V 电气连接，另一个夹子应与 Signal Input I 和 Signal Input -V 电气连接。用两个夹子固定 1 Ω 电阻器。图 3.28 显示了硬件设置图。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//d3273320-c378-4624-8a4c-87b8113c0bbd/markdown_4/imgs/img_in_image_box_227_715_890_1115.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A23Z%2F-1%2F%2F3a4f24cfb21e28761ec82b6b11ede3f5d3d936bddfc7c4c26930e248d60f78b4" alt="Image" width="55%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.28. 阻抗补偿教程的设置</div> </div>


确保 MFLI 仪器已通电，然后通过 USB 将 MFLI 直接连接到主机或通过以太网连接到主机所在的局域网 (LAN)。使用 Web 浏览器地址并通过 Web 浏览器连接到仪器后，LabOne 图形用户界面打开。有关详细说明，请查看第 1 章。本教程可以使用默认仪器配置（例如，重启后）和默认用户界面设置（即在浏览器中按 F5 键后）启动。

#### 3.6.3. 配置阻抗分析仪

像开尔文探针组这样的测量夹具通过其电气特性来影响阻抗测量，例如其杂散电容或其电缆引起的延迟。事实上，谨慎执行补偿实际上可以消除负面影响，从而提高测量精度。

为了解开尔文探针的影响，我们首先进行无补偿的快速测量。我们将在 Impedance Analyzer（阻抗分析仪）选项卡中选择 Rs+Ls Representation（Rs+Ls 表示），这对于数值较小的电阻来说是一个

不错的选择。可以在已激活 Impedance（阻抗）预设的 Numeric（数值）选项卡中查看这两个表示参数。此外，我们还通过在 Impedance Analyzer（阻抗分析仪）选项卡中将 Suppression Ratio（抑制比）设置为 100 来放宽抑制警告的阈值。将 Measurement Control（测量控制）的 Mode（模式）设置为 Advanced（高级）后，此设置显示在选项卡的下半部分。条件放宽后，我们就可以使用这种基于电缆的设置达到理想的精度水平。

让我们先看看不同振荡器频率下的一些测量值，我们在 Impedance Analyzer（阻抗分析仪）选项卡中手动更改这些频率。

<div style="text-align: center;"><div style="text-align: center;">表 3.17. 测量：1 K 通孔电阻器（无补偿）</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>频率</td><td style='text-align: center; word-wrap: break-word;'>代表参数 1（电阻 Rs）</td><td style='text-align: center; word-wrap: break-word;'>代表参数 2（电感 Ls）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>1 kHz</td><td style='text-align: center; word-wrap: break-word;'>1.001 Ω</td><td style='text-align: center; word-wrap: break-word;'>抑制</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>500 kHz</td><td style='text-align: center; word-wrap: break-word;'>0.986 Ω</td><td style='text-align: center; word-wrap: break-word;'>110 nH</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>3 MHz</td><td style='text-align: center; word-wrap: break-word;'>0.738 Ω</td><td style='text-align: center; word-wrap: break-word;'>112 nH</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>5 MHz（MF-5M 选件）</td><td style='text-align: center; word-wrap: break-word;'>抑制</td><td style='text-align: center; word-wrap: break-word;'>111 nH</td></tr></table>

1 kHz 频率下的电阻（代表参数 1）看起来很合理。电感（代表参数 2）在此频率下无法可靠测量，并标有“抑制”警告。在 500 kHz 等较高频率下，电感是可测量的，但似乎有些过大：110 nH 相当于 10 到 15 cm 的电线，但电阻器引线要短得多。通孔组件的寄生串联电感 Ls 通常为 5 nH 的阶数。在 3 Mhz 下，测得的电阻降至 0.738 Ω，这似乎不太现实。在最大频率 5 Mhz 下，电阻测量最终失败。下表总结了我们使用的设置。

<div style="text-align: center;"><div style="text-align: center;">表 3.18. 设置：使用未补偿的开尔文探针组进行快速测量</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>子选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>IA</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Equivalent Circuit（等效电路）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Representation（表示）</td><td style='text-align: center; word-wrap: break-word;'>Rs + Ls</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>IA</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Measurement Control（测量控制）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Enable（启用）</td><td style='text-align: center; word-wrap: break-word;'>ON（打开）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>IA</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Measurement Control（测量控制）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Mode（模式）</td><td style='text-align: center; word-wrap: break-word;'>Advanced（高级）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>IA</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Confidence Indicators（置信度指示器）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Suppression（抑制）</td><td style='text-align: center; word-wrap: break-word;'>100</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>IA</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Measurement Control（测量控制）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Osc Frequency（振荡器频率）</td><td style='text-align: center; word-wrap: break-word;'>1k、500k、3M、5M</td></tr></table>

#### 3.6.4. 执行补偿

之前看到的一些明显问题可归因于未补偿的开尔文探针组。要进行补偿，请打开 Impedance Analyzer（阻抗分析仪）选项卡中的 Cal（校准）侧边栏选项卡并在 Compensation Sequence（补偿序列）中选择 SOL（短路/开路负载）。需要指定“负载”DUT 的参数：10 Ω，由于我们不确定杂散电容，我们将输入 0 F 这个值作为 Load C（负载 C）。现在可以通过固定合适的 DUT（S 步骤需要电线、L 步骤需要 10 Ω 电阻器，O 步骤不需要任何设备）来简单地执行三个补偿步骤，然后单击“Short”（短路）、“Open”（开路）或“Load”（负载）按钮，然后单击“Compensate”（补偿）。要进行精确校准，在所有三个步骤和原本测量过程中请尽量确保夹子的位置相同。夹子的位置和电缆非屏蔽部分对寄生电容的影响很大。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//ab01e10d-daae-4792-88ed-67bd0da25f2b/markdown_1/imgs/img_in_image_box_215_114_1079_354.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A48Z%2F-1%2F%2F2a3f563ecfbbf049e06e7afd1145da2798c7699089e1d2e22a712d4da864f820" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.29.Impedance Analyzer（阻抗分析仪）选项卡：Cal（校准）侧边栏选项卡</div> </div>


在标准设置下，每个补偿步骤大约需要 1 分钟时间，补偿进度和终止情况会报告在“Compensate”（补偿）按钮下的文本框内。状态指示灯将显示哪些步骤已经完成。所有三个步骤全部完成后，补偿数据会传输到仪器。必要时可保存并重新加载补偿文件。

<div style="text-align: center;"><div style="text-align: center;">表 3.19. 设置：执行用户补偿</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>子选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>IA</td><td style='text-align: center; word-wrap: break-word;'>Cal（校准）</td><td style='text-align: center; word-wrap: break-word;'>Compensation Sequence（补偿序列）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Mode（模式）</td><td style='text-align: center; word-wrap: break-word;'>SOL（短路/开路负载）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>IA</td><td style='text-align: center; word-wrap: break-word;'>Cal（校准）</td><td style='text-align: center; word-wrap: break-word;'>Compensation Sequence（补偿序列）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Load R（负载 R）( $ \Omega $)</td><td style='text-align: center; word-wrap: break-word;'>10</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>IA</td><td style='text-align: center; word-wrap: break-word;'>Cal（校准）</td><td style='text-align: center; word-wrap: break-word;'>Compensation Sequence（补偿序列）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Load C（负载 C）(F)</td><td style='text-align: center; word-wrap: break-word;'>0</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>IA</td><td style='text-align: center; word-wrap: break-word;'>Cal（校准）</td><td style='text-align: center; word-wrap: break-word;'>Compensation Sequence（补偿序列）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Step（步骤）</td><td style='text-align: center; word-wrap: break-word;'>Short /Open /Load（短路/开路/负载）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>IA</td><td style='text-align: center; word-wrap: break-word;'>Cal（校准）</td><td style='text-align: center; word-wrap: break-word;'>Compensation Sequence（补偿序列）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Compensate（补偿）</td><td style='text-align: center; word-wrap: break-word;'>ON（打开）</td></tr></table>

Cal（校准）侧边栏选项卡的左侧部分显示信息，当前用户补偿和内部校准的启用按钮也在这里。

User Compensation（用户补偿）（或 Internal Calibration（内部校准））标签被用作画面切换控件（标签右下角的黑色小三角形表示控件）。当切换到 User Compensation（用户补偿）画面时，使用 Enable（启用）按钮便可轻松激活和禁用补偿功能。这会直接影响到 Numeric（数值）、Plotter（绘图仪）或 Sweeper（参数扫描仪）选项卡中显示的测量数据。

#### 注释

通常，内部校准功能应始终启用。

#### 3.6.5. 在启用补偿的情况下进行测量

为了比较启用补偿和不启用补偿两种情况下的结果，我们将执行直至最大可用频率的扫描操作，正如前面的教程所示。在 Sweeper（参数扫描仪）选项卡中，执行从 1 kHz 到 5 Mhz 的线性频率扫描。在启用补偿和不启用补偿的情况下各重复扫描操作一次。

我们来看看下面图 3.30 绘图中选定的两个物理量。Resistance（电阻）（= 代表参数 1）在启用补偿（绿色）后保持在 1.0 Ω，不启用补偿则降到 0.4 Ω 以下。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//ab01e10d-daae-4792-88ed-67bd0da25f2b/markdown_2/imgs/img_in_chart_box_238_132_1061_487.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A49Z%2F-1%2F%2F8d3dfe95012736ae0461c42d66fe174476685f2a7a5fcdac2bfe305a0a698dbc" alt="Image" width="69%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.30.LabOne Sweeper（参数扫描仪）显示启用补偿（绿色）和不启用补偿（灰色）测到的  $ 1 \Omega $ DUT 的电阻</div> </div>


不管启不启用补偿，电感（= 参数 2）在频率下都相对稳定，请参见 图 3.31。但在不补偿的情况下，它的值太大了。补偿后的电感测量值小于 10 nH，虽然达到预期的数量级，但不管怎样还是太小了，不能进行高精度测量，因为被标记为“Suppression”（抑制）警告。请注意，电阻器的引线电感约为 8 nH/cm。将 DUT 夹在稍微不同的位置，然后再测量，结果显示对测量到的电感 Ls 有影响，但对电阻 Rs 基本上没有影响。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//ab01e10d-daae-4792-88ed-67bd0da25f2b/markdown_2/imgs/img_in_chart_box_222_775_1064_1139.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A49Z%2F-1%2F%2F2b27201083c2b94d7883de1970a80acef5ab9916792f581c9dccfb136743b77d" alt="Image" width="70%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.31.LabOne Sweeper（参数扫描仪）显示启用补偿（红色）和不启用补偿（灰色）测到的 1 K DUT 的串联电感</div> </div>


### 3.7. 锁相环

##### 注释

本教程适用于所有安装了 MF-PID 四通道 PID/PLL 控制器选件的 MF 仪器。

#### 3.7.1. 目标和要求

本教程阐述了如何使用锁相环 (PLL) 追踪谐振器的共振频移。按照教程所讲，Signal Output 1 和 Signal Input 1 之间需要连接一个谐振器。

#### 3.7.2. 准备

连接电缆，如下图所示。确保 MF 仪器已通电，然后通过 USB 将 MF 仪器连接到主机或通过以太网连接到主机所在的局域网 (LAN)。LabOne 启动后，打开带有 LabOne 图形用户界面的默认的 Web 浏览器。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//ab01e10d-daae-4792-88ed-67bd0da25f2b/markdown_3/imgs/img_in_image_box_218_622_1078_934.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A50Z%2F-1%2F%2Fc13cd1d15a850ccfac2efb6fc38106138bbfb2cf758bf2671c52e6c26cbf12ed" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.32. 使用 MF 仪器进行 PLL 连接</div> </div>


本教程可以使用默认仪器配置（例如，重启后）和默认用户界面设置（例如，在浏览器中按 F5 键后）启动。

#### 3.7.3. 确定石英谐振器的共振

本节首先介绍如何使用 109 工具来确定谐振器的共振。在 Sweeper（参数扫描仪）选项卡中，可以先定义整个仪器带宽范围内的频率扫描，然后通过多次扫描缩小范围，从而找到期望的共振峰值。在本例中，我们已经知道共振频率大约在 1.8 MHz，这为我们发现峰值节省了一些时间，因为 Q 因子相当高。Sweeper（参数扫描仪）选项卡设置和 Lock-in（锁相）选项卡设置如下表所示。

##### 注释

下表适用于未安装 MF-MD 多解调器选件的仪器。如果安装了 MF-MD 多解调器选件，需要在 Lock-in（锁相）选项卡的 Output Amplitude（输出幅值）部分配置输出幅值。

<div style="text-align: center;"><div style="text-align: center;">表 3.20. 设置：扫描测量频率</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>子选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>All（全部）</td><td style='text-align: center; word-wrap: break-word;'>Signal Outputs（信号输出）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Amp（幅值）(V)</td><td style='text-align: center; word-wrap: break-word;'>100.0 m / ON（打开）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>All（全部）</td><td style='text-align: center; word-wrap: break-word;'>Signal Outputs（信号输出）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Output 1（输出1）</td><td style='text-align: center; word-wrap: break-word;'>ON（打开）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>All（全部）</td><td style='text-align: center; word-wrap: break-word;'>Signal Inputs（信号输入）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>50 \Omega</td><td style='text-align: center; word-wrap: break-word;'>ON（打开）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>All（全部）</td><td style='text-align: center; word-wrap: break-word;'>Signal Inputs（信号输入）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Diff（差分）</td><td style='text-align: center; word-wrap: break-word;'>OFF（关闭）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>All（全部）</td><td style='text-align: center; word-wrap: break-word;'>Demodulators（解调器）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Osc（振荡器）</td><td style='text-align: center; word-wrap: break-word;'>1</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>All（全部）</td><td style='text-align: center; word-wrap: break-word;'>Demodulators（解调器）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Input（输入）</td><td style='text-align: center; word-wrap: break-word;'>Sig In 1（信号输入 1）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>All（全部）</td><td style='text-align: center; word-wrap: break-word;'>Data Transfer（数据传输）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Enable（启用）</td><td style='text-align: center; word-wrap: break-word;'>ON（打开）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'>Horizontal（水平）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Sweep Param.（扫描参数）</td><td style='text-align: center; word-wrap: break-word;'>Osc 1 Frequency（振荡器 1 频率）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'>Vertical Axis Groups（垂直轴组）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Signal Type（信号类型）/ Channel（通道）</td><td style='text-align: center; word-wrap: break-word;'>Demod \Theta / 1（解调器 \Theta / 1）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'>Vertical Axis Groups（垂直轴组）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Add Signal（添加信号）</td><td style='text-align: center; word-wrap: break-word;'>单击</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'>Vertical Axis Groups（垂直轴组）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Signal Type（信号类型）/ Channel（通道）</td><td style='text-align: center; word-wrap: break-word;'>Demod R / 1（解调器 R / 1）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'>Vertical Axis Groups（垂直轴组）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Add Signal（添加信号）</td><td style='text-align: center; word-wrap: break-word;'>单击</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'>Horizontal（水平）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Start（起始）（Hz）</td><td style='text-align: center; word-wrap: break-word;'>1 M</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'>Horizontal（水平）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Stop（结束）（Hz）</td><td style='text-align: center; word-wrap: break-word;'>3 M</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>History（历史记录）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Length（长度）</td><td style='text-align: center; word-wrap: break-word;'>2</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'>Settings（设置）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Dual Plot（双绘图）</td><td style='text-align: center; word-wrap: break-word;'>ON（打开）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'>Settings（设置）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Run/Stop（运行/停止）</td><td style='text-align: center; word-wrap: break-word;'>ON（打开）</td></tr></table>





我们使用解调器 1 生成扫描信号，再解调通过谐振器传输的信号。Lock-in（锁相）设置确保用于生成和测量的振荡器是同一个（振荡器 1）。此外，应按照接线图将输入设置为 Signal Input 1（信号输入 1）。

单击 Sweeper（参数扫描仪）的 Run/Stop 按钮，Sweeper（参数扫描仪）将重复扫描石英振荡器的频率响应。History Length（历史记录长度）为 2，允许在调整扫描范围的同时在屏幕上保留前一次扫描。可以使用放大工具在共振峰值时获得更高的分辨率。只需单击 Copy From Range 按钮，便可重新定义起始频率和结束频率，获得更精细的参数扫描仪范围。这将自动把绘图频率范围粘贴到 Sweeper（参数扫描仪）频率范围的 Start（起始）和 Stop（结束）字段中。

##### 注释

即时不改变点数，使用 Copy From Range 按钮水平放大时，扫描频率的分辨率也会变得更精细。

发现共振峰值后，应该会得到和下面两图中的实线差不多的测量值。我们可以通过共振拟合工具来轻松确定共振参数，比如 Q 因子、中心频率或峰值幅度。要使用这个工具，先要在共振左右两侧放两个 X 光标，然后打开 Sweeper（参数扫描仪）选项卡的 Math（数学）子选项卡，再从左侧下拉

菜单中选择“Resonance”（共振），最后单击 Add。重复这一操作，一次使用解调器幅值作为绘图中的活动迹线，一次使用解调器相位（参见垂直轴组）。该工具将对 LCR 电路的响应函数执行最小二乘拟合算法。在 Q 因子较大的极限情况下，这相当于对幅值洛伦兹函数的平方根和相位反正切的拟合。具体的拟合函数参见“光标和数学”一节。

绘图中的虚线为添加的拟合曲线，参见图 3.33 和图 3.34。由于这两种拟合是独立的，如果共振明显偏离简单的 LCR 电路模型，那么它们可能会导致不同的结果。引线之间若存在电容耦合，通常就会发生这种情况。在本例中，对相位曲线的拟合明显优于对幅值曲线的拟合，产生的 Q 因子约为 12,800，中心频率为 1.8428 MHz。

当在 50 Ω 输入上通过共振传递时，图 3.34 中的相位遵循从 +90° 到 -90° 的典型谐振器响应。刚好在共振处测到的相位接近 0°。我们将把这个值作为 PLL 的相位设定值。完成 Sweeper（参数扫描仪）测量后，单击 Run/Stop 关闭扫描操作。这将从 Sweeper（参数扫描仪）的控制中释放振荡器频率。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//1b2bd65e-bd2f-4bb3-8e0e-9d7f0ec876cf/markdown_0/imgs/img_in_image_box_223_471_295_538.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A09Z%2F-1%2F%2Ffe073cfecb63acf1174c1403ff181544283d7f28ee9f08ad1dd802b7a364ffdc" alt="Image" width="6%" /></div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//1b2bd65e-bd2f-4bb3-8e0e-9d7f0ec876cf/markdown_0/imgs/img_in_chart_box_244_582_1062_945.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A09Z%2F-1%2F%2F5bf0b7043058966334767b1b1a2108e4e5de892f6599f7e62309ba1b184b4ba4" alt="Image" width="68%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.33. 使用 LabOne Sweeper（参数扫描仪）测量的谐振器频率响应的幅值。实线指测量数据，虚线指使用共振拟合工具对 LCR 电路模型的响应函数进行的拟合。</div> </div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//1b2bd65e-bd2f-4bb3-8e0e-9d7f0ec876cf/markdown_0/imgs/img_in_chart_box_239_1060_1062_1432.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A10Z%2F-1%2F%2F01de1867870fb61c1f855d63af42062a3cc0ce152ed7bfb82bec1768828e9c9a" alt="Image" width="69%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.34. 使用 LabOne Sweeper（参数扫描仪）测量的谐振器频率响应的相位。实线指测量数据，虚线指使用共振拟合工具对 LCR 电路模型的响应函数进行的拟合。</div> </div>


#### 3.7.4. 使用 PLL 进行共振跟踪

现在我们知道了共振频率和在这个频率测量到的相位。我们可以通过锁定到这个相位来追踪共振频率的偏移情况，因此这也叫做锁相环(PLL)。锁相环可在 PLL 选项卡中找到。每个 MFLI 仪器都有 4 个 PID（比例-积分-微分）控制器，前两个还可用作 PLL 控制器。本教程将使用 PLL 1（锁相环 1）。首先使用之前测量到的值来设置基本的 PLL 1 字段，如下表所示。

<div style="text-align: center;"><div style="text-align: center;">表 3.21. 设置：设置锁相环</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>子选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PLL</td><td style='text-align: center; word-wrap: break-word;'>PLL</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Mode（模式）</td><td style='text-align: center; word-wrap: break-word;'>PLL</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PLL</td><td style='text-align: center; word-wrap: break-word;'>PLL</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Auto Mode（自动模式）</td><td style='text-align: center; word-wrap: break-word;'>PID Coeff（PID 多项式系数）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PLL</td><td style='text-align: center; word-wrap: break-word;'>PLL</td><td style='text-align: center; word-wrap: break-word;'>Input（输入）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Setpoint（设定值）(deg)</td><td style='text-align: center; word-wrap: break-word;'>0.0</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PLL</td><td style='text-align: center; word-wrap: break-word;'>PLL</td><td style='text-align: center; word-wrap: break-word;'>Output（输出）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Output（输出）</td><td style='text-align: center; word-wrap: break-word;'>Oscillator Frequency / 1（振荡器频率 / 1）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PLL</td><td style='text-align: center; word-wrap: break-word;'>PLL</td><td style='text-align: center; word-wrap: break-word;'>Output（输出）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Center Freq（中心频率）(Hz)</td><td style='text-align: center; word-wrap: break-word;'>1.8428 M</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PLL</td><td style='text-align: center; word-wrap: break-word;'>PLL</td><td style='text-align: center; word-wrap: break-word;'>Output（输出）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Lower / Upper Limit（下限/上限）(Hz)</td><td style='text-align: center; word-wrap: break-word;'>-10k / +10 k</td></tr></table>

相对于 Center Frequency（中心频率）的上下限频率（或范围）要选择得足够窄，这样设备的相位才能形成单调曲线，在设定值处有一个交叉点，否则反馈控制器将无法正确锁定。我们选择第 1 个振荡器和解调器 1 来进行锁相环操作。接下来，我们需要找到合适的反馈增益参数（P、I、D），这就需要用到 Advisor（智能参数设定）。将 DUT Model（DUT 模型）设置为 Resonator Frequency（谐振器频率），再将 Target BW（Hz）（目标带宽（Hz））设置为 1.0 kHz，然后单击 To Advisor 将 Center Frequency（中心频率）复制到 Advisor（智能参数设定）的共振频率字段。目标带宽应至少与频率变量的预期带宽一样大。在本例中，谐振器频率其实是稳定的，因此 1 kHz 的带宽就足够了。单击 Advise 按钮，让 Advisor（智能参数设定）使用数值优化算法确定一系列反馈增益参数。图 3.35 显示的是 Advisor（智能参数设定）操作完成后典型的 PLL 选项卡视图。Advisor（智能参数设定）尝试在模拟中匹配或超越目标带宽。获得的带宽可以从 BW（Hz）（带宽（Hz））字段读取，也可以直接从右侧模拟的波特图的 3 dB 点读取。模拟的 Phase Margin（相位裕度）值显示在 PM（deg）字段并且应该超过 45°，这样才能确保稳定的反馈操作，不会出现振荡。如果对 Advisor（智能参数设定）的结果感到满意，请单击 To PLL 按钮，将反馈增益参数传输到物理 PLL 控制器上。要启动 PLL 操作，请单击 PLL 选项卡顶部的 Enable（启用）按钮。

<div style="text-align: center;"><div style="text-align: center;">表 3.22. 设置：设置并运行 PID Advisor（PID 智能参数设定）</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>子选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PLL</td><td style='text-align: center; word-wrap: break-word;'>Advisor（智能参数设定）</td><td style='text-align: center; word-wrap: break-word;'>Advisor（智能参数设定）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Target BW（目标带宽）(Hz)</td><td style='text-align: center; word-wrap: break-word;'>1 k</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PLL</td><td style='text-align: center; word-wrap: break-word;'>Advisor（智能参数设定）</td><td style='text-align: center; word-wrap: break-word;'>DUT Model（DUT模型）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>DUT Model（DUT模型）</td><td style='text-align: center; word-wrap: break-word;'>Resonator Frequency（谐振器频率）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PLL</td><td style='text-align: center; word-wrap: break-word;'>Advisor（智能参数设定）</td><td style='text-align: center; word-wrap: break-word;'>DUT Model（DUT模型）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Res Frequency（共振频率）(Hz)</td><td style='text-align: center; word-wrap: break-word;'>1.8 M</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PLL</td><td style='text-align: center; word-wrap: break-word;'>Advisor（智能参数设定）</td><td style='text-align: center; word-wrap: break-word;'>DUT Model（DUT模型）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Q</td><td style='text-align: center; word-wrap: break-word;'>12.8 k</td></tr></table>

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//1b2bd65e-bd2f-4bb3-8e0e-9d7f0ec876cf/markdown_2/imgs/img_in_image_box_213_105_1080_568.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A11Z%2F-1%2F%2Fa6d5b6d75f8197061a641b157b1074ad8bf933ab8a3746ff151b8624f440cc4a" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.35.PLL 选项卡中的设置和 Advisor（智能参数设定）模拟（典型-参数可能与示例不同）</div> </div>


当 PLL 被锁定时，Error/PLL Lock（误差/PLL 锁相）标签旁边的绿色指示灯将亮起。实际频移显示在 Freq Shift (Hz)（频移 (Hz)）字段中。

#### 注释

此时建议单击 Lock-in（锁相）选项卡中的 Auto Range（自动选择范围）☑按钮来调整信号输入范围。这通常会增加信噪比，有助于 PLL 锁定输入信号。

将频移可视化最简单的办法就是使用 Plotter（绘图仪）工具。通过使用树状选择器☎导航到Demodulator 1（解调器 1）→采样并选择频率，可将频率添加到画面中。频率噪声随着 PLL 带宽的增加而增加，因此为了获得最佳噪声性能，带宽不应高于实验所需的带宽。频率噪声还与谐振器的驱动幅值成反比。

### 3.8. 自动增益控制

##### 注释

本教程适用于所有安装了 MF-PID 四通道 PID/PLL 控制器选件的 MF 仪器。

#### 3.8.1. 目标和要求

本教程阐述了如何安装 PID 控制器实现自动增益控制。我们使用 PID Advisor（PID 智能参数设定）来模拟反馈回路的阶跃响应，并通过 Data Acquisition（数据采集）工具来捕捉回路的物理阶跃响应。我们还利用 Signal Output 1 和 Signal Input 1 之间的石英谐振器来进行测试。

#### 3.8.2. 准备

按下图连接电缆。确保 MF 仪器已通电，然后通过 USB 将 MF 仪器连接到 PC 或主机所在的局域网 (LAN)。LabOne 启动后，打开带有 LabOne 图形用户界面的默认的 Web 浏览器。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//1b2bd65e-bd2f-4bb3-8e0e-9d7f0ec876cf/markdown_3/imgs/img_in_image_box_216_598_1061_901.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A12Z%2F-1%2F%2Fde15304486737b87b2316cde4f19893b8fe55235995afc341b73ccd3dd2b3d27" alt="Image" width="70%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.36. 使用 MF 仪器进行 PID 连接</div> </div>


本教程可以使用默认仪器配置（例如，重启后）和默认用户界面设置（例如，在浏览器中按 F5 键后）启动。

#### 3.8.3. 自动增益控制

本节将介绍如何使用 PID 控制器来控制被测设备的输出幅值。我们将使用石英谐振器，其由仪器的信号发生器进行谐振频率驱动，并用解调器进行测量。

如果从第 3.7 节继续，那么只要启用 PLL 就可以。否则，就要知道如何在所需频率生成激励信号，以及如何测量自己想控制的信号幅值。被测设备不必是谐振器。

如下面的频率响应曲线所示，我们在以 100 mV $ _{pk} $ 驱动时，在谐振峰值处测量到大约 4.0 mV 的幅值。目标是让用户在运行中对该幅值进行编程。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//1b2bd65e-bd2f-4bb3-8e0e-9d7f0ec876cf/markdown_4/imgs/img_in_image_box_217_155_293_228.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A13Z%2F-1%2F%2F805ddbb18d25179ffbe881acb640bedc2b577ffb2ced85db592a6c2b2a75c3ae" alt="Image" width="6%" /></div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//1b2bd65e-bd2f-4bb3-8e0e-9d7f0ec876cf/markdown_4/imgs/img_in_chart_box_241_251_1125_646.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A13Z%2F-1%2F%2Fac73ab8b261decca168651429c8fbb4e9b87d6597a2396e4380fb71f02882142" alt="Image" width="74%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.37. 使用 LabOne Sweeper（参数扫描仪）测量的谐振器频率响应的幅值。实线指测量数据，虚线指使用共振拟合工具对 LCR 电路模型的响应函数进行的拟合。</div> </div>


要设置自动增益控制，请打开 PID / PLL 选项卡，其中四个可用的 PID 控制器显示在不同的侧边栏选项卡中。由于前两个控制器还兼具 PLL 的用途，因此我们将在本教程中使用 PID 3。我们将控制器的输入定义为测量的锁相 R 信号，输出定义为驱动幅值。设置如下表所示。

##### 注释

下表适用于未安装 MF-MD 多解调器选件的仪器。安装该选件后，需要将 Output 1 Amplitude（输出 1 幅值）通道设置为用于在 Lock-in（锁相）选项卡的 Output Amplitudes（输出幅值）部分生成信号的解调器的数量。

<div style="text-align: center;"><div style="text-align: center;">表 3.23. 设置：设置 PID 控制器</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>子选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID / PLL</td><td style='text-align: center; word-wrap: break-word;'>PID / PLL</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>3</td><td style='text-align: center; word-wrap: break-word;'>Mode（模式）</td><td style='text-align: center; word-wrap: break-word;'>PID</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID / PLL</td><td style='text-align: center; word-wrap: break-word;'>PID / PLL</td><td style='text-align: center; word-wrap: break-word;'>Input（输入）</td><td style='text-align: center; word-wrap: break-word;'>3</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Demod R / 1（解调器 R / 1）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID / PLL</td><td style='text-align: center; word-wrap: break-word;'>PID / PLL</td><td style='text-align: center; word-wrap: break-word;'>Input（输入）</td><td style='text-align: center; word-wrap: break-word;'>3</td><td style='text-align: center; word-wrap: break-word;'>Setpoint（设定值）(V)</td><td style='text-align: center; word-wrap: break-word;'>10 m</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID / PLL</td><td style='text-align: center; word-wrap: break-word;'>PID / PLL</td><td style='text-align: center; word-wrap: break-word;'>Output（输出）</td><td style='text-align: center; word-wrap: break-word;'>3</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Output 1 Amplitude / 1（输出 1 幅值 / 1）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID / PLL</td><td style='text-align: center; word-wrap: break-word;'>PID / PLL</td><td style='text-align: center; word-wrap: break-word;'>Output（输出）</td><td style='text-align: center; word-wrap: break-word;'>3</td><td style='text-align: center; word-wrap: break-word;'>Center（中心）(V)</td><td style='text-align: center; word-wrap: break-word;'>0.5</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID / PLL</td><td style='text-align: center; word-wrap: break-word;'>PID / PLL</td><td style='text-align: center; word-wrap: break-word;'>Output（输出）</td><td style='text-align: center; word-wrap: break-word;'>3</td><td style='text-align: center; word-wrap: break-word;'>Lower/Upper Limit（上限/下限）(V)</td><td style='text-align: center; word-wrap: break-word;'>-0.5/+0.5</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID / PLL</td><td style='text-align: center; word-wrap: break-word;'>PID / PLL</td><td style='text-align: center; word-wrap: break-word;'>Output（输出）</td><td style='text-align: center; word-wrap: break-word;'>3</td><td style='text-align: center; word-wrap: break-word;'>Range（范围）</td><td style='text-align: center; word-wrap: break-word;'>0.5</td></tr></table>

下一步是选择合适的反馈增益参数（P、I、D）。在 MF 仪器上，我们可以在 PID Advisor（PID 智能参数设定）的帮助下完成此操作。基于被测设备（DUT）的一组数学模型，它可以模拟一组特定反

馈增益值的阶跃响应。PID Advisor（PID 智能参数设定）对反馈增益参数进行数值优化，以获得等于或超过用户指定目标带宽的阶跃响应。

有关可用 DUT 模型列表，请参见第 4.18 节。如果您的 DUT 没有被其中一个模型很好地展现出来，这里介绍的方法可帮助您实施某种试探性调谐方法（例如 Good Gain 方法（Finn Haugen，挪威泰勒马克大学学院，2010 年），因为它们可以测量闭环阶跃响应。

PID Advisor（PID 智能参数设定）提供了一种高效的图形工具，可手动设置反馈增益参数。要使用这种工具，请在 Display（显示）子选项卡中启用 Advanced Mode（高级模式），然后从 Transfer Function（传递函数）菜单中选择 PID。三条光标线将添加到显示部分，代表 PID 控制器传递函数的 P、I 和 D 部分的频率相关性。拖动光标即可定义目标波特图。如果您启用 Advisor Link（智能参数设定关联）按钮，则来自光标的反馈增益参数将与来自 Advisor（智能参数设定）的模拟参数相关联，这些参数可以从此处传输到仪器。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//24efe8ed-6983-4ecc-8a07-623f12340510/markdown_0/imgs/img_in_image_box_217_439_287_505.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A15Z%2F-1%2F%2Fa481544254f54dea9496350305f17ae3595bab42c53c5978f0a1e98ddea7c246" alt="Image" width="5%" /></div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//24efe8ed-6983-4ecc-8a07-623f12340510/markdown_0/imgs/img_in_chart_box_219_522_1081_995.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A16Z%2F-1%2F%2Fe94318e28fe6466e63ca39b8a56fb54ccd799c3790b50ffe43ad768a4482d13a" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.38. 使用光标对 PID 参数进行图形设置。具有负斜率、零斜率和正斜率的三条光标线分别对应于控制器的 P、I 和 D 部分的频率相关性。</div> </div>


#### 3.8.4. 模拟被测设备

在 Advisor（智能参数设定）子选项卡中，选择“Resonator Amplitude”（谐振器幅值）作为 DUT 的模型。该模型有四个参数：延迟、增益、中心频率和 Q。后两者可以使用 Math（数学）子选项卡中的共振拟合工具，通过 Sweeper（参数扫描仪）选项卡中的频率响应测量轻松确定，如确定石英谐振器的共振所述。我们得出 Q 因子约为 12,800，中心频率为 1.8428 MHz。延迟值表示额外的延迟，例如来自电缆的延迟（通常为每米 4-5 ns）。由于我们使用的是短电缆，这些延迟可以忽略不计，我们可以将延迟参数保持在 0 s。增益值让 PID 控制器输出和输入之间的整体信号增益或衰减实现了参数化，包括单位转换。在本例中，当驱动幅度设置为 100 mVpk 时，测量共振时的 R 幅值为 4.0 mVrms，得到的增益为 0.040。

使用 Advisor（智能参数设定）子选项卡中的 Mode（模式）选择器，您可以定义 Advisor（智能参数设定）使用哪些反馈增益参数进行优化。例如，当您选择 PI 建议模式时，P 和 I 参数会发生变化，但 D 保持在当前设置的值。这样一来，您可以选择使用 Advisor（智能参数设定）的最有效方式：您可以让 Advisor（智能参数设定）完成所有工作、手动控制一些参数并让 Advisor（智能参数设定）处理其余部分，或者您手动完成所有调整并仅使用 Advisor（智能参数设定）来模拟结果。

我们将 D 参数保持在 0，让 Advisor（智能参数设定）在 PI 模式下运行。输入 1 kHz 的目标带宽并单击 Advise 按钮。Advisor（智能参数设定）将给出 P 和 I 的一些建议值。BW（带宽）字段指示模拟回路的带宽，绿色灯表示达到或超过目标带宽。PM 字段显示相位裕度，绿色灯表示反馈回路稳定。

在给定的示例中，谐振器的带宽约为 140 Hz，因此基本可以达到 1 kHz 的目标带宽。但是，为了达到该值，可能需要调整相应的解调器滤波器带宽。它应该大于目标带宽，但不能过大，以免产生过多噪声。启用 Auto Bandwidth（自动带宽）（Demodulator Settings（解调器设置）中 Filter BW（滤波器带宽）字段旁边的复选框）时，PID Advisor（PID 智能参数设定）会选择合适的解调器带宽，稍后这些带宽将自动传输到解调器。

选项卡右侧的波特图对应于基于 P、I 和 D 增益值以及当前在 Advisor（智能参数设定）子选项卡中设置的 DUT 模型的模拟闭环频率响应。为了显示示例的模拟闭环阶跃响应，如图 3.39 所示，在 Display（显示）子选项卡中将 Display（显示）设置为 Step Response（阶跃响应）。

##### 注释

如果选择解调器测量值作为 PID 输入，Advisor（智能参数设定）将控制相应的解调器滤波器带宽，但不控制滤波器阶数。如果遇到振荡反馈问题，请记住低阶滤波器通常会让反馈回路行为更稳定，因为它们的延迟较小。

<div style="text-align: center;"><div style="text-align: center;">表 3.24. 设置：设置并运行 PID Advisor（PID 智能参数设定）</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>子选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID / PLL</td><td style='text-align: center; word-wrap: break-word;'>Advisor（智能参数设定）</td><td style='text-align: center; word-wrap: break-word;'>Advisor（智能参数设定）</td><td style='text-align: center; word-wrap: break-word;'>3</td><td style='text-align: center; word-wrap: break-word;'>Target BW（目标带宽）(Hz)</td><td style='text-align: center; word-wrap: break-word;'>1 k</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID / PLL</td><td style='text-align: center; word-wrap: break-word;'>Advisor（智能参数设定）</td><td style='text-align: center; word-wrap: break-word;'>Advisor（智能参数设定）</td><td style='text-align: center; word-wrap: break-word;'>3</td><td style='text-align: center; word-wrap: break-word;'>Advise Mode（建议模式）</td><td style='text-align: center; word-wrap: break-word;'>PI</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID / PLL</td><td style='text-align: center; word-wrap: break-word;'>Advisor（智能参数设定）</td><td style='text-align: center; word-wrap: break-word;'>Demodulator Settings（解调器设置）</td><td style='text-align: center; word-wrap: break-word;'>3</td><td style='text-align: center; word-wrap: break-word;'>Filter BW / Auto Bandwidth（滤波器带宽/自动带宽）</td><td style='text-align: center; word-wrap: break-word;'>ON（打开）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID / PLL</td><td style='text-align: center; word-wrap: break-word;'>Advisor（智能参数设定）</td><td style='text-align: center; word-wrap: break-word;'>DUT Model（DUT模型）</td><td style='text-align: center; word-wrap: break-word;'>3</td><td style='text-align: center; word-wrap: break-word;'>DUT Model（DUT模型）</td><td style='text-align: center; word-wrap: break-word;'>Resonator Amplitude（谐振器幅值）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID / PLL</td><td style='text-align: center; word-wrap: break-word;'>Advisor（智能参数设定）</td><td style='text-align: center; word-wrap: break-word;'>DUT Model（DUT模型）</td><td style='text-align: center; word-wrap: break-word;'>3</td><td style='text-align: center; word-wrap: break-word;'>Delay（延迟）</td><td style='text-align: center; word-wrap: break-word;'>0.0 s</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID / PLL</td><td style='text-align: center; word-wrap: break-word;'>Advisor（智能参数设定）</td><td style='text-align: center; word-wrap: break-word;'>DUT Model（DUT模型）</td><td style='text-align: center; word-wrap: break-word;'>3</td><td style='text-align: center; word-wrap: break-word;'>Gain（增益）</td><td style='text-align: center; word-wrap: break-word;'>0.040</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID / PLL</td><td style='text-align: center; word-wrap: break-word;'>Advisor（智能参数设定）</td><td style='text-align: center; word-wrap: break-word;'>DUT Model（DUT模型）</td><td style='text-align: center; word-wrap: break-word;'>3</td><td style='text-align: center; word-wrap: break-word;'>Center Frequency（中心频率）</td><td style='text-align: center; word-wrap: break-word;'>1.8 M</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID / PLL</td><td style='text-align: center; word-wrap: break-word;'>Advisor（智能参数设定）</td><td style='text-align: center; word-wrap: break-word;'>DUT Model（DUT模型）</td><td style='text-align: center; word-wrap: break-word;'>3</td><td style='text-align: center; word-wrap: break-word;'>Q</td><td style='text-align: center; word-wrap: break-word;'>12.8 k</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID / PLL</td><td style='text-align: center; word-wrap: break-word;'>Display（显示）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>3</td><td style='text-align: center; word-wrap: break-word;'>Display（显示）</td><td style='text-align: center; word-wrap: break-word;'>Step Response（阶跃响应）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID / PLL</td><td style='text-align: center; word-wrap: break-word;'>Advisor（智能参数设定）</td><td style='text-align: center; word-wrap: break-word;'>Advisor（智能参数设定）</td><td style='text-align: center; word-wrap: break-word;'>3</td><td style='text-align: center; word-wrap: break-word;'>Advise（建议）</td><td style='text-align: center; word-wrap: break-word;'>ON（打开）</td></tr></table>

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//24efe8ed-6983-4ecc-8a07-623f12340510/markdown_2/imgs/img_in_image_box_215_116_283_181.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A18Z%2F-1%2F%2F6b3b8d94cf44d533b89d3b248a8eff96b61b98e32f700d43f5fa3071770d61c0" alt="Image" width="5%" /></div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//24efe8ed-6983-4ecc-8a07-623f12340510/markdown_2/imgs/img_in_chart_box_250_202_1079_792.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A18Z%2F-1%2F%2Fdf38eaef603b24bfc9ea5c9ef56fa51354a41cf361a73d80d2369a76c86a0ecc" alt="Image" width="69%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.39. 使用 PID Advisor（PID 智能参数设定）模拟的闭环阶跃响应</div> </div>


#### 3.8.5. 测量阶跃响应

一旦 Advisor（智能参数设定）的结果达到您的要求，单击 To PID 按钮将反馈增益参数传输到左侧显示的物理 PID / PLL 控制器。启用 PID / PLL 控制器，并按照第 4.6 节的说明来检查解调器 1 R 是否已稳定在 10 mV 的设定值。接着可以立即在 Plotter（绘图仪）中看到这样一个步骤，即在 PID / PLL 选项卡中切换设定值。要捕捉阶跃响应，建议您按照第 4.8 节的说明来操作。打开 DAQ 选项卡并根据下表在 Settings（设置）和 Grid（网格）子选项卡中配置触发。设置：设置 Data Acquisition（数据采集）工具

<div style="text-align: center;"><div style="text-align: center;">表 3.25. 设置：设置 Data Acquisition（数据采集）工具</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>子选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DAQ</td><td style='text-align: center; word-wrap: break-word;'>Settings（设置）</td><td style='text-align: center; word-wrap: break-word;'>Trigger Settings（触发设置）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Trigger Signal（触发信号）</td><td style='text-align: center; word-wrap: break-word;'>Demod 1 R（解调器 1 R）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DAQ</td><td style='text-align: center; word-wrap: break-word;'>Settings（设置）</td><td style='text-align: center; word-wrap: break-word;'>Trigger Settings（触发设置）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Level（电平）(V)</td><td style='text-align: center; word-wrap: break-word;'>11 m</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DAQ</td><td style='text-align: center; word-wrap: break-word;'>Settings（设置）</td><td style='text-align: center; word-wrap: break-word;'>Trigger Settings（触发设置）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Hysteresis（滞后）(V)</td><td style='text-align: center; word-wrap: break-word;'>0</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DAQ</td><td style='text-align: center; word-wrap: break-word;'>Settings（设置）</td><td style='text-align: center; word-wrap: break-word;'>Horizontal（水平）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Delay（延迟）(s)</td><td style='text-align: center; word-wrap: break-word;'>-1 m</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DAQ</td><td style='text-align: center; word-wrap: break-word;'>Grid（网格）</td><td style='text-align: center; word-wrap: break-word;'>Grid Settings（网格设置）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Mode（模式）</td><td style='text-align: center; word-wrap: break-word;'>Linear（线性）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DAQ</td><td style='text-align: center; word-wrap: break-word;'>Grid（网格）</td><td style='text-align: center; word-wrap: break-word;'>Grid Settings（网格设置）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Duration（持续时间）(s)</td><td style='text-align: center; word-wrap: break-word;'>5 m</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>All（全部）</td><td style='text-align: center; word-wrap: break-word;'>Data Transfer（数据传输）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Rate (Hz) / Enable（速率 (Hz) / 启用）</td><td style='text-align: center; word-wrap: break-word;'>100 k / ON（100 k / 打开）</td></tr></table>





我们还提高了解调器数据传输速率，以确保此测量的高时间分辨率。通过单击 Run/Stop 启动 Data Acquisition（数据采集）工具，只要您切换 Trigger Level（触发电平）的设定值（例如从 10 mV 到 12 mV），一条迹线就会被记录下来并显示在 DAQ 选项卡中，如下图所示。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//24efe8ed-6983-4ecc-8a07-623f12340510/markdown_3/imgs/img_in_image_box_218_384_288_452.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A19Z%2F-1%2F%2F938fc93e9883592389a7a8ea765b728f65e461084d3c2ca9311fe0a5042f047f" alt="Image" width="5%" /></div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//24efe8ed-6983-4ecc-8a07-623f12340510/markdown_3/imgs/img_in_chart_box_238_473_1061_938.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A19Z%2F-1%2F%2F02746681e9d576373c11c3ea00f1a5de91077a9a18570a911018c4bf0ef9b6e9" alt="Image" width="69%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.40. 使用 Data Acquisition（数据采集）工具测量的闭环阶跃响应</div> </div>


时间 (ms)

将图 3.40 与图 3.39 进行比较后可以发现，模拟和测量之间定量匹配得非常好。

### 3.9. 成像

注释

本教程适用于所有 MF 仪器。

#### 3.9.1. 目标和要求

本教程介绍了如何捕获和显示成像信号，即可以构建出二维数据集的线和帧结构的信号。要学习本教程，需要用到第三方可编程任意波形发生器来生成提供线触发的真实成像信号，或访问包括线触发或EOL触发在内的真实成像信号，例如来自原子力显微镜的信号。

#### 3.9.2. 准备

连接电缆，如下图所示。确保 MF 仪器已通电，然后通过 USB 将 MF 仪器连接到主机或通过以太网连接到主机所在的局域网 (LAN)。LabOne 启动后，打开带有 LabOne 图形用户界面的默认的 Web 浏览器。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//24efe8ed-6983-4ecc-8a07-623f12340510/markdown_4/imgs/img_in_image_box_215_690_1055_948.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A20Z%2F-1%2F%2F0da868b2e6a961ec3a0b4fa43ca11e4c7f05ba041a618616a5ae1d462ac50e1d" alt="Image" width="70%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.41.MF 仪器成像教程的设置</div> </div>


本教程可以使用默认仪器配置（例如，重启后）和默认用户界面设置（例如，在浏览器中按 F5 键后）启动。

#### 3.9.3. 成像信号属性

在本节中，我们将讨论本教程中使用的外部信号的属性。为了更好的说明，我们在解释成像功能时是基于任意波形发生器 (AWG) 生成的真实信号或是真实成像信号。也可以在没有外部设备的情况下使用该仪器的成像功能，但仅使用 MF 仪器不易生成结构良好的成像信号。为了促进 AWG 和锁定之间的锁相，建议使用具有数字调制能力并且可以将相位参考信号与 AWG 信号分开输出的 AWG，例如来自 Zurich Instruments 的 UHFAWG 和 HDAWG。

我们将假设以下扫描参数：线扫描频率约为 200 Hz，线数为 256。然后进一步假设 AWG 信号输出上的成像信号是 300 kHz 固定载波频率的调幅信号。该信号连接到 MF 仪器的 Signal Input +V 连接器。载波相位参考是一个 300 kHz 的方波，幅值约为 1 Vpk，在 AWG 标记输出 1 上生成，并连接到锁相参考输入 Aux In 1。在每条线的开头，AWG 会生成 TTL 信号的上升沿，该信号是在其标记输出 2 上生成的。该线触发信号连接到 MF 仪器的 Trigger In 1 连接器。正确触发数据采集所需的最小触发信号宽度等于所使用的逆解调器采样率。原因是 Trigger In 1 连接器的状态与解调器数据一起传输到主机，这限制了时间分辨率，从而限制了最小触发脉冲宽度。

#### 3.9.4. 测量成像信号

在本例中，我们对 AWG 进行了编程，以生成幅值在 0 到约 0.6 V $ _{rms} $ 之间变化的信号，从而构建出 Zurich Instruments 标志的图像。我们让 AWG 连续运行，这意味着它将永久生成此信号、线触发和相位参考信号。在这里，我们将设置具有足够高解调器带宽和采样率的锁相放大器，以便在外部参考模式下准确地测量成像信号。

为了锁定到外部参考锁相参考输入，我们需要选择参考输入信号并将锁相放大器更改为外部参考模式。您可以按第 4.13 节所述来检查相应的输入连接器是否显示切换信号。这可能需要调整输入的阈值电平以匹配 AWG 生成的 TTL 信号电平。第 3.2 节笼统介绍了在外部参考模式下设置测量。

<div style="text-align: center;"><div style="text-align: center;">表 3.26. 设置：启用外部参考模式</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>子选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>All（全部）</td><td style='text-align: center; word-wrap: break-word;'>Demodulators（解调器）</td><td style='text-align: center; word-wrap: break-word;'>2</td><td style='text-align: center; word-wrap: break-word;'>Signal（信号）</td><td style='text-align: center; word-wrap: break-word;'>Aux In 1（辅助输入 1）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>All（全部）</td><td style='text-align: center; word-wrap: break-word;'>Demodulators（解调器）</td><td style='text-align: center; word-wrap: break-word;'>2</td><td style='text-align: center; word-wrap: break-word;'>Mode（模式）</td><td style='text-align: center; word-wrap: break-word;'>ExtRef（外部参考）</td></tr></table>

我们选择解调器滤波器设置和足够高的采样率，以测量信号中高达数个 10 kHz 的快速分量。您可以在第 3.1 节中找到有关选择滤波器常数的大致说明。下表显示了要完成的设置。这里我们使用 200 kSa/s 的采样率，需要 1GbE 连接而不是 USB，因为前者的带宽更高。

<div style="text-align: center;"><div style="text-align: center;">表 3.27. 设置：配置解调器</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>子选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>All（全部）</td><td style='text-align: center; word-wrap: break-word;'>Signal Input（信号输入）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Range（范围）</td><td style='text-align: center; word-wrap: break-word;'>1.2 V</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>All（全部）</td><td style='text-align: center; word-wrap: break-word;'>Low-Pass Filters（低通滤波器）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>BW 3 dB（带宽3 dB）</td><td style='text-align: center; word-wrap: break-word;'>30 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>All（全部）</td><td style='text-align: center; word-wrap: break-word;'>Low-Pass Filters（低通滤波器）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Order（阶数）</td><td style='text-align: center; word-wrap: break-word;'>8</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>All（全部）</td><td style='text-align: center; word-wrap: break-word;'>Data Transfer（数据传输）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Rate（速率）</td><td style='text-align: center; word-wrap: break-word;'>220 kSa/s</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in（锁相）</td><td style='text-align: center; word-wrap: break-word;'>All（全部）</td><td style='text-align: center; word-wrap: break-word;'>Data Transfer（数据传输）</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Enable（启用）</td><td style='text-align: center; word-wrap: break-word;'>ON（打开）</td></tr></table>

现在我们可以按第 4.6 节所述来监控成像信号和线触发。打开 Plotter（绘图仪）选项卡并将解调器 R 信号以及 Trigger In 1（触发输入 1）添加到绘图中。

<div style="text-align: center;"><div style="text-align: center;">表 3.28. 设置：在 Plotter（绘图仪）中测量成像信号和线触发</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>子选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Plotter（绘图仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'>Vertical AxisGroups（垂直轴组）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Tree Selector（树状选择器）</td><td style='text-align: center; word-wrap: break-word;'>Demodulators/1/Sample/R（解调器/1/样本/R）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Plotter（绘图仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'>Vertical AxisGroups（垂直轴组）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Tree Selector（树状选择器）</td><td style='text-align: center; word-wrap: break-word;'>Demodulators/1/Sample/Trig In 1（解调器/1/样本/触发输入 1）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Plotter（绘图仪）</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Run/Stop（运行/停止）</td><td style='text-align: center; word-wrap: break-word;'>ON（打开）</td></tr></table>

Plotter（绘图仪）现在应该显示连续流传输的成像数据。下图中，蓝色为解调器 R 信号，绿色为线触发信号，表示每条线的开始。光标表明一个线重复周期大约为 1.66 ms，接下来我们想捕获完整的图像帧，而不是将这些数据以连续流的形式显示在 Plotter（绘图仪）中。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//bd5acc87-e2ee-4b9c-8247-3cf543132158/markdown_1/imgs/img_in_chart_box_236_217_1062_518.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A19Z%2F-1%2F%2F241a1734270b7a01bb52b9cb65de25a76354e78a45c08b4290f29d27c6dd9a3c" alt="Image" width="69%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.42.LabOne Plotter（绘图仪）中显示的成像信号（蓝色）和线触发（绿色）</div> </div>


#### 3.9.5. 设置网格模式

第 4.8 节中介绍的 Grid Mode（网格模式）工具适合用来捕捉图像。本节将介绍这个工具的配置。

网格模式下的 Data Acquisition（数据采集）工具采集提供预定义行和列的二维数据集，这些行和列由每条线的触发时间、明确规定的线数和线持续时间定义。获取的数据流可以线性内插到每条线明确规定数量的数据点（例如像素）中，也可以在精确模式下以解调器的传输速率精确获取。此外，它还支持多帧求平均值。

这里我们选择 Trigger In 1（触发输入 1）信号作为 Settings（设置）子选项卡中的触发源。我们将延迟时间设置为 0 s，以确保在连续线之间不会丢失触发信号。通过改变延迟，我们可以补偿触发时间和线首之间可能出现的偏差，或者为线尾触发而非线首触发配置 Data Acquisition（数据采集）工具。

在 Grid（网格）子选项卡中，我们选择了一些行与我们在 AWG 上编程的内容相对应。在 Exact（on-grid）（精确（按网格））模式下，我们选择的列数使得持续时间长到足以能捕捉一条线，但又比 1 个线触发周期短，因此 DAQ 工具可以针对每条新线重新激活。这里我们选择 N = 300 列，对应的持续时间为 T = 1.36 ms。这两个数字与解调器采样率  $ f_s = 220 \, \text{kSa/s} $ 相关，公式为  $ T = N / f_s $。

最后，我们在 Control（控制）子选项卡中选择 2D 显示，确保将解调器 1 R 作为显示信号添加到垂直轴组部分。DAQ 选项卡还支持多通道采集，原因是可以记录相位或其他解调器等更多信号。下表总结了这些设置。

<div style="text-align: center;"><div style="text-align: center;">表 3.29. 设置：设置网格模式</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选项卡</td><td style='text-align: center; word-wrap: break-word;'>子选项卡</td><td style='text-align: center; word-wrap: break-word;'>部分</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>设置/值/状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DAQ</td><td style='text-align: center; word-wrap: break-word;'>Settings（设置）</td><td style='text-align: center; word-wrap: break-word;'>Trigger Settings（触发设置）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Trigger Signal（触发信号）</td><td style='text-align: center; word-wrap: break-word;'>Demod 1 Trig In 1（解调器 1 触发输入 1）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DAQ</td><td style='text-align: center; word-wrap: break-word;'>Settings（设置）</td><td style='text-align: center; word-wrap: break-word;'>Horizontal（水平）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Hold Off Time（延迟时间）(s)</td><td style='text-align: center; word-wrap: break-word;'>0 s</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DAQ</td><td style='text-align: center; word-wrap: break-word;'>Settings（设置）</td><td style='text-align: center; word-wrap: break-word;'>Horizontal（水平）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Delay（延迟）</td><td style='text-align: center; word-wrap: break-word;'>0 s</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DAQ</td><td style='text-align: center; word-wrap: break-word;'>Grid（网格）</td><td style='text-align: center; word-wrap: break-word;'>Grid Settings（网格设置）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Mode（模式）</td><td style='text-align: center; word-wrap: break-word;'>Exact (on-grid)（精确（按网格））</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DAQ</td><td style='text-align: center; word-wrap: break-word;'>Grid（网格）</td><td style='text-align: center; word-wrap: break-word;'>Grid Settings（网格设置）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Columns（列数）</td><td style='text-align: center; word-wrap: break-word;'>300</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DAQ</td><td style='text-align: center; word-wrap: break-word;'>Grid（网格）</td><td style='text-align: center; word-wrap: break-word;'>Grid Settings（网格设置）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Duration（持续时间）</td><td style='text-align: center; word-wrap: break-word;'>1.36 ms（在 Exact（精确）模式下只读）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DAQ</td><td style='text-align: center; word-wrap: break-word;'>Grid（网格）</td><td style='text-align: center; word-wrap: break-word;'>Grid Settings（网格设置）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Rows（行数）</td><td style='text-align: center; word-wrap: break-word;'>256</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DAQ</td><td style='text-align: center; word-wrap: break-word;'>Control（控制）</td><td style='text-align: center; word-wrap: break-word;'>Time Domain（时域）</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Plot Type（绘图类型）</td><td style='text-align: center; word-wrap: break-word;'>2D</td></tr></table>





为捕捉一个新的帧，我们立刻禁用 AWG。通过单击 Single 启用 Data Acquisition（数据采集）工具，以捕捉具有之前规定好具体行数的一个单帧，然后再重启 AWG。下图显示了捕捉到的图像。获取的数据在 History（历史记录）子选项卡中显示为一个条目，可从那里轻松保存下来。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//bd5acc87-e2ee-4b9c-8247-3cf543132158/markdown_2/imgs/img_in_image_box_221_399_292_468.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A20Z%2F-1%2F%2F8250002fe776747b38928b618ae063e68a1976fdd472f230c61c266142fa3525" alt="Image" width="5%" /></div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//bd5acc87-e2ee-4b9c-8247-3cf543132158/markdown_2/imgs/img_in_chart_box_226_488_1066_901.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A20Z%2F-1%2F%2F7d639c0b04bcf3b4f534e04f7b4d7aeea2b47e88abc0f47c63be230fb914cbcc" alt="Image" width="70%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 3.43.Grid（网格）模式下 LabOne Data Acquisition（数据采集）工具捕捉到的 2D 图像</div> </div>


### 第 4 章.LabOne 用户界面的功能描述

本章详细介绍了 Zurich Instruments MFLI 的 LabOne 用户界面 (UI) 中可用的功能。LabOne 中有一个数据服务器和一个 Web 服务器，支持通过任何最常见的 Web 浏览器（例如 Firefox、Chrome、Edge 等）来控制仪器。这种独立于平台的架构支持各种设备（PC、平板电脑、智能手机等）与仪器之间的交互，即便必要时这些设备一起使用也可以。

除了获取和保存数据点等标准功能外，这个 UI 还提供各种测量工具，用于测量数据的时域和频域分析，以及便捷的伺服回路操作。

### 4.1. 用户界面概述

#### 4.1.1. UI 命名法

本节概述了 LabOne 用户界面及其主要元素和命名约定。LabOne 用户界面是一个基于浏览器的 UI，是 MFLI 仪器的主界面。支持多个浏览器会话同时访问仪器，也支持在多个计算机屏幕上显示。与 UI 一样，仪器可由自定义程序来控制和读取，这些程序由各种受支持的语言（例如 LabVIEW、MATLAB、Python、C）编写，并通过 LabOne API 连接。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//bd5acc87-e2ee-4b9c-8247-3cf543132158/markdown_4/imgs/img_in_image_box_224_381_1062_1003.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A21Z%2F-1%2F%2Fac7d73712892f13e6c965cf587840581f83a3396c7678db90da5673e06ec7d5c" alt="Image" width="70%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.1.LabOne 用户界面（默认视图）</div> </div>


启动新的 UI 会话后，图 4.1[LabOne 用户界面]会默认自动打开一些选项卡。UI 被默认分成两个选项卡行，每行均包含一个选项卡结构，可以访问不同的 LabOne 工具。根据显示大小和应用，可使用每个选项卡栏右侧的控件元素自由添加和删除选项卡行。同样，也可以从左侧的侧边栏中选择应用图标来删除或添加单个选项卡。单击图标将相应的选项卡添加到屏幕中，也可以将图标拖放到其中一个选项卡行中。此外，还可以通过行内或行间拖放操作来替换选项卡。

表 4.1 简单介绍了最重要的 UI 项及其命名约定。

<div style="text-align: center;"><div style="text-align: center;">表 4.1. LabOne 用户界面功能</div> </div>




<table border="1" style="margin: auto; word-wrap: break-word;"><tr><td style="text-align: center; word-wrap: break-word;">项目名称</td><td style="text-align: center; word-wrap: break-word;">位置</td><td style="text-align: center; word-wrap: break-word;">描述</td><td style="text-align: center; word-wrap: break-word;">组成</td></tr><tr><td style="text-align: center; word-wrap: break-word;">侧边栏</td><td style="text-align: center; word-wrap: break-word;">UI 的左侧</td><td style="text-align: center; word-wrap: break-word;">包含每个可用选项卡的应用图标 - 单击图标可添加或激活活动选项卡</td><td style="text-align: center; word-wrap: break-word;">应用图标</td></tr><tr><td rowspan="2">状态栏</td><td rowspan="2">UI 的底部</td><td style="text-align: center; word-wrap: break-word;">生活中的相应选项卡</td><td rowspan="2">状态指示灯</td></tr><tr><td style="text-align: center; word-wrap: break-word;">包含重要的状态指示灯、警告灯、设备和会</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">话信息和命令日志访问入口。</td><td style="text-align: center; word-wrap: break-word;"></td></tr><tr><td style="text-align: center; word-wrap: break-word;">主要区域</td><td style="text-align: center; word-wrap: break-word;">UI 的中间</td><td style="text-align: center; word-wrap: break-word;">包含所有活动选项卡 - 使用每个选项卡行右上角的控件元素可添加或删除新的行</td><td style="text-align: center; word-wrap: break-word;">选项卡行，每个选项卡行都由选项卡栏和活动选项卡区域组成</td></tr><tr><td style="text-align: center; word-wrap: break-word;">选项卡区域</td><td style="text-align: center; word-wrap: break-word;">每个选项卡的内部</td><td style="text-align: center; word-wrap: break-word;">包含每个选项卡的活动部分，包括设置、控件和测量工具</td><td style="text-align: center; word-wrap: break-word;">部分、绘图、子选项卡、单元选择</td></tr></table>




其他项目在图 4.2 中标记出来了。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//c16947ce-e5cf-4be2-8b33-041dfb8cdbb1/markdown_0/imgs/img_in_image_box_224_418_1074_1023.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A04Z%2F-1%2F%2F4a803acf9e826ea8140eec058da93d93326a03141f4f3528bf16e1cdfb446895" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.2.LabOne 用户界面（其余项目）</div> </div>


#### 4.1.2. 独特的分析工具集

所有仪器都提供能对原始信号和解调信号进行时域和频域分析的综合工具集。

UI 左侧的应用图标大致可分成两类：设置和工具。

设置有关的选项卡与仪器硬件直接连接，这样用户就可以控制所有的设置和仪器状态。

工具有关的选项卡主要用来显示和分析收集到的测量数据。

设置选项卡和工具选项卡之间没有严格的区分，例如 Sweeper（参数扫描仪）选项卡既可以改变一些解调器设置，也可以执行频率扫描。在这些工具中，通常可以进一步区分时域和频域分析工具。此外，快速输入信号的分析（典型采样率为 60 Msa/s）与较慢数据的数量级测量（典型采样率 <200 kSa/s）之间的区别，就可能源自解调器输出和辅助输入。表 4.2 对这些工具进行了简单的划分。

<div style="text-align: center;"><div style="text-align: center;">表 4.2. 时域和频域分析工具</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>时域</td><td style='text-align: center; word-wrap: break-word;'>频域</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>快速信号 (60 MSa/s)</td><td style='text-align: center; word-wrap: break-word;'>Oscilloscope（示波器）（Scope（示波器）选项卡）</td><td style='text-align: center; word-wrap: break-word;'>FFT Analyzer（FFT 分析仪）（Scope（示波器）选项卡）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>时域</td><td style='text-align: center; word-wrap: break-word;'>频域</td></tr><tr><td rowspan="3">慢速信号 (&lt;200 kSa/s)</td><td style='text-align: center; word-wrap: break-word;'>Numeric（数值）</td><td style='text-align: center; word-wrap: break-word;'>Spectrum Analyzer（频谱分析仪）（Spectrum（频谱）选项卡）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Plotter（绘图仪）</td><td style='text-align: center; word-wrap: break-word;'>Sweeper（参数扫描仪）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Data Acquisition（数据采集）</td><td style='text-align: center; word-wrap: break-word;'>-</td></tr></table>

下表概述了所有应用图标。请注意，应用图标的选择可能取决于给定仪器上安装的升级选件。

<div style="text-align: center;"><div style="text-align: center;">表 4.3. 应用图标和简要描述概览</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in</td><td style='text-align: center; word-wrap: break-word;'>☒</td><td style='text-align: center; word-wrap: break-word;'>快速纵览和访问关于信号生成及解调的所有设置和属性。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in MD</td><td style='text-align: center; word-wrap: break-word;'>☒</td><td style='text-align: center; word-wrap: break-word;'>快速纵览和访问关于信号生成及解调的所有设置和属性。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Files</td><td style='text-align: center; word-wrap: break-word;'>☐</td><td style='text-align: center; word-wrap: break-word;'>访问内部闪存和 U 盘上的文件。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Numeric</td><td style='text-align: center; word-wrap: break-word;'>0058</td><td style='text-align: center; word-wrap: break-word;'>访问所有连续流传输的测量数据（数值形式）。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Plotter</td><td style='text-align: center; word-wrap: break-word;'>☐</td><td style='text-align: center; word-wrap: break-word;'>以迹线形式显示一段时间内的各种连续流传输的测量数据（滚动模式）。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Scope</td><td style='text-align: center; word-wrap: break-word;'>☑</td><td style='text-align: center; word-wrap: break-word;'>显示时域图和频域图 (FFT) 中的数据样本截图。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DAQ</td><td style='text-align: center; word-wrap: break-word;'>☑</td><td style='text-align: center; word-wrap: break-word;'>为所有连续流传输的测量数据样本和时域显示提供复杂的触发功能。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Spectrum</td><td style='text-align: center; word-wrap: break-word;'>☒</td><td style='text-align: center; word-wrap: break-word;'>为所有连续流传输的测量数据提供 FFT 功能。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper</td><td style='text-align: center; word-wrap: break-word;'>☑</td><td style='text-align: center; word-wrap: break-word;'>扫描规定范围内的频率、电压及其他物理量，并显示包括统计运算在内的各种响应函数。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Aux</td><td style='text-align: center; word-wrap: break-word;'>☑</td><td style='text-align: center; word-wrap: break-word;'>控制与辅助输入和辅助输出有关的所有设置。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>In/Out</td><td style='text-align: center; word-wrap: break-word;'>☑</td><td style='text-align: center; word-wrap: break-word;'>允许访问仪器前面板上与信号输入和信号输出相关的所有控件。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DIO</td><td style='text-align: center; word-wrap: break-word;'>☒</td><td style='text-align: center; word-wrap: break-word;'>允许访问与数字输入和输出相关的所有控件，包括 Ref/Trigger 连接器。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Config</td><td style='text-align: center; word-wrap: break-word;'>☒</td><td style='text-align: center; word-wrap: break-word;'>提供对于软件配置的访问权限。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Device</td><td style='text-align: center; word-wrap: break-word;'>☑</td><td style='text-align: center; word-wrap: break-word;'>提供特定于仪器的设置。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID</td><td style='text-align: center; word-wrap: break-word;'>☑</td><td style='text-align: center; word-wrap: break-word;'>具有 PID 控制器的所有控制、分析和模拟功能。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>MOD</td><td style='text-align: center; word-wrap: break-word;'>☑</td><td style='text-align: center; word-wrap: break-word;'>以振荡器频率的线性组合启用调制/解调的控制面板。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>IA</td><td style='text-align: center; word-wrap: break-word;'>☑</td><td style='text-align: center; word-wrap: break-word;'>快速纵览和访问关于阻抗测量的所有设置和属性。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>MDS</td><td style='text-align: center; word-wrap: break-word;'>☑</td><td style='text-align: center; word-wrap: break-word;'>同步多个仪器。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>ZI Labs</td><td style='text-align: center; word-wrap: break-word;'>☑</td><td style='text-align: center; word-wrap: break-word;'>实验性设置及控件。</td></tr></table>

表 4.4 大致概述了不同的状态栏元素，并作了简要描述。

<div style="text-align: center;"><div style="text-align: center;">表 4.4. 状态栏描述</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Shutdown</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>关闭仪器。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>IA</td><td style='text-align: center; word-wrap: break-word;'>灰色/绿色</td><td style='text-align: center; word-wrap: break-word;'>阻抗分析仪 - 绿色：指示启用哪个阻抗分析仪模块。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>OVI</td><td style='text-align: center; word-wrap: break-word;'>灰色/黄色/红色</td><td style='text-align: center; word-wrap: break-word;'>信号输入过载 - 红色：表示信号输入发生过载，前面板上的红色 LED 也会显示过载情况。黄色：表示过去曾发生过载。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>OVO</td><td style='text-align: center; word-wrap: break-word;'>灰色/黄色/红色</td><td style='text-align: center; word-wrap: break-word;'>过载信号输出 - 红色：表示信号输出发生过载。黄色：表示过去曾发生过载。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>COM</td><td style='text-align: center; word-wrap: break-word;'>灰色/红色</td><td style='text-align: center; word-wrap: break-word;'>停止 - 红色：表示样本传输速率已复位为默认值，以防止出现严重的通信故障。这通常是由于主机速度慢，但样本传输速率高所导致。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>MOD</td><td style='text-align: center; word-wrap: break-word;'>灰色/绿色</td><td style='text-align: center; word-wrap: break-word;'>MOD - 绿色：指示启用哪个调制工具包。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID</td><td style='text-align: center; word-wrap: break-word;'>灰色/绿色</td><td style='text-align: center; word-wrap: break-word;'>PID - 绿色：指示启用哪个 PID 单元。红色：指示 PID 单元处于 PLL 或 ExtRef 模式但未锁定。黄色：指示过去未锁定 PID 单元。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PLL</td><td style='text-align: center; word-wrap: break-word;'>灰色/绿色</td><td style='text-align: center; word-wrap: break-word;'>PLL - 绿色：指示启用哪个 PLL。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Command log</td><td style='text-align: center; word-wrap: break-word;'>最后一条命令</td><td style='text-align: center; word-wrap: break-word;'>显示最后一条命令。可以在 config（配置）选项卡中设置不同的格式（Matlab、Python 等）。该日志还保存在 [User]\Documents\Zurich Instruments\LabOne\WebServer\Log 中</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Show Log</td><td style='text-align: center; word-wrap: break-word;'>☑</td><td style='text-align: center; word-wrap: break-word;'>在单独的浏览器窗口中显示命令日志历史记录。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Errors</td><td style='text-align: center; word-wrap: break-word;'>错误</td><td style='text-align: center; word-wrap: break-word;'>在单独的浏览器选项卡中显示系统错误。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Device</td><td style='text-align: center; word-wrap: break-word;'>devXXX</td><td style='text-align: center; word-wrap: break-word;'>指示设备序列号。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Identify Device</td><td style='text-align: center; word-wrap: break-word;'>☑</td><td style='text-align: center; word-wrap: break-word;'>激活时，设备 LED 灯闪烁</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>MDS</td><td style='text-align: center; word-wrap: break-word;'>灰色/绿色/红色/黄色</td><td style='text-align: center; word-wrap: break-word;'>多设备同步指示器。灰色：无需同步 - UI 上只有一个设备。绿色：UI 上的所有设备均已正确同步。黄色：正在进行 MDS 同步，或者只同步所连设备的子集。红色：设备未同步或在 MDS 同步期间出错。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>REC</td><td style='text-align: center; word-wrap: break-word;'>灰色/红色</td><td style='text-align: center; word-wrap: break-word;'>指示灯呈红色表示正在进行数据记录（与 Config（配置）选项卡中的全局记录设置相关）。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>CF</td><td style='text-align: center; word-wrap: break-word;'>灰色/黄色/红色</td><td style='text-align: center; word-wrap: break-word;'>时钟故障 - 红色：表示外部 10 MHz 参考振荡器出现故障。黄色：表示过去曾发生故障。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>COM</td><td style='text-align: center; word-wrap: break-word;'>灰色/黄色/红色</td><td style='text-align: center; word-wrap: break-word;'>数据包丢失 - 红色：表示设备与主机 PC 之间存在数据丢失情况。黄色：表示过去曾发生数据丢失。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>COM</td><td style='text-align: center; word-wrap: break-word;'>灰色/黄色/红色</td><td style='text-align: center; word-wrap: break-word;'>样本丢失 - 红色：表示设备与主机 PC 之间存在样本数据丢失情况。黄色：表示过去曾发生样本数据丢失。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>C</td><td style='text-align: center; word-wrap: break-word;'>☑</td><td style='text-align: center; word-wrap: break-word;'>复位状态标志：清除状态标志的当前状态</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Full Screen</td><td style='text-align: center; word-wrap: break-word;'>☑</td><td style='text-align: center; word-wrap: break-word;'>切换浏览器的全屏模式和普通模式。</td></tr></table>

#### 4.1.3.绘图功能

一些工具以绘图的形式实现测量数据的图形显示。这些多功能工具具有缩放、平移和光标功能。本节介绍了一些主要工具。

##### 绘图区域元素

绘图包括绘图区域、X 范围和范围控件。X 范围（位于绘图区域上方）通过蓝色缩放区域指示器指示显示的是波的哪个部分。这两个范围显示了绘图的满量程，当绘图区域显示缩放视图时，该比例不会改变。但在使用缩放视图时，绘图区域的两个轴会改变。

绘图内的鼠标功能极大地简化并加快了数据查看和导航。

<div style="text-align: center;"><div style="text-align: center;">表 4.5. 绘图内的鼠标功能</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>名称</td><td style='text-align: center; word-wrap: break-word;'>操作</td><td style='text-align: center; word-wrap: break-word;'>描述</td><td style='text-align: center; word-wrap: break-word;'>执行区域</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>平移</td><td style='text-align: center; word-wrap: break-word;'>在任何位置单击左键并四处移动</td><td style='text-align: center; word-wrap: break-word;'>移动波形</td><td style='text-align: center; word-wrap: break-word;'>绘图区域</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>缩放 X 轴</td><td style='text-align: center; word-wrap: break-word;'>鼠标滚轮</td><td style='text-align: center; word-wrap: break-word;'>放大和缩小 X 轴</td><td style='text-align: center; word-wrap: break-word;'>绘图区域</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>缩放 Y 轴</td><td style='text-align: center; word-wrap: break-word;'>Shift 键 + 鼠标滚轮</td><td style='text-align: center; word-wrap: break-word;'>放大和缩小 Y 轴</td><td style='text-align: center; word-wrap: break-word;'>绘图区域</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>视窗缩放</td><td style='text-align: center; word-wrap: break-word;'>Shift 键 + 鼠标左键进行区域选择</td><td style='text-align: center; word-wrap: break-word;'>选择要放大的波形区域</td><td style='text-align: center; word-wrap: break-word;'>绘图区域</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>缩放区域的绝对跳转</td><td style='text-align: center; word-wrap: break-word;'>单击鼠标左键</td><td style='text-align: center; word-wrap: break-word;'>移动蓝色缩放范围指示器</td><td style='text-align: center; word-wrap: break-word;'>X 和 Y 范围，但在蓝色缩放范围指示器之外</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>缩放区域的绝对移动</td><td style='text-align: center; word-wrap: break-word;'>鼠标左键拖放</td><td style='text-align: center; word-wrap: break-word;'>移动蓝色缩放范围指示器</td><td style='text-align: center; word-wrap: break-word;'>X 和 Y 范围，在蓝色范围指示器之内</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>满量程</td><td style='text-align: center; word-wrap: break-word;'>双击</td><td style='text-align: center; word-wrap: break-word;'>将 X 和 Y 轴设置为满量程</td><td style='text-align: center; word-wrap: break-word;'>绘图区域</td></tr></table>

每个绘图区域都包含一个图例，其中列出了以相应颜色显示的所有信号。图例可以通过拖放操作移动到任何所需的位置。

X 范围和 Y 范围绘图控件在表 4.6 中进行了说明。

##### 注释

LabOne 的 Net Link 功能可以很方便地将绘图数据导出到其他应用，例如 Excel 或 Matlab，有关详细信息，请参见 LabOne Net Link。

<div style="text-align: center;"><div style="text-align: center;">表 4.6. 绘图控件描述</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Axis scaling mode</td><td style='text-align: center; word-wrap: break-word;'>Auto FS Man Auto</td><td style='text-align: center; word-wrap: break-word;'>在自动、满量程和手动轴缩放之间进行选择。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Axis mapping mode</td><td style='text-align: center; word-wrap: break-word;'>Lin Lin Log dB</td><td style='text-align: center; word-wrap: break-word;'>在线性、对数和分贝轴映射之间选择。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Axis zoom in</td><td style='text-align: center; word-wrap: break-word;'><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//c16947ce-e5cf-4be2-8b33-041dfb8cdbb1/markdown_3/imgs/img_in_image_box_440_1015_472_1044.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A07Z%2F-1%2F%2F2fb844052c95099abbf806cfd8fa612bd96ff5b49945f332c1e699bd82180d37" alt="Image"" /></td><td style='text-align: center; word-wrap: break-word;'>将相应的轴放大为 2 倍。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Axis zoom out</td><td style='text-align: center; word-wrap: break-word;'><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//c16947ce-e5cf-4be2-8b33-041dfb8cdbb1/markdown_3/imgs/img_in_image_box_439_1050_472_1081.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A07Z%2F-1%2F%2Fc1defc020e64358a7199868cd583c3e7968c78a70e8f2a947e573e18a235b0b1" alt="Image"" /></td><td style='text-align: center; word-wrap: break-word;'>将相应的轴缩小为 1/2。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Rescale axis to data</td><td rowspan="2"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//c16947ce-e5cf-4be2-8b33-041dfb8cdbb1/markdown_3/imgs/img_in_image_box_438_1084_473_1146.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A07Z%2F-1%2F%2F04e07dc6016a9b196eb22f17913a5f1f1cc04d362da57e5023a51c9e95bf67c6" alt="Image"" /></td><td style='text-align: center; word-wrap: break-word;'>在所选缩放区域中重新缩放前景 Y 轴。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Save figure</td><td style='text-align: center; word-wrap: break-word;'>将绘图区域或双绘图区域的 PNG、JPG 或 SVG 生成到本地下载文件夹。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Save data</td><td style='text-align: center; word-wrap: break-word;'>图1</td><td style='text-align: center; word-wrap: break-word;'>生成由显示波或直方图数据组成的 CSV 文件（在启用直方图数学运算时）。选择满量程以保存完整波形。保存数据功能一次只保存一个截图（最后显示的波形）。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Cursor control</td><td style='text-align: center; word-wrap: break-word;'><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//c16947ce-e5cf-4be2-8b33-041dfb8cdbb1/markdown_3/imgs/img_in_image_box_439_1275_573_1315.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A07Z%2F-1%2F%2F105df4af9e3723b50d415269dddf8534964cfc9d951909a5806474f3e06d8c2f" alt="Image"" /></td><td style='text-align: center; word-wrap: break-word;'>可用于开启/关闭光标，以及将光标设置为单独移动或一起移动。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Net Link</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>提供 LabOne Net Link 以在 Excel、Matlab 等工具中使用显示的波形数据。</td></tr></table>

##### 光标和数学

绘图区域提供两个 X 光标和两个 Y 光标，它们在绘图区域内显示为虚线。拖放蓝色手柄即可选择和移动四个光标。每个轴都有一个表示其绝对位置的主光标和一个表示相对于主光标的绝对位置和相对位置的辅助光标。

光标存在绝对位置，该位置在平移或缩放事件中不会改变。如果光标位置移出绘图区域，则在绘图区域的边缘会显示相应的手柄。只要不移动手柄，光标就停在当前位置。此功能非常适用于确保大增量测量的高精度（因为其他光标的绝对位置不会移动）。

光标数据还可用于定义对绘制数据执行的数学运算的输入数据。每个工具的 Math（数学）子选项卡均提供此功能。表 4.7 概述了所有元素及其功能。所选的信号和操作仅应用于当前活动的迹线。

##### 注释

LabOne 的 Net Link 功能可以很方便地将光标数据导出到其他应用，例如 Excel 或 MATLAB，有关详细信息，请参见 LabOne Net Link。

<div style="text-align: center;"><div style="text-align: center;">表 4.7. 绘图数学描述</div> </div>




<table border="1" style="margin: auto; word-wrap: break-word;"><tr><td style="text-align: center; word-wrap: break-word;">控件/工具</td><td style="text-align: center; word-wrap: break-word;">选项/范围</td><td style="text-align: center; word-wrap: break-word;">描述</td></tr><tr><td rowspan="10">Source Select</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">从输入源列表中选择数学运算的输入。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Cursor Loc</td><td style="text-align: center; word-wrap: break-word;">将光标坐标作为输入数据。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Cursor Area</td><td style="text-align: center; word-wrap: break-word;">将由光标位置定义的矩形内活动迹线的所有数据视为统计函数（Min、Max、Avg、Std）的输入。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Tracking</td><td style="text-align: center; word-wrap: break-word;">在水平轴光标 X1 或 X2 的位置显示活动迹线的值。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Plot Area</td><td style="text-align: center; word-wrap: break-word;">将当前显示在绘图中的活动迹线的所有数据视为统计函数（Min、Max、Avg、Std）的输入。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Peak</td><td style="text-align: center; word-wrap: break-word;">查找数据中最多 5 个峰值的位置和电平。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Trough</td><td style="text-align: center; word-wrap: break-word;">查找数据中最多 5 个谷值的位置和电平。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Histogram</td><td style="text-align: center; word-wrap: break-word;">显示 x 轴范围内活动迹线数据的直方图。使用直方图作为统计函数（Avg、Std）的输入。由于数据分箱处理，统计函数所产生的结果通常不同于 Plot Area（绘图区域）选择下的结果。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Resonance</td><td style="text-align: center; word-wrap: break-word;">显示谐振频率的拟合曲线。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Linear Fit</td><td style="text-align: center; word-wrap: break-word;">显示线性回归曲线。</td></tr><tr><td rowspan="7">Operation Select</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">从数学运算列表中选择要对所选源执行的运算。列表选项取决于所选的源。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Cursor Loc: X1、X2、X2-X1、Y1、Y2、Y2-Y1、Y2/Y1</td><td style="text-align: center; word-wrap: break-word;">光标的位置、差值和比值。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Cursor Area: Min、Max、Avg、Std</td><td style="text-align: center; word-wrap: break-word;">光标 X1 和 X2 之间所有样本的最小值、最大值、平均值和偏置校正样本标准差。所有样本值也会一并显示在绘图中。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Tracking: Y(X1)、Y(X2)、ratioY、deltaY</td><td style="text-align: center; word-wrap: break-word;">光标位置 X1 和 X2 处的跟踪值，以及这两个 Y 值的比值和差值。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Plot Area: Min、Max、Pk Pk、Avg、Std</td><td style="text-align: center; word-wrap: break-word;">X 轴范围内所有样本的最小值、最大值、最大值与最小值之差、平均值以及偏置校正样本标准差。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Peak: Pos、Level</td><td style="text-align: center; word-wrap: break-word;">峰值（从最高峰值开始）的位置和电平。这些值也显示在绘图中以标识峰值。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Histogram: Avg、Std、Bin Size，（仅限 Plotter（绘图仪）选项卡：SNR、Norm Fit、Rice Fit）</td><td style="text-align: center; word-wrap: break-word;">使用 x 轴范围内的所有样本生成直方图。bin 大小由屏幕分辨率给出：1 像素 = 1 bin。通过该直方图，可计算平均值和偏置校正样本标准差（基本上假设 bin 中的所有数据点都位于其各自 bin）</td></tr><tr><td rowspan="3"></td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">的中心）。当在 Plotter（绘图仪）选项卡中使用解调器或 boxcar 信号时，另外会出现 SNR 估计和将统计分布拟合到直方图（正态分布和莱斯分布）的选项。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Resonance: Q、BW、Center、Amp、Phase、Fit Error</td><td style="text-align: center; word-wrap: break-word;">曲线与谐振器拟合。拟合边界由两个光标 X1 和 X2 确定。根据迹线的类型（Demod R（解调器 R）或 Demod Phase（解调器相位）），利用洛伦兹函数或反正切函数拟合迹线。Q 是拟合曲线的品质因数。BW（带宽）是拟合曲线的 3dB 带宽（FWHM）。Center（中心）是中心频率。Amp（幅值）指定幅值（仅限 Demod R（解调器 R）），而 Phase（相位）返回谐振中心频率的相位（仅限 Demod Phase（解调器相位））。Fit Error（拟合错误）由归一化的均方根偏差指定。它按测量数据的范围归一化。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Linear Fit: Intercept、Slope、 $ R^{2} $</td><td style="text-align: center; word-wrap: break-word;">使用 QR 分解例程执行简单的线性最小二乘回归。拟合边界由两个光标 X1 和 X2 确定。参数输出是 Y 轴截距、斜率和  $ R^{2} $ 值， $ R^{2} $ 值是确定拟合优度的决定系数。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Add</td><td style="text-align: center; word-wrap: break-word;">Add</td><td style="text-align: center; word-wrap: break-word;">将选定的数学函数添加到下面的结果表中。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Add All</td><td style="text-align: center; word-wrap: break-word;">Add All</td><td style="text-align: center; word-wrap: break-word;">将所选信号的所有运算添加到下面的结果表中。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Clear Selected</td><td style="text-align: center; word-wrap: break-word;">Clear</td><td style="text-align: center; word-wrap: break-word;">清除上面结果表中的选定行。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Clear All</td><td style="text-align: center; word-wrap: break-word;">Clear All</td><td style="text-align: center; word-wrap: break-word;">清除上面结果表中的所有行。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Copy</td><td style="text-align: center; word-wrap: break-word;">Copy</td><td style="text-align: center; word-wrap: break-word;">将选定行以 CSV 格式复制到剪贴板中</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Unit Prefix</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">为 SI 单位添加合适的前缀，以提高可读性并增加显示的有效数字。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">CSV</td><td style="text-align: center; word-wrap: break-word;">CSV</td><td style="text-align: center; word-wrap: break-word;">当前结果表的值将以文本文件的形式保存到下载文件夹中。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Net Link</td><td style="text-align: center; word-wrap: break-word;">Link</td><td style="text-align: center; word-wrap: break-word;">提供 LabOne Net Link 以在 Excel、Matlab 等工具中使用数据。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Help</td><td style="text-align: center; word-wrap: break-word;">Help</td><td style="text-align: center; word-wrap: break-word;">打开 LabOne 用户界面帮助。</td></tr></table>




##### 注释

标准差是使用样本标准差的无偏置估计量的公式  $ \sqrt{\frac{1}{N-1}\sum_{i=1}^{N}(x_i - \bar{x})^2} $ 计算的，其中  $ X_i $ 为 N 样本总数， $ \bar{X} $ 为算术平均数。上述公式用于计算 Histogram Plot Math（直方图绘图数学）工具的标准差。如果是很多点（Cursor Area（光标区域）和 Plot Area（绘图区域）工具），应使用更准确的 Pairwise（两两组合）算法（Chan 等人，“计算样本方差的算法：分析和建议”，The American Statistician 37 (1983)，242-247）。

##### 注释

Resonance Plot Math（谐振绘图数学）工具中使用的拟合函数取决于所选的信号源。解调器 R 信号采用以下函数进行拟合：

 $$ R(f)=C+A\frac{f}{\sqrt{f^{2}+\left(\frac{Q}{f_{0}}\right)^{2}\left(f^{2}-f_{0}^{2}\right)^{2}}} $$ 

其中 C 表示输出中可能存在的偏移，A 是幅值，Q 是品质因数， $ f_{0} $ 是中心频率。解调器  $ \phi $ 信号采用以下函数进行拟合：

 $$ \phi(f)=tan^{-1}\left(Q\frac{1-\left(\frac{f}{f_{0}}\right)^{2}}{\frac{f}{f_{0}}}\right) $$ 

使用了与上面一样的参数。

##### Tree Selector（树状选择器）

使用 Tree Selector（树状选择器）即可通过选中应显示的信号方框来访问分层结构中的流传输测量数据。Tree Selector（树状选择器）还支持从多个仪器中选择数据（前提是有多个仪器）。根据工具的不同，Tree Selector（树状选择器）要么显示在单独的 Tree（树）子选项卡中，要么可以通过单击☑按钮来访问。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//855280b2-161d-4f0c-8a50-16822fc63744/markdown_1/imgs/img_in_image_box_215_823_493_1382.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A30Z%2F-1%2F%2F27df6a65fc98040084d28421da3dc8e32c8a468823c138b86264c40bde6d59f6" alt="Image" width="23%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.3. 提供 Display（显示）下拉菜单的 Tree Selector（树状选择器）</div> </div>


##### 垂直轴组

在许多 LabOne 工具中，垂直轴组可用作绘图功能的一部分。它们的作用是在同一绘图中处理具有不同轴属性的信号。单位不同的信号即使显示在同一绘图中，本身也具有独立的垂直尺度。然而，单位相同的信号最好使用一个尺度，以便进行定量比较。为此，信号被分配到特定的轴组。每个轴组都有自己的轴系。通过将一个或多个信号移动到一个新组中，可以更改此默认行为。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//855280b2-161d-4f0c-8a50-16822fc63744/markdown_2/imgs/img_in_image_box_250_298_1044_629.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A31Z%2F-1%2F%2F38d6d2aa1d7277380bb8a676b4ab581c861e16f7f7cd41fb6c024cbf71ef1164" alt="Image" width="66%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.4.Plotter（绘图仪）工具中的垂直轴组</div> </div>


一次只能显示一个轴组的刻度标签。这是前景轴组。要定义前景组，请单击垂直轴组方框中的一个组名称。当前的前景组使用的是对比明显的颜色。



<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>选择前景组</td><td style='text-align: center; word-wrap: break-word;'>单击垂直轴组内的信号名称或组名称。如果组为空，则不执行选择操作。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>拆分默认垂直轴组</td><td style='text-align: center; word-wrap: break-word;'>将信号拖放到字段*[Drop signal here to add a new group]（将信号拖放到此处以添加新组）。该信号现在将拥有自己的轴系。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>更改信号的垂直轴组</td><td style='text-align: center; word-wrap: break-word;'>通过拖放将信号从一组移动到单位相同的另一组。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>分组</td><td style='text-align: center; word-wrap: break-word;'>如果一个组承载多个信号并且其中一些信号的单位发生变化，则该组将根据不同的新单位分成几个组。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>删除组中的信号</td><td style='text-align: center; word-wrap: break-word;'>要删除组中的信号，可以将信号拖放到垂直轴组方框之外的位置。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>删除垂直轴组</td><td style='text-align: center; word-wrap: break-word;'>自定义组的最后一个信号被删除后，该组也将立即被删除。默认组将保持活动状态，直到通过拖放将其明确删除。如果添加了与组属性匹配的新信号，它将被再次添加到此默认组中。这可确保默认组的设置不会丢失，除非被明确删除。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>重命名垂直轴组</td><td style='text-align: center; word-wrap: break-word;'>新组的默认名称为“Group of ...”（……组）。可以通过双击组名称来更改此名称。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>隐藏/显示信号</td><td style='text-align: center; word-wrap: break-word;'>取消选中/选中信号的复选框。这比再次从树中获取信号要快。</td></tr></table>

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//855280b2-161d-4f0c-8a50-16822fc63744/markdown_3/imgs/img_in_image_box_216_103_1087_318.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A32Z%2F-1%2F%2F91b4e3cffff59c785260a63be45b846526ff91e1c7e3eac4f324071c681dfd3f" alt="Image" width="73%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.5. 垂直轴组典型的拖放动作。</div> </div>


<div style="text-align: center;"><div style="text-align: center;">表 4.8. 垂直轴组描述</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Vertical Axis Group</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>管理共享公共垂直轴的信号组。通过更改复选框状态来显示或隐藏信号。通过将信号拖放到字段 [将信号拖放到此处以添加新组] 可拆分组。通过将信号拖动到空闲区域可移除信号。通过编辑组标签可对组进行重命名。所选组的轴刻度标签显示在绘图中。活动波形（选定）的光标元素将添加到 Cursor Math（光标数学）选项卡中。</td></tr><tr><td rowspan="4">Signal Type</td><td style='text-align: center; word-wrap: break-word;'>Demod X、Y、R、Theta</td><td rowspan="4">选择垂直轴组的信号类型。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Frequency</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Aux Input 1、2</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>HW Trigger</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Channel</td><td style='text-align: center; word-wrap: break-word;'>整数值</td><td style='text-align: center; word-wrap: break-word;'>选择要添加的通道。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Add Signal</td><td style='text-align: center; word-wrap: break-word;'>Add Signal</td><td style='text-align: center; word-wrap: break-word;'>向绘图中添加信号。该信号将被添加到默认组中。可以通过拖放操作将该信号移至其所属的组中。组中的所有信号都共享一个公共的 y 轴。选择一个组以将其轴置于前景并显示其标签。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Window Length</td><td style='text-align: center; word-wrap: break-word;'>2 s 至 12 h</td><td style='text-align: center; word-wrap: break-word;'>窗口内存深度。如果数值大于 10 s，采样率较高的信号可能会占用过多的内存。自动缩放或平移会刷新显示，仅考虑所定义窗口长度内的数据。</td></tr></table>

##### Trends（趋势）

Trends（趋势）工具让用户可以监控信号特征随时间的演化，例如最小值和最大值，或平均值和标准差。此功能可用于 Scope（示波器）、Spectrum（频谱）、Plotter（绘图仪）和 DAQ 选项卡。通过 Trends（趋势）功能可以监控在相应选项卡的 110 中获得的所有参数。

Trends（趋势）工具让用户可以分析在不同的、可调整的时间尺度上记录的数据，这种时间尺度比快速采集测量信号的时间要长得多。它避免了对记录信号进行后期处理，从而节省了时间，而且由于它实时提取和显示测量结果，有利于对实验参数进行微调。

要激活趋势图，请启用相应主选项卡的 Control（控制）子选项卡中的 Trends（趋势）按钮。可以从“垂直轴组”部分的“Trends”（趋势）子选项卡中将各种信号特征添加到绘图中。Trends（趋势）的垂直轴组有自己的 Run/Stop（运行/停止）按钮和 Length（长度）设置，与选项卡的主绘图没有关联。由于 Math（数学）量来自主绘图中的原始信号，因此趋势图仅与主绘图一起显示。Trends（趋势）功能仅在 LabOne 用户界面中可用，在 API 上不可用。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//855280b2-161d-4f0c-8a50-16822fc63744/markdown_4/imgs/img_in_chart_box_226_123_1057_478.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A33Z%2F-1%2F%2F062f083d8bce76a01c1d7dc376b4a2468a78ae7d00bfa6c0c6c516e04cfb11d1" alt="Image" width="69%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.6.顶部：显示信号迹线的 Scope（示波器）选项卡的主绘图。底部：对应的趋势图跟踪从主绘图中光标位置得出的平均值、标准差和差分信号。所示示例是 HF2LI 用户界面的一部分。在提供此功能的所有选项卡和产品平台中，Trends（趋势）功能的控件及其布局都是非常相似的。</div> </div>


### 4.2. 保存和加载数据

#### 4.2.1. 概览

在本节中，我们将讨论如何使用 MFLI 仪器和 LabOne 用户界面来保存和记录测量数据。在 LabOne 用户界面中，有 3 种保存数据的方式：

一 保存当前在绘图中显示的数据

一 后台连续记录数据

一 在 History（历史记录）子选项卡中保存迹线数据。

此外，History（历史记录）子选项卡支持加载数据。下面，我们将解释这些方法。

#### 4.2.2. 保存绘图中的数据

要快速保存任何绘图中的数据，请单击绘图底部的 Save CSV（保存 CSV）图标 📚，将当前显示的曲线作为逗号分隔值 (CSV) 文件存储到 Web 浏览器的下载文件夹中。单击 ☐ 即可保存图形文件。

#### 4.2.3. 记录数据

记录功能允许您连续存储测量数据，以及跟踪一段时间内的仪器设置。按照第 4.15 节的说明，您可以访问此功能的主要设置。Format（格式）选择器定义使用哪种格式：HDF5、CSV 或 MATLAB。可以在 User Preferences（用户首选项）部分更改 CSV 分隔符。默认选项是 Semicolon（分号）。Time Zone（时区）设置允许您调整保存数据的时间戳。

Record Data（记录数据）部分的节点树显示允许您浏览不同的测量数据和仪器设置，并选择要记录的数据。例如，解调器 1 的测量数据可通过以下形式的路径来访问：Device 0000/Demodulators/Demod 1/Sample（设备 0000/解调器/解调器 1/样本）。仪器设置的一个示例是滤波器时间常数，可通过以下路径来访问：Device 0000/Demodulators/Demod 1/ Filter Time Constant（设备 0000/解调器/解调器 1/滤波器时间常数）。

从 Record（记录）部分的 Drive（驱动）下拉菜单中选择存储位置。默认位置是 MFLI 的内部闪存。或者，您可以将外部 USB 驱动器插入 MFLI 后面板上的其中一个 USB 设备端口。之后 Drive（驱动）下拉菜单中会出现一个附加选项 USB 1 或 USB 2。如果您想直接将数据保存到主机，您可以按第 1.5 节所述在主机上安装并运行 LabOne Web 服务器。

##### 注释

只建议偶尔使用内部闪存存储数据和在存储少量数据时使用内部闪存。原因是闪存（例如仪器中使用的闪存）仅支持有限数量的写入周期，并且在大量使用时可能会有磨损。针对这些情况，更安全的做法就是将数据存储到主机（参见第 1.5 节）或外部 USB 硬盘上，这样速度也更快了。

单击 Record（记录）复选框，开始记录到选定位置。对于解调器和 boxcar 数据，请确保启用相应的数据流，否则将不会有任何数据保存下来。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//a28035b5-0cbc-40a0-ba37-bb8cc00de4c0/markdown_0/imgs/img_in_image_box_217_1317_1083_1518.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A19Z%2F-1%2F%2F181ef386716d1c7847a98db8f093bfe2481b7a3c76c7f03ced11b9f0e0d34f42" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.7. 在 LabOne File Manager（文件管理器）选项卡中浏览和检查文件</div> </div>


如果选择 HDF5 或 MATLAB 作为文件格式，LabOne 将创建一个包含全部选定节点数据的文件。对于 CSV 格式，从一开始就为每个选定节点创建至少一个文件。在可配置的时间间隔内，可以创建新的数据文件，但文件的最大大小上限约为 1 GB，以便于数据处理。存储位置会显示在 Record Data（记录数据）部分的 Folder（文件夹）字段中。

第 4.17 节很好地介绍了怎么检查 CSV 数据文件。通过选项卡左侧的文件浏览器，可以导航到数据文件的位置，该浏览器还具有管理 MF 仪器驱动器（如果是在主机上运行 Web 服务器，那么就是计算机驱动器）上的文件的功能。此外，还可以使用 Upload/Download（上传/下载）按钮在 MFLI 和主机的下载文件夹之间很方便地传输文件。选项卡右侧的文件查看器显示不超过特定大小限制的文本文件的内容。图 4.7 显示记录 Demodulator Sample（解调器样本）和 Filter Time Constant（滤波器时间常数）几秒后的 Files（文件）选项卡。该文件查看器显示解调器数据文件的内容。

##### 注释

包含仪器设置的文件和包含流传输数据的文件，两者结构相同。流传输数据文件每个采样周期包含一行，但若是仪器设置，文件通常只包含几行，每次更改设置才有一行。有关文件结构的更多信息可以参见 LabOne 编程手册。

#### 4.2.4. 历史记录列表

第 4.10 节、第 4.8 节、第 4.7 节、第 4.9 节等包含历史记录列表的选项卡支持功能保存、自动保存和加载功能。这些工具中的绘图区域默认显示最近 100 次测量（即取决于工具、扫描迹线、示波器截图、DAQ 数据集或光谱），并且每次测量都表示为 History（历史记录）子选项卡中的列表条目。每个列表条目的左侧按钮控制绘图中对应迹线的可见性；右侧按钮控制迹线的颜色。 $ ^{3} $双击列表条目可以重新命名它。可通过 Save All 保存历史记录列表中的所有测量。单击 Save Sel 按钮（请注意下拉按钮 ☑）只保存鼠标单击选定的迹线。使用 Control 或 Shift 键的同时单击鼠标，选择多个迹线。使用 Open Folder（打开文件夹）按钮 ☑ 访问文件位置。图 4.8 说明了其中部分功能。图 4.8 说明了数据加载功能。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//a28035b5-0cbc-40a0-ba37-bb8cc00de4c0/markdown_2/imgs/img_in_image_box_223_111_560_697.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A21Z%2F-1%2F%2F71076b1a123b39913c71c7c7330aebfbb39206a4fa707a18774f1aed693d2f1e" alt="Image" width="28%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.8.History（历史记录）子选项卡功能。用户可重新命名“My measurement 1”等条目。测量 1、2、3、4 当前显示在绘图中，原因是它们各自的左侧按钮已经启用。单击 Save Sel（保存选定项）即可将“My measurement 3”和““My measurement 4”保存到一个文件中，因为这些条目已经通过 Control 键 + 鼠标单击的操作被选定（灰色覆盖）。</div> </div>


保存哪些物理量取决于有哪些信号已添加到 Control（控制）子选项卡中的 Vertical Axis Groups（垂直轴组）部分。Lock-in（锁相）选项卡中只有启用了 Data Transfer（数据传输）的解调器的数据才能保存在文件中。

History（历史记录）子选项卡具有自动保存功能，可在工具运行时持续存储测量结果。自动保存目录与普通保存目录有所不同，其名称中有“autosave”文字，例如 sweep_autosave_000。在激活Autosave（自动保存）功能的情况下连续运行工具（Run/Stop 按钮），那么当前测量（历史记录条目）完成后就会保存历史记录中的所有测量。每次覆盖同一个文件，意味着一旦达到历史记录Length（长度）设置定义的限制，以前的测量就会丢失。在激活Autosave（自动保存）功能的情况下执行单次测量（Single 按钮），每次测量后，历史记录列表中的元素都会以递增计数的方式保存到一个新的目录中，例如 sweep_autosave_001、sweep_autosave_002。

以 HDF5 文件格式保存的数据可以重新加载到历史记录列表中。加载迹线在用户界面的历史记录条目中的名称有一个前缀“loaded”。标题数据中的 createdtimestamp 信息标记了测量数据的时间。

只能加载通过 History（历史记录）子选项卡中的 Save（保存）按钮创建的文件。

加载文件时，文件中保存的所有历史记录项会添加到历史记录列表中。以前的条目保存在列表中。

如果文件中的数据与工具 Vertical Axis Group（垂直轴组）部分的当前设置匹配，那么这些数据仅显示在绘图中。Sweeper（参数扫描仪）中的加载（例如 PID 数据）不会显示出来，除非它已在 Control（控制）子选项卡被选定。

一 只有保存和加载数据的设备属于同一个产品系列才能加载文件。数据路径将根据加载数据的设备 ID 设置。

<div style="text-align: center;"><div style="text-align: center;">图 4.9 说明了数据加载功能。</div> </div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//a28035b5-0cbc-40a0-ba37-bb8cc00de4c0/markdown_3/imgs/img_in_image_box_219_155_809_675.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A22Z%2F-1%2F%2F87cd342c94d4ce5095ec0928d68d337b5b06267f62ec2fb2f5f6f552cbdc843d" alt="Image" width="49%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.9. 历史记录数据加载功能。这里，文件 sweep_00000.h5 通过拖放加载。加载数据会被添加到历史记录列表中的测量中。</div> </div>


#### 4.2.5. 支持的文件格式

HDF5

层级数据文件 5 (HDF5) 是一种广泛使用且可节省内存的结构性二进制开放文件格式。可以使用专用查看器 HDFview 查看这种格式的数据。HDF5 库或导入工具可用于 Python、MATLAB、LabVIEW、C、R、Octave、Origin、Igor Pro 等。以下示例说明了如何使用 Python 中的 h5py 库从扫描中访问解调器数据：

import h5py
filename = 'sweep_00000.h5'
f = h5py.File(filename, 'r')
x = f['000/dev3025/demods/0/sample/frequency']
LabOne 的数据加载功能支持 HDF5 格式的文

##### MATLAB

MATLAB 文件格式 (.mat) 是 MathWorks 基于 HDF5 开放文件格式的专有文件格式。因此，它具有与 HDF5 格式相似的属性，但在支持向 MATLAB 以外的第三方软件导入 .mat 文件时通常就不如支持导入 HDF5 文件了。

##### SXM

SXM 是 Nanonis 用于 SPM 测量的专有文件格式。

##### ZView

ZView 是一种逗号分隔值格式，适用于阻抗分析，由 Scribner Associates 的同名分析软件提供支持。由于其他阻抗建模软件工具正在使用这种结构的许多变体，因此 LabOne 支持通过模板文件将 ZView 格式调整为首选标准。步骤如下：

一 按第 4.15 节所述，选择 ZView 作为数据记录的 Format（格式）设置。

启用和禁用 Record（记录）复选框。只有首次使用 ZView 格式并创建默认模板文件时才需要这一步。

按第 4.17 节所述，在 Setting（设置）文件夹中查找文件 savefile_template.txt。使用 Download（下载）按钮将其传输到 PC 中，并根据需要进行修改（见下文）。

一 使用 Upload（上传）按钮将修改后的文件（同名文件 savefile_template.txt）重新传输到 Setting（设置）文件夹中。

所有 ZView 格式的连续数据记录都将使用这个新模板。模板文件的最后一行定义了保存的数据文件的数据行格式，并会在每个样本中重复。最后一行以上的所有内容定义了数据文件标题，并一次写入数据文件。在标题部分和最后一行中，${variable} 形式的关键词都将替换为相应的物理量或设置。模板文件中的任何其他文本都被逐字写入数据文件。

下表列出了模板文件标题部分和最后一行支持的关键词。

<div style="text-align: center;"><div style="text-align: center;">表 4.9.ZView 模板文件标题部分支持的关键词</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>关键词</td><td style='text-align: center; word-wrap: break-word;'>基准</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>${year}、${month}、${day}、${hours}、${minutes}、${seconds}</td><td style='text-align: center; word-wrap: break-word;'>当前时间戳的各个组成部分</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>${month_str}</td><td style='text-align: center; word-wrap: break-word;'>月份名缩写（Jan、Feb、Mar...）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>${numpoints}</td><td style='text-align: center; word-wrap: break-word;'>记录数据样本数</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>${filename}</td><td style='text-align: center; word-wrap: break-word;'>文件名</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>${grid_columns}</td><td style='text-align: center; word-wrap: break-word;'>第4.8节中的列数</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>${grid_rows}</td><td style='text-align: center; word-wrap: break-word;'>第4.8节中的行数</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>${grid_mode}</td><td style='text-align: center; word-wrap: break-word;'>第4.8节中的模式设置（最近、线性、Lanczos）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>${grid_operation}</td><td style='text-align: center; word-wrap: break-word;'>第4.8节中的操作设置（替换、平均）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>${grid_scan_direction}</td><td style='text-align: center; word-wrap: break-word;'>第4.8节中的扫描方向（正向、反向、双向）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>${grid_repetitions}</td><td style='text-align: center; word-wrap: break-word;'>第4.8节中的重复设置</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">表 4.10.ZView 模板文件最后一行支持的关键词</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>关键词</td><td style='text-align: center; word-wrap: break-word;'>基准</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>${frequency}</td><td style='text-align: center; word-wrap: break-word;'>测量频率</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>${phasez}</td><td style='text-align: center; word-wrap: break-word;'>阻抗复相位</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>${absz}</td><td style='text-align: center; word-wrap: break-word;'>阻抗绝对值</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>${realz}</td><td style='text-align: center; word-wrap: break-word;'>阻抗实部</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>${imagz}</td><td style='text-align: center; word-wrap: break-word;'>阻抗虚部</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>${param0}</td><td style='text-align: center; word-wrap: break-word;'>表示参数 1</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>${param1}</td><td style='text-align: center; word-wrap: break-word;'>表示参数 2</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>${drive}</td><td style='text-align: center; word-wrap: break-word;'>驱动电压幅值</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>${bias}</td><td style='text-align: center; word-wrap: break-word;'>直流偏置电压</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>${timestamp}</td><td style='text-align: center; word-wrap: break-word;'>以仪器时钟周期为单位的测量时间</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>${time_sec}</td><td style='text-align: center; word-wrap: break-word;'>相对于第一个样本的时间（以秒为单位）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>${count}</td><td style='text-align: center; word-wrap: break-word;'>连续样本计数</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>${flags}</td><td style='text-align: center; word-wrap: break-word;'>包含置信度指示器和设备状态信息的位标志的整数（参见表 4.11）</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">表 4.11.\${flags} 数据列中的位分配</div> </div>




<table border="1" style="margin: auto; word-wrap: break-word;"><tr><td style="text-align: center; word-wrap: break-word;">位号</td><td style="text-align: center; word-wrap: break-word;">条件</td></tr><tr><td style="text-align: center; word-wrap: break-word;">0</td><td style="text-align: center; word-wrap: break-word;">启用内部校准</td></tr><tr><td style="text-align: center; word-wrap: break-word;">1</td><td style="text-align: center; word-wrap: break-word;">启用用户补偿</td></tr><tr><td style="text-align: center; word-wrap: break-word;">2...3</td><td style="text-align: center; word-wrap: break-word;">保留</td></tr><tr><td style="text-align: center; word-wrap: break-word;">4</td><td style="text-align: center; word-wrap: break-word;">置信度指示器：电压信号输入上溢</td></tr><tr><td style="text-align: center; word-wrap: break-word;">5</td><td style="text-align: center; word-wrap: break-word;">置信度指示器：电流信号输入上溢</td></tr><tr><td style="text-align: center; word-wrap: break-word;">6</td><td style="text-align: center; word-wrap: break-word;">置信度指示器：电压信号输入下溢</td></tr><tr><td style="text-align: center; word-wrap: break-word;">7</td><td style="text-align: center; word-wrap: break-word;">置信度指示器：电流信号输入下溢</td></tr><tr><td style="text-align: center; word-wrap: break-word;">8...10</td><td style="text-align: center; word-wrap: break-word;">保留</td></tr><tr><td style="text-align: center; word-wrap: break-word;">11</td><td style="text-align: center; word-wrap: break-word;">置信度指示器：Z对于2端子来说太低了</td></tr><tr><td style="text-align: center; word-wrap: break-word;">12</td><td style="text-align: center; word-wrap: break-word;">置信度指示器：抑制第一个表示参数(PARAM0)</td></tr><tr><td style="text-align: center; word-wrap: break-word;">13</td><td style="text-align: center; word-wrap: break-word;">置信度指示器：抑制第二个表示参数(PARAM1)</td></tr><tr><td style="text-align: center; word-wrap: break-word;">14</td><td style="text-align: center; word-wrap: break-word;">保留</td></tr><tr><td style="text-align: center; word-wrap: break-word;">15</td><td style="text-align: center; word-wrap: break-word;">置信度指示器：超出电流输入频率限制</td></tr><tr><td style="text-align: center; word-wrap: break-word;">16</td><td style="text-align: center; word-wrap: break-word;">置信度指示器：在第一个表示参数(PARAM0)上检测到强补偿</td></tr><tr><td style="text-align: center; word-wrap: break-word;">17</td><td style="text-align: center; word-wrap: break-word;">置信度指示器：在第二个表示参数(PARAM1)上检测到强补偿</td></tr><tr><td style="text-align: center; word-wrap: break-word;">18...23</td><td style="text-align: center; word-wrap: break-word;">保留</td></tr><tr><td style="text-align: center; word-wrap: break-word;">24</td><td style="text-align: center; word-wrap: break-word;">置信度指示器：检测到开路</td></tr><tr><td style="text-align: center; word-wrap: break-word;">25...31</td><td style="text-align: center; word-wrap: break-word;">保留</td></tr></table>




#### 4.2.6. LabOne Net Link

测量和光标数据可以作为 CSV 数据从浏览器下载。这样就可以在任何支持 CSV 文件格式的应用中进一步处理。由于数据内部存储在 Web 服务器上，因此其他应用可直接通过访问服务器来读取它。大多数的最新软件都支持通过互联网从网页或 CSV 文件导入数据。这样就可以在许多应用中自动导入和刷新数据集。要执行导入，应用需要知道加载数据的地址。该链接由 LabOne 用户界面提供。以下章节列表举例说明了如何将数据导入一些常用应用。

发送到应用的 CSV 数据是发送请求时 Web 服务器上数据集的快照。许多应用支持手动或定期刷新功能。

由于选项卡可以在同一个用户界面中多次实例化，因此该链接特定于从中获取的选项卡。更改LabOne用户界面上的会话或删除选项卡可能会使链接无效。

支持的应用：

一 “Excel”这一节

一 “MATLAB”这一节

一 “Python”这一节

“C#.NET”这一节

一 “Igor Pro”这一节

一 “Origin”这一节

##### Excel

这些说明适用于 Excel 2010（英文版）。其他版本的程序可能有所不同。

1. 在 Excel 中，单击要放置数据的单元格。从 Data（数据）功能区中，单击“From Text”（自文本）图标。将出现“Import Text File”（导入文本文件）对话框。



<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>File</td><td style='text-align: center; word-wrap: break-word;'>Home</td><td style='text-align: center; word-wrap: break-word;'>Insert</td><td style='text-align: center; word-wrap: break-word;'>Page Layout</td><td style='text-align: center; word-wrap: break-word;'>Formulas</td><td style='text-align: center; word-wrap: break-word;'>Data</td><td style='text-align: center; word-wrap: break-word;'>F</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>A</td><td style='text-align: center; word-wrap: break-word;'>From</td><td style='text-align: center; word-wrap: break-word;'>From</td><td style='text-align: center; word-wrap: break-word;'>From Other Sources</td><td style='text-align: center; word-wrap: break-word;'>Existing Connections</td><td style='text-align: center; word-wrap: break-word;'>Refresh All</td><td style='text-align: center; word-wrap: break-word;'>Edit Links Connections</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>A</td><td style='text-align: center; word-wrap: break-word;'>From Web</td><td style='text-align: center; word-wrap: break-word;'>From Text</td><td style='text-align: center; word-wrap: break-word;'>Sources</td><td style='text-align: center; word-wrap: break-word;'>Connections</td><td style='text-align: center; word-wrap: break-word;'>E</td><td style='text-align: center; word-wrap: break-word;'></td></tr><tr><td style='text-align: center; word-wrap: break-word;'>A</td><td style='text-align: center; word-wrap: break-word;'>From Web</td><td style='text-align: center; word-wrap: break-word;'>From Text</td><td style='text-align: center; word-wrap: break-word;'>Sources</td><td style='text-align: center; word-wrap: break-word;'>Connections</td><td style='text-align: center; word-wrap: break-word;'>E</td><td style='text-align: center; word-wrap: break-word;'></td></tr><tr><td style='text-align: center; word-wrap: break-word;'>A</td><td style='text-align: center; word-wrap: break-word;'>From Web</td><td style='text-align: center; word-wrap: break-word;'>From Text</td><td style='text-align: center; word-wrap: break-word;'>Sources</td><td style='text-align: center; word-wrap: break-word;'>Connections</td><td style='text-align: center; word-wrap: break-word;'>E</td><td style='text-align: center; word-wrap: break-word;'></td></tr><tr><td style='text-align: center; word-wrap: break-word;'>A</td><td style='text-align: center; word-wrap: break-word;'>From Web</td><td style='text-align: center; word-wrap: break-word;'>From Text</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td></tr></table>

2. 在 LabOne 中，单击相应 Math（数学）选项卡的“Link”（链接）按钮。将选定文本从“LabOne Net Link”对话框复制到剪贴板（使用 Ctrl-C 或右键单击并选择“Copy”（复制））。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//d79c0417-785e-49ff-86f6-5ca10e9c4a2d/markdown_1/imgs/img_in_image_box_252_708_1086_891.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A32%3A11Z%2F-1%2F%2F9545d5ba3b0445d8db7ca333b63c92166b9b4b190047c5ed356a9782bd95c1d5" alt="Image" width="70%" /></div>


3. 在 Excel 中，将链接粘贴到“Import Text File”（导入文本文件）对话框的“File name”（文件名）输入字段中，然后单击“Open”（打开）按钮。这将启动文本导入向导。在单击“Next”（下一步）按钮之前，确保选中“Delimited”（分隔符号）按钮。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//d79c0417-785e-49ff-86f6-5ca10e9c4a2d/markdown_2/imgs/img_in_image_box_253_113_1092_708.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A32%3A12Z%2F-1%2F%2Ffc890e085a9eb940302bdbf9858244be1b3da83915eaf0fc6045aa4034104d9f" alt="Image" width="70%" /></div>


4. 在下一个对话框中，选择与 LabOne 中选定的分隔符相对应的分隔符（可以在“Config”（配置）选项卡的“Sessions”（会话）部分找到）。默认为分号。单击“Next”（下一步）按钮。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//d79c0417-785e-49ff-86f6-5ca10e9c4a2d/markdown_2/imgs/img_in_image_box_252_787_1090_1373.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A32%3A12Z%2F-1%2F%2Fc47dcd648a6ef302255c098b05b4a8c8b60a4b9a3357bb5b24c9873b5313596e" alt="Image" width="70%" /></div>


5. 在下一个对话框中，单击“Finish”（完成），然后在“Import Data”（导入数据）对话框中单击“OK”（确定）。Math（数学）选项卡中的数据现在将出现在 Excel 工作表中。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//d79c0417-785e-49ff-86f6-5ca10e9c4a2d/markdown_3/imgs/img_in_image_box_254_113_1092_702.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A32%3A13Z%2F-1%2F%2F91dc13f87785c345c1ea8b0b50399924fdf7c716e21eed737d0af84d19882e10" alt="Image" width="70%" /></div>


6. 单击“Refresh All”（全部刷新）图标可以更新工作表中的数据。要使数据更新更容易，可单击“Properties”（属性）取消“Import text file”（导入文本文件）对话框。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//d79c0417-785e-49ff-86f6-5ca10e9c4a2d/markdown_3/imgs/img_in_image_box_250_784_1094_903.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A32%3A13Z%2F-1%2F%2Fd16166a776253dae0345003edf71358bf3727174b6745546729fc8e87ff78442" alt="Image" width="70%" /></div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>A</td><td style='text-align: center; word-wrap: break-word;'>B</td><td style='text-align: center; word-wrap: break-word;'>C</td><td style='text-align: center; word-wrap: break-word;'>D</td><td style='text-align: center; word-wrap: break-word;'>E</td><td style='text-align: center; word-wrap: break-word;'>F</td><td style='text-align: center; word-wrap: break-word;'>G</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>% Module: Math, ID: c0p1t6p1cfplotmath</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td></tr><tr><td style='text-align: center; word-wrap: break-word;'>2</td><td style='text-align: center; word-wrap: break-word;'>% Device: dev2009</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td></tr><tr><td style='text-align: center; word-wrap: break-word;'>3</td><td style='text-align: center; word-wrap: break-word;'>% Time: 2014/03/19 16:29:22</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td></tr><tr><td style='text-align: center; word-wrap: break-word;'>4</td><td style='text-align: center; word-wrap: break-word;'>Signal</td><td style='text-align: center; word-wrap: break-word;'>Operation</td><td style='text-align: center; word-wrap: break-word;'>Value</td><td style='text-align: center; word-wrap: break-word;'>Unit</td><td style='text-align: center; word-wrap: break-word;'>#</td><td style='text-align: center; word-wrap: break-word;'>Description</td><td style='text-align: center; word-wrap: break-word;'>Node</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>5</td><td style='text-align: center; word-wrap: break-word;'>Cursor Loc</td><td style='text-align: center; word-wrap: break-word;'>X1</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>0</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Position of cursor X1</td><td style='text-align: center; word-wrap: break-word;'>Scope Channel 1</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>6</td><td style='text-align: center; word-wrap: break-word;'>Cursor Loc</td><td style='text-align: center; word-wrap: break-word;'>X2</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>0</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Position of cursor X2</td><td style='text-align: center; word-wrap: break-word;'>Scope Channel 1</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>7</td><td style='text-align: center; word-wrap: break-word;'>Cursor Loc</td><td style='text-align: center; word-wrap: break-word;'>X2 - X1</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>0</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Difference between vertical cursors X2 and X1</td><td style='text-align: center; word-wrap: break-word;'>Scope Channel 1</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>8</td><td style='text-align: center; word-wrap: break-word;'>Cursor Loc</td><td style='text-align: center; word-wrap: break-word;'>Y1</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>0</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Position of cursor Y1</td><td style='text-align: center; word-wrap: break-word;'>Scope Channel 1</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>9</td><td style='text-align: center; word-wrap: break-word;'>Cursor Loc</td><td style='text-align: center; word-wrap: break-word;'>Y2</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>0</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Position of cursor Y2</td><td style='text-align: center; word-wrap: break-word;'>Scope Channel 1</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>10</td><td style='text-align: center; word-wrap: break-word;'>Cursor Loc</td><td style='text-align: center; word-wrap: break-word;'>Y2 - Y1</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>0</td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>Difference between horizontal cursors Y2 and Y1</td><td style='text-align: center; word-wrap: break-word;'>Scope Channel 1</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>11</td><td style='text-align: center; word-wrap: break-word;'>Wave</td><td style='text-align: center; word-wrap: break-word;'>Min</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>-0.010742188</td><td style='text-align: center; word-wrap: break-word;'>V</td><td style='text-align: center; word-wrap: break-word;'>2560</td><td style='text-align: center; word-wrap: break-word;'>Minimum</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>12</td><td style='text-align: center; word-wrap: break-word;'>Wave</td><td style='text-align: center; word-wrap: break-word;'>Max</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>0.015136719</td><td style='text-align: center; word-wrap: break-word;'>V</td><td style='text-align: center; word-wrap: break-word;'>2560</td><td style='text-align: center; word-wrap: break-word;'>Maximum</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>13</td><td style='text-align: center; word-wrap: break-word;'>Wave</td><td style='text-align: center; word-wrap: break-word;'>Avg</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>0.002365303</td><td style='text-align: center; word-wrap: break-word;'>V</td><td style='text-align: center; word-wrap: break-word;'>2560</td><td style='text-align: center; word-wrap: break-word;'>Average</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>14</td><td style='text-align: center; word-wrap: break-word;'>Wave</td><td style='text-align: center; word-wrap: break-word;'>Std</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>0.003113134</td><td style='text-align: center; word-wrap: break-word;'>V</td><td style='text-align: center; word-wrap: break-word;'>2560</td><td style='text-align: center; word-wrap: break-word;'>Standard Deviation</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>15</td><td style='text-align: center; word-wrap: break-word;'>Wave</td><td style='text-align: center; word-wrap: break-word;'>Int</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>6.73E-09</td><td style='text-align: center; word-wrap: break-word;'>Vs</td><td style='text-align: center; word-wrap: break-word;'>2560</td><td style='text-align: center; word-wrap: break-word;'>Integral</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>16</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td></tr><tr><td style='text-align: center; word-wrap: break-word;'>17</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td></tr><tr><td style='text-align: center; word-wrap: break-word;'>18</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td></tr><tr><td style='text-align: center; word-wrap: break-word;'>19</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td></tr></table>

7. 取消选中“Prompt for file name on refresh”（刷新时提示输入文件名）复选框。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//d79c0417-785e-49ff-86f6-5ca10e9c4a2d/markdown_4/imgs/img_in_image_box_253_153_754_829.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A32%3A14Z%2F-1%2F%2F7973cfab54e83652204eaf3530b0cfed061ca2ec8b5eaa373f21c909f5c17106" alt="Image" width="42%" /></div>


##### MATLAB

通过将“LabOne Net Link”对话框中的链接文本复制到剪贴板，可以在 MATLAB 中使用以下代码片段来读取数据。

textscan(urlread(clipboard('paste'), '%s%s%f%s%d%s%s', 'Headerlines', 4,'Delimiter',;)

##### Python

以下代码片段可用于在 Python 2 中读取 LabOne Net Link 数据，其中“url”被分配给从“LabOne Net Link”对话框复制的文本。

import csv import urllib2
url = "http://127.0.0.1:8006/netlink?id=c0p5t6p1cfplotmath&ziSessionId=0"
webpage = urllib2.urlopen(url)
datareader = csv.reader(webpage)
data = []
for row in datareader:
    data.append(row)

##### C#.NET

.NET Framework 提供了一个 WebClient 对象，可用于向 LabOne WebServer 发送 Web 请求并下载 LabOne Net Link 数据。可以通过在逗号边框处拆分数据来解析具有逗号分隔内容的字符串。

using System;
using System.Text;
using System.Net;

namespace ExampleCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WebClient wc = new WebClient();
                byte[] buffer = wc.DownloadData("http://127.0.0.1:8006/netlink?id=c0p1t6p1cfplotmath&ziSessionId=0");
                String doc = Encoding.ASCII.GetString(buffer);
                //Parse here CSV lines and extract data
                //...
                Console.WriteLine(doc);
            } catch (Exception e) {
                Console.WriteLine("Caught exception: " + e.Message);
            }
        }
    }
}

##### Igor Pro

这些说明适用于 Igor Pro 6.34A（英文版）。其他版本的程序可能有所不同。

1. 对于 Igor Pro，CSV 分隔符必须是逗号。在 LabOne Config（配置）选项卡中进行如下设置：

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//1e08fb30-51b1-4766-8572-c968ec371c3e/markdown_0/imgs/img_in_image_box_259_692_905_1137.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A38Z%2F-1%2F%2Fef20183f544bb28de02e19f3ad82231dc7dcf0db8e0cf11130982baf181f39eb" alt="Image" width="54%" /></div>


2. 在 Igor Pro 中，选择菜单“Data（数据）→Load Waves（加载 Waves）→Load Waves（加载 Waves）...”。



<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td colspan="2">File Edit Data Analysis Macros Windows Table Help</td></tr></table>

3. 在“Load Waves”（加载 Waves）对话框中，单击“File...”（文件...）按钮并将“LabOne Net Link”对话框中的链接文本粘贴到输入字段中。然后单击“Tweaks...”按钮打开“Load Data Tweaks”（加载数据 Tweaks）对话框。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//1e08fb30-51b1-4766-8572-c968ec371c3e/markdown_1/imgs/img_in_image_box_252_713_1020_1271.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A39Z%2F-1%2F%2F347a1239dbecad9ef00204261fd2a79a60ca6c6992851b4680ce92602d470c43" alt="Image" width="64%" /></div>


4. 调整下面突出显示的值，然后单击“Return”（返回）。将出现“Loading Delimited Data”（加载分隔数据）对话框。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//1e08fb30-51b1-4766-8572-c968ec371c3e/markdown_2/imgs/img_in_image_box_251_180_881_693.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A39Z%2F-1%2F%2F754e5854406c8e6c30bc86817c0bd8a0aea74127f5bea05b56ed30fa05580ff5" alt="Image" width="52%" /></div>


# 5. 单击“Load”（加载）按钮读取数据。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//1e08fb30-51b1-4766-8572-c968ec371c3e/markdown_2/imgs/img_in_image_box_253_750_1021_1356.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A39Z%2F-1%2F%2F4803ef02de8a001190c06fd17d519a3468d6377875c888b23e5e60de21c60c2d" alt="Image" width="64%" /></div>


# 6. 数据将出现在 Igor Pro 主窗口中。



<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td colspan="2">Input Pro 6.344 - [Table1-Signal,Operation,Value,Unit,XW...]</td></tr></table>

##### Origin

这些说明适用于 Origin 9.1（英文版）。其他版本的程序可能有所不同。

1. 单击下面突出显示的图标，打开导入向导。



<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>Project Explorer (1)</td><td colspan="3">Book1</td></tr></table>

2. 请务必选择 ASCII 按钮。单击“...”按钮。请参见下面的屏幕截图。将出现“Import Multiple ASCII”（导入多个 ASCII）对话框。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//1e08fb30-51b1-4766-8572-c968ec371c3e/markdown_4/imgs/img_in_image_box_254_176_1104_984.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A41Z%2F-1%2F%2F2ef729df781fd76c347de73b2bb47fc537cd76f0cbb6fc90603786e8e0b5e4f8" alt="Image" width="71%" /></div>


3. 将“LabOne Net Link”对话框中的链接文本粘贴到下面突出显示的输入字段中。然后单击“Add File(s)”（添加文件），再单击“OK”（确定）。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//e362d0f3-4345-49a9-b745-5ed743cd1339/markdown_0/imgs/img_in_image_box_252_176_1108_1063.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A11Z%2F-1%2F%2Fa23a46cfb4ac60fed15a7ae0ddfeb39ecfdcd0fe8b8a99172fef3192d9e7df27" alt="Image" width="71%" /></div>


# 4. 返回到“Import Wizard - Source”（导入向导 - 数据源）对话框，单击“Finish”（完成）。



<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>Import Wizard - Source</td><td style='text-align: center; word-wrap: break-word;'>? ×</td></tr><tr><td colspan="2">Data Type</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>ASCII</td><td style='text-align: center; word-wrap: break-word;'>Binary</td></tr><tr><td colspan="2">Data Source</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>File</td><td style='text-align: center; word-wrap: break-word;'>C:\Users\dragonl\AppData\Local\Microsoft\Windows\Temporary Internet Files\Content.IE5\JM</td></tr><tr><td colspan="2">Clipboard</td></tr><tr><td colspan="2">Import Filter</td></tr><tr><td colspan="2">List filters applicable to both Data Type and file name</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Import Filters for current Data Type</td><td style='text-align: center; word-wrap: break-word;'>&lt;None&gt;</td></tr><tr><td colspan="2">Description</td></tr><tr><td colspan="2">Target Window</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Worksheet</td><td style='text-align: center; word-wrap: break-word;'>Matrix</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Template</td><td style='text-align: center; word-wrap: break-word;'>&lt;Default&gt;</td></tr><tr><td colspan="2">Template could be used only when import mode is start new books or start new sheets</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Import Mode</td><td style='text-align: center; word-wrap: break-word;'>Replace Existing Data</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Cancel</td><td style='text-align: center; word-wrap: break-word;'>&lt;&lt; Back Next &gt;&gt; Finish</td></tr></table>

# 5. 数据将出现在 Origin 主窗口中。



<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>Project Explorer (1)</td><td style='text-align: center; word-wrap: break-word;'>File</td><td style='text-align: center; word-wrap: break-word;'>Edit</td><td style='text-align: center; word-wrap: break-word;'>View</td><td style='text-align: center; word-wrap: break-word;'>Plot</td><td style='text-align: center; word-wrap: break-word;'>Column</td><td style='text-align: center; word-wrap: break-word;'>Worksheet</td><td style='text-align: center; word-wrap: break-word;'>Analysis</td><td style='text-align: center; word-wrap: break-word;'>Statistics</td><td style='text-align: center; word-wrap: break-word;'>Image</td><td style='text-align: center; word-wrap: break-word;'>Tools</td><td style='text-align: center; word-wrap: break-word;'>Format</td><td style='text-align: center; word-wrap: break-word;'>Window</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>☐</td><td colspan="12">Help</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>☐</td><td style='text-align: center; word-wrap: break-word;'>☐</td><td style='text-align: center; word-wrap: break-word;'>☐</td><td style='text-align: center; word-wrap: break-word;'>☐</td><td style='text-align: center; word-wrap: break-word;'>☐</td><td style='text-align: center; word-wrap: break-word;'>☐</td><td style='text-align: center; word-wrap: break-word;'>☐</td><td style='text-align: center; word-wrap: break-word;'>☐</td><td style='text-align: center; word-wrap: break-word;'>☐</td><td style='text-align: center; word-wrap: break-word;'>☐</td><td style='text-align: center; word-wrap: break-word;'>☐</td><td style='text-align: center; word-wrap: break-word;'>☐</td><td style='text-align: center; word-wrap: break-word;'>☐</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>☐</td><td style='text-align: center; word-wrap: break-word;'>☐</td><td style='text-align: center; word-wrap: break-word;'>☐</td><td style='text-align: center; word-wrap: break-word;'>☐</td><td style='text-align: center; word-wrap: break-word;'>&lt;ecel&gt;</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td></tr></table>

### 4.3. Lock-in（锁相）选项卡

此选项卡是主要的锁相放大器控制面板。使用安装了 MF-MD 多解调器选件的仪器的用户请参见第4.4节。

#### 4.3.1. 特征

一 可访问主要输入、输出和解调器控件的功能框图

一 具有主要输入、输出和解调器控件的参数表

一 用于 1 个可配置解调器的控件元素

一 用于两个输入通道的自动调整量程、缩放、任意输入单位

一 用于 1 个振荡器的控件

一 主信号输入和信号输出的设置

一 灵活选择参考源、触发选项和数据传输速率

#### 4.3.2. 描述

Lock-in（锁相）选项卡是仪器的主控制中心，默认启动后打开。当该选项卡关闭或需要其他相同类型的选项卡时，单击以下图标即可打开该选项卡的新实例。

<div style="text-align: center;"><div style="text-align: center;">表 4.12. 应用图标和简要描述</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in</td><td style='text-align: center; word-wrap: break-word;'>☒</td><td style='text-align: center; word-wrap: break-word;'>快速纵览和访问关于信号生成及解调的所有设置和属性。</td></tr></table>

Lock-in（锁相）选项卡的默认视图是参数表视图。可以在标有 All（全部）的侧边栏选项卡下访问，该视图提供用于仪器中所有解调器的控件。此外，每个单独的解调器都有一个可用的功能框图。可以在标有相应解调器编号的侧边栏选项卡下访问功能框图。

##### 参数表

参数表（参见图 4.10）包含 4 个部分：Signal Inputs（信号输入）、Oscillators（振荡器）、Demodulators（解调器）和 Signal Outputs（信号输出）。Demodulator（解调器）部分由两行组成，上面一行可访问双相解调器的所有设置，第二行代表用于外部参考的 PLL 的相位检测器。用户可以获取和更改滤波器设置，但不能将数据传输到数据服务器。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//e362d0f3-4345-49a9-b745-5ed743cd1339/markdown_3/imgs/img_in_image_box_216_1125_1074_1320.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A13Z%2F-1%2F%2F4b69193756bf694a5ce79b20b8df1df3c2099a10789549176954b9924721a29b" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.10. LabOne 用户界面的 Lock-in（锁相）选项卡 - 参数表（全部）</div> </div>


Signal Inputs（信号输入）部分允许用户定义输入信号的所有相关设置，例如输入耦合、范围等。一些可用选项，如相位调整和触发功能，在默认情况下处于折叠状态。只需在“+”图标上单击鼠标即可展开这些控件。在 Lock-in（锁相）选项卡的右侧，Signal Outputs（信号输出）部分允许定义信号幅值、偏移和范围值。

Range（范围）字段下方的 Scaling（缩放）字段可用于将 Signal Input（信号输入）数据相乘，例如表示外部放大器的增益。如果外部输入信号有 10 V/A 的跨阻增益，则可将 Scaling（缩放）字段设置为 0.1，将 Units（单位）字段设置为 A，以便通过整个用户界面来显示实际电流读数。Scaling（缩放）字段的下方是 AC/DC（交流/直流）按钮和 50 Ω/10 MΩ 按钮。AC/DC（交流/直流）按钮用来设置耦合类型：交流耦合具有高通截止频率，可用于阻挡大的直流信号分量，以防止放大期间输入信号饱和。50 Ω/10 MΩ 按钮在低 (50 Ω) 和高（约 10 MΩ）输入阻抗之间切换输入阻抗。对于 50 Ω 输入阻抗，如果信号源也具有 50 Ω 输出阻抗，则预计测量信号会减少 2 倍。

##### 注释

Signal Inputs（信号输入）可以设置为浮动，这意味着 BNC 连接器屏蔽不再连接到仪器接地端。该设置会影响电流输入和电压输入。建议在连接前对测试设备进行放电或仅当信号源在接地模式下连接至 Signal Input（信号输入）后启用此设置。

Oscillator（振荡器）部分表示内部振荡器的频率。当 Mode（模式）指示器显示 Manual（手动）时，用户可以通过在字段中键入频率值来手动定义振荡器频率。如果振荡器参考外部源，Mode（模式）指示器将显示 ExtRef（外部参考），并且频率字段设置为只读。外部参考需要一个 PLL 来将频率映射到内部振荡器上。频率字段旁边的绿灯表示锁定成功。

在下文中，我们将更详细地讨论 Demodulators（解调器）设置。图 4.11 中显示的框图显示了主要解调器组件及相互之间的连接。了解如何接线对于成功操作仪器至关重要。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//e362d0f3-4345-49a9-b745-5ed743cd1339/markdown_4/imgs/img_in_image_box_224_730_1085_1066.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A15Z%2F-1%2F%2F4fa0360818d70e373ccc92280b2c82b3184f3d7e828791cda96023a837da1d3d" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.11. 未安装 MF-MD 多解调器选件的解调器框图。</div> </div>


Demodulators（解调器）部分的第一条线代表可用于测量的解调器。Mode（模式）这一列只读设置为内部参考（Demod（解调器））。第二条线代表另外一个解调器，当模式切换到外部参考（ExtRef）时，该解调器专门用作相位检测器。用户可以从许多不同的输入中进行选择以用作外部参考信号，并且滤波器设置向用户展示了 PLL 速度的概念。然而，第二个解调器不会产生任何可用于测量的输出数据。在 Input Signal（输入信号）列中，可以定义作为给定解调器输入的信号。可以选择多种信号：Signal Inputs（信号输入）、Trigger Inputs（触发输入）、Auxiliary Inputs（辅助输入）和 Auxiliary Outputs（辅助输出）。这样可以将仪器用于许多不同的测量拓扑。对于每个解调器，通过在 Phase（相位）列中输入相移，可以将额外的相移引入相关的振荡器。该相位被添加到参考通道和解调器的输出。因此，当使用相同的解调器生成和检测频率时，信号相位和参考相位进行等量变化并且解调结果中看不到任何变化。通过在 Harm（谐波）列中输入所需的因子来实现对任何振荡器频率整数倍的频率解调。解调的结果，即幅值和相位可以被读取，例如使用第 4.5 节中描述的 Numeric（数值）选项卡。

在 Lock-in（锁相）选项卡的中间是 Low-Pass Filters（低通滤波器）部分，在该部分中，可以在下拉列表中为每个解调器选择滤波器阶数，并且可通过键入数值来选择滤波器带宽 (BW 3dB)。或者，

可以通过单击列标题来选择滤波器的时间常数 (TC) 或噪声等效功率滤波器带宽 (BW NEP)。例如，将滤波器阶数设置为 4，相当于 24 dB/oct 或 80 dB/dec 的滚降系数，即频率增加十倍，衰减  $ 10^{4} $。当 Low-Pass Filter（低通滤波器）带宽与解调频率相当或大于解调频率时，解调器输出可以包含解调频率及其高次谐波的频率分量。在这种情况下，应启用额外的 Sinc Filter（Sinc 滤波器）。它会衰减解调器输出中那些不需要的谐波分量。Sinc Filter（Sinc 滤波器）适用于低频测量，因为它允许适用更接近解调频率的 Low-Pass Filter（低通滤波器）带宽，从而加快测量时间。

解调器输出的数据传输由 Data Transfer（数据传输）部分中的 En 按钮激活，其中还可以定义每个解调器的采样率（Rate（速率））。

Data Transfer（数据传输）旁边的 Trigger（触发）部分允许设置触发条件，以便通过将逻辑信号（例如 TTL）应用到仪器后面板上的 Trigger Input 1 或 Trigger Input 2 来控制和启动从仪器到主机 PC 的数据传输。

在 Signal Outputs（信号输出）部分，On（打开）按钮用于激活 Signal Output（信号输出）。Range（范围）下拉列表用于选择正确的输出范围设置。在 Signal Output（信号输出）上可以定义偏移电压（Offset（偏移））。允许的最大输出信号为 PLUSMINUS10 V。

##### 框图

主要仪器功能的框图视图有时也称为“图形 Lock-in（锁相）选项卡”。Lock-in（锁相）选项卡中的一组索引侧边栏选项卡可以访问每个解调器的框图。框图功能齐全，可为用户提供仪器内部情况的视觉反馈。上一节详述的参数表中可用的所有控件元素也以图形表示。

图 4.12 中的框图显示了使用内部振荡器作为参考时通过仪器的信号路径。Signal Inputs（信号输入）和 Reference/Internal Frequency（参考/内部频率）显示在左侧。实际解调，即混合和低通滤波显示在选项卡的中心。在右下方，用户可以设置 Signal Output（信号输出）参数。右上角是与测量数据输出相关的设置，即通过数字方式（PC 数据传输）或模拟方式（辅助输出 1 到 4）输出。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//ad8cd1f5-2e28-42ca-9fd1-7152cca17dfc/markdown_0/imgs/img_in_image_box_216_777_1076_968.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A27Z%2F-1%2F%2F00f914d32787629af56483296a11534f5f411f60b827ccd9198254b5b25e5baa" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.12. LabOne 用户界面的 Lock-in（锁相）选项卡 - Internal Reference（内部参考）模式下的图形 Lock-in（锁相）选项卡</div> </div>


图 4.13 中的框图显示了使用外部参考时通过仪器的信号路径。左侧描述了 Signal Input（信号输入），混频器和低通滤波器的解调核心以及 External Reference（外部参考）位于选项卡的中心，Signal Outputs（信号输出）、Auxiliary Outputs（辅助输出）以及“数据传输到 PC”显示在右侧。

#### 注释

要在 Internal Reference（内部参考）模式和 External Reference（外部参考）模式之间切换，请单击该部分的标签。标签旁边的“+”符号用于访问参考相位设置。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//ad8cd1f5-2e28-42ca-9fd1-7152cca17dfc/markdown_1/imgs/img_in_image_box_216_112_1074_403.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A27Z%2F-1%2F%2Ff531c073bc5930b0c8b54109f7e90b237580e0983e6fdc49bf46b4727613933c" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.13. LabOne 用户界面 Lock-in（锁相）选项卡 - External Reference（外部参考）模式下的图形 Lock-in（锁相）选项卡</div> </div>


#### 4.3.3. 功能元素

<div style="text-align: center;"><div style="text-align: center;">表 4.13. Lock-in（锁相）选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td rowspan="2">50 \Omega</td><td style='text-align: center; word-wrap: break-word;'>OFF: 10 M \Omega</td><td rowspan="2">在 50 \Omega (ON) 和 10 M \Omega (OFF) 之间进行切换。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>ON: 50 \Omega</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Float</td><td style='text-align: center; word-wrap: break-word;'>ON: 浮动</td><td style='text-align: center; word-wrap: break-word;'>在浮动(ON)和接地(OFF)之间进行切换。此设置适用于电压和电流输入。建议在连接前对测试设备进行放电或仅当信号源在接地模式下连接至信号输入后启用此设置。</td></tr><tr><td rowspan="2">Range</td><td rowspan="2">3.0 mV、10 mV、30 mV、100 mV、300 mV、1 V、3.0 V</td><td style='text-align: center; word-wrap: break-word;'>定义模拟输入放大器的增益。该范围应为输入信号的两倍左右，包括潜在的直流偏移量。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>仪器会相对于用户插入的值选择下一个较大的可用范围。适当选择此设置可通过确保使用输入ADC的完整动态范围，从而优化精度和信噪比。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>On</td><td style='text-align: center; word-wrap: break-word;'>ON / OFF</td><td style='text-align: center; word-wrap: break-word;'>启用 Signal Input（信号输入）。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Auto</td><td style='text-align: center; word-wrap: break-word;'>☒</td><td style='text-align: center; word-wrap: break-word;'>将 Range（范围）自动调整为约 100 ms 时间内测量的最大信号输入幅值的两倍左右。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Scaling</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>对输入信号进行任意比例的缩放。</td></tr><tr><td rowspan="2">Measurement Unit</td><td rowspan="2">单位首字母缩略词</td><td style='text-align: center; word-wrap: break-word;'>定义输入信号的物理单位。使用 *、/ 和 ^ 运算符，例如 m 或 m/s^2。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>此字段中的值会修改用户界面中所有测量工具的读数。该字段的典型用途是在传感器/换能器之前按此单位进行测量，例如将跨阻抗放大器考虑在内并直接以 A 为单位（而非 V）读取结果。</td></tr><tr><td rowspan="2">AC</td><td style='text-align: center; word-wrap: break-word;'>ON: 交流耦合</td><td rowspan="2">定义信号输入的输入耦合。交流耦合会插入一个高通滤波器。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>OFF: 直流耦合</td></tr><tr><td rowspan="2">Diff</td><td style='text-align: center; word-wrap: break-word;'>OFF: 单端电压输入</td><td rowspan="2">在单端(OFF)和差分(ON)测量之间进行切换。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>ON: 差分电压输入</td></tr><tr><td rowspan="7">Range</td><td style='text-align: center; word-wrap: break-word;'>1 nA (*)</td><td style='text-align: center; word-wrap: break-word;'>定义电流输入放大器的增益。该范围应为输入信号的两倍左右，包括潜在的直流偏移量。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>10 nA</td><td rowspan="2"></td></tr><tr><td style='text-align: center; word-wrap: break-word;'>100 nA (*)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>1 \mu A</td><td style='text-align: center; word-wrap: break-word;'>仪器会相对于用户插入的值选择下一个较大的可用范围。适当选择此设置可确保使用输入ADC的完整动态范围，从而优化精度和信噪比。标有</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>10 \mu A</td><td style='text-align: center; word-wrap: break-word;'></td></tr><tr><td style='text-align: center; word-wrap: break-word;'>100 \mu A</td><td rowspan="2"></td></tr><tr><td style='text-align: center; word-wrap: break-word;'>1 mA (*)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>10 mA</td><td style='text-align: center; word-wrap: break-word;'>星号(*)的范围仅适用于序列号为MF-DEV3200及以上的仪器。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Auto</td><td style='text-align: center; word-wrap: break-word;'>☒</td><td style='text-align: center; word-wrap: break-word;'>将Range（范围）自动调整为约100 ms时间内测量的最大电流输入幅值的两倍左右。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Scaling</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>对电流输入进行任意比例的缩放。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Measurement Unit</td><td style='text-align: center; word-wrap: break-word;'>单位首字母缩略词</td><td style='text-align: center; word-wrap: break-word;'>定义电流输入的物理单位。使用*、/和^运算符，例如m或m/s^2</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>此字段中的值会修改用户界面中所有测量工具的读数。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Mode</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>指示如何控制相应振荡器的频率（手动或外部参考）。只读标志。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Manual</td><td style='text-align: center; word-wrap: break-word;'>通过用户设置定义振荡器频率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>ExtRef</td><td style='text-align: center; word-wrap: break-word;'>直接使用外部参考频率作为振荡器频率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Frequency (Hz)</td><td style='text-align: center; word-wrap: break-word;'>0至5 MHz</td><td style='text-align: center; word-wrap: break-word;'>控制各振荡器的频率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Locked</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>振荡器接通后锁定到外部参考频率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Harm</td><td style='text-align: center; word-wrap: break-word;'>1至1023</td><td style='text-align: center; word-wrap: break-word;'>在外部参考模式下将解调器的参考频率除以某一整数因子。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Mode</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择参考模式（手动或外部参考）或指示使用解调器的单元（例如PLL）。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>ExtRef Low BW</td><td style='text-align: center; word-wrap: break-word;'>解调器用于外部参考模式并跟踪所选参考输入的频率。将解调器带宽设置为一个固定的低值。当由于自动带宽调整的干扰而导致无法稳定地锁定在一个固定频率时使用。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>ExtRef High BW</td><td style='text-align: center; word-wrap: break-word;'>解调器用于外部参考模式并跟踪所选参考输入的频率。将解调器带宽设置为一个固定的高值。当由于自动带宽调整的干扰而导致所跟踪的频率剧烈波动时使用。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>PLL</td><td style='text-align: center; word-wrap: break-word;'>解调器用于在PLL模式下跟踪信号频率。此功能需要使用MF-PID选件。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>IA</td><td style='text-align: center; word-wrap: break-word;'>解调器由阻抗分析仪使用。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Manual</td><td style='text-align: center; word-wrap: break-word;'>默认Lock-in（锁相）工作模式，采用手动设置的参考频率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>ExtRef</td><td style='text-align: center; word-wrap: break-word;'>解调器用于外部参考模式并跟踪所选参考输入的频率。自动设置解调器带宽以适应信号属性。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Osc</td><td style='text-align: center; word-wrap: break-word;'>振荡器索引</td><td style='text-align: center; word-wrap: break-word;'>将所选振荡器与对应于该线路的解调器相连。可用振荡器的数量取决于安装的选件。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Harm</td><td style='text-align: center; word-wrap: break-word;'>1至1023</td><td style='text-align: center; word-wrap: break-word;'>将解调器的参考频率与该字段定义的整数因子相乘。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>如果在外部参考模式（PLL）下将解调器用作相位检测器，则效果为内部振荡器锁定到外部频率除以该整数因子后所得到的频率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Demod Freq (Hz)</td><td style='text-align: center; word-wrap: break-word;'>0至5 MHz</td><td style='text-align: center; word-wrap: break-word;'>指示用于解调和生成输出的频率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>通过将振荡器频率乘以谐波因子来计算解调频率。当使用MF-MOD选件时，通过振荡器频率（包括谐波因子）的线性组合来定义解调频率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Phase (deg)</td><td style='text-align: center; word-wrap: break-word;'>-180°至180°</td><td style='text-align: center; word-wrap: break-word;'>应用到解调器参考输入的相移。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Zero</td><td style='text-align: center; word-wrap: break-word;'>☑</td><td style='text-align: center; word-wrap: break-word;'>自动调整解调器参考的相位，以便使解调器输出端的读数为零度。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>此操作将最大化X输出，使Y输出为零，使 \Theta 输出为零，并保持R输出不变。</td></tr><tr><td rowspan="12">Signal</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择要与解调器关联的信号源。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Curr In 1（电流输入 1）</td><td style='text-align: center; word-wrap: break-word;'>Current Input 1（电流输入 1）与相应的解调器相连。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Trigger 1（触发 1）</td><td style='text-align: center; word-wrap: break-word;'>Trigger 1（触发 1）与相应的解调器相连。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Trigger 2（触发 2）</td><td style='text-align: center; word-wrap: break-word;'>Trigger 2（触发 2）与相应的解调器相连。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Aux Out 1（辅助输出 1）</td><td style='text-align: center; word-wrap: break-word;'>Auxiliary Output 1（辅助输出 1）与相应的解调器相连。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Aux Out 2（辅助输出 2）</td><td style='text-align: center; word-wrap: break-word;'>Auxiliary Output 2（辅助输出 2）与相应的解调器相连。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Aux Out 3（辅助输出 3）</td><td style='text-align: center; word-wrap: break-word;'>Auxiliary Output 3（辅助输出 3）与相应的解调器相连。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Aux Out 4（辅助输出 4）</td><td style='text-align: center; word-wrap: break-word;'>Auxiliary Output 4（辅助输出 4）与相应的解调器相连。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Aux In 1（辅助输入 1）</td><td style='text-align: center; word-wrap: break-word;'>Auxiliary Input 1（辅助输入 1）与相应的解调器相连。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Aux In 2（辅助输入 2）</td><td style='text-align: center; word-wrap: break-word;'>Auxiliary Input 2（辅助输入 2）与相应的解调器相连。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Constant（常数）</td><td style='text-align: center; word-wrap: break-word;'>解调常数输入。这样会得到一个振幅为 1，频率由解调器的振荡器指定的正弦波（频率较低时；较高频率将会衰减）。最大可能频率受解调器采样率和带宽的限制；使用解调器 1 阶可使得解调器输出中的衰减最低。该信号可与辅助输出、PID 和阈值单元一起使用，用于高级测量和控制任务。当解调器输出被写入辅助输出时，所得到的信号也可以用作第二输出通道（用于低频）。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sig In 1（信号输入 1）</td><td style='text-align: center; word-wrap: break-word;'>Signal Input 1（信号输入 1）与相应的解调器相连。</td></tr><tr><td rowspan="9">Order</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>在 6 dB/oct 和 48 dB/oct 之间选择滤波器滚降系数。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>1 阶滤波器为 6 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>2</td><td style='text-align: center; word-wrap: break-word;'>2 阶滤波器为 12 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>3</td><td style='text-align: center; word-wrap: break-word;'>3 阶滤波器为 18 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>4</td><td style='text-align: center; word-wrap: break-word;'>4 阶滤波器为 24 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>5</td><td style='text-align: center; word-wrap: break-word;'>5 阶滤波器为 30 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>6</td><td style='text-align: center; word-wrap: break-word;'>6 阶滤波器为 36 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>7</td><td style='text-align: center; word-wrap: break-word;'>7 阶滤波器为 42 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>8</td><td style='text-align: center; word-wrap: break-word;'>8 阶滤波器为 48 dB/oct</td></tr><tr><td rowspan="4">TC/BW Select</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>定义低通滤波器的显示单位：时间常数（TC）的单位为秒，噪声等效功率带宽（BW NEP）的单位为 Hz，3 dB 带宽（BW 3 dB）的单位为 Hz。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>TC</td><td style='text-align: center; word-wrap: break-word;'>使用滤波器的时间常数定义低通滤波器特性。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>BW NEP</td><td style='text-align: center; word-wrap: break-word;'>使用滤波器的噪声等效功率带宽（Hz）定义低通滤波器特性。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>BW 3 dB</td><td style='text-align: center; word-wrap: break-word;'>使用滤波器的 3 dB 截止频率（Hz）定义低通滤波器特性。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>TC/BW Value</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>使用上面定义的单位来定义低通滤波器特性。</td></tr><tr><td rowspan="2">Sinc</td><td rowspan="2">ON / OFF</td><td style='text-align: center; word-wrap: break-word;'>启用 sinc 滤波器。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>当滤波器带宽与解调频率相当或大于解调频率时，解调器输出可以包含解调频率及其高次谐波的频率分量。Sinc 是一个附加滤波器，用于衰减解调器输出中这些不需要的分量。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Filter Lock</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>使所有解调器滤波器设置（阶数、时间常数、带宽）相同。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>启用锁定可将解调器1中的设置复制到所有其他解调器。此外，通过锁定滤波器，还可将针对滤波器设置进行的任何修改应用至所有其他滤波器。解除锁定不会更改任何设置。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Enable Streaming</td><td style='text-align: center; word-wrap: break-word;'>ON / OFF</td><td style='text-align: center; word-wrap: break-word;'>为相应的解调器启用对解调样本的数据采集并将解调样本流传输到主机。流传输速率在右侧字段中定义。启用流传输将激活Numeric（数值）选项卡中的相应元素，并允许在任何LabOne测量工具中显示和分析解调样本。请注意：随着激活的解调器数量的增加，主机物理连接的负载也会增加。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Rate (Sa/s)</td><td style='text-align: center; word-wrap: break-word;'>0.056 Sa/s 至 857 kSa/s</td><td style='text-align: center; word-wrap: break-word;'>定义解调器采样率，即每秒发送到主机的样本数。该速率通常为滤波器带宽的7-10倍左右时，可实现充足的混叠抑制。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>这也是LabOne数据服务器接收数据并保存到计算机硬盘的速率。此设置对辅助输出连接器上的采样率没有影响。请注意：用户插入的值可能会被近似处理为仪器所支持的最接近值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Demodulator Sampling Rate Lock</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>使所有解调器采样率相等。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>启用锁定可将解调器1中的设置复制到所有其他解调器。此外，通过锁定采样率，还可将针对采样率进行的任何修改应用至所有其他采样率字段。解除锁定不会更改任何设置。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Trigger</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择解调样本的采集模式。连续触发意味着以指示的速率将数据流传输到主机。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Trigger 1（触发 1）</td><td style='text-align: center; word-wrap: break-word;'>通过Trigger 1（触发 1）连接器选择外部触发。每次发生Trig Mode（触发模式）字段中定义的事件时，都将解调样本发送到主机。选择Edge trigger（边沿触发）时，Rate（速率）字段将呈灰显且无意义。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Trigger 2（触发 2）</td><td style='text-align: center; word-wrap: break-word;'>通过Trigger 2（触发 2）连接器选择外部触发。每次发生Trig Mode（触发模式）字段中定义的事件时，都将解调样本发送到主机。选择Edge trigger（边沿触发）时，Rate（速率）字段将呈灰显且无意义。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Trigger 1|2（触发 1|2）</td><td style='text-align: center; word-wrap: break-word;'>与上述功能相同，但基于Trigger 1（触发 1）和Trigger 2（触发 2）的逻辑OR函数的运算结果触发。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Continuous（连续）</td><td style='text-align: center; word-wrap: break-word;'>选择连续数据采集模式。以左侧指示的速率将解调样本流传输到主机。在连续模式下，数字和绘图仪工具将持续接收并显示新值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Trig Mode</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>为所选触发输入定义边沿触发或电平触发模式。请注意：只有在Trigger（触发）字段中选择了非连续触发时，才会显示此字段。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Rising（上升）</td><td style='text-align: center; word-wrap: break-word;'>选择在所选触发输入的上升沿触发的样本采集模式。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Falling（下降）</td><td style='text-align: center; word-wrap: break-word;'>选择在所选触发输入的下降沿触发的样本采集模式。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Both（两者）</td><td style='text-align: center; word-wrap: break-word;'>选择在所选触发输入的边沿触发的样本采集模式。</td></tr></table>













<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td rowspan="2"></td><td style='text-align: center; word-wrap: break-word;'>High（高电平）</td><td style='text-align: center; word-wrap: break-word;'>选择在所选触发输入为高电平时触发的连续样本采集模式。选择该项时，Samplerate（采样率）字段确定以何种频率将解调样本发送到主机。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Low（低电平）</td><td style='text-align: center; word-wrap: break-word;'>选择在所选触发输入为低电平时触发的连续样本采集模式。选择该项时，Samplerate（采样率）字段确定以何种频率将解调样本发送到主机。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Amplitude Unit</td><td style='text-align: center; word-wrap: break-word;'>Vpk、Vrms、dBm</td><td style='text-align: center; word-wrap: break-word;'>选择所显示幅值的单位。dBm值仅对采用50 \Omega 端接的系统有效。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Amp Mode</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>指示生成的波形的类型或源。“Sine”表示来自内部振荡器的正弦波形。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Amp Enable</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>启用单个输出信号幅值。当使用MF-MD选件时，可以生成由多个可用解调器频率线性组合的信号。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>50 \Omega</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>在50 \Omega 与HiZ之间选择负载阻抗。输出的阻抗始终为50 \Omega 。当负载阻抗为50 \Omega 时，显示的电压为输出电压的一半，以反映负载处的电压。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Auto Range</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>自动选择最适合的输出范围。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Output Clipping</td><td style='text-align: center; word-wrap: break-word;'>灰色/红色</td><td style='text-align: center; word-wrap: break-word;'>表示指定的输出幅值超出范围设置。此时会发生信号削波，输出信号质量也会下降。需要调整范围或输出幅值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Offset</td><td style='text-align: center; word-wrap: break-word;'>-Range至Range</td><td style='text-align: center; word-wrap: break-word;'>定义添加到输出信号动态部分的直流电压。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Add</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>将提供给AuxInput1（辅助输入1）的信号添加到信号输出。对于差分输出，添加的信号为共模偏移。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Diff</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>在单端输出（OFF）和差分输出（ON）之间切换。在差分模式下，将信号摆幅定义为信号输出+V/-V之间。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>On</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>仪器前面板上蓝色LED指示灯所对应的Signal Output（信号输出）的主开关。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Range</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>定义相应Signal Output（信号输出）所生成的最大输出电压。其中包括可能的多个Signal Amplitude（信号幅值）和Offset（偏移量）总和。选择可能的最小范围以优化信号质量。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>此设置可确保生成的电压或峰值不会高于设定值，所以用于限制用户可输入的输出幅值。因此，选定的输出幅值将被限制在定义的时间内，且限幅指示灯会亮起。如果启用50 \Omega 目标源或差分输出，可能的最大输出范围将会折半。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>10 mV</td><td style='text-align: center; word-wrap: break-word;'>选择输出范围 \pm 10 mV。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>100 mV</td><td style='text-align: center; word-wrap: break-word;'>选择输出范围 \pm 100 mV。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>1 V</td><td style='text-align: center; word-wrap: break-word;'>选择输出范围 \pm 1 V。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>10 V</td><td style='text-align: center; word-wrap: break-word;'>选择输出范围 \pm 10 V。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Output</td><td style='text-align: center; word-wrap: break-word;'>-Range至Range</td><td style='text-align: center; word-wrap: break-word;'>将输出幅值定义为rms或峰峰值。幅值为负值相当于相位变化180度。</td></tr></table>

### 4.4. Lock-in（锁相）选项卡（MF-MD 选件）

该选项卡是安装了 MF-MD 多解调器选件的 MFLI 仪器的锁相放大器主控制面板。仪器未安装此选件的用户请参阅第 4.3 节。

#### 4.4.1. 特征

一 可访问主要输入、输出和解调器控件的功能框图

一 具有主要输入、输出和解调器控件的参数表

一 4 个可单独配置的解调器的控件

一 用于两个输入通道的自动调整量程、缩放、任意输入单位

一 4 个振荡器的控件

一 主信号输入和信号输出的设置

一 选择参考源、触发选件和数据传输率

#### 4.4.2. 描述

Lock-in（锁相）选项卡是仪器的主控制中心，默认启动后打开。当该选项卡关闭或需要其他相同类型的选项卡时，单击以下图标即可打开该选项卡的新实例。

<div style="text-align: center;"><div style="text-align: center;">表 4.14. 应用图标和简要描述</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock-in MD</td><td style='text-align: center; word-wrap: break-word;'>☒</td><td style='text-align: center; word-wrap: break-word;'>快速纵览和访问关于信号生成及解调的所有设置和属性。</td></tr></table>

Lock-in（锁相）选项卡的默认视图是参数表视图。可以在标有 All（全部）的侧边栏选项卡下访问，该视图提供用于仪器中所有解调器的控件。此外，每个单独的解调器都有一个可用的功能框图。可以在标有相应解调器编号的侧边栏选项卡下访问功能框图。

##### 参数表

参数表（参见图 4.14）包含 5 个部分：Signal Inputs（信号输入）、Oscillators（振荡器）、Demodulators（解调器）、Output Amplitudes（输出振幅）和 Signal Outputs（信号输出）。Demodulator（解调器）部分包含 4 行，每行都提供对于一个双相解调器设置的访问权限。Demodulator 2（解调器 2）和 Demodulator 4（解调器 4）可用于外部参考。每个解调器都可以连接到任何可能的输入和振荡器。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//dbe754ff-2c16-4891-9d7f-71369d184836/markdown_1/imgs/img_in_image_box_216_1142_1074_1338.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A48Z%2F-1%2F%2Fafa536f1539a34749de9436f2b6b85b8a651215cb525db67c541b80c489ba3e4" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.14. LabOne 用户界面的 Lock-in（锁相）选项卡（已安装 MF-MD 多解调器选件）。</div> </div>


Signal Inputs（信号输入）部分允许用户定义输入信号的所有相关设置，例如输入耦合、范围等。一些可用选项，如相位调整和触发功能，在默认情况下处于折叠状态。只需在“+”图标上单击鼠标即可展开这些控件。在 Lock-in（锁相）选项卡的右侧，Signal Outputs（信号输出）部分可以定义信号幅值、偏移值和范围值。

Range（范围）字段下方的 Scaling（缩放）字段可用于将 Signal Input（信号输入）数据相乘，例如表示外部放大器的增益。如果外部输入信号有 10 V/A 的跨阻增益，则可将 Scaling（缩放）字段设置为 0.1，将 Units（单位）字段设置为 A，以便通过整个用户界面来显示实际电流读数。

在 Scaling（缩放）字段下方有两个可以切换的按钮：AC/DC（交流/直流）按钮和 50 Ω/10 MΩ 按钮。AC/DC（交流/直流）按钮用来设置耦合类型：交流耦合具有高通截止频率，可用于阻挡大的直流信号分量，以防止放大期间输入信号饱和。50 Ω/10 MΩ 按钮在低 (50 Ω) 和高（约 10 MΩ）输入阻抗之间切换输入阻抗。对于 50 Ω 输入阻抗，如果信号源也具有 50 Ω 输出阻抗，则预计测量信号会减少 2 倍。

##### 注释

Signal Inputs（信号输入）可以设置为浮动，这意味着 BNC 连接器屏蔽不再连接到仪器接地端。该设置会影响电流输入和电压输入。建议在连接前对测试设备进行放电或仅当信号源在接地模式下连接至信号输入后启用此设置。

Oscillator（振荡器）部分指示 4 个内部振荡器的频率。当 Mode（模式）指示器显示 Manual（手动）时，用户可以通过在字段中键入频率值来手动定义振荡器频率。如果振荡器参考外部源，Mode（模式）指示器将显示 ExtRef（外部参考），并且频率字段设置为只读。外部参考需要一个 PLL 来将频率映射到内部振荡器上。频率字段旁边的绿灯表示锁定成功。

下一部分包含 Demodulators（解调器）设置。图 4.15 中的框图显示主要解调器元件及其相互之间的连接。了解如何接线对于成功操作仪器至关重要。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//dbe754ff-2c16-4891-9d7f-71369d184836/markdown_2/imgs/img_in_image_box_236_792_1043_1110.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A50Z%2F-1%2F%2Fab25385e9445a4765ee90ad65c872e31f42b88e2cfb2fbfec693d5cd665fa6c0" alt="Image" width="67%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.15. 已安装 MF-MD 多解调器选件的解调器框图。</div> </div>


Demodulators（解调器）部分中的每一行代表一个解调器。Mode（模式）列对于除 2 和 4 之外的所有解调器都是只读的，可以设置为内部参考（Demod）或外部参考模式（ExtRef）。选择内部参考模式时，可以使用 4 个解调器以 4 个独立频率和不同的滤波器设置来同时解调输入信号。对于外部参考模式，一个解调器用于参考恢复，一些设置呈灰显，因此要保留 3 个解调器用于同时测量。在 Input Signal（输入信号）列中，一列定义了作为解调器输入的信号。可以选择多种信号：Signal Inputs（信号输入）、Trigger Inputs（触发输入）、Auxiliary Inputs（辅助输入）和 Auxiliary Outputs（辅助输出）。这样仪器就可以用于许多不同的测量拓扑。

对于每个解调器，通过在 Phase（相位）列中输入相移，可以将额外的相移引入相关的振荡器。该相位被添加到参考通道和解调器的输出。因此，当使用相同的解调器生成和检测频率时，信号相位和参考相位进行等量变化并且解调结果中看不到任何变化。通过在 Harm（谐波）列中输入所需的因子来实现对任何振荡器频率整数倍的频率解调。可以使用第 4.5 节中描述的 Numeric（数值）选项卡获得解调器读数。

在 Lock-in（锁相）选项卡的中间是 Low-Pass Filters（低通滤波器）部分，在该部分中，可以在下拉列表中为每个解调器选择滤波器阶数，并且可通过键入数值来选择滤波器带宽（BW 3dB）。或者，可以通过单击列标题来选择滤波器的时间常数（TC）或噪声等效功率滤波器带宽（BW NEP）。例如，将滤波器阶数设置为 4，相当于 24 dB/oct 或 80 dB/dec 的滚降系数，即频率增加十倍，衰减 10⁴。当 Low-Pass Filter（低通滤波器）带宽与解调频率相当或大于解调频率时，解调器输出可以包含解调频率及其高次谐波的频率分量。在这种情况下，可启用额外的 Sinc Filter（Sinc 滤波器）。它会衰减解调器输出中那些不需要的谐波分量。Sinc Filter（Sinc 滤波器）还适用于低频测量，因为它允许适用更接近解调频率的 Low-Pass Filter（低通滤波器）带宽，从而加快测量时间。

解调器输出的数据传输由 Data Transfer（数据传输）部分中的 En 按钮激活，其中还可以定义每个解调器的采样率（Rate（速率））。

Data Transfer（数据传输）旁边的 Trigger（触发）部分允许设置触发条件，以便通过将逻辑信号（例如 TTL）应用到后面板上的 Trigger Input 1 或 Trigger Input 2 来控制和启动从仪器到主机 PC 的数据传输。

Output Amplitudes（输出幅值）部分仅适用于安装了 MF-MD 选件的仪器，并可以灵活调整不同解调器的输出幅值及其在 Signal Output（信号输出）上的总和。为了避免信号削波，每个信号输出的幅值总和需要小于右侧 Signal Outputs（信号输出）部分中定义的范围。当信号输出部分中的 50 Ω 选项被激活时，通过单击每一列的标题，可以从均方根值、峰峰值，甚至 dBm 单位等方面对幅值定义进行切换。在 Signal Outputs（信号输出）部分，On（打开）按钮用于激活前面板上的 Signal Output（信号输出）。Range（范围）下拉列表用于选择正确的输出范围设置。在 Signal Output（信号输出）上可以定义数字偏移电压（Offset（偏移））。允许的最大输出信号为 PLUSMINUS10 V。

##### 框图

主要仪器功能的框图视图有时也称为“图形 Lock-in（锁相）选项卡”。根据仪器中可用的解调器数量，提供一组带编号的侧边栏选项卡，可以通过这些选项卡访问每个解调器的图形 Lock-in（锁相）选项卡。框图功能齐全，可为用户提供仪器内部情况的视觉反馈。上一节详述的参数表中可用的所有控件元素也以图形表示。

图 4.16 中的框图描述了使用内部振荡器作为参考时通过仪器的信号路径。左侧描述了 Signal Inputs（信号输入）和 Reference/Internal Frequency（参考/内部频率）、混频器和低通滤波器的解调核心位于选项卡的中心，Signal Outputs（信号输出）、Auxiliary Outputs（辅助输出）以及“数据传输到 PC”显示在右侧。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//dbe754ff-2c16-4891-9d7f-71369d184836/markdown_3/imgs/img_in_image_box_215_985_1075_1176.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A51Z%2F-1%2F%2Fa2963b46f99232e2f0a7948739eb15d8f012a11c14182f0f39a4411ad5fcfeaf" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.16. LabOne 用户界面的 Lock-in（锁相）选项卡 - Internal Reference（内部参考）模式下的图形 Lock-in（锁相）选项卡</div> </div>


图 4.17 中的框图描述了使用外部参考时通过仪器的信号路径。此设置仅适用于解调器 2/4。要将外部频率映射到任何振荡器，请转到解调器 2/4 的 Reference（参考）部分并将模式更改为 ExtRef（外部参考）。该解调器随后将用作锁相环内的相位检测器。软件将根据参考信号的频率和属性选择合适的滤波器设置。一旦使用解调器将外部频率映射到其中一个内部振荡器，它就不再能用于其他测量。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//dbe754ff-2c16-4891-9d7f-71369d184836/markdown_4/imgs/img_in_image_box_215_112_1075_303.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A52Z%2F-1%2F%2Fb064e92e7f00351c397bab0581de1e3ca1b559e03abf89d7f4ce5a7254a12973" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.17. LabOne 用户界面 Lock-in（锁相）选项卡 - External Reference（外部参考）模式下的图形 Lock-in（锁相）选项卡</div> </div>


#### 4.4.3. 功能元素

<div style="text-align: center;"><div style="text-align: center;">表 4.15. Lock-in MF 选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td rowspan="2">50 \Omega</td><td style='text-align: center; word-wrap: break-word;'>OFF: 10 M \Omega</td><td rowspan="2">在 50 \Omega (ON) 和 10 M \Omega (OFF) 之间进行切换。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>ON: 50 \Omega</td></tr><tr><td rowspan="2">Float</td><td style='text-align: center; word-wrap: break-word;'>ON: 浮动</td><td rowspan="2">在浮动 (ON) 和接地 (OFF) 之间进行切换。此设置适用于电压和电流输入。建议在连接前对测试设备进行放电或仅当信号源在接地模式下连接至信号输入后启用此设置。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>OFF: 接地</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Range</td><td style='text-align: center; word-wrap: break-word;'>3.0 mV、10 mV、30 mV、100 mV、300 mV、1 V、3.0 V</td><td style='text-align: center; word-wrap: break-word;'>定义模拟输入放大器的增益。该范围应为输入信号的两倍左右，包括潜在的直流偏移量。仪器会相对于用户插入的值选择下一个较大的可用范围。适当选择此设置可通过确保使用输入ADC的完整动态范围，从而优化精度和信噪比。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>On</td><td style='text-align: center; word-wrap: break-word;'>ON / OFF</td><td style='text-align: center; word-wrap: break-word;'>启用 Signal Input（信号输入）。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Auto</td><td style='text-align: center; word-wrap: break-word;'>☒</td><td style='text-align: center; word-wrap: break-word;'>将 Range（范围）自动调整为约 100 ms 时间内测量的最大信号输入幅值的两倍左右。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Scaling</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>对输入信号进行任意比例的缩放。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Measurement Unit</td><td style='text-align: center; word-wrap: break-word;'>单位首字母缩略词</td><td style='text-align: center; word-wrap: break-word;'>定义输入信号的物理单位。使用 *、/ 和 ^ 运算符，例如 m 或 m/s^2。此字段中的值会修改用户界面中所有测量工具的读数。该字段的典型用途是在传感器/换能器之前按此单位进行测量，例如将跨阻抗放大器考虑在内并直接以 A 为单位（而非 V）读取结果。</td></tr><tr><td rowspan="2">AC</td><td style='text-align: center; word-wrap: break-word;'>ON: 交流耦合</td><td rowspan="2">定义 Signal Inputs（信号输入）的输入耦合。交流耦合会插入一个高通滤波器。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>OFF: 直流耦合</td></tr><tr><td rowspan="2">Diff</td><td style='text-align: center; word-wrap: break-word;'>OFF: 单端电压输入</td><td rowspan="2">在单端 (OFF) 和差分 (ON) 测量之间进行切换。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>ON: 差分电压输入</td></tr><tr><td rowspan="8">Range</td><td style='text-align: center; word-wrap: break-word;'>1 nA (*)</td><td rowspan="8">定义电流输入放大器的增益。该范围应为输入信号的两倍左右，包括潜在的直流偏移量。仪器会相对于用户插入的值选择下一个较大的可用范围。适当选择此设置可确保使用输入 ADC 的完整动态范围，从而优化精度和信噪比。标有星号 (*) 的范围仅适用于序列号为 MF-DEV3200 及以上的仪器。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>10 nA</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>100 nA (*)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>1 \mu A</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>10 \mu A (*)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>100 \mu A</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>1 mA (*)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>10 mA</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Auto</td><td style='text-align: center; word-wrap: break-word;'>☒</td><td style='text-align: center; word-wrap: break-word;'>将 Range（范围）自动调整为约 100 ms 时间内测量的最大电流输入幅值的两倍左右。</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">4.4 Lock-in（锁相）选项卡（MF-MD 选件）</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Scaling</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>对电流输入进行任意比例的缩放。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Measurement Unit</td><td style='text-align: center; word-wrap: break-word;'>单位首字母缩略词</td><td style='text-align: center; word-wrap: break-word;'>定义电流输入的物理单位。使用*、/和^运算符，例如m或m/s^2</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>此字段中的值会修改用户界面中所有测量工具的读数。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Mode</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>指示如何控制相应振荡器的频率（手动或外部参考）。只读标志。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Manual（手动）</td><td style='text-align: center; word-wrap: break-word;'>通过用户设置定义振荡器频率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>ExtRef（外部参考）</td><td style='text-align: center; word-wrap: break-word;'>直接使用外部参考频率作为振荡器频率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Frequency (Hz)</td><td style='text-align: center; word-wrap: break-word;'>0至5MHz</td><td style='text-align: center; word-wrap: break-word;'>控制各振荡器的频率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Locked</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>振荡器接通后锁定到外部参考频率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Harm</td><td style='text-align: center; word-wrap: break-word;'>1至1023</td><td style='text-align: center; word-wrap: break-word;'>在外部参考模式下将解调器的参考频率除以某一整数因子。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Mode</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择参考模式（手动或外部参考）或指示使用解调器的单元（例如PLL）。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>ExtRef Low BW</td><td style='text-align: center; word-wrap: break-word;'>解调器用于外部参考模式并跟踪所选参考输入的频率。将解调器带宽设置为一个固定的低值。当由于自动带宽调整的干扰而导致无法稳定地锁定在一个固定频率时使用。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>ExtRef High BW</td><td style='text-align: center; word-wrap: break-word;'>解调器用于外部参考模式并跟踪所选参考输入的频率。将解调器带宽设置为一个固定的高值。当由于自动带宽调整的干扰而导致所跟踪的频率剧烈波动时使用。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>PLL</td><td style='text-align: center; word-wrap: break-word;'>解调器用于在PLL模式下跟踪信号频率。此功能需要使用MF-PID选件。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>IA</td><td style='text-align: center; word-wrap: break-word;'>解调器由阻抗分析仪使用。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Manual</td><td style='text-align: center; word-wrap: break-word;'>默认Lock-in（锁相）工作模式，采用手动设置的参考频率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>ExtRef</td><td style='text-align: center; word-wrap: break-word;'>解调器用于外部参考模式并跟踪所选参考输入的频率。自动设置解调器带宽以适应信号属性。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Osc</td><td style='text-align: center; word-wrap: break-word;'>振荡器索引</td><td style='text-align: center; word-wrap: break-word;'>将所选振荡器与对应于该线路的解调器相连。可用振荡器的数量取决于安装的选件。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Harm</td><td style='text-align: center; word-wrap: break-word;'>1至1023</td><td style='text-align: center; word-wrap: break-word;'>将解调器的参考频率与该字段定义的整数因子相乘。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>如果在外部参考模式（PLL）下将解调器用作相位检测器，则效果为内部振荡器锁定到外部频率除以该整数因子后所得到的频率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Demod Freq (Hz)</td><td style='text-align: center; word-wrap: break-word;'>0至5MHz</td><td style='text-align: center; word-wrap: break-word;'>指示用于解调和生成输出的频率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>通过将振荡器频率乘以谐波因子来计算解调频率。当使用MF-MOD选件时，通过振荡器频率（包括谐波因子）的线性组合来定义解调频率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Phase (deg)</td><td style='text-align: center; word-wrap: break-word;'>-180°至180°</td><td style='text-align: center; word-wrap: break-word;'>应用到解调器参考输入的相移。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Zero</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>自动调整解调器参考的相位，以便使解调器输出端的读数为零度。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>此操作将最大化X输出，使Y输出为零，使 \Theta 输出为零，并保持R输出不变。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Signal</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择要与解调器关联的信号源。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Curr In 1（电流输入）</td><td style='text-align: center; word-wrap: break-word;'>Current Input 1（电流输入 1）与相应的解调器相连。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Trigger 1（触发 1）</td><td style='text-align: center; word-wrap: break-word;'>Trigger 1（触发 1）与相应的解调器相连。</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">4.4 Lock-in（锁相）选项卡（MF-MD 选件）</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Trigger 2（触发 2）</td><td style='text-align: center; word-wrap: break-word;'>Trigger 2（触发 2）与相应的解调器相连。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Aux Out 1（辅助输出 1）</td><td style='text-align: center; word-wrap: break-word;'>Auxiliary Output 1（辅助输出 1）与相应的解调器相连。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Aux Out 2（辅助输出 2）</td><td style='text-align: center; word-wrap: break-word;'>Auxiliary Output 2（辅助输出 2）与相应的解调器相连。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Aux Out 3（辅助输出 3）</td><td style='text-align: center; word-wrap: break-word;'>Auxiliary Output 3（辅助输出 3）与相应的解调器相连。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Aux Out 4（辅助输出 4）</td><td style='text-align: center; word-wrap: break-word;'>Auxiliary Output 4（辅助输出 4）与相应的解调器相连。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Aux In 1（辅助输入 1）</td><td style='text-align: center; word-wrap: break-word;'>Auxiliary Input 1（辅助输入 1）与相应的解调器相连。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Aux In 2（辅助输入 2）</td><td style='text-align: center; word-wrap: break-word;'>Auxiliary Input 2（辅助输入 2）与相应的解调器相连。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Constant（常数）</td><td style='text-align: center; word-wrap: break-word;'>解调常数输入。这样会得到一个振幅为 1，频率由解调器的振荡器指定的正弦波（频率较低时；较高频率将会衰减）。最大可能频率受解调器采样率和带宽的限制；使用解调器 1 阶可使得解调器输出中的衰减最低。该信号可与辅助输出、PID 和阈值单元一起使用，用于高级测量和控制任务。当解调器输出被写入辅助输出时，所得到的信号也可以用作第二输出通道（用于低频）。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Sig In 1（信号输入 1）</td><td style='text-align: center; word-wrap: break-word;'>Signal Input 1（信号输入 1）与相应的解调器相连。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Order</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>在 6 dB/oct 和 48 dB/oct 之间选择滤波器滚降系数。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>1 阶滤波器为 6 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>2</td><td style='text-align: center; word-wrap: break-word;'>2 阶滤波器为 12 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>3</td><td style='text-align: center; word-wrap: break-word;'>3 阶滤波器为 18 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>4</td><td style='text-align: center; word-wrap: break-word;'>4 阶滤波器为 24 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>5</td><td style='text-align: center; word-wrap: break-word;'>5 阶滤波器为 30 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>6</td><td style='text-align: center; word-wrap: break-word;'>6 阶滤波器为 36 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>7</td><td style='text-align: center; word-wrap: break-word;'>7 阶滤波器为 42 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>8</td><td style='text-align: center; word-wrap: break-word;'>8 阶滤波器为 48 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>TC/BW Select</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>定义低通滤波器的显示单位：时间常数（TC）的单位为秒，噪声等效功率带宽（BW NEP）的单位为 Hz，3 dB 带宽（BW 3 dB）的单位为 Hz。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>TC</td><td style='text-align: center; word-wrap: break-word;'>使用滤波器的时间常数定义低通滤波器特性。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>BW NEP</td><td style='text-align: center; word-wrap: break-word;'>使用滤波器的噪声等效功率带宽（Hz）定义低通滤波器特性。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>BW 3 dB</td><td style='text-align: center; word-wrap: break-word;'>使用滤波器的 3 dB 截止频率（Hz）定义低通滤波器特性。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>TC/BW Value</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>使用上面定义的单位来定义低通滤波器特性。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sinc</td><td style='text-align: center; word-wrap: break-word;'>ON / OFF</td><td style='text-align: center; word-wrap: break-word;'>启用 sinc 滤波器。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>当滤波器带宽与解调频率相当或大于解调频率时，解调器输出可以包含解调频率及其高次谐波的频率分量。Sinc 是一个附加滤波器，用于衰减解调器输出中这些不需要的分量。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Filter Lock</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>使所有解调器滤波器设置（阶数、时间常数、带宽）相同。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>启用锁定可将解调器 1 中的设置复制到所有其他解调器。此外，通过锁定滤波器，还可将针对滤</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">4.4 Lock-in（锁相）选项卡（MF-MD 选件）</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>波器设置进行的任何修改应用至所有其他滤波器。解除锁定不会更改任何设置。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Enable Streaming</td><td style='text-align: center; word-wrap: break-word;'>ON / OFF</td><td style='text-align: center; word-wrap: break-word;'>为相应的解调器启用对解调样本的数据采集并将解调样本流传输到主机。流传输速率在右侧字段中定义。启用流传输将激活 Numeric（数值）选项卡中的相应元素，并允许在任何 LabOne 测量工具中显示和分析解调样本。请注意：随着激活的解调器数量的增加，主机物理连接的负载也会增加。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Rate (Sa/s)</td><td style='text-align: center; word-wrap: break-word;'>0.056 Sa/s 至 857 kSa/s</td><td style='text-align: center; word-wrap: break-word;'>定义解调器采样率，即每秒发送到主机的样本数。该速率通常为滤波器带宽的 7-10 倍左右时，可实现充足的混叠抑制。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>这也是 LabOne 数据服务器接收数据并保存到计算机硬盘的速率。此设置对辅助输出连接器上的采样率没有影响。请注意：用户插入的值可能会被近似处理为仪器所支持的最接近值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Demodulator Sampling Rate Lock</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>使所有解调器采样率相等。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>启用锁定可将解调器 1 中的设置复制到所有其他解调器。此外，通过锁定采样率，还可将针对采样率进行的任何修改应用至所有其他采样率字段。解除锁定不会更改任何设置。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Trigger</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择解调样本的采集模式。连续触发意味着以指示的速率将数据流传输到主机。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Trigger 1（触发 1）</td><td style='text-align: center; word-wrap: break-word;'>通过 Trigger 1（触发 1）连接器选择外部触发。每次发生 Trig Mode（触发模式）字段中定义的事件时，都将解调样本发送到主机。选择 Edge trigger（边沿触发）时，Rate（速率）字段将呈灰显且无意义。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Trigger 2（触发 2）</td><td style='text-align: center; word-wrap: break-word;'>通过 Trigger 2（触发 2）连接器选择外部触发。每次发生 Trig Mode（触发模式）字段中定义的事件时，都将解调样本发送到主机。选择 Edge trigger（边沿触发）时，Rate（速率）字段将呈灰显且无意义。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Trigger 1|2（触发 1|2）</td><td style='text-align: center; word-wrap: break-word;'>与上述功能相同，但基于 Trigger 1（触发 1）和 Trigger 2（触发 2）的逻辑 OR 函数的运算结果触发。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Continuous（连续模式）</td><td style='text-align: center; word-wrap: break-word;'>选择连续数据采集模式。以左侧指示的速率将解调样本流传输到主机。在连续模式下，数字和绘图仪工具将持续接收并显示新值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Trig Mode</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>为所选触发输入定义边沿触发或电平触发模式。请注意：只有在 Trigger（触发）字段中选择了非连续触发时，才会显示此字段。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Rising（上升）</td><td style='text-align: center; word-wrap: break-word;'>选择在所选触发输入的上升沿触发的样本采集模式。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Falling（下降）</td><td style='text-align: center; word-wrap: break-word;'>选择在所选触发输入的下降沿触发的样本采集模式。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Both（两者）</td><td style='text-align: center; word-wrap: break-word;'>选择在所选触发输入的边沿触发的样本采集模式。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>High（高电平）</td><td style='text-align: center; word-wrap: break-word;'>选择在所选触发输入为高电平时触发的连续样本采集模式。选择该项时，Sampler rate（采样率）字段确定以何种频率将解调样本发送到主机。</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">4.4 Lock-in（锁相）选项卡（MF-MD 选件）</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Low（低电平）</td><td style='text-align: center; word-wrap: break-word;'>选择在所选触发输入为低电平时触发的连续样本采集模式。选择该项时，Samplerate（采样率）字段确定以何种频率将解调样本发送到主机。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Amplitude Unit</td><td style='text-align: center; word-wrap: break-word;'>Vpk、Vrms、dBm</td><td style='text-align: center; word-wrap: break-word;'>选择所显示幅值的单位。dBm值仅对采用50 \Omega 端接的系统有效。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Amp Mode</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>指示生成的波形的类型或源。“Sine”表示来自内部振荡器的正弦波形。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Amp Enable</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>启用单个输出信号幅值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>当使用MF-MD选件时，可以生成由多个可用解调器频率线性组合的信号。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Amp (V)</td><td style='text-align: center; word-wrap: break-word;'>-Range至Range</td><td style='text-align: center; word-wrap: break-word;'>将每个解调器频率的输出幅值定义为rms或峰峰值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>幅值为负值相当于相位变化180度。同一输出中多个幅值设置的线性组合将被限制在范围设置内。请注意：用户插入的值可能会被近似处理为仪器所支持的最接近值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>50 \Omega</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>在50 \Omega 与HiZ之间选择负载阻抗。输出的阻抗始终为50 \Omega 。当负载阻抗为50 \Omega 时，显示的电压为输出电压的一半，以反映负载处的电压。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Auto Range</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>自动选择最适合的输出范围。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Output Clipping</td><td style='text-align: center; word-wrap: break-word;'>灰色/红色</td><td style='text-align: center; word-wrap: break-word;'>表示指定的输出幅值超出范围设置。此时会发生信号削波，输出信号质量也会下降。需要调整范围或输出幅值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Offset</td><td style='text-align: center; word-wrap: break-word;'>-Range至Range</td><td style='text-align: center; word-wrap: break-word;'>定义添加到输出信号动态部分的直流电压。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Add</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>将提供给AuxInput1（辅助输入1）的信号添加到信号输出。对于差分输出，添加的信号为共模偏移。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Diff</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>在单端输出（OFF）和差分输出（ON）之间切换。在差分模式下，将信号摆幅定义为信号输出+V/-V之间。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>On</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>仪器前面板上蓝色LED指示灯所对应的信号输出的主开关。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Range</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>定义相应SignalOutput（信号输出）所生成的最大输出电压。其中包括可能的多个SignalAmplitude（信号幅值）和Offset（偏移量）总和。选择可能的最小范围以优化信号质量。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>此设置可确保生成的电压或峰值不会高于设定值，所以用于限制用户可输入的输出幅值。因此，选定的输出幅值将被限制在定义的时间内，且限幅指示灯会亮起。如果启用50 \Omega 目标源或差分输出，可能的最大输出范围将会折半。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>10 mV</td><td style='text-align: center; word-wrap: break-word;'>选择输出范围 \pm 10 mV。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>100 mV</td><td style='text-align: center; word-wrap: break-word;'>选择输出范围 \pm 100 mV。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>1 V</td><td style='text-align: center; word-wrap: break-word;'>选择输出范围 \pm 1 V。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>10 V</td><td style='text-align: center; word-wrap: break-word;'>选择输出范围 \pm 10 V。</td></tr></table>

### 4.5. Numeric（数值）选项卡

Numeric（数值）选项卡提供强大的基于时域的测量显示，正如独特的分析工具组合中所述。该选项卡可用于所有 MFLI 仪器。

#### 4.5.1. 特征

一 显示解调器输出数据和其他流传输数据，例如辅助输入、解调器频率

一 图形和数值范围指示器

一 极坐标和笛卡尔坐标格式

一 支持输入缩放和输入单元

#### 4.5.2. 描述

Numeric（数值）选项卡用作多个测量数据的主要数值概览显示。可以通过选择显示的值以及通过拖放重新排列显示图块来配置显示。当该选项卡关闭或需要其他相同类型的选项卡时，单击以下图标即可打开该选项卡的新实例。

<div style="text-align: center;"><div style="text-align: center;">表 4.16. 应用图标和简要描述</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Numeric</td><td style='text-align: center; word-wrap: break-word;'>0.058</td><td style='text-align: center; word-wrap: break-word;'>访问所有连续流传输的测量数据（数值形式）。</td></tr></table>

Numeric（数值）选项卡（参见图 4.18）由左侧的显示部分和右侧的配置部分组成。配置部分还细分为多个子选项卡。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//56adf0d8-b80f-4ff2-8fdc-05bed65d63dd/markdown_4/imgs/img_in_image_box_218_836_1074_1126.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A39Z%2F-1%2F%2F43b7ab5e32abffbac13dc28a2bb8821fa14371eea82037037599badb1629eb70" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.18. LabOne UI: Numeric（数值）选项卡</div> </div>


Numeric（数值）选项卡可用于显示解调信号、相位、频率以及辅助输入处的信号电平。默认情况下，用户可以在极坐标（R,  $ \Theta $）或笛卡尔坐标（X, Y）中显示解调数据，使用预设进行切换。要显示任何预设中可用的其他测量物理量，只需单击预设选项卡旁边的树选项卡即可。可以在每个解调器的目录树状结构下选择所需的显示字段。

#### 4.5.3. 功能元素

<div style="text-align: center;"><div style="text-align: center;">表 4.17. Numeric（数值）选项卡：Presets（预设）子选项卡</div> </div>




<table border="1" style="margin: auto; word-wrap: break-word;"><tr><td style="text-align: center; word-wrap: break-word;">控件/工具</td><td style="text-align: center; word-wrap: break-word;">选项/范围</td><td style="text-align: center; word-wrap: break-word;">描述</td></tr><tr><td style="text-align: center; word-wrap: break-word;">选择预设</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">根据预设选择数值视图。或者，也可以基于树元素来选择显示的值。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Enabled Impedances（启用阻抗）</td><td style="text-align: center; word-wrap: break-word;">显示阻抗、模型参数和频率。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">PID Errors（PID 误差）</td><td style="text-align: center; word-wrap: break-word;">显示所有 PID 的误差。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Demods Polar（解调器极坐标）</td><td style="text-align: center; word-wrap: break-word;">显示所有解调器的 R 和 Phase（相位）。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Enabled Demods Polar（启用解调器极坐标）</td><td style="text-align: center; word-wrap: break-word;">显示已启用的解调器的 R 和 Phase（相位）。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Demods Cartesian（解调器笛卡尔坐标）</td><td style="text-align: center; word-wrap: break-word;">显示所有解调器的 X 和 Y。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Enabled Demods Cartesian（启用解调器笛卡尔坐标）</td><td style="text-align: center; word-wrap: break-word;">显示已启用的解调器的 X 和 Y。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Demods R（解调器 R）</td><td style="text-align: center; word-wrap: break-word;">显示所有解调器的 R。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Unpopulated（无信号）</td><td style="text-align: center; word-wrap: break-word;">不显示信号。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Manual（手动）</td><td style="text-align: center; word-wrap: break-word;">如果添加或删除其他信号，则活动预设将变为手动。</td></tr></table>




对于 Tree（树）子选项卡，请参阅“树状选择器”一节。

<div style="text-align: center;"><div style="text-align: center;">表 4.18.Numeric（数值）选项卡：Settings（设置）子选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Name</td><td style='text-align: center; word-wrap: break-word;'>文本标签</td><td style='text-align: center; word-wrap: break-word;'>所选绘图的名称。可以更改默认名称，以反映测量信号。</td></tr><tr><td rowspan="4">Mapping</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>对所选绘图进行映射</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lin</td><td style='text-align: center; word-wrap: break-word;'>启用线性映射。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Log</td><td style='text-align: center; word-wrap: break-word;'>启用对数映射。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>dB</td><td style='text-align: center; word-wrap: break-word;'>以 dB 为单位启用对数映射。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Scaling</td><td style='text-align: center; word-wrap: break-word;'>Manual/Full Scale（手动/满量程）</td><td style='text-align: center; word-wrap: break-word;'>对所选绘图进行缩放</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Zoom To Limits</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>将缩放比例调整为所示直方图数据的当前限值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Start Value</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>所选绘图的起始值。仅手动缩放时可见。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Stop Value</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>所选绘图的停止值。仅手动缩放时可见。</td></tr></table>

### 4.6. Plotter（绘图仪）选项卡

Plotter（绘图仪）是一个强大的时域测量工具，正如独特的分析工具组合中所介绍的，并且它适用于所有 MFLI 仪器。

#### 4.6.1. 特征

一 用于灵活缩放轴的垂直轴分组

一 极坐标和笛卡尔数据格式

一 用于数据分析的直方图和数学功能

一 4 个用于数据分析的光标

一 支持输入缩放和输入单元

#### 4.6.2. 描述

Plotter（绘图仪）用作滚动模式下时域数据的图形显示，即连续不触发。当该选项卡关闭或需要其他相同类型的选项卡时，单击以下图标即可打开该选项卡的新实例。

<div style="text-align: center;"><div style="text-align: center;">表 4.19. 应用图标和简要描述</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Plotter</td><td style='text-align: center; word-wrap: break-word;'>☑</td><td style='text-align: center; word-wrap: break-word;'>以迹线形式显示一段时间内的各种连续流传输的测量数据（滚动模式）。</td></tr></table>

Plotter（绘图仪）选项卡（参见图 4.19）由左侧的显示部分和右侧的配置部分组成。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//4e89c9c3-c5f5-43a3-8be8-b7bd65b5914c/markdown_1/imgs/img_in_chart_box_216_838_1071_1129.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A32%3A00Z%2F-1%2F%2F4d9c68308ad34ebcfb6d5bbeaedecabbbeab8731cb6af4da93dac3386317ca94" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.19.LabOne UI: Plotter（绘图仪）选项卡</div> </div>


Plotter（绘图仪）可用于连续监测解调数据和其他流传输数据一段时间内的演变。就和 Numeric（数值）选项卡一样，Plotter（绘图仪）选项卡也可以显示任何连续流传输的物理量，例如 R、 $ \Theta $、X、Y、频率等。可以通过使用 Control（控制）子选项卡中的预设或通过浏览树结构并在树结构中选择期望信号来添加新信号。垂直轴和水平轴可以以 Lin、Log 或 dB 标度显示。Plotter（绘图仪）显示可以使用放大镜符号放大和缩小，或可通过 Man（手动）、Auto（自动）和 FS（满量程）按钮设置进行放大和缩小（另请参见绘图功能）。保存在内存中的最大持续时间数据可在 Settings（设置）子选项卡中定义为窗口长度参数。窗口长度还决定了 Record Data（记录数据）功能的文件大小。

##### 注释

当以高采样率运行时，将窗口长度设置为较大的值可能会导致托管数据服务器的计算机出现内存问题。

解调器数据的采样率由 Lock-in（锁相）选项卡中设置的以 Sa/s 为单位的速率值确定。通过单击 Config（配置）选项卡中的记录按钮，绘图仪数据可以连续保存到磁盘，状态栏中的绿色 REC（记录）LED 将指示该按钮。有关数据保存的更多信息，请参见第 4.2 节。

#### 4.6.3. 功能元素

<div style="text-align: center;"><div style="text-align: center;">表 4.20. Plotter（绘图仪）选项卡：Control（控制）子选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Run/Stop</td><td style='text-align: center; word-wrap: break-word;'>Run/Stop</td><td style='text-align: center; word-wrap: break-word;'>启动和停止连续数据绘图（滚动模式）</td></tr><tr><td rowspan="8">Select a Preset</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择预定义的组信号。信号组由常用单位和信号类型定义。组内信号应具有相同的缩放属性，因为它们共用Y轴。如果各信号的缩放属性不同，则拆分组。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Enabled Impedances（启用阻抗）</td><td style='text-align: center; word-wrap: break-word;'>显示阻抗、模型参数和频率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID Errors（PID 误差）</td><td style='text-align: center; word-wrap: break-word;'>选择所有 PID 的误差。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Enabled Demods R（启用解调器 R）</td><td style='text-align: center; word-wrap: break-word;'>选择所有已启用的解调器的幅值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Enabled Demods Cartesian（启用解调器笛卡尔坐标）</td><td style='text-align: center; word-wrap: break-word;'>选择所有已启用的解调器的 X 和 Y。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Enabled Demods Polar（启用解调器极坐标）</td><td style='text-align: center; word-wrap: break-word;'>选择所有已启用的解调器的幅值和相位。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Unpopulated（无信号）</td><td style='text-align: center; word-wrap: break-word;'>不显示信号。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Manual（手动）</td><td style='text-align: center; word-wrap: break-word;'>选择 Tree（树）子选项卡中定义的信号。</td></tr></table>

有关垂直轴组的信息，请参见“垂直轴组”部分中的“垂直轴组描述”表。

有关 Math（数学）子选项卡的信息，请参见“光标和数学”一节中的“绘图数学描述”表。

### 4.7.Scope（示波器）选项卡

Scope（示波器）是一个强大的时域和频域测量工具，正如独特的分析工具组合中所介绍，它适用于所有 MFLI 仪器。

#### 4.7.1. 特征

一个具有 16 kSa 内存的输入通道；可升级到两个通道，每个通道具有 2.5 MSa 内存（MF-DIG 选件）

一 16 位标称分辨率

分段记录（需要安装 MF-DIG 选件）

一 用于成像的色度显示（需要安装 MF-DIG 选件）

24 位高清模式（MF-DIG 选件）

一 快速傅里叶变换 (FFT)：高达 60 MHz 的跨度、频谱密度和功率转换、窗口函数选择

采样率从 1.83 kSa/s 到 60 MSa/s；60 MSa/s 下的采集时间长达 270 μs 或 1.83 kSa/s 下的采集时间为 8.9 s

8 个信号源，包括 Signal Inputs（信号输入）（I/V）和 Trigger Inputs（触发输入）；多达 8 个触发源和 2 种触发方式

一 独立的延迟、滞后、预触发和触发电平设置

一 支持输入缩放和输入单元

#### 4.7.2. 描述

Scope（示波器）选项卡用作时域数据的图形显示。当该选项卡关闭或需要其他相同类型的选项卡时，单击以下图标即可打开该选项卡的新实例。

<div style="text-align: center;"><div style="text-align: center;">表 4.21. 应用图标和简要描述</div> </div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//4e89c9c3-c5f5-43a3-8be8-b7bd65b5914c/markdown_3/imgs/img_in_chart_box_216_969_1076_1340.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A32%3A02Z%2F-1%2F%2Fd397f0603dcbb675a21b7285369f6af2d2061b3f499b6c93f793a11b1af78bec" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.20.LabOne UI: Scope（示波器）选项卡 - 时域</div> </div>


Scope（示波器）选项卡由左侧的绘图部分和右侧的配置部分组成。配置部分还细分为多个子选项卡。它允许访问单通道示波器，该示波器可用于监控时域或频域中的信号选择。因此，绘图区域的X轴显示时间（用于时域显示，参见图4.20）或频率（用于频域显示，参见图4.22）。通过打开Scope（示波器）选项卡的第二个实例，可以同时显示时间迹线和相关的FFT。Y轴显示可以通过Lock-in（锁相）选项卡中的任意输入单元功能进行修改和缩放的选定信号。

Scope（示波器）以高达 60 MSa/s 的速度记录来自单个通道的数据。可以在两个 Signal Inputs（信号输入）、Auxiliary Inputs（辅助输入）、Trigger Inputs（触发输入）和 Demodulator Oscillator Phase（解调器振荡器相位）中选择通道。Scope（示波器）在标准配置中记录多达 16 kSa 样本的数据集，这对应于最高采样率下 270 μs 的采集时间。

逆采样率和获取点数（长度）的乘积决定了每次截图的总记录时间。因此，可以通过降低采样率来捕捉更长的时间间隔。Scope（示波器）可以使用抽取或 BW Limitation（带宽限制）的方式降低采样率，如图 4.21 所示。BW Limitation（带宽限制）在默认情况下激活，但可以通过 Advanced（高级）子选项卡禁用。该图顶部显示了输入信号示例，然后是使用最高采样率 60 MSa/s 时的 Scope（示波器）输出。下一个信号显示了使用抽取方式将配置采样率降低 4 倍（即 15 MSa/s）后的 Scope（示波器）输出。抽取方法是通过仅保留每次第 N 个样本并丢弃其余样本来执行 N 倍的采样率降低。这种方法的优点是简单，但缺点是信号欠采样，因为 MFLI 仪器的输入滤波器带宽固定在 7 MHz。其结果是不再满足奈奎斯特采样标准并且可能会观察到混叠效应。图中最下方的信号说明了 BW Limitation（带宽限制）的默认采样率降低机制。BW Limitation（带宽限制）意味着采样率降低 N 倍，示波器产生的每个样本计算为以最大采样率采集的 N 个样本的平均值，从而减少有效信号带宽并且很大程度上抑制了混叠效应。从图中可以看出，采样率降低 4 倍，每个输出样本都被简单地计算为以 60 MSa/s 采集的 4 个连续样本的平均值。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//4e89c9c3-c5f5-43a3-8be8-b7bd65b5914c/markdown_4/imgs/img_in_image_box_256_603_1025_1192.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A32%3A04Z%2F-1%2F%2Fd102c403776d6704d8e3b10b640f45c402588978eb426c4a0971b66336558297" alt="Image" width="64%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.21. 显示当采样率从默认的 60 MSa/s 降低到 15 MSa/s 时，示波器输出是如何在带宽限制和抽取模式下生成的</div> </div>


通过选择 Freq Domain FFT（频域 FFT）作为 Horizontal Mode（水平模式），可以在 Control（控制）子选项卡中激活频域图。这样一来，用户就可以观察采集到的样本截图的频谱。所有控件和设置在时域图和频域图之间共享。

Scope（示波器）支持对多个截图求平均值。该功能是通过具有可配置滤波器深度的指数移动平均滤波器实现的。求平均值有助于抑制与主信号不相关的噪声分量。特别适合与 Frequency Domain FFT（频域 FFT）模式结合使用，可以帮助显示谐波信号和干扰，否则这些信号和干扰可能隐藏在本底噪声之下。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//c24d90e8-07f7-4c88-91d5-8e5474f67fe9/markdown_0/imgs/img_in_chart_box_217_111_1072_405.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A20Z%2F-1%2F%2F308ba7ce87ee5c53e94c4848a138979f5a32eed3851683f41fcdb100146ef469" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.22.LabOne UI: Scope（示波器）选项卡 - 频域</div> </div>


Trigger（触发）子选项卡提供在不同信号源上触发所需的所有控件。启用触发后，只要满足触发条件，就会采集示波器截图。Trigger（触发）和 Hysteresis（滞后）电平可以在绘图中表示为图形。禁用触发相当于连续采集示波器截图。

##### 数字转换器升级选件

MF-DIG 数字转换器选件通过添加以下功能大大提升示波器的性能：

一 同时记录两个 Scope（示波器）通道

一 两个 Scope（示波器）通道的内存深度均为 5 MSa

一 附加输入信号源（解调器 X、Y、R 和  $ \Theta $）

一 分段记录

一 成像支持色度显示

一 两个通道的 XY 显示

一 触发门控

一 使用高清 (HD) 模式将分辨率提高到 24 位

一 允许跨域触发的附加触发输入源

一 基于示波器状态的附加触发/标记输出源

一 连续流传输示波器数据

可以使用选件密钥在任何 MFLI 仪器上启用此附加功能。请联系 Zurich Instruments 获取更多信息。下面的章节将详细介绍数字转换器的功能。

##### 两个通道和扩展内存深度

MF-DIG 选件支持同时进行双通道记录。这样可以确保相对时序测量的高度准确性。可以借助 XY 显示来绘制两个相互对应的信号，例如用于快速显示相位偏移或特性曲线。可以为每个通道分配不同的信号源。触发设置、采样率和记录长度设置在两个通道之间共享。与标准 16 kSa 相比，高达 5 MSa 的更长的截图长度支持更长的记录时间和 FFT，在相同的频率范围下具有更精细的频率分辨率。

##### 附加输入源

除了 Signal Input（信号输入）、Trigger Input（触发输入）、Auxiliary Input（辅助输入）和 Oscillator Phase（振荡器相位）之外，MF-DIG 选件还允许记录解调器 X、Y、R 和  $ \Theta $ 信号。此功能非常强大，能够以非常高的采样率记录短脉冲。为了最有效地使用垂直分辨率，应正确选择这些输入信号的上限和下限。在采样之前，将缩放和偏移应用于输入信号，以便下限和上限之间相差 16 位分辨率。应用的缩放和偏移值与示波器数据一起传输，从而恢复以绝对值表示的原始物理信号强度。对于直接采样的输入信号，如 Signal Inputs（信号输入）或 Trigger Inputs（触发输入），限制是只读值并反映选定的输入范围。

##### 分段数据记录和成像

分段数据记录模式允许在示波器内存里中间存储多达 1024 个示波器截图的脉冲，称为分段。这样一来，示波器不必在每次采集到截图后一直等到数据从示波器内存成功传输到内部计算机。在分段数据记录模式下，示波器提供数据的二维色度显示，对成像应用特别有用。在 API 上使用时，每个截图的数据将包含有关分段数量的信息。

##### 高清模式

使用 BW Limitation（带宽限制）降低采样率的优势是将 ADC 的 16 位可用垂直分辨率有效提高到 23.5 位（高清模式）。表 4.22 显示了取决于采样率的标称示波器分辨率。

<div style="text-align: center;"><div style="text-align: center;">表 4.22. 使用 MF-DIG 数字转换器选件提高示波器分辨率</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>示波器采样频率</td><td style='text-align: center; word-wrap: break-word;'>示波器垂直分辨率（已安装MF-DIG选件）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>60 MSa/s</td><td style='text-align: center; word-wrap: break-word;'>16 位</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>30 MSa/s</td><td style='text-align: center; word-wrap: break-word;'>16.5 位</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>15 MSa/s</td><td style='text-align: center; word-wrap: break-word;'>17 位</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>7.5 MSa/s</td><td style='text-align: center; word-wrap: break-word;'>17.5 位</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>3.75 MSa/s</td><td style='text-align: center; word-wrap: break-word;'>18 位</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>1.88 MSa/s</td><td style='text-align: center; word-wrap: break-word;'>18.5 位</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>938 kSa/s</td><td style='text-align: center; word-wrap: break-word;'>19 位</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>469 kSa/s</td><td style='text-align: center; word-wrap: break-word;'>19.5 位</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>234 kSa/s</td><td style='text-align: center; word-wrap: break-word;'>20 位</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>117 kSa/s</td><td style='text-align: center; word-wrap: break-word;'>20.5 位</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>58.6 kSa/s</td><td style='text-align: center; word-wrap: break-word;'>21 位</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>29.3 kSa/s</td><td style='text-align: center; word-wrap: break-word;'>21.5 位</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>14.6 kSa/s</td><td style='text-align: center; word-wrap: break-word;'>22 位</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>7.32 kSa/s</td><td style='text-align: center; word-wrap: break-word;'>22.5 位</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>3.66 kSa/s</td><td style='text-align: center; word-wrap: break-word;'>23 位</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>1.83 kSa/s</td><td style='text-align: center; word-wrap: break-word;'>23.5 位</td></tr></table>

##### 触发门控

安装 MF-DIG 选件后，用户可以充分利用该触发引擎。如果启用了触发门控，则只有在门控输入处于活动状态时才会接受触发事件。

##### 附加触发输入源

通过使用解调器信号作为触发源，Scope（示波器）可以在跨域触发模式下使用。例如，这样就能以同步方式记录时域信号，解调器在频域中对信号进行分析的结果会触发同步方式。

##### 注释

选择负延迟（预触发）来补偿解调器引入的延迟。

##### Trigger Output（触发输出）上的 Scope（示波器）状态输出

MF-DIG 选件向可用 Trigger Outputs（触发输出）列表增加六个元素：Scope Trigger（示波器触发）、Scope Armed（示波器已配备）、Scope Active（示波器活动）及各自的逻辑反相信号。Trigger Output（触发输出）信号在 DIO 选项卡上受控（参见第 4.13 节）。图 4.23 显示了当六个新的 Scope（示波器）相关信号源中的一个被选定时，将在 Trigger Output（触发输出）上生成的信号说明。示例输入信号显示在该图的顶部。假设 Scope（示波器）配置为在跨越点状线指示的电平的上升沿上触发此输入信号。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//c24d90e8-07f7-4c88-91d5-8e5474f67fe9/markdown_2/imgs/img_in_chart_box_225_126_1033_756.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A23Z%2F-1%2F%2Fabecb5710fd297d5db681b935398c1823ae4d003860bb10f455e99d1846632c5" alt="Image" width="67%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.23. 当六个 Scope（示波器）相关信号源中的一个被选定时，将出现在 Trigger Output（触发输出）上的信号说明。</div> </div>


可以将 Scope（示波器）视为拥有随时间变化的状态。该状态在图中的输入信号下方显示。当Scope（示波器）完全不活动时，即处于空闲状态。当用户之后激活 Scope（示波器）时，它将转换为 Buffer（缓冲）状态。在此状态下，Scope（示波器）将开始记录输入信号。它将保持此状态，直到记录了足够的数据以满足用户在触发点之前记录数据的要求，触发点由用户界面中的触发Reference（参考）和Delay（延迟）字段控制。一旦记录了足够的数据，Scope（示波器）将转换为 Armed（已配备）状态。在此状态下，Scope（示波器）已准备好接受触发信号。请注意，只要Scope（示波器）处于 Armed（已配备）状态，它就会继续记录数据，如果没有定义触发，Scope（示波器）将直接进入 Armed（已配备）状态。一旦输入信号超过 Trigger（触发）电平，Scope（示波器）就会触发，同时其状态将从 Armed（已配备）变为 Active（活动）。Scope（示波器）将保持在 Active（活动）状态，并记录数据，直到记录了足够的数据以满足用户界面中配置的 Length（长度）要求。采集到足够的数据后，示波器将返回到 Idle（空闲）状态，等待通过 Hold-off（延迟）时间配置的时间，然后自动开始下一次测量（如果 Run（运行）处于活动状态）或等待用户重新激活它。

触发源选择器允许以多种方式在 Trigger Output（触发输出）上重现有关 Scope（示波器）状态的信息。将出现在输出上的信号与图中最下面的六条迹线一起显示。请注意，这些迹线显示为具有逻辑 0 和 1 符号值的数字信号。当在设备本身上测量时，这些值当然就是实际电压。

首先，如果选择了 Scope Trigger（示波器触发），那么触发输出将有一个被置位的信号，这意味着当示波器触发时，即从 Armed（已配备）状态变为 Active（活动）状态，它会升高。该信号的持续时间通常非常短，因此在图中用箭头表示。可以通过 Width（宽度）输入字段增加其持续时间，该字段位于 DIO 选项卡上的 Output Signal（输出信号）选择器旁边。如果选择了 Scope/Trigger（示波器/触发），则相同的信号将出现在输出上。但只是逻辑上是相反的。

接下来，如果选择了 Scope Armed（示波器已配备）信号源，只要 Scope（示波器）处于 Armed（已配备）状态，触发输出就会被置位。同样，这意味着 Scope（示波器）已经记录了足够的数据

来进行采集，并且正在等待触发条件得到满足。在本例中，由于定义了上升沿触发，当输入信号从低于触发电平上升到高于触发电平时，触发条件就满足了。

同样地，如果选择了 Scope /Armed（示波器/已配备），则只要 Scope（示波器）处于与 Armed（已配备）状态不同的状态，触发输出就会被置位（即在逻辑 1 处）。这同样适用于另外两个配置选项，除了此处当 Scope（示波器）处于 Active（活动）状态或非 Active（活动）状态时触发输出被置位。

#### 4.7.3. 功能元素

<div style="text-align: center;"><div style="text-align: center;">表 4.23.Scope（示波器）选项卡：Control（控制）子选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Single</td><td style='text-align: center; word-wrap: break-word;'>Single</td><td style='text-align: center; word-wrap: break-word;'>获取一次样本。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Force</td><td style='text-align: center; word-wrap: break-word;'>Force</td><td style='text-align: center; word-wrap: break-word;'>强制输出触发事件。</td></tr><tr><td rowspan="3">Length Mode</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>切换显示长度或持续时间。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Length（长度）(pts)</td><td style='text-align: center; word-wrap: break-word;'>示波器截图长度以样本数定义。持续时间由样本数除以采样率的形式给出。MF-DIG 选件大大增加了可用长度。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Duration（持续时间）(s)</td><td style='text-align: center; word-wrap: break-word;'>示波器截图长度以持续时间定义。样本数由持续时间乘以采样率的形式给出。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Length (pts) or Duration (s)</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>定义所记录示波器截图的长度。使用 Length Mode（长度模式）切换显示长度或持续时间。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Channel 1/2</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择相应示波器通道的信号源。浏览显示的树视图，然后单击所需信号。注释：通道 2 需要使用 DIG 选件。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Min</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>示波器满量程的下限。对于解调器、PID、Boxcar 和 AU 信号，应调整限值使信号覆盖指定范围，从而实现最佳分辨率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Max</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>示波器满量程的上限。对于解调器、PID、Boxcar 和 AU 信号，应调整限值使信号覆盖指定范围，从而实现最佳分辨率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Enable</td><td style='text-align: center; word-wrap: break-word;'>ON / OFF</td><td style='text-align: center; word-wrap: break-word;'>激活相应示波器通道的显示。注释：通道 2 需要使用 DIG 选件。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Run/Stop</td><td style='text-align: center; word-wrap: break-word;'>Run/Stop</td><td style='text-align: center; word-wrap: break-word;'>连续运行示波器/FFT。</td></tr><tr><td rowspan="2">Mode</td><td style='text-align: center; word-wrap: break-word;'>Time Domain（时域）</td><td rowspan="2">切换显示时域或频域。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Freq Domain（频域）(FFT)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sampling Rate</td><td style='text-align: center; word-wrap: break-word;'>916 Sa/s 至 60 MSa/s</td><td style='text-align: center; word-wrap: break-word;'>定义示波器的采样率。显示的数值是四舍五入后的结果。确切值等于基本采样率除以  $ 2^{n} $，其中 n 是整数。</td></tr><tr><td rowspan="3">Average Filter</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>启用在计算和显示多个示波器截图的平均值时所应用的指数移动平均 (EMA) 滤波器。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Off（关闭）</td><td style='text-align: center; word-wrap: break-word;'>关闭求平均值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Exponential Moving Avgerage（指数移动平均）</td><td style='text-align: center; word-wrap: break-word;'>将对连续示波器截图进行指数加权求平均值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Averages</td><td style='text-align: center; word-wrap: break-word;'>整数值</td><td style='text-align: center; word-wrap: break-word;'>达到 63% 的稳定程度所需的截图数量。将截图数量加倍可达到 86% 的稳定程度。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Reset</td><td style='text-align: center; word-wrap: break-word;'>R</td><td style='text-align: center; word-wrap: break-word;'>复位均值滤波器。</td></tr></table>

有关垂直轴组的信息，请参见“垂直轴组”部分中的“垂直轴组描述”表。

<div style="text-align: center;"><div style="text-align: center;">表 4.24.Scope（示波器）选项卡：Trigger（触发）子选项卡</div> </div>




<table border="1" style="margin: auto; word-wrap: break-word;"><tr><td style="text-align: center; word-wrap: break-word;">控件/工具</td><td style="text-align: center; word-wrap: break-word;">选项/范围</td><td style="text-align: center; word-wrap: break-word;">描述</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Enable</td><td style="text-align: center; word-wrap: break-word;">ON / OFF</td><td style="text-align: center; word-wrap: break-word;">启用触发后，每次满足所定义的触发条件时都会获取示波器数据。禁用时，则连续获取示波器截图。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Signal</td><td style="text-align: center; word-wrap: break-word;">☑</td><td style="text-align: center; word-wrap: break-word;">选择触发源信号。浏览显示的树视图，然后单击所需信号。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Level (V)</td><td style="text-align: center; word-wrap: break-word;">触发信号范围（允许负值）</td><td style="text-align: center; word-wrap: break-word;">定义触发电平。</td></tr><tr><td rowspan="3">Hysteresis Mode</td><td style="text-align: center; word-wrap: break-word;">☑</td><td style="text-align: center; word-wrap: break-word;">选择用于定义滞后强度的模式。只要模拟输入信号不会产生过多噪声，则相对模式在整个输入范围内效果最佳。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Hysteresis (V)</td><td style="text-align: center; word-wrap: break-word;">选择绝对滞后。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Hysteresis (%)</td><td style="text-align: center; word-wrap: break-word;">选择相对于调整后的满量程信号输入范围的滞后。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Hysteresis (V)</td><td style="text-align: center; word-wrap: break-word;">触发信号范围（仅限正值）</td><td style="text-align: center; word-wrap: break-word;">定义在重新激活触发器之前，源信号必须偏离触发电平的电压。设置为0可将其关闭。符号将由Edge设置定义。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Hysteresis (%)</td><td style="text-align: center; word-wrap: break-word;">数字百分比值（仅限正值）</td><td style="text-align: center; word-wrap: break-word;">相对于调整后的满量程信号输入范围的滞后。允许滞后值大于100%。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Show Level</td><td style="text-align: center; word-wrap: break-word;">ON / OFF</td><td style="text-align: center; word-wrap: break-word;">如果启用，触发电平在绘图中将显示为灰线。滞后以灰色框表示。可以通过拖放灰线来调整触发电平。</td></tr><tr><td rowspan="5">Trigger Gating</td><td style="text-align: center; word-wrap: break-word;">☑</td><td style="text-align: center; word-wrap: break-word;">在门控已启用时选择用于触发门控的信号源。此功能需要使用MF-DIG选件。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Trigger In 1 High</td><td style="text-align: center; word-wrap: break-word;">仅在Trigger Input 1处于高电平时触发。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Trigger In 1 Low</td><td style="text-align: center; word-wrap: break-word;">仅在Trigger Input 1处于低电平时触发。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Trigger In 2 High</td><td style="text-align: center; word-wrap: break-word;">仅在Trigger Input 2处于高电平时触发。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Trigger In 2 Low</td><td style="text-align: center; word-wrap: break-word;">仅在Trigger Input 2处于低电平时触发。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Trigger Gating Enable</td><td style="text-align: center; word-wrap: break-word;">ON / OFF</td><td style="text-align: center; word-wrap: break-word;">如果启用，触发器将由触发门控输入信号进行门控。此功能需要使用MF-DIG选件。</td></tr><tr><td rowspan="3">Holdoff Mode</td><td style="text-align: center; word-wrap: break-word;">☑</td><td style="text-align: center; word-wrap: break-word;">选择延迟模式。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Holdoff (s)</td><td style="text-align: center; word-wrap: break-word;">延迟以时间进行定义。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Holdoff (events)</td><td style="text-align: center; word-wrap: break-word;">延迟以事件数进行定义。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Holdoff (events)</td><td style="text-align: center; word-wrap: break-word;">1至1048575</td><td style="text-align: center; word-wrap: break-word;">定义在记录事件后将触发下一次记录的触发事件数量。如果值为1，则表示将为每个触发事件启动一次记录。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Reference (%)</td><td style="text-align: center; word-wrap: break-word;">百分比值</td><td style="text-align: center; word-wrap: break-word;">相对于绘图窗口的触发参考位置。默认值为50%，这会使得参考点落在所获取数据的中间位置。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Delay (s)</td><td style="text-align: center; word-wrap: break-word;">数值</td><td style="text-align: center; word-wrap: break-word;">相对于参考的触发位置。正延迟会导致在触发点之前获取的数据较少，负延迟会导致在触发点之前获取的数据较多。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Enable</td><td style="text-align: center; word-wrap: break-word;">ON / OFF</td><td style="text-align: center; word-wrap: break-word;">启用分段示波器记录。这样可以对示波器截图进行全带宽记录，并确保各截图之间的死区时间最短。此功能需要使用DIG选件。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Segments</td><td style="text-align: center; word-wrap: break-word;">1至32768</td><td style="text-align: center; word-wrap: break-word;">指定要在设备内存中记录的段数。最大示波器截图大小以可用内存除以段数的形式给出。此功能需要使用DIG选件。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Shown Trigger</td><td style="text-align: center; word-wrap: break-word;">整数值</td><td style="text-align: center; word-wrap: break-word;">显示自上次启动以来触发的事件数。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Trigger</td><td style="text-align: center; word-wrap: break-word;">灰色/绿色/黄色</td><td style="text-align: center; word-wrap: break-word;">闪烁时，表示正在捕获新的示波器截图并显示在绘图区域中。并非必须启用触发器，此指示灯才会闪烁。禁用触发器相当于连续采集。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">发生数据丢失的示波器截图将以黄色指示。这种无效的示波器截图不会得到处理。</td></tr><tr><td rowspan="4">Slope</td><td style="text-align: center; word-wrap: break-word;">无</td><td rowspan="4">选择应激活触发的信号边沿。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">上升沿和下降沿均触发</td></tr><tr><td style="text-align: center; word-wrap: break-word;">上升沿触发</td></tr><tr><td style="text-align: center; word-wrap: break-word;">下降沿触发</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Holdoff (s)</td><td style="text-align: center; word-wrap: break-word;">数值</td><td style="text-align: center; word-wrap: break-word;">定义在记录事件后重新激活触发器之前的时间。</td></tr><tr><td rowspan="5">Plot Type</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">选择绘图类型。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">无</td><td style="text-align: center; word-wrap: break-word;">不显示绘图。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">2D</td><td style="text-align: center; word-wrap: break-word;">将指定数量的网格行显示为一个2D绘图。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Row</td><td style="text-align: center; word-wrap: break-word;">仅显示Active Row（活动行）字段中定义的索引的迹线。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">2D + Row</td><td style="text-align: center; word-wrap: break-word;">显示2D和行图。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Active Row</td><td style="text-align: center; word-wrap: break-word;">整数值</td><td style="text-align: center; word-wrap: break-word;">在Row图中设置要显示的行索引。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Track Active Row</td><td style="text-align: center; word-wrap: break-word;">ON / OFF</td><td style="text-align: center; word-wrap: break-word;">启用后，活动行标记将跟踪最后记录的行。禁用后，活动行控制字段为只读。</td></tr><tr><td rowspan="6">Palette</td><td style="text-align: center; word-wrap: break-word;">Viridis</td><td rowspan="6">选择当前绘图的颜色映射表。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Inferno</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Balance</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Turbo</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Grey</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Solar</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Colorscale</td><td style="text-align: center; word-wrap: break-word;">ON / OFF</td><td style="text-align: center; word-wrap: break-word;">启用/禁用2D绘图中的色度栏显示。</td></tr><tr><td rowspan="4">Mapping</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">映射色度。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Lin</td><td style="text-align: center; word-wrap: break-word;">启用线性映射。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Log</td><td style="text-align: center; word-wrap: break-word;">启用对数映射。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">dB</td><td style="text-align: center; word-wrap: break-word;">以dB为单位启用对数映射。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Scaling</td><td style="text-align: center; word-wrap: break-word;">Full Scale/Manual/Auto</td><td style="text-align: center; word-wrap: break-word;">缩放色度。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Clamp To Color</td><td style="text-align: center; word-wrap: break-word;">ON / OFF</td><td style="text-align: center; word-wrap: break-word;">启用后，超出定义的最小区域或最大区域的网格值将使用最小或最大等效色绘制。禁用后，超出定义的最小值或最大值的网格值将保持透明。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Start</td><td style="text-align: center; word-wrap: break-word;">数值</td><td style="text-align: center; word-wrap: break-word;">色度下限。
仅手动缩放时可见。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Stop</td><td style="text-align: center; word-wrap: break-word;">数值</td><td style="text-align: center; word-wrap: break-word;">色度上限。
仅手动缩放时可见。</td></tr></table>




<div style="text-align: center;"><div style="text-align: center;">表 4.25.Scope（示波器）选项卡：Advanced（高级）子选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td rowspan="3">BW Limit</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>在样本抽取和样本求平均值之间进行选择。求平均值可避免混叠，但可能会隐藏信号峰值。通道2需要使用DIG选件。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>OFF</td><td style='text-align: center; word-wrap: break-word;'>选择样本抽取，以确保采样率低于最大可用采样率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>ON</td><td style='text-align: center; word-wrap: break-word;'>选择样本求平均值，以确保采样率低于最大可用采样率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Enable</td><td style='text-align: center; word-wrap: break-word;'>ON / OFF</td><td style='text-align: center; word-wrap: break-word;'>为指定通道启用示波器传输。这允许在绘图仪上连续记录示波器数据并流传输到磁盘。注：示波器流传输需要使用DIG选件。</td></tr><tr><td rowspan="4">X Axis</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>为xy绘图显示模式选择x轴。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Time/Freq（时间/频率）</td><td style='text-align: center; word-wrap: break-word;'>关闭xy绘图模式。x轴为时间或频率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Channel 1（通道1）</td><td style='text-align: center; word-wrap: break-word;'>启用xy绘图，并将第一个通道用于x轴。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Channel 2（通道2）</td><td style='text-align: center; word-wrap: break-word;'>启用xy绘图，并将第二个通道用于x轴。</td></tr><tr><td rowspan="7">FFT Window</td><td style='text-align: center; word-wrap: break-word;'>Rectangular</td><td rowspan="2">可供选择的七种不同的 FFT 窗。每个窗函数在幅值精度和频谱泄漏之间会有不同程度的折衷。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Hann</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Hamming</td><td rowspan="5">请查看相关文献，以便找到最符合您需求的窗函数。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Blackman Harris</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Exponential (ring-down)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Cosine (ring-down)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Cosine squared (ring-down)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Resolution (Hz)</td><td style='text-align: center; word-wrap: break-word;'>mHz 至 Hz</td><td style='text-align: center; word-wrap: break-word;'>以采集时间的倒数定义的频谱分辨率（采样率，记录的样本数）。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Spectral Density</td><td style='text-align: center; word-wrap: break-word;'>ON / OFF</td><td style='text-align: center; word-wrap: break-word;'>计算并显示频谱密度。如果启用电源，则会计算功率谱密度值。功率谱密度用于分析噪声。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Power</td><td style='text-align: center; word-wrap: break-word;'>ON / OFF</td><td style='text-align: center; word-wrap: break-word;'>计算并显示功率值。要提取功率谱密度（PSD），应将此按钮与 Spectral Density（频谱密度）一起启用。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Persistence</td><td style='text-align: center; word-wrap: break-word;'>ON / OFF</td><td style='text-align: center; word-wrap: break-word;'>保留显示先前的示波器截图。颜色方案会通过多种颜色以时间和幅值的形式来显示在某些位置上的出现次数。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Rate</td><td style='text-align: center; word-wrap: break-word;'>1.83 kHz 至 3.75 MHz</td><td style='text-align: center; word-wrap: break-word;'>示波器通道的流传输速率。可以独立于示波器采样率来调整流传输速率。最大速率取决于传输接口。注：示波器流传输需要使用 DIG 选件。</td></tr></table>





<div style="text-align: center;"><div style="text-align: center;">表 4.26.Scope（示波器）选项卡：History（历史记录）子选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>History</td><td style='text-align: center; word-wrap: break-word;'>History（历史记录）</td><td style='text-align: center; word-wrap: break-word;'>列表中的每个条目对应于历史记录中的单条迹线。绘图中显示的迹线数量最多为20。使用切换按钮可隐藏或显示各迹线。使用颜色选择器可更改绘图中迹线的颜色。双击列表条目可编辑其名称。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Length</td><td style='text-align: center; word-wrap: break-word;'>整数值</td><td style='text-align: center; word-wrap: break-word;'>历史记录中的最大记录数。列表中显示的条目数被限制为最近的100个条目。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Clear All</td><td style='text-align: center; word-wrap: break-word;'>Clear All</td><td style='text-align: center; word-wrap: break-word;'>从历史记录列表中删除所有记录。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Clear</td><td style='text-align: center; word-wrap: break-word;'>Clear</td><td style='text-align: center; word-wrap: break-word;'>从历史记录列表中删除所选记录。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Load file</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>将数据从文件加载到历史记录。加载操作不会改变在绘图中显示的数据类型和范围，如果数据未显示，则需要手动调整。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Name</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>输入一个名称用作文件夹名称以保存历史记录。另外向文件夹名称中添加一个三位数计数器，以标识连续保存到同一文件夹名称。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Auto Save</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>激活自动保存功能。激活后将自动保存历史记录中的所有测量结果，以及之后的每一个测量结果。自动保存目录可通过名称中的文“autosave”来识别，例如“sweep_autosave_001”。如果在连续运行模块期间激活自动保存功能，则每次连续的测量结果都会保存到同一个目录下。对于单触发操作，会创建一个新目录来包含历史记录中的所有测量结果。根据不同的文件格式，测量结果会附加到同一文件中或保存在单独的文件中。对于HDF5和ZView格式，测量结果会附加到同一文件中。对于MATLAB和SXM格式，每一个测量结果都保存在单独的文件中。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>File Format</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择保存数据时采用的文件格式。</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">4.7 Scope（示波器）选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Save</td><td style='text-align: center; word-wrap: break-word;'>Save</td><td style='text-align: center; word-wrap: break-word;'>将历史记录中的迹线保存到可在 File Manager（文件管理器）选项卡中访问的文件中。该文件包含 Control（控制）子选项卡的 Vertical Axis Groups（垂直轴组）中的信号。保存的数据取决于下拉列表中的选择。Save All：保存所有迹线。Save Sel：保存所选迹线。</td></tr></table>

有关 Math（数学）子选项卡的信息，请参见“光标和数学”一节中的“绘图数学描述”表。

### 4.8. Data Acquisition（数据采集）选项卡

Data Acquisition（数据采集）工具是独特的分析工具组合中引入的功能强大的时域测量工具之一，可用于所有 MFLI 仪器。该选项卡在 LabOne 软件老版本中曾被称为 Software Trigger（软件触发）选项卡。

#### 4.8.1. 特征

一 所有连续流传输数据的时域和频域显示

一 成像数据的捕获和色度显示

一 帧求平均值和像素插值

一 确定自动触发电平

一 显示多条迹线

一 记录历史可调整

一 用于信号分析的数学工具包

#### 4.8.2. 描述

Data Acquisition（数据采集）选项卡支持在触发事件时显示并记录逐次成像数据集。当该选项卡关闭或需要其他相同类型的选项卡时，单击以下图标即可打开该选项卡的新实例。

<div style="text-align: center;"><div style="text-align: center;">表 4.27. 应用图标和简要描述</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DAQ</td><td style='text-align: center; word-wrap: break-word;'>$ \underline{\text{☐}} $</td><td style='text-align: center; word-wrap: break-word;'>为所有连续流传输的测量数据样本和时域显示提供复杂的触发功能。</td></tr></table>

Data Acquisition（数据采集）选项卡（参见图 4.24）分为左侧的显示部分和右侧的配置部分。配置部分还细分为多个子选项卡。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//ef99573c-9215-48be-b2e5-0991a1b8a0c8/markdown_3/imgs/img_in_image_box_216_965_1073_1257.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A02Z%2F-1%2F%2Fdf1b2da1a955c01cc0bbcc880bf71bb1baa99a8dfbb178850e3f46090f763da1" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.24.LabOne UI: Data Acquisition（数据采集）选项卡</div> </div>


Data Acquisition（数据采集）工具为解调器信号和其他流传输数据带来了具有 FFT 能力的示波器触发功能。用户可以在时域和频域中的各种不同触发和显示选项之间进行选择。

使用Control（控制）子选项卡配置在时域和频域中要测量哪些信号。测量信号可以添加到 Vertical Axis Groups（垂直轴组）部分，如垂直轴组中所述。时域和频域数据各有一个垂直轴组。

触发条件在 Settings（设置）子选项卡中配置。在此处提供的 Trigger Types（触发类型）选择中，Edge（边沿）和 Pulse（脉冲）适用于模拟触发源，例如解调器数据、辅助电压或振荡器频率。通过使用插值，触发时间分辨率提高到超过模拟数据的采样率。无需手动设置 Triager Level（触发申

平），您可以单击 Find，让 LabOne 通过分析数据流找到一个值。对于嘈杂的触发源，Bandwidth（带宽）和 Hysteresis（滞后）设置都有助于预防假触发事件。Bandwidth（带宽）设置提供应用于触发源的可配置低通滤波器。启用此功能时，请务必选择足够高的带宽来解析应触发的信号特征，例如信号边沿或脉冲。Bandwidth（带宽）设置不会影响记录的数据。

对于偏移缓慢变化的触发源，Tracking Edge（跟踪边沿）和 Tracking Pulse（跟踪脉冲）触发类型提供 Level（电平）和 Hysteresis（滞后）的连续调整。在 Tracking（跟踪）模式下，Bandwidth（带宽）设置的作用不同于 Edge（边沿）和 Pulse（脉冲）触发类型。在这里，应该选择足够低的 Bandwidth（带宽）以过滤掉所有快速特征，只让缓慢偏移通过。

Settings（设置）子选项卡的 Horizontal（水平）部分包含关于截图 Duration（持续时间）和 Delay（延迟）的设置（负延迟对应于预触发时间）。此处还定义了 Pulse（脉冲）和 Tracking Pulse（跟踪脉冲）触发类型的最小和最大脉冲宽度。

Grid（网格）子选项卡提供成像功能，可捕获和显示组织在由行和列组成的帧中的二维数据集。默认情况下，行数为 1，这意味着 Data Acquisition（数据采集）工具的操作类似于示波器。Rows（行数）设置大于 1 时，每个新捕获的数据截图都会分配到一行，直到达到行数且帧完成。完整帧完成后，根据所选的 Operation and Repetitions（操作和重复）设置，执行新数据替换旧数据或执行求平均值的操作。在水平轴上，截图的 Duration（持续时间）被划分为由 Columns（列）设置指定的多个样本。Mode（模式）设置提供对流传输数据进行后处理以进行插值、重采样和与触发事件对齐的功能。这适用于从多个来源捕获数据，例如解调器和 PID 控制器。如图 4.25 所示，在这种情况下，流传输数据默认不会位于同一时间网格上。这可以通过将 Mode（模式）设置为 Linear（线性）或 Nearest（最接近）来更改。在这些模式下，来自多个来源的数据流将被上采样以匹配最快数据流的采样率和时间网格。这意味着保存后对数据进行处理变得更加方便，但请注意，实际数据流传输速率并没有提高，并且数据在时间分辨率上也没有增加。可以在 Display（显示）部分启用和控制数据的二维色度图像。显示具有可配置的缩放比例、范围和色度等功能。

启用网格模式后，求平均后的完整帧数据显示为 History（历史记录）子选项卡中的列表条目。有关如何管理和存储历史记录列表中的数据的更多详细信息，请参见历史记录列表。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//ef99573c-9215-48be-b2e5-0991a1b8a0c8/markdown_4/imgs/img_in_image_box_222_845_1047_1136.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A03Z%2F-1%2F%2F1bd7ea7cef62414b273dda42839fa26cd54e8f5d24f800d07d9387bf306f14fc" alt="Image" width="69%" /></div>


<div style="text-align: center;"><div style="text-align: center;">时间</div> </div>


图 4.25. 来自不同来源的样本配置为不同的速率：解调器 1 为 2N kSa/s、解调器 2 为 N kSa/s，PID Error 1 为 M kSa/s（N 不能被 M 整除）。虽然每个数据流由时间上等距间隔的样本组成，但由于采样率不同，来自不同数据流的样本时间戳不一定一致。

#### 4.8.3. 功能元素

<div style="text-align: center;"><div style="text-align: center;">表 4.28. DAQ 选项卡：Control（控制）子选项卡</div> </div>




<table border="1" style="margin: auto; word-wrap: break-word;"><tr><td style="text-align: center; word-wrap: break-word;">控件/工具</td><td style="text-align: center; word-wrap: break-word;">选项/范围</td><td style="text-align: center; word-wrap: break-word;">描述</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Run/Stop</td><td style="text-align: center; word-wrap: break-word;">Run/Stop</td><td style="text-align: center; word-wrap: break-word;">启动和停止 Data Acquisition（数据采集）工具</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Single</td><td style="text-align: center; word-wrap: break-word;">Single</td><td style="text-align: center; word-wrap: break-word;">运行一次 Data Acquisition（数据采集）工具（记录计数触发事件）</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Force</td><td style="text-align: center; word-wrap: break-word;">Force</td><td style="text-align: center; word-wrap: break-word;">强制输出单个触发事件。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Triggered</td><td style="text-align: center; word-wrap: break-word;">灰色/绿色</td><td style="text-align: center; word-wrap: break-word;">绿色表示正在捕获新的触发截图并显示在绘图区域中。</td></tr></table>




有关垂直轴组的信息，请参见“垂直轴组”部分中的“垂直轴组描述”表。

<div style="text-align: center;"><div style="text-align: center;">表 4.29.DAQ 选项卡：Settings（设置）子选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>Trigger Signal</td><td style='text-align: center; word-wrap: break-word;'>触发条件的源信号。浏览显示的树视图，然后单击所需信号。</td></tr><tr><td rowspan="8">Trigger Type</td><td style='text-align: center; word-wrap: break-word;'>选择要使用的触发类型。可选用的选件取决于所选的触发信号。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Continuous（连续） 连续触发。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Edge（边沿） 基于高电平和低电平的模拟边沿触发。可通过电平滞后和低通滤波技术来降低误触发含噪声触发信号的风险。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Digital（数字） 32位DIO线上的数字触发。通过位值定义触发条件。通过位掩码控制用于触发器评估的位。使用Positive Edge（上升沿）触发设置时，一旦满足等式(DIO数值)AND(位掩码)=(位)AND(位掩码)(并且之前未能满足)，就会发生触发事件。若要在DIO0上触发，则将位值和位掩码均设置为1；若要在DIO1上触发，则将位值和位掩码均设置为2。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Pulse（脉冲） 当模拟信号中的脉冲介于最小脉冲宽度与最大脉冲宽度之间时触发。脉冲可以定义为如下变化：低电平-高电平-低电平（正）、高电平-低电平-高电平（负）或以上两者。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Tracking Edge（跟踪边沿） 边沿触发，自动调节触发电平以补偿漂移。跟踪速度通过低通滤波器的带宽控制。对于此滤波器，只能通过电平滞后来实现噪声抑制。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>HW Trigger（硬件触发） 由四个触发输入之一触发。确保已正确调整触发电平和触发耦合。可以在绘图仪上监测触发输入状态。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Tracking Pulse（跟踪脉冲） 脉冲触发，自动调节触发电平以补偿漂移。跟踪速度通过低通滤波器的带宽控制。对于此滤波器，只能通过电平滞后来实现噪声抑制。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Pulse Type</td><td style='text-align: center; word-wrap: break-word;'>Positive/Negative/Both（正/负/两者） 选择用于触发的信号脉冲类型：负脉冲、正脉冲或以上两者。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Trigger Edge</td><td style='text-align: center; word-wrap: break-word;'>Positive/Negative/Both（正/负/两者） 选择在触发输入信号从高电平变为低电平的过程中达到触发电平时触发，还是从低电平变为高电平的过程中达到触发电平时触发，或者上述两种情况都触发。此字段仅在触发类型为Edge（边沿）、Tracking Edge（跟踪边沿）和Event Count（事件计数）时显示。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Bits</td><td style='text-align: center; word-wrap: break-word;'>0至2^32-1 指定用于触发的DIO值。必须在所有指定位都完成设置后才能触发。此字段仅在触发类型为Digital（数字）时显示。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Bit Mask</td><td style='text-align: center; word-wrap: break-word;'>0至2^32-1 为DIO触发值指定位掩码。触发值为“位AND位掩码”（按位）。此字段仅在触发类型为Digital（数字）时显示。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Level</td><td style='text-align: center; word-wrap: break-word;'>全信号范围 指定触发电平值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Find</td><td style='text-align: center; word-wrap: break-word;'>Find 根据当前信号自动查找触发电平。</td></tr></table>



<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Hysteresis</td><td style='text-align: center; word-wrap: break-word;'>全信号范围</td><td style='text-align: center; word-wrap: break-word;'>在噪声环境下，若想在正确的边沿触发，滞后非常重要。如果选择正边沿触发，则在触发电平以下应用滞后。如果选择负边沿触发，则在触发电平以上应用滞后。如果选择在两种边沿均触发，则在触发电平两侧均应用滞后。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Count</td><td style='text-align: center; word-wrap: break-word;'>整数</td><td style='text-align: center; word-wrap: break-word;'>要记录的触发事件数（在 Single（单一）模式下）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Trigger progress</td><td style='text-align: center; word-wrap: break-word;'>0% 至 100%</td><td style='text-align: center; word-wrap: break-word;'>已获取的触发所占百分比（在 Single（单一）模式下）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Bandwidth (Hz)</td><td style='text-align: center; word-wrap: break-word;'>0 至 0.5 * Sampling Rate</td><td style='text-align: center; word-wrap: break-word;'>应用于触发信号的低通滤波器的带宽。对于边沿和脉冲触发，使用的带宽应大于信号采样率的 1/20，以便保持相位延迟。对于跟踪滤波器，使用的带宽应小于信号采样频率的 1/100，以便仅跟踪漂移等慢速信号分量。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Enable</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>启用触发信号的低通滤波。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Hold Off Time (s)</td><td style='text-align: center; word-wrap: break-word;'>正数值</td><td style='text-align: center; word-wrap: break-word;'>重新激活触发器之前的延迟时间。如果延迟时间短于持续时间，将会导致触发帧发生重叠。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Hold Off Count</td><td style='text-align: center; word-wrap: break-word;'>整数值</td><td style='text-align: center; word-wrap: break-word;'>再次记录下一次触发之前跳过的触发次数。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Delay (s)</td><td style='text-align: center; word-wrap: break-word;'>-Duration 至 Duration</td><td style='text-align: center; word-wrap: break-word;'>触发帧位置（左侧）相对于触发边沿的时间延迟。如果延迟小于 0，则表示触发边沿在触发帧内（预触发）。如果延迟大于 0，将表示触发边沿在触发帧之前（后触发）。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Refresh Rate</td><td style='text-align: center; word-wrap: break-word;'>100 mHz 至 10 Hz</td><td style='text-align: center; word-wrap: break-word;'>设置用于绘图更新的最大刷新率。实际刷新率还取决于延迟时间和持续时间等其他因素。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Pulse Min (s)</td><td style='text-align: center; word-wrap: break-word;'>0 至 Duration</td><td style='text-align: center; word-wrap: break-word;'>用于触发的最小脉冲宽度。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Pulse Max (s)</td><td style='text-align: center; word-wrap: break-word;'>0 至 Duration</td><td style='text-align: center; word-wrap: break-word;'>用于触发的最大脉冲宽度。</td></tr><tr><td rowspan="7">Window</td><td style='text-align: center; word-wrap: break-word;'>Rectangular</td><td rowspan="7">可供选择的七种不同的 FFT 窗。根据应用的不同，使用的窗函数也会有巨大差异。请查看相关文献，以便找到最符合您需求的窗函数。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Hann</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Hamming</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Blackman Harris</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Exponential (ring-down)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Cosine (ring-down)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Cosine squared (ring-down)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Absolute Frequency</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>关闭时，移动 x 轴标记以显示中心解调频率，而不是 0 Hz。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Spectral Density</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>计算并显示频谱密度。如果启用电源，则会计算功率谱密度值。功率谱密度用于分析噪声。</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">表 4.30.DAQ（数据采集）选项卡：Grid（网格）子选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td rowspan="5">Mode</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择二维数据记录的重采样方法。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Off</td><td style='text-align: center; word-wrap: break-word;'>禁用二维数据记录。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Nearest</td><td style='text-align: center; word-wrap: break-word;'>使用最接近的数据点代替执行重采样。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Linear</td><td style='text-align: center; word-wrap: break-word;'>使用线性插值来执行重采样。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Exact (on-grid)</td><td style='text-align: center; word-wrap: break-word;'>调整持续时间，以使得网格距离与所选信号的最大采样率相匹配。这样可以按网格对测量数据进行采样。如果信号使用的采样率较低，则将通过线性插值对其进行上采样。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>On Grid Sampling</td><td style='text-align: center; word-wrap: break-word;'>绿色或黄色</td><td style='text-align: center; word-wrap: break-word;'>绿色表示捕获的所有数据都与网格对齐。黄色表示某些数据未与网格对齐并进行了插值处理。当其中一个或多个数据源的采样率不同或采样率发生变化时，就会出现这种情况。</td></tr><tr><td rowspan="4">Operation</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择行更新方法。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Replace</td><td style='text-align: center; word-wrap: break-word;'>新行替换旧行。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Average</td><td style='text-align: center; word-wrap: break-word;'>每行的数据是多次重复采样的平均值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Std</td><td style='text-align: center; word-wrap: break-word;'>每行的数据是多次重复采样的标准差。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Columns</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>列数。将沿水平轴的数据重新采样到由此设置定义的多个样本。</td></tr><tr><td rowspan="2">Duration</td><td rowspan="2">最长 1000 s</td><td style='text-align: center; word-wrap: break-word;'>记录每个触发的数据集的长度。在精确采样模式下，Duration（持续时间）是只读字段。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Duration（持续时间）由最大采样率和列大小定义。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Rows</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>行数</td></tr><tr><td rowspan="4">Scan Direction</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择扫描方向和模式</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Forward</td><td style='text-align: center; word-wrap: break-word;'>扫描方向从左到右</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Reverse</td><td style='text-align: center; word-wrap: break-word;'>扫描方向从右到左</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Bidirectional</td><td style='text-align: center; word-wrap: break-word;'>两个方向交替扫描</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Repetitions</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>用于求平均值的重复采样次数</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Row-wise repetition</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>启用逐行重复。对于逐行重复，每一行都在连续进行多次重复采样后计算数据，然后再开始下一行。对于网格重复，每次重复采样后便计算整个网格。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Waterfall</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>允许以瀑布模式显示 2D 绘图。将始终更新最后一行。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Overwrite</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>允许以连续模式覆盖网格。不会收集历史记录。只有在分析停止后才会创建历史记录元素。</td></tr><tr><td rowspan="5">Plot Type</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择绘图类型。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>None</td><td style='text-align: center; word-wrap: break-word;'>不显示绘图。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>2D</td><td style='text-align: center; word-wrap: break-word;'>将指定数量的网格行显示为一个 2D 绘图。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Row</td><td style='text-align: center; word-wrap: break-word;'>仅显示 Active Row（活动行）字段中定义的索引的迹线。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>2D + Row</td><td style='text-align: center; word-wrap: break-word;'>显示 2D 和行图。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Active Row</td><td style='text-align: center; word-wrap: break-word;'>整数值</td><td style='text-align: center; word-wrap: break-word;'>在 Row 图中设置要显示的行索引。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Track Active Row</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>启用后，活动行标记将跟踪最后记录的行。禁用后，活动行控制字段为只读。</td></tr><tr><td rowspan="6">Palette</td><td style='text-align: center; word-wrap: break-word;'>Viridis</td><td style='text-align: center; word-wrap: break-word;'>选择当前绘图的颜色映射表。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Inferno</td><td rowspan="5"></td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Balance</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Turbo</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Grey</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Solar</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Colorscale</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>启用/禁用 2D 绘图中的色度栏显示。</td></tr><tr><td rowspan="4">Mapping</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>映射色度。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lin</td><td style='text-align: center; word-wrap: break-word;'>启用线性映射。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Log</td><td style='text-align: center; word-wrap: break-word;'>启用对数映射。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>dB</td><td style='text-align: center; word-wrap: break-word;'>以 dB 为单位启用对数映射。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Scaling</td><td style='text-align: center; word-wrap: break-word;'>Full Scale/Manual/Auto</td><td style='text-align: center; word-wrap: break-word;'>缩放色度。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Clamp To Color</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>启用后，超出定义的最小区域或最大区域的网格值将使用最小或最大等效色绘制。禁用后，超出定义的最小值或最大值的网格值将保持透明。</td></tr><tr><td rowspan="2">Start</td><td rowspan="2">数值</td><td style='text-align: center; word-wrap: break-word;'>色度下限。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>仅手动缩放时可见。</td></tr><tr><td rowspan="2">Stop</td><td rowspan="2">数值</td><td style='text-align: center; word-wrap: break-word;'>色度上限。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>仅手动缩放时可见。</td></tr></table>





<div style="text-align: center;"><div style="text-align: center;">表 4.31.DAQ（数据采集）选项卡：History（历史记录）子选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>History</td><td style='text-align: center; word-wrap: break-word;'>History</td><td style='text-align: center; word-wrap: break-word;'>列表中的每个条目对应于历史记录中的单条迹线。绘图中显示的迹线数量最多为20。使用切换按钮可隐藏或显示各迹线。使用颜色选择器可更改绘图中迹线的颜色。双击列表条目可编辑其名称。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Length</td><td style='text-align: center; word-wrap: break-word;'>整数值</td><td style='text-align: center; word-wrap: break-word;'>历史记录中的最大记录数。列表中显示的条目数被限制为最近的100个条目。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Clear All</td><td style='text-align: center; word-wrap: break-word;'>Clear All</td><td style='text-align: center; word-wrap: break-word;'>从历史记录列表中删除所有记录。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Clear</td><td style='text-align: center; word-wrap: break-word;'>Clear</td><td style='text-align: center; word-wrap: break-word;'>从历史记录列表中删除所选记录。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Load file</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>将数据从文件加载到历史记录。加载操作不会改变在绘图中显示的数据类型和范围，如果数据未显示，则需要手动调整。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Name</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>输入一个名称用作文件夹名称以保存历史记录。另外向文件夹名称中添加一个三位数计数器，以标识连续保存到同一文件夹名称。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Auto Save</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>激活自动保存功能。激活后将自动保存历史记录中的所有测量结果，以及之后的每一个测量结果。自动保存目录可通过名称中的文本“autosave”来识别，例如“sweep_autosave_001”。如果在连续运行模块期间激活自动保存功能，则每次连续的测量结果都会保存到同一个目录下。对于单触发操作，会创建一个新目录来包含历史记录中的所有测量结果。根据不同的文件格式，测量结果会附加到同一文件中或保存在单独的文件中。对于HDF5和ZView格式，测量结果会附加到同一文件中。对于MATLAB和SXM格式，每一个测量结果都保存在单独的文件中。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>File Format</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择保存数据时采用的文件格式。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Save</td><td style='text-align: center; word-wrap: break-word;'>Save</td><td style='text-align: center; word-wrap: break-word;'>将历史记录中的迹线保存到可在File Manager（文件管理器）选项卡中访问的文件中。该文件包含Control（控制）子选项卡的Vertical Axis Groups（垂直轴组）中的信号。保存的数据取决于下拉列表中的选择。Save All：保存所有迹线。Save Sel：保存所选迹线。</td></tr></table>

有关 Math（数学）子选项卡的信息，请参见“光标和数学”一节中的“绘图数学描述”表。

### 4.9. Spectrum Analyzer（频谱分析仪）选项卡

正如独特的分析工具组合一节所述，频谱分析仪是强大的频域测量工具，可用于所有 MFLI 仪器。

#### 4.9.1. 特征

一 高速高分辨率 FFT 频谱分析仪

一 信号：解调数据（X+iY、R、 $ \Theta $、f 和 d $ \Theta $/dt/(2 $ \pi $)）、PID、Boxcar、辅助输入等

一 可调节的中心频率、频率分辨率和频率范围

一 自动带宽

一 瀑布模式显示

一 4 种不同的 FFT 窗函数可选

一 以不同类型的平均功能连续和分块采集

一 详细的噪声功率分析

一 支持输入缩放和输入单元

一 数学工具箱用于信号分析

#### 4.9.2. 描述

可通过 Spectrum Analyzer（频谱分析仪）对解调器数据进行频域分析。当该选项卡关闭或需要其他相同类型的选项卡时，单击以下图标即可打开该选项卡的新实例。

<div style="text-align: center;"><div style="text-align: center;">表 4.32. 应用图标和简要描述</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Spectrum</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>为所有连续流传输的测量数据提供 FFT 功能。</td></tr></table>

Spectrum（频谱）选项卡（见图 4.26）分为两个部分，左边是显示部分，右边是配置部分。配置部分还细分为多个子选项卡。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//b1b9c193-ea37-4b54-9edc-2990a36c03bf/markdown_4/imgs/img_in_image_box_218_1008_1072_1297.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A36Z%2F-1%2F%2Fd19b112b9acf6c3f3c95f8ff1e97f7d7e363d43e4561446373c28f6219884142" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.26.LabOne UI: Spectrum Analyzer（频谱分析仪）选项卡</div> </div>


频谱分析仪通过对复数解调器数据样本 X+iY（以 i 为虚部）执行快速傅里叶变换 (FFT)，允许对所有解调器数据进行频谱分析。此 FFT 结果是解调频率周围的频谱，而直接对原始输入数据应用 FFT 则将产生零频率周围的频谱。后者对应的过程是第 4.7 节的频域操作。二者的主要区别在于，频谱分析仪工具可在更长的时段内获取数据，因此可在解调频率周围实现非常高的频率分辨率。默认情况下显示的是零频率周围的频谱。然而，有时通过解调频率来移动频率轴是很方便的，这使得人们

可以用信号输入处的物理频率来识别水平轴上的频率。方法是在 Settings（设置）子选项卡上激活 Absolute Frequency（绝对频率）。

显示部分默认包括频谱的线绘图，以及最近获取的几个频谱的彩色瀑布图。瀑布图更便于查看一段时间内的频谱变化。显示部分的布局以及彩色绘图中的行数均可在 Settings（设置）子选项卡中配置。

Spectrum（频谱）子选项卡中所示的数据均已通过低通滤波器按明确定义的阶数和带宽完成滤波。本底噪声的形状清晰地反映出了滤波的效果。为防止因混叠而造成的测量误差，必须注意所选择的频率范围（等于解调器采样率）要比滤波器带宽高5到10倍。Auto Bandwidth（自动带宽）按钮

A 用于根据滤波器设置调整采样率。Spectrum（频谱）选项卡还具有 FFT 显示功能，显示 Signal Type（信号类型）下拉列表中除了复数解调器样本 X+iY 之外的一系列可选数据。查看极坐标解调器值 R 和 θ 的 FFT，即可区分信号中的相位噪声分量和幅度噪声分量。借助相位导数 dΩ/dt 的 FFT，能够从定量角度了解调器频率的频谱。这在与 PLL 或 ExtRef 功能结合使用时尤其实用。频率样本的 FFT 能够从定量角度说明参考信号中呈现的频率噪声分量，并有助于找到追踪信号的最优 PLL 带宽。需要注意的是，Signal Type（信号类型）列表中的很多信号都是实值的，而非复值的。其频谱都是单侧的，最低频率为 0 Hz。

#### 4.9.3. 功能元素

<div style="text-align: center;"><div style="text-align: center;">表 4.33.Spectrum（频谱）选项卡：Settings（设置）子选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Run/Stop</td><td style='text-align: center; word-wrap: break-word;'>Run/Stop</td><td style='text-align: center; word-wrap: break-word;'>连续运行 FFT 频谱分析</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Single</td><td style='text-align: center; word-wrap: break-word;'>Single</td><td style='text-align: center; word-wrap: break-word;'>运行一次 FFT 频谱分析</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Center Freq (Hz)</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>将所选解调器的解调频率用作频谱的输入。对于复数 FFT  $ X + iY $，解调频率定义了所显示 FFT 的中心频率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Frequency Span (Hz)</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>设置复数 FFT 的期望频率范围。基于实际输入数据的 FFT 将显示频率范围的一半，上限为奈奎斯特频率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Auto Bandwidth</td><td style='text-align: center; word-wrap: break-word;'>A</td><td style='text-align: center; word-wrap: break-word;'>自动调整解调器带宽，以便在所选频率范围（等于采样率）内实现最佳混叠抑制。该功能仅在已启用频谱的情况下可用。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Start Frequency (Hz)</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>表示 FFT 的起始频率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Stop Frequency (Hz)</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>表示 FFT 的结束频率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Refresh Rate (Hz)</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>设置绘图的最大刷新率。实际刷新率还取决于 FFT 长度等其他参数。在重叠模式下，刷新率定义重叠量。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Overlapped FFT</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>启用重叠的 FFT。如果禁用，则在不同的邻接数据集上执行 FFT。如果启用，则连续 FFT 的数据集将根据所定义的刷新率重叠。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Power</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>计算并显示功率值。要提取功率谱密度 (PSD)，应将此按钮与 Spectral Density（频谱密度）一起启用。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Spectral Density</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>计算并显示频谱密度。如果启用电源，则会计算功率谱密度值。功率谱密度用于分析噪声。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Filter Compensation</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>通过解调器滤波器传递函数校正频谱。允许对频谱不同部分的幅值进行定量比较。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Absolute Frequency</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>关闭时，移动 x 轴标记以显示中心解调频率，而不是 0 Hz。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>FFT length</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>用于 FFT 的样本数。如果输入的值不是 2 的幂，则会被截断为最接近的 2 的幂。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sampling Progress</td><td style='text-align: center; word-wrap: break-word;'>0% 至 100%</td><td style='text-align: center; word-wrap: break-word;'>FFT 缓冲区中已获取的样本数所占的百分比。进度包括行数和平均值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>FFT Duration (s)</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>表示样本进行单次 FFT 所使用的时长。</td></tr><tr><td rowspan="7">Window</td><td style='text-align: center; word-wrap: break-word;'>Rectangular</td><td rowspan="7">可供选择的七种不同的 FFT 窗。根据应用的不同，使用的窗函数也会有巨大差异。请查看相关文献，以便找到最符合您需求的窗函数。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Hann</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Hamming</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Blackman Harris</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Exponential (ring-down)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Cosine (ring-down)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Cosine squared (ring-down)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Resolution (Hz)</td><td style='text-align: center; word-wrap: break-word;'>mHz 至 Hz</td><td style='text-align: center; word-wrap: break-word;'>以采集时间的倒数定义的频谱分辨率（采样率，记录的样本数）。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Rows</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>行数</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Averages</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>每行的 FFT 平均数。将该值设置为 1 会禁用任何求平均值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Waterfall</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>允许以瀑布模式显示 2D 绘图。将始终更新最低一行。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Overwrite</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>允许以连续模式覆盖网格。不会收集历史记录。只有在分析停止后才会创建历史记录元素。</td></tr><tr><td rowspan="5">Plot Type</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择绘图类型。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>无</td><td style='text-align: center; word-wrap: break-word;'>不显示绘图。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>2D</td><td style='text-align: center; word-wrap: break-word;'>将指定数量的网格行显示为一个 2D 绘图。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Row</td><td style='text-align: center; word-wrap: break-word;'>仅显示 Active Row（活动行）字段中定义的索引的迹线。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>2D + Row</td><td style='text-align: center; word-wrap: break-word;'>显示 2D 和行图。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Active Row</td><td style='text-align: center; word-wrap: break-word;'>整数值</td><td style='text-align: center; word-wrap: break-word;'>在 Row 图中设置要显示的行索引。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Track Active Row</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>启用后，活动行标记将跟踪最后记录的行。禁用后，活动行控制字段为只读。</td></tr><tr><td rowspan="6">Palette</td><td style='text-align: center; word-wrap: break-word;'>Viridis</td><td rowspan="6">选择当前绘图的颜色映射表。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Inferno</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Balance</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Turbo</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Grey</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Solar</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Colorscale</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>启用/禁用 2D 绘图中的色度栏显示。</td></tr><tr><td rowspan="4">Mapping</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>映射色度。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lin</td><td style='text-align: center; word-wrap: break-word;'>启用线性映射。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Log</td><td style='text-align: center; word-wrap: break-word;'>启用对数映射。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>dB</td><td style='text-align: center; word-wrap: break-word;'>以 dB 为单位启用对数映射。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Scaling</td><td style='text-align: center; word-wrap: break-word;'>Full Scale/Manual/Auto</td><td style='text-align: center; word-wrap: break-word;'>缩放色度。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Clamp To Color</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>启用后，超出定义的最小区域或最大区域的网格值将使用最小或最大等效色绘制。禁用后，超出定义的最小值或最大值的网格值将保持透明。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Start</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>色度下限。仅手动缩放时可见。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Stop</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>色度上限。仅手动缩放时可见。</td></tr></table>





有关 Math（数学）子选项卡的信息，请参见“光标和数学”一节中的“绘图数学描述”表。

### 4.10. Sweeper（参数扫描仪）选项卡

参数扫描仪是应用极为广泛的测量工具，可用于所有 MFLI 仪器。参数扫描仪能够扫描规定范围内的仪器参数，同时测量选定的连续流传输的数据。在扫描参数是振荡器频率的特殊情况下，参数扫描仪可提供功能强大的频率响应分析仪 (FRA)。

#### 4.10.1. 特征

一 功能全面的参数扫描工具，可扫描频率、相移、输出幅值，直流输出电压等参数

同步显示来自不同数据源（解调器、PID、辅助输入等）的数据

不同的应用模式，例如频率响应分析仪（波特图）、噪声幅值扫描等

不同的扫描类型：单相、持续（运行/停止）、双向、二进制

一 持续显示之前的扫描结果

一 对奈奎斯特图或 I-V 曲线应用 XY Mode（XY 模式）

一 标准化扫描

一 自动带宽、均化值和显示标准化

一 支持输入缩放和输入单元

一 相位重建

一 全面支持 sinc 滤波器

#### 4.10.2. 描述

参数扫描仪支持多种参数逐步变化且图形化显示诸多测量数据的实验。在 UI 侧栏单击相应图标即可打开该工具。Sweeper（参数扫描仪）选项卡（见图 4.27）分为两个部分，左边是绘图部分，右边是配置部分。配置部分还细分为多个子选项卡。

<div style="text-align: center;"><div style="text-align: center;">表 4.34. 应用图标和简要描述</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sweeper</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>扫描规定范围内的频率、电压及其他物理量，并显示包括统计运算在内的各种响应函数。</td></tr></table>

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//32f27e91-6704-4e77-989f-2020840300a9/markdown_2/imgs/img_in_chart_box_217_1082_1071_1370.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A27Z%2F-1%2F%2F5e024d13266105ebefd69149316e9466273bee0adc2ab6991547fa73676c1022" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.27.LabOne UI: Sweeper（参数扫描仪）选项卡</div> </div>


Control（控制）子选项卡包含基础测量设置，例如扫描参数、起始值/结束值以及 Horizontal（水平）部分中的点数（长度）。测量信号可通过 Vertical Axis Groups（垂直轴组）部分添加。参数扫描仪常用于执行频率扫描，以波特图的形式测量被测设备的响应情况。例如，AFM 和 MEMS 用户需要

确定其振荡器的谐振频率和相位延迟。参数扫描仪还可用于扫描频率以外的参数，例如信号幅值和直流偏移电压。例如，扫描辅助输出偏移可用于测量电流电压 (I-V) 特性。在 XY Mode（XY 模式）下，允许用户在水平轴上使用测量信号而非扫描参数。这对在阻抗测量中获得奈奎斯特图，或在非线性设备的四探头测量中显示 I-V 曲线非常有用。

扫描频率时，默认情况下起始值和结束值之间的扫描点是以对数而非线性方式分布的。这一功能尤其有助于几十年的扫描，并可通过 Log（日志）复选框禁用。Sweep Mode（扫描模式）设置用于识别出现测量问题的原因在于滞后样本性能还是扫描速度太快。此类问题可导致双向扫描时出现非重叠曲线。

##### 注释

参数扫描仪会主动修改解调器和振荡器的主要设置。因此，尤其是在涉及多个实验，甚至来自不同的控制计算机的实验时，应非常小心，确保参数扫描仪模块改变的参数不会对别处产生不利影响。

参数扫描仪提供 Application Mode（应用模式）和 Advanced Mode（高级模式）这两种操作模式，二者的可访问设置的细节水平不同，但都可通过 Settings（设置）子选项卡访问。Application Mode（应用模式）提供六种测量方法供您选择，有助于快速获得大范围应用的正确测量结果。倾向于控制所有设置的用户可以切换到 Advanced Mode（高级模式）。

在 Advanced Mode（高级模式）的 Statistics（统计）部分，可控制每个扫描点的数据均分方式：通过指定样本计数或指定滤波器时间常数（TC）的数量。考虑到解调器采样率和滤波器设置，实际测量时间取两种设置得出的较大值。Algorithm（算法）设置决定了使用测量数据计算出的统计数据：一般情况下是平均值，噪声测量时是偏差，功率测量时是均方值。相位重建功能可确保相位测量曲线在 PM180 度范围内的连续性。启用 Sinc Filter（Sinc 滤波器）设置意味着在 Auto（自动）和 Fixed（固定）模式下，解调器 Sinc 滤波器会在扫描点低于 50 Hz 时被激活。这就像 Sinc 滤波中解释的那样，加快了小频率的测量速度。

在 Settling（稳定）部分，可以控制参数设置和首次测量之间的等待时间。与 Statistics（统计）设置相似的是，可以选择两种不同的等待时间代表方法。实际稳定时间是以绝对时间为单位设定的值和从解调器滤波器和所需的不精确度（如 0.1% 为 1 m）中得出的时间的最大值。举个例子。对于频率为 100 Hz、带宽为 3 dB 的 4 阶滤波器，在约 4.5 ms 后得到 90% 的阶跃响应。这可以使用图 4.28 中指示的数据采集工具轻松测量得到。离散时间滤波器中也有说明。如果全量程设定为 1 V，这意味着测量由于不完美稳定而造成的最大误差约为 0.1 V。然而，对于大多数测量而言，相比满量程，相邻值更为接近，因此造成的实际误差通常要小得多。

在 Advanced Mode（高级模式）的 Filter（滤波器）部分，Bandwidth Mode（带宽模式）设置决定如何配置已激活的解调器的滤波器。在 Manual（手动）模式下，参数扫描仪不会改变当前设置（位于 Lock-in（锁相）选项卡）。在 Fixed（固定）模式下，可在 Sweeper（参数扫描仪）选项卡中控制滤波器设置。在 Auto（自动）模式下，参数扫描仪根据想要的  $ \omega $ 抑制来确定每个扫描点的滤波器带宽。 $ \omega $ 抑制取决于测量频率和滤波器陡度。对于频率扫描，带宽将根据 Max Bandwidth（最大带宽）设置中所设范围内的每个扫描点进行调整。Auto（自动）模式尤其适用于几十年的频率扫描，因为带宽的持续调整可大幅缩短整体测量时间。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//32f27e91-6704-4e77-989f-2020840300a9/markdown_4/imgs/img_in_chart_box_222_126_1041_519.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A28Z%2F-1%2F%2F281a250fb4ecdbcc8336b1d74f842c03d45337f0c2baa46566218ac4c2980e95" alt="Image" width="68%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.28. 解调器稳定时间和不精确度：使用数据采集工具进行测量，以说明频率为 100 Hz、带宽为 3 dB 的 4 阶滤波器的稳定时间。</div> </div>


默认情况下绘图区域会保存并显示最近的 100 次扫描，可通过 History（历史记录）子选项卡中的列表查看。有关如何管理和存储历史记录列表中的数据的更多详细信息，请参见历史记录列表。借助“参考”功能，可以用参考测量来划分历史记录中的所有测量。例如，这一功能在消除频率响应扫描的寄生效应时非常实用。在将某个测量确定为参考时，只需在列表中标记该测量，然后单击 Reference 。然后通过勾选列表下方的复选框来启用 Reference（参考）模式，更新绘图显示。注意，Reference（参考）设置并不影响数据保存：已保存的文件仍包含原始数据。

#### 注释

参数扫描仪会在接受不到任何数据的时候卡住。常见的错误是选择显示解调器数据，而不在 Lock-in（锁相）选项卡中启用相关解调器的数据传输。

##### 注释

参数扫描仪会在执行扫描时存储来自已启用的解调器和辅助输入的所有数据，即使它们并没有立即显示在绘图区域。这些数据可在稍后的时间点通过选择相应的信号显示设置（Input Channel（输入通道））来访问。

#### 4.10.3. 功能元素

<div style="text-align: center;"><div style="text-align: center;">表 4.35. Sweeper（参数扫描仪）选项卡：Control（控制）子选项卡</div> </div>




<table border="1" style="margin: auto; word-wrap: break-word;"><tr><td style="text-align: center; word-wrap: break-word;">控件/工具</td><td style="text-align: center; word-wrap: break-word;">选项/范围</td><td style="text-align: center; word-wrap: break-word;">描述</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Run/Stop</td><td style="text-align: center; word-wrap: break-word;">Run/Stop</td><td style="text-align: center; word-wrap: break-word;">持续运行参数扫描仪。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Single</td><td style="text-align: center; word-wrap: break-word;">Single</td><td style="text-align: center; word-wrap: break-word;">运行一次参数扫描仪。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Copy From Range</td><td style="text-align: center; word-wrap: break-word;">Copy From Range</td><td style="text-align: center; word-wrap: break-word;">从绘图区域获取起始值和结束值。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Start (unit)</td><td style="text-align: center; word-wrap: break-word;">数值</td><td style="text-align: center; word-wrap: break-word;">扫描参数的起始值。根据所选的扫描参数调整单位。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Stop (unit)</td><td style="text-align: center; word-wrap: break-word;">数值</td><td style="text-align: center; word-wrap: break-word;">扫描参数的结束值。根据所选的扫描参数调整单位。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Length</td><td style="text-align: center; word-wrap: break-word;">整数值</td><td style="text-align: center; word-wrap: break-word;">设置测量点数。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Progress</td><td style="text-align: center; word-wrap: break-word;">0 至 100%</td><td style="text-align: center; word-wrap: break-word;">以记录的点数所占比例报告扫描进度。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Sweep Param</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">选择要扫描的参数。浏览显示的树视图，然后单击所需参数。可用的选项因设备配置而异。</td></tr><tr><td rowspan="5">Sweep Mode</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">选择扫描类型，默认顺序扫描（从起始值到结束值进行增量扫描）</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Sequential</td><td style="text-align: center; word-wrap: break-word;">从起始值到结束值按顺序扫描</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Binary</td><td style="text-align: center; word-wrap: break-word;">在整个范围内以不断增加的分辨率进行非顺序扫描</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Bidirectional</td><td style="text-align: center; word-wrap: break-word;">从起始值到结束值再返回到起始值的顺序扫描</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Reverse</td><td style="text-align: center; word-wrap: break-word;">从结束值到起始值逆序扫描</td></tr><tr><td style="text-align: center; word-wrap: break-word;">X Distribution</td><td style="text-align: center; word-wrap: break-word;">线性/对数</td><td style="text-align: center; word-wrap: break-word;">选择扫描参数的线性分布或对数分布。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Remaining</td><td style="text-align: center; word-wrap: break-word;">数值</td><td style="text-align: center; word-wrap: break-word;">报告当前扫描的剩余时间。只有参数扫描仪启动后才会显示有效数字。未定义的扫描时间用NaN表示。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Invert Y Axis</td><td style="text-align: center; word-wrap: break-word;">ON/OFF</td><td style="text-align: center; word-wrap: break-word;">显示 xy 绘图，使用反向 y 轴。此模式用于奈奎斯特图，允许在 y 轴上显示 -imag(z)，在 x 轴上显示 real(z)。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">X Signal</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">选择用于定义 xy 绘图的 x 轴的信号。可用的选项因设备配置而异。显示所选的信号源将得到一条对角直线。</td></tr></table>




有关垂直轴组的信息，请参见“垂直轴组”部分中的“垂直轴组描述”表。

<div style="text-align: center;"><div style="text-align: center;">表 4.36. Sweeper（参数扫描仪）选项卡：Settings（设置）子选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td rowspan="3">Filter</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Application Mode（应用模式）：预设配置。Advanced Mode（高级模式）：手动配置。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Application Mode</td><td style='text-align: center; word-wrap: break-word;'>参数扫描仪自动设置滤波器和其他参数。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Advanced Mode</td><td style='text-align: center; word-wrap: break-word;'>参数扫描仪使用手动配置的参数。</td></tr><tr><td rowspan="8">Application</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择扫描应用模式</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Parameter Sweep</td><td style='text-align: center; word-wrap: break-word;'>每个参数扫描点仅获取一个数据样本。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Parameter Sweep Averaged</td><td style='text-align: center; word-wrap: break-word;'>每个参数扫描点获取的多个数据样本及其平均值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Noise Amplitude Sweep</td><td style='text-align: center; word-wrap: break-word;'>每个参数扫描点获取的多个数据样本及其标准差（例如，用于确定输入噪声）。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Freq Response Analyzer</td><td style='text-align: center; word-wrap: break-word;'>窄带频率响应分析。启用求平均值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>3-Omega Sweep</td><td style='text-align: center; word-wrap: break-word;'>优化的 3-omega 应用参数。启用求平均值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>FRA (Sinc Filter)</td><td style='text-align: center; word-wrap: break-word;'>在 FRA 模式下，sinc 滤波器有助于加速测量 50 Hz 以下的频率。对于更高的频率，会自动禁用。关闭求平均值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Impedance</td><td style='text-align: center; word-wrap: break-word;'>此应用模式使用窄带宽滤波器设置来实现高准确度的校准。</td></tr><tr><td rowspan="4">Precision</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>在高速扫描速度与高精度/准确度之间权衡取舍。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Low → fast sweep</td><td style='text-align: center; word-wrap: break-word;'>低精度/准确度，快速扫描。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>High → standard speed</td><td style='text-align: center; word-wrap: break-word;'>高精度/准确度，标准速度扫描（测量需要较长时间）。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Very high → slow sweep</td><td style='text-align: center; word-wrap: break-word;'>超高精度/准确度，慢速扫描（测量需要较长时间）。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Bandwidth Mode</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>推荐选择自动模式，尤其是对数扫描，可确保覆盖整个频谱。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Auto</td><td style='text-align: center; word-wrap: break-word;'>所选解调器的所有带宽设置都会自动调整。对于对数扫描，可在整个测量过程中调整测量带宽。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Fixed</td><td style='text-align: center; word-wrap: break-word;'>为所有选定的解调器定义一个特定的带宽用于测量。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Manual</td><td style='text-align: center; word-wrap: break-word;'>参数扫描仪模块会使解调器的带宽设置完全不受影响。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Time</td><td rowspan="2">Constant/Bandwidth</td><td rowspan="2">定义用于固定带宽模式下扫描的低通滤波器显示单位：时间常数(TC)、噪声等效功率带宽(NEP)、3 dB 带宽(3 dB)。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Select</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>TC</td><td style='text-align: center; word-wrap: break-word;'>使用滤波器的时间常数定义低通滤波器特性。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Bandwidth NEP</td><td style='text-align: center; word-wrap: break-word;'>使用滤波器的噪声等效功率带宽定义低通滤波器特性。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Bandwidth 3 dB</td><td style='text-align: center; word-wrap: break-word;'>使用滤波器的截止频率定义低通滤波器特性。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Time</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>定义固定带宽扫描模式下的测量带宽，并根据选择对应到噪声等效功率带宽(NEP)、时间常数(TC)或3 dB 带宽(3 dB)。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Order</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>在固定带宽模式下选择要用于扫描的滤波器滚降系数。范围在6 dB/oct和48 dB/oct之间。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Max Bandwidth (Hz)</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>自动带宽模式下使用的最大带宽。有效带宽将基于该最大值、频率步长和omega 抑制来计算。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>BW Overlap</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>如果启用，扫描点的带宽可能会与相邻扫描点的频率重叠。有效带宽仅受最大带宽设置和omega 抑制的限制。因此，带宽与扫描点数量无关。对于频率响应分析，应启用带宽重叠以实现最大扫描速度。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Omega Suppression (dB)</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>抑制omega 和2-omega 分量。大幅抑制将对扫描时间产生显著影响，尤其是对于低阶滤波器。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Min Settling Time (s)</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>从扫描参数更改到记录下一个扫描点的最短等待时间（以秒为单位）。此参数可用于定义实验测量装置所需的稳定时间。有效等待时间取该值与解调器滤波器稳定时间（由指定的不精确度值确定）之间的最大值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Inaccuracy</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>解调器滤波器稳定不精确度，定义从扫描参数更改到记录下一个扫描点的等待时间。稳定时间计算的是达到输入阶跃函数的指定剩余比[1e-13, 0.1]所需的时间。典型的不精确度值：对于大信号的最高扫描速度为10 m，对于精确幅值测量为100 u，对于精确噪声测量为100 n。稳定精度将定义参数扫描仪必须等待的时间（以滤波器时间常数的数量表示），具体取决于阶数。取该值与稳定时间之间的最大值作为记录下一个扫描点之前的等待时间。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Settling Time (TC)</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>计算的等待时间以指定滤波器稳定不精确度定义的时间常数表示。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Algorithm</td><td style='text-align: center; word-wrap: break-word;'>Averaging</td><td style='text-align: center; word-wrap: break-word;'>选择测量方法。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Standard Deviation</td><td style='text-align: center; word-wrap: break-word;'>计算每个数据集的平均值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Average Power</td><td style='text-align: center; word-wrap: break-word;'>计算每个数据集的标准差。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Count (Sa)</td><td style='text-align: center; word-wrap: break-word;'>整数</td><td style='text-align: center; word-wrap: break-word;'>基于50 \Omega 输入阻抗计算电功率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>整数</td><td style='text-align: center; word-wrap: break-word;'>设置测量中考虑的每个参数扫描仪参数点的数据样本数。取样本、时间和时间常数的数量三者之间的最大值作为有效计算时间。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Count (s)</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>设置处理数据样本的时间。取样本、时间和时间常数的数量三者之间的最大值作为有效计算时间。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Count (TC)</td><td style='text-align: center; word-wrap: break-word;'>0/5/15/50/100 TC</td><td style='text-align: center; word-wrap: break-word;'>设置测量中考虑的每个参数扫描仪参数点的有效测量时间。取样本、时间和时间常数的数量三者之间的最大值作为有效计算时间。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Phase Unwrap</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>允许在  $ \pm $ 180 度范围内重建缓慢变化的相位。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Spectral Density</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>选择是否将测量结果相对于解调带宽进行归一化处理。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sinc Filter</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>如果扫描频率低于 50 Hz，则启用 sinc 滤波器。启用后将改善低频条件下的扫描速度，因为不需要通过正常低通滤波器来抑制 omega 分量。</td></tr></table>








<div style="text-align: center;"><div style="text-align: center;">表 4.37. Sweeper（参数扫描仪）选项卡：History（历史记录）子选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>History</td><td style='text-align: center; word-wrap: break-word;'>History</td><td style='text-align: center; word-wrap: break-word;'>列表中的每个条目对应于历史记录中的单条迹线。绘图中显示的迹线数量最多为20。使用切换按钮可隐藏或显示各迹线。使用颜色选择器可更改绘图中迹线的颜色。双击列表条目可编辑其名称。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Length</td><td style='text-align: center; word-wrap: break-word;'>整数值</td><td style='text-align: center; word-wrap: break-word;'>历史记录中的最大记录数。列表中显示的条目数被限制为最近的100个条目。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Clear All</td><td style='text-align: center; word-wrap: break-word;'>Clear All</td><td style='text-align: center; word-wrap: break-word;'>从历史记录列表中删除所有记录。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Clear</td><td style='text-align: center; word-wrap: break-word;'>Clear</td><td style='text-align: center; word-wrap: break-word;'>从历史记录列表中删除所选记录。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Load file</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>将数据从文件加载到历史记录。加载操作不会改变在绘图中显示的数据类型和范围，如果数据未显示，则需要手动调整。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Name</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>输入一个名称用作文件夹名称以保存历史记录。另外向文件夹名称中添加一个三位数计数器，以标识连续保存到同一文件夹名称。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Auto Save</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>激活自动保存功能。激活后将自动保存历史记录中的所有测量结果，以及之后的每一个测量结果。自动保存目录可通过名称中的文本“autosave”来识别，例如“sweep_autosave_001”。如果在连续运行模块期间激活自动保存功能，则每次连续的测量结果都会保存到同一个目录下。对于单触发操作，会创建一个新目录来包含历史记录中的所有测量结果。根据不同的文件格式，测量结果会附加到同一文件中或保存在单独的文件中。对于HDF5和ZView格式，测量结果会附加到同一文件中。对于MATLAB和SXM格式，每一个测量结果都保存在单独的文件中。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>File Format</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择保存数据时采用的文件格式。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Save</td><td style='text-align: center; word-wrap: break-word;'>Save</td><td style='text-align: center; word-wrap: break-word;'>将历史记录中的迹线保存到可在File Manager（文件管理器）选项卡中访问的文件中。该文件包含Control（控制）子选项卡的Vertical Axis Groups（垂直轴组）中的信号。保存的数据取决于下拉列表中的选择。Save All：保存所有迹线。Save Sel：保存所选迹线。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Reference</td><td style='text-align: center; word-wrap: break-word;'>Reference</td><td style='text-align: center; word-wrap: break-word;'>使用所选迹线作为所有活动迹线的参考。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Reference On</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>启用/禁用参考模式。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Reference name</td><td style='text-align: center; word-wrap: break-word;'>name</td><td style='text-align: center; word-wrap: break-word;'>所用参考迹线的名称。</td></tr></table>

有关 Math（数学）子选项卡的信息，请参见“光标和数学”一节中的“绘图数学描述”表。

### 4.11. Auxiliary（辅助）选项卡

通过 Auxiliary（辅助）选项卡可访问辅助输入端和辅助输出端的设置，该选项卡可用于所有 MFLI 仪器。

#### 4.11.1. 特征

一 监控辅助输入连接器的信号电平

一 监控辅助输出连接器的信号电平

一 辅助输出信号源：解调器和手动设置

一 定义辅助输出值的偏移和比例

一 控制辅助输出范围限制

#### 4.11.2. 描述

Auxiliary（辅助）选项卡主要监视和控制辅助输入和输出。当该选项卡关闭或需要其他相同类型的选项卡时，单击以下图标即可打开该选项卡的新实例。

<div style="text-align: center;"><div style="text-align: center;">表 4.38. 应用图标和简要描述</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Aux</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>控制与辅助输入和辅助输出有关的所有设置。</td></tr></table>

Auxiliary（辅助）选项卡（参见图 4.29）分为三个部分。Aux Input（辅助输入）部分有两个图形监控器和两个数字监控器，监控应用于后面板上的辅助输入端的信号幅值。选项卡中间是 Aux Output（辅助输出）部分，能够将任何测量信号关联到仪器前面板的 4 个辅助输出端中的任何一个。通过 Preoffset（预偏移）值和 Offset（偏移）值旁边的操作按钮，可将辅助输出端的有效电压自动设置为零。模拟输出电压可限制到特定范围，以免损害连接到输出端的部件。

##### 注释

请注意，比例因子的单位的变化取决于所选的测量信号。

右侧的两个 Aux Output Levels（辅助输出电平）提供 4 个图形指示器和 4 个数字指示器，用于监控辅助输出端当前设置的电压。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//3fb9fb28-2c10-4dab-9555-8f83cdedc8cb/markdown_3/imgs/img_in_image_box_215_1146_1074_1342.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A56Z%2F-1%2F%2F73174f6e9374f0513b18b747c6abbe7a349e35d3bda47431624902f083fa6764" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.29.LabOne UI: Auxiliary（辅助）选项卡</div> </div>


#### 4.11.3. 功能元素

<div style="text-align: center;"><div style="text-align: center;">表 4.39. Auxiliary（辅助）选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Preoffset</td><td style='text-align: center; word-wrap: break-word;'>采用相应信号单位的数值</td><td style='text-align: center; word-wrap: break-word;'>在应用缩放之前，向信号添加预偏移量。辅助输出值 =  $ Signal + Preoffset \times Scale + Offset $</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Auto-zero</td><td style='text-align: center; word-wrap: break-word;'>▶▶</td><td style='text-align: center; word-wrap: break-word;'>自动调整预偏移量以将辅助输出值设置为零。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Scale</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>用于缩放信号的乘法因子。辅助输出值 =  $ Signal + Preoffset \times Scale + Offset $</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Offset</td><td style='text-align: center; word-wrap: break-word;'>以伏特为单位的数值</td><td style='text-align: center; word-wrap: break-word;'>在缩放后将指定的偏移电压添加到信号。辅助输出值 =  $ Signal + Preoffset \times Scale + Offset $</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lower Limit</td><td style='text-align: center; word-wrap: break-word;'>-10 V 至 10 V</td><td style='text-align: center; word-wrap: break-word;'>辅助输出端信号的下限。如果数值过小，则会选择取值范围下限。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Upper Limit</td><td style='text-align: center; word-wrap: break-word;'>-10 V 至 10 V</td><td style='text-align: center; word-wrap: break-word;'>辅助输出端信号的上限。如果数值过大，则会选择取值范围上限。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Value</td><td style='text-align: center; word-wrap: break-word;'>-10 V 至 10 V</td><td style='text-align: center; word-wrap: break-word;'>辅助输出端的电压。辅助输出值 =  $ Signal + Preoffset \times Scale + Offset $</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Auxiliary Input Voltage</td><td style='text-align: center; word-wrap: break-word;'>-10 V 至 10 V</td><td style='text-align: center; word-wrap: break-word;'>在辅助输入端测得的电压。</td></tr><tr><td rowspan="11">Signal</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择辅助输出所表示的信号源。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID Out</td><td style='text-align: center; word-wrap: break-word;'>选择其中一个PID控制器的输出。需要安装MF-PID选件。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID Shift</td><td style='text-align: center; word-wrap: break-word;'>选择其中一个PID控制器的偏移信号。需要安装MF-PID选件。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID Error</td><td style='text-align: center; word-wrap: break-word;'>选择其中一个PID控制器的误差信号。需要安装MF-PID选件。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>TU Filtered Value</td><td style='text-align: center; word-wrap: break-word;'>选择其中一个经滤波的阈值单元输入信号作为辅助输出。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>TU Output Value</td><td style='text-align: center; word-wrap: break-word;'>选择其中一个阈值单元输出信号作为辅助输出。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>X</td><td style='text-align: center; word-wrap: break-word;'>选择解调器X分量作为辅助输出。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Y</td><td style='text-align: center; word-wrap: break-word;'>选择解调器Y分量作为辅助输出。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>R</td><td style='text-align: center; word-wrap: break-word;'>选择解调器幅值分量作为辅助输出。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>\Theta</td><td style='text-align: center; word-wrap: break-word;'>选择解调器相位分量作为辅助输出。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Manual</td><td style='text-align: center; word-wrap: break-word;'>使用Offset（偏移）字段手动定义辅助输出电压。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Channel</td><td style='text-align: center; word-wrap: break-word;'>索引</td><td style='text-align: center; word-wrap: break-word;'>根据所选信号源选择通道。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Auto-zero</td><td style='text-align: center; word-wrap: break-word;'>▶▶</td><td style='text-align: center; word-wrap: break-word;'>自动调整偏移量以将辅助输出值设置为零。</td></tr></table>

### 4.12.Inputs/Outputs（输入/输出）选项卡

通过 In / Out（输入/输出）选项卡可访问仪器主要信号输入和信号输出的设置。该选项卡可用于所有 MFLI 仪器。

#### 4.12.1. 特征

信号输入配置

信号输出配置

#### 4.12.2. 描述

通过 In / Out（输入/输出）选项卡可访问与 Lock-in（锁相）选项卡最左侧和最右侧部分相同的设置。该选项卡主要用于无法一次显示整个 Lock-in（锁相）选项卡的小屏幕。当该选项卡关闭或需要其他相同类型的选项卡时，单击以下图标即可打开该选项卡的新实例。

<div style="text-align: center;"><div style="text-align: center;">表 4.40. 应用图标和简要描述</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>In/Out</td><td style='text-align: center; word-wrap: break-word;'>☑</td><td style='text-align: center; word-wrap: break-word;'>允许访问仪器前面板上与信号输入和信号输出相关的所有控件。</td></tr></table>

In/Out（输入/输出）选项卡包括两个部分，分别为 Signal Inputs（信号输入）部分和 Signal Outputs（信号输出）部分。所有对应连接器均位于仪器前面板。安装或未安装 MF-MD 多解调器选件的仪器上的 In/Out（输入/输出）选项卡也不同。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//33d7d2f3-c060-4e31-87a7-c2465f388b9e/markdown_0/imgs/img_in_image_box_216_797_1074_993.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A59Z%2F-1%2F%2Fc4dd141e1e6cda5f08152fdbdd35051068832a2b974ccb4475d474e697949027" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.30.LabOne UI: Inputs/Outputs（输入/输出）选项卡（基础配置）</div> </div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//33d7d2f3-c060-4e31-87a7-c2465f388b9e/markdown_0/imgs/img_in_image_box_215_1044_1073_1241.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A59Z%2F-1%2F%2F1fcdd0b71037f3f135bdc904f90c06a8189e05e922d2d8d2972e9f2913fdfbca" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.31.LabOne UI: Inputs/Outputs（输入/输出）选项卡（安装 MF-MD 多解调器选件）</div> </div>


#### 4.12.3. 功能元素

所有功能元素均与 Lock-in（锁相）选项卡相同。有关功能元素的详细描述，请参见 Lock-in（锁相）选项卡或 Lock-in MF（锁相 MF）选项卡。

### 4.13.DIO 选项卡

通过 DIO 选项卡可访问数字 I/O 和触发通道的设置和控件，该选项卡可用于所有 MFLI 仪器。

#### 4.13.1. 特征

一 监视和控制数字 I/O 连接器

一 控制外置参考和触发的设置

#### 4.13.2. 描述

DIO 选项卡是控制数字输入和输出以及触发电平和外部参考通道的主面板。当该选项卡关闭或需要其他相同类型的选项卡时，单击以下图标即可打开该选项卡的新实例。

<div style="text-align: center;"><div style="text-align: center;">表 4.41. 应用图标和简要描述</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DIO</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>允许访问与数字输入和输出相关的所有控件，包括 Ref/Trigger 连接器。</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">图 4.32.LabOne UI: DIO 选项卡</div> </div>


Digital I/O（数字 I/O）部分提供数字监控器，用于观察数字输入和输出的状态。此外，通过设置 Output（输出）列中的值并激活 Drive（驱动）按钮，还可以不同的数字格式主动设置状态。

触发部分显示的是仪器后面板上的 2 个触发输入和 2 个触发输出的设置。触发输出可以参考解调器频率，并输出占空比为 50% 的 TTL 信号。

##### 注释

输入电平决定了触发状态判别的触发阈值。此外，滞后值为 100 mV 且不可调整，这样幅值至少达 100 mV，触发输入才能稳定。

#### 4.13.3. 功能元素

<div style="text-align: center;"><div style="text-align: center;">表 4.42. 数字输入和输出通道，参考和触发</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td rowspan="3">DIO mode</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择 DIO 模式</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Threshold outputs</td><td style='text-align: center; word-wrap: break-word;'>允许通过阈值单元设置 DIO 输出值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Manual</td><td style='text-align: center; word-wrap: break-word;'>允许手动控制 DIO 输出位数。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>QA Result Overflow</td><td style='text-align: center; word-wrap: break-word;'>灰色/黄色/红色</td><td style='text-align: center; word-wrap: break-word;'>红色：读取时 DIO 接口发生溢出。黄色：表示过去曾发生溢出。当读取的触发速度超过 DIO 接口的数据速率上限时，可能发生溢出。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DIO bits</td><td style='text-align: center; word-wrap: break-word;'>标签</td><td style='text-align: center; word-wrap: break-word;'>将32位DIO分成4条总线，每条总线8位。每条总线都可以用作输入或输出。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DIO input</td><td style='text-align: center; word-wrap: break-word;'>十六进制或二进制格式的数值</td><td style='text-align: center; word-wrap: break-word;'>DIO输入端口的当前数字值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DIO output</td><td style='text-align: center; word-wrap: break-word;'>十六进制或二进制格式的数值</td><td style='text-align: center; word-wrap: break-word;'>数字输出值。启用驱动器以将信号施加到输出端。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DIO drive</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>开启时，相应的8位总线处于输出模式。关闭时，相应的8位总线处于输入模式。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Format</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择DIO视图格式。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Hexadecimal</td><td style='text-align: center; word-wrap: break-word;'>DIO视图格式为十六进制。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Binary</td><td style='text-align: center; word-wrap: break-word;'>DIO视图格式为二进制。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Clock</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>为DIO选择内部或外部时钟。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Internal 60 MHz</td><td style='text-align: center; word-wrap: break-word;'>在内部为DIO提供60 MHz固定频率的时钟。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Clk Pin 68</td><td style='text-align: center; word-wrap: break-word;'>通过将时钟信号连接到DIO引脚68，从外部为DIO提供时钟。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>可用频率范围为1 Hz至60 MHz。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Trigger level</td><td style='text-align: center; word-wrap: break-word;'>-5 V至5 V</td><td style='text-align: center; word-wrap: break-word;'>使触发输入在低电平和高电平之间切换的触发电压电平。对数字输入使用50%的幅值，并考虑触发滞后情况。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Auto Threshold</td><td style='text-align: center; word-wrap: break-word;'>按一下</td><td style='text-align: center; word-wrap: break-word;'>自动调整触发阈值。电平经调整后会处于目标电平转换的中心电平位置。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Trigger Input Low status</td><td style='text-align: center; word-wrap: break-word;'>Off</td><td style='text-align: center; word-wrap: break-word;'>指示当前为低电平触发状态。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>On</td><td style='text-align: center; word-wrap: break-word;'>未触发低电平状态。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Trigger Input High status</td><td style='text-align: center; word-wrap: break-word;'>Off</td><td style='text-align: center; word-wrap: break-word;'>触发了低电平状态。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>On</td><td style='text-align: center; word-wrap: break-word;'>指示当前为高电平触发状态。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>On</td><td style='text-align: center; word-wrap: break-word;'>未触发高电平状态。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Trigger output signal</td><td style='text-align: center; word-wrap: break-word;'>Off</td><td style='text-align: center; word-wrap: break-word;'>触发了高电平状态。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Off</td><td style='text-align: center; word-wrap: break-word;'>选择分配给触发输出的信号。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Osc Phase Demod 2/4</td><td style='text-align: center; word-wrap: break-word;'>禁用输出触发。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Osc Phase Demod 2/4</td><td style='text-align: center; word-wrap: break-word;'>demod 2（触发输出通道1）或demod 4（触发输出通道2）的振荡器相位。在振荡器相位的每个过零点，均输出触发事件。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Scope Trigger</td><td style='text-align: center; word-wrap: break-word;'>当满足示波器触发条件时，将触发输出置为有效。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Scope/Trigger</td><td style='text-align: center; word-wrap: break-word;'>当满足示波器触发条件时，将触发输出置为无效。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Scope Armed</td><td style='text-align: center; word-wrap: break-word;'>在示波器等待触发条件得到满足的过程中，将触发输出置为有效。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Scope/Armed</td><td style='text-align: center; word-wrap: break-word;'>在示波器等待触发条件得到满足的过程中，将触发输出置为无效。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Scope Active</td><td style='text-align: center; word-wrap: break-word;'>当示波器已触发且正在记录数据时，将触发输出置为有效。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Scope/Active</td><td style='text-align: center; word-wrap: break-word;'>当示波器已触发且正在记录数据时，将触发输出置为无效。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Threshold 1</td><td style='text-align: center; word-wrap: break-word;'>阈值逻辑单元1输出。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Threshold 2</td><td style='text-align: center; word-wrap: break-word;'>阈值逻辑单元2输出。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Threshold 3</td><td style='text-align: center; word-wrap: break-word;'>阈值逻辑单元3输出。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Threshold 4</td><td style='text-align: center; word-wrap: break-word;'>阈值逻辑单元4输出。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>MDSSync Out</td><td style='text-align: center; word-wrap: break-word;'>触发输出由多设备同步信号驱动。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Width</td><td style='text-align: center; word-wrap: break-word;'>0 s至0.149 s</td><td style='text-align: center; word-wrap: break-word;'>定义在将示波器事件写入设备的触发输出时的最小脉宽。</td></tr></table>





### 4.14. Impedance Analyzer（阻抗分析仪）选项卡

Impedance Analyzer（阻抗分析仪）选项卡可用于 MFIA 阻抗分析仪和已安装 MF-IA 阻抗分析仪选件的 MFLI 锁相放大器（参见 Device（设备）选项卡的 Information（信息）部分）。

#### 4.14.1. 特征

一 控制阻抗分析仪单元（带有 MF-MD 选件时为 2 个单元）

一 自动调整量程和自动带宽

一 图形化显示测量模式：2 端子和 4 端子配置

一 图形化显示 DUT 表示法：Rp||Cp、Rs+Cs、Ls+Rs、C、D……

基本精度可达 0.05%

1 mΩ 至 10 GΩ 测量范围

基本精度下的测量速度达 20 ms

一 SOL 智能补偿和其他补偿程序

一 置信度指示器

一 单独测量电流和电压

一 对低频阻抗测量应用单周期平均功能

#### 4.14.2. 描述

Impedance Analyzer（阻抗分析仪）选项卡是阻抗测量的主要控制面板。该选项卡在 MFIA 抗阻分析仪上默认已打开。当该选项卡关闭或需要其他相同类型的选项卡时，单击以下图标即可打开该选项卡的新实例。

<div style="text-align: center;"><div style="text-align: center;">表 4.43. 应用图标和简要描述</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>IA</td><td style='text-align: center; word-wrap: break-word;'>043</td><td style='text-align: center; word-wrap: break-word;'>快速纵览和访问关于阻抗测量的所有设置和属性。</td></tr></table>

Impedance Analyzer（阻抗分析仪）选项卡分为一个侧边栏选项卡，用于每个阻抗分析仪单元，还有一个 Cal（校准）侧边栏选项卡，可访问 Compensation Advisor（智能补偿）。阻抗分析仪单元的编号侧边栏选项卡（参见图 4.33）是主要的测量界面。可通过左侧的 Measurement Control（测量控制）部分访问主要设置。Equivalent Circuit（等效电路）部分包含控件，用于配置由图形电路图可视化的电路表示。在 Mode（模式）设置下，用户可根据被测设备（DUT）的物理布线选择 2 端子或 4 端子设置。在 Representation（表示）设置下，用户可将测量阻抗 Z 转换为 DUT 电路表示的参数对，例如并联电阻和电容（Rp || Cp）或串联电阻和电感（Rs + Ls）。数据显示在右侧的 Measurement Results（测量结果）部分。等效电路参数在 Measurement（测量）UI 的其他地方显示为表示参数 1 和 2，例如在第 4.5 节或第 4.6 节所述选项卡中。左上角的 Enable（启用）按钮通过打开驱动电压并开始电流和电压测量来启动测量。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//33d7d2f3-c060-4e31-87a7-c2465f388b9e/markdown_4/imgs/img_in_image_box_216_112_1074_286.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A03Z%2F-1%2F%2Fecf63d6429bbce6526b9b17d015c1b6826a2134945c2ee16d4eccbcb76970d3d" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.33.LabOne UI: Impedance Analyzer（阻抗分析仪）选项卡（Application（应用）模式）</div> </div>


该选项卡的 Measurement Control（测量控制）部分包括与测量范围、频率以及输出驱动幅值相关的设置。默认情况下，所有这些参数都由阻抗分析仪自动控制，提供适合大多数情况的设置。在部分高级用例中可以进行手动控制。例如通过将 Range Control（范围控制）设置为 Manual（手动）或 Impedance（阻抗）即可禁用自动设置，从而有助于防止参数扫描仪在测量时出现范围变动。在强噪声条件下，启用 Manual Bandwidth Control（手动带宽控制）具有一定优势。这样就可以通过调整测量带宽来平衡测量速度和精度。在 Auto Bandwidth（自动带宽）模式下，仪器根据想要的  $ \Omega $ 抑制来选择适合的带宽（参见 Sinc 滤波）。例如，禁用自动 Drive Control（驱动控制）后，用户可在测量电敏 DUT 时指定驱动幅值。带宽和驱动幅值的数值控件可通过第 4.3 节所述选项卡访问。

从 Measurement Control（测量控制）部分的 Application（应用）模式切换到 Advanced（高级）模式后，可在选项卡的下半部分访问关于信号带宽、数字数据传输等的更多高级控件，参见图 4.34。Confidence Indicators（置信度指示器）可控制多种有助于测量的功能。指示器在第 4.10 节、第 4.6 节和第 4.5 节所述的选项卡中提供警报消息，以防止误解测量数据。不同警报消息的含义如下表所示。所有指示器都可以单独启用或禁用，数值设置可以对误差阈值进行微调。使用 Discard Samples（丢弃样本）功能，用户可以通过阈值来剔除异常的测量值。

对于低频阻抗测量，可启用单周期平均功能（位于 Measurement Control（测量控制）子选项卡）。启用后，单周期平均功能将在频率低于频率阈值（由数据传输速率定义）时自动激活，并在频率高于该阈值时使用标准测量模式。当上述功能处于激活状态时，Enable（启用）开关旁的 LED 将亮绿灯。与标准测量模式不同的是，单周期平均功能使用替代方法来计算阻抗，即测量单个周期的电流和电压，然后平均以计算阻抗，这种技术通过在一个完整周期内求平均值来抑制不需要的  $ \omega $ 分量。相比之下，MFIA 的标准测量模式是使用低通滤波器来滤除不需要的  $ \omega $ 分量。单周期平均功能是优点是提高了低频测量速度，因为可以使用更宽松（更快）的滤波器设置。

在使用单周期平均功能期间，Demod 信号将包含大量的  $ \omega $ 分量，因此无法返回可靠的值。如果需要 Demod 流，则必须关闭单周期平均功能。第 4.10 节和第 4.6 节都可采用单周期平均功能来计算阻抗。请注意，在测量的第一个周期内，由于没有可用的有效结果，因此不会传输数据。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//33d7d2f3-c060-4e31-87a7-c2465f388b9e/markdown_4/imgs/img_in_image_box_216_1061_1074_1353.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A03Z%2F-1%2F%2F78a22f916a396358475a5a8db5854ba8e0493b14c2ea3ca43744f51846e44e50" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.34.LabOne UI: Impedance Analyzer（阻抗分析仪）选项卡（Advanced（高级）模式）</div> </div>


<div style="text-align: center;"><div style="text-align: center;">表 4.44. 置信度指示器提供的警报消息列表。</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>置信度指示器</td><td style='text-align: center; word-wrap: break-word;'>警报消息</td><td style='text-align: center; word-wrap: break-word;'>情况</td><td style='text-align: center; word-wrap: break-word;'>校正动作</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Suppression</td><td style='text-align: center; word-wrap: break-word;'>Suppression</td><td style='text-align: center; word-wrap: break-word;'>DUT 阻抗分量差异很大。已标记的表示参数的计算不可靠。</td><td style='text-align: center; word-wrap: break-word;'>更改测量频率，选择与 DUT 对应的合适表示。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Compensation</td><td style='text-align: center; word-wrap: break-word;'>Strong Compensation</td><td style='text-align: center; word-wrap: break-word;'>在一个参数范围内进行测量，在该参数范围内，用户补偿会强制进行较大校正，使测量不可靠。</td><td style='text-align: center; word-wrap: break-word;'>检查测试夹具是否适合测量的阻抗范围和频率。</td></tr><tr><td rowspan="2">Open Detect</td><td rowspan="2">Open Detected</td><td rowspan="2">4 端子中的 1 个端子断连</td><td style='text-align: center; word-wrap: break-word;'>检查所选的补偿方法是否适合阻抗范围。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>考虑采用阶跃“载荷”，选取靠近测量范围的负荷。</td></tr><tr><td rowspan="2">Underflow Detect</td><td rowspan="2">Current Underflow, Voltage Underflow</td><td rowspan="2">电压或电流读数接近零</td><td style='text-align: center; word-wrap: break-word;'>检查 DUT 是否正确接线（例如在 4 端子测量中接了 2 端子 DUT）。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>检查连接断路。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Overflow Detect</td><td style='text-align: center; word-wrap: break-word;'>Current Overflow, Voltage Overflow</td><td style='text-align: center; word-wrap: break-word;'>电压或电流读数接近或超过输入范围</td><td style='text-align: center; word-wrap: break-word;'>检查连接开路。如果连接正确无误，则检查范围模式设置为 Manual（手动）或 Impedance（阻抗）时所选的范围是否适合测量阻抗。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Frequency Limit</td><td style='text-align: center; word-wrap: break-word;'>Freq Limit</td><td style='text-align: center; word-wrap: break-word;'>测量频率高于所选电流输入范围的带宽</td><td style='text-align: center; word-wrap: break-word;'>在 Range Control（范围控制）设置中选择更大的电流范围，或将 Range Control（范围控制）设为 Auto（自动）。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Negative Q/D</td><td style='text-align: center; word-wrap: break-word;'>Negative Q/D</td><td style='text-align: center; word-wrap: break-word;'>测量的 Q 或 D 因子，或用于计算得出所示平均值的任何测量值为负数</td><td style='text-align: center; word-wrap: break-word;'>检查所选的表示是否对应连接的 DUT，评估应用的补偿的质量，并检查是否存在强噪声。负 Q 或 D 因子表示测量阻抗无法物理映射到所选择的表示。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Z too low for 2-terminal</td><td style='text-align: center; word-wrap: break-word;'>Low DUT 2T</td><td style='text-align: center; word-wrap: break-word;'>2 端子测量中，测量的 Z 低于定义的阈值</td><td style='text-align: center; word-wrap: break-word;'>对于低阻抗测量，建议使用 4 端子测量。可在 Impedance（阻抗）选项卡的 Advance（高级）部分手动调整或禁用置信度指示器的阈值</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Different representation</td><td style='text-align: center; word-wrap: break-word;'>Different representation</td><td style='text-align: center; word-wrap: break-word;'>此标志高亮显示所显示的数据集中使用等效电路表示而不是上一组表示获得的迹线</td><td style='text-align: center; word-wrap: break-word;'>使用 History（历史记录）选项卡从记录的数据中删除这些迹线，或以要求的表示重启数据</td></tr></table>

#### 4.14.3. Compensation（补偿）

Cal（校准）侧边栏选项卡（参见图 4.35）通过补偿程序提供用户指导。补偿降低了测试夹具寄生效应的影响，从而提高了测量精度。这需要测量一个或多个阻抗值在某个频率范围内精确已知的参考被测设备（DUT）。可用的补偿方法是组合测量短路（“S”、零阻抗的 DUT）、开路（“O”、无限阻抗的 DUT）和负荷（“L”、已知任意值阻抗的 DUT）。请查看《MFIA 阻抗分析仪用户手册》的“信

号处理”章节，了解补偿的背景和实用性，并查看本文档的“教程”部分，了解具体示例的分步说明。可访问 Zurich Instruments 网站获取《MFIA 用户手册》。准备补偿时，需要选择适当的模式、连接参考 DUT 后单击。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//bbdb834b-e7d1-4101-beaa-8c0986723add/markdown_1/imgs/img_in_image_box_215_204_1080_443.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A58Z%2F-1%2F%2Ff6b999c689784312455ec26fb043da10ae86e363b78079f315df0bf0b78cf748" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.35.LabOne UI: Impedance Analyzer（阻抗分析仪）选项卡（Cal（校准）侧边栏选项卡）</div> </div>


#### 4.14.4. 功能元素

<div style="text-align: center;"><div style="text-align: center;">表 4.45.Impedance Analyzer（阻抗分析仪）选项卡：Control（控制）子选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Enable</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>启用解调器数据的阻抗计算。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>One-Period Averaging</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>对低频阻抗测量启用单周期平均功能。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>One-Period Averaging</td><td style='text-align: center; word-wrap: break-word;'>灰色/绿色</td><td style='text-align: center; word-wrap: break-word;'>单周期平均功能激活时 LED 亮绿灯。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lower Frequency Limit (Hz)</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>启用电流输入范围的频率下限。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Upper Frequency Limit (Hz)</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>启用电流输入范围的频率上限。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Cable Length</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>用于测量装置的单向 RG58 电缆长度。此设置可用于校正理想电缆引入的相移。</td></tr><tr><td rowspan="11">Representation</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>通过两个实数值表示复数阻抗值 Z，这两个实数值可在所有用户界面显示画面中作为 Parameter 1 和 Parameter 2 进行访问。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Rp || Cp</td><td style='text-align: center; word-wrap: break-word;'>阻抗值 Z 由并联的电阻元件 Rp 与电容元件 Cp 表示。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Rs + Cs</td><td style='text-align: center; word-wrap: break-word;'>阻抗值 Z 由串联的电阻元件 Rs 与电容元件 Cs 表示。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Rs + Ls</td><td style='text-align: center; word-wrap: break-word;'>阻抗值 Z 由串联的电阻元件 Rs 与电感元件 Ls 表示。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>GB</td><td style='text-align: center; word-wrap: break-word;'>阻抗值 Z 由导纳 Y = 1/Z 的电导 G = Real(Y) 和电纳 B = Imag(Y) 表示。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DCs</td><td style='text-align: center; word-wrap: break-word;'>阻抗值 Z 由损耗系数 D = -Real(Z)/Imag(Z)（损耗角正切）和电容元件表示。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>QCs</td><td style='text-align: center; word-wrap: break-word;'>阻抗值 Z 由品质因数 Q = -Imag(Z)/Real(Z) 和电容元件表示。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DLs</td><td style='text-align: center; word-wrap: break-word;'>阻抗值 Z 由损耗系数 D = Real(Z)/Imag(Z)（损耗角正切）和电感元件表示。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>QLs</td><td style='text-align: center; word-wrap: break-word;'>阻抗值 Z 由品质因数 Q = Imag(Z)/Real(Z) 和电感元件表示。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Rp || Lp</td><td style='text-align: center; word-wrap: break-word;'>阻抗值 Z 由并联的电阻元件 Rp 与电感元件 Lp 表示。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DCp</td><td style='text-align: center; word-wrap: break-word;'>阻抗值 Z 由损耗系数 D = -Real(Z)/Imag(Z)（损耗角正切）和电容元件表示。</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">4.14 Impedance Analyzer（阻抗分析仪）选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Real(Z)</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>测量阻抗 Z 的实部。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Imag(Z)</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>测量阻抗 Z 的虚部。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Abs(Z)</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>测量阻抗 Z 的绝对值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Phase(Z)</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>测量阻抗 Z 的相位。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Frequency</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>测量电流阻抗时所采用的频率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Parameter 1</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>当前有效表示参数 1 和相应的测量值。表示基于测量阻抗和频率。表示仅在特定频率或阻抗区域内有效。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Parameter 2</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>当前有效表示参数 2 和相应的测量值。表示基于测量阻抗和频率。表示仅在特定频率或阻抗区域内有效。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Osc Frequency</td><td style='text-align: center; word-wrap: break-word;'>0 至 5 MHz</td><td style='text-align: center; word-wrap: break-word;'>用于阻抗测量的振荡器的频率控制。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Range Control</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择输入范围控制模式。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Manual</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>在手动模式下，电流和电压输入范围可以手动方式单独调整。请小心使用此模式，因为过载会导致阻抗结果不准确。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Auto</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>根据测得的输入信号强度动态调整输入范围。这样可以优化阻抗测量的动态范围和精度。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Current Zone</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>可通过此调整范围选项手动设置所有八个电流输入范围的切换频率限值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Range Control</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>指示禁用定期自动范围控制。正在运行的参数扫描仪模块会接管范围控制，因此会禁用定期范围检查。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Override</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Current Range</td><td style='text-align: center; word-wrap: break-word;'>100 nA、1 \mu A、10 \mu A、100 \mu A、10 mA、10 mA</td><td style='text-align: center; word-wrap: break-word;'>用于阻抗测量的输入电流范围。如果电流输入范围较小，带宽也会减小。在“Auto”和“Impedance”两种范围控制模式下，如果频率过高，电流范围会自动切换到更高的范围。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Voltage Range</td><td style='text-align: center; word-wrap: break-word;'>10 mV、30 mV、100 mV、300 mV、1 V、3.0 V</td><td style='text-align: center; word-wrap: break-word;'>用于阻抗测量的输入电压范围。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Drive Control</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>如果启用，驱动电压幅值由设备控制。如果禁用，可以手动设置。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Test Signal (V)</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>信号输出的驱动幅值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Bandwidth Control</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>启用自动带宽控制。如果启用，则基于频率和测量数据计算最佳带宽。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Max Bandwidth (Hz)</td><td style='text-align: center; word-wrap: break-word;'>正数值</td><td style='text-align: center; word-wrap: break-word;'>解调器滤波器使用的最大带宽限制。如果数值高于 1 kHz，则会导致高频区域（高频区域的幅值随频率而变化）的测量精度大幅降低。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>w Suppression (dB)</td><td style='text-align: center; word-wrap: break-word;'>正数值</td><td style='text-align: center; word-wrap: break-word;'>抑制 omega 和 2-omega 分量。如果 \Omega 抑制较小，则会减少对极低或极高阻抗的测量，因为直流分量会占据主导地位。如果 \Omega 抑制较大，则会对扫描时间产生显著影响，尤其是对于低阶滤波器。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Suppression Ratio</td><td style='text-align: center; word-wrap: break-word;'>1 到 10000</td><td style='text-align: center; word-wrap: break-word;'>误差放大限制，如果超限，第二个参数会被标记为不可靠。增益值越大，警告容差越大。介于 10 和 100 之间的增益值最佳。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Suppression Enable</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>抑制置信度指示器用于指示两个电路表示参数中是否有一个无法通过测得的阻抗可靠地计算得出。如果其中一个（主导）表示参数的微小变化导致另一个（抑制）表示参数发生巨大变化，则属于这种情况。这种误差放大表明第二个参数的测量是不可靠的。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Compensation</td><td style='text-align: center; word-wrap: break-word;'>正数值</td><td style='text-align: center; word-wrap: break-word;'>将会触发强补偿警告的补偿强度。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Compensation Enable</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>启用绘图中的强补偿指示。强补偿会导致参数的测量精度降低。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Low DUT</td><td style='text-align: center; word-wrap: break-word;'>正数值</td><td style='text-align: center; word-wrap: break-word;'>将 2T 测量结果标记为不可靠时对应的 DUT 阻抗最大值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Low DUT Enable</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>执行 2 端子测量时启用低 DUT 阻抗检测。测量低阻抗时使用 4 端子模式。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Open Detect</td><td style='text-align: center; word-wrap: break-word;'>正数值</td><td style='text-align: center; word-wrap: break-word;'>端子开路检测率。如果根据电流和压降计算所得的激励超过根据驱动电压计算的指定因子，则会报告端子开路。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Open Detect Enable</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>启用针对 4 端子测量的端子开路检测。如果启用，则会在 Numeric（数值）选项卡和绘图中指示端子开路。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Underflow Detect</td><td style='text-align: center; word-wrap: break-word;'>正数值</td><td style='text-align: center; word-wrap: break-word;'>如果测得的幅值低于相对于满量程的指定比率，则满足下溢条件。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Underflow Detect Enable</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>启用针对电流和电压的下溢检测。如果启用，则会在 Numeric（数值）选项卡和绘图中显示下溢。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Overload Detect Enable</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>启用针对电流和电压的过载检测。如果启用，则会在 Numeric（数值）选项卡和绘图中显示过载。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Frequency Limit Enable</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>根据使用的电流输入范围启用频率限值检测。如果启用，则会在 Numeric（数值）选项卡和绘图中显示频率限值。该项仅在 Range Control（范围控制）设置为 Manual（手动）时可用。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Negative Q/D Enable</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>启用负 Q 或 D 因子检测。负 Q 或 D 因子表示测量的阻抗与所选择的表示不对应。这可能是由于错误补偿、误选表示或噪声所致。消息将显示在 Numeric（数值）选项卡和绘图中。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Invalid One-period</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>启用因数据样本丢失导致单周期平均值无效的不可靠数据点的检测。尝试降低数据传输速率。</td></tr></table>





<div style="text-align: center;"><div style="text-align: center;">表 4.46.Impedance Analyzer（阻抗分析仪）选项卡：Settings（设置）子选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td rowspan="3">Mode</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>在基于应用的阻抗设置或手动配置的阻抗设置之间切换。通过切换为 Advanced（高级）模式，可以微调 Application（应用）模式给出的参数集。切换回 Application（应用）模式将会复位参数。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Application</td><td style='text-align: center; word-wrap: break-word;'>根据所选应用对阻抗设置进行最为合适的调整。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Advanced</td><td style='text-align: center; word-wrap: break-word;'>手动配置阻抗设置。</td></tr><tr><td rowspan="3">Application</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择 Impedance（阻抗）应用</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>LCR Impedance Measurement</td><td style='text-align: center; word-wrap: break-word;'>用于在有限频率下测量阻抗的通用设置</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DC Impedance Measurement</td><td style='text-align: center; word-wrap: break-word;'>用于在频率为零时测量电阻的设置。</td></tr><tr><td rowspan="4">Precision</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>通过自动调整滤波器带宽来选择阻抗精度和测量速度。如果参数扫描仪模块处于阻抗应用模式，则精度设置还将控制参数扫描仪的测量速度。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Low → fast settling</td><td style='text-align: center; word-wrap: break-word;'>低精度/准确度，快速扫描（经过优化加速响应）。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>High → medium settling</td><td style='text-align: center; word-wrap: break-word;'>高精度/准确度，中速扫描（需要较长时间达到稳定）。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Very high → slow settling</td><td style='text-align: center; word-wrap: break-word;'>超高精度/准确度，慢速扫描（由于带宽极低，需要更长时间达到稳定）。</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">4.14 Impedance Analyzer（阻抗分析仪）选项卡</div> </div>




<table border="1" style="margin: auto; word-wrap: break-word;"><tr><td style="text-align: center; word-wrap: break-word;">控件/工具</td><td style="text-align: center; word-wrap: break-word;">选项/范围</td><td style="text-align: center; word-wrap: break-word;">描述</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Show Advanced</td><td style="text-align: center; word-wrap: break-word;">ON/OFF</td><td style="text-align: center; word-wrap: break-word;">显示高级设置。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Bias Control (V)</td><td style="text-align: center; word-wrap: break-word;">-3 V至3 V</td><td style="text-align: center; word-wrap: break-word;">在待测设备上施加直流偏置电压。既支持正偏置电压，也支持负偏置电压。在4端子测量中，偏置电压会受限于设备的最大公共电压输入范围。在2端子测量中，偏置电压可能更大，因为没有连接电压输入。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Bias Control Enable</td><td style="text-align: center; word-wrap: break-word;">ON/OFF</td><td style="text-align: center; word-wrap: break-word;">启用偏置控制。偏置由施加于输出端的附加偏移产生。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Current Input</td><td style="text-align: center; word-wrap: break-word;">Current Input 1</td><td style="text-align: center; word-wrap: break-word;">选择用于2端子和4端子阻抗测量的电流输入。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Current Invert Enable</td><td style="text-align: center; word-wrap: break-word;">ON/OFF</td><td style="text-align: center; word-wrap: break-word;">如果启用，则会将电流输入信号取反。这对于切换输入信号的极性很有用，因为附加的电流放大器可能会导致输入信号的极性反转。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Scaling factor for current input</td><td style="text-align: center; word-wrap: break-word;">数值</td><td style="text-align: center; word-wrap: break-word;">在电流输入端测得的值将按此比例值进行缩放。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Voltage Input</td><td style="text-align: center; word-wrap: break-word;">Voltage Input 1</td><td style="text-align: center; word-wrap: break-word;">选择用于4端子阻抗测量的电压输入。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Voltage Invert Enable</td><td style="text-align: center; word-wrap: break-word;">ON/OFF</td><td style="text-align: center; word-wrap: break-word;">如果启用，则会将电压输入信号取反。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Scaling factor for voltage input</td><td style="text-align: center; word-wrap: break-word;">数值</td><td style="text-align: center; word-wrap: break-word;">在电压输入端测得的值将按此比例值进行缩放。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">AC</td><td style="text-align: center; word-wrap: break-word;">ON/OFF</td><td style="text-align: center; word-wrap: break-word;">定义信号输入的输入耦合。交流耦合会插入一个高通滤波器。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Current Demodulator</td><td style="text-align: center; word-wrap: break-word;">解调器索引</td><td style="text-align: center; word-wrap: break-word;">用于电流解调制的解调器。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Voltage Demodulator</td><td style="text-align: center; word-wrap: break-word;">解调器索引</td><td style="text-align: center; word-wrap: break-word;">在4端子阻抗测量情况下，用于电压测量的解调器。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Output Demodulator</td><td style="text-align: center; word-wrap: break-word;">解调器索引</td><td style="text-align: center; word-wrap: break-word;">用于在信号输出端产生激励电压的解调器单元。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Interpolation</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">选择补偿数据的插值方法。如果导数变化很大，例如在截止频率处，则插值方法尤其重要。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Linear</td><td style="text-align: center; word-wrap: break-word;">线性插值最快，但可能会在用于补偿的频率点之间产生补偿误差。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Piecewise Cubic Hermite (PCHIP)</td><td style="text-align: center; word-wrap: break-word;">分段三次 Hermite 插值将产生非常精确的结果，但需要具备更高的计算能力。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Osc</td><td style="text-align: center; word-wrap: break-word;">振荡器索引</td><td style="text-align: center; word-wrap: break-word;">用于在Hcur(+V)连接器上产生激励电压频率的振荡器。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Harm</td><td style="text-align: center; word-wrap: break-word;">1至1023</td><td style="text-align: center; word-wrap: break-word;">将解调器的参考频率与该字段定义的整数因子相乘。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Order</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">在6 dB/oct和48 dB/oct之间选择滤波器滚降系数。高滤波器阶数有助于抑制直流偏移，因此有利于阻抗测量。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">1</td><td style="text-align: center; word-wrap: break-word;">1阶滤波器为6 dB/oct</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">2</td><td style="text-align: center; word-wrap: break-word;">2阶滤波器为12 dB/oct</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">3</td><td style="text-align: center; word-wrap: break-word;">3阶滤波器为18 dB/oct</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">4</td><td style="text-align: center; word-wrap: break-word;">4阶滤波器为24 dB/oct</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">5</td><td style="text-align: center; word-wrap: break-word;">5阶滤波器为30 dB/oct</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">6</td><td style="text-align: center; word-wrap: break-word;">6阶滤波器为36 dB/oct</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">7</td><td style="text-align: center; word-wrap: break-word;">7阶滤波器为42 dB/oct</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">8</td><td style="text-align: center; word-wrap: break-word;">8阶滤波器为48 dB/oct</td></tr><tr><td style="text-align: center; word-wrap: break-word;">TC/BW Select</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">定义低通滤波器的显示单位：时间常数(TC)、噪声等效功率带宽(BW NEP)、3 dB带宽(BW 3 dB)。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">TC</td><td style="text-align: center; word-wrap: break-word;">使用滤波器的时间常数定义低通滤波器特性。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">BW NEP</td><td style="text-align: center; word-wrap: break-word;">使用滤波器的噪声等效功率带宽定义低通滤波器特性。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">BW 3 dB</td><td style="text-align: center; word-wrap: break-word;">使用滤波器的截止频率定义低通滤波器特性。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">TC/BW Value</td><td style="text-align: center; word-wrap: break-word;">数值</td><td style="text-align: center; word-wrap: break-word;">使用上面定义的单位来定义低通滤波器特性。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Sinc</td><td style="text-align: center; word-wrap: break-word;">ON/OFF</td><td style="text-align: center; word-wrap: break-word;">启用 sinc 滤波器。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Rate</td><td style="text-align: center; word-wrap: break-word;">0.056 Sa/s 至 857 kSa/s</td><td style="text-align: center; word-wrap: break-word;">阻抗数据流传输速率。该数据流传输速率将应用于所有用于阻抗测量的解调器。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">On</td><td style="text-align: center; word-wrap: break-word;">ON/OFF</td><td style="text-align: center; word-wrap: break-word;">仪器前面板上蓝色 LED 指示灯所对应的信号输出的主开关。</td></tr><tr><td rowspan="5">Range</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">定义相应 Signal Output（信号输出）所生成的最大输出电压。其中包括可能的多个 Signal Amplitude（信号幅值）和 Offset（偏移量）总和。选择可能的最小范围以优化信号质量。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">10 mV</td><td style="text-align: center; word-wrap: break-word;">选择输出范围  $ \pm 10 $ mV。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">100 mV</td><td style="text-align: center; word-wrap: break-word;">选择输出范围  $ \pm 100 $ mV。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">1 V</td><td style="text-align: center; word-wrap: break-word;">选择输出范围  $ \pm 1 $ V。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">10 V</td><td style="text-align: center; word-wrap: break-word;">选择输出范围  $ \pm 10 $ V。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Enable</td><td style="text-align: center; word-wrap: break-word;">ON/OFF</td><td style="text-align: center; word-wrap: break-word;">丢弃超出指定范围的阻抗样本。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Minimum</td><td style="text-align: center; word-wrap: break-word;">ON/OFF</td><td style="text-align: center; word-wrap: break-word;">abs(Z) 的阈值下限，低于该阈值的阻抗样本将被丢弃。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Maximum</td><td style="text-align: center; word-wrap: break-word;">ON/OFF</td><td style="text-align: center; word-wrap: break-word;">abs(Z) 的阈值上限，高于该阈值的阻抗样本将被丢弃。</td></tr></table>




<div style="text-align: center;"><div style="text-align: center;">表 4.47. Impedance Analyzer（阻抗分析仪）选项卡：Compensation（补偿）子选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td rowspan="4">Compensation Type Select</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>显示有关内部校准或用户补偿的信息。</td></tr><tr><td rowspan="2">Internal Calibration</td><td style='text-align: center; word-wrap: break-word;'>内部校准能够匹配整个频率范围内的所有电压和电流范围，从而实现高动态阻抗范围。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>在 Zurich 仪器上执行内部校准。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>User Compensation</td><td style='text-align: center; word-wrap: break-word;'>用户补偿将校正测量装置自身的影响，如寄生电容或电感效应。它将紧接着内部校准一起执行。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Internal</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>启用内部校准。这样可确保输入范围增益在整个频率范围内匹配。通过启用内部校准，设备可满足阻抗精度规范。内部校准是应用用户补偿的先决条件。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Active</td><td style='text-align: center; word-wrap: break-word;'>灰色/绿色</td><td style='text-align: center; word-wrap: break-word;'>指示是否已对测量数据应用内部校准。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Smooth Internal Data</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>平滑处理内部校准数据。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Internal Calibration Info</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>显示与内部阻抗校准数据一起保存的元数据。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>User</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>启用对阻抗数据的补偿。用户补偿用于校正由外部测量装置引起的寄生效应和延迟。用户补偿将紧接着内部阻抗校准一起执行。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Active</td><td style='text-align: center; word-wrap: break-word;'>灰色/绿色</td><td style='text-align: center; word-wrap: break-word;'>指示当前正在进行有效补偿。如果激活，则阻抗数据流将基于阻抗补偿传输幅值和相位校正数据。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Smooth User Data</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>平滑处理用户补偿数据。仅当补偿数据包含至少21个点时才可以进行平滑处理。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>User Compensation Info</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>显示与用户补偿一起保存的元数据。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>File Name for User Compensation</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>输入一个新文件名以将当前用户补偿保存到此文件，或选择一个现有文件以加载用户补偿。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Save User Compensation</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>将当前用户补偿保存到文件中。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Load User Compensation</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>从文件加载用户补偿。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Mode</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择用户补偿序列。如果序列涉及短路或开路状态，则必须通过在电压和电流输入端使用自动选择范围来将噪声保持在较低水平。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>None</td><td style='text-align: center; word-wrap: break-word;'>不执行补偿。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>SOL (Short-Open-Load)</td><td style='text-align: center; word-wrap: break-word;'>使用短路/开路负载条件补偿用户测量装置。这种补偿方法可在低噪声的开路和短路补偿条件下，在整个阻抗范围内获得非常精确的结果。因此，此补偿方法应始终在自动选择范围启用时使用。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>OL (Open-Load)</td><td style='text-align: center; word-wrap: break-word;'>开路负载补偿适用于测量高阻抗。使用自动选择范围可以降低噪声对开路补偿步骤的影响。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>SL (Short-Load)</td><td style='text-align: center; word-wrap: break-word;'>短路负载补偿适用于测量低阻抗。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>L (Load)</td><td style='text-align: center; word-wrap: break-word;'>使用单个负载执行的补偿。如果被测设备在用于补偿的负载附近，则该补偿方法非常有用。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>SO (Short-Open)</td><td style='text-align: center; word-wrap: break-word;'>短路开路补偿用于校正用户测量装置的寄生电感和电容效应。如果没有负载可用于补偿，则此补偿方法适用。它不会校正增益误差。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>LLL (Load-Load-Load)</td><td style='text-align: center; word-wrap: break-word;'>此补偿方法基于三个负载值，对于受限阻抗范围会产生非常精确的结果。如果开路或短路条件下的噪声太强，可采用此方法。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Load R</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>补偿负载的电阻值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Load C</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>补偿负载的电容值。在电阻负载的情况下，此电容值等效于其寄生电容效应。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Step</td><td style='text-align: center; word-wrap: break-word;'>Short、Open、Load</td><td style='text-align: center; word-wrap: break-word;'>要记录的补偿步骤。各个步骤的顺序可以自由选择。在启动之前，需要将正确的设备连接到测量装置。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Compensation Step Short</td><td style='text-align: center; word-wrap: break-word;'>ON / OF</td><td style='text-align: center; word-wrap: break-word;'>选择进行短路测量。这补偿了与DUT串联的寄生效应。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Compensation Step Open</td><td style='text-align: center; word-wrap: break-word;'>ON / OF</td><td style='text-align: center; word-wrap: break-word;'>选择进行开路测量。这补偿了与DUT并联的寄生效应。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Compensation Step Load</td><td style='text-align: center; word-wrap: break-word;'>ON / OF</td><td style='text-align: center; word-wrap: break-word;'>选择进行负载测量。这补偿了测量装置的额外增益。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Compensation Step High Load</td><td style='text-align: center; word-wrap: break-word;'>ON / OF</td><td style='text-align: center; word-wrap: break-word;'>选择进行高负载测量。这补偿了测量装置的额外增益。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Status</td><td style='text-align: center; word-wrap: break-word;'>灰色/绿色</td><td style='text-align: center; word-wrap: break-word;'>指示成功的补偿步骤。如果状态指示器在补偿步骤执行后未指示绿色，可选中消息框，了解有关故障的详细信息。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Compensate</td><td style='text-align: center; word-wrap: break-word;'>Compensate</td><td style='text-align: center; word-wrap: break-word;'>开始执行所选条件的补偿测量。如果补偿测量成功完成，则自动选择下一个待处理条件。消息框将显示与已完成补偿的质量相关的信息，如果补偿失败，还将显示故障消息。当前有效的补偿的执行进度将显示在消息框中。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Message</td><td style='text-align: center; word-wrap: break-word;'>字符串</td><td style='text-align: center; word-wrap: break-word;'>消息窗格显示与补偿相关的信息。如果补偿失败，则显示根本原因相关信息。如果补偿成功执行，则显示代表性参数，以此判断补偿和测量装置的质量。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Comment</td><td style='text-align: center; word-wrap: break-word;'>字符串</td><td style='text-align: center; word-wrap: break-word;'>用户备注将与补偿数据一起保存。备注字符串也可以在不同补偿步骤之间切换。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Validation</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>对补偿结果进行完整性检查，以检测测量结果异常值、过载或其他错误情况。只有在特殊情况下执行的补偿才能禁用验证。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>High Z Load</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>在用户补偿期间测量两个不同的负载。改善补偿数据。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Auto Transfer</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>如果启用，成功执行的补偿的相关数据会立即传输到设备，然后激活并永久存储。如果禁用自动传输，则需要手动启动传输。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>On Device</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>手动传输并激活记录的补偿。</td></tr></table>





<div style="text-align: center;"><div style="text-align: center;">4.14 Impedance Analyzer（阻抗分析仪）选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>On Device</td><td style='text-align: center; word-wrap: break-word;'></td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Persistent</td><td style='text-align: center; word-wrap: break-word;'>Persistent</td><td style='text-align: center; word-wrap: break-word;'>将补偿数据永久存储在设备上。每次通电时都会自动加载补偿数据。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Start (Hz)</td><td style='text-align: center; word-wrap: break-word;'>0 至 5 MHz</td><td style='text-align: center; word-wrap: break-word;'>用于校准的频率下限。在低于该值的频率下进行测量时，执行推断。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Stop (Hz)</td><td style='text-align: center; word-wrap: break-word;'>0 至 5 MHz</td><td style='text-align: center; word-wrap: break-word;'>用于校准的频率上限。该上限对于准确测量至关重要。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Points</td><td style='text-align: center; word-wrap: break-word;'>正整数值</td><td style='text-align: center; word-wrap: break-word;'>用于补偿的频率点数。对于两个补偿频率之间的频率，将对数据进行插补。</td></tr><tr><td rowspan="3">Precision</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>补偿期间的测量精度。在测量受噪声限制的情况下，使用高精度可以改善补偿数据的质量。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Standard</td><td style='text-align: center; word-wrap: break-word;'>在补偿期间执行测量时应用标准滤波器和均值滤波设置</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>High</td><td style='text-align: center; word-wrap: break-word;'>在补偿期间执行测量时采用较低的滤波器带宽并执行更多次均值滤波</td></tr></table>

### 4.15.Config（配置）选项卡

通过 Config（配置）选项卡可访问所有主要 LabOne 设置，该选项卡可用于所有 MFLI 仪器。

#### 4.15.1. 特征

一 定义仪器连接参数

一 浏览器会话控制

一 定义 UI 外观（网格、主题等）

一 存储和加载仪器设置和 UI 设置

一 配置数据记录

#### 4.15.2. 描述

Config（配置）选项卡作为所有常规 LabOne 设置的控制面板，默认在仪器启动时开启。当该选项卡关闭或需要其他相同类型的选项卡时，单击以下图标即可打开该选项卡的新实例。

<div style="text-align: center;"><div style="text-align: center;">表 4.48. 应用图标和简要描述</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Config</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>提供对于软件配置的访问权限。</td></tr></table>

Config（配置）选项卡（参见图 4.36）分为五个部分，分别控制连接、会话、设置、用户界面外观和数据记录。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//8df1ee74-6ce8-44a1-9c92-dd8d613b6b81/markdown_3/imgs/img_in_image_box_215_816_1074_1012.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A05Z%2F-1%2F%2F84558d11399d8448a84cedbfa4afbe1b32928b5c4431e12c5148a27f0be270a5" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.36.LabOne UI: Config（配置）选项卡</div> </div>


Connection（连接）部分提供有关连接和服务器版本的信息。可在连接设置中限制远程访问。

Session（会话）部分提供会话数量，该信息还会显示在状态栏中。点击 Session Dialog（会话对话框），即可打开会话对话框窗口（和启动画面中相同），在此加载不同的设置文件以及连接其他仪器。

Settings（设置）部分可加载和保存仪器和 UI 设置。保存的设置稍后会应用到会话对话框中。

User Preferences（用户首选项）部分包括连续存储的设置，并在下次通过同一计算机帐户使用MFLI仪器时自动重新加载。

在低照度环境条件下，建议使用深色显示主题（参见图 4.37）。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//8df1ee74-6ce8-44a1-9c92-dd8d613b6b81/markdown_4/imgs/img_in_image_box_215_112_1074_309.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A06Z%2F-1%2F%2F70c840316a5f7c9b7c47ac83d7cd2f023fc3a989b2217402bc450c3b41776ad5" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.37.LabOne UI: Config（配置）选项卡 - 深色主题</div> </div>


Record Data（记录数据）部分包括获取测量数据的硬拷贝所必需的所有设置。通过树状结构（参见树状选择器一节）可访问大量的信号和仪器设置。使用 View Filter（查看滤波器）以便减少树状结构，只保留最常用的节点，例如解调器样本节点。无论何时，只要启用 Record（记录）按钮，所有选中的节点将以 MATLAB、逗号分隔值 (CSV) 或其他支持的文件格式连续保存下来。每个选中的节点生成至少一个文件，但是在长时间记录中，数据可能会分布在多个文件上。这些文件通常保存在 MFLI 的内部存储中或是连接到仪器某个 USB 端口的大容量存储设备中。如需将数据直接保存在主机上，请在主机上安装并运行 LabOne Web Server，详细描述参见第 1.5 节。有关数据保存的更多信息，请参见第 4.2 节。在记录后检查文件的最快方法是使用 File Manager（文件管理器）选项卡，参见第 4.17 节。除了数值数据和设置，文件还包括时间戳。这些整数以仪器时钟周期 1/(60 MHz) 为单位对测量时间进行编码。同一个仪器内的时间戳是通用的，可用于对齐来自不同文件的数据。

#### 4.15.3. 功能元素

<div style="text-align: center;"><div style="text-align: center;">表 4.49.Config（配置）选项卡</div> </div>




<table border="1" style="margin: auto; word-wrap: break-word;"><tr><td style="text-align: center; word-wrap: break-word;">控件/工具</td><td style="text-align: center; word-wrap: break-word;">选项/范围</td><td style="text-align: center; word-wrap: break-word;">描述</td></tr><tr><td style="text-align: center; word-wrap: break-word;">About</td><td style="text-align: center; word-wrap: break-word;">About</td><td style="text-align: center; word-wrap: break-word;">获取关于 LabOne 软件的信息。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Web Server Version and Revision</td><td style="text-align: center; word-wrap: break-word;">字符串</td><td style="text-align: center; word-wrap: break-word;">Web 服务器版本和修订号</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Host</td><td style="text-align: center; word-wrap: break-word;">默认为 localhost: 127.0.0.1</td><td style="text-align: center; word-wrap: break-word;">LabOne Web 服务器的 IP 地址</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Port</td><td style="text-align: center; word-wrap: break-word;">4 位整数</td><td style="text-align: center; word-wrap: break-word;">LabOne Web 服务器的 TCP/IP 端口</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Data Server Version and Revision</td><td style="text-align: center; word-wrap: break-word;">字符串</td><td style="text-align: center; word-wrap: break-word;">数据服务器版本和修订号</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Host</td><td style="text-align: center; word-wrap: break-word;">默认为 localhost: 127.0.0.1</td><td style="text-align: center; word-wrap: break-word;">LabOne 数据服务器的 IP 地址</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Port</td><td style="text-align: center; word-wrap: break-word;">默认为 8004</td><td style="text-align: center; word-wrap: break-word;">用于连接 LabOne 数据服务器的 TCP/IP 端口。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Connect/Disconnect</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">连接/断开当前选定设备的 LabOne 数据服务器。如果连接了 LabOne 数据服务器，则只有对该服务器可见的设备才会显示在设备列表中。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Status</td><td style="text-align: center; word-wrap: break-word;">灰色/绿色</td><td style="text-align: center; word-wrap: break-word;">指示 LabOne 用户界面是否连接到所选的 LabOne 数据服务器。灰色：未连接。绿色：已连接。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Connectivity</td><td style="text-align: center; word-wrap: break-word;">Localhost Only From Everywhere</td><td style="text-align: center; word-wrap: break-word;">禁止/允许从其他计算机连接此数据服务器。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">File Upload</td><td style="text-align: center; word-wrap: break-word;">拖放区域</td><td style="text-align: center; word-wrap: break-word;">在此框中拖放文件即可上传文件。单击此框会打开一个关于文件上传的文件对话框。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">支持的文件：设置 (.xml)、软件更新 (LabOne.tar)。如果文件有效并且版本与当前安</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">装的软件不同，则上传软件更新将自动触发更新过程。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Load From USB</td><td style="text-align: center; word-wrap: break-word;">Load From USB</td><td style="text-align: center; word-wrap: break-word;">从连接到设备的 USB 大容量存储器加载公共 SSH 密钥。上传 SSH 密钥可以通过 SSH 访问设备。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Delete All</td><td style="text-align: center; word-wrap: break-word;">Delete All</td><td style="text-align: center; word-wrap: break-word;">删除设备上的所有公共 SSH 密钥。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Time Zone</td><td style="text-align: center; word-wrap: break-word;">时区相对于 UTC（协调世界时）的偏差。</td><td style="text-align: center; word-wrap: break-word;">选择使用设备的时区。设置、数据和日志文件接收来自此时区的时间戳。需要重启才能使更改生效。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Session Id</td><td style="text-align: center; word-wrap: break-word;">整数</td><td style="text-align: center; word-wrap: break-word;">会话标识符。会话是客户端与 LabOne 数据服务器之间的连接。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Session Manager</td><td style="text-align: center; word-wrap: break-word;">Session Manager</td><td style="text-align: center; word-wrap: break-word;">打开会话管理器对话。允许切换设备或会话。按取消可以继续当前会话。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">FileName</td><td style="text-align: center; word-wrap: break-word;">选择可用的文件名</td><td style="text-align: center; word-wrap: break-word;">将设备和用户界面设置保存到内部闪存盘上的选定文件，或者从内部闪存盘上的选定文件加载设备和用户界面设置。可以使用 Files（文件）选项卡下载/上传设置文件。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Include</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">启用特别设置的 Save（保存）/Load（加载）。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">No Include Settings</td><td style="text-align: center; word-wrap: break-word;">请启用 Save（保存）/Load（加载）期间将包括的设置类型。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Include Device</td><td style="text-align: center; word-wrap: break-word;">启用设备设置的 Save（保存）/Load（加载）。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Include UI</td><td style="text-align: center; word-wrap: break-word;">启用用户界面设置的 Save（保存）/Load（加载）。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Include UI and Device</td><td style="text-align: center; word-wrap: break-word;">启用用户界面和设备设置的 Save（保存）/Load（加载）。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Include Preferences</td><td style="text-align: center; word-wrap: break-word;">启用从设置文件加载 User Preferences（用户首选项）。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Include UI, Device and Preferences</td><td style="text-align: center; word-wrap: break-word;">启用用户界面、设备和用户首选项的 Save（保存）/Load（加载）。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Save</td><td style="text-align: center; word-wrap: break-word;">Save</td><td style="text-align: center; word-wrap: break-word;">将用户界面和设备设置保存到文件。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Load</td><td style="text-align: center; word-wrap: break-word;">Load</td><td style="text-align: center; word-wrap: break-word;">从文件加载用户界面和设备设置。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Language</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">选择工具提示的语言。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Display Theme</td><td style="text-align: center; word-wrap: break-word;">Light</td><td style="text-align: center; word-wrap: break-word;">选择用户界面的主题。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Dark</td><td style="text-align: center; word-wrap: break-word;"></td></tr><tr><td style="text-align: center; word-wrap: break-word;">Plot Print Theme</td><td style="text-align: center; word-wrap: break-word;">Light</td><td style="text-align: center; word-wrap: break-word;">选择打印 SVG 图的主题。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Dark</td><td style="text-align: center; word-wrap: break-word;"></td></tr><tr><td style="text-align: center; word-wrap: break-word;">Plot Grid</td><td style="text-align: center; word-wrap: break-word;">Dashed</td><td style="text-align: center; word-wrap: break-word;">为所有 SVG 图选择活动网格设置。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Solid</td><td style="text-align: center; word-wrap: break-word;"></td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">None</td><td style="text-align: center; word-wrap: break-word;"></td></tr><tr><td style="text-align: center; word-wrap: break-word;">Plot Rendering</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">选择渲染提示，了解浏览器渲染 SVG 图时要做出的权衡。无论是显示的绘图还是保存的绘图，此设置都会对其渲染速度和绘图显示产生影响。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Auto</td><td style="text-align: center; word-wrap: break-word;">指示浏览器会在平衡速度、清晰边缘和几何精度之间进行适当的权衡，其中几何精度要比速度和清晰边缘更为重要。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Optimize Speed</td><td style="text-align: center; word-wrap: break-word;">与几何精度和清晰边缘相比，浏览器应更加侧重渲染速度。此选项有时会导致浏览器关闭形状抗混叠。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Crisp Edges</td><td style="text-align: center; word-wrap: break-word;">指示与渲染速度和几何精度相比，浏览器应尝试更加侧重绘图清晰边缘之间的对比度。为实现清晰边缘，用户代理可关闭所有线条和曲线的抗混叠，更多情况下可能只需关闭接近水平或垂直的直线的抗混叠。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Geometric Precision</td><td style="text-align: center; word-wrap: break-word;">指示与渲染速度和清晰边缘相比，浏览器应更加侧重几何精度。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Resampling Method</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">选择重新采样插值方法。重新采样可更正后续示波器截图中的样本偏差情况。当使用的采样率较低并且时间分辨率低于触发时间分辨率时，这一点很重要。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Linear</td><td style="text-align: center; word-wrap: break-word;">线性插值</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">PCHIP</td><td style="text-align: center; word-wrap: break-word;">分段三次 Hermite 插值多项式</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Show Shortcuts</td><td style="text-align: center; word-wrap: break-word;">ON/OFF</td><td style="text-align: center; word-wrap: break-word;">显示用于操作绘图的键盘和鼠标滚轮快捷键列表。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Dynamic Tabs</td><td style="text-align: center; word-wrap: break-word;">ON/OFF</td><td style="text-align: center; word-wrap: break-word;">如果启用，应用选项卡内的各部分会根据窗口宽度自动折叠。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Graphical Mode</td><td style="text-align: center; word-wrap: break-word;">自动</td><td style="text-align: center; word-wrap: break-word;">选择图形元素的显示模式。Auto（自动）格式将选择最适合当前窗口宽度的格式。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Expanded</td><td style="text-align: center; word-wrap: break-word;">选择最适合当前窗口宽度的格式。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Collapsed</td><td style="text-align: center; word-wrap: break-word;"></td></tr><tr><td style="text-align: center; word-wrap: break-word;">Log Format</td><td style="text-align: center; word-wrap: break-word;">Telnet</td><td style="text-align: center; word-wrap: break-word;">选择命令日志格式。查看状态栏和 [User]\Documents\Zurich Instruments</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Matlab</td><td style="text-align: center; word-wrap: break-word;">[User]\Documents\Zurich Instruments</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Python</td><td style="text-align: center; word-wrap: break-word;">\LabOne\WebServer\Log</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">.NET</td><td style="text-align: center; word-wrap: break-word;"></td></tr><tr><td style="text-align: center; word-wrap: break-word;">CSV Delimiter</td><td style="text-align: center; word-wrap: break-word;">Comma</td><td style="text-align: center; word-wrap: break-word;">选择要为 CSV 文件插入的分隔符。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Semicolon</td><td style="text-align: center; word-wrap: break-word;"></td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Tab</td><td style="text-align: center; word-wrap: break-word;"></td></tr><tr><td style="text-align: center; word-wrap: break-word;">CSV Locale</td><td style="text-align: center; word-wrap: break-word;">默认区域设置。使用点号代表小数点，不使用数字分组，例如 1005.07。</td><td style="text-align: center; word-wrap: break-word;">选择用于定义小数点的区域设置以及 CSV 文件中数值的数字分组符号。默认区域设置使用点号代表小数点，不使用数字分组，例如 1005.07。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">1005.07。</td><td style="text-align: center; word-wrap: break-word;">系统区域设置使用在计算机的语言和区域设置中设置的符号。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">系统区域设置。使用在计算机的语言和区域设置中设置的符号。</td><td style="text-align: center; word-wrap: break-word;"></td></tr><tr><td style="text-align: center; word-wrap: break-word;">HDF5 Saving</td><td style="text-align: center; word-wrap: break-word;">单个文件。所有测量均存储在一个文件中</td><td style="text-align: center; word-wrap: break-word;">仅限 HDF5 文件格式：选择每个测量存储在单独的文件中，还是所有测量均存储在一个文件中。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">多个文件。每个测量存储在单独的文件中</td><td style="text-align: center; word-wrap: break-word;"></td></tr><tr><td style="text-align: center; word-wrap: break-word;">Auto Start</td><td style="text-align: center; word-wrap: break-word;">ON/OFF</td><td style="text-align: center; word-wrap: break-word;">如果所选设备可用，在启动时跳过会话管理器对话框。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">ON/OFF</td><td style="text-align: center; word-wrap: break-word;"></td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">ON/OFF</td><td style="text-align: center; word-wrap: break-word;">如果 LabOne 软件已有 180 天未更新，则启动时会显示提醒。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Update Check</td><td style="text-align: center; word-wrap: break-word;">ON/OFF</td><td style="text-align: center; word-wrap: break-word;">定期通过互联网检查 LabOne 软件是否有新版本。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Drive</td><td style="text-align: center; word-wrap: break-word;">选择用于保存数据的驱动器。</td><td style="text-align: center; word-wrap: break-word;"></td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">MFFlash Drive</td><td style="text-align: center; word-wrap: break-word;">MFFL/MFIA 的内部闪存大容量存储设备。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">USB 1/2</td><td style="text-align: center; word-wrap: break-word;">USB 上连接的大容量存储设备。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Format</td><td style="text-align: center; word-wrap: break-word;">ZView</td><td style="text-align: center; word-wrap: break-word;">已记录和已保存数据的文件格式。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Matlab</td><td style="text-align: center; word-wrap: break-word;"></td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">CSV</td><td style="text-align: center; word-wrap: break-word;"></td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">SXM (Nanonis)</td><td style="text-align: center; word-wrap: break-word;"></td></tr><tr><td style="text-align: center; word-wrap: break-word;">Open Folder</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">在系统文件资源管理器中打开已记录数据。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Folder</td><td style="text-align: center; word-wrap: break-word;">指示文件位置的路径</td><td style="text-align: center; word-wrap: break-word;">包含已记录数据的文件夹。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Save Interval</td><td style="text-align: center; word-wrap: break-word;">时间（秒）</td><td style="text-align: center; word-wrap: break-word;">保存到磁盘之间的时间间隔。时间间隔越短，系统内存占用越少，但对于某些文件格式（例如 MATLAB），磁盘上存储更多的小文件。时间间隔越长，系统内存占用越多，但对于某些文件格式</td></tr></table>








<div style="text-align: center;"><div style="text-align: center;">4.15 Config（配置）选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>式（例如 MATLAB），磁盘上存储更少的大文件。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Queue</td><td style='text-align: center; word-wrap: break-word;'>整数</td><td style='text-align: center; word-wrap: break-word;'>尚未写入磁盘的数据块数。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Size</td><td style='text-align: center; word-wrap: break-word;'>整数</td><td style='text-align: center; word-wrap: break-word;'>当前会话中已保存数据的累计大小。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Record</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>按选择过滤器中的定义启动和停止将数据保存到磁盘的操作。文件长度由 Plotter（绘图仪）选项卡中的 Window Length（窗口长度）设置确定。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Writing</td><td style='text-align: center; word-wrap: break-word;'>灰色/绿色</td><td style='text-align: center; word-wrap: break-word;'>指示数据当前是否写入磁盘。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Display</td><td style='text-align: center; word-wrap: break-word;'>过滤器或正则表达式</td><td style='text-align: center; word-wrap: break-word;'>使用其中一个预设视图过滤器或自定义正则表达式显示特定树分支。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Tree</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>单击树节点即可将其激活。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>All</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择所有树元素。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>None</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>取消选择所有树元素。</td></tr></table>

有关 Record Data（记录数据）部分树状功能的更多信息，请参见树状选择器。

### 4.16. Device（设备）选项卡

Device（设备）选项卡是所连接的仪器的主要设置选项卡，可用于所有 MFLI 仪器。

#### 4.16.1. 特征

一 选件和升级管理

一 外部时钟参考 (10 MHz)

一 仪器连接参数

一 设备监控器

#### 4.16.2. 描述

Device（设备）选项卡主要作为一个控制面板，用于此特定会话中 LabOne 控制的仪器的所有特定设置。当该选项卡关闭或需要其他相同类型的选项卡时，单击以下图标即可打开该选项卡的新实例。

<div style="text-align: center;"><div style="text-align: center;">表 4.50. 应用图标和简要描述</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Device</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>提供特定于仪器的设置。</td></tr></table>

Device（设备）选项卡（参见图 4.38）分为五个部分：一般仪器信息、配置、通信参数、设备预设和设备监控器。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//7be9a87a-9c50-465d-81cd-241f3b2990d7/markdown_3/imgs/img_in_image_box_215_779_1074_976.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A06Z%2F-1%2F%2F09e8edd3dea8f7260a324803f7b3311b7dd0bd2faeaad2e0f7d848e93bf2787c" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.38.LabOne UI: Device（设备）选项卡</div> </div>


Information（信息）部分提供给有关仪器硬件的详细信息，并指示已安装的升级选件。用户还可通过输入提供的选件密钥在此添加新的选件。

Configuration（配置）部分允许用户将参考从内部时钟更改为外部 10 MHz 参考。参考应连接仪器后面板上的 Clock Input。

Presets（预设）部分允许用户定义不同于出厂默认设置的自定义仪器启动配置。该配置存储在仪器自身，其应用也独立于控制 PC。这在常规不需要控制 PC 的情况下（例如当仅使用模拟接口时，仪器配置是固定的）可以节省时间。

Communication（通信）部分可访问仪器的 TCP/IP 设置。

Statistics（统计）部分可查看通信统计概述。尤其是当前使用的数据速率（即带宽）。

##### 注释

UDP 或 USB 上数据流的数据包丢失：如果总带宽超过可用的物理接口带宽，则数据包可能会丢失。如果主机无法处理高带宽数据，数据也可能丢失。

##### 注释

TCP 或 USB 上命令流的数据包丢失：由于命令包可创建新的无效状态，因此命令包不会丢失。

Wireless Network（无线网络）部分控制使用仪器附带的 WiFi USB 适配器的无线设备访问。有关如何通过无线网络连接仪器的说明，请参见无线连接。

Device Monitor（设备监控器）部分在默认情况下处于折叠状态，通常仅在维修时需要。此部分显示仪器部分硬件组件的活动信号。

#### 4.16.3. 功能元素

<div style="text-align: center;"><div style="text-align: center;">表 4.51.Device（设备）选项卡</div> </div>




<table border="1" style="margin: auto; word-wrap: break-word;"><tr><td style="text-align: center; word-wrap: break-word;">控件/工具</td><td style="text-align: center; word-wrap: break-word;">选项/范围</td><td style="text-align: center; word-wrap: break-word;">描述</td></tr><tr><td style="text-align: center; word-wrap: break-word;">FPGA</td><td style="text-align: center; word-wrap: break-word;">整数</td><td style="text-align: center; word-wrap: break-word;">HDL 固件版本。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Digital Board</td><td style="text-align: center; word-wrap: break-word;">版本号</td><td style="text-align: center; word-wrap: break-word;">FPGA 基板的硬件版本。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Firmware</td><td style="text-align: center; word-wrap: break-word;">整数</td><td style="text-align: center; word-wrap: break-word;">设备内部控制器软件的版本。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Serial</td><td style="text-align: center; word-wrap: break-word;">1-4 位数字</td><td style="text-align: center; word-wrap: break-word;">设备序列号</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Type</td><td style="text-align: center; word-wrap: break-word;">字符串</td><td style="text-align: center; word-wrap: break-word;">设备类型</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Installed Options</td><td style="text-align: center; word-wrap: break-word;">每个选件的简称</td><td style="text-align: center; word-wrap: break-word;">此设备上安装的选件。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Install</td><td style="text-align: center; word-wrap: break-word;">Install</td><td style="text-align: center; word-wrap: break-word;">单击即可在此设备上安装选件。需要输入唯一的功能代码，然后重启。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">More Information</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">在单独的浏览器选项卡中显示更多设备信息。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Upgrade Device Options</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">显示可用的升级选件。</td></tr><tr><td rowspan="3">Clock Source</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">10MHz 参考时钟源。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Internal</td><td style="text-align: center; word-wrap: break-word;">使用内部 10MHz 时钟作为频率和时基参考。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Clk 10MHz</td><td style="text-align: center; word-wrap: break-word;">计划使用外部 10MHz 时钟作为频率和时基参考。为相应的后面板连接器提供干净且稳定的 10MHz 参考。</td></tr><tr><td rowspan="3">Index</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">在出厂预设或存储在内部闪存中的预设之间进行选择。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Factory</td><td style="text-align: center; word-wrap: break-word;">选择出厂预设。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Flash 1-6</td><td style="text-align: center; word-wrap: break-word;">选择存储在内部闪存 1-6 中的预设之一。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Load</td><td style="text-align: center; word-wrap: break-word;">Load</td><td style="text-align: center; word-wrap: break-word;">加载所选预设。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Save</td><td style="text-align: center; word-wrap: break-word;">Save</td><td style="text-align: center; word-wrap: break-word;">将实际设置保存为预设。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Erase</td><td style="text-align: center; word-wrap: break-word;">Erase</td><td style="text-align: center; word-wrap: break-word;">擦除所选预设。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Busy</td><td style="text-align: center; word-wrap: break-word;">灰色/绿色</td><td style="text-align: center; word-wrap: break-word;">指示设备正忙于加载、保存或擦除预设。</td></tr><tr><td rowspan="3">Error</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">如果最后一次预设操作已成功完成，则返回 0；如果最后一次预设操作是非法的，则返回 1。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">0</td><td style="text-align: center; word-wrap: break-word;">最后一次预设操作已成功完成。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">1</td><td style="text-align: center; word-wrap: break-word;">最后一次预设操作是非法的。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Error LED</td><td style="text-align: center; word-wrap: break-word;">灰色/红色</td><td style="text-align: center; word-wrap: break-word;">如果最后一次操作是非法的，则变为红色。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Valid LED</td><td style="text-align: center; word-wrap: break-word;">灰色/绿色</td><td style="text-align: center; word-wrap: break-word;">如果在相应位置存储了有效预设，则变为绿色。</td></tr><tr><td rowspan="8">Presets</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">显示可用预设列表，包括出厂预设。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">0</td><td style="text-align: center; word-wrap: break-word;">出厂默认预设。出厂默认预设的名称已给定且无法编辑。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">1</td><td style="text-align: center; word-wrap: break-word;">闪存预设 1。可以编辑此预设的名称。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">2</td><td style="text-align: center; word-wrap: break-word;">闪存预设 2。可以编辑此预设的名称。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">3</td><td style="text-align: center; word-wrap: break-word;">闪存预设 3。可以编辑此预设的名称。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">4</td><td style="text-align: center; word-wrap: break-word;">闪存预设 4。可以编辑此预设的名称。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">5</td><td style="text-align: center; word-wrap: break-word;">闪存预设 5。可以编辑此预设的名称。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">6</td><td style="text-align: center; word-wrap: break-word;">闪存预设 6。可以编辑此预设的名称。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Default</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">指示在设备启动时用作默认预设的预设。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Factory</td><td style="text-align: center; word-wrap: break-word;">选择出厂预设作为默认预设。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Flash 1-6</td><td style="text-align: center; word-wrap: break-word;">选择存储在内部闪存 1-6 中的预设之一作为默认预设。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">MAC Address</td><td style="text-align: center; word-wrap: break-word;">80:2F:DE:xx:xx:xx</td><td style="text-align: center; word-wrap: break-word;">设备的 MAC 地址。MAC 地址是静态定义的，不能更改且对于每台设备都是唯一的。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">IPv4 Address</td><td style="text-align: center; word-wrap: break-word;">默认为 192.168.1.10</td><td style="text-align: center; word-wrap: break-word;">设备的当前 IP 地址。此 IP 地址由 DHCP 服务器动态分配、静态定义。如果无法找到 DHCP 服务器，则此 IP 地址为后备 IP 地址（用于点对点连接）。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Jumbo Frames</td><td style="text-align: center; word-wrap: break-word;">ON/OFF</td><td style="text-align: center; word-wrap: break-word;">默认情况下为此设备和接口启用巨型帧。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Static IP</td><td style="text-align: center; word-wrap: break-word;">ON/OFF</td><td style="text-align: center; word-wrap: break-word;">如果在没有 DHCP 服务器的情况下在具有固定 IP 分配的网络中使用此设备，请启用此标志。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">IPv4 Address</td><td style="text-align: center; word-wrap: break-word;">默认为 192.168.1.10</td><td style="text-align: center; word-wrap: break-word;">要写入设备的静态 IP 地址。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">IPv4 Mask</td><td style="text-align: center; word-wrap: break-word;">默认为 255.255.255.0</td><td style="text-align: center; word-wrap: break-word;">要写入设备的静态 IP 掩码。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Gateway</td><td style="text-align: center; word-wrap: break-word;">默认为 192.168.1.1</td><td style="text-align: center; word-wrap: break-word;">静态 IP 网关</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Program</td><td style="text-align: center; word-wrap: break-word;">Program</td><td style="text-align: center; word-wrap: break-word;">单击即可为设备编程指定的 IPv4 地址、IPv4 掩码和网关。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Pending</td><td style="text-align: center; word-wrap: break-word;">整数值</td><td style="text-align: center; word-wrap: break-word;">准备好从设备接收命令包的缓冲区数。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Processing</td><td style="text-align: center; word-wrap: break-word;">整数值</td><td style="text-align: center; word-wrap: break-word;">正在为命令包而接受处理的缓冲区数。如果数值较小，则表示性能适当。对于 TCP/IP 接口，使用 TCP 协议发送命令包。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Packet Loss</td><td style="text-align: center; word-wrap: break-word;">整数值</td><td style="text-align: center; word-wrap: break-word;">设备启动后丢失的命令包数。命令包中包含发送到设备和从设备接收的设备设置。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Bandwidth</td><td style="text-align: center; word-wrap: break-word;">数值</td><td style="text-align: center; word-wrap: break-word;">在设备和数据服务器之间的物理网络连接上使用的命令流传输带宽。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Pending</td><td style="text-align: center; word-wrap: break-word;">整数值</td><td style="text-align: center; word-wrap: break-word;">准备好从设备接收数据包的缓冲区数。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Processing</td><td style="text-align: center; word-wrap: break-word;">整数值</td><td style="text-align: center; word-wrap: break-word;">正在为数据包而接受处理的缓冲区数。如果数值较小，则表示性能适当。对于 TCP/IP 接口，使用 UDP 协议发送数据包。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Packet Loss</td><td style="text-align: center; word-wrap: break-word;">整数值</td><td style="text-align: center; word-wrap: break-word;">设备启动后丢失的数据包数。数据包中包含测量数据。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Bandwidth</td><td style="text-align: center; word-wrap: break-word;">数值</td><td style="text-align: center; word-wrap: break-word;">在设备和数据服务器之间的物理网络连接上使用的数据流传输带宽。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">WiFi Available LED</td><td style="text-align: center; word-wrap: break-word;">灰色/绿色</td><td style="text-align: center; word-wrap: break-word;">如果支持的 WiFi USB 适配器连接到设备，则变为绿色。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">WiFi Mode</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">选择 WiFi 操作模式</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Disabled</td><td style="text-align: center; word-wrap: break-word;">禁用 WiFi 操作。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Access Point</td><td style="text-align: center; word-wrap: break-word;">创建新的 WiFi 网络并将设备作为接入点运行。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Client</td><td style="text-align: center; word-wrap: break-word;">作为客户端加入现有的 WiFi 网络。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Advanced WiFi Settings</td><td style="text-align: center; word-wrap: break-word;">ON/OFF</td><td style="text-align: center; word-wrap: break-word;">允许手动选择 WiFi 设置。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">WiFi SSID</td><td style="text-align: center; word-wrap: break-word;">默认：设备 ID</td><td style="text-align: center; word-wrap: break-word;">设置要创建（在接入点模式下）或要加入（在客户端模式下）的网络的 SSID。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">WiFi Password</td><td style="text-align: center; word-wrap: break-word;">默认：password123</td><td style="text-align: center; word-wrap: break-word;">设置要创建（在接入点模式下）或要加入（在客户端模式下）的网络的密码。在接入点模式下，密码长度必须介于 8 到 63 个字符之间。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">WiFi Channel</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">选择要创建（在接入点模式下）的网络的 WiFi 通道。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Channel 1</td><td style="text-align: center; word-wrap: break-word;">WiFi 通道 1 (2.412 GHz)</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Channel 6</td><td style="text-align: center; word-wrap: break-word;">WiFi 通道 6 (2.437 GHz)</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Channel 11</td><td style="text-align: center; word-wrap: break-word;">WiFi 通道 11 (2.462 GHz)</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Enable WiFi</td><td style="text-align: center; word-wrap: break-word;">ON/OFF</td><td style="text-align: center; word-wrap: break-word;">启用/禁用采用给定设置的 WiFi 网络。在接入点模式下，可通过 IP 地址 192.168.20.1 访问设备</td></tr></table>




<div style="text-align: center;"><div style="text-align: center;">4.16 Device（设备）选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Program</td><td style='text-align: center; word-wrap: break-word;'>Program</td><td style='text-align: center; word-wrap: break-word;'>为设备编程指定的 WiFi 设置。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>FW Load</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>指示运行固件的处理器上的 CPU 负载。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>CPU Load</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>指示运行数据服务器的机器上的总 CPU 负载。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>CPU Temperature</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>指示运行数据服务器的 MF 内部 CPU 的温度。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Memory Usage</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>指示运行数据服务器的机器的总体内存使用情况。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Interface</td><td style='text-align: center; word-wrap: break-word;'>1.PCIe</td><td style='text-align: center; word-wrap: break-word;'>设备和数据服务器之间的活动接口。如果有多个选项可用，则左侧所示的优先级适用。</td></tr></table>

### 4.17. File Manager（文件管理器）选项卡

通过 File Manager（文件管理器）选项卡可快速访问存储在仪器闪存盘上的文件，以及连接到某个 USB 连接器的任何大容量存储设备上的文件。

#### 4.17.1. 特征

一 将测量数据、仪器设置和日志文件下载到本地设备

一 管理仪器闪存盘和所连接 USB 大容量存储设备的文件结构（浏览、复制、重命名、删除）

一 从 USB 大容量存储设备更新仪器

一 对设置文件和日志文件进行文件预览

#### 4.17.2. 描述

File Manager（文件管理器）选项卡提供标准工具来查看和整理仪器闪存盘以及所连接 USB 存储设备上的文件。可便利地复制、重命名、下载和删除文件。当该选项卡关闭或需要其他相同类型的选项卡时，单击以下图标即可打开该选项卡的新实例。

<div style="text-align: center;"><div style="text-align: center;">表 4.52. 应用图标和简要描述</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Files</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>访问内部闪存和 U 盘上的文件。</td></tr></table>

Files（文件）选项卡（参见图 4.39）提供三种浏览窗口。左侧窗口允许用户通过目录结构浏览，中间窗口显示在左侧窗口中选定的文件夹中的文件，右侧窗口显示在中间窗口中选定的文件中的内容，例如一个设置文件或日志文件。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//49205bc5-ac8a-4fff-841c-029e29043e25/markdown_2/imgs/img_in_image_box_215_857_1073_1054.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A41Z%2F-1%2F%2Ff879414b780159a27fdd69a8a8b5cd5139b840835103c98796c245728a74d532" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.39.LabOne UI: File Manager（文件管理器）选项卡</div> </div>


#### 4.17.3. 功能元素

<div style="text-align: center;"><div style="text-align: center;">表 4.53.File（文件）选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>New Folder</td><td style='text-align: center; word-wrap: break-word;'>New Folder</td><td style='text-align: center; word-wrap: break-word;'>在当前位置创建新文件夹。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Rename</td><td style='text-align: center; word-wrap: break-word;'>Rename</td><td style='text-align: center; word-wrap: break-word;'>重命名所选文件或文件夹。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Delete</td><td style='text-align: center; word-wrap: break-word;'>Delete</td><td style='text-align: center; word-wrap: break-word;'>删除所选文件和/或文件夹。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Copy</td><td style='text-align: center; word-wrap: break-word;'>Copy</td><td style='text-align: center; word-wrap: break-word;'>将所选文件和/或文件夹复制到剪贴板。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Cut</td><td style='text-align: center; word-wrap: break-word;'>Cut</td><td style='text-align: center; word-wrap: break-word;'>将所选文件和/或文件夹剪切到剪贴板。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Paste</td><td style='text-align: center; word-wrap: break-word;'>Paste</td><td style='text-align: center; word-wrap: break-word;'>将文件和/或文件夹从剪贴板粘贴到所选目录。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Upload</td><td style='text-align: center; word-wrap: break-word;'>Upload</td><td style='text-align: center; word-wrap: break-word;'>将文件和/或文件夹上传到所选目录。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Download</td><td style='text-align: center; word-wrap: break-word;'>Download</td><td style='text-align: center; word-wrap: break-word;'>下载所选文件和/或文件夹。</td></tr></table>

### 4.18.PID/PLL 选项卡

PID/PLL 选项卡仅可用于已安装 MF-PID 四通道 PID/PLL 控制器选件的 MFLI 仪器（已安装的选件显示在 Device（设备）选项卡中）。

##### 注释

反馈控制器提供通用的 PID 功能、锁相环 (PLL) 功能和外部参考功能。当用户将某个解调器设置为 ExtRef 模式时（参见 Lock-in（锁相）选项卡，Demodulators（调制解调器）部分，Mode（模式）列），将为此保留一个 PID 控制器。

##### 注释

PID/PLL 选项卡中的部分设置与可从其他选项卡访问的设置是共生的。如果 PID 输出控制某个变量，例如 Signal Output Offset（信号输出偏移），则该变量在其他选项卡中（在此例中即为 Lock-in（锁相）选项卡）显示为只读。

#### 4.18.1. 特征

一 四个完全可编程的比例、积分和微分 (PID) 控制器

一 两个完全可编程的 5 MHz/500 kHz 锁相环

一带多个 DUT 模型、传递函数和阶跃函数建模的 PID/PLL Advisor（智能参数设定）

一 自动调谐：自动将 PID 误差信号幅值调至最小

一 高达 50 kHz 环路滤波器带宽，支持高速运行

一 输入参数：解调器数据、辅助输入、辅助输出

一 输出参数：输出幅值、振荡器频率、解调器相位、辅助输出、信号输出偏移

一 解调器  $ \Theta $ 数据 ( $ \pm 1024\pi $) 相位展开，例如用于光学锁相环

一 微分 (D) 反馈分量的带宽限制

一 可编程 PLL 中心频率和相位设定值

一 可编程 PLL 相位检测器的滤波器设置

一 PLL 中心频率和设定值自动校零功能

一 使用谐波乘法因子生成因数频率

#### 4.18.2. 描述

PID/PLL 选项卡是仪器中反馈回路控制器的主要控制中心。当该选项卡关闭或需要其他相同类型的选项卡时，单击以下图标即可打开该选项卡的新实例。

<div style="text-align: center;"><div style="text-align: center;">表 4.54. 应用图标和简要描述</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID</td><td style='text-align: center; word-wrap: break-word;'>☑</td><td style='text-align: center; word-wrap: break-word;'>具有 PID 控制器的所有控制、分析和模拟功能。</td></tr></table>

PID/PLL 选项卡（参见图 4.40）包括四个相同的侧边栏选项卡，每一个都可用于访问四个 PID/PLL 控制器之一的功能和相关的 PID 智能参数设定功能。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//49205bc5-ac8a-4fff-841c-029e29043e25/markdown_4/imgs/img_in_image_box_228_120_1048_473.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A43Z%2F-1%2F%2F4a239c7a9a22e587b343fcb23ef7b3ea8e76d72357cb7b0390aad8272ae40322" alt="Image" width="68%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.40.LabOne UI: PID/PLL 选项卡</div> </div>


LabOne PID 控制器具有许多不同的输入和输出连接，使用范围极其广泛，可用于许多不同的应用，包括激光同步或高速 SPM。图 4.41 所示框图包括了所有的 PID 控制器元件、其互相连接以及可供用户指定的变量。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//49205bc5-ac8a-4fff-841c-029e29043e25/markdown_4/imgs/img_in_image_box_257_699_1042_994.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A43Z%2F-1%2F%2Fb677d7c86da8c05772615163ed41bef53b24efdc6927a182822f88335d3852d7" alt="Image" width="65%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.41.PID 控制器框图</div> </div>


##### 设置一个控制环

不同应用设置控制环的方法也不同。以下考虑几种不同的方法，探索 Advisor（智能参数设定）如何在减少工作量的同时改进设置结果，提升对设置的理解。

##### 手动设置

如果被测设备 (DUT) 的传递函数未知，并且只有很少的噪声从环境中耦合到系统中，那么通常手动操作是最快的方法。手动配置新的控制环时，建议首先采用较小的 P 值，并将其他参数（I、D、D 限值）设置为零。通过启用控制器，能够立即看到 P 的符号是否正确以及反馈是否作用于正确的输出参数，例如通过检查显示在 PID/PLL 选项卡中的数字（误差、位移、输出）。积分增益 I 的逐步提高有助于将 PID 误差信号完全归零。启用微分增益 D 可提高反馈回路的速度，但也会导致反馈回路行为不稳定。在此阶段并行监控第 4.6 节所述的 PID 误差会非常有帮助。借助 Plotter（绘图仪）中提供的数学工具，用户能够显示误差的标准差和平均值。这些值应通过调整 PID 参数来获得最小值，并且相关的直方图应该具有对称的（理想情况下采用高斯分布来实现）包络图。

为定量地表征反馈回路，可测量阶跃响应，参见第 4.8 节。要进行该测量，需要在将 DAQ 触发电平配置在新旧设定值之间一半后手动更改 PID 设定值。选择 DAQ Delay（DAQ 延迟）和 Duration

（持续时间）以粗略匹配预计带宽。对于具有精细时间分辨率的阶跃响应曲线，PID 数据速率应该足够高。

##### PID 智能参数设定功能

在许多实验条件下，外部设备或 DUT 可通过一个简单的模型来良好模拟。借助 LabOne PID 智能参数设定功能，用户可以在反馈回路中模拟多种不同类型 DUT 的行为，并根据模拟结果选择反馈增益参数。DUT 由模型功能表征，可在 Advisor（智能参数设定）子选项卡上设置多种参数。所有模型均可设置发生在仪器外的延迟。根据不同的目标伺服带宽，外部延迟通常可作为限制因素，需要明智选择。

##### 注释

为每个模型指定的延迟是对仪表输入上看到的仪表输出逐步变化的最早的可能响应。它描述的是系统的因果关系，不影响 DUT 传递函数的形状。标准同轴电缆导致的信号延迟约为 5 ns/m。

最简单的建模方法是使用全通 (All Pass) 假设一个具有统一的传递函数的 DUT。低通滤波器允许限制带宽，为二阶滤波器设置整体增益和阻尼。将增益 (Gain) 设为 1，延迟 (Delay) 设置为 0 时，全通可独立于外部设备对 PID 控制器进行建模。谐振器频率 (Resonator Frequency) 模型非常适用于具有无源外部组件的情况，例如 AFM 悬臂或石英谐振器，其频率应由 PLL 随时间跟踪。当需要使用第二个控制环（自动增益控制）来稳定谐振器信号的幅值时，谐振器幅值 (Resonator Amplitude) 模型是合适的选择。设置谐振频率和 Q 因子（二者均可通过使用第 4.10 节所述方法对谐振器进行频率扫描来获得），使 Advisor（智能参数设定）能够估计谐振器的增益和低通行为。每当提供一个应由内部振荡器跟踪的外部振荡信号时，都使用内部 PLL (Internal PLL)。VCO 设置描述的情况是 DUT 的输入变量是电压，输出是频率。该增益参数规定了输入电压的变化会导致 VCO 输出产生多大的频移。如果使用外部参考模式可以跟踪 VCO 的频率，那么用户可以通过扫描辅助输出电压并显示产生的振荡器频率，轻松按照第 4.10 节所述内容测量增益。增益是由所产生的直线在期望频率上的斜率给出的。

模型和参数经过设置后已能够最贴近实际测量情况，现在可以通过为整个控制环定义目标带宽并选择 Advise（建议）模式来继续，即用于控制操作的反馈增益参数。只要从其中一个解调器获取输入信号，就可方便地激活目标带宽旁的方框。该方框激活后，Advise 算法会自动将解调器带宽调整到比目标带宽高 5 倍的值，以免受到解调速度的限制。接下来 Advisor 算法将计算目标阶跃响应函数，它将在下一步通过调整反馈增益参数来求得该函数。在此之前，如果使用的是新建的 DUT 模型，该算法将首先尝试使用齐格勒·尼科尔斯方法来估计 PID 参数。如果在此之前已运行过一次，用户也可手动更改模型中的参数，用作下一次 Advise 运行的新启动参数。从初始参数开始，Advisor（智能参数设定）将执行数值优化，以实现计算的阶跃响应与根据目标带宽（Target Bandwidth）确定的目标阶跃响应的最小二乘拟合。其结果由得到的带宽（BW）和相位裕度（PM）进行数值表征。此外右侧的较大绘图区域可通过显示环内不同信号节点之间的传递函数、幅值和相位以及阶跃响应来表征结果。建模完成后，可通过单击 To PID 将结果参数复制到物理 PID。

<div style="text-align: center;"><div style="text-align: center;">表 4.55.DUT 传递函数</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>名称</td><td style='text-align: center; word-wrap: break-word;'>函数</td><td style='text-align: center; word-wrap: break-word;'>参数</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>全通</td><td style='text-align: center; word-wrap: break-word;'>H(s) = g</td><td style='text-align: center; word-wrap: break-word;'>1. 增益 g</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>一阶低通</td><td style='text-align: center; word-wrap: break-word;'>H(s) = g $ \frac{1}{t_{c}s + 1} $ = g $ \frac{\omega_{n}}{s + \omega_{n}} $</td><td style='text-align: center; word-wrap: break-word;'>1. 增益 g 2. 滤波器带宽 (BW)  $ f_{-3dB} = \omega_{n} / 2\pi $</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>二阶低通</td><td style='text-align: center; word-wrap: break-word;'>H(s) = g $ \frac{\omega_{n}^{2}}{s^{2} + 2\omega_{n}\zeta s + \omega_{n}^{2}} $</td><td style='text-align: center; word-wrap: break-word;'>1. 增益 g 2. 谐振频率  $ f_{res} = \omega_{n} / 2\pi $ 3.  $ f_{-3dB} = 2\zeta f_{res} $ 时阻尼比  $ \zeta $</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>谐振器频率</td><td style='text-align: center; word-wrap: break-word;'>$ H(s) = -360^{\circ}\frac{t_{c}}{t_{c}s + 1} $，其中 $ t_{c} = \frac{1}{2\pi BW} = \frac{2Q}{2\pi f_{res}} $</td><td style='text-align: center; word-wrap: break-word;'>1. 谐振频率 $ f_{res} $ 2. 品质因数 $ Q $</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>谐振器幅度</td><td style='text-align: center; word-wrap: break-word;'>$ H(s) = g\frac{\omega / (2Q)}{s + \omega / (2Q)} $，其中 $ \omega = 2\pi f_{res} $</td><td style='text-align: center; word-wrap: break-word;'>1. 增益 $ g $ 2. 谐振频率 $ f_{res} $ 3. 品质因数 $ Q $</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>内部PLL</td><td style='text-align: center; word-wrap: break-word;'>$ H8s) = -\frac{360^{\circ}}{s} $</td><td style='text-align: center; word-wrap: break-word;'></td></tr><tr><td style='text-align: center; word-wrap: break-word;'>VCO</td><td style='text-align: center; word-wrap: break-word;'>$ H(s) = g\frac{360^{\circ}}{s(t_{c}s + 1)} $，其中 $ t_{c} = \frac{1}{2\pi f_{res}} $</td><td style='text-align: center; word-wrap: break-word;'>1. 增益 $ g $ (Hz/V) 2. 带宽(BW)  $ f_{-3dB} $</td></tr></table>





##### 注释

使用 Advisor（智能参数设定）时建议逐步将自由参数从 P 增加到 PI，再增加到 PID。这样可以防止优化到局部极小值，从而可以节省时间。此外，这还可以直观说明哪些反馈参数会导致反馈行为中的哪些影响。

##### 注释

微分部分的低通滤波器作为指数移动平均滤波器实施，描述为  $  y_t = (1 - \alpha) \cdot y_{t-1} + \alpha x_t  $，其中  $  \alpha = 2^{-dshift}  $,  $  x_t  $ 为滤波器输入， $  y_t  $ 为滤波器输出。dshift 默认值为 0，对应禁用的滤波器。在 UI 中，滤波器属性可以以带宽或时间常数为单位进行更改。

如果反馈输出是施加在敏感外部设备上的电压，则建议使用中心值以及上限和下限值，从而保证即使锁相失败且积分器饱和，输出也仍保持在定义的时间内。

##### 自动调谐

自动调谐功能位于 Tuner（调谐器）子选项卡，可帮助将残留误差信号减至最少。自动调谐将反馈增益参数改变为在 Advisor（智能参数设定）子选项卡的 Advise Mode（建议模式）字段中所选择的参数，从而即将 PID 误差信号的均方根降至最小。自动调谐功能以测量为基础，由于能够考虑实际实验噪声和设备传递函数，因此通常能够改进基于模型的 PID 智能参数设定功能的结果。为达到良好的自动调谐效果，应该将自动调谐应用于 PID 环的实际操作条件，否则 PID 带宽可能会过低。例如，将自动调谐功能应用于抬起的 AFM 悬臂上的 PLL，而该 PLL 稍后将在扫描期间跟踪悬臂，这将没有任何意义。

所选 PID 设置的传递函数可始终通过单击 To Advisor 按钮后在 Display（显示）子选项卡选择 Advanced Mode（高级模式）将值复制到 Advisor（智能参数设定）来进行检查。将 Response In（响应输入）设置为 Setpoint（设定值），将 Response Out（响应输出）设置为 PID Output（PID 输出），并将 Closed-Loop（闭环）禁用，用户可看到 PID 控制器传递函数的波特幅值图。该图经常出现在教科书中，并且独立于 DUT 部分中选择的模型函数。但是如果是要模拟阶跃响应或计算带宽，则需要为整个环建立一个合适的模型。

##### 设置锁相环 (PLL)

PID 控制器 1 和 2 可在 Mode（模式）选择器中设为 PLL 模式。更改为 PLL 模式后，PID 控制器输入会设为解调器相位，PID 控制器输出会设为内部振荡器频率，部分参数也将更改为适当的默认值。图 4.42 所示框图包括了 PLL 元件、其互相连接以及可供用户指定的变量。此示意图中的解调器和 PID 控制器略有简化。其完整详细框图分别参见未安装 MF-MD 多解调器选件的解调器框图、已安装 MF-MD 多解调器选件的解调器框图和图 4.41。

##### 锁相环

锁相环

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//4fc54919-86db-4980-b4fa-628f1d804e8c/markdown_2/imgs/img_in_image_box_252_219_1032_526.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A26Z%2F-1%2F%2F5af4b35eaa7306c6a9641a3d90c4c46a9dceec61db54621988f67fcdc6b8adf2" alt="Image" width="65%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.42. 锁相环框图（元件有所简化）</div> </div>


在设置 PLL 的常规程序中，首先在左侧部分确定中心频率、频率限值以及相位设定值。如果事先未知频率，通常可以使用参数扫描仪或频谱工具来确定频率。然后在 Advisor（智能参数设定）部分设定目标带宽，点击 Advise（建议）按钮。Advisor（智能参数设定）计算得出的反馈参数将显示在下面的字段中。计算得出的传递函数的图形表示显示在右侧的绘图中。如果对结果满意，就可以点击 To PID 按钮将值传递到仪器，然后启用 PLL。如果 Error/PLL Lock（误差/PLL 锁相）字段显示非常小的值，则表明锁相成功。现在可以重复该过程，例如在 PLL Advisor（智能参数设定）中使用目标带宽来计算一组新的反馈参数。在绘图仪中显示振荡器频率以及直方图和数学函数（例如标准差）有助于量化残留相位误差，并通过手动调整进一步提高锁相性能。

##### 注释

PLL 频率限制设定的范围应比目标带宽大 5 至 10 倍甚至更多。

##### 注释

在 PID/PLL 选项卡中，应选择将所用的哪些解调器用作相位检测器。打开 Lock-in（锁相）选项卡，查看正确的 Signal Input（信号输入）是否关联到所用的解调器。

#### 4.18.3. 功能元素

<div style="text-align: center;"><div style="text-align: center;">表 4.56.PID 选项卡：PID 部分</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td rowspan="4">Mode</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>PID 模块的工作模式。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID</td><td style='text-align: center; word-wrap: break-word;'>PID 用于一般应用。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PLL</td><td style='text-align: center; word-wrap: break-word;'>PID 用于控制内部振荡器。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>ExtRef</td><td style='text-align: center; word-wrap: break-word;'>PID 由外部参考使用以控制内部振荡器。</td></tr><tr><td rowspan="4">Auto Mode</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>该项定义 PID 中参数的自动调整类型。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Off</td><td style='text-align: center; word-wrap: break-word;'>不自动调整。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID Coeff</td><td style='text-align: center; word-wrap: break-word;'>自动设置 PID 控制器的系数。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Coeff + BW (low)</td><td style='text-align: center; word-wrap: break-word;'>使用低带宽自动设置 PID 系数、滤波器带宽和输出限值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Coeff + BW (high)</td><td style='text-align: center; word-wrap: break-word;'>使用高带宽自动设置 PID 系数、滤波器带宽和输出限值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Adaptive</td><td style='text-align: center; word-wrap: break-word;'>调整包括中心频率在内的所有 PID 参数。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Phase Unwrap</td><td style='text-align: center; word-wrap: break-word;'>ON / OFF</td><td style='text-align: center; word-wrap: break-word;'>支持相位重建，以便能够跟踪超过 +/-180 度边界的相位误差并增加 PLL 带宽。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Center</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>将 Center 值添加到 PID 输出后，信号取值范围为 Center + Lower Limit 和 Center + Upper Limit 之间。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lower Limit</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>将 Center 值添加到 PID 输出后，信号取值范围为 Center + Lower Limit 和 Center + Upper Limit 之间。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Upper Limit</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>将 Center 值添加到 PID 输出后，信号取值范围为 Center + Lower Limit 和 Center + Upper Limit 之间。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>D Limit TC/BW 3 dB</td><td style='text-align: center; word-wrap: break-word;'>673 ns 至 15 ms/10 Hz</td><td style='text-align: center; word-wrap: break-word;'>D 限制的低通滤波器截止值，显示为滤波器时间常数或 3 dB 截止频率，具体取决于所选的 TC 模式。设置为 0 时，禁用低通滤波器。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lock LED</td><td style='text-align: center; word-wrap: break-word;'>灰色/绿色</td><td style='text-align: center; word-wrap: break-word;'>指示 PID（配置为 PLL）何时锁定。以 5 Sa/s 的速率采样 PLL 误差，并计算其绝对值。如果结果小于 5 度，则认为环路已锁定。仅在 PLL 或 ExtRef 模式下有效。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Value</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>当前输出值</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Enable</td><td style='text-align: center; word-wrap: break-word;'>ON / OFF</td><td style='text-align: center; word-wrap: break-word;'>启用 PID 控制器</td></tr><tr><td rowspan="6">Input</td><td style='text-align: center; word-wrap: break-word;'>Demodulator X</td><td style='text-align: center; word-wrap: break-word;'>选择 PID 控制器的输入源</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Demodulator Y</td><td style='text-align: center; word-wrap: break-word;'>解调器笛卡尔坐标 X 分量</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Demodulator R</td><td style='text-align: center; word-wrap: break-word;'>解调器笛卡尔坐标 Y 分量</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Demodulator Theta</td><td style='text-align: center; word-wrap: break-word;'>解调器幅值分量</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Aux Input</td><td style='text-align: center; word-wrap: break-word;'>解调器相位</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Aux Output</td><td style='text-align: center; word-wrap: break-word;'>辅助输入</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Input Channel</td><td style='text-align: center; word-wrap: break-word;'>索引</td><td style='text-align: center; word-wrap: break-word;'>选择 PID 控制器的输入通道。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Setpoint</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>PID 控制器设定值</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Filter BW</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>将解调器滤波器的带宽用作输入。</td></tr><tr><td rowspan="9">Filter Order</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>在 6 dB/oct 和 48 dB/oct 之间选择当前解调器的滤波器滚降系数。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>1 阶滤波器为 6 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>2</td><td style='text-align: center; word-wrap: break-word;'>2 阶滤波器为 12 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>3</td><td style='text-align: center; word-wrap: break-word;'>3 阶滤波器为 18 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>4</td><td style='text-align: center; word-wrap: break-word;'>4 阶滤波器为 24 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>5</td><td style='text-align: center; word-wrap: break-word;'>5 阶滤波器为 30 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>6</td><td style='text-align: center; word-wrap: break-word;'>6 阶滤波器为 36 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>7</td><td style='text-align: center; word-wrap: break-word;'>7 阶滤波器为 42 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>8</td><td style='text-align: center; word-wrap: break-word;'>8 阶滤波器为 48 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Harmonic</td><td style='text-align: center; word-wrap: break-word;'>1 至 1023</td><td style='text-align: center; word-wrap: break-word;'>当前解调器的参考频率的谐波倍数。</td></tr><tr><td rowspan="7">Output</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择 PID 控制器的输出</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sig Out 1 Amplitude</td><td style='text-align: center; word-wrap: break-word;'>反馈到主信号输出幅值 1</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sig Out 2 Amplitude</td><td style='text-align: center; word-wrap: break-word;'>反馈到主信号输出幅值 2</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Oscillator Frequency</td><td style='text-align: center; word-wrap: break-word;'>反馈到内部振荡器频率之一</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Demodulator Phase</td><td style='text-align: center; word-wrap: break-word;'>反馈到 8 个解调器相位设定值之一</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Aux Output Offset</td><td style='text-align: center; word-wrap: break-word;'>反馈到 4 个辅助输出偏移量之一</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Signal Output Offset</td><td style='text-align: center; word-wrap: break-word;'>反馈到主信号输出偏移量调整</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Output Channel</td><td style='text-align: center; word-wrap: break-word;'>索引</td><td style='text-align: center; word-wrap: break-word;'>选择 PID 控制器的输出通道。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>P (Hz/deg)</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>PID 比例增益 P</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>I (Hz/deg/s)</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>PID 积分增益 I</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>D (Hz/deg*s)</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>PID 微分增益 D</td></tr><tr><td rowspan="2">Rate</td><td rowspan="2">3.7 Hz 至 469 kHz</td><td style='text-align: center; word-wrap: break-word;'>PID 采样率和 PID 输出的更新率。需要设置为远高于目标环路滤波器带宽。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>控制器的数值精度受环路滤波器采样率的影响。如果目标带宽低于 1 kHz，则将该速率的值调整为目标带宽的 100 至 500 倍左右就会很有用。对于低带宽应用，如果将速率设置得过高，积分不精确性会导致非线性行为。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Error</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>误差 = 设定值 - PID 输入</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Shift</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>当前输出值 Out 和 Center 之差。Shift = P*Error + I*Int(Error, dt) + D*dError/dt</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>To Advisor</td><td style='text-align: center; word-wrap: break-word;'>To Advisor</td><td style='text-align: center; word-wrap: break-word;'>将当前 PID 设置复制到 PID Advisor。</td></tr></table>








<div style="text-align: center;"><div style="text-align: center;">表 4.57.PID 选项卡：Advisor 子选项卡</div> </div>




<table border="1" style="margin: auto; word-wrap: break-word;"><tr><td style="text-align: center; word-wrap: break-word;">控件/工具</td><td style="text-align: center; word-wrap: break-word;">选项/范围</td><td style="text-align: center; word-wrap: break-word;">描述</td></tr><tr><td style="text-align: center; word-wrap: break-word;">D Limit TC/BW 3 dB</td><td style="text-align: center; word-wrap: break-word;">数值</td><td style="text-align: center; word-wrap: break-word;">D 限制的低通滤波器截止值，显示为滤波器时间常数或 3 dB 截止频率，具体取决于所选的 TC 模式。设置为 0 时，禁用低通滤波器。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Rate</td><td style="text-align: center; word-wrap: break-word;">3.7 Hz 至 469 kHz</td><td style="text-align: center; word-wrap: break-word;">用于模拟的 PID 采样率。
Advisor 将更新采样率以匹配指定的目标带宽。采样率与目标带宽接近以及带宽过高都将导致模拟不匹配。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Advise</td><td style="text-align: center; word-wrap: break-word;">Advise</td><td style="text-align: center; word-wrap: break-word;">根据使用的 DUT 模型和给定的目标带宽计算 PID 系数。如果可以找到最优值，则更新系数并在绘图上更新响应曲线。
仅优化使用建议模式指定的 PID 系数。Advise（建议）模式可以增量方式使用，即表示将当前系数用作优化起点，但其他模型参数在其间发生变化的情况除外。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Target BW (Hz)</td><td style="text-align: center; word-wrap: break-word;">数值</td><td style="text-align: center; word-wrap: break-word;">闭环反馈系统的目标带宽，用于提供 PID 参数建议。该带宽决定 PID 速度和噪声之间的权衡结果。</td></tr><tr><td rowspan="6">Advise Mode</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">选择优化的 PID 系数。其他 PID 系数保持不变，但在优化期间正常使用。这样能够在优化其余部分的同时将所选系数保持在固定值。
建议时间将随着待优化参数数量的增加而显著延长。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">PIDF</td><td style="text-align: center; word-wrap: break-word;">优化比例增益、积分增益和微分增益。微分增益带宽也将一并优化。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">P</td><td style="text-align: center; word-wrap: break-word;">只优化比例增益。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">I</td><td style="text-align: center; word-wrap: break-word;">只优化积分增益。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">PI</td><td style="text-align: center; word-wrap: break-word;">只优化比例增益和积分增益。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">PID</td><td style="text-align: center; word-wrap: break-word;">优化比例增益、积分增益和微分增益。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Filter BW</td><td style="text-align: center; word-wrap: break-word;">数值</td><td style="text-align: center; word-wrap: break-word;">定义所选解调器输入的低通滤波器特性。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Auto Bandwidth</td><td style="text-align: center; word-wrap: break-word;">ON / OFF</td><td style="text-align: center; word-wrap: break-word;">调整解调器带宽以完美适应整个系统的指定目标带宽。禁用后，如果解调器带宽与目标带宽过于接近，可能会导致过冲和不稳定问题。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">在特殊情况下，也可以选择小于目标带宽的解调器带宽。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Filter Order</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">在 6 dB/oct 和 48 dB/oct 之间选择模型解调器的滤波器滚降系数。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">1</td><td style="text-align: center; word-wrap: break-word;">1 阶滤波器为 6 dB/oct</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">2</td><td style="text-align: center; word-wrap: break-word;">2 阶滤波器为 12 dB/oct</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">3</td><td style="text-align: center; word-wrap: break-word;">3 阶滤波器为 18 dB/oct</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">4</td><td style="text-align: center; word-wrap: break-word;">4 阶滤波器为 24 dB/oct</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">5</td><td style="text-align: center; word-wrap: break-word;">5 阶滤波器为 30 dB/oct</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">6</td><td style="text-align: center; word-wrap: break-word;">6 阶滤波器为 36 dB/oct</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">7</td><td style="text-align: center; word-wrap: break-word;">7 阶滤波器为 42 dB/oct</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">8</td><td style="text-align: center; word-wrap: break-word;">8 阶滤波器为 48 dB/oct</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Harmonic</td><td style="text-align: center; word-wrap: break-word;">1 至 1023</td><td style="text-align: center; word-wrap: break-word;">模型解调器的参考频率的谐波倍数。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">DUT Model</td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">由 PID 控制的外部设备所采用的模型类型。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">有关每种模型传递函数的详细说明，请参见上一节。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">All Pass</td><td style="text-align: center; word-wrap: break-word;">外部设备采用全通滤波器模型。需配置的参数有延迟和增益。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">LP 1st</td><td style="text-align: center; word-wrap: break-word;">外部设备采用一阶低通滤波器模型。需配置的参数有延迟、增益和滤波器带宽。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">LP 2nd</td><td style="text-align: center; word-wrap: break-word;">外部设备采用二阶低通滤波器模型。需配置的参数有延迟、增益、谐振频率和阻尼比。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Resonator Frequency</td><td style="text-align: center; word-wrap: break-word;">外部设备采用谐振器模型。需配置的参数有延迟、中心频率和品质因数。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Internal PLL</td><td style="text-align: center; word-wrap: break-word;">DUT 是通过锁相环锁定到外部信号的内部振荡器。需配置的参数有延迟。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">VCO</td><td style="text-align: center; word-wrap: break-word;">外部设备采用压控振荡器模型。需配置的参数有延迟、增益和带宽。</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">Resonator Amplitude</td><td style="text-align: center; word-wrap: break-word;">外部设备采用谐振器模型。需配置的参数有延迟、增益、中心频率和品质因数。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Delay</td><td style="text-align: center; word-wrap: break-word;">数值</td><td style="text-align: center; word-wrap: break-word;">确定阶跃变化最早响应的参数。该参数不影响DUT 传递函数的形状。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Gain</td><td style="text-align: center; word-wrap: break-word;">数值</td><td style="text-align: center; word-wrap: break-word;">确定 DUT 传递函数增益的参数。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">BW (Hz)</td><td style="text-align: center; word-wrap: break-word;">数值</td><td style="text-align: center; word-wrap: break-word;">确定一阶低通滤波器带宽或 VCO 带宽的参数。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Damping Ratio</td><td style="text-align: center; word-wrap: break-word;">数值</td><td style="text-align: center; word-wrap: break-word;">确定二阶低通滤波器阻尼比的参数。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Res Freq</td><td style="text-align: center; word-wrap: break-word;">数值</td><td style="text-align: center; word-wrap: break-word;">确定谐振器模型谐振频率的参数。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Q</td><td style="text-align: center; word-wrap: break-word;">数值</td><td style="text-align: center; word-wrap: break-word;">确定谐振器模型品质因数的参数。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">P (Hz/deg)</td><td style="text-align: center; word-wrap: break-word;">数值</td><td style="text-align: center; word-wrap: break-word;">比例增益 P 系数，用于计算 PID 模型的响应。可以使用 PID advise 优化参数或手动更改参数。仅当按下 To PLL 按钮后，该参数才会在 PID 上激活。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">I (Hz/deg/s)</td><td style="text-align: center; word-wrap: break-word;">数值</td><td style="text-align: center; word-wrap: break-word;">积分增益 I 系数，用于计算 PID 模型的响应。可以使用 PID advise 优化参数或手动更改参数。仅当按下 To PLL 按钮后，该参数才会在 PID 上激活。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">D (Hz/deg*s)</td><td style="text-align: center; word-wrap: break-word;">数值</td><td style="text-align: center; word-wrap: break-word;">微分增益 D 系数，用于计算 PID 模型的响应。可以使用 PID advise 优化参数或手动更改参数。仅当按下 To PLL 按钮后，该参数才会在 PID 上激活。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">BW (Hz)</td><td style="text-align: center; word-wrap: break-word;">数值</td><td style="text-align: center; word-wrap: break-word;">采用当前 PID 设置的全闭环模型的模拟带宽。该值应大于目标带宽。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Target BW LED</td><td style="text-align: center; word-wrap: break-word;">绿色/红色</td><td style="text-align: center; word-wrap: break-word;">绿色表示可以实现目标带宽。对于极高的 PID 带宽，只能通过临界稳定 PID 设置来实现目标</td></tr><tr><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;"></td><td style="text-align: center; word-wrap: break-word;">带宽。在这种情况下，可尝试降低带宽或优化PID系统的环路延迟。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">PM (deg)</td><td style="text-align: center; word-wrap: break-word;">数值</td><td style="text-align: center; word-wrap: break-word;">采用当前设置的PID的模拟相位裕度。在稳定条件下，对于内部PLL，相位裕度应大于45度；对于所有其他DUT，相位裕度应大于60度。如果没有单位增益交叉点可用于确定相位裕度，则显示无穷大值。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">Stable LED</td><td style="text-align: center; word-wrap: break-word;">绿色/红色</td><td style="text-align: center; word-wrap: break-word;">绿色表示满足相位裕度，且PID系统应达到稳定状态。</td></tr><tr><td style="text-align: center; word-wrap: break-word;">To PID</td><td style="text-align: center; word-wrap: break-word;">To PID</td><td style="text-align: center; word-wrap: break-word;">将PID Advisor设置复制到PID。</td></tr></table>








<div style="text-align: center;"><div style="text-align: center;">表 4.58.PID 选项卡：Tuner（调谐器）子选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Auto Tune</td><td style='text-align: center; word-wrap: break-word;'>Run/Stop</td><td style='text-align: center; word-wrap: break-word;'>优化 PID 参数，从而最大限度降低闭环系统的噪声。这种调谐方法需要一个适当的优化起点（远离限值）。调谐过程可以中断，也可以重启。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Enable</td><td style='text-align: center; word-wrap: break-word;'>ON / OFF</td><td style='text-align: center; word-wrap: break-word;'>在调谐过程中，会尝试将 PID 带宽与 DUT、信号输入（解调器）和信号输出的环路带宽相匹配。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Alt Setpoint</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>启用设定值切换</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Toggle Rate</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>定义用于设定值切换的第二个设定值。定义设定值切换的速率。请注意，可能值之间呈对数间隔（系数为 4）。</td></tr><tr><td rowspan="6">Mode</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择优化的 PID 系数。其他 PID 系数保持不变，但在优化期间正常使用。这样能够在优化其余部分的同时将系数强制设为某个值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PIDF</td><td style='text-align: center; word-wrap: break-word;'>优化比例增益、积分增益和微分增益。微分增益带宽也将一并优化。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>P</td><td style='text-align: center; word-wrap: break-word;'>只优化比例增益。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>I</td><td style='text-align: center; word-wrap: break-word;'>只优化积分增益。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PI</td><td style='text-align: center; word-wrap: break-word;'>只优化比例增益和积分增益。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID</td><td style='text-align: center; word-wrap: break-word;'>优化比例增益、积分增益和微分增益。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Advanced Mode</td><td style='text-align: center; word-wrap: break-word;'>ON / OFF</td><td style='text-align: center; word-wrap: break-word;'>可以手动选择调谐器求平均值和设定值切换操作。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Iteration Time</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>设置调谐器优化迭代的长度。</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">表 4.59.PID 选项卡：Display（显示）子选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Max Rate (Sa/s)</td><td style='text-align: center; word-wrap: break-word;'>1 至 469 kSa/s</td><td style='text-align: center; word-wrap: break-word;'>PID 输出数据发送到 PC 的目标速率。该值定义在将数据发送到 PC 时应用的抽取。它不会影响任何其他使用 PID 数据的位置。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Rate (Sa/s)</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>PID 流数据发送到 PC 的当前速率。根据 Max Rate（最大速率）定义。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Stream Overflow Indicator</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>指示流溢出。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Advanced Mode</td><td style='text-align: center; word-wrap: break-word;'>ON / OFF</td><td style='text-align: center; word-wrap: break-word;'>允许手动选择显示属性和建议属性。如果禁用，显示设置和建议设置会自动使用优化的默认值。</td></tr><tr><td rowspan="3">Display</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择用于呈现系统频率或时间响应的显示模式。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Bode Magnitude</td><td style='text-align: center; word-wrap: break-word;'>显示波特幅值图。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Bode Phase</td><td style='text-align: center; word-wrap: break-word;'>显示波特相位图。</td></tr><tr><td rowspan="2">Start (Hz)</td><td style='text-align: center; word-wrap: break-word;'>Step Resp</td><td style='text-align: center; word-wrap: break-word;'>显示阶跃响应图。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>波特图显示的起始频率。如果禁用高级模式，则会自动从系统属性获取起始值，输入字段为只读。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Stop (Hz)</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>波特图显示的结束频率。如果禁用高级模式，则会自动从系统属性获取结束值，输入字段为只读。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Start (s)</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>阶跃响应显示的起始时间。如果禁用高级模式，则起始值为零，该字段为只读。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Stop (s)</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>阶跃响应显示的结束时间。如果禁用高级模式，则会自动从系统属性获取结束值，输入字段为只读。</td></tr><tr><td rowspan="4">Transfer Function Selector</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择显示的环路传递函数。支持2种预设和手动选择。在闭环配置中，从输出到输入的所有元件都将被视为反馈元件。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>System</td><td style='text-align: center; word-wrap: break-word;'>从设定值到系统输出。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID</td><td style='text-align: center; word-wrap: break-word;'>从设定值到PID输出。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Manual</td><td style='text-align: center; word-wrap: break-word;'>可以查看开环或闭环中的任何传递函数。</td></tr><tr><td rowspan="6">Response In</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>开环或闭环工厂响应模拟的起点。在闭环配置中，从输出到输入的所有元件都将被视为反馈元件。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Demod Input</td><td style='text-align: center; word-wrap: break-word;'>起点位于解调器输入端。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Setpoint</td><td style='text-align: center; word-wrap: break-word;'>起点位于PID之前的设定值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID Output</td><td style='text-align: center; word-wrap: break-word;'>起点位于PID输出端。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Instrument Output</td><td style='text-align: center; word-wrap: break-word;'>起点位于仪器输出端。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DUT Output</td><td style='text-align: center; word-wrap: break-word;'>起点位于DUT输出端和仪器输入端。</td></tr><tr><td rowspan="6">Response Out</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>开环或闭环工厂响应模拟的终点。在闭环配置中，从输出到输入的所有元件都将被视为反馈元件。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID Output</td><td style='text-align: center; word-wrap: break-word;'>终点位于PID输出端。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Instrument Output</td><td style='text-align: center; word-wrap: break-word;'>终点位于仪器输出端。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DUT Output</td><td style='text-align: center; word-wrap: break-word;'>终点位于DUT输出端和仪器输入端。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Demod Input</td><td style='text-align: center; word-wrap: break-word;'>终点位于解调器输入端。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>System Output</td><td style='text-align: center; word-wrap: break-word;'>终点位于受控系统的输出端。</td></tr><tr><td rowspan="2">Closed-Loop TC Mode</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>切换显示系统闭环响应或系统开环响应。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>启用PID参数的时间常数表示。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Set Limits</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>按下“To PID”时，切换PID限值写入。仅适用于内部PLL。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Advisor Link</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>自动将以下显示的光标值复制到PID Advisor。要启用光标助手，请打开Advanced（高级）模式，将Display（显示）设为PID传递函数的Bode Magnitude（波特幅值图）。光标将以对数和dB轴标度组合显示。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>P</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>代表PID比例增益P的光标值。用鼠标指针拖动绘图光标或直接在此处插入数值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>I</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>代表PID积分增益I的光标值。用鼠标指针拖动绘图光标或直接在此处插入数值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>D</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>代表PID微分增益D的光标值。用鼠标指针拖动绘图光标或直接在此处插入数值。</td></tr></table>





### 4.19.Threshold（阈值）选项卡

Threshold Unit（阈值单元）选项卡允许用户定义选定输入信号的辨别条件和逻辑运算，并实时将结果输出为 TTL 信号。所有 MF 仪器均提供此功能和选项卡。

#### 4.19.1. 特征

一 4 个阈值单元用于状态检测

一 模拟输入信号：解调器数据（X、Y、R、 $ \Theta $）、PID 数据（误差、输出、偏移；需要 MF-PID 四通道 PID/PLL 控制器选件）

一 数字输入信号：32 个 DIO 通道、输入和输出过载等

一 阈值检测：超出、低于、内部、外部、上升沿、下降沿

一 可在检测阈值前应用绝对值和低通滤波

一 可配置的激活和去活时间

一 在一个输出上使用非、与、或和异或运算组合多达 3 个逻辑信号

一 最短长度、保持和逆变功能

#### 4.19.2. 描述

Threshold（阈值）选项卡支持对测量数据进行实时逻辑分析，以检测特殊情况或故障，并通过 TTL 输出触发反应。典型应用为 AFM 尖端保护或微流控细胞分选。当该选项卡关闭或需要其他相同类型的选项卡时，单击以下图标即可打开该选项卡的新实例。

<div style="text-align: center;"><div style="text-align: center;">表 4.60. 应用图标和简要描述</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Threshold</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>配置阈值单元和逻辑组合以生成数字输出信号。</td></tr></table>

Threshold（阈值）选项卡（参见图 4.43）分为两个部分，左侧是 Thresholds（阈值）部分，右侧是 Logic units（逻辑单元）部分。Thresholds（阈值）部分的各行表示单元的输入信号，以及将其转换为逻辑信号的离散操作。Logic units（逻辑单元）部分的各行表示单元的输出信号，以及为生成这些信号所执行的逻辑运算。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//9a49f1ed-e2d7-4aa8-8be5-e71381392ef2/markdown_3/imgs/img_in_image_box_216_1060_1074_1256.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A02Z%2F-1%2F%2F8e969de847f281173204cdf2303d960172c611052ad4a0662a42ba880b8374e0" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.43.LabOne UI: Threshold（阈值）选项卡</div> </div>


可用的输入信号包括模拟信号，例如解调器 R，以及仪器的数字输入或误差标记，例如信号输入过载。模拟输入信号可经过低通滤波处理，有助于在出现短路故障时避免误报。滤波后，对比信号与用户定义的阈值或范围，从而离散信号。超过阈值后，通过可配置的最短激活时间可进一步调谐时域行为。滤波后的阈值信号可显示于第 4.7 节所述的选项卡中，有助于定义有意义的阈值条件。当数字信号被选为输入时，激活和去活时间的设置方法与模拟信号相同。下面通过流程图和信号图详细展示了阈值单元中的信号处理过程。

为了在触发器输出中输出这些信号，第 4.13 节的 Mode setting（模式设置）需要设为 Threshold units（阈值单元）且需要启用 Trigger output Drive（触发器输出驱动）。默认情况下，四个逻辑信号按原样路由到四个触发器输出。为设置更复杂的状态检测，可使用逻辑运算在一个输出中最多组合三个输入信号。Logic units（逻辑单元）部分中的逻辑运算配置在默认情况下处于折叠状态。基础逻辑运算符（与、或、异或）以及逻辑反转（非）均可用，用户界面中以括号表示运算的分组。

##### 阈值

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//9a49f1ed-e2d7-4aa8-8be5-e71381392ef2/markdown_4/imgs/img_in_image_box_243_331_1034_591.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A03Z%2F-1%2F%2F85ee612ed41ab05aada04dd822b414bbfef6fc62a51e9a3939088cc2bfc959e7" alt="Image" width="66%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.44.Threshold（阈值）选项卡中 Thresholds（阈值）部分的流程图。</div> </div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//9a49f1ed-e2d7-4aa8-8be5-e71381392ef2/markdown_4/imgs/img_in_image_box_246_672_991_951.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A03Z%2F-1%2F%2F8951f99397ab27dff70a3544934f73235f025d4e642ce48ddaef80a7acd76a91" alt="Image" width="62%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.45.信号图所示为保护计时器中发生的信号处理示例。保护计时器块对应 Threshold（阈值）选项卡中 Thresholds（阈值）部分的 Enable/Disable（启用/禁用）设置，如图 4.44 所示。</div> </div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//9a49f1ed-e2d7-4aa8-8be5-e71381392ef2/markdown_4/imgs/img_in_image_box_277_1084_831_1340.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A03Z%2F-1%2F%2F60575b6bb25a27bfbbffec7d4f6f73dcb362573dc81f79131d98412c8cc9e6b8" alt="Image" width="46%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.46.Threshold（阈值）选项卡中 Logic Units（逻辑单元）部分的流程图。</div> </div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f0a757e7-d3c9-4345-9cc0-5abf71d108a7/markdown_0/imgs/img_in_chart_box_235_137_1028_422.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A51Z%2F-1%2F%2Ff8cbbaa0f83ee5a571378fd5f116d387b8eff971550534f65328af78a7c4f803" alt="Image" width="66%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.47. 信号图所示为 Threshold Unit（阈值单元）中 Hold and Width（保持和宽度）功能的信号处理示例。代表的信号 1 至 5 见图 4.46。</div> </div>


#### 4.19.3. 功能元素

<div style="text-align: center;"><div style="text-align: center;">表 4.61.Threshold（阈值）选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td rowspan="18">Signal</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择阈值单元中将使用的信号源。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>X</td><td style='text-align: center; word-wrap: break-word;'>选择解调器 X 分量作为输入。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Y</td><td style='text-align: center; word-wrap: break-word;'>选择解调器 Y 分量作为输入。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>R</td><td style='text-align: center; word-wrap: break-word;'>选择解调器幅值分量作为输入。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>$ \Theta $</td><td style='text-align: center; word-wrap: break-word;'>选择解调器相位分量作为输入。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID Out</td><td style='text-align: center; word-wrap: break-word;'>使用 PID 控制器的输出信号作为输入。需要安装 PID 选件。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID Shift</td><td style='text-align: center; word-wrap: break-word;'>使用 PID 控制器的偏移信号作为输入。需要安装 PID 选件。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID Error</td><td style='text-align: center; word-wrap: break-word;'>使用 PID 控制器的误差信号作为输入。需要安装 PID 选件。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DIO</td><td style='text-align: center; word-wrap: break-word;'>选择其中一个 DIO 通道作为输入。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Trigger In</td><td style='text-align: center; word-wrap: break-word;'>选择触发器输入作为输入。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Trigger Out</td><td style='text-align: center; word-wrap: break-word;'>选择触发器输出作为输入。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Input Overload (V)</td><td style='text-align: center; word-wrap: break-word;'>使用电压输入过载作为输入。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Input Overload (I)</td><td style='text-align: center; word-wrap: break-word;'>使用电流输入过载作为输入。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Output Overload</td><td style='text-align: center; word-wrap: break-word;'>使用信号输出过载作为输入。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Aux Input Overload</td><td style='text-align: center; word-wrap: break-word;'>使用辅助输入过载作为输入。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Aux Output Overload</td><td style='text-align: center; word-wrap: break-word;'>使用辅助输出过载作为输入。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID Output Overload</td><td style='text-align: center; word-wrap: break-word;'>使用 PID 输出过载作为输入。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>TU Output Value</td><td style='text-align: center; word-wrap: break-word;'>使用 TU 输出值作为输入。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Channel</td><td style='text-align: center; word-wrap: break-word;'>索引</td><td style='text-align: center; word-wrap: break-word;'>根据所选信号源选择通道。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Abs</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>取模拟输入信号的绝对值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>TC/BW Value</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>定义应用于模拟输入信号的低通滤波器的特性时间常数。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Value</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>显示经过低通滤波器滤波后的值。</td></tr><tr><td rowspan="5">Mode</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择用于定义输出信号的分析模式。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Above</td><td style='text-align: center; word-wrap: break-word;'>在信号高于阈值上限时启用。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Below</td><td style='text-align: center; word-wrap: break-word;'>在信号低于阈值下限时启用。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Outside</td><td style='text-align: center; word-wrap: break-word;'>在信号超出范围 [阈值下限, 阈值上限] 时启用。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Rising Edge</td><td style='text-align: center; word-wrap: break-word;'>在信号从低于阈值下限的位置上升到阈值上限时启用。阈值上限与阈值下限之差定义阈值滞后。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Falling Edge</td><td style='text-align: center; word-wrap: break-word;'>在信号从高于阈值上限的位置下降到阈值下限时启用。阈值上限与阈值下限之差定义阈值滞后。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Lower</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>用于生成输出的阈值下限。在 Rising Edge（上升沿）模式下，此参数定义滞后行为，只有当信号从高于阈值上限的位置下降到阈值下限时，输出状态才会复位。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Upper</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>用于生成输出的阈值上限。在 Falling Edge（下降沿）模式下，此参数定义滞后行为，只有当信号从低于阈值下限的位置上升到阈值上限时，输出状态才会复位。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>State</td><td style='text-align: center; word-wrap: break-word;'>低电平/高电平/正在切换</td><td style='text-align: center; word-wrap: break-word;'>在执行最短时间分析之前指示阈值单元的当前输出。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Enable</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>激活输出之前需要违反阈值要求的最短持续时间。此参数可用作毛刺滤波器。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Disable</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>禁用输出之前需要满足阈值要求的最短持续时间。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>State</td><td style='text-align: center; word-wrap: break-word;'>低电平/高电平/正在切换</td><td style='text-align: center; word-wrap: break-word;'>在执行最短时间分析之后指示阈值单元的当前输出。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Not</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>将输入信号取反。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>In</td><td style='text-align: center; word-wrap: break-word;'>索引</td><td style='text-align: center; word-wrap: break-word;'>选择要用作输入的阈值通道。</td></tr><tr><td rowspan="5">Op</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>应用于控件左侧和右侧信号的逻辑运算。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>none</td><td style='text-align: center; word-wrap: break-word;'>未选择任何逻辑运算。生成输出时未使用任何附加信号。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>AND</td><td style='text-align: center; word-wrap: break-word;'>使用逻辑与运算。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>OR</td><td style='text-align: center; word-wrap: break-word;'>使用逻辑或运算。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>XOR</td><td style='text-align: center; word-wrap: break-word;'>使用逻辑异或运算。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>State</td><td style='text-align: center; word-wrap: break-word;'>低电平/高电平/正在切换</td><td style='text-align: center; word-wrap: break-word;'>在执行逻辑组合之后指示阈值的当前输出。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Width</td><td style='text-align: center; word-wrap: break-word;'>数值</td><td style='text-align: center; word-wrap: break-word;'>为生成的输出信号选择最小脉冲宽度。短于此时的脉冲宽度将会被延长。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Hold</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>输出状态切换为激活状态后，便会无限期保持。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Inv</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>将输出信号更改为低电平有效。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>State</td><td style='text-align: center; word-wrap: break-word;'>低电平/高电平/正在切换</td><td style='text-align: center; word-wrap: break-word;'>最终输出状态。</td></tr></table>





### 4.20. MOD 选项卡

通过 MOD 选项卡可访问调幅和调频单元。该选项卡仅在已安装 MF-MOD AM/FM 调制选件的仪器上可用，参见 Device（设备）选项卡的 Information（信息）部分。

##### 注释

安装 MF-MOD AM/FM 调制选件需要先安装 MF-MD 多解调器选件。

#### 4.20.1. 特征

一 以相位相干模式加减振荡器频率及其倍数

一 控制 AM 和 FM 解调

一 控制 AM 和窄带 FM 生成

一 直接分析高阶载波频率和边带

#### 4.20.2. 描述

MOD 选项卡提供控制设置，以便以相位相干模式加减多个数字振荡器的频率。当该选项卡关闭或需要其他相同类型的选项卡时，单击以下图标即可打开该选项卡的新实例。

<div style="text-align: center;"><div style="text-align: center;">表 4.62. 应用图标和简要描述</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>MOD</td><td style='text-align: center; word-wrap: break-word;'>\downarrow</td><td style='text-align: center; word-wrap: break-word;'>以振荡器频率的线性组合启用调制/解调的控制面板。</td></tr></table>

MOD 选项卡（参见图 4.48）分为水平的水平部分，各有一个调制单元。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f0a757e7-d3c9-4345-9cc0-5abf71d108a7/markdown_2/imgs/img_in_image_box_216_955_760_1158.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A52Z%2F-1%2F%2F8af506375e8f011578320e26e629beeff42da8b122674601b6a77eae571efb23" alt="Image" width="45%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.48.LabOne UI: MOD 选项卡</div> </div>


调制单元旨在用于涉及多频率的实验。在许多这类实验中，能够通过关联频谱揭示一个主导中心频率（通常称为载波），以及一个或多个对称分布于载波周围的边带。典型的示例是调幅（AM）信号带一个载波和两个由AM调制频率分隔在载波两侧的边带。另一个示例是调频（FM）信号，载波的左右两侧可出现多个边带。AM和FM的边带相对幅值都取决于调制深度，这通常由调制指数来表示。

分析此类信号（尤其是当只有模拟仪器可用时）的经典方法是使用串联解调配置。这在本质上是锁相放大器的串行级联。第一个设备参考载波频率，输出同相分量。然后馈送到后续的锁相放大器，以提取不同的边带分量。此方案存在数个弊端：

参考载波调谐的第一个锁相放大器的正交分量必须通过调整参考相位连续归零。否则，信号强度的很大一部分会因分析而损失，这通常会导致信噪比 (SNR) 下降。

此方案在所需硬件资源方面的扩展性很差，尤其是在需要提取多个边带频率的情况下。

SNR 会因每次信号进出仪器（例如由于仪器输入噪声）而变小。多次重复此步骤会显著降低信号质量。

所有这些缺点都可通过生成振荡器频率的线性组合，并将这些组合用作解调器参考相位来妥善化解。MOD 单元链接到解调器 1、2 和 3。它可以利用多达 3 个振荡器，甚至可使用 ExtRef 或 PLL 来参考到外部源。图 4.49 简要展示了涉及的不同组件及其相互连接。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//f0a757e7-d3c9-4345-9cc0-5abf71d108a7/markdown_3/imgs/img_in_image_box_263_343_1048_629.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A54Z%2F-1%2F%2F76c27eed4df570563eabdc6e612b27be4661f0b9d56592237099e38f630c7848" alt="Image" width="65%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.49. 调制选件框图</div> </div>


用户可在用户界面的 Mode（模式）列方便地访问 AM 和 FM 预设。在 Manual（人工）模式下，可自由选择所有设置。

##### 注释

只要启用了 MOD 单元，Lock-in（锁相）选项卡中由该单元控制的所有设置都将设为只读。

除了信号分析，MF-MOD AM/FM 调制选件还可用于信号生成。Generation（生成）部分提供用于调整载波和边带幅值的所有必要控件。

##### 注释

FM 信号是由载波信号的相干叠加产生的，载波信号的两侧各有两个边带频率，其幅值相同，但相位相反。按照 Lock-in（锁相）选项卡中所示，使用负幅值实现相移。只要调制指数远低于 1，也就是可忽略高阶边带，那么使用这种方法生成的 FM 就近似于实际 FM。当调制指数为 1 时，实际 FM 在第二和更高阶边带提供超过 13% 的信号强度。

有关 AM 和 FM 信号分析及生成的更多详细信息，请参见 Zurich Instruments 网页。

#### 4.20.3. 功能元素

<div style="text-align: center;"><div style="text-align: center;">表 4.63.MOD 选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>SG Channels</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择 SG 通道来显示相应的振荡器频率集。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Frequency (Hz)</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>振荡器频率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Oscillator Select</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>选择用于生成的正弦信号的振荡器。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Harmonic</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>将振荡器的参考频率与该字段所定义的整数因子相乘。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Frequency (Hz)</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>所选振荡器的频率。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Phase Shift (deg)</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>设置正弦信号的相位。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>I Sin Amplitude</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>设置发送至数字混频器的I输入的正弦信号的幅值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>I Cos Amplitude</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>设置发送至数字混频器的I输入的余弦信号的幅值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>I Enable</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>启用数字混频器的I输入。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Q Sin Amplitude</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>设置发送至数字混频器的Q输入的正弦信号的幅值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Q Cos Amplitude</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>设置发送至数字混频器的Q输入的余弦信号的幅值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Q Enable</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>启用数字混频器的Q输入。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Run/Stop</td><td style='text-align: center; word-wrap: break-word;'>Run/Stop</td><td style='text-align: center; word-wrap: break-word;'>运行AWG定序器。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>定序器状态</td><td style='text-align: center; word-wrap: break-word;'>灰色/绿色/红色</td><td style='text-align: center; word-wrap: break-word;'>显示仪器上的定序器的状态。Off：就绪，未运行。绿色：运行中，不等待任何触发事件。黄色：运行中，等待触发事件。红色：未就绪（例如正在等待elf下载，无elf下载）。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Modulation Enable</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>启用AWG生成的波形的数字调制。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>AWG Output Amplitude</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>设置第一个AWG输出的幅值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>AWG Output Amplitude</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>设置第二个AWG输出的幅值。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Hold</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>即使在波形程序结束后，也要在输出端保留最后一个样本（常量）。建议仅对长度等于16的倍数的AWG波形使用该功能。对于其他长度的波形，AWG编译器会自动在末尾补上零。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>AWG Output Gain Amplitude</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>设置指定AWG通道的幅值比例因子。幅值是应用于数字信号的无量纲比例因子。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>AWG Output Gain Enable</td><td style='text-align: center; word-wrap: break-word;'>ON/OFF</td><td style='text-align: center; word-wrap: break-word;'>指示AWG信号（行）到数字混频器输入（列）的路径选择。</td></tr></table>





### 4.21. Multi Device Sync（多设备同步）选项卡

通过 Multi Device Sync（多设备同步）选项卡可对来自多个 MF 仪器的测量数据进行自动定时同步。所有 MF 仪器均提供此功能和选项卡。

#### 4.21.1. 特征

一 跨仪器自动定时同步

一 定期检查同步

一 可选仪器子组

一 状态显示

#### 4.21.2. 描述

Multi Device Sync（多设备同步）选项卡包括有关多个仪器上同步测量的控件和状态信息。当该选项卡关闭或需要其他相同类型的选项卡时，单击以下图标即可打开该选项卡的新实例。

<div style="text-align: center;"><div style="text-align: center;">表 4.64. 应用图标和简要描述</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>MDS</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>同步多个仪器。</td></tr></table>

图 4.50 所示的 Multi Device Sync（多设备同步）选项卡包括 Available Devices（可用设备）部分、Status（状态）部分以及一个布线图。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//a4ef9cd7-d5e3-4c07-b8d2-ce877157606d/markdown_0/imgs/img_in_image_box_221_813_1044_1092.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A23Z%2F-1%2F%2Fd320bbb39032da637e7e9a0c210f83d8ac56436abe9ef49295c66eae7109cc10" alt="Image" width="69%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.50.LabOne UI: Multi Device Sync（多设备同步）选项卡</div> </div>


多设备同步特性支持自动删除单独 MF 仪器的时钟偏移。这样就能够在第 4.6 节所述的选项卡中正确同步数据显示，便于分析记录的数据。因此，在要求实现亚微秒时间精度的多通道应用中，用户可从一开始就获得同步数据，而无需在后处理中人工测量和补偿时钟偏移。

实现自动同步的首要前提是所有仪器均连接到同一个 LabOne 数据服务器（参见第 1.6 节）。如第 1.5 节所述，这只有在单独电脑上运行 LabOne 软件时才可行。

为执行这些连接，请单击 Session Manager （参见第 4.15 节），打开 Device Connection（设备连接）对话框。在对话框中选择 Advanced（高级）视图，并在 Available Devices（可用设备）列表中单击相应条目旁的 Enable（启用）复选框。连接所有仪器后，在新打开的 Plotter（绘图仪）选项卡的树状选择器中，这些仪器均变为可选状态，供用户同步查看仪器中的数据，即使默认情况下这些数据尚未同步。为每个仪器打开新的 Web 服务器会话，即可并行访问多个仪器的设置。操作方法是：打开新的浏览器选项卡并分别连接到本地主机：8006 或 127.0.0.1:8006，然后双击 Available Devices（可用设备）列表中的相应仪器条目。将多个仪器连接到同一个数据服务器后，支持多个仪器的选项卡将显示设备选择器，如图 4.51 所示。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//a4ef9cd7-d5e3-4c07-b8d2-ce877157606d/markdown_1/imgs/img_in_image_box_216_110_479_163.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A24Z%2F-1%2F%2Fa1f637027f475f1e49bc0de62faaafcf23faee20692c57f8dc4d3f0187bf4b36" alt="Image" width="22%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.51.Device（设备）选项卡的设备选择器示例</div> </div>


实现自动同步的第二个先决条件是仪器布线正确，如图 4.52 所示。仪器应共享同一个 10 MHz 参考时钟，并通过 Ref/Trigger 连接器进行通信，以实现绝对定时同步。10 MHz 时钟信号以菊花链布局分布，且引导仪器的时钟 10 MHz 输出连接到下一个仪器的时钟 10 MHz 输入，以此类推。在所有以下仪器中，第 4.16 节所述的 Clock Source（时钟源）需要设为 Clk 10 MHz（时钟 10 MHz）而非 Internal（内部）。引导仪器的 Trigger Out 1（触发器输出 1）信号应分配到所有跟随仪器和引导仪器的 Trigger In 1（触发器输入 1）连接器。这种星形连接应使用 1/N 的功率分配器和等长电缆。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//a4ef9cd7-d5e3-4c07-b8d2-ce877157606d/markdown_1/imgs/img_in_image_box_253_462_1034_931.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A24Z%2F-1%2F%2F253f0cf09f58b2fd26c49b37423893406ce81beb030255fdc3bb8c66d9856716" alt="Image" width="65%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 4.52. 多个 MF 仪器自动同步的接线</div> </div>


正确接线和连接后，在 Multi Device Sync（多设备同步）选项卡的 Available Devices（可用设备）列表中勾选仪器的 Enable（启用）按钮，然后单击 Start/Stop Sync，即可开始自动同步。仪器的分配顺序（引导仪器、跟随仪器 1、跟随仪器 2…）可按单击 Enable（启用）按钮的顺序来确定。此分配顺序必须与接线一致。此顺序还

与在 AWG 序列程序中为仪器寻址相关。然后，右侧的 Message（消息）显示屏将报告进度，如果同步成功，Sync Status（同步状态）指示灯将变为绿色。这时，在 Plotter（绘图仪）中查看多个仪器的时间相关测量时将演示定时同步。

#### 4.21.3. 功能元素

<div style="text-align: center;"><div style="text-align: center;">表 4.65.Multi Device Sync（多设备同步）选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Start Sync</td><td style='text-align: center; word-wrap: break-word;'>Start/Stop Sync</td><td style='text-align: center; word-wrap: break-word;'>启动所选设备的自动同步。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Sync Status</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>指示该组内同步的状态。绿色：同步已成功执行。黄色：同步正在执行。红色：错误（见消息）。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Message</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>显示同步组的状态消息。</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">4.21 Multi Device Sync（多设备同步）选项卡</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Cabling</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>此图显示为进行设备同步设备所采用的连接方式。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Phase Synchronization</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>复位所有已同步设备上所有振荡器的相位。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Identify Device</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>使设备正面的 LED 灯闪烁</td></tr></table>

### 4.22. ZI Labs（ZI 实验室）选项卡

ZI Labs（ZI 实验室）选项卡包括由 ZI 开发团队添加的实验性 LabOne 功能。此处的设置通常与特殊应用相关，但尚未真正出现在其他 LabOne 选项卡中。此选项卡的内容必然会经常更改，对各项特性的说明超出了本用户手册的范围。单击下方图标，即可打开此选项卡的新实例。

<div style="text-align: center;"><div style="text-align: center;">表 4.66. 应用图标和简要描述</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>控件/工具</td><td style='text-align: center; word-wrap: break-word;'>选项/范围</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>ZI Labs</td><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>实验性设置及控件。</td></tr></table>

### 4.23. Upgrade（升级）选项卡

Upgrade（升级）选项卡作为信息源，提供所用仪器可升级的选件的相关信息。此选项卡无实际功能，仅为用户提供快速链接，以便查看有关升级选件的更多线上信息。

### 第 5 章.规格

##### 重要事项

除非另有说明，否则所有规格均仅适用于预热 30 分钟后的仪器。

##### 重要事项

规格参数的变更已明确列于本文档的修订历史中。

##### 重要事项

部分规格取决于所安装的选件。给定仪器上已安装的选件列于 LabOne 用户界面的 Device（设备）选项卡中。

### 5.1. 一般规格

<div style="text-align: center;"><div style="text-align: center;">表 5.1. 一般规格</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>参数</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>储存温度</td><td style='text-align: center; word-wrap: break-word;'>+5°C 到 +65°C</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>储存相对湿度</td><td style='text-align: center; word-wrap: break-word;'>&lt; 95%，无冷凝</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>工作环境</td><td style='text-align: center; word-wrap: break-word;'>IEC61010，室内位置，安装类别Ⅱ，污染等级2</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>工作海拔</td><td style='text-align: center; word-wrap: break-word;'>最高2000米</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>工作温度</td><td style='text-align: center; word-wrap: break-word;'>+5°C 到 +40°C</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>工作相对湿度</td><td style='text-align: center; word-wrap: break-word;'>&lt; 90%，无冷凝</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>规格温度</td><td style='text-align: center; word-wrap: break-word;'>+18°C 到 +28°C</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>功耗</td><td style='text-align: center; word-wrap: break-word;'>&lt; 40 W</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DC电源进线</td><td style='text-align: center; word-wrap: break-word;'>12 V、2 A 连接器：Switchcraft 760BK、ID 2.5 mm、OD 5.5 mm</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>电源AC线路</td><td style='text-align: center; word-wrap: break-word;'>100-240 V ( $ \pm $10%)，50/60 Hz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>线路电源保险丝</td><td style='text-align: center; word-wrap: break-word;'>250 V、2 A、高速、5 x 20 mm、F 2 A L 250 V</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>尺寸（含减震器）</td><td style='text-align: center; word-wrap: break-word;'>28.3 x 23.2 x 10.2 cm，11.1 x 9.1 x 4.0 英寸，按需安装机架</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>重量（含减震器）</td><td style='text-align: center; word-wrap: break-word;'>3.8 kg</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>建议校准间隔</td><td style='text-align: center; word-wrap: break-word;'>2 年（参见后面板标签）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>保修</td><td style='text-align: center; word-wrap: break-word;'>1 年，可延保</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">表 5.2. 解调器</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>参数</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>频率范围</td><td style='text-align: center; word-wrap: break-word;'>DC - 500 kHz DC - 5 MHz，需安装 MF-F5M 选件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>解调器数量</td><td style='text-align: center; word-wrap: break-word;'>1 个双相（X、Y、R、 $ \Theta $）4 个双相，需安装 MF-MD 选件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>解调器输入</td><td style='text-align: center; word-wrap: break-word;'>信号输入 (V/I)、辅助输入、辅助输出、触发器输入</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>滤波器时间常数</td><td style='text-align: center; word-wrap: break-word;'>336 ns - 83 s</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>滤波器带宽 (-3 dB)</td><td style='text-align: center; word-wrap: break-word;'>276  $ \mu $Hz - 206 kHz（4 阶滤波器）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>谐波</td><td style='text-align: center; word-wrap: break-word;'>1 - 1023</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>滤波器斜率</td><td style='text-align: center; word-wrap: break-word;'>6、12、18、24、30、36、42、48 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>附加滤波器</td><td style='text-align: center; word-wrap: break-word;'>Sinc 滤波器</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>相位分辨率</td><td style='text-align: center; word-wrap: break-word;'>10  $ \mu $deg</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>频率分辨率</td><td style='text-align: center; word-wrap: break-word;'>1  $ \mu $Hz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>辅助输出的输出采样率</td><td style='text-align: center; word-wrap: break-word;'>612 kSa/s（每个辅助输出），18 位， $ \pm 10 $ V</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>最高传输速率超过 1 GbE</td><td style='text-align: center; word-wrap: break-word;'>200 kSa/s（所有解调器），48 位全频</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>本地 USB 驱动程序的最高存储速率</td><td style='text-align: center; word-wrap: break-word;'>50 kSa/s（所有解调器），48 位全频</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>数据传输的触发器模式</td><td style='text-align: center; word-wrap: break-word;'>连续、边沿、门控</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">表 5.3. 参考频率</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>参数</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td rowspan="2">外部参考频率范围</td><td style='text-align: center; word-wrap: break-word;'>1 Hz 到 500 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>1 Hz - 5 MHz，需安装 MF-F5M 选件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>外部参考输入</td><td style='text-align: center; word-wrap: break-word;'>辅助输入、触发器输入、辅助输出、电流信号输入、电压信号输入</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>外部参考的锁定时间</td><td style='text-align: center; word-wrap: break-word;'>通常少于最大值（100 个周期，1.2 ms）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>外部参考的数量</td><td style='text-align: center; word-wrap: break-word;'>1；2，需安装 MF-MD 选件</td></tr><tr><td rowspan="2">内部参考频率范围</td><td style='text-align: center; word-wrap: break-word;'>0 - 500 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>0 - 5 MHz，需安装 MF-F5M 选件</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">表 5.4. 示波器</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>参数</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输入渠道</td><td style='text-align: center; word-wrap: break-word;'>信号输入（V、I）、辅助输入、辅助输出、触发器输入、触发器输出、信号输出、振荡器相位。解调器 R、Theta、X、Y，需安装 MF-DIG 选件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>示波器模式</td><td style='text-align: center; word-wrap: break-word;'>时域、频域 (FFT)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>数量显示通道</td><td style='text-align: center; word-wrap: break-word;'>1；2，需安装 MF-DIG 选件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>触发器通道</td><td style='text-align: center; word-wrap: break-word;'>信号输入（V、I）、辅助输入、辅助输出、触发器输入、触发器输出。解调器 R、Theta、X、Y，需安装 MF-DIG 选件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>触发器模式</td><td style='text-align: center; word-wrap: break-word;'>边沿</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>触发器滞后</td><td style='text-align: center; word-wrap: break-word;'>全输入范围</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>预触发</td><td style='text-align: center; word-wrap: break-word;'>全样本范围</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>采样率</td><td style='text-align: center; word-wrap: break-word;'>1.8 kSa/s 至 60 MSa/s</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>垂直分辨率</td><td style='text-align: center; word-wrap: break-word;'>16 位</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>单次触发的最大样本数量</td><td style='text-align: center; word-wrap: break-word;'>16 kSa；5 MSa，需安装 MF-DIG 选件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>最短保持时间</td><td style='text-align: center; word-wrap: break-word;'>1 ms</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>带宽限制模式，垂直分辨率提高</td><td style='text-align: center; word-wrap: break-word;'>通过平均来降采样；垂直分辨率最多提高至 24 位，需安装 MF-DIG 选件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>光标功能</td><td style='text-align: center; word-wrap: break-word;'>位置、面积、波、峰值、轨迹、直方图</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">表 5.5.频谱</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>参数</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>中心频率范围</td><td style='text-align: center; word-wrap: break-word;'>0 - 500 kHz0 - 5 MHz，需安装 MF-F5M 选件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>频谱模式</td><td style='text-align: center; word-wrap: break-word;'>FFT(X +iY)、FFT®、FFT(O)、FFT(f) 和 FFT((dO/dt)/2π)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>统计选件</td><td style='text-align: center; word-wrap: break-word;'>幅值、谱密度、功率</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>平均模式</td><td style='text-align: center; word-wrap: break-word;'>无，指数移动平均</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>单个频谱的最大样本数量</td><td style='text-align: center; word-wrap: break-word;'>8 kSa</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>最大量程</td><td style='text-align: center; word-wrap: break-word;'>58 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>窗函数</td><td style='text-align: center; word-wrap: break-word;'>Rectangular、Hann、Hamming、Blackman Harris</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>光标功能</td><td style='text-align: center; word-wrap: break-word;'>位置、面积、跟踪、波、峰值、柱状图</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">表 5.6. 参数扫描仪</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>参数</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>参数扫描仪参数</td><td style='text-align: center; word-wrap: break-word;'>振荡器频率、解调器相位、辅助偏移、信号输出偏移等</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>参数扫描范围</td><td style='text-align: center; word-wrap: break-word;'>满量程、线性和对数</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>参数扫描分辨率</td><td style='text-align: center; word-wrap: break-word;'>任意，由起始值/结束值和扫描点数量决定</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>显示参数</td><td style='text-align: center; word-wrap: break-word;'>解调器输出（X、Y、R、 $ \Theta $、f），辅助输入</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>显示选件</td><td style='text-align: center; word-wrap: break-word;'>单绘图、双绘图（例如波特图）、多迹线</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>统计选件</td><td style='text-align: center; word-wrap: break-word;'>幅值、谱密度、功率</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>预设测量模式</td><td style='text-align: center; word-wrap: break-word;'>参数扫描、噪声幅值测量、频率响应分析仪、3-Omega 参数扫描</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">表 5.7.MF-IA 阻抗分析仪选件</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>参数</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>频率范围</td><td style='text-align: center; word-wrap: break-word;'>DC - 500 kHz DC - 5 MHz，需安装 MF-F5M 选件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>基本精度</td><td style='text-align: center; word-wrap: break-word;'>0.05%（1 mHz 到 500 kHz）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>基本温度稳定性</td><td style='text-align: center; word-wrap: break-word;'>&lt; 200 ppm/K</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>测试信号电平</td><td style='text-align: center; word-wrap: break-word;'>0 - 2.1  $ V_{rms} $，带监控</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>带宽</td><td style='text-align: center; word-wrap: break-word;'>276 \mu Hz 到 206 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DC 偏置信号电平</td><td style='text-align: center; word-wrap: break-word;'>$ \pm 10 $ V（2 端子）； $ \pm 3 $ V（4 端子）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>补偿方法</td><td style='text-align: center; word-wrap: break-word;'>SO、SOL、LLL、SL、L、OL</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>阻抗值 Z：范围；基本精度</td><td style='text-align: center; word-wrap: break-word;'>1 m \Omega 到1 T \Omega；0.05%</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>导纳 Y：范围；基本精度</td><td style='text-align: center; word-wrap: break-word;'>1 pS 到1 kS；0.05%</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>电阻 Rs，Rp：范围；基本精度</td><td style='text-align: center; word-wrap: break-word;'>1 m \Omega 到10 G \Omega；最大（10 \mu  \Omega ，0.05%） $ ^{2} $</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>电容 Cs，Cp：范围；基本精度</td><td style='text-align: center; word-wrap: break-word;'>10 fF 到1 F；最大（10 fF，0.05%） $ ^{2} $</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>电感 Ls，Lp：范围；基本精度</td><td style='text-align: center; word-wrap: break-word;'>100 nH 到1 H；最大（10 nH，0.05%） $ ^{2} $</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DC 电阻 RDC：范围；基本精度</td><td style='text-align: center; word-wrap: break-word;'>1 m \Omega 到10 G \Omega；2%</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>电抗 X：范围；基本精度</td><td style='text-align: center; word-wrap: break-word;'>1 m \Omega 到10 G \Omega；0.05%</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>电导 G：范围；基本精度</td><td style='text-align: center; word-wrap: break-word;'>1 nS 到1 kS；最大（100 nS，0.05%）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>电纳 B：范围；基本精度</td><td style='text-align: center; word-wrap: break-word;'>1 nS 到1 kS；最大（100 nS，0.05%）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>损失系数 D：范围</td><td style='text-align: center; word-wrap: break-word;'>$ 10^{-4} $ 到  $ 10^{4} $</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Q 因子：范围</td><td style='text-align: center; word-wrap: break-word;'>$ 10^{-4} $ 到  $ 10^{4} $</td></tr></table>





 $ ^{2} $如果参数是电路表示的主导值，则精度有效。

<div style="text-align: center;"><div style="text-align: center;">表 5.8. 电压信号输入</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>参数</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>连接器</td><td style='text-align: center; word-wrap: break-word;'>前面板配有2个BNC连接器，单端或差分输出</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>屏蔽连接</td><td style='text-align: center; word-wrap: break-word;'>浮动或接地</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>最大浮动电压和地电压</td><td style='text-align: center; word-wrap: break-word;'>$ \pm 1 $ V</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输入阻抗</td><td style='text-align: center; word-wrap: break-word;'>50  $ \Omega $ 和 10 M $ \Omega $ 27 pF（范围  $ \geq $ 300 mV）；40 pF（范围  $ \leq $ 100 mV）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输入频率范围</td><td style='text-align: center; word-wrap: break-word;'>DC - 500 kHz；DC - 5 MHz，需安装 MF-F5M 选件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输入A/D转换</td><td style='text-align: center; word-wrap: break-word;'>16 位，60 MSa/s</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输入噪声幅值</td><td style='text-align: center; word-wrap: break-word;'>2.5 nV/ $ \sqrt{\text{Hz}} $（频率 &gt; 1 kHz），7 nV/ $ \sqrt{\text{Hz}} $（频率 = 10 Hz），40 nV/ $ \sqrt{\text{Hz}} $（频率 = 1 Hz），3.3 mV 输入范围；缺少输入上限</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输入噪声转角频率</td><td style='text-align: center; word-wrap: break-word;'>通常为 100 Hz（范围  $ \leq $ 10 mV）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输入偏置电流</td><td style='text-align: center; word-wrap: break-word;'>通常为  $ \pm 10 $ pA，最大  $ \pm 200 $ pA</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>满量程输入灵敏度（10 V 锁相放大器输出）</td><td style='text-align: center; word-wrap: break-word;'>1 nV - 3 V</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输入AC范围</td><td style='text-align: center; word-wrap: break-word;'>$ \pm 1 $ mV、 $ \pm $ mV、 $ \pm 10 $ mV、 $ \pm 30 $ mV、 $ \pm 100 $ mV、 $ \pm 300 $ mV、 $ \pm 1 $ V、 $ \pm 3 $ V</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>AC耦合截止频率</td><td style='text-align: center; word-wrap: break-word;'>1.6 Hz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>AC耦合最大DC偏移</td><td style='text-align: center; word-wrap: break-word;'>$ \pm 10 $ V</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输入DC范围</td><td style='text-align: center; word-wrap: break-word;'>$ \pm 1 $ mV、 $ \pm $ mV、 $ \pm 10 $ mV、 $ \pm 30 $ mV、 $ \pm 100 $ mV、 $ \pm 300 $ mV、 $ \pm 1 $ V、 $ \pm 3 $ V</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输入增益不精确度</td><td style='text-align: center; word-wrap: break-word;'>&lt; 1% (&lt; 2 MHz)；对于更高的频率，由模拟输入滤波器进行限制</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>模拟输入滤波器（抗混叠）</td><td style='text-align: center; word-wrap: break-word;'>5 MHz 时 1 dB 抑制，12 MHz 时 3 dB 抑制；三阶滚降</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输入幅值稳定性</td><td style='text-align: center; word-wrap: break-word;'>0.1%/°C</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输入偏移幅值</td><td style='text-align: center; word-wrap: break-word;'>&lt; 最大值（0.5 mV，范围的 1%）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>动态储备</td><td style='text-align: center; word-wrap: break-word;'>最高 120 dB</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>谐波失真</td><td style='text-align: center; word-wrap: break-word;'>80 dBc（频率  $ \leq $ 100 kHz），65 dBc（频率  $ \leq $ 5 MHz），载波幅值为 1 dBFS</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>相干输入</td><td style='text-align: center; word-wrap: break-word;'>&lt;-140 dB（频率  $ \leq $ 5 MHz，输入阻抗 = 50  $ \Omega $）；&lt;-180 dB（频率  $ \leq $ 100 kHz，输入阻抗 = 50  $ \Omega $）；</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">表 5.9. 电流输入</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>参数</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>连接器</td><td style='text-align: center; word-wrap: break-word;'>前面板 BNC，浮动/接地</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>屏蔽连接</td><td style='text-align: center; word-wrap: break-word;'>浮动或接地</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>最大浮动电压和地电压</td><td style='text-align: center; word-wrap: break-word;'>$ \pm 1 $ V</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输入阻抗</td><td style='text-align: center; word-wrap: break-word;'>参见表 5.10</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输入频率范围</td><td style='text-align: center; word-wrap: break-word;'>0 - 500 kHz
0 - 5 MHz，需安装 MF-F5M 选件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输入 A/D 转换</td><td style='text-align: center; word-wrap: break-word;'>16 位，60 MSa/s</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输入泄漏电流</td><td style='text-align: center; word-wrap: break-word;'>$ \pm 10 $ pA</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>满量程输入灵敏度（10 V 锁相放大器输出）</td><td style='text-align: center; word-wrap: break-word;'>10 fA 到 10 mA</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输入增益不精确度</td><td style='text-align: center; word-wrap: break-word;'>&lt; 1%（频率低于输入带宽的 10%）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输入偏移幅值</td><td style='text-align: center; word-wrap: break-word;'>范围的 1%</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输入偏移电压</td><td style='text-align: center; word-wrap: break-word;'>最大  $ \pm 2.2 $ mV；屏蔽电流输入 BNC 连接器</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>动态储备</td><td style='text-align: center; word-wrap: break-word;'>最高 120 dB</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>相干输入</td><td style='text-align: center; word-wrap: break-word;'>&lt; 90 G $ \Omega $（频率  $ \leq 5 $ MHz，输入范围为 100  $ \mu $A），&lt; 140 T $ \Omega $（频率  $ \leq 100 $ kHz，输入范围为 10 nA）</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">表 5.10. 电流信号输入：输入范围、跨阻抗增益、带宽、输入阻抗、噪声</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>电流输入范围</td><td style='text-align: center; word-wrap: break-word;'>跨阻抗增益</td><td style='text-align: center; word-wrap: break-word;'>带宽 $ (-3\ \text{dB}) $</td><td style='text-align: center; word-wrap: break-word;'>DC输入阻抗</td><td style='text-align: center; word-wrap: break-word;'>输入噪声</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>10 mA</td><td style='text-align: center; word-wrap: break-word;'>100 V/A</td><td style='text-align: center; word-wrap: break-word;'>5 MHz</td><td style='text-align: center; word-wrap: break-word;'>50 \Omega</td><td style='text-align: center; word-wrap: break-word;'>300 pA/ $ \sqrt{\text{Hz}} $ (100 kHz)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>1 mA $ ^{1} $</td><td style='text-align: center; word-wrap: break-word;'>1 kV/A</td><td style='text-align: center; word-wrap: break-word;'>5 MHz</td><td style='text-align: center; word-wrap: break-word;'>50 \Omega</td><td style='text-align: center; word-wrap: break-word;'>200 pA/ $ \sqrt{\text{Hz}} $ (100 kHz)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>100 \mu A</td><td style='text-align: center; word-wrap: break-word;'>10 kV/A</td><td style='text-align: center; word-wrap: break-word;'>5 MHz</td><td style='text-align: center; word-wrap: break-word;'>60 \Omega</td><td style='text-align: center; word-wrap: break-word;'>3.5 pA/ $ \sqrt{\text{Hz}} $ (100 kHz)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>10 \mu A $ ^{1} $</td><td style='text-align: center; word-wrap: break-word;'>100 kV/A</td><td style='text-align: center; word-wrap: break-word;'>5 MHz</td><td style='text-align: center; word-wrap: break-word;'>60 \Omega</td><td style='text-align: center; word-wrap: break-word;'>2.5 pA/ $ \sqrt{\text{Hz}} $ (100 kHz)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>1 \mu A</td><td style='text-align: center; word-wrap: break-word;'>1 MV/A</td><td style='text-align: center; word-wrap: break-word;'>450 kHz</td><td style='text-align: center; word-wrap: break-word;'>1 k \Omega</td><td style='text-align: center; word-wrap: break-word;'>200 fA/ $ \sqrt{\text{Hz}} $ (1 kHz)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>100 nA $ ^{1} $</td><td style='text-align: center; word-wrap: break-word;'>10 MV/A</td><td style='text-align: center; word-wrap: break-word;'>450 kHz</td><td style='text-align: center; word-wrap: break-word;'>1 k \Omega</td><td style='text-align: center; word-wrap: break-word;'>150 fA/ $ \sqrt{\text{Hz}} $ (1 kHz)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>10 nA</td><td style='text-align: center; word-wrap: break-word;'>100 MV/A</td><td style='text-align: center; word-wrap: break-word;'>2 kHz</td><td style='text-align: center; word-wrap: break-word;'>160 k \Omega</td><td style='text-align: center; word-wrap: break-word;'>20 fA/ $ \sqrt{\text{Hz}} $ (100 kHz)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>1 nA $ ^{1} $</td><td style='text-align: center; word-wrap: break-word;'>1 GV/A</td><td style='text-align: center; word-wrap: break-word;'>2 kHz</td><td style='text-align: center; word-wrap: break-word;'>160 k \Omega</td><td style='text-align: center; word-wrap: break-word;'>15 fA/ $ \sqrt{\text{Hz}} $ (100 kHz)</td></tr></table>

 $ ^{1} $此范围仅适用于序列号为 MF-DEV3200 及以上的 MF 仪器。

<div style="text-align: center;"><div style="text-align: center;">表 5.11. 信号输出</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>参数</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>连接器</td><td style='text-align: center; word-wrap: break-word;'>前面板配有2个BNC连接器，单端和差分输出</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输出阻抗</td><td style='text-align: center; word-wrap: break-word;'>50 \Omega</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>参数</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输出频率范围</td><td style='text-align: center; word-wrap: break-word;'>DC - 500 kHzDC - 5 MHz（装有MF-F5M选件）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输出频率分辨率</td><td style='text-align: center; word-wrap: break-word;'>1 \mu Hz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输出相位范围</td><td style='text-align: center; word-wrap: break-word;'>\pm 180°</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输出相位分辨率</td><td style='text-align: center; word-wrap: break-word;'>10 \mu deg</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>差分输出</td><td style='text-align: center; word-wrap: break-word;'>正弦波偏移180°</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输出D/A转换</td><td style='text-align: center; word-wrap: break-word;'>16位，60 MSa/s</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输出幅值范围</td><td style='text-align: center; word-wrap: break-word;'>\pm 10 mV、\pm 100 mV、\pm 1 V、\pm 10 V（单端输出到高阻抗）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输出DC偏移范围</td><td style='text-align: center; word-wrap: break-word;'>\pm 10 mV到\pm 10 V，等于设定输出幅值范围</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输出功率</td><td style='text-align: center; word-wrap: break-word;'>每个BNC 24 dBm（\pm 10 V，250 mW）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输出增益不精确度</td><td style='text-align: center; word-wrap: break-word;'>&lt; 1%（100 kHz，全输出范围）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>最大输出驱动电流</td><td style='text-align: center; word-wrap: break-word;'>100 mA</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输出偏移幅值</td><td style='text-align: center; word-wrap: break-word;'>\pm 1 mV或范围的1%，取较大值</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>谐波失真</td><td style='text-align: center; word-wrap: break-word;'>85 dBc（f &lt; 100 kHz），60 dBc（f &lt; 5 MHz）；输出范围≤1V；80 dBc（f &lt; 100 kHz），50 dBc（f &lt; 5 MHz）；输出范围=10 V，载波幅值=1 dBFS</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>模拟加法器</td><td style='text-align: center; word-wrap: break-word;'>辅助输入1可加到信号输出，\pm 10 V，DC-2 MHz</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">表 5.12. 信号输出：电压噪声，范围</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>输出范围</td><td style='text-align: center; word-wrap: break-word;'>输出噪声密度（高负载阻抗设置）</td><td style='text-align: center; word-wrap: break-word;'>12 MHz 带宽下的 RMS 输出噪声</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>10 mV</td><td style='text-align: center; word-wrap: break-word;'>43 nV/ $ \sqrt{\text{Hz}} $</td><td style='text-align: center; word-wrap: break-word;'>145  $ \mu $Vrms</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>100 mV</td><td style='text-align: center; word-wrap: break-word;'>43 nV/ $ \sqrt{\text{Hz}} $</td><td style='text-align: center; word-wrap: break-word;'>145  $ \mu $Vrms</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>1 V</td><td style='text-align: center; word-wrap: break-word;'>48 nV/ $ \sqrt{\text{Hz}} $</td><td style='text-align: center; word-wrap: break-word;'>161  $ \mu $Vrms</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>10 V</td><td style='text-align: center; word-wrap: break-word;'>104 nV/ $ \sqrt{\text{Hz}} $</td><td style='text-align: center; word-wrap: break-word;'>310  $ \mu $Vrms</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">表 5.13. 辅助输入</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>参数</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>连接器</td><td style='text-align: center; word-wrap: break-word;'>前面板配有2个BNC连接器</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>A/D转换器</td><td style='text-align: center; word-wrap: break-word;'>16位，15 MSa/s</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>A/D模拟带宽</td><td style='text-align: center; word-wrap: break-word;'>5 MHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输入阻抗</td><td style='text-align: center; word-wrap: break-word;'>1 M $ \Omega $</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>幅值</td><td style='text-align: center; word-wrap: break-word;'>$ \pm $10 V</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输入噪声幅值</td><td style='text-align: center; word-wrap: break-word;'>430 nV/ $ \sqrt{Hz} $；频率＞100 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>分辨率</td><td style='text-align: center; word-wrap: break-word;'>0.335 mV</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">表 5.14. 辅助输出</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>参数</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>连接器</td><td style='text-align: center; word-wrap: break-word;'>前面板配有4个BNC连接器</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>D/A转换器</td><td style='text-align: center; word-wrap: break-word;'>18位，612 kSa/s</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>D/A模拟带宽</td><td style='text-align: center; word-wrap: break-word;'>200 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输出阻抗</td><td style='text-align: center; word-wrap: break-word;'>50 \Omega</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>幅值</td><td style='text-align: center; word-wrap: break-word;'>\pm 10 V</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>分辨率</td><td style='text-align: center; word-wrap: break-word;'>&lt; 85 \mu V</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>驱动电流</td><td style='text-align: center; word-wrap: break-word;'>20 mA</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>噪声密度</td><td style='text-align: center; word-wrap: break-word;'>210 nV/ $ \sqrt{\text{Hz}} $ 高阻抗负载；频率 &gt; 1 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>RMS噪声</td><td style='text-align: center; word-wrap: break-word;'>90 \mu V $ _{\text{rms}} $ 高阻抗负载；测量带宽 12 MHz</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">表 5.15. 触发器输入</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>参数</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>连接器</td><td style='text-align: center; word-wrap: break-word;'>后面板配有2个BNC连接器</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>触发输入阻抗</td><td style='text-align: center; word-wrap: break-word;'>1 kΩ</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>频率范围外部参考</td><td style='text-align: center; word-wrap: break-word;'>1 Hz到500 kHz；1 Hz-5 MHz，需安装MF-F5M选件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>触发器幅值范围</td><td style='text-align: center; word-wrap: break-word;'>$ \pm5 $ V</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>最小脉冲宽度</td><td style='text-align: center; word-wrap: break-word;'>35 ns</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>触发电平</td><td style='text-align: center; word-wrap: break-word;'>$ \pm5 $ V，3.66 mV分辨率</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>触发器滞后</td><td style='text-align: center; word-wrap: break-word;'>&lt; 20 mV</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">表 5.16. 触发器输出</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>参数</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>连接器</td><td style='text-align: center; word-wrap: break-word;'>后面板配有2个BNC连接器</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>触发器输出阻抗</td><td style='text-align: center; word-wrap: break-word;'>50  $ \Omega $</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>频率范围外部参考</td><td style='text-align: center; word-wrap: break-word;'>1  $ \mu $Hz到500 kHz；1  $ \mu $Hz-5 MHz，需安装MF-F5M选件</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>触发器幅值</td><td style='text-align: center; word-wrap: break-word;'>5 V</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">表 5.17.10 MHz 时钟同步</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>参数</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>连接器</td><td style='text-align: center; word-wrap: break-word;'>后面板配有2个BNC连接器、10 MHz时钟输入和输出</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>10 MHz输入、阻抗</td><td style='text-align: center; word-wrap: break-word;'>50 Ω</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>10 MHz输入，频率范围</td><td style='text-align: center; word-wrap: break-word;'>9.98 - 10.02 MHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>10 MHz输入，幅值范围</td><td style='text-align: center; word-wrap: break-word;'>200 mV到3 V</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>10 MHz输出，阻抗</td><td style='text-align: center; word-wrap: break-word;'>50 Ω</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>10 MHz输出，幅值</td><td style='text-align: center; word-wrap: break-word;'>通常50 Ω为1 Vpp，正弦信号</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">表 5.18. 内部频率参考</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>参数</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>类型</td><td style='text-align: center; word-wrap: break-word;'>TCXO</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>初始精度</td><td style='text-align: center; word-wrap: break-word;'>＜±1.5 ppm</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>长期精度/老化</td><td style='text-align: center; word-wrap: break-word;'>第一年＜±1 ppm</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>短期稳定性 (0.1 s)</td><td style='text-align: center; word-wrap: break-word;'>＜2·10^{-10}</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>温度系数</td><td style='text-align: center; word-wrap: break-word;'>0.05 ppm/℃ (23℃)</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>相位噪声 (1 kHz)</td><td style='text-align: center; word-wrap: break-word;'>-140 dBc/Hz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>相位噪声 (10 kHz)</td><td style='text-align: center; word-wrap: break-word;'>-150 dBc/Hz</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">表 5.19. 连接性和其他性能</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>参数</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>主机连接</td><td style='text-align: center; word-wrap: break-word;'>LAN, 1 GbE; USB 2.0, 480 Mbit/s</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>内置驱动器数据存储容量</td><td style='text-align: center; word-wrap: break-word;'>4.5 GB</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>USB 主机</td><td style='text-align: center; word-wrap: break-word;'>后面板配 2 个连接器用于大量存储或 WLAN 模块</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DIO, 数字 I/O</td><td style='text-align: center; word-wrap: break-word;'>4 x 8 位，常规数字输入/输出端口，3.3 V TTL VHDCI 68 引脚母头连接器</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">表 5.20. 最大额定值</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>参数</td><td style='text-align: center; word-wrap: break-word;'>下限</td><td style='text-align: center; word-wrap: break-word;'>上限</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>损坏阈值电流信号输入I</td><td style='text-align: center; word-wrap: break-word;'>-5 V</td><td style='text-align: center; word-wrap: break-word;'>+5 V</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>损坏阈值电压输入+V/-V差异</td><td style='text-align: center; word-wrap: break-word;'>-12 V</td><td style='text-align: center; word-wrap: break-word;'>+12 V</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>损坏阈值信号输出+V/-V</td><td style='text-align: center; word-wrap: break-word;'>-12 V</td><td style='text-align: center; word-wrap: break-word;'>+12 V</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>损坏阈值辅助输入1,2</td><td style='text-align: center; word-wrap: break-word;'>-12 V</td><td style='text-align: center; word-wrap: break-word;'>+12 V</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>损坏阈值辅助输出1,2,3,4</td><td style='text-align: center; word-wrap: break-word;'>-12 V</td><td style='text-align: center; word-wrap: break-word;'>+12 V</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>损坏阈值时钟10 MHz输入/输出</td><td style='text-align: center; word-wrap: break-word;'>-5 V</td><td style='text-align: center; word-wrap: break-word;'>+5 V</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>损坏阈值触发器输出1,2</td><td style='text-align: center; word-wrap: break-word;'>-1 V</td><td style='text-align: center; word-wrap: break-word;'>+6 V</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>损坏阈值触发器输入1,2</td><td style='text-align: center; word-wrap: break-word;'>-8 V</td><td style='text-align: center; word-wrap: break-word;'>+8 V</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>损坏阈值DIO 32位</td><td style='text-align: center; word-wrap: break-word;'>-1 V</td><td style='text-align: center; word-wrap: break-word;'>+6 V</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>损坏阈值DC输入</td><td style='text-align: center; word-wrap: break-word;'>0 V</td><td style='text-align: center; word-wrap: break-word;'>26 V</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">表 5.21. LabOne UI 要求</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>参数</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>操作系统</td><td style='text-align: center; word-wrap: break-word;'>基于 Web 浏览器的任何操作系统</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输入设备</td><td style='text-align: center; word-wrap: break-word;'>触摸屏、键盘、鼠标</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>CPU</td><td style='text-align: center; word-wrap: break-word;'>2 个以上内核，硬件加速绘制浏览器</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>浏览器</td><td style='text-align: center; word-wrap: break-word;'>Edge、Firefox、Chrome、Safari、Opera</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>连接性</td><td style='text-align: center; word-wrap: break-word;'>1 GbE，100 MbE，USB 2.0</td></tr></table>

<div style="text-align: center;"><div style="text-align: center;">表 5.22. LabOne API 要求</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>参数</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>操作系统</td><td style='text-align: center; word-wrap: break-word;'>Windows 10、8.1、7，采用 x86-64 架构</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>参数</td><td style='text-align: center; word-wrap: break-word;'>描述</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>macOS 10.11 及以上版本，采用 x86-64 和 ARMv8 架构\nGNU/Linux（Ubuntu 14.04 及以上版本，CentOS 7 及以上版本，Debian 8 及以上版本），采用 x86-64 和 ARMv8 架构</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>CPU</td><td style='text-align: center; word-wrap: break-word;'>采用 x86-64 架构（Intel，AMD），ARMv8 架构（例如 Raspberry Pi 4、Apple M1）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>RAM</td><td style='text-align: center; word-wrap: break-word;'>4 GB+</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>连接性</td><td style='text-align: center; word-wrap: break-word;'>1 GbE，100 MbE，USB 2.0</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>支持的语言</td><td style='text-align: center; word-wrap: break-word;'>LabVIEW、Python、MATLAB、.NET、C/C++</td></tr></table>

DIO 端口是 VHDCI 68 引脚连接器，在 SCSI-3 规格的 SPI-3 文档中引入。这款母头连接器需要配用 32 mm 的宽版公头连接器。32 位 DIO 端口可照字节配置作为输入或输出。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//c3510619-cc7c-4440-82e9-4b4d19e937fa/markdown_2/imgs/img_in_image_box_223_518_1076_889.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A09Z%2F-1%2F%2Fb1f00a111cbfcab8ff286526a287447cc9b8fcdba477fa7384673250b2e3aca5" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 5.1.DIO HD 68 引脚连接器</div> </div>


<div style="text-align: center;"><div style="text-align: center;">表 5.23.DIO 引脚分配</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>引脚</td><td style='text-align: center; word-wrap: break-word;'>名称</td><td style='text-align: center; word-wrap: break-word;'>描述</td><td style='text-align: center; word-wrap: break-word;'>范围规格</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>68</td><td style='text-align: center; word-wrap: break-word;'>CLKI</td><td style='text-align: center; word-wrap: break-word;'>时钟输入，用于锁存数字输入端口的信号，也可以使用外部采样时钟从输出端口检索数字信号</td><td style='text-align: center; word-wrap: break-word;'>3.3 V LVCMOS/TTL</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>67</td><td style='text-align: center; word-wrap: break-word;'>DOL</td><td style='text-align: center; word-wrap: break-word;'>DIO 输出锁存，60 MHz 时钟信号，数字输出同步到此信号的下降沿</td><td style='text-align: center; word-wrap: break-word;'>3.3 V LVCMOS/TTL</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>66-59</td><td style='text-align: center; word-wrap: break-word;'>DI[31:24]</td><td style='text-align: center; word-wrap: break-word;'>数字输入或输出（由用户设定）</td><td style='text-align: center; word-wrap: break-word;'>3.3 V LVCMOS/TTL</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>58-51</td><td style='text-align: center; word-wrap: break-word;'>DIO[23:16]</td><td style='text-align: center; word-wrap: break-word;'>数字输入或输出（由用户设定）</td><td style='text-align: center; word-wrap: break-word;'>3.3 V LVCMOS/TTL</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>50-43</td><td style='text-align: center; word-wrap: break-word;'>DIO[15:8]</td><td style='text-align: center; word-wrap: break-word;'>数字输入或输出（由用户设定）</td><td style='text-align: center; word-wrap: break-word;'>3.3 V LVCMOS/TTL</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>42-35</td><td style='text-align: center; word-wrap: break-word;'>DIO[7:0]</td><td style='text-align: center; word-wrap: break-word;'>数字输入或输出（由用户设定）</td><td style='text-align: center; word-wrap: break-word;'>3.3 V LVCMOS/TTL</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>34-30</td><td style='text-align: center; word-wrap: break-word;'>-</td><td style='text-align: center; word-wrap: break-word;'>不连接，仅供内部使用</td><td style='text-align: center; word-wrap: break-word;'>-</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>29-1</td><td style='text-align: center; word-wrap: break-word;'>GND</td><td style='text-align: center; word-wrap: break-word;'>数字接地</td><td style='text-align: center; word-wrap: break-word;'>-</td></tr></table>

下图所示为 DIO 输入/输出的架构。32 位 DIO 端口可照字节通过驱动信号配置为输入或输出。数字输出数据与内部时钟（运行速度为 60 MHz）的下降沿同步锁存。内部采样时钟可在 DIO 连接器的 DOL 引脚上获得。数字输入数据可通过内部时钟或 CLKI 引脚提供的外部时钟进行采样。从输入时钟中抽取十分之一，以该抽取版本对输入数据进行采样。抽取单元对时钟计数进行抽取，然后锁存输入数据。默认抽取率为 3e6，对应数字输入采样率（每秒 20 个样本）。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//c3510619-cc7c-4440-82e9-4b4d19e937fa/markdown_3/imgs/img_in_image_box_173_133_1035_1367.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A11Z%2F-1%2F%2Ff96c834f145dfb65ad2768fe29462e4c2ee54d420aa51591bc9acb83955b6af5" alt="Image" width="72%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 5.2. DIO 输入/输出架构</div> </div>


### 5.2. 性能图

输入噪声幅值取决于多个参数，尤其是频率以及输入范围的设置。对于较小的输入范围，输入噪声较低，建议范围选取较小的值，尤其是噪声测量。图 5.3所示为 DC 耦合时电压输入的噪声密度。AC 耦合时，只要频率高于 AC 截止频率，输入噪声就相同（参见表 5.8）。噪声与输入阻抗设置（例如 50 Ω 或 10 MΩ）无关。对于最小输入范围，1/f 噪声的转角频率在 100 Hz 的范围内，本底白噪声通常为 2.5 nV/√Hz。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//c3510619-cc7c-4440-82e9-4b4d19e937fa/markdown_4/imgs/img_in_chart_box_241_400_1058_1050.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A11Z%2F-1%2F%2F139ea2ed74cf2fb7416cb914e8cc0c5aa40ccfa16bbe96447e9412cf32b7979a" alt="Image" width="68%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 5.3.MFLI 电压输入电压噪声密度</div> </div>


关于输入电压噪声和 AC 耦合的说明。当在 MFLI 信号输入中使用 AC 耦合时，输入电压噪声在低频时将提高。例如，如上图所示，在 10 Hz 频率下，10 mV 输入范围的输入电压噪声约为 10 nV/√Hz。当切换 AC 耦合时，噪声将提高到约 75 nV/√Hz。原因在于，10nF AC 耦合电容器在 10 Hz 频率下的阻抗为 1.6 MΩ。再加上 MFLI 输入放大器的 10 MΩ 输入偏置电阻，噪声密度就会增加。为解决这一问题，需为信号输入使用 DC 耦合。如果必须使用 AC 耦合，可接入外部大型电容器。

图 5.4 所示为电流输入的噪声密度。较小输入范围的测量频率范围受限于这些范围的带宽，如表 5.10 所示。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//cadfb07f-aaf7-4642-9cad-8104ac9e4261/markdown_0/imgs/img_in_chart_box_244_141_1060_820.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A02Z%2F-1%2F%2F899c665d22ce936c3ac38e2cb6e3e5316c6df99f1033a2c0e50bc859e1e00b56" alt="Image" width="68%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 5.4.MFLI 电流输入电流噪声密度</div> </div>


UHF 相位噪声所示为在信号输出时测量的 SSB 相位噪声。在此测量中，信号输出连接到相位噪声分析仪，输出幅值设为 5 V。在 5 MHz 和 10 kHz 偏移下测得的相位噪声约为 -153 dBc/Hz。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//cadfb07f-aaf7-4642-9cad-8104ac9e4261/markdown_1/imgs/img_in_chart_box_217_135_1070_804.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A03Z%2F-1%2F%2Fc517e7788f37054f6be160496ac50a428dc02bd1be2f2e3cb26cf1c982978c9f" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 5.5.MFLI 相位噪声</div> </div>


图 5.6 所示为 50 Ω 电压输出下的噪声密度。在高阻抗负载条件下，图中的电压噪声水平需要加倍。输出噪声是在无信号和 0 V 偏移的条件下测量的。对于 10 mV 和 100 mV 范围，100 kHz 至 50 Ω 条件下的电压噪声与 14.5 nV/vHz 的平带噪声水平基本相同。在高阻抗负载条件下，该值约为 29 nV/√Hz。对于 10 V 范围，在 100 kHz 条件下的最大噪声为 34.5 nV/√Hz。1/f 噪声的转角频率范围是 10-20 kHz。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//cadfb07f-aaf7-4642-9cad-8104ac9e4261/markdown_2/imgs/img_in_chart_box_218_126_1073_792.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A03Z%2F-1%2F%2Fc335c6cee896c76fd791029f68dcd2b18d6e5a2a29c6023210e9e879c7d5225c" alt="Image" width="71%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 5.6.MFLI 信号输出电压噪声密度</div> </div>


### 第 6 章.信号处理基础信息

本章提供有关多个锁相放大器原理的见解，这些原理不一定与 Zurich Instruments 的特定仪器相关。自 20 世纪 30 年代首个阀基锁相放大器诞生以来，虽然其物理学特性没有改变，但是实施和性能都有了很大发展。过去的几十年里出现了许多优秀的锁相放大器初级读物，其中一些初级读物是以模拟仪器为对象撰写的，因此现在似乎已经过时了。本节并不意在取代任何已有的初级读物，而希望以数字锁相放大器为重点来予以补充。第一小节介绍的是锁相放大的原理，接着是离散时间滤波器的功能。之后，我们将讨论满量程灵敏度的定义，这个规格参数对模拟锁相放大器特别重要，但对数字仪器的影响没那么大。我们还将继续介绍 Sinc 滤波，尤其是在低频锁相测量中的功能和使用。最后一节将主要介绍选带傅里叶变换功能。随着锁相放大器的创新，选带傅里叶变换可围绕锁相操作频率提供快速、高分辨率的频谱分析。

### 6.1. 锁相检测的原理

锁相解调技术旨在通过比较信号与参考信号来测量具有频率 ( $ \omega_s = 2\pi f_s $) 的周期信号的幅值  $ A_s $ 和相位  $ \theta $。该技术也称为相敏检测。通过随时间进行平均化处理，信号的信噪比 (SNR) 可提高多个数量级，从而能够以高精度检测非常小的信号，使锁相放大器成为信号恢复的常用工具。无论是信号恢复还是相敏检测，都可通过窄带通滤波分离出期望信号，从而降低测量信号中噪声的影响。

图 6.1 所示为基本的测量装置： $ V_r $ 参考信号馈送到被测设备。该参考信号由具有衰减、放大、相移和失真的一般非线性设备修改，得到信号  $ V_s = A_s \cos(\omega_s t + \theta_s) $ 外加谐波分量。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//cadfb07f-aaf7-4642-9cad-8104ac9e4261/markdown_4/imgs/img_in_image_box_223_467_950_626.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A05Z%2F-1%2F%2Fc0861534d53ada5cc7355cdc1717780bb356185ac331a721606ccaa677c9a928" alt="Image" width="61%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 6.1. 包含锁相放大器的基本测量装置</div> </div>


出于实践方面的原因，大多数锁相放大器均使用混频器和低通滤波器来实施带通滤波器功能（参见图 6.2）：混频器将期望信号转移到基带（理想情况下转换到 DC），而低通滤波器则切断所有不需要的高频。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//cadfb07f-aaf7-4642-9cad-8104ac9e4261/markdown_4/imgs/img_in_image_box_234_845_931_1017.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A30%3A05Z%2F-1%2F%2Fe4e9a1a170c2c871d7e2e483bd94d8749476e5152d453ee2387242563a57566f" alt="Image" width="58%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 6.2. 锁相放大器执行的混频和低通滤波功能</div> </div>


输入信号  $ V_{\mathrm{s}}(t) $ 乘以参考信号  $ V_{r}(t)=\sqrt{2}e^{-i\omega_{r}t} $，其中  $ \omega_{r}=2\pi f_{r} $ 是解调频率，以 i 为虚部。这是构成正交序列解调组件的正弦和余弦信号（相移 90°）的复数表示方法，能够测量期望信号的幅值和相位。原则上可以将期望信号乘以任何频率，得出外差运算。但是锁相放大器的目标是移动信号，使其尽可能靠近 DC，因此会选择相似的参考频率和信号频率。文献中将这称为零差检测、同步检测或零中频直接转换。

相乘后得出信号

 $$ V_{s}(t)\cdot V_{r}(t)=V_{s}(t\cdot\sqrt{2}e^{-i\omega_{r}t}=\frac{A_{s}}{\sqrt{2}}e^{i[(\omega_{s}-\omega_{r})t+\theta]}+\frac{A_{s}}{\sqrt{2}}e^{-i[(\omega_{s}+\omega_{r})t+\theta]} $$ 

这包括一个慢速分量（频率为  $ \omega_{s} - \omega_{r} $）和一个快速分量（频率为  $ \omega_{s} + \omega_{r} $）

已解调信号使用无限冲击响应 (IIR) RC 滤波器进行低通滤波，以符号  $ \langle\cdot\rangle $ 表示。滤波器的频率响应  $ F(\omega) $ 将允许低频  $ F(\omega_s - \omega_r) $ 通过，同时显著衰减高频  $ F(\omega_s + \omega_r) $。另一种方法是将低通滤波器作为平均器。

 $$ X+i Y=\left\langle V_{s}(t)\cdot\sqrt{2}e^{-i\omega_{r}t}\right\rangle\approx F(\omega_{s}-\omega_{r})\frac{A_{s}}{\sqrt{2}}e^{i[(\omega_{s}-\omega_{r})t+\theta]} $$ 

低通滤波器处理后得到已解调信号  $ X + iY $，其中 X 是实部，Y 是复平面上描绘的信号的虚部。这些分量也称为同相和正交分量。X 和 Y 到幅值 R 的转换以及  $ V_s(t) $ 的相位  $ \theta $ 信息可用三角函数运算来得出。

有趣的是，测量信号的值对应于信号的 RMS 值，也就是  $ R = A_s / \sqrt{2} $。

当辅助输出信号范围为  $ -10 \, V $ 到  $ +10 \, V $ 时，大部分锁相放大器输出编码值  $ (X, Y) $ 和  $ (R, \theta) $。

#### 6.1.1. 锁相放大器应用

锁相放大器应用范围非常广泛。在某些情况下，目标是测量具有良好信噪比的信号，以至于即使使用较大的滤波器设置也可以测得该信号。这种情况可以称为相敏检测。在另一些应用中，信号非常弱以致被噪声盖住，必须使用非常窄的滤波器进行测量。这种情况下，可以使用锁相放大器来恢复信号。还有一种情况是，在极高频率（GHz 或 THz）上调制的信号无法采用标准方法测量，因此混频到适合锁相放大器的测量频带的较低频率。

例如，测量完全淹没在 1/f 噪声、电源线噪声和缓慢漂移中的平稳或缓慢变化的微弱信号。为此，将微弱信号调制到较高频率，远离这些噪声源。此类信号可快速地混频回来，并使用锁相放大器在基带中进行测量。图 6.3 所示即为此过程。许多光学应用都采用斩波器、电光调制器或声光调制器进行上混。这种方法的优点是，能够在噪声相对较小的光谱区测量所需信号，并且比直接低通滤波DC信号要更加高效。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//b0d00e64-04ee-4cf4-b677-e0a4493fb3cd/markdown_0/imgs/img_in_image_box_236_845_1026_1336.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A06Z%2F-1%2F%2Ffc7627750d6d10ddd2ad2c20cf0d5f9261b214bf61b95d8a5c549bd4d09cab68" alt="Image" width="66%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 6.3. 含噪声的 DC 信号的锁相测量</div> </div>


### 6.2. 信号带宽

信号带宽 (BW) 理论上对应信号中期望的最高频率分量。但在实际信号中，带宽通常由截止频率来量化。在这个频率下，系统的传递函数相对于 DC 显示 3 dB 的衰减（带宽 = f_{cut-off} = f_{3dB}）；也就是说，f_{3dB} 下的信号功率是 DC 下信号功率的一半。带宽就等于截止频率，用于信号的动态行为或不同信号的分离。例如快速变化的幅值，或者 PLL 或图像应用中的相位值，或者频率间隔很小的信号需要分离。

噪声等效功率带宽（NEPBW）不同于信号带宽，但也是非常有用的数值。该单位通常用于噪声测量：在这种情况下，用户关注的是通过低通滤波器滤波的总功率，等于图 6.4 中实曲线下方的面积。出于实际原因，用户会定义一个理想矩形滤波器，假设噪声呈现平谱（白噪声）密度，让等量的功率通过。该矩形滤波器的传输 1 从 DC 传输到 fNEPBW。图 6.4 中橙色和蓝色区域的面积在线性标度中完全相等。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//b0d00e64-04ee-4cf4-b677-e0a4493fb3cd/markdown_1/imgs/img_in_chart_box_226_483_578_659.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A07Z%2F-1%2F%2F058d96b2f1ebf4f48c7a23ce14ef4abc48fd53784c3509291476334dc8d51f90" alt="Image" width="29%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 6.4. 信号带宽和噪声等效功率带宽</div> </div>


可以在 fcut-off 和 fNEPBW 之间建立仅取决于滤波器斜率（或滚降）的简单关系。由于滤波器斜率实际上取决于为滤波器设定的时间常数 (TC)，因此也可以建立与时间常数的关系。可以很直观得看出，滤波器阶数越高，fcut-off 就越接近 fNEPBW。

时间常数是一个参数，用于在时域中解析滤波器响应，并且与达到最终值定义的百分比所需的时间相关。低通滤波器的时间常数与带宽的关系公式为

 $$ TC=\frac{FO}{2\pi f_{cut-off}} $$ 

其中 FO 是上述取决于滤波器斜率的因子。该因子和不同滤波器参数之间的其他实用的转换因子都可参见下表。

<div style="text-align: center;"><div style="text-align: center;">表 6.1. 带宽定义中的转换因子汇总</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>滤波器阶数</td><td style='text-align: center; word-wrap: break-word;'>滤波器滚降</td><td style='text-align: center; word-wrap: break-word;'>FO</td><td style='text-align: center; word-wrap: break-word;'>fcut-off</td><td style='text-align: center; word-wrap: break-word;'>fNEPBW</td><td style='text-align: center; word-wrap: break-word;'>fNEPBW / fcut-off</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>1 阶</td><td style='text-align: center; word-wrap: break-word;'>6 dB/oct</td><td style='text-align: center; word-wrap: break-word;'>1.0000</td><td style='text-align: center; word-wrap: break-word;'>0.1592 / TC</td><td style='text-align: center; word-wrap: break-word;'>0.2500 / TC</td><td style='text-align: center; word-wrap: break-word;'>1.5708</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>2 阶</td><td style='text-align: center; word-wrap: break-word;'>12 dB/oct</td><td style='text-align: center; word-wrap: break-word;'>0.6436</td><td style='text-align: center; word-wrap: break-word;'>0.1024 / TC</td><td style='text-align: center; word-wrap: break-word;'>0.1250 / TC</td><td style='text-align: center; word-wrap: break-word;'>1.2203</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>3 阶</td><td style='text-align: center; word-wrap: break-word;'>18 dB/oct</td><td style='text-align: center; word-wrap: break-word;'>0.5098</td><td style='text-align: center; word-wrap: break-word;'>0.0811 / TC</td><td style='text-align: center; word-wrap: break-word;'>0.0937 / TC</td><td style='text-align: center; word-wrap: break-word;'>1.1554</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>4 阶</td><td style='text-align: center; word-wrap: break-word;'>24 dB/oct</td><td style='text-align: center; word-wrap: break-word;'>0.4350</td><td style='text-align: center; word-wrap: break-word;'>0.0692 / TC</td><td style='text-align: center; word-wrap: break-word;'>0.0781 / TC</td><td style='text-align: center; word-wrap: break-word;'>1.1285</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>5 阶</td><td style='text-align: center; word-wrap: break-word;'>30 dB/oct</td><td style='text-align: center; word-wrap: break-word;'>0.3856</td><td style='text-align: center; word-wrap: break-word;'>0.0614 / TC</td><td style='text-align: center; word-wrap: break-word;'>0.0684 / TC</td><td style='text-align: center; word-wrap: break-word;'>1.1138</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>6 阶</td><td style='text-align: center; word-wrap: break-word;'>36 dB/oct</td><td style='text-align: center; word-wrap: break-word;'>0.3499</td><td style='text-align: center; word-wrap: break-word;'>0.0557 / TC</td><td style='text-align: center; word-wrap: break-word;'>0.0615 / TC</td><td style='text-align: center; word-wrap: break-word;'>1.1046</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>7 阶</td><td style='text-align: center; word-wrap: break-word;'>42 dB/oct</td><td style='text-align: center; word-wrap: break-word;'>0.3226</td><td style='text-align: center; word-wrap: break-word;'>0.0513 / TC</td><td style='text-align: center; word-wrap: break-word;'>0.0564 / TC</td><td style='text-align: center; word-wrap: break-word;'>1.0983</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>8 阶</td><td style='text-align: center; word-wrap: break-word;'>48 dB/oct</td><td style='text-align: center; word-wrap: break-word;'>0.3008</td><td style='text-align: center; word-wrap: break-word;'>0.0479 / TC</td><td style='text-align: center; word-wrap: break-word;'>0.0524 / TC</td><td style='text-align: center; word-wrap: break-word;'>1.0937</td></tr></table>

### 6.3. 离散时间滤波器

#### 6.3.1. 离散时间 RC 滤波器

实施数字低通滤波器的方法很多。一种常见滤波器类型是指数运行均值滤波器。这款滤波器的各项特性都非常接近模拟电阻器-电容器 RC 滤波器，因此有时被称为离散时间 RC 滤波器。指数运行均值滤波器的唯一可调参数就是  $ TC = \tau_N $ 时间常数。它运算的输入信号  $ X_{in}[n,] $ 由离散时间  $ nT_s, (n+1)T_s, (n+2)T_s $ 等定义，并以采样时间  $ T_s $ 为间隔。它的输出  $ X_{out}[n, T_s] $ 可使用以下递推公式计算得出，

 $$ X_{o u t}[n,T_{s}]=e^{-T_{s}/\tau_{n}}X_{o u t}[n-1,T_{s}]+(1-e^{-T_{s}/\tau_{N}})X_{i n}[n,T_{s}] $$ 

该滤波器在频域的响应可以用以下公式近似表示

 $$ H_{1}(\omega)=\frac{1}{1+i\cdot\omega\cdot\tau_{n}} $$ 

指数滤波器是一阶滤波器。通过级联多个滤波器，即可轻松获得更高阶的滤波器。例如，通过一个接一个地链接 4 个具有相同时间常数  $ TC = \tau_n $ 的滤波器，使一个滤波级的输出为下一个滤波级的输入，即可获得 4 阶滤波器。这种级联滤波器的传递函数就是单个滤波级的传递函数的乘积。对于 N 阶滤波器，我们就有

 $$ H_{n}(\omega)=\frac{1}{(1+i\cdot\omega\cdot\tau_{n})^{n}} $$ 

滤波器的衰减和相移都可通过此公式计算得出。也就是说，滤波器衰减由绝对值的平方  $ |H_n(\omega)|^2 $ 得出。滤波器的传输相位由复自变数  $ arg[H_n(\omega)] $ 得出。

#### 6.3.2. 滤波器稳定时间

低通滤波器在解调器之后，会导致测量信号的延迟，具体取决于滤波器阶数和时间常数  $ T_C = \tau_n $。信号发生变化后，锁相输出需要一段时间才能达到正确的测量值。图 6.5 所示为级联滤波器对阶跃输入信号的响应。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//b0d00e64-04ee-4cf4-b677-e0a4493fb3cd/markdown_3/imgs/img_in_chart_box_230_140_846_601.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A09Z%2F-1%2F%2Fbb45c79736bf82e9964a41ca806f317d6af7c1cc19e714f99b73cda3f238c4f9" alt="Image" width="51%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 6.5.RC 低通滤波器的时域阶跃响应</div> </div>


有关稳定时间的更多定量信息，请参见表 6.2。此表包括 MFLI 锁相放大器可用的所有滤波器阶数的稳定时间（单位为滤波器时间常数  $ \tau_{n} $）。这些数值表示滤波后的解调器信号达到最终值的 5%、95% 和 99% 所需的时间。这有助于从定量角度正确选择滤波器参数（例如在涉及参数扫描的测量中）。

<div style="text-align: center;"><div style="text-align: center;">表 6.2. 滤波器上升时间汇总</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>滤波器阶数</td><td colspan="3">时间设为</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>1阶</td><td style='text-align: center; word-wrap: break-word;'>0.025·TC</td><td style='text-align: center; word-wrap: break-word;'>3.0·TC</td><td style='text-align: center; word-wrap: break-word;'>4.6·TC</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>2阶</td><td style='text-align: center; word-wrap: break-word;'>0.36·TC</td><td style='text-align: center; word-wrap: break-word;'>4.7·TC</td><td style='text-align: center; word-wrap: break-word;'>6.6·TC</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>3阶</td><td style='text-align: center; word-wrap: break-word;'>0.82·TC</td><td style='text-align: center; word-wrap: break-word;'>6.3·TC</td><td style='text-align: center; word-wrap: break-word;'>8.4·TC</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>4阶</td><td style='text-align: center; word-wrap: break-word;'>1.4·TC</td><td style='text-align: center; word-wrap: break-word;'>7.8·TC</td><td style='text-align: center; word-wrap: break-word;'>10·TC</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>5阶</td><td style='text-align: center; word-wrap: break-word;'>2.0·TC</td><td style='text-align: center; word-wrap: break-word;'>9.2·TC</td><td style='text-align: center; word-wrap: break-word;'>12·TC</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>6阶</td><td style='text-align: center; word-wrap: break-word;'>2.6·TC</td><td style='text-align: center; word-wrap: break-word;'>11·TC</td><td style='text-align: center; word-wrap: break-word;'>12·TC</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>7阶</td><td style='text-align: center; word-wrap: break-word;'>3.3·TC</td><td style='text-align: center; word-wrap: break-word;'>12·TC</td><td style='text-align: center; word-wrap: break-word;'>15·TC</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>8阶</td><td style='text-align: center; word-wrap: break-word;'>4.0·TC</td><td style='text-align: center; word-wrap: break-word;'>13·TC</td><td style='text-align: center; word-wrap: break-word;'>16·TC</td></tr></table>

### 6.4. 满量程灵敏度

锁相放大器的灵敏度是已解调正弦输入信号的 RMS 值，产生满量程模拟输出。习惯上 X、Y 或 R 分量会映射到 10 V 满量程模拟输出。在这种情况下，锁相放大器从输入到输出的总增益由输入和输出放大器级组成。许多锁相放大器指定的灵敏度在 1 nV 至 1 V 之间。也就是说，仪器允许将 1 nV 至 1 V 之间的输入信号放大至 10 V 满量程输出。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//b0d00e64-04ee-4cf4-b677-e0a4493fb3cd/markdown_4/imgs/img_in_image_box_224_319_988_557.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A31%3A10Z%2F-1%2F%2Fecde3fd222f892348529a520431c780eb902530fbf9de52202fb1dab8b1ba233" alt="Image" width="64%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 6.6. 从信号输入到信号输出的灵敏度</div> </div>


模拟锁相放大器的灵敏度很好理解，就是仪器（特别是输入放大器和输出放大器）的输入和输出之间的模拟放大级之和。

数字锁相放大器的灵敏度则不那么容易理解。模数转换器 (ADC) 以固定的输入范围（例如 1 V）运行，因此需要可变增益放大器将输入信号放大到 ADC 给定的范围。该可变增益放大器必须在模拟域，其能力决定了仪器的最小输入范围。一个实用的模拟输入放大器能够放大 1000 倍，因此 1 V 除以 1000 就得到仪器的最小输入范围。

该输入范围是给定范围设置允许的最大信号幅值。该信号在内部以合适的因子（例如 1000 (1 mV)）放大，从而在 ADC 中产生全摆幅信号。该范围之外的信号会因为 ADC 饱和而失真，测量结果也变得无效。因此，信号不得超出范围设置。

但是，输入范围与灵敏度不一样。在数字锁相放大器中，灵敏度仅取决于输出放大器——这是一个全数字信号处理单元，执行解调器输出与比例因子的数乘。然后，该单元的数字输出被馈送到固定范围为 10 V 的输出数模转换器 (DAC)。这个比例因子可以根据模拟锁相放大器已知的灵敏度进行修改。对于数字放大而言，较大比例因子和较高灵敏度的成本相对较低。

数字锁相放大器有趣的一点是输入分辨率和灵敏度之间的关系。由于 ADC 以有限分辨率（例如 14 位）运行，因此可检测和数字化的最小信号（例如 1 mV）要除以 ADC 的分辨率。以 14 位为例，可以数字化的最低电平为 122 nV。如何在不使用 21 位模数转换器的情况下达到 1 nV 灵敏度？零噪声的世界是不存在的。相反，正是因为有了噪声和当前的数字技术，才能实现甚至低于 1 nV 的灵敏度。

大多数宽带噪声源（包括输入放大器）均可视为高斯噪声源。高斯噪声均匀分布在信号中，因此产生均匀分布的干扰。噪声经锁相放大器滤波后可达到不影响测量的水平。但是，在与信号的相互作用时，噪声确实会对测量产生影响。ADC的输入等于噪声和信号幅值的总和。较大噪声上的信号幅值，即使是非常小的信号（不超过1 nV），也能不时切换最低有效位。产生的数字信号在信号频率上带有一个分量，可被锁相放大器检测到。

生物学上也有类似的例子。人眼视杆细胞允许人类在光线很暗的条件下看见东西。人眼视杆细胞可以达到低至单光子的灵敏度。这种灵敏度的实现方式是在低光条件下对细胞进行某种预充电，使其对触发细胞启动脉冲的单光子敏感。在环境光更多的条件下，视杆细胞则不太敏感，需要更多光子来启动。

总之，在数字锁相放大器中，满量程灵敏度仅取决于数字输出放大器的比例因子能力。由于比例可以任意大，1 nV 最小满量程灵敏度是完全可以实现的。此外，数字锁相放大器利用输入噪声来大幅提高灵敏度，而不影响测量的精度。

### 6.5. 正弦滤波

如第 6.1 节所述，理想锁相放大器中的解调信号在 DC 上具有一个信号分量，并在两倍的解调频率上具有一个寄生分量。两倍的解调频率上的寄生分量（称为 2ω 分量）可通过常规低通滤波来有效去除。通过选择带宽小、滚降更快的滤波器，可轻松将 2ω 分量衰减至少 100 dB。问题出现在较低的解调频率上，因为这迫使用户选择较长的积分时间（例如，当解调频率为 20 Hz 时，积分时间 > 60 ms），才能实现同水平的 2ω 衰减。

在实践中，锁相放大器将利用解调频率来调制信号输入的 DC 偏移和非线性，产生解调频率的信号（称为  $ \omega $ 分量）。该分量也可在高于 1 kHz 的频率下通过常规低通滤波器有效去除。

在较低的解调频率下，特别是在解调频率接近滤波器带宽时的应用中，ω 和 2ω 分量均会影响测量结果。正弦滤波能够实现 ω 和 2ω 分量的强衰减。从技术上讲，正弦滤波器是一种梳状滤波器，换级触点为解调频率的整数倍数（ω、2ω、3ω 等），能以约 80 dB 的抑制因子去除 ω 分量。2ω 分量可以全部去除（例如 80 dB），也可以少量去除（例如 5 dB），具体取决于输入信号。这种变化与正弦滤波器的性能无关，而是取决于输入信号的带宽。

<div style="text-align: center;"><div style="text-align: center;">低频解调（无正弦滤波）</div> </div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//6dd93ad6-b436-4c5a-98b9-fb74dcd33255/markdown_0/imgs/img_in_image_box_230_577_810_787.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A28Z%2F-1%2F%2F72d1730dd64c4e4d051ce5b0c4a33ecd496549ece7fa631c4f99ea60fe520d7e" alt="Image" width="48%" /></div>


<div style="text-align: center;"><div style="text-align: center;">低频解调（有正弦滤波）</div> </div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//6dd93ad6-b436-4c5a-98b9-fb74dcd33255/markdown_0/imgs/img_in_image_box_229_820_809_1030.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A28Z%2F-1%2F%2Fd9ff72497a928faf1df58c56350b250a9574048322a1e9effa26ea5eead8e032" alt="Image" width="48%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 6.7. 正弦滤波的效果</div> </div>


<div style="text-align: center;"><div style="text-align: center;">表 6.3. 解调信号的假像</div> </div>




<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>输入信号</td><td style='text-align: center; word-wrap: break-word;'>低通滤波器处理前的解调结果</td><td style='text-align: center; word-wrap: break-word;'>结果</td></tr><tr><td rowspan="2">信号具有 \omega 分量</td><td style='text-align: center; word-wrap: break-word;'>DC 分量</td><td style='text-align: center; word-wrap: break-word;'>幅值和相位信息（期望信号）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>2 $ \omega $ 分量</td><td style='text-align: center; word-wrap: break-word;'>不需要的分量（可通过正弦滤波器额外进行衰减）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DC 偏移</td><td style='text-align: center; word-wrap: break-word;'>$ \omega $ 分量</td><td style='text-align: center; word-wrap: break-word;'>不需要的分量（可通过正弦滤波器额外进行衰减）</td></tr></table>

可以使用 MFLI 锁相放大器的频谱分析仪工具来观察正弦滤波器的效果。例如，假设有一个幅值为 0.1 V 的 30 Hz 信号，该信号使用 100 Hz 的滤波器带宽和 8 阶滤波器进行解调。信号中还增加了 0.1 V 的偏移，这样就得到一个很大的  $ \omega $ 分量。

图 6.8 所示为已禁用正弦滤波器的频谱，图 6.9 所示为已启用正弦滤波器的频谱。对比二图，可清楚地看到正弦选件如何将  $ \omega $ 和  $ 2\omega $ 分量衰减了约 100 dB。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//6dd93ad6-b436-4c5a-98b9-fb74dcd33255/markdown_1/imgs/img_in_chart_box_215_109_1058_557.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A29Z%2F-1%2F%2F791ad1525af81dec7cece167bab8443f9d3d6a85dff4ae6289b970fe011a5147" alt="Image" width="70%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 6.8. 已解调 30 Hz 信号的频谱（未启用正弦滤波器）</div> </div>


<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//6dd93ad6-b436-4c5a-98b9-fb74dcd33255/markdown_1/imgs/img_in_chart_box_221_623_1062_1072.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A29Z%2F-1%2F%2F8c1b49a10c2fafb589c6f7fe0727a70a3c37ae7923c68c6b1f0867cb8f85ab01" alt="Image" width="70%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 6.9. 已解调 30 Hz 信号的频谱（已启用正弦滤波器）</div> </div>


频率 (Hz)

##### 注释

为将数字滤波器的换级触点设为  $ \omega $ 和  $ 2\omega $，滤波器采样率必须根据信号频率精确调整。由于这在技术上并不可行，因此只对产生的信号频率进行微小的调整。

### 6.6. 选带傅里叶变换

选带傅里叶变换这一概念允许用户通过放大频谱的窄频带部分来分析特定频率附近的输入信号频谱。具体方法是对解调的同相和正交（X 和 Y）分量进行傅里叶变换，更准确地说，是对复量 X+iY 进行傅里叶变换，其中 i 是虚数单位。在 LabOne 用户界面中，这一功能位于 Spectrum（频谱）选项卡。

在一般的傅里叶变换中，采样率决定频率范围，总采集时间决定频率分辨率。如果要同时具有大范围和高分辨率，则需要在高采样率下进行长时间采集。这意味着需要采集、存储和处理大量数据，只为保留一小部分频谱，其余大部分都将丢弃。在选带傅里叶变换中，使用锁相解调来降低信号频率，使用户能够以更低的采样率和采样数量来实现同样的频率分辨率。通常，为在 1 MHz 的频率下实现 1 Hz 的频率分辨率，傅里叶变换需要收集和处理大约 10° 个点，而选带傅里叶变换只需要处理 10³ 个点。（当然，高速率采样是在解调阶段通过锁相来完成的，因此选带傅里叶变换仍需要隐式依赖于快速 ADC）。

 $$ \begin{array}{l} 为说明其原因以及这一测量工具能给用户带来的优势 , 此处必须提醒用户 , 在输入信号 \\V_{s}(t)=A_{s}c o d(\omega_{s}t+\tau)\qquad 解 \quad 调 \quad 结 \quad 束 \quad 时 \quad,\quad 输 \quad 出 \quad 信 \quad 号 \quad 为 \\X+iY=F(\omega_{s}-\omega_{r})(A_{s}/\sqrt{2})e^{i[(\omega_{s}-\omega_{r})t\tau]}~, 其中 F(\omega) 是滤波器的频率响应。\end{array} $$ 

由于解调信号在频率  $ \omega_s - \omega_r $ 上只有一个分量，因此其功率频谱（傅里叶变换模平方）在  $ \omega_s - \omega_r $ 达到峰值  $ (|A_s|^2 / 2) \cdot |F(\omega_r - \omega_s|^2) $：指示在滤波器  $ F(\omega) $ 设定的解调带宽内输入信号在频率接近  $ \omega_r $ 时的频谱功率分布。

注意：

区分正负频率的功能只有在对 X+iY 进行傅里叶变换时才起作用。如果以 X 为例，其功率频谱的正负频率将相等。实函数 g(t) 的傅里叶变换 G(ω) 存在对称关系 G(-ω)=G*(ω)，并且两个峰值相同，均出现在 ±|ω_s-ω_r|。

一 可以将功率频谱除以  $ |F(\omega)|^2 $ 来提取输入信号的幅值，但这种运算受数值精度的限制。该运算在 LabOne 中实施，由 Filter Compensation（滤波器补偿）按钮激活：启用 Filter Compensation（滤波器补偿）后，背景噪声显示为白色；如果不启用该功能，则滤波器滚降的影响会变得明显。

输入信号包含单个频率分量的情况可泛化到多个频率的情况。在这种情况下，功率频谱将显示滤波器传递函数加权的所有频率分量，如果启用了 Filter Compensation（滤波器补偿）后，功率频谱将进行归一化处理。

对于离散时间信号处理，当高于采样率 ω 的信号频率未得到充分抑制时，应小心出现混叠。需要牢记的是，ω 是用户可设置的读出速率，而不是 MFLI 输入的 60 MSa/s 采样率。由于离散时间傅里叶变换的延伸范围是 -ω/2 到 +ω/2，用户必须确保在 ±ω/2 时滤波器提供所需的衰减：可通过提高采样率或解算以测量更小的频谱（即更小的滤波器带宽）来实现。

与此类似的是连续的情况，其采集时间决定了最大频率分辨率（ $ 2\pi / T $，如果 T 是采集时间），可通过增加记录的数据点的数量来提高选带傅里叶变换的分辨率。如果以采样率  $ \omega $ 收集了 N 个数据点，则离散傅里叶变换的频率分辨率为  $ \omega / N $。

### 第 7 章.设备节点树

本章包含 MFLI 仪器上可用的设置和测量数据的参考文献。虽然第 4 章也从 LabOne 用户界面可用功能的角度介绍了许多这些设置，但本章旨在从设备层面进行介绍，并提供按层级整理的设备功能综合列表。

由于这些设置和数据流可使用 LabOne API（应用程序编程接口）来写入和读取，因此本章尤其适用于希望通过 LabVIEW、Python、MATLAB、.NET 或 C 语言以编程方式执行测量的用户。

请参见：

第 7.1 节介绍仪器的设置和测量数据在数据服务器的“节点树”中的层级组织。

第 7.2 节提供按节点树分支整理的 MFLI 仪器上可用设置和测量数据的参考列表。

### 7.1. 引言

本节概述仪器的配置和输出在数据服务器中的组织方式。

与仪器进行的所有通信都是通过与仪器连接的数据服务器程序发生的（参见 LabOne 软件架构获取 LabOne 软件组件的概述）。尽管仪器的设置本地存储在设备上，但数据服务器的任务是确保其保持当前设置的值，并使这些设置（以及任何订阅的数据）可用于所有当前客户端。客户端可以是 LabOne 用户界面，也可以是用户使用某个 LabOne API（例如 Python）执行的自有程序。

仪器的设置和数据由数据服务器以类似文件系统的层级结构来组织，该结构称为节点树。当仪器连接到数据服务器时，其设备 ID 就变为数据服务器节点树中最顶端的分支。仪器的各项功能作为顶端设备分支下面的分支，各种仪器设置都作为这些分支的树叶。

例如，仪器的设备 ID 为“dev2006”，其辅助输出在节点树的分支位置为：

/DEV2006/AUXOUTS/

“AUXOUTS”分支下依次是每个辅助输出通道的分支。

/DEV2006/AUXOUTS/0/

/DEV2006/AUXOUTS/1/

/DEV2006/AUXOUTS/2/

/DEV2006/AUXOUTS/3/

辅助输出和其他通道在仪器面板和用户界面上使用以 1 为第一位的索引方式进行标记，但数据服务器的节点树使用的是以 0 为第一位的索引方式。辅助输出的单个设置（和数据）均作为相应通道的分支下的树叶：

/DEV2006/AUXOUTS/0/DEMODSELECT

/DEV2006/AUXOUTS/0/LIMITLOWER

/DEV2006/AUXOUTS/0/LIMITUPPER

 $$ /DEV2006/AUXOUTS/0/OUTPUTSELECT $$ 

/DEV2006/AUXOUTS/0/PREOFFSET

/DEV2006/AUXOUTS/0/SCALE

/DEV2006/AUXOUTS/0/VALUE

以上都是节点树中的单个节点路径；最低一级的节点代表单个仪器设置或数据流。相关仪器特定用户手册的“参考节点文档”部分基于每个节点，对节点是仪器设置还是数据流，以及它包含或提供哪种类型的数据进行了明确的定义和记录。有关不同属性和类型的详细信息，参见第7.1.1节。

对于仪器设置，数据服务器客户端通过向数据服务器指定适当的路径和值为（路径，值）对来修改节点的值。当在 LabOne 用户界面中更改仪器的设置后，更改后的节点的路径和值显示在窗口底部的状态栏中。关于这一点的详细信息见第 7.1.2 节。

##### 模块参数

LabOne 的核心模块（例如参数扫描仪）也使用类似的树状结构来组织其参数。但请注意，模块节点不会显示在数据服务器的节点树中；这些节点位于在 LabOne 客户端中创建的模块实例本地，且不在客户端之间同步。

#### 7.1.1. 节点属性和数据类型

一个节点可具有一个或多个以下属性：

读取可从节点读取数据。

写入 可向节点写入数据。

设置 节点具有对应于仪器配置的写入属性。这些节点中的数据将保存到 LabOne XML 设置文件中，并从这些文件加载。

流传输 节点具有读取属性，通常以用户配置的速率提供仪器数据。该数据通常是更复杂的数据类型，例如解调器数据作为 ZIDemodSample 数据返回。《编程手册》的“仪器通信”一章中提供了完整的流传输节点列表。这些节点的可用性取决于设备类别（例如MF）和设备上安装的选件组。

节点上可包含以下类型的数据：

整数 整数数据。

双双精度浮点数据。

字符串

字符串阵列。

枚举（整数）整数数据，但是节点仅允许部分数值。

复合数据类型

例如 ZIDemodSample。这些自定义数据类型的结构中，字段包含仪器输出、时间戳和其他相关仪器设置，例如解调器振荡器频率。有关自定义数据类型的文档参见

#### 7.1.2. 探索节点树

##### LabOne 用户界面

要了解哪个节点负责特定的仪器设置，比较方便的方法之一是在 LabOne 用户界面底部查看 Command Log（命令日志）历史记录。状态栏中的命令会在每次更改配置后更新。图 7.1 所示为修改辅助输出 1 的偏移值后等效 Matlab 命令的显示内容。LabOne UI 的命令历史记录的格式可在 Config（配置）选项卡中进行配置（可选格式包括 Matlab、Python 和 .NET）。当前 UI 会话中生成的整个历史记录都可通过单击 Show Log（显示日志）按钮来查看。

<div style="text-align: center;"><img src="https://pplines-online.bj.bcebos.com/deploy/official/paddleocr/pp-ocr-vl-15//fe6e08ac-8847-4a5f-b697-39f9a8c50157/markdown_0/imgs/img_in_image_box_215_767_1087_964.jpg?authorization=bce-auth-v1%2FALTAKDN8mY5KlNI7zaRpLmOqrw%2F2026-05-15T10%3A29%3A44Z%2F-1%2F%2Fa8d9924fb6acdeeb45b29244dc5b8c2bd0f457c79c80b7c6fa845a69095dabf1" alt="Image" width="73%" /></div>


<div style="text-align: center;"><div style="text-align: center;">图 7.1. 在 LabOne 用户界面中修改设备配置后，状态栏会通过 LabOne 编程界面显示等效命令来执行相同配置。LabOne 编程界面会提供用于修改辅助输出 1 的偏移值的 Matlab 代码。单击 Show Log（显示日志）按钮后，整个配置历史记录都会显示在新的浏览器选项卡中。</div> </div>


##### LabOne 编程界面

使用 listNodes 命令（Matlab、Python、.NET）或 ziAPIListNodes() 函数（C API）可从 API 客户端的数据服务器请求（特定分支下的）节点列表。有关使用 listNodes 命令的更多帮助，请参见各 API 的命令参考。为获取从仪器高速提供数据的所有节点（即“流传输节点”）的列表，可向 listNodes 提供 streamingonly 标志。有关数据流传输和流传输节点的更多信息，参见《LabOne 编程手册》。

第 7.2 节提供的有关节点的详细说明也可通过在 LabOne Matlab 或 Python 编程界面中使用“help”命令直接访问。“help”命令在 Python 和 Matlab 中分别为 daq.help(path) 和 ziDAQ('help', path)。该命令返回有关仪器节点的描述，包括访问属性、数据类型、单位和可用选件。“help”命令还处理通配符，以返回与路径匹配的所有节点的详细描述。以下为相关示例。

daq = zhinst.ziPython.ziDAQServer('localhost', 8004, 6)
daq.help('/dev2006/auxouts/0/offset')
# Out:
# /DEV2006/AUXOUTS/0/OFFSET#
# Add the specified offset voltage to the signal after scaling.Auxiliary Output
# Value = (Signal+Preoffset)*Scale + Offset
# Properties: Read, Write, Setting

Type: Double

Unit: V

#### 7.1.3. 数据服务器节点

数据服务器在节点树的顶端 /ZI/ 分支下有可用的节点。这些节点提供客户端连接的数据服务器的版本和状态信息。例如，以下节点：

/ZI/ABOUT/VERSION

/ZI/ABOUT/REVISION

为包含数据服务器的发行版本和修订信息的只读节点。/ZI/DEVICES/ 下的节点列出了数据服务器已连接、可发现且可见的设备。

以下节点：

/ZI/CONFIG/OPEN

/ZI/CONFIG/PORT

为设置节点，可用于配置数据服务器从哪个端口监听传入客户端连接，以及它是否可以接受来自本地主机以外的主机上的客户端的连接。

对程序员尤其有用的节点是：

/ZI/DEBUG/LOGPATH - 数据服务器日志在电脑文件系统中的位置，

一 /ZI/DEBUG/LEVEL - 数据服务器当前的日志级别（可配置；具有写入属性），

/ZI/DEBUG/LOG - 作为字符串阵列的最后的数据服务器日志条目。

有关所有数据服务器节点的文档，请参见仪器特定用户手册的“参考节点文档”部分的 /ZI/ 部分。

### 7.2. 参考节点文档

本节按分支介绍数据服务器的节点树中的所有节点。有关节点属性和类型的说明，参见节点属性和数据类型。

#### 7.2.1. AUXINS

##### /DEV..../AUXINS/n/AVERAGING

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

将输入上的样本数量定义为 2 的幂的平均值。可能的值的范围为 [0, 16]。0 值对应辅助输入的 ADC 的采样率。

##### /DEV..../AUXINS/n/SAMPLE

属性：读取、流传输

类型：ZIAuxInSample

单位：V

取平均值后在辅助输入端测得的电压。数据速率取决于平均值。注意，如果仪器具有解调器功能，则辅助输入值可作为解调器样本中的字段，并通过时间戳与解调器输出对齐。

##### /DEV..../AUXINS/n/VALUES/n

属性：读取

类型：双

单位：V

取平均值后在辅助输入端测得的电压。该节点的值以低速率 (50 Hz) 更新；流传输节点 auxins/n/sample 以平均值定义的高速率更新。

#### 7.2.2. AUXOUTS

##### /DEV..../AUXOUTS/n/DEMODSELECT

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

选择所选信号源的通道数量。

##### /DEV..../AUXOUTS/n/LIMITLOWER

属性：读取、写入、设置

类型：双

单位：V

辅助输出端信号的下限。如果数值过小，则会选择取值范围下限。

##### /DEV..../AUXOUTS/n/LIMITUPPER

属性：读取、写入、设置

类型：双

单位：V

辅助输出端信号的上限。如果数值过大，则会选择取值范围上限。

##### /DEV..../AUXOUTS/n/OFFSET

属性：读取、写入、设置

类型：双

单位：V

在缩放后将指定的偏移电压添加到信号。辅助输出值 = (Signal+Preoffset)*Scale + Offset

##### /DEV..../AUXOUTS/n/OUTPUTSELECT

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

选择辅助输出所表示的信号源。

-1 manual



<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>-1</td><td style='text-align: center; word-wrap: break-word;'>manual</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>0</td><td style='text-align: center; word-wrap: break-word;'>demod_x</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>demod_y</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>2</td><td style='text-align: center; word-wrap: break-word;'>demod_r</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>3</td><td style='text-align: center; word-wrap: break-word;'>demod_theta</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>5</td><td style='text-align: center; word-wrap: break-word;'>pid</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>9</td><td style='text-align: center; word-wrap: break-word;'>pid_shift</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>10</td><td style='text-align: center; word-wrap: break-word;'>pid_error</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>11</td><td style='text-align: center; word-wrap: break-word;'>tu_filtered</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>13</td><td style='text-align: center; word-wrap: break-word;'>tu_output</td></tr></table>

##### /DEV..../AUXOUTS/n/PREOFFSET

属性：读取、写入、设置

类型：双

单位：依赖

在应用缩放之前，向信号添加预偏移量。辅助输出值 = (Signal+Preoffset)*Scale + Offset

##### /DEV..../AUXOUTS/n/SCALE

属性：读取、写入、设置

类型：双

单位：___ 无

用于缩放信号的乘法因子。辅助输出值 = (Signal+Preoffset)*Scale + Offset

##### /DEV..../AUXOUTS/n/VALUE

属性：读取

类型：双

单位：V

辅助输出端的电压。辅助输出值 = (Signal+Preoffset)*Scale + Offset

#### 7.2.3. CLOCKBASE

##### /DEV..../CLOCKBASE

属性：读取

类型：双

单位：Hz

返回设备的内部时钟频率。

#### 7.2.4. CURRINS

##### /DEV..../CURRINS/n/AUTORANGE

属性：读取、写入

类型：整数（64位）

单位：___ 无

将 Range（范围）自动调整为约 100 ms 时间内测量的最大电流输入幅值的两倍左右。

##### /DEV..../CURRINS/n/FLOAT

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

在浮动 (ON) 和接地 (OFF) 之间进行切换输入。此设置适用于电压和电流输入。建议在连接前对测试设备进行放电或仅当信号源在接地模式下连接至信号输入后启用此设置。

0 off

OFF: 接地

1 on

ON: 浮动

##### /DEV..../CURRINS/n/MAX

属性：读取、写入

类型：双

单位：___ 无

提供归一化到输入范围的最大测量输入电流（峰值）。

##### /DEV.../CURRINS/n/MIN

属性：读取、写入

类型：双

单位：___ 无

提供归一化到输入范围的最小测量输入电流（峰值）。

##### /DEV.../CURRINS/n/ON

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

启用电流输入。

##### /DEV..../CURRINS/n/RANGE

属性：读取、写入、设置

类型：双

单位：A

定义电流输入放大器的增益。该范围应为输入信号的两倍左右，包括潜在的直流偏移量。仪器会相对于用户插入的值选择下一个较大的可用范围。适当选择此设置可确保使用输入ADC的完整动态范围，从而优化精度和信噪比。

##### /DEV..../CURRINS/n/SCALING

属性：读取、写入、设置

类型：双

单位：___ 无

对电流输入进行给定比例的缩放。

##### /DEV..../CURRINS/n/RANGESTEP/TRIGGER

属性：读取、写入

类型：整数（64位）

单位：___ 无

切换到下一个最适合测量的输入电流的输入范围。

#### 7.2.5. DEMODS

##### /DEV..../DEMODS/n/ADCSELECT

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

选择解调器的输入信号。

0 sigin0, signal_input0

Sig In 1

1 currin0, current_input0

Curr In 1

2 trigin0, trigger_input0

Trigger Input 1

3 trigin1, trigger_input1

Trigger Input 2

4 auxout0, auxiliary_output0

Aux Out 1

5 auxout1, auxiliary_output1

Aux Out 2

6 auxout2, auxiliary_output2

Aux Out 3

7 auxout3, auxiliary_output3

Aux Out 4

8 auxin0, auxiliary_input0

Aux In 1

9 auxin1, auxiliary_input1

Aux In 2

174 demod_constant_input

解调常数输入。这样会得到一

时；较高频率将会衰减）。最

可使得解调器输出中的衰减最

级测量和控制任务。当解调器

解调常数输入。这样会得到一个振幅为 1，频率由解调器的振荡器指定的正弦波（频率较低时；较高频率将会衰减）。最大可能频率受解调器采样率和带宽的限制；使用解调器 1 阶可使得解调器输出中的衰减最低。该信号可与辅助输出、PID 和阈值单元一起使用，用于高级测量和控制任务。当解调器输出被写入辅助输出时，所得到的信号也可以用作第二输出通道（用于低频）。

##### /DEV..../DEMODS/n/BYPASS

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

允许将解调器低通滤波器置于旁路模式，从而增加带宽。

##### /DEV..../DEMODS/n/ENABLE

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

启用响应解调器的数据采集。请注意：随着激活的解调器数量的增加，主机物理连接的负载也会增加。

0 off

OFF：解调器停用

1 on

ON：解调器激活

##### /DEV..../DEMODS/n/FREQ

属性：读取

类型：双

单位：Hz

指示用于解调和生成输出的频率。通过将振荡器频率乘以谐波因子来计算解调频率。当使用 MOD 选件时，通过振荡器频率（包括谐波因子）的线性组合来定义解调频率。

##### /DEV.../DEMODS/n/HARMONIC

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

将解调器的参考频率乘以某一整数因子。如果在外部参考模式 (PLL) 下将解调器用作相位检测器，则效果为内部振荡器锁定到外部频率除以该整数因子后所得到的频率。

##### /DEV..../DEMODS/n/ORDER

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

在 6 dB/oct 和 48 dB/oct 之间选择滤波器滚降系数。

1 1 阶滤波器为 6 dB/oct

2 2 阶滤波器为 12 dB/oct

3 3 阶滤波器为 18 dB/oct

4 4 阶滤波器为 24 dB/oct

5 5 阶滤波器为 30 dB/oct

6 6 阶滤波器为 36 dB/oct

7 7 阶滤波器为 42 dB/oct

8 8 阶滤波器为 48 dB/oct

##### /DEV.../DEMODS/n/OSCSELECT

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

连接解调器和随附的振荡器。可用振荡器的数量取决于安装的选件。

0 振荡器 1

1 振荡器 2

2 振荡器 3

3 振荡器 4

##### /DEV.../DEMODS/n/PHASEADJUST

属性：读取、写入

类型：整数（64位）

单位：___ 无

自动调整解调器相位，以读取 0 度。

##### /DEV..../DEMODS/n/PHASESHIFT

属性：读取、写入、设置

类型：双

单位：度

应用到解调器参考输入的相移。

##### /DEV..../DEMODS/n/RATE

属性：读取、写入、设置

类型：双

单位： $ 1/s $

定义解调器采样率，即每秒发送到主机的样本数。该速率通常为滤波器带宽的 7-10 倍左右时，可实现充足的混叠抑制。这也是 LabOne 数据服务器接收数据并保存到计算机硬盘的速率。此设置对辅助输出连接器上的采样率没有影响。请注意：用户插入的值可能会被近似处理为仪器所支持的最接近值。

##### /DEV..../DEMODS/n/SAMPLE

属性：读取、流传输

类型：ZIDemodSample

单位：依赖

包含流传输的解调器样本，样本间隔由解调器数据速率决定。

##### /DEV..../DEMODS/n/SINC

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

及其高次谐波的频率分量。Sinc 是一个附加滤波器，用于衰减解调器输出中这些不需要的分量。

##### /DEV..../DEMODS/n/TIMECONSTANT

属性：读取、写入、设置

类型：双

单位：s

设置积分时间常数，即解调器低通滤波器的截止频率。

##### /DEV..../DEMODS/n/TRIGGER

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

选择采集模式（即触发）或解调器。

0 continuous

连续：解调器数据连续流传输到主机。

1 trigin0_rising, trigger_input0_rising

触发器输入 1：触发上升沿。

2 trigin0_falling, trigger_input0_falling

触发器输入 1：触发下降沿。

3 trigin0_both, trigger_input0_both

触发器输入 1：触发上升沿和下降沿。

4  $ trigin1\_rising, trigger\_input1\_rising $

触发器输入 2：触发上升沿。

5 trigin0or1_rising, trigger_input0or1_rising

触发器输入 1 或 2：任一输入触发上升沿。

8 trigin1_falling, trigger_input1_falling

舳发器输入 2：触发下降沿。

10 trigin0or1_falling, trigger_input0or1_falling

触发器输入 1 或 2：任一输入触发下降沿。

12 trigin1_both, trigger_input1_both

触发器输入 2：触发上升沿和下降沿。

15 trigin0or1_both, trigger_input0or1_both

触发器输入 1 或 2：触发上升沿和下降沿或任一触发器输。

16 trigin0_low, trigger_input0_low

触发器输入 1：在低电平时解调器数据流传输到主机(TTL)。

32 trigin0_high, trigger_input0_high

MF 触发器输入 1：在高电平时解调器数据流传输到主机 (TTL)。

64 trigin1_low, trigger_input1_low

触发器输入 2：在低电平时解调器数据流传输到主机(TTL)。

80 trigin0or1_low, trigger_input0or1_low



<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>128</td><td style='text-align: center; word-wrap: break-word;'>触发器输入 1 或 2：在任一输入处于低电平时解调器数据流传输到主机 (TTL)。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>160</td><td style='text-align: center; word-wrap: break-word;'>trigin1_high, trigger_input1_high 触发器输入 2：在高电平时解调器数据流传输到主机 (TTL)。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>trigin0or1_high, trigger_input0or1_high 触发器输入 1 或 2：在任一输入处于高电平时解调器数据流传输到主机 (TTL)。</td></tr></table>

#### 7.2.6. DIOS (Digital I/O)

##### /DEV..../DIOS/n/AUXDRIVE

属性：读取

类型：整数（64位）

单位：___ 无

未使用。保存以供未来使用。

##### /DEV..../DIOS/n/DECIMATION

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

设置流传输到主机的 DIO 数据的抽取因子。

##### /DEV..../DIOS/n/DRIVE

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

开启 (1) 时，相应的 8 位总线处于输出模式。关闭 (0) 时，相应的 8 位总线处于输入模式。位 0 对应最低有效字节。例如，值 1 驱动最低有效字节，值 8 驱动最高有效字节。

##### /DEV..../DIOS/n/EXTCLK

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

为 DIO 选择内部或外部时钟。

0 internal

在内部为 DIO 提供 60 MHz 固定频率的时钟。

1 external

通过将时钟信号连接到 DIO 引脚 68，从外部为 DIO 提供时钟。可用范围为 1 Hz 到内部时钟频率。

##### /DEV..../DIOS/n/INPUT

属性：读取、流传输

类型： ZIDIOSample

单位：___ 无

提供驱动被禁用的字节的 DIO 输入值。

##### /DEV..../DIOS/n/MODE

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

选择 DIO 模式

0 manual

允许手动控制 DIO 输出位数。

3 threshold_unit

允许通过阈值单元设置 DIO 输出值。

/DEV..../DIOS/n/OUTPUT

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

设置“驱动”被启用的字节的 DIO 输出值。

#### 7.2.7. EXTREFS

##### /DEV..../EXTREFS/n/ADCSELECT

属性：读取

类型：整数（枚举）

单位：___ 无

指示所选解调器的输入信号选择。

0 sign0, signal_input0

Signal Input 1 与相应的解调器相连。

1 currin0, current_input0

Current Input 1 与相应的解调器相连。

2 trigin0, trigger_input0

Trigger Input 1 与相应的解调器相连。

3 trigin1, trigger_input1

Trigger Input 2 与相应的解调器相连。

4 auxout0, auxiliary_output0

Auxiliary Output 1 与相应的解调器相连。

5 auxout1, auxiliary_output1

Auxiliary Output 2 与相应的解调器相连。

6 auxout2, auxiliary_output2

Auxiliary Output 3 与相应的解调器相连。

7 auxout3, auxiliary_output3

Auxiliary Output 4 与相应的解调器相连。

8 auxin0, auxiliary_input0

Auxiliary Input 1 与相应的解调器相连。

9 auxin1, auxiliary_input1

Auxiliary Input 2 与相应的解调器相连。

##### /DEV..../EXTREFS/n/AUTOMODE

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

该项定义用于 Ext Ref 的 PID 中参数的自动调整类型。

0 off

  不自动调整。

1 coefficients_only

  自动设置 PID 控制器的系数。

2 low_bandwidth

  使用低带宽自动设置 PID 系数、滤波器带宽和输出限值。

3 high_bandwidth

  使用高带宽自动设置 PID 系数、滤波器带宽和输出限值。

4 all

  调整包括中心频率在内的所有 PID 参数。

##### /DEV..../EXTREFS/n/DEMODSELECT

属性：读取、写入、设置  

类型：整数（64 位）  

单位：无

指示连接到 ExtRef 通道的解调器。

##### /DEV..../EXTREFS/n/ENABLE

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

启用外部参考。

##### /DEV..../EXTREFS/n/LOCKED

属性：读取

类型：整数（64位）

单位：___ 无

指示外部参考是否已锁定。

##### /DEV.../EXTREFS/n/OSCSELECT

属性：读取

类型：整数（64位）

单位：___ 无

指示哪一振荡器已锁定到外部参考。

#### 7.2.8. 特征

##### /DEV..../FEATURES/CODE

属性：读取、写入

类型： 字符串

单位：___ 无

提供特征码编写机制的节点。

##### /DEV..../FEATURES/DEVTYPE

属性：读取

类型： 字符串

单位：___ 无

返回设备类型。

##### /DEV..../FEATURES/OPTIONS

属性：读取

类型： 字符串

单位：___ 无

返回启用的选件。

##### /DEV..../FEATURES/SERIAL

属性：读取

类型： 字符串

单位：___ 无

设备序列号。

#### 7.2.9. IMPS（阻抗）

##### /DEV..../IMPS/n/AC

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

定义信号输入的输入耦合。交流耦合会插入一个高通滤波器。

##### /DEV..../IMPS/n/ENABLE

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

启用解调器数据的阻抗计算。

##### /DEV..../IMPS/n/FREQ

属性：读取、写入、设置

类型：双

单位：Hz

用于阻抗测量的振荡器的频率控制。

##### /DEV.../IMPS/n/INTERPOLATION

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

选择补偿数据的插值方法。如果导数变化很大，例如在截止频率处，则插值方法尤其重要。

0 linear

线性：线性插值最快，但可能会在用于补偿的频率点之间产生补偿误差。

1 pchip

分段三次 Hermite (PCHIP)：分段三次 Hermite 插值将产生非常精确的结果，但需要具备更高的计算能力。

##### /DEV..../IMPS/n/MAXBANDWIDTH

属性：读取、写入、设置

类型：双

单位：Hz

解调器滤波器使用的最大带宽限制。如果数值高于 1 kHz，则会导致高频区域（高频区域的幅值随频率而变化）的测量精度大幅降低。

##### /DEV..../IMPS/n/MODE

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

选择阻抗测量模式。

0 4 Terminal

该方法使用 DUT 上的电流和压降来计算 DUT 阻抗。由于排除了串联电阻对输出和电流输入的影响，因此该方法可以实现非常精确的测量。

12 Terminal

该方法使用驱动电压和测量电流来计算 DUT 阻抗。当测量非常高的阻抗时，电压测量的寄生效应会限制频率范围，这种情况下 2 端子法可能更为合适。

##### /DEV..../IMPS/n/MODEL

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

通过两个实数值表示复数阻抗值 Z，这两个实数值可在所有用户界面显示画面中作为 Parameter 1 和 Parameter 2 进行访问。

0 r_c_parallel

Cp：阻抗值 Z 由并联的电阻元件 Rp 与电容元件 Cp 表示。



<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>r_c_series</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Rs + Cs: 阻抗值 Z 由串联的电阻元件 Rs 与电容元件 Cs 表示。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>2</td><td style='text-align: center; word-wrap: break-word;'>r_l_series</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Rs + Ls: 阻抗值 Z 由串联的电阻元件 Rs 与电感元件 Ls 表示。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>3</td><td style='text-align: center; word-wrap: break-word;'>g_b_parallel, admittance</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>G B: 阻抗值 Z 由导纳 Y = 1/Z 的电导 G = Real(Y) 和电纳 B = Imag(Y) 表示。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>4</td><td style='text-align: center; word-wrap: break-word;'>d_c_series</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>D Cs: 阻抗值 Z 由损耗系数 D = -Real(Z)/Imag(Z)（损耗角正切）和串联电容元件表示。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>5</td><td style='text-align: center; word-wrap: break-word;'>q_c_series</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Q Cs: 阻抗值 Z 由品质因数 Q = -Imag(Z)/Real(Z) 和串联电容元件表示。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>6</td><td style='text-align: center; word-wrap: break-word;'>d_l_series</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>D Ls: 阻抗值 Z 由损耗系数 D = Real(Z)/Imag(Z)（损耗角正切）和串联电感元件表示。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>7</td><td style='text-align: center; word-wrap: break-word;'>q_l_series</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Q Ls: 阻抗值 Z 由品质因数 Q = Imag(Z)/Real(Z) 和串联电感元件表示。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>8</td><td style='text-align: center; word-wrap: break-word;'>r_l_parallel</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Rp</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Lp: 阻抗值 Z 由并联的电阻元件 Rp 与电感元件 Lp 表示。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>9</td><td style='text-align: center; word-wrap: break-word;'>d_c_parallel</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>D Cp: 阻抗值 Z 由损耗系数 D = -Real(Z)/Imag(Z)（损耗角正切）和并联电容元件 Cp 表示。</td></tr></table>

##### /DEV.../IMPS/n/OMEGASUPPRESSION

属性：读取、写入、设置

类型：双

单位：dB

抑制 omega 和 2-omega 分量。如果 Ω 抑制较小，则会减少对极低或极高阻抗的测量，因为直流分量会占据主导地位。如果 Ω 抑制较大，则会对扫描时间产生显著影响，尤其是对于低阶滤波器。

##### /DEV..../IMPS/n/SAMPLE

属性：读取、流传输

类型：ZlimpedanceSample

单位：___ 无

包含阻抗测量样本数据的流传输节点。

##### /DEV..../IMPS/n/AUTO/BW

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

启用自动带宽控制。如果启用，则基于频率和测量数据计算最佳带宽。

##### /DEV..../IMPS/n/AUTO/INPUTRANGE

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

选择输入范围控制模式。

0 Manual

在手动模式下，电流和电压输入范围可以手动方式单独调整。请小心使用此模式，因为过载会导致阻抗结果不准确。

1 Auto

根据测得的输入信号强度动态调整输入范围。这样可以优化阻抗测量的动态范围和精度。

2 Zone

可通过此调整范围选项手动设置所有八个电流输入范围的切换频率限值。

##### /DEV..../IMPS/n/AUTO/OUTPUT

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

如果启用，驱动电压幅值由设备控制。如果禁用，可以手动设置。

##### /DEV..../IMPS/n/AUTO/SUPPRESS

属性：读取、写入

类型：整数（64位）

单位：___ 无

指示禁用定期自动范围控制。正在运行的参数扫描仪模块会接管范围控制，因此会禁用定期范围检查。

##### /DEV..../IMPS/n/BIAS/ENABLE

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

启用 DC 偏置电压。

##### /DEV..../IMPS/n/BIAS/VALUE

属性：读取、写入、设置

类型：双

单位：V

在待测设备上施加直流偏置电压。既支持正偏置电压，也支持负偏置电压。在 4 端子测量中，偏置电压会受限于设备的最大公共电压输入范围。在 2 端子测量中，偏置电压可能更大，因为没有连接电压输入。

##### /DEV..../IMPS/n/CURRENT/DEMODSELECT

属性：读取

类型：整数（64位）

单位：___ 无

用于电流解调制的解调器。

##### /DEV..../IMPS/n/CURRENT/INPUTSELECT

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

选择用于 2 端子和 4 端子阻抗测量的电流输入。

0 currin0, current_input0

Current Input 1

8 auxin0, auxiliary_input0

Aux In 1

9 auxin1, auxiliary_input1

Aux In 2

##### /DEV..../IMPS/n/CURRENT/INVERT

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

如果启用，则会将电流输入信号取反。这对于切换输入信号的极性很有用，因为附加的电流放大器可能会导致输入信号的极性反转。

##### /DEV..../IMPS/n/CURRENT/RANGE

属性：读取、写入、设置

类型：双

单位：A

用于阻抗测量的输入电流范围。如果电流输入范围较小，带宽也会减小。在“Auto”（自动）和“Impedance”（阻抗）两种范围控制模式下，如果频率过高，电流范围会自动切换到更高的范围。

##### /DEV..../IMPS/n/CURRENT/SCALING

属性：读取、写入、设置

类型： 双

单位： $ A/V $

通过 Aux In 输入完成电流测量时应用的比例因子。

##### /DEV..../IMPS/n/DEMOD/HARMONIC

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

将解调器的参考频率与该字段定义的整数因子相乘。

##### /DEV.../IMPS/n/DEMOD/ORDER

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

在 6 dB/oct 和 48 dB/oct 之间选择当前解调器的滤波器滚降系数。

1 1 阶滤波器为 6 dB/oct  

2 2 阶滤波器为 12 dB/oct  

3 3 阶滤波器为 18 dB/oct  

4 4 阶滤波器为 24 dB/oct  

5 5 阶滤波器为 30 dB/oct  

6 6 阶滤波器为 36 dB/oct  

7 7 阶滤波器为 42 dB/oct  

8 8 阶滤波器为 48 dB/oct

##### /DEV..../IMPS/n/DEMOD/OSCSELECT

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

用于在 Hcur (+V) 连接器上产生激励电压频率的振荡器。

0 振荡器 1  

1 振荡器 2  

2 振荡器 3  

3 振荡器 4

##### /DEV..../IMPS/n/DEMOD/RATE

属性：读取、写入、设置

类型：双

单位：1/s

阻抗数据流传输速率。该数据流传输速率将应用于所有用于阻抗测量的解调器。

##### /DEV..../IMPS/n/DEMOD/SINC

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

启用 sinc 滤波器。

##### /DEV..../IMPS/n/DEMOD/TIMECONSTANT

属性：读取、写入、设置

类型：双

单位：s

定义低通滤波器时间常数。

##### /DEV..../IMPS/n/DISCARD/ENABLE

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

丢弃超出指定范围的阻抗样本。

##### /DEV..../IMPS/n/DISCARD/LIMITLOWER

属性：读取、写入、设置

类型：双

单位：___ 无

abs(Z) 的阈值下限，低于该阈值的阻抗样本将被丢弃。

##### /DEV.../IMPS/n/DISCARD/LIMITUPPER

属性：读取、写入、设置

类型：双

单位：___ 无

abs(Z) 的阈值上限，高于该阈值的阻抗样本将被丢弃。

##### /DEV..../IMPS/n/ONEPERIOD/ACTIVE

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

对低频阻抗测量启用单周期平均功能。启用后 LED 亮绿灯。

##### /DEV.../IMPS/n/ONEPERIOD/ENABLE

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

对低频阻抗测量启用单周期平均功能。启用后 LED 亮绿灯。

##### /DEV..../IMPS/n/OUTPUT/AMPLITUDE

属性：读取、写入、设置

类型：双

单位：V

信号输出的驱动幅值。

##### /DEV..../IMPS/n/OUTPUT/DEMOD

属性：读取

类型：整数（64位）

单位：___ 无

用于在信号输出端产生激励电压的解调器单元。

##### /DEV..../IMPS/n/OUTPUT/ON

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

仪器前面板上蓝色 LED 指示灯所对应的信号输出的主开关。

##### /DEV..../IMPS/n/OUTPUT/RANGE

属性：读取、写入、设置

类型：双

单位：V

选择输出电压范围。

##### /DEV..../IMPS/n/OUTPUT/SELECT

属性：读取

类型：整数（枚举）

单位：___ 无

选择激励电压驱动的输出通道。

0 sigout0, signal_output0

Signal Output 1

##### /DEV.../IMPS/n/VOLTAGE/DEMODSELECT

属性：读取

类型：整数（64位）

单位：___ 无

在 4 端子阻抗测量情况下，用于电压测量的解调器。

##### /DEV..../IMPS/n/VOLTAGE/INPUTSELECT

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

选择用于 4 端子阻抗测量的电压输入。

0 voltage input0

Voltage Input 1

8 auxin0, auxiliary_input0

Aux In 1

9 auxin1, auxiliary_input1

Aux In 2

##### /DEV..../IMPS/n/VOLTAGE/INVERT

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

如果启用，则会将电压输入信号取反。

##### /DEV..../IMPS/n/VOLTAGE/RANGE

属性：读取、写入、设置

类型：双

单位：V

用于阻抗测量的输入电压范围。

##### /DEV..../IMPS/n/VOLTAGE/SCALING

属性：读取、写入、设置

类型：双

单位： $ V/V $

通过 Aux In 输入完成电压测量时应用的比例因子。

##### /DEV..../IMPS/n/CALIB/INTERNAL/ACTIVE

属性：读取

类型：整数（64位）

单位：___ 无

指示是否已对测量数据应用内部校准。

##### /DEV..../IMPS/n/CALIB/INTERNAL/ENABLE

属性：读取、写入、设置

类型：整数（64位）

单位： 无

启用内部校准。这样可确保输入范围增益在整个频率范围内匹配。通过启用内部校准，设备可满足阻抗精度规范。内部校准是应用用户补偿的先决条件。

##### /DEV.../IMPS/n/CALIB/INTERNAL/SMOOTH

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

启用内部校准数据的平滑处理。这会导致测量数据中的噪声较低。

##### /DEV..../IMPS/n/CALIB/USER/ACTIVE

属性：读取

类型：整数（64位）

单位：___ 无

指示当前正在进行有效用户补偿。如果激活，则阻抗数据流将基于阻抗用户补偿传输幅值和相位校正数据。

##### /DEV..../IMPS/n/CALIB/USER/ENABLE

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

启用对阻抗数据的用户补偿。用户补偿用于校正由外部测量装置引起的寄生效应和延迟。用户补偿将紧接着内部阻抗校准一起执行。

##### /DEV..../IMPS/n/CALIB/USER/SMOOTH

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

启用补偿数据的平滑处理。这会导致测量数据中的噪声较低。

##### /DEV..../IMPS/n/CONFIDENCE/COMPENSATION/ENABLE

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

启用绘图中的强补偿指示。强补偿会导致参数的测量精度降低。

##### /DEV..../IMPS/n/CONFIDENCE/COMPENSATION/RATIO

属性：读取、写入、设置

类型：双

单位：___ 无

将会触发强补偿警告的补偿强度。

##### /DEV..../IMPS/n/CONFIDENCE/FREQLIMIT/ENABLE

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

根据使用的电流输入范围启用频率限值检测。该项仅在 Range Control（范围控制）设置为 Manual（手动）时可用。

##### /DEV..../IMPS/n/CONFIDENCE/LOWDUT2T/ENABLE

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

当以两点接触测量低阻抗 (100k) 时启用警告。

##### /DEV..../IMPS/n/CONFIDENCE/LOWDUT2T/RATIO

属性：读取、写入、设置

类型：双

单位：___ 无

当以两点接触测量时，DUT 阻抗过低将触发 Low DUT 2T 警告。

##### /DEV..../IMPS/n/CONFIDENCE/ONEPERIOD/ENABLE

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

启用因数据样本丢失导致单周期平均值无效的不可靠数据点的检测。尝试降低数据传输速率。

##### /DEV.../IMPS/n/CONFIDENCE/OPENDETECT/ENABLE

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

启用针对 4 端子测量的端子开路检测。

##### /DEV..../IMPS/n/CONFIDENCE/OPENDETECT/RATIO

属性：读取、写入、设置

类型：双

单位：___ 无

端子开路检测率。如果根据电流和压降计算所得的激励超过根据驱动电压计算的指定因子，则会报告端子开路。

##### /DEV..../IMPS/n/CONFIDENCE/OVERFLOW/ENABLE

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

启用针对电流和电压的过载检测。

##### /DEV..../IMPS/n/CONFIDENCE/QFACTOR/ENABLE

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

启用负 Q 或 D 因子检测。负 Q 或 D 因子表示测量的阻抗与所选择的表示不对应。这可能是由于错

误补偿、误选表示或噪声所致。

##### /DEV..../IMPS/n/CONFIDENCE/SUPPRESSION/ENABLE

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

抑制置信度指示器用于指示两个电路表示参数中是否有一个无法通过测得的阻抗可靠地计算得出。

如果其中一个（主导）表示参数的微小变化导致另一个（抑制）表示参数发生巨大变化，则属于这

种情况。这种误差放大表明第二个参数的测量是不可靠的。

##### /DEV..../IMPS/n/CONFIDENCE/SUPPRESSION/RATIO

属性：读取、写入、设置

类型：双

单位：___ 无

误差放大限制，如果超限，第二个参数会被标记为不可靠。增益值越大，警告容差越大。介于 10

和 100 之间的增益值最佳。

##### /DEV..../IMPS/n/CONFIDENCE/UNDERFLOW/ENABLE

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

启用针对电流和电压的下溢检测。

##### /DEV..../IMPS/n/CONFIDENCE/UNDERFLOW/RATIO

属性：读取、写入、设置

类型：双

单位：___ 无

如果测得的幅值低于相对于满量程的指定比率，则满足下溢条件。

##### /DEV..../IMPS/n/CURRENT/PID/ENABLE

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

如果启用，则会使用 PID 值（而非电流输入端的测量值）来计算阻抗。

#### 7.2.10. MODS（调制）

##### /DEV..../MODS/n/ENABLE

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

启用调制。

##### /DEV..../MODS/n/FREQDEV

属性：读取、写入、设置

类型：双

单位：Hz

FM 模式下的峰值偏差值。

##### /DEV..../MODS/n/FREQDEVENABLE

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

在 FM 模式下，选择使用调制指数还是峰值偏差。调制指数等于峰值偏差除以调制频率。

0 modulation index

使用调制指数。

1 peak\_deviation

使用峰值偏差。

##### /DEV..../MODS/n/INDEX

属性：读取、写入、设置

类型：双

单位：___ 无

FM 调制指数：调制指数等于峰值偏差除以调制频率。

##### /DEV..../MODS/n/MODE

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

选择调制模式。

0 am

AM 调制

1 fm

FM 调制

2 manual

手动

##### /DEV..../MODS/n/OUTPUT

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

选择信号输出。

0 none

无

1 sigout0, signal_output0

Signal Output 1

##### /DEV..../MODS/n/CARRIER/AMPLITUDE

属性：读取、写入、设置

类型：双

单位：V

设置载波幅值

##### /DEV..../MODS/n/CARRIER/ENABLE

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

启用调制

##### /DEV..../MODS/n/CARRIER/HARMONIC

属性：读取、写入、设置

类型：整数（64位）

单位：无

设置载波频率的谐波 1 = 其波

设置载波频率的谐波。1 = 基波

##### /DEV.../MODS/n/CARRIER/INPUTSELECT

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

##### 选择信号输入以进行载波解调

0 sigin0, signal_input0

    Sig In 1

1 currin0, current_input0

    Curr In 1

2 trigin0, trigger_input0

    Trigger Input 1

3 trigin1, trigger_input1

    Trigger Input 2

4 auxout0, auxiliary_output0

    Aux Out 1

5 auxout1, auxiliary_output1

    Aux Out 2

6 auxout2, auxiliary_output2

    Aux Out 3

7 auxout3, auxiliary_output3

    Aux Out 4

8 auxin0, auxiliary_input0

    Aux In 1

9 auxin1, auxiliary_input1

Aux In 2

174 demod_constant_input

解调常数输入。这样会得到一个振幅为 1，频率由解调器的振荡器指定的正弦波（频率较低时；较高频率将会衰减）。最大可能频率受解调器采样率和带宽的限制；使用解调器 1 阶可使得解调器输出中的衰减最低。该信号可与辅助输出、PID 和阈值单元一起使用，用于高级测量和控制任务。当解调器输出被写入辅助输出时，所得到的信号也可以用作第二输出通道（用于低频）。

##### /DEV..../MODS/n/CARRIER/ORDER

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

##### 用于载波解调的滤波器阶数

1 1 阶滤波器为 6 dB/oct

2 2 阶滤波器为 12 dB/oct

3 3 阶滤波器为 18 dB/oct

4 4 阶滤波器为 24 dB/oct

5 5 阶滤波器为 30 dB/oct

6 6 阶滤波器为 36 dB/oct

7 7 阶滤波器为 42 dB/oct

8 8 阶滤波器为 48 dB/oct

##### /DEV.../MODS/n/CARRIER/OSCSELECT

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

为载波信号选择振荡器。

0 振荡器 1

1 振荡器 2

2 振荡器 3

3 振荡器 4

##### /DEV.../MODS/n/CARRIER/PHASESHIFT

属性：读取、写入、设置

类型：双

单位：___ 度

应用于载波解调器的参考输入以及信号输出端的载波信号的相移

##### /DEV..../MODS/n/CARRIER/TIMECONSTANT

属性：读取、写入、设置

类型：双

单位：s

设置积分时间常数，即载波解调器低通滤波器的截止频率。

##### /DEV..../MODS/n/SIDEBANDS/n/AMPLITUDE

属性：读取、写入、设置

类型：双

单位：V

设置边带分量的幅值。

##### /DEV..../MODS/n/SIDEBANDS/n/ENABLE

属性：读取、写入、设置

类型：整数（64位）

单位： 无

为相应边带启用信号生成功能

##### /DEV..../MODS/n/SIDEBANDS/n/HARMONIC

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

设置边带频率的谐波。1 = 基波

##### /DEV.../MODS/n/SIDEBANDS/n/INPUTSELECT

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

##### 选择信号输入以进行边带解调

0 sigin0, signal_input0  

Sig In 1  

1 currin0, current_input0  

    Curr In 1  

2 trigin0, trigger_input0  

    Trigger Input 1  

3 trigin1, trigger_input1  

    Trigger Input 2  

4 auxout0, auxiliary_output0  

    Aux Out 1  

5 auxout1, auxiliary_output1  

    Aux Out 2  

6 auxout2, auxiliary_output2  

    Aux Out 3  

7 auxout3, auxiliary_output3  

    Aux Out 4  

8 auxin0, auxiliary_input0  

    Aux In 1  

9 auxin1, auxiliary_input1  

    Aux In 2  

174 demod_constant_input  

    解调常数输入。这样会得到一  

    低时；较高频率将会衰减）。  

    阶可使得解调器输出中的衰减  

    于高级测量和控制任务。当解  

    输出通道（用于低频）。

解调常数输入。这样会得到一个振幅为 1，频率由解调器的振荡器指定的正弦波（频率较低时；较高频率将会衰减）。最大可能频率受调器采样率和带宽的限制；使用解调器 1 阶可使得解调器输出中的衰减最低。该信号可与辅助输出、PID 和阈值单元一起使用，用于高级测量和控制任务。当解调器输出被写入辅助输出时，所得到的信号也可以用作第二输出通道（用于低频）。

##### /DEV..../MODS/n/SIDEBANDS/n/MODE

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

对于手动模式，启用第一个边带并选择该边带相对于载波频率的位置。

0 off

Off：禁用第一个边带。边带解调器的行为与普通解调器相似。

1 upper

C + M：载波右侧的第一个边带

2 lower

C - M：载波左侧的第一个边带

##### /DEV..../MODS/n/SIDEBANDS/n/ORDER

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

用于边带解调的滤波器阶数



<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>1 阶滤波器为 6 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>2</td><td style='text-align: center; word-wrap: break-word;'>2 阶滤波器为 12 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>3</td><td style='text-align: center; word-wrap: break-word;'>3 阶滤波器为 18 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>4</td><td style='text-align: center; word-wrap: break-word;'>4 阶滤波器为 24 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>5</td><td style='text-align: center; word-wrap: break-word;'>5 阶滤波器为 30 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>6</td><td style='text-align: center; word-wrap: break-word;'>6 阶滤波器为 36 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>7</td><td style='text-align: center; word-wrap: break-word;'>7 阶滤波器为 42 dB/oct</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>8</td><td style='text-align: center; word-wrap: break-word;'>8 阶滤波器为 48 dB/oct</td></tr></table>

##### /DEV..../MODS/n/SIDEBANDS/n/OSCSELECT

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

为第二个边带选择振荡器。

0 振荡器 1

1 振荡器 2

2 振荡器 3

3 振荡器 4

##### /DEV..../MODS/n/SIDEBANDS/n/PHASESHIFT

属性：读取、写入、设置

类型：双

单位：___ 度

应用于边带解调器的参考输入以及信号输出端的边带信号的相移

##### /DEV.../MODS/n/SIDEBANDS/n/TIMECONSTANT

属性：读取、写入、设置

类型：双

单位：s

设置积分时间常数，即边带解调器低通滤波器的截止频率。

#### 7.2.11. OSCS（振荡器）

##### /DEV..../OSCS/n/FREQ

属性：读取、写入、设置

类型：双

单位：Hz

控制各振荡器的频率。

#### 7.2.12. PIDS

##### /DEV..../PIDS/n/CENTER

属性：读取、写入、设置

类型：双

单位：依赖

设置 PID 输出的 Center 值。添加 Center 值后，信号取值范围为 Center + Lower Limit 和 Center + Upper Limit 之间。

##### /DEV..../PIDS/n/D

属性：读取、写入、设置

类型：双

单位：依赖

PID 微分增益。

##### /DEV..../PIDS/n/DLIMITTIMECONSTANT

属性：读取、写入、设置

类型：双

单位：s

D 限制的低通滤波器截止值显示为时间常数。设置为 0 时，禁用低通滤波器。

##### /DEV..../PIDS/n/ENABLE

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

启用 PID 控制器。

##### /DEV..../PIDS/n/ERROR

属性：读取

类型：双

单位：依赖

误差 = 设定值 - PID 输入。

##### /DEV..../PIDS/n/I

属性：读取、写入、设置

类型：双

单位：依赖

PID 积分增益 I。

##### /DEV..../PIDS/n/INPUT

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

选择 PID 控制器的输入源。



<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>0</td><td style='text-align: center; word-wrap: break-word;'>demod_x</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Demodulator X</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>demod_y</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Demodulator Y</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>2</td><td style='text-align: center; word-wrap: break-word;'>demod_r</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Demodulator R</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>3</td><td style='text-align: center; word-wrap: break-word;'>demod_theta</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Demodulator Theta</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>4</td><td style='text-align: center; word-wrap: break-word;'>auxin, auxiliary_input</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Aux Input</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>5</td><td style='text-align: center; word-wrap: break-word;'>auxout, auxiliary_output</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>Aux Output</td></tr></table>

##### /DEV..../PIDS/n/INPUTCHANNEL

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

选择 PID 控制器的输入通道。

##### /DEV..../PIDS/n/KEEPINT

属性：读取、写入、设置

类型：整数（64位）

单位：依赖

启用后，累积的积分误差在 PID 重新启动时保持不变。禁用后，积分误差在 PID 禁用后归零。

##### /DEV..../PIDS/n/LIMITLOWER

属性：读取、写入、设置

类型：双

单位：依赖

设置 PID 输出的下限。添加 Center 值后，信号取值范围为 Center + Lower Limit 和 Center + Upper Limit 之间。

##### /DEV..../PIDS/n/LIMITUPPER

属性：读取、写入、设置

类型：双

单位：依赖

设置 PID 输出的上限。添加 Center 值后，信号取值范围为 Center + Lower Limit 和 Center + Upper Limit 之间。

##### /DEV..../PIDS/n/MODE

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

设置 PID 模块的工作模式。

0 pid

PID

1 pll

PLL（锁相环）

2 extref

ExtRef（外部参考）

##### /DEV..../PIDS/n/OUTPUT

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

选择 PID 控制器的输出。

0 sigout, signal_output

反馈到主信号输出幅值

1 oscillator_frequency

反馈到内部振荡器频率之一

2 demod phase

反馈到 8 个解调器相位设定值之一

3 auxout_offset, auxiliary_output_offset

反馈到 4 个辅助输出偏移量之一

4 sigout_offset, signal_output_offset

反馈到主信号输出偏移量调整

##### /DEV..../PIDS/n/OUTPUTCHANNEL

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

选择 PID 控制器驱动输出的输出通道。

##### /DEV..../PIDS/n/P

属性：读取、写入、设置

类型：双

单位：依赖

PID 比例增益 P。

##### /DEV..../PIDS/n/PHASEUNWRAP

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

支持相位重建，以便能够跟踪超过  $ \pm 180 $ 度边界的相位误差并增加 PLL 带宽。

##### /DEV..../PIDS/n/RATE

属性：读取、写入、设置

类型：双

单位： $ 1/s $

PID 采样率和 PID 输出的更新率。需要设置为远高于目标环路滤波器带宽。

##### /DEV.../PIDS/n/SETPOINT

属性：读取、写入、设置

类型：双

单位：依赖

PID 控制器设定值

##### /DEV.../PIDS/n/SHIFT

属性：读取

类型：双

单位：依赖

当前输出值 Out 和 Center 之差。Shift = P*Error + I*Int(Error, dt) + D*dError/dt

##### /DEV..../PIDS/n/VALUE

属性：读取

类型：双

单位：依赖

提供当前 PID 输出值。

##### /DEV..../PIDS/n/DEMOD/ADCSELECT

属性：读取

类型：整数（枚举）

单位：___ 无

指示连接到所选输入解调器通道的信号源。

0 sign0, signal_input0

Signal Input 1 与相应的解调器相连。

1 currin0, current_input0

Current Input 1 与相应的解调器相连。

2 trigin0, trigger_input0

Trigger Input 1 与相应的解调器相连。

3 trigin1, trigger_input1

Trigger Input 2 与相应的解调器相连。

4 auxout0, auxiliary_output0

Auxiliary Output 1 与相应的解调器相连。

5 auxout1, auxiliary_output1

Auxiliary Output 2 与相应的解调器相连。

6 auxout2, auxiliary_output2

Auxiliary Output 3 与相应的解调器相连。

7 auxout3, auxiliary_output3

Auxiliary Output 4 与相应的解调器相连。

8 auxin0, auxiliary_input0

Auxiliary Input 1 与相应的解调器相连。

9 auxin1, auxiliary_input1

9 auxin1, auxiliary_input1

Auxiliary Input 2 与相应的解调器相连。

##### /DEV..../PIDS/n/DEMOD/HARMONIC

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

当前解调器的参考频率的谐波倍数。

##### /DEV..../PIDS/n/DEMOD/ORDER

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

在 6 dB/oct 和 48 dB/oct 之间选择当前解调器的滤波器滚降系数。

1 1 阶滤波器为 6 dB/oct

2 2 阶滤波器为 12 dB/oct

3 3 阶滤波器为 18 dB/oct

4 4 阶滤波器为 24 dB/oct

5 5 阶滤波器为 30 dB/oct

6 6 阶滤波器为 36 dB/oct

7 7 阶滤波器为 42 dB/oct

8 8 阶滤波器为 48 dB/oct

##### /DEV.../PIDS/n/DEMOD/TIMECONSTANT

属性：读取、写入、设置

类型：双

单位：s

定义用作输入的解调器滤波器的特性时间常数（截止）。

##### /DEV..../PIDS/n/PLL/AUTOMODE

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

该项定义 PID 中参数的自动调整类型。

0 no_adaption

不自动调整。

1 pid\_coeffs

自动设置 PID 控制器的系数。

2 pid\_coeffs\_filter\_low\_bw

使用低带宽自动设置 PID 系数、滤波器带宽和输出限值。

3 pid_coeffs_filter_high_bw

使用高带宽自动设置 PID 系数、滤波器带宽和输出限值。

4 pid_all

调整包括中心频率在内的所有 PID 参数。

##### /DEV.../PIDS/n/PLL/LOCKED

属性：读取

类型：整数（64位）

单位：___ 无

指示 PID（配置为 PLL）何时锁定。

##### /DEV..../PIDS/n/SETPOINTTOGGLE/ENABLE

属性：读取、写入、设置

类型：整数（64位）

单位：无

启用设定值切换。

##### /DEV..../PIDS/n/SETPOINTTOGGLE/RATE

属性：读取、写入、设置

类型：双

单位：Hz

定义设定值切换的速率。请注意，可能值之间呈对数间隔（系数为 4）。

##### /DEV.../PIDS/n/SETPOINTTOGGLE/SETPOINT

属性：读取、写入、设置

类型：双

单位：依赖

定义用于设定值切换的设定值。

##### /DEV..../PIDS/n/STREAM/EFFECTIVERATE

属性：读取

类型：双

单位： $ 1/s $

PID 流数据发送到 PC 的当前速率。根据 Max Rate（最大速率）定义。

##### /DEV..../PIDS/n/STREAM/ERROR

属性：读取、流传输

类型：双

单位：依赖

PID 误差 = 设定值 - PID 输入。

##### /DEV.../PIDS/n/STREAM/OVERFLOW

属性：读取

类型：整数（64位）

单位：___ 无

指示流传输 FIFO 溢出状态。0 = 正常，1 = 溢出。

##### /DEV..../PIDS/n/STREAM/RATE

属性：读取、写入、设置

类型：双

单位： $ 1/s $

PID 输出数据发送到 PC 的目标速率。该值定义在将数据发送到 PC 时应用的抽取。它不会影响任何其他使用 PID 数据的位置。

##### /DEV..../PIDS/n/STREAM/SHIFT

属性：读取、流传输

类型：双

单位：依赖

提供当前输出值和 Center 值之差。Shift = P*Error + I*Int(Error, dt) + D*dError/dt

##### /DEV..../PIDS/n/STREAM/VALUE

属性：读取、流传输

类型：双

单位：依赖

提供当前 PID 输出值。

#### 7.2.13. SCOPES

##### /DEV..../SCOPES/n/CHANNEL

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

激活示波器通道。

1 仅激活通道 1。

2 仅激活通道 2。

3 both

同时激活通道 1 和 2。

##### /DEV.../SCOPES/n/ENABLE

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

启用示波器截图采集。

##### /DEV..../SCOPES/n/LENGTH

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

以样本数定义所记录示波器截图的长度。

##### /DEV..../SCOPES/n/SINGLE

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

将示波器设为单触发模式。

##### /DEV.../SCOPES/n/TIME

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

根据仪器时钟基频的分频器指数定义示波器的时基。得出的采样时间为  $ 2^{n} $ /时钟基频。



<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>0</td><td style='text-align: center; word-wrap: break-word;'>60 MHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>1</td><td style='text-align: center; word-wrap: break-word;'>30 MHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>2</td><td style='text-align: center; word-wrap: break-word;'>15 MHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>3</td><td style='text-align: center; word-wrap: break-word;'>7.5 MHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>4</td><td style='text-align: center; word-wrap: break-word;'>3.75 MHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>5</td><td style='text-align: center; word-wrap: break-word;'>1.88 MHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>6</td><td style='text-align: center; word-wrap: break-word;'>938 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>7</td><td style='text-align: center; word-wrap: break-word;'>469 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>8</td><td style='text-align: center; word-wrap: break-word;'>234 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>9</td><td style='text-align: center; word-wrap: break-word;'>117 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>10</td><td style='text-align: center; word-wrap: break-word;'>58.6 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>11</td><td style='text-align: center; word-wrap: break-word;'>29.3 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>12</td><td style='text-align: center; word-wrap: break-word;'>14.6 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>13</td><td style='text-align: center; word-wrap: break-word;'>7.32 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>14</td><td style='text-align: center; word-wrap: break-word;'>3.66 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>15</td><td style='text-align: center; word-wrap: break-word;'>1.83 kHz</td></tr></table>

##### /DEV..../SCOPES/n/TRIGCHANNEL

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

选择触发源信号。

0 sigin0, signal_input0

Signal Input 1

1 currin0, current_input0

Current Input 1

2 trigin0, trigger_input0

Trigger Input 1

3 trigin1, trigger_input1

Trigger Input 2

4 auxout0, auxiliary_output0

Aux Output 1。需安装数字转换器(DIG)选件。

auxout1, auxiliary_output1

Aux Output 2。需安装数字转换器(DIG)选件。

auxout2, auxiliary_output2

Aux Output 3。需安装数字转换器(DIG)选件。

auxout3, auxiliary_output3

Aux Output 4。需安装数字转换器(DIG)选件。

auxin0, auxiliary_input0

Aux Input 1

9 auxin1, auxiliary_input1

Aux Input 2

10 demod1

Osc φ Demod 2

11 demod3

Osc φ Demod 4

14 trigout0, trigger_output0

Trigger Output 1

15 trigout1, trigger_output1

Trigger Output 2

16 demod0_x

Demod 1 X。需安装数字转换器(DIG)选件。

demod1_x

17 Demod 2 X。需安装数字转换器(DIG)选件。

demod2_x

18 Demod 3 X。需安装数字转换器(DIG)选件。

demod3_x

19 Demod 4 X。需安装数字转换器(DIG)选件。

demod0_y

32 Demod 1 Y。需安装数字转换器(DIG)选件。

demod1_y

33 Demod 2 Y。需安装数字转换器(DIG)选件。

demod2_y

34 Demod 3 Y。需安装数字转换器(DIG)选件。

demod3_y

35 Demod 4 Y。需安装数字转换器(DIG)选件。

demod0_r

48 Demod 1 R。需安装数字转换器(DIG)选件。

demod1_r

49 Demod 2 R。需安装数字转换器(DIG)选件。

demod2_r

50 Demod 3 R。需安装数字转换器(DIG)选件。

demod3_r

51 Demod 4 R。需安装数字转换器(DIG)选件。

demod0_theta

64 Demod 1 θ。需安装数字转换器(DIG)选件。

demod1_theta

65 Demod 2 θ。需安装数字转换器(DIG)选件。

demod2_theta

66 Demod 3 θ。需安装数字转换器(DIG)选件。

demod3_theta

67 Demod 4 θ。需安装数字转换器(DIG)选件。

pid0_value

80 PID 1 值。需安装数字转换器(DIG)选件。

pid1_value

81 PID 2 值。需安装数字转换器(DIG)选件。

82 pid2_value

PID 3 值。需安装数字转换器 (DIG) 选件。

83 pid3_value

PID 4 值。需安装数字转换器 (DIG) 选件。

144 pid0_shift

PID 1 偏移。需安装数字转换器 (DIG) 选件。

145 pid1_shift

PID 2 Shift。需安装数字转换器 (DIG) 选件。

146 pid2_shift

PID 3 偏移。需安装数字转换器 (DIG) 选件。

147 pid3_shift

PID 4 偏移。需安装数字转换器 (DIG) 选件。

208 pid0_error

PID 1 误差。需安装数字转换器 (DIG) 选件。

209 pid1_error

PID 2 误差。需安装数字转换器 (DIG) 选件。

210 pid2_error

PID 3 误差。需安装数字转换器 (DIG) 选件。

211 pid3_error

PID 4 误差。需安装数字转换器 (DIG) 选件。

224 tu0_filtered

TU 1 滤波值。需安装数字转换器 (DIG) 选件。

225 tu1_filtered

TU 2 滤波值。需安装数字转换器 (DIG) 选件。

226 tu2_filtered

TU 3 滤波值。需安装数字转换器 (DIG) 选件。

227 tu3_filtered

TU 4 滤波值。需安装数字转换器 (DIG) 选件。

##### /DEV..../SCOPES/n/TRIGDELAY

属性：读取、写入、设置

类型：双

单位：s

相对于参考的触发位置。正延迟会导致在触发点之前获取的数据较少，负延迟会导致在触发点之前获取的数据较多。

##### /DEV..../SCOPES/n/TRIGENABLE

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

启用触发后，每次满足所定义的触发条件时都会获取示波器数据。

0 on

##### /DEV.../SCOPES/n/TRIGFALLING

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

设为 (1) 时启用下降沿触发。该设置与在 /TRIGSLOPE 节点中完成的设置同步。

##### /DEV..../SCOPES/n/TRIGFORCE

属性：读取、写入

类型：整数（64位）

单位：___ 无

强制触发事件。

/DEV..../SCOPES/n/TRIGHOLDOFF

属性：读取、写入、设置

类型：双

单位：s

定义在记录事件后重新激活触发器之前的时间。

##### /DEV.../SCOPES/n/TRIGHOLDOFFCOUNT

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

定义在记录事件后将触发下一次记录的触发事件数量。如果值为 1，则表示将为每个触发事件启动一次记录。

##### /DEV.../SCOPES/n/TRIGHOLDOFFMODE

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

选择延迟模式。

0 time

延迟以时间(s)进行定义。

1 number_of_events 延迟以事件数进行定义。

##### /DEV.../SCOPES/n/TRIGLEVEL

属性：读取、写入、设置

类型：双

单位：V

定义触发电平。

##### /DEV..../SCOPES/n/TRIGREFERENCE

属性：读取、写入、设置

类型：双

单位：___ 无

相对于所获取数据的触发参考位置。默认值为 50% (0.5)，这会使得参考点落在所获取数据的中间位置。

##### /DEV..../SCOPES/n/TRIGRISING

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

设为 (1) 时启用上升沿触发。该设置与在 /TRIGFALLING 节点中完成的设置同步。

##### /DEV..../SCOPES/n/TRIGSLOPE

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

选择在触发器信号的哪一斜率触发示波器。该设置与在 /TRIGFALLING 和 /TRIGRISING 节点中完成的设置同步。

0 none

1 rising

上升沿触发。

2 falling

3 both

同时在上升沿和下降沿触发。

##### /DEV..../SCOPES/n/TRIGSTATE

属性：读取

类型：整数（64位）

单位：___ 无

1 指示触发器信号满足触发器条件。

##### /DEV..../SCOPES/n/WAVE

属性：读取、流传输

类型：ZIScopeWave

单位：___ 无

包含示波器截图数据。

##### /DEV.../SCOPES/n/SEGMENTS/COUNT

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

指定要在设备内存中记录的段数。最大示波器截图大小以可用内存除以段数的形式给出。此功能需要使用 DIG 选件。

##### /DEV..../SCOPES/n/SEGMENTS/ENABLE

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

启用分段示波器记录。这样可以对示波器截图进行全带宽记录，并确保各截图之间的死区时间最短。此功能需要使用 DIG 选件。

##### /DEV..../SCOPES/n/STREAM/RATE

属性：读取、写入、设置

类型：整数（枚举）

单位：Hz

示波器通道的流传输速率。可以独立于示波器采样率来调整流传输速率。最大速率取决于传输接口。注：示波器流传输需要使用 DIG 选件。



<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>4</td><td style='text-align: center; word-wrap: break-word;'>3.75 MHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>3.75 MHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>5</td><td style='text-align: center; word-wrap: break-word;'>1.88 MHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>1.88 MHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>6</td><td style='text-align: center; word-wrap: break-word;'>938 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>938 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>7</td><td style='text-align: center; word-wrap: break-word;'>469 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>469 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>8</td><td style='text-align: center; word-wrap: break-word;'>234 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>234 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>9</td><td style='text-align: center; word-wrap: break-word;'>117 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>117 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>10</td><td style='text-align: center; word-wrap: break-word;'>58.6 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>58.6 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>11</td><td style='text-align: center; word-wrap: break-word;'>29.3 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>29.3 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>12</td><td style='text-align: center; word-wrap: break-word;'>14.6 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>14.6 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>13</td><td style='text-align: center; word-wrap: break-word;'>7.32 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>7.32 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>14</td><td style='text-align: center; word-wrap: break-word;'>3.66 kHz</td></tr><tr><td style='text-align: center; word-wrap: break-word;'></td><td style='text-align: center; word-wrap: break-word;'>3.66 kHz</td></tr></table>

15 1.83 kHz 1.83 kHz

##### /DEV.../SCOPES/n/STREAM/SAMPLE

属性：读取、流传输

类型：ZIScopeWave

单位：___ 无

包含示波器样本数据的流传输节点。注：示波器流传输需要使用 DIG 选件。

##### /DEV.../SCOPES/n/TRIGGATE/ENABLE

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

如果启用，触发器将由触发门控输入信号进行门控。此功能需要使用 DIG 选件。

##### /DEV.../SCOPES/n/TRIGGATE/INPUTSELECT

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

在门控已启用时选择用于触发门控的信号源。此功能需要使用 DIG 选件。

0 trigin0_high, trigger_input0_high  

仅在 Trigger Input 1 处于高电平时触发。  

1 trigin0_low, trigger_input0_low  

仅在 Trigger Input 1 处于低电平时触发。  

2 trigin1_high, trigger_input1_high  

仅在 Trigger Input 2 处于高电平时触发。  

3 trigin1_low, trigger_input1_low  

仅在 Trigger Input 2 处于低电平时触发。

##### /DEV.../SCOPES/n/TRIGHYSTERESIS/ABSOLUTE

属性：读取、写入、设置

类型：双

单位：V

定义在重新激活触发器之前，源信号必须偏离触发电平的电压。设置为 0 可将其关闭。符号将由 Edge 设置定义。

##### /DEV..../SCOPES/n/TRIGHYSTERESIS/MODE

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

选择用于定义滞后强度的模式。只要模拟输入信号不会产生过多噪声，则相对模式在整个输入范围内效果最佳。

0 absolute

选择绝对滞后。

1 relative

选择相对于调整后的满量程信号输入范围的滞后。

##### /DEV.../SCOPES/n/TRIGHYSTERESIS/RELATIVE

属性：读取、写入、设置

类型：双

单位：___ 无

相对于调整后的满量程信号输入范围的滞后。允许滞后值大于1(100%)。

##### /DEV..../SCOPES/n/CHANNELS/n/BWLIMIT

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

在样本抽取和样本求平均值之间进行选择。求平均值可避免混叠，但可能会隐藏信号峰值。

0 on

ON：选择样本求平均值，以确保采样率低于最大可用采样率。

1 off

OFF：选择样本抽取，以确保采样率低于最大可用采样率。

##### /DEV.../SCOPES/n/CHANNELS/n/FULLSCALE

属性：读取、写入、设置

类型：双

单位：依赖

指示示波器通道满量程值。

##### /DEV.../SCOPES/n/CHANNELS/n/INPUTSELECT

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

选择示波器输入信号。

0 sigin0, signal_input0

Signal Input 1

1 currin0, current_input0

Current Input 1

2 trigin0, trigger_input0

Trigger Input 1

3 trigin1, trigger_input1

Trigger Input 2

4 auxout0, auxiliary_output0

Aux Output 1。需安装数字转换器(DIG)选件。

auxout1, auxiliary_output1

Aux Output 2。需安装数字转换器(DIG)选件。

auxout2, auxiliary_output2

Aux Output 3。需安装数字转换器(DIG)选件。

auxout3, auxiliary_output3

Aux Output 4。需安装数字转换器(DIG)选件。

auxin0, auxiliary_input0

Aux Input 1

9 auxin1, auxiliary_input1

Aux Input 2

10 demod1

Osc φ Demod 2

11 demod3

Osc φ Demod 4

14 trigout0, trigger_output0

Trigger Output 1

15 trigout1, trigger_output1

Trigger Output 2

16 demod0_x

Demod 1 X。需安装数字转换器(DIG)选件。

demod1_x

17 Demod 2 X。需安装数字转换器(DIG)选件。

demod2_x

18 Demod 3 X。需安装数字转换器(DIG)选件。

demod3_x

19 Demod 4 X。需安装数字转换器(DIG)选件。

demod0_y

32 Demod 1 Y。需安装数字转换器(DIG)选件。

33 demod1_y

Demod 2 Y。需安装数字转换器 (DIG) 选件。

34  $ \text{demod2\_y} $

35  $ \text{demod3\_Y} $ 需安装数字转换器 (DIG) 选件。

35  $ \text{demod3\_y} $

35  $ \text{Demod4\_Y} $ 需安装数字转换器 (DIG) 选件。

48  $ \text{demod0\_r} $

49  $ \text{Demod1\_R} $ 需安装数字转换器 (DIG) 选件。

50  $ \text{Demod2\_R} $ 需安装数字转换器 (DIG) 选件。

50  $ \text{Demod3\_R} $ 需安装数字转换器 (DIG) 选件。

51  $ \text{demod3\_r} $

51  $ \text{Demod4\_R} $ 需安装数字转换器 (DIG) 选件。

64  $ \text{demod0\_theta} $

64  $ \text{Demod1\_theta} $ 需安装数字转换器 (DIG) 选件。

65  $ \text{demod1\_theta} $

65  $ \text{Demod2\_theta} $ 需安装数字转换器 (DIG) 选件。

66  $ \text{demod2\_theta} $

66  $ \text{Demod3\_theta} $ 需安装数字转换器 (DIG) 选件。

67  $ \text{demod3\_theta} $

67  $ \text{Demod4\_theta} $ 需安装数字转换器 (DIG) 选件。

80  $ \text{pid0\_value} $

80  $ \text{PID1\_value} $ 需安装数字转换器 (DIG) 选件。

81  $ \text{pid1\_value} $

81  $ \text{PID2\_value} $ 需安装数字转换器 (DIG) 选件。

82  $ \text{pid2\_value} $

82  $ \text{PID3\_value} $ 需安装数字转换器 (DIG) 选件。

83  $ \text{pid3\_value} $

83  $ \text{PID4\_value} $ 需安装数字转换器 (DIG) 选件。

144  $ \text{pid0\_shift} $

144  $ \text{PID1\_shift} $

145  $ \text{pid1\_shift} $

145  $ \text{PID2\_shift} $

146  $ \text{pid2\_shift} $

146  $ \text{PID3\_shift} $ 需安装数字转换器 (DIG) 选件。

147  $ \text{pid3\_shift} $

147  $ \text{PID4\_shift} $ 需安装数字转换器 (DIG) 选件。

160  $ \text{保存以供未来使用。} $

161  $ \text{保存以供未来使用。} $

208  $ \text{pid0\_error} $

209  $ \text{PID1\_error} $

210  $ \text{PID2\_error} $

211  $ \text{PID3\_error} $

211  $ \text{PID4\_error} $ 需安装数字转换器 (DIG) 选件。

240  $ \text{保存以供未来使用。} $

241  $ \text{保存以供未来使用。} $

242  $ \text{保存以供未来使用。} $

243  $ \text{保存以供未来使用。} $

##### /DEV.../SCOPES/n/CHANNELS/n/LIMITLOWER

属性：读取、写入、设置

类型：双

单位：依赖

示波器满量程的下限。对于解调器、PID、Boxcar 和 AU 信号，应调整限值使信号覆盖指定范围，从而实现最佳分辨率。

##### /DEV..../SCOPES/n/CHANNELS/n/LIMITUPPER

属性：读取、写入、设置

类型：双

单位：依赖

示波器满量程的上限。对于解调器、PID、Boxcar 和 AU 信号，应调整限值使信号覆盖指定范围，从而实现最佳分辨率。

##### /DEV.../SCOPES/n/CHANNELS/n/OFFSET

属性：读取、写入、设置

类型：双

单位：依赖

指示示波器通道偏移值。

##### /DEV.../SCOPES/n/STREAM/ENABLES/n

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

为指定通道启用示波器流传输。这允许在绘图仪上连续记录示波器数据并流传输到磁盘。注：示波器流传输需要使用 DIG 选件。

#### 7.2.14. SIGINS

##### /DEV..../SIGINS/n/AC

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

定义信号输入的输入耦合。交流耦合会插入一个高通滤波器。

0 dc

OFF：直流耦合

1 ac

ON：交流耦合

##### /DEV..../SIGINS/n/AUTORANGE

属性：读取、写入

类型：整数（64位）

单位：___ 无

将 Range（范围）自动调整为约 100 ms 时间内测量的最大信号输入幅值的两倍左右。

##### /DEV.../SIGINS/n/DIFF

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

在单端 (OFF) 和差分 (ON) 测量之间进行切换。

0 off

OFF：单端电压输入

1 on

ON：差分电压输入

##### /DEV..../SIGINS/n/FLOAT

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

在浮动 (ON) 和接地 (OFF) 之间切换输入。此设置适用于电压和电流输入。建议在连接前对测试设备进行放电或仅当信号源在接地模式下连接至信号输入后启用此设置。

0 off

OFF: 接地

1 on

ON: 浮动

##### /DEV..../SIGINS/n/IMP50

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

在  $ 50 \Omega $ (ON) 和  $ 10 M\Omega $ (OFF) 之间进行切换。

0 10_MOhm

OFF: 10 MΩ

##### /DEV..../SIGINS/n/MAX

属性：读取、写入

类型：双

单位：___ 无

指示归一化到输入范围的输入端的最大测量值。

##### /DEV..../SIGINS/n/MIN

属性：读取、写入

类型：双

单位：___ 无

指示归一化到输入范围的输入端的最小测量值。

##### /DEV..../SIGINS/n/ON

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

启用信号输入。

##### /DEV.../SIGINS/n/RANGE

属性：读取、写入、设置

类型：双

单位：V

定义模拟输入放大器的增益。该范围应为输入信号的两倍左右，包括潜在的直流偏移量。仪器会相对于用户插入的值选择下一个较大的可用范围。适当选择此设置可确保使用输入ADC的完整动态范围，从而优化精度和信噪比。

##### /DEV.../SIGINS/n/SCALING

属性：读取、写入、设置

类型：双

单位：___ 无

对输入信号进行给定比例的缩放。

##### /DEV..../SIGINS/n/RANGESTEP/TRIGGER

属性：读取、写入

类型：整数（64位）

单位：___ 无

切换到下一个最适合测量的输入信号幅值的输入范围。

#### 7.2.15. SIGOUTS

##### /DEV..../SIGOUTS/n/ADD

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

将提供给 Aux Input 1（辅助输入 1）的信号添加到信号输出。对于差分输出，添加的信号为共模偏移。

##### /DEV..../SIGOUTS/n/AUTORANGE

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

启用后自动选择最适合的输出范围。

##### /DEV.../SIGOUTS/n/DIFF

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

在单端输出 (OFF) 和差分输出 (ON) 之间切换。在差分模式下，将信号摆幅定义为信号输出 +V / -V 之间。

##### /DEV.../SIGOUTS/n/IMP50

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

在  $ 50 \, \Omega $ 与 HiZ 之间选择负载阻抗。输出的阻抗始终为  $ 50 \, \Omega $。当负载阻抗为  $ 50 \, \Omega $ 时，显示的电压为输出电压的一半，以反映负载处的电压。

0 high_impedance

Hiz

1 50_Ohm 50 Ω

##### /DEV..../SIGOUTS/n/OFFSET

属性：读取、写入、设置

类型：双

单位：V

定义添加到输出信号动态部分的直流电压。

##### /DEV..../SIGOUTS/n/ON

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

启用/禁用信号输出。对应仪器前面板上的蓝色 LED 指示灯。

##### /DEV..../SIGOUTS/n/OVER

属性：读取

类型：整数（64位）

单位：___ 无

指示信号输出已过载。

##### /DEV..../SIGOUTS/n/RANGE

属性：读取、写入、设置

类型：双

单位：V

设置输出电压范围。仪器选择下一个较大的可用范围。

##### /DEV..../SIGOUTS/n/AMPLITUDES/n

属性：读取、写入、设置

类型：双

单位：V

设置分配给给定解调通道的振荡器用于信号输出的峰值幅值。

##### /DEV.../SIGOUTS/n/ENABLES/n

属性：读取、写入、设置

类型：整数（64位）

单位：V

启用单个输出信号幅值。当使用 MD 选件时，可以生成由多个可用解调器频率线性组合的信号。

#### 7.2.16. STATS

##### /DEV.../STATS/CPULOAD

属性：读取

类型：双

单位：%

指示运行数据服务器的机器上的总 CPU 负载。

##### /DEV.../STATS/DATASERVERCPULOAD

属性：读取

类型：双

单位：%

指示数据服务器的 CPU 负载。

##### /DEV..../STATS/DATASERVERMEMLOAD

属性：读取

类型：双

单位：%

指示数据服务器的内存使用情况。

##### /DEV..../STATS/MEMLOAD

属性：读取

类型：双

单位：%

指示运行数据服务器的机器的总体内存使用情况。

##### /DEV.../STATS/CMDSTREAM/BANDWIDTH

属性：读取

类型：双

单位：Mbit/s

在设备和数据服务器之间的物理网络连接上使用的命令流传输带宽。

##### /DEV..../STATS/CMDSTREAM/BYTESRECEIVED

属性：读取

类型：整数（64位）

单位：B

自会话开始以来在命令流上接收的来自设备的字节数。

##### /DEV..../STATS/CMDSTREAM/BYTESSENT

属性：读取

类型：整数（64位）

单位：B

自会话开始以来在命令流上发送的来自设备的字节数。

##### /DEV..../STATS/CMDSTREAM/PACKETSLOST

属性：读取

类型：整数（64位）

单位：___ 无

设备启动后丢失的命令包数。命令包中包含发送到设备和从设备接收的设备设置。

##### /DEV..../STATS/CMDSTREAM/PACKETSRECEIVED

属性：读取

类型：整数（64位）

单位：___ 无

自会话开始以来在命令流上接收的来自设备的数据包数。

##### /DEV.../STATS/CMDSTREAM/PACKETSSENT

属性：读取

类型：整数（64位）

单位：___ 无

自会话开始以来在命令流上发送到设备的数据包数。

##### /DEV.../STATS/CMDSTREAM/PENDING

属性：读取

类型：整数（64位）

单位：___ 无

准备好从设备接收命令包的缓冲区数。

##### /DEV..../STATS/CMDSTREAM/PROCESSING

属性：读取

类型：整数（64位）

单位：___ 无

正在为命令包而接受处理的缓冲区数。如果数值较小，则表示性能适当。对于 TCP/IP 接口，使用 TCP 协议发送命令包。

##### /DEV..../STATS/DATASTREAM/BANDWIDTH

属性：读取

类型：双

单位：Mbit/s

在设备和数据服务器之间的物理网络连接上使用的数据流传输带宽。

##### /DEV..../STATS/DATASTREAM/BYTESRECEIVED

属性：读取

类型：整数（64位）

单位：B

自会话开始以来在数据流上接收的来自设备的字节数。

##### /DEV..../STATS/DATASTREAM/PACKETSLOST

属性：读取

类型：整数（64位）

单位：___ 无

设备启动后丢失的数据包数。数据包中包含测量数据。

##### /DEV..../STATS/DATASTREAM/PACKETSRECEIVED

属性：读取

类型：整数（64位）

单位：___ 无

自会话开始以来在数据流上接收的来自设备的数据包数。

##### /DEV.../STATS/DATASTREAM/PENDING

属性：读取

类型：整数（64位）

单位：___ 无

准备好从设备接收数据包的缓冲区数。

##### /DEV..../STATS/DATASTREAM/PROCESSING

属性：读取

类型：整数（64位）

单位：___ 无

正在为数据包而接受处理的缓冲区数。如果数值较小，则表示性能适当。对于 TCP/IP 接口，使用 UDP 协议发送数据包。

##### /DEV.../STATS/PHYSICAL/FANSPEED

属性：读取

类型：双

单位：RPM

内部冷却风扇的速度。

##### /DEV..../STATS/PHYSICAL/OVERTEMPERATURE

属性：读取

类型：整数（64位）

单位：___ 无

FPGA 温度超过  $ 85^{\circ} $C 后，此标志设为 1。设备重启后，此标志重置为 0。

##### /DEV..../STATS/PHYSICAL/FPGA/AUX

属性：读取

类型：双

单位：V

FPGA 的电源电压。

##### /DEV..../STATS/PHYSICAL/FPGA/CORE

属性：读取

类型：双

单位：V

FPGA 的核心电压。

##### /DEV..../STATS/PHYSICAL/FPGA/TEMP

属性：读取

类型：双

单位： $ ^{\circ} $C

FPGA 的内部温度。

##### /DEV..../STATS/PHYSICAL/TEMPERATURES/n

属性：读取

类型：双

单位： $ ^{\circ} $C

内部温度测量。

##### /DEV..../STATS/PHYSICAL/VOLTAGES/n

属性：读取

类型：双

单位：V

内部电压测量。

#### 7.2.17. STATUS

##### /DEV..../STATUS/ADC0MAX

属性：读取

类型：整数（64位）

单位：___ 无

100 ms 期间 Signal Input 1 (ADC0) 的最大值。

##### /DEV.../STATUS/ADCOMIN

属性：读取

类型：整数（64位）

单位：___ 无

100 ms 期间 Signal Input 1 (ADC0) 的最小值

##### /DEV..../STATUS/ADC1MAX

属性：读取

类型：整数（64位）

单位：___ 无

100 ms 期间 Signal Input 2 (ADC1) 的最大值。

##### /DEV..../STATUS/ADC1MIN

属性：读取

类型：整数（64位）

单位：___ 无

100 ms 期间 Signal Input 2 (ADC1) 的最小值

##### /DEV.../STATUS/FIFOLEVEL

属性：读取

类型：双

单位：___ 无

USB FIFO 级别：指示设备内部 USB FIFO 的填充级别。当填充级别达到 100% 时，数据会丢失

##### /DEV.../STATUS/TIME

属性：读取

类型：整数（64位）

单位：___ 无

当前时间戳。

##### /DEV..../STATUS/FLAGS/BINARY

属性：读取

类型：整数（64位）

单位：___ 无

一组二进制标志，指示设备不同部件的状态。位 0：Signal Input 1 溢出，位 1：Current Input 1 溢出，位 2：Analog PLL 失败，位 3：Output 1 DAC 成功，位 4：Output 2 DAC 成功，位 5：Signal Output 1 削波，位 6：Signal Output 2 削波，位 7：Ext Ref 1 锁定，位 8：Ext Ref 2 锁定，位 9：Ext Ref 3 锁定，位 10：Ext Ref 4 锁定，位 11：Sample Loss，位 12 - 13：Trigger In 1，位 14 -

15：Trigger In 2，位 16-17：Trigger In 3，位 18-19：Trigger In 4，位 20：PLL 1 锁定，位 21：PLL 2 锁定，位 22：PLL 3 锁定，位 23：PLL 4 锁定，位 24：铷钟锁定，位 25：AU Cartesian 1 溢出，位 26：AU Cartesian 2 溢出，位 27：AU Polar 1 溢出，位 28：AU Polar 2 溢出。

##### /DEV.../STATUS/FLAGS/PACKETLOSSTCP

属性：读取

类型：整数（64位）

单位：___ 无

指示 TCP 数据包是否丢失的标志。

##### /DEV.../STATUS/FLAGS/PACKETLOSSUDP

属性：读取

类型：整数（64位）

单位：___ 无

指示 UDP 数据包是否丢失的标志。

#### 7.2.18. SYSTEM

##### /DEV..../SYSTEM/ACTIVEINTERFACE

属性：读取

类型： 字符串

单位：___ 无

设备当前激活的接口。

##### /DEV..../SYSTEM/EXTCLK

属性：读取、写入、设置

类型：整数（枚举）

10 MHz 参考时钟源。

单位：___ 无

0 internal

使用内部 10 MHz 时钟作为频率和时基参考。

1 external

使用外部 10 MHz 时钟作为频率和时基参考。为相应的后面板连接器提供干净且稳定的 10 MHz 参考。

##### /DEV..../SYSTEM/FPGAREVISION

属性：读取

类型：整数（64位）

单位：___ 无

HDL 固件版本。

##### /DEV..../SYSTEM/FWLOG

属性：读取

类型： 字符串

单位：___ 无

返回固件的日志输出。

##### /DEV..../SYSTEM/FWLOGENABLE

属性：读取、写入

类型：整数（64位）

单位：___ 无

启用 fwlog 节点的日志记录。

##### /DEV..../SYSTEM/FWREVISION

属性：读取

类型：整数（64位）

单位：___ 无

设备内部控制器软件的版本。

##### /DEV..../SYSTEM/IDENTIFY

属性：读取、写入

类型：整数（64位）

单位：___ 无

将此节点设为 1 将导致设备的电源 LED 灯持续闪烁数秒。

##### /DEV.../SYSTEM/INTERFACESPEED

属性：读取

类型： 字符串

单位：___ 无

当前活动接口（仅 USB）的速度。

##### /DEV.../SYSTEM/JUMBO

属性：读取、写入

类型：整数（64位）

单位：___ 无

在 TCP/IP 接口上启用巨型帧 (4k)。这将减少 PC 上的负载，并且是实现最大吞吐量的必要条件。确保网卡上也启用了巨型帧 (4k)。如果网络上的某个设备无法使用巨型帧，则连接将失败。

##### /DEV..../SYSTEM/OWNER

属性：读取

类型： 字符串

单位：___ 无

返回设备的当前所有者 (IP)。

##### /DEV.../SYSTEM/PORTTCP

属性：读取、写入

类型：整数（64位）

单位：___ 无

返回用于与数据服务器通信的当前 TCP 端口。

##### /DEV.../SYSTEM/PORTUDP

属性：读取、写入

类型：整数（64位）

单位：___ 无

返回用于与数据服务器通信的当前 UDP 端口。

##### /DEV..../SYSTEM/PREAMPENABLE

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

启用前置放大器。

##### /DEV.../SYSTEM/SAVEPORTS

属性：读取、写入

类型：整数（64位）

单位：___ 无

指示应保存 TCP 和 UDP 端口的标志。

##### /DEV..../SYSTEM/SHUTDOWN

属性：读取、写入

类型：整数（64位）

单位：___ 无

向此节点发送“1”将启动 MFLI 设备操作系统的关闭。建议在使用设备背面的硬件开关关闭设备之前触发此关机动作。

##### /DEV.../SYSTEM/STALL

属性：读取、写入

类型：整数（64位）

单位：___ 无

指示网络连接是否停止。

##### /DEV.../SYSTEM/BOARDREVISIONS/n

属性：读取

类型： 字符串

单位：___ 无

FPGA 基板的硬件版本

##### /DEV..../SYSTEM/COMPDELAY/CALIBRATE

属性：读取、写入

类型：整数（64位）

单位：___ 无

执行输入延迟补偿的自动校准。

##### /DEV..../SYSTEM/IMPEDANCE/APPLICATION

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

选择 Impedance（阻抗）应用

0 Icr

LCR 阻抗测量：用于在有限频率下测量阻抗的通用设置。

1 dc

DC 阻抗测量：用于在频率为零时测量电阻的设置。

##### /DEV.../SYSTEM/IMPEDANCE/FILTER

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

在基于应用的阻抗设置或手动配置的阻抗设置之间切换。通过切换为 Advanced（高级）模式，可以微调 Application（应用）模式给出的参数集。切换回 Application（应用）模式将会复位参数。

0 application

应用：根据所选应用对阻抗设置进行最为合适的调整。

1 advanced

高级：手动配置阻抗设置。

##### /DEV.../SYSTEM/IMPEDANCE/PRECISION

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

通过自动调整滤波器带宽来选择阻抗精度和测量速度。如果参数扫描仪模块处于阻抗应用模式，则精度设置还将控制参数扫描仪的测量速度。

0 low

低→快速稳定：低精度/准确度，快速扫描（经过优化加速响应）。

1 high

高→中速稳定：高精度/准确度，中速扫描（需要较长时间达到稳定）。

2 very_high

超高 → 低速稳定：超高精度/准确度，慢速扫描（由于带宽极低，需要更长时间达到稳定）。

##### /DEV.../SYSTEM/PRESET/BUSY

属性：读取

类型：整数（64位）

单位：___ 无

指示当前是否加载预设。

##### /DEV.../SYSTEM/PRESET/DEFAULT

属性：读取、写入

类型：整数（枚举）

单位：___ 无

指示在设备启动时用作默认预设的预设。

0 factory

选择出厂预设作为默认预设。

1 选择存储在内部闪存位置 1 中的预设作为默认预设。

2 选择存储在内部闪存位置 2 中的预设作为默认预设。

3 选择存储在内部闪存位置 3 中的预设作为默认预设。

4 选择存储在内部闪存位置 4 中的预设作为默认预设。

5 选择存储在内部闪存位置 5 中的预设作为默认预设。

6 选择存储在内部闪存位置 6 中的预设作为默认预设。

##### /DEV.../SYSTEM/PRESET/ERASE

属性：读取、写入

类型：整数（64位）

单位：___ 无

擦除所选预设。

##### /DEV..../SYSTEM/PRESET/ERROR

属性：读取

类型：整数（64位）

单位：___ 无

指示最后一次操作是否非法。成功：0，错误：1。

##### /DEV.../SYSTEM/PRESET/INDEX

属性：读取、写入

类型：整数（枚举）

单位：___ 无

在出厂预设或存储在内部闪存中的预设之间进行选择。

0 factory

选择出厂预设。

1 选择存储在内部闪存位置 1 中的预设。

2 选择存储在内部闪存位置 2 中的预设。

3 选择存储在内部闪存位置 3 中的预设。

4 选择存储在内部闪存位置 4 中的预设。

5 选择存储在内部闪存位置 5 中的预设。

6 选择存储在内部闪存位置 6 中的预设。

##### /DEV.../SYSTEM/PRESET/LOAD

属性：读取、写入

类型：整数（64位）

单位：___ 无

加载所选预设。

##### /DEV.../SYSTEM/PRESET/SAVE

属性：读取、写入

类型：整数（64位）

单位：___ 无

将实际设置保存为预设。

##### /DEV..../SYSTEM/PROPERTIES/FREQRESOLUTION

属性：读取

类型：整数（64位）

单位：___ 无

用于表示频率的位数。

##### /DEV..../SYSTEM/PROPERTIES/FREQSCALING

属性：读取

类型：双

单位：___ 无

用于将表示为频率分辨率位整数的频率转换为浮点值的比例因子。

##### /DEV..../SYSTEM/PROPERTIES/MAXFREQ

属性：读取

类型：双

单位：___ 无

可设置的最大振荡器频率。

##### /DEV..../SYSTEM/PROPERTIES/MAXTIMECONSTANT

属性：读取

类型：双

单位：___ 无

可设置的最大解调器时间常数。

##### /DEV..../SYSTEM/PROPERTIES/MINFREQ

属性：读取

类型：双

单位：___ 无

可设置的最小振荡器频率。

##### /DEV..../SYSTEM/PROPERTIES/MINTIMECONSTANT

属性：读取

类型：双

单位：___ 无

可设置的最小解调器时间常数。

##### /DEV.../SYSTEM/PROPERTIES/NEGATIVEFREQ

属性：读取

类型：整数（64位）

单位：___ 无

指示是否支持负频率。

##### /DEV..../SYSTEM/PROPERTIES/TIMEBASE

属性：读取

类型：双

单位 s

两个时间戳之间的最小时差。该值等于 1/（最大采样率）。

##### /DEV..../SYSTEM/COMPDELAY/DELAYS/n

属性：读取、写入

类型：整数（64位）

单位：___ 无

当前的补偿延迟值。0：信号输入 0，1：信号输入 1，2：辅助输入，3：触发输入，4：回路

##### /DEV..../SYSTEM/IMPEDANCE/CALIB/CABLELENGTH

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

测量设置中使用的（单向）电缆长度。

0 off

Off: 电缆长度补偿已关闭。

1 1_m

电缆长度设为 1 m。

2 2_m

电缆长度设为 2 m。

3 3_m

电缆长度设为 3 m。

##### /DEV..../SYSTEM/NICS/n/DEFAULTGATEWAY

属性：读取、写入

类型： 字符串

单位：___ 无

网络连接的默认网关配置。

##### /DEV.../SYSTEM/NICS/n/DEFAULTP4

属性：读取、写入

类型： 字符串

单位：___ 无

启用静态 IP 时使用的设备 IPv4 地址。

##### /DEV.../SYSTEM/NICS/n/DEFAULTMASK

属性：读取、写入

类型： 字符串

单位：___ 无

使用静态 IP 时的 IPv4 掩码。

##### /DEV..../SYSTEM/NICS/n/GATEWAY

属性：读取

类型： 字符串

单位：___ 无

当前网络网关。

##### /DEV..../SYSTEM/NICS/n/IP4

属性：读取

类型： 字符串

单位：___ 无

设备的当前 IPv4。

##### /DEV..../SYSTEM/NICS/n/JUMBO

属性：读取、写入

类型：整数（64位）

单位： 无

已存储的巨型帧设置。将在重启后应用。

##### /DEV.../SYSTEM/NICS/n/MAC

属性：读取

类型： 字符串

单位：___ 无

设备网络接口的当前 MAC 地址。

##### /DEV..../SYSTEM/NICS/n/MASK

属性：读取

类型： 字符串

单位：___ 无

当前网络掩码。

##### /DEV.../SYSTEM/NICS/n/SAVEIP

属性：读取、写入

类型：整数（64位）

单位：___ 无

如果写入，此操作将为设备编程定义的静态 IP 地址。

##### /DEV.../SYSTEM/NICS/n/STATIC

属性：读取、写入

类型：整数（64位）

单位：___ 无

如果在没有 DHCP 服务器的情况下在具有固定 IP 分配的网络中使用此设备，请启用此标志。

##### /DEV.../SYSTEM/UPDATE/LABONE/BUSY

属性：读取

类型：整数（64位）

单位：___ 无

设备正在更新。

##### /DEV.../SYSTEM/UPDATE/LABONE/DATA

属性：读取、写入

类型： ZIVectorData

单位： 无

接收二进制文件以更新设备的节点。

##### /DEV.../SYSTEM/UPDATE/LABONE/DONE

属性：读取

类型：整数（64位）

单位：___ 无

更新已完成。

##### /DEV..../SYSTEM/UPDATE/LABONE/ERROR

属性：读取

类型：整数（64位）

单位：___ 无

更新过程中发生错误。

##### /DEV.../SYSTEM/UPDATE/LABONE/PROGRESS

属性：读取

类型：双

单位：___ 无

指示更新进度的介于 0 到 1 之间的值。

##### /DEV..../SYSTEM/UPDATE/LABONE/START

属性：读取、写入

类型：整数（64位）

单位：___ 无

如果设为 1，则设备开始更新。

##### /DEV...

##### ./SYSTEM/IMPEDANCE/CALIB/INTERNAL/ALLOWSMOOTHING

属性：读取、写入

类型：整数（64位）

单位：___ 无

指示是否可对设备内部补偿数据应用平滑处理。

##### /DEV..../SYSTEM/IMPEDANCE/CALIB/INTERNAL/DATA

属性：读取、写入

类型：ZIVectorData

单位：___ 无

包含二进制格式的用户补偿数据。

##### /DEV.../SYSTEM/IMPEDANCE/CALIB/INTERNAL/INFO

属性：读取

类型： 字符串

单位：___ 无

包含有关设备内部补偿数据的一般信息。

##### /DEV..../SYSTEM/IMPEDANCE/CALIB/INTERNAL/STORE

属性：读取、写入

类型：整数（64位）

单位：___ 无

将补偿数据永久存储在设备上。每次通电时都会自动加载补偿数据。

##### /DEV.../SYSTEM/IMPEDANCE/CALIB/INTERNAL/VALID

属性：读取、写入

类型：整数（64位）

单位：___ 无

指示设备内部校准数据是否有效（1 = 有效，0 = 无效）。

##### /DEV.../SYSTEM/IMPEDANCE/CALIB/USER/ALLOWSMOOTHING

属性：读取、写入

类型：整数（64位）

单位：___ 无

指示是否可对设备校准数据应用平滑处理。

##### /DEV..../SYSTEM/IMPEDANCE/CALIB/USER/DATA

属性：读取、写入

类型： ZIVectorData

单位：___ 无

包含二进制格式的用户补偿数据。

##### /DEV..../SYSTEM/IMPEDANCE/CALIB/USER/INFO

属性：读取

类型： 字符串

单位：___ 无

包含有关用户补偿数据的一般信息。

##### /DEV.../SYSTEM/IMPEDANCE/CALIB/USER/VALID

属性：读取、写入

类型：整数（64位）

单位：___ 无

指示用户补偿数据是否有效（1 = 有效，0 = 无效）。

##### /DEV..../SYSTEM/IMPEDANCE/FREQLIMIT2T/n/FREQ

属性：读取

类型：双

单位：无

指示用于 2 端子阻抗测量的频率范围限值。

##### /DEV.../SYSTEM/IMPEDANCE/FREQLIMIT2T/n/RANGE

属性：读取

类型：双

单位：___ 无

指示在频率等于或高于相应频率节点的值时，可用于 2 端子阻抗测量的最小输入电流范围。

##### /DEV..../SYSTEM/IMPEDANCE/FREQLIMIT4T/n/FREQ

属性：读取

类型：双

单位：___ 无

指示用于 4 端子阻抗测量的频率范围限值。

##### /DEV.../SYSTEM/IMPEDANCE/FREQLIMIT4T/n/RANGE

属性：读取

类型：双

单位：___ 无

指示在频率等于或高于相应频率节点的值时，可用于 4 端子阻抗测量的最小输入电流范围。

##### /DEV..../SYSTEM/PRESET/RECORDS/n/FEATURES

属性：读取

类型：整数（64位）

单位：___ 无

预设的属性。

##### /DEV..../SYSTEM/PRESET/RECORDS/n/LABEL

属性：读取、写入

类型： 字符串

单位：___ 无

此预设的名称。

##### /DEV.../SYSTEM/PRESET/RECORDS/n/TIMESTAMP

属性：读取、写入

类型：整数（64位）

单位：___ 无

未使用。

##### /DEV..../SYSTEM/PRESET/RECORDS/n/VALID

属性：读取

类型：整数（64位）

单位：___ 无

如果有效预设已存储，则为真。

#### 7.2.19. TRIGGERS

##### /DEV..../TRIGGERS/IN/n/AUTOTHRESHOLD

属性：读取、写入

类型：整数（64位）

单位：___ 无

自动调整触发阈值。电平经调整后会处于目标电平转换的中心电平位置。

##### /DEV..../TRIGGERS/IN/n/LEVEL

属性：读取、写入、设置

类型：双

单位：V

使触发输入在低电平和高电平之间切换的触发电压电平。对数字输入使用 50% 的幅值，并考虑触发滞后情况。

##### /DEV..../TRIGGERS/OUT/n/PULSEWIDTH

属性：读取、写入、设置

类型：双

单位 s

定义在将示波器事件写入设备的触发输出时的最小脉宽。

##### /DEV..../TRIGGERS/OUT/n/SOURCE

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

选择分配给触发输出的信号。

0 disabled

禁用输出触发。

1 demod1_phase

demod 2（触发输出通道 1）或 demod 4（触发输出通道 2）的振荡器相位。

2 scope_trigger

示波器触发器。需安装 DIG 选件。

3 scope_not_trigger

示波器/触发器。需安装 DIG 选件。

4 scope_armed

示波器配置完毕。需安装 DIG 选件。

5 scope_not_armed

示波器/配置完毕。需安装 DIG 选件。

6 scope_active

示波器活动。需安装 DIG 选件。

7 scope_not_active

示波器/活动。需安装 DIG 选件。

36 th_logic_unit0_out

阈值逻辑单元 1 输出。

37 th_logic_unit1_out 阈值逻辑单元 2 输出。

38 th_logic_unit2_out 阈值逻辑单元 3 输出。

39 th_logic_unit3_out

阈值逻辑单元 4 输出。

52 mds_sync_out MDS 同步输出。

#### 7.2.20. TU（阈值单元）

##### /DEV..../TU/LOGICUNITS/n/INTERNALVALUE

属性：读取

类型：整数（64位）

单位：___ 无

显示逻辑组合之后、输出设置之前的值。该值为经过一段时间整合的值。值为 1：低，2：高，3：期间有高有低。

##### /DEV..../TU/LOGICUNITS/n/INVERT

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

将输出信号更改为低电平有效。

##### /DEV.../TU/LOGICUNITS/n/KEEP

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

输出状态切换为激活状态后，便会无限期保持。

##### /DEV.../TU/LOGICUNITS/n/PULSEWIDTH

属性：读取、写入、设置

类型：双

单位 s

生成的输出信号的最小脉冲宽度。短于此时间的脉冲宽度将会被延长。

##### /DEV..../TU/LOGICUNITS/n/VALUE

属性：读取

类型：整数（64位）

单位： 无

显示逻辑单元的输出值。该值为经过一段时间整合的值。值为 1：低，2：高，3：期间有高有低。

##### /DEV..../TU/THRESHOLDS/n/ACTIVATIONTIME

属性：读取、写入、设置

类型：双

单位 s

激活输出之前需要违反阈值要求的最短持续时间。此参数可用作毛刺滤波器。

##### /DEV..../TU/THRESHOLDS/n/DEACTIVATIONTIME

属性：读取、写入、设置

类型：双

单位 s

禁用输出之前需要满足阈值要求的最短持续时间。

##### /DEV..../TU/THRESHOLDs/n/INPUT

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

选择阈值单元中将使用的信号源。

0  $ \text{demod\_x} $

1  $ \text{Demod X} $

1  $ \text{demod\_y} $

1  $ \text{Demod Y} $

2  $ \text{demod\_r} $

 $ \text{Demod R} $

3  $ \text{demod\_theta} $

 $ \text{Demod Theta} $

5  $ \text{pid\_out} $

 $ \text{PID Out} $

6  $ \text{boxcar} $

 $ \text{Boxcar} $

7  $ \text{au\_cartesian} $

 $ \text{AU Cartesian} $

8  $ \text{au\_polar} $

 $ \text{AU Polar} $

9  $ \text{pid\_shift} $

 $ \text{PID Shift} $

10  $ \text{pid\_error} $

 $ \text{PID Error} $

50  $ \text{dio} $

 $ \text{DIO} $

51  $ \text{trigin, trigger\_input} $

 $ \text{Trigger In} $

52  $ \text{trigout, trigger\_output} $

 $ \text{Trigger Out} $

53  $ \text{input\_overload\_v} $

 $ \text{Input Overload (V)} $

54  $ \text{input\_overload\_i} $

 $ \text{Input Overload (I)} $

55  $ \text{output\_overload} $

 $ \text{Output Overload} $

56  $ \text{auxin\_overload, auxiliary\_input\_overload} $

 $ \text{Aux input Overload} $

57  $ \text{auxout\_overload, auxiliary\_output\_overload} $

 $ \text{Aux Output Overload} $

58  $ \text{pid\_output\_overload} $

 $ \text{PID Output Overload} $

59  $ \text{tu\_output} $

 $ \text{TU Output Value} $

##### /DEV.../TU/THRESHOLDs/n/INPUTCHANNEL

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

根据所选信号源选择通道。

##### /DEV.../TU/THRESHOLDs/n/INTERNALVALUE

属性：读取

类型：整数（64位）

单位：依赖

显示阈值之后、最短时间之前的值。该值为经过一段时间整合的值。值为 1：低，2：高，3：期间有高有低。

##### /DEV..../TU/THRESHOLDs/n/VALUE

属性：读取

类型：整数（64位）

单位：依赖

显示阈值输出端的阈值数值。该值为经过一段时间整合的值。值为 1：低，2：高，3：期间有高有低。

##### /DEV.../TU/LOGICUNITS/n/INPUTS/n/CHANNEL

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

选择要用作输入的阈值通道。

##### /DEV.../TU/LOGICUNITS/n/INPUTS/n/NOT

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

将输入信号取反。

##### /DEV..../TU/LOGICUNITS/n/OPS/n/VALUE

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

应用于控件左侧和右侧信号的逻辑运算。

0 off

未选择任何逻辑运算。生成输出时未使用任何附加信号。

1 and

使用逻辑与运算。

2 or

使用逻辑或运算。

3 xor

使用逻辑异或运算。

##### /DEV..../TU/THRESHOLDs/n/FILTER/ABS

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

取模拟输入信号的绝对值。

##### /DEV..../TU/THRESHOLDS/n/FILTER/ENABLE

属性：读取

类型：整数（64位）

单位：___ 无

启用应用于模拟输入信号的低通滤波器

##### /DEV..../TU/THRESHOLDS/n/FILTER/FILTEREDVALUE

属性：读取

类型：双

单位：依赖

显示经过低通滤波器滤波后的值。

##### /DEV..../TU/THRESHOLDs/n/FILTER/MODE

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

选择用于定义输出信号的分析模式。

0 above_upper

    在信号高于阈值上限时启用。

1 below_lower

    在信号低于阈值下限时启用。

2 outside_range

    在信号超出范围[阈值下限,阈值上限]时启用。

3 crossing_both_rising

    在信号从低于阈值下限的位置上升到阈值上限时启用。阈值上限与阈值下限之差定义阈值滞后。

4 crossing_both_falling

在信号从高于阈值上限的位置下降到阈值下限时启用。阈值上限与阈值下限之差定义阈值滞后。

##### /DEV..../TU/THRESHOLDs/n/FILTER/THRESHOLDHigh

属性：读取、写入、设置

类型：双

单位：依赖

用于生成输出的阈值上限。在 Falling Edge（下降沿）模式下，此参数定义滞后性能，因为输出状态仅在信号从低于阈值下限的位置上升到阈值上限时复位。

##### /DEV..../TU/THRESHOLDS/n/FILTER/THRESHOLDLOW

属性：读取、写入、设置

类型：双

单位：依赖

用于生成输出的阈值下限。在 Rising Edge（上升沿）模式下，此参数定义滞后性能，因为输出状态仅在信号从高于阈值上限的位置下降到阈值下限时复位。

##### /DEV..../TU/THRESHOLDs/n/FILTER/TIMECONSTANT

属性：读取、写入、设置

类型：双

单位 s

定义应用于模拟输入信号的低通滤波器的特性时间常数（截止）。

#### 7.2.21. ZI（LabOne 数据服务器节点）

##### /ZI/ABOUT/COMMIT

属性：读取

类型： 字符串

单位：___ 无

包含用于构建此版本 LabOne 软件的源代码的提交哈希值。

##### /ZI/ABOUT/COPYRIGHT

属性：读取

类型： 字符串

单位：___ 无

持有版权声明。

##### /ZI/ABOUT/DATASERVER

属性：读取

类型： 字符串

单位：___ 无

包含有关 Zurich Instruments 数据服务器的信息。

##### /ZI/ABOUT/FWREVISION

属性：读取

类型：整数（64位）

单位：___ 无

包含设备固件的修订版本。

##### /ZI/ABOUT/REVISION

属性：读取

类型：整数（64位）

单位：___ 无

包含 Zurich Instruments 数据服务器的修订号。

##### /ZI/ABOUT/VERSION

属性：读取

类型： 字符串

单位：无

包含 LabOne 软件的版本。

##### /ZI/CLOCKBASE

属性：读取

类型：双

单位：___ 无

一种回退时钟频率，可在客户端没有其他可用的时钟频率时用于计算时基。

##### /ZI/CONFIG/OPEN

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

支持从网络中的其他计算机与 LabOne 数据服务器通信。

0 本地

仅可与本地机器通信。

1 网络

可以与网络中的其他机器通信。

##### /ZI/CONFIG/PORT

属性：读取

类型：整数（64位）

单位：___ 无

LabOne 数据服务器监听的 IP 端口。

##### /ZI/DEBUG/LEVEL

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

设置 LabOne 数据服务器的日志级别（详细程度）。

0 trace

迹线。记录指定为迹线的消息。

1 debug

调试。记录指定为调试信息的消息。

2 info

信息。记录指定为信息的消息。

3 status

状态。记录指定为状态信息的消息。

4 warning

警告。记录指定为警告的消息。

5 error

错误。记录指定为错误的消息。

6 fatal

致命。记录指定为致命错误的消息。

##### /ZI/DEBUG/LOG

属性：读取

类型： 字符串

单位：___ 无

返回 LabOne 数据服务器的日志文件文本。

##### /ZI/DEBUG/LOGPATH

属性：读取

类型： 字符串

单位：___ 无

返回日志目录的路径。

##### /ZI/DEVICES/CONNECTED

属性：读取

类型： 字符串

单位：___ 无

包含连接到 LabOne 数据服务器的设备的清单。

##### /ZI/DEVICES/DISCOVER

属性：读取、写入

类型： 字符串

单位：___ 无

未使用。

##### /ZI/DEVICES/VISIBLE

属性：读取

类型： 字符串

单位：___ 无

包含网络中 LabOne 数据服务器可见的设备的清单。

##### /ZI/MDS/GROUPS/n/DEVICES

属性：读取、写入、设置

类型： 字符串

单位：___ 无

##### /ZI/MDS/GROUPS/n/KEEPALIVE

包含属于此同步组的设备的清单。

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

由 MDS 模块设置，以指示对此同步组的控制。

##### /ZI/MDS/GROUPS/n/LOCKED

属性：读取、写入、设置

类型：整数（64位）

单位：___ 无

指示设备组是否由 MDS 模块锁定。

##### /ZI/MDS/GROUPS/n/STATUS

属性：读取、写入、设置

类型：整数（枚举）

单位：___ 无

指示同步组的状态。

-1 错误。同步过程中发生错误。

0 新建

1 同步

2 带电

##### /ZI/SYSTEM/USAGEDATA

属性：读取

类型： 字符串

单位：___ 无

包含一个 JSON 格式字符串，提供有关 LabOne 软件的使用信息（使用哪些选项卡、模块，以及错误情况）。

### 术语表

本术语表提供众多测量仪器相关术语（包括本用户手册中使用的缩写）的简单易懂的描述。



<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>A</td><td style='text-align: center; word-wrap: break-word;'>模拟到数字。另请参见 ADC。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>AC</td><td style='text-align: center; word-wrap: break-word;'>交流电</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>ADC</td><td style='text-align: center; word-wrap: break-word;'>模数转换器</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>AM</td><td style='text-align: center; word-wrap: break-word;'>调幅</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>调幅 AFM (AM-AFM)</td><td style='text-align: center; word-wrap: break-word;'>原子力显微镜 (AFM) 模式下，以驱动信号和测量信号之间的幅值变化编码形貌图或测量的 AFM 变量。另请参见原子力显微镜。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>API</td><td style='text-align: center; word-wrap: break-word;'>应用程序编程接口</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>ASCII</td><td style='text-align: center; word-wrap: break-word;'>美国信息交换标准代码</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>原子力显微镜 (AFM)</td><td style='text-align: center; word-wrap: break-word;'>通过振荡式机械结构（例如悬臂、音叉）扫描表面的显微镜，其振荡尖头在静电、化学、磁力或其他力的作用下非常接近表面，从而进入相互作用状态。借助 AFM 就可能生成具有原子分辨率的图像。另请参见调幅 AFM、调频 AFM、调相 AFM。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>AVAR</td><td style='text-align: center; word-wrap: break-word;'>阿伦方差</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>B</td><td style='text-align: center; word-wrap: break-word;'>信号带宽表示信号中期望的最高频率分量。滤波器的信号带宽就是截止点，此时系统的传递函数相对于 DC 显示 3 dB 的衰减。在这种情况下，带宽就是截止频率  $ f_{cut-off} $ 或 3 dB 频率  $ f_{3dB} $ 的同义词。带宽的概念用于信号的动态行为很重要或需要分离不同信号的情况。在开环或闭环系统中，带宽可用于指示系统的最快速度或系统可实现的最高信号更新变化速率。有时，带宽这一术语会被错误地用作频率范围的同义词。另请参见噪声等效功率带宽。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>BNC</td><td style='text-align: center; word-wrap: break-word;'>尼尔-康塞曼卡口连接器</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>C</td><td style='text-align: center; word-wrap: break-word;'>时钟故障（内部处理器时钟丢失）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>CF</td><td style='text-align: center; word-wrap: break-word;'>差分放大器（或其他设备）的规格，指示放大器在抑制与信号无差异的分量（共模）的同时，获得两个输入之差的能力。在期望信号由叠加在（可能较大的）电压偏移上的较小电压波动表示时，或者当相关信息包含在两个信号之间的电压差值中时，必须具有较高的 CMRR。共模抑制比率最简单的数学定义是： $ CMRR = 20 \times \log \left(\frac{\text{差分增益}}{\text{共模增益}}\right) $。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>CSV</td><td style='text-align: center; word-wrap: break-word;'>逗号分隔值</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>D</td><td style='text-align: center; word-wrap: break-word;'>数字到模拟</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>DAC</td><td style='text-align: center; word-wrap: break-word;'>数模转换器</td></tr></table>

DC 直流电

DDS 直接数字合成

DHCP 动态主机配置协议

DIO 数字输入/输出

DNS 域名服务器

DSP 数字信号处理器

DUT 被测设备

动态储备 (DR) 锁相放大器在非参考频率下承受干扰信号和噪声，同时在信号带宽内保持指定测量精度的能力的度量。

##### E

XML 可扩展标记语言。

另请参见 XML。

##### F

FFT 快速傅里叶变换

FIFO 先进先出

FM 调频

频率准确度 (FA) 仪器对照可追踪标准如实指示正确频率的能力的度量。

调频 AFM (FM-AFM) 原子力显微镜 (AFM) 模式下，以驱动信号和测量信号之间的频率变化编码形貌图或测量的 AFM 变量。

频率响应分析仪

能够刺激被测设备并以细粒度绘制可选频率范围内的频率响应的仪器。

频率参数扫描仪

另请参见频率响应分析仪。

#### G

增益相位计

另请参见矢量网络分析仪。

GPIB

通用接口总线

GUI

图形用户界面

### I

I/O

输入/输出

阻抗谱仪 (IS)

适合刺激被测设备并在可选频率下（通过电流测量）测量阻抗及其幅值和相位随时间变化的仪器。输出内容为与刺激信号相关的幅值和相位信息。

输入幅值精度 (IAA) 仪器对照可追踪标准如实指示输入通道中的信号幅值的能力的度量。

输入电压噪声 仪器产生的总噪声，所指为信号输入，因此表示为测量信号的额外噪声源。

IP 互联网协议

L

LAN 局域网



<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>LED</td><td style='text-align: center; word-wrap: break-word;'>发光二极管</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>锁相放大器（LI、LIA）</td><td style='text-align: center; word-wrap: break-word;'>适用于采集噪声环境中的微弱信号或快速变化且具有良好信噪比的信号的仪器。锁相放大器通过以合适的参考频率进行解调来恢复已知信号频率的期望信号。解调得出信号与参考信号相比的幅值和相位：复平面（X, Y）、（R,  $ \Theta $）中的值对。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>M</td><td style='text-align: center; word-wrap: break-word;'></td></tr><tr><td style='text-align: center; word-wrap: break-word;'>媒体访问控制地址（MAC 地址）</td><td style='text-align: center; word-wrap: break-word;'>是指为进行物理网络通信而分配给网络适配器的唯一标识符。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>多频（MF）</td><td style='text-align: center; word-wrap: break-word;'>是指同时测量以任意频率调制的信号。多频的目的一是增加可从测量中得到的信息，这对一次性的不重复事件特别重要，二是提高测量的速度，因为无需一个接一个地应用不同的频率。另请参见多谐波。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>多谐波（MH）</td><td style='text-align: center; word-wrap: break-word;'>是指同时测量以不同谐波频率调制的信号。多频的目的一是增加可从测量中得到的信息，这对一次性的不重复事件特别重要，二是提高测量的速度，因为无需一个接一个地应用不同的频率。另请参见多频。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>N</td><td style='text-align: center; word-wrap: break-word;'></td></tr><tr><td style='text-align: center; word-wrap: break-word;'>噪声等效功率带宽（NEPBW）</td><td style='text-align: center; word-wrap: break-word;'>考虑频谱中低通滤波器传递函数下方面积的有效带宽。NEPBW 用于某一带宽内的功率量很重要的情况，例如噪声测量。与该单位对应的是在等效频率下具有无限陡度的完美滤波器。另请参见带宽。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>奈奎斯特频率（NF）</td><td style='text-align: center; word-wrap: break-word;'>对于采样模拟信号，奈奎斯特频率相当于信号转换后正确表示的最高频率分量的两倍。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>O</td><td style='text-align: center; word-wrap: break-word;'></td></tr><tr><td style='text-align: center; word-wrap: break-word;'>输出幅值精度（OAA）</td><td style='text-align: center; word-wrap: break-word;'>仪器对照可追踪标准在给定频率下如实输出设定电压的能力的度量。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>OV</td><td style='text-align: center; word-wrap: break-word;'>过电压（信号输出饱和与信号削波）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>P</td><td style='text-align: center; word-wrap: break-word;'></td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PC</td><td style='text-align: center; word-wrap: break-word;'>个人计算机</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PD</td><td style='text-align: center; word-wrap: break-word;'>相位检测器</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>锁相环（PLL）</td><td style='text-align: center; word-wrap: break-word;'>用于跟踪和控制指定频率的电子电路。为此生成外部信号的副本，其与原始信号同相但通常具有更好的频谱特性。它可用于频率稳定、频率倍增或频率恢复。在模拟和数字实现中，它都由相位检测器、环路滤波器、控制器和振荡器组成。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>调相 AFM（PM-AFM）</td><td style='text-align: center; word-wrap: break-word;'>AFM 模式下，以驱动信号和测量信号之间的相位编码形貌图或测量的 AFM 变量。另请参见原子力显微镜。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PID</td><td style='text-align: center; word-wrap: break-word;'>比例-积分-微分</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>PL</td><td style='text-align: center; word-wrap: break-word;'>数据包丢失（仪器和主机之间的数据包丢失）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>R</td><td style='text-align: center; word-wrap: break-word;'></td></tr><tr><td style='text-align: center; word-wrap: break-word;'>RISC</td><td style='text-align: center; word-wrap: break-word;'>精简指令集计算机</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>均方根（RMS）</td><td style='text-align: center; word-wrap: break-word;'>变化量的大小的统计量度。尤其适用于变量具有正负数值（例如正弦波、锯齿波、方波）的情况，对于正弦波、幅值和 RMS 值之间存在</td></tr></table>

RISC

精简指令集计算机

均方根 (RMS)

变化量的大小的统计量度。尤其适用于变量具有正负数值（例如正弦波、锯齿波、方波）的情况。对于正弦波，幅值和 RMS 值之间存在以下关系： $ U_{RMS} = U_{PK} / \sqrt{2} = U_{PK} / 1.41 $。RMS 也称为均方值。



<table border=1 style='margin: auto; word-wrap: break-word;'><tr><td style='text-align: center; word-wrap: break-word;'>RT</td><td style='text-align: center; word-wrap: break-word;'>实时</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>S</td><td style='text-align: center; word-wrap: break-word;'></td></tr><tr><td style='text-align: center; word-wrap: break-word;'>标量网络分析仪 (SNA)</td><td style='text-align: center; word-wrap: break-word;'>测量仅提供幅值（增益）信息的模拟输入信号电压的仪器。另请参见频谱分析仪、矢量网络分析仪。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>SL</td><td style='text-align: center; word-wrap: break-word;'>样本丢失（仪器和主机之间的样本丢失）</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>频谱分析仪 (SA)</td><td style='text-align: center; word-wrap: break-word;'>测量仅提供指定频谱内的幅值（增益）信息的模拟输入信号电压的仪器。另请参见标量网络分析仪。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>SSH</td><td style='text-align: center; word-wrap: break-word;'>安全外壳</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>T</td><td style='text-align: center; word-wrap: break-word;'></td></tr><tr><td style='text-align: center; word-wrap: break-word;'>TC</td><td style='text-align: center; word-wrap: break-word;'>时间常数</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>TCP/IP</td><td style='text-align: center; word-wrap: break-word;'>传输控制协议/互联网协议</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>线程</td><td style='text-align: center; word-wrap: break-word;'>由处理器执行的独立指令序列。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>总谐波失真 (THD)</td><td style='text-align: center; word-wrap: break-word;'>信号通道（输入和输出）非线性的度量</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>TTL</td><td style='text-align: center; word-wrap: break-word;'>晶体管-晶体管逻辑电平</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>U</td><td style='text-align: center; word-wrap: break-word;'></td></tr><tr><td style='text-align: center; word-wrap: break-word;'>UHF</td><td style='text-align: center; word-wrap: break-word;'>超高频率</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>UHS</td><td style='text-align: center; word-wrap: break-word;'>超高稳定性</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>USB</td><td style='text-align: center; word-wrap: break-word;'>通用串行总线</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>V</td><td style='text-align: center; word-wrap: break-word;'></td></tr><tr><td style='text-align: center; word-wrap: break-word;'>VCO</td><td style='text-align: center; word-wrap: break-word;'>压控振荡器</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>矢量网络分析仪 (VCO)</td><td style='text-align: center; word-wrap: break-word;'>测量电网网络参数（通常表示为 S 参数）的仪器。为此，VCO 测量同时提供幅值（增益）和相位信息的输入信号的电压。由于这一特性，该仪器曾被称为增益相位计。另请参见增益相位计、标量网络分析仪。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>X</td><td style='text-align: center; word-wrap: break-word;'></td></tr><tr><td style='text-align: center; word-wrap: break-word;'>XML</td><td style='text-align: center; word-wrap: break-word;'>可扩展标记语言：定义一组规则以便以人类和机器均可读的格式对文档进行编码的标记语言。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>Z</td><td style='text-align: center; word-wrap: break-word;'></td></tr><tr><td style='text-align: center; word-wrap: break-word;'>ZCtrl</td><td style='text-align: center; word-wrap: break-word;'>Zurich Instruments 控制总线</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>ZoomFFT</td><td style='text-align: center; word-wrap: break-word;'>此技术用于对解调样本（例如在锁相放大器之后）执行 FFT。由于 FFT 的分辨率取决于采集的点数和时间跨度（而非采样率），因此可以获得非常高分辨率的频谱分析。</td></tr><tr><td style='text-align: center; word-wrap: break-word;'>ZSync</td><td style='text-align: center; word-wrap: break-word;'>Zurich Instruments 同步总线</td></tr></table>

### 索引

##### 符号

1GbE

后面板，60

##### A

自动保存，131，131

辅助输入

前面板，59

辅助输出

前面板，59

Auxiliary（辅助）选项卡，210

Auxiliary（辅助）选项卡，210

B

后面板，60

带宽，292

C

校准，10

出厂，10

时钟

10 MHz

后面板，60

命令行，35

Config（配置）选项卡，231

连接

1 Gbit/s 以太网，16

USB，17

无线，24

耦合

AC，150，161

电流输入信号 LED

前面板，58

光标

描述，123

截止频率，292

D

DAQ 选项卡，189

数据服务器

节点，304

DC 输入

后面板，60

解调器

框图，150，161

解调器稳定时间，203

Device（设备）选项卡，237

DIO

后面板，60

DIO 选项卡，214

E

地面

接地

##### 外部参考

教程，75

##### F

文件格式，133

Files（文件）选项卡，242

滤波器，294

补偿，301

稳定时间，294，294

正弦，203，298

前面板，58

满量程灵敏度，296

##### H

历史记录，131，131

### I

##### 阻抗

输入，150，161

Impedance Analyzer（阻抗分析仪）选项卡，217

Inputs/Outputs（输入/输出）选项卡，213

安装

Linux，33

Windows，29

##### L

Linux

软件安装，33

锁相

原理，289

Lock-in（锁相）选项卡，149

安装多解调器 (MF-MD) 选件，160

日志文件，52

##### M

Math（数学）子选项卡

描述，123

MOD 选项卡，263

解调选件

框图，264

鼠标功能

描述，121

Multi Device Sync（多设备同步）选项卡，267

##### N

树叶，304

清单节点，305

属性，305

服务器节点，306

类型，305

##### 噪声

##### O

订购指南，61

##### P

包装内容，10

性能图，284

锁相环

PLL

教程，100，111

PID

框图，245

PID Advisor（PID 智能参数设定）

教程，105

PID 选项卡，244

PLL

框图，248

Plotter（绘图仪）选项卡，174

电源进线

后面板，60

电源 LED

前面板，59

编程

.NET，45

C，45

LabVIEW，44

MATLAB，44

Python，45

##### Q

正交，289

R

参考信号，289

RMS 值，290

##### S

保存数据，130

Scope（示波器）选项卡，176

灵敏度

满量程灵敏度，296

信号输入 I

前面板，58

软件安装

命令行，35

Linux，33

要求

Linux，33

支持的 Linux 版本，33

Windows，29

软件启动，38

Spectrum Analyzer（频谱分析仪）选项卡，197

状态栏

描述，120

参数扫描仪

教程，80

Sweeper（参数扫描仪）选项卡，201

##### T

Threshold（阈值）选项卡，258

工具箱

描述，118

树状选择器

描述，126

趋势

描述，128

触发器输入

后面板，60

触发器输出

后面板，60

##### u

更新

固件，49

LabOne，46

USB

后面板，60

USB 驱动程序

Linux，21

Macintosh，21

Windows，17

用户界面

描述，116

### V

垂直轴组

描述，126

电压输入信号 LED

前面板，59

##### W

Windows

软件安装，29

Z

Zoom FFT, 301

