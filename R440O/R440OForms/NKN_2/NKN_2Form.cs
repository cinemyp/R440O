using ShareTypes.SignalTypes;
using R440O.BaseClasses;

namespace R440O.R440OForms.NKN_2
{
    using System.Windows.Forms;

    /// <summary>
    /// Форма блока НКН-1
    /// </summary>
    public partial class NKN_2Form : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="NKN_2Form"/>
        /// </summary>
        public NKN_2Form()
        {
            this.InitializeComponent();
            NKN_2Parameters.getInstance().ParameterChanged += RefreshFormElements;
            RefreshFormElements();
        }

        /// <summary>
        /// Инициализация начальных положений
        /// </summary>
        public void RefreshFormElements()
        {
            ЛампочкаМУ.BackgroundImage = NKN_2Parameters.getInstance().ЛампочкаМУ
                ? ControlElementImages.lampType9OnGreen
                : null;
            ЛампочкаФаза1.BackgroundImage = NKN_2Parameters.getInstance().ЛампочкаФаза1
                ? ControlElementImages.lampType9OnGreen
                : null;
            ЛампочкаФаза2.BackgroundImage = NKN_2Parameters.getInstance().ЛампочкаФаза2
                ? ControlElementImages.lampType9OnGreen
                : null;
            ЛампочкаФаза3.BackgroundImage = NKN_2Parameters.getInstance().ЛампочкаФаза3
                ? ControlElementImages.lampType9OnGreen
                : null;
        }

        #region Кнопки местного включения блока
        private void Кнопка220Вкл_MouseDown(object sender, MouseEventArgs e)
        {
            Кнопка220Вкл.BackgroundImage = ControlElementImages.buttonRoundType4;
        }

        private void Кнопка220Вкл_MouseUp(object sender, MouseEventArgs e)
        {
            Кнопка220Вкл.BackgroundImage = null;
            NKN_2Parameters.getInstance().Питание220Включено = true;
        }

        private void Кнопка220Откл_MouseDown(object sender, MouseEventArgs e)
        {
            Кнопка220Откл.BackgroundImage = ControlElementImages.buttonRoundType4;
        }

        private void Кнопка220Откл_MouseUp(object sender, MouseEventArgs e)
        {
            Кнопка220Откл.BackgroundImage = null;
            NKN_2Parameters.getInstance().Питание220Включено = false;
        }
        #endregion

        private void NKN_2Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            NKN_2Parameters.getInstance().ParameterChanged -= RefreshFormElements;
        }
    }
}