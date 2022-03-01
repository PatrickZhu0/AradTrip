using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020013C3 RID: 5059
	public class WarriorRecruitItem : MonoBehaviour
	{
		// Token: 0x0600C467 RID: 50279 RVA: 0x002F286C File Offset: 0x002F0C6C
		public void OnItemVisiable(WarriorRecruitTaskDataModel taskData, int index)
		{
			this.mTaskDataModel = taskData;
			if (this.mTaskDataModel == null)
			{
				return;
			}
			if (this.mTaskName != null)
			{
				this.mTaskName.text = this.mTaskDataModel.taskDesc;
			}
			if (this.mGlassBtn != null)
			{
				this.mGlassBtn.CustomActive(this.mTaskDataModel.taskType == 9 && this.mTaskDataModel.identify == 4);
			}
			this.mGlassBtn.SafeRemoveAllListener();
			this.mGlassBtn.SafeAddOnClickListener(new UnityAction(this.OnGlassBtnClick));
			this.mReceiveBtn.SafeRemoveAllListener();
			this.mReceiveBtn.SafeAddOnClickListener(new UnityAction(this.OnReceiveBtnClick));
			this.mGoBtn.SafeRemoveAllListener();
			this.mGoBtn.SafeAddOnClickListener(new UnityAction(this.OnGoBtnClick));
			this.CreatRewardItem(this.mTaskDataModel);
			this.UpdateTaskInfo(this.mTaskDataModel);
			this.mBgGo.CustomActive(index % 2 == 0);
		}

		// Token: 0x0600C468 RID: 50280 RVA: 0x002F2984 File Offset: 0x002F0D84
		private void CreatRewardItem(WarriorRecruitTaskDataModel data)
		{
			for (int i = 0; i < this.rewardsComBindList.Count; i++)
			{
				this.rewardsComBindList[i].CustomActive(false);
			}
			for (int j = 0; j < data.rewards.Count; j++)
			{
				ItemSimpleData itemSimpleData = data.rewards[j];
				if (itemSimpleData != null)
				{
					if (j < this.rewardsComBindList.Count)
					{
						ComCommonBind bind = this.rewardsComBindList[j];
						this.RefreshTaskRewardInfo(bind, itemSimpleData);
					}
					else
					{
						GameObject gameObject = Object.Instantiate<GameObject>(this.mItemPrefab);
						ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
						if (!(component == null))
						{
							this.RefreshTaskRewardInfo(component, itemSimpleData);
							Utility.AttachTo(gameObject, this.mItemParent, false);
							this.rewardsComBindList.Add(component);
						}
					}
				}
			}
		}

		// Token: 0x0600C469 RID: 50281 RVA: 0x002F2A6C File Offset: 0x002F0E6C
		private void RefreshTaskRewardInfo(ComCommonBind bind, ItemSimpleData reward)
		{
			bind.CustomActive(true);
			Image com = bind.GetCom<Image>("backgroud");
			Image com2 = bind.GetCom<Image>("Icon");
			Button com3 = bind.GetCom<Button>("Iconbtn");
			Text com4 = bind.GetCom<Text>("Count");
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(reward.ItemID, 100, 0);
			itemData.Count = reward.Count;
			if (com != null)
			{
				ETCImageLoader.LoadSprite(ref com, itemData.GetQualityInfo().Background, true);
			}
			if (com2 != null)
			{
				ETCImageLoader.LoadSprite(ref com2, itemData.Icon, true);
			}
			if (com4 != null)
			{
				com4.text = itemData.Count.ToString();
			}
			com3.SafeRemoveAllListener();
			com3.SafeAddOnClickListener(delegate
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
			});
		}

		// Token: 0x0600C46A RID: 50282 RVA: 0x002F2B64 File Offset: 0x002F0F64
		private void UpdateTaskInfo(WarriorRecruitTaskDataModel data)
		{
			if (this.mTaskProgress != null)
			{
				this.mTaskProgress.text = string.Format("{0}/{1}", data.cnt, data.fullcnt);
			}
			this.mReceiveBtn.CustomActive(false);
			this.mUnfinished.CustomActive(false);
			this.mHaveRreceive.CustomActive(false);
			this.mGoBtn.CustomActive(false);
			switch (data.state)
			{
			case 0:
			case 1:
				if (data.linkId != 0)
				{
					this.mGoBtn.CustomActive(true);
				}
				else
				{
					this.mUnfinished.CustomActive(true);
				}
				break;
			case 2:
				this.mReceiveBtn.CustomActive(true);
				break;
			case 5:
				this.mHaveRreceive.CustomActive(true);
				break;
			}
		}

		// Token: 0x0600C46B RID: 50283 RVA: 0x002F2C58 File Offset: 0x002F1058
		private void OnReceiveBtnClick()
		{
			if (this.mTaskDataModel != null)
			{
				if (this.mTaskDataModel.identify == 2 && !WarriorRecruitDataManager.isBindInviteCode)
				{
					SystemNotifyManager.SysNotifyTextAnimation("请先接受玩家招募", CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				DataManager<WarriorRecruitDataManager>.GetInstance().SendSubmitHireTaskReq(this.mTaskDataModel.taskId);
			}
		}

		// Token: 0x0600C46C RID: 50284 RVA: 0x002F2CAC File Offset: 0x002F10AC
		private void OnGlassBtnClick()
		{
			if (this.mTaskDataModel != null)
			{
				DataManager<WarriorRecruitDataManager>.GetInstance().SendQueryHireTaskAccidListReq(this.mTaskDataModel.taskId);
			}
		}

		// Token: 0x0600C46D RID: 50285 RVA: 0x002F2CD0 File Offset: 0x002F10D0
		private void OnGoBtnClick()
		{
			AcquiredMethodTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AcquiredMethodTable>(this.mTaskDataModel.linkId, string.Empty, string.Empty);
			if (tableItem != null && tableItem.IsLink != 0)
			{
				if (tableItem.FuncitonID != 0)
				{
					FunctionUnLock tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(tableItem.FuncitonID, string.Empty, string.Empty);
					if (tableItem2 != null && tableItem2.FinishLevel > (int)DataManager<PlayerBaseData>.GetInstance().Level)
					{
						SystemNotifyManager.SystemNotify(tableItem2.CommDescID, string.Empty);
						return;
					}
				}
				DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(tableItem.LinkInfo, null, false);
				ActiveChargeFrame.CloseMe();
			}
		}

		// Token: 0x0600C46E RID: 50286 RVA: 0x002F2D77 File Offset: 0x002F1177
		private void OnDestroy()
		{
			this.mTaskDataModel = null;
			this.rewardsComBindList.Clear();
		}

		// Token: 0x04006FD3 RID: 28627
		[SerializeField]
		private Text mTaskName;

		// Token: 0x04006FD4 RID: 28628
		[SerializeField]
		private Text mTaskProgress;

		// Token: 0x04006FD5 RID: 28629
		[SerializeField]
		private GameObject mRewardParent;

		// Token: 0x04006FD6 RID: 28630
		[SerializeField]
		private Button mReceiveBtn;

		// Token: 0x04006FD7 RID: 28631
		[SerializeField]
		private Button mGoBtn;

		// Token: 0x04006FD8 RID: 28632
		[SerializeField]
		private GameObject mUnfinished;

		// Token: 0x04006FD9 RID: 28633
		[SerializeField]
		private GameObject mHaveRreceive;

		// Token: 0x04006FDA RID: 28634
		[SerializeField]
		private GameObject mItemPrefab;

		// Token: 0x04006FDB RID: 28635
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x04006FDC RID: 28636
		[SerializeField]
		private Button mGlassBtn;

		// Token: 0x04006FDD RID: 28637
		[SerializeField]
		private GameObject mBgGo;

		// Token: 0x04006FDE RID: 28638
		private WarriorRecruitTaskDataModel mTaskDataModel;

		// Token: 0x04006FDF RID: 28639
		private List<ComCommonBind> rewardsComBindList = new List<ComCommonBind>();
	}
}
