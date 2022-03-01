using System;
using System.Collections.Generic;
using Battle;
using UnityEngine;

// Token: 0x020043E7 RID: 17383
public class Mechanism40 : BeMechanism
{
	// Token: 0x060181FA RID: 98810 RVA: 0x0078033A File Offset: 0x0077E73A
	public Mechanism40(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060181FB RID: 98811 RVA: 0x00780368 File Offset: 0x0077E768
	public override void OnInit()
	{
		this.m_EffectPath = this.data.StringValueA[0];
		this.m_AttachBuffId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		if (this.data.ValueB.Count > 0)
		{
			for (int i = 0; i < this.data.ValueB.Count; i++)
			{
				int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
				this.m_RemoveBuffList.Add(valueFromUnionCell);
			}
		}
	}

	// Token: 0x060181FC RID: 98812 RVA: 0x0078041A File Offset: 0x0077E81A
	public override void OnUpdate(int deltaTime)
	{
		if (this.GetAttachNum() > 0)
		{
			this.AddEffect(this.GetAttachNum());
		}
	}

	// Token: 0x060181FD RID: 98813 RVA: 0x00780434 File Offset: 0x0077E834
	protected int GetAttachNum()
	{
		return base.owner.buffController.GetBuffCountByID(this.m_AttachBuffId);
	}

	// Token: 0x060181FE RID: 98814 RVA: 0x0078045C File Offset: 0x0077E85C
	protected void AddEffect(int attachNum)
	{
		if (attachNum == this.m_LastAttachNum)
		{
			return;
		}
		this.m_LastAttachNum = attachNum;
		this.HideOtherEffect(attachNum);
		for (int i = 0; i < attachNum; i++)
		{
			GeEffectEx geEffectEx;
			if (this.m_EffectList.Count > i)
			{
				geEffectEx = this.m_EffectList[i];
				geEffectEx.SetVisible(true);
			}
			else
			{
				geEffectEx = this.CreateEffect();
				this.m_EffectList.Add(geEffectEx);
				GameObject attachNode = base.owner.m_pkGeActor.GetAttachNode("[actor]Orign");
				GeUtility.AttachTo(geEffectEx.GetRootNode(), attachNode, false);
			}
			this.SetEffectPos(geEffectEx, i);
		}
	}

	// Token: 0x060181FF RID: 98815 RVA: 0x00780504 File Offset: 0x0077E904
	protected void SetEffectPos(GeEffectEx effect, int index)
	{
		if (effect == null)
		{
			return;
		}
		Vector3 zero = Vector3.zero;
		Vector3 overHeadPosition = base.owner.m_pkGeActor.GetOverHeadPosition();
		if (index != 0)
		{
			if (index != 1)
			{
				if (index == 2)
				{
					zero..ctor(-0.4f, overHeadPosition.y - 0.4f, -0.5f);
				}
			}
			else
			{
				zero..ctor(-0.4f, overHeadPosition.y / 2f, -0.5f);
			}
		}
		else
		{
			zero..ctor(-0.4f, 0.4f, -0.5f);
		}
		effect.SetLocalPosition(zero);
		int num = (!base.owner.GetFace()) ? 1 : -1;
		effect.SetScale((float)num, 1f, 1f);
	}

	// Token: 0x06018200 RID: 98816 RVA: 0x007805DC File Offset: 0x0077E9DC
	protected GeEffectEx CreateEffect()
	{
		return base.owner.m_pkGeActor.CreateEffect(this.m_EffectPath, null, 99999f, Vec3.zero, 1f, 1f, false, false, EffectTimeType.BUFF, false);
	}

	// Token: 0x06018201 RID: 98817 RVA: 0x0078061C File Offset: 0x0077EA1C
	protected void HideOtherEffect(int currNum)
	{
		if (this.m_EffectList.Count > currNum)
		{
			for (int i = currNum - 1; i < this.m_EffectList.Count; i++)
			{
				this.m_EffectList[i].SetVisible(false);
			}
		}
	}

	// Token: 0x06018202 RID: 98818 RVA: 0x0078066C File Offset: 0x0077EA6C
	protected void RemoveBuff()
	{
		for (int i = 0; i < this.m_RemoveBuffList.Count; i++)
		{
			base.owner.buffController.RemoveBuff(this.m_RemoveBuffList[0], 0, 0);
		}
	}

	// Token: 0x06018203 RID: 98819 RVA: 0x007806B4 File Offset: 0x0077EAB4
	protected void RemoveEffect()
	{
		for (int i = 0; i < this.m_EffectList.Count; i++)
		{
			base.owner.m_pkGeActor.DestroyEffect(this.m_EffectList[i]);
		}
		this.m_EffectList.Clear();
	}

	// Token: 0x06018204 RID: 98820 RVA: 0x00780704 File Offset: 0x0077EB04
	public override void OnFinish()
	{
		this.RemoveBuff();
		this.RemoveEffect();
	}

	// Token: 0x04011657 RID: 71255
	protected string m_EffectPath = "Actor/Effe_Wyzls/Effe_Wyzls/Prefabs/p_Effe_Wyzls";

	// Token: 0x04011658 RID: 71256
	protected int m_AttachBuffId;

	// Token: 0x04011659 RID: 71257
	protected List<int> m_RemoveBuffList = new List<int>();

	// Token: 0x0401165A RID: 71258
	protected List<GeEffectEx> m_EffectList = new List<GeEffectEx>();

	// Token: 0x0401165B RID: 71259
	protected int m_LastAttachNum;
}
