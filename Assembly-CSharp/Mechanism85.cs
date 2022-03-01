using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x02004417 RID: 17431
public class Mechanism85 : BeMechanism
{
	// Token: 0x06018353 RID: 99155 RVA: 0x00789739 File Offset: 0x00787B39
	public Mechanism85(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018354 RID: 99156 RVA: 0x0078974C File Offset: 0x00787B4C
	public override void OnInit()
	{
		base.OnInit();
		this.hurtID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		if (this.data.ValueB.Length > 0)
		{
			this.height = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		}
		this.onlyMainActor = (TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true) == 1);
		this.hurtIDByDis = (TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true) == 1);
		this.dis = new VInt[this.data.ValueE.Count];
		for (int i = 0; i < this.dis.Length; i++)
		{
			this.dis[i] = TableManager.GetValueFromUnionCell(this.data.ValueE[i], this.level, true);
		}
		this.hurtIDs = new int[this.data.ValueF.Count];
		for (int j = 0; j < this.hurtIDs.Length; j++)
		{
			this.hurtIDs[j] = TableManager.GetValueFromUnionCell(this.data.ValueF[j], this.level, true);
		}
	}

	// Token: 0x06018355 RID: 99157 RVA: 0x007898E8 File Offset: 0x00787CE8
	public override void OnStart()
	{
		base.OnStart();
		List<BeEntity> list = ListPool<BeEntity>.Get();
		base.owner.CurrentBeScene.GetEntitys2(list);
		for (int i = 0; i < list.Count; i++)
		{
			BeActor beActor = list[i] as BeActor;
			if (beActor != null && beActor.GetEntityData() != null && !beActor.GetEntityData().isPet)
			{
				if (beActor.GetPID() != base.owner.GetPID() && !beActor.IsDead() && beActor.GetCamp() != base.owner.GetCamp())
				{
					if (!this.onlyMainActor || beActor.isMainActor)
					{
						VInt3 position = beActor.GetPosition();
						if (this.height != -1)
						{
							if (beActor.m_cpkCurEntityActionFrameData != null && beActor.GetPosition().z <= this.height)
							{
								position.z += VInt.one.i;
								base.owner._onHurtEntity(beActor, position, this.hurtID);
							}
						}
						else
						{
							position.z += VInt.one.i;
							if (this.hurtIDByDis)
							{
								this.hurtID = this.GetHurtIDByDis(beActor);
							}
							base.owner._onHurtEntity(beActor, position, this.hurtID);
						}
					}
				}
			}
		}
		ListPool<BeEntity>.Release(list);
	}

	// Token: 0x06018356 RID: 99158 RVA: 0x00789A68 File Offset: 0x00787E68
	private int GetHurtIDByDis(BeActor actor)
	{
		int magnitude2D = (base.owner.GetPosition() - actor.GetPosition()).magnitude2D;
		for (int i = 0; i < this.dis.Length; i++)
		{
			if (magnitude2D < this.dis[i])
			{
				return this.hurtIDs[i];
			}
		}
		return 0;
	}

	// Token: 0x0401178F RID: 71567
	private bool hurtSelf;

	// Token: 0x04011790 RID: 71568
	private int hurtID;

	// Token: 0x04011791 RID: 71569
	private int height = -1;

	// Token: 0x04011792 RID: 71570
	private bool onlyMainActor;

	// Token: 0x04011793 RID: 71571
	private bool hurtIDByDis;

	// Token: 0x04011794 RID: 71572
	private VInt[] dis;

	// Token: 0x04011795 RID: 71573
	private int[] hurtIDs;
}
