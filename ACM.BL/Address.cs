namespace CMS.BusinessLayer
{
    /// <summary>
    /// A postal address shared by customer and order models.
    /// </summary>
    public class Address
    {
        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
