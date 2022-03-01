using System;
using Network;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018AD RID: 6317
	public class ReservationUpgradeActivityView : LimitTimeActivityViewCommon
	{
		// Token: 0x0600F700 RID: 63232 RVA: 0x0042CBAC File Offset: 0x0042AFAC
		public override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			base.Init(model, onItemClick);
			this.mTextCoin.SafeSetText(string.Format(TR.Value("activity_reservation_upgrade_coin_num"), DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_ACTIVITY_COIN_NUM)));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
			if (this.mGoRoleSelectBtn != null)
			{
				this.mGoRoleSelectBtn.SafeAddOnClickListener(new UnityAction(this.OnGoRoleSelectBtnClick));
			}
		}

		// Token: 0x0600F701 RID: 63233 RVA: 0x0042CC34 File Offset: 0x0042B034
		public override void Dispose()
		{
			base.Dispose();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
			if (this.mGoRoleSelectBtn != null)
			{
				this.mGoRoleSelectBtn.SafeRemoveOnClickListener(new UnityAction(this.OnGoRoleSelectBtnClick));
			}
		}

		// Token: 0x0600F702 RID: 63234 RVA: 0x0042CC8A File Offset: 0x0042B08A
		private void _OnCountValueChanged(UIEvent uiEvent)
		{
			this.mTextCoin.SafeSetText(string.Format(TR.Value("activity_reservation_upgrade_coin_num"), DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_ACTIVITY_COIN_NUM)));
		}

		// Token: 0x0600F703 RID: 63235 RVA: 0x0042CCBC File Offset: 0x0042B0BC
		private void OnGoRoleSelectBtnClick()
		{
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = string.Format(TR.Value("limitactivity_xiariyuyue_conetnt"), new object[0]),
				IsShowNotify = false,
				LeftButtonText = TR.Value("limitactivity_xiariyuyue_cancel"),
				RightButtonText = TR.Value("limitactivity_xiariyuyue_ok"),
				OnRightButtonClickCallBack = new Action(this.OnOKBtnClick)
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x0600F704 RID: 63236 RVA: 0x0042CD2C File Offset: 0x0042B12C
		private void OnOKBtnClick()
		{
			RoleSwitchReq cmd = new RoleSwitchReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<RoleSwitchReq>(ServerType.GATE_SERVER, cmd);
			ClientSystemLogin.mSwitchRole = true;
			Singleton<SDKVoiceManager>.GetInstance().LeaveVoiceSDK(false);
		}

		// Token: 0x040097E3 RID: 38883
		[SerializeField]
		private Text mTextCoin;

		// Token: 0x040097E4 RID: 38884
		[SerializeField]
		private Button mGoRoleSelectBtn;
	}
}
