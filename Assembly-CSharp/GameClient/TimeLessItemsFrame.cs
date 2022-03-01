using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001710 RID: 5904
	internal class TimeLessItemsFrame : ClientFrame
	{
		// Token: 0x0600E81B RID: 59419 RVA: 0x003D4E3F File Offset: 0x003D323F
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Package/TimeLessItems";
		}

		// Token: 0x0600E81C RID: 59420 RVA: 0x003D4E48 File Offset: 0x003D3248
		protected override void _OnOpenFrame()
		{
			this.data = (this.userData as TimeLessItemsFrameData);
			this.m_comItems.Initialize();
			this.m_comItems.onBindItem = delegate(GameObject var)
			{
				GameObject goParent = Utility.FindGameObject(var.gameObject, "Item", true);
				return base.CreateComItem(goParent);
			};
			this.m_comItems.onItemVisiable = delegate(ComUIListElementScript var)
			{
				List<ItemData> timeLessItems = DataManager<ItemDataManager>.GetInstance().GetTimeLessItems();
				if (var.m_index >= 0 && var.m_index < timeLessItems.Count)
				{
					ItemData itemData = timeLessItems[var.m_index];
					ComItem comItem = var.gameObjectBindScript as ComItem;
					comItem.Setup(itemData, delegate(GameObject var1, ItemData var2)
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
					});
					Text componetInChild = Utility.GetComponetInChild<Text>(var.gameObject, "Name");
					componetInChild.text = itemData.GetColorName(string.Empty, false);
					Text componetInChild2 = Utility.GetComponetInChild<Text>(var.gameObject, "TimeRemain");
					componetInChild2.text = this._GetTimeLeftDesc(itemData);
					Button componetInChild3 = Utility.GetComponetInChild<Button>(var.gameObject, "Func");
					Text componetInChild4 = Utility.GetComponetInChild<Text>(var.gameObject, "Func/Text");
					string text;
					UnityAction unityAction;
					if (this._GetSuitableFunc(itemData, out text, out unityAction))
					{
						componetInChild3.onClick.RemoveAllListeners();
						componetInChild3.onClick.AddListener(unityAction);
						componetInChild4.text = text;
						componetInChild3.gameObject.SetActive(true);
					}
					else
					{
						componetInChild3.gameObject.SetActive(false);
					}
				}
			};
			this.m_comItems.SetElementAmount(DataManager<ItemDataManager>.GetInstance().GetTimeLessItems().Count);
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TimeLessItemsChanged, new ClientEventSystem.UIEventHandler(this._OnTimeLessItemsChanged));
		}

		// Token: 0x0600E81D RID: 59421 RVA: 0x003D4ED4 File Offset: 0x003D32D4
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TimeLessItemsChanged, new ClientEventSystem.UIEventHandler(this._OnTimeLessItemsChanged));
			if (this.data != null)
			{
				if (this.data.onCloseFrame != null)
				{
					this.data.onCloseFrame.Invoke();
					this.data.onCloseFrame = null;
				}
				this.data = null;
			}
		}

		// Token: 0x0600E81E RID: 59422 RVA: 0x003D4F3C File Offset: 0x003D333C
		private string _GetTimeLeftDesc(ItemData a_itemData)
		{
			int num;
			bool flag;
			a_itemData.GetTimeLeft(out num, out flag);
			if (!flag)
			{
				return string.Empty;
			}
			if (num > 0)
			{
				int num2 = 0;
				int num3 = 0;
				int num4 = num % 60;
				int num5 = num / 60;
				if (num5 > 0)
				{
					num2 = num5 % 60;
					num3 = num5 / 60;
				}
				string text = string.Empty;
				if (num3 > 0)
				{
					text += string.Format("{0}小时", num3);
				}
				if (num2 > 0)
				{
					text += string.Format("{0}分", num2);
				}
				if (num4 > 0)
				{
					text += string.Format("{0}秒", num4);
				}
				return TR.Value("tip_color_bad", TR.Value("item_time_left", text));
			}
			return TR.Value("tip_color_bad", TR.Value("item_time_left_none"));
		}

		// Token: 0x0600E81F RID: 59423 RVA: 0x003D5024 File Offset: 0x003D3424
		private bool _GetSuitableFunc(ItemData a_itemData, out string a_strName, out UnityAction a_func)
		{
			if (a_itemData.CanRenewal())
			{
				a_strName = TR.Value("tip_renewal");
				a_func = delegate()
				{
					this._OnRenewalItem(a_itemData);
				};
				return true;
			}
			int num;
			bool flag;
			a_itemData.GetTimeLeft(out num, out flag);
			if (flag && num <= 0)
			{
				a_strName = string.Empty;
				a_func = null;
				return false;
			}
			if (a_itemData.UseType == ItemTable.eCanUse.UseOne || a_itemData.UseType == ItemTable.eCanUse.UseTotal)
			{
				if (a_itemData.Type != ItemTable.eType.FUCKTITTLE && a_itemData.Type != ItemTable.eType.EQUIP && a_itemData.Type != ItemTable.eType.FASHION)
				{
					a_strName = TR.Value("tip_use");
					a_func = delegate()
					{
						this._TryOnUseItem(a_itemData);
					};
					return true;
				}
			}
			else
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(a_itemData.TableID, string.Empty, string.Empty);
				if (tableItem != null && !string.IsNullOrEmpty(tableItem.LinkInfo))
				{
					a_strName = TR.Value("tip_itemLink");
					a_func = delegate()
					{
						this._OnItemLink(a_itemData);
					};
					return true;
				}
				if (a_itemData.Type == ItemTable.eType.EXPENDABLE && a_itemData.SubType == 25 && Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Forge))
				{
					a_strName = TR.Value("tip_forge");
					a_func = delegate()
					{
						this._OnForgeItem(a_itemData);
					};
					return true;
				}
			}
			a_strName = string.Empty;
			a_func = null;
			return false;
		}

		// Token: 0x0600E820 RID: 59424 RVA: 0x003D51B6 File Offset: 0x003D35B6
		private void _OnRenewalItem(ItemData item)
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<RenewalItemFrame>(FrameLayer.Middle, item, string.Empty);
		}

		// Token: 0x0600E821 RID: 59425 RVA: 0x003D51CC File Offset: 0x003D35CC
		private void _OnDeSealClicked(ItemData item)
		{
			if (item != null && item.Packing)
			{
				if (item.CanEquip())
				{
					SystemNotifyManager.SystemNotify(2006, delegate()
					{
						DataManager<ItemDataManager>.GetInstance().UseItem(item, false, 0, 0);
						MonoSingleton<AudioManager>.instance.PlaySound(102);
					}, null, new object[]
					{
						item.GetColorName(string.Empty, false)
					});
				}
				else
				{
					SystemNotifyManager.SysNotifyMsgBoxOK(TR.Value("equip_deseal_notify_cannot", item.GetColorName(string.Empty, false)), null, string.Empty, false);
				}
			}
		}

		// Token: 0x0600E822 RID: 59426 RVA: 0x003D5270 File Offset: 0x003D3670
		private void _TryOnUseItem(ItemData item)
		{
			if (item.Type == ItemTable.eType.EQUIP)
			{
				int masterPriority = DataManager<EquipMasterDataManager>.GetInstance().GetMasterPriority(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)item.Quality, (int)item.EquipWearSlotType, (int)item.ThirdType);
				if (masterPriority == 2)
				{
					SystemNotifyManager.SystemNotifyOkCancel(7019, delegate
					{
						this._OnUseItem(item);
					}, null, FrameLayer.High, false);
					return;
				}
			}
			this._OnUseItem(item);
		}

		// Token: 0x0600E823 RID: 59427 RVA: 0x003D5308 File Offset: 0x003D3708
		private void _OnUseItem(ItemData item)
		{
			if (item != null)
			{
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
						else
						{
							DataManager<ItemDataManager>.GetInstance().UseItem(item, false, 0, 0);
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
				else
				{
					DataManager<ItemDataManager>.GetInstance().UseItem(item, false, 0, 0);
					if (item.PackageType == EPackageType.Equip || item.PackageType == EPackageType.Fashion)
					{
						MonoSingleton<AudioManager>.instance.PlaySound(102);
					}
				}
			}
		}

		// Token: 0x0600E824 RID: 59428 RVA: 0x003D5420 File Offset: 0x003D3820
		private void _OnItemLink(ItemData item)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
			if (tableItem != null && !string.IsNullOrEmpty(tableItem.LinkInfo))
			{
				FunctionUnLock tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(tableItem.FunctionID, string.Empty, string.Empty);
				if (tableItem2 != null && tableItem2.FinishLevel > (int)DataManager<PlayerBaseData>.GetInstance().Level)
				{
					SystemNotifyManager.SystemNotify(tableItem2.CommDescID, string.Empty);
					return;
				}
				DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(tableItem.LinkInfo, null, false);
			}
		}

		// Token: 0x0600E825 RID: 59429 RVA: 0x003D54B8 File Offset: 0x003D38B8
		private void _OnForgeItem(ItemData a_item)
		{
			if (a_item != null)
			{
				SmithShopNewLinkData smithShopNewLinkData = new SmithShopNewLinkData();
				smithShopNewLinkData.itemData = a_item;
				if (a_item.SubType == 25)
				{
					smithShopNewLinkData.iDefaultFirstTabId = 2;
					smithShopNewLinkData.iDefaultSecondTabId = 0;
				}
				else
				{
					smithShopNewLinkData.iDefaultFirstTabId = 0;
				}
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<SmithShopNewFrame>(null, true);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<SmithShopNewFrame>(FrameLayer.Middle, smithShopNewLinkData, string.Empty);
			}
		}

		// Token: 0x0600E826 RID: 59430 RVA: 0x003D551D File Offset: 0x003D391D
		private void _OnTimeLessItemsChanged(UIEvent a_event)
		{
			this.m_comItems.SetElementAmount(DataManager<ItemDataManager>.GetInstance().GetTimeLessItems().Count);
		}

		// Token: 0x0600E827 RID: 59431 RVA: 0x003D5539 File Offset: 0x003D3939
		[UIEventHandle("Close")]
		private void _OnCloseClicked()
		{
			this.frameMgr.CloseFrame<TimeLessItemsFrame>(this, false);
		}

		// Token: 0x04008CBE RID: 36030
		[UIControl("Items", null, 0)]
		private ComUIListScript m_comItems;

		// Token: 0x04008CBF RID: 36031
		private TimeLessItemsFrameData data;
	}
}
