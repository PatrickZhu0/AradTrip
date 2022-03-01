using System;
using System.Collections.Generic;

// Token: 0x0200431F RID: 17183
public class Mechanism15 : BeMechanism
{
	// Token: 0x06017C67 RID: 97383 RVA: 0x0075704C File Offset: 0x0075544C
	public Mechanism15(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017C68 RID: 97384 RVA: 0x007570B0 File Offset: 0x007554B0
	public override void OnInit()
	{
		this.buffRangeRadius = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.duration = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.triggerBuffInfoID = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.infoData = new BuffInfoData(this.triggerBuffInfoID, 0, 0);
	}

	// Token: 0x06017C69 RID: 97385 RVA: 0x00757148 File Offset: 0x00755548
	public override void OnStart()
	{
	}

	// Token: 0x06017C6A RID: 97386 RVA: 0x0075714A File Offset: 0x0075554A
	public override void OnUpdate(int deltaTime)
	{
		this.UpdateCheckRange(deltaTime, base.owner);
		this.UpdateInRanger(deltaTime);
	}

	// Token: 0x06017C6B RID: 97387 RVA: 0x00757160 File Offset: 0x00755560
	public override void OnFinish()
	{
		for (int i = 0; i < this.inRangers.Count; i++)
		{
			this.OutRangeEffect(this.inRangers[i]);
		}
		this.inRangers.Clear();
	}

	// Token: 0x06017C6C RID: 97388 RVA: 0x007571A6 File Offset: 0x007555A6
	private bool checkCanRemove(Mechanism15.InRangeData item)
	{
		return item.IsFinish();
	}

	// Token: 0x06017C6D RID: 97389 RVA: 0x007571B0 File Offset: 0x007555B0
	public void UpdateInRanger(int delta)
	{
		for (int i = 0; i < this.inRangerUpdater.Count; i++)
		{
			Mechanism15.InRangeData inRangeData = this.inRangerUpdater[i];
			if (inRangeData.IsFinish())
			{
				this.inRangers.Remove(inRangeData.actor);
			}
		}
		this.inRangerUpdater.RemoveAll(new Predicate<Mechanism15.InRangeData>(this.checkCanRemove));
		for (int j = 0; j < this.inRangerUpdater.Count; j++)
		{
			this.inRangerUpdater[j].Update(delta);
		}
	}

	// Token: 0x06017C6E RID: 97390 RVA: 0x00757249 File Offset: 0x00755649
	private bool CheckCanRemove(BeActor item)
	{
		if (item.IsDead() || !this.targets.Contains(item))
		{
			this.OutRangeEffect(item);
			return true;
		}
		return false;
	}

	// Token: 0x06017C6F RID: 97391 RVA: 0x00757274 File Offset: 0x00755674
	public void UpdateCheckRange(int delta, BeActor owner)
	{
		if (owner == null)
		{
			return;
		}
		this.timeAcc += delta;
		if (this.timeAcc >= this.checkInterval)
		{
			this.timeAcc -= this.checkInterval;
			owner.CurrentBeScene.FindTargets(this.targets, owner, VInt.NewVInt(this.buffRangeRadius, GlobalLogic.VALUE_1000), false, null);
			int i;
			for (i = 0; i < this.targets.Count; i++)
			{
				if (!this.inRangers.Contains(this.targets[i]) && this.CanAddTarget(this.targets[i]))
				{
					this.inRangers.Add(this.targets[i]);
					this.targets[i].inBossRange = true;
					Mechanism15.InRangeData inRangeData = this.inRangerUpdater.Find((Mechanism15.InRangeData dataItem) => dataItem.actor == this.targets[i]);
					if (inRangeData == null)
					{
						Mechanism15.InRangeData inRangeData2 = new Mechanism15.InRangeData(this.targets[i], this.duration, new Mechanism15.InRangeCallback(this.InRangeEffect));
						this.inRangerUpdater.Add(inRangeData2);
						inRangeData = inRangeData2;
					}
					else
					{
						inRangeData.reverse = true;
					}
					inRangeData.ShowSpellBar();
				}
			}
			this.inRangers.RemoveAll(new Predicate<BeActor>(this.CheckCanRemove));
		}
	}

	// Token: 0x06017C70 RID: 97392 RVA: 0x0075740C File Offset: 0x0075580C
	public void InRangeEffect(BeActor target)
	{
		if (target != null)
		{
			if (target.buffController.HasBuffByID(this.infoData.buffID) == null)
			{
				target.buffController.TryAddBuff(this.infoData, null, false, default(VRate), null);
			}
			target.inBossRange = false;
		}
	}

	// Token: 0x06017C71 RID: 97393 RVA: 0x00757464 File Offset: 0x00755864
	public void OutRangeEffect(BeActor item)
	{
		item.inBossRange = false;
		Mechanism15.InRangeData inRangeData = this.inRangerUpdater.Find((Mechanism15.InRangeData dataItem) => !dataItem.IsFinish() && dataItem.actor == item);
		if (inRangeData != null)
		{
			item.SetSpellBarReverse(eDungeonCharactorBar.Continue, true);
			this.inRangerUpdater.Remove(inRangeData);
		}
	}

	// Token: 0x06017C72 RID: 97394 RVA: 0x007574C2 File Offset: 0x007558C2
	public bool CanAddTarget(BeActor target)
	{
		return !target.inBossRange && null == target.buffController.HasBuffByID(this.infoData.buffID);
	}

	// Token: 0x0401119D RID: 70045
	private int buffRangeRadius = 2600;

	// Token: 0x0401119E RID: 70046
	private new int duration = 7000;

	// Token: 0x0401119F RID: 70047
	private int triggerBuffInfoID = 500021;

	// Token: 0x040111A0 RID: 70048
	protected const int CHECK_INTERVAL = 200;

	// Token: 0x040111A1 RID: 70049
	protected int timeAcc;

	// Token: 0x040111A2 RID: 70050
	protected int checkInterval = 200;

	// Token: 0x040111A3 RID: 70051
	private BuffInfoData infoData;

	// Token: 0x040111A4 RID: 70052
	protected List<BeActor> inRangers = new List<BeActor>();

	// Token: 0x040111A5 RID: 70053
	protected List<Mechanism15.InRangeData> inRangerUpdater = new List<Mechanism15.InRangeData>();

	// Token: 0x040111A6 RID: 70054
	private List<BeActor> targets = new List<BeActor>();

	// Token: 0x02004320 RID: 17184
	// (Invoke) Token: 0x06017C74 RID: 97396
	public delegate void InRangeCallback(BeActor actor);

	// Token: 0x02004321 RID: 17185
	public class InRangeData
	{
		// Token: 0x06017C77 RID: 97399 RVA: 0x007574F0 File Offset: 0x007558F0
		public InRangeData(BeActor ba, int d, Mechanism15.InRangeCallback act)
		{
			this.actor = ba;
			this.duration = d;
			this.callback = act;
		}

		// Token: 0x06017C78 RID: 97400 RVA: 0x0075750D File Offset: 0x0075590D
		public void ShowSpellBar()
		{
			this.actor.StartSpellBar(eDungeonCharactorBar.Continue, this.duration, true, "冰冻", false);
			this.timeAcc = this.actor.GetSpellBarDuration(eDungeonCharactorBar.Continue);
		}

		// Token: 0x06017C79 RID: 97401 RVA: 0x0075753C File Offset: 0x0075593C
		public void Update(int delta)
		{
			if (this.finish)
			{
				return;
			}
			if (this.reverse)
			{
				this.timeAcc -= delta;
			}
			else
			{
				this.timeAcc += delta;
			}
			if (!this.reverse && this.timeAcc >= this.duration)
			{
				this.timeAcc -= this.duration;
				if (this.callback != null)
				{
					this.callback(this.actor);
				}
				this.finish = true;
			}
			if (this.reverse && this.timeAcc <= 0)
			{
				this.finish = true;
			}
		}

		// Token: 0x06017C7A RID: 97402 RVA: 0x007575F1 File Offset: 0x007559F1
		public bool IsFinish()
		{
			return this.finish;
		}

		// Token: 0x040111A7 RID: 70055
		public BeActor actor;

		// Token: 0x040111A8 RID: 70056
		public int duration;

		// Token: 0x040111A9 RID: 70057
		private int timeAcc;

		// Token: 0x040111AA RID: 70058
		public Mechanism15.InRangeCallback callback;

		// Token: 0x040111AB RID: 70059
		private bool finish;

		// Token: 0x040111AC RID: 70060
		public bool reverse;
	}
}
