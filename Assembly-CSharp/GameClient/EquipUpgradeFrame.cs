using System;
using System.Collections;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015D2 RID: 5586
	internal class EquipUpgradeFrame : ClientFrame
	{
		// Token: 0x0600DAD7 RID: 56023 RVA: 0x00370F34 File Offset: 0x0036F334
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/EquipRecovery/EquipUpgradeFrame";
		}

		// Token: 0x0600DAD8 RID: 56024 RVA: 0x00370F3B File Offset: 0x0036F33B
		protected sealed override void _OnOpenFrame()
		{
			this._InitData();
			this._RegisterUIEvent();
		}

		// Token: 0x0600DAD9 RID: 56025 RVA: 0x00370F49 File Offset: 0x0036F349
		protected sealed override void _OnCloseFrame()
		{
			this._ClearData();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600DADA RID: 56026 RVA: 0x00370F58 File Offset: 0x0036F358
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.EquipUpgradeSuccess, new ClientEventSystem.UIEventHandler(this._OnEquipUpgradeSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChange));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.EquipRecivertDeleteItem, new ClientEventSystem.UIEventHandler(this._OnUpdateDisplayList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.EquipUpgradeFail, new ClientEventSystem.UIEventHandler(this._OnEquipUpgradeFail));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GoldChanged, new ClientEventSystem.UIEventHandler(this._OnGoldChanged));
		}

		// Token: 0x0600DADB RID: 56027 RVA: 0x00370FEC File Offset: 0x0036F3EC
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.EquipUpgradeSuccess, new ClientEventSystem.UIEventHandler(this._OnEquipUpgradeSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChange));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.EquipRecivertDeleteItem, new ClientEventSystem.UIEventHandler(this._OnUpdateDisplayList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.EquipUpgradeFail, new ClientEventSystem.UIEventHandler(this._OnEquipUpgradeFail));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GoldChanged, new ClientEventSystem.UIEventHandler(this._OnGoldChanged));
		}

		// Token: 0x0600DADC RID: 56028 RVA: 0x0037107D File Offset: 0x0036F47D
		private void _InitData()
		{
			this.curUpgradeType = UpgradeType.stop;
			DataManager<EquipRecoveryDataManager>.GetInstance().isUpgradeing = false;
			this.upgradeEquipList.Clear();
			this._InitReturnItemScrollListBind();
			this._InitResultItemScrollListBind();
			this._UpdateEquipList();
		}

		// Token: 0x0600DADD RID: 56029 RVA: 0x003710AE File Offset: 0x0036F4AE
		private void _ClearData()
		{
			this.curUpgradeType = UpgradeType.stop;
			this.canUpgradeScore = 0;
			this.upgradeEquipList.Clear();
		}

		// Token: 0x0600DADE RID: 56030 RVA: 0x003710CC File Offset: 0x0036F4CC
		private void _UpdateEquipList()
		{
			this.canUpgradeScore = 0;
			this.upgradeEquipList.Clear();
			List<ulong> list = new List<ulong>();
			list = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.EquipRecovery);
			for (int i = 0; i < list.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(list[i]);
				if (item != null)
				{
					int num = DataManager<EquipRecoveryDataManager>.GetInstance()._GetEquipPrice(item, false);
					this.canUpgradeScore += num - item.RecoScore;
					if (num > item.RecoScore)
					{
						this.upgradeEquipList.Add(list[i]);
					}
				}
			}
			this.SortMyList();
			this.mTips.CustomActive(this.upgradeEquipList.Count == 0);
			this.mCanRedeemCount.text = this.canUpgradeScore.ToString();
			this._RefreshItemListCount();
		}

		// Token: 0x0600DADF RID: 56031 RVA: 0x003711B3 File Offset: 0x0036F5B3
		private void _UpdateResultList()
		{
			this._RefreshResultListCount();
			this.mTitleText.text = TR.Value("equip_upgrade_result_title", this.totalCount.ToString());
		}

		// Token: 0x0600DAE0 RID: 56032 RVA: 0x003711E1 File Offset: 0x0036F5E1
		private void SortMyList()
		{
			this.upgradeEquipList.Sort(delegate(ulong x, ulong y)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(x);
				int num = DataManager<EquipRecoveryDataManager>.GetInstance()._GetEquipPrice(item, false);
				ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(y);
				int num2 = DataManager<EquipRecoveryDataManager>.GetInstance()._GetEquipPrice(item2, false);
				int num3 = num - item.RecoScore;
				int value = num2 - item2.RecoScore;
				int result;
				if (num3.CompareTo(value) > 0)
				{
					result = -1;
				}
				else
				{
					result = 1;
				}
				return result;
			});
		}

		// Token: 0x0600DAE1 RID: 56033 RVA: 0x0037120B File Offset: 0x0036F60B
		private void _RefreshItemListCount()
		{
			this.mEquipUIList.SetElementAmount(this.upgradeEquipList.Count);
		}

		// Token: 0x0600DAE2 RID: 56034 RVA: 0x00371223 File Offset: 0x0036F623
		private void _RefreshResultListCount()
		{
			this.mResultUIList.SetElementAmount(this.upgradeResultList.Count);
		}

		// Token: 0x0600DAE3 RID: 56035 RVA: 0x0037123B File Offset: 0x0036F63B
		private void _InitReturnItemScrollListBind()
		{
			this.mEquipUIList.Initialize();
			this.mEquipUIList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0)
				{
					this._UpdateItemScrollListBind(item);
				}
			};
			this.mEquipUIList.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
				Button com = component.GetCom<Button>("upgrade");
				if (com != null)
				{
					com.onClick.RemoveAllListeners();
				}
				Button com2 = this.mBind.GetCom<Button>("YjUpgrade");
				if (com2 != null)
				{
					com2.onClick.RemoveAllListeners();
				}
			};
		}

		// Token: 0x0600DAE4 RID: 56036 RVA: 0x00371278 File Offset: 0x0036F678
		private void _InitResultItemScrollListBind()
		{
			this.mResultUIList.Initialize();
			this.mResultUIList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0)
				{
					this._UpdateResultScrollListBind(item);
				}
			};
			this.mResultUIList.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				GameObject gameObject = component.GetGameObject("Line");
				gameObject.CustomActive(true);
			};
		}

		// Token: 0x0600DAE5 RID: 56037 RVA: 0x003712D0 File Offset: 0x0036F6D0
		private void _UpdateResultScrollListBind(ComUIListElementScript item)
		{
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this.upgradeResultList.Count)
			{
				return;
			}
			int num = this.upgradeResultList[item.m_index];
			if (num < 0)
			{
				return;
			}
			GameObject gameObject = component.GetGameObject("Line");
			Text com = component.GetCom<Text>("Result");
			Text com2 = component.GetCom<Text>("Consume");
			if (item.m_index == 0)
			{
				gameObject.CustomActive(false);
			}
			else
			{
				gameObject.CustomActive(true);
			}
			if (num > 0)
			{
				com.text = TR.Value("equip_upgrade_succeed", num);
			}
			else
			{
				com.text = TR.Value("equip_upgrade_fail", num);
			}
			com2.text = TR.Value("equip_upgrade_consume", this.consume);
		}

		// Token: 0x0600DAE6 RID: 56038 RVA: 0x003713C8 File Offset: 0x0036F7C8
		private void _UpdateItemScrollListBind(ComUIListElementScript item)
		{
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			if (this.upgradeEquipList == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this.upgradeEquipList.Count)
			{
				return;
			}
			ulong guid = this.upgradeEquipList[item.m_index];
			ItemData itemData = DataManager<ItemDataManager>.GetInstance().GetItem(guid);
			if (itemData == null)
			{
				return;
			}
			GameObject gameObject = component.GetGameObject("itemRoot");
			Text com = component.GetCom<Text>("expectCount");
			Text com2 = component.GetCom<Text>("count");
			Button com3 = component.GetCom<Button>("upgrade");
			GameObject gameObject2 = component.GetGameObject("cannotRedeem");
			Text com4 = component.GetCom<Text>("canUpgradeScores");
			Button com5 = component.GetCom<Button>("YjUpgrade");
			int num = DataManager<EquipRecoveryDataManager>.GetInstance()._GetEquipPrice(itemData, false);
			int money = -1;
			int count = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.EQUIP_RECOVERY_WEEK_COUNT);
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<EquipRecoScUpConsRtiTable>();
			if (table == null)
			{
				return;
			}
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				EquipRecoScUpConsRtiTable equipRecoScUpConsRtiTable = keyValuePair.Value as EquipRecoScUpConsRtiTable;
				if (equipRecoScUpConsRtiTable.TimesSection.Count < 2)
				{
					break;
				}
				int num2 = -1;
				int num3 = -1;
				int.TryParse(equipRecoScUpConsRtiTable.TimesSection[0], out num2);
				int.TryParse(equipRecoScUpConsRtiTable.TimesSection[1], out num3);
				if (num2 == -1 || num3 == -1)
				{
					break;
				}
				if ((count >= num2 && count <= num3) || (count >= num2 && num3 == -1))
				{
					money = equipRecoScUpConsRtiTable.Ratio * num;
				}
			}
			com3.onClick.RemoveAllListeners();
			com3.onClick.AddListener(delegate()
			{
				string text = string.Empty;
				if (money != -1)
				{
					text = string.Format(TR.Value("equip_upgrade_tip"), money);
				}
				if (text != string.Empty && !DataManager<EquipRecoveryDataManager>.GetInstance().isUpgradeing)
				{
					SystemNotifyManager.SysNotifyMsgBoxOkCancel(text, delegate()
					{
						int money = money;
						this.consume = money;
						int nMoneyID = 0;
						SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(375, string.Empty, string.Empty);
						if (tableItem != null)
						{
							nMoneyID = tableItem.Value;
						}
						CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
						if (costInfo != null)
						{
							costInfo.nMoneyID = nMoneyID;
							DataManager<ItemTipManager>.GetInstance().CloseAll();
							costInfo.nCount = money;
							DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
							{
								this.beginScore = (this.endScore = itemData.RecoScore);
								this.beginGold = (this.endGold = this._GetUpgradeGoldCount());
								this.mYjReturn.CustomActive(false);
								this.mYjUpgradeRoot.CustomActive(true);
								this.mUpgradeResult.CustomActive(false);
								this.mImmediate.CustomActive(false);
								this.mContinueButton.CustomActive(true);
								if (this.mContinueButton != null)
								{
									this.mContinueButton.enabled = true;
								}
								if (this.mContinueButtonText != null)
								{
									this.mContinueButtonText.text = TR.Value("equip_upgrade_continue");
								}
								if (this.mContinueUIGray != null)
								{
									this.mContinueUIGray.enabled = false;
								}
								this.upgradingGuid = guid;
								if (this.mBeginCount != null)
								{
									this.mBeginCount.text = this.beginScore.ToString();
								}
								if (this.mEndCount != null)
								{
									this.mEndCount.text = this.endScore.ToString();
								}
								this.endGold = (int)DataManager<PlayerBaseData>.GetInstance().Gold;
								if (this.mConsumeCount != null)
								{
									this.mConsumeCount.text = (this.beginGold - this.endGold).ToString();
								}
								DataManager<EquipRecoveryDataManager>.GetInstance().isUpgradeing = false;
								this.curUpgradeType = UpgradeType.stop;
								DataManager<EquipRecoveryDataManager>.GetInstance()._UpgradeEquip(guid);
								this.totalCount++;
							}, "common_money_cost", null);
						}
					}, null, 0f, false);
				}
			});
			com5.onClick.RemoveAllListeners();
			com5.onClick.AddListener(delegate()
			{
				if (!DataManager<EquipRecoveryDataManager>.GetInstance().isUpgradeing)
				{
					string msgContent = TR.Value("equip_yj_upgrade_tip");
					SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
					{
						int money = money;
						this.consume = money;
						int nMoneyID = 0;
						SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(375, string.Empty, string.Empty);
						if (tableItem != null)
						{
							nMoneyID = tableItem.Value;
						}
						CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
						if (costInfo != null)
						{
							costInfo.nMoneyID = nMoneyID;
							DataManager<ItemTipManager>.GetInstance().CloseAll();
							costInfo.nCount = money;
							DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
							{
								DataManager<EquipRecoveryDataManager>.GetInstance().isUpgradeing = true;
								this.curUpgradeType = UpgradeType.begining;
								this.mYjUpgradeRoot.CustomActive(true);
								this.mYjReturn.CustomActive(true);
								this.mImmediate.CustomActive(true);
								this.mUpgradeResult.CustomActive(false);
								this.upgradingGuid = guid;
								this.beginScore = (this.endScore = itemData.RecoScore);
								this.beginGold = (this.endGold = this._GetUpgradeGoldCount());
								if (this.mBeginCount != null)
								{
									this.mBeginCount.text = this.beginScore.ToString();
								}
								if (this.mEndCount != null)
								{
									this.mEndCount.text = this.endScore.ToString();
								}
								this.mYjUpgradeEffect.CustomActive(true);
								DataManager<EquipRecoveryDataManager>.GetInstance()._UpgradeEquip(guid);
								this.totalCount++;
							}, "common_money_cost", null);
						}
					}, null, 0f, false);
				}
			});
			if (ItemDataManager.CreateItemDataFromTable(itemData.TableID, 100, 0) != null)
			{
				ComItem comItem = gameObject.GetComponentInChildren<ComItem>();
				if (comItem == null)
				{
					comItem = base.CreateComItem(gameObject);
				}
				int tableID = itemData.TableID;
				comItem.Setup(itemData, delegate(GameObject Obj, ItemData sitem)
				{
					this._OnShowTips(itemData);
				});
			}
			if (com != null)
			{
				com.text = DataManager<EquipRecoveryDataManager>.GetInstance()._GetEquipPrice(itemData);
			}
			if (com2 != null)
			{
				com2.text = itemData.RecoScore.ToString();
			}
			int num4 = DataManager<EquipRecoveryDataManager>.GetInstance()._GetEquipPrice(itemData, false);
			if (com4 != null)
			{
				com4.text = (num4 - itemData.RecoScore).ToString();
			}
		}

		// Token: 0x0600DAE7 RID: 56039 RVA: 0x003716F3 File Offset: 0x0036FAF3
		private void _OnShowTips(ItemData result)
		{
			if (result == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(result, null, 4, true, false, true);
		}

		// Token: 0x0600DAE8 RID: 56040 RVA: 0x0037170C File Offset: 0x0036FB0C
		private void _PlayEffect(int upgradeScore)
		{
			if (upgradeScore > 0)
			{
				if (this.mVictoryEffect.activeSelf)
				{
					this.mVictoryEffect.CustomActive(false);
					this.mVictoryEffect.CustomActive(true);
				}
				else
				{
					this.mVictoryEffect.CustomActive(true);
				}
			}
			if (upgradeScore == 0)
			{
				if (this.mDefeatEffect.activeSelf)
				{
					this.mDefeatEffect.CustomActive(false);
					this.mDefeatEffect.CustomActive(true);
				}
				else
				{
					this.mDefeatEffect.CustomActive(true);
				}
			}
		}

		// Token: 0x0600DAE9 RID: 56041 RVA: 0x00371798 File Offset: 0x0036FB98
		private void _StartYjUpgrade()
		{
		}

		// Token: 0x0600DAEA RID: 56042 RVA: 0x0037179C File Offset: 0x0036FB9C
		private void _DisplayYjUpgrade()
		{
			if (DataManager<EquipRecoveryDataManager>.GetInstance().isUpgradeing)
			{
				this.mContinueButton.CustomActive(false);
				if ((int)DataManager<PlayerBaseData>.GetInstance().Gold < this.consume && this.upgradeScore == 0)
				{
					this.mContinueUIGray.enabled = true;
					this.mContinueButton.enabled = false;
					this.mContinueButton.CustomActive(true);
					this.mContinueButtonText.text = TR.Value("equip_upgrade_nomoney");
					this.mContinueButton.CustomActive(true);
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("equip_upgrade_nomoney_notice"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				}
			}
			else
			{
				if ((int)DataManager<PlayerBaseData>.GetInstance().Gold < this.consume && this.upgradeScore == 0)
				{
					this.mContinueUIGray.enabled = true;
					this.mContinueButton.enabled = false;
					this.mContinueButton.CustomActive(true);
					this.mContinueButtonText.text = TR.Value("equip_upgrade_nomoney");
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("equip_upgrade_nomoney_notice"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				}
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(this.upgradingGuid);
				int num = DataManager<EquipRecoveryDataManager>.GetInstance()._GetEquipPrice(item, false);
				if (num == item.RecoScore)
				{
					this.mContinueUIGray.enabled = true;
					this.mContinueButton.enabled = false;
					this.mContinueButton.CustomActive(true);
					this.mContinueButtonText.text = TR.Value("equip_upgrade_highscore");
				}
			}
			this.upgradeScore = -1;
			this.mYjReturn.CustomActive(false);
			this.mImmediate.CustomActive(false);
			this.mYjUpgradeRoot.CustomActive(true);
			this.curUpgradeType = UpgradeType.stop;
			this.mBeginCount.text = this.beginScore.ToString();
			this.mEndCount.text = this.endScore.ToString();
			this.endGold = (int)DataManager<PlayerBaseData>.GetInstance().Gold;
			this.mConsumeCount.text = (this.beginGold - this.endGold).ToString();
			if (this.beginScore != this.endScore)
			{
				this.mEndCount.color = Color.green;
			}
			else
			{
				this.mEndCount.color = Color.white;
			}
			base.StartCoroutine(this.OpenRewardFrame());
		}

		// Token: 0x0600DAEB RID: 56043 RVA: 0x003719F0 File Offset: 0x0036FDF0
		private IEnumerator OpenRewardFrame()
		{
			this.mYjUpgradeEffect.CustomActive(false);
			this.curUpgradeType = UpgradeType.stop;
			yield return new WaitForSeconds(1f);
			this._UpdateResultList();
			this.mFinishUIGray.enabled = false;
			this.mBtOk.enabled = true;
			this.mUpgradeResult.CustomActive(true);
			yield return null;
			yield break;
		}

		// Token: 0x0600DAEC RID: 56044 RVA: 0x00371A0C File Offset: 0x0036FE0C
		private int _GetUpgradeGoldCount()
		{
			int num = 0;
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(375, string.Empty, string.Empty);
			if (tableItem != null)
			{
				num = tableItem.Value;
			}
			ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(num, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				this.mConsumeImage.SafeSetImage(tableItem2.Icon, false);
			}
			return DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(num, true);
		}

		// Token: 0x0600DAED RID: 56045 RVA: 0x00371A7C File Offset: 0x0036FE7C
		private void _OnEquipUpgradeSuccess(UIEvent eventID)
		{
			this.upgradeScore = (int)eventID.Param1;
			this.upgradeResultList.Add(this.upgradeScore);
			if (this.upgradeScore > 0)
			{
				this.upgradeResultList.Reverse();
			}
			this.endScore += this.upgradeScore;
			if (this.beginScore < this.endScore)
			{
				this.mEndCount.color = Color.green;
			}
			else
			{
				this.mEndCount.color = Color.white;
			}
			this.mEndCount.text = this.endScore.ToString();
		}

		// Token: 0x0600DAEE RID: 56046 RVA: 0x00371B28 File Offset: 0x0036FF28
		private IEnumerator tryUpgradeAgain()
		{
			if ((int)DataManager<PlayerBaseData>.GetInstance().Gold < this.consume)
			{
				this.curUpgradeType = UpgradeType.stop;
				this._DisplayYjUpgrade();
				yield return null;
			}
			yield return new WaitForSeconds(1f);
			if (this.curUpgradeType == UpgradeType.begining && DataManager<EquipRecoveryDataManager>.GetInstance().isUpgradeing && this.mYjUpgradeRoot.activeSelf && !this.mUpgradeResult.activeSelf)
			{
				DataManager<EquipRecoveryDataManager>.GetInstance()._UpgradeEquip(this.upgradingGuid);
				this.totalCount++;
			}
			if (this.curUpgradeType == UpgradeType.immediately && DataManager<EquipRecoveryDataManager>.GetInstance().isUpgradeing && this.mYjUpgradeRoot.activeSelf)
			{
				this.upgradeAgain();
			}
			yield return null;
			yield break;
		}

		// Token: 0x0600DAEF RID: 56047 RVA: 0x00371B44 File Offset: 0x0036FF44
		private void upgradeAgain()
		{
			if ((int)DataManager<PlayerBaseData>.GetInstance().Gold < this.consume)
			{
				this.curUpgradeType = UpgradeType.stop;
				this._DisplayYjUpgrade();
				return;
			}
			if (this.curUpgradeType == UpgradeType.immediately && DataManager<EquipRecoveryDataManager>.GetInstance().isUpgradeing && this.mYjUpgradeRoot.activeSelf)
			{
				DataManager<EquipRecoveryDataManager>.GetInstance()._UpgradeEquip(this.upgradingGuid);
				this.totalCount++;
			}
		}

		// Token: 0x0600DAF0 RID: 56048 RVA: 0x00371BBE File Offset: 0x0036FFBE
		private void _OnCountValueChange(UIEvent eventID)
		{
		}

		// Token: 0x0600DAF1 RID: 56049 RVA: 0x00371BC0 File Offset: 0x0036FFC0
		private void _OnUpdateDisplayList(UIEvent eventID)
		{
			this._UpdateEquipList();
		}

		// Token: 0x0600DAF2 RID: 56050 RVA: 0x00371BC8 File Offset: 0x0036FFC8
		private void _OnEquipUpgradeFail(UIEvent eventID)
		{
			this.upgradeScore = -1;
			if (this.curUpgradeType == UpgradeType.returned)
			{
				this._DisplayYjUpgrade();
			}
			else
			{
				this.curUpgradeType = UpgradeType.fail;
				this._DisplayYjUpgrade();
			}
		}

		// Token: 0x0600DAF3 RID: 56051 RVA: 0x00371BF8 File Offset: 0x0036FFF8
		private void _OnGoldChanged(UIEvent eventID)
		{
			this.endGold = (int)DataManager<PlayerBaseData>.GetInstance().Gold;
			this.mConsumeCount.text = (this.beginGold - this.endGold).ToString();
			if (this.upgradeScore < 0)
			{
				return;
			}
			if (DataManager<EquipRecoveryDataManager>.GetInstance().isUpgradeing)
			{
				if (this.upgradeScore > 0)
				{
					this._UpdateEquipList();
					this._PlayEffect(this.upgradeScore);
					this.curUpgradeType = UpgradeType.success;
					this._DisplayYjUpgrade();
				}
				else if (this.curUpgradeType == UpgradeType.begining)
				{
					this._PlayEffect(this.upgradeScore);
					base.StartCoroutine(this.tryUpgradeAgain());
				}
				else if (this.curUpgradeType == UpgradeType.immediately)
				{
					this._UpdateResultList();
					this.upgradeAgain();
				}
			}
			else
			{
				if (this.upgradeScore > 0)
				{
					this._UpdateEquipList();
				}
				this._PlayEffect(this.upgradeScore);
				this._DisplayYjUpgrade();
			}
		}

		// Token: 0x0600DAF4 RID: 56052 RVA: 0x00371CF4 File Offset: 0x003700F4
		protected override void _bindExUI()
		{
			this.mEquipItem = this.mBind.GetCom<ComUIListElementScript>("equipItem");
			this.mCanRedeemCount = this.mBind.GetCom<Text>("canRedeemCount");
			this.mClose = this.mBind.GetCom<Button>("close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			this.mEquipUIList = this.mBind.GetCom<ComUIListScript>("equipUIList");
			this.mVictoryEffect = this.mBind.GetGameObject("victoryEffect");
			this.mDefeatEffect = this.mBind.GetGameObject("defeatEffect");
			this.mTips = this.mBind.GetGameObject("tips");
			this.mYjUpgradeRoot = this.mBind.GetGameObject("YjUpgradeRoot");
			this.mYjReturn = this.mBind.GetCom<Button>("YjReturn");
			this.mYjReturn.onClick.AddListener(new UnityAction(this._onYjReturnButtonClick));
			this.mUpgradeResult = this.mBind.GetGameObject("upgradeResult");
			this.mBeginCount = this.mBind.GetCom<Text>("beginCount");
			this.mEndCount = this.mBind.GetCom<Text>("endCount");
			this.mConsumeImage = this.mBind.GetCom<Image>("consumeImage");
			this.mConsumeCount = this.mBind.GetCom<Text>("consumeCount");
			this.mBtOk = this.mBind.GetCom<Button>("btOk");
			this.mBtOk.onClick.AddListener(new UnityAction(this._onBtOkButtonClick));
			this.mImmediate = this.mBind.GetCom<Button>("immediate");
			this.mImmediate.onClick.AddListener(new UnityAction(this._onImmediatelyButtonClick));
			this.mContinueButton = this.mBind.GetCom<Button>("continueButton");
			this.mContinueButton.onClick.AddListener(new UnityAction(this._onContinueButtonClick));
			this.mTitleText = this.mBind.GetCom<Text>("titleText");
			this.mResultItem = this.mBind.GetCom<ComUIListElementScript>("resultItem");
			this.mResultUIList = this.mBind.GetCom<ComUIListScript>("resultUIList");
			this.mContinueUIGray = this.mBind.GetCom<UIGray>("continueUIGray");
			this.mContinueButtonText = this.mBind.GetCom<Text>("ContinueButtonText");
			this.mFinishUIGray = this.mBind.GetCom<UIGray>("finishUIGray");
			this.mYjUpgradeEffect = this.mBind.GetGameObject("YjUpgradeEffect");
		}

		// Token: 0x0600DAF5 RID: 56053 RVA: 0x00371FA0 File Offset: 0x003703A0
		protected override void _unbindExUI()
		{
			this.mEquipItem = null;
			this.mCanRedeemCount = null;
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
			this.mEquipUIList = null;
			this.mVictoryEffect = null;
			this.mDefeatEffect = null;
			this.mTips = null;
			this.mTips = null;
			this.mYjUpgradeRoot = null;
			this.mYjReturn.onClick.RemoveListener(new UnityAction(this._onYjReturnButtonClick));
			this.mYjReturn = null;
			this.mImmediate.onClick.RemoveListener(new UnityAction(this._onImmediatelyButtonClick));
			this.mImmediate = null;
			this.mUpgradeResult = null;
			this.mBeginCount = null;
			this.mEndCount = null;
			this.mConsumeImage = null;
			this.mConsumeCount = null;
			this.mBtOk.onClick.RemoveListener(new UnityAction(this._onBtOkButtonClick));
			this.mBtOk = null;
			this.mContinueButton.onClick.RemoveListener(new UnityAction(this._onContinueButtonClick));
			this.mContinueButton = null;
			this.mTitleText = null;
			this.mResultItem = null;
			this.mResultUIList = null;
			this.mContinueUIGray = null;
			this.mContinueButtonText = null;
			this.mFinishUIGray = null;
			this.mYjUpgradeEffect = null;
		}

		// Token: 0x0600DAF6 RID: 56054 RVA: 0x003720E8 File Offset: 0x003704E8
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<EquipUpgradeFrame>(this, false);
		}

		// Token: 0x0600DAF7 RID: 56055 RVA: 0x003720F7 File Offset: 0x003704F7
		private void _onYjReturnButtonClick()
		{
			this.curUpgradeType = UpgradeType.returned;
			this._DisplayYjUpgrade();
		}

		// Token: 0x0600DAF8 RID: 56056 RVA: 0x00372108 File Offset: 0x00370508
		private void _onBtOkButtonClick()
		{
			this.mYjUpgradeRoot.CustomActive(false);
			this.mUpgradeResult.CustomActive(false);
			this.mYjReturn.CustomActive(false);
			this.beginScore = 0;
			this.endScore = 0;
			this.beginGold = 0;
			this.endGold = 0;
			this.totalCount = 0;
			this.upgradeResultList.Clear();
			this.mConsumeCount.text = string.Empty;
			this.curUpgradeType = UpgradeType.stop;
			DataManager<EquipRecoveryDataManager>.GetInstance().isUpgradeing = false;
		}

		// Token: 0x0600DAF9 RID: 56057 RVA: 0x0037218C File Offset: 0x0037058C
		private void _onImmediatelyButtonClick()
		{
			this.curUpgradeType = UpgradeType.immediately;
			this.mYjReturn.CustomActive(false);
			this.mImmediate.CustomActive(false);
			this.mUpgradeResult.CustomActive(true);
			this.mContinueButton.CustomActive(false);
			this.mFinishUIGray.enabled = true;
			this.mBtOk.enabled = false;
			this._UpdateResultList();
		}

		// Token: 0x0600DAFA RID: 56058 RVA: 0x003721EE File Offset: 0x003705EE
		private void _onContinueButtonClick()
		{
			this.upgradeResultList.Clear();
			DataManager<EquipRecoveryDataManager>.GetInstance()._UpgradeEquip(this.upgradingGuid);
			this.totalCount = 1;
			this.mUpgradeResult.CustomActive(false);
		}

		// Token: 0x040080BF RID: 32959
		private int canUpgradeScore;

		// Token: 0x040080C0 RID: 32960
		private UpgradeType curUpgradeType;

		// Token: 0x040080C1 RID: 32961
		private ulong upgradingGuid;

		// Token: 0x040080C2 RID: 32962
		private int beginScore;

		// Token: 0x040080C3 RID: 32963
		private int endScore;

		// Token: 0x040080C4 RID: 32964
		private int beginGold;

		// Token: 0x040080C5 RID: 32965
		private int endGold;

		// Token: 0x040080C6 RID: 32966
		private int totalCount;

		// Token: 0x040080C7 RID: 32967
		private List<int> upgradeResultList = new List<int>();

		// Token: 0x040080C8 RID: 32968
		private int consume;

		// Token: 0x040080C9 RID: 32969
		private int upgradeScore = -1;

		// Token: 0x040080CA RID: 32970
		private List<ulong> upgradeEquipList = new List<ulong>();

		// Token: 0x040080CB RID: 32971
		private ComUIListElementScript mEquipItem;

		// Token: 0x040080CC RID: 32972
		private Text mCanRedeemCount;

		// Token: 0x040080CD RID: 32973
		private Button mClose;

		// Token: 0x040080CE RID: 32974
		private ComUIListScript mEquipUIList;

		// Token: 0x040080CF RID: 32975
		private GameObject mVictoryEffect;

		// Token: 0x040080D0 RID: 32976
		private GameObject mDefeatEffect;

		// Token: 0x040080D1 RID: 32977
		private GameObject mTips;

		// Token: 0x040080D2 RID: 32978
		private GameObject mYjUpgradeRoot;

		// Token: 0x040080D3 RID: 32979
		private Button mYjReturn;

		// Token: 0x040080D4 RID: 32980
		private GameObject mUpgradeResult;

		// Token: 0x040080D5 RID: 32981
		private Text mBeginCount;

		// Token: 0x040080D6 RID: 32982
		private Text mEndCount;

		// Token: 0x040080D7 RID: 32983
		private Image mConsumeImage;

		// Token: 0x040080D8 RID: 32984
		private Text mConsumeCount;

		// Token: 0x040080D9 RID: 32985
		private Button mBtOk;

		// Token: 0x040080DA RID: 32986
		private Button mImmediate;

		// Token: 0x040080DB RID: 32987
		private Button mContinueButton;

		// Token: 0x040080DC RID: 32988
		private Text mTitleText;

		// Token: 0x040080DD RID: 32989
		private ComUIListElementScript mResultItem;

		// Token: 0x040080DE RID: 32990
		private ComUIListScript mResultUIList;

		// Token: 0x040080DF RID: 32991
		private UIGray mContinueUIGray;

		// Token: 0x040080E0 RID: 32992
		private Text mContinueButtonText;

		// Token: 0x040080E1 RID: 32993
		private UIGray mFinishUIGray;

		// Token: 0x040080E2 RID: 32994
		private GameObject mYjUpgradeEffect;
	}
}
