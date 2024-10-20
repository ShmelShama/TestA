using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAssignment.Domain.Entities;
using AutoMapper;
using TestAssignment.AppCore.DTO.RequestDTO;
using TestAssignment.AppCore.DTO.ResponseDTO;

namespace TestAssignment.DAL.MapProfile
{
    public class ProductProfile:Profile
    {
        public ProductProfile() 
        {
            CreateMap<Product, ProductResponse>();
            CreateMap<ProductResponse, Product>();
            CreateMap<Product, ProductRequest>();
            CreateMap<ProductRequest, Product>();
        }
    }
}
