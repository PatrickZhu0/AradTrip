using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x02004263 RID: 16995
public class Mechanism1027 : BeMechanism
{
	// Token: 0x0601783E RID: 96318 RVA: 0x0073C08A File Offset: 0x0073A48A
	public Mechanism1027(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601783F RID: 96319 RVA: 0x0073C0A0 File Offset: 0x0073A4A0
	public override void OnInit()
	{
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.monsterIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
		this.skillId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.existMonsterCount = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x06017840 RID: 96320 RVA: 0x0073C14B File Offset: 0x0073A54B
	public override void OnStart()
	{
		this.canUseSkillFlag = true;
		this.RegisterMonsterSummon();
	}

	// Token: 0x06017841 RID: 96321 RVA: 0x0073C15A File Offset: 0x0073A55A
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		this.UpdateMonsterState();
	}

	// Token: 0x06017842 RID: 96322 RVA: 0x0073C169 File Offset: 0x0073A569
	private void RegisterMonsterSummon()
	{
		if (base.owner.CurrentBeScene == null)
		{
			return;
		}
		this.handleA = base.owner.CurrentBeScene.RegisterEvent(BeEventSceneType.onSummon, delegate(object[] args)
		{
			BeActor beActor = (BeActor)args[0];
			if (beActor != null && this.ContainMonsterId(beActor))
			{
				this.canUseSkillFlag = true;
			}
		});
	}

	// Token: 0x06017843 RID: 96323 RVA: 0x0073C1A0 File Offset: 0x0073A5A0
	private void UpdateMonsterState()
	{
		if (!this.canUseSkillFlag)
		{
			return;
		}
		if (base.owner.CurrentBeScene == null)
		{
			return;
		}
		if (this.GetMonstersCount() <= this.existMonsterCount)
		{
			base.owner.UseSkill(this.skillId, true);
			this.canUseSkillFlag = false;
		}
	}

	// Token: 0x06017844 RID: 96324 RVA: 0x0073C1F8 File Offset: 0x0073A5F8
	private bool ContainMonsterId(BeActor monster)
	{
		bool result = false;
		for (int i = 0; i < this.monsterIdList.Count; i++)
		{
			if (monster.GetEntityData().MonsterIDEqual(this.monsterIdList[i]))
			{
				result = true;
				break;
			}
		}
		return result;
	}

	// Token: 0x06017845 RID: 96325 RVA: 0x0073C248 File Offset: 0x0073A648
	private int GetMonstersCount()
	{
		int num = 0;
		List<BeActor> list = ListPool<BeActor>.Get();
		for (int i = 0; i < this.monsterIdList.Count; i++)
		{
			base.owner.CurrentBeScene.FindActorById2(list, this.monsterIdList[i], false);
			num += list.Count;
		}
		ListPool<BeActor>.Release(list);
		return num;
	}

	// Token: 0x04010E5F RID: 69215
	private List<int> monsterIdList = new List<int>();

	// Token: 0x04010E60 RID: 69216
	private int skillId;

	// Token: 0x04010E61 RID: 69217
	private int existMonsterCount;

	// Token: 0x04010E62 RID: 69218
	private bool canUseSkillFlag;
}
