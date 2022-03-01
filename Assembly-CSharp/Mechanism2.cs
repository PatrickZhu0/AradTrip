using System;
using System.Collections.Generic;

// Token: 0x02004331 RID: 17201
public class Mechanism2 : BeMechanism
{
	// Token: 0x06017CC5 RID: 97477 RVA: 0x007592A6 File Offset: 0x007576A6
	public Mechanism2(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017CC6 RID: 97478 RVA: 0x007592BC File Offset: 0x007576BC
	public override void OnInit()
	{
		this.addFixTime = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.addPercentTime = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		for (int i = 0; i < this.data.ValueC.Count; i++)
		{
			int num = TableManager.GetValueFromUnionCell(this.data.ValueC[i], this.level, true);
			num = BeUtility.GetOnlyMonsterID(num);
			if (num > 0)
			{
				this.specifyMonsterIDs.Add(num);
			}
		}
		if (this.data.ValueD.Count > 0 && TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true) == 1)
		{
			this.relateByLevel = true;
		}
	}

	// Token: 0x06017CC7 RID: 97479 RVA: 0x007593BC File Offset: 0x007577BC
	public override void OnStart()
	{
		if (base.owner != null)
		{
			this.handleA = base.owner.RegisterEvent(BeEventType.onChangeSummonLifeTime, delegate(object[] args)
			{
				BeActor beActor = args[0] as BeActor;
				if (beActor != null && (this.specifyMonsterIDs.Count <= 0 || this.specifyMonsterIDs.Contains(beActor.GetEntityData().simpleMonsterID)))
				{
					int[] array = (int[])args[1];
					if (array[0] != 0)
					{
						array[0] += ((!this.relateByLevel) ? this.addFixTime : (this.level * this.addFixTime));
						array[1] += ((!this.relateByLevel) ? this.addPercentTime : (this.level * this.addPercentTime));
					}
				}
			});
		}
	}

	// Token: 0x040111ED RID: 70125
	private int addFixTime;

	// Token: 0x040111EE RID: 70126
	private int addPercentTime;

	// Token: 0x040111EF RID: 70127
	private List<int> specifyMonsterIDs = new List<int>();

	// Token: 0x040111F0 RID: 70128
	private bool relateByLevel;
}
