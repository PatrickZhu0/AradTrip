using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02001567 RID: 5479
public class VoiceStatusPopup : MonoBehaviour
{
	// Token: 0x0600D5F4 RID: 54772 RVA: 0x00357658 File Offset: 0x00355A58
	public void InitComponent()
	{
		if (this.isInited)
		{
			return;
		}
		this.text_info_go = base.gameObject;
		if (this.text_info_go && this.mic_start_decibel)
		{
			this.mic_start_decibel.type = 3;
			this.mic_start_decibel.fillMethod = 1;
		}
	}

	// Token: 0x0600D5F5 RID: 54773 RVA: 0x003576B5 File Offset: 0x00355AB5
	private void OnDestroy()
	{
		this.isInited = false;
		this._Clear();
	}

	// Token: 0x0600D5F6 RID: 54774 RVA: 0x003576C4 File Offset: 0x00355AC4
	private void OnDisable()
	{
		this._Clear();
	}

	// Token: 0x0600D5F7 RID: 54775 RVA: 0x003576CC File Offset: 0x00355ACC
	private void _Clear()
	{
		base.StopAllCoroutines();
		this.PlayMicDecibelImage(0f);
		if (this.autoPlayTexCor != null)
		{
			base.StopCoroutine(this.autoPlayTexCor);
			this.autoPlayTexCor = null;
		}
	}

	// Token: 0x0600D5F8 RID: 54776 RVA: 0x003576FD File Offset: 0x00355AFD
	public void AutoPlayMicDecibelImage(bool isPlay)
	{
		if (base.gameObject.activeSelf)
		{
			if (this.autoPlayTexCor != null)
			{
				base.StopCoroutine(this.autoPlayTexCor);
			}
			this.autoPlayTexCor = base.StartCoroutine(this.PlayDecibelImageLoop(isPlay));
		}
	}

	// Token: 0x0600D5F9 RID: 54777 RVA: 0x0035773C File Offset: 0x00355B3C
	private IEnumerator PlayDecibelImageLoop(bool isLoop)
	{
		float value = 0f;
		float duration = VoiceDataHelper.VoiceRecordTexDuration;
		while (isLoop)
		{
			if (value > 1f)
			{
				value = 0f;
			}
			this.PlayMicDecibelImage(value);
			yield return Yielders.GetWaitForSeconds(duration);
			value += 0.2f;
			yield return null;
		}
		this.PlayMicDecibelImage(0f);
		yield break;
	}

	// Token: 0x0600D5FA RID: 54778 RVA: 0x00357760 File Offset: 0x00355B60
	public void PlayMicDecibelImage(float voiceDecibel)
	{
		if (voiceDecibel < 0f || voiceDecibel > 1f)
		{
			return;
		}
		voiceDecibel = ((voiceDecibel >= 0.2f) ? ((voiceDecibel >= 0.4f) ? ((voiceDecibel >= 0.6f) ? ((voiceDecibel >= 0.8f) ? ((voiceDecibel >= 1f) ? 0f : 1f) : 0.8f) : 0.6f) : 0.4f) : 0.2f);
		if (this.mic_start_decibel)
		{
			this.mic_start_decibel.fillAmount = voiceDecibel;
		}
	}

	// Token: 0x0600D5FB RID: 54779 RVA: 0x00357810 File Offset: 0x00355C10
	public void SetVoiceInfoPos()
	{
		if (this.text_info_go)
		{
			RectTransform component = this.text_info_go.GetComponent<RectTransform>();
			component.anchoredPosition = new Vector2((float)Screen.width / 2f, (float)Screen.height / 2f);
		}
	}

	// Token: 0x0600D5FC RID: 54780 RVA: 0x0035785C File Offset: 0x00355C5C
	public void ShowVoiceInfoBg(bool isShow)
	{
		if (this.text_info_bg)
		{
			this.text_info_bg.CustomActive(isShow);
			if (this.mic_start_show)
			{
				this.mic_start_show.CustomActive(!isShow);
			}
			if (this.mic_start_decibel)
			{
				this.mic_start_decibel.CustomActive(!isShow);
			}
			if (this.mic_stop_show)
			{
				this.mic_stop_show.CustomActive(isShow);
			}
		}
	}

	// Token: 0x0600D5FD RID: 54781 RVA: 0x003578DF File Offset: 0x00355CDF
	public void SetInfoText(string text)
	{
		if (this.text_info)
		{
			this.text_info.text = text;
		}
	}

	// Token: 0x0600D5FE RID: 54782 RVA: 0x003578FD File Offset: 0x00355CFD
	public void SetInfoTextActive(bool isShow)
	{
		if (this.text_info_go)
		{
			this.text_info_go.CustomActive(isShow);
			this.AutoPlayMicDecibelImage(isShow);
		}
	}

	// Token: 0x04007DAC RID: 32172
	private GameObject text_info_go;

	// Token: 0x04007DAD RID: 32173
	public Image text_info_bg;

	// Token: 0x04007DAE RID: 32174
	public Text text_info;

	// Token: 0x04007DAF RID: 32175
	public Image mic_start_show;

	// Token: 0x04007DB0 RID: 32176
	public Image mic_start_decibel;

	// Token: 0x04007DB1 RID: 32177
	public Image mic_stop_show;

	// Token: 0x04007DB2 RID: 32178
	private Coroutine autoPlayTexCor;

	// Token: 0x04007DB3 RID: 32179
	private bool isInited;
}
