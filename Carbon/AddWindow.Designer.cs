using System.ComponentModel;

namespace Carbon;

partial class AddWindow {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if(disposing && (components != null)) {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        addWindowDataGridView = new System.Windows.Forms.DataGridView();
        addWindowSearchTextBox = new System.Windows.Forms.TextBox();
        ((System.ComponentModel.ISupportInitialize)addWindowDataGridView).BeginInit();
        SuspendLayout();
        // 
        // addWindowDataGridView
        // 
        addWindowDataGridView.ColumnHeadersHeight = 46;
        addWindowDataGridView.Location = new System.Drawing.Point(12, 12);
        addWindowDataGridView.Name = "addWindowDataGridView";
        addWindowDataGridView.RowHeadersWidth = 82;
        addWindowDataGridView.Size = new System.Drawing.Size(1362, 827);
        addWindowDataGridView.TabIndex = 0;
        // 
        // addWindowSearchTextBox
        // 
        addWindowSearchTextBox.Location = new System.Drawing.Point(12, 860);
        addWindowSearchTextBox.Name = "addWindowSearchTextBox";
        addWindowSearchTextBox.Size = new System.Drawing.Size(1362, 39);
        addWindowSearchTextBox.TabIndex = 1;
        // 
        // AddWindow
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1612, 911);
        Controls.Add(addWindowSearchTextBox);
        Controls.Add(addWindowDataGridView);
        Text = "AddWindow";
        ((System.ComponentModel.ISupportInitialize)addWindowDataGridView).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TextBox addWindowSearchTextBox;

    private System.Windows.Forms.DataGridView addWindowDataGridView;

    #endregion
}