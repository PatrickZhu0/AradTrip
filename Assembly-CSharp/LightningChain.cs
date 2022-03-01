using System;
using UnityEngine;

// Token: 0x02000D80 RID: 3456
public class LightningChain : MonoBehaviour
{
	// Token: 0x06008C19 RID: 35865 RVA: 0x0019ED50 File Offset: 0x0019D150
	private void Start()
	{
		this.lineRend = base.gameObject.GetComponent<LineRenderer>();
		this.zapTimer = 0f;
		this.lineRend.SetVertexCount(1);
		this.zapTimer = this.timeOfZap;
		this.timeAcc = this.interval;
	}

	// Token: 0x06008C1A RID: 35866 RVA: 0x0019EDA0 File Offset: 0x0019D1A0
	private void Update()
	{
		this.timeAcc += Time.deltaTime;
		if (this.timeAcc >= this.interval)
		{
			this.timeAcc -= this.interval;
			if (this.zapTimer > 0f && this.target != null)
			{
				Vector3 position = base.transform.position;
				int num = 1;
				this.lineRend.SetPosition(0, base.transform.position);
				this.lineRend.SetVertexCount(num + 1);
				this.lineRend.SetPosition(num, this.target.transform.position);
				this.zapTimer -= this.interval;
			}
			else if (this.lineRend != null)
			{
				this.lineRend.SetVertexCount(1);
			}
			return;
		}
	}

	// Token: 0x06008C1B RID: 35867 RVA: 0x0019EE90 File Offset: 0x0019D290
	private Vector3 Randomize(Vector3 newVector, float devation)
	{
		newVector += new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * devation;
		newVector.Normalize();
		return newVector;
	}

	// Token: 0x06008C1C RID: 35868 RVA: 0x0019EEE5 File Offset: 0x0019D2E5
	public void ZapTarget(GameObject newTarget)
	{
		this.target = newTarget;
		this.zapTimer = this.timeOfZap;
	}

	// Token: 0x06008C1D RID: 35869 RVA: 0x0019EEFA File Offset: 0x0019D2FA
	public void SetVertexCount(int count)
	{
	}

	// Token: 0x06008C1E RID: 35870 RVA: 0x0019EEFC File Offset: 0x0019D2FC
	public void ForceUpdate()
	{
		this.timeAcc = this.interval;
		this.Update();
	}

	// Token: 0x04004553 RID: 17747
	public GameObject target;

	// Token: 0x04004554 RID: 17748
	private LineRenderer lineRend;

	// Token: 0x04004555 RID: 17749
	public float arcLength = 1f;

	// Token: 0x04004556 RID: 17750
	public float arcVariation = 1f;

	// Token: 0x04004557 RID: 17751
	public float inaccuracy = 0.5f;

	// Token: 0x04004558 RID: 17752
	public float timeOfZap = 250000000f;

	// Token: 0x04004559 RID: 17753
	private float zapTimer;

	// Token: 0x0400455A RID: 17754
	private float timeAcc;

	// Token: 0x0400455B RID: 17755
	public float interval = 1f;
}
