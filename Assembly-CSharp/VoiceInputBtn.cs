using System;
using GameClient;
using ProtoTable;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02001562 RID: 5474
public class VoiceInputBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler, IEventSystemHandler
{
	// Token: 0x17001C1A RID: 7194
	// (get) Token: 0x0600D5BE RID: 54718 RVA: 0x00356C0C File Offset: 0x0035500C
	// (set) Token: 0x0600D5BF RID: 54719 RVA: 0x00356C14 File Offset: 0x00355014
	public VoiceInputType BtnType
	{
		get
		{
			return this.btnType;
		}
		set
		{
			this.btnType = value;
		}
	}

	// Token: 0x0600D5C0 RID: 54720 RVA: 0x00356C20 File Offset: 0x00355020
	public void InitComponent(VoiceChatModule module, VoiceInputType type)
	{
		if (this.isInitialized)
		{
			return;
		}
		this.voiceModule = module;
		this.btnType = type;
		base.gameObject.CustomActive(true);
		if (this.voiceStatusPopupGo)
		{
			this.voiceStatusPopup = this.voiceStatusPopupGo.GetComponent<VoiceStatusPopup>();
			if (this.voiceStatusPopup)
			{
				this.voiceStatusPopup.InitComponent();
			}
		}
		this.ResetUIAtFirst();
		this.ResetStateFlag();
		this.DOWN_BTN_RECORD_START = TR.Value("voice_sdk_down_btn_record_start");
		this.UP_BTN_RECORD_END = TR.Value("voice_sdk_up_btn_record_end");
		this.DRAG_UP_SEND_CANCEL = TR.Value("voice_sdk_drag_up_send_cancel");
		this.DRAG_AWAY_SEND_CANCEL = TR.Value("voice_sdk_drag_down_send_cancel");
		this.VOICE_SEND_READY = TR.Value("voice_sdk_send_ready");
		this.VOICE_SEND_CANCEL = TR.Value("voice_sdk_send_cancel");
		this.VOICE_SENDING = TR.Value("voice_sdk_sending");
		this.VOICE_SEND_FAILED = TR.Value("voice_sdk_send_failed");
		this.VOICE_RECORD_FAILED = TR.Value("voice_sdk_record_failed");
		this.VOICE_RECORD_NOT_ENABLED = TR.Value("voice_sdk_record_not_enabled");
		this.VOICE_PLAY_NOT_ENABLED = TR.Value("voice_sdk_play_not_enabled");
		this.VOICE_MESSAGE = TR.Value("voice_sdk_message");
		this.AUDIO_AUTH_REQUEST = TR.Value("voice_sdk_audio_auth_request");
		this.VOICE_RECORD_NOT_ENABLE_INREAL = TR.Value("voice_sdk_be_in_real_voice");
		this.VOICE_LOGINING = TR.Value("voice_sdk_not_login");
		this.isInitialized = true;
	}

	// Token: 0x0600D5C1 RID: 54721 RVA: 0x00356D94 File Offset: 0x00355194
	public void UnInitComponent()
	{
		this.startRecordSendAudioHandler = null;
		this.stopRecordAudioHandler = null;
		this.cancelRecordAudioHandler = null;
		this.voiceStatusPopup = null;
		this.voiceModule = null;
		this.btnType = VoiceInputType.None;
		this.ResetStateFlag();
		this.DOWN_BTN_RECORD_START = null;
		this.UP_BTN_RECORD_END = null;
		this.DRAG_UP_SEND_CANCEL = null;
		this.DRAG_AWAY_SEND_CANCEL = null;
		this.VOICE_SEND_READY = null;
		this.VOICE_SEND_CANCEL = null;
		this.VOICE_SENDING = null;
		this.VOICE_SEND_FAILED = null;
		this.VOICE_RECORD_FAILED = null;
		this.VOICE_RECORD_NOT_ENABLED = null;
		this.VOICE_PLAY_NOT_ENABLED = null;
		this.VOICE_MESSAGE = null;
		this.AUDIO_AUTH_REQUEST = null;
		this.VOICE_RECORD_NOT_ENABLE_INREAL = null;
		this.VOICE_LOGINING = null;
		this.isInitialized = false;
	}

