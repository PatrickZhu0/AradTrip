using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;

// Token: 0x02004159 RID: 16729
public class BuffInfoData
{
	// Token: 0x06016D9C RID: 93596 RVA: 0x00705D1C File Offset: 0x0070411C
	public BuffInfoData()
	{
		this.level = 1;
		this.abnormalLevel = this.level;
		this.target = BuffTarget.SELF;
		this.prob = GlobalLogic.VALUE_1000;
		this.duration = -1;
		this.condition = BuffCondition.NONE;
		this.delay = 0;
	}

	// Token: 0x06016D9D RID: 93597 RVA: 0x00705D9C File Offset: 0x0070419C
	public BuffInfoData(int buffInfoID, int externLevel = 0, int addLevel = 0)
	{
		this.buffInfoID = buffInfoID;
		if (buffInfoID != 0)
		{
			this.data = Singleton<TableManager>.GetInstance().GetTableItem<BuffInfoTable>(buffInfoID, string.Empty, string.Empty);
			if (this.data != null)
			{
				this.buffID = this.data.BuffID;
				this.level = TableManager.GetValueFromUnionCell(this.data.BuffLevel, externLevel, true);
				this.abnormalLevel = TableManager.GetValueFromUnionCell(this.data.BuffLevel, externLevel, true);
				if (this.data.BuffLevel.valueType != UnionCellType.union_fix && externLevel > 0)
				{
					this.level = externLevel;
				}
				this.level = Mathf.Max(1, externLevel);
				this.level += addLevel;
				this.target = (BuffTarget)this.data.BuffTarget;
				this.prob = TableManager.GetValueFromUnionCell(this.data.AttachBuffRate, this.level, true);
				this.duration = TableManager.GetValueFromUnionCell(this.data.AttachBuffTime, this.level, true);
				this.attack = TableManager.GetValueFromUnionCell(this.data.BuffAttack, this.level, true);
				this.condition = (BuffCondition)this.data.BuffCondition;
				this.buffRangeRadius = TableManager.GetValueFromUnionCell(this.data.BuffRangeRadius, this.level, true);
				this.buffTargetRangeRadius = this.data.BuffTargetRadius;
				this.CD = TableManager.GetValueFromUnionCell(this.data.BuffInfoCD, this.level, true);
				this.startCD = TableManager.GetValueFromUnionCell(this.data.BuffInfoStartCD, this.level, true);
				if (this.startCD > 0)
				{
					this.StartInitCD();
				}
				this.delay = this.data.BuffDelay;
				this.effectName = this.data.EffectName;
				this.effectLocatorName = this.data.EffectLocateName;
				if (this.skillIDs == null)
				{
					this.skillIDs = new List<int>();
				}
				for (int i = 0; i < this.data.SkillID.Count; i++)
				{
					if (this.data.SkillID[i] > 0)
					{
						this.skillIDs.Add(this.data.SkillID[i]);
					}
				}
				if (this.condition == BuffCondition.RELEASE_SEPCIFY_SKILL || this.condition == BuffCondition.RELEASE_SEPCIFY_SKILL_HIT || this.condition == BuffCondition.RELEASE_SEPCIFY_SKILL_COMPLETE)
				{
					if (this.conditionSkillIDs == null)
					{
						this.conditionSkillIDs = new List<int>();
					}
					for (int j = 0; j < this.data.ConditionSkillID.Count; j++)
					{
						this.conditionSkillIDs.Add(this.data.ConditionSkillID[j]);
					}
				}
				this.monsterMode = this.data.monsterModeType;
				if (this.data.MonsterTypeMap.Count >= 1 && this.data.MonsterTypeMap[0].valueType == UnionCellType.union_fixGrow)
				{
					for (int k = 0; k < this.data.MonsterTypeMap.Count; k++)
					{
						int fixInitValue = this.data.MonsterTypeMap[k].fixInitValue;
						int fixLevelGrow = this.data.MonsterTypeMap[k].fixLevelGrow;
						if (!this.mapMonsterTypeBuff.ContainsKey(fixInitValue))
						{
							this.mapMonsterTypeBuff.Add(fixInitValue, fixLevelGrow);
						}
					}
				}
				this.checkInterval = ((this.data.BuffRangeCheckInterval != 0) ? this.data.BuffRangeCheckInterval : this.CHECK_INTERVAL);
			}
		}
	}

	// Token: 0x06016D9E RID: 93598 RVA: 0x007061D4 File Offset: 0x007045D4
	public void OnAdd(BeActor owner)
	{
		if (this.condition == BuffCondition.RANGE && Utility.IsStringValid(this.effectName))
		{
			this.effect = owner.m_pkGeActor.CreateEffect(this.effectName, this.effectLocatorName, 9999999f, new Vec3(0f, 0f, 0f), 1f, 1f, false, false, EffectTimeType.SYNC_ANIMATION, false);
		}
		int[] array = new int[]
		{
			GlobalLogic.VALUE_1000
		};
		owner.TriggerEvent(BeEventType.onChangeBuffRangeRadius, new object[]
		{
			this.buffInfoID,
			array
		});
		this.buffRangeRadius *= VFactor.NewVFactor(array[0], GlobalLogic.VALUE_1000);
	}

