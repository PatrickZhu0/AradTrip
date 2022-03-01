using System;

// Token: 0x020043BD RID: 17341
public class Mechanism2128 : BeMechanism
{
	// Token: 0x060180CD RID: 98509 RVA: 0x00777D68 File Offset: 0x00776168
	public Mechanism2128(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060180CE RID: 98510 RVA: 0x00777D74 File Offset: 0x00776174
	public override void OnInit()
	{
		int valueALength = this.data.ValueALength;
		this.mPosAry = new VInt3[valueALength];
		for (int i = 0; i < valueALength; i++)
		{
			this.mPosAry[i] = new VInt3(this.data.ValueA[i].fixInitValue, this.data.ValueA[i].fixLevelGrow, 0);
		}
		this.mStartIndex = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.mMoveTime = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.mWaitTime = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		this.mSkillID = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		this.mMoveTotalNum = TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true);
	}

	// Token: 0x060180CF RID: 98511 RVA: 0x00777EB6 File Offset: 0x007762B6
	public override void OnStart()
	{
		this.mWaitTimeAcc = this.mWaitTime;
		this.mMoveTotalNumAcc = 0;
		this.mNowPosIndex = this.mStartIndex;
	}

	// Token: 0x060180D0 RID: 98512 RVA: 0x00777ED8 File Offset: 0x007762D8
	public override void OnUpdate(int deltaTime)
	{
		this.mWaitTimeAcc += deltaTime;
		if (this.mWaitTimeAcc >= this.mWaitTime)
		{
			this.mWaitTimeAcc -= this.mWaitTime;
			if (this.mMoveTotalNum == this.mMoveTotalNumAcc)
			{
				base.Finish();
				return;
			}
			this.DoRandomMove();
		}
	}

	// Token: 0x060180D1 RID: 98513 RVA: 0x00777F35 File Offset: 0x00776335
	public override void OnFinish()
	{
		if (base.owner != null)
		{
			base.owner.actionManager.StopAll();
			base.owner.UseSkill(this.mSkillID, true);
		}
	}

	// Token: 0x060180D2 RID: 98514 RVA: 0x00777F68 File Offset: 0x00776368
	protected void DoRandomMove()
	{
		if (this.mPosAry == null || this.mPosAry.Length < 2)
		{
			return;
		}
		if (this.mNowPosIndex == 0)
		{
			this.mNowPosIndex = 1;
		}
		else if (this.mNowPosIndex == this.mPosAry.Length - 1)
		{
			this.mNowPosIndex = this.mPosAry.Length - 2;
		}
		else
		{
			int num = (int)base.FrameRandom.Range1000();
			if (num < 500)
			{
				this.mNowPosIndex--;
			}
			else
			{
				this.mNowPosIndex++;
			}
		}
		this.mMoveTotalNumAcc++;
		if (this.mMoveTotalNum == this.mMoveTotalNumAcc)
		{
			this.mNowPosIndex = this.mStartIndex;
			this.mWaitTime = this.mMoveTime;
		}
		this.DoMove();
	}

	// Token: 0x060180D3 RID: 98515 RVA: 0x00778048 File Offset: 0x00776448
	protected void DoMove()
	{
		if (base.owner != null)
		{
			base.owner.actionManager.StopAll();
			BeMoveTo action = BeMoveTo.Create(base.owner, this.mMoveTime, base.owner.GetPosition(), this.mPosAry[this.mNowPosIndex], true, null, false);
			base.owner.actionManager.RunAction(action);
		}
	}

	// Token: 0x04011548 RID: 70984
	protected VInt3[] mPosAry;

	// Token: 0x04011549 RID: 70985
	protected int mStartIndex;

	// Token: 0x0401154A RID: 70986
	protected int mMoveTime;

	// Token: 0x0401154B RID: 70987
	protected int mWaitTime;

	// Token: 0x0401154C RID: 70988
	protected int mMoveTotalNum;

	// Token: 0x0401154D RID: 70989
	protected int mSkillID;

	// Token: 0x0401154E RID: 70990
	protected int mWaitTimeAcc;

	// Token: 0x0401154F RID: 70991
	protected int mMoveTotalNumAcc;

	// Token: 0x04011550 RID: 70992
	protected int mNowPosIndex;
}
