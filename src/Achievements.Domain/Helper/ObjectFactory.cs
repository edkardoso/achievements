using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Achievements.Domain.Helper
{
    public class ObjectFactory<T>
    {
        private readonly Dictionary<string, Type> _reportMap = new Dictionary<string, Type>();

        public ObjectFactory()
        {
            var types = Assembly.GetAssembly(typeof(T)).GetTypes();
            foreach (var type in types.Where(type => typeof(T).IsAssignableFrom(type) && type != typeof(T)))
                _reportMap.Add(type.Name, type);
        }

        public T CreateObject(string name, params object[] args)
        {
            return (T)Activator.CreateInstance(_reportMap[name], args);
        }
    }
}