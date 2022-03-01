using System;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020016D4 RID: 5844
	internal class ItemDoubleCheckFrame : ClientFrame
	{
		// Token: 0x0600E524 RID: 58660 RVA: 0x003B8964 File Offset: 0x003B6D64
		protected override void _bindExUI()
		{
			this.mCanNotify = this.mBind.GetCom<Toggle>("CanNotify");
			if (null != this.mCanNotify)
			{
				this.mCanNotify.onValueChanged.AddListener(new UnityAction<bool>(this._onCanNotifyToggleValueChange));
			}
			this.mCancel = this.mBind.GetCom<Button>("Cancel");
			if (null != this.mCancel)
			{
				this.mCancel.onClick.AddListener(new UnityAction(this._onCancelButtonClick));
			}
			this.mOK = this.mBind.GetCom<Button>("OK");
			if (null != this.mOK)
			{
				this.mOK.onClick.AddListener(new UnityAction(this._onOKButtonClick));
			}
			this.mText = this.mBind.GetCom<Text>("Text");
			this.mShowTip = this.mBind.GetCom<Button>("ShowTip");
			this.mShowTip.SafeAddOnClickListener(delegate
			{
				if (this.itemDataToUse != null && ItemDoubleCheckFrame.box2key != null && ItemDoubleCheckFrame.box2key.ContainsKey(this.itemDataToUse.TableID))
				{
					ItemData itemData = DataManager<ItemDataManager>.GetInstance().GetItemByTableID(ItemDoubleCheckFrame.box2key[this.itemDataToUse.TableID], true, true);
					if (itemData == null)
					{
						itemData = ItemDataManager.CreateItemDataFromTable(ItemDoubleCheckFrame.box2key[this.itemDataToUse.TableID], 100, 0);
					}
					if (itemData != null)
					{
						DataManager<ItemTipManager>.GetInstance().CloseAll();
						DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
					}
				}
			});
			this.mBtns = this.mBind.GetCom<HorizontalLayoutGroup>("btns");
		}

		// Token: 0x0600E525 RID: 58661 RVA: 0x003B8A94 File Offset: 0x003B6E94
		protected override void _unbindExUI()
		{
			if (null != this.mCanNotify)
			{
				this.mCanNotify.onValueChanged.RemoveListener(new UnityAction<bool>(this._onCanNotifyToggleValueChange));
			}
			this.mCanNotify = null;
			if (null != this.mCancel)
			{
				this.mCancel.onClick.RemoveListener(new UnityAction(this._onCancelButtonClick));
			}
			this.mCancel = null;
			if (null != this.mOK)
			{
				this.mOK.onClick.RemoveListener(new UnityAction(this._onOKButtonClick));
			}
			this.mOK = null;
			this.mText = null;
			this.mShowTip = null;
			this.mBtns = null;
		}

		// Token: 0x0600E526 RID: 58662 RVA: 0x003B8B52 File Offset: 0x003B6F52
		private void _onCanNotifyToggleValueChange(bool changed)
		{
		}

		// Token: 0x0600E527 RID: 58663 RVA: 0x003B8B54 File Offset: 0x003B6F54
		private void _onCancelButtonClick()
		{
			this.frameMgr.CloseFrame<ItemDoubleCheckFrame>(this, false);
		}

		// Token: 0x0600E528 RID: 58664 RVA: 0x003B8B63 File Offset: 0x003B6F63
		private void _onOKButtonClick()
		{
			if (this.mCallBack != null)
			{
				this.mCallBack.Invoke(this.mCanNotify.isOn);
			}
			this.frameMgr.CloseFrame<ItemDoubleCheckFrame>(this, false);
		}

		// Token: 0x0600E529 RID: 58665 RVA: 0x003B8B93 File Offset: 0x003B6F93
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Tip/ItemDoubleCheckFrame";
		}

		// Token: 0x0600E52A RID: 58666 RVA: 0x003B8B9C File Offset: 0x003B6F9C
		protected override void _OnOpenFrame()
		{
			ItemDoubleCheckData itemDoubleCheckData = this.userData as ItemDoubleCheckData;
			if (itemDoubleCheckData == null)
			{
				Logger.LogError("open ItemDoubleCheckFrame frame data is null");
				return;
			}
			this.mCallBack = itemDoubleCheckData.mCallBack;
			this.mText.text = itemDoubleCheckData.Desc.Replace("\\n", "\n");
			this.itemDataToUse = itemDoubleCheckData.itemData;
			bool flag = false;
			if (this.itemDataToUse != null && ItemDoubleCheckFrame.box2key != null && ItemDoubleCheckFrame.box2key.ContainsKey(this.itemDataToUse.TableID))
			{
				flag = true;
			}
			if (flag)
			{
				this.mShowTip.CustomActive(true);
				if (this.mBtns != null)
				{
					this.mBtns.spacing = 5f;
				}
			}
			else
			{
				this.mShowTip.CustomActive(false);
				if (this.mBtns != null)
				{
					this.mBtns.spacing = 100f;
				}
			}
		}

		// Token: 0x04008AA2 RID: 35490
		private Toggle mCanNotify;

		// Token: 0x04008AA3 RID: 35491
		private Button mCancel;

		// Token: 0x04008AA4 RID: 35492
		private Button mOK;

		// Token: 0x04008AA5 RID: 35493
		private Text mText;

		// Token: 0x04008AA6 RID: 35494
		private Button mShowTip;

		// Token: 0x04008AA7 RID: 35495
		private HorizontalLayoutGroup mBtns;

		// Token: 0x04008AA8 RID: 35496
		private UnityAction<bool> mCallBack;

		// Token: 0x04008AA9 RID: 35497
		private ItemData itemDataToUse;

		// Token: 0x04008AAA RID: 35498
		private static readonly Dictionary<int, int> box2key = new Dictionary<int, int>
		{
			{
				800001055,
				800001056
			},
			{
				800001126,
				800001127
			}
		};
	}
}
