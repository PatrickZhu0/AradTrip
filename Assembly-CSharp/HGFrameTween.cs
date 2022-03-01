using System;
using UnityEngine;

// Token: 0x02000FAA RID: 4010
[ExecuteInEditMode]
public class HGFrameTween : MonoBehaviour
{
	// Token: 0x06009A9C RID: 39580 RVA: 0x001DE4C6 File Offset: 0x001DC8C6
	private void Awake()
	{
		this.canvasRenders = base.gameObject.GetComponentsInChildren<CanvasRenderer>();
	}

	// Token: 0x06009A9D RID: 39581 RVA: 0x001DE4D9 File Offset: 0x001DC8D9
	private void Start()
	{
		this.startTime = Time.realtimeSinceStartup;
	}

	// Token: 0x06009A9E RID: 39582 RVA: 0x001DE4E8 File Offset: 0x001DC8E8
	private void Update()
	{
		float num = Time.realtimeSinceStartup - this.startTime;
		bool flag = true;
		if (flag && num > this.timeLength)
		{
			Object.Destroy(base.gameObject);
		}
		num = Mathf.Repeat(num, this.timeLength) / this.timeLength;
		float alpha = this.alphaCurve.Evaluate(num);
		for (int i = 0; i < this.canvasRenders.Length; i++)
		{
			this.canvasRenders[i].SetAlpha(alpha);
		}
	}

	// Token: 0x04005032 RID: 20530
	public AnimationCurve alphaCurve;

	// Token: 0x04005033 RID: 20531
	public float timeLength = 1f;

	// Token: 0x04005034 RID: 20532
	private float startTime;

	// Token: 0x04005035 RID: 20533
	private CanvasRenderer[] canvasRenders;
}
