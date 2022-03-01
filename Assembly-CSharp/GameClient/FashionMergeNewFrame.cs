using System;
using System.Collections.Generic;
using GamePool;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B30 RID: 6960
	internal class FashionMergeNewFrame : ClientFrame
	{
		// Token: 0x06011163 RID: 69987 RVA: 0x004E5F41 File Offset: 0x004E4341
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/FashionSmithShop/FashionMergeNewFrame";
		}

		// Token: 0x06011164 RID: 69988 RVA: 0x004E5F48 File Offset: 0x004E4348
		public static void CommandOpen(object argv)
		{
			bool flag = (bool)argv;
			if (flag)
			{
				if (DataManager<FashionMergeManager>.GetInstance().HasSkyFashion(DataManager<FashionMergeManager>.GetInstance().FashionPart))
				{
					DataManager<FashionMergeManager>.GetInstance().FashionPart = ItemTable.eSubType.ST_NONE;
				}
				if (DataManager<FashionMergeManager>.GetInstance().FashionPart == ItemTable.eSubType.ST_NONE)
				{
					DataManager<FashionMergeManager>.GetInstance().FashionPart = DataManager<FashionMergeManager>.GetInstance().GetDefaultFashionPart();
				}
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<FashionMergeNewFrame>(FrameLayer.Middle, argv, string.Empty);
		}

		// Token: 0x06011165 RID: 69989 RVA: 0x004E5FBC File Offset: 0x004E43BC
		public static void OpenLinkFrame(string strParam)
		{
			if (DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsTypeFuncLock(ServiceType.SERVICE_FASHION_MERGO))
			{
				return;
			}
			string[] array = strParam.Split(new char[]
			{
				'|'
			});
			int num = 0;
			int num2 = 0;
			int fashionPart = 12;
			ulong bindId = 0UL;
			int num3 = 0;
			if (array.Length == 5 && int.TryParse(array[0], out num) && int.TryParse(array[1], out num3) && int.TryParse(array[2], out num2) && int.TryParse(array[3], out fashionPart) && ulong.TryParse(array[4], out bindId))
			{
				bool flag = num == 1;
				if (flag)
				{
					if (DataManager<FashionMergeManager>.GetInstance().HasSkyFashion(DataManager<FashionMergeManager>.GetInstance().FashionPart))
					{
						DataManager<FashionMergeManager>.GetInstance().FashionPart = ItemTable.eSubType.ST_NONE;
					}
					if (DataManager<FashionMergeManager>.GetInstance().FashionPart == ItemTable.eSubType.ST_NONE)
					{
						DataManager<FashionMergeManager>.GetInstance().FashionPart = DataManager<FashionMergeManager>.GetInstance().GetDefaultFashionPart();
					}
					if (num2 != 10000)
					{
						DataManager<FashionMergeManager>.GetInstance().RecordNomalFashionType = (FashionType)num2;
					}
					DataManager<FashionMergeManager>.GetInstance().FashionType = (FashionType)num2;
				}
				else
				{
					DataManager<FashionMergeManager>.GetInstance().FashionPart = (ItemTable.eSubType)fashionPart;
					DataManager<FashionMergeManager>.GetInstance().FashionType = (FashionType)num2;
				}
				if (num3 == 0)
				{
					DataManager<FashionMergeManager>.GetInstance().FashionType = DataManager<FashionMergeManager>.GetInstance().RecordNomalFashionType;
				}
				FashionMergeNewFrameData fashionMergeNewFrameData = new FashionMergeNewFrameData();
				fashionMergeNewFrameData.bindId = bindId;
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<FashionMergeNewFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<FashionMergeNewFrame>(null, false);
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<FashionMergeNewFrame>(FrameLayer.Middle, fashionMergeNewFrameData, string.Empty);
			}
		}

		// Token: 0x06011166 RID: 69990 RVA: 0x004E613C File Offset: 0x004E453C
		protected sealed override void _OnOpenFrame()
		{
			if (DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsTypeFuncLock(ServiceType.SERVICE_FASHION_MERGO))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<FashionMergeNewFrame>(null, false);
				return;
			}
			this.data = (this.userData as FashionMergeNewFrameData);
			if (this.data == null)
			{
				this.data = new FashionMergeNewFrameData();
				this.data.bindId = 0UL;
				int fashionType = 0;
				int fashionPart = 12;
				DataManager<FashionMergeManager>.GetInstance().FashionPart = (ItemTable.eSubType)fashionPart;
				DataManager<FashionMergeManager>.GetInstance().FashionType = (FashionType)fashionType;
				Logger.LogErrorFormat("you should not open FashionMergeNewFrame by default,instead of calling OpenLinkFrame frame !!! to 郝晓亮 !!!", new object[0]);
			}
			base._AddButton("BG/Title/Close", delegate
			{
				this.frameMgr.CloseFrame<FashionMergeNewFrame>(this, false);
			});
			base._AddButton("ChangeMode", delegate
			{
				DataManager<FashionMergeManager>.GetInstance().FashionType = ((DataManager<FashionMergeManager>.GetInstance().FashionType != FashionType.FT_GOLD_SKY) ? FashionType.FT_GOLD_SKY : FashionType.FT_SKY);
				this._UpdateSkyItems();
				DataManager<FashionMergeManager>.GetInstance().ClearRedPoit();
			});
			base._AddButton("GoFashionBag", delegate
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<PackageNewFrame>(FrameLayer.Middle, EPackageOpenMode.Fashion, string.Empty);
				DataManager<FashionMergeManager>.GetInstance().ClearRedPoit();
			});
			this._InitSkySuit();
			this._InitNormalSuit();
			this._UpdateSkyItems();
			this._InitBindItem();
			if (DataManager<FashionMergeManager>.GetInstance().IsChangeSectionActivity(DataManager<FashionMergeManager>.GetInstance().FashionType))
			{
				this.m_FrameTypeStateCol.Key = this.mFrameActivity;
			}
			else
			{
				this.m_FrameTypeStateCol.Key = this.mFrameTypeNomal;
			}
			this._InitAutoEquipState();
			this.UpdateProbabilityAscensionRoot();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnNormalFashionModeChanged, new ClientEventSystem.UIEventHandler(this._OnNormalFashionModeChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnFashionMergeNotify, new ClientEventSystem.UIEventHandler(this._OnFashionMergeNotify));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnFashionSpecialFly, new ClientEventSystem.UIEventHandler(this._OnFashionSpecialFly));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnFashionAutoEquip, new ClientEventSystem.UIEventHandler(this._OnFashionAutoEquip));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityLimitTimeDataUpdate, new ClientEventSystem.UIEventHandler(this._OnLimitTimeDataUpdate));
		}

		// Token: 0x06011167 RID: 69991 RVA: 0x004E630C File Offset: 0x004E470C
		private void _UpdateSkyItems()
		{
			if (null != this.comSkyMode)
			{
				if (DataManager<FashionMergeManager>.GetInstance().FashionType == FashionType.FT_GOLD_SKY)
				{
					this.comSkyMode.Key = this.mKeyGoldSky;
				}
				else
				{
					this.comSkyMode.Key = this.mKeySky;
				}
			}
			if (null != this.mDataBinder)
			{
				this.mDataBinder.SetSkyMode(DataManager<FashionMergeManager>.GetInstance().FashionType);
				this.mDataBinder.SetSkyFashionPart(DataManager<FashionMergeManager>.GetInstance().FashionPart);
				this.mDataBinder.SetNormalFashionPart(DataManager<FashionMergeManager>.GetInstance().FashionPart);
				this.mDataBinder.SetSlotPart(DataManager<FashionMergeManager>.GetInstance().FashionPart);
				this.mDataBinder.SetSkySuitName();
			}
			this._LoadSkyDatas(DataManager<FashionMergeManager>.GetInstance().FashionType);
			if (null != this.mDataBinder)
			{
				this.mDataBinder.UpdateSkyStatus();
				this.mDataBinder.ForceUpdateSkyStatus();
				this.mDataBinder.UpdateWindProcess();
			}
		}

		// Token: 0x06011168 RID: 69992 RVA: 0x004E6413 File Offset: 0x004E4813
		private void _OnNormalFashionModeChanged(UIEvent uiEvent)
		{
			if (null != this.mDataBinder)
			{
				this.mDataBinder.SetNormalFashionPart(DataManager<FashionMergeManager>.GetInstance().FashionPart);
			}
		}

		// Token: 0x06011169 RID: 69993 RVA: 0x004E643B File Offset: 0x004E483B
		private void _OnFashionMergeNotify(UIEvent uiEvent)
		{
			if (null != this.mDataBinder)
			{
				this.mDataBinder.EnableMergeState();
				this.mDataBinder.UpdateSlotItems();
			}
		}

		// Token: 0x0601116A RID: 69994 RVA: 0x004E6464 File Offset: 0x004E4864
		private void _InitSkySuit()
		{
			int num = DataManager<FashionMergeManager>.GetInstance().SkySuitID;
			if (DataManager<FashionMergeManager>.GetInstance().GetFashionByKey(DataManager<FashionMergeManager>.GetInstance().FashionType, DataManager<PlayerBaseData>.GetInstance().JobTableID, num, ItemTable.eSubType.FASHION_HEAD) == 0)
			{
				num = 1;
				DataManager<FashionMergeManager>.GetInstance().SkySuitID = num;
			}
		}

		// Token: 0x0601116B RID: 69995 RVA: 0x004E64B4 File Offset: 0x004E48B4
		private void _InitNormalSuit()
		{
			int num = DataManager<FashionMergeManager>.GetInstance().NormalSuitID;
			if (DataManager<FashionMergeManager>.GetInstance().GetFashionByKey(DataManager<FashionMergeManager>.GetInstance().FashionType, DataManager<PlayerBaseData>.GetInstance().JobTableID, num, ItemTable.eSubType.FASHION_HEAD) == 0)
			{
				num = 1;
				DataManager<FashionMergeManager>.GetInstance().SkySuitID = num;
			}
		}

		// Token: 0x0601116C RID: 69996 RVA: 0x004E6501 File Offset: 0x004E4901
		private void _InitBindItem()
		{
			if (null != this.mDataBinder)
			{
				this.mDataBinder.SetBindItem(this.data.bindId);
			}
		}

		// Token: 0x0601116D RID: 69997 RVA: 0x004E652A File Offset: 0x004E492A
		private void _InitAutoEquipState()
		{
			this.autoEquipState = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.FASHION_MERGE_AUTO_EQUIP_STATE);
			if (this.autoEquipState == 0)
			{
				this.mAutoEquip.isOn = false;
			}
			else
			{
				this.mAutoEquip.isOn = true;
			}
		}

		// Token: 0x0601116E RID: 69998 RVA: 0x004E656C File Offset: 0x004E496C
		private void _LoadSkyDatas(FashionType eFashionType)
		{
			if (null == this.mDataBinder)
			{
				Logger.LogErrorFormat("mDataBinder is null !!", new object[0]);
				return;
			}
			List<int> list = ListPool<int>.Get();
			DataManager<FashionMergeManager>.GetInstance().GetFashionItemsByTypeAndOccu(eFashionType, DataManager<PlayerBaseData>.GetInstance().JobTableID, DataManager<FashionMergeManager>.GetInstance().SkySuitID, ref list);
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(list[i], string.Empty, string.Empty);
					if (tableItem != null)
					{
						ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(list[i]);
						if (commonItemTableDataByID != null)
						{
							this.mDataBinder.SetSlotItems(commonItemTableDataByID, new ComItem.OnItemClicked(this._OnItemClicked), tableItem.SubType);
						}
					}
				}
			}
			ListPool<int>.Release(list);
		}

		// Token: 0x0601116F RID: 69999 RVA: 0x004E6648 File Offset: 0x004E4A48
		private void _OnItemClicked(GameObject obj, ItemData item)
		{
			if (item != null && null != this.mDataBinder)
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (tableItem.SubType != ItemTable.eSubType.FASHION_HAIR)
					{
						this.mDataBinder.SetSkyFashionPart(tableItem.SubType);
						this.mDataBinder.SetNormalFashionPart(tableItem.SubType);
						this.mDataBinder.SetSlotPart(tableItem.SubType);
						DataManager<FashionMergeManager>.GetInstance().FashionPart = tableItem.SubType;
					}
					else if (!this.mDataBinder.IsWindUnLock())
					{
						if (DataManager<FashionMergeManager>.GetInstance().FashionType == FashionType.FT_SKY)
						{
							SystemNotifyManager.SysNotifyTextAnimation(TR.Value("fashion_wind_unlock_hint_sky_lock"), CommonTipsDesc.eShowMode.SI_UNIQUE);
						}
						else if (DataManager<FashionMergeManager>.GetInstance().FashionType == FashionType.FT_GOLD_SKY)
						{
							SystemNotifyManager.SysNotifyTextAnimation(TR.Value("fashion_wind_unlock_hint_gold_sky_lock"), CommonTipsDesc.eShowMode.SI_UNIQUE);
						}
					}
					else if (DataManager<FashionMergeManager>.GetInstance().FashionType == FashionType.FT_SKY)
					{
						SystemNotifyManager.SysNotifyTextAnimation(TR.Value("fashion_wind_unlock_hint_sky_unlock"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					}
					else if (DataManager<FashionMergeManager>.GetInstance().FashionType == FashionType.FT_GOLD_SKY)
					{
						SystemNotifyManager.SysNotifyTextAnimation(TR.Value("fashion_wind_unlock_hint_gold_sky_unlock"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					}
				}
			}
		}

		// Token: 0x06011170 RID: 70000 RVA: 0x004E6784 File Offset: 0x004E4B84
		private void _SetGoldSkyMode(bool bOpen)
		{
			bool flag = DataManager<FashionMergeManager>.GetInstance().FashionType == FashionType.FT_GOLD_SKY;
			if (bOpen != flag)
			{
				DataManager<FashionMergeManager>.GetInstance().FashionType = ((!bOpen) ? FashionType.FT_SKY : FashionType.FT_GOLD_SKY);
				this._UpdateSkyItems();
				DataManager<FashionMergeManager>.GetInstance().ClearRedPoit();
			}
		}

		// Token: 0x06011171 RID: 70001 RVA: 0x004E67D0 File Offset: 0x004E4BD0
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnNormalFashionModeChanged, new ClientEventSystem.UIEventHandler(this._OnNormalFashionModeChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnFashionMergeNotify, new ClientEventSystem.UIEventHandler(this._OnFashionMergeNotify));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnFashionSpecialFly, new ClientEventSystem.UIEventHandler(this._OnFashionSpecialFly));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnFashionAutoEquip, new ClientEventSystem.UIEventHandler(this._OnFashionAutoEquip));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityLimitTimeDataUpdate, new ClientEventSystem.UIEventHandler(this._OnLimitTimeDataUpdate));
			InvokeMethod.RemoveInvokeCall(this);
			this.data = null;
			if (null != this.mDataBinder)
			{
				this.mDataBinder.ClearSlotValues();
			}
		}

		// Token: 0x06011172 RID: 70002 RVA: 0x004E688D File Offset: 0x004E4C8D
		private void _OnFashionAutoEquip(UIEvent uiEvent)
		{
			if (this.autoEquipState == 1)
			{
				this.mDataBinder.TryAutoEquipFashion();
			}
		}

		// Token: 0x06011173 RID: 70003 RVA: 0x004E68A6 File Offset: 0x004E4CA6
		private void _OnLimitTimeDataUpdate(UIEvent uiEvent)
		{
			this.UpdateProbabilityAscensionRoot();
		}

		// Token: 0x06011174 RID: 70004 RVA: 0x004E68AE File Offset: 0x004E4CAE
		private void _OnShowTips(ItemData result)
		{
			if (result == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(result, null, 4, true, false, true);
		}

		// Token: 0x06011175 RID: 70005 RVA: 0x004E68C8 File Offset: 0x004E4CC8
		private void _OnFashionSpecialFly(UIEvent uiEvent)
		{
			ItemData data = uiEvent.Param3 as ItemData;
			if (data == null)
			{
				return;
			}
			FashionComposeSkyTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FashionComposeSkyTable>(data.TableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (null == this.mDataBinder)
			{
				return;
			}
			FashionType eTargetFashionType = (tableItem.Type != 1) ? FashionType.FT_GOLD_SKY : FashionType.FT_SKY;
			Vector3 zero = Vector3.zero;
			zero.x = (float)uiEvent.Param1;
			zero.y = (float)uiEvent.Param2;
			zero.z = 0f;
			bool flag = eTargetFashionType == DataManager<FashionMergeManager>.GetInstance().FashionType;
			if (DataManager<FashionMergeManager>.GetInstance().IsChangeSectionActivity(DataManager<FashionMergeManager>.GetInstance().FashionType))
			{
				flag = true;
			}
			ItemData itemWind = uiEvent.Param4 as ItemData;
			if (flag)
			{
				this.mDataBinder.FlyEffect2Slot(9, zero, (ItemTable.eSubType)data.SubType, this.mDataBinder.mFlyLength, delegate
				{
					if (this.mDataBinder.mOnFlyStart != null)
					{
						this.mDataBinder.mOnFlyStart.Invoke();
					}
				}, delegate
				{
					if (null != this.mDataBinder)
					{
						if (eTargetFashionType == FashionType.FT_GOLD_SKY)
						{
							this.mDataBinder.PlaySpecialSlotEffect((ItemTable.eSubType)data.SubType);
						}
						else
						{
							this.mDataBinder.PlayNormalSlotEffect((ItemTable.eSubType)data.SubType);
						}
						if ((itemWind == null && !DataManager<FashionMergeManager>.GetInstance().IsChangeSectionActivity(DataManager<FashionMergeManager>.GetInstance().FashionType)) || (DataManager<FashionMergeManager>.GetInstance().IsChangeSectionActivity(DataManager<FashionMergeManager>.GetInstance().FashionType) && !DataManager<FashionMergeManager>.GetInstance().ChangeFashionIsAllMerged))
						{
							this._LoadSkyDatas(DataManager<FashionMergeManager>.GetInstance().FashionType);
							if (null != this.mDataBinder)
							{
								this.mDataBinder.UpdateSkyStatus();
								this.mDataBinder.ForceUpdateSkyStatus();
								this.mDataBinder.UpdateWindProcess();
								this.mDataBinder.DisableFlyState();
							}
						}
						else
						{
							if (null != this.mDataBinder)
							{
								this.mDataBinder.UpdateSlotSkyStatus((ItemTable.eSubType)data.SubType);
								this.mDataBinder.ForceUpdateSkyStatus();
								this.mDataBinder.UpdateWindProcess();
							}
							if (null != this.mDataBinder.mEffectLoader)
							{
								this.mDataBinder.mEffectLoader.DeActiveEffect(10);
								this.mDataBinder.mEffectLoader.DeActiveEffect(11);
							}
							InvokeMethod.RemoveInvokeCall(this);
							InvokeMethod.Invoke(this, this.mDataBinder.mFadeLength, delegate()
							{
								if (null != this.mDataBinder.mEffectLoader)
								{
									if (this.mDataBinder.mOnFlightStart != null)
									{
										this.mDataBinder.mOnFlightStart.Invoke();
									}
									this.mDataBinder.mEffectLoader.LoadEffect(11);
									this.mDataBinder.mEffectLoader.ActiveEffect(11);
								}
							});
							InvokeMethod.Invoke(this, this.mDataBinder.mFadeLength + this.mDataBinder.mFlightLength, delegate()
							{
								if (null != this.mDataBinder.mEffectLoader)
								{
									this.mDataBinder.mEffectLoader.DeActiveEffect(11);
									this.mDataBinder.mEffectLoader.LoadEffect(10);
									this.mDataBinder.mEffectLoader.ActiveEffect(10);
								}
								this._LoadSkyDatas(DataManager<FashionMergeManager>.GetInstance().FashionType);
								if (null != this.mDataBinder)
								{
									this.mDataBinder.UpdateSkyStatus();
									this.mDataBinder.ForceUpdateSkyStatus();
									this.mDataBinder.UpdateWindProcess();
									this.mDataBinder.DisableFlyState();
								}
								Singleton<ClientSystemManager>.GetInstance().OpenFrame<FashionEquipFrame>(FrameLayer.Middle, new FashionEquipFrameData
								{
									eFashionType = DataManager<FashionMergeManager>.GetInstance().FashionType,
									Occu = DataManager<PlayerBaseData>.GetInstance().JobTableID,
									SuitID = DataManager<FashionMergeManager>.GetInstance().SkySuitID
								}, string.Empty);
							});
						}
					}
				});
			}
			else if (null != this.mDataBinder)
			{
				this.mDataBinder.FlyEffect(9, zero, this.mDataBinder.GetFlyFixedPosition(), this.mDataBinder.mFlyLength, delegate
				{
					if (this.mDataBinder.mOnFlyStart != null)
					{
						this.mDataBinder.mOnFlyStart.Invoke();
					}
				}, delegate
				{
					if (null != this.mDataBinder)
					{
						this.mDataBinder.DisableFlyState();
					}
					if (itemWind != null)
					{
						FashionType eFashionType = FashionType.FT_SKY;
						int suitID = 1;
						FashionComposeSkyTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<FashionComposeSkyTable>(itemWind.TableID, string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							eFashionType = ((tableItem2.Type != 1) ? FashionType.FT_GOLD_SKY : FashionType.FT_SKY);
							suitID = tableItem2.SuitID;
						}
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<FashionEquipFrame>(FrameLayer.Middle, new FashionEquipFrameData
						{
							eFashionType = eFashionType,
							Occu = DataManager<PlayerBaseData>.GetInstance().JobTableID,
							SuitID = suitID
						}, string.Empty);
					}
				});
			}
		}

		// Token: 0x06011176 RID: 70006 RVA: 0x004E6A5A File Offset: 0x004E4E5A
		private void ShowFashionPropertyFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<FashionMergeNewPropertyFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x06011177 RID: 70007 RVA: 0x004E6A6E File Offset: 0x004E4E6E
		private void UpdateProbabilityAscensionRoot()
		{
			this.mProbabilityAscension.CustomActive(DataManager<ActivityDataManager>.GetInstance().CheckFashionSynthesisActivityIsOpen());
		}

		// Token: 0x06011178 RID: 70008 RVA: 0x004E6A88 File Offset: 0x004E4E88
		protected sealed override void _bindExUI()
		{
			this.mAutoEquip = this.mBind.GetCom<Toggle>("autoEquip");
			if (null != this.mAutoEquip)
			{
				this.mAutoEquip.onValueChanged.AddListener(new UnityAction<bool>(this._onAutoEquipToggleValueChange));
			}
			this.mWatchInfo = this.mBind.GetCom<Button>("WatchInfo");
			if (this.mWatchInfo != null)
			{
				this.mWatchInfo.onClick.RemoveAllListeners();
				this.mWatchInfo.onClick.AddListener(new UnityAction(this.ShowFashionPropertyFrame));
			}
			this.mActivityWatchInfo = this.mBind.GetCom<Button>("ActivityWatchInfo");
			if (this.mActivityWatchInfo != null)
			{
				this.mActivityWatchInfo.onClick.RemoveAllListeners();
				this.mActivityWatchInfo.onClick.AddListener(new UnityAction(this.ShowActivityFashionPropertyFrame));
			}
			this.mProbabilityAscension = this.mBind.GetGameObject("ProbabilityAscension");
		}

		// Token: 0x06011179 RID: 70009 RVA: 0x004E6B94 File Offset: 0x004E4F94
		protected sealed override void _unbindExUI()
		{
			if (null != this.mAutoEquip)
			{
				this.mAutoEquip.onValueChanged.RemoveListener(new UnityAction<bool>(this._onAutoEquipToggleValueChange));
			}
			this.mAutoEquip = null;
			if (this.mWatchInfo != null)
			{
				this.mWatchInfo.onClick.RemoveAllListeners();
				this.mWatchInfo = null;
			}
			if (this.mActivityWatchInfo != null)
			{
				this.mActivityWatchInfo.onClick.RemoveAllListeners();
				this.mActivityWatchInfo = null;
			}
			this.mProbabilityAscension = null;
		}

		// Token: 0x0601117A RID: 70010 RVA: 0x004E6C2C File Offset: 0x004E502C
		private void _onAutoEquipToggleValueChange(bool changed)
		{
			if (changed)
			{
				if (this.autoEquipState != 1)
				{
					this.autoEquipState = 1;
					DataManager<FashionMergeManager>.GetInstance().SetAutoEquipState(1);
				}
				this.mDataBinder.TryAutoEquipFashion();
			}
			else if (this.autoEquipState != 0)
			{
				this.autoEquipState = 0;
				DataManager<FashionMergeManager>.GetInstance().SetAutoEquipState(0);
			}
		}

		// Token: 0x0601117B RID: 70011 RVA: 0x004E6C8A File Offset: 0x004E508A
		private void ShowActivityFashionPropertyFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ActivityFashionMergeNewPropertyFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0400B01B RID: 45083
		[UIControl("", typeof(ComFashionMergeDataBinder), 0)]
		private ComFashionMergeDataBinder mDataBinder;

		// Token: 0x0400B01C RID: 45084
		[UIControl("", typeof(StateController), 0)]
		private StateController comSkyMode;

		// Token: 0x0400B01D RID: 45085
		[UIControl("FrameType", typeof(StateController), 0)]
		private StateController m_FrameTypeStateCol;

		// Token: 0x0400B01E RID: 45086
		private string mKeySky = "sky";

		// Token: 0x0400B01F RID: 45087
		private string mKeyGoldSky = "gold_sky";

		// Token: 0x0400B020 RID: 45088
		private string mFrameTypeNomal = "Nomal";

		// Token: 0x0400B021 RID: 45089
		private string mFrameActivity = "ChangeSectionActivity";

		// Token: 0x0400B022 RID: 45090
		private FashionMergeNewFrameData data;

		// Token: 0x0400B023 RID: 45091
		private int autoEquipState;

		// Token: 0x0400B024 RID: 45092
		private Toggle mAutoEquip;

		// Token: 0x0400B025 RID: 45093
		private Button mWatchInfo;

		// Token: 0x0400B026 RID: 45094
		private Button mActivityWatchInfo;

		// Token: 0x0400B027 RID: 45095
		private GameObject mProbabilityAscension;
	}
}
