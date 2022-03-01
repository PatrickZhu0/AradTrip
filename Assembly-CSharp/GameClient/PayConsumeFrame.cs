using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001950 RID: 6480
	public class PayConsumeFrame : ClientFrame
	{
		// Token: 0x0600FBF2 RID: 64498 RVA: 0x00452093 File Offset: 0x00450493
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Vip/PayConsumeFrame";
		}

		// Token: 0x0600FBF3 RID: 64499 RVA: 0x0045209A File Offset: 0x0045049A
		[UIEventHandle("btnClose")]
		private void OnClickClose()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<PayConsumeFrame>(null, false);
			this.consumeItems.Clear();
		}

		// Token: 0x0600FBF4 RID: 64500 RVA: 0x004520B4 File Offset: 0x004504B4
		[UIEventHandle("btnGoPay")]
		private void OnClickPay()
		{
			this.OnClickClose();
			VipFrame vipFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, null, string.Empty) as VipFrame;
			vipFrame.OpenPayTab();
		}

		// Token: 0x0600FBF5 RID: 64501 RVA: 0x004520E4 File Offset: 0x004504E4
		protected override void _OnOpenFrame()
		{
			bool flag = false;
			int index = -1;
			string text = string.Empty;
			string text2 = string.Empty;
			List<ActiveManager.ActivityData> items = Singleton<PayManager>.GetInstance().GetConsumeItems(false);
			if (items != null)
			{
				for (int i = 0; i < items.Count; i++)
				{
					PayConsumeItem3 item = new PayConsumeItem3(items[i], this.scrollContent, this);
					this.consumeItems.Add(item);
					if (!flag && items[i].status == 1)
					{
						flag = true;
						text = items[i].akActivityValues[0].value;
						text2 = items[i].akActivityValues[1].value;
						index = i;
					}
				}
				for (int j = 0; j < items.Count; j++)
				{
					if (items[j].status == 2)
					{
						index = j;
						break;
					}
				}
			}
			if (!flag)
			{
				this.objNextPay.CustomActive(false);
			}
			else
			{
				this.objNextPay.CustomActive(true);
				this.txtCurPay.text = text;
				this.txtNextPay.text = text2;
			}
			if (this.scroll)
			{
				this.scroll.SelectedGameObject = this.selectScrollGo;
				this.scroll.SelectedGameObject.CustomActive(false);
			}
			Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(250, delegate
			{
				PayConsumeFrame.SetScrollPositon(this.scroll, index, items.Count, 0.18f);
			}, 0, 0, false);
		}

		// Token: 0x0600FBF6 RID: 64502 RVA: 0x004522B1 File Offset: 0x004506B1
		public static void SetScrollPositon(ScrollRect scroll, int index, int count, float interval = 0.15f)
		{
			scroll.horizontalNormalizedPosition = Mathf.Max(0f, interval * (float)index);
		}

		// Token: 0x04009D9B RID: 40347
		[UIControl("content/ScrollView", null, 0)]
		private ComSelectScorllRect scroll;

		// Token: 0x04009D9C RID: 40348
		[UIObject("content/ScrollView/Viewport/Content")]
		private GameObject scrollContent;

		// Token: 0x04009D9D RID: 40349
		[UIObject("content/ScrollView/ScrollbarH")]
		private GameObject scrollBar;

		// Token: 0x04009D9E RID: 40350
		[UIControl("nextPay/curPay", null, 0)]
		private Text txtCurPay;

		// Token: 0x04009D9F RID: 40351
		[UIControl("nextPay/nextPay", null, 0)]
		private Text txtNextPay;

		// Token: 0x04009DA0 RID: 40352
		[UIObject("nextPay")]
		private GameObject objNextPay;

		// Token: 0x04009DA1 RID: 40353
		[UIObject("content/selectLights")]
		private GameObject selectScrollGo;

		// Token: 0x04009DA2 RID: 40354
		private List<PayConsumeItem3> consumeItems = new List<PayConsumeItem3>();
	}
}
