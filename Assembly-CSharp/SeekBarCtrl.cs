using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020048D5 RID: 18645
public class SeekBarCtrl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IEventSystemHandler
{
	// Token: 0x0601AD46 RID: 109894 RVA: 0x00840ADD File Offset: 0x0083EEDD
	private void Start()
	{
	}

	// Token: 0x0601AD47 RID: 109895 RVA: 0x00840AE0 File Offset: 0x0083EEE0
	private void Update()
	{
		if (!this.m_bActiveDrag)
		{
			this.m_fDeltaTime += Time.deltaTime;
			if (this.m_fDeltaTime > this.m_fDragTime)
			{
				this.m_bActiveDrag = true;
				this.m_fDeltaTime = 0f;
			}
		}
		if (!this.m_bUpdate)
		{
			return;
		}
		if (this.m_srcVideo != null && this.m_srcSlider != null)
		{
			this.m_srcSlider.value = this.m_srcVideo.GetSeekBarValue();
		}
	}

	// Token: 0x0601AD48 RID: 109896 RVA: 0x00840B71 File Offset: 0x0083EF71
	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("OnPointerEnter:");
		this.m_bUpdate = false;
	}

	// Token: 0x0601AD49 RID: 109897 RVA: 0x00840B84 File Offset: 0x0083EF84
	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log("OnPointerExit:");
		this.m_bUpdate = true;
	}

	// Token: 0x0601AD4A RID: 109898 RVA: 0x00840B97 File Offset: 0x0083EF97
	public void OnPointerDown(PointerEventData eventData)
	{
	}

	// Token: 0x0601AD4B RID: 109899 RVA: 0x00840B99 File Offset: 0x0083EF99
	public void OnPointerUp(PointerEventData eventData)
	{
		this.m_srcVideo.SetSeekBarValue(this.m_srcSlider.value);
	}

	// Token: 0x0601AD4C RID: 109900 RVA: 0x00840BB4 File Offset: 0x0083EFB4
	public void OnDrag(PointerEventData eventData)
	{
		Debug.Log("OnDrag:" + eventData);
		if (!this.m_bActiveDrag)
		{
			this.m_fLastValue = this.m_srcSlider.value;
			return;
		}
		this.m_srcVideo.SetSeekBarValue(this.m_srcSlider.value);
		this.m_fLastSetValue = this.m_srcSlider.value;
		this.m_bActiveDrag = false;
	}

	// Token: 0x04012AB1 RID: 76465
	public MediaPlayerCtrl m_srcVideo;

	// Token: 0x04012AB2 RID: 76466
	public Slider m_srcSlider;

	// Token: 0x04012AB3 RID: 76467
	public float m_fDragTime = 0.2f;

	// Token: 0x04012AB4 RID: 76468
	private bool m_bActiveDrag = true;

	// Token: 0x04012AB5 RID: 76469
	private bool m_bUpdate = true;

	// Token: 0x04012AB6 RID: 76470
	private float m_fDeltaTime;

	// Token: 0x04012AB7 RID: 76471
	private float m_fLastValue;

	// Token: 0x04012AB8 RID: 76472
	private float m_fLastSetValue;
}
