//-----------------------------------------------------------------------
// <copyright file="Rubin_NForm.cs" company="VKISPU">
//      R440O station.
// </copyright>
//-----------------------------------------------------------------------

using ShareTypes.SignalTypes;
using R440O.Parameters;
using R440O.ThirdParty;
using R440O.BaseClasses;
using System.Windows.Forms;
using R440O.TestModule;
using System;

namespace R440O.R440OForms.Rubin_N
{
    

    /// <summary>
    /// Форма блока пульт управления Рубин-Н
    /// </summary>
    public partial class Rubin_NForm : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Rubin_NForm"/>
        /// </summary>
        public Rubin_NForm()
        {
            InitializeComponent();
            Rubin_NParameters.getInstance().ParameterChanged += RefreshFormElements;
            RefreshFormElements();
        }

        #region Инициализация

        public void RefreshFormElements()
        {
            InitializeButtonsPosition();
            InitializeTogglesPosition();
            InitializeTumblersPosition();
        }

        private void InitializeButtonsPosition()
        {
            if (Rubin_NParameters.getInstance().КнопкаВкл)
            {
                КнопкаВкл.BackgroundImage = null;
                КнопкаВкл.Text = string.Empty;
            }
            else
            {
                КнопкаВкл.BackgroundImage = ControlElementImages.buttonSquareYellow;
                КнопкаВкл.Text = "ВКЛ";
            }

            if (Rubin_NParameters.getInstance().КнопкаОткл)
            {
                КнопкаОткл.BackgroundImage = null;
                КнопкаОткл.Text = string.Empty;
            }
            else
            {
                КнопкаОткл.BackgroundImage = ControlElementImages.buttonSquareYellow;
                КнопкаОткл.Text = "ОТКЛ";
            }
        }

