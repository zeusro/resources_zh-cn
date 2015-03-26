using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            Action action = new Action(() =>
            {
                Clear();
                Result.AppendText(string.Format("开始装逼{0}", Environment.NewLine));
                Initialize();
                var files = Directory.GetFiles(Pathnew, "*.properties", SearchOption.TopDirectoryOnly).ToList();//目标目录
                //var oldfiles = Directory.GetFiles(Pathold, "*.properties", SearchOption.TopDirectoryOnly).ToList();//目标目录
                //for (int i = 0; i < files.Count; i++)
                for (int i = 0; i < 1; i++)
                {
                    //遍历文件，然后从旧的文件找出可以汉化的部分，然后替换掉=号后面的内容
                    string propertiePath = files.ElementAt(i);//propertie全路径
                    string fileName = propertiePath.Split('\\').Last();
                    Result.AppendText(string.Format("开始分析文件：{1}{0}", Environment.NewLine, propertiePath));
                    StringBuilder sb = new StringBuilder();
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
                            //Result.AppendText(string.Format("{2}行为：{1}{0}", Environment.NewLine, a, line++));
                            using (StreamReader sr2 = new StreamReader(Path.Combine(Pathold, fileName), Encoding.ASCII))
                            //读取已汉化文件
                            {
                                //todo：要建立一个二维数组，求并集。然后把待汉化的放末尾
                                List<string> oldTextList = new List<string>();
                                while (!sr2.EndOfStream)
                                {
                                    oldTextList.Add(sr2.ReadLine());
                                }
                                string newhead = a.Split('=').First();//原文头部
                                if (oldTextList.Where(o => o.StartsWith(newhead)).FirstOrDefault() != null)
                                {
                                }
                            }
                        }
                    }
                    using (FileStream fs = new FileStream(Path.Combine(Pathtarget, fileName), FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                    {
                        var bytes = System.Text.Encoding.ASCII.GetBytes(sb.ToString());
                        fs.Write(bytes, 0, bytes.Length);
                    }

                }
                //todo:打开新文件，然后遍历旧文件的每一行，然后替换，追加到sb,最后把sb输出到新目录里面
                //编码？
                Result.AppendText(string.Format("装逼结束{0}", Environment.NewLine));
            });
            TryCatch(action);
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
    }
}
