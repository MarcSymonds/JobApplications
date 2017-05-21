using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

using JobApplications.DTOs;
using JobApplications.Models;
using JobApplications.ViewModels;

namespace JobApplications {
   public class MappingProfile : Profile {
      public MappingProfile() {
         CreateMap<job_application, job_applicationVMList>();
         CreateMap<job_applicationVMList, job_application>().ForMember(d => d.id, opt => opt.Ignore());

         CreateMap<job_application, job_applicationVMEdit>();
         CreateMap<job_applicationDTOBase, job_application>()
            .ForMember(d => d.last_updated, opt => opt.Ignore());

         CreateMap<job_site, job_siteDTO>();
         CreateMap<job_application_activity, job_application_activityDTO>();
         CreateMap<job_application_activity_type, job_application_activity_typeDTO>();

         CreateMap<employment_agency, employment_agencyDTO>();

         CreateMap<employment_agency_contact, employment_agency_contactDTO>();

         CreateMap<latest_job_activity, latest_job_activityDTO>();
      }
   }
}
