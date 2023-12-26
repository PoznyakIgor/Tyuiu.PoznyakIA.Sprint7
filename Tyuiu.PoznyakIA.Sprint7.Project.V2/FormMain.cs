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
                for (int i = 0; i < dataGridViewDataBase_PIA.RowCount - 1; i++)
                {

                    if (dataGridViewDataBase_PIA.Rows[i].Cells[3].Value.ToString() == "")
                    {
                        dataGridViewDataBase_PIA.Rows.RemoveAt(i);
                        i--;
                    }
                }

                buttonSaveFile_PIA.Enabled = true;
                buttonDeleteRow_PIA.Enabled = true;
                buttonSum_PIA.Enabled = true;             
                buttonDone_PIA.Enabled = true;

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
            string Articule_PIA = textBoxNumberAdd_PIA.Text;
            string CountUpakovka_PIA = textBoxNameAdd_PIA.Text;
            string CountUpakovok_PIA = textBoxAdresAdd_PIA.Text;
            string postavshik_PIA = textBoxNumberPhoneAdd_PIA.Text;
            string price_PIA = textBoxBudgetAdd_PIA.Text;


            // заполнение
            dataGridViewDataBase_PIA.Rows.Add(Articule_PIA, CountUpakovka_PIA, CountUpakovok_PIA, postavshik_PIA, price_PIA);
            textBoxNumberAdd_PIA.Text = "";
            textBoxNameAdd_PIA.Text = "";
            textBoxAdresAdd_PIA.Text = "";
            textBoxNumberPhoneAdd_PIA.Text = "";
            textBoxBudgetAdd_PIA.Text = "";
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

        private void comboBoxFilter_PIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valueFilt = comboBoxFilter_PIA.SelectedItem.ToString(); //извлечение строкового значения выбранного элемента ComboBox
            if (!string.IsNullOrEmpty(valueFilt))
            {
                foreach (DataGridViewRow row in dataGridViewDataBase_PIA.Rows)
                {
                    if (!row.IsNewRow) // проверка новая ли строка
                    {
                        if (row.Cells["ColumnAdres_PIA"].Value != null && row.Cells["ColumnAdres_PIA"].Value.ToString() == valueFilt)
                        {
                            row.Visible = true;
                        }
                        else
                        {
                            row.Visible = false;
                        }
                    }
                }
            }
        }

        private void comboBoxNumber_PIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxNumber_PIA.SelectedItem != null)
            {
                int columnIndex = 0;
                string selectedItem = comboBoxNumber_PIA.SelectedItem.ToString();
                foreach (DataGridViewRow row in dataGridViewDataBase_PIA.Rows)
                {
                    double cellValue;
                    if (row.Cells[columnIndex].Value != null && double.TryParse(row.Cells[columnIndex].Value.ToString(), out cellValue))
                    {
                        row.Cells[columnIndex].Value = cellValue;
                    }
                }
                try
                {

                    string[,] matrix = ds.LoadFromDataFile(openFilePath);

                    rows = matrix.GetLength(0);
                    columns = matrix.GetLength(1);

                    dataGridViewDataBase_PIA.RowCount = rows + 1;
                    dataGridViewDataBase_PIA.ColumnCount = columns;

                    DataGridViewColumn column = dataGridViewDataBase_PIA.Columns[0];

                    if (selectedItem == "По возрастанию")
                    {
                        dataGridViewDataBase_PIA.Sort(column, ListSortDirection.Descending);

                    }
                    if (selectedItem == "По убыванию")
                    {
                        dataGridViewDataBase_PIA.Sort(column, ListSortDirection.Ascending);
                    }
                    if (selectedItem == "Сбросить сортировку")
                    {
                        for (int i = 0; i < rows; i++)
                        {
                            for (int j = 0; j < columns; j++)
                            {
                                dataGridViewDataBase_PIA.Rows[i].Cells[j].Value = matrix[i, j];
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Невозможно выполнить сортировку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void comboBoxSort_PIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSort_PIA.SelectedItem != null)
            {
                int columnIndex = 4;
                string selectedItem = comboBoxSort_PIA.SelectedItem.ToString();
                foreach (DataGridViewRow row in dataGridViewDataBase_PIA.Rows)
                {
                    double cellValue;
                    if (row.Cells[columnIndex].Value != null && double.TryParse(row.Cells[columnIndex].Value.ToString(), out cellValue))
                    {
                        row.Cells[columnIndex].Value = cellValue;
                    }
                }
                try
                {

                    string[,] matrix = ds.LoadFromDataFile(openFilePath);

                    rows = matrix.GetLength(0);
                    columns = matrix.GetLength(1);

                    dataGridViewDataBase_PIA.RowCount = rows + 1;
                    dataGridViewDataBase_PIA.ColumnCount = columns;

                    DataGridViewColumn column = dataGridViewDataBase_PIA.Columns[4];

                    if (selectedItem == "По возрастанию")
                    {
                        dataGridViewDataBase_PIA.Sort(column, ListSortDirection.Descending);

                    }
                    if (selectedItem == "По убыванию")
                    {
                        dataGridViewDataBase_PIA.Sort(column, ListSortDirection.Ascending);
                    }
                    if (selectedItem == "Сбросить сортировку")
                    {
                        for (int i = 0; i < rows; i++)
                        {
                            for (int j = 0; j < columns; j++)
                            {
                                dataGridViewDataBase_PIA.Rows[i].Cells[j].Value = matrix[i, j];
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Невозможно выполнить сортировку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSum_PIA_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < dataGridViewDataBase_PIA.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridViewDataBase_PIA.Rows[i].Cells[4].Value);
            }
            textBoxSum_PIA.Text = sum.ToString();
        }

        private void textBoxPoiskAdres_PIA_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBoxPoiskAdres_PIA.Text.ToLower(); //приведение к нижнему регистру
            foreach (DataGridViewRow row in dataGridViewDataBase_PIA.Rows)
            {
                if (row.Cells["ColumnAdres_PIA"].Value != null)
                {
                    string column6Text = row.Cells["ColumnAdres_PIA"].Value.ToString().ToLower();
                    if (column6Text.Contains(searchText))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
        }

        private void textBoxPoiskNumberPhone_PIA_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBoxPoiskNumberPhone_PIA.Text.ToLower(); //приведение к нижнему регистру
            foreach (DataGridViewRow row in dataGridViewDataBase_PIA.Rows)
            {
                if (row.Cells["ColumnNumberPhone_PIA"].Value != null)
                {
                    string column6Text = row.Cells["ColumnNumberPhone_PIA"].Value.ToString().ToLower();
                    if (column6Text.Contains(searchText))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
        }

        private void textBoxNumber_PIA_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBoxNumber_PIA.Text.ToLower(); //приведение к нижнему регистру
            foreach (DataGridViewRow row in dataGridViewDataBase_PIA.Rows)
            {
                if (row.Cells["ColumnNumber_PIA"].Value != null)
                {
                    string column6Text = row.Cells["ColumnNumber_PIA"].Value.ToString().ToLower();
                    if (column6Text.Contains(searchText))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
        }

        private void buttonAboutProgramm_PIA_Click(object sender, EventArgs e)
        {
            FormAboutDeveloper formAbout = new FormAboutDeveloper();
            formAbout.ShowDialog();
        }

        private void buttonDone_PIA_Click(object sender, EventArgs e)
        {
            try
            {
                this.chartDataBase_PIA.Series[0].Points.Clear();
                int rows = dataGridViewDataBase_PIA.RowCount;
                int columns = dataGridViewDataBase_PIA.ColumnCount;
                string str;
                string[,] matrix = new string[rows, columns];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        str = "";
                        str += dataGridViewDataBase_PIA.Rows[i].Cells[j].Value;
                        matrix[i, j] = str;
                    }

                }

                for (int i = 0; i < rows; i++)
                {
                    this.chartDataBase_PIA.Series[0].Points.AddXY(matrix[i, 0], matrix[i, 4]);
                }











            }
            catch
            {
                MessageBox.Show("Невозможно построить график", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAboutDeveloper_PIA_Click(object sender, EventArgs e)
        {
            FormAboutProgram formAbout = new FormAboutProgram();
            formAbout.ShowDialog();
        }
    }
}
