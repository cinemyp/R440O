using System.Linq;
using R440O.R440OForms.K03M_01;
using R440O.R440OForms.N15;
using R440O.ThirdParty;

namespace R440O.R440OForms.K05M_01
{
    using System.Windows.Forms;
    using K05M_01Inside;

    /// <summary>
    /// Форма блока К05-М-1
    /// </summary>
    public partial class K05M_01Form : Form
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="K05M_01Form"/>
        /// </summary>
        public K05M_01Form()
        {
            this.InitializeComponent();
            K05M_01Parameters.ParameterChanged += this.InitializeToggles;
            this.InitializeToggles();
        }

        /// <summary>
        /// Открытие формы внутренней части блока
        /// </summary>
        /// <param name="sender">Объет вызвавший событие</param>
        /// <param name="e">Событие закрытия формы</param>
        private void ButtonInside_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            Form thisForm = new K05M_01InsideForm();
            thisForm.Show(this);
        }

        private void InitializeToggles()
        {
            foreach (Control item in K05M_01Panel.Controls)
            {
                var propertiesList = typeof(K05M_01Parameters).GetProperties();
                foreach (var property in propertiesList.Where(property => item.Name == property.Name))
                {
                    if (item.Name.Contains("ПереключательРодРаботы") ||
                        item.Name.Contains("ПереключательОслабление"))
                    {
                        var angle = (int) property.GetValue(null)*30 - 30;
                        item.BackgroundImage =
                            TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);
                    }
                    else
                    {
                        if(item.Name.Contains("СтрелкаУровень"))
                        {
                            var angle = (int) property.GetValue(null)*10*6f/36f;
                            item.BackgroundImage =
                                TransformImageHelper.RotateImageByAngle(ControlElementImages.arrow2, angle);
                        }
                        else if (item.Name.Contains("РегуляторУровень"))
                        {
                            item.BackgroundImage = TransformImageHelper.RotateImageByAngle(
                                ControlElementImages.revolverRoundSmall,
                                (float)K05M_01Parameters.РегуляторУровень * 10);
                        }
                        else
                        {
                            var angle = (int) property.GetValue(null)*30 - 45;
                            item.BackgroundImage =
                                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);
                        }
                    }
                }
            }
        }

        private void Переключатель_MouseDown(object sender, MouseEventArgs e)
        {

            var item = sender as Button;
            var property = typeof(K05M_01Parameters).GetProperty(item.Name);
            if (e.Button == MouseButtons.Left)
            {
                property.SetValue(null, (int)property.GetValue(null) + 1);
            }

            if (e.Button == MouseButtons.Right)
            {
                property.SetValue(null, (int)property.GetValue(null) - 1);
            }
        }

        private static bool isManipulation = false;


        private void РегуляторУровень_MouseUp_1(object sender, MouseEventArgs e)
        {
            isManipulation = false;
        }

        private void РегуляторУровень_MouseDown_1(object sender, MouseEventArgs e)
        {
            isManipulation = true;
        }

        private void РегуляторУровень_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (!isManipulation) return;
            var button = sender as Button;
            var angle = TransformImageHelper.CalculateAngle(button.Width, button.Height, e);
            K05M_01Parameters.РегуляторУровень = angle / 10;
        }

       
    }
}