using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000248 RID: 584
public class UpdateBlur : MonoBehaviour
{
	// Token: 0x06001326 RID: 4902 RVA: 0x00066E9B File Offset: 0x0006529B
	private void Start()
	{
		base.GetComponent<Image>().material.SetFloat("_Distance", this.DurationTime);
	}

	// Token: 0x06001327 RID: 4903 RVA: 0x00066EB8 File Offset: 0x000652B8
	private void Update()
	{
		this.DelayTime -= Time.deltaTime;
		if (this.DelayTime <= 0f)
		{
			this.DurationTime -= Time.deltaTime;
			if (this.DurationTime <= 0f)
			{
				this.DurationTime = 0f;
			}
			base.GetComponent<Image>().material.SetFloat("_Distance", this.DurationTime);
		}
	}

	// Token: 0x04000CFB RID: 3323
	public float DurationTime = 0.15f;

	// Token: 0x04000CFC RID: 3324
	public float DelayTime = 0.1f;
}
