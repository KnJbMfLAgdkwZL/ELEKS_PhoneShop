namespace Application.DTO.PhoneSpecificationsAPI.ListBrands
{
    public class BrandDto
    {
        public int Brand_id { get; set; }
        public string Brand_name { get; set; }
        public string Brand_slug { get; set; }
        public int Device_count { get; set; }
        public string Detail { get; set; }
    }
}