public class House
{
    public string Id { get; set; }

    public string StreetAndHouseNumber { get; set; }

    public string PostalCode { get; set; }

    public string City { get; set; }

    public decimal AskingPrice { get; set; }

    public DateTime PriceDate { get; set; }

    public override string ToString()
    {
        return $"Id: {Id} Street and housenumber {StreetAndHouseNumber} PostalCode: {PostalCode} City: {City} AskingPrice {AskingPrice}";
    }
}