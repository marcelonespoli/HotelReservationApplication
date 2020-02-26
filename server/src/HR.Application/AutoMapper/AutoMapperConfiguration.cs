﻿using AutoMapper;

namespace HR.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMapping()
        {
            return new MapperConfiguration((options) =>
            {
                options.AddProfile(new DomainToViewModelMappingProfile());
                options.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}
