
namespace EGO.NetIndicator
{
    partial class main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnHead = new System.Windows.Forms.Button();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Crimson;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(349, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 69);
            this.btnClose.TabIndex = 3;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnHead
            // 
            this.btnHead.BackColor = System.Drawing.Color.Gray;
            this.btnHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHead.FlatAppearance.BorderSize = 0;
            this.btnHead.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnHead.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnHead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHead.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnHead.ForeColor = System.Drawing.SystemColors.Control;
            this.btnHead.Location = new System.Drawing.Point(0, 0);
            this.btnHead.Name = "btnHead";
            this.btnHead.Size = new System.Drawing.Size(349, 25);
            this.btnHead.TabIndex = 100;
            this.btnHead.TabStop = false;
            this.btnHead.Text = "net indicator";
            this.btnHead.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHead.UseCompatibleTextRendering = true;
            this.btnHead.UseVisualStyleBackColor = false;
            // 
            // txtHost
            // 
            this.txtHost.BackColor = System.Drawing.Color.DimGray;
            this.txtHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHost.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtHost.ForeColor = System.Drawing.SystemColors.Control;
            this.txtHost.Location = new System.Drawing.Point(49, 36);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(201, 23);
            this.txtHost.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Location = new System.Drawing.Point(11, 38);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(31, 21);
            this.lblTitle.TabIndex = 101;
            this.lblTitle.Text = "host:";
            this.lblTitle.UseCompatibleTextRendering = true;
            // 
            // btnSet
            // 
            this.btnSet.BackColor = System.Drawing.Color.Gray;
            this.btnSet.FlatAppearance.BorderSize = 0;
            this.btnSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSet.Font = new System.Drawing.Font("Segoe UI Semilight", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSet.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSet.Location = new System.Drawing.Point(260, 36);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(78, 23);
            this.btnSet.TabIndex = 2;
            this.btnSet.Text = "set";
            this.btnSet.UseCompatibleTextRendering = true;
            this.btnSet.UseVisualStyleBackColor = false;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(374, 69);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.btnHead);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "main";
            this.Text = "Net Indicator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnHead;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSet;
    }
}

