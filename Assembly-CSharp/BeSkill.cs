using System;
using System.Collections.Generic;
using GameClient;
using GamePool;
using ProtoTable;
using UnityEngine;

// Token: 0x020041B5 RID: 16821
public class BeSkill
{
	// Token: 0x060172BA RID: 94906 RVA: 0x0071FD34 File Offset: 0x0071E134
	public BeSkill(int sid, int skillLevel)
	{
		this.skillID = sid;
		this.level = skillLevel;
		this.skillData = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(this.skillID, string.Empty, string.Empty);
		if (this.skillData == null)
		{
			Logger.LogErrorFormat("技能表 没有ID为 {0} 的技能", new object[]
			{
				this.skillID
			});
		}
		this.ChangeSummonData();
	}

	// Token: 0x060172BB RID: 94907 RVA: 0x0071FF0C File Offset: 0x0071E30C
	public void JoyStickPostInit()
	{
		BDEntityActionInfo skillActionInfo = this.owner.GetSkillActionInfo(this.skillID);
		if (skillActionInfo == null)
		{
			return;
		}
		if (skillActionInfo.skillJoystickConfig.mode != this.joystickMode)
		{
			this.joystickMode = skillActionInfo.skillJoystickConfig.mode;
		}
		if (skillActionInfo.useSpecialOperation && skillActionInfo.skillJoystickConfig.mode != SkillJoystickMode.FORWARDBACK)
		{
			this.joystickMode = SkillJoystickMode.SPECIAL;
		}
		if (skillActionInfo.useSelectSeatJoystick)
		{
			this.joystickMode = SkillJoystickMode.SELECTSEAT;
		}
	}

	// Token: 0x060172BC RID: 94908 RVA: 0x0071FF8E File Offset: 0x0071E38E
	public void JoyStickStart()
	{
		this.effectOffset = 0;
		this.canRemoveJoystick = true;
	}

	// Token: 0x060172BD RID: 94909 RVA: 0x0071FF9E File Offset: 0x0071E39E
	public VInt3 GetEffectPos()
	{
		return this.effectPos;
	}

	// Token: 0x060172BE RID: 94910 RVA: 0x0071FFA6 File Offset: 0x0071E3A6
	public void UpdateJoystick(int vx, int vy)
	{
		this.recordVx = vx;
		this.recordVy = vy;
	}

	// Token: 0x060172BF RID: 94911 RVA: 0x0071FFB8 File Offset: 0x0071E3B8
	private void LoadJoystickUI()
	{
		if (this.joystickMode != SkillJoystickMode.FREE)
		{
			return;
		}
		this.innerState = BeSkill.InnerState.CHOOSE_TARGET;
		BDEntityActionInfo skillActionInfo = this.owner.GetSkillActionInfo(this.skillID);
		if (skillActionInfo == null)
		{
			return;
		}
		this.effectPos = this.owner.GetPosition();
		this.effectSpeed = skillActionInfo.skillJoystickConfig.effectMoveSpeed;
		this.effectRange = skillActionInfo.skillJoystickConfig.effectMoveRange;
		this.recordVx = 0;
		this.recordVy = 0;
		if (this.targetEffectWarning != null)
		{
			this.targetEffectWarning.Remove();
		}
		this.targetEffectWarning = null;
		this.effectPos.x = this.effectPos.x + this.effectOffset;
		if (Utility.IsStringValid(skillActionInfo.skillJoystickConfig.effectName) && this.owner.isLocalActor)
		{
			this.targetEffectWarning = this.CreateEffect(skillActionInfo.skillJoystickConfig.effectName, this.effectPos.vec3);
			this.targetEffectLine = this.CreateEffect("Effects/Hero_Qiangpao/Liangzi/Prefab/Eff_Liangzi_kuang_jiguang_guo", this.effectPos.vec3);
			this.targetEffectGround = this.CreateEffect("Effects/Scene_effects/EffectUI/Eff_Jinengfanwei_guo", this.owner.GetPosition().vec3);
		}
	}

	// Token: 0x060172C0 RID: 94912 RVA: 0x007200F0 File Offset: 0x0071E4F0
	public void EndJoystick()
	{
		if (this.joystickMode != SkillJoystickMode.FREE || !this.canRemoveJoystick)
		{
			return;
		}
		this.SetInnerState(BeSkill.InnerState.NONE);
		if (!this.owner.isLocalActor)
		{
			return;
		}
		if (InputManager.instance != null)
		{
			InputManager.instance.RemoveButtonJoystick2(this.skillID);
		}
		this.owner.delayCaller.DelayCall(500, delegate
		{
			this.RemoveJoystickEffect();
		}, 0, 0, false);
		this.RemoveGroundAndLine();
	}

	// Token: 0x060172C1 RID: 94913 RVA: 0x00720172 File Offset: 0x0071E572
	public void RemoveJoystickEffect()
	{
		if (this.joystickMode != SkillJoystickMode.FREE)
		{
			return;
		}
		if (this.targetEffectWarning != null)
		{
			this.targetEffectWarning.Remove();
			this.targetEffectWarning = null;
		}
		this.RemoveGroundAndLine();
	}

	// Token: 0x060172C2 RID: 94914 RVA: 0x007201A4 File Offset: 0x0071E5A4
	private void RemoveGroundAndLine()
	{
		if (this.targetEffectGround != null)
		{
			this.targetEffectGround.Remove();
			this.targetEffectGround = null;
		}
		if (this.targetEffectLine != null)
		{
			this.targetEffectLine.Remove();
			this.targetEffectLine = null;
		}
	}

	// Token: 0x060172C3 RID: 94915 RVA: 0x007201E0 File Offset: 0x0071E5E0
	public void SetInnerState(BeSkill.InnerState sta)
	{
		this.innerState = sta;
		if (this.innerState == BeSkill.InnerState.LAUNCH)
		{
			this.EndJoystick();
		}
	}

	// Token: 0x060172C4 RID: 94916 RVA: 0x007201FC File Offset: 0x0071E5FC
	public void UpdateEffectMove(int iDeltime)
	{
		if (this.joystickMode == SkillJoystickMode.FREE && this.innerState == BeSkill.InnerState.CHOOSE_TARGET && this.recordVx != 0 && this.recordVy != 0)
		{
			VInt vint = (VInt)this.owner.CurrentBeScene.sceneData.GetLogicXSize().x;
			VInt vint2 = (VInt)this.owner.CurrentBeScene.sceneData.GetLogicXSize().y;
			VInt vint3 = (VInt)this.owner.CurrentBeScene.sceneData.GetLogicZSize().x;
			VInt vint4 = (VInt)this.owner.CurrentBeScene.sceneData.GetLogicZSize().y;
			VInt3 position = this.owner.GetPosition();
			VFactor f = new VFactor(60000L, 1000L);
			this.effectPos.x = position.x + this.recordVx * f;
			this.effectPos.y = position.y + this.recordVy * f;
			this.effectPos.x = Mathf.Clamp(this.effectPos.x, this.owner.GetPosition().x - VInt.Float2VIntValue(this.effectRange.x), this.owner.GetPosition().x + VInt.Float2VIntValue(this.effectRange.x));
			this.effectPos.y = Mathf.Clamp(this.effectPos.y, this.owner.GetPosition().y - VInt.Float2VIntValue(this.effectRange.y), this.owner.GetPosition().y + VInt.Float2VIntValue(this.effectRange.y));
			this.effectPos.x = Mathf.Clamp(this.effectPos.x, vint.i, vint2.i);
			this.effectPos.y = Mathf.Clamp(this.effectPos.y, vint3.i, vint4.i);
			if (this.targetEffectWarning != null && this.targetEffectLine != null)
			{
				Vector3 vector = this.effectPos.vector3;
				this.targetEffectWarning.SetPosition(vector);
				this.targetEffectLine.SetPosition(vector);
			}
		}
	}

	// Token: 0x060172C5 RID: 94917 RVA: 0x00720480 File Offset: 0x0071E880
	private GeEffectEx CreateEffect(string path, Vec3 pos)
	{
		return this.owner.CurrentBeScene.currentGeScene.CreateEffect(path, 10000f, pos, 1f, 1f, true, false);
	}

	// Token: 0x060172C6 RID: 94918 RVA: 0x007204BC File Offset: 0x0071E8BC
	private void SpecialSkillStart()
	{
		if (!this.owner.CurrentBeBattle.HasFlag(BattleFlagType.SkillSpecialBug) && string.IsNullOrEmpty(this.startEnterNextFlag) && string.IsNullOrEmpty(this.endEnterNextFlag) && string.IsNullOrEmpty(this.startJumpBackCnacelFlag) && string.IsNullOrEmpty(this.endJumpBackCnacelFlag))
		{
			return;
		}
		this.enterFlag = false;
		this.enterNextHandle = this.owner.RegisterEvent(BeEventType.onSkillCurFrame, delegate(object[] args)
		{
			string a = (string)args[0];
			if (a == this.startEnterNextFlag)
			{
				this.enterFlag = true;
				this.SwitchEnterNextState();
			}
			else if (a == this.endEnterNextFlag)
			{
				this.enterFlag = false;
				this.ResetButtonEffect();
			}
			if (a == this.startJumpBackCnacelFlag)
			{
				this.canPressJumpBackCancel = true;
				this.ChangeJumpBackImage(false);
			}
			else if (a == this.endJumpBackCnacelFlag)
			{
				this.ChangeJumpBackImage(true);
				this.canPressJumpBackCancel = false;
			}
		});
	}

	// Token: 0x060172C7 RID: 94919 RVA: 0x0072054C File Offset: 0x0071E94C
	private void SpecialSkillPressAgain()
	{
		if (!this.skillState.IsRunning())
		{
			return;
		}
		if (this.enterFlag)
		{
			this.ResetButtonEffect();
			this.OnEnterNextPhase(this.curPhase);
			((BeActorStateGraph)this.owner.GetStateGraph()).ExecuteNextPhaseSkill();
		}
	}

	// Token: 0x060172C8 RID: 94920 RVA: 0x0072059C File Offset: 0x0071E99C
	private void SpecialSkillCancel()
	{
		if (this.owner.CurrentBeBattle.HasFlag(BattleFlagType.SkillSpecialBug))
		{
			if (this.startEnterNextFlag != null)
			{
				this.RemoveHandle();
				this.ResetButtonEffect();
			}
		}
		else
		{
			this.RemoveHandle();
			if (this.startEnterNextFlag != null)
			{
				this.ResetButtonEffect();
			}
			if (!string.IsNullOrEmpty(this.startJumpBackCnacelFlag))
			{
				this.ChangeJumpBackImage(true);
				this.canPressJumpBackCancel = false;
			}
		}
	}

	// Token: 0x060172C9 RID: 94921 RVA: 0x00720618 File Offset: 0x0071EA18
	private void SpecialSkillFinish()
	{
		if (this.owner.CurrentBeBattle.HasFlag(BattleFlagType.SkillSpecialBug))
		{
			if (this.startEnterNextFlag != null)
			{
				this.RemoveHandle();
				this.ResetButtonEffect();
			}
		}
		else
		{
			this.RemoveHandle();
			if (this.startEnterNextFlag != null)
			{
				this.ResetButtonEffect();
			}
			if (!string.IsNullOrEmpty(this.startJumpBackCnacelFlag))
			{
				this.ChangeJumpBackImage(true);
				this.canPressJumpBackCancel = false;
			}
		}
	}

	// Token: 0x060172CA RID: 94922 RVA: 0x00720691 File Offset: 0x0071EA91
	protected void SwitchEnterNextState()
	{
		this.skillButtonState = BeSkill.SkillState.WAIT_FOR_NEXT_PRESS;
		this.ChangeButtonEffect();
	}

