using System;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200190D RID: 6413
	public class SpringFestivalRedEnvelopeRainItem : ActivityItemBase
	{
		// Token: 0x0600F9B5 RID: 63925 RVA: 0x004445E8 File Offset: 0x004429E8
		public sealed override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			this.mGoUnReceived.CustomActive(false);
			this.mGoReceived.CustomActive(false);
			this.mGoHasReceived.CustomActive(false);
			if (!this.bIsToReceived)
			{
				OpActTaskState state = data.State;
				if (state != OpActTaskState.OATS_UNFINISH)
				{
					if (state != OpActTaskState.OATS_FINISHED)
					{
						if (state == OpActTaskState.OATS_OVER)
						{
							this.mGoHasReceived.CustomActive(true);
						}
					}
					else
					{
						this.mGoReceived.CustomActive(true);
					}
				}
				else
				{
					this.mGoUnReceived.CustomActive(true);
				}
			}
			else
			{
				this.mGoUnReceived.CustomActive(false);
				this.mGoReceived.CustomActive(false);
				this.mGoHasReceived.CustomActive(true);
			}
			if (this.mOnlineTimeValue != null)
			{
				this.mOnlineTimeValue.text = string.Format("({0}/1)", data.ParamProgressList.Count);
			}
		}

		// Token: 0x0600F9B6 RID: 63926 RVA: 0x004446D8 File Offset: 0x00442AD8
		protected sealed override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			this.mData = data;
			if (this.mDateDesc != null)
			{
				this.mDateDesc.text = data.taskName;
			}
			string text = string.Empty;
			string text2 = string.Empty;
			string[] array = data.Desc.Split(new char[]
			{
				'，'
			});
			if (array != null && array.Length >= 2)
			{
				text = array[0];
				text2 = array[1];
			}
			if (text != string.Empty && text2 != string.Empty)
			{
				if (this.mActiveDesc != null)
				{
					this.mActiveDesc.text = text;
				}
				if (this.mOnlineTimeDesc != null)
				{
					this.mOnlineTimeDesc.text = text2;
				}
			}
			if (this.mActiveValue != null)
			{
				this.mActiveValue.text = string.Format("({0}/{1})", (int)(data.DoneNum / data.TotalNum), data.TotalNum / data.TotalNum);
			}
			if (this.mOnlineTimeValue != null)
			{
				this.mOnlineTimeValue.text = string.Format("({0}/1)", data.ParamProgressList.Count);
			}
			if (data.AwardDataList != null && data.AwardDataList.Count > 0)
			{
				OpTaskReward opTaskReward = data.AwardDataList[0];
				int id = (int)opTaskReward.id;
				int num = (int)opTaskReward.num;
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(id, 100, 0);
				if (itemData != null)
				{
					itemData.Count = num;
					if (this.mBtnItem != null)
					{
						this.mBtnItem.onClick.RemoveAllListeners();
						this.mBtnItem.onClick.AddListener(delegate()
						{
							DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
						});
					}
					if (this.mBackgroupImg != null)
					{
						ETCImageLoader.LoadSprite(ref this.mBackgroupImg, itemData.GetQualityInfo().Background, true);
					}
					if (this.mIconImg != null)
					{
						ETCImageLoader.LoadSprite(ref this.mIconImg, itemData.Icon, true);
					}
				}
			}
			if (this.mBtnReceived != null)
			{
				this.mBtnReceived.SafeAddOnClickListener(new UnityAction(this._OnItemClick));
			}
			this.RegisterAccountData(new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
			this.OnRequsetAccountData(data);
		}

		// Token: 0x0600F9B7 RID: 63927 RVA: 0x00444968 File Offset: 0x00442D68
		public sealed override void Dispose()
		{
			base.Dispose();
			if (this.mBtnReceived != null)
			{
				this.mBtnReceived.SafeRemoveOnClickListener(new UnityAction(this._OnItemClick));
			}
			this.UnRegisterAccountData(new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
			this.mData = null;
			this.bIsToReceived = false;
		}

		// Token: 0x0600F9B8 RID: 63928 RVA: 0x004449C4 File Offset: 0x00442DC4
		private void _OnActivityCounterUpdate(UIEvent uiEvent)
		{
			if (this.mData != null && (uint)uiEvent.Param1 == this.mData.DataId)
			{
				int accountTotalSubmitLimit = this.mData.AccountTotalSubmitLimit;
				int num = 0;
				int num2 = 0;
				if (accountTotalSubmitLimit > 0)
				{
					num2 = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(this.mData.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_TOTAL_SUBMIT_TASK);
					num = accountTotalSubmitLimit;
				}
				if (num > 0)
				{
					int num3 = num - num2;
					if (num3 <= 0)
					{
						this.bIsToReceived = true;
						this.mGoUnReceived.CustomActive(false);
						this.mGoReceived.CustomActive(false);
						this.mGoHasReceived.CustomActive(true);
					}
				}
			}
		}

		// Token: 0x04009BCA RID: 39882
		[SerializeField]
		private Text mDateDesc;

		// Token: 0x04009BCB RID: 39883
		[SerializeField]
		private Text mActiveDesc;

		// Token: 0x04009BCC RID: 39884
		[SerializeField]
		private Text mActiveValue;

		// Token: 0x04009BCD RID: 39885
		[SerializeField]
		private Text mOnlineTimeDesc;

		// Token: 0x04009BCE RID: 39886
		[SerializeField]
		private Text mOnlineTimeValue;

		// Token: 0x04009BCF RID: 39887
		[SerializeField]
		private Image mBackgroupImg;

		// Token: 0x04009BD0 RID: 39888
		[SerializeField]
		private Image mIconImg;

		// Token: 0x04009BD1 RID: 39889
		[SerializeField]
		private GameObject mGoUnReceived;

		// Token: 0x04009BD2 RID: 39890
		[SerializeField]
		private GameObject mGoReceived;

		// Token: 0x04009BD3 RID: 39891
		[SerializeField]
		private GameObject mGoHasReceived;

		// Token: 0x04009BD4 RID: 39892
		[SerializeField]
		private Button mBtnReceived;

		// Token: 0x04009BD5 RID: 39893
		[SerializeField]
		private Button mBtnItem;

		// Token: 0x04009BD6 RID: 39894
		private ILimitTimeActivityTaskDataModel mData;

		// Token: 0x04009BD7 RID: 39895
		private bool bIsToReceived;
	}
}
