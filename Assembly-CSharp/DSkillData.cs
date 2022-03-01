using System;
using UnityEngine;

// Token: 0x02004BB7 RID: 19383
public class DSkillData : ScriptableObject
{
	// Token: 0x040139D2 RID: 80338
	public string _name;

	// Token: 0x040139D3 RID: 80339
	public int skillID;

	// Token: 0x040139D4 RID: 80340
	public int skillPriority = 1;

	// Token: 0x040139D5 RID: 80341
	public int[] skillPhases = new int[0];

	// Token: 0x040139D6 RID: 80342
	public bool relatedAttackSpeed;

	// Token: 0x040139D7 RID: 80343
	public int attackSpeed = 1000;

	// Token: 0x040139D8 RID: 80344
	public int isLoop;

	// Token: 0x040139D9 RID: 80345
	public bool notLoopLastFrame;

	// Token: 0x040139DA RID: 80346
	public bool loopAnimation;

	// Token: 0x040139DB RID: 80347
	public bool loopAnimation1;

	// Token: 0x040139DC RID: 80348
	public string hitEffect = string.Empty;

	// Token: 0x040139DD RID: 80349
	public GameObject goHitEffect;

	// Token: 0x040139DE RID: 80350
	public DAssetObject goHitEffectAsset;

	// Token: 0x040139DF RID: 80351
	public int hitEffectInfoTableId;

	// Token: 0x040139E0 RID: 80352
	public Object goSFX;

	// Token: 0x040139E1 RID: 80353
	public DAssetObject goSFXAsset;

	// Token: 0x040139E2 RID: 80354
	public int hitSFXID;

	// Token: 0x040139E3 RID: 80355
	public int hurtType;

	// Token: 0x040139E4 RID: 80356
	public float hurtTime;

	// Token: 0x040139E5 RID: 80357
	public int hurtPause;

	// Token: 0x040139E6 RID: 80358
	public float hurtPauseTime;

	// Token: 0x040139E7 RID: 80359
	public float forcex;

	// Token: 0x040139E8 RID: 80360
	public float forcey;

	// Token: 0x040139E9 RID: 80361
	public string description;

	// Token: 0x040139EA RID: 80362
	public GameObject characterPrefab;

	// Token: 0x040139EB RID: 80363
	public DAssetObject characterAsset;

	// Token: 0x040139EC RID: 80364
	public int fps = 60;

	// Token: 0x040139ED RID: 80365
	public string animationName;

	// Token: 0x040139EE RID: 80366
	public string moveName;

	// Token: 0x040139EF RID: 80367
	public WrapMode wrapMode;

	// Token: 0x040139F0 RID: 80368
	public float interpolationSpeed;

	// Token: 0x040139F1 RID: 80369
	public float animationSpeed = 1f;

	// Token: 0x040139F2 RID: 80370
	public int totalFrames = 15;

	// Token: 0x040139F3 RID: 80371
	public int startUpFrames = 5;

	// Token: 0x040139F4 RID: 80372
	public int activeFrames = 5;

	// Token: 0x040139F5 RID: 80373
	public int recoveryFrames = 5;

	// Token: 0x040139F6 RID: 80374
	public bool useSpellBar;

	// Token: 0x040139F7 RID: 80375
	public float spellBarTime;

	// Token: 0x040139F8 RID: 80376
	public int comboStartFrame;

	// Token: 0x040139F9 RID: 80377
	public int comboSkillID;

	// Token: 0x040139FA RID: 80378
	public float skilltime;

	// Token: 0x040139FB RID: 80379
	public bool cameraRestore;

	// Token: 0x040139FC RID: 80380
	public float cameraRestoreTime;

	// Token: 0x040139FD RID: 80381
	public float grabPosx;

	// Token: 0x040139FE RID: 80382
	public float grabPosy;

	// Token: 0x040139FF RID: 80383
	public float grabEndForceX;

	// Token: 0x04013A00 RID: 80384
	public float grabEndForceY;

	// Token: 0x04013A01 RID: 80385
	public float grabTime;

	// Token: 0x04013A02 RID: 80386
	public int grabEndEffectType;

	// Token: 0x04013A03 RID: 80387
	public int grabAction;

