using ShareTypes.SignalTypes;
using R440O.BaseClasses;

namespace R440O.R440OForms.NKN_1
{
    using System.Windows.Forms;

    /// <summary>
    /// Форма блока НКН-1
    /// </summary>
    public partial class NKN_1Form : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="NKN_1Form"/>
        /// </summary>
        public NKN_1Form()
        {
            this.InitializeComponent();
            NKN_1Parameters.ParameterChanged += RefreshFormElements;
            RefreshFormElements();
        }

        /// <summary>
        /// Инициализация начальных положений
        /// </summary>
        public void RefreshFormElements()
        {
            ЛампочкаМУ.BackgroundImage = NKN_1Parameters.ЛампочкаМУ
                ? ControlElementImages.lampType9OnGreen
                : null;
            ЛампочкаФаза1.BackgroundImage = NKN_1Parameters.ЛампочкаФаза1
                ? ControlElementImages.lampType9OnGreen
                : null;
            ЛампочкаФаза2.BackgroundImage = NKN_1Parameters.ЛампочкаФаза2
                ? ControlElementImages.lampType9OnGreen
                : null;
            ЛампочкаФаза3.BackgroundImage = NKN_1Parameters.ЛампочкаФаза3
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
            NKN_1Parameters.Питание220Включено = true;
        }

        private void Кнопка220Откл_MouseDown(object sender, MouseEventArgs e)
        {
            Кнопка220Откл.BackgroundImage = ControlElementImages.buttonRoundType4;
        }

        private void Кнопка220Откл_MouseUp(object sender, MouseEventArgs e)
        {
            Кнопка220Откл.BackgroundImage = null;
            NKN_1Parameters.Питание220Включено = false;
        }
        #endregion

        private void NKN_1Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            NKN_1Parameters.ParameterChanged -= RefreshFormElements;
        }
    }
}