using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019D6 RID: 6614
	public class RandomTreasureRaffle : ClientFrame
	{
		// Token: 0x0601033E RID: 66366 RVA: 0x0048506E File Offset: 0x0048346E
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.digSiteModel = (this.userData as RandomTreasureMapDigSiteModel);
			}
			this._InitView();
			this._BindUIEvent();
		}

		// Token: 0x0601033F RID: 66367 RVA: 0x00485098 File Offset: 0x00483498
		protected override void _OnCloseFrame()
		{
			this._ClearData();
			this._UnBindUIEvent();
		}

		// Token: 0x06010340 RID: 66368 RVA: 0x004850A6 File Offset: 0x004834A6
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/RandomTreasureFrame/RandomTreasureRaffle";
		}

		// Token: 0x06010341 RID: 66369 RVA: 0x004850B0 File Offset: 0x004834B0
		private void _ClearData()
		{
			this.digSiteModel = null;
			this.titleShowItem = null;
			this.tr_raffle_must_require_desc = string.Empty;
			this.tr_raffle_gold_box_desc = string.Empty;
			this.tr_raffle_silver_box_desc = string.Empty;
			if (this.mComUIGrids != null)
			{
				this.mComUIGrids.SetElementAmount(0);
			}
		}

		// Token: 0x06010342 RID: 66370 RVA: 0x0048510C File Offset: 0x0048350C
		private void _BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnWatchRefreshDigSite, new ClientEventSystem.UIEventHandler(this._OnWatchRefreshDigSite));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnOpenTreasureDigSite, new ClientEventSystem.UIEventHandler(this._OnOpenTreasureDigSite));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTreasureRaffleStart, new ClientEventSystem.UIEventHandler(this._OnTreasureRaffleStart));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTreasureRaffleEnd, new ClientEventSystem.UIEventHandler(this._OnTreasureRaffleEnd));
		}

		// Token: 0x06010343 RID: 66371 RVA: 0x00485188 File Offset: 0x00483588
		private void _UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnWatchRefreshDigSite, new ClientEventSystem.UIEventHandler(this._OnWatchRefreshDigSite));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnOpenTreasureDigSite, new ClientEventSystem.UIEventHandler(this._OnOpenTreasureDigSite));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTreasureRaffleStart, new ClientEventSystem.UIEventHandler(this._OnTreasureRaffleStart));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTreasureRaffleEnd, new ClientEventSystem.UIEventHandler(this._OnTreasureRaffleEnd));
		}

		// Token: 0x06010344 RID: 66372 RVA: 0x00485204 File Offset: 0x00483604
		private void _InitView()
		{
			if (this.mComUIGrids != null && this.mGridsBoard != null)
			{
				RectTransform component = this.mComUIGrids.gameObject.GetComponent<RectTransform>();
				if (component)
				{
					component.sizeDelta = new Vector2(this.mGridsBoard.GridContentSizeX, this.mGridsBoard.GridContentSizeY);
				}
				this.mComUIGrids.m_elementSpacing = new Vector2(this.mGridsBoard.mGridSpace, this.mGridsBoard.mGridSpace);
			}
			if (this.mGridsBoard != null)
			{
				this.mGridsBoard.InitView();
			}
			this._SetDigButtonEnable(true);
			this._SetSkipAnimToggleActive();
			this.tr_raffle_must_require_desc = TR.Value("random_treasure_raffle_must_require_desc");
			this.tr_raffle_gold_box_desc = TR.Value("random_treasure_raffle_gold_box");
			this.tr_raffle_silver_box_desc = TR.Value("random_treasure_raffle_silver_box");
		}

		// Token: 0x06010345 RID: 66373 RVA: 0x004852F0 File Offset: 0x004836F0
		private void _ChangeDigSiteTypeIcon(DigType digType)
		{
			bool flag = digType == DigType.DIG_GLOD;
			bool flag2 = digType == DigType.DIG_SILVER;
			if (this.mGoldTex)
			{
				this.mGoldTex.enabled = (flag && !flag2);
			}
			if (this.mGoldBtnImg)
			{
				this.mGoldBtnImg.enabled = (flag && !flag2);
			}
			if (this.mSilverTex)
			{
				this.mSilverTex.enabled = (!flag && flag2);
			}
			if (this.mSilverBtnImg)
			{
				this.mSilverBtnImg.enabled = (!flag && flag2);
			}
		}

		// Token: 0x06010346 RID: 66374 RVA: 0x004853A4 File Offset: 0x004837A4
		private void _ChangeDigSiteTypeName(DigType digType)
		{
			if (this.mFrameTitle == null)
			{
				return;
			}
			if (digType == DigType.DIG_GLOD)
			{
				this.mFrameTitle.text = this.tr_raffle_gold_box_desc;
			}
			else if (digType == DigType.DIG_SILVER)
			{
				this.mFrameTitle.text = this.tr_raffle_silver_box_desc;
			}
			else
			{
				this.mFrameTitle.text = "宝箱";
			}
		}

		// Token: 0x06010347 RID: 66375 RVA: 0x00485410 File Offset: 0x00483810
		private void _SetDigButtonEnable(bool bEnable)
		{
			if (this.mDigBtn)
			{
				this.mDigBtn.enabled = bEnable;
			}
			if (this.mDigBtnGray)
			{
				this.mDigBtnGray.enabled = !bEnable;
			}
			if (this.mDigBtnEffui)
			{
				this.mDigBtnEffui.CustomActive(bEnable);
			}
		}

		// Token: 0x06010348 RID: 66376 RVA: 0x00485474 File Offset: 0x00483874
		private void _SetSkipAnimToggleActive()
		{
			bool bActive = false;
			if (this.digSiteModel != null && this.digSiteModel.type == DigType.DIG_SILVER)
			{
				bActive = true;
			}
			if (this.mSkipAnimToggle)
			{
				this.mSkipAnimToggle.CustomActive(bActive);
				this.mSkipAnimToggle.isOn = DataManager<RandomTreasureDataManager>.GetInstance().BSilverRaffleSkipAnim;
			}
		}

		// Token: 0x06010349 RID: 66377 RVA: 0x004854D4 File Offset: 0x004838D4
		private void _RefreshData()
		{
			if (this.digSiteModel == null)
			{
				Logger.LogError("[RandomTreasureRaffle] - RefreshData digSiteModel is null");
				return;
			}
			if (this.digSiteModel.itemSDatas == null)
			{
				Logger.LogError("[RandomTreasureRaffle] - RefreshData digSiteModel.itemIds is null");
				return;
			}
			if (this.mComUIGrids == null)
			{
				Logger.LogError("[RandomTreasureRaffle] - RefreshData mComUIGrids is null");
				return;
			}
			List<ItemSimpleData> digSiteItems = this.digSiteModel.itemSDatas;
			if (!this.mComUIGrids.IsInitialised())
			{
				this.mComUIGrids.Initialize();
				this.mComUIGrids.onBindItem = ((GameObject go) => go.GetComponent<RandomTreasureInfo>());
			}
			this.mComUIGrids.onItemVisiable = delegate(ComUIListElementScript var)
			{
				if (var == null)
				{
					return;
				}
				int index = var.m_index;
				if (index >= 0 && index < digSiteItems.Count)
				{
					ItemSimpleData itemSimpleData = digSiteItems[index];
					if (itemSimpleData == null)
					{
						return;
					}
					if (this.mGridsBoard == null)
					{
						return;
					}
					RandomTreasureInfo randomTreasureInfo = var.gameObjectBindScript as RandomTreasureInfo;
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(itemSimpleData.ItemID, 100, 0);
					randomTreasureInfo.SetInfoTitleImg(itemData.Icon);
					randomTreasureInfo.onTitleBtnClick = delegate()
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
					};
				}
			};
			this.mComUIGrids.SetElementAmount(digSiteItems.Count);
			if (this.mTitleInfo == null)
			{
				return;
			}
			if (this.digSiteModel.type == DigType.DIG_GLOD)
			{
				this.titleShowItem = DataManager<RandomTreasureDataManager>.GetInstance().GoldRaffleMustGetItem;
			}
			else if (this.digSiteModel.type == DigType.DIG_SILVER)
			{
				this.titleShowItem = DataManager<RandomTreasureDataManager>.GetInstance().SilverRaffleMustGetItem;
			}
			this._ChangeDigSiteTypeIcon(this.digSiteModel.type);
			this._ChangeDigSiteTypeName(this.digSiteModel.type);
			if (this.titleShowItem != null)
			{
				this.mTitleInfo.SetInfoContent(string.Format(this.tr_raffle_must_require_desc, this.titleShowItem.Count, this.titleShowItem.Name));
				this.mTitleInfo.CustomActive(true);
			}
			else
			{
				this.mTitleInfo.CustomActive(false);
			}
		}

		// Token: 0x0601034A RID: 66378 RVA: 0x00485690 File Offset: 0x00483A90
		private void _StartPlayRaffleAnim(int itemIndex, int itemId, int itemCount, bool bSkipAnim = false)
		{
			if (this.mGridsBoard != null)
			{
				List<ItemSimpleData> list = new List<ItemSimpleData>();
				if (this.titleShowItem != null)
				{
					list.Add(this.titleShowItem);
				}
				this.mGridsBoard.StartSelectAnim(itemIndex, itemId, itemCount, list, bSkipAnim);
			}
		}

		// Token: 0x0601034B RID: 66379 RVA: 0x004856DC File Offset: 0x00483ADC
		private void _OnWatchRefreshDigSite(UIEvent uiEvent)
		{
			if (uiEvent.Param1 == null)
			{
				return;
			}
			RandomTreasureMapDigSiteModel randomTreasureMapDigSiteModel = uiEvent.Param1 as RandomTreasureMapDigSiteModel;
			if (randomTreasureMapDigSiteModel != null)
			{
				this.digSiteModel = randomTreasureMapDigSiteModel;
				this._RefreshData();
			}
		}

		// Token: 0x0601034C RID: 66380 RVA: 0x00485714 File Offset: 0x00483B14
		private void _OnOpenTreasureDigSite(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			if (uiEvent.Param1 == null || uiEvent.Param2 == null || uiEvent.Param3 == null)
			{
				return;
			}
			int itemIndex = (int)uiEvent.Param1;
			int itemId = (int)uiEvent.Param2;
			int itemCount = (int)uiEvent.Param3;
			bool bSkipAnim = false;
			if (this.digSiteModel != null && this.digSiteModel.type == DigType.DIG_SILVER)
			{
				bSkipAnim = DataManager<RandomTreasureDataManager>.GetInstance().BSilverRaffleSkipAnim;
			}
			this._StartPlayRaffleAnim(itemIndex, itemId, itemCount, bSkipAnim);
		}

		// Token: 0x0601034D RID: 66381 RVA: 0x004857A1 File Offset: 0x00483BA1
		private void _OnTreasureRaffleStart(UIEvent uiEvent)
		{
			this._SetDigButtonEnable(false);
		}

		// Token: 0x0601034E RID: 66382 RVA: 0x004857AA File Offset: 0x00483BAA
		private void _OnTreasureRaffleEnd(UIEvent uiEvent)
		{
			this._SetDigButtonEnable(true);
			base.Close(false);
		}

		// Token: 0x0601034F RID: 66383 RVA: 0x004857BC File Offset: 0x00483BBC
		protected override void _bindExUI()
		{
			this.mMaskClose = this.mBind.GetCom<Button>("MaskClose");
			this.mMaskClose.onClick.AddListener(new UnityAction(this._onMaskCloseButtonClick));
			this.mComUIFade = this.mBind.GetCom<ComRandomTreasureUIFade>("ComUIFade");
			this.mComUIGrids = this.mBind.GetCom<ComUIListScript>("ComUIGrids");
			this.mGridsBoard = this.mBind.GetCom<ComRandomTreasureRaffleBoard>("GridsBoard");
			this.mDigBtn = this.mBind.GetCom<Button>("DigBtn");
			this.mDigBtn.onClick.AddListener(new UnityAction(this._onDigBtnButtonClick));
			this.mDigBtnGray = this.mBind.GetCom<UIGray>("DigBtnGray");
			this.mGoldBtnImg = this.mBind.GetCom<Image>("goldBtnImg");
			this.mSilverBtnImg = this.mBind.GetCom<Image>("silverBtnImg");
			this.mDigBtnCD = this.mBind.GetCom<SetComButtonCD>("DigBtnCD");
			this.mDigBtnEffui = this.mBind.GetGameObject("digBtnEffui");
			this.mSilverTex = this.mBind.GetCom<Image>("silverTex");
			this.mGoldTex = this.mBind.GetCom<Image>("goldTex");
			this.mTitleInfo = this.mBind.GetCom<RandomTreasureInfo>("TitleInfo");
			this.mFrameTitle = this.mBind.GetCom<Text>("FrameTitle");
			this.mSkipAnimToggle = this.mBind.GetCom<Toggle>("SkipAnimToggle");
			if (null != this.mSkipAnimToggle)
			{
				this.mSkipAnimToggle.onValueChanged.AddListener(new UnityAction<bool>(this._onSkipAnimToggleToggleValueChange));
			}
		}

		// Token: 0x06010350 RID: 66384 RVA: 0x00485978 File Offset: 0x00483D78
		protected override void _unbindExUI()
		{
			this.mMaskClose.onClick.RemoveListener(new UnityAction(this._onMaskCloseButtonClick));
			this.mMaskClose = null;
			this.mComUIFade = null;
			this.mComUIGrids = null;
			this.mGridsBoard = null;
			this.mDigBtn.onClick.RemoveListener(new UnityAction(this._onDigBtnButtonClick));
			this.mDigBtn = null;
			this.mDigBtnGray = null;
			this.mGoldBtnImg = null;
			this.mSilverBtnImg = null;
			this.mDigBtnCD = null;
			this.mDigBtnEffui = null;
			this.mSilverTex = null;
			this.mGoldTex = null;
			this.mTitleInfo = null;
			this.mFrameTitle = null;
			if (null != this.mSkipAnimToggle)
			{
				this.mSkipAnimToggle.onValueChanged.RemoveListener(new UnityAction<bool>(this._onSkipAnimToggleToggleValueChange));
			}
			this.mSkipAnimToggle = null;
		}

		// Token: 0x06010351 RID: 66385 RVA: 0x00485A53 File Offset: 0x00483E53
		private void _onMaskCloseButtonClick()
		{
			if (this.mGridsBoard != null && this.mGridsBoard.GridSelectAnimPlaying)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("randrom_treasure_raffle_anim_playing"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			base.Close(false);
		}

		// Token: 0x06010352 RID: 66386 RVA: 0x00485A90 File Offset: 0x00483E90
		private void _onDigBtnButtonClick()
		{
			if (this.mDigBtnCD == null || !this.mDigBtnCD.IsBtnWork())
			{
				return;
			}
			if (this.digSiteModel != null)
			{
				int num = DataManager<RandomTreasureDataManager>.GetInstance().Gold_Treasure_Item_Id;
				if (this.digSiteModel.type == DigType.DIG_GLOD)
				{
					num = DataManager<RandomTreasureDataManager>.GetInstance().Gold_Treasure_Item_Id;
				}
				else if (this.digSiteModel.type == DigType.DIG_SILVER)
				{
					num = DataManager<RandomTreasureDataManager>.GetInstance().Silver_Treasure_Item_Id;
				}
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(num, true);
				int num2 = 1;
				if (ownedItemCount < num2)
				{
					DataManager<RandomTreasureDataManager>.GetInstance().ReqFastMallBuy(num);
				}
				else
				{
					DataManager<RandomTreasureDataManager>.GetInstance().ReqOpenTreasureDigSite(this.digSiteModel);
				}
				if (this.mDigBtnCD != null)
				{
					this.mDigBtnCD.StartBtCD();
				}
			}
		}

		// Token: 0x06010353 RID: 66387 RVA: 0x00485B64 File Offset: 0x00483F64
		private void _onSkipAnimToggleToggleValueChange(bool changed)
		{
			DataManager<RandomTreasureDataManager>.GetInstance().BSilverRaffleSkipAnim = changed;
		}

		// Token: 0x0400A3D5 RID: 41941
		public const string RAFFLE_FRAME_PATH = "UIFlatten/Prefabs/RandomTreasureFrame/RandomTreasureRaffle";

		// Token: 0x0400A3D6 RID: 41942
		private RandomTreasureMapDigSiteModel digSiteModel;

		// Token: 0x0400A3D7 RID: 41943
		private ItemSimpleData titleShowItem;

		// Token: 0x0400A3D8 RID: 41944
		private string tr_raffle_must_require_desc = "开启后必定获得{0}个{1}";

		// Token: 0x0400A3D9 RID: 41945
		private string tr_raffle_gold_box_desc = "金宝箱";

		// Token: 0x0400A3DA RID: 41946
		private string tr_raffle_silver_box_desc = "银宝箱";

		// Token: 0x0400A3DB RID: 41947
		private Button mMaskClose;

		// Token: 0x0400A3DC RID: 41948
		private ComRandomTreasureUIFade mComUIFade;

		// Token: 0x0400A3DD RID: 41949
		private ComUIListScript mComUIGrids;

		// Token: 0x0400A3DE RID: 41950
		private ComRandomTreasureRaffleBoard mGridsBoard;

		// Token: 0x0400A3DF RID: 41951
		private Button mDigBtn;

		// Token: 0x0400A3E0 RID: 41952
		private UIGray mDigBtnGray;

		// Token: 0x0400A3E1 RID: 41953
		private Image mGoldBtnImg;

		// Token: 0x0400A3E2 RID: 41954
		private Image mSilverBtnImg;

		// Token: 0x0400A3E3 RID: 41955
		private SetComButtonCD mDigBtnCD;

		// Token: 0x0400A3E4 RID: 41956
		private GameObject mDigBtnEffui;

		// Token: 0x0400A3E5 RID: 41957
		private Image mSilverTex;

		// Token: 0x0400A3E6 RID: 41958
		private Image mGoldTex;

		// Token: 0x0400A3E7 RID: 41959
		private RandomTreasureInfo mTitleInfo;

		// Token: 0x0400A3E8 RID: 41960
		private Text mFrameTitle;

		// Token: 0x0400A3E9 RID: 41961
		private Toggle mSkipAnimToggle;
	}
}
