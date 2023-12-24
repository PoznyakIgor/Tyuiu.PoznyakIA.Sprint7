using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using Tyuiu.PoznyakIA.Sprint7.Project.V2.Lib;
namespace Tyuiu.PoznyakIA.Sprint7.Project.V2
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        static int rows;
        static int columns;
        static string openFilePath;
        DataService ds = new DataService();

        private void buttonOpenFile_PIA_Click(object sender, EventArgs e)
        {
            try
            {   
                openFileDialogButton_PIA.ShowDialog();
                openFilePath = openFileDialogButton_PIA.FileName;

                string[,] matrix = ds.LoadFromDataFile(openFilePath);

                rows = matrix.GetLength(0);
                columns = matrix.GetLength(1);

                dataGridViewDataBase_PIA.RowCount = rows + 1;
                dataGridViewDataBase_PIA.ColumnCount = columns;

                
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        dataGridViewDataBase_PIA.Rows[i].Cells[j].Value = matrix[i, j];
                    }
                }
                dataGridViewDataBase_PIA.AutoResizeColumns();
                dataGridViewDataBase_PIA.ScrollBars = ScrollBars.Both;
                buttonSaveFile_PIA.Enabled = true;
                buttonAddRow_PIA.Enabled = true;
                buttonDeleteRow_PIA.Enabled = true;


            }
            catch
            {
                MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSaveFile_PIA_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialogMain_PIA.FileName = ".csv";
                saveFileDialogMain_PIA.InitialDirectory = @":L";
                if (saveFileDialogMain_PIA.ShowDialog() == DialogResult.OK)
                {
                    string savepath = saveFileDialogMain_PIA.FileName;

                    if (File.Exists(savepath)) File.Delete(savepath);

                    int rows = dataGridViewDataBase_PIA.RowCount;
                    int columns = dataGridViewDataBase_PIA.ColumnCount;

                    StringBuilder strBuilder = new StringBuilder();

                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            strBuilder.Append(dataGridViewDataBase_PIA.Rows[i].Cells[j].Value);

                            if (j != columns - 1) strBuilder.Append(";"); // ???
                        }
                        strBuilder.AppendLine();
                    }
                    File.WriteAllText(savepath, strBuilder.ToString(), Encoding.GetEncoding(1251));
                    MessageBox.Show("Файл успешно сохранен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Файл не сохранен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddRow_PIA_Click(object sender, EventArgs e)
        {
            string Articule_SAN = textBoxArticuleAdd_PIA.Text;
            string otdel_SAN = textBoxOtdelAdd_PIA.Text;
            string name_SAN = textBoxNameAdd_PIA.Text;
            string CountSklad_SAN = textBoxCountSkadAdd_PIA.Text;
            string CountUpakovka_SAN = textBoxCountUpaAdd_PIA.Text;
            string CountUpakovok_SAN = textBoxCountUpakovokadd_PIA.Text;
            string postavshik_SAN = textBoxPostavshikAdd_PIA.Text;
            string price_SAN = textBoxPriceAdd_PIA.Text;


            // заполнение
            dataGridViewDataBase_PIA.Rows.Add(Articule_SAN, otdel_SAN, name_SAN, CountSklad_SAN, CountUpakovka_SAN, CountUpakovok_SAN, postavshik_SAN, price_SAN);
            textBoxArticuleAdd_PIA.Text = "";
            textBoxOtdelAdd_PIA.Text = "";
            textBoxNameAdd_PIA.Text = "";
            textBoxCountSkadAdd_PIA.Text = "";
            textBoxCountUpaAdd_PIA.Text = "";
            textBoxCountUpakovokadd_PIA.Text = "";
            textBoxPostavshikAdd_PIA.Text = "";
            textBoxPriceAdd_PIA.Text = "";
            dataGridViewDataBase_PIA.CurrentCell = dataGridViewDataBase_PIA.Rows[dataGridViewDataBase_PIA.Rows.Count - 1].Cells[0];
        }

        private void buttonDeleteRow_PIA_Click(object sender, EventArgs e)
        {
            if (dataGridViewDataBase_PIA.RowCount != 0)
            {
                int del = 0;
                var result = MessageBox.Show($"{"Удалить данную строку?\rЕё невозможно будет восстановить"}", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    del = 1;
                }
                if (del == 1)
                {
                    int a = dataGridViewDataBase_PIA.CurrentCell.RowIndex;
                    dataGridViewDataBase_PIA.Rows.RemoveAt(a);
                }
            }
            else
            {
                MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAboutProgramm_PIA_Click(object sender, EventArgs e)
        {
            FormAboutProgram_PIA formOProgramme = new FormAboutProgram_PIA();
            formOProgramme.ShowDialog();
        }

        private void buttonAboutDeveloper_PIA_Click(object sender, EventArgs e)
        {
            FormAbout_PIA formAbout = new FormAbout_PIA();
            formAbout.ShowDialog();
        }
    }
}
