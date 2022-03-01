using System;
using System.Collections.Generic;
using ProtoTable;

// Token: 0x020044F2 RID: 17650
public class Skill5679 : BeSkill
{
	// Token: 0x060188F5 RID: 100597 RVA: 0x007ABA04 File Offset: 0x007A9E04
	public Skill5679(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060188F6 RID: 100598 RVA: 0x007ABA36 File Offset: 0x007A9E36
	public override void OnPostInit()
	{
		base.OnPostInit();
	}

	// Token: 0x060188F7 RID: 100599 RVA: 0x007ABA40 File Offset: 0x007A9E40
	public override void OnStart()
	{
		base.OnStart();
		base.owner.CurrentBeScene.FindMonsterByID(this.monsterList, this.monsterID, true);
		for (int i = 0; i < this.monsterList.Count; i++)
		{
			if (this.monsterList[i].GetPID() != base.owner.GetPID())
			{
				this.partnerMonster = this.monsterList[i];
			}
		}
		VInt3 sceneCenterPosition = base.owner.CurrentBeScene.GetSceneCenterPosition();
		base.owner.SetFace(base.owner.GetPosition().x > sceneCenterPosition.x, true, false);
		if (this.partnerMonster != null)
		{
			this.skill = (this.partnerMonster.GetSkill(5680) as Skill5680);
			if (this.skill != null)
			{
				this.skill.partnerMonster = base.owner;
			}
		}
	}

	// Token: 0x060188F8 RID: 100600 RVA: 0x007ABB41 File Offset: 0x007A9F41
	public override bool CanUseSkill()
	{
		base.owner.CurrentBeScene.FindMonsterByID(this.monsterList, this.monsterID, true);
		return base.CanUseSkill() && this.monsterList.Count > 1;
	}

	// Token: 0x060188F9 RID: 100601 RVA: 0x007ABB80 File Offset: 0x007A9F80
	public override void OnEnterPhase(int phase)
	{
		base.OnEnterPhase(phase);
		if (phase == 1)
		{
			this.partnerMonster.UseSkill(5680, true);
		}
		if (phase == 2 && this.partnerMonster != null)
		{
			this.partnerMonster.SetFace(!base.owner.GetFace(), true, false);
			VInt vint = IntMath.Float2IntWithFixed((float)this.distance, 10000L, 100L, MidpointRounding.ToEven);
			VInt3 vint2 = base.owner.GetPosition() + new VInt3((!base.owner.GetFace()) ? vint.i : (-vint.i), 0, 0);
			if (base.owner.CurrentBeScene.IsInBlockPlayer(vint2))
			{
				vint2 = BeAIManager.FindStandPositionNew(vint2, base.owner.CurrentBeScene, false, false, 12);
			}
			this.partnerMonster.SetPosition(vint2, true, true, false);
			base.owner.RegisterEvent(BeEventType.onSummon, delegate(object[] args)
			{
				this.protectMonster = (args[0] as BeActor);
				if (this.protectMonster != null)
				{
					if (this.skill != null)
					{
						this.skill.protectMonster = this.protectMonster;
					}
					this.protectMonster.SetPosition((base.owner.GetPosition() + this.partnerMonster.GetPosition()) * 0.5f, false, true, false);
					this.protectMonster.RegisterEvent(BeEventType.onDead, delegate(object[] o)
					{
						base.owner.Locomote(new BeStateData(0, 0), true);
						if (this.partnerMonster != null)
						{
							this.partnerMonster.Locomote(new BeStateData(0, 0), true);
						}
					});
				}
			});
			base.owner.DoSummon(this.protectID, 1, EffectTable.eSummonPosType.FACE, null, 1, 0, 0, 0, 0, false, 0, 0, null, SummonDisplayType.NONE, null, true);
		}
	}

	// Token: 0x060188FA RID: 100602 RVA: 0x007ABCA8 File Offset: 0x007AA0A8
	public override void OnCancel()
	{
		base.OnCancel();
		this.StopSkill();
	}

	// Token: 0x060188FB RID: 100603 RVA: 0x007ABCB6 File Offset: 0x007AA0B6
	public override void OnFinish()
	{
		this.StopSkill();
		base.OnFinish();
	}

	// Token: 0x060188FC RID: 100604 RVA: 0x007ABCC4 File Offset: 0x007AA0C4
	private void StopSkill()
	{
		if (this.partnerMonster != null)
		{
			this.partnerMonster.Locomote(new BeStateData(0, 0), true);
		}
		if (this.protectMonster != null)
		{
			this.protectMonster.DoDead(false);
		}
		this.protectMonster = null;
		this.partnerMonster = null;
	}

	// Token: 0x04011B86 RID: 72582
	private int monsterID = 30080011;

	// Token: 0x04011B87 RID: 72583
	private int distance = 4;

	// Token: 0x04011B88 RID: 72584
	private int protectID = 30230011;

	// Token: 0x04011B89 RID: 72585
	private List<BeActor> monsterList = new List<BeActor>();

	// Token: 0x04011B8A RID: 72586
	private BeActor partnerMonster;

	// Token: 0x04011B8B RID: 72587
	private BeActor protectMonster;

	// Token: 0x04011B8C RID: 72588
	private Skill5680 skill;
}
