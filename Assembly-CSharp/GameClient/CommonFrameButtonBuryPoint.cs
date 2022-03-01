using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E17 RID: 3607
	public class CommonFrameButtonBuryPoint : MonoBehaviour
	{
		// Token: 0x170018DE RID: 6366
		// (get) Token: 0x0600906F RID: 36975 RVA: 0x001AB211 File Offset: 0x001A9611
		// (set) Token: 0x06009070 RID: 36976 RVA: 0x001AB219 File Offset: 0x001A9619
		public string FrameName
		{
			get
			{
				return this.mFrameName;
			}
			set
			{
				this.mFrameName = value;
			}
		}

		// Token: 0x170018DF RID: 6367
		// (get) Token: 0x06009071 RID: 36977 RVA: 0x001AB222 File Offset: 0x001A9622
		// (set) Token: 0x06009072 RID: 36978 RVA: 0x001AB22A File Offset: 0x001A962A
		public string ButtonName
		{
			get
			{
				return this.mName;
			}
			set
			{
				this.mName = value;
			}
		}

		// Token: 0x170018E0 RID: 6368
		// (get) Token: 0x06009073 RID: 36979 RVA: 0x001AB233 File Offset: 0x001A9633
		// (set) Token: 0x06009074 RID: 36980 RVA: 0x001AB23B File Offset: 0x001A963B
		public bool Swich
		{
			get
			{
				return this.mSwich;
			}
			set
			{
				this.mSwich = value;
			}
		}

		// Token: 0x06009075 RID: 36981 RVA: 0x001AB244 File Offset: 0x001A9644
		public void OnSendBuryingPoint()
		{
			if (this.mFrameName != string.Empty && this.mName != string.Empty && this.mSwich)
			{
				Toggle component = base.GetComponent<Toggle>();
				if (component != null)
				{
					if (component.isOn)
					{
						this.DoStartFrameOperation();
					}
				}
				else
				{
					this.DoStartFrameOperation();
				}
			}
		}

		// Token: 0x06009076 RID: 36982 RVA: 0x001AB2B8 File Offset: 0x001A96B8
		private void DoStartFrameOperation()
		{
			string dateTime = Function.GetDateTime((int)DataManager<TimeManager>.GetInstance().GetServerTime(), true);
			Singleton<GameStatisticManager>.GetInstance().DoStartFrameOperation(this.mFrameName, this.mName, dateTime);
		}

		// Token: 0x040047C1 RID: 18369
		[Header("界面名")]
		[SerializeField]
		private string mFrameName;

		// Token: 0x040047C2 RID: 18370
		[Header("button名字 或者 toggle名字")]
		[SerializeField]
		private string mName;

		// Token: 0x040047C3 RID: 18371
		[Header("开关 true 上报 false 不上报")]
		[SerializeField]
		private bool mSwich = true;
	}
}
