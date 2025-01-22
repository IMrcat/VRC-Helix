using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Il2CppSystem.Collections.Generic;
using ReMod.Core;
using TMPro;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using VRC.UI.Elements;
using VRC.UI.Elements.Menus;

namespace Resources.Extensions
{
	// Token: 0x0200000F RID: 15
	[NullableContext(1)]
	[Nullable(0)]
	public static class PlayerExtensions
	{
		// Token: 0x0600003C RID: 60 RVA: 0x000038D8 File Offset: 0x00001AD8
		public static Player GetSelectedPlayer()
		{
			IEnumerable<Player> enumerable = PlayerManager.Method_Public_Static_get_PlayerManager_0().field_Private_List_1_Player_0.ToSysList<Player>();
			string displayName2 = PlayerExtensions.QuickMenuInstance.transform.Find("CanvasGroup/Container/Window/QMParent/Menu_SelectedUser_Local/ScrollRect/Viewport/VerticalLayoutGroup/UserProfile_Compact/PanelBG/Info/Text_Username_NonFriend").GetComponent<TextMeshProUGUI>().text;
			return enumerable.FirstOrDefault((Player x) => x.field_Private_APIUser_0.displayName == displayName2);
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600003D RID: 61 RVA: 0x0000392F File Offset: 0x00001B2F
		public static QuickMenu QuickMenuInstance
		{
			get
			{
				if (PlayerExtensions._quickMenu == null)
				{
					PlayerExtensions._quickMenu = Object.FindObjectsOfType<QuickMenu>()[0];
				}
				return PlayerExtensions._quickMenu;
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00003954 File Offset: 0x00001B54
		public static List<T> ToSysList<[Nullable(2)] T>(this List<T> il2List)
		{
			List<T> list = new List<T>();
			foreach (T t in il2List)
			{
				list.Add(t);
			}
			return list;
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00003988 File Offset: 0x00001B88
		private static MethodInfo LoadAvatarMethod
		{
			get
			{
				if (PlayerExtensions._reloadAvatarMethod == null)
				{
					PlayerExtensions._reloadAvatarMethod = typeof(VRCPlayer).GetMethods().First(delegate(MethodInfo mi)
					{
						if (mi.Name.StartsWith("Method_Private_Void_Boolean_") && mi.Name.Length < 31)
						{
							if (mi.GetParameters().Any((ParameterInfo pi) => pi.IsOptional))
							{
								return XrefUtils.CheckUsedBy(mi, "ReloadAvatarNetworkedRPC", null);
							}
						}
						return false;
					});
				}
				return PlayerExtensions._reloadAvatarMethod;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000040 RID: 64 RVA: 0x000039E0 File Offset: 0x00001BE0
		private static MethodInfo ReloadAllAvatarsMethod
		{
			get
			{
				if (PlayerExtensions._reloadAllAvatarsMethod == null)
				{
					PlayerExtensions._reloadAllAvatarsMethod = typeof(VRCPlayer).GetMethods().First(delegate(MethodInfo mi)
					{
						if (mi.Name.StartsWith("Method_Public_Void_Boolean_") && mi.Name.Length < 30)
						{
							if (mi.GetParameters().All((ParameterInfo pi) => pi.IsOptional))
							{
								return XrefUtils.CheckUsedBy(mi, "Method_Public_Void_", typeof(FeaturePermissionManager));
							}
						}
						return false;
					});
				}
				return PlayerExtensions._reloadAllAvatarsMethod;
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00003A38 File Offset: 0x00001C38
		public static Player GetPlayer(this string UserID)
		{
			foreach (Player player in PlayerManager.Method_Public_Static_get_PlayerManager_0().field_Private_List_1_Player_0.ToArray().ToList<Player>())
			{
				if (player.field_Private_APIUser_0.id == UserID)
				{
					return player;
				}
			}
			return null;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00003AAC File Offset: 0x00001CAC
		public static SelectedUserMenuQM GetTarget()
		{
			QuickMenu quickMenu = Object.FindObjectsOfType<QuickMenu>().FirstOrDefault<QuickMenu>();
			if (quickMenu != null)
			{
				return quickMenu.field_Private_UIPage_1.GetComponent<SelectedUserMenuQM>();
			}
			return null;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003ADA File Offset: 0x00001CDA
		public static Player GetPlayer(this IUser value)
		{
			return value.Method_Public_Abstract_Virtual_New_get_String_0().GetPlayer();
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00003AE7 File Offset: 0x00001CE7
		public static VRCPlayer GetVRCPlayer(this IUser value)
		{
			return value.GetPlayer()._vrcplayer;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00003AF4 File Offset: 0x00001CF4
		public static APIUser GetAPIUser(this IUser value)
		{
			return value.GetPlayer().Method_Internal_get_APIUser_0();
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00003B01 File Offset: 0x00001D01
		public static ApiAvatar GetApiAvatar(this IUser value)
		{
			return value.GetPlayer().Method_Public_get_ApiAvatar_PDM_0();
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003B0E File Offset: 0x00001D0E
		public static IUser SelectedIUser()
		{
			return PlayerExtensions.GetTarget().field_Private_IUser_0;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00003B1A File Offset: 0x00001D1A
		public static VRCPlayer GetVRCPlayer()
		{
			return PlayerExtensions.GetTarget().field_Private_IUser_0.GetPlayer()._vrcplayer;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003B30 File Offset: 0x00001D30
		public static APIUser GetAPIUser()
		{
			return PlayerExtensions.GetTarget().field_Private_IUser_0.GetPlayer().field_Private_APIUser_0;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00003B46 File Offset: 0x00001D46
		public static ApiAvatar GetApiAvatar()
		{
			return PlayerExtensions.GetTarget().field_Private_IUser_0.GetPlayer().Method_Public_get_ApiAvatar_PDM_0();
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00003B5C File Offset: 0x00001D5C
		public static Player[] GetPlayers(this PlayerManager playerManager)
		{
			return playerManager.field_Private_List_1_Player_0.ToArray();
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00003B6E File Offset: 0x00001D6E
		public static PlayerNet GetPlayerNet(this VRCPlayer vrcPlayer)
		{
			return vrcPlayer._playerNet;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003B76 File Offset: 0x00001D76
		public static GameObject GetAvatarObject(this VRCPlayer vrcPlayer)
		{
			return vrcPlayer.field_Internal_GameObject_0;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00003B7E File Offset: 0x00001D7E
		public static VRCPlayerApi GetPlayerApi(this VRCPlayer vrcPlayer)
		{
			return vrcPlayer.field_Private_VRCPlayerApi_0;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00003B88 File Offset: 0x00001D88
		public static bool IsStaff(this APIUser user)
		{
			return user.hasModerationPowers || user.developerType != null || user.tags.Contains("admin_moderator") || user.tags.Contains("admin_scripting_access") || user.tags.Contains("admin_official_thumbnail");
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00003BDF File Offset: 0x00001DDF
		public static void ReloadAvatar(this VRCPlayer instance)
		{
			PlayerExtensions.LoadAvatarMethod.Invoke(instance, new object[] { true });
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00003BFC File Offset: 0x00001DFC
		public static void ReloadAllAvatars(this VRCPlayer instance, bool ignoreSelf = false)
		{
			PlayerExtensions.ReloadAllAvatarsMethod.Invoke(instance, new object[] { ignoreSelf });
		}

		// Token: 0x0400003F RID: 63
		private static QuickMenu _quickMenu;

		// Token: 0x04000040 RID: 64
		private static MethodInfo _reloadAvatarMethod;

		// Token: 0x04000041 RID: 65
		private static MethodInfo _reloadAllAvatarsMethod;
	}
}
