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
    using global::R440O.TestModule;
    using System.Threading;
    using System.Collections.Generic;
    using global::R440O.JsonAdapter;

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

            TestMain.close += Close;

            if(ParametersConfig.getIsLearning())
            {
                TextHelperForm textHelper = new TextHelperForm();
                textHelper.Show();
                LearnMain.setHelpForms(this, textHelper);
                LearnMain.setIntent(ModulesEnum.openPowerCabeltoPower);
            }
            else if(ParametersConfig.IsTesting)
                TestMain.setIntent(ModulesEnum.openPowerCabeltoPower);
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

            // Открытие новой формы соответствующей нажатой кнопке
            try
            {
                const string r440OFormsString = "R440O.R440OForms.";
                var typeName = r440OFormsString + blockName + "." + formName;
                // ReSharper disable once AssignNullToNotNullAttribute by trycatch
                var type = Type.GetType(typeName);
                var thisForm = Activator.CreateInstance(type);
                var newForm = (Form)thisForm;
                var controls = newForm.Controls[0].Controls;
                List<Button> list = new List<Button>();

                foreach (var c in controls.OfType<Button>())
                {
                    c.Click += (send, ev) => ClickHandler(send, ev);
                    list.Add(c);
                }

                newForm.Show(this);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void ClickHandler(object sender, EventArgs e)
        {
            var obj = (Button)sender;
            var parent = obj.Parent.Parent;
            
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
            LearnMain.CloseHelper();
            TestMain.close -= Close;
            SetDefaultParameters();
        }
        //На фокус
        private void R440OForm_Activated(object sender, EventArgs e)
        {

            if (LearnMain.getIntent() == ModulesEnum.N502Power) LearnMain.setIntent(ModulesEnum.openN502BtoPower);
            if (LearnMain.getIntent() == ModulesEnum.N502Check) LearnMain.setIntent(ModulesEnum.openN502BtoCheck);
            if (LearnMain.getIntent() == ModulesEnum.PowerCabelConnect) LearnMain.setIntent(ModulesEnum.openPowerCabeltoPower);

            //switch (TestMain.getIntent())
            //{
            //    case ModulesEnum.PowerCabelConnect:
            //        break;
            //}
        }

        private void SetDefaultParameters()
        {
            A306.A306Parameters.getInstance().SetDefaultParameters();
            A304.A304Parameters.getInstance().SetDefaultParameters();
            N15.N15Parameters.getInstance().SetDefaultParameters();
            N502B.N502BParameters.getInstance().SetDefaultParameters();
            VoltageStabilizer.VoltageStabilizerParameters.getInstance().SetDefaultParameters();
            PowerCabel.PowerCabelParameters.getInstance().SetDefaultParameters();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StationAdapterJson.StoreStationStateToJson();
        }
    }
}