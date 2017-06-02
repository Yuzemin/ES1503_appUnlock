namespace UnlockApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Mac_ID = new System.Windows.Forms.TextBox();
            this.lab1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SetLimit = new System.Windows.Forms.Label();
            this.LimitBox = new System.Windows.Forms.ComboBox();
            this.FileSel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.OW = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Mac_ID
            // 
            this.Mac_ID.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Mac_ID.Location = new System.Drawing.Point(110, 25);
            this.Mac_ID.MaxLength = 10;
            this.Mac_ID.Name = "Mac_ID";
            this.Mac_ID.Size = new System.Drawing.Size(187, 34);
            this.Mac_ID.TabIndex = 1;
            this.Mac_ID.TextChanged += new System.EventHandler(this.Mac_ID_TextChanged);
            this.Mac_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Mac_ID_KeyPress);
            // 
            // lab1
            // 
            this.lab1.AutoSize = true;
            this.lab1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab1.Location = new System.Drawing.Point(33, 35);
            this.lab1.Name = "lab1";
            this.lab1.Size = new System.Drawing.Size(56, 16);
            this.lab1.TabIndex = 3;
            this.lab1.Text = "机器码";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(51, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 37);
            this.button1.TabIndex = 5;
            this.button1.Text = "生成激活码";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SetLimit
            // 
            this.SetLimit.AutoSize = true;
            this.SetLimit.Font = new System.Drawing.Font("宋体", 12F);
            this.SetLimit.Location = new System.Drawing.Point(17, 87);
            this.SetLimit.Name = "SetLimit";
            this.SetLimit.Size = new System.Drawing.Size(72, 16);
            this.SetLimit.TabIndex = 6;
            this.SetLimit.Text = "件数限制";
            // 
            // LimitBox
            // 
            this.LimitBox.Font = new System.Drawing.Font("宋体", 12F);
            this.LimitBox.FormattingEnabled = true;
            this.LimitBox.Location = new System.Drawing.Point(110, 83);
            this.LimitBox.Name = "LimitBox";
            this.LimitBox.Size = new System.Drawing.Size(91, 24);
            this.LimitBox.TabIndex = 7;
            // 
            // FileSel
            // 
            this.FileSel.Location = new System.Drawing.Point(180, 180);
            this.FileSel.Name = "FileSel";
            this.FileSel.Size = new System.Drawing.Size(102, 37);
            this.FileSel.TabIndex = 10;
            this.FileSel.Text = "生成升级文件";
            this.FileSel.UseVisualStyleBackColor = true;
            this.FileSel.Click += new System.EventHandler(this.FileSel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(33, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "激活码";
            // 
            // OW
            // 
            this.OW.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OW.Location = new System.Drawing.Point(110, 131);
            this.OW.Name = "OW";
            this.OW.ReadOnly = true;
            this.OW.Size = new System.Drawing.Size(187, 29);
            this.OW.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(329, 246);
            this.Controls.Add(this.OW);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FileSel);
            this.Controls.Add(this.LimitBox);
            this.Controls.Add(this.SetLimit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lab1);
            this.Controls.Add(this.Mac_ID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "程序升级指令";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Mac_ID;
        private System.Windows.Forms.Label lab1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label SetLimit;
        private System.Windows.Forms.ComboBox LimitBox;
        private System.Windows.Forms.Button FileSel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox OW;
    }
}

