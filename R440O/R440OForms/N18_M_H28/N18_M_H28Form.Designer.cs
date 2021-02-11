namespace R440O.R440OForms.N18_M_H28
{
    partial class N18_M_H28Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(N18_M_H28Form));
            this.КабельК11 = new System.Windows.Forms.Button();
            this.КабельК12 = new System.Windows.Forms.Button();
            this.АктивныйКабель = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // КабельК11
            // 
            this.КабельК11.BackColor = System.Drawing.Color.Transparent;
            this.КабельК11.BackgroundImage = global::R440O.ControlElementImages.kabelProfileK11;
            this.КабельК11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.КабельК11.FlatAppearance.BorderSize = 0;
            this.КабельК11.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.КабельК11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.КабельК11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.КабельК11.Location = new System.Drawing.Point(108, 12);
            this.КабельК11.Name = "КабельК11";
            this.КабельК11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.КабельК11.Size = new System.Drawing.Size(57, 227);
            this.КабельК11.TabIndex = 42;
            this.КабельК11.UseVisualStyleBackColor = false;
            this.КабельК11.Click += new System.EventHandler(this.КабельК11_Click);
            // 
            // КабельК12
            // 
            this.КабельК12.BackColor = System.Drawing.Color.Transparent;
            this.КабельК12.BackgroundImage = global::R440O.ControlElementImages.kabelProfileK12;
            this.КабельК12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.КабельК12.FlatAppearance.BorderSize = 0;
            this.КабельК12.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.КабельК12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.КабельК12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.КабельК12.Location = new System.Drawing.Point(199, 12);
            this.КабельК12.Name = "КабельК12";
            this.КабельК12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.КабельК12.Size = new System.Drawing.Size(59, 227);
            this.КабельК12.TabIndex = 43;
            this.КабельК12.UseVisualStyleBackColor = false;
            this.КабельК12.Click += new System.EventHandler(this.КабельК12_Click);
            // 
            // АктивныйКабель
            // 
            this.АктивныйКабель.BackColor = System.Drawing.Color.Transparent;
            this.АктивныйКабель.BackgroundImage = global::R440O.ControlElementImages.kabelInputK11;
            this.АктивныйКабель.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.АктивныйКабель.FlatAppearance.BorderSize = 0;
            this.АктивныйКабель.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.АктивныйКабель.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.АктивныйКабель.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.АктивныйКабель.Location = new System.Drawing.Point(383, 62);
            this.АктивныйКабель.Name = "АктивныйКабель";
            this.АктивныйКабель.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.АктивныйКабель.Size = new System.Drawing.Size(113, 90);
            this.АктивныйКабель.TabIndex = 44;
            this.АктивныйКабель.UseVisualStyleBackColor = false;
            this.АктивныйКабель.Visible = false;
            this.АктивныйКабель.Click += new System.EventHandler(this.АктивныйКабель_Click);
            // 
            // N18_M_H28Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::R440O.BackgroundImages.N18_M_Bottom;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(605, 149);
            this.Controls.Add(this.АктивныйКабель);
            this.Controls.Add(this.КабельК12);
            this.Controls.Add(this.КабельК11);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "N18_M_H28Form";
            this.Text = "Ш28";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button КабельК11;
        private System.Windows.Forms.Button КабельК12;
        private System.Windows.Forms.Button АктивныйКабель;
    }
}