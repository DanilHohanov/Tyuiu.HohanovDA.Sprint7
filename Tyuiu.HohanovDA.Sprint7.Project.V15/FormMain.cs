using System.Text;
using System.Windows.Forms;
using Tyuiu.HohanovDA.Sprint7.Project.V15.Lib;
namespace Tyuiu.HohanovDA.Sprint7.Project.V15
{
    public partial class FormMain : Form
    {

        private DataService ds = new DataService();
        private string[] names;
        private double[] incomes;
        private int[] documents;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void buttonbuttonLoadFile_HDA_Click(object sender, EventArgs e)
        {
            openFileDialogCsv_HDA.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialogCsv_HDA.Title = "Выберите файл data.csv";

            if (openFileDialogCsv_HDA.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Загружаем данные из CSV
                    string[,] rawData = ds.LoadFromFileData(openFileDialogCsv_HDA.FileName);

                    // Парсим в массивы
                    ds.ParseData(rawData, out names, out incomes, out documents);

                    // Заполняем DataGridView
                    dataGridViewTable_HDA.Rows.Clear();
                    dataGridViewTable_HDA.Columns.Clear();

                    dataGridViewTable_HDA.Columns.Add("ФИО", "ФИО");
                    dataGridViewTable_HDA.Columns.Add("Доход", "Доход");
                    dataGridViewTable_HDA.Columns.Add("Документы", "Документы");

                    for (int i = 0; i < names.Length; i++)
                    {
                        dataGridViewTable_HDA.Rows.Add(names[i], incomes[i], documents[i]);
                    }

                    this.Text = $"Анализ доходов - Загружено {names.Length} граждан";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveDataGridViewToCsv(string filePath)
        {
            var sb = new StringBuilder();

            // 1. Заголовки столбцов
            for (int col = 0; col < dataGridViewTable_HDA.Columns.Count; col++)
            {
                sb.Append(dataGridViewTable_HDA.Columns[col].HeaderText);
                if (col < dataGridViewTable_HDA.Columns.Count - 1)
                    sb.Append(";");
            }
            sb.AppendLine();

            // 2. Строки данных
            for (int row = 0; row < dataGridViewTable_HDA.Rows.Count; row++)
            {
                // пропускаем "пустую" последнюю строку для ввода
                if (dataGridViewTable_HDA.Rows[row].IsNewRow)
                    continue;

                for (int col = 0; col < dataGridViewTable_HDA.Columns.Count; col++)
                {
                    var cellValue = dataGridViewTable_HDA.Rows[row].Cells[col].Value;
                    string text = cellValue == null ? "" : cellValue.ToString();
                    sb.Append(text);
                    if (col < dataGridViewTable_HDA.Columns.Count - 1)
                        sb.Append(";");
                }
                sb.AppendLine();
            }

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }
        private void buttonFullAnalysis_HDA_Click(object sender, EventArgs e)
        {
            {
                if (names == null || names.Length == 0)
                {
                    MessageBox.Show("Сначала загрузите файл data.csv!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    // Полный анализ через GetAnalysisResult
                    string result = ds.GetAnalysisResult(names, incomes, documents);
                    textBoxResult_HDA.Text = result;

                    MessageBox.Show("Анализ завершен!", "Готово",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка анализа: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void ToolStripMenuItemOpen_HDA_Click(object sender, EventArgs e)
        {
            {
                openFileDialogCsv_HDA.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialogCsv_HDA.Title = "Выберите файл data.csv";

                if (openFileDialogCsv_HDA.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Загружаем данные из CSV
                        string[,] rawData = ds.LoadFromFileData(openFileDialogCsv_HDA.FileName);

                        // Парсим в массивы
                        ds.ParseData(rawData, out names, out incomes, out documents);

                        // Заполняем DataGridView
                        dataGridViewTable_HDA.Rows.Clear();
                        dataGridViewTable_HDA.Columns.Clear();

                        dataGridViewTable_HDA.Columns.Add("ФИО", "ФИО");
                        dataGridViewTable_HDA.Columns.Add("Доход", "Доход");
                        dataGridViewTable_HDA.Columns.Add("Документы", "Документы");

                        for (int i = 0; i < names.Length; i++)
                        {
                            dataGridViewTable_HDA.Rows.Add(names[i], incomes[i], documents[i]);
                        }

                        this.Text = $"Анализ доходов - Загружено {names.Length} граждан";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            buttonbuttonLoadFile_HDA_Click(sender, e);
        }

        private void ToolStripMenuItemExit_HDA_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Выйти из программы?", "Выход",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void buttonSaveCsv_HDA_Click(object sender, EventArgs e)
        {
            {
                saveFileDialogCsv.FileName = "data.csv";
                if (saveFileDialogCsv.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        SaveDataGridViewToCsv(saveFileDialogCsv.FileName);
                        MessageBox.Show("Файл успешно сохранён.", "Сохранение",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка сохранения: " + ex.Message, "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonClearAnalysis_HDA_Click(object sender, EventArgs e)
        {
            {
                // очищаем текст полного анализа
                textBoxResult_HDA.Clear();

                // по желанию: очищаем таблицу
                // dataGridView1.Rows.Clear();
                // dataGridView1.Columns.Clear();

                // сбрасываем массивы данных
                names = null;
                incomes = null;
                documents = null;

                // можно обновить заголовок формы или статусную строку
                this.Text = "Анализ доходов граждан – анализ очищен";
            }
        }
    }
}
