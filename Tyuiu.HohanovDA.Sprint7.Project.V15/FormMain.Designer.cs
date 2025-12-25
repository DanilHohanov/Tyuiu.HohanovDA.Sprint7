namespace Tyuiu.HohanovDA.Sprint7.Project.V15
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonbuttonLoadFile_HDA = new Button();
            buttonFullAnalysis_HDA = new Button();
            dataGridViewTable_HDA = new DataGridView();
            textBoxResult_HDA = new TextBox();
            menuStripFile_HDA = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItemOpen_HDA = new ToolStripMenuItem();
            ToolStripMenuItemExit_HDA = new ToolStripMenuItem();
            openFileDialogCsv_HDA = new OpenFileDialog();
            saveFileDialogCsv = new SaveFileDialog();
            buttonSaveCsv_HDA = new Button();
            buttonClearAnalysis_HDA = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTable_HDA).BeginInit();
            menuStripFile_HDA.SuspendLayout();
            SuspendLayout();
            // 
            // buttonbuttonLoadFile_HDA
            // 
            buttonbuttonLoadFile_HDA.Location = new Point(274, 11);
            buttonbuttonLoadFile_HDA.Name = "buttonbuttonLoadFile_HDA";
            buttonbuttonLoadFile_HDA.Size = new Size(160, 67);
            buttonbuttonLoadFile_HDA.TabIndex = 0;
            buttonbuttonLoadFile_HDA.Text = "Загрузить data.csv";
            buttonbuttonLoadFile_HDA.UseVisualStyleBackColor = true;
            buttonbuttonLoadFile_HDA.Click += buttonbuttonLoadFile_HDA_Click;
            // 
            // buttonFullAnalysis_HDA
            // 
            buttonFullAnalysis_HDA.Location = new Point(430, 365);
            buttonFullAnalysis_HDA.Name = "buttonFullAnalysis_HDA";
            buttonFullAnalysis_HDA.Size = new Size(160, 47);
            buttonFullAnalysis_HDA.TabIndex = 1;
            buttonFullAnalysis_HDA.Text = "Полный анализ";
            buttonFullAnalysis_HDA.UseVisualStyleBackColor = true;
            buttonFullAnalysis_HDA.Click += buttonFullAnalysis_HDA_Click;
            // 
            // dataGridViewTable_HDA
            // 
            dataGridViewTable_HDA.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTable_HDA.Location = new Point(12, 85);
            dataGridViewTable_HDA.Name = "dataGridViewTable_HDA";
            dataGridViewTable_HDA.RowHeadersWidth = 62;
            dataGridViewTable_HDA.Size = new Size(776, 194);
            dataGridViewTable_HDA.TabIndex = 2;
            // 
            // textBoxResult_HDA
            // 
            textBoxResult_HDA.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxResult_HDA.Location = new Point(12, 285);
            textBoxResult_HDA.Multiline = true;
            textBoxResult_HDA.Name = "textBoxResult_HDA";
            textBoxResult_HDA.ReadOnly = true;
            textBoxResult_HDA.ScrollBars = ScrollBars.Vertical;
            textBoxResult_HDA.Size = new Size(367, 283);
            textBoxResult_HDA.TabIndex = 3;
            // 
            // menuStripFile_HDA
            // 
            menuStripFile_HDA.ImageScalingSize = new Size(24, 24);
            menuStripFile_HDA.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem });
            menuStripFile_HDA.Location = new Point(0, 0);
            menuStripFile_HDA.Name = "menuStripFile_HDA";
            menuStripFile_HDA.Size = new Size(800, 33);
            menuStripFile_HDA.TabIndex = 4;
            menuStripFile_HDA.Text = "Файл";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemOpen_HDA, ToolStripMenuItemExit_HDA });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(69, 29);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // ToolStripMenuItemOpen_HDA
            // 
            ToolStripMenuItemOpen_HDA.Name = "ToolStripMenuItemOpen_HDA";
            ToolStripMenuItemOpen_HDA.Size = new Size(259, 34);
            ToolStripMenuItemOpen_HDA.Text = "Открыть csv файл";
            ToolStripMenuItemOpen_HDA.Click += ToolStripMenuItemOpen_HDA_Click;
            // 
            // ToolStripMenuItemExit_HDA
            // 
            ToolStripMenuItemExit_HDA.Name = "ToolStripMenuItemExit_HDA";
            ToolStripMenuItemExit_HDA.Size = new Size(259, 34);
            ToolStripMenuItemExit_HDA.Text = "Выход";
            ToolStripMenuItemExit_HDA.Click += ToolStripMenuItemExit_HDA_Click;
            // 
            // openFileDialogCsv_HDA
            // 
            openFileDialogCsv_HDA.FileName = "openFileDialog1";
            openFileDialogCsv_HDA.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            // 
            // saveFileDialogCsv
            // 
            saveFileDialogCsv.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialogCsv.Title = "Сохранить файл csv";
            // 
            // buttonSaveCsv_HDA
            // 
            buttonSaveCsv_HDA.Location = new Point(89, 12);
            buttonSaveCsv_HDA.Name = "buttonSaveCsv_HDA";
            buttonSaveCsv_HDA.Size = new Size(168, 66);
            buttonSaveCsv_HDA.TabIndex = 5;
            buttonSaveCsv_HDA.Text = "Сохранить data.csv";
            buttonSaveCsv_HDA.UseVisualStyleBackColor = true;
            buttonSaveCsv_HDA.Click += buttonSaveCsv_HDA_Click;
            // 
            // buttonClearAnalysis_HDA
            // 
            buttonClearAnalysis_HDA.Location = new Point(443, 474);
            buttonClearAnalysis_HDA.Name = "buttonClearAnalysis_HDA";
            buttonClearAnalysis_HDA.Size = new Size(147, 64);
            buttonClearAnalysis_HDA.TabIndex = 6;
            buttonClearAnalysis_HDA.Text = "Очистить анализ";
            buttonClearAnalysis_HDA.UseVisualStyleBackColor = true;
            buttonClearAnalysis_HDA.Click += buttonClearAnalysis_HDA_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 580);
            Controls.Add(buttonClearAnalysis_HDA);
            Controls.Add(buttonSaveCsv_HDA);
            Controls.Add(textBoxResult_HDA);
            Controls.Add(dataGridViewTable_HDA);
            Controls.Add(buttonFullAnalysis_HDA);
            Controls.Add(buttonbuttonLoadFile_HDA);
            Controls.Add(menuStripFile_HDA);
            MainMenuStrip = menuStripFile_HDA;
            Name = "FormMain";
            Text = "FormMain";
            Load += FormMain_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTable_HDA).EndInit();
            menuStripFile_HDA.ResumeLayout(false);
            menuStripFile_HDA.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonbuttonLoadFile_HDA;
        private Button buttonFullAnalysis_HDA;
        private DataGridView dataGridViewTable_HDA;
        private TextBox textBoxResult_HDA;
        private MenuStrip menuStripFile_HDA;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem ToolStripMenuItemOpen_HDA;
        private ToolStripMenuItem ToolStripMenuItemExit_HDA;
        private OpenFileDialog openFileDialogCsv_HDA;
        private SaveFileDialog saveFileDialogCsv;
        private Button buttonSaveCsv_HDA;
        private Button buttonClearAnalysis_HDA;
    }
}
