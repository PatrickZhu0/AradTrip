using System;
using System.Collections.Generic;
using System.ComponentModel;
using Battle;
using GameClient;
using GamePool;
using UnityEngine;

// Token: 0x0200437E RID: 17278
public class Mechanism2072 : BeMechanism
{
	// Token: 0x06017F39 RID: 98105 RVA: 0x0076B25C File Offset: 0x0076965C
	public Mechanism2072(int id, int lv) : base(id, lv)
	{
	}

	// Token: 0x06017F3A RID: 98106 RVA: 0x0076B44C File Offset: 0x0076984C
	public override void OnInit()
	{
		base.OnInit();
		this.z_ChaserMaxCount[0] = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.z_ChaserMaxCount[1] = TableManager.GetValueFromUnionCell(this.data.ValueA[1], this.level, true);
		this.z_ComboCheckCountArr[0] = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.z_ComboCheckCountArr[1] = TableManager.GetValueFromUnionCell(this.data.ValueB[1], this.level, true);
		this.z_ComboCheckCountArr[2] = TableManager.GetValueFromUnionCell(this.data.ValueB[2], this.level, true);
		this.z_ChaserLiveTime = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		this.z_ChaserTweenFactor = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true), GlobalLogic.VALUE_1000);
		for (int i = 0; i < this.data.ValueG.Count; i++)
		{
			this.z_FilterHitSet.Add(TableManager.GetValueFromUnionCell(this.data.ValueG[i], this.level, true));
		}
		this.mHandleList = ListPool<BeEventHandle>.Get();
		this.mHandleList.Clear();
		this.mIsTweenChaser = true;
	}

	// Token: 0x06017F3B RID: 98107 RVA: 0x0076B5F7 File Offset: 0x007699F7
	private void OnLevelSwitchStart(object[] args)
	{
		this.mIsTweenChaser = false;
	}

	// Token: 0x06017F3C RID: 98108 RVA: 0x0076B600 File Offset: 0x00769A00
	private void OnLevelSwitchEnd(object[] args)
	{
		this.mIsTweenChaser = true;
	}

	// Token: 0x06017F3D RID: 98109 RVA: 0x0076B609 File Offset: 0x00769A09
	protected void OnChangeWeapon(object[] args)
	{
		this.UpdateEquipData();
	}

	// Token: 0x06017F3E RID: 98110 RVA: 0x0076B611 File Offset: 0x00769A11
	protected void OnChangeEquip(BeEvent.BeEventParam param)
	{
		this.UpdateEquipData();
	}

	// Token: 0x06017F3F RID: 98111 RVA: 0x0076B61C File Offset: 0x00769A1C
	private void UpdateEquipData()
	{
		this.m_ChaserMaxCount = ((!BattleMain.IsModePvP(base.battleType)) ? this.z_ChaserMaxCount[0] : this.z_ChaserMaxCount[1]);
		this.z_GenerateRateArr_Equip[0] = 0;
		this.z_GenerateRateArr_Equip[1] = 0;
		this.z_GenerateRateArr_Equip[2] = 0;
		this.m_ComboScaleList.Clear();
		for (int i = 0; i < this.z_ChaserScale.Length; i++)
		{
			this.z_ChaserScale[i] = VFactor.zero;
		}
		List<BeMechanism> mechanismList = base.owner.MechanismList;
		if (mechanismList == null)
		{
			return;
		}
		for (int j = 0; j < mechanismList.Count; j++)
		{
			if (mechanismList[j].isRunning)
			{
				Mechanism2089 mechanism = mechanismList[j] as Mechanism2089;
				if (mechanism != null)
				{
					this.m_ChaserMaxCount += mechanism.ChaserMaxCount;
					this.z_GenerateRateArr_Equip[0] += mechanism.BigChaserCreateProb;
					this.z_GenerateRateArr_Equip[1] += mechanism.ChaserCreateProb;
					this.z_GenerateRateArr_Equip[2] += mechanism.ChaserCreateProb;
					this.m_ComboScaleList.Add(mechanism.ComboChaserScale);
					for (int k = 0; k < this.z_ChaserScale.Length; k++)
					{
						this.z_ChaserScale[k] += VFactor.NewVFactor(mechanism.ChaserScale(k), GlobalLogic.VALUE_1000);
					}
				}
			}
		}
	}

	// Token: 0x06017F40 RID: 98112 RVA: 0x0076B7B3 File Offset: 0x00769BB3
	public void OffsetChaserCreateTime(int time)
	{
		this.z_ChaserCreateTime_Equip += time;
	}

	// Token: 0x06017F41 RID: 98113 RVA: 0x0076B7C3 File Offset: 0x00769BC3
	public override void OnStart()
	{
		base.OnStart();
		this.InitData();
	}

	// Token: 0x06017F42 RID: 98114 RVA: 0x0076B7D1 File Offset: 0x00769BD1
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		this.UpdateAddChaser(deltaTime);
		this.UpdateChaserLive(deltaTime);
		this.UpdateChaserPosition(deltaTime);
	}

	// Token: 0x06017F43 RID: 98115 RVA: 0x0076B7EF File Offset: 0x00769BEF
	public override void OnUpdateGraphic(int deltaTime)
	{
		this.UpdateChaserGraphicPos(deltaTime);
	}

	// Token: 0x06017F44 RID: 98116 RVA: 0x0076B7F8 File Offset: 0x00769BF8
	public override void OnFinish()
	{
		base.OnFinish();
		this.ClearData();
		this.RemoveHandle();
	}

	// Token: 0x06017F45 RID: 98117 RVA: 0x0076B80C File Offset: 0x00769C0C
	private void RemoveHandle()
	{
		if (this.mHandleList != null)
		{
			for (int i = 0; i < this.mHandleList.Count; i++)
			{
				BeEventHandle beEventHandle = this.mHandleList[i];
				if (beEventHandle != null)
				{
					beEventHandle.Remove();
				}
			}
			this.mHandleList.Clear();
			ListPool<BeEventHandle>.Release(this.mHandleList);
			this.mHandleList = null;
		}
		if (this.mEquipHandle != null)
		{
			this.mEquipHandle.Remove();
			this.mEquipHandle = null;
		}
	}

	// Token: 0x06017F46 RID: 98118 RVA: 0x0076B898 File Offset: 0x00769C98
	private void InitData()
	{
		this.m_ChaserQueue = new Queue<Mechanism2072.ChaserData>();
		this.m_HurtIdDic = new Dictionary<int, Mechanism2072.ChaserType>();
		this.mSkillMarkSet = new HashSet<int>();
		this.UpdateEquipData();
		this.m_LastAddType = Mechanism2072.ChaserType.None;
		this.RegiserEvent();
		this.m_CurChaserCount = 0;
		this.m_HurtIdDic.Add(23180, Mechanism2072.ChaserType.None);
		this.m_HurtIdDic.Add(20100, Mechanism2072.ChaserType.Light);
		this.m_HurtIdDic.Add(23010, Mechanism2072.ChaserType.Dark);
		this.m_HurtIdDic.Add(20080, Mechanism2072.ChaserType.Ice);
		this.m_HurtIdDic.Add(20090, Mechanism2072.ChaserType.Fire);
		this.m_HurtIdDic.Add(20091, Mechanism2072.ChaserType.Fire);
		this.InitEffectData();
	}

	// Token: 0x06017F47 RID: 98119 RVA: 0x0076B94C File Offset: 0x00769D4C
	private void ClearData()
	{
		this.mSkillMarkSet.Clear();
		this.m_ChaserQueue.Clear();
		this.m_ChaserQueue = null;
		this.m_HurtIdDic.Clear();
		this.m_HurtIdDic = null;
	}

	// Token: 0x06017F48 RID: 98120 RVA: 0x0076B980 File Offset: 0x00769D80
	private void RegiserEvent()
	{
		if (base.owner == null)
		{
			return;
		}
		if (this.mHandleList == null)
		{
			this.mHandleList = ListPool<BeEventHandle>.Get();
		}
		this.mHandleList.Add(base.owner.RegisterEvent(BeEventType.onHitOther, new BeEventHandle.Del(this.RegisterSkillHitOther)));
		this.mHandleList.Add(base.owner.RegisterEvent(BeEventType.onHitOther, new BeEventHandle.Del(this.RegisterHitOther)));
		this.mHandleList.Add(base.owner.RegisterEvent(BeEventType.onBattleCombo, new BeEventHandle.Del(this.RegisterComboAddChaser)));
		this.mHandleList.Add(base.owner.RegisterEvent(BeEventType.onCastSkillFinish, new BeEventHandle.Del(this.RegisterSkillComplete)));
		this.mHandleList.Add(base.owner.RegisterEvent(BeEventType.onSkillCancel, new BeEventHandle.Del(this.RegisterSkillComplete)));
		this.mHandleList.Add(base.owner.RegisterEvent(BeEventType.OnChangeWeaponEnd, new BeEventHandle.Del(this.OnChangeWeapon)));
		this.mEquipHandle = base.owner.RegisterEventNew(BeEventType.onChangeEquipEnd, new BeEvent.BeEventHandleNew.Function(this.OnChangeEquip));
		this.mHandleList.Add(base.owner.RegisterEvent(BeEventType.onAfterDead, new BeEventHandle.Del(this.OnDead)));
		this.mHandleList.Add(base.owner.RegisterEvent(BeEventType.onStartPassDoor, new BeEventHandle.Del(this.OnLevelSwitchStart)));
		this.mHandleList.Add(base.owner.RegisterEvent(BeEventType.onPassedDoor, new BeEventHandle.Del(this.OnLevelSwitchEnd)));
	}

	// Token: 0x06017F49 RID: 98121 RVA: 0x0076BB0F File Offset: 0x00769F0F
	private void OnDead(object[] args)
	{
		this.mSkillMarkSet.Clear();
		this.m_ChaserQueue.Clear();
		this.m_CurTimeAcc = 0;
		this.m_CurChaserCount = 0;
		this.m_AutoChaserFlag = false;
		this.m_LastAddType = Mechanism2072.ChaserType.None;
		this.mIsTweenChaser = true;
	}

	// Token: 0x06017F4A RID: 98122 RVA: 0x0076BB4C File Offset: 0x00769F4C
	private void RegisterSkillHitOther(object[] args)
	{
		int skillId = (int)args[2];
		if (this.CheckSkillMark(skillId))
		{
			return;
		}
		int key = (int)args[1];
		if (!this.m_HurtIdDic.ContainsKey(key))
		{
			return;
		}
		Mechanism2072.ChaserType type = this.m_HurtIdDic[key];
		if (base.owner.IsChaserSwitch((int)type))
		{
			return;
		}
		this.MarkSkill(skillId, true);
		Mechanism2072.ChaseSizeType sizeType = Mechanism2072.ChaseSizeType.Normal;
		if (base.owner == null || base.owner.actorData == null)
		{
			return;
		}
		int curComboCount = base.owner.actorData.GetCurComboCount();
		if (curComboCount >= this.z_ComboCheckCountArr[0])
		{
			sizeType = Mechanism2072.ChaseSizeType.Big;
		}
		this.AddChaser(type, sizeType, false);
	}

	// Token: 0x06017F4B RID: 98123 RVA: 0x0076BBFC File Offset: 0x00769FFC
	private void RegisterHitOther(object[] args)
	{
		if (!this.m_AutoChaserFlag)
		{
			return;
		}
		int item = (int)args[1];
		if (!this.z_FilterHitSet.Contains(item))
		{
			return;
		}
		int skillId = (int)args[2];
		if (this.CheckSkillMark(skillId))
		{
			return;
		}
		this.MarkSkill(skillId, true);
		this.RateAddChaser(this.z_GenerateRateArr[1]);
	}

	// Token: 0x06017F4C RID: 98124 RVA: 0x0076BC5C File Offset: 0x0076A05C
	private void RegisterSkillComplete(object[] args)
	{
		int skillId = (int)args[0];
		this.MarkSkill(skillId, false);
	}

	// Token: 0x06017F4D RID: 98125 RVA: 0x0076BC7C File Offset: 0x0076A07C
	private void MarkSkill(int skillId, bool mark)
	{
		if (mark)
		{
			if (!this.mSkillMarkSet.Contains(skillId))
			{
				this.mSkillMarkSet.Add(skillId);
			}
		}
		else if (this.mSkillMarkSet.Contains(skillId))
		{
			this.mSkillMarkSet.Remove(skillId);
		}
	}

	// Token: 0x06017F4E RID: 98126 RVA: 0x0076BCD0 File Offset: 0x0076A0D0
	private bool CheckSkillMark(int skillId)
	{
		return this.mSkillMarkSet.Contains(skillId);
	}

	// Token: 0x06017F4F RID: 98127 RVA: 0x0076BCE0 File Offset: 0x0076A0E0
	private void UpdateChaserPosition(int deltaTime)
	{
		Queue<Mechanism2072.ChaserData>.Enumerator enumerator = this.m_ChaserQueue.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Mechanism2072.ChaserData chaserData = enumerator.Current;
			if (this.mIsTweenChaser)
			{
				chaserData.position = VInt3.Lerp(chaserData.position, this.GetAnchorWorldPos(chaserData.anchorPos), this.z_ChaserTweenFactor);
			}
			else
			{
				chaserData.position = this.GetAnchorWorldPos(chaserData.anchorPos);
			}
		}
		enumerator.Dispose();
	}

	// Token: 0x06017F50 RID: 98128 RVA: 0x0076BD60 File Offset: 0x0076A160
	private void UpdateChaserLive(int deltaTime)
	{
		Queue<Mechanism2072.ChaserData>.Enumerator enumerator = this.m_ChaserQueue.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Mechanism2072.ChaserData chaserData = enumerator.Current;
			chaserData.liveTime += deltaTime;
		}
		enumerator.Dispose();
		int num = 0;
		while (this.m_ChaserQueue.Count > 0)
		{
			Mechanism2072.ChaserData chaserData2 = this.m_ChaserQueue.Peek();
			if (chaserData2 == null || chaserData2.liveTime < this.z_ChaserLiveTime)
			{
				IL_D0:
				if (num > 0)
				{
					this.ChangeChaserEffectPos();
					this._ReduceChaserCount(num);
				}
				return;
			}
			this.m_ChaserQueue.Dequeue();
			num++;
			if (chaserData2.effect != null && base.owner != null && base.owner.m_pkGeActor != null)
			{
				base.owner.m_pkGeActor.DestroyEffect(chaserData2.effect);
			}
		}
		goto IL_D0;
	}

	// Token: 0x06017F51 RID: 98129 RVA: 0x0076BE54 File Offset: 0x0076A254
	private void ChangeChaserEffectPos()
	{
		int num = 0;
		Queue<Mechanism2072.ChaserData>.Enumerator enumerator = this.m_ChaserQueue.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Mechanism2072.ChaserData chaserData = enumerator.Current;
			if (num < this.m_ChaserPosArrEffect.Length)
			{
				chaserData.anchorPos = new VInt3(this.m_ChaserPosArrEffect[num]);
			}
			num++;
		}
		enumerator.Dispose();
	}

	// Token: 0x06017F52 RID: 98130 RVA: 0x0076BEC0 File Offset: 0x0076A2C0
	private void UpdateAddChaser(int deltaTime)
	{
		if (!this.m_AutoChaserFlag)
		{
			return;
		}
		int num = this.z_GenerateTimeAcc + this.z_ChaserCreateTime_Equip;
		if (num <= 1000)
		{
			num = 1000;
		}
		if (this.m_CurTimeAcc < num)
		{
			this.m_CurTimeAcc += deltaTime;
			return;
		}
		this.m_CurTimeAcc -= num;
		Mechanism2072.ChaserType chaserType = this.GetChaserType();
		if (chaserType == Mechanism2072.ChaserType.Max)
		{
			return;
		}
		Mechanism2072.ChaseSizeType sizeType = Mechanism2072.ChaseSizeType.Normal;
		int num2 = (int)base.FrameRandom.Range1000();
		if (num2 <= this.z_GenerateRateArr[0])
		{
			sizeType = Mechanism2072.ChaseSizeType.Big;
		}
		this.AddChaser(chaserType, sizeType, false);
	}

	// Token: 0x06017F53 RID: 98131 RVA: 0x0076BF58 File Offset: 0x0076A358
	private void RegisterComboAddChaser(object[] args)
	{
		if (!this.m_AutoChaserFlag)
		{
			return;
		}
		if (base.owner == null || base.owner.actorData == null)
		{
			return;
		}
		int curComboCount = base.owner.actorData.GetCurComboCount();
		if ((curComboCount - this.z_ComboCheckCountArr[1]) % this.z_ComboCheckCountArr[2] != 0)
		{
			return;
		}
		this.RateAddChaser(this.z_GenerateRateArr[2]);
	}

	// Token: 0x06017F54 RID: 98132 RVA: 0x0076BFC8 File Offset: 0x0076A3C8
	private void RateAddChaser(int rate)
	{
		int num = (int)base.FrameRandom.Range1000();
		if (num > rate)
		{
			return;
		}
		Mechanism2072.ChaserType chaserType = this.GetChaserType();
		if (chaserType == Mechanism2072.ChaserType.Max)
		{
			return;
		}
		Mechanism2072.ChaseSizeType sizeType = Mechanism2072.ChaseSizeType.Normal;
		this.AddChaser(chaserType, sizeType, false);
	}

	// Token: 0x06017F55 RID: 98133 RVA: 0x0076C003 File Offset: 0x0076A403
	public void AddChaserByExternal(Mechanism2072.ChaserType type, Mechanism2072.ChaseSizeType sizeType, bool isExtra = false)
	{
		if (base.owner.IsChaserSwitch((int)type))
		{
			type = this.GetPriorityChaserType();
		}
		if (type == Mechanism2072.ChaserType.Max)
		{
			return;
		}
		this.AddChaser(type, sizeType, isExtra);
	}

	// Token: 0x06017F56 RID: 98134 RVA: 0x0076C030 File Offset: 0x0076A430
	public void AddChaser(Mechanism2072.ChaserType type, Mechanism2072.ChaseSizeType sizeType, bool isExtra = false)
	{
		if (this.m_CurChaserCount >= this.m_ChaserMaxCount)
		{
			return;
		}
		BeEvent.BeEventParam beEventParam = DataStructPool.EventParamPool.Get();
		beEventParam.m_Int = (int)type;
		beEventParam.m_Int2 = (int)sizeType;
		base.owner.TriggerEventNew(BeEventType.onAddChaser, beEventParam);
		type = (Mechanism2072.ChaserType)beEventParam.m_Int;
		sizeType = (Mechanism2072.ChaseSizeType)beEventParam.m_Int2;
		DataStructPool.EventParamPool.Release(beEventParam);
		if (!isExtra)
		{
			this.m_LastAddType = type;
		}
		Mechanism2072.ChaserData chaserData = new Mechanism2072.ChaserData();
		chaserData.type = type;
		chaserData.sizeType = sizeType;
		chaserData.liveTime = 0;
		chaserData.scale = this.GetChaserScale(type);
		int count = this.m_ChaserQueue.Count;
		chaserData.anchorPos = new VInt3(this.m_ChaserPosArrEffect[count]);
		chaserData.position = this.GetAnchorWorldPos(chaserData.anchorPos);
		if (this.NeedCreateEffect())
		{
			GeEffectEx geEffectEx = this.AddChaserEffect(chaserData, count);
			chaserData.effect = geEffectEx;
			if (geEffectEx != null && !this.m_IsChaserVisable)
			{
				chaserData.effect.SetVisible(this.m_IsChaserVisable);
			}
		}
		this.m_CurChaserCount++;
		this.m_ChaserQueue.Enqueue(chaserData);
	}

	// Token: 0x06017F57 RID: 98135 RVA: 0x0076C150 File Offset: 0x0076A550
	private VFactor GetChaserScale(Mechanism2072.ChaserType type)
	{
		VFactor a = VFactor.zero;
		if (base.owner != null && base.owner.actorData != null)
		{
			int curComboCount = base.owner.actorData.GetCurComboCount();
			for (int i = 0; i < this.m_ComboScaleList.Count; i++)
			{
				Mechanism2089.ComboScale comboScale = this.m_ComboScaleList[i];
				if (curComboCount >= comboScale.combo)
				{
					a += comboScale.scale;
				}
			}
		}
		VFactor b = VFactor.zero;
		if (type < (Mechanism2072.ChaserType)this.z_ChaserScale.Length)
		{
			b = this.z_ChaserScale[(int)type];
		}
		return a + b;
	}

	// Token: 0x06017F58 RID: 98136 RVA: 0x0076C208 File Offset: 0x0076A608
	private VInt3 GetAnchorWorldPos(VInt3 pos)
	{
		if (base.owner == null)
		{
			return VInt3.zero;
		}
		pos.x = ((!base.owner.GetFace()) ? pos.x : (pos.x * -1));
		return base.owner.GetPosition() + pos;
	}

	// Token: 0x06017F59 RID: 98137 RVA: 0x0076C264 File Offset: 0x0076A664
	public void LaunchChaser(int launchCount, List<Mechanism2072.ChaserData> list)
	{
		if (list == null)
		{
			return;
		}
		list.Clear();
		int count = this.m_ChaserQueue.Count;
		for (int i = 0; i < count; i++)
		{
			if (i >= launchCount)
			{
				break;
			}
			Mechanism2072.ChaserData item = this.m_ChaserQueue.Dequeue();
			list.Add(item);
		}
		this.ChangeChaserEffectPos();
	}

	// Token: 0x06017F5A RID: 98138 RVA: 0x0076C2C1 File Offset: 0x0076A6C1
	private Mechanism2072.ChaserType GetChaserType()
	{
		if (this.m_LastAddType != Mechanism2072.ChaserType.None)
		{
			return this.m_LastAddType;
		}
		return this.GetPriorityChaserType();
	}

	// Token: 0x06017F5B RID: 98139 RVA: 0x0076C2DC File Offset: 0x0076A6DC
	private Mechanism2072.ChaserType GetPriorityChaserType()
	{
		Mechanism2072.ChaserType[] array = new Mechanism2072.ChaserType[]
		{
			Mechanism2072.ChaserType.None,
			Mechanism2072.ChaserType.Dark,
			Mechanism2072.ChaserType.Fire,
			Mechanism2072.ChaserType.Light,
			Mechanism2072.ChaserType.Ice
		};
		for (int i = 0; i < array.Length; i++)
		{
			if (!base.owner.IsChaserSwitch((int)array[i]))
			{
				return array[i];
			}
		}
		return Mechanism2072.ChaserType.Max;
	}

	// Token: 0x06017F5C RID: 98140 RVA: 0x0076C327 File Offset: 0x0076A727
	public int GetChaserCount()
	{
		if (this.m_ChaserQueue == null)
		{
			return 0;
		}
		return this.m_ChaserQueue.Count;
	}

	// Token: 0x06017F5D RID: 98141 RVA: 0x0076C341 File Offset: 0x0076A741
	public void SetAutoChaserFlag(bool flag, int level)
	{
		this.m_AutoChaserFlag = flag;
		if (this.m_AutoChaserFlag)
		{
			this.mAutoChaserLevel = level;
			this.UpdateAutoChaserData();
			this.m_CurTimeAcc = this.z_GenerateTimeAcc + this.z_ChaserCreateTime_Equip;
		}
	}

	// Token: 0x06017F5E RID: 98142 RVA: 0x0076C378 File Offset: 0x0076A778
	public void UpdateAutoChaserData()
	{
		this.z_GenerateTimeAcc = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.mAutoChaserLevel, true);
		if (BattleMain.IsModePvP(base.battleType))
		{
			this.z_GenerateRateArr[0] = TableManager.GetValueFromUnionCell(this.data.ValueH[0], this.mAutoChaserLevel, true) + this.z_GenerateRateArr_Equip[0];
			this.z_GenerateRateArr[1] = TableManager.GetValueFromUnionCell(this.data.ValueH[1], this.mAutoChaserLevel, true) + this.z_GenerateRateArr_Equip[1];
			this.z_GenerateRateArr[2] = TableManager.GetValueFromUnionCell(this.data.ValueH[2], this.mAutoChaserLevel, true) + this.z_GenerateRateArr_Equip[2];
		}
		else
		{
			this.z_GenerateRateArr[0] = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.mAutoChaserLevel, true) + this.z_GenerateRateArr_Equip[0];
			this.z_GenerateRateArr[1] = TableManager.GetValueFromUnionCell(this.data.ValueC[1], this.mAutoChaserLevel, true) + this.z_GenerateRateArr_Equip[1];
			this.z_GenerateRateArr[2] = TableManager.GetValueFromUnionCell(this.data.ValueC[2], this.mAutoChaserLevel, true) + this.z_GenerateRateArr_Equip[2];
		}
	}

	// Token: 0x06017F5F RID: 98143 RVA: 0x0076C4D4 File Offset: 0x0076A8D4
	public void SetChaseSize(Mechanism2072.ChaseSizeType size)
	{
		Queue<Mechanism2072.ChaserData>.Enumerator enumerator = this.m_ChaserQueue.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Mechanism2072.ChaserData chaserData = enumerator.Current;
			chaserData.sizeType = size;
			this.SetEffectScale(chaserData, chaserData.effect);
		}
		enumerator.Dispose();
	}

	// Token: 0x06017F60 RID: 98144 RVA: 0x0076C521 File Offset: 0x0076A921
	private void _ReduceChaserCount(int count)
	{
		if (this.m_CurChaserCount < count)
		{
			this.m_CurChaserCount = 0;
			return;
		}
		this.m_CurChaserCount -= count;
	}

	// Token: 0x06017F61 RID: 98145 RVA: 0x0076C548 File Offset: 0x0076A948
	public void ReduceChaserCount(int count)
	{
		BeEvent.BeEventParam beEventParam = DataStructPool.EventParamPool.Get();
		beEventParam.m_Int = count;
		base.owner.TriggerEventNew(BeEventType.onRemoveChaser, beEventParam);
		DataStructPool.EventParamPool.Release(beEventParam);
		this._ReduceChaserCount(count);
	}

	// Token: 0x06017F62 RID: 98146 RVA: 0x0076C580 File Offset: 0x0076A980
	private void InitEffectData()
	{
		this.m_ChaserPathArr[0] = "Effects/Hero_Lifa/Eff_Lifa_XWRH/Prefab/Eff_Lifa_XWRH_wu";
		this.m_ChaserPathArr[1] = "Effects/Hero_Lifa/Eff_Lifa_XWRH/Prefab/Eff_Lifa_XWRH_guang";
		this.m_ChaserPathArr[2] = "Effects/Hero_Lifa/Eff_Lifa_XWRH/Prefab/Eff_Lifa_XWRH_fire";
		this.m_ChaserPathArr[3] = "Effects/Hero_Lifa/Eff_Lifa_XWRH/Prefab/Eff_Lifa_XWRH_ice";
		this.m_ChaserPathArr[4] = "Effects/Hero_Lifa/Eff_Lifa_XWRH/Prefab/Eff_Lifa_XWRH_an";
		if (base.owner != null && base.owner.CurrentBeScene != null)
		{
			this.mHandleList.Add(base.owner.CurrentBeScene.RegisterEvent(BeEventSceneType.OnStartAirBattle, new BeEventHandle.Del(this.OnStartAirBattle)));
			this.mHandleList.Add(base.owner.CurrentBeScene.RegisterEvent(BeEventSceneType.OnEndAirBattle, new BeEventHandle.Del(this.OnEndAirBattle)));
		}
	}

	// Token: 0x06017F63 RID: 98147 RVA: 0x0076C63B File Offset: 0x0076AA3B
	private void OnStartAirBattle(object[] args)
	{
		this.SetChaserVisable(false);
	}

	// Token: 0x06017F64 RID: 98148 RVA: 0x0076C644 File Offset: 0x0076AA44
	private void OnEndAirBattle(object[] args)
	{
		this.SetChaserVisable(true);
	}

	// Token: 0x06017F65 RID: 98149 RVA: 0x0076C650 File Offset: 0x0076AA50
	private void UpdateChaserGraphicPos(int deltaTime)
	{
		Queue<Mechanism2072.ChaserData>.Enumerator enumerator = this.m_ChaserQueue.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Mechanism2072.ChaserData chaserData = enumerator.Current;
			if (chaserData != null && chaserData.effect != null)
			{
				chaserData.effect.SetPosition(chaserData.position.vector3);
			}
		}
		enumerator.Dispose();
	}

	// Token: 0x06017F66 RID: 98150 RVA: 0x0076C6B0 File Offset: 0x0076AAB0
	private GeEffectEx AddChaserEffect(Mechanism2072.ChaserData data, int index)
	{
		if (index >= this.m_ChaserPosArrEffect.Length)
		{
			return null;
		}
		if (base.owner == null || base.owner.m_pkGeActor == null)
		{
			return null;
		}
		string chaserPath = this.GetChaserPath(data.type);
		GeEffectEx geEffectEx = base.owner.m_pkGeActor.CreateEffect(chaserPath, "[actor]Orign", 1E+09f, Vec3.zero, 1f, 1f, true, false, EffectTimeType.BUFF, false);
		if (geEffectEx != null)
		{
			GeUtility.AttachTo(geEffectEx.GetRootNode(), base.owner.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Root), false);
			geEffectEx.SetPosition(data.position.vector3);
			this.SetEffectScale(data, geEffectEx);
			return geEffectEx;
		}
		return null;
	}

	// Token: 0x06017F67 RID: 98151 RVA: 0x0076C768 File Offset: 0x0076AB68
	private string GetChaserPath(Mechanism2072.ChaserType type)
	{
		string result = this.m_ChaserPathArr[0];
		switch (type)
		{
		case Mechanism2072.ChaserType.Light:
			result = this.m_ChaserPathArr[1];
			break;
		case Mechanism2072.ChaserType.Fire:
			result = this.m_ChaserPathArr[2];
			break;
		case Mechanism2072.ChaserType.Ice:
			result = this.m_ChaserPathArr[3];
			break;
		case Mechanism2072.ChaserType.Dark:
			result = this.m_ChaserPathArr[4];
			break;
		}
		return result;
	}

	// Token: 0x06017F68 RID: 98152 RVA: 0x0076C7D4 File Offset: 0x0076ABD4
	private void SetEffectScale(Mechanism2072.ChaserData data, GeEffectEx effect)
	{
		if (effect == null)
		{
			return;
		}
		float num = 1f;
		Mechanism2072.ChaseSizeType sizeType = data.sizeType;
		if (sizeType == Mechanism2072.ChaseSizeType.Big)
		{
			num = 1.3f;
		}
		num += data.scale.single;
		effect.SetScale(num, num, num);
	}

	// Token: 0x06017F69 RID: 98153 RVA: 0x0076C824 File Offset: 0x0076AC24
	private void SetChaserVisable(bool visable)
	{
		this.m_IsChaserVisable = visable;
		Queue<Mechanism2072.ChaserData>.Enumerator enumerator = this.m_ChaserQueue.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Mechanism2072.ChaserData chaserData = enumerator.Current;
			if (chaserData.effect != null)
			{
				chaserData.effect.SetVisible(visable);
			}
		}
		enumerator.Dispose();
	}

	// Token: 0x06017F6A RID: 98154 RVA: 0x0076C87C File Offset: 0x0076AC7C
	protected bool NeedCreateEffect()
	{
		return BattleMain.IsModePvP(base.battleType) || base.owner.isLocalActor || Singleton<SettingManager>.instance == null || Singleton<SettingManager>.instance.GetCommmonSet("SETTING_SKILLEFFECTSET") == SettingManager.SetCommonType.Open;
	}

	// Token: 0x040113F1 RID: 70641
	public static readonly int ChaserMgrID = 5282;

	// Token: 0x040113F2 RID: 70642
	private Vector3[] m_ChaserPosArrEffect = new Vector3[]
	{
		new Vector3(-0.752f, 1.811f, -0.38f),
		new Vector3(-0.997f, 1.484f, -0.107f),
		new Vector3(-0.618f, 1.131f, 0.54f),
		new Vector3(-1.018f, 1.166f, -0.201f),
		new Vector3(-0.687f, 0.74f, 0.413f),
		new Vector3(-0.45f, 0.518f, -0.14f),
		new Vector3(-0.799f, 0.265f, 0.093f),
		new Vector3(-0.962f, 0.7f, -0.21f),
		new Vector3(-1.324f, 0.674f, 0.575f),
		new Vector3(-1.245f, 0.627f, -0.481f),
		new Vector3(-1.418f, 1.206f, 0.136f)
	};

	// Token: 0x040113F3 RID: 70643
	private int[] z_ChaserMaxCount = new int[2];

	// Token: 0x040113F4 RID: 70644
	private int[] z_ComboCheckCountArr = new int[3];

	// Token: 0x040113F5 RID: 70645
	private int[] z_GenerateRateArr = new int[3];

	// Token: 0x040113F6 RID: 70646
	private int[] z_GenerateRateArr_Equip = new int[3];

	// Token: 0x040113F7 RID: 70647
	private int z_ChaserCreateTime_Equip;

	// Token: 0x040113F8 RID: 70648
	private int z_GenerateTimeAcc;

	// Token: 0x040113F9 RID: 70649
	private int z_ChaserLiveTime;

	// Token: 0x040113FA RID: 70650
	private VFactor z_ChaserTweenFactor;

	// Token: 0x040113FB RID: 70651
	private List<Mechanism2089.ComboScale> m_ComboScaleList = new List<Mechanism2089.ComboScale>();

	// Token: 0x040113FC RID: 70652
	private HashSet<int> z_FilterHitSet = new HashSet<int>();

	// Token: 0x040113FD RID: 70653
	private VFactor[] z_ChaserScale = new VFactor[5];

	// Token: 0x040113FE RID: 70654
	private Queue<Mechanism2072.ChaserData> m_ChaserQueue;

	// Token: 0x040113FF RID: 70655
	private int m_ChaserMaxCount;

	// Token: 0x04011400 RID: 70656
	private bool m_AutoChaserFlag;

	// Token: 0x04011401 RID: 70657
	private Mechanism2072.ChaserType m_LastAddType;

	// Token: 0x04011402 RID: 70658
	private int m_CurTimeAcc;

	// Token: 0x04011403 RID: 70659
	private int m_CurChaserCount;

	// Token: 0x04011404 RID: 70660
	private List<BeEventHandle> mHandleList;

	// Token: 0x04011405 RID: 70661
	private BeEvent.BeEventHandleNew mEquipHandle;

	// Token: 0x04011406 RID: 70662
	private Dictionary<int, Mechanism2072.ChaserType> m_HurtIdDic;

	// Token: 0x04011407 RID: 70663
	private HashSet<int> mSkillMarkSet;

	// Token: 0x04011408 RID: 70664
	private int mAutoChaserLevel;

	// Token: 0x04011409 RID: 70665
	private bool mIsTweenChaser = true;

	// Token: 0x0401140A RID: 70666
	private string[] m_ChaserPathArr = new string[5];

	// Token: 0x0401140B RID: 70667
	private bool m_IsChaserVisable = true;

	// Token: 0x0200437F RID: 17279
	public enum ChaserType
	{
		// Token: 0x0401140D RID: 70669
		[Description("无")]
		None,
		// Token: 0x0401140E RID: 70670
		[Description("光属性炫纹")]
		Light,
		// Token: 0x0401140F RID: 70671
		[Description("火属性炫纹")]
		Fire,
		// Token: 0x04011410 RID: 70672
		[Description("冰属性炫纹")]
		Ice,
		// Token: 0x04011411 RID: 70673
		[Description("暗属性炫纹")]
		Dark,
		// Token: 0x04011412 RID: 70674
		Max
	}

	// Token: 0x02004380 RID: 17280
	public enum ChaseSizeType
	{
		// Token: 0x04011414 RID: 70676
		[Description("一般大小")]
		Normal,
		// Token: 0x04011415 RID: 70677
		[Description("大炫纹")]
		Big,
		// Token: 0x04011416 RID: 70678
		Max
	}

	// Token: 0x02004381 RID: 17281
	public class ChaserData
	{
		// Token: 0x04011417 RID: 70679
		public Mechanism2072.ChaserType type;

		// Token: 0x04011418 RID: 70680
		public Mechanism2072.ChaseSizeType sizeType;

		// Token: 0x04011419 RID: 70681
		public int liveTime;

		// Token: 0x0401141A RID: 70682
		public VInt3 position;

		// Token: 0x0401141B RID: 70683
		public VFactor scale;

		// Token: 0x0401141C RID: 70684
		public VInt3 anchorPos;

		// Token: 0x0401141D RID: 70685
		public GeEffectEx effect;
	}
}
