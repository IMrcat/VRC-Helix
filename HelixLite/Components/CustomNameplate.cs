using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MelonLoader;
using TMPro;
using UnityEngine;
using Values;
using VRC;

namespace HelixLiteModule.Components
{
	// Token: 0x02000026 RID: 38
	[NullableContext(1)]
	[Nullable(0)]
	public class CustomNameplate : MonoBehaviour, IDisposable
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x00006E6B File Offset: 0x0000506B
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x00006E73 File Offset: 0x00005073
		public Player Player { get; set; }

		// Token: 0x060000A6 RID: 166 RVA: 0x00006E7C File Offset: 0x0000507C
		public CustomNameplate(IntPtr ptr)
			: base(ptr)
		{
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00006EAC File Offset: 0x000050AC
		public void Dispose()
		{
			if (this._statsText != null)
			{
				this._statsText.text = null;
				this._statsText.OnDisable();
				Object.Destroy(this._statsText.gameObject);
				this._statsText = null;
			}
			base.enabled = false;
			CustomNameplate.nameplates.Remove(this);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00006F08 File Offset: 0x00005108
		private void Start()
		{
			try
			{
				PlayerNameplate field_Public_PlayerNameplate_ = this.Player._vrcplayer.field_Public_PlayerNameplate_0;
				if (field_Public_PlayerNameplate_ != null)
				{
					Transform transform = field_Public_PlayerNameplate_.field_Public_GameObject_5.transform;
					if (transform.Find("Trust Text").GetComponent<TextMeshProUGUI>() != null)
					{
						Transform transform2 = Object.Instantiate<Transform>(transform, transform.parent);
						transform2.localPosition = new Vector3(0f, -75f, 0f);
						transform2.gameObject.SetActive(true);
						this._statsText = transform2.Find("Trust Text").GetComponent<TextMeshProUGUI>();
						if (this._statsText != null)
						{
							this._statsText.color = Color.white;
							this._statsText.isOverlay = this.OverRender && this.Enabled;
						}
						Transform transform3 = transform2.Find("Trust Icon");
						if (transform3 != null)
						{
							transform3.gameObject.SetActive(false);
						}
						Transform transform4 = transform2.Find("Performance Icon");
						if (transform4 != null)
						{
							transform4.gameObject.SetActive(false);
						}
						Transform transform5 = transform2.Find("Performance Text");
						if (transform5 != null)
						{
							transform5.gameObject.SetActive(false);
						}
						Transform transform6 = transform2.Find("Friend Anchor Stats");
						if (transform6 != null)
						{
							transform6.gameObject.SetActive(false);
						}
					}
				}
				this.StartTime = Time.time;
				this.looptime = Time.time;
			}
			catch (Exception ex)
			{
				MelonLogger.Msg(ex.Message);
			}
			switch (others.GetPlayerRank(this.Player))
			{
			case 1:
				this.ranktext = "<color=#6495ED>New User</color>";
				break;
			case 2:
				this.ranktext = "<color=#90EE90>User</color>";
				break;
			case 3:
				this.ranktext = "<color=#ffca5d>Known</color>";
				break;
			case 4:
				this.ranktext = "<color=#d472ff>Trusted</color>";
				break;
			case 5:
				this.ranktext = "<color=#ff7575>Troll</color>";
				break;
			case 6:
				this.ranktext = "<color=#fffd81>Friend</color>";
				break;
			}
			if (this.Player.field_Private_VRCPlayerApi_0.IsUserInVR())
			{
				if (this.Player.Method_Internal_get_APIUser_0().last_platform.ToLower() != "standalonewindows")
				{
					this.platform = "Q";
				}
				else
				{
					this.platform = "VR";
				}
			}
			else if (this.Player.Method_Internal_get_APIUser_0().last_platform.ToLower() != "standalonewindows")
			{
				this.platform = "Android";
			}
			else
			{
				this.platform = "D";
			}
			if (this.Player._vrcplayer._player.field_Private_APIUser_0.id == "usr_34584e51-fb77-49f9-a0e5-b62160556a1f")
			{
				this.IsHelixOwner = true;
			}
			CustomNameplate.nameplates.Add(this, this.Player.field_Private_APIUser_0.id);
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x000071D4 File Offset: 0x000053D4
		private void Update()
		{
			if (this._statsText == null)
			{
				return;
			}
			if (Time.time >= this.looptime + 3f)
			{
				if (string.IsNullOrEmpty(this.FormattedDate))
				{
					this.FormattedDate = others.AccountCreated(this.DateCreated);
				}
				int num = (int)(Time.time - this.StartTime);
				int num2 = num / 3600;
				int num3 = num % 3600 / 60;
				int num4 = num % 60;
				string text;
				if (num2 > 0)
				{
					float num5 = (float)num / 3600f;
					text = string.Format("{0:F1}h", num5);
				}
				else if (num3 > 0)
				{
					text = string.Format("{0}m", num3);
				}
				else
				{
					text = string.Format("{0}s", num4);
				}
				string text2 = this.platform;
				IkController.EnumNPublicSealedvaInNoLiThFoFiSi8vUnique field_Private_EnumNPublicSealedvaInNoLiThFoFiSi8vUnique_ = this.Player._vrcplayer.field_Private_VRCAvatarManager_0.field_Internal_IkController_0.field_Private_EnumNPublicSealedvaInNoLiThFoFiSi8vUnique_0;
				if (field_Private_EnumNPublicSealedvaInNoLiThFoFiSi8vUnique_ == 6 || field_Private_EnumNPublicSealedvaInNoLiThFoFiSi8vUnique_ == 4 || field_Private_EnumNPublicSealedvaInNoLiThFoFiSi8vUnique_ == 5)
				{
					text2 += "+FBT";
				}
				string text3 = null;
				if (this.ishelixuser || this.IsHelixOwner)
				{
					text3 = this.Role + (this.IsHelixOwner ? "<b>HELIX OWNER </b>|" : "HelixUsr |");
				}
				this._statsText.text = string.Concat(new string[]
				{
					this.Role,
					text3,
					" <color=white>",
					text,
					"</color> | ",
					text2,
					" | ",
					this.ranktext,
					" | F:",
					others.ColourFPS(this.Player),
					" | P:",
					others.ColourPing(this.Player),
					" | ",
					this.FormattedDate
				});
				this.looptime = Time.time;
			}
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000073B0 File Offset: 0x000055B0
		public static CustomNameplate FindById(string Id)
		{
			foreach (KeyValuePair<CustomNameplate, string> keyValuePair in CustomNameplate.nameplates)
			{
				if (keyValuePair.Value == Id)
				{
					return keyValuePair.Key;
				}
			}
			return null;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00007418 File Offset: 0x00005618
		public static void PlayerLeft(string Id)
		{
			foreach (KeyValuePair<CustomNameplate, string> keyValuePair in CustomNameplate.nameplates)
			{
				if (keyValuePair.Value == Id)
				{
					CustomNameplate.nameplates.Remove(keyValuePair.Key);
					break;
				}
			}
		}

		// Token: 0x04000099 RID: 153
		private static Dictionary<CustomNameplate, string> nameplates = new Dictionary<CustomNameplate, string>();

		// Token: 0x0400009A RID: 154
		private TextMeshProUGUI _statsText;

		// Token: 0x0400009C RID: 156
		public bool OverRender = true;

		// Token: 0x0400009D RID: 157
		public bool Enabled = true;

		// Token: 0x0400009E RID: 158
		public string Role = string.Empty;

		// Token: 0x0400009F RID: 159
		private float StartTime;

		// Token: 0x040000A0 RID: 160
		private float looptime;

		// Token: 0x040000A1 RID: 161
		public string DateCreated;

		// Token: 0x040000A2 RID: 162
		private string FormattedDate;

		// Token: 0x040000A3 RID: 163
		private string platform;

		// Token: 0x040000A4 RID: 164
		public bool IsHelixOwner;

		// Token: 0x040000A5 RID: 165
		public bool ishelixuser;

		// Token: 0x040000A6 RID: 166
		private string ranktext = "Visitor";
	}
}
