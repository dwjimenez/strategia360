namespace Strategia.Service.Api.DTOs
{
    public class VoteIntentOptionGroupDto
    {
        public string CodigoDignidad { get; set; } = string.Empty;
        public string FieldName { get; set; } = string.Empty;
        public string ObsFieldName { get; set; } = string.Empty;
        public string ObsLabel { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public List<VoteIntentOptionItemDto> Options { get; set; } = new();
    }
}
