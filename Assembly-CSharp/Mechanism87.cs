using System;
using System.Collections.Generic;

// Token: 0x02004419 RID: 17433
public class Mechanism87 : BeMechanism
{
	// Token: 0x06018362 RID: 99170 RVA: 0x0078A19D File Offset: 0x0078859D
	public Mechanism87(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06018363 RID: 99171 RVA: 0x0078A1C0 File Offset: 0x007885C0
	public override void OnInit()
	{
		base.OnInit();
		this.monsterID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.buffInfoID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.batiInfoID = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x06018364 RID: 99172 RVA: 0x0078A24C File Offset: 0x0078864C
	public override void OnStart()
	{
		base.OnStart();
		base.owner.CurrentBeScene.FindMonsterByID(this.monsterList, this.monsterID, true);
		for (int i = 0; i < this.monsterList.Count; i++)
		{
			BeEventHandle item = this.monsterList[i].RegisterEvent(BeEventType.onAfterDead, delegate(object[] args)
			{
				this.AddBuff();
			});
			this.handleList.Add(item);
		}
	}

	// Token: 0x06018365 RID: 99173 RVA: 0x0078A2C8 File Offset: 0x007886C8
	private void AddBuff()
	{
		base.owner.CurrentBeScene.FindMonsterByID(this.monsterList, this.monsterID, true);
		if (this.monsterList.Count == 1)
		{
			this.monsterList[0].buffController.TryAddBuff(this.batiInfoID, null, false, null, 0);
		}
		else
		{
			for (int i = 0; i < this.monsterList.Count; i++)
			{
				this.monsterList[i].buffController.TryAddBuff(this.buffInfoID, null, false, null, 0);
			}
		}
	}

	// Token: 0x06018366 RID: 99174 RVA: 0x0078A368 File Offset: 0x00788768
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

	// Token: 0x040117A2 RID: 71586
	private int monsterID;

	// Token: 0x040117A3 RID: 71587
	private int buffInfoID;

	// Token: 0x040117A4 RID: 71588
	private int batiInfoID;

	// Token: 0x040117A5 RID: 71589
	private List<BeActor> monsterList = new List<BeActor>();

	// Token: 0x040117A6 RID: 71590
	private List<BeEventHandle> handleList = new List<BeEventHandle>();
}
