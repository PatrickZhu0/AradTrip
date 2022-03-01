using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x0200430C RID: 17164
internal class Mechanism134 : BeMechanism
{
	// Token: 0x06017BF7 RID: 97271 RVA: 0x0075360F File Offset: 0x00751A0F
	public Mechanism134(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017BF8 RID: 97272 RVA: 0x00753624 File Offset: 0x00751A24
	public override void OnInit()
	{
		this.interval = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.buffInfoArray = new int[this.data.ValueB.Length];
		for (int i = 0; i < this.data.ValueB.Length; i++)
		{
			this.buffInfoArray[i] = TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
		}
	}

	// Token: 0x06017BF9 RID: 97273 RVA: 0x007536BF File Offset: 0x00751ABF
	public override void OnStart()
	{
		this.timer = 0;
	}

	// Token: 0x06017BFA RID: 97274 RVA: 0x007536C8 File Offset: 0x00751AC8
	public override void OnUpdate(int deltaTime)
	{
		this.timer += deltaTime;
		if (this.timer >= this.interval)
		{
			this.timer -= this.interval;
			this.AddBuffInfoToMonsters();
		}
	}

	// Token: 0x06017BFB RID: 97275 RVA: 0x00753704 File Offset: 0x00751B04
	private void AddBuffInfoToMonsters()
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindTargets(list, base.owner, VInt.Float2VIntValue(100f), false, null);
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] != null && !list[i].IsDead() && !this.targetList.Contains(list[i]))
			{
				for (int j = 0; j < this.buffInfoArray.Length; j++)
				{
					list[i].buffController.TryAddBuff(this.buffInfoArray[j], base.owner, false, null, 0);
				}
				this.targetList.Add(list[i]);
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x06017BFC RID: 97276 RVA: 0x007537E0 File Offset: 0x00751BE0
	public override void OnFinish()
	{
		for (int i = 0; i < this.targetList.Count; i++)
		{
			for (int j = 0; j < this.buffInfoArray.Length; j++)
			{
				this.targetList[i].buffController.RemoveBuffByBuffInfoID(this.buffInfoArray[j]);
			}
		}
		this.targetList.Clear();
	}

	// Token: 0x04011136 RID: 69942
	private int interval;

	// Token: 0x04011137 RID: 69943
	private int[] buffInfoArray;

	// Token: 0x04011138 RID: 69944
	private int timer;

	// Token: 0x04011139 RID: 69945
	private List<BeActor> targetList = new List<BeActor>();
}
