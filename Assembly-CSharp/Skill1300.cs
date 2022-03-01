using System;
using System.Collections.Generic;

// Token: 0x02004452 RID: 17490
public class Skill1300 : BeSkill
{
	// Token: 0x0601847D RID: 99453 RVA: 0x0078F758 File Offset: 0x0078DB58
	public Skill1300(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601847E RID: 99454 RVA: 0x0078F7C5 File Offset: 0x0078DBC5
	public override void OnPostInit()
	{
		this.mXForceCutRate = TableManager.GetValueFromUnionCell(this.skillData.ValueD[0], base.level, true);
	}

	// Token: 0x0601847F RID: 99455 RVA: 0x0078F7EC File Offset: 0x0078DBEC
	public override void OnInit()
	{
		this.mStreSilverBuffId = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.mIceBuffId = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
		this.mFireBuffId = TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true);
		this.mXForceCutRate = TableManager.GetValueFromUnionCell(this.skillData.ValueD[0], base.level, true);
		for (int i = 0; i < this.skillData.ValueE.Count; i++)
		{
			this.effectIdList.Add(TableManager.GetValueFromUnionCell(this.skillData.ValueE[i], base.level, true));
		}
		this.mStartXDis = TableManager.GetValueFromUnionCell(this.skillData.ValueG[0], base.level, true);
		this.RemoveHandle();
		this.mBuffAddHandle = base.owner.RegisterEvent(BeEventType.onAddBuff, delegate(object[] args)
		{
			BeBuff beBuff = (BeBuff)args[0];
			if (beBuff != null && (this.mStreSilverBuffId == beBuff.buffID || this.mFireBuffId == beBuff.buffID || this.mIceBuffId == beBuff.buffID))
			{
				this.mUsedBuffId = beBuff.buffID;
			}
		});
		this.mBuffFinishHandle = base.owner.RegisterEvent(BeEventType.onBuffFinish, delegate(object[] args)
		{
			int num = (int)args[0];
			if (num == this.mUsedBuffId)
			{
				this.mUsedBuffId = 0;
			}
		});
		this.mBuffRemoveHandle = base.owner.RegisterEvent(BeEventType.onRemoveBuff, delegate(object[] args)
		{
			int num = (int)args[0];
			if (num == this.mUsedBuffId)
			{
				this.mUsedBuffId = 0;
			}
		});
		this.mPreSkillPhaseHandle = base.owner.RegisterEvent(BeEventType.onPreSetSkillAction, delegate(object[] args)
		{
			int[] array = (int[])args[0];
			if (array[0] == this.mOriginalPhaseId && this.mUsedBuffId != 0)
			{
				if (this.mStreSilverBuffId == this.mUsedBuffId)
				{
					array[0] = this.mReplacePhaseIdSilver;
				}
				else if (this.mFireBuffId == this.mUsedBuffId)
				{
					array[0] = this.mReplacePhaseIdFire;
				}
				else if (this.mIceBuffId == this.mUsedBuffId)
				{
					array[0] = this.mReplacePhaseIdIce;
				}
			}
		});
		this.mRebornHandle = base.owner.RegisterEvent(BeEventType.onReborn, delegate(object[] args)
		{
			this.mUsedBuffId = 0;
		});
	}

	// Token: 0x06018480 RID: 99456 RVA: 0x0078F998 File Offset: 0x0078DD98
	public override void OnStart()
	{
		this.mXPosition = base.owner.GetPosition().x;
		this.mFace = base.owner.GetFace();
		this.mAfterGenBulletHandle = base.owner.RegisterEvent(BeEventType.onAfterGenBullet, delegate(object[] arg2)
		{
			BeProjectile beProjectile = arg2[0] as BeProjectile;
			if (beProjectile != null)
			{
				this.mHitHandle = beProjectile.RegisterEvent(BeEventType.onHitOther, delegate(object[] args)
				{
					BeActor target = args[0] as BeActor;
					int item = (int)args[1];
					if (target != null && this.effectIdList.Contains(item) && !this.targetList.Contains(target.GetPID()))
					{
						this.targetList.Add(target.GetPID());
						this.mChangeXRateHandle.Add(target.RegisterEvent(BeEventType.onChangeXRate, delegate(object[] arg1)
						{
							int item2 = (int)arg1[0];
							if (this.effectIdList.Contains(item2))
							{
								int[] array = (int[])arg1[1];
								int x = target.GetPosition().x;
								if (Math.Abs(x - this.mXPosition) <= this.mStartXDis)
								{
									return;
								}
								array[0] += (this.mFace ? -1 : 1) * this.mXForceCutRate * (x - this.mXPosition) / 1000;
							}
						}));
					}
				});
			}
		});
	}

