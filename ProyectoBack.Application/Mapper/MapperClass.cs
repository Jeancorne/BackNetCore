using AutoMapper;
using ProyectoBack.Application.DTOs.v1.InventarioDTO;
using ProyectoBack.Application.DTOs.v1.POST;
using ProyectoBack.Application.DTOs.v1.productoDTO;
using ProyectoBack.Application.DTOs.v1.usuarioDTO;
using ProyectoBack.Core.Entities.v1;

namespace ProyectoBack.Application.Mapper
{
    public class MapperClass : Profile
    {
        public MapperClass()
        {
            //==============================================  
            //============================== Usuario
            //==============================================
            this.CreateMap<clsUsuariosDTO, clsUsuario>();
            this.CreateMap<clsUsuariosGetDTO, clsUsuario>();
            this.CreateMap<clsUsuario, clsUsuariosGetDTO>();
            this.CreateMap<clsUsuario, clsUsuariosPutDTO>();
            this.CreateMap<clsUsuariosPutDTO, clsUsuario>();
            //==============================================  
            //============================== Productos
            //==============================================
            this.CreateMap<clsProductoDTO, clsProducto>();
            //==============================================  
            //============================== Inventario
            //==============================================
            this.CreateMap<clsInventariocrearDTO, clsInventario>();
            this.CreateMap<clsInventarioactualizarDTO, clsInventario>();
            this.CreateMap<clsInventarioactualizarDTO, clsInventario>();
            this.CreateMap<clsInventario, clsInventarioactualizarDTO>();



        }
    }
}
