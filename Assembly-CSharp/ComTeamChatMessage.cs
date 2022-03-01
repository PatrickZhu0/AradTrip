using System;
using GameClient;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000F22 RID: 3874
public class ComTeamChatMessage : MonoBehaviour
{
	// Token: 0x0600974D RID: 38733 RVA: 0x001CF614 File Offset: 0x001CDA14
	private void Start()
	{
		this._hiddenRoot(false);
		if (null != this.mLinkRoot)
		{
			this.mLink = this.mLinkRoot.GetComponent<LinkParse>();
		}
	}

	// Token: 0x0600974E RID: 38734 RVA: 0x001CF63F File Offset: 0x001CDA3F
	private void _hiddenRoot(bool isShow)
	{
		this.mState = ((!isShow) ? ComTeamChatMessage.eState.onHidden : ComTeamChatMessage.eState.onShow);
		if (null != this.mRoot)
		{
			this.mRoot.SetActive(isShow);
		}
	}

	// Token: 0x0600974F RID: 38735 RVA: 0x001CF671 File Offset: 0x001CDA71
	private void _setMsg(string msg)
	{
		if (null != this.mContent)
		{
			this.mContent.text = msg;
		}
		if (null != this.mLink)
		{
			this.mLink.SetText(msg, true);
		}
	}

	// Token: 0x06009750 RID: 38736 RVA: 0x001CF6AE File Offset: 0x001CDAAE
	public void SetMessage(string msg)
	{
		this._hiddenRoot(true);
		this._setMsg(msg);
		this.mCal = this.mDelay;
	}

	// Token: 0x06009751 RID: 38737 RVA: 0x001CF6CA File Offset: 0x001CDACA
	private void Update()
	{
		if (this.mState == ComTeamChatMessage.eState.onShow)
		{
			if (this.mCal > 0f)
			{
				this.mCal -= Time.deltaTime;
			}
			else
			{
				this._hiddenRoot(false);
			}
		}
	}

	// Token: 0x04004DEF RID: 19951
	public float mDelay = 5f;

	// Token: 0x04004DF0 RID: 19952
	public GameObject mRoot;

	// Token: 0x04004DF1 RID: 19953
	public Text mContent;

	// Token: 0x04004DF2 RID: 19954
	public GameObject mLinkRoot;

	// Token: 0x04004DF3 RID: 19955
	private LinkParse mLink;

	// Token: 0x04004DF4 RID: 19956
	private ComTeamChatMessage.eState mState = ComTeamChatMessage.eState.onHidden;

	// Token: 0x04004DF5 RID: 19957
	private float mCal;

	// Token: 0x02000F23 RID: 3875
	private enum eState
	{
		// Token: 0x04004DF7 RID: 19959
		onShow,
		// Token: 0x04004DF8 RID: 19960
		onHidden
	}
}
