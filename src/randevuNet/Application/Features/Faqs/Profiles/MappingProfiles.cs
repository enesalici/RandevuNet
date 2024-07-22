using Application.Features.Faqs.Commands.Create;
using Application.Features.Faqs.Commands.Delete;
using Application.Features.Faqs.Commands.Update;
using Application.Features.Faqs.Queries.GetById;
using Application.Features.Faqs.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Faqs.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateFaqCommand, Faq>();
        CreateMap<Faq, CreatedFaqResponse>();

        CreateMap<UpdateFaqCommand, Faq>();
        CreateMap<Faq, UpdatedFaqResponse>();

        CreateMap<DeleteFaqCommand, Faq>();
        CreateMap<Faq, DeletedFaqResponse>();

        CreateMap<Faq, GetByIdFaqResponse>();

        CreateMap<Faq, GetListFaqListItemDto>();
        CreateMap<IPaginate<Faq>, GetListResponse<GetListFaqListItemDto>>();
    }
}