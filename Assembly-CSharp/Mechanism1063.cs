using System;
using System.Collections.Generic;

// Token: 0x02004288 RID: 17032
public class Mechanism1063 : BeMechanism
{
	// Token: 0x0601790F RID: 96527 RVA: 0x00740F34 File Offset: 0x0073F334
	public Mechanism1063(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017910 RID: 96528 RVA: 0x00740F90 File Offset: 0x0073F390
	public override void OnInit()
	{
		base.OnInit();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			Mechanism1063.EntityData item = default(Mechanism1063.EntityData);
			item.entityId = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
			item.num = TableManager.GetValueFromUnionCell(this.data.ValueC[i], this.level, true);
			item.maxHitCount = TableManager.GetValueFromUnionCell(this.data.ValueF[i], this.level, true);
			this.entityList.Add(item);
		}
		this.time = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.checkDis = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true), GlobalLogic.VALUE_1000);
		this.forceZHeight = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x06017911 RID: 96529 RVA: 0x007410E0 File Offset: 0x0073F4E0
	public override void OnStart()
	{
		base.OnStart();
		if (base.owner.CurrentBeScene != null)
		{
			this.sceneHandleA = base.owner.CurrentBeScene.RegisterEvent(BeEventSceneType.onEntityRemove, new BeEventHandle.Del(this.RegisterEntityRemove));
		}
		base.InitTimeAcc(this.time);
	}

	// Token: 0x06017912 RID: 96530 RVA: 0x00741133 File Offset: 0x0073F533
	public override void OnUpdateTimeAcc()
	{
		base.OnUpdateTimeAcc();
		this.AddEntity();
	}

	// Token: 0x06017913 RID: 96531 RVA: 0x00741144 File Offset: 0x0073F544
	private void RegisterEntityRemove(object[] args)
	{
		BeEntity beEntity = args[0] as BeEntity;
		if (beEntity == null)
		{
			return;
		}
		if (!this.CheckEntityResId(beEntity.m_iResID))
		{
			return;
		}
		if (!this.entityDataDic.ContainsKey(beEntity.GetPID()))
		{
			return;
		}
		this.entityDataDic.Remove(beEntity.GetPID());
	}

	// Token: 0x06017914 RID: 96532 RVA: 0x0074119C File Offset: 0x0073F59C
	private void AddEntity()
	{
		for (int i = 0; i < this.entityList.Count; i++)
		{
			Mechanism1063.EntityData data = this.entityList[i];
			for (int j = 0; j < data.num; j++)
			{
				this.AddEntitySingle(data);
			}
		}
	}

	// Token: 0x06017915 RID: 96533 RVA: 0x007411F4 File Offset: 0x0073F5F4
	private void AddEntitySingle(Mechanism1063.EntityData data)
	{
		int num = 0;
		VInt3 randomPos;
		BeProjectile beProjectile;
		for (;;)
		{
			num++;
			randomPos = base.owner.CurrentBeScene.GetRandomPos(20);
			if (this.CheckDis(randomPos))
			{
				if (this.forceZHeight != 0)
				{
					randomPos.z = this.forceZHeight.i;
				}
				beProjectile = (base.owner.AddEntity(data.entityId, randomPos, this.level, 0) as BeProjectile);
				if (beProjectile != null && !this.entityDataDic.ContainsKey(beProjectile.GetPID()))
				{
					break;
				}
			}
			if (num >= this.whileCount)
			{
				return;
			}
		}
		beProjectile.totoalHitCount = data.maxHitCount;
		this.entityDataDic.Add(beProjectile.GetPID(), randomPos);
	}

	// Token: 0x06017916 RID: 96534 RVA: 0x007412C4 File Offset: 0x0073F6C4
	private bool CheckDis(VInt3 targetPos)
	{
		foreach (KeyValuePair<int, VInt3> keyValuePair in this.entityDataDic)
		{
			VInt3 value = keyValuePair.Value;
			if ((value - targetPos).magnitude < this.checkDis)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06017917 RID: 96535 RVA: 0x00741328 File Offset: 0x0073F728
	private bool CheckEntityResId(int resId)
	{
		for (int i = 0; i < this.entityList.Count; i++)
		{
			if (this.entityList[i].entityId == resId)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x04010EEC RID: 69356
	private int time = 2000;

	// Token: 0x04010EED RID: 69357
	private VInt checkDis = 10000;

	// Token: 0x04010EEE RID: 69358
	private int whileCount = 100;

	// Token: 0x04010EEF RID: 69359
	private VInt forceZHeight = 0;

	// Token: 0x04010EF0 RID: 69360
	private List<Mechanism1063.EntityData> entityList = new List<Mechanism1063.EntityData>();

	// Token: 0x04010EF1 RID: 69361
	private Dictionary<int, VInt3> entityDataDic = new Dictionary<int, VInt3>();

	// Token: 0x02004289 RID: 17033
	private struct EntityData
	{
		// Token: 0x04010EF2 RID: 69362
		public int entityId;

		// Token: 0x04010EF3 RID: 69363
		public int num;

		// Token: 0x04010EF4 RID: 69364
		public int maxHitCount;
	}
}
