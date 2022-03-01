using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001943 RID: 6467
	public class FirstPayFrame : ClientFrame
	{
		// Token: 0x0600FB64 RID: 64356 RVA: 0x0044DF64 File Offset: 0x0044C364
		protected override void _bindExUI()
		{
			this.mBtnClose = this.mBind.GetCom<Button>("btnClose");
			if (null != this.mBtnClose)
			{
				this.mBtnClose.onClick.AddListener(new UnityAction(this._onBtnCloseButtonClick));
			}
			this.mWeaponModelRoot = this.mBind.GetGameObject("weaponModelRoot");
			this.mScrollContent = this.mBind.GetGameObject("scrollContent");
			this.mWeaponName = this.mBind.GetCom<Text>("weaponName");
			this.mBtnGo = this.mBind.GetCom<Button>("btnGo");
			if (null != this.mBtnGo)
			{
				this.mBtnGo.onClick.AddListener(new UnityAction(this._onBtnGoButtonClick));
			}
			this.mBtnGet = this.mBind.GetCom<Button>("btnGet");
			if (null != this.mBtnGet)
			{
				this.mBtnGet.onClick.AddListener(new UnityAction(this._onBtnGetButtonClick));
			}
			this.mBtnGetText = this.mBind.GetCom<Text>("btnGetText");
			this.mBtnGetGray = this.mBind.GetCom<UIGray>("btnGetGray");
			this.mGotoMonthCard = this.mBind.GetCom<Button>("gotoMonthCard");
			if (null != this.mGotoMonthCard)
			{
				this.mGotoMonthCard.onClick.AddListener(new UnityAction(this._onGotoMonthCardButtonClick));
			}
			this.mGotoMoneyplan = this.mBind.GetCom<Button>("gotoMoneyplan");
			if (null != this.mGotoMoneyplan)
			{
				this.mGotoMoneyplan.onClick.AddListener(new UnityAction(this._onGotoMoneyplanButtonClick));
			}
			this.mMainView = this.mBind.GetCom<ComUIListScript>("mainView");
			this.mSpecialItem = this.mBind.GetCom<PayRewardItem>("specialItem");
			this.mHasChargeRMB = this.mBind.GetCom<Text>("HasChargeRMB");
			this.mEffectRoot_Backlight = this.mBind.GetGameObject("EffectRoot_Backlight");
			this.mEffectRoot_TopTitle = this.mBind.GetGameObject("EffectRoot_TopTitle");
			this.mEffectRoot_Envior = this.mBind.GetGameObject("EffectRoot_Envior");
			this.mEffectRoot_GoPayBtn = this.mBind.GetGameObject("EffectRoot_GoPayBtn");
		}

		// Token: 0x0600FB65 RID: 64357 RVA: 0x0044E1C8 File Offset: 0x0044C5C8
		protected override void _unbindExUI()
		{
			if (null != this.mBtnClose)
			{
				this.mBtnClose.onClick.RemoveListener(new UnityAction(this._onBtnCloseButtonClick));
			}
			this.mBtnClose = null;
			this.mWeaponModelRoot = null;
			this.mScrollContent = null;
			this.mWeaponName = null;
			if (null != this.mBtnGo)
			{
				this.mBtnGo.onClick.RemoveListener(new UnityAction(this._onBtnGoButtonClick));
			}
			this.mBtnGo = null;
			if (null != this.mBtnGet)
			{
				this.mBtnGet.onClick.RemoveListener(new UnityAction(this._onBtnGetButtonClick));
			}
			this.mBtnGet = null;
			this.mBtnGetText = null;
			this.mBtnGetGray = null;
			if (null != this.mGotoMonthCard)
			{
				this.mGotoMonthCard.onClick.RemoveListener(new UnityAction(this._onGotoMonthCardButtonClick));
			}
			this.mGotoMonthCard = null;
			if (null != this.mGotoMoneyplan)
			{
				this.mGotoMoneyplan.onClick.RemoveListener(new UnityAction(this._onGotoMoneyplanButtonClick));
			}
			this.mGotoMoneyplan = null;
			this.mMainView = null;
			this.mSpecialItem = null;
			this.mHasChargeRMB = null;
			this.mEffectRoot_Backlight = null;
			this.mEffectRoot_TopTitle = null;
			this.mEffectRoot_Envior = null;
			this.mEffectRoot_GoPayBtn = null;
		}

		// Token: 0x0600FB66 RID: 64358 RVA: 0x0044E32D File Offset: 0x0044C72D
		private void _onBtnCloseButtonClick()
		{
			this.OnClickClose();
		}

		// Token: 0x0600FB67 RID: 64359 RVA: 0x0044E338 File Offset: 0x0044C738
		private void _onBtnGoButtonClick()
		{
			this.OnClickClose();
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MallNewFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<MallNewFrame>(null, false);
			}
			MallNewFrame mallNewFrame = Singleton<ClientSystemManager>.instance.OpenFrame<MallNewFrame>(FrameLayer.Middle, new MallNewFrameParamData
			{
				MallNewType = MallNewType.ReChargeMall
			}, string.Empty) as MallNewFrame;
		}

		// Token: 0x0600FB68 RID: 64360 RVA: 0x0044E38B File Offset: 0x0044C78B
		private void _onBtnGetButtonClick()
		{
			Singleton<PayManager>.GetInstance().GetRewards(8301);
			Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(300, delegate
			{
				this.ShowButton();
				this.OnGetForstPayReward();
			}, 0, 0, false);
		}

		// Token: 0x0600FB69 RID: 64361 RVA: 0x0044E3C0 File Offset: 0x0044C7C0
		private void _onGotoMoneyplanButtonClick()
		{
			string text = typeof(ActiveChargeFrame).Name + 9380.ToString();
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen(text))
			{
				ActiveChargeFrame activeChargeFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(text) as ActiveChargeFrame;
				activeChargeFrame.Close(true);
			}
			DataManager<ActiveManager>.GetInstance().OpenActiveFrame(9380, 8600);
		}

		// Token: 0x0600FB6A RID: 64362 RVA: 0x0044E434 File Offset: 0x0044C834
		private void _onGotoMonthCardButtonClick()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MallNewFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<MallNewFrame>(null, false);
			}
			MallNewFrame mallNewFrame = Singleton<ClientSystemManager>.instance.OpenFrame<MallNewFrame>(FrameLayer.Middle, new MallNewFrameParamData
			{
				MallNewType = MallNewType.ReChargeMall
			}, string.Empty) as MallNewFrame;
		}

		// Token: 0x0600FB6B RID: 64363 RVA: 0x0044E481 File Offset: 0x0044C881
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Vip/FirstPayFrame";
		}

		// Token: 0x0600FB6C RID: 64364 RVA: 0x0044E488 File Offset: 0x0044C888
		public void OnUpdateData(UIEvent iEvent)
		{
			this.ShowReward();
			this.ShowSpecialItem();
			this.ShowButton();
			this.ShowHasChargedRMB();
		}

		// Token: 0x0600FB6D RID: 64365 RVA: 0x0044E4A2 File Offset: 0x0044C8A2
		protected override void _OnOpenFrame()
		{
			this.BindEvent();
			this.InitEffectRoot();
			this.ShowReward();
			this.ShowSpecialItem();
			this.ShowButton();
			this.ShowHasChargedRMB();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.FirstPayFrameOpen, null, null, null, null);
		}

		// Token: 0x0600FB6E RID: 64366 RVA: 0x0044E4DC File Offset: 0x0044C8DC
		protected override void _OnCloseFrame()
		{
			this.UnBindEvent();
			if (this.itemDataList != null)
			{
				this.itemDataList.Clear();
			}
			this.ClearAllPayRewardItems();
			this.ClearEffectRoot();
			this.mToGetRewardText = string.Empty;
			this.mNotGetRewardText = string.Empty;
			this.mGotRewardText = string.Empty;
		}

		// Token: 0x0600FB6F RID: 64367 RVA: 0x0044E534 File Offset: 0x0044C934
		private void InitEffectRoot()
		{
			if (this.effect_guang_go == null)
			{
				this.effect_guang_go = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_guang", true, 0U);
				Utility.AttachTo(this.effect_guang_go, this.mEffectRoot_Backlight, false);
			}
			if (this.effect_qian_go == null)
			{
				this.effect_qian_go = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_qian", true, 0U);
				Utility.AttachTo(this.effect_qian_go, this.mEffectRoot_Envior, false);
			}
			if (this.effect_zi_go == null)
			{
				this.effect_zi_go = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_zi", true, 0U);
				Utility.AttachTo(this.effect_zi_go, this.mEffectRoot_TopTitle, false);
			}
			if (this.effect_goPayBtn_go == null)
			{
				this.effect_goPayBtn_go = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_anniu", true, 0U);
				Utility.AttachTo(this.effect_goPayBtn_go, this.mEffectRoot_GoPayBtn, false);
			}
		}

		// Token: 0x0600FB70 RID: 64368 RVA: 0x0044E62C File Offset: 0x0044CA2C
		private void ClearEffectRoot()
		{
			if (this.effect_guang_go)
			{
				Object.Destroy(this.effect_guang_go);
				this.effect_guang_go = null;
			}
			if (this.effect_qian_go)
			{
				Object.Destroy(this.effect_qian_go);
				this.effect_qian_go = null;
			}
			if (this.effect_zi_go)
			{
				Object.Destroy(this.effect_zi_go);
				this.effect_zi_go = null;
			}
			if (this.effect_goPayBtn_go)
			{
				Object.Destroy(this.effect_goPayBtn_go);
				this.effect_goPayBtn_go = null;
			}
		}

		// Token: 0x0600FB71 RID: 64369 RVA: 0x0044E6C4 File Offset: 0x0044CAC4
		private void BindEvent()
		{
			NetProcess.AddMsgHandler(501127U, new Action<MsgDATA>(this.OnRecvSceneNotifyActiveTaskStatus));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.WelfareFrameClose, new ClientEventSystem.UIEventHandler(this.OnUpdateData));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMallFrameClosed, new ClientEventSystem.UIEventHandler(this.OnUpdateData));
		}

		// Token: 0x0600FB72 RID: 64370 RVA: 0x0044E720 File Offset: 0x0044CB20
		private void UnBindEvent()
		{
			NetProcess.RemoveMsgHandler(501127U, new Action<MsgDATA>(this.OnRecvSceneNotifyActiveTaskStatus));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.WelfareFrameClose, new ClientEventSystem.UIEventHandler(this.OnUpdateData));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMallFrameClosed, new ClientEventSystem.UIEventHandler(this.OnUpdateData));
		}

		// Token: 0x0600FB73 RID: 64371 RVA: 0x0044E77C File Offset: 0x0044CB7C
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

		// Token: 0x0600FB74 RID: 64372 RVA: 0x0044E7E8 File Offset: 0x0044CBE8
		private void OnClickClose()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<FirstPayFrame>(null, false);
		}

		// Token: 0x0600FB75 RID: 64373 RVA: 0x0044E7F8 File Offset: 0x0044CBF8
		private void ShowButton()
		{
			this.InitTRDesc();
			if (!Singleton<PayManager>.GetInstance().HasFirstPay())
			{
				if (this.mBtnGet)
				{
					this.mBtnGet.gameObject.CustomActive(false);
				}
				if (this.mBtnGo)
				{
					this.mBtnGo.gameObject.CustomActive(false);
				}
				if (this.mEffectRoot_GoPayBtn)
				{
					this.mEffectRoot_GoPayBtn.CustomActive(false);
				}
			}
			if (Singleton<PayManager>.GetInstance().CanGetRewards(8301))
			{
				if (this.mBtnGet)
				{
					this.mBtnGet.gameObject.CustomActive(true);
					this.mBtnGet.interactable = true;
				}
				if (this.mBtnGetText)
				{
					this.mBtnGetText.text = this.mToGetRewardText;
				}
				if (this.mBtnGetGray)
				{
					this.mBtnGetGray.enabled = false;
				}
				if (this.mBtnGo)
				{
					this.mBtnGo.gameObject.CustomActive(false);
				}
				if (this.mEffectRoot_GoPayBtn)
				{
					this.mEffectRoot_GoPayBtn.CustomActive(true);
				}
			}
			if (Singleton<PayManager>.GetInstance().HasFirstPayFinish())
			{
				if (this.mBtnGet)
				{
					this.mBtnGet.gameObject.CustomActive(true);
					this.mBtnGet.interactable = false;
				}
				if (this.mBtnGetText)
				{
					this.mBtnGetText.text = this.mGotRewardText;
				}
				if (this.mBtnGetGray)
				{
					this.mBtnGetGray.enabled = true;
				}
				if (this.mBtnGo)
				{
					this.mBtnGo.gameObject.CustomActive(false);
				}
				if (this.mEffectRoot_GoPayBtn)
				{
					this.mEffectRoot_GoPayBtn.CustomActive(false);
				}
			}
		}

		// Token: 0x0600FB76 RID: 64374 RVA: 0x0044E9E9 File Offset: 0x0044CDE9
		private void InitTRDesc()
		{
			this.mToGetRewardText = TR.Value("vip_month_card_first_buy_next_pay_return_toget");
			this.mNotGetRewardText = TR.Value("vip_month_card_first_buy_next_pay_return_notget");
			this.mGotRewardText = TR.Value("vip_month_card_first_buy_next_pay_return_got");
		}

		// Token: 0x0600FB77 RID: 64375 RVA: 0x0044EA1C File Offset: 0x0044CE1C
		private string GetWrapPath(string resPath)
		{
			string result = null;
			string text = resPath.ToLower();
			if (text.Contains("sword"))
			{
				result = "UIFlatten/Prefabs/Vip/ShowSword";
			}
			else if (text.Contains("gun"))
			{
				if (text.Contains("cannon"))
				{
					result = "UIFlatten/Prefabs/Vip/ShowGun_cannon";
				}
				else
				{
					result = "UIFlatten/Prefabs/Vip/ShowGun";
				}
			}
			else if (text.Contains("magegirl"))
			{
				result = "UIFlatten/Prefabs/Vip/ShowMage";
			}
			else if (text.Contains("fighter"))
			{
				result = "UIFlatten/Prefabs/Vip/ShowFighter";
			}
			return result;
		}

		// Token: 0x0600FB78 RID: 64376 RVA: 0x0044EAB8 File Offset: 0x0044CEB8
		private void ShowModel()
		{
			int jobTableID = DataManager<PlayerBaseData>.GetInstance().JobTableID;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(jobTableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (this.objectRenderer == null)
				{
					this.objectRenderer = this.mWeaponModelRoot.GetComponent<GeObjectRenderer>();
				}
				string[] array = tableItem.FirstPayWeapon.Split(new char[]
				{
					'_'
				});
				if (array.Length == 2)
				{
					int num = Convert.ToInt32(array[0]);
					int num2 = Convert.ToInt32(array[1]);
					string itemModulePath = Utility.GetItemModulePath(num);
					this.objectRenderer.LoadObject(itemModulePath, 30, this.GetWrapPath(itemModulePath));
					IList<int> firstPayModelTransform = tableItem.FirstPayModelTransform;
					if (firstPayModelTransform.Count >= 4)
					{
						this.objectRenderer.SetLocalScale((float)firstPayModelTransform[0] / 1000f);
						this.objectRenderer.SetLocalPosition(new Vector3((float)firstPayModelTransform[1] / 1000f, (float)firstPayModelTransform[2] / 1000f, (float)firstPayModelTransform[3] / 1000f));
					}
					ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(num, string.Empty, string.Empty);
					if (tableItem2 != null && this.mWeaponName != null)
					{
						this.mWeaponName.text = tableItem2.Name;
						if (num2 > 0)
						{
							Text text = this.mWeaponName;
							string text2 = text.text;
							text.text = string.Concat(new object[]
							{
								text2,
								"\n(强化等级+",
								num2,
								")"
							});
						}
					}
				}
			}
		}

		// Token: 0x0600FB79 RID: 64377 RVA: 0x0044EC58 File Offset: 0x0044D058
		private void ShowSpecialItem()
		{
			if (this.itemDataList == null)
			{
				return;
			}
			if (this.mMainView == null)
			{
				return;
			}
			if (!this.mMainView.IsInitialised())
			{
				this.mMainView.Initialize();
				this.mMainView.onBindItem = delegate(GameObject go)
				{
					PayRewardItem result = null;
					if (go)
					{
						result = go.GetComponent<PayRewardItem>();
					}
					return result;
				};
			}
			this.mMainView.onItemVisiable = delegate(ComUIListElementScript var)
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
					if (this.mMainView && (long)itemData.TableID == (long)((ulong)Singleton<PayManager>.GetInstance().weaponItemID))
					{
						itemData.StrengthenLevel = Singleton<PayManager>.GetInstance().weaponStrengthLevel;
					}
					PayRewardItem payRewardItem = var.gameObjectBindScript as PayRewardItem;
					if (payRewardItem != null)
					{
						payRewardItem.Initialize(this, itemData, true, false);
						payRewardItem.RefreshView(true, true);
						if (this.payRewardItems != null && !this.payRewardItems.Contains(payRewardItem))
						{
							this.payRewardItems.Add(payRewardItem);
						}
					}
				}
			};
			this.mMainView.SetElementAmount(this.itemDataList.Count);
			if (this.mSpecialItem)
			{
				int payReturnSpecialResID = Singleton<PayManager>.GetInstance().GetPayReturnSpecialResID(8301, this.itemDataList);
				ItemData detailData = ItemDataManager.CreateItemDataFromTable(payReturnSpecialResID, 100, 0);
				if (detailData == null)
				{
					Logger.LogErrorFormat("Can find !!! Please Check item data id {0} !!!", new object[]
					{
						payReturnSpecialResID
					});
					return;
				}
				this.mSpecialItem.Initialize(this, detailData, false, true);
				this.mSpecialItem.RefreshView(false, false);
				string payReturnSpecialResPath = Singleton<PayManager>.GetInstance().GetPayReturnSpecialResPath(8301, this.itemDataList);
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

		// Token: 0x0600FB7A RID: 64378 RVA: 0x0044EDB0 File Offset: 0x0044D1B0
		private void ShowReward()
		{
			Dictionary<uint, int> firstPayItems = Singleton<PayManager>.GetInstance().GetFirstPayItems();
			if (firstPayItems == null)
			{
				return;
			}
			if (this.itemDataList != null)
			{
				this.itemDataList.Clear();
			}
			AwardItemData item = new AwardItemData
			{
				ID = (int)Singleton<PayManager>.GetInstance().weaponItemID,
				Num = 1
			};
			if (this.itemDataList != null && !this.itemDataList.Contains(item))
			{
				this.itemDataList.Add(item);
			}
			foreach (KeyValuePair<uint, int> keyValuePair in firstPayItems)
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

		// Token: 0x0600FB7B RID: 64379 RVA: 0x0044EE95 File Offset: 0x0044D295
		private void ShowHasChargedRMB()
		{
			if (this.mHasChargeRMB)
			{
				this.mHasChargeRMB.text = string.Format(TR.Value("vip_month_card_first_buy_first_has_pay"), Singleton<PayManager>.GetInstance().GetCurrentRolePayMoney());
			}
		}

		// Token: 0x0600FB7C RID: 64380 RVA: 0x0044EED0 File Offset: 0x0044D2D0
		private void OnGetForstPayReward()
		{
			if (!Singleton<PayManager>.GetInstance().CanGetRewards(8301))
			{
				int currFinishActivityNum = Singleton<PayManager>.GetInstance().GetCurrFinishActivityNum();
				if (currFinishActivityNum > 1)
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<SecondPayFrame>(FrameLayer.Middle, null, string.Empty);
				}
				base.Close(false);
			}
		}

		// Token: 0x0600FB7D RID: 64381 RVA: 0x0044EF1C File Offset: 0x0044D31C
		private void OnRecvSceneNotifyActiveTaskStatus(MsgDATA data)
		{
			SceneNotifyActiveTaskStatus sceneNotifyActiveTaskStatus = new SceneNotifyActiveTaskStatus();
			sceneNotifyActiveTaskStatus.decode(data.bytes);
			if (sceneNotifyActiveTaskStatus.taskId == 8301U)
			{
				this.ShowButton();
				this.ShowHasChargedRMB();
			}
		}

		// Token: 0x04009D0F RID: 40207
		protected const string EffUI_shouchong_guang_Path = "Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_guang";

		// Token: 0x04009D10 RID: 40208
		protected const string EffUI_shouchong_qian_Path = "Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_qian";

		// Token: 0x04009D11 RID: 40209
		protected const string EffUI_shouchong_zi_Path = "Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_zi";

		// Token: 0x04009D12 RID: 40210
		protected const string EffUI_shouchong_anniu_Path = "Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_anniu";

		// Token: 0x04009D13 RID: 40211
		protected GeObjectRenderer objectRenderer;

		// Token: 0x04009D14 RID: 40212
		private string mToGetRewardText = string.Empty;

		// Token: 0x04009D15 RID: 40213
		private string mNotGetRewardText = string.Empty;

		// Token: 0x04009D16 RID: 40214
		private string mGotRewardText = string.Empty;

		// Token: 0x04009D17 RID: 40215
		private GameObject effect_guang_go;

		// Token: 0x04009D18 RID: 40216
		private GameObject effect_qian_go;

		// Token: 0x04009D19 RID: 40217
		private GameObject effect_zi_go;

		// Token: 0x04009D1A RID: 40218
		private GameObject effect_goPayBtn_go;

		// Token: 0x04009D1B RID: 40219
		private List<AwardItemData> itemDataList = new List<AwardItemData>();

		// Token: 0x04009D1C RID: 40220
		private List<PayRewardItem> payRewardItems = new List<PayRewardItem>();

		// Token: 0x04009D1D RID: 40221
		private Button mBtnClose;

		// Token: 0x04009D1E RID: 40222
		private GameObject mWeaponModelRoot;

		// Token: 0x04009D1F RID: 40223
		private GameObject mScrollContent;

		// Token: 0x04009D20 RID: 40224
		private Text mWeaponName;

		// Token: 0x04009D21 RID: 40225
		private Button mBtnGo;

		// Token: 0x04009D22 RID: 40226
		private Button mBtnGet;

		// Token: 0x04009D23 RID: 40227
		private Text mBtnGetText;

		// Token: 0x04009D24 RID: 40228
		private UIGray mBtnGetGray;

		// Token: 0x04009D25 RID: 40229
		private Button mGotoMonthCard;

		// Token: 0x04009D26 RID: 40230
		private Button mGotoMoneyplan;

		// Token: 0x04009D27 RID: 40231
		private ComUIListScript mMainView;

		// Token: 0x04009D28 RID: 40232
		private PayRewardItem mSpecialItem;

		// Token: 0x04009D29 RID: 40233
		private Text mHasChargeRMB;

		// Token: 0x04009D2A RID: 40234
		private GameObject mEffectRoot_Backlight;

		// Token: 0x04009D2B RID: 40235
		private GameObject mEffectRoot_TopTitle;

		// Token: 0x04009D2C RID: 40236
		private GameObject mEffectRoot_Envior;

		// Token: 0x04009D2D RID: 40237
		private GameObject mEffectRoot_GoPayBtn;
	}
}
