using System;

// Token: 0x020042F1 RID: 17137
public class Mechanism1188 : BeMechanism
{
	// Token: 0x06017B63 RID: 97123 RVA: 0x0074F092 File Offset: 0x0074D492
	public Mechanism1188(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017B64 RID: 97124 RVA: 0x0074F09C File Offset: 0x0074D49C
	public override void OnInit()
	{
		this.mMaxHpLimitRate = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.mConditionBuffInfo = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.mCdBuffID = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.mCdBuffTime = TableManager.GetValueFromUnionCell(this.data.ValueC[1], this.level, true);
	}

	// Token: 0x06017B65 RID: 97125 RVA: 0x0074F149 File Offset: 0x0074D549
	public override void OnStart()
	{
		this.StartRecordHpDamage();
		this._RegistEvent();
	}

	// Token: 0x06017B66 RID: 97126 RVA: 0x0074F158 File Offset: 0x0074D558
	private void _RegistEvent()
	{
		if (base.owner != null)
		{
			this.handleA = base.owner.RegisterEvent(BeEventType.onHurt, new BeEventHandle.Del(this.OnHurtEvent));
			this.handleB = base.owner.RegisterEvent(BeEventType.OnBuffDamage, new BeEventHandle.Del(this.OnBuffDamage));
		}
	}

	// Token: 0x06017B67 RID: 97127 RVA: 0x0074F1B4 File Offset: 0x0074D5B4
	private void OnHurtEvent(object[] args)
	{
		if (this.IsInSaveDamageCD())
		{
			return;
		}
		if (args.Length > 1)
		{
			BeEntity beEntity = args[1] as BeEntity;
			if (beEntity == null || beEntity.GetPID() == base.owner.GetPID())
			{
				return;
			}
			int value = (int)args[0];
			this.SaveHpDamage(value);
		}
	}

	// Token: 0x06017B68 RID: 97128 RVA: 0x0074F20C File Offset: 0x0074D60C
	private void OnBuffDamage(object[] args)
	{
		if (this.IsInSaveDamageCD())
		{
			return;
		}
		if (args.Length > 1)
		{
			int value = (int)args[0];
			int bid = (int)args[1];
			BeBuff beBuff = base.owner.buffController.HasBuffByID(bid);
			if (beBuff == null || beBuff.releaser == null || beBuff.releaser.GetPID() == base.owner.GetPID())
			{
				return;
			}
			this.SaveHpDamage(value);
		}
	}

	// Token: 0x06017B69 RID: 97129 RVA: 0x0074F286 File Offset: 0x0074D686
	protected bool IsInSaveDamageCD()
	{
		return base.owner != null && base.owner.buffController != null && base.owner.buffController.HasBuffByID(this.mCdBuffID) != null;
	}

	// Token: 0x06017B6A RID: 97130 RVA: 0x0074F2C1 File Offset: 0x0074D6C1
	protected void StartRecordHpDamage()
	{
		if (base.owner == null || base.owner.attribute == null)
		{
			return;
		}
		this.mNowHpDamageRate = 0;
	}

	// Token: 0x06017B6B RID: 97131 RVA: 0x0074F2E8 File Offset: 0x0074D6E8
	protected void SaveHpDamage(int value)
	{
		if (value <= 0)
		{
			return;
		}
		this.mNowHpDamageRate += (int)((long)value * 10000L / (long)base.owner.attribute.GetMaxHP());
		if (this.mNowHpDamageRate >= this.mMaxHpLimitRate)
		{
			if (base.owner != null && base.owner.buffController != null)
			{
				base.owner.buffController.TryAddBuff(this.mConditionBuffInfo, null, false, null, 0);
				base.owner.buffController.TryAddBuff(this.mCdBuffID, this.mCdBuffTime, 1);
			}
			this.mNowHpDamageRate = 0;
		}
	}

	// Token: 0x0401109A RID: 69786
	protected int mMaxHpLimitRate;

	// Token: 0x0401109B RID: 69787
	protected int mConditionBuffInfo;

	// Token: 0x0401109C RID: 69788
	protected int mCdBuffID;

	// Token: 0x0401109D RID: 69789
	protected int mCdBuffTime;

	// Token: 0x0401109E RID: 69790
	protected int mNowHpDamageRate;
}
