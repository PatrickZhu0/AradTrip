using System;
using System.Collections.Generic;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001ACF RID: 6863
	public class BeadPickView : MonoBehaviour
	{
		// Token: 0x06010D94 RID: 69012 RVA: 0x004CDEDC File Offset: 0x004CC2DC
		private void Start()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance.onUpdateItem, new ItemDataManager.OnUpdateItem(this._OnUpdateItem));
		}

		// Token: 0x06010D95 RID: 69013 RVA: 0x004CDF04 File Offset: 0x004CC304
		public void Init(BeadPickModel model, UnityAction closeCallBack, UnityAction onOkClick)
		{
			if (model == null)
			{
				return;
			}
			this.beadPickModel = model;
			this.onCloseBtnClick = closeCallBack;
			this.onOkBtnClick = onOkClick;
			this.UpdateBeadItem();
			this.CreatPickItem();
			this.mCloseBtn.SafeAddOnClickListener(this.onCloseBtnClick);
			this.mOkBtn.SafeAddOnClickListener(this.onOkBtnClick);
		}

		// Token: 0x06010D96 RID: 69014 RVA: 0x004CDF5C File Offset: 0x004CC35C
		private void UpdateBeadItem()
		{
			if (this.comItem == null)
			{
				this.comItem = ComItemManager.Create(this.mItemPos);
			}
			ItemData mItemData = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.beadPickModel.mPrecBead.preciousBeadId);
			this.comItem.Setup(mItemData, delegate(GameObject obj, ItemData item)
			{
				if (item != null)
				{
					mItemData.BeadPickNumber = this.beadPickModel.mPrecBead.pickNumber;
					mItemData.BeadReplaceNumber = this.beadPickModel.mPrecBead.beadReplaceNumber;
					DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
				}
			});
			if (this.mBeadName != null)
			{
				this.mBeadName.text = mItemData.GetColorName(string.Empty, false);
			}
		}

		// Token: 0x06010D97 RID: 69015 RVA: 0x004CE004 File Offset: 0x004CC404
		private void CreatPickItem()
		{
			for (int i = 0; i < this.beadPickModel.mBeadPickItemList.Count; i++)
			{
				BeadPickItemModel beadPickItemModel = this.beadPickModel.mBeadPickItemList[i];
				if (beadPickItemModel != null)
				{
					GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.mPickItemPath, true, 0U);
					if (gameObject == null)
					{
						Logger.LogError("加载活动预制体失败，路径:" + this.mPickItemPath);
						return;
					}
					gameObject.transform.SetParent(this.mPickItemRoot.transform, false);
					PickBeadExpendItem component = gameObject.GetComponent<PickBeadExpendItem>();
					if (component != null)
					{
						component.Init(beadPickItemModel, this.mGroup, this.beadPickModel);
					}
				}
			}
		}

		// Token: 0x06010D98 RID: 69016 RVA: 0x004CE0C4 File Offset: 0x004CC4C4
		private void _OnUpdateItem(List<Item> items)
		{
			for (int i = 0; i < items.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid);
				if (item != null)
				{
					if (item.GUID == this.beadPickModel.mEquipItemData.GUID)
					{
						this.beadPickModel.mPrecBead.pickNumber = item.PreciousBeadMountHole[this.beadPickModel.mPrecBead.index - 1].pickNumber;
						break;
					}
				}
			}
			this.UpdateBeadItem();
		}

		// Token: 0x06010D99 RID: 69017 RVA: 0x004CE160 File Offset: 0x004CC560
		private void OnDestroy()
		{
			this.beadPickModel = null;
			this.mCloseBtn.SafeRemoveOnClickListener(this.onCloseBtnClick);
			this.mOkBtn.SafeRemoveOnClickListener(this.onOkBtnClick);
			this.comItem = null;
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance.onUpdateItem, new ItemDataManager.OnUpdateItem(this._OnUpdateItem));
		}

		// Token: 0x0400ACD7 RID: 44247
		[SerializeField]
		private GameObject mItemPos;

		// Token: 0x0400ACD8 RID: 44248
		[SerializeField]
		private Text mBeadName;

		// Token: 0x0400ACD9 RID: 44249
		[SerializeField]
		private Button mOkBtn;

		// Token: 0x0400ACDA RID: 44250
		[SerializeField]
		private Button mCloseBtn;

		// Token: 0x0400ACDB RID: 44251
		[SerializeField]
		private GameObject mPickItemRoot;

		// Token: 0x0400ACDC RID: 44252
		[SerializeField]
		private ToggleGroup mGroup;

		// Token: 0x0400ACDD RID: 44253
		[SerializeField]
		private string mPickItemPath = "UIFlatten/Prefabs/SmithShop/BeadPickFrame/BeadPickItem";

		// Token: 0x0400ACDE RID: 44254
		private BeadPickModel beadPickModel;

		// Token: 0x0400ACDF RID: 44255
		private UnityAction onOkBtnClick;

		// Token: 0x0400ACE0 RID: 44256
		private UnityAction onCloseBtnClick;

		// Token: 0x0400ACE1 RID: 44257
		private List<PickBeadExpendItem> mPickBeadExpendItemList = new List<PickBeadExpendItem>();

		// Token: 0x0400ACE2 RID: 44258
		private ComItem comItem;
	}
}
