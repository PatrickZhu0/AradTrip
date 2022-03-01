using System;
using System.Collections.Generic;

// Token: 0x02004349 RID: 17225
public class Mechanism2019 : BeMechanism
{
	// Token: 0x06017D8E RID: 97678 RVA: 0x0075EAD4 File Offset: 0x0075CED4
	public Mechanism2019(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017D8F RID: 97679 RVA: 0x0075EB14 File Offset: 0x0075CF14
	public override void OnInit()
	{
		base.OnInit();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.buffInfoList.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
		for (int j = 0; j < this.data.ValueB.Count; j++)
		{
			this.fakeRebornBuffList.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[j], this.level, true));
		}
		this.invincibleBuffTime = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.m_CanNotAttackBuffTime = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
	}

	// Token: 0x06017D90 RID: 97680 RVA: 0x0075EC13 File Offset: 0x0075D013
	public override void OnStart()
	{
		base.OnStart();
		this.AddBuffInfo(true);
		this.SetEquipDataAdd();
		this.handleB = base.owner.RegisterEvent(BeEventType.onHPChange, delegate(object[] args)
		{
			if (base.owner.GetEntityData().GetHP() <= 0)
			{
				this.FakeReborn();
			}
		});
	}

	// Token: 0x06017D91 RID: 97681 RVA: 0x0075EC47 File Offset: 0x0075D047
	public override void OnFinish()
	{
		base.OnFinish();
		this.AddBuffInfo(false);
	}

	// Token: 0x06017D92 RID: 97682 RVA: 0x0075EC58 File Offset: 0x0075D058
	private void AddBuffInfo(bool isAdd)
	{
		for (int i = 0; i < this.buffInfoList.Count; i++)
		{
			if (isAdd)
			{
				int num = this.buffInfoList[i];
				BuffInfoData buffInfoData = new BuffInfoData(num, this.level, 0);
				if (this.buffInfoRadiusAddDic.ContainsKey(num))
				{
					BuffInfoData buffInfoData2 = buffInfoData;
					buffInfoData2.buffTargetRangeRadius += this.buffInfoRadiusAddDic[num];
				}
				base.owner.buffController.TryAddBuff(buffInfoData, null, false, default(VRate), base.GetAttachBuffReleaser());
			}
			else
			{
				base.owner.buffController.RemoveBuffByBuffInfoID(this.buffInfoList[i]);
			}
		}
	}

	// Token: 0x06017D93 RID: 97683 RVA: 0x0075ED20 File Offset: 0x0075D120
	private void FakeReborn()
	{
		if (base.owner == null || base.owner.GetEntityData() == null)
		{
			return;
		}
		base.owner.TriggerEvent(BeEventType.OnFakeReborn, new object[]
		{
			base.owner
		});
		base.owner.buffController.RemoveAllAbnormalBuff();
		base.owner.GetEntityData().SetHP(1);
		base.owner.SetIsDead(false);
		for (int i = 0; i < this.fakeRebornBuffList.Count; i++)
		{
			BuffInfoData info = new BuffInfoData(this.fakeRebornBuffList[i], this.level, 0);
			base.owner.buffController.TryAddBuff(info, null, false, default(VRate), base.GetAttachBuffReleaser());
		}
		if (this.m_CanNotAttackBuffTime != 0)
		{
			base.owner.buffController.TryAddBuff(this.m_CanNotAttackBuffId, this.m_CanNotAttackBuffTime, 1);
		}
		base.owner.buffController.TryAddBuff(43, this.invincibleBuffTime, 1);
		BeStateData rkData = new BeStateData(14, 10002);
		base.owner.sgForceSwitchState(rkData);
		if (this.attachBuff != null)
		{
			base.owner.buffController.RemoveBuff(this.attachBuff);
		}
	}

	// Token: 0x06017D94 RID: 97684 RVA: 0x0075EE70 File Offset: 0x0075D270
	private void SetEquipDataAdd()
	{
		BeActor attachBuffReleaser = base.GetAttachBuffReleaser();
		if (attachBuffReleaser == null)
		{
			return;
		}
		List<BeMechanism> mechanismList = attachBuffReleaser.MechanismList;
		for (int i = 0; i < mechanismList.Count; i++)
		{
			Mechanism2028 mechanism = mechanismList[i] as Mechanism2028;
			if (mechanism != null)
			{
				for (int j = 0; j < mechanism.impactBuffInfoList.Count; j++)
				{
					int num = mechanism.impactBuffInfoList[j];
					int num2 = mechanism.buffInfoRadiusAddRateList[j];
					if (!this.buffInfoRadiusAddDic.ContainsKey(num))
					{
						this.buffInfoRadiusAddDic.Add(num, num2);
					}
					else
					{
						Dictionary<int, int> dictionary;
						int key;
						(dictionary = this.buffInfoRadiusAddDic)[key = num] = dictionary[key] + num2;
					}
				}
			}
		}
	}

	// Token: 0x04011290 RID: 70288
	private List<int> buffInfoList = new List<int>();

	// Token: 0x04011291 RID: 70289
	private List<int> fakeRebornBuffList = new List<int>();

	// Token: 0x04011292 RID: 70290
	private int invincibleBuffTime = 5000;

	// Token: 0x04011293 RID: 70291
	private int m_CanNotAttackBuffId = 101;

	// Token: 0x04011294 RID: 70292
	private int m_CanNotAttackBuffTime;

	// Token: 0x04011295 RID: 70293
	private Dictionary<int, int> buffInfoRadiusAddDic = new Dictionary<int, int>();
}
