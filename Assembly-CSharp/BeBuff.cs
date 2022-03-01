using System;
using System.Collections.Generic;
using GameClient;
using GamePool;
using ProtoTable;
using UnityEngine;

// Token: 0x02004153 RID: 16723
public class BeBuff
{
	// Token: 0x06016D3D RID: 93501 RVA: 0x006E3928 File Offset: 0x006E1D28
	public BeBuff(int bi, int buffLevel, int buffDuration, int attack = 0, bool buffEffectAni = true)
	{
		this.buffID = bi;
		this.level = buffLevel;
		this.duration = buffDuration;
		this.buffAttack = attack;
		this.buffEffectAni = buffEffectAni;
		for (int i = 0; i < this.valueChanged.Length; i++)
		{
			this.valueChanged[i] = 0;
		}
		this.LoadBuffByID(bi);
	}

	// Token: 0x17001F26 RID: 7974
	// (get) Token: 0x06016D3E RID: 93502 RVA: 0x006E3A06 File Offset: 0x006E1E06
	// (set) Token: 0x06016D3F RID: 93503 RVA: 0x006E3A0E File Offset: 0x006E1E0E
	public BeActor owner { get; set; }

	// Token: 0x17001F27 RID: 7975
	// (get) Token: 0x06016D40 RID: 93504 RVA: 0x006E3A17 File Offset: 0x006E1E17
	// (set) Token: 0x06016D41 RID: 93505 RVA: 0x006E3A1F File Offset: 0x006E1E1F
	public BeActor releaser { get; set; }

	// Token: 0x17001F28 RID: 7976
	// (set) Token: 0x06016D42 RID: 93506 RVA: 0x006E3A28 File Offset: 0x006E1E28
	public bool NeedRestoreTargetAction
	{
		set
		{
			this.m_NeedRestoreTargetAction = value;
		}
	}

	// Token: 0x17001F29 RID: 7977
	// (get) Token: 0x06016D43 RID: 93507 RVA: 0x006E3A31 File Offset: 0x006E1E31
	public int runTime
	{
		get
		{
			return this.timeAcc;
		}
	}

	// Token: 0x17001F2A RID: 7978
	// (get) Token: 0x06016D44 RID: 93508 RVA: 0x006E3A39 File Offset: 0x006E1E39
	public BattleType battleType
	{
		get
		{
			return this.owner.battleType;
		}
	}

	// Token: 0x06016D45 RID: 93509 RVA: 0x006E3A46 File Offset: 0x006E1E46
	public void Init()
	{
	}

	// Token: 0x06016D46 RID: 93510 RVA: 0x006E3A48 File Offset: 0x006E1E48
	public void DeInit()
	{
	}

	// Token: 0x06016D47 RID: 93511 RVA: 0x006E3A4C File Offset: 0x006E1E4C
	public void LoadBuffByID(int bid)
	{
		try
		{
			BuffTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffTable>(bid, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.name = tableItem.Name;
				this.buffData = tableItem;
				this.buffType = (BuffType)this.buffData.Type;
				this.buffWorkType = (BuffWorkType)this.buffData.WorkType;
				this.overlayType = (BuffOverlayType)this.buffData.Overlay;
				this.isShowSpell = (this.buffData.IsShowSpell && this.buffData.OverlayLimit == 1);
				if (this.buffData.TriggerInterval > 0)
				{
					this.timeType = BuffTimeType.INTERVAL;
					this.timeInterval = this.buffData.TriggerInterval;
					this.totalAttackCount = this.duration / tableItem.TriggerInterval;
				}
				if (this.buffData.DispelType == 1)
				{
					this.dispel = true;
				}
			}
			this.buffEffect = new BuffEffect();
			this.buffEffect.Init(bid, this.buffEffectAni);
			this.buffEffect.buff = this;
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("Load buff error bid: {0}, exception: {1}", new object[]
			{
				bid,
				ex.Message
			});
		}
	}

	// Token: 0x06016D48 RID: 93512 RVA: 0x006E3BB4 File Offset: 0x006E1FB4
	public void PostInit()
	{
		this.OnInit();
	}

	// Token: 0x06016D49 RID: 93513 RVA: 0x006E3BBC File Offset: 0x006E1FBC
	public void SetBuffReleaser(BeActor actor)
	{
		if (actor == null)
		{
			return;
		}
		if (this.releaser != null)
		{
			return;
		}
		this.releaser = actor;
		this.skillId = this.releaser.m_iCurSkillID;
		this.releaser.TriggerEvent(BeEventType.OnAddBuffToOthers, new object[]
		{
			this.owner,
			this
		});
	}

	// Token: 0x06016D4A RID: 93514 RVA: 0x006E3C14 File Offset: 0x006E2014
	public virtual bool CanAdd(BeActor target)
	{
		return true;
	}

	// Token: 0x06016D4B RID: 93515 RVA: 0x006E3C17 File Offset: 0x006E2017
	protected void DoSyncHPBar(BeActor actor)
	{
		if (actor != null && actor.m_pkGeActor != null)
		{
			actor.m_pkGeActor.SyncHPBar();
		}
	}

	// Token: 0x06016D4C RID: 93516 RVA: 0x006E3C38 File Offset: 0x006E2038
	public int GetAbnromalDamage(int buffAttack, int duration)
	{
		int result = 0;
		if (buffAttack > 0)
		{
			if (this.buffType == BuffType.FLASH)
			{
				result = this.owner.GetEntityData().GetAbnormalDamage(buffAttack, 0, this.releaser);
			}
			else
			{
				result = this.owner.GetEntityData().GetAbnormalDamage(buffAttack, IntMath.Float2Int((float)duration / (float)GlobalLogic.VALUE_1000 * (float)GlobalLogic.VALUE_2), this.releaser);
			}
		}
		return result;
	}

	// Token: 0x06016D4D RID: 93517 RVA: 0x006E3CA8 File Offset: 0x006E20A8
	public void Start()
	{
		this.state.SetRunning();
		if (this.owner.CurrentBeBattle != null && this.owner.CurrentBeBattle.HasFlag(BattleFlagType.HandleRemoveOptimize))
		{
			this.rebornHandle = this.owner.RegisterEvent(BeEventType.onReborn, delegate(object[] args)
			{
				if (this.duration == 2147483647)
				{
					this.ShowEffect();
				}
			});
		}
		this.TriggerEvent(BeEventType.onBuffStart, new object[]
		{
			this.buffID
		});
		if (this.owner != null)
		{
			this.owner.TriggerEvent(BeEventType.onBuffStart, new object[]
			{
				this.buffID
			});
			if (this.isShowSpell)
			{
				this.owner.StartSpellBar(eDungeonCharactorBar.Buff, this.duration, true, this.buffData.HeadName, true);
				this.owner.AddStateBar(this.buffData.HeadName, this.duration);
			}
		}
		if (this.timeInterval <= 0 || this.buffType != BuffType.TRIGGER_BUFFINFO)
		{
			this.DoWork();
		}
		this.OnStart();
	}

	// Token: 0x06016D4E RID: 93518 RVA: 0x006E3DD8 File Offset: 0x006E21D8
	private void ChangeTargetAction()
	{
		if (this.owner.GetPosition().z > 0)
		{
			this.addBuffInAir = true;
		}
		if (this.buffData != null && this.buffData.TargetState.Length > 0 && this.buffData.TargetState[0] != -1)
		{
			int iState = this.buffData.TargetState[0];
			if (this.CanLocomoteState(iState))
			{
				this.m_NeedRestoreTargetAction = true;
				this.owner.Locomote(new BeStateData(iState, 0, 0, 0, 0, this.duration, true), true);
			}
		}
		if (this.owner.HasTag(4))
		{
			this.addBuffFallGround = true;
		}
	}

	// Token: 0x06016D4F RID: 93519 RVA: 0x006E3E9C File Offset: 0x006E229C
	private bool CanLocomoteState(int state)
	{
		return this.owner.stateController == null || (state != 13 && state != 15 && state != 4) || !this.owner.stateController.HaveSuperBati();
	}

