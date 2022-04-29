using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GTechAPI.DTO.ItemDTO;
using GTechAPI.DTO.LoanDTO;
using GTechAPI.DTO.MemberDTO;
using GTechAPI.Entities;

namespace GTechAPI.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Book, BookDTO>()
                .ForMember(dest => dest.IdNavigation, opt => opt.MapFrom(src => src.IdNavigation))
                .ForMember(dest => dest.Isbn13, opt => opt.MapFrom(src => src.Isbn13))
                .ForMember(dest => dest.Ddcs, opt => opt.MapFrom(src => src.Ddcs))
                .ForMember(dest => dest.PublisherId, opt => opt.MapFrom(src => src.PublisherId))
                .ForMember(dest => dest.PageCount, opt => opt.MapFrom(src => src.PageCount))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.Language))
                .ForMember(dest => dest.IdNavigation, opt => opt.MapFrom(src => src.IdNavigation));
                /*.ForMember(dest=>dest.Ddcs,opt=>opt.MapFrom(src=>src.DdcsNavigation.DdcsCode))
                .ForMember(dest=>dest.Language,opt=>opt.MapFrom(src=>src.LanguageNavigation.Language1))
                .ForMember(dest=>dest.PublisherId,opt=>opt.MapFrom(src=>src.Publisher.Name));*/
            CreateMap<BookDTO, Book>()
                .ForMember(dest => dest.IdNavigation, opt => opt.MapFrom(src => src.IdNavigation))
                .ForMember(dest => dest.Isbn13, opt => opt.MapFrom(src => src.Isbn13))
                .ForMember(dest => dest.Ddcs, opt => opt.MapFrom(src => src.Ddcs))
                .ForMember(dest => dest.PublisherId, opt => opt.MapFrom(src => src.PublisherId))
                .ForMember(dest => dest.PageCount, opt => opt.MapFrom(src => src.PageCount))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.Language))
                .ForMember(dest => dest.IdNavigation, opt => opt.MapFrom(src => src.IdNavigation));

            CreateMap<BaseMetadatum, BaseMetadatumDTO>()
                .ForMember(dest=>dest.Type,opt=>opt.MapFrom(src=>src.TypeNavigation.Name));
            CreateMap<BaseMetadatumDTO, BaseMetadatum>();


            CreateMap<Item, ItemDTO>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IsLoanable, opt => opt.MapFrom(src => src.IsLoanable))
                .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => src.Condition))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.ItemMetadata, opt => opt.MapFrom(src => src.ItemMetadata));
                
            CreateMap<ItemDTO,Item>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IsLoanable, opt => opt.MapFrom(src => src.IsLoanable))
                .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => src.Condition))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.ItemMetadata, opt => opt.MapFrom(src => src.ItemMetadata));
            CreateMap<Member, MemberDTO>()
                .ForMember(dest => dest.SSN, opt => opt.MapFrom(src => src.Ssn))
                .ForMember(dest => dest.FName, opt => opt.MapFrom(src => src.FName))
                .ForMember(dest => dest.LName, opt => opt.MapFrom(src => src.LName))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.CampusAddress, opt => opt.MapFrom(src => src.CampusAddress))
                .ForMember(dest => dest.HomeAddress, opt => opt.MapFrom(src => src.HomeAddress))
                .ForMember(dest=>dest.MemberType,opt=>opt.MapFrom(src=>src.MemberType));

            CreateMap<MemberDTO, Member>()
                .ForMember(dest => dest.Ssn, opt => opt.MapFrom(src => src.SSN))
                .ForMember(dest => dest.FName, opt => opt.MapFrom(src => src.FName))
                .ForMember(dest => dest.LName, opt => opt.MapFrom(src => src.LName))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.CampusAddress, opt => opt.MapFrom(src => src.CampusAddress))
                .ForMember(dest => dest.HomeAddress, opt => opt.MapFrom(src => src.HomeAddress))
                .ForMember(dest => dest.MemberType, opt => opt.MapFrom(src => src.MemberType));
                /*.ForMember(dest => dest.Cards, opt => opt.Ignore())
                .ForMember(dest => dest.Loans, opt => opt.Ignore());*/
            // CreateMap<ItemDTO, Item>();

            /*
                        CreateMap<Item, ItemDTO>()
                           .ForMember(dest => dest.ItemMetadata, opt => opt.MapFrom(src => src.ItemMetadata));*/


            CreateMap<Loan, LoanDTO>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.ItemId))
                .ForMember(dest => dest.MemberSnn, opt => opt.MapFrom(src => src.MemberSnn));

            CreateMap<LoanDTO, Loan>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.ItemId))
                .ForMember(dest => dest.MemberSnn, opt => opt.MapFrom(src => src.MemberSnn));

        }

    }
}
