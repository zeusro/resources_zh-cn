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
                var files = Directory.GetFiles(Pathnew, "*.properties", SearchOption.TopDirectoryOnly).ToList();//目标目录
                //var oldfiles = Directory.GetFiles(Pathold, "*.properties", SearchOption.TopDirectoryOnly).ToList();//目标目录
                //for (int i = 0; i < files.Count; i++)
                //for (int i = 0; i < 1; i++)
                for (int i = 0; i < files.Count; i++)
                {
                    //遍历文件，然后从旧的文件找出可以汉化的部分，然后替换掉=号后面的内容
                    string propertiePath = files.ElementAt(i);//propertie全路径
                    string fileName = propertiePath.Split('\\').Last();
                    Result.AppendText(string.Format("开始分析文件：{1}{0}", Environment.NewLine, propertiePath));
                    StringBuilder sb = new StringBuilder();//记录汉化文
                    StringBuilder sb2 = new StringBuilder();//记录原文
                    List<string> old = new List<string>();
                    using (StreamReader sr = new StreamReader(propertiePath, Encoding.ASCII))
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
                            using (StreamReader sr2 = new StreamReader(Path.Combine(Pathold, fileName), Encoding.ASCII))
                            //读取已汉化文件
                            {
                                //打开新文件，然后遍历旧文件的每一行，然后替换，追加到sb,最后把sb输出到新目录里面
                                List<string> oldTextList = new List<string>();
                                while (!sr2.EndOfStream)
                                {
                                    oldTextList.Add(sr2.ReadLine());
                                }
                                //oldTextList = oldTextList.OrderBy(o => o.ToString()).ToList();
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
                        }
                    }
                    using (FileStream fs = new FileStream(Path.Combine(Pathtarget, fileName), FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                    {
                        var bytes = System.Text.Encoding.ASCII.GetBytes(sb.ToString());
                        fs.Write(bytes, 0, bytes.Length);
                    }
                    using (FileStream fs = new FileStream(Path.Combine(Pathtarget, fileName), FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                    {
                        var bytes = System.Text.Encoding.ASCII.GetBytes(sb2.ToString());
                        fs.Write(bytes, 0, bytes.Length);
                    }
                   
                    using (FileStream fs = new FileStream(Path.Combine(textBox4.Text, fileName), FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                    {
                        var bytes = System.Text.Encoding.ASCII.GetBytes(sb2.ToString());
                        fs.Write(bytes, 0, bytes.Length);
                    }
                    //待汉化的字符在前
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

        private void TryCatch(Action action)
        {
            try
            {
                action();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
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
                Clear();
                Result.AppendText(string.Format("开始装逼{0}", Environment.NewLine));
                Initialize();
                var files = Directory.GetFiles(Pathnew, "*.properties", SearchOption.TopDirectoryOnly).ToList();//目标目录
                //var oldfiles = Directory.GetFiles(Pathold, "*.properties", SearchOption.TopDirectoryOnly).ToList();//目标目录
                //for (int i = 0; i < files.Count; i++)
                //for (int i = 0; i < 1; i++)
                for (int i = 0; i < files.Count; i++)
                {
                    //遍历文件，然后从旧的文件找出可以汉化的部分，然后替换掉=号后面的内容
                    string propertiePath = files.ElementAt(i);//propertie全路径
                    string fileName = propertiePath.Split('\\').Last();
                    //Result.AppendText(string.Format("开始分析文件：{1}{0}", Environment.NewLine, propertiePath));
                    StringBuilder sb = new StringBuilder();//记录汉化文
                    StringBuilder sb2 = new StringBuilder();//记录原文
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
                            using (StreamReader sr2 = new StreamReader(Path.Combine(Pathold, fileName), Encoding.ASCII))
                            //读取已汉化文件
                            {
                                //打开新文件，然后遍历旧文件的每一行，然后替换，追加到sb,最后把sb输出到新目录里面
                                List<string> oldTextList = new List<string>();
                                while (!sr2.EndOfStream)
                                {
                                    oldTextList.Add(sr2.ReadLine());
                                }
                                //oldTextList = oldTextList.OrderBy(o => o.ToString()).ToList();
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
                        }
                        Result.AppendText(string.Format("原文：{0}行，多余行：{1}排序后：{2}行;出入行：{3}{4}", line, duoyuLine, old.Count, line - duoyuLine - old.Count, Environment.NewLine));
                    }
                    old = old.OrderBy(o => o.ToString()).ToList();
                    StringBuilder sb3 = new StringBuilder();
                    for (int j = 0; j < old.Count; j++)
                    {
                        sb3.AppendLine(old.ElementAt(j));
                    }
                    using (FileStream fs = new FileStream(Path.Combine(textBox5.Text, fileName), FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                    {//排序原文
                        var bytes = System.Text.Encoding.ASCII.GetBytes(sb3.ToString());
                        fs.Write(bytes, 0, bytes.Length);
                    }
                    if (sb4.ToString().Length > 0)
                    {
                        using (FileStream fs = new FileStream(Path.Combine(@"F:\MyOpenSourceLife\resources_zh-cn\MyTextAnalyzer\duoyu", fileName), FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                        {//排序原文
                            var bytes = System.Text.Encoding.ASCII.GetBytes(sb4.ToString());
                            fs.Write(bytes, 0, bytes.Length);
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
    }
}
