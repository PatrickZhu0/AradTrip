using System;
using System.Collections.Generic;

// Token: 0x0200445A RID: 17498
public class Skill1515 : BeSkill
{
	// Token: 0x060184F4 RID: 99572 RVA: 0x00791C04 File Offset: 0x00790004
	public Skill1515(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060184F5 RID: 99573 RVA: 0x00791C50 File Offset: 0x00790050
	public override void OnInit()
	{
		this.buffIDs.Clear();
		for (int i = 0; i < this.skillData.ValueA.Count; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell((!this.isPVP()) ? this.skillData.ValueA[i] : this.skillData.ValueB[i], base.level, true);
			if (valueFromUnionCell > 0)
			{
				this.buffIDs.Add(valueFromUnionCell);
			}
		}
		if (this.isPVP())
		{
			if (this.skillData.ValueD.Count > 1)
			{
				this.duration = TableManager.GetValueFromUnionCell(this.skillData.ValueD[0], base.level, true);
				this.dis = TableManager.GetValueFromUnionCell(this.skillData.ValueD[1], base.level, true);
			}
		}
		else if (this.skillData.ValueC.Count > 1)
		{
			this.duration = TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true);
			this.dis = TableManager.GetValueFromUnionCell(this.skillData.ValueC[1], base.level, true);
		}
		this.weaponType.Clear();
		for (int j = 0; j < this.skillData.ValueE.Count; j++)
		{
			int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(this.skillData.ValueE[j], base.level, true);
			if (valueFromUnionCell2 > 0)
			{
				this.weaponType.Add(valueFromUnionCell2);
			}
		}
		this.carrerID.Clear();
		for (int k = 0; k < this.skillData.ValueF.Count; k++)
		{
			int valueFromUnionCell3 = TableManager.GetValueFromUnionCell(this.skillData.ValueF[k], base.level, true);
			if (valueFromUnionCell3 > 0)
			{
				this.carrerID.Add(valueFromUnionCell3);
			}
		}
		if (this.skillData.ValueG.Count > 1)
		{
			this.pveBuffID = TableManager.GetValueFromUnionCell(this.skillData.ValueG[0], base.level, true);
			this.pvpBuffID = TableManager.GetValueFromUnionCell(this.skillData.ValueG[1], base.level, true);
		}
	}

