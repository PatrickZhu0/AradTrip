using System;
using System.Collections.Generic;
using FBSkillData;
using GameClient;
using ProtoTable;
using UnityEngine;

// Token: 0x02004132 RID: 16690
public class BDEntityActionInfo
{
	// Token: 0x06016B6A RID: 93034 RVA: 0x006E79C0 File Offset: 0x006E5DC0
	public BDEntityActionInfo()
	{
		this.fActionHurtLevel = 60f;
		this.fFramesSpeed = 1f;
		this.fActionForcex = 4f;
		this.fActionForcey = 0f;
		this.iActionType = 0;
		this.bLoop = false;
		this.bAnimLoop = false;
		this.bAnimLoop1 = false;
	}

	// Token: 0x06016B6B RID: 93035 RVA: 0x006E7A54 File Offset: 0x006E5E54
	private void SetVector3(ref UnityEngine.Vector3 dest, FBSkillData.Vector3 source)
	{
		dest.x = source.X;
		dest.y = source.Y;
		dest.z = source.Z;
	}

	// Token: 0x06016B6C RID: 93036 RVA: 0x006E7A7A File Offset: 0x006E5E7A
	private void SetVec3(ref Vec3 dest, FBSkillData.Vector3 source)
	{
		dest.x = source.X;
		dest.y = source.Y;
		dest.z = source.Z;
	}

	// Token: 0x06016B6D RID: 93037 RVA: 0x006E7AA0 File Offset: 0x006E5EA0
	private void SetVector2(ref UnityEngine.Vector2 dest, FBSkillData.Vector2 source)
	{
		dest.x = source.X;
		dest.y = source.Y;
	}

	// Token: 0x06016B6E RID: 93038 RVA: 0x006E7ABA File Offset: 0x006E5EBA
	private void SetQuan(ref UnityEngine.Quaternion dest, FBSkillData.Quaternion source)
	{
		dest.x = source.X;
		dest.y = source.Y;
		dest.z = source.Z;
		dest.w = source.W;
	}

	// Token: 0x06016B6F RID: 93039 RVA: 0x006E7AEC File Offset: 0x006E5EEC
	private void SetEffectsFrames(ref global::EffectsFrames effectsFrames, FBSkillData.EffectsFrames source)
	{
		effectsFrames.name = source.Name;
		effectsFrames.effectResID = source.EffectResID;
		effectsFrames.startFrames = source.StartFrames;
		effectsFrames.endFrames = source.EndFrames;
		effectsFrames.attachname = source.Attachname;
		effectsFrames.playtype = (EffectPlayType)source.Playtype;
		effectsFrames.timetype = (EffectTimeType)source.Timetype;
		effectsFrames.time = source.Time;
		effectsFrames.effectAsset = new DAssetObject(source.EffectAsset, false);
		effectsFrames.attachPoint = (EffectAttachPoint)source.AttachPoint;
		this.SetVector3(ref effectsFrames.localPosition, source.LocalPosition);
		this.SetQuan(ref effectsFrames.localRotation, source.LocalRotation);
		this.SetVector3(ref effectsFrames.localScale, source.LocalScale);
		effectsFrames.effecttype = source.Effecttype;
		effectsFrames.loop = source.Loop;
		effectsFrames.loopLoop = source.LoopLoop;
		effectsFrames.onlyLocalSee = source.OnlyLocalSee;
	}

	// Token: 0x06016B70 RID: 93040 RVA: 0x006E7BF0 File Offset: 0x006E5FF0
	private void SetEntityFrames(ref global::EntityFrames dest, FBSkillData.EntityFrames source)
	{
		dest.name = source.Name;
		dest.resID = source.ResID;
		dest.randomResID = source.RandomResID;
		dest.resIDList = new int[source.ResIDListLength];
		for (int i = 0; i < source.ResIDListLength; i++)
		{
			dest.resIDList[i] = source.GetResIDList(i);
		}
		dest.type = (EntityType)source.Type;
		dest.startFrames = source.StartFrames;
		dest.entityAsset = new DAssetObject(source.EntityAsset, false);
		this.SetVector2(ref dest.gravity, source.Gravity);
		dest.speed = source.Speed;
		dest.angle = source.Angle;
		dest.isAngleWithEffect = source.IsAngleWithEffect;
		this.SetVector2(ref dest.emitposition, source.Emitposition);
		dest.emitPositionZ = source.EmitPositionZ;
		dest.axisType = (AxisType)source.AxisType;
		dest.shockTime = source.ShockTime;
		dest.shockSpeed = source.ShockSpeed;
		dest.shockRangeX = source.ShockRangeX;
		dest.shockRangeY = source.ShockRangeY;
		dest.isRotation = source.IsRotation;
		dest.rotateSpeed = source.RotateSpeed;
		dest.moveSpeed = source.MoveSpeed;
		dest.rotateInitDegree = source.RotateInitDegree;
		dest.followRotate = source.FollowRotate;
		dest.sceneShock = default(global::ShockInfo);
		FBSkillData.ShockInfo sceneShock = source.SceneShock;
		dest.sceneShock.shockRangeX = source.ShockRangeX;
		dest.sceneShock.shockRangeY = source.ShockRangeY;
		dest.sceneShock.shockSpeed = source.ShockSpeed;
		dest.sceneShock.shockTime = source.ShockTime;
		dest.hitFallUP = source.HitFallUP;
		dest.forceY = source.ForceY;
		dest.hurtID = source.HurtID;
		dest.lifeTime = source.LifeTime;
		dest.hitThrough = source.HitThrough;
		dest.hitCount = source.HitCount;
		dest.distance = source.Distance;
		dest.attackCountExceedPlayExtDead = source.AttackCountExceedPlayExtDead;
		dest.hitGroundClick = source.HitGroundClick;
		dest.delayDead = source.DelayDead;
		dest.offsetType = (OffsetType)source.OffsetType;
		dest.targetChooseType = (TargetChooseType)source.TargetChooseType;
		this.SetVector2(ref dest.range, source.Range);
		dest.boomerangeDistance = source.BoomerangeDistance;
		dest.stayDuration = source.StayDuration;
		dest.paraSpeed = source.ParaSpeed;
		dest.paraGravity = source.ParaGravity;
		dest.useRandomLaunch = source.UseRandomLaunch;
		dest.randomLaunchInfo = default(global::RandomLaunchInfo);
		FBSkillData.RandomLaunchInfo randomLaunchInfo = source.RandomLaunchInfo;
		dest.randomLaunchInfo.num = randomLaunchInfo.Num;
		dest.randomLaunchInfo.isNumRand = randomLaunchInfo.IsNumRand;
		this.SetVector2(ref dest.randomLaunchInfo.numRandRange, randomLaunchInfo.NumRandRange);
		dest.randomLaunchInfo.interval = randomLaunchInfo.Interval;
		dest.randomLaunchInfo.rangeRadius = randomLaunchInfo.RangeRadius;
		dest.randomLaunchInfo.isFullScene = randomLaunchInfo.IsFullScene;
		dest.onCollideDie = source.OnCollideDie;
		dest.onXInBlockDie = source.OnXInBlockDie;
		dest.changForceBehindOther = source.ChangeForceBehindOther;
		dest.changeFace = source.ChangeFace;
	}

