# framework 通用代码生成

![bingo](images/trump.gif)

## 介绍

生成通用的api、service、mapper代码，节省人力输入

## 注意：

使用此API时，需要在项目中引用org.mickey.framework框架、引用core架包，否则可能无法正常使用生成的代码

框架具体使用参考[mickey framework](https://github.com/meclus/framework/blob/master/README.md)

🤔
[![Build Status](https://mickewang.visualstudio.com/mickey-framework/_apis/build/status/mickey-framework?branchName=azure-pipelines)](https://mickewang.visualstudio.com/mickey-framework/_build/latest?definitionId=2&branchName=azure-pipelines)

## 使用

使用方式，调用 [http://192.168.31.71/api/CodeGeneric?package={package.name}&poName={poname}](http://192.168.31.71/api/CodeGeneric?package={package.name}&poName={poname})， 将占位符替换为具体的包名及po名称，文件下载完成后，解压替换到具体项目即可
