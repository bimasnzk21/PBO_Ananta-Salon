using Microsoft.AspNetCore.Mvc;
using MVC_ASP.Models;
using System.Diagnostics;
using Npgsql;
using System.Data;

namespace MVC_ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Helper helper;
        // Object DataSet
        DataSet ds;
        // Object List of NpgsqlParameter
        NpgsqlParameter[] param;
        // Query ke Database
        string query;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            // Inisialisasi Object
            helper = new Helper();
            ds = new DataSet();
            param = new NpgsqlParameter[] { };
            query = "";
        }

        public IActionResult Process()
        {
            // Reinisialiasi ds dan param agar dataset dan parameter nya kembali null
            ds = new DataSet();
            param = new NpgsqlParameter[] { };

            // Query Select
            query = "SELECT * FROM pengguna.pemesanan";
            // Panggil DBConn untuk eksekusi Query
            helper.DBConn(ref ds, query, param);

            // List of User untuk menampung data user
            List<UserModel> users = new List<UserModel>();
            // Mengambil value dari tabel di index 0
            var data = ds.Tables[0];

            // Perulangan untuk mengambil instance tiap baris dari tabel
            foreach (DataRow u in data.Rows)
            {
                // Membuat object User baru
                UserModel user = new UserModel();
                // Mengisi id dan username dari object user dengan nilai dari database
                user.Id = u.Field<Int32>(data.Columns[0]);
                user.Username = u.Field<string>(data.Columns[1]);
                user.Jenis = u.Field<string>(data.Columns[2]);
                user.Tanggal = u.Field<string>(data.Columns[3]);
                user.nohp = u.Field<string>(data.Columns[4]);
                user.email = u.Field<string>(data.Columns[5]);
                // Menambahkan user ke users (List of User)
                users.Add(user);
            }

            ViewData["data"] = users;

            return View();
        }

        public IActionResult LoginAdmin()
        {
            return View();
        }

        public IActionResult Login(string useradm, string passadm)
        {
            ds = new DataSet();
            param = new NpgsqlParameter[] { };
            // Query Select

            query = "SELECT * FROM pengguna.admin;";
            // Panggil DBConn untuk eksekusi Query
            helper.DBConn(ref ds, query, param);

            // List of User untuk menampung data user
            List<AdminModel> admins = new List<AdminModel>();
            // Mengambil value dari tabel di index 0
            var data = ds.Tables[0];

            // Perulangan untuk mengambil instance tiap baris dari tabel
            foreach (DataRow u in data.Rows)
            {
                // Membuat object User baru
                AdminModel admin = new AdminModel();
                // Mengisi id dan username dari object user dengan nilai dari database
                admin.useradm = u.Field<string>(data.Columns[1]);
                admin.passadm = u.Field<string>(data.Columns[2]);
                // Menambahkan user ke users (List of User)
                admins.Add(admin);
            }

            ViewData["data"] = admins;

            bool berhasil = true;
            foreach (var admin in admins)
            {
                if (admin.passadm == passadm && admin.useradm == admin.useradm)
                {
                    Console.WriteLine("Login Berhasil");
                    break;
                }
                else
                {
                    Console.WriteLine("Cek Kembali username dan password Anda!");
                    berhasil = false;
                }
            }

            switch (berhasil)
            {
                case true:
                    return RedirectToAction("IndexAdmin");
                case false:
                    return RedirectToAction("LoginAdminFail");
            }

        }

        public IActionResult LoginPelanggan(string userpel, string pswpel)
        {
            ds = new DataSet();
            param = new NpgsqlParameter[] { };
            // Query Select

            query = "SELECT * FROM pengguna.pelanggan;";
            // Panggil DBConn untuk eksekusi Query
            helper.DBConn(ref ds, query, param);

            // List of User untuk menampung data user
            List<PelangganModel> pelang = new List<PelangganModel>();
            // Mengambil value dari tabel di index 0
            var data = ds.Tables[0];

            // Perulangan untuk mengambil instance tiap baris dari tabel
            foreach (DataRow u in data.Rows)
            {
                // Membuat object User baru
                PelangganModel pel = new PelangganModel();
                // Mengisi id dan username dari object user dengan nilai dari database
                pel.userpel = u.Field<string>(data.Columns[1]);
                pel.pswpel = u.Field<string>(data.Columns[2]);
                // Menambahkan user ke users (List of User)
                pelang.Add(pel);
            }

            ViewData["data"] = pelang;

            bool berhasil = true;
            foreach (var pel in pelang)
            {
                if (pel.pswpel == pel.pswpel && pel.userpel == pel.userpel)
                {
                    Console.WriteLine("Login Berhasil");
                    break;
                }
                else
                {
                    Console.WriteLine("Cek Kembali username dan password Anda!");
                    berhasil = false;
                }
            }

            switch (berhasil)
            {
                case true:
                    return RedirectToAction("IndexPel");
                case false:
                    return RedirectToAction("LoginPelFail");
            }

        }

        public IActionResult Info()
        {
            return View();
        }

        public IActionResult LoginPel()
        {
            return View();
        }

        public IActionResult IndexPel()
        {
            return View();
        }
        public IActionResult InfoPel()
        {
            return View();
        }

        public IActionResult RambutPel()
        {
            return View();
        }

        public IActionResult WajahPel()
        {
            return View();
        }

        public IActionResult LoginPelFail()
        {
            return View();
        }

        public IActionResult LoginAdminFail()
        {
            return View();
        }

        public IActionResult InfoAdmin()
        {
            return View();
        }

        public IActionResult LoginMain()
        {
            return View();
        }

        public IActionResult WajahAdmin()
        {
            return View();
        }

        public IActionResult RambutAdmin()
        {
            return View();
        }

        public IActionResult IndexAdmin()
        {
            return View();
        }


        public IActionResult Insert()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(int Id, string Username)
        {
            return View();
        }

        public IActionResult Rambut()
        {
            return View();
        }
        public IActionResult Wajah()
        {
            return View();
        }

        public IActionResult Pemesanan()
        {
            return View();
        }

        public IActionResult Sign()
        {
            return View();
        }

        public void GetUserById(int id)
        {
            ds = new DataSet();
            param = new NpgsqlParameter[] { 
            // Parameter untuk id
            new NpgsqlParameter("@id_pemesanan", id)
        };

            query = "SELECT * FROM pengguna.pemesanan WHERE id = @id_pemesanan;";
            helper.DBConn(ref ds, query, param);


            List<UserModel> users = new List<UserModel>();

            var data = ds.Tables[0];

            foreach (DataRow u in data.Rows)
            {
                UserModel user = new UserModel();
                user.Id = u.Field<Int32>(data.Columns[0]);
                user.Username = u.Field<string>(data.Columns[1]);
                user.Jenis = u.Field<string>(data.Columns[2]);
                user.Tanggal = u.Field<string>(data.Columns[3]);
                user.nohp = u.Field<string>(data.Columns[4]);
                user.email = u.Field<string>(data.Columns[5]);
                users.Add(user);
            }

            foreach (UserModel user in users)
            {
                Console.WriteLine($"ID: {user.Id} -- Username: {user.Username}");
            }
        }

        public IActionResult Signup(PelangganModel pel)
        {
            ds = new DataSet();
            param = new NpgsqlParameter[] {
            // Parameter untuk id dan username
            new NpgsqlParameter("@userpel", pel.userpel),
            new NpgsqlParameter("@pswpel", pel.pswpel),
            new NpgsqlParameter("@emailpel", pel.emailpel),
        };

            query = "INSERT INTO pengguna.pelanggan VALUES (@userpel, @pswpel, @emailpel);";
            helper.DBConn(ref ds, query, param);

            return RedirectToAction("IndexPel");
        }

        public IActionResult Insertdata(UserModel user)
        {
            ds = new DataSet();
            param = new NpgsqlParameter[] {
            // Parameter untuk id dan username
            new NpgsqlParameter("@id_pemesanan", user.Id),
            new NpgsqlParameter("@nama_pelanggan", user.Username),
            new NpgsqlParameter("@jenis_perawatan", user.Jenis),
            new NpgsqlParameter("@tanggal_perawatan", user.Tanggal),
            new NpgsqlParameter("@no_hp", user.nohp),
            new NpgsqlParameter("@email", user.email),
        };

            query = "INSERT INTO pengguna.pemesanan VALUES (@id_pemesanan, @nama_pelanggan, @jenis_perawatan, @tanggal_perawatan, @no_hp, @email);";
            helper.DBConn(ref ds, query, param);

            return RedirectToAction("Process");
        }

        public IActionResult UpdateUser(UserModel user)
        {
            ds = new DataSet();
            param = new NpgsqlParameter[] {
            new NpgsqlParameter("@id_pemasanan", user.Id),
            new NpgsqlParameter("@nama_pelanggan", user.Username),
            new NpgsqlParameter("@jenis_perawatan", user.Jenis),
            new NpgsqlParameter("@tanggal_perawatan", user.Tanggal),
            new NpgsqlParameter("@no_hp", user.nohp),
            new NpgsqlParameter("@email", user.email),
        };

            query = "UPDATE pengguna.pemesanan SET nama_pelanggan = @nama_pelanggan, jenis_perawatan = @jenis_perawatan, tanggal_perawatan = @tanggal_perawatan, no_hp = @no_hp, email = @email WHERE id_pemesanan = @id_pemesanan;";
            helper.DBConn(ref ds, query, param);

            return RedirectToAction("IndexAdmin");
        }

        public IActionResult DeleteUser(UserModel user)
        {
            ds = new DataSet();
            param = new NpgsqlParameter[] {
            new NpgsqlParameter("@id_pemesanan", user.Id)
        };

            query = "DELETE FROM pengguna.pemesanan WHERE id_pemesanan = @id_pemesanan;";
            helper.DBConn(ref ds, query, param);

            return RedirectToAction("IndexAdmin");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    // Helper untuk koneksi ke DB
    class Helper
    {
        public void DBConn(ref DataSet ds, string query, NpgsqlParameter[] param)
        {
            // Data Source Name berisi credential dari database
            string dsn = "Host=localhost;Username=postgres;Password=Bima12345;Database=PBO;Port=5432";
            // Membuat koneksi ke db
            var conn = new NpgsqlConnection(dsn);
            // Command untuk eksekusi query
            var cmd = new NpgsqlCommand(query, conn);

            try
            {
                // Perulangan untuk menyisipkan nilai yang ada pada parameter ke query
                foreach (var p in param)
                {
                    cmd.Parameters.Add(p);
                }
                // Membuka koneksi ke database
                cmd.Connection!.Open();
                // Mengisi ds dengan data yang didapatkan dari database
                new NpgsqlDataAdapter(cmd).Fill(ds);
                Console.WriteLine("Query berhasil dieksekusi");
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                // Menutup koneksi ke database
                cmd.Connection!.Close();
            }

        }
    }
}






