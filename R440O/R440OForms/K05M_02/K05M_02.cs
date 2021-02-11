using System.Linq;
using R440O.Parameters;
using R440O.ThirdParty;

namespace R440O.R440OForms.K05M_02
{
    using System.Windows.Forms;
    using K05M_02Inside;

    /// <summary>
    /// Форма блока К05-М-2
    /// </summary>
    public partial class K05M_02Form : Form
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="K05M_02Form"/>
        /// </summary>
        public K05M_02Form()
        {
            this.InitializeComponent();
            this.InitializeToggles();
        }

        /// <summary>
        /// Открытие формы внутренней части блока
        /// </summary>
        /// <param name="sender">Объет вызвавший событие</param>
        /// <param name="e">Событие закрытия формы</param>
        private void K05M_02ButtonInside_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            Form thisForm = new K05M_02InsideForm();
            thisForm.Show(this);
        }

        private void InitializeToggles()
        {
            foreach (Control item in K05M_02Panel.Controls)
            {
                var propertiesList = typeof(K05M_02Parameters).GetProperties();
                foreach (var property in propertiesList.Where(property => item.Name == property.Name))
                {
                    if (item.Name.Contains("K05M_02ПереключательРодРаботы") ||
                        item.Name.Contains("K05M_02ПереключательОслабление"))
                    {
                        var angle = (int)property.GetValue(null) * 30 - 30;
                        item.BackgroundImage =
                            TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);
                    }
                    else
                    {
                        var angle = (int)property.GetValue(null) * 30 - 45;
                        item.BackgroundImage =
                            TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);
                    }
                }
            }
        }

        private void K05M_02Переключатель_MouseDown(object sender, MouseEventArgs e)
        {
            var item = sender as Button;
            var property = typeof(K05M_02Parameters).GetProperty(item.Name);
            if (e.Button == MouseButtons.Left)
            {
                property.SetValue(null, (int)property.GetValue(null) + 1);
            }

            if (e.Button == MouseButtons.Right)
            {
                property.SetValue(null, (int)property.GetValue(null) - 1);
            }

            if (item.Name.Contains("K05M_02ПереключательРодРаботы") ||
                        item.Name.Contains("K05M_02ПереключательОслабление"))
            {
                var angle = (int)property.GetValue(null) * 30 - 30;
                item.BackgroundImage =
                    TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);
            }
            else
            {
                var angle = (int)property.GetValue(null) * 30 - 45;
                item.BackgroundImage =
                    TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);
            }
        }
    }
}