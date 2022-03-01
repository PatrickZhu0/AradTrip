using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001616 RID: 5654
	public class GuildDungeonBuffAddUpInfoItem : MonoBehaviour
	{
		// Token: 0x0600DDA8 RID: 56744 RVA: 0x003833D7 File Offset: 0x003817D7
		private void Start()
		{
		}

		// Token: 0x0600DDA9 RID: 56745 RVA: 0x003833D9 File Offset: 0x003817D9
		private void Update()
		{
		}

		// Token: 0x0600DDAA RID: 56746 RVA: 0x003833DC File Offset: 0x003817DC
		public void SetUp(object data)
		{
			GuildDataManager.BuffAddUpInfo buffAddUpInfo = data as GuildDataManager.BuffAddUpInfo;
			if (buffAddUpInfo == null)
			{
				return;
			}
			this.nDungeonID = buffAddUpInfo.nDungeonID;
			if (this.txtBossName != null)
			{
				this.txtBossName.text = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonName((uint)this.nDungeonID);
			}
			if (this.txtDungeonLv != null)
			{
				this.txtDungeonLv.text = "Lv." + DataManager<GuildDataManager>.GetInstance().GetGuildDungeonLv((uint)this.nDungeonID).ToString();
			}
			if (this.txtAddUpInfo != null)
			{
				this.txtAddUpInfo.text = GuildDataManager.GetBuffAddUpInfo((int)buffAddUpInfo.nBuffID, (int)buffAddUpInfo.nBuffLv);
			}
			GuildDataManager.GuildDungeonActivityData guildDungeonActivityData = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityData();
			if (guildDungeonActivityData != null && guildDungeonActivityData.juniorDungeonDamgeInfos != null)
			{
				for (int i = 0; i < guildDungeonActivityData.juniorDungeonDamgeInfos.Count; i++)
				{
					if (guildDungeonActivityData.juniorDungeonDamgeInfos[i].nDungeonID == this.nDungeonID)
					{
						if (this.txtKillCountInfo != null)
						{
							this.txtKillCountInfo.text = string.Format("通关次数 {0}", guildDungeonActivityData.juniorDungeonDamgeInfos[i].nKillCount);
						}
						uint num = (uint)guildDungeonActivityData.juniorDungeonDamgeInfos[i].nKillCount;
						uint num2 = num % 10U;
						uint num3 = num / 10U % 10U;
						uint num4 = num / 100U % 10U;
						if (this.txt100Place != null)
						{
							this.txt100Place.text = num4.ToString();
						}
						if (this.txt10Place != null)
						{
							this.txt10Place.text = num3.ToString();
						}
						if (this.txt1Place != null)
						{
							this.txt1Place.text = num2.ToString();
						}
						break;
					}
				}
			}
			if (this.imgIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.imgIcon, DataManager<GuildDataManager>.GetInstance().GetGuildDungeonIconPath((uint)this.nDungeonID), true);
			}
		}

		// Token: 0x0400832D RID: 33581
		[SerializeField]
		private Text txtBossName;

		// Token: 0x0400832E RID: 33582
		[SerializeField]
		private Text txtDungeonLv;

		// Token: 0x0400832F RID: 33583
		[SerializeField]
		private Image imgIcon;

		// Token: 0x04008330 RID: 33584
		[SerializeField]
		private Text txtAddUpInfo;

		// Token: 0x04008331 RID: 33585
		[SerializeField]
		private Text txtKillCountInfo;

		// Token: 0x04008332 RID: 33586
		[SerializeField]
		private Text txt100Place;

		// Token: 0x04008333 RID: 33587
		[SerializeField]
		private Text txt10Place;

		// Token: 0x04008334 RID: 33588
		[SerializeField]
		private Text txt1Place;

		// Token: 0x04008335 RID: 33589
		private ulong nDungeonID;
	}
}
