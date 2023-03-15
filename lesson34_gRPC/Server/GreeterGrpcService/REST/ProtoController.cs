using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace GreeterGrpcService.REST
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProtoController : ControllerBase
    {
        private const string ProtoFilePath = "./Protos/greet.proto";

        [HttpGet]
        public FileResult GetProtobufDefinitionsFile()
        {
            var steam = new FileStream(ProtoFilePath, FileMode.Open);
            return File(steam, "text/plain", fileDownloadName: "greeter.proto");
        }
    }
}
