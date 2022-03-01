using System;
using GameClient;
using ProtoTable;
using UnityEngine;

// Token: 0x020040FB RID: 16635
public class BDGenProjectile : BDEventBase
{
	// Token: 0x06016A5F RID: 92767 RVA: 0x006DC24D File Offset: 0x006DA64D
	public BDGenProjectile(object info)
	{
		this._info = info;
	}

	// Token: 0x06016A60 RID: 92768 RVA: 0x006DC25C File Offset: 0x006DA65C
	public override void OnEvent(BeEntity pkEntity)
	{
		base.OnEvent(pkEntity);
		if (pkEntity == null)
		{
			return;
		}
		EntityFrames frame = this._info as EntityFrames;
		if (frame == null)
		{
			return;
		}
		if (frame.type != EntityType.LogicEntity)
		{
			BeScene main = pkEntity.CurrentBeScene;
			if (frame.useRandomLaunch)
			{
				VInt3 startPosition = this.GetStartPosition(pkEntity);
				int num = frame.randomLaunchInfo.num;
				if (frame.randomLaunchInfo.isNumRand)
				{
					num = base.FrameRandom(pkEntity).InRange(IntMath.Float2Int(frame.randomLaunchInfo.numRandRange.x), IntMath.Float2Int(frame.randomLaunchInfo.numRandRange.y + 1f));
				}
				for (int i = 0; i < num; i++)
				{
					VInt3 pos = default(VInt3);
					if (frame.randomLaunchInfo.isFullScene)
					{
						pos = pkEntity.CurrentBeScene.GetRandomPos(20);
						pos.z = startPosition.z + VInt.Float2VIntValue(frame.emitposition.y);
					}
					else
					{
						int num2 = VInt.Float2VIntValue(frame.randomLaunchInfo.rangeRadius);
						pos.x = startPosition.x + base.FrameRandom(pkEntity).InRange(-num2, num2);
						pos.y = startPosition.y + base.FrameRandom(pkEntity).InRange(-num2, num2);
						pos.z = startPosition.z + VInt.Float2VIntValue(frame.emitposition.y);
					}
					int ms = IntMath.Float2Int(frame.randomLaunchInfo.interval * (float)GlobalLogic.VALUE_1000) * i;
					pkEntity.delayCaller.DelayCall(ms, delegate
					{
						this.LaunchProjectile(pkEntity, frame, main, true, pos);
					}, 0, 0, false);
				}
			}
			else
			{
				int[] array = new int[1];
				int[] array2 = new int[1];
				pkEntity.TriggerEvent(BeEventType.onChangeLaunchProNum, new object[]
				{
					frame.resID,
					array,
					array2
				});
				for (int j = 0; j < array2[0] + 1; j++)
				{
					int num3 = j * array[0];
					if (num3 != 0)
					{
						pkEntity.delayCaller.DelayCall(num3, delegate
						{
							this.LaunchProjectile(pkEntity, frame, main, false, default(VInt3));
						}, 0, 0, false);
					}
					else
					{
						this.LaunchProjectile(pkEntity, frame, main, false, default(VInt3));
					}
				}
			}
		}
	}

