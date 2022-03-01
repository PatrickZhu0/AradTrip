using System;
using UnityEngine;

// Token: 0x02000E2A RID: 3626
public class DataBuryingPointTimer : MonoBehaviour
{
	// Token: 0x06009105 RID: 37125 RVA: 0x001AD666 File Offset: 0x001ABA66
	private void Start()
	{
		this.EndTime = 0f;
		this.bBeginCal = true;
	}

	// Token: 0x06009106 RID: 37126 RVA: 0x001AD67A File Offset: 0x001ABA7A
	private void Update()
	{
		if (this.bBeginCal)
		{
			this.EndTime += Time.deltaTime;
		}
	}

	// Token: 0x06009107 RID: 37127 RVA: 0x001AD699 File Offset: 0x001ABA99
	private void OnDestroy()
	{
		this.SendOpenFrameTime();
	}

	// Token: 0x06009108 RID: 37128 RVA: 0x001AD6A1 File Offset: 0x001ABAA1
	private void SendOpenFrameTime()
	{
		this.bBeginCal = false;
		Singleton<GameStatisticManager>.GetInstance().DoStartOpenFrameUseTime(this.mFrameName, (int)this.EndTime);
		this.EndTime = 0f;
	}

	// Token: 0x0400484D RID: 18509
	[SerializeField]
	private string mFrameName;

	// Token: 0x0400484E RID: 18510
	private bool bBeginCal;

	// Token: 0x0400484F RID: 18511
	private float EndTime;
}
