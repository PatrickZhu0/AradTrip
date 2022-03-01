using System;
using System.Collections.Generic;
using GameClient;
using UnityEngine;

// Token: 0x02004366 RID: 17254
public class Mechanism2047 : BeMechanism
{
	// Token: 0x06017E4C RID: 97868 RVA: 0x00764148 File Offset: 0x00762548
	public Mechanism2047(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06017E4D RID: 97869 RVA: 0x007641D4 File Offset: 0x007625D4
	public override void OnInit()
	{
		base.OnInit();
		int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.addSpeed = VInt.NewVInt(valueFromUnionCell, GlobalLogic.VALUE_10000);
		valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.decSpeed = VInt.NewVInt(valueFromUnionCell, GlobalLogic.VALUE_10000);
		this.initEnergy = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true), GlobalLogic.VALUE_1000);
		if (this.data.ValueD.Length > 0)
		{
			for (int i = 0; i < this.data.ValueD.Length; i++)
			{
				this.energyUpLevelValue.Add(VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueD[i], this.level, true), GlobalLogic.VALUE_1000));
			}
		}
		if (this.data.ValueE.Length > 0)
		{
			for (int j = 0; j < this.data.ValueE.Length; j++)
			{
				this.energyLevelBuffInfo.Add(TableManager.GetValueFromUnionCell(this.data.ValueE[j], this.level, true));
			}
		}
		if (this.data.ValueF.Length > 0)
		{
			for (int k = 0; k < this.data.ValueF.Length; k++)
			{
				this.energyLevelBuff.Add(TableManager.GetValueFromUnionCell(this.data.ValueF[k], this.level, true));
			}
		}
		this.curEnergy = this.initEnergy;
		if (this.colorValues.Length > 0)
		{
			for (int l = 0; l < this.colorValues.Length; l++)
			{
				uint num = this.colorValues[l];
				Color item;
				item..ctor((num >> 24 & 255U) / 255f, (num >> 16 & 255U) / 255f, (num >> 8 & 255U) / 255f, (num & 255U) / 255f);
				this.colorList.Add(item);
			}
		}
	}

	// Token: 0x06017E4E RID: 97870 RVA: 0x00764455 File Offset: 0x00762855
	public override void OnFinish()
	{
		base.OnFinish();
		if (this.frame != null)
		{
			this.frame.SetBossEnergyBarActive(false);
		}
	}

	// Token: 0x06017E4F RID: 97871 RVA: 0x00764474 File Offset: 0x00762874
	public override void OnStart()
	{
		base.OnStart();
		if (this.frame == null)
		{
			this.frame = (Singleton<ClientSystemManager>.instance.OpenFrame<TeamDungeonBattleFrame>(FrameLayer.Middle, null, string.Empty) as TeamDungeonBattleFrame);
		}
		if (this.frame != null)
		{
			this.frame.SetBossEnergyBarActive(true);
		}
		if (base.owner == null || base.owner.CurrentBeScene == null)
		{
			return;
		}
	}

	// Token: 0x06017E50 RID: 97872 RVA: 0x007644E4 File Offset: 0x007628E4
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (base.owner == null || base.owner.CurrentBeScene == null)
		{
			return;
		}
		this.curTime += deltaTime;
		if (this.curTime < 1000)
		{
			return;
		}
		this.curTime -= 1000;
		if (this.curLevel == 0 || this.curLevel + 1 == this.energyUpLevelValue.Count)
		{
			int bid = this.energyLevelBuff[this.curLevel];
			if (base.owner.buffController.HasBuffByID(bid) != null)
			{
				if (this.frame != null)
				{
					this.frame.SetBossEnergyValue((float)this.curEnergy.i / 100f, this.curLevel);
				}
				return;
			}
			this.curEnergy = this.initEnergy;
		}
		bool flag = base.owner.CurrentBeScene.IsDayTime();
		if (flag)
		{
			if (this.curEnergy < VInt.one)
			{
				this.curEnergy += this.addSpeed;
				if (this.curEnergy > VInt.one)
				{
					this.curEnergy = VInt.one;
				}
			}
		}
		else if (this.curEnergy > 0)
		{
			this.curEnergy -= this.decSpeed;
			if (this.curEnergy < 0)
			{
				this.curEnergy = 0;
			}
		}
		int num = this.curLevel;
		for (int i = 0; i < this.energyUpLevelValue.Count; i++)
		{
			if (this.curEnergy <= this.energyUpLevelValue[i])
			{
				num = i;
				if (this.curLevel != num)
				{
					if (this.curLevel >= 0 && this.curLevel < this.energyLevelBuff.Count)
					{
						int buffID = this.energyLevelBuff[this.curLevel];
						base.owner.buffController.RemoveBuff(buffID, 0, 0);
					}
					this.curLevel = num;
					if (this.curLevel + 1 == this.energyUpLevelValue.Count)
					{
						base.owner.TriggerEvent(BeEventType.onReachMaxEnergy, null);
					}
					if (this.curLevel >= 0 && this.curLevel < this.energyLevelBuffInfo.Count)
					{
						int buffInfoID = this.energyLevelBuffInfo[this.curLevel];
						base.owner.buffController.TryAddBuff(buffInfoID, null, false, null, 0);
					}
					if (this.curLevel >= 0 && this.curLevel < this.colorList.Count && base.owner.m_pkGeActor != null)
					{
						base.owner.m_pkGeActor.SetEmissiveColor(this.colorList[this.curLevel], 1f);
					}
				}
				break;
			}
			if (this.frame != null)
			{
				this.frame.SetBossEnergyValue((float)this.curEnergy.i / 100f, this.curLevel);
			}
		}
	}

	// Token: 0x04011320 RID: 70432
	private VInt addSpeed = VInt.zero;

	// Token: 0x04011321 RID: 70433
	private VInt decSpeed = VInt.zero;

	// Token: 0x04011322 RID: 70434
	private List<VInt> energyUpLevelValue = new List<VInt>();

	// Token: 0x04011323 RID: 70435
	private List<int> energyLevelBuffInfo = new List<int>();

	// Token: 0x04011324 RID: 70436
	private List<int> energyLevelBuff = new List<int>();

	// Token: 0x04011325 RID: 70437
	private List<Color> colorList = new List<Color>();

	// Token: 0x04011326 RID: 70438
	private readonly uint[] colorValues = new uint[]
	{
		2583691392U,
		88769408U,
		3343253632U,
		1627416448U,
		2583691392U
	};

	// Token: 0x04011327 RID: 70439
	private TeamDungeonBattleFrame frame;

	// Token: 0x04011328 RID: 70440
	private VInt curEnergy = VInt.zero;

	// Token: 0x04011329 RID: 70441
	private int curLevel = -1;

	// Token: 0x0401132A RID: 70442
	private VInt initEnergy = 0;

	// Token: 0x0401132B RID: 70443
	private int curTime;
}
