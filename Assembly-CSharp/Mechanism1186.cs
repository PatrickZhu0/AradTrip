using System;
using System.Collections.Generic;
using GameClient;
using GamePool;

// Token: 0x020042EF RID: 17135
public class Mechanism1186 : BeMechanism
{
	// Token: 0x06017B57 RID: 97111 RVA: 0x0074ECA4 File Offset: 0x0074D0A4
	public Mechanism1186(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017B58 RID: 97112 RVA: 0x0074ECC0 File Offset: 0x0074D0C0
	public override void OnInit()
	{
		this.mBuffInfoID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		if (this.data.ValueA.Count > 1)
		{
			this.mOwnerBuffInfoID = TableManager.GetValueFromUnionCell(this.data.ValueA[1], this.level, true);
		}
		if (this.data.ValueB.Count > 0)
		{
			this.mSkillID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		}
		if (this.data.ValueC.Count > 0)
		{
			this.mSkilLPhase = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		}
		this.mAddBuffCD = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
	}

	// Token: 0x06017B59 RID: 97113 RVA: 0x0074EDD7 File Offset: 0x0074D1D7
	public override void OnStart()
	{
		this._RegistEvent();
	}

	// Token: 0x06017B5A RID: 97114 RVA: 0x0074EDDF File Offset: 0x0074D1DF
	public override void OnUpdate(int deltaTime)
	{
		if (this.mAddBuffCDAcc > 0)
		{
			this.mAddBuffCDAcc -= deltaTime;
		}
	}

	// Token: 0x06017B5B RID: 97115 RVA: 0x0074EDFB File Offset: 0x0074D1FB
	private void _RegistEvent()
	{
		if (base.owner != null)
		{
			this.handleNewA = base.owner.RegisterEventNew(BeEventType.onEnterPhase, new BeEvent.BeEventHandleNew.Function(this._OnEnterPhase));
		}
	}

	// Token: 0x06017B5C RID: 97116 RVA: 0x0074EE28 File Offset: 0x0074D228
	private void _OnEnterPhase(BeEvent.BeEventParam param)
	{
		int @int = param.m_Int;
		int int2 = param.m_Int2;
		if (this.mSkillID != @int)
		{
			return;
		}
		if (this.mSkilLPhase != int2)
		{
			return;
		}
		if (this.mAddBuffCDAcc > 0)
		{
			return;
		}
		this.mAddBuffCDAcc = this.mAddBuffCD;
		this.TryAddSummonerMonsterBuff();
		if (base.owner != null && base.owner.buffController != null)
		{
			base.owner.buffController.TryAddBuff(this.mOwnerBuffInfoID, null, false, null, 0);
		}
	}

	// Token: 0x06017B5D RID: 97117 RVA: 0x0074EEB4 File Offset: 0x0074D2B4
	private void TryAddSummonerMonsterBuff()
	{
		if (base.owner.CurrentBeScene == null)
		{
			return;
		}
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.GetSummonBySummoner(list, base.owner, false, true);
		for (int i = 0; i < list.Count; i++)
		{
			BeActor beActor = list[i];
			if (beActor != null)
			{
				beActor.buffController.TryAddBuff(this.mBuffInfoID, null, false, null, 0);
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x04011092 RID: 69778
	protected int mSkillID = 2114;

	// Token: 0x04011093 RID: 69779
	protected int mSkilLPhase = 2;

	// Token: 0x04011094 RID: 69780
	protected int mBuffInfoID;

	// Token: 0x04011095 RID: 69781
	protected int mAddBuffCD;

	// Token: 0x04011096 RID: 69782
	protected int mAddBuffCDAcc;

	// Token: 0x04011097 RID: 69783
	protected int mOwnerBuffInfoID;
}
