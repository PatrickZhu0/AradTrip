using System;

// Token: 0x0200412A RID: 16682
public class BeAbnormalBuff : BeBuff
{
	// Token: 0x06016B5C RID: 93020 RVA: 0x006E7604 File Offset: 0x006E5A04
	public BeAbnormalBuff(int bi, int buffLevel, int buffDuration, int attack = 0, bool buffEffectAni = true) : base(bi, buffLevel, buffDuration, attack, buffEffectAni)
	{
	}

	// Token: 0x06016B5D RID: 93021 RVA: 0x006E7628 File Offset: 0x006E5A28
	public override void OnUpdate(int delta)
	{
		base.OnUpdate(delta);
		this.UpdateAbnormalDamage(delta);
	}

	// Token: 0x06016B5E RID: 93022 RVA: 0x006E7638 File Offset: 0x006E5A38
	public override void OnFinish()
	{
		base.OnFinish();
		this.ChangeAbnormalData();
	}

	// Token: 0x06016B5F RID: 93023 RVA: 0x006E7646 File Offset: 0x006E5A46
	public override int GetAloneAbnormalDamage()
	{
		if (this.abnormalAttack > 0)
		{
			return this.abnormalAttack;
		}
		this.abnormalAttack = base.GetAbnromalDamage(this.buffAttack, this.duration);
		return this.abnormalAttack;
	}

	// Token: 0x06016B60 RID: 93024 RVA: 0x006E7684 File Offset: 0x006E5A84
	private void ChangeAbnormalData()
	{
		if (this.abnormalBuffData.isFinish || !this.abnormalBuffData.isFirst)
		{
			return;
		}
		this.abnormalBuffData.isFinish = true;
		this.abnormalBuffData.isFirst = false;
		BeBuff buffButSelf = base.owner.buffController.GetBuffButSelf(this, this.buffID);
		if (buffButSelf != null)
		{
			buffButSelf.abnormalBuffData.isFirst = true;
		}
		BeBuff firstAbnormalBuff = base.owner.buffController.GetFirstAbnormalBuff(this.buffID);
		if (firstAbnormalBuff == null)
		{
			return;
		}
		if (this.abnormalBuffData.lastDamageAcc != 0)
		{
			firstAbnormalBuff.abnormalBuffData.curAbnormalTimeAcc = this.duration - this.abnormalBuffData.lastDamageAcc;
		}
		else
		{
			firstAbnormalBuff.abnormalBuffData.curAbnormalTimeAcc = this.abnormalBuffData.curAbnormalTimeAcc;
		}
	}

	// Token: 0x06016B61 RID: 93025 RVA: 0x006E7760 File Offset: 0x006E5B60
	private void UpdateAbnormalDamage(int delta)
	{
		if (!this.abnormalBuffData.isFirst)
		{
			return;
		}
		if (this.buffData.TriggerInterval <= 0)
		{
			return;
		}
		if (this.abnormalBuffData.curAbnormalTimeAcc >= this.buffData.TriggerInterval)
		{
			int num = base.owner.buffController.GetAbnormalDamage(this.buffID);
			if (num <= 0)
			{
				return;
			}
			this.interParams[0] = this;
			int[] array = this.interParams[1] as int[];
			array[0] = num;
			base.owner.TriggerEvent(BeEventType.AbnormalBuffHurt, this.interParams);
			num = array[0];
			if (base.owner.CurrentBeScene != null)
			{
				base.owner.CurrentBeScene.TriggerEvent(BeEventSceneType.onHurtByAbnormalBuff, new object[]
				{
					num,
					base.releaser,
					base.owner,
					this.skillId
				});
			}
			base.DoBuffAttack(num);
			this.abnormalBuffData.curAbnormalTimeAcc = 0;
			if (this.duration > base.runTime)
			{
				this.abnormalBuffData.lastDamageAcc = base.runTime;
			}
		}
		else
		{
			this.abnormalBuffData.curAbnormalTimeAcc = this.abnormalBuffData.curAbnormalTimeAcc + delta;
		}
	}

	// Token: 0x0401038D RID: 66445
	protected int abnormalAttack;

	// Token: 0x0401038E RID: 66446
	protected object[] interParams = new object[]
	{
		null,
		new int[1]
	};
}
