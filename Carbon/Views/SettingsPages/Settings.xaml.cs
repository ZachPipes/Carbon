using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using log4net.Repository.Hierarchy;

namespace Carbon;

public partial class SettingsPage {
    public SettingsPage() {
        InitializeComponent();
    }

    public async void Authenticate(object sender, RoutedEventArgs e) {
        try {
            AuthenticationState.LaunchAuthFlow();
            await AuthenticationState.Instance.ExecuteEbayAuth();
        } catch (Exception ex) {
            MessageBox.Show($"Authorization failed: {ex.Message}");
        }
    }

    public void PrintToken(object sender, RoutedEventArgs e) {
        Console.WriteLine($"Token: <<< {AppState.Instance.AccessToken} >>>");
    }

    private void SwitchAPI(object sender, RoutedEventArgs e) {
        if (AppState.Instance.API == "sandbox.") {
            AppState.Instance.API = "";
            Console.WriteLine("Switched API to : PROD");
        }
        else {
            AppState.Instance.API = "sandbox.";
            Console.WriteLine("Switched API to : SANDBOX");
        }
    }
    
    
    
    private async void FunctionTest(object sender, RoutedEventArgs e) {
        //IMAGES
        string imagePath = @"C:\Users\Administrator\Downloads\BillDong.jpg";
        string elimageurl = "";
        string imageUrl = await EbayAPI.uploadImage(imagePath);
        using JsonDocument doc = JsonDocument.Parse(imageUrl);
        if(doc.RootElement.TryGetProperty("imageUrl", out JsonElement imageUrlElement)) {
            elimageurl = imageUrlElement.GetString();
        }
        
        var payload = new {
            product = new {
                title = "Apple Watch Series 2 - Silver Aluminum Case with White Sport Band",
                aspects = new {
                    Brand = new[] { "Apple" },
                    Model = new[] { "Apple Watch Series 2" },
                    CaseMaterial = new[] { "Aluminum" },
                    BandColor = new[] { "White" },
                    Condition = new[] { "New" }
                },
                description = "Apple Watch Series 2 with stunning design and advanced features. Built-in GPS and water resistance to 50 meters. Features a lightning-fast dual-core processor and a display that's two times brighter than before. Full of features that help you stay active, motivated, and connected.",
                imageUrls = new[] {
                    elimageurl
                }
            },
            condition = "NEW",
            packageWeightAndSize = new {
                dimensions = new {
                    length = 10,
                    width = 15,
                    height = 5,
                    unit = "INCH"
                },
                weight = new {
                    value = 2,
                    unit = "POUND"
                }
            },
            availability = new {
                shipToLocationAvailability = new {
                    quantity = 1,
                    allocationByFormat = new {
                        auction = 0,
                        fixedPrice = 1
                    }
                }
            }
        };
        
        string jsonPayload = JsonSerializer.Serialize(payload);
        
        try {
            string sku = await EbayAPI.generateInventoryItem(jsonPayload);
            string offerid = await EbayAPI.createOffer(sku);
            await EbayAPI.publishOffer(offerid);
        } catch(Exception ex) {
            Console.WriteLine(ex);
        }
    }
}