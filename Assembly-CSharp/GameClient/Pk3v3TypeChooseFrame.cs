using System;
using Protocol;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019AC RID: 6572
	public class Pk3v3TypeChooseFrame : ClientFrame
	{
		// Token: 0x06010088 RID: 65672 RVA: 0x00472DC0 File Offset: 0x004711C0
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk3v3/Pk3v3TypeChooseFrame";
		}

		// Token: 0x06010089 RID: 65673 RVA: 0x00472DC7 File Offset: 0x004711C7
		protected override void _OnOpenFrame()
		{
			this.InitInterface();
			this.BindUIEvent();
		}

		// Token: 0x0601008A RID: 65674 RVA: 0x00472DD5 File Offset: 0x004711D5
		protected override void _OnCloseFrame()
		{
			this.ClearData();
			this.UnBindUIEvent();
		}

		// Token: 0x0601008B RID: 65675 RVA: 0x00472DE3 File Offset: 0x004711E3
		private void ClearData()
		{
			this.iMinLv = 0;
			this.iMinRankLv = 0;
		}

		// Token: 0x0601008C RID: 65676 RVA: 0x00472DF3 File Offset: 0x004711F3
		protected void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3RoomInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnPk3v3RoomInfoUpdate));
		}

		// Token: 0x0601008D RID: 65677 RVA: 0x00472E10 File Offset: 0x00471210
		protected void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3RoomInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnPk3v3RoomInfoUpdate));
		}

		// Token: 0x0601008E RID: 65678 RVA: 0x00472E2D File Offset: 0x0047122D
		private void OnPk3v3RoomInfoUpdate(UIEvent iEvent)
		{
			this.frameMgr.CloseFrame<Pk3v3TypeChooseFrame>(this, false);
		}

		// Token: 0x0601008F RID: 65679 RVA: 0x00472E3C File Offset: 0x0047123C
		private void InitInterface()
		{
			this.iMinLv = Utility.GetFunctionUnlockLevel(FunctionUnLock.eFuncType.Duel);
			this.iMinRankLv = DataManager<SeasonDataManager>.GetInstance().GetMinRankID();
		}

		// Token: 0x06010090 RID: 65680 RVA: 0x00472E5C File Offset: 0x0047125C
		protected override void _bindExUI()
		{
			this.mBtAmusement = this.mBind.GetCom<Button>("btAmusement");
			this.mBtAmusement.onClick.AddListener(new UnityAction(this._onBtAmusementButtonClick));
			this.mBtMatch = this.mBind.GetCom<Button>("btMatch");
			this.mBtMatch.onClick.AddListener(new UnityAction(this._onBtMatchButtonClick));
			this.mBtClose = this.mBind.GetCom<Button>("btClose");
			this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			this.mTgCreatePassword = this.mBind.GetCom<Toggle>("tgCreatePassword");
			this.mTgCreatePassword.onValueChanged.AddListener(new UnityAction<bool>(this._onTgCreatePasswordToggleValueChange));
			this.mPassword = this.mBind.GetCom<Text>("Password");
			this.mPasswordTips = this.mBind.GetCom<Text>("PasswordTips");
		}

		// Token: 0x06010091 RID: 65681 RVA: 0x00472F60 File Offset: 0x00471360
		protected override void _unbindExUI()
		{
			this.mBtAmusement.onClick.RemoveListener(new UnityAction(this._onBtAmusementButtonClick));
			this.mBtAmusement = null;
			this.mBtMatch.onClick.RemoveListener(new UnityAction(this._onBtMatchButtonClick));
			this.mBtMatch = null;
			this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtClose = null;
			this.mTgCreatePassword.onValueChanged.RemoveListener(new UnityAction<bool>(this._onTgCreatePasswordToggleValueChange));
			this.mTgCreatePassword = null;
			this.mPassword = null;
			this.mPasswordTips = null;
		}

		// Token: 0x06010092 RID: 65682 RVA: 0x00473007 File Offset: 0x00471407
		private void _onBtAmusementButtonClick()
		{
			DataManager<Pk3v3DataManager>.GetInstance().SendCreateRoomReq(RoomType.ROOM_TYPE_THREE_FREE);
		}

		// Token: 0x06010093 RID: 65683 RVA: 0x00473014 File Offset: 0x00471414
		private void _onBtMatchButtonClick()
		{
			if (DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsTypeFuncLock(ServiceType.SERVICE_3v3_TUMBLE))
			{
				SystemNotifyManager.SystemNotify(5, string.Empty);
				return;
			}
			DataManager<Pk3v3DataManager>.GetInstance().SendCreateRoomReq(RoomType.ROOM_TYPE_MELEE);
		}

		// Token: 0x06010094 RID: 65684 RVA: 0x0047303E File Offset: 0x0047143E
		private void _onBtCloseButtonClick()
		{
			this.frameMgr.CloseFrame<Pk3v3TypeChooseFrame>(this, false);
		}

		// Token: 0x06010095 RID: 65685 RVA: 0x00473050 File Offset: 0x00471450
		private void _onTgCreatePasswordToggleValueChange(bool changed)
		{
			DataManager<Pk3v3DataManager>.GetInstance().bHasPassword = changed;
			if (changed)
			{
				DataManager<Pk3v3DataManager>.GetInstance().PassWord = DataManager<Pk3v3DataManager>.GetInstance().RandPassWord().ToString();
			}
			else
			{
				DataManager<Pk3v3DataManager>.GetInstance().PassWord = string.Empty;
			}
			this.mPasswordTips.gameObject.CustomActive(!changed);
			this.mPassword.text = DataManager<Pk3v3DataManager>.GetInstance().PassWord;
		}

		// Token: 0x0400A1D6 RID: 41430
		private int iMinLv;

		// Token: 0x0400A1D7 RID: 41431
		private int iMinRankLv;

		// Token: 0x0400A1D8 RID: 41432
		private Button mBtAmusement;

		// Token: 0x0400A1D9 RID: 41433
		private Button mBtMatch;

		// Token: 0x0400A1DA RID: 41434
		private Button mBtClose;

		// Token: 0x0400A1DB RID: 41435
		private Toggle mTgCreatePassword;

		// Token: 0x0400A1DC RID: 41436
		private Text mPassword;

		// Token: 0x0400A1DD RID: 41437
		private Text mPasswordTips;
	}
}