	// Token: 0x06016D9F RID: 93599 RVA: 0x00706296 File Offset: 0x00704696
	public void OnRemove(BeActor owner)
	{
		if (this.condition == BuffCondition.RANGE && this.effect != null)
		{
			owner.m_pkGeActor.DestroyEffect(this.effect);
			this.effect = null;
		}
	}

	// Token: 0x06016DA0 RID: 93600 RVA: 0x007062C8 File Offset: 0x007046C8
	public void DoEnhance(BuffInfoData enhance, bool addLevel = false)
	{
		this.attack += enhance.attack;
		if (addLevel)
		{
			this.level += enhance.level;
			this.abnormalLevel += enhance.level;
		}
		this.prob += enhance.prob;
		this.duration += enhance.duration;
		if (enhance.attackPercent != 0)
		{
			this.attack += IntMath.Float2Int((float)(this.attack * enhance.attackPercent) / (float)GlobalLogic.VALUE_1000);
		}
	}

	// Token: 0x06016DA1 RID: 93601 RVA: 0x007063D0 File Offset: 0x007047D0
	public bool ContainSkillID(int skillID)
	{
		return this.conditionSkillIDs != null && this.conditionSkillIDs.Contains(skillID);
	}

	// Token: 0x06016DA2 RID: 93602 RVA: 0x007063EB File Offset: 0x007047EB
	private bool checkCanRemoveInrangers(BeActor item)
	{
		if (item.IsDead() || !this.targets.Contains(item))
		{
			item.buffController.RemoveBuff(this.buffID, 0, 0);
			return true;
		}
		return false;
	}

	// Token: 0x06016DA3 RID: 93603 RVA: 0x00706424 File Offset: 0x00704824
	public void UpdateCheckRange(int delta, BeActor owner)
	{
		if (owner == null)
		{
			return;
		}
		this.timeAcc += delta;
		if (this.timeAcc >= this.checkInterval)
		{
			this.timeAcc -= this.checkInterval;
			if (this.targets == null)
			{
				this.targets = new List<BeActor>();
			}
			if (this.target == BuffTarget.ENEMY)
			{
				owner.CurrentBeScene.FindTargets(this.targets, owner, VInt.NewVInt((long)this.buffRangeRadius, (long)GlobalLogic.VALUE_1000), false, null);
			}
			else if (this.target == BuffTarget.FRIEND)
			{
				owner.CurrentBeScene.FindTargets(this.targets, owner, VInt.NewVInt((long)this.buffRangeRadius, (long)GlobalLogic.VALUE_1000), true, null);
			}
			else if (this.target == BuffTarget.FRIEND_NOTSELF)
			{
				owner.CurrentBeScene.FindTargets(this.targets, owner, VInt.NewVInt((long)this.buffRangeRadius, (long)GlobalLogic.VALUE_1000), true, null);
				if (this.targets.Contains(owner))
				{
					this.targets.Remove(owner);
				}
			}
			else if (this.target == BuffTarget.RANGE_FRIEND_ADNSELF)
			{
				owner.CurrentBeScene.FindTargets(this.targets, owner, VInt.NewVInt((long)this.buffRangeRadius, (long)GlobalLogic.VALUE_1000), true, null);
			}
			else if (this.target == BuffTarget.RANGE_FRIENDHERO)
			{
				BeUtility.GetAllFriendPlayers(owner, this.targets);
			}
			else if (this.target == BuffTarget.RANGE_ENEMYHERO)
			{
				BeUtility.GetAllEnemyPlayers(owner, this.targets);
			}
			else if (this.target == BuffTarget.RANGE_FRIEND_NOTSUMMON)
			{
				BeGetRangeFriendNotSummon filter = new BeGetRangeFriendNotSummon();
				owner.CurrentBeScene.FindTargets(this.targets, owner, VInt.NewVInt((long)this.buffRangeRadius, (long)GlobalLogic.VALUE_1000), true, filter);
			}
			else if (this.target == BuffTarget.OUT_OF_RANGE_ENEMY)
			{
				BeGetConcentricCircleTarget beGetConcentricCircleTarget = new BeGetConcentricCircleTarget();
				beGetConcentricCircleTarget.m_Owner = owner;
				beGetConcentricCircleTarget.m_OwnerPosXY = new VInt2(owner.GetPosition().x, owner.GetPosition().y);
				beGetConcentricCircleTarget.m_MinCircleRadius = VInt.NewVInt(this.buffRangeRadius, GlobalLogic.VALUE_1000);
				beGetConcentricCircleTarget.m_MaxCircleRadius = BeGetConcentricCircleTarget.LargeMaxCirleRadius;
				owner.CurrentBeScene.GetFilterTarget(this.targets, beGetConcentricCircleTarget, true);
			}
			for (int i = 0; i < this.targets.Count; i++)
			{
				if (!this.inRangers.Contains(this.targets[i]))
				{
					this.inRangers.Add(this.targets[i]);
				}
			}
			this.inRangers.RemoveAll(new Predicate<BeActor>(this.checkCanRemoveInrangers));
			for (int j = 0; j < this.inRangers.Count; j++)
			{
				if (this.inRangers[j].buffController.HasBuffByID(this.buffID) == null)
				{
					this.inRangers[j].buffController.TryAddBuff(this.buffID, -1, this.level, GlobalLogic.VALUE_1000, this.attack, false, null, 0, 0, null);
				}
			}
		}
	}

