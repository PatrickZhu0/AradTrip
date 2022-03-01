using System;
using UnityEngine;

// Token: 0x02000ED4 RID: 3796
[ExecuteInEditMode]
public class ComDungeonRewardTipPosition : MonoBehaviour
{
	// Token: 0x0600953F RID: 38207 RVA: 0x001C24B6 File Offset: 0x001C08B6
	public void SetPosition(RectTransform trans)
	{
		if (this.mTransform != trans)
		{
			this.mTransform = trans;
			this._updatePostion();
		}
	}

	// Token: 0x06009540 RID: 38208 RVA: 0x001C24D8 File Offset: 0x001C08D8
	public void _updatePostion()
	{
		RectTransform component = base.GetComponent<RectTransform>();
		Vector2 offsetMin = component.offsetMin;
		Vector2 offsetMax = component.offsetMax;
		component.offsetMin = new Vector2(this.mTransform.offsetMin.x, offsetMin.y);
		component.offsetMax = new Vector2(this.mTransform.offsetMax.x, offsetMax.y);
	}

	// Token: 0x04004C1F RID: 19487
	public RectTransform mTransform;
}
