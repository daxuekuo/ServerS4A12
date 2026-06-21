# 86JP Server Emulator

DNF 86JP 服务端模拟器。配合 `86JPDump.exe` 客户端使用。

## 构建

需要 .NET SDK（提供 `dotnet` CLI）。NuGet 依赖自动下载，无需额外配置。

```bash
dotnet build Server/DfoServer.sln -c Debug
```

或双击 `build.bat`。

## 运行

1. 将客户端的 `Script.pvf` 放到 `Server/DfoServer/bin/Debug/Data/Pvf/` 目录
2. 运行 `Server/DfoServer/bin/Debug/DfoServer.exe`
3. 服务端监听 7001 (Channel) + 10011 (Game) 端口

## 数据库

SQLite 数据库 `inventory.db` 位于 `Server/DfoServer/bin/Debug/Data/`。
首次运行时自动创建表结构。附带的 DB 包含一个种子角色。

## 项目结构

```
Server/DfoServer/    服务端主程序 (.NET Framework 4.7.2)
Tool/PvfLib/         PVF 档案解析库
build.bat            一键构建脚本
```
