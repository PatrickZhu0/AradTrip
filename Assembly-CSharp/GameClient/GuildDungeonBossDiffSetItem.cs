using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001613 RID: 5651
	public class GuildDungeonBossDiffSetItem : MonoBehaviour
	{
		// Token: 0x0600DD7E RID: 56702 RVA: 0x00382414 File Offset: 0x00380814
		private void Start()
		{
		}

		// Token: 0x0600DD7F RID: 56703 RVA: 0x00382418 File Offset: 0x00380818
		private void Awake()
		{
			this.diffType2IconPath = new Dictionary<int, string>();
			if (this.diffType2IconPath != null)
			{
				this.diffType2IconPath[1] = "UI/Image/Icon/Icon_Gonghui/Icon_Gonghui_Nandu_01.png";
				this.diffType2IconPath[2] = "UI/Image/Icon/Icon_Gonghui/Icon_Gonghui_Nandu_02.png";
				this.diffType2IconPath[3] = "UI/Image/Icon/Icon_Gonghui/Icon_Gonghui_Nandu_03.png";
				this.diffType2IconPath[4] = "UI/Image/Icon/Icon_Gonghui/Icon_Gonghui_Nandu_04.png";
			}
			this.diffType2NamePath = new Dictionary<int, string>();
			if (this.diffType2NamePath != null)
			{
				this.diffType2NamePath[1] = "UI/Image/Packed/p_UI_Badge.png:UI_Badge_Boss_Putong";
				this.diffType2NamePath[2] = "UI/Image/Packed/p_UI_Badge.png:UI_Badge_Boss_Maoxian";
				this.diffType2NamePath[3] = "UI/Image/Packed/p_UI_Badge.png:UI_Badge_Boss_Yongshi";
				this.diffType2NamePath[4] = "UI/Image/Packed/p_UI_Badge.png:UI_Badge_Boss_Wangzhe";
			}
		}

		// Token: 0x0600DD80 RID: 56704 RVA: 0x003824D9 File Offset: 0x003808D9
		private void OnDestroy()
		{
			this.diffType2IconPath = null;
			this.diffType2NamePath = null;
		}

		// Token: 0x0600DD81 RID: 56705 RVA: 0x003824E9 File Offset: 0x003808E9
		private void Update()
		{
		}

		// Token: 0x0600DD82 RID: 56706 RVA: 0x003824EB File Offset: 0x003808EB
		private string GetIconPath(int iDiffType)
		{
			if (this.diffType2IconPath != null && this.diffType2IconPath.ContainsKey(iDiffType))
			{
				return this.diffType2IconPath[iDiffType];
			}
			return string.Empty;
		}

		// Token: 0x0600DD83 RID: 56707 RVA: 0x0038251B File Offset: 0x0038091B
		private string GetDiffPath(int iDiffType)
		{
			if (this.diffType2NamePath != null && this.diffType2NamePath.ContainsKey(iDiffType))
			{
				return this.diffType2NamePath[iDiffType];
			}
			return string.Empty;
		}

		// Token: 0x0600DD84 RID: 56708 RVA: 0x0038254C File Offset: 0x0038094C
		private void InitAwardItems()
		{
			if (this.awardItems == null)
			{
				return;
			}
			this.awardItems.Initialize();
			this.awardItems.onBindItem = delegate(GameObject go)
			{
				PayRewardItem result = null;
				if (go)
				{
					result = go.GetComponent<PayRewardItem>();
				}
				return result;
			};
			this.awardItems.onItemVisiable = delegate(ComUIListElementScript var1)
			{
				if (var1 == null)
				{
					return;
				}
				int index = var1.m_index;
				if (index >= 0 && this.awardItemDataList != null && index < this.awardItemDataList.Count)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.awardItemDataList[index].ID, 100, 0);
					if (itemData == null)
					{
						Logger.LogErrorFormat("GuildDungeonBossDiffSetItem Can not find item id in item table!!! Please Check item data id {0} !!!", new object[]
						{
							this.awardItemDataList[index].ID
						});
						return;
					}
					itemData.Count = this.awardItemDataList[index].Num;
					PayRewardItem payRewardItem = var1.gameObjectBindScript as PayRewardItem;
					if (payRewardItem != null)
					{
						payRewardItem.Initialize(this.clientFrame, itemData, true, false);
						payRewardItem.RefreshView(true, true);
					}
				}
			};
		}

		// Token: 0x0600DD85 RID: 56709 RVA: 0x003825B8 File Offset: 0x003809B8
		private void CalAwardItemList(int iDiffType)
		{
			this.awardItemDataList = new List<AwardItemData>();
			if (this.awardItemDataList == null)
			{
				return;
			}
			GuildDungeonTypeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildDungeonTypeTable>(iDiffType, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			for (int i = 0; i < tableItem.rewardItemLength; i++)
			{
				string text = tableItem.rewardItemArray(i);
				string[] array = text.Split(new char[]
				{
					'_'
				});
				if (array.Length >= 2)
				{
					AwardItemData awardItemData = new AwardItemData();
					int.TryParse(array[0], out awardItemData.ID);
					int.TryParse(array[1], out awardItemData.Num);
					this.awardItemDataList.Add(awardItemData);
				}
			}
		}

		// Token: 0x0600DD86 RID: 56710 RVA: 0x00382668 File Offset: 0x00380A68
		private void UpdateAwardItems(int iDiffType)
		{
			if (Singleton<TableManager>.GetInstance().GetTableItem<GuildDungeonTypeTable>(iDiffType, string.Empty, string.Empty) == null)
			{
				return;
			}
			if (this.awardItems == null)
			{
				return;
			}
			this.CalAwardItemList(iDiffType);
			if (this.awardItemDataList != null)
			{
				this.awardItems.SetElementAmount(this.awardItemDataList.Count);
				if (this.awardItems.m_scrollRect != null)
				{
					this.awardItems.m_scrollRect.horizontalNormalizedPosition = 0f;
				}
			}
		}

		// Token: 0x0600DD87 RID: 56711 RVA: 0x003826F8 File Offset: 0x00380AF8
		private string GetBossDiffStr(int iDiffType)
		{
			string[] array = new string[]
			{
				TR.Value("guild_build_boss_lv_set_diff_putong"),
				TR.Value("guild_build_boss_lv_set_diff_maoxian"),
				TR.Value("guild_build_boss_lv_set_diff_yongshi"),
				TR.Value("guild_build_boss_lv_set_diff_wangzhe")
			};
			if (array == null)
			{
				return string.Empty;
			}
			if (iDiffType >= 1 && iDiffType <= array.Length)
			{
				return array[iDiffType - 1];
			}
			return string.Empty;
		}

		// Token: 0x0600DD88 RID: 56712 RVA: 0x00382768 File Offset: 0x00380B68
		public void SetUp(object data, ClientFrame frame)
		{
			if (data == null)
			{
				return;
			}
			if (frame == null)
			{
				return;
			}
			if (!(data is int))
			{
				return;
			}
			int iDiffType = (int)data;
			GuildDungeonTypeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildDungeonTypeTable>(iDiffType, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.clientFrame = frame;
			this.icon.SafeSetImage(this.GetIconPath(iDiffType), false);
			this.diff.SafeSetImage(this.GetDiffPath(iDiffType), false);
			this.selected.CustomActive(iDiffType == DataManager<GuildDataManager>.GetInstance().GetGuildDungeonDiffType());
			this.InitAwardItems();
			this.UpdateAwardItems(iDiffType);
			this.btnSelect.SafeSetOnClickListener(delegate
			{
				int iDiffTemp = iDiffType;
				int guildDungeonDiffType = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonDiffType();
				SystemNotifyManager.SysNotifyMsgBoxCancelOk(TR.Value("guild_build_boss_lv_set_diff_msg_box", this.GetBossDiffStr(guildDungeonDiffType), this.GetBossDiffStr(iDiffTemp)), null, delegate()
				{
					DataManager<GuildDataManager>.GetInstance().SendWorldGuildSetDungeonTypeReq((uint)iDiffTemp);
				}, 0f, false, null);
			});
			this.btnSelect.SafeSetGray(!DataManager<GuildDataManager>.GetInstance().HasPermission(EGuildPermission.SetGuildDungeonBossDiff, EGuildDuty.Invalid), true);
			this.btnSelect.CustomActive(iDiffType != DataManager<GuildDataManager>.GetInstance().GetGuildDungeonDiffType());
			this.description1.SafeSetText(TR.Value("guild_build_boss_lv_set_challenge_time", tableItem.challengeTime));
			this.description2.SafeSetText(TR.Value("guild_build_boss_lv_set_recommend_lv", tableItem.recommendLv));
			this.description3.SafeSetText(TR.Value("guild_build_boss_lv_set_recommend_equip", tableItem.recommendEquip));
			this.description4.SafeSetText(TR.Value("guild_build_boss_lv_set_recommend_player_num", tableItem.recommendPlayerNum));
			this.lvLimit.SafeSetText(TR.Value("guild_build_boss_lv_set_unlock_by_fete_lv", tableItem.buildLvl));
			bool flag = tableItem.buildLvl > DataManager<GuildDataManager>.GetInstance().GetBuildingLevel(GuildBuildingType.FETE);
			bool flag2 = DataManager<GuildDataManager>.GetInstance().GetBuildingLevel(GuildBuildingType.FETE) >= tableItem.buildLvl;
			if (!flag2 || flag)
			{
				this.btnSelect.CustomActive(false);
			}
			if (flag)
			{
				this.lvLimit.CustomActive(false);
				this.comingSoon.CustomActive(true);
			}
			else
			{
				this.lvLimit.CustomActive(!flag2);
				this.comingSoon.CustomActive(false);
			}
			this.mask.CustomActive(flag);
			this.effuiSelect.CustomActive(iDiffType == DataManager<GuildDataManager>.GetInstance().GetGuildDungeonDiffType());
		}

		// Token: 0x04008309 RID: 33545
		[SerializeField]
		private Image icon;

		// Token: 0x0400830A RID: 33546
		[SerializeField]
		private Image diff;

		// Token: 0x0400830B RID: 33547
		[SerializeField]
		private Image selected;

		// Token: 0x0400830C RID: 33548
		[SerializeField]
		private ComUIListScript awardItems;

		// Token: 0x0400830D RID: 33549
		[SerializeField]
		private Button btnSelect;

		// Token: 0x0400830E RID: 33550
		[SerializeField]
		private Text lvLimit;

		// Token: 0x0400830F RID: 33551
		[SerializeField]
		private Text description1;

		// Token: 0x04008310 RID: 33552
		[SerializeField]
		private Text description2;

		// Token: 0x04008311 RID: 33553
		[SerializeField]
		private Text description3;

		// Token: 0x04008312 RID: 33554
		[SerializeField]
		private Text description4;

		// Token: 0x04008313 RID: 33555
		[SerializeField]
		private GameObject descriptionRoot;

		// Token: 0x04008314 RID: 33556
		[SerializeField]
		private Image comingSoon;

		// Token: 0x04008315 RID: 33557
		[SerializeField]
		private Image mask;

		// Token: 0x04008316 RID: 33558
		[SerializeField]
		private GameObject effuiSelect;

		// Token: 0x04008317 RID: 33559
		private List<AwardItemData> awardItemDataList;

		// Token: 0x04008318 RID: 33560
		private ClientFrame clientFrame;

		// Token: 0x04008319 RID: 33561
		private Dictionary<int, string> diffType2IconPath;

		// Token: 0x0400831A RID: 33562
		private Dictionary<int, string> diffType2NamePath;
	}
}
