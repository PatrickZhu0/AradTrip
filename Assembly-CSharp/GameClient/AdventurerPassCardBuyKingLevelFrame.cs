using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200142F RID: 5167
	public class AdventurerPassCardBuyKingLevelFrame : ClientFrame
	{
		// Token: 0x0600C86B RID: 51307 RVA: 0x0030A726 File Offset: 0x00308B26
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/AdventurerPassCard/AdventurerPassCardBuyKingLevel";
		}

		// Token: 0x0600C86C RID: 51308 RVA: 0x0030A72D File Offset: 0x00308B2D
		protected override void _OnOpenFrame()
		{
			this.UpdateUI();
			this.BindUIEvent();
		}

		// Token: 0x0600C86D RID: 51309 RVA: 0x0030A73B File Offset: 0x00308B3B
		protected override void _OnCloseFrame()
		{
			this.UnBindUIEvent();
		}

		// Token: 0x0600C86E RID: 51310 RVA: 0x0030A744 File Offset: 0x00308B44
		protected override void _bindExUI()
		{
			this.mBtBuy = this.mBind.GetCom<Button>("btBuy");
			this.mBtBuy.SafeSetOnClickListener(delegate
			{
				int moneyIDByType = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT);
				DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(new CostItemManager.CostInfo
				{
					nMoneyID = moneyIDByType,
					nCount = this.kingPrice
				}, delegate
				{
					SystemNotifyManager.SysNotifyMsgBoxCancelOk(TR.Value("adventurer_pass_card_buy_high_card_tip", this.kingPrice), null, delegate()
					{
						DataManager<AdventurerPassCardDataManager>.GetInstance().SendWorldAventurePassBuyReq(1);
					}, 0f, false, null);
				}, "common_money_cost", null);
			});
			this.btBuyUseRMB = this.mBind.GetCom<Button>("btBuyUseRMB");
			this.btBuyUseRMB.SafeSetOnClickListener(delegate
			{
				SystemNotifyManager.SysNotifyMsgBoxCancelOk(TR.Value("adventurer_pass_card_buy_high_card_tip_rmb", DataManager<AdventurerPassCardDataManager>.GetInstance().KingCardItemPrice), null, delegate()
				{
					DataManager<AdventurerPassCardDataManager>.GetInstance().SendBuyKingCardUseRmb();
				}, 0f, false, null);
			});
			this.mBanner1 = this.mBind.GetCom<Image>("banner1");
			this.mBanner2 = this.mBind.GetCom<Image>("banner2");
			this.mBanner3 = this.mBind.GetCom<Image>("banner3");
			this.mBannerText1 = this.mBind.GetCom<Text>("bannerText1");
			this.mBannerText2 = this.mBind.GetCom<Text>("bannerText2");
			this.mBannerText3 = this.mBind.GetCom<Text>("bannerText3");
			this.mMoneyNum = this.mBind.GetCom<Text>("moneyNum");
			this.moneyNumRMB = this.mBind.GetCom<Text>("moneyNumRMB");
			this.mGeAvatarRendererEx = this.mBind.GetCom<GeAvatarRendererEx>("Actorpos");
			this.mNameTitleRoot = this.mBind.GetGameObject("nameTitleRoot");
			this.mTitleName = this.mBind.GetCom<Text>("titleName");
			this.mTitleAnimation = this.mBind.GetCom<SpriteAniRenderChenghao>("titleAnimation");
			this.mTitleAnimationImage = this.mBind.GetCom<Image>("titleAnimationImage");
		}

		// Token: 0x0600C86F RID: 51311 RVA: 0x0030A8DC File Offset: 0x00308CDC
		protected override void _unbindExUI()
		{
			this.mBtBuy = null;
			this.mBanner1 = null;
			this.mBanner2 = null;
			this.mBanner3 = null;
			this.mBannerText1 = null;
			this.mBannerText2 = null;
			this.mBannerText3 = null;
			this.mMoneyNum = null;
			this.mGeAvatarRendererEx = null;
			this.mNameTitleRoot = null;
			this.mTitleName = null;
			this.mTitleAnimation = null;
			this.mTitleAnimationImage = null;
			this.btBuyUseRMB = null;
			this.moneyNumRMB = null;
		}

		// Token: 0x0600C870 RID: 51312 RVA: 0x0030A952 File Offset: 0x00308D52
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600C871 RID: 51313 RVA: 0x0030A958 File Offset: 0x00308D58
		protected override void _OnUpdate(float timeElapsed)
		{
			if (this.mGeAvatarRendererEx != null)
			{
				while (Global.Settings.avatarLightDir.x > 360f)
				{
					GlobalSetting settings = Global.Settings;
					settings.avatarLightDir.x = settings.avatarLightDir.x - 360f;
				}
				while (Global.Settings.avatarLightDir.x < 0f)
				{
					GlobalSetting settings2 = Global.Settings;
					settings2.avatarLightDir.x = settings2.avatarLightDir.x + 360f;
				}
				while (Global.Settings.avatarLightDir.y > 360f)
				{
					GlobalSetting settings3 = Global.Settings;
					settings3.avatarLightDir.y = settings3.avatarLightDir.y - 360f;
				}
				while (Global.Settings.avatarLightDir.y < 0f)
				{
					GlobalSetting settings4 = Global.Settings;
					settings4.avatarLightDir.y = settings4.avatarLightDir.y + 360f;
				}
				while (Global.Settings.avatarLightDir.z > 360f)
				{
					GlobalSetting settings5 = Global.Settings;
					settings5.avatarLightDir.z = settings5.avatarLightDir.z - 360f;
				}
				while (Global.Settings.avatarLightDir.z < 0f)
				{
					GlobalSetting settings6 = Global.Settings;
					settings6.avatarLightDir.z = settings6.avatarLightDir.z + 360f;
				}
				this.mGeAvatarRendererEx.m_LightRot = Global.Settings.avatarLightDir;
			}
		}

		// Token: 0x0600C872 RID: 51314 RVA: 0x0030AAE1 File Offset: 0x00308EE1
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UpdateAventurePassStatus, new ClientEventSystem.UIEventHandler(this._OnUpdateAventurePassStatus));
		}

		// Token: 0x0600C873 RID: 51315 RVA: 0x0030AAFE File Offset: 0x00308EFE
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UpdateAventurePassStatus, new ClientEventSystem.UIEventHandler(this._OnUpdateAventurePassStatus));
		}

		// Token: 0x0600C874 RID: 51316 RVA: 0x0030AB1C File Offset: 0x00308F1C
		private void InitAvatar()
		{
			int jobTableID = DataManager<PlayerBaseData>.GetInstance().JobTableID;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(jobTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("can not find JobTable with id:{0}", new object[]
				{
					jobTableID
				});
			}
			else
			{
				ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 == null)
				{
					Logger.LogErrorFormat("can not find ResTable with id:{0}", new object[]
					{
						tableItem.Mode
					});
				}
				else
				{
					this.mGeAvatarRendererEx.ClearAvatar();
					this.mGeAvatarRendererEx.LoadAvatar(tableItem2.ModelPath, -1);
					if (jobTableID == DataManager<PlayerBaseData>.GetInstance().JobTableID)
					{
						DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromCurrentEquiped(this.mGeAvatarRendererEx, null, false);
					}
					this.mGeAvatarRendererEx.AttachAvatar("Aureole", "Effects/Scene_effects/Effectui/EffUI_chuangjue_fazhen_JS", "[actor]Orign", false, true, false, 0f);
					this.mGeAvatarRendererEx.SuitAvatar(true, false);
				}
			}
		}

		// Token: 0x0600C875 RID: 51317 RVA: 0x0030AC24 File Offset: 0x00309024
		private void CalcGiftBagItemIDs(int itemID, ref List<int> ids)
		{
			if (ids == null)
			{
				return;
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(itemID, 100, 0);
			if (itemData == null)
			{
				return;
			}
			List<GiftTable> gifts = itemData.GetGifts();
			if (gifts != null)
			{
				for (int i = 0; i < gifts.Count; i++)
				{
					this.CalcGiftBagItemIDs(gifts[i].ItemID, ref ids);
				}
			}
			else
			{
				ids.Add(itemID);
			}
		}

		// Token: 0x0600C876 RID: 51318 RVA: 0x0030AC8E File Offset: 0x0030908E
		private void SetTitleName(string name, ItemTable.eColor color)
		{
			if (this.mTitleName != null)
			{
				this.mTitleName.text = DataManager<PetDataManager>.GetInstance().GetColorName(name, (PetTable.eQuality)color);
			}
		}

		// Token: 0x0600C877 RID: 51319 RVA: 0x0030ACB8 File Offset: 0x003090B8
		private void SetNameTitleImage(ItemTable itemTable)
		{
			if (itemTable != null && itemTable.Path2.Count == 4 && this.mTitleAnimation != null)
			{
				this.mTitleAnimation.gameObject.CustomActive(true);
				this.mTitleAnimation.Reset(itemTable.Path2[0], itemTable.Path2[1], int.Parse(itemTable.Path2[2]), float.Parse(itemTable.Path2[3]), itemTable.ModelPath);
				if (this.mTitleAnimationImage != null)
				{
					this.mTitleAnimationImage.enabled = true;
				}
			}
		}

		// Token: 0x0600C878 RID: 51320 RVA: 0x0030AD68 File Offset: 0x00309168
		private void UpdateFashionAndTitle()
		{
			if (this.mGeAvatarRendererEx == null)
			{
				return;
			}
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<AdventurePassBuyRewardTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					AdventurePassBuyRewardTable adventurePassBuyRewardTable = keyValuePair.Value as AdventurePassBuyRewardTable;
					if (adventurePassBuyRewardTable != null)
					{
						if ((long)adventurePassBuyRewardTable.Season == (long)((ulong)DataManager<AdventurerPassCardDataManager>.GetInstance().SeasonID))
						{
							string[] array = adventurePassBuyRewardTable.GiftBagID.Split(new char[]
							{
								'|'
							});
							if (array != null)
							{
								int num = 0;
								List<int> list = new List<int>();
								if (list != null)
								{
									list.Clear();
									List<int> list2 = new List<int>();
									if (list2 != null)
									{
										for (int i = 0; i < array.Length; i++)
										{
											this.CalcGiftBagItemIDs(Utility.ToInt(array[i]), ref list2);
										}
										for (int j = 0; j < list2.Count; j++)
										{
											ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(list2[j], string.Empty, string.Empty);
											if (tableItem != null)
											{
												if (tableItem.Type == ItemTable.eType.FASHION)
												{
													list.Add(list2[j]);
												}
												else if (tableItem.Type == ItemTable.eType.FUCKTITTLE)
												{
													num = list2[j];
												}
											}
										}
										for (int k = 0; k < list.Count; k++)
										{
											this.UpdateHeroActorFashion(Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(list[k], string.Empty, string.Empty));
										}
										ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(num, string.Empty, string.Empty);
										if (tableItem2 != null)
										{
											this.SetNameTitleImage(tableItem2);
											this.SetTitleName(tableItem2.Name, tableItem2.Color);
										}
										this.mNameTitleRoot.CustomActive(tableItem2 != null);
										list2.Clear();
										list2.AddRange(list);
										list2.Add(num);
										for (int l = list2.Count; l < 7; l++)
										{
											list2.Add(0);
										}
										for (int m = 0; m < list2.Count; m++)
										{
											ComItem com = this.mBind.GetCom<ComItem>(string.Format("Item{0}", m));
											if (!(com == null))
											{
												com.Setup(ItemDataManager.CreateItemDataFromTable(list2[m], 100, 0), delegate(GameObject go, ItemData item)
												{
													DataManager<ItemTipManager>.GetInstance().CloseAll();
													DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
												});
												com.CustomActive(list2[m] > 0);
											}
										}
										break;
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600C879 RID: 51321 RVA: 0x0030B050 File Offset: 0x00309450
		private void UpdateHeroActorFashion(ItemTable itemTable)
		{
			if (itemTable == null)
			{
				return;
			}
			if (this.mGeAvatarRendererEx == null)
			{
				return;
			}
			GeAvatarRendererEx geAvatarRendererEx = this.mGeAvatarRendererEx;
			EFashionWearSlotType equipSlotType = FashionMallUtility.GetEquipSlotType(itemTable);
			if (itemTable.SubType == ItemTable.eSubType.FASHION_WEAPON)
			{
				int selfBaseJobId = CommonUtility.GetSelfBaseJobId();
				DataManager<PlayerBaseData>.GetInstance().AvatarEquipWeapon(geAvatarRendererEx, selfBaseJobId, itemTable.ID, null, false);
			}
			else
			{
				DataManager<PlayerBaseData>.GetInstance().AvatarEquipPart(geAvatarRendererEx, equipSlotType, 0, null, 0, false);
				DataManager<PlayerBaseData>.GetInstance().AvatarEquipPart(geAvatarRendererEx, equipSlotType, itemTable.ID, null, 0, false);
			}
			geAvatarRendererEx.ChangeAction("Anim_Show_Idle", 1f, true);
		}

		// Token: 0x0600C87A RID: 51322 RVA: 0x0030B0E8 File Offset: 0x003094E8
		private void UpdateUI()
		{
			this.InitAvatar();
			this.UpdateFashionAndTitle();
			this.mBtBuy.SafeSetGray(DataManager<AdventurerPassCardDataManager>.GetInstance().GetPassCardType != AdventurerPassCardDataManager.PassCardType.Normal, true);
			this.btBuyUseRMB.SafeSetGray(DataManager<AdventurerPassCardDataManager>.GetInstance().GetPassCardType != AdventurerPassCardDataManager.PassCardType.Normal, true);
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<AdventurePassBuyRewardTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					AdventurePassBuyRewardTable adventurePassBuyRewardTable = keyValuePair.Value as AdventurePassBuyRewardTable;
					if (adventurePassBuyRewardTable != null)
					{
						if ((long)adventurePassBuyRewardTable.Season == (long)((ulong)DataManager<AdventurerPassCardDataManager>.GetInstance().SeasonID))
						{
							this.mBanner1.SafeSetImage(adventurePassBuyRewardTable.KingRewardBanner1, false);
							this.mBannerText1.SafeSetText(adventurePassBuyRewardTable.KingRewardBanner1Text);
							this.mBanner2.SafeSetImage(adventurePassBuyRewardTable.KingRewardBanner2, false);
							this.mBannerText2.SafeSetText(adventurePassBuyRewardTable.KingRewardBanner2Text);
							this.mBanner3.SafeSetImage(adventurePassBuyRewardTable.KingRewardBanner3, false);
							this.mBannerText3.SafeSetText(adventurePassBuyRewardTable.KingRewardBanner3Text);
							this.mMoneyNum.SafeSetText(adventurePassBuyRewardTable.KingPrice.ToString());
							this.kingPrice = adventurePassBuyRewardTable.KingPrice;
							break;
						}
					}
				}
			}
			this.moneyNumRMB.SafeSetText(TR.Value("adventurer_pass_card_rmb", DataManager<AdventurerPassCardDataManager>.GetInstance().KingCardItemPrice));
			bool flag = DataManager<AdventurerPassCardDataManager>.GetInstance().IsBuyKingCardUseRMB((int)DataManager<AdventurerPassCardDataManager>.GetInstance().SeasonID);
			this.mBtBuy.CustomActive(!flag);
			this.btBuyUseRMB.CustomActive(flag);
		}

		// Token: 0x0600C87B RID: 51323 RVA: 0x0030B28A File Offset: 0x0030968A
		private void _OnUpdateAventurePassStatus(UIEvent uiEvent)
		{
			this.UpdateUI();
		}

		// Token: 0x04007389 RID: 29577
		private int kingPrice;

		// Token: 0x0400738A RID: 29578
		private Button mBtBuy;

		// Token: 0x0400738B RID: 29579
		private Image mBanner1;

		// Token: 0x0400738C RID: 29580
		private Image mBanner2;

		// Token: 0x0400738D RID: 29581
		private Image mBanner3;

		// Token: 0x0400738E RID: 29582
		private Text mBannerText1;

		// Token: 0x0400738F RID: 29583
		private Text mBannerText2;

		// Token: 0x04007390 RID: 29584
		private Text mBannerText3;

		// Token: 0x04007391 RID: 29585
		private Text mMoneyNum;

		// Token: 0x04007392 RID: 29586
		private GeAvatarRendererEx mGeAvatarRendererEx;

		// Token: 0x04007393 RID: 29587
		private GameObject mNameTitleRoot;

		// Token: 0x04007394 RID: 29588
		private Text mTitleName;

		// Token: 0x04007395 RID: 29589
		private SpriteAniRenderChenghao mTitleAnimation;

		// Token: 0x04007396 RID: 29590
		private Image mTitleAnimationImage;

		// Token: 0x04007397 RID: 29591
		private Button btBuyUseRMB;

		// Token: 0x04007398 RID: 29592
		private Text moneyNumRMB;
	}
}
