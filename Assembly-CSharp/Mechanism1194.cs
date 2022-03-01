using System;
using System.Collections.Generic;

// Token: 0x020042F9 RID: 17145
public class Mechanism1194 : BeMechanism
{
	// Token: 0x06017B94 RID: 97172 RVA: 0x00750244 File Offset: 0x0074E644
	public Mechanism1194(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017B95 RID: 97173 RVA: 0x00750294 File Offset: 0x0074E694
	public override void OnInit()
	{
		this.mPhaseBuffInfoIDs.Clear();
		this.mAvoidSkillIDs.Clear();
		this.mPhaseBuffInfoIDs.Add(0);
		this.mBatiPhase = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			this.mPhaseBuffInfoIDs.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
		}
		this.mNoDamageReset = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.mAddBuffCDTime = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		for (int j = 0; j < this.data.ValueE.Count; j++)
		{
			this.mAvoidSkillIDs.Add(TableManager.GetValueFromUnionCell(this.data.ValueE[j], this.level, true));
		}
		this.mNotifyBuffInfoID = TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true);
		if (this.data.ValueF.Count > 1)
		{
			this.mNotifyBuffInfoID1 = TableManager.GetValueFromUnionCell(this.data.ValueF[1], this.level, true);
		}
	}

	// Token: 0x06017B96 RID: 97174 RVA: 0x0075043D File Offset: 0x0074E83D
	public override void OnStart()
	{
		this._RegistEvent();
	}

	// Token: 0x06017B97 RID: 97175 RVA: 0x00750448 File Offset: 0x0074E848
	public override void OnUpdate(int deltaTime)
	{
		if (this.mAddBuffCDTimeAcc > 0)
		{
			this.mAddBuffCDTimeAcc -= deltaTime;
			if (this.mAddBuffCDTimeAcc <= 0 && base.owner != null && base.owner.buffController != null)
			{
				base.owner.buffController.TryAddBuff(this.mNotifyBuffInfoID, 1000, 1);
			}
		}
		if (this.mNoDamageResetAcc > 0 && this.mUseSkillFlag == -1)
		{
			this.mNoDamageResetAcc -= deltaTime;
			if (this.mNoDamageResetAcc <= 0)
			{
				this.mAddBuffCDTimeAcc = this.mAddBuffCDTime;
				this.mBatiPahseAcc = 0;
			}
		}
	}

	// Token: 0x06017B98 RID: 97176 RVA: 0x007504F8 File Offset: 0x0074E8F8
	private void _RegistEvent()
	{
		if (base.owner == null)
		{
			return;
		}
		this.handleA = base.owner.RegisterEvent(BeEventType.onRemoveBuff, new BeEventHandle.Del(this.OnBuffRemoveEvent));
		this.handleB = base.owner.RegisterEvent(BeEventType.onCastSkill, new BeEventHandle.Del(this._OnCastSkill));
		this.handleC = base.owner.RegisterEvent(BeEventType.onSkillCancel, new BeEventHandle.Del(this._OnSkillCancel));
		this.handleD = base.owner.RegisterEvent(BeEventType.onCastSkillFinish, new BeEventHandle.Del(this._OnCastSkillFinish));
		this.mOnBeforeHitEvent = base.owner.RegisterEvent(BeEventType.onBeforeHit, new BeEventHandle.Del(this.OnBeforeHitEvent));
	}

	// Token: 0x06017B99 RID: 97177 RVA: 0x007505AC File Offset: 0x0074E9AC
	private void _OnSkillCancel(object[] args)
	{
		this.mUseSkillFlag = -1;
		this.mAddBuffSkillID = -1;
		this.mAddBuffHurtID = -1;
		this.mRemoveBuffSkillID = -1;
	}

	// Token: 0x06017B9A RID: 97178 RVA: 0x007505CA File Offset: 0x0074E9CA
	private void _OnCastSkillFinish(object[] args)
	{
		this.mUseSkillFlag = -1;
		this.mAddBuffSkillID = -1;
		this.mAddBuffHurtID = -1;
		this.mRemoveBuffSkillID = -1;
	}

	// Token: 0x06017B9B RID: 97179 RVA: 0x007505E8 File Offset: 0x0074E9E8
	private void _OnCastSkill(object[] args)
	{
		if (args == null || args.Length < 2)
		{
			return;
		}
		this.mUseSkillFlag = (int)args[0];
	}

	// Token: 0x06017B9C RID: 97180 RVA: 0x00750608 File Offset: 0x0074EA08
	private void OnBuffRemoveEvent(object[] args)
	{
		if (this.mBatiPahseAcc != 0)
		{
			return;
		}
		if (this.mAddBuffCDTimeAcc > 0)
		{
			return;
		}
		if (base.owner == null || base.owner.buffController == null)
		{
			return;
		}
		if (args.Length < 2)
		{
			return;
		}
		BeBuff beBuff = args[1] as BeBuff;
		if (beBuff != null && beBuff.buffData != null && beBuff.buffData.Type == 1)
		{
			this.mBatiPahseAcc = this.mBatiPhase;
			this.mNoDamageResetAcc = this.mNoDamageReset;
			this.mRemoveBuffSkillID = this.mUseSkillFlag;
			if (this.mAddBuffCDTimeAcc <= 0 && base.owner != null && base.owner.buffController != null)
			{
				base.owner.buffController.TryAddBuff(this.mNotifyBuffInfoID1, 1000, 1);
			}
		}
	}

	// Token: 0x06017B9D RID: 97181 RVA: 0x007506E7 File Offset: 0x0074EAE7
	public override void OnFinish()
	{
		if (this.mOnBeforeHitEvent != null)
		{
			this.mOnBeforeHitEvent.Remove();
			this.mOnBeforeHitEvent = null;
		}
	}

	// Token: 0x06017B9E RID: 97182 RVA: 0x00750708 File Offset: 0x0074EB08
	private void OnBeforeHitEvent(object[] args)
	{
		if (this.mUseSkillFlag == -1)
		{
			return;
		}
		if (args == null || args.Length < 4)
		{
			return;
		}
		int num = (int)args[3];
		int num2 = (int)args[2];
		BeEntity beEntity = args[0] as BeEntity;
		if (beEntity == null)
		{
			return;
		}
		int pid = beEntity.GetPID();
		if (this.mRemoveBuffSkillID == num)
		{
			return;
		}
		if (base.owner == null || base.owner.buffController == null || this.mPhaseBuffInfoIDs == null || this.mAvoidSkillIDs.Contains(num))
		{
			return;
		}
		if (this.mAddBuffSkillID == num && this.mAddBuffHurtID != num2)
		{
			if (this.mNoDamageResetAcc != 0)
			{
				this.mNoDamageResetAcc = this.mNoDamageReset;
			}
			if (this.mBatiPahseAcc + 1 < this.mPhaseBuffInfoIDs.Count)
			{
				base.owner.buffController.TryAddBuff(this.mPhaseBuffInfoIDs[this.mBatiPahseAcc + 1], null, false, null, 0);
			}
			this.mAddBuffHurtID = num2;
			if (this.mAddBuffCDTimeAcc != 0)
			{
				this.mAddBuffCDTimeAcc = this.mAddBuffCDTime;
			}
			return;
		}
		if (this.mAddBuffSkillID == num && pid == this.mAddBuffTargetPid)
		{
			if (this.mNoDamageResetAcc != 0)
			{
				this.mNoDamageResetAcc = this.mNoDamageReset;
			}
			if (this.mBatiPahseAcc + 1 < this.mPhaseBuffInfoIDs.Count)
			{
				base.owner.buffController.TryAddBuff(this.mPhaseBuffInfoIDs[this.mBatiPahseAcc + 1], null, false, null, 0);
			}
			if (this.mAddBuffCDTimeAcc != 0)
			{
				this.mAddBuffCDTimeAcc = this.mAddBuffCDTime;
			}
			return;
		}
		if (this.mBatiPahseAcc == 0)
		{
			return;
		}
		if (this.mAddBuffSkillID != num)
		{
			if (this.mNoDamageResetAcc != 0)
			{
				this.mNoDamageResetAcc = this.mNoDamageReset;
			}
			if (this.mBatiPahseAcc < this.mPhaseBuffInfoIDs.Count)
			{
				base.owner.buffController.TryAddBuff(this.mPhaseBuffInfoIDs[this.mBatiPahseAcc], null, false, null, 0);
			}
			this.mAddBuffSkillID = num;
			this.mAddBuffHurtID = num2;
			this.mAddBuffTargetPid = pid;
			this.mBatiPahseAcc--;
			this.mBatiPahseAcc = IntMath.Max(0, this.mBatiPahseAcc);
			if (this.mBatiPahseAcc == 0)
			{
				this.mAddBuffCDTimeAcc = this.mAddBuffCDTime;
				this.mNoDamageResetAcc = 0;
			}
		}
	}

	// Token: 0x040110B8 RID: 69816
	protected int mBatiPhase;

	// Token: 0x040110B9 RID: 69817
	protected int mBatiPahseAcc;

	// Token: 0x040110BA RID: 69818
	protected List<int> mPhaseBuffInfoIDs = new List<int>();

	// Token: 0x040110BB RID: 69819
	protected int mNoDamageReset;

	// Token: 0x040110BC RID: 69820
	protected int mNoDamageResetAcc;

	// Token: 0x040110BD RID: 69821
	protected int mAddBuffCDTime;

	// Token: 0x040110BE RID: 69822
	protected int mAddBuffCDTimeAcc;

	// Token: 0x040110BF RID: 69823
	protected int mUseSkillFlag = -1;

	// Token: 0x040110C0 RID: 69824
	protected BeEventHandle mOnBeforeHitEvent;

	// Token: 0x040110C1 RID: 69825
	protected int mAddBuffSkillID = -1;

	// Token: 0x040110C2 RID: 69826
	protected int mAddBuffHurtID = -1;

	// Token: 0x040110C3 RID: 69827
	protected int mAddBuffTargetPid = -1;

	// Token: 0x040110C4 RID: 69828
	protected List<int> mAvoidSkillIDs = new List<int>();

	// Token: 0x040110C5 RID: 69829
	protected int mRemoveBuffSkillID = -1;

	// Token: 0x040110C6 RID: 69830
	protected int mNotifyBuffInfoID;

	// Token: 0x040110C7 RID: 69831
	protected int mNotifyBuffInfoID1;
}
