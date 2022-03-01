using System;
using System.Collections.Generic;

// Token: 0x020042F7 RID: 17143
public class Mechanism1192 : BeMechanism
{
	// Token: 0x06017B86 RID: 97158 RVA: 0x0074FCA9 File Offset: 0x0074E0A9
	public Mechanism1192(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017B87 RID: 97159 RVA: 0x0074FCCC File Offset: 0x0074E0CC
	public override void OnInit()
	{
		base.OnInit();
		this._damagePercent = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true), GlobalLogic.VALUE_1000);
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			this._monsterIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
		}
	}

	// Token: 0x06017B88 RID: 97160 RVA: 0x0074FD5F File Offset: 0x0074E15F
	public override void OnStart()
	{
		base.OnStart();
		this._RegisterEvent();
	}

	// Token: 0x06017B89 RID: 97161 RVA: 0x0074FD6D File Offset: 0x0074E16D
	private void _RegisterEvent()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onAfterFinalDamageNew, new BeEventHandle.Del(this._OnHitOther));
	}

	// Token: 0x06017B8A RID: 97162 RVA: 0x0074FD90 File Offset: 0x0074E190
	private void _OnHitOther(object[] args)
	{
		BeEntity beEntity = args[1] as BeEntity;
		if (beEntity == null)
		{
			return;
		}
		if (!this._CheckMonsterId(beEntity))
		{
			return;
		}
		int hp = beEntity.GetEntityData().GetHP();
		int num = hp * this._damagePercent;
		int[] array = (int[])args[0];
		array[0] = num;
	}

	// Token: 0x06017B8B RID: 97163 RVA: 0x0074FDE0 File Offset: 0x0074E1E0
	private bool _CheckMonsterId(BeEntity entity)
	{
		if (entity == null)
		{
			return false;
		}
		for (int i = 0; i < this._monsterIdList.Count; i++)
		{
			if (entity.GetEntityData().MonsterIDEqual(this._monsterIdList[i]))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x040110B1 RID: 69809
	private VFactor _damagePercent = VFactor.zero;

	// Token: 0x040110B2 RID: 69810
	private List<int> _monsterIdList = new List<int>();
}
