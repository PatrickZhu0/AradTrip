using System;

// Token: 0x02004248 RID: 16968
internal class Mechanism100 : BeMechanism
{
	// Token: 0x060177A4 RID: 96164 RVA: 0x007382E6 File Offset: 0x007366E6
	public Mechanism100(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060177A5 RID: 96165 RVA: 0x007382F0 File Offset: 0x007366F0
	public override void OnInit()
	{
		this.buffArray = new int[this.data.ValueA.Length];
		for (int i = 0; i < this.data.ValueA.Length; i++)
		{
			this.buffArray[i] = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
		}
		this.buffInfoArray = new int[this.data.ValueB.Length];
		for (int j = 0; j < this.data.ValueB.Length; j++)
		{
			this.buffInfoArray[j] = TableManager.GetValueFromUnionCell(this.data.ValueB[j], this.level, true);
		}
		this.finishRemoveBuff = (TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true) != 0);
		this._attackRemoveBuffResetFlag = (TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true) != 0);
	}

	// Token: 0x060177A6 RID: 96166 RVA: 0x00738434 File Offset: 0x00736834
	public override void OnStart()
	{
		this.hitOtherFlag = false;
		this.handleA = base.owner.RegisterEvent(BeEventType.onHitOther, delegate(object[] args)
		{
			this.hitOtherFlag = true;
		});
		this.handleB = base.owner.RegisterEvent(BeEventType.onCastSkillFinish, delegate(object[] args)
		{
			if (this.hitOtherFlag)
			{
				if (this._attackRemoveBuffResetFlag)
				{
					this.hitOtherFlag = false;
				}
				this.RemoveBuff();
			}
		});
	}

	// Token: 0x060177A7 RID: 96167 RVA: 0x00738486 File Offset: 0x00736886
	public override void OnFinish()
	{
		base.OnFinish();
		if (this.finishRemoveBuff)
		{
			this.RemoveBuff();
		}
	}

	// Token: 0x060177A8 RID: 96168 RVA: 0x007384A0 File Offset: 0x007368A0
	private void RemoveBuff()
	{
		for (int i = 0; i < this.buffArray.Length; i++)
		{
			base.owner.buffController.RemoveBuff(this.buffArray[i], 0, 0);
		}
		for (int j = 0; j < this.buffInfoArray.Length; j++)
		{
			base.owner.buffController.RemoveBuffByBuffInfoID(this.buffInfoArray[j]);
		}
	}

	// Token: 0x04010DEB RID: 69099
	private int[] buffArray;

	// Token: 0x04010DEC RID: 69100
	private int[] buffInfoArray;

	// Token: 0x04010DED RID: 69101
	private bool hitOtherFlag;

	// Token: 0x04010DEE RID: 69102
	private bool finishRemoveBuff;

	// Token: 0x04010DEF RID: 69103
	private bool _attackRemoveBuffResetFlag;
}
