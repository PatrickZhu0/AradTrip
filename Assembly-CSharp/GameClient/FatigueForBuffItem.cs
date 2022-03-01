using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018F2 RID: 6386
	public class FatigueForBuffItem : ActivityItemBase
	{
		// Token: 0x0600F908 RID: 63752 RVA: 0x0043E288 File Offset: 0x0043C688
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			OpActTaskState state = data.State;
			if (state != OpActTaskState.OATS_OVER)
			{
				if (state != OpActTaskState.OATS_FINISHED)
				{
					this.mNotFinishGO.CustomActive(true);
					this.mHasTakenReward.CustomActive(false);
					this.mReplacedGo.CustomActive(false);
				}
				else
				{
					this.mNotFinishGO.CustomActive(false);
					this.mHasTakenReward.CustomActive(true);
					this.mReplacedGo.CustomActive(false);
				}
			}
			else
			{
				this.mNotFinishGO.CustomActive(false);
				this.mHasTakenReward.CustomActive(false);
				this.mReplacedGo.CustomActive(true);
			}
			this.mTextDescription.SafeSetText(data.Desc);
			this.mTextProgress.SafeSetText(string.Format("{0}/{1}", data.DoneNum, data.TotalNum));
			if (data.ParamNums != null && data.ParamNums.Count > 0)
			{
				int id = (int)data.ParamNums[0];
				BuffTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffTable>(id, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				ETCImageLoader.LoadSprite(ref this.mImageBuff, tableItem.Icon, true);
				this.mTextBuffDescription.SafeSetText(tableItem.Name);
			}
		}

		// Token: 0x0600F909 RID: 63753 RVA: 0x0043E3D0 File Offset: 0x0043C7D0
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
		}

		// Token: 0x04009AA0 RID: 39584
		[SerializeField]
		private Text mTextDescription;

		// Token: 0x04009AA1 RID: 39585
		[SerializeField]
		private Text mTextProgress;

		// Token: 0x04009AA2 RID: 39586
		[SerializeField]
		private Image mImageBuff;

		// Token: 0x04009AA3 RID: 39587
		[SerializeField]
		private Text mTextBuffDescription;

		// Token: 0x04009AA4 RID: 39588
		[SerializeField]
		private GameObject mHasTakenReward;

		// Token: 0x04009AA5 RID: 39589
		[SerializeField]
		private GameObject mNotFinishGO;

		// Token: 0x04009AA6 RID: 39590
		[SerializeField]
		private GameObject mReplacedGo;
	}
}
