using AutoMapper;
using System.Collections.Generic;

namespace EF_Repo.Utils.MapperBase
{
    public static class MapperConfigurationCentral<T, T1>
        where T : class, new()
        where T1 : class, new()
    {

        private static MapperConfiguration configMap;

        public static IMapper Mapper()
        {
            configMap = new MapperConfiguration(cfg => cfg.CreateMap<T, T1>());
            return configMap.CreateMapper();
        }

        public static IReadOnlyList<T1> MapList(IReadOnlyList<T> obj)
        {
            return Mapper().Map<IReadOnlyList<T>, IReadOnlyList<T1>>(obj);
        }

        public static T1 MapEntity(T obj)
        {
            return Mapper().Map<T1>(obj);
        }



    }
}
