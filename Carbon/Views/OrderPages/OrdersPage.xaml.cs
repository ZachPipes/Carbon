namespace Carbon;

public partial class OrdersPage {
    public OrdersPage() {
        InitializeComponent();

        // var token = Utils.EbayAuth().GetAwaiter().GetResult();
        //
        // var ordersJson = Utils.GetEbayApiDataAsync("https://api.sandbox.ebay.com/sell/fulfillment/v1/order", token).GetAwaiter().GetResult();
        // Utils.SaveOrdersToCsvAsync(ordersJson).GetAwaiter().GetResult();
        //
        // var inventoryJson = Utils.GetEbayApiDataAsync("https://api.sandbox.ebay.com/sell/inventory/v1/inventory_item", token).GetAwaiter().GetResult();
        // Utils.SaveInventoryToCsvAsync(inventoryJson).GetAwaiter().GetResult();
        //
        // Console.WriteLine("Done syncing CSV files.");
    }
}

public class Order {
    public required string SalesRecordNumber { get; set; }
    public required string OrderNumber { get; set; }
    public required string BuyerUsername { get; set; }
    public required string BuyerName { get; set; }
    public required string BuyerEmail { get; set; }
    public required string BuyerNote { get; set; }
    public required string BuyerAddress1 { get; set; }
    public required string BuyerAddress2 { get; set; }
    public required string BuyerCity { get; set; }
    public required string BuyerState { get; set; }
    public required string BuyerZip { get; set; }
    public required string BuyerCountry { get; set; }
    public required string BuyerTaxIdentifierName { get; set; }
    public required string BuyerTaxIdentifierValue { get; set; }
    public required string ShipToName { get; set; }
    public required string ShipToPhone { get; set; }
    public required string ShipToAddress1 { get; set; }
    public required string ShipToAddress2 { get; set; }
    public required string ShipToCity { get; set; }
    public required string ShipToState { get; set; }
    public required string ShipToZip { get; set; }
    public required string ShipToCountry { get; set; }
    public required string ItemNumber { get; set; }
    public required string ItemTitle { get; set; }
    public required string CustomLabel { get; set; }
    public required string SoldViaPromotedListings { get; set; }
    public required string Quantity { get; set; }
    public required string SoldFor { get; set; }
    public required string ShippingAndHandling { get; set; }
    public required string ItemLocation { get; set; }
    public required string ItemZipCode { get; set; }
    public required string ItemCountry { get; set; }
    public required string EbayCollectAndRemitTaxRate { get; set; }
    public required string EbayCollectAndRemitTaxType { get; set; }
    public required string EbayReferenceName { get; set; }
    public required string EbayReferenceValue { get; set; }
    public required string TaxStatus { get; set; }
    public required string SellerCollectedTax { get; set; }
    public required string EbayCollectedTax { get; set; }
    public required string ElectronicWasteRecyclingFee { get; set; }
    public required string MattressRecyclingFee { get; set; }
    public required string BatteryRecyclingFee { get; set; }
    public required string WhiteGoodsDisposalTax { get; set; }
    public required string TireRecyclingFee { get; set; }
    public required string AdditionalFee { get; set; }
    public required string LumberFee { get; set; }
    public required string PrepaidWirelessFee { get; set; }
    public required string RoadImprovementAndFoodDeliveryFee { get; set; }
    public required string EbayCollectedCharges { get; set; }
    public required string TotalPrice { get; set; }
    public required string EbayCollectedTaxAndFeesIncludedInTotal { get; set; }
    public required string PaymentMethod { get; set; }
    public required string SaleDate { get; set; }
    public required string PaidOnDate { get; set; }
    public required string ShipByDate { get; set; }
    public required string MinimumEstimatedDeliveryDate { get; set; }
    public required string MaximumEstimatedDeliveryDate { get; set; }
    public required string ShippedOnDate { get; set; }
    public required string FeedbackLeft { get; set; }
    public required string FeedbackReceived { get; set; }
    public required string MyItemNote { get; set; }
    public required string PayPalTransactionID { get; set; }
    public required string ShippingService { get; set; }
    public required string TrackingNumber { get; set; }
    public required string TransactionID { get; set; }
    public required string VariationDetails { get; set; }
    public required string GlobalShippingProgram { get; set; }
    public required string GlobalShippingReferenceID { get; set; }
    public required string ClickAndCollect { get; set; }
    public required string ClickAndCollectReferenceNumber { get; set; }
    public required string EbayPlus { get; set; }
    public required string AuthenticityVerificationProgram { get; set; }
    public required string AuthenticityVerificationStatus { get; set; }
    public required string AuthenticityVerificationOutcomeReason { get; set; }
    public required string PSAVaultProgram { get; set; }
    public required string VaultFulfillmentType { get; set; }
    public required string EbayFulfillmentProgram { get; set; }
    public required string TaxCity { get; set; }
    public required string TaxState { get; set; }
    public required string TaxZip { get; set; }
    public required string TaxCountry { get; set; }
    public required string EbayInternationalShipping { get; set; }
}
