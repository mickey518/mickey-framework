using System;
using System.IO;

namespace mickey_framework
{
    public class CodeGenericUtil
    {
        public static string Generic(string package, string poName)
        {
            var basePath = AppContext.BaseDirectory;
            // 创建 “父级” 文件夹
            var codePath = Path.Join(basePath, "mickeyCodeGeneric");
            deleteFolder(codePath);
            createFolder(codePath);

            // 生成mapper文件夹及文件
            var mapperPath = Path.Join(codePath, "mapper");
            createFolder(mapperPath);
            GenericMapperFile(package, poName, mapperPath);

            // 生成api文件夹及文件
            var apiPath = Path.Join(codePath, "api");
            createFolder(apiPath);
            GenericApiFile(package, poName, apiPath);

            // 生成service文件夹、service impl 文件夹 及service接口文件、serviceImpl 类文件
            var servicePath = Path.Join(codePath, "service", poName.ToLower());
            createFolder(servicePath);
            GenericServiceFile(package, poName, servicePath);

            var serviceImplPath = Path.Join(servicePath, "impl");
            createFolder(serviceImplPath);
            GenericServiceImplFile(package, poName, serviceImplPath);

            return codePath;
        }

        private static void deleteFolder(string codePath)
        {
            if (Directory.Exists(codePath)) Directory.Delete(codePath, true);
        }

        private static void GenericServiceImplFile(string package, string poName, string serviceImplPath)
        {
            var codeStr = $@"package {package}.service.{poName.ToLower()}.impl;

import lombok.extern.slf4j.Slf4j;
import org.mickey.framework.core.service.GenericService;
import {package}.mapper.{poName}Mapper;
import {package}.po.{poName};
import {package}.service.{poName.ToLower()}.I{poName}Service;
import org.springframework.stereotype.Service;

/**
 * description
 *
 * @author codeGeneric
 * {DateTime.Now.ToShortDateString()}
 */
@Slf4j
@Service
public class {poName}ServiceImpl extends GenericService<{poName}Mapper, {poName}> implements I{poName}Service " + @"{

}";

            File.WriteAllText(Path.Join(serviceImplPath, $"{poName}ServiceImpl.java"), codeStr);
        }

        private static void GenericServiceFile(string package, string poName, string servicePath)
        {
            var codeStr = $@"package {package}.service.{poName.ToLower()};

import org.mickey.framework.core.service.IBaseService;
import {package}.po.{poName};

/**
 * description
 *
 * @author codeGeneric
 * {DateTime.Now.ToShortDateString()}
 */
public interface I{poName}Service extends IBaseService<{poName}> " + @"{

}";

            File.WriteAllText(Path.Join(servicePath, $"I{poName}Service.java"), codeStr);
        }

        private static void GenericApiFile(string package, string poName, string apiPath)
        {
            var codeStr = $@"package {package}.api;

import io.swagger.annotations.Api;
import lombok.extern.slf4j.Slf4j;
import org.mickey.framework.core.api.BaseController;
import {package}.po.{poName};
import {package}.service.{poName.ToLower()}.I{poName}Service;
import org.springframework.web.bind.annotation.*;

import static org.springframework.http.MediaType.APPLICATION_JSON_VALUE;

/**
 * description
 *
 * @author codeGeneric
 * {DateTime.Now.ToShortDateString()}
 */
@Slf4j
@RestController
@RequestMapping(value = """+ $"/api/{poName}"  + $@""", produces = APPLICATION_JSON_VALUE)
@Api(tags = ""{poName} API"")
public class {poName}Controller extends BaseController<I{poName}Service, {poName}> " + @"{

}";

            File.WriteAllText(Path.Join(apiPath, $"{poName}Controller.java"), codeStr);
        }

        private static void GenericMapperFile(string package, string poName, string mapperPath)
        {
            var codeStr = $@"package {package}.mapper;
                        
import org.mickey.framework.core.mybatis.BaseMapper;
import {package}.po.{poName};

/**
* description
*
* @author codeGeneric
* {DateTime.Now.ToShortDateString()}
*/
public interface {poName}Mapper extends BaseMapper<{poName}> " + @"{

}";

            File.WriteAllText(Path.Join(mapperPath, $"{poName}Mapper.java"), codeStr);
        }

        private static void createFolder(string path)
        {
            Directory.CreateDirectory(path);
        }
    }
}
