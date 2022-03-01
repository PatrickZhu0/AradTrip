using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001568 RID: 5480
	public class ComVoiceTalk : MonoBehaviour
	{
		// Token: 0x17001C1B RID: 7195
		// (get) Token: 0x0600D600 RID: 54784 RVA: 0x00357A56 File Offset: 0x00355E56
		// (set) Token: 0x0600D601 RID: 54785 RVA: 0x00357A5E File Offset: 0x00355E5E
		public bool HasHide { get; private set; }

		// Token: 0x17001C1C RID: 7196
		// (get) Token: 0x0600D602 RID: 54786 RVA: 0x00357A68 File Offset: 0x00355E68
		public GameObject GoParent
		{
			get
			{
				if (base.gameObject == null || base.gameObject.transform == null)
				{
					return null;
				}
				Transform parent = base.gameObject.transform.parent;
				if (parent == null)
				{
					return null;
				}
				return parent.gameObject;
			}
		}

		// Token: 0x0600D603 RID: 54787 RVA: 0x00357AC3 File Offset: 0x00355EC3
		private void Awake()
		{
			Object.DontDestroyOnLoad(this);
			this._InitView();
		}

		// Token: 0x0600D604 RID: 54788 RVA: 0x00357AD1 File Offset: 0x00355ED1
		private void OnDestroy()
		{
			this._ClearView();
		}

		// Token: 0x0600D605 RID: 54789 RVA: 0x00357AD9 File Offset: 0x00355ED9
		private void _InitView()
		{
			this._BindUIEvent();
			this._InitAllTalkBtns();
			this._AddTalkBtnsEvent();
		}

		// Token: 0x0600D606 RID: 54790 RVA: 0x00357AF0 File Offset: 0x00355EF0
		private void _InitAllTalkBtns()
		{
			if (this.tempTalkBtnList != null)
			{
				this.tempTalkBtnList.Add(this.micBtn);
				this.tempTalkBtnList.Add(this.playerBtn);
				this.tempTalkBtnList.Add(this.limitMicBtn);
				if (this.micBtnGroup != null)
				{
					this.tempTalkBtnList.AddRange(this.micBtnGroup.GetAllTalkBtns());
				}
				this.tempTalkBtnList.ForEach(new Action<ComVoiceTalkButton>(this._SetAllTalkBtnOff));
			}
			this._ShowMicBtnGroup(false);
			this.ShowLimitAllNotSpeakBtn(false);
		}

		// Token: 0x0600D607 RID: 54791 RVA: 0x00357B87 File Offset: 0x00355F87
		public void AddTempTalkBtnList(List<ComVoiceTalkButton> btns)
		{
			if (this.tempTalkBtnList != null && btns != null)
			{
				this.tempTalkBtnList.AddRange(btns);
			}
		}

		// Token: 0x0600D608 RID: 54792 RVA: 0x00357BA8 File Offset: 0x00355FA8
		private void _ClearView()
		{
			this._UnBindUIEvent();
			this._RemoveTalkBtnsEvent();
			if (this.mVoiceTalkModule != null)
			{
				this.mVoiceTalkModule.UnInit();
				this.mVoiceTalkModule = null;
			}
			if (ComVoiceTalk.msComVoiceTalk == this)
			{
				ComVoiceTalk.msComVoiceTalk = null;
			}
			if (this.tempTalkBtnList != null)
			{
				this.tempTalkBtnList.Clear();
				this.tempTalkBtnList = null;
			}
			this.bMicBtnGroupShow = false;
			this.lastGoParent = null;
			this.HasHide = false;
		}

		// Token: 0x0600D609 RID: 54793 RVA: 0x00357C28 File Offset: 0x00356028
		private void _BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.VoiceTalkMicSwitch, new ClientEventSystem.UIEventHandler(this._OnVoiceTalkMicSwitch));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.VoiceTalkPlayerSwitch, new ClientEventSystem.UIEventHandler(this._OnVoiceTalkPlayerSwitch));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.VoiceTalkLimitAllNotSpeak, new ClientEventSystem.UIEventHandler(this._VoiceTalkLimitAllNotSpeak));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.VoiceTalkMicClosedByOther, new ClientEventSystem.UIEventHandler(this._VoiceTalkMicClosedByOther));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.VoiceTalkChannelChanged, new ClientEventSystem.UIEventHandler(this._VoiceTalkChannelChanged));
		}

		// Token: 0x0600D60A RID: 54794 RVA: 0x00357CBC File Offset: 0x003560BC
		private void _UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.VoiceTalkMicSwitch, new ClientEventSystem.UIEventHandler(this._OnVoiceTalkMicSwitch));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.VoiceTalkPlayerSwitch, new ClientEventSystem.UIEventHandler(this._OnVoiceTalkPlayerSwitch));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.VoiceTalkLimitAllNotSpeak, new ClientEventSystem.UIEventHandler(this._VoiceTalkLimitAllNotSpeak));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.VoiceTalkMicClosedByOther, new ClientEventSystem.UIEventHandler(this._VoiceTalkMicClosedByOther));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.VoiceTalkChannelChanged, new ClientEventSystem.UIEventHandler(this._VoiceTalkChannelChanged));
		}

		// Token: 0x0600D60B RID: 54795 RVA: 0x00357D50 File Offset: 0x00356150
		private void _OnVoiceTalkMicSwitch(UIEvent uiEvent)
		{
			bool flag = this._TryGetUIEventParam1(uiEvent);
			if (this.tempTalkBtnList != null)
			{
				if (flag)
				{
					this.tempTalkBtnList.ForEach(new Action<ComVoiceTalkButton>(this._SetTalkMicBtnOn));
				}
				else
				{
					this.tempTalkBtnList.ForEach(new Action<ComVoiceTalkButton>(this._SetTalkMicBtnOff));
				}
			}
			if (this.bMicBtnGroupShow && this.micBtnGroup)
			{
				if (this.mVoiceTalkModule != null && !this.mVoiceTalkModule.IsSelfMicEnable())
				{
					this._UpdateAllMicEnable(false);
					return;
				}
				if (!flag)
				{
					this.micBtnGroup.SetMicOffTalkBtnSelected(true);
				}
			}
		}

		// Token: 0x0600D60C RID: 54796 RVA: 0x00357DFC File Offset: 0x003561FC
		private void _OnVoiceTalkPlayerSwitch(UIEvent uiEvent)
		{
			bool flag = this._TryGetUIEventParam1(uiEvent);
			if (this.tempTalkBtnList != null)
			{
				if (flag)
				{
					this.tempTalkBtnList.ForEach(new Action<ComVoiceTalkButton>(this._SetTalkPlayerBtnOn));
				}
				else
				{
					this.tempTalkBtnList.ForEach(new Action<ComVoiceTalkButton>(this._SetTalkPlayerBtnOff));
				}
			}
		}

		// Token: 0x0600D60D RID: 54797 RVA: 0x00357E58 File Offset: 0x00356258
		private void _VoiceTalkLimitAllNotSpeak(UIEvent uiEvent)
		{
			bool flag = this._TryGetUIEventParam1(uiEvent);
			if (this.tempTalkBtnList != null)
			{
				if (flag)
				{
					this.tempTalkBtnList.ForEach(new Action<ComVoiceTalkButton>(this._SetTalkLimitSpeakBtnOn));
				}
				else
				{
					this.tempTalkBtnList.ForEach(new Action<ComVoiceTalkButton>(this._SetTalkLimitSpeakBtnOff));
				}
			}
		}

		// Token: 0x0600D60E RID: 54798 RVA: 0x00357EB4 File Offset: 0x003562B4
		private void _VoiceTalkMicClosedByOther(UIEvent uiEvent)
		{
			bool bEnable = this._TryGetUIEventParam1(uiEvent);
			this._UpdateAllMicEnable(bEnable);
		}

		// Token: 0x0600D60F RID: 54799 RVA: 0x00357ED0 File Offset: 0x003562D0
		private bool _TryGetUIEventParam1(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return false;
			}
			bool[] array = uiEvent.Param1 as bool[];
			return array != null && array.Length > 0 && array[0];
		}

		// Token: 0x0600D610 RID: 54800 RVA: 0x00357F10 File Offset: 0x00356310
		private void _VoiceTalkChannelChanged(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			string text = uiEvent.Param1 as string;
			if (string.IsNullOrEmpty(text))
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("voice_talk_set_channel_failed"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.bMicBtnGroupShow && this.micBtnGroup)
			{
				this.micBtnGroup.SetMicChannelOnTalkBtnSelected(text, true);
			}
		}

		// Token: 0x0600D611 RID: 54801 RVA: 0x00357F7F File Offset: 0x0035637F
		private void _SetAllTalkBtnOn(ComVoiceTalkButton talkBtn)
		{
			if (talkBtn != null)
			{
				talkBtn.SetBtnStatus(true);
			}
		}

		// Token: 0x0600D612 RID: 54802 RVA: 0x00357F94 File Offset: 0x00356394
		private void _SetAllTalkBtnOff(ComVoiceTalkButton talkBtn)
		{
			if (talkBtn != null)
			{
				talkBtn.SetBtnStatus(false);
			}
		}

		// Token: 0x0600D613 RID: 54803 RVA: 0x00357FA9 File Offset: 0x003563A9
		private void _SetTalkMicBtnOn(ComVoiceTalkButton talkBtn)
		{
			if (talkBtn != null && talkBtn.isMicType)
			{
				talkBtn.SetBtnStatus(true);
			}
		}

		// Token: 0x0600D614 RID: 54804 RVA: 0x00357FC9 File Offset: 0x003563C9
		private void _SetTalkMicBtnOff(ComVoiceTalkButton talkBtn)
		{
			if (talkBtn != null && talkBtn.isMicType)
			{
				talkBtn.SetBtnStatus(false);
			}
		}

		// Token: 0x0600D615 RID: 54805 RVA: 0x00357FE9 File Offset: 0x003563E9
		private void _SetTalkPlayerBtnOn(ComVoiceTalkButton talkBtn)
		{
			if (talkBtn != null && talkBtn.isPlayerType)
			{
				talkBtn.SetBtnStatus(true);
			}
		}

		// Token: 0x0600D616 RID: 54806 RVA: 0x00358009 File Offset: 0x00356409
		private void _SetTalkPlayerBtnOff(ComVoiceTalkButton talkBtn)
		{
			if (talkBtn != null && talkBtn.isPlayerType)
			{
				talkBtn.SetBtnStatus(false);
			}
		}

		// Token: 0x0600D617 RID: 54807 RVA: 0x00358029 File Offset: 0x00356429
		private void _SetTalkLimitSpeakBtnOn(ComVoiceTalkButton talkBtn)
		{
			if (talkBtn != null && talkBtn.isLimitSpeakType)
			{
				talkBtn.SetBtnStatus(false);
			}
		}

		// Token: 0x0600D618 RID: 54808 RVA: 0x00358049 File Offset: 0x00356449
		private void _SetTalkLimitSpeakBtnOff(ComVoiceTalkButton talkBtn)
		{
			if (talkBtn != null && talkBtn.isLimitSpeakType)
			{
				talkBtn.SetBtnStatus(true);
			}
		}

		// Token: 0x0600D619 RID: 54809 RVA: 0x00358069 File Offset: 0x00356469
		private void _SetTalkMicOnByOther(ComVoiceTalkButton talkBtn)
		{
			if (talkBtn != null && talkBtn.isMicType)
			{
				talkBtn.SetMarkIconShow(false);
				talkBtn.SetBtnEnable(true);
			}
		}

		// Token: 0x0600D61A RID: 54810 RVA: 0x00358090 File Offset: 0x00356490
		private void _SetTalkMicOffByOther(ComVoiceTalkButton talkBtn)
		{
			if (talkBtn != null && talkBtn.isMicType)
			{
				talkBtn.SetMarkIconShow(true);
				talkBtn.SetBtnEnable(false);
			}
		}

		// Token: 0x0600D61B RID: 54811 RVA: 0x003580B7 File Offset: 0x003564B7
		private void _AddTalkBtnsEvent()
		{
			if (this.tempTalkBtnList != null)
			{
				this.tempTalkBtnList.ForEach(new Action<ComVoiceTalkButton>(this._AddTalkBtnEvent));
			}
		}

		// Token: 0x0600D61C RID: 54812 RVA: 0x003580DB File Offset: 0x003564DB
		private void _RemoveTalkBtnsEvent()
		{
			if (this.tempTalkBtnList != null)
			{
				this.tempTalkBtnList.ForEach(new Action<ComVoiceTalkButton>(this._RemoveTalkBtnEvent));
			}
		}

		// Token: 0x0600D61D RID: 54813 RVA: 0x003580FF File Offset: 0x003564FF
		private void _AddTalkBtnEvent(ComVoiceTalkButton talkBtn)
		{
			if (talkBtn != null)
			{
				talkBtn.onClick.AddListener(new UnityAction<ComVoiceTalkButton.TalkBtnType, ComVoiceTalkButton, object>(this._OnTalkBtnClick));
			}
		}

		// Token: 0x0600D61E RID: 54814 RVA: 0x00358124 File Offset: 0x00356524
		private void _RemoveTalkBtnEvent(ComVoiceTalkButton talkBtn)
		{
			if (talkBtn != null)
			{
				talkBtn.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600D61F RID: 54815 RVA: 0x00358140 File Offset: 0x00356540
		private void _OnTalkBtnClick(ComVoiceTalkButton.TalkBtnType btnType, ComVoiceTalkButton comBtn, object param1)
		{
			if (this.mVoiceTalkModule == null)
			{
				return;
			}
			bool flag = true;
			switch (btnType)
			{
			case ComVoiceTalkButton.TalkBtnType.MicChannelOn:
			{
				string sceneId = param1 as string;
				flag = this.mVoiceTalkModule.SwitchSpeakChannel(sceneId, true);
				break;
			}
			case ComVoiceTalkButton.TalkBtnType.MicAllOff:
				flag = this.mVoiceTalkModule.CloseMic();
				break;
			case ComVoiceTalkButton.TalkBtnType.MicSwitch:
				this.mVoiceTalkModule.ControlMic();
				break;
			case ComVoiceTalkButton.TalkBtnType.MicAllNotSpeak:
				this.mVoiceTalkModule.ControlGlobalSilence();
				break;
			case ComVoiceTalkButton.TalkBtnType.PlayerSwitch:
				this.mVoiceTalkModule.ControlPlayer();
				break;
			}
			if (!flag)
			{
				this._SetComVoiceBtnGroupSelectBtn(comBtn, false);
			}
		}

		// Token: 0x0600D620 RID: 54816 RVA: 0x003581E5 File Offset: 0x003565E5
		private void _SetComVoiceBtnGroupSelectBtn(ComVoiceTalkButton comBtn, bool bSelected)
		{
			if (null == comBtn || null == comBtn.group)
			{
				return;
			}
			comBtn.group.SetComVoiceTalkBtnSelected(comBtn, bSelected);
		}

		// Token: 0x0600D621 RID: 54817 RVA: 0x00358214 File Offset: 0x00356614
		public void UpdateMicBtnGroup(bool showGroup)
		{
			if (this.mVoiceTalkModule == null)
			{
				return;
			}
			if (this.micBtnGroup != null)
			{
				this.micBtnGroup.UpdateAllTalkBtns(this.mVoiceTalkModule.GetMultipleTalkChannels());
			}
			this._ShowMicBtnGroup(showGroup);
			if (showGroup && this.micBtnGroup)
			{
				this.micBtnGroup.SetMicChannelOnTalkBtnSelected(this.mVoiceTalkModule.GetCurrentTalkChanneld(), true);
			}
		}

		// Token: 0x0600D622 RID: 54818 RVA: 0x00358288 File Offset: 0x00356688
		public void UpdateAllMicStatus()
		{
			if (this.mVoiceTalkModule == null)
			{
				return;
			}
			bool bEnable = this.mVoiceTalkModule.IsSelfMicEnable();
			this._UpdateAllMicEnable(bEnable);
		}

		// Token: 0x0600D623 RID: 54819 RVA: 0x003582B4 File Offset: 0x003566B4
		private void _UpdateAllMicEnable(bool bEnable)
		{
			if (this.tempTalkBtnList != null)
			{
				if (bEnable)
				{
					this.tempTalkBtnList.ForEach(new Action<ComVoiceTalkButton>(this._SetTalkMicOnByOther));
				}
				else
				{
					this.tempTalkBtnList.ForEach(new Action<ComVoiceTalkButton>(this._SetTalkMicOffByOther));
				}
			}
		}

		// Token: 0x0600D624 RID: 54820 RVA: 0x00358308 File Offset: 0x00356708
		public void TrySwitchTalkChannelIdByCond(string channelId, bool canSwitch = false)
		{
			if (canSwitch)
			{
				if (this.mVoiceTalkModule != null && !string.IsNullOrEmpty(channelId))
				{
					this.mVoiceTalkModule.SwitchSpeakChannel(channelId, false);
				}
			}
			else if (this.bMicBtnGroupShow && this.micBtnGroup)
			{
				this.micBtnGroup.SetMicOffTalkBtnSelected(true);
			}
		}

		// Token: 0x0600D625 RID: 54821 RVA: 0x0035836B File Offset: 0x0035676B
		private void _ShowMicBtnGroup(bool isShow)
		{
			this.micBtnGroup.CustomActive(isShow);
			this.micBtn.CustomActive(!isShow);
			this.bMicBtnGroupShow = isShow;
		}

		// Token: 0x0600D626 RID: 54822 RVA: 0x0035838F File Offset: 0x0035678F
		public void ShowLimitAllNotSpeakBtn(bool isShow)
		{
			this.limitMicBtn.CustomActive(isShow);
		}

		// Token: 0x0600D627 RID: 54823 RVA: 0x0035839D File Offset: 0x0035679D
		public void SetPlayerMicEnable(string accId, bool bEnable)
		{
			if (this.mVoiceTalkModule != null)
			{
				this.mVoiceTalkModule.SetMicEnable(accId, bEnable);
			}
		}

		// Token: 0x0600D628 RID: 54824 RVA: 0x003583B7 File Offset: 0x003567B7
		public void ResetGlobalSilence()
		{
			if (this.mVoiceTalkModule != null)
			{
				this.mVoiceTalkModule.ResetGlobalSilence();
			}
		}

		// Token: 0x0600D629 RID: 54825 RVA: 0x003583CF File Offset: 0x003567CF
		public void Enable(VoiceTalkConfig vtConfig)
		{
			if (this.mVoiceTalkModule == null)
			{
				this.mVoiceTalkModule = new VoiceTalkModule();
			}
			if (this.mVoiceTalkModule != null)
			{
				this.mVoiceTalkModule.Reset(vtConfig, true);
			}
		}

		// Token: 0x0600D62A RID: 54826 RVA: 0x003583FF File Offset: 0x003567FF
		public void Hide()
		{
			this.AttachToParent(null);
		}

		// Token: 0x0600D62B RID: 54827 RVA: 0x00358408 File Offset: 0x00356808
		public void AttachToParent(GameObject goParent)
		{
			this.HasHide = (goParent == null);
			if (goParent == null)
			{
				base.gameObject.transform.SetParent(null);
			}
			else
			{
				Utility.AttachTo(base.gameObject, goParent, false);
			}
		}

		// Token: 0x0600D62C RID: 54828 RVA: 0x0035845D File Offset: 0x0035685D
		public void UpdateTalkChannelId(List<string> channelIds)
		{
			if (this.mVoiceTalkModule != null)
			{
				this.mVoiceTalkModule.UpdateMultipleTalkChannel(channelIds);
			}
		}

		// Token: 0x0600D62D RID: 54829 RVA: 0x00358476 File Offset: 0x00356876
		public void AddGameSceneId(string sId)
		{
			if (this.mVoiceTalkModule != null)
			{
				this.mVoiceTalkModule.AddMultipleTalkChannel(sId);
			}
		}

		// Token: 0x0600D62E RID: 54830 RVA: 0x0035848F File Offset: 0x0035688F
		public void RemoveGameSceneId(string sId)
		{
			if (this.mVoiceTalkModule != null)
			{
				this.mVoiceTalkModule.RemoveMultipleTalkChannel(sId);
			}
		}

		// Token: 0x0600D62F RID: 54831 RVA: 0x003584A8 File Offset: 0x003568A8
		public bool IsMicOn()
		{
			return this.mVoiceTalkModule != null && this.mVoiceTalkModule.IsMicOn();
		}

		// Token: 0x0600D630 RID: 54832 RVA: 0x003584C2 File Offset: 0x003568C2
		public bool IsPlayerOn()
		{
			return this.mVoiceTalkModule != null && this.mVoiceTalkModule.IsPlayerOn();
		}

		// Token: 0x0600D631 RID: 54833 RVA: 0x003584DC File Offset: 0x003568DC
		public bool IsJoinedTalkChannel(string talkChannelId)
		{
			return this.mVoiceTalkModule != null && this.mVoiceTalkModule.IsJoinedTalkChannel(talkChannelId);
		}

		// Token: 0x0600D632 RID: 54834 RVA: 0x003584F7 File Offset: 0x003568F7
		public static bool CheckJoinedTalkChannel(string talkChannelId)
		{
			return ComVoiceTalk.msComVoiceTalk != null && ComVoiceTalk.msComVoiceTalk.IsJoinedTalkChannel(talkChannelId);
		}

		// Token: 0x0600D633 RID: 54835 RVA: 0x00358516 File Offset: 0x00356916
		public static void SetSelctPlayerMicEnable(string accId, bool bEnable)
		{
			if (ComVoiceTalk.msComVoiceTalk != null)
			{
				ComVoiceTalk.msComVoiceTalk.SetPlayerMicEnable(accId, bEnable);
			}
		}

		// Token: 0x0600D634 RID: 54836 RVA: 0x00358534 File Offset: 0x00356934
		public static void ResetCurrentGlobalSilence()
		{
			if (ComVoiceTalk.msComVoiceTalk != null)
			{
				ComVoiceTalk.msComVoiceTalk.ResetGlobalSilence();
			}
		}

		// Token: 0x0600D635 RID: 54837 RVA: 0x00358550 File Offset: 0x00356950
		public static void AddChannelID(string cId)
		{
			if (ComVoiceTalk.msComVoiceTalk != null)
			{
				ComVoiceTalk.msComVoiceTalk.AddGameSceneId(cId);
			}
		}

		// Token: 0x0600D636 RID: 54838 RVA: 0x0035856D File Offset: 0x0035696D
		public static void RemoveChannelID(string cId)
		{
			if (ComVoiceTalk.msComVoiceTalk != null)
			{
				ComVoiceTalk.msComVoiceTalk.RemoveGameSceneId(cId);
			}
		}

		// Token: 0x0600D637 RID: 54839 RVA: 0x0035858A File Offset: 0x0035698A
		public static void UpdateChannelID(List<string> cIds)
		{
			if (ComVoiceTalk.msComVoiceTalk != null)
			{
				ComVoiceTalk.msComVoiceTalk.UpdateTalkChannelId(cIds);
			}
		}

		// Token: 0x0600D638 RID: 54840 RVA: 0x003585A7 File Offset: 0x003569A7
		public static void Hidden()
		{
			if (ComVoiceTalk.msComVoiceTalk != null)
			{
				ComVoiceTalk.msComVoiceTalk.Hide();
			}
		}

		// Token: 0x0600D639 RID: 54841 RVA: 0x003585C3 File Offset: 0x003569C3
		public static void ForceDestroy()
		{
			if (ComVoiceTalk.msComVoiceTalk != null)
			{
				Object.Destroy(ComVoiceTalk.msComVoiceTalk.gameObject);
				ComVoiceTalk.msComVoiceTalk = null;
			}
		}

		// Token: 0x0600D63A RID: 54842 RVA: 0x003585EA File Offset: 0x003569EA
		public static void ShowLimitSpeakBtn(bool isShow)
		{
			if (ComVoiceTalk.msComVoiceTalk != null)
			{
				ComVoiceTalk.msComVoiceTalk.ShowLimitAllNotSpeakBtn(isShow);
			}
		}

		// Token: 0x0600D63B RID: 54843 RVA: 0x00358607 File Offset: 0x00356A07
		public static void UpdateMicBtnGroupStatus(bool showGroup)
		{
			if (ComVoiceTalk.msComVoiceTalk != null)
			{
				ComVoiceTalk.msComVoiceTalk.UpdateMicBtnGroup(showGroup);
			}
		}

		// Token: 0x0600D63C RID: 54844 RVA: 0x00358624 File Offset: 0x00356A24
		public static void UpdateAllMicShowStatus()
		{
			if (ComVoiceTalk.msComVoiceTalk != null)
			{
				ComVoiceTalk.msComVoiceTalk.UpdateAllMicStatus();
			}
		}

		// Token: 0x0600D63D RID: 54845 RVA: 0x00358640 File Offset: 0x00356A40
		public static void TrySwitchTalkChannelId(string channelId, bool canSwitch = false)
		{
			if (ComVoiceTalk.msComVoiceTalk != null)
			{
				ComVoiceTalk.msComVoiceTalk.TrySwitchTalkChannelIdByCond(channelId, canSwitch);
			}
		}

		// Token: 0x0600D63E RID: 54846 RVA: 0x0035865E File Offset: 0x00356A5E
		public static bool IsVoiceTalkMicOn()
		{
			return ComVoiceTalk.msComVoiceTalk != null && ComVoiceTalk.msComVoiceTalk.IsMicOn();
		}

		// Token: 0x0600D63F RID: 54847 RVA: 0x0035867C File Offset: 0x00356A7C
		public static bool IsVoiceTalkPlayerOn()
		{
			return ComVoiceTalk.msComVoiceTalk != null && ComVoiceTalk.msComVoiceTalk.IsPlayerOn();
		}

		// Token: 0x0600D640 RID: 54848 RVA: 0x0035869A File Offset: 0x00356A9A
		public static ComVoiceTalk Bind(GameObject goParent)
		{
			if (ComVoiceTalk.msComVoiceTalk == null)
			{
				return null;
			}
			ComVoiceTalk.msComVoiceTalk.lastGoParent = ComVoiceTalk.msComVoiceTalk.GoParent;
			ComVoiceTalk.msComVoiceTalk.AttachToParent(goParent);
			return ComVoiceTalk.msComVoiceTalk;
		}

		// Token: 0x0600D641 RID: 54849 RVA: 0x003586D2 File Offset: 0x00356AD2
		public static void UnBind()
		{
			if (ComVoiceTalk.msComVoiceTalk == null)
			{
				return;
			}
			if (ComVoiceTalk.msComVoiceTalk.HasHide)
			{
				return;
			}
			ComVoiceTalk.msComVoiceTalk.AttachToParent(ComVoiceTalk.msComVoiceTalk.lastGoParent);
		}

		// Token: 0x0600D642 RID: 54850 RVA: 0x0035870C File Offset: 0x00356B0C
		public static ComVoiceTalk Create(GameObject goParent, ComVoiceTalk.LocalCacheData localData, ComVoiceTalk.ComVoiceTalkType cvTalkType = ComVoiceTalk.ComVoiceTalkType.None, bool otherSwitch = true, bool openGlobalSilence = false)
		{
			if (cvTalkType == ComVoiceTalk.ComVoiceTalkType.None)
			{
				return null;
			}
			VoiceTalkConfig vtConfig = ComVoiceTalk.talkTypeWithConfig.SafeGetValue(cvTalkType);
			if (!Singleton<PluginManager>.GetInstance().GetVoiceSDKSwitch(vtConfig.switchType) || !otherSwitch)
			{
				return null;
			}
			if (ComVoiceTalk.msComVoiceTalk != null)
			{
				ComVoiceTalk.msComVoiceTalk.AttachToParent(goParent);
			}
			else
			{
				GameObject gameObject;
				if (!string.IsNullOrEmpty(vtConfig.resPath))
				{
					gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(vtConfig.resPath, true, 0U);
				}
				else
				{
					gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Common/ComVoice/ComVoiceTalk", true, 0U);
				}
				if (gameObject)
				{
					Utility.AttachTo(gameObject, goParent, false);
					ComVoiceTalk.msComVoiceTalk = gameObject.SafeAddComponent(false);
				}
				if (localData.hasSetMicStatus)
				{
					vtConfig.isMicOnAtFirst = localData.isMicOn;
				}
				if (localData.hasSetPlayerStatus)
				{
					vtConfig.isPlayerOnAtFirst = localData.isPlayerOn;
				}
				vtConfig.isGlobalSilenceAtFirst = openGlobalSilence;
			}
			if (ComVoiceTalk.msComVoiceTalk != null)
			{
				ComVoiceTalk.msComVoiceTalk.gameObject.CustomActive(true);
				ComVoiceTalk.msComVoiceTalk.gameObject.transform.localScale = Vector3.one;
				(ComVoiceTalk.msComVoiceTalk.transform as RectTransform).anchoredPosition3D = Vector3.zero;
				ComVoiceTalk.msComVoiceTalk.Enable(vtConfig);
			}
			return ComVoiceTalk.msComVoiceTalk;
		}

		// Token: 0x04007DB4 RID: 32180
		public static ComVoiceTalk msComVoiceTalk = null;

		// Token: 0x04007DB5 RID: 32181
		public const string RES_PATH = "UIFlatten/Prefabs/Common/ComVoice/ComVoiceTalk";

		// Token: 0x04007DB6 RID: 32182
		private static Dictionary<ComVoiceTalk.ComVoiceTalkType, VoiceTalkConfig> talkTypeWithConfig = new Dictionary<ComVoiceTalk.ComVoiceTalkType, VoiceTalkConfig>
		{
			{
				ComVoiceTalk.ComVoiceTalkType.TeamDuplicationMainBuild,
				new VoiceTalkConfig
				{
					resPath = "UIFlatten/Prefabs/Common/ComVoice/TeamDuplicationComVoiceTalk",
					switchType = PluginManager.VoiceSDKSwitch.TalkVoiceInTeamDuplication,
					isMicOnAtFirst = false,
					isPlayerOnAtFirst = true
				}
			},
			{
				ComVoiceTalk.ComVoiceTalkType.TeamDungeon,
				new VoiceTalkConfig
				{
					resPath = "UIFlatten/Prefabs/Common/ComVoice/TeamComVoiceTalk",
					switchType = PluginManager.VoiceSDKSwitch.TalkVoiceInTeam,
					isMicOnAtFirst = false,
					isPlayerOnAtFirst = false
				}
			},
			{
				ComVoiceTalk.ComVoiceTalkType.Pk3v3Battle,
				new VoiceTalkConfig
				{
					resPath = "UIFlatten/Prefabs/Common/ComVoice/Pk3v3ComVoiceTalk",
					switchType = PluginManager.VoiceSDKSwitch.TalkVoiceIn3v3Pvp,
					isMicOnAtFirst = false,
					isPlayerOnAtFirst = true
				}
			}
		};

		// Token: 0x04007DB7 RID: 32183
		[SerializeField]
		private ComVoiceTalkButton micBtn;

		// Token: 0x04007DB8 RID: 32184
		[SerializeField]
		private ComVoiceTalkButton playerBtn;

		// Token: 0x04007DB9 RID: 32185
		[SerializeField]
		private ComVoiceTalkButton limitMicBtn;

		// Token: 0x04007DBA RID: 32186
		[SerializeField]
		private ComVoiceTalkButtonGroup micBtnGroup;

		// Token: 0x04007DBB RID: 32187
		private List<ComVoiceTalkButton> tempTalkBtnList = new List<ComVoiceTalkButton>();

		// Token: 0x04007DBC RID: 32188
		private VoiceTalkModule mVoiceTalkModule;

		// Token: 0x04007DBD RID: 32189
		private bool bMicBtnGroupShow;

		// Token: 0x04007DBF RID: 32191
		private GameObject lastGoParent;

		// Token: 0x02001569 RID: 5481
		public enum ComVoiceTalkType
		{
			// Token: 0x04007DC1 RID: 32193
			None,
			// Token: 0x04007DC2 RID: 32194
			TeamDuplicationMainBuild,
			// Token: 0x04007DC3 RID: 32195
			TeamDungeon,
			// Token: 0x04007DC4 RID: 32196
			Pk3v3Battle
		}

		// Token: 0x0200156A RID: 5482
		public struct LocalCacheData
		{
			// Token: 0x0600D644 RID: 54852 RVA: 0x00358928 File Offset: 0x00356D28
			public void Clear()
			{
				this.hasSetMicStatus = (this.hasSetPlayerStatus = false);
				this.isMicOn = (this.isPlayerOn = false);
			}

			// Token: 0x04007DC5 RID: 32197
			public bool hasSetMicStatus;

			// Token: 0x04007DC6 RID: 32198
			public bool hasSetPlayerStatus;

			// Token: 0x04007DC7 RID: 32199
			public bool isMicOn;

			// Token: 0x04007DC8 RID: 32200
			public bool isPlayerOn;
		}
	}
}
