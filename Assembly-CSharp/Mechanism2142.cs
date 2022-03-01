using System;

// Token: 0x020043CC RID: 17356
public class Mechanism2142 : BeMechanism
{
	// Token: 0x0601813B RID: 98619 RVA: 0x0077A486 File Offset: 0x00778886
	public Mechanism2142(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601813C RID: 98620 RVA: 0x0077A490 File Offset: 0x00778890
	public override void OnInit()
	{
		base.OnInit();
		this.m_IdleTime = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.m_BuffId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.m_IdleTimeAcc = 0;
	}

	// Token: 0x0601813D RID: 98621 RVA: 0x0077A4FC File Offset: 0x007788FC
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (base.owner.sgGetCurrentState() == 15 || base.owner.sgGetCurrentState() == 4 || base.owner.sgGetCurrentState() == 9 || base.owner.sgGetCurrentState() == 13)
		{
			this.m_IdleTimeAcc = 0;
		}
		else
		{
			this.m_IdleTimeAcc += deltaTime;
			if (this.m_IdleTimeAcc >= this.m_IdleTime)
			{
				base.owner.buffController.RemoveBuff(this.m_BuffId, 0, 0);
				if (this.attachBuff != null)
				{
					base.owner.buffController.RemoveBuff(this.attachBuff);
				}
				else
				{
					base.Finish();
				}
			}
		}
	}

	// Token: 0x04011593 RID: 71059
	private int m_IdleTimeAcc;

	// Token: 0x04011594 RID: 71060
	private int m_IdleTime;

	// Token: 0x04011595 RID: 71061
	private int m_BuffId;
}
