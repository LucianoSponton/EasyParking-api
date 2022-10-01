using Model;
using ServiceWebApi;
using System;
using System.Net.Http;

namespace Test
{
    class Program
    {
        // **** Con esto se usa la api de arriba o la local *** ///
        //static string Uri = "http://localhost:5000";
        static string Uri = "http://40.118.242.96:12595";
        static HttpClient httpClient { get; set; } = new HttpClient();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //UserInfo user = new UserInfo();
            //user.Apellido = "sponton";
            //user.Nombre = "luciano";
            //user.Email = "lucianosponton14@hotmail.com";
            //user.Password = "xxx123";
            //user.UserName = "lucho123";

            //UserInfo user = new UserInfo();
            //user.Apellido = "sponton";
            //user.Nombre = "leandro";
            //user.Email = "leandrosponton14@hotmail.com";
            //user.Password = "xxx124";
            //user.UserName = "leo";

            UserInfo user = new UserInfo();
            user.Apellido = "ronaldo";
            user.Nombre = "cristiano";
            user.Email = "cristiano@hotmail.com";
            user.Password = "cristiano123";
            user.UserName = "cristiano@hotmail.com";
            user.NumeroDeDocumento = "40256941";
            user.TipoDeDocumento = Model.Enums.TipoDeDocumento.DNI;
            user.Telefono = "3777111256";

            try
            {
                var webapiaccess =  WebApiAccess.GetAccessAsync("http://40.118.242.96:12595", "sgsghegwe", "afswergaef").Result;
                //var webapiaccess = WebApiAccess.GetAccessAsync("http://40.118.242.96:12595", "cristiano@hotmail.com", "cristiano123").Result;
                AccountServiceWebApi02 accountServiceWebApi02 = new AccountServiceWebApi02(webapiaccess);
                var userr = accountServiceWebApi02.GetUserInfo("cristiano@hotmail.com").Result;
                //** Crear usuario **////
                //AccountServiceWebApi.CreateUser(user);

                /// *** logear usuario *** /// 
               //string token = AccountServiceWebApi.Login("cristiano@hotmail.com", "cristiano123");
                //string token = AccountServiceWebApi.Login("leandrosponton14@hotmail.com", "xxx124");

                /// *** Consultar usuario ** /// 
                //string token = AccountServiceWebApi.Login("cristiano@hotmail.com", "cristiano123");
                //var userinfo = AccountServiceWebApi.GetUserInfo("cristiano@hotmail.com", "cristiano123").Result;

                /// update usuario //
                // string token = AccountServiceWebApi.Login("cristiano@hotmail.com", "cristiano123");
                //UserInfo userinfo = new UserInfo();
                //userinfo.Apodo = "xx";
                //AccountServiceWebApi.Update(userinfo, "cristiano@hotmail.com", "cristiano123");

                /// eliminar usuario /// 
                //token = AccountServiceWebApi.Login("cristiano@hotmail.com", "cristiano123");
                //AccountServiceWebApi.UserLock("cristiano@hotmail.com");

                //string token = AccountServiceWebApi.Login("EasyParkingAdmin", "easyparking123");
                //AccountServiceWebApi.UserUnLock("analia@hotmail.com");
                //string token = AccountServiceWebApi.Login("analia@hotmail.com", "analia123");
                //Console.WriteLine("ok");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //accountServiceWebApi.Update(user);
            //accountServiceWebApi.UserLock(user.Email);
            //accountServiceWebApi.UserUnLock(user.Email);
            //accountServiceWebApi.UserLockItSelf(user.Email, user.Password);
            Console.ReadKey();

        }

        //static void CreateUser(UserInfo user)
        //{
        //    try
        //    {
        //        string Uri = "http://localhost:5000";
        //        //string Uri = "http://40.118.242.96:12595";
        //        Console.WriteLine("Autenticando ...");
        //        httpClient.BaseAddress = new Uri(Uri);
        //        Random rand = new Random(DateTime.Now.Second);
        //        Console.WriteLine("Comienza Add()");

        //        string dtojson = JsonConvert.SerializeObject(user); // aca va el DTO de userinfo 
        //        HttpContent content2 = new StringContent(dtojson, Encoding.UTF8, "application/json");
        //        HttpResponseMessage response2 = httpClient.PostAsync("/api/Account/CreateUser", content2).Result;
        //        if (response2.StatusCode == System.Net.HttpStatusCode.OK)
        //        {
        //            Console.WriteLine("Create ok");

        //        }
        //        else
        //        {
        //            Console.WriteLine(response2.ReasonPhrase);
        //        }

        //        //httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine(ex.Message);
        //    }
        //    //}
        //}

