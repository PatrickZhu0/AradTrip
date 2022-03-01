using System;
using System.Collections.Generic;
using System.IO;
using FBGlobalSetting;
using FlatBuffers;
using GameClient;
using UnityEngine;

// Token: 0x02000129 RID: 297
public class FBGlobalSettingSerializer
{
	// Token: 0x0600087B RID: 2171 RVA: 0x0002BEBE File Offset: 0x0002A2BE
	private static StringOffset ToFBString(FlatBufferBuilder builder, string value)
	{
		if (!string.IsNullOrEmpty(value))
		{
			return builder.CreateString(value);
		}
		return builder.CreateString(string.Empty);
	}

	// Token: 0x0600087C RID: 2172 RVA: 0x0002BEE0 File Offset: 0x0002A2E0
	public static void SaveFBGlobalSetting(string dataPath, global::GlobalSetting dataObj)
	{
		FlatBufferBuilder flatBufferBuilder = new FlatBufferBuilder(1);
		StringOffset defaultHitEffectOffset = FBGlobalSettingSerializer.ToFBString(flatBufferBuilder, dataObj.defaultHitEffect);
		StringOffset defaultProjectileHitEffectOffset = FBGlobalSettingSerializer.ToFBString(flatBufferBuilder, dataObj.defaultProjectileHitEffect);
		StringOffset defualtHitSfxOffset = FBGlobalSettingSerializer.ToFBString(flatBufferBuilder, dataObj.defualtHitSfx);
		StringOffset equipListOffset = FBGlobalSettingSerializer.ToFBString(flatBufferBuilder, dataObj.equipList);
		StringOffset scenePathOffset = FBGlobalSettingSerializer.ToFBString(flatBufferBuilder, dataObj.scenePath);
		StringOffset serverListUrlOffset = FBGlobalSettingSerializer.ToFBString(flatBufferBuilder, dataObj.serverListUrl);
		StringOffset critialDeadEffectOffset = FBGlobalSettingSerializer.ToFBString(flatBufferBuilder, dataObj.critialDeadEffect);
		StringOffset immediateDeadEffectOffset = FBGlobalSettingSerializer.ToFBString(flatBufferBuilder, dataObj.immediateDeadEffect);
		StringOffset normalDeadEffectOffset = FBGlobalSettingSerializer.ToFBString(flatBufferBuilder, dataObj.normalDeadEffect);
		StringOffset pvpDefaultSesstionIDOffset = FBGlobalSettingSerializer.ToFBString(flatBufferBuilder, dataObj.pvpDefaultSesstionID);
		VectorOffset loggerFilterOffset = default(VectorOffset);
		if (dataObj.loggerFilter != null && dataObj.loggerFilter.Length > 0)
		{
			StringOffset[] array = new StringOffset[dataObj.loggerFilter.Length];
			int i = 0;
			int num = dataObj.loggerFilter.Length;
			while (i < num)
			{
				string value = dataObj.loggerFilter[i];
				array[i] = FBGlobalSettingSerializer.ToFBString(flatBufferBuilder, value);
				i++;
			}
			loggerFilterOffset = FBGlobalSetting.GlobalSetting.CreateLoggerFilterVector(flatBufferBuilder, array);
		}
		Dictionary<string, float>.Enumerator enumerator = dataObj.equipPropFactors.GetEnumerator();
		float[] array2 = new float[dataObj.equipPropFactors.Count];
		StringOffset[] array3 = new StringOffset[dataObj.equipPropFactors.Count];
		int num2 = 0;
		while (enumerator.MoveNext())
		{
			KeyValuePair<string, float> keyValuePair = enumerator.Current;
			array2[num2] = keyValuePair.Value;
			array3[num2] = FBGlobalSettingSerializer.ToFBString(flatBufferBuilder, keyValuePair.Key);
			num2++;
		}
		VectorOffset equipPropFactorsKeyOffset = FBGlobalSetting.GlobalSetting.CreateEquipPropFactorsKeyVector(flatBufferBuilder, array3);
		VectorOffset equipPropFactorsValueOffset = FBGlobalSetting.GlobalSetting.CreateEquipPropFactorsValueVector(flatBufferBuilder, array2);
		VectorOffset equipPropFactorValuesOffset = FBGlobalSetting.GlobalSetting.CreateEquipPropFactorValuesVector(flatBufferBuilder, dataObj.equipPropFactorValues);
		enumerator = dataObj.quipThirdTypeFactors.GetEnumerator();
		float[] array4 = new float[dataObj.quipThirdTypeFactors.Count];
		StringOffset[] array5 = new StringOffset[dataObj.quipThirdTypeFactors.Count];
		num2 = 0;
		while (enumerator.MoveNext())
		{
			KeyValuePair<string, float> keyValuePair2 = enumerator.Current;
			array4[num2] = keyValuePair2.Value;
			array5[num2] = FBGlobalSettingSerializer.ToFBString(flatBufferBuilder, keyValuePair2.Key);
			num2++;
		}
		VectorOffset quipThirdTypeFactorsKeyOffset = FBGlobalSetting.GlobalSetting.CreateQuipThirdTypeFactorsKeyVector(flatBufferBuilder, array5);
		VectorOffset quipThirdTypeFactorsValueOffset = FBGlobalSetting.GlobalSetting.CreateQuipThirdTypeFactorsValueVector(flatBufferBuilder, array4);
		VectorOffset quipThirdTypeFactorValuesOffset = FBGlobalSetting.GlobalSetting.CreateQuipThirdTypeFactorValuesVector(flatBufferBuilder, dataObj.quipThirdTypeFactorValues);
		VectorOffset serverListOffset = default(VectorOffset);
		if (dataObj.serverList.Length > 0)
		{
			Offset<Address>[] array6 = new Offset<Address>[dataObj.serverList.Length];
			int j = 0;
			int num3 = dataObj.serverList.Length;
			while (j < num3)
			{
				global::GlobalSetting.Address address = dataObj.serverList[j];
				StringOffset name = FBGlobalSettingSerializer.ToFBString(flatBufferBuilder, address.name);
				StringOffset ip = FBGlobalSettingSerializer.ToFBString(flatBufferBuilder, address.ip);
				array6[j] = Address.CreateAddress(flatBufferBuilder, name, ip, address.port, address.id);
				j++;
			}
			serverListOffset = FBGlobalSetting.GlobalSetting.CreateServerListVector(flatBufferBuilder, array6);
		}
		FBGlobalSetting.GlobalSetting.StartGlobalSetting(flatBufferBuilder);
		FBGlobalSetting.GlobalSetting.AddIsTestTeam(flatBufferBuilder, dataObj.isTestTeam);
		FBGlobalSetting.GlobalSetting.AddIsPaySDKDebug(flatBufferBuilder, dataObj.isPaySDKDebug);
		FBGlobalSetting.GlobalSetting.AddSdkChannel(flatBufferBuilder, (int)dataObj.sdkChannel);
		FBGlobalSetting.GlobalSetting.AddIsBanShuVersion(flatBufferBuilder, dataObj.isBanShuVersion);
		FBGlobalSetting.GlobalSetting.AddIsDebug(flatBufferBuilder, dataObj.isDebug);
		FBGlobalSetting.GlobalSetting.AddIsLogRecord(flatBufferBuilder, dataObj.isLogRecord);
		FBGlobalSetting.GlobalSetting.AddIsRecordPVP(flatBufferBuilder, dataObj.isRecordPVP);
		FBGlobalSetting.GlobalSetting.AddShowDebugBox(flatBufferBuilder, dataObj.showDebugBox);
		FBGlobalSetting.GlobalSetting.AddFrameLock(flatBufferBuilder, dataObj.frameLock);
		FBGlobalSetting.GlobalSetting.AddFallgroundHitFactor(flatBufferBuilder, dataObj.fallgroundHitFactor);
		FBGlobalSetting.GlobalSetting.AddHitTime(flatBufferBuilder, dataObj.hitTime);
		FBGlobalSetting.GlobalSetting.AddDeadWhiteTime(flatBufferBuilder, dataObj.deadWhiteTime);
		FBGlobalSetting.GlobalSetting.AddDefaultHitEffect(flatBufferBuilder, defaultHitEffectOffset);
		FBGlobalSetting.GlobalSetting.AddDefaultProjectileHitEffect(flatBufferBuilder, defaultProjectileHitEffectOffset);
		FBGlobalSetting.GlobalSetting.AddDefualtHitSfx(flatBufferBuilder, defualtHitSfxOffset);
		FBGlobalSetting.GlobalSetting.Add_walkSpeed(flatBufferBuilder, Vector3.CreateVector3(flatBufferBuilder, dataObj._walkSpeed.x, dataObj._walkSpeed.y, dataObj._walkSpeed.z));
		FBGlobalSetting.GlobalSetting.Add_runSpeed(flatBufferBuilder, Vector3.CreateVector3(flatBufferBuilder, dataObj._runSpeed.x, dataObj._runSpeed.y, dataObj._runSpeed.z));
		FBGlobalSetting.GlobalSetting.AddTownWalkSpeed(flatBufferBuilder, Vector3.CreateVector3(flatBufferBuilder, dataObj.townWalkSpeed.x, dataObj.townWalkSpeed.y, dataObj.townWalkSpeed.z));
		FBGlobalSetting.GlobalSetting.AddTownRunSpeed(flatBufferBuilder, Vector3.CreateVector3(flatBufferBuilder, dataObj.townRunSpeed.x, dataObj.townRunSpeed.y, dataObj.townRunSpeed.z));
		FBGlobalSetting.GlobalSetting.AddTownActionSpeed(flatBufferBuilder, dataObj.townActionSpeed);
		FBGlobalSetting.GlobalSetting.AddTownPlayerRun(flatBufferBuilder, dataObj.townPlayerRun);
		FBGlobalSetting.GlobalSetting.AddMinHurtTime(flatBufferBuilder, dataObj.minHurtTime);
		FBGlobalSetting.GlobalSetting.AddMaxHurtTime(flatBufferBuilder, dataObj.maxHurtTime);
		FBGlobalSetting.GlobalSetting.AddFrozenPercent(flatBufferBuilder, dataObj.frozenPercent);
		FBGlobalSetting.GlobalSetting.AddJumpBackSpeed(flatBufferBuilder, Vector2.CreateVector2(flatBufferBuilder, dataObj.jumpBackSpeed.x, dataObj.jumpBackSpeed.y));
		FBGlobalSetting.GlobalSetting.AddJumpForce(flatBufferBuilder, dataObj.jumpForce);
		FBGlobalSetting.GlobalSetting.AddClickForce(flatBufferBuilder, dataObj.clickForce);
		FBGlobalSetting.GlobalSetting.AddSnapDuration(flatBufferBuilder, dataObj.snapDuration);
		FBGlobalSetting.GlobalSetting.Add_dunFuTime(flatBufferBuilder, dataObj._dunFuTime);
		FBGlobalSetting.GlobalSetting.Add_pvpDunFuTime(flatBufferBuilder, dataObj._pvpDunFuTime);
		FBGlobalSetting.GlobalSetting.AddPVPHPScale(flatBufferBuilder, dataObj.PVPHPScale);
		FBGlobalSetting.GlobalSetting.AddTestLevel(flatBufferBuilder, dataObj.TestLevel);
		FBGlobalSetting.GlobalSetting.AddTestPlayerNum(flatBufferBuilder, dataObj.testPlayerNum);
		FBGlobalSetting.GlobalSetting.AddShowBattleInfoPanel(flatBufferBuilder, dataObj.showBattleInfoPanel);
		FBGlobalSetting.GlobalSetting.AddDefaultMonsterID(flatBufferBuilder, dataObj.defaultMonsterID);
		FBGlobalSetting.GlobalSetting.Add_monsterWalkSpeedFactor(flatBufferBuilder, dataObj._monsterWalkSpeedFactor);
		FBGlobalSetting.GlobalSetting.Add_monsterSightFactor(flatBufferBuilder, dataObj._monsterSightFactor);
		FBGlobalSetting.GlobalSetting.AddEnableAssetInstPool(flatBufferBuilder, dataObj.enableAssetInstPool);
		FBGlobalSetting.GlobalSetting.AddEnemyHasAI(flatBufferBuilder, dataObj.enemyHasAI);
		FBGlobalSetting.GlobalSetting.AddIsCreateMonsterLocal(flatBufferBuilder, dataObj.isCreateMonsterLocal);
		FBGlobalSetting.GlobalSetting.AddIsGiveEquips(flatBufferBuilder, dataObj.isGiveEquips);
		FBGlobalSetting.GlobalSetting.AddEquipList(flatBufferBuilder, equipListOffset);
		FBGlobalSetting.GlobalSetting.AddIsGuide(flatBufferBuilder, dataObj.isGuide);
		FBGlobalSetting.GlobalSetting.AddDisplayHUD(flatBufferBuilder, dataObj.displayHUD);
		FBGlobalSetting.GlobalSetting.AddCloseTeamCondition(flatBufferBuilder, dataObj.CloseTeamCondition);
		FBGlobalSetting.GlobalSetting.AddIsLocalDungeon(flatBufferBuilder, dataObj.isLocalDungeon);
		FBGlobalSetting.GlobalSetting.AddLocalDungeonID(flatBufferBuilder, dataObj.localDungeonID);
		FBGlobalSetting.GlobalSetting.AddRecordResFile(flatBufferBuilder, dataObj.recordResFile);
		FBGlobalSetting.GlobalSetting.AddProfileAssetLoad(flatBufferBuilder, dataObj.profileAssetLoad);
		FBGlobalSetting.GlobalSetting.Add_gravity(flatBufferBuilder, dataObj._gravity);
		FBGlobalSetting.GlobalSetting.Add_fallGravityReduceFactor(flatBufferBuilder, dataObj._fallGravityReduceFactor);
		FBGlobalSetting.GlobalSetting.AddSkillHasCooldown(flatBufferBuilder, dataObj.skillHasCooldown);
		FBGlobalSetting.GlobalSetting.AddScenePath(flatBufferBuilder, scenePathOffset);
		FBGlobalSetting.GlobalSetting.AddIpSelectedIndex(flatBufferBuilder, dataObj.ipSelectedIndex);
		FBGlobalSetting.GlobalSetting.AddISingleCharactorID(flatBufferBuilder, dataObj.iSingleCharactorID);
		FBGlobalSetting.GlobalSetting.AddCameraInRange(flatBufferBuilder, Vector2.CreateVector2(flatBufferBuilder, dataObj.cameraInRange.x, dataObj.cameraInRange.y));
		FBGlobalSetting.GlobalSetting.AddButtonType(flatBufferBuilder, (int)dataObj.buttonType);
		FBGlobalSetting.GlobalSetting.Add_defaultFloatHurt(flatBufferBuilder, dataObj._defaultFloatHurt);
		FBGlobalSetting.GlobalSetting.Add_defaultFloatLevelHurat(flatBufferBuilder, dataObj._defaultFloatLevelHurat);
		FBGlobalSetting.GlobalSetting.Add_defaultGroundHurt(flatBufferBuilder, dataObj._defaultGroundHurt);
		FBGlobalSetting.GlobalSetting.Add_defaultStandHurt(flatBufferBuilder, dataObj._defaultStandHurt);
		FBGlobalSetting.GlobalSetting.Add_fallProtectGravityAddFactor(flatBufferBuilder, dataObj._fallProtectGravityAddFactor);
		FBGlobalSetting.GlobalSetting.Add_protectClearDuration(flatBufferBuilder, dataObj._protectClearDuration);
		FBGlobalSetting.GlobalSetting.AddBgmStart(flatBufferBuilder, dataObj.bgmStart);
		FBGlobalSetting.GlobalSetting.AddBgmTown(flatBufferBuilder, dataObj.bgmTown);
		FBGlobalSetting.GlobalSetting.AddBgmBattle(flatBufferBuilder, dataObj.bgmBattle);
		FBGlobalSetting.GlobalSetting.Add_zDimFactor(flatBufferBuilder, dataObj._zDimFactor);
		FBGlobalSetting.GlobalSetting.AddBullteScale(flatBufferBuilder, dataObj.bullteScale);
		FBGlobalSetting.GlobalSetting.AddBullteTime(flatBufferBuilder, dataObj.bullteTime);
		FBGlobalSetting.GlobalSetting.AddStartSystem(flatBufferBuilder, (int)dataObj.startSystem);
		FBGlobalSetting.GlobalSetting.AddLoggerFilter(flatBufferBuilder, loggerFilterOffset);
		FBGlobalSetting.GlobalSetting.AddShowDialog(flatBufferBuilder, dataObj.showDialog);
		FBGlobalSetting.GlobalSetting.AddAvatarLightDir(flatBufferBuilder, Vector3.CreateVector3(flatBufferBuilder, dataObj.avatarLightDir.x, dataObj.avatarLightDir.y, dataObj.avatarLightDir.z));
		FBGlobalSetting.GlobalSetting.AddShadowLightDir(flatBufferBuilder, Vector3.CreateVector3(flatBufferBuilder, dataObj.shadowLightDir.x, dataObj.shadowLightDir.y, dataObj.shadowLightDir.z));
		FBGlobalSetting.GlobalSetting.AddStartVel(flatBufferBuilder, Vector3.CreateVector3(flatBufferBuilder, dataObj.startVel.x, dataObj.startVel.y, dataObj.startVel.z));
		FBGlobalSetting.GlobalSetting.AddEndVel(flatBufferBuilder, Vector3.CreateVector3(flatBufferBuilder, dataObj.endVel.x, dataObj.endVel.y, dataObj.endVel.z));
		FBGlobalSetting.GlobalSetting.AddOffset(flatBufferBuilder, Vector3.CreateVector3(flatBufferBuilder, dataObj.offset.x, dataObj.offset.y, dataObj.offset.z));
		FBGlobalSetting.GlobalSetting.AddTimeAccerlate(flatBufferBuilder, dataObj.TimeAccerlate);
		FBGlobalSetting.GlobalSetting.AddTotalTime(flatBufferBuilder, dataObj.TotalTime);
		FBGlobalSetting.GlobalSetting.AddTotalDist(flatBufferBuilder, dataObj.TotalDist);
		FBGlobalSetting.GlobalSetting.AddHeightAdoption(flatBufferBuilder, dataObj.heightAdoption);
		FBGlobalSetting.GlobalSetting.AddDebugDrawBlock(flatBufferBuilder, dataObj.debugDrawBlock);
		FBGlobalSetting.GlobalSetting.AddLoadFromPackage(flatBufferBuilder, dataObj.loadFromPackage);
		FBGlobalSetting.GlobalSetting.AddEnableHotFix(flatBufferBuilder, dataObj.enableHotFix);
		FBGlobalSetting.GlobalSetting.AddHotFixUrlDebug(flatBufferBuilder, dataObj.hotFixUrlDebug);
		FBGlobalSetting.GlobalSetting.AddREVIVESHOCKSKILLID(flatBufferBuilder, dataObj.REVIVE_SHOCK_SKILLID);
		FBGlobalSetting.GlobalSetting.AddRollSpeed(flatBufferBuilder, Vector2.CreateVector2(flatBufferBuilder, dataObj.rollSpeed.x, dataObj.rollSpeed.y));
		FBGlobalSetting.GlobalSetting.AddRollRand(flatBufferBuilder, dataObj.rollRand);
		FBGlobalSetting.GlobalSetting.AddNormalRollRand(flatBufferBuilder, dataObj.normalRollRand);
		FBGlobalSetting.GlobalSetting.Add_pkDamageAdjustFactor(flatBufferBuilder, dataObj._pkDamageAdjustFactor);
		FBGlobalSetting.GlobalSetting.Add_pkHPAdjustFactor(flatBufferBuilder, dataObj._pkHPAdjustFactor);
		FBGlobalSetting.GlobalSetting.AddPkUseMaxLevel(flatBufferBuilder, dataObj.pkUseMaxLevel);
		FBGlobalSetting.GlobalSetting.AddBattleRunMode(flatBufferBuilder, (int)dataObj.battleRunMode);
		FBGlobalSetting.GlobalSetting.AddHasDoubleRun(flatBufferBuilder, dataObj.hasDoubleRun);
		FBGlobalSetting.GlobalSetting.AddPlayerHP(flatBufferBuilder, dataObj.playerHP);
		FBGlobalSetting.GlobalSetting.AddPlayerRebornHP(flatBufferBuilder, dataObj.playerRebornHP);
		FBGlobalSetting.GlobalSetting.AddMonsterHP(flatBufferBuilder, dataObj.monsterHP);
		FBGlobalSetting.GlobalSetting.AddPlayerPos(flatBufferBuilder, Vector3.CreateVector3(flatBufferBuilder, dataObj.playerPos.x, dataObj.playerPos.y, dataObj.playerPos.z));
		FBGlobalSetting.GlobalSetting.AddTransportDoorRadius(flatBufferBuilder, dataObj.transportDoorRadius);
		FBGlobalSetting.GlobalSetting.AddPetXMovingDis(flatBufferBuilder, dataObj.petXMovingDis);
		FBGlobalSetting.GlobalSetting.AddPetXMovingv1(flatBufferBuilder, dataObj.petXMovingv1);
		FBGlobalSetting.GlobalSetting.AddPetXMovingv2(flatBufferBuilder, dataObj.petXMovingv2);
		FBGlobalSetting.GlobalSetting.AddPetYMovingDis(flatBufferBuilder, dataObj.petYMovingDis);
		FBGlobalSetting.GlobalSetting.AddPetYMovingv1(flatBufferBuilder, dataObj.petYMovingv1);
		FBGlobalSetting.GlobalSetting.AddPetYMovingv2(flatBufferBuilder, dataObj.petYMovingv2);
		FBGlobalSetting.GlobalSetting.AddServerListUrl(flatBufferBuilder, serverListUrlOffset);
		FBGlobalSetting.GlobalSetting.AddServerList(flatBufferBuilder, serverListOffset);
		FBGlobalSetting.GlobalSetting.AddDebugNewAutofightAI(flatBufferBuilder, dataObj.debugNewAutofightAI);
		FBGlobalSetting.GlobalSetting.AddCharScale(flatBufferBuilder, dataObj.charScale);
		FBGlobalSetting.GlobalSetting.AddMonsterBeHitShockData(flatBufferBuilder, FBGlobalSetting.ShockData.CreateShockData(flatBufferBuilder, dataObj.monsterBeHitShockData.time, dataObj.monsterBeHitShockData.speed, dataObj.monsterBeHitShockData.xrange, dataObj.monsterBeHitShockData.yrange, dataObj.monsterBeHitShockData.mode));
		FBGlobalSetting.GlobalSetting.AddPlayerBeHitShockData(flatBufferBuilder, FBGlobalSetting.ShockData.CreateShockData(flatBufferBuilder, dataObj.playerBeHitShockData.time, dataObj.playerBeHitShockData.speed, dataObj.playerBeHitShockData.xrange, dataObj.playerBeHitShockData.yrange, dataObj.playerBeHitShockData.mode));
		FBGlobalSetting.GlobalSetting.AddPlayerSkillCDShockData(flatBufferBuilder, FBGlobalSetting.ShockData.CreateShockData(flatBufferBuilder, dataObj.playerSkillCDShockData.time, dataObj.playerSkillCDShockData.speed, dataObj.playerSkillCDShockData.xrange, dataObj.playerSkillCDShockData.yrange, dataObj.playerSkillCDShockData.mode));
		FBGlobalSetting.GlobalSetting.AddPlayerHighFallTouchGroundShockData(flatBufferBuilder, FBGlobalSetting.ShockData.CreateShockData(flatBufferBuilder, dataObj.playerHighFallTouchGroundShockData.time, dataObj.playerHighFallTouchGroundShockData.speed, dataObj.playerHighFallTouchGroundShockData.xrange, dataObj.playerHighFallTouchGroundShockData.yrange, dataObj.playerHighFallTouchGroundShockData.mode));
		FBGlobalSetting.GlobalSetting.AddHighFallHight(flatBufferBuilder, dataObj.highFallHight);
		FBGlobalSetting.GlobalSetting.AddCritialDeadEffect(flatBufferBuilder, critialDeadEffectOffset);
		FBGlobalSetting.GlobalSetting.AddImmediateDeadEffect(flatBufferBuilder, immediateDeadEffectOffset);
		FBGlobalSetting.GlobalSetting.AddNormalDeadEffect(flatBufferBuilder, normalDeadEffectOffset);
		FBGlobalSetting.GlobalSetting.AddEnableEffectLimit(flatBufferBuilder, dataObj.enableEffectLimit);
		FBGlobalSetting.GlobalSetting.AddEffectLimitCount(flatBufferBuilder, dataObj.effectLimitCount);
		FBGlobalSetting.GlobalSetting.AddImmediateDeadHPPercent(flatBufferBuilder, dataObj.immediateDeadHPPercent);
		FBGlobalSetting.GlobalSetting.AddOpenBossShow(flatBufferBuilder, dataObj.openBossShow);
		FBGlobalSetting.GlobalSetting.AddShooterFitPercent(flatBufferBuilder, dataObj.shooterFitPercent);
		FBGlobalSetting.GlobalSetting.AddDisappearDis(flatBufferBuilder, Vector3.CreateVector3(flatBufferBuilder, dataObj.disappearDis.x, dataObj.disappearDis.y, dataObj.disappearDis.z));
		FBGlobalSetting.GlobalSetting.AddKeepDis(flatBufferBuilder, dataObj.keepDis);
		FBGlobalSetting.GlobalSetting.AddAccompanyRunTime(flatBufferBuilder, dataObj.accompanyRunTime);
		FBGlobalSetting.GlobalSetting.Add_aiWanderRange(flatBufferBuilder, dataObj._aiWanderRange);
		FBGlobalSetting.GlobalSetting.Add_aiWAlkBackRange(flatBufferBuilder, dataObj._aiWAlkBackRange);
		FBGlobalSetting.GlobalSetting.Add_aiMaxWalkCmdCount(flatBufferBuilder, dataObj._aiMaxWalkCmdCount);
		FBGlobalSetting.GlobalSetting.Add_aiMaxWalkCmdCountRANGED(flatBufferBuilder, dataObj._aiMaxWalkCmdCount_RANGED);
		FBGlobalSetting.GlobalSetting.Add_aiMaxIdleCmdcount(flatBufferBuilder, dataObj._aiMaxIdleCmdcount);
		FBGlobalSetting.GlobalSetting.Add_aiSkillAttackPassive(flatBufferBuilder, dataObj._aiSkillAttackPassive);
		FBGlobalSetting.GlobalSetting.Add_monsterGetupBatiFactor(flatBufferBuilder, dataObj._monsterGetupBatiFactor);
		FBGlobalSetting.GlobalSetting.Add_degangBackDistance(flatBufferBuilder, dataObj._degangBackDistance);
		FBGlobalSetting.GlobalSetting.Add_afThinkTerm(flatBufferBuilder, dataObj._afThinkTerm);
		FBGlobalSetting.GlobalSetting.Add_afFindTargetTerm(flatBufferBuilder, dataObj._afFindTargetTerm);
		FBGlobalSetting.GlobalSetting.Add_afChangeDestinationTerm(flatBufferBuilder, dataObj._afChangeDestinationTerm);
		FBGlobalSetting.GlobalSetting.Add_autoCheckRestoreInterval(flatBufferBuilder, dataObj._autoCheckRestoreInterval);
		FBGlobalSetting.GlobalSetting.AddForceUseAutoFight(flatBufferBuilder, dataObj.forceUseAutoFight);
		FBGlobalSetting.GlobalSetting.AddCanUseAutoFight(flatBufferBuilder, dataObj.canUseAutoFight);
		FBGlobalSetting.GlobalSetting.AddCanUseAutoFightFirstPass(flatBufferBuilder, dataObj.canUseAutoFightFirstPass);
		FBGlobalSetting.GlobalSetting.AddLoadAutoFight(flatBufferBuilder, dataObj.loadAutoFight);
		FBGlobalSetting.GlobalSetting.AddJumpAttackLimitHeight(flatBufferBuilder, dataObj.jumpAttackLimitHeight);
		FBGlobalSetting.GlobalSetting.AddSkillCancelLimitTime(flatBufferBuilder, dataObj.skillCancelLimitTime);
		FBGlobalSetting.GlobalSetting.AddDoublePressCheckDuration(flatBufferBuilder, dataObj.doublePressCheckDuration);
		FBGlobalSetting.GlobalSetting.AddWalkAction(flatBufferBuilder, (int)dataObj.walkAction);
		FBGlobalSetting.GlobalSetting.AddRunAction(flatBufferBuilder, (int)dataObj.runAction);
		FBGlobalSetting.GlobalSetting.AddWalkAniFactor(flatBufferBuilder, dataObj.walkAniFactor);
		FBGlobalSetting.GlobalSetting.AddRunAniFactor(flatBufferBuilder, dataObj.runAniFactor);
		FBGlobalSetting.GlobalSetting.AddChangeFaceStop(flatBufferBuilder, dataObj.changeFaceStop);
		FBGlobalSetting.GlobalSetting.Add_monsterWalkSpeed(flatBufferBuilder, Vector3.CreateVector3(flatBufferBuilder, dataObj._monsterWalkSpeed.x, dataObj._monsterWalkSpeed.y, dataObj._monsterWalkSpeed.z));
		FBGlobalSetting.GlobalSetting.Add_monsterRunSpeed(flatBufferBuilder, Vector3.CreateVector3(flatBufferBuilder, dataObj._monsterRunSpeed.x, dataObj._monsterRunSpeed.y, dataObj._monsterRunSpeed.z));
		FBGlobalSetting.GlobalSetting.AddTableLoadStep(flatBufferBuilder, dataObj.tableLoadStep);
		FBGlobalSetting.GlobalSetting.AddLoadingProgressStepInEditor(flatBufferBuilder, dataObj.loadingProgressStepInEditor);
		FBGlobalSetting.GlobalSetting.AddLoadingProgressStep(flatBufferBuilder, dataObj.loadingProgressStep);
		FBGlobalSetting.GlobalSetting.AddPvpDefaultSesstionID(flatBufferBuilder, pvpDefaultSesstionIDOffset);
		FBGlobalSetting.GlobalSetting.AddPetID(flatBufferBuilder, dataObj.petID);
		FBGlobalSetting.GlobalSetting.AddPetLevel(flatBufferBuilder, dataObj.petLevel);
		FBGlobalSetting.GlobalSetting.AddPetHunger(flatBufferBuilder, dataObj.petHunger);
		FBGlobalSetting.GlobalSetting.AddPetSkillIndex(flatBufferBuilder, dataObj.petSkillIndex);
		FBGlobalSetting.GlobalSetting.AddTestFashionEquip(flatBufferBuilder, dataObj.testFashionEquip);
		FBGlobalSetting.GlobalSetting.AddEquipPropFactorsKey(flatBufferBuilder, equipPropFactorsKeyOffset);
		FBGlobalSetting.GlobalSetting.AddEquipPropFactorsValue(flatBufferBuilder, equipPropFactorsValueOffset);
		FBGlobalSetting.GlobalSetting.AddEquipPropFactorValues(flatBufferBuilder, equipPropFactorValuesOffset);
		FBGlobalSetting.GlobalSetting.AddQuipThirdTypeFactorsKey(flatBufferBuilder, quipThirdTypeFactorsKeyOffset);
		FBGlobalSetting.GlobalSetting.AddQuipThirdTypeFactorsValue(flatBufferBuilder, quipThirdTypeFactorsValueOffset);
		FBGlobalSetting.GlobalSetting.AddQuipThirdTypeFactorValues(flatBufferBuilder, quipThirdTypeFactorValuesOffset);
		FBGlobalSetting.GlobalSetting.AddQualityAdjust(flatBufferBuilder, QualityAdjust.CreateQualityAdjust(flatBufferBuilder, dataObj.qualityAdjust.bIsOpen, dataObj.qualityAdjust.fInterval, dataObj.qualityAdjust.iTimes));
		FBGlobalSetting.GlobalSetting.AddPetDialogLife(flatBufferBuilder, dataObj.petDialogLife);
		FBGlobalSetting.GlobalSetting.AddPetDialogShowInterval(flatBufferBuilder, dataObj.petDialogShowInterval);
		FBGlobalSetting.GlobalSetting.AddPetSpecialIdleInterval(flatBufferBuilder, dataObj.petSpecialIdleInterval);
		FBGlobalSetting.GlobalSetting.AddNotifyItemTimeLess(flatBufferBuilder, dataObj.notifyItemTimeLess);
		flatBufferBuilder.Finish(FBGlobalSetting.GlobalSetting.EndGlobalSetting(flatBufferBuilder).Value, "GSET");
		using (MemoryStream memoryStream = new MemoryStream(flatBufferBuilder.DataBuffer.Data, flatBufferBuilder.DataBuffer.Position, flatBufferBuilder.Offset))
		{
			File.WriteAllBytes(dataPath, memoryStream.ToArray());
		}
	}

