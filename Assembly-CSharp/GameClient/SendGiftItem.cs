using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200191F RID: 6431
	public class SendGiftItem : MonoBehaviour
	{
		// Token: 0x0600FA5C RID: 64092 RVA: 0x00448D6E File Offset: 0x0044716E
		private void Start()
		{
			this.mSelectToggle.SafeAddOnValueChangedListener(new UnityAction<bool>(this._OnSelect));
		}

		// Token: 0x0600FA5D RID: 64093 RVA: 0x00448D87 File Offset: 0x00447187
		private void OnDestroy()
		{
			this.mSelectToggle.SafeRemoveOnValueChangedListener(new UnityAction<bool>(this._OnSelect));
		}

		// Token: 0x0600FA5E RID: 64094 RVA: 0x00448DA0 File Offset: 0x004471A0
		public void SendData(FriendPresentInfo data, Action<FriendPresentInfo> selectAction, FriendPresentInfo curSeletData)
		{
			this.mNameTxt.SafeSetText(data.friendname);
			this.ShowHeadIcon(data);
			this.mStateTxt.SafeSetText(this.GetStateDes(data.isOnline));
			this.mMySendTxt.SafeSetText(string.Format("{0}/{1}", data.sendTimes, data.sendLimit));
			this.mSendMeTxt.SafeSetText(string.Format("{0}/{1}", data.beSendedTimes, data.beSendedLimit));
			this.mBeSendTxt.SafeSetText(string.Format("{0}/{1}", data.sendedTotalTimes, data.sendedTotalLimit));
			this.mData = data;
			this.mSelectAction = selectAction;
			if (curSeletData != null)
			{
				if (curSeletData.friendId == data.friendId)
				{
					this._SetSelected(true);
				}
				else
				{
					this._SetSelected(false);
				}
			}
		}

		// Token: 0x0600FA5F RID: 64095 RVA: 0x00448E98 File Offset: 0x00447298
		private void ShowHeadIcon(FriendPresentInfo data)
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)data.friendOcc, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					ETCImageLoader.LoadSprite(ref this.mHeadImage, tableItem2.IconPath, true);
					this.mHeadImage.SetNativeSize();
				}
			}
		}

		// Token: 0x0600FA60 RID: 64096 RVA: 0x00448F05 File Offset: 0x00447305
		private void _OnSelect(bool isOn)
		{
			if (isOn && this.mSelectAction != null)
			{
				this._SetAllowSwitchOff(false);
				this.mSelectAction(this.mData);
			}
		}

		// Token: 0x0600FA61 RID: 64097 RVA: 0x00448F30 File Offset: 0x00447330
		private void _SetSelected(bool isOn)
		{
			if (this.mSelectToggle != null)
			{
				this.mSelectToggle.isOn = isOn;
			}
		}

		// Token: 0x0600FA62 RID: 64098 RVA: 0x00448F4F File Offset: 0x0044734F
		private void _SetAllowSwitchOff(bool isCan)
		{
			if (this.mSelectToggle != null && this.mSelectToggle.group != null)
			{
				this.mSelectToggle.group.allowSwitchOff = isCan;
			}
		}

		// Token: 0x0600FA63 RID: 64099 RVA: 0x00448F89 File Offset: 0x00447389
		public void OnRecycle()
		{
			this._SetAllowSwitchOff(true);
			this._SetSelected(false);
			this._SetAllowSwitchOff(false);
			this.mData = null;
			this.mSelectAction = null;
		}

		// Token: 0x0600FA64 RID: 64100 RVA: 0x00448FB0 File Offset: 0x004473B0
		private string GetStateDes(byte state)
		{
			string result = string.Empty;
			if (state == 0)
			{
				result = TR.Value("OffOnLine_State");
			}
			else
			{
				result = TR.Value("OnLine_State");
			}
			return result;
		}

		// Token: 0x04009C4F RID: 40015
		[SerializeField]
		private Image mHeadImage;

		// Token: 0x04009C50 RID: 40016
		[SerializeField]
		private Text mNameTxt;

		// Token: 0x04009C51 RID: 40017
		[SerializeField]
		private Text mStateTxt;

		// Token: 0x04009C52 RID: 40018
		[SerializeField]
		private Text mSendMeTxt;

		// Token: 0x04009C53 RID: 40019
		[SerializeField]
		private Text mMySendTxt;

		// Token: 0x04009C54 RID: 40020
		[SerializeField]
		private Text mBeSendTxt;

		// Token: 0x04009C55 RID: 40021
		[SerializeField]
		private Toggle mSelectToggle;

		// Token: 0x04009C56 RID: 40022
		private FriendPresentInfo mData;

		// Token: 0x04009C57 RID: 40023
		private Action<FriendPresentInfo> mSelectAction;
	}
}
