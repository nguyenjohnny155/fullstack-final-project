using System.ComponentModel.DataAnnotations;

namespace ShopApi.Models;

// One to Many Table
public class ShopItem
{
    [Key]
    public int Id {get; set;}
    public string ItemName {get; set;} = null!;
    public float ItemBasePrice {get; set;}
    public float Rating {get;set;}
    public float NumReviews{get;set;}
    public List<ItemAddOn> ItemAddOns { get; set; } // Connects to ItemAddOn rows
    public string S3BaseUrl {get; set;}
}

