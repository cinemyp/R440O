namespace R440O.R440OForms.PowerShield
{
    partial class PowerShieldForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PowerShieldForm));
            this.PowerShieldPanel = new System.Windows.Forms.Panel();
            this.КнопкаТЛФ_ТЧ = new System.Windows.Forms.Button();
            this.PowerShieldPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PowerShieldPanel
            // 
            this.PowerShieldPanel.BackgroundImage = global::R440O.BackgroundImages.PowerShield;
            this.PowerShieldPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PowerShieldPanel.Controls.Add(this.КнопкаТЛФ_ТЧ);
            this.PowerShieldPanel.Location = new System.Drawing.Point(0, 0);
            this.PowerShieldPanel.Name = "PowerShieldPanel";
            this.PowerShieldPanel.Size = new System.Drawing.Size(970, 749);
            this.PowerShieldPanel.TabIndex = 4;
            // 
            // КнопкаТЛФ_ТЧ
            // 
            this.КнопкаТЛФ_ТЧ.BackColor = System.Drawing.Color.Transparent;
            this.КнопкаТЛФ_ТЧ.FlatAppearance.BorderSize = 0;
            this.КнопкаТЛФ_ТЧ.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.КнопкаТЛФ_ТЧ.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.КнопкаТЛФ_ТЧ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.КнопкаТЛФ_ТЧ.Location = new System.Drawing.Point(136, 156);
            this.КнопкаТЛФ_ТЧ.Name = "КнопкаТЛФ_ТЧ";
            this.КнопкаТЛФ_ТЧ.Size = new System.Drawing.Size(231, 173);
            this.КнопкаТЛФ_ТЧ.TabIndex = 9;
            this.КнопкаТЛФ_ТЧ.UseVisualStyleBackColor = false;
            this.КнопкаТЛФ_ТЧ.Click += new System.EventHandler(this.КнопкаТЛФ_ТЧ_Click);
            // 
            // PowerShieldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 733);
            this.Controls.Add(this.PowerShieldPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PowerShieldForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "КАБЕЛЬНЫЙ ВВОД";
            this.PowerShieldPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PowerShieldPanel;
        private System.Windows.Forms.Button КнопкаТЛФ_ТЧ;
    }
}