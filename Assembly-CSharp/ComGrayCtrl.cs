using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02001A1E RID: 6686
public class ComGrayCtrl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IEventSystemHandler
{
	// Token: 0x060106BC RID: 67260 RVA: 0x0049EAB3 File Offset: 0x0049CEB3
	private void OnEnable()
	{
		this.comGray = base.gameObject.GetComponent<UIGray>();
		this.SetGrayEnable(true);
	}

	// Token: 0x060106BD RID: 67261 RVA: 0x0049EACD File Offset: 0x0049CECD
	private void OnDisable()
	{
		this.comGray = null;
	}

	// Token: 0x060106BE RID: 67262 RVA: 0x0049EAD6 File Offset: 0x0049CED6
	public void OnPointerDown(PointerEventData eventData)
	{
		this.SetGrayEnable(false);
	}

	// Token: 0x060106BF RID: 67263 RVA: 0x0049EADF File Offset: 0x0049CEDF
	public void OnPointerUp(PointerEventData eventData)
	{
		this.SetGrayEnable(true);
	}

	// Token: 0x060106C0 RID: 67264 RVA: 0x0049EAE8 File Offset: 0x0049CEE8
	private void SetGrayEnable(bool isEnable)
	{
		if (this.isGrayEnabled == isEnable)
		{
			return;
		}
		this.isGrayEnabled = isEnable;
		if (this.comGray)
		{
			this.comGray.enabled = this.isGrayEnabled;
		}
	}

	// Token: 0x0400A6D9 RID: 42713
	private UIGray comGray;

	// Token: 0x0400A6DA RID: 42714
	private bool isGrayEnabled;
}
