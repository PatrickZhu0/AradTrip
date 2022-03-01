using System;
using GameClient;
using ProtoTable;

// Token: 0x02004333 RID: 17203
public class Mechanism20 : BeMechanism
{
	// Token: 0x06017CC9 RID: 97481 RVA: 0x007594A7 File Offset: 0x007578A7
	public Mechanism20(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017CCA RID: 97482 RVA: 0x007594C8 File Offset: 0x007578C8
	public override void OnInit()
	{
		this.mType = (ReflectType)TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.mRate = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.mHealRate = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x06017CCB RID: 97483 RVA: 0x0075954D File Offset: 0x0075794D
	public override void OnStart()
	{
		this.handler = base.owner.RegisterEvent(BeEventType.onHit, delegate(object[] args)
		{
			if (args.Length >= 4)
			{
				EffectTable.eDamageType eDamageType = (EffectTable.eDamageType)args[3];
				int num = (int)args[0];
				BeActor beActor = args[2] as BeActor;
				int num2 = (int)args[4];
				if (beActor != null && num2 != 999801 && eDamageType == (EffectTable.eDamageType)this.mType)
				{
					int num3 = IntMath.Float2Int((float)num * ((float)this.mRate / (float)GlobalLogic.VALUE_1000));
					if (num3 != 0)
					{
						beActor.DoHurt(num3, null, HitTextType.NORMAL, base.owner, HitTextType.NORMAL, false);
					}
					int num4 = num * this.mHealRate / 1000;
					if (num4 > 0)
					{
						base.owner.m_pkGeActor.CreateEffect("Effects/Common/Sfx/Huifu/Prefab/Eff_Common_HP", "[actor]Body", 0f, new Vec3(0f, 0f, 0f), 1f, 1f, false, false, EffectTimeType.SYNC_ANIMATION, false);
						base.owner.DoHeal(num4, true);
					}
				}
			}
		});
	}

	// Token: 0x06017CCC RID: 97484 RVA: 0x0075956E File Offset: 0x0075796E
	public override void OnFinish()
	{
		if (this.handler != null)
		{
			base.owner.RemoveEvent(this.handler);
			this.handler = null;
		}
	}

	// Token: 0x040111F4 RID: 70132
	private ReflectType mType;

	// Token: 0x040111F5 RID: 70133
	private int mHealRate = 1000;

	// Token: 0x040111F6 RID: 70134
	private int mRate = 1000;

	// Token: 0x040111F7 RID: 70135
	private BeEventHandle handler;
}
