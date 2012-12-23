namespace ReverseDictionary.DictionaryControls
{
    partial class DictionaryView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._saveButton = new System.Windows.Forms.ToolStripButton();
            this._saveAsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._makeButton = new System.Windows.Forms.ToolStripButton();
            this._langComboBox = new System.Windows.Forms.ToolStripComboBox();
            this._gridView = new System.Windows.Forms.DataGridView();
            this._saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.wordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._saveButton,
            this._saveAsButton,
            this.toolStripSeparator1,
            this._makeButton,
            this._langComboBox});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(286, 25);
            this._toolStrip.TabIndex = 0;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _saveButton
            // 
            this._saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._saveButton.Image = global::ReverseDictionary.Properties.Resources.filesave;
            this._saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(23, 24);
            this._saveButton.Text = "Save";
            this._saveButton.Click += new System.EventHandler(this.SaveClick);
            // 
            // _saveAsButton
            // 
            this._saveAsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._saveAsButton.Image = global::ReverseDictionary.Properties.Resources.filesaveas;
            this._saveAsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._saveAsButton.Name = "_saveAsButton";
            this._saveAsButton.Size = new System.Drawing.Size(23, 24);
            this._saveAsButton.Text = "Save As";
            this._saveAsButton.Click += new System.EventHandler(this.SaveAsClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // _makeButton
            // 
            this._makeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._makeButton.Image = global::ReverseDictionary.Properties.Resources.fonts;
            this._makeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._makeButton.Name = "_makeButton";
            this._makeButton.Size = new System.Drawing.Size(23, 24);
            this._makeButton.Text = "Make Dictionary";
            this._makeButton.Click += new System.EventHandler(this.MakeButtonClick);
            // 
            // _langComboBox
            // 
            this._langComboBox.Name = "_langComboBox";
            this._langComboBox.Size = new System.Drawing.Size(121, 25);
            this._langComboBox.ToolTipText = "Source text language";
            // 
            // _gridView
            // 
            this._gridView.AutoGenerateColumns = false;
            this._gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.wordDataGridViewTextBoxColumn,
            this.countDataGridViewTextBoxColumn});
            this._gridView.DataSource = this.viewItemBindingSource;
            this._gridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridView.Location = new System.Drawing.Point(0, 25);
            this._gridView.Name = "_gridView";
            this._gridView.Size = new System.Drawing.Size(286, 266);
            this._gridView.TabIndex = 1;
            // 
            // wordDataGridViewTextBoxColumn
            // 
            this.wordDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.wordDataGridViewTextBoxColumn.DataPropertyName = "Word";
            this.wordDataGridViewTextBoxColumn.FillWeight = 200F;
            this.wordDataGridViewTextBoxColumn.HeaderText = "Word";
            this.wordDataGridViewTextBoxColumn.Name = "wordDataGridViewTextBoxColumn";
            // 
            // countDataGridViewTextBoxColumn
            // 
            this.countDataGridViewTextBoxColumn.DataPropertyName = "Count";
            this.countDataGridViewTextBoxColumn.HeaderText = "Count";
            this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
            // 
            // viewItemBindingSource
            // 
            this.viewItemBindingSource.DataSource = typeof(ReverseDictionary.DictionaryControls.ViewItem);
            // 
            // DictionaryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._gridView);
            this.Controls.Add(this._toolStrip);
            this.Name = "DictionaryView";
            this.Size = new System.Drawing.Size(286, 291);
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewItemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.DataGridView _gridView;
        private System.Windows.Forms.BindingSource viewItemBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn wordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton _saveButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton _makeButton;
        private System.Windows.Forms.ToolStripComboBox _langComboBox;
        private System.Windows.Forms.ToolStripButton _saveAsButton;
        private System.Windows.Forms.SaveFileDialog _saveFileDialog;
    }
}
