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
                var files = Directory.GetFiles(Pathnew, "*.properties", SearchOption.TopDirectoryOnly).ToList();
                //for (int i = 0; i < files.Count; i++)
                for (int i = 0; i < 1; i++)
                {
                    string propertiePath = files.ElementAt(i);//propertie全路径
                    Result.AppendText(string.Format("开始分析文件：{1}{0}", Environment.NewLine, propertiePath));
                    StringWriter sw = new StringWriter();
                    StringBuilder sb = new StringBuilder();

                    using (StreamReader sr = new StreamReader(propertiePath, Encoding.ASCII))
                    {
                        while (!sr.EndOfStream)
                        {
                            string a = sr.ReadLine();
                            //Result.AppendText(string.Format("该行为：{1}{0}", Environment.NewLine, a));
                        }
                    }

                }
                //打开新文件，然后遍历旧文件的每一行，然后替换，追加到sb,最后把sb输出到新目录里面
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
