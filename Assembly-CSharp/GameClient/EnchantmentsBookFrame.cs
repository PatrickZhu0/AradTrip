using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015B4 RID: 5556
	internal class EnchantmentsBookFrame : ClientFrame
	{
		// Token: 0x0600D92B RID: 55595 RVA: 0x00366841 File Offset: 0x00364C41
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/EnchantmentsFrame/EnchantmentsFrame";
		}

		// Token: 0x0600D92C RID: 55596 RVA: 0x00366848 File Offset: 0x00364C48
		private IEnumerator _AnsyInitEnchantmentsCard()
		{
			this.m_goParent = Utility.FindChild(this.frame, "tittles/ScrollView/Viewport/content");
			this.m_goPrefab = Utility.FindChild(this.m_goParent, "prefabs");
			this.m_goPrefab.CustomActive(false);
			this.m_akEnchantCardObjects.Clear();
			yield return Yielders.EndOfFrame;
			List<EnchantmentsCardData> magicCards = DataManager<EnchantmentsCardManager>.GetInstance().EnchantmentsCardDataList;
			for (int i = 0; i < magicCards.Count; i++)
			{
				this.OnAddCard(magicCards[i], false);
				if (i % 5 == 0)
				{
					yield return Yielders.EndOfFrame;
				}
			}
			this._OnCheckAllTabMarks();
			yield return Yielders.EndOfFrame;
			yield break;
		}

		// Token: 0x0600D92D RID: 55597 RVA: 0x00366864 File Offset: 0x00364C64
		protected override void _OnOpenFrame()
		{
			this.m_kBtnComLink = Utility.FindComponent<Button>(this.frame, "tittles/Detail/ButtonAcquire", true);
			this.m_kComGray = Utility.FindComponent<UIGray>(this.frame, "tittles/Detail/ButtonAcquire", true);
			EnchantmentsBookFrame.CardItemObject.Clear();
			this._InitTabs();
			base.StartCoroutine(this._AnsyInitEnchantmentsCard());
			EnchantmentsCardManager instance = DataManager<EnchantmentsCardManager>.GetInstance();
			instance.onUpdateCard = (EnchantmentsCardManager.OnUpdateCard)Delegate.Combine(instance.onUpdateCard, new EnchantmentsCardManager.OnUpdateCard(this._OnUpdateCard));
			EnchantmentsCardManager instance2 = DataManager<EnchantmentsCardManager>.GetInstance();
			instance2.onTabMarkChanged = (EnchantmentsCardManager.OnTabMarkChanged)Delegate.Combine(instance2.onTabMarkChanged, new EnchantmentsCardManager.OnTabMarkChanged(this.OnTabMarkChanged));
			this.m_kComItem = null;
		}

		// Token: 0x0600D92E RID: 55598 RVA: 0x0036690C File Offset: 0x00364D0C
		protected override void _OnCloseFrame()
		{
			EnchantmentsCardManager instance = DataManager<EnchantmentsCardManager>.GetInstance();
			instance.onUpdateCard = (EnchantmentsCardManager.OnUpdateCard)Delegate.Remove(instance.onUpdateCard, new EnchantmentsCardManager.OnUpdateCard(this._OnUpdateCard));
			EnchantmentsCardManager instance2 = DataManager<EnchantmentsCardManager>.GetInstance();
			instance2.onTabMarkChanged = (EnchantmentsCardManager.OnTabMarkChanged)Delegate.Remove(instance2.onTabMarkChanged, new EnchantmentsCardManager.OnTabMarkChanged(this.OnTabMarkChanged));
			this.m_akEnchantCardObjects.Clear();
			EnchantmentsBookFrame.CardItemObject.Clear();
		}

		// Token: 0x0600D92F RID: 55599 RVA: 0x00366978 File Offset: 0x00364D78
		private void _InitTabs()
		{
			this.m_eEnchantmentsType = EnchantmentsType.ET_INVALID;
			this.m_goTabPrefab = Utility.FindChild(this.frame, "tabs/tab");
			this.m_goTabPrefab.CustomActive(false);
			for (int i = 0; i < 6; i++)
			{
				if (DataManager<EnchantmentsCardManager>.GetInstance().HasQualityCard((EnchantmentsType)i))
				{
					GameObject gameObject = Object.Instantiate<GameObject>(this.m_goTabPrefab);
					Utility.AttachTo(gameObject, this.m_goTabPrefab.transform.parent.gameObject, false);
					string text = Utility.GetEnumDescription<EnchantmentsType>((EnchantmentsType)i);
					string text2 = TR.Value(text);
					if (!string.IsNullOrEmpty(text2))
					{
						text = text2;
					}
					Text text3 = Utility.FindComponent<Text>(gameObject, "Label", true);
					text3.text = text;
					text3 = Utility.FindComponent<Text>(gameObject, "Checkmark/Label", true);
					text3.text = text;
					gameObject.CustomActive(true);
					Toggle component = gameObject.GetComponent<Toggle>();
					component.onValueChanged.RemoveAllListeners();
					int k = i;
					component.onValueChanged.AddListener(delegate(bool bValue)
					{
						if (bValue)
						{
							this._OnTabChanged((EnchantmentsType)k);
						}
					});
					this.m_akToggles[i] = component;
					this.m_akTabMark[i] = Utility.FindChild(component.gameObject, "tabMark");
				}
			}
			this.m_akToggles[0].isOn = true;
		}

		// Token: 0x0600D930 RID: 55600 RVA: 0x00366ABF File Offset: 0x00364EBF
		private void _OnTabChanged(EnchantmentsType eEnchantmentsType)
		{
			this.m_eEnchantmentsType = eEnchantmentsType;
			this.m_akEnchantCardObjects.Filter(new object[]
			{
				this.m_eEnchantmentsType
			});
			this._OnTabMarkChanged(eEnchantmentsType);
		}

		// Token: 0x0600D931 RID: 55601 RVA: 0x00366AEE File Offset: 0x00364EEE
		private void _OnTabMarkChanged(EnchantmentsType eEnchantmentsType)
		{
			if (this.m_akTabMark[(int)eEnchantmentsType] != null)
			{
				this.m_akTabMark[(int)eEnchantmentsType].CustomActive(DataManager<EnchantmentsCardManager>.GetInstance().HasNewQualityCard(eEnchantmentsType));
			}
		}

		// Token: 0x0600D932 RID: 55602 RVA: 0x00366B1C File Offset: 0x00364F1C
		private void _OnCheckAllTabMarks()
		{
			for (int i = 0; i < 6; i++)
			{
				if (this.m_akTabMark[i] != null)
				{
					this.m_akTabMark[i].CustomActive(DataManager<EnchantmentsCardManager>.GetInstance().HasNewQualityCard((EnchantmentsType)i));
				}
			}
		}

		// Token: 0x0600D933 RID: 55603 RVA: 0x00366B66 File Offset: 0x00364F66
		[UIEventHandle("tittle/close")]
		private void OnClickClose()
		{
			this.frameMgr.CloseFrame<EnchantmentsBookFrame>(this, false);
		}

		// Token: 0x0600D934 RID: 55604 RVA: 0x00366B78 File Offset: 0x00364F78
		[UIEventHandle("ToGet")]
		private void OnToGet()
		{
			ItemComeLink.OnLink(this.tableID, 0, true, null, false, false, false, null, string.Empty);
		}

		// Token: 0x0600D935 RID: 55605 RVA: 0x00366B9C File Offset: 0x00364F9C
		private void _InitEnchantmentsCard()
		{
			this.m_goParent = Utility.FindChild(this.frame, "tittles/ScrollView/Viewport/content");
			this.m_goPrefab = Utility.FindChild(this.m_goParent, "prefabs");
			this.m_goPrefab.CustomActive(false);
			this.m_akEnchantCardObjects.Clear();
			List<EnchantmentsCardData> enchantmentsCardDataList = DataManager<EnchantmentsCardManager>.GetInstance().EnchantmentsCardDataList;
			for (int i = 0; i < enchantmentsCardDataList.Count; i++)
			{
				this.OnAddCard(enchantmentsCardDataList[i], false);
			}
			this._OnCheckAllTabMarks();
		}

		// Token: 0x0600D936 RID: 55606 RVA: 0x00366C24 File Offset: 0x00365024
		private void OnSetTarget(EnchantmentsBookFrame.CardItemObject cardItemObject)
		{
			this.m_kCurrent = cardItemObject;
			if (this.m_kComItem == null)
			{
				this.m_kComItem = base.CreateComItem(this.m_kCardIcon.gameObject);
			}
			if (this.m_kCurrent != null)
			{
				EnchantmentsCardData enchantmentsCardData = this.m_kCurrent.EnchantmentsCardData;
				this.tableID = enchantmentsCardData.itemData.TableID;
				this.m_kCondition.text = DataManager<EnchantmentsCardManager>.GetInstance().GetCondition(enchantmentsCardData);
				this.m_kCardName.text = enchantmentsCardData.itemData.GetColorName(string.Empty, false);
				this.m_kCardDesc.text = DataManager<EnchantmentsCardManager>.GetInstance().GetDefaultDescribe(enchantmentsCardData);
				this.m_kCardIcon.enabled = false;
				this.m_kComItem.Setup(enchantmentsCardData.itemData, new ComItem.OnItemClicked(this.OnItemClicked));
				this.m_kComGray.enabled = false;
				this.m_kBtnComLink.enabled = true;
				this.m_kCardComeLink.bNotEnough = false;
				this.m_kCardComeLink.iItemLinkID = enchantmentsCardData.magicItem.ID;
			}
			else
			{
				this.m_kCardIcon.enabled = true;
				this.m_kComItem.Setup(null, null);
				this.m_kComGray.enabled = true;
				this.m_kBtnComLink.enabled = false;
				this.m_kCardComeLink.iItemLinkID = 0;
			}
		}

		// Token: 0x0600D937 RID: 55607 RVA: 0x00366D75 File Offset: 0x00365175
		private void OnItemClicked(GameObject obj, ItemData item)
		{
			DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
		}

		// Token: 0x0600D938 RID: 55608 RVA: 0x00366D88 File Offset: 0x00365188
		private void OnAddCard(EnchantmentsCardData data, bool bNeedUpdateTabMark = false)
		{
			if (data != null)
			{
				if (this.m_akEnchantCardObjects.HasObject((ulong)((long)data.itemData.TableID)))
				{
					this.OnUpdateCard(data, bNeedUpdateTabMark);
				}
				else
				{
					EnchantmentsBookFrame.CardItemObject cardItemObject = this.m_akEnchantCardObjects.Create((ulong)((long)data.itemData.TableID), new object[]
					{
						this.m_goParent,
						this.m_goPrefab,
						data,
						this
					});
					if (cardItemObject != null)
					{
						this.m_akEnchantCardObjects.FilterObject((ulong)((long)data.itemData.TableID), new object[]
						{
							this.m_eEnchantmentsType
						});
						cardItemObject.TrySelected();
						if (bNeedUpdateTabMark)
						{
							this._OnTabMarkChanged(cardItemObject.EnchantmentsType);
						}
					}
				}
			}
		}

		// Token: 0x0600D939 RID: 55609 RVA: 0x00366E48 File Offset: 0x00365248
		private void OnUpdateCard(EnchantmentsCardData data, bool bNeedUpdateTabMark = false)
		{
			if (data != null)
			{
				this.m_akEnchantCardObjects.RefreshObject((ulong)((long)data.itemData.TableID), new object[]
				{
					data
				});
				if (bNeedUpdateTabMark)
				{
					EnchantmentsBookFrame.CardItemObject @object = this.m_akEnchantCardObjects.GetObject((ulong)((long)data.itemData.TableID));
					if (@object != null)
					{
						this._OnTabMarkChanged(@object.EnchantmentsType);
					}
				}
			}
		}

		// Token: 0x0600D93A RID: 55610 RVA: 0x00366EAD File Offset: 0x003652AD
		private void _OnUpdateCard(EnchantmentsCardData data)
		{
			this.OnUpdateCard(data, true);
		}

		// Token: 0x0600D93B RID: 55611 RVA: 0x00366EB8 File Offset: 0x003652B8
		private void OnTabMarkChanged(ulong iTableID)
		{
			EnchantmentsBookFrame.CardItemObject @object = this.m_akEnchantCardObjects.GetObject(iTableID);
			if (@object != null)
			{
				@object._UpdateItem();
				this._OnTabMarkChanged(@object.EnchantmentsType);
			}
		}

		// Token: 0x04007FA9 RID: 32681
		private GameObject m_goTabPrefab;

		// Token: 0x04007FAA RID: 32682
		private EnchantmentsType m_eEnchantmentsType = EnchantmentsType.ET_INVALID;

		// Token: 0x04007FAB RID: 32683
		private Toggle[] m_akToggles = new Toggle[6];

		// Token: 0x04007FAC RID: 32684
		private GameObject[] m_akTabMark = new GameObject[6];

		// Token: 0x04007FAD RID: 32685
		private CachedObjectDicManager<ulong, EnchantmentsBookFrame.CardItemObject> m_akEnchantCardObjects = new CachedObjectDicManager<ulong, EnchantmentsBookFrame.CardItemObject>();

		// Token: 0x04007FAE RID: 32686
		private GameObject m_goParent;

		// Token: 0x04007FAF RID: 32687
		private GameObject m_goPrefab;

		// Token: 0x04007FB0 RID: 32688
		private EnchantmentsBookFrame.CardItemObject m_kCurrent;

		// Token: 0x04007FB1 RID: 32689
		[UIControl("tittles/Detail/condition/name", typeof(Text), 0)]
		private Text m_kCondition;

		// Token: 0x04007FB2 RID: 32690
		[UIControl("tittles/Detail/card/name", typeof(Text), 0)]
		private Text m_kCardName;

		// Token: 0x04007FB3 RID: 32691
		[UIControl("tittles/Detail/card/slot", typeof(Image), 0)]
		private Image m_kCardIcon;

		// Token: 0x04007FB4 RID: 32692
		[UIControl("tittles/Detail/card/ScrollView/Viewport/content/Text", typeof(Text), 0)]
		private Text m_kCardDesc;

		// Token: 0x04007FB5 RID: 32693
		private ComItem m_kComItem;

		// Token: 0x04007FB6 RID: 32694
		[UIControl("tittles/Detail/ButtonAcquire", typeof(ItemComeLink), 0)]
		private ItemComeLink m_kCardComeLink;

		// Token: 0x04007FB7 RID: 32695
		private Button m_kBtnComLink;

		// Token: 0x04007FB8 RID: 32696
		private UIGray m_kComGray;

		// Token: 0x04007FB9 RID: 32697
		private int tableID;

		// Token: 0x020015B5 RID: 5557
		private class CardItemObject : CachedObject
		{
			// Token: 0x0600D93D RID: 55613 RVA: 0x00366EF2 File Offset: 0x003652F2
			public static void Clear()
			{
				EnchantmentsBookFrame.CardItemObject.ms_selected = null;
			}

			// Token: 0x17001C2D RID: 7213
			// (get) Token: 0x0600D93E RID: 55614 RVA: 0x00366EFA File Offset: 0x003652FA
			public EnchantmentsType EnchantmentsType
			{
				get
				{
					return this.eEnchantmentsType;
				}
			}

			// Token: 0x17001C2E RID: 7214
			// (get) Token: 0x0600D93F RID: 55615 RVA: 0x00366F02 File Offset: 0x00365302
			public EnchantmentsCardData EnchantmentsCardData
			{
				get
				{
					return this.data;
				}
			}

			// Token: 0x0600D940 RID: 55616 RVA: 0x00366F0C File Offset: 0x0036530C
			public override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.data = (param[2] as EnchantmentsCardData);
				this.THIS = (param[3] as EnchantmentsBookFrame);
				if (this.goLocal == null)
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
					Utility.AttachTo(this.goLocal, this.goParent, false);
					this.itemParent = Utility.FindChild(this.goLocal, "EnableMark/Icon");
					this.comItem = this.THIS.CreateComItem(this.itemParent);
					this.goSelected = Utility.FindChild(this.goLocal, "SelectMark");
					this.m_kName = Utility.FindComponent<Text>(this.goLocal, "EnableMark/Name", true);
					this.m_kLv = Utility.FindComponent<Text>(this.goLocal, "EnableMark/Lv", true);
					this.button = this.goLocal.GetComponent<Button>();
					this.button.onClick.RemoveAllListeners();
					this.button.onClick.AddListener(new UnityAction(this._OnClick));
					this.m_goNewMark = Utility.FindChild(this.goLocal, "EnableMark/NewMark");
					this.comGray = Utility.FindComponent<UIGray>(this.goLocal, "EnableMark", true);
				}
				this.Enable();
				this._UpdateItem();
			}

			// Token: 0x0600D941 RID: 55617 RVA: 0x0036706C File Offset: 0x0036546C
			public override void OnRecycle()
			{
				this.Disable();
			}

			// Token: 0x0600D942 RID: 55618 RVA: 0x00367074 File Offset: 0x00365474
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x0600D943 RID: 55619 RVA: 0x00367093 File Offset: 0x00365493
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0600D944 RID: 55620 RVA: 0x003670B2 File Offset: 0x003654B2
			public override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x0600D945 RID: 55621 RVA: 0x003670BB File Offset: 0x003654BB
			public override void OnRefresh(object[] param)
			{
				this.data = (param[0] as EnchantmentsCardData);
				this._UpdateItem();
			}

			// Token: 0x0600D946 RID: 55622 RVA: 0x003670D1 File Offset: 0x003654D1
			public override bool NeedFilter(object[] param)
			{
				return this.eEnchantmentsType != (EnchantmentsType)param[0];
			}

			// Token: 0x0600D947 RID: 55623 RVA: 0x003670E8 File Offset: 0x003654E8
			public void _UpdateItem()
			{
				this.eEnchantmentsType = EnchantmentsCardManager.GetQuality(this.data.itemData.Quality);
				this.comItem.Setup(this.data.itemData, new ComItem.OnItemClicked(this.OnItemClicked));
				this.m_kName.text = this.data.itemData.GetColorName(string.Empty, false);
				this.m_kLv.text = "lv" + this.data.itemData.LevelLimit;
				this.SetSelected(this == EnchantmentsBookFrame.CardItemObject.ms_selected);
				this.m_goNewMark.CustomActive(this.data.itemData.IsNew);
				this.comGray.enabled = (this.data.itemData.Count <= 0);
			}

			// Token: 0x0600D948 RID: 55624 RVA: 0x003671C7 File Offset: 0x003655C7
			private void OnItemClicked(GameObject obj, ItemData item)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
			}

			// Token: 0x0600D949 RID: 55625 RVA: 0x003671D9 File Offset: 0x003655D9
			private void SetSelected(bool bSelected)
			{
				this.goSelected.CustomActive(bSelected);
			}

			// Token: 0x0600D94A RID: 55626 RVA: 0x003671E7 File Offset: 0x003655E7
			private void _OnClick()
			{
				DataManager<EnchantmentsCardManager>.GetInstance().RemoveNewMark((ulong)((long)this.data.itemData.TableID));
				this.OnSelected();
			}

			// Token: 0x0600D94B RID: 55627 RVA: 0x0036720A File Offset: 0x0036560A
			private void OnSelected()
			{
				if (EnchantmentsBookFrame.CardItemObject.ms_selected != this)
				{
					if (EnchantmentsBookFrame.CardItemObject.ms_selected != null)
					{
						EnchantmentsBookFrame.CardItemObject.ms_selected.SetSelected(false);
					}
					EnchantmentsBookFrame.CardItemObject.ms_selected = this;
					this.SetSelected(true);
				}
				this.THIS.OnSetTarget(this);
			}

			// Token: 0x0600D94C RID: 55628 RVA: 0x00367245 File Offset: 0x00365645
			public void TrySelected()
			{
				if (EnchantmentsBookFrame.CardItemObject.ms_selected == null && this.eEnchantmentsType == this.THIS.m_eEnchantmentsType)
				{
					this.OnSelected();
				}
			}

			// Token: 0x04007FBA RID: 32698
			private static EnchantmentsBookFrame.CardItemObject ms_selected;

			// Token: 0x04007FBB RID: 32699
			protected GameObject goLocal;

			// Token: 0x04007FBC RID: 32700
			protected GameObject goParent;

			// Token: 0x04007FBD RID: 32701
			protected GameObject goPrefab;

			// Token: 0x04007FBE RID: 32702
			protected EnchantmentsCardData data;

			// Token: 0x04007FBF RID: 32703
			protected EnchantmentsBookFrame THIS;

			// Token: 0x04007FC0 RID: 32704
			protected EnchantmentsType eEnchantmentsType;

			// Token: 0x04007FC1 RID: 32705
			protected GameObject itemParent;

			// Token: 0x04007FC2 RID: 32706
			protected ComItem comItem;

			// Token: 0x04007FC3 RID: 32707
			protected GameObject goSelected;

			// Token: 0x04007FC4 RID: 32708
			private Text m_kName;

			// Token: 0x04007FC5 RID: 32709
			private Text m_kLv;

			// Token: 0x04007FC6 RID: 32710
			private GameObject m_goNewMark;

			// Token: 0x04007FC7 RID: 32711
			private UIGray comGray;

			// Token: 0x04007FC8 RID: 32712
			private Button button;
		}
	}
}
