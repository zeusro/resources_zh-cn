namespace MyTextAnalyzer
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.PathOld = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PathNew = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PathTarget = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Result = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PathOld
            // 
            this.PathOld.Location = new System.Drawing.Point(96, 12);
            this.PathOld.Name = "PathOld";
            this.PathOld.Size = new System.Drawing.Size(471, 21);
            this.PathOld.TabIndex = 0;
            this.PathOld.Text = "F:\\MyOpenSourceLife\\resources_zh-cn\\resources_zh-cn-old\\messages";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "旧的汉化目录";
            // 
            // PathNew
            // 
            this.PathNew.Location = new System.Drawing.Point(96, 39);
            this.PathNew.Name = "PathNew";
            this.PathNew.Size = new System.Drawing.Size(471, 21);
            this.PathNew.TabIndex = 0;
            this.PathNew.Text = "F:\\MyOpenSourceLife\\resources_zh-cn\\resources_zh-cn\\messages";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "目标汉化目录";
            // 
            // PathTarget
            // 
            this.PathTarget.Location = new System.Drawing.Point(96, 66);
            this.PathTarget.Name = "PathTarget";
            this.PathTarget.Size = new System.Drawing.Size(471, 21);
            this.PathTarget.TabIndex = 0;
            this.PathTarget.Text = "F:\\MyOpenSourceLife\\resources_zh-cn\\MyTextAnalyzer\\Result";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "输出目录";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(587, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "开始分析";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Result
            // 
            this.Result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Result.Location = new System.Drawing.Point(13, 264);
            this.Result.Multiline = true;
            this.Result.Name = "Result";
            this.Result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Result.Size = new System.Drawing.Size(652, 348);
            this.Result.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(587, 87);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "切换中文";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.切换中文);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(587, 118);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "切换英文";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.切换英文);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(96, 93);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(471, 21);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "C:\\Users\\Z\\Desktop\\temp\\backup\\汉化版";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "中文包目录";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(96, 120);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(471, 21);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "F:\\MyOpenSourceLife\\resources_zh-cn\\backup\\原版";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "英文包目录";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(96, 147);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(471, 21);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "C:\\Program Files\\Android\\Android Studio\\lib";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "软件目录";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(96, 174);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(471, 21);
            this.textBox4.TabIndex = 0;
            this.textBox4.Text = "F:\\MyOpenSourceLife\\resources_zh-cn\\MyTextAnalyzer\\Todo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "待汉化目录";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(96, 201);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(471, 21);
            this.textBox5.TabIndex = 0;
            this.textBox5.Text = "F:\\MyOpenSourceLife\\resources_zh-cn\\MyTextAnalyzer\\原文";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "原文整理目录";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(590, 196);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "排序原文";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(573, 174);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(103, 23);
            this.button5.TabIndex = 8;
            this.button5.Text = "导出待汉化文件";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(587, 58);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 9;
            this.button6.Text = "退出";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 624);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.PathTarget);
            this.Controls.Add(this.PathNew);
            this.Controls.Add(this.PathOld);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PathOld;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PathNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PathTarget;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Result;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}

