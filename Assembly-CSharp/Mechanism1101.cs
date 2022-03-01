using System;
using System.Collections.Generic;

// Token: 0x020042A7 RID: 17063
public class Mechanism1101 : BeMechanism
{
	// Token: 0x060179B4 RID: 96692 RVA: 0x00745C0F File Offset: 0x0074400F
	public Mechanism1101(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060179B5 RID: 96693 RVA: 0x00745C24 File Offset: 0x00744024
	public override void OnInit()
	{
		this.mSummonMechanismList.Clear();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.mSummonMechanismList.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
	}

	// Token: 0x060179B6 RID: 96694 RVA: 0x00745C8A File Offset: 0x0074408A
	public override void OnStart()
	{
		this.TryAddOnceMechanism();
	}

	// Token: 0x060179B7 RID: 96695 RVA: 0x00745C94 File Offset: 0x00744094
	public void TryAddOnceMechanism()
	{
		if (base.owner != null && this.mAddMechanismIndex < this.mSummonMechanismList.Count)
		{
			base.owner.AddMechanism(this.mSummonMechanismList[this.mAddMechanismIndex], this.level, MechanismSourceType.NONE, null, 0);
			this.AddIndex();
		}
	}

	// Token: 0x060179B8 RID: 96696 RVA: 0x00745CF3 File Offset: 0x007440F3
	private void AddIndex()
	{
		this.mAddMechanismIndex++;
		if (this.mAddMechanismIndex >= this.mSummonMechanismList.Count)
		{
			base.owner.RemoveMechanism(this);
		}
	}

	// Token: 0x04010F79 RID: 69497
	private List<int> mSummonMechanismList = new List<int>();

	// Token: 0x04010F7A RID: 69498
	private int mAddMechanismIndex;
}
