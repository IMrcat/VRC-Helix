using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using MelonLoader;
using UnityEngine;
using VRC;

namespace Values
{
	// Token: 0x02000007 RID: 7
	[NullableContext(1)]
	[Nullable(0)]
	internal class others
	{
		// Token: 0x0600000A RID: 10 RVA: 0x0000215F File Offset: 0x0000035F
		internal static List<Player> GetAllPlayers()
		{
			if (PlayerManager.Method_Public_Static_get_PlayerManager_0() != null)
			{
				return PlayerManager.Method_Public_Static_get_PlayerManager_0().field_Private_List_1_Player_0.ToArray().ToList<Player>();
			}
			return null;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002180 File Offset: 0x00000380
		public static string AccountCreated(string joinedDate)
		{
			string text = string.Empty;
			try
			{
				if (string.IsNullOrWhiteSpace(joinedDate))
				{
					return null;
				}
				DateTime dateTime;
				DateTime.TryParseExact(joinedDate.Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);
				DateTime today = DateTime.Today;
				int num = today.Year - dateTime.Year;
				int num2 = today.Month - dateTime.Month;
				int num3 = today.Day - dateTime.Day;
				if (num3 < 0)
				{
					num2--;
					num3 += DateTime.DaysInMonth(today.Year, (today.Month == 1) ? 12 : (today.Month - 1));
				}
				if (num2 < 0)
				{
					num--;
					num2 += 12;
				}
				string text2 = dateTime.ToString("MMM", CultureInfo.InvariantCulture);
				string text3 = ((dateTime.Day % 10 == 1 && dateTime.Day != 11) ? "st" : ((dateTime.Day % 10 == 2 && dateTime.Day != 12) ? "nd" : ((dateTime.Day % 10 == 3 && dateTime.Day != 13) ? "rd" : "th")));
				text = string.Format("{0}{1} {2} {3}", new object[] { dateTime.Day, text3, text2, dateTime.Year });
			}
			catch (Exception ex)
			{
				MelonLogger.Msg(ex);
			}
			return text;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002310 File Offset: 0x00000510
		public static int GetPlayerRank(Player player)
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			foreach (string text in player.field_Private_APIUser_0.tags)
			{
				if (text.Contains("basic"))
				{
					flag = true;
				}
				else if (text.Contains("known"))
				{
					flag2 = true;
				}
				else if (text.Contains("trusted"))
				{
					flag3 = true;
				}
				else if (text.Contains("veteran"))
				{
					flag4 = true;
				}
				else if (text.Contains("troll"))
				{
					flag5 = true;
				}
			}
			if (player.field_Private_APIUser_0.isFriend)
			{
				return 6;
			}
			if (flag5)
			{
				return 5;
			}
			if (flag4)
			{
				return 4;
			}
			if (flag3)
			{
				return 3;
			}
			if (flag2)
			{
				return 2;
			}
			if (flag)
			{
				return 1;
			}
			return -1;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000023D1 File Offset: 0x000005D1
		public static float GetFPS(Player player)
		{
			if (player._playerNet.field_Private_Byte_0 == 0)
			{
				return -1f;
			}
			return Mathf.Floor(1000f / (float)player._playerNet.field_Private_Byte_0);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002400 File Offset: 0x00000600
		public static string ColourFPS(Player player)
		{
			float num = ((player._playerNet.field_Private_Byte_0 != 0) ? Mathf.Floor(1000f / (float)player._playerNet.field_Private_Byte_0) : (-1f));
			string text;
			if (num > 55f)
			{
				text = "<color=green>";
			}
			else if (num <= 55f && num > 18f)
			{
				text = "<color=yellow>";
			}
			else if (num <= 18f && num > 5f)
			{
				text = "<color=orange>";
			}
			else
			{
				text = "<color=red>";
			}
			return text + num.ToString() + "</color>";
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002497 File Offset: 0x00000697
		public static float GetPing(Player player)
		{
			return (float)player.Method_Internal_get_PlayerNet_0().Method_Public_get_Int16_0();
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000024A8 File Offset: 0x000006A8
		public static string ColourPing(Player player)
		{
			short num = player.Method_Internal_get_PlayerNet_0().Method_Public_get_Int16_0();
			string text;
			if (num > 250)
			{
				text = "<color=red>";
			}
			else if (num <= 250 && num > 120)
			{
				text = "<color=orange>";
			}
			else if (num <= 120 && num >= 50)
			{
				text = "<color=green>";
			}
			else
			{
				text = "<color=#AAFF00>";
			}
			return text + num.ToString() + "</color>";
		}
	}
}