        private void InitializeTogglesPosition()
        {
            var angle = Rubin_NParameters.getInstance().ПереключательГрупСкор * 33 - 80;
            ПереключательГрупСкор.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = Rubin_NParameters.getInstance().ПереключательКонтроль * 35 - 85;
            ПереключательКонтроль.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = Rubin_NParameters.getInstance().ПереключательN5063_2кБод * 35 - 85;
            ПереключательN5063_2кБод.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = Rubin_NParameters.getInstance().ПереключательN5063_6812кБод * 17 - 170;
            ПереключательN5063_6812кБод.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = Rubin_NParameters.getInstance().ПереключательN5063_48кБод * 35 - 185;
            ПереключательN5063_48кБод.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = Rubin_NParameters.getInstance().ПереключательN4963_2кБод * 35 - 85;
            ПереключательN4963_2кБод.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = Rubin_NParameters.getInstance().ПереключательN4963_6812кБод * 17 - 170;
            ПереключательN4963_6812кБод.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = Rubin_NParameters.getInstance().ПереключательN4963_48кБод * 35 - 185;
            ПереключательN4963_48кБод.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = Rubin_NParameters.getInstance().ПереключательN4923_2кБод * 35 - 85;
            ПереключательN4923_2кБод.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = Rubin_NParameters.getInstance().ПереключательN4923_6812кБод * 17 - 170;
            ПереключательN4923_6812кБод.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = Rubin_NParameters.getInstance().ПереключательN4923_48кБод * 35 - 185;
            ПереключательN4923_48кБод.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);
        }

        private void InitializeTumblersPosition()
        {
            ТумблерПолярность.BackgroundImage = Rubin_NParameters.getInstance().ТумблерПолярность
              ? ControlElementImages.tumblerType4Left
              : ControlElementImages.tumblerType4Right;

            ТумблерБлок5063.BackgroundImage = Rubin_NParameters.getInstance().ТумблерРнБас1
              ? ControlElementImages.tumblerType4Left
              : ControlElementImages.tumblerType4Right;

            ТумблерБлок4923.BackgroundImage = Rubin_NParameters.getInstance().ТумблерРнБас2
              ? ControlElementImages.tumblerType4Left
              : ControlElementImages.tumblerType4Right;

            ТумблерБлок4963.BackgroundImage = Rubin_NParameters.getInstance().ТумблерРнБас3
              ? ControlElementImages.tumblerType4Left
              : ControlElementImages.tumblerType4Right;
        }
        #endregion

        #region Переключатели
        private void ПереключательГрупСкор_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Rubin_NParameters.getInstance().ПереключательГрупСкор += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                Rubin_NParameters.getInstance().ПереключательГрупСкор -= 1;
            }
        }

        private void ПереключательКонтроль_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Rubin_NParameters.getInstance().ПереключательКонтроль += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                Rubin_NParameters.getInstance().ПереключательКонтроль -= 1;
            }
        }

        private void ПереключательN5063_2кБод_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Rubin_NParameters.getInstance().ПереключательN5063_2кБод += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                Rubin_NParameters.getInstance().ПереключательN5063_2кБод -= 1;
            }
        }

        private void ПереключательN5063_6812кБод_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Rubin_NParameters.getInstance().ПереключательN5063_6812кБод += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                Rubin_NParameters.getInstance().ПереключательN5063_6812кБод -= 1;
            }
        }

        private void ПереключательN5063_48кБод_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Rubin_NParameters.getInstance().ПереключательN5063_48кБод += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                Rubin_NParameters.getInstance().ПереключательN5063_48кБод -= 1;
            }
        }

        private void ПереключательN4923_2кБод_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Rubin_NParameters.getInstance().ПереключательN4923_2кБод += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                Rubin_NParameters.getInstance().ПереключательN4923_2кБод -= 1;
            }
        }

        private void ПереключательN4923_6812кБод_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Rubin_NParameters.getInstance().ПереключательN4923_6812кБод += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                Rubin_NParameters.getInstance().ПереключательN4923_6812кБод -= 1;
            }
        }

        private void ПереключательN4923_48кБод_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Rubin_NParameters.getInstance().ПереключательN4923_48кБод += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                Rubin_NParameters.getInstance().ПереключательN4923_48кБод -= 1;
            }
        }

        private void ПереключательN4963_2кБод_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Rubin_NParameters.getInstance().ПереключательN4963_2кБод += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                Rubin_NParameters.getInstance().ПереключательN4963_2кБод -= 1;
            }
        }

        private void ПереключательN4963_6812кБод_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Rubin_NParameters.getInstance().ПереключательN4963_6812кБод += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                Rubin_NParameters.getInstance().ПереключательN4963_6812кБод -= 1;
            }
        }

        private void ПереключательN4963_48кБод_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Rubin_NParameters.getInstance().ПереключательN4963_48кБод += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                Rubin_NParameters.getInstance().ПереключательN4963_48кБод -= 1;
            }
        }
        #endregion

        #region Кнопки
        private void Rubin_NКнопкаОсн_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаОсн.BackgroundImage = null;
        }

        private void Rubin_NКнопкаОсн_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаОсн.BackgroundImage = ControlElementImages.buttonRoundType7;
        }

        private void Rubin_NКнопкаРезервированиеВкл_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаРезервированиеВкл.BackgroundImage = null;
        }

        private void Rubin_NКнопкаРезервированиеВкл_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаРезервированиеВкл.BackgroundImage = ControlElementImages.buttonRoundType7;
        }

        private void Rubin_NКнопкаРезервированиеОткл_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаРезервированиеОткл.BackgroundImage = null;
        }

        private void Rubin_NКнопкаРезервированиеОткл_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаРезервированиеОткл.BackgroundImage = ControlElementImages.buttonRoundType7;
        }

        private void Rubin_NКнопкаТранзит_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаТранзит.BackgroundImage = null;
        }

        private void Rubin_NКнопкаТранзит_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаТранзит.BackgroundImage = ControlElementImages.buttonRoundType7;
        }

        private void Rubin_NКнопкаРабота_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаРабота.BackgroundImage = null;
        }

        private void Rubin_NКнопкаРабота_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаРабота.BackgroundImage = ControlElementImages.buttonRoundType7;
        }

        private void Rubin_NКнопкаВкл_Click(object sender, System.EventArgs e)
        {
            if (Rubin_NParameters.getInstance().КнопкаВкл)
            {
                КнопкаВкл.BackgroundImage = ControlElementImages.buttonSquareYellow;
                КнопкаВкл.Text = "ВКЛ";
            }
            else
            {
                КнопкаВкл.BackgroundImage = null;
                КнопкаВкл.Text = string.Empty;
            }
            Rubin_NParameters.getInstance().КнопкаВкл = !Rubin_NParameters.getInstance().КнопкаВкл;
        }

        private void Rubin_NКнопкаОткл_Click(object sender, System.EventArgs e)
        {
            if (Rubin_NParameters.getInstance().КнопкаОткл)
            {
                КнопкаОткл.BackgroundImage = ControlElementImages.buttonSquareYellow;
                КнопкаОткл.Text = "ОТКЛ";
            }
            else
            {
                КнопкаОткл.BackgroundImage = null;
                КнопкаОткл.Text = string.Empty;
            }
            Rubin_NParameters.getInstance().КнопкаОткл = !Rubin_NParameters.getInstance().КнопкаОткл;
        }

        #endregion

        #region Тумблеры
        private void Rubin_NТумблерПолярность_Click(object sender, System.EventArgs e)
        {
            Rubin_NParameters.getInstance().ТумблерПолярность = !Rubin_NParameters.getInstance().ТумблерПолярность;
        }

        private void Rubin_NТумблерБлок5063_Click(object sender, System.EventArgs e)
        {
            Rubin_NParameters.getInstance().ТумблерРнБас1 = !Rubin_NParameters.getInstance().ТумблерРнБас1;
        }

        private void Rubin_NТумблерБлок4923_Click(object sender, System.EventArgs e)
        {
            Rubin_NParameters.getInstance().ТумблерРнБас2 = !Rubin_NParameters.getInstance().ТумблерРнБас2;
        }

        private void Rubin_NТумблерБлок4963_Click(object sender, System.EventArgs e)
        {
            Rubin_NParameters.getInstance().ТумблерРнБас3 = !Rubin_NParameters.getInstance().ТумблерРнБас3;
        }
        #endregion

        private void Rubin_NForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ParametersConfig.IsTesting)
            {
                var blockParams = Rubin_NParameters.getInstance();
                bool def = blockParams.ПереключательКонтроль == 1;

                TestMain.Action(new JsonAdapter.ActionStation() { Module = LearnModule.ModulesEnum.Check_RUBIN, Value = Convert.ToInt32(def) });
            }
        }
    }
}