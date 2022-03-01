using System;
using GameClient;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020045E6 RID: 17894
internal class DialogScript : MonoBehaviour
{
	// Token: 0x060192AB RID: 103083 RVA: 0x007F4C98 File Offset: 0x007F3098
	public void Initialize(bool bUseLink)
	{
		this.bUseLink = bUseLink;
		this.goPopDialog = Utility.FindChild(base.gameObject, "PopUpDialog");
		this.goPopDialog.CustomActive(true);
		if (bUseLink)
		{
			this.compText = Utility.FindComponent<LinkParse>(base.gameObject, "PopUpDialog/content", false);
		}
		else
		{
			this.compNormalText = Utility.FindComponent<Text>(base.gameObject, "PopUpDialog/content", false);
		}
	}

	// Token: 0x060192AC RID: 103084 RVA: 0x007F4D08 File Offset: 0x007F3108
	public void ShowText(string text, bool bLink = true, float fLifeTime = 3.5f)
	{
		this.lifeTime = fLifeTime;
		if (base.IsInvoking())
		{
			base.CancelInvoke();
		}
		if (!base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(true);
		}
		if (this.bUseLink)
		{
			if (this.compText != null)
			{
				this.compText.SetText(text, bLink);
				base.Invoke("DoHide", this.lifeTime);
			}
		}
		else if (this.compNormalText != null)
		{
			this.compNormalText.text = text;
			base.Invoke("DoHide", this.lifeTime);
		}
		this.isShow = true;
	}

	// Token: 0x060192AD RID: 103085 RVA: 0x007F4DBD File Offset: 0x007F31BD
	public void DoHide()
	{
		if (!this.isShow)
		{
			return;
		}
		this.isShow = false;
		base.gameObject.CustomActive(false);
	}

	// Token: 0x060192AE RID: 103086 RVA: 0x007F4DDE File Offset: 0x007F31DE
	public bool IsShow()
	{
		return this.isShow;
	}

	// Token: 0x04012067 RID: 73831
	private float lifeTime = 3.5f;

	// Token: 0x04012068 RID: 73832
	private LinkParse compText;

	// Token: 0x04012069 RID: 73833
	private Text compNormalText;

	// Token: 0x0401206A RID: 73834
	private bool isShow;

	// Token: 0x0401206B RID: 73835
	private bool bUseLink;

	// Token: 0x0401206C RID: 73836
	private GameObject goPopDialog;
}
