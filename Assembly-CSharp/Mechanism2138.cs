using System;
using GameClient;

// Token: 0x020043C8 RID: 17352
public class Mechanism2138 : BeMechanism
{
	// Token: 0x06018120 RID: 98592 RVA: 0x00779C65 File Offset: 0x00778065
	public Mechanism2138(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018121 RID: 98593 RVA: 0x00779C6F File Offset: 0x0077806F
	public override void OnStart()
	{
		if (base.owner == null)
		{
			return;
		}
		this.handleNewA = base.owner.RegisterEventNew(BeEventType.onAddChaser, new BeEvent.BeEventHandleNew.Function(this.ChangeCreateChaseSize));
	}

	// Token: 0x06018122 RID: 98594 RVA: 0x00779CA0 File Offset: 0x007780A0
	private void ChangeCreateChaseSize(BeEvent.BeEventParam param)
	{
		Mechanism2072.ChaseSizeType @int = (Mechanism2072.ChaseSizeType)param.m_Int2;
		if (@int != Mechanism2072.ChaseSizeType.Big)
		{
			param.m_Int2 = 1;
		}
	}
}
