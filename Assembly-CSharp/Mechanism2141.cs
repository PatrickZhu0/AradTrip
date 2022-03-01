using System;
using System.Collections.Generic;

// Token: 0x020043CB RID: 17355
public class Mechanism2141 : BeMechanism
{
	// Token: 0x06018136 RID: 98614 RVA: 0x0077A37A File Offset: 0x0077877A
	public Mechanism2141(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018137 RID: 98615 RVA: 0x0077A390 File Offset: 0x00778790
	public override void OnInit()
	{
		for (int i = 0; i < this.data.ValueA.Length; i++)
		{
			this.m_BuffInfoId.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
		this.m_HasHurt = false;
	}

	// Token: 0x06018138 RID: 98616 RVA: 0x0077A3F2 File Offset: 0x007787F2
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onHurt, new BeEventHandle.Del(this.OnHurt));
	}

	// Token: 0x06018139 RID: 98617 RVA: 0x0077A419 File Offset: 0x00778819
	private void OnHurt(object[] args)
	{
		this.m_HasHurt = true;
	}

	// Token: 0x0601813A RID: 98618 RVA: 0x0077A424 File Offset: 0x00778824
	public override void OnFinish()
	{
		if (!this.m_HasHurt)
		{
			for (int i = 0; i < this.m_BuffInfoId.Count; i++)
			{
				base.owner.buffController.TryAddBuffInfo(this.m_BuffInfoId[i], base.owner, this.level);
			}
		}
	}

	// Token: 0x04011591 RID: 71057
	private List<int> m_BuffInfoId = new List<int>();

	// Token: 0x04011592 RID: 71058
	private bool m_HasHurt;
}
