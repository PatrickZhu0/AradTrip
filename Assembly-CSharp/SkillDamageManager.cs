using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;

// Token: 0x020010DF RID: 4319
public class SkillDamageManager
{
	// Token: 0x0600A362 RID: 41826 RVA: 0x0021742D File Offset: 0x0021582D
	public SkillDamageManager(BeActor actor)
	{
		this.owner = actor;
	}

	// Token: 0x0600A363 RID: 41827 RVA: 0x00217448 File Offset: 0x00215848
	public void InitData(BeScene sce)
	{
		this.skillIdDic = new Dictionary<int, List<int>>();
		this.skillDamageData = default(SkillDamageData);
		this.scene = sce;
		this.RemoveHandle();
		this.InitHandle();
		this.InitSkillData();
	}

	// Token: 0x0600A364 RID: 41828 RVA: 0x00217488 File Offset: 0x00215888
	public void DeInit()
	{
		this.RemoveHandle();
	}

	// Token: 0x0600A365 RID: 41829 RVA: 0x00217490 File Offset: 0x00215890
	public void Update(int deltaTime)
	{
		this.UpdateTotalTime(deltaTime);
		this.UpdateMonsterTime(deltaTime);
	}

	// Token: 0x0600A366 RID: 41830 RVA: 0x002174A0 File Offset: 0x002158A0
	private void UpdateTotalTime(int deltaTime)
	{
		if (!this.timingFlag)
		{
			return;
		}
		if (this.skillDamageData.totalTime >= 2147483647)
		{
			return;
		}
		this.skillDamageData.totalTime = this.skillDamageData.totalTime + deltaTime;
	}

	// Token: 0x0600A367 RID: 41831 RVA: 0x002174D8 File Offset: 0x002158D8
	private void UpdateMonsterTime(int deltaTime)
	{
		if (!this.timingFlag)
		{
			return;
		}
		if (this.skillDamageData.monsterExistTimeList == null)
		{
			return;
		}
		for (int i = 0; i < this.skillDamageData.monsterExistTimeList.Count; i++)
		{
			MonsterExistTime value = this.skillDamageData.monsterExistTimeList[i];
			int monsterId = value.monsterId;
			if (this.recordMonsterIdList.Contains(monsterId))
			{
				if (!value.isDead)
				{
					if (value.time < 2147483647)
					{
						value.time += deltaTime;
						this.skillDamageData.monsterExistTimeList[i] = value;
					}
				}
			}
		}
	}

	// Token: 0x0600A368 RID: 41832 RVA: 0x0021759C File Offset: 0x0021599C
	private void InitHandle()
	{
		if (this.owner == null || this.scene == null)
		{
			return;
		}
		this.onHurtHandle = this.scene.RegisterEvent(BeEventSceneType.onDoHurt, delegate(object[] args)
		{
			BeActor beActor = (BeActor)args[1];
			BeActor beActor2 = beActor.GetTopOwner(beActor.GetOwner()) as BeActor;
			if (beActor2 != this.owner)
			{
				return;
			}
			this.OnHurt((int)args[0], (BeActor)args[2], (int)args[3]);
		});
		this.onSummonHandle = this.scene.RegisterEvent(BeEventSceneType.onSummon, delegate(object[] args)
		{
			BeActor beActor = (BeActor)args[1];
			BeActor beActor2 = beActor.GetTopOwner(beActor.GetOwner()) as BeActor;
			if (beActor2 != this.owner)
			{
				return;
			}
			this.OnSummon((BeActor)args[0], (int)args[2]);
		});
		this.onHurtByAbnormalHandle = this.scene.RegisterEvent(BeEventSceneType.onHurtByAbnormalBuff, delegate(object[] args)
		{
			BeActor beActor = (BeActor)args[1];
			if (beActor == null)
			{
				return;
			}
			BeActor beActor2 = beActor.GetTopOwner(beActor) as BeActor;
			if (beActor2 != this.owner)
			{
				return;
			}
			this.OnHurtByAbnormalBuff((int)args[0], (BeActor)args[2], (int)args[3]);
		});
		this.onCastSkillHandle = this.owner.RegisterEvent(BeEventType.onCastSkill, delegate(object[] args)
		{
			int skillId = (int)args[0];
			this.SaveOrigionSkillUseData(skillId);
		});
		this.onAreaClearHandle = this.scene.RegisterEvent(BeEventSceneType.onClear, delegate(object[] args)
		{
			this.timingFlag = false;
		});
		this.onSceneMonsterDead = this.scene.RegisterEvent(BeEventSceneType.onMonsterDead, delegate(object[] args)
		{
			this.SaveMonsterDeadTime(args[0] as BeActor);
		});
	}

