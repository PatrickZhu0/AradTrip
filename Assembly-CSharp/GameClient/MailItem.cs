using System;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200174C RID: 5964
	public class MailItem : MonoBehaviour
	{
		// Token: 0x17001CE0 RID: 7392
		// (get) Token: 0x0600EA57 RID: 59991 RVA: 0x003E2077 File Offset: 0x003E0477
		// (set) Token: 0x0600EA58 RID: 59992 RVA: 0x003E207F File Offset: 0x003E047F
		public MailTitleInfo GetMailTitleInfo
		{
			get
			{
				return this.mMailTitleInfo;
			}
			set
			{
				this.mMailTitleInfo = value;
			}
		}

		// Token: 0x0600EA59 RID: 59993 RVA: 0x003E2088 File Offset: 0x003E0488
		public void OnItemChangeDisplay(bool bSelected)
		{
			if (this.mSelectBack != null)
			{
				this.mSelectBack.CustomActive(bSelected);
			}
		}

		// Token: 0x0600EA5A RID: 59994 RVA: 0x003E20A7 File Offset: 0x003E04A7
		public void UpdateItemVisiable(MailTitleInfo mailTitleInfo)
		{
			this.mMailTitleInfo = mailTitleInfo;
			this.UpdateMailItemInfo(this.mMailTitleInfo);
		}

		// Token: 0x0600EA5B RID: 59995 RVA: 0x003E20BC File Offset: 0x003E04BC
		private void UpdateMailItemInfo(MailTitleInfo mailTitleInfo)
		{
			if (mailTitleInfo == null)
			{
				return;
			}
			this.mMailTitle.text = mailTitleInfo.title;
			this.mMailSender.text = mailTitleInfo.sender;
			this.mMailSendTime.text = Function.GetBeginTimeStr(mailTitleInfo.date, ShowtimeType.Normal);
			this.CalSelMailLeftTime(mailTitleInfo);
			string path;
			if (mailTitleInfo.status == 0)
			{
				path = "UI/Image/Packed/p_UI_Mail.png:UI_Youjian_Tubiao_Youjianguan";
			}
			else
			{
				path = "UI/Image/Packed/p_UI_Mail.png:UI_Youjian_Tubiao_YoujianKai";
			}
			ETCImageLoader.LoadSprite(ref this.mMailIcon, path, true);
			this.mNewMailPrompt.gameObject.CustomActive(mailTitleInfo.status == 0);
			this.mAttachIcon.CustomActive(mailTitleInfo.hasItem == 1);
		}

		// Token: 0x0600EA5C RID: 59996 RVA: 0x003E216C File Offset: 0x003E056C
		private void CalSelMailLeftTime(MailTitleInfo mailTitleInfo)
		{
			if (mailTitleInfo == null)
			{
				return;
			}
			if (mailTitleInfo.deadline - mailTitleInfo.date > 0U)
			{
				this.mMailTimeLeft.text = Function.GetLeftTimeStr(mailTitleInfo.date, mailTitleInfo.deadline - mailTitleInfo.date, ShowtimeType.Normal);
			}
		}

		// Token: 0x0600EA5D RID: 59997 RVA: 0x003E21BB File Offset: 0x003E05BB
		private void Update()
		{
			this.fUpdateInterval += Time.deltaTime;
			if (this.fUpdateInterval <= 60f)
			{
				return;
			}
			this.fUpdateInterval = 0f;
			this.CalSelMailLeftTime(this.mMailTitleInfo);
		}

		// Token: 0x0600EA5E RID: 59998 RVA: 0x003E21F7 File Offset: 0x003E05F7
		private void OnDestroy()
		{
			this.mMailTitleInfo = null;
			this.fUpdateInterval = 0f;
		}

		// Token: 0x04008E1F RID: 36383
		private const string MailUnReadPath = "UI/Image/Packed/p_UI_Mail.png:UI_Youjian_Tubiao_Youjianguan";

		// Token: 0x04008E20 RID: 36384
		private const string MailReadPath = "UI/Image/Packed/p_UI_Mail.png:UI_Youjian_Tubiao_YoujianKai";

		// Token: 0x04008E21 RID: 36385
		[SerializeField]
		private Text mMailTitle;

		// Token: 0x04008E22 RID: 36386
		[SerializeField]
		private Text mMailSender;

		// Token: 0x04008E23 RID: 36387
		[SerializeField]
		private Text mMailSendTime;

		// Token: 0x04008E24 RID: 36388
		[SerializeField]
		private Text mMailTimeLeft;

		// Token: 0x04008E25 RID: 36389
		[SerializeField]
		private Image mMailIcon;

		// Token: 0x04008E26 RID: 36390
		[SerializeField]
		private GameObject mNewMailPrompt;

		// Token: 0x04008E27 RID: 36391
		[SerializeField]
		private GameObject mAttachIcon;

		// Token: 0x04008E28 RID: 36392
		[SerializeField]
		private GameObject mSelectBack;

		// Token: 0x04008E29 RID: 36393
		private MailTitleInfo mMailTitleInfo;

		// Token: 0x04008E2A RID: 36394
		private float fUpdateInterval;
	}
}
