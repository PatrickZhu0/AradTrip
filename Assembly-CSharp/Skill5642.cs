using System;

// Token: 0x020044E7 RID: 17639
internal class Skill5642 : BeSkill
{
	// Token: 0x060188C8 RID: 100552 RVA: 0x007AA6B3 File Offset: 0x007A8AB3
	public Skill5642(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060188C9 RID: 100553 RVA: 0x007AA6C4 File Offset: 0x007A8AC4
	public override void OnInit()
	{
		this.rNumber = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.timeArray = new int[this.rNumber];
		for (int i = 0; i < this.rNumber; i++)
		{
			this.timeArray[i] = TableManager.GetValueFromUnionCell(this.skillData.ValueB[i], base.level, true);
		}
		this.attackId = 56422;
		this.mechanismId = 1089;
	}

	// Token: 0x060188CA RID: 100554 RVA: 0x007AA757 File Offset: 0x007A8B57
	public override void OnStart()
	{
		this.handle1 = base.owner.RegisterEvent(BeEventType.onPreSetSkillAction, delegate(object[] args)
		{
			int[] newPhaseArray = this.GetNewPhaseArray(this.rNumber);
			base.owner.SetCurrSkillPhase(newPhaseArray);
		});
	}

	// Token: 0x060188CB RID: 100555 RVA: 0x007AA778 File Offset: 0x007A8B78
	private int[] GetNewPhaseArray(int number)
	{
		if (number < 1)
		{
			number = 1;
		}
		int[] array = new int[5 + (number - 1) * 4];
		array[0] = 56421;
		array[1] = 56422;
		array[2] = 56423;
		array[3] = 56424;
		array[4] = 56425;
		int[] array2 = new int[]
		{
			56426,
			56423,
			56424,
			56425
		};
		int num = 5;
		for (int i = 1; i < number; i++)
		{
			for (int j = 0; j < array2.Length; j++)
			{
				array[num++] = array2[j];
			}
		}
		return array;
	}

	// Token: 0x060188CC RID: 100556 RVA: 0x007AA810 File Offset: 0x007A8C10
	public override void OnEnterPhase(int phase)
	{
		this.curPhase = phase;
		if (phase == 4)
		{
			this.mechanism52 = (base.owner.AddMechanism(this.mechanismId, base.level, MechanismSourceType.NONE, null, 0) as Mechanism52);
			if (this.mechanism52 != null)
			{
				this.mechanism52.Init(0);
			}
		}
		if (phase % 4 == 0)
		{
			if (this.mechanism52 != null)
			{
				this.mechanism52.rTime = this.timeArray[phase / 4 - 1];
				this.mechanism52.Start();
			}
			this.executeNext = false;
		}
	}

	// Token: 0x060188CD RID: 100557 RVA: 0x007AA8A4 File Offset: 0x007A8CA4
	public override void OnUpdate(int iDeltime)
	{
		if (!this.executeNext && this.mechanism52 != null && this.mechanism52.rotateEnd)
		{
			(base.owner.GetStateGraph() as BeActorStateGraph).ExecuteNextPhaseSkill();
			this.executeNext = true;
		}
	}

	// Token: 0x060188CE RID: 100558 RVA: 0x007AA8F3 File Offset: 0x007A8CF3
	public override void OnCancel()
	{
		if (this.mechanism52 != null)
		{
			this.mechanism52.Stop();
			base.owner.RemoveMechanism(this.mechanism52.mechianismID);
		}
		this.RemoveHandle();
	}

	// Token: 0x060188CF RID: 100559 RVA: 0x007AA927 File Offset: 0x007A8D27
	public override void OnFinish()
	{
		if (this.mechanism52 != null)
		{
			this.mechanism52.Stop();
			base.owner.RemoveMechanism(this.mechanism52.mechianismID);
		}
		this.RemoveHandle();
	}

	// Token: 0x060188D0 RID: 100560 RVA: 0x007AA95B File Offset: 0x007A8D5B
	private void RemoveHandle()
	{
		if (this.handle1 != null)
		{
			this.handle1.Remove();
			this.handle1 = null;
		}
	}

	// Token: 0x04011B68 RID: 72552
	private Mechanism52 mechanism52;

	// Token: 0x04011B69 RID: 72553
	private BeEventHandle handle1;

	// Token: 0x04011B6A RID: 72554
	private int rNumber;

	// Token: 0x04011B6B RID: 72555
	private int[] timeArray;

	// Token: 0x04011B6C RID: 72556
	private int attackId;

	// Token: 0x04011B6D RID: 72557
	private int mechanismId;

	// Token: 0x04011B6E RID: 72558
	private bool executeNext = true;
}
