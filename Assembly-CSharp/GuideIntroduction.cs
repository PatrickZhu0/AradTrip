using System;
using GameClient;
using UnityEngine;

// Token: 0x02001011 RID: 4113
[Serializable]
public class GuideIntroduction : IUnitData
{
	// Token: 0x06009C3B RID: 39995 RVA: 0x001E8757 File Offset: 0x001E6B57
	public NewbieGuideComType getType()
	{
		return NewbieGuideComType.INTRODUCTION;
	}

	// Token: 0x06009C3C RID: 39996 RVA: 0x001E875B File Offset: 0x001E6B5B
	public Type objType()
	{
		return typeof(GuideIntroduction);
	}

	// Token: 0x06009C3D RID: 39997 RVA: 0x001E8768 File Offset: 0x001E6B68
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
			this.mHighLightPointPath,
			this.mAutoClose,
			this.mWaitTime
		};
	}

	// Token: 0x040055A0 RID: 21920
	public string mFrameType;

	// Token: 0x040055A1 RID: 21921
	public string mComRoot;

	// Token: 0x040055A2 RID: 21922
	public string mTextTips;

	// Token: 0x040055A3 RID: 21923
	public ComNewbieGuideBase.eNewbieGuideAnchor mAnchor;

	// Token: 0x040055A4 RID: 21924
	public TextTipType mTextTipType;

	// Token: 0x040055A5 RID: 21925
	public Vector3 mLocalPos;

	// Token: 0x040055A6 RID: 21926
	public eNewbieGuideAgrsName mSaveBoot;

	// Token: 0x040055A7 RID: 21927
	public eNewbieGuideAgrsName mPauseBattle;

	// Token: 0x040055A8 RID: 21928
	public string mHighLightPointPath;

	// Token: 0x040055A9 RID: 21929
	public eNewbieGuideAgrsName mAutoClose;

	// Token: 0x040055AA RID: 21930
	public float mWaitTime;
}
