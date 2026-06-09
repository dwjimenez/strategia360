namespace Docufy.Seguridad.Api.DTOs
{
    public class MessageGeneral
    {
        public List<string> To { get; set; }
        public string Subject { get; set; }
        public string Institution { get; set; }
        public string Code { get; set; }

        public List<string> Content { get; set; }

        public MessageGeneral(List<string> to, string subject, string institution, string code, List<string> content)
        {
            To = to;
            Subject = subject;
            Content = content;
            Institution = institution;
            Code = code;
        }
    }
}
