namespace Carbon;

partial class Gui {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        mainTabControl = new System.Windows.Forms.TabControl();
        inventoryTabPage = new System.Windows.Forms.TabPage();
        inventoryDataGridView = new System.Windows.Forms.DataGridView();
        inventorySearchTextBox = new System.Windows.Forms.TextBox();
        listingsTabPage = new System.Windows.Forms.TabPage();
        listingsSearchTextBox = new System.Windows.Forms.TextBox();
        listingsDataGridView = new System.Windows.Forms.DataGridView();
        ordersTabPage = new System.Windows.Forms.TabPage();
        ordersSearchTextBox = new System.Windows.Forms.TextBox();
        ordersDataGridView = new System.Windows.Forms.DataGridView();
        archivesTabPage = new System.Windows.Forms.TabPage();
        archivesSearchTextBox = new System.Windows.Forms.TextBox();
        archivesDataGridView = new System.Windows.Forms.DataGridView();
        addButton = new System.Windows.Forms.Button();
        directoryButton = new System.Windows.Forms.Button();
        deleteButton = new System.Windows.Forms.Button();
        saveButton = new System.Windows.Forms.Button();
        saveAllButton = new System.Windows.Forms.Button();
        mainTabControl.SuspendLayout();
        inventoryTabPage.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)inventoryDataGridView).BeginInit();
        listingsTabPage.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)listingsDataGridView).BeginInit();
        ordersTabPage.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)ordersDataGridView).BeginInit();
        archivesTabPage.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)archivesDataGridView).BeginInit();
        SuspendLayout();
        // 
        // mainTabControl
        // 
        mainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        mainTabControl.Controls.Add(inventoryTabPage);
        mainTabControl.Controls.Add(listingsTabPage);
        mainTabControl.Controls.Add(ordersTabPage);
        mainTabControl.Controls.Add(archivesTabPage);
        mainTabControl.Location = new System.Drawing.Point(12, 12);
        mainTabControl.Name = "mainTabControl";
        mainTabControl.SelectedIndex = 0;
        mainTabControl.Size = new System.Drawing.Size(734, 477);
        mainTabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
        mainTabControl.TabIndex = 0;
        mainTabControl.SelectedIndexChanged += tabSwitch;
        // 
        // inventoryTabPage
        // 
        inventoryTabPage.Controls.Add(inventoryDataGridView);
        inventoryTabPage.Controls.Add(inventorySearchTextBox);
        inventoryTabPage.Location = new System.Drawing.Point(4, 24);
        inventoryTabPage.Name = "inventoryTabPage";
        inventoryTabPage.Padding = new System.Windows.Forms.Padding(3);
        inventoryTabPage.Size = new System.Drawing.Size(726, 449);
        inventoryTabPage.TabIndex = 0;
        inventoryTabPage.Text = "Inventory";
        inventoryTabPage.UseVisualStyleBackColor = true;
        // 
        // inventoryDataGridView
        // 
        inventoryDataGridView.AllowUserToAddRows = false;
        inventoryDataGridView.AllowUserToDeleteRows = false;
        inventoryDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        inventoryDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        inventoryDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
        inventoryDataGridView.ColumnHeadersHeight = 46;
        inventoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        inventoryDataGridView.Location = new System.Drawing.Point(0, 0);
        inventoryDataGridView.Name = "inventoryDataGridView";
        inventoryDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
        inventoryDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        inventoryDataGridView.Size = new System.Drawing.Size(723, 420);
        inventoryDataGridView.TabIndex = 1;
        // 
        // inventorySearchTextBox
        // 
        inventorySearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        inventorySearchTextBox.Location = new System.Drawing.Point(0, 426);
        inventorySearchTextBox.Name = "inventorySearchTextBox";
        inventorySearchTextBox.Size = new System.Drawing.Size(723, 23);
        inventorySearchTextBox.TabIndex = 2;
        inventorySearchTextBox.TextChanged += searchTextBox_TextChanged;
        // 
        // listingsTabPage
        // 
        listingsTabPage.Controls.Add(listingsSearchTextBox);
        listingsTabPage.Controls.Add(listingsDataGridView);
        listingsTabPage.Location = new System.Drawing.Point(4, 24);
        listingsTabPage.Name = "listingsTabPage";
        listingsTabPage.Padding = new System.Windows.Forms.Padding(3);
        listingsTabPage.Size = new System.Drawing.Size(726, 449);
        listingsTabPage.TabIndex = 1;
        listingsTabPage.Text = "Listings";
        listingsTabPage.UseVisualStyleBackColor = true;
        // 
        // listingsSearchTextBox
        // 
        listingsSearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        listingsSearchTextBox.Location = new System.Drawing.Point(0, 426);
        listingsSearchTextBox.Name = "listingsSearchTextBox";
        listingsSearchTextBox.Size = new System.Drawing.Size(723, 23);
        listingsSearchTextBox.TabIndex = 2;
        // 
        // listingsDataGridView
        // 
        listingsDataGridView.AllowUserToAddRows = false;
        listingsDataGridView.AllowUserToDeleteRows = false;
        listingsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        listingsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        listingsDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
        listingsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        listingsDataGridView.Location = new System.Drawing.Point(0, 0);
        listingsDataGridView.Name = "listingsDataGridView";
        listingsDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
        listingsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        listingsDataGridView.Size = new System.Drawing.Size(723, 420);
        listingsDataGridView.TabIndex = 1;
        // 
        // ordersTabPage
        // 
        ordersTabPage.Controls.Add(ordersSearchTextBox);
        ordersTabPage.Controls.Add(ordersDataGridView);
        ordersTabPage.Location = new System.Drawing.Point(4, 24);
        ordersTabPage.Name = "ordersTabPage";
        ordersTabPage.Padding = new System.Windows.Forms.Padding(3);
        ordersTabPage.Size = new System.Drawing.Size(726, 449);
        ordersTabPage.TabIndex = 2;
        ordersTabPage.Text = "Orders";
        ordersTabPage.UseVisualStyleBackColor = true;
        // 
        // ordersSearchTextBox
        // 
        ordersSearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        ordersSearchTextBox.Location = new System.Drawing.Point(0, 426);
        ordersSearchTextBox.Name = "ordersSearchTextBox";
        ordersSearchTextBox.Size = new System.Drawing.Size(723, 23);
        ordersSearchTextBox.TabIndex = 2;
        // 
        // ordersDataGridView
        // 
        ordersDataGridView.AllowUserToAddRows = false;
        ordersDataGridView.AllowUserToDeleteRows = false;
        ordersDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        ordersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
        ordersDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
        ordersDataGridView.ColumnHeadersHeight = 46;
        ordersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        ordersDataGridView.Location = new System.Drawing.Point(0, 0);
        ordersDataGridView.Name = "ordersDataGridView";
        ordersDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
        ordersDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        ordersDataGridView.Size = new System.Drawing.Size(723, 420);
        ordersDataGridView.TabIndex = 1;
        // 
        // archivesTabPage
        // 
        archivesTabPage.Controls.Add(archivesSearchTextBox);
        archivesTabPage.Controls.Add(archivesDataGridView);
        archivesTabPage.Location = new System.Drawing.Point(4, 24);
        archivesTabPage.Name = "archivesTabPage";
        archivesTabPage.Padding = new System.Windows.Forms.Padding(3);
        archivesTabPage.Size = new System.Drawing.Size(726, 449);
        archivesTabPage.TabIndex = 3;
        archivesTabPage.Text = "Archives";
        archivesTabPage.UseVisualStyleBackColor = true;
        // 
        // archivesSearchTextBox
        // 
        archivesSearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        archivesSearchTextBox.Location = new System.Drawing.Point(0, 426);
        archivesSearchTextBox.Name = "archivesSearchTextBox";
        archivesSearchTextBox.Size = new System.Drawing.Size(723, 23);
        archivesSearchTextBox.TabIndex = 2;
        // 
        // archivesDataGridView
        // 
        archivesDataGridView.AllowUserToAddRows = false;
        archivesDataGridView.AllowUserToDeleteRows = false;
        archivesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        archivesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        archivesDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
        archivesDataGridView.ColumnHeadersHeight = 46;
        archivesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        archivesDataGridView.Location = new System.Drawing.Point(0, 0);
        archivesDataGridView.Name = "archivesDataGridView";
        archivesDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
        archivesDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        archivesDataGridView.Size = new System.Drawing.Size(723, 420);
        archivesDataGridView.TabIndex = 1;
        // 
        // addButton
        // 
        addButton.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        addButton.Location = new System.Drawing.Point(752, 36);
        addButton.Name = "addButton";
        addButton.Size = new System.Drawing.Size(180, 38);
        addButton.TabIndex = 4;
        addButton.Text = "Add/Edit";
        addButton.UseVisualStyleBackColor = true;
        addButton.Click += addButton_Click;
        // 
        // directoryButton
        // 
        directoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        directoryButton.Location = new System.Drawing.Point(752, 5);
        directoryButton.Name = "directoryButton";
        directoryButton.Size = new System.Drawing.Size(180, 25);
        directoryButton.TabIndex = 3;
        directoryButton.Text = "Choose Directory";
        directoryButton.UseVisualStyleBackColor = true;
        directoryButton.Click += directoryButton_Click;
        // 
        // deleteButton
        // 
        deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        deleteButton.Location = new System.Drawing.Point(752, 80);
        deleteButton.Name = "deleteButton";
        deleteButton.Size = new System.Drawing.Size(180, 38);
        deleteButton.TabIndex = 6;
        deleteButton.Text = "Delete";
        deleteButton.UseVisualStyleBackColor = true;
        // 
        // saveButton
        // 
        saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
        saveButton.Location = new System.Drawing.Point(752, 451);
        saveButton.Name = "saveButton";
        saveButton.Size = new System.Drawing.Size(131, 38);
        saveButton.TabIndex = 7;
        saveButton.Text = "Save";
        saveButton.UseVisualStyleBackColor = true;
        saveButton.Click += saveButton_Click;
        // 
        // saveAllButton
        // 
        saveAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
        saveAllButton.Location = new System.Drawing.Point(889, 451);
        saveAllButton.Name = "saveAllButton";
        saveAllButton.Size = new System.Drawing.Size(43, 38);
        saveAllButton.TabIndex = 8;
        saveAllButton.Text = "All";
        saveAllButton.UseVisualStyleBackColor = true;
        saveAllButton.Click += saveAllButton_Click;
        // 
        // Gui
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(944, 501);
        Controls.Add(saveAllButton);
        Controls.Add(saveButton);
        Controls.Add(directoryButton);
        Controls.Add(deleteButton);
        Controls.Add(addButton);
        Controls.Add(mainTabControl);
        Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
        Text = "Carbon";
        mainTabControl.ResumeLayout(false);
        inventoryTabPage.ResumeLayout(false);
        inventoryTabPage.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)inventoryDataGridView).EndInit();
        listingsTabPage.ResumeLayout(false);
        listingsTabPage.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)listingsDataGridView).EndInit();
        ordersTabPage.ResumeLayout(false);
        ordersTabPage.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)ordersDataGridView).EndInit();
        archivesTabPage.ResumeLayout(false);
        archivesTabPage.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)archivesDataGridView).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.TextBox archivesSearchTextBox;

    private System.Windows.Forms.TextBox listingsSearchTextBox;
    private System.Windows.Forms.TextBox ordersSearchTextBox;

    private System.Windows.Forms.Button saveAllButton;

    private System.Windows.Forms.DataGridView listingsDataGridView;
    private System.Windows.Forms.DataGridView ordersDataGridView;
    private System.Windows.Forms.DataGridView archivesDataGridView;

    private System.Windows.Forms.Button saveButton;

    private System.Windows.Forms.Button deleteButton;

    private System.Windows.Forms.DataGridView inventoryDataGridView;

    private System.Windows.Forms.Button directoryButton;

    private System.Windows.Forms.TextBox inventorySearchTextBox;

    private System.Windows.Forms.Button addButton;

    private System.Windows.Forms.TabControl mainTabControl;
    private System.Windows.Forms.TabPage inventoryTabPage;
    private System.Windows.Forms.TabPage listingsTabPage;
    private System.Windows.Forms.TabPage ordersTabPage;
    private System.Windows.Forms.TabPage archivesTabPage;

    #endregion
}