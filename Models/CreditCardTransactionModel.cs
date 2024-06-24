// Models/CreditCardTransactionModel.cs
public class CreditCardTransactionModel
{
    public string MerchantOrderId { get; set; }
    public CreditCardCustomerModel Customer { get; set; }
    public CreditCardPaymentModel Payment { get; set; }
}

public class CreditCardCustomerModel
{
    public string Name { get; set; }
    public string Identity { get; set; }
    public string IdentityType { get; set; }
    public string Email { get; set; }
    public string Birthdate { get; set; }
}

public class CreditCardPaymentModel
{
    public decimal ServiceTaxAmount { get; set; }
    public int Installments { get; set; }
    public decimal Interest { get; set; }
    public bool Capture { get; set; }
    public bool Authenticate { get; set; }
    public bool Recurrent { get; set; }
    public string SoftDescriptor { get; set; }
    public CreditCardModel CreditCard { get; set; }
    // Outros campos necessários
}

public class CreditCardModel
{
    public string CardNumber = "4024007153763191";
    public string Holder { get; set; }
    public string ExpirationDate { get; set; }
    public string SecurityCode { get; set; }
    public bool SaveCard { get; set; }
    public string Brand { get; set; }
    public CreditCardCardOnFileModel CardOnFile { get; set; }
}

public class CreditCardCardOnFileModel
{
    public string Usage { get; set; }
    public string Reason { get; set; }
}