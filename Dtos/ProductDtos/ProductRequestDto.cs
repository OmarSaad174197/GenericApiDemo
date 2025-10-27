namespace GenericDemo.Dtos.ProductDtos
{
    public record ProductRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
