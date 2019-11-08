using System;
using System.IO;
using System.IO.Compression;
using Microsoft.AspNetCore.Mvc;

namespace mickey_framework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeGenericController : ControllerBase
    {

        /// <summary>
        /// 生成Java Mickey framework使用的通用代码，包含api mapper service
        /// </summary>
        /// <param name="package">包名</param>
        /// <param name="poName">实体名称</param>
        /// <returns>生成代码的地址</returns>
        [HttpGet]
        public FileResult Generic(string package, string poName)
        {
            var filePath = CodeGenericUtil.Generic(package, poName);
            var zipPath = Path.Join(AppContext.BaseDirectory, "codeGeneric.zip");
            if (System.IO.File.Exists(zipPath))
            {
                System.IO.File.Delete(zipPath);
            }
            ZipFile.CreateFromDirectory(filePath, zipPath);
            var stream = new FileStream(zipPath, FileMode.Open);
            return File(stream, "application/octet-stream", "codeGeneric.zip");
        }
    }
}