using System;
using System.Collections.Generic;

// Token: 0x020042AC RID: 17068
public class Mechanism1115 : BeMechanism
{
	// Token: 0x060179CE RID: 96718 RVA: 0x00746316 File Offset: 0x00744716
	public Mechanism1115(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060179CF RID: 96719 RVA: 0x00746344 File Offset: 0x00744744
	public override void OnInit()
	{
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.m_TargetHurtSet.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
		this.m_BuffInfoId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		if (this.data.ValueC.Count > 0)
		{
			this.m_BuffPercent = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		}
		if (this.data.ValueD.Count > 0)
		{
			this.m_TriggerCD = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		}
	}

	// Token: 0x060179D0 RID: 96720 RVA: 0x00746444 File Offset: 0x00744844
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onBeforeHit, new BeEventHandle.Del(this.OnHit));
	}

	// Token: 0x060179D1 RID: 96721 RVA: 0x00746468 File Offset: 0x00744868
	private void OnHit(object[] args)
	{
		if (this.m_TriggerCD > 0 && this.m_CD.IsCD())
		{
			return;
		}
		BeActor beActor = args[0] as BeActor;
		int item = (int)args[2];
		if (beActor != null && this.m_TargetHurtSet.Contains(item) && this.m_BuffInfoId != 0 && (int)base.FrameRandom.Range1000() <= this.m_BuffPercent && beActor.buffController.TryAddBuffInfo(this.m_BuffInfoId, base.owner, this.level) != null && this.m_TriggerCD > 0)
		{
			this.m_CD.StartCD(this.m_TriggerCD);
		}
	}

	// Token: 0x060179D2 RID: 96722 RVA: 0x00746520 File Offset: 0x00744920
	public override void OnUpdate(int deltaTime)
	{
		if (this.m_TriggerCD > 0)
		{
			this.m_CD.UpdateCD(deltaTime);
		}
	}

	// Token: 0x04010F8A RID: 69514
	private CoolDown m_CD = new CoolDown();

	// Token: 0x04010F8B RID: 69515
	private HashSet<int> m_TargetHurtSet = new HashSet<int>();

	// Token: 0x04010F8C RID: 69516
	private int m_BuffInfoId;

	// Token: 0x04010F8D RID: 69517
	private int m_BuffPercent = 1000;

	// Token: 0x04010F8E RID: 69518
	private int m_TriggerCD;
}
