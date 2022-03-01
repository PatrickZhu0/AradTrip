using System;

// Token: 0x02004411 RID: 17425
public class Mechanism79 : BeMechanism
{
	// Token: 0x06018327 RID: 99111 RVA: 0x007883D2 File Offset: 0x007867D2
	public Mechanism79(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018328 RID: 99112 RVA: 0x007883DC File Offset: 0x007867DC
	public override void OnInit()
	{
		this.height = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x06018329 RID: 99113 RVA: 0x00788406 File Offset: 0x00786806
	public override void OnStart()
	{
		base.owner.SetFloating(VInt.NewVInt(this.height, GlobalLogic.VALUE_1000), false);
		if (this.height <= 0)
		{
			base.owner.RemoveFloating();
		}
	}

	// Token: 0x04011771 RID: 71537
	private int height;
}
