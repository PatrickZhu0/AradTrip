using System;
using System.Collections.Generic;
using FBSkillData;
using FlatBuffers;
using UnityEngine;

// Token: 0x02004B40 RID: 19264
public class FBSkillDataTools
{
	// Token: 0x0601C4B8 RID: 115896 RVA: 0x00898B36 File Offset: 0x00896F36
	private void FlatBufferAddString(FBSkillDataTools.AddString method, FlatBufferBuilder builder, string value)
	{
		if (!string.IsNullOrEmpty(value) && method != null)
		{
			method(builder, builder.CreateString(value));
		}
	}

	// Token: 0x0601C4B9 RID: 115897 RVA: 0x00898B58 File Offset: 0x00896F58
	private StringOffset CreateString(string value)
	{
		if (!string.IsNullOrEmpty(value))
		{
			return this.currentBuilder.CreateString(value);
		}
		return default(StringOffset);
	}

	// Token: 0x0601C4BA RID: 115898 RVA: 0x00898B86 File Offset: 0x00896F86
	private void CreateSValue(SUnion value, FlatBufferBuilder builder, ref int offset, ref int type)
	{
	}

	// Token: 0x0601C4BB RID: 115899 RVA: 0x00898B88 File Offset: 0x00896F88
	private VectorOffset CreateSkillPhasesVector(int[] data)
	{
		if (data != null && data.Length > 0)
		{
			return FBSkillData.CreateSkillPhasesVector(this.currentBuilder, data);
		}
		return default(VectorOffset);
	}

	// Token: 0x0601C4BC RID: 115900 RVA: 0x00898BBA File Offset: 0x00896FBA
	private T Call<T>(Func<T> func)
	{
		return func();
	}

