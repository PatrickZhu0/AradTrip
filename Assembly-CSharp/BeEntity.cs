using System;
using System.Collections.Generic;
using GameClient;
using GamePool;
using ProtoTable;
using UnityEngine;

// Token: 0x02004172 RID: 16754
public class BeEntity
{
	// Token: 0x06016E4B RID: 93771 RVA: 0x006EB83C File Offset: 0x006E9C3C
	public BeEntity(int iResID, int iCamp, long iID)
	{
		this.m_vkCurWorldAttackBox = new BDDBoxData();
		for (int i = 0; i < 10; i++)
		{
			this.m_vkCurWorldAttackBox.vBox.Add(new DBoxImp());
		}
		this.m_vkCurWorldDefenseBox = new BDDBoxData();
		for (int j = 0; j < 10; j++)
		{
			this.m_vkCurWorldDefenseBox.vBox.Add(new DBoxImp());
		}
		this.stateController = new BeStateControl(this);
		this.actionManager.Init();
		this.InitReset(iResID, iCamp, (int)iID);
	}

	// Token: 0x17001F30 RID: 7984
	// (get) Token: 0x06016E4D RID: 93773 RVA: 0x006EBB70 File Offset: 0x006E9F70
	// (set) Token: 0x06016E4C RID: 93772 RVA: 0x006EBB67 File Offset: 0x006E9F67
	public VInt forceX
	{
		get
		{
			return this.m_fForceX;
		}
		set
		{
			this.m_fForceX = value;
		}
	}

	// Token: 0x17001F31 RID: 7985
	// (get) Token: 0x06016E4F RID: 93775 RVA: 0x006EBB81 File Offset: 0x006E9F81
	// (set) Token: 0x06016E4E RID: 93774 RVA: 0x006EBB78 File Offset: 0x006E9F78
	public VInt forceY
	{
		get
		{
			return this.m_fForceY;
		}
		set
		{
			this.m_fForceY = value;
		}
	}

	// Token: 0x17001F32 RID: 7986
	// (get) Token: 0x06016E51 RID: 93777 RVA: 0x006EBB92 File Offset: 0x006E9F92
	// (set) Token: 0x06016E50 RID: 93776 RVA: 0x006EBB89 File Offset: 0x006E9F89
	public VInt3 speedConfig
	{
		get
		{
			return this.m_kSpeedConfig;
		}
		set
		{
			this.m_kSpeedConfig = value;
		}
	}

	// Token: 0x17001F33 RID: 7987
	// (get) Token: 0x06016E53 RID: 93779 RVA: 0x006EBBA3 File Offset: 0x006E9FA3
	// (set) Token: 0x06016E52 RID: 93778 RVA: 0x006EBB9A File Offset: 0x006E9F9A
	public bool XuanWuManualAttack
	{
		get
		{
			return this._xuanWuManualAttack;
		}
		set
		{
			this._xuanWuManualAttack = value;
		}
	}

	// Token: 0x06016E54 RID: 93780 RVA: 0x006EBBAB File Offset: 0x006E9FAB
	public bool IsChaserSwitch(int type)
	{
		return (1 << type & (int)this.chaserSwitch) != 0;
	}

	// Token: 0x17001F34 RID: 7988
	// (get) Token: 0x06016E55 RID: 93781 RVA: 0x006EBBC0 File Offset: 0x006E9FC0
	public int lastTargetID
	{
		get
		{
			return this.mLastTargetId;
		}
	}

	// Token: 0x17001F35 RID: 7989
	// (get) Token: 0x06016E56 RID: 93782 RVA: 0x006EBBC8 File Offset: 0x006E9FC8
	public int lastOwnerTargetId
	{
		get
		{
			return this.mLastOwnerTargetId;
		}
	}

	// Token: 0x17001F36 RID: 7990
	// (get) Token: 0x06016E57 RID: 93783 RVA: 0x006EBBD0 File Offset: 0x006E9FD0
	public VInt3 lastTargetPos
	{
		get
		{
			if (this.currentBeScene != null)
			{
				BeEntity entityByPID = this.currentBeScene.GetEntityByPID(this.mLastTargetId);
				if (entityByPID != null)
				{
					return entityByPID.GetPosition();
				}
			}
			return this.GetPosition();
		}
	}

	// Token: 0x17001F37 RID: 7991
	// (get) Token: 0x06016E58 RID: 93784 RVA: 0x006EBC10 File Offset: 0x006EA010
	public VInt3 lastTargetOwnerPos
	{
		get
		{
			if (this.mLastOwnerTargetId == -1)
			{
				return this.GetPosition();
			}
			if (this.currentBeScene != null)
			{
				BeEntity entityByPID = this.currentBeScene.GetEntityByPID(this.mLastOwnerTargetId);
				if (entityByPID != null)
				{
					return entityByPID.GetPosition();
				}
			}
			return this.mLastTargetOwnerPos;
		}
	}

	// Token: 0x17001F38 RID: 7992
	// (get) Token: 0x06016E59 RID: 93785 RVA: 0x006EBC60 File Offset: 0x006EA060
	// (set) Token: 0x06016E5A RID: 93786 RVA: 0x006EBC68 File Offset: 0x006EA068
	public List<uint> PhaseDeleteAudioList
	{
		get
		{
			return this.m_PhaseDeleteAudioList;
		}
		set
		{
			this.m_PhaseDeleteAudioList = value;
		}
	}

	// Token: 0x17001F39 RID: 7993
	// (get) Token: 0x06016E5B RID: 93787 RVA: 0x006EBC71 File Offset: 0x006EA071
	// (set) Token: 0x06016E5C RID: 93788 RVA: 0x006EBC79 File Offset: 0x006EA079
	public List<uint> FinishDeleteAudioList
	{
		get
		{
			return this.m_FinishDeleteAudioList;
		}
		set
		{
			this.m_FinishDeleteAudioList = value;
		}
	}

	// Token: 0x17001F3A RID: 7994
	// (get) Token: 0x06016E5D RID: 93789 RVA: 0x006EBC82 File Offset: 0x006EA082
	public VInt lastAttackerId
	{
		get
		{
			return this.mLastAttackerId;
		}
	}

	// Token: 0x17001F3B RID: 7995
	// (get) Token: 0x06016E5E RID: 93790 RVA: 0x006EBC8A File Offset: 0x006EA08A
	public int lastAttackerOwnerId
	{
		get
		{
			return this.mLastOwnerAttackerId;
		}
	}

	// Token: 0x17001F3C RID: 7996
	// (get) Token: 0x06016E5F RID: 93791 RVA: 0x006EBC92 File Offset: 0x006EA092
	// (set) Token: 0x06016E60 RID: 93792 RVA: 0x006EBC9A File Offset: 0x006EA09A
	public VInt lastMoveXSpeed
	{
		get
		{
			return this.m_lastMoveXSpeed;
		}
		set
		{
			this.m_lastMoveXSpeed = value;
		}
	}

	// Token: 0x17001F3D RID: 7997
	// (get) Token: 0x06016E61 RID: 93793 RVA: 0x006EBCA3 File Offset: 0x006EA0A3
	// (set) Token: 0x06016E62 RID: 93794 RVA: 0x006EBCAB File Offset: 0x006EA0AB
	public VInt lastMoveYSpeed
	{
		get
		{
			return this.m_lastMoveYSpeed;
		}
		set
		{
			this.m_lastMoveYSpeed = value;
		}
	}

	// Token: 0x17001F3E RID: 7998
	// (get) Token: 0x06016E63 RID: 93795 RVA: 0x006EBCB4 File Offset: 0x006EA0B4
	// (set) Token: 0x06016E64 RID: 93796 RVA: 0x006EBCBC File Offset: 0x006EA0BC
	public VInt moveXSpeed
	{
		get
		{
			return this.m_fMoveXSpeed;
		}
		set
		{
			this.m_fMoveXSpeed = value;
		}
	}

	// Token: 0x17001F3F RID: 7999
	// (get) Token: 0x06016E65 RID: 93797 RVA: 0x006EBCC5 File Offset: 0x006EA0C5
	// (set) Token: 0x06016E66 RID: 93798 RVA: 0x006EBCCD File Offset: 0x006EA0CD
	public VInt moveYSpeed
	{
		get
		{
			return this.m_fMoveYSpeed;
		}
		set
		{
			this.m_fMoveYSpeed = value;
		}
	}

	// Token: 0x17001F40 RID: 8000
	// (get) Token: 0x06016E67 RID: 93799 RVA: 0x006EBCD6 File Offset: 0x006EA0D6
	// (set) Token: 0x06016E68 RID: 93800 RVA: 0x006EBCE0 File Offset: 0x006EA0E0
	public VInt moveZSpeed
	{
		get
		{
			return this.m_fMoveZSpeed;
		}
		set
		{
			if (!this.inUpdatePosition && this.m_fMoveZSpeed != 0 && value == 0 && this is BeActor)
			{
				this.resetMoveDirty = true;
			}
			this.m_fMoveZSpeed = value;
		}
	}

	// Token: 0x17001F41 RID: 8001
	// (get) Token: 0x06016E69 RID: 93801 RVA: 0x006EBD2E File Offset: 0x006EA12E
	// (set) Token: 0x06016E6A RID: 93802 RVA: 0x006EBD36 File Offset: 0x006EA136
	public VInt moveXAcc
	{
		get
		{
			return this.m_fMoveXAcc;
		}
		set
		{
			this.m_fMoveXAcc = value;
		}
	}

	// Token: 0x17001F42 RID: 8002
	// (get) Token: 0x06016E6B RID: 93803 RVA: 0x006EBD3F File Offset: 0x006EA13F
	// (set) Token: 0x06016E6C RID: 93804 RVA: 0x006EBD47 File Offset: 0x006EA147
	public VInt moveYAcc
	{
		get
		{
			return this.m_fMoveYAcc;
		}
		set
		{
			this.m_fMoveYAcc = value;
		}
	}

	// Token: 0x17001F43 RID: 8003
	// (get) Token: 0x06016E6D RID: 93805 RVA: 0x006EBD50 File Offset: 0x006EA150
	// (set) Token: 0x06016E6E RID: 93806 RVA: 0x006EBD63 File Offset: 0x006EA163
	public VInt moveZAcc
	{
		get
		{
			return this.m_fMoveZAcc + this.m_fMoveZAccExtra;
		}
		set
		{
			this.m_fMoveZAcc = value;
		}
	}

	// Token: 0x17001F44 RID: 8004
	// (get) Token: 0x06016E6F RID: 93807 RVA: 0x006EBD6C File Offset: 0x006EA16C
	// (set) Token: 0x06016E70 RID: 93808 RVA: 0x006EBD74 File Offset: 0x006EA174
	public VInt moveZAccExtra
	{
		get
		{
			return this.m_fMoveZAccExtra;
		}
		set
		{
			this.m_fMoveZAccExtra = value;
		}
	}

	// Token: 0x17001F45 RID: 8005
	// (get) Token: 0x06016E71 RID: 93809 RVA: 0x006EBD7D File Offset: 0x006EA17D
	// (set) Token: 0x06016E72 RID: 93810 RVA: 0x006EBD85 File Offset: 0x006EA185
	protected bool m_bPositionDirty
	{
		get
		{
			return this.mPositionDirty;
		}
		set
		{
			this.mPositionDirty = value;
			if (value)
			{
				this.m_bGraphicPositionDirty = true;
			}
		}
	}

	// Token: 0x06016E73 RID: 93811 RVA: 0x006EBD9B File Offset: 0x006EA19B
	public void LockMoveCmd(bool bLock)
	{
		if (this.m_bLockMoveCmd != bLock)
		{
			this.m_bCmdDirty = true;
		}
		this.m_bLockMoveCmd = bLock;
	}

	// Token: 0x06016E74 RID: 93812 RVA: 0x006EBDB7 File Offset: 0x006EA1B7
	public void SetIsDead(bool flag)
	{
		this.isDead = flag;
	}

	// Token: 0x06016E75 RID: 93813 RVA: 0x006EBDC0 File Offset: 0x006EA1C0
	public int GetAllStatTag()
	{
		return this.m_kStateTag.GetAllFlag();
	}

	// Token: 0x17001F46 RID: 8006
	// (get) Token: 0x06016E76 RID: 93814 RVA: 0x006EBDCD File Offset: 0x006EA1CD
	public BDDBoxData CurWorldDefenseBox
	{
		get
		{
			return this.m_vkCurWorldDefenseBox;
		}
	}

	// Token: 0x17001F47 RID: 8007
	// (get) Token: 0x06016E77 RID: 93815 RVA: 0x006EBDD5 File Offset: 0x006EA1D5
	public BeEventManager EventManager
	{
		get
		{
			return this.m_EventManager;
		}
	}

	// Token: 0x17001F48 RID: 8008
	// (get) Token: 0x06016E79 RID: 93817 RVA: 0x006EBDF7 File Offset: 0x006EA1F7
	// (set) Token: 0x06016E78 RID: 93816 RVA: 0x006EBDDD File Offset: 0x006EA1DD
	public bool hasAI
	{
		get
		{
			return this._hasAI > 0;
		}
		set
		{
			this._hasAI = ((!value) ? 0 : 1);
		}
	}

	// Token: 0x17001F49 RID: 8009
	// (get) Token: 0x06016E7B RID: 93819 RVA: 0x006EBE2B File Offset: 0x006EA22B
	// (set) Token: 0x06016E7A RID: 93818 RVA: 0x006EBE11 File Offset: 0x006EA211
	public bool pauseAI
	{
		get
		{
			return this._pauseAI > 0;
		}
		set
		{
			this._pauseAI = ((!value) ? 0 : 1);
		}
	}

