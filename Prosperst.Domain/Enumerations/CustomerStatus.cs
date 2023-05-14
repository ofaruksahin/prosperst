namespace Prosperst.Domain.Enumerations
{
    public enum CustomerStatus
    {
        [Description("Kimlik Doğrulama Bekleniyor")]
        WAITING_IDENTITY_VERIFICATION = 1,

        [Description("Kimlik Doğrulandı")]
        IDENTITY_VERIFICATED = 2,

        [Description("Kimlik Doğrulanamadı")]
        IDENTITY_NOT_VERIFICATED = 3
    }
}