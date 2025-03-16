using System.Data;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace Carbon;

public partial class Gui : Form {
    private string DirectoryPath { get; set; }
    public Gui() {
        DirectoryPath = Directory.GetCurrentDirectory() + "\\DIR";
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
        LoadData(DirectoryPath + "\\" + SelectedTab() + ".csv");
    }
    
    // Other functions
    private string SelectedTab() {
        return mainTabControl.SelectedTab?.Text ?? "ERROR: NO TAB SELECTED";
    }

    private void LoadData(string path) {
        using var reader = new StreamReader(path);
        
        var config = new CsvConfiguration(CultureInfo.InvariantCulture) {
            HasHeaderRecord = true
        };
        
        using var csv = new CsvReader(reader, config);

        var table = new DataTable();
        // Adding the headers to the datatable
        csv.Read();
        csv.ReadHeader();
        foreach(var header in csv?.HeaderRecord ?? new string[] {"ERROR: NO HEADER FOUND"}) {
            table.Columns.Add(header);
        }

        // Adding the data to the datatable
        foreach(var item in csv?.GetRecords<InventoryItem>() ?? Array.Empty<InventoryItem>()) {
            table.Rows.Add(item.name, item.buyPrice, item.buyDate, item.location);
        }
        
        inventoryDataGridView.DataSource = table;
    }

    private void NewAddWindow() {
        if(SelectedTab() == "Inventory") {
            var addWindow = new AddWindow();
            addWindow.Text = "Add Inventory Item";
            addWindow.Show();
        }
    }
}