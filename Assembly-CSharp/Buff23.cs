using System;
using GameClient;

// Token: 0x02004225 RID: 16933
public class Buff23 : BeBuff
{
	// Token: 0x0601771C RID: 96028 RVA: 0x00734188 File Offset: 0x00732588
	public Buff23(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack, true)
	{
	}

	// Token: 0x0601771D RID: 96029 RVA: 0x007341B8 File Offset: 0x007325B8
	private void _initData()
	{
		this.mDamageToAttackerRate = TableManager.GetValueFromUnionCell(this.buffData.ValueA[0], this.level, true);
		this.mScaleRate = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.buffData.ValueB[0], this.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x0601771E RID: 96030 RVA: 0x00734220 File Offset: 0x00732620
	public override void OnStart()
	{
		this._initData();
		this.mOriginScale = base.owner.GetScale();
		base.owner.SetScale(this.mScaleRate);
		this.handler = base.owner.RegisterEvent(BeEventType.onHit, delegate(object[] args)
		{
			if (args.Length >= 3)
			{
				int num = (int)args[0];
				BeActor beActor = args[2] as BeActor;
				int value = num * GlobalLogic.VALUE_1000 / this.mDamageToAttackerRate;
				if (beActor != null)
				{
					beActor.DoHurt(value, null, HitTextType.NORMAL, base.owner, HitTextType.NORMAL, false);
					base.owner.m_pkGeActor.CreateEffect("Effects/Common/Sfx/Huifu/Prefab/Eff_Common_HP", "[actor]Body", 0f, new Vec3(0f, 0f, 0f), 1f, 1f, false, false, EffectTimeType.SYNC_ANIMATION, false);
					base.owner.DoHeal(num, true);
				}
			}
		});
	}

	// Token: 0x0601771F RID: 96031 RVA: 0x00734274 File Offset: 0x00732674
	public override void OnFinish()
	{
		base.owner.SetScale(this.mOriginScale);
		if (this.handler != null)
		{
			base.owner.RemoveEvent(this.handler);
			this.handler = null;
		}
	}

	// Token: 0x04010D52 RID: 68946
	private VInt mOriginScale = VInt.one;

	// Token: 0x04010D53 RID: 68947
	private BeEventHandle handler;

	// Token: 0x04010D54 RID: 68948
	private VInt mScaleRate = VInt.one;

	// Token: 0x04010D55 RID: 68949
	private int mDamageToAttackerRate = GlobalLogic.VALUE_1000;
}
