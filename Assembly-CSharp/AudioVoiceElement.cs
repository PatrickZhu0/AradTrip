using System;
using GameClient;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02001551 RID: 5457
public class AudioVoiceElement : MonoBehaviour
{
	// Token: 0x0600D544 RID: 54596 RVA: 0x003552B8 File Offset: 0x003536B8
	private void Awake()
	{
		this.voiceImg = base.gameObject.GetComponent<Image>();
		this.thisSpriteAnim = base.gameObject.GetComponent<UGUISpriteAnimation>();
		this.voice_level_3 = (Singleton<AssetLoader>.instance.LoadRes("UIFlatten/Image/Packed/pck_UI_Common00.png:UI_Common_IconVoice", typeof(Sprite), false, 0U).obj as Sprite);
		this.currPlayStatus = AudioVoiceElement.AudioVoicePlayStatus.Recycle;
	}

	// Token: 0x0600D545 RID: 54597 RVA: 0x00355319 File Offset: 0x00353719
	private void OnEnable()
	{
		this.AddUIEvent();
	}

	// Token: 0x0600D546 RID: 54598 RVA: 0x00355321 File Offset: 0x00353721
	private void OnDisable()
	{
		this.RemoveUIEvent();
	}

	// Token: 0x0600D547 RID: 54599 RVA: 0x0035532C File Offset: 0x0035372C
	private void AddUIEvent()
	{
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnVoiceChatPlayStart, new ClientEventSystem.UIEventHandler(this.OnVoicePlayStart));
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnVoiceChatPlayEnd, new ClientEventSystem.UIEventHandler(this.OnVoicePlayEnd));
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnVoiceChatPlayReset, new ClientEventSystem.UIEventHandler(this.OnVoicePlayEnd));
	}

	// Token: 0x0600D548 RID: 54600 RVA: 0x0035538C File Offset: 0x0035378C
	private void RemoveUIEvent()
	{
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnVoiceChatPlayStart, new ClientEventSystem.UIEventHandler(this.OnVoicePlayStart));
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnVoiceChatPlayEnd, new ClientEventSystem.UIEventHandler(this.OnVoicePlayEnd));
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnVoiceChatPlayReset, new ClientEventSystem.UIEventHandler(this.OnVoicePlayEnd));
	}

	// Token: 0x0600D549 RID: 54601 RVA: 0x003553EA File Offset: 0x003537EA
	private void OnDestroy()
	{
		this.RemoveUIEvent();
		this.thisSpriteAnim = null;
		this.voiceImg = null;
		this.voice_level_3 = null;
	}

	// Token: 0x0600D54A RID: 54602 RVA: 0x00355407 File Offset: 0x00353807
	private void OnVoicePlayStart(UIEvent evt)
	{
		if (this.currPlayStatus == AudioVoiceElement.AudioVoicePlayStatus.Recycle)
		{
			return;
		}
		this.StartPlayVoiceTex();
	}

	// Token: 0x0600D54B RID: 54603 RVA: 0x0035541B File Offset: 0x0035381B
	private void OnVoicePlayEnd(UIEvent evt)
	{
		if (this.currPlayStatus == AudioVoiceElement.AudioVoicePlayStatus.Recycle)
		{
			return;
		}
		this.StopPlayVoiceTex();
	}

	// Token: 0x0600D54C RID: 54604 RVA: 0x0035542F File Offset: 0x0035382F
	private void StartPlayVoiceTex()
	{
		if (this.thisSpriteAnim)
		{
			this.thisSpriteAnim.IsPlaying = true;
		}
	}

	// Token: 0x0600D54D RID: 54605 RVA: 0x0035544D File Offset: 0x0035384D
	private void StopPlayVoiceTex()
	{
		if (this.thisSpriteAnim)
		{
			this.thisSpriteAnim.IsPlaying = false;
		}
		this.RecyclePlayVoiceTex();
	}

	// Token: 0x0600D54E RID: 54606 RVA: 0x00355471 File Offset: 0x00353871
	public void RecyclePlayVoiceTex()
	{
		this.ResetVoiceImg();
		this.currPlayStatus = AudioVoiceElement.AudioVoicePlayStatus.Recycle;
	}

	// Token: 0x0600D54F RID: 54607 RVA: 0x00355480 File Offset: 0x00353880
	public void ResetPlayVoiceTex()
	{
		this.ResetVoiceImg();
		UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnVoiceChatPlayReset, null, null, null, null);
		this.currPlayStatus = AudioVoiceElement.AudioVoicePlayStatus.Use;
	}

	// Token: 0x0600D550 RID: 54608 RVA: 0x003554A2 File Offset: 0x003538A2
	private void ResetVoiceImg()
	{
		if (this.voiceImg != null)
		{
			this.voiceImg.sprite = this.voice_level_3;
		}
	}

	// Token: 0x04007D3A RID: 32058
	private UGUISpriteAnimation thisSpriteAnim;

	// Token: 0x04007D3B RID: 32059
	private Sprite voice_level_3;

	// Token: 0x04007D3C RID: 32060
	private Image voiceImg;

	// Token: 0x04007D3D RID: 32061
	private AudioVoiceElement.AudioVoicePlayStatus currPlayStatus;

	// Token: 0x02001552 RID: 5458
	private enum AudioVoicePlayStatus
	{
		// Token: 0x04007D3F RID: 32063
		Recycle,
		// Token: 0x04007D40 RID: 32064
		Use
	}
}
