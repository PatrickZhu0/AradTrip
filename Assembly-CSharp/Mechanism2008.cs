using System;
using System.Collections.Generic;

// Token: 0x0200433E RID: 17214
public class Mechanism2008 : BeMechanism
{
	// Token: 0x06017D2F RID: 97583 RVA: 0x0075C380 File Offset: 0x0075A780
	public Mechanism2008(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017D30 RID: 97584 RVA: 0x0075C408 File Offset: 0x0075A808
	public override void OnInit()
	{
		base.OnInit();
		this.totalDamage = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.time = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x06017D31 RID: 97585 RVA: 0x0075C46C File Offset: 0x0075A86C
	public override void OnStart()
	{
		base.OnStart();
		for (int i = 0; i < this.monsterIDs.Length; i++)
		{
			int num = i;
			this.FindMonster(this.monsterIDs[num], num);
		}
		this.boss = base.owner.CurrentBeScene.FindMonsterByID(this.bossID);
		this.flag = true;
		this.tmplist.AddRange(this.actorList);
	}

	// Token: 0x06017D32 RID: 97586 RVA: 0x0075C4E0 File Offset: 0x0075A8E0
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (!this.flag)
		{
			return;
		}
		this.timer += deltaTime;
		if (this.timer >= this.time)
		{
			this.timer = 0;
			BeActor beActor = this.SelectTarget();
			if (beActor != null)
			{
				this.AddBuff(beActor);
			}
		}
	}

	// Token: 0x06017D33 RID: 97587 RVA: 0x0075C53C File Offset: 0x0075A93C
	private void AddBuff(BeActor actor)
	{
		for (int i = 0; i < this.monsterIDs.Length; i++)
		{
			if (actor.GetEntityData().MonsterIDEqual(this.monsterIDs[i]))
			{
				actor.buffController.TryAddBuff(this.buffIDs[i], -1, 1);
			}
		}
	}

	// Token: 0x06017D34 RID: 97588 RVA: 0x0075C590 File Offset: 0x0075A990
	private BeActor SelectTarget()
	{
		int index = base.owner.FrameRandom.InRange(0, this.tmplist.Count);
		BeActor beActor = this.tmplist[index];
		this.tmplist.Remove(beActor);
		if (this.HaveBuff(beActor))
		{
			return this.SelectTarget();
		}
		if (this.tmplist.Count <= 0)
		{
			if (this.boss != null)
			{
				this.boss.buffController.TryAddBuff(this.buffID, -1, 1);
			}
			this.tmplist.AddRange(this.actorList);
			this.flag = false;
		}
		return beActor;
	}

	// Token: 0x06017D35 RID: 97589 RVA: 0x0075C638 File Offset: 0x0075AA38
	private bool HaveBuff(BeActor actor)
	{
		for (int i = 0; i < this.buffIDs.Length; i++)
		{
			if (actor.buffController.HasBuffByID(this.buffIDs[i]) != null)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06017D36 RID: 97590 RVA: 0x0075C67C File Offset: 0x0075AA7C
	private void FindMonster(int id, int index)
	{
		BeActor beActor = base.owner.CurrentBeScene.FindMonsterByID(id);
		if (beActor != null)
		{
			this.actorList.Add(beActor);
			this.RegistDamageEvent(beActor, index);
		}
	}

	// Token: 0x06017D37 RID: 97591 RVA: 0x0075C6B8 File Offset: 0x0075AAB8
	private void RegistDamageEvent(BeActor actor, int index)
	{
		BeEventHandle item = actor.RegisterEvent(BeEventType.onHit, delegate(object[] args)
		{
			int num = (int)args[0];
			this.calcDamage[index] += num;
			if (this.calcDamage[index] >= this.totalDamage)
			{
				this.ClearAllChain();
			}
		});
		this.handleList.Add(item);
	}

	// Token: 0x06017D38 RID: 97592 RVA: 0x0075C6FC File Offset: 0x0075AAFC
	private void ClearAllChain()
	{
		this.timer = 0;
		this.flag = true;
		if (this.boss != null)
		{
			this.boss.buffController.RemoveBuff(this.buffID, 0, 0);
		}
		this.tmplist.Clear();
		this.tmplist.AddRange(this.actorList);
		for (int i = 0; i < this.calcDamage.Length; i++)
		{
			this.calcDamage[i] = 0;
		}
		for (int j = 0; j < this.actorList.Count; j++)
		{
			BeActor beActor = this.actorList[j];
			if (beActor != null && !beActor.IsDead())
			{
				for (int k = 0; k < this.buffIDs.Length; k++)
				{
					beActor.buffController.RemoveBuff(this.buffIDs[k], 0, 0);
				}
			}
		}
	}

	// Token: 0x06017D39 RID: 97593 RVA: 0x0075C7E0 File Offset: 0x0075ABE0
	public override void OnFinish()
	{
		base.OnFinish();
		for (int i = 0; i < this.handleList.Count; i++)
		{
			if (this.handleList[i] != null)
			{
				this.handleList[i].Remove();
				this.handleList[i] = null;
			}
		}
		this.handleList.Clear();
	}

	// Token: 0x04011251 RID: 70225
	private int[] monsterIDs = new int[]
	{
		30830011,
		30840011,
		30850011,
		30860011
	};

	// Token: 0x04011252 RID: 70226
	private int[] buffIDs = new int[]
	{
		521736,
		521737,
		521738,
		521739
	};

	// Token: 0x04011253 RID: 70227
	private int[] calcDamage = new int[4];

	// Token: 0x04011254 RID: 70228
	private int bossID = 30770021;

	// Token: 0x04011255 RID: 70229
	private int buffID = 521740;

	// Token: 0x04011256 RID: 70230
	private int totalDamage;

	// Token: 0x04011257 RID: 70231
	private int time;

	// Token: 0x04011258 RID: 70232
	private List<BeEventHandle> handleList = new List<BeEventHandle>();

	// Token: 0x04011259 RID: 70233
	private List<BeActor> actorList = new List<BeActor>();

	// Token: 0x0401125A RID: 70234
	private BeActor boss;

	// Token: 0x0401125B RID: 70235
	private List<BeActor> tmplist = new List<BeActor>();

	// Token: 0x0401125C RID: 70236
	private int timer;

	// Token: 0x0401125D RID: 70237
	private bool flag;
}
