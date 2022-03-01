using System;
using GameClient;
using Network;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x0200117B RID: 4475
public class ServerWaitQueueUp : ClientFrame
{
	// Token: 0x0600AB1F RID: 43807 RVA: 0x0024AFC8 File Offset: 0x002493C8
	public override string GetPrefabPath()
	{
		return "UIFlatten/Prefabs/Login/ServerWaitQueueFrame";
	}

	// Token: 0x0600AB20 RID: 43808 RVA: 0x0024AFD0 File Offset: 0x002493D0
	protected override void _bindExUI()
	{
		this.mQuitWaitQueueBtn = this.mBind.GetCom<Button>("QuitWaitQueueBtn");
		this.mQuitWaitQueueBtn.onClick.AddListener(new UnityAction(this._onQuitWaitQueueBtnButtonClick));
		this.mServerName = this.mBind.GetCom<Text>("ServerName");
		this.mShowLeftPlayerNum = this.mBind.GetCom<Text>("ShowLeftPlayerNum");
		this.mPreWaitTime = this.mBind.GetCom<Text>("PreWaitTime");
		this.mCheckQuitPlane = this.mBind.GetGameObject("CheckQuitPlane");
		this.mOkBtn = this.mBind.GetCom<Button>("OkBtn");
		this.mOkBtn.onClick.AddListener(new UnityAction(this._onOkBtnButtonClick));
		this.mCancelBtn = this.mBind.GetCom<Button>("CancelBtn");
		this.mCancelBtn.onClick.AddListener(new UnityAction(this._onCancelBtnButtonClick));
		this.mChangeBtn = this.mBind.GetCom<Button>("ChangeBtn");
		this.mChangeBtn.onClick.AddListener(new UnityAction(this._onChangeBtnButtonClick));
		this.mLeftTime = this.mBind.GetCom<ComTime>("leftTime");
		this.mWaitTimeRoot = this.mBind.GetGameObject("waitTimeRoot");
		this.mSuccessRoot = this.mBind.GetGameObject("successRoot");
	}

	// Token: 0x0600AB21 RID: 43809 RVA: 0x0024B140 File Offset: 0x00249540
	protected override void _unbindExUI()
	{
		this.mQuitWaitQueueBtn.onClick.RemoveListener(new UnityAction(this._onQuitWaitQueueBtnButtonClick));
		this.mQuitWaitQueueBtn = null;
		this.mServerName = null;
		this.mShowLeftPlayerNum = null;
		this.mPreWaitTime = null;
		this.mCheckQuitPlane = null;
		this.mOkBtn.onClick.RemoveListener(new UnityAction(this._onOkBtnButtonClick));
		this.mOkBtn = null;
		this.mCancelBtn.onClick.RemoveListener(new UnityAction(this._onCancelBtnButtonClick));
		this.mCancelBtn = null;
		this.mChangeBtn.onClick.RemoveListener(new UnityAction(this._onChangeBtnButtonClick));
		this.mChangeBtn = null;
		this.mLeftTime = null;
		this.mWaitTimeRoot = null;
		this.mSuccessRoot = null;
	}

	// Token: 0x0600AB22 RID: 43810 RVA: 0x0024B20A File Offset: 0x0024960A
	private void _onQuitWaitQueueBtnButtonClick()
	{
		this.mCheckQuitPlane.SetActive(true);
	}

	// Token: 0x0600AB23 RID: 43811 RVA: 0x0024B218 File Offset: 0x00249618
	private void _onCancelBtnButtonClick()
	{
		this.mCheckQuitPlane.SetActive(false);
	}

	// Token: 0x0600AB24 RID: 43812 RVA: 0x0024B226 File Offset: 0x00249626
	private void _onOkBtnButtonClick()
	{
		this.mQuitQueueType = ServerWaitQueueUp.eQuitQueueType.UserCancel;
		this._quitQueue();
	}

	// Token: 0x0600AB25 RID: 43813 RVA: 0x0024B235 File Offset: 0x00249635
	private void _onChangeBtnButtonClick()
	{
		Singleton<ClientSystemManager>.instance.OpenFrame<ServerListFrame>(FrameLayer.Middle, null, string.Empty);
	}

	// Token: 0x0600AB26 RID: 43814 RVA: 0x0024B24C File Offset: 0x0024964C
	protected override void _OnOpenFrame()
	{
		this.mCheckQuitPlane.SetActive(false);
		this.mServerName.text = ClientApplication.adminServer.name;
		this._setPlayerNum((uint)this.userData);
		this._bindEvents();
		this.mQuitQueueType = ServerWaitQueueUp.eQuitQueueType.None;
	}

