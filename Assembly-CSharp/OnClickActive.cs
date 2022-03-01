using System;
using UnityEngine;

// Token: 0x02000090 RID: 144
public class OnClickActive : MonoBehaviour
{
	// Token: 0x040002FE RID: 766
	public OnClickActive.EventType m_eEventType;

	// Token: 0x040002FF RID: 767
	public OnClickActive.OnClickActiveType m_eOnClickActiveType = OnClickActive.OnClickActiveType.OCAT_INVALID;

	// Token: 0x04000300 RID: 768
	public OnClickActive.NodeType m_eNodeType;

	// Token: 0x04000301 RID: 769
	public OnClickActive.BindStatus m_eBindStatus = OnClickActive.BindStatus.BS_UNFINISH;

	// Token: 0x04000302 RID: 770
	public OnClickActive.AttachParamsType m_eAttachParamsType;

	// Token: 0x04000303 RID: 771
	public OnClickActive.OnClickCloseType m_eOnClickCloseType;

	// Token: 0x02000091 RID: 145
	public enum AttachParamsType
	{
		// Token: 0x04000305 RID: 773
		APT_NONE,
		// Token: 0x04000306 RID: 774
		APT_CHECK_CONDITION
	}

	// Token: 0x02000092 RID: 146
	public enum OnClickActiveType
	{
		// Token: 0x04000308 RID: 776
		OCAT_INVALID = -1,
		// Token: 0x04000309 RID: 777
		OCAT_GO,
		// Token: 0x0400030A RID: 778
		OCAT_ACQUIRED,
		// Token: 0x0400030B RID: 779
		OCAT_EVENT,
		// Token: 0x0400030C RID: 780
		OCAT_COUNT
	}

	// Token: 0x02000093 RID: 147
	public enum NodeType
	{
		// Token: 0x0400030E RID: 782
		NT_ROOT,
		// Token: 0x0400030F RID: 783
		NT_CHILD
	}

	// Token: 0x02000094 RID: 148
	public enum BindStatus
	{
		// Token: 0x04000311 RID: 785
		BS_INIT,
		// Token: 0x04000312 RID: 786
		BS_UNFINISH,
		// Token: 0x04000313 RID: 787
		BS_FINISH
	}

	// Token: 0x02000095 RID: 149
	public enum EventType
	{
		// Token: 0x04000315 RID: 789
		EventType_Invalid = -1,
		// Token: 0x04000316 RID: 790
		EventType_OpenSignFrame,
		// Token: 0x04000317 RID: 791
		EventType_OpenSeventDayAwardFrame,
		// Token: 0x04000318 RID: 792
		EventType_NormalAcquireAward,
		// Token: 0x04000319 RID: 793
		EventType_PerfectAcquireAward,
		// Token: 0x0400031A RID: 794
		EventType_Pl_Normal_AcquireAward,
		// Token: 0x0400031B RID: 795
		EventType_Pl_Perfect_AcquireAward,
		// Token: 0x0400031C RID: 796
		EventType_Diamond_BeVip
	}

	// Token: 0x02000096 RID: 150
	public enum OnClickCloseType
	{
		// Token: 0x0400031E RID: 798
		OCCT_NONE,
		// Token: 0x0400031F RID: 799
		OCCT_PRE,
		// Token: 0x04000320 RID: 800
		OCCT_AFT
	}
}
