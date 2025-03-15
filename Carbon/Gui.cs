using System.Data;
using System.Diagnostics;

namespace Carbon;

public partial class Gui : Form {
    public string DirectoryPath { get; set; }
    public Gui() {
        DirectoryPath = Directory.GetCurrentDirectory();
        InitializeComponent();
    }

    private void addButton_Click(object sender, EventArgs e) {
        // Differentiate between which tab user is on
        NewAddWindow();
    }

    private void directoryButton_Click(object sender, EventArgs e) {
        var folderBrowserDialog = new FolderBrowserDialog();
        folderBrowserDialog.SelectedPath = AppDomain.CurrentDomain.BaseDirectory;
        if(folderBrowserDialog.ShowDialog() == DialogResult.OK) {
            DirectoryPath = folderBrowserDialog.SelectedPath;
            switch(SelectedTab()) {
                case "Inventory":
                    
                default:
                    return;
            }
        } // Add else statement
    }

    private void refreshButton_Click(object sender, EventArgs e) {
        // Differentiate between which tab user is on
        LoadData(DirectoryPath + SelectedTab() + ".csv");
        
        //
        
        var table = new DataTable();
        table.Columns.Add("Name");
        table.Columns.Add("Price");
        table.Columns.Add("Buy Date");
        table.Columns.Add("Quantity");

        table.Rows.Add("Watch 420e45798056767", "$4.99", "12/31/2003", "4");
        table.Rows.Add("Watch 69", "$8.99", "02/03/2004", "2");
        
        inventoryDataGridView.DataSource = table;
    }
    
    // Other functions
    private string SelectedTab() {
        return mainTabControl.SelectedTab?.Text ?? "ERROR: NO TAB SELECTED";
    }

    private void LoadData(string path) {
        searchTextBox.Text = path;
        
    }

    private void NewAddWindow() {
        if(SelectedTab() == "Inventory") {
            var addWindow = new AddWindow();
            addWindow.Text = "Add Inventory Item";
            addWindow.Show();
        }
    }
}