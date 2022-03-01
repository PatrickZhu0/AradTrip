using System;
using UnityEngine;

// Token: 0x02000164 RID: 356
public class XCameraScrollScript : MonoBehaviour
{
	// Token: 0x06000A52 RID: 2642 RVA: 0x00035E00 File Offset: 0x00034200
	private void Start()
	{
		if (this.CameraObject)
		{
			this.Pos = base.gameObject.transform.localPosition;
		}
		else
		{
			this.CameraObject = GameObject.Find("Main Camera");
			this.Pos = base.gameObject.transform.localPosition;
		}
		this.fTargetX = this.CameraObject.transform.position.x;
	}

	// Token: 0x06000A53 RID: 2643 RVA: 0x00035E7C File Offset: 0x0003427C
	public void Init()
	{
		if (this.CameraObject)
		{
			this.Pos = base.gameObject.transform.localPosition;
		}
	}

	// Token: 0x06000A54 RID: 2644 RVA: 0x00035EA4 File Offset: 0x000342A4
	public void UpdateForce()
	{
		if (this.CameraObject)
		{
			this.Pos = base.gameObject.transform.localPosition;
			this.fOffset = this.CameraObject.transform.position.x;
		}
	}

	// Token: 0x06000A55 RID: 2645 RVA: 0x00035EF8 File Offset: 0x000342F8
	public void ForceUpdate()
	{
		if (this.CameraObject)
		{
			this.fTargetX = this.CameraObject.transform.position.x;
			Vector3 vector;
			vector..ctor((this.fTargetX - this.fOffset) * this.fSpeed, 0f, 0f);
			vector = base.gameObject.transform.InverseTransformVector(vector);
			base.gameObject.transform.localPosition = this.Pos + vector;
		}
	}

	// Token: 0x06000A56 RID: 2646 RVA: 0x00035F88 File Offset: 0x00034388
	private void Update()
	{
		if (this.CameraObject)
		{
			this.fTargetX = Mathf.SmoothDamp(this.fTargetX, this.CameraObject.transform.position.x, ref this.fVec, 0.03f);
			Vector3 vector;
			vector..ctor((this.fTargetX - this.fOffset) * this.fSpeed, 0f, 0f);
			vector = base.gameObject.transform.InverseTransformVector(vector);
			base.gameObject.transform.localPosition = this.Pos + vector;
		}
	}

	// Token: 0x04000799 RID: 1945
	public GameObject CameraObject;

	// Token: 0x0400079A RID: 1946
	public float fSpeed;

	// Token: 0x0400079B RID: 1947
	public float fOffset;

	// Token: 0x0400079C RID: 1948
	public float fTargetX;

	// Token: 0x0400079D RID: 1949
	private float fVec;

	// Token: 0x0400079E RID: 1950
	[HideInInspector]
	[NonSerialized]
	protected Vector3 Pos;

	// Token: 0x0400079F RID: 1951
	[HideInInspector]
	[NonSerialized]
	public bool bPauseScroll = true;
}
