using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001911 RID: 6417
	public class SwipePicturesToSendTicketsItem : ActivityItemBase
	{
		// Token: 0x0600F9D7 RID: 63959 RVA: 0x00445970 File Offset: 0x00443D70
		private void Awake()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnPullRecordsSuccessed, new ClientEventSystem.UIEventHandler(this.OnPullRecordsSuccessed));
			if (this.mGoToBtn != null)
			{
				this.mGoToBtn.onClick.RemoveAllListeners();
				this.mGoToBtn.onClick.AddListener(new UnityAction(this.OnGoToBtnClick));
			}
		}

		// Token: 0x0600F9D8 RID: 63960 RVA: 0x004459D8 File Offset: 0x00443DD8
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnPullRecordsSuccessed, new ClientEventSystem.UIEventHandler(this.OnPullRecordsSuccessed));
			if (this.mGoToBtn != null)
			{
				this.mGoToBtn.onClick.RemoveListener(new UnityAction(this.OnGoToBtnClick));
			}
		}

		// Token: 0x0600F9D9 RID: 63961 RVA: 0x00445A30 File Offset: 0x00443E30
		private void OnPullRecordsSuccessed(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			if (uiEvent.Param1 == null)
			{
				return;
			}
			if (uiEvent.Param2 == null)
			{
				return;
			}
			if (this.itemId != (uint)uiEvent.Param1)
			{
				return;
			}
			uint num = (uint)uiEvent.Param2;
			this.curNum = (int)num;
			this.UpdateProgressInfo();
		}

		// Token: 0x0600F9DA RID: 63962 RVA: 0x00445A8C File Offset: 0x00443E8C
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
		}

		// Token: 0x0600F9DB RID: 63963 RVA: 0x00445A90 File Offset: 0x00443E90
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (data == null)
			{
				return;
			}
			this.mData = data;
			this.totalNum = (int)data.TotalNum;
			if (data.ParamNums.Count > 0)
			{
				this.linkId = (int)data.ParamNums[0];
			}
			if (this.mTaskDesc != null)
			{
				this.mTaskDesc.text = data.Desc;
			}
			if (data.AwardDataList.Count > 0)
			{
				OpTaskReward opTaskReward = data.AwardDataList[0];
				this.itemId = opTaskReward.id;
				CommonNewItemDataModel dataModel = new CommonNewItemDataModel
				{
					ItemId = (int)opTaskReward.id,
					ItemCount = (int)opTaskReward.num
				};
				CommonNewItem commonNewItem = CommonUtility.CreateCommonNewItem(this.mItemRoot);
				if (commonNewItem != null)
				{
					commonNewItem.InitItem(dataModel);
					commonNewItem.SetItemCountFontSize(26);
					commonNewItem.SetItemLevelFontSize(26);
					(commonNewItem.transform as RectTransform).sizeDelta = this.mComItemSize;
				}
			}
			if (data.ParamNums2.Count > 0)
			{
				if (this.mProgressGo != null)
				{
					this.mProgressGo.CustomActive(true);
				}
				this.UpdateProgressInfo();
				DataManager<ActivityDataManager>.GetInstance().OnSendWorldGetSysRecordReq(1016U, (uint)DataManager<PlayerBaseData>.GetInstance().RoleID, this.itemId);
			}
			else if (this.mProgressGo != null)
			{
				this.mProgressGo.CustomActive(false);
			}
		}

		// Token: 0x0600F9DC RID: 63964 RVA: 0x00445C01 File Offset: 0x00444001
		private void UpdateProgressInfo()
		{
			if (this.mProgress != null)
			{
				this.mProgress.text = string.Format(this.mDesc, this.curNum, this.totalNum);
			}
		}

		// Token: 0x0600F9DD RID: 63965 RVA: 0x00445C40 File Offset: 0x00444040
		private void OnGoToBtnClick()
		{
			AcquiredMethodTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AcquiredMethodTable>(this.linkId, string.Empty, string.Empty);
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

		// Token: 0x04009BFD RID: 39933
		[SerializeField]
		private Text mTaskDesc;

		// Token: 0x04009BFE RID: 39934
		[SerializeField]
		private Text mProgress;

		// Token: 0x04009BFF RID: 39935
		[SerializeField]
		private GameObject mProgressGo;

		// Token: 0x04009C00 RID: 39936
		[SerializeField]
		private GameObject mItemRoot;

		// Token: 0x04009C01 RID: 39937
		[SerializeField]
		private Button mGoToBtn;

		// Token: 0x04009C02 RID: 39938
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(70f, 70f);

		// Token: 0x04009C03 RID: 39939
		[SerializeField]
		private string mDesc = "今日获得：{0}/{1}";

		// Token: 0x04009C04 RID: 39940
		private ILimitTimeActivityTaskDataModel mData;

		// Token: 0x04009C05 RID: 39941
		private int linkId;

		// Token: 0x04009C06 RID: 39942
		private int totalNum;

		// Token: 0x04009C07 RID: 39943
		private uint itemId;

		// Token: 0x04009C08 RID: 39944
		private int curNum;
	}
}