	// Token: 0x060172CB RID: 94923 RVA: 0x007206A0 File Offset: 0x0071EAA0
	private void RemoveHandle()
	{
		if (this.enterNextHandle != null)
		{
			this.enterNextHandle.Remove();
			this.enterNextHandle = null;
		}
	}

	// Token: 0x060172CC RID: 94924 RVA: 0x007206BF File Offset: 0x0071EABF
	public void SetIgnoreCD(bool isIgnore, bool needReset = false)
	{
		if (isIgnore && needReset)
		{
			this.ResetCoolDown();
		}
		this.mIsIgnoreCD = isIgnore;
	}

	// Token: 0x17001F99 RID: 8089
	// (get) Token: 0x060172CD RID: 94925 RVA: 0x007206DA File Offset: 0x0071EADA
	// (set) Token: 0x060172CE RID: 94926 RVA: 0x007206E2 File Offset: 0x0071EAE2
	public ETCButton button
	{
		get
		{
			return this._button;
		}
		set
		{
			this._button = value;
			if (this.needSetIcon && this.iconPath != null)
			{
				InputManager._setButtonImageByPath(this._button, this.iconPath, 0.7f);
			}
		}
	}

	// Token: 0x17001F9A RID: 8090
	// (get) Token: 0x060172CF RID: 94927 RVA: 0x00720717 File Offset: 0x0071EB17
	// (set) Token: 0x060172D0 RID: 94928 RVA: 0x0072071F File Offset: 0x0071EB1F
	public BeActor owner { get; set; }

	// Token: 0x17001F9B RID: 8091
	// (get) Token: 0x060172D1 RID: 94929 RVA: 0x00720728 File Offset: 0x0071EB28
	public FrameRandomImp FrameRandom
	{
		get
		{
			if (this.owner.FrameRandom == null)
			{
				return BeSkill.randomForTown;
			}
			return this.owner.FrameRandom;
		}
	}

	// Token: 0x17001F9C RID: 8092
	// (get) Token: 0x060172D2 RID: 94930 RVA: 0x0072074B File Offset: 0x0071EB4B
	public TrailManagerImp TrailManager
	{
		get
		{
			return this.owner.CurrentBeBattle.TrailManager;
		}
	}

	// Token: 0x17001F9D RID: 8093
	// (get) Token: 0x060172D3 RID: 94931 RVA: 0x0072075D File Offset: 0x0071EB5D
	public BattleType battleType
	{
		get
		{
			if (this.owner.CurrentBeBattle == null)
			{
				return BattleType.Dungeon;
			}
			return this.owner.CurrentBeBattle.GetBattleType();
		}
	}

	// Token: 0x17001F9E RID: 8094
	// (get) Token: 0x060172D4 RID: 94932 RVA: 0x00720781 File Offset: 0x0071EB81
	public int raceType
	{
		get
		{
			if (this.owner.CurrentBeBattle == null)
			{
				return -1;
			}
			return this.owner.CurrentBeBattle.PkRaceType;
		}
	}

	// Token: 0x17001F9F RID: 8095
	// (get) Token: 0x060172D5 RID: 94933 RVA: 0x007207A5 File Offset: 0x0071EBA5
	public BeProjectilePoolImp BeProjectilePool
	{
		get
		{
			return this.owner.CurrentBeBattle.BeProjectilePool;
		}
	}

	// Token: 0x17001FA0 RID: 8096
	// (get) Token: 0x060172D6 RID: 94934 RVA: 0x007207B7 File Offset: 0x0071EBB7
	public BeAICommandPoolImp BeAICommandPool
	{
		get
		{
			return this.owner.CurrentBeBattle.BeAICommandPool;
		}
	}

	// Token: 0x17001FA1 RID: 8097
	// (get) Token: 0x060172D7 RID: 94935 RVA: 0x007207C9 File Offset: 0x0071EBC9
	// (set) Token: 0x060172D8 RID: 94936 RVA: 0x007207D1 File Offset: 0x0071EBD1
	public int useRate { get; set; }

	// Token: 0x17001FA2 RID: 8098
	// (get) Token: 0x060172D9 RID: 94937 RVA: 0x007207DA File Offset: 0x0071EBDA
	public bool canSwitchWeapon
	{
		get
		{
			return this.skillData.CanSwithWeapon == 1;
		}
	}

	// Token: 0x17001FA3 RID: 8099
	// (get) Token: 0x060172DB RID: 94939 RVA: 0x00720804 File Offset: 0x0071EC04
	// (set) Token: 0x060172DA RID: 94938 RVA: 0x007207EA File Offset: 0x0071EBEA
	public bool isCooldown
	{
		get
		{
			return this._coolDown > 0;
		}
		set
		{
			this._coolDown = ((!value) ? 0 : 1);
		}
	}

	// Token: 0x060172DC RID: 94940 RVA: 0x0072081E File Offset: 0x0071EC1E
	public bool IsJueXingSkill()
	{
		return this.skillData != null && this.skillData.SkillCategory == 4;
	}

	// Token: 0x060172DD RID: 94941 RVA: 0x0072083B File Offset: 0x0071EC3B
	public bool IsNormalSkill()
	{
		return this.skillData != null && this.skillData.SkillCategory == 1;
	}

	// Token: 0x060172DE RID: 94942 RVA: 0x00720858 File Offset: 0x0071EC58
	public bool IsCommonSkill()
	{
		return this.skillData != null && this.skillData.SkillCategory == 2;
	}

	// Token: 0x060172DF RID: 94943 RVA: 0x00720875 File Offset: 0x0071EC75
	public bool IsProfessionalSkill()
	{
		return this.skillData != null && this.skillData.SkillCategory == 3;
	}

	// Token: 0x060172E0 RID: 94944 RVA: 0x00720892 File Offset: 0x0071EC92
	public bool IsGuildSkill()
	{
		return this.skillData != null && this.skillData.SkillCategory == 5;
	}

	// Token: 0x17001FA4 RID: 8100
	// (get) Token: 0x060172E1 RID: 94945 RVA: 0x007208AF File Offset: 0x0071ECAF
	// (set) Token: 0x060172E2 RID: 94946 RVA: 0x007208B7 File Offset: 0x0071ECB7
	public int CurSkillWalkMode
	{
		get
		{
			return this._CurSkillWalkMode;
		}
		set
		{
			this._CurSkillWalkMode = value;
		}
	}

	// Token: 0x17001FA5 RID: 8101
	// (get) Token: 0x060172E3 RID: 94947 RVA: 0x007208C0 File Offset: 0x0071ECC0
	// (set) Token: 0x060172E4 RID: 94948 RVA: 0x007208C8 File Offset: 0x0071ECC8
	public bool hit
	{
		get
		{
			return this._hit;
		}
		set
		{
			this._hit = value;
		}
	}

	// Token: 0x17001FA6 RID: 8102
	// (get) Token: 0x060172E5 RID: 94949 RVA: 0x007208D1 File Offset: 0x0071ECD1
	// (set) Token: 0x060172E6 RID: 94950 RVA: 0x007208E0 File Offset: 0x0071ECE0
	public int level
	{
		get
		{
			return this._level;
		}
		set
		{
			this._level = value;
			if (this.skillData != null)
			{
				this._level = Mathf.Min(this.skillData.TopLevel, this._level);
			}
			if (this._level < 1)
			{
				this._level = 1;
			}
			if (this.owner != null)
			{
				BeEntityData entityData = this.owner.GetEntityData();
				if (entityData != null)
				{
					entityData.UpdateLevel(this.skillID, this._level);
				}
			}
		}
	}

	// Token: 0x17001FA7 RID: 8103
	// (get) Token: 0x060172E7 RID: 94951 RVA: 0x0072097B File Offset: 0x0071ED7B
	// (set) Token: 0x060172E8 RID: 94952 RVA: 0x00720983 File Offset: 0x0071ED83
	public bool ForceShowButtonImage
	{
		get
		{
			return this._forceShowButtonImage;
		}
		set
		{
			this._forceShowButtonImage = value;
		}
	}

	// Token: 0x060172E9 RID: 94953 RVA: 0x0072098C File Offset: 0x0071ED8C
	public void InitValues()
	{
		if (this.skillData != null)
		{
			this.mpCost = TableManager.GetValueFromUnionCell(this.skillData.MPCost, this.level, true);
			this.hpCost = TableManager.GetValueFromUnionCell(this.skillData.HPCost, this.level, true);
			this.hpCostPercent = TableManager.GetValueFromUnionCell(this.skillData.HPCostPercent, this.level, true);
			if (this.raceType != 8 && this.raceType != 9)
			{
				this.crystalCost = TableManager.GetValueFromUnionCell(this.skillData.CrystalCost, this.level, true);
			}
			else
			{
				this.crystalCost = 0;
			}
			this.useRate = TableManager.GetValueFromUnionCell(this.skillData.Probability, this.level, true);
			int valueFromUnionCell = TableManager.GetValueFromUnionCell((!BattleMain.IsModePvP(this.battleType)) ? this.skillData.Zscale : this.skillData.PVPZscale, this.level, true);
			if (valueFromUnionCell > 0)
			{
				this.skillZdimFactor = new VFactor((long)valueFromUnionCell, (long)GlobalLogic.VALUE_1000);
			}
			if (BattleMain.IsChijiNeedReplaceSkillId(this.skillID, this.battleType))
			{
				ChijiSkillMapTable tableItem = Singleton<TableManager>.instance.GetTableItem<ChijiSkillMapTable>(this.skillID, string.Empty, string.Empty);
				this.tableCD = TableManager.GetValueFromUnionCell(tableItem.RefreshTimePVP, this.level, true);
			}
			else
			{
				this.tableCD = ((!BattleMain.IsModePvP(this.battleType)) ? TableManager.GetValueFromUnionCell(this.skillData.RefreshTime, this.level, true) : TableManager.GetValueFromUnionCell(this.skillData.RefreshTimePVP, this.level, true));
			}
		}
	}

	// Token: 0x060172EA RID: 94954 RVA: 0x00720B68 File Offset: 0x0071EF68
	public void Init()
	{
		if (this.skillData != null)
		{
			this.InitValues();
			this.skillCategory = this.skillData.SkillCategory;
			this.canChangeWeapon = (this.skillData.CanSwithWeapon > 0);
			this.canPressJumpBackCancel = (this.skillData.PressBackJumpCancel > 0);
			this.skillSpeedFactor = this.skillData.Speed;
			this.charge = this.skillData.IsChargeEnable;
			this.walk = this.skillData.IsWalkEnable;
			this.hideSpellBar = (this.skillData.HideSpellBar == 1);
			this.isBuffSkill = (this.skillData.IsBuff > 0);
			this.costMode = this.skillData.CostMode;
			this.pressMode = (SkillPressMode)this.skillData.SkillPressType;
			this.isQTE = (this.skillData.IsQTE != 0);
			this.isRunAttack = (this.skillData.IsRunAttack != 0);
			this.skillSpeech = this.skillData.SkillSpeech;
			this.skillSpeechRand = this.skillData.SkillSpeechRand;
			this.skillWalkMode = this.skillData.WalkMode;
			this.SetInterruptSkills();
			for (int i = 0; i < this.skillData.HitInterruptSkills.Count; i++)
			{
				int num = this.skillData.HitInterruptSkills[i];
				if (num > 0 && !this.hitInterruptSkills.Contains(num))
				{
					this.hitInterruptSkills.Add(num);
				}
			}
			if (this.skillData.SkillEffect.Contains(SkillTable.eSkillEffect.PHYSICAL_SKILL))
			{
				this.skillMagicType = SkillMaigcType.PHYSIC;
			}
			else if (this.skillData.SkillEffect.Contains(SkillTable.eSkillEffect.MAGIC_SKILL))
			{
				this.skillMagicType = SkillMaigcType.MAGIC;
			}
			this.CurSkillWalkMode = this.skillData.WalkMode;
		}
		this.OnInit();
	}

