using System;
using System.Collections.Generic;

// Token: 0x020044CF RID: 17615
public class Skill3703 : BeSkill
{
	// Token: 0x06018841 RID: 100417 RVA: 0x007A6C6B File Offset: 0x007A506B
	public Skill3703(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018842 RID: 100418 RVA: 0x007A6C8C File Offset: 0x007A508C
	public override void OnInit()
	{
		base.OnInit();
		this.buffInfoListPve.Clear();
		this.buffInfoListPvp.Clear();
		for (int i = 0; i < this.skillData.ValueA.Count; i++)
		{
			this.buffInfoListPve.Add(TableManager.GetValueFromUnionCell(this.skillData.ValueA[i], base.level, true));
		}
		for (int j = 0; j < this.skillData.ValueB.Count; j++)
		{
			this.buffInfoListPvp.Add(TableManager.GetValueFromUnionCell(this.skillData.ValueB[j], base.level, true));
		}
		this.addBuffTag = "370301";
	}

	// Token: 0x06018843 RID: 100419 RVA: 0x007A6D52 File Offset: 0x007A5152
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onSkillCurFrame, delegate(object[] args)
		{
			string a = (string)args[0];
			if (a == this.addBuffTag)
			{
				this.AddBuffInfo();
			}
		});
	}

	// Token: 0x06018844 RID: 100420 RVA: 0x007A6D74 File Offset: 0x007A5174
	private void AddBuffInfo()
	{
		BeActor actor = base.owner;
		if (this.joystickSelectActor != null && !this.joystickSelectActor.IsDead())
		{
			actor = this.joystickSelectActor;
		}
		this.RealAddBuffInfo(actor);
	}

	// Token: 0x06018845 RID: 100421 RVA: 0x007A6DB4 File Offset: 0x007A51B4
	private void RealAddBuffInfo(BeActor actor)
	{
		if (actor == null || actor.IsDead())
		{
			return;
		}
		List<int> list = (!BattleMain.IsModePvP(base.battleType)) ? this.buffInfoListPve : this.buffInfoListPvp;
		for (int i = 0; i < list.Count; i++)
		{
			BuffInfoData info = new BuffInfoData(list[i], base.level, 0);
			actor.buffController.TryAddBuff(info, null, false, default(VRate), base.owner);
		}
	}

	// Token: 0x04011AF1 RID: 72433
	private List<int> buffInfoListPve = new List<int>();

	// Token: 0x04011AF2 RID: 72434
	private List<int> buffInfoListPvp = new List<int>();

	// Token: 0x04011AF3 RID: 72435
	protected string addBuffTag;
}
