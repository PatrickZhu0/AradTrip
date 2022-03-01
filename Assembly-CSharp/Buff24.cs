using System;
using GameClient;
using ProtoTable;

// Token: 0x02004226 RID: 16934
public class Buff24 : BeBuff
{
	// Token: 0x06017721 RID: 96033 RVA: 0x00734349 File Offset: 0x00732749
	public Buff24(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack, true)
	{
	}

	// Token: 0x06017722 RID: 96034 RVA: 0x00734374 File Offset: 0x00732774
	private void _initData()
	{
		this.mType = TableManager.GetValueFromUnionCell(this.buffData.ValueA[0], this.level, true);
		this.mRate = TableManager.GetValueFromUnionCell(this.buffData.ValueB[0], this.level, true);
		this.mHealRate = TableManager.GetValueFromUnionCell(this.buffData.ValueC[0], this.level, true);
	}

	// Token: 0x06017723 RID: 96035 RVA: 0x007343F9 File Offset: 0x007327F9
	public override void OnStart()
	{
		this._initData();
		this.handler = base.owner.RegisterEvent(BeEventType.onHit, delegate(object[] args)
		{
			if (args.Length >= 4)
			{
				EffectTable.eDamageType eDamageType = (EffectTable.eDamageType)args[3];
				int num = (int)args[0];
				BeActor beActor = args[2] as BeActor;
				if (beActor != null && eDamageType == (EffectTable.eDamageType)this.mType)
				{
					int value = num * VFactor.NewVFactor((long)this.mRate, (long)GlobalLogic.VALUE_1000);
					beActor.DoHurt(value, null, HitTextType.NORMAL, base.owner, HitTextType.NORMAL, false);
					int num2 = num * this.mHealRate / GlobalLogic.VALUE_1000;
					if (num2 > 0)
					{
						base.owner.m_pkGeActor.CreateEffect("Effects/Common/Sfx/Huifu/Prefab/Eff_Common_HP", "[actor]Body", 0f, new Vec3(0f, 0f, 0f), 1f, 1f, false, false, EffectTimeType.SYNC_ANIMATION, false);
						base.owner.DoHeal(num2, true);
					}
				}
			}
		});
	}

	// Token: 0x06017724 RID: 96036 RVA: 0x00734420 File Offset: 0x00732820
	public override void OnFinish()
	{
		if (this.handler != null)
		{
			base.owner.RemoveEvent(this.handler);
			this.handler = null;
		}
	}

	// Token: 0x04010D56 RID: 68950
	private BeEventHandle handler;

	// Token: 0x04010D57 RID: 68951
	private int mType = -1;

	// Token: 0x04010D58 RID: 68952
	private int mHealRate = GlobalLogic.VALUE_1000;

	// Token: 0x04010D59 RID: 68953
	private int mRate = GlobalLogic.VALUE_1000;
}
