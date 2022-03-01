using System;
using System.Collections.Generic;
using Battle;
using GameClient;
using GamePool;
using Protocol;
using ProtoTable;
using UnityEngine;

// Token: 0x0200413C RID: 16700
public class BeActor : BeEntity
{
	// Token: 0x06016B9B RID: 93083 RVA: 0x006F3C9C File Offset: 0x006F209C
	public BeActor(int iResID, int iCamp, int iID) : base(iResID, iCamp, (long)iID)
	{
		this.m_bInRunMode = false;
		this.restrainPosition = true;
		this.buffController = new BeBuffManager(this);
		this.protectManager = new BeProtect(this);
		this.actorData = new BeActorData(this);
		this.skillDamageManager = new SkillDamageManager(this);
		if (this.actorData != null)
		{
			this.actorData.InitData(this);
		}
		for (int i = 0; i < this.groupSummonNum.Length; i++)
		{
			this.groupSummonNum[i] = 0;
		}
	}

	// Token: 0x06016B9C RID: 93084 RVA: 0x006F3DE4 File Offset: 0x006F21E4
	public void InitChangeEquipData(RaceEquip[] equipArr, RaceEquipScheme[] schemeArr)
	{
		if (equipArr == null)
		{
			return;
		}
		if (schemeArr == null)
		{
			return;
		}
		this.m_SchemeLength = schemeArr.Length;
		this.m_ChangeEquipDataList = new EquipSchemeData[this.m_SchemeLength];
		for (int i = 0; i < this.m_SchemeLength; i++)
		{
			RaceEquipScheme raceEquipScheme = schemeArr[i];
			this.InitEquipDataByScheme(equipArr, raceEquipScheme, (int)(raceEquipScheme.id - 1U));
		}
	}

	// Token: 0x06016B9D RID: 93085 RVA: 0x006F3E44 File Offset: 0x006F2244
	protected void InitEquipDataByScheme(RaceEquip[] equipArr, RaceEquipScheme scheme, int index)
	{
		if (scheme == null)
		{
			return;
		}
		bool isWear = false;
		if (scheme.isWear == 1)
		{
			isWear = true;
			this.m_CurrentChangeEquipIndex = index;
		}
		this.InitSwitchEquipIcon(this.m_CurrentChangeEquipIndex);
		if (scheme.equips == null)
		{
			return;
		}
		EquipSchemeData equipSchemeData = default(EquipSchemeData);
		equipSchemeData.EquipList = new List<ItemProperty>();
		equipSchemeData.Title = null;
		equipSchemeData.TitlId = 0;
		int i = 0;
		while (i < equipArr.Length)
		{
			RaceEquip raceEquip = equipArr[i];
			if (raceEquip.uid != scheme.title)
			{
				goto IL_AB;
			}
			ItemProperty equip = this.GetEquip(isWear, raceEquip);
			if (equip == null)
			{
				goto IL_AB;
			}
			equipSchemeData.Title = this.GetEquip(isWear, raceEquip);
			equipSchemeData.TitlId = (int)raceEquip.id;
			IL_E6:
			i++;
			continue;
			IL_AB:
			if (Array.IndexOf<ulong>(scheme.equips, raceEquip.uid) < 0)
			{
				goto IL_E6;
			}
			equip = this.GetEquip(isWear, raceEquip);
			if (equip == null)
			{
				goto IL_E6;
			}
			equipSchemeData.EquipList.Add(equip);
			goto IL_E6;
		}
		this.m_ChangeEquipDataList[index] = equipSchemeData;
	}

	// Token: 0x06016B9E RID: 93086 RVA: 0x006F3F58 File Offset: 0x006F2358
	public void InitTrainingPveBattleData()
	{
		if (DataManager<ItemDataManager>.GetInstance() == null)
		{
			return;
		}
		if (DataManager<EquipPlanDataManager>.GetInstance() == null)
		{
			return;
		}
		if (!EquipPlanUtility.IsEquipPlanOpenedByServer())
		{
			return;
		}
		int equipPlanId = (DataManager<EquipPlanDataManager>.GetInstance().CurrentSelectedEquipPlanId != 1) ? 1 : 2;
		if (EquipPlanUtility.OnlyGetEquipItemGuidListInEquipPlanByEquipPlanId(equipPlanId) == null && EquipPlanUtility.OnlyGetTitleItemGuidInEquipPlanByEquipPlanId(equipPlanId) == 0UL)
		{
			return;
		}
		this.m_ChangeEquipDataList = new EquipSchemeData[this.m_SchemeLength];
		this.m_CurrentChangeEquipIndex = DataManager<EquipPlanDataManager>.GetInstance().CurrentSelectedEquipPlanId - 1;
		this.InitSwitchEquipIcon(this.m_CurrentChangeEquipIndex);
		for (int i = 0; i < 2; i++)
		{
			int equipPlanId2 = i + 1;
			bool isWear = i == this.m_CurrentChangeEquipIndex;
			EquipSchemeData equipSchemeData = default(EquipSchemeData);
			equipSchemeData.EquipList = new List<ItemProperty>();
			equipSchemeData.Title = null;
			equipSchemeData.TitlId = 0;
			List<ulong> list = EquipPlanUtility.OnlyGetEquipItemGuidListInEquipPlanByEquipPlanId(equipPlanId2);
			if (list != null)
			{
				for (int j = 0; j < list.Count; j++)
				{
					ItemProperty equipInTraningPve = this.GetEquipInTraningPve(isWear, list[j]);
					equipSchemeData.EquipList.Add(equipInTraningPve);
				}
			}
			ulong num = EquipPlanUtility.OnlyGetTitleItemGuidInEquipPlanByEquipPlanId(equipPlanId2);
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(num);
			if (item != null)
			{
				ItemProperty equipInTraningPve2 = this.GetEquipInTraningPve(isWear, num);
				equipSchemeData.Title = equipInTraningPve2;
				equipSchemeData.TitlId = item.TableID;
			}
			this.m_ChangeEquipDataList[i] = equipSchemeData;
		}
	}

	// Token: 0x06016B9F RID: 93087 RVA: 0x006F40C8 File Offset: 0x006F24C8
	public void ChangeEquip(int index)
	{
		if (this.m_ChangeEquipDataList == null)
		{
			Logger.LogErrorFormat("没有初始化切换装备数据,不能切换装备", new object[0]);
			return;
		}
		if (this.m_CurrentChangeEquipIndex >= this.m_ChangeEquipDataList.Length || index >= this.m_ChangeEquipDataList.Length)
		{
			Logger.LogErrorFormat("切换装备传入的序号越界了, index:{0}", new object[]
			{
				this.m_CurrentChangeEquipIndex
			});
			return;
		}
		EquipSchemeData equipSchemeData = this.m_ChangeEquipDataList[this.m_CurrentChangeEquipIndex];
		EquipSchemeData equipSchemeData2 = this.m_ChangeEquipDataList[index];
		this.m_RecordEquipDataList.Clear();
		if (equipSchemeData.EquipList != null)
		{
			for (int i = 0; i < equipSchemeData.EquipList.Count; i++)
			{
				ItemProperty item = equipSchemeData.EquipList[i];
				this.RemoveOldEquip(item);
			}
		}
		if (equipSchemeData.Title != null)
		{
			this.RemoveOldEquip(equipSchemeData.Title);
		}
		this.RemoveOldEquip(this.suitProperty);
		this.RemoveOldEquip(this.masterProperty);
		if (equipSchemeData2.EquipList != null)
		{
			for (int j = 0; j < equipSchemeData2.EquipList.Count; j++)
			{
				ItemProperty item2 = equipSchemeData2.EquipList[j];
				this.AddNewEquip(item2);
			}
		}
		if (equipSchemeData2.Title != null)
		{
			this.AddNewEquip(equipSchemeData2.Title);
		}
		this.ChangeTitleUI(equipSchemeData2.TitlId);
		if (this.equips != null)
		{
			List<int> list = new List<int>();
			for (int k = 0; k < this.equips.Count; k++)
			{
				list.Add(this.equips[k].itemID);
			}
			this.suitProperty = DataManager<EquipSuitDataManager>.GetInstance().GetEquipSuitPropByIDs(list);
			if (this.attribute != null)
			{
				this.masterProperty = DataManager<EquipMasterDataManager>.GetInstance().GetEquipMasterPropByIDs(this.attribute.professtion, list);
			}
			else
			{
				Logger.LogError("attribute is null");
			}
			if (this.suitProperty != null)
			{
				this.AddNewEquip(this.suitProperty);
			}
			if (this.masterProperty != null)
			{
				this.AddNewEquip(this.masterProperty);
			}
		}
		this.RealAddBuffAddMechanisms();
		this.RefreshDataByChangeEquipOrWeapon();
		this.attribute.ChangeMaxHpByResist();
		this.m_CurrentChangeEquipIndex = index;
		BeEvent.BeEventParam beEventParam = DataStructPool.EventParamPool.Get();
		beEventParam.m_Obj = this;
		base.TriggerEventNew(BeEventType.onChangeEquipEnd, beEventParam);
		DataStructPool.EventParamPool.Release(beEventParam);
	}

	// Token: 0x06016BA0 RID: 93088 RVA: 0x006F4344 File Offset: 0x006F2744
	protected void RefreshDataByChangeEquipOrWeapon()
	{
		Dictionary<int, CrypticInt32> dictionary = new Dictionary<int, CrypticInt32>(this.attribute.skillLevelInfo);
		Dictionary<int, CrypticInt32> dictionary2 = new Dictionary<int, CrypticInt32>(this.attribute.skillLevelInfo);
		foreach (KeyValuePair<int, CrypticInt32> keyValuePair in dictionary)
		{
			int key = keyValuePair.Key;
			Dictionary<int, CrypticInt32>.Enumerator enumerator = new Dictionary<int, CrypticInt32>.Enumerator();
			KeyValuePair<int, CrypticInt32> keyValuePair2 = enumerator.Current;
			int num = keyValuePair2.Value;
			int num2 = 0;
			if (dictionary2.ContainsKey(key))
			{
				num2 = dictionary2[key];
			}
			if (num != num2)
			{
				BeSkill skill = this.GetSkill(key);
				if (skill != null)
				{
					skill.OnInit();
					if (skill.skillData != null && skill.skillData.SkillType == SkillTable.eSkillType.PASSIVE)
					{
						skill.OnPostInit();
					}
					skill.DealLevelChange();
				}
			}
		}
		if (base.IsCastingSkill())
		{
			this.SetSkillPhases(this.m_iCurSkillID);
		}
		foreach (KeyValuePair<int, BeSkill> keyValuePair3 in this.skillList)
		{
			BeSkill value = keyValuePair3.Value;
			if (value != null)
			{
				value.DealEquipChange();
			}
		}
		this.attribute.ChangeMaxHpByResist();
		this.attribute.battleData.RefreshMpInfo();
		if (this.m_pkGeActor != null)
		{
			if (this.m_pkGeActor.mCurHpBar != null)
			{
				this.m_pkGeActor.mCurHpBar.InitResistMagic(this.attribute.GetResistMagic(), this);
			}
			this.m_pkGeActor.SyncHPBar();
		}
	}

	// Token: 0x06016BA1 RID: 93089 RVA: 0x006F44D0 File Offset: 0x006F28D0
	protected void ChangeTitleUI(int newTitleId)
	{
		int iTittle = newTitleId;
		if (this.isLocalActor)
		{
			if (BattleMain.IsModePvP(base.battleType) || base.battleType == BattleType.TrainingSkillCombo)
			{
				if (Singleton<SettingManager>.GetInstance().GetCommmonSet("SETTING_TITLESETPVP") == SettingManager.SetCommonType.Close)
				{
					iTittle = 0;
				}
			}
			else if (Singleton<SettingManager>.GetInstance().GetCommmonSet("SETTING_TITLESET") == SettingManager.SetCommonType.Close)
			{
				iTittle = 0;
			}
		}
		this.m_pkGeActor.OnTittleChanged(iTittle);
	}

	// Token: 0x06016BA2 RID: 93090 RVA: 0x006F4548 File Offset: 0x006F2948
	protected void RemoveOldEquip(ItemProperty item)
	{
		if (item == null)
		{
			return;
		}
		if (BattleMain.IsModePvP(base.battleType))
		{
			this.RemoveMechanisms(item.attachPVPMechanismIDs);
			this.RemoveMechanismBuffs(item.attachPVPBuffIDs, item);
		}
		else
		{
			this.RemoveMechanisms(item.attachMechanismIDs);
			this.RemoveMechanismBuffs(item.attachBuffIDs, item);
		}
		this.attribute.RemoveEquip(item);
		this.attribute.RemoveEquipment(item);
	}

	// Token: 0x06016BA3 RID: 93091 RVA: 0x006F45BC File Offset: 0x006F29BC
	protected void AddNewEquip(ItemProperty item)
	{
		if (item == null)
		{
			return;
		}
		RecordEquipAddData item2 = default(RecordEquipAddData);
		item2.item = item;
		item2.mechanismIdList = new List<int>();
		item2.mechanismBuffIdList = new List<int>();
		item2.mechanismIdList.AddRange((!BattleMain.IsModePvP(base.battleType)) ? item.attachMechanismIDs : item.attachPVPMechanismIDs);
		item2.mechanismBuffIdList.AddRange((!BattleMain.IsModePvP(base.battleType)) ? item.attachBuffIDs : item.attachPVPBuffIDs);
		this.m_RecordEquipDataList.Add(item2);
		this.attribute.AddEquipment(item);
		this.attribute.AddEquip(item);
	}

	// Token: 0x06016BA4 RID: 93092 RVA: 0x006F4678 File Offset: 0x006F2A78
	protected void RealAddBuffAddMechanisms()
	{
		for (int i = 0; i < this.m_RecordEquipDataList.Count; i++)
		{
			this.LoadMechanisms(this.m_RecordEquipDataList[i].mechanismIdList, 0, MechanismSourceType.EQUIP);
		}
		for (int j = 0; j < this.m_RecordEquipDataList.Count; j++)
		{
			RecordEquipAddData recordEquipAddData = this.m_RecordEquipDataList[j];
			this.LoadMechanismBuffs(recordEquipAddData.mechanismBuffIdList, 0, false, recordEquipAddData.item, true);
		}
	}

	// Token: 0x06016BA5 RID: 93093 RVA: 0x006F46FD File Offset: 0x006F2AFD
	public int GetSchemeCount()
	{
		if (this.m_ChangeEquipDataList == null)
		{
			return 0;
		}
		return this.m_ChangeEquipDataList.Length;
	}

	// Token: 0x06016BA6 RID: 93094 RVA: 0x006F4714 File Offset: 0x006F2B14
	public int GetCurrentSchemeIndex()
	{
		return this.m_CurrentChangeEquipIndex;
	}

	// Token: 0x06016BA7 RID: 93095 RVA: 0x006F471C File Offset: 0x006F2B1C
	protected void InitSwitchEquipIcon(int index)
	{
		ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.GetCurrentSystem() as ClientSystemBattle;
		if (clientSystemBattle == null)
		{
			return;
		}
		clientSystemBattle.InitSwitchEquipIcon(this.m_CurrentChangeEquipIndex);
	}

	// Token: 0x06016BA8 RID: 93096 RVA: 0x006F474C File Offset: 0x006F2B4C
	protected ItemProperty GetEquip(bool isWear, RaceEquip equip)
	{
		if (isWear)
		{
			return this.attribute.GetWearEquipByGUID(equip.uid);
		}
		return BattlePlayer.GetEquip(equip, BattleMain.IsModePvP(base.battleType));
	}

	// Token: 0x06016BA9 RID: 93097 RVA: 0x006F4778 File Offset: 0x006F2B78
	protected ItemProperty GetEquipInTraningPve(bool isWear, ulong guid)
	{
		if (isWear)
		{
			return this.attribute.GetWearEquipByGUID(guid);
		}
		ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(guid);
		if (item != null)
		{
			ItemProperty battleProperty = item.GetBattleProperty(0);
			battleProperty.itemID = item.TableID;
			battleProperty.guid = item.GUID;
			return battleProperty;
		}
		return null;
	}

	// Token: 0x17001F1C RID: 7964
	// (get) Token: 0x06016BAA RID: 93098 RVA: 0x006F47D2 File Offset: 0x006F2BD2
	public bool HasAttackEntityOnGrabCheck
	{
		get
		{
			return this.hasAttackEntityOnGrabCheck;
		}
	}

	// Token: 0x17001F1D RID: 7965
	// (get) Token: 0x06016BAC RID: 93100 RVA: 0x006F47E3 File Offset: 0x006F2BE3
	// (set) Token: 0x06016BAB RID: 93099 RVA: 0x006F47DA File Offset: 0x006F2BDA
	public int skillPhase
	{
		get
		{
			return this.m_skillPhase;
		}
		set
		{
			this.m_skillPhase = value;
		}
	}

	// Token: 0x17001F1E RID: 7966
	// (get) Token: 0x06016BAD RID: 93101 RVA: 0x006F47EB File Offset: 0x006F2BEB
	public List<BeMechanism> MechanismList
	{
		get
		{
			return this.mechanismList;
		}
	}

	// Token: 0x17001F1F RID: 7967
	// (get) Token: 0x06016BAE RID: 93102 RVA: 0x006F47F3 File Offset: 0x006F2BF3
	public bool isInDunfu
	{
		get
		{
			return this.isDunFu;
		}
	}

	// Token: 0x17001F20 RID: 7968
	// (get) Token: 0x06016BB0 RID: 93104 RVA: 0x006F4804 File Offset: 0x006F2C04
	// (set) Token: 0x06016BAF RID: 93103 RVA: 0x006F47FB File Offset: 0x006F2BFB
	public float geLastTopZ
	{
		get
		{
			return this.m_geLastTopZ;
		}
		set
		{
			this.m_geLastTopZ = value;
		}
	}

	// Token: 0x17001F21 RID: 7969
	// (get) Token: 0x06016BB2 RID: 93106 RVA: 0x006F4815 File Offset: 0x006F2C15
	// (set) Token: 0x06016BB1 RID: 93105 RVA: 0x006F480C File Offset: 0x006F2C0C
	public bool inBossRange
	{
		get
		{
			return this.m_inBossRange;
		}
		set
		{
			this.m_inBossRange = value;
		}
	}

	// Token: 0x17001F22 RID: 7970
	// (get) Token: 0x06016BB4 RID: 93108 RVA: 0x006F4826 File Offset: 0x006F2C26
	// (set) Token: 0x06016BB3 RID: 93107 RVA: 0x006F481D File Offset: 0x006F2C1D
	public AccompanyData accompanyData
	{
		get
		{
			return this.m_accompanyData;
		}
		set
		{
			this.m_accompanyData = value;
		}
	}

	// Token: 0x17001F23 RID: 7971
	// (get) Token: 0x06016BB6 RID: 93110 RVA: 0x006F4837 File Offset: 0x006F2C37
	// (set) Token: 0x06016BB5 RID: 93109 RVA: 0x006F482E File Offset: 0x006F2C2E
	public PetData petData
	{
		get
		{
			return this.m_petData;
		}
		set
		{
			this.m_petData = value;
		}
	}

	// Token: 0x06016BB7 RID: 93111 RVA: 0x006F483F File Offset: 0x006F2C3F
	public Dictionary<int, BeSkill> GetSkills()
	{
		return this.skillList;
	}

	// Token: 0x06016BB8 RID: 93112 RVA: 0x006F4847 File Offset: 0x006F2C47
	public int GetPressCount()
	{
		return this.pressCount;
	}

	// Token: 0x06016BB9 RID: 93113 RVA: 0x006F4850 File Offset: 0x006F2C50
	public void Create(int iDelaytime = 0, bool useCube = false)
	{
		BeActorStateGraph beActorStateGraph = new BeActorStateGraph();
		beActorStateGraph.InitStatesGraph();
		beActorStateGraph.pkActor = this;
		beActorStateGraph.m_pkEntity = this;
		base.Create(beActorStateGraph, 18, false, true, useCube);
		this.name = base.GetName();
		this.delayCaller.DelayCall(GlobalLogic.VALUE_100, delegate
		{
			base.SetBlockLayer(true);
		}, 0, 0, false);
		this.actorTimeAcc = 0;
	}

	// Token: 0x06016BBA RID: 93114 RVA: 0x006F48B6 File Offset: 0x006F2CB6
	public sealed override bool _onCreate()
	{
		return true;
	}

	// Token: 0x06016BBB RID: 93115 RVA: 0x006F48B9 File Offset: 0x006F2CB9
	public bool IsRunning()
	{
		return this.m_bInRunMode;
	}

	// Token: 0x06016BBC RID: 93116 RVA: 0x006F48C1 File Offset: 0x006F2CC1
	public void SetForceRunMode(bool flag)
	{
		this.forceRunMode = flag;
	}

	// Token: 0x06016BBD RID: 93117 RVA: 0x006F48CA File Offset: 0x006F2CCA
	public void SetActorNeedCost(bool flag)
	{
		this.actorNeedCost = flag;
	}

	// Token: 0x06016BBE RID: 93118 RVA: 0x006F48D3 File Offset: 0x006F2CD3
	public void SetDefaultWeapenTag(int tag)
	{
		this.defaultWeaponTag = tag;
	}

	// Token: 0x06016BBF RID: 93119 RVA: 0x006F48DC File Offset: 0x006F2CDC
	public void SetDefaultWeapenType(int type)
	{
		this.defaultWeaponType = type;
	}

	// Token: 0x06016BC0 RID: 93120 RVA: 0x006F48E5 File Offset: 0x006F2CE5
	public int GetDefaultWeaponType()
	{
		return this.defaultWeaponType;
	}

	// Token: 0x06016BC1 RID: 93121 RVA: 0x006F48ED File Offset: 0x006F2CED
	public sealed override void OnJoystickMove(int degree)
	{
		if (this.isMainActor)
		{
		}
	}

	// Token: 0x06016BC2 RID: 93122 RVA: 0x006F48FC File Offset: 0x006F2CFC
	private void _updateController(int delta)
	{
		if (this.controller != null)
		{
			if (this.controller.IsEnd())
			{
				if (this.controller.AutoRemove())
				{
					this.controller = null;
				}
			}
			else
			{
				this.controller.OnTick(delta);
			}
		}
	}

	// Token: 0x06016BC3 RID: 93123 RVA: 0x006F494C File Offset: 0x006F2D4C
	public sealed override bool Update(int iDeltaTime)
	{
		this._updateController(iDeltaTime);
		this._updateDeadProtect(iDeltaTime);
		if (base.GetLifeState() != 2)
		{
			return false;
		}
		this._internalDealInput();
		this._internalUpdate(iDeltaTime);
		if (!base.IsBoss() && this.needDead)
		{
			this.needDead = false;
			this.DoDead(false);
		}
		if (base.IsDead() && !base.IsInPassiveState())
		{
			this.DoDead(false);
		}
		this.skillDamageManager.Update(iDeltaTime);
		return true;
	}

	// Token: 0x06016BC4 RID: 93124 RVA: 0x006F49D0 File Offset: 0x006F2DD0
	public void SetController(IBeActorController controller)
	{
		controller.SetOwner(this);
		controller.OnEnter();
		this.controller = controller;
	}

	// Token: 0x17001F24 RID: 7972
	// (get) Token: 0x06016BC5 RID: 93125 RVA: 0x006F49E6 File Offset: 0x006F2DE6
	public IBeActorController currentController
	{
		get
		{
			return this.controller;
		}
	}

	// Token: 0x06016BC6 RID: 93126 RVA: 0x006F49F0 File Offset: 0x006F2DF0
	public void _internalDealInput()
	{
		if (this.attackButtonState == ButtonState.PRESS)
		{
			if (base.sgGetCurrentState() == 6)
			{
				base.TriggerEvent(BeEventType.onJumpBackAttack, null);
			}
			if (this.isPkRobot && this.aiAttackNeedCheck && this.aiManager != null && this.aiManager.aiTarget != null && !this.aiManager.aiTarget.HasTag(1))
			{
				this.aiManager.StopCurrentCommand();
				this.aiManager.pkRobotWander = true;
				this.aiManager.ResetDestinationSelect();
				this.SetAttackButtonState(ButtonState.RELEASE, false);
				this.SetAttackCheckFlag(false);
			}
			if (base.HasTag(2) && base.sgGetCurrentState() == 13 && base.GetPosition().z >= Global.Settings.JumpAttackLimitHeight)
			{
				if (this.jumpAttackUseCount < base.GetEntityData().jumpAttackCount)
				{
					this.UseSkill(base.GetEntityData().jumpAttackID, false);
				}
			}
			else if (!this.hasRunAttackConfig && this.hasDoublePress && this.IsRunning() && base.sgGetCurrentState() == 3 && base.GetEntityData().runAttackID > 0 && this.isMainActor && (this.aiManager == null || base.pauseAI))
			{
				this.UseSkill(base.GetEntityData().runAttackID, false);
			}
			else
			{
				if (this.isMainActor && base.sgGetCurrentState() == 14 && (this.m_iCurSkillID == 1102 || this.m_iCurSkillID == 2522) && this.canWalkShootTurn)
				{
					this.canWalkShootTurn = false;
					base.SetFace(!base.GetFace(), false, false);
					this.delayCaller.DelayCall(GlobalLogic.VALUE_500, delegate
					{
						this.canWalkShootTurn = true;
					}, 0, 0, false);
				}
				int num = base.GetEntityData().normalAttackID;
				if (base.sgGetCurrentState() == 14 && (this.m_iCurSkillID == base.GetEntityData().runAttackID || BeActor.AttackComboSkillList.Contains(this.m_iCurSkillID)))
				{
					num = this.m_iCurSkillID;
				}
				if (base.TriggerEventNew(BeEventType.onSpecialSkillCombo, new EventParam
				{
					m_Int = num,
					m_Bool = false
				}).m_Bool)
				{
					return;
				}
				int num2 = this.CheckComboSkill(num);
				if (num2 > 0)
				{
					bool flag = false;
					if (BattleMain.IsModePvP(base.battleType) || !this.attackReplaceLigui)
					{
						BeSkill skill = this.GetSkill(base.GetEntityData().normalAttackID);
						if (skill != null && skill.CanInterrupt(this.m_iCurSkillID, false))
						{
							this.UseSkill(base.GetEntityData().normalAttackID, false);
							flag = true;
						}
					}
					if (!flag)
					{
						BeSkill skill2 = this.GetSkill(this.m_iCurSkillID);
						if (skill2 != null && skill2.isComboSkill)
						{
							skill2.cancelByCombo = true;
							skill2.OnComboBreak();
						}
						if (this.m_iCurSkillID == 1909)
						{
							BeSkill skill3 = this.GetSkill(num2);
							if (skill3 != null && skill2 != null && this.m_iCurSkillID != skill3.comboSkillSourceID)
							{
								return;
							}
						}
						this.CastSkill(num2);
					}
				}
				else if (base.sgGetCurrentState() != 14)
				{
					this.UseSkill(num, false);
				}
			}
		}
	}

	// Token: 0x06016BC7 RID: 93127 RVA: 0x006F4D82 File Offset: 0x006F3182
	public sealed override bool _isCmdMoveForbiden()
	{
		return this.controller == null && base._isCmdMoveForbiden();
	}

