using System;
using UnityEngine;

// Token: 0x02004262 RID: 16994
public class Mechanism1026 : BeMechanism
{
	// Token: 0x06017838 RID: 96312 RVA: 0x0073BF04 File Offset: 0x0073A304
	public Mechanism1026(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017839 RID: 96313 RVA: 0x0073BF19 File Offset: 0x0073A319
	public override void OnInit()
	{
		base.OnInit();
		this.effectPath = this.data.StringValueA[0];
	}

	// Token: 0x0601783A RID: 96314 RVA: 0x0073BF38 File Offset: 0x0073A338
	public override void OnStart()
	{
		base.OnStart();
		if (base.owner.isLocalActor)
		{
			Vec3 vec = base.owner.CurrentBeScene.GetSceneCenterPosition().vec3;
			Vector3 vector;
			vector..ctor((float)Screen.width / 2f, (float)Screen.height / 2f, 0f);
			Ray ray = Camera.main.ScreenPointToRay(vector);
			float num = -ray.origin.y / ray.direction.y;
			Vec3 initPos = new Vec3(ray.GetPoint(num).x, base.owner.CurrentBeScene.logicZSize.fy, 0f);
			this.baipingEffect = base.owner.CurrentBeScene.currentGeScene.CreateEffect(this.effectPath, 99999f, initPos, 2f, 1f, false, false);
		}
	}

	// Token: 0x0601783B RID: 96315 RVA: 0x0073C02F File Offset: 0x0073A42F
	public void RemoveEffect()
	{
		if (base.owner.isLocalActor && this.baipingEffect != null)
		{
			base.owner.CurrentBeScene.currentGeScene.DestroyEffect(this.baipingEffect);
			this.baipingEffect = null;
		}
	}

	// Token: 0x0601783C RID: 96316 RVA: 0x0073C06E File Offset: 0x0073A46E
	public override void OnFinish()
	{
		this.RemoveEffect();
		base.OnFinish();
	}

	// Token: 0x0601783D RID: 96317 RVA: 0x0073C07C File Offset: 0x0073A47C
	public override void OnDead()
	{
		this.RemoveEffect();
		base.OnDead();
	}

	// Token: 0x04010E5D RID: 69213
	private GeEffectEx baipingEffect;

	// Token: 0x04010E5E RID: 69214
	private string effectPath = "Effects/Hero_Jianhun/Eff_jianhun_juexing/Prefeb/Eff_jianhun_juexing_inbaiping";
}