	// Token: 0x0600D5C2 RID: 54722 RVA: 0x00356E41 File Offset: 0x00355241
	private void ResetStateFlag()
	{
		this.isReadyToSend = false;
		this.canSend = false;
		this.bLessRecordVoice = false;
		this._isPressed = false;
		this.bLargeRecordVoice = false;
	}

	// Token: 0x0600D5C3 RID: 54723 RVA: 0x00356E66 File Offset: 0x00355266
	private void ResetUIAtFirst()
	{
		this.SetBtnText(this.DOWN_BTN_RECORD_START);
		this.ResetVoiceInfoTextGo();
		this.downBtnStartTime = -0.1f;
		this.ResetStateFlag();
	}

	// Token: 0x0600D5C4 RID: 54724 RVA: 0x00356E8B File Offset: 0x0035528B
	private void ResetVoiceInfoTextGo()
	{
		if (this.voiceStatusPopup != null)
		{
			this.voiceStatusPopup.SetInfoText(this.DRAG_UP_SEND_CANCEL);
			this.voiceStatusPopup.ShowVoiceInfoBg(false);
			this.voiceStatusPopup.SetInfoTextActive(false);
		}
	}

	// Token: 0x0600D5C5 RID: 54725 RVA: 0x00356EC7 File Offset: 0x003552C7
	private void SetBtnText(string text)
	{
		if (this.text_btn)
		{
			this.text_btn.text = text;
		}
	}

	// Token: 0x0600D5C6 RID: 54726 RVA: 0x00356EE5 File Offset: 0x003552E5
	public void SetSendStart()
	{
		this.ResetVoiceInfoTextGo();
		this.EnabledCurrentBtn(false);
		this.SetBtnText(this.VOICE_SENDING);
	}

	// Token: 0x0600D5C7 RID: 54727 RVA: 0x00356F00 File Offset: 0x00355300
	public void SetSendReady()
	{
		this.ResetVoiceInfoTextGo();
		this.EnabledCurrentBtn(false);
		this.SetBtnText(this.VOICE_SEND_READY);
	}

	// Token: 0x0600D5C8 RID: 54728 RVA: 0x00356F1B File Offset: 0x0035531B
	public void SetSendFailed()
	{
		SystemNotifyManager.SysNotifyTextAnimation(this.VOICE_SEND_FAILED, CommonTipsDesc.eShowMode.SI_UNIQUE);
		this.EnabledCurrentBtn(false);
		this.SetSendEnd();
	}

	// Token: 0x0600D5C9 RID: 54729 RVA: 0x00356F36 File Offset: 0x00355336
	public void SetSendCancel()
	{
		SystemNotifyManager.SysNotifyTextAnimation(this.VOICE_SEND_CANCEL, CommonTipsDesc.eShowMode.SI_UNIQUE);
		this.ResetVoiceInfoTextGo();
		this.EnabledCurrentBtn(false);
		this.SetSendEnd();
	}

	// Token: 0x0600D5CA RID: 54730 RVA: 0x00356F57 File Offset: 0x00355357
	public void SetAudioAuthFailed()
	{
		SystemNotifyManager.SysNotifyTextAnimation(this.AUDIO_AUTH_REQUEST, CommonTipsDesc.eShowMode.SI_UNIQUE);
		this.ResetVoiceInfoTextGo();
		this.EnabledCurrentBtn(false);
		this.SetSendEnd();
	}

	// Token: 0x0600D5CB RID: 54731 RVA: 0x00356F78 File Offset: 0x00355378
	public void SetRecordFailed()
	{
		SystemNotifyManager.SysNotifyTextAnimation(this.VOICE_RECORD_FAILED, CommonTipsDesc.eShowMode.SI_UNIQUE);
		this.ResetVoiceInfoTextGo();
		this.EnabledCurrentBtn(false);
		this.SetSendEnd();
	}

	// Token: 0x0600D5CC RID: 54732 RVA: 0x00356F99 File Offset: 0x00355399
	public void SetSendEnd()
	{
		this.EnabledCurrentBtn(true);
		this.ResetUIAtFirst();
		this.delayRecordEnabled = true;
		base.Invoke("ResetDelayToRecord", 1f);
	}

