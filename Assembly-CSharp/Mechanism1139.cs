using System;
using System.Collections.Generic;

// Token: 0x020042BD RID: 17085
public class Mechanism1139 : BeMechanism
{
	// Token: 0x06017A3E RID: 96830 RVA: 0x0074893D File Offset: 0x00746D3D
	public Mechanism1139(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017A3F RID: 96831 RVA: 0x00748960 File Offset: 0x00746D60
	public override void OnInit()
	{
		this.m_hpPercent = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true), GlobalLogic.VALUE_1000);
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			this.m_buffInfoID.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
		}
	}

	// Token: 0x06017A40 RID: 96832 RVA: 0x007489ED File Offset: 0x00746DED
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onHitAfterAddBuff, new BeEventHandle.Del(this.onHit));
	}

	// Token: 0x06017A41 RID: 96833 RVA: 0x00748A10 File Offset: 0x00746E10
	private void onHit(object[] args)
	{
		if (!(bool)args[5])
		{
			return;
		}
		if (base.owner.GetEntityData() == null || base.owner.GetEntityData().GetMaxHP() == 0)
		{
			return;
		}
		int num = (int)args[4];
		this.m_totalDamage += num;
		VFactor a = VFactor.NewVFactor(this.m_totalDamage, base.owner.GetEntityData().GetMaxHP());
		if (a >= this.m_hpPercent)
		{
			for (int i = 0; i < this.m_buffInfoID.Count; i++)
			{
				base.owner.buffController.TryAddBuff(this.m_buffInfoID[i], null, false, null, 0);
			}
			base.Finish();
		}
	}

	// Token: 0x04010FC8 RID: 69576
	private VFactor m_hpPercent = VFactor.zero;

	// Token: 0x04010FC9 RID: 69577
	private List<int> m_buffInfoID = new List<int>();

	// Token: 0x04010FCA RID: 69578
	private int m_totalDamage;
}
