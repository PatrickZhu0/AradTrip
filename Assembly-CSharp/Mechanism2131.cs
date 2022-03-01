using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x020043C0 RID: 17344
public class Mechanism2131 : BeMechanism
{
	// Token: 0x060180E7 RID: 98535 RVA: 0x00778814 File Offset: 0x00776C14
	public Mechanism2131(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060180E8 RID: 98536 RVA: 0x00778840 File Offset: 0x00776C40
	public override void OnInit()
	{
		this.m_PosYXRate = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.m_YMinOffset = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.m_YMaxOffset = TableManager.GetValueFromUnionCell(this.data.ValueB[1], this.level, true);
		this.checkInterval = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x060180E9 RID: 98537 RVA: 0x007788ED File Offset: 0x00776CED
	public override void OnUpdate(int deltaTime)
	{
		this.UpdateCheckRange(deltaTime);
	}

	// Token: 0x060180EA RID: 98538 RVA: 0x007788F6 File Offset: 0x00776CF6
	protected void UpdateCheckRange(int deltaTime)
	{
		this.timeAcc += deltaTime;
		if (this.timeAcc >= this.checkInterval)
		{
			this.timeAcc -= this.checkInterval;
			this.CheckRange();
		}
	}

	// Token: 0x060180EB RID: 98539 RVA: 0x00778930 File Offset: 0x00776D30
	private void CheckRange()
	{
		if (base.owner == null || base.owner.CurrentBeScene == null || base.owner.m_cpkCurEntityActionFrameData == null || base.owner.m_cpkCurEntityActionFrameData.pAttackData == null || base.owner.m_cpkCurEntityActionFrameData.pAttackData.vBox == null || base.owner.m_cpkCurEntityActionFrameData.pAttackData.vBox.Count == 0)
		{
			return;
		}
		List<BeActor> list = ListPool<BeActor>.Get();
		VInt3 position = base.owner.GetPosition();
		this.m_TargetFilter.SetData(position.y + this.m_YMinOffset, position.y + this.m_YMaxOffset);
		base.owner.CurrentBeScene.FindTargets(list, base.owner, false, this.m_TargetFilter);
		VFactor scale = base.owner.GetScale().factor * base.owner.skillAttackScale;
		bool face = base.owner.GetFace();
		DBox rkBox = default(DBox);
		for (int i = 0; i < list.Count; i++)
		{
			BeActor beActor = list[i];
			if (!base.owner._checkEntityHurted(beActor))
			{
				VInt3 position2 = list[i].GetPosition();
				int num = (position2.y - position.y) * this.m_PosYXRate / 1000;
				DBox vBox = base.owner.m_cpkCurEntityActionFrameData.pAttackData.vBox[0].vBox;
				DBox vWorldBox = base.owner.m_cpkCurEntityActionFrameData.pAttackData.vBox[0].vWorldBox;
				int i2 = position.x + num;
				int i3 = position2.y * DBoxConfig.fSinA + position.z * DBoxConfig.fCosA;
				vWorldBox.offset(vBox, i2, i3, scale, face);
				BDDBoxData curWorldDefenseBox = beActor.CurWorldDefenseBox;
				int count = curWorldDefenseBox.vBox.Count;
				bool flag = false;
				for (int j = 0; j < count; j++)
				{
					DBox vWorldBox2 = curWorldDefenseBox.vBox[j].vWorldBox;
					if (vWorldBox.intersects(vWorldBox2))
					{
						vWorldBox.getIntersects(vWorldBox2, ref rkBox);
						flag = true;
						break;
					}
				}
				if (flag)
				{
					VInt3 hitPos = base.owner.GetHitPos(rkBox, beActor);
					base.owner._onHurtEntity(beActor, hitPos, base.owner.m_cpkCurEntityActionFrameData.pAttackData.hurtID);
				}
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x0401155E RID: 71006
	protected int m_BoxX;

	// Token: 0x0401155F RID: 71007
	protected int m_BoxY;

	// Token: 0x04011560 RID: 71008
	protected int m_PosYXRate;

	// Token: 0x04011561 RID: 71009
	protected int m_YMinOffset;

	// Token: 0x04011562 RID: 71010
	protected int m_YMaxOffset;

	// Token: 0x04011563 RID: 71011
	private int timeAcc;

	// Token: 0x04011564 RID: 71012
	private int checkInterval = 200;

	// Token: 0x04011565 RID: 71013
	protected List<BeActor> inRangers = new List<BeActor>();

	// Token: 0x04011566 RID: 71014
	private GetEntityByYPosFilter m_TargetFilter = new GetEntityByYPosFilter();
}