	// Token: 0x0600AB27 RID: 43815 RVA: 0x0024B298 File Offset: 0x00249698
	private void _updateWaitTextTips()
	{
		if (null == this.mWaitTimeDesc)
		{
			this.mWaitTimeDesc = Utility.FindComponent<Text>("content/ItemParent/successRoot/PreWaitTime", true);
		}
		if (null == this.mWaitTimeDesc)
		{
			return;
		}
		this.mWaitTimeDesc.text = this.kWaitTimeDesc[this.mWaitTimeIdx % this.kWaitTimeDesc.Length];
		this.mWaitTimeIdx++;
		this.mWaitTimeIdx %= this.kWaitTimeDesc.Length;
	}

	// Token: 0x0600AB28 RID: 43816 RVA: 0x0024B31D File Offset: 0x0024971D
	protected override void _OnCloseFrame()
	{
		this._unbindEvents();
		this.mQuitQueueType = ServerWaitQueueUp.eQuitQueueType.None;
	}

	// Token: 0x0600AB29 RID: 43817 RVA: 0x0024B32C File Offset: 0x0024972C
	private void _bindEvents()
	{
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ServerListSelectChanged, new ClientEventSystem.UIEventHandler(this._onSeverListChanged));
	}

	// Token: 0x0600AB2A RID: 43818 RVA: 0x0024B349 File Offset: 0x00249749
	private void _unbindEvents()
	{
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ServerListSelectChanged, new ClientEventSystem.UIEventHandler(this._onSeverListChanged));
	}

	// Token: 0x0600AB2B RID: 43819 RVA: 0x0024B368 File Offset: 0x00249768
	private void _onSeverListChanged(UIEvent ui)
	{
		bool flag = (bool)ui.Param1;
		if (flag)
		{
			this.mQuitQueueType = ServerWaitQueueUp.eQuitQueueType.ServerListChanged;
			this._quitQueue();
		}
	}

	// Token: 0x0600AB2C RID: 43820 RVA: 0x0024B39C File Offset: 0x0024979C
	[MessageHandle(300316U, false, 0)]
	private void SyncWaitPlayerNum(MsgDATA data)
	{
		GateNotifyLoginWaitInfo gateNotifyLoginWaitInfo = new GateNotifyLoginWaitInfo();
		gateNotifyLoginWaitInfo.decode(data.bytes);
		this._setPlayerNum(gateNotifyLoginWaitInfo.waitPlayerNum);
	}

	// Token: 0x0600AB2D RID: 43821 RVA: 0x0024B3C7 File Offset: 0x002497C7
	private void _setPlayerNum(uint playerNum)
	{
		this.mLeftTimeInSec = (int)(playerNum * this._getPerUserWaitTime());
		this.mPlayerNum = (int)playerNum;
		this._updateWaitTimeTips();
		this._updateWaitTime();
	}

	// Token: 0x0600AB2E RID: 43822 RVA: 0x0024B3F0 File Offset: 0x002497F0
	private float _getPerUserWaitTime()
	{
		return 1.5f;
	}

	// Token: 0x0600AB2F RID: 43823 RVA: 0x0024B404 File Offset: 0x00249804
	private void _updateWaitTimeTips()
	{
		bool flag = this.mLeftTimeInSec > 0;
		this.mWaitTimeRoot.SetActive(flag);
		this.mSuccessRoot.SetActive(!flag);
	}

	// Token: 0x0600AB30 RID: 43824 RVA: 0x0024B436 File Offset: 0x00249836
	[MessageHandle(300317U, false, 0)]
	private void NotifyAllowLogin(MsgDATA data)
	{
		Singleton<ClientSystemManager>.instance.CloseFrame<ServerWaitQueueUp>(this, false);
		Singleton<ClientSystemManager>.instance.CloseFrame<ServerListFrame>(null, false);
		UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ServerLoginSuccess, null, null, null, null);
	}

	// Token: 0x0600AB31 RID: 43825 RVA: 0x0024B464 File Offset: 0x00249864
	protected void _quitQueue()
	{
		Singleton<ClientSystemManager>.instance.CloseFrame<ServerWaitQueueUp>(this, false);
		GateLeaveLoginQueue cmd = new GateLeaveLoginQueue();
		MonoSingleton<NetManager>.instance.SendCommand<GateLeaveLoginQueue>(ServerType.GATE_SERVER, cmd);
		this.mTickCount = 3;
	}

	// Token: 0x0600AB32 RID: 43826 RVA: 0x0024B497 File Offset: 0x00249897
	public override bool IsNeedUpdate()
	{
		return true;
	}

	// Token: 0x0600AB33 RID: 43827 RVA: 0x0024B49C File Offset: 0x0024989C
	protected override void _OnUpdate(float delta)
	{
		this.mTickTime += delta;
		if (this.mTickTime > 1f)
		{
			this._updateWaitTime();
			this.mTickTime -= 1f;
		}
		ServerWaitQueueUp.eQuitQueueType eQuitQueueType = this.mQuitQueueType;
		if (eQuitQueueType != ServerWaitQueueUp.eQuitQueueType.None)
		{
			if (eQuitQueueType != ServerWaitQueueUp.eQuitQueueType.ServerListChanged)
			{
				if (eQuitQueueType == ServerWaitQueueUp.eQuitQueueType.UserCancel)
				{
					if (this._isTickCountFinish())
					{
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ServerLoginFail, null, null, null, null);
						this.mQuitQueueType = ServerWaitQueueUp.eQuitQueueType.None;
					}
				}
			}
			else if (this._isTickCountFinish())
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ServerLoginFail, null, null, null, null);
				ClientSystemLoginUtility.StartLoginAfterVerify();
				this.mQuitQueueType = ServerWaitQueueUp.eQuitQueueType.None;
			}
		}
	}

	// Token: 0x0600AB34 RID: 43828 RVA: 0x0024B560 File Offset: 0x00249960
	private bool _isTickCountFinish()
	{
		return this.mTickCount-- < 0;
	}

	// Token: 0x0600AB35 RID: 43829 RVA: 0x0024B584 File Offset: 0x00249984
	private void _updateWaitTime()
	{
		this.mLeftTimeInSec--;
		if (this.mLeftTimeInSec >= 0)
		{
			this.mLeftTime.SetTime(this.mLeftTimeInSec * 1000);
		}
		else if (this.mPlayerNum > 1)
		{
			this._setPlayerNum((uint)this.mPlayerNum);
		}
		else
		{
			this._updateWaitTextTips();
			this._updateWaitTimeTips();
		}
	}

	// Token: 0x04005FF0 RID: 24560
	private const float kDefaltWaitSec = 1.5f;

	// Token: 0x04005FF1 RID: 24561
	private const int kDefaultWaitQuitMessageFrameCount = 3;

	// Token: 0x04005FF2 RID: 24562
	private int mLeftTimeInSec;

	// Token: 0x04005FF3 RID: 24563
	private int mPlayerNum;

	// Token: 0x04005FF4 RID: 24564
	private Button mQuitWaitQueueBtn;

	// Token: 0x04005FF5 RID: 24565
	private Text mServerName;

	// Token: 0x04005FF6 RID: 24566
	private Text mShowLeftPlayerNum;

	// Token: 0x04005FF7 RID: 24567
	private Text mPreWaitTime;

	// Token: 0x04005FF8 RID: 24568
	private GameObject mCheckQuitPlane;

	// Token: 0x04005FF9 RID: 24569
	private Button mOkBtn;

	// Token: 0x04005FFA RID: 24570
	private Button mCancelBtn;

	// Token: 0x04005FFB RID: 24571
	private Button mChangeBtn;

	// Token: 0x04005FFC RID: 24572
	private ComTime mLeftTime;

	// Token: 0x04005FFD RID: 24573
	private GameObject mWaitTimeRoot;

	// Token: 0x04005FFE RID: 24574
	private GameObject mSuccessRoot;

	// Token: 0x04005FFF RID: 24575
	private ServerWaitQueueUp.eQuitQueueType mQuitQueueType;

	// Token: 0x04006000 RID: 24576
	private string[] kWaitTimeDesc = new string[]
	{
		"等待进入服务器，请稍候.",
		"等待进入服务器，请稍候..",
		"等待进入服务器，请稍候..."
	};

	// Token: 0x04006001 RID: 24577
	private int mWaitTimeIdx;

	// Token: 0x04006002 RID: 24578
	private Text mWaitTimeDesc;

	// Token: 0x04006003 RID: 24579
	private float mTickTime;

	// Token: 0x04006004 RID: 24580
	private int mTickCount;

	// Token: 0x0200117C RID: 4476
	private enum eQuitQueueType
	{
		// Token: 0x04006006 RID: 24582
		None,
		// Token: 0x04006007 RID: 24583
		UserCancel,
		// Token: 0x04006008 RID: 24584
		ServerListChanged
	}
}