	// Token: 0x060172EB RID: 94955 RVA: 0x00720D57 File Offset: 0x0071F157
	public void DeInit()
	{
		this.OnDeInit();
	}

	// Token: 0x060172EC RID: 94956 RVA: 0x00720D60 File Offset: 0x0071F160
	private void SetInterruptSkills()
	{
		string text = (!BattleMain.IsModePvP(this.battleType) || string.IsNullOrEmpty(this.skillData.InterruptSkillsPVP)) ? this.skillData.InterruptSkills : this.skillData.InterruptSkillsPVP;
		if (!string.IsNullOrEmpty(text))
		{
			if (!text.Contains(":"))
			{
				string[] array = text.Split(new char[]
				{
					'|'
				});
				for (int i = 0; i < array.Length; i++)
				{
					int num = 0;
					int.TryParse(array[i], out num);
					if (num > 0 && !this.interruptSkills.Contains(num))
					{
						this.interruptSkills.Add(num);
					}
				}
			}
			else
			{
				string[] array2 = text.Split(new char[]
				{
					'|'
				});
				for (int j = 0; j < array2.Length; j++)
				{
					string[] array3 = array2[j].Split(new char[]
					{
						':'
					});
					int num2 = 0;
					int num3 = 0;
					int.TryParse(array3[0], out num2);
					int.TryParse(array3[1], out num3);
					if (num2 != 0 && num3 != 0 && !this.jobInterruptSkills.ContainsKey(num2))
					{
						this.jobInterruptSkills[num3] = num2;
					}
				}
			}
		}
	}

