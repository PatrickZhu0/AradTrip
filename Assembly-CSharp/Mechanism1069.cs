using System;

// Token: 0x0200428F RID: 17039
public class Mechanism1069 : BeMechanism
{
	// Token: 0x06017933 RID: 96563 RVA: 0x00741DC5 File Offset: 0x007401C5
	public Mechanism1069(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017934 RID: 96564 RVA: 0x00741DD0 File Offset: 0x007401D0
	public override void OnInit()
	{
		this.mTagBuffId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.mTagBuffDuration = TableManager.GetValueFromUnionCell(this.data.ValueA[1], this.level, true);
		this.mTargetEffectTableId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.mSelfBuffId = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.mSelfBuffDuration = TableManager.GetValueFromUnionCell(this.data.ValueC[1], this.level, true);
		this.mSelfBuffRate = TableManager.GetValueFromUnionCell(this.data.ValueC[2], this.level, true);
		this.mSelfBuffCD = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
	}

	// Token: 0x06017935 RID: 96565 RVA: 0x00741EF5 File Offset: 0x007402F5
	public override void OnStart()
	{
		if (base.owner == null)
		{
			return;
		}
		this.handleA = base.owner.RegisterEvent(BeEventType.onAfterFinalDamageNew, delegate(object[] args1)
		{
			BeActor beActor = args1[1] as BeActor;
			int num = (int)args1[2];
			if (beActor == null || num == this.mTargetEffectTableId)
			{
				return;
			}
			if (beActor.buffController.HasBuffByID(this.mTagBuffId) == null)
			{
				beActor.buffController.TryAddBuff(this.mTagBuffId, this.mTagBuffDuration, 1, GlobalLogic.VALUE_1000, 0, false, null, 0, 0, null);
			}
			else
			{
				base.owner.DoAttackTo(beActor, this.mTargetEffectTableId, false, true);
				if (!this.isSelfBuffInCD && this.mSelfBuffRate >= (int)base.FrameRandom.Range1000())
				{
					base.owner.buffController.TryAddBuff(this.mSelfBuffId, this.mSelfBuffDuration, 1);
					this.isSelfBuffInCD = true;
				}
			}
		});
	}

	// Token: 0x06017936 RID: 96566 RVA: 0x00741F22 File Offset: 0x00740322
	public override void OnUpdate(int deltaTime)
	{
		if (this.isSelfBuffInCD)
		{
			this.mSelfBuffCDTimer += deltaTime;
			if (this.mSelfBuffCDTimer >= this.mSelfBuffCD)
			{
				this.mSelfBuffCDTimer = 0;
				this.isSelfBuffInCD = false;
			}
		}
	}

	// Token: 0x04010F09 RID: 69385
	private int mTagBuffId;

	// Token: 0x04010F0A RID: 69386
	private int mTagBuffDuration;

	// Token: 0x04010F0B RID: 69387
	private int mTargetEffectTableId;

	// Token: 0x04010F0C RID: 69388
	private int mSelfBuffId;

	// Token: 0x04010F0D RID: 69389
	private int mSelfBuffDuration;

	// Token: 0x04010F0E RID: 69390
	private int mSelfBuffRate;

	// Token: 0x04010F0F RID: 69391
	private int mSelfBuffCD;

	// Token: 0x04010F10 RID: 69392
	private int mSelfBuffCDTimer;

	// Token: 0x04010F11 RID: 69393
	private bool isSelfBuffInCD;
}
