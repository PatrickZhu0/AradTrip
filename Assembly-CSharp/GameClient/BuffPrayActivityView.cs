using System;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001879 RID: 6265
	public class BuffPrayActivityView : MonoBehaviour, IActivityView, IDisposable
	{
		// Token: 0x0600F57F RID: 62847 RVA: 0x00423D75 File Offset: 0x00422175
		private void OnDestroy()
		{
			if (this.m_BuffPrayTimer != null)
			{
				this.m_BuffPrayTimer.StopTimer();
			}
		}

		// Token: 0x0600F580 RID: 62848 RVA: 0x00423D94 File Offset: 0x00422194
		private void UpdateInfo(ILimitTimeActivityModel model)
		{
			for (int i = 0; i < model.TaskDatas.Count; i++)
			{
				ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel = model.TaskDatas[i];
				if (limitTimeActivityTaskDataModel.State == OpActTaskState.OATS_FINISHED)
				{
					if (this.m_BuffPrayName != null)
					{
						this.m_BuffPrayName.text = limitTimeActivityTaskDataModel.taskName;
					}
					if (this.m_BuffPrayDesc != null)
					{
						this.m_BuffPrayDesc.text = limitTimeActivityTaskDataModel.Desc;
					}
					this.mTimer.SafeSetText(string.Format(TR.Value("activity_qi_xi_que_qiao_time"), Function.GetTimeWithoutYearNoZero((int)model.StartTime, (int)model.EndTime)));
					if (this.m_BuffPrayTimer != null)
					{
						int num = (int)(limitTimeActivityTaskDataModel.DoneNum - DataManager<TimeManager>.GetInstance().GetServerTime());
						if (num > 0)
						{
							this.m_BuffPrayTimer.SetCountdown(num);
							this.m_BuffPrayTimer.StartTimer();
						}
					}
					if (limitTimeActivityTaskDataModel.ParamNums.Count > 0)
					{
						int index = (int)limitTimeActivityTaskDataModel.ParamNums[0];
						this.SetEffects(Utility.GetBuffPrayActivityEffectPath(index));
					}
				}
			}
		}

		// Token: 0x0600F581 RID: 62849 RVA: 0x00423EB5 File Offset: 0x004222B5
		public void Close()
		{
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F582 RID: 62850 RVA: 0x00423EC2 File Offset: 0x004222C2
		public void Dispose()
		{
		}

		// Token: 0x0600F583 RID: 62851 RVA: 0x00423EC4 File Offset: 0x004222C4
		public void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			this.UpdateInfo(model);
		}

		// Token: 0x0600F584 RID: 62852 RVA: 0x00423ECD File Offset: 0x004222CD
		public void UpdateData(ILimitTimeActivityModel data)
		{
			this.UpdateInfo(data);
		}

		// Token: 0x0600F585 RID: 62853 RVA: 0x00423ED6 File Offset: 0x004222D6
		public void Show()
		{
		}

		// Token: 0x0600F586 RID: 62854 RVA: 0x00423ED8 File Offset: 0x004222D8
		public void Hide()
		{
		}

		// Token: 0x0600F587 RID: 62855 RVA: 0x00423EDA File Offset: 0x004222DA
		public void SetBuyCallBack(FashionTicketBuyActivityView.BuyCallBack buyFashion)
		{
		}

		// Token: 0x0600F588 RID: 62856 RVA: 0x00423EDC File Offset: 0x004222DC
		public void SetEffects(string sEffectPath)
		{
			if (sEffectPath != string.Empty)
			{
				GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(sEffectPath, true, 0U);
				Utility.AttachTo(gameObject, this.m_BuffEffEctRoot, false);
				gameObject.CustomActive(true);
			}
		}

		// Token: 0x0400969A RID: 38554
		[SerializeField]
		private Text m_BuffPrayTitle;

		// Token: 0x0400969B RID: 38555
		[SerializeField]
		private Text m_BuffPrayName;

		// Token: 0x0400969C RID: 38556
		[SerializeField]
		private Text m_BuffPrayDesc;

		// Token: 0x0400969D RID: 38557
		[SerializeField]
		private SimpleTimer m_BuffPrayTimer;

		// Token: 0x0400969E RID: 38558
		[SerializeField]
		private GameObject m_BuffEffEctRoot;

		// Token: 0x0400969F RID: 38559
		[SerializeField]
		private Text mTimer;
	}
}