	// Token: 0x060172ED RID: 94957 RVA: 0x00720EB8 File Offset: 0x0071F2B8
	public void InitForPassive()
	{
		if (this.skillData == null)
		{
			return;
		}
		if (this.skillData.SkillType == SkillTable.eSkillType.PASSIVE)
		{
			for (int i = 0; i < this.skillData.PreCondition.Count; i++)
			{
				SkillTable.ePreCondition ePreCondition = this.skillData.PreCondition[i];
				if (ePreCondition == SkillTable.ePreCondition.BEHIT)
				{
					if (this.owner != null)
					{
						this.eventHandler = this.owner.RegisterEvent(BeEventType.onHurt, delegate(object[] args)
						{
							this.DealEffectFrame();
						});
					}
				}
				else if (ePreCondition == SkillTable.ePreCondition.INIT)
				{
					this.DealEffectFrame();
					this.ExecuteOperation(this.ParseOperation());
				}
				else if (ePreCondition == SkillTable.ePreCondition.LOWHP && this.owner != null && this.skillData.ValueA.Count >= 1)
				{
					int value = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], 1, true);
					bool isTrigger = false;
					this.eventHandler = this.owner.RegisterEvent(BeEventType.onStateChange, delegate(object[] args)
					{
						BeEntityData entityData = this.owner.GetEntityData();
						if (entityData != null)
						{
							VFactor hprate = entityData.GetHPRate();
							VFactor b = new VFactor((long)value, (long)GlobalLogic.VALUE_1000);
							if (!isTrigger && hprate < b)
							{
								isTrigger = true;
								this.DealEffectFrame();
							}
						}
					});
				}
			}
		}
		this.AddBuffs();
		this.AddMechanisms();
	}

	// Token: 0x060172EE RID: 94958 RVA: 0x00720FF0 File Offset: 0x0071F3F0
	public void AddBuffs()
	{
		if (this.skillData != null && this.owner != null && this.skillData.BuffInfoIDs[0] != 0)
		{
			FlatBufferArray<int> buffInfos = (!BattleMain.IsModePvP(this.battleType)) ? this.skillData.BuffInfoIDs : this.skillData.BuffInfoIDsPVP;
			this.owner.RemoveMechanismBuffs(buffInfos, null);
			this.owner.LoadMechanismBuffs(buffInfos, this.level, false, null, false);
		}
	}

	// Token: 0x060172EF RID: 94959 RVA: 0x00721078 File Offset: 0x0071F478
	public void AddMechanisms()
	{
		if (this.skillData != null && this.owner != null && this.skillData.MechismIDs[0] != 0)
		{
			FlatBufferArray<int> flatBufferArray = (!BattleMain.IsModePvP(this.battleType)) ? this.skillData.MechismIDs : this.skillData.MechismIDsPVP;
			for (int i = 0; i < flatBufferArray.Count; i++)
			{
				this.skillMechanismList.Add(this.owner.AddMechanism(flatBufferArray[i], this.level, MechanismSourceType.NONE, null, 0));
			}
		}
	}

	// Token: 0x060172F0 RID: 94960 RVA: 0x0072111C File Offset: 0x0071F51C
	private void RemoveMechanisms()
	{
		if (this.skillData == null)
		{
			return;
		}
		if (this.owner == null)
		{
			return;
		}
		for (int i = 0; i < this.skillMechanismList.Count; i++)
		{
			this.owner.RemoveMechanism(this.skillMechanismList[i]);
		}
		this.skillMechanismList.Clear();
	}

	// Token: 0x060172F1 RID: 94961 RVA: 0x00721180 File Offset: 0x0071F580
	public void DealEffectFrame()
	{
		FlatBufferArray<int> flatBufferArray = (!BattleMain.IsModePvP(this.battleType)) ? this.skillData.HitEffectIDs : this.skillData.HitEffectIDsPVP;
		for (int i = 0; i < flatBufferArray.Count; i++)
		{
			EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(flatBufferArray[i], string.Empty, string.Empty);
			if (tableItem != null && this.owner != null)
			{
				if (tableItem.BuffID > 0)
				{
					this.owner.buffController.RemoveBuff(tableItem.BuffID, 0, 0);
				}
				else
				{
					for (int j = 0; j < tableItem.BuffInfoID.Count; j++)
					{
						if (tableItem.BuffInfoID[j] > 0)
						{
							this.owner.buffController.RemoveBuffByBuffInfoID(tableItem.BuffInfoID[j]);
						}
					}
					if (BattleMain.IsChijiNeedReplaceHurtId(flatBufferArray[i], this.battleType))
					{
						ChijiEffectMapTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ChijiEffectMapTable>(flatBufferArray[i], string.Empty, string.Empty);
						for (int k = 0; k < tableItem2.PVPBuffInfoID.Count; k++)
						{
							if (tableItem2.PVPBuffInfoID[k] > 0)
							{
								this.owner.buffController.RemoveBuffByBuffInfoID(tableItem2.PVPBuffInfoID[k]);
							}
						}
					}
					else
					{
						for (int l = 0; l < tableItem.PVPBuffInfoID.Count; l++)
						{
							if (tableItem.PVPBuffInfoID[l] > 0)
							{
								this.owner.buffController.RemoveBuffByBuffInfoID(tableItem.PVPBuffInfoID[l]);
							}
						}
					}
				}
			}
		}
		if ((int)this.FrameRandom.Range1000() <= this.useRate)
		{
			for (int m = 0; m < flatBufferArray.Count; m++)
			{
				this.owner.DealEffectFrame(null, flatBufferArray[m], 0, false, true, false, false);
				EffectTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(flatBufferArray[m], string.Empty, string.Empty);
				if (tableItem3 != null && tableItem3.BuffID > 0)
				{
					BeBuff beBuff = this.owner.buffController.HasBuffByID(tableItem3.BuffID);
					if (beBuff != null)
					{
						beBuff.passive = true;
					}
				}
			}
		}
	}

	// Token: 0x060172F2 RID: 94962 RVA: 0x007213F0 File Offset: 0x0071F7F0
	public void PostInit()
	{
		this.JoyStickPostInit();
		this.InitForPassive();
		if (this.owner != null)
		{
			this.SetComboSourceSkillID();
			BDEntityActionInfo skillActionInfo = this.owner.GetSkillActionInfo(this.skillID);
			if (skillActionInfo != null)
			{
				if (skillActionInfo.useCharge)
				{
					this.chargeConfig = skillActionInfo.chargeConfig;
				}
				if (skillActionInfo.skillEvents != null)
				{
					this.skillEvents = skillActionInfo.skillEvents;
				}
				if (skillActionInfo.useSpecialOperation)
				{
					this.specialOperate = true;
					this.operationConfig = skillActionInfo.operationConfig;
				}
			}
		}
		this.UpdateCanUseSkillWithRightWeapon();
		this.SetOrignWalkSpeed();
		this.OnPostInit();
		if (this.owner != null)
		{
			this.owner.TriggerEvent(BeEventType.onSkillPostInit, new object[]
			{
				this.skillID
			});
		}
	}

	// Token: 0x060172F3 RID: 94963 RVA: 0x007214BC File Offset: 0x0071F8BC
	private void SetComboSourceSkillID()
	{
		if (this.skillData.SkillCategory == 3)
		{
			bool flag = true;
			int i = 0;
			BDEntityActionInfo actionInfoBySkillID = this.owner.GetActionInfoBySkillID(this.skillID);
			if (actionInfoBySkillID == null)
			{
				return;
			}
			while (i < 10)
			{
				if (actionInfoBySkillID == null || actionInfoBySkillID.comboSkillID == 0)
				{
					break;
				}
				BeSkill skill = this.owner.GetSkill(actionInfoBySkillID.comboSkillID);
				if (skill == null)
				{
					break;
				}
				if (flag)
				{
					flag = false;
					this.comboSkillSourceID = this.skillID;
				}
				skill.comboSkillSourceID = this.skillID;
				i++;
				actionInfoBySkillID = this.owner.GetActionInfoBySkillID(actionInfoBySkillID.comboSkillID);
			}
		}
	}

	// Token: 0x060172F4 RID: 94964 RVA: 0x00721578 File Offset: 0x0071F978
	protected void SetOrignWalkSpeed()
	{
		try
		{
			int num = GlobalLogic.VALUE_1000;
			if (BattleMain.IsModePvP(this.battleType))
			{
				num = TableManager.GetValueFromUnionCell(this.skillData.WalkSpeedPVP, this.level, true);
			}
			else
			{
				num = TableManager.GetValueFromUnionCell(this.skillData.WalkSpeed, this.level, true);
			}
			this.walkSpeed = new VFactor((long)num, (long)GlobalLogic.VALUE_1000);
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("SetOrignWalkSpeed方法中的技能id为：{0}错误信息为：{1}", new object[]
			{
				this.skillID.ToString(),
				ex.ToString()
			});
		}
	}

	// Token: 0x060172F5 RID: 94965 RVA: 0x0072162C File Offset: 0x0071FA2C
	public void DealSkillEvents(EventCommand skillEvent)
	{
		if (this.skillEvents == null)
		{
			return;
		}
		for (int i = 0; i < this.skillEvents.Length; i++)
		{
			SkillEvent skillEvent2 = this.skillEvents[i];
			if (skillEvent2.eventType == skillEvent && (skillEvent2.workPhase == 0 || skillEvent2.workPhase == this.curPhase))
			{
				if ((skillEvent2.eventType == EventCommand.EVENT_COMMAND_PRESS_JOYSTICK || skillEvent2.eventType == EventCommand.EVENT_COMMAND_RELEASE_JOYSTICK) && !this.walk)
				{
					return;
				}
				if (skillEvent2.eventAction == SkillAction.CHANGE_ANIMATION)
				{
					if (this.owner != null)
					{
						this.owner.ChangeAnimation(skillEvent2.paramter, true);
					}
				}
				else if (skillEvent2.eventAction == SkillAction.DISPOSE_SKILL)
				{
					this.owner.FinishSkill(int.Parse(skillEvent2.paramter));
					this.owner.GetStateGraph().LocomoteState();
				}
			}
		}
	}

	// Token: 0x060172F6 RID: 94966 RVA: 0x00721714 File Offset: 0x0071FB14
	public void Start()
	{
		this.cancelByCombo = false;
		this.isComboSkill = (this.comboSkillSourceID != 0);
		this.comboSourceID = this.comboSkillSourceID;
		this.useCount++;
		this.canceled = false;
		this.hit = false;
		this.curPhase = 0;
		this.cdFlag = false;
		this.skillState.SetRunning();
		this.JoyStickStart();
		if (this.skillData.SwitchSkillID > 0)
		{
			this.useInternalID = this.CheckSpellSituation();
		}
		this.buttonState = ButtonState.PRESS;
		this.pressDuration = 0;
		this.isCharging = false;
		this.useTimeAcc = 0;
		this.charged = false;
		if (this.pressMode == SkillPressMode.BUFF_INDICATOR && this.owner != null)
		{
			if (this.hander1 == null)
			{
				this.hander1 = this.owner.RegisterEvent(BeEventType.onAddBuff, delegate(object[] args)
				{
					BeBuff beBuff = args[0] as BeBuff;
					if (beBuff != null && beBuff.buffID == this.skillData.WatchBuffID && this.button != null)
					{
						this.button.StartBuffCD(beBuff);
					}
				});
			}
			if (this.hander2 == null)
			{
				this.hander2 = this.owner.RegisterEvent(BeEventType.onRemoveBuff, delegate(object[] args)
				{
					BeBuff beBuff = args[1] as BeBuff;
					if (beBuff != null && beBuff.buffID == this.skillData.WatchBuffID && this.button != null)
					{
						this.button.StopBuffCD();
					}
				});
			}
		}
		this.OnStart();
		this.LoadJoystickUI();
		if (this.NeedCoolDown() && this.skillData.CDPhase == 0 && !this.isComboSkill)
		{
			this.StartCoolDown();
		}
		this.ChangeButtonState();
		this.ChangeJumpBackImage(false);
		this.ShowSpeech();
		this.ResetMoveZAccExtra();
		this.SpecialSkillStart();
		this.owner.TriggerEventNew(BeEventType.onSkillStart, new EventParam
		{
			m_Int = this.skillID,
			m_Obj = this
		});
	}

	// Token: 0x060172F7 RID: 94967 RVA: 0x007218B2 File Offset: 0x0071FCB2
	public VFactor GetSkillZDimFactor()
	{
		return this.skillZdimFactor;
	}

	// Token: 0x060172F8 RID: 94968 RVA: 0x007218BC File Offset: 0x0071FCBC
	public bool IsOpenCameraShock()
	{
		if (this.skillCategory != 4 || (this.owner.CurrentBeBattle != null && !this.owner.CurrentBeBattle.FunctionIsOpen(BattleFlagType.JunXingShock)))
		{
			InputManager.CameraShockMode cameraShockMode = Singleton<SettingManager>.GetInstance().GetCameraShockMode();
			return cameraShockMode == InputManager.CameraShockMode.OPEN;
		}
		return true;
	}

	// Token: 0x060172F9 RID: 94969 RVA: 0x00721914 File Offset: 0x0071FD14
	public void ShowSpeech()
	{
		if (this.owner != null && this.owner.GetEntityData() != null && this.owner.GetEntityData().isShowSkillSpeech)
		{
			if (this.skillSpeech != null && this.skillSpeechRand > 0 && this.FrameRandom.InRange(0, GlobalLogic.VALUE_1000) < this.skillSpeechRand)
			{
				bool useSkill = true;
				bool isPet = this.owner.GetEntityData().isPet;
				if (isPet)
				{
					useSkill = false;
				}
				this.owner.m_pkGeActor.ShowHeadDialog(this.skillSpeech, false, false, false, useSkill, 3.5f, isPet);
			}
			this.ShowSkillTip();
		}
	}

	// Token: 0x060172FA RID: 94970 RVA: 0x007219C8 File Offset: 0x0071FDC8
	public void ShowSkillTip()
	{
		if (this.skillData != null && Utility.IsStringValid(this.skillData.SkillDealText))
		{
			float num = 5000f;
			if (this.skillData.SkillDealTextDuration > 0)
			{
				num = (float)this.skillData.SkillDealTextDuration;
			}
			SystemNotifyManager.SysDungeonSkillTip(this.skillData.SkillDealText, num / 1000f, false);
		}
	}

	// Token: 0x060172FB RID: 94971 RVA: 0x00721A34 File Offset: 0x0071FE34
	public void ChangeButtonState()
	{
		if (this.pressMode == SkillPressMode.PRESS_AGAIN_CANCEL)
		{
			if (this.button != null)
			{
				this.button.AddEffect(ETCButton.eEffectType.onBreak, this.skillData.IsBuff > 0);
			}
		}
		else if (this.pressMode == SkillPressMode.TWO_PRESS)
		{
			if (this.button != null)
			{
				this.button.AddEffect(ETCButton.eEffectType.onContinue, this.skillData.IsBuff > 0);
			}
			this.skillButtonState = BeSkill.SkillState.WAIT_FOR_NEXT_PRESS;
		}
		else if (this.pressMode == SkillPressMode.PRESS_AGAIN_CANCEL_OUT)
		{
			if (this.button != null)
			{
				this.button.AddEffect(ETCButton.eEffectType.onBreak, this.skillData.IsBuff > 0);
			}
			this.skillButtonState = BeSkill.SkillState.WAIT_FOR_NEXT_PRESS;
		}
		else if (this.pressMode == SkillPressMode.TWO_PRESS_OUT)
		{
			if (this.button != null)
			{
				this.button.AddEffect(ETCButton.eEffectType.onContinue, this.skillData.IsBuff > 0);
			}
			this.skillButtonState = BeSkill.SkillState.WAIT_FOR_NEXT_PRESS;
		}
		else if (this.pressMode == SkillPressMode.PRESS_MANY)
		{
			this.skillButtonState = BeSkill.SkillState.WAIT_FOR_NEXT_PRESS;
		}
		else if (this.pressMode == SkillPressMode.PRESS_JOYSTICK)
		{
			this.skillButtonState = BeSkill.SkillState.WAIT_FOR_NEXT_PRESS;
		}
		else if (this.pressMode == SkillPressMode.PRESS_MANY_TWO)
		{
			this.skillButtonState = BeSkill.SkillState.WAIT_FOR_NEXT_PRESS;
		}
	}

	// Token: 0x060172FC RID: 94972 RVA: 0x00721B8C File Offset: 0x0071FF8C
	public void RestoreButtonState()
	{
		if (this.pressMode == SkillPressMode.PRESS_AGAIN_CANCEL)
		{
			if (this.button != null)
			{
				this.button.RemoveEffect(ETCButton.eEffectType.onBreak, this.skillData.IsBuff > 0);
			}
		}
		else if (this.pressMode == SkillPressMode.TWO_PRESS)
		{
			if (this.button != null)
			{
				this.button.RemoveEffect(ETCButton.eEffectType.onContinue, this.skillData.IsBuff > 0);
			}
			this.skillButtonState = BeSkill.SkillState.NORMAL;
		}
	}

	// Token: 0x060172FD RID: 94973 RVA: 0x00721C14 File Offset: 0x00720014
	public void RestoreButtonStateOut()
	{
		if (this.pressMode == SkillPressMode.PRESS_AGAIN_CANCEL_OUT)
		{
			if (this.button != null)
			{
				this.button.RemoveEffect(ETCButton.eEffectType.onBreak, this.skillData.IsBuff > 0);
			}
			this.skillButtonState = BeSkill.SkillState.NORMAL;
		}
		else if (this.pressMode == SkillPressMode.TWO_PRESS_OUT)
		{
			if (this.button != null)
			{
				this.button.RemoveEffect(ETCButton.eEffectType.onContinue, this.skillData.IsBuff > 0);
			}
			this.skillButtonState = BeSkill.SkillState.NORMAL;
		}
	}

	// Token: 0x060172FE RID: 94974 RVA: 0x00721CA2 File Offset: 0x007200A2
	public virtual bool NeedCost()
	{
		return true;
	}

	// Token: 0x060172FF RID: 94975 RVA: 0x00721CA5 File Offset: 0x007200A5
	public void SetButtonRelease()
	{
		this.buttonState = ButtonState.RELEASE;
		this.EndJoystick();
	}

	// Token: 0x06017300 RID: 94976 RVA: 0x00721CB4 File Offset: 0x007200B4
	public void SetButtonPressAgain()
	{
		if (this.buttonState == ButtonState.PRESS_AGAIN)
		{
			return;
		}
		if (this.pressMode == SkillPressMode.PRESS_AGAIN_CANCEL && !this.CanCancel())
		{
			return;
		}
		this.buttonState = ButtonState.PRESS_AGAIN;
		this.RestoreButtonState();
		if (this.pressMode == SkillPressMode.PRESS_AGAIN_CANCEL && this.owner != null)
		{
			this.owner.Locomote(new BeStateData(0, 0), false);
		}
	}

	// Token: 0x06017301 RID: 94977 RVA: 0x00721D1D File Offset: 0x0072011D
	public void SetChargeCdTime(int time)
	{
		this.chargeCD = true;
		this.chargeCDTimeAcc = time;
	}

	// Token: 0x06017302 RID: 94978 RVA: 0x00721D30 File Offset: 0x00720130
	public bool CheckSpellSituation()
	{
		bool result = false;
		VInt2 distance = new VInt2(VInt.NewVInt(this.skillData.RangeX, GlobalLogic.VALUE_1000).i, VInt.NewVInt(this.skillData.RangeY, GlobalLogic.VALUE_1000).i);
		List<BeEntity> list = ListPool<BeEntity>.Get();
		VFactor yReduceFactor = VFactor.NewVFactorF(Global.Settings.shooterFitPercent, 1000);
		this.owner.CurrentBeScene.FindFaceTargets(list, this.owner, distance, yReduceFactor, VInt.NewVInt(this.skillData.BackRangeX, GlobalLogic.VALUE_1000));
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] is BeObject || !list[i].HasTag(1) || list[i].HasTag(4))
			{
				result = true;
				break;
			}
		}
		ListPool<BeEntity>.Release(list);
		return result;
	}

	// Token: 0x06017303 RID: 94979 RVA: 0x00721E34 File Offset: 0x00720234
	public void Finish()
	{
		this.isCharging = false;
		this.joystickHasMove = false;
		this.skillState.SetDead();
		this.RestoreCameraMove(false);
		this.RestoreButtonState();
		this.owner.RemoveRepeatDamage();
		this.ChangeJumpBackImage(true);
		this.OnFinish();
		this.StartComboSkillCoolDown(true);
		this.owner.buffController.TriggerBuffs(BuffCondition.RELEASE_SEPCIFY_SKILL_COMPLETE, null, this.skillID);
		this.owner.TriggerEvent(BeEventType.onCastSkillFinish, new object[]
		{
			this.skillID
		});
		this.RemoveAllHandles();
		this.ResetMoveZAccExtra();
		this.SpecialSkillFinish();
	}

	// Token: 0x06017304 RID: 94980 RVA: 0x00721ED7 File Offset: 0x007202D7
	public bool isFinish()
	{
		return this.skillState.GetState() == BDStat.State.DEAD;
	}

	// Token: 0x06017305 RID: 94981 RVA: 0x00721EE8 File Offset: 0x007202E8
	private void StartComboSkillCoolDown(bool onlyCheckComboSkill = true)
	{
		if (!this.cdFlag)
		{
			if (this.isComboSkill)
			{
				if (this.comboSourceID != 0)
				{
					if (this.owner.TriggerEventNew(BeEventType.onComboSkillCDCoolDown, new EventParam
					{
						m_Int = this.skillID,
						m_Bool = false
					}).m_Bool)
					{
						return;
					}
					BeSkill skill = this.owner.GetSkill(this.comboSourceID);
					if (skill != null)
					{
						skill.StartCoolDown();
					}
				}
				else
				{
					this.StartCoolDown();
				}
			}
			else if (!onlyCheckComboSkill)
			{
				this.StartCoolDown();
			}
		}
	}

	// Token: 0x06017306 RID: 94982 RVA: 0x00721F89 File Offset: 0x00720389
	public bool IsCanceled()
	{
		return this.canceled;
	}

	// Token: 0x17001FA8 RID: 8104
	// (get) Token: 0x06017307 RID: 94983 RVA: 0x00721F94 File Offset: 0x00720394
	public int LeftInitCd
	{
		get
		{
			int currentCD = this.GetCurrentCD();
			if (this.initTableCd < currentCD)
			{
				return currentCD - this.cdTimeAcc;
			}
			return this.initTableCd - this.cdTimeAcc;
		}
	}

	// Token: 0x06017308 RID: 94984 RVA: 0x00721FD4 File Offset: 0x007203D4
	public void AccTimeCD(int accValue)
	{
		this.cdTimeAcc += accValue;
		if (this.cdTimeAcc >= this.GetCurrentCD())
		{
			this.FinishCoolDown();
		}
	}

	// Token: 0x06017309 RID: 94985 RVA: 0x00721FFC File Offset: 0x007203FC
	public void StartInitCD(bool isPvP = false)
	{
		int num = 0;
		if (BattleMain.IsChijiNeedReplaceSkillId(this.skillID, this.battleType))
		{
			ChijiSkillMapTable tableItem = Singleton<TableManager>.instance.GetTableItem<ChijiSkillMapTable>(this.skillID, string.Empty, string.Empty);
			this.initTableCd = TableManager.GetValueFromUnionCell(tableItem.InitCDPVP, this.level, true);
		}
		else if (this.skillData != null)
		{
			this.initTableCd = ((!isPvP) ? TableManager.GetValueFromUnionCell(this.skillData.InitCD, this.level, true) : TableManager.GetValueFromUnionCell(this.skillData.InitCDPVP, this.level, true));
		}
		if (this.initTableCd > 0)
		{
			this.StartCoolDown();
			if (num < this.GetCurrentCD())
			{
				this.cdTimeAcc = this.GetCurrentCD() - this.initTableCd;
			}
		}
	}

	// Token: 0x0601730A RID: 94986 RVA: 0x007220E8 File Offset: 0x007204E8
	protected void ChangeJumpBackImage(bool restore)
	{
		if (!this.canPressJumpBackCancel)
		{
			return;
		}
		if (!this.owner.isLocalActor)
		{
			return;
		}
		string spritePath = (!restore) ? this.jumpBackCancelImage : this.jumpBackImage;
		if (InputManager.instance != null)
		{
			ETCButton specialETCButton = InputManager.instance.GetSpecialETCButton(SpecialSkillID.JUMP_BACK);
			if (specialETCButton != null)
			{
				specialETCButton.SetFgImage(spritePath, true);
			}
		}
	}

	// Token: 0x0601730B RID: 94987 RVA: 0x00722158 File Offset: 0x00720558
	private bool CanCancel()
	{
		return this.useTimeAcc >= VRate.Conver(Global.Settings.skillCancelLimitTime);
	}

	// Token: 0x0601730C RID: 94988 RVA: 0x00722174 File Offset: 0x00720574
	public void PressAgainCancel()
	{
		if (!this.CanCancel())
		{
			return;
		}
		this.OnClickAgainCancel();
		this.Cancel();
		this.skillButtonState = BeSkill.SkillState.NORMAL;
		this.RestoreButtonStateOut();
		this.StartCoolDown();
	}

	// Token: 0x0601730D RID: 94989 RVA: 0x007221A1 File Offset: 0x007205A1
	public void PressJoystick()
	{
		this.OnClickAgain();
	}

	// Token: 0x0601730E RID: 94990 RVA: 0x007221A9 File Offset: 0x007205A9
	public void PressAgainRelease()
	{
		this.OnClickAgain();
		this.Cancel();
		this.skillButtonState = BeSkill.SkillState.NORMAL;
		this.RestoreButtonStateOut();
	}

	// Token: 0x0601730F RID: 94991 RVA: 0x007221C4 File Offset: 0x007205C4
	public void PressMany()
	{
		this.OnClickAgain();
		this.SpecialSkillPressAgain();
	}

	// Token: 0x06017310 RID: 94992 RVA: 0x007221D2 File Offset: 0x007205D2
	public void PressAgain()
	{
		this.OnClickAgain();
		this.skillButtonState = BeSkill.SkillState.NORMAL;
		this.RestoreButtonStateOut();
	}

	// Token: 0x06017311 RID: 94993 RVA: 0x007221E8 File Offset: 0x007205E8
	public void Cancel()
	{
		if (this.canceled)
		{
			return;
		}
		this.canceled = true;
		this.isCharging = false;
		this.joystickHasMove = false;
		this.owner.RemoveRepeatDamage();
		this.RestoreCameraMove(false);
		this.RestoreButtonState();
		this.RestoreButtonStateOut();
		this.SetButtonRelease();
		this.OnCancel();
		this.ChangeJumpBackImage(true);
		if (!this.cdFlag)
		{
			this.CancelSkillStartCoolDown();
		}
		this.skillState.SetDead();
		this.RemoveAllHandles();
		this.ResetMoveZAccExtra();
		this.SpecialSkillCancel();
		this.owner.TriggerEvent(BeEventType.onSkillCancel, new object[]
		{
			this.skillID
		});
	}

	// Token: 0x06017312 RID: 94994 RVA: 0x00722296 File Offset: 0x00720696
	private void CancelSkillStartCoolDown()
	{
		if (!this.cancelByCombo)
		{
			this.StartComboSkillCoolDown(false);
		}
	}

	// Token: 0x06017313 RID: 94995 RVA: 0x007222AC File Offset: 0x007206AC
	public void RestoreCameraMove(bool isCancel = false)
	{
		BDEntityActionInfo skillActionInfo = this.owner.GetSkillActionInfo(this.skillID);
		if (skillActionInfo != null)
		{
			float timelen = (!this.CheckResetCamera() || !isCancel || BattleMain.IsModePvP(this.battleType)) ? skillActionInfo.cameraRestoreTime : 0.01f;
			if (skillActionInfo.cameraRestore && skillActionInfo.cameraRestoreTime > 0f)
			{
				GeCameraControllerScroll controller = this.owner.CurrentBeScene.currentGeScene.GetCamera().GetController();
				float off = -1f * controller.GetOffset();
				controller.MoveCamera(off, timelen);
			}
		}
	}

	// Token: 0x06017314 RID: 94996 RVA: 0x00722350 File Offset: 0x00720750
	public virtual bool CheckSpellCondition(ActionState state)
	{
		bool flag = false;
		for (int i = 0; i < this.skillData.PreCondition.Count; i++)
		{
			switch (this.skillData.PreCondition[i])
			{
			case SkillTable.ePreCondition.STAND:
				if (state == ActionState.AS_IDLE)
				{
					flag = true;
				}
				break;
			case SkillTable.ePreCondition.WALK:
				if (state == ActionState.AS_WALK)
				{
					flag = true;
				}
				break;
			case SkillTable.ePreCondition.RUN:
				if (state == ActionState.AS_RUN)
				{
					flag = true;
				}
				break;
			case SkillTable.ePreCondition.JUMP:
				if (this.owner.HasTag(2))
				{
					flag = true;
				}
				break;
			case SkillTable.ePreCondition.BEHIT:
				if (this.owner.sgGetCurrentState() == 4)
				{
					flag = true;
				}
				break;
			case SkillTable.ePreCondition.DAODI:
				if (this.owner.sgGetCurrentState() == 11)
				{
					flag = true;
				}
				break;
			case SkillTable.ePreCondition.JUMP_BACK:
				if (this.owner.sgGetCurrentState() == 6)
				{
					flag = true;
				}
				break;
			}
			if (flag)
			{
				break;
			}
		}
		int lowHPPercent = this.GetLowHPPercent();
		if (flag && lowHPPercent > 0)
		{
			flag = false;
			BeEntityData entityData = this.owner.GetEntityData();
			if (entityData != null)
			{
				VFactor hprate = entityData.GetHPRate();
				VFactor b = new VFactor((long)lowHPPercent, (long)GlobalLogic.VALUE_1000);
				if (hprate < b)
				{
					flag = true;
				}
			}
		}
		return flag;
	}

	// Token: 0x06017315 RID: 94997 RVA: 0x007224B4 File Offset: 0x007208B4
	public int GetLowHPPercent()
	{
		int result = 0;
		if (this.skillData.LowHpPercent.Length == 1)
		{
			result = this.skillData.LowHpPercent[0];
		}
		else if (this.skillData.LowHpPercent.Length == 2)
		{
			if (BattleMain.IsModePvP(this.battleType))
			{
				result = this.skillData.LowHpPercent[1];
			}
			else
			{
				result = this.skillData.LowHpPercent[0];
			}
		}
		return result;
	}

	// Token: 0x06017316 RID: 94998 RVA: 0x00722540 File Offset: 0x00720940
	public virtual bool CanUseSkill()
	{
		if (!this.CanUseInPvp())
		{
			return false;
		}
		bool flag;
		if (!Global.Settings.skillHasCooldown)
		{
			flag = true;
		}
		else
		{
			flag = !this.isCooldown;
			if (BeClientSwitch.FunctionIsOpen(ClientSwitchType.SkillCanSummon))
			{
				flag = (flag && this.CanSummon2());
			}
			else
			{
				flag = (flag && this.CanSummon());
			}
		}
		if (this.isRunAttack && this.owner.hasRunAttackConfig)
		{
			flag = (flag && this.owner.sgGetCurrentState() == 3 && this.owner.IsRunning());
		}
		return (flag && this.canUseWithRightWeapon) || this.CanForceUseSkill();
	}

	// Token: 0x06017317 RID: 94999 RVA: 0x0072260B File Offset: 0x00720A0B
	public virtual BeActor.SkillCannotUseType GetCannotUseType()
	{
		if (!this.canUseWithRightWeapon)
		{
			return BeActor.SkillCannotUseType.NO_RIGHT_WEAPON;
		}
		if (!this.CanUseInPvp())
		{
			return BeActor.SkillCannotUseType.CAN_NOT_USE;
		}
		return BeActor.SkillCannotUseType.CAN_USE;
	}

	// Token: 0x06017318 RID: 95000 RVA: 0x00722629 File Offset: 0x00720A29
	private bool CanUseInPvp()
	{
		return this.skillData == null || !BattleMain.IsModePvP(this.battleType) || this.skillData.CanUseInPVP != 3;
	}

	// Token: 0x06017319 RID: 95001 RVA: 0x00722660 File Offset: 0x00720A60
	public bool CanSummon()
	{
		if (this.skillData.SummonRestrainEffectID > 0)
		{
			EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(this.skillData.SummonRestrainEffectID, string.Empty, string.Empty);
			if (tableItem != null && tableItem.SummonID > 0)
			{
				int valueFromUnionCell = TableManager.GetValueFromUnionCell(tableItem.SummonNum, this.GetLevel(), true);
				int summonNumLimit = tableItem.SummonNumLimit;
				int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(tableItem.SummonGroupNumLimit, this.GetLevel(), true);
				int summonGroup = tableItem.SummonGroup;
				int summonNum = this.owner.GetSummonNum(tableItem.SummonID, valueFromUnionCell, summonNumLimit, summonGroup, valueFromUnionCell2);
				return summonNum > 0;
			}
		}
		return true;
	}

	// Token: 0x0601731A RID: 95002 RVA: 0x00722704 File Offset: 0x00720B04
	public bool CanSummon2()
	{
		if (this.skillData.SummonRestrainEffectID > 0 || this.summonEffectData.summonId > 0)
		{
			int summonNum = this.owner.GetSummonNum(this.summonEffectData.summonId, this.summonEffectData.summonNum, this.summonEffectData.singleNumLimit, this.summonEffectData.summonGroup, this.summonEffectData.groupNumLimit);
			return summonNum > 0;
		}
		return true;
	}

	// Token: 0x0601731B RID: 95003 RVA: 0x0072277C File Offset: 0x00720B7C
	public int GetMPCost()
	{
		VRate vrate = this.mpCostReduceRate;
		if (this.owner != null)
		{
			vrate += this.owner.GetEntityData().GetMPCostReduce(this.skillMagicType);
		}
		return this.mpCost * (VRate.one - vrate).factor;
	}

	// Token: 0x0601731C RID: 95004 RVA: 0x007227DB File Offset: 0x00720BDB
	public int GetHPCost(int maxHP = 0)
	{
		if (this.hpCostPercent > 0)
		{
			return maxHP * VFactor.NewVFactor((long)this.hpCostPercent, (long)GlobalLogic.VALUE_1000);
		}
		return this.hpCost;
	}

	// Token: 0x0601731D RID: 95005 RVA: 0x00722817 File Offset: 0x00720C17
	public int GetCrystalCost()
	{
		return this.crystalCost;
	}

	// Token: 0x17001FA9 RID: 8105
	// (get) Token: 0x0601731E RID: 95006 RVA: 0x00722824 File Offset: 0x00720C24
	public int CDTimeAcc
	{
		get
		{
			if (this.isCooldown)
			{
				return this.cdTimeAcc;
			}
			return 0;
		}
	}

	// Token: 0x17001FAA RID: 8106
	// (get) Token: 0x0601731F RID: 95007 RVA: 0x00722839 File Offset: 0x00720C39
	public int CDLeftTime
	{
		get
		{
			if (this.isCooldown)
			{
				return this.GetCurrentCD() - this.cdTimeAcc;
			}
			return 0;
		}
	}

	// Token: 0x06017320 RID: 95008 RVA: 0x00722855 File Offset: 0x00720C55
	public void UpdateJoystick(int degree)
	{
		this.joystickHasMove = true;
		this.OnUpdateJoystick(degree);
	}

	// Token: 0x06017321 RID: 95009 RVA: 0x00722865 File Offset: 0x00720C65
	public void ReleaseJoystick()
	{
		this.OnReleaseJoystick();
	}

	// Token: 0x06017322 RID: 95010 RVA: 0x00722870 File Offset: 0x00720C70
	public void Update(int deltaTime)
	{
		this.useTimeAcc += deltaTime;
		if (this.owner != null && (this.isQTE || (this.isRunAttack && this.owner.hasRunAttackConfig)))
		{
			bool flag = this.owner.CanUseSkill(this.skillID);
			if (flag != this.canUse)
			{
				this.canUse = flag;
				if (this.button != null)
				{
					this.button.gameObject.CustomActive(this.canUse);
				}
			}
		}
		if (this.isCooldown)
		{
			this.cdTimeAcc += deltaTime;
			if (this.cdTimeAcc >= this.GetCurrentCD())
			{
				this.FinishCoolDown();
			}
		}
		if (this.chargeCDTimeAcc > 0)
		{
			this.chargeCDTimeAcc -= deltaTime;
			this.charge = false;
		}
		else if (this.chargeCD)
		{
			this.chargeCD = false;
			this.charge = true;
		}
		if (this.skillState.IsRunning())
		{
			if (this.buttonState == ButtonState.PRESS)
			{
				this.pressDuration += deltaTime;
			}
			this.OnUpdate(deltaTime);
			this.UpdateEffectMove(deltaTime);
			this._SwitchToAssignPhase();
		}
	}

	// Token: 0x06017323 RID: 95011 RVA: 0x007229B8 File Offset: 0x00720DB8
	public void EnterPhase(int phase)
	{
		if (!this.cdFlag && phase == this.skillData.CDPhase)
		{
			this.StartCoolDown();
		}
		this.curPhase = phase;
		this.OnEnterPhase(phase);
		this.owner.TriggerEventNew(BeEventType.onEnterPhase, new EventParam
		{
			m_Int = this.skillID,
			m_Int2 = phase
		});
	}

	// Token: 0x06017324 RID: 95012 RVA: 0x00722A21 File Offset: 0x00720E21
	public void SetSkillStartPhase(int phase)
	{
		this._skillStartPahse = phase;
	}

	// Token: 0x06017325 RID: 95013 RVA: 0x00722A2C File Offset: 0x00720E2C
	private void _SwitchToAssignPhase()
	{
		if (this._skillStartPahse <= 0)
		{
			return;
		}
		for (int i = 0; i < this._skillStartPahse - 1; i++)
		{
			(this.owner.GetStateGraph() as BeActorStateGraph).ExecuteNextPhaseSkill();
		}
		this._skillStartPahse = 0;
	}

	// Token: 0x06017326 RID: 95014 RVA: 0x00722A7B File Offset: 0x00720E7B
	public int GetCurrPhase()
	{
		return this.curPhase;
	}

	// Token: 0x06017327 RID: 95015 RVA: 0x00722A83 File Offset: 0x00720E83
	public void ResetCoolDown()
	{
		this.isCooldown = false;
		this.cdAtStartCoolDown = 0;
	}

	// Token: 0x06017328 RID: 95016 RVA: 0x00722A94 File Offset: 0x00720E94
	public void StartCoolDown()
	{
		if (this.mIsIgnoreCD)
		{
			return;
		}
		this.cdAtStartCoolDown = this.GetCurrentCD();
		this.cdFlag = true;
		this.cdTimeAcc = 0;
		this.isCooldown = true;
		this.owner.TriggerEventNew(BeEventType.onSkillCoolDownStart, new EventParam
		{
			m_Int = this.skillID
		});
	}

	// Token: 0x06017329 RID: 95017 RVA: 0x00722AF2 File Offset: 0x00720EF2
	public virtual bool NeedCoolDown()
	{
		return this.pressMode != SkillPressMode.PRESS_AGAIN_CANCEL_OUT && this.pressMode != SkillPressMode.PRESS_JOYSTICK;
	}

	// Token: 0x0601732A RID: 95018 RVA: 0x00722B10 File Offset: 0x00720F10
	public void FinishCoolDown()
	{
		this.isCooldown = false;
		this.cdAtStartCoolDown = 0;
		this.owner.TriggerEventNew(BeEventType.onSkillCoolDownFinish, new EventParam
		{
			m_Int = this.skillID
		});
	}

	// Token: 0x0601732B RID: 95019 RVA: 0x00722B4F File Offset: 0x00720F4F
	public bool IsTargetTypeEnemy()
	{
		return this.skillData.SkillTarget == SkillTable.eSkillTarget.ENEMY;
	}

	// Token: 0x0601732C RID: 95020 RVA: 0x00722B5F File Offset: 0x00720F5F
	public bool IsFroce()
	{
		return this.skillData.IsForce;
	}

	// Token: 0x0601732D RID: 95021 RVA: 0x00722B6C File Offset: 0x00720F6C
	public virtual bool CanBePositiveAbort()
	{
		return this.skillData.IsCanCancel;
	}

	// Token: 0x0601732E RID: 95022 RVA: 0x00722B7C File Offset: 0x00720F7C
	public bool CanInterrupt(int otherSkillID, bool otherSkillHit = false)
	{
		return (otherSkillID != 3113 || this.owner.GetPosition().z <= 0) && (this.InterruptSkills(otherSkillID) || (otherSkillHit && this.hitInterruptSkills.Contains(otherSkillID)));
	}

	// Token: 0x0601732F RID: 95023 RVA: 0x00722BD4 File Offset: 0x00720FD4
	public virtual bool CanBeInterrupt(int skillId)
	{
		this.interParams[0] = this;
		int[] array = this.interParams[1] as int[];
		array[0] = skillId;
		array[1] = 0;
		if (this.owner != null)
		{
			this.owner.TriggerEvent(BeEventType.onSkillCanBeInterrupt, this.interParams);
		}
		return array[1] != 0;
	}

	// Token: 0x06017330 RID: 95024 RVA: 0x00722C2C File Offset: 0x0072102C
	private bool InterruptSkills(int skillID)
	{
		if (this.jobInterruptSkills.Count > 0)
		{
			return this.jobInterruptSkills.ContainsKey(skillID) && this.jobInterruptSkills[skillID] == this.owner.professionID;
		}
		return this.interruptSkills.Contains(skillID);
	}

	// Token: 0x06017331 RID: 95025 RVA: 0x00722C88 File Offset: 0x00721088
	public virtual bool CanForceUseSkill()
	{
		return false;
	}

	// Token: 0x06017332 RID: 95026 RVA: 0x00722C8B File Offset: 0x0072108B
	public int GetWalkMode()
	{
		return this.skillData.WalkMode;
	}

	// Token: 0x06017333 RID: 95027 RVA: 0x00722C98 File Offset: 0x00721098
	public bool CanWalk()
	{
		return this.skillData.WalkMode != 0;
	}

	// Token: 0x06017334 RID: 95028 RVA: 0x00722CAB File Offset: 0x007210AB
	public VFactor GetWalkSpeedRate()
	{
		return this.walkSpeed;
	}

	// Token: 0x06017335 RID: 95029 RVA: 0x00722CB3 File Offset: 0x007210B3
	public int GetLevel()
	{
		return this.level;
	}

	// Token: 0x06017336 RID: 95030 RVA: 0x00722CBB File Offset: 0x007210BB
	public VFactor GetSkillSpeedFactor()
	{
		return new VFactor((long)this.skillSpeed, (long)GlobalLogic.VALUE_1000);
	}

	// Token: 0x06017337 RID: 95031 RVA: 0x00722CD4 File Offset: 0x007210D4
	public bool SkillNeedChagneSpeed()
	{
		return !this.isCharging || this.owner.skillPhase != this.chargeConfig.repeatPhase;
	}

	// Token: 0x06017338 RID: 95032 RVA: 0x00722D00 File Offset: 0x00721100
	public void SetSkillSpeed(int attackSpeed)
	{
		VRate a = this.skillSpeedFactor;
		this.skillSpeed = attackSpeed * (a + this.speedAddRate).factor;
		if (this.skillSpeed < GlobalLogic.VALUE_400)
		{
			this.skillSpeed = GlobalLogic.VALUE_400;
		}
	}

	// Token: 0x06017339 RID: 95033 RVA: 0x00722D68 File Offset: 0x00721168
	public void SetSkillSpeedWithSkillData()
	{
		VRate a = GlobalLogic.VALUE_1000;
		a += this.speedAddRate;
		this.skillSpeed = this.skillData.Speed * a.factor;
	}

	// Token: 0x0601733A RID: 95034 RVA: 0x00722DAF File Offset: 0x007211AF
	public SkillSpeedEffectType GetSkillSpeedEffectType()
	{
		return (SkillSpeedEffectType)this.skillData.SpeedEffectType;
	}

	// Token: 0x0601733B RID: 95035 RVA: 0x00722DBC File Offset: 0x007211BC
	public virtual int GetCurrentCD()
	{
		if (this.isCooldown && this.cdAtStartCoolDown > 0)
		{
			return this.cdAtStartCoolDown;
		}
		VRate vrate = this.cdReduceRate;
		if (this.owner != null)
		{
			vrate += this.owner.GetEntityData().GetCDReduce(this.skillMagicType);
		}
		int num = this.tableCD * (VRate.one - vrate).factor;
		num -= this.cdReduceValue;
		int num2 = (!BattleMain.IsModePvP(this.battleType)) ? TableManager.GetValueFromUnionCell(this.skillData.MinCD, this.level, true) : TableManager.GetValueFromUnionCell(this.skillData.MinCDPVP, this.level, true);
		if (num < num2)
		{
			num = num2;
		}
		return num;
	}

	// Token: 0x0601733C RID: 95036 RVA: 0x00722E98 File Offset: 0x00721298
	public int GetCurrentCharge()
	{
		int i = IntMath.Float2IntWithFixed(this.chargeConfig.chargeDuration, (long)GlobalLogic.VALUE_1000, 100L, MidpointRounding.ToEven);
		return IntMath.Max(1, i * (VRate.one - this.chargeReduceRate).factor);
	}

	// Token: 0x0601733D RID: 95037 RVA: 0x00722EE4 File Offset: 0x007212E4
	public Operation ParseOperation()
	{
		Operation result = default(Operation);
		if (this.skillData != null)
		{
			result.op = (Operation.OP)this.skillData.SkillOperation;
			result.target = (Operation.TARGET)this.skillData.SkillOpTarget;
			result.varName = this.skillData.SkillOpVar;
			result.value = TableManager.GetValueFromUnionCell(this.skillData.SkillOpValue, this.level, true);
			if (result.target == Operation.TARGET.SKILL)
			{
				int num = 0;
				result.skillIDs = new int[this.skillData.SkillOpSkillIDs.Count];
				for (int i = 0; i < this.skillData.SkillOpSkillIDs.Count; i++)
				{
					int num2 = this.skillData.SkillOpSkillIDs[i];
					if (num2 > 0)
					{
						result.skillIDs[num++] = num2;
					}
				}
			}
		}
		return result;
	}

	// Token: 0x0601733E RID: 95038 RVA: 0x00722FCC File Offset: 0x007213CC
	public void ExecuteOperation(Operation operation)
	{
		if (operation.op == Operation.OP.NONE)
		{
			return;
		}
		Type typeFromHandle = typeof(BeSkill);
		object obj = this;
		if (operation.target == Operation.TARGET.ACTOR)
		{
			typeFromHandle = typeof(BeActor);
			obj = this.owner;
		}
		if (operation.target == Operation.TARGET.SKILL)
		{
			for (int i = 0; i < operation.skillIDs.Length; i++)
			{
				BeSkill skill = this.owner.GetSkill(operation.skillIDs[i]);
				if (skill != null)
				{
					obj = skill;
					if (operation.varName == "level")
					{
						Utility.SetValueForProperty(typeFromHandle, obj, operation.varName, operation.value, operation.op == Operation.OP.ADD);
					}
					else
					{
						Utility.SetValue(typeFromHandle, obj, operation.varName, operation.value, operation.op == Operation.OP.ADD);
					}
				}
			}
		}
		else
		{
			Utility.SetValue(typeFromHandle, obj, operation.varName, operation.value, operation.op == Operation.OP.ADD);
		}
	}

	// Token: 0x0601733F RID: 95039 RVA: 0x007230D6 File Offset: 0x007214D6
	public int GetPvpAttackScale()
	{
		return this.skillData.AttackScalePVP;
	}

	// Token: 0x06017340 RID: 95040 RVA: 0x007230E4 File Offset: 0x007214E4
	public static List<int> GetEffectSkills(IList<UnionCell> value, int skillLevel)
	{
		List<int> list = new List<int>();
		for (int i = 0; i < value.Count; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(value[i], skillLevel, true);
			list.Add(valueFromUnionCell);
		}
		return list;
	}

	// Token: 0x06017341 RID: 95041 RVA: 0x00723128 File Offset: 0x00721528
	public void AddBuff(BeActor target, int effectID)
	{
		EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(effectID, string.Empty, string.Empty);
		if (tableItem != null)
		{
			int level = this.level;
			int valueFromUnionCell;
			if (BattleMain.IsChijiNeedReplaceHurtId(effectID, this.battleType))
			{
				ChijiEffectMapTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ChijiEffectMapTable>(effectID, string.Empty, string.Empty);
				valueFromUnionCell = TableManager.GetValueFromUnionCell(tableItem2.AttachBuffTime, level, true);
			}
			else
			{
				valueFromUnionCell = TableManager.GetValueFromUnionCell(tableItem.AttachBuffTime, level, true);
			}
			target.buffController.TryAddBuff(tableItem.BuffID, valueFromUnionCell, level);
		}
	}

	// Token: 0x06017342 RID: 95042 RVA: 0x007231B6 File Offset: 0x007215B6
	public BuffInfoData GetBuffInfo(int buffID)
	{
		if (this.buffEnhanceList.ContainsKey(buffID))
		{
			return this.buffEnhanceList[buffID];
		}
		return null;
	}

	// Token: 0x06017343 RID: 95043 RVA: 0x007231D7 File Offset: 0x007215D7
	protected bool CheckResetCamera()
	{
		return this.skillData != null && this.skillData.IsResetCamera;
	}

	// Token: 0x06017344 RID: 95044 RVA: 0x007231F9 File Offset: 0x007215F9
	public void ChangeWeapon()
	{
		this.UpdateCanUseSkillWithRightWeapon();
	}

	// Token: 0x06017345 RID: 95045 RVA: 0x00723204 File Offset: 0x00721604
	public void UpdateCanUseSkillWithRightWeapon()
	{
		if (this.owner == null || this.skillData == null)
		{
			return;
		}
		int needWeaponType = this.skillData.NeedWeaponType;
		if (needWeaponType == 0)
		{
			return;
		}
		this.canUseWithRightWeapon = (needWeaponType == this.owner.GetWeaponType());
	}

	// Token: 0x06017346 RID: 95046 RVA: 0x00723250 File Offset: 0x00721650
	public void DealLevelChange()
	{
		this.AddBuffs();
		this.RemoveMechanisms();
		this.AddMechanisms();
		if (this.skillData.SkillType == SkillTable.eSkillType.PASSIVE)
		{
			for (int i = 0; i < this.skillData.PreCondition.Count; i++)
			{
				SkillTable.ePreCondition ePreCondition = this.skillData.PreCondition[i];
				if (ePreCondition == SkillTable.ePreCondition.INIT)
				{
					this.DealEffectFrame();
				}
			}
		}
		this.ChangeSummonData();
	}

	// Token: 0x06017347 RID: 95047 RVA: 0x007232C6 File Offset: 0x007216C6
	public void DealWeaponChange()
	{
		this.UpdateCanUseSkillWithRightWeapon();
		this.OnWeaponChange();
		this.SetComboSourceSkillID();
	}

	// Token: 0x06017348 RID: 95048 RVA: 0x007232DA File Offset: 0x007216DA
	public void DealEquipChange()
	{
		this.OnWeaponChange();
	}

	// Token: 0x06017349 RID: 95049 RVA: 0x007232E2 File Offset: 0x007216E2
	protected void ChangeButtonEffect()
	{
		if (this.button != null)
		{
			this.button.AddEffect(ETCButton.eEffectType.onContinue, false);
		}
	}

	// Token: 0x0601734A RID: 95050 RVA: 0x00723302 File Offset: 0x00721702
	protected void ResetButtonEffect()
	{
		this.skillButtonState = BeSkill.SkillState.NORMAL;
		if (this.button != null)
		{
			this.button.RemoveEffect(ETCButton.eEffectType.onContinue, false);
		}
	}

	// Token: 0x0601734B RID: 95051 RVA: 0x0072332C File Offset: 0x0072172C
	protected void ChangeSummonData()
	{
		if (this.skillData == null || this.skillData.SummonRestrainEffectID <= 0)
		{
			return;
		}
		EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(this.skillData.SummonRestrainEffectID, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return;
		}
		this.summonEffectData.summonId = tableItem.SummonID;
		this.summonEffectData.summonNum = TableManager.GetValueFromUnionCell(tableItem.SummonNum, this.GetLevel(), true);
		this.summonEffectData.singleNumLimit = tableItem.SummonNumLimit;
		this.summonEffectData.groupNumLimit = TableManager.GetValueFromUnionCell(tableItem.SummonGroupNumLimit, this.GetLevel(), true);
		this.summonEffectData.summonGroup = tableItem.SummonGroup;
	}

	// Token: 0x0601734C RID: 95052 RVA: 0x007233EA File Offset: 0x007217EA
	protected void ResetMoveZAccExtra()
	{
		this.owner.SetMoveSpeedZAccExtra(0);
	}

	// Token: 0x0601734D RID: 95053 RVA: 0x00723400 File Offset: 0x00721800
	public void RemoveAllHandles()
	{
		if (this.handleA != null)
		{
			this.handleA.Remove();
			this.handleA = null;
		}
		if (this.handleB != null)
		{
			this.handleB.Remove();
			this.handleB = null;
		}
		if (this.handleC != null)
		{
			this.handleC.Remove();
			this.handleC = null;
		}
	}

	// Token: 0x0601734E RID: 95054 RVA: 0x00723464 File Offset: 0x00721864
	public virtual void OnInit()
	{
	}

	// Token: 0x0601734F RID: 95055 RVA: 0x00723466 File Offset: 0x00721866
	public virtual void OnDeInit()
	{
	}

	// Token: 0x06017350 RID: 95056 RVA: 0x00723468 File Offset: 0x00721868
	public virtual void OnPostInit()
	{
	}

	// Token: 0x06017351 RID: 95057 RVA: 0x0072346A File Offset: 0x0072186A
	public virtual void OnStart()
	{
	}

	// Token: 0x06017352 RID: 95058 RVA: 0x0072346C File Offset: 0x0072186C
	public virtual void OnUpdate(int iDeltime)
	{
	}

	// Token: 0x06017353 RID: 95059 RVA: 0x0072346E File Offset: 0x0072186E
	public virtual void OnUpdateJoystick(int degree)
	{
	}

	// Token: 0x06017354 RID: 95060 RVA: 0x00723470 File Offset: 0x00721870
	public virtual void OnReleaseJoystick()
	{
	}

	// Token: 0x06017355 RID: 95061 RVA: 0x00723472 File Offset: 0x00721872
	public virtual void OnFinish()
	{
	}

	// Token: 0x06017356 RID: 95062 RVA: 0x00723474 File Offset: 0x00721874
	public virtual void OnComboBreak()
	{
	}

	// Token: 0x06017357 RID: 95063 RVA: 0x00723476 File Offset: 0x00721876
	public virtual void OnCancel()
	{
	}

	// Token: 0x06017358 RID: 95064 RVA: 0x00723478 File Offset: 0x00721878
	public virtual void OnEnterPhase(int phase)
	{
	}

	// Token: 0x06017359 RID: 95065 RVA: 0x0072347A File Offset: 0x0072187A
	public virtual void OnClickAgain()
	{
	}

	// Token: 0x0601735A RID: 95066 RVA: 0x0072347C File Offset: 0x0072187C
	public virtual void OnClickAgainCancel()
	{
	}

	// Token: 0x0601735B RID: 95067 RVA: 0x0072347E File Offset: 0x0072187E
	public virtual void OnWeaponChange()
	{
	}

	// Token: 0x0601735C RID: 95068 RVA: 0x00723480 File Offset: 0x00721880
	public virtual void OnEnterNextPhase(int phase)
	{
	}

	// Token: 0x04010AB4 RID: 68276
	public int effectOffset;

	// Token: 0x04010AB5 RID: 68277
	public bool canRemoveJoystick = true;

	// Token: 0x04010AB6 RID: 68278
	public SkillJoystickMode joystickMode;

	// Token: 0x04010AB7 RID: 68279
	public BeSkill.InnerState innerState;

	// Token: 0x04010AB8 RID: 68280
	public VInt3 effectPos;

	// Token: 0x04010AB9 RID: 68281
	private Vector3 effectSpeed;

	// Token: 0x04010ABA RID: 68282
	private Vector3 effectRange;

	// Token: 0x04010ABB RID: 68283
	private GeEffectEx targetEffectWarning;

	// Token: 0x04010ABC RID: 68284
	private GeEffectEx targetEffectLine;

	// Token: 0x04010ABD RID: 68285
	private GeEffectEx targetEffectGround;

	// Token: 0x04010ABE RID: 68286
	private int recordVx;

	// Token: 0x04010ABF RID: 68287
	private int recordVy;

	// Token: 0x04010AC0 RID: 68288
	protected string startEnterNextFlag;

	// Token: 0x04010AC1 RID: 68289
	protected string endEnterNextFlag;

	// Token: 0x04010AC2 RID: 68290
	private bool enterFlag;

	// Token: 0x04010AC3 RID: 68291
	private BeEventHandle enterNextHandle;

	// Token: 0x04010AC4 RID: 68292
	protected string startJumpBackCnacelFlag;

	// Token: 0x04010AC5 RID: 68293
	protected string endJumpBackCnacelFlag;

	// Token: 0x04010AC6 RID: 68294
	protected BeSkill.SummonEffectData summonEffectData;

	// Token: 0x04010AC7 RID: 68295
	public int skillID;

	// Token: 0x04010AC8 RID: 68296
	public bool mIsIgnoreCD;

	// Token: 0x04010AC9 RID: 68297
	protected bool createdInBackMode;

	// Token: 0x04010ACA RID: 68298
	private ETCButton _button;

	// Token: 0x04010ACC RID: 68300
	public static FrameRandomImp randomForTown = new FrameRandomImp();

	// Token: 0x04010ACD RID: 68301
	public SkillTable skillData;

	// Token: 0x04010ACE RID: 68302
	public int skillCategory;

	// Token: 0x04010ACF RID: 68303
	public CrypticInt32 mpCost;

	// Token: 0x04010AD0 RID: 68304
	public bool isBuffSkill;

	// Token: 0x04010AD1 RID: 68305
	public CrypticInt32 hpCost;

	// Token: 0x04010AD2 RID: 68306
	public CrypticInt32 hpCostPercent;

	// Token: 0x04010AD3 RID: 68307
	public CrypticInt32 crystalCost;

	// Token: 0x04010AD4 RID: 68308
	public CrypticInt32 skillSpeed = GlobalLogic.VALUE_1000;

	// Token: 0x04010AD5 RID: 68309
	public bool canChangeWeapon;

	// Token: 0x04010AD6 RID: 68310
	public bool needSetIcon;

	// Token: 0x04010AD7 RID: 68311
	public string iconPath;

	// Token: 0x04010AD8 RID: 68312
	public int comboSkillSourceID;

	// Token: 0x04010AD9 RID: 68313
	public bool inTown;

	// Token: 0x04010ADA RID: 68314
	public CrypticInt32 skillSpeedFactor = GlobalLogic.VALUE_1000;

	// Token: 0x04010ADC RID: 68316
	public CrypticInt32 tableCD = 0;

	// Token: 0x04010ADD RID: 68317
	private int cdTimeAcc;

	// Token: 0x04010ADE RID: 68318
	private int useTimeAcc;

	// Token: 0x04010ADF RID: 68319
	private int cdAtStartCoolDown;

	// Token: 0x04010AE0 RID: 68320
	protected string skillSpeech;

	// Token: 0x04010AE1 RID: 68321
	protected int skillSpeechRand;

	// Token: 0x04010AE2 RID: 68322
	private int useCount;

	// Token: 0x04010AE3 RID: 68323
	private BeEventHandle eventHandler;

	// Token: 0x04010AE4 RID: 68324
	protected BeEventHandle hander1;

	// Token: 0x04010AE5 RID: 68325
	protected BeEventHandle hander2;

	// Token: 0x04010AE6 RID: 68326
	public BDStat skillState = new BDStat();

	// Token: 0x04010AE7 RID: 68327
	protected bool canceled;

	// Token: 0x04010AE8 RID: 68328
	public bool pressedForwardMove;

	// Token: 0x04010AE9 RID: 68329
	public bool pressedBackwardMove;

	// Token: 0x04010AEA RID: 68330
	public bool useInternalID;

	// Token: 0x04010AEB RID: 68331
	public ButtonState buttonState;

	// Token: 0x04010AEC RID: 68332
	public ChargeConfig chargeConfig;

	// Token: 0x04010AED RID: 68333
	public bool charged;

	// Token: 0x04010AEE RID: 68334
	public int pressDuration;

	// Token: 0x04010AEF RID: 68335
	public bool specialOperate;

	// Token: 0x04010AF0 RID: 68336
	public OperationConfig operationConfig;

	// Token: 0x04010AF1 RID: 68337
	public int specialChoice;

	// Token: 0x04010AF2 RID: 68338
	public BeActor joystickSelectActor;

	// Token: 0x04010AF3 RID: 68339
	protected IBeEventHandle handleA;

	// Token: 0x04010AF4 RID: 68340
	protected IBeEventHandle handleB;

	// Token: 0x04010AF5 RID: 68341
	protected IBeEventHandle handleC;

	// Token: 0x04010AF6 RID: 68342
	private SkillEvent[] skillEvents;

	// Token: 0x04010AF7 RID: 68343
	public bool cancelByCombo;

	// Token: 0x04010AF8 RID: 68344
	public bool isComboSkill;

	// Token: 0x04010AF9 RID: 68345
	public int comboSourceID;

	// Token: 0x04010AFA RID: 68346
	public CrypticInt32 _coolDown = 0;

	// Token: 0x04010AFB RID: 68347
	public SkillPressMode pressMode;

	// Token: 0x04010AFC RID: 68348
	public BeSkill.SkillState skillButtonState;

	// Token: 0x04010AFD RID: 68349
	protected Dictionary<int, int> jobInterruptSkills = new Dictionary<int, int>();

	// Token: 0x04010AFE RID: 68350
	protected List<int> interruptSkills = new List<int>();

	// Token: 0x04010AFF RID: 68351
	protected List<int> hitInterruptSkills = new List<int>();

	// Token: 0x04010B00 RID: 68352
	protected CrypticInt32 _level = 1;

	// Token: 0x04010B01 RID: 68353
	public bool isQTE;

	// Token: 0x04010B02 RID: 68354
	public bool isRunAttack;

	// Token: 0x04010B03 RID: 68355
	public bool canSlide;

	// Token: 0x04010B04 RID: 68356
	public bool canUse;

	// Token: 0x04010B05 RID: 68357
	private bool canUseWithRightWeapon = true;

	// Token: 0x04010B06 RID: 68358
	public bool walk;

	// Token: 0x04010B07 RID: 68359
	public VFactor walkSpeed = VFactor.zero;

	// Token: 0x04010B08 RID: 68360
	public bool charge;

	// Token: 0x04010B09 RID: 68361
	public bool hideSpellBar;

	// Token: 0x04010B0A RID: 68362
	protected bool chargeCD;

	// Token: 0x04010B0B RID: 68363
	protected int chargeCDTimeAcc;

	// Token: 0x04010B0C RID: 68364
	protected bool _hit;

	// Token: 0x04010B0D RID: 68365
	protected bool cdFlag;

	// Token: 0x04010B0E RID: 68366
	public bool isCharging;

	// Token: 0x04010B0F RID: 68367
	public bool joystickHasMove;

	// Token: 0x04010B10 RID: 68368
	protected string jumpBackImage = "UI/Image/Icon/Icon_Skill/General_icon-2.png:General_icon-2";

	// Token: 0x04010B11 RID: 68369
	protected string jumpBackCancelImage = "UI/Image/Icon/Icon_Skill/General_icon-15.png:General_icon-15";

	// Token: 0x04010B12 RID: 68370
	protected SkillMaigcType skillMagicType;

	// Token: 0x04010B13 RID: 68371
	protected int skillWalkMode;

	// Token: 0x04010B14 RID: 68372
	private int _CurSkillWalkMode;

	// Token: 0x04010B15 RID: 68373
	protected int curPhase;

	// Token: 0x04010B16 RID: 68374
	public int costMode;

	// Token: 0x04010B17 RID: 68375
	public VRate speedAddRate = 0;

	// Token: 0x04010B18 RID: 68376
	public VRate hitRateAdd = 0;

	// Token: 0x04010B19 RID: 68377
	public VRate criticalHitRateAdd = 0;

	// Token: 0x04010B1A RID: 68378
	public VRate attackAddRate = 0;

	// Token: 0x04010B1B RID: 68379
	public CrypticInt32 attackAdd = 0;

	// Token: 0x04010B1C RID: 68380
	public CrypticInt32 attackAddFix = 0;

	// Token: 0x04010B1D RID: 68381
	public VRate mpCostReduceRate = 0;

	// Token: 0x04010B1E RID: 68382
	public VRate cdReduceRate = 0;

	// Token: 0x04010B1F RID: 68383
	public CrypticInt32 cdReduceValue = 0;

	// Token: 0x04010B20 RID: 68384
	public VRate hardAddRate = 0;

	// Token: 0x04010B21 RID: 68385
	public VRate chargeReduceRate = 0;

	// Token: 0x04010B22 RID: 68386
	protected VFactor skillZdimFactor = VFactor.one;

	// Token: 0x04010B23 RID: 68387
	public bool canPressJumpBackCancel;

	// Token: 0x04010B24 RID: 68388
	public Dictionary<int, BuffInfoData> buffEnhanceList = new Dictionary<int, BuffInfoData>();

	// Token: 0x04010B25 RID: 68389
	private List<BeMechanism> skillMechanismList = new List<BeMechanism>();

	// Token: 0x04010B26 RID: 68390
	private bool _forceShowButtonImage;

	// Token: 0x04010B27 RID: 68391
	private int _skillStartPahse;

	// Token: 0x04010B28 RID: 68392
	private float startTime;

	// Token: 0x04010B29 RID: 68393
	private CrypticInt32 initTableCd = 0;

	// Token: 0x04010B2A RID: 68394
	private object[] interParams = new object[]
	{
		null,
		new int[2]
	};

	// Token: 0x020041BF RID: 16831
	public enum InnerState
	{
		// Token: 0x04010B63 RID: 68451
		NONE,
		// Token: 0x04010B64 RID: 68452
		CHOOSE_TARGET,
		// Token: 0x04010B65 RID: 68453
		LAUNCH
	}

	// Token: 0x020041C0 RID: 16832
	public enum SkillState
	{
		// Token: 0x04010B67 RID: 68455
		NORMAL,
		// Token: 0x04010B68 RID: 68456
		WAIT_FOR_NEXT_PRESS
	}

	// Token: 0x020041C1 RID: 16833
	protected struct SummonEffectData
	{
		// Token: 0x04010B69 RID: 68457
		public int summonId;

		// Token: 0x04010B6A RID: 68458
		public int summonNum;

		// Token: 0x04010B6B RID: 68459
		public int singleNumLimit;

		// Token: 0x04010B6C RID: 68460
		public int groupNumLimit;

		// Token: 0x04010B6D RID: 68461
		public int summonGroup;
	}
}
