using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x02004396 RID: 17302
public class Mechanism2090 : BeMechanism
{
	// Token: 0x06017FCF RID: 98255 RVA: 0x0076EFB7 File Offset: 0x0076D3B7
	public Mechanism2090(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017FD0 RID: 98256 RVA: 0x0076EFE4 File Offset: 0x0076D3E4
	public override void OnInit()
	{
		this.m_IsAddTrigger = (TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true) > 0);
		this.m_IsRemoveTrigger = (TableManager.GetValueFromUnionCell(this.data.ValueA[1], this.level, true) > 0);
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

	// Token: 0x06017FD1 RID: 98257 RVA: 0x0076F0EC File Offset: 0x0076D4EC
	public override void OnStart()
	{
		if (base.owner == null)
		{
			return;
		}
		this.m_HandleNewList.Add(base.owner.RegisterEventNew(BeEventType.onAddChaser, new BeEvent.BeEventHandleNew.Function(this.OnAddChaser)));
		this.m_HandleNewList.Add(base.owner.RegisterEventNew(BeEventType.onRemoveChaser, new BeEvent.BeEventHandleNew.Function(this.OnRemoveChaser)));
	}

	// Token: 0x06017FD2 RID: 98258 RVA: 0x0076F153 File Offset: 0x0076D553
	private void OnAddChaser(BeEvent.BeEventParam param)
	{
		if (!this.m_IsAddTrigger)
		{
			return;
		}
		this.AddBuff();
	}

	// Token: 0x06017FD3 RID: 98259 RVA: 0x0076F167 File Offset: 0x0076D567
	private void OnRemoveChaser(BeEvent.BeEventParam param)
	{
		if (!this.m_IsRemoveTrigger)
		{
			return;
		}
		this.AddBuff();
	}

	// Token: 0x06017FD4 RID: 98260 RVA: 0x0076F17C File Offset: 0x0076D57C
	private void AddBuff()
	{
		if (this.m_TriggerCD > 0 && this.m_CD.IsCD())
		{
			return;
		}
		if (this.m_BuffInfoId != 0 && (int)base.FrameRandom.Range1000() <= this.m_BuffPercent && base.owner != null && base.owner.buffController != null && base.owner.buffController.TryAddBuffInfo(this.m_BuffInfoId, base.owner, this.level) != null && this.m_TriggerCD > 0)
		{
			this.m_CD.StartCD(this.m_TriggerCD);
		}
	}

	// Token: 0x06017FD5 RID: 98261 RVA: 0x0076F22B File Offset: 0x0076D62B
	public override void OnUpdate(int deltaTime)
	{
		if (this.m_TriggerCD > 0)
		{
			this.m_CD.UpdateCD(deltaTime);
		}
	}

	// Token: 0x06017FD6 RID: 98262 RVA: 0x0076F248 File Offset: 0x0076D648
	public override void OnFinish()
	{
		for (int i = 0; i < this.m_HandleNewList.Count; i++)
		{
			this.m_HandleNewList[i].Remove();
			this.m_HandleNewList[i] = null;
		}
		this.m_HandleNewList.Clear();
	}

	// Token: 0x0401146A RID: 70762
	private CoolDown m_CD = new CoolDown();

	// Token: 0x0401146B RID: 70763
	private bool m_IsAddTrigger;

	// Token: 0x0401146C RID: 70764
	private bool m_IsRemoveTrigger;

	// Token: 0x0401146D RID: 70765
	private int m_BuffInfoId;

	// Token: 0x0401146E RID: 70766
	private int m_TriggerCD;

	// Token: 0x0401146F RID: 70767
	private int m_BuffPercent = 1000;

	// Token: 0x04011470 RID: 70768
	protected List<BeEvent.BeEventHandleNew> m_HandleNewList = new List<BeEvent.BeEventHandleNew>();
}
