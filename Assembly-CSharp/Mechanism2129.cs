using System;
using System.Collections.Generic;
using GamePool;
using UnityEngine;

// Token: 0x020043BE RID: 17342
public class Mechanism2129 : BeMechanism
{
	// Token: 0x060180D4 RID: 98516 RVA: 0x007780B7 File Offset: 0x007764B7
	public Mechanism2129(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060180D5 RID: 98517 RVA: 0x007780CC File Offset: 0x007764CC
	public override void OnInit()
	{
		this.m_MinXLimitOffset = (float)(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true) / 1000);
		this.m_MaxXLimitOffset = (float)(TableManager.GetValueFromUnionCell(this.data.ValueA[1], this.level, true) / 1000);
		this.m_MinXLimitBeginOffset = (float)(TableManager.GetValueFromUnionCell(this.data.ValueA[2], this.level, true) / 1000);
		this.m_MaxXLimitBeginOffset = (float)(TableManager.GetValueFromUnionCell(this.data.ValueA[3], this.level, true) / 1000);
		int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.mSetOffsetTime = ((valueFromUnionCell != 0) ? ((float)valueFromUnionCell) : this.mSetOffsetTime);
	}

	// Token: 0x060180D6 RID: 98518 RVA: 0x007781D1 File Offset: 0x007765D1
	public override void OnStart()
	{
		this.mSetOffsetTimeAcc = 0;
		this.SetCameraControl();
		this.RemoveSameMidMechanism();
	}

	// Token: 0x060180D7 RID: 98519 RVA: 0x007781E6 File Offset: 0x007765E6
	public override void OnUpdateGraphic(int deltaTime)
	{
		this.SetOffsetByDeltaTime(deltaTime);
	}

	// Token: 0x060180D8 RID: 98520 RVA: 0x007781F0 File Offset: 0x007765F0
	protected void SetOffsetByDeltaTime(int deltaTime)
	{
		this.mSetOffsetTimeAcc += deltaTime;
		float min = Mathf.Lerp(this.m_MinXLimitBeginOffset, this.m_MinXLimitOffset, (float)this.mSetOffsetTimeAcc / this.mSetOffsetTime);
		float max = Mathf.Lerp(this.m_MaxXLimitBeginOffset, this.m_MaxXLimitOffset, (float)this.mSetOffsetTimeAcc / this.mSetOffsetTime);
		this.SetCameraXLimitOffset(min, max);
	}

	// Token: 0x060180D9 RID: 98521 RVA: 0x00778253 File Offset: 0x00776653
	protected void SetCameraXLimitOffset(float min, float max)
	{
		if (this.mCameraControl == null)
		{
			return;
		}
		this.mCameraControl.SetXLimitOffset(min, max);
	}

	// Token: 0x060180DA RID: 98522 RVA: 0x00778274 File Offset: 0x00776674
	protected void SetCameraControl()
	{
		if (base.owner.CurrentBeScene == null || base.owner.CurrentBeScene.currentGeScene == null || base.owner.CurrentBeScene.currentGeScene.GetCamera() == null || base.owner.CurrentBeScene.currentGeScene.GetCamera().GetController() == null)
		{
			return;
		}
		this.mCameraControl = base.owner.CurrentBeScene.currentGeScene.GetCamera().GetController();
	}

	// Token: 0x060180DB RID: 98523 RVA: 0x00778308 File Offset: 0x00776708
	private void RemoveSameMidMechanism()
	{
		if (base.owner != null)
		{
			List<BeMechanism> list = ListPool<BeMechanism>.Get();
			base.owner.GetMechanismsByIndex(list, base.GetMechanismIndex());
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] != null && list[i] != this)
				{
					list[i].Finish();
				}
			}
			ListPool<BeMechanism>.Release(list);
		}
	}

	// Token: 0x060180DC RID: 98524 RVA: 0x0077837A File Offset: 0x0077677A
	public override void OnFinish()
	{
		if (this.mCameraControl != null)
		{
			this.mCameraControl.SetXLimitOffset(0f, 0f);
		}
	}

	// Token: 0x04011551 RID: 70993
	protected float m_MinXLimitOffset;

	// Token: 0x04011552 RID: 70994
	protected float m_MaxXLimitOffset;

	// Token: 0x04011553 RID: 70995
	protected float m_MinXLimitBeginOffset;

	// Token: 0x04011554 RID: 70996
	protected float m_MaxXLimitBeginOffset;

	// Token: 0x04011555 RID: 70997
	protected float m_MinOffsetStart;

	// Token: 0x04011556 RID: 70998
	protected float m_MaxOffsetStart;

	// Token: 0x04011557 RID: 70999
	protected float mSetOffsetTime = 300f;

	// Token: 0x04011558 RID: 71000
	protected int mSetOffsetTimeAcc;

	// Token: 0x04011559 RID: 71001
	protected GeCameraControllerScroll mCameraControl;
}