        //static string Login(string username, string password)
        //{
        //    try
        //    {
        //        string Uri = "http://localhost:5000";
        //        //string Uri = "http://40.118.242.96:12595";
        //        Console.WriteLine("Autenticando ...");
        //        httpClient.BaseAddress = new Uri(Uri);
        //        var userDTO = new { username = username, password = password };
        //        Random rand = new Random(DateTime.Now.Second);
        //        Console.WriteLine("Comienza Login()");
        //        string dtojson = JsonConvert.SerializeObject(userDTO); // aca va el DTO de userinfo 
        //        HttpContent content2 = new StringContent(dtojson, Encoding.UTF8, "application/json");
        //        HttpResponseMessage response2 = httpClient.PostAsync("/api/Account/Login", content2).Result;
        //        if (response2.StatusCode == System.Net.HttpStatusCode.OK)
        //        {
        //            string jsontoken = response2.Content.ReadAsStringAsync().Result;
        //            JObject jsonresult = JObject.Parse(jsontoken);
        //            string token = jsonresult.SelectToken("token").ToObject<string>();
        //            DateTime expiration = jsonresult.SelectToken("expiration").ToObject<DateTime>();
        //            Console.WriteLine("Token: " + response2.StatusCode);
        //            Console.WriteLine("Token: " + token);
        //            return token;

        //        }
        //        else
        //        {
        //            Console.WriteLine(response2.ReasonPhrase + " " + response2.Content.ReadAsStringAsync().Result);
        //            return null;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return null;
        //    }
        //    //}
        //}

        //static void Update(UserInfo user)
        //{
        //    try
        //    {
        //        string token = Login(user.UserName, user.Password);

        //        if (!string.IsNullOrEmpty(token))
        //        {
        //            //string Uri = "http://localhost:5000";
        //            string Uri = "http://40.118.242.96:12595";
        //            Console.WriteLine("Autenticando ...");
        //            httpClient.BaseAddress = new Uri(Uri);
        //            var userDTO = new { apellido = user.Apellido };

        //            Random rand = new Random(DateTime.Now.Second);
        //            Console.WriteLine("Comienza Update()");

        //            string dtojson = JsonConvert.SerializeObject(userDTO); // aca va el DTO de userinfo 
        //            HttpContent content2 = new StringContent(dtojson, Encoding.UTF8, "application/json");

        //            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

        //            HttpResponseMessage response2 = httpClient.PostAsync("/api/Account/UpdateUser", content2).Result;
        //            if (response2.StatusCode == System.Net.HttpStatusCode.OK)
        //            {
        //                Console.WriteLine("Update ok");

        //            }
        //            else
        //            {
        //                Console.WriteLine(response2.ReasonPhrase);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine(ex.Message);
        //    }

        //}

        //static void UserLock(string username)
        //{
        //    try
        //    {
        //        string token = Login("EasyParkingAdmin", "easyparking123"); // login de admin

        //        if (!string.IsNullOrEmpty(token))
        //        {

        //            Console.WriteLine("Comienza UserLock()");

        //            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

        //            HttpResponseMessage response2 = httpClient.GetAsync($"/api/Account/UserLock/{username}").Result;
        //            if (response2.StatusCode == System.Net.HttpStatusCode.OK)
        //            {
        //                Console.WriteLine("UserLock ok");

        //            }
        //            else
        //            {
        //                Console.WriteLine(response2.ReasonPhrase);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine(ex.Message);
        //    }

        //}
        //static void UserUnLock(string username)
        //{
        //    try
        //    {
        //        string token = Login("EasyParkingAdmin", "easyparking123"); // login de admin

        //        if (!string.IsNullOrEmpty(token))
        //        {

        //            Console.WriteLine("Comienza UserUnLock()");

        //            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

        //            HttpResponseMessage response2 = httpClient.GetAsync($"/api/Account/UserUnLock/{username}").Result;
        //            if (response2.StatusCode == System.Net.HttpStatusCode.OK)
        //            {
        //                Console.WriteLine("UserUnLock ok");

        //            }
        //            else
        //            {
        //                Console.WriteLine(response2.ReasonPhrase);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine(ex.Message);
        //    }

        //}

        //static void UserLockItSelf(string username, string password)
        //{
        //    try
        //    {
        //        string token = Login(username, password); // login de user it self

        //        if (!string.IsNullOrEmpty(token))
        //        {

        //            Console.WriteLine("Comienza UserLockItSelf()");

        //            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

        //            HttpResponseMessage response2 = httpClient.GetAsync($"/api/Account/UserLockItSelf/{username}").Result;
        //            if (response2.StatusCode == System.Net.HttpStatusCode.OK)
        //            {
        //                Console.WriteLine("UserLockItSelf ok");

        //            }
        //            else
        //            {
        //                Console.WriteLine(response2.ReasonPhrase);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine(ex.Message);
        //    }

        //}

    }
}
