using AutoMapper;
using System.Collections.Generic;
using AutoMapper.Configuration;

namespace EF_Repo.Utils.MapperBase
{
    public static class MapperConfigurationCentral<T, T1>
        where T : class, new()
        where T1 : class, new()
    {
        public static IMapper Mapper()
        {
            MapperConfiguration configMap;
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

        public static IMapper Mapper(MapperConfiguration conf)
        {
            MapperConfiguration configMap;
            configMap = conf;
            return configMap.CreateMapper();
        }

        public static T1 MapEntity(T obj, MapperConfiguration conf)
        {
            return Mapper(conf).Map<T1>(obj);
        }

        public static IReadOnlyList<T1> MapList(IReadOnlyList<T> obj, MapperConfiguration conf)
        {
            return Mapper(conf).Map<IReadOnlyList<T>, IReadOnlyList<T1>>(obj);
        }
    }
}
