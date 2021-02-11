//-----------------------------------------------------------------------
// <copyright file="R440OForm.cs" company="VKISPU">
//      R440O station.
// </copyright>
//-----------------------------------------------------------------------

namespace R440O.R440OForms.R440O
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using InternalBlocks;
    using global::R440O.LearnModule;
    using System.Threading;

    /// <summary>
    /// Форма станции Р440-О
    /// </summary>
    public partial class R440OForm : Form
    {
        public event Action FormClosedEvent;
        CancellationTokenSource ct = new CancellationTokenSource();
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="R440OForm"/>
        /// </summary>
        public R440OForm()
        {
            this.InitializeComponent();
            Antenna.StartServerPing();
            Antenna.ErrorEvent += ServerError;
            TextHelperForm textHelper = new TextHelperForm();
            textHelper.Show();
            LearnMain.setHelpForms(this,textHelper);
            LearnMain.setIntent(ModulesEnum.openPowerCabeltoPower);

        }

        private bool serverErrorFlag = false;
        private void ServerError()
        {
            if (!serverErrorFlag)
            {
                serverErrorFlag = true;
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show("Возникла проблема с сервером!");
                    this.Close();
                }));
            }
        }

        /// <summary>
        /// Открытие формы блока в соотвествии с нажатой кнопкой
        /// </summary>
        /// <param name="sender">Нажатая кнопка</param>
        /// <param name="e">Событие нажатия</param>
        private void R440OButtonCommon_Click(object sender, EventArgs e)
        {

            var button = (Button)sender;

            const string buttonStrings = "Button";
            var blockName =
                button.Name.Substring(button.Name.IndexOf(buttonStrings, StringComparison.Ordinal) + buttonStrings.Length);
            var formName = blockName + "Form";

            // Активация формы соответствующей нажатой кнопке
            foreach (var form in OwnedForms.Where(form => form.Name == formName))
            {
                form.WindowState = FormWindowState.Normal;
                form.Activate();
                return;
            }

     
          



       

            if ((button.Name == "R440OButtonPowerCabel") && (LearnMain.getIntent() == ModulesEnum.openPowerCabeltoPower))
            {
                LearnMain.setIntent(ModulesEnum.PowerCabelConnect);
            }


            // Открытие новой формы соответствующей нажатой кнопке
            try
            {
                const string r440OFormsString = "R440O.R440OForms.";
                var typeName = r440OFormsString + blockName + "." + formName;
                // ReSharper disable once AssignNullToNotNullAttribute by trycatch
                var thisForm = Activator.CreateInstance(Type.GetType(typeName));
                var newForm = (Form)thisForm;
                newForm.Show(this);
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        private void R440OForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Antenna.StopServerPing();
            if (FormClosedEvent != null)
            {
                FormClosedEvent();
            }
        }

        private void R440OForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Antenna.StopServerPing();
        }

        private void R440OForm_Activated(object sender, EventArgs e)
        {
           
            if (LearnMain.getIntent() == ModulesEnum.N502Power) LearnMain.setIntent(ModulesEnum.openN502BtoPower);
            if (LearnMain.getIntent() == ModulesEnum.N502Check) LearnMain.setIntent(ModulesEnum.openN502BtoCheck);
            if (LearnMain.getIntent() == ModulesEnum.PowerCabelConnect) LearnMain.setIntent(ModulesEnum.openPowerCabeltoPower);
            
        }
    }
}