	// Token: 0x06018481 RID: 99457 RVA: 0x0078F9EE File Offset: 0x0078DDEE
	public override void OnCancel()
	{
		this.ClearNewHandleEvent();
		this.targetList.Clear();
	}

	// Token: 0x06018482 RID: 99458 RVA: 0x0078FA01 File Offset: 0x0078DE01
	public override void OnFinish()
	{
		this.ClearNewHandleEvent();
		this.targetList.Clear();
	}

	// Token: 0x06018483 RID: 99459 RVA: 0x0078FA14 File Offset: 0x0078DE14
	protected void RemoveHandle()
	{
		if (this.mBuffAddHandle != null)
		{
			this.mBuffAddHandle.Remove();
			this.mBuffAddHandle = null;
		}
		if (this.mBuffRemoveHandle != null)
		{
			this.mBuffRemoveHandle.Remove();
			this.mBuffRemoveHandle = null;
		}
		if (this.mPreSkillPhaseHandle != null)
		{
			this.mPreSkillPhaseHandle.Remove();
			this.mPreSkillPhaseHandle = null;
		}
		if (this.mRebornHandle != null)
		{
			this.mRebornHandle.Remove();
			this.mRebornHandle = null;
		}
		if (this.mBuffFinishHandle != null)
		{
			this.mBuffFinishHandle.Remove();
			this.mBuffFinishHandle = null;
		}
	}

	// Token: 0x06018484 RID: 99460 RVA: 0x0078FAB4 File Offset: 0x0078DEB4
	private void ClearNewHandleEvent()
	{
		if (this.mHitHandle != null)
		{
			this.mHitHandle.Remove();
			this.mHitHandle = null;
		}
		for (int i = 0; i < this.mChangeXRateHandle.Count; i++)
		{
			this.mChangeXRateHandle[i].Remove();
			this.mChangeXRateHandle[i] = null;
		}
		this.mChangeXRateHandle.Clear();
		if (this.mAfterGenBulletHandle != null)
		{
			this.mAfterGenBulletHandle.Remove();
			this.mAfterGenBulletHandle = null;
		}
	}

	// Token: 0x04011852 RID: 71762
	protected int mStreSilverBuffId;

	// Token: 0x04011853 RID: 71763
	protected int mIceBuffId;

	// Token: 0x04011854 RID: 71764
	protected int mFireBuffId;

	// Token: 0x04011855 RID: 71765
	protected int mOriginalPhaseId = 1300;

	// Token: 0x04011856 RID: 71766
	protected int mReplacePhaseIdSilver = 13002;

	// Token: 0x04011857 RID: 71767
	protected int mReplacePhaseIdFire = 13003;

	// Token: 0x04011858 RID: 71768
	protected int mReplacePhaseIdIce = 13004;

	// Token: 0x04011859 RID: 71769
	protected int mUsedBuffId;

	// Token: 0x0401185A RID: 71770
	protected int mXForceCutRate;

	// Token: 0x0401185B RID: 71771
	protected List<int> effectIdList = new List<int>();

	// Token: 0x0401185C RID: 71772
	protected List<int> targetList = new List<int>();

	// Token: 0x0401185D RID: 71773
	protected int mXPosition;

	// Token: 0x0401185E RID: 71774
	protected bool mFace;

	// Token: 0x0401185F RID: 71775
	protected int mStartXDis = 1000;

	// Token: 0x04011860 RID: 71776
	protected BeEventHandle mBuffAddHandle;

	// Token: 0x04011861 RID: 71777
	protected BeEventHandle mBuffFinishHandle;

	// Token: 0x04011862 RID: 71778
	protected BeEventHandle mBuffRemoveHandle;

	// Token: 0x04011863 RID: 71779
	protected BeEventHandle mPreSkillPhaseHandle;

	// Token: 0x04011864 RID: 71780
	protected BeEventHandle mRebornHandle;

	// Token: 0x04011865 RID: 71781
	protected List<BeEventHandle> mChangeXRateHandle = new List<BeEventHandle>();

	// Token: 0x04011866 RID: 71782
	protected BeEventHandle mHitHandle;

	// Token: 0x04011867 RID: 71783
	protected BeEventHandle mAfterGenBulletHandle;
}
