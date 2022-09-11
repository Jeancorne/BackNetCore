using DC_Modelo_Arana_Core.CustomEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProyectoBack.Application.DTOs.v1;
using ProyectoBack.Application.DTOs.v1.InventarioDTO;
using ProyectoBack.Application.DTOs.v1.POST;
using ProyectoBack.Application.DTOs.v1.productoDTO;
using ProyectoBack.Application.DTOs.v1.usuarioDTO;
using ProyectoBack.Application.Helpers;
using ProyectoBack.Application.Interfaces.v1;
using ProyectoBack.Core.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProyectoBack.Controllers.v1
{
    [Produces("application/json")]
    [Route("api/v1/servicio")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicio _services;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        public ServicioController(IServicio a, IConfiguration e, IUnitOfWork t)
        {
            _unitOfWork = t;
            _configuration = e;
            _services = a;
        }
        //=======================================================================
        //=============================================== INVENTARIOS
        //=======================================================================
        ///<summary>
        ///Endpoint crear un Inventario
        ///</summary>
        [HttpPost("crearInventario")]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResult<IActionResult>), StatusCodes.Status200OK)]
        [Authorize(Policy = "crearServicio")]
        public async Task<IActionResult> crearInventario(clsInventariocrearDTO inventario)
        {
            try
            {
                string usuario = User.Claims.FirstOrDefault(x => x.Type == "usuario").Value;                
                var data = await _services.crearInventario(inventario, usuario);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }
        ///<summary>
        ///Endpoint actualizar un Inventario
        ///</summary>
        [HttpPut("actualizarInventario")]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResult<IActionResult>), StatusCodes.Status200OK)]
        [Authorize(Policy = "actualizarServicio")]
        public async Task<IActionResult> actualizarInventario(clsInventarioactualizarDTO inventario)
        {
            try
            {
                string usuario = User.Claims.FirstOrDefault(x => x.Type == "usuario").Value;
                var data = await _services.actualizarInventario(inventario, usuario);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }
        ///<summary>
        ///Endpoint obtener Inventarios
        ///</summary>
        [HttpGet("obtenerInventarios")]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResult<IActionResult>), StatusCodes.Status200OK)]
        [Authorize(Policy = "obtenerServicio")]
        public async Task<IActionResult> obtenerInventarios()
        {
            try
            {                
                var data = await _services.obtenerInventario();
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }
        //=======================================================================
        //=============================================== PRODUCTOS
        //=======================================================================
        ///<summary>
        ///Endpoint obtener productos
        ///</summary>
        [HttpGet("obtenerProductos")]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResult<List<clsProducto>>), StatusCodes.Status200OK)]
        [Authorize(Policy = "obtenerServicio")]
        public async Task<IActionResult> crearProducto()
        {
            try
            { 
                var data = await _services.obtenerProductos();
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }
        ///<summary>
        ///Endpoint crear un producto
        ///</summary>
        [HttpPost("crearProducto")]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResult<IActionResult>), StatusCodes.Status200OK)]
        [Authorize(Policy = "crearServicio")]
        public async Task<IActionResult> crearProducto(clsProducto producto)
        {
            try
            {
                string usuario = User.Claims.FirstOrDefault(x => x.Type == "usuario").Value;
                producto.creadoPor = usuario;
                var data = await _services.crearProducto(producto);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }

        ///<summary>
        ///Endpoint actualizar un producto
        ///</summary>
        [HttpPut("actualizarProducto")]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResult<IActionResult>), StatusCodes.Status200OK)]
        [Authorize(Policy = "actualizarServicio")]
        public async Task<IActionResult> actualizarProducto(clsProductoDTO producto)
        {
            try
            {
                string usuario = User.Claims.FirstOrDefault(x => x.Type == "usuario").Value;                
                var data = await _services.actualizarProducto(producto, usuario);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }

        //=======================================================================
        //=============================================== USUARIOS
        //=======================================================================
        ///<summary>
        ///Endpoint obtener usuarios
        ///</summary>
        [HttpPut("actualizarUsuario")]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResult<IActionResult>), StatusCodes.Status200OK)]
        [Authorize(Policy = "actualizarServicio")]
        public async Task<IActionResult> actualizarUsuario(clsUsuariosPutDTO usuario)
        {
            try
            {
                string tokenUsuario = User.Claims.FirstOrDefault(x => x.Type == "usuario").Value;
                var data = await _services.actualizarUsuarios(usuario, tokenUsuario);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }

        ///<summary>
        ///Endpoint obtener usuarios
        ///</summary>
        [HttpGet("obtenerUsuarios")]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResult<IActionResult>), StatusCodes.Status200OK)]
        [Authorize(Policy = "obtenerServicio")]
        public async Task<IActionResult> crearPersona()
        {
            try
            {
                var data = await _services.obtenerUsuarios();
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }

        ///<summary>
        ///Endpoint crear una usuario
        ///</summary>
        [HttpPost("crearUsuario")]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResult<IActionResult>), StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<IActionResult> crearPersona(clsUsuariosDTO usuario)
        {
            try
            {
                var data = await _services.crearUsuario(usuario);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }
        ///<summary>
        ///Endpoint Login al sistema
        ///</summary>
        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResult<IActionResult>), StatusCodes.Status200OK)]
        public async Task<IActionResult> obtenerEmpleados([FromBody] LoginModelDTO login)
        {
            try
            {
                var data = await _services.obtenerUsuario(login.usuario, login.password);
                if (data != null)
                {
                    if (data.activo == false) throw new Exception("El usuario se encuentra inactivo");
                    string secret = _configuration.GetValue<string>("KeySecret");
                    var jwtHelper = new JWT(secret);
                    List<string> listaToken = new List<string>() { "crearServicio", "obtenerServicio", "actualizarServicio", "eliminarServicio" };

                    var token = jwtHelper.crearToken(data, listaToken);
                    return Ok(new
                    {
                        ok = true,
                        mensaje = "logeado",
                        token = token
                    });
                }
                else
                {
                    throw new Exception("Usuario o contraseña incorrecto");                    
                }
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }
       


    }
}
