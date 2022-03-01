using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x0200437D RID: 17277
public class Mechanism2071 : BeMechanism
{
	// Token: 0x06017F31 RID: 98097 RVA: 0x0076ACFC File Offset: 0x007690FC
	public Mechanism2071(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017F32 RID: 98098 RVA: 0x0076AD50 File Offset: 0x00769150
	public override void OnInit()
	{
		if (this.calcuSkillIdList == null)
		{
			this.calcuSkillIdList = new List<int>();
		}
		else
		{
			this.calcuSkillIdList.Clear();
		}
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.calcuSkillIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
		if (this.gainSkillIdList == null)
		{
			this.gainSkillIdList = new List<int>();
		}
		else
		{
			this.gainSkillIdList.Clear();
		}
		for (int j = 0; j < this.data.ValueB.Count; j++)
		{
			this.gainSkillIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[j], this.level, true));
		}
		this.calcuNum = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.overLoadBuffId = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		this.skillIdBuffInfoIdDic.Clear();
		int num = Math.Min(this.data.ValueB.Count, this.data.ValueE.Count);
		for (int k = 0; k < num; k++)
		{
			this.skillIdBuffInfoIdDic.Add(this.gainSkillIdList[k], TableManager.GetValueFromUnionCell(this.data.ValueE[k], this.level, true));
		}
		this.skillIdBuffIdDic.Clear();
		num = Math.Min(this.data.ValueB.Count, this.data.ValueF.Count);
		for (int l = 0; l < num; l++)
		{
			this.skillIdBuffIdDic.Add(this.gainSkillIdList[l], TableManager.GetValueFromUnionCell(this.data.ValueF[l], this.level, true));
		}
	}

	// Token: 0x06017F33 RID: 98099 RVA: 0x0076AF93 File Offset: 0x00769393
	public override void OnStart()
	{
		this.useSkillTimes = 0;
		this.addDamageSkillId.Clear();
		this.useSkillHandle = base.owner.RegisterEvent(BeEventType.onCastSkill, new BeEventHandle.Del(this.OnCastSkillEvent));
		this.InitNvDaQiangEnergyBar(this.calcuNum);
	}

	// Token: 0x06017F34 RID: 98100 RVA: 0x0076AFD2 File Offset: 0x007693D2
	public override void OnUpdate(int deltaTime)
	{
		if (this.unInitUI)
		{
			this.InitUITimer += deltaTime;
			if (this.InitUITimer >= 1000)
			{
				this.InitUITimer = 0;
				this.InitNvDaQiangEnergyBar(this.calcuNum);
			}
		}
	}

	// Token: 0x06017F35 RID: 98101 RVA: 0x0076B010 File Offset: 0x00769410
	public override void OnFinish()
	{
		this.useSkillTimes = 0;
		this.addDamageSkillId.Clear();
		if (this.useSkillHandle != null)
		{
			this.useSkillHandle.Remove();
			this.useSkillHandle = null;
		}
	}

	// Token: 0x06017F36 RID: 98102 RVA: 0x0076B044 File Offset: 0x00769444
	private void OnCastSkillEvent(object[] args)
	{
		if (args != null && args.Length > 0)
		{
			int num = (int)args[0];
			if (this.addDamageSkillId.Contains(num))
			{
				if (this.skillIdBuffIdDic.ContainsKey(num))
				{
					base.owner.buffController.RemoveBuff(this.skillIdBuffIdDic[num], 0, 0);
				}
				this.addDamageSkillId.Remove(num);
			}
			if (this.useSkillTimes >= this.calcuNum && this.gainSkillIdList.Contains(num))
			{
				this.addDamageSkillId.Add(num);
				this.useSkillTimes = 0;
				this.SetNvDaQiangEnergyBar(this.useSkillTimes);
				base.owner.buffController.RemoveBuff(this.overLoadBuffId, 0, 0);
				if (this.skillIdBuffInfoIdDic.ContainsKey(num))
				{
					base.owner.buffController.TryAddBuffInfo(this.skillIdBuffInfoIdDic[num], base.owner, this.level);
				}
				return;
			}
			if (this.calcuSkillIdList.Contains(num))
			{
				this.useSkillTimes++;
				this.SetNvDaQiangEnergyBar(this.useSkillTimes);
				if (this.useSkillTimes >= this.calcuNum)
				{
					base.owner.buffController.TryAddBuff(this.overLoadBuffId, -1, this.level);
				}
			}
		}
	}

	// Token: 0x06017F37 RID: 98103 RVA: 0x0076B1B0 File Offset: 0x007695B0
	private void InitNvDaQiangEnergyBar(int n)
	{
		if (!this.unInitUI)
		{
			return;
		}
		if (base.owner != null && base.owner.isLocalActor)
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				clientSystemBattle.InitNvDaQiangEnergyBar(n);
				this.unInitUI = false;
			}
		}
	}

	// Token: 0x06017F38 RID: 98104 RVA: 0x0076B208 File Offset: 0x00769608
	private void SetNvDaQiangEnergyBar(int times)
	{
		if (this.unInitUI)
		{
			return;
		}
		if (base.owner != null && base.owner.isLocalActor)
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				clientSystemBattle.SetNvDaQiangEnergyBar(times);
			}
		}
	}

	// Token: 0x040113E5 RID: 70629
	private List<int> calcuSkillIdList = new List<int>();

	// Token: 0x040113E6 RID: 70630
	private List<int> gainSkillIdList = new List<int>();

	// Token: 0x040113E7 RID: 70631
	private Dictionary<int, int> skillIdBuffInfoIdDic = new Dictionary<int, int>();

	// Token: 0x040113E8 RID: 70632
	private Dictionary<int, int> skillIdBuffIdDic = new Dictionary<int, int>();

	// Token: 0x040113E9 RID: 70633
	private int calcuNum;

	// Token: 0x040113EA RID: 70634
	private int overLoadBuffId;

	// Token: 0x040113EB RID: 70635
	private const int InitUIMaxTime = 1000;

	// Token: 0x040113EC RID: 70636
	private int InitUITimer;

	// Token: 0x040113ED RID: 70637
	private int useSkillTimes;

	// Token: 0x040113EE RID: 70638
	private List<int> addDamageSkillId = new List<int>();

	// Token: 0x040113EF RID: 70639
	private BeEventHandle useSkillHandle;

	// Token: 0x040113F0 RID: 70640
	private bool unInitUI = true;
}
