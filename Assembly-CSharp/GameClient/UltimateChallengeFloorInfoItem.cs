using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020013B6 RID: 5046
	public class UltimateChallengeFloorInfoItem : MonoBehaviour
	{
		// Token: 0x0600C3C6 RID: 50118 RVA: 0x002EE967 File Offset: 0x002ECD67
		private void Start()
		{
		}

		// Token: 0x0600C3C7 RID: 50119 RVA: 0x002EE969 File Offset: 0x002ECD69
		private void OnDestroy()
		{
		}

		// Token: 0x0600C3C8 RID: 50120 RVA: 0x002EE96B File Offset: 0x002ECD6B
		private void Update()
		{
		}

		// Token: 0x0600C3C9 RID: 50121 RVA: 0x002EE96D File Offset: 0x002ECD6D
		private void ShowItemTip(GameObject go, ItemData itemData)
		{
			if (itemData != null)
			{
				DataManager<ItemTipManager>.GetInstance().CloseAll();
				DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
			}
		}

		// Token: 0x0600C3CA RID: 50122 RVA: 0x002EE990 File Offset: 0x002ECD90
		private void SetComItemData(ComItem comItem, AwardItemData uIItemData)
		{
			if (comItem == null || uIItemData == null)
			{
				return;
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(uIItemData.ID, 100, 0);
			if (itemData != null)
			{
				itemData.Count = uIItemData.Num;
				comItem.Setup(itemData, new ComItem.OnItemClicked(this.ShowItemTip));
			}
		}

		// Token: 0x0600C3CB RID: 50123 RVA: 0x002EE9E4 File Offset: 0x002ECDE4
		private string GetColorName(AwardItemData uIItemData)
		{
			if (uIItemData == null)
			{
				return string.Empty;
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(uIItemData.ID, 100, 0);
			if (itemData != null)
			{
				return itemData.GetColorName(string.Empty, false);
			}
			return string.Empty;
		}

		// Token: 0x0600C3CC RID: 50124 RVA: 0x002EEA24 File Offset: 0x002ECE24
		private void SetFloorEffect(string path)
		{
			if (this.effectRoot == null)
			{
				return;
			}
			for (int i = 0; i < this.effectRoot.childCount; i++)
			{
				Object.Destroy(this.effectRoot.GetChild(i).gameObject);
			}
			if (string.IsNullOrEmpty(path))
			{
				return;
			}
			GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadRes(path, true, 0U).obj as GameObject;
			if (gameObject == null)
			{
				return;
			}
			gameObject.transform.SetParent(this.effectRoot, false);
			gameObject.SetActive(true);
		}

		// Token: 0x0600C3CD RID: 50125 RVA: 0x002EEAC0 File Offset: 0x002ECEC0
		public void SetUp(object data)
		{
			if (data == null)
			{
				return;
			}
			if (!(data is ActivityDataManager.UltimateChallengeFloorData))
			{
				return;
			}
			ActivityDataManager.UltimateChallengeFloorData ultimateChallengeFloorData = data as ActivityDataManager.UltimateChallengeFloorData;
			this.SetFloorEffect(string.Empty);
			if (ultimateChallengeFloorData.floor == 0)
			{
				this.bg1.CustomActive(false);
				this.bg2.CustomActive(true);
				this.floorBg.CustomActive(false);
				this.lock1.CustomActive(false);
				this.lock2.CustomActive(false);
				this.floornum.CustomActive(false);
				this.unopen.CustomActive(false);
				return;
			}
			DateTime dateTime = Function.ConvertIntDateTime(DataManager<TimeManager>.GetInstance().GetServerDoubleTime());
			int num = (int)dateTime.DayOfWeek;
			if (dateTime.DayOfWeek == DayOfWeek.Sunday)
			{
				num = 7;
			}
			int num2 = num * DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeDungeonDailyOpenFloor();
			this.bg1.CustomActive(true);
			this.bg2.CustomActive(false);
			this.floorBg.CustomActive(true);
			this.floornum.CustomActive(true);
			this.unopen.CustomActive(true);
			if (ultimateChallengeFloorData.floor > num2)
			{
				this.lock2.CustomActive(true);
				this.SetFloorEffect(string.Empty);
				this.unopen.CustomActive(true);
			}
			else if (ultimateChallengeFloorData.floor == DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeTodayStartFloor())
			{
				this.lock2.CustomActive(false);
				this.SetFloorEffect(UltimateChallengeFloorInfoItem.openEffPath);
				this.unopen.CustomActive(false);
			}
			else if (ultimateChallengeFloorData.floor < DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeTodayStartFloor())
			{
				this.lock2.CustomActive(false);
				this.SetFloorEffect(UltimateChallengeFloorInfoItem.finishedEffPath);
				this.unopen.CustomActive(false);
			}
			else
			{
				this.lock2.CustomActive(true);
				this.SetFloorEffect(UltimateChallengeFloorInfoItem.notOpenEffPath);
				this.unopen.CustomActive(false);
			}
			UltimateChallengeDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<UltimateChallengeDungeonTable>(ultimateChallengeFloorData.tableID, string.Empty, string.Empty);
			this.lock1.CustomActive(tableItem != null && tableItem.IsDifficulty > 0);
			this.floornum.SafeSetText(ultimateChallengeFloorData.floor.ToString());
		}

		// Token: 0x04006F4C RID: 28492
		[SerializeField]
		private Image lock1;

		// Token: 0x04006F4D RID: 28493
		[SerializeField]
		private Image lock2;

		// Token: 0x04006F4E RID: 28494
		[SerializeField]
		private Text floornum;

		// Token: 0x04006F4F RID: 28495
		[SerializeField]
		private GameObject bg1;

		// Token: 0x04006F50 RID: 28496
		[SerializeField]
		private GameObject bg2;

		// Token: 0x04006F51 RID: 28497
		[SerializeField]
		private GameObject floorBg;

		// Token: 0x04006F52 RID: 28498
		[SerializeField]
		private RectTransform effectRoot;

		// Token: 0x04006F53 RID: 28499
		[SerializeField]
		private GameObject unopen;

		// Token: 0x04006F54 RID: 28500
		private ulong tableID;

		// Token: 0x04006F55 RID: 28501
		private static string finishedEffPath = "Effects/UI/Prefab/EffUI_pata/Prefab/EffUI_pata_wancheng";

		// Token: 0x04006F56 RID: 28502
		private static string notOpenEffPath = "Effects/UI/Prefab/EffUI_pata/Prefab/EffUI_pata_notopen";

		// Token: 0x04006F57 RID: 28503
		private static string openEffPath = "Effects/UI/Prefab/EffUI_pata/Prefab/EffUI_pata_open";
	}
}
