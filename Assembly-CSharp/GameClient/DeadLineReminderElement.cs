using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015AC RID: 5548
	public class DeadLineReminderElement : MonoBehaviour
	{
		// Token: 0x0600D8FA RID: 55546 RVA: 0x003653E8 File Offset: 0x003637E8
		private void Awake()
		{
			if (this.mGoBtn != null)
			{
				this.mGoBtn.onClick.RemoveAllListeners();
				this.mGoBtn.onClick.AddListener(new UnityAction(this.OnGoBtnClick));
			}
			if (this.mRenewalBtn != null)
			{
				this.mRenewalBtn.onClick.RemoveAllListeners();
				this.mRenewalBtn.onClick.AddListener(delegate()
				{
					if (this.func != null)
					{
						this.func.Invoke();
					}
				});
			}
			if (this.mIgnoreBtn != null)
			{
				this.mIgnoreBtn.onClick.RemoveAllListeners();
				this.mIgnoreBtn.onClick.AddListener(new UnityAction(this.OnIgnoreBtnClick));
			}
		}

		// Token: 0x0600D8FB RID: 55547 RVA: 0x003654AC File Offset: 0x003638AC
		public void InitElement(DeadLineReminderModel model)
		{
			this.data = model;
			this.UpdateButtonState();
			this.InitInterface();
		}

		// Token: 0x0600D8FC RID: 55548 RVA: 0x003654C4 File Offset: 0x003638C4
		private void InitInterface()
		{
			if (this.data.type == DeadLineReminderType.DRT_NOTIFYINFO)
			{
				string text = string.Empty;
				string text2 = string.Empty;
				text = DataManager<DeadLineReminderDataManager>.GetInstance().GetDeadlineReminderItemIcon((NotifyType)this.data.info.type);
				if (this.data.info.type == 7U)
				{
					if (string.IsNullOrEmpty(text))
					{
						text = "UI/Image/Packed/p_MainUIIcon.png:UI_MainUI_Tubiao_Moguan";
					}
					text2 = TR.Value("notice_mogicjar_integral_emptying");
				}
				else if (this.data.info.type == 9U)
				{
					text = "UI/Image/Packed/p_UI_Fuli.png:UI_Fuli_JiangLiZanCunXiang";
					text2 = TR.Value("notice_month_card_high_grade_expire_24h");
				}
				else if (this.data.info.type == 10U)
				{
					if (string.IsNullOrEmpty(text))
					{
						text = "UI/Image/Packed/p_MainUI01.png:UI_MainUI_Tubiao_Yongbingtuan";
					}
					text2 = TR.Value("notice_adventureteam_bounty_emptying");
				}
				else if (this.data.info.type == 11U)
				{
					if (string.IsNullOrEmpty(text))
					{
						text = "UI/Image/Packed/p_MainUI01.png:UI_MainUI_Tubiao_Yongbingtuan";
					}
					text2 = TR.Value("notice_adventureteam_inheritbless_emptying");
				}
				else if (this.data.info.type == 12U)
				{
					if (string.IsNullOrEmpty(text))
					{
						text = "UI/Image/Packed/p_MainUI01.png:UI_MainUI_Tubiao_Yongbingtuan";
					}
					text2 = TR.Value("adventurer_pass_card_shop_coin_to_do_empty", DataManager<AdventurerPassCardDataManager>.GetInstance().SeasonID);
				}
				if (this.mIcon != null)
				{
					ETCImageLoader.LoadSprite(ref this.mIcon, text, true);
					this.mIcon.SetNativeSize();
				}
				if (this.mDesc != null)
				{
					this.mDesc.text = text2;
				}
			}
			else
			{
				ItemData itemData = this.data.itemData;
				if (this.mBackGround != null)
				{
					ETCImageLoader.LoadSprite(ref this.mBackGround, itemData.GetQualityInfo().Background, true);
				}
				if (this.mIcon != null)
				{
					ETCImageLoader.LoadSprite(ref this.mIcon, itemData.Icon, true);
				}
				if (this.mLimitTimeGo != null)
				{
					int num;
					bool flag;
					itemData.GetTimeLeft(out num, out flag);
					if ((flag && num > 0) || itemData.IsTimeLimit)
					{
						this.mLimitTimeGo.CustomActive(true);
					}
					else
					{
						this.mLimitTimeGo.CustomActive(false);
					}
				}
				if (this.mIconBtn != null)
				{
					this.mIconBtn.onClick.RemoveAllListeners();
					this.mIconBtn.onClick.AddListener(delegate()
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
					});
				}
				if (this.mRenewalTxt != null)
				{
					this.mRenewalTxt.text = this.strFuncName;
				}
				if (this.mName != null)
				{
					this.mName.text = itemData.GetColorName(string.Empty, false);
				}
				if (this.mTimeRemain != null)
				{
					this.mTimeRemain.text = this.GetTimeLeftDesc(itemData);
				}
			}
		}

		// Token: 0x0600D8FD RID: 55549 RVA: 0x003657E8 File Offset: 0x00363BE8
		private void UpdateButtonState()
		{
			if (this.data.type == DeadLineReminderType.DRT_NOTIFYINFO)
			{
				this.mControl.Key = "NotifyInfo";
			}
			else if (this.GetSuitableFunc(this.data.itemData, out this.strFuncName, out this.func))
			{
				this.mControl.Key = "Rebewal";
			}
			else
			{
				this.mControl.Key = "Ignore";
			}
		}

		// Token: 0x0600D8FE RID: 55550 RVA: 0x00365864 File Offset: 0x00363C64
		private string GetTimeLeftDesc(ItemData a_itemData)
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

		// Token: 0x0600D8FF RID: 55551 RVA: 0x0036594C File Offset: 0x00363D4C
		private bool GetSuitableFunc(ItemData a_itemData, out string a_strName, out UnityAction a_func)
		{
			if (a_itemData.CanRenewal())
			{
				a_strName = TR.Value("tip_renewal");
				a_func = delegate()
				{
					this.OnRenewalItem(a_itemData);
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
					if (a_itemData.PackageType == EPackageType.Consumable && a_itemData.SubType == 53 && a_itemData.ThirdType == ItemTable.eThirdType.ChangeAdventureName)
					{
						a_strName = TR.Value("tip_check");
						a_func = delegate()
						{
							this.OnToViewClick(a_itemData);
						};
						return true;
					}
					a_strName = TR.Value("tip_use");
					a_func = delegate()
					{
						this.TryOnUseItem(a_itemData);
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
						this.OnItemLink(a_itemData);
					};
					return true;
				}
				if (a_itemData.Type == ItemTable.eType.EXPENDABLE && a_itemData.SubType == 25 && Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Forge))
				{
					if (a_itemData.SubType == 25)
					{
						a_strName = TR.Value("tip_enchanting");
					}
					else
					{
						a_strName = TR.Value("tip_forge");
					}
					a_func = delegate()
					{
						this.OnForgeItem(a_itemData);
					};
					return true;
				}
			}
			a_strName = TR.Value("tip_check");
			a_func = delegate()
			{
				this.OnToViewClick(a_itemData);
			};
			return true;
		}

		// Token: 0x0600D900 RID: 55552 RVA: 0x00365B65 File Offset: 0x00363F65
		private void OnRenewalItem(ItemData item)
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<RenewalItemFrame>(FrameLayer.Middle, item, string.Empty);
		}

		// Token: 0x0600D901 RID: 55553 RVA: 0x00365B7C File Offset: 0x00363F7C
		private void TryOnUseItem(ItemData item)
		{
			if (item.Type == ItemTable.eType.EQUIP)
			{
				int masterPriority = DataManager<EquipMasterDataManager>.GetInstance().GetMasterPriority(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)item.Quality, (int)item.EquipWearSlotType, (int)item.ThirdType);
				if (masterPriority == 2)
				{
					SystemNotifyManager.SystemNotifyOkCancel(7019, delegate
					{
						this.OnUseItem(item);
					}, null, FrameLayer.High, false);
					return;
				}
			}
			this.OnUseItem(item);
		}

		// Token: 0x0600D902 RID: 55554 RVA: 0x00365C14 File Offset: 0x00364014
		private void OnUseItem(ItemData item)
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

		// Token: 0x0600D903 RID: 55555 RVA: 0x00365D2C File Offset: 0x0036412C
		private void OnItemLink(ItemData item)
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

		// Token: 0x0600D904 RID: 55556 RVA: 0x00365DC4 File Offset: 0x003641C4
		private void OnForgeItem(ItemData a_item)
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

		// Token: 0x0600D905 RID: 55557 RVA: 0x00365E2C File Offset: 0x0036422C
		private void OnGoBtnClick()
		{
			NotifyInfo info = this.data.info;
			if (info.type == 7U)
			{
				DataManager<ShopNewDataManager>.GetInstance().OpenShopNewFrame(7, 0, 0, -1);
				DataManager<DeadLineReminderDataManager>.GetInstance().DeleteActivityNotice(info);
			}
			else if (info.type == 9U)
			{
				DataManager<ActiveManager>.GetInstance().OpenActiveFrame(9380, 6000);
				DataManager<DeadLineReminderDataManager>.GetInstance().DeleteActivityNotice(info);
			}
			else if (info.type == 10U)
			{
				DataManager<AccountShopDataManager>.GetInstance().OpenAccountShop(50, 52, 0, -1);
				DataManager<DeadLineReminderDataManager>.GetInstance().DeleteActivityNotice(info);
			}
			else if (info.type == 11U)
			{
				DataManager<AdventureTeamDataManager>.GetInstance().OpenAdventureTeamInfoFrame(AdventureTeamMainTabType.PassingBless);
				DataManager<DeadLineReminderDataManager>.GetInstance().DeleteActivityNotice(info);
			}
			else if (info.type == 12U)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<AdventurerPassCardFrame>(FrameLayer.Middle, null, string.Empty);
				DataManager<DeadLineReminderDataManager>.GetInstance().DeleteActivityNotice(info);
			}
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<DeadLineReminderFrame>(null, false);
		}

		// Token: 0x0600D906 RID: 55558 RVA: 0x00365F2C File Offset: 0x0036432C
		private void OnToViewClick(ItemData a_item)
		{
			if (a_item != null)
			{
				EPackageOpenMode epackageOpenMode = EPackageOpenMode.Equip;
				if (a_item.Type == ItemTable.eType.EQUIP)
				{
					epackageOpenMode = EPackageOpenMode.Equip;
				}
				else if (a_item.Type == ItemTable.eType.EXPENDABLE)
				{
					epackageOpenMode = EPackageOpenMode.Consumables;
				}
				else if (a_item.Type == ItemTable.eType.MATERIAL)
				{
					epackageOpenMode = EPackageOpenMode.Material;
				}
				else if (a_item.Type == ItemTable.eType.FASHION)
				{
					epackageOpenMode = EPackageOpenMode.Fashion;
				}
				else if (a_item.Type == ItemTable.eType.FUCKTITTLE)
				{
					epackageOpenMode = EPackageOpenMode.Title;
				}
				this.OnIgnoreBtnClick();
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<PackageNewFrame>(FrameLayer.Middle, epackageOpenMode, string.Empty);
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<DeadLineReminderFrame>(null, false);
			}
		}

		// Token: 0x0600D907 RID: 55559 RVA: 0x00365FC4 File Offset: 0x003643C4
		private void OnIgnoreBtnClick()
		{
			DataManager<DeadLineReminderDataManager>.GetInstance().DeleteLimitTimeItem(this.data.itemData);
		}

		// Token: 0x0600D908 RID: 55560 RVA: 0x00365FDB File Offset: 0x003643DB
		private void OnDestroy()
		{
			this.data = null;
			this.strFuncName = string.Empty;
			this.func = null;
		}

		// Token: 0x04007F7F RID: 32639
		[SerializeField]
		private StateController mControl;

		// Token: 0x04007F80 RID: 32640
		[SerializeField]
		private Button mGoBtn;

		// Token: 0x04007F81 RID: 32641
		[SerializeField]
		private Button mRenewalBtn;

		// Token: 0x04007F82 RID: 32642
		[SerializeField]
		private Button mIgnoreBtn;

		// Token: 0x04007F83 RID: 32643
		[SerializeField]
		private Button mIconBtn;

		// Token: 0x04007F84 RID: 32644
		[SerializeField]
		private Image mBackGround;

		// Token: 0x04007F85 RID: 32645
		[SerializeField]
		private Image mIcon;

		// Token: 0x04007F86 RID: 32646
		[SerializeField]
		private Text mName;

		// Token: 0x04007F87 RID: 32647
		[SerializeField]
		private Text mDesc;

		// Token: 0x04007F88 RID: 32648
		[SerializeField]
		private Text mTimeRemain;

		// Token: 0x04007F89 RID: 32649
		[SerializeField]
		private Text mRenewalTxt;

		// Token: 0x04007F8A RID: 32650
		[SerializeField]
		private GameObject mLimitTimeGo;

		// Token: 0x04007F8B RID: 32651
		private DeadLineReminderModel data;

		// Token: 0x04007F8C RID: 32652
		private string strFuncName;

		// Token: 0x04007F8D RID: 32653
		private UnityAction func;
	}
}
