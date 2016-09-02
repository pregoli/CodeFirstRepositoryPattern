using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Internal;
using EFCodeFirstPaoloTest.Entities;

namespace EFCodeFirstPaoloTest.Services.Mapper
{
    public static class MapperService
    {
        public static TDest Map<TSource, TDest>(TSource viewModel)
        {
            AutoMapper.Mapper.CreateMap<TSource, TDest>();
            var result = AutoMapper.Mapper.Map<TSource, TDest>(viewModel);

            return result;
        }
    }
}
