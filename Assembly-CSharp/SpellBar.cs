using System;

// Token: 0x02004141 RID: 16705
public class SpellBar
{
	// Token: 0x04010477 RID: 66679
	public eDungeonCharactorBar type;

	// Token: 0x04010478 RID: 66680
	public int acc;

	// Token: 0x04010479 RID: 66681
	public int duration;

	// Token: 0x0401047A RID: 66682
	public bool active;

	// Token: 0x0401047B RID: 66683
	public bool autodelete = true;

	// Token: 0x0401047C RID: 66684
	public bool reverse;

	// Token: 0x0401047D RID: 66685
	public bool autoAcc = true;

	// Token: 0x0401047E RID: 66686
	public bool reverseAutoAcc = true;

	// Token: 0x0401047F RID: 66687
	public bool alwaysRefreshUI;

	// Token: 0x04010480 RID: 66688
	public ComDungeonCharactorHeadBar com;
}
