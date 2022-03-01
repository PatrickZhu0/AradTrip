using System;

// Token: 0x020042F2 RID: 17138
public class Mechanism1189 : BeMechanism
{
	// Token: 0x06017B6C RID: 97132 RVA: 0x0074F392 File Offset: 0x0074D792
	public Mechanism1189(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017B6D RID: 97133 RVA: 0x0074F39C File Offset: 0x0074D79C
	public override void OnInit()
	{
		this.mBuffInfoId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.mHpDamagePercent = ((valueFromUnionCell != 0) ? new VRate(valueFromUnionCell) : VRate.zero);
		this.mCDBuffID = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.mCDBuffTime = TableManager.GetValueFromUnionCell(this.data.ValueC[1], this.level, true);
	}

	// Token: 0x06017B6E RID: 97134 RVA: 0x0074F460 File Offset: 0x0074D860
	public override void OnStart()
	{
		this.StartFightingState();
		this._RegistEvent();
	}

	// Token: 0x06017B6F RID: 97135 RVA: 0x0074F470 File Offset: 0x0074D870
	private void _RegistEvent()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onBuffFinish, new BeEventHandle.Del(this.OnCDBuffFinishEvent));
		this.handleB = base.owner.RegisterEvent(BeEventType.onHurt, new BeEventHandle.Del(this.OnHurtEvent));
		this.handleC = base.owner.RegisterEvent(BeEventType.OnBuffDamage, new BeEventHandle.Del(this.OnBuffDamage));
	}

	// Token: 0x06017B70 RID: 97136 RVA: 0x0074F4E0 File Offset: 0x0074D8E0
	protected void StartFightingState()
	{
		if (base.owner == null || base.owner.buffController == null)
		{
			return;
		}
		this.mFightingBuff = base.owner.buffController.TryAddBuff(this.mBuffInfoId, null, false, null, 0);
	}

	// Token: 0x06017B71 RID: 97137 RVA: 0x0074F520 File Offset: 0x0074D920
	private void OnCDBuffFinishEvent(object[] args)
	{
		int num = (int)args[0];
		if (num == this.mCDBuffID)
		{
			this.StartFightingState();
		}
	}

	// Token: 0x06017B72 RID: 97138 RVA: 0x0074F548 File Offset: 0x0074D948
	protected void CheckHpDamage(int value)
	{
		if (value <= 0)
		{
			return;
		}
		if (base.owner == null || base.owner.attribute == null || base.owner.buffController == null)
		{
			return;
		}
		if (value > base.owner.attribute.GetMaxHP() * this.mHpDamagePercent.factor && this.mFightingBuff != null)
		{
			base.owner.buffController.RemoveBuff(this.mFightingBuff);
			this.mFightingBuff = null;
			base.owner.buffController.TryAddBuff(this.mCDBuffID, this.mCDBuffTime, 1);
		}
	}

	// Token: 0x06017B73 RID: 97139 RVA: 0x0074F5F8 File Offset: 0x0074D9F8
	private void OnHurtEvent(object[] args)
	{
		if (this.IsInCheckDamageCD())
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
			this.CheckHpDamage(value);
		}
	}

	// Token: 0x06017B74 RID: 97140 RVA: 0x0074F650 File Offset: 0x0074DA50
	private void OnBuffDamage(object[] args)
	{
		if (this.IsInCheckDamageCD())
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
			this.CheckHpDamage(value);
		}
	}

	// Token: 0x06017B75 RID: 97141 RVA: 0x0074F6CA File Offset: 0x0074DACA
	protected bool IsInCheckDamageCD()
	{
		return base.owner != null && base.owner.buffController != null && base.owner.buffController.HasBuffByID(this.mCDBuffID) != null;
	}

	// Token: 0x0401109F RID: 69791
	protected int mBuffInfoId;

	// Token: 0x040110A0 RID: 69792
	protected VRate mHpDamagePercent;

	// Token: 0x040110A1 RID: 69793
	protected int mCDBuffID;

	// Token: 0x040110A2 RID: 69794
	protected int mCDBuffTime;

	// Token: 0x040110A3 RID: 69795
	protected BeBuff mFightingBuff;
}
