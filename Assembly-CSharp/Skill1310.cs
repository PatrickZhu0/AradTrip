using System;
using GameClient;

// Token: 0x02004456 RID: 17494
public class Skill1310 : BeSkill
{
	// Token: 0x060184C3 RID: 99523 RVA: 0x00790FF4 File Offset: 0x0078F3F4
	public Skill1310(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060184C4 RID: 99524 RVA: 0x00791084 File Offset: 0x0078F484
	public override void OnInit()
	{
		this.m_ClickTimeAccPve = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.m_ClickTimeAccPvp = TableManager.GetValueFromUnionCell(this.skillData.ValueA[1], base.level, true);
		this.mMaxBulletPve = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
		this.mMaxBulletPvp = TableManager.GetValueFromUnionCell(this.skillData.ValueB[1], base.level, true);
		this.m_HurtIdPve = TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true);
		this.m_HurtIdPvp = TableManager.GetValueFromUnionCell(this.skillData.ValueC[1], base.level, true);
		this.m_PvpMoveXOffset = TableManager.GetValueFromUnionCell(this.skillData.ValueD[0], base.level, true);
	}

	// Token: 0x060184C5 RID: 99525 RVA: 0x00791188 File Offset: 0x0078F588
	public override void OnStart()
	{
		this.mCurMaxBullet = ((!BattleMain.IsModePvP(base.battleType)) ? this.mMaxBulletPve : this.mMaxBulletPvp);
		this.m_ClickTimeAcc = ((!BattleMain.IsModePvP(base.battleType)) ? this.m_ClickTimeAccPve : this.m_ClickTimeAccPvp);
		this.m_CurrClickTimeAcc = 0;
		this.mCurBullet = 0;
		this.mAddTime = 0;
		this.mEnterNextPhaseFlag = false;
		this.RemoveHandle();
		this.m_AddBuffHandle = base.owner.RegisterEvent(BeEventType.onAddBuff, delegate(object[] args)
		{
			BeBuff beBuff = (BeBuff)args[0];
			if (beBuff != null && beBuff.buffID == this.m_FlagBatiBuffId)
			{
				this.InitLogicData();
				this.InitEffectData();
			}
			else if (beBuff != null && beBuff.buffID == this.m_FlagGunMoveBuffId)
			{
				this.AttackPhaseStart();
			}
		});
		for (int i = 0; i < base.owner.MechanismList.Count; i++)
		{
			Mechanism124 mechanism = base.owner.MechanismList[i] as Mechanism124;
			if (mechanism != null)
			{
				this.mCurMaxBullet += mechanism.bulletNum;
				this.mAddTime += mechanism.addTime;
			}
		}
	}

	// Token: 0x060184C6 RID: 99526 RVA: 0x00791288 File Offset: 0x0078F688
	public override void OnUpdate(int iDeltime)
	{
		if (!this.m_CreateAttackFlag || this.m_SkillSniperEffect == null)
		{
			return;
		}
		this.UpdateAttackCD(iDeltime);
		this.CheckAttack();
		this.m_SkillSniperEffect.UpdateSkillTime(iDeltime);
	}

	// Token: 0x060184C7 RID: 99527 RVA: 0x007912BA File Offset: 0x0078F6BA
	public override void OnEnterPhase(int phase)
	{
		base.OnEnterPhase(phase);
		if (phase == 2)
		{
			this.AttackPhaseEnd();
		}
	}

	// Token: 0x060184C8 RID: 99528 RVA: 0x007912D0 File Offset: 0x0078F6D0
	protected void UpdateAttackCD(int iDeltaTime)
	{
		if (!this.m_CreateAttackFlag)
		{
			return;
		}
		if (this.mCurBullet >= this.mCurMaxBullet)
		{
			return;
		}
		if (this.m_CurrClickTimeAcc > 0)
		{
			this.m_CurrClickTimeAcc -= iDeltaTime;
		}
		else
		{
			this.m_SkillSniperEffect.SetAttackButtonEnable(true);
			this.m_CurrClickTimeAcc = 0;
		}
		this.m_SkillSniperEffect.RefreshCd(this.m_ClickTimeAcc, this.m_CurrClickTimeAcc);
	}

