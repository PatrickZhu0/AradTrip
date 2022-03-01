using System;
using GameClient;
using Protocol;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x020010EC RID: 4332
public class BattleRedPacketFrame : ClientFrame
{
	// Token: 0x0600A43C RID: 42044 RVA: 0x0021C588 File Offset: 0x0021A988
	public override string GetPrefabPath()
	{
		return "UIFlatten/Prefabs/BattleUI/UIComponent/BattleRedPacketFrame";
	}

	// Token: 0x0600A43D RID: 42045 RVA: 0x0021C590 File Offset: 0x0021A990
	protected override void _bindExUI()
	{
		this.mBtnRedPacket = this.mBind.GetCom<Button>("BtnRedPacket");
		this.mBtnRedPacket.onClick.AddListener(new UnityAction(this._onBtnRedPacketButtonClick));
		this.mLabRedPacketCount = this.mBind.GetCom<Text>("LabRedPacketCount");
	}

	// Token: 0x0600A43E RID: 42046 RVA: 0x0021C5E5 File Offset: 0x0021A9E5
	protected override void _unbindExUI()
	{
		this.mBtnRedPacket.onClick.RemoveListener(new UnityAction(this._onBtnRedPacketButtonClick));
		this.mBtnRedPacket = null;
		this.mLabRedPacketCount = null;
	}

	// Token: 0x0600A43F RID: 42047 RVA: 0x0021C614 File Offset: 0x0021AA14
	private void _onBtnRedPacketButtonClick()
	{
		RedPacketBaseEntry firstRedPacketToOpen = DataManager<RedPackDataManager>.GetInstance().GetFirstRedPacketToOpen();
		if (firstRedPacketToOpen != null)
		{
			DataManager<RedPackDataManager>.GetInstance().OpenRedPacket(firstRedPacketToOpen.id);
		}
	}

	// Token: 0x0600A440 RID: 42048 RVA: 0x0021C642 File Offset: 0x0021AA42
	protected override void _OnOpenFrame()
	{
		base._OnOpenFrame();
		this._RegisterEvent();
		this._UpdateRedPacket();
	}

	// Token: 0x0600A441 RID: 42049 RVA: 0x0021C656 File Offset: 0x0021AA56
	protected override void _OnCloseFrame()
	{
		base._OnCloseFrame();
		this._UnRegisterEvent();
	}

	// Token: 0x0600A442 RID: 42050 RVA: 0x0021C664 File Offset: 0x0021AA64
	private void _RegisterEvent()
	{
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RedPacketOpenSuccess, new ClientEventSystem.UIEventHandler(this._OnRedPacketOpenSuccess));
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RedPacketGet, new ClientEventSystem.UIEventHandler(this._OnNewRedPacketGet));
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RedPacketDelete, new ClientEventSystem.UIEventHandler(this._OnDeleteRedPacket));
	}

	// Token: 0x0600A443 RID: 42051 RVA: 0x0021C6C4 File Offset: 0x0021AAC4
	private void _UnRegisterEvent()
	{
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RedPacketOpenSuccess, new ClientEventSystem.UIEventHandler(this._OnRedPacketOpenSuccess));
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RedPacketGet, new ClientEventSystem.UIEventHandler(this._OnNewRedPacketGet));
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RedPacketDelete, new ClientEventSystem.UIEventHandler(this._OnDeleteRedPacket));
	}

	// Token: 0x0600A444 RID: 42052 RVA: 0x0021C722 File Offset: 0x0021AB22
	protected void _OnNewRedPacketGet(UIEvent a_event)
	{
		this._UpdateRedPacket();
	}

	// Token: 0x0600A445 RID: 42053 RVA: 0x0021C72A File Offset: 0x0021AB2A
	protected void _OnDeleteRedPacket(UIEvent a_event)
	{
		this._UpdateRedPacket();
	}

	// Token: 0x0600A446 RID: 42054 RVA: 0x0021C732 File Offset: 0x0021AB32
	protected void _OnRedPacketOpenSuccess(UIEvent a_event)
	{
		if (BattleMain.IsModePvP(BattleMain.battleType) && !Singleton<ClientSystemManager>.instance.IsFrameOpen<OpenRedPacketFrame>(null))
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<OpenRedPacketFrame>(FrameLayer.Middle, a_event.Param1, string.Empty);
		}
		this._UpdateRedPacket();
	}

	// Token: 0x0600A447 RID: 42055 RVA: 0x0021C770 File Offset: 0x0021AB70
	private void _UpdateRedPacket()
	{
		if (!BattleMain.IsModePvP(BattleMain.battleType))
		{
			int waitOpenCount = DataManager<RedPackDataManager>.GetInstance().GetWaitOpenCount();
			if (this.mBtnRedPacket != null)
			{
				this.mBtnRedPacket.gameObject.CustomActive(waitOpenCount > 0);
			}
			if (this.mLabRedPacketCount != null)
			{
				this.mLabRedPacketCount.gameObject.CustomActive(waitOpenCount > 1);
				this.mLabRedPacketCount.text = waitOpenCount.ToString();
			}
		}
		else
		{
			if (this.mBtnRedPacket != null)
			{
				this.mBtnRedPacket.gameObject.CustomActive(false);
			}
			if (this.mLabRedPacketCount != null)
			{
				this.mLabRedPacketCount.gameObject.CustomActive(false);
			}
		}
	}

	// Token: 0x04005BD5 RID: 23509
	private Button mBtnRedPacket;

	// Token: 0x04005BD6 RID: 23510
	private Text mLabRedPacketCount;
}
