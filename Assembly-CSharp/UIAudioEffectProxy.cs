using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020000FD RID: 253
public class UIAudioEffectProxy : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	// Token: 0x06000555 RID: 1365 RVA: 0x00023779 File Offset: 0x00021B79
	private void Start()
	{
		this.m_Gray = base.gameObject.transform.GetComponent<UIGray>();
	}

	// Token: 0x06000556 RID: 1366 RVA: 0x00023794 File Offset: 0x00021B94
	private void OnEnable()
	{
		if (null != this.m_AudioEffOnEnable)
		{
			MonoSingleton<AudioManager>.instance.PlaySound(this.m_AudioEffOnEnable, AudioType.AudioEffect, 1f, false, null, false, false, null, 1f);
		}
	}

	// Token: 0x06000557 RID: 1367 RVA: 0x000237D4 File Offset: 0x00021BD4
	private void OnDisable()
	{
		if (null != this.m_AudioEffOnDisable)
		{
			MonoSingleton<AudioManager>.instance.PlaySound(this.m_AudioEffOnDisable, AudioType.AudioEffect, 1f, false, null, false, false, null, 1f);
		}
	}

	// Token: 0x06000558 RID: 1368 RVA: 0x00023814 File Offset: 0x00021C14
	void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
	{
		if (null != this.m_AudioEffOnPress)
		{
			if (null != this.m_Gray)
			{
				if (!this.m_Gray.isActiveAndEnabled)
				{
					MonoSingleton<AudioManager>.instance.PlaySound(this.m_AudioEffOnPress, AudioType.AudioEffect, 1f, false, null, false, false, null, 1f);
				}
			}
			else
			{
				MonoSingleton<AudioManager>.instance.PlaySound(this.m_AudioEffOnPress, AudioType.AudioEffect, 1f, false, null, false, false, null, 1f);
			}
		}
	}

	// Token: 0x040004C6 RID: 1222
	public AudioClip m_AudioEffOnPress;

	// Token: 0x040004C7 RID: 1223
	public AudioClip m_AudioEffOnEnable;

	// Token: 0x040004C8 RID: 1224
	public AudioClip m_AudioEffOnDisable;

	// Token: 0x040004C9 RID: 1225
	protected UIGray m_Gray;
}
