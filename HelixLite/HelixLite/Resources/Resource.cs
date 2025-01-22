using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace HelixLite.Resources
{
	// Token: 0x02000027 RID: 39
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	public class Resource
	{
		// Token: 0x060000AD RID: 173 RVA: 0x00007494 File Offset: 0x00005694
		internal Resource()
		{
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x060000AE RID: 174 RVA: 0x0000749C File Offset: 0x0000569C
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceManager ResourceManager
		{
			get
			{
				if (Resource.resourceMan == null)
				{
					Resource.resourceMan = new ResourceManager("HelixLite.Resources.Resource", typeof(Resource).Assembly);
				}
				return Resource.resourceMan;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x060000AF RID: 175 RVA: 0x000074C8 File Offset: 0x000056C8
		// (set) Token: 0x060000B0 RID: 176 RVA: 0x000074CF File Offset: 0x000056CF
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static CultureInfo Culture
		{
			get
			{
				return Resource.resourceCulture;
			}
			set
			{
				Resource.resourceCulture = value;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x000074D7 File Offset: 0x000056D7
		public static string String1
		{
			get
			{
				return Resource.ResourceManager.GetString("String1", Resource.resourceCulture);
			}
		}

		// Token: 0x040000A7 RID: 167
		private static ResourceManager resourceMan;

		// Token: 0x040000A8 RID: 168
		private static CultureInfo resourceCulture;
	}
}
