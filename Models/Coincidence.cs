using System;

namespace coincidence.Models
{
  public class Coincidence
  {
    public int Id { get; set; }
    public string SKU { get; set; }
    public string Name { get; set; }
    public string Short_description { get; set; }
    public int NumberInStock { get; set; }
    public double Price { get; set; }
    public DateTime DateOrdered { get; set; } = DateTime.Now;
  }
}