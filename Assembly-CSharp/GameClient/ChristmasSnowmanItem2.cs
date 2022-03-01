using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018DD RID: 6365
	public class ChristmasSnowmanItem2 : ActivityItemBase
	{
		// Token: 0x0600F882 RID: 63618 RVA: 0x004399CC File Offset: 0x00437DCC
		public sealed override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			switch (data.State)
			{
			case OpActTaskState.OATS_INIT:
			case OpActTaskState.OATS_UNFINISH:
				this.mUnFinishImag.CustomActive(true);
				this.mFinishImage.CustomActive(false);
				this.mOverImag.CustomActive(false);
				break;
			case OpActTaskState.OATS_FINISHED:
				this.mUnFinishImag.CustomActive(false);
				this.mFinishImage.CustomActive(true);
				this.mOverImag.CustomActive(false);
				break;
			case OpActTaskState.OATS_OVER:
				this.mUnFinishImag.CustomActive(false);
				this.mFinishImage.CustomActive(false);
				this.mOverImag.CustomActive(true);
				break;
			}
			this.PetBtnOnClick(data);
		}

		// Token: 0x0600F883 RID: 63619 RVA: 0x00439A94 File Offset: 0x00437E94
		protected sealed override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (data.AwardDataList.Count > 0)
			{
				int id = (int)data.AwardDataList[0].id;
				int num = (int)data.AwardDataList[0].num;
				this.mItemData = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(id);
			}
			this.PetBtnOnClick(data);
			if (this.mTipButton != null)
			{
				this.mTipButton.onClick.RemoveAllListeners();
				this.mTipButton.onClick.AddListener(delegate()
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(this.mItemData, null, 4, true, false, true);
				});
			}
			this.GetPetID();
		}

		// Token: 0x0600F884 RID: 63620 RVA: 0x00439B34 File Offset: 0x00437F34
		public sealed override void Dispose()
		{
			base.Dispose();
			if (this.mButton != null)
			{
				this.mButton.onClick.RemoveAllListeners();
			}
			if (this.mTipButton != null)
			{
				this.mTipButton.onClick.RemoveAllListeners();
			}
			this.mItemData = null;
		}

		// Token: 0x0600F885 RID: 63621 RVA: 0x00439B90 File Offset: 0x00437F90
		private void GetPetID()
		{
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<PetTable>())
			{
				PetTable petTable = keyValuePair.Value as PetTable;
				if (petTable.PetEggID == this.mItemData.TableID)
				{
					this.mPetId = petTable.ID;
					return;
				}
			}
		}

		// Token: 0x0600F886 RID: 63622 RVA: 0x00439BFC File Offset: 0x00437FFC
		private void PetBtnOnClick(ILimitTimeActivityTaskDataModel data)
		{
			if (this.mButton != null)
			{
				this.mButton.onClick.RemoveAllListeners();
				this.mButton.onClick.AddListener(delegate()
				{
					switch (data.State)
					{
					case OpActTaskState.OATS_INIT:
					case OpActTaskState.OATS_UNFINISH:
					case OpActTaskState.OATS_OVER:
						this.OpenShowPetModelFrame();
						break;
					case OpActTaskState.OATS_FINISHED:
						this._OnItemClick();
						break;
					}
				});
			}
		}

		// Token: 0x0600F887 RID: 63623 RVA: 0x00439C5A File Offset: 0x0043805A
		private void OpenShowPetModelFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ShowPetModelFrame>(FrameLayer.Middle, this.mPetId, string.Empty);
		}

		// Token: 0x040099C8 RID: 39368
		[SerializeField]
		private Button mButton;

		// Token: 0x040099C9 RID: 39369
		[SerializeField]
		private Button mTipButton;

		// Token: 0x040099CA RID: 39370
		[SerializeField]
		private Image mFinishImage;

		// Token: 0x040099CB RID: 39371
		[SerializeField]
		private Image mUnFinishImag;

		// Token: 0x040099CC RID: 39372
		[SerializeField]
		private Image mOverImag;

		// Token: 0x040099CD RID: 39373
		[SerializeField]
		private ItemData mItemData;

		// Token: 0x040099CE RID: 39374
		private int mPetId;
	}
}
