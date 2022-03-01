using System;
using System.Collections;
using GameClient;

// Token: 0x020041F1 RID: 16881
public interface IBattle
{
	// Token: 0x0601757A RID: 95610
	eDungeonMode GetMode();

	// Token: 0x0601757B RID: 95611
	BattleType GetBattleType();

	// Token: 0x0601757C RID: 95612
	void End(bool needEndRecord = true);

	// Token: 0x0601757D RID: 95613
	IEnumerator Start(IASyncOperation op);

	// Token: 0x0601757E RID: 95614
	BeScene Restart();

	// Token: 0x0601757F RID: 95615
	void Update(int delta);

	// Token: 0x06017580 RID: 95616
	void FrameUpdate(int delta);

	// Token: 0x06017581 RID: 95617
	bool CanReborn();

	// Token: 0x06017582 RID: 95618
	bool IsRebornCountLimit();

	// Token: 0x06017583 RID: 95619
	int GetLeftRebornCount();

	// Token: 0x06017584 RID: 95620
	int GetMaxRebornCount();
}
