using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015AA RID: 5546
	public class ComScrollViewPage : MonoBehaviour
	{
		// Token: 0x0600D8D6 RID: 55510 RVA: 0x003645A7 File Offset: 0x003629A7
		public void OnPointerDown()
		{
			this.downScorllBarValue = this.m_Scrollbar.value;
			Debug.Log(this.downScorllBarValue);
		}

		// Token: 0x0600D8D7 RID: 55511 RVA: 0x003645CC File Offset: 0x003629CC
		public void OnPointerUp()
		{
			if (this.m_Scrollbar.value - this.downScorllBarValue < -0.01f)
			{
				if (this.currentPage >= this.startPage)
				{
					this.AutoMove(false);
				}
				else
				{
					this.currentPage = this.startPage;
					this.m_Scrollbar.value = 1f / (this.countPage - 1f) * (this.startPage - 1f);
				}
				if (this.currentPage == this.startPage || this.m_Scrollbar.value == 1f / (this.countPage - 1f) * (this.startPage - 1f))
				{
					this.isMoved = !this.isMoved;
				}
			}
			else if (this.m_Scrollbar.value - this.downScorllBarValue > 0.01f)
			{
				if (this.currentPage <= this.endPage)
				{
					this.AutoMove(true);
				}
				else
				{
					this.currentPage = this.endPage;
					this.m_Scrollbar.value = 1f / (this.countPage - 1f) * (this.endPage - 1f);
				}
				if (this.currentPage == this.endPage || this.m_Scrollbar.value == 1f / (this.countPage - 1f) * (this.endPage - 1f))
				{
					this.isMoved = !this.isMoved;
				}
			}
			this.mMoveSpeed = 0f;
		}

		// Token: 0x0600D8D8 RID: 55512 RVA: 0x00364768 File Offset: 0x00362B68
		private void AutoMove(bool isPlayForward)
		{
			if (isPlayForward)
			{
				this.currentPage += 1f;
			}
			else
			{
				this.currentPage -= 1f;
			}
			this.mTargetValue = 1f / (this.countPage - 1f) * (this.currentPage - 1f);
			this.mNeedMove = true;
			this.currentTime = 0f;
		}

		// Token: 0x0600D8D9 RID: 55513 RVA: 0x003647DB File Offset: 0x00362BDB
		private void Start()
		{
			this.m_Scrollbar.value = 1f / (this.countPage - 1f) * (this.currentPage - 1f);
		}

		// Token: 0x0600D8DA RID: 55514 RVA: 0x00364808 File Offset: 0x00362C08
		private void Update()
		{
			if (this.mNeedMove)
			{
				if (Mathf.Abs(this.m_Scrollbar.value - this.mTargetValue) < 0.01f)
				{
					this.m_Scrollbar.value = this.mTargetValue;
					this.mNeedMove = false;
					return;
				}
				this.m_Scrollbar.value = Mathf.SmoothDamp(this.m_Scrollbar.value, this.mTargetValue, ref this.mMoveSpeed, 0.2f);
			}
			if (this.autoPlay)
			{
				this.currentTime += Time.deltaTime;
				if (this.intervalTime - this.currentTime < 0.01f)
				{
					if (!this.isMoved)
					{
						if (this.currentPage <= this.endPage)
						{
							this.AutoMove(true);
						}
						else
						{
							this.currentPage = this.endPage;
							this.m_Scrollbar.value = 1f / (this.countPage - 1f) * (this.endPage - 1f);
						}
						if (this.currentPage == this.endPage || this.m_Scrollbar.value == 1f / (this.countPage - 1f) * (this.endPage - 1f))
						{
							this.isMoved = !this.isMoved;
						}
					}
					else
					{
						if (this.currentPage >= this.startPage)
						{
							this.AutoMove(false);
						}
						else
						{
							this.currentPage = this.startPage;
							this.m_Scrollbar.value = 1f / (this.countPage - 1f) * (this.startPage - 1f);
						}
						if (this.currentPage == this.startPage || this.m_Scrollbar.value == 1f / (this.countPage - 1f) * (this.startPage - 1f))
						{
							this.isMoved = !this.isMoved;
						}
					}
				}
			}
		}

		// Token: 0x04007F68 RID: 32616
		public Scrollbar m_Scrollbar;

		// Token: 0x04007F69 RID: 32617
		public ScrollRect m_ScrollRect;

		// Token: 0x04007F6A RID: 32618
		private float mTargetValue;

		// Token: 0x04007F6B RID: 32619
		private bool mNeedMove;

		// Token: 0x04007F6C RID: 32620
		private const float MOVE_SPEED = 1f;

		// Token: 0x04007F6D RID: 32621
		private const float SMOOTH_TIME = 0.2f;

		// Token: 0x04007F6E RID: 32622
		private float mMoveSpeed;

		// Token: 0x04007F6F RID: 32623
		private float currentTime;

		// Token: 0x04007F70 RID: 32624
		public bool autoPlay;

		// Token: 0x04007F71 RID: 32625
		public float currentPage;

		// Token: 0x04007F72 RID: 32626
		public float countPage;

		// Token: 0x04007F73 RID: 32627
		public float startPage;

		// Token: 0x04007F74 RID: 32628
		public float endPage;

		// Token: 0x04007F75 RID: 32629
		public float intervalTime;

		// Token: 0x04007F76 RID: 32630
		private bool isMoved;

		// Token: 0x04007F77 RID: 32631
		private float downScorllBarValue;
	}
}
