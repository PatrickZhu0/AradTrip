using System;

// Token: 0x0200434D RID: 17229
public class Mechanism2023 : BeMechanism
{
	// Token: 0x06017DA8 RID: 97704 RVA: 0x0075F766 File Offset: 0x0075DB66
	public Mechanism2023(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06017DA9 RID: 97705 RVA: 0x0075F770 File Offset: 0x0075DB70
	public override void OnInit()
	{
		base.OnInit();
		this.addEntityRate = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x040112A2 RID: 70306
	public int addEntityRate;
}
