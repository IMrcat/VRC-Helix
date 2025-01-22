using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using Il2CppSystem;
using Il2CppSystem.IO;
using Il2CppSystem.Runtime.Serialization.Formatters.Binary;

namespace Resources.Extensions
{
	// Token: 0x02000010 RID: 16
	[NullableContext(1)]
	[Nullable(0)]
	internal static class SerializationUtils
	{
		// Token: 0x06000052 RID: 82 RVA: 0x00003C1C File Offset: 0x00001E1C
		internal static byte[] ToByteArray(Object obj)
		{
			if (obj == null)
			{
				return null;
			}
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			MemoryStream memoryStream = new MemoryStream();
			binaryFormatter.Serialize(memoryStream, obj);
			return memoryStream.ToArray();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00003C4C File Offset: 0x00001E4C
		internal static byte[] ToByteArray(object obj)
		{
			if (obj == null)
			{
				return null;
			}
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			MemoryStream memoryStream = new MemoryStream();
			binaryFormatter.Serialize(memoryStream, obj);
			return memoryStream.ToArray();
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00003C78 File Offset: 0x00001E78
		internal static T FromByteArray<[Nullable(2)] T>(byte[] data)
		{
			if (data == null)
			{
				return default(T);
			}
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			MemoryStream memoryStream = new MemoryStream(data);
			return (T)((object)binaryFormatter.Deserialize(memoryStream));
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00003CAC File Offset: 0x00001EAC
		internal static T IL2CPPFromByteArray<[Nullable(2)] T>(byte[] data)
		{
			if (data == null)
			{
				return default(T);
			}
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			MemoryStream memoryStream = new MemoryStream(data);
			return (T)((object)binaryFormatter.Deserialize(memoryStream));
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00003CE2 File Offset: 0x00001EE2
		internal static T FromIL2CPPToManaged<[Nullable(2)] T>(Object obj)
		{
			return SerializationUtils.FromByteArray<T>(SerializationUtils.ToByteArray(obj));
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00003CEF File Offset: 0x00001EEF
		internal static T FromManagedToIL2CPP<[Nullable(2)] T>(object obj)
		{
			return SerializationUtils.IL2CPPFromByteArray<T>(SerializationUtils.ToByteArray(obj));
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00003CFC File Offset: 0x00001EFC
		internal static object[] FromIL2CPPArrayToManagedArray(Object[] obj)
		{
			object[] array = new object[obj.Length];
			for (int i = 0; i < obj.Length; i++)
			{
				if (obj[i].GetIl2CppType().Attributes == 8192)
				{
					array[i] = SerializationUtils.FromIL2CPPToManaged<object>(obj[i]);
				}
				else
				{
					array[i] = obj[i];
				}
			}
			return array;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00003D48 File Offset: 0x00001F48
		internal static Object[] FromManagedArrayToIL2CPPArray(object[] obj)
		{
			Object[] array = new Object[obj.Length];
			for (int i = 0; i < obj.Length; i++)
			{
				if (obj[i].GetType().Attributes == TypeAttributes.Serializable)
				{
					array[i] = SerializationUtils.FromManagedToIL2CPP<Object>(obj[i]);
				}
				else
				{
					array[i] = (Object)obj[i];
				}
			}
			return array;
		}
	}
}
