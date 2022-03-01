using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200167A RID: 5754
	public class HonorSystemProtectCardView : MonoBehaviour
	{
		// Token: 0x0600E236 RID: 57910 RVA: 0x003A1F0D File Offset: 0x003A030D
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600E237 RID: 57911 RVA: 0x003A1F15 File Offset: 0x003A0315
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600E238 RID: 57912 RVA: 0x003A1F23 File Offset: 0x003A0323
		private void BindEvents()
		{
		}

		// Token: 0x0600E239 RID: 57913 RVA: 0x003A1F25 File Offset: 0x003A0325
		private void UnBindEvents()
		{
		}

		// Token: 0x0600E23A RID: 57914 RVA: 0x003A1F27 File Offset: 0x003A0327
		private void ClearData()
		{
			this._intervalTime = 0f;
			this._finishTimeStamp = 0U;
			this._normalProtectCardItemData = null;
			this._highProtectCardItemData = null;
		}

		// Token: 0x0600E23B RID: 57915 RVA: 0x003A1F49 File Offset: 0x003A0349
		public void InitView()
		{
			this.InitProtectCardData();
			this.InitBaseView();
			this.UpdateTimeCountDownLabel();
			this.InitProtectCardItem();
		}

		// Token: 0x0600E23C RID: 57916 RVA: 0x003A1F63 File Offset: 0x003A0363
		private void InitProtectCardData()
		{
			this._intervalTime = 0f;
			this._finishTimeStamp = DataManager<HonorSystemDataManager>.GetInstance().FinishTimeStamp;
			this.GetProtectCardItemData();
		}

		// Token: 0x0600E23D RID: 57917 RVA: 0x003A1F88 File Offset: 0x003A0388
		private void GetProtectCardItemData()
		{
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Material);
			if (itemsByPackageType == null)
			{
				return;
			}
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ulong id = itemsByPackageType[i];
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(id);
				if (item != null)
				{
					if (item.TableID == 330000252)
					{
						this._normalProtectCardItemData = item;
					}
					else if (item.TableID == 330000253)
					{
						this._highProtectCardItemData = item;
					}
				}
			}
		}

		// Token: 0x0600E23E RID: 57918 RVA: 0x003A2014 File Offset: 0x003A0414
		private void InitBaseView()
		{
			if (this.timeTitleLabel != null)
			{
				this.timeTitleLabel.text = TR.Value("Honor_System_Count_Down_Time_Title_Label");
			}
			if (this.introductionLabel != null)
			{
				this.introductionLabel.text = TR.Value("Honor_System_Protect_Card_Introduction_Label");
			}
		}

		// Token: 0x0600E23F RID: 57919 RVA: 0x003A2070 File Offset: 0x003A0470
		private void InitProtectCardItem()
		{
			if (this.normalProtectCardItem != null)
			{
				this.normalProtectCardItem.InitItem(330000252, this._normalProtectCardItemData);
			}
			if (this.highProtectCardItem != null)
			{
				this.highProtectCardItem.InitItem(330000253, this._highProtectCardItemData);
			}
		}

		// Token: 0x0600E240 RID: 57920 RVA: 0x003A20CB File Offset: 0x003A04CB
		private void OnCloseFrame()
		{
			HonorSystemUtility.OnCloseHonorSystemProtectCardFrame();
		}

		// Token: 0x0600E241 RID: 57921 RVA: 0x003A20D4 File Offset: 0x003A04D4
		private void Update()
		{
			if (this._finishTimeStamp < DataManager<TimeManager>.GetInstance().GetServerTime())
			{
				return;
			}
			this._intervalTime += Time.deltaTime;
			if (this._intervalTime >= 1f)
			{
				this._intervalTime = 0f;
				this.UpdateTimeCountDownLabel();
			}
		}

		// Token: 0x0600E242 RID: 57922 RVA: 0x003A212C File Offset: 0x003A052C
		private void UpdateTimeCountDownLabel()
		{
			if (this.timeCounterDownLabel == null)
			{
				return;
			}
			uint finishTimeStamp = this._finishTimeStamp;
			uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			string countDownTimeByDayHourMinuteSecondFormat = CountDownTimeUtility.GetCountDownTimeByDayHourMinuteSecondFormat(finishTimeStamp, serverTime);
			this.timeCounterDownLabel.text = countDownTimeByDayHourMinuteSecondFormat;
		}

		// Token: 0x0400875E RID: 34654
		private float _intervalTime;

		// Token: 0x0400875F RID: 34655
		private uint _finishTimeStamp;

		// Token: 0x04008760 RID: 34656
		private ItemData _normalProtectCardItemData;

		// Token: 0x04008761 RID: 34657
		private ItemData _highProtectCardItemData;

		// Token: 0x04008762 RID: 34658
		[Space(10f)]
		[Header("Title")]
		[Space(10f)]
		[SerializeField]
		private Text timeTitleLabel;

		// Token: 0x04008763 RID: 34659
		[SerializeField]
		private Text timeCounterDownLabel;

		// Token: 0x04008764 RID: 34660
		[SerializeField]
		private Text introductionLabel;

		// Token: 0x04008765 RID: 34661
		[Space(10f)]
		[Header("ProtectCardItem")]
		[Space(10f)]
		[SerializeField]
		private HonorSystemProtectCardItem normalProtectCardItem;

		// Token: 0x04008766 RID: 34662
		[SerializeField]
		private HonorSystemProtectCardItem highProtectCardItem;
	}
}
