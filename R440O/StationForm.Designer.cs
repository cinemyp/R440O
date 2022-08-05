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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StationForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btnLearning = new System.Windows.Forms.Button();
            this.btnExaming = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbConnectionError = new System.Windows.Forms.PictureBox();
            this.tbIpAddress = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pbConnectionGot = new System.Windows.Forms.PictureBox();
            this.ttError = new System.Windows.Forms.ToolTip(this.components);
            this.ttConnectionGot = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbConnectionError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbConnectionGot)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите режим работы";
            // 
            // btnLearning
            // 
            this.btnLearning.Location = new System.Drawing.Point(15, 53);
            this.btnLearning.Name = "btnLearning";
            this.btnLearning.Size = new System.Drawing.Size(136, 26);
            this.btnLearning.TabIndex = 2;
            this.btnLearning.Text = "Режим Обучения";
            this.btnLearning.UseVisualStyleBackColor = true;
            this.btnLearning.Click += new System.EventHandler(this.btnLearning_Click);
            // 
            // btnExaming
            // 
            this.btnExaming.Enabled = false;
            this.btnExaming.Location = new System.Drawing.Point(15, 108);
            this.btnExaming.Name = "btnExaming";
            this.btnExaming.Size = new System.Drawing.Size(136, 26);
            this.btnExaming.TabIndex = 3;
            this.btnExaming.Text = "Сдача Норматива";
            this.btnExaming.UseVisualStyleBackColor = true;
            this.btnExaming.Click += new System.EventHandler(this.btnExaming_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbConnectionError);
            this.panel1.Controls.Add(this.tbIpAddress);
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pbConnectionGot);
            this.panel1.Location = new System.Drawing.Point(228, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 125);
            this.panel1.TabIndex = 4;
            // 
            // pbConnectionError
            // 
            this.pbConnectionError.BackColor = System.Drawing.Color.Transparent;
            this.pbConnectionError.Image = ((System.Drawing.Image)(resources.GetObject("pbConnectionError.Image")));
            this.pbConnectionError.Location = new System.Drawing.Point(136, 41);
            this.pbConnectionError.Name = "pbConnectionError";
            this.pbConnectionError.Size = new System.Drawing.Size(26, 26);
            this.pbConnectionError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbConnectionError.TabIndex = 7;
            this.pbConnectionError.TabStop = false;
            this.ttError.SetToolTip(this.pbConnectionError, "Ошибка подключения");
            this.pbConnectionError.Visible = false;
            // 
            // tbIpAddress
            // 
            this.tbIpAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbIpAddress.Location = new System.Drawing.Point(6, 41);
            this.tbIpAddress.Name = "tbIpAddress";
            this.tbIpAddress.Size = new System.Drawing.Size(124, 26);
            this.tbIpAddress.TabIndex = 6;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(6, 96);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(127, 26);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Подключиться";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Введите IP-адрес сервера";
            // 
            // pbConnectionGot
            // 
            this.pbConnectionGot.Image = global::R440O.Properties.Resources.correct;
            this.pbConnectionGot.Location = new System.Drawing.Point(136, 42);
            this.pbConnectionGot.Name = "pbConnectionGot";
            this.pbConnectionGot.Size = new System.Drawing.Size(26, 26);
            this.pbConnectionGot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbConnectionGot.TabIndex = 8;
            this.pbConnectionGot.TabStop = false;
            this.ttConnectionGot.SetToolTip(this.pbConnectionGot, "Подключение прошло успешно!");
            this.pbConnectionGot.Visible = false;
            // 
            // ttError
            // 
            this.ttError.ToolTipTitle = "Ошибка подключения";
            // 
            // StationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 149);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnExaming);
            this.Controls.Add(this.btnLearning);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StationForm";
            this.Text = "Симулятор станции Р-440-О";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbConnectionError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbConnectionGot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLearning;
        private System.Windows.Forms.Button btnExaming;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbIpAddress;
        private System.Windows.Forms.PictureBox pbConnectionError;
        private System.Windows.Forms.ToolTip ttError;
        private System.Windows.Forms.PictureBox pbConnectionGot;
        private System.Windows.Forms.ToolTip ttConnectionGot;
    }
}