using System;

// Token: 0x020043EC RID: 17388
public class Mechanism45 : BeMechanism
{
	// Token: 0x06018227 RID: 98855 RVA: 0x00781497 File Offset: 0x0077F897
	public Mechanism45(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018228 RID: 98856 RVA: 0x007814A8 File Offset: 0x0077F8A8
	public override void OnInit()
	{
		this.m_BuffId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.m_TimeAcc = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.m_HurtId = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		if (this.data.ValueD.Count > 0)
		{
			this.m_HurtNumMax = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		}
	}

	// Token: 0x06018229 RID: 98857 RVA: 0x0078156C File Offset: 0x0077F96C
	public override void OnUpdate(int deltaTime)
	{
		if (this.m_HurtNumMax == -1 || this.m_CurrHurtNum < this.m_HurtNumMax)
		{
			if (this.m_CurrTimeAcc > this.m_TimeAcc)
			{
				this.m_CurrTimeAcc = 0;
				this.DoAttack();
			}
			else
			{
				this.m_CurrTimeAcc += deltaTime;
			}
		}
	}

	// Token: 0x0601822A RID: 98858 RVA: 0x007815C8 File Offset: 0x0077F9C8
	protected void DoAttack()
	{
		BeBuff beBuff = base.owner.buffController.HasBuffByID(this.m_BuffId);
		BeActor beActor = null;
		if (beBuff != null)
		{
			beActor = beBuff.releaser;
		}
		if (beActor != null)
		{
			beActor.DoAttackTo(base.owner, this.m_HurtId, true, false);
			this.m_CurrHurtNum++;
		}
	}

	// Token: 0x04011683 RID: 71299
	protected int m_BuffId;

	// Token: 0x04011684 RID: 71300
	protected int m_TimeAcc;

	// Token: 0x04011685 RID: 71301
	protected int m_HurtId;

	// Token: 0x04011686 RID: 71302
	protected int m_HurtNumMax = -1;

	// Token: 0x04011687 RID: 71303
	protected int m_CurrTimeAcc;

	// Token: 0x04011688 RID: 71304
	protected int m_CurrHurtNum;
}
