using System;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001878 RID: 6264
	public class BuffPrayActivityNewView : MonoBehaviour, IActivityView, IDisposable
	{
		// Token: 0x0600F573 RID: 62835 RVA: 0x00423B44 File Offset: 0x00421F44
		public void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model != null)
			{
				this.mModel = model;
				this.UpdateInfo(model);
			}
			this.mBuffGo1Btn.SafeRemoveAllListener();
			this.mBuffGo1Btn.SafeAddOnClickListener(delegate
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<StrengthenTicketMergeFrame>(FrameLayer.Middle, null, string.Empty);
				this.CloseActivityLimitTimeFrame();
			});
			this.mBuffGo2Btn.SafeRemoveAllListener();
			this.mBuffGo2Btn.SafeAddOnClickListener(delegate
			{
				ActivityDungeonFrame.OpenLinkFrame("2003000|2");
				this.CloseActivityLimitTimeFrame();
			});
		}

		// Token: 0x0600F574 RID: 62836 RVA: 0x00423BA9 File Offset: 0x00421FA9
		public void Show()
		{
			if (this.mModel != null)
			{
				this.UpdateData(this.mModel);
			}
		}

		// Token: 0x0600F575 RID: 62837 RVA: 0x00423BC2 File Offset: 0x00421FC2
		public void UpdateData(ILimitTimeActivityModel data)
		{
			this.UpdateInfo(data);
		}

		// Token: 0x0600F576 RID: 62838 RVA: 0x00423BCB File Offset: 0x00421FCB
		public void Close()
		{
			this.mModel = null;
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F577 RID: 62839 RVA: 0x00423BDF File Offset: 0x00421FDF
		public void Dispose()
		{
		}

		// Token: 0x0600F578 RID: 62840 RVA: 0x00423BE1 File Offset: 0x00421FE1
		public void Hide()
		{
		}

		// Token: 0x0600F579 RID: 62841 RVA: 0x00423BE4 File Offset: 0x00421FE4
		private void UpdateInfo(ILimitTimeActivityModel model)
		{
			if (model.TaskDatas.Count > this.mTitleTxtArry.Length)
			{
				return;
			}
			for (int i = 0; i < model.TaskDatas.Count; i++)
			{
				ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel = model.TaskDatas[i];
				if (limitTimeActivityTaskDataModel.State == OpActTaskState.OATS_FINISHED)
				{
					if (this.mTitleTxtArry[i] != null)
					{
						this.mTitleTxtArry[i].text = limitTimeActivityTaskDataModel.taskName;
					}
					if (this.mDestxtArry[i] != null)
					{
						this.mDestxtArry[i].text = limitTimeActivityTaskDataModel.Desc;
					}
				}
			}
			if (this.mTimeTxt != null)
			{
				this.mTimeTxt.SafeSetText(string.Format(TR.Value("activity_qi_xi_que_qiao_time"), Function.GetTimeWithoutYearNoZero((int)model.StartTime, (int)model.EndTime)));
			}
			if (this.mEffectRoot != null)
			{
				Utility.ClearChild(this.mEffectRoot);
				this.SetEffects(Utility.GetBuffPrayActivityEffectPath(0));
			}
		}

		// Token: 0x0600F57A RID: 62842 RVA: 0x00423CF4 File Offset: 0x004220F4
		public void SetEffects(string sEffectPath)
		{
			if (sEffectPath != string.Empty)
			{
				GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(sEffectPath, true, 0U);
				Utility.AttachTo(gameObject, this.mEffectRoot, false);
				gameObject.CustomActive(true);
			}
		}

		// Token: 0x0600F57B RID: 62843 RVA: 0x00423D33 File Offset: 0x00422133
		private void CloseActivityLimitTimeFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ActivityLimitTimeFrame>(null, false);
		}

		// Token: 0x04009693 RID: 38547
		[SerializeField]
		private Text[] mTitleTxtArry = new Text[2];

		// Token: 0x04009694 RID: 38548
		[SerializeField]
		private Text[] mDestxtArry = new Text[2];

		// Token: 0x04009695 RID: 38549
		[SerializeField]
		private Text mTimeTxt;

		// Token: 0x04009696 RID: 38550
		[SerializeField]
		private GameObject mEffectRoot;

		// Token: 0x04009697 RID: 38551
		[SerializeField]
		private Button mBuffGo1Btn;

		// Token: 0x04009698 RID: 38552
		[SerializeField]
		private Button mBuffGo2Btn;

		// Token: 0x04009699 RID: 38553
		private ILimitTimeActivityModel mModel;
	}
}
