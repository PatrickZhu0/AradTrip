using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020015C7 RID: 5575
	public class RightLowerBubbleShowsOrder : MonoBehaviour
	{
		// Token: 0x0600DA49 RID: 55881 RVA: 0x0036DEB5 File Offset: 0x0036C2B5
		private void OnDestroy()
		{
			this.timer = 0f;
			this.mBubbleType.Clear();
			this.mIsUpdata = false;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RightLowerBubbleStopAnimation, new ClientEventSystem.UIEventHandler(this.mRightLowerBubbleStopAnimation));
		}

		// Token: 0x0600DA4A RID: 55882 RVA: 0x0036DEF0 File Offset: 0x0036C2F0
		private void Start()
		{
			this.mIsPlayAnimtion = true;
			this.mIsUpdata = false;
			this.timer = 0f;
			this.mBubbleType.Clear();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RightLowerBubbleStopAnimation, new ClientEventSystem.UIEventHandler(this.mRightLowerBubbleStopAnimation));
		}

		// Token: 0x0600DA4B RID: 55883 RVA: 0x0036DF3C File Offset: 0x0036C33C
		private void mRightLowerBubbleStopAnimation(UIEvent iEvent)
		{
			BubbleShowType item = (BubbleShowType)iEvent.Param1;
			if (this.mBubbleType.Contains(item))
			{
				this.mBubbleType.Remove(item);
				this.timer = 0f;
				this.mIsPlayAnimtion = true;
			}
		}

		// Token: 0x0600DA4C RID: 55884 RVA: 0x0036DF85 File Offset: 0x0036C385
		public void AddAnimation(BubbleShowType type)
		{
			if (!this.mBubbleType.Contains(type))
			{
				this.mBubbleType.Add(type);
				this.mIsUpdata = true;
				this.mIsPlayAnimtion = true;
				this.timer = 0f;
			}
		}

		// Token: 0x0600DA4D RID: 55885 RVA: 0x0036DFC0 File Offset: 0x0036C3C0
		public void Update()
		{
			if (this.mIsUpdata)
			{
				this.timer += Time.deltaTime;
				if (this.timer > 0.2f)
				{
					if (this.mIsPlayAnimtion)
					{
						if (this.mBubbleType.Count != 0)
						{
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RightLowerBubblePlayAnimation, this.mBubbleType[0], null, null, null);
							this.mIsPlayAnimtion = false;
						}
						else
						{
							this.mIsPlayAnimtion = false;
						}
					}
					if (this.timer > 10f)
					{
						if (this.mBubbleType.Count != 0)
						{
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RightLowerBubbleStopAnimation, this.mBubbleType[0], null, null, null);
						}
						else
						{
							this.mIsUpdata = false;
						}
					}
				}
			}
		}

		// Token: 0x04008065 RID: 32869
		private float timer;

		// Token: 0x04008066 RID: 32870
		private bool mIsPlayAnimtion = true;

		// Token: 0x04008067 RID: 32871
		private bool mIsUpdata;

		// Token: 0x04008068 RID: 32872
		private List<BubbleShowType> mBubbleType = new List<BubbleShowType>();
	}
}
