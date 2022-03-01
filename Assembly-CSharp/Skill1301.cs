using System;
using System.Collections.Generic;

// Token: 0x02004453 RID: 17491
public class Skill1301 : BeSkill
{
	// Token: 0x0601848C RID: 99468 RVA: 0x0078FE1C File Offset: 0x0078E21C
	public Skill1301(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601848D RID: 99469 RVA: 0x0078FE7C File Offset: 0x0078E27C
	public override void OnInit()
	{
		this.mWeaponTypeList.Clear();
		this.mReplaceAttackIdList.Clear();
		this.mEffectWeaponTypeList.Clear();
		if (this.skillData.ValueA.Count > 0)
		{
			for (int i = 0; i < this.skillData.ValueA.Count; i++)
			{
				this.mWeaponTypeList.Add(TableManager.GetValueFromUnionCell(this.skillData.ValueA[i], base.level, true));
			}
		}
		if (this.skillData.ValueB.Count > 0)
		{
			for (int j = 0; j < this.skillData.ValueB.Count; j++)
			{
				this.mReplaceAttackIdList.Add(TableManager.GetValueFromUnionCell(this.skillData.ValueB[j], base.level, true));
			}
		}
		for (int k = 0; k < this.skillData.ValueC.Count; k++)
		{
			this.mEffectWeaponTypeList.Add(TableManager.GetValueFromUnionCell(this.skillData.ValueC[k], base.level, true));
		}
		for (int l = 0; l < this.skillData.ValueD.Count; l++)
		{
			this.mPveBuffIdArr[l] = TableManager.GetValueFromUnionCell(this.skillData.ValueD[l], base.level, true);
		}
		for (int m = 0; m < this.skillData.ValueE.Count; m++)
		{
			this.mPvpBuffIdArr[m] = TableManager.GetValueFromUnionCell(this.skillData.ValueE[m], base.level, true);
		}
	}

	// Token: 0x0601848E RID: 99470 RVA: 0x00790043 File Offset: 0x0078E443
	public override void OnPostInit()
	{
		this.RemoveHandle();
		this.mRebornHandle = base.owner.RegisterEvent(BeEventType.onReborn, delegate(object[] args)
		{
			this.UseEffectId();
			this.ReplaceNormalAttack();
		});
		this.RestoreAttackId();
		this.ReplaceNormalAttack();
		this.UseEffectId();
	}

	// Token: 0x0601848F RID: 99471 RVA: 0x0079007C File Offset: 0x0078E47C
	public override void OnWeaponChange()
	{
		this.OnPostInit();
	}

	// Token: 0x06018490 RID: 99472 RVA: 0x00790084 File Offset: 0x0078E484
	protected void ReplaceNormalAttack()
	{
		int weaponType = base.owner.GetWeaponType();
		for (int i = 0; i < this.mReplaceAttackIdList.Count; i++)
		{
			if (weaponType == this.mWeaponTypeList[i])
			{
				this.ReplaceAttackId(this.mReplaceAttackIdList[i]);
			}
		}
	}

	// Token: 0x06018491 RID: 99473 RVA: 0x007900E0 File Offset: 0x0078E4E0
	protected void UseEffectId()
	{
		int[] buffIdArr = (!BattleMain.IsModePvP(base.battleType)) ? this.mPveBuffIdArr : this.mPvpBuffIdArr;
		this.AddBuff(buffIdArr, false);
		if (this.mEffectWeaponTypeList.Count <= 0)
		{
			return;
		}
		if (!this.mEffectWeaponTypeList.Contains(base.owner.GetWeaponType()))
		{
			return;
		}
		this.AddBuff(buffIdArr, true);
	}

	// Token: 0x06018492 RID: 99474 RVA: 0x00790150 File Offset: 0x0078E550
	protected void AddBuff(int[] buffIdArr, bool isAdd = true)
	{
		foreach (int buffID in buffIdArr)
		{
			if (isAdd)
			{
				base.owner.buffController.TryAddBuff(buffID, int.MaxValue, base.level);
			}
			else
			{
				base.owner.buffController.RemoveBuff(buffID, 0, 0);
			}
		}
	}

	// Token: 0x06018493 RID: 99475 RVA: 0x007901B0 File Offset: 0x0078E5B0
	public override void OnCancel()
	{
		this.RestoreAttackId();
	}

	// Token: 0x06018494 RID: 99476 RVA: 0x007901B8 File Offset: 0x0078E5B8
	public override void OnFinish()
	{
		this.RestoreAttackId();
	}

	// Token: 0x06018495 RID: 99477 RVA: 0x007901C0 File Offset: 0x0078E5C0
	protected void ReplaceAttackId(int replaceAttackId)
	{
		this.mAttackData = base.owner.AddReplaceAttackId(replaceAttackId, 1);
	}

	// Token: 0x06018496 RID: 99478 RVA: 0x007901D5 File Offset: 0x0078E5D5
	protected void RestoreAttackId()
	{
		base.owner.RemoveReplaceAttackId(this.mAttackData);
	}

	// Token: 0x06018497 RID: 99479 RVA: 0x007901E8 File Offset: 0x0078E5E8
	protected void RemoveHandle()
	{
		if (this.mRebornHandle != null)
		{
			this.mRebornHandle.Remove();
			this.mRebornHandle = null;
		}
	}

	// Token: 0x04011868 RID: 71784
	protected List<int> mWeaponTypeList = new List<int>();

	// Token: 0x04011869 RID: 71785
	protected List<int> mReplaceAttackIdList = new List<int>();

	// Token: 0x0401186A RID: 71786
	protected List<int> mEffectWeaponTypeList = new List<int>();

	// Token: 0x0401186B RID: 71787
	protected int[] mPveBuffIdArr = new int[2];

	// Token: 0x0401186C RID: 71788
	protected int[] mPvpBuffIdArr = new int[2];

	// Token: 0x0401186D RID: 71789
	protected BeActor.NormalAttack mAttackData = default(BeActor.NormalAttack);

	// Token: 0x0401186E RID: 71790
	protected BeEventHandle mRebornHandle;
}