	// Token: 0x0601C4BD RID: 115901 RVA: 0x00898BC4 File Offset: 0x00896FC4
	private Offset<FBSkillData> CreateFBSkillData(FlatBufferBuilder builder, DSkillData editorData)
	{
		try
		{
			return FBSkillData.CreateFBSkillData(builder, this.CreateString(editorData._name), editorData.skillID, editorData.skillPriority, this.CreateSkillPhasesVector(editorData.skillPhases), editorData.relatedAttackSpeed, editorData.attackSpeed, editorData.isLoop, editorData.notLoopLastFrame, editorData.loopAnimation, editorData.loopAnimation1, this.CreateString(editorData.hitEffect), this.CreateString(editorData.goHitEffectAsset.m_AssetPath), this.CreateString(editorData.goSFXAsset.m_AssetPath), editorData.hitSFXID, editorData.hurtType, editorData.hurtTime, editorData.hurtPause, editorData.hurtPauseTime, editorData.forcex, editorData.forcey, this.CreateString(editorData.description), this.CreateString(editorData.characterAsset.m_AssetPath), editorData.fps, this.CreateString(editorData.animationName), this.CreateString(editorData.moveName), (int)editorData.wrapMode, editorData.interpolationSpeed, editorData.animationSpeed, editorData.totalFrames, editorData.startUpFrames, editorData.activeFrames, editorData.recoveryFrames, editorData.useSpellBar, editorData.spellBarTime, editorData.comboStartFrame, editorData.comboSkillID, editorData.skilltime, editorData.cameraRestore, editorData.cameraRestoreTime, editorData.grabPosx, editorData.grabPosy, editorData.grabEndForceX, editorData.grabEndForceY, editorData.grabTime, editorData.grabEndEffectType, editorData.grabAction, editorData.grabNum, editorData.grabMoveSpeed, editorData.grabSupportQuickPressDismis, editorData.notGrabBati, editorData.notGrabGeDang, editorData.notUseGrabSetPos, editorData.notGrabToBlock, editorData.buffInfoId, editorData.buffInfoIdToSelf, editorData.buffInfoIDToOther, editorData.isCharge, this.Call<Offset<FBSkillData.ChargeConfig>>(delegate
			{
				global::ChargeConfig chargeConfig = editorData.chargeConfig;
				return FBSkillData.ChargeConfig.CreateChargeConfig(builder, chargeConfig.repeatPhase, chargeConfig.changePhase, chargeConfig.switchPhaseID, chargeConfig.chargeDuration, chargeConfig.chargeMinDuration, this.CreateString(chargeConfig.effect), this.CreateString(chargeConfig.locator), chargeConfig.buffInfo, chargeConfig.playBuffAni);
			}), editorData.isSpeicalOperate, this.Call<Offset<FBSkillData.OperationConfig>>(delegate
			{
				global::OperationConfig operationConfig = editorData.operationConfig;
				return FBSkillData.OperationConfig.CreateOperationConfig(builder, operationConfig.changePhase, FBSkillData.OperationConfig.CreateChangeSkillIDsVector(builder, operationConfig.changeSkillIDs));
			}), editorData.isUseSelectSeatJoystick, this.Call<Offset<FBSkillData.SkillJoystickConfig>>(delegate
			{
				global::SkillJoystickConfig skillJoystickConfig = editorData.skillJoystickConfig;
				StringOffset effectNameOffset = this.CreateString(skillJoystickConfig.effectName);
				FBSkillData.SkillJoystickConfig.StartSkillJoystickConfig(builder);
				FBSkillData.SkillJoystickConfig.AddMode(builder, (int)((sbyte)skillJoystickConfig.mode));
				FBSkillData.SkillJoystickConfig.AddEffectName(builder, effectNameOffset);
				FBSkillData.SkillJoystickConfig.AddEffectMoveSpeed(builder, Vector3.CreateVector3(builder, skillJoystickConfig.effectMoveSpeed.x, skillJoystickConfig.effectMoveSpeed.y, skillJoystickConfig.effectMoveSpeed.z));
				FBSkillData.SkillJoystickConfig.AddEffectMoveRange(builder, Vector3.CreateVector3(builder, skillJoystickConfig.effectMoveRange.x, skillJoystickConfig.effectMoveRange.y, skillJoystickConfig.effectMoveRange.z));
				return FBSkillData.SkillJoystickConfig.EndSkillJoystickConfig(builder);
			}), this.Call<VectorOffset>(delegate
			{
				if (editorData.skillEvents != null && editorData.skillEvents.Length > 0)
				{
					List<Offset<FBSkillData.SkillEvent>> list = new List<Offset<FBSkillData.SkillEvent>>();
					for (int i = 0; i < editorData.skillEvents.Length; i++)
					{
						global::SkillEvent skillEvent = editorData.skillEvents[i];
						list.Add(FBSkillData.SkillEvent.CreateSkillEvent(builder, (int)((sbyte)skillEvent.eventType), (int)((sbyte)skillEvent.eventAction), this.CreateString(skillEvent.paramter), skillEvent.workPhase));
					}
					return FBSkillData.CreateSkillEventsVector(builder, list.ToArray());
				}
				return default(VectorOffset);
			}), (int)((sbyte)editorData.triggerType), this.Call<VectorOffset>(delegate
			{
				if (editorData.HurtBlocks != null && editorData.HurtBlocks.Length > 0)
				{
					List<Offset<FBSkillData.HurtDecisionBox>> list = new List<Offset<FBSkillData.HurtDecisionBox>>();
					for (int i = 0; i < editorData.HurtBlocks.Length; i++)
					{
						global::HurtDecisionBox hurtDecisionBox = editorData.HurtBlocks[i];
						VectorOffset boxs = default(VectorOffset);
						if (hurtDecisionBox.boxs != null && hurtDecisionBox.boxs.Length > 0)
						{
							List<Offset<FBSkillData.ShapeBox>> list2 = new List<Offset<FBSkillData.ShapeBox>>();
							for (int j = 0; j < hurtDecisionBox.boxs.Length; j++)
							{
								global::ShapeBox shapeBox = hurtDecisionBox.boxs[j];
								FBSkillData.ShapeBox.StartShapeBox(builder);
								FBSkillData.ShapeBox.AddCenter(builder, Vector2.CreateVector2(builder, shapeBox.center.x, shapeBox.center.y));
								FBSkillData.ShapeBox.AddSize(builder, Vector2.CreateVector2(builder, shapeBox.size.x, shapeBox.size.y));
								list2.Add(FBSkillData.ShapeBox.EndShapeBox(builder));
							}
							boxs = FBSkillData.HurtDecisionBox.CreateBoxsVector(builder, list2.ToArray());
						}
						list.Add(FBSkillData.HurtDecisionBox.CreateHurtDecisionBox(builder, boxs, hurtDecisionBox.hasHit, hurtDecisionBox.blockToggle, hurtDecisionBox.zDim, hurtDecisionBox.damage, hurtDecisionBox.hurtID));
					}
					return FBSkillData.CreateHurtBlocksVector(builder, list.ToArray());
				}
				return default(VectorOffset);
			}), this.Call<VectorOffset>(delegate
			{
				if (editorData.DefenceBlocks != null && editorData.DefenceBlocks.Length > 0)
				{
					List<Offset<FBSkillData.DefenceDecisionBox>> list = new List<Offset<FBSkillData.DefenceDecisionBox>>();
					for (int i = 0; i < editorData.DefenceBlocks.Length; i++)
					{
						global::DefenceDecisionBox defenceDecisionBox = editorData.DefenceBlocks[i];
						VectorOffset boxs = default(VectorOffset);
						if (defenceDecisionBox.boxs != null && defenceDecisionBox.boxs.Length > 0)
						{
							List<Offset<FBSkillData.ShapeBox>> list2 = new List<Offset<FBSkillData.ShapeBox>>();
							for (int j = 0; j < defenceDecisionBox.boxs.Length; j++)
							{
								global::ShapeBox shapeBox = defenceDecisionBox.boxs[j];
								FBSkillData.ShapeBox.StartShapeBox(builder);
								FBSkillData.ShapeBox.AddCenter(builder, Vector2.CreateVector2(builder, shapeBox.center.x, shapeBox.center.y));
								FBSkillData.ShapeBox.AddSize(builder, Vector2.CreateVector2(builder, shapeBox.size.x, shapeBox.size.y));
								list2.Add(FBSkillData.ShapeBox.EndShapeBox(builder));
							}
							FBSkillData.DefenceDecisionBox.StartBoxsVector(builder, defenceDecisionBox.boxs.Length);
							for (int k = defenceDecisionBox.boxs.Length - 1; k >= 0; k--)
							{
								builder.AddOffset(list2[k].Value);
							}
							boxs = FBSkillData.DefenceDecisionBox.CreateBoxsVector(builder, list2.ToArray());
						}
						list.Add(FBSkillData.DefenceDecisionBox.CreateDefenceDecisionBox(builder, boxs, defenceDecisionBox.hasHit, defenceDecisionBox.blockToggle, defenceDecisionBox.type));
					}
					return FBSkillData.CreateDefenceBlocksVector(builder, list.ToArray());
				}
				return default(VectorOffset);
			}), this.Call<VectorOffset>(delegate
			{
				if (editorData.attachFrames != null && editorData.attachFrames.Length > 0)
				{
					List<Offset<FBSkillData.EntityAttachFrames>> list = new List<Offset<FBSkillData.EntityAttachFrames>>();
					for (int i = 0; i < editorData.attachFrames.Length; i++)
					{
						global::EntityAttachFrames entityAttachFrames = editorData.attachFrames[i];
						StringOffset nameOffset = this.CreateString(entityAttachFrames.name);
						StringOffset attachNameOffset = this.CreateString(entityAttachFrames.attachName);
						StringOffset entityAssetOffset = this.CreateString(entityAttachFrames.entityAsset.m_AssetPath);
						Offset<FBSkillData.TransformParam> transOffset = default(Offset<FBSkillData.TransformParam>);
						if (entityAttachFrames.trans != null)
						{
							transOffset = FBSkillData.TransformParam.CreateTransformParam(builder, entityAttachFrames.trans.localPosition.x, entityAttachFrames.trans.localPosition.y, entityAttachFrames.trans.localPosition.z, entityAttachFrames.trans.localRotation.x, entityAttachFrames.trans.localRotation.y, entityAttachFrames.trans.localRotation.z, entityAttachFrames.trans.localRotation.w, entityAttachFrames.trans.localScale.x, entityAttachFrames.trans.localScale.y, entityAttachFrames.trans.localScale.z);
						}
						VectorOffset animationsOffset = default(VectorOffset);
						if (entityAttachFrames.animations != null && entityAttachFrames.animations.Length > 0)
						{
							List<Offset<FBSkillData.AnimationFrames>> list2 = new List<Offset<FBSkillData.AnimationFrames>>();
							for (int j = 0; j < entityAttachFrames.animations.Length; j++)
							{
								global::AnimationFrames animationFrames = entityAttachFrames.animations[j];
								list2.Add(FBSkillData.AnimationFrames.CreateAnimationFrames(builder, animationFrames.start, builder.CreateString(animationFrames.anim), animationFrames.blend, (int)animationFrames.mode, animationFrames.speed));
							}
							animationsOffset = FBSkillData.EntityAttachFrames.CreateAnimationsVector(builder, list2.ToArray());
						}
						FBSkillData.EntityAttachFrames.StartEntityAttachFrames(builder);
						FBSkillData.EntityAttachFrames.AddName(builder, nameOffset);
						FBSkillData.EntityAttachFrames.AddResID(builder, entityAttachFrames.resID);
						FBSkillData.EntityAttachFrames.AddStart(builder, entityAttachFrames.start);
						FBSkillData.EntityAttachFrames.AddEnd(builder, entityAttachFrames.end);
						FBSkillData.EntityAttachFrames.AddAttachName(builder, attachNameOffset);
						FBSkillData.EntityAttachFrames.AddEntityAsset(builder, entityAssetOffset);
						FBSkillData.EntityAttachFrames.AddTrans(builder, transOffset);
						FBSkillData.EntityAttachFrames.AddAnimations(builder, animationsOffset);
						list.Add(FBSkillData.EntityAttachFrames.EndEntityAttachFrames(builder));
					}
					return FBSkillData.CreateAttachFramesVector(builder, list.ToArray());
				}
				return default(VectorOffset);
			}), this.Call<VectorOffset>(delegate
			{
				if (editorData.effectFrames != null && editorData.effectFrames.Length > 0)
				{
					List<Offset<FBSkillData.EffectsFrames>> list = new List<Offset<FBSkillData.EffectsFrames>>();
					for (int i = 0; i < editorData.effectFrames.Length; i++)
					{
						global::EffectsFrames effectsFrames = editorData.effectFrames[i];
						StringOffset nameOffset = this.CreateString(effectsFrames.name);
						StringOffset attachnameOffset = this.CreateString(effectsFrames.attachname);
						StringOffset effectAssetOffset = this.CreateString(effectsFrames.effectAsset.m_AssetPath);
						FBSkillData.EffectsFrames.StartEffectsFrames(builder);
						FBSkillData.EffectsFrames.AddName(builder, nameOffset);
						FBSkillData.EffectsFrames.AddEffectResID(builder, effectsFrames.effectResID);
						FBSkillData.EffectsFrames.AddStartFrames(builder, effectsFrames.startFrames);
						FBSkillData.EffectsFrames.AddEndFrames(builder, effectsFrames.endFrames);
						FBSkillData.EffectsFrames.AddAttachname(builder, attachnameOffset);
						FBSkillData.EffectsFrames.AddPlaytype(builder, (int)((sbyte)effectsFrames.playtype));
						FBSkillData.EffectsFrames.AddTimetype(builder, (int)((sbyte)effectsFrames.timetype));
						FBSkillData.EffectsFrames.AddTime(builder, effectsFrames.time);
						FBSkillData.EffectsFrames.AddEffectAsset(builder, effectAssetOffset);
						FBSkillData.EffectsFrames.AddAttachPoint(builder, (int)((sbyte)effectsFrames.attachPoint));
						FBSkillData.EffectsFrames.AddLocalPosition(builder, Vector3.CreateVector3(builder, effectsFrames.localPosition.x, effectsFrames.localPosition.y, effectsFrames.localPosition.z));
						FBSkillData.EffectsFrames.AddLocalRotation(builder, Quaternion.CreateQuaternion(builder, effectsFrames.localRotation.x, effectsFrames.localRotation.y, effectsFrames.localRotation.z, effectsFrames.localRotation.w));
						FBSkillData.EffectsFrames.AddLocalScale(builder, Vector3.CreateVector3(builder, effectsFrames.localScale.x, effectsFrames.localScale.y, effectsFrames.localScale.z));
						FBSkillData.EffectsFrames.AddEffecttype(builder, effectsFrames.effecttype);
						FBSkillData.EffectsFrames.AddLoop(builder, effectsFrames.loop);
						FBSkillData.EffectsFrames.AddLoopLoop(builder, effectsFrames.loopLoop);
						list.Add(FBSkillData.EffectsFrames.EndEffectsFrames(builder));
					}
					return FBSkillData.CreateEffectFramesVector(builder, list.ToArray());
				}
				return default(VectorOffset);
			}), this.Call<VectorOffset>(delegate
			{
				if (editorData.entityFrames != null && editorData.entityFrames.Length > 0)
				{
					List<Offset<FBSkillData.EntityFrames>> list = new List<Offset<FBSkillData.EntityFrames>>();
					for (int i = 0; i < editorData.entityFrames.Length; i++)
					{
						global::EntityFrames entityFrames = editorData.entityFrames[i];
						StringOffset nameOffset = this.CreateString(entityFrames.name);
						StringOffset entityAssetOffset = this.CreateString(entityFrames.entityAsset.m_AssetPath);
						VectorOffset resIDListOffset = default(VectorOffset);
						if (entityFrames.resIDList != null && entityFrames.resIDList.Length > 0)
						{
							resIDListOffset = FBSkillData.EntityFrames.CreateResIDListVector(builder, entityFrames.resIDList);
						}
						FBSkillData.EntityFrames.StartEntityFrames(builder);
						FBSkillData.EntityFrames.AddName(builder, nameOffset);
						FBSkillData.EntityFrames.AddResID(builder, entityFrames.resID);
						FBSkillData.EntityFrames.AddType(builder, (int)((sbyte)entityFrames.type));
						FBSkillData.EntityFrames.AddRandomResID(builder, entityFrames.randomResID);
						FBSkillData.EntityFrames.AddResIDList(builder, resIDListOffset);
						FBSkillData.EntityFrames.AddStartFrames(builder, entityFrames.startFrames);
						FBSkillData.EntityFrames.AddEntityAsset(builder, entityAssetOffset);
						FBSkillData.EntityFrames.AddGravity(builder, Vector2.CreateVector2(builder, entityFrames.gravity.x, entityFrames.gravity.y));
						FBSkillData.EntityFrames.AddSpeed(builder, entityFrames.speed);
						FBSkillData.EntityFrames.AddAngle(builder, entityFrames.angle);
						FBSkillData.EntityFrames.AddIsAngleWithEffect(builder, entityFrames.isAngleWithEffect);
						FBSkillData.EntityFrames.AddEmitposition(builder, Vector2.CreateVector2(builder, entityFrames.emitposition.x, entityFrames.emitposition.y));
						FBSkillData.EntityFrames.AddEmitPositionZ(builder, entityFrames.emitPositionZ);
						FBSkillData.EntityFrames.AddAxisType(builder, (int)((sbyte)entityFrames.axisType));
						FBSkillData.EntityFrames.AddShockTime(builder, entityFrames.shockTime);
						FBSkillData.EntityFrames.AddShockSpeed(builder, entityFrames.shockSpeed);
						FBSkillData.EntityFrames.AddShockRangeX(builder, entityFrames.shockRangeX);
						FBSkillData.EntityFrames.AddShockRangeY(builder, entityFrames.shockRangeY);
						FBSkillData.EntityFrames.AddIsRotation(builder, entityFrames.isRotation);
						FBSkillData.EntityFrames.AddRotateSpeed(builder, entityFrames.rotateSpeed);
						FBSkillData.EntityFrames.AddMoveSpeed(builder, entityFrames.moveSpeed);
						FBSkillData.EntityFrames.AddFollowRotate(builder, entityFrames.followRotate);
						if (entityFrames.rotateInitDegree != 0)
						{
							Debugger.LogError("cur.rotateInitDegree:" + entityFrames.rotateInitDegree);
						}
						FBSkillData.EntityFrames.AddRotateInitDegree(builder, entityFrames.rotateInitDegree);
						FBSkillData.EntityFrames.AddSceneShock(builder, FBSkillData.ShockInfo.CreateShockInfo(builder, entityFrames.sceneShock.shockTime, entityFrames.sceneShock.shockSpeed, entityFrames.sceneShock.shockRangeX, entityFrames.sceneShock.shockRangeY));
						FBSkillData.EntityFrames.AddHitFallUP(builder, entityFrames.hitFallUP);
						FBSkillData.EntityFrames.AddForceY(builder, entityFrames.forceY);
						FBSkillData.EntityFrames.AddHurtID(builder, entityFrames.hurtID);
						FBSkillData.EntityFrames.AddLifeTime(builder, entityFrames.lifeTime);
						FBSkillData.EntityFrames.AddHitThrough(builder, entityFrames.hitThrough);
						FBSkillData.EntityFrames.AddHitCount(builder, entityFrames.hitCount);
						FBSkillData.EntityFrames.AddDistance(builder, entityFrames.distance);
						FBSkillData.EntityFrames.AddAttackCountExceedPlayExtDead(builder, entityFrames.attackCountExceedPlayExtDead);
						FBSkillData.EntityFrames.AddHitGroundClick(builder, entityFrames.hitGroundClick);
						FBSkillData.EntityFrames.AddDelayDead(builder, entityFrames.delayDead);
						FBSkillData.EntityFrames.AddOffsetType(builder, (int)((sbyte)entityFrames.offsetType));
						FBSkillData.EntityFrames.AddTargetChooseType(builder, (int)((sbyte)entityFrames.targetChooseType));
						FBSkillData.EntityFrames.AddRange(builder, Vector2.CreateVector2(builder, entityFrames.range.x, entityFrames.range.y));
						FBSkillData.EntityFrames.AddBoomerangeDistance(builder, entityFrames.boomerangeDistance);
						FBSkillData.EntityFrames.AddStayDuration(builder, entityFrames.stayDuration);
						FBSkillData.EntityFrames.AddParaSpeed(builder, entityFrames.paraSpeed);
						FBSkillData.EntityFrames.AddParaGravity(builder, entityFrames.paraGravity);
						FBSkillData.EntityFrames.AddUseRandomLaunch(builder, entityFrames.useRandomLaunch);
						FBSkillData.EntityFrames.AddRandomLaunchInfo(builder, FBSkillData.RandomLaunchInfo.CreateRandomLaunchInfo(builder, entityFrames.randomLaunchInfo.num, entityFrames.randomLaunchInfo.isNumRand, entityFrames.randomLaunchInfo.numRandRange.x, entityFrames.randomLaunchInfo.numRandRange.y, entityFrames.randomLaunchInfo.interval, entityFrames.randomLaunchInfo.rangeRadius, entityFrames.randomLaunchInfo.isFullScene));
						FBSkillData.EntityFrames.AddOnCollideDie(builder, entityFrames.onCollideDie);
						FBSkillData.EntityFrames.AddOnXInBlockDie(builder, entityFrames.onXInBlockDie);
						FBSkillData.EntityFrames.AddChangeForceBehindOther(builder, entityFrames.changForceBehindOther);
						FBSkillData.EntityFrames.AddChangeFace(builder, entityFrames.changeFace);
						list.Add(FBSkillData.EntityFrames.EndEntityFrames(builder));
					}
					return FBSkillData.CreateEntityFramesVector(builder, list.ToArray());
				}
				return default(VectorOffset);
			}), this.Call<VectorOffset>(delegate
			{
				if (editorData.frameTags != null && editorData.frameTags.Length > 0)
				{
					List<Offset<FBSkillData.DSkillFrameTag>> list = new List<Offset<FBSkillData.DSkillFrameTag>>();
					for (int i = 0; i < editorData.frameTags.Length; i++)
					{
						global::DSkillFrameTag dskillFrameTag = editorData.frameTags[i];
						list.Add(FBSkillData.DSkillFrameTag.CreateDSkillFrameTag(builder, default(StringOffset), dskillFrameTag.startframe, dskillFrameTag.length, (int)((short)dskillFrameTag.tag), this.CreateString(dskillFrameTag.tagFlag)));
					}
					return FBSkillData.CreateFrameTagsVector(builder, list.ToArray());
				}
				return default(VectorOffset);
			}), this.Call<VectorOffset>(delegate
			{
				if (editorData.frameGrap != null && editorData.frameGrap.Length > 0)
				{
					List<Offset<FBSkillData.DSkillFrameGrap>> list = new List<Offset<FBSkillData.DSkillFrameGrap>>();
					for (int i = 0; i < editorData.frameGrap.Length; i++)
					{
						global::DSkillFrameGrap dskillFrameGrap = editorData.frameGrap[i];
						FBSkillData.DSkillFrameGrap.StartDSkillFrameGrap(builder);
						FBSkillData.DSkillFrameGrap.AddStartframe(builder, dskillFrameGrap.startframe);
						FBSkillData.DSkillFrameGrap.AddLength(builder, dskillFrameGrap.length);
						FBSkillData.DSkillFrameGrap.AddOp(builder, (int)dskillFrameGrap.op);
						FBSkillData.DSkillFrameGrap.AddFaceGraber(builder, dskillFrameGrap.faceGraber);
						FBSkillData.DSkillFrameGrap.AddTargetPos(builder, Vector3.CreateVector3(builder, dskillFrameGrap.targetPos.x, dskillFrameGrap.targetPos.y, dskillFrameGrap.targetPos.z));
						FBSkillData.DSkillFrameGrap.AddTargetAction(builder, (int)dskillFrameGrap.targetAction);
						list.Add(FBSkillData.DSkillFrameGrap.EndDSkillFrameGrap(builder));
					}
					return FBSkillData.CreateFrameGrapVector(builder, list.ToArray());
				}
				return default(VectorOffset);
			}), this.Call<VectorOffset>(delegate
			{
				if (editorData.stateop != null && editorData.stateop.Length > 0)
				{
					List<Offset<FBSkillData.DSkillFrameStateOp>> list = new List<Offset<FBSkillData.DSkillFrameStateOp>>();
					for (int i = 0; i < editorData.stateop.Length; i++)
					{
						global::DSkillFrameStateOp dskillFrameStateOp = editorData.stateop[i];
						list.Add(FBSkillData.DSkillFrameStateOp.CreateDSkillFrameStateOp(builder, default(StringOffset), dskillFrameStateOp.startframe, dskillFrameStateOp.length, (int)((sbyte)dskillFrameStateOp.op), (int)((sbyte)dskillFrameStateOp.state), dskillFrameStateOp.idata1, dskillFrameStateOp.idata2, dskillFrameStateOp.fdata1, dskillFrameStateOp.fdata2, (int)((sbyte)dskillFrameStateOp.statetag)));
					}
					return FBSkillData.CreateStateopVector(builder, list.ToArray());
				}
				return default(VectorOffset);
			}), this.Call<VectorOffset>(delegate
			{
				if (editorData.faceAttackerFrames != null && editorData.faceAttackerFrames.Length > 0)
				{
					List<Offset<FBSkillData.DSkillFaceAttacker>> list = new List<Offset<FBSkillData.DSkillFaceAttacker>>();
					for (int i = 0; i < editorData.faceAttackerFrames.Length; i++)
					{
						global::DSkillFaceAttacker dskillFaceAttacker = editorData.faceAttackerFrames[i];
						list.Add(FBSkillData.DSkillFaceAttacker.CreateDSkillFaceAttacker(builder, default(StringOffset), dskillFaceAttacker.startframe, dskillFaceAttacker.length));
					}
					return FBSkillData.CreateFaceAttackerFramesVector(builder, list.ToArray());
				}
				return default(VectorOffset);
			}), this.Call<VectorOffset>(delegate
			{
				if (editorData.properModify != null && editorData.properModify.Length > 0)
				{
					List<Offset<FBSkillData.DSkillPropertyModify>> list = new List<Offset<FBSkillData.DSkillPropertyModify>>();
					for (int i = 0; i < editorData.properModify.Length; i++)
					{
						global::DSkillPropertyModify dskillPropertyModify = editorData.properModify[i];
						list.Add(FBSkillData.DSkillPropertyModify.CreateDSkillPropertyModify(builder, default(StringOffset), dskillPropertyModify.startframe, dskillPropertyModify.length, dskillPropertyModify.tag, (int)((sbyte)dskillPropertyModify.modifyfliter), dskillPropertyModify.value, dskillPropertyModify.movedValue, WeaponClassesOrWhatever.NONE, 0, dskillPropertyModify.jumpToTargetPos, dskillPropertyModify.joyStickControl, dskillPropertyModify.valueAcc, dskillPropertyModify.movedValueAcc, (int)dskillPropertyModify.modifyXBackward, dskillPropertyModify.movedYValue, dskillPropertyModify.movedYValueAcc, dskillPropertyModify.eachFrameModify, dskillPropertyModify.useMovedYValue));
					}
					return FBSkillData.CreateProperModifyVector(builder, list.ToArray());
				}
				return default(VectorOffset);
			}), this.Call<VectorOffset>(delegate
			{
				if (editorData.shocks != null && editorData.shocks.Length > 0)
				{
					List<Offset<FBSkillData.DSkillFrameEventSceneShock>> list = new List<Offset<FBSkillData.DSkillFrameEventSceneShock>>();
					for (int i = 0; i < editorData.shocks.Length; i++)
					{
						global::DSkillFrameEventSceneShock dskillFrameEventSceneShock = editorData.shocks[i];
						list.Add(FBSkillData.DSkillFrameEventSceneShock.CreateDSkillFrameEventSceneShock(builder, default(StringOffset), dskillFrameEventSceneShock.startframe, dskillFrameEventSceneShock.length, dskillFrameEventSceneShock.time, dskillFrameEventSceneShock.speed, dskillFrameEventSceneShock.xrange, dskillFrameEventSceneShock.yrange, false, 0, false, 0f, 0f, 0f, 0));
					}
					return FBSkillData.CreateShocksVector(builder, list.ToArray());
				}
				return default(VectorOffset);
			}), this.Call<VectorOffset>(delegate
			{
				if (editorData.sfx != null && editorData.sfx.Length > 0)
				{
					List<Offset<FBSkillData.DSkillSfx>> list = new List<Offset<FBSkillData.DSkillSfx>>();
					for (int i = 0; i < editorData.sfx.Length; i++)
					{
						global::DSkillSfx dskillSfx = editorData.sfx[i];
						list.Add(FBSkillData.DSkillSfx.CreateDSkillSfx(builder, default(StringOffset), dskillSfx.startframe, dskillSfx.length, builder.CreateString(dskillSfx.soundClipAsset.m_AssetPath), dskillSfx.loop, dskillSfx.soundID));
					}
					return FBSkillData.CreateSfxVector(builder, list.ToArray());
				}
				return default(VectorOffset);
			}), this.Call<VectorOffset>(delegate
			{
				if (editorData.frameEffects != null && editorData.frameEffects.Length > 0)
				{
					List<Offset<FBSkillData.DSkillFrameEffect>> list = new List<Offset<FBSkillData.DSkillFrameEffect>>();
					for (int i = 0; i < editorData.frameEffects.Length; i++)
					{
						global::DSkillFrameEffect dskillFrameEffect = editorData.frameEffects[i];
						list.Add(FBSkillData.DSkillFrameEffect.CreateDSkillFrameEffect(builder, default(StringOffset), dskillFrameEffect.startframe, dskillFrameEffect.length, dskillFrameEffect.effectID, dskillFrameEffect.buffTime, dskillFrameEffect.phaseDelete, dskillFrameEffect.finishDelete, dskillFrameEffect.finishDeleteAll, dskillFrameEffect.useBuffAni, dskillFrameEffect.usePause, dskillFrameEffect.pauseTime, dskillFrameEffect.mechanismId));
					}
					return FBSkillData.CreateFrameEffectsVector(builder, list.ToArray());
				}
				return default(VectorOffset);
			}), this.Call<VectorOffset>(delegate
			{
				if (editorData.cameraMoves != null && editorData.cameraMoves.Length > 0)
				{
					List<Offset<FBSkillData.DSkillCameraMove>> list = new List<Offset<FBSkillData.DSkillCameraMove>>();
					for (int i = 0; i < editorData.cameraMoves.Length; i++)
					{
						global::DSkillCameraMove dskillCameraMove = editorData.cameraMoves[i];
						list.Add(FBSkillData.DSkillCameraMove.CreateDSkillCameraMove(builder, default(StringOffset), dskillCameraMove.startframe, dskillCameraMove.length, dskillCameraMove.offset, dskillCameraMove.duraction, dskillCameraMove.newOffset));
					}
					return FBSkillData.CreateCameraMovesVector(builder, list.ToArray());
				}
				return default(VectorOffset);
			}), this.Call<VectorOffset>(delegate
			{
				if (editorData.walkControl != null && editorData.walkControl.Length > 0)
				{
					List<Offset<FBSkillData.DSkillWalkControl>> list = new List<Offset<FBSkillData.DSkillWalkControl>>();
					for (int i = 0; i < editorData.walkControl.Length; i++)
					{
						global::DSkillWalkControl dskillWalkControl = editorData.walkControl[i];
						list.Add(FBSkillData.DSkillWalkControl.CreateDSkillWalkControl(builder, default(StringOffset), dskillWalkControl.startframe, dskillWalkControl.length, (int)((sbyte)dskillWalkControl.walkMode), dskillWalkControl.walkSpeedPercent, dskillWalkControl.useSkillSpeed, dskillWalkControl.walkSpeedPercent2));
					}
					return FBSkillData.CreateWalkControlVector(builder, list.ToArray());
				}
				return default(VectorOffset);
			}), this.Call<VectorOffset>(delegate
			{
				if (editorData.actions != null && editorData.actions.Length > 0)
				{
					List<Offset<FBSkillData.DActionData>> list = new List<Offset<FBSkillData.DActionData>>();
					for (int i = 0; i < editorData.actions.Length; i++)
					{
						global::DActionData dactionData = editorData.actions[i];
						FBSkillData.DActionData.StartDActionData(builder);
						FBSkillData.DActionData.AddStartframe(builder, dactionData.startframe);
						FBSkillData.DActionData.AddLength(builder, dactionData.length);
						FBSkillData.DActionData.AddActionType(builder, (int)((sbyte)dactionData.actionType));
						FBSkillData.DActionData.AddDuration(builder, dactionData.duration);
						FBSkillData.DActionData.AddDeltaScale(builder, dactionData.deltaScale);
						FBSkillData.DActionData.AddDeltaPos(builder, Vector3.CreateVector3(builder, dactionData.deltaPos.x, dactionData.deltaPos.y, dactionData.deltaPos.z));
						FBSkillData.DActionData.AddIgnoreBlock(builder, dactionData.ignoreBlock);
						list.Add(FBSkillData.DActionData.EndDActionData(builder));
					}
					return FBSkillData.CreateActionsVector(builder, list.ToArray());
				}
				return default(VectorOffset);
			}), this.Call<VectorOffset>(delegate
			{
				if (editorData.buffs != null && editorData.buffs.Length > 0)
				{
					List<Offset<FBSkillData.DSkillBuff>> list = new List<Offset<FBSkillData.DSkillBuff>>();
					VectorOffset vectorOffset = default(VectorOffset);
					for (int i = 0; i < editorData.buffs.Length; i++)
					{
						global::DSkillBuff dskillBuff = editorData.buffs[i];
						VectorOffset buffInfoList = FBSkillData.DSkillBuff.CreateBuffInfoListVector(builder, dskillBuff.buffInfoList);
						list.Add(FBSkillData.DSkillBuff.CreateDSkillBuff(builder, default(StringOffset), dskillBuff.startframe, dskillBuff.length, dskillBuff.buffTime, dskillBuff.buffID, dskillBuff.phaseDelete, buffInfoList, dskillBuff.finishDeleteAll, dskillBuff.level, dskillBuff.levelBySkill));
					}
					return FBSkillData.CreateBuffsVector(builder, list.ToArray());
				}
				return default(VectorOffset);
			}), this.Call<VectorOffset>(delegate
			{
				if (editorData.summons != null && editorData.summons.Length > 0)
				{
					List<Offset<FBSkillData.DSkillSummon>> list = new List<Offset<FBSkillData.DSkillSummon>>();
					VectorOffset vectorOffset = default(VectorOffset);
					for (int i = 0; i < editorData.summons.Length; i++)
					{
						global::DSkillSummon dskillSummon = editorData.summons[i];
						VectorOffset posType = FBSkillData.DSkillSummon.CreatePosType2Vector(builder, dskillSummon.posType2);
						list.Add(FBSkillData.DSkillSummon.CreateDSkillSummon(builder, default(StringOffset), dskillSummon.startframe, dskillSummon.length, dskillSummon.summonID, dskillSummon.summonLevel, dskillSummon.levelGrowBySkill, dskillSummon.summonNum, dskillSummon.posType, posType, dskillSummon.isSameFace, dskillSummon.summonNumLimit));
					}
					return FBSkillData.CreateSummonsVector(builder, list.ToArray());
				}
				return default(VectorOffset);
			}), this.Call<VectorOffset>(delegate
			{
				if (editorData.mechanisms != null && editorData.mechanisms.Length > 0)
				{
					List<Offset<FBSkillData.DSkillMechanism>> list = new List<Offset<FBSkillData.DSkillMechanism>>();
					for (int i = 0; i < editorData.mechanisms.Length; i++)
					{
						global::DSkillMechanism dskillMechanism = editorData.mechanisms[i];
						list.Add(FBSkillData.DSkillMechanism.CreateDSkillMechanism(builder, default(StringOffset), dskillMechanism.startframe, dskillMechanism.length, dskillMechanism.id, dskillMechanism.time, dskillMechanism.level, dskillMechanism.levelBySkill, dskillMechanism.phaseDelete, dskillMechanism.finishDeleteAll));
					}
					return FBSkillData.CreateMechanismsVector(builder, list.ToArray());
				}
				return default(VectorOffset);
			}));
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("[ERRORRRRRRRRRRRRR]:{0}", new object[]
			{
				ex.ToString()
			});
		}
		return default(Offset<FBSkillData>);
	}