	// Token: 0x060184C9 RID: 99529 RVA: 0x00791344 File Offset: 0x0078F744
	protected void CheckAttack()
	{
		if (!this.m_CreateAttackFlag)
		{
			return;
		}
		if (this.mCurBullet >= this.mCurMaxBullet)
		{
			return;
		}
		if (base.owner.GetCurrentBtnState() == ButtonState.PRESS && this.m_CurrClickTimeAcc == 0)
		{
			this.CreateAttackFrameCommand();
		}
	}

	// Token: 0x060184CA RID: 99530 RVA: 0x00791391 File Offset: 0x0078F791
	public override void OnCancel()
	{
		this.AttackPhaseEnd();
		this.CloseFrame();
	}

	// Token: 0x060184CB RID: 99531 RVA: 0x0079139F File Offset: 0x0078F79F
	public override void OnFinish()
	{
		this.CloseFrame();
	}

	// Token: 0x060184CC RID: 99532 RVA: 0x007913A7 File Offset: 0x0078F7A7
	protected void InitLogicData()
	{
		this.m_PassDoorHandle = base.owner.RegisterEvent(BeEventType.onPassedDoor, delegate(object[] args)
		{
			this.LocomoteToIdle();
		});
		this.mDeadTowerEnterNextLayerHandle = base.owner.RegisterEvent(BeEventType.onDeadTowerEnterNextLayer, delegate(object[] args)
		{
			base.Cancel();
		});
	}

	// Token: 0x060184CD RID: 99533 RVA: 0x007913E6 File Offset: 0x0078F7E6
	protected void InitEffectData()
	{
		this.m_SkillSniperEffect = new SkillSniperEffect(this, base.owner);
		this.m_SkillSniperEffect.m_SkillTotalTime += this.mAddTime;
		this.m_SkillSniperEffect.InitFrame();
	}

	// Token: 0x060184CE RID: 99534 RVA: 0x0079141D File Offset: 0x0078F81D
	protected void AttackPhaseStart()
	{
		if (this.m_SkillSniperEffect == null)
		{
			return;
		}
		this.m_CreateAttackFlag = true;
		this.m_SkillSniperEffect.AttackPhaseStartEffect();
	}

	// Token: 0x060184CF RID: 99535 RVA: 0x0079143D File Offset: 0x0078F83D
	protected void CreateAttackFrameCommand()
	{
		this.mCurBullet++;
		this.m_SkillSniperEffect.CreateAttackFrame(this.mCurBullet, this.mCurMaxBullet);
		this.m_CurrClickTimeAcc = this.m_ClickTimeAcc;
	}

	// Token: 0x060184D0 RID: 99536 RVA: 0x00791470 File Offset: 0x0078F870
	public void DoRealAttack(int bulletNum, int pid)
	{
		if (bulletNum > this.mCurMaxBullet)
		{
			return;
		}
		if (base.owner.CurrentBeScene != null)
		{
			BeEntity entityByPID = base.owner.CurrentBeScene.GetEntityByPID(pid);
			if (entityByPID != null && entityByPID is BeActor)
			{
				VInt3 position = entityByPID.GetPosition();
				position.z += VInt.one.i;
				int hurtid = (!BattleMain.IsModePvP(base.battleType)) ? this.m_HurtIdPve : this.m_HurtIdPvp;
				base.owner._onHurtEntity(entityByPID, position, hurtid);
			}
		}
		if (pid == 0)
		{
			base.owner.buffController.TryAddBuff(131001, null, false, null, 0);
			if (this.m_SkillSniperEffect != null)
			{
				this.m_SkillSniperEffect.ShowOtherAttackEffect();
			}
		}
		if (bulletNum >= this.mCurMaxBullet && !this.mEnterNextPhaseFlag)
		{
			this.mEnterNextPhaseFlag = true;
			((BeActorStateGraph)base.owner.GetStateGraph()).ExecuteNextPhaseSkill();
		}
	}

