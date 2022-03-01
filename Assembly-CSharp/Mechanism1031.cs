using System;
using System.Collections.Generic;

// Token: 0x02004268 RID: 17000
public class Mechanism1031 : BeMechanism
{
	// Token: 0x06017865 RID: 96357 RVA: 0x0073CE5D File Offset: 0x0073B25D
	public Mechanism1031(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017866 RID: 96358 RVA: 0x0073CE8C File Offset: 0x0073B28C
	public override void OnInit()
	{
		base.OnInit();
		this.offsetArr[0] = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true), GlobalLogic.VALUE_1000);
		this.offsetArr[1] = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueA[1], this.level, true), GlobalLogic.VALUE_1000);
		this.offsetArr[2] = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueA[2], this.level, true), GlobalLogic.VALUE_1000);
		this.skillId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x06017867 RID: 96359 RVA: 0x0073CF7E File Offset: 0x0073B37E
	public override void OnStart()
	{
		base.OnStart();
		this.RegisterExcuteGrab();
		this.RegisterEndGrab();
	}

	// Token: 0x06017868 RID: 96360 RVA: 0x0073CF92 File Offset: 0x0073B392
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		this.UpdateTargetPos();
	}

	// Token: 0x06017869 RID: 96361 RVA: 0x0073CFA1 File Offset: 0x0073B3A1
	public override void OnFinish()
	{
		base.OnFinish();
		this.ResetData();
	}

	// Token: 0x0601786A RID: 96362 RVA: 0x0073CFAF File Offset: 0x0073B3AF
	private void RegisterExcuteGrab()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onExcuteGrab, delegate(object[] args)
		{
			int num = (int)args[0];
			if (num == this.skillId)
			{
				this.ResetData();
				base.owner.GetGrabTargetList(this.targetList);
			}
		});
	}

	// Token: 0x0601786B RID: 96363 RVA: 0x0073CFD0 File Offset: 0x0073B3D0
	private void RegisterEndGrab()
	{
		this.handleB = base.owner.RegisterEvent(BeEventType.onEndGrab, delegate(object[] args)
		{
			int num = (int)args[1];
			if (num == this.skillId)
			{
				base.owner.grabPos = false;
			}
		});
	}

	// Token: 0x0601786C RID: 96364 RVA: 0x0073CFF4 File Offset: 0x0073B3F4
	private void UpdateTargetPos()
	{
		if (this.targetList == null)
		{
			return;
		}
		base.owner.grabPos = true;
		for (int i = 0; i < this.targetList.Count; i++)
		{
			BeActor beActor = this.targetList[i];
			if (beActor != null && !beActor.IsDead())
			{
				VInt3 position = base.owner.GetPosition();
				position.x += this.offsetArr[0].i;
				position.y += this.offsetArr[1].i;
				position.z += this.offsetArr[2].i;
				beActor.SetPosition(base.owner.GetPosition(), false, true, false);
			}
		}
	}

	// Token: 0x0601786D RID: 96365 RVA: 0x0073D0D5 File Offset: 0x0073B4D5
	private void ResetData()
	{
		this.targetList.Clear();
	}

	// Token: 0x04010E78 RID: 69240
	private VInt[] offsetArr = new VInt[3];

	// Token: 0x04010E79 RID: 69241
	private int skillId = 20182;

	// Token: 0x04010E7A RID: 69242
	private List<BeActor> targetList = new List<BeActor>();
}
