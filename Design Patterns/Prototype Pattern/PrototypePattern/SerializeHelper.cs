using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    public class SerializeHelper
    {
        //序列化
        public static string Serializable(object target)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(stream, target);

                return Convert.ToBase64String(stream.ToArray());
            }
        }

        //反列化
        public static T Derializable<T>(string target)
        {
            byte[] targetArray = Convert.FromBase64String(target);

            using (MemoryStream stream = new MemoryStream(targetArray))
            {
                return (T)(new BinaryFormatter().Deserialize(stream));
            }
        }

        //通过序列化反序列话实现对象深克隆
        public static T DeepClone<T>(T t)
        {
            return Derializable<T>(Serializable(t));
        }
    }
}
