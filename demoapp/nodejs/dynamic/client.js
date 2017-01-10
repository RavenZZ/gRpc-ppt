var protoPath = __dirname + './minglog.proto';

var grpc = require('grpc');
var minglog_proto = grpc.load(protoPath).minglogger;


// function main() {
//     var client = new minglog_proto.LogService('localhost:50051', grpc.credentials.createInsecure());

//     var log = {
//         Author: "Raven"
//     };
//     client.writeLog(log, function (err, response) {
//         console.dir(response);
//     });



// }

// main();







