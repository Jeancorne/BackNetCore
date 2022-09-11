
using AutoMapper;
using ProyectoBack.Application.DTOs.v1.InventarioDTO;
using ProyectoBack.Application.DTOs.v1.POST;
using ProyectoBack.Application.DTOs.v1.productoDTO;
using ProyectoBack.Application.DTOs.v1.usuarioDTO;
using ProyectoBack.Application.Interfaces.v1;
using ProyectoBack.Core.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoBack.Application.Services.v1
{
    public class Servicio : IServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailServices _email;
        public Servicio(IUnitOfWork unitOfWork, IMapper e, IEmailServices email)
        {
            _mapper = e;
            _unitOfWork = unitOfWork;
            _email = email;
        }

        //==============================================  
        //============================== Usuario
        //==============================================
        public async Task<clsUsuariosGetDTO> actualizarUsuarios(clsUsuariosPutDTO usuarioPut, string tokenUsuario)
        {
            var usuario = await _unitOfWork.clsUsuario.GetById(usuarioPut.id);
            if (usuario == null) throw new Exception("El usuario no existe");
            await validarUsuario(usuarioPut.usuario, "actualizar", usuario.id);
            var nuevoUsuario = _mapper.Map(usuarioPut, usuario);
            nuevoUsuario.modificadoPor = tokenUsuario;
            nuevoUsuario.fechaModificacion = DateTime.Now;
            _unitOfWork.clsUsuario.Update(nuevoUsuario);
            await _unitOfWork.SaveChangesAsync();            
            clsUsuariosGetDTO clsUsuarioDTO = _mapper.Map<clsUsuariosGetDTO>(nuevoUsuario);
            return clsUsuarioDTO;
        }
        public async Task<List<clsUsuariosGetDTO>> obtenerUsuarios()
        {
            var usuarios = _unitOfWork.clsUsuario.GetAll().ToList();
            List<clsUsuariosGetDTO> clsUsuario = _mapper.Map<List<clsUsuariosGetDTO>>(usuarios);
            return clsUsuario;
        }
        public async Task<bool> validarUsuario(string usuario, string tipo = null, int id = 0)
        {
            var usuariosExistentes = _unitOfWork.clsUsuario.GetAll().ToList();
            if (tipo == "actualizar") usuariosExistentes = usuariosExistentes.Where(a => a.id != id).ToList();
            var compararUsuario = usuariosExistentes.Where(a => a.usuario.ToLower().Trim() == usuario.ToLower().Trim()).FirstOrDefault();
            if (compararUsuario != null) throw new Exception("El usuario ya existe");
            return true;
        }
        public async Task<bool> crearUsuario(clsUsuariosDTO usuario)
        {            
            await validarUsuario(usuario.usuario);
            clsUsuario clsUsuario = _mapper.Map<clsUsuario>(usuario);
            clsUsuario.fechaCreacion = DateTime.Now;                        
            await _unitOfWork.clsUsuario.Add(clsUsuario);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        private static string PasswordHash(string password)
        {
            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(password));
            return string.Concat(hash.Select(b => b.ToString("x3")));
        }
        public async Task<clsUsuario> obtenerUsuario(string usuario, string password)
        {

            var usu = await _unitOfWork.IServicioRepository.obtenerUsuarios(usuario);
            if (usu == null) return null;            
            if (usu.password == password)
                return usu;
            return null;
        }
        //==============================================  
        //============================== Producto
        //==============================================
        public async Task<clsProducto> crearProducto(clsProducto producto)
        {
            producto.fechaCreacion = DateTime.Now;
            await _unitOfWork.clsProducto.Add(producto);
            await _unitOfWork.SaveChangesAsync();
            return producto;
        }
        public async Task<clsProducto> actualizarProducto(clsProductoDTO producto, string usuario)
        {
            clsProducto clsProducto = await _unitOfWork.clsProducto.GetById((int)producto.id);
            if (clsProducto == null) throw new Exception("El producto no existe");
            var cantidad = clsProducto.cantidadMinAlerta;
            var product = _mapper.Map(producto, clsProducto);
            product.fechaModificacion = DateTime.Now;
            product.modificadoPor = usuario;
            _unitOfWork.clsProducto.Update(product);
            if (product.cantidadMinAlerta <= cantidad)
            {
                //await _email.EnviarCorreo(correo);
            }
            await _unitOfWork.SaveChangesAsync();
            return product;
        }
        public async Task<List<clsProducto>> obtenerProductos()
        {
            return await _unitOfWork.IServicioRepository.obtenerProductos();
        }
        //==============================================  
        //============================== Inventarios
        //==============================================
        public async Task<clsInventario> crearInventario(clsInventariocrearDTO inventario, string usuario)
        {
            var producto = await _unitOfWork.clsProducto.GetById((int)inventario.idProducto);
            if (producto == null) throw new Exception("El producto no existe");
            clsInventario clsInventario = _mapper.Map<clsInventario>(inventario);
            clsInventario.cantidad = inventario.cantidadEntrada;
            clsInventario.fechaCreacion = DateTime.Now;
            clsInventario.creadoPor = usuario;
            await _unitOfWork.clsInventario.Add(clsInventario);
            await _unitOfWork.SaveChangesAsync();
            return clsInventario;
        }
        public async Task<clsInventario> actualizarInventario(clsInventarioactualizarDTO inventarioDTO, string usuario)
        {
            var producto = await _unitOfWork.IServicioRepository.obtenerUnProductoAsNotTracking((int)inventarioDTO.idProducto);
            var inven = await _unitOfWork.IServicioRepository.obtenerUnInventarioAsNotTracking((int)inventarioDTO.id);
            if (producto == null) throw new Exception("El producto no existe");
            if (inven == null) throw new Exception("El inventario no existe");

            var inventario = _mapper.Map<clsInventario>(inventarioDTO);
            inventario.fechaModificacion = DateTime.Now;
            inventario.modificadoPor = usuario;

            inventario.idProductoNavigation = null;

            _unitOfWork.clsInventario.Update(inventario);
            await _unitOfWork.SaveChangesAsync();
            inventario = await _unitOfWork.IServicioRepository.obtenerUnInventarios(inventario.id);
            return inventario;
        }
        public async Task<List<clsInventario>> obtenerInventario()
        {
            return await _unitOfWork.IServicioRepository.obtenerInventarios();
        }


    }
}
