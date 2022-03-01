using System;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001123 RID: 4387
	public class ChijiSkillChooseFrame : ClientFrame
	{
		// Token: 0x0600A67C RID: 42620 RVA: 0x00228CDD File Offset: 0x002270DD
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chiji/ChijiSkillChooseFrame";
		}

		// Token: 0x0600A67D RID: 42621 RVA: 0x00228CE4 File Offset: 0x002270E4
		protected override void _OnOpenFrame()
		{
			this._BindUIEvent();
			if (this.userData != null)
			{
				if (ChijiSkillChooseFrame.pickUpType == PickUpType.PickUpSkill)
				{
					ChiJiSkill[] array = this.userData as ChiJiSkill[];
					this.skillList = new ChiJiSkill[array.Length];
					this.skillList = array;
					if (this.mTitle != null)
					{
						this.mTitle.text = "技能选择";
					}
				}
				else if (ChijiSkillChooseFrame.pickUpType == PickUpType.PickUpItem)
				{
					uint[] array2 = this.userData as uint[];
					this.equipList = new uint[array2.Length];
					this.equipList = array2;
					if (this.mTitle != null)
					{
						this.mTitle.text = "装备选择";
					}
				}
			}
			this._InitItemScrollListBind();
			this._RefreshItemListCount();
		}

		// Token: 0x0600A67E RID: 42622 RVA: 0x00228DAD File Offset: 0x002271AD
		protected override void _OnCloseFrame()
		{
			this._UnBindUIEvent();
			this._ClearData();
		}

		// Token: 0x0600A67F RID: 42623 RVA: 0x00228DBB File Offset: 0x002271BB
		private void _ClearData()
		{
			if (this.skillList != null)
			{
				this.skillList = null;
			}
			if (this.equipList != null)
			{
				this.equipList = null;
			}
		}

		// Token: 0x0600A680 RID: 42624 RVA: 0x00228DE1 File Offset: 0x002271E1
		private void _BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OpenChijiSkillChooseFrame, new ClientEventSystem.UIEventHandler(this._OnOpenChijiSkillChooseFrame));
		}

		// Token: 0x0600A681 RID: 42625 RVA: 0x00228DFE File Offset: 0x002271FE
		private void _UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OpenChijiSkillChooseFrame, new ClientEventSystem.UIEventHandler(this._OnOpenChijiSkillChooseFrame));
		}

		// Token: 0x0600A682 RID: 42626 RVA: 0x00228E1C File Offset: 0x0022721C
		private void _OnOpenChijiSkillChooseFrame(UIEvent iEvent)
		{
			ChijiSkillChooseFrame.pickUpType = (PickUpType)iEvent.Param1;
			if (ChijiSkillChooseFrame.pickUpType == PickUpType.PickUpSkill)
			{
				this.skillList = (iEvent.Param2 as ChiJiSkill[]);
				if (this.mTitle != null)
				{
					this.mTitle.text = "技能选择";
				}
			}
			else if (ChijiSkillChooseFrame.pickUpType == PickUpType.PickUpItem)
			{
				this.equipList = (iEvent.Param2 as uint[]);
				if (this.mTitle != null)
				{
					this.mTitle.text = "装备选择";
				}
			}
			this._InitItemScrollListBind();
			this._RefreshItemListCount();
		}

		// Token: 0x0600A683 RID: 42627 RVA: 0x00228EC4 File Offset: 0x002272C4
		private void _InitItemScrollListBind()
		{
			this.mChijiSkillUIListScript.Initialize();
			this.mChijiSkillUIListScript.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0)
				{
					this._UpdateItemScrollListBind(item);
				}
			};
			this.mChijiSkillUIListScript.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
				Button com = component.GetCom<Button>("select");
				com.onClick.RemoveAllListeners();
			};
		}

		// Token: 0x0600A684 RID: 42628 RVA: 0x00228F1C File Offset: 0x0022731C
		private void _UpdateItemScrollListBind(ComUIListElementScript item)
		{
			if (!(Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemGameBattle))
			{
				return;
			}
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			Text com = component.GetCom<Text>("name");
			Image com2 = component.GetCom<Image>("skillIcon");
			GameObject gameObject = component.GetGameObject("EquipIcon");
			Text com3 = component.GetCom<Text>("des");
			Button com4 = component.GetCom<Button>("select");
			if (ChijiSkillChooseFrame.pickUpType == PickUpType.PickUpSkill)
			{
				if (this.skillList == null || item.m_index < 0 || item.m_index >= this.skillList.Length)
				{
					return;
				}
				SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>((int)this.skillList[item.m_index].skillId, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				if (com != null)
				{
					com.text = tableItem.Name + "Lv." + this.skillList[item.m_index].skillLvl;
				}
				if (com2 != null)
				{
					ETCImageLoader.LoadSprite(ref com2, tableItem.Icon, true);
				}
				if (com3 != null)
				{
					com3.text = DataManager<SkillDataManager>.GetInstance().GetSkillDescription(tableItem);
				}
			}
			else if (ChijiSkillChooseFrame.pickUpType == PickUpType.PickUpItem)
			{
				if (this.equipList == null || item.m_index < 0 || item.m_index >= this.equipList.Length)
				{
					return;
				}
				ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)this.equipList[item.m_index], string.Empty, string.Empty);
				if (tableItem2 == null)
				{
					return;
				}
				if (com2 != null)
				{
					ETCImageLoader.LoadSprite(ref com2, tableItem2.Icon, true);
				}
				ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)this.equipList[item.m_index], 100, 0);
				if (itemData != null)
				{
					if (com != null)
					{
						com.text = itemData.GetColorName(string.Empty, false);
					}
					if (com3 != null)
					{
						com3.text = ChijiShopUtility.GetItemDetailStr(itemData, true);
					}
					if (gameObject != null)
					{
						ItemData wearEquipDataBySlotType = DataManager<ItemDataManager>.GetInstance().GetWearEquipDataBySlotType(itemData.EquipWearSlotType);
						gameObject.CustomActive(wearEquipDataBySlotType != null && wearEquipDataBySlotType.TableID == itemData.TableID);
					}
				}
			}
			com4.onClick.RemoveAllListeners();
			int iIndex = item.m_index;
			com4.onClick.AddListener(delegate()
			{
				this.OnSelectSkill(iIndex);
			});
		}

		// Token: 0x0600A685 RID: 42629 RVA: 0x002291CC File Offset: 0x002275CC
		private void OnSelectSkill(int iIndex)
		{
			if (ChijiSkillChooseFrame.pickUpType == PickUpType.PickUpSkill)
			{
				if (this.skillList == null || iIndex < 0 || iIndex >= this.skillList.Length)
				{
					return;
				}
				DataManager<ChijiDataManager>.GetInstance().SendSelectSkillReq(this.skillList[iIndex].skillId);
			}
			else if (ChijiSkillChooseFrame.pickUpType == PickUpType.PickUpItem)
			{
				if (this.equipList == null || iIndex < 0 || iIndex >= this.equipList.Length)
				{
					return;
				}
				DataManager<ChijiDataManager>.GetInstance().SendSelectItemReq(this.equipList[iIndex]);
			}
			this._onBtCloseButtonClick();
		}

		// Token: 0x0600A686 RID: 42630 RVA: 0x00229268 File Offset: 0x00227668
		private void _RefreshItemListCount()
		{
			if (ChijiSkillChooseFrame.pickUpType == PickUpType.PickUpSkill)
			{
				if (this.mChijiSkillUIListScript == null || this.skillList == null)
				{
					return;
				}
				this.mChijiSkillUIListScript.SetElementAmount(this.skillList.Length);
			}
			else if (ChijiSkillChooseFrame.pickUpType == PickUpType.PickUpItem)
			{
				if (this.mChijiSkillUIListScript == null || this.equipList == null)
				{
					return;
				}
				this.mChijiSkillUIListScript.SetElementAmount(this.equipList.Length);
			}
		}

		// Token: 0x0600A687 RID: 42631 RVA: 0x002292F0 File Offset: 0x002276F0
		protected override void _bindExUI()
		{
			this.mBtClose = this.mBind.GetCom<Button>("btClose");
			this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			this.mChijiSkillUIListScript = this.mBind.GetCom<ComUIListScript>("ChijiSkillUIListScript");
			this.mTitle = this.mBind.GetCom<Text>("title");
		}

		// Token: 0x0600A688 RID: 42632 RVA: 0x0022935B File Offset: 0x0022775B
		protected override void _unbindExUI()
		{
			this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtClose = null;
			this.mChijiSkillUIListScript = null;
			this.mTitle = null;
		}

		// Token: 0x0600A689 RID: 42633 RVA: 0x0022938E File Offset: 0x0022778E
		private void _onBtCloseButtonClick()
		{
			this.frameMgr.CloseFrame<ChijiSkillChooseFrame>(this, false);
		}

		// Token: 0x04005D23 RID: 23843
		public static PickUpType pickUpType;

		// Token: 0x04005D24 RID: 23844
		private ChiJiSkill[] skillList;

		// Token: 0x04005D25 RID: 23845
		private uint[] equipList;

		// Token: 0x04005D26 RID: 23846
		private Button mBtClose;

		// Token: 0x04005D27 RID: 23847
		private ComUIListScript mChijiSkillUIListScript;

		// Token: 0x04005D28 RID: 23848
		private Text mTitle;
	}
}
