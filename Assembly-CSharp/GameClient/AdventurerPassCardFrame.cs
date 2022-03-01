using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001431 RID: 5169
	public class AdventurerPassCardFrame : ClientFrame
	{
		// Token: 0x0600C891 RID: 51345 RVA: 0x0030B649 File Offset: 0x00309A49
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/AdventurerPassCard/AdventurerPassCard";
		}

		// Token: 0x0600C892 RID: 51346 RVA: 0x0030B650 File Offset: 0x00309A50
		protected override void _OnOpenFrame()
		{
			this.ensureElement = true;
			AdventurerPassCardFrame.RequestPassCardData();
			this.awardItemInfo = null;
			this.InitAwards();
			this.InitAvatar();
			this.UpdateFashionAndTitle();
			if (this.firstMoney != null)
			{
				this.firstMoney.InitMoneyItem(600002545);
			}
			this.BindUIEvent();
		}

		// Token: 0x0600C893 RID: 51347 RVA: 0x0030B6A9 File Offset: 0x00309AA9
		protected override void _OnCloseFrame()
		{
			this.awardItemInfo = null;
			this.UnBindUIEvent();
		}

		// Token: 0x0600C894 RID: 51348 RVA: 0x0030B6B8 File Offset: 0x00309AB8
		protected override void _bindExUI()
		{
			this.mCardLv = this.mBind.GetCom<Text>("cardLv");
			this.mCardExp = this.mBind.GetCom<Text>("cardExp");
			this.mBuyLv = this.mBind.GetCom<Button>("buyLv");
			this.mBuyLv.SafeSetOnClickListener(delegate
			{
				if ((ulong)DataManager<AdventurerPassCardDataManager>.GetInstance().CardLv >= (ulong)((long)DataManager<AdventurerPassCardDataManager>.GetInstance().GetAdventurerPassCardMaxLv(DataManager<AdventurerPassCardDataManager>.GetInstance().SeasonID)))
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("adventurer_pass_card_lv_max"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				if (DataManager<AdventurerPassCardDataManager>.GetInstance().GetPassCardType == AdventurerPassCardDataManager.PassCardType.Normal)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("adventurer_pass_card_buy_lv_need_king"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<AdventurerPassCardBuyLevelFrame>(FrameLayer.Middle, null, string.Empty);
			});
			this.mBuyHighLvCard = this.mBind.GetCom<Button>("buyHighLvCard");
			this.mBuyHighLvCard.SafeSetOnClickListener(delegate
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<AdventurerPassCardBuyKingLevelFrame>(FrameLayer.Middle, null, string.Empty);
			});
			this.mGetExpAward = this.mBind.GetCom<Button>("getExpAward");
			this.mGetExpAward.SafeSetOnClickListener(delegate
			{
				AdventurerPassCardDataManager.ExpPackState expPackState = DataManager<AdventurerPassCardDataManager>.GetInstance().GetExpPackState();
				if (expPackState == AdventurerPassCardDataManager.ExpPackState.Lock)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("adventurer_pass_card_high_card_lock", Utility.GetSystemValueFromTable(SystemValueTable.eType3.SVT_ADVENTURE_PASS_EXP, 0)), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				else if (expPackState == AdventurerPassCardDataManager.ExpPackState.CanGet)
				{
					SystemNotifyManager.SysNotifyMsgBoxCancelOk(TR.Value("adventurer_pass_card_high_card_get_exp_tip", Utility.GetSystemValueFromTable(SystemValueTable.eType3.SVT_ADVENTURE_PASS_EXP, 0)), null, delegate()
					{
						DataManager<AdventurerPassCardDataManager>.GetInstance().SendWorldAventurePassExpPackReq(1);
					}, 0f, false, null);
				}
				else if (expPackState == AdventurerPassCardDataManager.ExpPackState.Got)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("adventurer_pass_card_high_card_has_get_exp"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
			});
			this.awards = this.mBind.GetCom<ComUIListScript>("awards");
			this.mShowAwards = this.mBind.GetCom<Button>("showAwards");
			this.mShowAwards.SafeSetOnClickListener(delegate
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<AdventurerPassCardShowAwardsFrame>(FrameLayer.Middle, null, string.Empty);
			});
			this.mSeasonText = this.mBind.GetCom<Text>("seasonText");
			this.mSeasonTime = this.mBind.GetCom<Text>("seasonTime");
			this.mCardExpProcess = this.mBind.GetCom<Slider>("cardExpProcess");
			this.mTodayActive = this.mBind.GetCom<Text>("todayActive");
			this.mGeAvatarRendererEx = this.mBind.GetCom<GeAvatarRendererEx>("Actorpos");
			this.mOneKeyGetAward = this.mBind.GetCom<Button>("oneKeyGetAward");
			this.mOneKeyGetAward.SafeSetOnClickListener(delegate
			{
				DataManager<AdventurerPassCardDataManager>.GetInstance().SendWorldAventurePassRewardReq(0U);
			});
			this.mLockRoot = this.mBind.GetGameObject("lockRoot");
			this.mExchange = this.mBind.GetCom<Button>("exchange");
			this.mExchange.SafeSetOnClickListener(delegate
			{
				DataManager<AccountShopDataManager>.GetInstance().OpenAccountShop(70, 0, 0, -1);
			});
			this.firstMoney = this.mBind.GetCom<ShopNewMoneyItem>("firstMoney");
			this.mHighawardItemShow = this.mBind.GetCom<AdventurerPassCardAwardItem>("highawardItemShow");
			this.mExpAddByActiveDesc = this.mBind.GetCom<Text>("expAddByActiveDesc");
			this.mCanGotEffRoot = this.mBind.GetGameObject("canGotEffRoot");
			this.mGou = this.mBind.GetCom<Image>("gou");
			this.mNameTitleRoot = this.mBind.GetGameObject("nameTitleRoot");
			this.mTitleName = this.mBind.GetCom<Text>("titleName");
			this.mTitleAnimation = this.mBind.GetCom<SpriteAniRenderChenghao>("titleAnimation");
			this.mTitleAnimationImage = this.mBind.GetCom<Image>("titleAnimationImage");
			this.mOneKeyGetAwardRedPoint = this.mBind.GetGameObject("oneKeyGetAwardRedPoint");
			this.mBtnLock = this.mBind.GetCom<Button>("btnLock");
			this.mBtnLock.SafeSetOnClickListener(delegate
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<AdventurerPassCardBuyKingLevelFrame>(FrameLayer.Middle, null, string.Empty);
			});
		}

		// Token: 0x0600C895 RID: 51349 RVA: 0x0030BA1C File Offset: 0x00309E1C
		protected override void _unbindExUI()
		{
			this.mCardLv = null;
			this.mCardExp = null;
			this.mBuyLv = null;
			this.mBuyHighLvCard = null;
			this.mGetExpAward = null;
			this.awards = null;
			this.mShowAwards = null;
			this.mSeasonText = null;
			this.mSeasonTime = null;
			this.mCardExpProcess = null;
			this.mTodayActive = null;
			this.mGeAvatarRendererEx = null;
			this.mOneKeyGetAward = null;
			this.mLockRoot = null;
			this.mExchange = null;
			this.firstMoney = null;
			this.mHighawardItemShow = null;
			this.mExpAddByActiveDesc = null;
			this.mCanGotEffRoot = null;
			this.mGou = null;
			this.mNameTitleRoot = null;
			this.mTitleName = null;
			this.mTitleAnimation = null;
			this.mTitleAnimationImage = null;
			this.mOneKeyGetAwardRedPoint = null;
			this.mBtnLock = null;
		}

		// Token: 0x0600C896 RID: 51350 RVA: 0x0030BADF File Offset: 0x00309EDF
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UpdateAventurePassStatus, new ClientEventSystem.UIEventHandler(this._OnUpdateAventurePassStatus));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UpdateAventurePassExpPackStatus, new ClientEventSystem.UIEventHandler(this._OnUpdateAventurePassExpPackStatus));
		}

		// Token: 0x0600C897 RID: 51351 RVA: 0x0030BB17 File Offset: 0x00309F17
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UpdateAventurePassStatus, new ClientEventSystem.UIEventHandler(this._OnUpdateAventurePassStatus));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UpdateAventurePassExpPackStatus, new ClientEventSystem.UIEventHandler(this._OnUpdateAventurePassExpPackStatus));
		}

		// Token: 0x0600C898 RID: 51352 RVA: 0x0030BB4F File Offset: 0x00309F4F
		private void UpdateUI()
		{
			this._OnUpdateAventurePassStatus(null);
		}

		// Token: 0x0600C899 RID: 51353 RVA: 0x0030BB58 File Offset: 0x00309F58
		private void UpdateNextLvHighAward(int lv)
		{
			if (this.mHighawardItemShow == null || this.awardItemInfo == null)
			{
				return;
			}
			bool flag = false;
			for (int i = lv + 1; i < this.awardItemInfo.Count; i++)
			{
				if (this.awardItemInfo.ContainsKey(i))
				{
					if (this.awardItemInfo[i].highAwards != null)
					{
						if (this.awardItemInfo[i].highAwards.FindIndex((AdventurerPassCardDataManager.ItemInfo item) => item.highValue) >= 0)
						{
							this.mHighawardItemShow.SetUp(this.awardItemInfo[i], true);
							flag = true;
							break;
						}
					}
				}
			}
			if (!flag)
			{
				for (int i = lv; i >= 1; i--)
				{
					if (this.awardItemInfo.ContainsKey(i))
					{
						if (this.awardItemInfo[i].highAwards != null)
						{
							if (this.awardItemInfo[i].highAwards.FindIndex((AdventurerPassCardDataManager.ItemInfo item) => item.highValue) >= 0)
							{
								this.mHighawardItemShow.SetUp(this.awardItemInfo[i], true);
								flag = true;
								break;
							}
						}
					}
				}
			}
			if (!flag)
			{
			}
		}

		// Token: 0x0600C89A RID: 51354 RVA: 0x0030BCD4 File Offset: 0x0030A0D4
		private void InitAwards()
		{
			if (this.awards == null)
			{
				return;
			}
			this.awards.Initialize();
			this.awards.onBindItem = ((GameObject go) => go);
			this.awards.onItemVisiable = delegate(ComUIListElementScript go)
			{
				if (go == null)
				{
					return;
				}
				if (this.awardItemInfo == null)
				{
					return;
				}
				AdventurerPassCardAwardItem component = go.GetComponent<AdventurerPassCardAwardItem>();
				if (component == null)
				{
					return;
				}
				int key = go.m_index + 1;
				if (this.awardItemInfo.ContainsKey(key))
				{
					component.SetUp(this.awardItemInfo[key], false);
				}
			};
			ScrollRect scrollRect = this.awards.m_scrollRect;
			if (scrollRect != null)
			{
				scrollRect.onValueChanged.RemoveAllListeners();
				scrollRect.onValueChanged.AddListener(delegate(Vector2 vec)
				{
				});
			}
		}

		// Token: 0x0600C89B RID: 51355 RVA: 0x0030BD88 File Offset: 0x0030A188
		private void UpdateAwards()
		{
			if (this.awards == null)
			{
				return;
			}
			this.awardItemInfo = DataManager<AdventurerPassCardDataManager>.GetInstance().GetAdventurePassAwardsBySeasonID(DataManager<AdventurerPassCardDataManager>.GetInstance().SeasonID);
			if (this.awardItemInfo == null)
			{
				return;
			}
			this.awards.SetElementAmount(this.awardItemInfo.Count);
			if (this.ensureElement)
			{
				this.ensureElement = false;
				int num = (int)DataManager<AdventurerPassCardDataManager>.GetInstance().CardLv;
				for (int i = 1; i <= num; i++)
				{
					if ((DataManager<AdventurerPassCardDataManager>.GetInstance().GetPassCardType > AdventurerPassCardDataManager.PassCardType.Normal && !DataManager<AdventurerPassCardDataManager>.GetInstance().IsHighAwardReceived(i)) || !DataManager<AdventurerPassCardDataManager>.GetInstance().IsNormalAwardReceived(i))
					{
						num = i;
						break;
					}
				}
				int num2 = num - 1;
				if (num2 >= 0 && num2 < this.awards.GetElementAmount())
				{
					this.awards.EnsureElementVisable(num2);
				}
			}
		}

		// Token: 0x0600C89C RID: 51356 RVA: 0x0030BE74 File Offset: 0x0030A274
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

		// Token: 0x0600C89D RID: 51357 RVA: 0x0030BF7C File Offset: 0x0030A37C
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

		// Token: 0x0600C89E RID: 51358 RVA: 0x0030BFE6 File Offset: 0x0030A3E6
		private void SetTitleName(string name, ItemTable.eColor color)
		{
			if (this.mTitleName != null)
			{
				this.mTitleName.text = DataManager<PetDataManager>.GetInstance().GetColorName(name, (PetTable.eQuality)color);
			}
		}

		// Token: 0x0600C89F RID: 51359 RVA: 0x0030C010 File Offset: 0x0030A410
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

		// Token: 0x0600C8A0 RID: 51360 RVA: 0x0030C0C0 File Offset: 0x0030A4C0
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
								int id = 0;
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
													id = list2[j];
												}
											}
										}
										for (int k = 0; k < list.Count; k++)
										{
											this.UpdateHeroActorFashion(Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(list[k], string.Empty, string.Empty));
										}
										ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id, string.Empty, string.Empty);
										if (tableItem2 != null)
										{
											this.SetNameTitleImage(tableItem2);
											this.SetTitleName(tableItem2.Name, tableItem2.Color);
										}
										this.mNameTitleRoot.CustomActive(tableItem2 != null);
										break;
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600C8A1 RID: 51361 RVA: 0x0030C2D8 File Offset: 0x0030A6D8
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

		// Token: 0x0600C8A2 RID: 51362 RVA: 0x0030C36E File Offset: 0x0030A76E
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600C8A3 RID: 51363 RVA: 0x0030C374 File Offset: 0x0030A774
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
			int lv = 0;
			bool flag = false;
			if (this.awards != null && this.awards.IsInitialised())
			{
				for (int i = 0; i < this.awards.GetElementAmount(); i++)
				{
					if (this.awards.IsElementInScrollArea(i))
					{
						lv = i + 1;
						flag = true;
					}
					else if (flag)
					{
						break;
					}
				}
			}
			this.UpdateNextLvHighAward(lv);
		}

		// Token: 0x0600C8A4 RID: 51364 RVA: 0x0030C56C File Offset: 0x0030A96C
		private string GetTimeStampDateString(int time)
		{
			DateTime dateTimeByTimeStamp = TimeUtility.GetDateTimeByTimeStamp(time);
			return string.Format("{0:D4}.{1:D2}.{2:D2}", dateTimeByTimeStamp.Year, dateTimeByTimeStamp.Month, dateTimeByTimeStamp.Day);
		}

		// Token: 0x0600C8A5 RID: 51365 RVA: 0x0030C5B0 File Offset: 0x0030A9B0
		public static bool CanOneKeyGetAwards()
		{
			bool flag = false;
			bool flag2 = false;
			int num = 1;
			while ((long)num <= (long)((ulong)DataManager<AdventurerPassCardDataManager>.GetInstance().CardLv))
			{
				if (!DataManager<AdventurerPassCardDataManager>.GetInstance().IsNormalAwardReceived(num))
				{
					flag = true;
					break;
				}
				num++;
			}
			if (DataManager<AdventurerPassCardDataManager>.GetInstance().GetPassCardType > AdventurerPassCardDataManager.PassCardType.Normal)
			{
				int num2 = 1;
				while ((long)num2 <= (long)((ulong)DataManager<AdventurerPassCardDataManager>.GetInstance().CardLv))
				{
					if (!DataManager<AdventurerPassCardDataManager>.GetInstance().IsHighAwardReceived(num2))
					{
						flag2 = true;
						break;
					}
					num2++;
				}
			}
			return flag || flag2;
		}

		// Token: 0x0600C8A6 RID: 51366 RVA: 0x0030C644 File Offset: 0x0030AA44
		private int GetExpAddByActive(int active)
		{
			int num = 0;
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<AdventurePassActivityTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					AdventurePassActivityTable adventurePassActivityTable = keyValuePair.Value as AdventurePassActivityTable;
					if (adventurePassActivityTable != null)
					{
						if (active < adventurePassActivityTable.Activity)
						{
							break;
						}
						num += adventurePassActivityTable.Exp;
					}
				}
			}
			return num;
		}

		// Token: 0x0600C8A7 RID: 51367 RVA: 0x0030C6B8 File Offset: 0x0030AAB8
		private int GetMaxExpAddUp()
		{
			int num = 0;
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<AdventurePassActivityTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					AdventurePassActivityTable adventurePassActivityTable = keyValuePair.Value as AdventurePassActivityTable;
					if (adventurePassActivityTable != null)
					{
						num += adventurePassActivityTable.Exp;
					}
				}
			}
			return num;
		}

		// Token: 0x0600C8A8 RID: 51368 RVA: 0x0030C71C File Offset: 0x0030AB1C
		private string GetExpAddDesc()
		{
			string text = string.Empty;
			int num = 5;
			int num2 = 0;
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<AdventurePassActivityTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					AdventurePassActivityTable adventurePassActivityTable = keyValuePair.Value as AdventurePassActivityTable;
					if (adventurePassActivityTable != null)
					{
						if (num2 == 0)
						{
							num = adventurePassActivityTable.Exp;
						}
						if (num2 != 0)
						{
							text += "/";
						}
						text += adventurePassActivityTable.Activity.ToString();
						num2++;
					}
				}
			}
			return TR.Value("adventurer_pass_card_exp_add_desc", text, num);
		}

		// Token: 0x0600C8A9 RID: 51369 RVA: 0x0030C7D2 File Offset: 0x0030ABD2
		public static void RequestPassCardData()
		{
			DataManager<AdventurerPassCardDataManager>.GetInstance().SendWorldAventurePassStatusReq();
			DataManager<AdventurerPassCardDataManager>.GetInstance().SendWorldAventurePassExpPackReq(0);
		}

		// Token: 0x0600C8AA RID: 51370 RVA: 0x0030C7E9 File Offset: 0x0030ABE9
		private void _OnUpdateAventurePassExpPackStatus(UIEvent uiEvent)
		{
			this.mCanGotEffRoot.CustomActive(DataManager<AdventurerPassCardDataManager>.GetInstance().GetExpPackState() == AdventurerPassCardDataManager.ExpPackState.CanGet);
			this.mGou.CustomActive(DataManager<AdventurerPassCardDataManager>.GetInstance().GetExpPackState() == AdventurerPassCardDataManager.ExpPackState.Got);
		}

		// Token: 0x0600C8AB RID: 51371 RVA: 0x0030C81C File Offset: 0x0030AC1C
		private void _OnUpdateAventurePassStatus(UIEvent uiEvent)
		{
			this.mCardLv.SafeSetText(DataManager<AdventurerPassCardDataManager>.GetInstance().CardLv.ToString());
			this.mCardExp.SafeSetText(TR.Value("adventurer_pass_card_exp_process", DataManager<AdventurerPassCardDataManager>.GetInstance().CardExp, DataManager<AdventurerPassCardDataManager>.GetInstance().GetNeedExpToNextLv((int)DataManager<AdventurerPassCardDataManager>.GetInstance().CardLv)));
			if ((ulong)DataManager<AdventurerPassCardDataManager>.GetInstance().CardLv == (ulong)((long)DataManager<AdventurerPassCardDataManager>.GetInstance().GetAdventurerPassCardMaxLv(DataManager<AdventurerPassCardDataManager>.GetInstance().SeasonID)))
			{
				this.mCardExp.SafeSetText(TR.Value("adventurer_pass_card_reach_max_lv"));
			}
			this.mTodayActive.SafeSetText(TR.Value("adventurer_pass_card_get_active_today", DataManager<AdventurerPassCardDataManager>.GetInstance().GetTodayActive(), this.GetExpAddByActive(DataManager<AdventurerPassCardDataManager>.GetInstance().GetTodayActive()), this.GetMaxExpAddUp()));
			this.mSeasonText.SafeSetText(TR.Value("adventurer_pass_card_season_info", DataManager<AdventurerPassCardDataManager>.GetInstance().SeasonID));
			this.mSeasonTime.SafeSetText(TR.Value("adventurer_pass_card_season_time_info", this.GetTimeStampDateString(DataManager<AdventurerPassCardDataManager>.GetInstance().GetSeasonStartTime()), this.GetTimeStampDateString(DataManager<AdventurerPassCardDataManager>.GetInstance().GetSeasonEndTime())));
			int needExpToNextLv = DataManager<AdventurerPassCardDataManager>.GetInstance().GetNeedExpToNextLv((int)DataManager<AdventurerPassCardDataManager>.GetInstance().CardLv);
			float value;
			if (needExpToNextLv == 0)
			{
				value = 1f;
			}
			else
			{
				value = DataManager<AdventurerPassCardDataManager>.GetInstance().CardExp / (float)needExpToNextLv;
			}
			this.mCardExpProcess.SafeSetValue(value);
			this.mBuyHighLvCard.CustomActive(DataManager<AdventurerPassCardDataManager>.GetInstance().GetPassCardType == AdventurerPassCardDataManager.PassCardType.Normal);
			this.mLockRoot.CustomActive(DataManager<AdventurerPassCardDataManager>.GetInstance().GetPassCardType == AdventurerPassCardDataManager.PassCardType.Normal);
			this.mOneKeyGetAward.SafeSetGray(!AdventurerPassCardFrame.CanOneKeyGetAwards(), true);
			this.mOneKeyGetAwardRedPoint.CustomActive(AdventurerPassCardFrame.CanOneKeyGetAwards());
			this.UpdateAwards();
			this.mExpAddByActiveDesc.SafeSetText(this.GetExpAddDesc());
			this.mBuyLv.SafeSetGray((ulong)DataManager<AdventurerPassCardDataManager>.GetInstance().CardLv >= (ulong)((long)DataManager<AdventurerPassCardDataManager>.GetInstance().GetAdventurerPassCardMaxLv(DataManager<AdventurerPassCardDataManager>.GetInstance().SeasonID)), true);
		}

		// Token: 0x0600C8AC RID: 51372 RVA: 0x0030CA44 File Offset: 0x0030AE44
		private void _OnOnCountValueChange(UIEvent uiEvent)
		{
		}

		// Token: 0x040073A0 RID: 29600
		private Dictionary<int, AdventurerPassCardDataManager.AwardItemInfo> awardItemInfo;

		// Token: 0x040073A1 RID: 29601
		private bool ensureElement;

		// Token: 0x040073A2 RID: 29602
		private Text mCardLv;

		// Token: 0x040073A3 RID: 29603
		private Text mCardExp;

		// Token: 0x040073A4 RID: 29604
		private Button mBuyLv;

		// Token: 0x040073A5 RID: 29605
		private Button mBuyHighLvCard;

		// Token: 0x040073A6 RID: 29606
		private Button mGetExpAward;

		// Token: 0x040073A7 RID: 29607
		private Text mSeasonText;

		// Token: 0x040073A8 RID: 29608
		private Text mSeasonTime;

		// Token: 0x040073A9 RID: 29609
		private Slider mCardExpProcess;

		// Token: 0x040073AA RID: 29610
		private Text mTodayActive;

		// Token: 0x040073AB RID: 29611
		private ComUIListScript awards;

		// Token: 0x040073AC RID: 29612
		private Button mShowAwards;

		// Token: 0x040073AD RID: 29613
		private GeAvatarRendererEx mGeAvatarRendererEx;

		// Token: 0x040073AE RID: 29614
		private Button mOneKeyGetAward;

		// Token: 0x040073AF RID: 29615
		private GameObject mLockRoot;

		// Token: 0x040073B0 RID: 29616
		private Button mExchange;

		// Token: 0x040073B1 RID: 29617
		private ShopNewMoneyItem firstMoney;

		// Token: 0x040073B2 RID: 29618
		private AdventurerPassCardAwardItem mHighawardItemShow;

		// Token: 0x040073B3 RID: 29619
		private Text mExpAddByActiveDesc;

		// Token: 0x040073B4 RID: 29620
		private GameObject mCanGotEffRoot;

		// Token: 0x040073B5 RID: 29621
		private Image mGou;

		// Token: 0x040073B6 RID: 29622
		private GameObject mNameTitleRoot;

		// Token: 0x040073B7 RID: 29623
		private Text mTitleName;

		// Token: 0x040073B8 RID: 29624
		private SpriteAniRenderChenghao mTitleAnimation;

		// Token: 0x040073B9 RID: 29625
		private Image mTitleAnimationImage;

		// Token: 0x040073BA RID: 29626
		private GameObject mOneKeyGetAwardRedPoint;

		// Token: 0x040073BB RID: 29627
		private Button mBtnLock;
	}
}
