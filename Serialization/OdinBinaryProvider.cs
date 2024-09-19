using System;
using System.Collections.Generic;
#if ODIN_INSPECTOR
using Sirenix.Serialization;
#elif ODIN_SERIALIZER
using OdinSerializer;
#endif
using UnityEngine;

namespace LegendaryTools.Persistence
{
    [CreateAssetMenu(menuName = "Tools/Persistence/OdinBinaryProvider", fileName = "OdinBinaryProvider", order = 0)]
    public class OdinBinaryProvider : ScriptableObject, IBinarySerializationProvider
    {
        public string Extension => "odin.bin";
        
        object ISerializationProvider.Serialize(Dictionary<Type, DataTable> dataTable)
        {
            return ((IBinarySerializationProvider)this).Serialize(dataTable);
        }

        public Dictionary<Type, DataTable> Deserialize(object serializedData)
        {
            return Deserialize(serializedData as byte[]);
        }

        public Dictionary<Type, DataTable> Deserialize(byte[] serializedData)
        {
#if ODIN_INSPECTOR || ODIN_SERIALIZER
            if (serializedData.Length == 0) return new Dictionary<Type, DataTable>();
            return SerializationUtility.DeserializeValue<Dictionary<Type, DataTable>>(serializedData, 
                DataFormat.Binary);
#else
            return null;
#endif
        }

        byte[] IBinarySerializationProvider.Serialize(Dictionary<Type, DataTable> dataTable)
        {
#if ODIN_INSPECTOR || ODIN_SERIALIZER
            return SerializationUtility.SerializeValue(dataTable, DataFormat.Binary);
#else
            return null;
#endif
        }
        
#if !ODIN_INSPECTOR && !ODIN_SERIALIZER
        [ContextMenu("ImportOdinSerializer")]
        public void ImportOdinSerializer()
        {
            UnityEditor.PackageManager.Client.Add(
                "https://github.com/LeGustaVinho/odin-serializer.git?path=OdinSerializer");
        }
#endif
    }
}