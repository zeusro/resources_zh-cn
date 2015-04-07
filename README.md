
# android studio汉化
原理很简单，lib目录下的resources_en.jar这个包就是编辑器相关的，解压好就是那几个文件夹，其中messages文件夹就是语言相关的。由于编码问题，不能直接打开，要用别的工具编辑。
##android studio 版本

window版 1.1.0 

##todo
### 汉化

CodeInsightBundle

DebuggerBundle

ExecutionBundle

InspectionsBundle

RefactoringBundle


### 处理一些遗漏的
### 优化


## 使用

1进入这个目录，这个目录是我汉化好的

`\resources_zh-cn\MyTextAnalyzer\Result`

2找个地方把resources_zh-cn里的文件复制到目录A，然后把我汉化好的messages文件夹覆盖

3进入A目录生成包

`jar cvf  resources_en.jar * `


4放到android studio的lib目录，覆盖原文件之前记得备份，由于版本差异问题造成的问题本人概不负责

`C:\Program Files\Android\Android Studio\lib`

## 有没有其他版本？
本人没有Mac,不装Linux。所以

## 如何参与汉化？
用eclipse+properties-editor插件或myeclipse打开\MyTextAnalyzer\Result文件，编辑后pull request过来就行，由于编码问题，最好附上中文，我会检查，然后合并。最好有上下文环境（截图，这样尽可能的避免误翻）
