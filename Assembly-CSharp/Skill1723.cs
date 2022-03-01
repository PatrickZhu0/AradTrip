using System;
using System.Collections.Generic;
using GameClient;
using GamePool;

// Token: 0x0200446D RID: 17517
public class Skill1723 : BeSkill
{
	// Token: 0x0601859F RID: 99743 RVA: 0x007960E8 File Offset: 0x007944E8
	public Skill1723(int sid, int skillLevel) : base(sid, skillLevel)
	{
		this.mFilter = new BeAbilityEnable
		{
			abType = 7
		};
	}

	// Token: 0x060185A0 RID: 99744 RVA: 0x00796184 File Offset: 0x00794584
	public override void OnInit()
	{
		this.firsthurtId = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.suckTimeFactor = new VFactor((long)TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true), (long)GlobalLogic.VALUE_1000);
		this.explosiveHurtId = TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true);
		this.mAddDamage.Clear();
		if (BattleMain.IsModePvP(base.battleType))
		{
			for (int i = 1; i <= 5; i++)
			{
				int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.skillData.ValueF[1], i, true);
				this.mAddDamage.Add(VFactor.NewVFactor(valueFromUnionCell, GlobalLogic.VALUE_1000));
			}
		}
		else
		{
			for (int j = 1; j <= 5; j++)
			{
				int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(this.skillData.ValueF[0], j, true);
				this.mAddDamage.Add(VFactor.NewVFactor(valueFromUnionCell2, GlobalLogic.VALUE_1000));
			}
		}
		this.InitValue();
	}

	// Token: 0x060185A1 RID: 99745 RVA: 0x007962B0 File Offset: 0x007946B0
	private void InitValue()
	{
		this.mSpecialMonsterAddDamage = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.skillData.ValueE[0], base.level, true), GlobalLogic.VALUE_1000);
		this.mSearchEnemyRadius = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueG[0], base.level, true), GlobalLogic.VALUE_1000);
		this.baseAttackRange = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueD[0], base.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x060185A2 RID: 99746 RVA: 0x00796344 File Offset: 0x00794744
	public override void OnPostInit()
	{
		this.InitValue();
	}

	// Token: 0x060185A3 RID: 99747 RVA: 0x0079634C File Offset: 0x0079474C
	public override bool CanUseSkill()
	{
		return base.owner != null && base.CanUseSkill() && base.owner.buffController != null && !this.HaveBuff() && base.owner.buffController.HasBuffByID(171901) != null && base.owner.buffController.HasBuffByID(171101) != null;
	}

	// Token: 0x060185A4 RID: 99748 RVA: 0x007963CA File Offset: 0x007947CA
	private bool HaveBuff()
	{
		return base.owner.buffController.HasBuffByID(370500) != null || base.owner.buffController.HasBuffByID(370501) != null;
	}

	// Token: 0x060185A5 RID: 99749 RVA: 0x00796404 File Offset: 0x00794804
	private void onSummonMonster(object[] args)
	{
		BeActor beActor = args[0] as BeActor;
		if (beActor != null && base.owner.GetCastSkillID() == this.skillID)
		{
			this.summonMonsterPid = beActor.GetPID();
		}
	}

	// Token: 0x060185A6 RID: 99750 RVA: 0x00796444 File Offset: 0x00794844
	public override void OnStart()
	{
		this._SetRuneManager();
		this._haveShowBuDongMingWangState = false;
		this.CleanUp();
		this.isStartSuck = true;
		this.suckDurtime = 0;
		this.summonHandle = base.owner.RegisterEvent(BeEventType.onSummon, new BeEventHandle.Del(this.onSummonMonster));
		this.curFrameHandle = base.owner.RegisterEvent(BeEventType.onSkillCurFrame, delegate(object[] args)
		{
			string a = (string)args[0];
			if (a == this.skillFrame)
			{
				this.frameFlag = true;
				if (base.button != null)
				{
					base.button.AddEffect(ETCButton.eEffectType.onContinue, false);
				}
			}
			else if (a == this.attackEndFrame)
			{
				this.isStartExplosive = true;
			}
			else if (a == this._cancelSkillFlag && this._needUseBuDongMingWang)
			{
				base.owner.Locomote(new BeStateData(0, 0), false);
			}
		});
		this.doAttackhandle = base.owner.RegisterEvent(BeEventType.onAfterFinalDamageNew, delegate(object[] args)
		{
			BeActor beActor = args[1] as BeActor;
			int num = (int)args[2];
			if (num == this.firsthurtId)
			{
				if (base.owner.CurrentBeScene == null)
				{
					return;
				}
				this.isStartSuck = false;
				if (beActor != null)
				{
					this.isHitOther = true;
				}
			}
			else if (num == this.explosiveHurtId)
			{
				if (this.suckEnemyCount <= 0)
				{
					return;
				}
				int num2 = (int)args[2];
				if (num2 != this.explosiveHurtId)
				{
					return;
				}
				int[] array = (int[])args[0];
				int num3 = array[0];
				int num4 = this.suckEnemyCount - 1;
				VFactor f = VFactor.zero;
				if (num4 >= this.mAddDamage.Count)
				{
					f = this.mAddDamage[this.mAddDamage.Count - 1];
				}
				else
				{
					f = this.mAddDamage[num4];
				}
				int num5 = num3 * f;
				if (!BattleMain.IsModePvP(base.battleType) && beActor != null && beActor.GetEntityData() != null && (beActor.GetEntityData().type == 2 || beActor.GetEntityData().type == 3 || beActor.GetEntityData().type == 5 || beActor.GetEntityData().type == 6))
				{
					num5 += num3 * this.mSpecialMonsterAddDamage;
				}
				num3 += num5;
				array[0] = num3;
			}
		});
		if (!BattleMain.IsModePvP(base.battleType))
		{
			this._useSkillHandle = base.owner.RegisterEventNew(BeEventType.onWillUseSkill, new BeEvent.BeEventHandleNew.Function(this._OnWillUseSkill));
		}
	}

	// Token: 0x060185A7 RID: 99751 RVA: 0x00796504 File Offset: 0x00794904
	private void _SetRuneManager()
	{
		if (base.owner != null)
		{
			Skill1710 skill = base.owner.GetSkill(1710) as Skill1710;
			if (skill != null)
			{
				this._runeManager = skill.runeManager;
			}
		}
	}

	// Token: 0x060185A8 RID: 99752 RVA: 0x00796544 File Offset: 0x00794944
	private void _OnWillUseSkill(BeEvent.BeEventParam param)
	{
		if (BattleMain.IsModePvP(base.battleType))
		{
			return;
		}
		if (!this.frameFlag)
		{
			return;
		}
		if (this._needUseBuDongMingWang)
		{
			return;
		}
		if (param.m_Int != this._buDongMingWangSkillId)
		{
			return;
		}
		if (this._runeManager != null && this._runeManager.GetRuneCount() <= 0)
		{
			return;
		}
		param.m_Int = -1;
		this.OnClickAgain();
		this._needUseBuDongMingWang = true;
	}

	// Token: 0x060185A9 RID: 99753 RVA: 0x007965C0 File Offset: 0x007949C0
	public override void OnUpdate(int iDeltime)
	{
		this._CheckBuDongMingWangButtonState();
		if (this.isStartSuck)
		{
			this.suckDurtime += iDeltime;
		}
		if (this.isStartExplosive && this.isHitOther)
		{
			List<BeActor> list = ListPool<BeActor>.Get();
			base.owner.CurrentBeScene.FindTargets(list, base.owner, this.mSearchEnemyRadius, false, this.mFilter);
			this.suckEnemyCount = list.Count;
			ListPool<BeActor>.Release(list);
			VInt3 position = base.owner.GetPosition();
			position.x = ((!base.owner.GetFace()) ? (position.x + this.explosiveOffset) : (position.x - this.explosiveOffset));
			list = ListPool<BeActor>.Get();
			base.owner.CurrentBeScene.FindActorInRange(list, position, this.baseAttackRange + this.suckDurtime * this.suckTimeFactor, (base.owner.GetCamp() != 0) ? 0 : 1, 0);
			for (int i = 0; i < list.Count; i++)
			{
				BeActor beActor = list[i];
				if (beActor != null && !beActor.IsDeadOrRemoved())
				{
					base.owner._onHurtEntity(beActor, beActor.GetPosition(), this.explosiveHurtId);
				}
			}
			if (base.owner.CurrentBeScene.currentGeScene != null)
			{
				base.owner.m_pkGeActor.CreateEffect(this.effectPath, "[actor]Orign", 0f, new Vec3(0f, 0f, 0f), 1f, 1f, false, false, EffectTimeType.SYNC_ANIMATION, false);
			}
			ListPool<BeActor>.Release(list);
			this.isStartExplosive = false;
			this.isHitOther = false;
		}
	}

	// Token: 0x060185AA RID: 99754 RVA: 0x00796789 File Offset: 0x00794B89
	public override void OnFinish()
	{
		this._UseBuDongMingWang();
		this.CleanUp();
	}

	// Token: 0x060185AB RID: 99755 RVA: 0x00796798 File Offset: 0x00794B98
	public override void OnEnterPhase(int phase)
	{
		base.OnEnterPhase(phase);
		if (phase == 3)
		{
			this.isStartSuck = false;
			List<BeActor> list = ListPool<BeActor>.Get();
			base.owner.CurrentBeScene.FindActorById(list, 93000032);
			for (int i = 0; i < list.Count; i++)
			{
				BeActor beActor = list[i];
				if (beActor != null)
				{
					BeEntity owner = list[i].GetOwner();
					if (owner != null && owner.GetPID() == base.owner.GetPID())
					{
						beActor.DoDead(false);
						break;
					}
				}
			}
			ListPool<BeActor>.Release(list);
		}
	}

	// Token: 0x060185AC RID: 99756 RVA: 0x0079683C File Offset: 0x00794C3C
	public override void OnClickAgain()
	{
		if (this.curPhase == 2 && this.frameFlag)
		{
			if (base.button != null)
			{
				base.button.RemoveEffect(ETCButton.eEffectType.onContinue, false);
			}
			((BeActorStateGraph)base.owner.GetStateGraph()).ExecuteNextPhaseSkill();
			this.frameFlag = false;
			this.skillButtonState = BeSkill.SkillState.NORMAL;
		}
	}

	// Token: 0x060185AD RID: 99757 RVA: 0x007968A1 File Offset: 0x00794CA1
	public override void OnCancel()
	{
		this._UseBuDongMingWang();
		this.CleanUp();
	}

	// Token: 0x060185AE RID: 99758 RVA: 0x007968B0 File Offset: 0x00794CB0
	private void CleanUp()
	{
		this.frameFlag = false;
		this.isStartSuck = false;
		this.isStartExplosive = false;
		this.suckDurtime = 0;
		this.suckEnemyCount = 0;
		this.isHitOther = false;
		this._needUseBuDongMingWang = false;
		if (base.owner.CurrentBeScene != null)
		{
			BeEntity entityByPID = base.owner.CurrentBeScene.GetEntityByPID(this.summonMonsterPid);
			if (entityByPID != null && !entityByPID.IsDeadOrRemoved())
			{
				entityByPID.DoDead(false);
			}
		}
		this.summonMonsterPid = 0;
		if (this.summonHandle != null)
		{
			this.summonHandle.Remove();
			this.summonHandle = null;
		}
		if (this.curFrameHandle != null)
		{
			this.curFrameHandle.Remove();
			this.curFrameHandle = null;
		}
		if (this.doAttackhandle != null)
		{
			this.doAttackhandle.Remove();
			this.doAttackhandle = null;
		}
		if (this._useSkillHandle != null)
		{
			this._useSkillHandle.Remove();
			this._useSkillHandle = null;
		}
		if (this._canCancelSkillHandle != null)
		{
			this._canCancelSkillHandle.Remove();
			this._canCancelSkillHandle = null;
		}
		this.skillButtonState = BeSkill.SkillState.NORMAL;
		this._ShowBuDongMingWangButton(false);
		if (base.button != null)
		{
			base.button.RemoveEffect(ETCButton.eEffectType.onContinue, false);
		}
	}

	// Token: 0x060185AF RID: 99759 RVA: 0x007969F4 File Offset: 0x00794DF4
	private void _CheckBuDongMingWangButtonState()
	{
		if (BattleMain.IsModePvP(base.battleType))
		{
			return;
		}
		if (this._haveShowBuDongMingWangState)
		{
			return;
		}
		if (!this.frameFlag)
		{
			return;
		}
		if (this._runeManager != null && this._runeManager.GetRuneCount() <= 0)
		{
			return;
		}
		this._haveShowBuDongMingWangState = true;
		this._ShowBuDongMingWangButton(true);
	}

	// Token: 0x060185B0 RID: 99760 RVA: 0x00796A58 File Offset: 0x00794E58
	private void _ShowBuDongMingWangButton(bool flag)
	{
		if (BattleMain.IsModePvP(base.battleType))
		{
			return;
		}
		BeSkill skill = base.owner.GetSkill(this._buDongMingWangSkillId);
		if (skill == null)
		{
			return;
		}
		skill.ForceShowButtonImage = flag;
	}

	// Token: 0x060185B1 RID: 99761 RVA: 0x00796A98 File Offset: 0x00794E98
	private void _UseBuDongMingWang()
	{
		if (BattleMain.IsModePvP(base.battleType))
		{
			return;
		}
		if (!this._needUseBuDongMingWang)
		{
			return;
		}
		base.owner.delayCaller.DelayCall(30, new DelayCaller.Del(this._RealUseSkill), 0, 0, false);
	}

	// Token: 0x060185B2 RID: 99762 RVA: 0x00796AE4 File Offset: 0x00794EE4
	private void _RealUseSkill()
	{
		base.owner.UseSkill(this._buDongMingWangSkillId, false);
	}

	// Token: 0x04011933 RID: 71987
	protected BeEventHandle doAttackhandle;

	// Token: 0x04011934 RID: 71988
	protected BeEventHandle curFrameHandle;

	// Token: 0x04011935 RID: 71989
	protected BeEventHandle summonHandle;

	// Token: 0x04011936 RID: 71990
	protected int suckDurtime;

	// Token: 0x04011937 RID: 71991
	protected VFactor suckTimeFactor = VFactor.zero;

	// Token: 0x04011938 RID: 71992
	protected bool isStartSuck;

	// Token: 0x04011939 RID: 71993
	protected bool frameFlag;

	// Token: 0x0401193A RID: 71994
	protected int firsthurtId;

	// Token: 0x0401193B RID: 71995
	protected int explosiveHurtId;

	// Token: 0x0401193C RID: 71996
	protected VInt baseAttackRange = 15000;

	// Token: 0x0401193D RID: 71997
	protected int specialMonsterTypeBuffID;

	// Token: 0x0401193E RID: 71998
	private string effectPath = "Effects/Hero_Axiuluo/wushuangbo/prefeb/Eff_wushuangbo_xuligongji_02";

	// Token: 0x0401193F RID: 71999
	private string skillFrame = "1723";

	// Token: 0x04011940 RID: 72000
	private string attackEndFrame = "attackEnd";

	// Token: 0x04011941 RID: 72001
	protected int explosiveOffset;

	// Token: 0x04011942 RID: 72002
	protected bool isStartExplosive;

	// Token: 0x04011943 RID: 72003
	protected bool isSpecailAttack;

	// Token: 0x04011944 RID: 72004
	protected bool isHitOther;

	// Token: 0x04011945 RID: 72005
	protected int suckEnemyCount;

	// Token: 0x04011946 RID: 72006
	protected List<VFactor> mAddDamage = new List<VFactor>();

	// Token: 0x04011947 RID: 72007
	protected VFactor mSpecialMonsterAddDamage = VFactor.zero;

	// Token: 0x04011948 RID: 72008
	protected VInt mSearchEnemyRadius = VInt.zero;

	// Token: 0x04011949 RID: 72009
	protected BeAbilityEnable mFilter;

	// Token: 0x0401194A RID: 72010
	protected int summonMonsterPid;

	// Token: 0x0401194B RID: 72011
	private BeEvent.BeEventHandleNew _useSkillHandle;

	// Token: 0x0401194C RID: 72012
	private BeEvent.BeEventHandleNew _canCancelSkillHandle;

	// Token: 0x0401194D RID: 72013
	private bool _needUseBuDongMingWang;

	// Token: 0x0401194E RID: 72014
	private int _buDongMingWangSkillId = 1717;

	// Token: 0x0401194F RID: 72015
	private string _cancelSkillFlag = "CancelSkill";

	// Token: 0x04011950 RID: 72016
	private Mechanism22 _runeManager;

	// Token: 0x04011951 RID: 72017
	private bool _haveShowBuDongMingWangState;
}
