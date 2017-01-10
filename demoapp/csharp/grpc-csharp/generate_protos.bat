
setlocal

@rem enter this directory
cd /d %~dp0

set TOOLS_PATH=Tools\Grpc.Tools.0.15.0\tools\windows_x64

%TOOLS_PATH%\protoc.exe -I./ --csharp_out MingLogger ./minglog.proto --grpc_out MingLogger --plugin=protoc-gen-grpc=%TOOLS_PATH%\grpc_csharp_plugin.exe

endlocal
