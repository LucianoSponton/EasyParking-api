using Model;
using ServiceWebApi;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        // **** Con esto se usa la api de arriba o la local *** ///
        static string Uri = "http://localhost:5000";
        //static string Uri = "http://40.118.242.96:12595";
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
                // PruebaLogin().Wait();
                //for (int i = 0; i < 4; i++)
                //{
                //    Agregar().Wait();
                //}
               //  GetAllEstacionamientos().Wait();
                //var lista = GetAll().Result;
                //Estacionamiento estacionamiento = lista[0];
                //estacionamiento.Id = 0;
                //Delete(11).Wait();
                Agregar().Wait();
                //var estacionamiento = Get(17).Result;
                // Update(estacionamiento).Wait();
                //var estacionamiento2 = Get(9).Result;

                //var webapiaccess = WebApiAccess.GetAccessAsync("http://40.118.242.96:12595", "debranahir@gmail.com", "debra1234", 3, 60).Result;
                //EstacionamientoServiceWebApi estacionamientoServiceWebApi = new EstacionamientoServiceWebApi(webapiaccess);

                //for (int i = 20; i < 30; i++)
                //{
                //    estacionamientoServiceWebApi.SetInactivo(i).Wait();
                //}

                //AccountServiceWebApi accountServiceWebApi02 = new AccountServiceWebApi(webapiaccess);
                //AgregarEstacionamientoAsync();
                //GetAllEstacionamientos().Wait();
                //var userr = accountServiceWebApi02.UserUnLock("cristiano@hotmail.com");

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

        static async Task PruebaLogin()
        {
            try
            {

                //var webapiaccess = await WebApiAccess.GetAccessAsync("http://localhost:5000", "debranahir@gmail.com", "debra1234", 3, 60);
                var webapiaccess = await WebApiAccess.GetAccessAsync("http://40.118.242.96:12595", "debranahir@gmail.com", "debra1234", 3, 60);
                AccountServiceWebApi accountServiceWebApi = new AccountServiceWebApi(webapiaccess);
                var x = await accountServiceWebApi.GetUserInfo("debranahir@gmail.com");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        static async Task<List<Estacionamiento>> GetAll()
        {
            try
            {
                Console.WriteLine("GetAccess");
                //var webapiaccess = await WebApiAccess.GetAccessAsync(Uri, "cristiano@hotmail.com", "cristiano123", 3, 3 * 60);
                var webapiaccess = await WebApiAccess.GetAccessAsync(Uri, "debranahir@gmail.com", "debra1234", 3, 60);
                EstacionamientoServiceWebApi estacionamientoServiceWebApi = new EstacionamientoServiceWebApi(webapiaccess);
                Console.WriteLine("Consultando");
                var x = await estacionamientoServiceWebApi.GetAll();
                return x;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        static async Task GetAllInclude()
        {
            try
            {
                Console.WriteLine("GetAccess");
                var webapiaccess = await WebApiAccess.GetAccessAsync("http://40.118.242.96:12595", "debranahir@gmail.com", "debra1234", 3, 60);
                EstacionamientoServiceWebApi estacionamientoServiceWebApi = new EstacionamientoServiceWebApi(webapiaccess);
                Console.WriteLine("Consultando");
                var x = await estacionamientoServiceWebApi.GetAllInclude();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        static async Task<Estacionamiento> Get(int estacionamientoId)
        {
            try
            {
                Console.WriteLine("GetAccess");
                var webapiaccess = await WebApiAccess.GetAccessAsync("http://40.118.242.96:12595", "debranahir@gmail.com", "debra1234", 3, 60);
                EstacionamientoServiceWebApi estacionamientoServiceWebApi = new EstacionamientoServiceWebApi(webapiaccess);
                Console.WriteLine("Consultando");
                var estacionamiento = await estacionamientoServiceWebApi.Get(estacionamientoId);
                Console.WriteLine("Get Ok");
                return estacionamiento;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        static async Task SetInactivo(int estacionamientoId)
        {
            try
            {
                Console.WriteLine("GetAccess");
                var webapiaccess = await WebApiAccess.GetAccessAsync("http://40.118.242.96:12595", "debranahir@gmail.com", "debra1234", 3, 60);
                EstacionamientoServiceWebApi estacionamientoServiceWebApi = new EstacionamientoServiceWebApi(webapiaccess);
                Console.WriteLine("Seteando");
                await estacionamientoServiceWebApi.SetInactivo(estacionamientoId);
                Console.WriteLine("SetInactivo ok");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task SetPublicacionPausada(int estacionamientoId)
        {
            try
            {
                Console.WriteLine("GetAccess");
                var webapiaccess = await WebApiAccess.GetAccessAsync("http://40.118.242.96:12595", "debranahir@gmail.com", "debra1234", 3, 60);
                EstacionamientoServiceWebApi estacionamientoServiceWebApi = new EstacionamientoServiceWebApi(webapiaccess);

                Console.WriteLine("Seteando");
                await estacionamientoServiceWebApi.SetPublicacionPausada(estacionamientoId);
                Console.WriteLine("SetPublicacionPausada ok");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        static async Task Delete(int estacionamientoId)
        {
            try
            {
                Console.WriteLine("GetAccess");
                var webapiaccess = await WebApiAccess.GetAccessAsync("http://40.118.242.96:12595", "debranahir@gmail.com", "debra1234", 3, 60);
                EstacionamientoServiceWebApi estacionamientoServiceWebApi = new EstacionamientoServiceWebApi(webapiaccess);
                Console.WriteLine("Eliminando");
                await estacionamientoServiceWebApi.Delete(estacionamientoId);
                Console.WriteLine("Delete ok");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        static async Task Update(Estacionamiento estacionamiento)
        {
            try
            {
                Console.WriteLine("GetAccess");
                var webapiaccess = await WebApiAccess.GetAccessAsync("http://40.118.242.96:12595", "debranahir@gmail.com", "debra1234", 3, 60);
                EstacionamientoServiceWebApi estacionamientoServiceWebApi = new EstacionamientoServiceWebApi(webapiaccess);
                Console.WriteLine("Actualizando");
                //estacionamiento.Imagen = Tools.GetBytesFromUrl("https://www.neahoy.com/wp-content/uploads/2022/02/San-Valentin-cuanto-puede-costar-una-salida-en-pareja-en-la-capital-correntina-2.jpg");
                estacionamiento.PublicacionPausada = true;
                estacionamiento.Inactivo = false;

                await estacionamientoServiceWebApi.Update(estacionamiento);
                Console.WriteLine("Update ok");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        static async Task Agregar()
        {
            try
            {
                List<string> ciudades = new List<string>();
                ciudades.Add("La Plata");
                ciudades.Add("San Fernando del Valle de Catamarca");
                ciudades.Add("Resistencia");
                ciudades.Add("Rawson");
                ciudades.Add("Córdoba");
                ciudades.Add("Corrientes");
                ciudades.Add("Paraná");
                ciudades.Add("Formosa");
                ciudades.Add("San Salvador de Jujuy");
                ciudades.Add("Santa Rosa");
                ciudades.Add("La Rioja");
                ciudades.Add("Mendoza");
                ciudades.Add("Posadas");
                ciudades.Add("Neuquén");
                ciudades.Add("Viedma");
                ciudades.Add("Salta");
                ciudades.Add("San Luis");
                ciudades.Add("Río Gallegos");
                ciudades.Add("Santa Fe");
                ciudades.Add("Santiago del Estero");
                ciudades.Add("Ushuaia");
                ciudades.Add("San Miguel de Tucumán");

                List<string> lugares = new List<string>();
                lugares.Add("Terreno parialmente cubierto");
                lugares.Add("Galpón abierto");
                lugares.Add("Galpón cerrado");
                lugares.Add("Lugar bajo edificio");
                lugares.Add("Casa");

                Console.WriteLine("GetAccess");
                //var webapiaccess = await WebApiAccess.GetAccessAsync("http://localhost:5000", "EasyParkingAdmin", "easyparking123");
                var webapiaccess = await WebApiAccess.GetAccessAsync("http://40.118.242.96:12595", "debranahir@gmail.com", "debra1234", 3, 60);
                EstacionamientoServiceWebApi estacionamientoServiceWebApi = new EstacionamientoServiceWebApi(webapiaccess);

                Console.WriteLine("Preparando Estacionamiento");


                Estacionamiento estacionamiento = new Estacionamiento();

                Random numRandom = new Random();


                estacionamiento.Ciudad = ciudades[numRandom.Next(0, 22)]; ;
                estacionamiento.Imagen = Tools.GetBytesFromUrl("https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/drivers-loft-1-1643441566.jpg?resize=480:*");// // IMAGEN DEL LUGAR
                //estacionamiento.Nombre = $"El parking {numRandom.Next(1, 999)}";// // NOMBRE DEL LUGAR
                estacionamiento.Nombre = "Park";// // NOMBRE DEL LUGAR
                estacionamiento.Direccion = $"Calle {numRandom.Next(1, 999)}";// // DIRECCION DEL LUGAR
                estacionamiento.TipoDeLugar = lugares[numRandom.Next(0, 4)]; // // TIPO DEL LUGAR
                                                                             // LOS RANGO HORARIOS YA SE CARGARON ANTES EN EL EVENTO --> btnEditarHorario_Clicked

                List<RangoH> lista = new List<RangoH>();
                RangoH r = new RangoH();
                r.DesdeHora = numRandom.Next(6, 10);
                r.DesdeMinuto = 0;
                r.HastaHora = numRandom.Next(15, 22);
                r.HastaMinuto = 30;
                lista.Add(r);

                Jornada jornada = new Jornada();
                jornada.Horarios = lista;

                switch (numRandom.Next(1, 7))
                {
                    case 1:
                        jornada.DiaDeLaSemana = Model.Enums.Dia.LUNES;
                        break;
                    case 2:
                        jornada.DiaDeLaSemana = Model.Enums.Dia.MARTES;
                        break;
                    case 3:
                        jornada.DiaDeLaSemana = Model.Enums.Dia.MIERCOLES;
                        break;
                    case 4:
                        jornada.DiaDeLaSemana = Model.Enums.Dia.JUEVES;
                        break;
                    case 5:
                        jornada.DiaDeLaSemana = Model.Enums.Dia.VIERNES;
                        break;
                    case 6:
                        jornada.DiaDeLaSemana = Model.Enums.Dia.SABADO;
                        break;
                    case 7:
                        jornada.DiaDeLaSemana = Model.Enums.Dia.DOMINGO;
                        break;
                }

                estacionamiento.Jornadas.Add(jornada);



                //********** TEMA VEHICULOS ACEPTADOS Y SUS TARIFAS **********//

                Model.DataVehiculoAlojado dataVehiculo = new Model.DataVehiculoAlojado();
                dataVehiculo.TipoDeVehiculo = "Auto";
                dataVehiculo.CapacidadDeAlojamiento = numRandom.Next(1, 6);
                dataVehiculo.Tarifa_Hora = numRandom.Next(50, 100);
                dataVehiculo.Tarifa_Dia = numRandom.Next(100, 200);
                dataVehiculo.Tarifa_Semana = numRandom.Next(200, 300);
                dataVehiculo.Tarifa_Mes = numRandom.Next(300, 1000);


                Model.DataVehiculoAlojado dataVehiculo1 = new Model.DataVehiculoAlojado();
                dataVehiculo1.TipoDeVehiculo = "Moto";
                dataVehiculo1.CapacidadDeAlojamiento = numRandom.Next(1, 6);
                dataVehiculo1.Tarifa_Hora = numRandom.Next(50, 100);
                dataVehiculo1.Tarifa_Dia = numRandom.Next(100, 200);
                dataVehiculo1.Tarifa_Semana = numRandom.Next(200, 300);
                dataVehiculo1.Tarifa_Mes = numRandom.Next(300, 1000);


                Model.DataVehiculoAlojado dataVehiculo3 = new Model.DataVehiculoAlojado();
                dataVehiculo3.TipoDeVehiculo = "Camioneta";
                dataVehiculo3.CapacidadDeAlojamiento = numRandom.Next(1, 6);
                dataVehiculo3.Tarifa_Hora = numRandom.Next(50, 100);
                dataVehiculo3.Tarifa_Dia = numRandom.Next(100, 200);
                dataVehiculo3.Tarifa_Semana = numRandom.Next(200, 300);
                dataVehiculo3.Tarifa_Mes = numRandom.Next(300, 1000);

                int v = numRandom.Next(1, 4);

                switch (v)
                {
                    case 1:
                        estacionamiento.TiposDeVehiculosAdmitidos.Add(dataVehiculo);
                        estacionamiento.TiposDeVehiculosAdmitidos.Add(dataVehiculo1);
                        estacionamiento.TiposDeVehiculosAdmitidos.Add(dataVehiculo3);
                        break;
                    case 2:
                        estacionamiento.TiposDeVehiculosAdmitidos.Add(dataVehiculo1);
                        estacionamiento.TiposDeVehiculosAdmitidos.Add(dataVehiculo3);
                        break;
                    case 3:
                        estacionamiento.TiposDeVehiculosAdmitidos.Add(dataVehiculo);
                        estacionamiento.TiposDeVehiculosAdmitidos.Add(dataVehiculo3);
                        break;
                    case 4:
                        estacionamiento.TiposDeVehiculosAdmitidos.Add(dataVehiculo);
                        estacionamiento.TiposDeVehiculosAdmitidos.Add(dataVehiculo1);
                        break;
                    case 5:
                        estacionamiento.TiposDeVehiculosAdmitidos.Add(dataVehiculo1);
                        break;
                }

                estacionamiento.MontoReserva = numRandom.Next(100, 150); // MONTO DE LA RESERVA

                await estacionamientoServiceWebApi.Add(estacionamiento);

                Console.WriteLine("Agregado Ok");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        static async Task Agregar(Estacionamiento _estacionamiento)
        {
            try
            {
               
                Console.WriteLine("GetAccess");
                //var webapiaccess = await WebApiAccess.GetAccessAsync(Uri, "EasyParkingAdmin", "easyparking123");
                var webapiaccess = await WebApiAccess.GetAccessAsync(Uri, "debranahir@gmail.com", "debra1234", 3, 60);
                EstacionamientoServiceWebApi estacionamientoServiceWebApi = new EstacionamientoServiceWebApi(webapiaccess);

                Console.WriteLine("Preparando Estacionamiento");


                Estacionamiento estacionamiento = new Estacionamiento();

                Random numRandom = new Random();


                estacionamiento.Ciudad = _estacionamiento.Ciudad;
                estacionamiento.Imagen = Tools.GetBytesFromUrl("https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/drivers-loft-1-1643441566.jpg?resize=480:*");// // IMAGEN DEL LUGAR
                estacionamiento.Nombre = _estacionamiento.Nombre;// // NOMBRE DEL LUGAR
                estacionamiento.Direccion = $"Calle {numRandom.Next(1, 999)}";// // DIRECCION DEL LUGAR
                estacionamiento.TipoDeLugar = _estacionamiento.TipoDeLugar; // // TIPO DEL LUGAR
                                                                             // LOS RANGO HORARIOS YA SE CARGARON ANTES EN EL EVENTO --> btnEditarHorario_Clicked

                List<RangoH> lista = new List<RangoH>();
                RangoH r = new RangoH();
                r.DesdeHora = numRandom.Next(6, 10);
                r.DesdeMinuto = 0;
                r.HastaHora = numRandom.Next(15, 22);
                r.HastaMinuto = 30;
                lista.Add(r);

                Jornada jornada = new Jornada();
                jornada.Horarios = lista;

                switch (numRandom.Next(1, 7))
                {
                    case 1:
                        jornada.DiaDeLaSemana = Model.Enums.Dia.LUNES;
                        break;
                    case 2:
                        jornada.DiaDeLaSemana = Model.Enums.Dia.MARTES;
                        break;
                    case 3:
                        jornada.DiaDeLaSemana = Model.Enums.Dia.MIERCOLES;
                        break;
                    case 4:
                        jornada.DiaDeLaSemana = Model.Enums.Dia.JUEVES;
                        break;
                    case 5:
                        jornada.DiaDeLaSemana = Model.Enums.Dia.VIERNES;
                        break;
                    case 6:
                        jornada.DiaDeLaSemana = Model.Enums.Dia.SABADO;
                        break;
                    case 7:
                        jornada.DiaDeLaSemana = Model.Enums.Dia.DOMINGO;
                        break;
                }

                estacionamiento.Jornadas.Add(jornada);



                //********** TEMA VEHICULOS ACEPTADOS Y SUS TARIFAS **********//

                Model.DataVehiculoAlojado dataVehiculo = new Model.DataVehiculoAlojado();
                dataVehiculo.TipoDeVehiculo = "Auto";
                dataVehiculo.CapacidadDeAlojamiento = numRandom.Next(1, 6);
                dataVehiculo.Tarifa_Hora = numRandom.Next(50, 100);
                dataVehiculo.Tarifa_Dia = numRandom.Next(100, 200);
                dataVehiculo.Tarifa_Semana = numRandom.Next(200, 300);
                dataVehiculo.Tarifa_Mes = numRandom.Next(300, 1000);


                Model.DataVehiculoAlojado dataVehiculo1 = new Model.DataVehiculoAlojado();
                dataVehiculo1.TipoDeVehiculo = "Moto";
                dataVehiculo1.CapacidadDeAlojamiento = numRandom.Next(1, 6);
                dataVehiculo1.Tarifa_Hora = numRandom.Next(50, 100);
                dataVehiculo1.Tarifa_Dia = numRandom.Next(100, 200);
                dataVehiculo1.Tarifa_Semana = numRandom.Next(200, 300);
                dataVehiculo1.Tarifa_Mes = numRandom.Next(300, 1000);


                Model.DataVehiculoAlojado dataVehiculo3 = new Model.DataVehiculoAlojado();
                dataVehiculo3.TipoDeVehiculo = "Camioneta";
                dataVehiculo3.CapacidadDeAlojamiento = numRandom.Next(1, 6);
                dataVehiculo3.Tarifa_Hora = numRandom.Next(50, 100);
                dataVehiculo3.Tarifa_Dia = numRandom.Next(100, 200);
                dataVehiculo3.Tarifa_Semana = numRandom.Next(200, 300);
                dataVehiculo3.Tarifa_Mes = numRandom.Next(300, 1000);

                int v = numRandom.Next(1, 4);

                switch (v)
                {
                    case 1:
                        estacionamiento.TiposDeVehiculosAdmitidos.Add(dataVehiculo);
                        estacionamiento.TiposDeVehiculosAdmitidos.Add(dataVehiculo1);
                        estacionamiento.TiposDeVehiculosAdmitidos.Add(dataVehiculo3);
                        break;
                    case 2:
                        estacionamiento.TiposDeVehiculosAdmitidos.Add(dataVehiculo1);
                        estacionamiento.TiposDeVehiculosAdmitidos.Add(dataVehiculo3);
                        break;
                    case 3:
                        estacionamiento.TiposDeVehiculosAdmitidos.Add(dataVehiculo);
                        estacionamiento.TiposDeVehiculosAdmitidos.Add(dataVehiculo3);
                        break;
                    case 4:
                        estacionamiento.TiposDeVehiculosAdmitidos.Add(dataVehiculo);
                        estacionamiento.TiposDeVehiculosAdmitidos.Add(dataVehiculo1);
                        break;
                    case 5:
                        estacionamiento.TiposDeVehiculosAdmitidos.Add(dataVehiculo1);
                        break;
                }

                estacionamiento.MontoReserva = numRandom.Next(100, 150); // MONTO DE LA RESERVA

                await estacionamientoServiceWebApi.Add(estacionamiento);

                Console.WriteLine("Agregado Ok");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        static async Task GetAllEstacionamientos()
        {
            try
            {
                Console.WriteLine("GetAccess");

                var webapiaccess = WebApiAccess.GetAccessAsync("http://40.118.242.96:12595", "EasyParkingAdmin", "easyparking123").Result;
                EstacionamientoServiceWebApi estacionamientoServiceWebApi = new EstacionamientoServiceWebApi(webapiaccess);

                Console.WriteLine("Consultando Estacionamiento");

                var list = await estacionamientoServiceWebApi.GetAll();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
