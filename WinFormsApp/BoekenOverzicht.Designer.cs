namespace WinFormsApp;

partial class BoekenOverzicht
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        boekenTabel = new DataGridView();
        iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        titelDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        schrijverDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        boekListItemBindingSource = new BindingSource(components);
        menu = new MenuStrip();
        exportToolStripMenuItem = new ToolStripMenuItem();
        ((System.ComponentModel.ISupportInitialize)boekenTabel).BeginInit();
        ((System.ComponentModel.ISupportInitialize)boekListItemBindingSource).BeginInit();
        menu.SuspendLayout();
        SuspendLayout();
        // 
        // boekenTabel
        // 
        boekenTabel.AllowUserToAddRows = false;
        boekenTabel.AllowUserToDeleteRows = false;
        boekenTabel.AllowUserToOrderColumns = true;
        boekenTabel.AutoGenerateColumns = false;
        boekenTabel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        boekenTabel.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        boekenTabel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        boekenTabel.Columns.AddRange(new DataGridViewColumn[] { iDDataGridViewTextBoxColumn, titelDataGridViewTextBoxColumn, schrijverDataGridViewTextBoxColumn });
        boekenTabel.DataSource = boekListItemBindingSource;
        boekenTabel.Location = new Point(-1, 27);
        boekenTabel.Name = "boekenTabel";
        boekenTabel.Size = new Size(800, 266);
        boekenTabel.TabIndex = 0;
        // 
        // iDDataGridViewTextBoxColumn
        // 
        iDDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
        iDDataGridViewTextBoxColumn.HeaderText = "ID";
        iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
        iDDataGridViewTextBoxColumn.Width = 43;
        // 
        // titelDataGridViewTextBoxColumn
        // 
        titelDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        titelDataGridViewTextBoxColumn.DataPropertyName = "Titel";
        titelDataGridViewTextBoxColumn.HeaderText = "Titel";
        titelDataGridViewTextBoxColumn.Name = "titelDataGridViewTextBoxColumn";
        // 
        // schrijverDataGridViewTextBoxColumn
        // 
        schrijverDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        schrijverDataGridViewTextBoxColumn.DataPropertyName = "Schrijver";
        schrijverDataGridViewTextBoxColumn.HeaderText = "Schrijver";
        schrijverDataGridViewTextBoxColumn.Name = "schrijverDataGridViewTextBoxColumn";
        // 
        // boekListItemBindingSource
        // 
        boekListItemBindingSource.DataSource = typeof(BoekenAPI2025.Shared.DTO.Boeken.BoekListItem);
        // 
        // menu
        // 
        menu.Items.AddRange(new ToolStripItem[] { exportToolStripMenuItem });
        menu.Location = new Point(0, 0);
        menu.Name = "menu";
        menu.Size = new Size(800, 24);
        menu.TabIndex = 1;
        menu.Text = "menuStrip1";
        // 
        // exportToolStripMenuItem
        // 
        exportToolStripMenuItem.Click += ExportToolStripMenuItem_Click;
        exportToolStripMenuItem.Name = "exportToolStripMenuItem";
        exportToolStripMenuItem.Size = new Size(52, 20);
        exportToolStripMenuItem.Text = "Export";
        // 
        // BoekenOverzicht
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(boekenTabel);
        Controls.Add(menu);
        MainMenuStrip = menu;
        Name = "BoekenOverzicht";
        Text = "BoekenOverzicht";
        ((System.ComponentModel.ISupportInitialize)boekenTabel).EndInit();
        ((System.ComponentModel.ISupportInitialize)boekListItemBindingSource).EndInit();
        menu.ResumeLayout(false);
        menu.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private DataGridView boekenTabel;
    private BindingSource boekListItemBindingSource;
    private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn titelDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn schrijverDataGridViewTextBoxColumn;
    private MenuStrip menu;
    private ToolStripMenuItem exportToolStripMenuItem;
}