	// Token: 0x06016DA4 RID: 93604 RVA: 0x00706766 File Offset: 0x00704B66
	public void DoRelease()
	{
		this.inRangers.RemoveAll(delegate(BeActor item)
		{
			item.buffController.RemoveBuff(this.buffID, 0, 0);
			return true;
		});
	}

	// Token: 0x06016DA5 RID: 93605 RVA: 0x00706780 File Offset: 0x00704B80
	public void Update(int delta)
	{
		if (this.isCooldown)
		{
			this.cdAcc += delta;
			if (this.cdAcc >= this.CD)
			{
				this.StopCD();
			}
		}
	}

	// Token: 0x06016DA6 RID: 93606 RVA: 0x007067B7 File Offset: 0x00704BB7
	public void StartInitCD()
	{
		this.SetCDRemain(this.CD - this.startCD);
	}

	// Token: 0x06016DA7 RID: 93607 RVA: 0x007067D6 File Offset: 0x00704BD6
	public void StartCD()
	{
		if (!this.NeedCD())
		{
			return;
		}
		this.isCooldown = true;
		this.cdAcc = 0;
	}

	// Token: 0x06016DA8 RID: 93608 RVA: 0x007067F2 File Offset: 0x00704BF2
	public void StopCD()
	{
		this.isCooldown = false;
		this.cdAcc = 0;
	}

	// Token: 0x06016DA9 RID: 93609 RVA: 0x00706802 File Offset: 0x00704C02
	public bool IsCD()
	{
		return this.isCooldown;
	}

	// Token: 0x06016DAA RID: 93610 RVA: 0x0070680A File Offset: 0x00704C0A
	public bool NeedCD()
	{
		return this.CD > 0;
	}

	// Token: 0x06016DAB RID: 93611 RVA: 0x0070681A File Offset: 0x00704C1A
	public int GetCDAcc()
	{
		return this.cdAcc;
	}

	// Token: 0x06016DAC RID: 93612 RVA: 0x00706822 File Offset: 0x00704C22
	public void SetCDRemain(int cdRemain)
	{
		this.isCooldown = true;
		this.cdAcc = cdRemain;
	}

	// Token: 0x04010577 RID: 66935
	public CrypticInt32 buffInfoID;

	// Token: 0x04010578 RID: 66936
	public CrypticInt32 buffID;

	// Token: 0x04010579 RID: 66937
	public CrypticInt32 level;

	// Token: 0x0401057A RID: 66938
	public CrypticInt32 abnormalLevel;

	// Token: 0x0401057B RID: 66939
	public BuffTarget target;

	// Token: 0x0401057C RID: 66940
	public CrypticInt32 buffTargetRangeRadius;

	// Token: 0x0401057D RID: 66941
	public CrypticInt32 prob;

	// Token: 0x0401057E RID: 66942
	public CrypticInt32 duration;

	// Token: 0x0401057F RID: 66943
	public CrypticInt32 attack;

	// Token: 0x04010580 RID: 66944
	public CrypticInt32 attackPercent;

	// Token: 0x04010581 RID: 66945
	public BuffCondition condition;

	// Token: 0x04010582 RID: 66946
	public List<int> skillIDs;

	// Token: 0x04010583 RID: 66947
	public int buffRangeRadius;

	// Token: 0x04010584 RID: 66948
	public List<int> conditionSkillIDs;

	// Token: 0x04010585 RID: 66949
	public int checkInterval;

	// Token: 0x04010586 RID: 66950
	public Dictionary<int, int> mapMonsterTypeBuff = new Dictionary<int, int>();

	// Token: 0x04010587 RID: 66951
	public string effectName;

	// Token: 0x04010588 RID: 66952
	public string effectLocatorName;

	// Token: 0x04010589 RID: 66953
	public CrypticInt32 CD;

	// Token: 0x0401058A RID: 66954
	public CrypticInt32 startCD;

	// Token: 0x0401058B RID: 66955
	public int delay;

	// Token: 0x0401058C RID: 66956
	public BuffInfoTable data;

	// Token: 0x0401058D RID: 66957
	private int CHECK_INTERVAL = GlobalLogic.VALUE_1000;

	// Token: 0x0401058E RID: 66958
	private int timeAcc;

	// Token: 0x0401058F RID: 66959
	private bool isCooldown;

	// Token: 0x04010590 RID: 66960
	private int cdAcc;

	// Token: 0x04010591 RID: 66961
	public int monsterMode;

	// Token: 0x04010592 RID: 66962
	private GeEffectEx effect;

	// Token: 0x04010593 RID: 66963
	private List<BeActor> inRangers = new List<BeActor>();

	// Token: 0x04010594 RID: 66964
	private List<BeActor> targets;
}
