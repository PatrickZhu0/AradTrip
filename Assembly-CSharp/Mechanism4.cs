using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x020043E6 RID: 17382
public class Mechanism4 : BeMechanism
{
	// Token: 0x060181F6 RID: 98806 RVA: 0x0077FF12 File Offset: 0x0077E312
	public Mechanism4(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060181F7 RID: 98807 RVA: 0x0077FF28 File Offset: 0x0077E328
	public override void OnInit()
	{
		this.buffIdArray = new int[this.data.ValueA.Length];
		for (int i = 0; i < this.data.ValueA.Length; i++)
		{
			this.buffIdArray[i] = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
		}
		for (int j = 0; j < this.data.ValueB.Count; j++)
		{
			int num = TableManager.GetValueFromUnionCell(this.data.ValueB[j], this.level, true);
			num = BeUtility.GetOnlyMonsterID(num);
			if (num > 0)
			{
				this.specifyMonsterIDs.Add(num);
			}
		}
		this.buffInfoIdArray = new int[this.data.ValueC.Length];
		for (int k = 0; k < this.data.ValueC.Length; k++)
		{
			this.buffInfoIdArray[k] = TableManager.GetValueFromUnionCell(this.data.ValueC[k], this.level, true);
		}
		this.notAddToSelf = (TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true) != 0);
		if (this.data.ValueE.Count > 0)
		{
			this.isNeedRefresh = (TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true) != 0);
		}
	}

	// Token: 0x060181F8 RID: 98808 RVA: 0x007800E0 File Offset: 0x0077E4E0
	public override void OnStart()
	{
		if (base.owner != null)
		{
			if (this.isNeedRefresh && base.owner.CurrentBeScene != null)
			{
				List<BeActor> list = ListPool<BeActor>.Get();
				for (int i = 0; i < this.specifyMonsterIDs.Count; i++)
				{
					base.owner.CurrentBeScene.FindMonsterByID(list, this.specifyMonsterIDs[i], false);
					for (int j = 0; j < list.Count; j++)
					{
						BeEntity topOwner = list[j].GetTopOwner(base.owner);
						if (topOwner.GetPID() == base.owner.GetPID())
						{
							for (int k = 0; k < this.buffIdArray.Length; k++)
							{
								list[j].buffController.TryAddBuff(this.buffIdArray[k], -1, this.level);
							}
							for (int l = 0; l < this.buffInfoIdArray.Length; l++)
							{
								if (!this.notAddToSelf)
								{
									list[j].buffController.TryAddBuff(this.buffInfoIdArray[l], null, false, null, 0);
								}
								list[j].buffController.AddTriggerBuff(this.buffInfoIdArray[l], 0);
							}
						}
					}
				}
				ListPool<BeActor>.Release(list);
			}
			this.handleA = base.owner.RegisterEvent(BeEventType.onSummon, delegate(object[] args)
			{
				BeActor beActor = args[0] as BeActor;
				if (beActor != null && (this.specifyMonsterIDs.Count <= 0 || this.specifyMonsterIDs.Contains(beActor.GetEntityData().simpleMonsterID)))
				{
					for (int m = 0; m < this.buffIdArray.Length; m++)
					{
						beActor.buffController.TryAddBuff(this.buffIdArray[m], -1, this.level);
					}
					for (int n = 0; n < this.buffInfoIdArray.Length; n++)
					{
						if (!this.notAddToSelf)
						{
							beActor.buffController.TryAddBuff(this.buffInfoIdArray[n], null, false, null, 0);
						}
						beActor.buffController.AddTriggerBuff(this.buffInfoIdArray[n], 0);
					}
				}
			});
		}
	}

	// Token: 0x04011652 RID: 71250
	private int[] buffIdArray;

	// Token: 0x04011653 RID: 71251
	private int[] buffInfoIdArray;

	// Token: 0x04011654 RID: 71252
	private List<int> specifyMonsterIDs = new List<int>();

	// Token: 0x04011655 RID: 71253
	private bool notAddToSelf;

	// Token: 0x04011656 RID: 71254
	private bool isNeedRefresh;
}
