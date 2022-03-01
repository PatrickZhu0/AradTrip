using System;
using GameClient;
using UnityEngine;

// Token: 0x020043B9 RID: 17337
public class Mechanism2125 : BeMechanism
{
	// Token: 0x060180B7 RID: 98487 RVA: 0x0077733C File Offset: 0x0077573C
	public Mechanism2125(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060180B8 RID: 98488 RVA: 0x007773A8 File Offset: 0x007757A8
	public override void OnInit()
	{
		base.OnInit();
		this._launchEntityEffect = this.data.StringValueA[0];
		this._skillId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this._entityId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this._entitySpeed = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this._launchTimeAcc = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		this._launchEntityHeight = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		this._launchEntityXOffset = TableManager.GetValueFromUnionCell(this.data.ValueE[1], this.level, true);
		this._launchEntityYOffset = TableManager.GetValueFromUnionCell(this.data.ValueE[2], this.level, true);
		this._launchEntityHitCount = TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true);
	}

	// Token: 0x060180B9 RID: 98489 RVA: 0x00777512 File Offset: 0x00775912
	public override void OnStart()
	{
		base.OnStart();
		this._InitData();
		this._RegisterEvent();
	}

	// Token: 0x060180BA RID: 98490 RVA: 0x00777526 File Offset: 0x00775926
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		this._UpdateLaunchEntity(deltaTime);
	}

	// Token: 0x060180BB RID: 98491 RVA: 0x00777538 File Offset: 0x00775938
	private void _InitData()
	{
		VFactor vfactor = VFactor.pi * 3L / 180L;
		this._fSinA = IntMath.sin(vfactor.nom, vfactor.den);
		this._fCosA = IntMath.cos(vfactor.nom, vfactor.den);
		this._launchState = Mechanism2125.LaunchState.None;
	}

	// Token: 0x060180BC RID: 98492 RVA: 0x00777596 File Offset: 0x00775996
	private void _RegisterEvent()
	{
		this.handleNewA = base.owner.RegisterEventNew(BeEventType.onSyncSightCommand, new BeEvent.BeEventHandleNew.Function(this._OnSyncSightCommand));
	}

	// Token: 0x060180BD RID: 98493 RVA: 0x007775BC File Offset: 0x007759BC
	private void _UpdateLaunchEntity(int deltaTime)
	{
		if (!base.owner.stateController.CanAttack())
		{
			return;
		}
		if (this._launchState != Mechanism2125.LaunchState.Ready)
		{
			return;
		}
		this._curLaunchTimeAcc += deltaTime;
		if (this._curLaunchTimeAcc > this._launchTimeAcc)
		{
			this._LaunchEntity();
			this._curLaunchTimeAcc = 0;
		}
	}

	// Token: 0x060180BE RID: 98494 RVA: 0x00777618 File Offset: 0x00775A18
	private void _LaunchEntity()
	{
		VInt3 position = base.owner.GetPosition();
		position.z += this._launchEntityHeight;
		position.y += this._launchEntityYOffset;
		position.x += ((!base.owner.GetFace()) ? this._launchEntityXOffset : (-this._launchEntityXOffset));
		this.CreateLaunchEntityEffect(position);
		BeEntity beEntity = base.owner.AddEntity(this._entityId, position, this.level, 0);
		if (beEntity != null)
		{
			BeProjectile beProjectile = beEntity as BeProjectile;
			if (beProjectile != null)
			{
				beProjectile.totoalHitCount = this._launchEntityHitCount;
			}
		}
		VFactor vfactor = VFactor.pi * (long)this._curDegree / 180L;
		VInt moveSpeedXLocal = this._entitySpeed * GlobalLogic.VALUE_10000 * IntMath.cos(vfactor.nom, vfactor.den);
		VInt moveSpeedY = (this._entitySpeed * GlobalLogic.VALUE_10000 * IntMath.sin(vfactor.nom, vfactor.den)).i * this._fCosA + position.z * this._fSinA;
		if (beEntity != null)
		{
			if (beEntity.m_pkGeActor != null)
			{
				beEntity.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Root).transform.localRotation = Quaternion.Euler(0f, (float)(-(float)this._curDegree), 0f);
			}
			beEntity.SetMoveSpeedXLocal(moveSpeedXLocal);
			beEntity.SetMoveSpeedY(moveSpeedY);
			beEntity.SetMoveSpeedZ(0);
		}
	}

	// Token: 0x060180BF RID: 98495 RVA: 0x007777CC File Offset: 0x00775BCC
	protected void CreateLaunchEntityEffect(VInt3 pos)
	{
		if (base.owner != null && base.owner.m_pkGeActor != null)
		{
			GeEffectEx geEffectEx = base.owner.m_pkGeActor.CreateEffect(this._launchEntityEffect, "[actor]Orign", 0.5f, pos.vec3, 1f, 1f, false, false, EffectTimeType.SYNC_ANIMATION, false);
			if (geEffectEx != null)
			{
				geEffectEx.SetPosition(pos.vector3);
			}
		}
	}

	// Token: 0x060180C0 RID: 98496 RVA: 0x00777840 File Offset: 0x00775C40
	private void _OnSyncSightCommand(BeEvent.BeEventParam param)
	{
		if (!base.owner.stateController.CanAttack())
		{
			return;
		}
		if (param.m_Int != this._skillId)
		{
			return;
		}
		this._curDegree = param.m_Int3;
		if (param.m_Int2 == 1)
		{
			this._launchState = Mechanism2125.LaunchState.Ready;
		}
		else if (param.m_Int2 == 0)
		{
			this._launchState = Mechanism2125.LaunchState.Finish;
		}
		else if (param.m_Int2 == 3)
		{
			this._DoOnceAttack();
		}
	}

	// Token: 0x060180C1 RID: 98497 RVA: 0x007778C2 File Offset: 0x00775CC2
	private void _DoOnceAttack()
	{
		this._LaunchEntity();
		this._curLaunchTimeAcc = 0;
	}

	// Token: 0x04011530 RID: 70960
	private Mechanism2125.LaunchState _launchState;

	// Token: 0x04011531 RID: 70961
	private int _skillId = 21827;

	// Token: 0x04011532 RID: 70962
	private int _entityId = 63609;

	// Token: 0x04011533 RID: 70963
	private int _entitySpeed = 50000;

	// Token: 0x04011534 RID: 70964
	private int _launchTimeAcc = 1000;

	// Token: 0x04011535 RID: 70965
	private int _launchEntityHeight = 10000;

	// Token: 0x04011536 RID: 70966
	private int _launchEntityXOffset = 10000;

	// Token: 0x04011537 RID: 70967
	private int _launchEntityYOffset = 10000;

	// Token: 0x04011538 RID: 70968
	private int _curLaunchTimeAcc;

	// Token: 0x04011539 RID: 70969
	private int _curDegree;

	// Token: 0x0401153A RID: 70970
	private string _launchEntityEffect;

	// Token: 0x0401153B RID: 70971
	private VFactor _fSinA;

	// Token: 0x0401153C RID: 70972
	private VFactor _fCosA;

	// Token: 0x0401153D RID: 70973
	protected int _launchEntityHitCount = 1;

	// Token: 0x020043BA RID: 17338
	private enum LaunchState
	{
		// Token: 0x0401153F RID: 70975
		None,
		// Token: 0x04011540 RID: 70976
		Ready,
		// Token: 0x04011541 RID: 70977
		Finish
	}
}
