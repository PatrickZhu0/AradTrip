using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018E1 RID: 6369
	public class CompetitionSupportItem : ActivityItemBase
	{
		// Token: 0x0600F89E RID: 63646 RVA: 0x0043A798 File Offset: 0x00438B98
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			if (data == null)
			{
				return;
			}
			this.mReceiveBtn.CustomActive(false);
			this.mGoBtn.CustomActive(false);
			this.mHasReceiveGo.CustomActive(false);
			if (this.isLeftMinusThan0)
			{
				switch (data.State)
				{
				case OpActTaskState.OATS_INIT:
				case OpActTaskState.OATS_UNFINISH:
					this.mGoBtn.CustomActive(true);
					break;
				case OpActTaskState.OATS_FINISHED:
					this.mReceiveBtn.CustomActive(true);
					break;
				case OpActTaskState.OATS_OVER:
					this.mHasReceiveGo.CustomActive(true);
					break;
				}
			}
			else
			{
				this.mHasReceiveGo.CustomActive(true);
			}
		}

		// Token: 0x0600F89F RID: 63647 RVA: 0x0043A84C File Offset: 0x00438C4C
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (data == null)
			{
				return;
			}
			this.mData = data;
			int linkId = (int)data.ParamNums2[0];
			this.mTaskName.SafeSetText(data.taskName);
			this.mTaskDesc.SafeSetText(data.Desc);
			this.mGoBtn.SafeRemoveAllListener();
			this.mGoBtn.SafeAddOnClickListener(delegate
			{
				this.OnGoBtnClick(linkId);
			});
			this.mReceiveBtn.SafeRemoveAllListener();
			this.mReceiveBtn.SafeAddOnClickListener(new UnityAction(this.OnReceiveBtnClick));
			if (data.AwardDataList != null)
			{
				for (int i = 0; i < data.AwardDataList.Count; i++)
				{
					OpTaskReward opTaskReward = data.AwardDataList[i];
					if (opTaskReward != null)
					{
						ComItem comItem = ComItemManager.Create(this.mItemContent.gameObject);
						if (comItem != null)
						{
							ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)opTaskReward.id, 100, 0);
							itemData.Count = (int)opTaskReward.num;
							ComItem comItem2 = comItem;
							ItemData item = itemData;
							if (CompetitionSupportItem.<>f__mg$cache0 == null)
							{
								CompetitionSupportItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
							}
							comItem2.Setup(item, CompetitionSupportItem.<>f__mg$cache0);
							this.mComItems.Add(comItem);
							(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
						}
					}
				}
			}
			base.RegisterAccountData(new ClientEventSystem.UIEventHandler(this.OnActivityCounterUpdate));
			base.OnRequsetAccountData(this.mData);
		}

		// Token: 0x0600F8A0 RID: 63648 RVA: 0x0043A9CC File Offset: 0x00438DCC
		private void OnGoBtnClick(int linkId)
		{
			AcquiredMethodTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AcquiredMethodTable>(linkId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(tableItem.LinkInfo, null, false);
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<LimitTimeActivityFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<LimitTimeActivityFrame>(null, false);
			}
		}

		// Token: 0x0600F8A1 RID: 63649 RVA: 0x0043AA24 File Offset: 0x00438E24
		private void OnReceiveBtnClick()
		{
			this._OnItemClick();
			this.OnRequsetAccountData(this.mData);
		}

		// Token: 0x0600F8A2 RID: 63650 RVA: 0x0043AA38 File Offset: 0x00438E38
		public override void Dispose()
		{
			base.Dispose();
			if (this.mComItems != null)
			{
				for (int i = this.mComItems.Count - 1; i >= 0; i--)
				{
					ComItemManager.Destroy(this.mComItems[i]);
				}
				this.mComItems.Clear();
			}
			this.mGoBtn.SafeRemoveAllListener();
			this.mReceiveBtn.SafeRemoveOnClickListener(new UnityAction(this.OnReceiveBtnClick));
		}

		// Token: 0x0600F8A3 RID: 63651 RVA: 0x0043AAB2 File Offset: 0x00438EB2
		private void OnActivityCounterUpdate(UIEvent uiEvent)
		{
			if (this.mData != null && (uint)uiEvent.Param1 == this.mData.DataId)
			{
				this.ShowHaveUsedNumState();
			}
		}

		// Token: 0x0600F8A4 RID: 63652 RVA: 0x0043AAE0 File Offset: 0x00438EE0
		private void ShowHaveUsedNumState()
		{
			if (this.mData != null)
			{
				int accountDailySubmitLimit = this.mData.AccountDailySubmitLimit;
				int accountTotalSubmitLimit = this.mData.AccountTotalSubmitLimit;
				int num = 0;
				if (accountDailySubmitLimit > 0)
				{
					num = accountDailySubmitLimit;
				}
				if (accountTotalSubmitLimit > 0)
				{
					num = accountTotalSubmitLimit;
				}
				if (num > 0)
				{
					int activityConunter = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(this.mData.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_TOTAL_SUBMIT_TASK);
					int num2 = num - activityConunter;
					if (num2 < 0)
					{
						num2 = 0;
					}
					if (num2 <= 0)
					{
						this.isLeftMinusThan0 = false;
						this.mReceiveBtn.CustomActive(false);
						this.mGoBtn.CustomActive(false);
						this.mHasReceiveGo.CustomActive(true);
					}
				}
			}
		}

		// Token: 0x040099F5 RID: 39413
		[SerializeField]
		private Text mTaskName;

		// Token: 0x040099F6 RID: 39414
		[SerializeField]
		private Text mTaskDesc;

		// Token: 0x040099F7 RID: 39415
		[SerializeField]
		private GameObject mItemContent;

		// Token: 0x040099F8 RID: 39416
		[SerializeField]
		private Button mReceiveBtn;

		// Token: 0x040099F9 RID: 39417
		[SerializeField]
		private Button mGoBtn;

		// Token: 0x040099FA RID: 39418
		[SerializeField]
		private GameObject mHasReceiveGo;

		// Token: 0x040099FB RID: 39419
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x040099FC RID: 39420
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x040099FD RID: 39421
		private ILimitTimeActivityTaskDataModel mData;

		// Token: 0x040099FE RID: 39422
		private bool isLeftMinusThan0 = true;

		// Token: 0x040099FF RID: 39423
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
