using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015E4 RID: 5604
	public class BossGuildDungeon : MonoBehaviour
	{
		// Token: 0x0600DB64 RID: 56164 RVA: 0x00374804 File Offset: 0x00372C04
		private void Start()
		{
			if (this.btnBk != null)
			{
				this.btnBk.onClick.RemoveAllListeners();
				this.btnBk.onClick.AddListener(delegate()
				{
					if (!DataManager<GuildDataManager>.GetInstance().IsGuildDungeonOpen((int)this.nDungeonID))
					{
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("guildDungeonNotOpenNow"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						return;
					}
					GuildDataManager.GuildDungeonActivityData guildDungeonActivityData = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityData();
					if (guildDungeonActivityData != null && guildDungeonActivityData.nBossOddHp == 0UL)
					{
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("guildDungeonBossHaveKilledCanNotEnter"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						return;
					}
					ChapterBaseFrame.sDungeonID = (int)this.nDungeonID;
					Singleton<ClientSystemManager>.instance.OpenFrame<GuildDungeonCityInfoFrame>(FrameLayer.Middle, null, string.Empty);
				});
			}
			this.btnHowToPlay.SafeAddOnClickListener(delegate
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildDungeonHowToPlayFrame>(FrameLayer.Middle, this.nDungeonID, string.Empty);
			});
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildDungeonUpdateActivityData, new ClientEventSystem.UIEventHandler(this._OnUpdateActivityData));
		}

		// Token: 0x0600DB65 RID: 56165 RVA: 0x00374880 File Offset: 0x00372C80
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildDungeonUpdateActivityData, new ClientEventSystem.UIEventHandler(this._OnUpdateActivityData));
		}

		// Token: 0x0600DB66 RID: 56166 RVA: 0x0037489D File Offset: 0x00372C9D
		private void Update()
		{
		}

		// Token: 0x0600DB67 RID: 56167 RVA: 0x003748A0 File Offset: 0x00372CA0
		public void SetUp(object data)
		{
			GuildDataManager.BossDungeonDamageInfo bossDungeonDamageInfo = data as GuildDataManager.BossDungeonDamageInfo;
			if (bossDungeonDamageInfo == null)
			{
				return;
			}
			this.nDungeonID = bossDungeonDamageInfo.nDungeonID;
			if (this.txtBossName != null)
			{
				this.txtBossName.text = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonName((uint)bossDungeonDamageInfo.nDungeonID);
			}
			if (this.txtDungeonLv != null)
			{
				this.txtDungeonLv.text = "Lv. " + DataManager<GuildDataManager>.GetInstance().GetGuildDungeonLv((uint)bossDungeonDamageInfo.nDungeonID).ToString();
			}
			if (this.imgIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.imgIcon, DataManager<GuildDataManager>.GetInstance().GetGuildDungeonIconPath((uint)this.nDungeonID), true);
			}
			if (this.txtLockTip != null)
			{
				this.txtLockTip.CustomActive(!DataManager<GuildDataManager>.GetInstance().IsGuildDungeonOpen((int)this.nDungeonID));
			}
			if (this.imgLock != null)
			{
				this.imgLock.CustomActive(!DataManager<GuildDataManager>.GetInstance().IsGuildDungeonOpen((int)this.nDungeonID));
			}
			if (this.process != null)
			{
				this.process.CustomActive(DataManager<GuildDataManager>.GetInstance().IsGuildDungeonOpen((int)this.nDungeonID));
			}
			this.UpdateOpenFlagImgs();
			this.UpdateKillInfo();
		}

		// Token: 0x0600DB68 RID: 56168 RVA: 0x00374A01 File Offset: 0x00372E01
		private void _OnUpdateActivityData(UIEvent uiEvent)
		{
			this.UpdateKillInfo();
		}

		// Token: 0x0600DB69 RID: 56169 RVA: 0x00374A09 File Offset: 0x00372E09
		private void SafeLoadImage(ref Image img, string path)
		{
			if (img == null || path == null)
			{
				return;
			}
			ETCImageLoader.LoadSprite(ref img, path, true);
		}

		// Token: 0x0600DB6A RID: 56170 RVA: 0x00374A28 File Offset: 0x00372E28
		private void UpdateOpenFlagImgs()
		{
			Image[] array = new Image[]
			{
				this.imgOpenFlag0,
				this.imgOpenFlag1,
				this.imgOpenFlag2
			};
			if (array == null)
			{
				return;
			}
			GuildDataManager.GuildDungeonActivityData guildDungeonActivityData = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityData();
			if (guildDungeonActivityData != null && guildDungeonActivityData.mediumDungeonDamgeInfos != null)
			{
				for (int i = 0; i < guildDungeonActivityData.mediumDungeonDamgeInfos.Count; i++)
				{
					GuildDataManager.MediumDungeonDamageInfo mediumDungeonDamageInfo = guildDungeonActivityData.mediumDungeonDamgeInfos[i];
					if (mediumDungeonDamageInfo != null && mediumDungeonDamageInfo.nOddHp == 0UL)
					{
						array[i].CustomActive(true);
						if (i < array.Length && i < this.openFlagStrs.Length)
						{
							this.SafeLoadImage(ref array[i], this.openFlagStrs[i]);
						}
					}
					else
					{
						array[i].CustomActive(false);
					}
				}
			}
		}

		// Token: 0x0600DB6B RID: 56171 RVA: 0x00374B00 File Offset: 0x00372F00
		private void UpdateKillInfo()
		{
			GuildDataManager.GuildDungeonActivityData guildDungeonActivityData = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityData();
			if (guildDungeonActivityData != null)
			{
				if (this.txtKillInfo != null)
				{
					this.txtKillInfo.text = string.Format("{0}/{1}", guildDungeonActivityData.nBossOddHp, guildDungeonActivityData.nBossMaxHp);
				}
				if (this.process != null && guildDungeonActivityData.nBossMaxHp > 0UL)
				{
					this.process.value = guildDungeonActivityData.nBossOddHp / guildDungeonActivityData.nBossMaxHp;
				}
				if (this.imgKilled != null)
				{
					this.imgKilled.CustomActive(guildDungeonActivityData.nBossOddHp == 0UL);
				}
				if (this.imgVerifyBlood != null && guildDungeonActivityData.nBossMaxHp > 0UL)
				{
					this.imgVerifyBlood.fillAmount = guildDungeonActivityData.nVerifyBlood / guildDungeonActivityData.nBossMaxHp;
				}
				if (this.imgIcon != null)
				{
					UIGray uigray = this.imgIcon.gameObject.SafeAddComponent(false);
					if (uigray != null)
					{
						uigray.enabled = (guildDungeonActivityData.nBossOddHp == 0UL);
						uigray.SetEnable(guildDungeonActivityData.nBossOddHp == 0UL);
					}
				}
			}
		}

		// Token: 0x04008147 RID: 33095
		[SerializeField]
		private Text txtBossName;

		// Token: 0x04008148 RID: 33096
		[SerializeField]
		private Text txtDungeonLv;

		// Token: 0x04008149 RID: 33097
		[SerializeField]
		private Button btnBk;

		// Token: 0x0400814A RID: 33098
		[SerializeField]
		private Image imgIcon;

		// Token: 0x0400814B RID: 33099
		[SerializeField]
		private Text txtLockTip;

		// Token: 0x0400814C RID: 33100
		[SerializeField]
		private Image imgLock;

		// Token: 0x0400814D RID: 33101
		[SerializeField]
		private Slider process;

		// Token: 0x0400814E RID: 33102
		[SerializeField]
		private Text txtKillInfo;

		// Token: 0x0400814F RID: 33103
		[SerializeField]
		private Image imgOpenFlag0;

		// Token: 0x04008150 RID: 33104
		[SerializeField]
		private Image imgOpenFlag1;

		// Token: 0x04008151 RID: 33105
		[SerializeField]
		private Image imgOpenFlag2;

		// Token: 0x04008152 RID: 33106
		[SerializeField]
		private Image imgKilled;

		// Token: 0x04008153 RID: 33107
		[SerializeField]
		private Image imgVerifyBlood;

		// Token: 0x04008154 RID: 33108
		[SerializeField]
		private Button btnHowToPlay;

		// Token: 0x04008155 RID: 33109
		private ulong nDungeonID;

		// Token: 0x04008156 RID: 33110
		private const int nMediumDungeonNum = 3;

		// Token: 0x04008157 RID: 33111
		private string[] openFlagStrs = new string[]
		{
			"UI/Image/Packed/p_UI_Gonghuifuben.png:UI_Gonghuifuben_Baoshi03",
			"UI/Image/Packed/p_UI_Gonghuifuben.png:UI_Gonghuifuben_Baoshi02",
			"UI/Image/Packed/p_UI_Gonghuifuben.png:UI_Gonghuifuben_Baoshi01"
		};
	}
}
