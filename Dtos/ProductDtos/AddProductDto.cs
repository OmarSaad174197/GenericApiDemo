namespace GenericDemo.Dtos.ProductDtos
{
    public record AddProductDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