	// Token: 0x0600D5CD RID: 54733 RVA: 0x00356FBF File Offset: 0x003553BF
	public void SetRecordNotEnabled()
	{
		SystemNotifyManager.SysNotifyTextAnimation(this.VOICE_RECORD_NOT_ENABLED, CommonTipsDesc.eShowMode.SI_UNIQUE);
	}

	// Token: 0x0600D5CE RID: 54734 RVA: 0x00356FCD File Offset: 0x003553CD
	public void SetPlayVoiceNotEnabled()
	{
		SystemNotifyManager.SysNotifyTextAnimation(this.VOICE_PLAY_NOT_ENABLED, CommonTipsDesc.eShowMode.SI_UNIQUE);
	}

	// Token: 0x0600D5CF RID: 54735 RVA: 0x00356FDB File Offset: 0x003553DB
	public void SetNotifyInRealVoice()
	{
		SystemNotifyManager.SysNotifyTextAnimation(this.VOICE_RECORD_NOT_ENABLE_INREAL, CommonTipsDesc.eShowMode.SI_UNIQUE);
	}

	// Token: 0x0600D5D0 RID: 54736 RVA: 0x00356FE9 File Offset: 0x003553E9
	public void SetNotLoginChatVoice()
	{
		SystemNotifyManager.SysNotifyTextAnimation(this.VOICE_LOGINING, CommonTipsDesc.eShowMode.SI_UNIQUE);
	}

	// Token: 0x0600D5D1 RID: 54737 RVA: 0x00356FF7 File Offset: 0x003553F7
	private void ResetDelayToRecord()
	{
		this.delayRecordEnabled = false;
	}

	// Token: 0x0600D5D2 RID: 54738 RVA: 0x00357000 File Offset: 0x00355400
	private void EnabledCurrentBtn(bool bEnabled)
	{
		if (this.currentUIGray != null)
		{
			this.currentUIGray.enabled = !bEnabled;
		}
	}

	// Token: 0x0600D5D3 RID: 54739 RVA: 0x00357022 File Offset: 0x00355422
	private bool IsCurrentBtnEnable()
	{
		return !(this.currentUIGray != null) || !this.currentUIGray.enabled;
	}

	// Token: 0x0600D5D4 RID: 54740 RVA: 0x00357045 File Offset: 0x00355445
	private bool IsRecordLimited()
	{
		return this.voiceModule != null && this.voiceModule.Is_RecordVoice_Limited != null && this.voiceModule.Is_RecordVoice_Limited();
	}

	// Token: 0x0600D5D5 RID: 54741 RVA: 0x00357078 File Offset: 0x00355478
	private void Update()
	{
		if (this._isPressed && !this.bLargeRecordVoice)
		{
			float time = Time.time;
			if (this.downBtnStartTime > 0f && time - this.downBtnStartTime > 60f)
			{
				this.bLargeRecordVoice = true;
				this.TryStopRecord();
			}
		}
	}

