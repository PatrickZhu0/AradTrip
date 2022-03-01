using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001667 RID: 5735
	public class JuniorGuildDungeon : MonoBehaviour
	{
		// Token: 0x0600E197 RID: 57751 RVA: 0x0039E24C File Offset: 0x0039C64C
		private void Start()
		{
			if (this.btnBk != null)
			{
				this.btnBk.onClick.RemoveAllListeners();
				this.btnBk.onClick.AddListener(delegate()
				{
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
		}

		// Token: 0x0600E198 RID: 57752 RVA: 0x0039E2AD File Offset: 0x0039C6AD
		private void Update()
		{
		}

		// Token: 0x0600E199 RID: 57753 RVA: 0x0039E2B0 File Offset: 0x0039C6B0
		public void SetUp(object data)
		{
			GuildDataManager.JuniorDungeonDamageInfo juniorDungeonDamageInfo = data as GuildDataManager.JuniorDungeonDamageInfo;
			if (juniorDungeonDamageInfo == null)
			{
				return;
			}
			this.nDungeonID = juniorDungeonDamageInfo.nDungeonID;
			if (this.txtBossName != null)
			{
				this.txtBossName.text = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonName((uint)juniorDungeonDamageInfo.nDungeonID);
			}
			if (this.txtDungeonLv != null)
			{
				this.txtDungeonLv.text = "Lv. " + DataManager<GuildDataManager>.GetInstance().GetGuildDungeonLv((uint)juniorDungeonDamageInfo.nDungeonID).ToString();
			}
			if (this.txtKillCount != null)
			{
				this.txtKillCount.text = string.Format("通关次数 {0}", juniorDungeonDamageInfo.nKillCount);
			}
			if (this.imgIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.imgIcon, DataManager<GuildDataManager>.GetInstance().GetGuildDungeonIconPath((uint)this.nDungeonID), true);
			}
			GuildDataManager.GuildDungeonActivityData guildDungeonActivityData = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityData();
			if (guildDungeonActivityData != null && this.imgIcon != null)
			{
				UIGray uigray = this.imgIcon.gameObject.SafeAddComponent(false);
				if (uigray != null)
				{
					uigray.enabled = (guildDungeonActivityData.nBossOddHp == 0UL);
					uigray.SetEnable(guildDungeonActivityData.nBossOddHp == 0UL);
				}
			}
		}

		// Token: 0x0400864D RID: 34381
		[SerializeField]
		private Text txtBossName;

		// Token: 0x0400864E RID: 34382
		[SerializeField]
		private Text txtDungeonLv;

		// Token: 0x0400864F RID: 34383
		[SerializeField]
		private Text txtKillCount;

		// Token: 0x04008650 RID: 34384
		[SerializeField]
		private Button btnBk;

		// Token: 0x04008651 RID: 34385
		[SerializeField]
		private Image imgIcon;

		// Token: 0x04008652 RID: 34386
		[SerializeField]
		private Button btnHowToPlay;

		// Token: 0x04008653 RID: 34387
		private ulong nDungeonID;
	}
}
