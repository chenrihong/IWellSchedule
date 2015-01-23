namespace IWellSchedule
{
    partial class ModifyCronPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.savebtn = new System.Windows.Forms.Button();
            this.corn = new System.Windows.Forms.TextBox();
            this.opencornbtn = new System.Windows.Forms.Button();
            this.corndesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(22, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(25, 181);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(304, 27);
            this.savebtn.TabIndex = 1;
            this.savebtn.Text = "保存";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // corn
            // 
            this.corn.Location = new System.Drawing.Point(24, 64);
            this.corn.Name = "corn";
            this.corn.Size = new System.Drawing.Size(244, 21);
            this.corn.TabIndex = 2;
            // 
            // opencornbtn
            // 
            this.opencornbtn.Location = new System.Drawing.Point(288, 60);
            this.opencornbtn.Name = "opencornbtn";
            this.opencornbtn.Size = new System.Drawing.Size(41, 27);
            this.opencornbtn.TabIndex = 3;
            this.opencornbtn.Text = "..";
            this.opencornbtn.UseVisualStyleBackColor = true;
            this.opencornbtn.Click += new System.EventHandler(this.opencornbtn_Click);
            // 
            // corndesc
            // 
            this.corndesc.Location = new System.Drawing.Point(25, 124);
            this.corndesc.Name = "corndesc";
            this.corndesc.Size = new System.Drawing.Size(243, 21);
            this.corndesc.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "时间片描述";
            // 
            // ModifyCronPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 220);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.corndesc);
            this.Controls.Add(this.opencornbtn);
            this.Controls.Add(this.corn);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModifyCronPanel";
            this.Text = "编辑时间片";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.TextBox corn;
        private System.Windows.Forms.Button opencornbtn;
        private System.Windows.Forms.TextBox corndesc;
        private System.Windows.Forms.Label label2;
    }
}