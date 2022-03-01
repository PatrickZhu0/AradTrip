using System;
using ProtoTable;

// Token: 0x0200440B RID: 17419
public class Mechanism73 : BeMechanism
{
	// Token: 0x0601830B RID: 99083 RVA: 0x00787770 File Offset: 0x00785B70
	public Mechanism73(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x1700200D RID: 8205
	// (get) Token: 0x0601830C RID: 99084 RVA: 0x0078778C File Offset: 0x00785B8C
	// (set) Token: 0x0601830D RID: 99085 RVA: 0x00787794 File Offset: 0x00785B94
	public int Distance
	{
		get
		{
			return this.dis;
		}
		set
		{
			this.dis = value;
		}
	}

	// Token: 0x1700200E RID: 8206
	// (get) Token: 0x0601830E RID: 99086 RVA: 0x0078779D File Offset: 0x00785B9D
	// (set) Token: 0x0601830F RID: 99087 RVA: 0x007877A5 File Offset: 0x00785BA5
	public int Duration
	{
		get
		{
			return this.duration;
		}
		set
		{
			this.duration = value;
		}
	}

	// Token: 0x06018310 RID: 99088 RVA: 0x007877B0 File Offset: 0x00785BB0
	public override void OnInit()
	{
		if (this.data.ValueA.Count > 0)
		{
			this.skillID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		}
		if (this.data.ValueB.Count > 0)
		{
			this.possibility = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		}
		if (this.data.ValueC.Count > 0)
		{
			this.duration = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		}
		if (this.data.ValueD.Count > 0)
		{
			this.dis = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		}
		if (this.data.ValueE.Count > 0)
		{
			this.castSkillCD = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		}
	}

	// Token: 0x06018311 RID: 99089 RVA: 0x007878F3 File Offset: 0x00785CF3
	public override void OnStart()
	{
		this.RemoveHandle();
		this.beforeBeHit = base.owner.RegisterEvent(BeEventType.onBeforeOtherHit, delegate(object[] args)
		{
			if (!this.canCastBlockSkill)
			{
				return;
			}
			EffectTable effectTable = args[1] as EffectTable;
			if (effectTable != null && effectTable.IsFriendDamage == 1)
			{
				return;
			}
			if ((int)base.owner.FrameRandom.Range1000() < this.possibility && base.owner.CanUseSkill(this.skillID))
			{
				BeActor beActor = args[0] as BeActor;
				if (beActor != null)
				{
					base.owner.SetFace(!beActor.GetFace(), true, true);
				}
				base.owner.UseSkill(this.skillID, false);
				Skill1515 skill = base.owner.GetSkill(this.skillID) as Skill1515;
				if (skill != null)
				{
					skill.isAutoBlock = true;
				}
				this.canCastBlockSkill = false;
			}
		});
	}

	// Token: 0x06018312 RID: 99090 RVA: 0x0078791A File Offset: 0x00785D1A
	public override void OnUpdate(int deltaTime)
	{
		if (!this.canCastBlockSkill)
		{
			this.timer += deltaTime;
			if (this.timer >= this.castSkillCD)
			{
				this.canCastBlockSkill = true;
				this.timer = 0;
			}
		}
	}

	// Token: 0x06018313 RID: 99091 RVA: 0x00787954 File Offset: 0x00785D54
	public override void OnFinish()
	{
		this.RemoveHandle();
	}

	// Token: 0x06018314 RID: 99092 RVA: 0x0078795C File Offset: 0x00785D5C
	protected void RemoveHandle()
	{
		if (this.beforeBeHit != null)
		{
			this.beforeBeHit.Remove();
			this.beforeBeHit = null;
		}
	}

	// Token: 0x04011753 RID: 71507
	private BeEventHandle beforeBeHit;

	// Token: 0x04011754 RID: 71508
	private int possibility;

	// Token: 0x04011755 RID: 71509
	private int skillID;

	// Token: 0x04011756 RID: 71510
	private int castSkillCD;

	// Token: 0x04011757 RID: 71511
	private bool canCastBlockSkill = true;

	// Token: 0x04011758 RID: 71512
	private int dis;

	// Token: 0x04011759 RID: 71513
	private new int duration = 800;

	// Token: 0x0401175A RID: 71514
	private int timer;
}