	// Token: 0x06016A61 RID: 92769 RVA: 0x006DC5A4 File Offset: 0x006DA9A4
	private void LaunchProjectile(BeEntity pkEntity, EntityFrames frame, BeScene main, bool useGivenPos = false, VInt3 gPos = default(VInt3))
	{
		int num = frame.resID;
		int num2 = 0;
		if (frame.type == EntityType.Bullet)
		{
			int[] array = new int[]
			{
				num,
				0,
				1
			};
			pkEntity.TriggerEvent(BeEventType.onBeforeGenBullet, new object[]
			{
				array
			});
			if (array[0] != 0)
			{
				num = array[0];
				num2 = array[1];
			}
			if (array[2] != 1)
			{
				return;
			}
		}
		int triggerSkillLevel = 1;
		if (pkEntity.IsCastingSkill())
		{
			BeActor beActor = pkEntity as BeActor;
			BeSkill currentSkill = beActor.GetCurrentSkill();
			if (currentSkill != null)
			{
				triggerSkillLevel = currentSkill.level;
			}
		}
		BeEntity beEntity;
		if (pkEntity is BeProjectile)
		{
			beEntity = pkEntity.GetOwner();
		}
		else
		{
			beEntity = pkEntity;
		}
		if (beEntity.IsRemoved())
		{
			return;
		}
		if (frame.randomResID)
		{
			int num3 = pkEntity.FrameRandom.InRange(0, frame.resIDList.Length);
			num = frame.resIDList[num3];
		}
		BeProjectile beProjectile = main.AddProjectile(num, pkEntity.m_iCamp, (int)frame.type, IntMath.Float2Int(frame.lifeTime * (float)GlobalLogic.VALUE_1000), triggerSkillLevel, beEntity, -1, false);
		beProjectile.hurtID = frame.hurtID;
		beProjectile.attribute = pkEntity.attribute;
		beProjectile.hitThrough = frame.hitThrough;
		beProjectile.totoalHitCount = frame.hitCount;
		beProjectile.attackCountExceedPlayExtDead = frame.attackCountExceedPlayExtDead;
		beProjectile.distance = VInt.Float2VIntValue(frame.distance);
		beProjectile.delayDead = IntMath.Float2Int(frame.delayDead * (float)GlobalLogic.VALUE_1000);
		beProjectile.hitGroundClick = frame.hitGroundClick;
		beProjectile.onCollideDie = frame.onCollideDie;
		beProjectile.onXInBlockDie = frame.onXInBlockDie;
		beProjectile.changForceBehindOther = frame.changForceBehindOther;
		if (num2 > 0)
		{
			beProjectile.attachHurts.Add(num2);
		}
		beProjectile.SetFace(pkEntity.GetFace(), false, false);
		if (frame.changeFace == 1)
		{
			beProjectile.SetFace(true, true, true);
		}
		else if (frame.changeFace == 2)
		{
			beProjectile.SetFace(false, true, true);
		}
		VInt3 rkPos = default(VInt3);
		ObjectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ObjectTable>(num, string.Empty, string.Empty);
		if (tableItem != null && tableItem.UseOwnerPos)
		{
			rkPos = pkEntity.GetPosition();
			if (tableItem.UseOffset)
			{
				rkPos.z += VInt.Float2VIntValue(frame.emitposition.y);
				rkPos.y += VInt.Float2VIntValue(frame.emitPositionZ);
				rkPos.x += (pkEntity.GetFace() ? (-VInt.Float2VIntValue(frame.emitposition.x)) : VInt.Float2VIntValue(frame.emitposition.x));
			}
		}
		else if (useGivenPos)
		{
			rkPos = gPos;
		}
		else
		{
			rkPos = this.GetStartPosition(beProjectile.GetOwner());
			rkPos.z += VInt.Float2VIntValue(frame.emitposition.y);
			rkPos.y += VInt.Float2VIntValue(frame.emitPositionZ);
			rkPos.x += (beProjectile.GetFace() ? (-VInt.Float2VIntValue(frame.emitposition.x)) : VInt.Float2VIntValue(frame.emitposition.x));
		}
		int num4 = IntMath.Float2Int(frame.angle * 1000f);
		if (frame.offsetType == OffsetType.OFFSET_ANGLE)
		{
			num4 += base.FrameRandom(pkEntity).InRange(-800, 800);
		}
		VInt[] array2 = new VInt[]
		{
			(VInt)frame.speed
		};
		beEntity.TriggerEvent(BeEventType.onChangeProjectileSpeed, new object[]
		{
			beProjectile,
			array2
		});
		VInt vint = array2[0];
		VFactor vfactor = VFactor.NewVFactor((long)num4, 1000L) / (VFactor.pi * 2L);
		VInt vint2 = vint.i * IntMath.cos(vfactor.nom, vfactor.den);
		VInt vint3 = vint.i * IntMath.sin(vfactor.nom, vfactor.den);
		int num5 = VInt.Float2VIntValue(0.2f);
		if (frame.offsetType == OffsetType.OFFSET_VERTICAL)
		{
			if (vint2 != 0)
			{
				rkPos.y += base.FrameRandom(pkEntity).InRange(-num5, num5);
			}
			if (vint3 != 0)
			{
				rkPos.x += base.FrameRandom(pkEntity).InRange(-num5, num5);
			}
		}
		beProjectile.SetPosition(rkPos, false, true);
		beProjectile.SetScale(pkEntity.GetScale().i * beProjectile.GetProjectileScale());
		beProjectile.SetZDimScaleFactor(beProjectile.GetProjectileZDimScale());
		beProjectile._updateGraphicActor(false);
		beProjectile.moveZAcc = new VInt(frame.gravity.y);
		beProjectile.moveXAcc = new VInt(frame.gravity.x);
		if (pkEntity.m_cpkCurEntityActionInfo != null)
		{
			BDEntityActionInfo cpkCurEntityActionInfo = pkEntity.m_cpkCurEntityActionInfo;
			beProjectile.hurtType = cpkCurEntityActionInfo.iActionType;
			beProjectile.forcex = cpkCurEntityActionInfo.fActionForcex;
			beProjectile.forcey = cpkCurEntityActionInfo.fActionForcey;
			beProjectile.hurtTime = cpkCurEntityActionInfo.hurtTime;
		}
		if (frame.shockTime > 0f)
		{
			beProjectile.SetTargetShockInfo(new ShockInfo
			{
				shockTime = frame.shockTime,
				shockSpeed = frame.shockSpeed,
				shockRangeX = frame.shockRangeX,
				shockRangeY = frame.shockRangeY
			});
		}
		beProjectile.SetSceneShockInfo(frame.sceneShock);
		if (frame.axisType == AxisType.Z)
		{
			beProjectile.SetMoveSpeedXLocal(vint2);
			beProjectile.SetMoveSpeedZ(vint3);
			if (frame.isAngleWithEffect)
			{
				beProjectile.InitLocalRotation();
			}
		}
		else if (frame.axisType == AxisType.Y)
		{
			VFactor vfactor2 = VFactor.pi * (long)VInt.Float2VIntValue(frame.angle) / 180L / 10000L;
			vint2 = vint.i * IntMath.cos(vfactor2.nom, vfactor2.den);
			vint3 = vint.i * IntMath.sin(vfactor2.nom, vfactor2.den);
			beProjectile.SetMoveSpeedXLocal(vint2);
			beProjectile.SetMoveSpeedY(vint3);
			beProjectile.SetMoveSpeedZ(0);
		}
		else if (frame.axisType == AxisType.X)
		{
		}
		beProjectile.RecordOriginPosition();
		beProjectile.isHitFloat = (frame.hitFallUP == 1);
		beProjectile.hitFloatForceY = frame.forceY;
		if (frame.isRotation)
		{
			beProjectile.rotateSpeed = VInt.Float2VIntValue(frame.rotateSpeed / 100f);
			beProjectile.moveSpeed = VInt.Float2VIntValue(frame.moveSpeed / 1000f);
			beProjectile.InitRotation(frame.rotateInitDegree);
			beProjectile.isFollowRotate = frame.followRotate;
		}
		pkEntity.TriggerEvent(BeEventType.onAfterGenBullet, new object[]
		{
			beProjectile
		});
		if (frame.targetChooseType == TargetChooseType.SMART_NEAREST)
		{
			BeScene currentBeScene = pkEntity.CurrentBeScene;
			if (currentBeScene != null)
			{
				BeActor projectileOwner = this.GetProjectileOwner(pkEntity);
				BeActor beActor2 = currentBeScene.FindNearestFacedTarget(projectileOwner, new VInt2(frame.range.x, frame.range.y));
				if (beActor2 != null && Mathf.Abs(beActor2.GetPosition().x - pkEntity.GetPosition().x) > VInt.onehalf)
				{
					LinearLogicTrial linearLogicTrial = new LinearLogicTrial();
					linearLogicTrial.StartPoint = beProjectile.GetPosition();
					VInt3 position = beActor2.GetPosition();
					position.z = linearLogicTrial.StartPoint.z;
					linearLogicTrial.EndPoint = position;
					if (pkEntity.GetFace() && linearLogicTrial.EndPoint.x > linearLogicTrial.StartPoint.x)
					{
						linearLogicTrial.EndPoint.x = linearLogicTrial.StartPoint.x - VInt.zeroDotOne.i;
					}
					if (!pkEntity.GetFace() && linearLogicTrial.EndPoint.x < linearLogicTrial.StartPoint.x)
					{
						linearLogicTrial.EndPoint.x = linearLogicTrial.StartPoint.x + VInt.zeroDotOne.i;
					}
					if (Mathf.Abs(linearLogicTrial.EndPoint.y - linearLogicTrial.StartPoint.y) <= VInt.half)
					{
						linearLogicTrial.EndPoint.y = linearLogicTrial.StartPoint.y;
					}
					linearLogicTrial.MoveSpeed = vint2;
					linearLogicTrial.Init();
					beProjectile.trail = linearLogicTrial;
				}
			}
		}
		else if (frame.targetChooseType == TargetChooseType.MAX_RESENTMENT)
		{
			BeScene currentBeScene2 = pkEntity.CurrentBeScene;
			if (currentBeScene2 != null)
			{
				BeActor resentmentActor = currentBeScene2.GetResentmentActor(true);
				if (resentmentActor != null)
				{
					beProjectile.SetPosition(resentmentActor.GetPosition(), true, true);
				}
			}
		}
		else if (frame.targetChooseType == TargetChooseType.BOOMERANGE)
		{
			BeScene currentBeScene3 = pkEntity.CurrentBeScene;
			if (currentBeScene3 != null)
			{
				BeActor projectileOwner2 = this.GetProjectileOwner(pkEntity);
				BeActor beActor3 = currentBeScene3.FindNearestFacedTarget(projectileOwner2, new VInt2(frame.range.x, frame.range.y));
				VInt3 vint4 = new VInt3((!pkEntity.GetFace()) ? 1f : -1f, 0f, 0f);
				VInt3 vint5 = vint4.NormalizeTo(10000);
				VInt3 position2 = beProjectile.GetPosition();
				VInt3 position3 = beProjectile.GetOwner().GetPosition();
				position3.z = position2.z;
				if (beActor3 != null && Mathf.Abs(beActor3.GetPosition().x - pkEntity.GetPosition().x) > new VInt(1.5f))
				{
					VInt3 position4 = beActor3.GetPosition();
					position4.z = position2.z;
					vint5 = (position4 - position3).NormalizeTo(10000);
				}
				BoomerangBehaviour2 boomerangBehaviour = new BoomerangBehaviour2();
				boomerangBehaviour.StartPoint = position2;
				boomerangBehaviour.stayDuration = (int)(frame.stayDuration * 1000f);
				int[] array3 = new int[]
				{
					boomerangBehaviour.stayDuration
				};
				pkEntity.TriggerEvent(BeEventType.onChangeBoomerangStayDuration, new object[]
				{
					projectileOwner2.GetCurSkillID(),
					array3
				});
				boomerangBehaviour.stayDuration = array3[0];
				LinearLogicTrial linearLogicTrial2 = boomerangBehaviour;
				VInt3 v = vint5;
				VInt vint6 = new VInt(frame.boomerangeDistance);
				linearLogicTrial2.EndPoint = v * vint6.factor + position3;
				BoomerangBehaviour2 boomerangBehaviour2 = boomerangBehaviour;
				int y = boomerangBehaviour2.EndPoint.y;
				VInt vint7 = new VInt(frame.emitPositionZ);
				boomerangBehaviour2.EndPoint.y = y + vint7.i * 2;
				BoomerangBehaviour2 boomerangBehaviour3 = boomerangBehaviour;
				int x = boomerangBehaviour3.EndPoint.x;
				VInt vint8 = new VInt(frame.emitposition.x);
				boomerangBehaviour3.EndPoint.x = x + vint8.i;
				boomerangBehaviour.MoveSpeed = vint2;
				boomerangBehaviour.Init();
				beProjectile.trail = boomerangBehaviour;
				boomerangBehaviour.target = (pkEntity as BeActor);
				boomerangBehaviour.owner = beProjectile;
			}
		}
		else if (frame.targetChooseType != TargetChooseType.PARABOLA_TARGET_POS)
		{
			if (frame.targetChooseType != TargetChooseType.PARABOLA_TARGET)
			{
				if (frame.targetChooseType == TargetChooseType.GRAVITATION)
				{
					BeScene currentBeScene4 = pkEntity.CurrentBeScene;
					if (currentBeScene4 != null)
					{
						BeActor projectileOwner3 = this.GetProjectileOwner(pkEntity);
						BeActor beActor4 = currentBeScene4.FindNearestRangeTarget(projectileOwner3.GetPosition(), projectileOwner3, GlobalLogic.VALUE_100 * GlobalLogic.VALUE_10000, null);
						if (beActor4 != null)
						{
							Gravitation gravitation = new Gravitation();
							gravitation.StartPoint = beProjectile.GetPosition();
							beProjectile.ClearMoveSpeed(7);
							VInt3 position5 = beActor4.GetPosition();
							position5.z = gravitation.StartPoint.z;
							gravitation.EndPoint = position5;
							if (projectileOwner3.GetFace())
							{
								gravitation.speed = -gravitation.speed;
							}
							gravitation.Init();
							beProjectile.trail = gravitation;
							gravitation.target = beActor4;
							gravitation.owner = beProjectile;
						}
					}
				}
				else if (frame.targetChooseType == TargetChooseType.FOLLOW_TARGET)
				{
					BeScene currentBeScene5 = pkEntity.CurrentBeScene;
					if (currentBeScene5 != null)
					{
						BeActor projectileOwner4 = this.GetProjectileOwner(pkEntity);
						if (projectileOwner4 != null)
						{
							BeActor beActor5 = currentBeScene5.FindNearestRangeTarget(projectileOwner4.GetPosition(), projectileOwner4, GlobalLogic.VALUE_100 * GlobalLogic.VALUE_10000, null);
							if (beActor5 != null)
							{
								FollowTarget followTarget = new FollowTarget();
								followTarget.StartPoint = beProjectile.GetPosition();
								beProjectile.ClearMoveSpeed(7);
								VInt3 position6 = beActor5.GetPosition();
								position6.z = followTarget.StartPoint.z;
								followTarget.EndPoint = position6;
								followTarget.MoveSpeed = vint2.i / GlobalLogic.VALUE_10;
								followTarget.Init();
								beProjectile.trail = followTarget;
								followTarget.owner = beProjectile;
								followTarget.target = beActor5;
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06016A62 RID: 92770 RVA: 0x006DD30C File Offset: 0x006DB70C
	private VInt3 GetStartPosition(BeEntity owner)
	{
		VInt3 result = owner.GetPosition();
		EntityFrames entityFrames = this._info as EntityFrames;
		TargetChooseType targetChooseType = entityFrames.targetChooseType;
		switch (targetChooseType)
		{
		case TargetChooseType.NEAREST:
		{
			BeScene currentBeScene = owner.CurrentBeScene;
			if (currentBeScene != null)
			{
				BeActor beActor = currentBeScene.FindTarget(owner as BeActor, (VInt)30f);
				if (beActor != null)
				{
					result = beActor.GetPosition();
					result.z = 0;
				}
			}
			break;
		}
		default:
			if (targetChooseType == TargetChooseType.LAST_TARGET)
			{
				result = owner.lastTargetOwnerPos;
				result.z = 0;
			}
			break;
		case TargetChooseType.FARTEST:
			break;
		case TargetChooseType.FULL_SCREEN:
			break;
		}
		return result;
	}

	// Token: 0x06016A63 RID: 92771 RVA: 0x006DD3B8 File Offset: 0x006DB7B8
	public override void PreparePreload(BeActionFrameMgr frameMgr, SkillFileListCache fileCache, bool useCube = false)
	{
		if (useCube)
		{
			return;
		}
		EntityFrames entityFrames = this._info as EntityFrames;
		if (entityFrames != null)
		{
			int resID = entityFrames.resID;
			if (resID != 0)
			{
				PreloadManager.PreloadResID(resID, frameMgr, fileCache, false);
			}
		}
	}

	// Token: 0x06016A64 RID: 92772 RVA: 0x006DD3F4 File Offset: 0x006DB7F4
	protected BeActor GetProjectileOwner(BeEntity entity)
	{
		BeActor beActor = entity as BeActor;
		if (beActor != null)
		{
			return beActor;
		}
		beActor = (entity.GetOwner() as BeActor);
		if (beActor != null)
		{
			return beActor;
		}
		return null;
	}

	// Token: 0x04010242 RID: 66114
	public object _info;
}
