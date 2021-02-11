namespace R440O.R440OForms.Wattmeter
{
    partial class WattmeterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WattmeterForm));
            this.Panel = new System.Windows.Forms.Panel();
            this.Дисплей = new System.Windows.Forms.Button();
            this.ТумблерСеть = new System.Windows.Forms.Button();
            this.РегуляторКоррекция = new System.Windows.Forms.Button();
            this.РегуляторТочно = new System.Windows.Forms.Button();
            this.РегуляторГрубо = new System.Windows.Forms.Button();
            this.ПереключательРежимРаботы = new System.Windows.Forms.Button();
            this.Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.BackgroundImage = global::R440O.BackgroundImages.Wattmeter;
            this.Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Panel.Controls.Add(this.Дисплей);
            this.Panel.Controls.Add(this.ТумблерСеть);
            this.Panel.Controls.Add(this.РегуляторКоррекция);
            this.Panel.Controls.Add(this.РегуляторТочно);
            this.Panel.Controls.Add(this.РегуляторГрубо);
            this.Panel.Controls.Add(this.ПереключательРежимРаботы);
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(707, 544);
            this.Panel.TabIndex = 0;
            // 
            // Дисплей
            // 
            this.Дисплей.BackColor = System.Drawing.Color.Transparent;
            this.Дисплей.FlatAppearance.BorderSize = 0;
            this.Дисплей.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Дисплей.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Дисплей.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Дисплей.Font = new System.Drawing.Font("Consolas", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Дисплей.ForeColor = System.Drawing.Color.Red;
            this.Дисплей.Location = new System.Drawing.Point(99, 98);
            this.Дисплей.Name = "Дисплей";
            this.Дисплей.Size = new System.Drawing.Size(166, 58);
            this.Дисплей.TabIndex = 65;
            this.Дисплей.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Дисплей.UseVisualStyleBackColor = false;
            // 
            // ТумблерСеть
            // 
            this.ТумблерСеть.BackColor = System.Drawing.Color.Transparent;
            this.ТумблерСеть.BackgroundImage = global::R440O.ControlElementImages.tumblerType4Down;
            this.ТумблерСеть.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ТумблерСеть.FlatAppearance.BorderSize = 0;
            this.ТумблерСеть.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ТумблерСеть.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ТумблерСеть.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ТумблерСеть.Location = new System.Drawing.Point(81, 298);
            this.ТумблерСеть.Name = "ТумблерСеть";
            this.ТумблерСеть.Size = new System.Drawing.Size(39, 64);
            this.ТумблерСеть.TabIndex = 38;
            this.ТумблерСеть.UseVisualStyleBackColor = false;
            this.ТумблерСеть.Click += new System.EventHandler(this.ТумблерСеть_Click);
            // 
            // РегуляторКоррекция
            // 
            this.РегуляторКоррекция.BackColor = System.Drawing.Color.Transparent;
            this.РегуляторКоррекция.BackgroundImage = global::R440O.ControlElementImages.revolverRoundBlack;
            this.РегуляторКоррекция.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.РегуляторКоррекция.FlatAppearance.BorderSize = 0;
            this.РегуляторКоррекция.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.РегуляторКоррекция.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.РегуляторКоррекция.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.РегуляторКоррекция.Location = new System.Drawing.Point(541, 295);
            this.РегуляторКоррекция.Name = "РегуляторКоррекция";
            this.РегуляторКоррекция.Size = new System.Drawing.Size(76, 71);
            this.РегуляторКоррекция.TabIndex = 37;
            this.РегуляторКоррекция.UseVisualStyleBackColor = false;
            this.РегуляторКоррекция.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Регулятор_MouseDown);
            this.РегуляторКоррекция.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Регулятор_MouseMove);
            this.РегуляторКоррекция.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Регулятор_MouseUp);
            // 
            // РегуляторТочно
            // 
            this.РегуляторТочно.BackColor = System.Drawing.Color.Transparent;
            this.РегуляторТочно.BackgroundImage = global::R440O.ControlElementImages.revolverRoundBlack;
            this.РегуляторТочно.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.РегуляторТочно.FlatAppearance.BorderSize = 0;
            this.РегуляторТочно.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.РегуляторТочно.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.РегуляторТочно.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.РегуляторТочно.Location = new System.Drawing.Point(379, 295);
            this.РегуляторТочно.Name = "РегуляторТочно";
            this.РегуляторТочно.Size = new System.Drawing.Size(76, 71);
            this.РегуляторТочно.TabIndex = 36;
            this.РегуляторТочно.UseVisualStyleBackColor = false;
            this.РегуляторТочно.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Регулятор_MouseDown);
            this.РегуляторТочно.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Регулятор_MouseMove);
            this.РегуляторТочно.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Регулятор_MouseUp);
            // 
            // РегуляторГрубо
            // 
            this.РегуляторГрубо.BackColor = System.Drawing.Color.Transparent;
            this.РегуляторГрубо.BackgroundImage = global::R440O.ControlElementImages.revolverRoundBlack;
            this.РегуляторГрубо.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.РегуляторГрубо.FlatAppearance.BorderSize = 0;
            this.РегуляторГрубо.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.РегуляторГрубо.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.РегуляторГрубо.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.РегуляторГрубо.Location = new System.Drawing.Point(214, 295);
            this.РегуляторГрубо.Name = "РегуляторГрубо";
            this.РегуляторГрубо.Size = new System.Drawing.Size(76, 71);
            this.РегуляторГрубо.TabIndex = 35;
            this.РегуляторГрубо.UseVisualStyleBackColor = false;
            this.РегуляторГрубо.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Регулятор_MouseDown);
            this.РегуляторГрубо.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Регулятор_MouseMove);
            this.РегуляторГрубо.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Регулятор_MouseUp);
            // 
            // ПереключательРежимРаботы
            // 
            this.ПереключательРежимРаботы.BackColor = System.Drawing.Color.Transparent;
            this.ПереключательРежимРаботы.BackgroundImage = global::R440O.ControlElementImages.toggleType3;
            this.ПереключательРежимРаботы.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ПереключательРежимРаботы.FlatAppearance.BorderSize = 0;
            this.ПереключательРежимРаботы.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ПереключательРежимРаботы.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ПереключательРежимРаботы.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ПереключательРежимРаботы.Location = new System.Drawing.Point(303, 415);
            this.ПереключательРежимРаботы.Name = "ПереключательРежимРаботы";
            this.ПереключательРежимРаботы.Size = new System.Drawing.Size(76, 71);
            this.ПереключательРежимРаботы.TabIndex = 34;
            this.ПереключательРежимРаботы.UseVisualStyleBackColor = false;
            this.ПереключательРежимРаботы.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ПереключательРежимРаботы_MouseUp);
            // 
            // WattmeterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 542);
            this.Controls.Add(this.Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WattmeterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "БЛОК ВАТТМЕТРА ИЗМЕРИТЕЛЬНЫЙ Я2М-66";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WattmeterForm_FormClosed);
            this.Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel Panel;
        public System.Windows.Forms.Button ПереключательРежимРаботы;
        public System.Windows.Forms.Button РегуляторГрубо;
        public System.Windows.Forms.Button РегуляторТочно;
        public System.Windows.Forms.Button РегуляторКоррекция;
        public System.Windows.Forms.Button ТумблерСеть;
        public System.Windows.Forms.Button Дисплей;
    }
}