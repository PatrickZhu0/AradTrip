using System;
using GameClient;

// Token: 0x02001014 RID: 4116
[Serializable]
public class GuidePassThrough : IUnitData
{
	// Token: 0x06009C47 RID: 40007 RVA: 0x001E88ED File Offset: 0x001E6CED
	public NewbieGuideComType getType()
	{
		return NewbieGuideComType.PASS_THROUGH;
	}

	// Token: 0x06009C48 RID: 40008 RVA: 0x001E88F1 File Offset: 0x001E6CF1
	public Type objType()
	{
		return typeof(GuidePassThrough);
	}

	// Token: 0x06009C49 RID: 40009 RVA: 0x001E8900 File Offset: 0x001E6D00
	public object[] getArgs()
	{
		return new object[]
		{
			this.mFrameType,
			this.mComRoot,
			this.mAutoClose,
			this.mWaitTime,
			this.mShowBindObjName,
			this.mTextTips,
			this.mAnchor,
			this.mTextTipType,
			this.mSaveBoot
		};
	}

	// Token: 0x040055B7 RID: 21943
	public string mFrameType;

	// Token: 0x040055B8 RID: 21944
	public string mComRoot;

	// Token: 0x040055B9 RID: 21945
	public eNewbieGuideAgrsName mAutoClose;

	// Token: 0x040055BA RID: 21946
	public float mWaitTime;

	// Token: 0x040055BB RID: 21947
	public string mShowBindObjName;

	// Token: 0x040055BC RID: 21948
	public string mTextTips;

	// Token: 0x040055BD RID: 21949
	public ComNewbieGuideBase.eNewbieGuideAnchor mAnchor;

	// Token: 0x040055BE RID: 21950
	public TextTipType mTextTipType;

	// Token: 0x040055BF RID: 21951
	public eNewbieGuideAgrsName mSaveBoot;
}
