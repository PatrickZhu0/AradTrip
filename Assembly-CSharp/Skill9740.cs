using System;

// Token: 0x02004499 RID: 17561
public class Skill9740 : BeSkill
{
	// Token: 0x060186B0 RID: 100016 RVA: 0x0079D5C1 File Offset: 0x0079B9C1
	public Skill9740(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060186B1 RID: 100017 RVA: 0x0079D5CB File Offset: 0x0079B9CB
	public override void OnStart()
	{
		this.RemoveHandle();
		this.m_Monster = null;
		this.m_SummonHandle = base.owner.RegisterEvent(BeEventType.onSummon, delegate(object[] args)
		{
			BeActor monster = (BeActor)args[0];
			this.m_Monster = monster;
		});
	}

	// Token: 0x060186B2 RID: 100018 RVA: 0x0079D5F9 File Offset: 0x0079B9F9
	public override void OnCancel()
	{
		this.SetMonsterDead();
		this.RemoveHandle();
	}

	// Token: 0x060186B3 RID: 100019 RVA: 0x0079D607 File Offset: 0x0079BA07
	public override void OnFinish()
	{
		this.SetMonsterDead();
		this.RemoveHandle();
	}

	// Token: 0x060186B4 RID: 100020 RVA: 0x0079D618 File Offset: 0x0079BA18
	private void SetMonsterDead()
	{
		if (this.m_Monster != null && !this.m_Monster.IsDead() && this.m_Monster.GetOwner() == base.owner)
		{
			this.m_Monster.DoDead(false);
			this.m_Monster = null;
		}
	}

	// Token: 0x060186B5 RID: 100021 RVA: 0x0079D669 File Offset: 0x0079BA69
	protected void RemoveHandle()
	{
		if (this.m_SummonHandle != null)
		{
			this.m_SummonHandle.Remove();
			this.m_SummonHandle = null;
		}
	}

	// Token: 0x040119EE RID: 72174
	protected BeEventHandle m_SummonHandle;

	// Token: 0x040119EF RID: 72175
	protected BeActor m_Monster;
}
