using System;
using System.Collections.Generic;
using GameClient;
using GamePool;

// Token: 0x020043F0 RID: 17392
public class Mechanism50 : BeMechanism
{
	// Token: 0x0601823C RID: 98876 RVA: 0x00781A69 File Offset: 0x0077FE69
	public Mechanism50(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601823D RID: 98877 RVA: 0x00781A94 File Offset: 0x0077FE94
	public override void OnInit()
	{
		int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		if (valueFromUnionCell > 0)
		{
			this.targetType = Mechanism50.TargetType.OWER;
		}
		if (this.data.ValueB.Count > 0)
		{
			this.minCD = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		}
		if (this.data.ValueC.Count > 0)
		{
			this.maxCD = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		}
		if (this.data.ValueD.Count > 0)
		{
			for (int i = 0; i < this.data.ValueD.Count; i++)
			{
				this.useSkillIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueD[i], this.level, true));
			}
		}
		if (this.data.ValueE.Count > 0)
		{
			for (int j = 0; j < this.data.ValueE.Count; j++)
			{
				this.skillIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueE[j], this.level, true));
			}
		}
		this._reduceCdpercent = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x0601823E RID: 98878 RVA: 0x00781C48 File Offset: 0x00780048
	public override void OnStart()
	{
		if (base.owner == null || base.owner.IsDead())
		{
			return;
		}
		BeActor beActor = base.owner;
		if (this.targetType == Mechanism50.TargetType.PET_OWER && base.owner.GetEntityData().isPet)
		{
			beActor = (base.owner.GetOwner() as BeActor);
		}
		if (beActor == null)
		{
			return;
		}
		this.CheckResetSkillCd(beActor);
		this.CheckReduceSkillCd(beActor);
	}

	// Token: 0x0601823F RID: 98879 RVA: 0x00781CC0 File Offset: 0x007800C0
	private void CheckResetSkillCd(BeActor actor)
	{
		if (this._reduceCdpercent != VFactor.zero)
		{
			return;
		}
		if (this.skillIdList.Count > 0)
		{
			if (this.skillIdList.Count > 0)
			{
				for (int i = 0; i < this.skillIdList.Count; i++)
				{
					this.ResetSkillCd(actor, this.skillIdList[i]);
				}
			}
		}
		else
		{
			List<int> list = ListPool<int>.Get();
			if (Mechanism50.GetCanCooldownSkills(actor, this.minCD, this.maxCD, list) && list.Count > 0)
			{
				int index = base.FrameRandom.InRange(0, list.Count);
				this.ResetSkillCd(actor, list[index]);
			}
			ListPool<int>.Release(list);
			base.owner.buffController.RemoveBuff(1200522, 0, 0);
		}
	}

	// Token: 0x06018240 RID: 98880 RVA: 0x00781DA4 File Offset: 0x007801A4
	private void CheckReduceSkillCd(BeActor actor)
	{
		if (this._reduceCdpercent == VFactor.zero)
		{
			return;
		}
		List<int> list = ListPool<int>.Get();
		Mechanism50.GetCanReduceCDSkills(actor, this.minCD, list);
		if (list.Count > 0)
		{
			BeSkill skill;
			if (list[0] == -1 && list.Count > 1)
			{
				int skillID = list[1];
				skill = actor.GetSkill(skillID);
				if (skill != null)
				{
					skill.ResetCoolDown();
				}
			}
			else
			{
				int index = base.FrameRandom.InRange(0, list.Count);
				skill = actor.GetSkill(list[index]);
				if (skill != null)
				{
					skill.AccTimeCD(skill.GetCurrentCD() * this._reduceCdpercent);
				}
			}
			if (skill != null && base.owner.m_pkGeActor != null)
			{
				base.owner.m_pkGeActor.CreateHeadText(HitTextType.SPECIAL_ATTACK, skill.skillData.Icon, false, "UIFlatten/Prefabs/Battle_Digit/PlayerInfo_ShowSkillIcon");
			}
		}
		ListPool<int>.Release(list);
	}

	// Token: 0x06018241 RID: 98881 RVA: 0x00781EA0 File Offset: 0x007802A0
	protected void ResetSkillCd(BeActor actor, int skillId)
	{
		BeSkill skill = actor.GetSkill(skillId);
		if (skill != null)
		{
			skill.ResetCoolDown();
			if (base.owner.m_pkGeActor != null)
			{
				base.owner.m_pkGeActor.CreateHeadText(HitTextType.SPECIAL_ATTACK, skill.skillData.Icon, false, "UIFlatten/Prefabs/Battle_Digit/PlayerInfo_ShowSkillIcon");
			}
		}
	}

	// Token: 0x06018242 RID: 98882 RVA: 0x00781EF4 File Offset: 0x007802F4
	public static bool GetCanCooldownSkills(BeActor actor, int minCD, int maxCD, List<int> skillIDs = null)
	{
		bool result = false;
		if (actor == null)
		{
			return result;
		}
		if (skillIDs != null)
		{
			skillIDs.Clear();
		}
		Dictionary<int, CrypticInt32> skillLevelInfo = actor.GetEntityData().skillLevelInfo;
		int num = 0;
		if (actor.sgGetCurrentState() == 14)
		{
			num = actor.GetCurSkillID();
		}
		foreach (KeyValuePair<int, CrypticInt32> keyValuePair in skillLevelInfo)
		{
			int key = keyValuePair.Key;
			BeSkill skill = actor.GetSkill(key);
			if (skill != null && skill.skillCategory == 3 && !skill.isBuffSkill && skill.GetCurrentCD() >= minCD && skill.CDLeftTime >= minCD && key != num && skill.GetCurrentCD() - skill.CDLeftTime >= maxCD)
			{
				if (skillIDs != null)
				{
					skillIDs.Add(key);
				}
				result = true;
			}
		}
		return result;
	}

	// Token: 0x06018243 RID: 98883 RVA: 0x00781FD8 File Offset: 0x007803D8
	public static bool GetCanReduceCDSkills(BeActor actor, int minCD, List<int> skillIDs = null)
	{
		bool result = false;
		if (actor == null)
		{
			return result;
		}
		if (skillIDs != null)
		{
			skillIDs.Clear();
		}
		Dictionary<int, CrypticInt32> skillLevelInfo = actor.GetEntityData().skillLevelInfo;
		int num = 0;
		if (actor.sgGetCurrentState() == 14)
		{
			num = actor.GetCurSkillID();
		}
		int num2 = 0;
		int num3 = 0;
		foreach (KeyValuePair<int, CrypticInt32> keyValuePair in skillLevelInfo)
		{
			int key = keyValuePair.Key;
			BeSkill skill = actor.GetSkill(key);
			if (skill != null && (skill.skillCategory == 3 || skill.skillCategory == 4) && key != num && skill.CDLeftTime > 0 && !skill.isBuffSkill)
			{
				if (skill.CDLeftTime > minCD)
				{
					if (skillIDs != null)
					{
						skillIDs.Add(key);
					}
					result = true;
				}
				else if (skill.CDLeftTime > num3)
				{
					num2 = key;
					num3 = skill.CDLeftTime;
					result = true;
				}
			}
		}
		if (skillIDs != null && skillIDs.Count <= 0 && num2 > 0)
		{
			skillIDs.Add(-1);
			skillIDs.Add(num2);
		}
		return result;
	}

	// Token: 0x06018244 RID: 98884 RVA: 0x007820FF File Offset: 0x007804FF
	public override void OnFinish()
	{
		base.OnFinish();
	}

	// Token: 0x04011690 RID: 71312
	protected Mechanism50.TargetType targetType;

	// Token: 0x04011691 RID: 71313
	protected int minCD;

	// Token: 0x04011692 RID: 71314
	protected int maxCD;

	// Token: 0x04011693 RID: 71315
	protected List<int> useSkillIdList = new List<int>();

	// Token: 0x04011694 RID: 71316
	protected List<int> skillIdList = new List<int>();

	// Token: 0x04011695 RID: 71317
	protected VFactor _reduceCdpercent = VFactor.zero;

	// Token: 0x020043F1 RID: 17393
	public enum TargetType
	{
		// Token: 0x04011697 RID: 71319
		PET_OWER,
		// Token: 0x04011698 RID: 71320
		OWER
	}
}
