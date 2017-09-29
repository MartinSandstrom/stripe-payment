public class Product 
{

    public Product(string Id, string Name, string Description, string ImageUrl)
    {
        this.Id = Id;
        this.Name = Name;
        this.Description = Description;
        this.ImageUrl = ImageUrl;
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}