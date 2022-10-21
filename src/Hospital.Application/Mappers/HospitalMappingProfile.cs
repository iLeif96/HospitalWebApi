using AutoMapper;

using Hospital.Application.DTO;
using Hospital.Application.Mappers.Converters;
using Hospital.Domain.Entities;

namespace Hospital.Application.Mappers
{
    public class HospitalMappingProfile : Profile
    {
        public HospitalMappingProfile()
        {
            //Doctors

            CreateMap<Doctor, DoctorDto>()
                .ForMember(dest => dest.OfficeId, opt => opt.MapFrom(src => src.Office.Id))
                .ForMember(dest => dest.DistrictId, opt => opt.MapFrom<long?>(src => src.District != null ? src.District.Id : null))
                .ForMember(dest => dest.SpecializationId, opt => opt.MapFrom(src => src.Specialization.Id)).ReverseMap();

            CreateMap<DoctorDto, Doctor>()
                .ForMember(dest => dest.Office, opt => opt.ConvertUsing<IdToEntityConverter<Office>, long?>(src => src.OfficeId))
                .ForMember(dest => dest.District, opt => opt.ConvertUsing<IdToEntityConverter<District>, long?>(src => src.DistrictId))
                .ForMember(dest => dest.Specialization, opt => opt.ConvertUsing<IdToEntityConverter<Specialization>, long?>(src => src.SpecializationId));

            CreateMap<Doctor, DoctorPageDto>()
                .ForMember(dest => dest.Office, opt => opt.MapFrom(src => src.Office.Number))
                .ForMember(dest => dest.District, opt => opt.MapFrom<int?>(src => src.District != null ? src.District.Number : null))
                .ForMember(dest => dest.Specialization, opt => opt.MapFrom(src => src.Specialization.Name));

            //Patients

            CreateMap<Patient, PatientDto>()
                .ForMember(dest => dest.DistrictId, opt => opt.MapFrom(src => src.District.Id));

            CreateMap<PatientDto, Patient>()
                .ForMember(dest => dest.District, opt => opt.ConvertUsing<IdToEntityConverter<District>, long?>(src => src.DistrictId));

            CreateMap<Patient, PatientPageDto>()
                .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.District.Number));
        }
    }
}
