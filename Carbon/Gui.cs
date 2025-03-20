using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace Carbon;

public partial class Gui : Form {
    private string DirectoryPath { get; set; }

    public Gui() {
        // REMOVE THIS BEFORE RELEASE
        DirectoryPath = Directory.GetCurrentDirectory() + "\\Data";
        InitializeComponent();

        EnsureRequiredFiles();

        LoadData<InventoryItem>("inventory.csv", inventoryDataGridView);
    }

    // Opens an explorer.exe prompt and allows users to select what folder they want to use as the directory
    private void directoryButton_Click(object sender, EventArgs e) {
        var folderBrowserDialog = new FolderBrowserDialog();
        folderBrowserDialog.SelectedPath = AppDomain.CurrentDomain.BaseDirectory;

        // Opens explorer.exe and lets user select the directory
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
            DirectoryPath = folderBrowserDialog.SelectedPath;
        }
    }

    // Enables adding and editing of current DataGridView
    private void addButton_Click(object sender, EventArgs e) {
        throw new System.NotImplementedException();
    }

    // Saves the data of the currently selected tab
    private void saveButton_Click(object sender, EventArgs e) {
        switch (mainTabControl.SelectedTab?.Text ?? "ERROR: TAB NOT FOUND") {
            case("inventoryTabPage"):
                SaveData<InventoryItem>("inventory.csv", inventoryDataGridView);
                break;
            case("listingsTabPage"):
                SaveData<ListingsItem>("listings.csv", listingsDataGridView);
                break;
            case("ordersTabPage"):
                SaveData<ListingsItem>("orders.csv", ordersDataGridView);
                break;
            case("archivesTabPage"):
                SaveData<ListingsItem>("archives.csv", archivesDataGridView);
                break;
        }
    }
    
    // Saves all data
    private void saveAllButton_Click(object sender, EventArgs e) {
        SaveData<InventoryItem>("inventory.csv", inventoryDataGridView);
        SaveData<ListingsItem>("listings.csv", listingsDataGridView);
        SaveData<ListingsItem>("orders.csv", ordersDataGridView);
        SaveData<ListingsItem>("archives.csv", archivesDataGridView);
    }
    
    // Loads new data on tab switch
    private void tabSwitch(object sender, EventArgs e) {
        switch (mainTabControl.SelectedTab?.Text ?? "ERROR: TAB NOT FOUND") {
            case("Inventory"):
                LoadData<InventoryItem>("inventory.csv", inventoryDataGridView);
                break;
            case("Listings"):
                LoadData<ListingsItem>("listings.csv", listingsDataGridView);
                break;
            case("Orders"):
                LoadData<ListingsItem>("orders.csv", ordersDataGridView);
                break;
            case("Archives"):
                LoadData<ListingsItem>("archives.csv", archivesDataGridView);
                break;
        }
    }
    // Search function
    private void searchTextBox_TextChanged(object sender, EventArgs e) {
        //ObservableCollection<InventoryItem> collection = inventoryDataGridView.;
    }

    
    
    /// Other functions ///
    // Ensures required files are present
    // - (folder) Data
    // - (file) inventory.csv
    // - (file) listings.csv
    // - (file) orders.csv
    // - (file) archives.csv
    private void EnsureRequiredFiles() {
        string[] requiredFiles = ["inventory.csv", "listings.csv", "orders.csv", "archives.csv"];
        if (!Directory.Exists(DirectoryPath)) {
            Directory.CreateDirectory(DirectoryPath);
        }

        var existingFiles = Directory.GetFiles(DirectoryPath, "*.csv");
        var missingFiles = requiredFiles.Except(existingFiles).ToArray();

        if (missingFiles.Length == 0) return;

        foreach (var missingFile in missingFiles) {
            File.Create(DirectoryPath + "\\" + missingFile).Dispose();
            using var writer = new StreamWriter(DirectoryPath + "\\" + missingFile);
            switch (missingFile) {
                case "inventory.csv":
                    writer.WriteLine("name,buyPrice,buyDate,location");
                    writer.WriteLine("Mickey Mouse Car,$3.99,02/13/2025,Hallsville");
                    break;
                case "listings.csv":
                    writer.WriteLine("name,buyPrice,buyDate,location,category,listedDate");
                    writer.WriteLine("Mickey Mouse Car,$3.99,02/13/2025,Hallsville,Toy,02/16/2025");
                    break;
                case "orders.csv":
                    writer.WriteLine("name,buyPrice,buyDate,location,category,listedDate,sellPrice,ebayFees,shippingFees,total,profit,sellDate");
                    writer.WriteLine("Mickey Mouse Car,$3.99,02/13/2025,Hallsville,Toy,02/16/2025,$0.99,$2.99,$10.99,$3.02,03/01/2025");
                    break;
                case "archives.csv":
                    writer.WriteLine("name,buyPrice,buyDate,location,category,listedDate,ebayFees,shippingFees,total,profit,sellDate");
                    writer.WriteLine("Mickey Mouse Car,$3.99,02/13/2025,Hallsville,Toy,02/16/2025,$0.99,$2.99,$10.99,$3.02,03/01/2025");
                    break;
            }
        }
    }

    // Dynamically loads the dataGridViews on each page of the program
    private void LoadData<T>(string fileName, DataGridView dataGridView) {
        using var reader = new StreamReader(DirectoryPath + "\\" + fileName);

        var config = new CsvConfiguration(CultureInfo.InvariantCulture) {
            HasHeaderRecord = true
        };

        using(var csv = new CsvReader(reader, config)) {
            var table = new DataTable();

            // Adding the headers to the table
            csv.Read();
            csv.ReadHeader();
            foreach (var header in csv.HeaderRecord ?? ["ERROR: NO HEADER FOUND"]) {
                table.Columns.Add(header);
            }

            // Adding the data to the datatable
            foreach (var item in csv.GetRecords<T>()) {
                var properties = typeof(T).GetProperties();
                table.Rows.Add(properties.Select(p => p.GetValue(item)).ToArray());
            }

            dataGridView.DataSource = table;
        }
        
        //SaveData<T>(fileName, dataGridView);
    }

    private void SaveData<T>(string fileName, DataGridView dataGridView) { ;
        var records = new List<T>();

        // Assigning data
        dataGridView.DataSource = records;

        using(var writer = new StreamWriter(DirectoryPath + "\\" + fileName)) {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) {
                HasHeaderRecord = true
            };

            using var csv = new CsvWriter(writer, config);
            // Writing the headers
            csv.WriteHeader<T>();
            csv.NextRecord();

            // Writing the data
            csv.WriteRecords(records);
        }
    }
}