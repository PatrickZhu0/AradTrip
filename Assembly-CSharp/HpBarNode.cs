using System;
using UnityEngine;

// Token: 0x02000F88 RID: 3976
public class HpBarNode
{
	// Token: 0x1700192C RID: 6444
	// (get) Token: 0x060099AC RID: 39340 RVA: 0x001D91B6 File Offset: 0x001D75B6
	// (set) Token: 0x060099AD RID: 39341 RVA: 0x001D91BE File Offset: 0x001D75BE
	public int id { get; private set; }

	// Token: 0x1700192D RID: 6445
	// (get) Token: 0x060099AE RID: 39342 RVA: 0x001D91C7 File Offset: 0x001D75C7
	// (set) Token: 0x060099AF RID: 39343 RVA: 0x001D91CF File Offset: 0x001D75CF
	public int changedHp { get; private set; }

	// Token: 0x1700192E RID: 6446
	// (get) Token: 0x060099B0 RID: 39344 RVA: 0x001D91D8 File Offset: 0x001D75D8
	// (set) Token: 0x060099B1 RID: 39345 RVA: 0x001D91E0 File Offset: 0x001D75E0
	public int hp { get; private set; }

	// Token: 0x1700192F RID: 6447
	// (get) Token: 0x060099B2 RID: 39346 RVA: 0x001D91E9 File Offset: 0x001D75E9
	// (set) Token: 0x060099B3 RID: 39347 RVA: 0x001D91F1 File Offset: 0x001D75F1
	public int maxHp { get; private set; }

	// Token: 0x17001930 RID: 6448
	// (get) Token: 0x060099B4 RID: 39348 RVA: 0x001D91FA File Offset: 0x001D75FA
	// (set) Token: 0x060099B5 RID: 39349 RVA: 0x001D9202 File Offset: 0x001D7602
	public int singleBarHp { get; private set; }

	// Token: 0x17001931 RID: 6449
	// (get) Token: 0x060099B6 RID: 39350 RVA: 0x001D920B File Offset: 0x001D760B
	// (set) Token: 0x060099B7 RID: 39351 RVA: 0x001D9213 File Offset: 0x001D7613
	public eHpBarType barType { get; private set; }

	// Token: 0x17001932 RID: 6450
	// (get) Token: 0x060099B8 RID: 39352 RVA: 0x001D921C File Offset: 0x001D761C
	// (set) Token: 0x060099B9 RID: 39353 RVA: 0x001D9224 File Offset: 0x001D7624
	public string name { get; private set; }

	// Token: 0x17001933 RID: 6451
	// (get) Token: 0x060099BA RID: 39354 RVA: 0x001D922D File Offset: 0x001D762D
	// (set) Token: 0x060099BB RID: 39355 RVA: 0x001D9235 File Offset: 0x001D7635
	public int level { get; private set; }

	// Token: 0x17001934 RID: 6452
	// (get) Token: 0x060099BC RID: 39356 RVA: 0x001D923E File Offset: 0x001D763E
	// (set) Token: 0x060099BD RID: 39357 RVA: 0x001D9246 File Offset: 0x001D7646
	public Sprite headIcon { get; private set; }

	// Token: 0x17001935 RID: 6453
	// (get) Token: 0x060099BE RID: 39358 RVA: 0x001D924F File Offset: 0x001D764F
	// (set) Token: 0x060099BF RID: 39359 RVA: 0x001D9257 File Offset: 0x001D7657
	public Material headIconMaterial { get; private set; }

	// Token: 0x17001936 RID: 6454
	// (get) Token: 0x060099C0 RID: 39360 RVA: 0x001D9260 File Offset: 0x001D7660
	// (set) Token: 0x060099C1 RID: 39361 RVA: 0x001D9268 File Offset: 0x001D7668
	private int originSingleBarHp { get; set; }

	// Token: 0x060099C2 RID: 39362 RVA: 0x001D9271 File Offset: 0x001D7671
	public void InitHpData(int id, eHpBarType barType, int maxHp, int singleBarHp)
	{
		this.id = id;
		this.barType = barType;
		this.hp = maxHp;
		this.maxHp = maxHp;
		this.singleBarHp = singleBarHp;
		this.originSingleBarHp = this.singleBarHp;
		this.changedHp = 0;
		this.originMaxHp = maxHp;
	}

	// Token: 0x060099C3 RID: 39363 RVA: 0x001D92B1 File Offset: 0x001D76B1
	public void InitInfo(string name, int level, Sprite headIcon, Material headIconmaterial)
	{
		this.name = name;
		this.level = level;
		this.headIcon = headIcon;
		this.headIconMaterial = headIconmaterial;
	}

	// Token: 0x060099C4 RID: 39364 RVA: 0x001D92D0 File Offset: 0x001D76D0
	public void SyncHPBar(int hp, int maxHp)
	{
		if (maxHp <= 0)
		{
			return;
		}
		this.mSingleBarHpFactor = new VFactor((long)maxHp, (long)this.originMaxHp);
		this.singleBarHp = (this.mSingleBarHpFactor * (long)this.originSingleBarHp).roundInt;
		this.maxHp = maxHp;
		this.hp = hp;
	}

	// Token: 0x060099C5 RID: 39365 RVA: 0x001D9327 File Offset: 0x001D7727
	public void Damage(int changedHp)
	{
		this.changedHp += changedHp;
		this.hp -= changedHp;
	}

	// Token: 0x060099C6 RID: 39366 RVA: 0x001D9345 File Offset: 0x001D7745
	public bool IsHpChanged()
	{
		return this.changedHp != 0;
	}

	// Token: 0x060099C7 RID: 39367 RVA: 0x001D9353 File Offset: 0x001D7753
	public void ClearChangedHp()
	{
		this.changedHp = 0;
	}

	// Token: 0x060099C8 RID: 39368 RVA: 0x001D935C File Offset: 0x001D775C
	public void ResetHp()
	{
		this.hp = this.maxHp;
		this.changedHp = 0;
	}

	// Token: 0x060099C9 RID: 39369 RVA: 0x001D9374 File Offset: 0x001D7774
	public void Reset()
	{
		this.id = 0;
		this.changedHp = 0;
		this.hp = 0;
		this.maxHp = 0;
		this.singleBarHp = 0;
		this.originSingleBarHp = 0;
		this.barType = eHpBarType.Monster;
		this.name = string.Empty;
		this.level = 0;
		this.headIcon = null;
		this.headIconMaterial = null;
	}

	// Token: 0x04004F39 RID: 20281
	private VFactor mSingleBarHpFactor = VFactor.one;

	// Token: 0x04004F3B RID: 20283
	private int originMaxHp;
}
