using System;
using GameClient;

// Token: 0x02004299 RID: 17049
public class Mechanism108 : BeMechanism
{
	// Token: 0x06017967 RID: 96615 RVA: 0x007437AA File Offset: 0x00741BAA
	public Mechanism108(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017968 RID: 96616 RVA: 0x007437CC File Offset: 0x00741BCC
	public override void OnInit()
	{
		this.effectArray1 = new int[this.data.ValueB.Length];
		for (int i = 0; i < this.data.ValueB.Length; i++)
		{
			this.effectArray1[i] = TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
		}
		this.timeArray = new int[this.data.ValueC.Length];
		for (int j = 0; j < this.data.ValueC.Length; j++)
		{
			this.timeArray[j] = TableManager.GetValueFromUnionCell(this.data.ValueC[j], this.level, true);
		}
		this.effectArray2 = new int[this.data.ValueD.Length];
		for (int k = 0; k < this.data.ValueD.Length; k++)
		{
			this.effectArray2[k] = TableManager.GetValueFromUnionCell(this.data.ValueD[k], this.level, true);
		}
	}

	// Token: 0x06017969 RID: 96617 RVA: 0x0074390C File Offset: 0x00741D0C
	public override void OnStart()
	{
		this.hpArray = new int[this.data.ValueA.Length];
		for (int i = 0; i < this.data.ValueA.Length; i++)
		{
			VFactor f = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true), GlobalLogic.VALUE_1000);
			int num = base.owner.GetEntityData().GetMaxHP() * f;
			this.hpArray[i] = num;
		}
		this.index = 0;
		this.timer = this.timeArray[this.index];
		this.handleA = base.owner.RegisterEvent(BeEventType.onHPChange, delegate(object[] args)
		{
			if (this.index >= this.hpArray.Length)
			{
				return;
			}
			if (base.owner.GetEntityData().GetHP() <= this.hpArray[this.index])
			{
				base.owner.DealEffectFrame(base.owner, this.effectArray1[this.index], 0, false, true, false, false);
				if (this.index < this.changePhaseArray.Length)
				{
					base.owner.buffController.TryAddBuff(this.changePhaseArray[this.index], GlobalLogic.VALUE_1000, 1);
				}
				this.index++;
				if (this.index < this.timeArray.Length)
				{
					this.timer = this.timeArray[this.index];
				}
			}
		});
	}

	// Token: 0x0601796A RID: 96618 RVA: 0x007439DC File Offset: 0x00741DDC
	public override void OnUpdate(int deltaTime)
	{
		if (this.index >= this.timeArray.Length)
		{
			return;
		}
		this.timer -= deltaTime;
		if (this.timer <= 0)
		{
			base.owner.DealEffectFrame(base.owner, this.effectArray2[this.index], 0, false, true, false, false);
			int value = base.owner.GetEntityData().GetHP() - this.hpArray[this.index];
			base.owner.m_pkGeActor.SetHPDamage(value, HitTextType.NORMAL);
			if (this.hpArray[this.index] == 0)
			{
				base.owner.GetEntityData().SetHP(-1);
				base.owner.DoDead(false);
			}
			else
			{
				base.owner.GetEntityData().SetHP(this.hpArray[this.index]);
			}
			if (this.index < this.changePhaseArray.Length)
			{
				base.owner.buffController.TryAddBuff(this.changePhaseArray[this.index], GlobalLogic.VALUE_1000, 1);
			}
			this.index++;
			if (this.index < this.timeArray.Length)
			{
				this.timer = this.timeArray[this.index];
			}
		}
	}

	// Token: 0x04010F2B RID: 69419
	private int[] hpArray;

	// Token: 0x04010F2C RID: 69420
	private int[] effectArray1;

	// Token: 0x04010F2D RID: 69421
	private int[] timeArray;

	// Token: 0x04010F2E RID: 69422
	private int[] effectArray2;

	// Token: 0x04010F2F RID: 69423
	private int[] changePhaseArray = new int[]
	{
		521390,
		521391,
		521392
	};

	// Token: 0x04010F30 RID: 69424
	private int index;

	// Token: 0x04010F31 RID: 69425
	private int timer;
}
