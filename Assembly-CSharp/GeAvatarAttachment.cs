using System;
using UnityEngine;

// Token: 0x02000CE3 RID: 3299
public class GeAvatarAttachment : MonoBehaviour
{
	// Token: 0x17001820 RID: 6176
	// (get) Token: 0x06008750 RID: 34640 RVA: 0x0017DB2B File Offset: 0x0017BF2B
	// (set) Token: 0x0600874F RID: 34639 RVA: 0x0017DB22 File Offset: 0x0017BF22
	public string refAvatar
	{
		get
		{
			return this.m_RefAvatar;
		}
		set
		{
			this.m_RefAvatar = value;
		}
	}

	// Token: 0x17001821 RID: 6177
	// (get) Token: 0x06008752 RID: 34642 RVA: 0x0017DB3C File Offset: 0x0017BF3C
	// (set) Token: 0x06008751 RID: 34641 RVA: 0x0017DB33 File Offset: 0x0017BF33
	public GeAttachDesc[] attachDescArray
	{
		get
		{
			return this.m_AttachDescArray;
		}
		set
		{
			this.m_AttachDescArray = value;
		}
	}

	// Token: 0x04004117 RID: 16663
	[SerializeField]
	private string m_RefAvatar;

	// Token: 0x04004118 RID: 16664
	[SerializeField]
	private GeAttachDesc[] m_AttachDescArray = new GeAttachDesc[0];
}
