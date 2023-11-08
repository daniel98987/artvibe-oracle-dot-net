using AutoMapper;
using artvibe_oracle.Data;
using artvibe_oracle.Models.ProductType;
using artvibe_oracle.Models.userModel;

namespace artvibe_oracle.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {

            CreateMap<ProductTypeDate, CreateProductTypeModel>().ReverseMap();
            CreateMap<UserData, RegisterUser>().ReverseMap();

        }
    }
}
