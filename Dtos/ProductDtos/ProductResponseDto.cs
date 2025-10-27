namespace GenericDemo.Dtos.ProductDtos
{
    public record ProductResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; } 
    }
}
