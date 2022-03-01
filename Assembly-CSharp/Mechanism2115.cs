using System;

// Token: 0x020043AF RID: 17327
public class Mechanism2115 : BeMechanism
{
	// Token: 0x0601807B RID: 98427 RVA: 0x007757F9 File Offset: 0x00773BF9
	public Mechanism2115(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601807C RID: 98428 RVA: 0x00775804 File Offset: 0x00773C04
	public override void OnInit()
	{
		this.mSkillID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.mBuffInfoID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x0601807D RID: 98429 RVA: 0x00775864 File Offset: 0x00773C64
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onCastSkill, new BeEventHandle.Del(this.onCastSkill));
		this.handleB = base.owner.RegisterEvent(BeEventType.onCastSkillFinish, new BeEventHandle.Del(this.onCastSkillFinish));
		this.handleC = base.owner.RegisterEvent(BeEventType.onAfterFinalDamageNew, new BeEventHandle.Del(this.onHitOther));
	}

	// Token: 0x0601807E RID: 98430 RVA: 0x007758CE File Offset: 0x00773CCE
	public override void OnFinish()
	{
		base.OnFinish();
		this.mDelayCaller.SetRemove(true);
	}

	// Token: 0x0601807F RID: 98431 RVA: 0x007758E4 File Offset: 0x00773CE4
	private void onCastSkill(object[] args)
	{
		int num = (int)args[0];
		if (this.mSkillID == num)
		{
			this.mUsingSkill = true;
		}
	}

	// Token: 0x06018080 RID: 98432 RVA: 0x00775910 File Offset: 0x00773D10
	private void onCastSkillFinish(object[] args)
	{
		int num = (int)args[0];
		if (this.mSkillID != num)
		{
			return;
		}
		this.mUsingSkill = false;
		if (!this.mHitSomeone)
		{
			base.owner.buffController.TryAddBuff(this.mBuffInfoID, null, false, null, 0);
			this.mDelayCaller = base.owner.delayCaller.DelayCall(0, new DelayCaller.Del(this._RemoveSkill), 0, 0, false);
		}
		this.mHitSomeone = false;
	}

	// Token: 0x06018081 RID: 98433 RVA: 0x0077598D File Offset: 0x00773D8D
	private void _RemoveSkill()
	{
		if (base.owner != null)
		{
			base.owner.RemoveSkill(this.mSkillID);
		}
	}

	// Token: 0x06018082 RID: 98434 RVA: 0x007759AC File Offset: 0x00773DAC
	private void onHitOther(object[] args)
	{
		if (!this.mUsingSkill)
		{
			return;
		}
		BeActor beActor = args[1] as BeActor;
		if (beActor == null || !beActor.isMainActor)
		{
			return;
		}
		int[] array = args[0] as int[];
		if (array == null)
		{
			return;
		}
		if (array[0] > 0)
		{
			this.mHitSomeone = true;
		}
	}

	// Token: 0x04011504 RID: 70916
	private int mSkillID;

	// Token: 0x04011505 RID: 70917
	private int mBuffInfoID;

	// Token: 0x04011506 RID: 70918
	private bool mUsingSkill;

	// Token: 0x04011507 RID: 70919
	private bool mHitSomeone;

	// Token: 0x04011508 RID: 70920
	private DelayCallUnitHandle mDelayCaller;
}