	// Token: 0x06016E7C RID: 93820 RVA: 0x006EBE48 File Offset: 0x006EA248
	public static bool CheckIntersectEx(BDDBoxData rkWorldAttackData, int iAttackSize, BDDBoxData rkWorldDefenseData, int iDefenseSize, ref DBox rkBoxOut)
	{
		for (int i = 0; i < iAttackSize; i++)
		{
			for (int j = 0; j < iDefenseSize; j++)
			{
				DBox vWorldBox = rkWorldAttackData.vBox[i].vWorldBox;
				DBox vWorldBox2 = rkWorldDefenseData.vBox[j].vWorldBox;
				if (vWorldBox.intersects(vWorldBox2))
				{
					vWorldBox.getIntersects(vWorldBox2, ref rkBoxOut);
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06016E7D RID: 93821 RVA: 0x006EBEB8 File Offset: 0x006EA2B8
	public static bool CheckIntersect3Ex(BDDBoxData rkWorldAttackData, int iAttackSize, BDDBoxData rkWorldDefenseData, int iDefenseSize, ref DBox3 rkBoxOut)
	{
		for (int i = 0; i < iAttackSize; i++)
		{
			for (int j = 0; j < iDefenseSize; j++)
			{
				DBox3 vWorld3Box = rkWorldAttackData.vBox[i].vWorld3Box;
				DBox3 vWorld3Box2 = rkWorldDefenseData.vBox[j].vWorld3Box;
				if (vWorld3Box.intersects(vWorld3Box2))
				{
					vWorld3Box.getIntersects(vWorld3Box2, ref rkBoxOut);
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06016E7E RID: 93822 RVA: 0x006EBF27 File Offset: 0x006EA327
	public void Pause(int time, bool hitEffectPause = true)
	{
		this.pause = true;
		this.pausetime = time;
		if (this.m_pkGeActor != null)
		{
			this.m_pkGeActor.Pause(63, hitEffectPause);
		}
		if (this.m_kShockEffect != null)
		{
			this.m_kShockEffect.Stop();
		}
	}

	// Token: 0x06016E7F RID: 93823 RVA: 0x006EBF66 File Offset: 0x006EA366
	public void StopShock()
	{
		if (this.m_kShockEffect != null)
		{
			this.m_kShockEffect.Stop();
		}
	}

	// Token: 0x06016E80 RID: 93824 RVA: 0x006EBF7E File Offset: 0x006EA37E
	public void Resume()
	{
		if (this.pause)
		{
			this.pause = false;
			if (this.m_pkGeActor != null)
			{
				this.m_pkGeActor.Resume(63);
			}
		}
	}

	// Token: 0x06016E81 RID: 93825 RVA: 0x006EBFAA File Offset: 0x006EA3AA
	public bool IsPause()
	{
		return this.pause;
	}

	// Token: 0x06016E82 RID: 93826 RVA: 0x006EBFB4 File Offset: 0x006EA3B4
	public bool _updatePause(int iDeltatime)
	{
		if (this.pause)
		{
			this.pausetime -= iDeltatime;
			if (this.pausetime <= 0)
			{
				this.pause = false;
				if (this.m_pkGeActor != null)
				{
					this.m_pkGeActor.Resume(63);
					return false;
				}
			}
			return true;
		}
		return false;
	}

	// Token: 0x06016E83 RID: 93827 RVA: 0x006EC00A File Offset: 0x006EA40A
	public string GetActionNameBySkillID(int sID)
	{
		return this.GetSkillDataNameByID(sID);
	}

	// Token: 0x06016E84 RID: 93828 RVA: 0x006EC014 File Offset: 0x006EA414
	public BDEntityActionInfo GetActionInfoBySkillID(int skillID)
	{
		BDEntityActionInfo result = null;
		string actionNameBySkillID = this.GetActionNameBySkillID(skillID);
		if (this.m_cpkEntityInfo.HasAction(actionNameBySkillID))
		{
			result = this.m_cpkEntityInfo._vkActionsMap[actionNameBySkillID];
		}
		return result;
	}

	// Token: 0x06016E85 RID: 93829 RVA: 0x006EC04F File Offset: 0x006EA44F
	public string GetSkillDataNameByID(int skillID)
	{
		if (this.m_cpkEntityInfo.skillData.ContainsKey(skillID))
		{
			return this.m_cpkEntityInfo.skillData[skillID];
		}
		return null;
	}

	// Token: 0x06016E86 RID: 93830 RVA: 0x006EC07C File Offset: 0x006EA47C
	public virtual void InitReset(int iResID, int iCamp, int iID)
	{
		this.m_iCamp = iCamp;
		this.m_iID = iID;
		this.m_iResID = iResID;
		this.m_bFaceLeft = false;
		this.m_iCurrentLogicFrame = -1;
		this.moveZAcc = (VInt)Global.Settings.gravity;
		this.m_fScale = VInt.one;
		this.m_fZdimScaleFactor = VFactor.one;
		this.moveXAcc = VInt.zero;
		this.moveYAcc = VInt.zero;
		this.m_bCanBeAttacked = true;
		this.m_iEntityLifeState = 0;
		this.runSpeed = new VInt3(Global.Settings.runSpeed);
		this.walkSpeed = new VInt3(Global.Settings.walkSpeed);
		this.speedConfig = this.walkSpeed;
		this.m_iRemoveTime = 0;
		this.m_kPosition = VInt3.zero;
		this.m_kBlockPosition = VInt3.zero;
		this.forceX = VInt.zero;
		this.forceY = VInt.zero;
		this.walkSpeedFactor = 1f;
		this.runSpeedFactor = 1f;
		this.hasDoublePress = false;
		this.chaserSwitch = 0;
		this.hasRunAttackConfig = false;
		this.extraSpeed = VInt3.zero;
		this.m_fMoveXSpeedRate = VFactor.one;
		this.m_fMoveYSpeedRate = VFactor.one;
		this.onlyMoveFacedDir = false;
		this.onlyMoveFaceDirOpposite = false;
		this.skillFreeTurnFace = false;
		this.mPositionDirty = false;
		this.m_bGraphicPositionDirty = true;
		this.m_bHaveMoveCmd = false;
		this.m_bCmdDirty = false;
		this.m_bLockMoveCmd = false;
		this.m_Degree = 0;
		this.stateStart = 0;
		this.sgStarted = false;
		this.m_vHurtEntity.Clear();
		this.m_kStateTag.Clear();
		this.isDead = false;
		this.m_fCurrentLogicFrame = 0f;
		this.hasAI = false;
		this.pauseAI = false;
		this.dontSetFace = false;
		this.m_bCanBeAttacked = true;
		this.pause = false;
		this.pausetime = 0;
		this.m_cpkCurEntityActionInfo = null;
		this.actionLooped = false;
		this.m_cpkCurEntityActionFrameData = null;
		this.m_iPreSkillID = 0;
		this.m_iCurSkillID = 0;
		this.m_bSkillDirty = false;
		this.hurtCount = 0;
		this.attribute = null;
		this.stateController.Reset();
		this.hasHP = true;
		this.timeAcc = 0;
		this.delayCaller.Clear();
		this.restrainPosition = false;
		this.pkRestrainPosition = false;
		this.reachAreaLimited = false;
		this.moveSpeedFactor = VFactor.one;
		this.posBeforeGrab = VInt3.zero;
		this.actionQueue.Clear();
		this.actionAcc = 0;
		this.actionTimeout = 0;
		this.queuedActionSpeed = 1f;
		this.absorbTargetPos = VInt3.zero;
		this.isAbsorb = false;
		this.absorbSpeed = VInt.zero;
		this.repeatUnit = null;
		this.skillAttackScale = VFactor.one;
		this.beHitEffect = "-";
		this.hitEffect = "-";
		this.isFloating = false;
		this.floatingHeight = 0;
		this.owner = this;
		this.boxRadius = VInt.zero;
		this.showDamageNumber = true;
		this.savedPosition = VInt3.zero;
		this.playedExpDead = false;
		this.recoverTimeAcc = 0;
		this.recoverInterval = 1000;
		this.deadType = DeadType.NORMAL;
		this.needDead = false;
		this.dontDelete = false;
		this.needHitShader = false;
		this.loadCommonSkill = false;
		this.doublePressRun = false;
		this.doublePressRunLeft = false;
		this.changeToNoBlock = false;
		this.defaultHitSFXID = 0;
		this.defaultHitSFXData = null;
		this.resetMoveDirty = false;
		this.currentHitEffectNum = 0;
		this.delayCallUnitList.Clear();
		this.delayCallUnitHurtIdList.Clear();
		this.ClearMoveSpeed(7);
		if (this.m_pkStateGraph != null)
		{
			this.m_pkStateGraph.Reset();
		}
		this._xuanWuManualAttack = false;
	}

	// Token: 0x06016E87 RID: 93831 RVA: 0x006EC41D File Offset: 0x006EA81D
	public void SetBeScene(BeScene beScene)
	{
		this.currentBeScene = beScene;
	}

	// Token: 0x17001F4A RID: 8010
	// (get) Token: 0x06016E88 RID: 93832 RVA: 0x006EC426 File Offset: 0x006EA826
	public BeScene CurrentBeScene
	{
		get
		{
			return this.currentBeScene;
		}
	}

	// Token: 0x17001F4B RID: 8011
	// (get) Token: 0x06016E89 RID: 93833 RVA: 0x006EC430 File Offset: 0x006EA830
	public BaseBattle CurrentBeBattle
	{
		get
		{
			BaseBattle result = null;
			if (this.currentBeScene != null)
			{
				result = this.currentBeScene.mBattle;
			}
			return result;
		}
	}

	// Token: 0x17001F4C RID: 8012
	// (get) Token: 0x06016E8A RID: 93834 RVA: 0x006EC457 File Offset: 0x006EA857
	public FrameRandomImp FrameRandom
	{
		get
		{
			if (this.CurrentBeBattle == null)
			{
				return BeSkill.randomForTown;
			}
			if (this.CurrentBeBattle == null)
			{
				Logger.LogError("CurrentBeBattle is null");
			}
			return this.CurrentBeBattle.FrameRandom;
		}
	}

	// Token: 0x17001F4D RID: 8013
	// (get) Token: 0x06016E8B RID: 93835 RVA: 0x006EC48C File Offset: 0x006EA88C
	public BattleType battleType
	{
		get
		{
			BattleType result = BattleType.Dungeon;
			if (this.owner.CurrentBeBattle != null)
			{
				result = this.owner.CurrentBeBattle.GetBattleType();
			}
			return result;
		}
	}

	// Token: 0x06016E8C RID: 93836 RVA: 0x006EC4C0 File Offset: 0x006EA8C0
	~BeEntity()
	{
	}

	// Token: 0x06016E8D RID: 93837 RVA: 0x006EC4EC File Offset: 0x006EA8EC
	public void Create(BeStatesGraph pkStateGraph, int iStartState, bool isSceneObj = false, bool loadCommonSkill = false, bool useCube = false)
	{
		if (this.GetLifeState() != 0)
		{
			return;
		}
		this.m_iEntityLifeState = 2;
		this.isDead = false;
		this._LoadBlockData();
		if (this is BeProjectile && this.m_pkGeActor != null)
		{
			this.m_pkGeActor.RecreateForProjectile(useCube);
		}
		else
		{
			this.m_pkGeActor = this.CurrentBeScene.currentGeScene.CreateActor(this.m_iResID, 0, 0, isSceneObj, true, true, useCube);
			this.m_pkGeActor.SuitAvatar(true, false, 0);
		}
		if (this.m_pkGeActor == null)
		{
			Logger.LogErrorFormat("资源ID {0} 角色创建失败", new object[]
			{
				this.m_iResID
			});
		}
		this.loadCommonSkill = loadCommonSkill;
		if (this.attachmentproxy == null)
		{
			this.attachmentproxy = new BeAttachFramesProxy
			{
				actor = this.m_pkGeActor
			};
		}
		this.m_pkGeActor.entity = this;
		if (this.m_pkGeActor != null)
		{
			this.m_pkGeActor.AddAnimPackage("AnimPack02");
			this.m_kShockEffect.Init(this.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Child), 1);
			if (this is BeObject)
			{
				this.currentBeScene.currentGeScene.AddToColorDescList(this.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Actor));
			}
		}
		if (pkStateGraph != null)
		{
			this.SetStateGraph(pkStateGraph, iStartState);
		}
		if (!this._onCreate() && this.m_cpkEntityInfo._vkActionsMap.Count <= 0)
		{
			this.m_pkGeActor.LoadSkillConfig(this.m_cpkEntityInfo, loadCommonSkill, null, 0);
		}
		this.TriggerEvent(BeEventType.onBirth, null);
	}

	// Token: 0x06016E8E RID: 93838 RVA: 0x006EC67B File Offset: 0x006EAA7B
	public bool IsRemoved()
	{
		return this.m_iEntityLifeState == 5;
	}

	// Token: 0x06016E8F RID: 93839 RVA: 0x006EC686 File Offset: 0x006EAA86
	public bool IsDeadOrRemoved()
	{
		return this.IsRemoved() || this.IsDead();
	}

	// Token: 0x06016E90 RID: 93840 RVA: 0x006EC69C File Offset: 0x006EAA9C
	public virtual void OnRemove(bool force = false)
	{
		this.TriggerEvent(BeEventType.onRemove, null);
		this.SetLifeState(EntityLifeState.ELS_REMOVED);
		if (this.m_pkGeActor != null && (force || !this.dontDelete))
		{
			if (this.aiManager != null)
			{
				this.aiManager.Remove();
				this.aiManager = null;
			}
			if (this is BeProjectile && !force)
			{
				this.CurrentBeScene.currentGeScene.RecycleActor(this.m_pkGeActor);
			}
			else
			{
				this.CurrentBeScene.currentGeScene.DestroyActor(this.m_pkGeActor);
				this.m_pkGeActor = null;
			}
			if (this.eventProcessor != null)
			{
				this.eventProcessor.ClearAll();
			}
			if (this.delayCaller != null)
			{
				this.delayCaller.Clear();
			}
			this.ClearEventAllNew();
		}
		if (this.actionManager != null)
		{
			this.actionManager.Deinit();
		}
	}

	// Token: 0x06016E91 RID: 93841 RVA: 0x006EC783 File Offset: 0x006EAB83
	public virtual bool UpdateGraphic(int iDeltaTime)
	{
		this._updateGraphic(iDeltaTime, 0);
		return true;
	}

	// Token: 0x06016E92 RID: 93842 RVA: 0x006EC790 File Offset: 0x006EAB90
	public void _updateGraphic(int iDeltaTime, int accTime = 0)
	{
		this.m_kShockEffect.Update((float)iDeltaTime / (float)GlobalLogic.VALUE_1000);
		this._updateGraphicActor(false);
		if (this.m_pkGeActor != null)
		{
			this.m_pkGeActor.Update(iDeltaTime, 46, (float)this.GetPosition().z, accTime);
		}
	}

	// Token: 0x06016E93 RID: 93843 RVA: 0x006EC7E4 File Offset: 0x006EABE4
	public virtual bool Update(int iDeltaTime)
	{
		if (this.m_EventManager != null)
		{
			this.m_EventManager.Update();
		}
		if (this.GetLifeState() != 2)
		{
			return false;
		}
		this.timeAcc += iDeltaTime;
		if (this.delayCaller != null)
		{
			this.delayCaller.Update(iDeltaTime);
		}
		if (this.actionManager != null)
		{
			this.actionManager.Update(iDeltaTime);
		}
		if (this._updatePause(iDeltaTime))
		{
			return false;
		}
		this._updateMoveCmd();
		this._updatePosition(iDeltaTime);
		if (this.m_pkStateGraph != null)
		{
			if (!this.sgStarted)
			{
				this.sgStarted = true;
				this.m_pkStateGraph.Start(this.stateStart);
			}
			this.m_pkStateGraph.UpdateStates(iDeltaTime);
		}
		if (this.m_cpkCurEntityActionInfo != null)
		{
			this.UpdateFrame();
			this._updateWorldDBox(iDeltaTime);
			this.attachmentproxy.Update(this.m_fCurrentLogicFrame);
		}
		this._updateAction(iDeltaTime);
		return true;
	}

	// Token: 0x06016E94 RID: 93844 RVA: 0x006EC8D8 File Offset: 0x006EACD8
	public void UpdateFrame()
	{
		this._updateFrame(false);
	}

	// Token: 0x06016E95 RID: 93845 RVA: 0x006EC8E1 File Offset: 0x006EACE1
	public void PostUpate()
	{
		if (this.GetLifeState() != 2)
		{
			return;
		}
		if (this.pause)
		{
			return;
		}
		this._calcAttack();
	}

	// Token: 0x06016E96 RID: 93846 RVA: 0x006EC902 File Offset: 0x006EAD02
	public void Reset()
	{
		this.m_pkStateGraph.SwitchStates(new BeStateData(0, 0));
		this.ResetMoveCmd();
		this.ClearMoveSpeed(7);
		this.m_vHurtEntity.Clear();
		this._onReset();
	}

	// Token: 0x06016E97 RID: 93847 RVA: 0x006EC938 File Offset: 0x006EAD38
	public virtual void Reborn()
	{
		if (this.owner.CurrentBeBattle != null && !this.owner.CurrentBeBattle.HasFlag(BattleFlagType.DeadTypeFlag))
		{
			this.deadType = DeadType.NORMAL;
		}
		if (this.m_pkGeActor != null)
		{
			this.m_pkGeActor.RemoveSurface(uint.MaxValue);
		}
		this.m_iEntityLifeState = 2;
		this.isDead = false;
		BeEntityData entityData = this.GetEntityData();
		if (entityData != null)
		{
			entityData.PostInit(null);
		}
		if (this.stateController != null)
		{
			this.stateController.ResetMoveAbility();
		}
		if (this.m_pkGeActor != null)
		{
			this.m_pkGeActor.ResetHPBar();
		}
		DAssetObject effectRes = new DAssetObject
		{
			m_AssetPath = "Effects/Common/Sfx/level_up/Prefab/Eff_fuhuo_guo"
		};
		if (this.m_pkGeActor != null)
		{
			Vec3 initPos = new Vec3(this.m_pkGeActor.GetPosition());
			this.m_pkGeActor.CreateEffect(effectRes, this.DUMMY_EFF_FRAME, 0f, initPos, 1f, 1f, false, true, false);
		}
		this.Reset();
		MonoSingleton<AudioManager>.instance.PlaySound(8);
	}

	// Token: 0x06016E98 RID: 93848 RVA: 0x006ECA48 File Offset: 0x006EAE48
	public void ResetMoveCmd()
	{
		this.m_bCmdDirty = true;
		for (int i = 0; i < 5; i++)
		{
			this.m_vkMoveCmd[i] = false;
		}
		this.moveXSpeed = 0;
		this.moveYSpeed = 0;
		this.moveZSpeed = 0;
	}

	// Token: 0x06016E99 RID: 93849 RVA: 0x006ECA9C File Offset: 0x006EAE9C
	public void ModifyMoveCmd(int iMoveCmd, bool bUse)
	{
		if (iMoveCmd >= 0 && iMoveCmd < 5 && this.m_vkMoveCmd[iMoveCmd] != bUse)
		{
			this.m_bCmdDirty = true;
			this.m_vkMoveCmd[iMoveCmd] = bUse;
			if (bUse)
			{
				this.m_pkStateGraph.FireEvents2CurrentStates(6);
			}
			else
			{
				bool flag = true;
				for (int i = 0; i < 4; i++)
				{
					if (this.m_vkMoveCmd[i])
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					this.m_pkStateGraph.FireEvents2CurrentStates(7);
				}
			}
		}
	}

	// Token: 0x06016E9A RID: 93850 RVA: 0x006ECB28 File Offset: 0x006EAF28
	public void ModifyMoveDirection(bool bSet, short nDegree = 0)
	{
		if (this.bLockMove)
		{
			return;
		}
		if (this.bLockMoveDegree && bSet)
		{
			if (nDegree > 6 && nDegree < 18)
			{
				nDegree = 12;
			}
			else
			{
				nDegree = 0;
			}
		}
		this.TriggerEvent(BeEventType.OnChangeMoveDir, new object[]
		{
			nDegree,
			bSet
		});
		if (bSet && !this.m_vkMoveCmd[4])
		{
			this.m_pkStateGraph.FireEvents2CurrentStates(6);
			this.TriggerEvent(BeEventType.onMoveJoystick, null);
		}
		else if (!bSet && this.m_vkMoveCmd[4])
		{
			this.m_pkStateGraph.FireEvents2CurrentStates(7);
			this.TriggerEvent(BeEventType.onStopMoveJoystick, null);
		}
		this.m_vkMoveCmd[4] = bSet;
		this.m_Degree = nDegree;
		this.m_bCmdDirty = true;
		this.OnJoystickMove((int)nDegree);
	}

	// Token: 0x06016E9B RID: 93851 RVA: 0x006ECC00 File Offset: 0x006EB000
	public virtual void OnJoystickMove(int degree)
	{
	}

	// Token: 0x06016E9C RID: 93852 RVA: 0x006ECC02 File Offset: 0x006EB002
	public bool IsInMoveDirection()
	{
		return this.m_vkMoveCmd[4];
	}

	// Token: 0x06016E9D RID: 93853 RVA: 0x006ECC0C File Offset: 0x006EB00C
	public short MoveDirectionDegree()
	{
		return this.m_Degree;
	}

	// Token: 0x06016E9E RID: 93854 RVA: 0x006ECC14 File Offset: 0x006EB014
	public void GetMoveSpeedFromDirection(out VInt x, out VInt y)
	{
		VFactor vfactor = VFactor.pi / 180L * (long)(this.m_Degree * 15);
		x = this.speedConfig.x * IntMath.cos(vfactor.nom, vfactor.den);
		y = this.speedConfig.y * IntMath.sin(vfactor.nom, vfactor.den);
	}

	// Token: 0x06016E9F RID: 93855 RVA: 0x006ECCA4 File Offset: 0x006EB0A4
	public void ClearMoveSpeed(int iClearMod = 7)
	{
		if ((iClearMod & 1) != 0)
		{
			this.moveXSpeed = 0;
		}
		if ((iClearMod & 2) != 0)
		{
			this.moveYSpeed = 0;
		}
		if ((iClearMod & 4) != 0)
		{
			this.moveZSpeed = 0;
		}
		this.moveXAcc = 0;
		this.moveYAcc = 0;
	}

	// Token: 0x06016EA0 RID: 93856 RVA: 0x006ECD05 File Offset: 0x006EB105
	public bool IsHaveMoveCmd()
	{
		return this.m_bHaveMoveCmd;
	}

	// Token: 0x06016EA1 RID: 93857 RVA: 0x006ECD0D File Offset: 0x006EB10D
	public void ResetDamageData()
	{
		this.m_vHurtEntity.Clear();
	}

	// Token: 0x06016EA2 RID: 93858 RVA: 0x006ECD1A File Offset: 0x006EB11A
	public void SetMoveSpeedX(VInt fValue)
	{
		this.moveXSpeed = fValue;
	}

	// Token: 0x06016EA3 RID: 93859 RVA: 0x006ECD23 File Offset: 0x006EB123
	public void SetMoveSpeedXRate(VFactor fValue)
	{
		this.m_fMoveXSpeedRate = fValue;
	}

	// Token: 0x06016EA4 RID: 93860 RVA: 0x006ECD2C File Offset: 0x006EB12C
	public void SetMoveSpeedYRate(VFactor fValue)
	{
		this.m_fMoveYSpeedRate = fValue;
	}

	// Token: 0x06016EA5 RID: 93861 RVA: 0x006ECD35 File Offset: 0x006EB135
	public void SetMoveSpeedXLocal(VInt fValue)
	{
		this.moveXSpeed = (int)((long)fValue) * ((!this.GetFace()) ? 1 : -1);
	}

	// Token: 0x06016EA6 RID: 93862 RVA: 0x006ECD5C File Offset: 0x006EB15C
	public void SetMoveSpeedY(VInt fValue)
	{
		this.moveYSpeed = fValue;
	}

	// Token: 0x06016EA7 RID: 93863 RVA: 0x006ECD65 File Offset: 0x006EB165
	public void SetMoveSpeedZ(VInt fValue)
	{
		this.moveZSpeed = fValue;
	}

	// Token: 0x06016EA8 RID: 93864 RVA: 0x006ECD6E File Offset: 0x006EB16E
	public void SetMoveSpeedZAcc(VInt fValue)
	{
		this.moveZAcc = fValue;
	}

	// Token: 0x06016EA9 RID: 93865 RVA: 0x006ECD77 File Offset: 0x006EB177
	public void SetMoveSpeedZAccExtra(VInt fValue)
	{
		this.moveZAccExtra = fValue;
	}

	// Token: 0x06016EAA RID: 93866 RVA: 0x006ECD80 File Offset: 0x006EB180
	public void SetMoveSpeedYAcc(VInt fValue)
	{
		this.moveYAcc = fValue;
	}

	// Token: 0x06016EAB RID: 93867 RVA: 0x006ECD89 File Offset: 0x006EB189
	public void SetMoveSpeedXAcc(VInt fValue)
	{
		this.moveXAcc = fValue;
	}

	// Token: 0x06016EAC RID: 93868 RVA: 0x006ECD92 File Offset: 0x006EB192
	public void sgPushState(BeStateData rkData)
	{
		if (this.m_pkStateGraph != null)
		{
			this.m_pkStateGraph.PushState(ref rkData);
		}
	}

	// Token: 0x06016EAD RID: 93869 RVA: 0x006ECDAC File Offset: 0x006EB1AC
	public void sgLocomoteState()
	{
		if (this.m_pkStateGraph != null)
		{
			this.m_pkStateGraph.LocomoteState();
		}
	}

	// Token: 0x06016EAE RID: 93870 RVA: 0x006ECDC4 File Offset: 0x006EB1C4
	public void sgForceSwitchState(BeStateData rkData)
	{
		if (this.m_pkStateGraph != null)
		{
			this.m_pkStateGraph.ClearStateStack();
			this.m_pkStateGraph.Locomote(rkData, true);
		}
	}

	// Token: 0x06016EAF RID: 93871 RVA: 0x006ECDE9 File Offset: 0x006EB1E9
	public void sgClearStateStack()
	{
		if (this.m_pkStateGraph != null)
		{
			this.m_pkStateGraph.ClearStateStack();
		}
	}

	// Token: 0x06016EB0 RID: 93872 RVA: 0x006ECE01 File Offset: 0x006EB201
	public void sgPopState()
	{
		if (this.m_pkStateGraph != null)
		{
			this.m_pkStateGraph.PopState();
		}
	}

	// Token: 0x06016EB1 RID: 93873 RVA: 0x006ECE1A File Offset: 0x006EB21A
	public virtual void Locomote(BeStateData rkStateData, bool bForce = false)
	{
		if (this.m_pkStateGraph != null && !this.IsRemoved())
		{
			this.m_pkStateGraph.Locomote(rkStateData, bForce);
		}
	}

	// Token: 0x06016EB2 RID: 93874 RVA: 0x006ECE3F File Offset: 0x006EB23F
	public void sgSwitchStates(BeStateData s)
	{
		if (this.m_pkStateGraph != null)
		{
			this.m_pkStateGraph.SwitchStates(s);
		}
	}

	// Token: 0x06016EB3 RID: 93875 RVA: 0x006ECE59 File Offset: 0x006EB259
	public void sgSetCurrentStatesTimeout(int fTime)
	{
		if (this.m_pkStateGraph != null)
		{
			this.m_pkStateGraph.SetCurrentStatesTimeout((int)((ulong)this.m_pkStateGraph.GetCurrentStatesTime() + (ulong)((long)fTime)), false);
		}
	}

	// Token: 0x06016EB4 RID: 93876 RVA: 0x006ECE82 File Offset: 0x006EB282
	public int sgGetCurrentState()
	{
		if (this.m_pkStateGraph != null)
		{
			return this.m_pkStateGraph.GetCurrentState();
		}
		return -1;
	}

	// Token: 0x06016EB5 RID: 93877 RVA: 0x006ECE9C File Offset: 0x006EB29C
	public int GetCamp()
	{
		return this.m_iCamp;
	}

	// Token: 0x06016EB6 RID: 93878 RVA: 0x006ECEA4 File Offset: 0x006EB2A4
	public int GetPID()
	{
		return this.m_iID;
	}

	// Token: 0x06016EB7 RID: 93879 RVA: 0x006ECEAC File Offset: 0x006EB2AC
	public int GetLifeState()
	{
		return this.m_iEntityLifeState;
	}

	// Token: 0x06016EB8 RID: 93880 RVA: 0x006ECEB4 File Offset: 0x006EB2B4
	public void SetLifeState(EntityLifeState state)
	{
		this.m_iEntityLifeState = (int)state;
	}

	// Token: 0x06016EB9 RID: 93881 RVA: 0x006ECEBD File Offset: 0x006EB2BD
	public void SetPosition(VInt3 rkPos, bool immediate = false, bool showLog = true, bool needUpdateBackPos = false)
	{
		if (this.m_kPosition != rkPos)
		{
			this.m_kPosition = rkPos;
			this.m_bPositionDirty = true;
			if (needUpdateBackPos)
			{
				this.m_kBlockPosition = rkPos;
			}
			if (immediate)
			{
				this._updateGraphicActor(false);
			}
		}
	}

	// Token: 0x06016EBA RID: 93882 RVA: 0x006ECEFC File Offset: 0x006EB2FC
	public void SetStandPosition(VInt3 pos, bool immediate = false)
	{
		VInt3 pos2 = pos;
		pos2.z = 0;
		VInt3 rkPos;
		if (this.m_kBlockPosition == VInt3.zero)
		{
			rkPos = BeAIManager.FindStandPositionNew(pos2, this.CurrentBeScene, this.GetFace(), false, 30);
		}
		else
		{
			rkPos = this.m_kBlockPosition;
		}
		rkPos.z = pos.z;
		this.SetPosition(rkPos, immediate, true, false);
	}

	// Token: 0x06016EBB RID: 93883 RVA: 0x006ECF64 File Offset: 0x006EB364
	public void SaveCurrentPosition()
	{
		this.savedPosition = this.GetPosition();
	}

	// Token: 0x06016EBC RID: 93884 RVA: 0x006ECF72 File Offset: 0x006EB372
	public void SetRestrainPosition(bool flag)
	{
		this.restrainPosition = flag;
	}

	// Token: 0x06016EBD RID: 93885 RVA: 0x006ECF7B File Offset: 0x006EB37B
	public VInt3 GetPosition()
	{
		return this.m_kPosition;
	}

	// Token: 0x06016EBE RID: 93886 RVA: 0x006ECF84 File Offset: 0x006EB384
	public Vec3 GetGePosition(PositionType pt)
	{
		Vec3 vec = this.GetPosition().vec3;
		if (this.m_pkGeActor == null)
		{
			return vec;
		}
		if (pt == PositionType.BODY)
		{
			vec += new Vec3(this.m_pkGeActor.bodyLocalPosition.x, this.m_pkGeActor.bodyLocalPosition.z, this.m_pkGeActor.bodyLocalPosition.y);
		}
		else if (pt == PositionType.OVERHEAD)
		{
			Vector3 overHeadPosition = this.m_pkGeActor.GetOverHeadPosition();
			vec += new Vec3(overHeadPosition.x, overHeadPosition.z, overHeadPosition.y);
		}
		else if (pt == PositionType.ORIGIN_BUFF)
		{
			vec += new Vec3(this.m_pkGeActor.buffOriginLocalPosition.x, this.m_pkGeActor.buffOriginLocalPosition.z, this.m_pkGeActor.buffOriginLocalPosition.y);
		}
		Vec3[] array = new Vec3[]
		{
			vec
		};
		this.TriggerEvent(BeEventType.onChangeBeHitNumberPos, new object[]
		{
			array
		});
		return array[0];
	}

	// Token: 0x06016EBF RID: 93887 RVA: 0x006ED0A5 File Offset: 0x006EB4A5
	public VInt2 GetPosition2()
	{
		return new VInt2(this.m_kPosition.x, this.m_kPosition.y);
	}

	// Token: 0x06016EC0 RID: 93888 RVA: 0x006ED0C2 File Offset: 0x006EB4C2
	public Vector3 GetGePosition()
	{
		return new Vector3(this.m_kPosition.fx, this.m_kPosition.fz, this.m_kPosition.fy);
	}

	// Token: 0x06016EC1 RID: 93889 RVA: 0x006ED0EC File Offset: 0x006EB4EC
	public int GetDistance(BeEntity target)
	{
		if (target == null)
		{
			return 0;
		}
		VInt2 position = this.GetPosition2();
		VInt2 position2 = target.GetPosition2();
		return (position - position2).magnitude;
	}

	// Token: 0x06016EC2 RID: 93890 RVA: 0x006ED120 File Offset: 0x006EB520
	public void SetFace(bool bFace, bool immediate = false, bool force = false)
	{
		if (!this.stateController.CanTurnFace() && !force)
		{
			return;
		}
		if (this.m_bFaceLeft != bFace)
		{
			this.m_bFaceLeft = bFace;
			this.m_bPositionDirty = true;
			if (this.IsProcessRecord())
			{
				this.GetRecordServer().Mark(142055317U, this.GetEntityRecordAttribute(), new string[]
				{
					this.GetName()
				});
			}
			this.OnChangeFace();
			this.TriggerEvent(BeEventType.onChangeFace, null);
			if (immediate)
			{
				this._updateGraphicActor(false);
			}
		}
	}

	// Token: 0x06016EC3 RID: 93891 RVA: 0x006ED1AA File Offset: 0x006EB5AA
	public virtual void OnChangeFace()
	{
	}

	// Token: 0x06016EC4 RID: 93892 RVA: 0x006ED1AC File Offset: 0x006EB5AC
	public bool GetFace()
	{
		return this.m_bFaceLeft;
	}

	// Token: 0x06016EC5 RID: 93893 RVA: 0x006ED1B4 File Offset: 0x006EB5B4
	public void SetScale(VInt fScale)
	{
		if (this.m_fScale != fScale)
		{
			this.m_fScale = fScale;
			this.m_bPositionDirty = true;
		}
	}

	// Token: 0x06016EC6 RID: 93894 RVA: 0x006ED1D5 File Offset: 0x006EB5D5
	public VInt GetScale()
	{
		return this.m_fScale;
	}

	// Token: 0x06016EC7 RID: 93895 RVA: 0x006ED1DD File Offset: 0x006EB5DD
	public void SetZDimScaleFactor(VFactor scale)
	{
		this.m_fZdimScaleFactor = scale;
	}

	// Token: 0x06016EC8 RID: 93896 RVA: 0x006ED1E6 File Offset: 0x006EB5E6
	public VFactor GetZDimScaleFactor()
	{
		return this.m_fZdimScaleFactor;
	}

	// Token: 0x06016EC9 RID: 93897 RVA: 0x006ED1EE File Offset: 0x006EB5EE
	public bool HasTag(int iTag)
	{
		return this.m_kStateTag.HasFlag(iTag);
	}

	// Token: 0x06016ECA RID: 93898 RVA: 0x006ED1FC File Offset: 0x006EB5FC
	public void SetTag(int iTag, bool bSet)
	{
		if (bSet)
		{
			this.m_kStateTag.SetFlag(iTag, null);
		}
		else
		{
			this.m_kStateTag.ClearFlag(iTag);
		}
	}

	// Token: 0x06016ECB RID: 93899 RVA: 0x006ED222 File Offset: 0x006EB622
	public bool CanBeAttacked()
	{
		return this.m_bCanBeAttacked;
	}

	// Token: 0x06016ECC RID: 93900 RVA: 0x006ED22A File Offset: 0x006EB62A
	public void SetCanBeAttacked(bool bValue)
	{
		this.m_bCanBeAttacked = bValue;
	}

	// Token: 0x06016ECD RID: 93901 RVA: 0x006ED233 File Offset: 0x006EB633
	public void SetCurSkillID(int iSkillID)
	{
		this.m_iCurSkillID = iSkillID;
		this.m_bSkillDirty = true;
	}

	// Token: 0x06016ECE RID: 93902 RVA: 0x006ED243 File Offset: 0x006EB643
	public int GetCurSkillID()
	{
		return this.m_iCurSkillID;
	}

	// Token: 0x06016ECF RID: 93903 RVA: 0x006ED24B File Offset: 0x006EB64B
	public virtual bool IsCurSkillOpenShock()
	{
		return true;
	}

	// Token: 0x06016ED0 RID: 93904 RVA: 0x006ED24E File Offset: 0x006EB64E
	public int PlayQueuedAction(List<ActionType> actions, float aniSpeed = 1f)
	{
		this.actionQueue = actions;
		this.queuedActionSpeed = aniSpeed;
		this.PlayActionAuto();
		return 0;
	}

	// Token: 0x06016ED1 RID: 93905 RVA: 0x006ED265 File Offset: 0x006EB665
	public void ClearQueuedAction()
	{
		if (this.actionQueue != null && this.actionQueue.Count > 0)
		{
			this.actionQueue.Clear();
		}
	}

	// Token: 0x06016ED2 RID: 93906 RVA: 0x006ED290 File Offset: 0x006EB690
	public void PlayActionAuto()
	{
		if (this.actionQueue.Count > 0)
		{
			ActionType iAction = this.actionQueue[0];
			this.actionQueue.RemoveAt(0);
			int num = this.PlayAction(iAction, this.queuedActionSpeed, true);
			this.actionAcc = 0;
		}
	}

	// Token: 0x06016ED3 RID: 93907 RVA: 0x006ED2E0 File Offset: 0x006EB6E0
	public int PlayAction(ActionType iAction, float aniSpeed = 1f, bool queued = false)
	{
		if (!queued)
		{
			this.ClearQueuedAction();
		}
		if (iAction < (ActionType)BeEntity.ActionConfigNames.Length)
		{
			string acActionName = BeEntity.ActionConfigNames[(int)iAction];
			this.actionTimeout = this.PlayAction(acActionName, aniSpeed);
			return this.actionTimeout;
		}
		return 0;
	}

	// Token: 0x06016ED4 RID: 93908 RVA: 0x006ED324 File Offset: 0x006EB724
	public bool HasAction(string actionName)
	{
		return this.m_cpkEntityInfo != null && this.m_cpkEntityInfo.HasAction(actionName);
	}

	// Token: 0x06016ED5 RID: 93909 RVA: 0x006ED340 File Offset: 0x006EB740
	public bool HasAction(ActionType type)
	{
		string actionName = BeEntity.ActionConfigNames[(int)type];
		return this.HasAction(actionName);
	}

	// Token: 0x06016ED6 RID: 93910 RVA: 0x006ED35C File Offset: 0x006EB75C
	public void ResetActionInfo()
	{
		if (this.IsProcessRecord())
		{
			this.GetRecordServer().Mark(142055318U, this.GetEntityRecordAttribute(), new string[]
			{
				this.GetName()
			});
		}
		if (this.m_pkGeActor != null)
		{
			this.m_iCurrentLogicFrame = 0;
			this.m_cpkCurEntityActionInfo = null;
			this.m_cpkCurEntityActionFrameData = null;
			this.m_pkGeActor.Clear(4);
			this.actionLooped = false;
			this.m_pkGeActor.StopAction();
		}
	}

	// Token: 0x06016ED7 RID: 93911 RVA: 0x006ED3D8 File Offset: 0x006EB7D8
	public int PlayAction(string acActionName, float aniSpeed = 1f)
	{
		if (acActionName == "ExpDead")
		{
			this.playedExpDead = true;
		}
		if (this.m_pkGeActor != null)
		{
			this.m_iCurrentLogicFrame = -1;
			if (this.m_cpkEntityInfo != null)
			{
				if (this.m_cpkEntityInfo.HasAction(acActionName))
				{
					this.m_cpkCurEntityActionInfo = this.m_cpkEntityInfo._vkActionsMap[acActionName];
					this.m_cpkEntityInfo.SetActionName(acActionName);
				}
				else
				{
					if (this.GetRecordServer().IsProcessRecord())
					{
						this.GetRecordServer().Mark(142055319U, this.GetEntityRecordAttribute(), new string[]
						{
							this.GetName(),
							acActionName
						});
					}
					this.m_cpkCurEntityActionInfo = null;
					this.m_cpkEntityInfo.SetActionName(string.Empty);
				}
			}
			else
			{
				this.m_cpkCurEntityActionInfo = null;
			}
			this.attachmentproxy.Init(this.m_cpkCurEntityActionInfo);
			this.m_pkGeActor.Clear(4);
			if (this.m_cpkCurEntityActionInfo != null)
			{
				int allFlag = this.m_cpkCurEntityActionInfo.exFlag.GetAllFlag();
				if (allFlag > 0)
				{
					this.m_pkStateGraph.GetCurrentStateData().kExTags.SetFlag(allFlag, null);
				}
				this._updateFrame(true);
				this.actionLooped = false;
				bool flag = this.m_cpkCurEntityActionInfo.bLoop;
				if (this.m_cpkCurEntityActionInfo.actionName.Contains("idle", StringComparison.OrdinalIgnoreCase) || this.m_cpkCurEntityActionInfo.actionName.Contains("walk", StringComparison.OrdinalIgnoreCase))
				{
					flag = true;
				}
				if (!flag && this.m_cpkCurEntityActionInfo.bAnimLoop1)
				{
					flag = true;
				}
				this.m_pkGeActor.ChangeAction(this.m_cpkCurEntityActionInfo.actionName, aniSpeed * this.m_cpkCurEntityActionInfo.animationspeed, flag, true, false);
				int[] array = new int[]
				{
					this.m_cpkCurEntityActionInfo.skillTotalTime,
					GlobalLogic.VALUE_1000
				};
				this.TriggerEvent(BeEventType.onChangeSkillTime, new object[]
				{
					this.m_cpkCurEntityActionInfo.skillID,
					array
				});
				int val = array[0] * VFactor.NewVFactor(array[1], GlobalLogic.VALUE_1000);
				return Math.Max(this.m_cpkCurEntityActionInfo.fRealFramesTime, val);
			}
			if (this.IsProcessRecord())
			{
				this.GetRecordServer().Mark(142055320U, this.GetEntityRecordAttribute(), new string[]
				{
					acActionName,
					this.GetName()
				});
			}
		}
		return 0;
	}

	// Token: 0x06016ED8 RID: 93912 RVA: 0x006ED638 File Offset: 0x006EBA38
	public void _ChangeAnimation(string aniName, float aniSpeed = 1f)
	{
		if (this.m_cpkCurEntityActionInfo != null && this.m_pkGeActor != null)
		{
			bool bLoop = this.m_cpkCurEntityActionInfo.bLoop;
			this.m_pkGeActor.ChangeAction(aniName, aniSpeed * this.m_cpkCurEntityActionInfo.animationspeed, bLoop, true, false);
		}
	}

	// Token: 0x06016ED9 RID: 93913 RVA: 0x006ED684 File Offset: 0x006EBA84
	public void SetNeedDead(bool flag)
	{
		this.needDead = flag;
	}

	// Token: 0x06016EDA RID: 93914 RVA: 0x006ED690 File Offset: 0x006EBA90
	public int GetCurrentActionDuration()
	{
		int result = 0;
		if (this.m_cpkCurEntityActionInfo != null)
		{
			result = this.m_cpkCurEntityActionInfo.fRealFramesTime;
		}
		return result;
	}

	// Token: 0x06016EDB RID: 93915 RVA: 0x006ED6B7 File Offset: 0x006EBAB7
	public BeStatesGraph GetStateGraph()
	{
		return this.m_pkStateGraph;
	}

	// Token: 0x06016EDC RID: 93916 RVA: 0x006ED6BF File Offset: 0x006EBABF
	public void SetStateGraph(BeStatesGraph pkStateGraph, int iStartState)
	{
		this.m_pkStateGraph = pkStateGraph;
		this.stateStart = iStartState;
	}

	// Token: 0x06016EDD RID: 93917 RVA: 0x006ED6D0 File Offset: 0x006EBAD0
	public virtual bool _isCmdMoveForbiden()
	{
		return this.m_pkStateGraph == null || this.GetEntityData() == null || (this.GetEntityData() != null && this.IsDead()) || !this.stateController.CanMove() || (this.m_pkStateGraph.CurrentStateHasTag(1) || (this.m_pkStateGraph.CurrentStateHasTag(2) && !this.m_kStateTag.HasFlag(2)));
	}

	// Token: 0x06016EDE RID: 93918 RVA: 0x006ED755 File Offset: 0x006EBB55
	public void ClearState()
	{
		this._clearStates();
	}

	// Token: 0x06016EDF RID: 93919 RVA: 0x006ED75D File Offset: 0x006EBB5D
	public virtual bool _onCreate()
	{
		return false;
	}

	// Token: 0x06016EE0 RID: 93920 RVA: 0x006ED760 File Offset: 0x006EBB60
	public virtual void _updateAction(int deltaTime)
	{
		if (this.actionQueue.Count <= 0)
		{
			return;
		}
		this.actionAcc += deltaTime;
		if (this.actionAcc > this.actionTimeout)
		{
			this.PlayActionAuto();
		}
	}

	// Token: 0x06016EE1 RID: 93921 RVA: 0x006ED79C File Offset: 0x006EBB9C
	public virtual void _updateFrame(bool force = false)
	{
		if (!force && (this.pause || this.m_cpkCurEntityActionInfo == null))
		{
			return;
		}
		int iCurrentLogicFrame = this.m_iCurrentLogicFrame;
		uint currentStatesTime = this.m_pkStateGraph.GetCurrentStatesTime();
		if (this.m_cpkCurEntityActionInfo.iLogicFramesNum <= 1)
		{
			this.m_fCurrentLogicFrame = 0f;
			this.m_iCurrentLogicFrame = 0;
		}
		else
		{
			VFactor vfactor = new VFactor((long)((ulong)currentStatesTime * (ulong)this.m_cpkCurEntityActionInfo.fLogicFrameDeltaTime.den), (long)GlobalLogic.VALUE_1000 * this.m_cpkCurEntityActionInfo.fLogicFrameDeltaTime.nom);
			this.m_iCurrentLogicFrame = vfactor.integer;
			this.m_fCurrentLogicFrame = vfactor.single;
			if (this.m_iCurrentLogicFrame >= this.m_cpkCurEntityActionInfo.iLogicFramesNum && this.m_cpkCurEntityActionInfo.bLoop)
			{
				this.actionLooped = true;
				this.m_iCurrentLogicFrame %= this.m_cpkCurEntityActionInfo.iLogicFramesNum;
				if (this.m_iCurrentLogicFrame == 0)
				{
					this.TriggerEvent(BeEventType.onActionLoop, null);
				}
			}
			if (this.m_fCurrentLogicFrame > (float)(this.m_cpkCurEntityActionInfo.iLogicFramesNum - 1))
			{
				if (this.m_cpkCurEntityActionInfo.bLoop)
				{
					this.m_fCurrentLogicFrame %= (float)(this.m_cpkCurEntityActionInfo.iLogicFramesNum - 1);
				}
				else
				{
					this.m_fCurrentLogicFrame = (float)(this.m_cpkCurEntityActionInfo.iLogicFramesNum - 1);
				}
			}
		}
		if (this.m_iCurrentLogicFrame >= 0 && this.m_iCurrentLogicFrame < this.m_cpkCurEntityActionInfo.vFramesData.Count)
		{
			this.m_cpkCurEntityActionFrameData = this.m_cpkCurEntityActionInfo.vFramesData[this.m_iCurrentLogicFrame];
			if (Global.Settings.isDebug)
			{
				if (this.m_pkGeActor != null && this.m_pkGeActor.showDebugBox)
				{
					this.m_pkGeActor.SetDebugDrawData(this.m_cpkCurEntityActionFrameData, this.m_fScale.scalar * this.skillAttackScale.single, this.m_fZdimScaleFactor.single);
				}
				else if (this.m_pkGeActor != null)
				{
					this.m_pkGeActor.SetDebugDrawData(null, 1f, 1f);
				}
			}
		}
		else
		{
			this.m_cpkCurEntityActionFrameData = this.m_cpkCurEntityActionInfo.vFramesData[this.m_cpkCurEntityActionInfo.iLogicFramesNum - 1];
		}
		if (iCurrentLogicFrame != this.m_iCurrentLogicFrame)
		{
			this._onEnterFrame(this.m_iCurrentLogicFrame);
		}
	}

	// Token: 0x06016EE2 RID: 93922 RVA: 0x006EDA08 File Offset: 0x006EBE08
	public virtual void _onEnterFrame(int iFrame)
	{
		BDEntityActionFrameData cpkCurEntityActionFrameData = this.m_cpkCurEntityActionFrameData;
		if (cpkCurEntityActionFrameData != null && cpkCurEntityActionFrameData.pEvents.Count > 0)
		{
			for (int i = 0; i < cpkCurEntityActionFrameData.pEvents.Count; i++)
			{
				cpkCurEntityActionFrameData.pEvents[i].OnEvent(this);
			}
		}
		if (cpkCurEntityActionFrameData.kFlag.HasFlag(16))
		{
			this.ResetDamageData();
		}
		if (cpkCurEntityActionFrameData.kFlag.HasFlag(32))
		{
			this.m_pkStateGraph.SetCurrentStateTag(4, true);
		}
		if (cpkCurEntityActionFrameData.kFlag.HasFlag(64))
		{
			this.m_pkStateGraph.SetCurrentStateTag(4, false);
		}
		if (cpkCurEntityActionFrameData.kFlag.HasFlag(256))
		{
			if (this.isFloating)
			{
				this.RemoveFloating();
			}
			else
			{
				this.stateController.SetAbilityEnable(BeAbilityType.GRAVITY, true);
			}
		}
		if (cpkCurEntityActionFrameData.kFlag.HasFlag(128))
		{
			if (this.isFloating)
			{
				this.RestoreFloating(true);
			}
			else
			{
				this.stateController.SetAbilityEnable(BeAbilityType.GRAVITY, false);
			}
		}
		if (cpkCurEntityActionFrameData.kFlag.HasFlag(512))
		{
			this.OnDealFrameTag(DSFFrameTags.TAG_SET_TARGET_POS_XY);
		}
		if (cpkCurEntityActionFrameData.kFlag.HasFlag(1024))
		{
			string flagData = cpkCurEntityActionFrameData.kFlag.GetFlagData();
			if (flagData != null)
			{
				this.owner.TriggerEvent(BeEventType.onSkillCurFrame, new object[]
				{
					flagData
				});
			}
		}
		if (cpkCurEntityActionFrameData.kFlag.HasFlag(2048))
		{
			this.owner.SetFace(!this.owner.GetFace(), false, false);
		}
		if (cpkCurEntityActionFrameData.kFlag.HasFlag(4096))
		{
			int num = (int)(this.m_Degree * 15);
			if (num > 90 && num < 270)
			{
				this.owner.SetFace(true, false, false);
			}
			else
			{
				this.owner.SetFace(false, false, false);
			}
		}
	}

	// Token: 0x06016EE3 RID: 93923 RVA: 0x006EDC0B File Offset: 0x006EC00B
	public virtual void OnDealFrameTag(DSFFrameTags frameTag)
	{
	}

	// Token: 0x06016EE4 RID: 93924 RVA: 0x006EDC10 File Offset: 0x006EC010
	public bool CanMoveNext(bool dirX, bool moveRight)
	{
		VInt3 position = this.GetPosition();
		if (dirX)
		{
			int num = this.speedConfig.x;
			num = ((!moveRight) ? (-num) : num);
			position.x += (BeEntity.speedScaleFactor * this.m_fMoveXSpeedRate * (long)num).roundInt;
		}
		else
		{
			int num2 = this.speedConfig.y;
			num2 = ((!moveRight) ? (-num2) : num2);
			position.y += (BeEntity.speedScaleFactor * this.m_fMoveYSpeedRate * (long)num2).roundInt;
		}
		return !this.currentBeScene.IsInBlockPlayer(position);
	}

	// Token: 0x06016EE5 RID: 93925 RVA: 0x006EDCDB File Offset: 0x006EC0DB
	public int GetEnhanceRadius()
	{
		if (this.GetEntityData() != null)
		{
			return this.GetEntityData().enhancedRadius;
		}
		return 0;
	}

	// Token: 0x06016EE6 RID: 93926 RVA: 0x006EDCF5 File Offset: 0x006EC0F5
	protected VInt3 EnhanceVec(VInt3 pos, bool faceLeft, VInt dis)
	{
		if (faceLeft)
		{
			pos.x -= dis.i;
		}
		else
		{
			pos.x += dis.i;
		}
		return pos;
	}

	// Token: 0x06016EE7 RID: 93927 RVA: 0x006EDD30 File Offset: 0x006EC130
	public virtual void _updatePosition(int iDeltime)
	{
		this.inUpdatePosition = true;
		if (this.moveXSpeed != 0 || this.moveYSpeed != 0 || this.moveZSpeed != 0 || this.extraSpeed.x != 0 || this.extraSpeed.y != 0 || this.GetPosition().z > 0 || this.resetMoveDirty)
		{
			if (this.resetMoveDirty)
			{
				this.resetMoveDirty = false;
			}
			VFactor vfactor = new VFactor((long)iDeltime, 1000L);
			VInt vint = vfactor.vint;
			if (this.moveXSpeed != 0 && this.moveXAcc != 0)
			{
				int num = (!(this.moveXSpeed > 0)) ? -1 : 1;
				this.moveXSpeed += num * this.moveXAcc.i * vfactor;
				if (num > 0)
				{
					this.moveXSpeed = Math.Max(0, this.moveXSpeed.i);
				}
				else if (num < 0)
				{
					this.moveXSpeed = Math.Min(0, this.moveXSpeed.i);
				}
			}
			if (this.moveYSpeed != 0 && this.moveYAcc != 0)
			{
				int num2 = (!(this.moveYSpeed > 0)) ? -1 : 1;
				this.moveYSpeed += num2 * this.moveYAcc.i * vfactor;
				if (num2 > 0)
				{
					this.moveYSpeed = Math.Max(0, this.moveYSpeed.i);
				}
				else if (num2 < 0)
				{
					this.moveYSpeed = Math.Min(0, this.moveYSpeed.i);
				}
			}
			VInt3 kPosition = this.m_kPosition;
			VInt3 vint2 = kPosition;
			bool faceLeft = !(this.moveXSpeed + this.extraSpeed.x > 0);
			bool flag = this.boxRadius > 0 && this.currentBeScene.IsInBlockPlayer(this.EnhanceVec(vint2, faceLeft, this.boxRadius));
			if ((this.aiManager != null && this.aiManager.isAutoFight && !this.pauseAI) || this.sgGetCurrentState() == 6)
			{
				flag = false;
			}
			int x = vint2.x;
			bool flag2 = false;
			if (this.CanUpdateX())
			{
				vint2.x += (vfactor * this.m_fMoveXSpeedRate * (long)(this.moveXSpeed + this.extraSpeed.x).i).roundInt;
			}
			if (this is BeActor && (this.currentBeScene.IsInBlockPlayer(vint2) || flag) && this.stateController.HasAbility(BeAbilityType.BLOCK))
			{
				this.blockparams[0] = this;
				this.TriggerEvent(BeEventType.onXInBlock, this.blockparams);
			}
			else
			{
				this.m_kPosition.x = vint2.x;
				flag2 = true;
			}
			if (this.currentBeScene.IsInBlockPlayer(vint2) || flag)
			{
				this.OnXInBlock();
			}
			if (!this.currentBeScene.IsInBlockPlayer(vint2) && !flag)
			{
				this.m_kBlockPosition.x = vint2.x;
			}
			vint2 = kPosition;
			if (flag2)
			{
				vint2.x = this.m_kBlockPosition.x;
			}
			if (this.CanUpdateY())
			{
				vint2.y += (vfactor * this.m_fMoveYSpeedRate * (long)(this.moveYSpeed + this.extraSpeed.y).i).roundInt;
			}
			flag = (this.boxRadius > 0 && this.currentBeScene.IsInBlockPlayer(vint2));
			if ((this.aiManager != null && this.aiManager.isAutoFight && !this.pauseAI) || this.sgGetCurrentState() == 6)
			{
				flag = false;
			}
			if (this is BeActor && (this.currentBeScene.IsInBlockPlayer(vint2) || flag) && this.stateController.HasAbility(BeAbilityType.BLOCK))
			{
				this.blockparams[0] = this;
				int[] array = new int[2];
				array[0] = x;
				int[] array2 = array;
				this.blockparams[1] = array2;
				this.TriggerEvent(BeEventType.onYInBlock, this.blockparams);
				if (array2[1] == 1)
				{
					this.m_kPosition.x = array2[0];
				}
			}
			else
			{
				this.m_kPosition.y = vint2.y;
			}
			if (!this.currentBeScene.IsInBlockPlayer(vint2) && !flag)
			{
				this.m_kBlockPosition.y = vint2.y;
			}
			bool flag3 = false;
			if (this.m_pkStateGraph != null && this.m_pkStateGraph.CurrentStateHasTag(4))
			{
				flag3 = true;
			}
			if (!this.stateController.HasAbility(BeAbilityType.GRAVITY))
			{
				flag3 = true;
			}
			if (!flag3 && this.CanUpdateZ())
			{
				if (this.m_kPosition.z > 0 || this.moveZSpeed != 0)
				{
					VInt vint3 = this.moveZAcc;
					if (this.HasTag(1) && this.moveZSpeed <= 0)
					{
						vint3 = this.moveZAcc.i * VFactor.NewVFactorF(Global.Settings.fallGravityReduceFactor, 1000);
					}
					VInt moveZSpeed = this.moveZSpeed;
					this.moveZSpeed -= vint3.i * vfactor;
					this.m_kPosition.z = this.m_kPosition.z + this.moveZSpeed.i * vfactor;
					if (moveZSpeed >= 0 && this.moveZSpeed <= 0 && this.m_pkStateGraph != null)
					{
						this.m_pkStateGraph.FireEvents2CurrentStates(3);
					}
					if (this.m_kPosition.z <= 0 && !this.HasTag(8))
					{
						this.clickZSpeed = this.moveZSpeed;
						this.m_kPosition.z = 0;
						this.moveZSpeed = 0;
						if (this.m_pkStateGraph != null)
						{
							this.TriggerEvent(BeEventType.onTouchGround, null);
							this.m_pkStateGraph.FireEvents2CurrentStates(4);
						}
					}
				}
				else
				{
					this.m_kPosition.z = 0;
					this.moveZSpeed = 0;
					if (this.m_pkStateGraph != null)
					{
						this.TriggerEvent(BeEventType.onTouchGround, null);
						this.m_pkStateGraph.FireEvents2CurrentStates(4);
					}
				}
			}
			this.m_bPositionDirty = true;
		}
		if (this.pkRestrainPosition)
		{
			this.m_kPosition.x = Mathf.Clamp(this.m_kPosition.x, this.pkRestrainRangeX.x, this.pkRestrainRangeX.y);
		}
		if (this.restrainPosition && this.m_bPositionDirty)
		{
			this.CheckReachAreaLimit();
			VInt3 kPosition2 = this.m_kPosition;
			VInt2 logicZSize = this.currentBeScene.logicZSize;
			VInt2 logicXSize = this.currentBeScene.logicXSize;
			this.m_kPosition.y = Mathf.Clamp(this.m_kPosition.y, logicZSize.x, logicZSize.y);
			this.m_kPosition.x = Mathf.Clamp(this.m_kPosition.x, logicXSize.x, logicXSize.y);
			this.m_bPositionDirty = false;
		}
		this.extraSpeed = VInt3.zero;
		this.inUpdatePosition = false;
	}

	// Token: 0x06016EE8 RID: 93928 RVA: 0x006EE571 File Offset: 0x006EC971
	public void CheckReachAreaLimit()
	{
	}

	// Token: 0x06016EE9 RID: 93929 RVA: 0x006EE574 File Offset: 0x006EC974
	public InputManager.PressDir GetJoystickPressDir()
	{
		int degree = (int)(this.m_Degree * 15);
		return InputManager.GetDir(degree);
	}

	// Token: 0x06016EEA RID: 93930 RVA: 0x006EE591 File Offset: 0x006EC991
	public int GetJoystickDegree()
	{
		return (int)(this.m_Degree * 15);
	}

	// Token: 0x06016EEB RID: 93931 RVA: 0x006EE59C File Offset: 0x006EC99C
	public virtual void _updateMoveCmd()
	{
		if (!this.m_bCmdDirty)
		{
			return;
		}
		if (this._isCmdMoveForbiden())
		{
			return;
		}
		this.m_bHaveMoveCmd = false;
		this.m_bCmdDirty = false;
		this.moveXSpeed = 0;
		this.moveYSpeed = 0;
		if (this.m_vkMoveCmd[4])
		{
			VInt moveXSpeed;
			VInt moveYSpeed;
			this.GetMoveSpeedFromDirection(out moveXSpeed, out moveYSpeed);
			this.moveXSpeed = moveXSpeed;
			this.moveYSpeed = moveYSpeed;
		}
		else
		{
			if (this.m_vkMoveCmd[0])
			{
				this.m_bHaveMoveCmd = true;
				this.moveXSpeed = this.speedConfig.x;
			}
			if (this.m_vkMoveCmd[1])
			{
				this.m_bHaveMoveCmd = true;
				this.moveXSpeed = -this.speedConfig.x;
			}
			if (this.m_vkMoveCmd[2])
			{
				this.m_bHaveMoveCmd = true;
				this.moveYSpeed = this.speedConfig.y;
			}
			if (this.m_vkMoveCmd[3])
			{
				this.m_bHaveMoveCmd = true;
				this.moveYSpeed = -this.speedConfig.y;
			}
		}
		if (this.keepXSkillSpeed)
		{
			this.moveXSpeed = ((!this.GetFace()) ? this.speedConfig.x : (-this.speedConfig.x));
		}
		if (this.onlyMoveFacedDir && ((this.GetFace() && this.moveXSpeed.i > 0) || (!this.GetFace() && this.moveXSpeed.i < 0)))
		{
			this.moveXSpeed = 0;
		}
		if (this.onlyMoveFaceDirOpposite && ((this.GetFace() && this.moveXSpeed.i < 0) || (!this.GetFace() && this.moveXSpeed.i > 0)))
		{
			this.moveXSpeed = 0;
		}
		if (this.stateController.HasBuffState(BeBuffStateType.CONFUNSE))
		{
			this.moveXSpeed = -1 * this.moveXSpeed.i;
			this.moveYSpeed = -1 * this.moveYSpeed.i;
		}
		if (this.moveXSpeed != 0)
		{
			if (!this.dontSetFace && (this.sgGetCurrentState() != 14 || this.skillFreeTurnFace))
			{
				this.SetFace(this.moveXSpeed.i < 0, false, false);
			}
		}
		if (!this.stateController.CanMoveX())
		{
			this.moveXSpeed = 0;
			this.moveXAcc = 0;
		}
		if (!this.stateController.CanMoveY())
		{
			this.moveYSpeed = 0;
			this.moveYAcc = 0;
		}
		if (!this.stateController.CanMoveZ())
		{
			this.moveZSpeed = 0;
			this.moveZAcc = 0;
		}
		if (this.m_pkStateGraph != null)
		{
			this.m_pkStateGraph.FireEvents2CurrentStates(1);
		}
		this.moveSpeed[0] = this.moveXSpeed;
		this.moveSpeed[1] = this.moveYSpeed;
		this.changeSpeedEventParam[0] = this.moveSpeed;
		this.TriggerEvent(BeEventType.OnChangeSpeed, this.changeSpeedEventParam);
		this.moveXSpeed = this.moveSpeed[0];
		this.moveYSpeed = this.moveSpeed[1];
	}

	// Token: 0x06016EEC RID: 93932 RVA: 0x006EE970 File Offset: 0x006ECD70
	public bool IsPressForwardMoveCmd()
	{
		if (this.IsInMoveDirection())
		{
			VInt vint;
			VInt vint2;
			this.GetMoveSpeedFromDirection(out vint, out vint2);
			return (this.GetFace() && vint.i < -VInt.one.i / 100) || (!this.GetFace() && vint.i > VInt.one.i / 100);
		}
		return (!this.GetFace() && this.m_vkMoveCmd[0]) || (this.GetFace() && this.m_vkMoveCmd[1]);
	}

	// Token: 0x06016EED RID: 93933 RVA: 0x006EEA18 File Offset: 0x006ECE18
	public bool IsPressBackwardMoveCmd()
	{
		if (this.IsInMoveDirection())
		{
			VInt vint;
			VInt vint2;
			this.GetMoveSpeedFromDirection(out vint, out vint2);
			return (!this.GetFace() && vint.i < -VInt.one.i / 100) || (this.GetFace() && vint.i > VInt.one.i / 100);
		}
		return (this.GetFace() && this.m_vkMoveCmd[0]) || (!this.GetFace() && this.m_vkMoveCmd[1]);
	}

	// Token: 0x06016EEE RID: 93934 RVA: 0x006EEAC0 File Offset: 0x006ECEC0
	public virtual void _updateWorldDBox(int iDeltaTime)
	{
		BDEntityActionFrameData cpkCurEntityActionFrameData = this.m_cpkCurEntityActionFrameData;
		if (cpkCurEntityActionFrameData != null)
		{
			VInt3 position = this.GetPosition();
			int x = position.x;
			int i = position.y * DBoxConfig.fSinA + position.z * DBoxConfig.fCosA;
			VFactor factor = this.m_fScale.factor;
			if (cpkCurEntityActionFrameData.pAttackData != null)
			{
				int[] array = this.temp_array_3;
				array[0] = 0;
				array[1] = 0;
				array[2] = 0;
				if (this.m_cpkCurEntityActionInfo != null)
				{
					this.temp_event[0] = this.m_cpkCurEntityActionInfo.skillID;
					this.temp_event[1] = array;
					this.TriggerEvent(BeEventType.onChangeAttackDBox, this.temp_event);
				}
				int num = array[0];
				VFactor f = VFactor.NewVFactor(array[1], GlobalLogic.VALUE_1000);
				VFactor f2 = VFactor.NewVFactor(array[2], GlobalLogic.VALUE_1000);
				List<DBoxImp> vBox = cpkCurEntityActionFrameData.pAttackData.vBox;
				for (int j = 0; j < vBox.Count; j++)
				{
					if (DBoxConfig.b2D)
					{
						DBox vBox2 = vBox[j].vBox;
						if (!f.IsZero || !f2.IsZero)
						{
							int num2 = (vBox2._max.x - vBox2._min.x) * f;
							int num3 = (vBox2._max.y - vBox2._min.y) * f2;
							if (num == 0)
							{
								vBox2._max.x = vBox2._max.x + num2 / 2;
								vBox2._min.x = vBox2._min.x - num2 / 2;
								vBox2._max.y = vBox2._max.y + num3 / 2;
								vBox2._min.y = vBox2._min.y - num3 / 2;
							}
							else
							{
								vBox2._max.x = vBox2._max.x + num2;
								vBox2._max.y = vBox2._max.y + num3 / 2;
								vBox2._min.y = vBox2._min.y - num3 / 2;
							}
						}
						this.m_vkCurWorldAttackBox.vBox[j].vWorldBox.offset(vBox2, x, i, factor * this.skillAttackScale, this.GetFace());
					}
				}
			}
			if (cpkCurEntityActionFrameData.pDefenseData != null)
			{
				List<DBoxImp> vBox3 = cpkCurEntityActionFrameData.pDefenseData.vBox;
				for (int k = 0; k < vBox3.Count; k++)
				{
					if (DBoxConfig.b2D)
					{
						this.m_vkCurWorldDefenseBox.vBox[k].vWorldBox.offset(vBox3[k].vBox, x, i, factor, this.GetFace());
					}
				}
			}
		}
	}

	// Token: 0x06016EEF RID: 93935 RVA: 0x006EEDA0 File Offset: 0x006ED1A0
	public virtual void _calcAttack()
	{
		BDEntityActionFrameData cpkCurEntityActionFrameData = this.m_cpkCurEntityActionFrameData;
		if (cpkCurEntityActionFrameData != null && cpkCurEntityActionFrameData.pAttackData != null && cpkCurEntityActionFrameData.pAttackData.vBox.Count > 0)
		{
			int entityCount = this.currentBeScene.GetEntityCount();
			DBox rkBox = default(DBox);
			int hitType = cpkCurEntityActionFrameData.pAttackData.hurtType;
			for (int i = 0; i < entityCount; i++)
			{
				BeEntity entityAt = this.currentBeScene.GetEntityAt(i);
				if (entityAt != null)
				{
					if (entityAt.stateController.IsChaosState())
					{
						hitType = 0;
					}
					else if (this.CheckCanAttackFriend(entityAt))
					{
						hitType = 2;
					}
					else
					{
						hitType = cpkCurEntityActionFrameData.pAttackData.hurtType;
					}
					if ((this._betrayCanAttack(entityAt) || this._canAttackedEntity(entityAt, hitType) || this._canAttackedEntity2(entityAt)) && !this._checkEntityHurted(entityAt) && DBoxConfig.b2D)
					{
						BDDBoxData pAttackData = cpkCurEntityActionFrameData.pAttackData;
						int[] array = this.temp_array_1;
						array[0] = GlobalLogic.VALUE_1000;
						if (this.m_cpkCurEntityActionInfo != null)
						{
							this.temp_event[0] = this.m_cpkCurEntityActionInfo.skillID;
							this.temp_event[1] = array;
							this.TriggerEvent(BeEventType.onChangeAttackZDim, this.temp_event);
						}
						int num = pAttackData.zDimInt.i * (Global.Settings.zDimFactor * this.m_fZdimScaleFactor) * VFactor.NewVFactor(array[0], GlobalLogic.VALUE_1000);
						int enhanceRadius = entityAt.GetEnhanceRadius();
						bool flag;
						if (enhanceRadius != 0)
						{
							int num2 = entityAt.GetPosition().y - enhanceRadius - num;
							int num3 = entityAt.GetPosition().y + enhanceRadius + num;
							flag = (this.GetPosition().y >= num2 && this.GetPosition().y <= num3);
						}
						else
						{
							int num4 = entityAt.GetPosition().y - this.GetPosition().y;
							flag = (num4 >= -num && num4 <= num);
						}
						if (flag)
						{
							BDEntityActionFrameData cpkCurEntityActionFrameData2 = entityAt.m_cpkCurEntityActionFrameData;
							if (cpkCurEntityActionFrameData2 != null && cpkCurEntityActionFrameData2.pDefenseData != null)
							{
								BDDBoxData pDefenseData = cpkCurEntityActionFrameData2.pDefenseData;
								int count = pAttackData.vBox.Count;
								int count2 = pDefenseData.vBox.Count;
								if (BeEntity.CheckIntersectEx(this.m_vkCurWorldAttackBox, count, entityAt.m_vkCurWorldDefenseBox, count2, ref rkBox))
								{
									VInt3 hitPos = this.GetHitPos(rkBox, entityAt);
									VInt3[] array2 = this.temp_vint3_1;
									array2[0] = hitPos;
									this.temp_event_1[0] = array2;
									entityAt.TriggerEvent(BeEventType.onChangeBeHitEffectPos, this.temp_event_1);
									this._onHurtEntity(entityAt, array2[0], cpkCurEntityActionFrameData.pAttackData.hurtID);
								}
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06016EF0 RID: 93936 RVA: 0x006EF0B4 File Offset: 0x006ED4B4
	public virtual void _updateGraphicActor(bool force = false)
	{
		if (this.m_pkGeActor != null && (this.m_bGraphicPositionDirty || force))
		{
			Vector3 vector = this.GetPosition().vector3;
			this.m_pkGeActor.SetPosition(vector);
			if (!this.dontSetFace)
			{
				this.m_pkGeActor.SetFaceLeft(this.GetFace());
			}
			this.m_pkGeActor.SetFootIndicatorTouchGround(vector.y);
			this.m_pkGeActor.SetScale(this.m_fScale.scalar);
			this.m_bGraphicPositionDirty = false;
		}
	}

	// Token: 0x06016EF1 RID: 93937 RVA: 0x006EF148 File Offset: 0x006ED548
	public virtual void _clearStates()
	{
		this.moveXAcc = 0;
		this.moveYAcc = 0;
		this.m_bCmdDirty = true;
		this.m_vHurtEntity.Clear();
	}

	// Token: 0x06016EF2 RID: 93938 RVA: 0x006EF174 File Offset: 0x006ED574
	public void ResetCmdDirty()
	{
		this.m_bCmdDirty = true;
	}

	// Token: 0x06016EF3 RID: 93939 RVA: 0x006EF17D File Offset: 0x006ED57D
	public void ResetWeight()
	{
		if (this.GetEntityData() != null)
		{
			this.SetMoveSpeedZAcc(this.GetEntityData().weight);
		}
	}

	// Token: 0x06016EF4 RID: 93940 RVA: 0x006EF19C File Offset: 0x006ED59C
	public void RestoreWeight()
	{
		BeEntityData entityData = this.GetEntityData();
		if (entityData != null && entityData.backupWeight > 0)
		{
			this.SetMoveSpeedZAcc(entityData.backupWeight);
			entityData.backupWeight = 0;
		}
	}

	// Token: 0x06016EF5 RID: 93941 RVA: 0x006EF1E0 File Offset: 0x006ED5E0
	public void SetStandardWeight()
	{
		BeEntityData entityData = this.GetEntityData();
		if (entityData != null)
		{
			entityData.backupWeight = this.moveZAcc;
			this.SetMoveSpeedZAcc((VInt)Global.Settings.gravity);
		}
	}

	// Token: 0x06016EF6 RID: 93942 RVA: 0x006EF21C File Offset: 0x006ED61C
	public BDEntityActionInfo GetSkillActionInfo(int skillid)
	{
		if (this.m_pkGeActor == null)
		{
			return null;
		}
		string skillDataNameByID = this.GetSkillDataNameByID(skillid);
		BDEntityActionInfo result = null;
		if (skillDataNameByID != null)
		{
			result = this.m_cpkEntityInfo._vkActionsMap[skillDataNameByID];
		}
		return result;
	}

	// Token: 0x06016EF7 RID: 93943 RVA: 0x006EF259 File Offset: 0x006ED659
	public virtual void _onReset()
	{
	}

	// Token: 0x06016EF8 RID: 93944 RVA: 0x006EF25C File Offset: 0x006ED65C
	public virtual bool _canAttackedEntity(BeEntity pkEntity, int hitType = 1)
	{
		return this.CheckCondition(pkEntity) && (hitType != 1 || pkEntity.m_iCamp != this.m_iCamp) && (hitType != 2 || pkEntity.m_iCamp == this.m_iCamp);
	}

	// Token: 0x06016EF9 RID: 93945 RVA: 0x006EF2AC File Offset: 0x006ED6AC
	protected virtual bool _canAttackedEntity2(BeEntity pkEntity)
	{
		return this.CheckCondition(pkEntity) && (!(this is BeProjectile) || this.owner != pkEntity) && this.owner.stateController != null && pkEntity.stateController != null && this.owner.stateController != null && pkEntity.stateController != null && !this.IsSummonMonster() && !this.owner.IsSummonMonster() && (pkEntity.GetCamp() == this.GetCamp() && (this.stateController.CanAttackFriendAndEnemy2() || this.owner.stateController.CanAttackFriendAndEnemy2()));
	}

	// Token: 0x06016EFA RID: 93946 RVA: 0x006EF370 File Offset: 0x006ED770
	private bool _betrayCanAttack(BeEntity pkEntity)
	{
		return this.CheckCondition(pkEntity) && (!(this is BeProjectile) || this.owner != pkEntity) && this.owner.stateController != null && pkEntity.stateController != null && !this.IsSummonMonster() && !this.owner.IsSummonMonster() && this.CanAttackFriendAndEnemy(pkEntity);
	}

	// Token: 0x06016EFB RID: 93947 RVA: 0x006EF3ED File Offset: 0x006ED7ED
	protected virtual bool CanAttackFriendAndEnemy(BeEntity pkEntity)
	{
		return this.owner.stateController.CanAttackFriendAndEnemy() || pkEntity.stateController.CanAttackFriendAndEnemy();
	}

	// Token: 0x06016EFC RID: 93948 RVA: 0x006EF414 File Offset: 0x006ED814
	private bool CheckCondition(BeEntity pkEntity)
	{
		return pkEntity != null && pkEntity.m_bCanBeAttacked && pkEntity != this && pkEntity.sgGetCurrentState() != 16 && pkEntity.m_cpkCurEntityActionFrameData != null && pkEntity.m_cpkCurEntityActionFrameData.pDefenseData != null && pkEntity.stateController.CanBeHit();
	}

	// Token: 0x06016EFD RID: 93949 RVA: 0x006EF480 File Offset: 0x006ED880
	public bool _checkEntityHurted(BeEntity pkEntity)
	{
		for (int i = 0; i < this.m_vHurtEntity.Count; i++)
		{
			if (this.m_vHurtEntity[i] == pkEntity)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06016EFE RID: 93950 RVA: 0x006EF4C0 File Offset: 0x006ED8C0
	public VInt3 GetHitPos(DBox rkBox, BeEntity pkEntity)
	{
		VInt3 result = default(VInt3);
		VInt2 center = rkBox.getCenter();
		if (pkEntity != null)
		{
			int z = pkEntity.GetPosition().z;
		}
		if (DBoxConfig.b2D)
		{
			float f = (center.fy - pkEntity.GetPosition().fy * DBoxConfig.fSinA.single) / DBoxConfig.fCosA.single;
			result = new VInt3(center.x, pkEntity.GetPosition().y, ((VInt)f).i);
		}
		return result;
	}

	// Token: 0x06016EFF RID: 93951 RVA: 0x006EF568 File Offset: 0x006ED968
	public virtual bool OnDamage()
	{
		return false;
	}

	// Token: 0x06016F00 RID: 93952 RVA: 0x006EF56B File Offset: 0x006ED96B
	public virtual void ShowMissEffect(Vec3 Pos)
	{
	}

	// Token: 0x06016F01 RID: 93953 RVA: 0x006EF570 File Offset: 0x006ED970
	public virtual void ShowHitEffect(Vec3 Pos, BeEntity target, int hurtID)
	{
		EffectsFrames dummy_HIT_EFF_FRAME = this.DUMMY_HIT_EFF_FRAME;
		dummy_HIT_EFF_FRAME.localPosition = new Vector3(0f, 0f, 0f);
		string text;
		if (this.m_cpkCurEntityActionInfo.hitEffectAsset.IsValid())
		{
			text = this.m_cpkCurEntityActionInfo.hitEffectAsset.m_AssetPath;
		}
		else if (Utility.IsStringValid(this.hitEffect))
		{
			text = this.hitEffect;
		}
		else
		{
			text = Global.Settings.defaultHitEffect;
		}
		string[] array = new string[]
		{
			text
		};
		this.TriggerEvent(BeEventType.onChangeHitEffect, new object[]
		{
			hurtID,
			array
		});
		text = array[0];
		if (text != null)
		{
			int num = 0;
			if (this.m_cpkCurEntityActionInfo != null)
			{
				num = this.m_cpkCurEntityActionInfo.hitEffectInfoTableId;
			}
			GeEffectEx geEffectEx;
			if (num == 0)
			{
				geEffectEx = this.CurrentBeScene.currentGeScene.CreateEffect(text, 0f, Pos, 1f, 1f, false, this.GetFace());
			}
			else
			{
				this.DUMMY_INFO_EFFECT.ChangeEffectFrames(ref dummy_HIT_EFF_FRAME, num);
				geEffectEx = this.CurrentBeScene.currentGeScene.CreateEffect(new DAssetObject
				{
					m_AssetPath = text
				}, dummy_HIT_EFF_FRAME, 0f, Pos, 1f, 1f, false, this.GetFace());
			}
			if (target != null && geEffectEx != null)
			{
				target.currentHitEffectNum++;
				int ms = Math.Max((int)geEffectEx.GetTimeLen(), GlobalLogic.VALUE_100);
				target.delayCaller.DelayCall(ms, delegate
				{
					target.currentHitEffectNum--;
				}, 0, 0, false);
			}
		}
	}

	// Token: 0x06016F02 RID: 93954 RVA: 0x006EF72C File Offset: 0x006EDB2C
	public void ShowHit(BeEntity pkEntity, Vec3 hitPos, int hurtID = 0)
	{
		if (this.m_cpkCurEntityActionInfo != null)
		{
			if (pkEntity == null || pkEntity.currentHitEffectNum < pkEntity.totalHitEffectNum)
			{
				this.ShowMagicElementsHitEffect(hitPos, pkEntity, hurtID);
				this.ShowHitEffect(hitPos, pkEntity, hurtID);
			}
		}
		if (Utility.IsStringValid(pkEntity.beHitEffect))
		{
			this.currentBeScene.currentGeScene.CreateEffect(pkEntity.beHitEffect, 0f, hitPos, 1f, 1f, false, this.GetFace());
		}
		this.PlayHitSfx(pkEntity, hurtID);
	}

	// Token: 0x06016F03 RID: 93955 RVA: 0x006EF7BC File Offset: 0x006EDBBC
	private bool ShowMagicElementsHitEffect(Vec3 hitPos, BeEntity target, int hurtID = 0)
	{
		if (target == null)
		{
			return false;
		}
		int num = 0;
		EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(hurtID, string.Empty, string.Empty);
		if (tableItem != null)
		{
			num = tableItem.MagicElementType;
		}
		int[] array = new int[]
		{
			num,
			hurtID
		};
		this.owner.TriggerEvent(BeEventType.onChangeMagicElement, new object[]
		{
			array
		});
		num = array[0];
		int count = Global.magicElementsEffectMap.Count;
		int num2 = 1;
		for (int i = 1; i < 5; i++)
		{
			if (tableItem == null || tableItem.MagicElementISuse || i == num)
			{
				if (this.attribute.HasMagicElementType(i) || i == num)
				{
					if (i <= count)
					{
						string text = Global.magicElementsEffectMap[i - 1];
						if (Utility.IsStringValid(text))
						{
							EffectsFrames dummy_HIT_EFF_FRAME = this.DUMMY_HIT_EFF_FRAME;
							dummy_HIT_EFF_FRAME.localPosition = new Vector3(0f, 0f, 0f);
							DAssetObject effectRes;
							effectRes.m_AssetObj = null;
							effectRes.m_AssetPath = text;
							int num3 = 0;
							if (this.m_cpkCurEntityActionInfo != null)
							{
								num3 = this.m_cpkCurEntityActionInfo.hitEffectInfoTableId;
							}
							GeEffectEx geEffectEx;
							if (num3 == 0)
							{
								geEffectEx = this.CurrentBeScene.currentGeScene.CreateEffect(effectRes, dummy_HIT_EFF_FRAME, 0f, hitPos, 1f, 1f, false, this.GetFace());
							}
							else
							{
								this.DUMMY_INFO_EFFECT.ChangeEffectFrames(ref dummy_HIT_EFF_FRAME, num3);
								geEffectEx = this.CurrentBeScene.currentGeScene.CreateEffect(effectRes, dummy_HIT_EFF_FRAME, 0f, hitPos, 1f, 1f, false, this.GetFace());
							}
							if (geEffectEx != null)
							{
								target.currentHitEffectNum++;
								int ms = Math.Max((int)geEffectEx.GetTimeLen(), GlobalLogic.VALUE_100);
								target.delayCaller.DelayCall(ms, delegate
								{
									if (target != null)
									{
										target.currentHitEffectNum--;
									}
								}, 0, 0, false);
							}
							num2++;
						}
					}
				}
			}
		}
		return true;
	}

	// Token: 0x06016F04 RID: 93956 RVA: 0x006EF9E4 File Offset: 0x006EDDE4
	public void DealHit(int hurtid, BeEntity pkEntity, VInt3 hitPos, EffectTable hurtData, int skillLevel, bool isBackHit)
	{
		this.ShowHit(pkEntity, hitPos.vec3, hurtid);
		if (pkEntity.stateController.HasBuffState(BeBuffStateType.BLOCK))
		{
			BeActor beActor = pkEntity as BeActor;
			if (!isBackHit)
			{
				int[] array = new int[2];
				int num = (!pkEntity.GetFace()) ? (-1 * VInt.Float2VIntValue(Global.Settings.degangBackDistance)) : 1;
				int num2 = GlobalLogic.VALUE_100;
				array[0] = num2;
				array[1] = num;
				pkEntity.TriggerEvent(BeEventType.BlockSuccess, new object[]
				{
					array
				});
				num2 = array[0];
				num = array[1];
				pkEntity.actionManager.StopAll();
				pkEntity.actionManager.RunAction(BeMoveBy.Create(pkEntity, num2, pkEntity.GetPosition(), new VInt3(num, 0, 0), false, null, true));
				this.currentBeScene.currentGeScene.CreateEffect("Effects/Common/Sfx/Hit/Prefab/Eff_hit_miss", 0f, hitPos.vec3, 1f, 1f, false, this.GetFace());
				MonoSingleton<AudioManager>.instance.PlaySound(2022);
			}
		}
		if (pkEntity != null && this.currentBeScene.currentGeScene != null)
		{
			BeActor beActor2 = this as BeActor;
			if (beActor2 != null && beActor2.isLocalActor)
			{
				int[] array2 = new int[]
				{
					hurtData.ScreenShakeID
				};
				beActor2.TriggerEvent(BeEventType.onChangeScreenShakeID, new object[]
				{
					hurtid,
					array2
				});
				int num3 = array2[0];
				if (num3 > 0 && this.currentBeScene.currentGeScene.GetCamera().shockTime <= 0)
				{
					ScreenShakeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ScreenShakeTable>(num3, string.Empty, string.Empty);
					if (tableItem != null)
					{
						this.currentBeScene.currentGeScene.GetCamera().shockTime = tableItem.CDTime;
						this.currentBeScene.currentGeScene.GetCamera().PlayShockEffect((float)tableItem.TotalTime / 1000f, tableItem.Num, (float)tableItem.Xrange / 1000f, (float)tableItem.Yrange / 1000f, tableItem.Decelerate == 1, (float)tableItem.Xreduce / 1000f, (float)tableItem.Yreduce / 1000f, tableItem.Mode, (float)tableItem.Radius / 1000f, this.IsCurSkillOpenShock());
					}
				}
				else if (hurtData.HitScreenShakeTime > 0)
				{
					this.currentBeScene.currentGeScene.GetCamera().PlayShockEffect((float)hurtData.HitScreenShakeTime / 1000f, (float)hurtData.HitScreenShakeSpeed, (float)hurtData.HitScreenShakeX / 1000f, (float)hurtData.HitScreenShakeY / 1000f, 2, this.IsCurSkillOpenShock());
				}
			}
			else if (this is BeProjectile)
			{
				BeProjectile beProjectile = this as BeProjectile;
				BeActor beActor3 = beProjectile.owner as BeActor;
				if (beActor3 != null && beActor3.isLocalActor)
				{
					int[] array3 = new int[]
					{
						hurtData.ScreenShakeID
					};
					beActor3.TriggerEvent(BeEventType.onChangeScreenShakeID, new object[]
					{
						hurtid,
						array3
					});
					int num4 = array3[0];
					if (hurtData.ScreenShakeID > 0 && this.currentBeScene.currentGeScene.GetCamera().shockTime <= 0)
					{
						ScreenShakeTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ScreenShakeTable>(hurtData.ScreenShakeID, string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							this.currentBeScene.currentGeScene.GetCamera().shockTime = tableItem2.CDTime;
							this.currentBeScene.currentGeScene.GetCamera().PlayShockEffect((float)tableItem2.TotalTime / 1000f, tableItem2.Num, (float)tableItem2.Xrange / 1000f, (float)tableItem2.Yrange / 1000f, tableItem2.Decelerate == 1, (float)tableItem2.Xreduce / 1000f, (float)tableItem2.Yreduce / 1000f, tableItem2.Mode, (float)tableItem2.Radius / 1000f, beActor3.IsCurSkillOpenShock());
						}
					}
				}
			}
		}
		if (pkEntity != null && pkEntity.needHitShader && pkEntity.m_pkGeActor != null && !pkEntity.IsDead())
		{
			pkEntity.delayCaller.DelayCall(50, delegate
			{
				if (pkEntity != null && pkEntity.m_pkGeActor != null && !pkEntity.IsDead())
				{
					pkEntity.m_pkGeActor.ChangeSurface("受击", Global.Settings.hitTime, true, true);
				}
			}, 0, 0, false);
		}
		if (hurtData != null && hurtData.ClearTargetState.Count > 0 && hurtData.ClearTargetState[0] > 0)
		{
			for (int i = 0; i < hurtData.ClearTargetState.Count; i++)
			{
				pkEntity.SetTag(hurtData.ClearTargetState[i], false);
			}
		}
		if (this.CheckBeHitCondition(pkEntity, hurtData))
		{
			if (!this.needHitShader && pkEntity != null && pkEntity.m_pkGeActor != null)
			{
				pkEntity.delayCaller.DelayCall(50, delegate
				{
					if (pkEntity != null && pkEntity.m_pkGeActor != null && !pkEntity.IsDead())
					{
						BuffTable tableItem5 = Singleton<TableManager>.GetInstance().GetTableItem<BuffTable>(hurtData.BuffID, string.Empty, string.Empty);
						if (tableItem5 != null && Utility.IsStringValid(tableItem5.EffectShaderName))
						{
							return;
						}
						pkEntity.m_pkGeActor.ChangeSurface("受击", Global.Settings.hitTime, true, true);
					}
				}, 0, 0, false);
			}
			if (hurtData.HitEffect == EffectTable.eHitEffect.NO_EFFECT && (hurtData.HitDeadFall <= 0 || !pkEntity.IsDead()))
			{
				return;
			}
			bool[] array4 = new bool[1];
			this.owner.TriggerEvent(BeEventType.onHitEffect, new object[]
			{
				array4,
				hurtid,
				hurtData,
				pkEntity
			});
			if (array4[0])
			{
				return;
			}
			bool flag = !this.GetFace();
			if (hurtData.HitSpreadOut == 1)
			{
				VInt3 vint = VInt3.zero;
				if (this is BeProjectile)
				{
					vint = this.owner.GetPosition();
				}
				else
				{
					vint = this.GetPosition();
				}
				flag = (pkEntity.GetPosition().x > vint.x);
			}
			if (!pkEntity.GetStateGraph().CurrentStateHasTag(1) && (hurtData.HitDeadFall <= 0 || !pkEntity.IsDead()))
			{
				pkEntity.SetFace(flag, false, false);
			}
			int valueFromUnionCell;
			int valueFromUnionCell2;
			if (BattleMain.IsChijiNeedReplaceHurtId(hurtid, this.battleType))
			{
				ChijiEffectMapTable tableItem3 = Singleton<TableManager>.instance.GetTableItem<ChijiEffectMapTable>(hurtid, string.Empty, string.Empty);
				valueFromUnionCell = TableManager.GetValueFromUnionCell(tableItem3.Attack, skillLevel, true);
				valueFromUnionCell2 = TableManager.GetValueFromUnionCell(tableItem3.FloatingRate, skillLevel, true);
			}
			else
			{
				valueFromUnionCell = TableManager.GetValueFromUnionCell(hurtData.Attack, skillLevel, true);
				valueFromUnionCell2 = TableManager.GetValueFromUnionCell(hurtData.FloatingRate, skillLevel, true);
			}
			VFactor a = new VFactor((long)valueFromUnionCell, (long)(GlobalLogic.VALUE_1000 * ((!flag) ? -1 : 1)));
			VFactor a2 = new VFactor((long)valueFromUnionCell2, (long)GlobalLogic.VALUE_1000);
			int[] array5 = new int[]
			{
				(int)a.nom,
				GlobalLogic.VALUE_1000
			};
			pkEntity.TriggerEvent(BeEventType.onChangeXRate, new object[]
			{
				hurtData.ID,
				array5
			});
			if (this != null)
			{
				this.ChangeXForce(array5, pkEntity, this, flag);
			}
			int num5 = array5[0] * VFactor.NewVFactor(array5[1], GlobalLogic.VALUE_1000);
			a = VFactor.NewVFactor((long)num5, a.den);
			int[] array6 = new int[]
			{
				(int)a2.nom,
				GlobalLogic.VALUE_1000
			};
			pkEntity.TriggerEvent(BeEventType.onChangeFloatingRate, new object[]
			{
				hurtData.ID,
				array6
			});
			int num6 = array6[0] * VFactor.NewVFactor(array6[1], GlobalLogic.VALUE_1000);
			a2 = VFactor.NewVFactor((long)num6, a2.den);
			ActionState actionState = ActionState.AS_HURT;
			if (hurtData.HitEffect == EffectTable.eHitEffect.HITFLY)
			{
				actionState = ActionState.AS_FALL;
			}
			if (pkEntity.HasTag(1) && !pkEntity.HasTag(4))
			{
				int num7 = TableManager.GetValueFromUnionCell(hurtData.HitFloatYForce, skillLevel, true);
				int[] array7 = new int[]
				{
					num7,
					GlobalLogic.VALUE_1000
				};
				pkEntity.TriggerEvent(BeEventType.onChangeFloatYForce, new object[]
				{
					hurtData.ID,
					array7
				});
				num7 = array7[0] * VFactor.NewVFactor(array7[1], GlobalLogic.VALUE_1000);
				if (num7 > 0)
				{
					a2 = new VFactor((long)num7, (long)GlobalLogic.VALUE_1000);
				}
				int num8;
				if (BattleMain.IsChijiNeedReplaceHurtId(hurtid, this.battleType))
				{
					ChijiEffectMapTable tableItem4 = Singleton<TableManager>.instance.GetTableItem<ChijiEffectMapTable>(hurtid, string.Empty, string.Empty);
					num8 = TableManager.GetValueFromUnionCell(tableItem4.HitFloatXForce, skillLevel, true);
				}
				else
				{
					num8 = TableManager.GetValueFromUnionCell(hurtData.HitFloatXForce, skillLevel, true);
				}
				int[] array8 = new int[]
				{
					num8,
					GlobalLogic.VALUE_1000
				};
				pkEntity.TriggerEvent(BeEventType.onChangeFloatXForce, new object[]
				{
					hurtData.ID,
					array8
				});
				if (this != null)
				{
					this.ChangeXForce(array8, pkEntity, this, flag);
				}
				num8 = array8[0] * VFactor.NewVFactor(array8[1], GlobalLogic.VALUE_1000);
				a = new VFactor((long)num8, (long)GlobalLogic.VALUE_1000) * (long)this._getFaceCoff();
				actionState = ActionState.AS_FALL;
			}
			if (actionState != ActionState.AS_FALL && pkEntity.GetPosition().z > VInt.Float2VIntValue(0.1f) && !pkEntity.isFloating)
			{
				actionState = ActionState.AS_FALL;
				a = VFactor.one;
				a2 = VFactor.NewVFactorF(0.1f, GlobalLogic.VALUE_1000);
			}
			bool flag2 = false;
			if (hurtData.UseStandardWeight)
			{
				flag2 = true;
				pkEntity.SetStandardWeight();
				if (pkEntity.HasTag(4))
				{
					a *= 2L;
					a2 *= 2L;
				}
			}
			if (hurtData.UseNoBlock && pkEntity.stateController.HasAbility(BeAbilityType.BLOCK))
			{
				pkEntity.changeToNoBlock = true;
				pkEntity.stateController.SetAbilityEnable(BeAbilityType.BLOCK, false);
			}
			int num9 = this.attribute.GetHurtFrozenTime(pkEntity.GetEntityData(), hurtid);
			num9 = Mathf.Clamp(num9, Singleton<TableManager>.instance.gst.hurtTime[0], Singleton<TableManager>.instance.gst.hurtTime[1]);
			pkEntity.FrozenDisMax = this.attribute.GetFrozenDisMax(hurtid);
			if (actionState == ActionState.AS_FALL && !pkEntity.stateController.CanBeFloat())
			{
				actionState = ActionState.AS_HURT;
			}
			if (!pkEntity.stateController.CanBeFloat())
			{
				a = VFactor.zero;
				a2 = VFactor.zero;
			}
			if (actionState == ActionState.AS_HURT)
			{
				a2 = VFactor.zero;
			}
			if (hurtData.HitDeadFall > 0 && pkEntity.IsDead() && actionState == ActionState.AS_HURT)
			{
				actionState = ActionState.AS_FALL;
				a = ((pkEntity.GetPosition().x - this.GetPosition().x <= 0) ? VFactor.NewVFactorF(-3f, GlobalLogic.VALUE_1000) : VFactor.NewVFactorF(3f, GlobalLogic.VALUE_1000));
				a2 = VFactor.NewVFactorF(5f, 1000);
				if (pkEntity.aiManager != null)
				{
					pkEntity.aiManager.Stop();
				}
			}
			if (this.JudgeChangeForceXByStrain(pkEntity))
			{
				a = VFactor.zero;
			}
			pkEntity.Locomote(new BeStateData((int)actionState, (!flag2) ? 0 : 1, a.vint.i, a2.vint.i, 0, num9, true), false);
		}
		else if (pkEntity.IsDead())
		{
			if (pkEntity.GetPosition().z > 0)
			{
				VInt3 position = pkEntity.GetPosition();
				position.z = 0;
				pkEntity.SetMoveSpeedZ(VInt.zero);
				pkEntity.SetStandPosition(position, true);
			}
			pkEntity.DoDead(false);
		}
		if (hurtData.HitEffect != EffectTable.eHitEffect.NO_EFFECT)
		{
			this.OnDealHit(pkEntity);
		}
	}

	// Token: 0x06016F05 RID: 93957 RVA: 0x006F076C File Offset: 0x006EEB6C
	private bool CheckBeHitCondition(BeEntity pkEntity, EffectTable hurtData)
	{
		if (pkEntity.m_iCamp == this.m_iCamp)
		{
			return false;
		}
		if (pkEntity.stateController.HasBuffState(BeBuffStateType.FROZEN))
		{
			return false;
		}
		if (pkEntity.stateController.HasBuffState(BeBuffStateType.STONE))
		{
			return false;
		}
		if (!pkEntity.stateController.CanBeForceBreakAction())
		{
			return false;
		}
		if (!pkEntity.stateController.CanBeBreakAction() && !hurtData.UseStandardWeight)
		{
			return false;
		}
		BeActor beActor = (BeActor)pkEntity;
		return beActor == null || beActor.protectManager == null || !beActor.protectManager.IsEnterHardProtect() || hurtData.HitEffect != EffectTable.eHitEffect.HIT;
	}

	// Token: 0x06016F06 RID: 93958 RVA: 0x006F081F File Offset: 0x006EEC1F
	private bool JudgeChangeForceXByStrain(BeEntity entity)
	{
		return BeClientSwitch.FunctionIsOpen(ClientSwitchType.Strain) && entity.stateController.HasBuffState(BeBuffStateType.STRAIN);
	}

	// Token: 0x06016F07 RID: 93959 RVA: 0x006F0847 File Offset: 0x006EEC47
	public virtual void OnDealHit(BeEntity pkEntity)
	{
	}

	// Token: 0x06016F08 RID: 93960 RVA: 0x006F084C File Offset: 0x006EEC4C
	public virtual void _onHurtEntity(BeEntity pkEntity, VInt3 hitPos, int hurtid = 0)
	{
		if (pkEntity == null)
		{
			return;
		}
		if (!pkEntity.stateController.CanBeHit())
		{
			return;
		}
		int finalDamage = 0;
		EffectTable hurtData = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(hurtid, string.Empty, string.Empty);
		if (hurtData == null)
		{
			if (this.m_cpkCurEntityActionInfo != null)
			{
			}
			return;
		}
		if (hurtData.HitGrab && !pkEntity.IsGrabed())
		{
			return;
		}
		this.m_vHurtEntity.Add(pkEntity);
		if (this.owner.CurrentBeScene != null)
		{
			EventParam eventParam = this.owner.CurrentBeScene.TriggerEventNew(BeEventSceneType.onHurtEntity, new EventParam
			{
				m_Int = hurtid,
				m_Vint3 = hitPos,
				m_Obj = this,
				m_Obj2 = pkEntity,
				m_Obj3 = hurtData
			});
			if (eventParam.m_Int <= 0)
			{
				return;
			}
			hurtid = eventParam.m_Int;
			hurtData = (eventParam.m_Obj3 as EffectTable);
		}
		int skillLevel = 1;
		BeActor beActor = this as BeActor;
		if (beActor == null)
		{
			beActor = (this.GetTopOwner(this.owner) as BeActor);
		}
		if (beActor != null && beActor.buffController != null)
		{
			if (hurtData.DamageType == EffectTable.eDamageType.MAGIC)
			{
				beActor.buffController.TriggerBuffs(BuffCondition.MAGIC_ATTACK, pkEntity as BeActor, null);
			}
			else if (hurtData.DamageType == EffectTable.eDamageType.PHYSIC)
			{
				beActor.buffController.TriggerBuffs(BuffCondition.PHYSIC_ATTACK, pkEntity as BeActor, null);
			}
		}
		if (pkEntity.OnDamage())
		{
			this.onHitEntity(pkEntity, VInt3.zero, 0, AttackResult.MISS, 0);
			pkEntity.m_pkGeActor.ChangeSurface("受击", Global.Settings.hitTime, true, true);
			this.ShowHit(pkEntity, hitPos.vec3, hurtid);
			return;
		}
		if (hurtData.HasDamage == 0)
		{
			this.onHitEntity(pkEntity, VInt3.zero, 0, AttackResult.MISS, 0);
			return;
		}
		this.DealRepeatHurt(hurtData);
		bool isBackHit = false;
		if (pkEntity.stateController.HasAbility(BeAbilityType.CAN_HIT_BACK))
		{
			VInt b = (VInt)0.2f;
			if (hurtData != null && hurtData.IsFriendDamage == 0 && ((pkEntity.GetFace() && hitPos.x > pkEntity.GetPosition().x + b) || (!pkEntity.GetFace() && hitPos.x <= pkEntity.GetPosition().x - b)))
			{
				isBackHit = true;
			}
		}
		bool flag = false;
		int reflectDamage = 0;
		AttackResult attackResult = this.DoAttackTo(pkEntity, hurtid, ref flag, ref reflectDamage, ref finalDamage, hitPos, true, isBackHit, true, false);
		if (attackResult == AttackResult.IGNORE)
		{
			return;
		}
		if (attackResult != AttackResult.MISS)
		{
			this.OnAttachHurt(pkEntity, hurtData);
		}
		BeEntityData entityData = this.GetEntityData();
		if (entityData != null)
		{
			skillLevel = entityData.GetSkillLevel(hurtData.SkillID);
		}
		if (attackResult != AttackResult.MISS && pkEntity.stateController.CanBeHit())
		{
			this.TriggerEvent(BeEventType.onHitCritical, new object[]
			{
				hitPos
			});
			this.DealHit(hurtid, pkEntity, hitPos, hurtData, skillLevel, isBackHit);
			if (flag)
			{
				this.DoReflectHurt(reflectDamage, pkEntity);
			}
			if (hurtData.HitPause)
			{
				this.delayCaller.DelayCall(30, delegate
				{
					int hitPauseTime = hurtData.HitPauseTime;
					bool hitEffectPause = !hurtData.HitEffectPause;
					this.Pause(hitPauseTime, hitEffectPause);
					BeActor beActor2 = pkEntity as BeActor;
					if (beActor2 != null)
					{
						if (!beActor2.buffController.HaveBatiNoPauseBuff())
						{
							pkEntity.Pause(hitPauseTime, hitEffectPause);
						}
					}
					else
					{
						pkEntity.Pause(hitPauseTime, hitEffectPause);
					}
				}, 0, 0, false);
			}
		}
		else
		{
			this.ShowMissEffect(hitPos.vec3);
		}
		this.onHitEntity(pkEntity, hitPos, hurtid, attackResult, finalDamage);
	}

	// Token: 0x06016F09 RID: 93961 RVA: 0x006F0C80 File Offset: 0x006EF080
	public void DoReflectHurt(int reflectDamage, BeEntity pkEntity)
	{
		if (this.attribute != null)
		{
			int hp = this.attribute.GetHP();
			this.DoHurt(reflectDamage, null, HitTextType.NORMAL, pkEntity, HitTextType.NORMAL, false);
			int hp2 = this.attribute.GetHP();
			int num = hp - hp2;
			if (this is BeProjectile && this.owner != null)
			{
				this.owner.TriggerEvent(BeEventType.onHurt, new object[]
				{
					num,
					pkEntity
				});
			}
		}
		VInt3 position = this.GetPosition();
		position.z += VInt.Float2VIntValue(1f);
		this.ShowHit(pkEntity, position.vec3, 0);
		bool flag = false;
		BeActor beActor = this as BeActor;
		if (beActor != null && beActor.protectManager != null && beActor.protectManager.IsEnterHardProtect())
		{
			flag = true;
		}
		if (this.stateController.CanBeBreakAction() && !flag)
		{
			this.Locomote(new BeStateData(4, 0, 0, 0, 0, GlobalLogic.VALUE_150, true), false);
		}
	}

	// Token: 0x06016F0A RID: 93962 RVA: 0x006F0D84 File Offset: 0x006EF184
	public void DealRepeatHurt(EffectTable hurtData)
	{
		if (hurtData == null)
		{
			return;
		}
		if (hurtData.RepeatAttackInterval[0] == 0)
		{
			return;
		}
		if (this.delayCallUnitHurtIdList.Contains(hurtData.ID))
		{
			return;
		}
		int skillLevel = this.GetEntityData().GetSkillLevel(hurtData.SkillID);
		int[] array = new int[]
		{
			GlobalLogic.VALUE_1000,
			0
		};
		this.owner.TriggerEvent(BeEventType.onRepeatAttackInterval, new object[]
		{
			array,
			hurtData.ID
		});
		array[0] = hurtData.RepeatAttackInterval[0] * VFactor.NewVFactor(array[0], GlobalLogic.VALUE_1000);
		int num = 9999999;
		if (hurtData.RepeatAttackInterval.Count > 1)
		{
			num = hurtData.RepeatAttackInterval[1] + array[1] - 2;
		}
		if (num < 0)
		{
			return;
		}
		DelayCallUnitHandle item = this.delayCaller.RepeatCall(array[0], delegate
		{
			this.ResetDamageData();
		}, num, false);
		this.delayCallUnitHurtIdList.Add(hurtData.ID);
		this.delayCallUnitList.Add(item);
	}

	// Token: 0x06016F0B RID: 93963 RVA: 0x006F0E9B File Offset: 0x006EF29B
	public virtual void onHitEntity(BeEntity pkEntity, VInt3 pos, int hurtID = 0, AttackResult result = AttackResult.MISS, int finalDamage = 0)
	{
	}

	// Token: 0x06016F0C RID: 93964 RVA: 0x006F0EA0 File Offset: 0x006EF2A0
	public void PlayHitSfx(BeEntity target, int hurtID = 0)
	{
		if (target != null && target.currentHitSFXNum >= target.totalHitSFXNum)
		{
			return;
		}
		int num = 0;
		bool flag = false;
		EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(hurtID, string.Empty, string.Empty);
		if (tableItem != null)
		{
			num = tableItem.MagicElementType;
			flag = tableItem.MagicElementISuse;
		}
		int[] array = new int[]
		{
			num,
			hurtID
		};
		this.owner.TriggerEvent(BeEventType.onChangeMagicElement, new object[]
		{
			array
		});
		num = array[0];
		int count = Global.magicElementsSoundMap.Count;
		int num2 = 1;
		for (int i = 1; i < 5; i++)
		{
			if (flag || i == num)
			{
				if (this.attribute.HasMagicElementType(i) || i == num)
				{
					if (i <= count)
					{
						int soundID = Global.magicElementsSoundMap[i - 1];
						uint num3 = MonoSingleton<AudioManager>.instance.PlaySound(soundID);
						if (num3 > 0U)
						{
							target.currentHitSFXNum++;
							int audioLength = MonoSingleton<AudioManager>.instance.GetAudioLength(num3);
							target.delayCaller.DelayCall(audioLength, delegate
							{
								target.currentHitSFXNum--;
							}, 0, 0, false);
						}
						num2++;
					}
				}
			}
		}
		SoundTable hitSFXIDData = this.defaultHitSFXData;
		if (this.m_cpkCurEntityActionInfo != null && this.m_cpkCurEntityActionInfo.hitSFXID > 0)
		{
			hitSFXIDData = this.m_cpkCurEntityActionInfo.hitSFXIDData;
		}
		uint num4 = MonoSingleton<AudioManager>.instance.PlaySound(hitSFXIDData, 1f, 1f);
		if (num4 > 0U)
		{
			target.currentHitSFXNum++;
			int audioLength2 = MonoSingleton<AudioManager>.instance.GetAudioLength(num4);
			target.delayCaller.DelayCall(audioLength2, delegate
			{
				target.currentHitSFXNum--;
			}, 0, 0, false);
		}
	}

	// Token: 0x06016F0D RID: 93965 RVA: 0x006F10A9 File Offset: 0x006EF4A9
	public void SetOwner(BeEntity o)
	{
		this.owner = o;
	}

	// Token: 0x06016F0E RID: 93966 RVA: 0x006F10B2 File Offset: 0x006EF4B2
	public BeEntity GetOwner()
	{
		return this.owner;
	}

	// Token: 0x06016F0F RID: 93967 RVA: 0x006F10BC File Offset: 0x006EF4BC
	public bool IsFacingAway(BeEntity target)
	{
		if (!target.stateController.HasAbility(BeAbilityType.CAN_HIT_BACK))
		{
			return false;
		}
		if (target == null)
		{
			return false;
		}
		VInt3 position = this.GetPosition();
		if (this is BeProjectile)
		{
			position = this.owner.GetPosition();
		}
		if ((target.GetPosition() - position).x > 0)
		{
			return !target.GetFace();
		}
		return target.GetFace();
	}

	// Token: 0x06016F10 RID: 93968 RVA: 0x006F112D File Offset: 0x006EF52D
	public virtual void OnBeforeGetDamage(BeEntity target, AttackResult result, bool isBackHit, int hurtID)
	{
	}

	// Token: 0x06016F11 RID: 93969 RVA: 0x006F1130 File Offset: 0x006EF530
	public AttackResult DoAttackTo(BeEntity target, int hurtid, bool triggerFlashHurt = true, bool isAttachHurt = false)
	{
		bool flag = false;
		int num = 0;
		int num2 = 0;
		return this.DoAttackTo(target, hurtid, ref flag, ref num, ref num2, this.GetPosition(), true, false, triggerFlashHurt, isAttachHurt);
	}

	// Token: 0x06016F12 RID: 93970 RVA: 0x006F115C File Offset: 0x006EF55C
	private void _addHurtData2Statistics(int skillId, int hurtId, int damage)
	{
		if (this == null)
		{
			return;
		}
		if (this.CurrentBeBattle == null)
		{
			Logger.LogError("[战斗] 战斗对象为空");
			return;
		}
		IDungeonStatistics dungeonStatistics = this.CurrentBeBattle.dungeonStatistics;
		if (dungeonStatistics == null)
		{
			Logger.LogError("[战斗] 数据统计为空");
			return;
		}
		dungeonStatistics.AddHurtData(skillId, hurtId, damage);
	}

	// Token: 0x06016F13 RID: 93971 RVA: 0x006F11AC File Offset: 0x006EF5AC
	public bool IsBoss()
	{
		return this.IsMonster() && this.attribute.type == 3;
	}

	// Token: 0x06016F14 RID: 93972 RVA: 0x006F11CA File Offset: 0x006EF5CA
	public bool IsMonster()
	{
		return this.attribute != null && this.attribute.isMonster && this.m_iCamp != 0;
	}

	// Token: 0x06016F15 RID: 93973 RVA: 0x006F11F6 File Offset: 0x006EF5F6
	public virtual bool IsAttackAdd2Statistics()
	{
		return false;
	}

	// Token: 0x06016F16 RID: 93974 RVA: 0x006F11FC File Offset: 0x006EF5FC
	public AttackResult DoAttackTo(BeEntity target, int hurtid, ref bool doRefectDamage, ref int reflectDamage, ref int outFinalDamage, VInt3 hitPos, bool needCalcBackHit = true, bool isBackHit = false, bool triggerFlashHurt = true, bool isAttachHurt = false)
	{
		ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
		int num = 1;
		outFinalDamage = 0;
		AttackResult attackResult = AttackResult.NORMAL;
		EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(hurtid, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return attackResult;
		}
		EffectTable.eDamageType damageType = tableItem.DamageType;
		attackResult = this.attribute.GetAttackResult(target.GetEntityData(), damageType, hurtid);
		if (!isAttachHurt)
		{
			int[] array = new int[]
			{
				(int)attackResult
			};
			target.TriggerEvent(BeEventType.OnAttackResult, new object[]
			{
				array
			});
			attackResult = (AttackResult)array[0];
		}
		attackResult = (AttackResult)this.TriggerEventNew(BeEventType.OnDoAttckResult, new EventParam
		{
			m_Obj = this,
			m_Int = (int)attackResult,
			m_Obj2 = target
		}).m_Int;
		if (attackResult == AttackResult.IGNORE)
		{
			return attackResult;
		}
		if (isAttachHurt && attackResult == AttackResult.MISS)
		{
			attackResult = AttackResult.NORMAL;
		}
		if (tableItem.DamageDistanceType == EffectTable.eDamageDistanceType.FAR && target.stateController.IgnoreFarDamage())
		{
			if (this.showDamageNumber && clientSystemBattle != null && clientSystemBattle.comShowHit != null)
			{
				clientSystemBattle.comShowHit.ShowHitNumber(0, null, this.m_iID, hitPos.vec3, this.GetFace(), HitTextType.NORMAL, this, target);
			}
			this.TriggerMiss(this.owner, target, 0);
			return AttackResult.MISS;
		}
		if (tableItem.DamageDistanceType != EffectTable.eDamageDistanceType.NEAR && target.stateController.CanBeHitOnlyNear())
		{
			if (this.showDamageNumber && clientSystemBattle != null && clientSystemBattle.comShowHit != null)
			{
				clientSystemBattle.comShowHit.ShowHitNumber(0, null, this.m_iID, hitPos.vec3, this.GetFace(), HitTextType.NORMAL, this, target);
			}
			this.TriggerMiss(this.owner, target, 1);
			return AttackResult.MISS;
		}
		if (attackResult == AttackResult.NORMAL || attackResult == AttackResult.CRITICAL)
		{
			if (tableItem.HasDamage == 1)
			{
				if (needCalcBackHit && tableItem.IsFriendDamage == 0)
				{
					isBackHit = this.IsFacingAway(target);
				}
				this.OnBeforeGetDamage(target, attackResult, isBackHit, hurtid);
				int num2 = this.attribute.GetDamage(target.GetEntityData(), hurtid, attackResult);
				if (this.IsAttackAdd2Statistics())
				{
					this._addHurtData2Statistics(tableItem.SkillID, hurtid, num2);
				}
				int[] array2 = new int[1];
				if (this.m_iCamp == target.m_iCamp && !target.stateController.IsChaosState() && !this.CheckCanAttackFriend(target) && !this.CheckCanAttackFriendAndEnemy(target))
				{
					array2[0] = 1;
				}
				else
				{
					array2[0] = num2;
				}
				target.TriggerEvent(BeEventType.onAfterCalFirstDamage, new object[]
				{
					array2,
					true,
					hurtid
				});
				BeEntity beEntity = null;
				if (this is BeProjectile)
				{
					beEntity = this.GetOwner();
				}
				this.TriggerEvent(BeEventType.onAfterCalFirstDamage, new object[]
				{
					array2,
					false,
					hurtid
				});
				num2 = array2[0];
				CrypticInt32 inData = GlobalLogic.VALUE_100;
				MagicElementType attackElementType = this.attribute.GetAttackElementType(hurtid);
				int addPercentDamage = 0;
				if (attackElementType == MagicElementType.LIGHT && target.stateController.HasBuffState(BeBuffStateType.FLASH))
				{
					addPercentDamage = inData;
				}
				else if (attackElementType == MagicElementType.FIRE && target.stateController.HasBuffState(BeBuffStateType.BURN))
				{
					addPercentDamage = inData;
				}
				else if (attackElementType == MagicElementType.ICE && target.stateController.HasBuffState(BeBuffStateType.FROZEN))
				{
					addPercentDamage = inData;
				}
				else if (attackElementType == MagicElementType.DARK && target.stateController.HasBuffState(BeBuffStateType.CURSE))
				{
					addPercentDamage = inData;
				}
				AddDamageInfo item2 = new AddDamageInfo(addPercentDamage, 0);
				if (addPercentDamage > 0)
				{
					this.attribute.battleData.addDamagePercent.Add(item2);
				}
				List<int> list = ListPool<int>.Get();
				int damage = 0;
				num = this.attribute.GetAttachDamages(target, num2, tableItem.DamageType, tableItem.DamageDistanceType, ref damage, list);
				if (addPercentDamage > 0)
				{
					if (this.CurrentBeBattle != null && !this.CurrentBeBattle.FunctionIsOpen(BattleFlagType.MagicAddDamagePercent))
					{
						this.attribute.battleData.addDamagePercent.Remove(item2);
					}
					else
					{
						this.attribute.battleData.addDamagePercent.RemoveAll((AddDamageInfo item) => item.value == addPercentDamage);
					}
				}
				reflectDamage = target.GetEntityData().GetReflectDamages(damage);
				if (reflectDamage > 0)
				{
					doRefectDamage = true;
				}
				if (!this.stateController.CanBeHit())
				{
					doRefectDamage = false;
					reflectDamage = 0;
				}
				if (this.m_iCamp == target.m_iCamp && !target.stateController.IsChaosState() && !this.CheckCanAttackFriend(target) && !this.CheckCanAttackFriendAndEnemy(target))
				{
					num = 1;
				}
				bool flag = isBackHit;
				if (flag)
				{
					target.TriggerEvent(BeEventType.onBackHit, new object[]
					{
						this
					});
					BeActor beActor = null;
					if (this is BeProjectile)
					{
						beActor = (this.GetOwner() as BeActor);
					}
					if (this is BeActor)
					{
						beActor = (this as BeActor);
					}
					if (beActor != null && !beActor.IsDeadOrRemoved() && beActor.isLocalActor)
					{
						beActor.m_pkGeActor.CreateHeadText(HitTextType.SPECIAL_ATTACK, "UI/Font/new_font/pic_back_hit", false, null);
					}
				}
				bool flag2 = false;
				EffectTable.eAvoidDamageType avoidDamageType = tableItem.AvoidDamageType;
				if (avoidDamageType == EffectTable.eAvoidDamageType.AV_FACINGAWAY)
				{
					flag2 = flag;
				}
				if (flag2)
				{
					doRefectDamage = false;
					num = 0;
				}
				array2[0] = num;
				this.TriggerEvent(BeEventType.onAfterFinalDamage, new object[]
				{
					array2,
					target,
					hurtid
				});
				if (beEntity != null && !beEntity.IsDeadOrRemoved())
				{
					beEntity.TriggerEvent(BeEventType.onAfterFinalDamageNew, new object[]
					{
						array2,
						target,
						hurtid,
						damageType,
						list,
						this,
						hitPos
					});
				}
				else
				{
					this.TriggerEvent(BeEventType.onAfterFinalDamageNew, new object[]
					{
						array2,
						target,
						hurtid,
						damageType,
						list,
						this,
						hitPos
					});
				}
				bool magicElementISuse = tableItem.MagicElementISuse;
				List<int> list2 = new List<int>();
				this.ChangeEquipElementList(magicElementISuse, list2, attackElementType);
				BeEvent.BeEventParam beEventParam = DataStructPool.EventParamPool.Get();
				beEventParam.m_Int = hurtid;
				beEventParam.m_Obj = list2;
				this.GetProjectileEventTrigger().TriggerEventNew(BeEventType.onChangeMagicElementList, beEventParam);
				DataStructPool.EventParamPool.Release(beEventParam);
				bool flag3 = this is BeActor;
				bool[] array3 = new bool[]
				{
					false
				};
				if (flag3)
				{
					target.TriggerEvent(BeEventType.onBeHitAfterFinalDamage, new object[]
					{
						array2,
						hurtid,
						array3,
						this,
						triggerFlashHurt,
						hitPos,
						list2,
						list
					});
				}
				else
				{
					BeEntity beEntity2 = this.GetOwner();
					if (beEntity2 != null && !beEntity2.IsDeadOrRemoved())
					{
						target.TriggerEvent(BeEventType.onBeHitAfterFinalDamage, new object[]
						{
							array2,
							hurtid,
							array3,
							beEntity2,
							triggerFlashHurt,
							hitPos,
							list2,
							list
						});
					}
				}
				num = array2[0];
				if (array3[0])
				{
					ListPool<int>.Release(list);
					return AttackResult.MISS;
				}
				if (flag3)
				{
					target.TriggerEvent(BeEventType.onHit, new object[]
					{
						num,
						attackElementType,
						this,
						damageType,
						hurtid,
						triggerFlashHurt,
						list2,
						flag,
						target
					});
				}
				else
				{
					BeEntity beEntity3 = this.GetOwner();
					if (beEntity3 != null && !beEntity3.IsDeadOrRemoved())
					{
						target.TriggerEvent(BeEventType.onHit, new object[]
						{
							num,
							attackElementType,
							beEntity3,
							damageType,
							hurtid,
							triggerFlashHurt,
							list2,
							flag,
							target
						});
					}
				}
				if (target.stateController.CanBeHitNoDamage())
				{
					this.TriggerMiss(this.owner, target, 2);
					ListPool<int>.Release(list);
					return AttackResult.MISS;
				}
				num = this.FixSummonMonsterDamage(num);
				outFinalDamage = num;
				BeActor beActor2 = this as BeActor;
				if (beActor2 != null)
				{
					this.TriggerEvent(BeEventType.onHitOther, new object[]
					{
						target,
						hurtid,
						tableItem.SkillID,
						hitPos,
						beActor2.GetCurSkillID(),
						num
					});
				}
				else
				{
					this.TriggerEvent(BeEventType.onHitOther, new object[]
					{
						target,
						hurtid,
						tableItem.SkillID,
						hitPos,
						0,
						num
					});
				}
				HitTextType type = (attackResult != AttackResult.NORMAL) ? HitTextType.CRITICAL : HitTextType.NORMAL;
				HitTextType typeForSpecialBuff = HitTextType.NORMAL;
				if (tableItem.IsFriendDamage > 0)
				{
					typeForSpecialBuff = HitTextType.FRIEND_HURT;
					list.Clear();
				}
				BeActor beActor3 = target as BeActor;
				if (beActor3 != null && beActor3.protectManager != null && triggerFlashHurt)
				{
					beActor3.protectManager.BeHit();
				}
				this.OnSkillDamageEvent(num, beActor3, tableItem.SkillID);
				if (beEntity != null && !beEntity.IsDeadOrRemoved())
				{
					beEntity.RecordHurtId(hurtid, target);
				}
				else
				{
					this.RecordHurtId(hurtid, target);
				}
				target.DoHurt(num, list, type, this, typeForSpecialBuff, false);
				this.TriggerEvent(BeEventType.onHitOtherAfterHurt, new object[]
				{
					target,
					hurtid,
					attackResult
				});
				if (tableItem.HitDeadFall > 0 && target.IsDead())
				{
					this.DealHit(hurtid, target, hitPos, tableItem, 1, false);
				}
				this.TriggerHitAfterDoHurt(beActor3);
				ListPool<int>.Release(list);
				if (this.IsProcessRecord())
				{
					this.GetRecordServer().Mark(559240U, new int[]
					{
						this.m_iID,
						target.m_iID,
						(int)attackResult,
						num,
						this.GetPosition().x,
						this.GetPosition().y,
						this.GetPosition().z,
						this.moveXSpeed.i,
						this.moveYSpeed.i,
						this.moveZSpeed.i,
						(!this.GetFace()) ? 0 : 1,
						this.attribute.GetHP(),
						this.attribute.GetMP(),
						this.m_kStateTag.GetAllFlag(),
						this.attribute.battleData.attack.ToInt(),
						target.GetPosition().x,
						target.GetPosition().y,
						target.GetPosition().z,
						target.moveXSpeed.i,
						target.moveYSpeed.i,
						target.moveZSpeed.i,
						(!target.GetFace()) ? 0 : 1,
						target.attribute.GetHP(),
						target.attribute.GetMP(),
						target.m_kStateTag.GetAllFlag(),
						target.attribute.battleData.attack.ToInt()
					}, new string[]
					{
						this.GetName(),
						target.GetName()
					});
				}
			}
			else if (tableItem.HasDamage == -1)
			{
				this.TriggerEvent(BeEventType.onCollide, new object[]
				{
					target,
					hurtid
				});
				target.TriggerEvent(BeEventType.onCollideOther, new object[]
				{
					this
				});
			}
			this.OnCollide();
			this.TryAddBuff(tableItem, target, 0, true, false, false);
			if (tableItem.HasDamage == 1)
			{
				bool flag4 = this is BeActor;
				if (flag4)
				{
					target.TriggerEvent(BeEventType.onHitAfterAddBuff, new object[]
					{
						hurtid,
						triggerFlashHurt,
						this,
						tableItem.SkillID,
						num,
						isBackHit
					});
				}
				else
				{
					BeEntity beEntity4 = this.GetOwner();
					target.TriggerEvent(BeEventType.onHitAfterAddBuff, new object[]
					{
						hurtid,
						triggerFlashHurt,
						beEntity4,
						tableItem.SkillID,
						num,
						isBackHit
					});
				}
			}
			this.TryAddEntity(tableItem, this.GetPosition(), 1);
			this.TrySummon(tableItem);
		}
		else if (attackResult == AttackResult.MISS)
		{
			this.TriggerMiss(this.owner, target, 3);
			if (clientSystemBattle != null && this.showDamageNumber)
			{
				clientSystemBattle.comShowHit.ShowHitNumber(0, null, this.m_iID, hitPos.vec3, this.GetFace(), HitTextType.MISS, this.owner, target);
			}
		}
		if (clientSystemBattle != null)
		{
			clientSystemBattle.comDebugBattleStatis.BS_AddBattleInfo(this.GetName(), target.GetName(), attackResult, num);
		}
		return attackResult;
	}

	// Token: 0x06016F17 RID: 93975 RVA: 0x006F1F96 File Offset: 0x006F0396
	public BeEntity GetTopOwner(BeEntity parent)
	{
		if (parent == null)
		{
			return null;
		}
		this.mCurRecursiveCount = 0;
		return this._GetTopOwner(parent.GetOwner());
	}

	// Token: 0x06016F18 RID: 93976 RVA: 0x006F1FB3 File Offset: 0x006F03B3
	protected void RecordHurtId(int hurtId, BeEntity target)
	{
	}

	// Token: 0x06016F19 RID: 93977 RVA: 0x006F1FB8 File Offset: 0x006F03B8
	private BeEntity _GetTopOwner(BeEntity parent)
	{
		if (parent == null)
		{
			return null;
		}
		if (this.mCurRecursiveCount >= 5)
		{
			Logger.LogErrorFormat("recursive count is out of range curparent {0} {1}", new object[]
			{
				(parent == null) ? "null" : parent.GetName(),
				this.GetName()
			});
			return parent;
		}
		this.mCurRecursiveCount++;
		if (parent == parent.GetOwner())
		{
			return parent;
		}
		BeEntity beEntity = this._GetTopOwner(parent.GetOwner());
		if (beEntity == null)
		{
			return parent;
		}
		return beEntity;
	}

	// Token: 0x06016F1A RID: 93978 RVA: 0x006F203F File Offset: 0x006F043F
	public BeActor GetProjectileOwnerActor(BeEntity entity)
	{
		if (entity == null)
		{
			return null;
		}
		this.mCurRecursiveCount = 0;
		return this._GetProjectileOwnerActor(entity) as BeActor;
	}

	// Token: 0x06016F1B RID: 93979 RVA: 0x006F205C File Offset: 0x006F045C
	private BeEntity _GetProjectileOwnerActor(BeEntity entity)
	{
		if (entity == null)
		{
			return null;
		}
		if (this.mCurRecursiveCount >= 5)
		{
			Logger.LogErrorFormat("recursive count is out of range curparent {0} {1}", new object[]
			{
				(entity == null) ? "null" : entity.GetName(),
				this.GetName()
			});
			return entity;
		}
		this.mCurRecursiveCount++;
		BeActor beActor = entity as BeActor;
		if (beActor != null)
		{
			return beActor;
		}
		BeActor beActor2 = this.GetOwner() as BeActor;
		if (beActor2 != null)
		{
			return beActor2;
		}
		BeEntity beEntity = this._GetProjectileOwnerActor(entity);
		BeActor beActor3 = beEntity as BeActor;
		if (beActor3 != null)
		{
			return beActor3;
		}
		return entity;
	}

	// Token: 0x06016F1C RID: 93980 RVA: 0x006F20FC File Offset: 0x006F04FC
	private void OnSkillDamageEvent(int hurtValue, BeActor target, int skillId)
	{
		if (this.owner.CurrentBeScene == null)
		{
			return;
		}
		if (target == null)
		{
			return;
		}
		BeActor beActor = this as BeActor;
		if (beActor == null)
		{
			beActor = (this.owner as BeActor);
		}
		if (beActor == null)
		{
			return;
		}
		if (beActor.GetSkill(skillId) == null)
		{
			return;
		}
		int comboSkillId = BeUtility.GetComboSkillId(beActor, skillId);
		this.owner.CurrentBeScene.TriggerEvent(BeEventSceneType.onDoHurt, new object[]
		{
			hurtValue,
			beActor,
			target,
			comboSkillId
		});
	}

	// Token: 0x06016F1D RID: 93981 RVA: 0x006F218C File Offset: 0x006F058C
	protected int FixSummonMonsterDamage(int damage)
	{
		if (this.attribute.monsterData != null && this.attribute.monsterData.MonsterMode == 5 && BattleMain.IsModePvP(this.CurrentBeScene.mBattle.GetBattleType()))
		{
			PkHPProfessionAdjustTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PkHPProfessionAdjustTable>(this.attribute.simpleMonsterID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (this.CurrentBeScene.mBattle.PkRaceType == 6)
				{
					damage *= VRate.Factor(tableItem.DamageFactor_3v3);
				}
				else if (this.CurrentBeScene.mBattle.PkRaceType == 8)
				{
					damage *= VRate.Factor(tableItem.DamageFactor_chiji);
				}
				else
				{
					damage *= VRate.Factor(tableItem.DamageFactor);
				}
			}
		}
		return damage;
	}

	// Token: 0x06016F1E RID: 93982 RVA: 0x006F226F File Offset: 0x006F066F
	public virtual void TriggerHitAfterDoHurt(BeActor target)
	{
	}

	// Token: 0x06016F1F RID: 93983 RVA: 0x006F2274 File Offset: 0x006F0674
	protected void TriggerMiss(BeEntity attacker, BeEntity target, int missFlag)
	{
		BeActor beActor = (BeActor)attacker;
		BeActor beActor2 = (BeActor)target;
		if (beActor != null)
		{
			beActor.buffController.TriggerBuffs(BuffCondition.ATTACKMISS, target as BeActor, null);
		}
		if (beActor2 != null)
		{
			beActor2.buffController.TriggerBuffs(BuffCondition.BEHITMISS, target as BeActor, null);
		}
	}

	// Token: 0x06016F20 RID: 93984 RVA: 0x006F22C3 File Offset: 0x006F06C3
	protected void ChangeEquipElementList(bool useEquipElement, List<int> magicElementTypeList, MagicElementType attackElementType)
	{
		if (useEquipElement)
		{
			this.attribute.GetOwnerEquipElement(magicElementTypeList);
		}
		if (!magicElementTypeList.Contains((int)attackElementType))
		{
			magicElementTypeList.Add((int)attackElementType);
		}
	}

	// Token: 0x06016F21 RID: 93985 RVA: 0x006F22EA File Offset: 0x006F06EA
	public void DoReflect(int reflectDamage, BeEntity target)
	{
		if (reflectDamage > 0 && target != null && target != this)
		{
			target.DoHurt(reflectDamage, null, HitTextType.NORMAL, null, HitTextType.NORMAL, false);
		}
	}

	// Token: 0x06016F22 RID: 93986 RVA: 0x006F230C File Offset: 0x006F070C
	public void DealEffectFrame(BeEntity target, int hurtid, int duration = 0, bool phaseDelete = false, bool useBuffAni = true, bool finishDelete = false, bool finishDeleteAll = false)
	{
		EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(hurtid, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return;
		}
		this.TryAddBuff(tableItem, this, duration, useBuffAni, finishDelete, finishDeleteAll);
		this.TryAddEntity(tableItem, this.GetPosition(), 1);
		this.TrySummon(tableItem);
	}

	// Token: 0x06016F23 RID: 93987 RVA: 0x006F235D File Offset: 0x006F075D
	public virtual bool TryAddBuff(EffectTable hurtData, BeEntity target = null, int duration = 0, bool useBuffAni = true, bool finishDelete = false, bool finishDeleteAll = false)
	{
		return false;
	}

	// Token: 0x06016F24 RID: 93988 RVA: 0x006F2360 File Offset: 0x006F0760
	public virtual bool TryAddEntity(EffectTable hurtData, VInt3 pos, int triggeredLevel = 1)
	{
		return false;
	}

	// Token: 0x06016F25 RID: 93989 RVA: 0x006F2363 File Offset: 0x006F0763
	public virtual bool TrySummon(EffectTable hurtData)
	{
		return false;
	}

	// Token: 0x06016F26 RID: 93990 RVA: 0x006F2366 File Offset: 0x006F0766
	public virtual void TryAddMechanism(int mechanismId)
	{
	}

	// Token: 0x06016F27 RID: 93991 RVA: 0x006F2368 File Offset: 0x006F0768
	public BeEntityData GetEntityData()
	{
		return this.attribute;
	}

	// Token: 0x06016F28 RID: 93992 RVA: 0x006F2370 File Offset: 0x006F0770
	public bool IsSummonMonster()
	{
		return this.attribute != null && this.attribute.monsterData != null && this.attribute.monsterData.MonsterMode == 5;
	}

	// Token: 0x06016F29 RID: 93993 RVA: 0x006F23A3 File Offset: 0x006F07A3
	public VInt GetEnityScale()
	{
		return this.m_fScale;
	}

	// Token: 0x06016F2A RID: 93994 RVA: 0x006F23AB File Offset: 0x006F07AB
	public int _getFaceCoff()
	{
		return (!this.GetFace()) ? 1 : -1;
	}

	// Token: 0x06016F2B RID: 93995 RVA: 0x006F23BF File Offset: 0x006F07BF
	public void AddShock(ShockData sd)
	{
		this._addShock(sd.time, sd.speed, sd.xrange, sd.yrange, sd.mode);
	}

	// Token: 0x06016F2C RID: 93996 RVA: 0x006F23EA File Offset: 0x006F07EA
	public void _addShock(float time, float speed, float xrange, float yrange, int mode = 1)
	{
		this.m_kShockEffect.SetMode(mode);
		this.m_kShockEffect.Start(time, speed, xrange * (float)this._getFaceCoff(), yrange);
	}

	// Token: 0x06016F2D RID: 93997 RVA: 0x006F2414 File Offset: 0x006F0814
	public virtual void JudgeDead()
	{
		bool flag = this.isDead;
		if (this.attribute != null && this.attribute.GetHP() <= 0)
		{
			this.isDead = true;
			if (!flag && this.isDead)
			{
				this.TriggerEvent(BeEventType.onBeKilled, null);
			}
		}
	}

	// Token: 0x06016F2E RID: 93998 RVA: 0x006F2465 File Offset: 0x006F0865
	public bool IsDead()
	{
		return this.isDead;
	}

	// Token: 0x06016F2F RID: 93999 RVA: 0x006F2470 File Offset: 0x006F0870
	public virtual void DoDead(bool isForce = false)
	{
		if (this.sgGetCurrentState() == 16)
		{
			return;
		}
		int[] array = new int[]
		{
			0
		};
		this.TriggerEvent(BeEventType.onDead, new object[]
		{
			array,
			isForce,
			this
		});
		bool flag = array[0] == 0;
		if (flag)
		{
			if (this.aiManager != null)
			{
				this.aiManager.Stop();
			}
			if (!this.sgStarted)
			{
				if (this.m_pkStateGraph != null && !this.m_pkStateGraph.Start(16))
				{
					this.Locomote(new BeStateData(16, 0), false);
					return;
				}
			}
			else
			{
				this.Locomote(new BeStateData(16, 0), false);
			}
			this.sgStarted = true;
		}
	}

	// Token: 0x06016F30 RID: 94000 RVA: 0x006F252B File Offset: 0x006F092B
	public virtual void OnDead()
	{
	}

	// Token: 0x06016F31 RID: 94001 RVA: 0x006F2530 File Offset: 0x006F0930
	public void DoMPChange(int value, bool showNumber = false)
	{
		if (this.attribute != null)
		{
			this.attribute.OnMPChange(value);
			this.TriggerEvent(BeEventType.onMPChange, null);
			if (this.m_pkGeActor != null)
			{
				this.m_pkGeActor.SetMpValue(this.attribute.GetMPRate().single);
			}
			if (showNumber)
			{
				ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
				if (clientSystemBattle != null && clientSystemBattle.comShowHit != null && this.showDamageNumber)
				{
					clientSystemBattle.comShowHit.ShowHitNumber(value, null, this.m_iID, this.GetGePosition(PositionType.OVERHEAD), this.GetFace(), HitTextType.MP_RECOVER, null, null);
				}
			}
		}
	}

	// Token: 0x06016F32 RID: 94002 RVA: 0x006F25DC File Offset: 0x006F09DC
	public void DoHPChange(int value, bool showNumber = true)
	{
		if (this.attribute != null)
		{
			int hp = this.attribute.GetHP();
			this.attribute.OnHPChange(value);
			float num = this.attribute.GetHPRate().single;
			num = Mathf.Clamp(num, 0f, 1f);
			int num2 = this.attribute.GetHP() - hp;
			HitTextType type = HitTextType.RECOVE;
			if (value <= 0)
			{
				type = HitTextType.BUFF_HURT;
			}
			if (this.m_pkGeActor != null)
			{
				this.m_pkGeActor.SetHPValue(num);
				if (num2 <= 0 || this.stateController.CanHurt())
				{
					BeActor beActor = this as BeActor;
					if (beActor != null && beActor.buffController.HasBuffByID(69) != null)
					{
						return;
					}
					this.m_pkGeActor.SetHPDamage(-num2, type);
				}
			}
			if (showNumber)
			{
				ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
				if (clientSystemBattle != null && this.showDamageNumber)
				{
					clientSystemBattle.comShowHit.ShowHitNumber(value, null, this.m_iID, this.GetGePosition(PositionType.OVERHEAD), this.GetFace(), type, null, this);
				}
			}
		}
	}

	// Token: 0x06016F33 RID: 94003 RVA: 0x006F26FF File Offset: 0x006F0AFF
	public void DoHeal(int healValue, bool showNumber = true)
	{
		if (healValue > 0)
		{
			this.DoHPChange(healValue, showNumber);
		}
	}

	// Token: 0x06016F34 RID: 94004 RVA: 0x006F2710 File Offset: 0x006F0B10
	public virtual void DoHurt(int value, List<int> attachValues = null, HitTextType type = HitTextType.NORMAL, BeEntity attacker = null, HitTextType typeForSpecialBuff = HitTextType.NORMAL, bool forceBuffHurt = false)
	{
		if (this.attribute != null)
		{
			int hp = this.attribute.GetHP();
			int[] array = new int[]
			{
				value
			};
			this.TriggerEvent(BeEventType.onChangeHurtValue, new object[]
			{
				array,
				attachValues
			});
			int num = array[0];
			EventParam eventParam = this.TriggerEventNew(BeEventType.onChangeHurtValue, new EventParam
			{
				m_Int = num,
				m_Int2 = num,
				m_Obj = ListPool<int>.Get(),
				m_Obj2 = attachValues
			});
			num = eventParam.m_Int2;
			attachValues = (eventParam.m_Obj2 as List<int>);
			List<int> list = eventParam.m_Obj as List<int>;
			if (list != null)
			{
				ListPool<int>.Release(list);
			}
			this.attribute.OnHPChange(-num);
			if (this.IsBoss() && attacker != null)
			{
				int pid = attacker.GetPID();
				BeActor beActor = attacker as BeActor;
				if (beActor == null || !beActor.isMainActor)
				{
					BeActor beActor2 = this.GetTopOwner(attacker) as BeActor;
					if (beActor2 != null && beActor2.isMainActor)
					{
						pid = beActor2.GetPID();
					}
				}
				IDungeonStatistics dungeonStatistics = this.CurrentBeBattle.dungeonStatistics;
				if (dungeonStatistics != null)
				{
					dungeonStatistics.AddBossHurtData(pid, num, this.GetEntityData().monsterID);
				}
			}
			if (this.attribute.GetHP() <= 0 && hp > 0 && attacker != null)
			{
				VFactor f = new VFactor((long)Global.Settings.immediateDeadHPPercent, (long)GlobalLogic.VALUE_100);
				if (num >= this.attribute.GetMaxHP() * f)
				{
					this.needDead = true;
					if (!this.PlayDeadAction())
					{
						this.deadType = DeadType.IMMEDIATE;
					}
				}
				else if (type == HitTextType.CRITICAL)
				{
					BeActor beActor3 = this as BeActor;
					if (beActor3 == null || (beActor3 != null && beActor3.IsCanCritDead()))
					{
						this.needDead = true;
						if (!this.PlayDeadAction())
						{
							this.deadType = DeadType.CRITICAL;
						}
					}
				}
				if (this.deadType == DeadType.NORMAL)
				{
				}
				BeEntity beEntity = attacker.GetOwner();
				if (beEntity != null && !beEntity.IsDeadOrRemoved())
				{
					beEntity.TriggerEvent(BeEventType.onKill, new object[]
					{
						this
					});
				}
			}
			this.TriggerEvent(BeEventType.onHurt, new object[]
			{
				num,
				attacker
			});
			if (attacker != null)
			{
				attacker.mLastTargetId = this.GetPID();
				BeEntity topOwner = this.GetTopOwner(this);
				if (topOwner != null)
				{
					attacker.mLastOwnerTargetId = topOwner.GetPID();
					attacker.mLastTargetOwnerPos = topOwner.GetPosition();
				}
				this.mLastAttackerId = attacker.GetPID();
				BeEntity topOwner2 = attacker.GetTopOwner(attacker);
				if (topOwner2 != null)
				{
					this.mLastOwnerAttackerId = topOwner2.GetPID();
					if (topOwner != null)
					{
						topOwner2.mLastOwnerTargetId = topOwner.GetPID();
						topOwner2.mLastTargetOwnerPos = topOwner.GetPosition();
						topOwner2.mLastTargetId = this.GetPID();
					}
				}
			}
			this.OnHurt(num, attacker, typeForSpecialBuff);
			float num2 = this.attribute.GetHPRate().single;
			num2 = Mathf.Clamp(num2, 0f, 1f);
			if (this.m_pkGeActor != null)
			{
				this.m_pkGeActor.SetHPValue(num2);
			}
			if (num <= 0 || this.stateController.CanHurt())
			{
				if (this is BeProjectile)
				{
					if (this.owner != null && this.owner.m_pkGeActor != null)
					{
						this.owner.m_pkGeActor.SetHPDamage(num, type);
					}
				}
				else if (this.m_pkGeActor != null)
				{
					this.m_pkGeActor.SetHPDamage(num, type);
				}
			}
			if (attacker != null)
			{
				BeEntity topOwner3 = attacker.GetTopOwner(attacker);
				BeActor beActor4 = topOwner3 as BeActor;
				if (beActor4 != null && beActor4.isMainActor)
				{
					topOwner3.GetEntityData().battleData.AddDamage(value, attacker, topOwner3);
				}
			}
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				int num3 = num;
				if (attachValues != null)
				{
					for (int i = 0; i < attachValues.Count; i++)
					{
						num3 -= attachValues[i];
					}
				}
				if (this.showDamageNumber)
				{
					if (attacker != null && (attacker is BeProjectile || (attacker is BeActor && attacker.GetEntityData() != null && attacker.GetEntityData().type == 8) || (attacker.GetOwner() != null && attacker.GetEntityData() == attacker.GetOwner().GetEntityData())))
					{
						attacker = attacker.GetOwner();
					}
					if (typeForSpecialBuff != HitTextType.NORMAL)
					{
						type = typeForSpecialBuff;
					}
					clientSystemBattle.comShowHit.ShowHitNumber(num3, attachValues, this.m_iID, this.GetGePosition(PositionType.OVERHEAD), this.GetFace(), type, attacker, this);
				}
			}
		}
	}

	// Token: 0x06016F35 RID: 94005 RVA: 0x006F2BF7 File Offset: 0x006F0FF7
	public virtual bool PlayDeadAction()
	{
		return false;
	}

	// Token: 0x06016F36 RID: 94006 RVA: 0x006F2BFA File Offset: 0x006F0FFA
	public virtual void OnHurt(int value, BeEntity attacker, HitTextType curHitTextType)
	{
	}

	// Token: 0x06016F37 RID: 94007 RVA: 0x006F2BFC File Offset: 0x006F0FFC
	public List<BeEntity> GetHurtEntityList()
	{
		return this.m_vHurtEntity;
	}

	// Token: 0x17001F4E RID: 8014
	// (get) Token: 0x06016F38 RID: 94008 RVA: 0x006F2C04 File Offset: 0x006F1004
	// (set) Token: 0x06016F39 RID: 94009 RVA: 0x006F2C21 File Offset: 0x006F1021
	public BeEventProcessor EventProcessor
	{
		get
		{
			if (this.eventProcessor == null)
			{
				Logger.LogError("EventProcessor is nil");
			}
			return this.eventProcessor;
		}
		set
		{
			this.eventProcessor = value;
		}
	}

	// Token: 0x06016F3A RID: 94010 RVA: 0x006F2C2A File Offset: 0x006F102A
	public void ClearEvent()
	{
		if (this.eventProcessor != null)
		{
			this.eventProcessor.ClearAll();
		}
		this.ClearEventAllNew();
	}

	// Token: 0x06016F3B RID: 94011 RVA: 0x006F2C48 File Offset: 0x006F1048
	public BeEventHandle RegisterEvent(BeEventType type, BeEventHandle.Del del)
	{
		BeEventHandle result = null;
		if (this.eventProcessor != null)
		{
			result = this.eventProcessor.AddEventHandler((int)type, del);
		}
		return result;
	}

	// Token: 0x06016F3C RID: 94012 RVA: 0x006F2C71 File Offset: 0x006F1071
	public void RemoveEvent(BeEventType type, BeEventHandle.Del del)
	{
		if (this.eventProcessor != null)
		{
			this.eventProcessor.RemoveEventHandler((int)type, del);
		}
	}

	// Token: 0x06016F3D RID: 94013 RVA: 0x006F2C8B File Offset: 0x006F108B
	public void RemoveEvent(BeEventHandle handler)
	{
		if (this.eventProcessor != null)
		{
			handler.Remove();
		}
	}

	// Token: 0x06016F3E RID: 94014 RVA: 0x006F2C9E File Offset: 0x006F109E
	public void TriggerEvent(BeEventType type, object[] args = null)
	{
		if (this.eventProcessor != null)
		{
			this.eventProcessor.HandleEvent((int)type, args);
		}
	}

	// Token: 0x06016F3F RID: 94015 RVA: 0x006F2CB8 File Offset: 0x006F10B8
	public BeEvent.BeEventHandleNew RegisterEventNew(BeEventType eventType, BeEvent.BeEventHandleNew.Function function)
	{
		if (this.m_EventManager == null)
		{
			this.m_EventManager = new BeEventManager();
		}
		return this.m_EventManager.RegisterEvent((int)eventType, function);
	}

	// Token: 0x06016F40 RID: 94016 RVA: 0x006F2CDD File Offset: 0x006F10DD
	public void TriggerEventNew(BeEventType eventType, BeEvent.BeEventParam eventParam = null)
	{
		if (this.m_EventManager == null)
		{
			return;
		}
		this.m_EventManager.TriggerEvent((int)eventType, eventParam);
	}

	// Token: 0x06016F41 RID: 94017 RVA: 0x006F2CF8 File Offset: 0x006F10F8
	public EventParam TriggerEventNew(BeEventType eventType, EventParam param = default(EventParam))
	{
		if (this.m_EventManager == null)
		{
			return param;
		}
		return this.m_EventManager.TriggerEvent((int)eventType, param);
	}

	// Token: 0x06016F42 RID: 94018 RVA: 0x006F2D14 File Offset: 0x006F1114
	public void ClearEventAllNew()
	{
		if (this.m_EventManager == null)
		{
			return;
		}
		this.m_EventManager.ClearAll();
	}

	// Token: 0x06016F43 RID: 94019 RVA: 0x006F2D2D File Offset: 0x006F112D
	public bool IsCastingSkill()
	{
		return this.sgGetCurrentState() == 14;
	}

	// Token: 0x06016F44 RID: 94020 RVA: 0x006F2D39 File Offset: 0x006F1139
	public bool IsGrabed()
	{
		return this.sgGetCurrentState() == 15;
	}

	// Token: 0x06016F45 RID: 94021 RVA: 0x006F2D45 File Offset: 0x006F1145
	public void RecordGrabPosition()
	{
		if (this.currentBeScene != null && !this.currentBeScene.IsInBlockPlayer(this.GetPosition()))
		{
			this.posBeforeGrab = this.GetPosition();
		}
	}

	// Token: 0x06016F46 RID: 94022 RVA: 0x006F2D74 File Offset: 0x006F1174
	public void JugePositionAfterGrab()
	{
		VInt3 position = this.GetPosition();
		if (this.currentBeScene != null && this.currentBeScene.IsInBlockPlayer(position))
		{
			if (this.m_kBlockPosition == VInt3.zero)
			{
				this.m_kBlockPosition = this.posBeforeGrab;
			}
			this.SetStandPosition(new VInt3(this.m_kBlockPosition.x, this.m_kBlockPosition.y, position.z), false);
		}
	}

	// Token: 0x06016F47 RID: 94023 RVA: 0x006F2DEE File Offset: 0x006F11EE
	public string GetName()
	{
		if (this.m_pkGeActor != null)
		{
			return this.m_pkGeActor.m_ActorDesc.name;
		}
		return string.Empty;
	}

	// Token: 0x06016F48 RID: 94024 RVA: 0x006F2E11 File Offset: 0x006F1211
	public void SetFloating(VInt height, bool footIndicator = true)
	{
		this.isFloating = true;
		this.floatingHeight = height;
		if (footIndicator)
		{
			this.m_pkGeActor.CreateFootIndicator(null);
		}
		this.RestoreFloating(false);
	}

	// Token: 0x06016F49 RID: 94025 RVA: 0x006F2E3C File Offset: 0x006F123C
	public void RestoreFloating(bool force = false)
	{
		if (force || !this.stateController.IgnoreGravity())
		{
			this.stateController.SetAbilityEnable(BeAbilityType.GRAVITY, false);
			VInt3 position = this.GetPosition();
			position.z = 0;
			position.z += this.floatingHeight.i;
			this.SetPosition(position, false, true, false);
		}
	}

	// Token: 0x06016F4A RID: 94026 RVA: 0x006F2E9F File Offset: 0x006F129F
	public void RemoveFloating()
	{
		if (this.stateController.IgnoreGravity())
		{
			this.stateController.SetAbilityEnable(BeAbilityType.GRAVITY, true);
		}
	}

	// Token: 0x06016F4B RID: 94027 RVA: 0x006F2EC0 File Offset: 0x006F12C0
	public bool IsNormalInAir()
	{
		return !this.IsInPassiveState() && this.GetPosition().z > VInt.zeroDotOne;
	}

	// Token: 0x06016F4C RID: 94028 RVA: 0x006F2EF7 File Offset: 0x006F12F7
	public bool IsInPassiveState()
	{
		return this.GetStateGraph().CurrentStateHasTag(7);
	}

	// Token: 0x06016F4D RID: 94029 RVA: 0x006F2F08 File Offset: 0x006F1308
	public void UpdateRecover(int delta)
	{
		this.recoverTimeAcc += delta;
		if (this.recoverTimeAcc >= this.recoverInterval)
		{
			this.recoverTimeAcc -= this.recoverInterval;
			if (!this.IsDead())
			{
				this.DoRecover();
				this.DoReduce();
			}
		}
	}

	// Token: 0x06016F4E RID: 94030 RVA: 0x006F2F60 File Offset: 0x006F1360
	public void DoRecover()
	{
		if (this.attribute == null)
		{
			return;
		}
		if ((this.attribute.battleData.hpRecover > 0 && this.attribute.GetHP() < this.attribute.battleData.maxHp) || (this.attribute.battleData.hpRecover < 0 && this.attribute.GetHP() > 0))
		{
			VFactor b = new VFactor((long)this.recoverInterval, (long)GlobalLogic.VALUE_1000);
			int num = this.attribute.battleData.hpRecover * (BeEntity.Recover_Tmp2 * b);
			if (this.attribute.battleData.hpRecover > 0)
			{
				num = Mathf.Max(1, num);
				if (num != 0)
				{
					this.DoHPChange(num, false);
				}
			}
			else if (this.attribute.battleData.hpRecover < 0 && num != 0 && Math.Abs(num) < this.attribute.GetHP())
			{
				this.DoHPChange(num, false);
			}
		}
		if (this.attribute.battleData.mpRecover != 0 && this.attribute.GetMP() < this.attribute.GetMaxMP())
		{
			VFactor b2 = new VFactor((long)this.recoverInterval, (long)GlobalLogic.VALUE_1000);
			int num2 = this.attribute.battleData.mpRecover * (BeEntity.Recover_Tmp2 * b2);
			if (num2 != 0)
			{
				this.DoMPChange(num2, false);
			}
		}
	}

	// Token: 0x06016F4F RID: 94031 RVA: 0x006F3114 File Offset: 0x006F1514
	public void DoReduce()
	{
		if (this.attribute == null)
		{
			return;
		}
		if (this.attribute.battleData.hpReduce > 0 && this.attribute.GetHP() > this.attribute.battleData.hpReduce)
		{
			this.DoHPChange(-this.attribute.battleData.hpReduce, false);
		}
		if (this.attribute.battleData.mpReduce > 0 && this.attribute.GetMP() > this.attribute.battleData.mpReduce)
		{
			this.DoMPChange(-this.attribute.battleData.mpReduce, false);
		}
	}

	// Token: 0x06016F50 RID: 94032 RVA: 0x006F31E8 File Offset: 0x006F15E8
	public void _LoadBlockData()
	{
		string blockDataResPath = FBModelDataSerializer.GetBlockDataResPath(this.m_iResID);
		DModelData dmodelData = null;
		if (!string.IsNullOrEmpty(blockDataResPath))
		{
			dmodelData = (Singleton<AssetLoader>.instance.LoadRes(blockDataResPath, typeof(DModelData), true, 0U).obj as DModelData);
		}
		if (null != dmodelData)
		{
			this.m_nBlockWidth = dmodelData.blockGridChunk.gridWidth;
			this.m_nBlockHeight = dmodelData.blockGridChunk.gridHeight;
			this.m_byteBlockData = new byte[dmodelData.blockGridChunk.gridBlockData.Length];
			if (dmodelData.blockGridChunk.gridBlockData.Length > 0)
			{
				Array.Copy(dmodelData.blockGridChunk.gridBlockData, this.m_byteBlockData, dmodelData.blockGridChunk.gridBlockData.Length);
			}
		}
		else
		{
			this.m_nBlockWidth = 1;
			this.m_nBlockHeight = 1;
			this.m_byteBlockData = BeEntity.DEFAULT_BLOCK_DATA;
		}
	}

	// Token: 0x06016F51 RID: 94033 RVA: 0x006F32CA File Offset: 0x006F16CA
	public byte[] _GetBlockData(out int width, out int height)
	{
		width = this.m_nBlockWidth;
		height = this.m_nBlockHeight;
		return this.m_byteBlockData;
	}

	// Token: 0x06016F52 RID: 94034 RVA: 0x006F32E4 File Offset: 0x006F16E4
	public void SetBlockLayer(bool block = true)
	{
		if (this.currentBeScene == null)
		{
			return;
		}
		DGrid dgrid = new DGrid(5, 10);
		int num;
		int num2;
		byte[] array = this._GetBlockData(out num, out num2);
		bool flag = true;
		if (num == 1 && num2 == 1)
		{
			flag = false;
		}
		else
		{
			dgrid.x = num;
			dgrid.y = num2;
		}
		if (!flag)
		{
			return;
		}
		DGrid dgrid2 = this.currentBeScene.CalGridByPosition(this.GetPosition());
		int x = dgrid2.x;
		int y = dgrid2.y;
		int num3 = x - dgrid.x / 2;
		int num4 = y - dgrid.y / 2 + 1;
		if (dgrid.x % 2 == 1)
		{
			num3++;
		}
		if (dgrid.y % 2 == 1)
		{
			num4++;
		}
		for (int i = num3; i < num3 + dgrid.x; i++)
		{
			for (int j = num4; j < num4 + dgrid.y; j++)
			{
				if (flag)
				{
					int num5 = i - num3 + (j - num4) * num;
					bool flag2 = array[num5] == 1;
					if (flag2)
					{
						if (block)
						{
							this.currentBeScene.SetBlock(new DGrid(i, j), true);
						}
						else
						{
							this.currentBeScene.SetBlock(new DGrid(i, j), false);
						}
					}
				}
				else
				{
					this.currentBeScene.SetBlock(new DGrid(i, j), block);
				}
			}
		}
	}

	// Token: 0x06016F53 RID: 94035 RVA: 0x006F3468 File Offset: 0x006F1868
	public void SetDefaultHitSFX(int sfxID)
	{
		this.defaultHitSFXID = sfxID;
		if (this.defaultHitSFXID > 0)
		{
			this.defaultHitSFXData = Singleton<TableManager>.GetInstance().GetTableItem<SoundTable>(this.defaultHitSFXID, string.Empty, string.Empty);
			MonoSingleton<AudioManager>.instance.PreloadSound(this.defaultHitSFXID);
		}
	}

	// Token: 0x06016F54 RID: 94036 RVA: 0x006F34B8 File Offset: 0x006F18B8
	public virtual string GetInfo()
	{
		VInt3 position = this.GetPosition();
		return string.Format(" [PID:{10} name:{9} pos:({0},{1},{2}) speed:({3},{4},{5}) face:{6} hp:{7} mp:{8} attack:{12} tag:{11}]", new object[]
		{
			position.x,
			position.y,
			position.z,
			this.moveXSpeed,
			this.moveYSpeed,
			this.moveZSpeed,
			this.GetFace(),
			this.attribute.GetHP(),
			this.attribute.GetMP(),
			this.GetName(),
			this.m_iID,
			this.m_kStateTag.GetAllFlag(),
			this.attribute.battleData.attack
		});
	}

	// Token: 0x06016F55 RID: 94037 RVA: 0x006F35B0 File Offset: 0x006F19B0
	public virtual int[] GetEntityRecordAttribute()
	{
		VInt3 position = this.GetPosition();
		return new int[]
		{
			this.m_iID,
			position.x,
			position.y,
			position.z,
			this.moveXSpeed.i,
			this.moveYSpeed.i,
			this.moveZSpeed.i,
			(!this.GetFace()) ? 0 : 1,
			(this.attribute == null) ? 0 : this.attribute.GetHP(),
			(this.attribute == null) ? 0 : this.attribute.GetMP(),
			this.m_kStateTag.GetAllFlag(),
			this.m_iCurSkillID
		};
	}

	// Token: 0x06016F56 RID: 94038 RVA: 0x006F3694 File Offset: 0x006F1A94
	public void RemoveRepeatDamage()
	{
		if (this.delayCallUnitList.Count > 0)
		{
			for (int i = 0; i < this.delayCallUnitList.Count; i++)
			{
				this.delayCallUnitList[i].SetRemove(true);
			}
		}
		this.delayCallUnitHurtIdList.Clear();
		this.delayCallUnitList.Clear();
	}

	// Token: 0x06016F57 RID: 94039 RVA: 0x006F36FC File Offset: 0x006F1AFC
	public bool IsProcessRecord()
	{
		RecordServer recordServer = this.GetRecordServer();
		return recordServer != null && recordServer.IsProcessRecord();
	}

	// Token: 0x06016F58 RID: 94040 RVA: 0x006F371E File Offset: 0x006F1B1E
	public RecordServer GetRecordServer()
	{
		if (this.currentBeScene == null)
		{
			return null;
		}
		return this.currentBeScene.mBattle.recordServer;
	}

	// Token: 0x06016F59 RID: 94041 RVA: 0x006F373D File Offset: 0x006F1B3D
	public int GetCurrentFrame()
	{
		return this.m_iCurrentLogicFrame;
	}

	// Token: 0x06016F5A RID: 94042 RVA: 0x006F3745 File Offset: 0x006F1B45
	protected virtual bool CheckCanAttackFriend(BeEntity pkEntity)
	{
		if (pkEntity == null)
		{
			return false;
		}
		if (this is BeProjectile)
		{
			return this.owner != pkEntity && this.owner.stateController.CanAttackFriend();
		}
		return this.stateController.CanAttackFriend();
	}

	// Token: 0x06016F5B RID: 94043 RVA: 0x006F3785 File Offset: 0x006F1B85
	private bool CheckCanAttackFriendAndEnemy(BeEntity pkEntity)
	{
		return pkEntity != null && (this.owner.stateController.CanAttackFriendAndEnemy() || pkEntity.stateController.CanAttackFriendAndEnemy());
	}

	// Token: 0x06016F5C RID: 94044 RVA: 0x006F37B2 File Offset: 0x006F1BB2
	private bool CanUpdateX()
	{
		return this.CheckUpdateXYZFlag() || this.stateController.CanUpdateX();
	}

	// Token: 0x06016F5D RID: 94045 RVA: 0x006F37CC File Offset: 0x006F1BCC
	private bool CanUpdateY()
	{
		return this.CheckUpdateXYZFlag() || this.stateController.CanUpdateY();
	}

	// Token: 0x06016F5E RID: 94046 RVA: 0x006F37E6 File Offset: 0x006F1BE6
	private bool CanUpdateZ()
	{
		return this.CheckUpdateXYZFlag() || this.stateController.CanUpdateZ();
	}

	// Token: 0x06016F5F RID: 94047 RVA: 0x006F3800 File Offset: 0x006F1C00
	private bool CheckUpdateXYZFlag()
	{
		return this.CurrentBeBattle == null;
	}

	// Token: 0x06016F60 RID: 94048 RVA: 0x006F3810 File Offset: 0x006F1C10
	protected BeEntity GetProjectileEventTrigger()
	{
		if (!(this is BeProjectile))
		{
			return this;
		}
		return this.GetOwner();
	}

	// Token: 0x06016F61 RID: 94049 RVA: 0x006F3832 File Offset: 0x006F1C32
	protected virtual void OnCollide()
	{
	}

	// Token: 0x06016F62 RID: 94050 RVA: 0x006F3834 File Offset: 0x006F1C34
	protected virtual void OnXInBlock()
	{
	}

	// Token: 0x06016F63 RID: 94051 RVA: 0x006F3836 File Offset: 0x006F1C36
	protected virtual void ChangeXForce(int[] xForce, BeEntity target, BeEntity bullet, bool face)
	{
	}

	// Token: 0x06016F64 RID: 94052 RVA: 0x006F3838 File Offset: 0x006F1C38
	protected virtual void OnAttachHurt(BeEntity pkEntity, EffectTable hurtData)
	{
	}

	// Token: 0x06016F65 RID: 94053 RVA: 0x006F383C File Offset: 0x006F1C3C
	public void ClearPhaseDeleteAudio()
	{
		if (this.m_PhaseDeleteAudioList == null)
		{
			return;
		}
		for (int i = 0; i < this.m_PhaseDeleteAudioList.Count; i++)
		{
			MonoSingleton<AudioManager>.instance.Stop(this.m_PhaseDeleteAudioList[i]);
		}
		this.m_PhaseDeleteAudioList.Clear();
	}

	// Token: 0x06016F66 RID: 94054 RVA: 0x006F3894 File Offset: 0x006F1C94
	public void ClearSkillFinishDeleteAudio()
	{
		if (this.m_FinishDeleteAudioList == null)
		{
			return;
		}
		for (int i = 0; i < this.m_FinishDeleteAudioList.Count; i++)
		{
			MonoSingleton<AudioManager>.instance.Stop(this.m_FinishDeleteAudioList[i]);
		}
		this.m_FinishDeleteAudioList.Clear();
	}

	// Token: 0x06016F67 RID: 94055 RVA: 0x006F38EC File Offset: 0x006F1CEC
	public bool IsSameTopOwner(BeEntity entity)
	{
		BeEntity topOwner = this.GetTopOwner(this);
		if (topOwner == null)
		{
			return false;
		}
		if (entity == null)
		{
			return false;
		}
		BeEntity topOwner2 = entity.GetTopOwner(entity);
		return topOwner2 != null && topOwner2 == topOwner;
	}

	// Token: 0x04010655 RID: 67157
	public static string[] ActionConfigNames = new string[]
	{
		"Jump_up",
		"Jump_down",
		"Getup",
		"Idle",
		"Idle_special",
		"Walk",
		"Run",
		"-",
		"Jump_up_loop",
		"Jump_down_loop",
		"Houtiao",
		"parry",
		"Beiji01",
		"Beiji02",
		"Beiji01",
		"runattack",
		"jumpattack",
		"Float_down",
		"fallchange",
		"Float_up",
		"Daodi",
		"skillbase",
		"Dead",
		"Birth",
		"Win",
		"Idle02",
		"Roll",
		"StartWalk",
		"EndWalk",
		"Idle03"
	};

	// Token: 0x04010656 RID: 67158
	public static int MAX_STATE_TAG_NUM = 64;

	// Token: 0x04010657 RID: 67159
	public int m_iEntityLifeState;

	// Token: 0x04010658 RID: 67160
	public int m_iRemoveTime;

	// Token: 0x04010659 RID: 67161
	public GeActorEx m_pkGeActor;

	// Token: 0x0401065A RID: 67162
	public BeAttachFramesProxy attachmentproxy;

	// Token: 0x0401065B RID: 67163
	protected VInt3 m_kPosition;

	// Token: 0x0401065C RID: 67164
	protected VInt3 m_kBlockPosition;

	// Token: 0x0401065D RID: 67165
	protected VInt m_fScale;

	// Token: 0x0401065E RID: 67166
	protected VFactor m_fZdimScaleFactor;

	// Token: 0x0401065F RID: 67167
	protected int m_nBlockWidth = 1;

	// Token: 0x04010660 RID: 67168
	protected int m_nBlockHeight = 1;

	// Token: 0x04010661 RID: 67169
	protected static readonly byte[] DEFAULT_BLOCK_DATA = new byte[]
	{
		1
	};

	// Token: 0x04010662 RID: 67170
	protected byte[] m_byteBlockData = BeEntity.DEFAULT_BLOCK_DATA;

	// Token: 0x04010663 RID: 67171
	protected bool m_birthPosFlag;

	// Token: 0x04010664 RID: 67172
	protected VInt3 m_birthPos;

	// Token: 0x04010665 RID: 67173
	protected bool m_bFaceLeft;

	// Token: 0x04010666 RID: 67174
	public VInt FrozenDisMax = VInt.zero;

	// Token: 0x04010667 RID: 67175
	public VInt3 FrozenStartDis = VInt3.zero;

	// Token: 0x04010668 RID: 67176
	protected List<DelayCallUnitHandle> delayCallUnitList = new List<DelayCallUnitHandle>();

	// Token: 0x04010669 RID: 67177
	protected List<int> delayCallUnitHurtIdList = new List<int>();

	// Token: 0x0401066A RID: 67178
	public VInt clickZSpeed = 0;

	// Token: 0x0401066B RID: 67179
	protected VInt m_fForceX;

	// Token: 0x0401066C RID: 67180
	protected VInt m_fForceY;

	// Token: 0x0401066D RID: 67181
	public bool fallForGrab;

	// Token: 0x0401066E RID: 67182
	protected VInt3 m_kSpeedConfig;

	// Token: 0x0401066F RID: 67183
	public VInt3 walkSpeed;

	// Token: 0x04010670 RID: 67184
	public VInt3 runSpeed;

	// Token: 0x04010671 RID: 67185
	public ActionType walkAction = ActionType.ActionType_WALK;

	// Token: 0x04010672 RID: 67186
	public ActionType runAction = ActionType.ActionType_RUN;

	// Token: 0x04010673 RID: 67187
	public float walkSpeedFactor = 1f;

	// Token: 0x04010674 RID: 67188
	public float runSpeedFactor = 1f;

	// Token: 0x04010675 RID: 67189
	public bool hasDoublePress;

	// Token: 0x04010676 RID: 67190
	public bool hasRunAttackConfig;

	// Token: 0x04010677 RID: 67191
	public bool attackReplaceLigui;

	// Token: 0x04010678 RID: 67192
	public bool paladinAttackCharge = true;

	// Token: 0x04010679 RID: 67193
	public bool canUseCrystalSkill = true;

	// Token: 0x0401067A RID: 67194
	public bool backHitConfig;

	// Token: 0x0401067B RID: 67195
	public bool autoHitConfig;

	// Token: 0x0401067C RID: 67196
	public byte chaserSwitch;

	// Token: 0x0401067D RID: 67197
	public bool _xuanWuManualAttack;

	// Token: 0x0401067E RID: 67198
	private VInt mLastAttackerId = 0;

	// Token: 0x0401067F RID: 67199
	private int mLastOwnerAttackerId;

	// Token: 0x04010680 RID: 67200
	private int mLastTargetId = -1;

	// Token: 0x04010681 RID: 67201
	private int mLastOwnerTargetId = 1;

	// Token: 0x04010682 RID: 67202
	private VInt3 mLastTargetOwnerPos = VInt3.zero;

	// Token: 0x04010683 RID: 67203
	protected List<uint> m_PhaseDeleteAudioList = new List<uint>();

	// Token: 0x04010684 RID: 67204
	protected List<uint> m_FinishDeleteAudioList = new List<uint>();

	// Token: 0x04010685 RID: 67205
	public VInt m_lastMoveXSpeed;

	// Token: 0x04010686 RID: 67206
	public VInt m_lastMoveYSpeed;

	// Token: 0x04010687 RID: 67207
	public VInt3 lastMoveSpeed;

	// Token: 0x04010688 RID: 67208
	protected VInt m_fMoveXSpeed;

	// Token: 0x04010689 RID: 67209
	protected VInt m_fMoveXAcc;

	// Token: 0x0401068A RID: 67210
	protected VInt m_fMoveYSpeed;

	// Token: 0x0401068B RID: 67211
	protected VInt m_fMoveYAcc;

	// Token: 0x0401068C RID: 67212
	protected VInt m_fMoveZSpeed;

	// Token: 0x0401068D RID: 67213
	protected VInt m_fMoveZAcc;

	// Token: 0x0401068E RID: 67214
	protected VInt m_fMoveZAccExtra;

	// Token: 0x0401068F RID: 67215
	public VInt3 extraSpeed;

	// Token: 0x04010690 RID: 67216
	protected VFactor m_fMoveXSpeedRate = VFactor.one;

	// Token: 0x04010691 RID: 67217
	protected VFactor m_fMoveYSpeedRate = VFactor.one;

	// Token: 0x04010692 RID: 67218
	protected bool onlyMoveFacedDir;

	// Token: 0x04010693 RID: 67219
	protected bool onlyMoveFaceDirOpposite;

	// Token: 0x04010694 RID: 67220
	protected bool keepXSkillSpeed;

	// Token: 0x04010695 RID: 67221
	protected bool skillFreeTurnFace;

	// Token: 0x04010696 RID: 67222
	private bool mPositionDirty;

	// Token: 0x04010697 RID: 67223
	protected bool m_bGraphicPositionDirty;

	// Token: 0x04010698 RID: 67224
	protected bool m_bHaveMoveCmd;

	// Token: 0x04010699 RID: 67225
	protected bool[] m_vkMoveCmd = new bool[5];

	// Token: 0x0401069A RID: 67226
	protected bool m_bCmdDirty;

	// Token: 0x0401069B RID: 67227
	protected bool m_bLockMoveCmd;

	// Token: 0x0401069C RID: 67228
	public VFactor skillAttackScale;

	// Token: 0x0401069D RID: 67229
	protected short m_Degree;

	// Token: 0x0401069E RID: 67230
	protected BeStatesGraph m_pkStateGraph;

	// Token: 0x0401069F RID: 67231
	protected int stateStart;

	// Token: 0x040106A0 RID: 67232
	protected bool sgStarted;

	// Token: 0x040106A1 RID: 67233
	protected List<BeEntity> m_vHurtEntity = new List<BeEntity>();

	// Token: 0x040106A2 RID: 67234
	protected SeFlag m_kStateTag = new SeFlag(BeEntity.MAX_STATE_TAG_NUM);

	// Token: 0x040106A3 RID: 67235
	protected bool isDead;

	// Token: 0x040106A4 RID: 67236
	private GeShockEffect m_kShockEffect = new GeShockEffect();

	// Token: 0x040106A5 RID: 67237
	protected int m_iCurrentLogicFrame;

	// Token: 0x040106A6 RID: 67238
	protected float m_fCurrentLogicFrame;

	// Token: 0x040106A7 RID: 67239
	public bool dontSetFace;

	// Token: 0x040106A8 RID: 67240
	public BeAIManager aiManager;

	// Token: 0x040106A9 RID: 67241
	public int m_iCamp;

	// Token: 0x040106AA RID: 67242
	public int m_iID;

	// Token: 0x040106AB RID: 67243
	public int m_iResID;

	// Token: 0x040106AC RID: 67244
	protected bool m_bCanBeAttacked;

	// Token: 0x040106AD RID: 67245
	protected bool pause;

	// Token: 0x040106AE RID: 67246
	protected int pausetime;

	// Token: 0x040106AF RID: 67247
	public BDEntityRes m_cpkEntityInfo = new BDEntityRes();

	// Token: 0x040106B0 RID: 67248
	public BDEntityActionInfo m_cpkCurEntityActionInfo;

	// Token: 0x040106B1 RID: 67249
	public bool actionLooped;

	// Token: 0x040106B2 RID: 67250
	public BDEntityActionFrameData m_cpkCurEntityActionFrameData;

	// Token: 0x040106B3 RID: 67251
	public int m_iPreSkillID;

	// Token: 0x040106B4 RID: 67252
	public int m_iCurSkillID;

	// Token: 0x040106B5 RID: 67253
	protected bool m_bSkillDirty;

	// Token: 0x040106B6 RID: 67254
	protected BDDBoxData m_vkCurWorldAttackBox;

	// Token: 0x040106B7 RID: 67255
	protected BDDBoxData m_vkCurWorldDefenseBox;

	// Token: 0x040106B8 RID: 67256
	public int hurtCount;

	// Token: 0x040106B9 RID: 67257
	public BeEntityData attribute;

	// Token: 0x040106BA RID: 67258
	public BeStateControl stateController;

	// Token: 0x040106BB RID: 67259
	public bool hasHP = true;

	// Token: 0x040106BC RID: 67260
	public int timeAcc;

	// Token: 0x040106BD RID: 67261
	public DelayCaller delayCaller = new DelayCaller();

	// Token: 0x040106BE RID: 67262
	protected bool restrainPosition;

	// Token: 0x040106BF RID: 67263
	public bool pkRestrainPosition;

	// Token: 0x040106C0 RID: 67264
	public VInt2 pkRestrainRangeX;

	// Token: 0x040106C1 RID: 67265
	private bool reachAreaLimited;

	// Token: 0x040106C2 RID: 67266
	public VFactor moveSpeedFactor = VFactor.one;

	// Token: 0x040106C3 RID: 67267
	protected VInt3 posBeforeGrab = VInt3.zero;

	// Token: 0x040106C4 RID: 67268
	protected List<ActionType> actionQueue = new List<ActionType>();

	// Token: 0x040106C5 RID: 67269
	private int actionAcc;

	// Token: 0x040106C6 RID: 67270
	private int actionTimeout;

	// Token: 0x040106C7 RID: 67271
	private float queuedActionSpeed = 1f;

	// Token: 0x040106C8 RID: 67272
	public VInt3 absorbTargetPos = VInt3.zero;

	// Token: 0x040106C9 RID: 67273
	public bool isAbsorb;

	// Token: 0x040106CA RID: 67274
	public VInt3 absorbPos = VInt3.zero;

	// Token: 0x040106CB RID: 67275
	public VInt absorbLen = VInt.zero;

	// Token: 0x040106CC RID: 67276
	public VInt absorbSpeed;

	// Token: 0x040106CD RID: 67277
	protected DelayCallUnit repeatUnit;

	// Token: 0x040106CE RID: 67278
	public string beHitEffect = "-";

	// Token: 0x040106CF RID: 67279
	public string hitEffect = "-";

	// Token: 0x040106D0 RID: 67280
	public bool isFloating;

	// Token: 0x040106D1 RID: 67281
	public VInt floatingHeight = 0;

	// Token: 0x040106D2 RID: 67282
	protected BeEntity owner;

	// Token: 0x040106D3 RID: 67283
	public VInt boxRadius = 0;

	// Token: 0x040106D4 RID: 67284
	public bool showDamageNumber = true;

	// Token: 0x040106D5 RID: 67285
	public BeActionManager actionManager = new BeActionManager();

	// Token: 0x040106D6 RID: 67286
	public VInt3 savedPosition;

	// Token: 0x040106D7 RID: 67287
	public bool playedExpDead;

	// Token: 0x040106D8 RID: 67288
	private int recoverInterval = 1000;

	// Token: 0x040106D9 RID: 67289
	private int recoverTimeAcc;

	// Token: 0x040106DA RID: 67290
	public DeadType deadType;

	// Token: 0x040106DB RID: 67291
	protected bool needDead;

	// Token: 0x040106DC RID: 67292
	public bool dontDelete;

	// Token: 0x040106DD RID: 67293
	public bool needHitShader;

	// Token: 0x040106DE RID: 67294
	public bool loadCommonSkill;

	// Token: 0x040106DF RID: 67295
	public bool doublePressRun;

	// Token: 0x040106E0 RID: 67296
	public bool doublePressRunLeft;

	// Token: 0x040106E1 RID: 67297
	public bool changeToNoBlock;

	// Token: 0x040106E2 RID: 67298
	public int defaultHitSFXID;

	// Token: 0x040106E3 RID: 67299
	public SoundTable defaultHitSFXData;

	// Token: 0x040106E4 RID: 67300
	protected bool resetMoveDirty;

	// Token: 0x040106E5 RID: 67301
	public int currentHitEffectNum;

	// Token: 0x040106E6 RID: 67302
	public int totalHitEffectNum = 5;

	// Token: 0x040106E7 RID: 67303
	public int currentHitSFXNum;

	// Token: 0x040106E8 RID: 67304
	public int totalHitSFXNum = 5;

	// Token: 0x040106E9 RID: 67305
	public bool absoluteBroken;

	// Token: 0x040106EA RID: 67306
	protected BeEventManager m_EventManager;

	// Token: 0x040106EB RID: 67307
	protected CrypticInt32 _hasAI = 0;

	// Token: 0x040106EC RID: 67308
	protected CrypticInt32 _pauseAI = 0;

	// Token: 0x040106ED RID: 67309
	protected BeScene currentBeScene;

	// Token: 0x040106EE RID: 67310
	private EffectsFrames DUMMY_EFF_FRAME = new EffectsFrames();

	// Token: 0x040106EF RID: 67311
	public bool bLockMoveDegree;

	// Token: 0x040106F0 RID: 67312
	public short nLockDegree;

	// Token: 0x040106F1 RID: 67313
	public bool bLockMove;

	// Token: 0x040106F2 RID: 67314
	private static VFactor speedScaleFactor = new VFactor(32L, 1000L);

	// Token: 0x040106F3 RID: 67315
	public bool inUpdatePosition;

	// Token: 0x040106F4 RID: 67316
	private object[] blockparams = new object[2];

	// Token: 0x040106F5 RID: 67317
	private VInt[] moveSpeed = new VInt[]
	{
		0,
		0
	};

	// Token: 0x040106F6 RID: 67318
	private object[] changeSpeedEventParam = new object[1];

	// Token: 0x040106F7 RID: 67319
	private int[] temp_array_3 = new int[3];

	// Token: 0x040106F8 RID: 67320
	private object[] temp_event = new object[2];

	// Token: 0x040106F9 RID: 67321
	private int[] temp_array_1 = new int[1];

	// Token: 0x040106FA RID: 67322
	private VInt3[] temp_vint3_1 = new VInt3[1];

	// Token: 0x040106FB RID: 67323
	private object[] temp_event_1 = new object[1];

	// Token: 0x040106FC RID: 67324
	private EffectsFrames DUMMY_HIT_EFF_FRAME = new EffectsFrames();

	// Token: 0x040106FD RID: 67325
	private BeInfoEffect DUMMY_INFO_EFFECT = new BeInfoEffect();

	// Token: 0x040106FE RID: 67326
	private static int kCount = 1;

	// Token: 0x040106FF RID: 67327
	private int mCurRecursiveCount;

	// Token: 0x04010700 RID: 67328
	private BeEventProcessor eventProcessor = new BeEventProcessor();

	// Token: 0x04010701 RID: 67329
	private static readonly VFactor Recover_Tmp2 = new VFactor(1L, (long)GlobalLogic.VALUE_60);
}
