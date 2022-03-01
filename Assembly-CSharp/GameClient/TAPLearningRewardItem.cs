using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BD7 RID: 7127
	internal class TAPLearningRewardItem : ClientFrame
	{
		// Token: 0x06011754 RID: 71508 RVA: 0x00511D2A File Offset: 0x0051012A
		public TAPLearningRewardItem(MasterSysGiftTable masterSysGiftTableItem)
		{
			this.tableData = masterSysGiftTableItem;
			this.CreateGo(masterSysGiftTableItem);
		}

		// Token: 0x17001DB3 RID: 7603
		// (get) Token: 0x06011755 RID: 71509 RVA: 0x00511D40 File Offset: 0x00510140
		// (set) Token: 0x06011756 RID: 71510 RVA: 0x00511D48 File Offset: 0x00510148
		public GameObject ThisGameObject
		{
			get
			{
				return this.thisGameObject;
			}
			set
			{
				this.thisGameObject = value;
			}
		}

		// Token: 0x06011757 RID: 71511 RVA: 0x00511D54 File Offset: 0x00510154
		public void CreateGo(MasterSysGiftTable masterSysGiftTableItem)
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/TAP/TAPLearningRewardItem", true, 0U);
			this.thisGameObject = gameObject;
			this.myMasterSysGiftTableData = masterSysGiftTableItem;
			if (gameObject == null)
			{
				return;
			}
			ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			this.mItemRoot = component.GetGameObject("ItemRoot");
			this.mScore = component.GetCom<Text>("Score");
			this.mFinished = component.GetGameObject("Finished");
			this.mGetReward = component.GetCom<Button>("GetReward");
			if (null != this.mGetReward)
			{
				this.mGetReward.onClick.RemoveAllListeners();
				this.mGetReward.onClick.AddListener(delegate()
				{
					DataManager<TAPNewDataManager>.GetInstance().FinishLearningReward(this.tableData.ID);
					this.mGetReward.CustomActive(false);
					this.mFinished.CustomActive(true);
				});
			}
			this.UpdateRewardJar();
		}

		// Token: 0x06011758 RID: 71512 RVA: 0x00511E2C File Offset: 0x0051022C
		public void UpdateRewardJar()
		{
			ComItem comItem = this.mItemRoot.GetComponentInChildren<ComItem>();
			if (comItem == null)
			{
				comItem = base.CreateComItem(this.mItemRoot);
			}
			ItemData ItemDetailData = ItemDataManager.CreateItemDataFromTable(this.myMasterSysGiftTableData.GiftId, 100, 0);
			if (ItemDetailData == null)
			{
				return;
			}
			comItem.Setup(ItemDetailData, delegate(GameObject Obj, ItemData sitem)
			{
				this._OnShowTips(ItemDetailData);
			});
			this.mScore.text = this.myMasterSysGiftTableData.Param.ToString();
			this.mFinished.CustomActive(false);
			this.mGetReward.CustomActive(false);
		}

		// Token: 0x06011759 RID: 71513 RVA: 0x00511EE4 File Offset: 0x005102E4
		public void UpdateState(int myScore)
		{
			if (DataManager<CountDataManager>.GetInstance().GetCount(this.myMasterSysGiftTableData.CounterKey) == 0)
			{
				if (this.myMasterSysGiftTableData.Param <= myScore)
				{
					this.mGetReward.CustomActive(true);
				}
			}
			else
			{
				this.mFinished.CustomActive(true);
			}
		}

		// Token: 0x0601175A RID: 71514 RVA: 0x00511F40 File Offset: 0x00510340
		private void _OnShowTips(ItemData result)
		{
			if (result == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(result, null, 4, true, false, true);
		}

		// Token: 0x0400B558 RID: 46424
		private const string learningRewardItemPath = "UIFlatten/Prefabs/TAP/TAPLearningRewardItem";

		// Token: 0x0400B559 RID: 46425
		private GameObject mItemRoot;

		// Token: 0x0400B55A RID: 46426
		private Text mScore;

		// Token: 0x0400B55B RID: 46427
		private GameObject mFinished;

		// Token: 0x0400B55C RID: 46428
		private Button mGetReward;

		// Token: 0x0400B55D RID: 46429
		private GameObject thisGameObject;

		// Token: 0x0400B55E RID: 46430
		private MasterSysGiftTable tableData;

		// Token: 0x0400B55F RID: 46431
		private MasterSysGiftTable myMasterSysGiftTableData;
	}
}