	// Token: 0x0601C4BE RID: 115902 RVA: 0x008990C4 File Offset: 0x008974C4
	private Offset<FBSkillDataTable> CreateFBSkillDataTable(FlatBufferBuilder builder, FBSkillDataTools.DSkillDataItem item)
	{
		string filepath = item.filepath;
		StringOffset path = this.CreateString(filepath);
		bool isCommon = filepath.Contains("common", StringComparison.OrdinalIgnoreCase);
		string[] array = filepath.Split(new char[]
		{
			'/'
		});
		StringOffset type = this.CreateString(array[0]);
		Offset<FBSkillData> data = this.CreateFBSkillData(builder, item.skillData);
		return FBSkillDataTable.CreateFBSkillDataTable(builder, path, type, isCommon, data);
	}

	// Token: 0x0601C4BF RID: 115903 RVA: 0x00899128 File Offset: 0x00897528
	public bool CreateFBSkillDataCollection(FlatBufferBuilder builder, List<FBSkillDataTools.DSkillDataItem> collection)
	{
		try
		{
			this.currentBuilder = builder;
			List<Offset<FBSkillDataTable>> list = new List<Offset<FBSkillDataTable>>();
			for (int i = 0; i < collection.Count; i++)
			{
				FBSkillDataTools.DSkillDataItem item = collection[i];
				list.Add(this.CreateFBSkillDataTable(builder, item));
			}
			VectorOffset collectionOffset = FBSkillDataCollection.CreateCollectionVector(builder, list.ToArray());
			FBSkillDataCollection.StartFBSkillDataCollection(builder);
			FBSkillDataCollection.AddCollection(builder, collectionOffset);
			Offset<FBSkillDataCollection> offset = FBSkillDataCollection.EndFBSkillDataCollection(builder);
			FBSkillDataCollection.FinishFBSkillDataCollectionBuffer(builder, offset);
		}
		catch (Exception ex)
		{
			Debug.LogError("FBSKillDataCollection Error!!" + ex.Message + ex.StackTrace);
			return false;
		}
		return true;
	}

