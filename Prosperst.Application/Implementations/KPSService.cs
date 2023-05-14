namespace Prosperst.Application.Implementations
{
    public class KPSService : IKPSService
    {
        private HttpClient _client;

        public KPSService(HttpClient client)
        {
            _client = client;
        }

        public async Task Verify(Customer customer)
        {
            var content = new StringContent($"<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"><soap:Body><TCKimlikNoDogrula xmlns=\"http://tckimlik.nvi.gov.tr/WS\"><TCKimlikNo>{customer.IdentityNo}</TCKimlikNo><Ad>{customer.Name}</Ad><Soyad>{customer.Surname}</Soyad><DogumYili>{customer.BirthDate.Year}</DogumYili></TCKimlikNoDogrula></soap:Body></soap:Envelope>",Encoding.UTF8,"text/xml");
            var response = await _client.PostAsync("/Service/KPSPublic.asmx", content);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());

        }
    }
}