using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;

// Token: 0x020043E9 RID: 17385
public class Mechanism42 : BeMechanism
{
	// Token: 0x0601820B RID: 98827 RVA: 0x00780984 File Offset: 0x0077ED84
	public Mechanism42(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601820C RID: 98828 RVA: 0x007809F4 File Offset: 0x0077EDF4
	public sealed override void OnInit()
	{
		this.m_BeHitNumPve = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.m_BeHitNumPvp = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.m_ReplaceAttackId = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		for (int i = 0; i < this.data.ValueD.Count; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueD[i], this.level, true);
			this.m_BuffIdList.Add(valueFromUnionCell);
		}
		this.m_ReplaceSkillId = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		if (this.data.ValueF.Count > 0)
		{
			for (int j = 0; j < this.data.ValueF.Count; j++)
			{
				int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(this.data.ValueF[j], this.level, true);
				this.m_RemoveBuffList.Add(valueFromUnionCell2);
			}
		}
		if (this.data.ValueG.Count > 0)
		{
			for (int k = 0; k < this.data.ValueG.Count; k++)
			{
				int valueFromUnionCell3 = TableManager.GetValueFromUnionCell(this.data.ValueG[k], this.level, true);
				this.m_AddBuffInfoList.Add(valueFromUnionCell3);
			}
		}
		if (this.data.ValueH.Length > 0)
		{
			for (int l = 0; l < this.data.ValueH.Length - 1; l++)
			{
				this.targetSkill.Add(TableManager.GetValueFromUnionCell(this.data.ValueH[l], this.level, true));
			}
			this.m_SkillFinishProtectTime = TableManager.GetValueFromUnionCell(this.data.ValueH[this.data.ValueH.Length - 1], this.level, true);
		}
	}

	// Token: 0x0601820D RID: 98829 RVA: 0x00780C6C File Offset: 0x0077F06C
	public sealed override void OnStart()
	{
		this.m_HitNum = ((!BattleMain.IsModePvP(base.battleType)) ? this.m_BeHitNumPve : this.m_BeHitNumPvp);
		this.m_CurrentBeHitNum = 0;
		this.ReplaceAttackId();
		this.ReplaceSkill();
		if (this.m_HitNum != 0)
		{
			this.m_BeHitHandle = base.owner.RegisterEvent(BeEventType.onHit, delegate(object[] arg)
			{
				bool flag = true;
				if (arg.Length >= 5)
				{
					int id = (int)arg[4];
					EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(id, string.Empty, string.Empty);
					if (tableItem != null && tableItem.IsFriendDamage > 0)
					{
						flag = false;
					}
				}
				if (flag)
				{
					this.BeHit();
				}
			});
		}
		this.m_StateChange = base.owner.RegisterEvent(BeEventType.onStateChange, delegate(object[] arg)
		{
			ActionState actionState = (ActionState)arg[0];
			if (actionState == ActionState.AS_RUN && base.owner.IsRunning())
			{
				this.m_IsSkillFinishProtect = false;
				this.m_IsRunAddBuffState = true;
				this.m_CurrRunTimeAcc = 0;
			}
			else if (base.owner.CurrentBeBattle != null && !base.owner.CurrentBeBattle.FunctionIsOpen(BattleFlagType.CanYingRunBuffModify))
			{
				if (BattleMain.IsModePvP(base.owner.battleType))
				{
					this.RemoveRunBuffList();
				}
				else if ((actionState != ActionState.AS_CASTSKILL || !this.targetSkill.Contains(base.owner.m_iCurSkillID)) && (actionState != ActionState.AS_IDLE || !this.m_IsSkillFinishProtect))
				{
					this.RemoveRunBuffList();
				}
			}
			else
			{
				this.RemoveRunBuffList();
			}
		});
		if (base.owner.CurrentBeBattle != null && !base.owner.CurrentBeBattle.FunctionIsOpen(BattleFlagType.CanYingRunBuffModify) && !BattleMain.IsModePvP(base.owner.battleType))
		{
			this.m_SkillFinish = base.owner.RegisterEvent(BeEventType.onCastSkillFinish, delegate(object[] arg)
			{
				int item = (int)arg[0];
				if (this.targetSkill.Contains(item))
				{
					this.m_IsSkillFinishProtect = true;
					this.m_SkillFinishProtectTimeAcc = 0;
				}
			});
		}
	}

	// Token: 0x0601820E RID: 98830 RVA: 0x00780D58 File Offset: 0x0077F158
	private void RemoveRunBuffList()
	{
		this.m_IsRunAddBuffState = false;
		for (int i = 0; i < this.m_RemoveBuffList.Count; i++)
		{
			base.owner.buffController.RemoveBuff(this.m_RemoveBuffList[i], 0, 0);
		}
	}

	// Token: 0x0601820F RID: 98831 RVA: 0x00780DA8 File Offset: 0x0077F1A8
	public sealed override void OnUpdate(int deltaTime)
	{
		if (this.m_IsRunAddBuffState)
		{
			if (this.m_CurrRunTimeAcc >= this.m_MaxRunTimeAcc)
			{
				for (int i = 0; i < this.m_AddBuffInfoList.Count; i++)
				{
					base.owner.buffController.TryAddBuff(this.m_AddBuffInfoList[i], null, false, null, 0);
				}
				this.m_IsRunAddBuffState = false;
			}
			else
			{
				this.m_CurrRunTimeAcc += deltaTime;
			}
		}
		if (base.owner.CurrentBeBattle != null && !base.owner.CurrentBeBattle.FunctionIsOpen(BattleFlagType.CanYingRunBuffModify) && !BattleMain.IsModePvP(base.owner.battleType) && this.m_IsSkillFinishProtect)
		{
			this.m_SkillFinishProtectTimeAcc += deltaTime;
			if (this.m_SkillFinishProtectTimeAcc > this.m_SkillFinishProtectTime)
			{
				this.m_IsSkillFinishProtect = false;
				this.RemoveRunBuffList();
			}
		}
	}

