using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using Il2CppSystem;
using Il2CppSystem.IO;
using Il2CppSystem.Runtime.Serialization.Formatters.Binary;

namespace Resource
{
	// Token: 0x02000008 RID: 8
	[NullableContext(1)]
	[Nullable(0)]
	internal static class SerializationUtils
	{
		// Token: 0x06000012 RID: 18 RVA: 0x00002520 File Offset: 0x00000720
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

		// Token: 0x06000013 RID: 19 RVA: 0x00002550 File Offset: 0x00000750
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

		// Token: 0x06000014 RID: 20 RVA: 0x0000257C File Offset: 0x0000077C
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

		// Token: 0x06000015 RID: 21 RVA: 0x000025B0 File Offset: 0x000007B0
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

		// Token: 0x06000016 RID: 22 RVA: 0x000025E6 File Offset: 0x000007E6
		internal static T FromIL2CPPToManaged<[Nullable(2)] T>(Object obj)
		{
			return SerializationUtils.FromByteArray<T>(SerializationUtils.ToByteArray(obj));
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000025F3 File Offset: 0x000007F3
		internal static T FromManagedToIL2CPP<[Nullable(2)] T>(object obj)
		{
			return SerializationUtils.IL2CPPFromByteArray<T>(SerializationUtils.ToByteArray(obj));
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002600 File Offset: 0x00000800
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

		// Token: 0x06000019 RID: 25 RVA: 0x0000264C File Offset: 0x0000084C
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
