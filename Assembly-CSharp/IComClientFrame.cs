using System;
using GameClient;

// Token: 0x02000DA7 RID: 3495
public interface IComClientFrame
{
	// Token: 0x06008D88 RID: 36232
	int GetZOrder();

	// Token: 0x06008D89 RID: 36233
	string GetGroupTag();

	// Token: 0x06008D8A RID: 36234
	FrameLayer GetLayer();

	// Token: 0x06008D8B RID: 36235
	void SetCurrentFrame(string name);

	// Token: 0x06008D8C RID: 36236
	void SetGroupTag(string tag);

	// Token: 0x06008D8D RID: 36237
	bool IsNeedFade();

	// Token: 0x06008D8E RID: 36238
	bool IsNeedClearWhenChangeScene();

	// Token: 0x06008D8F RID: 36239
	void SetIsNeedClearWhenChangeScene(bool bFlag);

	// Token: 0x06008D90 RID: 36240
	bool IsInitWithGameBindSystem();

	// Token: 0x06008D91 RID: 36241
	eFrameType GetFrameType();

	// Token: 0x06008D92 RID: 36242
	bool IsFullScreenFrame();

	// Token: 0x06008D93 RID: 36243
	bool IsFullScreenFrameNeedBeClose();
}
