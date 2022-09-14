using AutoMapper;
using Dominio.Entidade;
using drc.Models;

namespace drc.AutoMapper
{
    public class UnidadeMedidaProfile : Profile
    {
        public UnidadeMedidaProfile()
        {
            CreateMap<UnidadeMedida, UnidadeMedidaVM>();
            CreateMap<UnidadeMedidaVM, UnidadeMedida>();
        }
    }
}