	// Token: 0x0600D5D6 RID: 54742 RVA: 0x003570D0 File Offset: 0x003554D0
	public void OnPointerDown(PointerEventData eventData)
	{
		if (!this.CheckRecordEnabled())
		{
			return;
		}
		if (this.delayRecordEnabled)
		{
			SystemNotifyManager.SysNotifyTextAnimation(TR.Value("voice_sdk_record_too_frequent"), CommonTipsDesc.eShowMode.SI_UNIQUE);
			return;
		}
		if (this.voiceModule == null || this.voiceModule.currentUsedButton == null)
		{
			return;
		}
		if (null != this.voiceModule.currentUsedButton.currActiveBtn)
		{
			return;
		}
		if (this._isPressed)
		{
			return;
		}
		this._isPressed = true;
		this.InitComponentInBattle();
		if (this.voiceStatusPopup != null)
		{
			this.voiceStatusPopup.SetInfoTextActive(true);
		}
		this.isReadyToSend = true;
		this.bLessRecordVoice = false;
		this.downBtnStartTime = Time.time;
		if (this.voiceModule != null && this.voiceModule.currentUsedButton != null)
		{
			this.voiceModule.currentUsedButton.pointerFirstId = eventData.pointerId;
			this.voiceModule.currentUsedButton.currActiveBtn = this;
			this.voiceModule.CanSendVoice = true;
		}
		this.StartRecord(this.btnType);
		if (this.btnType == VoiceInputType.ComtalkGuild || this.btnType == VoiceInputType.ComtalkTeam)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnVoiceChatComtalkBtnPressed, false, null, null, null);
		}
	}

	// Token: 0x0600D5D7 RID: 54743 RVA: 0x00357218 File Offset: 0x00355618
	public void OnPointerUp(PointerEventData eventData)
	{
		if (!this.CheckRecordEnabled())
		{
			return;
		}
		if (!this.IsOnlyCurrBtnPressed(eventData))
		{
			return;
		}
		this._isPressed = false;
		if (this.btnType == VoiceInputType.ComtalkGuild || this.btnType == VoiceInputType.ComtalkTeam)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnVoiceChatComtalkBtnPressed, true, null, null, null);
		}
		float time = Time.time;
		if (time - this.downBtnStartTime < 1f && this.downBtnStartTime > 0f)
		{
			this.SetRecordFailed();
			this.downBtnStartTime = -0.1f;
			this.bLessRecordVoice = true;
			this.canSend = false;
			if (this.voiceModule != null && this.voiceModule.currentUsedButton != null)
			{
				this.voiceModule.CanSendVoice = this.canSend;
				this.voiceModule.currentUsedButton.Reset();
			}
			this.StopRecord();
			return;
		}
		if (this.bLargeRecordVoice)
		{
			return;
		}
		this.TryStopRecord();
	}

	// Token: 0x0600D5D8 RID: 54744 RVA: 0x00357314 File Offset: 0x00355714
	private void TryStopRecord()
	{
		if (this.isReadyToSend)
		{
			this.canSend = true;
			this.SetSendStart();
		}
		else
		{
			this.canSend = false;
			this.SetSendCancel();
		}
		if (this.voiceModule != null)
		{
			this.voiceModule.CanSendVoice = this.canSend;
		}
		this.StopRecord();
	}

	// Token: 0x0600D5D9 RID: 54745 RVA: 0x00357370 File Offset: 0x00355770
	public void OnPointerExit(PointerEventData eventData)
	{
		if (!this.IsOnlyCurrBtnPressed(eventData))
		{
			return;
		}
		this.SetBtnText(this.DRAG_AWAY_SEND_CANCEL);
		this.InitComponentInBattle();
		if (this.voiceStatusPopup != null)
		{
			this.voiceStatusPopup.SetInfoText(this.DRAG_AWAY_SEND_CANCEL);
			this.voiceStatusPopup.ShowVoiceInfoBg(true);
		}
		this.isReadyToSend = false;
	}

	// Token: 0x0600D5DA RID: 54746 RVA: 0x003573D4 File Offset: 0x003557D4
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!this.IsOnlyCurrBtnPressed(eventData))
		{
			return;
		}
		this.SetBtnText(this.UP_BTN_RECORD_END);
		this.InitComponentInBattle();
		if (this.voiceStatusPopup != null)
		{
			this.voiceStatusPopup.SetInfoText(this.DRAG_UP_SEND_CANCEL);
			this.voiceStatusPopup.ShowVoiceInfoBg(false);
		}
		this.isReadyToSend = true;
	}

	// Token: 0x0600D5DB RID: 54747 RVA: 0x00357438 File Offset: 0x00355838
	private bool IsOnlyCurrBtnPressed(PointerEventData eventData)
	{
		if (!this._isPressed)
		{
			return false;
		}
		if (eventData == null)
		{
			return false;
		}
		if (this.voiceModule == null || this.voiceModule.currentUsedButton == null)
		{
			return false;
		}
		int pointerFirstId = this.voiceModule.currentUsedButton.pointerFirstId;
		return eventData.pointerId == pointerFirstId && !(this.voiceModule.currentUsedButton.currActiveBtn != this);
	}

	// Token: 0x0600D5DC RID: 54748 RVA: 0x003574BC File Offset: 0x003558BC
	private bool CheckRecordEnabled()
	{
		if (!Singleton<PluginManager>.instance.GetAudioAuthorization())
		{
			this.SetAudioAuthFailed();
			return false;
		}
		if (!Singleton<SDKVoiceManager>.GetInstance().IsRecordVoiceEnabled)
		{
			this.SetRecordNotEnabled();
			return false;
		}
		if (!this.isInitialized)
		{
			return false;
		}
		if (!this.IsCurrentBtnEnable())
		{
			return false;
		}
		if (this.IsRecordLimited())
		{
			return false;
		}
		if (Singleton<SDKVoiceManager>.GetInstance().BeInRealVoiceChannel())
		{
			this.SetNotifyInRealVoice();
			return false;
		}
		if (!Singleton<SDKVoiceManager>.GetInstance().CheckLoginChatVoice())
		{
			this.SetNotLoginChatVoice();
			return false;
		}
		return true;
	}

	// Token: 0x0600D5DD RID: 54749 RVA: 0x0035754D File Offset: 0x0035594D
	public void AddStartRecordListener(VoiceInputBtn.StartRecordSendAudio handler)
	{
		this.startRecordSendAudioHandler = handler;
	}

	// Token: 0x0600D5DE RID: 54750 RVA: 0x00357556 File Offset: 0x00355956
	public void RemoveAllStartRecordListener()
	{
		this.startRecordSendAudioHandler = null;
	}

	// Token: 0x0600D5DF RID: 54751 RVA: 0x0035755F File Offset: 0x0035595F
	public void AddStopRecordListener(VoiceInputBtn.StopRecordAudio handler)
	{
		this.stopRecordAudioHandler = handler;
	}

	// Token: 0x0600D5E0 RID: 54752 RVA: 0x00357568 File Offset: 0x00355968
	public void RemoveAllStopRecordListener()
	{
		this.stopRecordAudioHandler = null;
	}

	// Token: 0x0600D5E1 RID: 54753 RVA: 0x00357571 File Offset: 0x00355971
	public void AddCancelRecordListener(VoiceInputBtn.CancelRecordAudio handler)
	{
		this.cancelRecordAudioHandler = handler;
	}

	// Token: 0x0600D5E2 RID: 54754 RVA: 0x0035757A File Offset: 0x0035597A
	public void RemoveAllCancelRecordListener()
	{
		this.cancelRecordAudioHandler = null;
	}

	// Token: 0x0600D5E3 RID: 54755 RVA: 0x00357583 File Offset: 0x00355983
	private void StartRecord(VoiceInputType btnType)
	{
		if (this.startRecordSendAudioHandler != null)
		{
			this.startRecordSendAudioHandler(btnType);
		}
	}

	// Token: 0x0600D5E4 RID: 54756 RVA: 0x0035759C File Offset: 0x0035599C
	private void StopRecord()
	{
		if (this.stopRecordAudioHandler != null)
		{
			this.stopRecordAudioHandler();
		}
	}

	// Token: 0x0600D5E5 RID: 54757 RVA: 0x003575B4 File Offset: 0x003559B4
	private void InitComponentInBattle()
	{
		if (BattleMain.instance == null)
		{
			return;
		}
		if (this.voiceStatusPopup != null)
		{
			return;
		}
		if (this.voiceStatusPopupGoRoot == null)
		{
			return;
		}
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/BattleUI/UIComponent/BattleVoiceShowInfo", true, 0U);
		Utility.AttachTo(gameObject, this.voiceStatusPopupGoRoot, false);
		this.voiceStatusPopup = gameObject.GetComponent<VoiceStatusPopup>();
		if (this.voiceStatusPopup)
		{
			this.voiceStatusPopup.InitComponent();
		}
	}

	// Token: 0x0600D5E6 RID: 54758 RVA: 0x00357636 File Offset: 0x00355A36
	private void CancelRecord()
	{
		if (this.cancelRecordAudioHandler != null)
		{
			this.cancelRecordAudioHandler();
		}
	}

	// Token: 0x04007D83 RID: 32131
	private string DOWN_BTN_RECORD_START = "按 住 说 话";

	// Token: 0x04007D84 RID: 32132
	private string UP_BTN_RECORD_END = "松 开 结 束";

	// Token: 0x04007D85 RID: 32133
	private string DRAG_UP_SEND_CANCEL = "手指移开，取消发送";

	// Token: 0x04007D86 RID: 32134
	private string DRAG_AWAY_SEND_CANCEL = "松开手指，取消发送";

	// Token: 0x04007D87 RID: 32135
	private string VOICE_SEND_READY = "准 备 发 送";

	// Token: 0x04007D88 RID: 32136
	private string VOICE_SEND_CANCEL = "取 消 发 送";

	// Token: 0x04007D89 RID: 32137
	private string VOICE_SENDING = "正 在 发 送";

	// Token: 0x04007D8A RID: 32138
	private string VOICE_SEND_FAILED = "没有听清，请重试";

	// Token: 0x04007D8B RID: 32139
	private string VOICE_RECORD_FAILED = "没有听清，请重试";

	// Token: 0x04007D8C RID: 32140
	private string VOICE_RECORD_NOT_ENABLED = "录音关闭，可在设置中开启";

	// Token: 0x04007D8D RID: 32141
	private string VOICE_PLAY_NOT_ENABLED = "音频播放关闭，可在设置中开启";

	// Token: 0x04007D8E RID: 32142
	private string VOICE_MESSAGE = "[语 音 消 息]";

	// Token: 0x04007D8F RID: 32143
	private string AUDIO_AUTH_REQUEST = "请检查您的麦克风是否开启";

	// Token: 0x04007D90 RID: 32144
	private string VOICE_RECORD_NOT_ENABLE_INREAL = "当前在实时聊天频道，录音聊天功能暂时关闭";

	// Token: 0x04007D91 RID: 32145
	private string VOICE_LOGINING = "还没有准备好，请再试一次";

	// Token: 0x04007D92 RID: 32146
	public UIGray currentUIGray;

	// Token: 0x04007D93 RID: 32147
	public Button thisBtn;

	// Token: 0x04007D94 RID: 32148
	public Text text_btn;

	// Token: 0x04007D95 RID: 32149
	public GameObject text_Go;

	// Token: 0x04007D96 RID: 32150
	[Header("可以为空，但空状态和voiceStatusPopupGoRoot互斥")]
	public GameObject voiceStatusPopupGo;

	// Token: 0x04007D97 RID: 32151
	[Header("可以为空，但空状态和voiceStatusPopupGo互斥")]
	public GameObject voiceStatusPopupGoRoot;

	// Token: 0x04007D98 RID: 32152
	private VoiceStatusPopup voiceStatusPopup;

	// Token: 0x04007D99 RID: 32153
	private bool isInitialized;

	// Token: 0x04007D9A RID: 32154
	private bool canSend;

	// Token: 0x04007D9B RID: 32155
	private bool isReadyToSend;

	// Token: 0x04007D9C RID: 32156
	private bool _isPressed;

	// Token: 0x04007D9D RID: 32157
	private float downBtnStartTime;

	// Token: 0x04007D9E RID: 32158
	private bool bLessRecordVoice;

	// Token: 0x04007D9F RID: 32159
	private bool bLargeRecordVoice;

	// Token: 0x04007DA0 RID: 32160
	private bool delayRecordEnabled;

	// Token: 0x04007DA1 RID: 32161
	private VoiceChatModule voiceModule;

	// Token: 0x04007DA2 RID: 32162
	private VoiceInputType btnType;

	// Token: 0x04007DA3 RID: 32163
	private VoiceInputBtn.StartRecordSendAudio startRecordSendAudioHandler;

	// Token: 0x04007DA4 RID: 32164
	private VoiceInputBtn.StopRecordAudio stopRecordAudioHandler;

	// Token: 0x04007DA5 RID: 32165
	private VoiceInputBtn.CancelRecordAudio cancelRecordAudioHandler;

	// Token: 0x02001563 RID: 5475
	private enum VoiceBtnStatus
	{
		// Token: 0x04007DA7 RID: 32167
		None,
		// Token: 0x04007DA8 RID: 32168
		Down,
		// Token: 0x04007DA9 RID: 32169
		Up,
		// Token: 0x04007DAA RID: 32170
		IsDragUp,
		// Token: 0x04007DAB RID: 32171
		IsDragDown
	}

	// Token: 0x02001564 RID: 5476
	// (Invoke) Token: 0x0600D5E8 RID: 54760
	public delegate void StartRecordSendAudio(VoiceInputType btnType);

	// Token: 0x02001565 RID: 5477
	// (Invoke) Token: 0x0600D5EC RID: 54764
	public delegate void StopRecordAudio();

	// Token: 0x02001566 RID: 5478
	// (Invoke) Token: 0x0600D5F0 RID: 54768
	public delegate void CancelRecordAudio();
}
