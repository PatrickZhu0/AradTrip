using System;
using UnityEngine.UI;

// Token: 0x02000ECE RID: 3790
public struct DungeonGraphicInfo
{
	// Token: 0x04004BCA RID: 19402
	public Image image;

	// Token: 0x04004BCB RID: 19403
	public Image imageFg;

	// Token: 0x04004BCC RID: 19404
	public Image imageBoard;

	// Token: 0x04004BCD RID: 19405
	public int x;

	// Token: 0x04004BCE RID: 19406
	public int y;

	// Token: 0x04004BCF RID: 19407
	public DungeonGraphicInfo.State state;

	// Token: 0x04004BD0 RID: 19408
	public bool visited;

	// Token: 0x04004BD1 RID: 19409
	public int id;

	// Token: 0x04004BD2 RID: 19410
	public eDungeonGraphicType type;

	// Token: 0x02000ECF RID: 3791
	public enum State
	{
		// Token: 0x04004BD4 RID: 19412
		DS_NONE,
		// Token: 0x04004BD5 RID: 19413
		DS_IN,
		// Token: 0x04004BD6 RID: 19414
		DS_CLOSE,
		// Token: 0x04004BD7 RID: 19415
		DS_OPEN
	}
}
