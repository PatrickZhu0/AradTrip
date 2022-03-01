using System;
using System.Collections.Generic;

// Token: 0x0200426A RID: 17002
public class Mechanism1033 : BeMechanism
{
	// Token: 0x06017874 RID: 96372 RVA: 0x0073D27C File Offset: 0x0073B67C
	public Mechanism1033(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017875 RID: 96373 RVA: 0x0073D2DC File Offset: 0x0073B6DC
	public override void OnInit()
	{
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			Mechanism1033.BeHitData item = default(Mechanism1033.BeHitData);
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
			item.skillId = valueFromUnionCell;
			if (i < this.data.ValueB.Count)
			{
				item.addRate = TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
			}
			this.beHitDataList.Add(item);
			this.skillIdList.Add(valueFromUnionCell);
		}
		this.entityId = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.reduceValue = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		this.summonTimeAcc = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		this.summonMonsterId = TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true);
		for (int j = 0; j < this.data.ValueH.Count; j++)
		{
			this.buffInfoIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueH[j], this.level, true));
		}
	}

	// Token: 0x06017876 RID: 96374 RVA: 0x0073D484 File Offset: 0x0073B884
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onHitAfterAddBuff, new BeEventHandle.Del(this.AddHurtValue));
		this.handleB = base.owner.RegisterEvent(BeEventType.onMagicGirlMonsterChange, new BeEventHandle.Del(this.RegisterMagicGirlChange));
	}

	// Token: 0x06017877 RID: 96375 RVA: 0x0073D4D8 File Offset: 0x0073B8D8
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		this.UpdateReduce(deltaTime);
		this.UpdateSummon(deltaTime);
	}

	// Token: 0x06017878 RID: 96376 RVA: 0x0073D4EF File Offset: 0x0073B8EF
	public override void OnFinish()
	{
		base.OnFinish();
		this.RemoveSpellBar();
	}

	// Token: 0x06017879 RID: 96377 RVA: 0x0073D500 File Offset: 0x0073B900
	private void UpdateReduce(int deltaTime)
	{
		if (this.curTimeAcc < this.timeAcc)
		{
			this.curTimeAcc += deltaTime;
			return;
		}
		this.curTimeAcc = 0;
		this.curHurtValue -= this.reduceValue;
		if (this.curHurtValue <= 0)
		{
			base.owner.buffController.RemoveBuff(this.attachBuff);
		}
		else
		{
			this.RefreshEnergrUI(-this.reduceValue);
		}
	}

	// Token: 0x0601787A RID: 96378 RVA: 0x0073D57C File Offset: 0x0073B97C
	private void UpdateSummon(int deltaTime)
	{
		if (this.summonMonsterId == 0)
		{
			return;
		}
		if (!this.needSummonUpdate)
		{
			return;
		}
		if (this.curSummonTime >= this.summonTimeAcc)
		{
			this.curSummonTime = 0;
			if (this.attachBuff != null && this.attachBuff.releaser != null)
			{
				this.CreateMonster();
			}
		}
		else
		{
			this.curSummonTime += deltaTime;
		}
	}

	// Token: 0x0601787B RID: 96379 RVA: 0x0073D5F0 File Offset: 0x0073B9F0
	private void AddHurtValue(object[] args)
	{
		int num = (int)args[3];
		if (!this.skillIdList.Contains(num))
		{
			return;
		}
		if (this.curHurtValue >= 1000)
		{
			return;
		}
		int addRateById = this.GetAddRateById(num);
		this.curHurtValue += addRateById;
		this.RefreshEnergrUI(this.curHurtValue);
		if (this.curHurtValue >= this.maxHurtValue)
		{
			BeActor attacker = args[2] as BeActor;
			this.AddEntity(attacker);
			this.AddBuffInfo();
			this.EneryFull();
		}
	}

	// Token: 0x0601787C RID: 96380 RVA: 0x0073D678 File Offset: 0x0073BA78
	private void EneryFull()
	{
		if (this.summonMonsterId != 0)
		{
			this.needSummonUpdate = true;
			this.CreateMonster();
		}
		else
		{
			this.ResetDamgeRecord();
			this.RemoveSpellBar();
		}
	}

	// Token: 0x0601787D RID: 96381 RVA: 0x0073D6A3 File Offset: 0x0073BAA3
	private void AddEntity(BeActor attacker)
	{
		if (this.entityId == 0)
		{
			return;
		}
		if (attacker == null)
		{
			return;
		}
		attacker.AddEntity(this.entityId, base.owner.GetPosition(), 1, 0);
	}

	// Token: 0x0601787E RID: 96382 RVA: 0x0073D6D4 File Offset: 0x0073BAD4
	private void AddBuffInfo()
	{
		if (this.buffInfoIdList.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < this.buffInfoIdList.Count; i++)
		{
			BeActor releaser = null;
			if (this.attachBuff != null)
			{
				releaser = this.attachBuff.releaser;
			}
			base.owner.buffController.TryAddBuff(this.buffInfoIdList[i], null, false, releaser, 0);
		}
	}

	// Token: 0x0601787F RID: 96383 RVA: 0x0073D749 File Offset: 0x0073BB49
	private void RegisterMagicGirlChange(object[] args)
	{
		if (this.attachBuff != null)
		{
			this.attachBuff.Finish();
		}
	}

	// Token: 0x06017880 RID: 96384 RVA: 0x0073D764 File Offset: 0x0073BB64
	private void CreateMonster()
	{
		if (this.attachBuff != null && this.attachBuff.releaser != null)
		{
			int level = this.attachBuff.releaser.GetEntityData().level;
			int monsterID = base.owner.GenNewMonsterID(this.summonMonsterId, level);
			this.attachBuff.releaser.CurrentBeScene.SummonMonster(monsterID, base.owner.GetPosition(), this.attachBuff.releaser.GetCamp(), null, false, 0, true, 0, false, false);
		}
	}

	// Token: 0x06017881 RID: 96385 RVA: 0x0073D7F4 File Offset: 0x0073BBF4
	private int GetAddRateById(int skillId)
	{
		for (int i = 0; i < this.beHitDataList.Count; i++)
		{
			if (this.beHitDataList[i].skillId == skillId)
			{
				return this.beHitDataList[i].addRate;
			}
		}
		return 0;
	}

	// Token: 0x06017882 RID: 96386 RVA: 0x0073D84D File Offset: 0x0073BC4D
	private void ResetDamgeRecord()
	{
		this.curTimeAcc = 0;
		this.curHurtValue = 0;
	}

	// Token: 0x06017883 RID: 96387 RVA: 0x0073D860 File Offset: 0x0073BC60
	protected void RefreshEnergrUI(int value)
	{
		int spellBarDuration = base.owner.GetSpellBarDuration(eDungeonCharactorBar.MonsterEnergyBar);
		if (spellBarDuration <= 0)
		{
			string text = string.Empty;
			if (this.data.StringValueA.Count > 0)
			{
				text = this.data.StringValueA[0];
			}
			SpellBar spellBar = base.owner.StartSpellBar(eDungeonCharactorBar.MonsterEnergyBar, this.maxHurtValue, true, text, false);
			spellBar.autoAcc = false;
			spellBar.reverse = false;
			spellBar.autodelete = false;
		}
		base.owner.AddSpellBarProgress(eDungeonCharactorBar.MonsterEnergyBar, new VFactor((long)value, 1000L));
	}

	// Token: 0x06017884 RID: 96388 RVA: 0x0073D8F8 File Offset: 0x0073BCF8
	private void RemoveSpellBar()
	{
		base.owner.StopSpellBar(eDungeonCharactorBar.MonsterEnergyBar, true);
	}

	// Token: 0x04010E7D RID: 69245
	private List<Mechanism1033.BeHitData> beHitDataList = new List<Mechanism1033.BeHitData>();

	// Token: 0x04010E7E RID: 69246
	private List<int> skillIdList = new List<int>();

	// Token: 0x04010E7F RID: 69247
	private int entityId;

	// Token: 0x04010E80 RID: 69248
	private int curHurtValue;

	// Token: 0x04010E81 RID: 69249
	private int maxHurtValue = 1000;

	// Token: 0x04010E82 RID: 69250
	private List<int> buffInfoIdList = new List<int>();

	// Token: 0x04010E83 RID: 69251
	private int reduceValue = 1;

	// Token: 0x04010E84 RID: 69252
	private int curTimeAcc;

	// Token: 0x04010E85 RID: 69253
	private int timeAcc = 1000;

	// Token: 0x04010E86 RID: 69254
	protected SpellBar spellBar;

	// Token: 0x04010E87 RID: 69255
	private int summonTimeAcc = 2000;

	// Token: 0x04010E88 RID: 69256
	private int curSummonTime;

	// Token: 0x04010E89 RID: 69257
	private int summonMonsterId;

	// Token: 0x04010E8A RID: 69258
	private bool needSummonUpdate;

	// Token: 0x0200426B RID: 17003
	private struct BeHitData
	{
		// Token: 0x04010E8B RID: 69259
		public int skillId;

		// Token: 0x04010E8C RID: 69260
		public int addRate;
	}
}
