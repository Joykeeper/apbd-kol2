namespace Kol2Preparation.DTOs;


public class DataDto{
    public NewCustomerDto Customer { get; set; }
    public List<NewCustomerPurchaseDto> Purchases { get; set; }
}

public class NewCustomerDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
}

public class NewCustomerPurchaseDto
{
    public int SeatNumber { get; set; }
    public string ConcertName { get; set; }
    public double Price { get; set; }
}