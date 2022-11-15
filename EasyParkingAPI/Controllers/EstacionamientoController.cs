using EasyParkingAPI.Data;
using EasyParkingAPI.Model;
using EasyParkingAPI.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyParkingAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EstacionamientoController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _UserId;
        private readonly UserManager<ApplicationUser> _userManager;

        public EstacionamientoController(IConfiguration configuration,
                                            IHttpContextAccessor httpContextAccessor,
                                            UserManager<ApplicationUser> userManager)
        {
            try
            {
                _configuration = configuration;
                _userManager = userManager;
                HttpContext http = httpContextAccessor.HttpContext;
                var user = http.User;
              
                ApplicationUser appuser = _userManager.FindByNameAsync(user.Identity.Name).Result; // Obtengo los datos del usuario logeado

                _UserId = appuser.Id; // Obtengo el ID del usuario logeado

                if (String.IsNullOrEmpty(_UserId) | String.IsNullOrWhiteSpace(_UserId))
                {
                    throw new Exception("ERROR ... Usuario sin permisos necesarios.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Estacionamiento>>> GetAllAsync()
        {
            try
            {
                DataContext dataContext = new DataContext();
                var lista = await dataContext.Estacionamientos.AsNoTracking().ToListAsync();
                if (lista == null)
                {
                    return NotFound();
                }
                return lista;

            }
            catch (Exception e)
            {

                return BadRequest(Tools.ExceptionMessage(e));
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Estacionamiento>>> GetAllIncludeAsync()
        {
            try
            {
                DataContext dataContext = new DataContext();
                var estacionamientos = await dataContext.Estacionamientos.Include("Jornadas.Horarios")
                .Include("TiposDeVehiculosAdmitidos").Where(x=>x.Inactivo == false && x.PublicacionPausada == false).AsNoTracking().ToListAsync();
                 
                if (estacionamientos == null)
                {
                    return NotFound();
                }
                return estacionamientos;

            }
            catch (Exception e)
            {

                return BadRequest(Tools.ExceptionMessage(e));
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Estacionamiento>>> GetMisEstacionamientosAsync()
        {
            try
            {
                DataContext dataContext = new DataContext();
                var lista = await dataContext.Estacionamientos.Include("Jornadas.Horarios")
                .Include("TiposDeVehiculosAdmitidos").Where(x=> x.UserId == _UserId && x.Inactivo == false).AsNoTracking().ToListAsync(); // Retorna los estacionamientos de la persona logeada
                if (lista == null)
                {
                    return NotFound();
                }
                return lista;

            }
            catch (Exception e)
            {

                return BadRequest(Tools.ExceptionMessage(e));
            }
        }
        /// <summary>
        /// ///////////////// EJEMPLOS 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Estacionamiento>>> GetGenerico()
        {
            try
            {   //Inactivo-
                DataContext dataContext = new DataContext(); //

                //var qweryResult = qweryActivoInactivo(true).Intersect(qweryUsuario(_UserId)); // Hasta aca, solo se prepara el qwery
                var qweryResult = qweryActivoInactivo(true).Intersect(qweryUsuario(_UserId)); // Hasta aca, solo se prepara el qwery

                if (qweryResult == null)
                {
                    return NotFound();
                }
                return await qweryResult.AsNoTracking().ToListAsync(); // Aca se hace la busqueda efectivamente

            }
            catch (Exception e)
            {

                return BadRequest(Tools.ExceptionMessage(e));
            }


            IQueryable<Estacionamiento> qweryActivoInactivo(bool Inactivo)
            {
                DataContext dataContext = new DataContext();
                return dataContext.Estacionamientos.Where(x => x.Inactivo == Inactivo);
            }


            IQueryable<Estacionamiento> qweryTipoDeLugar(string TipoDeLugar)
            {
                DataContext dataContext = new DataContext();
                return dataContext.Estacionamientos.Where(x => x.TipoDeLugar == TipoDeLugar);
            }

            IQueryable<Estacionamiento> qweryMontoReservaMayorA(decimal MontoReserva)
            {
                DataContext dataContext = new DataContext();
                return dataContext.Estacionamientos.Where(x => x.MontoReserva >= MontoReserva);
            }

            IQueryable<Estacionamiento> qweryMontoReservaMenorA(decimal MontoReserva)
            {
                DataContext dataContext = new DataContext();
                return dataContext.Estacionamientos.Where(x => x.MontoReserva <= MontoReserva);
            }

            IQueryable<Estacionamiento> qweryCiudad(string Ciudad)
            {
                DataContext dataContext = new DataContext();
                return dataContext.Estacionamientos.Where(x => x.Ciudad == Ciudad);
            }

            IQueryable<Estacionamiento> qweryTipoDeVehiculo(string TipoDeVehiculo)
            {
                DataContext dataContext = new DataContext();
                return dataContext.Estacionamientos.Where(x => x.TiposDeVehiculosAdmitidos.Exists(z => z.TipoDeVehiculo == TipoDeVehiculo));
            }

            IQueryable<Estacionamiento> qweryUsuario(string UserId)
            {
                DataContext dataContext = new DataContext();
                if (UserId == null)
                {
                    return dataContext.Estacionamientos;
                }
                else
                {
                    return dataContext.Estacionamientos.Where(x => x.UserId == UserId);
                }
            }
        }



        /// <summary>
        /// //////////////////////////////
        /// </summary>
        /// <param name="estacionamientoId"></param>
        /// <returns></returns>


        [HttpGet("[action]/{estacionamientoId}")]
        public async Task<ActionResult<Estacionamiento>> GetAsync(int estacionamientoId)
        {
            try
            {
                DataContext dataContext = new DataContext();
                var estacionamiento = await dataContext.Estacionamientos.Include("Jornadas.Horarios")
                  .Include("TiposDeVehiculosAdmitidos").FirstOrDefaultAsync(x => x.Id == estacionamientoId);

                if (estacionamiento == null)
                {
                    return NotFound();
                }
                return estacionamiento;

            }
            catch (Exception e)
            {

                return BadRequest(Tools.ExceptionMessage(e));
            }
        }

        [HttpGet("[action]/{estacionamientoId}")]
        public async Task<ActionResult<List<Estacionamiento>>> GetOrderByReservasAsync()
        {
            try
            {
                DataContext dataContext = new DataContext();
                var estacionamiento = await dataContext.Estacionamientos.Include("Jornadas.Horarios")
                                            .Include("TiposDeVehiculosAdmitidos").OrderBy(x=>x.MontoReserva).ToListAsync();

                if (estacionamiento == null)
                {
                    return NotFound();
                }
                return estacionamiento;

            }
            catch (Exception e)
            {

                return BadRequest(Tools.ExceptionMessage(e));
            }
        }



        [HttpGet]
        [Route("[action]/{text}")]
        public async Task<ActionResult<List<Estacionamiento>>> GetConsultaSimpleAsync(string text) // consulta por nombre o direccion del estacionamiento
        {
            try
            {
                DataContext dataContext = new DataContext();
                var estacionamientos = await dataContext.Estacionamientos.Include("Jornadas.Horarios")
                .Include("TiposDeVehiculosAdmitidos").Where(x => x.Direccion.Contains(text) || x.Nombre.Contains(text)).ToListAsync();

                if (estacionamientos == null)
                {
                    return NotFound();
                }
                return estacionamientos;

            }
            catch (Exception e)
            {

                return BadRequest(Tools.ExceptionMessage(e));
            }
        }

        [HttpGet]
        [Route("[action]/{vehiculo}")]
        public async Task<ActionResult<List<Estacionamiento>>> GetByTiposDeVehiculosAdmitidosAsync(string vehiculo) // consulta por nombre o direccion del estacionamiento
        {
            try
            {
                DataContext dataContext = new DataContext();
                var estacionamientos = await dataContext.Estacionamientos.Include("Jornadas.Horarios")
                .Include("TiposDeVehiculosAdmitidos").ToListAsync();


                if (estacionamientos == null)
                {
                    return NotFound();
                }

                List<Estacionamiento> lista = new List<Estacionamiento>();

                foreach (var item in estacionamientos)
                {
                    foreach (var i in item.TiposDeVehiculosAdmitidos)
                    {
                        if (i.TipoDeVehiculo == vehiculo)
                        {
                            lista.Add(item);
                        }
                    }
                }

                if (lista == null)
                {
                    return NotFound();
                }


                return lista;

            }
            catch (Exception e)
            {

                return BadRequest(Tools.ExceptionMessage(e));
            }
        }

        [HttpGet]
        [Route("[action]/{tipoDeLugar}")]
        public async Task<ActionResult<List<Estacionamiento>>> GetByTiposDeLugarAsync(string tipoDeLugar) // consulta por nombre o direccion del estacionamiento
        {
            try
            {
                DataContext dataContext = new DataContext();
                var estacionamientos = await dataContext.Estacionamientos.Include("Jornadas.Horarios")
                .Include("TiposDeVehiculosAdmitidos").Where(x => x.TipoDeLugar == tipoDeLugar).ToListAsync();


                if (estacionamientos == null)
                {
                    return NotFound();
                }

            
                return estacionamientos;

            }
            catch (Exception e)
            {

                return BadRequest(Tools.ExceptionMessage(e));
            }
        }

        //[HttpGet]
        //[Route("[action]")]
        //public async Task<ActionResult<List<Estacionamiento>>> GetAbiertosAsync()
        //{
        //    try
        //    {
        //        DataContext dataContext = new DataContext();
        //        var estacionamientos = await dataContext.Estacionamientos.Include("Jornadas.Horarios")
        //        .Include("TiposDeVehiculosAdmitidos").Where(x => x.Jornadas.Contains(text) || x.Nombre.Contains(text)).ToListAsync();

        //        if (estacionamientos == null)
        //        {
        //            return NotFound();
        //        }
        //        return estacionamientos;

        //    }
        //    catch (Exception e)
        //    {

        //        return BadRequest(Tools.ExceptionMessage(e));
        //    }
        //}



        [HttpPost]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin, AppUser")]
        public async Task<ActionResult> AddAsync([FromBody] Estacionamiento estacionamiento)
        {
            try
            {
                DataContext dataContext = new DataContext();
                estacionamiento.UserId = _UserId;
                var ExisteUnoConMismoNombre = dataContext.Estacionamientos.Any(x => x.Nombre == estacionamiento.Nombre && x.UserId == _UserId); // De mis estacionamientos
                var ExisteUnoConMismaDireccion = dataContext.Estacionamientos.Any(x => x.Direccion == estacionamiento.Direccion && x.Ciudad == estacionamiento.Ciudad && x.UserId == _UserId);  // De mis estacionamientos
                var ExisteUnoConMismaDireccion_QueNoEsMio = dataContext.Estacionamientos.Any(x => x.Direccion == estacionamiento.Direccion && x.Ciudad == estacionamiento.Ciudad);  // De todos los existentes estacionamientos

                if (ExisteUnoConMismoNombre == false)
                {
                    if (ExisteUnoConMismaDireccion == false)
                    {
                        if (ExisteUnoConMismaDireccion_QueNoEsMio == false)
                        {

                            await dataContext.Estacionamientos.AddAsync(estacionamiento);
                            await dataContext.SaveChangesAsync();
                            return Ok();
                        }
                        else
                        {
                            return BadRequest("Alguien mas ya registro un estacionamiento con la misma dirección y en la misma ciudad. Revise su información");
                        }                        
                    }
                    else
                    {
                        return BadRequest("Usted ya tiene un estacionamiento con la misma dirección y en la misma ciudad.");
                    }               
                }
                else
                {
                    return BadRequest("Usted ya tiene un estacionamiento con el mismo nombre, debe elegir otro diferente.");
                }

                
            }
            catch (Exception e)
            {
                return BadRequest(Tools.ExceptionMessage(e));
            }
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin, AppUser")]
        public async Task<ActionResult> SetActivoAsync([FromBody] int estacionamientoId)
        {
            try
            {
                DataContext dataContext = new DataContext();
                var estacionamiento = dataContext.Estacionamientos.Where(x=>x.Id == estacionamientoId).FirstOrDefault();
                estacionamiento.Inactivo = false;
                dataContext.Estacionamientos.Update(estacionamiento);
                await dataContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(Tools.ExceptionMessage(e));
            }
        }


        [HttpPost]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin, AppUser")]
        public async Task<ActionResult> SetInactivoAsync([FromBody] int estacionamientoId)
        {
            try
            {
                DataContext dataContext = new DataContext();
                var estacionamiento = dataContext.Estacionamientos.Where(x => x.Id == estacionamientoId).FirstOrDefault();
                estacionamiento.Inactivo = true;
                dataContext.Estacionamientos.Update(estacionamiento);
                await dataContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(Tools.ExceptionMessage(e));
            }
        }


        [HttpPost]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin, AppUser")]
        public async Task<ActionResult> SetPublicacionPausadaAsync([FromBody] int estacionamientoId)
        {
            try
            {
                DataContext dataContext = new DataContext();
                var estacionamiento = dataContext.Estacionamientos.Where(x => x.Id == estacionamientoId).FirstOrDefault();
                estacionamiento.PublicacionPausada = true;
                dataContext.Estacionamientos.Update(estacionamiento);
                await dataContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(Tools.ExceptionMessage(e));
            }
        }


        [HttpPost]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin, AppUser")]
        public async Task<ActionResult> SetReanudarPublicacionAsync([FromBody] int estacionamientoId)
        {
            try
            {
                DataContext dataContext = new DataContext();
                var estacionamiento = dataContext.Estacionamientos.Where(x => x.Id == estacionamientoId).FirstOrDefault();
                estacionamiento.PublicacionPausada = false;
                dataContext.Estacionamientos.Update(estacionamiento);
                await dataContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(Tools.ExceptionMessage(e));
            }
        }



        [HttpPost]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin, AppUser")]
        public async Task<ActionResult> UpdateAsync([FromBody] Estacionamiento estacionamiento)
        {
            try
            {
                DataContext dataContext = new DataContext();
                var lista_TipoVehiculosAlojados = dataContext.DataVehiculoAlojados.Where(x=>x.Estacionamiento.UserId == _UserId && x.Estacionamiento.Id == estacionamiento.Id);
             
                foreach (var item in lista_TipoVehiculosAlojados)
                {
                    if (!item.Id.Equals(estacionamiento.TiposDeVehiculosAdmitidos))
                    {
                        dataContext.DataVehiculoAlojados.Remove(item);
                    }
                }
                dataContext.Estacionamientos.Update(estacionamiento);
                await dataContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(Tools.ExceptionMessage(e));
            }
        }

        [HttpDelete("[action]/{estacionamientoId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin, AppUser")]
        public async Task<ActionResult> DeleteAsync(int estacionamientoId)
        {
            try
            {
                DataContext dataContext = new DataContext();
                var estacionamiento = await dataContext.Estacionamientos.FirstOrDefaultAsync(x=> x.Id == estacionamientoId);
                dataContext.Estacionamientos.Remove(estacionamiento);
                await dataContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(Tools.ExceptionMessage(e));
            }
        }






    }
}
