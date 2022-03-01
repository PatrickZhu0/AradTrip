using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015FE RID: 5630
	public class GuildBuildingItem : MonoBehaviour
	{
		// Token: 0x0600DC9E RID: 56478 RVA: 0x0037BF4F File Offset: 0x0037A34F
		private void Start()
		{
		}

		// Token: 0x0600DC9F RID: 56479 RVA: 0x0037BF51 File Offset: 0x0037A351
		private void OnDestroy()
		{
		}

		// Token: 0x0600DCA0 RID: 56480 RVA: 0x0037BF53 File Offset: 0x0037A353
		private void Update()
		{
		}

		// Token: 0x0600DCA1 RID: 56481 RVA: 0x0037BF58 File Offset: 0x0037A358
		private bool CanLvUpBuildingByType(GuildBuildingType guildBuildingType)
		{
			GuildBuildingData buildingData = DataManager<GuildDataManager>.GetInstance().GetBuildingData(guildBuildingType);
			return buildingData != null && (buildingData.nUnlockMaincityLevel <= 0 || buildingData.nLevel < buildingData.nMaxLevel) && DataManager<GuildDataManager>.GetInstance().GetMyGuildFund() >= buildingData.nUpgradeCost;
		}

		// Token: 0x0600DCA2 RID: 56482 RVA: 0x0037BFB4 File Offset: 0x0037A3B4
		public void SetUp(object data)
		{
			if (data == null)
			{
				return;
			}
			if (!(data is GuildBuildingData))
			{
				return;
			}
			GuildBuildingData guildBuildingData = data as GuildBuildingData;
			GuildBuildInfoTable guildBuildInfoTable = DataManager<GuildDataManager>.GetInstance().GetGuildBuildInfoTable(guildBuildingData.eType);
			if (guildBuildInfoTable == null)
			{
				return;
			}
			this.guildBuildingType = guildBuildingData.eType;
			this.icon.SafeSetImage(guildBuildInfoTable.buildIconPath, false);
			this.name.SafeSetImage(guildBuildInfoTable.buildNamePath, false);
			if (this.name != null)
			{
				this.name.SetNativeSize();
			}
			this.desc.SafeSetText(guildBuildInfoTable.buildDesc);
			int num = guildBuildingData.nLevel;
			int num2 = guildBuildingData.nMaxLevel;
			if (num2 <= 0)
			{
				num = 1;
				num2 = 1;
			}
			this.lv.SafeSetText(TR.Value("guild_build_lv_info", num));
			this.mainLvLimit.SafeSetText(TR.Value("guild_build_lv_up_need_main_lv", guildBuildingData.nUnlockMaincityLevel));
			int myGuildFund = DataManager<GuildDataManager>.GetInstance().GetMyGuildFund();
			if (this.process != null)
			{
				float value = 0f;
				if (guildBuildingData.nUpgradeCost > 0)
				{
					value = Math.Min(1f, (float)myGuildFund / (float)guildBuildingData.nUpgradeCost);
				}
				this.process.value = value;
			}
			this.cost.SafeSetText(string.Format("{0}/{1}", myGuildFund, guildBuildingData.nUpgradeCost));
			bool bActive = false;
			bool flag;
			if (num >= num2)
			{
				if (guildBuildingData.nUnlockMaincityLevel > 0)
				{
					flag = true;
					bActive = true;
				}
				else
				{
					flag = false;
				}
			}
			else
			{
				flag = true;
			}
			if (guildBuildingData.eType == GuildBuildingType.MAIN)
			{
				bActive = false;
			}
			this.btnLvUp.SafeSetOnClickListener(delegate
			{
				GuildBuildingType a_eType = this.guildBuildingType;
				GuildBuildingData guildBuildingDataTemp = DataManager<GuildDataManager>.GetInstance().GetBuildingData(a_eType);
				if (guildBuildingDataTemp != null)
				{
					if (guildBuildingDataTemp.nUnlockMaincityLevel > 0 && guildBuildingDataTemp.nLevel >= guildBuildingDataTemp.nMaxLevel)
					{
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("guild_build_lv_up_main_lv_not_enough"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						return;
					}
					if (DataManager<GuildDataManager>.GetInstance().GetMyGuildFund() < guildBuildingDataTemp.nUpgradeCost)
					{
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("guild_build_lv_up_fund_not_enough"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						return;
					}
					SystemNotifyManager.SysNotifyMsgBoxOkCancel(TR.Value("guild_upgrade_building_ask", guildBuildingDataTemp.nUpgradeCost), delegate()
					{
						DataManager<GuildDataManager>.GetInstance().UpgradeBuilding(guildBuildingDataTemp.eType, guildBuildingDataTemp.nUpgradeCost);
					}, null, 0f, false);
				}
			});
			bool flag2 = DataManager<GuildDataManager>.GetInstance().GetBuildingLevel(GuildBuildingType.MAIN) >= DataManager<GuildDataManager>.GetInstance().GetUnLockBuildingNeedMainCityLv(this.guildBuildingType);
			if (flag2)
			{
				this.btnLvUpText.SafeSetText(TR.Value("guild_build_lv_up"));
			}
			else
			{
				this.btnLvUpText.SafeSetText(TR.Value("guild_build_lv_up_need_main_lv_to_unlcok", DataManager<GuildDataManager>.GetInstance().GetUnLockBuildingNeedMainCityLv(this.guildBuildingType)));
				this.unlockNeedMainLv.SafeSetText(TR.Value("guild_build_lv_up_need_main_lv_to_unlcok", DataManager<GuildDataManager>.GetInstance().GetUnLockBuildingNeedMainCityLv(this.guildBuildingType)));
			}
			this.btnLvUp.SafeSetGray(!DataManager<GuildDataManager>.GetInstance().HasPermission(EGuildPermission.UpgradeBuilding, EGuildDuty.Invalid) || !this.CanLvUpBuildingByType(this.guildBuildingType), true);
			this.btnLvUp.CustomActive(flag);
			this.maxLv.CustomActive(!flag);
			this.mainLvLimit.CustomActive(bActive);
			this.process.CustomActive(flag);
			if (!flag2)
			{
				this.process.CustomActive(false);
				this.mainLvLimit.CustomActive(false);
				this.unlockNeedMainLv.CustomActive(true);
				this.btnLvUp.CustomActive(false);
			}
			else
			{
				this.unlockNeedMainLv.CustomActive(false);
			}
		}

		// Token: 0x0400822B RID: 33323
		[SerializeField]
		private Image icon;

		// Token: 0x0400822C RID: 33324
		[SerializeField]
		private Image name;

		// Token: 0x0400822D RID: 33325
		[SerializeField]
		private Text lv;

		// Token: 0x0400822E RID: 33326
		[SerializeField]
		private Text desc;

		// Token: 0x0400822F RID: 33327
		[SerializeField]
		private Text mainLvLimit;

		// Token: 0x04008230 RID: 33328
		[SerializeField]
		private Text unlockNeedMainLv;

		// Token: 0x04008231 RID: 33329
		[SerializeField]
		private Slider process;

		// Token: 0x04008232 RID: 33330
		[SerializeField]
		private Text cost;

		// Token: 0x04008233 RID: 33331
		[SerializeField]
		private Button btnLvUp;

		// Token: 0x04008234 RID: 33332
		[SerializeField]
		private Text maxLv;

		// Token: 0x04008235 RID: 33333
		[SerializeField]
		private Text btnLvUpText;

		// Token: 0x04008236 RID: 33334
		private GuildBuildingType guildBuildingType;
	}
}
