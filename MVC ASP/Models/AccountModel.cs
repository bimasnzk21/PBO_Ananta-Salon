using NpgsqlTypes;

namespace MVC_ASP.Models
{
    public class AdminModel
    {
        public string? useradm { get; set; }
        public string? passadm { get; set; }

    }

    public class PelangganModel
    {
        public string? userpel { get; set; }
        public string? pswpel { get; set; }
        public string? emailpel { get; set; }

    }
}
