using System;
using UnityEngine;

// Token: 0x02004451 RID: 17489
public class Skill1213 : BeSkill
{
	// Token: 0x0601846B RID: 99435 RVA: 0x0078EEF8 File Offset: 0x0078D2F8
	public Skill1213(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601846C RID: 99436 RVA: 0x0078EF78 File Offset: 0x0078D378
	public override void OnInit()
	{
		this.bornPos = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true), GlobalLogic.VALUE_1000);
		this.speed = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true), GlobalLogic.VALUE_1000);
		this.dis = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true), GlobalLogic.VALUE_1000);
		this.changePhase = TableManager.GetValueFromUnionCell(this.skillData.ValueD[0], base.level, true);
		this.mechanisID = TableManager.GetValueFromUnionCell(this.skillData.ValueE[0], base.level, true);
		this.smallResID = TableManager.GetValueFromUnionCell(this.skillData.ValueF[0], base.level, true);
	}

	// Token: 0x0601846D RID: 99437 RVA: 0x0078F078 File Offset: 0x0078D478
	public override void OnStart()
	{
		this.actor = null;
		base.OnStart();
		this.isBombEntityCreated = false;
		this.m_ChargeFlag = false;
		this.RemoveHandler();
		this.m_SummonHandle = base.owner.RegisterEvent(BeEventType.onSummon, delegate(object[] obj)
		{
			BeActor beActor = obj[0] as BeActor;
			if (beActor != null && beActor.GetEntityData() != null && beActor.GetEntityData().monsterID != this.monsterID)
			{
				return;
			}
			this.actor = beActor;
			if (this.actor == null)
			{
				return;
			}
			this.beDead = false;
			this.scale = 0;
			this.changeScale = true;
			this.recordScale = this.actor.GetScale();
			VInt3 position = base.owner.GetPosition();
			int x = (!base.owner.GetFace()) ? (position.x + this.bornPos.i) : (-this.bornPos.i + position.x);
			this.actor.SetPosition(new VInt3(x, position.y, this.actor.GetPosition().z), true, true, false);
			this.tmpSpeed = ((!base.owner.GetFace()) ? this.speed.i : (-this.speed.i));
			if (this.actor.m_iResID == this.smallResID)
			{
				this.SetCameraPause(true);
			}
			this.orginPos = base.owner.CurrentBeScene.currentGeScene.GetCamera().GetController().transform.localPosition;
			if (!BattleMain.IsModePvP(base.owner.battleType))
			{
				this.actor.buffController.TryAddBuff(25, -1, 1);
			}
			this.m_HitOtherHandle = this.actor.RegisterEvent(BeEventType.onHitOther, delegate(object[] args)
			{
				BeEntity beEntity = args[0] as BeEntity;
				if (beEntity != null && beEntity is BeObject)
				{
					this.SetMonsterDead();
				}
			});
			this.m_ActorDeadHandle = this.actor.RegisterEvent(BeEventType.onDead, delegate(object[] args)
			{
				if (this.isBombEntityCreated)
				{
					return;
				}
				this.CreateBoomEntity();
			});
		});
		this.m_ChargeHandle = base.owner.RegisterEvent(BeEventType.onPreSetSkillAction, delegate(object[] args)
		{
			int[] array = (int[])args[0];
			int num = array[0];
			if (num == 12134)
			{
				this.m_ChargeFlag = false;
			}
			else if (num == 121341)
			{
				this.m_ChargeFlag = true;
			}
		});
	}

	// Token: 0x0601846E RID: 99438 RVA: 0x0078F0E4 File Offset: 0x0078D4E4
	private void SetCameraPause(bool flag)
	{
		if (!base.owner.isLocalActor)
		{
			return;
		}
		base.owner.CurrentBeScene.currentGeScene.GetCamera().GetController().SetPause(flag);
	}

	// Token: 0x0601846F RID: 99439 RVA: 0x0078F117 File Offset: 0x0078D517
	private void SetCameraPos(Vector3 offset)
	{
		if (!base.owner.isLocalActor)
		{
			return;
		}
		base.owner.CurrentBeScene.currentGeScene.GetCamera().GetController().SetCameraPos(offset);
	}

	// Token: 0x06018470 RID: 99440 RVA: 0x0078F14C File Offset: 0x0078D54C
	public override void OnEnterPhase(int phase)
	{
		this.curFrame = phase;
		base.OnEnterPhase(phase);
		if (this.actor != null && base.owner != null && this.curFrame == this.changePhase)
		{
			this.actor.RemoveMechanism(this.mechanisID);
		}
	}

	// Token: 0x06018471 RID: 99441 RVA: 0x0078F1A0 File Offset: 0x0078D5A0
	public override void OnUpdate(int iDeltime)
	{
		base.OnUpdate(iDeltime);
		if (this.actor != null && base.owner != null && !this.beDead)
		{
			if (this.changeScale)
			{
				this.scale += 100;
				this.actor.SetScale(this.recordScale + this.scale);
			}
			if (this.curFrame == this.changePhase)
			{
				this.changeScale = false;
				this.actor.ResetMoveCmd();
				this.actor.SetMoveSpeedX(this.tmpSpeed);
				this.orginPos.x = this.orginPos.x + this.tmpSpeed.scalar * (float)iDeltime / 1000f;
				if (BattleMain.IsModePvP(base.owner.battleType))
				{
					this.actor.buffController.TryAddBuff(25, -1, 1);
				}
			}
			this.SetCameraPos(new Vector3(this.orginPos.x, this.orginPos.y, this.orginPos.z));
			if (Mathf.Abs(this.actor.GetPosition().x - base.owner.GetPosition().x) > this.dis || (base.owner.CurrentBeScene.IsInBlockPlayer(this.actor.GetPosition()) && this.curFrame == this.changePhase))
			{
				this.SetMonsterDead();
			}
		}
	}

	// Token: 0x06018472 RID: 99442 RVA: 0x0078F33C File Offset: 0x0078D73C
	private void SetMonsterDead()
	{
		if (this.actor != null && base.owner != null && !this.beDead)
		{
			this.actor.SetScale(this.recordScale);
			this.beDead = true;
			this.actor.DoDead(false);
			base.owner.delayCaller.DelayCall(500, delegate
			{
				if (!base.isFinish() && !base.owner.IsDead())
				{
					base.owner.Locomote(new BeStateData(0, 0), true);
				}
			}, 0, 0, false);
			base.owner.delayCaller.DelayCall(1300, delegate
			{
				this.SetCameraPause(false);
			}, 0, 0, false);
		}
	}

	// Token: 0x06018473 RID: 99443 RVA: 0x0078F3D8 File Offset: 0x0078D7D8
	public override void OnCancel()
	{
		this.SetMonsterDead();
		this.changeScale = false;
	}

	// Token: 0x06018474 RID: 99444 RVA: 0x0078F3E7 File Offset: 0x0078D7E7
	public override void OnFinish()
	{
		this.changeScale = false;
	}

	// Token: 0x06018475 RID: 99445 RVA: 0x0078F3F0 File Offset: 0x0078D7F0
	protected void CreateBoomEntity()
	{
		if (this.actor != null)
		{
			this.isBombEntityCreated = true;
			int entityID = (!this.m_ChargeFlag) ? this.m_BoomEntityId[0] : this.m_BoomEntityId[1];
			base.owner.AddEntity(entityID, this.actor.GetPosition(), base.level, 0);
		}
	}

	// Token: 0x06018476 RID: 99446 RVA: 0x0078F450 File Offset: 0x0078D850
	private void RemoveHandler()
	{
		if (this.m_SummonHandle != null)
		{
			this.m_SummonHandle.Remove();
			this.m_SummonHandle = null;
		}
		if (this.m_ChargeHandle != null)
		{
			this.m_ChargeHandle.Remove();
		}
		if (this.m_ActorDeadHandle != null)
		{
			this.m_ActorDeadHandle.Remove();
		}
		if (this.m_HitOtherHandle != null)
		{
			this.m_HitOtherHandle.Remove();
		}
	}

	// Token: 0x0401183C RID: 71740
	private BeActor actor;

	// Token: 0x0401183D RID: 71741
	private VInt bornPos = 0;

	// Token: 0x0401183E RID: 71742
	private VInt speed;

	// Token: 0x0401183F RID: 71743
	private VInt dis = 0;

	// Token: 0x04011840 RID: 71744
	private int changePhase;

	// Token: 0x04011841 RID: 71745
	private int mechanisID;

	// Token: 0x04011842 RID: 71746
	private int smallResID;

	// Token: 0x04011843 RID: 71747
	private VInt tmpSpeed;

	// Token: 0x04011844 RID: 71748
	private bool beDead;

	// Token: 0x04011845 RID: 71749
	private int curFrame;

	// Token: 0x04011846 RID: 71750
	private Vector3 orginPos = Vector3.zero;

	// Token: 0x04011847 RID: 71751
	private int monsterID = 2150031;

	// Token: 0x04011848 RID: 71752
	protected BeEventHandle m_SummonHandle;

	// Token: 0x04011849 RID: 71753
	protected bool m_ChargeFlag;

	// Token: 0x0401184A RID: 71754
	protected int[] m_BoomEntityId = new int[]
	{
		60271,
		60272
	};

	// Token: 0x0401184B RID: 71755
	protected BeEventHandle m_ChargeHandle;

	// Token: 0x0401184C RID: 71756
	protected BeEventHandle m_ActorDeadHandle;

	// Token: 0x0401184D RID: 71757
	protected BeEventHandle m_HitOtherHandle;

	// Token: 0x0401184E RID: 71758
	protected bool isBombEntityCreated;

	// Token: 0x0401184F RID: 71759
	private VInt recordScale = 0;

	// Token: 0x04011850 RID: 71760
	private VInt scale = 0;

	// Token: 0x04011851 RID: 71761
	private bool changeScale = true;
}
