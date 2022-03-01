using System;
using UnityEngine;

// Token: 0x020042AF RID: 17071
public class Mechanism1117 : BeMechanism
{
	// Token: 0x060179D8 RID: 96728 RVA: 0x007467D2 File Offset: 0x00744BD2
	public Mechanism1117(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060179D9 RID: 96729 RVA: 0x007467F4 File Offset: 0x00744BF4
	public override void OnInit()
	{
		this.m_EffectPath = this.data.StringValueA[0];
		this.m_StartFrame = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true).ToString();
		this.m_EndFrame = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true).ToString();
		if (this.data.ValueC.Count > 0)
		{
			this.m_EffectScale = (float)TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true) / 1000f;
		}
	}

	// Token: 0x060179DA RID: 96730 RVA: 0x007468C9 File Offset: 0x00744CC9
	public override void OnStart()
	{
		if (base.owner == null)
		{
			return;
		}
		this.handleA = base.owner.RegisterEvent(BeEventType.onSkillCurFrame, new BeEventHandle.Del(this.OnSkillCurFrame));
	}

	// Token: 0x060179DB RID: 96731 RVA: 0x007468F6 File Offset: 0x00744CF6
	public override void OnFinish()
	{
		this.ResetEffect();
	}

	// Token: 0x060179DC RID: 96732 RVA: 0x00746900 File Offset: 0x00744D00
	private void OnSkillCurFrame(object[] args)
	{
		string a = args[0] as string;
		if (a == this.m_StartFrame)
		{
			this.ResetEffect();
			this.ShowEffect();
		}
		else if (a == this.m_EndFrame)
		{
			this.ResetEffect();
		}
	}

	// Token: 0x060179DD RID: 96733 RVA: 0x00746950 File Offset: 0x00744D50
	private void ShowEffect()
	{
		if (!base.owner.isLocalActor)
		{
			return;
		}
		if (base.owner == null || base.owner.CurrentBeScene == null || base.owner.CurrentBeScene.currentGeScene == null)
		{
			return;
		}
		this.m_SceneEffect = base.owner.CurrentBeScene.currentGeScene.CreateEffect(this.m_EffectPath, 100f, this.GetSceneCenterPos(), this.m_EffectScale, 1f, true, false);
		if (this.m_SceneEffect != null)
		{
			int num = (!base.owner.GetFace()) ? 1 : -1;
			this.m_SceneEffect.SetScale(this.m_EffectScale * (float)num, this.m_EffectScale, this.m_EffectScale);
		}
	}

	// Token: 0x060179DE RID: 96734 RVA: 0x00746A1C File Offset: 0x00744E1C
	private void ResetEffect()
	{
		if (!base.owner.isLocalActor)
		{
			return;
		}
		if (this.m_SceneEffect != null)
		{
			if (base.owner == null || base.owner.CurrentBeScene == null || base.owner.CurrentBeScene.currentGeScene == null)
			{
				return;
			}
			base.owner.CurrentBeScene.currentGeScene.DestroyEffect(this.m_SceneEffect);
			this.m_SceneEffect = null;
		}
	}

	// Token: 0x060179DF RID: 96735 RVA: 0x00746A98 File Offset: 0x00744E98
	private Vec3 GetSceneCenterPos()
	{
		Vector3 vector;
		vector..ctor((float)Screen.width / 2f, (float)Screen.height / 2f, 0f);
		Ray ray = Camera.main.ScreenPointToRay(vector);
		float num = -ray.origin.y / ray.direction.y;
		Vec3 result = new Vec3(ray.GetPoint(num).x, base.owner.CurrentBeScene.logicZSize.fy, 0f);
		return result;
	}

	// Token: 0x04010F95 RID: 69525
	private string m_EffectPath = "Effects/Hero_Gungirl/Gungirl_jsuexing/Perfab/Eff_BLMG_juexing01_beijing";

	// Token: 0x04010F96 RID: 69526
	private string m_StartFrame;

	// Token: 0x04010F97 RID: 69527
	private string m_EndFrame;

	// Token: 0x04010F98 RID: 69528
	private float m_EffectScale = 1f;

	// Token: 0x04010F99 RID: 69529
	private GeEffectEx m_SceneEffect;
}
