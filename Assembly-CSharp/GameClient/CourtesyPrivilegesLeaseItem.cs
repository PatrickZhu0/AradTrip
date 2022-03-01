using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200181F RID: 6175
	public class CourtesyPrivilegesLeaseItem : ActivityItemBase
	{
		// Token: 0x0600F33D RID: 62269 RVA: 0x0041BE84 File Offset: 0x0041A284
		private void Awake()
		{
			if (this.mLeaseEquipmentBtn != null)
			{
				this.mLeaseEquipmentBtn.onClick.RemoveAllListeners();
				this.mLeaseEquipmentBtn.onClick.AddListener(new UnityAction(this._OnItemClick));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this.OnCounterChanged));
		}

		// Token: 0x0600F33E RID: 62270 RVA: 0x0041BEEC File Offset: 0x0041A2EC
		private void OnDestroy()
		{
			if (this.mLeaseEquipmentBtn != null)
			{
				this.mLeaseEquipmentBtn.onClick.RemoveListener(new UnityAction(this._OnItemClick));
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this.OnCounterChanged));
		}

		// Token: 0x0600F33F RID: 62271 RVA: 0x0041BF42 File Offset: 0x0041A342
		private void OnCounterChanged(UIEvent uIEvent)
		{
			this.UpdateData(this.limitTimeActivityTaskDataModel);
		}

		// Token: 0x0600F340 RID: 62272 RVA: 0x0041BF50 File Offset: 0x0041A350
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (data == null)
			{
				return;
			}
			if (data.ParamNums2.Count > 0)
			{
				this.limitLevel = (int)data.ParamNums2[0];
			}
			if (this.mTaskDesc != null)
			{
				this.mTaskDesc.text = data.Desc;
			}
			if (this.mLimitDesc != null)
			{
				this.mLimitDesc.text = TR.Value("grand_total_role_limit_desc", data.TotalNum);
			}
			if (data.AwardDataList != null)
			{
				for (int i = 0; i < data.AwardDataList.Count; i++)
				{
					OpTaskReward opTaskReward = data.AwardDataList[i];
					if (opTaskReward != null)
					{
						ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)opTaskReward.id, string.Empty, string.Empty);
						if (tableItem != null)
						{
							if (this.mName != null)
							{
								this.mName.text = CommonUtility.GetItemColorName(tableItem);
							}
							CommonNewItemDataModel dataModel = new CommonNewItemDataModel
							{
								ItemId = (int)opTaskReward.id,
								ItemCount = (int)opTaskReward.num
							};
							CommonNewItem commonNewItem = CommonUtility.CreateCommonNewItem(this.mItemRoot);
							if (commonNewItem != null)
							{
								commonNewItem.InitItem(dataModel);
								commonNewItem.SetItemCountFontSize(30);
								commonNewItem.SetItemLevelFontSize(30);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600F341 RID: 62273 RVA: 0x0041C0BC File Offset: 0x0041A4BC
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			if (data == null)
			{
				return;
			}
			this.limitTimeActivityTaskDataModel = data;
			if (this.mLeaseEquipmentGo != null)
			{
				this.mLeaseEquipmentGo.CustomActive(false);
			}
			if (this.mHasLeaseGo != null)
			{
				this.mHasLeaseGo.CustomActive(false);
			}
			switch (data.State)
			{
			case OpActTaskState.OATS_INIT:
			case OpActTaskState.OATS_UNFINISH:
				if (this.mLeaseEquipmentGo != null)
				{
					this.mLeaseEquipmentGo.CustomActive(true);
				}
				this.UpdateLeaseButton(false);
				break;
			case OpActTaskState.OATS_FINISHED:
			{
				if (this.mLeaseEquipmentGo != null)
				{
					this.mLeaseEquipmentGo.CustomActive(true);
				}
				if ((int)DataManager<PlayerBaseData>.GetInstance().Level < this.limitLevel)
				{
					this.UpdateLeaseButton(false);
					return;
				}
				int count = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.GIFT_RIGHT_CARD);
				if (count == 1)
				{
					this.UpdateLeaseButton(true);
				}
				else
				{
					this.UpdateLeaseButton(false);
				}
				break;
			}
			case OpActTaskState.OATS_OVER:
				if (this.mLeaseEquipmentGo != null)
				{
					this.mLeaseEquipmentGo.CustomActive(false);
				}
				if (this.mHasLeaseGo != null)
				{
					this.mHasLeaseGo.CustomActive(true);
				}
				break;
			}
		}

		// Token: 0x0600F342 RID: 62274 RVA: 0x0041C20C File Offset: 0x0041A60C
		private void UpdateLeaseButton(bool flag)
		{
			if (this.mLeaseEquipmentBtn != null)
			{
				this.mLeaseEquipmentBtn.enabled = flag;
			}
			if (this.mLeaseEquipmentGray != null)
			{
				this.mLeaseEquipmentGray.enabled = !flag;
			}
		}

		// Token: 0x040095BD RID: 38333
		[SerializeField]
		private Text mName;

		// Token: 0x040095BE RID: 38334
		[SerializeField]
		private GameObject mItemRoot;

		// Token: 0x040095BF RID: 38335
		[SerializeField]
		private GameObject mHasLeaseGo;

		// Token: 0x040095C0 RID: 38336
		[SerializeField]
		private GameObject mLeaseEquipmentGo;

		// Token: 0x040095C1 RID: 38337
		[SerializeField]
		private Button mLeaseEquipmentBtn;

		// Token: 0x040095C2 RID: 38338
		[SerializeField]
		private UIGray mLeaseEquipmentGray;

		// Token: 0x040095C3 RID: 38339
		[SerializeField]
		private Text mTaskDesc;

		// Token: 0x040095C4 RID: 38340
		[SerializeField]
		private Text mLimitDesc;

		// Token: 0x040095C5 RID: 38341
		private ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel;

		// Token: 0x040095C6 RID: 38342
		private int limitLevel;
	}
}
