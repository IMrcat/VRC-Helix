using System;
using System.Runtime.CompilerServices;
using Exploits;
using ReMod.Core.Managers;
using ReMod.Core.UI.QuickMenu;
using UnityEngine;

namespace MenuZone
{
	// Token: 0x02000019 RID: 25
	[NullableContext(1)]
	[Nullable(0)]
	internal class BlackcatMenu
	{
		// Token: 0x06000075 RID: 117 RVA: 0x00004F50 File Offset: 0x00003150
		public static void Create(Sprite MenuIcon, Sprite ButtonIcon, ref UiManager Manager)
		{
			UiManager helixLiteModule = MenuManager.HelixLiteModule;
			ReMenuCategory reMenuCategory = Manager.QMMenu.AddCategoryPage("l Blackcat l", "", MenuIcon, "#ffffff").AddCategory("Empty For Now");
			reMenuCategory.AddButton("Update skin stuff", "Update skin stuff", delegate
			{
				BlackCatDecorShit.Menu.Update();
			}, null, "#ffffff");
			BlackcatMenu.GoosePage = reMenuCategory.AddCategoryPage("Goose Skins", "", null, "#ffffff");
			BlackcatMenu.DecorPage = reMenuCategory.AddCategoryPage("Decor", "", null, "#ffffff");
			BlackcatMenu.FlairPage = reMenuCategory.AddCategoryPage("Flairs", "", null, "#ffffff");
		}

		// Token: 0x04000053 RID: 83
		public static ReCategoryPage DecorPage;

		// Token: 0x04000054 RID: 84
		public static ReCategoryPage GoosePage;

		// Token: 0x04000055 RID: 85
		public static ReCategoryPage FlairPage;
	}
}
