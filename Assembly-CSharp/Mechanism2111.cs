using System;
using GameClient;

// Token: 0x020043A9 RID: 17321
public class Mechanism2111 : BeMechanism
{
	// Token: 0x06018056 RID: 98390 RVA: 0x00773F26 File Offset: 0x00772326
	public Mechanism2111(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018057 RID: 98391 RVA: 0x00773F38 File Offset: 0x00772338
	public override void OnInit()
	{
		this.mCumulateBuffID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.mCumulateNum = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.mBuffInfoID = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.mMonsterID = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
	}

	// Token: 0x06018058 RID: 98392 RVA: 0x00773FE8 File Offset: 0x007723E8
	public override void OnStart()
	{
		if (base.owner.isSpecialMonster)
		{
			base.Finish();
			return;
		}
		this._CheckCumulateBuff();
		this.handleA = base.owner.RegisterEvent(BeEventType.onAddBuff, new BeEventHandle.Del(this.onAddBuff));
		this.handleB = base.owner.RegisterEvent(BeEventType.onBuffFinish, new BeEventHandle.Del(this.onFinishBuff));
		this.handleC = base.owner.RegisterEvent(BeEventType.onHitAfterAddBuff, new BeEventHandle.Del(this.onHurt));
	}

	// Token: 0x06018059 RID: 98393 RVA: 0x00774074 File Offset: 0x00772474
	private void _CheckCumulateBuff()
	{
		int buffCountByID = base.owner.buffController.GetBuffCountByID(this.mCumulateBuffID);
		if (buffCountByID >= this.mCumulateNum)
		{
			BeBuff beBuff = base.owner.buffController.TryAddBuff(this.mBuffInfoID, null, false, null, 0);
			if (beBuff != null)
			{
				this.mBuffID = beBuff.buffID;
			}
		}
	}

	// Token: 0x0601805A RID: 98394 RVA: 0x007740D4 File Offset: 0x007724D4
	private void onAddBuff(object[] args)
	{
		BeBuff beBuff = args[0] as BeBuff;
		if (beBuff == null)
		{
			return;
		}
		if (beBuff.buffID != this.mCumulateBuffID)
		{
			return;
		}
		this._CheckCumulateBuff();
	}

	// Token: 0x0601805B RID: 98395 RVA: 0x0077410C File Offset: 0x0077250C
	private void onFinishBuff(object[] args)
	{
		int num = (int)args[0];
		if (this.mBuffID != num)
		{
			return;
		}
		this.mBuffID = -1;
		base.owner.buffController.RemoveBuff(this.mCumulateBuffID, 0, 0);
	}

	// Token: 0x0601805C RID: 98396 RVA: 0x00774150 File Offset: 0x00772550
	private void onHurt(object[] args)
	{
		if (this.mBuffID <= 0)
		{
			return;
		}
		BeActor beActor = args[2] as BeActor;
		if (beActor == null)
		{
			return;
		}
		BeActor beActor2 = beActor.GetTopOwner(beActor) as BeActor;
		if (!beActor.GetEntityData().MonsterIDEqual(this.mMonsterID) && !beActor2.GetEntityData().MonsterIDEqual(this.mMonsterID))
		{
			return;
		}
		if (base.owner.IsDead())
		{
			return;
		}
		BeMechanism mechanismByIndex = base.owner.GetMechanismByIndex(2019);
		if (mechanismByIndex != null)
		{
			return;
		}
		if ((int)args[4] == 0)
		{
			this.ShowHitNumber();
		}
		base.owner.DoDead(false);
		if (base.owner.IsDead())
		{
			base.owner.GetEntityData().SetHP(0);
			if (base.owner.m_pkGeActor != null)
			{
				base.owner.m_pkGeActor.isSyncHPMP = true;
				base.owner.m_pkGeActor.SyncHPBar();
				base.owner.m_pkGeActor.isSyncHPMP = false;
			}
		}
	}

	// Token: 0x0601805D RID: 98397 RVA: 0x00774264 File Offset: 0x00772664
	private void ShowHitNumber()
	{
		ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
		if (clientSystemBattle == null)
		{
			return;
		}
		if (clientSystemBattle.comShowHit == null)
		{
			return;
		}
		clientSystemBattle.comShowHit.ShowHitNumber(1, null, base.owner.m_iID, base.owner.GetGePosition(PositionType.OVERHEAD), base.owner.GetFace(), HitTextType.NORMAL, null, base.owner);
	}

	// Token: 0x0601805E RID: 98398 RVA: 0x007742CB File Offset: 0x007726CB
	public override void OnFinish()
	{
		base.OnFinish();
	}

	// Token: 0x040114E6 RID: 70886
	private int mCumulateBuffID;

	// Token: 0x040114E7 RID: 70887
	private int mCumulateNum;

	// Token: 0x040114E8 RID: 70888
	private int mBuffInfoID;

	// Token: 0x040114E9 RID: 70889
	private int mBuffID = -1;

	// Token: 0x040114EA RID: 70890
	private int mMonsterID;
}
