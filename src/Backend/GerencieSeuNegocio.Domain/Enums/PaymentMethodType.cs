namespace GerencieSeuNegocio.Domain.Enums
{
    public enum PaymentMethodType
    {
        Undefined = 0,

        CreditCard = 1,
        DebitCard = 2,
        Pix = 3,
        BankTransfer = 4,
        Cash = 5,

        CreditCard_DebitCard = 6,
        CreditCard_Pix = 7,
        CreditCard_BankTransfer = 8,
        CreditCard_Cash = 9,

        DebitCard_Pix = 10,
        DebitCard_BankTransfer = 11,
        DebitCard_Cash = 12,

        Pix_BankTransfer = 13,
        Pix_Cash = 14,

        Cash_BankTransfer = 15,
    }
}
