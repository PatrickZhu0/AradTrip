using System;
using System.Collections.Generic;

// Token: 0x02004177 RID: 16759
public class DisplayAttribute
{
	// Token: 0x06016F6B RID: 94059 RVA: 0x0070A3EC File Offset: 0x007087EC
	public DisplayAttribute()
	{
		foreach (string key in Enum.GetNames(typeof(AttributeType)))
		{
			this.attachValue.Add(key, 0);
		}
	}

	// Token: 0x04010716 RID: 67350
	public float maxHp;

	// Token: 0x04010717 RID: 67351
	public float maxMp;

	// Token: 0x04010718 RID: 67352
	public float hpRecover;

	// Token: 0x04010719 RID: 67353
	public float mpRecover;

	// Token: 0x0401071A RID: 67354
	public float baseSta;

	// Token: 0x0401071B RID: 67355
	public float baseAtk;

	// Token: 0x0401071C RID: 67356
	public float baseInt;

	// Token: 0x0401071D RID: 67357
	public float baseIndependence;

	// Token: 0x0401071E RID: 67358
	public float baseSpr;

	// Token: 0x0401071F RID: 67359
	public float attack;

	// Token: 0x04010720 RID: 67360
	public float magicAttack;

	// Token: 0x04010721 RID: 67361
	public float defence;

	// Token: 0x04010722 RID: 67362
	public float magicDefence;

	// Token: 0x04010723 RID: 67363
	public float attackSpeed;

	// Token: 0x04010724 RID: 67364
	public float spellSpeed;

	// Token: 0x04010725 RID: 67365
	public float moveSpeed;

	// Token: 0x04010726 RID: 67366
	public float ciriticalAttack;

	// Token: 0x04010727 RID: 67367
	public float ciriticalMagicAttack;

	// Token: 0x04010728 RID: 67368
	public float dex;

	// Token: 0x04010729 RID: 67369
	public float dodge;

	// Token: 0x0401072A RID: 67370
	public float frozen;

	// Token: 0x0401072B RID: 67371
	public float hard;

	// Token: 0x0401072C RID: 67372
	public float resistMagic;

	// Token: 0x0401072D RID: 67373
	public int hp;

	// Token: 0x0401072E RID: 67374
	public int mp;

	// Token: 0x0401072F RID: 67375
	public float lightAttack;

	// Token: 0x04010730 RID: 67376
	public float fireAttack;

	// Token: 0x04010731 RID: 67377
	public float iceAttack;

	// Token: 0x04010732 RID: 67378
	public float darkAttack;

	// Token: 0x04010733 RID: 67379
	public float lightDefence;

	// Token: 0x04010734 RID: 67380
	public float fireDefence;

	// Token: 0x04010735 RID: 67381
	public float iceDefence;

	// Token: 0x04010736 RID: 67382
	public float darkDefence;

	// Token: 0x04010737 RID: 67383
	public Dictionary<string, int> attachValue = new Dictionary<string, int>();
}
