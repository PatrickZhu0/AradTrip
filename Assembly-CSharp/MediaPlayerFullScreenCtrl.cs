using System;
using UnityEngine;

// Token: 0x020048D4 RID: 18644
public class MediaPlayerFullScreenCtrl : MonoBehaviour
{
	// Token: 0x0601AD42 RID: 109890 RVA: 0x00840A16 File Offset: 0x0083EE16
	private void Start()
	{
		this.Resize();
	}

	// Token: 0x0601AD43 RID: 109891 RVA: 0x00840A1E File Offset: 0x0083EE1E
	private void Update()
	{
		if (this.m_iOrgWidth != Screen.width)
		{
			this.Resize();
		}
		if (this.m_iOrgHeight != Screen.height)
		{
			this.Resize();
		}
	}

	// Token: 0x0601AD44 RID: 109892 RVA: 0x00840A4C File Offset: 0x0083EE4C
	private void Resize()
	{
		this.m_iOrgWidth = Screen.width;
		this.m_iOrgHeight = Screen.height;
		float num = (float)this.m_iOrgHeight / (float)this.m_iOrgWidth;
		this.m_objVideo.transform.localScale = new Vector3(20f / num, 20f / num, 1f);
		this.m_objVideo.transform.GetComponent<MediaPlayerCtrl>().Resize();
	}

	// Token: 0x04012AAE RID: 76462
	public GameObject m_objVideo;

	// Token: 0x04012AAF RID: 76463
	private int m_iOrgWidth;

	// Token: 0x04012AB0 RID: 76464
	private int m_iOrgHeight;
}
