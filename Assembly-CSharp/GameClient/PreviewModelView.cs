using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200159A RID: 5530
	public class PreviewModelView : MonoBehaviour, IDisposable
	{
		// Token: 0x0600D84A RID: 55370 RVA: 0x00361148 File Offset: 0x0035F548
		private void MoveOffset(GameObject obj, int ix, int iy)
		{
			if (obj == null)
			{
				return;
			}
			RectTransform component = obj.GetComponent<RectTransform>();
			Vector3 localPosition = default(Vector3);
			localPosition = component.localPosition;
			localPosition.x += (float)ix;
			localPosition.y += (float)iy;
			obj.transform.localPosition = localPosition;
		}

		// Token: 0x0600D84B RID: 55371 RVA: 0x003611A4 File Offset: 0x0035F5A4
		private void Awake()
		{
			if (this.mCloseBtn != null)
			{
				this.mCloseBtn.onClick.RemoveAllListeners();
				this.mCloseBtn.onClick.AddListener(delegate()
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<PreviewModelFrame>(null, false);
				});
			}
			if (this.mLeftArrowBtn != null)
			{
				this.mLeftArrowBtn.onClick.RemoveAllListeners();
				this.mLeftArrowBtn.onClick.AddListener(new UnityAction(this.OnLeftArrowClick));
			}
			if (this.mRightArrowBtn != null)
			{
				this.mRightArrowBtn.onClick.RemoveAllListeners();
				this.mRightArrowBtn.onClick.AddListener(new UnityAction(this.OnRightArrowClick));
			}
			this.showItemAttr.SafeSetOnClickListener(delegate
			{
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.mPreViewDataModel.preViewItemList[this.mCurrentSelectIndex].itemId, 100, 0);
				ItemTipData itemTipData = new ItemTipData();
				itemTipData.item = itemData;
				itemTipData.itemSuitObj = DataManager<EquipSuitDataManager>.GetInstance().GetSelfEquipSuitObj(itemData.SuitID);
				itemTipData.compareItem = null;
				itemTipData.compareItemSuitObj = null;
				itemTipData.textAnchor = 4;
				itemTipData.funcs = null;
				itemTipData.IsForceCloseModelAvatar = true;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ItemTipFrame>(this.itemTipRoot, itemTipData, "ShowAttrTip");
				this.MoveOffset(this.actorPos, -400, 0);
				this.MoveOffset(this.mName.gameObject, -400, 0);
				this.MoveOffset(this.mAniImage.gameObject, -400, 0);
				this.showItemAttr.CustomActive(false);
				this.closeShowItemAttr.CustomActive(true);
				this.mLeftArrowBtn.CustomActive(false);
				this.mRightArrowBtn.CustomActive(false);
				this.mPreViewItemList.CustomActive(false);
				this.mCloseBtn.CustomActive(false);
			});
			this.closeShowItemAttr.SafeSetOnClickListener(delegate
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame("ShowAttrTip");
				this.MoveOffset(this.actorPos, 400, 0);
				this.MoveOffset(this.mName.gameObject, 400, 0);
				this.MoveOffset(this.mAniImage.gameObject, 400, 0);
				this.showItemAttr.CustomActive(true);
				this.closeShowItemAttr.CustomActive(false);
				this.mPreViewItemList.CustomActive(true);
				this.mCloseBtn.CustomActive(true);
				this.UpdateViewShowInfo();
			});
		}

		// Token: 0x0600D84C RID: 55372 RVA: 0x003612A8 File Offset: 0x0035F6A8
		private void OnLeftArrowClick()
		{
			if (this.mCurrentSelectIndex < 0 || this.mCurrentSelectIndex >= this.mPreViewDataModel.preViewItemList.Count)
			{
				return;
			}
			this.mCurrentSelectIndex--;
			this.UpdateViewShowInfo();
			this.UpdateAvatar(this.mPreViewDataModel.preViewItemList[this.mCurrentSelectIndex]);
			if (this.mPreViewDataModel.isCreatItem)
			{
				this.SelectElement();
			}
		}

		// Token: 0x0600D84D RID: 55373 RVA: 0x00361324 File Offset: 0x0035F724
		private void OnRightArrowClick()
		{
			if (this.mCurrentSelectIndex < 0 || this.mCurrentSelectIndex >= this.mPreViewDataModel.preViewItemList.Count)
			{
				return;
			}
			this.mCurrentSelectIndex++;
			this.UpdateViewShowInfo();
			this.UpdateAvatar(this.mPreViewDataModel.preViewItemList[this.mCurrentSelectIndex]);
			if (this.mPreViewDataModel.isCreatItem)
			{
				this.SelectElement();
			}
		}

		// Token: 0x0600D84E RID: 55374 RVA: 0x003613A0 File Offset: 0x0035F7A0
		private void Update()
		{
			if (this.isInitialize && this.mGeAvatarRendererEx != null)
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

		// Token: 0x0600D84F RID: 55375 RVA: 0x00361534 File Offset: 0x0035F934
		public void InitView(PreViewDataModel preViewData)
		{
			this.mPreViewDataModel = preViewData;
			this.isInitialize = true;
			if (this.mPreViewDataModel == null)
			{
				return;
			}
			if (this.mPreViewDataModel.preViewItemList == null || this.mPreViewDataModel.preViewItemList.Count <= 0)
			{
				return;
			}
			this.InitPreViewItemList();
			this.UpdateViewShowInfo();
			if (this.mPreViewDataModel.preViewItemList.Count > 0)
			{
				this.UpdateAvatar(this.mPreViewDataModel.preViewItemList[this.mCurrentSelectIndex]);
			}
		}

		// Token: 0x0600D850 RID: 55376 RVA: 0x003615C0 File Offset: 0x0035F9C0
		private void InitPreViewItemList()
		{
			if (this.showItemAttr != null)
			{
				this.showItemAttr.CustomActive(this.mPreViewDataModel.isCreatItem);
			}
			if (this.mPreViewDataModel.isCreatItem && this.mPreViewItemList != null)
			{
				this.mPreViewItemList.Initialize();
				ComUIListScript comUIListScript = this.mPreViewItemList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mPreViewItemList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mPreViewItemList;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.mPreViewItemList;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Combine(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangeDisplayDelegate));
				this.mPreViewItemList.SetElementAmount(this.mPreViewDataModel.preViewItemList.Count);
				this.SelectElement();
			}
		}

		// Token: 0x0600D851 RID: 55377 RVA: 0x003616E0 File Offset: 0x0035FAE0
		private void SelectElement()
		{
			if (this.mCurrentSelectIndex < 0 || this.mCurrentSelectIndex >= this.mPreViewDataModel.preViewItemList.Count)
			{
				return;
			}
			if (this.mPreViewItemList != null)
			{
				this.mPreViewItemList.SelectElement(this.mCurrentSelectIndex, true);
			}
		}

		// Token: 0x0600D852 RID: 55378 RVA: 0x00361738 File Offset: 0x0035FB38
		private PreviewItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<PreviewItem>();
		}

		// Token: 0x0600D853 RID: 55379 RVA: 0x00361740 File Offset: 0x0035FB40
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			PreviewItem previewItem = item.gameObjectBindScript as PreviewItem;
			if (previewItem != null && item.m_index >= 0 && item.m_index < this.mPreViewDataModel.preViewItemList.Count)
			{
				previewItem.OnItemVisiable(item.m_index, this.mPreViewDataModel.preViewItemList[item.m_index]);
			}
		}

		// Token: 0x0600D854 RID: 55380 RVA: 0x003617B0 File Offset: 0x0035FBB0
		private void OnItemSelectedDelegate(ComUIListElementScript item)
		{
			PreviewItem previewItem = item.gameObjectBindScript as PreviewItem;
			if (previewItem != null)
			{
				this.mCurrentSelectIndex = previewItem.Index;
				this.UpdateViewShowInfo();
				this.UpdateAvatar(this.mPreViewDataModel.preViewItemList[this.mCurrentSelectIndex]);
			}
		}

		// Token: 0x0600D855 RID: 55381 RVA: 0x00361804 File Offset: 0x0035FC04
		private void OnItemChangeDisplayDelegate(ComUIListElementScript item, bool bSelected)
		{
			PreviewItem previewItem = item.gameObjectBindScript as PreviewItem;
			if (previewItem != null)
			{
				previewItem.OnItemChangeDisplay(bSelected);
			}
		}

		// Token: 0x0600D856 RID: 55382 RVA: 0x00361830 File Offset: 0x0035FC30
		private void UnInitPreViewItemList()
		{
			if (this.mPreViewDataModel.isCreatItem && this.mPreViewItemList != null)
			{
				ComUIListScript comUIListScript = this.mPreViewItemList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mPreViewItemList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mPreViewItemList;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.mPreViewItemList;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Remove(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangeDisplayDelegate));
			}
		}

		// Token: 0x0600D857 RID: 55383 RVA: 0x003618FC File Offset: 0x0035FCFC
		private void UpdateAvatar(PreViewItemData preViewItem)
		{
			if (preViewItem == null)
			{
				return;
			}
			if (this.mSpriteAniRenderChenghao != null)
			{
				this.mSpriteAniRenderChenghao.gameObject.CustomActive(false);
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(preViewItem.itemId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("can not find ItemTable with id:{0}", new object[]
				{
					preViewItem.itemId
				});
			}
			else if (tableItem.SubType == ItemTable.eSubType.GiftPackage)
			{
				GiftPackTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<GiftPackTable>(tableItem.PackageID, string.Empty, string.Empty);
				if (tableItem2 == null)
				{
					return;
				}
				if (tableItem2.ShowAvatarModelType == GiftPackTable.eShowAvatarModelType.Complete)
				{
					this.InitAvatar(true);
				}
				else
				{
					this.InitAvatar(false);
				}
				FlatBufferArray<int> items = tableItem2.Items;
				bool flag = false;
				for (int i = 0; i < items.Length; i++)
				{
					GiftTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<GiftTable>(items[i], string.Empty, string.Empty);
					ItemTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(tableItem3.ItemID, string.Empty, string.Empty);
					if (tableItem3 != null && tableItem4 != null)
					{
						if (tableItem4.SubType == ItemTable.eSubType.PetEgg || tableItem3.RecommendJobs.Contains(DataManager<PlayerBaseData>.GetInstance().JobTableID))
						{
							if (!flag)
							{
								flag = true;
								this.RefreshAvatar(tableItem3.ItemID);
							}
							else if (tableItem4 != null)
							{
								if (tableItem4.SubType == ItemTable.eSubType.FASHION_HAIR)
								{
									DataManager<PlayerBaseData>.GetInstance().AvatarEquipWing(this.mGeAvatarRendererEx, tableItem4.ID, null, false);
								}
								else if (tableItem4.SubType == ItemTable.eSubType.FASHION_WEAPON)
								{
									DataManager<PlayerBaseData>.GetInstance().AvatarEquipWeapon(this.mGeAvatarRendererEx, DataManager<PlayerBaseData>.GetInstance().JobTableID, tableItem4.ID, null, false);
								}
								else if (tableItem4.SubType == ItemTable.eSubType.GiftPackage)
								{
									GiftPackTable tableItem5 = Singleton<TableManager>.GetInstance().GetTableItem<GiftPackTable>(tableItem4.ID, string.Empty, string.Empty);
									if (tableItem5 == null)
									{
										return;
									}
									FlatBufferArray<int> items2 = tableItem5.Items;
									for (int j = 0; j < items2.Length; j++)
									{
										GiftTable tableItem6 = Singleton<TableManager>.GetInstance().GetTableItem<GiftTable>(items2[j], string.Empty, string.Empty);
										if (tableItem6 != null)
										{
											if (tableItem6.RecommendJobs.Contains(DataManager<PlayerBaseData>.GetInstance().JobTableID))
											{
												ItemTable tableItem7 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(tableItem6.ItemID, string.Empty, string.Empty);
												if (tableItem7.SubType == ItemTable.eSubType.FASHION_HAIR)
												{
													DataManager<PlayerBaseData>.GetInstance().AvatarEquipWing(this.mGeAvatarRendererEx, tableItem7.ID, null, false);
												}
											}
										}
									}
								}
								else
								{
									EFashionWearSlotType equipSlotType = this.GetEquipSlotType(tableItem4);
									DataManager<PlayerBaseData>.GetInstance().AvatarEquipPart(this.mGeAvatarRendererEx, equipSlotType, tableItem4.ID, null, 0, false);
								}
							}
						}
					}
				}
				this.mGeAvatarRendererEx.ChangeAction("Anim_Show_Idle", 1f, true);
				if (this.mShowItemNameId != null && this.mShowItemNameId.Contains(tableItem.ID))
				{
					this.SetName(tableItem.Name, tableItem.Color);
				}
				else
				{
					MallLimitTimeActivity tableItem8 = Singleton<TableManager>.GetInstance().GetTableItem<MallLimitTimeActivity>(preViewItem.activityId, string.Empty, string.Empty);
					if (tableItem8 != null)
					{
						this.SetName(tableItem8.FashionName, tableItem.Color);
					}
					else
					{
						this.SetName(tableItem.Name, tableItem.Color);
					}
				}
			}
			else if (tableItem.SubType == ItemTable.eSubType.TITLE)
			{
				this.InitAvatar(false);
				this.SetNameTitleImage(tableItem);
				this.SetName(tableItem.Name, tableItem.Color);
			}
			else if (tableItem.SubType == ItemTable.eSubType.PetEgg)
			{
				int petID = this.GetPetID(tableItem);
				PlayerUtility.LoadPetAvatarRenderEx(petID, this.mGeAvatarRendererEx, true);
				PetTable tableItem9 = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>(petID, string.Empty, string.Empty);
				if (tableItem9 == null)
				{
					Logger.LogErrorFormat("can not find PetTable with id:{0}", new object[]
					{
						petID
					});
				}
				else
				{
					this.SetName(tableItem9.Name, (ItemTable.eColor)tableItem9.Quality);
				}
			}
			else
			{
				this.InitAvatar(false);
				this.RefreshAvatar(tableItem.ID);
				this.SetName(tableItem.Name, tableItem.Color);
			}
		}

		// Token: 0x0600D858 RID: 55384 RVA: 0x00361D70 File Offset: 0x00360170
		private void RefreshAvatar(int id)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("can not find ItemTable with id:{0}", new object[]
				{
					id
				});
			}
			else
			{
				if (tableItem.SubType == ItemTable.eSubType.FASHION_HAIR)
				{
					DataManager<PlayerBaseData>.GetInstance().AvatarEquipWing(this.mGeAvatarRendererEx, tableItem.ID, null, false);
				}
				else if (tableItem.SubType == ItemTable.eSubType.FASHION_AURAS)
				{
					DataManager<PlayerBaseData>.GetInstance().AvatarEquipHalo(this.mGeAvatarRendererEx, tableItem.ID, null, false, false);
				}
				else if (tableItem.SubType == ItemTable.eSubType.WEAPON)
				{
					DataManager<PlayerBaseData>.GetInstance().AvatarEquipWeapon(this.mGeAvatarRendererEx, DataManager<PlayerBaseData>.GetInstance().JobTableID, tableItem.ID, null, false);
				}
				else if (tableItem.SubType == ItemTable.eSubType.FASHION_WEAPON)
				{
					DataManager<PlayerBaseData>.GetInstance().AvatarEquipWeapon(this.mGeAvatarRendererEx, DataManager<PlayerBaseData>.GetInstance().JobTableID, tableItem.ID, null, false);
				}
				else if (tableItem.SubType == ItemTable.eSubType.PetEgg)
				{
					int petID = this.GetPetID(tableItem);
					PlayerUtility.LoadPetAvatarRenderEx(petID, this.mGeAvatarRendererEx, true);
					PetTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>(petID, string.Empty, string.Empty);
					if (tableItem2 == null)
					{
						Logger.LogErrorFormat("can not find PetTable with id:{0}", new object[]
						{
							petID
						});
					}
					else
					{
						this.SetName(tableItem2.Name, (ItemTable.eColor)tableItem2.Quality);
					}
				}
				else
				{
					EFashionWearSlotType equipSlotType = this.GetEquipSlotType(tableItem);
					DataManager<PlayerBaseData>.GetInstance().AvatarEquipPart(this.mGeAvatarRendererEx, equipSlotType, tableItem.ID, null, 0, false);
				}
				this.mGeAvatarRendererEx.ChangeAction("Anim_Show_Idle", 1f, true);
			}
		}

		// Token: 0x0600D859 RID: 55385 RVA: 0x00361F20 File Offset: 0x00360320
		private void InitAvatar(bool isTakeOffWearFashion = false)
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
						if (isTakeOffWearFashion)
						{
							DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromPreviewCompleteFashion(this.mGeAvatarRendererEx, null);
						}
						else
						{
							DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromCurrentEquiped(this.mGeAvatarRendererEx, null, false);
						}
					}
					this.mGeAvatarRendererEx.AttachAvatar("Aureole", "Effects/Scene_effects/Effectui/EffUI_chuangjue_fazhen_JS", "[actor]Orign", false, true, false, 0f);
					this.mGeAvatarRendererEx.SuitAvatar(true, false);
				}
			}
		}

		// Token: 0x0600D85A RID: 55386 RVA: 0x00362044 File Offset: 0x00360444
		private void UpdateViewShowInfo()
		{
			if (this.mPreViewDataModel.preViewItemList.Count > 1 && this.mCurrentSelectIndex == 0)
			{
				this.mLeftArrowBtn.gameObject.CustomActive(false);
				this.mRightArrowBtn.gameObject.CustomActive(true);
			}
			else if (this.mPreViewDataModel.preViewItemList.Count > 1 && this.mCurrentSelectIndex == this.mPreViewDataModel.preViewItemList.Count - 1)
			{
				this.mLeftArrowBtn.gameObject.CustomActive(true);
				this.mRightArrowBtn.gameObject.CustomActive(false);
			}
			else if (this.mPreViewDataModel.preViewItemList.Count < 2)
			{
				this.mLeftArrowBtn.gameObject.CustomActive(false);
				this.mRightArrowBtn.gameObject.CustomActive(false);
			}
			else
			{
				this.mLeftArrowBtn.gameObject.CustomActive(true);
				this.mRightArrowBtn.gameObject.CustomActive(true);
			}
		}

		// Token: 0x0600D85B RID: 55387 RVA: 0x00362154 File Offset: 0x00360554
		private EFashionWearSlotType GetEquipSlotType(ItemTable ItemTableData)
		{
			if (ItemTableData.SubType == ItemTable.eSubType.FASHION_HEAD)
			{
				return EFashionWearSlotType.Head;
			}
			if (ItemTableData.SubType == ItemTable.eSubType.FASHION_CHEST)
			{
				return EFashionWearSlotType.UpperBody;
			}
			if (ItemTableData.SubType == ItemTable.eSubType.FASHION_EPAULET)
			{
				return EFashionWearSlotType.Chest;
			}
			if (ItemTableData.SubType == ItemTable.eSubType.FASHION_LEG)
			{
				return EFashionWearSlotType.LowerBody;
			}
			if (ItemTableData.SubType == ItemTable.eSubType.FASHION_SASH)
			{
				return EFashionWearSlotType.Waist;
			}
			return EFashionWearSlotType.Invalid;
		}

		// Token: 0x0600D85C RID: 55388 RVA: 0x003621B0 File Offset: 0x003605B0
		private int GetPetID(ItemTable itemTable)
		{
			int result = 0;
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<PetTable>())
			{
				PetTable petTable = keyValuePair.Value as PetTable;
				if (petTable.PetEggID == itemTable.ID)
				{
					return petTable.ID;
				}
			}
			return result;
		}

		// Token: 0x0600D85D RID: 55389 RVA: 0x00362215 File Offset: 0x00360615
		private void SetName(string name, ItemTable.eColor color)
		{
			if (this.mName != null)
			{
				this.mName.text = DataManager<PetDataManager>.GetInstance().GetColorName(name, (PetTable.eQuality)color);
			}
		}

		// Token: 0x0600D85E RID: 55390 RVA: 0x00362240 File Offset: 0x00360640
		private void SetNameTitleImage(ItemTable itemTable)
		{
			if (itemTable != null && itemTable.Path2.Count == 4 && this.mSpriteAniRenderChenghao != null)
			{
				this.mSpriteAniRenderChenghao.gameObject.CustomActive(true);
				this.mSpriteAniRenderChenghao.Reset(itemTable.Path2[0], itemTable.Path2[1], int.Parse(itemTable.Path2[2]), float.Parse(itemTable.Path2[3]), itemTable.ModelPath);
				if (this.mAniImage != null)
				{
					this.mAniImage.enabled = true;
				}
			}
		}

		// Token: 0x0600D85F RID: 55391 RVA: 0x003622F0 File Offset: 0x003606F0
		public void Dispose()
		{
			this.UnInitPreViewItemList();
			this.mPreViewDataModel = null;
			this.mCurrentSelectIndex = 0;
			this.isInitialize = false;
			if (this.mCloseBtn != null)
			{
				this.mCloseBtn.onClick.RemoveAllListeners();
			}
			if (this.mLeftArrowBtn != null)
			{
				this.mLeftArrowBtn.onClick.RemoveAllListeners();
			}
			if (this.mRightArrowBtn != null)
			{
				this.mRightArrowBtn.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600D860 RID: 55392 RVA: 0x0036237B File Offset: 0x0036077B
		private void OnDestroy()
		{
			this.Dispose();
		}

		// Token: 0x04007EFD RID: 32509
		[SerializeField]
		private Text mName;

		// Token: 0x04007EFE RID: 32510
		[SerializeField]
		private SpriteAniRenderChenghao mSpriteAniRenderChenghao;

		// Token: 0x04007EFF RID: 32511
		[SerializeField]
		private GeAvatarRendererEx mGeAvatarRendererEx;

		// Token: 0x04007F00 RID: 32512
		[SerializeField]
		private Image mAniImage;

		// Token: 0x04007F01 RID: 32513
		[SerializeField]
		private Button mCloseBtn;

		// Token: 0x04007F02 RID: 32514
		[SerializeField]
		private Button mLeftArrowBtn;

		// Token: 0x04007F03 RID: 32515
		[SerializeField]
		private Button mRightArrowBtn;

		// Token: 0x04007F04 RID: 32516
		[SerializeField]
		private ComUIListScript mPreViewItemList;

		// Token: 0x04007F05 RID: 32517
		[SerializeField]
		private GameObject actorPos;

		// Token: 0x04007F06 RID: 32518
		[SerializeField]
		private GameObject itemTipRoot;

		// Token: 0x04007F07 RID: 32519
		[SerializeField]
		private Button showItemAttr;

		// Token: 0x04007F08 RID: 32520
		[SerializeField]
		private Button closeShowItemAttr;

		// Token: 0x04007F09 RID: 32521
		private int mCurrentSelectIndex;

		// Token: 0x04007F0A RID: 32522
		private PreViewDataModel mPreViewDataModel;

		// Token: 0x04007F0B RID: 32523
		private bool isInitialize;

		// Token: 0x04007F0C RID: 32524
		private List<int> mShowItemNameId = new List<int>
		{
			800001223
		};

		// Token: 0x04007F0D RID: 32525
		private const int offsetX = 400;
	}
}