	// Token: 0x06016B71 RID: 93041 RVA: 0x006E7F79 File Offset: 0x006E6379
	private string GetSafeString(string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			return string.Empty;
		}
		return value;
	}

	// Token: 0x06016B72 RID: 93042 RVA: 0x006E7F90 File Offset: 0x006E6390
	public bool InitWithFlatBuffer(FBSkillData.FBSkillData dataRes)
	{
		if (dataRes == null)
		{
			return false;
		}
		this.moveName = this.GetSafeString(dataRes.MoveName);
		this.skillID = dataRes.SkillID;
		this.actionName = this.GetSafeString(dataRes.AnimationName);
		this.relatedAttackSpeed = dataRes.RelatedAttackSpeed;
		this.attackSpeed = dataRes.AttackSpeed;
		this.iLogicFramesNum = dataRes.TotalFrames;
		this.hitEffect = null;
		this.hitEffectAsset = new DAssetObject(dataRes.HitEffect, false);
		this.hitEffectInfoTableId = 0;
		this.hitSFX = null;
		this.hitSFXID = dataRes.HitSFXID;
		if (this.hitSFXID > 0)
		{
			this.hitSFXIDData = Singleton<TableManager>.GetInstance().GetTableItem<SoundTable>(this.hitSFXID, string.Empty, string.Empty);
		}
		this.iActionType = dataRes.HurtType;
		this.fActionForcex = dataRes.Forcex;
		this.fActionForcey = dataRes.Forcey;
		this.animationspeed = dataRes.AnimationSpeed;
		if (dataRes.HurtTime > 0f)
		{
			this.hurtTime = dataRes.HurtTime;
		}
		if (dataRes.HurtPause == 1)
		{
			this.hurtPause = true;
		}
		this.hurtPauseTime = dataRes.HurtPauseTime;
		if (dataRes.Skilltime > 0f)
		{
			this.skillTotalTime = IntMath.Float2Int(dataRes.Skilltime, 1000);
		}
		this.skillPriority = dataRes.SkillPriority;
		this.fLogicFrameDeltaTime = new VFactor(1L, (long)dataRes.Fps);
		this.fRealFramesTime = (this.iLogicFramesNum - 1) * 1000 / dataRes.Fps;
		this.fFramesSpeed = 1f;
		if (dataRes.IsLoop != 0)
		{
			this.bLoop = true;
		}
		if (dataRes.LoopAnimation)
		{
			this.bAnimLoop = dataRes.LoopAnimation;
		}
		if (dataRes.LoopAnimation1)
		{
			this.bAnimLoop1 = dataRes.LoopAnimation1;
		}
		this.comboStartFrame = dataRes.CmboStartFrame;
		this.comboSkillID = dataRes.CmboSkillID;
		int skillPhasesLength = dataRes.SkillPhasesLength;
		if (skillPhasesLength > 0)
		{
			this.skillPhases = new int[skillPhasesLength];
			for (int i = 0; i < skillPhasesLength; i++)
			{
				this.skillPhases[i] = dataRes.GetSkillPhases(i);
			}
		}
		this.triggerType = (TriggerNextPhaseType)dataRes.TriggerType;
		this.useSpellBar = dataRes.UeSpellBar;
		if (this.useSpellBar)
		{
			this.spellBarTime = dataRes.SellBarTime;
		}
		this.useCharge = dataRes.IsCharge;
		if (this.useCharge)
		{
			FBSkillData.ChargeConfig chargeConfig = dataRes.ChargeConfig;
			this.chargeConfig.repeatPhase = chargeConfig.RepeatPhase;
			this.chargeConfig.changePhase = chargeConfig.ChangePhase;
			this.chargeConfig.switchPhaseID = chargeConfig.SwitchPhaseID;
			this.chargeConfig.chargeDuration = chargeConfig.ChargeDuration;
			this.chargeConfig.chargeMinDuration = chargeConfig.ChargeMinDuration;
			this.chargeConfig.effect = chargeConfig.Effect;
			this.chargeConfig.locator = chargeConfig.Locator;
			this.chargeConfig.buffInfo = chargeConfig.BuffInfo;
			this.chargeConfig.playBuffAni = chargeConfig.PlayBuffAni;
		}
		this.useSpecialOperation = dataRes.IsSpeicalOperate;
		if (this.useSpecialOperation)
		{
			FBSkillData.OperationConfig operationConfig = dataRes.OperationConfig;
			this.operationConfig.changePhase = operationConfig.ChangePhase;
			int changeSkillIDsLength = operationConfig.ChangeSkillIDsLength;
			this.operationConfig.changeSkillIDs = new int[changeSkillIDsLength];
			for (int j = 0; j < changeSkillIDsLength; j++)
			{
				this.operationConfig.changeSkillIDs[j] = operationConfig.GetChangeSkillIDs(j);
			}
		}
		this.useSelectSeatJoystick = dataRes.IsUseSelectSeatJoystick;
		FBSkillData.SkillJoystickConfig skillJoystickConfig = dataRes.SkillJoystickConfig;
		this.skillJoystickConfig.mode = (SkillJoystickMode)skillJoystickConfig.Mode;
		this.skillJoystickConfig.effectName = skillJoystickConfig.EffectName;
		this.SetVector3(ref this.skillJoystickConfig.effectMoveSpeed, skillJoystickConfig.EffectMoveSpeed);
		this.SetVector3(ref this.skillJoystickConfig.effectMoveRange, skillJoystickConfig.EffectMoveRange);
		int skillEventsLength = dataRes.SkillEventsLength;
		this.skillEvents = new global::SkillEvent[skillEventsLength];
		for (int k = 0; k < skillEventsLength; k++)
		{
			FBSkillData.SkillEvent skillEvent = dataRes.GetSkillEvents(k);
			this.skillEvents[k] = new global::SkillEvent();
			this.skillEvents[k].eventType = (EventCommand)skillEvent.EventType;
			this.skillEvents[k].eventAction = (SkillAction)skillEvent.EventAction;
			this.skillEvents[k].paramter = skillEvent.Paramter;
			this.skillEvents[k].workPhase = skillEvent.WorkPhase;
		}
		this.cameraRestore = dataRes.CameraRestore;
		this.cameraRestoreTime = dataRes.CameraRestoreTime;
		this.grabData.endForcex = dataRes.GrabEndForceX;
		this.grabData.endForcey = dataRes.GrabEndForceY;
		this.grabData.posx = dataRes.GrabPosx;
		this.grabData.posy = dataRes.GrabPosy;
		this.grabData.grabNum = dataRes.GrabNum;
		this.grabData.grabMoveSpeed = dataRes.GrabMoveSpeed;
		float grabTime = dataRes.GrabTime;
		if (grabTime > 0f)
		{
			this.grabData.duraction = IntMath.Float2Int(grabTime * 1000f);
		}
		this.grabData.endForceType = dataRes.GrabEndEffectType;
		int grabAction = dataRes.GrabAction;
		if (grabAction != 0)
		{
			this.grabData.action = grabAction;
		}
		this.grabData.quickPressDismis = dataRes.GrabSupportQuickPressDismis;
		this.grabData.notGrabBati = dataRes.NotGrabBati;
		this.grabData.notGrabGeDang = dataRes.NotGrabGeDang;
		this.grabData.notUseGrabSetPos = dataRes.NotUseGrabSetPos;
		this.grabData.notGrabToBlock = dataRes.NotGrabToBlock;
		this.grabData.buffInfoId = dataRes.BuffInfoId;
		this.grabData.buffInfoIdToSelf = dataRes.BuffInfoIdToSelf;
		this.grabData.buffInfoIDToOther = dataRes.BuffInfoIdToOther;
		for (int l = 0; l < this.iLogicFramesNum; l++)
		{
			BDEntityActionFrameData bdentityActionFrameData = new BDEntityActionFrameData();
			bdentityActionFrameData.pAttackData = new BDDBoxData();
			FBSkillData.HurtDecisionBox hurtBlocks = dataRes.GetHurtBlocks(l);
			int boxsLength = hurtBlocks.BoxsLength;
			if (hurtBlocks != null && boxsLength > 0)
			{
				bdentityActionFrameData.pAttackData.zDim = hurtBlocks.ZDim;
				bdentityActionFrameData.pAttackData.hurtID = hurtBlocks.HurtID;
				if (bdentityActionFrameData.pAttackData.hurtID > 0)
				{
					EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(bdentityActionFrameData.pAttackData.hurtID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						bdentityActionFrameData.pAttackData.hurtType = (int)tableItem.EffectTargetType;
					}
					else
					{
						Logger.LogErrorFormat("技能配置文件{0}的攻击框没有{1}的触发效果ID", new object[]
						{
							dataRes._name,
							bdentityActionFrameData.pAttackData.hurtID
						});
					}
				}
				for (int m = 0; m < boxsLength; m++)
				{
					FBSkillData.ShapeBox boxs = hurtBlocks.GetBoxs(m);
					float num = Mathf.Abs(boxs.Size.X);
					float num2 = Mathf.Abs(boxs.Size.Y);
					float x = boxs.Center.X;
					float y = boxs.Center.Y;
					DBoxImp dboxImp = new DBoxImp();
					dboxImp.vBox._min.x = VInt.Float2VIntValue(x - num / 2f);
					dboxImp.vBox._min.y = VInt.Float2VIntValue(y - num2 / 2f);
					dboxImp.vBox._max.x = VInt.Float2VIntValue(x + num / 2f);
					dboxImp.vBox._max.y = VInt.Float2VIntValue(y + num2 / 2f);
					bdentityActionFrameData.pAttackData.vBox.Add(dboxImp);
				}
			}
			bdentityActionFrameData.pDefenseData = new BDDBoxData();
			FBSkillData.DefenceDecisionBox defenceBlocks = dataRes.GetDefenceBlocks(l);
			int boxsLength2 = defenceBlocks.BoxsLength;
			if (defenceBlocks != null && boxsLength2 > 0)
			{
				for (int n = 0; n < boxsLength2; n++)
				{
					FBSkillData.ShapeBox boxs2 = defenceBlocks.GetBoxs(n);
					float num3 = Mathf.Abs(boxs2.Size.X);
					float num4 = Mathf.Abs(boxs2.Size.Y);
					float x2 = boxs2.Center.X;
					float y2 = boxs2.Center.Y;
					DBoxImp dboxImp2 = new DBoxImp();
					dboxImp2.vBox._min.x = VInt.Float2VIntValue(x2 - num3 / 2f);
					dboxImp2.vBox._min.y = VInt.Float2VIntValue(y2 - num4 / 2f);
					dboxImp2.vBox._max.x = VInt.Float2VIntValue(x2 + num3 / 2f);
					dboxImp2.vBox._max.y = VInt.Float2VIntValue(y2 + num4 / 2f);
					bdentityActionFrameData.pDefenseData.vBox.Add(dboxImp2);
				}
			}
			this.vFramesData.Add(bdentityActionFrameData);
		}
		int effectFramesLength = dataRes.EffectFramesLength;
		if (effectFramesLength > 0)
		{
			for (int num5 = 0; num5 < effectFramesLength; num5++)
			{
				FBSkillData.EffectsFrames effectFrames = dataRes.GetEffectFrames(num5);
				global::EffectsFrames effectsFrames = new global::EffectsFrames();
				this.SetEffectsFrames(ref effectsFrames, effectFrames);
				BDPlayEffect item = new BDPlayEffect(effectsFrames);
				int startFrames = effectsFrames.startFrames;
				if (startFrames >= 0 && startFrames < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData2 = this.vFramesData[startFrames];
					if (bdentityActionFrameData2 != null)
					{
						bdentityActionFrameData2.pEvents.Add(item);
					}
				}
			}
		}
		int entityFramesLength = dataRes.EntityFramesLength;
		if (entityFramesLength > 0)
		{
			for (int num6 = 0; num6 < entityFramesLength; num6++)
			{
				FBSkillData.EntityFrames entityFrames = dataRes.GetEntityFrames(num6);
				global::EntityFrames info = new global::EntityFrames();
				this.SetEntityFrames(ref info, entityFrames);
				BDGenProjectile item2 = new BDGenProjectile(info);
				int startFrames2 = entityFrames.StartFrames;
				if (startFrames2 < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData3 = this.vFramesData[startFrames2];
					if (bdentityActionFrameData3 != null)
					{
						bdentityActionFrameData3.pEvents.Add(item2);
					}
				}
			}
		}
		int frameTagsLength = dataRes.FrameTagsLength;
		if (frameTagsLength > 0)
		{
			for (int num7 = 0; num7 < frameTagsLength; num7++)
			{
				FBSkillData.DSkillFrameTag frameTags = dataRes.GetFrameTags(num7);
				int startframe = frameTags.Startframe;
				if (startframe >= 0 && startframe < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData4 = this.vFramesData[startframe];
					int tag = frameTags.Tag;
					if (BeUtility.CheckHaveTag(tag, 1))
					{
						bdentityActionFrameData4.kFlag.SetFlag(16, null);
					}
					else if (BeUtility.CheckHaveTag(tag, 2))
					{
						bdentityActionFrameData4.kFlag.SetFlag(32, null);
					}
					else if (BeUtility.CheckHaveTag(tag, 4))
					{
						bdentityActionFrameData4.kFlag.SetFlag(64, null);
					}
					else if (BeUtility.CheckHaveTag(tag, 8))
					{
						bdentityActionFrameData4.kFlag.SetFlag(128, null);
					}
					else if (BeUtility.CheckHaveTag(tag, 16))
					{
						bdentityActionFrameData4.kFlag.SetFlag(256, null);
					}
					else if (BeUtility.CheckHaveTag(tag, 32))
					{
						bdentityActionFrameData4.kFlag.SetFlag(512, null);
					}
					else if (BeUtility.CheckHaveTag(tag, 64))
					{
						bdentityActionFrameData4.kFlag.SetFlag(1024, frameTags.TagFlag);
					}
					else if (BeUtility.CheckHaveTag(tag, 128))
					{
						bdentityActionFrameData4.kFlag.SetFlag(2048, null);
					}
					else if (BeUtility.CheckHaveTag(tag, 256))
					{
						bdentityActionFrameData4.kFlag.SetFlag(4096, null);
					}
				}
			}
		}
		int frameGrapLength = dataRes.FrameGrapLength;
		if (frameGrapLength > 0)
		{
			for (int num8 = 0; num8 < frameGrapLength; num8++)
			{
				FBSkillData.DSkillFrameGrap frameGrap = dataRes.GetFrameGrap(num8);
				BDEventBase bdeventBase = null;
				int startframe2 = frameGrap.Startframe;
				if (startframe2 < this.vFramesData.Count)
				{
					DSFGrapOp op = (DSFGrapOp)frameGrap.Op;
					BDEntityActionFrameData bdentityActionFrameData5 = this.vFramesData[startframe2];
					if (op == DSFGrapOp.GRAP_INTERRUPT || op == DSFGrapOp.GRAP_CHANGE_TARGETPOS || op == DSFGrapOp.GRAP_STOPCHANGE_TARGETPOS || op == DSFGrapOp.GRAP_CHANGE_TARGETACTION || op == DSFGrapOp.GRAP_INTERRUPT_ATTACKBOX)
					{
						Vec3 position = default(Vec3);
						this.SetVec3(ref position, frameGrap.TargetPos);
						BDSkillSuspend bdskillSuspend = new BDSkillSuspend((int)op, new VInt3(position), frameGrap.FaceGraber, frameGrap.TargetAction);
						bdeventBase = bdskillSuspend;
					}
					else if (op == DSFGrapOp.GRAP_JUDGE || op == DSFGrapOp.GRAP_JUDGE_EXECUTE || op == DSFGrapOp.GRAP_JUDGE_SKIP_PHASE)
					{
						int length = frameGrap.Length;
						for (int num9 = 0; num9 < length; num9++)
						{
							if (startframe2 + num9 < this.vFramesData.Count)
							{
								BDEntityActionFrameData bdentityActionFrameData6 = this.vFramesData[startframe2 + num9];
								bdentityActionFrameData6.kFlag.SetFlag((int)op, null);
							}
						}
					}
					else
					{
						bdentityActionFrameData5.kFlag.SetFlag((int)op, null);
					}
					if (bdeventBase != null)
					{
						bdentityActionFrameData5.pEvents.Add(bdeventBase);
					}
				}
			}
		}
		int stateopLength = dataRes.StateopLength;
		if (stateopLength > 0)
		{
			for (int num10 = 0; num10 < stateopLength; num10++)
			{
				FBSkillData.DSkillFrameStateOp stateop = dataRes.GetStateop(num10);
				int startframe3 = stateop.Startframe;
				if (startframe3 < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData7 = this.vFramesData[startframe3];
					BDStateStackOP bdstateStackOP = new BDStateStackOP(stateop.Op, stateop.State, stateop.Idata1, (float)stateop.Idata2, stateop.Fdata1, stateop.Statetag);
					BDEventBase bdeventBase2 = bdstateStackOP;
					if (bdeventBase2 != null)
					{
						bdentityActionFrameData7.pEvents.Add(bdeventBase2);
					}
				}
			}
		}
		int faceAttackerFramesLength = dataRes.FaceAttackerFramesLength;
		if (faceAttackerFramesLength > 0)
		{
			for (int num11 = 0; num11 < faceAttackerFramesLength; num11++)
			{
				FBSkillData.DSkillFaceAttacker faceAttackerFrames = dataRes.GetFaceAttackerFrames(num11);
				int startframe4 = faceAttackerFrames.Startframe;
				if (startframe4 < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData8 = this.vFramesData[startframe4];
					BDFaceAttacker bdfaceAttacker = new BDFaceAttacker();
					BDEventBase bdeventBase3 = bdfaceAttacker;
					if (bdeventBase3 != null)
					{
						bdentityActionFrameData8.pEvents.Add(bdeventBase3);
					}
				}
			}
		}
		int properModifyLength = dataRes.ProperModifyLength;
		if (properModifyLength > 0)
		{
			for (int num12 = 0; num12 < properModifyLength; num12++)
			{
				FBSkillData.DSkillPropertyModify properModify = dataRes.GetProperModify(num12);
				int startframe5 = properModify.Startframe;
				int num13 = 0;
				while (num13 < properModify.Length && startframe5 + num13 < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData9 = this.vFramesData[startframe5 + num13];
					BDModifySpeed bdmodifySpeed = new BDModifySpeed(properModify.Tag, (DSkillPropertyModifyType)properModify.Modifyfliter, properModify.Value, properModify.MovedValue, properModify.JumpToTargetPos, properModify.JoystickControl, properModify.ValueAcc, properModify.MovedValueAcc, (DModifyXBackward)properModify.ModifyXBackward, properModify.EachFrameModify, properModify.UseMovedYValue, properModify.MovedYValue, properModify.MovedYValueAcc);
					BDEventBase bdeventBase4 = bdmodifySpeed;
					if (bdeventBase4 != null)
					{
						bdentityActionFrameData9.pEvents.Add(bdeventBase4);
					}
					num13++;
				}
			}
		}
		int shocksLength = dataRes.ShocksLength;
		if (shocksLength > 0)
		{
			for (int num14 = 0; num14 < shocksLength; num14++)
			{
				FBSkillData.DSkillFrameEventSceneShock shocks = dataRes.GetShocks(num14);
				int startframe6 = shocks.Startframe;
				if (startframe6 < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData10 = this.vFramesData[startframe6];
					BDSceneShock bdsceneShock;
					if (shocks.IsNew)
					{
						bdsceneShock = new BDSceneShock(shocks.Time, shocks.Num, shocks.Xrange, shocks.Yrange, shocks.Decelerate, shocks.Xreduce, shocks.Yreduce, shocks.Mode, shocks.Radius);
					}
					else
					{
						bdsceneShock = new BDSceneShock(shocks.Time, shocks.Speed, shocks.Xrange, shocks.Yrange);
					}
					BDEventBase bdeventBase5 = bdsceneShock;
					if (bdeventBase5 != null)
					{
						bdentityActionFrameData10.pEvents.Add(bdeventBase5);
					}
				}
			}
		}
		int walkControlLength = dataRes.WalkControlLength;
		if (walkControlLength > 0)
		{
			for (int num15 = 0; num15 < walkControlLength; num15++)
			{
				FBSkillData.DSkillWalkControl walkControl = dataRes.GetWalkControl(num15);
				int startframe7 = walkControl.Startframe;
				if (startframe7 < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData11 = this.vFramesData[startframe7];
					BDSkillWalkControl bdskillWalkControl = new BDSkillWalkControl((SkillWalkMode)walkControl.WalkMode, walkControl.WalkSpeedPercent, walkControl.UseSkillSpeed, walkControl.WalkSpeedPercent2);
					BDEventBase bdeventBase6 = bdskillWalkControl;
					if (bdeventBase6 != null)
					{
						bdentityActionFrameData11.pEvents.Add(bdeventBase6);
					}
				}
			}
		}
		int cameraMovesLength = dataRes.CameraMovesLength;
		if (cameraMovesLength > 0)
		{
			for (int num16 = 0; num16 < cameraMovesLength; num16++)
			{
				FBSkillData.DSkillCameraMove cameraMoves = dataRes.GetCameraMoves(num16);
				int startframe8 = cameraMoves.Startframe;
				if (startframe8 >= 0 && startframe8 < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData12 = this.vFramesData[startframe8];
					BDSkillCameraMove bdskillCameraMove = new BDSkillCameraMove(cameraMoves.Offset, cameraMoves.Duraction, cameraMoves.Newoffset);
					BDEventBase bdeventBase7 = bdskillCameraMove;
					if (bdeventBase7 != null)
					{
						bdentityActionFrameData12.pEvents.Add(bdeventBase7);
					}
				}
			}
		}
		int sfxLength = dataRes.SfxLength;
		if (sfxLength > 0)
		{
			for (int num17 = 0; num17 < sfxLength; num17++)
			{
				FBSkillData.DSkillSfx sfx = dataRes.GetSfx(num17);
				int startframe9 = sfx.Startframe;
				if (startframe9 < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData13 = this.vFramesData[startframe9];
					BDSkillSfx bdskillSfx = new BDSkillSfx(new DAssetObject(sfx.SoundClipAsset, false), sfx.SoundID, sfx.Loop, false, false, false, 0f);
					BDEventBase bdeventBase8 = bdskillSfx;
					if (bdeventBase8 != null)
					{
						bdentityActionFrameData13.pEvents.Add(bdeventBase8);
					}
				}
			}
		}
		int frameEffectsLength = dataRes.FrameEffectsLength;
		if (frameEffectsLength > 0)
		{
			for (int num18 = 0; num18 < frameEffectsLength; num18++)
			{
				FBSkillData.DSkillFrameEffect frameEffects = dataRes.GetFrameEffects(num18);
				int startframe10 = frameEffects.Startframe;
				if (startframe10 < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData14 = this.vFramesData[startframe10];
					int d = IntMath.Float2Int(frameEffects.BuffTime * 1000f);
					if (frameEffects.PhaseDelete)
					{
						d = -1;
					}
					BDSkillFrameEffect bdskillFrameEffect = new BDSkillFrameEffect(frameEffects.EffectID, d, frameEffects.UseBuffAni, frameEffects.UsePause, frameEffects.PauseTime, frameEffects.FinishDelete, frameEffects.FinishDeleteAll, frameEffects.MechanismId);
					BDEventBase bdeventBase9 = bdskillFrameEffect;
					if (bdeventBase9 != null)
					{
						bdentityActionFrameData14.pEvents.Add(bdeventBase9);
					}
				}
			}
		}
		int actionsLength = dataRes.ActionsLength;
		if (actionsLength > 0)
		{
			for (int num19 = 0; num19 < actionsLength; num19++)
			{
				FBSkillData.DActionData actions = dataRes.GetActions(num19);
				int startframe11 = actions.Startframe;
				if (startframe11 < this.vFramesData.Count)
				{
					Vec3 position2 = default(Vec3);
					this.SetVec3(ref position2, actions.DeltaPos);
					BDEntityActionFrameData bdentityActionFrameData15 = this.vFramesData[startframe11];
					BDSkillAction bdskillAction = new BDSkillAction((BeActionType)actions.ActionType, actions.Duration, actions.DeltaScale, new VInt3(position2), actions.IgnoreBlock);
					BDSkillAction bdskillAction2 = bdskillAction;
					if (bdskillAction2 != null)
					{
						bdentityActionFrameData15.pEvents.Add(bdskillAction2);
					}
				}
			}
		}
		int attachFramesLength = dataRes.AttachFramesLength;
		for (int num20 = 0; num20 < attachFramesLength; num20++)
		{
			FBSkillData.EntityAttachFrames attachFrames = dataRes.GetAttachFrames(num20);
			if (attachFrames != null)
			{
				BeAttachFrames beAttachFrames = new BeAttachFrames();
				beAttachFrames.name = attachFrames.Name;
				beAttachFrames.resID = attachFrames.ResID;
				beAttachFrames.start = attachFrames.Start;
				beAttachFrames.end = attachFrames.End;
				beAttachFrames.entityPrefab = null;
				beAttachFrames.entityAsset = new DAssetObject(attachFrames.EntityAsset, false);
				beAttachFrames.attachName = attachFrames.AttachName;
				List<BeAnimationFrame> list = new List<BeAnimationFrame>();
				int animationsLength = attachFrames.AnimationsLength;
				for (int num21 = 0; num21 < animationsLength; num21++)
				{
					BeAnimationFrame item3 = default(BeAnimationFrame);
					FBSkillData.AnimationFrames animations = attachFrames.GetAnimations(num21);
					item3.anim = animations.Anim;
					item3.start = animations.Start;
					item3.speed = animations.Speed;
					list.Add(item3);
				}
				beAttachFrames.animations = list.ToArray();
				this.vAttachFrames.Add(beAttachFrames);
			}
		}
		int buffsLength = dataRes.BuffsLength;
		if (buffsLength > 0)
		{
			for (int num22 = 0; num22 < buffsLength; num22++)
			{
				FBSkillData.DSkillBuff buffs = dataRes.GetBuffs(num22);
				if (buffs != null)
				{
					int startframe12 = buffs.Startframe;
					if (startframe12 < this.vFramesData.Count)
					{
						BDEntityActionFrameData bdentityActionFrameData16 = this.vFramesData[startframe12];
						int d2 = IntMath.Float2Int(buffs.BuffTime * 1000f);
						if (buffs.PhaseDelete)
						{
							d2 = -1;
						}
						List<int> list2 = new List<int>();
						int buffInfoListLength = buffs.BuffInfoListLength;
						for (int num23 = 0; num23 < buffInfoListLength; num23++)
						{
							list2.Add(buffs.GetBuffInfoList(num23));
						}
						BDAddBuffInfoOrBuff bdaddBuffInfoOrBuff = new BDAddBuffInfoOrBuff(buffs.BuffID, list2, d2, buffs.PhaseDelete, buffs.FinishDeleteAll, buffs.Level, buffs.LevelBySkill);
						BDEventBase bdeventBase10 = bdaddBuffInfoOrBuff;
						if (bdeventBase10 != null)
						{
							bdentityActionFrameData16.pEvents.Add(bdeventBase10);
						}
					}
				}
			}
		}
		int summonsLength = dataRes.SummonsLength;
		if (summonsLength > 0)
		{
			for (int num24 = 0; num24 < summonsLength; num24++)
			{
				FBSkillData.DSkillSummon summons = dataRes.GetSummons(num24);
				if (summons != null)
				{
					int startframe13 = summons.Startframe;
					if (startframe13 < this.vFramesData.Count)
					{
						BDEntityActionFrameData bdentityActionFrameData17 = this.vFramesData[startframe13];
						List<int> list3 = new List<int>();
						int posType2Length = summons.PosType2Length;
						for (int num25 = 0; num25 < posType2Length; num25++)
						{
							list3.Add(summons.GetPosType2(num25));
						}
						BDDoSummon bddoSummon = new BDDoSummon(summons.SummonID, summons.SummonLevel, summons.LevelGrowBySkill, summons.SummonNum, summons.PosType, list3, summons.IsSameFace, summons.SummonNumLimit);
						BDEventBase bdeventBase11 = bddoSummon;
						if (bdeventBase11 != null)
						{
							bdentityActionFrameData17.pEvents.Add(bdeventBase11);
						}
					}
				}
			}
		}
		for (int num26 = 0; num26 < dataRes.MechanismsLength; num26++)
		{
			FBSkillData.DSkillMechanism mechanisms = dataRes.GetMechanisms(num26);
			if (mechanisms != null)
			{
				int startframe14 = mechanisms.Startframe;
				if (startframe14 < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData18 = this.vFramesData[startframe14];
					int d3 = IntMath.Float2Int(mechanisms.Time * (float)GlobalLogic.VALUE_1000);
					if (mechanisms.PhaseDelete)
					{
						d3 = -1;
					}
					BDAddMechanism bdaddMechanism = new BDAddMechanism(mechanisms.Id, d3, mechanisms.Level, mechanisms.LevelBySkill, mechanisms.PhaseDelete, mechanisms.FinishDeleteAll);
					BDEventBase bdeventBase12 = bdaddMechanism;
					if (bdeventBase12 != null)
					{
						bdentityActionFrameData18.pEvents.Add(bdeventBase12);
					}
				}
			}
		}
		return true;
	}

	// Token: 0x06016B73 RID: 93043 RVA: 0x006E9754 File Offset: 0x006E7B54
	private static bool CheckSkillNeedLoad(List<string> skillCfgList, SkillFileName sf)
	{
		string fullPath = sf.fullPath;
		if (sf.isPvp)
		{
			return false;
		}
		if (sf.isChiji)
		{
			return false;
		}
		if (skillCfgList != null && !sf.isCommon && sf.folderName.Length > 0)
		{
			bool flag = false;
			for (int i = 0; i < skillCfgList.Count; i++)
			{
				if (string.Compare(sf.folderName, skillCfgList[i], true) == 0)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06016B74 RID: 93044 RVA: 0x006E97E8 File Offset: 0x006E7BE8
	private static void ProcessNewLoadedSkillInfo(BDEntityActionInfo info, string skillFullPath, bool bPreLoadAction, bool collectAnimationNames, List<string> animationNames)
	{
		if (bPreLoadAction)
		{
			PreloadManager.PreloadActionInfo(info, null, null, false);
		}
		if (collectAnimationNames && animationNames != null && !animationNames.Contains(info.actionName))
		{
			animationNames.Add(info.actionName);
		}
		BeActionFrameMgr.AddCached(skillFullPath, info);
	}

	// Token: 0x06016B75 RID: 93045 RVA: 0x006E9838 File Offset: 0x006E7C38
	public static bool SaveLoad(BattleType battleType, string path, List<string> skillCfgList, bool bPreLoadAction, bool collectAnimationNames, List<BDEntityActionInfo> loadedSkillList, List<string> animationNames, List<int> types = null)
	{
		try
		{
			return BDEntityActionInfo.Load(battleType, path, skillCfgList, bPreLoadAction, collectAnimationNames, loadedSkillList, animationNames, null, types);
		}
		catch (Exception ex)
		{
			Logger.LogError("SkillTable Load Error" + ex.Message + ex.StackTrace);
		}
		return false;
	}

	// Token: 0x06016B76 RID: 93046 RVA: 0x006E9894 File Offset: 0x006E7C94
	private static bool Load(BattleType battleType, string path, List<string> skillCfgList, bool bPreLoadAction, bool collectAnimationNames, List<BDEntityActionInfo> loadedSkillList, List<string> animationNames, BeEntity entity = null, List<int> types = null)
	{
		if (string.IsNullOrEmpty(path))
		{
			return false;
		}
		if (loadedSkillList != null)
		{
			loadedSkillList.Clear();
		}
		List<SkillFileName> list = SkillFileListCache.GetCached(path);
		if (list == null)
		{
			return false;
		}
		if (types != null)
		{
			list = BDEntityActionInfo.SkillFileNameListFilter(list, types);
		}
		for (int i = 0; i < list.Count; i++)
		{
			SkillFileName skillFileName = list[i];
			string fullPath = skillFileName.fullPath;
			if (BDEntityActionInfo.CheckSkillNeedLoad(skillCfgList, skillFileName))
			{
				string text = list[i].fullPath;
				if (BattleMain.IsModePvP(battleType) && list[i].pvpPath != null)
				{
					text = list[i].pvpPath;
				}
				else if (BattleMain.IsModeChiji(battleType) && list[i].chijiPath != null)
				{
					text = list[i].chijiPath;
				}
				BDEntityActionInfo bdentityActionInfo = BeActionFrameMgr.GetCached(text);
				if (bdentityActionInfo == null)
				{
					System.Object @object;
					if (Singleton<DebugSettings>.instance.EnableDSkillDataCache)
					{
						@object = BeActionFrameMgr.GetSkillObjectCache(text);
					}
					else
					{
						@object = Singleton<AssetLoader>.instance.LoadRes(text, typeof(DSkillData), true, 0U).obj;
					}
					DSkillData dataRes = @object as DSkillData;
					bdentityActionInfo = new BDEntityActionInfo();
					if (!bdentityActionInfo.InitWithDataRes(dataRes))
					{
						Logger.LogErrorFormat("加载技能文件失败:{0}", new object[]
						{
							text
						});
						goto IL_17E;
					}
					bdentityActionInfo.weaponType = skillFileName.weaponType;
					BDEntityActionInfo.ProcessNewLoadedSkillInfo(bdentityActionInfo, text, bPreLoadAction, collectAnimationNames, animationNames);
				}
				if (loadedSkillList != null)
				{
					loadedSkillList.Add(bdentityActionInfo);
				}
			}
			IL_17E:;
		}
		return true;
	}

	// Token: 0x06016B77 RID: 93047 RVA: 0x006E9A30 File Offset: 0x006E7E30
	private static List<SkillFileName> SkillFileNameListFilter(List<SkillFileName> fileList, List<int> weaponTypes)
	{
		List<SkillFileName> list = new List<SkillFileName>();
		if (weaponTypes != null && fileList != null)
		{
			for (int i = 0; i < fileList.Count; i++)
			{
				if (fileList[i].weaponType == 0 || weaponTypes.Contains(fileList[i].weaponType))
				{
					list.Add(fileList[i]);
				}
			}
		}
		return list;
	}

	// Token: 0x06016B78 RID: 93048 RVA: 0x006E9A9C File Offset: 0x006E7E9C
	public bool InitWithDataRes(DSkillData dataRes)
	{
		if (dataRes == null)
		{
			return false;
		}
		this.moveName = dataRes.moveName;
		this.skillID = dataRes.skillID;
		this.relatedAttackSpeed = dataRes.relatedAttackSpeed;
		this.attackSpeed = dataRes.attackSpeed;
		this.actionName = dataRes.animationName;
		this.iLogicFramesNum = dataRes.totalFrames;
		this.hitEffect = dataRes.goHitEffect;
		this.hitEffectAsset = dataRes.goHitEffectAsset;
		this.hitEffectInfoTableId = dataRes.hitEffectInfoTableId;
		this.hitSFX = dataRes.goSFX;
		this.hitSFXID = dataRes.hitSFXID;
		if (this.hitSFXID > 0)
		{
			this.hitSFXIDData = Singleton<TableManager>.GetInstance().GetTableItem<SoundTable>(this.hitSFXID, string.Empty, string.Empty);
		}
		this.iActionType = dataRes.hurtType;
		this.fActionForcex = dataRes.forcex;
		this.fActionForcey = dataRes.forcey;
		this.animationspeed = dataRes.animationSpeed;
		if (dataRes.hurtTime > 0f)
		{
			this.hurtTime = dataRes.hurtTime;
		}
		if (dataRes.hurtPause == 1)
		{
			this.hurtPause = true;
		}
		this.hurtPauseTime = dataRes.hurtPauseTime;
		if (dataRes.skilltime > 0f)
		{
			this.skillTotalTime = IntMath.Float2Int(dataRes.skilltime, 1000);
		}
		this.skillPriority = dataRes.skillPriority;
		this.fLogicFrameDeltaTime = new VFactor(1L, (long)dataRes.fps);
		this.fRealFramesTime = (this.iLogicFramesNum - 1) * 1000 / dataRes.fps;
		this.fFramesSpeed = 1f;
		if (dataRes.isLoop != 0)
		{
			this.bLoop = true;
		}
		if (dataRes.loopAnimation)
		{
			this.bAnimLoop = dataRes.loopAnimation;
		}
		if (dataRes.loopAnimation1)
		{
			this.bAnimLoop1 = dataRes.loopAnimation1;
		}
		this.comboStartFrame = dataRes.comboStartFrame;
		this.comboSkillID = dataRes.comboSkillID;
		if (dataRes.skillPhases.Length > 0)
		{
			this.skillPhases = new int[dataRes.skillPhases.Length];
			dataRes.skillPhases.CopyTo(this.skillPhases, 0);
		}
		this.triggerType = dataRes.triggerType;
		this.useSpellBar = dataRes.useSpellBar;
		if (this.useSpellBar)
		{
			this.spellBarTime = dataRes.spellBarTime;
		}
		this.useCharge = dataRes.isCharge;
		if (this.useCharge)
		{
			this.chargeConfig = dataRes.chargeConfig;
		}
		this.useSpecialOperation = dataRes.isSpeicalOperate;
		if (this.useSpecialOperation)
		{
			this.operationConfig = dataRes.operationConfig;
		}
		this.useSelectSeatJoystick = dataRes.isUseSelectSeatJoystick;
		this.skillJoystickConfig = dataRes.skillJoystickConfig;
		this.skillEvents = dataRes.skillEvents;
		this.cameraRestore = dataRes.cameraRestore;
		this.cameraRestoreTime = dataRes.cameraRestoreTime;
		this.grabData.endForcex = dataRes.grabEndForceX;
		this.grabData.endForcey = dataRes.grabEndForceY;
		this.grabData.posx = dataRes.grabPosx;
		this.grabData.posy = dataRes.grabPosy;
		this.grabData.grabNum = dataRes.grabNum;
		this.grabData.grabMoveSpeed = dataRes.grabMoveSpeed;
		if (dataRes.grabTime > 0f)
		{
			this.grabData.duraction = IntMath.Float2Int(dataRes.grabTime * (float)GlobalLogic.VALUE_1000);
		}
		this.grabData.endForceType = dataRes.grabEndEffectType;
		if (dataRes.grabAction != 0)
		{
			this.grabData.action = dataRes.grabAction;
		}
		this.grabData.quickPressDismis = dataRes.grabSupportQuickPressDismis;
		this.grabData.notGrabBati = dataRes.notGrabBati;
		this.grabData.notGrabGeDang = dataRes.notGrabGeDang;
		this.grabData.notUseGrabSetPos = dataRes.notUseGrabSetPos;
		this.grabData.notGrabToBlock = dataRes.notGrabToBlock;
		this.grabData.buffInfoId = dataRes.buffInfoId;
		this.grabData.buffInfoIdToSelf = dataRes.buffInfoIdToSelf;
		this.grabData.buffInfoIDToOther = dataRes.buffInfoIDToOther;
		for (int i = 0; i < this.iLogicFramesNum; i++)
		{
			BDEntityActionFrameData bdentityActionFrameData = new BDEntityActionFrameData();
			bdentityActionFrameData.pAttackData = new BDDBoxData();
			global::HurtDecisionBox hurtDecisionBox = dataRes.HurtBlocks[i];
			if (hurtDecisionBox != null && hurtDecisionBox.boxs.Length > 0)
			{
				bdentityActionFrameData.pAttackData.zDim = hurtDecisionBox.zDim;
				bdentityActionFrameData.pAttackData.hurtID = hurtDecisionBox.hurtID;
				if (bdentityActionFrameData.pAttackData.hurtID > 0)
				{
					EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(bdentityActionFrameData.pAttackData.hurtID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						bdentityActionFrameData.pAttackData.hurtType = (int)tableItem.EffectTargetType;
					}
					else
					{
						Logger.LogErrorFormat("技能配置文件{0} id: {1} 的攻击框没有{2}的触发效果ID", new object[]
						{
							dataRes.name,
							dataRes.skillID,
							bdentityActionFrameData.pAttackData.hurtID
						});
					}
				}
				for (int j = 0; j < hurtDecisionBox.boxs.Length; j++)
				{
					global::ShapeBox shapeBox = hurtDecisionBox.boxs[j];
					shapeBox.size.x = Mathf.Abs(shapeBox.size.x);
					shapeBox.size.y = Mathf.Abs(shapeBox.size.y);
					DBoxImp dboxImp = new DBoxImp();
					dboxImp.vBox._min.x = VInt.Float2VIntValue(shapeBox.center.x - shapeBox.size.x / 2f);
					dboxImp.vBox._min.y = VInt.Float2VIntValue(shapeBox.center.y - shapeBox.size.y / 2f);
					dboxImp.vBox._max.x = VInt.Float2VIntValue(shapeBox.center.x + shapeBox.size.x / 2f);
					dboxImp.vBox._max.y = VInt.Float2VIntValue(shapeBox.center.y + shapeBox.size.y / 2f);
					bdentityActionFrameData.pAttackData.vBox.Add(dboxImp);
				}
			}
			bdentityActionFrameData.pDefenseData = new BDDBoxData();
			global::DefenceDecisionBox defenceDecisionBox = dataRes.DefenceBlocks[i];
			if (defenceDecisionBox != null && defenceDecisionBox.boxs.Length > 0)
			{
				for (int k = 0; k < defenceDecisionBox.boxs.Length; k++)
				{
					global::ShapeBox shapeBox2 = defenceDecisionBox.boxs[k];
					shapeBox2.size.x = Mathf.Abs(shapeBox2.size.x);
					shapeBox2.size.y = Mathf.Abs(shapeBox2.size.y);
					DBoxImp dboxImp2 = new DBoxImp();
					dboxImp2.vBox._min.x = VInt.Float2VIntValue(shapeBox2.center.x - shapeBox2.size.x / 2f);
					dboxImp2.vBox._min.y = VInt.Float2VIntValue(shapeBox2.center.y - shapeBox2.size.y / 2f);
					dboxImp2.vBox._max.x = VInt.Float2VIntValue(shapeBox2.center.x + shapeBox2.size.x / 2f);
					dboxImp2.vBox._max.y = VInt.Float2VIntValue(shapeBox2.center.y + shapeBox2.size.y / 2f);
					bdentityActionFrameData.pDefenseData.vBox.Add(dboxImp2);
				}
			}
			this.vFramesData.Add(bdentityActionFrameData);
		}
		if (dataRes.effectFrames != null && dataRes.effectFrames.Length > 0)
		{
			for (int l = 0; l < dataRes.effectFrames.Length; l++)
			{
				global::EffectsFrames effectsFrames = dataRes.effectFrames[l];
				BDPlayEffect item = new BDPlayEffect(effectsFrames);
				int startFrames = effectsFrames.startFrames;
				if (startFrames >= 0 && startFrames < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData2 = this.vFramesData[startFrames];
					if (bdentityActionFrameData2 != null)
					{
						bdentityActionFrameData2.pEvents.Add(item);
					}
				}
			}
		}
		if (dataRes.entityFrames != null && dataRes.entityFrames.Length > 0)
		{
			for (int m = 0; m < dataRes.entityFrames.Length; m++)
			{
				global::EntityFrames entityFrames = dataRes.entityFrames[m];
				BDGenProjectile item2 = new BDGenProjectile(entityFrames);
				int startFrames2 = entityFrames.startFrames;
				if (startFrames2 < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData3 = this.vFramesData[startFrames2];
					if (bdentityActionFrameData3 != null)
					{
						bdentityActionFrameData3.pEvents.Add(item2);
					}
				}
			}
		}
		if (dataRes.frameTags != null && dataRes.frameTags.Length > 0)
		{
			for (int n = 0; n < dataRes.frameTags.Length; n++)
			{
				global::DSkillFrameTag dskillFrameTag = dataRes.frameTags[n];
				int startframe = dskillFrameTag.startframe;
				if (startframe >= 0 && startframe < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData4 = this.vFramesData[startframe];
					int tag = (int)dskillFrameTag.tag;
					if (BeUtility.CheckHaveTag(tag, 1))
					{
						bdentityActionFrameData4.kFlag.SetFlag(16, null);
					}
					else if (BeUtility.CheckHaveTag(tag, 2))
					{
						bdentityActionFrameData4.kFlag.SetFlag(32, null);
					}
					else if (BeUtility.CheckHaveTag(tag, 4))
					{
						bdentityActionFrameData4.kFlag.SetFlag(64, null);
					}
					else if (BeUtility.CheckHaveTag(tag, 8))
					{
						bdentityActionFrameData4.kFlag.SetFlag(128, null);
					}
					else if (BeUtility.CheckHaveTag(tag, 16))
					{
						bdentityActionFrameData4.kFlag.SetFlag(256, null);
					}
					else if (BeUtility.CheckHaveTag(tag, 32))
					{
						bdentityActionFrameData4.kFlag.SetFlag(512, null);
					}
					else if (BeUtility.CheckHaveTag(tag, 64))
					{
						bdentityActionFrameData4.kFlag.SetFlag(1024, dskillFrameTag.tagFlag);
					}
					else if (BeUtility.CheckHaveTag(tag, 128))
					{
						bdentityActionFrameData4.kFlag.SetFlag(2048, null);
					}
					else if (BeUtility.CheckHaveTag(tag, 256))
					{
						bdentityActionFrameData4.kFlag.SetFlag(4096, null);
					}
				}
			}
		}
		if (dataRes.frameGrap != null && dataRes.frameGrap.Length > 0)
		{
			for (int num = 0; num < dataRes.frameGrap.Length; num++)
			{
				global::DSkillFrameGrap dskillFrameGrap = dataRes.frameGrap[num];
				BDEventBase bdeventBase = null;
				int startframe2 = dskillFrameGrap.startframe;
				if (startframe2 < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData5 = this.vFramesData[startframe2];
					if (dskillFrameGrap.op == DSFGrapOp.GRAP_INTERRUPT || dskillFrameGrap.op == DSFGrapOp.GRAP_CHANGE_TARGETPOS || dskillFrameGrap.op == DSFGrapOp.GRAP_STOPCHANGE_TARGETPOS || dskillFrameGrap.op == DSFGrapOp.GRAP_CHANGE_TARGETACTION || dskillFrameGrap.op == DSFGrapOp.GRAP_INTERRUPT_ATTACKBOX)
					{
						BDSkillSuspend bdskillSuspend = new BDSkillSuspend((int)dskillFrameGrap.op, new VInt3(dskillFrameGrap.targetPos), dskillFrameGrap.faceGraber, (int)dskillFrameGrap.targetAction);
						bdeventBase = bdskillSuspend;
					}
					else if (dskillFrameGrap.op == DSFGrapOp.GRAP_JUDGE || dskillFrameGrap.op == DSFGrapOp.GRAP_JUDGE_EXECUTE || dskillFrameGrap.op == DSFGrapOp.GRAP_JUDGE_SKIP_PHASE)
					{
						for (int num2 = 0; num2 < dskillFrameGrap.length; num2++)
						{
							if (startframe2 + num2 < this.vFramesData.Count)
							{
								BDEntityActionFrameData bdentityActionFrameData6 = this.vFramesData[startframe2 + num2];
								bdentityActionFrameData6.kFlag.SetFlag((int)dskillFrameGrap.op, null);
							}
						}
					}
					else
					{
						bdentityActionFrameData5.kFlag.SetFlag((int)dskillFrameGrap.op, null);
					}
					if (bdeventBase != null)
					{
						bdentityActionFrameData5.pEvents.Add(bdeventBase);
					}
				}
			}
		}
		if (dataRes.stateop != null && dataRes.stateop.Length > 0)
		{
			for (int num3 = 0; num3 < dataRes.stateop.Length; num3++)
			{
				global::DSkillFrameStateOp dskillFrameStateOp = dataRes.stateop[num3];
				int startframe3 = dskillFrameStateOp.startframe;
				if (startframe3 < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData7 = this.vFramesData[startframe3];
					BDStateStackOP bdstateStackOP = new BDStateStackOP((int)dskillFrameStateOp.op, (int)dskillFrameStateOp.state, dskillFrameStateOp.idata1, (float)dskillFrameStateOp.idata2, dskillFrameStateOp.fdata1, (int)dskillFrameStateOp.statetag);
					BDEventBase bdeventBase2 = bdstateStackOP;
					if (bdeventBase2 != null)
					{
						bdentityActionFrameData7.pEvents.Add(bdeventBase2);
					}
				}
			}
		}
		if (dataRes.faceAttackerFrames != null && dataRes.faceAttackerFrames.Length > 0)
		{
			for (int num4 = 0; num4 < dataRes.faceAttackerFrames.Length; num4++)
			{
				global::DSkillFaceAttacker dskillFaceAttacker = dataRes.faceAttackerFrames[num4];
				int startframe4 = dskillFaceAttacker.startframe;
				if (startframe4 < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData8 = this.vFramesData[startframe4];
					BDFaceAttacker bdfaceAttacker = new BDFaceAttacker();
					BDEventBase bdeventBase3 = bdfaceAttacker;
					if (bdeventBase3 != null)
					{
						bdentityActionFrameData8.pEvents.Add(bdeventBase3);
					}
				}
			}
		}
		if (dataRes.properModify != null && dataRes.properModify.Length > 0)
		{
			for (int num5 = 0; num5 < dataRes.properModify.Length; num5++)
			{
				global::DSkillPropertyModify dskillPropertyModify = dataRes.properModify[num5];
				int startframe5 = dskillPropertyModify.startframe;
				int num6 = 0;
				while (num6 < dskillPropertyModify.length && startframe5 + num6 < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData9 = this.vFramesData[startframe5 + num6];
					BDModifySpeed bdmodifySpeed = new BDModifySpeed(dskillPropertyModify.tag, dskillPropertyModify.modifyfliter, dskillPropertyModify.value, dskillPropertyModify.movedValue, dskillPropertyModify.jumpToTargetPos, dskillPropertyModify.joyStickControl, dskillPropertyModify.valueAcc, dskillPropertyModify.movedValueAcc, dskillPropertyModify.modifyXBackward, dskillPropertyModify.eachFrameModify, dskillPropertyModify.useMovedYValue, dskillPropertyModify.movedYValue, dskillPropertyModify.movedYValueAcc);
					BDEventBase bdeventBase4 = bdmodifySpeed;
					if (bdeventBase4 != null)
					{
						bdentityActionFrameData9.pEvents.Add(bdeventBase4);
					}
					num6++;
				}
			}
		}
		if (dataRes.shocks != null && dataRes.shocks.Length > 0)
		{
			for (int num7 = 0; num7 < dataRes.shocks.Length; num7++)
			{
				global::DSkillFrameEventSceneShock dskillFrameEventSceneShock = dataRes.shocks[num7];
				int startframe6 = dskillFrameEventSceneShock.startframe;
				if (startframe6 < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData10 = this.vFramesData[startframe6];
					BDSceneShock bdsceneShock;
					if (dskillFrameEventSceneShock.isNew)
					{
						bdsceneShock = new BDSceneShock(dskillFrameEventSceneShock.time, dskillFrameEventSceneShock.num, dskillFrameEventSceneShock.xrange, dskillFrameEventSceneShock.yrange, dskillFrameEventSceneShock.decelerate, dskillFrameEventSceneShock.xreduce, dskillFrameEventSceneShock.yreduce, dskillFrameEventSceneShock.mode, dskillFrameEventSceneShock.radius);
					}
					else
					{
						bdsceneShock = new BDSceneShock(dskillFrameEventSceneShock.time, dskillFrameEventSceneShock.speed, dskillFrameEventSceneShock.xrange, dskillFrameEventSceneShock.yrange);
					}
					BDEventBase bdeventBase5 = bdsceneShock;
					if (bdeventBase5 != null)
					{
						bdentityActionFrameData10.pEvents.Add(bdeventBase5);
					}
				}
			}
		}
		if (dataRes.walkControl != null && dataRes.walkControl.Length > 0)
		{
			for (int num8 = 0; num8 < dataRes.walkControl.Length; num8++)
			{
				global::DSkillWalkControl dskillWalkControl = dataRes.walkControl[num8];
				int startframe7 = dskillWalkControl.startframe;
				if (startframe7 < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData11 = this.vFramesData[startframe7];
					BDSkillWalkControl bdskillWalkControl = new BDSkillWalkControl(dskillWalkControl.walkMode, dskillWalkControl.walkSpeedPercent, dskillWalkControl.useSkillSpeed, dskillWalkControl.walkSpeedPercent2);
					BDEventBase bdeventBase6 = bdskillWalkControl;
					if (bdeventBase6 != null)
					{
						bdentityActionFrameData11.pEvents.Add(bdeventBase6);
					}
				}
			}
		}
		if (dataRes.cameraMoves != null && dataRes.cameraMoves.Length > 0)
		{
			for (int num9 = 0; num9 < dataRes.cameraMoves.Length; num9++)
			{
				global::DSkillCameraMove dskillCameraMove = dataRes.cameraMoves[num9];
				int startframe8 = dskillCameraMove.startframe;
				if (startframe8 >= 0 && startframe8 < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData12 = this.vFramesData[startframe8];
					BDSkillCameraMove bdskillCameraMove = new BDSkillCameraMove(dskillCameraMove.offset, dskillCameraMove.duraction, dskillCameraMove.newOffset);
					BDEventBase bdeventBase7 = bdskillCameraMove;
					if (bdeventBase7 != null)
					{
						bdentityActionFrameData12.pEvents.Add(bdeventBase7);
					}
				}
			}
		}
		if (dataRes.sfx != null && dataRes.sfx.Length > 0)
		{
			for (int num10 = 0; num10 < dataRes.sfx.Length; num10++)
			{
				global::DSkillSfx dskillSfx = dataRes.sfx[num10];
				int startframe9 = dskillSfx.startframe;
				if (startframe9 < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData13 = this.vFramesData[startframe9];
					BDSkillSfx bdskillSfx = new BDSkillSfx(dskillSfx.soundClipAsset, dskillSfx.soundID, dskillSfx.loop, dskillSfx.useActorSpeed, dskillSfx.phaseFinishDelete, dskillSfx.finishDelete, dskillSfx.volume);
					BDEventBase bdeventBase8 = bdskillSfx;
					if (bdeventBase8 != null)
					{
						bdentityActionFrameData13.pEvents.Add(bdeventBase8);
					}
				}
			}
		}
		if (dataRes.frameEffects != null && dataRes.frameEffects.Length > 0)
		{
			for (int num11 = 0; num11 < dataRes.frameEffects.Length; num11++)
			{
				global::DSkillFrameEffect dskillFrameEffect = dataRes.frameEffects[num11];
				int startframe10 = dskillFrameEffect.startframe;
				if (startframe10 < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData14 = this.vFramesData[startframe10];
					int d = IntMath.Float2Int(dskillFrameEffect.buffTime * (float)GlobalLogic.VALUE_1000);
					if (dskillFrameEffect.phaseDelete)
					{
						d = -1;
					}
					BDSkillFrameEffect bdskillFrameEffect = new BDSkillFrameEffect(dskillFrameEffect.effectID, d, dskillFrameEffect.useBuffAni, dskillFrameEffect.usePause, dskillFrameEffect.pauseTime, dskillFrameEffect.finishDelete, dskillFrameEffect.finishDeleteAll, dskillFrameEffect.mechanismId);
					BDEventBase bdeventBase9 = bdskillFrameEffect;
					if (bdeventBase9 != null)
					{
						bdentityActionFrameData14.pEvents.Add(bdeventBase9);
					}
				}
			}
		}
		if (dataRes.actions != null && dataRes.actions.Length > 0)
		{
			for (int num12 = 0; num12 < dataRes.actions.Length; num12++)
			{
				global::DActionData dactionData = dataRes.actions[num12];
				int startframe11 = dactionData.startframe;
				if (startframe11 < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData15 = this.vFramesData[startframe11];
					BDSkillAction bdskillAction = new BDSkillAction(dactionData.actionType, dactionData.duration, dactionData.deltaScale, new VInt3(dactionData.deltaPos), dactionData.ignoreBlock);
					BDSkillAction bdskillAction2 = bdskillAction;
					if (bdskillAction2 != null)
					{
						bdentityActionFrameData15.pEvents.Add(bdskillAction2);
					}
				}
			}
		}
		if (dataRes.attachFrames != null)
		{
			for (int num13 = 0; num13 < dataRes.attachFrames.Length; num13++)
			{
				global::EntityAttachFrames entityAttachFrames = dataRes.attachFrames[num13];
				if (entityAttachFrames != null)
				{
					BeAttachFrames beAttachFrames = new BeAttachFrames();
					beAttachFrames.name = entityAttachFrames.name;
					beAttachFrames.resID = entityAttachFrames.resID;
					beAttachFrames.start = entityAttachFrames.start;
					beAttachFrames.end = entityAttachFrames.end;
					beAttachFrames.entityPrefab = entityAttachFrames.entityPrefab;
					beAttachFrames.entityAsset = entityAttachFrames.entityAsset;
					beAttachFrames.attachName = entityAttachFrames.attachName;
					List<BeAnimationFrame> list = new List<BeAnimationFrame>();
					for (int num14 = 0; num14 < entityAttachFrames.animations.Length; num14++)
					{
						list.Add(new BeAnimationFrame
						{
							anim = entityAttachFrames.animations[num14].anim,
							start = entityAttachFrames.animations[num14].start,
							speed = entityAttachFrames.animations[num14].speed
						});
					}
					beAttachFrames.animations = list.ToArray();
					this.vAttachFrames.Add(beAttachFrames);
				}
			}
		}
		if (dataRes.buffs != null && dataRes.buffs.Length > 0)
		{
			for (int num15 = 0; num15 < dataRes.buffs.Length; num15++)
			{
				global::DSkillBuff dskillBuff = dataRes.buffs[num15];
				int startframe12 = dskillBuff.startframe;
				if (startframe12 < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData16 = this.vFramesData[startframe12];
					int d2 = IntMath.Float2Int(dskillBuff.buffTime * (float)GlobalLogic.VALUE_1000);
					if (dskillBuff.phaseDelete)
					{
						d2 = -1;
					}
					BDAddBuffInfoOrBuff bdaddBuffInfoOrBuff = new BDAddBuffInfoOrBuff(dskillBuff.buffID, new List<int>(dskillBuff.buffInfoList), d2, dskillBuff.phaseDelete, dskillBuff.finishDeleteAll, dskillBuff.level, dskillBuff.levelBySkill);
					BDEventBase bdeventBase10 = bdaddBuffInfoOrBuff;
					if (bdeventBase10 != null)
					{
						bdentityActionFrameData16.pEvents.Add(bdeventBase10);
					}
				}
			}
		}
		if (dataRes.summons != null && dataRes.summons.Length > 0)
		{
			for (int num16 = 0; num16 < dataRes.summons.Length; num16++)
			{
				global::DSkillSummon dskillSummon = dataRes.summons[num16];
				int startframe13 = dskillSummon.startframe;
				if (startframe13 < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData17 = this.vFramesData[startframe13];
					BDDoSummon bddoSummon = new BDDoSummon(dskillSummon.summonID, dskillSummon.summonLevel, dskillSummon.levelGrowBySkill, dskillSummon.summonNum, dskillSummon.posType, new List<int>(dskillSummon.posType2), dskillSummon.isSameFace, dskillSummon.summonNumLimit);
					BDEventBase bdeventBase11 = bddoSummon;
					if (bdeventBase11 != null)
					{
						bdentityActionFrameData17.pEvents.Add(bdeventBase11);
					}
				}
			}
		}
		if (dataRes.mechanisms != null && dataRes.mechanisms.Length > 0)
		{
			for (int num17 = 0; num17 < dataRes.mechanisms.Length; num17++)
			{
				global::DSkillMechanism dskillMechanism = dataRes.mechanisms[num17];
				int startframe14 = dskillMechanism.startframe;
				if (startframe14 < this.vFramesData.Count)
				{
					BDEntityActionFrameData bdentityActionFrameData18 = this.vFramesData[startframe14];
					int d3 = IntMath.Float2Int(dskillMechanism.time * (float)GlobalLogic.VALUE_1000);
					if (dskillMechanism.phaseDelete)
					{
						d3 = -1;
					}
					BDAddMechanism bdaddMechanism = new BDAddMechanism(dskillMechanism.id, d3, dskillMechanism.level, dskillMechanism.levelBySkill, dskillMechanism.phaseDelete, dskillMechanism.finishDeleteAll);
					BDEventBase bdeventBase12 = bdaddMechanism;
					if (bdeventBase12 != null)
					{
						bdentityActionFrameData18.pEvents.Add(bdeventBase12);
					}
				}
			}
		}
		return true;
	}

	// Token: 0x040103BA RID: 66490
	public int weaponType;

	// Token: 0x040103BB RID: 66491
	public int weaponTag;

	// Token: 0x040103BC RID: 66492
	public string key;

	// Token: 0x040103BD RID: 66493
	public string moveName;

	// Token: 0x040103BE RID: 66494
	public int skillID;

	// Token: 0x040103BF RID: 66495
	public bool relatedAttackSpeed;

	// Token: 0x040103C0 RID: 66496
	public int attackSpeed;

	// Token: 0x040103C1 RID: 66497
	public string actionName;

	// Token: 0x040103C2 RID: 66498
	public int iLogicFramesNum;

	// Token: 0x040103C3 RID: 66499
	public VFactor fLogicFrameDeltaTime;

	// Token: 0x040103C4 RID: 66500
	public int fRealFramesTime;

	// Token: 0x040103C5 RID: 66501
	public float fFramesSpeed;

	// Token: 0x040103C6 RID: 66502
	public bool bLoop;

	// Token: 0x040103C7 RID: 66503
	public GameObject hitEffect;

	// Token: 0x040103C8 RID: 66504
	public DAssetObject hitEffectAsset;

	// Token: 0x040103C9 RID: 66505
	public int hitEffectInfoTableId;

	// Token: 0x040103CA RID: 66506
	public Object hitSFX;

	// Token: 0x040103CB RID: 66507
	public int hitSFXID;

	// Token: 0x040103CC RID: 66508
	public SoundTable hitSFXIDData;

	// Token: 0x040103CD RID: 66509
	public int skillTotalTime;

	// Token: 0x040103CE RID: 66510
	public float animationspeed;

	// Token: 0x040103CF RID: 66511
	public int[] skillPhases = new int[0];

	// Token: 0x040103D0 RID: 66512
	public TriggerNextPhaseType triggerType;

	// Token: 0x040103D1 RID: 66513
	public int iLogicStartFrame;

	// Token: 0x040103D2 RID: 66514
	public int iLogicEndFrame;

	// Token: 0x040103D3 RID: 66515
	public int iActionType;

	// Token: 0x040103D4 RID: 66516
	public float fActionHurtLevel;

	// Token: 0x040103D5 RID: 66517
	public float fActionForcex;

	// Token: 0x040103D6 RID: 66518
	public float fActionForcey;

	// Token: 0x040103D7 RID: 66519
	public float hurtTime;

	// Token: 0x040103D8 RID: 66520
	public bool hurtPause;

	// Token: 0x040103D9 RID: 66521
	public float hurtPauseTime;

	// Token: 0x040103DA RID: 66522
	public int comboStartFrame;

	// Token: 0x040103DB RID: 66523
	public int comboSkillID;

	// Token: 0x040103DC RID: 66524
	public int skillPriority;

	// Token: 0x040103DD RID: 66525
	public SeFlag exFlag = new SeFlag(0);

	// Token: 0x040103DE RID: 66526
	public BDGrabData grabData = new BDGrabData();

	// Token: 0x040103DF RID: 66527
	public bool useSpellBar;

	// Token: 0x040103E0 RID: 66528
	public float spellBarTime;

	// Token: 0x040103E1 RID: 66529
	public List<BDEntityActionFrameData> vFramesData = new List<BDEntityActionFrameData>();

	// Token: 0x040103E2 RID: 66530
	public List<BDDBoxData> vDecisionBoxData;

	// Token: 0x040103E3 RID: 66531
	public List<BeAttachFrames> vAttachFrames = new List<BeAttachFrames>();

	// Token: 0x040103E4 RID: 66532
	public bool useCharge;

	// Token: 0x040103E5 RID: 66533
	public global::ChargeConfig chargeConfig;

	// Token: 0x040103E6 RID: 66534
	public bool useSpecialOperation;

	// Token: 0x040103E7 RID: 66535
	public global::OperationConfig operationConfig;

	// Token: 0x040103E8 RID: 66536
	public bool useSelectSeatJoystick;

	// Token: 0x040103E9 RID: 66537
	public global::SkillJoystickConfig skillJoystickConfig;

	// Token: 0x040103EA RID: 66538
	public global::SkillEvent[] skillEvents;

	// Token: 0x040103EB RID: 66539
	public bool cameraRestore;

	// Token: 0x040103EC RID: 66540
	public float cameraRestoreTime;

	// Token: 0x040103ED RID: 66541
	public bool bAnimLoop;

	// Token: 0x040103EE RID: 66542
	public bool bAnimLoop1;

	// Token: 0x02004133 RID: 16691
	// (Invoke) Token: 0x06016B7A RID: 93050
	public delegate void Del(BDEntityActionFrameData state, DSkillFrameEvent frameEvent);
}
