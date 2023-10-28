﻿  namespace WasteManagementAPI.Models
{
    public class Product
    {
        public Product() => Citizens = new HashSet<Citizen>();
        
        public int ProductId { get; set; }

        public string Name { get; set; } = string.Empty;

        public float Weight { get; set; }

        public ICollection<Citizen> Citizens { get; set; } 
    }
}
