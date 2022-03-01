using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x0200107A RID: 4218
public class BuffTipsScrollRectHandle : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IPointerUpHandler, IEventSystemHandler
{
	// Token: 0x06009F6D RID: 40813 RVA: 0x001FE805 File Offset: 0x001FCC05
	private void OnEnable()
	{
		this.ResetFlag();
	}

	// Token: 0x06009F6E RID: 40814 RVA: 0x001FE80D File Offset: 0x001FCC0D
	public void ResetFlag()
	{
		this.mBeginDragFlag = false;
		this.mPointerDownFlag = false;
		this.mPointerUpFlag = false;
	}

	// Token: 0x06009F6F RID: 40815 RVA: 0x001FE824 File Offset: 0x001FCC24
	public void OnBeginDrag(PointerEventData eventData)
	{
		this.mBeginDragFlag = true;
	}

	// Token: 0x06009F70 RID: 40816 RVA: 0x001FE82D File Offset: 0x001FCC2D
	public void OnPointerDown(PointerEventData eventData)
	{
		this.mPointerDownFlag = true;
	}

	// Token: 0x06009F71 RID: 40817 RVA: 0x001FE836 File Offset: 0x001FCC36
	public void OnPointerUp(PointerEventData eventData)
	{
		this.mPointerUpFlag = true;
	}

	// Token: 0x040057E5 RID: 22501
	public bool mBeginDragFlag;

	// Token: 0x040057E6 RID: 22502
	public bool mPointerDownFlag;

	// Token: 0x040057E7 RID: 22503
	public bool mPointerUpFlag;
}
