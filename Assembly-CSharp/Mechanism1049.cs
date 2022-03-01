using System;

// Token: 0x0200427A RID: 17018
public class Mechanism1049 : BeMechanism
{
	// Token: 0x060178C9 RID: 96457 RVA: 0x0073F298 File Offset: 0x0073D698
	public Mechanism1049(int id, int level) : base(id, level)
	{
	}

	// Token: 0x060178CA RID: 96458 RVA: 0x0073F2B0 File Offset: 0x0073D6B0
	public override void OnInit()
	{
		base.OnInit();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.speedArr[i] = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true), GlobalLogic.VALUE_1000);
		}
	}

	// Token: 0x060178CB RID: 96459 RVA: 0x0073F324 File Offset: 0x0073D724
	public override void OnStart()
	{
		base.OnStart();
		base.owner.SetRestrainPosition(false);
		base.owner.stateController.SetAbilityEnable(BeAbilityType.BLOCK, false);
		base.owner.buffController.TryAddBuff(29, GlobalLogic.VALUE_10000, 1);
		base.owner.FrozenDisMax = GlobalLogic.VALUE_100000;
		base.owner.ClearMoveSpeed(7);
		base.owner.Locomote(new BeStateData(4, 0, 0, 0, 0, GlobalLogic.VALUE_10000, true), false);
		base.owner.SetMoveSpeedX((!base.owner.GetFace()) ? (-this.speedArr[0]) : this.speedArr[0]);
		base.owner.SetMoveSpeedY(this.speedArr[1]);
		base.owner.SetMoveSpeedZ(this.speedArr[2]);
	}

	// Token: 0x060178CC RID: 96460 RVA: 0x0073F42C File Offset: 0x0073D82C
	public override void OnFinish()
	{
		base.OnFinish();
		base.owner.Locomote(new BeStateData(9, 0), false);
		base.owner.stateController.SetAbilityEnable(BeAbilityType.BLOCK, true);
		base.owner.ClearMoveSpeed(7);
		base.owner.SetRestrainPosition(true);
		VInt3 sceneCenterPosition = base.owner.CurrentBeScene.GetSceneCenterPosition();
		sceneCenterPosition.z = 35000;
		base.owner.SetPosition(sceneCenterPosition, false, true, false);
		base.owner.buffController.RemoveBuff(29, 0, 0);
	}

	// Token: 0x04010EBE RID: 69310
	private VInt[] speedArr = new VInt[3];
}