	// Token: 0x06018210 RID: 98832 RVA: 0x00780E9B File Offset: 0x0077F29B
	protected void BeHit()
	{
		this.m_CurrentBeHitNum++;
		if (this.m_CurrentBeHitNum >= this.m_HitNum)
		{
			this.RemoveEffect();
		}
	}

	// Token: 0x06018211 RID: 98833 RVA: 0x00780EC4 File Offset: 0x0077F2C4
	protected void ReplaceAttackId()
	{
		if (BattleMain.IsModePvP(base.battleType))
		{
			this.m_AttackData = base.owner.AddReplaceAttackId(this.m_ReplaceAttackId, 1);
		}
		else
		{
			this.m_AttackData = base.owner.AddReplaceAttackId(this.m_ReplaceAttackId, 3);
		}
	}

	// Token: 0x06018212 RID: 98834 RVA: 0x00780F16 File Offset: 0x0077F316
	protected void RestoreAttackId()
	{
		base.owner.RemoveReplaceAttackId(this.m_AttackData);
	}

	// Token: 0x06018213 RID: 98835 RVA: 0x00780F29 File Offset: 0x0077F329
	protected void ReplaceSkill()
	{
		this.m_ReplaceSkillHandle = base.owner.RegisterEvent(BeEventType.onPreSetSkillAction, delegate(object[] args)
		{
			int[] array = (int[])args[0];
			int num = array[0];
			if (num == this.m_BackupSkillId)
			{
				array[0] = this.m_ReplaceSkillId;
			}
		});
	}

	// Token: 0x06018214 RID: 98836 RVA: 0x00780F4A File Offset: 0x0077F34A
	protected void RemoveSkillReplaceHandle()
	{
		if (this.m_ReplaceSkillHandle != null)
		{
			this.m_ReplaceSkillHandle.Remove();
		}
	}

	// Token: 0x06018215 RID: 98837 RVA: 0x00780F64 File Offset: 0x0077F364
	protected void RemoveEffect()
	{
		this.RestoreAttackId();
		this.RemoveSkillReplaceHandle();
		for (int i = 0; i < this.m_BuffIdList.Count; i++)
		{
			base.owner.buffController.RemoveBuff(this.m_BuffIdList[i], 0, 0);
		}
	}

	// Token: 0x06018216 RID: 98838 RVA: 0x00780FB8 File Offset: 0x0077F3B8
	public sealed override void OnFinish()
	{
		if (this.m_BeHitHandle != null)
		{
			this.m_BeHitHandle.Remove();
		}
		if (this.m_StateChange != null)
		{
			this.m_StateChange.Remove();
		}
		if (this.m_SkillFinish != null)
		{
			this.m_SkillFinish.Remove();
			this.m_SkillFinish = null;
		}
		this.RemoveEffect();
	}

	// Token: 0x04011662 RID: 71266
	protected int m_BeHitNumPve;

	// Token: 0x04011663 RID: 71267
	protected int m_BeHitNumPvp;

	// Token: 0x04011664 RID: 71268
	protected int m_ReplaceAttackId;

	// Token: 0x04011665 RID: 71269
	protected List<int> m_BuffIdList = new List<int>();

	// Token: 0x04011666 RID: 71270
	protected int m_ReplaceSkillId;

	// Token: 0x04011667 RID: 71271
	protected List<int> m_RemoveBuffList = new List<int>();

	// Token: 0x04011668 RID: 71272
	protected List<int> m_AddBuffInfoList = new List<int>();

	// Token: 0x04011669 RID: 71273
	protected BeEventHandle m_BeHitHandle;

	// Token: 0x0401166A RID: 71274
	protected BeEventHandle m_ReplaceSkillHandle;

	// Token: 0x0401166B RID: 71275
	protected int m_BackupSkillId = 1503;

	// Token: 0x0401166C RID: 71276
	protected BeActor.NormalAttack m_AttackData = default(BeActor.NormalAttack);

	// Token: 0x0401166D RID: 71277
	protected int m_CurrentBeHitNum;

	// Token: 0x0401166E RID: 71278
	protected int m_HitNum;

	// Token: 0x0401166F RID: 71279
	protected BeEventHandle m_StateChange;

	// Token: 0x04011670 RID: 71280
	protected BeEventHandle m_SkillFinish;

	// Token: 0x04011671 RID: 71281
	private bool m_IsSkillFinishProtect;

	// Token: 0x04011672 RID: 71282
	private int m_SkillFinishProtectTime = 100;

	// Token: 0x04011673 RID: 71283
	private int m_SkillFinishProtectTimeAcc;

	// Token: 0x04011674 RID: 71284
	protected bool m_IsRunAddBuffState;

	// Token: 0x04011675 RID: 71285
	protected int m_CurrRunTimeAcc;

	// Token: 0x04011676 RID: 71286
	protected int m_MaxRunTimeAcc = 300;

	// Token: 0x04011677 RID: 71287
	private HashSet<int> targetSkill = new HashSet<int>();
}
