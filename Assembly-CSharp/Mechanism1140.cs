using System;
using System.Collections.Generic;

// Token: 0x020042BF RID: 17087
public class Mechanism1140 : BeMechanism
{
	// Token: 0x06017A4A RID: 96842 RVA: 0x00748DC2 File Offset: 0x007471C2
	public Mechanism1140(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017A4B RID: 96843 RVA: 0x00748DE4 File Offset: 0x007471E4
	public override void OnInit()
	{
		this.m_hpPercent = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true), GlobalLogic.VALUE_1000);
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			this.m_buffInfoID.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
		}
		this.m_timeLen = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.m_interval = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
	}

	// Token: 0x06017A4C RID: 96844 RVA: 0x00748EC4 File Offset: 0x007472C4
	private Mechanism1140.DamageCheckPoint GenCheckPoint()
	{
		if (this.m_PoolRecord != null && this.m_PoolRecord.Count > 0)
		{
			Mechanism1140.DamageCheckPoint damageCheckPoint = this.m_PoolRecord[this.m_PoolRecord.Count - 1];
			damageCheckPoint.damage = 0;
			damageCheckPoint.timeStamp = 0;
			this.m_PoolRecord.RemoveAt(this.m_PoolRecord.Count - 1);
			return damageCheckPoint;
		}
		return new Mechanism1140.DamageCheckPoint();
	}

	// Token: 0x06017A4D RID: 96845 RVA: 0x00748F33 File Offset: 0x00747333
	private void ReleaseCheckPoint(Mechanism1140.DamageCheckPoint record)
	{
		if (this.m_PoolRecord == null)
		{
			this.m_PoolRecord = new List<Mechanism1140.DamageCheckPoint>();
		}
		this.m_PoolRecord.Add(record);
	}

	// Token: 0x06017A4E RID: 96846 RVA: 0x00748F58 File Offset: 0x00747358
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onHitAfterAddBuff, new BeEventHandle.Del(this.onHit));
		Mechanism1140.DamageCheckPoint damageCheckPoint = this.GenCheckPoint();
		if (damageCheckPoint != null)
		{
			damageCheckPoint.damage = 0;
			damageCheckPoint.timeStamp = 0;
		}
		if (this.m_RecordPoint == null)
		{
			this.m_RecordPoint = new List<Mechanism1140.DamageCheckPoint>();
		}
		this.m_RecordPoint.Add(damageCheckPoint);
	}

	// Token: 0x06017A4F RID: 96847 RVA: 0x00748FC4 File Offset: 0x007473C4
	private void onHit(object[] args)
	{
		int num = (int)args[4];
		if (base.owner.GetEntityData() == null || base.owner.GetEntityData().GetMaxHP() == 0)
		{
			return;
		}
		int maxHP = base.owner.GetEntityData().GetMaxHP();
		for (int i = 0; i < this.m_RecordPoint.Count; i++)
		{
			Mechanism1140.DamageCheckPoint damageCheckPoint = this.m_RecordPoint[i];
			if (this.m_elapseTime - damageCheckPoint.timeStamp <= this.m_timeLen)
			{
				damageCheckPoint.damage += num;
				VFactor a = VFactor.NewVFactor(damageCheckPoint.damage, maxHP);
				if (a >= this.m_hpPercent)
				{
					for (int j = 0; j < this.m_buffInfoID.Count; j++)
					{
						base.owner.buffController.TryAddBuff(this.m_buffInfoID[j], null, false, null, 0);
					}
					if (this.m_PoolRecord != null)
					{
						this.m_PoolRecord.Clear();
					}
					if (this.m_RecordPoint != null)
					{
						this.m_RecordPoint.Clear();
					}
					base.Finish();
					return;
				}
			}
		}
	}

	// Token: 0x06017A50 RID: 96848 RVA: 0x007490F8 File Offset: 0x007474F8
	private void _MakeAllCheckPointValid()
	{
		if (this.m_RecordPoint == null)
		{
			return;
		}
		for (int i = this.m_RecordPoint.Count - 1; i >= 0; i--)
		{
			Mechanism1140.DamageCheckPoint damageCheckPoint = this.m_RecordPoint[i];
			if (this.m_elapseTime - damageCheckPoint.timeStamp > this.m_timeLen)
			{
				int num = this.m_RecordPoint.Count - 1;
				Mechanism1140.DamageCheckPoint value = this.m_RecordPoint[num];
				this.m_RecordPoint[num] = this.m_RecordPoint[i];
				this.ReleaseCheckPoint(this.m_RecordPoint[num]);
				if (num > i)
				{
					this.m_RecordPoint[i] = value;
				}
				this.m_RecordPoint.RemoveAt(num);
			}
		}
	}

	// Token: 0x06017A51 RID: 96849 RVA: 0x007491BC File Offset: 0x007475BC
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		this.m_elapseTime += deltaTime;
		this.m_durTime += deltaTime;
		if (this.m_durTime < 500)
		{
			return;
		}
		if (this.m_durTime >= this.m_interval && this.m_RecordPoint != null && this.m_RecordPoint.Count < 50)
		{
			this.m_durTime -= this.m_interval;
			Mechanism1140.DamageCheckPoint damageCheckPoint = this.GenCheckPoint();
			damageCheckPoint.timeStamp = this.m_elapseTime;
			this.m_RecordPoint.Add(damageCheckPoint);
		}
		this._MakeAllCheckPointValid();
	}

	// Token: 0x04010FCF RID: 69583
	private List<Mechanism1140.DamageCheckPoint> m_RecordPoint;

	// Token: 0x04010FD0 RID: 69584
	private List<Mechanism1140.DamageCheckPoint> m_PoolRecord;

	// Token: 0x04010FD1 RID: 69585
	private VFactor m_hpPercent = VFactor.zero;

	// Token: 0x04010FD2 RID: 69586
	private int m_timeLen;

	// Token: 0x04010FD3 RID: 69587
	private int m_interval;

	// Token: 0x04010FD4 RID: 69588
	private int m_elapseTime;

	// Token: 0x04010FD5 RID: 69589
	private int m_durTime;

	// Token: 0x04010FD6 RID: 69590
	private const int MAX_RECORD_COUNT = 50;

	// Token: 0x04010FD7 RID: 69591
	private List<int> m_buffInfoID = new List<int>();

	// Token: 0x020042C0 RID: 17088
	private class DamageCheckPoint
	{
		// Token: 0x04010FD8 RID: 69592
		public int damage;

		// Token: 0x04010FD9 RID: 69593
		public int timeStamp;
	}
}
