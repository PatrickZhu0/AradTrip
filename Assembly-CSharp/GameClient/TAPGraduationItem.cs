using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BD5 RID: 7125
	internal class TAPGraduationItem : ClientFrame
	{
		// Token: 0x06011738 RID: 71480 RVA: 0x00511176 File Offset: 0x0050F576
		public TAPGraduationItem(MasterSysGiftTable masterSysGiftTableItem)
		{
			this.CreateGo(masterSysGiftTableItem);
		}

		// Token: 0x17001DB2 RID: 7602
		// (get) Token: 0x06011739 RID: 71481 RVA: 0x00511185 File Offset: 0x0050F585
		// (set) Token: 0x0601173A RID: 71482 RVA: 0x0051118D File Offset: 0x0050F58D
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

		// Token: 0x0601173B RID: 71483 RVA: 0x00511198 File Offset: 0x0050F598
		public void CreateGo(MasterSysGiftTable masterSysGiftTableItem)
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/TAP/TAPGraduationItem", true, 0U);
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
			this.mImage = component.GetGameObject("Image");
			if (null != this.mGetReward)
			{
				this.mGetReward.onClick.RemoveAllListeners();
				this.mGetReward.onClick.AddListener(delegate()
				{
				});
			}
			this.UpdateRewardJar();
		}

		// Token: 0x0601173C RID: 71484 RVA: 0x00511290 File Offset: 0x0050F690
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
			if (this.myMasterSysGiftTableData.Param == 0)
			{
				this.mScore.CustomActive(false);
			}
			else
			{
				this.mScore.CustomActive(true);
				this.mScore.text = this.myMasterSysGiftTableData.Param.ToString();
			}
		}

		// Token: 0x0601173D RID: 71485 RVA: 0x0051135D File Offset: 0x0050F75D
		private void _OnShowTips(ItemData result)
		{
			if (result == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(result, null, 4, true, false, true);
		}

		// Token: 0x0601173E RID: 71486 RVA: 0x00511376 File Offset: 0x0050F776
		public int GetScore()
		{
			return this.myMasterSysGiftTableData.Param;
		}

		// Token: 0x0601173F RID: 71487 RVA: 0x00511383 File Offset: 0x0050F783
		public void SetActiveImage(bool flag)
		{
			if (this.myMasterSysGiftTableData.Param == 0)
			{
				this.mImage.CustomActive(false);
			}
			else
			{
				this.mImage.CustomActive(flag);
			}
		}

		// Token: 0x0400B536 RID: 46390
		private const string learningRewardItemPath = "UIFlatten/Prefabs/TAP/TAPGraduationItem";

		// Token: 0x0400B537 RID: 46391
		private GameObject mItemRoot;

		// Token: 0x0400B538 RID: 46392
		private Text mScore;

		// Token: 0x0400B539 RID: 46393
		private GameObject mFinished;

		// Token: 0x0400B53A RID: 46394
		private Button mGetReward;

		// Token: 0x0400B53B RID: 46395
		private GameObject mImage;

		// Token: 0x0400B53C RID: 46396
		private GameObject thisGameObject;

		// Token: 0x0400B53D RID: 46397
		private MasterSysGiftTable myMasterSysGiftTableData;
	}
}
