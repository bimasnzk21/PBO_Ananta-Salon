using NpgsqlTypes;

namespace MVC_ASP.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Jenis { get; set; }
        public string? Tanggal { get; set; }
        public string? nohp { get; set; }
        public string? email { get; set; }

    }
}
