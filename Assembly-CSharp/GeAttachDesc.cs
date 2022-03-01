using System;

// Token: 0x02000CE2 RID: 3298
[Serializable]
public class GeAttachDesc
{
	// Token: 0x04004114 RID: 16660
	public string m_AttachmentRes;

	// Token: 0x04004115 RID: 16661
	public string m_AttachNode;

	// Token: 0x04004116 RID: 16662
	[NonSerialized]
	public GeAttach m_Attachment;
}
