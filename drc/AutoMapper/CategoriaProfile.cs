using AutoMapper;
using Dominio.Entidade;
using drc.Models;

namespace drc.AutoMapper
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, CategoriaVM>();
            CreateMap<CategoriaVM, Categoria>();
        }
    }
}
