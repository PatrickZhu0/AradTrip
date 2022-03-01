using System;

// Token: 0x0200436B RID: 17259
public class Mechanism2051 : BeMechanism
{
	// Token: 0x06017E77 RID: 97911 RVA: 0x00765CC4 File Offset: 0x007640C4
	public Mechanism2051(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017E78 RID: 97912 RVA: 0x00765D44 File Offset: 0x00764144
	public override void OnInit()
	{
		base.OnInit();
		this.baseDamage = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.damagePercent = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		if (valueFromUnionCell != 0)
		{
			this.monsterID = valueFromUnionCell;
		}
	}

	// Token: 0x06017E79 RID: 97913 RVA: 0x00765DD8 File Offset: 0x007641D8
	public override void OnStart()
	{
		base.OnStart();
		BeActor beActor = base.owner.CurrentBeScene.FindMonsterByID(this.monsterID);
		if (beActor != null)
		{
			this.handleA = beActor.RegisterEvent(BeEventType.onAddBuff, delegate(object[] args)
			{
				BeBuff beBuff = args[0] as BeBuff;
				if (beBuff != null)
				{
					if (beBuff.buffID == this.buffID)
					{
						this.hitAttachCount = 0;
					}
					int num = Array.IndexOf<int>(this.effectBuffIDs, beBuff.buffID);
					if (num != -1)
					{
						this.curBuffID = this.buffIDs[num];
					}
				}
			});
			this.handle = beActor.RegisterEvent(BeEventType.onRemoveBuff, delegate(object[] args)
			{
				int value = (int)args[0];
				int num = Array.IndexOf<int>(this.effectBuffIDs, value);
				if (num != -1)
				{
					this.curBuffID = -1;
				}
			});
			this.handleC = beActor.RegisterEvent(BeEventType.onBeHitAfterFinalDamage, delegate(object[] args)
			{
				if (this.curBuffID == -1)
				{
					return;
				}
				BeEntity beEntity = args[3] as BeEntity;
				BeEntity owner = beEntity.GetOwner();
				if (owner != null)
				{
					BeActor beActor2 = owner as BeActor;
					if (beActor2 != null && beActor2.buffController.HasBuffByID(this.curBuffID) == null)
					{
						int[] array = args[0] as int[];
						array[0] = array[0] * VFactor.NewVFactor(this.damagePercent, 100);
					}
				}
			});
		}
		this.handleB = base.owner.RegisterEvent(BeEventType.onAfterCalFirstDamage, delegate(object[] args)
		{
			bool flag = (bool)args[1];
			if (flag)
			{
				int[] array = args[0] as int[];
				int value = (int)args[2];
				if (Array.IndexOf<int>(this.hurtIDs, value) != -1)
				{
					this.hitAttachCount++;
					array[0] = array[0] + this.baseDamage * this.hitAttachCount;
				}
			}
		});
		this.handleD = base.owner.RegisterEvent(BeEventType.onBuffBeforePostInit, delegate(object[] args)
		{
			BeBuff beBuff = args[0] as BeBuff;
			if (beBuff != null && Array.IndexOf<int>(this.buffIDs, beBuff.buffID) != -1)
			{
				this.DeleteBeforeBuff();
			}
		});
	}

	// Token: 0x06017E7A RID: 97914 RVA: 0x00765E98 File Offset: 0x00764298
	private void DeleteBeforeBuff()
	{
		for (int i = 0; i < this.buffIDs.Length; i++)
		{
			if (base.owner.buffController.HasBuffByID(this.buffIDs[i]) != null)
			{
				base.owner.buffController.RemoveBuff(this.buffIDs[i], 0, 0);
			}
		}
	}

	// Token: 0x06017E7B RID: 97915 RVA: 0x00765EF5 File Offset: 0x007642F5
	public override void OnFinish()
	{
		base.OnFinish();
		if (this.handle != null)
		{
			this.handle.Remove();
			this.handle = null;
		}
	}

	// Token: 0x0401134F RID: 70479
	private int monsterID = 87030031;

	// Token: 0x04011350 RID: 70480
	private int hitAttachCount;

	// Token: 0x04011351 RID: 70481
	private int buffID = 570037;

	// Token: 0x04011352 RID: 70482
	private int[] hurtIDs = new int[]
	{
		210590,
		210592,
		210593,
		210594
	};

	// Token: 0x04011353 RID: 70483
	private int baseDamage = 20;

	// Token: 0x04011354 RID: 70484
	private int[] buffIDs = new int[]
	{
		570041,
		570042,
		570043,
		570044
	};

	// Token: 0x04011355 RID: 70485
	private int[] effectBuffIDs = new int[]
	{
		570033,
		570034,
		570035,
		570036
	};

	// Token: 0x04011356 RID: 70486
	private int curBuffID = -1;

	// Token: 0x04011357 RID: 70487
	private int damagePercent;

	// Token: 0x04011358 RID: 70488
	private BeEventHandle handle;
}
