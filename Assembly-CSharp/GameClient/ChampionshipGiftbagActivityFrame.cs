using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014D9 RID: 5337
	public class ChampionshipGiftbagActivityFrame : ClientFrame
	{
		// Token: 0x0600CF02 RID: 52994 RVA: 0x00330F6C File Offset: 0x0032F36C
		protected override void _bindExUI()
		{
			this.mCloseButton = this.mBind.GetCom<Button>("closeButton");
			this.mCloseButton.onClick.AddListener(new UnityAction(this._onCloseButtonButtonClick));
			this.mChampionshipGiftbagActivityView = this.mBind.GetCom<ChampionshipGiftbagActivityView>("ChampionshipGiftbagActivityView");
		}

		// Token: 0x0600CF03 RID: 52995 RVA: 0x00330FC1 File Offset: 0x0032F3C1
		protected override void _unbindExUI()
		{
			this.mCloseButton.onClick.RemoveListener(new UnityAction(this._onCloseButtonButtonClick));
			this.mCloseButton = null;
			this.mChampionshipGiftbagActivityView = null;
		}

		// Token: 0x0600CF04 RID: 52996 RVA: 0x00330FED File Offset: 0x0032F3ED
		private void _onCloseButtonButtonClick()
		{
			this.frameMgr.CloseFrame<ChampionshipGiftbagActivityFrame>(this, false);
		}

		// Token: 0x0600CF05 RID: 52997 RVA: 0x00330FFC File Offset: 0x0032F3FC
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Championship/Activity/ChampionshipGiftbagActivityFrame";
		}

		// Token: 0x0600CF06 RID: 52998 RVA: 0x00331004 File Offset: 0x0032F404
		protected override void _OnOpenFrame()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityLimitTimeMallDataChanged, new ClientEventSystem.UIEventHandler(this.OnActivityLimitTimeMallDataChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityLimitTimeDataUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityLimitTimeDataUpdate));
			OpActivityData activeDataFromType = DataManager<ActivityDataManager>.GetInstance().GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType.OAT_CHAMPIOSHIPGIFTBAGACTIVITY);
			if (activeDataFromType != null)
			{
				this.mMallType = (MallTypeTable.eMallType)activeDataFromType.parm;
				this.mMallItemInfo = DataManager<ActivityDataManager>.GetInstance().GetGiftPackInfos(this.mMallType);
				this.mDataModel = new LimitTimeActivityModel(activeDataFromType, string.Empty, null, null, null);
				if (this.mChampionshipGiftbagActivityView != null)
				{
					this.mChampionshipGiftbagActivityView.InitView(this.mDataModel, this.mMallType, this.mMallItemInfo, new ActivityItemBase.OnActivityItemClick<int>(this.OnItemClick));
				}
				DataManager<ActivityDataManager>.GetInstance().RequestMallGiftData(this.mMallType);
			}
		}

		// Token: 0x0600CF07 RID: 52999 RVA: 0x003310DD File Offset: 0x0032F4DD
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityLimitTimeMallDataChanged, new ClientEventSystem.UIEventHandler(this.OnActivityLimitTimeMallDataChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityLimitTimeDataUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityLimitTimeDataUpdate));
		}

		// Token: 0x0600CF08 RID: 53000 RVA: 0x00331115 File Offset: 0x0032F515
		private void OnItemClick(int taskId, int param, ulong param2)
		{
			DataManager<ActivityDataManager>.GetInstance().RequestOnTakeActTask(this.mDataModel.Id, (uint)taskId, 0UL);
		}

		// Token: 0x0600CF09 RID: 53001 RVA: 0x00331130 File Offset: 0x0032F530
		private void OnActivityLimitTimeMallDataChanged(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			byte b = (byte)uiEvent.Param1;
			if (b != (byte)this.mMallType)
			{
				return;
			}
			List<MallItemInfo> giftPackInfos = DataManager<ActivityDataManager>.GetInstance().GetGiftPackInfos(this.mMallType);
			if (this.mChampionshipGiftbagActivityView != null)
			{
				this.mChampionshipGiftbagActivityView.UpdateRightGiftItemStatus(giftPackInfos);
			}
		}

		// Token: 0x0600CF0A RID: 53002 RVA: 0x00331198 File Offset: 0x0032F598
		private void OnActivityLimitTimeDataUpdate(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			uint num = (uint)uiEvent.Param1;
			if (num == (uint)DataManager<ActivityDataManager>.GetInstance().GetActiveIdFromType(ActivityLimitTimeFactory.EActivityType.OAT_CHAMPIOSHIPGIFTBAGACTIVITY) && !DataManager<ActivityDataManager>.GetInstance().CheckChampionshipActivityIsOpen())
			{
				this._onCloseButtonButtonClick();
			}
		}

		// Token: 0x040078ED RID: 30957
		private Button mCloseButton;

		// Token: 0x040078EE RID: 30958
		private ChampionshipGiftbagActivityView mChampionshipGiftbagActivityView;

		// Token: 0x040078EF RID: 30959
		protected ILimitTimeActivityModel mDataModel;

		// Token: 0x040078F0 RID: 30960
		protected MallTypeTable.eMallType mMallType;

		// Token: 0x040078F1 RID: 30961
		protected List<MallItemInfo> mMallItemInfo;
	}
}
