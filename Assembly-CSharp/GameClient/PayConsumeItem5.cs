using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200194E RID: 6478
	public class PayConsumeItem5
	{
		// Token: 0x0600FBDF RID: 64479 RVA: 0x004513B4 File Offset: 0x0044F7B4
		public PayConsumeItem5(ActiveManager.ActivityData data, GameObject parent, ClientFrame THIS)
		{
			this.Clear();
			this.data = data;
			this.parent = parent;
			this.THIS = THIS;
			if (this.root == null)
			{
				this.root = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Vip/PayConsumeItem5", true, 0U);
				if (this.root != null)
				{
					ComCommonBind component = this.root.GetComponent<ComCommonBind>();
					this.mTxtMoney = component.GetCom<Text>("txtMoney");
					this.mSpecialItem = component.GetCom<PayRewardItem>("specialItem");
					this.mGirdItem = component.GetGameObject("girdItem");
					this.mSlider = component.GetCom<Slider>("slider");
					this.mTxtProgress = component.GetCom<Text>("txtProgress");
					this.mComScrollView = component.GetCom<ComUIListScript>("comScrollView");
					this.mBtnGet = component.GetCom<Button>("btnGet");
					if (null != this.mBtnGet)
					{
						this.mBtnGet.onClick.AddListener(new UnityAction(this._onBtnGetButtonClick));
					}
					this.mBtnGetGray = component.GetCom<UIGray>("btnGetGray");
					this.mBtnGetText = component.GetCom<Text>("btnGetText");
					this.mEffectRoot_Backlight = component.GetGameObject("EffectRoot_Backlight");
					this.mEffectRoot_Envior = component.GetGameObject("EffectRoot_Envior");
					if (this.effect_guang_go == null)
					{
						this.effect_guang_go = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_guang", true, 0U);
						Utility.AttachTo(this.effect_guang_go, this.mEffectRoot_Backlight, false);
					}
					if (this.effect_fanli_go == null)
					{
						this.effect_fanli_go = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_chongzhifanli", true, 0U);
						Utility.AttachTo(this.effect_fanli_go, this.mEffectRoot_Envior, false);
					}
					this.mBtnGet.gameObject.CustomActive(true);
					Utility.AttachTo(this.root, parent, false);
				}
			}
			this.InitTRDesc();
			this.RefreshView(null);
		}

		// Token: 0x0600FBE0 RID: 64480 RVA: 0x004515E8 File Offset: 0x0044F9E8
		public void Clear()
		{
			this.ClearAllPayRewardItems();
			this.mTxtMoney = null;
			this.mSlider = null;
			this.mTxtProgress = null;
			this.mComScrollView = null;
			this.mSpecialItem = null;
			this.mGirdItem = null;
			if (null != this.mBtnGet)
			{
				this.mBtnGet.onClick.RemoveListener(new UnityAction(this._onBtnGetButtonClick));
			}
			this.mBtnGet = null;
			this.mBtnGetText = null;
			this.mBtnGetGray = null;
			this.mEffectRoot_Backlight = null;
			this.mEffectRoot_Envior = null;
			this.root = null;
			this.parent = null;
			this.data = null;
			this.THIS = null;
			if (this.itemDataList != null)
			{
				this.itemDataList.Clear();
			}
			this.mToGetRewardText = string.Empty;
			this.mNotGetRewardText = string.Empty;
			this.mGotRewardText = string.Empty;
			this.bFirstPayReturn = false;
			if (this.effect_guang_go)
			{
				Object.Destroy(this.effect_guang_go);
				this.effect_guang_go = null;
			}
		}

		// Token: 0x0600FBE1 RID: 64481 RVA: 0x004516F1 File Offset: 0x0044FAF1
		public void RefreshView(ActiveManager.ActivityData newData = null)
		{
			if (newData != null)
			{
				this.data = newData;
			}
			this.SetViewStatus();
			this.RefreshAwardData();
			this.SetMainView();
		}

		// Token: 0x0600FBE2 RID: 64482 RVA: 0x00451714 File Offset: 0x0044FB14
		private void RefreshAwardData()
		{
			if (this.data == null)
			{
				return;
			}
			Dictionary<uint, int> awardItems = Singleton<PayManager>.GetInstance().GetAwardItems(this.data);
			if (awardItems == null)
			{
				Logger.LogError("[Pay Consume Item Set Data] - Get award items is null");
				return;
			}
			if (this.itemDataList != null)
			{
				this.itemDataList.Clear();
			}
			if (this.bFirstPayReturn)
			{
				AwardItemData item = new AwardItemData
				{
					ID = (int)Singleton<PayManager>.GetInstance().weaponItemID,
					Num = 1
				};
				if (this.itemDataList != null && !this.itemDataList.Contains(item))
				{
					this.itemDataList.Add(item);
				}
			}
			foreach (KeyValuePair<uint, int> keyValuePair in awardItems)
			{
				uint key = keyValuePair.Key;
				Dictionary<uint, int>.Enumerator enumerator;
				KeyValuePair<uint, int> keyValuePair2 = enumerator.Current;
				int value = keyValuePair2.Value;
				if (this.itemDataList != null)
				{
					this.itemDataList.Add(new AwardItemData
					{
						ID = (int)key,
						Num = value
					});
				}
			}
		}

		// Token: 0x0600FBE3 RID: 64483 RVA: 0x00451820 File Offset: 0x0044FC20
		private void SetMainView()
		{
			if (this.itemDataList == null)
			{
				return;
			}
			if (this.mComScrollView == null)
			{
				return;
			}
			if (!this.mComScrollView.IsInitialised())
			{
				this.mComScrollView.Initialize();
				this.mComScrollView.onBindItem = delegate(GameObject go)
				{
					PayRewardItem result = null;
					if (go)
					{
						result = go.GetComponent<PayRewardItem>();
					}
					return result;
				};
			}
			this.mComScrollView.onItemVisiable = delegate(ComUIListElementScript var)
			{
				if (var == null)
				{
					return;
				}
				int index = var.m_index;
				if (index >= 0 && index < this.itemDataList.Count)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.itemDataList[index].ID, 100, 0);
					if (itemData == null)
					{
						Logger.LogErrorFormat("Can find !!! Please Check item data id {0} !!!", new object[]
						{
							this.itemDataList[index].ID
						});
						return;
					}
					itemData.Count = this.itemDataList[index].Num;
					if (this.bFirstPayReturn && (long)itemData.TableID == (long)((ulong)Singleton<PayManager>.GetInstance().weaponItemID))
					{
						itemData.StrengthenLevel = Singleton<PayManager>.GetInstance().weaponStrengthLevel;
					}
					PayRewardItem payRewardItem = var.gameObjectBindScript as PayRewardItem;
					if (payRewardItem != null)
					{
						payRewardItem.Initialize(this.THIS, itemData, true, true);
						payRewardItem.RefreshView(true, true);
						if (this.payRewardItems != null && !this.payRewardItems.Contains(payRewardItem))
						{
							this.payRewardItems.Add(payRewardItem);
						}
					}
				}
			};
			this.mComScrollView.SetElementAmount(this.itemDataList.Count);
			this.mComScrollView.ResetContentPosition();
			if (this.mSpecialItem)
			{
				int payReturnSpecialResID = Singleton<PayManager>.GetInstance().GetPayReturnSpecialResID(this.data.ID, this.itemDataList);
				ItemData detailData = ItemDataManager.CreateItemDataFromTable(payReturnSpecialResID, 100, 0);
				if (detailData == null)
				{
					Logger.LogErrorFormat("Can find !!! Please Check item data id {0} !!!", new object[]
					{
						payReturnSpecialResID
					});
					return;
				}
				this.mSpecialItem.Initialize(this.THIS, detailData, false, true);
				this.mSpecialItem.RefreshView(true, false);
				string payReturnSpecialResPath = Singleton<PayManager>.GetInstance().GetPayReturnSpecialResPath(this.data.ID, this.itemDataList);
				this.mSpecialItem.SetItemIcon(payReturnSpecialResPath);
				this.mSpecialItem.onPayItemClick = delegate()
				{
					if ((long)detailData.TableID == (long)((ulong)Singleton<PayManager>.GetInstance().weaponItemID))
					{
						detailData.StrengthenLevel = Singleton<PayManager>.GetInstance().weaponStrengthLevel;
					}
					DataManager<ItemTipManager>.GetInstance().ShowTip(detailData, null, 4, true, false, true);
				};
			}
		}

		// Token: 0x0600FBE4 RID: 64484 RVA: 0x00451994 File Offset: 0x0044FD94
		private void SetViewStatus()
		{
			int num;
			int num2;
			if (this.data.akActivityValues.Count == 2)
			{
				num = Convert.ToInt32(this.data.akActivityValues[0].value);
				num2 = Convert.ToInt32(this.data.akActivityValues[1].value);
				if (this.data.status > 1)
				{
					num += num2;
					num2 = 0;
				}
				this.mTxtMoney.text = (num + num2).ToString();
				if (num + num2 <= 6)
				{
					this.bFirstPayReturn = true;
				}
				else
				{
					this.bFirstPayReturn = false;
				}
			}
			else
			{
				if (this.data.status <= 1)
				{
					num = 0;
					num2 = 6;
				}
				else
				{
					num = 6;
					num2 = 0;
				}
				this.mTxtMoney.text = 6.ToString();
				this.bFirstPayReturn = true;
			}
			if (this.data.status == 2)
			{
				this.SetGetBtnStatus(true);
				this.SetGetBtnText(this.mToGetRewardText);
			}
			else if (this.data.status < 2)
			{
				this.SetGetBtnStatus(false);
				this.SetGetBtnText(this.mNotGetRewardText);
			}
			else if (this.data.status > 2)
			{
				this.SetGetBtnStatus(false);
				this.SetGetBtnText(this.mGotRewardText);
			}
			if (this.mTxtProgress)
			{
				this.mTxtProgress.text = string.Format("{0}/{1}", num, num + num2);
			}
			if (this.mSlider)
			{
				this.mSlider.value = (float)num / (float)(num + num2);
			}
		}

		// Token: 0x0600FBE5 RID: 64485 RVA: 0x00451B51 File Offset: 0x0044FF51
		private void _onBtnGetButtonClick()
		{
			Singleton<PayManager>.GetInstance().GetRewards(this.data.ID);
			Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(300, delegate
			{
				this.SetViewStatus();
				MallPayFrame mallPayFrame = Singleton<ClientSystemManager>.instance.GetFrame(typeof(MallPayFrame)) as MallPayFrame;
				VipFrame vipFrame = Singleton<ClientSystemManager>.instance.GetFrame(typeof(VipFrame)) as VipFrame;
				if (mallPayFrame != null && vipFrame != null)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UpdatePayData, null, null, null, null);
				}
			}, 0, 0, false);
		}

		// Token: 0x0600FBE6 RID: 64486 RVA: 0x00451B8C File Offset: 0x0044FF8C
		private void SetGetBtnStatus(bool active)
		{
			if (this.mBtnGetGray)
			{
				this.mBtnGetGray.enabled = !active;
			}
			if (this.mBtnGet)
			{
				this.mBtnGet.interactable = active;
			}
		}

		// Token: 0x0600FBE7 RID: 64487 RVA: 0x00451BC9 File Offset: 0x0044FFC9
		private void SetGetBtnText(string desc)
		{
			if (this.mBtnGetText)
			{
				this.mBtnGetText.text = desc;
			}
		}

		// Token: 0x0600FBE8 RID: 64488 RVA: 0x00451BE7 File Offset: 0x0044FFE7
		private void InitTRDesc()
		{
			this.mToGetRewardText = TR.Value("vip_month_card_first_buy_next_pay_return_toget");
			this.mNotGetRewardText = TR.Value("vip_month_card_first_buy_next_pay_return_notget");
			this.mGotRewardText = TR.Value("vip_month_card_first_buy_next_pay_return_got");
		}

		// Token: 0x0600FBE9 RID: 64489 RVA: 0x00451C1C File Offset: 0x0045001C
		private void ClearAllPayRewardItems()
		{
			if (this.payRewardItems != null)
			{
				for (int i = 0; i < this.payRewardItems.Count; i++)
				{
					this.payRewardItems[i].Clear();
				}
				this.payRewardItems.Clear();
			}
			if (this.mSpecialItem != null)
			{
				this.mSpecialItem.Clear();
			}
		}

		// Token: 0x04009D79 RID: 40313
		protected const string EffUI_shouchong_guang_Path = "Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_guang";

		// Token: 0x04009D7A RID: 40314
		protected const string EffUI_chongzhifanli_Path = "Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_chongzhifanli";

		// Token: 0x04009D7B RID: 40315
		public const string RES_CONUSME_ITEM5_PATH = "UIFlatten/Prefabs/Vip/PayConsumeItem5";

		// Token: 0x04009D7C RID: 40316
		private Text mTxtMoney;

		// Token: 0x04009D7D RID: 40317
		private PayRewardItem mSpecialItem;

		// Token: 0x04009D7E RID: 40318
		private GameObject mGirdItem;

		// Token: 0x04009D7F RID: 40319
		private Slider mSlider;

		// Token: 0x04009D80 RID: 40320
		private Text mTxtProgress;

		// Token: 0x04009D81 RID: 40321
		private ComUIListScript mComScrollView;

		// Token: 0x04009D82 RID: 40322
		private Button mBtnGet;

		// Token: 0x04009D83 RID: 40323
		private UIGray mBtnGetGray;

		// Token: 0x04009D84 RID: 40324
		private Text mBtnGetText;

		// Token: 0x04009D85 RID: 40325
		private GameObject mEffectRoot_Backlight;

		// Token: 0x04009D86 RID: 40326
		private GameObject mEffectRoot_Envior;

		// Token: 0x04009D87 RID: 40327
		private GameObject effect_guang_go;

		// Token: 0x04009D88 RID: 40328
		private GameObject effect_fanli_go;

		// Token: 0x04009D89 RID: 40329
		private GameObject root;

		// Token: 0x04009D8A RID: 40330
		private GameObject parent;

		// Token: 0x04009D8B RID: 40331
		private ActiveManager.ActivityData data;

		// Token: 0x04009D8C RID: 40332
		private ClientFrame THIS;

		// Token: 0x04009D8D RID: 40333
		private List<AwardItemData> itemDataList = new List<AwardItemData>();

		// Token: 0x04009D8E RID: 40334
		private List<PayRewardItem> payRewardItems = new List<PayRewardItem>();

		// Token: 0x04009D8F RID: 40335
		private bool bFirstPayReturn;

		// Token: 0x04009D90 RID: 40336
		private string mToGetRewardText = string.Empty;

		// Token: 0x04009D91 RID: 40337
		private string mNotGetRewardText = string.Empty;

		// Token: 0x04009D92 RID: 40338
		private string mGotRewardText = string.Empty;
	}
}
