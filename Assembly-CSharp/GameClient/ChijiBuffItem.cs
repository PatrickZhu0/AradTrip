using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001104 RID: 4356
	public class ChijiBuffItem : MonoBehaviour
	{
		// Token: 0x0600A51B RID: 42267 RVA: 0x00220EC8 File Offset: 0x0021F2C8
		public void OnItemVisiable(BeFightBuff beFightBuff)
		{
			if (beFightBuff == null)
			{
				return;
			}
			this.mBeFightBuff = beFightBuff;
			this.isUpdate = true;
			this.time = (int)this.mBeFightBuff.LeftTime;
			this.SetBuffIcon();
			this.UpdateTime(this.time);
			if (this.mTipsBtn != null)
			{
				this.mTipsBtn.onClick.RemoveAllListeners();
				this.mTipsBtn.onClick.AddListener(new UnityAction(this.OnTipsButtonClick));
			}
		}

		// Token: 0x0600A51C RID: 42268 RVA: 0x00220F4B File Offset: 0x0021F34B
		private void OnTipsButtonClick()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChijiBuffTipsFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChijiBuffTipsFrame>(null, false);
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChijiBuffTipsFrame>(FrameLayer.Middle, this.mBeFightBuff.BuffID, string.Empty);
		}

		// Token: 0x0600A51D RID: 42269 RVA: 0x00220F8C File Offset: 0x0021F38C
		private void SetBuffIcon()
		{
			if (this.mBuffIcon != null)
			{
				if (this.mBeFightBuff != null)
				{
					if (this.mBeFightBuff.Table != null)
					{
						if (this.mBeFightBuff.Table.Icon != null)
						{
							if (this.mBeFightBuff.Table.Icon != string.Empty && this.mBeFightBuff.Table.Icon != "-")
							{
								ETCImageLoader.LoadSprite(ref this.mBuffIcon, this.mBeFightBuff.Table.Icon, true);
							}
							else
							{
								Logger.LogErrorFormat("吃鸡buff icon显示报错,Icon路径错误,buff id = {0}", new object[]
								{
									this.mBeFightBuff.BuffID
								});
							}
						}
						else
						{
							Logger.LogErrorFormat("吃鸡buff icon显示报错,Icon = null, buff id = {0}", new object[]
							{
								this.mBeFightBuff.BuffID
							});
						}
					}
					else
					{
						Logger.LogErrorFormat("吃鸡buff icon显示报错,mBeFightBuff.Table == null, buff id = {0}", new object[]
						{
							this.mBeFightBuff.BuffID
						});
					}
				}
				else
				{
					Logger.LogErrorFormat("吃鸡buff icon显示报错,mBeFightBuff == null", new object[0]);
				}
			}
		}

		// Token: 0x0600A51E RID: 42270 RVA: 0x002210C2 File Offset: 0x0021F4C2
		private void UpdateTime(int time)
		{
			if (this.mBuffTime != null)
			{
				this.mBuffTime.text = string.Format("{0}秒", time);
			}
		}

		// Token: 0x0600A51F RID: 42271 RVA: 0x002210F0 File Offset: 0x0021F4F0
		private void Update()
		{
			if (this.mBeFightBuff != null)
			{
				if (this.time > 0)
				{
					this.isUpdate = true;
				}
				if (this.isUpdate)
				{
					this.timer += Time.deltaTime;
					if (this.timer >= 1f)
					{
						this.time--;
						this.UpdateTime(this.time);
						this.timer = 0f;
					}
					if (this.time <= 0)
					{
						this.isUpdate = false;
					}
				}
			}
		}

		// Token: 0x0600A520 RID: 42272 RVA: 0x00221180 File Offset: 0x0021F580
		private void OnDestroy()
		{
			this.time = 0;
			this.timer = 0f;
			this.isUpdate = false;
			this.mBeFightBuff = null;
		}

		// Token: 0x04005C24 RID: 23588
		[SerializeField]
		private Image mBuffIcon;

		// Token: 0x04005C25 RID: 23589
		[SerializeField]
		private Text mBuffTime;

		// Token: 0x04005C26 RID: 23590
		[SerializeField]
		private Button mTipsBtn;

		// Token: 0x04005C27 RID: 23591
		private float timer;

		// Token: 0x04005C28 RID: 23592
		private int time;

		// Token: 0x04005C29 RID: 23593
		private bool isUpdate;

		// Token: 0x04005C2A RID: 23594
		private BeFightBuff mBeFightBuff;
	}
}
