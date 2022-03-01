using System;
using System.Collections.Generic;

// Token: 0x02004435 RID: 17461
public class Skill1103 : BeSkill
{
	// Token: 0x060183E9 RID: 99305 RVA: 0x0078CA99 File Offset: 0x0078AE99
	public Skill1103(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060183EA RID: 99306 RVA: 0x0078CAB9 File Offset: 0x0078AEB9
	public override void OnStart()
	{
		this.deadMonsterList.Clear();
		this.RemoveHandler();
		this.handler = base.owner.RegisterEvent(BeEventType.onKill, delegate(object[] args)
		{
			BeActor deadMonster = args[0] as BeActor;
			if (deadMonster != null)
			{
				deadMonster.showDamageNumber = false;
				base.owner.delayCaller.DelayCall(100, delegate
				{
					deadMonster.Pause(1000000, true);
				}, 0, 0, false);
				this.deadMonsterList.Add(deadMonster);
			}
		});
	}

	// Token: 0x060183EB RID: 99307 RVA: 0x0078CAEC File Offset: 0x0078AEEC
	public override void OnEnterPhase(int phase)
	{
		if (phase == 12)
		{
			if (this.deadMonsterList.Count > 0)
			{
				base.owner.delayCaller.DelayCall(700, delegate
				{
					this.DoExplodeDeadMonster();
				}, 0, 0, false);
			}
			else
			{
				base.Cancel();
				base.owner.sgSwitchStates(new BeStateData(0, 0));
			}
		}
	}

	// Token: 0x060183EC RID: 99308 RVA: 0x0078CB54 File Offset: 0x0078AF54
	public override void OnFinish()
	{
		this.Restore();
	}

	// Token: 0x060183ED RID: 99309 RVA: 0x0078CB5C File Offset: 0x0078AF5C
	public override void OnCancel()
	{
		this.Restore();
		for (int i = 0; i < this.deadMonsterList.Count; i++)
		{
			this.deadMonsterList[i].Resume();
		}
	}

	// Token: 0x060183EE RID: 99310 RVA: 0x0078CB9C File Offset: 0x0078AF9C
	public void DoExplodeDeadMonster()
	{
		for (int i = 0; i < this.deadMonsterList.Count; i++)
		{
			BeActor monster = this.deadMonsterList[i];
			VInt3 position = monster.GetPosition();
			base.owner.CurrentBeScene.currentGeScene.CreateEffect(this.deadEffect, 0f, position.vec3, 1f, 1f, false, false);
			base.owner.delayCaller.DelayCall(300, delegate
			{
				monster.Resume();
				monster.DoDead(false);
			}, 0, 0, false);
		}
	}

	// Token: 0x060183EF RID: 99311 RVA: 0x0078CC42 File Offset: 0x0078B042
	private void Restore()
	{
		this.RemoveHandler();
	}

	// Token: 0x060183F0 RID: 99312 RVA: 0x0078CC4A File Offset: 0x0078B04A
	private void RemoveHandler()
	{
		if (this.handler != null)
		{
			this.handler.Remove();
			this.handler = null;
		}
	}

	// Token: 0x040117F8 RID: 71672
	private BeEventHandle handler;

	// Token: 0x040117F9 RID: 71673
	private List<BeActor> deadMonsterList = new List<BeActor>();

	// Token: 0x040117FA RID: 71674
	private string deadEffect = "Effects/Hero_Manyou/Fengkuangtulu/Prefab/Eff_fktl_baozha";
}
