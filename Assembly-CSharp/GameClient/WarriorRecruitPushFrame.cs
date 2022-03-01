using System;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020013C4 RID: 5060
	public class WarriorRecruitPushFrame : ClientFrame
	{
		// Token: 0x0600C470 RID: 50288 RVA: 0x002F2DC0 File Offset: 0x002F11C0
		protected override void _bindExUI()
		{
			this.mClose = this.mBind.GetCom<Button>("Close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			this.mGo = this.mBind.GetCom<Button>("Go");
			this.mGo.onClick.AddListener(new UnityAction(this._onGoButtonClick));
			this.mComItem4 = this.mBind.GetCom<ComCommonBind>("ComItem4");
			this.mComItem3 = this.mBind.GetCom<ComCommonBind>("ComItem3");
			this.mComItem2 = this.mBind.GetCom<ComCommonBind>("ComItem2");
			this.mComItem1 = this.mBind.GetCom<ComCommonBind>("ComItem1");
			this.mComBindList.Add(this.mComItem1);
			this.mComBindList.Add(this.mComItem2);
			this.mComBindList.Add(this.mComItem3);
			this.mComBindList.Add(this.mComItem4);
		}

		// Token: 0x0600C471 RID: 50289 RVA: 0x002F2ED0 File Offset: 0x002F12D0
		protected override void _unbindExUI()
		{
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
			this.mGo.onClick.RemoveListener(new UnityAction(this._onGoButtonClick));
			this.mGo = null;
			this.mComItem4 = null;
			this.mComItem3 = null;
			this.mComItem2 = null;
			this.mComItem1 = null;
			if (this.mComBindList != null)
			{
				this.mComBindList.Clear();
			}
		}

		// Token: 0x0600C472 RID: 50290 RVA: 0x002F2F55 File Offset: 0x002F1355
		private void _onGoButtonClick()
		{
			DataManager<ActiveManager>.GetInstance().OpenActiveFrame(9380, 8800);
			this._onCloseButtonClick();
		}

		// Token: 0x0600C473 RID: 50291 RVA: 0x002F2F71 File Offset: 0x002F1371
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<WarriorRecruitPushFrame>(this, false);
		}

		// Token: 0x0600C474 RID: 50292 RVA: 0x002F2F80 File Offset: 0x002F1380
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Activity/WarriorRecruit/WarriorRecruitPushFrame";
		}

		// Token: 0x0600C475 RID: 50293 RVA: 0x002F2F87 File Offset: 0x002F1387
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			this.InitInterface();
			DataManager<WarriorRecruitDataManager>.GetInstance().SendWorldQueryHirePushReq(1);
		}

		// Token: 0x0600C476 RID: 50294 RVA: 0x002F2FA0 File Offset: 0x002F13A0
		protected override void _OnCloseFrame()
		{
			base._OnCloseFrame();
			DataManager<FollowingOpenQueueManager>.GetInstance().NotifyCurrentOrderClosed();
		}

		// Token: 0x0600C477 RID: 50295 RVA: 0x002F2FB4 File Offset: 0x002F13B4
		private void InitInterface()
		{
			for (int i = 0; i < DataManager<WarriorRecruitDataManager>.GetInstance().mRecruitmentBonusPreview_OldPlayerList.Count; i++)
			{
				if (i <= this.mComBindList.Count)
				{
					int tableId = DataManager<WarriorRecruitDataManager>.GetInstance().mRecruitmentBonusPreview_OldPlayerList[i];
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(tableId, 100, 0);
					if (itemData != null)
					{
						ComCommonBind comCommonBind = this.mComBindList[i];
						if (!(comCommonBind == null))
						{
							Text com = comCommonBind.GetCom<Text>("Name");
							Image com2 = comCommonBind.GetCom<Image>("Icon");
							Button com3 = comCommonBind.GetCom<Button>("Iconbtn");
							Image com4 = comCommonBind.GetCom<Image>("Backgroud");
							if (com != null)
							{
								com.text = itemData.GetColorName(string.Empty, false);
							}
							if (com4 != null)
							{
								ETCImageLoader.LoadSprite(ref com4, itemData.GetQualityInfo().Background, true);
							}
							if (com2 != null)
							{
								ETCImageLoader.LoadSprite(ref com2, itemData.Icon, true);
							}
							if (com3 != null)
							{
								com3.onClick.RemoveAllListeners();
								com3.onClick.AddListener(delegate()
								{
									DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
								});
							}
						}
					}
				}
			}
		}

		// Token: 0x04006FE0 RID: 28640
		private List<ComCommonBind> mComBindList = new List<ComCommonBind>();

		// Token: 0x04006FE1 RID: 28641
		private Button mClose;

		// Token: 0x04006FE2 RID: 28642
		private Button mGo;

		// Token: 0x04006FE3 RID: 28643
		private ComCommonBind mComItem4;

		// Token: 0x04006FE4 RID: 28644
		private ComCommonBind mComItem3;

		// Token: 0x04006FE5 RID: 28645
		private ComCommonBind mComItem2;

		// Token: 0x04006FE6 RID: 28646
		private ComCommonBind mComItem1;
	}
}
