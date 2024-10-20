using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAssignment.AppCore.DTO.RequestDTO;
using TestAssignment.AppCore.DTO.ResponseDTO;
using TestAssignment.Domain.Entities;

namespace TestAssignment.DAL.MapProfile
{
    public class ProductCategoryProfile : Profile
    {
        public ProductCategoryProfile() 
        {
            CreateMap<ProductCategory, ProductCategoryResponse>();
            CreateMap<ProductCategoryResponse, ProductCategory>();
            CreateMap<ProductCategory, ProductCategoryRequest>();
            CreateMap<ProductCategoryRequest, ProductCategory>();
        }
    }
}