	// Token: 0x040137CF RID: 79823
	private FlatBufferBuilder currentBuilder;

	// Token: 0x02004B41 RID: 19265
	// (Invoke) Token: 0x0601C4C1 RID: 115905
	private delegate void AddString(FlatBufferBuilder builder, StringOffset StringOffset);

	// Token: 0x02004B42 RID: 19266
	public struct DSkillDataItem
	{
		// Token: 0x0601C4C4 RID: 115908 RVA: 0x008991DC File Offset: 0x008975DC
		public DSkillDataItem(string path, DSkillData data)
		{
			this._filepath = path;
			this._skillData = data;
		}

		// Token: 0x170027CB RID: 10187
		// (get) Token: 0x0601C4C5 RID: 115909 RVA: 0x008991EC File Offset: 0x008975EC
		public string filepath
		{
			get
			{
				return this._filepath;
			}
		}

		// Token: 0x170027CC RID: 10188
		// (get) Token: 0x0601C4C6 RID: 115910 RVA: 0x008991F4 File Offset: 0x008975F4
		public DSkillData skillData
		{
			get
			{
				return this._skillData;
			}
		}

		// Token: 0x040137D0 RID: 79824
		private string _filepath;

		// Token: 0x040137D1 RID: 79825
		private DSkillData _skillData;
	}
}
