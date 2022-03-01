using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A98 RID: 6808
	public class WeekSignInTotalAwardItem : MonoBehaviour
	{
		// Token: 0x06010B79 RID: 68473 RVA: 0x004BDD7B File Offset: 0x004BC17B
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x06010B7A RID: 68474 RVA: 0x004BDD83 File Offset: 0x004BC183
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x06010B7B RID: 68475 RVA: 0x004BDD91 File Offset: 0x004BC191
		private void BindEvents()
		{
			if (this.totalAwardItemButton != null)
			{
				this.totalAwardItemButton.onClick.RemoveAllListeners();
				this.totalAwardItemButton.onClick.AddListener(new UnityAction(this.OnTotalAwardItemClicked));
			}
		}

		// Token: 0x06010B7C RID: 68476 RVA: 0x004BDDD0 File Offset: 0x004BC1D0
		private void UnBindEvents()
		{
			if (this.totalAwardItemButton != null)
			{
				this.totalAwardItemButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06010B7D RID: 68477 RVA: 0x004BDDF3 File Offset: 0x004BC1F3
		private void ClearData()
		{
			this._weekSignInType = WeekSignInType.None;
			this._weekSignSumTable = null;
			this._weekSignInAwardState = WeekSignInAwardState.None;
			this._commonNewItem = null;
		}

		// Token: 0x06010B7E RID: 68478 RVA: 0x004BDE14 File Offset: 0x004BC214
		public void InitItem(WeekSignInType weekSignInType, WeekSignSumTable weekSignSumTable)
		{
			this._weekSignInType = weekSignInType;
			this._weekSignSumTable = weekSignSumTable;
			if (this._weekSignSumTable == null)
			{
				Logger.LogErrorFormat("WeekSignSumTable null", new object[0]);
				return;
			}
			if (this._weekSignInType != WeekSignInType.ActivityWeekSignIn && this._weekSignInType != WeekSignInType.NewPlayerWeekSignIn)
			{
				return;
			}
			this._weekSignInAwardState = WeekSignInUtility.GetWeekSignInTotalAwardState(this._weekSignInType, this._weekSignSumTable);
			this.InitItemView();
		}

		// Token: 0x06010B7F RID: 68479 RVA: 0x004BDE84 File Offset: 0x004BC284
		public void OnItemUpdate()
		{
			if (this._weekSignSumTable == null)
			{
				return;
			}
			WeekSignInAwardState weekSignInTotalAwardState = WeekSignInUtility.GetWeekSignInTotalAwardState(this._weekSignInType, this._weekSignSumTable);
			if (weekSignInTotalAwardState != this._weekSignInAwardState)
			{
				this._weekSignInAwardState = weekSignInTotalAwardState;
				this.UpdateAwardItemState();
			}
		}

		// Token: 0x06010B80 RID: 68480 RVA: 0x004BDEC8 File Offset: 0x004BC2C8
		private void InitItemView()
		{
			CommonNewItemDataModel dataModel = new CommonNewItemDataModel
			{
				ItemId = this._weekSignSumTable.rewardId,
				ItemCount = this._weekSignSumTable.rewardNum
			};
			if (this.itemRoot != null)
			{
				this._commonNewItem = this.itemRoot.GetComponentInChildren<CommonNewItem>();
				if (this._commonNewItem == null)
				{
					this._commonNewItem = CommonUtility.CreateCommonNewItem(this.itemRoot);
				}
			}
			if (this._commonNewItem != null)
			{
				this._commonNewItem.InitItem(dataModel);
				this._commonNewItem.SetItemCountFontSize(28);
				this._commonNewItem.SetItemLevelFontSize(28);
			}
			if (this.totalWeekLabel != null)
			{
				this.totalWeekLabel.text = TR.Value("week_sing_in_total_week", this._weekSignSumTable.weekSum);
			}
			this.UpdateAwardItemState();
		}

		// Token: 0x06010B81 RID: 68481 RVA: 0x004BDFB8 File Offset: 0x004BC3B8
		private void UpdateAwardItemState()
		{
			this.ResetItemFlag();
			if (this._weekSignSumTable == null)
			{
				return;
			}
			if (this._weekSignInAwardState == WeekSignInAwardState.Received)
			{
				this.UpdateFlag(this.totalAwardReceivedFlag, true);
			}
			else if (this._weekSignInAwardState == WeekSignInAwardState.Finished)
			{
				this.UpdateFlag(this.totalAwardFinishFlag, true);
				this.UpdateTotalAwardItemButton(true);
			}
		}

		// Token: 0x06010B82 RID: 68482 RVA: 0x004BE015 File Offset: 0x004BC415
		private void ResetItemFlag()
		{
			this.UpdateFlag(this.totalAwardFinishFlag, false);
			this.UpdateFlag(this.totalAwardReceivedFlag, false);
			this.UpdateTotalAwardItemButton(false);
		}

		// Token: 0x06010B83 RID: 68483 RVA: 0x004BE038 File Offset: 0x004BC438
		private void UpdateTotalAwardItemButton(bool flag)
		{
			if (this.totalAwardItemButton != null)
			{
				this.totalAwardItemButton.gameObject.CustomActive(flag);
			}
		}

		// Token: 0x06010B84 RID: 68484 RVA: 0x004BE05C File Offset: 0x004BC45C
		private void UpdateFlag(GameObject flag, bool state)
		{
			if (flag != null)
			{
				flag.CustomActive(state);
			}
		}

		// Token: 0x06010B85 RID: 68485 RVA: 0x004BE071 File Offset: 0x004BC471
		private void OnTotalAwardItemClicked()
		{
			if (this._weekSignSumTable == null)
			{
				return;
			}
			if (this._weekSignInAwardState == WeekSignInAwardState.Finished)
			{
				DataManager<WeekSignInDataManager>.GetInstance().SendSceneWeekSignRewardReq((uint)this._weekSignSumTable.opActType, (uint)this._weekSignSumTable.weekSum);
			}
		}

		// Token: 0x0400AAF1 RID: 43761
		private WeekSignInType _weekSignInType;

		// Token: 0x0400AAF2 RID: 43762
		private WeekSignSumTable _weekSignSumTable;

		// Token: 0x0400AAF3 RID: 43763
		private WeekSignInAwardState _weekSignInAwardState;

		// Token: 0x0400AAF4 RID: 43764
		private CommonNewItem _commonNewItem;

		// Token: 0x0400AAF5 RID: 43765
		[Space(10f)]
		[Header("item")]
		[Space(10f)]
		[SerializeField]
		private GameObject itemRoot;

		// Token: 0x0400AAF6 RID: 43766
		[Space(10f)]
		[Header("Content")]
		[Space(10f)]
		[SerializeField]
		private Text totalWeekLabel;

		// Token: 0x0400AAF7 RID: 43767
		[SerializeField]
		private GameObject totalAwardReceivedFlag;

		// Token: 0x0400AAF8 RID: 43768
		[SerializeField]
		private GameObject totalAwardFinishFlag;

		// Token: 0x0400AAF9 RID: 43769
		[SerializeField]
		private Button totalAwardItemButton;
	}
}
