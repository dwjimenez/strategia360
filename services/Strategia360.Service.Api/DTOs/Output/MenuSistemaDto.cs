namespace DFast.Seguridad.Api.DTOs
{
    public class MenuSistemaDto
    {
        public string id { get; set; }

        public int? idMenuOrigin { get; set; }
        public string label  { get; set; }
        public string subtitle { get; set; }
        public string type { get; set; }
        public string icon { get; set; }
        public bool? visible { get; set; }
        public int? orden { get; set; }

        public List<MenuSistemaChildren> children { get; set; }

    }

    public class MenuSistemaChildren
    {
        public string id { get; set; }
        public string label { get; set; }
        public string subtitle { get; set; }
        public string type { get; set; }
        public string icon { get; set; }
        public string uri { get; set; }
        public int idMenuOrigin { get; set; }
        public bool? visible { get; set; }
        public int? orden { get; set; }
        public List<MenuSistemaChildren> children { get; set; }
    }

}
