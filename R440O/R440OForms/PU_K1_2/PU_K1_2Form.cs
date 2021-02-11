namespace R440O.R440OForms.PU_K1_2
{
    using System.Windows.Forms;
    using Parameters;
    using ThirdParty;

    /// <summary>
    /// Форма блока пульт управления К01-2
    /// </summary>
    public partial class PU_K1_2Form : Form
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="PU_K1_2Form"/>
        /// </summary>
        public PU_K1_2Form()
        {
            this.InitializeComponent();
            this.InitializeTogglePosition();
        }

        /// <summary>
        /// Задание начальных положений переключателей
        /// </summary>
        private void InitializeTogglePosition()
        {
            var angle = PU_K1_2Parameters.PU_K1_2ПереключательКаналы * 30 - 75;
            PU_K1_2ПереключательКаналы.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType3, angle);

            angle = PU_K1_2Parameters.PU_K1_2ПереключательНапряжение * 28 - 180;
            PU_K1_2ПереключательНапряжение.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType3, angle);
        }

        #region Взаимодействие с элементами управления
        private void PU_K1_2ТумблерПитание_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) PU_K1_2Parameters.PU_K1_2ТумблерПитание--;
            else PU_K1_2Parameters.PU_K1_2ТумблерПитание++;

            switch (PU_K1_2Parameters.PU_K1_2ТумблерПитание)
            {
                case 0:
                    {
                        PU_K1_2ТумблерПитание.BackgroundImage = ControlElementImages.tumblerType6Up;
                        PU_K1_2Parameters.PU_K1_2ЛампочкаCеть = true;
                    }
                    break;
                case 1:
                    {
                        PU_K1_2ТумблерПитание.BackgroundImage = null;
                        PU_K1_2Parameters.PU_K1_2ЛампочкаCеть = false;
                    }
                    break;
                case 2:
                    {
                        PU_K1_2ТумблерПитание.BackgroundImage = ControlElementImages.tumblerType6Down;
                        PU_K1_2Parameters.PU_K1_2ЛампочкаCеть = false;
                    }
                    break;
            }

            PU_K1_2ЛампочкаCеть.BackgroundImage = PU_K1_2Parameters.PU_K1_2ЛампочкаCеть
                ? ControlElementImages.lampType9OnGreen
                : null;
        }

        private void PU_K1_2ПереключательКаналы_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PU_K1_2Parameters.PU_K1_2ПереключательКаналы++;
            }
            else
            {
                PU_K1_2Parameters.PU_K1_2ПереключательКаналы--;
            }

            var angle = PU_K1_2Parameters.PU_K1_2ПереключательКаналы * 30 - 75;
            PU_K1_2ПереключательКаналы.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType3, angle);
        }

        private void PU_K1_2ПереключательНапряжение_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PU_K1_2Parameters.PU_K1_2ПереключательНапряжение++;
            }
            else
            {
                PU_K1_2Parameters.PU_K1_2ПереключательНапряжение--;
            }

            var angle = PU_K1_2Parameters.PU_K1_2ПереключательНапряжение * 28 - 180;
            PU_K1_2ПереключательНапряжение.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType3, angle);
        }
        #endregion

        private void PU_K1_2ТумблерВентВкл_Click(object sender, System.EventArgs e)
        {
            if (PU_K1_2Parameters.PU_K1_2ТумблерВентВкл)
            {
                this.PU_K1_2ТумблерВентВкл.BackgroundImage = ControlElementImages.tumblerType4Down;
                PU_K1_2Parameters.PU_K1_2ТумблерВентВкл = false;
            }
            else
            {
                this.PU_K1_2ТумблерВентВкл.BackgroundImage = ControlElementImages.tumblerType4Up;
                PU_K1_2Parameters.PU_K1_2ТумблерВентВкл = true;
            }
        }
    }
}