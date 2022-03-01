using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200188C RID: 6284
	public class FashionActivityView : MonoBehaviour, IActivityView, IDisposable
	{
		// Token: 0x0600F5EC RID: 62956 RVA: 0x00425A89 File Offset: 0x00423E89
		public void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model == null)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.mModel = model;
			this.mLastTime = Time.time;
			this.UpdateTime();
		}

		// Token: 0x0600F5ED RID: 62957 RVA: 0x00425AB4 File Offset: 0x00423EB4
		public void UpdateData(ILimitTimeActivityModel model)
		{
			this.mModel = model;
			this.UpdateTime();
		}

		// Token: 0x0600F5EE RID: 62958 RVA: 0x00425AC3 File Offset: 0x00423EC3
		public void Dispose()
		{
		}

		// Token: 0x0600F5EF RID: 62959 RVA: 0x00425AC5 File Offset: 0x00423EC5
		public void Close()
		{
			this.Dispose();
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F5F0 RID: 62960 RVA: 0x00425AD8 File Offset: 0x00423ED8
		public void Show()
		{
		}

		// Token: 0x0600F5F1 RID: 62961 RVA: 0x00425ADA File Offset: 0x00423EDA
		public void Hide()
		{
		}

		// Token: 0x0600F5F2 RID: 62962 RVA: 0x00425ADC File Offset: 0x00423EDC
		private void Update()
		{
			if (Time.time - this.mLastTime > 1f)
			{
				this.UpdateTime();
				this.mLastTime = Time.time;
			}
		}

		// Token: 0x0600F5F3 RID: 62963 RVA: 0x00425B08 File Offset: 0x00423F08
		protected virtual void UpdateTime()
		{
			int num = (int)this.mLastTime - (int)DataManager<TimeManager>.GetInstance().GetServerTime();
			int num2 = num / 60 / 60;
			int num3 = num / 60 % 60;
			int num4 = num % 60;
			this.mTextTime.SafeSetText(string.Format(TR.Value("activity_fashion_time"), num2, num3, num4));
		}

		// Token: 0x040096D4 RID: 38612
		[SerializeField]
		protected Image mImageBg;

		// Token: 0x040096D5 RID: 38613
		[SerializeField]
		protected Text mTextTime;

		// Token: 0x040096D6 RID: 38614
		private float mLastTime;

		// Token: 0x040096D7 RID: 38615
		protected ILimitTimeActivityModel mModel;
	}
}
