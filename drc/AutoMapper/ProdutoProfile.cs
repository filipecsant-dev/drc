using AutoMapper;
using Dominio.Entidade;
using drc.Models;

namespace drc.AutoMapper
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produto, ProdutoVM>();
            CreateMap<ProdutoVM, Produto>();
        }
    }
}
