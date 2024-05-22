using AutoMapper;
using Company.Patients.Application.Commands.Create;
using Company.Patients.Application.Commands.Update;
using Company.Patients.Application.Dto;
using Company.Patients.Domain.Entities;
using Company.Patients.Domain.Types;

namespace Company.Patients.Infrastructure.Mappng
{
  public class AppMappingProfile : Profile
  {
    public AppMappingProfile()
    {

      CreateMap<CreatePatientCommand, PatientEntity>().ReverseMap();
      CreateMap<CreatePatientDetailCommand, PatientDetailEntity>().ReverseMap();
   

      CreateMap<CreatePatientCommand, PatientInfo>()
        .ForPath(dest => dest.GenderType, opts => opts.MapFrom(src => src.GenderType))
        .ForPath(dest => dest.birthDate, opts => opts.MapFrom(src => src.BirthDate))
        .ForPath(dest => dest.active, opts => opts
          .MapFrom(src => src.IsActive ? BooleanType.True : BooleanType.False))
        .ReverseMap();


      CreateMap<CreatePatientDetailCommand, PatientDetailInfo>()
        .ForPath(dest => dest.family, opts => opts.MapFrom(src => src.Family))
        .ForPath(dest => dest.given, opts => opts.MapFrom(src => src.Given))
        .ForPath(dest => dest.use, opts => opts.MapFrom(src => src.Use))
        .ReverseMap();


      CreateMap<PatientEntity, PatientInfo>()
        .ForPath(dest => dest.GenderType, opts => opts.MapFrom(src => src.GenderType))
        .ForPath(dest => dest.birthDate, opts => opts.MapFrom(src => src.BirthDate))
        .ForPath(dest => dest.active, opts => opts.
          MapFrom(src => src.IsActive ? BooleanType.True : BooleanType.False))
        .ReverseMap();

      CreateMap<PatientEntity, PatientFullInfo>()
        .ForPath(dest => dest.GenderType, opts => opts.MapFrom(src => src.GenderType))
        .ForPath(dest => dest.birthDate, opts => opts.MapFrom(src => src.BirthDate))
        .ForPath(dest => dest.active, opts => opts.
          MapFrom(src => src.IsActive ? BooleanType.True : BooleanType.False))
        .ReverseMap();

      CreateMap<PatientDetailEntity, PatientFullDetailInfo>()
        .ForPath(dest => dest.family, opts => opts.MapFrom(src => src.Family))
        .ForPath(dest => dest.given, opts => opts.MapFrom(src => src.Given))
        .ForPath(dest => dest.id, opts => opts.MapFrom(src => src.Id))
        .ForPath(dest => dest.use, opts => opts.MapFrom(src => src.Use))
        .ReverseMap();

      CreateMap<PatientDetailEntity, PatientDetailInfo>()
        .ForPath(dest => dest.family, opts => opts.MapFrom(src => src.Family))
        .ForPath(dest => dest.given, opts => opts.MapFrom(src => src.Given))
        .ForPath(dest => dest.use, opts => opts.MapFrom(src => src.Use))
        .ReverseMap();

      CreateMap<UpdatePatientCommand, PatientEntity>().ReverseMap();
      CreateMap<UpdatePatientDetailCommand, PatientDetailEntity>()
        .ForPath(dest => dest.Id, opts => opts.MapFrom(src => src.Id)).
        ReverseMap();
      

      CreateMap<UpdatePatientCommand, PatientFullInfo>()
        .ForPath(dest => dest.GenderType, opts => opts.MapFrom(src => src.GenderType))
        .ForPath(dest => dest.birthDate, opts => opts.MapFrom(src => src.BirthDate))
        .ForPath(dest => dest.active, opts => opts
          .MapFrom(src => src.IsActive ? BooleanType.True : BooleanType.False))
        .ReverseMap();

      CreateMap<UpdatePatientDetailCommand, PatientFullDetailInfo>()
        .ForPath(dest => dest.family, opts => opts.MapFrom(src => src.Family))
        .ForPath(dest => dest.given, opts => opts.MapFrom(src => src.Given))
        .ForPath(dest => dest.id, opts => opts.MapFrom(src => src.Id))
        .ForPath(dest => dest.use, opts => opts.MapFrom(src => src.Use))
        .ReverseMap();

    

    }

  }
}
