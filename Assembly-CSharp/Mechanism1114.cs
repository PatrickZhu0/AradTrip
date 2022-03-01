using System;
using GameClient;

// Token: 0x020042AA RID: 17066
public class Mechanism1114 : BeMechanism
{
	// Token: 0x060179C5 RID: 96709 RVA: 0x007461C7 File Offset: 0x007445C7
	public Mechanism1114(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060179C6 RID: 96710 RVA: 0x007461DC File Offset: 0x007445DC
	public override void OnInit()
	{
		this.hurtId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.rate = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x060179C7 RID: 96711 RVA: 0x0074623E File Offset: 0x0074463E
	public override void OnStart()
	{
		this.mHandleNew = base.owner.RegisterEventNew(BeEventType.onReplaceHurtTableCiriticalData, new BeEvent.BeEventHandleNew.Function(this.OnChangeCiritical));
	}

	// Token: 0x060179C8 RID: 96712 RVA: 0x00746260 File Offset: 0x00744660
	protected void OnChangeCiritical(BeEvent.BeEventParam param)
	{
		int @int = param.m_Int;
		if (@int == this.hurtId)
		{
			param.m_Rate += this.rate;
		}
	}

	// Token: 0x060179C9 RID: 96713 RVA: 0x00746297 File Offset: 0x00744697
	public override void OnFinish()
	{
		base.OnFinish();
		if (this.mHandleNew != null)
		{
			this.mHandleNew.Remove();
			this.mHandleNew = null;
		}
	}

	// Token: 0x04010F84 RID: 69508
	private VRate rate = VRate.zero;

	// Token: 0x04010F85 RID: 69509
	private int hurtId;

	// Token: 0x04010F86 RID: 69510
	protected BeEvent.BeEventHandleNew mHandleNew;
}
