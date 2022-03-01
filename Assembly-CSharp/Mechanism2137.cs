using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x020043C7 RID: 17351
public class Mechanism2137 : BeMechanism
{
	// Token: 0x06018116 RID: 98582 RVA: 0x00779A99 File Offset: 0x00777E99
	public Mechanism2137(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018117 RID: 98583 RVA: 0x00779AA4 File Offset: 0x00777EA4
	public override void OnInit()
	{
		base.OnInit();
		this._chargeMechanismId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this._chargeSkillBuffId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this._cdTime = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x06018118 RID: 98584 RVA: 0x00779B2F File Offset: 0x00777F2F
	public override void OnStart()
	{
		base.OnStart();
		this._RegisterEvent();
		this._AddChargeSkillBuffInfo();
	}

	// Token: 0x06018119 RID: 98585 RVA: 0x00779B43 File Offset: 0x00777F43
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		this._UpdateCd(deltaTime);
	}

	// Token: 0x0601811A RID: 98586 RVA: 0x00779B53 File Offset: 0x00777F53
	public override void OnFinish()
	{
		base.OnFinish();
		this._RemoveChargeSkillBuff();
	}

	// Token: 0x0601811B RID: 98587 RVA: 0x00779B61 File Offset: 0x00777F61
	private void _UpdateCd(int deltaTime)
	{
		if (this._curCdTime <= 0)
		{
			return;
		}
		this._curCdTime -= deltaTime;
	}

	// Token: 0x0601811C RID: 98588 RVA: 0x00779B7E File Offset: 0x00777F7E
	private void _RegisterEvent()
	{
		this.handleNewA = base.owner.RegisterEventNew(BeEventType.onMishuMagicAttrChange, new BeEvent.BeEventHandleNew.Function(this._OnMishuMagicAttrChange));
	}

	// Token: 0x0601811D RID: 98589 RVA: 0x00779B9F File Offset: 0x00777F9F
	private void _OnMishuMagicAttrChange(BeEvent.BeEventParam param)
	{
		if (this._curCdTime > 0)
		{
			return;
		}
		base.owner.AddMechanism(this._chargeMechanismId, this.level, MechanismSourceType.NONE, null, int.MaxValue);
		this._curCdTime = this._cdTime;
	}

	// Token: 0x0601811E RID: 98590 RVA: 0x00779BE0 File Offset: 0x00777FE0
	private void _AddChargeSkillBuffInfo()
	{
		List<int> list = new List<int>();
		base.owner.GetChargeSkillList(list);
		BuffInfoData buffInfoData = new BuffInfoData();
		buffInfoData.buffID = this._chargeSkillBuffId;
		buffInfoData.prob = 1000;
		buffInfoData.skillIDs = list;
		base.owner.buffController.TryAddBuff(buffInfoData, null, false, default(VRate), null);
	}

	// Token: 0x0601811F RID: 98591 RVA: 0x00779C4B File Offset: 0x0077804B
	private void _RemoveChargeSkillBuff()
	{
		base.owner.buffController.RemoveBuff(this._chargeSkillBuffId, 0, 0);
	}

	// Token: 0x04011580 RID: 71040
	private int _chargeMechanismId;

	// Token: 0x04011581 RID: 71041
	private int _chargeSkillBuffId;

	// Token: 0x04011582 RID: 71042
	private int _cdTime;

	// Token: 0x04011583 RID: 71043
	private int _curCdTime;
}
