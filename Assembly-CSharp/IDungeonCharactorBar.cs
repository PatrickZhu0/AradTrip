using System;
using UnityEngine;

// Token: 0x02000EC4 RID: 3780
public interface IDungeonCharactorBar
{
	// Token: 0x060094C5 RID: 38085
	void SetRate(float percent);

	// Token: 0x060094C6 RID: 38086
	eDungeonCharactorBar GetBarType();

	// Token: 0x060094C7 RID: 38087
	void SetBarType(eDungeonCharactorBar type);

	// Token: 0x060094C8 RID: 38088
	GameObject GetGameObject();

	// Token: 0x060094C9 RID: 38089
	void Show(bool isShow);

	// Token: 0x060094CA RID: 38090
	void SetText(string content);

	// Token: 0x060094CB RID: 38091
	void SetCdText(float cdTime);
}
