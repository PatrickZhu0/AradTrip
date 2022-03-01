using System;
using UnityEngine;

// Token: 0x02000D72 RID: 3442
public class GeEffectProperty : MonoBehaviour
{
	// Token: 0x06008BC3 RID: 35779 RVA: 0x0019C764 File Offset: 0x0019AB64
	private void Start()
	{
		this.firstAccess = false;
		if (this.mTrasform == null)
		{
			this.mTrasform = base.gameObject.transform;
		}
	}

	// Token: 0x06008BC4 RID: 35780 RVA: 0x0019C790 File Offset: 0x0019AB90
	private void LateUpdate()
	{
		if (this.mTrasform != null)
		{
			if (this.isBillBord && this.mTrasform.lossyScale.x <= 0f)
			{
				Vector3 localScale = this.mTrasform.localScale;
				localScale.x *= -1f;
				this.mTrasform.localScale = localScale;
			}
			if (this.isNoRotate)
			{
				this.mTrasform.rotation = Quaternion.identity;
			}
			if (this.isTouchGround)
			{
				if (!this.firstAccess)
				{
					this.delta = this.mTrasform.position.z - this.mTrasform.position.y;
					this.firstAccess = true;
				}
				else if (this.mTrasform.position.z - this.mTrasform.position.y != this.delta)
				{
					Vector3 position = this.mTrasform.position;
					position.y = this.mTrasform.position.z - this.delta;
					this.mTrasform.position = position;
				}
			}
		}
	}

	// Token: 0x04004506 RID: 17670
	[Header("是否不随角色镜像(公告板)")]
	public bool isBillBord;

	// Token: 0x04004507 RID: 17671
	[HideInInspector]
	public bool isTouchGround;

	// Token: 0x04004508 RID: 17672
	[HideInInspector]
	public int forceZOrder;

	// Token: 0x04004509 RID: 17673
	[Header("是否不随角色旋转")]
	public bool isNoRotate;

	// Token: 0x0400450A RID: 17674
	private Transform mTrasform;

	// Token: 0x0400450B RID: 17675
	private bool firstAccess;

	// Token: 0x0400450C RID: 17676
	private float delta;
}
