using ProyectoBack.Application.DTOs.v1.InventarioDTO;
using ProyectoBack.Application.DTOs.v1.POST;
using ProyectoBack.Application.DTOs.v1.productoDTO;
using ProyectoBack.Application.DTOs.v1.usuarioDTO;
using ProyectoBack.Core.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Application.Interfaces.v1
{
    public interface IServicio
    {
        //==============================================  
        //============================== Usuarios
        //==============================================
        Task<clsUsuariosGetDTO> actualizarUsuarios(clsUsuariosPutDTO usuarioPut, string tokenUsuario);
        Task<List<clsUsuariosGetDTO>> obtenerUsuarios();
        Task<clsUsuario> obtenerUsuario(string usuario, string password);
        Task<bool> crearUsuario(clsUsuariosDTO persona);
        //==============================================  
        //============================== Productos
        //==============================================
        Task<clsProducto> crearProducto(clsProducto producto);
        Task<clsProducto> actualizarProducto(clsProductoDTO producto, string usuario);

        Task<List<clsProducto>> obtenerProductos();

        //==============================================  
        //============================== Inventarios
        //==============================================
        Task<clsInventario> crearInventario(clsInventariocrearDTO inventario, string usuario);
        Task<clsInventario> actualizarInventario(clsInventarioactualizarDTO inventario, string usuario);
        Task<List<clsInventario>> obtenerInventario();


    }
}