	// Token: 0x0600087D RID: 2173 RVA: 0x0002CCF4 File Offset: 0x0002B0F4
	public static void LoadFBGlobalSetting(string dataPath, out global::GlobalSetting dataSetting)
	{
		dataPath = dataPath.ToLower();
		dataSetting = null;
		if (!File.Exists(dataPath))
		{
			return;
		}
		byte[] buffer = File.ReadAllBytes(dataPath);
		dataSetting = ScriptableObject.CreateInstance<global::GlobalSetting>();
		if (null != dataSetting)
		{
			ByteBuffer bb = new ByteBuffer(buffer);
			FBGlobalSetting.GlobalSetting rootAsGlobalSetting = FBGlobalSetting.GlobalSetting.GetRootAsGlobalSetting(bb);
			if (rootAsGlobalSetting != null)
			{
				dataSetting.isTestTeam = rootAsGlobalSetting.IsTestTeam;
				dataSetting.isPaySDKDebug = rootAsGlobalSetting.IsPaySDKDebug;
				dataSetting.sdkChannel = (SDKChannel)rootAsGlobalSetting.SdkChannel;
				dataSetting.isBanShuVersion = rootAsGlobalSetting.IsBanShuVersion;
				dataSetting.isDebug = rootAsGlobalSetting.IsDebug;
				dataSetting.isLogRecord = rootAsGlobalSetting.IsLogRecord;
				dataSetting.isRecordPVP = rootAsGlobalSetting.IsRecordPVP;
				dataSetting.showDebugBox = rootAsGlobalSetting.ShowDebugBox;
				dataSetting.frameLock = rootAsGlobalSetting.FrameLock;
				dataSetting.fallgroundHitFactor = rootAsGlobalSetting.FallgroundHitFactor;
				dataSetting.hitTime = rootAsGlobalSetting.HitTime;
				dataSetting.deadWhiteTime = rootAsGlobalSetting.DeadWhiteTime;
				dataSetting.defaultHitEffect = rootAsGlobalSetting.DefaultHitEffect;
				dataSetting.defaultProjectileHitEffect = rootAsGlobalSetting.DefaultProjectileHitEffect;
				dataSetting.defualtHitSfx = rootAsGlobalSetting.DefualtHitSfx;
				dataSetting._walkSpeed = new Vec3(rootAsGlobalSetting._walkSpeed.X, rootAsGlobalSetting._walkSpeed.Y, rootAsGlobalSetting._walkSpeed.Z);
				dataSetting._runSpeed = new Vec3(rootAsGlobalSetting._runSpeed.X, rootAsGlobalSetting._runSpeed.Y, rootAsGlobalSetting._runSpeed.Z);
				dataSetting.townWalkSpeed = new Vec3(rootAsGlobalSetting.TownWalkSpeed.X, rootAsGlobalSetting.TownWalkSpeed.Y, rootAsGlobalSetting.TownWalkSpeed.Z);
				dataSetting.townRunSpeed = new Vec3(rootAsGlobalSetting.TownRunSpeed.X, rootAsGlobalSetting.TownRunSpeed.Y, rootAsGlobalSetting.TownRunSpeed.Z);
				dataSetting.townActionSpeed = rootAsGlobalSetting.TownActionSpeed;
				dataSetting.townPlayerRun = rootAsGlobalSetting.TownPlayerRun;
				dataSetting.minHurtTime = rootAsGlobalSetting.MinHurtTime;
				dataSetting.maxHurtTime = rootAsGlobalSetting.MaxHurtTime;
				dataSetting.frozenPercent = rootAsGlobalSetting.FrozenPercent;
				dataSetting.jumpBackSpeed = new Vector2(rootAsGlobalSetting.JumpBackSpeed.X, rootAsGlobalSetting.JumpBackSpeed.Y);
				dataSetting.jumpForce = rootAsGlobalSetting.JumpForce;
				dataSetting.clickForce = rootAsGlobalSetting.ClickForce;
				dataSetting.snapDuration = rootAsGlobalSetting.SnapDuration;
				dataSetting._dunFuTime = rootAsGlobalSetting._dunFuTime;
				dataSetting._pvpDunFuTime = rootAsGlobalSetting._pvpDunFuTime;
				dataSetting.PVPHPScale = rootAsGlobalSetting.PVPHPScale;
				dataSetting.TestLevel = rootAsGlobalSetting.TestLevel;
				dataSetting.testPlayerNum = rootAsGlobalSetting.TestPlayerNum;
				dataSetting.showBattleInfoPanel = rootAsGlobalSetting.ShowBattleInfoPanel;
				dataSetting.defaultMonsterID = rootAsGlobalSetting.DefaultMonsterID;
				dataSetting._monsterWalkSpeedFactor = rootAsGlobalSetting._monsterWalkSpeedFactor;
				dataSetting._monsterSightFactor = rootAsGlobalSetting._monsterSightFactor;
				dataSetting.enableAssetInstPool = rootAsGlobalSetting.EnableAssetInstPool;
				dataSetting.enemyHasAI = rootAsGlobalSetting.EnemyHasAI;
				dataSetting.isCreateMonsterLocal = rootAsGlobalSetting.IsCreateMonsterLocal;
				dataSetting.isGiveEquips = rootAsGlobalSetting.IsGiveEquips;
				dataSetting.equipList = rootAsGlobalSetting.EquipList;
				dataSetting.isGuide = rootAsGlobalSetting.IsGuide;
				dataSetting.displayHUD = rootAsGlobalSetting.DisplayHUD;
				dataSetting.CloseTeamCondition = rootAsGlobalSetting.CloseTeamCondition;
				dataSetting.isLocalDungeon = rootAsGlobalSetting.IsLocalDungeon;
				dataSetting.localDungeonID = rootAsGlobalSetting.LocalDungeonID;
				dataSetting.recordResFile = rootAsGlobalSetting.RecordResFile;
				dataSetting.profileAssetLoad = rootAsGlobalSetting.ProfileAssetLoad;
				dataSetting._gravity = rootAsGlobalSetting._gravity;
				dataSetting._fallGravityReduceFactor = rootAsGlobalSetting._fallGravityReduceFactor;
				dataSetting.skillHasCooldown = rootAsGlobalSetting.SkillHasCooldown;
				dataSetting.scenePath = rootAsGlobalSetting.ScenePath;
				dataSetting.ipSelectedIndex = rootAsGlobalSetting.IpSelectedIndex;
				dataSetting.iSingleCharactorID = rootAsGlobalSetting.ISingleCharactorID;
				dataSetting.cameraInRange = new Vector2(rootAsGlobalSetting.CameraInRange.X, rootAsGlobalSetting.CameraInRange.Y);
				dataSetting.buttonType = (InputManager.ButtonMode)rootAsGlobalSetting.ButtonType;
				dataSetting._defaultFloatHurt = rootAsGlobalSetting._defaultFloatHurt;
				dataSetting._defaultFloatLevelHurat = rootAsGlobalSetting._defaultFloatLevelHurat;
				dataSetting._defaultGroundHurt = rootAsGlobalSetting._defaultGroundHurt;
				dataSetting._defaultStandHurt = rootAsGlobalSetting._defaultStandHurt;
				dataSetting._fallProtectGravityAddFactor = rootAsGlobalSetting._fallProtectGravityAddFactor;
				dataSetting._protectClearDuration = rootAsGlobalSetting._protectClearDuration;
				dataSetting.bgmStart = rootAsGlobalSetting.BgmStart;
				dataSetting.bgmTown = rootAsGlobalSetting.BgmTown;
				dataSetting.bgmBattle = rootAsGlobalSetting.BgmBattle;
				dataSetting._zDimFactor = rootAsGlobalSetting._zDimFactor;
				dataSetting.bullteScale = rootAsGlobalSetting.BullteScale;
				dataSetting.bullteTime = rootAsGlobalSetting.BullteTime;
				dataSetting.startSystem = (EClientSystem)rootAsGlobalSetting.StartSystem;
				string[] array = new string[rootAsGlobalSetting.LoggerFilterLength];
				int i = 0;
				int num = array.Length;
				while (i < num)
				{
					array[i] = rootAsGlobalSetting.GetLoggerFilter(i);
					i++;
				}
				dataSetting.loggerFilter = array;
				dataSetting.showDialog = rootAsGlobalSetting.ShowDialog;
				dataSetting.avatarLightDir = new Vector3(rootAsGlobalSetting.AvatarLightDir.X, rootAsGlobalSetting.AvatarLightDir.Y, rootAsGlobalSetting.AvatarLightDir.Z);
				dataSetting.shadowLightDir = new Vector3(rootAsGlobalSetting.ShadowLightDir.X, rootAsGlobalSetting.ShadowLightDir.Y, rootAsGlobalSetting.ShadowLightDir.Z);
				dataSetting.startVel = new Vector3(rootAsGlobalSetting.StartVel.X, rootAsGlobalSetting.StartVel.Y, rootAsGlobalSetting.StartVel.Z);
				dataSetting.endVel = new Vector3(rootAsGlobalSetting.EndVel.X, rootAsGlobalSetting.EndVel.Y, rootAsGlobalSetting.EndVel.Z);
				dataSetting.offset = new Vector3(rootAsGlobalSetting.Offset.X, rootAsGlobalSetting.Offset.Y, rootAsGlobalSetting.Offset.Z);
				dataSetting.TimeAccerlate = rootAsGlobalSetting.TimeAccerlate;
				dataSetting.TotalTime = rootAsGlobalSetting.TotalTime;
				dataSetting.TotalDist = rootAsGlobalSetting.TotalDist;
				dataSetting.heightAdoption = rootAsGlobalSetting.HeightAdoption;
				dataSetting.debugDrawBlock = rootAsGlobalSetting.DebugDrawBlock;
				dataSetting.loadFromPackage = rootAsGlobalSetting.LoadFromPackage;
				dataSetting.enableHotFix = rootAsGlobalSetting.EnableHotFix;
				dataSetting.hotFixUrlDebug = rootAsGlobalSetting.HotFixUrlDebug;
				dataSetting.REVIVE_SHOCK_SKILLID = rootAsGlobalSetting.REVIVESHOCKSKILLID;
				dataSetting.rollSpeed = new Vector2(rootAsGlobalSetting.RollSpeed.X, rootAsGlobalSetting.RollSpeed.Y);
				dataSetting.rollRand = rootAsGlobalSetting.RollRand;
				dataSetting.normalRollRand = rootAsGlobalSetting.NormalRollRand;
				dataSetting._pkDamageAdjustFactor = rootAsGlobalSetting._pkDamageAdjustFactor;
				dataSetting._pkHPAdjustFactor = rootAsGlobalSetting._pkHPAdjustFactor;
				dataSetting.pkUseMaxLevel = rootAsGlobalSetting.PkUseMaxLevel;
				dataSetting.battleRunMode = (BattleRunMode)rootAsGlobalSetting.BattleRunMode;
				dataSetting.hasDoubleRun = rootAsGlobalSetting.HasDoubleRun;
				dataSetting.playerHP = rootAsGlobalSetting.PlayerHP;
				dataSetting.playerRebornHP = rootAsGlobalSetting.PlayerRebornHP;
				dataSetting.monsterHP = rootAsGlobalSetting.MonsterHP;
				dataSetting.playerPos = new Vec3(rootAsGlobalSetting.PlayerPos.X, rootAsGlobalSetting.PlayerPos.Y, rootAsGlobalSetting.PlayerPos.Z);
				dataSetting.transportDoorRadius = rootAsGlobalSetting.TransportDoorRadius;
				dataSetting.petXMovingDis = rootAsGlobalSetting.PetXMovingDis;
				dataSetting.petXMovingv1 = rootAsGlobalSetting.PetXMovingv1;
				dataSetting.petXMovingv2 = rootAsGlobalSetting.PetXMovingv2;
				dataSetting.petYMovingDis = rootAsGlobalSetting.PetYMovingDis;
				dataSetting.petYMovingv1 = rootAsGlobalSetting.PetYMovingv1;
				dataSetting.petYMovingv2 = rootAsGlobalSetting.PetYMovingv2;
				dataSetting.serverListUrl = rootAsGlobalSetting.ServerListUrl;
				global::GlobalSetting.Address[] array2 = new global::GlobalSetting.Address[rootAsGlobalSetting.ServerListLength];
				int j = 0;
				int num2 = array2.Length;
				while (j < num2)
				{
					global::GlobalSetting.Address address = new global::GlobalSetting.Address();
					Address serverList = rootAsGlobalSetting.GetServerList(j);
					address.id = serverList.Id;
					address.port = serverList.Port;
					address.name = serverList.Name;
					address.ip = serverList.Ip;
					array2[j] = address;
					j++;
				}
				dataSetting.serverList = array2;
				dataSetting.debugNewAutofightAI = rootAsGlobalSetting.DebugNewAutofightAI;
				dataSetting.charScale = rootAsGlobalSetting.CharScale;
				dataSetting.monsterBeHitShockData = new global::ShockData(rootAsGlobalSetting.MonsterBeHitShockData.Time, rootAsGlobalSetting.MonsterBeHitShockData.Speed, rootAsGlobalSetting.MonsterBeHitShockData.Xrange, rootAsGlobalSetting.MonsterBeHitShockData.Yrange, rootAsGlobalSetting.MonsterBeHitShockData.Mode);
				dataSetting.playerBeHitShockData = new global::ShockData(rootAsGlobalSetting.PlayerBeHitShockData.Time, rootAsGlobalSetting.PlayerBeHitShockData.Speed, rootAsGlobalSetting.PlayerBeHitShockData.Xrange, rootAsGlobalSetting.PlayerBeHitShockData.Yrange, rootAsGlobalSetting.PlayerBeHitShockData.Mode);
				dataSetting.playerSkillCDShockData = new global::ShockData(rootAsGlobalSetting.PlayerSkillCDShockData.Time, rootAsGlobalSetting.PlayerSkillCDShockData.Speed, rootAsGlobalSetting.PlayerSkillCDShockData.Xrange, rootAsGlobalSetting.PlayerSkillCDShockData.Yrange, rootAsGlobalSetting.PlayerSkillCDShockData.Mode);
				dataSetting.playerHighFallTouchGroundShockData = new global::ShockData(rootAsGlobalSetting.PlayerHighFallTouchGroundShockData.Time, rootAsGlobalSetting.PlayerHighFallTouchGroundShockData.Speed, rootAsGlobalSetting.PlayerHighFallTouchGroundShockData.Xrange, rootAsGlobalSetting.PlayerHighFallTouchGroundShockData.Yrange, rootAsGlobalSetting.PlayerHighFallTouchGroundShockData.Mode);
				dataSetting.highFallHight = rootAsGlobalSetting.HighFallHight;
				dataSetting.critialDeadEffect = rootAsGlobalSetting.CritialDeadEffect;
				dataSetting.immediateDeadEffect = rootAsGlobalSetting.ImmediateDeadEffect;
				dataSetting.normalDeadEffect = rootAsGlobalSetting.NormalDeadEffect;
				dataSetting.enableEffectLimit = rootAsGlobalSetting.EnableEffectLimit;
				dataSetting.effectLimitCount = rootAsGlobalSetting.EffectLimitCount;
				dataSetting.immediateDeadHPPercent = rootAsGlobalSetting.ImmediateDeadHPPercent;
				dataSetting.openBossShow = rootAsGlobalSetting.OpenBossShow;
				dataSetting.shooterFitPercent = rootAsGlobalSetting.ShooterFitPercent;
				dataSetting.disappearDis = new Vector3(rootAsGlobalSetting.DisappearDis.X, rootAsGlobalSetting.DisappearDis.Y, rootAsGlobalSetting.DisappearDis.Z);
				dataSetting.keepDis = rootAsGlobalSetting.KeepDis;
				dataSetting.accompanyRunTime = rootAsGlobalSetting.AccompanyRunTime;
				dataSetting._aiWanderRange = rootAsGlobalSetting._aiWanderRange;
				dataSetting._aiWAlkBackRange = rootAsGlobalSetting._aiWAlkBackRange;
				dataSetting._aiMaxWalkCmdCount = rootAsGlobalSetting._aiMaxWalkCmdCount;
				dataSetting._aiMaxWalkCmdCount_RANGED = rootAsGlobalSetting._aiMaxWalkCmdCountRANGED;
				dataSetting._aiMaxIdleCmdcount = rootAsGlobalSetting._aiMaxIdleCmdcount;
				dataSetting._aiSkillAttackPassive = rootAsGlobalSetting._aiSkillAttackPassive;
				dataSetting._monsterGetupBatiFactor = rootAsGlobalSetting._monsterGetupBatiFactor;
				dataSetting._degangBackDistance = rootAsGlobalSetting._degangBackDistance;
				dataSetting._afThinkTerm = rootAsGlobalSetting._afThinkTerm;
				dataSetting._afFindTargetTerm = rootAsGlobalSetting._afFindTargetTerm;
				dataSetting._afChangeDestinationTerm = rootAsGlobalSetting._afChangeDestinationTerm;
				dataSetting._autoCheckRestoreInterval = rootAsGlobalSetting._autoCheckRestoreInterval;
				dataSetting.forceUseAutoFight = rootAsGlobalSetting.ForceUseAutoFight;
				dataSetting.canUseAutoFight = rootAsGlobalSetting.CanUseAutoFight;
				dataSetting.canUseAutoFightFirstPass = rootAsGlobalSetting.CanUseAutoFightFirstPass;
				dataSetting.loadAutoFight = rootAsGlobalSetting.LoadAutoFight;
				dataSetting.jumpAttackLimitHeight = rootAsGlobalSetting.JumpAttackLimitHeight;
				dataSetting.skillCancelLimitTime = rootAsGlobalSetting.SkillCancelLimitTime;
				dataSetting.doublePressCheckDuration = rootAsGlobalSetting.DoublePressCheckDuration;
				dataSetting.walkAction = (ActionType)rootAsGlobalSetting.WalkAction;
				dataSetting.runAction = (ActionType)rootAsGlobalSetting.RunAction;
				dataSetting.walkAniFactor = rootAsGlobalSetting.WalkAniFactor;
				dataSetting.runAniFactor = rootAsGlobalSetting.RunAniFactor;
				dataSetting.changeFaceStop = rootAsGlobalSetting.ChangeFaceStop;
				dataSetting._monsterWalkSpeed = new Vec3(rootAsGlobalSetting._monsterWalkSpeed.X, rootAsGlobalSetting._monsterWalkSpeed.Y, rootAsGlobalSetting._monsterWalkSpeed.Z);
				dataSetting._monsterRunSpeed = new Vec3(rootAsGlobalSetting._monsterRunSpeed.X, rootAsGlobalSetting._monsterRunSpeed.Y, rootAsGlobalSetting._monsterRunSpeed.Z);
				dataSetting.tableLoadStep = rootAsGlobalSetting.TableLoadStep;
				dataSetting.loadingProgressStepInEditor = rootAsGlobalSetting.LoadingProgressStepInEditor;
				dataSetting.loadingProgressStep = rootAsGlobalSetting.LoadingProgressStep;
				dataSetting.pvpDefaultSesstionID = rootAsGlobalSetting.PvpDefaultSesstionID;
				dataSetting.petID = rootAsGlobalSetting.PetID;
				dataSetting.petLevel = rootAsGlobalSetting.PetLevel;
				dataSetting.petHunger = rootAsGlobalSetting.PetHunger;
				dataSetting.petSkillIndex = rootAsGlobalSetting.PetSkillIndex;
				dataSetting.testFashionEquip = rootAsGlobalSetting.TestFashionEquip;
				dataSetting.equipPropFactors = new Dictionary<string, float>();
				int num3 = (rootAsGlobalSetting.EquipPropFactorsKeyLength >= rootAsGlobalSetting.EquipPropFactorsValueLength) ? rootAsGlobalSetting.EquipPropFactorsValueLength : rootAsGlobalSetting.EquipPropFactorsKeyLength;
				int k = 0;
				int num4 = num3;
				while (k < num4)
				{
					dataSetting.equipPropFactors.Add(rootAsGlobalSetting.GetEquipPropFactorsKey(k), rootAsGlobalSetting.GetEquipPropFactorsValue(k));
					k++;
				}
				float[] array3 = new float[rootAsGlobalSetting.EquipPropFactorValuesLength];
				int l = 0;
				int num5 = array3.Length;
				while (l < num5)
				{
					array3[l] = rootAsGlobalSetting.GetEquipPropFactorValues(l);
					l++;
				}
				dataSetting.equipPropFactorValues = array3;
				num3 = ((rootAsGlobalSetting.QuipThirdTypeFactorsKeyLength >= rootAsGlobalSetting.QuipThirdTypeFactorsValueLength) ? rootAsGlobalSetting.QuipThirdTypeFactorsValueLength : rootAsGlobalSetting.QuipThirdTypeFactorsKeyLength);
				int m = 0;
				int num6 = num3;
				while (m < num6)
				{
					dataSetting.quipThirdTypeFactors.Add(rootAsGlobalSetting.GetQuipThirdTypeFactorsKey(m), rootAsGlobalSetting.GetQuipThirdTypeFactorsValue(m));
					m++;
				}
				float[] array4 = new float[rootAsGlobalSetting.QuipThirdTypeFactorValuesLength];
				int n = 0;
				int num7 = array4.Length;
				while (n < num7)
				{
					array4[n] = rootAsGlobalSetting.GetQuipThirdTypeFactorValues(n);
					n++;
				}
				dataSetting.quipThirdTypeFactorValues = array4;
				dataSetting.qualityAdjust = new global::GlobalSetting.QualityAdjust();
				dataSetting.qualityAdjust.fInterval = rootAsGlobalSetting.QualityAdjust.FInterval;
				dataSetting.qualityAdjust.bIsOpen = rootAsGlobalSetting.QualityAdjust.BIsOpen;
				dataSetting.qualityAdjust.iTimes = rootAsGlobalSetting.QualityAdjust.ITimes;
				dataSetting.petDialogLife = rootAsGlobalSetting.PetDialogLife;
				dataSetting.petDialogShowInterval = rootAsGlobalSetting.PetDialogShowInterval;
				dataSetting.petSpecialIdleInterval = rootAsGlobalSetting.PetSpecialIdleInterval;
				dataSetting.notifyItemTimeLess = rootAsGlobalSetting.NotifyItemTimeLess;
			}
		}
	}
}
