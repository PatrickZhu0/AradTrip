using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B5D RID: 7005
	public class InscriptionMosaicView : MonoBehaviour, ISmithShopNewView
	{
		// Token: 0x060112A4 RID: 70308 RVA: 0x004EEB60 File Offset: 0x004ECF60
		private void Awake()
		{
			if (this.mBtnMosaic != null)
			{
				this.mBtnMosaic.onClick.RemoveAllListeners();
				this.mBtnMosaic.onClick.AddListener(new UnityAction(this.OnInscriptionMosaicClick));
			}
			if (this.mBtnPick != null)
			{
				this.mBtnPick.onClick.RemoveAllListeners();
				this.mBtnPick.onClick.AddListener(new UnityAction(this.OnIncriptionExtractBtnClick));
			}
			if (this.mBtnFracture != null)
			{
				this.mBtnFracture.onClick.RemoveAllListeners();
				this.mBtnFracture.onClick.AddListener(new UnityAction(this.OnInscriptionFracturnBtnClick));
			}
			this.BindUIEventSystem();
			this.InitEquipmentUIListScript();
		}

		// Token: 0x060112A5 RID: 70309 RVA: 0x004EEC30 File Offset: 0x004ED030
		private void OnDestroy()
		{
			if (this.mInscriptionHoleInfoList != null)
			{
				this.mInscriptionHoleInfoList.Clear();
			}
			if (this.mAllInscripionEquipment != null)
			{
				this.mAllInscripionEquipment.Clear();
			}
			this.mComItem = null;
			this.mCurrentSelectedEquipItemData = null;
			this.mCurrentSelectedInscriptionItem = null;
			this.mInscriptionHoleIndex = 0;
			this.UnBindUIEventSystem();
			this.UnInitEquipmentUIListScript();
		}

		// Token: 0x060112A6 RID: 70310 RVA: 0x004EEC91 File Offset: 0x004ED091
		public void InitView(SmithShopNewLinkData linkData)
		{
			this.UpdateInscriptionEquipment();
		}

		// Token: 0x060112A7 RID: 70311 RVA: 0x004EEC99 File Offset: 0x004ED099
		public void OnEnableView()
		{
			this.UpdateInscriptionEquipment();
		}

		// Token: 0x060112A8 RID: 70312 RVA: 0x004EECA1 File Offset: 0x004ED0A1
		public void OnDisableView()
		{
		}

		// Token: 0x060112A9 RID: 70313 RVA: 0x004EECA4 File Offset: 0x004ED0A4
		private void InitEquipmentUIListScript()
		{
			if (this.mEquipmentUIListScript != null)
			{
				this.mEquipmentUIListScript.Initialize();
				ComUIListScript comUIListScript = this.mEquipmentUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mEquipmentUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mEquipmentUIListScript;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.mEquipmentUIListScript;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Combine(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangeDisplayDelegate));
			}
		}

		// Token: 0x060112AA RID: 70314 RVA: 0x004EED6C File Offset: 0x004ED16C
		private void UnInitEquipmentUIListScript()
		{
			if (this.mEquipmentUIListScript != null)
			{
				ComUIListScript comUIListScript = this.mEquipmentUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mEquipmentUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mEquipmentUIListScript;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.mEquipmentUIListScript;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Remove(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangeDisplayDelegate));
			}
		}

		// Token: 0x060112AB RID: 70315 RVA: 0x004EEE26 File Offset: 0x004ED226
		private InscriptionEquipmentItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<InscriptionEquipmentItem>();
		}

		// Token: 0x060112AC RID: 70316 RVA: 0x004EEE30 File Offset: 0x004ED230
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			InscriptionEquipmentItem inscriptionEquipmentItem = item.gameObjectBindScript as InscriptionEquipmentItem;
			if (inscriptionEquipmentItem != null && item.m_index >= 0 && item.m_index < this.mAllInscripionEquipment.Count)
			{
				inscriptionEquipmentItem.OnitemVisiable(this.mAllInscripionEquipment[item.m_index]);
			}
		}

		// Token: 0x060112AD RID: 70317 RVA: 0x004EEE90 File Offset: 0x004ED290
		private void OnItemSelectedDelegate(ComUIListElementScript item)
		{
			InscriptionEquipmentItem inscriptionEquipmentItem = item.gameObjectBindScript as InscriptionEquipmentItem;
			if (inscriptionEquipmentItem != null)
			{
				InscriptionEquipmentItem.mSelectItemData = inscriptionEquipmentItem.CurrentItemData;
				this.mCurrentSelectedInscriptionItem = null;
				this.UpdateLeftEquipmentInfo(inscriptionEquipmentItem.CurrentItemData);
			}
		}

		// Token: 0x060112AE RID: 70318 RVA: 0x004EEED4 File Offset: 0x004ED2D4
		private void OnItemChangeDisplayDelegate(ComUIListElementScript item, bool isSelected)
		{
			InscriptionEquipmentItem inscriptionEquipmentItem = item.gameObjectBindScript as InscriptionEquipmentItem;
			if (inscriptionEquipmentItem != null)
			{
				inscriptionEquipmentItem.OnItemChangeDisplay(isSelected);
			}
		}

		// Token: 0x060112AF RID: 70319 RVA: 0x004EEF00 File Offset: 0x004ED300
		private void SetElementAmount()
		{
			this.mEquipmentUIListScript.SetElementAmount(this.mAllInscripionEquipment.Count);
		}

		// Token: 0x060112B0 RID: 70320 RVA: 0x004EEF18 File Offset: 0x004ED318
		private void TrySelectDefultItem()
		{
			int num = -1;
			if (InscriptionEquipmentItem.mSelectItemData != null)
			{
				ItemData itemData = this.mAllInscripionEquipment.Find((ItemData x) => x.GUID == InscriptionEquipmentItem.mSelectItemData.GUID);
				if (itemData != null)
				{
					InscriptionEquipmentItem.mSelectItemData = itemData;
				}
				else
				{
					InscriptionEquipmentItem.mSelectItemData = null;
				}
			}
			if (InscriptionEquipmentItem.mSelectItemData != null)
			{
				for (int i = 0; i < this.mAllInscripionEquipment.Count; i++)
				{
					ulong guid = this.mAllInscripionEquipment[i].GUID;
					if (guid == InscriptionEquipmentItem.mSelectItemData.GUID)
					{
						num = i;
					}
				}
			}
			else if (this.mAllInscripionEquipment.Count > 0)
			{
				num = 0;
			}
			if (num >= 0 && num < this.mAllInscripionEquipment.Count)
			{
				InscriptionEquipmentItem.mSelectItemData = this.mAllInscripionEquipment[num];
				if (!this.mEquipmentUIListScript.IsElementInScrollArea(num))
				{
					this.mEquipmentUIListScript.EnsureElementVisable(num);
				}
				this.mEquipmentUIListScript.SelectElement(num, true);
			}
			else
			{
				this.mEquipmentUIListScript.SelectElement(-1, true);
				InscriptionEquipmentItem.mSelectItemData = null;
			}
			if (InscriptionEquipmentItem.mSelectItemData != null)
			{
				this.UpdateLeftEquipmentInfo(InscriptionEquipmentItem.mSelectItemData);
			}
		}

		// Token: 0x060112B1 RID: 70321 RVA: 0x004EF058 File Offset: 0x004ED458
		private void BindUIEventSystem()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnInscriptionHoleOpenHoleSuccess, new ClientEventSystem.UIEventHandler(this.OnInscriptionHoleOpenHoleSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RefreshInscriptionEquipmentList, new ClientEventSystem.UIEventHandler(this.OnRefreshInscriptionEquipmentList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnInscriptionMosaicSuccess, new ClientEventSystem.UIEventHandler(this.OnRefreshInscriptionEquipmentList));
		}

		// Token: 0x060112B2 RID: 70322 RVA: 0x004EF0B8 File Offset: 0x004ED4B8
		private void UnBindUIEventSystem()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnInscriptionHoleOpenHoleSuccess, new ClientEventSystem.UIEventHandler(this.OnInscriptionHoleOpenHoleSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RefreshInscriptionEquipmentList, new ClientEventSystem.UIEventHandler(this.OnRefreshInscriptionEquipmentList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnInscriptionMosaicSuccess, new ClientEventSystem.UIEventHandler(this.OnRefreshInscriptionEquipmentList));
		}

		// Token: 0x060112B3 RID: 70323 RVA: 0x004EF116 File Offset: 0x004ED516
		private void OnInscriptionHoleOpenHoleSuccess(UIEvent uiEvent)
		{
			this.mEquipmentUIListScript.ResetSelectedElementIndex();
			this.UpdateInscriptionEquipment();
		}

		// Token: 0x060112B4 RID: 70324 RVA: 0x004EF129 File Offset: 0x004ED529
		private void OnRefreshInscriptionEquipmentList(UIEvent uiEvent)
		{
			this.UpdateInscriptionEquipment();
		}

		// Token: 0x060112B5 RID: 70325 RVA: 0x004EF134 File Offset: 0x004ED534
		private void UpdateLeftEquipmentInfo(ItemData itemData)
		{
			this.mCurrentSelectedEquipItemData = itemData;
			if (itemData == null)
			{
				return;
			}
			if (this.mComItem == null)
			{
				this.mComItem = ComItemManager.Create(this.mItemParent);
			}
			ComItem comItem = this.mComItem;
			if (InscriptionMosaicView.<>f__mg$cache0 == null)
			{
				InscriptionMosaicView.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			comItem.Setup(itemData, InscriptionMosaicView.<>f__mg$cache0);
			if (this.mName != null)
			{
				this.mName.text = itemData.GetColorName(string.Empty, false);
			}
			if (this.mInscriptionHoleInfoList != null && this.mInscriptionHoleInfoList.Count > 0)
			{
				for (int i = 0; i < this.mInscriptionHoleInfoList.Count; i++)
				{
					this.mInscriptionHoleInfoList[i].CustomActive(false);
				}
			}
			for (int j = 0; j < this.mCurrentSelectedEquipItemData.InscriptionHoles.Count; j++)
			{
				if (j < this.mInscriptionHoleInfoList.Count)
				{
					this.mInscriptionHoleInfoList[j].CustomActive(true);
					InscriptionHoleItem component = this.mInscriptionHoleInfoList[j].GetComponent<InscriptionHoleItem>();
					if (component != null)
					{
						component.OnItemVisiable(this.mCurrentSelectedEquipItemData.InscriptionHoles[j], this.mCurrentSelectedEquipItemData, this.mToggleGroup, j == 0, new OnSetInscriptionItemData(this.OnSetInscriptionItem));
					}
				}
				else
				{
					GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(this.mSInscriptionHoleItemPath, true, 0U);
					if (gameObject != null)
					{
						Utility.AttachTo(gameObject, this.mInscriptionHoleRoot, false);
						InscriptionHoleItem component2 = gameObject.GetComponent<InscriptionHoleItem>();
						if (component2 != null)
						{
							component2.OnItemVisiable(this.mCurrentSelectedEquipItemData.InscriptionHoles[j], this.mCurrentSelectedEquipItemData, this.mToggleGroup, j == 0, new OnSetInscriptionItemData(this.OnSetInscriptionItem));
						}
						this.mInscriptionHoleInfoList.Add(gameObject);
					}
				}
			}
			this.UpdateIncriptionMosaicPickBtnState();
		}

		// Token: 0x060112B6 RID: 70326 RVA: 0x004EF330 File Offset: 0x004ED730
		private void UpdateIncriptionMosaicPickBtnState()
		{
			bool flag = false;
			bool flag2 = false;
			bool bActive = false;
			for (int i = 0; i < this.mCurrentSelectedEquipItemData.InscriptionHoles.Count; i++)
			{
				if (this.mCurrentSelectedEquipItemData.InscriptionHoles[i].IsOpenHole)
				{
					flag = true;
					if (this.mCurrentSelectedEquipItemData.InscriptionHoles[i].InscriptionId >= 0)
					{
						flag2 = DataManager<InscriptionMosaicDataManager>.GetInstance().CheckInscriptionItemIsExtract(this.mCurrentSelectedEquipItemData.InscriptionHoles[i].InscriptionId);
						if (!flag2)
						{
							goto IL_7C;
						}
					}
					break;
				}
				IL_7C:;
			}
			for (int j = 0; j < this.mCurrentSelectedEquipItemData.InscriptionHoles.Count; j++)
			{
				if (this.mCurrentSelectedEquipItemData.InscriptionHoles[j].IsOpenHole)
				{
					if (this.mCurrentSelectedEquipItemData.InscriptionHoles[j].InscriptionId > 0)
					{
						bActive = true;
						break;
					}
				}
			}
			this.mGrayMosaic.enabled = !flag;
			this.mBtnMosaic.image.raycastTarget = flag;
			this.mBtnPick.CustomActive(flag2);
			this.mBtnFracture.CustomActive(bActive);
		}

		// Token: 0x060112B7 RID: 70327 RVA: 0x004EF475 File Offset: 0x004ED875
		private void OnSetInscriptionItem(ItemData itemData, int incriptionHoleIndex)
		{
			this.mCurrentSelectedInscriptionItem = itemData;
			this.mInscriptionHoleIndex = incriptionHoleIndex;
		}

		// Token: 0x060112B8 RID: 70328 RVA: 0x004EF485 File Offset: 0x004ED885
		private void UpdateInscriptionEquipment()
		{
			this.mCurrentSelectedInscriptionItem = null;
			DataManager<InscriptionMosaicDataManager>.GetInstance().LoadAllInscriptionEquipment();
			this.mAllInscripionEquipment = DataManager<InscriptionMosaicDataManager>.GetInstance().GetInscriptionAllEquipment();
			this.SetElementAmount();
			this.TrySelectDefultItem();
		}

		// Token: 0x060112B9 RID: 70329 RVA: 0x004EF4B4 File Offset: 0x004ED8B4
		private void OnIncriptionExtractBtnClick()
		{
			List<InscriptionExtractItemData> list = new List<InscriptionExtractItemData>();
			if (this.mCurrentSelectedEquipItemData != null && this.mCurrentSelectedEquipItemData.InscriptionHoles != null)
			{
				for (int i = 0; i < this.mCurrentSelectedEquipItemData.InscriptionHoles.Count; i++)
				{
					InscriptionHoleData inscriptionHoleData = this.mCurrentSelectedEquipItemData.InscriptionHoles[i];
					if (inscriptionHoleData != null)
					{
						if (inscriptionHoleData.IsOpenHole)
						{
							if (inscriptionHoleData.InscriptionId > 0)
							{
								if (DataManager<InscriptionMosaicDataManager>.GetInstance().CheckInscriptionItemIsExtract(inscriptionHoleData.InscriptionId))
								{
									list.Add(new InscriptionExtractItemData
									{
										equipmentItem = this.mCurrentSelectedEquipItemData,
										inscriptionItem = ItemDataManager.CreateItemDataFromTable(inscriptionHoleData.InscriptionId, 100, 0),
										index = inscriptionHoleData.Index
									});
								}
							}
						}
					}
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<InscriptionExtractFrame>(FrameLayer.Middle, list, string.Empty);
			}
		}

		// Token: 0x060112BA RID: 70330 RVA: 0x004EF5B0 File Offset: 0x004ED9B0
		private void OnInscriptionFracturnBtnClick()
		{
			List<InscriptionExtractItemData> list = new List<InscriptionExtractItemData>();
			if (this.mCurrentSelectedEquipItemData != null && this.mCurrentSelectedEquipItemData.InscriptionHoles != null)
			{
				for (int i = 0; i < this.mCurrentSelectedEquipItemData.InscriptionHoles.Count; i++)
				{
					InscriptionHoleData inscriptionHoleData = this.mCurrentSelectedEquipItemData.InscriptionHoles[i];
					if (inscriptionHoleData != null)
					{
						if (inscriptionHoleData.IsOpenHole)
						{
							if (inscriptionHoleData.InscriptionId > 0)
							{
								list.Add(new InscriptionExtractItemData
								{
									equipmentItem = this.mCurrentSelectedEquipItemData,
									inscriptionItem = ItemDataManager.CreateItemDataFromTable(inscriptionHoleData.InscriptionId, 100, 0),
									index = inscriptionHoleData.Index
								});
							}
						}
					}
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<InscriptionFractureFrame>(FrameLayer.Middle, list, string.Empty);
			}
		}

		// Token: 0x060112BB RID: 70331 RVA: 0x004EF684 File Offset: 0x004EDA84
		private void OnInscriptionMosaicClick()
		{
			if (this.mCurrentSelectedEquipItemData != null && this.mCurrentSelectedEquipItemData.Packing)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("Inscription_Mosaic_SealEquip_Desc"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.mCurrentSelectedInscriptionItem == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("Inscription_Mosaic_NoPutInInscription_Desc"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			int inscriptionId = this.mCurrentSelectedEquipItemData.InscriptionHoles[this.mInscriptionHoleIndex - 1].InscriptionId;
			if (inscriptionId > 0)
			{
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(inscriptionId, 100, 0);
				AdjustResultFrame.AdjustResultFrameData adjustResultFrameData = new AdjustResultFrame.AdjustResultFrameData();
				AdjustResultFrame.AdjustResultFrameData adjustResultFrameData2 = adjustResultFrameData;
				adjustResultFrameData2.callback = (UnityAction)Delegate.Combine(adjustResultFrameData2.callback, new UnityAction(this.OnOnSceneEquipInscriptionMountReq));
				string desc = string.Format("使用[{0}]的[{1}]\n替换\n[{2}]的[{3}],被替换的铭文将会消失,确定要替换?", new object[]
				{
					DataManager<InscriptionMosaicDataManager>.GetInstance().GetInscriptionAttributesDesc(this.mCurrentSelectedInscriptionItem.TableID, false),
					this.mCurrentSelectedInscriptionItem.GetColorName(string.Empty, false),
					DataManager<InscriptionMosaicDataManager>.GetInstance().GetInscriptionAttributesDesc(itemData.TableID, false),
					itemData.GetColorName(string.Empty, false)
				});
				adjustResultFrameData.desc = desc;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<AdjustResultFrame>(FrameLayer.Middle, adjustResultFrameData, string.Empty);
				return;
			}
			if (this.mCurrentSelectedInscriptionItem.Quality > ItemTable.eColor.PURPLE)
			{
				string msgContent = TR.Value("Inscription_Mosaic_HightQualityIncription_Desc");
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, new UnityAction(this.OnOnSceneEquipInscriptionMountReq), null, 0f, false);
				return;
			}
			if (!InscriptionMosaicDataManager.InscriptionMosiacBounced)
			{
				string content = TR.Value("Inscription_Mosaic_LowInscription_Desc");
				MallNewUtility.CommonIntergralMallPopupWindow(content, new OnCommonMsgBoxToggleClick(this.OnToggleClick), new Action(this.OnOnSceneEquipInscriptionMountReq));
				return;
			}
			this.OnOnSceneEquipInscriptionMountReq();
		}

		// Token: 0x060112BC RID: 70332 RVA: 0x004EF81F File Offset: 0x004EDC1F
		private void OnToggleClick(bool value)
		{
			InscriptionMosaicDataManager.InscriptionMosiacBounced = value;
		}

		// Token: 0x060112BD RID: 70333 RVA: 0x004EF828 File Offset: 0x004EDC28
		private void OnOnSceneEquipInscriptionMountReq()
		{
			if (this.mCurrentSelectedEquipItemData != null && this.mCurrentSelectedInscriptionItem != null)
			{
				DataManager<InscriptionMosaicDataManager>.GetInstance().OnSceneEquipInscriptionMountReq(this.mCurrentSelectedEquipItemData.GUID, (uint)this.mInscriptionHoleIndex, this.mCurrentSelectedInscriptionItem.GUID, (uint)this.mCurrentSelectedInscriptionItem.TableID);
			}
		}

		// Token: 0x0400B12E RID: 45358
		[SerializeField]
		private ComUIListScript mEquipmentUIListScript;

		// Token: 0x0400B12F RID: 45359
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400B130 RID: 45360
		[SerializeField]
		private Text mName;

		// Token: 0x0400B131 RID: 45361
		[SerializeField]
		private GameObject mInscriptionHoleRoot;

		// Token: 0x0400B132 RID: 45362
		[SerializeField]
		private Button mBtnPick;

		// Token: 0x0400B133 RID: 45363
		[SerializeField]
		private Button mBtnMosaic;

		// Token: 0x0400B134 RID: 45364
		[SerializeField]
		private Button mBtnFracture;

		// Token: 0x0400B135 RID: 45365
		[SerializeField]
		private UIGray mGrayMosaic;

		// Token: 0x0400B136 RID: 45366
		[SerializeField]
		private ToggleGroup mToggleGroup;

		// Token: 0x0400B137 RID: 45367
		[SerializeField]
		private string mSInscriptionHoleItemPath = "UIFlatten/Prefabs/SmithShop/InscriptionFrame/InscriptionHoleItem";

		// Token: 0x0400B138 RID: 45368
		private List<GameObject> mInscriptionHoleInfoList = new List<GameObject>();

		// Token: 0x0400B139 RID: 45369
		private List<ItemData> mAllInscripionEquipment = new List<ItemData>();

		// Token: 0x0400B13A RID: 45370
		private ComItem mComItem;

		// Token: 0x0400B13B RID: 45371
		private ItemData mCurrentSelectedEquipItemData;

		// Token: 0x0400B13C RID: 45372
		private ItemData mCurrentSelectedInscriptionItem;

		// Token: 0x0400B13D RID: 45373
		private int mInscriptionHoleIndex;

		// Token: 0x0400B13F RID: 45375
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