	// Token: 0x0600A369 RID: 41833 RVA: 0x00217678 File Offset: 0x00215A78
	private void RemoveHandle()
	{
		if (this.onHurtHandle != null)
		{
			this.onHurtHandle.Remove();
			this.onHurtHandle = null;
		}
		if (this.onSummonHandle != null)
		{
			this.onSummonHandle.Remove();
			this.onSummonHandle = null;
		}
		if (this.onHurtByAbnormalHandle != null)
		{
			this.onHurtByAbnormalHandle.Remove();
			this.onHurtByAbnormalHandle = null;
		}
		if (this.onCastSkillHandle != null)
		{
			this.onCastSkillHandle.Remove();
			this.onCastSkillHandle = null;
		}
		if (this.onAreaClearHandle != null)
		{
			this.onAreaClearHandle.Remove();
			this.onAreaClearHandle = null;
		}
		if (this.onSceneMonsterDead != null)
		{
			this.onSceneMonsterDead.Remove();
			this.onSceneMonsterDead = null;
		}
	}

	// Token: 0x0600A36A RID: 41834 RVA: 0x00217734 File Offset: 0x00215B34
	private void InitSkillData()
	{
		if (this.owner == null)
		{
			return;
		}
		List<int> actorSkillList = this.GetActorSkillList(this.owner);
		for (int i = 0; i < actorSkillList.Count; i++)
		{
			int num = actorSkillList[i];
			int comboSkillId = BeUtility.GetComboSkillId(this.owner, num);
			List<int> list = new List<int>();
			if (!list.Contains(num))
			{
				list.Add(num);
			}
			if (!list.Contains(comboSkillId))
			{
				list.Add(comboSkillId);
			}
			this.skillIdDic.Add(num, list);
		}
	}

	// Token: 0x0600A36B RID: 41835 RVA: 0x002177C5 File Offset: 0x00215BC5
	private void OnHurt(int hurtValue, BeActor target, int skillId)
	{
		this.SaveAllData(hurtValue, target, skillId);
	}

	// Token: 0x0600A36C RID: 41836 RVA: 0x002177D0 File Offset: 0x00215BD0
	private void OnSummon(BeActor monster, int skillId)
	{
		if (monster == null)
		{
			return;
		}
		int originSkillId = this.GetOriginSkillId(skillId);
		if (originSkillId == 0)
		{
			return;
		}
		List<int> actorSkillList = this.GetActorSkillList(monster);
		this.skillIdDic[originSkillId].AddRange(actorSkillList);
	}

	// Token: 0x0600A36D RID: 41837 RVA: 0x0021780D File Offset: 0x00215C0D
	private void OnHurtByAbnormalBuff(int hurtValue, BeActor target, int skillId)
	{
		this.SaveAllData(hurtValue, target, skillId);
	}

