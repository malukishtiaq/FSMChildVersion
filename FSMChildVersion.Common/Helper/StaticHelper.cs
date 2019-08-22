using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FSMChildVersion.Common.Helpers
{
    public static class StaticHelper
    {
        public static List<string> GetListOfEnumDescription<T>() where T : struct
        {
            Type t = typeof(T);
            return !t.IsEnum ? null : Enum.GetValues(t).Cast<Enum>().Select(x => x.GetDescription()).ToList();
        }
        private static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            var name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attr)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }
    }
}
