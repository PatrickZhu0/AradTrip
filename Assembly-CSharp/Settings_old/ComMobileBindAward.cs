using System;
using System.Text.RegularExpressions;
using GameClient;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Settings_old
{
	// Token: 0x02001A20 RID: 6688
	public class ComMobileBindAward : MonoBehaviour
	{
		// Token: 0x060106C3 RID: 67267 RVA: 0x0049EB37 File Offset: 0x0049CF37
		private void OnEnable()
		{
			this.countDownNum = this.TotalCountDownNum;
		}

		// Token: 0x060106C4 RID: 67268 RVA: 0x0049EB45 File Offset: 0x0049CF45
		private void Disable()
		{
			this.UnInitBtns();
		}

		// Token: 0x060106C5 RID: 67269 RVA: 0x0049EB4D File Offset: 0x0049CF4D
		private void InitCom(ClientFrame currFrame)
		{
			this.InitBtns();
			this.InitAwardItems(currFrame);
		}

		// Token: 0x060106C6 RID: 67270 RVA: 0x0049EB5C File Offset: 0x0049CF5C
		private void InitBtns()
		{
			if (this.receiveBtn)
			{
				this.receiveBtn.onClick.RemoveListener(new UnityAction(this.OnReceiveBtnClick));
				this.receiveBtn.onClick.AddListener(new UnityAction(this.OnReceiveBtnClick));
			}
			if (this.sendVerifyBtn)
			{
				this.sendVerifyBtn.onClick.RemoveListener(new UnityAction(this.OnSendVerifyBtnClick));
				this.sendVerifyBtn.onClick.AddListener(new UnityAction(this.OnSendVerifyBtnClick));
			}
			if (this.pushVerifyBtn)
			{
				this.pushVerifyBtn.onClick.RemoveListener(new UnityAction(this.OnPushVerifyBtnClick));
				this.pushVerifyBtn.onClick.AddListener(new UnityAction(this.OnPushVerifyBtnClick));
			}
			this.InitBtnsState();
		}

		// Token: 0x060106C7 RID: 67271 RVA: 0x0049EC48 File Offset: 0x0049D048
		private void UnInitBtns()
		{
			if (this.receiveBtn)
			{
				this.receiveBtn.onClick.RemoveListener(new UnityAction(this.OnReceiveBtnClick));
			}
			if (this.sendVerifyBtn)
			{
				this.sendVerifyBtn.onClick.RemoveListener(new UnityAction(this.OnSendVerifyBtnClick));
			}
			if (this.pushVerifyBtn)
			{
				this.pushVerifyBtn.onClick.RemoveListener(new UnityAction(this.OnPushVerifyBtnClick));
			}
		}

		// Token: 0x060106C8 RID: 67272 RVA: 0x0049ECD9 File Offset: 0x0049D0D9
		private void InitBtnsState()
		{
			this.SetReceiveBtnState(ComMobileBindAward.ReceiveBtnState.UnReceive);
			this.SetSendVerifyBtnState(ComMobileBindAward.SendVerifyBtnState.Normal);
		}

		// Token: 0x060106C9 RID: 67273 RVA: 0x0049ECEC File Offset: 0x0049D0EC
		private void InitAwardItems(ClientFrame currFrame)
		{
			if (currFrame == null)
			{
				return;
			}
			if (this.awardItems != null)
			{
				for (int i = 0; i < this.awardItems.Length; i++)
				{
					ComItem comItem = currFrame.CreateComItem(this.awardItems[i].gameObject);
				}
			}
		}

		// Token: 0x060106CA RID: 67274 RVA: 0x0049ED38 File Offset: 0x0049D138
		private void OnReceiveBtnClick()
		{
		}

		// Token: 0x060106CB RID: 67275 RVA: 0x0049ED3A File Offset: 0x0049D13A
		private void OnSendVerifyBtnClick()
		{
		}

		// Token: 0x060106CC RID: 67276 RVA: 0x0049ED3C File Offset: 0x0049D13C
		private void OnPushVerifyBtnClick()
		{
		}

		// Token: 0x060106CD RID: 67277 RVA: 0x0049ED40 File Offset: 0x0049D140
		private void SetReceiveBtnState(ComMobileBindAward.ReceiveBtnState state)
		{
			if (this.receiveBtnText == null)
			{
				return;
			}
			if (state != ComMobileBindAward.ReceiveBtnState.UnReceive)
			{
				if (state != ComMobileBindAward.ReceiveBtnState.ToReceive)
				{
					if (state == ComMobileBindAward.ReceiveBtnState.Received)
					{
						this.receiveBtnText.text = "已领取";
					}
				}
				else
				{
					this.receiveBtnText.text = "领取";
				}
			}
			else
			{
				this.receiveBtnText.text = "无法领取";
			}
		}

		// Token: 0x060106CE RID: 67278 RVA: 0x0049EDB8 File Offset: 0x0049D1B8
		private void SetSendVerifyBtnState(ComMobileBindAward.SendVerifyBtnState state)
		{
			if (this.sendVerifyBtnText == null)
			{
				return;
			}
			if (state != ComMobileBindAward.SendVerifyBtnState.Normal)
			{
				if (state == ComMobileBindAward.SendVerifyBtnState.Sending)
				{
					this.sendVerifyBtnText.text = "发送验证码(" + this.countDownNum + ")";
				}
			}
			else
			{
				this.sendVerifyBtnText.text = "发送验证码";
			}
		}

		// Token: 0x060106CF RID: 67279 RVA: 0x0049EE28 File Offset: 0x0049D228
		private void StartSendVerifyCountDown()
		{
		}

		// Token: 0x060106D0 RID: 67280 RVA: 0x0049EE2C File Offset: 0x0049D22C
		private bool CheckIsRightMobileNum(string mNum)
		{
			Regex regex = new Regex("^[1]+[3,4,5,8]+\\d{9}");
			return regex.IsMatch(mNum);
		}

		// Token: 0x0400A6E0 RID: 42720
		public Transform[] awardItems;

		// Token: 0x0400A6E1 RID: 42721
		public Button receiveBtn;

		// Token: 0x0400A6E2 RID: 42722
		public Text receiveBtnText;

		// Token: 0x0400A6E3 RID: 42723
		public UIGray[] receiveGrayComs;

		// Token: 0x0400A6E4 RID: 42724
		public InputField mobileNumInput;

		// Token: 0x0400A6E5 RID: 42725
		public InputField verificationCodeInput;

		// Token: 0x0400A6E6 RID: 42726
		public Button sendVerifyBtn;

		// Token: 0x0400A6E7 RID: 42727
		public Text sendVerifyBtnText;

		// Token: 0x0400A6E8 RID: 42728
		public Button pushVerifyBtn;

		// Token: 0x0400A6E9 RID: 42729
		public int TotalCountDownNum = 60;

		// Token: 0x0400A6EA RID: 42730
		private ComMobileBindAward.ReceiveBtnState receiveBtnState;

		// Token: 0x0400A6EB RID: 42731
		private ComMobileBindAward.SendVerifyBtnState sendVerifyBtnState;

		// Token: 0x0400A6EC RID: 42732
		private int countDownNum;

		// Token: 0x02001A21 RID: 6689
		public enum ReceiveBtnState
		{
			// Token: 0x0400A6EE RID: 42734
			UnReceive,
			// Token: 0x0400A6EF RID: 42735
			ToReceive,
			// Token: 0x0400A6F0 RID: 42736
			Received
		}

		// Token: 0x02001A22 RID: 6690
		public enum SendVerifyBtnState
		{
			// Token: 0x0400A6F2 RID: 42738
			Normal,
			// Token: 0x0400A6F3 RID: 42739
			Sending
		}
	}
}
