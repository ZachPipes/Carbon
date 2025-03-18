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
        searchTextBox = new System.Windows.Forms.TextBox();
        listingsTabPage = new System.Windows.Forms.TabPage();
        ordersTabPage = new System.Windows.Forms.TabPage();
        archivesTabPage = new System.Windows.Forms.TabPage();
        addButton = new System.Windows.Forms.Button();
        directoryButton = new System.Windows.Forms.Button();
        deleteButton = new System.Windows.Forms.Button();
        mainTabControl.SuspendLayout();
        inventoryTabPage.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)inventoryDataGridView).BeginInit();
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
        mainTabControl.Size = new System.Drawing.Size(734, 477);
        mainTabControl.TabIndex = 0;
        // 
        // inventoryTabPage
        // 
        inventoryTabPage.Controls.Add(inventoryDataGridView);
        inventoryTabPage.Controls.Add(searchTextBox);
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
        inventoryDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        inventoryDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
        inventoryDataGridView.ColumnHeadersHeight = 46;
        inventoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        inventoryDataGridView.Location = new System.Drawing.Point(0, 0);
        inventoryDataGridView.Name = "inventoryDataGridView";
        inventoryDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
        inventoryDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        inventoryDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        inventoryDataGridView.Size = new System.Drawing.Size(726, 417);
        inventoryDataGridView.TabIndex = 0;
        // 
        // searchTextBox
        // 
        searchTextBox.Location = new System.Drawing.Point(3, 423);
        searchTextBox.Name = "searchTextBox";
        searchTextBox.Size = new System.Drawing.Size(723, 23);
        searchTextBox.TabIndex = 2;
        searchTextBox.TextChanged += searchTextBox_TextChanged;
        // 
        // listingsTabPage
        // 
        listingsTabPage.Location = new System.Drawing.Point(4, 24);
        listingsTabPage.Name = "listingsTabPage";
        listingsTabPage.Padding = new System.Windows.Forms.Padding(3);
        listingsTabPage.Size = new System.Drawing.Size(726, 449);
        listingsTabPage.TabIndex = 1;
        listingsTabPage.Text = "Listings";
        listingsTabPage.UseVisualStyleBackColor = true;
        // 
        // ordersTabPage
        // 
        ordersTabPage.Location = new System.Drawing.Point(4, 24);
        ordersTabPage.Name = "ordersTabPage";
        ordersTabPage.Padding = new System.Windows.Forms.Padding(3);
        ordersTabPage.Size = new System.Drawing.Size(726, 449);
        ordersTabPage.TabIndex = 2;
        ordersTabPage.Text = "Orders";
        ordersTabPage.UseVisualStyleBackColor = true;
        // 
        // archivesTabPage
        // 
        archivesTabPage.Location = new System.Drawing.Point(4, 24);
        archivesTabPage.Name = "archivesTabPage";
        archivesTabPage.Padding = new System.Windows.Forms.Padding(3);
        archivesTabPage.Size = new System.Drawing.Size(726, 449);
        archivesTabPage.TabIndex = 3;
        archivesTabPage.Text = "Archives";
        archivesTabPage.UseVisualStyleBackColor = true;
        // 
        // addButton
        // 
        addButton.Location = new System.Drawing.Point(752, 36);
        addButton.Name = "addButton";
        addButton.Size = new System.Drawing.Size(180, 38);
        addButton.TabIndex = 1;
        addButton.Text = "Add/Edit";
        addButton.UseVisualStyleBackColor = true;
        addButton.Click += addButton_Click;
        // 
        // directoryButton
        // 
        directoryButton.Location = new System.Drawing.Point(752, 5);
        directoryButton.Name = "directoryButton";
        directoryButton.Size = new System.Drawing.Size(180, 25);
        directoryButton.TabIndex = 4;
        directoryButton.Text = "Choose Directory";
        directoryButton.UseVisualStyleBackColor = true;
        directoryButton.Click += directoryButton_Click;
        // 
        // deleteButton
        // 
        deleteButton.Location = new System.Drawing.Point(752, 80);
        deleteButton.Name = "deleteButton";
        deleteButton.Size = new System.Drawing.Size(180, 38);
        deleteButton.TabIndex = 5;
        deleteButton.Text = "Delete";
        deleteButton.UseVisualStyleBackColor = true;
        // 
        // Gui
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(944, 501);
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
        ResumeLayout(false);
    }

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