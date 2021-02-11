namespace R440O.LearnModule
{
    partial class LearnTypeSelector
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
            this.oneChannelTypeButton = new System.Windows.Forms.Button();
            this.DiscreteTypeButton = new System.Windows.Forms.Button();
            this.DUB5Button = new System.Windows.Forms.Button();
            this.SHPSButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(106, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(507, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "В каком из режимов вы хотите обучаться?";
            // 
            // oneChannelTypeButton
            // 
            this.oneChannelTypeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.oneChannelTypeButton.Location = new System.Drawing.Point(12, 107);
            this.oneChannelTypeButton.Name = "oneChannelTypeButton";
            this.oneChannelTypeButton.Size = new System.Drawing.Size(344, 120);
            this.oneChannelTypeButton.TabIndex = 1;
            this.oneChannelTypeButton.Text = "Одноканальный режим";
            this.oneChannelTypeButton.UseVisualStyleBackColor = true;
            this.oneChannelTypeButton.Click += new System.EventHandler(this.oneChannelTypeButton_Click);
            // 
            // DiscreteTypeButton
            // 
            this.DiscreteTypeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DiscreteTypeButton.Location = new System.Drawing.Point(363, 107);
            this.DiscreteTypeButton.Name = "DiscreteTypeButton";
            this.DiscreteTypeButton.Size = new System.Drawing.Size(344, 120);
            this.DiscreteTypeButton.TabIndex = 2;
            this.DiscreteTypeButton.Text = "Режим работы с объединением абонентских и служебных каналов       ( аппаратура ди" +
    "скрет)";
            this.DiscreteTypeButton.UseVisualStyleBackColor = true;
            this.DiscreteTypeButton.Click += new System.EventHandler(this.DiscreteTypeButton_Click);
            // 
            // DUB5Button
            // 
            this.DUB5Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DUB5Button.Location = new System.Drawing.Point(12, 254);
            this.DUB5Button.Name = "DUB5Button";
            this.DUB5Button.Size = new System.Drawing.Size(344, 120);
            this.DUB5Button.TabIndex = 3;
            this.DUB5Button.Text = "Режим работы с объединением абонентских и служебных каналов       ( аппаратура ДА" +
    "Б5)";
            this.DUB5Button.UseVisualStyleBackColor = true;
            this.DUB5Button.Click += new System.EventHandler(this.DUB5Button_Click);
            // 
            // SHPSButton
            // 
            this.SHPSButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SHPSButton.Location = new System.Drawing.Point(363, 254);
            this.SHPSButton.Name = "SHPSButton";
            this.SHPSButton.Size = new System.Drawing.Size(344, 120);
            this.SHPSButton.TabIndex = 4;
            this.SHPSButton.Text = "Режим помехозащиты (ШПС)";
            this.SHPSButton.UseVisualStyleBackColor = true;
            this.SHPSButton.Click += new System.EventHandler(this.SHPSButton_Click);
            // 
            // LearnTypeSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 391);
            this.Controls.Add(this.SHPSButton);
            this.Controls.Add(this.DUB5Button);
            this.Controls.Add(this.DiscreteTypeButton);
            this.Controls.Add(this.oneChannelTypeButton);
            this.Controls.Add(this.label1);
            this.Name = "LearnTypeSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LearnTypeSelector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button oneChannelTypeButton;
        private System.Windows.Forms.Button DiscreteTypeButton;
        private System.Windows.Forms.Button DUB5Button;
        private System.Windows.Forms.Button SHPSButton;
    }
}