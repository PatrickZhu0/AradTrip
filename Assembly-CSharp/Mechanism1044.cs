using System;
using System.Collections.Generic;
using ProtoTable;

// Token: 0x02004277 RID: 17015
public class Mechanism1044 : BeMechanism
{
	// Token: 0x060178BB RID: 96443 RVA: 0x0073ECCF File Offset: 0x0073D0CF
	public Mechanism1044(int id, int level) : base(id, level)
	{
	}

	// Token: 0x060178BC RID: 96444 RVA: 0x0073ECF0 File Offset: 0x0073D0F0
	public override void OnInit()
	{
		this.effectID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.summonID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.bulletID = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x060178BD RID: 96445 RVA: 0x0073ED78 File Offset: 0x0073D178
	public override void OnStart()
	{
		this.ClearEventHandle();
		if (this.bulletPidList != null)
		{
			this.bulletPidList.Clear();
		}
		else
		{
			this.bulletPidList = new List<int>();
		}
		this.bulletEventHandle = base.owner.RegisterEvent(BeEventType.onAfterGenBullet, delegate(object[] args)
		{
			BeProjectile bullet = args[0] as BeProjectile;
			if (bullet == null || bullet.m_iResID != this.bulletID)
			{
				return;
			}
			this.hurtEventHandle.Add(bullet.RegisterEvent(BeEventType.onHitOther, delegate(object[] args1)
			{
				if (this.bulletPidList.Contains(bullet.GetPID()))
				{
					return;
				}
				if ((int)args1[1] == this.effectID)
				{
					BeActor target = args1[0] as BeActor;
					if (target != null)
					{
						this.summonEventHandle = this.owner.RegisterEvent(BeEventType.onSummon, delegate(object[] args2)
						{
							BeActor beActor = args2[0] as BeActor;
							if (!beActor.GetEntityData().MonsterIDEqual(<OnStart>c__AnonStorey.summonID))
							{
								return;
							}
							if (beActor != null)
							{
								beActor.SetPosition(target.GetPosition(), true, true, false);
							}
							if (<OnStart>c__AnonStorey.summonEventHandle != null)
							{
								<OnStart>c__AnonStorey.summonEventHandle.Remove();
								<OnStart>c__AnonStorey.summonEventHandle = null;
							}
						});
						this.owner.DoSummon(this.summonID, this.owner.GetEntityData().level, EffectTable.eSummonPosType.FACE, null, 1, 0, 0, 0, 0, false, 0, 0, null, SummonDisplayType.NONE, null, true);
						this.bulletPidList.Add(bullet.GetPID());
					}
				}
			}));
		});
	}

	// Token: 0x060178BE RID: 96446 RVA: 0x0073EDD0 File Offset: 0x0073D1D0
	public override void OnFinish()
	{
		if (this.bulletPidList != null)
		{
			this.bulletPidList.Clear();
		}
		this.ClearEventHandle();
	}

	// Token: 0x060178BF RID: 96447 RVA: 0x0073EDF0 File Offset: 0x0073D1F0
	private void ClearEventHandle()
	{
		if (this.bulletEventHandle != null)
		{
			this.bulletEventHandle.Remove();
			this.bulletEventHandle = null;
		}
		if (this.summonEventHandle != null)
		{
			this.summonEventHandle.Remove();
			this.summonEventHandle = null;
		}
		if (this.hurtEventHandle != null)
		{
			for (int i = 0; i < this.hurtEventHandle.Count; i++)
			{
				if (this.hurtEventHandle[i] != null)
				{
					this.hurtEventHandle[i].Remove();
					this.hurtEventHandle[i] = null;
				}
			}
		}
	}

	// Token: 0x04010EB1 RID: 69297
	private int effectID;

	// Token: 0x04010EB2 RID: 69298
	private BeEventHandle bulletEventHandle;

	// Token: 0x04010EB3 RID: 69299
	private BeEventHandle summonEventHandle;

	// Token: 0x04010EB4 RID: 69300
	private List<BeEventHandle> hurtEventHandle = new List<BeEventHandle>();

	// Token: 0x04010EB5 RID: 69301
	private int summonID;

	// Token: 0x04010EB6 RID: 69302
	private int bulletID;

	// Token: 0x04010EB7 RID: 69303
	private List<int> bulletPidList = new List<int>();
}
