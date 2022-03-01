using System;
using System.Collections.Generic;

// Token: 0x02004259 RID: 16985
public class Mechanism1018 : BeMechanism
{
	// Token: 0x06017806 RID: 96262 RVA: 0x0073AE8F File Offset: 0x0073928F
	public Mechanism1018(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017807 RID: 96263 RVA: 0x0073AEBC File Offset: 0x007392BC
	public override void OnInit()
	{
		base.OnInit();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.monsterTypeListPveList.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
		for (int j = 0; j < this.data.ValueB.Count; j++)
		{
			this.buffTimeList.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[j], this.level, true));
		}
		for (int k = 0; k < this.data.ValueC.Count; k++)
		{
			this.buffAddRateList.Add(TableManager.GetValueFromUnionCell(this.data.ValueC[k], this.level, true));
		}
		this.buffInfoId = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
	}

	// Token: 0x06017808 RID: 96264 RVA: 0x0073AFE1 File Offset: 0x007393E1
	public override void OnStart()
	{
		base.OnStart();
		this.SetEquipAdd();
		this.handleA = base.owner.RegisterEvent(BeEventType.onHitOther, delegate(object[] args)
		{
			BeActor target = (BeActor)args[0];
			this.AddBuff(target);
		});
	}

	// Token: 0x06017809 RID: 96265 RVA: 0x0073B010 File Offset: 0x00739410
	private void AddBuff(BeActor target)
	{
		if (target == null || target.IsDead())
		{
			return;
		}
		int monsterType = target.GetEntityData().type;
		int num = this.monsterTypeListPveList.FindIndex((int x) => x == monsterType);
		if (num == -1)
		{
			return;
		}
		BuffInfoData buffInfoData = new BuffInfoData(this.buffInfoId, 0, 0);
		buffInfoData.duration = this.buffTimeList[num];
		buffInfoData.prob = this.buffAddRateList[num];
		target.buffController.TryAddBuff(buffInfoData, null, false, default(VRate), base.GetAttachBuffReleaser());
	}

	// Token: 0x0601780A RID: 96266 RVA: 0x0073B0C0 File Offset: 0x007394C0
	private void SetEquipAdd()
	{
		List<BeMechanism> mechanismList = base.owner.MechanismList;
		if (mechanismList == null)
		{
			return;
		}
		for (int i = 0; i < mechanismList.Count; i++)
		{
			Mechanism2025 mechanism = mechanismList[i] as Mechanism2025;
			if (mechanism != null)
			{
				for (int j = 0; j < this.buffAddRateList.Count; j++)
				{
					List<int> list;
					int index;
					(list = this.buffAddRateList)[index = j] = list[index] + mechanism.addRate;
				}
				for (int k = 0; k < this.buffTimeList.Count; k++)
				{
					List<int> list;
					int index2;
					(list = this.buffTimeList)[index2 = k] = list[index2] + mechanism.addBuffTime;
				}
			}
		}
	}

	// Token: 0x04010E42 RID: 69186
	private List<int> monsterTypeListPveList = new List<int>();

	// Token: 0x04010E43 RID: 69187
	private List<int> buffTimeList = new List<int>();

	// Token: 0x04010E44 RID: 69188
	private List<int> buffAddRateList = new List<int>();

	// Token: 0x04010E45 RID: 69189
	private int buffInfoId;
}
