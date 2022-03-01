using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02000F02 RID: 3842
public class ComLongPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IEventSystemHandler
{
	// Token: 0x0600962A RID: 38442 RVA: 0x001C6AFF File Offset: 0x001C4EFF
	public void SetArgs(object args)
	{
		this.args = args;
	}

	// Token: 0x0600962B RID: 38443 RVA: 0x001C6B08 File Offset: 0x001C4F08
	public void OnPointerDown(PointerEventData eventData)
	{
		if (this.pointDownCallBack != null)
		{
			this.pointDownCallBack(base.transform, this.args);
		}
	}

	// Token: 0x0600962C RID: 38444 RVA: 0x001C6B2C File Offset: 0x001C4F2C
	public void OnPointerUp(PointerEventData eventData)
	{
		if (this.pointUpCallBack != null)
		{
			this.pointUpCallBack(this.args);
		}
	}

	// Token: 0x04004D0E RID: 19726
	public Action<Transform, object> pointDownCallBack;

	// Token: 0x04004D0F RID: 19727
	public Action<object> pointUpCallBack;

	// Token: 0x04004D10 RID: 19728
	private object args;
}