	// Token: 0x0600A36E RID: 41838 RVA: 0x00217818 File Offset: 0x00215C18
	private List<int> GetActorSkillList(BeActor actor)
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, BeSkill> keyValuePair in actor.GetSkills())
		{
			int key = keyValuePair.Key;
			list.Add(key);
		}
		return list;
	}

	// Token: 0x0600A36F RID: 41839 RVA: 0x00217860 File Offset: 0x00215C60
	private int GetOriginSkillId(int id)
	{
		foreach (KeyValuePair<int, List<int>> keyValuePair in this.skillIdDic)
		{
			int key = keyValuePair.Key;
			Dictionary<int, List<int>>.Enumerator enumerator;
			KeyValuePair<int, List<int>> keyValuePair2 = enumerator.Current;
			List<int> value = keyValuePair2.Value;
			for (int i = 0; i < value.Count; i++)
			{
				if (value[i] == id)
				{
					return key;
				}
			}
		}
		return 0;
	}

	// Token: 0x0600A370 RID: 41840 RVA: 0x002178D8 File Offset: 0x00215CD8
	private void SaveAllData(int hurtValue, BeActor target, int skillId)
	{
		if (skillId == 1719)
		{
			skillId = 1500;
		}
		int originSkillId = this.GetOriginSkillId(skillId);
		if (originSkillId == 0)
		{
			return;
		}
		if (originSkillId == 9998)
		{
			return;
		}
		int num = BeUtility.GetComboSkillId(this.owner, originSkillId);
		int monsterID = target.GetEntityData().monsterID;
		string name = target.GetEntityData().name;
		this.SaveMonsterData(monsterID, name);
		if (num == 1712)
		{
			num = 1500;
		}
		if (num == 3100 || num == 3101)
		{
			num = 3000;
		}
		this.SaveDamageData(num, (long)hurtValue, monsterID);
		this.SaveMonsterBeHitTime(target.GetPID(), monsterID, target);
	}

	// Token: 0x0600A371 RID: 41841 RVA: 0x00217984 File Offset: 0x00215D84
	private void SaveMonsterBeHitTime(int pid, int monsterId, BeActor target)
	{
		if (!this.CheckTargetIsMeetCondition(target))
		{
			return;
		}
		if (this.skillDamageData.monsterExistTimeList == null)
		{
			this.skillDamageData.monsterExistTimeList = new List<MonsterExistTime>();
		}
		if (this.recordMonsterIdList.Contains(monsterId))
		{
			return;
		}
		MonsterExistTime item = default(MonsterExistTime);
		item.monsterId = monsterId;
		this.skillDamageData.monsterExistTimeList.Add(item);
		this.recordMonsterIdList.Add(monsterId);
	}

	// Token: 0x0600A372 RID: 41842 RVA: 0x00217A00 File Offset: 0x00215E00
	private bool CheckTargetIsMeetCondition(BeActor actor)
	{
		return actor.IsMonster() && actor.GetEntityData().monsterData != null && (actor.GetEntityData().monsterData.Type == UnitTable.eType.BOSS || actor.GetEntityData().monsterData.Type == UnitTable.eType.ELITE);
	}

	// Token: 0x0600A373 RID: 41843 RVA: 0x00217A5C File Offset: 0x00215E5C
	private void SaveMonsterDeadTime(BeActor actor)
	{
		if (actor == null)
		{
			return;
		}
		int monsterID = actor.GetEntityData().monsterID;
		if (!this.recordMonsterIdList.Contains(monsterID))
		{
			return;
		}
		this.recordMonsterIdList.Remove(monsterID);
	}

	// Token: 0x0600A374 RID: 41844 RVA: 0x00217A9C File Offset: 0x00215E9C
	public double GetMonsterTime(int monsterId, SkillDamageData data)
	{
		if (monsterId == 0)
		{
			return (double)data.totalTime;
		}
		if (data.monsterExistTimeList == null || data.monsterExistTimeList.Count <= 0)
		{
			return 0.0;
		}
		for (int i = 0; i < data.monsterExistTimeList.Count; i++)
		{
			MonsterExistTime monsterExistTime = data.monsterExistTimeList[i];
			if (monsterExistTime.monsterId == monsterId)
			{
				return (double)monsterExistTime.time;
			}
		}
		return 0.0;
	}

	// Token: 0x0600A375 RID: 41845 RVA: 0x00217B2C File Offset: 0x00215F2C
	private void SaveOrigionSkillUseData(int skillId)
	{
		int num = BeUtility.GetComboSkillId(this.owner, skillId);
		if (skillId != num)
		{
			return;
		}
		if (num == 1712)
		{
			num = 1500;
		}
		int num2 = this.UseSkillIndex(num);
		if (num2 != -1)
		{
			List<int> origionSkillIdUseCount;
			int index;
			(origionSkillIdUseCount = this.skillDamageData.origionSkillIdUseCount)[index = num2] = origionSkillIdUseCount[index] + 1;
		}
	}

	// Token: 0x0600A376 RID: 41846 RVA: 0x00217B8C File Offset: 0x00215F8C
	private int UseSkillIndex(int skillId)
	{
		if (this.skillDamageData.origionSkillIdList == null)
		{
			this.skillDamageData.origionSkillIdList = new List<int>();
		}
		if (this.skillDamageData.origionSkillIdUseCount == null)
		{
			this.skillDamageData.origionSkillIdUseCount = new List<int>();
		}
		int num = this.skillDamageData.origionSkillIdList.FindIndex((int x) => x == skillId);
		if (num == -1)
		{
			this.skillDamageData.origionSkillIdList.Add(skillId);
			this.skillDamageData.origionSkillIdUseCount.Add(1);
			return num;
		}
		return num;
	}

	// Token: 0x0600A377 RID: 41847 RVA: 0x00217C34 File Offset: 0x00216034
	private void SaveMonsterData(int monsterId, string monsterName)
	{
		if (this.skillDamageData.monsterIdList == null)
		{
			this.skillDamageData.monsterIdList = new List<int>();
			this.skillDamageData.monsterIdList.Add(0);
		}
		int num = this.skillDamageData.monsterIdList.FindIndex((int x) => x == monsterId);
		if (num != -1)
		{
			return;
		}
		this.skillDamageData.monsterIdList.Add(monsterId);
		if (this.skillDamageData.monsterNameList == null)
		{
			this.skillDamageData.monsterNameList = new List<string>();
			this.skillDamageData.monsterNameList.Add("所有");
		}
		if (monsterName.Length > 8)
		{
			monsterName.Substring(0, 8);
		}
		this.skillDamageData.monsterNameList.Add(monsterName);
	}

	// Token: 0x0600A378 RID: 41848 RVA: 0x00217D18 File Offset: 0x00216118
	private void SaveDamageData(int skillId, long damage, int monsterId)
	{
		this.UseSkillIndex(skillId);
		if (this.skillDamageData.skillDamageDic == null)
		{
			this.skillDamageData.skillDamageDic = new Dictionary<int, List<DamageData>>();
		}
		if (!this.skillDamageData.skillDamageDic.ContainsKey(monsterId))
		{
			this.skillDamageData.skillDamageDic.Add(monsterId, new List<DamageData>());
		}
		List<DamageData> list = this.skillDamageData.skillDamageDic[monsterId];
		bool flag = false;
		for (int i = 0; i < list.Count; i++)
		{
			DamageData value = list[i];
			if (value.skillId == skillId)
			{
				value.damage += damage;
				list[i] = value;
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			list.Add(new DamageData
			{
				skillId = skillId,
				damage = damage
			});
		}
		if (!this.timingFlag)
		{
			this.timingFlag = true;
		}
	}

	// Token: 0x0600A379 RID: 41849 RVA: 0x00217E10 File Offset: 0x00216210
	public void SaveSkillDamageData(BeActor actor, string dungeonName)
	{
		if (actor.skillDamageManager == null)
		{
			return;
		}
		SkillDamageData item = actor.skillDamageManager.skillDamageData;
		item.dungeonName = dungeonName;
		if (item.skillDamageDic == null || item.skillDamageDic.Count <= 0)
		{
			return;
		}
		List<SkillDamageData> list = this.GetSkillDamageData();
		List<SkillDamageData> list2 = new List<SkillDamageData>();
		list2.Add(item);
		if (list != null)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (list2.Count >= 3)
				{
					break;
				}
				list2.Add(list[i]);
			}
		}
		DataManager<SkillDamageStorage>.GetInstance().SaveSkillDamageData(list2);
	}

	// Token: 0x0600A37A RID: 41850 RVA: 0x00217EB6 File Offset: 0x002162B6
	public List<SkillDamageData> GetSkillDamageData()
	{
		return DataManager<SkillDamageStorage>.GetInstance().GetSkillDamageData();
	}

	// Token: 0x0600A37B RID: 41851 RVA: 0x00217EC2 File Offset: 0x002162C2
	public void ClearSkillDamageData()
	{
		DataManager<SkillDamageStorage>.GetInstance().Clear();
	}

	// Token: 0x0600A37C RID: 41852 RVA: 0x00217ED0 File Offset: 0x002162D0
	public string GetSkillDamagePercent(int skillId, int monsterId, SkillDamageData data)
	{
		long skilDamage = this.GetSkilDamage(skillId, monsterId, data);
		long totalDamage = this.GetTotalDamage(monsterId, data);
		VFactor vfactor = new VFactor(skilDamage, totalDamage);
		return (vfactor.single * 100f).ToString("0.0") + "%";
	}

	// Token: 0x0600A37D RID: 41853 RVA: 0x00217F20 File Offset: 0x00216320
	public long GetSkilDamage(int skillId, int monsterId, SkillDamageData data)
	{
		long num = 0L;
		if (monsterId != 0 && !data.skillDamageDic.ContainsKey(monsterId))
		{
			return num;
		}
		Dictionary<int, List<DamageData>> skillDamageDic = data.skillDamageDic;
		foreach (KeyValuePair<int, List<DamageData>> keyValuePair in skillDamageDic)
		{
			int key = keyValuePair.Key;
			Dictionary<int, List<DamageData>>.Enumerator enumerator;
			KeyValuePair<int, List<DamageData>> keyValuePair2 = enumerator.Current;
			List<DamageData> value = keyValuePair2.Value;
			if (monsterId == 0 || key == monsterId)
			{
				for (int i = 0; i < value.Count; i++)
				{
					if (value[i].skillId == skillId)
					{
						num += value[i].damage;
					}
				}
			}
		}
		return num;
	}

	// Token: 0x0600A37E RID: 41854 RVA: 0x00217FEC File Offset: 0x002163EC
	public long GetTotalDamage(int monsterId, SkillDamageData data)
	{
		long num = 0L;
		if (data.skillDamageDic == null)
		{
			return num;
		}
		Dictionary<int, List<DamageData>> skillDamageDic = data.skillDamageDic;
		foreach (KeyValuePair<int, List<DamageData>> keyValuePair in skillDamageDic)
		{
			int key = keyValuePair.Key;
			Dictionary<int, List<DamageData>>.Enumerator enumerator;
			KeyValuePair<int, List<DamageData>> keyValuePair2 = enumerator.Current;
			List<DamageData> value = keyValuePair2.Value;
			for (int i = 0; i < value.Count; i++)
			{
				if (monsterId == 0 || key == monsterId)
				{
					num += value[i].damage;
				}
			}
		}
		return num;
	}

	// Token: 0x0600A37F RID: 41855 RVA: 0x00218091 File Offset: 0x00216491
	public void SetTimingFlag(bool isOpen)
	{
		this.timingFlag = isOpen;
	}

	// Token: 0x04005B28 RID: 23336
	private BeActor owner;

	// Token: 0x04005B29 RID: 23337
	private BeScene scene;

	// Token: 0x04005B2A RID: 23338
	private Dictionary<int, List<int>> skillIdDic;

	// Token: 0x04005B2B RID: 23339
	public SkillDamageData skillDamageData;

	// Token: 0x04005B2C RID: 23340
	private List<int> recordMonsterIdList = new List<int>();

	// Token: 0x04005B2D RID: 23341
	private bool timingFlag;

	// Token: 0x04005B2E RID: 23342
	private BeEventHandle onHurtHandle;

	// Token: 0x04005B2F RID: 23343
	private BeEventHandle onSummonHandle;

	// Token: 0x04005B30 RID: 23344
	private BeEventHandle onHurtByAbnormalHandle;

	// Token: 0x04005B31 RID: 23345
	private BeEventHandle onCastSkillHandle;

	// Token: 0x04005B32 RID: 23346
	private BeEventHandle onAreaClearHandle;

	// Token: 0x04005B33 RID: 23347
	private BeEventHandle onSceneMonsterDead;
}