	// Token: 0x04013A04 RID: 80388
	public int grabNum;

	// Token: 0x04013A05 RID: 80389
	public float grabMoveSpeed;

	// Token: 0x04013A06 RID: 80390
	public bool grabSupportQuickPressDismis;

	// Token: 0x04013A07 RID: 80391
	public bool notGrabBati;

	// Token: 0x04013A08 RID: 80392
	public bool notGrabGeDang;

	// Token: 0x04013A09 RID: 80393
	public bool notUseGrabSetPos;

	// Token: 0x04013A0A RID: 80394
	public bool notGrabToBlock;

	// Token: 0x04013A0B RID: 80395
	public int buffInfoId;

	// Token: 0x04013A0C RID: 80396
	public int buffInfoIdToSelf;

	// Token: 0x04013A0D RID: 80397
	public int buffInfoIDToOther;

	// Token: 0x04013A0E RID: 80398
	public bool isCharge;

	// Token: 0x04013A0F RID: 80399
	public ChargeConfig chargeConfig;

	// Token: 0x04013A10 RID: 80400
	public bool isSpeicalOperate;

	// Token: 0x04013A11 RID: 80401
	public OperationConfig operationConfig;

	// Token: 0x04013A12 RID: 80402
	public bool isUseSelectSeatJoystick;

	// Token: 0x04013A13 RID: 80403
	public SkillJoystickConfig skillJoystickConfig;

	// Token: 0x04013A14 RID: 80404
	public SkillEvent[] skillEvents = new SkillEvent[0];

	// Token: 0x04013A15 RID: 80405
	public TriggerNextPhaseType triggerType;

	// Token: 0x04013A16 RID: 80406
	public HurtDecisionBox[] HurtBlocks = new HurtDecisionBox[0];

	// Token: 0x04013A17 RID: 80407
	public DefenceDecisionBox[] DefenceBlocks = new DefenceDecisionBox[0];

	// Token: 0x04013A18 RID: 80408
	public EntityAttachFrames[] attachFrames = new EntityAttachFrames[0];

	// Token: 0x04013A19 RID: 80409
	public EffectsFrames[] effectFrames = new EffectsFrames[0];

	// Token: 0x04013A1A RID: 80410
	public EntityFrames[] entityFrames = new EntityFrames[0];

	// Token: 0x04013A1B RID: 80411
	public DSkillFrameTag[] frameTags = new DSkillFrameTag[0];

	// Token: 0x04013A1C RID: 80412
	public DSkillFrameGrap[] frameGrap = new DSkillFrameGrap[0];

	// Token: 0x04013A1D RID: 80413
	public DSkillFrameStateOp[] stateop = new DSkillFrameStateOp[0];

	// Token: 0x04013A1E RID: 80414
	public DSkillFaceAttacker[] faceAttackerFrames = new DSkillFaceAttacker[0];

	// Token: 0x04013A1F RID: 80415
	public DSkillPropertyModify[] properModify = new DSkillPropertyModify[0];

	// Token: 0x04013A20 RID: 80416
	public DSkillFrameEventSceneShock[] shocks = new DSkillFrameEventSceneShock[0];

	// Token: 0x04013A21 RID: 80417
	public DSkillSfx[] sfx = new DSkillSfx[0];

	// Token: 0x04013A22 RID: 80418
	public DSkillFrameEffect[] frameEffects = new DSkillFrameEffect[0];

	// Token: 0x04013A23 RID: 80419
	public DSkillCameraMove[] cameraMoves = new DSkillCameraMove[0];

	// Token: 0x04013A24 RID: 80420
	public DSkillWalkControl[] walkControl = new DSkillWalkControl[0];

	// Token: 0x04013A25 RID: 80421
	public DActionData[] actions = new DActionData[0];

	// Token: 0x04013A26 RID: 80422
	public DSkillBuff[] buffs = new DSkillBuff[0];

	// Token: 0x04013A27 RID: 80423
	public DSkillSummon[] summons = new DSkillSummon[0];

	// Token: 0x04013A28 RID: 80424
	public DSkillMechanism[] mechanisms = new DSkillMechanism[0];
}
