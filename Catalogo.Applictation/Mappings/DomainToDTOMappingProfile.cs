using AutoMapper;
using Catalogo.Applictation.DTOs;
using Catalogo.Domain.Entities;

namespace Catalogo.Applictation.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
        }
    }
}
