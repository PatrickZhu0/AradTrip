using System;
using System.Collections.Generic;
using System.Text;
using GamePool;
using Network;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001658 RID: 5720
	internal class GuildStoreFrame : ClientFrame
	{
		// Token: 0x0600E0F4 RID: 57588 RVA: 0x0039925D File Offset: 0x0039765D
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildStoreFrame";
		}

		// Token: 0x0600E0F5 RID: 57589 RVA: 0x00399264 File Offset: 0x00397664
		public static void CommandOpen(object argv = null)
		{
			GuildStoreFrame.ansyOpen(argv);
		}

		// Token: 0x0600E0F6 RID: 57590 RVA: 0x0039926C File Offset: 0x0039766C
		public static void ansyOpen(object argv = null)
		{
			if (!DataManager<GuildDataManager>.GetInstance().queried)
			{
				WorldGuildStorageListReq cmd = new WorldGuildStorageListReq();
				NetManager.Instance().SendCommand<WorldGuildStorageListReq>(ServerType.GATE_SERVER, cmd);
				DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildStorageListRes>(delegate(WorldGuildStorageListRes msgRet)
				{
					if (msgRet.result != 0U)
					{
						SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
					}
					else
					{
						DataManager<GuildDataManager>.GetInstance().queried = true;
						DataManager<GuildDataManager>.GetInstance().storeDatas.Clear();
						if (msgRet.items != null)
						{
							for (int i = 0; i < msgRet.items.Length; i++)
							{
								if (msgRet.items[i].num > 0)
								{
									ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)msgRet.items[i].dataId, 100, 0);
									if (itemData != null)
									{
										itemData.GUID = msgRet.items[i].uid;
										itemData.Count = (int)msgRet.items[i].num;
										itemData.StrengthenLevel = (int)msgRet.items[i].str;
										itemData.EquipType = (EEquipType)msgRet.items[i].equipType;
										DataManager<GuildDataManager>.GetInstance().storeDatas.Add(itemData);
									}
								}
							}
						}
						DataManager<GuildDataManager>.GetInstance().storeageCapacity = (int)msgRet.maxSize;
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildStoreFrame>(FrameLayer.Middle, null, string.Empty);
						if (msgRet.itemRecords != null)
						{
							for (int j = 0; j < msgRet.itemRecords.Length; j++)
							{
								GuildStorageOpRecord guildStorageOpRecord = msgRet.itemRecords[j];
								if (guildStorageOpRecord != null)
								{
									DataManager<GuildDataManager>.GetInstance().AddRecord(guildStorageOpRecord);
								}
							}
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnGuildSotrageOperationRecordsChanged, null, null, null, null);
						}
					}
				}, true, 15f, null);
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildStoreFrame>(FrameLayer.Middle, null, string.Empty);
			}
		}

		// Token: 0x0600E0F7 RID: 57591 RVA: 0x003992E4 File Offset: 0x003976E4
		private void _InitRecordsList()
		{
			this.comSotreRecordsList.Initialize();
			this.comSotreRecordsList.onBindItem = delegate(GameObject itemObject)
			{
				ComSotrageOperateRecord component = itemObject.GetComponent<ComSotrageOperateRecord>();
				if (null != component)
				{
					component.OnCreate();
				}
				return component;
			};
			this.comSotreRecordsList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (null != item && item.m_index >= 0 && item.m_index < DataManager<GuildDataManager>.GetInstance().GuildStorageOperationRecords.Count)
				{
					ComSotrageOperateRecord comSotrageOperateRecord = item.gameObjectBindScript as ComSotrageOperateRecord;
					if (null != comSotrageOperateRecord)
					{
						int index = DataManager<GuildDataManager>.GetInstance().GuildStorageOperationRecords.Count - 1 - item.m_index;
						comSotrageOperateRecord.OnItemVisible(DataManager<GuildDataManager>.GetInstance().GuildStorageOperationRecords[index]);
					}
				}
			};
		}

		// Token: 0x0600E0F8 RID: 57592 RVA: 0x0039934C File Offset: 0x0039774C
		private void _InitGeneratorSetting()
		{
			Vector2 vector;
			vector..ctor(this.comSuperLinkText.rectTransform.rect.size.x, 0f);
			TextGenerationSettings generationSettings = this.comSuperLinkText.GetGenerationSettings(vector);
			this.textGeneratorSetting.font = generationSettings.font;
			this.textGeneratorSetting.fontSize = generationSettings.fontSize;
			this.textGeneratorSetting.fontStyle = generationSettings.fontStyle;
			this.textGeneratorSetting.lineSpacing = generationSettings.lineSpacing;
			this.textGeneratorSetting.horizontalOverflow = 0;
			this.textGeneratorSetting.verticalOverflow = 1;
			this.textGeneratorSetting.alignByGeometry = false;
			this.textGeneratorSetting.resizeTextForBestFit = generationSettings.resizeTextForBestFit;
			this.textGeneratorSetting.richText = generationSettings.richText;
			this.textGeneratorSetting.scaleFactor = 1f;
			this.textGeneratorSetting.updateBounds = generationSettings.updateBounds;
			this.textGeneratorSetting.generationExtents = vector;
		}

		// Token: 0x0600E0F9 RID: 57593 RVA: 0x00399450 File Offset: 0x00397850
		private void _RefreshStorageOperationRecords()
		{
			List<Vector2> list = ListPool<Vector2>.Get();
			for (int i = 0; i < DataManager<GuildDataManager>.GetInstance().GuildStorageOperationRecords.Count; i++)
			{
				int index = DataManager<GuildDataManager>.GetInstance().GuildStorageOperationRecords.Count - 1 - i;
				SotrageOperateRecordData sotrageOperateRecordData = DataManager<GuildDataManager>.GetInstance().GuildStorageOperationRecords[index] as SotrageOperateRecordData;
				if (!sotrageOperateRecordData.measured)
				{
					StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
					LinkParse._TryToken(stringBuilder, sotrageOperateRecordData.value, 0, null, LinkParse.EmotionSizeType.EST_72);
					string text = stringBuilder.ToString();
					StringBuilderCache.Release(stringBuilder);
					float preferredHeight = this.cachedTextGenerator.GetPreferredHeight(text, this.textGeneratorSetting);
					float x = this.textGeneratorSetting.generationExtents.x;
					sotrageOperateRecordData.h = preferredHeight;
					sotrageOperateRecordData.w = x;
				}
				list.Add(new Vector2(sotrageOperateRecordData.w, sotrageOperateRecordData.h));
			}
			this.comSotreRecordsList.SetElementAmount(DataManager<GuildDataManager>.GetInstance().GuildStorageOperationRecords.Count, list);
			ListPool<Vector2>.Release(list);
		}

		// Token: 0x0600E0FA RID: 57594 RVA: 0x00399554 File Offset: 0x00397954
		protected override void _OnOpenFrame()
		{
			base._AddButton("SettingRoot/Ctrls/BtnSetting", new UnityAction(this._OnClickSetting));
			base._AddButton("SettingRoot/Ctrls/BtnClear", new UnityAction(this._OnClickClear));
			base._AddButton("SettingRoot/Ctrls/BtnShop", new UnityAction(this._OnGotoShop));
			base._AddButton("SettingRoot/Ctrls/BtnContribute", new UnityAction(this._OnClickContribute));
			base._AddButton("Close", delegate
			{
				this.frameMgr.CloseFrame<GuildStoreFrame>(this, false);
			});
			base._AddButton("AwardRoot/BtnAward", new UnityAction(this._OnClickAward));
			this._InitGeneratorSetting();
			this._InitRecordsList();
			this._RefreshStorageOperationRecords();
			this._UpdateButtonStatus();
			this._UpdateStatus();
			this._RefreshGuildItems();
			this._UpdateSpace();
			this._UpdateRecordHead();
			this._UpdateClearCtrl();
			this._UpdateContributeCtrl();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildBattleStateChanged, new ClientEventSystem.UIEventHandler(this._OnGuildBattleStateChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnGuildHouseItemAdd, new ClientEventSystem.UIEventHandler(this._OnStorageItemAdd));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnGuildHouseItemRemoved, new ClientEventSystem.UIEventHandler(this._OnStorageRemoved));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnGuildHouseItemUpdate, new ClientEventSystem.UIEventHandler(this._OnStorageItemUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnGuildSotrageOperationRecordsChanged, new ClientEventSystem.UIEventHandler(this._OnGuildSotrageOperationRecordsChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildLotteryResultRes, new ClientEventSystem.UIEventHandler(this._OnAwardStateChanged));
			GuildDataManager instance = DataManager<GuildDataManager>.GetInstance();
			instance.onGuildPowerChanged = (GuildDataManager.OnGuildPowerChanged)Delegate.Combine(instance.onGuildPowerChanged, new GuildDataManager.OnGuildPowerChanged(this._OnGuildPowerChanged));
			this._UpdateLotteryLeftTime();
			if (this.storeItemList != null)
			{
				this.storeItemList.verticalNormalizedPosition = 1f;
			}
		}

		// Token: 0x0600E0FB RID: 57595 RVA: 0x00399718 File Offset: 0x00397B18
		private void _SortStorageItem()
		{
			this.m_akHouseItemDatas.ActiveObjects.Sort(delegate(GuildHouseItem x, GuildHouseItem y)
			{
				if (x.Value.itemData == null != (y.Value.itemData == null))
				{
					return (x.Value.itemData != null) ? -1 : 1;
				}
				if (x.Value.itemData == null)
				{
					return 0;
				}
				if (x.Value.itemData.Quality != y.Value.itemData.Quality)
				{
					return y.Value.itemData.Quality - x.Value.itemData.Quality;
				}
				if (x.Value.itemData.GUID < y.Value.itemData.GUID)
				{
					return -1;
				}
				if (x.Value.itemData.GUID == y.Value.itemData.GUID)
				{
					return 0;
				}
				return 1;
			});
			for (int i = 0; i < this.m_akHouseItemDatas.ActiveObjects.Count; i++)
			{
				this.m_akHouseItemDatas.ActiveObjects[i].SetSiblingIndex(1 + i);
			}
		}

		// Token: 0x0600E0FC RID: 57596 RVA: 0x0039978C File Offset: 0x00397B8C
		private void _OnStorageItemAdd(UIEvent uiEvent)
		{
			ItemData itemData = uiEvent.Param1 as ItemData;
			if (itemData != null)
			{
				GuildHouseItem guildHouseItem = this.m_akHouseItemDatas.Find((GuildHouseItem x) => x.Value.itemData == null);
				if (guildHouseItem != null)
				{
					guildHouseItem.OnRefresh(new object[]
					{
						new GuildHouseItemData
						{
							itemData = itemData
						}
					});
				}
				else
				{
					this.m_akHouseItemDatas.Create(new object[]
					{
						this.goParent,
						this.goPrefab,
						new GuildHouseItemData
						{
							itemData = itemData
						},
						false
					});
				}
			}
			this._SortStorageItem();
			this._UpdateSpace();
		}

		// Token: 0x0600E0FD RID: 57597 RVA: 0x00399848 File Offset: 0x00397C48
		private void _OnStorageRemoved(UIEvent uiEvent)
		{
			ItemData itemData = uiEvent.Param1 as ItemData;
			if (itemData != null)
			{
				GuildHouseItem guildHouseItem = this.m_akHouseItemDatas.Find((GuildHouseItem x) => x != null && x.Value != null && x.Value.itemData != null && itemData.GUID == x.Value.itemData.GUID);
				if (guildHouseItem != null)
				{
					guildHouseItem.OnRefresh(new object[]
					{
						new GuildHouseItemData
						{
							itemData = null
						}
					});
				}
			}
			this._SortStorageItem();
			this._UpdateSpace();
		}

		// Token: 0x0600E0FE RID: 57598 RVA: 0x003998C0 File Offset: 0x00397CC0
		private void _OnStorageItemUpdate(UIEvent uiEvent)
		{
			ItemData itemData = uiEvent.Param1 as ItemData;
			if (itemData != null)
			{
				GuildHouseItem guildHouseItem = this.m_akHouseItemDatas.Find((GuildHouseItem x) => x != null && x.Value != null && x.Value.itemData != null && itemData.GUID == x.Value.itemData.GUID);
				if (guildHouseItem != null)
				{
					guildHouseItem.OnRefresh(new object[]
					{
						new GuildHouseItemData
						{
							itemData = itemData
						}
					});
				}
			}
			this._UpdateSpace();
		}

		// Token: 0x0600E0FF RID: 57599 RVA: 0x00399935 File Offset: 0x00397D35
		private void _OnGuildSotrageOperationRecordsChanged(UIEvent uiEvent)
		{
			this._RefreshStorageOperationRecords();
		}

		// Token: 0x0600E100 RID: 57600 RVA: 0x0039993D File Offset: 0x00397D3D
		private void _OnAwardStateChanged(UIEvent uiEvent)
		{
			this._UpdateStatus();
		}

		// Token: 0x0600E101 RID: 57601 RVA: 0x00399945 File Offset: 0x00397D45
		private void _OnGuildBattleStateChanged(UIEvent uiEvent)
		{
			this._UpdateStatus();
		}

		// Token: 0x0600E102 RID: 57602 RVA: 0x00399950 File Offset: 0x00397D50
		private void _UpdateStatus()
		{
			if (null != this.comStatus)
			{
				EGuildBattleState guildBattleState = DataManager<GuildDataManager>.GetInstance().GetGuildBattleState();
				if (guildBattleState == EGuildBattleState.LuckyDraw)
				{
					if (DataManager<GuildDataManager>.GetInstance().HasGuildBattleLotteryed())
					{
						this.comStatus.Key = "award_passed";
					}
					else
					{
						this.comStatus.Key = "award";
					}
				}
				else
				{
					this.comStatus.Key = "normal";
				}
			}
		}

		// Token: 0x0600E103 RID: 57603 RVA: 0x003999C9 File Offset: 0x00397DC9
		private void _UpdateLotteryLeftTime()
		{
			this.m_repeatCallLeftTime = Singleton<ClientSystemManager>.GetInstance().delayCaller.RepeatCall(1000, delegate
			{
				this._UpdateLeftTime();
			}, 9999999, true);
		}

		// Token: 0x0600E104 RID: 57604 RVA: 0x003999F8 File Offset: 0x00397DF8
		private void _UpdateLeftTime()
		{
			if (this.mLotteryLeftTime == null)
			{
				return;
			}
			if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleState() == EGuildBattleState.LuckyDraw)
			{
				uint num = DataManager<GuildDataManager>.GetInstance().GetGuildBattleStateEndTime() - DataManager<TimeManager>.GetInstance().GetServerTime();
				if (num > 0U)
				{
					this.mLotteryLeftTime.text = "抽奖剩余时间  " + Function.GetLeftTime((int)DataManager<GuildDataManager>.GetInstance().GetGuildBattleStateEndTime(), (int)DataManager<TimeManager>.GetInstance().GetServerTime(), ShowtimeType.OnlineGift);
					this.mLotteryLeftTime.gameObject.CustomActive(true);
				}
				else
				{
					this.mLotteryLeftTime.gameObject.CustomActive(false);
				}
			}
			else
			{
				this.mLotteryLeftTime.gameObject.CustomActive(false);
			}
		}

		// Token: 0x0600E105 RID: 57605 RVA: 0x00399AB0 File Offset: 0x00397EB0
		private void _UpdateSpace()
		{
			if (null != this.space)
			{
				this.space.text = string.Format("{0}/{1}", DataManager<GuildDataManager>.GetInstance().storeDatas.Count, DataManager<GuildDataManager>.GetInstance().storeageCapacity);
			}
		}

		// Token: 0x0600E106 RID: 57606 RVA: 0x00399B08 File Offset: 0x00397F08
		private void _UpdateContributeCtrl()
		{
			GuildPost serverDuty = (GuildPost)DataManager<GuildDataManager>.GetInstance().GetServerDuty(DataManager<PlayerBaseData>.GetInstance().eGuildDuty);
			bool bActive = serverDuty >= DataManager<GuildDataManager>.GetInstance().contributePower;
			this.goContribute.CustomActive(bActive);
		}

		// Token: 0x0600E107 RID: 57607 RVA: 0x00399B48 File Offset: 0x00397F48
		private void _UpdateClearCtrl()
		{
			GuildPost serverDuty = (GuildPost)DataManager<GuildDataManager>.GetInstance().GetServerDuty(DataManager<PlayerBaseData>.GetInstance().eGuildDuty);
			bool bActive = serverDuty >= DataManager<GuildDataManager>.GetInstance().clearPower;
			this.goClear.CustomActive(bActive);
		}

		// Token: 0x0600E108 RID: 57608 RVA: 0x00399B87 File Offset: 0x00397F87
		private void _OnGuildPowerChanged(PowerSettingType ePowerSettingType, int iPowerValue)
		{
			switch (ePowerSettingType)
			{
			case PowerSettingType.PST_WIN_POWER:
			case PowerSettingType.PST_LOSE_POWER:
				this._UpdateRecordHead();
				break;
			case PowerSettingType.PST_CONTRIBUTE_POWER:
				this._UpdateContributeCtrl();
				break;
			case PowerSettingType.PST_DELETE_POWER:
				this._UpdateClearCtrl();
				break;
			}
		}

		// Token: 0x0600E109 RID: 57609 RVA: 0x00399BC8 File Offset: 0x00397FC8
		private void _UpdateRecordHead()
		{
			if (null != this.recordHead)
			{
				this.recordHead.text = TR.Value("guild_store_house_award_hint", DataManager<GuildDataManager>.GetInstance().winPower, DataManager<GuildDataManager>.GetInstance().losePower);
			}
		}

		// Token: 0x0600E10A RID: 57610 RVA: 0x00399C1C File Offset: 0x0039801C
		private void _UpdateButtonStatus()
		{
			EGuildDuty eGuildDuty = DataManager<PlayerBaseData>.GetInstance().eGuildDuty;
			this.goSetting.CustomActive(eGuildDuty == EGuildDuty.Leader);
			this.goClear.CustomActive(eGuildDuty >= EGuildDuty.Elder);
		}

		// Token: 0x0600E10B RID: 57611 RVA: 0x00399C58 File Offset: 0x00398058
		private void _RefreshGuildItems()
		{
			this.goPrefab.CustomActive(false);
			this.m_akHouseItemDatas.RecycleAllObject();
			List<ItemData> storeDatas = DataManager<GuildDataManager>.GetInstance().storeDatas;
			storeDatas.Sort(delegate(ItemData x, ItemData y)
			{
				if (x.Quality != y.Quality)
				{
					return y.Quality - x.Quality;
				}
				if (x.GUID < y.GUID)
				{
					return -1;
				}
				if (x.GUID == y.GUID)
				{
					return 0;
				}
				return 1;
			});
			int storeageCapacity = DataManager<GuildDataManager>.GetInstance().storeageCapacity;
			for (int i = 0; i < storeageCapacity; i++)
			{
				if (i < storeDatas.Count)
				{
					ItemData itemData = storeDatas[i];
					this.m_akHouseItemDatas.Create(new object[]
					{
						this.goParent,
						this.goPrefab,
						new GuildHouseItemData
						{
							itemData = itemData
						},
						false
					});
				}
				else
				{
					this.m_akHouseItemDatas.Create(new object[]
					{
						this.goParent,
						this.goPrefab,
						new GuildHouseItemData
						{
							itemData = null
						},
						false
					});
				}
			}
			this._SortStorageItem();
		}

		// Token: 0x0600E10C RID: 57612 RVA: 0x00399D68 File Offset: 0x00398168
		private void _OnClickSetting()
		{
			if (DataManager<PlayerBaseData>.GetInstance().eGuildDuty != EGuildDuty.Leader)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_store_house_setting_need_power"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			GuildStoreHousePowerSettingFrameData argv = new GuildStoreHousePowerSettingFrameData
			{
				toggle0s = new List<int>
				{
					0,
					30,
					50,
					80,
					100
				},
				toggle1s = new List<int>
				{
					0,
					30,
					50,
					80,
					100
				}
			};
			GuildStoreHousePowerSettingFrame.CommandOpen(argv);
		}

		// Token: 0x0600E10D RID: 57613 RVA: 0x00399E0C File Offset: 0x0039820C
		private void _OnClickClear()
		{
			EGuildDuty eGuildDuty = DataManager<PlayerBaseData>.GetInstance().eGuildDuty;
			GuildPost serverDuty = (GuildPost)DataManager<GuildDataManager>.GetInstance().GetServerDuty(eGuildDuty);
			if (serverDuty < DataManager<GuildDataManager>.GetInstance().clearPower)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_store_house_clear_need_power"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			GuildStoreHouseClearFrame.CommandOpen(GuildStoreHouseClearFrame.ReadyStoreRemoveData());
		}

		// Token: 0x0600E10E RID: 57614 RVA: 0x00399E5B File Offset: 0x0039825B
		private void _OnGotoShop()
		{
			this.frameMgr.OpenFrame<GuildStoreShopFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600E10F RID: 57615 RVA: 0x00399E70 File Offset: 0x00398270
		private void _OnClickContribute()
		{
			EGuildDuty eGuildDuty = DataManager<PlayerBaseData>.GetInstance().eGuildDuty;
			GuildPost serverDuty = (GuildPost)DataManager<GuildDataManager>.GetInstance().GetServerDuty(eGuildDuty);
			if (serverDuty < DataManager<GuildDataManager>.GetInstance().contributePower)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_store_house_store_need_power"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			GuildStoreHouseClearFrame.CommandOpen(GuildStoreHouseClearFrame.ReadyStoreAddData());
		}

		// Token: 0x0600E110 RID: 57616 RVA: 0x00399EC0 File Offset: 0x003982C0
		private void _OnClickAward()
		{
			EGuildBattleState guildBattleState = DataManager<GuildDataManager>.GetInstance().GetGuildBattleState();
			if (guildBattleState != EGuildBattleState.LuckyDraw)
			{
				Logger.LogErrorFormat("battle state is not LuckyDraw !", new object[0]);
				return;
			}
			DataManager<GuildDataManager>.GetInstance().SendGuildBattleLotteryReq();
		}

		// Token: 0x0600E111 RID: 57617 RVA: 0x00399EFC File Offset: 0x003982FC
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildBattleStateChanged, new ClientEventSystem.UIEventHandler(this._OnGuildBattleStateChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnGuildHouseItemAdd, new ClientEventSystem.UIEventHandler(this._OnStorageItemAdd));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnGuildHouseItemRemoved, new ClientEventSystem.UIEventHandler(this._OnStorageRemoved));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnGuildHouseItemUpdate, new ClientEventSystem.UIEventHandler(this._OnStorageItemUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnGuildSotrageOperationRecordsChanged, new ClientEventSystem.UIEventHandler(this._OnGuildSotrageOperationRecordsChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildLotteryResultRes, new ClientEventSystem.UIEventHandler(this._OnAwardStateChanged));
			GuildDataManager instance = DataManager<GuildDataManager>.GetInstance();
			instance.onGuildPowerChanged = (GuildDataManager.OnGuildPowerChanged)Delegate.Remove(instance.onGuildPowerChanged, new GuildDataManager.OnGuildPowerChanged(this._OnGuildPowerChanged));
			this.m_akHouseItemDatas.DestroyAllObjects();
			if (null != this.comSotreRecordsList)
			{
				this.comSotreRecordsList.onBindItem = null;
				this.comSotreRecordsList.onItemVisiable = null;
				this.comSotreRecordsList = null;
			}
			this.comSuperLinkText = null;
			Singleton<ClientSystemManager>.GetInstance().delayCaller.StopItem(this.m_repeatCallLeftTime);
		}

		// Token: 0x0600E112 RID: 57618 RVA: 0x0039A028 File Offset: 0x00398428
		protected override void _bindExUI()
		{
			this.mLotteryLeftTime = this.mBind.GetCom<Text>("LotteryLeftTime");
			this.storeItemList = this.mBind.GetCom<ScrollRect>("storeItemList");
		}

		// Token: 0x0600E113 RID: 57619 RVA: 0x0039A056 File Offset: 0x00398456
		protected override void _unbindExUI()
		{
			this.mLotteryLeftTime = null;
			this.storeItemList = null;
		}

		// Token: 0x040085D5 RID: 34261
		private DelayCallUnitHandle m_repeatCallLeftTime;

		// Token: 0x040085D6 RID: 34262
		[UIObject("SettingRoot/Ctrls/BtnSetting")]
		private GameObject goSetting;

		// Token: 0x040085D7 RID: 34263
		[UIObject("SettingRoot/Ctrls/BtnClear")]
		private GameObject goClear;

		// Token: 0x040085D8 RID: 34264
		[UIObject("SettingRoot/Ctrls/BtnContribute")]
		private GameObject goContribute;

		// Token: 0x040085D9 RID: 34265
		[UIControl("", typeof(StateController), 0)]
		private StateController comStatus;

		// Token: 0x040085DA RID: 34266
		[UIControl("Space", typeof(Text), 0)]
		private Text space;

		// Token: 0x040085DB RID: 34267
		[UIControl("RecordHead", typeof(Text), 0)]
		private Text recordHead;

		// Token: 0x040085DC RID: 34268
		[UIControl("Records", typeof(ComUIListScript), 0)]
		private ComUIListScript comSotreRecordsList;

		// Token: 0x040085DD RID: 34269
		[UIControl("Records/Scroll View/Viewport/Content/Prefab/Record/Text", typeof(NewSuperLinkText), 0)]
		private NewSuperLinkText comSuperLinkText;

		// Token: 0x040085DE RID: 34270
		private TextGenerator cachedTextGenerator = new TextGenerator(256);

		// Token: 0x040085DF RID: 34271
		private TextGenerationSettings textGeneratorSetting = default(TextGenerationSettings);

		// Token: 0x040085E0 RID: 34272
		[UIObject("middleback/Goods/Scroll View/Viewport/Content")]
		private GameObject goParent;

		// Token: 0x040085E1 RID: 34273
		[UIObject("middleback/Goods/Scroll View/Viewport/Content/Prefab")]
		private GameObject goPrefab;

		// Token: 0x040085E2 RID: 34274
		private CachedObjectListManager<GuildHouseItem> m_akHouseItemDatas = new CachedObjectListManager<GuildHouseItem>();

		// Token: 0x040085E3 RID: 34275
		private Text mLotteryLeftTime;

		// Token: 0x040085E4 RID: 34276
		private ScrollRect storeItemList;
	}
}
