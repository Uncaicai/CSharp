namespace WindowsFormsApp1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCalculate = new System.Windows.Forms.Button();
            this.cbbxSymbol = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxNum1 = new System.Windows.Forms.TextBox();
            this.tbxNum2 = new System.Windows.Forms.TextBox();
            this.lblResultNum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(141, 225);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(122, 38);
            this.btnCalculate.TabIndex = 0;
            this.btnCalculate.Text = "计算";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // cbbxSymbol
            // 
            this.cbbxSymbol.FormattingEnabled = true;
            this.cbbxSymbol.Items.AddRange(new object[] {
            "＋",
            "-",
            "×",
            "÷"});
            this.cbbxSymbol.Location = new System.Drawing.Point(169, 142);
            this.cbbxSymbol.Name = "cbbxSymbol";
            this.cbbxSymbol.Size = new System.Drawing.Size(56, 23);
            this.cbbxSymbol.TabIndex = 2;
            this.cbbxSymbol.SelectedIndexChanged += new System.EventHandler(this.cbbxSymbol_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 302);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "结果";
            // 
            // tbxNum1
            // 
            this.tbxNum1.Location = new System.Drawing.Point(25, 140);
            this.tbxNum1.Name = "tbxNum1";
            this.tbxNum1.Size = new System.Drawing.Size(101, 25);
            this.tbxNum1.TabIndex = 1;
            this.tbxNum1.TextChanged += new System.EventHandler(this.tbxNum1_TextChanged);
            // 
            // tbxNum2
            // 
            this.tbxNum2.Location = new System.Drawing.Point(279, 142);
            this.tbxNum2.Name = "tbxNum2";
            this.tbxNum2.Size = new System.Drawing.Size(109, 25);
            this.tbxNum2.TabIndex = 4;
            this.tbxNum2.TextChanged += new System.EventHandler(this.tbxNum2_TextChanged);
            // 
            // lblResultNum
            // 
            this.lblResultNum.AutoSize = true;
            this.lblResultNum.Location = new System.Drawing.Point(170, 342);
            this.lblResultNum.Name = "lblResultNum";
            this.lblResultNum.Size = new System.Drawing.Size(0, 15);
            this.lblResultNum.TabIndex = 5;
            this.lblResultNum.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 435);
            this.Controls.Add(this.lblResultNum);
            this.Controls.Add(this.tbxNum2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbxSymbol);
            this.Controls.Add(this.tbxNum1);
            this.Controls.Add(this.btnCalculate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.ComboBox cbbxSymbol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxNum1;
        private System.Windows.Forms.TextBox tbxNum2;
        private System.Windows.Forms.Label lblResultNum;
    }
}

