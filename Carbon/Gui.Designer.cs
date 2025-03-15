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
        refreshButton = new System.Windows.Forms.Button();
        directoryButton = new System.Windows.Forms.Button();
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
        inventoryDataGridView.AllowUserToDeleteRows = false;
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
        // 
        // refreshButton
        // 
        refreshButton.Location = new System.Drawing.Point(1575, 141);
        refreshButton.Name = "refreshButton";
        refreshButton.Size = new System.Drawing.Size(307, 77);
        refreshButton.TabIndex = 3;
        refreshButton.Text = "Refresh";
        refreshButton.UseVisualStyleBackColor = true;
        refreshButton.Click += refreshButton_Click;
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
        // Gui
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1894, 1009);
        Controls.Add(directoryButton);
        Controls.Add(refreshButton);
        Controls.Add(searchTextBox);
        Controls.Add(addButton);
        Controls.Add(mainTabControl);
        Text = "Carbon";
        mainTabControl.ResumeLayout(false);
        inventoryTabPage.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)inventoryDataGridView).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.DataGridView inventoryDataGridView;

    private System.Windows.Forms.Button refreshButton;
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