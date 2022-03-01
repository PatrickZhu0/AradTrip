using System;

// Token: 0x02004384 RID: 17284
public class Mechanism2076 : BeMechanism
{
	// Token: 0x06017F73 RID: 98163 RVA: 0x0076CAB2 File Offset: 0x0076AEB2
	public Mechanism2076(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017F74 RID: 98164 RVA: 0x0076CAC8 File Offset: 0x0076AEC8
	public override void OnInit()
	{
		base.OnInit();
		if (this.data.ValueA.Count >= 2)
		{
			this.mComboTimeArray[0] = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
			this.mComboTimeArray[1] = TableManager.GetValueFromUnionCell(this.data.ValueA[1], this.level, true);
		}
	}

	// Token: 0x06017F75 RID: 98165 RVA: 0x0076CB48 File Offset: 0x0076AF48
	public override void OnStart()
	{
		base.OnStart();
		this.InitData();
		if (this.mComboTime <= 0)
		{
			return;
		}
		if (base.owner != null && base.owner.actorData != null)
		{
			base.owner.actorData.SetComboIntervel(this.mComboTime);
		}
	}

	// Token: 0x06017F76 RID: 98166 RVA: 0x0076CB9F File Offset: 0x0076AF9F
	private void InitData()
	{
		this.mComboTime = (BattleMain.IsModePvP(base.battleType) ? this.mComboTimeArray[1] : this.mComboTimeArray[0]);
	}

	// Token: 0x06017F77 RID: 98167 RVA: 0x0076CBCC File Offset: 0x0076AFCC
	public override void OnFinish()
	{
		base.OnFinish();
		if (base.owner != null && base.owner.actorData != null)
		{
			base.owner.actorData.ResetComboIntervel();
		}
	}

	// Token: 0x0401141E RID: 70686
	private int[] mComboTimeArray = new int[2];

	// Token: 0x0401141F RID: 70687
	private int mComboTime;
}
