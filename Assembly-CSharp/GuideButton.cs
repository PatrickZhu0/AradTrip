using System;
using GameClient;
using UnityEngine;

// Token: 0x0200100D RID: 4109
[Serializable]
public class GuideButton : IUnitData
{
	// Token: 0x06009C2B RID: 39979 RVA: 0x001E862B File Offset: 0x001E6A2B
	public NewbieGuideComType getType()
	{
		return NewbieGuideComType.BUTTON;
	}

	// Token: 0x06009C2C RID: 39980 RVA: 0x001E862E File Offset: 0x001E6A2E
	public Type objType()
	{
		return typeof(GuideButton);
	}

	// Token: 0x06009C2D RID: 39981 RVA: 0x001E863C File Offset: 0x001E6A3C
	public object[] getArgs()
	{
		return new object[]
		{
			this.mFrameType,
			this.mComRoot,
			this.mTextTips,
			this.mAnchor,
			this.mTextTipType,
			this.mLocalPos,
			this.mSaveBoot,
			this.mPauseBattle,
			this.mHighLightPointPath
		};
	}

	// Token: 0x04005592 RID: 21906
	public string mFrameType;

	// Token: 0x04005593 RID: 21907
	public string mComRoot;

	// Token: 0x04005594 RID: 21908
	public string mTextTips;

	// Token: 0x04005595 RID: 21909
	public ComNewbieGuideBase.eNewbieGuideAnchor mAnchor;

	// Token: 0x04005596 RID: 21910
	public TextTipType mTextTipType;

	// Token: 0x04005597 RID: 21911
	public Vector3 mLocalPos;

	// Token: 0x04005598 RID: 21912
	public eNewbieGuideAgrsName mSaveBoot;

	// Token: 0x04005599 RID: 21913
	public eNewbieGuideAgrsName mPauseBattle;

	// Token: 0x0400559A RID: 21914
	public string mHighLightPointPath;
}
