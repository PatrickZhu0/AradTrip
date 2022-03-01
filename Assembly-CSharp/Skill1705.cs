using System;
using UnityEngine;

// Token: 0x02004467 RID: 17511
public class Skill1705 : BeSkill
{
	// Token: 0x06018556 RID: 99670 RVA: 0x007945CF File Offset: 0x007929CF
	public Skill1705(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018557 RID: 99671 RVA: 0x007945E4 File Offset: 0x007929E4
	public override void OnInit()
	{
		if (this.skillData != null)
		{
			this.buffID = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
			this.nextPhaseSkillID = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
		}
	}

	// Token: 0x06018558 RID: 99672 RVA: 0x00794642 File Offset: 0x00792A42
	public override void OnStart()
	{
		if (this.skillPhase == 0)
		{
			this.skillPhase = 1;
			this.DoPhase1();
		}
		else if (this.skillPhase == 1)
		{
		}
	}

	// Token: 0x06018559 RID: 99673 RVA: 0x0079466D File Offset: 0x00792A6D
	private void DoPhase1()
	{
		this.handler = base.owner.RegisterEvent(BeEventType.onRemoveBuff, delegate(object[] args)
		{
			int num = (int)args[0];
			if (num == this.buffID)
			{
				base.PressAgainRelease();
			}
		});
		this.handler2 = base.owner.RegisterEvent(BeEventType.onHitOther, delegate(object[] args)
		{
			BeActor beActor = args[0] as BeActor;
			if (beActor != null && beActor.buffController.HasBuffByType(BuffType.BLEEDING) != null)
			{
				this.tmpCount++;
				VInt3 position = beActor.GetPosition();
				VInt3 position2 = base.owner.GetPosition();
				Vector3 startVel;
				startVel..ctor(15f, 0f, 8f);
				if (this.tmpCount % 2 == 0)
				{
					startVel.z *= -1f;
					startVel.y = 10f;
				}
				else
				{
					startVel.y = -2f;
				}
				if (position.x < position2.x)
				{
					startVel.x *= -1f;
				}
				ParabolaBehaviour parabolaBehaviour = base.TrailManager.AddParabolaTrail(beActor.GetGePosition() + new Vector3(0f, 0.6f, 0f), base.owner, startVel, Vector3.zero, this.effect);
				parabolaBehaviour.totalDist = 20f;
				parabolaBehaviour.TotalTime = 2000f;
			}
		});
	}

	// Token: 0x0601855A RID: 99674 RVA: 0x007946AD File Offset: 0x00792AAD
	private void DoReleaseNextSkill()
	{
		if (this.nextPhaseSkillID > 0)
		{
			this.DoFinish();
			base.owner.delayCaller.DelayCall(100, delegate
			{
				base.owner.UseSkill(this.nextPhaseSkillID, true);
			}, 0, 0, false);
		}
	}

	// Token: 0x0601855B RID: 99675 RVA: 0x007946E4 File Offset: 0x00792AE4
	private void DoFinish()
	{
		this.RemoveHandler();
		this.skillPhase = 0;
		base.owner.buffController.RemoveBuff(this.buffID, 0, 0);
		for (int i = 0; i < this.skillData.ValueC.Count; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.skillData.ValueC[i], base.level, true);
			if (valueFromUnionCell > 0)
			{
				base.owner.buffController.RemoveBuff(valueFromUnionCell, 0, 0);
			}
		}
	}

	// Token: 0x0601855C RID: 99676 RVA: 0x0079476F File Offset: 0x00792B6F
	private void RemoveHandler()
	{
		if (this.handler != null)
		{
			this.handler.Remove();
			this.handler = null;
		}
		if (this.handler2 != null)
		{
			this.handler2.Remove();
			this.handler2 = null;
		}
	}

	// Token: 0x0601855D RID: 99677 RVA: 0x007947AB File Offset: 0x00792BAB
	public override void OnCancel()
	{
		this.DoFinish();
	}

	// Token: 0x0601855E RID: 99678 RVA: 0x007947B3 File Offset: 0x00792BB3
	public override void OnClickAgain()
	{
		this.DoReleaseNextSkill();
	}

	// Token: 0x040118F9 RID: 71929
	private int buffID;

	// Token: 0x040118FA RID: 71930
	private int nextPhaseSkillID;

	// Token: 0x040118FB RID: 71931
	private BeEventHandle handler;

	// Token: 0x040118FC RID: 71932
	private BeEventHandle handler2;

	// Token: 0x040118FD RID: 71933
	private int skillPhase;

	// Token: 0x040118FE RID: 71934
	private string effect = "Effects/Common/Sfx/DiaoLuo/Eff_jinbi_tuowei";

	// Token: 0x040118FF RID: 71935
	private int tmpCount;
}