	// Token: 0x06016D50 RID: 93520 RVA: 0x006E3EDC File Offset: 0x006E22DC
	private bool _isStunBuff()
	{
		if (this.buffData != null)
		{
			for (int i = 0; i < this.buffData.StateChange.Length; i++)
			{
				if (this.buffData.StateChange[i] == 128)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06016D51 RID: 93521 RVA: 0x006E3F34 File Offset: 0x006E2334
	private void RestoreTargetAction()
	{
		if (!this.m_NeedRestoreTargetAction)
		{
			return;
		}
		if (this.buffData.TargetState.Length > 0 && this.buffData.TargetState[0] != -1 && this.owner.sgGetCurrentState() != 15)
		{
			bool flag = false;
			bool flag2 = this._isStunBuff();
			if (this.owner != null && this.owner.CurrentBeBattle != null && this.owner.CurrentBeBattle.FunctionIsOpen(BattleFlagType.StunBuffRestore2Idle))
			{
				flag2 = false;
			}
			if (this.buffData.TargetState.Length == 2 && this.buffData.TargetState[1] > 0)
			{
				flag = true;
			}
			bool flag3 = false;
			if (flag)
			{
				this.owner.Locomote(new BeStateData(0, 0), false);
			}
			else if (flag2 && (this.owner.HasTag(4) || this.owner.HasTag(1) || this.owner.sgGetCurrentState() == 4))
			{
				this.owner.sgPushState(new BeStateData(0, 0));
			}
			else if (this.owner.GetStateGraph().HasStateInStack(17) || (this.owner.GetPosition().z <= 0 && this.addBuffInAir) || this.addBuffFallGround)
			{
				flag3 = true;
				if (this.isReduceByQuickPress)
				{
					this.owner.Locomote(new BeStateData(0, 0), false);
				}
				else if (this.owner.HasTag(4))
				{
					this.owner.Locomote(new BeStateData(0, 0), false);
				}
				else
				{
					this.owner.sgPushState(new BeStateData(0, 0));
				}
			}
			else if (this.owner.sgGetCurrentState() != 17)
			{
				this.owner.Locomote(new BeStateData(0, 0), false);
			}
			else
			{
				this.owner.sgPushState(new BeStateData(0, 0));
			}
			if (flag3)
			{
				this.owner.protectManager.ClearGroundProtect();
				this.owner.protectManager.DelayClearFallProtect();
			}
		}
	}

	// Token: 0x06016D52 RID: 93522 RVA: 0x006E417C File Offset: 0x006E257C
	private void ChangeTargetState()
	{
		if (this.buffData != null)
		{
			for (int i = 0; i < this.buffData.StateChange.Count; i++)
			{
				int num = this.buffData.StateChange[i];
				if (num >= 1)
				{
					BeBuffStateType beBuffStateType = (BeBuffStateType)(1 << num);
					if (!this.owner.stateController.HasBuffState(beBuffStateType))
					{
						this.owner.stateController.SetBuffState(beBuffStateType, false);
						this.stateChanged[this.stateChangedCount++] = (int)beBuffStateType;
					}
				}
			}
		}
	}

	// Token: 0x06016D53 RID: 93523 RVA: 0x006E421C File Offset: 0x006E261C
	private void RestoreTargetState()
	{
		if (this.buffData != null)
		{
			for (int i = 0; i < this.stateChangedCount; i++)
			{
				int target = this.stateChanged[i];
				this.owner.stateController.SetBuffState((BeBuffStateType)target, true);
			}
		}
	}

	// Token: 0x06016D54 RID: 93524 RVA: 0x006E4268 File Offset: 0x006E2668
	private void ChangeTargetAbility()
	{
		if (this.buffData != null)
		{
			for (int i = 0; i < this.buffData.AbilityChange.Count; i++)
			{
				int num = this.buffData.AbilityChange[i];
				BeAbilityType abilityType = (BeAbilityType)num;
				this.owner.stateController.SetAbilityEnable(abilityType, false);
			}
		}
		if (!this.owner.stateController.CanMove())
		{
			this.owner.ClearMoveSpeed(7);
		}
	}

	// Token: 0x06016D55 RID: 93525 RVA: 0x006E42E8 File Offset: 0x006E26E8
	private void RestoreTargetAbility()
	{
		if (this.buffData != null)
		{
			for (int i = 0; i < this.buffData.AbilityChange.Count; i++)
			{
				int abilityType = this.buffData.AbilityChange[i];
				this.owner.stateController.SetAbilityEnable((BeAbilityType)abilityType, true);
			}
		}
	}

	// Token: 0x06016D56 RID: 93526 RVA: 0x006E4348 File Offset: 0x006E2748
	private void ChangeAIAttribute()
	{
		if (this.buffData != null && this.owner.aiManager != null)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.buffData.ai_sight, this.level, true);
			int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(this.buffData.ai_warlike, this.level, true);
			int valueFromUnionCell3 = TableManager.GetValueFromUnionCell(this.buffData.ai_attackProb, this.level, true);
			if (valueFromUnionCell > 0)
			{
				this.owner.aiManager.sight += valueFromUnionCell;
			}
			if (valueFromUnionCell2 > 0)
			{
				this.owner.aiManager.warlike += valueFromUnionCell2;
			}
			if (valueFromUnionCell3 > 0)
			{
				this.owner.aiManager.AddAttackProb(valueFromUnionCell3);
			}
		}
	}

	// Token: 0x06016D57 RID: 93527 RVA: 0x006E4420 File Offset: 0x006E2820
	private void RestoreAIAttribute()
	{
		if (this.buffData != null && this.owner.aiManager != null)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.buffData.ai_sight, this.level, true);
			int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(this.buffData.ai_warlike, this.level, true);
			int valueFromUnionCell3 = TableManager.GetValueFromUnionCell(this.buffData.ai_attackProb, this.level, true);
			if (valueFromUnionCell > 0)
			{
				this.owner.aiManager.sight -= valueFromUnionCell;
			}
			if (valueFromUnionCell2 > 0)
			{
				this.owner.aiManager.warlike -= valueFromUnionCell2;
			}
			if (valueFromUnionCell3 > 0)
			{
				this.owner.aiManager.AddAttackProb(-valueFromUnionCell3);
			}
		}
	}

	// Token: 0x06016D58 RID: 93528 RVA: 0x006E44F8 File Offset: 0x006E28F8
	private void ChangeAttribute()
	{
		if (this.buffData != null)
		{
			bool flag = false;
			BeEntityData entityData = this.owner.GetEntityData();
			for (int i = 0; i <= 39; i++)
			{
				UnionCell buffTableProperty = Singleton<TableManager>.GetInstance().GetBuffTableProperty((AttributeType)i, this.buffData);
				if (buffTableProperty != null)
				{
					int valueFromUnionCell = TableManager.GetValueFromUnionCell(buffTableProperty, this.level, true);
					if (i == 0 && valueFromUnionCell != 0)
					{
						flag = true;
						entityData.ChangeMaxHp(valueFromUnionCell);
					}
					else if (i == 1 && valueFromUnionCell != 0)
					{
						flag = true;
						entityData.battleData.ChangeMaxMP(valueFromUnionCell);
					}
					else if (valueFromUnionCell != 0)
					{
						entityData.SetAttributeValue((AttributeType)i, valueFromUnionCell, true);
						if (i == 2)
						{
							this.owner.GetEntityData().battleData.hpRecover = this.owner.GetEntityData().battleData.fHpRecoer;
						}
						else if (i == 3)
						{
							this.owner.GetEntityData().battleData.mpRecover = this.owner.GetEntityData().battleData.fMpRecover;
						}
					}
				}
			}
			int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(this.buffData.sta, this.level, true);
			if (valueFromUnionCell2 != 0)
			{
				entityData.battleData.sta += valueFromUnionCell2;
				flag = true;
			}
			int valueFromUnionCell3 = TableManager.GetValueFromUnionCell(this.buffData.spr, this.level, true);
			if (valueFromUnionCell3 != 0)
			{
				entityData.battleData.spr += valueFromUnionCell3;
				flag = true;
			}
			for (int j = 0; j < BeBuff._propertyRateName.Length; j++)
			{
				BeBuff._propertyRate propertyRate = BeBuff._propertyRateName[j];
				bool flag2 = this.ConvertValueForRate(j, propertyRate.buffName, propertyRate.at, entityData.battleData, entityData, true, false);
				if (flag2)
				{
					flag = true;
				}
			}
			int valueFromUnionCell4 = TableManager.GetValueFromUnionCell(this.buffData.moveSpeed, this.level, true);
			if (valueFromUnionCell4 != 0 && this.owner.sgGetCurrentState() == 3)
			{
				this.owner.RefreshMoveSpeed();
			}
			int valueFromUnionCell5 = TableManager.GetValueFromUnionCell(this.buffData.addDamageFix, this.level, true);
			if (valueFromUnionCell5 > 0)
			{
				entityData.battleData.addDamageFix.Add(new AddDamageInfo(valueFromUnionCell5, 0));
			}
			valueFromUnionCell5 = TableManager.GetValueFromUnionCell(this.buffData.addDamagePercent, this.level, true);
			if (valueFromUnionCell5 > 0)
			{
				entityData.battleData.addDamagePercent.Add(new AddDamageInfo(valueFromUnionCell5, 0));
			}
			valueFromUnionCell5 = TableManager.GetValueFromUnionCell(this.buffData.attachAddDamageFix, this.level, true);
			if (valueFromUnionCell5 > 0)
			{
				entityData.battleData.attachAddDamageFix.Add(new AddDamageInfo(valueFromUnionCell5, 0));
			}
			valueFromUnionCell5 = TableManager.GetValueFromUnionCell(this.buffData.attachAddDamagePercent, this.level, true);
			if (valueFromUnionCell5 > 0)
			{
				entityData.battleData.attachAddDamagePercent.Add(new AddDamageInfo(valueFromUnionCell5, 0));
			}
			valueFromUnionCell5 = TableManager.GetValueFromUnionCell(this.buffData.reduceDamageFix, this.level, true);
			if (valueFromUnionCell5 > 0)
			{
				entityData.battleData.reduceDamageFix.Add(new AddDamageInfo(valueFromUnionCell5, this.buffData.reduceDamageFixType));
			}
			valueFromUnionCell5 = TableManager.GetValueFromUnionCell(this.buffData.reduceDamagePercent, this.level, true);
			if (valueFromUnionCell5 != 0)
			{
				entityData.battleData.reduceDamagePercent.Add(new AddDamageInfo(valueFromUnionCell5, this.buffData.reduceDamagePercentType));
			}
			valueFromUnionCell5 = TableManager.GetValueFromUnionCell(this.buffData.extrareduceDamgePercent, this.level, true);
			if (valueFromUnionCell5 != 0)
			{
				entityData.battleData.reduceExtraDamagePercent.Add(new AddDamageInfo(valueFromUnionCell5, this.buffData.extrareduceDamagePercentType));
			}
			valueFromUnionCell5 = TableManager.GetValueFromUnionCell(this.buffData.skilladdDamagePercent, this.level, true);
			if (valueFromUnionCell5 != 0)
			{
				entityData.battleData.skillAddDamagePercent.Add(new AddDamageInfo(valueFromUnionCell5, 0));
			}
			valueFromUnionCell5 = TableManager.GetValueFromUnionCell(this.buffData.skilladdMagicDamagePercent, this.level, true);
			if (valueFromUnionCell5 != 0)
			{
				entityData.battleData.skillAddMagicDamagePercent.Add(new AddDamageInfo(valueFromUnionCell5, 0));
			}
			valueFromUnionCell5 = TableManager.GetValueFromUnionCell(this.buffData.reflectDamageFix, this.level, true);
			if (valueFromUnionCell5 > 0)
			{
				entityData.battleData.reflectDamageFix.Add(new AddDamageInfo(valueFromUnionCell5, this.buffData.reflectDamageFixType));
			}
			valueFromUnionCell5 = TableManager.GetValueFromUnionCell(this.buffData.reflectDamagePercent, this.level, true);
			if (valueFromUnionCell5 > 0)
			{
				entityData.battleData.reflectDamagePercent.Add(new AddDamageInfo(valueFromUnionCell5, this.buffData.reflectDamagePercentType));
			}
			valueFromUnionCell5 = TableManager.GetValueFromUnionCell(this.buffData.ResistMagic, this.level, true);
			if (valueFromUnionCell5 != 0)
			{
				this.ChangeResistMaic(valueFromUnionCell5);
			}
			this.DealElement(false);
			this.DealAbnormal(false);
			if (flag)
			{
				this.DoSyncHPBar(this.owner);
			}
		}
	}

	// Token: 0x06016D59 RID: 93529 RVA: 0x006E4A58 File Offset: 0x006E2E58
	private void DealElement(bool restore = false)
	{
		BeEntityData entityData = this.owner.GetEntityData();
		entityData.SetMagicElementTypes(this.buffData.Elements, !restore);
		int num = (!restore) ? 1 : -1;
		CrypticInt32[] magicElementsAttack = entityData.battleData.magicElementsAttack;
		int num2 = 2;
		magicElementsAttack[num2] += num * TableManager.GetValueFromUnionCell(this.buffData.FireAttack, this.level, true);
		CrypticInt32[] magicElementsAttack2 = entityData.battleData.magicElementsAttack;
		int num3 = 3;
		magicElementsAttack2[num3] += num * TableManager.GetValueFromUnionCell(this.buffData.IceAttack, this.level, true);
		CrypticInt32[] magicElementsAttack3 = entityData.battleData.magicElementsAttack;
		int num4 = 1;
		magicElementsAttack3[num4] += num * TableManager.GetValueFromUnionCell(this.buffData.LightAttack, this.level, true);
		CrypticInt32[] magicElementsAttack4 = entityData.battleData.magicElementsAttack;
		int num5 = 4;
		magicElementsAttack4[num5] += num * TableManager.GetValueFromUnionCell(this.buffData.DarkAttack, this.level, true);
		CrypticInt32[] magicElementsDefence = entityData.battleData.magicElementsDefence;
		int num6 = 2;
		magicElementsDefence[num6] += num * TableManager.GetValueFromUnionCell(this.buffData.FireDefence, this.level, true);
		CrypticInt32[] magicElementsDefence2 = entityData.battleData.magicElementsDefence;
		int num7 = 3;
		magicElementsDefence2[num7] += num * TableManager.GetValueFromUnionCell(this.buffData.IceDefence, this.level, true);
		CrypticInt32[] magicElementsDefence3 = entityData.battleData.magicElementsDefence;
		int num8 = 1;
		magicElementsDefence3[num8] += num * TableManager.GetValueFromUnionCell(this.buffData.LightDefence, this.level, true);
		CrypticInt32[] magicElementsDefence4 = entityData.battleData.magicElementsDefence;
		int num9 = 4;
		magicElementsDefence4[num9] += num * TableManager.GetValueFromUnionCell(this.buffData.DarkDefence, this.level, true);
	}

	// Token: 0x06016D5A RID: 93530 RVA: 0x006E4CBC File Offset: 0x006E30BC
	private void DealAbnormal(bool restore = false)
	{
		BeEntityData entityData = this.owner.GetEntityData();
		int num = (!restore) ? 1 : -1;
		UnionCell[] array = new UnionCell[]
		{
			this.buffData.abnormalResist1,
			this.buffData.abnormalResist2,
			this.buffData.abnormalResist3,
			this.buffData.abnormalResist4,
			this.buffData.abnormalResist5,
			this.buffData.abnormalResist6,
			this.buffData.abnormalResist7,
			this.buffData.abnormalResist8,
			this.buffData.abnormalResist9,
			this.buffData.abnormalResist10,
			this.buffData.abnormalResist11,
			this.buffData.abnormalResist12,
			this.buffData.abnormalResist13
		};
		for (int i = 0; i < 13; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(array[i], this.level, true);
			if (valueFromUnionCell != 0)
			{
				CrypticInt32[] abnormalResists = entityData.battleData.abnormalResists;
				int num2 = i;
				abnormalResists[num2] += num * valueFromUnionCell;
			}
		}
	}

	// Token: 0x06016D5B RID: 93531 RVA: 0x006E4E00 File Offset: 0x006E3200
	private bool ConvertValueForRate(int index, string buffProperty, AttributeType at, BattleData battleData, BeEntityData entityData, bool isField = true, bool isRestore = false)
	{
		bool result = false;
		if (isRestore)
		{
			if (this.valueChanged[index] != 0)
			{
				int num = this.valueChanged[index];
				if (num != 0)
				{
					if (buffProperty == "maxHpAddRate")
					{
						entityData.ChangeMaxHp(-num);
						result = true;
					}
					else if (buffProperty == "maxMpAddRate")
					{
						battleData.ChangeMaxMP(-num);
						result = true;
					}
					else
					{
						battleData.SetValue(at, -num, true);
					}
				}
			}
		}
		else
		{
			UnionCell buffTablePropertyByName = Singleton<TableManager>.GetInstance().GetBuffTablePropertyByName(buffProperty, this.buffData);
			if (buffTablePropertyByName != null)
			{
				int valueFromUnionCell = TableManager.GetValueFromUnionCell(buffTablePropertyByName, this.level, true);
				if (valueFromUnionCell != 0)
				{
					int value = battleData.GetValue(at);
					int num2 = IntMath.Float2Int((float)value * ((float)valueFromUnionCell / (float)GlobalLogic.VALUE_1000));
					if (buffProperty == "maxHpAddRate")
					{
						entityData.ChangeMaxHp(num2);
						result = true;
					}
					else if (buffProperty == "maxMpAddRate")
					{
						battleData.ChangeMaxMP(num2);
						result = true;
					}
					else
					{
						battleData.SetValue(at, num2, true);
					}
					this.valueChanged[index] = num2;
				}
			}
		}
		return result;
	}

	// Token: 0x06016D5C RID: 93532 RVA: 0x006E4F3C File Offset: 0x006E333C
	private void RestoreAttribute()
	{
		if (this.buffData != null)
		{
			bool flag = false;
			BeEntityData entityData = this.owner.GetEntityData();
			for (int i = 0; i <= 39; i++)
			{
				UnionCell buffTableProperty = Singleton<TableManager>.GetInstance().GetBuffTableProperty((AttributeType)i, this.buffData);
				if (buffTableProperty != null)
				{
					int valueFromUnionCell = TableManager.GetValueFromUnionCell(buffTableProperty, this.level, true);
					if (i == 0 && valueFromUnionCell != 0)
					{
						entityData.ChangeMaxHp(-valueFromUnionCell);
						flag = true;
					}
					else if (i == 0 && valueFromUnionCell != 0)
					{
						entityData.battleData.ChangeMaxMP(-valueFromUnionCell);
						flag = true;
					}
					else if (valueFromUnionCell != 0)
					{
						entityData.SetAttributeValue((AttributeType)i, -valueFromUnionCell, true);
						if (i == 2)
						{
							this.owner.GetEntityData().battleData.hpRecover = this.owner.GetEntityData().battleData.fHpRecoer;
						}
						else if (i == 3)
						{
							this.owner.GetEntityData().battleData.mpRecover = this.owner.GetEntityData().battleData.fMpRecover;
						}
					}
				}
			}
			int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(this.buffData.sta, this.level, true);
			if (valueFromUnionCell2 != 0)
			{
				entityData.battleData.sta -= valueFromUnionCell2;
				flag = true;
			}
			int valueFromUnionCell3 = TableManager.GetValueFromUnionCell(this.buffData.spr, this.level, true);
			if (valueFromUnionCell3 != 0)
			{
				entityData.battleData.spr -= valueFromUnionCell3;
				flag = true;
			}
			for (int j = 0; j < BeBuff._propertyRateName.Length; j++)
			{
				BeBuff._propertyRate propertyRate = BeBuff._propertyRateName[j];
				bool flag2 = this.ConvertValueForRate(j, propertyRate.buffName, propertyRate.at, entityData.battleData, entityData, false, true);
				if (flag2)
				{
					flag = true;
				}
			}
			int valueFromUnionCell4 = TableManager.GetValueFromUnionCell(this.buffData.moveSpeed, this.level, true);
			if (valueFromUnionCell4 != 0 && this.owner.sgGetCurrentState() == 3)
			{
				this.owner.RefreshMoveSpeed();
			}
			int v = TableManager.GetValueFromUnionCell(this.buffData.addDamageFix, this.level, true);
			if (v > 0)
			{
				int num = entityData.battleData.addDamageFix.FindIndex((AddDamageInfo item) => item.value == v);
				if (num != -1)
				{
					entityData.battleData.addDamageFix.RemoveAt(num);
				}
			}
			v = TableManager.GetValueFromUnionCell(this.buffData.addDamagePercent, this.level, true);
			if (v > 0)
			{
				int num2 = entityData.battleData.addDamagePercent.FindIndex((AddDamageInfo item) => item.value == v);
				if (num2 != -1)
				{
					entityData.battleData.addDamagePercent.RemoveAt(num2);
				}
			}
			v = TableManager.GetValueFromUnionCell(this.buffData.attachAddDamageFix, this.level, true);
			if (v > 0)
			{
				int num3 = entityData.battleData.attachAddDamageFix.FindIndex((AddDamageInfo item) => item.value == v);
				if (num3 != -1)
				{
					entityData.battleData.attachAddDamageFix.RemoveAt(num3);
				}
			}
			v = TableManager.GetValueFromUnionCell(this.buffData.attachAddDamagePercent, this.level, true);
			if (v > 0)
			{
				int num4 = entityData.battleData.attachAddDamagePercent.FindIndex((AddDamageInfo item) => item.value == v);
				if (num4 != -1)
				{
					entityData.battleData.attachAddDamagePercent.RemoveAt(num4);
				}
			}
			v = TableManager.GetValueFromUnionCell(this.buffData.reduceDamageFix, this.level, true);
			if (v > 0)
			{
				int num5 = entityData.battleData.reduceDamageFix.FindIndex((AddDamageInfo item) => item.value == v && item.attackType == (AttackType)this.buffData.reduceDamageFixType);
				if (num5 != -1)
				{
					entityData.battleData.reduceDamageFix.RemoveAt(num5);
				}
			}
			v = TableManager.GetValueFromUnionCell(this.buffData.reduceDamagePercent, this.level, true);
			if (v != 0)
			{
				int num6 = entityData.battleData.reduceDamagePercent.FindIndex((AddDamageInfo item) => item.value == v && item.attackType == (AttackType)this.buffData.reduceDamagePercentType);
				if (num6 != -1)
				{
					entityData.battleData.reduceDamagePercent.RemoveAt(num6);
				}
			}
			v = TableManager.GetValueFromUnionCell(this.buffData.extrareduceDamgePercent, this.level, true);
			if (v != 0)
			{
				this._removeAddDamageList(entityData.battleData.reduceExtraDamagePercent, v, this.buffData.extrareduceDamagePercentType);
			}
			v = TableManager.GetValueFromUnionCell(this.buffData.skilladdDamagePercent, this.level, true);
			if (v != 0)
			{
				this._removeAddDamageList(entityData.battleData.skillAddDamagePercent, v, -1);
			}
			v = TableManager.GetValueFromUnionCell(this.buffData.skilladdMagicDamagePercent, this.level, true);
			if (v != 0)
			{
				this._removeAddDamageList(entityData.battleData.skillAddMagicDamagePercent, v, -1);
			}
			v = TableManager.GetValueFromUnionCell(this.buffData.reflectDamageFix, this.level, true);
			if (v > 0)
			{
				int num7 = entityData.battleData.reflectDamageFix.FindIndex((AddDamageInfo item) => item.value == v && item.attackType == (AttackType)this.buffData.reflectDamageFixType);
				if (num7 != -1)
				{
					entityData.battleData.reflectDamageFix.RemoveAt(num7);
				}
			}
			v = TableManager.GetValueFromUnionCell(this.buffData.reflectDamagePercent, this.level, true);
			if (v > 0)
			{
				int num8 = entityData.battleData.reflectDamagePercent.FindIndex((AddDamageInfo item) => item.value == v && item.attackType == (AttackType)this.buffData.reflectDamagePercentType);
				if (num8 != -1)
				{
					entityData.battleData.reflectDamagePercent.RemoveAt(num8);
				}
			}
			v = TableManager.GetValueFromUnionCell(this.buffData.ResistMagic, this.level, true);
			if (v != 0)
			{
				this.ChangeResistMaic(-v);
			}
			this.DealElement(true);
			this.DealAbnormal(true);
			if (flag)
			{
				this.DoSyncHPBar(this.owner);
			}
		}
	}

	// Token: 0x06016D5D RID: 93533 RVA: 0x006E55EC File Offset: 0x006E39EC
	private void _removeAddDamageList(List<AddDamageInfo> infoList, int value, int type = -1)
	{
		for (int i = 0; i < infoList.Count; i++)
		{
			if (infoList[i].value == value && (type == -1 || infoList[i].attackType == (AttackType)type))
			{
				infoList.RemoveAt(i);
				return;
			}
		}
	}

	// Token: 0x06016D5E RID: 93534 RVA: 0x006E5650 File Offset: 0x006E3A50
	private void DoAttributeAdd()
	{
		if (this.buffData != null)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.buffData.hp, this.level, true);
			if (valueFromUnionCell != 0)
			{
				if (valueFromUnionCell > 0)
				{
					this.owner.DoHeal(valueFromUnionCell, this.ShowHPNumber());
				}
				else
				{
					this.owner.DoHPChange(valueFromUnionCell, this.ShowHPNumber());
					this.owner.TriggerEvent(BeEventType.OnBuffDamage, new object[]
					{
						-valueFromUnionCell,
						this.buffID,
						this.owner
					});
				}
			}
			int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(this.buffData.mp, this.level, true);
			if (valueFromUnionCell2 != 0)
			{
				this.owner.DoMPChange(valueFromUnionCell2, this.ShowHPNumber());
			}
			int valueFromUnionCell3 = TableManager.GetValueFromUnionCell(this.buffData.hpRate, this.level, true);
			if (valueFromUnionCell3 != 0)
			{
				int num = IntMath.Float2Int((float)((long)this.owner.GetEntityData().battleData.maxHp * (long)valueFromUnionCell3) / (float)GlobalLogic.VALUE_1000);
				if (valueFromUnionCell3 > 0)
				{
					this.owner.DoHeal(num, this.ShowHPNumber());
				}
				else
				{
					this.owner.DoHPChange(num, this.ShowHPNumber());
					this.owner.TriggerEvent(BeEventType.OnBuffDamage, new object[]
					{
						-num,
						this.buffID,
						this.owner
					});
				}
			}
			int valueFromUnionCell4 = TableManager.GetValueFromUnionCell(this.buffData.mpRate, this.level, true);
			if (valueFromUnionCell4 != 0)
			{
				this.owner.DoMPChange(IntMath.Float2Int((float)(this.owner.GetEntityData().battleData.maxMp * valueFromUnionCell4) / (float)GlobalLogic.VALUE_1000), this.ShowHPNumber());
			}
			int valueFromUnionCell5 = TableManager.GetValueFromUnionCell(this.buffData.currentHpRate, this.level, true);
			if (valueFromUnionCell5 != 0)
			{
				int num2 = IntMath.Float2Int((float)((long)this.owner.GetEntityData().GetHP() * (long)valueFromUnionCell5) / (float)GlobalLogic.VALUE_1000);
				if (valueFromUnionCell3 > 0)
				{
					this.owner.DoHeal(num2, this.ShowHPNumber());
				}
				else
				{
					BeActor owner = this.owner;
					if ((this.buffData.currentHpRateControl == 1 || (this.buffData.currentHpRateControl == 2 && owner != null && owner.attribute != null && owner.attribute.monsterData != null && owner.attribute.monsterData.MonsterMode == 8 && (owner.IsSkillMonster() || owner.IsMonster()))) && this.owner != null && num2 < 0)
					{
						int num3 = -8000 * this.owner.GetEntityData().level;
						num2 = Mathf.Max(num2, num3);
					}
					this.owner.DoHPChange(num2, this.ShowHPNumber());
					this.owner.TriggerEvent(BeEventType.OnBuffDamage, new object[]
					{
						-num2,
						this.buffID,
						this.owner
					});
				}
			}
			this.owner.TriggerEvent(BeEventType.OnBuffHpChange, new object[]
			{
				this.buffID
			});
		}
	}

	// Token: 0x06016D5F RID: 93535 RVA: 0x006E59CC File Offset: 0x006E3DCC
	private void ChangeSkillAttribute()
	{
		if (this.skillIDs != null)
		{
			for (int i = 0; i < this.skillIDs.Count; i++)
			{
				BeSkill skill = this.owner.GetSkill(this.skillIDs[i]);
				if (skill != null)
				{
					this.changeOneSkillAttr(skill);
				}
			}
		}
	}

	// Token: 0x06016D60 RID: 93536 RVA: 0x006E5A28 File Offset: 0x006E3E28
	private void ChangeAllSkillAttribute()
	{
		Dictionary<int, BeSkill> skills = this.owner.GetSkills();
		foreach (BeSkill beSkill in skills.Values)
		{
			if (beSkill != null)
			{
				this.changeOneSkillAttr(beSkill);
			}
		}
	}

	// Token: 0x06016D61 RID: 93537 RVA: 0x006E5A98 File Offset: 0x006E3E98
	private void changeOneSkillAttr(BeSkill skill)
	{
		int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.buffData.skill_mpCostReduceRate, this.level, true);
		if (valueFromUnionCell != 0)
		{
			skill.mpCostReduceRate += valueFromUnionCell;
		}
		valueFromUnionCell = TableManager.GetValueFromUnionCell(this.buffData.skill_cdReduceRate, this.level, true);
		if (valueFromUnionCell != 0)
		{
			skill.cdReduceRate += valueFromUnionCell;
		}
		valueFromUnionCell = TableManager.GetValueFromUnionCell(this.buffData.skill_cdReduceValue, this.level, true);
		if (valueFromUnionCell != 0)
		{
			skill.cdReduceValue += valueFromUnionCell;
		}
		valueFromUnionCell = TableManager.GetValueFromUnionCell(this.buffData.skill_chargeReduceRate, this.level, true);
		if (valueFromUnionCell != 0)
		{
			skill.chargeReduceRate += valueFromUnionCell;
		}
		valueFromUnionCell = TableManager.GetValueFromUnionCell(this.buffData.skill_speedAddFactor, this.level, true);
		if (valueFromUnionCell != 0)
		{
			skill.speedAddRate += valueFromUnionCell;
		}
		valueFromUnionCell = TableManager.GetValueFromUnionCell(this.buffData.skill_hitRateAdd, this.level, true);
		if (valueFromUnionCell != 0)
		{
			skill.hitRateAdd += valueFromUnionCell;
		}
		valueFromUnionCell = TableManager.GetValueFromUnionCell(this.buffData.skill_criticalHitRateAdd, this.level, true);
		if (valueFromUnionCell != 0)
		{
			skill.criticalHitRateAdd += valueFromUnionCell;
		}
		valueFromUnionCell = TableManager.GetValueFromUnionCell(this.buffData.skill_attackAddRate, this.level, true);
		if (valueFromUnionCell != 0)
		{
			skill.attackAddRate += valueFromUnionCell;
		}
		valueFromUnionCell = TableManager.GetValueFromUnionCell(this.buffData.skill_hardAddRate, this.level, true);
		if (valueFromUnionCell != 0)
		{
			skill.hardAddRate += valueFromUnionCell;
		}
		int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(this.buffData.level, this.level, true);
		if (valueFromUnionCell2 != 0)
		{
			int num = skill.level;
			skill.level += valueFromUnionCell2;
			if (this.m_AddSkillLevel == null)
			{
				this.m_AddSkillLevel = new Dictionary<int, int>();
			}
			if (!this.m_AddSkillLevel.ContainsKey(skill.skillID))
			{
				this.m_AddSkillLevel.Add(skill.skillID, skill.level - num);
			}
			else
			{
				this.m_AddSkillLevel[skill.skillID] = skill.level - num;
			}
		}
		int valueFromUnionCell3 = TableManager.GetValueFromUnionCell(this.buffData.skill_attackAdd, this.level, true);
		if (valueFromUnionCell3 != 0)
		{
			skill.attackAdd += valueFromUnionCell3;
		}
		int valueFromUnionCell4 = TableManager.GetValueFromUnionCell(this.buffData.skill_attackAddFix, this.level, true);
		if (valueFromUnionCell4 != 0)
		{
			skill.attackAddFix += valueFromUnionCell4;
		}
	}

	// Token: 0x06016D62 RID: 93538 RVA: 0x006E5DC4 File Offset: 0x006E41C4
	private void RestoreSkillAttribute()
	{
		if (this.skillIDs != null)
		{
			for (int i = 0; i < this.skillIDs.Count; i++)
			{
				BeSkill skill = this.owner.GetSkill(this.skillIDs[i]);
				if (skill != null)
				{
					this.RestoreOneSkillAttribute(skill);
				}
			}
		}
	}

	// Token: 0x06016D63 RID: 93539 RVA: 0x006E5E20 File Offset: 0x006E4220
	private void RestoreAllSkillAttribute()
	{
		Dictionary<int, BeSkill> skills = this.owner.GetSkills();
		foreach (BeSkill beSkill in skills.Values)
		{
			if (beSkill != null)
			{
				this.RestoreOneSkillAttribute(beSkill);
			}
		}
	}

	// Token: 0x06016D64 RID: 93540 RVA: 0x006E5E90 File Offset: 0x006E4290
	private void RestoreOneSkillAttribute(BeSkill skill)
	{
		int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.buffData.skill_mpCostReduceRate, this.level, true);
		if (valueFromUnionCell != 0)
		{
			skill.mpCostReduceRate -= valueFromUnionCell;
		}
		valueFromUnionCell = TableManager.GetValueFromUnionCell(this.buffData.skill_cdReduceRate, this.level, true);
		if (valueFromUnionCell != 0)
		{
			skill.cdReduceRate -= valueFromUnionCell;
		}
		valueFromUnionCell = TableManager.GetValueFromUnionCell(this.buffData.skill_cdReduceValue, this.level, true);
		if (valueFromUnionCell != 0)
		{
			skill.cdReduceValue -= valueFromUnionCell;
		}
		valueFromUnionCell = TableManager.GetValueFromUnionCell(this.buffData.skill_chargeReduceRate, this.level, true);
		if (valueFromUnionCell != 0)
		{
			skill.chargeReduceRate -= valueFromUnionCell;
		}
		valueFromUnionCell = TableManager.GetValueFromUnionCell(this.buffData.skill_speedAddFactor, this.level, true);
		if (valueFromUnionCell != 0)
		{
			skill.speedAddRate -= valueFromUnionCell;
		}
		valueFromUnionCell = TableManager.GetValueFromUnionCell(this.buffData.skill_hitRateAdd, this.level, true);
		if (valueFromUnionCell != 0)
		{
			skill.hitRateAdd -= valueFromUnionCell;
		}
		valueFromUnionCell = TableManager.GetValueFromUnionCell(this.buffData.skill_criticalHitRateAdd, this.level, true);
		if (valueFromUnionCell != 0)
		{
			skill.criticalHitRateAdd -= valueFromUnionCell;
		}
		valueFromUnionCell = TableManager.GetValueFromUnionCell(this.buffData.skill_attackAddRate, this.level, true);
		if (valueFromUnionCell != 0)
		{
			skill.attackAddRate -= valueFromUnionCell;
		}
		valueFromUnionCell = TableManager.GetValueFromUnionCell(this.buffData.skill_hardAddRate, this.level, true);
		if (valueFromUnionCell != 0)
		{
			skill.hardAddRate -= valueFromUnionCell;
		}
		int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(this.buffData.level, this.level, true);
		if (valueFromUnionCell2 != 0)
		{
			if (this.m_AddSkillLevel == null)
			{
				this.m_AddSkillLevel = new Dictionary<int, int>();
			}
			if (this.m_AddSkillLevel.ContainsKey(skill.skillID))
			{
				skill.level -= this.m_AddSkillLevel[skill.skillID];
				this.m_AddSkillLevel[skill.skillID] = 0;
			}
		}
		int valueFromUnionCell3 = TableManager.GetValueFromUnionCell(this.buffData.skill_attackAdd, this.level, true);
		if (valueFromUnionCell3 != 0)
		{
			skill.attackAdd -= valueFromUnionCell3;
		}
		int valueFromUnionCell4 = TableManager.GetValueFromUnionCell(this.buffData.skill_attackAddFix, this.level, true);
		if (valueFromUnionCell4 != 0)
		{
			skill.attackAddFix -= valueFromUnionCell4;
		}
	}

	// Token: 0x06016D65 RID: 93541 RVA: 0x006E61A0 File Offset: 0x006E45A0
	public void DoUseMechanism()
	{
		for (int i = 0; i < this.buffData.MechanismID.Count; i++)
		{
			int num = this.buffData.MechanismID[i];
			if (num > 0)
			{
				BeMechanism item = this.owner.AddMechanism(num, this.level, MechanismSourceType.NONE, this, 0);
				this.mechanismList.Add(item);
			}
		}
	}

	// Token: 0x06016D66 RID: 93542 RVA: 0x006E6210 File Offset: 0x006E4610
	public void RemoveMechanism()
	{
		for (int i = 0; i < this.mechanismList.Count; i++)
		{
			BeMechanism mechanism = this.mechanismList[i];
			this.owner.RemoveMechanism(mechanism);
		}
	}

	// Token: 0x06016D67 RID: 93543 RVA: 0x006E6252 File Offset: 0x006E4652
	public List<BeMechanism> GetMechanismList()
	{
		return this.mechanismList;
	}

	// Token: 0x06016D68 RID: 93544 RVA: 0x006E625C File Offset: 0x006E465C
	public void DoUseSkill()
	{
		for (int i = 0; i < this.buffData.UseSkillIDs.Count; i++)
		{
			int num = this.buffData.UseSkillIDs[i];
			if (num > 0 && this.owner.CanUseSkill(num))
			{
				this.owner.UseSkill(num, true);
			}
		}
	}

	// Token: 0x06016D69 RID: 93545 RVA: 0x006E62C4 File Offset: 0x006E46C4
	public void DoTriggerOtherBuffInfo()
	{
		if (this.buffData != null)
		{
			for (int i = 0; i < this.buffData.TriggerBuffInfoIDs.Count; i++)
			{
				int buffInfoID = this.buffData.TriggerBuffInfoIDs[i];
				BuffInfoData buffInfoData = new BuffInfoData(buffInfoID, this.level, 0);
				if (buffInfoData.data != null)
				{
					if (buffInfoData.data.BuffLevel.valueType != UnionCellType.union_fix && buffInfoData.data.BuffLevel.valueType != UnionCellType.union_helper)
					{
						buffInfoData.level = TableManager.GetValueFromUnionCell(buffInfoData.data.BuffLevel, this.level, true);
						buffInfoData.abnormalLevel = buffInfoData.level;
					}
					else if (TableManager.GetValueFromUnionCell(buffInfoData.data.BuffLevel, this.level, true) == 0)
					{
						buffInfoData.level = this.level;
						buffInfoData.abnormalLevel = buffInfoData.level;
					}
					if (buffInfoData.condition <= BuffCondition.NONE)
					{
						this.owner.buffController.TriggerBuffInfo(buffInfoData, null, null);
					}
					else
					{
						this.owner.buffController.AddTriggerBuff(buffInfoData);
					}
				}
			}
		}
	}

	// Token: 0x06016D6A RID: 93546 RVA: 0x006E6404 File Offset: 0x006E4804
	public void DoBuffDispel()
	{
		if (this.buffData != null)
		{
			this.owner.buffController.DispelBuff((BuffWorkType)this.buffData.DispelBuffType, int.MaxValue);
		}
	}

	// Token: 0x06016D6B RID: 93547 RVA: 0x006E6434 File Offset: 0x006E4834
	public void DoSummon()
	{
		if (this.buffData != null)
		{
			int[] array = new int[]
			{
				this.buffData.summon_num
			};
			this.owner.TriggerEvent(BeEventType.onChangeSummonNum, new object[]
			{
				-1,
				this.buffID,
				array
			});
			int summonNum = array[0];
			int[] array2 = new int[]
			{
				this.buffData.summon_numLimit
			};
			this.owner.TriggerEvent(BeEventType.onChangeSummonNumLimit, new object[]
			{
				-1,
				this.buffID,
				array2
			});
			int numLimit = array2[0];
			this.owner.DoSummon(this.buffData.summon_monsterID, TableManager.GetValueFromUnionCell(this.buffData.summon_monsterLevel, this.level, true), (EffectTable.eSummonPosType)this.buffData.summon_posType, this.buffData.summon_posType2, summonNum, numLimit, 0, 0, 0, this.buffData.summon_relation > 0, 0, this.buffData.summon_existTime, null, (SummonDisplayType)this.buffData.summon_display, null, true);
		}
	}

	// Token: 0x06016D6C RID: 93548 RVA: 0x006E6556 File Offset: 0x006E4956
	public void ResetDuration(int d)
	{
		this.timeAcc = 0;
		this.duration = d;
		this.buffEffect.ResetDuration(d);
	}

	// Token: 0x06016D6D RID: 93549 RVA: 0x006E6578 File Offset: 0x006E4978
	public void DoGenEntity()
	{
		if (this.buffData != null)
		{
			for (int i = 0; i < this.buffData.summon_entity.Count; i++)
			{
				int num = this.buffData.summon_entity[i];
				if (num > 0)
				{
					this.owner.AddEntity(num, this.owner.GetPosition(), 1, 0);
				}
			}
		}
	}

	// Token: 0x06016D6E RID: 93550 RVA: 0x006E65E4 File Offset: 0x006E49E4
	public void DoDuplicate()
	{
		if (this.buffData != null && this.buffData.duplicate_percent > 0)
		{
			int num = this.buffData.duplicate_max;
			if (num > 0)
			{
				num++;
			}
			this.owner.CurrentBeScene.DuplicateMonster(this.owner, new VFactor((long)this.buffData.duplicate_percent, (long)GlobalLogic.VALUE_1000), num);
		}
	}

	// Token: 0x06016D6F RID: 93551 RVA: 0x006E6654 File Offset: 0x006E4A54
	public void RefreshDuration(int d)
	{
		int[] array = new int[]
		{
			d
		};
		this.owner.TriggerEvent(BeEventType.onBuffRefresh, new object[]
		{
			this.buffID,
			array
		});
		this.duration = array[0];
		this.timeAcc = 0;
	}

	// Token: 0x06016D70 RID: 93552 RVA: 0x006E66A9 File Offset: 0x006E4AA9
	public void CopyRunTime(BeBuff curBuff)
	{
		if (curBuff == null)
		{
			return;
		}
		this.timeAcc = curBuff.runTime;
	}

	// Token: 0x06016D71 RID: 93553 RVA: 0x006E66C0 File Offset: 0x006E4AC0
	public void OverlayDamage(int damage, int duration = 0)
	{
		int abnromalDamage = this.GetAbnromalDamage(damage, duration);
		this.overlayCount++;
		this.totalDamage += abnromalDamage;
		this.ForceDoWork();
	}

	// Token: 0x06016D72 RID: 93554 RVA: 0x006E66F8 File Offset: 0x006E4AF8
	public void DoWork()
	{
		this.ShowEffect();
		this.ShowBuffEffectName();
		if (this.buffData != null && this.buffData.IsQuickPressSupport == 1)
		{
			this.StartQuickPress();
		}
		this.ChangeTargetState();
		this.ChangeTargetAbility();
		this.ChangeTargetAction();
		if (this.buffType >= BuffType.ATTRIBUTE_CHANGE)
		{
			this.ChangeAttribute();
			this.ChangeAIAttribute();
		}
		else if (this.buffType == BuffType.ATTRIBUTE_ADD)
		{
			this.DoAttributeAdd();
		}
		else if (this.buffType == BuffType.SKILL_BUFF)
		{
			this.ChangeSkillAttribute();
		}
		else if (this.buffType == BuffType.ALL_SKILL_BUFF)
		{
			this.ChangeAllSkillAttribute();
		}
		else if (this.buffType == BuffType.SUMMON)
		{
			this.DoSummon();
			this.DoGenEntity();
			this.DoDuplicate();
		}
		else if (this.buffType == BuffType.BUFF_DISPEL)
		{
			this.DoBuffDispel();
		}
		else if (this.buffType == BuffType.TRIGGER_BUFFINFO)
		{
			this.DoTriggerOtherBuffInfo();
		}
		else if (this.buffType == BuffType.USE_SKILL)
		{
			this.DoUseSkill();
		}
		else if (this.buffType == BuffType.USE_MECHANISM)
		{
			this.DoUseMechanism();
		}
	}

	// Token: 0x06016D73 RID: 93555 RVA: 0x006E6828 File Offset: 0x006E4C28
	public virtual void DoWorkForInterval()
	{
		if (!this.owner.IsDead())
		{
			this.attackCount++;
			if (this.buffType == BuffType.ATTRIBUTE_ADD)
			{
				this.DoAttributeAdd();
				this.buffEffect.ShowHurtEffect();
			}
			else if (this.buffType == BuffType.SUMMON)
			{
				this.DoSummon();
				this.DoGenEntity();
				this.DoDuplicate();
			}
			else if (this.buffType == BuffType.TRIGGER_BUFFINFO)
			{
				this.DoTriggerOtherBuffInfo();
			}
			else if (this.buffWorkType == BuffWorkType.DEBUFF && this.buffData.Overlay != 5 && !this.owner.IsDead())
			{
				if (this.totalDamage == -1 && this.buffAttack > 0)
				{
					this.totalDamage = this.GetAbnromalDamage(this.buffAttack, this.duration);
				}
				this.DoBuffAttack(this.totalDamage);
			}
			if (this.attackCount >= this.totalAttackCount)
			{
				this.Finish();
			}
		}
	}

	// Token: 0x06016D74 RID: 93556 RVA: 0x006E6940 File Offset: 0x006E4D40
	public void Update(int deltaTime)
	{
		if (this.m_EventManager != null)
		{
			this.m_EventManager.Update();
		}
		if (this.state.IsRunning())
		{
			this.timeAcc += deltaTime;
			if (this.timeType == BuffTimeType.INTERVAL)
			{
				this.UpdateForInterval(deltaTime);
			}
			if (this.timeAcc > this.duration)
			{
				this.Finish();
				return;
			}
			this.OnUpdate(deltaTime);
		}
	}

	// Token: 0x06016D75 RID: 93557 RVA: 0x006E69B8 File Offset: 0x006E4DB8
	public float GetProcess()
	{
		return (float)this.timeAcc / (float)this.duration;
	}

	// Token: 0x06016D76 RID: 93558 RVA: 0x006E69D0 File Offset: 0x006E4DD0
	public void UpdateForInterval(int deltaTime)
	{
		this.intervalAcc += deltaTime;
		if (this.timeInterval < this.intervalAcc)
		{
			this.intervalAcc -= this.timeInterval;
			this.DoWorkForInterval();
		}
	}

	// Token: 0x06016D77 RID: 93559 RVA: 0x006E6A1F File Offset: 0x006E4E1F
	public int GetLeftTime()
	{
		if (this.duration == -1)
		{
			return -1;
		}
		return Mathf.Max(0, this.duration - this.timeAcc);
	}

	// Token: 0x06016D78 RID: 93560 RVA: 0x006E6A4C File Offset: 0x006E4E4C
	public void ForceDoWork()
	{
		this.intervalAcc = 0;
		if (this.buffData.StateChange != null && !BeUtility.HaveBuffState(this.buffData.StateChange, BeBuffStateType.FLASH))
		{
			this.DoWorkForInterval();
		}
	}

	// Token: 0x06016D79 RID: 93561 RVA: 0x006E6A84 File Offset: 0x006E4E84
	public void Finish()
	{
		this.TriggerEvent(BeEventType.onBuffFinish, new object[]
		{
			this.buffID,
			this.owner
		});
		if (this.owner != null)
		{
			this.owner.TriggerEvent(BeEventType.onBuffFinish, new object[]
			{
				this.buffID,
				this.owner
			});
		}
		this.Cancel();
	}

	// Token: 0x06016D7A RID: 93562 RVA: 0x006E6AF8 File Offset: 0x006E4EF8
	public void Cancel()
	{
		if (this.state.IsDead())
		{
			return;
		}
		this.state.SetDead();
		this.RemoveEffect();
		this.RemoveBuffEffectName();
		if (this.buffData.IsQuickPressSupport == 1)
		{
			this.StopQuickPress();
		}
		this.RestoreTargetAbility();
		this.RestoreTargetState();
		this.RestoreTargetAction();
		if (this.buffType >= BuffType.ATTRIBUTE_CHANGE)
		{
			this.RestoreAttribute();
			this.RestoreAIAttribute();
		}
		if (this.owner != null && this.isShowSpell)
		{
			this.owner.StopSpellBar(eDungeonCharactorBar.Buff, true);
			this.owner.RemoveStateBar();
		}
		if (this.buffType == BuffType.SKILL_BUFF)
		{
			this.RestoreSkillAttribute();
		}
		if (this.buffType == BuffType.ALL_SKILL_BUFF)
		{
			this.RestoreAllSkillAttribute();
		}
		if (this.buffType == BuffType.USE_MECHANISM)
		{
			this.RemoveMechanism();
		}
		this.OnFinish();
		if (this.buffID == 25)
		{
			this.owner.EndGrap();
		}
		if (this.owner != null)
		{
			this.owner.TriggerEvent(BeEventType.onRemoveBuff, new object[]
			{
				this.buffID,
				this
			});
		}
		if (this.owner.CurrentBeScene != null)
		{
			this.owner.CurrentBeScene.TriggerEventNew(BeEventSceneType.onRemoveBuff, new EventParam
			{
				m_Obj = this,
				m_Obj2 = this.owner
			});
		}
		if (this.buffData.ExitRemoveTrigger == 1 && this.buffData.TriggerBuffInfoIDs.Count > 0)
		{
			for (int i = 0; i < this.buffData.TriggerBuffInfoIDs.Count; i++)
			{
				this.owner.buffController.RemoveTriggerBuff(this.buffData.TriggerBuffInfoIDs[i]);
			}
		}
		if (this.rebornHandle != null)
		{
			this.rebornHandle.Remove();
			this.rebornHandle = null;
		}
		this.DeInit();
		if (this.owner != null)
		{
			this.owner.TriggerEvent(BeEventType.onBuffCancel, new object[]
			{
				this.buffID
			});
		}
	}

	// Token: 0x06016D7B RID: 93563 RVA: 0x006E6D1F File Offset: 0x006E511F
	public bool CanRemove()
	{
		return this.state.IsDead();
	}

	// Token: 0x06016D7C RID: 93564 RVA: 0x006E6D2C File Offset: 0x006E512C
	public bool CanDispel()
	{
		return this.dispel;
	}

	// Token: 0x06016D7D RID: 93565 RVA: 0x006E6D34 File Offset: 0x006E5134
	public bool IsPassive()
	{
		return this.passive;
	}

	// Token: 0x06016D7E RID: 93566 RVA: 0x006E6D3C File Offset: 0x006E513C
	public void ReduceDuration(int value, bool isPercent = true)
	{
		int num = value;
		if (isPercent)
		{
			num = IntMath.Float2Int((float)this.duration * ((float)value / (float)GlobalLogic.VALUE_1000));
		}
		if (num > 0)
		{
			this.isReduceByQuickPress = true;
		}
		this.timeAcc += num;
	}

	// Token: 0x06016D7F RID: 93567 RVA: 0x006E6D8C File Offset: 0x006E518C
	public void StartQuickPress()
	{
		if (this.owner != null && this.owner.isMainActor)
		{
			BeActor owner = this.owner;
			owner.StartPressCount(BeActor.QuickPressType.BUFF, this);
		}
	}

	// Token: 0x06016D80 RID: 93568 RVA: 0x006E6DC4 File Offset: 0x006E51C4
	public void StopQuickPress()
	{
		if (this.owner != null && this.owner.isMainActor)
		{
			BeActor owner = this.owner;
			owner.EndPressCount();
		}
	}

	// Token: 0x06016D81 RID: 93569 RVA: 0x006E6DF9 File Offset: 0x006E51F9
	public void ShowEffect()
	{
		if (this.buffEffect != null)
		{
			this.buffEffect.ShowEffect(this.owner);
		}
	}

	// Token: 0x06016D82 RID: 93570 RVA: 0x006E6E18 File Offset: 0x006E5218
	public void ShowBuffEffectName()
	{
		if (this.owner != null && this.owner.m_pkGeActor != null && this.buffData != null && !this.owner.m_pkGeActor.hpBarBuffEffectNameList.Contains(this.buffData.HpBarName))
		{
			this.owner.m_pkGeActor.hpBarBuffEffectNameList.Add(this.buffData.HpBarName);
		}
	}

	// Token: 0x06016D83 RID: 93571 RVA: 0x006E6E90 File Offset: 0x006E5290
	public void RemoveBuffEffectName()
	{
		if (this.owner != null && this.owner.m_pkGeActor != null && this.buffData != null && this.owner.m_pkGeActor.hpBarBuffEffectNameList.Contains(this.buffData.HpBarName))
		{
			this.owner.m_pkGeActor.hpBarBuffEffectNameList.Remove(this.buffData.HpBarName);
		}
	}

	// Token: 0x06016D84 RID: 93572 RVA: 0x006E6F09 File Offset: 0x006E5309
	public void HideEffect()
	{
		if (this.buffEffect != null)
		{
			this.buffEffect.HideEffect();
		}
	}

	// Token: 0x06016D85 RID: 93573 RVA: 0x006E6F24 File Offset: 0x006E5324
	public void ResetEffectElapsedTime()
	{
		if (this.buffEffect == null)
		{
			return;
		}
		if (this.buffEffect.geEffect != null && !this.buffEffect.geEffect.IsDead())
		{
			this.buffEffect.ResetElapsedTime();
		}
		else
		{
			this.buffEffect.ShowEffect(this.owner);
		}
	}

	// Token: 0x06016D86 RID: 93574 RVA: 0x006E6F83 File Offset: 0x006E5383
	public void RemoveEffect()
	{
		if (this.buffEffect != null)
		{
			this.buffEffect.RemoveEffect(this.owner);
		}
	}

	// Token: 0x06016D87 RID: 93575 RVA: 0x006E6FA1 File Offset: 0x006E53A1
	public bool ShowHPNumber()
	{
		return this.buffEffect == null || this.buffEffect.showHPNumber;
	}

	// Token: 0x06016D88 RID: 93576 RVA: 0x006E6FBC File Offset: 0x006E53BC
	public BeEventHandle RegisterEvent(BeEventType eventKey, BeEventHandle.Del del)
	{
		BeEventHandle result = null;
		if (this.eventProcessor != null)
		{
			result = this.eventProcessor.AddEventHandler((int)eventKey, del);
		}
		return result;
	}

	// Token: 0x06016D89 RID: 93577 RVA: 0x006E6FE5 File Offset: 0x006E53E5
	public void RemoveEvent(BeEventHandle handler)
	{
		if (this.eventProcessor != null)
		{
			handler.Remove();
		}
	}

	// Token: 0x06016D8A RID: 93578 RVA: 0x006E6FF8 File Offset: 0x006E53F8
	public void TriggerEvent(BeEventType eventKey, object[] args = null)
	{
		if (this.eventProcessor != null)
		{
			this.eventProcessor.HandleEvent((int)eventKey, args);
		}
	}

	// Token: 0x06016D8B RID: 93579 RVA: 0x006E7012 File Offset: 0x006E5412
	public BeEvent.BeEventHandleNew RegisterEventNew(BeEventType eventType, BeEvent.BeEventHandleNew.Function function)
	{
		if (this.m_EventManager == null)
		{
			this.m_EventManager = new BeEventManager();
		}
		return this.m_EventManager.RegisterEvent((int)eventType, function);
	}

	// Token: 0x06016D8C RID: 93580 RVA: 0x006E7037 File Offset: 0x006E5437
	public void TriggerEventNew(BeEventType eventType, BeEvent.BeEventParam eventParam)
	{
		if (this.m_EventManager == null)
		{
			return;
		}
		this.m_EventManager.TriggerEvent((int)eventType, eventParam);
	}

	// Token: 0x06016D8D RID: 93581 RVA: 0x006E7052 File Offset: 0x006E5452
	public EventParam TriggerEventNew(BeEventType eventType, EventParam param = default(EventParam))
	{
		if (this.m_EventManager == null)
		{
			return param;
		}
		return this.m_EventManager.TriggerEvent((int)eventType, param);
	}

	// Token: 0x06016D8E RID: 93582 RVA: 0x006E706E File Offset: 0x006E546E
	public void ClearEventAllNew()
	{
		if (this.m_EventManager == null)
		{
			return;
		}
		this.m_EventManager.ClearAll();
	}

	// Token: 0x06016D8F RID: 93583 RVA: 0x006E7087 File Offset: 0x006E5487
	public GeEffectEx GetEffectEx()
	{
		if (this.buffEffect == null)
		{
			return null;
		}
		return this.buffEffect.geEffect;
	}

	// Token: 0x06016D90 RID: 93584 RVA: 0x006E70A4 File Offset: 0x006E54A4
	protected void DoBuffAttack(int damage)
	{
		bool forceBuffHurt = false;
		if (this.buffType >= BuffType.BLEEDING && this.buffType <= BuffType.POISON && this.owner.buffController.HasBuffByID(43) != null)
		{
			forceBuffHurt = true;
		}
		if (this.owner.buffController.IsAbnormalBuff(this.buffType) && damage <= 0)
		{
			return;
		}
		this.owner.TriggerEventNew(BeEventType.OnBuffDoHurt, new EventParam
		{
			m_Int = damage,
			m_Obj = this.owner
		});
		this.owner.DoHurt(damage, null, HitTextType.BUFF_HURT, this.releaser, HitTextType.NORMAL, forceBuffHurt);
		this.buffEffect.ShowHurtEffect();
		if (this.owner.IsDead() && !this.owner.IsInPassiveState())
		{
			this.owner.DoDead(false);
		}
	}

	// Token: 0x06016D91 RID: 93585 RVA: 0x006E7184 File Offset: 0x006E5584
	public virtual int GetAloneAbnormalDamage()
	{
		return this.GetAbnromalDamage(this.buffAttack, this.duration);
	}

	// Token: 0x06016D92 RID: 93586 RVA: 0x006E71A4 File Offset: 0x006E55A4
	protected void ChangeResistMaic(int value)
	{
		BattleData battleData = this.owner.GetEntityData().battleData;
		battleData.resistMagic += value;
		this.owner.GetEntityData().ChangeMaxHpByResist();
		if (this.owner.m_pkGeActor != null && this.owner.m_pkGeActor.mCurHpBar != null)
		{
			this.owner.m_pkGeActor.mCurHpBar.InitResistMagic(this.owner.attribute.GetResistMagic(), this.owner);
		}
		this.DoSyncHPBar(this.owner);
		if (this.owner.IsMonster())
		{
			return;
		}
		if (this.owner.CurrentBeScene == null)
		{
			return;
		}
		List<BeActor> list = ListPool<BeActor>.Get();
		this.owner.CurrentBeScene.FindSummonMonster(list, this.owner);
		for (int i = 0; i < list.Count; i++)
		{
			BattleData battleData2 = list[i].GetEntityData().battleData;
			battleData2.resistMagic += value;
			list[i].GetEntityData().ChangeMaxHpByResist();
			this.owner.CurrentBeScene.AdjustSummonMonsterAttribute(this.owner, list[i]);
			this.DoSyncHPBar(list[i]);
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x06016D93 RID: 93587 RVA: 0x006E7304 File Offset: 0x006E5704
	public void OnOwnerReborn()
	{
		if (this.duration == 2147483647)
		{
			this.ShowEffect();
		}
	}

	// Token: 0x06016D94 RID: 93588 RVA: 0x006E7321 File Offset: 0x006E5721
	public virtual void OnStart()
	{
	}

	// Token: 0x06016D95 RID: 93589 RVA: 0x006E7323 File Offset: 0x006E5723
	public virtual void OnInit()
	{
	}

	// Token: 0x06016D96 RID: 93590 RVA: 0x006E7325 File Offset: 0x006E5725
	public virtual void OnUpdate(int delta)
	{
	}

	// Token: 0x06016D97 RID: 93591 RVA: 0x006E7327 File Offset: 0x006E5727
	public virtual void OnFinish()
	{
	}

	// Token: 0x04010515 RID: 66837
	public string name;

	// Token: 0x04010516 RID: 66838
	public CrypticInt32 level;

	// Token: 0x04010517 RID: 66839
	public CrypticInt32 abnormalLevel;

	// Token: 0x04010518 RID: 66840
	public int buffID;

	// Token: 0x0401051B RID: 66843
	public BuffType buffType;

	// Token: 0x0401051C RID: 66844
	public BuffWorkType buffWorkType;

	// Token: 0x0401051D RID: 66845
	public BuffTimeType timeType;

	// Token: 0x0401051E RID: 66846
	public BuffOverlayType overlayType;

	// Token: 0x0401051F RID: 66847
	public bool isShowSpell;

	// Token: 0x04010520 RID: 66848
	private bool dispel;

	// Token: 0x04010521 RID: 66849
	public bool passive;

	// Token: 0x04010522 RID: 66850
	public List<int> damageList = new List<int>();

	// Token: 0x04010523 RID: 66851
	private int totalDamage = -1;

	// Token: 0x04010524 RID: 66852
	public CrypticInt32 buffAttack;

	// Token: 0x04010525 RID: 66853
	public int totalAttackCount;

	// Token: 0x04010526 RID: 66854
	private int attackCount;

	// Token: 0x04010527 RID: 66855
	public CrypticInt32 timeInterval;

	// Token: 0x04010528 RID: 66856
	public CrypticInt32 duration;

	// Token: 0x04010529 RID: 66857
	private bool buffEffectAni;

	// Token: 0x0401052A RID: 66858
	public BuffTable buffData;

	// Token: 0x0401052B RID: 66859
	protected BuffEffect buffEffect;

	// Token: 0x0401052C RID: 66860
	public int overlayCount = 1;

	// Token: 0x0401052D RID: 66861
	public BDStat state = new BDStat();

	// Token: 0x0401052E RID: 66862
	private int timeAcc;

	// Token: 0x0401052F RID: 66863
	private int intervalAcc;

	// Token: 0x04010530 RID: 66864
	private bool addBuffInAir;

	// Token: 0x04010531 RID: 66865
	private bool addBuffFallGround;

	// Token: 0x04010532 RID: 66866
	private bool isReduceByQuickPress;

	// Token: 0x04010533 RID: 66867
	private bool m_NeedRestoreTargetAction;

	// Token: 0x04010534 RID: 66868
	protected int[] stateChanged = new int[30];

	// Token: 0x04010535 RID: 66869
	protected int stateChangedCount;

	// Token: 0x04010536 RID: 66870
	protected BeEventProcessor eventProcessor = new BeEventProcessor();

	// Token: 0x04010537 RID: 66871
	protected BeEventManager m_EventManager = new BeEventManager();

	// Token: 0x04010538 RID: 66872
	public List<int> skillIDs;

	// Token: 0x04010539 RID: 66873
	protected int[] valueChanged = new int[15];

	// Token: 0x0401053A RID: 66874
	protected List<BeMechanism> mechanismList = new List<BeMechanism>();

	// Token: 0x0401053B RID: 66875
	public AbnormalBuffData abnormalBuffData = default(AbnormalBuffData);

	// Token: 0x0401053C RID: 66876
	protected BeEventHandle rebornHandle;

	// Token: 0x0401053D RID: 66877
	public int buffInfoId;

	// Token: 0x0401053E RID: 66878
	public int skillId;

	// Token: 0x0401053F RID: 66879
	private Dictionary<int, int> m_AddSkillLevel;

	// Token: 0x04010540 RID: 66880
	private static BeBuff._propertyRate[] _propertyRateName = new BeBuff._propertyRate[]
	{
		new BeBuff._propertyRate("atkAddRate", "baseAtk", true, AttributeType.baseAtk),
		new BeBuff._propertyRate("intAddRate", "baseInt", true, AttributeType.baseInt),
		new BeBuff._propertyRate("independenceAddRate", "baseIndependence", true, AttributeType.baseIndependence),
		new BeBuff._propertyRate("staAddRate", "sta", false, AttributeType.sta),
		new BeBuff._propertyRate("sprAddRate", "spr", false, AttributeType.spr),
		new BeBuff._propertyRate("maxHpAddRate", "_maxHp", true, AttributeType.maxHp),
		new BeBuff._propertyRate("maxMpAddRate", "_maxMp", true, AttributeType.maxMp),
		new BeBuff._propertyRate("ignoreDefAttackAddRate", "ignoreDefAttackAdd", true, AttributeType.ignoreDefAttackAdd),
		new BeBuff._propertyRate("ignoreDefMagicAttackAddRate", "ignoreDefMagicAttackAdd", true, AttributeType.ignoreDefMagicAttackAdd)
	};

	// Token: 0x04010541 RID: 66881
	private static string[] skillAtriibuteNames = new string[]
	{
		"skill_mpCostReduceRate",
		"skill_cdReduceRate",
		"skill_speedAddFactor",
		"skill_hitRateAdd",
		"skill_criticalHitRateAdd",
		"skill_attackAddRate",
		"skill_hardAddRate"
	};

	// Token: 0x02004154 RID: 16724
	private struct _propertyRate
	{
		// Token: 0x06016D9A RID: 93594 RVA: 0x006E74B1 File Offset: 0x006E58B1
		public _propertyRate(string bn, string bd, bool flag, AttributeType type)
		{
			this.buffName = bn;
			this.battleDataName = bd;
			this.isField = flag;
			this.at = type;
		}

		// Token: 0x04010542 RID: 66882
		public string buffName;

		// Token: 0x04010543 RID: 66883
		public string battleDataName;

		// Token: 0x04010544 RID: 66884
		public bool isField;

		// Token: 0x04010545 RID: 66885
		public AttributeType at;
	}
}
