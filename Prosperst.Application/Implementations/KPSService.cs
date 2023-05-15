namespace Prosperst.Application.Implementations
{
    public class KPSService : IKPSService
    {
        private HttpClient _client;

        public KPSService(HttpClient client)
        {
            _client = client;
        }

        public async Task<bool> Verify(Customer customer)
        {
            var content = new StringContent($"<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"><soap:Body><TCKimlikNoDogrula xmlns=\"http://tckimlik.nvi.gov.tr/WS\"><TCKimlikNo>{customer.IdentityNo}</TCKimlikNo><Ad>{customer.Name}</Ad><Soyad>{customer.Surname}</Soyad><DogumYili>{customer.BirthDate.Year}</DogumYili></TCKimlikNoDogrula></soap:Body></soap:Envelope>", Encoding.UTF8, "text/xml");
            var response = await _client.PostAsync("/Service/KPSPublic.asmx", content);
            response.EnsureSuccessStatusCode();
            var responseXml = await response.Content.ReadAsStringAsync();

            XmlSerializer serializer = new XmlSerializer(typeof(Envelope));
            StringReader rdr = new StringReader(responseXml);
            Envelope envelope = (Envelope)serializer.Deserialize(rdr);

            return envelope?.Body?.TCKimlikNoDogrulaResponse?.TCKimlikNoDogrulaResult.Equals("true", StringComparison.CurrentCultureIgnoreCase) ?? false;
        }

        [XmlRoot(ElementName = "TCKimlikNoDogrulaResponse", Namespace = "http://tckimlik.nvi.gov.tr/WS")]
        public class TCKimlikNoDogrulaResponse
        {
            [XmlElement(ElementName = "TCKimlikNoDogrulaResult", Namespace = "http://tckimlik.nvi.gov.tr/WS")]
            public string TCKimlikNoDogrulaResult { get; set; }

            [XmlAttribute(AttributeName = "xmlns")]
            public string Xmlns { get; set; }
        }

        [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public class Body
        {
            [XmlElement(ElementName = "TCKimlikNoDogrulaResponse", Namespace = "http://tckimlik.nvi.gov.tr/WS")]
            public TCKimlikNoDogrulaResponse TCKimlikNoDogrulaResponse { get; set; }
        }

        [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public class Envelope
        {
            [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
            public Body Body { get; set; }

            [XmlAttribute(AttributeName = "soap", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Soap { get; set; }

            [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Xsi { get; set; }

            [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Xsd { get; set; }
        }
    }
}