
# android studio汉化

##android studio 版本
window版 1.1.0 

##todo
ApplicationBundle.properties

CodeInsightBundle.properties

CommonBundle.properties

DebuggerBundle.properties

ExecutionBundle.properties

IdeBundle.properties

InspectionsBundle.properties

OptionsBundle.properties

RefactoringBundle.properties

VcsBundle.properties

XmlBundle.properties

文件分析的改进

以汉化列表的持久化


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
用eclipse或myeclipse打开那些操蛋文件，编辑后pull request过来就行，我会检查，然后合并
