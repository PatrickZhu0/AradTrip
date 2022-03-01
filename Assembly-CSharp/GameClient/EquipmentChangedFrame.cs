using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020016B6 RID: 5814
	public class EquipmentChangedFrame : ClientFrame
	{
		// Token: 0x0600E3EF RID: 58351 RVA: 0x003AE2D6 File Offset: 0x003AC6D6
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/BetterEquipHint/EquipmentChangedFrame";
		}

		// Token: 0x0600E3F0 RID: 58352 RVA: 0x003AE2E0 File Offset: 0x003AC6E0
		protected sealed override void _OnOpenFrame()
		{
			this.BindUIEvent();
			this.comItem = null;
			this.goItemParent = Utility.FindChild(this.frame, "back/ItemObject");
			this.m_currentGuid = 0UL;
			this.m_kName = Utility.FindComponent<Text>(this.frame, "back/BtnWearImmediately/text", true);
			this.m_kHint = Utility.FindComponent<Text>(this.frame, "back/front/Name", true);
			this.m_kComEffect = Utility.FindComponent<ComEffect>(this.frame, "back/EffectParent", true);
			this.frame.gameObject.transform.SetAsFirstSibling();
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onNeedPopEquipsChanged = (ItemDataManager.OnNeedPopEquipsChanged)Delegate.Combine(instance.onNeedPopEquipsChanged, new ItemDataManager.OnNeedPopEquipsChanged(this.OnNeedPopEquipsChanged));
			bool bVisible = this.IsFrameNeedShow();
			this._UpdateFrameVisible(bVisible);
			this.m_bLocked = false;
			this.OnNeedPopEquipsChanged(DataManager<ItemDataManager>.GetInstance().NeedEquiptmentsID);
		}

		// Token: 0x0600E3F1 RID: 58353 RVA: 0x003AE3C0 File Offset: 0x003AC7C0
		protected void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.NewFuncFrameOpen, new ClientEventSystem.UIEventHandler(this.OnNewFuncFrameOpen));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.NewFuncFrameClose, new ClientEventSystem.UIEventHandler(this.OnNewFuncFrameClose));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CurGuideStart, new ClientEventSystem.UIEventHandler(this.OnNewbieGuideStart));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CurGuideFinish, new ClientEventSystem.UIEventHandler(this.OnNewbieGuideFinish));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TipsAniStart, new ClientEventSystem.UIEventHandler(this.OnTipsAniStart));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TipsAniEnd, new ClientEventSystem.UIEventHandler(this.OnTipsAniEnd));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.EquipSubmitSuccess, new ClientEventSystem.UIEventHandler(this.OnEquipSubmitSuccess));
		}

		// Token: 0x0600E3F2 RID: 58354 RVA: 0x003AE48C File Offset: 0x003AC88C
		protected void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.NewFuncFrameOpen, new ClientEventSystem.UIEventHandler(this.OnNewFuncFrameOpen));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.NewFuncFrameClose, new ClientEventSystem.UIEventHandler(this.OnNewFuncFrameClose));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CurGuideStart, new ClientEventSystem.UIEventHandler(this.OnNewbieGuideStart));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CurGuideFinish, new ClientEventSystem.UIEventHandler(this.OnNewbieGuideFinish));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TipsAniStart, new ClientEventSystem.UIEventHandler(this.OnTipsAniStart));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TipsAniEnd, new ClientEventSystem.UIEventHandler(this.OnTipsAniEnd));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.EquipSubmitSuccess, new ClientEventSystem.UIEventHandler(this.OnEquipSubmitSuccess));
		}

		// Token: 0x0600E3F3 RID: 58355 RVA: 0x003AE556 File Offset: 0x003AC956
		private void OnNewFuncFrameOpen(UIEvent uiEvent)
		{
			this._UpdateFrameVisible(false);
		}

		// Token: 0x0600E3F4 RID: 58356 RVA: 0x003AE560 File Offset: 0x003AC960
		private void OnNewFuncFrameClose(UIEvent uiEvent)
		{
			if (DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList.Count > 0)
			{
				this._UpdateFrameVisible(false);
			}
			else if (Singleton<NewbieGuideManager>.GetInstance().IsGuiding())
			{
				this._UpdateFrameVisible(false);
			}
			else
			{
				this._UpdateFrameVisible(true);
			}
		}

		// Token: 0x0600E3F5 RID: 58357 RVA: 0x003AE5B0 File Offset: 0x003AC9B0
		private void OnNewbieGuideStart(UIEvent uiEvent)
		{
			if ((NewbieGuideTable.eNewbieGuideTask)uiEvent.Param1 == NewbieGuideTable.eNewbieGuideTask.QuickEquipGuide)
			{
				this._UpdateFrameVisible(true);
			}
			else
			{
				this._UpdateFrameVisible(false);
			}
		}

		// Token: 0x0600E3F6 RID: 58358 RVA: 0x003AE5D7 File Offset: 0x003AC9D7
		private void OnNewbieGuideFinish(UIEvent uiEvent)
		{
			this._UpdateFrameVisible(true);
		}

		// Token: 0x0600E3F7 RID: 58359 RVA: 0x003AE5E0 File Offset: 0x003AC9E0
		private void OnTipsAniStart(UIEvent uiEvent)
		{
			this._UpdateFrameVisible(false);
		}

		// Token: 0x0600E3F8 RID: 58360 RVA: 0x003AE5E9 File Offset: 0x003AC9E9
		private void OnTipsAniEnd(UIEvent uiEvent)
		{
			this._UpdateFrameVisible(true);
		}

		// Token: 0x0600E3F9 RID: 58361 RVA: 0x003AE5F4 File Offset: 0x003AC9F4
		private void OnEquipSubmitSuccess(UIEvent uiEvent)
		{
			EqRecScoreItem[] array = (EqRecScoreItem[])uiEvent.Param2;
			for (int i = 0; i < array.Length; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(array[i].uid);
				if (item != null)
				{
					DataManager<ItemDataManager>.GetInstance().NeedEquiptmentsID.Remove(array[i].uid);
					this.OnNeedPopEquipsChanged(DataManager<ItemDataManager>.GetInstance().NeedEquiptmentsID);
				}
			}
		}

		// Token: 0x0600E3FA RID: 58362 RVA: 0x003AE664 File Offset: 0x003ACA64
		private bool IsFrameNeedShow()
		{
			return DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList.Count <= 0 && !Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<FunctionUnlockFrame>(null) && (!Singleton<NewbieGuideManager>.GetInstance().IsGuiding() || Singleton<NewbieGuideManager>.GetInstance().IsGuidingTask(NewbieGuideTable.eNewbieGuideTask.QuickEquipGuide)) && !ClientSystemTownFrame.IsShowSkillTips && !ClientSystemTownFrame.IsShowEquipHandBookTips && !ClientSystemTownFrame.IsShowGuildTips;
		}

		// Token: 0x0600E3FB RID: 58363 RVA: 0x003AE6DC File Offset: 0x003ACADC
		private void _UpdateFrameVisible(bool bVisible)
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				base.SetVisible(false);
				return;
			}
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				base.SetVisible(false);
				return;
			}
			if (tableItem.SceneType != CitySceneTable.eSceneType.NORMAL && tableItem.SceneType != CitySceneTable.eSceneType.SINGLE)
			{
				base.SetVisible(false);
				return;
			}
			if (ClientSystemTownFrame.IsShowSkillTips || ClientSystemTownFrame.IsShowEquipHandBookTips || ClientSystemTownFrame.IsShowGuildTips)
			{
				base.SetVisible(false);
				return;
			}
			base.SetVisible(bVisible);
		}

		// Token: 0x0600E3FC RID: 58364 RVA: 0x003AE780 File Offset: 0x003ACB80
		private void OnNeedPopEquipsChanged(List<ulong> equipts)
		{
			if (this.OnEquipment(this.m_currentGuid))
			{
				return;
			}
			for (int i = 0; i < equipts.Count; i++)
			{
				if (this.m_currentGuid != equipts[i] && this.OnEquipment(equipts[i]))
				{
					return;
				}
			}
			this.frameMgr.CloseFrame<EquipmentChangedFrame>(this, false);
		}

		// Token: 0x0600E3FD RID: 58365 RVA: 0x003AE7E8 File Offset: 0x003ACBE8
		private void DisplayPrompt()
		{
			List<ulong> needEquiptmentsID = DataManager<ItemDataManager>.GetInstance().NeedEquiptmentsID;
			while (needEquiptmentsID.Count > 0)
			{
				ulong num = DataManager<ItemDataManager>.GetInstance().NeedEquiptmentsID[0];
				if (this.OnEquipment(num))
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(num);
					if (item != null && item.Count <= 1)
					{
						needEquiptmentsID.Remove(num);
					}
					break;
				}
				needEquiptmentsID.Remove(num);
			}
			if (this.comItem == null || this.comItem.ItemData == null)
			{
				this.frameMgr.CloseFrame<EquipmentChangedFrame>(this, false);
			}
		}

		// Token: 0x0600E3FE RID: 58366 RVA: 0x003AE890 File Offset: 0x003ACC90
		private bool OnEquipment(ulong GUID)
		{
			this.m_currentGuid = GUID;
			if (!DataManager<ItemDataManager>.GetInstance().NeedEquiptmentsID.Contains(GUID))
			{
				this.m_currentGuid = 0UL;
				return false;
			}
			if (this.comItem == null)
			{
				this.comItem = base.CreateComItem(this.goItemParent);
			}
			if (this.comItem != null)
			{
				ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(this.m_currentGuid);
				this.comItem.Setup(item2, delegate(GameObject obj, ItemData item)
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
				});
				if (item2 != null)
				{
					if ((DataManager<PlayerBaseData>.GetInstance().Level < 10 && item2.Type == ItemTable.eType.EQUIP) || (DataManager<PlayerBaseData>.GetInstance().Level < 10 && item2.SubType == 29) || (int)DataManager<PlayerBaseData>.GetInstance().Level < item2.LevelLimit || (int)DataManager<PlayerBaseData>.GetInstance().Level > item2.MaxLevelLimit)
					{
						this.OnClickClose();
						return true;
					}
					this.m_kHint.text = item2.GetColorName(string.Empty, false);
					if (item2.SubType == 41)
					{
						this.m_kName.text = TR.Value("equipment_use");
						ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item2.TableID, string.Empty, string.Empty);
						if (tableItem != null && tableItem.CanUse == ItemTable.eCanUse.UseTotal)
						{
							this.m_kName.text = TR.Value("equipment_onekey_use");
						}
					}
					else if (item2.SubType == 29)
					{
						this.m_kName.text = TR.Value("equipment_use");
						ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item2.TableID, string.Empty, string.Empty);
						if (tableItem2 != null && tableItem2.EPrompt == ItemTable.eEPrompt.EPT_NEW_EQUIP && tableItem2.CanUse == ItemTable.eCanUse.UseTotal && item2.Count > 1)
						{
							this.m_kName.text = TR.Value("equipment_onekey_use");
						}
					}
					else if (item2.Type == ItemTable.eType.EQUIP)
					{
						this.m_kName.text = TR.Value("equipment_dress");
					}
					else
					{
						this.m_kName.text = TR.Value("equipment_use");
					}
					return true;
				}
			}
			this.m_currentGuid = 0UL;
			return false;
		}

		// Token: 0x0600E3FF RID: 58367 RVA: 0x003AEAEC File Offset: 0x003ACEEC
		protected sealed override void _OnCloseFrame()
		{
			this.UnBindUIEvent();
			this.comItem = null;
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onNeedPopEquipsChanged = (ItemDataManager.OnNeedPopEquipsChanged)Delegate.Remove(instance.onNeedPopEquipsChanged, new ItemDataManager.OnNeedPopEquipsChanged(this.OnNeedPopEquipsChanged));
			InvokeMethod.RemoveInvokeCall(new UnityAction(this._UnLock));
		}

		// Token: 0x0600E400 RID: 58368 RVA: 0x003AEB40 File Offset: 0x003ACF40
		[UIEventHandle("back/BtnClose")]
		private void OnClickClose()
		{
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(this.m_currentGuid);
			if (item != null)
			{
				DataManager<ItemDataManager>.GetInstance().NeedEquiptmentsID.Remove(this.m_currentGuid);
			}
			this.OnNeedPopEquipsChanged(DataManager<ItemDataManager>.GetInstance().NeedEquiptmentsID);
		}

		// Token: 0x0600E401 RID: 58369 RVA: 0x003AEB8C File Offset: 0x003ACF8C
		[UIEventHandle("back/BtnWearImmediately")]
		private void OnWearImmediately()
		{
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(this.m_currentGuid);
			if (item.EquipType == EEquipType.ET_BREATH)
			{
				SystemNotifyManager.SysNotifyTextAnimation("带有虚空物质的装备无法穿戴", CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (item != null && item.PackageType != EPackageType.WearEquip && !this.m_bLocked)
			{
				this.m_bLocked = true;
				if (item.PackID > 0)
				{
					GiftPackTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GiftPackTable>(item.PackID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						if (tableItem.FilterType == GiftPackTable.eFilterType.Custom || tableItem.FilterType == GiftPackTable.eFilterType.CustomWithJob)
						{
							if (tableItem.FilterCount > 0)
							{
								Singleton<ClientSystemManager>.GetInstance().OpenFrame<SelectItemFrame>(FrameLayer.Middle, item, string.Empty);
							}
							else
							{
								Logger.LogErrorFormat("礼包{0}的FilterCount小于等于0", new object[]
								{
									item.PackID
								});
							}
						}
						else if (item.SubType == 55)
						{
							List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Consumable);
							if (itemsByPackageType != null)
							{
								int num = 0;
								for (int i = 0; i < itemsByPackageType.Count; i++)
								{
									ItemData item3 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
									if (item3 != null)
									{
										if (item3.SubType == 56)
										{
											num = Mathf.FloorToInt((float)(item3.Count / 4));
										}
									}
								}
								if (num >= item.Count)
								{
									DataManager<MagicBoxDataManager>.GetInstance().AnsyOpenMagBox(new UnityAction(this.OpenMagicBoxFrame), item.GUID, item.Count);
								}
								else if (num < item.Count && num != 0)
								{
									DataManager<MagicBoxDataManager>.GetInstance().AnsyOpenMagBox(new UnityAction(this.OpenMagicBoxFrame), item.GUID, num);
								}
								else
								{
									ItemComeLink.OnLink(800002002, 0, true, null, false, false, false, null, string.Empty);
								}
							}
							DataManager<ItemTipManager>.GetInstance().CloseAll();
						}
						else if (item.SubType == 56)
						{
							List<ulong> itemsByPackageType2 = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Consumable);
							if (itemsByPackageType2 != null)
							{
								int num2 = 0;
								for (int j = 0; j < itemsByPackageType2.Count; j++)
								{
									ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType2[j]);
									if (item2 != null)
									{
										if (item2.SubType == 55)
										{
											num2 = item2.Count;
										}
									}
								}
								if (num2 > 0)
								{
									int num3 = Mathf.FloorToInt((float)(item.Count / 4));
									if (num3 >= num2)
									{
										DataManager<MagicBoxDataManager>.GetInstance().AnsyOpenMagBox(new UnityAction(this.OpenMagicBoxFrame), item.GUID, num2);
									}
									else if (num3 < num2 && num3 != 0)
									{
										DataManager<MagicBoxDataManager>.GetInstance().AnsyOpenMagBox(new UnityAction(this.OpenMagicBoxFrame), item.GUID, num3);
									}
									else
									{
										ItemComeLink.OnLink(800002002, 0, true, null, false, false, false, null, string.Empty);
									}
								}
								else
								{
									ItemComeLink.OnLink(800002001, 0, true, null, false, false, false, null, string.Empty);
								}
							}
							DataManager<ItemTipManager>.GetInstance().CloseAll();
						}
						else if (item.SubType == 29)
						{
							DataManager<ItemDataManager>.GetInstance().UseItem(item, true, 0, 0);
							DataManager<ItemTipManager>.GetInstance().CloseAll();
						}
						else
						{
							DataManager<ItemDataManager>.GetInstance().UseItem(item, false, 0, 0);
							if (item.Count <= 1 || item.CD > 0)
							{
								DataManager<ItemTipManager>.GetInstance().CloseAll();
							}
						}
					}
					else
					{
						Logger.LogErrorFormat("道具{0}的礼包ID{1}不存在", new object[]
						{
							item.TableID,
							item.PackID
						});
					}
				}
				else if (item.Packing)
				{
					SystemNotifyManager.SystemNotify(2006, delegate()
					{
						this._OnUseItem(item);
					}, null, new object[]
					{
						item.GetColorName(string.Empty, false)
					});
				}
				else
				{
					this._OnUseItem(item);
				}
				InvokeMethod.Invoke(0.5f, new UnityAction(this._UnLock));
			}
		}

		// Token: 0x0600E402 RID: 58370 RVA: 0x003AF034 File Offset: 0x003AD434
		private void OpenMagicBoxFrame()
		{
			MagicBoxFrame.MagicBoxResultFrameData magicBoxResultFrameData = new MagicBoxFrame.MagicBoxResultFrameData();
			magicBoxResultFrameData.itemRewards = DataManager<MagicBoxDataManager>.GetInstance().itemRrewardList;
			magicBoxResultFrameData.ItemDoubleRewards = DataManager<MagicBoxDataManager>.GetInstance().itemDoubleRewardList;
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MagicBoxFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<MagicBoxFrame>(null, false);
			}
			ClientFrame.OpenTargetFrame<MagicBoxFrame>(FrameLayer.Middle, magicBoxResultFrameData);
		}

		// Token: 0x0600E403 RID: 58371 RVA: 0x003AF08B File Offset: 0x003AD48B
		private void _UnLock()
		{
			this.m_bLocked = false;
		}

		// Token: 0x0600E404 RID: 58372 RVA: 0x003AF094 File Offset: 0x003AD494
		private void _OnUseItem(ItemData item)
		{
			this.m_kComEffect.Play("UsedEffect");
			InvokeMethod.Invoke(0.4f, delegate()
			{
				if (item != null)
				{
					if (item.SubType == 29)
					{
						DataManager<ItemDataManager>.GetInstance().UseItem(item, true, 0, 0);
					}
					else if (item.SubType == 41)
					{
						ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
						if (tableItem != null)
						{
							if (tableItem.CanUse == ItemTable.eCanUse.UseTotal)
							{
								DataManager<ItemDataManager>.GetInstance().UseItem(item, true, 0, 0);
							}
							else
							{
								DataManager<ItemDataManager>.GetInstance().UseItem(item, false, 0, 0);
							}
						}
					}
					else if (item.SubType == 44 && item.Type == ItemTable.eType.EXPENDABLE)
					{
						DataManager<ItemDataManager>.GetInstance().UseItem(item, false, 0, 0);
						DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneUseItemRet>(delegate(SceneUseItemRet msgRet)
						{
							if (msgRet.code != 0U)
							{
								SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
							}
							else
							{
								if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<OpenPetEggFrame>(null))
								{
									Singleton<ClientSystemManager>.GetInstance().CloseFrame<OpenPetEggFrame>(null, false);
								}
								Singleton<ClientSystemManager>.GetInstance().OpenFrame<OpenPetEggFrame>(FrameLayer.Middle, item, string.Empty);
							}
						}, true, 15f, null);
					}
					else
					{
						DataManager<ItemDataManager>.GetInstance().UseItem(item, false, 0, 0);
					}
				}
			});
		}

		// Token: 0x040088EC RID: 35052
		private ComItem comItem;

		// Token: 0x040088ED RID: 35053
		private GameObject goItemParent;

		// Token: 0x040088EE RID: 35054
		private ulong m_currentGuid;

		// Token: 0x040088EF RID: 35055
		private Text m_kName;

		// Token: 0x040088F0 RID: 35056
		private Text m_kHint;

		// Token: 0x040088F1 RID: 35057
		private ComEffect m_kComEffect;

		// Token: 0x040088F2 RID: 35058
		private bool m_bLocked;
	}
}
