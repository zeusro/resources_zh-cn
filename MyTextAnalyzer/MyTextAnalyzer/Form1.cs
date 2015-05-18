using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Dapper;
using System.Web;
using Newtonsoft.Json;
using System.Threading;
namespace MyTextAnalyzer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string Pathold { get; private set; }
        public string Pathnew { get; private set; }
        public string Pathtarget { get; private set; }


        /// <summary>
        /// 开始分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Action action = new Action(() =>
            {
                Clear();
                Result.AppendText(string.Format("开始装逼{0}", Environment.NewLine));
                Initialize();
                var files = Directory.GetFiles(PathNew.Text, "*.properties", SearchOption.TopDirectoryOnly).ToList();//读取排序号的原文目录
                //遍历文件
                //for (int i = 0; i < 1; i++)
                for (int i = 0; i < files.Count; i++)
                {
                    //遍历文件，然后从旧的文件找出可以汉化的部分，然后替换掉=号后面的内容
                    string propertiePath = files.ElementAt(i);//原文propertie全路径
                    string fileName = propertiePath.Split('\\').Last();//文件名
                    Result.AppendText(string.Format("开始分析文件：{1}{0}", Environment.NewLine, propertiePath));
                    StringBuilder sb = new StringBuilder();//记录汉化文
                    StringBuilder sb2 = new StringBuilder();//记录原文
                    List<string> old = new List<string>();
                    string zh_cnPath = Path.Combine(Pathold, fileName);
                    List<string> oldTextList = new List<string>();
                    #region 加载已汉化文件
                    if (File.Exists(zh_cnPath))
                    {
                        using (StreamReader sr2 = new StreamReader(Path.Combine(Pathold, fileName), Encoding.ASCII))
                        {
                            while (!sr2.EndOfStream)
                            {
                                oldTextList.Add(sr2.ReadLine());
                            }
                            //oldTextList = oldTextList.OrderBy(o => o.ToString()).ToList();
                        }
                    }
                    #endregion
                    using (StreamReader sr = new StreamReader(propertiePath, Encoding.ASCII))//原文文件
                    {
                        int line = 0;
                        while (!sr.EndOfStream)
                        {
                            string a = sr.ReadLine();//原文
                            if (string.IsNullOrWhiteSpace(a) || !a.Contains("=") || a.StartsWith("#"))
                            {
                                line++;
                                continue;
                            }
                            old.Add(a);
                            //Result.AppendText(string.Format("{2}行为：{1}{0}", Environment.NewLine, a, line++));
                            //打开新文件，然后遍历旧文件的每一行，然后替换，追加到sb,最后把sb输出到新目录里面
                            if (File.Exists(zh_cnPath))
                            {
                                string newhead = a.Split('=').First();//原文头部
                                string fine = oldTextList.Where(o => o.StartsWith(newhead)).FirstOrDefault();//汉化文
                                if (fine != null)//有汉化文
                                {
                                    sb.AppendLine(fine);//汉化文
                                }
                                else
                                {
                                    sb2.AppendLine(a);//原文
                                }

                            }
                            else
                            {
                                sb2.AppendLine(a);//原文
                            }
                        }
                    }
                    string targetPath = Path.Combine(Pathtarget, fileName);
                    if (File.Exists(targetPath))
                    {
                        File.Delete(targetPath);
                    }
                    //待汉化的字符在前
                    using (FileStream fs = new FileStream(targetPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                    {
                        var bytes = System.Text.Encoding.ASCII.GetBytes(sb2.ToString());//原文
                        fs.Write(bytes, 0, bytes.Length);
                    }
                    using (FileStream fs = new FileStream(targetPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                    {
                        using (StreamWriter sw2 = new StreamWriter(fs))
                        {
                            //汉化文
                            sw2.WriteLine(sb.ToString());
                        }
                    }
                }
                Result.AppendText(string.Format("装逼结束{0}", Environment.NewLine));
            });
            TryCatch(action);
            sw.Stop();
            Result.AppendText(string.Format("耗时：{0}毫秒", sw.ElapsedMilliseconds));
            //Result.AppendText(string.Format(""));
        }

        private void Initialize()
        {
            Pathold = PathOld.Text;
            Pathnew = PathNew.Text;
            Pathtarget = PathTarget.Text;
        }

        private void TryCatch(Action action, bool isAutoExit = false)
        {
            try
            {
                action();
            }
            catch (Exception exception)
            {
                Result.AppendText(string.Format("{1}{0}", Environment.NewLine, exception));
                //MessageBox.Show(exception.Message);
                if (isAutoExit)
                    Application.Exit();
            }
        }



        private void Clear()
        {
            Result.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 排序原文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Action action = new Action(() =>
            {
                #region 清理工作
                if (System.IO.Directory.Exists(PathNew.Text))
                    System.IO.Directory.Delete(PathNew.Text, true);
                System.IO.Directory.CreateDirectory(PathNew.Text);
                string xxpp = @"D:\My speciality\opensource\resources_zh-cn\MyTextAnalyzer\duoyu";
                if (System.IO.Directory.Exists(xxpp))
                    System.IO.Directory.Delete(xxpp, true);
                System.IO.Directory.CreateDirectory(xxpp);
                #endregion
                Clear();
                Result.AppendText(string.Format("开始装逼{0}", Environment.NewLine));
                Initialize();
                var files = Directory.GetFiles(@"D:\My speciality\opensource\resources_zh-cn\resources_en\messages", "*.properties", SearchOption.TopDirectoryOnly).ToList();//原文目录
                for (int i = 0; i < files.Count; i++)
                {
                    string propertiePath = files.ElementAt(i);//propertie全路径
                    string fileName = propertiePath.Split('\\').Last();
                    Result.AppendText(string.Format("开始分析文件：{1}{0}", Environment.NewLine, propertiePath));
                    StringBuilder sb4 = new StringBuilder();//记录原文
                    List<string> old = new List<string>();
                    using (StreamReader sr = new StreamReader(propertiePath, Encoding.ASCII))
                    {
                        int line = 0;
                        int duoyuLine = 0;
                        while (!sr.EndOfStream)
                        {
                            string a = sr.ReadLine();//原文
                            if (string.IsNullOrWhiteSpace(a) || !a.Contains("=") || a.StartsWith("#"))
                            {
                                sb4.AppendLine(a);
                                line++;
                                duoyuLine++;
                                continue;
                            }
                            line++;
                            old.Add(a);
                            //Result.AppendText(string.Format("{2}行为：{1}{0}", Environment.NewLine, a, line++));
                        }
                        Result.AppendText(string.Format("原文：{0}行，多余行：{1}排序后：{2}行;出入行：{3}{4}", line, duoyuLine, old.Count, line - duoyuLine - old.Count, Environment.NewLine));
                    }
                    old = old.OrderBy(o => o.ToString()).ToList();
                    StringBuilder sb3 = new StringBuilder();
                    for (int j = 0; j < old.Count; j++)
                    {
                        sb3.AppendLine(old.ElementAt(j));
                    }
                    using (FileStream fs = new FileStream(Path.Combine(PathNew.Text, fileName), FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                    {//排序原文
                        var bytes = System.Text.Encoding.ASCII.GetBytes(sb3.ToString());
                        fs.Write(bytes, 0, bytes.Length);
                    }
                    #region 记录多余行
                    if (sb4.ToString().Length > 0)
                    {
                        using (FileStream fs = new FileStream(Path.Combine(xxpp, fileName), FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                        {//排序原文
                            var bytes = System.Text.Encoding.ASCII.GetBytes(sb4.ToString());
                            fs.Write(bytes, 0, bytes.Length);
                        }
                    }
                    #endregion

                }
                #region MyRegion
                //for (int i = 0; i < files.Count; i++)
                //{
                //    string propertiePath = files.ElementAt(i);//propertie全路径
                //    string fileName = propertiePath.Split('\\').Last();
                //    Result.AppendText(string.Format("开始分析文件：{1}{0}", Environment.NewLine, propertiePath));
                //    StringBuilder sb4 = new StringBuilder();//记录原文
                //    List<string> old = new List<string>();
                //    #region 读取已汉化文件
                //    List<string> oldTextList = new List<string>();
                //    using (StreamReader sr2 = new StreamReader(Path.Combine(Pathold, fileName), Encoding.ASCII))
                //    {
                //        //读取已汉化文件
                //        while (!sr2.EndOfStream)
                //        {
                //            oldTextList.Add(sr2.ReadLine());
                //        }
                //        oldTextList = oldTextList.OrderBy(o => o.ToString()).ToList();
                //    }
                //    #endregion
                //    using (StreamReader sr = new StreamReader(propertiePath, Encoding.ASCII))
                //    {
                //        int line = 0;
                //        int duoyuLine = 0;
                //        while (!sr.EndOfStream)
                //        {
                //            string a = sr.ReadLine();//原文
                //            if (string.IsNullOrWhiteSpace(a) || !a.Contains("=") || a.StartsWith("#"))
                //            {
                //                sb4.AppendLine(a);
                //                line++;
                //                duoyuLine++;
                //                continue;
                //            }
                //            line++;
                //            old.Add(a);
                //            //Result.AppendText(string.Format("{2}行为：{1}{0}", Environment.NewLine, a, line++));
                //        }
                //        Result.AppendText(string.Format("原文：{0}行，多余行：{1}排序后：{2}行;出入行：{3}{4}", line, duoyuLine, old.Count, line - duoyuLine - old.Count, Environment.NewLine));
                //    }
                //    old = old.OrderBy(o => o.ToString()).ToList();
                //    StringBuilder sb3 = new StringBuilder();
                //    for (int j = 0; j < old.Count; j++)
                //    {
                //        sb3.AppendLine(old.ElementAt(j));
                //    }            
                //    using (FileStream fs = new FileStream(Path.Combine(textBox5.Text, fileName), FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                //    {//排序原文
                //        var bytes = System.Text.Encoding.ASCII.GetBytes(sb3.ToString());
                //        fs.Write(bytes, 0, bytes.Length);
                //    }
                //    if (sb4.ToString().Length > 0)
                //    {
                //        using (FileStream fs = new FileStream(Path.Combine(@"F:\MyOpenSourceLife\resources_zh-cn\MyTextAnalyzer\duoyu", fileName), FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                //        {//排序原文
                //            var bytes = System.Text.Encoding.ASCII.GetBytes(sb4.ToString());
                //            fs.Write(bytes, 0, bytes.Length);
                //        }
                //    }
                //} 
                #endregion
                Result.AppendText(string.Format("装逼结束{0}", Environment.NewLine));
            });
            TryCatch(action);
            sw.Stop();
            Result.AppendText(string.Format("耗时：{0}毫秒", sw.ElapsedMilliseconds));
            //Result.AppendText(string.Format(""));
        }

        /// <summary>
        /// 汉化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Action action = new Action(() =>
            {
                Clear();
                Result.AppendText(string.Format("开始装逼{0}", Environment.NewLine));
                Initialize();
                var files = Directory.GetFiles(Pathnew, "*.properties", SearchOption.TopDirectoryOnly).ToList();//原文目录
                for (int i = 0; i < files.Count; i++)
                //for (int i = 0; i < 1; i++)
                {

                    //遍历文件，然后从旧的文件找出可以汉化的部分，然后替换掉=号后面的内容
                    string propertiePath = files.ElementAt(i);//propertie全路径
                    string fileName = propertiePath.Split('\\').Last();
                    string outputFileName = Path.Combine(textBox4.Text, fileName);//输出汉化文件
                    Result.AppendText(string.Format("开始分析文件：{1}{0}", Environment.NewLine, propertiePath));
                    if (!File.Exists(Path.Combine(Pathold, fileName)))//无对应汉化文件,直接复制
                    {
                        File.Copy(propertiePath, outputFileName, true);
                        continue;
                    }
                    StringBuilder sb = new StringBuilder(5000);//记录汉化文
                    StringBuilder sb2 = new StringBuilder(5000);//记录原文
                    List<string> old = new List<string>();//原文
                    var oldTextList = new Dictionary<string, string>();//汉化文
                    using (StreamReader sr = new StreamReader(propertiePath, Encoding.ASCII))
                    {//原文
                        int line = 0;
                        while (!sr.EndOfStream)
                        {
                            string a = sr.ReadLine();//原文
                            //if (string.IsNullOrWhiteSpace(a) || !a.Contains("=") || a.StartsWith("#"))
                            //{
                            //    line++;
                            //    continue;
                            //}
                            old.Add(a);
                            //Result.AppendText(string.Format("{2}行为：{1}{0}", Environment.NewLine, a, line++));
                        }
                    }
                    #region 加载汉化文
                    using (StreamReader sr2 = new StreamReader(Path.Combine(Pathold, fileName), Encoding.ASCII))
                    { //读取已汉化文件
                        //List<string> oldTextList = new List<string>();                        
                        while (!sr2.EndOfStream)
                        {
                            string znch = sr2.ReadLine();
                            if (!string.IsNullOrWhiteSpace(znch))
                            {
                                if (znch.Contains('='))
                                {
                                    var temp = znch.Split('=');
                                    if (!oldTextList.ContainsKey(temp.ElementAt(0).Trim()))
                                        oldTextList.Add(temp.ElementAt(0).Trim(), temp.ElementAt(1).Trim());
                                }
                            }
                        }
                    #endregion
                    }
                    #region 导入文本
                    //oldTextList = oldTextList.OrderBy(o => o.ToString()).ToList();
                    for (int j = 0; j < old.Count; j++)
                    {
                        string newhead = old.ElementAt(j).Split('=').First().Trim();//原文头部
                        if (oldTextList.ContainsKey(newhead))
                        {
                            //有汉化文
                            //string fine = oldTextList.Where(o => o.StartsWith(newhead)).FirstOrDefault();//汉化文  
                            string fine = newhead + "=" + oldTextList[newhead];
                            sb.AppendLine(fine);//汉化文    
                        }
                        else
                        {
                            sb2.AppendLine(old.ElementAt(j));//原文
                        }
                    }
                    //Result.AppendText(string.Format("{1}{0}", Environment.NewLine, old.Count));
                    //Result.AppendText(string.Format("{1}{0}", Environment.NewLine, oldTextList.Count));                    
                    #endregion
                    #region 输出文本
                    if (File.Exists(outputFileName))
                        File.Delete(outputFileName);
                    //待汉化的字符(原文)在前               
                    if (sb2.ToString().Length > 0)
                    {
                        using (FileStream fs = new FileStream(outputFileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                        {
                            var bytes = System.Text.Encoding.ASCII.GetBytes(sb2.ToString());
                            fs.Write(bytes, 0, bytes.Length);                            
                        }
                    }
                    if (sb.ToString().Length > 0)
                    {
                        using (FileStream fs = File.OpenWrite(outputFileName))
                        {
                            //设定书写的開始位置为文件的末尾    
                            fs.Position = fs.Length;
                            //将待写入内容追加到文件末尾  
                            var bytes = System.Text.Encoding.ASCII.GetBytes(sb.ToString());
                            fs.Write(bytes, 0, bytes.Length);
                        }
                    }
                    #endregion
                }
                Result.AppendText(string.Format("装逼结束{0}", Environment.NewLine));
            });
            TryCatch(action);
            sw.Stop();
            Result.AppendText(string.Format("耗时：{0}毫秒", sw.ElapsedMilliseconds));
            //Result.AppendText(string.Format(""));
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 数据持久化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string con = "Data Source=.;Initial Catalog=AndroidStudiozh_CN;User Id=sa;Password=sa;Min Pool Size=0;Max Pool Size = 515;Connection Lifetime=0;";
            Clear();
            Result.AppendText(string.Format("开始装逼{0}", Environment.NewLine));
            Initialize();
            var files = Directory.GetFiles(PathNew.Text, "*.properties", SearchOption.TopDirectoryOnly).ToList();//读取排序好的原文目录
            //遍历文件
            for (int i = 0; i < files.Count; i++)
            {
                //遍历文件，然后从旧的文件找出可以汉化的部分，然后替换掉=号后面的内容
                string propertiePath = files.ElementAt(i);//原文propertie全路径
                string fileName = propertiePath.Split('\\').Last();//文件名
                Result.AppendText(string.Format("开始分析文件：{1}{0}", Environment.NewLine, propertiePath));
                StringBuilder sb = new StringBuilder();//记录汉化文
                StringBuilder sb2 = new StringBuilder();//记录原文
                List<string> old = new List<string>();
                string zh_cnPath = Path.Combine(Pathold, fileName);
                List<string> oldTextList = new List<string>();
                #region 加载已汉化文件
                if (File.Exists(zh_cnPath))
                {
                    using (StreamReader sr2 = new StreamReader(Path.Combine(Pathold, fileName), Encoding.UTF8))
                    {
                        while (!sr2.EndOfStream)
                        {
                            oldTextList.Add(sr2.ReadLine());
                        }
                        //oldTextList = oldTextList.OrderBy(o => o.ToString()).ToList();
                    }
                }
                #endregion
                using (StreamReader sr = new StreamReader(propertiePath, Encoding.ASCII))//原文文件
                {
                    int line = 0;
                    while (!sr.EndOfStream)
                    {
                        line++;
                        string a = sr.ReadLine();//原文
                        if (string.IsNullOrWhiteSpace(a) || !a.Contains("=") || a.StartsWith("#"))
                        {
                            continue;
                        }
                        //Result.AppendText(string.Format("{2}行为：{1}{0}", Environment.NewLine, a, line++));
                        string newhead = a.Split('=').First();//原文头部
                        string fine = oldTextList.Where(o => o.StartsWith(newhead)).FirstOrDefault();//汉化文  
                        string TextValue = (a.Split('=').Last() ?? "");
                        string TextValueCN = fine.Split('=').Last() ?? "";

                        Encoding origin = Encoding.UTF8;
                        Encoding targetEnco = Encoding.GetEncoding(936);
                        byte[] ansiBytes = origin.GetBytes(TextValueCN);
                        byte[] utf8Bytes = Encoding.Convert(origin, targetEnco, ansiBytes);
                        string cn = targetEnco.GetString(utf8Bytes);
                        cn = "";
                        //TODO:UTF→GBK

                        //string temp = "[{\"Data\":\"" + TextValueCN + "\"}]";
                        ////string cn = (JsonConvert.DeserializeObject<A>(temp)).Data;
                        //var caonima = JsonConvert.SerializeObject(new A { Data = TextValueCN });
                        ////string cn = (JsonConvert.DeserializeObject<List<A>>(caonima)).First().Data;
                        //string cn = (JsonConvert.DeserializeObject<A>(caonima,)).Data;         
                        try
                        {
                            using (SqlConnection connection = new SqlConnection(con))
                            {
                                connection.Open();
                                connection.Execute(string.Format(@"insert into  [AndroidStudiozh_CN].[dbo].[Chinesization]([TextLine],[TextKey],[TextValue],[TextValueCN],[FileName],TextValueCN1)
                                     values(@TextLine,@TextKey,@TextValue,@TextValueCN,@FileName,@TextValueCN1);"), new
                                    {
                                        TextLine = line,
                                        TextKey = newhead,
                                        TextValue = TextValue,
                                        TextValueCN = TextValueCN,
                                        fileName = fileName,
                                        TextValueCN1 = cn,
                                    });
                            }
                        }
                        catch (Exception exception)
                        {
                            //Result.AppendText(string.Format("TextValue：{3}{0}", Environment.NewLine, line, newhead, TextValue, TextValueCN, exception.Message));
                            Result.AppendText(string.Format("TextLine：{1}{0}TextKey：{2}{0}TextValue：{3}{0}TextValueCN：{4}{0}errormessage:{5}", Environment.NewLine, line, newhead, TextValue, TextValueCN, exception.Message));
                        }
                    }
                }
            }
            Result.AppendText(string.Format("装逼结束{0}", Environment.NewLine));



        }


    }

}
