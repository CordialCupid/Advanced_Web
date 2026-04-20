using System.ComponentModel.DataAnnotations;
namespace  CSCI3110MKLAB2CRRUD.Models.Entities;

public class Product {
    public int Id {get; set;} 
    public string Name {get; set;} = string.Empty;
    public decimal Price {get; set;}
    public double WeightInPounds {get; set;}
    [DataType(DataType.Date)]
    public DateTime ManufactureDate {get; set;}
    public bool InStock {get; set;}
    public byte[]? ImageData {get; set;}
    public string ImageMIMEType {get; set;} = string.Empty;
}