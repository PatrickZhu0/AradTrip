using System;
using UnityEngine;

// Token: 0x02000F86 RID: 3974
public interface IHPBar
{
	// Token: 0x0600999B RID: 39323
	void Init(int hp, int mp, int maxHp = -1, int resistVale = 0);

	// Token: 0x0600999C RID: 39324
	void SetName(string name, int level);

	// Token: 0x0600999D RID: 39325
	void SetName(string name);

	// Token: 0x0600999E RID: 39326
	void SetLevel(int level);

	// Token: 0x0600999F RID: 39327
	void SetIcon(Sprite headIcon, Material material);

	// Token: 0x060099A0 RID: 39328
	void Damage(int value, bool withAnimate);

	// Token: 0x060099A1 RID: 39329
	void SetMPRate(float percent);

	// Token: 0x060099A2 RID: 39330
	void SetActive(bool active);

	// Token: 0x060099A3 RID: 39331
	void Unload();

	// Token: 0x060099A4 RID: 39332
	void SetHidden(bool hidden);

	// Token: 0x060099A5 RID: 39333
	bool GetHidden();

	// Token: 0x060099A6 RID: 39334
	eHpBarType GetBarType();

	// Token: 0x060099A7 RID: 39335
	void SetHP(int curHP, int maxHP);

	// Token: 0x060099A8 RID: 39336
	void SetMP(int curMP, int maxMP);

	// Token: 0x060099A9 RID: 39337
	void InitResistMagic(int resistValue, BeActor player);

	// Token: 0x060099AA RID: 39338
	void SetBuffName(string text);
}
