namespace R440O.R440OForms.K02M_01Inside
{
    partial class K02M_01InsideForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(K02M_01InsideForm));
            this.Panel = new System.Windows.Forms.Panel();
            this.ТумблерБ5 = new System.Windows.Forms.Button();
            this.Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.BackgroundImage = global::R440O.BackgroundImages.K02M_01_inside;
            this.Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Panel.Controls.Add(this.ТумблерБ5);
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(766, 696);
            this.Panel.TabIndex = 0;
            // 
            // ТумблерБ5
            // 
            this.ТумблерБ5.BackColor = System.Drawing.Color.Transparent;
            this.ТумблерБ5.BackgroundImage = global::R440O.ControlElementImages.tumblerType7Left;
            this.ТумблерБ5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ТумблерБ5.FlatAppearance.BorderSize = 0;
            this.ТумблерБ5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ТумблерБ5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ТумблерБ5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ТумблерБ5.Location = new System.Drawing.Point(202, 561);
            this.ТумблерБ5.Name = "ТумблерБ5";
            this.ТумблерБ5.Size = new System.Drawing.Size(71, 71);
            this.ТумблерБ5.TabIndex = 36;
            this.ТумблерБ5.UseVisualStyleBackColor = false;
            this.ТумблерБ5.Click += new System.EventHandler(this.K02M_01InsideТумблерБ5_Click);
            // 
            // K02M_01InsideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 696);
            this.Controls.Add(this.Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "K02M_01InsideForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "K02M-1Inside";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.K02M_01InsideForm_FormClosed);
            this.Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.Button ТумблерБ5;
    }
}