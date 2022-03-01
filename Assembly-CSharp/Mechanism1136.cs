using System;

// Token: 0x020042BA RID: 17082
public class Mechanism1136 : BeMechanism
{
	// Token: 0x06017A25 RID: 96805 RVA: 0x0074808E File Offset: 0x0074648E
	public Mechanism1136(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017A26 RID: 96806 RVA: 0x00748098 File Offset: 0x00746498
	public override void OnInit()
	{
		base.OnInit();
		this._hurtId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this._repeatTimeAcc = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this._repeatAttackNum = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x06017A27 RID: 96807 RVA: 0x00748123 File Offset: 0x00746523
	public override void OnStart()
	{
		this._InitData();
	}

	// Token: 0x06017A28 RID: 96808 RVA: 0x0074812B File Offset: 0x0074652B
	public override void OnUpdateImpactBySpeed(int deltaTime)
	{
		this._CheckResetHurtList(deltaTime);
	}

	// Token: 0x06017A29 RID: 96809 RVA: 0x00748134 File Offset: 0x00746534
	private void _InitData()
	{
		this._curAttackTime = 0;
		this._curTimeAcc = this._repeatTimeAcc;
		this._TriggerEvent();
	}

	// Token: 0x06017A2A RID: 96810 RVA: 0x00748150 File Offset: 0x00746550
	private void _TriggerEvent()
	{
		int[] array = new int[]
		{
			GlobalLogic.VALUE_1000,
			0
		};
		base.owner.TriggerEvent(BeEventType.onRepeatAttackInterval, new object[]
		{
			array,
			this._hurtId
		});
		this._repeatTimeAcc *= VFactor.NewVFactor(array[0], GlobalLogic.VALUE_1000);
		this._repeatAttackNum += array[1];
	}

	// Token: 0x06017A2B RID: 96811 RVA: 0x007481C8 File Offset: 0x007465C8
	private void _CheckResetHurtList(int deltaTime)
	{
		if (this._curAttackTime >= this._repeatAttackNum)
		{
			return;
		}
		this._curTimeAcc += deltaTime;
		if (this._curTimeAcc >= this._repeatTimeAcc)
		{
			this._curAttackTime++;
			base.owner.ResetDamageData();
			base.owner._calcAttack();
			this._curTimeAcc -= this._repeatTimeAcc;
		}
	}

	// Token: 0x04010FB8 RID: 69560
	private int _hurtId;

	// Token: 0x04010FB9 RID: 69561
	private int _repeatTimeAcc;

	// Token: 0x04010FBA RID: 69562
	private int _repeatAttackNum;

	// Token: 0x04010FBB RID: 69563
	private int _curAttackTime;

	// Token: 0x04010FBC RID: 69564
	private int _curTimeAcc;
}
