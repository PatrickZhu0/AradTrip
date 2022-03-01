using System;
using GameClient;

// Token: 0x020043B6 RID: 17334
public class Mechanism2122 : BeMechanism
{
	// Token: 0x060180A4 RID: 98468 RVA: 0x0077680F File Offset: 0x00774C0F
	public Mechanism2122(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060180A5 RID: 98469 RVA: 0x00776828 File Offset: 0x00774C28
	public override void OnInit()
	{
		this.m_BuffID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.m_RestoreTime = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.m_retreatTime = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.m_edgeDist = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true), GlobalLogic.VALUE_1000);
		this.m_skillID = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
	}

	// Token: 0x060180A6 RID: 98470 RVA: 0x00776908 File Offset: 0x00774D08
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onHPChange, new BeEventHandle.Del(this._onHPChange));
		this.SceneHandleNewA = base.owner.CurrentBeScene.RegisterEventNew(BeEventSceneType.onRaceGameEnd, new BeEvent.BeEventHandleNew.Function(this._onRaceGameEnd));
	}

	// Token: 0x060180A7 RID: 98471 RVA: 0x00776958 File Offset: 0x00774D58
	private void _onRaceGameEnd(BeEvent.BeEventParam param)
	{
		if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<RaceGameRepairFrame>(null))
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<RaceGameRepairFrame>(null, false);
		}
	}

	// Token: 0x060180A8 RID: 98472 RVA: 0x00776978 File Offset: 0x00774D78
	private void _onHPChange(object[] args)
	{
		if (base.owner.GetEntityData().GetHP() <= 0)
		{
			base.owner.GetEntityData().SetHP(1);
			base.owner.SetIsDead(false);
			base.owner.buffController.RemoveAllAbnormalBuff();
			base.owner.buffController.TryAddBuff(this.m_BuffID, null, false, null, 0);
			this.m_durTime = this.m_RestoreTime;
			if (base.owner.CurrentBeScene != null)
			{
				base.owner.CurrentBeScene.TriggerEventNew(BeEventSceneType.onEnterRepairStat, new EventParam
				{
					m_Obj = base.owner
				});
				if (base.owner.CurrentBeBattle != null && base.owner.CurrentBeBattle.dungeonManager != null && base.owner.CurrentBeBattle.dungeonManager.IsFinishFight())
				{
					return;
				}
				VInt vint = base.owner.CurrentBeScene.logicXSize.x - this.m_edgeDist;
				VInt3 position = base.owner.GetPosition();
				position.x = vint.i;
				BeMoveTo action = BeMoveTo.Create(base.owner, this.m_retreatTime, base.owner.GetPosition(), position, true, null, false);
				base.owner.actionManager.RunAction(action);
				if (base.owner.isLocalActor)
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<RaceGameRepairFrame>(FrameLayer.Middle, this.m_RestoreTime, string.Empty);
				}
			}
		}
	}

	// Token: 0x060180A9 RID: 98473 RVA: 0x00776B08 File Offset: 0x00774F08
	public override void OnUpdate(int deltaTime)
	{
		if (this.m_delaySpellSkill > 0)
		{
			this.m_delaySpellSkill -= deltaTime;
			if (this.m_delaySpellSkill <= 0)
			{
				base.owner.UseSkill(this.m_skillID, false);
			}
		}
		if (this.m_durTime <= 0)
		{
			return;
		}
		this.m_durTime -= deltaTime;
		if (this.m_durTime <= 0)
		{
			base.owner.GetEntityData().SetHP(base.owner.GetEntityData().GetMaxHP());
			if (base.owner.CurrentBeScene != null)
			{
				base.owner.CurrentBeScene.TriggerEventNew(BeEventSceneType.onLeaveRepairStat, new EventParam
				{
					m_Obj = base.owner
				});
			}
			if (base.owner.m_pkGeActor != null)
			{
				base.owner.m_pkGeActor.isSyncHPMP = true;
				base.owner.m_pkGeActor.SyncHPBar();
				base.owner.m_pkGeActor.isSyncHPMP = false;
			}
			this.m_delaySpellSkill = 500;
		}
	}

	// Token: 0x04011522 RID: 70946
	private int m_BuffID;

	// Token: 0x04011523 RID: 70947
	private int m_RestoreTime;

	// Token: 0x04011524 RID: 70948
	private int m_durTime;

	// Token: 0x04011525 RID: 70949
	private int m_retreatTime;

	// Token: 0x04011526 RID: 70950
	private VInt m_edgeDist = 0;

	// Token: 0x04011527 RID: 70951
	private int m_skillID;

	// Token: 0x04011528 RID: 70952
	private int m_delaySpellSkill;
}