	// Token: 0x06016BC8 RID: 93128 RVA: 0x006F4D98 File Offset: 0x006F3198
	public sealed override bool IsAttackAdd2Statistics()
	{
		if (!this.isMainActor)
		{
			BeEntityData entityData = base.GetEntityData();
			if (entityData == null)
			{
				return false;
			}
			if (!entityData.isSummonMonster)
			{
				return false;
			}
			BeActor beActor = base.GetOwner() as BeActor;
			if (beActor == null)
			{
				return false;
			}
			if (!beActor.isMainActor)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06016BC9 RID: 93129 RVA: 0x006F4DF0 File Offset: 0x006F31F0
	public sealed override bool UpdateGraphic(int iDeltaTime)
	{
		int accTime = iDeltaTime;
		if (this.effectTimeNeedChange)
		{
			accTime = iDeltaTime * this.speedAcc;
		}
		base._updateGraphic(iDeltaTime, accTime);
		this.UpdateMechanismsGraphic(iDeltaTime);
		this.UpdateSpirit();
		return true;
	}

	// Token: 0x06016BCA RID: 93130 RVA: 0x006F4E30 File Offset: 0x006F3230
	public sealed override void OnRemove(bool force = false)
	{
		base.OnRemove(force);
		this.actorTimeAcc = 0;
		if (this.actorData != null)
		{
			this.actorData.RemoveHandle();
		}
		if (this.skillDamageManager != null)
		{
			this.skillDamageManager.DeInit();
			this.skillDamageManager = null;
		}
	}

	// Token: 0x06016BCB RID: 93131 RVA: 0x006F4E80 File Offset: 0x006F3280
	public void _internalUpdate(int iDeltaTime)
	{
		this.effectTimeNeedChange = false;
		int num = iDeltaTime;
		this.speedAcc = VFactor.one;
		if (base.sgGetCurrentState() == 14 && !this.skillFreeTurnFace)
		{
			BeSkill currentSkill = this.GetCurrentSkill();
			if (currentSkill != null)
			{
				if (currentSkill.SkillNeedChagneSpeed() && !this.skillFreeTurnFace)
				{
					VFactor vfactor = currentSkill.GetSkillSpeedFactor();
					if (currentSkill.skillData != null && currentSkill.skillData.PhaseRelatedSpeed == 1)
					{
						if (this.m_cpkCurEntityActionInfo != null && this.m_cpkCurEntityActionInfo.relatedAttackSpeed)
						{
							vfactor *= VFactor.NewVFactor(this.m_cpkCurEntityActionInfo.attackSpeed, GlobalLogic.VALUE_1000);
							if (vfactor < BeActor.Skill_Speed_MIN)
							{
								vfactor = BeActor.Skill_Speed_MIN;
							}
						}
						else
						{
							vfactor = VFactor.NewVFactor(currentSkill.skillData.Speed, GlobalLogic.VALUE_1000);
						}
					}
					iDeltaTime *= vfactor;
					this.effectTimeNeedChange = true;
					this.speedAcc = vfactor;
				}
				base.SetZDimScaleFactor(currentSkill.GetSkillZDimFactor());
			}
		}
		else
		{
			base.SetZDimScaleFactor(VFactor.one);
			if (base.sgGetCurrentState() == 3 || base.sgGetCurrentState() == 2 || (this.skillFreeTurnFace && base.sgGetCurrentState() == 14) || (base.GetEntityData().isPet && (this.HasSpeed(base.moveXSpeed) || this.HasSpeed(base.moveYSpeed))))
			{
				BeEntityData entityData = base.GetEntityData();
				if (entityData != null)
				{
					iDeltaTime *= this.moveSpeedFactor;
					iDeltaTime = Mathf.Max(6, iDeltaTime);
				}
			}
		}
		this.actorTimeAcc = iDeltaTime;
		int num2 = 16;
		while (this.actorTimeAcc > 0)
		{
			int num3 = Mathf.Min(num2, this.actorTimeAcc);
			base.Update(num3);
			if (!base.IsDead())
			{
				base.UpdateRecover(num3);
				this.UpdateSpellBarsGraphic(num3);
				this.UpdateSpellBarsWithActor(num3);
				this.UpdateMechanismsImpactBySpeed(num3);
			}
			this.actorTimeAcc -= num2;
		}
		this.UpdateSpellBarsWithBuff(num);
		if (this.buffController != null)
		{
			this.buffController.UpdateBuff(num);
		}
		this.UpdateSkill(num);
		this.UpdateMechanisms(num);
		this.UpdateProtect(num);
		this.UpdatePet(num);
		this.UpdateActorData(num);
		this.UpdateMechanismList();
	}

	// Token: 0x06016BCC RID: 93132 RVA: 0x006F50D8 File Offset: 0x006F34D8
	public void UpdateSpirit()
	{
		if (this.spirit == null)
		{
			return;
		}
		Vector3 vector = base.GetPosition().vector3;
		this.spirit.SetFaceLeft(base.GetFace());
	}

	// Token: 0x06016BCD RID: 93133 RVA: 0x006F5111 File Offset: 0x006F3511
	public void ChangeRunMode(bool bRun)
	{
		if (this.forceRunMode)
		{
			bRun = true;
		}
		this.m_bInRunMode = bRun;
		if (this.m_bInRunMode)
		{
			this.doublePressRunLeft = base.GetFace();
		}
		this.RefreashSpeed();
	}

	// Token: 0x06016BCE RID: 93134 RVA: 0x006F5148 File Offset: 0x006F3548
	public void RefreshMoveSpeed()
	{
		this.moveSpeedFactor = VFactor.one;
		float num = 1f;
		BeEntityData entityData = base.GetEntityData();
		if (entityData != null)
		{
			this.moveSpeedFactor = new VFactor((long)entityData.GetMoveSpeed(), (long)GlobalLogic.VALUE_1000);
			num = (float)entityData.walkAnimationSpeedPercent / (float)GlobalLogic.VALUE_100;
		}
		ActionType iAction = (!this.m_bInRunMode) ? this.walkAction : this.runAction;
		float num2 = (!this.m_bInRunMode) ? this.walkSpeedFactor : this.runSpeedFactor;
		base.PlayAction(iAction, num2 * this.moveSpeedFactor.single * num, false);
		if (entityData != null && base.IsMonster())
		{
			this.moveSpeedFactor *= Global.Settings.monsterWalkSpeedFactor;
		}
	}

	// Token: 0x06016BCF RID: 93135 RVA: 0x006F521D File Offset: 0x006F361D
	public void RefreashSpeed()
	{
		if (this.m_bInRunMode)
		{
			base.speedConfig = this.runSpeed;
		}
		else
		{
			base.speedConfig = this.walkSpeed;
		}
	}

	// Token: 0x06016BD0 RID: 93136 RVA: 0x006F5247 File Offset: 0x006F3647
	public sealed override void _onReset()
	{
		this.attackButtonState = ButtonState.NONE;
	}

	// Token: 0x06016BD1 RID: 93137 RVA: 0x006F5250 File Offset: 0x006F3650
	public sealed override void _clearStates()
	{
		base._clearStates();
	}

	// Token: 0x06016BD2 RID: 93138 RVA: 0x006F5258 File Offset: 0x006F3658
	public void SetGrabInfo(BeActor grabber, BDGrabData grabData)
	{
		this.grabber = grabber;
		this.grabData = grabData;
	}

	// Token: 0x06016BD3 RID: 93139 RVA: 0x006F5268 File Offset: 0x006F3668
	public BeActor GetGrabber()
	{
		return this.grabber;
	}

	// Token: 0x06016BD4 RID: 93140 RVA: 0x006F5270 File Offset: 0x006F3670
	public BDGrabData GetGrabData()
	{
		return this.grabData;
	}

	// Token: 0x06016BD5 RID: 93141 RVA: 0x006F5278 File Offset: 0x006F3678
	public void ExecuteGrap()
	{
		BDGrabData bdgrabData = this.m_cpkCurEntityActionInfo.grabData;
		this.stateController.SetGrabStat(GrabState.GRAPING);
		for (int i = 0; i < this.m_vGrapedEntity.Count; i++)
		{
			BeActor beActor = this.m_vGrapedEntity[i] as BeActor;
			if (beActor != null && (!beActor.IsDead() || beActor.IsBoss() || beActor.deadType == DeadType.NORMAL))
			{
				if (bdgrabData.buffInfoId != 0)
				{
					beActor.buffController.TryAddBuff(bdgrabData.buffInfoId, null, false, null, 0);
				}
				beActor.isAbsorb = false;
				if (bdgrabData.grabMoveSpeed > 0f)
				{
					beActor.isAbsorb = true;
					beActor.absorbSpeed = new VInt(bdgrabData.grabMoveSpeed);
					VInt3 position = base.GetPosition();
					position.x += VInt.Float2VIntValue(bdgrabData.posx) * base._getFaceCoff();
					beActor.absorbTargetPos = position;
				}
				else
				{
					BeActor beActor2 = beActor;
					if (beActor2 != null)
					{
						beActor2.SetGrabInfo(this, bdgrabData);
					}
					beActor.RecordGrabPosition();
				}
				if (!this.IsSuplexGrap)
				{
					beActor.SetFace(beActor.GetPosition().x > base.GetPosition().x, false, false);
				}
				int[] array = new int[]
				{
					bdgrabData.duraction
				};
				base.TriggerEvent(BeEventType.onExcuteGrab, new object[]
				{
					this.m_iCurSkillID,
					beActor,
					array
				});
				beActor.TriggerEvent(BeEventType.onBeExcuteGrab, new object[]
				{
					this
				});
				beActor.Locomote(new BeStateData(15, bdgrabData.action, 0, 0, 0, array[0], true), false);
				beActor.RestoreWeight();
				beActor.stateController.SetGrabStat(GrabState.BEING_GRAB);
				BeActor beActor3 = beActor;
				if (bdgrabData.quickPressDismis && beActor3 != null)
				{
					beActor3.StartPressCount(BeActor.QuickPressType.GRAP, this);
				}
			}
		}
	}

	// Token: 0x06016BD6 RID: 93142 RVA: 0x006F5460 File Offset: 0x006F3860
	public sealed override void _onEnterFrame(int iFrame)
	{
		base._onEnterFrame(iFrame);
		if (this.m_cpkCurEntityActionFrameData != null)
		{
			if (this.m_cpkCurEntityActionFrameData.kFlag.HasFlag(2))
			{
				this.ExecuteGrap();
			}
			if (this.m_cpkCurEntityActionFrameData.kFlag.HasFlag(4))
			{
				this.EndGrap();
			}
		}
	}

	// Token: 0x06016BD7 RID: 93143 RVA: 0x006F54B8 File Offset: 0x006F38B8
	public void CastSkill(int skillID)
	{
		if (base.CurrentBeBattle != null && !base.CurrentBeBattle.FunctionIsOpen(BattleFlagType.ComboSkillNotClearPhaseBuffBug))
		{
			this.buffController.ClearPhaseDelete();
			this.buffController.ClearFinishDelete();
			this.buffController.ClearFinishDeleteAll();
		}
		this.ClearPhaseDelete();
		this.ClearFinishDeleteAll();
		base.ClearPhaseDeleteAudio();
		base.ClearSkillFinishDeleteAudio();
		this.m_iCurSkillID = skillID;
		BeSkill skill = this.GetSkill(skillID);
		if (skill != null)
		{
			skill.pressedForwardMove = base.IsPressForwardMoveCmd();
		}
		base.sgSwitchStates(new BeStateData(14, 0));
	}

	// Token: 0x06016BD8 RID: 93144 RVA: 0x006F5550 File Offset: 0x006F3950
	public bool isGraped(BeEntity entity)
	{
		for (int i = 0; i < this.m_vGrapedEntity.Count; i++)
		{
			if (this.m_vGrapedEntity[i] == entity)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06016BD9 RID: 93145 RVA: 0x006F5590 File Offset: 0x006F3990
	public bool checkGrap(BeEntity pkEntity)
	{
		if (this.m_cpkCurEntityActionFrameData != null && this.m_cpkCurEntityActionFrameData.kFlag != null && this.stateController != null && (this.m_cpkCurEntityActionFrameData.kFlag.HasFlag(1) || this.m_cpkCurEntityActionFrameData.kFlag.HasFlag(536870912) || this.m_cpkCurEntityActionFrameData.kFlag.HasFlag(1073741824) || this.stateController.CanGrap()))
		{
			this.hasAttackEntityOnGrabCheck = true;
		}
		if (!this._canGrap(pkEntity))
		{
			return false;
		}
		if (!this.m_cpkCurEntityActionFrameData.kFlag.HasFlag(1) && !this.m_cpkCurEntityActionFrameData.kFlag.HasFlag(536870912) && !this.m_cpkCurEntityActionFrameData.kFlag.HasFlag(1073741824) && !this.stateController.CanGrap())
		{
			return false;
		}
		if (this.isGraped(pkEntity) || this.m_vGrapedEntity.Count >= this.m_cpkCurEntityActionInfo.grabData.grabNum)
		{
			return true;
		}
		BeActor beActor = pkEntity as BeActor;
		if (beActor != null)
		{
			bool @bool = true;
			@bool = beActor.TriggerEventNew(BeEventType.OnJudgeGrab, new EventParam
			{
				m_Bool = @bool,
				m_Int = this.m_cpkCurEntityActionInfo.skillID,
				m_Obj = this
			}).m_Bool;
			if (!base.TriggerEventNew(BeEventType.OnSelfJudgeGrab, new EventParam
			{
				m_Bool = @bool,
				m_Int = this.m_cpkCurEntityActionInfo.skillID,
				m_Obj = beActor
			}).m_Bool)
			{
				return true;
			}
			if (this.m_cpkCurEntityActionInfo.grabData.notGrabBati && beActor.buffController.HaveBatiBuff())
			{
				return true;
			}
			int num = beActor.GetPosition().x - base.GetPosition().x;
			bool flag = (num >= 0 && beActor.GetFace()) || (num <= 0 && !beActor.GetFace());
			if (this.m_cpkCurEntityActionInfo.grabData.notGrabGeDang && beActor.buffController.HasBuffByID(50) != null && flag)
			{
				return true;
			}
		}
		BeStateControl stateController = pkEntity.stateController;
		if (stateController != null && !stateController.CanBeGrap())
		{
			return true;
		}
		this.m_vGrapedEntity.Add(pkEntity);
		if (beActor != null && !this.GrapedActorList.Contains(beActor))
		{
			if (this.m_cpkCurEntityActionInfo.grabData.buffInfoIDToOther != 0 && beActor.buffController != null)
			{
				beActor.buffController.TryAddBuff(this.m_cpkCurEntityActionInfo.grabData.buffInfoIDToOther, null, false, null, 0);
			}
			this.GrapedActorList.Add(beActor);
			base.TriggerEvent(BeEventType.OnGrab, new object[]
			{
				beActor
			});
		}
		if (stateController != null)
		{
			stateController.SetGrabStat(GrabState.WILL_BEGRAB);
		}
		if (this.m_cpkCurEntityActionInfo.grabData.buffInfoIdToSelf != 0 && this.GrapedActorList.Count > 0 && this.buffController != null)
		{
			this.graberBuffInfoIdToSelf = this.m_cpkCurEntityActionInfo.grabData.buffInfoIdToSelf;
			this.buffController.TryAddBuff(this.graberBuffInfoIdToSelf, null, false, null, 0);
		}
		if (this.m_cpkCurEntityActionFrameData.kFlag.HasFlag(1073741824) || this.stateController.CanGrap())
		{
			this.ExecuteGrap();
		}
		else if (this.m_cpkCurEntityActionFrameData.kFlag.HasFlag(536870912) && this.m_pkStateGraph != null)
		{
			(this.m_pkStateGraph as BeActorStateGraph).ExecuteNextPhaseSkill();
		}
		return true;
	}

	// Token: 0x06016BDA RID: 93146 RVA: 0x006F5968 File Offset: 0x006F3D68
	private bool _canGrap(BeEntity pkEntity)
	{
		return pkEntity != null && !pkEntity.IsGrabed() && this.m_cpkCurEntityActionInfo != null && this.m_cpkCurEntityActionFrameData != null && this.stateController != null && this.m_vGrapedEntity != null && this.m_cpkCurEntityActionFrameData.kFlag != null && this.m_cpkCurEntityActionInfo.grabData != null;
	}

	// Token: 0x06016BDB RID: 93147 RVA: 0x006F59E4 File Offset: 0x006F3DE4
	public void EndGrap()
	{
		this.stateController.SetGrabStat(GrabState.ENDGRAPING);
		if (this.m_vGrapedEntity.Count > 0)
		{
			for (int i = 0; i < this.m_vGrapedEntity.Count; i++)
			{
				BeEntity beEntity = this.m_vGrapedEntity[i];
				BeActor beActor = beEntity as BeActor;
				if (beActor != null)
				{
					beActor.EndPressCount();
				}
				beEntity.JugePositionAfterGrab();
			}
			if (this.m_cpkCurEntityActionInfo == null)
			{
				for (int j = 0; j < this.m_vGrapedEntity.Count; j++)
				{
					BeEntity beEntity2 = this.m_vGrapedEntity[j];
					BeActor beActor2 = beEntity2 as BeActor;
					if (beActor2 != null)
					{
						beActor2.SetGrabInfo(null, null);
						beActor2.grabPos = false;
					}
					if (!this.CannotFallHaveBuff101(beEntity2))
					{
						beEntity2.Locomote(new BeStateData(9, 0, 0, VInt.Float2VIntValue(1f), 0, GlobalLogic.VALUE_300, false), true);
					}
				}
				this.ClearGrapedEntity();
				return;
			}
			BDGrabData bdgrabData = this.m_cpkCurEntityActionInfo.grabData;
			int num = (bdgrabData.endForceType != 1) ? 4 : 9;
			int fTimeout = 0;
			for (int k = 0; k < this.m_vGrapedEntity.Count; k++)
			{
				BeActor beActor3 = this.m_vGrapedEntity[k] as BeActor;
				if (beActor3 != null && (beActor3.IsBoss() || beActor3.deadType == DeadType.NORMAL))
				{
					if (bdgrabData.buffInfoId != 0)
					{
						beActor3.buffController.RemoveBuffByBuffInfoID(bdgrabData.buffInfoId);
					}
					if (num == 4)
					{
						fTimeout = IntMath.Float2Int(this.m_cpkCurEntityActionInfo.hurtTime, GlobalLogic.VALUE_1000);
					}
					float f = bdgrabData.endForcey;
					if (beActor3.GetPosition().z > 0)
					{
						num = 9;
					}
					if (num == 9 && bdgrabData.endForcey <= 0f)
					{
						f = 0.01f;
					}
					if (this.m_iCurSkillID != 1818 && this.buffController.HasBuffByID(75) == null)
					{
						num = 9;
					}
					BeActor beActor4 = beActor3;
					if (beActor4 != null)
					{
						beActor4.SetGrabInfo(null, null);
					}
					if (!this.CannotFallHaveBuff101(beActor3))
					{
						base.TriggerEvent(BeEventType.onEndGrab, new object[]
						{
							beActor4,
							this.m_iCurSkillID
						});
						beActor3.Locomote(new BeStateData(num, 0, VInt.Float2VIntValue(bdgrabData.endForcex * (float)base._getFaceCoff()), VInt.Float2VIntValue(f), 0, fTimeout, false), true);
					}
				}
			}
			if (this.graberBuffInfoIdToSelf != 0 && this.buffController != null)
			{
				this.buffController.RemoveBuffByBuffInfoID(this.graberBuffInfoIdToSelf);
				this.graberBuffInfoIdToSelf = 0;
			}
			this.GrapedActorList.Clear();
			this.ClearGrapedEntity();
		}
	}

	// Token: 0x06016BDC RID: 93148 RVA: 0x006F5CBF File Offset: 0x006F40BF
	public void TryReleaseGrapedEntity()
	{
		if (this.m_pkStateGraph.CurrentStateHasExTag(8))
		{
			this.EndGrap();
		}
	}

	// Token: 0x06016BDD RID: 93149 RVA: 0x006F5CD8 File Offset: 0x006F40D8
	public sealed override void DoHurt(int value, List<int> attachValues = null, HitTextType type = HitTextType.NORMAL, BeEntity attacker = null, HitTextType typeForSpecialBuff = HitTextType.NORMAL, bool forceBuffHurt = false)
	{
		if (!this.stateController.CanBeHit() && !forceBuffHurt)
		{
			return;
		}
		if (base.GetEntityData() != null && base.GetEntityData().isPet)
		{
			return;
		}
		base.DoHurt(value, attachValues, type, attacker, typeForSpecialBuff, false);
	}

	// Token: 0x06016BDE RID: 93150 RVA: 0x006F5D27 File Offset: 0x006F4127
	public sealed override void _onHurtEntity(BeEntity pkEntity, VInt3 hitPos, int hurtID)
	{
		if (pkEntity == null)
		{
			return;
		}
		this.checkGrap(pkEntity);
		base._onHurtEntity(pkEntity, hitPos, hurtID);
	}

	// Token: 0x06016BDF RID: 93151 RVA: 0x006F5D41 File Offset: 0x006F4141
	public bool HasGrapedEntity()
	{
		return this.m_vGrapedEntity.Count > 0;
	}

	// Token: 0x06016BE0 RID: 93152 RVA: 0x006F5D51 File Offset: 0x006F4151
	public void ClearGrapedEntity()
	{
		this.hasAttackEntityOnGrabCheck = false;
		this.m_vGrapedEntity.Clear();
	}

	// Token: 0x06016BE1 RID: 93153 RVA: 0x006F5D65 File Offset: 0x006F4165
	public override void TriggerHitAfterDoHurt(BeActor target)
	{
		base.TriggerHitAfterDoHurt(target);
		this.buffController.TriggerBuffs(BuffCondition.HIT_TARGET, target, null);
	}

	// Token: 0x06016BE2 RID: 93154 RVA: 0x006F5D80 File Offset: 0x006F4180
	public int GenNewMonsterID(int mid, int level)
	{
		MonsterIDData monsterIDData = new MonsterIDData(mid);
		return monsterIDData.GenMonsterID(level);
	}

	// Token: 0x06016BE3 RID: 93155 RVA: 0x006F5D9C File Offset: 0x006F419C
	public int GetSummonNum(int summonID, int summonNum = 1, int numLimit = 0, int group = 0, int groupNumLimit = 0)
	{
		if (this.currentBeScene == null)
		{
			return 0;
		}
		int summonCountByID = this.currentBeScene.GetSummonCountByID(summonID, this);
		if (numLimit > 0 && summonCountByID + summonNum > numLimit)
		{
			summonNum = numLimit - summonCountByID;
		}
		if (summonNum > 0 && group > 0 && summonNum + this.groupSummonNum[group] > groupNumLimit)
		{
			summonNum = groupNumLimit - this.groupSummonNum[group];
		}
		return summonNum;
	}

	// Token: 0x06016BE4 RID: 93156 RVA: 0x006F5E28 File Offset: 0x006F4228
	public bool DoSummon(int summonID, int level = 1, EffectTable.eSummonPosType posType = EffectTable.eSummonPosType.FACE, IList<int> posType2 = null, int summonNum = 1, int numLimit = 0, int group = 0, int groupNumLimit = 0, int skillID = 0, bool related = false, int summonMonsterSkillLevel = 0, int existTime = 0, List<int> summonIDs = null, SummonDisplayType displayType = SummonDisplayType.NONE, object[] summoneds = null, bool isSameFace = true)
	{
		if (summonID <= 0 && summonIDs == null)
		{
			return false;
		}
		int originSummonId = summonID;
		summonNum = this.GetSummonNum(summonID, summonNum, numLimit, group, groupNumLimit);
		if (summonNum <= 0)
		{
			return false;
		}
		summonID = this.GenNewMonsterID(summonID, level);
		if (summonIDs != null)
		{
			for (int i = 0; i < summonIDs.Count; i++)
			{
				summonIDs[i] = this.GenNewMonsterID(summonIDs[i], level);
			}
		}
		bool isShowBlood = base.IsMonster();
		if (base.IsMonster())
		{
			BeUtility.AdjustMonsterDifficulty(ref base.GetEntityData().monsterID, ref summonID);
			if (summonIDs != null)
			{
				for (int j = 0; j < summonIDs.Count; j++)
				{
					int value = summonIDs[j];
					BeUtility.AdjustMonsterDifficulty(ref base.GetEntityData().monsterID, ref value);
					summonIDs[j] = value;
				}
			}
		}
		if (summonNum > 0)
		{
			for (int k = 0; k < summonNum; k++)
			{
				VInt3 vint = base.GetPosition();
				vint.z = 0;
				if (posType2 != null && posType2.Count > 1)
				{
					int num = posType2[1];
					if (posType2[0] == 1)
					{
						vint.x += ((!base.GetFace()) ? 1 : -1) * (k + 1) * num / GlobalLogic.VALUE_1000 * 10000;
						if (BeClientSwitch.FunctionIsOpen(ClientSwitchType.SummonNewFindPos))
						{
							vint = BeAIManager.FindStandPositionNew(vint, base.CurrentBeScene, base.GetFace(), false, 12);
						}
						else
						{
							vint = BeAIManager.FindStandPosition(vint, base.CurrentBeScene, base.GetFace(), false, 12);
						}
					}
					else if (posType2[0] == 2)
					{
						vint.x += ((!base.GetFace()) ? 1 : -1) * (k + 1) * num / GlobalLogic.VALUE_1000 * 10000;
					}
				}
				else if (posType == EffectTable.eSummonPosType.FACE)
				{
					vint.x += ((!base.GetFace()) ? 1 : -1) * (k + 1) * 10000;
					if (this.currentBeScene.IsInBlockPlayer(vint))
					{
						if (BeClientSwitch.FunctionIsOpen(ClientSwitchType.SummonNewFindPos))
						{
							vint = BeAIManager.FindStandPositionNew(base.GetPosition(), base.CurrentBeScene, base.GetFace(), false, 12);
						}
						else
						{
							vint = BeAIManager.FindStandPosition(base.GetPosition(), base.CurrentBeScene, base.GetFace(), false, 12);
						}
					}
				}
				else if (posType == EffectTable.eSummonPosType.FACE_FORCE)
				{
					vint.x += ((!base.GetFace()) ? 1 : -1) * (k + 1) * 10000;
				}
				else if (posType == EffectTable.eSummonPosType.FACE_BLACK)
				{
					vint.x += ((!base.GetFace()) ? 1 : -1) * (k + 1) * 10000;
					if (BeClientSwitch.FunctionIsOpen(ClientSwitchType.SummonNewFindPos))
					{
						vint = BeAIManager.FindStandPositionNew(vint, base.CurrentBeScene, base.GetFace(), true, 12);
					}
					else
					{
						vint = BeAIManager.FindStandPosition(vint, base.CurrentBeScene, base.GetFace(), true, 12);
					}
				}
				int[] array = new int[]
				{
					0
				};
				int num2 = summonID;
				if (summonIDs != null)
				{
					num2 = summonIDs[(int)base.FrameRandom.Random((uint)summonIDs.Count)];
				}
				base.TriggerEvent(BeEventType.onBeforeSummon, new object[]
				{
					array,
					num2
				});
				if (array[0] != 0)
				{
					num2 += GlobalLogic.VALUE_100 * array[0];
				}
				vint = base.TriggerEventNew(BeEventType.onBeforeSummon, new EventParam
				{
					m_Int = 0,
					m_Int2 = num2,
					m_Vint3 = vint
				}).m_Vint3;
				BeActor summonActor = this.currentBeScene.SummonMonster(num2, vint, this.m_iCamp, this, related, summonMonsterSkillLevel, isShowBlood, originSummonId, false, isSameFace);
				if (summonActor != null)
				{
					if (summoneds != null && summoneds.Length >= 1)
					{
						summoneds[0] = summonActor;
					}
					if (displayType == SummonDisplayType.FAZHEN)
					{
						this.owner.CurrentBeScene.currentGeScene.CreateEffect("Effects/Hero_Zhaohuanshi/Aosuo/Prefab/Eff_Zhaohuanaosuo_dimian_guo", 0f, summonActor.GetPosition().vec3, 1f, 1f, false, false);
					}
					summonActor.delayCaller.DelayCall(10, delegate
					{
						summonActor.buffController.TryAddBuff(31, GlobalLogic.VALUE_1000, 1);
					}, 0, 0, false);
					int[] array2 = new int[]
					{
						GlobalLogic.VALUE_1000
					};
					base.TriggerEvent(BeEventType.onChangeSummonScale, new object[]
					{
						summonActor,
						array2
					});
					int i2 = summonActor.GetScale().i * VFactor.NewVFactor(array2[0], GlobalLogic.VALUE_1000);
					summonActor.SetScale(i2);
					summonActor.attribute.isSpecialAPC = this.attribute.isSpecialAPC;
					base.TriggerEvent(BeEventType.onSummon, new object[]
					{
						summonActor,
						skillID
					});
					int[] array3 = new int[]
					{
						existTime,
						GlobalLogic.VALUE_1000
					};
					base.TriggerEvent(BeEventType.onChangeSummonLifeTime, new object[]
					{
						summonActor,
						array3
					});
					existTime = array3[0] * VFactor.NewVFactor(array3[1], GlobalLogic.VALUE_1000);
					if (existTime > 0)
					{
						summonActor.buffController.TryAddBuff(12, existTime, 1);
					}
					if (group > 0)
					{
						CrypticInt32[] array4 = this.groupSummonNum;
						int group2 = group;
						array4[group2]++;
						summonActor.summonNumHandle = summonActor.RegisterEvent(BeEventType.onDead, delegate(object[] args)
						{
							if (summonActor.summonNumHandle != null)
							{
								summonActor.summonNumHandle.Remove();
								summonActor.summonNumHandle = null;
							}
							CrypticInt32[] array5 = this.groupSummonNum;
							int group3 = group;
							array5[group3]--;
						});
					}
				}
			}
			return true;
		}
		return false;
	}

	// Token: 0x06016BE5 RID: 93157 RVA: 0x006F645C File Offset: 0x006F485C
	public sealed override bool TrySummon(EffectTable hurtData)
	{
		int summonID = hurtData.SummonID;
		if (summonID <= 0 && hurtData.SummonRandList[0] <= 0)
		{
			return false;
		}
		int skillLevel = this.GetSkillLevel(hurtData.SkillID);
		int num;
		if (BattleMain.IsChijiNeedReplaceHurtId(hurtData.ID, base.battleType))
		{
			ChijiEffectMapTable tableItem = Singleton<TableManager>.instance.GetTableItem<ChijiEffectMapTable>(hurtData.ID, string.Empty, string.Empty);
			num = TableManager.GetValueFromUnionCell(tableItem.SummonLevel, skillLevel, true);
		}
		else
		{
			num = TableManager.GetValueFromUnionCell(hurtData.SummonLevel, skillLevel, true);
		}
		int num2 = TableManager.GetValueFromUnionCell(hurtData.SummonNum, skillLevel, true);
		int num3 = hurtData.SummonNumLimit;
		int valueFromUnionCell = TableManager.GetValueFromUnionCell(hurtData.SummonGroupNumLimit, skillLevel, true);
		int summonGroup = hurtData.SummonGroup;
		bool flag = hurtData.SummonRelation != 0;
		int summonMonsterSkillLevel = 0;
		if (flag)
		{
			summonMonsterSkillLevel = skillLevel;
		}
		if (num <= 0)
		{
			num = skillLevel;
		}
		bool flag2 = hurtData.KillLastSummon != 0;
		if (flag2)
		{
			List<BeActor> list = ListPool<BeActor>.Get();
			this.owner.CurrentBeScene.FindActorById(list, summonID);
			if (list.Count > 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].owner == this.owner)
					{
						list[i].DoDead(false);
					}
				}
			}
			ListPool<BeActor>.Release(list);
		}
		List<int> list2 = null;
		if (hurtData.SummonRandList[0] > 0)
		{
			list2 = new List<int>();
			for (int j = 0; j < hurtData.SummonRandList.Count; j++)
			{
				list2.Add(hurtData.SummonRandList[j]);
			}
		}
		int[] array = new int[]
		{
			num2
		};
		this.owner.TriggerEvent(BeEventType.onChangeSummonNum, new object[]
		{
			hurtData.ID,
			-1,
			array
		});
		num2 = array[0];
		int[] array2 = new int[]
		{
			num3
		};
		this.owner.TriggerEvent(BeEventType.onChangeSummonNumLimit, new object[]
		{
			hurtData.ID,
			-1,
			array2
		});
		num3 = array2[0];
		return this.DoSummon(summonID, num, hurtData.SummonPosType, hurtData.SummonPosType2, num2, num3, summonGroup, valueFromUnionCell, hurtData.SkillID, flag, summonMonsterSkillLevel, 0, list2, (SummonDisplayType)hurtData.SummonDisplay, null, true);
	}

	// Token: 0x06016BE6 RID: 93158 RVA: 0x006F66D4 File Offset: 0x006F4AD4
	public override void TryAddMechanism(int mechanismId)
	{
		if (mechanismId == 0)
		{
			return;
		}
		base.TryAddMechanism(mechanismId);
		BeMechanism beMechanism = this.AddMechanism(mechanismId, 0, MechanismSourceType.NONE, null, 0);
		if (beMechanism != null && this.mechanismList.Contains(beMechanism))
		{
			this.RemoveMechanism(beMechanism);
		}
	}

	// Token: 0x06016BE7 RID: 93159 RVA: 0x006F671C File Offset: 0x006F4B1C
	public int TryGetBuffEnhanceLevel(int buffID, int skillID = 0)
	{
		int num = 0;
		if (buffID > 0)
		{
			if (this.buffEnhanceList.ContainsKey(buffID))
			{
				num += this.buffEnhanceList[buffID].level;
			}
			if (skillID > 0)
			{
				BeSkill skill = this.GetSkill(skillID);
				if (skill != null)
				{
					BuffInfoData buffInfo = skill.GetBuffInfo(buffID);
					if (buffInfo != null)
					{
						num += buffInfo.level;
					}
				}
			}
		}
		return num;
	}

	// Token: 0x06016BE8 RID: 93160 RVA: 0x006F6790 File Offset: 0x006F4B90
	public sealed override bool TryAddBuff(EffectTable hurtData, BeEntity target = null, int duration = 0, bool useBuffAni = true, bool finishDelete = false, bool finishDeleteAll = false)
	{
		List<BuffInfoData> list = new List<BuffInfoData>();
		int skillID = (hurtData.SkillID != 0) ? hurtData.SkillID : this.m_iCurSkillID;
		int skillLevel = this.GetSkillLevel(skillID);
		if (hurtData.BuffID > 0 && this.attribute != null && !this.attribute.isSpecialAPC)
		{
			int num = skillLevel;
			ChijiEffectMapTable chijiEffectMapTable = null;
			int num2;
			int num3;
			if (BattleMain.IsChijiNeedReplaceHurtId(hurtData.ID, base.battleType))
			{
				chijiEffectMapTable = Singleton<TableManager>.instance.GetTableItem<ChijiEffectMapTable>(hurtData.ID, string.Empty, string.Empty);
				num2 = TableManager.GetValueFromUnionCell(chijiEffectMapTable.BuffLevel, num, true);
				num3 = TableManager.GetValueFromUnionCell(chijiEffectMapTable.AttachBuffRate, num, true);
			}
			else
			{
				num3 = TableManager.GetValueFromUnionCell(hurtData.AttachBuffRate, num, true);
				num2 = TableManager.GetValueFromUnionCell(hurtData.BuffLevel, num, true);
			}
			int num4 = this.TryGetBuffEnhanceLevel(hurtData.BuffID, skillID);
			num2 += num4;
			int[] array = new int[]
			{
				0
			};
			this.owner.TriggerEvent(BeEventType.onChangeBuffLevel, new object[]
			{
				hurtData.ID,
				0,
				array,
				this.owner
			});
			num += array[0];
			if (num < 1)
			{
				num = 1;
			}
			num2 += array[0];
			if (num2 < 1)
			{
				num2 = 1;
			}
			int num5;
			if (duration > 0)
			{
				num5 = duration;
			}
			else if (duration == -1)
			{
				num5 = int.MaxValue;
			}
			else
			{
				if (chijiEffectMapTable != null)
				{
					num5 = TableManager.GetValueFromUnionCell(chijiEffectMapTable.AttachBuffTime, num, true);
				}
				else
				{
					num5 = TableManager.GetValueFromUnionCell(hurtData.AttachBuffTime, num, true);
				}
				if (num5 == -1)
				{
					num5 = int.MaxValue;
				}
			}
			int[] array2 = new int[]
			{
				num3
			};
			this.owner.TriggerEvent(BeEventType.onChangeBuffAttackRate, new object[]
			{
				BuffAttachType.EFFECTTABLE,
				hurtData.ID,
				array2,
				this.owner
			});
			num3 = array2[0];
			int[] array3 = new int[]
			{
				num5
			};
			this.owner.TriggerEvent(BeEventType.OnChangeEffectTime, new object[]
			{
				hurtData.ID,
				array3
			});
			num5 = array3[0];
			int num6;
			if (chijiEffectMapTable != null)
			{
				num6 = TableManager.GetValueFromUnionCell(chijiEffectMapTable.BuffAttack, num, true);
			}
			else
			{
				num6 = TableManager.GetValueFromUnionCell(hurtData.BuffAttack, num, true);
			}
			int[] array4 = new int[]
			{
				GlobalLogic.VALUE_1000
			};
			this.owner.TriggerEvent(BeEventType.onChangeBuffAttack, new object[]
			{
				hurtData.ID,
				0,
				array4,
				this.owner
			});
			num6 *= VFactor.NewVFactor(array4[0], GlobalLogic.VALUE_1000);
			BuffInfoData item2 = new BuffInfoData
			{
				buffID = hurtData.BuffID,
				level = num,
				duration = num5,
				prob = num3,
				attack = num6,
				target = ((hurtData.BuffTarget != EffectTable.eBuffTarget.SELF) ? BuffTarget.ENEMY : BuffTarget.SELF),
				abnormalLevel = num2
			};
			list.Add(item2);
		}
		FlatBufferArray<int> flatBufferArray = hurtData.BuffInfoID;
		if (BattleMain.IsModePvP(base.battleType) && hurtData.PVPBuffInfoID.Count > 0 && hurtData.PVPBuffInfoID[0] > 0)
		{
			list.Clear();
			if (BattleMain.IsChijiNeedReplaceHurtId(hurtData.ID, base.battleType))
			{
				ChijiEffectMapTable tableItem = Singleton<TableManager>.instance.GetTableItem<ChijiEffectMapTable>(hurtData.ID, string.Empty, string.Empty);
				flatBufferArray = tableItem.PVPBuffInfoID;
			}
			else
			{
				flatBufferArray = hurtData.PVPBuffInfoID;
			}
		}
		for (int i = 0; i < flatBufferArray.Count; i++)
		{
			if (flatBufferArray[i] > 0)
			{
				int num7 = this.TryGetBuffEnhanceLevel(hurtData.BuffID, skillID);
				BuffInfoData buffInfoData = new BuffInfoData(flatBufferArray[i], skillLevel, 0);
				BuffInfoData buffInfoData2 = buffInfoData;
				buffInfoData2.abnormalLevel += num7;
				list.Add(buffInfoData);
			}
		}
		bool result = false;
		for (int j = 0; j < list.Count; j++)
		{
			BuffInfoData buffInfoData3 = list[j];
			BeSkill skill = this.GetSkill(skillID);
			if (skill != null)
			{
				BuffInfoData buffInfo = skill.GetBuffInfo(hurtData.BuffID);
				if (buffInfo != null)
				{
					buffInfoData3.DoEnhance(buffInfo, false);
				}
			}
			if (this.buffEnhanceList.ContainsKey(buffInfoData3.buffID))
			{
				buffInfoData3.DoEnhance(this.buffEnhanceList[buffInfoData3.buffID], false);
			}
			int[] array5 = new int[]
			{
				GlobalLogic.VALUE_1000
			};
			this.owner.TriggerEvent(BeEventType.onChangeBuffTargetRadius, new object[]
			{
				buffInfoData3.buffInfoID,
				array5
			});
			BuffInfoData buffInfoData4 = buffInfoData3;
			buffInfoData4.buffTargetRangeRadius *= VFactor.NewVFactor(array5[0], GlobalLogic.VALUE_1000);
			if (this.CheckIsRangeBuffInfo(buffInfoData3))
			{
				List<BeActor> list2 = ListPool<BeActor>.Get();
				if (buffInfoData3.target == BuffTarget.RANGE_ENEMY)
				{
					base.CurrentBeScene.FindTargets(list2, this, VInt.NewVInt(buffInfoData3.buffTargetRangeRadius, GlobalLogic.VALUE_1000), false, null);
				}
				else if (buffInfoData3.target == BuffTarget.RANGE_FRIEND)
				{
					base.CurrentBeScene.FindTargets(list2, this, VInt.NewVInt(buffInfoData3.buffTargetRangeRadius, GlobalLogic.VALUE_1000), true, null);
					list2.RemoveAll((BeActor item) => item == this);
				}
				else if (buffInfoData3.target == BuffTarget.RANGE_FRIEND_ADNSELF)
				{
					base.CurrentBeScene.FindTargets(list2, this, VInt.NewVInt(buffInfoData3.buffTargetRangeRadius, GlobalLogic.VALUE_1000), true, null);
				}
				else if (buffInfoData3.target == BuffTarget.RANGE_FRIENDHERO)
				{
					BeUtility.GetAllFriendPlayers(this, list2);
				}
				else if (buffInfoData3.target == BuffTarget.RANGE_ENEMYHERO)
				{
					BeUtility.GetAllEnemyPlayers(this, list2);
				}
				else if (buffInfoData3.target == BuffTarget.RANGE_FRIEND_NOTSUMMON)
				{
					BeGetRangeFriendNotSummon filter = new BeGetRangeFriendNotSummon();
					base.CurrentBeScene.FindTargets(list2, this, VInt.NewVInt(buffInfoData3.buffTargetRangeRadius, GlobalLogic.VALUE_1000), true, filter);
				}
				else if (buffInfoData3.target == BuffTarget.OUT_OF_RANGE_ENEMY)
				{
					BeGetConcentricCircleTarget beGetConcentricCircleTarget = new BeGetConcentricCircleTarget();
					beGetConcentricCircleTarget.m_Owner = this;
					beGetConcentricCircleTarget.m_OwnerPosXY = new VInt2(base.GetPosition().x, base.GetPosition().y);
					beGetConcentricCircleTarget.m_MinCircleRadius = VInt.NewVInt(buffInfoData3.buffTargetRangeRadius, GlobalLogic.VALUE_1000);
					beGetConcentricCircleTarget.m_MaxCircleRadius = BeGetConcentricCircleTarget.LargeMaxCirleRadius;
					base.CurrentBeScene.GetFilterTarget(list2, beGetConcentricCircleTarget, true);
				}
				if (list2 != null)
				{
					for (int k = 0; k < list2.Count; k++)
					{
						if (list2[k] != null)
						{
							list2[k].buffController.TryAddBuff(buffInfoData3, this, false, default(VRate), this);
						}
					}
				}
				ListPool<BeActor>.Release(list2);
			}
			else
			{
				BeActor beActor = target as BeActor;
				if (buffInfoData3.target == BuffTarget.SELF)
				{
					beActor = this;
				}
				if (beActor != null)
				{
					BeBuff beBuff = beActor.buffController.TryAddBuff(buffInfoData3, this, useBuffAni, default(VRate), this);
					if (beBuff != null)
					{
						beBuff.SetBuffReleaser(this);
					}
					if (beBuff != null && duration == -1)
					{
						beActor.buffController.AddPhaseDelete(beBuff);
					}
					if (beBuff != null && finishDelete)
					{
						beActor.buffController.AddFinishDelete(beBuff);
					}
					if (beBuff != null && finishDeleteAll)
					{
						beActor.buffController.AddFinishDeleteAll(beBuff);
					}
					result = true;
				}
			}
		}
		return result;
	}

	// Token: 0x06016BE9 RID: 93161 RVA: 0x006F6FB0 File Offset: 0x006F53B0
	private bool CheckIsRangeBuffInfo(BuffInfoData info)
	{
		return info != null && (info.target == BuffTarget.RANGE_ENEMY || info.target == BuffTarget.RANGE_FRIEND || info.target == BuffTarget.RANGE_FRIEND_ADNSELF || info.target == BuffTarget.OUT_OF_RANGE_ENEMY || info.target == BuffTarget.RANGE_FRIENDHERO || info.target == BuffTarget.RANGE_ENEMYHERO || info.target == BuffTarget.RANGE_FRIEND_NOTSUMMON);
	}

	// Token: 0x06016BEA RID: 93162 RVA: 0x006F7028 File Offset: 0x006F5428
	public sealed override bool TryAddEntity(EffectTable hurtData, VInt3 pos, int triggeredLevel = 1)
	{
		for (int i = 0; i < hurtData.AttachEntity.Count; i++)
		{
			int num = hurtData.AttachEntity[i];
			if (num > 0)
			{
				this.AddEntity(num, pos, triggeredLevel, 0);
			}
		}
		return false;
	}

	// Token: 0x06016BEB RID: 93163 RVA: 0x006F7078 File Offset: 0x006F5478
	public BeEntity AddEntity(int entityID, VInt3 pos, int triggerSkillLevel = 1, int lifeTime = 0)
	{
		if (this.currentBeScene == null)
		{
			return null;
		}
		BeProjectile beProjectile = this.currentBeScene.AddProjectile(entityID, this.m_iCamp, 1, lifeTime, triggerSkillLevel, this, -1, this.m_pkGeActor != null && this.m_pkGeActor.GetUseCube());
		beProjectile.attribute = this.attribute;
		beProjectile.totoalHitCount = 99999;
		beProjectile.needSetFace = true;
		beProjectile.SetFace(base.GetFace(), false, false);
		beProjectile.SetPosition(pos, false, true);
		beProjectile.SetZDimScaleFactor(beProjectile.GetProjectileZDimScale());
		beProjectile.SetScale(base.GetScale().i * beProjectile.GetProjectileScale());
		beProjectile._updateGraphicActor(false);
		beProjectile.InitLocalRotation();
		beProjectile.RecordOriginPosition();
		base.TriggerEvent(BeEventType.onAfterGenBullet, new object[]
		{
			beProjectile
		});
		return beProjectile;
	}

	// Token: 0x06016BEC RID: 93164 RVA: 0x006F7158 File Offset: 0x006F5558
	public void DealBeforeGetDamage(BeEntity target, AttackResult result, int hurtID, bool isBackHit = false, int projectileResId = 0)
	{
		EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(hurtID, string.Empty, string.Empty);
		if (tableItem != null && result != AttackResult.MISS)
		{
			BeSkill skill = this.GetSkill(tableItem.SkillID);
			if (skill != null)
			{
				skill.hit = true;
			}
		}
		bool flag = true;
		if (tableItem != null && tableItem.IsFriendDamage > 0)
		{
			flag = false;
		}
		if (flag)
		{
			this.buffController.TriggerBuffs(BuffCondition.ATTACK, target as BeActor, null);
		}
		if (tableItem.DamageDistanceType == EffectTable.eDamageDistanceType.NEAR)
		{
			this.buffController.TriggerBuffs(BuffCondition.NEARATTACK, target as BeActor, null);
		}
		else if (tableItem.DamageDistanceType == EffectTable.eDamageDistanceType.FAR)
		{
			this.buffController.TriggerBuffs(BuffCondition.FARATTACK, target as BeActor, null);
		}
		MagicElementType attackElementType = this.attribute.GetAttackElementType(hurtID);
		if (attackElementType != MagicElementType.NONE)
		{
			BuffCondition condition = BuffCondition.LIGHTATTACK;
			switch (attackElementType)
			{
			case MagicElementType.LIGHT:
				condition = BuffCondition.LIGHTATTACK;
				break;
			case MagicElementType.FIRE:
				condition = BuffCondition.FIREATTACK;
				break;
			case MagicElementType.ICE:
				condition = BuffCondition.ICEATTACK;
				break;
			case MagicElementType.DARK:
				condition = BuffCondition.DARKATTACK;
				break;
			}
			this.buffController.TriggerBuffs(condition, target as BeActor, null);
		}
		this.buffController.TriggerBuffs(BuffCondition.RELEASE_SEPCIFY_SKILL_HIT, target as BeActor, this.m_iCurSkillID);
		if (result == AttackResult.CRITICAL)
		{
			this.buffController.TriggerBuffs(BuffCondition.CRITICAL_HIT, target as BeActor, null);
			base.TriggerEvent(BeEventType.onHitCriticalBeforDamage, null);
			BeActor beActor = target as BeActor;
			if (beActor != null)
			{
				beActor.buffController.TriggerBuffs(BuffCondition.BE_CRITICAL_HIT, this, null);
			}
		}
		if (isBackHit)
		{
			this.buffController.TriggerBuffs(BuffCondition.BACK_HIT, target as BeActor, null);
			BeActor beActor2 = target as BeActor;
			if (beActor2 != null)
			{
				beActor2.buffController.TriggerBuffs(BuffCondition.BE_BACK_HIT, this, null);
			}
		}
		base.TriggerEvent(BeEventType.onBeforeHit, new object[]
		{
			target,
			projectileResId,
			tableItem.ID,
			tableItem.SkillID
		});
		target.TriggerEvent(BeEventType.onBeforeOtherHit, new object[]
		{
			this,
			tableItem
		});
		BeActor beActor3 = target as BeActor;
		if (beActor3 != null)
		{
			beActor3.buffController.TriggerBuffs(BuffCondition.BEHIT, this, null);
		}
		if (this.CheckCanBreakAction(target, tableItem))
		{
			base.TriggerEvent(BeEventType.onBreakAction, null);
			this.buffController.TriggerBuffs(BuffCondition.BREAK_ACTION, target as BeActor, null);
			if (this != null && this.isLocalActor)
			{
				this.m_pkGeActor.CreateHeadText(HitTextType.SPECIAL_ATTACK, "UI/Font/new_font/pic_break_action", false, null);
			}
		}
	}

	// Token: 0x06016BED RID: 93165 RVA: 0x006F73E0 File Offset: 0x006F57E0
	public bool CheckCanBreakAction(BeEntity target, EffectTable hurtData)
	{
		return ((base.battleType == BattleType.TrainingPVE && this.absoluteBroken) || (target.sgGetCurrentState() == 14 && (hurtData == null || (hurtData != null && hurtData.IsFriendDamage == 0)))) && !target.TriggerEventNew(BeEventType.onBreakActionChangeEvent, new EventParam
		{
			m_Bool = false
		}).m_Bool;
	}

	// Token: 0x06016BEE RID: 93166 RVA: 0x006F7452 File Offset: 0x006F5852
	public sealed override void OnBeforeGetDamage(BeEntity target, AttackResult result, bool isBackHit, int hurtID)
	{
		this.DealBeforeGetDamage(target, result, hurtID, isBackHit, 0);
	}

	// Token: 0x06016BEF RID: 93167 RVA: 0x006F7460 File Offset: 0x006F5860
	public sealed override void ShowMissEffect(Vec3 Pos)
	{
		if (this.isMainActor)
		{
			string effectPath = "Effects/Common/Sfx/Hit/Prefab/Eff_hit_miss_newguo";
			this.currentBeScene.currentGeScene.CreateEffect(effectPath, 0f, Pos, 1f, 1f, false, base.GetFace());
		}
	}

	// Token: 0x06016BF0 RID: 93168 RVA: 0x006F74A7 File Offset: 0x006F58A7
	public sealed override void ShowHitEffect(Vec3 Pos, BeEntity target, int hurtID)
	{
		base.ShowHitEffect(Pos, target, hurtID);
	}

	// Token: 0x06016BF1 RID: 93169 RVA: 0x006F74B4 File Offset: 0x006F58B4
	public sealed override void OnDealHit(BeEntity pkEntity)
	{
		BeActor beActor = pkEntity as BeActor;
		if (beActor == null)
		{
			return;
		}
		if (beActor.IsMonster())
		{
			beActor.AddShock(Global.Settings.monsterBeHitShockData);
		}
		else
		{
			beActor.AddShock(Global.Settings.playerBeHitShockData);
		}
	}

	// Token: 0x06016BF2 RID: 93170 RVA: 0x006F7500 File Offset: 0x006F5900
	public sealed override void onHitEntity(BeEntity pkEntity, VInt3 pos, int hurtID = 0, AttackResult result = AttackResult.MISS, int finalDamage = 0)
	{
		base.onHitEntity(pkEntity, pos, hurtID, result, finalDamage);
		if (result != AttackResult.MISS)
		{
			BeActor beActor = pkEntity as BeActor;
			if (beActor == null)
			{
				return;
			}
			if (beActor.GetEntityData() != null && beActor.GetEntityData().hitID > 0 && (beActor.GetEntityData().type == 3 || beActor.GetEntityData().type == 1 || beActor.GetEntityData().type == 2) && (int)base.FrameRandom.Random((uint)GlobalLogic.VALUE_1000) < beActor.GetEntityData().hitIDRand && beActor.sgGetCurrentState() == 4 && beActor.GetPosition().z <= 0 && !beActor.stateController.HasBuffState(BeBuffStateType.FROZEN) && !beActor.stateController.HasBuffState(BeBuffStateType.STONE) && !beActor.stateController.HasBuffState(BeBuffStateType.STUN))
			{
				beActor.UseSkill(beActor.GetEntityData().hitID, true);
			}
		}
	}

	// Token: 0x06016BF3 RID: 93171 RVA: 0x006F7610 File Offset: 0x006F5A10
	public int GetSkillLevel(int skillID)
	{
		int result = 0;
		BeSkill skill = this.GetSkill(skillID);
		if (skill != null)
		{
			result = skill.GetLevel();
		}
		return result;
	}

	// Token: 0x06016BF4 RID: 93172 RVA: 0x006F7638 File Offset: 0x006F5A38
	public bool CanJump()
	{
		if (base.moveZSpeed != 0)
		{
			return false;
		}
		ActionState actionState = (ActionState)base.sgGetCurrentState();
		return actionState == ActionState.AS_IDLE || actionState == ActionState.AS_WALK || actionState == ActionState.AS_RUN;
	}

	// Token: 0x06016BF5 RID: 93173 RVA: 0x006F7678 File Offset: 0x006F5A78
	public bool CanJumpBack()
	{
		if (base.moveZSpeed != 0)
		{
			return false;
		}
		ActionState actionState = (ActionState)base.sgGetCurrentState();
		if (actionState == ActionState.AS_IDLE || actionState == ActionState.AS_WALK || actionState == ActionState.AS_RUN)
		{
			return true;
		}
		if (actionState == ActionState.AS_CASTSKILL)
		{
			BeSkill skill = this.GetSkill(this.m_iCurSkillID);
			if (skill != null)
			{
				bool flag = skill.CanBePositiveAbort() || BeActor.LiGuiSkillList.Contains(this.m_iCurSkillID);
				if (flag)
				{
					this.m_pkGeActor.CreateSnapshot(Color.white, Global.Settings.snapDuration, string.Empty);
				}
				return flag;
			}
		}
		return false;
	}

	// Token: 0x06016BF6 RID: 93174 RVA: 0x006F771C File Offset: 0x006F5B1C
	public void AddSkillMechanism(int id, int time, int level, bool isPhaseDelete, bool isFinishDelete)
	{
		BeMechanism item = this.AddMechanism(id, level, MechanismSourceType.NONE, null, time);
		if (isPhaseDelete)
		{
			this.phaseDeleteMechanismList.Add(item);
		}
		if (isFinishDelete)
		{
			this.finishDeleteMechanismList.Add(item);
		}
	}

	// Token: 0x06016BF7 RID: 93175 RVA: 0x006F775B File Offset: 0x006F5B5B
	public void ClearPhaseDelete()
	{
		this.ClearMechanisms(this.phaseDeleteMechanismList);
	}

	// Token: 0x06016BF8 RID: 93176 RVA: 0x006F7769 File Offset: 0x006F5B69
	public void ClearFinishDeleteAll()
	{
		this.ClearMechanisms(this.finishDeleteMechanismList);
	}

	// Token: 0x06016BF9 RID: 93177 RVA: 0x006F7778 File Offset: 0x006F5B78
	private void ClearMechanisms(List<BeMechanism> list)
	{
		for (int i = 0; i < list.Count; i++)
		{
			BeMechanism beMechanism = list[i];
			if (beMechanism != null && beMechanism.isRunning)
			{
				beMechanism.Finish();
			}
		}
		list.Clear();
	}

	// Token: 0x06016BFA RID: 93178 RVA: 0x006F77C4 File Offset: 0x006F5BC4
	public BeMechanism AddMechanism(int mid, int level = 0, MechanismSourceType sourceType = MechanismSourceType.NONE, BeBuff buff = null, int time = 0)
	{
		if (mid > 0)
		{
			BeMechanism cannotRemoveExist = this.GetCannotRemoveExist(mid);
			if (cannotRemoveExist != null)
			{
				return cannotRemoveExist;
			}
			BeMechanism beMechanism = BeMechanism.Create(mid, level);
			if (beMechanism != null)
			{
				beMechanism.owner = this;
				beMechanism.attachBuff = buff;
				beMechanism.Init(time);
				beMechanism.Start();
				this.mechanismList.Add(beMechanism);
				beMechanism.sourceType = sourceType;
				base.TriggerEvent(BeEventType.onAddMechanism, new object[]
				{
					mid
				});
				return beMechanism;
			}
		}
		return null;
	}

	// Token: 0x06016BFB RID: 93179 RVA: 0x006F7844 File Offset: 0x006F5C44
	private BeMechanism GetCannotRemoveExist(int id)
	{
		BeMechanism mechanism = this.GetMechanism(id);
		if (mechanism != null && !mechanism.canRemove)
		{
			return mechanism;
		}
		return null;
	}

	// Token: 0x06016BFC RID: 93180 RVA: 0x006F7870 File Offset: 0x006F5C70
	public void LoadMechanisms(IList<int> mIDs, int level = 0, MechanismSourceType sourceType = MechanismSourceType.NONE)
	{
		if (mIDs == null)
		{
			return;
		}
		for (int i = 0; i < mIDs.Count; i++)
		{
			int num = mIDs[i];
			if (num > 0)
			{
				this.AddMechanism(num, level, sourceType, null, 0);
			}
		}
	}

	// Token: 0x06016BFD RID: 93181 RVA: 0x006F78B6 File Offset: 0x006F5CB6
	private void UpdateMechanismList()
	{
		this.mechanismList.RemoveAll(delegate(BeMechanism item)
		{
			if (!item.isRunning && item.canRemove)
			{
				item = null;
				return true;
			}
			return false;
		});
	}

	// Token: 0x06016BFE RID: 93182 RVA: 0x006F78E4 File Offset: 0x006F5CE4
	public void RemoveMechanisms(IList<int> mIDs)
	{
		if (mIDs == null)
		{
			return;
		}
		for (int i = 0; i < mIDs.Count; i++)
		{
			if (mIDs[i] > 0)
			{
				this.RemoveMechanism(mIDs[i]);
			}
		}
	}

	// Token: 0x06016BFF RID: 93183 RVA: 0x006F792C File Offset: 0x006F5D2C
	public void RemoveMechanism(int mid)
	{
		if (mid <= 0)
		{
			return;
		}
		for (int i = 0; i < this.mechanismList.Count; i++)
		{
			BeMechanism beMechanism = this.mechanismList[i];
			if (beMechanism != null)
			{
				if (beMechanism.mechianismID == mid)
				{
					this.RemoveMechanism(beMechanism);
				}
			}
		}
	}

	// Token: 0x06016C00 RID: 93184 RVA: 0x006F798D File Offset: 0x006F5D8D
	public void RemoveMechanism(BeMechanism mechanism)
	{
		if (mechanism == null)
		{
			return;
		}
		if (!mechanism.canRemove)
		{
			return;
		}
		mechanism.Finish();
	}

	// Token: 0x06016C01 RID: 93185 RVA: 0x006F79A8 File Offset: 0x006F5DA8
	public void UpdateMechanisms(int deltaTime)
	{
		for (int i = 0; i < this.mechanismList.Count; i++)
		{
			this.mechanismList[i].Update(deltaTime);
		}
	}

	// Token: 0x06016C02 RID: 93186 RVA: 0x006F79E4 File Offset: 0x006F5DE4
	public void UpdateMechanismsImpactBySpeed(int deltaTime)
	{
		for (int i = 0; i < this.mechanismList.Count; i++)
		{
			this.mechanismList[i].UpdateImpactBySpeed(deltaTime);
		}
	}

	// Token: 0x06016C03 RID: 93187 RVA: 0x006F7A20 File Offset: 0x006F5E20
	public void UpdateMechanismsGraphic(int deltaTime)
	{
		for (int i = 0; i < this.mechanismList.Count; i++)
		{
			this.mechanismList[i].UpdateGraphic(deltaTime);
		}
	}

	// Token: 0x06016C04 RID: 93188 RVA: 0x006F7A5C File Offset: 0x006F5E5C
	public void RemoveAllMechanism()
	{
		this.RecordEquipMechanism();
		for (int i = 0; i < this.mechanismList.Count; i++)
		{
			BeMechanism beMechanism = this.mechanismList[i];
			if (beMechanism != null)
			{
				beMechanism.DealDead();
				this.RemoveMechanism(beMechanism);
			}
		}
	}

	// Token: 0x06016C05 RID: 93189 RVA: 0x006F7AB0 File Offset: 0x006F5EB0
	public BeMechanism GetMechanism(int mid)
	{
		for (int i = 0; i < this.mechanismList.Count; i++)
		{
			if (this.mechanismList[i].mechianismID == mid)
			{
				return this.mechanismList[i];
			}
		}
		return null;
	}

	// Token: 0x06016C06 RID: 93190 RVA: 0x006F7B00 File Offset: 0x006F5F00
	public BeMechanism GetMechanismByIndex(int index)
	{
		for (int i = 0; i < this.mechanismList.Count; i++)
		{
			if (this.mechanismList[i].GetMechanismIndex() == index)
			{
				return this.mechanismList[i];
			}
		}
		return null;
	}

	// Token: 0x06016C07 RID: 93191 RVA: 0x006F7B50 File Offset: 0x006F5F50
	public void GetMechanismsByIndex(List<BeMechanism> list, int index)
	{
		if (this.mechanismList == null)
		{
			return;
		}
		if (list == null)
		{
			return;
		}
		list.Clear();
		for (int i = 0; i < this.mechanismList.Count; i++)
		{
			BeMechanism beMechanism = this.mechanismList[i];
			if (beMechanism.data != null && beMechanism.data.Index == index)
			{
				list.Add(beMechanism);
			}
		}
	}

	// Token: 0x06016C08 RID: 93192 RVA: 0x006F7BC4 File Offset: 0x006F5FC4
	public void LoadMechanismBuffs(IList<int> buffInfos, int level = 0, bool inTown = false, ItemProperty weaponProperty = null, bool needRecord = false)
	{
		if (buffInfos == null)
		{
			return;
		}
		for (int i = 0; i < buffInfos.Count; i++)
		{
			if (buffInfos[i] > 0)
			{
				if (!needRecord || base.IsProcessRecord())
				{
				}
				BuffInfoTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffInfoTable>(buffInfos[i], string.Empty, string.Empty);
				if (tableItem != null && tableItem.RelatedSkillID != 0)
				{
					level = this.GetSkillLevel(tableItem.RelatedSkillID);
				}
				BuffInfoData buffInfoData = new BuffInfoData(buffInfos[i], level, 0);
				if (tableItem != null && tableItem.RelatedSkillLV.Length > 0)
				{
					if (tableItem.RelatedSkillLV.Length == 1)
					{
						int num = tableItem.RelatedSkillLV[0];
						if (num != 0)
						{
							Dictionary<int, BeSkill> skills = this.GetSkills();
							foreach (KeyValuePair<int, BeSkill> keyValuePair in skills)
							{
								BeSkill value = keyValuePair.Value;
								if (value != null && value.skillData != null && value.skillData.LevelLimit == num)
								{
									List<int> skillIDs = buffInfoData.skillIDs;
									Dictionary<int, BeSkill>.Enumerator enumerator = new Dictionary<int, BeSkill>.Enumerator();
									KeyValuePair<int, BeSkill> keyValuePair2 = enumerator.Current;
									if (!skillIDs.Contains(keyValuePair2.Key))
									{
										List<int> skillIDs2 = buffInfoData.skillIDs;
										KeyValuePair<int, BeSkill> keyValuePair3 = enumerator.Current;
										skillIDs2.Add(keyValuePair3.Key);
									}
								}
							}
						}
					}
					else if (tableItem.RelatedSkillLV.Length == 2)
					{
						int num2 = tableItem.RelatedSkillLV[0];
						int num3 = tableItem.RelatedSkillLV[1];
						if (num2 > 0 && num2 < num3)
						{
							Dictionary<int, BeSkill> skills2 = this.GetSkills();
							foreach (KeyValuePair<int, BeSkill> keyValuePair4 in skills2)
							{
								BeSkill value2 = keyValuePair4.Value;
								if (value2 != null && value2.skillData != null && value2.skillData.LevelLimit >= num2 && value2.skillData.LevelLimit <= num3)
								{
									List<int> skillIDs3 = buffInfoData.skillIDs;
									Dictionary<int, BeSkill>.Enumerator enumerator2 = new Dictionary<int, BeSkill>.Enumerator();
									KeyValuePair<int, BeSkill> keyValuePair5 = enumerator2.Current;
									if (!skillIDs3.Contains(keyValuePair5.Key))
									{
										List<int> skillIDs4 = buffInfoData.skillIDs;
										KeyValuePair<int, BeSkill> keyValuePair6 = enumerator2.Current;
										skillIDs4.Add(keyValuePair6.Key);
									}
								}
							}
						}
					}
				}
				base.TriggerEventNew(BeEventType.onAfterCalcBuffInfoSkillLV, new EventParam
				{
					m_Obj = buffInfoData
				});
				if (buffInfoData.condition <= BuffCondition.NONE)
				{
					if ((buffInfoData.condition == BuffCondition.ENTERBATTLE && !inTown) || buffInfoData.condition == BuffCondition.NONE)
					{
						this.buffController.TryAddBuff(buffInfoData, this, false, default(VRate), null);
					}
				}
				else
				{
					this.buffController.AddTriggerBuff(buffInfoData);
					if (weaponProperty != null)
					{
						BuffInfoData triggerBuff = this.buffController.GetTriggerBuff(buffInfoData);
						this.RestoreBuffInfoCDRemain(triggerBuff, weaponProperty);
					}
				}
			}
		}
	}

	// Token: 0x06016C09 RID: 93193 RVA: 0x006F7EAC File Offset: 0x006F62AC
	public void RemoveMechanismBuffs(IList<int> buffInfos, ItemProperty weaponProperty = null)
	{
		if (buffInfos == null)
		{
			return;
		}
		for (int i = 0; i < buffInfos.Count; i++)
		{
			if (buffInfos[i] > 0)
			{
				BuffInfoData buffInfoData = new BuffInfoData(buffInfos[i], 0, 0);
				if (buffInfoData.condition <= BuffCondition.NONE)
				{
					if (buffInfoData.condition == BuffCondition.ENTERBATTLE || buffInfoData.condition == BuffCondition.NONE)
					{
						this.buffController.RemoveBuff(buffInfoData.buffID, 1, buffInfoData.buffInfoID);
					}
				}
				else
				{
					if (weaponProperty != null)
					{
						this.RecordBuffInfoCDRemain(this.buffController.GetTriggerBuff(buffInfoData), weaponProperty);
					}
					this.buffController.RemoveTriggerBuff(buffInfos[i]);
				}
			}
		}
	}

	// Token: 0x06016C0A RID: 93194 RVA: 0x006F7F6D File Offset: 0x006F636D
	public void RecordBuffInfoCDRemain(BuffInfoData buffInfo, ItemProperty weaponProperty)
	{
		if (buffInfo == null || weaponProperty == null)
		{
			return;
		}
		if (buffInfo.IsCD() && buffInfo.GetCDAcc() > 0)
		{
			weaponProperty.SaveTriggerBuffCDRemain(buffInfo.buffInfoID, buffInfo.GetCDAcc());
		}
	}

	// Token: 0x06016C0B RID: 93195 RVA: 0x006F7FAC File Offset: 0x006F63AC
	public void RestoreBuffInfoCDRemain(BuffInfoData buffInfo, ItemProperty weaponProperty)
	{
		if (buffInfo == null || weaponProperty == null)
		{
			return;
		}
		int triggerBuffCDRemain = weaponProperty.GetTriggerBuffCDRemain(buffInfo.buffInfoID);
		if (triggerBuffCDRemain > 0)
		{
			buffInfo.SetCDRemain(triggerBuffCDRemain);
		}
	}

	// Token: 0x06016C0C RID: 93196 RVA: 0x006F7FE8 File Offset: 0x006F63E8
	public void RecordEquipMechanism()
	{
		this.recordedEquipMechanismIDs.Clear();
		for (int i = 0; i < this.mechanismList.Count; i++)
		{
			BeMechanism beMechanism = this.mechanismList[i];
			if (beMechanism != null)
			{
				if (beMechanism.sourceType == MechanismSourceType.EQUIP)
				{
					this.recordedEquipMechanismIDs.Add(beMechanism.mechianismID);
				}
			}
		}
	}

	// Token: 0x06016C0D RID: 93197 RVA: 0x006F8054 File Offset: 0x006F6454
	public bool LoadOneSkill(int skillID, int skillLevel)
	{
		string typeName = "Skill" + skillID;
		Type type = TypeTable.GetType(typeName);
		BeSkill beSkill;
		if (type != null)
		{
			beSkill = (BeSkill)Activator.CreateInstance(type, new object[]
			{
				skillID,
				skillLevel
			});
		}
		else
		{
			beSkill = new BeSkill(skillID, skillLevel);
		}
		if (beSkill == null || Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(skillID, string.Empty, string.Empty) == null)
		{
			return false;
		}
		this.AddSkill(skillID, beSkill);
		return true;
	}

	// Token: 0x06016C0E RID: 93198 RVA: 0x006F80E0 File Offset: 0x006F64E0
	public void LoadSkill(Dictionary<int, int> skillInfos, bool loadConfigBySkills = false, int resID = 0)
	{
		if (this.m_pkGeActor != null)
		{
			this.LoadSkillConfig(skillInfos, loadConfigBySkills, resID);
		}
		foreach (KeyValuePair<int, int> keyValuePair in skillInfos)
		{
			int key = keyValuePair.Key;
			Dictionary<int, int>.Enumerator enumerator = new Dictionary<int, int>.Enumerator();
			KeyValuePair<int, int> keyValuePair2 = enumerator.Current;
			int value = keyValuePair2.Value;
			this.LoadOneSkill(key, value);
		}
	}

	// Token: 0x06016C0F RID: 93199 RVA: 0x006F8144 File Offset: 0x006F6544
	public void LoadSkillConfig(Dictionary<int, int> skillInfos, bool loadConfigBySkills = false, int resID = 0)
	{
		List<string> list = null;
		if (loadConfigBySkills)
		{
			list = new List<string>();
			foreach (KeyValuePair<int, int> keyValuePair in skillInfos)
			{
				int key = keyValuePair.Key;
				SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(key, string.Empty, string.Empty);
				if (tableItem != null)
				{
					string englishName = tableItem.EnglishName;
					if (!list.Contains(englishName))
					{
						list.Add(englishName);
					}
				}
			}
		}
		if (this.m_pkGeActor != null)
		{
			this.m_pkGeActor.LoadSkillConfig(this.m_cpkEntityInfo, this.loadCommonSkill, list, resID);
		}
		if (this.attachmentproxy != null)
		{
			if (this.attachmentproxy.needReplace)
			{
				Dictionary<int, int> dictionary = new Dictionary<int, int>();
				Dictionary<int, List<int>> dictionary2 = new Dictionary<int, List<int>>();
				dictionary.Add(this.attachmentproxy.tag, 1);
				dictionary2.Add(this.attachmentproxy.tag, new List<int>(new int[]
				{
					this.attribute.GetWeaponType()
				}));
				if (this.attribute != null)
				{
					List<int> list2 = new List<int>();
					List<int> list3 = new List<int>();
					this.attribute.GetBackupWeaponTypesAndTags(list3, list2);
					for (int i = 0; i < list2.Count; i++)
					{
						if (!dictionary.ContainsKey(list2[i]))
						{
							dictionary.Add(list2[i], 1);
							dictionary2.Add(list2[i], new List<int>(new int[]
							{
								list3[i]
							}));
						}
						else if (!dictionary2[list2[i]].Contains(list3[i]))
						{
							dictionary2[list2[i]].Add(list3[i]);
						}
					}
					foreach (KeyValuePair<int, int> keyValuePair2 in dictionary)
					{
						if (this.m_pkGeActor != null)
						{
							List<int> types = null;
							if (dictionary2.ContainsKey(keyValuePair2.Key))
							{
								types = dictionary2[keyValuePair2.Key];
							}
							if (base.CurrentBeBattle.HasFlag(BattleFlagType.SKILL_LOADING_TYPE))
							{
								this.m_pkGeActor.LoadWeaponRelatedConfig(this.m_cpkEntityInfo, keyValuePair2.Key, list, null);
							}
							else
							{
								this.m_pkGeActor.LoadWeaponRelatedConfig(this.m_cpkEntityInfo, keyValuePair2.Key, list, types);
							}
						}
					}
				}
			}
			else if (this.m_pkGeActor != null)
			{
				this.m_pkGeActor.LoadWeaponRelatedConfig(this.m_cpkEntityInfo, this.defaultWeaponTag, list, null);
			}
		}
		if (this.attribute != null)
		{
			int num = 0;
			int num2 = 0;
			this.attribute.GetWeaponTagAndWeaponType(ref num, ref num2);
			if (num == 0)
			{
				num = this.defaultWeaponTag;
			}
			if (num2 == 0)
			{
				num2 = this.defaultWeaponType;
			}
			this.m_cpkEntityInfo.SetWeaponInfo(num, num2);
		}
	}

	// Token: 0x06016C10 RID: 93200 RVA: 0x006F8464 File Offset: 0x006F6864
	public void AddSkill(int sid, BeSkill skill)
	{
		if (!this.skillList.ContainsKey(sid))
		{
			skill.owner = this;
			skill.Init();
			this.skillList.Add(sid, skill);
		}
	}

	// Token: 0x06016C11 RID: 93201 RVA: 0x006F8498 File Offset: 0x006F6898
	public void PostInitOneSkill(int skillID)
	{
		BeSkill skill = this.GetSkill(skillID);
		if (skill == null)
		{
			return;
		}
		bool isPvP = BattleMain.IsModePvP(base.battleType);
		skill.PostInit();
		skill.StartInitCD(isPvP);
		BeEntityData entityData = base.GetEntityData();
		VRate b = VRate.zero;
		if (entityData != null && entityData.battleData.cdReduceRate > 0)
		{
			b = entityData.battleData.cdReduceRate;
		}
		skill.cdReduceRate += b;
		if (!this.attribute.skillLevelInfo.ContainsKey(skillID))
		{
			this.attribute.skillLevelInfo.Add(skillID, skill.level);
		}
		entityData.UpdateLevel(skillID, skill.level);
	}

	// Token: 0x06016C12 RID: 93202 RVA: 0x006F8560 File Offset: 0x006F6960
	public void StartInitCDForSkill(bool inTown = false)
	{
		if (BattleMain.IsModeTrain(base.battleType))
		{
			return;
		}
		bool isPvP = BattleMain.IsModePvP(base.battleType);
		foreach (KeyValuePair<int, BeSkill> keyValuePair in this.skillList)
		{
			BeSkill value = keyValuePair.Value;
			value.inTown = inTown;
			if (value != null)
			{
				value.StartInitCD(isPvP);
			}
		}
	}

	// Token: 0x06016C13 RID: 93203 RVA: 0x006F85CC File Offset: 0x006F69CC
	public void PostInitSkills(bool inTown = false)
	{
		bool flag = BattleMain.IsModePvP(base.battleType);
		string text = string.Empty;
		Dictionary<int, BeSkill>.Enumerator enumerator = this.skillList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<int, BeSkill> keyValuePair = enumerator.Current;
				BeSkill value = keyValuePair.Value;
				value.inTown = inTown;
				if (value != null)
				{
					text = string.Format("occu {0} skillId {1}", this.professionID, value.skillID);
					value.PostInit();
				}
			}
		}
		catch (Exception ex)
		{
			if (Singleton<ClientSystemManager>.instance != null && Singleton<ClientSystemManager>.instance.CurrentSystem != null)
			{
				Logger.LogErrorFormat("PostInitSkills occur error {0} reason {1} currentSystem{2}", new object[]
				{
					text,
					ex.ToString(),
					Singleton<ClientSystemManager>.instance.CurrentSystem.GetName()
				});
			}
		}
		if (!BattleMain.IsModePvP(base.battleType))
		{
			this.StartInitCDForSkill(inTown);
		}
		foreach (KeyValuePair<int, BeSkill> keyValuePair2 in this.skillList)
		{
			int key = keyValuePair2.Key;
			KeyValuePair<int, BeSkill> keyValuePair3 = enumerator.Current;
			BeSkill value2 = keyValuePair3.Value;
			if (this.attribute.skillLevelInfo.ContainsKey(key))
			{
				this.attribute.skillLevelInfo[key] = value2.level;
			}
		}
	}

	// Token: 0x06016C14 RID: 93204 RVA: 0x006F8740 File Offset: 0x006F6B40
	public bool HasSkill(int skillID)
	{
		return this.skillList.ContainsKey(skillID);
	}

	// Token: 0x06016C15 RID: 93205 RVA: 0x006F874E File Offset: 0x006F6B4E
	public BeSkill GetSkill(int skillID)
	{
		if (!this.HasSkill(skillID))
		{
			return null;
		}
		return this.skillList[skillID];
	}

	// Token: 0x06016C16 RID: 93206 RVA: 0x006F876C File Offset: 0x006F6B6C
	public void UpdateSkill(int deltaTime)
	{
		foreach (KeyValuePair<int, BeSkill> keyValuePair in this.skillList)
		{
			BeSkill value = keyValuePair.Value;
			value.Update(deltaTime);
		}
	}

	// Token: 0x06016C17 RID: 93207 RVA: 0x006F87B0 File Offset: 0x006F6BB0
	public void ResetSkillCoolDown()
	{
		foreach (KeyValuePair<int, BeSkill> keyValuePair in this.skillList)
		{
			BeSkill value = keyValuePair.Value;
			value.ResetCoolDown();
		}
	}

	// Token: 0x06016C18 RID: 93208 RVA: 0x006F87F0 File Offset: 0x006F6BF0
	public BeActor.SkillCannotUseType GetSkillCannotUseType(BeSkill skill)
	{
		BeActor.SkillCannotUseType skillCannotUseType = BeActor.SkillCannotUseType.CAN_USE;
		if (skill != null)
		{
			if (skill.isCooldown)
			{
				skillCannotUseType = BeActor.SkillCannotUseType.IN_CD;
			}
			else
			{
				bool flag = skill.GetMPCost() <= this.attribute.GetMP();
				bool flag2 = skill.GetHPCost(this.attribute.GetMaxHP()) <= this.attribute.GetHP();
				bool flag3 = skill.GetCrystalCost() <= this.attribute.GetCrystalNum();
				SkillCostMode costMode = (SkillCostMode)skill.costMode;
				if (costMode != SkillCostMode.ALL)
				{
					if (costMode != SkillCostMode.HP_ONLY)
					{
						if (costMode == SkillCostMode.MP_ONLY)
						{
							if (!flag)
							{
								skillCannotUseType = BeActor.SkillCannotUseType.NO_MP;
							}
						}
					}
					else if (!flag2)
					{
						skillCannotUseType = BeActor.SkillCannotUseType.NO_HP;
					}
				}
				else if (!flag)
				{
					skillCannotUseType = BeActor.SkillCannotUseType.NO_MP;
				}
				else if (!flag2)
				{
					skillCannotUseType = BeActor.SkillCannotUseType.NO_HP;
				}
				else if (!flag3)
				{
					skillCannotUseType = BeActor.SkillCannotUseType.NO_CRYSTAL;
				}
			}
			if (skillCannotUseType == BeActor.SkillCannotUseType.CAN_USE)
			{
				skillCannotUseType = skill.GetCannotUseType();
			}
		}
		return skillCannotUseType;
	}

	// Token: 0x06016C19 RID: 93209 RVA: 0x006F88DC File Offset: 0x006F6CDC
	public bool CanCost(BeSkill skill)
	{
		if (!Global.Settings.skillHasCooldown)
		{
			return true;
		}
		if (skill != null && skill.NeedCost() && this.actorNeedCost)
		{
			bool result = false;
			bool flag = skill.GetMPCost() <= this.attribute.GetMP();
			bool flag2 = skill.GetHPCost(this.attribute.GetMaxHP()) < this.attribute.GetHP();
			bool flag3 = skill.GetCrystalCost() <= this.attribute.GetCrystalNum();
			if (skill.NeedCost())
			{
				SkillCostMode costMode = (SkillCostMode)skill.costMode;
				if (costMode != SkillCostMode.ALL)
				{
					if (costMode != SkillCostMode.HP_ONLY)
					{
						if (costMode == SkillCostMode.MP_ONLY)
						{
							result = flag;
						}
					}
					else
					{
						result = flag2;
					}
				}
				else
				{
					result = (flag2 && flag && flag3);
				}
				return result;
			}
		}
		return true;
	}

	// Token: 0x06016C1A RID: 93210 RVA: 0x006F89BC File Offset: 0x006F6DBC
	public bool CheckMuscleShift(int curSkillID, int skillID)
	{
		bool flag = BattleMain.IsModePvP(base.battleType);
		BeBuff beBuff = this.buffController.HasBuffByID((!flag) ? 183211 : 183212);
		if (beBuff != null)
		{
			Buff183211 buff = beBuff as Buff183211;
			return buff.CanUseSkill(curSkillID, skillID);
		}
		return false;
	}

	// Token: 0x06016C1B RID: 93211 RVA: 0x006F8A10 File Offset: 0x006F6E10
	public void UseMuscleShift(int curSkillId, int skillId)
	{
		bool flag = BattleMain.IsModePvP(base.battleType);
		BeBuff beBuff = this.buffController.HasBuffByID((!flag) ? 183211 : 183212);
		if (beBuff != null)
		{
			Buff183211 buff = beBuff as Buff183211;
			buff.Decrease(curSkillId, skillId);
			this.buffController.TryAddBuff((!flag) ? 183206 : 1832060, null, false, null, 0);
			base.TriggerEventNew(BeEventType.onUseMuscleShift, new EventParam
			{
				m_Int = curSkillId,
				m_Int2 = skillId
			});
		}
	}

	// Token: 0x06016C1C RID: 93212 RVA: 0x006F8AA8 File Offset: 0x006F6EA8
	public bool CanUseSkill(int skillID)
	{
		if (!this.stateController.CanAttack())
		{
			return false;
		}
		if (!this.HasSkill(skillID))
		{
			if (skillID <= GlobalLogic.VALUE_1000 || this.aiManager == null || this.aiManager.isAutoFight)
			{
			}
			return false;
		}
		BeSkill skill = this.GetSkill(skillID);
		if (!skill.CanUseSkill())
		{
			return false;
		}
		if (!this.CanCost(skill))
		{
			return false;
		}
		ActionState actionState = (ActionState)base.sgGetCurrentState();
		bool result = true;
		if (actionState == ActionState.AS_CASTSKILL)
		{
			if (skillID == this.m_iCurSkillID)
			{
				result = false;
			}
			else
			{
				BeSkill skill2 = this.GetSkill(this.m_iCurSkillID);
				if (skill2 != null)
				{
					result = (skill2.CanBePositiveAbort() || skill.CanInterrupt(this.m_iCurSkillID, skill2.hit) || this.CheckMuscleShift(this.m_iCurSkillID, skillID) || skill2.CanBeInterrupt(skillID));
				}
			}
		}
		else
		{
			result = (skill.CheckSpellCondition(actionState) || (this.isPkRobot && skillID == 1515 && actionState == ActionState.AS_HURT));
		}
		if (skill.CanForceUseSkill())
		{
			result = true;
		}
		return result;
	}

	// Token: 0x06016C1D RID: 93213 RVA: 0x006F8BDC File Offset: 0x006F6FDC
	public int CheckComboSkill(int skillID = 0)
	{
		ActionState actionState = (ActionState)base.sgGetCurrentState();
		if (actionState == ActionState.AS_CASTSKILL && this.m_cpkCurEntityActionInfo != null && this.m_cpkCurEntityActionInfo.comboSkillID > 0)
		{
			int[] array = new int[]
			{
				this.m_cpkCurEntityActionInfo.comboSkillID,
				this.m_cpkCurEntityActionInfo.comboStartFrame
			};
			this.owner.TriggerEvent(BeEventType.onReplaceComboSkill, new object[]
			{
				array
			});
			if (this.m_iCurrentLogicFrame >= array[1])
			{
				int num = array[0];
				if (SwitchFunctionUtility.IsOpen(26) && !base.IsMonster() && this.professionID == 10 && (num == 1522 || num == 1524) && base.battleType != BattleType.NewbieGuide)
				{
					num = 0;
				}
				return num;
			}
		}
		return 0;
	}

	// Token: 0x06016C1E RID: 93214 RVA: 0x006F8CAC File Offset: 0x006F70AC
	public void DoSkillCost(BeSkill skill)
	{
		if (skill.NeedCost())
		{
			int mpcost = skill.GetMPCost();
			int hpcost = skill.GetHPCost(this.attribute.GetMaxHP());
			int crystalCost = skill.GetCrystalCost();
			SkillCostMode costMode = (SkillCostMode)skill.costMode;
			if (costMode != SkillCostMode.ALL)
			{
				if (costMode != SkillCostMode.HP_ONLY)
				{
					if (costMode == SkillCostMode.MP_ONLY)
					{
						if (mpcost > 0)
						{
							base.DoMPChange(-mpcost, false);
						}
					}
				}
				else if (hpcost > 0)
				{
					base.DoHPChange(-hpcost, false);
				}
			}
			else
			{
				if (mpcost > 0)
				{
					base.DoMPChange(-mpcost, false);
				}
				if (hpcost > 0)
				{
					base.DoHPChange(-hpcost, false);
				}
				if (crystalCost > 0)
				{
					base.GetEntityData().ModifyCrystalessNum(-crystalCost);
					base.TriggerEvent(BeEventType.OnUseCrystal, null);
					if (this.isLocalActor && !BattleMain.IsModeTrain(BattleMain.battleType) && !Singleton<ReplayServer>.GetInstance().IsReplay())
					{
						BeUtility.UseItemInBattle(300000106, skill.skillID, crystalCost);
					}
				}
			}
		}
	}

	// Token: 0x06016C1F RID: 93215 RVA: 0x006F8DAC File Offset: 0x006F71AC
	public bool UseSkill(int skillID, bool force = false)
	{
		BeSkill skill = this.GetSkill(skillID);
		if (this.owner.TriggerEventNew(BeEventType.onWillUseSkill, new EventParam
		{
			m_Int = skillID
		}).m_Int < 0)
		{
			return false;
		}
		if ((force || (this.CanUseSkill(skillID) && this.CheckCondition(skillID))) && skill != null && skill.CanUseSkill() && (int)base.FrameRandom.Range1000() <= skill.useRate)
		{
			if (base.IsCastingSkill())
			{
				BeSkill currentSkill = this.GetCurrentSkill();
				if (currentSkill != null && ((currentSkill.CanBePositiveAbort() && !skill.CanBePositiveAbort()) || skill.CanInterrupt(this.m_iCurSkillID, false) || currentSkill.CanBeInterrupt(skillID)))
				{
					if (this.m_pkGeActor != null)
					{
						this.m_pkGeActor.CreateSnapshot(Color.white, Global.Settings.snapDuration, string.Empty);
					}
				}
				else if (currentSkill != null && this.CheckMuscleShift(this.m_iCurSkillID, skillID))
				{
					if (this.m_pkGeActor != null)
					{
						this.m_pkGeActor.CreateSnapshot(Color.white, Global.Settings.snapDuration, string.Empty);
					}
					this.UseMuscleShift(this.m_iCurSkillID, skillID);
				}
			}
			this.DoSkillCost(skill);
			skill.pressedForwardMove = base.IsPressForwardMoveCmd();
			int[] array = new int[]
			{
				skillID
			};
			if (this.owner != null)
			{
				this.owner.TriggerEvent(BeEventType.onReplaceSkill, new object[]
				{
					array
				});
			}
			BeStateData rkStateData = new BeStateData(14, array[0]);
			this.Locomote(rkStateData, false);
			return true;
		}
		if (skill != null && this.isLocalActor)
		{
			BeActor.SkillCannotUseType skillCannotUseType = this.GetSkillCannotUseType(skill);
			if (skillCannotUseType != BeActor.SkillCannotUseType.CAN_USE)
			{
				bool @bool = true;
				if (this.owner.TriggerEventNew(BeEventType.onChangeShock, new EventParam
				{
					m_Bool = @bool
				}).m_Bool)
				{
					base.AddShock(Global.Settings.playerSkillCDShockData);
				}
				string arg = string.Empty;
				switch (skillCannotUseType)
				{
				case BeActor.SkillCannotUseType.NO_HP:
					arg = "UI/Font/new_font/pic_nohp.png";
					break;
				case BeActor.SkillCannotUseType.NO_MP:
					arg = "UI/Font/new_font/pic_nomp.png";
					break;
				case BeActor.SkillCannotUseType.IN_CD:
					arg = "UI/Font/new_font/pic_incd.png";
					break;
				case BeActor.SkillCannotUseType.NO_RIGHT_WEAPON:
					arg = string.Format("UI/Font/new_font/pic_sycs_{0}.png:pic_sycs_{1}_0", skill.skillData.NeedWeaponType, skill.skillData.NeedWeaponType);
					break;
				case BeActor.SkillCannotUseType.NO_KEYING:
					arg = "UI/Font/new_font/pic_qsksy.png";
					break;
				case BeActor.SkillCannotUseType.NO_CRYSTAL:
					arg = "UI/Font/new_font/pic_wsjtbz.png";
					break;
				case BeActor.SkillCannotUseType.NO_CYZKJ:
					arg = "UI/Font/new_font/pic_cyzkj.png";
					break;
				case BeActor.SkillCannotUseType.MONSTER_COUNT_LIMITM:
					arg = "UI/Font/new_font/pic_zhslsx.png";
					break;
				case BeActor.SkillCannotUseType.MONSTER_DIS_LIMITM:
					arg = "UI/Font/new_font/pic_yqtbh.png";
					break;
				case BeActor.SkillCannotUseType.CAN_NOT_USE:
					arg = "UI/Font/new_font/pic_sycs.png:pic_sycs";
					break;
				}
				if (this.m_pkGeActor != null)
				{
					this.m_pkGeActor.CreateHeadText(HitTextType.SKILL_CANNOTUSE, arg, false, null);
				}
			}
		}
		return false;
	}

	// Token: 0x06016C20 RID: 93216 RVA: 0x006F90C4 File Offset: 0x006F74C4
	private bool CheckCondition(int skillID)
	{
		return base.sgGetCurrentState() != 14 || ((!BeActor.LiGuiSkillList.Contains(this.m_iCurSkillID) || !BeActor.NormalSkillList.Contains(skillID)) && (!BeActor.LiGuiSkillList.Contains(skillID) || !BeActor.NormalSkillList.Contains(this.m_iCurSkillID))) || this.CanInterrupSkill();
	}

	// Token: 0x06016C21 RID: 93217 RVA: 0x006F9130 File Offset: 0x006F7530
	private bool CanInterrupSkill()
	{
		BDEntityActionInfo actionInfoBySkillID = base.GetActionInfoBySkillID(this.m_iCurSkillID);
		return actionInfoBySkillID == null || (this.m_iCurrentLogicFrame >= actionInfoBySkillID.comboStartFrame && actionInfoBySkillID.comboStartFrame > 0);
	}

	// Token: 0x06016C22 RID: 93218 RVA: 0x006F9170 File Offset: 0x006F7570
	public void SetSkillPhases(int skillID)
	{
		BDEntityActionInfo actionInfoBySkillID = base.GetActionInfoBySkillID(skillID);
		if (actionInfoBySkillID != null)
		{
			if (actionInfoBySkillID.skillPhases.Length > 0)
			{
				this.skillPhases = actionInfoBySkillID.skillPhases;
			}
			else
			{
				this.skillPhases = new int[1];
				this.skillPhases[0] = skillID;
			}
		}
		else
		{
			this.skillPhases = null;
		}
	}

	// Token: 0x06016C23 RID: 93219 RVA: 0x006F91CB File Offset: 0x006F75CB
	public void ResetSkillPhase(int skillID)
	{
		this.SetSkillPhases(skillID);
		this.skillPhase = 0;
	}

	// Token: 0x06016C24 RID: 93220 RVA: 0x006F91DC File Offset: 0x006F75DC
	public int GetSkillPhaseId()
	{
		int result = -1;
		if (this.skillPhases != null)
		{
			int num = this.skillPhases.Length;
			if (this.skillPhase < num)
			{
				result = this.skillPhases[this.skillPhase];
				this.skillPhase++;
			}
		}
		return result;
	}

	// Token: 0x06016C25 RID: 93221 RVA: 0x006F9228 File Offset: 0x006F7628
	public void SetCurrSkillPhase(int[] phase)
	{
		this.skillPhases = phase;
	}

	// Token: 0x06016C26 RID: 93222 RVA: 0x006F9234 File Offset: 0x006F7634
	public void SetSkillWalkMode(SkillWalkMode mode, VFactor walkSpeed, VFactor walkSpeed2 = default(VFactor))
	{
		BeSkill skill = this.GetSkill(this.m_iCurSkillID);
		if (skill == null)
		{
			return;
		}
		if (mode != SkillWalkMode.FORBID && !skill.walk)
		{
			mode = SkillWalkMode.FORBID;
		}
		this.skillFreeTurnFace = false;
		this.keepXSkillSpeed = false;
		bool flag = base.GetStateGraph().CurrentStateHasTag(4);
		skill.CurSkillWalkMode = (int)mode;
		switch (mode)
		{
		case SkillWalkMode.FORBID:
			base.GetStateGraph().ResetCurrentStateTag();
			base.GetStateGraph().SetCurrentStateTag(3, true);
			this.onlyMoveFacedDir = false;
			this.onlyMoveFaceDirOpposite = false;
			this.skillFreeTurnFace = false;
			base.SetMoveSpeedXRate(VFactor.one);
			base.SetMoveSpeedYRate(VFactor.one);
			break;
		case SkillWalkMode.FREE:
		case SkillWalkMode.FREE2:
			base.GetStateGraph().ResetCurrentStateTag();
			base.SetMoveSpeedXRate(walkSpeed);
			base.SetMoveSpeedYRate(walkSpeed);
			this.onlyMoveFacedDir = false;
			this.onlyMoveFaceDirOpposite = false;
			break;
		case SkillWalkMode.FACEDIR:
			base.GetStateGraph().ResetCurrentStateTag();
			base.SetMoveSpeedXRate(walkSpeed);
			base.SetMoveSpeedYRate(VFactor.zero);
			this.onlyMoveFaceDirOpposite = false;
			this.onlyMoveFacedDir = true;
			break;
		case SkillWalkMode.CHANGE_DIR:
			base.GetStateGraph().ResetCurrentStateTag();
			base.GetStateGraph().SetCurrentStateTag(3, true);
			if (this.m_vkMoveCmd[4])
			{
				VInt a;
				VInt vint;
				base.GetMoveSpeedFromDirection(out a, out vint);
				if ((a > 0 && base.GetFace()) || (a < 0 && !base.GetFace()))
				{
					base.SetFace(!base.GetFace(), true, false);
				}
			}
			break;
		case SkillWalkMode.FREE_AND_CHANGEDIR:
			base.GetStateGraph().ResetCurrentStateTag();
			this.skillFreeTurnFace = true;
			if (this.isMainActor && !this.hasDoublePress)
			{
				this.ChangeRunMode(true);
			}
			base.SetMoveSpeedXRate(walkSpeed);
			base.SetMoveSpeedYRate(walkSpeed);
			this.onlyMoveFaceDirOpposite = false;
			this.onlyMoveFacedDir = false;
			break;
		case SkillWalkMode.X_ONLY:
			base.GetStateGraph().ResetCurrentStateTag();
			this.onlyMoveFacedDir = false;
			this.onlyMoveFaceDirOpposite = false;
			base.SetMoveSpeedXRate(walkSpeed);
			base.SetMoveSpeedYRate(VFactor.zero);
			break;
		case SkillWalkMode.Y_ONLY:
			base.GetStateGraph().ResetCurrentStateTag();
			this.onlyMoveFacedDir = false;
			this.onlyMoveFaceDirOpposite = false;
			base.SetMoveSpeedXRate(VFactor.zero);
			base.SetMoveSpeedYRate(walkSpeed);
			break;
		case SkillWalkMode.FACEDIR_OPPOSITE:
			base.GetStateGraph().ResetCurrentStateTag();
			base.SetMoveSpeedXRate(walkSpeed);
			this.onlyMoveFaceDirOpposite = true;
			this.onlyMoveFacedDir = false;
			break;
		case SkillWalkMode.X_YControl:
			base.GetStateGraph().ResetCurrentStateTag();
			this.onlyMoveFacedDir = false;
			this.onlyMoveFaceDirOpposite = false;
			this.keepXSkillSpeed = true;
			base.SetMoveSpeedXRate(walkSpeed);
			break;
		case SkillWalkMode.FORBID2:
			base.GetStateGraph().ResetCurrentStateTag();
			this.onlyMoveFacedDir = false;
			this.onlyMoveFaceDirOpposite = false;
			base.SetMoveSpeedXRate(VFactor.zero);
			base.SetMoveSpeedYRate(VFactor.zero);
			break;
		case SkillWalkMode.XYDiffRate:
			base.GetStateGraph().ResetCurrentStateTag();
			this.skillFreeTurnFace = true;
			if (this.isMainActor && !this.hasDoublePress)
			{
				this.ChangeRunMode(true);
			}
			base.SetMoveSpeedXRate(walkSpeed);
			base.SetMoveSpeedYRate(walkSpeed2);
			this.onlyMoveFaceDirOpposite = false;
			this.onlyMoveFacedDir = false;
			break;
		}
	}

	// Token: 0x06016C27 RID: 93223 RVA: 0x006F9564 File Offset: 0x006F7964
	public void StartSkill(int skillID)
	{
		BeSkill skill = this.GetSkill(skillID);
		if (skill != null)
		{
			base.TriggerEvent(BeEventType.onCastSkill, new object[]
			{
				skillID,
				skill
			});
			if (skill.GetSkillSpeedEffectType() == SkillSpeedEffectType.ATTACK_SPEED)
			{
				skill.SetSkillSpeed(base.GetEntityData().GetAttackSpeed());
			}
			else if (skill.GetSkillSpeedEffectType() == SkillSpeedEffectType.SPELL_SPEED)
			{
				skill.SetSkillSpeed(base.GetEntityData().GetSpellSpeed());
			}
			else
			{
				skill.SetSkillSpeedWithSkillData();
			}
			skill.Start();
			SkillWalkMode walkMode = (SkillWalkMode)skill.GetWalkMode();
			this.SetSkillWalkMode(walkMode, skill.GetWalkSpeedRate(), default(VFactor));
		}
	}

	// Token: 0x06016C28 RID: 93224 RVA: 0x006F9608 File Offset: 0x006F7A08
	public void FinishSkill(int skillID)
	{
		BeSkill currentSkill = this.GetCurrentSkill();
		if (currentSkill == null)
		{
			return;
		}
		currentSkill.Finish();
		bool canceled = false;
		if (currentSkill.charge || this.actionLooped)
		{
			canceled = true;
		}
		this.CancelSkill(skillID, canceled);
	}

	// Token: 0x06016C29 RID: 93225 RVA: 0x006F964C File Offset: 0x006F7A4C
	public void CancelSkill(int skillID, bool canceled = true)
	{
		if (this.isCancelSkill)
		{
			return;
		}
		this.isCancelSkill = true;
		this.skillAttackScale = VFactor.one;
		base.SetMoveSpeedXRate(VFactor.one);
		base.SetMoveSpeedYRate(VFactor.one);
		this.onlyMoveFacedDir = false;
		this.onlyMoveFaceDirOpposite = false;
		this.keepXSkillSpeed = false;
		this.buffController.ClearPhaseDelete();
		this.buffController.ClearFinishDelete();
		this.buffController.ClearFinishDeleteAll();
		base.ClearPhaseDeleteAudio();
		this.ClearPhaseDelete();
		this.ClearFinishDeleteAll();
		base.ClearSkillFinishDeleteAudio();
		this.StopSpellBar(eDungeonCharactorBar.Power, true);
		this.StopSpellBar(eDungeonCharactorBar.Sing, true);
		BeSkill skill = this.GetSkill(skillID);
		if (skill != null && !skill.IsCanceled() && canceled)
		{
			if (this.m_pkGeActor != null)
			{
				this.m_pkGeActor.Clear(12);
			}
			skill.Cancel();
		}
		this.EndGrap();
		this.isCancelSkill = false;
	}

	// Token: 0x06016C2A RID: 93226 RVA: 0x006F9735 File Offset: 0x006F7B35
	public int GetCastSkillID()
	{
		return this.m_iCurSkillID;
	}

	// Token: 0x06016C2B RID: 93227 RVA: 0x006F973D File Offset: 0x006F7B3D
	public BeSkill GetCurrentSkill()
	{
		return this.GetSkill(this.GetCastSkillID());
	}

	// Token: 0x06016C2C RID: 93228 RVA: 0x006F974C File Offset: 0x006F7B4C
	public void ChangeAnimation(string aniName, bool isWalk = false)
	{
		float aniSpeed = 1f;
		BeSkill currentSkill = this.GetCurrentSkill();
		if (currentSkill != null)
		{
			aniSpeed = currentSkill.GetSkillSpeedFactor().single;
		}
		if (isWalk)
		{
			aniSpeed = ((!this.IsRunning()) ? this.walkSpeedFactor : this.runSpeedFactor);
		}
		base._ChangeAnimation(aniName, aniSpeed);
	}

	// Token: 0x06016C2D RID: 93229 RVA: 0x006F97A8 File Offset: 0x006F7BA8
	public void DealSkillEvent(EventCommand skillEvent)
	{
		BeSkill currentSkill = this.GetCurrentSkill();
		if (currentSkill != null)
		{
			currentSkill.DealSkillEvents(skillEvent);
		}
	}

	// Token: 0x06016C2E RID: 93230 RVA: 0x006F97CC File Offset: 0x006F7BCC
	public void PlaySkillAction(int skillPhaseID)
	{
		string actionNameBySkillID = base.GetActionNameBySkillID(skillPhaseID);
		if (actionNameBySkillID == null)
		{
			return;
		}
		float aniSpeed = 1f;
		BeSkill currentSkill = this.GetCurrentSkill();
		if (currentSkill != null)
		{
			aniSpeed = currentSkill.GetSkillSpeedFactor().single;
		}
		base.PlayAction(actionNameBySkillID, aniSpeed);
	}

	// Token: 0x06016C2F RID: 93231 RVA: 0x006F9814 File Offset: 0x006F7C14
	public void _addBuff(List<BuffInfoData> buffInfoList, bool needRecord = false, string reason = "")
	{
		if (buffInfoList != null)
		{
			for (int i = 0; i < buffInfoList.Count; i++)
			{
				BuffInfoData buffInfoData = buffInfoList[i];
				if (base.IsProcessRecord() && needRecord)
				{
					VInt3 position = base.GetPosition();
					base.GetRecordServer().Mark(2272884593U, new int[]
					{
						buffInfoData.buffInfoID,
						position.x,
						position.y,
						position.z,
						base.moveXSpeed.i,
						base.moveYSpeed.i,
						base.moveZSpeed.i,
						(!base.GetFace()) ? 0 : 1,
						this.attribute.GetHP(),
						this.attribute.GetMP(),
						this.m_iID,
						this.m_kStateTag.GetAllFlag(),
						this.attribute.battleData.attack.ToInt()
					}, new string[]
					{
						base.GetName(),
						reason
					});
				}
				if (buffInfoData != null && buffInfoData.condition == BuffCondition.NONE)
				{
					this.buffController.TryAddBuff(buffInfoData, this, false, default(VRate), null);
				}
			}
		}
	}

	// Token: 0x06016C30 RID: 93232 RVA: 0x006F9978 File Offset: 0x006F7D78
	public void InitData(int level, int fightID, Dictionary<int, int> skillLevelInfo, string ai = "", int proid = 0, List<ItemProperty> equips = null, List<Battle.DungeonBuff> buffList = null, int weaponStrengthenLevel = 0, List<BuffInfoData> rankBuffList = null, PetData petData = null, List<ItemProperty> sideEquips = null, Dictionary<int, string> avatar = null, bool isShowWeapon = false, bool isAIRobot = false, bool ispvp = false, SkillSystemSourceType skillSourceType = SkillSystemSourceType.None)
	{
		List<int> list = new List<int>(Singleton<TableManager>.instance.GetBornSkills(proid));
		this.professionID = proid;
		List<int> noNeedLoadSkills = ListPool<int>.Get();
		for (int i = 0; i < list.Count; i++)
		{
			int num = list[i];
			SkillTable tableItem = Singleton<TableManager>.instance.GetTableItem<SkillTable>(num, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (tableItem.MasterSkillID != 0 && !skillLevelInfo.ContainsKey(tableItem.MasterSkillID))
				{
					noNeedLoadSkills.Add(num);
				}
			}
		}
		list.RemoveAll((int item) => noNeedLoadSkills.Contains(item));
		ListPool<int>.Release(noNeedLoadSkills);
		if (isAIRobot)
		{
			skillLevelInfo = BeUtility.GetPKRobotSkillLevel(skillLevelInfo, level);
		}
		for (int j = 0; j < list.Count; j++)
		{
			int key = list[j];
			if (!skillLevelInfo.ContainsKey(key))
			{
				skillLevelInfo.Add(key, 1);
			}
		}
		if (BattleMain.IsModeChiji(base.battleType))
		{
			JobTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<JobTable>(proid, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				int chijiNormalAttackID = tableItem2.ChijiNormalAttackID;
				if (chijiNormalAttackID > 0 && !skillLevelInfo.ContainsKey(chijiNormalAttackID))
				{
					skillLevelInfo.Add(chijiNormalAttackID, 1);
				}
			}
		}
		List<int> list2 = new List<int>();
		List<int> passiveSkills = Singleton<TableManager>.instance.GetPassiveSkills(proid);
		for (int k = 0; k < passiveSkills.Count; k++)
		{
			int id = passiveSkills[k];
			SkillTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(id, string.Empty, string.Empty);
			if (tableItem3 != null && tableItem3.LevelLimit <= level)
			{
				for (int l = 0; l < tableItem3.BuffInfoIDs.Count; l++)
				{
					int id2 = tableItem3.BuffInfoIDs[l];
					BuffInfoTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<BuffInfoTable>(id2, string.Empty, string.Empty);
					if (tableItem4 != null)
					{
						if (tableItem4.BuffID > 0)
						{
							list2.Add(tableItem4.BuffID);
						}
					}
				}
			}
		}
		if (skillLevelInfo.ContainsKey(9998))
		{
			skillLevelInfo[9998] = level;
		}
		if (equips != null)
		{
			this.equips = equips;
			List<int> list3 = new List<int>();
			for (int m = 0; m < equips.Count; m++)
			{
				list3.Add(equips[m].itemID);
			}
			this.suitProperty = DataManager<EquipSuitDataManager>.GetInstance().GetEquipSuitPropByIDs(list3);
			this.masterProperty = DataManager<EquipMasterDataManager>.GetInstance().GetEquipMasterPropByIDs(proid, list3);
			if (this.suitProperty != null)
			{
				equips.Add(this.suitProperty);
			}
			if (this.masterProperty != null)
			{
				equips.Add(this.masterProperty);
			}
		}
		this.attribute = BeEntityData.GetActorAttribute(level, fightID, equips, skillLevelInfo, list2, sideEquips, this);
		if (isAIRobot && equips != null)
		{
			for (int n = 0; n < equips.Count; n++)
			{
				this.attribute.SetAIRobotData(equips[n]);
			}
		}
		this.attribute.professtion = Singleton<TableManager>.GetInstance().GetJobIDByFightID(fightID);
		if (fightID != 0 && this.attribute.professtion != 0)
		{
			JobTable tableItem5 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(this.attribute.professtion, string.Empty, string.Empty);
			if (tableItem5 != null)
			{
				this.attribute.jobAttribute = tableItem5.JobAttribute;
				if (BattleMain.IsModeChiji(base.battleType) && tableItem5.ChijiNormalAttackID > 0)
				{
					this.attribute.normalAttackID = tableItem5.ChijiNormalAttackID;
				}
				else if (tableItem5.NormalAttackID > 0)
				{
					this.attribute.normalAttackID = tableItem5.NormalAttackID;
				}
			}
		}
		this.ChangeWeaponModle(weaponStrengthenLevel);
		if (isShowWeapon)
		{
			this.InitFashionWeapon(equips, this.professionID);
		}
		this.LoadSkill(skillLevelInfo, fightID > 0 || ai == "apc", 0);
		if (equips != null)
		{
			List<int> list4 = new List<int>();
			List<int> list5 = new List<int>();
			if (skillSourceType != SkillSystemSourceType.FairDuel)
			{
				for (int num2 = 0; num2 < equips.Count; num2++)
				{
					if (BattleMain.IsModePvP(base.battleType) || (ispvp && ai == "town"))
					{
						if (equips[num2].attachPVPBuffIDs != null && equips[num2].attachPVPBuffIDs.Count > 0)
						{
							list5.AddRange(equips[num2].attachPVPBuffIDs);
						}
						if (equips[num2].attachPVPMechanismIDs != null && equips[num2].attachPVPMechanismIDs.Count > 0)
						{
							list4.AddRange(equips[num2].attachPVPMechanismIDs);
						}
					}
					else
					{
						if (equips[num2].attachBuffIDs != null && equips[num2].attachBuffIDs.Count > 0)
						{
							list5.AddRange(equips[num2].attachBuffIDs);
						}
						if (equips[num2].attachMechanismIDs != null && equips[num2].attachMechanismIDs.Count > 0)
						{
							list4.AddRange(equips[num2].attachMechanismIDs);
						}
					}
				}
			}
			Dictionary<int, string> dictionary = new Dictionary<int, string>();
			string value = string.Empty;
			bool flag = false;
			for (int num3 = 0; num3 < equips.Count; num3++)
			{
				ItemTable tableItem6 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(equips[num3].itemID, string.Empty, string.Empty);
				if (tableItem6 != null && tableItem6.SubType >= ItemTable.eSubType.FASHION_HAIR && tableItem6.SubType <= ItemTable.eSubType.FASHION_EPAULET)
				{
					ResTable tableItem7 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem6.ResID, string.Empty, string.Empty);
					if (tableItem7 != null)
					{
						if (tableItem6.SubType == ItemTable.eSubType.FASHION_HEAD && !tableItem7.newFashion)
						{
							flag = true;
						}
						if (tableItem6.SubType == ItemTable.eSubType.FASHION_EPAULET)
						{
							value = tableItem7.ModelPath;
						}
						else
						{
							dictionary.Add((int)tableItem6.SubType, tableItem7.ModelPath);
						}
					}
				}
			}
			if (!flag && !string.IsNullOrEmpty(value))
			{
				dictionary.Add(16, value);
			}
			if (list4 != null)
			{
				this.LoadMechanisms(list4, 0, MechanismSourceType.EQUIP);
			}
			if (list5 != null)
			{
				this.LoadMechanismBuffs(list5, 0, ai == "town", null, true);
			}
			if (this.m_pkGeActor != null)
			{
				if (avatar != null && avatar.Count > 0)
				{
					this.m_pkGeActor.EquipFashions(avatar, 0);
				}
				else
				{
					this.m_pkGeActor.EquipFashions(dictionary, 0);
				}
			}
		}
		if (rankBuffList != null)
		{
			this._addBuff(rankBuffList, true, "rankBuffList");
		}
		if (petData != null && petData.buffs != null && petData.buffs.Count > 0)
		{
			this._addBuff(petData.buffs, true, "petData.buffs");
		}
		if (buffList != null)
		{
			int num4 = GlobalLogic.VALUE_3600 * GlobalLogic.VALUE_1000;
			for (int num5 = 0; num5 < buffList.Count; num5++)
			{
				BeBuff beBuff = null;
				if (base.IsProcessRecord())
				{
					VInt3 position = base.GetPosition();
					base.GetRecordServer().Mark(142055289U, new int[]
					{
						this.m_iID,
						buffList[num5].id,
						position.x,
						position.y,
						position.z,
						base.moveXSpeed.i,
						base.moveYSpeed.i,
						base.moveZSpeed.i,
						(!base.GetFace()) ? 0 : 1,
						this.attribute.GetHP(),
						this.attribute.GetMP(),
						this.m_kStateTag.GetAllFlag(),
						this.attribute.battleData.attack.ToInt()
					}, new string[]
					{
						base.GetName()
					});
				}
				if (buffList[num5].type == Battle.DungeonBuff.eBuffDurationType.Town || buffList[num5].type == Battle.DungeonBuff.eBuffDurationType.SpecialTown)
				{
					int num6 = IntMath.Float2Int(buffList[num5].lefttime * (float)GlobalLogic.VALUE_1000);
					if (num6 > 2147483647 || num6 < 0)
					{
						num6 = num4;
					}
					beBuff = this.buffController.TryAddBuff(buffList[num5].id, num6, 1);
				}
				else if (buffList[num5].type == Battle.DungeonBuff.eBuffDurationType.Battle)
				{
					beBuff = this.buffController.TryAddBuff(buffList[num5].id, num4, 1);
				}
				else if (buffList[num5].type == Battle.DungeonBuff.eBuffDurationType.OnlyUseInBattle && this.owner.CurrentBeScene != null)
				{
					beBuff = this.buffController.TryAddBuff(buffList[num5].id, num4, 1);
				}
				if (beBuff != null)
				{
					beBuff.passive = true;
					if (this.isLocalActor)
					{
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BattleBuffAdded, beBuff.buffID, this, null, null);
					}
				}
			}
		}
		this.PostInitSkills(ai == "town");
		this.PostInit();
	}

	// Token: 0x06016C31 RID: 93233 RVA: 0x006FA364 File Offset: 0x006F8764
	private void RemoveSuitProperty()
	{
		if (this.suitProperty != null)
		{
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			if (BattleMain.IsModePvP(base.battleType))
			{
				if (this.suitProperty.attachPVPBuffIDs != null && this.suitProperty.attachPVPBuffIDs.Count > 0)
				{
					list2.AddRange(this.suitProperty.attachPVPBuffIDs);
				}
				if (this.suitProperty.attachPVPMechanismIDs != null && this.suitProperty.attachPVPMechanismIDs.Count > 0)
				{
					list.AddRange(this.suitProperty.attachPVPMechanismIDs);
				}
			}
			else
			{
				if (this.suitProperty.attachBuffIDs != null && this.suitProperty.attachBuffIDs.Count > 0)
				{
					list2.AddRange(this.suitProperty.attachBuffIDs);
				}
				if (this.suitProperty.attachMechanismIDs != null && this.suitProperty.attachMechanismIDs.Count > 0)
				{
					list.AddRange(this.suitProperty.attachMechanismIDs);
				}
			}
			if (list != null)
			{
				this.RemoveMechanisms(list);
			}
			if (list2 != null)
			{
				this.RemoveMechanismBuffs(list2, null);
			}
		}
	}

	// Token: 0x06016C32 RID: 93234 RVA: 0x006FA494 File Offset: 0x006F8894
	private void ReloadSuitProperty(ItemProperty newWeapon, ItemProperty oldWeapon)
	{
		if (this.equips != null)
		{
			this.equips.RemoveAll((ItemProperty f) => f.guid == oldWeapon.guid);
			if (newWeapon != null)
			{
				this.equips.Add(newWeapon);
			}
			List<int> list = new List<int>();
			for (int i = 0; i < this.equips.Count; i++)
			{
				list.Add(this.equips[i].itemID);
			}
			List<int> list2 = new List<int>();
			List<int> list3 = new List<int>();
			this.suitProperty = DataManager<EquipSuitDataManager>.GetInstance().GetEquipSuitPropByIDs(list);
			if (this.suitProperty != null)
			{
				if (BattleMain.IsModePvP(base.battleType))
				{
					if (this.suitProperty.attachPVPBuffIDs != null && this.suitProperty.attachPVPBuffIDs.Count > 0)
					{
						list3.AddRange(this.suitProperty.attachPVPBuffIDs);
					}
					if (this.suitProperty.attachPVPMechanismIDs != null && this.suitProperty.attachPVPMechanismIDs.Count > 0)
					{
						list2.AddRange(this.suitProperty.attachPVPMechanismIDs);
					}
				}
				else
				{
					if (this.suitProperty.attachBuffIDs != null && this.suitProperty.attachBuffIDs.Count > 0)
					{
						list3.AddRange(this.suitProperty.attachBuffIDs);
					}
					if (this.suitProperty.attachMechanismIDs != null && this.suitProperty.attachMechanismIDs.Count > 0)
					{
						list2.AddRange(this.suitProperty.attachMechanismIDs);
					}
				}
			}
			if (list2 != null)
			{
				this.LoadMechanisms(list2, 0, MechanismSourceType.EQUIP);
			}
			if (list3 != null)
			{
				this.LoadMechanismBuffs(list3, 0, false, null, false);
			}
		}
	}

	// Token: 0x06016C33 RID: 93235 RVA: 0x006FA65F File Offset: 0x006F8A5F
	public void PostInit()
	{
		if (base.IsMonster())
		{
		}
	}

	// Token: 0x06016C34 RID: 93236 RVA: 0x006FA66C File Offset: 0x006F8A6C
	public void ReplaceWeapon(int resID, int tag, int strengthenLevel = 0)
	{
		ResTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(resID, string.Empty, string.Empty);
		if (tableItem != null && this.attachmentproxy != null)
		{
			base.SetDefaultHitSFX(tableItem.WeaponHitSFX);
			this.attachmentproxy.SetWeaponReplace(tableItem.ModelPath, tableItem.ActionConfigPath[0], tag, strengthenLevel);
		}
	}

	// Token: 0x06016C35 RID: 93237 RVA: 0x006FA6CB File Offset: 0x006F8ACB
	public void InitAI(BeAIManager manager)
	{
		this.aiManager = manager;
		this.aiManager.Init(this);
	}

	// Token: 0x06016C36 RID: 93238 RVA: 0x006FA6E0 File Offset: 0x006F8AE0
	public void StartAI(BeActor target, bool reduceSpeed = true)
	{
		if (this.aiManager.IsRunning())
		{
			return;
		}
		base.hasAI = true;
		this.ChangeRunMode(false);
		if (this.aiManager != null)
		{
			this.aiManager.reduceSpeed = reduceSpeed;
		}
		BeEntityData entityData = base.GetEntityData();
		if (entityData != null && reduceSpeed)
		{
			VFactor vfactor = VFactor.NewVFactorF(2f, 1000);
			if (this.aiManager.isAPC)
			{
				vfactor = VFactor.NewVFactorF(1.5f, 1000);
			}
			int z = this.walkSpeed.z;
			this.walkSpeed = IntMath.Divide(this.walkSpeed, vfactor.den, vfactor.nom);
			this.walkSpeed.z = z;
			z = this.runSpeed.z;
			this.runSpeed = IntMath.Divide(this.runSpeed, vfactor.den, vfactor.nom);
			this.runSpeed.z = z;
		}
		this.UpdateAITarget(target);
		this.aiManager.Start();
	}

	// Token: 0x06016C37 RID: 93239 RVA: 0x006FA7E8 File Offset: 0x006F8BE8
	public bool IsComboSkill(int skillID)
	{
		BDEntityActionInfo actionInfoBySkillID = base.GetActionInfoBySkillID(skillID);
		BeSkill skill = this.GetSkill(skillID);
		return actionInfoBySkillID != null && skill != null && skill.comboSkillSourceID != 0;
	}

	// Token: 0x06016C38 RID: 93240 RVA: 0x006FA81F File Offset: 0x006F8C1F
	public void UpdateAITarget(BeActor target)
	{
		if (target == null)
		{
			this.aiManager.FindTarget((float)GlobalLogic.VALUE_100);
		}
		else
		{
			this.aiManager.SetTarget(target, false);
		}
	}

	// Token: 0x06016C39 RID: 93241 RVA: 0x006FA84C File Offset: 0x006F8C4C
	public void UseAdjustBalance()
	{
		BeEntityData entityData = base.GetEntityData();
		if (entityData.adjustBalance)
		{
			return;
		}
		entityData.adjustBalance = true;
		entityData.SetAttributeValue(AttributeType.dex, Singleton<TableManager>.instance.gst.pkHitRateAdd, true);
	}

	// Token: 0x06016C3A RID: 93242 RVA: 0x006FA88B File Offset: 0x006F8C8B
	public void AddStateBar(string text, int duration)
	{
		if (this.m_pkGeActor != null)
		{
			this.m_pkGeActor.CreateStateBar(text, duration);
		}
	}

	// Token: 0x06016C3B RID: 93243 RVA: 0x006FA8A5 File Offset: 0x006F8CA5
	public void RemoveStateBar()
	{
		if (this.m_pkGeActor != null)
		{
			this.m_pkGeActor.RemoveStateBar();
		}
	}

	// Token: 0x06016C3C RID: 93244 RVA: 0x006FA8BD File Offset: 0x006F8CBD
	public void UseProtect()
	{
		this.protectManager.SetEnable(true);
	}

	// Token: 0x06016C3D RID: 93245 RVA: 0x006FA8CB File Offset: 0x006F8CCB
	public void ClearProtect()
	{
		this.protectManager.ClearUp();
	}

	// Token: 0x06016C3E RID: 93246 RVA: 0x006FA8D8 File Offset: 0x006F8CD8
	public void UpdateProtect(int delta)
	{
		if (this.protectManager.IsEnable())
		{
			this.protectManager.Tick(delta);
		}
	}

	// Token: 0x06016C3F RID: 93247 RVA: 0x006FA8F6 File Offset: 0x006F8CF6
	public sealed override void OnHurt(int value, BeEntity attacker, HitTextType curHitTextType)
	{
		if (this.protectManager.IsEnable() && curHitTextType != HitTextType.FRIEND_HURT)
		{
			this.protectManager.Update(value);
		}
	}

	// Token: 0x06016C40 RID: 93248 RVA: 0x006FA91C File Offset: 0x006F8D1C
	public void UseActorData()
	{
		this.actorData.SetEnable(true);
	}

	// Token: 0x06016C41 RID: 93249 RVA: 0x006FA92A File Offset: 0x006F8D2A
	public void UpdateActorData(int delta)
	{
		if (this.actorData.IsEnable())
		{
			this.actorData.Update(delta);
		}
		this.actorData.UpdateLogic(delta);
	}

	// Token: 0x06016C42 RID: 93250 RVA: 0x006FA954 File Offset: 0x006F8D54
	public SpellBar StartSpellBar(eDungeonCharactorBar type, int time, bool autodelete = true, string text = "", bool reverse = false)
	{
		SpellBar spellBar = this.mBars.Find((SpellBar x) => x.type == type);
		if (spellBar == null)
		{
			IDungeonCharactorBar dungeonCharactorBar = this.m_pkGeActor.CreateBar(type);
			if (dungeonCharactorBar != null)
			{
				dungeonCharactorBar.SetBarType(type);
				dungeonCharactorBar.SetText(text);
			}
			spellBar = new SpellBar
			{
				type = type
			};
			if (dungeonCharactorBar != null)
			{
				spellBar.com = (dungeonCharactorBar as ComDungeonCharactorHeadBar);
			}
			this.mBars.Add(spellBar);
		}
		else if (type == eDungeonCharactorBar.Continue)
		{
			spellBar.reverse = false;
			spellBar.duration = time;
			spellBar.active = true;
			spellBar.autodelete = autodelete;
			return spellBar;
		}
		if (spellBar != null)
		{
			spellBar.acc = 0;
			spellBar.duration = time;
			spellBar.active = true;
			spellBar.autodelete = autodelete;
			spellBar.autoAcc = true;
			spellBar.reverseAutoAcc = true;
			if (reverse)
			{
				spellBar.acc = spellBar.duration;
				spellBar.reverse = true;
			}
		}
		return spellBar;
	}

	// Token: 0x06016C43 RID: 93251 RVA: 0x006FAA64 File Offset: 0x006F8E64
	public void UpdateSpellBarsGraphic(int delta)
	{
		for (int i = 0; i < this.mBars.Count; i++)
		{
			SpellBar spellBar = this.mBars[i];
			if (spellBar.active && spellBar.acc <= spellBar.duration && spellBar.acc > 0)
			{
				bool show = true;
				if (spellBar.type == eDungeonCharactorBar.Continue && !this.isLocalActor)
				{
					show = false;
				}
				this.m_pkGeActor.SetBar(spellBar.type, 1f * (float)spellBar.acc / (float)spellBar.duration, show);
				this.m_pkGeActor.SetCdTime(spellBar.type, (float)spellBar.acc / 1000f, show);
			}
		}
	}

	// Token: 0x06016C44 RID: 93252 RVA: 0x006FAB24 File Offset: 0x006F8F24
	public void UpdateSpellBarsWithActor(int delta)
	{
		bool flag = false;
		for (int i = 0; i < this.mBars.Count; i++)
		{
			SpellBar spellBar = this.mBars[i];
			if (spellBar.type == eDungeonCharactorBar.DunFu || spellBar.type == eDungeonCharactorBar.DunFuCD || spellBar.type == eDungeonCharactorBar.Loop || spellBar.type == eDungeonCharactorBar.Power || spellBar.type == eDungeonCharactorBar.RayDrop || spellBar.type == eDungeonCharactorBar.Sing || spellBar.type == eDungeonCharactorBar.Progress || spellBar.type == eDungeonCharactorBar.MonsterEnergyBar)
			{
				bool flag2 = this._updateSpellBar(spellBar, delta);
				if (flag2)
				{
					flag = true;
				}
			}
		}
		if (flag)
		{
			this.mBars.RemoveAll((SpellBar x) => !x.active);
		}
	}

	// Token: 0x06016C45 RID: 93253 RVA: 0x006FAC00 File Offset: 0x006F9000
	public void UpdateSpellBarsWithBuff(int delta)
	{
		bool flag = false;
		for (int i = 0; i < this.mBars.Count; i++)
		{
			SpellBar spellBar = this.mBars[i];
			if (spellBar.type == eDungeonCharactorBar.Buff || spellBar.type == eDungeonCharactorBar.Continue || spellBar.type == eDungeonCharactorBar.Fire || spellBar.type == eDungeonCharactorBar.Progress)
			{
				bool flag2 = this._updateSpellBar(spellBar, delta);
				if (flag2)
				{
					flag = true;
				}
				else if (spellBar.alwaysRefreshUI && this.m_pkGeActor != null && spellBar.acc <= spellBar.duration && spellBar.acc > 0)
				{
					bool show = true;
					if (spellBar.type == eDungeonCharactorBar.Continue && !this.isLocalActor)
					{
						show = false;
					}
					this.m_pkGeActor.SetBar(spellBar.type, 1f * (float)spellBar.acc / (float)spellBar.duration, show);
					this.m_pkGeActor.SetCdTime(spellBar.type, (float)spellBar.acc / 1000f, show);
				}
			}
		}
		if (flag)
		{
			this.mBars.RemoveAll((SpellBar x) => !x.active);
		}
	}

	// Token: 0x06016C46 RID: 93254 RVA: 0x006FAD48 File Offset: 0x006F9148
	private bool _updateSpellBar(SpellBar bar, int delta)
	{
		bool result = false;
		if (bar.active)
		{
			if (bar.reverse)
			{
				if (bar.reverseAutoAcc)
				{
					bar.acc -= delta;
				}
			}
			else if (bar.autoAcc)
			{
				bar.acc += delta;
			}
			if (bar.acc > bar.duration || bar.acc <= 0)
			{
				if (bar.autodelete)
				{
					bar.active = false;
					bar.acc = 0;
					this.StopSpellBar(bar.type, false);
					if (!bar.reverse && bar.com != null)
					{
						GeEffectEx geEffectEx = this.m_pkGeActor.CreateEffect("Effects/Hero_Jixieshi/EZ-8Zibaozhe/Perfab/Eff_Ez-8Zibaozhe_guang", string.Empty, 0f, new Vec3(0f, 0f, 0f), 1f, 1f, false, false, EffectTimeType.SYNC_ANIMATION, false);
						if (geEffectEx != null)
						{
							GeUtility.AttachTo(geEffectEx.GetRootNode(), this.m_pkGeActor.mBarsRoot.transform.parent.gameObject, false);
							geEffectEx.SetPosition(bar.com.transform.position);
						}
					}
				}
			}
			if (bar.acc >= bar.duration)
			{
				bar.acc = bar.duration;
			}
		}
		if (!bar.active)
		{
			result = true;
		}
		return result;
	}

	// Token: 0x06016C47 RID: 93255 RVA: 0x006FAEB4 File Offset: 0x006F92B4
	public void StopSpellBar(eDungeonCharactorBar type, bool cancel = true)
	{
		SpellBar spellBar = this.mBars.Find((SpellBar x) => x.type == type);
		if (spellBar != null)
		{
			spellBar.active = false;
		}
		if (this.m_pkGeActor != null)
		{
			this.m_pkGeActor.StopBar(type, cancel);
		}
	}

	// Token: 0x06016C48 RID: 93256 RVA: 0x006FAF10 File Offset: 0x006F9310
	public void SetSpellBarReverse(eDungeonCharactorBar type, bool flag)
	{
		SpellBar spellBar = this.mBars.Find((SpellBar x) => x.type == type);
		if (spellBar != null)
		{
			spellBar.reverse = flag;
		}
	}

	// Token: 0x06016C49 RID: 93257 RVA: 0x006FAF50 File Offset: 0x006F9350
	public int GetSpellBarDuration(eDungeonCharactorBar type)
	{
		int result = 0;
		SpellBar spellBar = this.mBars.Find((SpellBar x) => x.type == type);
		if (spellBar != null)
		{
			result = spellBar.acc;
		}
		return result;
	}

	// Token: 0x06016C4A RID: 93258 RVA: 0x006FAF94 File Offset: 0x006F9394
	public void AddSpellBarProgress(eDungeonCharactorBar type, VFactor addProgress)
	{
		SpellBar spellBar = this.mBars.Find((SpellBar x) => x.type == type);
		if (spellBar != null)
		{
			spellBar.acc += spellBar.duration * addProgress;
		}
	}

	// Token: 0x06016C4B RID: 93259 RVA: 0x006FAFE8 File Offset: 0x006F93E8
	public void AddSpellBarProgress(eDungeonCharactorBar type, float addProgress)
	{
		SpellBar spellBar = this.mBars.Find((SpellBar x) => x.type == type);
		if (spellBar != null)
		{
			float num = (float)spellBar.duration * addProgress;
			spellBar.acc += (int)num;
		}
	}

	// Token: 0x06016C4C RID: 93260 RVA: 0x006FB03C File Offset: 0x006F943C
	public int GetSpelBarProgress(eDungeonCharactorBar type)
	{
		SpellBar spellBar = this.mBars.Find((SpellBar x) => x.type == type);
		if (spellBar != null)
		{
			return spellBar.acc / spellBar.duration;
		}
		return 0;
	}

	// Token: 0x06016C4D RID: 93261 RVA: 0x006FB084 File Offset: 0x006F9484
	public int GetWeaponType()
	{
		int result = 0;
		if (this.attribute != null)
		{
			return this.attribute.GetWeaponType();
		}
		return result;
	}

	// Token: 0x06016C4E RID: 93262 RVA: 0x006FB0AC File Offset: 0x006F94AC
	public int GetWeaponID()
	{
		int result = 0;
		if (this.attribute != null)
		{
			result = this.attribute.GetWeaponItemID();
		}
		return result;
	}

	// Token: 0x06016C4F RID: 93263 RVA: 0x006FB0D4 File Offset: 0x006F94D4
	public void ChangeWeapon(int index, int weaponStrengthenLevel = 0)
	{
		if (this.attribute == null || this.attribute.backupWeapons.Count <= index || this.attribute.currentWeapon == null)
		{
			return;
		}
		Dictionary<int, CrypticInt32> dictionary = new Dictionary<int, CrypticInt32>(this.attribute.skillLevelInfo);
		ItemProperty currentWeapon = this.attribute.currentWeapon;
		if (BattleMain.IsModePvP(base.battleType))
		{
			this.RemoveMechanisms(currentWeapon.attachPVPMechanismIDs);
			this.RemoveMechanismBuffs(currentWeapon.attachPVPBuffIDs, currentWeapon);
		}
		else
		{
			this.RemoveMechanisms(currentWeapon.attachMechanismIDs);
			this.RemoveMechanismBuffs(currentWeapon.attachBuffIDs, currentWeapon);
		}
		this.RemoveSuitProperty();
		this.attribute.ChangeWeapon(index);
		ItemProperty currentWeapon2 = this.attribute.currentWeapon;
		this.ReloadSuitProperty(currentWeapon2, currentWeapon);
		if (BattleMain.IsModePvP(base.battleType))
		{
			this.LoadMechanisms(currentWeapon2.attachPVPMechanismIDs, 0, MechanismSourceType.EQUIP);
			this.LoadMechanismBuffs(currentWeapon2.attachPVPBuffIDs, 0, false, currentWeapon2, false);
		}
		else
		{
			this.LoadMechanisms(currentWeapon2.attachMechanismIDs, 0, MechanismSourceType.EQUIP);
			this.LoadMechanismBuffs(currentWeapon2.attachBuffIDs, 0, false, currentWeapon2, false);
		}
		this.m_cpkEntityInfo.SetWeaponInfo(this.attribute.GetWeaponTag(), this.attribute.GetWeaponType());
		if (this.m_cpkCurEntityActionInfo != null)
		{
			string currentActionName = this.m_cpkEntityInfo.GetCurrentActionName();
			if (this.m_cpkEntityInfo.HasAction(currentActionName))
			{
				this.m_cpkCurEntityActionInfo = this.m_cpkEntityInfo._vkActionsMap[currentActionName];
				this.attachmentproxy.Init(this.m_cpkCurEntityActionInfo);
			}
		}
		this.ChangeWeaponModle(currentWeapon2.strengthen);
		this.attachmentproxy.Update(0f);
		if (base.IsCastingSkill())
		{
			this.SetSkillPhases(this.m_iCurSkillID);
		}
		ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>(currentWeapon.itemID, string.Empty, string.Empty);
		ItemTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ItemTable>(currentWeapon2.itemID, string.Empty, string.Empty);
		base.TriggerEvent(BeEventType.OnChangeWeapon, new object[]
		{
			tableItem,
			tableItem2
		});
		Dictionary<int, CrypticInt32> dictionary2 = new Dictionary<int, CrypticInt32>(this.attribute.skillLevelInfo);
		foreach (KeyValuePair<int, CrypticInt32> keyValuePair in dictionary)
		{
			int key = keyValuePair.Key;
			Dictionary<int, CrypticInt32>.Enumerator enumerator = new Dictionary<int, CrypticInt32>.Enumerator();
			KeyValuePair<int, CrypticInt32> keyValuePair2 = enumerator.Current;
			int num = keyValuePair2.Value;
			int num2 = 0;
			if (dictionary2.ContainsKey(key))
			{
				num2 = dictionary2[key];
			}
			if (num != num2)
			{
				BeSkill skill = this.GetSkill(key);
				if (skill != null)
				{
					skill.OnInit();
					if (skill.skillData != null && skill.skillData.SkillType == SkillTable.eSkillType.PASSIVE)
					{
						skill.OnPostInit();
					}
					skill.DealLevelChange();
				}
			}
		}
		foreach (KeyValuePair<int, BeSkill> keyValuePair3 in this.skillList)
		{
			BeSkill value = keyValuePair3.Value;
			if (value != null)
			{
				value.comboSkillSourceID = 0;
			}
		}
		foreach (KeyValuePair<int, BeSkill> keyValuePair4 in this.skillList)
		{
			BeSkill value2 = keyValuePair4.Value;
			if (value2 != null)
			{
				value2.DealWeaponChange();
			}
		}
		if (this.isLocalActor)
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				clientSystemBattle.ChangeWeaponIcon(currentWeapon.itemID);
			}
			if (!Singleton<ReplayServer>.GetInstance().IsReplay())
			{
				BeUtility.ChangeWeaponInBattle(currentWeapon2.guid, currentWeapon.guid);
			}
		}
		if (this.m_pkGeActor != null && this.m_pkGeActor.mCurHpBar != null)
		{
			this.m_pkGeActor.mCurHpBar.InitResistMagic(this.attribute.GetResistMagic(), this);
		}
		base.TriggerEvent(BeEventType.OnChangeWeaponEnd, new object[0]);
	}

	// Token: 0x06016C50 RID: 93264 RVA: 0x006FB4C8 File Offset: 0x006F98C8
	public void ChangeWeaponModle(int weaponStrengthenLevel)
	{
		int weaponID = this.GetWeaponID();
		if (weaponID > 0)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(weaponID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.ReplaceWeapon(tableItem.ResID, tableItem.Tag, weaponStrengthenLevel);
			}
		}
		else
		{
			JobTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(this.attribute.professtion, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				base.SetDefaultHitSFX(tableItem2.DefaultHitSFXID);
			}
		}
	}

	// Token: 0x06016C51 RID: 93265 RVA: 0x006FB54C File Offset: 0x006F994C
	protected void InitFashionWeapon(List<ItemProperty> equips, int jobId)
	{
		if (equips == null)
		{
			return;
		}
		for (int i = 0; i < equips.Count; i++)
		{
			int id = equips[i].itemID;
			ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>(id, string.Empty, string.Empty);
			if (tableItem != null && tableItem.SubType == ItemTable.eSubType.FASHION_WEAPON)
			{
				ResTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem.ResID, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					JobTable tableItem3 = Singleton<TableManager>.instance.GetTableItem<JobTable>(jobId, string.Empty, string.Empty);
					if (tableItem3 != null)
					{
						if (this.attachmentproxy != null)
						{
							this.attachmentproxy.SetShowFashionWeapon(tableItem2.ModelPath, tableItem3.DefaultWeaponPath);
						}
					}
				}
			}
		}
	}

	// Token: 0x06016C52 RID: 93266 RVA: 0x006FB623 File Offset: 0x006F9A23
	public bool IsSkillMonster()
	{
		return (base.IsMonster() || this.m_iCamp == 0) && this.attribute.type == 8 && !this.attribute.skillMonsterCanBeAttack;
	}

	// Token: 0x06016C53 RID: 93267 RVA: 0x006FB65D File Offset: 0x006F9A5D
	public bool IsCanCritDead()
	{
		return base.IsMonster() && this.attribute.type != 3;
	}

	// Token: 0x06016C54 RID: 93268 RVA: 0x006FB680 File Offset: 0x006F9A80
	public void ShowSpeech(ActionState state)
	{
		if (this.walkSpeeches == null && this.attackSpeeches == null)
		{
			return;
		}
		IList<int> list = null;
		if (state == ActionState.AS_BIRTH)
		{
			list = this.birthSpeeches;
		}
		else if (base.FrameRandom.InRange(1, GlobalLogic.VALUE_100) < 95)
		{
			return;
		}
		if (state == ActionState.AS_WALK || state == ActionState.AS_RUN || state == ActionState.AS_IDLE)
		{
			list = this.walkSpeeches;
		}
		else if (state == ActionState.AS_CASTSKILL)
		{
			list = this.attackSpeeches;
		}
		if (list != null && list.Count > 0 && list[0] != 0)
		{
			int index = base.FrameRandom.InRange(0, list.Count);
			MonsterSpeech tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MonsterSpeech>(list[index], string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.m_pkGeActor.ShowHeadDialog(tableItem.Speech, false, false, false, false, 3.5f, base.GetEntityData().isPet);
			}
		}
	}

	// Token: 0x06016C55 RID: 93269 RVA: 0x006FB77C File Offset: 0x006F9B7C
	public void ShowSpeech(int index)
	{
		MonsterSpeech tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MonsterSpeech>(index, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return;
		}
		if (this.m_pkGeActor != null)
		{
			this.m_pkGeActor.ShowHeadDialog(tableItem.Speech, false, false, false, false, 3.5f, base.GetEntityData().isPet);
		}
		else
		{
			Logger.LogErrorFormat("ShowSpeech monsterID:{0},resID:{1}", new object[]
			{
				base.GetEntityData().monsterID,
				this.m_iResID
			});
		}
	}

	// Token: 0x06016C56 RID: 93270 RVA: 0x006FB80C File Offset: 0x006F9C0C
	public bool CanUseDunfu()
	{
		if (base.IsGrabed())
		{
			return false;
		}
		if (this.stateController != null && (this.stateController.WillBeGrab() || this.stateController.IsGraping() || this.stateController.IsBeingGrab()))
		{
			return false;
		}
		if (this.buffController.HasBuffByID(101) != null)
		{
			return false;
		}
		BeSkill skill = this.GetSkill(10001);
		return skill != null && !this.HaveDebuff() && (!this.isDead && skill.CanUseSkill()) && this.attackButtonState == ButtonState.PRESS;
	}

	// Token: 0x06016C57 RID: 93271 RVA: 0x006FB8B8 File Offset: 0x006F9CB8
	public bool HaveDebuff()
	{
		return this.stateController.HasBuffState(BeBuffStateType.SLEEP) || this.stateController.HasBuffState(BeBuffStateType.STUN) || this.stateController.HasBuffState(BeBuffStateType.STONE) || this.stateController.HasBuffState(BeBuffStateType.FROZEN);
	}

	// Token: 0x06016C58 RID: 93272 RVA: 0x006FB918 File Offset: 0x006F9D18
	public void StartDunfu()
	{
		this.isDunFu = true;
		this.pressDunfuDurTime = -1;
		this.DunFuTimeAcc = 0;
		if (BattleMain.IsModePvP(base.battleType))
		{
			this.DunFuTimeout = IntMath.Float2Int(Global.Settings.pvpDunFuTime * (float)GlobalLogic.VALUE_1000);
		}
		else
		{
			this.DunFuTimeout = IntMath.Float2Int(Global.Settings.dunFuTime * (float)GlobalLogic.VALUE_1000);
		}
		this.delayCaller.DelayCall(GlobalLogic.VALUE_50, delegate
		{
			this.m_pkGeActor.Pause(1, true);
		}, 0, 0, false);
		this.StartSpellBar(eDungeonCharactorBar.Loop, this.DunFuTimeout, true, string.Empty, true);
		this.buffController.TryAddBuff(38, this.DunFuTimeout, 1);
		BeSkill skill = this.GetSkill(10001);
		if (skill != null)
		{
			skill.Start();
			skill.Finish();
		}
	}

	// Token: 0x06016C59 RID: 93273 RVA: 0x006FB9EF File Offset: 0x006F9DEF
	public ButtonState GetCurrentBtnState()
	{
		return this.attackButtonState;
	}

	// Token: 0x06016C5A RID: 93274 RVA: 0x006FB9F8 File Offset: 0x006F9DF8
	public bool UpdateDunfu(int delta)
	{
		if (this.isDunFu)
		{
			bool flag = false;
			if (this.pressDunfuDurTime >= 0)
			{
				this.pressDunfuDurTime += delta;
				if (this.pressDunfuDurTime >= GlobalLogic.VALUE_500)
				{
					flag = true;
					this.StopSpellBar(eDungeonCharactorBar.Loop, false);
					this.pressDunfuDurTime = -1;
				}
			}
			else if (this.attackButtonState == ButtonState.PRESS)
			{
				this.DunFuTimeAcc += delta;
				if (this.DunFuTimeAcc >= this.DunFuTimeout)
				{
					flag = true;
					this.SetAttackButtonState(ButtonState.RELEASE, true);
					this.StopSpellBar(eDungeonCharactorBar.Loop, false);
				}
			}
			else if (this.attackButtonState == ButtonState.RELEASE)
			{
				this.pressDunfuDurTime = this.DunFuTimeAcc;
			}
			if (flag)
			{
				this.m_pkGeActor.Resume(1);
				this.isDunFu = false;
				this.buffController.RemoveBuff(38, 0, 0);
				this.buffController.TryAddBuff(34, GlobalLogic.VALUE_500, 1);
				return true;
			}
		}
		return false;
	}

	// Token: 0x06016C5B RID: 93275 RVA: 0x006FBAEB File Offset: 0x006F9EEB
	public void StartDeadProtect()
	{
		this.m_deadProtectDurTime = 0;
		this.m_isInDeadProtect = true;
	}

	// Token: 0x06016C5C RID: 93276 RVA: 0x006FBAFB File Offset: 0x006F9EFB
	public void EndDeadProtect()
	{
		this.m_deadProtectDurTime = 0;
		this.m_isInDeadProtect = false;
	}

	// Token: 0x06016C5D RID: 93277 RVA: 0x006FBB0C File Offset: 0x006F9F0C
	private void _updateDeadProtect(int delta)
	{
		if (this.m_isInDeadProtect)
		{
			this.m_deadProtectDurTime += delta;
			if (this.m_deadProtectDurTime >= GlobalLogic.VALUE_10000 + GlobalLogic.VALUE_1500)
			{
				this.m_isInDeadProtect = false;
				this.m_deadProtectDurTime = 0;
				base.TriggerEvent(BeEventType.onDeadProtectEnd, null);
			}
		}
	}

	// Token: 0x17001F25 RID: 7973
	// (get) Token: 0x06016C5E RID: 93278 RVA: 0x006FBB62 File Offset: 0x006F9F62
	public bool IsInDeadProtect
	{
		get
		{
			return this.m_isInDeadProtect;
		}
	}

	// Token: 0x06016C5F RID: 93279 RVA: 0x006FBB6C File Offset: 0x006F9F6C
	public void CancelSkills()
	{
		foreach (KeyValuePair<int, BeSkill> keyValuePair in this.skillList)
		{
			BeSkill value = keyValuePair.Value;
			if (value != null)
			{
				value.Cancel();
			}
		}
	}

	// Token: 0x06016C60 RID: 93280 RVA: 0x006FBBB4 File Offset: 0x006F9FB4
	public sealed override void OnDead()
	{
		base.OnDead();
		this.SetAttackButtonState(ButtonState.RELEASE, true);
		this.RemoveAllMechanism();
		this.ResetSkillCoolDown();
		this.CancelSkills();
		this.buffController.RemoveInPassiveBuff();
		this.buffController.RemoveRangerTriggerBuff();
		base.SetBlockLayer(false);
		this.DeletePressCountRes();
		if (!base.IsMonster())
		{
			this.buffController.TriggerBuffs(BuffCondition.PLAYER_DEAD, null, null);
		}
		if (!base.IsBoss() && this.m_pkGeActor != null)
		{
			this.m_pkGeActor.RemoveSurface(uint.MaxValue);
		}
		this.CheckAutoReborn();
		this.RemoveSkillJoyStick();
	}

	// Token: 0x06016C61 RID: 93281 RVA: 0x006FBC4C File Offset: 0x006FA04C
	public void ResetActorStatus()
	{
		this.SetAttackButtonState(ButtonState.RELEASE, true);
		this.RemoveAllMechanism();
		this.CancelSkills();
		this.ResetSkillCoolDown();
		this.buffController.RemoveInPassiveBuff();
		this.buffController.RemoveRangerTriggerBuff();
		base.SetBlockLayer(false);
		this.DeletePressCountRes();
		this.m_pkGeActor.RemoveSurface(uint.MaxValue);
		this.m_pkStateGraph.ClearStateStack();
		foreach (KeyValuePair<int, BeSkill> keyValuePair in this.GetSkills())
		{
			BeSkill value = keyValuePair.Value;
			value.AddMechanisms();
		}
		this.LoadMechanisms(this.recordedEquipMechanismIDs, 0, MechanismSourceType.EQUIP);
		this.recordedEquipMechanismIDs.Clear();
		base.Reset();
		this.StartInitCDForSkill(false);
	}

	// Token: 0x06016C62 RID: 93282 RVA: 0x006FBD08 File Offset: 0x006FA108
	public sealed override void Reborn()
	{
		this.dungeonRebornCount++;
		this.SetAttackButtonState(ButtonState.RELEASE, true);
		this.m_pkStateGraph.ClearStateStack();
		this.ResetSkillCoolDown();
		this.buffController.RemoveInPassiveBuff();
		foreach (KeyValuePair<int, BeSkill> keyValuePair in this.GetSkills())
		{
			BeSkill value = keyValuePair.Value;
			value.AddMechanisms();
		}
		this.LoadMechanisms(this.recordedEquipMechanismIDs, 0, MechanismSourceType.EQUIP);
		this.recordedEquipMechanismIDs.Clear();
		base.Reborn();
		this.buffController.TryAddBuff(2, GlobalLogic.VALUE_2000, 1);
		this.UseSkill(9998, true);
		base.TriggerEvent(BeEventType.onReborn, null);
		UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BattlePlayerAlive, null, null, null, null);
		if (this.aiManager != null && (this.aiManager.isAutoFight || this.attribute.isMonster))
		{
			this.aiManager.Start();
		}
		if (base.IsProcessRecord())
		{
			base.GetRecordServer().Mark(142055297U, new int[]
			{
				this.m_iID
			}, new string[]
			{
				base.GetName()
			});
		}
		if (this.m_pkGeActor != null)
		{
			this.m_pkGeActor.RemoveSurface(uint.MaxValue);
		}
		else
		{
			int num = (base.GetEntityData() == null) ? 0 : base.GetEntityData().professtion;
			int num2 = (base.GetEntityData() == null) ? 0 : base.GetEntityData().monsterID;
			string text = (base.GetEntityData() == null) ? string.Empty : base.GetEntityData().name;
			Logger.LogErrorFormat("Reborn occur error {0} {1} {2} {3}", new object[]
			{
				this.m_iID,
				num,
				num2,
				text
			});
		}
		if (Global.Settings.isDebug && Global.Settings.playerRebornHP > 0)
		{
			base.GetEntityData().SetHP(Global.Settings.playerRebornHP);
			base.GetEntityData().SetMaxHP(Global.Settings.playerRebornHP);
			if (this.m_pkGeActor != null)
			{
				this.m_pkGeActor.ResetHPBar();
			}
		}
		if (base.CurrentBeScene.mBattle.dungeonPlayerManager.GetAllPlayers().Count > 1 && this.m_pkGeActor != null)
		{
			this.m_pkGeActor.SetActorVisible(true);
		}
		this.buffController.RefreshBuffStateOnReborn();
		this.RemoveDeadHandle();
	}

	// Token: 0x06016C63 RID: 93283 RVA: 0x006FBF9A File Offset: 0x006FA39A
	public void LevelUp(int levelAdd)
	{
		this.attribute.CalculateLevelGrow(levelAdd + 1);
		this.attribute.PostInit(null);
		this.m_pkGeActor.ResetHPBar();
	}

	// Token: 0x06016C64 RID: 93284 RVA: 0x006FBFC4 File Offset: 0x006FA3C4
	public void LevelUpTo(int newLevel)
	{
		int num = newLevel - this.attribute.level;
		if (num > 0)
		{
			this.attribute.level = newLevel;
			this.LevelUp(num);
			this.m_pkGeActor.UpdateInfoBarLevel((ushort)newLevel, false);
			this.m_pkGeActor.OnLevelChanged(newLevel);
		}
	}

	// Token: 0x06016C65 RID: 93285 RVA: 0x006FC020 File Offset: 0x006FA420
	public void SetAttackButtonState(ButtonState bs, bool resetSpecialSkillCombo = true)
	{
		this.attackButtonState = bs;
		if (bs == ButtonState.PRESS)
		{
			base.TriggerEvent(BeEventType.onCastNormalAttack, null);
		}
		if (resetSpecialSkillCombo && bs == ButtonState.RELEASE)
		{
			base.TriggerEventNew(BeEventType.onSpecialSkillComboRelease, default(EventParam));
		}
	}

	// Token: 0x06016C66 RID: 93286 RVA: 0x006FC063 File Offset: 0x006FA463
	public void SetAttackCheckFlag(bool flag)
	{
		this.aiAttackNeedCheck = flag;
	}

	// Token: 0x06016C67 RID: 93287 RVA: 0x006FC06C File Offset: 0x006FA46C
	public sealed override void OnDealFrameTag(DSFFrameTags frameTag)
	{
		base.OnDealFrameTag(frameTag);
		if (frameTag == DSFFrameTags.TAG_SET_TARGET_POS_XY && base.IsMonster() && this.aiManager != null && this.aiManager.aiTarget != null)
		{
			VInt3 position = this.aiManager.aiTarget.GetPosition();
			base.SetStandPosition(new VInt3(position.x, position.y, base.GetPosition().z), false);
		}
	}

	// Token: 0x06016C68 RID: 93288 RVA: 0x006FC0EC File Offset: 0x006FA4EC
	private void StartPressCountBase(BeActor.QuickPressType type)
	{
		if (!this.isMainActor)
		{
			return;
		}
		if (this.isRecordPress)
		{
			return;
		}
		this.quickPressType = type;
		this.isRecordPress = true;
		this.pressCount = 0;
		if (this.isLocalActor)
		{
			VInt3 position = base.GetPosition();
			position.z += VInt.Float2VIntValue(3f);
			if (this.recordPressEffect == null)
			{
				this.recordPressEffect = this.currentBeScene.currentGeScene.CreateEffect("Effects/Common/Sfx/Yaogan/Prefab/Eff_common_yaogan", 999999f, position.vec3, 1f, 1f, false, false);
			}
			if (this.recordPressEffect != null)
			{
				this.recordPressEffect.SetVisible(true);
				this.recordPressEffect.SetPosition(position.vector3);
			}
		}
	}

	// Token: 0x06016C69 RID: 93289 RVA: 0x006FC1B8 File Offset: 0x006FA5B8
	public void UpdatePressPosition()
	{
		if (!this.isRecordPress)
		{
			return;
		}
		if (this.recordPressEffect == null)
		{
			return;
		}
		if (this.isLocalActor)
		{
			VInt3 position = base.GetPosition();
			position.z += VInt.Float2VIntValue(3f);
			this.recordPressEffect.SetPosition(position.vector3);
		}
	}

	// Token: 0x06016C6A RID: 93290 RVA: 0x006FC219 File Offset: 0x006FA619
	public void StartPressCount(BeActor.QuickPressType type, BeActor actor)
	{
		this.thisActor = actor;
		this.StartPressCountBase(type);
	}

	// Token: 0x06016C6B RID: 93291 RVA: 0x006FC229 File Offset: 0x006FA629
	public void StartPressCount(BeActor.QuickPressType type, BeBuff buff)
	{
		this.thisBuff = buff;
		this.StartPressCountBase(type);
	}

	// Token: 0x06016C6C RID: 93292 RVA: 0x006FC23C File Offset: 0x006FA63C
	public void RecordPressCount()
	{
		if (!this.isRecordPress)
		{
			return;
		}
		this.pressCount++;
		if (this.quickPressType == BeActor.QuickPressType.BUFF)
		{
			if (this.pressCount >= 2)
			{
				this.pressCount -= 2;
				if (this.thisBuff != null)
				{
					this.thisBuff.ReduceDuration(GlobalLogic.VALUE_50, true);
				}
				base._addShock(0.1f, 30f, 0.05f, 0f, 0);
			}
		}
		else
		{
			if (this.pressCount > 0 && this.pressCount % 2 == 0)
			{
				base._addShock(0.1f, 30f, 0.05f, 0f, 0);
			}
			int[] array = new int[]
			{
				this.pressCount
			};
			base.TriggerEvent(BeEventType.onGrabPressCountAdd, new object[]
			{
				array
			});
			if (array[0] >= 20 && this.thisActor != null && this.thisActor.IsCastingSkill())
			{
				this.thisActor.sgSwitchStates(new BeStateData(4, 0));
				this.EndPressCount();
			}
		}
	}

	// Token: 0x06016C6D RID: 93293 RVA: 0x006FC35C File Offset: 0x006FA75C
	public override bool IsCurSkillOpenShock()
	{
		if (this.owner.CurrentBeBattle != null && !this.owner.CurrentBeBattle.FunctionIsOpen(BattleFlagType.JunXingShock) && (base.GetEntityData().MonsterIDEqual(94100031) || base.GetEntityData().MonsterIDEqual(90000031)))
		{
			InputManager.CameraShockMode cameraShockMode = Singleton<SettingManager>.GetInstance().GetCameraShockMode();
			return cameraShockMode == InputManager.CameraShockMode.OPEN;
		}
		BeSkill skill = this.GetSkill(this.m_iCurSkillID);
		return skill == null || skill.IsOpenCameraShock();
	}

	// Token: 0x06016C6E RID: 93294 RVA: 0x006FC3EC File Offset: 0x006FA7EC
	public void EndPressCount()
	{
		if (!this.isMainActor)
		{
			return;
		}
		if (!this.isRecordPress)
		{
			return;
		}
		this.isRecordPress = false;
		if (this.isLocalActor && this.recordPressEffect != null)
		{
			this.recordPressEffect.SetVisible(false);
		}
	}

	// Token: 0x06016C6F RID: 93295 RVA: 0x006FC43A File Offset: 0x006FA83A
	public void DeletePressCountRes()
	{
		if (this.recordPressEffect != null)
		{
			this.m_pkGeActor.DestroyEffect(this.recordPressEffect);
			this.recordPressEffect = null;
		}
	}

	// Token: 0x06016C70 RID: 93296 RVA: 0x006FC460 File Offset: 0x006FA860
	public void SetAccompanyData(AccompanyData data)
	{
		this.accompanyData = data;
		SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(this.accompanyData.skillID, string.Empty, string.Empty);
		BeSkill skill = this.GetSkill(10000);
		if (skill != null && tableItem != null)
		{
			Skill10000 skill2 = skill as Skill10000;
			if (skill2 != null)
			{
				skill2.fixCD = TableManager.GetValueFromUnionCell(tableItem.RefreshTime, skill2.level, true);
				skill2.needSetIcon = true;
				skill2.iconPath = tableItem.Icon;
			}
		}
	}

	// Token: 0x06016C71 RID: 93297 RVA: 0x006FC4E8 File Offset: 0x006FA8E8
	public void UseHelpSkill()
	{
		BeSkill skill = this.GetSkill(10000);
		if (skill != null && !skill.isCooldown)
		{
			skill.Start();
		}
	}

	// Token: 0x06016C72 RID: 93298 RVA: 0x006FC518 File Offset: 0x006FA918
	public void SummonHelp(AccompanyData data)
	{
		int id = data.id;
		int level = data.level;
		int skillID = data.skillID;
		VInt3 position = base.GetPosition();
		position.z = 0;
		BeActor summon = this.currentBeScene.SummonAccompany(level * GlobalLogic.VALUE_100 + id, position, 0, this);
		if (summon == null)
		{
			return;
		}
		summon.SetFace(base.GetFace(), false, false);
		summon.aiManager.Stop();
		summon.SetRestrainPosition(false);
		summon.buffController.RemoveBuff(2, 0, 0);
		summon.buffController.TryAddBuff(29, int.MaxValue, 1);
		summon.stateController.SetAbilityEnable(BeAbilityType.BLOCK, false);
		summon.m_pkGeActor.RemoveHPBar();
		summon.delayCaller.DelayCall(GlobalLogic.VALUE_100, delegate
		{
			summon.SetPosition(new VInt3(this.GetPosition().x + ((!summon.GetFace()) ? -1 : 1) * VInt.Float2VIntValue(Global.Settings.keepDis), this.GetPosition().y, 0), false, true, false);
			summon.m_pkGeActor.ChangeAction("Anim_Run", 1f, true, true, true);
			BeAction beAction = BeMoveBy.Create(summon, IntMath.Float2Int(Global.Settings.accompanyRunTime * (float)GlobalLogic.VALUE_1000), summon.GetPosition(), new VInt3((Global.Settings.keepDis + 1f) * (float)((!summon.GetFace()) ? 1 : -1), 0f, 0f), true, null, false);
			beAction.SetFinishCallback(delegate
			{
				summon.UseSkill(skillID, true);
				summon.RegisterEvent(BeEventType.onStateChange, delegate(object[] args)
				{
					ActionState actionState = (ActionState)args[0];
					if (actionState != ActionState.AS_CASTSKILL)
					{
						summon.delayCaller.DelayCall(200, delegate
						{
							summon.m_pkGeActor.ChangeSurface("无敌", 0f, true, true);
							summon.currentBeScene.currentGeScene.CreateEffect("Effects/Hero_Zhaohuanshi/Kaxiliyasi/Prefab/Eff_kaxiliyasi_xiaoshi", 0f, new Vec3(summon.GetPosition().fx, summon.GetPosition().fy, 0.5f), 1f, 1f, false, false);
						}, 0, 0, false);
						summon.delayCaller.DelayCall(500, delegate
						{
							summon.SetLifeState(EntityLifeState.ELS_CANREMOVE);
						}, 0, 0, false);
					}
				});
			});
			summon.actionManager.RunAction(beAction);
		}, 0, 0, false);
	}

	// Token: 0x06016C73 RID: 93299 RVA: 0x006FC62A File Offset: 0x006FAA2A
	public void SetPetAlongside()
	{
		if (this.pet == null)
		{
			return;
		}
		this.pet.SetPosition(this.GetTargetPos(), false, true, false);
		this.PlayPetIdle();
	}

	// Token: 0x06016C74 RID: 93300 RVA: 0x006FC652 File Offset: 0x006FAA52
	public bool HasSpeed(VInt speed)
	{
		return speed != 0;
	}

	// Token: 0x06016C75 RID: 93301 RVA: 0x006FC65C File Offset: 0x006FAA5C
	public void PlayPetIdle()
	{
		if (this.pet.IsCastingSkill())
		{
			return;
		}
		if (this.petActionState == ActionState.AS_IDLE)
		{
			return;
		}
		this.petActionState = ActionState.AS_IDLE;
		string acActionName = "Idle";
		if (this.petData.hunger <= GlobalLogic.VALUE_30 && this.pet.HasAction("Eidle"))
		{
			acActionName = "Eidle";
		}
		this.pet.PlayAction(acActionName, 1f);
		this.pet.TriggerEvent(BeEventType.onStateChange, new object[]
		{
			2
		});
	}

	// Token: 0x06016C76 RID: 93302 RVA: 0x006FC6F4 File Offset: 0x006FAAF4
	public void PlayPetWalk()
	{
		if (this.pet.IsCastingSkill())
		{
			return;
		}
		if (this.petActionState == ActionState.AS_WALK)
		{
			return;
		}
		this.petActionState = ActionState.AS_WALK;
		string acActionName = "Walk";
		if (this.petData.hunger <= GlobalLogic.VALUE_30 && this.pet.HasAction("Ewalk"))
		{
			acActionName = "Ewalk";
		}
		this.pet.PlayAction(acActionName, 1f);
		this.pet.TriggerEvent(BeEventType.onStateChange, new object[]
		{
			2
		});
	}

	// Token: 0x06016C77 RID: 93303 RVA: 0x006FC78A File Offset: 0x006FAB8A
	public void SetPetFace(bool flag)
	{
		this.pet.SetFace(flag, false, false);
	}

	// Token: 0x06016C78 RID: 93304 RVA: 0x006FC79C File Offset: 0x006FAB9C
	public VInt3 GetTargetPos()
	{
		VInt3 position = base.GetPosition();
		position.z = 0;
		position.x = ((!base.GetFace()) ? (position.x - VInt.one.i) : (position.x + VInt.one.i));
		return position;
	}

	// Token: 0x06016C79 RID: 93305 RVA: 0x006FC7FC File Offset: 0x006FABFC
	public bool IsPetForward()
	{
		return (base.GetFace() && this.pet.GetPosition().x < base.GetPosition().x) || (!base.GetFace() && this.pet.GetPosition().x > base.GetPosition().x);
	}

	// Token: 0x06016C7A RID: 93306 RVA: 0x006FC870 File Offset: 0x006FAC70
	public bool IsInPosition()
	{
		VInt3 targetPos = this.GetTargetPos();
		int num = this.pet.GetPosition().x - targetPos.x;
		int num2 = this.pet.GetPosition().y - targetPos.y;
		int i = Mathf.Abs(num);
		int i2 = Mathf.Abs(num2);
		return i < VInt.zeroDotOne && i2 < VInt.zeroDotOne;
	}

	// Token: 0x06016C7B RID: 93307 RVA: 0x006FC8F8 File Offset: 0x006FACF8
	public void UpdatePet(int delta)
	{
		if (this.pet == null)
		{
			return;
		}
		this.pet.moveSpeedFactor = this.moveSpeedFactor;
		if (this.pet.IsCastingSkill())
		{
			return;
		}
		if (!this.IsInPosition())
		{
			this.handle.SetRemove(true);
			this.handle2.SetRemove(true);
			VInt3 targetPos = this.GetTargetPos();
			int num = this.pet.GetPosition().x - targetPos.x;
			int num2 = this.pet.GetPosition().y - targetPos.y;
			int i = VInt.zeroDotOne.i;
			if (num >= -i && num <= i)
			{
				num = 0;
			}
			if (num2 >= -i && num2 <= i)
			{
				num2 = 0;
			}
			int i2 = Mathf.Abs(num);
			int i3 = Mathf.Abs(num2);
			this.pet.moveXSpeed = Mathf.Abs(this.GetPetMoveXSpeed(i2).i) * ((num <= 0) ? 1 : -1);
			this.pet.moveYSpeed = Mathf.Abs(this.GetPetMoveYSpeed(i3).i) * ((num2 <= 0) ? 1 : -1);
			if (this.pet.moveXSpeed < 0)
			{
				this.SetPetFace(true);
			}
			else if (this.pet.moveXSpeed > 0)
			{
				this.SetPetFace(false);
			}
			this.isPetMoving = true;
			this.PlayPetWalk();
		}
		else
		{
			this.pet.moveXSpeed = 0;
			this.pet.moveYSpeed = 0;
			if (this.isPetMoving)
			{
				if (this.IsPetFaceDifferent())
				{
					this.handle = this.pet.delayCaller.DelayCall(GlobalLogic.VALUE_500, delegate
					{
						this.SetPetFace(base.GetFace());
					}, 0, 0, false);
				}
				this.isPetMoving = false;
				this.pet.SetPosition(this.GetTargetPos(), false, true, false);
				this.handle2 = this.pet.delayCaller.DelayCall(GlobalLogic.VALUE_200, delegate
				{
					this.PlayPetIdle();
				}, 0, 0, false);
			}
		}
	}

	// Token: 0x06016C7C RID: 93308 RVA: 0x006FCB48 File Offset: 0x006FAF48
	public bool IsPetFaceDifferent()
	{
		return this.pet.GetFace() != base.GetFace();
	}

	// Token: 0x06016C7D RID: 93309 RVA: 0x006FCB60 File Offset: 0x006FAF60
	public VInt GetPetMoveXSpeed(VInt disx)
	{
		VInt result = VInt.zero;
		if (disx <= VInt.Float2VIntValue(0.01f))
		{
			return result;
		}
		if (base.moveXSpeed == 0 || this.IsPetFaceDifferent())
		{
			result = VInt.Float2VIntValue(Global.Settings.petXMovingv2);
		}
		else if (disx >= VInt.Float2VIntValue(Global.Settings.petXMovingDis))
		{
			result = base.moveXSpeed;
		}
		else if (disx > VInt.Float2VIntValue(0.5f) && disx < VInt.Float2VIntValue(1.5f))
		{
			result = VInt.Float2VIntValue(Global.Settings.petXMovingv1);
		}
		return result;
	}

	// Token: 0x06016C7E RID: 93310 RVA: 0x006FCC28 File Offset: 0x006FB028
	public VInt GetPetMoveYSpeed(VInt disy)
	{
		VInt result = VInt.zero;
		if (disy <= VInt.Float2VIntValue(0.01f))
		{
			return result;
		}
		if (base.moveYSpeed == 0)
		{
			result = VInt.Float2VIntValue(Global.Settings.petYMovingv2);
		}
		else if (disy >= VInt.Float2VIntValue(Global.Settings.petYMovingDis))
		{
			result = base.moveYSpeed;
		}
		else if (disy > VInt.Float2VIntValue(0.5f) && disy < VInt.Float2VIntValue(1.5f))
		{
			result = VInt.Float2VIntValue(Global.Settings.petYMovingv1);
		}
		return result;
	}

	// Token: 0x06016C7F RID: 93311 RVA: 0x006FCCE4 File Offset: 0x006FB0E4
	public void SetPetData(PetData petData)
	{
		if (petData == null)
		{
			return;
		}
		if (petData.id <= 0)
		{
			return;
		}
		this.petData = petData;
		VInt3 position = base.GetPosition();
		position.z = 0;
		BeActor pet = this.currentBeScene.SummonAccompany(petData.level * GlobalLogic.VALUE_100 + petData.id, position, base.GetCamp(), this);
		if (pet == null)
		{
			Logger.LogErrorFormat("创建宠物{0}失败!!!", new object[]
			{
				petData.id
			});
			return;
		}
		pet.aiManager.Stop();
		Vector4 entityPlane = GeSceneEx.EntityPlane;
		entityPlane.w -= 0.07f;
		pet.m_pkGeActor.AddSimpleShadow(Vector3.one);
		pet.stateController.SetAbilityEnable(BeAbilityType.BETARGETED, false);
		pet.stateController.SetAbilityEnable(BeAbilityType.BLOCK, false);
		pet.m_pkGeActor.SetHPBarVisible(false);
		pet.GetEntityData().isPet = true;
		pet.owner = this;
		this.currentBeScene.AdjustSummonMonsterAttribute(this, pet);
		base.RegisterEvent(BeEventType.onAfterDead, delegate(object[] args)
		{
			pet.delayCaller.DelayCall(GlobalLogic.VALUE_500, delegate
			{
				if (this.IsDead())
				{
					pet.m_pkGeActor.SetActorVisible(false);
				}
			}, 0, 0, false);
		});
		base.RegisterEvent(BeEventType.onReborn, delegate(object[] args)
		{
			if (pet != null)
			{
				if (pet.m_pkGeActor != null)
				{
					pet.m_pkGeActor.SetActorVisible(true);
					this.SetPetAlongside();
				}
			}
		});
		this.pet = pet;
		this.SetPetAlongside();
		if ((BattleMain.IsModePvP(base.battleType) || base.battleType == BattleType.TrainingSkillCombo) && Singleton<SettingManager>.GetInstance().GetCommmonSet("SETTING_TITLESETPVP") == SettingManager.SetCommonType.Close && pet.m_pkGeActor != null && this.isLocalActor)
		{
			pet.m_pkGeActor.SetShadowVisible(base.CurrentBeScene.currentGeScene, false);
			pet.m_pkGeActor.SetActorVisible(false);
		}
		if (BattleMain.IsModePvP(base.battleType))
		{
			pet.buffController.TryAddBuff(2, int.MaxValue, 1);
			return;
		}
		if (petData.hunger <= 0)
		{
			BuffInfoData buffInfo = new BuffInfoData
			{
				buffID = -1,
				condition = BuffCondition.ATTACK,
				prob = GlobalLogic.VALUE_100
			};
			this.buffController.AddTriggerBuff(buffInfo);
			base.RegisterEvent(BeEventType.onPetSkill, delegate(object[] args)
			{
				if (this.FrameRandom.Range100() < 90)
				{
					return;
				}
				pet.ShowSpeech(11602);
			});
			return;
		}
		pet.LoadOneSkill(petData.skillID, petData.level);
		BeSkill skill = pet.GetSkill(petData.skillID);
		if (skill != null)
		{
			skill.PostInit();
			skill.StartInitCD(BattleMain.IsModePvP(base.battleType));
			bool flag = false;
			for (int i = 0; i < skill.skillData.PreCondition.Count; i++)
			{
				if (skill.skillData.PreCondition[i] == SkillTable.ePreCondition.MASTER_ATTACK)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				BuffInfoData buffInfo2 = new BuffInfoData
				{
					buffID = -1,
					condition = BuffCondition.ATTACK,
					prob = skill.useRate
				};
				this.buffController.AddTriggerBuff(buffInfo2);
				skill.useRate = GlobalLogic.VALUE_1000;
				base.RegisterEvent(BeEventType.onPetSkill, delegate(object[] args)
				{
					if (pet.CanUseSkill(petData.skillID))
					{
						VInt2 vint = this.GetPosition2() - pet.GetPosition2();
						vint.Normalize();
						if (vint.x != 0)
						{
							this.SetPetFace(vint.x < 0);
						}
						else
						{
							this.SetPetFace(this.GetFace());
						}
						pet.UseSkill(petData.skillID, true);
						this.petActionState = ActionState.AS_CASTSKILL;
					}
				});
			}
			return;
		}
		Logger.LogErrorFormat("宠物 {0} 找不到技能 {1}", new object[]
		{
			pet.GetName(),
			petData.skillID
		});
	}

	// Token: 0x06016C80 RID: 93312 RVA: 0x006FD0D0 File Offset: 0x006FB4D0
	public void CreateFollowMonster()
	{
		if (this.m_pkGeActor == null || this.currentBeScene == null)
		{
			return;
		}
		string attachModelPath = BeUtility.GetAttachModelPath(this.professionID);
		if (attachModelPath == null)
		{
			return;
		}
		GameObject entityNode = this.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Actor);
		this.attachModel = Utility.AddModelToActor(attachModelPath, this.m_pkGeActor, entityNode);
	}

	// Token: 0x06016C81 RID: 93313 RVA: 0x006FD127 File Offset: 0x006FB527
	public bool IsPassiveState()
	{
		return base.sgGetCurrentState() == 15 || base.sgGetCurrentState() == 11;
	}

	// Token: 0x06016C82 RID: 93314 RVA: 0x006FD144 File Offset: 0x006FB544
	public bool IsNearSceneEdge()
	{
		VInt onehalf = VInt.onehalf;
		return Mathf.Abs(base.GetPosition().x - this.currentBeScene.logicXSize.x) < onehalf.i || Mathf.Abs(base.GetPosition().x - this.currentBeScene.logicXSize.y) < onehalf.i;
	}

	// Token: 0x06016C83 RID: 93315 RVA: 0x006FD1BC File Offset: 0x006FB5BC
	public bool CanRoll()
	{
		return !base.IsDead() && base.IsMonster() && base.sgGetCurrentState() != 20 && base.HasAction(ActionType.ActionType_Roll) && ((this.IsNearSceneEdge() && (uint)base.FrameRandom.Range1000() <= (uint)(Global.Settings.rollRand * (float)GlobalLogic.VALUE_1000)) || (!this.IsNearSceneEdge() && (uint)base.FrameRandom.Range1000() <= (uint)(Global.Settings.normalRollRand * (float)GlobalLogic.VALUE_1000)));
	}

	// Token: 0x06016C84 RID: 93316 RVA: 0x006FD258 File Offset: 0x006FB658
	public void InitAutoFight(string actionTree = null, string destTree = null, string eventTree = null, int thinkTerm = 0, int findTargetTerm = 0, int changeDestinationTerm = 0, int keepDistance = 0, bool pauseAI = true)
	{
		BeAIManager beAIManager = new BeActorAIManager();
		this.InitAI(beAIManager);
		if (beAIManager != null)
		{
			beAIManager.isAutoFight = true;
			beAIManager.isAPC = true;
			beAIManager.sight = GlobalLogic.VALUE_20000;
			beAIManager.chaseSight = beAIManager.sight;
			beAIManager.thinkTerm = ((thinkTerm != 0) ? thinkTerm : Global.Settings.afThinkTerm);
			beAIManager.findTargetTerm = ((findTargetTerm != 0) ? findTargetTerm : Global.Settings.afFindTargetTerm);
			beAIManager.changeDestinationTerm = ((changeDestinationTerm != 0) ? changeDestinationTerm : Global.Settings.afChangeDestinationTerm);
			beAIManager.idleMode = BeAIManager.IdleMode.IDLE;
			beAIManager.idleDuration = GlobalLogic.VALUE_300;
			beAIManager.targetType = BeAIManager.TargetType.NEAREST;
			beAIManager.walkBackRange = 2;
			beAIManager.wanderRange = 2;
			beAIManager.keepDistance = keepDistance;
			beAIManager.InitAgents(actionTree, destTree, eventTree, null);
			this.StartAI(null, false);
			base.pauseAI = pauseAI;
		}
	}

	// Token: 0x06016C85 RID: 93317 RVA: 0x006FD348 File Offset: 0x006FB748
	public bool TriggerComboSkills(int skillID)
	{
		if (base.TriggerEventNew(BeEventType.onSpecialSkillCombo, new EventParam
		{
			m_Int = skillID,
			m_Bool = false
		}).m_Bool)
		{
			return true;
		}
		int num = this.CheckComboSkill(0);
		if (num <= 0)
		{
			return false;
		}
		BeSkill skill = this.GetSkill(num);
		BeSkill currentSkill = this.GetCurrentSkill();
		if (skill != null && currentSkill != null && skillID != skill.comboSkillSourceID)
		{
			return false;
		}
		if (currentSkill != null)
		{
			currentSkill.cancelByCombo = true;
			currentSkill.OnComboBreak();
		}
		this.CastSkill(num);
		return true;
	}

	// Token: 0x06016C86 RID: 93318 RVA: 0x006FD3E4 File Offset: 0x006FB7E4
	public void SetAutoFight(bool auto)
	{
		if (base.IsProcessRecord())
		{
			base.GetRecordServer().Mark(142055299U, new int[]
			{
				this.m_iID,
				(!auto) ? 0 : 1
			}, new string[]
			{
				base.GetName()
			});
		}
		if (!auto)
		{
			this.SetForceRunMode(false);
		}
		if (base.pauseAI == !auto)
		{
			return;
		}
		base.pauseAI = !auto;
		if (base.pauseAI)
		{
			this.SetForceRunMode(false);
			if (this.aiManager != null)
			{
				this.aiManager.StopCurrentCommand();
			}
			base.ResetMoveCmd();
			this.SetAttackButtonState(ButtonState.RELEASE, true);
		}
	}

	// Token: 0x06016C87 RID: 93319 RVA: 0x006FD49C File Offset: 0x006FB89C
	public sealed override void OnChangeFace()
	{
		if (this.isMainActor && this.IsRunning() && this.doublePressRunLeft != base.GetFace() && Global.Settings.changeFaceStop)
		{
			this.ChangeRunMode(false);
		}
	}

	// Token: 0x06016C88 RID: 93320 RVA: 0x006FD4E9 File Offset: 0x006FB8E9
	public sealed override void JudgeDead()
	{
		if (this.isMainActor && this.currentBeScene.IsBossDead())
		{
			return;
		}
		base.JudgeDead();
	}

	// Token: 0x06016C89 RID: 93321 RVA: 0x006FD50D File Offset: 0x006FB90D
	public sealed override void DoDead(bool isForce = false)
	{
		base.DoDead(isForce);
		this.ClearAttackId();
	}

	// Token: 0x06016C8A RID: 93322 RVA: 0x006FD51C File Offset: 0x006FB91C
	public void ChangeModel(UnitTable data, bool isPreChange = true, bool needRebindAttach = false)
	{
		if (data == null)
		{
			return;
		}
		if (this.m_pkGeActor == null)
		{
			return;
		}
		if (isPreChange)
		{
			this.m_pkGeActor.PreChangeModel(data.Mode, needRebindAttach);
		}
		else
		{
			this.m_pkGeActor.TryChangeModel(data.Mode, needRebindAttach);
		}
	}

	// Token: 0x06016C8B RID: 93323 RVA: 0x006FD56C File Offset: 0x006FB96C
	public void ChangeSkill(UnitTable data)
	{
		if (this.currentBeScene == null)
		{
			return;
		}
		Dictionary<int, int> monsterSkillInfo = this.currentBeScene.GetMonsterSkillInfo(data.ID, 0);
		if (monsterSkillInfo == null)
		{
			return;
		}
		this.m_cpkEntityInfo.Reset();
		this.skillList.Clear();
		this.LoadSkill(monsterSkillInfo, false, data.Mode);
		if (this.aiManager != null)
		{
			this.aiManager.ReloadSkillInfos(data);
		}
		this.currentBeScene.ChangeMonsterAbility(this, data, true);
		if (this.lastTimeMonsterData == null)
		{
			BeEntityData entityData = this.owner.GetEntityData();
			if (entityData != null)
			{
				UnitTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<UnitTable>(entityData.monsterID, string.Empty, string.Empty);
				this.lastTimeMonsterData = tableItem;
			}
		}
		this.currentBeScene.ChangeMonsterAbility(this, this.lastTimeMonsterData, false);
		this.lastTimeMonsterData = data;
	}

	// Token: 0x06016C8C RID: 93324 RVA: 0x006FD644 File Offset: 0x006FBA44
	public void RemoveSkill(int skillId)
	{
		if (this.skillList.ContainsKey(skillId))
		{
			if (this.skillList[skillId] != null)
			{
				try
				{
					this.skillList[skillId].DeInit();
				}
				catch (Exception ex)
				{
					Logger.LogErrorFormat("try remove skill {0} failed reason {1}", new object[]
					{
						skillId,
						ex.ToString()
					});
				}
			}
			this.skillList.Remove(skillId);
		}
	}

	// Token: 0x06016C8D RID: 93325 RVA: 0x006FD6D0 File Offset: 0x006FBAD0
	public BeActor.NormalAttack AddReplaceAttackId(int id, int level)
	{
		int count = this.m_ReplaceAttackIdList.Count;
		BeActor.NormalAttack normalAttack = new BeActor.NormalAttack
		{
			SkillID = id,
			PriorityLevel = level
		};
		if (count > 0)
		{
			int priorityLevel = this.m_ReplaceAttackIdList[count - 1].PriorityLevel;
			if (level >= priorityLevel)
			{
				this.m_ReplaceAttackIdList.Add(normalAttack);
				base.GetEntityData().normalAttackID = id;
			}
			else
			{
				for (int i = count - 1; i >= 0; i--)
				{
					if (level >= this.m_ReplaceAttackIdList[i].PriorityLevel)
					{
						this.m_ReplaceAttackIdList.Insert(i + 1, normalAttack);
					}
				}
			}
		}
		else
		{
			BeActor.NormalAttack item = new BeActor.NormalAttack
			{
				SkillID = base.GetEntityData().normalAttackID,
				PriorityLevel = 0
			};
			this.m_ReplaceAttackIdList.Add(item);
			this.ReplaceAttackId(normalAttack);
		}
		return normalAttack;
	}

	// Token: 0x06016C8E RID: 93326 RVA: 0x006FD7CC File Offset: 0x006FBBCC
	public void RemoveReplaceAttackId(BeActor.NormalAttack data)
	{
		if (!data.Equals(null))
		{
			int count = this.m_ReplaceAttackIdList.Count;
			if (count > 1)
			{
				if (data.Equals(this.m_ReplaceAttackIdList[count - 1]))
				{
					base.GetEntityData().normalAttackID = this.m_ReplaceAttackIdList[count - 2].SkillID;
				}
				this.m_ReplaceAttackIdList.Remove(data);
			}
		}
	}

	// Token: 0x06016C8F RID: 93327 RVA: 0x006FD852 File Offset: 0x006FBC52
	protected void ClearAttackId()
	{
		if (this.m_ReplaceAttackIdList.Count > 0)
		{
			this.ReplaceAttackId(this.m_ReplaceAttackIdList[0]);
			this.m_ReplaceAttackIdList.Clear();
		}
	}

	// Token: 0x06016C90 RID: 93328 RVA: 0x006FD882 File Offset: 0x006FBC82
	protected void ReplaceAttackId(BeActor.NormalAttack attackData)
	{
		base.GetEntityData().normalAttackID = attackData.SkillID;
		this.m_ReplaceAttackIdList.Add(attackData);
	}

	// Token: 0x06016C91 RID: 93329 RVA: 0x006FD8A4 File Offset: 0x006FBCA4
	private void CheckAutoReborn()
	{
		if (BattleMain.IsModePvP(base.battleType))
		{
			return;
		}
		if (!this.isLocalActor || base.pauseAI)
		{
			return;
		}
		if (DataManager<PlayerBaseData>.GetInstance().VipLevel == 0)
		{
			return;
		}
		if (!BeUtility.CheckVipAutoReborn())
		{
			return;
		}
		BattlePlayer localPlayer = BattleMain.instance.GetLocalPlayer(0UL);
		if (!localPlayer.CanUseItem(DungeonItem.eType.RebornCoin, 1) && DungeonUtility.GetVipRebornLeftCount() <= 0)
		{
			return;
		}
		BeUtility.PlayerReborn(this);
	}

	// Token: 0x06016C92 RID: 93330 RVA: 0x006FD924 File Offset: 0x006FBD24
	private void RemoveSkillJoyStick()
	{
		if (!this.isLocalActor)
		{
			return;
		}
		if (InputManager.instance == null)
		{
			return;
		}
		InputManager.instance.DisableSkillJoystick();
	}

	// Token: 0x06016C93 RID: 93331 RVA: 0x006FD948 File Offset: 0x006FBD48
	public void GetGrabTargetList(List<BeActor> list)
	{
		list.Clear();
		if (this.m_vGrapedEntity == null)
		{
			return;
		}
		for (int i = 0; i < this.m_vGrapedEntity.Count; i++)
		{
			BeActor beActor = this.m_vGrapedEntity[i] as BeActor;
			if (beActor != null && !beActor.IsDead())
			{
				list.Add(beActor);
			}
		}
	}

	// Token: 0x06016C94 RID: 93332 RVA: 0x006FD9B4 File Offset: 0x006FBDB4
	public BeSkill GetCurSkill()
	{
		int iCurSkillID = this.m_iCurSkillID;
		return this.GetSkill(this.m_iCurSkillID);
	}

	// Token: 0x06016C95 RID: 93333 RVA: 0x006FD9D8 File Offset: 0x006FBDD8
	public void GetChargeSkillList(List<int> list)
	{
		list.Clear();
		foreach (KeyValuePair<int, BeSkill> keyValuePair in this.skillList)
		{
			int key = keyValuePair.Key;
			Dictionary<int, BeSkill>.Enumerator enumerator;
			KeyValuePair<int, BeSkill> keyValuePair2 = enumerator.Current;
			BeSkill value = keyValuePair2.Value;
			if (value.charge)
			{
				list.Add(key);
			}
		}
	}

	// Token: 0x06016C96 RID: 93334 RVA: 0x006FDA3C File Offset: 0x006FBE3C
	public void ShowTransport(bool isShow)
	{
		if (this.isSpecialMonster)
		{
			if (base.GetOwner() != null && base.GetOwner().m_pkGeActor != null)
			{
				base.GetOwner().m_pkGeActor.ShowTranport(isShow);
			}
		}
		else if (this.m_pkGeActor != null)
		{
			this.m_pkGeActor.ShowTranport(isShow);
		}
	}

	// Token: 0x06016C97 RID: 93335 RVA: 0x006FDA9C File Offset: 0x006FBE9C
	public void RemoveDeadHandle()
	{
		if (base.CurrentBeBattle == null)
		{
			return;
		}
		if (base.CurrentBeBattle.HasFlag(BattleFlagType.HandleRemoveOptimize))
		{
			return;
		}
		if (base.EventProcessor != null)
		{
			base.EventProcessor.RemoveDeadHandle();
		}
		if (this.m_EventManager != null)
		{
			this.m_EventManager.RemoveDeadHandle();
		}
	}

	// Token: 0x06016C98 RID: 93336 RVA: 0x006FDAF8 File Offset: 0x006FBEF8
	protected bool CannotFallHaveBuff101(BeEntity entity)
	{
		BeActor beActor = entity as BeActor;
		return beActor != null && beActor.currentBeScene != null && beActor.currentBeScene.mBattle != null && !beActor.currentBeScene.mBattle.FunctionIsOpen(BattleFlagType.Mechanism2019Bug) && beActor.buffController.HasBuffByID(101) != null;
	}

	// Token: 0x06016C99 RID: 93337 RVA: 0x006FDB5F File Offset: 0x006FBF5F
	public void CancelCurSkill()
	{
		this.CancelSkill(this.m_iCurSkillID, true);
		this.Locomote(new BeStateData(0, 0), true);
	}

	// Token: 0x0401040C RID: 66572
	protected EquipSchemeData[] m_ChangeEquipDataList;

	// Token: 0x0401040D RID: 66573
	protected int m_CurrentChangeEquipIndex;

	// Token: 0x0401040E RID: 66574
	protected int m_SchemeLength = 2;

	// Token: 0x0401040F RID: 66575
	private List<RecordEquipAddData> m_RecordEquipDataList = new List<RecordEquipAddData>();

	// Token: 0x04010410 RID: 66576
	private string name;

	// Token: 0x04010411 RID: 66577
	protected bool m_bInRunMode;

	// Token: 0x04010412 RID: 66578
	protected bool forceRunMode;

	// Token: 0x04010413 RID: 66579
	protected List<BeEntity> m_vGrapedEntity = new List<BeEntity>();

	// Token: 0x04010414 RID: 66580
	protected bool hasAttackEntityOnGrabCheck;

	// Token: 0x04010415 RID: 66581
	protected int m_skillPhase;

	// Token: 0x04010416 RID: 66582
	protected int[] skillPhases;

	// Token: 0x04010417 RID: 66583
	public Dictionary<int, int> skillSlotMap;

	// Token: 0x04010418 RID: 66584
	public int jumpAttackUseCount;

	// Token: 0x04010419 RID: 66585
	public BeBuffManager buffController;

	// Token: 0x0401041A RID: 66586
	public BeProtect protectManager;

	// Token: 0x0401041B RID: 66587
	public BeActorData actorData;

	// Token: 0x0401041C RID: 66588
	public SkillDamageManager skillDamageManager;

	// Token: 0x0401041D RID: 66589
	public int professionID;

	// Token: 0x0401041E RID: 66590
	private CrypticInt32[] groupSummonNum = new CrypticInt32[10];

	// Token: 0x0401041F RID: 66591
	protected Dictionary<int, BeSkill> skillList = new Dictionary<int, BeSkill>();

	// Token: 0x04010420 RID: 66592
	protected readonly List<BeMechanism> mechanismList = new List<BeMechanism>();

	// Token: 0x04010421 RID: 66593
	private List<BeMechanism> phaseDeleteMechanismList = new List<BeMechanism>();

	// Token: 0x04010422 RID: 66594
	private List<BeMechanism> finishDeleteMechanismList = new List<BeMechanism>();

	// Token: 0x04010423 RID: 66595
	protected ButtonState attackButtonState;

	// Token: 0x04010424 RID: 66596
	protected bool aiAttackNeedCheck;

	// Token: 0x04010425 RID: 66597
	public bool isMainActor;

	// Token: 0x04010426 RID: 66598
	public bool isLocalActor;

	// Token: 0x04010427 RID: 66599
	protected bool isCancelSkill;

	// Token: 0x04010428 RID: 66600
	private List<SpellBar> mBars = new List<SpellBar>();

	// Token: 0x04010429 RID: 66601
	public IList<int> attackSpeeches;

	// Token: 0x0401042A RID: 66602
	public IList<int> walkSpeeches;

	// Token: 0x0401042B RID: 66603
	public IList<int> birthSpeeches;

	// Token: 0x0401042C RID: 66604
	private bool isDunFu;

	// Token: 0x0401042D RID: 66605
	private int DunFuTimeout;

	// Token: 0x0401042E RID: 66606
	private int DunFuTimeAcc;

	// Token: 0x0401042F RID: 66607
	protected int defaultWeaponType;

	// Token: 0x04010430 RID: 66608
	protected int defaultWeaponTag;

	// Token: 0x04010431 RID: 66609
	protected bool actorNeedCost = true;

	// Token: 0x04010432 RID: 66610
	public bool recieveConfigCmd;

	// Token: 0x04010433 RID: 66611
	protected Dictionary<int, BuffInfoData> buffEnhanceList = new Dictionary<int, BuffInfoData>();

	// Token: 0x04010434 RID: 66612
	protected bool isRecordPress;

	// Token: 0x04010435 RID: 66613
	protected int pressCount;

	// Token: 0x04010436 RID: 66614
	protected GeEffectEx recordPressEffect;

	// Token: 0x04010437 RID: 66615
	protected BeBuff thisBuff;

	// Token: 0x04010438 RID: 66616
	protected BeActor thisActor;

	// Token: 0x04010439 RID: 66617
	protected BeActor grabber;

	// Token: 0x0401043A RID: 66618
	protected BDGrabData grabData;

	// Token: 0x0401043B RID: 66619
	public bool isSpecialMonster;

	// Token: 0x0401043C RID: 66620
	public BeEventHandle winHandler;

	// Token: 0x0401043D RID: 66621
	private bool canWalkShootTurn = true;

	// Token: 0x0401043E RID: 66622
	public bool grabPos;

	// Token: 0x0401043F RID: 66623
	private UnitTable lastTimeMonsterData;

	// Token: 0x04010440 RID: 66624
	public List<BeActor> GrapedActorList = new List<BeActor>();

	// Token: 0x04010441 RID: 66625
	public bool IsSuplexGrap;

	// Token: 0x04010442 RID: 66626
	protected int graberBuffInfoIdToSelf;

	// Token: 0x04010443 RID: 66627
	private static List<int> LiGuiSkillList = new List<int>
	{
		1901,
		1902,
		1903,
		1904
	};

	// Token: 0x04010444 RID: 66628
	private static List<int> NormalSkillList = new List<int>
	{
		1500,
		1501,
		1502
	};

	// Token: 0x04010445 RID: 66629
	private static List<int> AttackComboSkillList = new List<int>
	{
		1506,
		1507,
		1508,
		1522,
		1523,
		1913,
		1914,
		1915,
		1916,
		1917
	};

	// Token: 0x04010446 RID: 66630
	protected List<int> recordedEquipMechanismIDs = new List<int>();

	// Token: 0x04010447 RID: 66631
	private int pressDunfuDurTime = -1;

	// Token: 0x04010448 RID: 66632
	private List<ItemProperty> equips;

	// Token: 0x04010449 RID: 66633
	private ItemProperty suitProperty;

	// Token: 0x0401044A RID: 66634
	private ItemProperty masterProperty;

	// Token: 0x0401044B RID: 66635
	public int dungeonRebornCount;

	// Token: 0x0401044C RID: 66636
	public bool isPkRobot;

	// Token: 0x0401044D RID: 66637
	protected float m_geLastTopZ;

	// Token: 0x0401044E RID: 66638
	protected bool m_inBossRange;

	// Token: 0x0401044F RID: 66639
	protected bool m_isInDeadProtect;

	// Token: 0x04010450 RID: 66640
	protected int m_deadProtectDurTime;

	// Token: 0x04010451 RID: 66641
	protected BeActor.QuickPressType quickPressType;

	// Token: 0x04010452 RID: 66642
	protected AccompanyData m_accompanyData;

	// Token: 0x04010453 RID: 66643
	protected PetData m_petData;

	// Token: 0x04010454 RID: 66644
	public BeActor pet;

	// Token: 0x04010455 RID: 66645
	public GeActorEx spirit;

	// Token: 0x04010456 RID: 66646
	public BeEventHandle summonNumHandle;

	// Token: 0x04010457 RID: 66647
	public bool floatShotSwitch;

	// Token: 0x04010458 RID: 66648
	public bool headShotSwitch;

	// Token: 0x04010459 RID: 66649
	private IBeActorController controller;

	// Token: 0x0401045A RID: 66650
	private int actorTimeAcc;

	// Token: 0x0401045B RID: 66651
	public VFactor speedAcc;

	// Token: 0x0401045C RID: 66652
	public bool effectTimeNeedChange;

	// Token: 0x0401045D RID: 66653
	private static readonly VFactor Skill_Speed_MIN = VFactor.NewVFactor(400, 1000);

	// Token: 0x0401045E RID: 66654
	private const string NO_RIGHT_WEAPON_STR = "UI/Font/new_font/pic_sycs_{0}.png:pic_sycs_{1}_0";

	// Token: 0x0401045F RID: 66655
	private DelayCallUnitHandle handle;

	// Token: 0x04010460 RID: 66656
	private DelayCallUnitHandle handle2;

	// Token: 0x04010461 RID: 66657
	private bool isPetMoving;

	// Token: 0x04010462 RID: 66658
	private ActionState petActionState = ActionState.AS_NONE;

	// Token: 0x04010463 RID: 66659
	public GameObject attachModel;

	// Token: 0x04010464 RID: 66660
	protected List<BeActor.NormalAttack> m_ReplaceAttackIdList = new List<BeActor.NormalAttack>();

	// Token: 0x02004142 RID: 16706
	public enum QuickPressType
	{
		// Token: 0x04010482 RID: 66690
		BUFF,
		// Token: 0x04010483 RID: 66691
		GRAP
	}

	// Token: 0x02004143 RID: 16707
	public enum SkillCannotUseType
	{
		// Token: 0x04010485 RID: 66693
		CAN_USE,
		// Token: 0x04010486 RID: 66694
		NO_HP,
		// Token: 0x04010487 RID: 66695
		NO_MP,
		// Token: 0x04010488 RID: 66696
		IN_CD,
		// Token: 0x04010489 RID: 66697
		NO_RIGHT_WEAPON,
		// Token: 0x0401048A RID: 66698
		NO_KEYING,
		// Token: 0x0401048B RID: 66699
		NO_CRYSTAL,
		// Token: 0x0401048C RID: 66700
		NO_CYZKJ,
		// Token: 0x0401048D RID: 66701
		MONSTER_COUNT_LIMITM,
		// Token: 0x0401048E RID: 66702
		MONSTER_DIS_LIMITM,
		// Token: 0x0401048F RID: 66703
		CAN_NOT_USE
	}

	// Token: 0x02004144 RID: 16708
	public struct NormalAttack
	{
		// Token: 0x04010490 RID: 66704
		public int PriorityLevel;

		// Token: 0x04010491 RID: 66705
		public int SkillID;
	}
}
