using System;

// Token: 0x0200437A RID: 17274
public class Mechanism2067 : BeMechanism
{
	// Token: 0x06017F1C RID: 98076 RVA: 0x0076A206 File Offset: 0x00768606
	public Mechanism2067(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017F1D RID: 98077 RVA: 0x0076A210 File Offset: 0x00768610
	public override void OnInit()
	{
		this.phase = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x06017F1E RID: 98078 RVA: 0x0076A23A File Offset: 0x0076863A
	public override void OnStart()
	{
		InputManager.CreateBossPhaseChange(this.phase);
	}

	// Token: 0x040113D7 RID: 70615
	private int phase;
}
