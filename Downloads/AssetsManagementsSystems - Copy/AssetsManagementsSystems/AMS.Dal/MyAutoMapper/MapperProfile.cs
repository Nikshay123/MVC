using AssetsManagementsSystems.DAL;
using AssetsManagementSystems.Api.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AssetsManagementSystems.Api.Hardware;
using AssetsManagementsSystems.Api.Software;

namespace AMS.Dal.MyAutoMapper
{
    public  class MapperProfile:Profile
    {
        public MapperProfile() {

            CreateMap<Book, BookRequest>().ReverseMap();

            CreateMap<Book, BookResponse>().ReverseMap();
            CreateMap<Book, BookUpdateRequest>().ReverseMap();


            CreateMap<Hardware, HardwareRequest>().ReverseMap();

            CreateMap<Hardware, HardwareResponse>().ReverseMap();
            CreateMap<Hardware, HardwareUpdateRequest>().ReverseMap();

            CreateMap<Software, SoftwareRequest>().ReverseMap();

            CreateMap<Software, SoftwareResponse>().ReverseMap();
            CreateMap<Software, SoftwareUpdateRequest>().ReverseMap();

        }
    }
}
