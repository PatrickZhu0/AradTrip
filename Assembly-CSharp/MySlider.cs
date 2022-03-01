using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000084 RID: 132
[RequireComponent(typeof(RectTransform))]
internal class MySlider : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler, IEventSystemHandler
{
	// Token: 0x1700001D RID: 29
	// (get) Token: 0x060002D3 RID: 723 RVA: 0x00015C0A File Offset: 0x0001400A
	// (set) Token: 0x060002D4 RID: 724 RVA: 0x00015C12 File Offset: 0x00014012
	public float Value
	{
		get
		{
			return this.fValue;
		}
		set
		{
			this.fValue = value;
			this._AlignSlider();
			if (this.onValueChanged != null)
			{
				this.onValueChanged();
			}
		}
	}

	// Token: 0x060002D5 RID: 725 RVA: 0x00015C38 File Offset: 0x00014038
	public void Start()
	{
		this.sliderZone.anchorMin = this.sliderZone.anchorMax;
		this.slider.anchorMin = this.slider.anchorMax;
		this._AlignSlider();
		this.bDrag = false;
		this.offset = Vector2.zero;
	}

	// Token: 0x060002D6 RID: 726 RVA: 0x00015C8C File Offset: 0x0001408C
	private void _AlignSlider()
	{
		if (this.m_eSliderType == MySlider.SliderType.ST_HORIZEN)
		{
			float num = this.canvas.sizeDelta.x * this.sliderZone.anchorMin.x + this.sliderZone.anchoredPosition.x - this.sliderZone.sizeDelta.x * this.sliderZone.pivot.x + this.fValue * this.sliderZone.sizeDelta.x;
			this.slider.anchoredPosition = new Vector2(num - this.canvas.sizeDelta.x * this.slider.anchorMin.x, this.slider.anchoredPosition.y);
		}
		else
		{
			float num2 = this.canvas.sizeDelta.y * this.sliderZone.anchorMin.x + this.sliderZone.anchoredPosition.y - this.sliderZone.sizeDelta.y * this.sliderZone.pivot.y + this.fValue * this.sliderZone.sizeDelta.y;
			this.slider.anchoredPosition = new Vector2(this.slider.anchoredPosition.x, num2 - this.canvas.sizeDelta.y * this.slider.anchorMin.y);
		}
	}

	// Token: 0x060002D7 RID: 727 RVA: 0x00015E50 File Offset: 0x00014250
	public void OnPointerDown(PointerEventData eventData)
	{
		Vector2 position = eventData.position;
		Vector2 vector = default(Vector2);
		bool flag = RectTransformUtility.ScreenPointToLocalPointInRectangle(this.canvas, position, eventData.enterEventCamera, ref vector);
		if (flag)
		{
			this.bDrag = true;
			if (this.m_eSliderType == MySlider.SliderType.ST_HORIZEN)
			{
				this.offset = this.slider.anchoredPosition - new Vector2(vector.x, 0f);
			}
			else
			{
				this.offset = this.slider.anchoredPosition - new Vector2(0f, vector.y);
			}
		}
	}

	// Token: 0x060002D8 RID: 728 RVA: 0x00015EEC File Offset: 0x000142EC
	public void OnDrag(PointerEventData eventData)
	{
		if (!this.bDrag)
		{
			return;
		}
		Vector2 position = eventData.position;
		Vector2 vector = default(Vector2);
		bool flag = RectTransformUtility.ScreenPointToLocalPointInRectangle(this.canvas, position, eventData.enterEventCamera, ref vector);
		if (flag)
		{
			Vector2 offsetMin = this.sliderZone.offsetMin;
			Vector2 offsetMax = this.sliderZone.offsetMax;
			float num = this.fValue;
			if (this.m_eSliderType == MySlider.SliderType.ST_HORIZEN)
			{
				float num2 = this.sliderZone.anchoredPosition.x - this.sliderZone.pivot.x * this.sliderZone.sizeDelta.x;
				float num3 = num2 + this.sliderZone.sizeDelta.x;
				vector.x = Mathf.Clamp(vector.x, num2, num3);
				this.slider.anchoredPosition = this.offset + new Vector2(vector.x, 0f);
				this.fValue = (vector.x - num2) / (num3 - num2);
			}
			else
			{
				float num4 = this.sliderZone.anchoredPosition.y - this.sliderZone.pivot.y * this.sliderZone.sizeDelta.y;
				float num5 = num4 + this.sliderZone.sizeDelta.y;
				vector.y = Mathf.Clamp(vector.y, num4, num5);
				this.slider.anchoredPosition = this.offset + new Vector2(0f, vector.y);
				this.fValue = (vector.y - num4) / (num5 - num4);
			}
			if (!object.Equals(this.fValue, num) && this.onValueChanged != null)
			{
				this.onValueChanged();
			}
		}
	}

	// Token: 0x060002D9 RID: 729 RVA: 0x000160EC File Offset: 0x000144EC
	public void OnEndDrag(PointerEventData eventData)
	{
		this.offset = Vector2.zero;
		this.bDrag = false;
	}

	// Token: 0x040002C6 RID: 710
	public RectTransform sliderZone;

	// Token: 0x040002C7 RID: 711
	public RectTransform slider;

	// Token: 0x040002C8 RID: 712
	public RectTransform canvas;

	// Token: 0x040002C9 RID: 713
	public MySlider.SliderType m_eSliderType;

	// Token: 0x040002CA RID: 714
	public MySlider.OnValueChanged onValueChanged;

	// Token: 0x040002CB RID: 715
	public Image imgSlider;

	// Token: 0x040002CC RID: 716
	public Image imgSliderZone;

	// Token: 0x040002CD RID: 717
	private Vector2 offset;

	// Token: 0x040002CE RID: 718
	private bool bDrag;

	// Token: 0x040002CF RID: 719
	private float fValue;

	// Token: 0x02000085 RID: 133
	// (Invoke) Token: 0x060002DB RID: 731
	public delegate void OnValueChanged();

	// Token: 0x02000086 RID: 134
	public enum SliderType
	{
		// Token: 0x040002D1 RID: 721
		ST_HORIZEN,
		// Token: 0x040002D2 RID: 722
		ST_VERTICAL
	}
}
