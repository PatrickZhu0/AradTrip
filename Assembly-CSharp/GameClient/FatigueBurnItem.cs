using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018F0 RID: 6384
	public class FatigueBurnItem : ActivityItemBase
	{
		// Token: 0x0600F8FF RID: 63743 RVA: 0x0043DF18 File Offset: 0x0043C318
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			if (data == null)
			{
				return;
			}
			base.CancelInvoke("_UpdateTime");
			switch (data.State)
			{
			case OpActTaskState.OATS_INIT:
			case OpActTaskState.OATS_UNFINISH:
				this.mOpenPanel.CustomActive(true);
				this.mTextTime.CustomActive(false);
				this.mButtonFreeze.CustomActive(false);
				this.mButtonThaw.CustomActive(false);
				break;
			case OpActTaskState.OATS_FINISHED:
				this.mLastTime = (int)data.DoneNum;
				this.mButtonFreeze.CustomActive(true);
				this.mTextTime.CustomActive(true);
				this.mButtonThaw.CustomActive(false);
				this.mOpenPanel.CustomActive(false);
				base.InvokeRepeating("_UpdateTime", 0f, 1f);
				break;
			case OpActTaskState.OATS_FAILED:
				this.mButtonFreeze.CustomActive(false);
				this.mTextTime.CustomActive(true);
				this.mButtonThaw.CustomActive(true);
				this.mOpenPanel.CustomActive(false);
				this.mTextTime.SafeSetText(Function.GetLastsTimeStr(data.DoneNum));
				break;
			}
			this.mTextDescription.SafeSetText(data.Desc);
		}

		// Token: 0x0600F900 RID: 63744 RVA: 0x0043E044 File Offset: 0x0043C444
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			List<uint> paramNums = data.ParamNums;
			int id = (int)paramNums[0];
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id, string.Empty, string.Empty);
			if (paramNums.Count > 2)
			{
				this.mTextGold.SafeSetText(paramNums[1].ToString());
				if (tableItem != null)
				{
					ETCImageLoader.LoadSprite(ref this.mImageGoldIcon, tableItem.Icon, true);
				}
			}
			if (paramNums.Count > 3)
			{
				bool flag = paramNums[3] == 1U;
				if (flag)
				{
					this.mTextName.color = this.mColorAdvance;
					this.mTextName.SafeSetText(TR.Value("activity_fatigue_burn_name_advance"));
				}
				else
				{
					this.mTextName.color = this.mColorNormal;
					this.mTextName.SafeSetText(TR.Value("activity_fatigue_burn_name_normal"));
				}
			}
			this.mButtonOpen.SafeAddOnClickListener(new UnityAction(this._OnOpenClick));
			this.mButtonFreeze.SafeAddOnClickListener(new UnityAction(this._OnFreezeClick));
			this.mButtonThaw.SafeAddOnClickListener(new UnityAction(this._OnThawClick));
		}

		// Token: 0x0600F901 RID: 63745 RVA: 0x0043E170 File Offset: 0x0043C570
		public override void Dispose()
		{
			base.Dispose();
			this.mButtonOpen.SafeRemoveOnClickListener(new UnityAction(this._OnOpenClick));
			this.mButtonFreeze.SafeRemoveOnClickListener(new UnityAction(this._OnFreezeClick));
			this.mButtonThaw.SafeRemoveOnClickListener(new UnityAction(this._OnThawClick));
		}

		// Token: 0x0600F902 RID: 63746 RVA: 0x0043E1C8 File Offset: 0x0043C5C8
		private void _UpdateTime()
		{
			if (this.mLastTime - (int)DataManager<TimeManager>.GetInstance().GetServerTime() > 0)
			{
				this.mTextTime.SafeSetText(Function.GetLastsTimeStr((double)(this.mLastTime - (int)DataManager<TimeManager>.GetInstance().GetServerTime())));
				this.mTextTime.CustomActive(true);
			}
			else
			{
				this.mTextTime.CustomActive(false);
				base.CancelInvoke("_UpdateTime");
			}
		}

		// Token: 0x0600F903 RID: 63747 RVA: 0x0043E236 File Offset: 0x0043C636
		private void _OnOpenClick()
		{
			this._OnOperation(FatigueBurnItem.Operation.Open);
		}

		// Token: 0x0600F904 RID: 63748 RVA: 0x0043E23F File Offset: 0x0043C63F
		private void _OnFreezeClick()
		{
			this._OnOperation(FatigueBurnItem.Operation.Freeze);
		}

		// Token: 0x0600F905 RID: 63749 RVA: 0x0043E248 File Offset: 0x0043C648
		private void _OnThawClick()
		{
			this._OnOperation(FatigueBurnItem.Operation.Thaw);
		}

		// Token: 0x0600F906 RID: 63750 RVA: 0x0043E251 File Offset: 0x0043C651
		private void _OnOperation(FatigueBurnItem.Operation operation)
		{
			if (this.mOnItemClick != null)
			{
				this.mOnItemClick((int)this.mId, (int)operation, 0UL);
			}
			this.mButtonCD.StartGrayCD();
		}

		// Token: 0x04009A8F RID: 39567
		[SerializeField]
		private Text mTextName;

		// Token: 0x04009A90 RID: 39568
		[SerializeField]
		private Text mTextDescription;

		// Token: 0x04009A91 RID: 39569
		[SerializeField]
		private Text mTextGold;

		// Token: 0x04009A92 RID: 39570
		[SerializeField]
		private Text mTextTime;

		// Token: 0x04009A93 RID: 39571
		[SerializeField]
		private Image mImageGoldIcon;

		// Token: 0x04009A94 RID: 39572
		[SerializeField]
		private Button mButtonOpen;

		// Token: 0x04009A95 RID: 39573
		[SerializeField]
		private Button mButtonFreeze;

		// Token: 0x04009A96 RID: 39574
		[SerializeField]
		private Button mButtonThaw;

		// Token: 0x04009A97 RID: 39575
		[SerializeField]
		private SetButtonGrayCD mButtonCD;

		// Token: 0x04009A98 RID: 39576
		[SerializeField]
		private Color mColorAdvance;

		// Token: 0x04009A99 RID: 39577
		[SerializeField]
		private Color mColorNormal;

		// Token: 0x04009A9A RID: 39578
		[SerializeField]
		private GameObject mOpenPanel;

		// Token: 0x04009A9B RID: 39579
		private int mLastTime = -1;

		// Token: 0x020018F1 RID: 6385
		private enum Operation
		{
			// Token: 0x04009A9D RID: 39581
			Open,
			// Token: 0x04009A9E RID: 39582
			Freeze,
			// Token: 0x04009A9F RID: 39583
			Thaw
		}
	}
}
