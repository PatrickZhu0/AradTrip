using System;
using UnityEngine;

// Token: 0x02000013 RID: 19
public class BossController : MonoBehaviour
{
	// Token: 0x06000068 RID: 104 RVA: 0x00006EC4 File Offset: 0x000052C4
	private void Start()
	{
		this.initPos = base.gameObject.transform.localPosition;
	}

	// Token: 0x06000069 RID: 105 RVA: 0x00006EDC File Offset: 0x000052DC
	public void SetUp()
	{
		this.bUpdate = false;
		base.gameObject.transform.localPosition = this.UpPosition;
	}

	// Token: 0x0600006A RID: 106 RVA: 0x00006EFB File Offset: 0x000052FB
	public void Begin()
	{
		this.bUpdate = true;
		this.beginTime = 0f;
	}

	// Token: 0x0600006B RID: 107 RVA: 0x00006F10 File Offset: 0x00005310
	private void Update()
	{
		if (!this.bUpdate)
		{
			return;
		}
		this.beginTime += Time.deltaTime;
		if (this.beginTime > this.time)
		{
			this.bUpdate = false;
			base.gameObject.transform.localPosition = this.initPos;
		}
		else
		{
			float num = Mathf.Repeat(this.beginTime, this.time) / this.time;
			num = this.doCurve.Evaluate(num);
			base.gameObject.transform.localPosition = Vector3.Lerp(this.UpPosition, this.initPos, num);
		}
	}

	// Token: 0x04000047 RID: 71
	private Vector3 initPos;

	// Token: 0x04000048 RID: 72
	private bool bUpdate;

	// Token: 0x04000049 RID: 73
	public Vector3 UpPosition;

	// Token: 0x0400004A RID: 74
	public AnimationCurve doCurve;

	// Token: 0x0400004B RID: 75
	public float time;

	// Token: 0x0400004C RID: 76
	private float beginTime;
}