	// Token: 0x060184F6 RID: 99574 RVA: 0x00791EC4 File Offset: 0x007902C4
	public override void OnPostInit()
	{
		base.OnPostInit();
		if (this.isPVP())
		{
			if (this.skillData.ValueD.Count > 1)
			{
				this.duration = TableManager.GetValueFromUnionCell(this.skillData.ValueD[0], base.level, true);
				this.dis = TableManager.GetValueFromUnionCell(this.skillData.ValueD[1], base.level, true);
			}
		}
		else if (this.skillData.ValueC.Count > 1)
		{
			this.duration = TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true);
			this.dis = TableManager.GetValueFromUnionCell(this.skillData.ValueC[1], base.level, true);
		}
	}

	// Token: 0x060184F7 RID: 99575 RVA: 0x00791F9F File Offset: 0x0079039F
	private bool isPVP()
	{
		return BattleMain.IsModePvP(base.battleType);
	}

	// Token: 0x060184F8 RID: 99576 RVA: 0x00791FAC File Offset: 0x007903AC
	public override void OnStart()
	{
		this.mechanism = (((!this.isPVP()) ? base.owner.GetMechanism(5061) : base.owner.GetMechanism(5062)) as Mechanism73);
		this.AddBuff();
		this.RemoveHandle();
		this.handle = base.owner.RegisterEvent(BeEventType.onBackHit, delegate(object[] args)
		{
			base.owner.Locomote(new BeStateData(0, 0), true);
		});
		this.block = base.owner.RegisterEvent(BeEventType.BlockSuccess, delegate(object[] args)
		{
			int[] array = (int[])args[0];
			if (this.isAutoBlock && this.mechanism != null)
			{
				array[0] = this.mechanism.Duration;
				int num = (!base.owner.GetFace()) ? -1 : 1;
				array[1] = num * VInt.Float2VIntValue((float)this.mechanism.Distance / 1000f);
			}
			else
			{
				array[0] = this.duration;
				int num2 = (!base.owner.GetFace()) ? -1 : 1;
				array[1] = num2 * VInt.Float2VIntValue((float)this.dis / 1000f);
			}
			if (base.owner != null && this.carrerID.Contains(base.owner.GetEntityData().professtion) && this.weaponType.Contains(base.owner.GetWeaponType()))
			{
				BuffInfoData info = new BuffInfoData((!this.isPVP()) ? this.pveBuffID : this.pvpBuffID, base.level, 0);
				base.owner.buffController.TryAddBuff(info, null, false, default(VRate), null);
			}
		});
	}

	// Token: 0x060184F9 RID: 99577 RVA: 0x00792040 File Offset: 0x00790440
	public override void OnUpdate(int iDeltime)
	{
		base.OnUpdate(iDeltime);
		if (this.isAutoBlock && this.mechanism != null)
		{
			this.timer += iDeltime;
			if (this.timer >= this.mechanism.Duration)
			{
				this.StopMoveByAction();
				base.owner.Locomote(new BeStateData(0, 0), true);
				this.isAutoBlock = false;
				this.timer = 0;
			}
		}
	}

	// Token: 0x060184FA RID: 99578 RVA: 0x007920B8 File Offset: 0x007904B8
	private void StopMoveByAction()
	{
		BeMoveBy beMoveBy = null;
		List<BeAction> actionList = base.owner.actionManager.GetActionList();
		for (int i = 0; i < actionList.Count; i++)
		{
			if (actionList[i] is BeMoveBy)
			{
				beMoveBy = (actionList[i] as BeMoveBy);
			}
		}
		if (beMoveBy != null)
		{
			beMoveBy.Stop();
		}
	}

	// Token: 0x060184FB RID: 99579 RVA: 0x00792119 File Offset: 0x00790519
	public override void OnFinish()
	{
		this.RemoveBuff();
		this.RemoveHandle();
	}

	// Token: 0x060184FC RID: 99580 RVA: 0x00792127 File Offset: 0x00790527
	public override void OnCancel()
	{
		this.RemoveBuff();
		this.RemoveHandle();
	}

	// Token: 0x060184FD RID: 99581 RVA: 0x00792138 File Offset: 0x00790538
	private void AddBuff()
	{
		base.owner.buffController.TryAddBuff(50, int.MaxValue, 1);
		for (int i = 0; i < this.buffIDs.Count; i++)
		{
			base.owner.buffController.TryAddBuff(this.buffIDs[i], int.MaxValue, base.level);
		}
	}

	// Token: 0x060184FE RID: 99582 RVA: 0x007921A4 File Offset: 0x007905A4
	private void RemoveBuff()
	{
		base.owner.buffController.RemoveBuff(50, 0, 0);
		for (int i = 0; i < this.buffIDs.Count; i++)
		{
			base.owner.buffController.RemoveBuff(this.buffIDs[i], 0, 0);
		}
	}

	// Token: 0x060184FF RID: 99583 RVA: 0x007921FF File Offset: 0x007905FF
	private void RemoveHandle()
	{
		if (this.handle != null)
		{
			this.handle.Remove();
			this.handle = null;
		}
		if (this.block != null)
		{
			this.block.Remove();
			this.block = null;
		}
	}

	// Token: 0x040118A7 RID: 71847
	private BeEventHandle handle;

	// Token: 0x040118A8 RID: 71848
	private List<int> buffIDs = new List<int>();

	// Token: 0x040118A9 RID: 71849
	private BeEventHandle block;

	// Token: 0x040118AA RID: 71850
	private int duration = 200;

	// Token: 0x040118AB RID: 71851
	private int dis = 500;

	// Token: 0x040118AC RID: 71852
	private List<int> weaponType = new List<int>();

	// Token: 0x040118AD RID: 71853
	private List<int> carrerID = new List<int>();

	// Token: 0x040118AE RID: 71854
	private int pveBuffID;

	// Token: 0x040118AF RID: 71855
	private int pvpBuffID;

	// Token: 0x040118B0 RID: 71856
	public bool isAutoBlock;

	// Token: 0x040118B1 RID: 71857
	private Mechanism73 mechanism;

	// Token: 0x040118B2 RID: 71858
	private int timer;
}
