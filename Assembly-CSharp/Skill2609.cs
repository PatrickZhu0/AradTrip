using System;
using UnityEngine;

// Token: 0x020044B1 RID: 17585
public class Skill2609 : BeSkill
{
	// Token: 0x06018751 RID: 100177 RVA: 0x007A1418 File Offset: 0x0079F818
	public Skill2609(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018752 RID: 100178 RVA: 0x007A14E0 File Offset: 0x0079F8E0
	public override void OnInit()
	{
		this.bornPos = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true), GlobalLogic.VALUE_1000);
		this.speed = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true), GlobalLogic.VALUE_1000);
		this.speedX = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueB[1], base.level, true), GlobalLogic.VALUE_1000);
		this.speedY = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueB[2], base.level, true), GlobalLogic.VALUE_1000);
		this.dis = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true), GlobalLogic.VALUE_1000);
		this.disX = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueC[1], base.level, true), GlobalLogic.VALUE_1000);
		this.changePhase = TableManager.GetValueFromUnionCell(this.skillData.ValueD[0], base.level, true);
		this.restoreCameraSec = TableManager.GetValueFromUnionCell(this.skillData.ValueD[1], base.level, true);
		this.mechanisID = TableManager.GetValueFromUnionCell(this.skillData.ValueE[0], base.level, true);
		this.smallResID = TableManager.GetValueFromUnionCell(this.skillData.ValueF[0], base.level, true);
		this.maxScale = VInt.NewVInt(Mathf.Clamp(TableManager.GetValueFromUnionCell(this.skillData.ValueG[0], base.level, true), 10000, 50000), GlobalLogic.VALUE_10000);
		this.mCameraPVEOff = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.skillData.ValueG[1], base.level, true), GlobalLogic.VALUE_1000);
		this.mCameraPVPOff = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.skillData.ValueG[2], base.level, true), GlobalLogic.VALUE_1000);
		this.mMoveCameraTimeLen = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.skillData.ValueG[3], base.level, true), GlobalLogic.VALUE_1000);
		this.mResetCameraTimeLen = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.skillData.ValueG[4], base.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x06018753 RID: 100179 RVA: 0x007A1778 File Offset: 0x0079FB78
	public override void OnStart()
	{
		this.m_BoomEntityId = new int[]
		{
			63683,
			63684
		};
		this.actor = null;
		this.isBombEntityCreated = false;
		this.m_ChargeFlag = false;
		this.m_dir_flag = false;
		this.tagPosX = 0;
		this.mCameraOff = VFactor.zero;
		this.RemoveHandler();
		this.monsterID = ((!BattleMain.IsModePvP(base.owner.battleType)) ? 94080031 : 94090031);
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
			this.tagPosX = base.owner.GetPosition().x;
			int x = (!base.owner.GetFace()) ? (position.x + this.bornPos.i) : (-this.bornPos.i + position.x);
			this.actor.SetPosition(new VInt3(x, position.y, this.actor.GetPosition().z), true, true, false);
			this.speed = ((!base.owner.GetFace()) ? Mathf.Abs(this.speed.i) : (-Mathf.Abs(this.speed.i)));
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
			if (num == 26094)
			{
				this.m_ChargeFlag = false;
			}
			else if (num == 26095)
			{
				this.m_ChargeFlag = true;
			}
		});
	}

	// Token: 0x06018754 RID: 100180 RVA: 0x007A1840 File Offset: 0x0079FC40
	public override void OnUpdate(int iDeltime)
	{
		if (this.actor != null && base.owner != null && !this.beDead)
		{
			if (this.changeScale)
			{
				this.scale += 100;
				VInt vint = VInt.Clamp(this.recordScale + this.scale, VInt.zero, this.maxScale);
				this.actor.SetScale(vint);
			}
			if (this.curFrame == this.changePhase)
			{
				if (!this.m_dir_flag)
				{
					this.m_dir_flag = true;
					this.currentDir = base.owner.GetJoystickDegree();
					if (this.currentDir > 45 && this.currentDir < 135)
					{
						this.speed = ((!base.owner.GetFace()) ? Mathf.Abs(this.speedX.i) : (-Mathf.Abs(this.speedX.i)));
						this.speedy = Mathf.Abs(this.speedY.i);
						this.dis = this.disX;
					}
					else if (this.currentDir >= 225 && this.currentDir < 315)
					{
						this.speed = ((!base.owner.GetFace()) ? Mathf.Abs(this.speedX.i) : (-Mathf.Abs(this.speedX.i)));
						this.speedy = -Mathf.Abs(this.speedY.i);
						this.dis = this.disX;
					}
					else
					{
						this.speed = ((!base.owner.GetFace()) ? Mathf.Abs(this.speed.i) : (-Mathf.Abs(this.speed.i)));
						this.speedy = 0;
						this.dis = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true), GlobalLogic.VALUE_1000);
					}
				}
				if (BattleMain.IsModePvP(base.owner.battleType))
				{
					this.actor.buffController.TryAddBuff(25, -1, 1);
				}
				this.changeScale = false;
				this.actor.ResetMoveCmd();
				this.actor.SetMoveSpeedX(this.speed);
				this.actor.SetMoveSpeedY(this.speedy);
				this.orginPos.x = this.orginPos.x + this.speed.scalar * (float)iDeltime / 1000f;
			}
			if (Mathf.Abs(this.actor.GetPosition().x - this.tagPosX) > this.dis || (base.owner.CurrentBeScene.IsInBlockPlayer(this.actor.GetPosition()) && this.curFrame == this.changePhase))
			{
				this.SetMonsterDead();
			}
		}
	}

	// Token: 0x06018755 RID: 100181 RVA: 0x007A1B74 File Offset: 0x0079FF74
	public override void OnEnterPhase(int phase)
	{
		this.curFrame = phase;
		base.OnEnterPhase(phase);
		if (this.actor != null && base.owner != null && this.curFrame == this.changePhase)
		{
			this.actor.RemoveMechanism(this.mechanisID);
		}
		if (this.curFrame == 1 && base.owner.GetCurSkillID() == 2609)
		{
			VFactor a = (!BattleMain.IsModePvP(base.owner.battleType)) ? this.mCameraPVEOff : this.mCameraPVPOff;
			this.mCameraOff = a * ((!base.owner.GetFace()) ? 1L : -1L);
			this.MoveCameraPos(this.mCameraOff, this.mMoveCameraTimeLen);
		}
	}

	// Token: 0x06018756 RID: 100182 RVA: 0x007A1C45 File Offset: 0x007A0045
	public override void OnCancel()
	{
		this.SetMonsterDead();
		this.changeScale = false;
	}

	// Token: 0x06018757 RID: 100183 RVA: 0x007A1C54 File Offset: 0x007A0054
	public override void OnFinish()
	{
		this.changeScale = false;
	}

	// Token: 0x06018758 RID: 100184 RVA: 0x007A1C60 File Offset: 0x007A0060
	private void CreateBoomEntity()
	{
		if (this.actor != null)
		{
			this.isBombEntityCreated = true;
			int entityID = (!this.m_ChargeFlag) ? this.m_BoomEntityId[0] : this.m_BoomEntityId[1];
			base.owner.AddEntity(entityID, this.actor.GetPosition(), base.level, 0);
		}
	}

	// Token: 0x06018759 RID: 100185 RVA: 0x007A1CC0 File Offset: 0x007A00C0
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
			base.owner.delayCaller.DelayCall(this.restoreCameraSec, delegate
			{
				this.RestoreCamera(this.mResetCameraTimeLen);
			}, 0, 0, false);
			this.actor.buffController.RemoveBuff(25, 0, 0);
		}
	}

	// Token: 0x0601875A RID: 100186 RVA: 0x007A1D71 File Offset: 0x007A0171
	private void RestoreCamera(VFactor timeLen)
	{
		if (!base.owner.isLocalActor)
		{
			return;
		}
		BeUtility.ResetCamera();
	}

	// Token: 0x0601875B RID: 100187 RVA: 0x007A1D89 File Offset: 0x007A0189
	private void MoveCameraPos(VFactor off, VFactor timeLen)
	{
		if (!base.owner.isLocalActor)
		{
			return;
		}
		base.owner.CurrentBeScene.currentGeScene.GetCamera().GetController().MoveCamera(off.single, timeLen.single);
	}

	// Token: 0x0601875C RID: 100188 RVA: 0x007A1DCC File Offset: 0x007A01CC
	protected void RemoveHandler()
	{
		if (this.m_SummonHandle != null)
		{
			this.m_SummonHandle.Remove();
			this.m_SummonHandle = null;
		}
		if (this.m_ChargeHandle != null)
		{
			this.m_ChargeHandle.Remove();
			this.m_ChargeHandle = null;
		}
		if (this.m_ActorDeadHandle != null)
		{
			this.m_ActorDeadHandle.Remove();
			this.m_ActorDeadHandle = null;
		}
		if (this.m_HitOtherHandle != null)
		{
			this.m_HitOtherHandle.Remove();
			this.m_HitOtherHandle = null;
		}
	}

	// Token: 0x04011A47 RID: 72263
	private BeActor actor;

	// Token: 0x04011A48 RID: 72264
	private VInt bornPos = 0;

	// Token: 0x04011A49 RID: 72265
	private VInt speed = 0;

	// Token: 0x04011A4A RID: 72266
	private VInt dis = 0;

	// Token: 0x04011A4B RID: 72267
	private int changePhase;

	// Token: 0x04011A4C RID: 72268
	private int mechanisID;

	// Token: 0x04011A4D RID: 72269
	private int smallResID;

	// Token: 0x04011A4E RID: 72270
	private VInt tmpSpeed;

	// Token: 0x04011A4F RID: 72271
	private bool beDead;

	// Token: 0x04011A50 RID: 72272
	private int curFrame;

	// Token: 0x04011A51 RID: 72273
	private Vector3 orginPos = Vector3.zero;

	// Token: 0x04011A52 RID: 72274
	private BeEventHandle m_SummonHandle;

	// Token: 0x04011A53 RID: 72275
	private bool m_ChargeFlag;

	// Token: 0x04011A54 RID: 72276
	private int[] m_BoomEntityId = new int[]
	{
		60271,
		60272
	};

	// Token: 0x04011A55 RID: 72277
	private BeEventHandle m_ChargeHandle;

	// Token: 0x04011A56 RID: 72278
	private BeEventHandle m_ActorDeadHandle;

	// Token: 0x04011A57 RID: 72279
	private BeEventHandle m_HitOtherHandle;

	// Token: 0x04011A58 RID: 72280
	private int currentDir;

	// Token: 0x04011A59 RID: 72281
	private bool m_dir_flag;

	// Token: 0x04011A5A RID: 72282
	private VInt speedy = 0;

	// Token: 0x04011A5B RID: 72283
	private VInt speedX = 0;

	// Token: 0x04011A5C RID: 72284
	private VInt speedY = 0;

	// Token: 0x04011A5D RID: 72285
	private VInt disX = 0;

	// Token: 0x04011A5E RID: 72286
	private VInt maxScale = 0;

	// Token: 0x04011A5F RID: 72287
	private int monsterID = 94080031;

	// Token: 0x04011A60 RID: 72288
	private bool isBombEntityCreated;

	// Token: 0x04011A61 RID: 72289
	private int tagPosX;

	// Token: 0x04011A62 RID: 72290
	private int restoreCameraSec;

	// Token: 0x04011A63 RID: 72291
	private VFactor mCameraPVEOff;

	// Token: 0x04011A64 RID: 72292
	private VFactor mCameraPVPOff;

	// Token: 0x04011A65 RID: 72293
	private VFactor mMoveCameraTimeLen;

	// Token: 0x04011A66 RID: 72294
	private VFactor mResetCameraTimeLen;

	// Token: 0x04011A67 RID: 72295
	private VFactor mCameraOff;

	// Token: 0x04011A68 RID: 72296
	protected VInt recordScale = 0;

	// Token: 0x04011A69 RID: 72297
	protected VInt scale = 0;

	// Token: 0x04011A6A RID: 72298
	protected bool changeScale = true;
}
