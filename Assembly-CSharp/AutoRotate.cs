using System;
using UnityEngine;

// Token: 0x02000CBF RID: 3263
public class AutoRotate : MonoBehaviour
{
	// Token: 0x0600866E RID: 34414 RVA: 0x001778AC File Offset: 0x00175CAC
	private void Update()
	{
		base.transform.Rotate(this.xSpeed * Time.deltaTime, this.ySpeed * Time.deltaTime, this.zSpeed * Time.deltaTime);
	}

	// Token: 0x04004051 RID: 16465
	public float xSpeed;

	// Token: 0x04004052 RID: 16466
	public float ySpeed;

	// Token: 0x04004053 RID: 16467
	public float zSpeed;
}
