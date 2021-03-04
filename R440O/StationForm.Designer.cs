namespace R440O
{
    partial class StationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StationForm));
            this.label1 = new System.Windows.Forms.Label();
            this.OfflineWorkButton = new System.Windows.Forms.Button();
            this.btnLearning = new System.Windows.Forms.Button();
            this.btnExaming = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Подождите, идет поиск сервера....";
            this.label1.Visible = false;
            // 
            // OfflineWorkButton
            // 
            this.OfflineWorkButton.Location = new System.Drawing.Point(100, 48);
            this.OfflineWorkButton.Name = "OfflineWorkButton";
            this.OfflineWorkButton.Size = new System.Drawing.Size(136, 26);
            this.OfflineWorkButton.TabIndex = 1;
            this.OfflineWorkButton.Text = "Работать оффлайн";
            this.OfflineWorkButton.UseVisualStyleBackColor = true;
            this.OfflineWorkButton.Visible = false;
            this.OfflineWorkButton.Click += new System.EventHandler(this.OfflineWorkButton_Click);
            // 
            // btnLearning
            // 
            this.btnLearning.Location = new System.Drawing.Point(100, 54);
            this.btnLearning.Name = "btnLearning";
            this.btnLearning.Size = new System.Drawing.Size(136, 26);
            this.btnLearning.TabIndex = 2;
            this.btnLearning.Text = "Режим Обучения";
            this.btnLearning.UseVisualStyleBackColor = true;
            this.btnLearning.Click += new System.EventHandler(this.btnLearning_Click);
            // 
            // btnExaming
            // 
            this.btnExaming.Location = new System.Drawing.Point(100, 112);
            this.btnExaming.Name = "btnExaming";
            this.btnExaming.Size = new System.Drawing.Size(136, 26);
            this.btnExaming.TabIndex = 3;
            this.btnExaming.Text = "Сдача Норматива";
            this.btnExaming.UseVisualStyleBackColor = true;
            this.btnExaming.Click += new System.EventHandler(this.btnExaming_Click);
            // 
            // StationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 167);
            this.Controls.Add(this.btnExaming);
            this.Controls.Add(this.btnLearning);
            this.Controls.Add(this.OfflineWorkButton);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StationForm";
            this.Text = "Поиск сервера";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OfflineWorkButton;
        private System.Windows.Forms.Button btnLearning;
        private System.Windows.Forms.Button btnExaming;
    }
}