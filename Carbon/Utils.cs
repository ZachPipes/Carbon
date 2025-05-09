﻿using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using CsvHelper;
using log4net.Util;

namespace Carbon;

public static class Utils {
    // Displays an error with the 'errorMessage' in a pop-up window
    public static void ShowError(string errorMessage) {
        MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }

    // Loads a csv file from 'fileName' into the 'grid'
    // Will create a directory if one DNE
    public static ObservableCollection<InventoryItem> LoadFile(string fileName, DataGrid grid) {
        // TODO: MAKE THIS COMPATIBLE WITH ANY DIRECTORY NAME
        var filePath = $@"C:\Users\{Environment.UserName}\Documents\Carbon";

        // If directory DNE -> creates directory and returns 
        if (!Directory.Exists(filePath)) {
            Directory.CreateDirectory(filePath);
            return new ObservableCollection<InventoryItem>();
        }

        filePath += $@"\{fileName}.csv";

        if (File.Exists(filePath)) {
            var lines = File.ReadAllLines(filePath);
            var items = new ObservableCollection<InventoryItem>();
            for (int i = 1; i < lines.Length; i++) {
                var line = lines[i];
                var columns = line.Split(',');

                if (columns.Length != 5) ShowError($"Invalid number of columns for {filePath} at row {i}");

                var item = new InventoryItem() {
                    Name = columns[0],
                    Category = columns[1],
                    Paid = double.TryParse(columns[2], out var paid) ? paid : 0,
                    Location = columns[3],
                    Bin = columns[4]
                };
                items.Add(item);
            }

            grid.ItemsSource = items;
            return items;
        }

        File.Create(filePath).Close();
        return new ObservableCollection<InventoryItem>();
    }

    // AI functions that I need to look through
    //
    // public static async Task<string> EbayAuth() {
    //     using JsonDocument jsonDoc = JsonDocument.Parse(File.ReadAllText("FILE.json"));
    //
    //     var clientId = jsonDoc.RootElement.GetProperty("client_id").GetString();
    //     var clientSecret = jsonDoc.RootElement.GetProperty("client_secret").GetString();
    //     var scopes = new[] {
    //         "https://api.ebay.com/oauth/api_scope"
    //     };
    //
    //     var credentials = $"{clientId}:{clientSecret}";
    //     var encodedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));
    //
    //     using var client = new HttpClient();
    //     client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encodedCredentials);
    //     client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    //
    //     var bodyString = $"grant_type=client_credentials&scope={Uri.EscapeDataString(string.Join(" ", scopes))}";
    //     var body = new StringContent(bodyString, Encoding.UTF8, "application/x-www-form-urlencoded");
    //
    //     var response = await client.PostAsync("https://api.sandbox.ebay.com/identity/v1/oauth2/token", body);
    //     response.EnsureSuccessStatusCode();
    //
    //     var json = await response.Content.ReadAsStringAsync();
    //
    //     using var doc = JsonDocument.Parse(json);
    //     var root = doc.RootElement;
    //     if (root.TryGetProperty("access_token", out var accessToken)) {
    //         return accessToken.GetString();
    //     }
    //
    //     throw new Exception("Access token not found in the response.");
    // }
    //
    // public static async Task<string> GetEbayApiDataAsync(string url, string token) {
    //     using var client = new HttpClient();
    //     client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    //     var response = await client.GetAsync(url);
    //     response.EnsureSuccessStatusCode();
    //     return await response.Content.ReadAsStringAsync();
    // }
    //
    // public static async Task SaveOrdersToCsvAsync(string json) {
    //     using var doc = JsonDocument.Parse(json);
    //     var orders = doc.RootElement.GetProperty("orders");
    //
    //     await using var writer = new StreamWriter("orders.csv");
    //     await using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
    //
    //     csv.WriteField("Order ID");
    //     csv.WriteField("Buyer Username");
    //     csv.WriteField("Total Price");
    //     csv.NextRecord();
    //
    //     foreach (var order in orders.EnumerateArray()) {
    //         csv.WriteField(order.GetProperty("orderId").GetString());
    //         csv.WriteField(order.GetProperty("buyer").GetProperty("username").GetString());
    //         csv.WriteField(order.GetProperty("pricingSummary").GetProperty("total").GetProperty("value").GetString());
    //         csv.NextRecord();
    //     }
    // }
    //
    // public static async Task SaveInventoryToCsvAsync(string json) {
    //     using var doc = JsonDocument.Parse(json);
    //     var items = doc.RootElement.GetProperty("inventoryItems");
    //
    //     await using var writer = new StreamWriter("inventory.csv");
    //     await using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
    //
    //     csv.WriteField("SKU");
    //     csv.WriteField("Title");
    //     csv.WriteField("Quantity");
    //     csv.NextRecord();
    //
    //     foreach (var item in items.EnumerateArray()) {
    //         csv.WriteField(item.GetProperty("sku").GetString());
    //         csv.WriteField(item.GetProperty("product").GetProperty("title").GetString());
    //         csv.WriteField(item.GetProperty("availability").GetProperty("shipToLocationAvailability").GetProperty("quantity").GetInt32());
    //         csv.NextRecord();
    //     }
    // }
}