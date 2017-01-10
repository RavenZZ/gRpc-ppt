
setlocal

@rem enter this directory
cd /d %~dp0

set TOOLS_PATH=./

protoc.exe --js_out=import_style=commonjs,binary:./codegen/ --grpc_out=./codegen/ --plugin=protoc-gen-grpc=grpc_node_plugin minglog.proto 

endlocal
pause