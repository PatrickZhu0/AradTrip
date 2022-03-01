using System;
using System.Collections;
using System.Text;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001168 RID: 4456
	public class PublishContentFrame : ClientFrame
	{
		// Token: 0x0600AA4E RID: 43598 RVA: 0x00244E4B File Offset: 0x0024324B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Login/Publish/Publish";
		}

		// Token: 0x0600AA4F RID: 43599 RVA: 0x00244E54 File Offset: 0x00243254
		protected override void _bindExUI()
		{
			this.mClose = this.mBind.GetCom<Button>("close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			this.mText = this.mBind.GetCom<LinkParse>("text");
			this.mScroll = this.mBind.GetCom<ScrollRect>("scroll");
			this.mComUIScirpt = this.mBind.GetCom<ComUIListScript>("comUIScirpt");
			this.mLastPage = this.mBind.GetCom<Button>("lastPage");
			this.mLastPage.onClick.AddListener(new UnityAction(this._onLastPageButtonClick));
			this.mNextPage = this.mBind.GetCom<Button>("nextPage");
			this.mNextPage.onClick.AddListener(new UnityAction(this._onNextPageButtonClick));
		}

		// Token: 0x0600AA50 RID: 43600 RVA: 0x00244F3C File Offset: 0x0024333C
		protected override void _unbindExUI()
		{
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
			this.mText = null;
			this.mScroll = null;
			this.mComUIScirpt = null;
			this.mLastPage.onClick.RemoveListener(new UnityAction(this._onLastPageButtonClick));
			this.mLastPage = null;
			this.mNextPage.onClick.RemoveListener(new UnityAction(this._onNextPageButtonClick));
			this.mNextPage = null;
		}

		// Token: 0x0600AA51 RID: 43601 RVA: 0x00244FC7 File Offset: 0x002433C7
		private void _onCloseButtonClick()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<PublishContentFrame>(this, false);
		}

		// Token: 0x0600AA52 RID: 43602 RVA: 0x00244FD5 File Offset: 0x002433D5
		private void _onLastPageButtonClick()
		{
			this.ShowPage(this.currentPage - 1);
		}

		// Token: 0x0600AA53 RID: 43603 RVA: 0x00244FE5 File Offset: 0x002433E5
		private void _onNextPageButtonClick()
		{
			this.ShowPage(this.currentPage + 1);
		}

		// Token: 0x0600AA54 RID: 43604 RVA: 0x00244FF8 File Offset: 0x002433F8
		private void ShowPage(int page)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = page * this.PAGE_LINE;
			while (num < (page + 1) * this.PAGE_LINE && num < this.lines.Length)
			{
				stringBuilder.AppendLine(this.lines[num]);
				num++;
			}
			this.mText.SetText(stringBuilder.ToString(), true);
			this.currentPage = page;
			this.mNextPage.CustomActive(false);
			this.mLastPage.CustomActive(false);
			if (this.currentPage < this.totalPages - 1)
			{
				this.mNextPage.CustomActive(true);
			}
			if (this.currentPage > 0)
			{
				this.mLastPage.CustomActive(true);
			}
		}

		// Token: 0x0600AA55 RID: 43605 RVA: 0x002450B2 File Offset: 0x002434B2
		private void _stop()
		{
			if (this.mCo != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mCo);
			}
			this.mCo = null;
		}

		// Token: 0x0600AA56 RID: 43606 RVA: 0x002450D8 File Offset: 0x002434D8
		protected override void _OnOpenFrame()
		{
			this.lines = null;
			this.currentPage = 0;
			this.totalPages = 0;
			this.PAGE_LINE = 11;
			this._stop();
			this.mCo = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._wt());
			if (this.mComUIScirpt != null)
			{
				this.mComUIScirpt.Initialize();
				this.mComUIScirpt.onItemVisiable = delegate(ComUIListElementScript item)
				{
					if (this.lines[item.m_index] != null)
					{
						item.gameObject.GetComponent<Text>().text = this.lines[item.m_index];
					}
					else
					{
						Logger.LogErrorFormat("index;{0} = null", new object[]
						{
							item.m_index
						});
					}
				};
			}
		}

		// Token: 0x0600AA57 RID: 43607 RVA: 0x00245151 File Offset: 0x00243551
		protected override void _OnCloseFrame()
		{
			this._stop();
			this.lines = null;
		}

		// Token: 0x0600AA58 RID: 43608 RVA: 0x00245160 File Offset: 0x00243560
		private IEnumerator _wt()
		{
			BaseWaitHttpRequest wt = new BaseWaitHttpRequest();
			string channelName = SDKInterface.instance.GetPlatformNameBySelect();
			wt.url = string.Format("http://{0}/info/{1}/announcement.txt", Global.PUBLISH_SERVER_ADDRESS, channelName);
			yield return wt;
			string content = wt.GetResultString();
			if (content != null)
			{
				this.lines = content.Split(new char[]
				{
					'\n'
				});
				if (this.mComUIScirpt != null)
				{
					this.mComUIScirpt.SetElementAmount(this.lines.Length);
				}
				if (this.lines.Length <= 20)
				{
					this.PAGE_LINE = 20;
				}
				this.totalPages = this.lines.Length / this.PAGE_LINE;
				if (this.lines.Length % this.PAGE_LINE > 0)
				{
					this.totalPages++;
				}
				this.ShowPage(0);
				this.mScroll.verticalNormalizedPosition = 1f;
			}
			yield break;
		}

		// Token: 0x04005F6B RID: 24427
		private Button mClose;

		// Token: 0x04005F6C RID: 24428
		private LinkParse mText;

		// Token: 0x04005F6D RID: 24429
		private ScrollRect mScroll;

		// Token: 0x04005F6E RID: 24430
		private ComUIListScript mComUIScirpt;

		// Token: 0x04005F6F RID: 24431
		private Button mLastPage;

		// Token: 0x04005F70 RID: 24432
		private Button mNextPage;

		// Token: 0x04005F71 RID: 24433
		private string[] lines;

		// Token: 0x04005F72 RID: 24434
		private int currentPage;

		// Token: 0x04005F73 RID: 24435
		private int totalPages;

		// Token: 0x04005F74 RID: 24436
		public int PAGE_LINE = 11;

		// Token: 0x04005F75 RID: 24437
		private Coroutine mCo;
	}
}