	// Token: 0x060184D1 RID: 99537 RVA: 0x00791578 File Offset: 0x0078F978
	protected void AttackPhaseEnd()
	{
		this.m_CreateAttackFlag = false;
		this.RemoveHandle();
		if (this.m_SkillSniperEffect != null)
		{
			this.m_SkillSniperEffect.AttackPhaseEnd();
		}
	}

	// Token: 0x060184D2 RID: 99538 RVA: 0x0079159D File Offset: 0x0078F99D
	public void DoSyncSight(int x, int z)
	{
		if (this.m_SkillSniperEffect == null)
		{
			return;
		}
		this.m_SkillSniperEffect.DoSyncSight(x, z);
	}

	// Token: 0x060184D3 RID: 99539 RVA: 0x007915B8 File Offset: 0x0078F9B8
	protected void CloseFrame()
	{
		if (this.m_SkillSniperEffect == null)
		{
			return;
		}
		this.m_SkillSniperEffect.CloseFrame();
	}

	// Token: 0x060184D4 RID: 99540 RVA: 0x007915D4 File Offset: 0x0078F9D4
	protected void RemoveHandle()
	{
		if (this.m_PassDoorHandle != null)
		{
			this.m_PassDoorHandle.Remove();
			this.m_PassDoorHandle = null;
		}
		if (this.m_AddBuffHandle != null)
		{
			this.m_AddBuffHandle.Remove();
			this.m_AddBuffHandle = null;
		}
		if (this.mDeadTowerEnterNextLayerHandle != null)
		{
			this.mDeadTowerEnterNextLayerHandle.Remove();
			this.mDeadTowerEnterNextLayerHandle = null;
		}
	}

	// Token: 0x060184D5 RID: 99541 RVA: 0x00791638 File Offset: 0x0078FA38
	protected void LocomoteToIdle()
	{
		base.owner.Locomote(new BeStateData(0, 0), true);
	}

	// Token: 0x04011885 RID: 71813
	protected int m_ClickTimeAccPve = 800;

	// Token: 0x04011886 RID: 71814
	protected int m_ClickTimeAccPvp = 1500;

	// Token: 0x04011887 RID: 71815
	protected int mMaxBulletPve = 5;

	// Token: 0x04011888 RID: 71816
	protected int mMaxBulletPvp = 5;

	// Token: 0x04011889 RID: 71817
	protected int m_HurtIdPve = 13100;

	// Token: 0x0401188A RID: 71818
	protected int m_HurtIdPvp = 13101;

	// Token: 0x0401188B RID: 71819
	public int m_PvpMoveXOffset = 500;

	// Token: 0x0401188C RID: 71820
	protected int m_CurrClickTimeAcc;

	// Token: 0x0401188D RID: 71821
	protected bool m_CreateAttackFlag;

	// Token: 0x0401188E RID: 71822
	protected int mCurBullet;

	// Token: 0x0401188F RID: 71823
	public int mCurMaxBullet = 5;

	// Token: 0x04011890 RID: 71824
	protected int m_ClickTimeAcc = 800;

	// Token: 0x04011891 RID: 71825
	protected int m_FlagBatiBuffId = 131001;

	// Token: 0x04011892 RID: 71826
	protected int m_FlagGunMoveBuffId = 131003;

	// Token: 0x04011893 RID: 71827
	protected int m_ShanbaiBuffInfoId = 131001;

	// Token: 0x04011894 RID: 71828
	protected bool mEnterNextPhaseFlag;

	// Token: 0x04011895 RID: 71829
	protected int mAddTime;

	// Token: 0x04011896 RID: 71830
	protected SkillSniperEffect m_SkillSniperEffect;

	// Token: 0x04011897 RID: 71831
	protected BeEventHandle m_PassDoorHandle;

	// Token: 0x04011898 RID: 71832
	protected BeEventHandle m_AddBuffHandle;

	// Token: 0x04011899 RID: 71833
	protected BeEventHandle mDeadTowerEnterNextLayerHandle;
}
