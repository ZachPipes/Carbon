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
        listingsTabPage = new System.Windows.Forms.TabPage();
        ordersTabPage = new System.Windows.Forms.TabPage();
        archivesTabPage = new System.Windows.Forms.TabPage();
        addButton = new System.Windows.Forms.Button();
        searchTextBox = new System.Windows.Forms.TextBox();
        directoryButton = new System.Windows.Forms.Button();
        deleteButton = new System.Windows.Forms.Button();
        listingsDataGridView = new System.Windows.Forms.DataGridView();
        ordersDataGridView = new System.Windows.Forms.DataGridView();
        archivesDataGridView = new System.Windows.Forms.DataGridView();
        mainTabControl.SuspendLayout();
        inventoryTabPage.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)inventoryDataGridView).BeginInit();
        listingsTabPage.SuspendLayout();
        ordersTabPage.SuspendLayout();
        archivesTabPage.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)listingsDataGridView).BeginInit();
        ((System.ComponentModel.ISupportInitialize)ordersDataGridView).BeginInit();
        ((System.ComponentModel.ISupportInitialize)archivesDataGridView).BeginInit();
        SuspendLayout();
        // 
        // mainTabControl
        // 
        mainTabControl.Controls.Add(inventoryTabPage);
        mainTabControl.Controls.Add(listingsTabPage);
        mainTabControl.Controls.Add(ordersTabPage);
        mainTabControl.Controls.Add(archivesTabPage);
        mainTabControl.Location = new System.Drawing.Point(12, 12);
        mainTabControl.Name = "mainTabControl";
        mainTabControl.SelectedIndex = 0;
        mainTabControl.Size = new System.Drawing.Size(1565, 940);
        mainTabControl.TabIndex = 0;
        // 
        // inventoryTabPage
        // 
        inventoryTabPage.Controls.Add(inventoryDataGridView);
        inventoryTabPage.Location = new System.Drawing.Point(8, 46);
        inventoryTabPage.Name = "inventoryTabPage";
        inventoryTabPage.Padding = new System.Windows.Forms.Padding(3);
        inventoryTabPage.Size = new System.Drawing.Size(1549, 886);
        inventoryTabPage.TabIndex = 0;
        inventoryTabPage.Text = "Inventory";
        inventoryTabPage.UseVisualStyleBackColor = true;
        // 
        // inventoryDataGridView
        // 
        inventoryDataGridView.AllowUserToAddRows = false;
        inventoryDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        inventoryDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
        inventoryDataGridView.ColumnHeadersHeight = 46;
        inventoryDataGridView.Location = new System.Drawing.Point(6, 6);
        inventoryDataGridView.Name = "inventoryDataGridView";
        inventoryDataGridView.RowHeadersVisible = false;
        inventoryDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        inventoryDataGridView.Size = new System.Drawing.Size(1537, 877);
        inventoryDataGridView.TabIndex = 0;
        // 
        // listingsTabPage
        // 
        listingsTabPage.Controls.Add(listingsDataGridView);
        listingsTabPage.Location = new System.Drawing.Point(8, 46);
        listingsTabPage.Name = "listingsTabPage";
        listingsTabPage.Padding = new System.Windows.Forms.Padding(3);
        listingsTabPage.Size = new System.Drawing.Size(1549, 886);
        listingsTabPage.TabIndex = 1;
        listingsTabPage.Text = "Listings";
        listingsTabPage.UseVisualStyleBackColor = true;
        // 
        // ordersTabPage
        // 
        ordersTabPage.Controls.Add(ordersDataGridView);
        ordersTabPage.Location = new System.Drawing.Point(8, 46);
        ordersTabPage.Name = "ordersTabPage";
        ordersTabPage.Padding = new System.Windows.Forms.Padding(3);
        ordersTabPage.Size = new System.Drawing.Size(1549, 886);
        ordersTabPage.TabIndex = 2;
        ordersTabPage.Text = "Orders";
        ordersTabPage.UseVisualStyleBackColor = true;
        // 
        // archivesTabPage
        // 
        archivesTabPage.Controls.Add(archivesDataGridView);
        archivesTabPage.Location = new System.Drawing.Point(8, 46);
        archivesTabPage.Name = "archivesTabPage";
        archivesTabPage.Padding = new System.Windows.Forms.Padding(3);
        archivesTabPage.Size = new System.Drawing.Size(1549, 886);
        archivesTabPage.TabIndex = 3;
        archivesTabPage.Text = "Archives";
        archivesTabPage.UseVisualStyleBackColor = true;
        // 
        // addButton
        // 
        addButton.Location = new System.Drawing.Point(1575, 58);
        addButton.Name = "addButton";
        addButton.Size = new System.Drawing.Size(307, 77);
        addButton.TabIndex = 1;
        addButton.Text = "Add/Edit";
        addButton.UseVisualStyleBackColor = true;
        addButton.Click += addButton_Click;
        // 
        // searchTextBox
        // 
        searchTextBox.Location = new System.Drawing.Point(12, 958);
        searchTextBox.Name = "searchTextBox";
        searchTextBox.Size = new System.Drawing.Size(1557, 39);
        searchTextBox.TabIndex = 2;
        searchTextBox.TextChanged += searchTextBox_TextChanged;
        // 
        // directoryButton
        // 
        directoryButton.Location = new System.Drawing.Point(1575, 12);
        directoryButton.Name = "directoryButton";
        directoryButton.Size = new System.Drawing.Size(307, 40);
        directoryButton.TabIndex = 4;
        directoryButton.Text = "Choose Directory";
        directoryButton.UseVisualStyleBackColor = true;
        directoryButton.Click += directoryButton_Click;
        // 
        // deleteButton
        // 
        deleteButton.Location = new System.Drawing.Point(1575, 141);
        deleteButton.Name = "deleteButton";
        deleteButton.Size = new System.Drawing.Size(307, 77);
        deleteButton.TabIndex = 5;
        deleteButton.Text = "Delete";
        deleteButton.UseVisualStyleBackColor = true;
        // 
        // listingsDataGridView
        // 
        listingsDataGridView.AllowUserToAddRows = false;
        listingsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        listingsDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
        listingsDataGridView.ColumnHeadersHeight = 46;
        listingsDataGridView.Location = new System.Drawing.Point(6, 5);
        listingsDataGridView.Name = "listingsDataGridView";
        listingsDataGridView.RowHeadersVisible = false;
        listingsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        listingsDataGridView.Size = new System.Drawing.Size(1537, 877);
        listingsDataGridView.TabIndex = 1;
        // 
        // ordersDataGridView
        // 
        ordersDataGridView.AllowUserToAddRows = false;
        ordersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        ordersDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
        ordersDataGridView.ColumnHeadersHeight = 46;
        ordersDataGridView.Location = new System.Drawing.Point(6, 5);
        ordersDataGridView.Name = "ordersDataGridView";
        ordersDataGridView.RowHeadersVisible = false;
        ordersDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        ordersDataGridView.Size = new System.Drawing.Size(1537, 877);
        ordersDataGridView.TabIndex = 1;
        // 
        // archivesDataGridView
        // 
        archivesDataGridView.AllowUserToAddRows = false;
        archivesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        archivesDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
        archivesDataGridView.ColumnHeadersHeight = 46;
        archivesDataGridView.Location = new System.Drawing.Point(6, 5);
        archivesDataGridView.Name = "archivesDataGridView";
        archivesDataGridView.RowHeadersVisible = false;
        archivesDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        archivesDataGridView.Size = new System.Drawing.Size(1537, 877);
        archivesDataGridView.TabIndex = 1;
        // 
        // Gui
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1894, 1009);
        Controls.Add(deleteButton);
        Controls.Add(directoryButton);
        Controls.Add(searchTextBox);
        Controls.Add(addButton);
        Controls.Add(mainTabControl);
        Text = "Carbon";
        mainTabControl.ResumeLayout(false);
        inventoryTabPage.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)inventoryDataGridView).EndInit();
        listingsTabPage.ResumeLayout(false);
        ordersTabPage.ResumeLayout(false);
        archivesTabPage.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)listingsDataGridView).EndInit();
        ((System.ComponentModel.ISupportInitialize)ordersDataGridView).EndInit();
        ((System.ComponentModel.ISupportInitialize)archivesDataGridView).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.DataGridView listingsDataGridView;
    private System.Windows.Forms.DataGridView ordersDataGridView;
    private System.Windows.Forms.DataGridView archivesDataGridView;

    private System.Windows.Forms.Button deleteButton;

    private System.Windows.Forms.DataGridView inventoryDataGridView;

    private System.Windows.Forms.Button directoryButton;

    private System.Windows.Forms.TextBox searchTextBox;

    private System.Windows.Forms.Button addButton;

    private System.Windows.Forms.TabControl mainTabControl;
    private System.Windows.Forms.TabPage inventoryTabPage;
    private System.Windows.Forms.TabPage listingsTabPage;
    private System.Windows.Forms.TabPage ordersTabPage;
    private System.Windows.Forms.TabPage archivesTabPage;

    #endregion
}