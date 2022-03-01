using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019CF RID: 6607
	public class RandomTreasureAtlas : ClientFrame
	{
		// Token: 0x060102D7 RID: 66263 RVA: 0x00482B10 File Offset: 0x00480F10
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.mThisMapModel = (this.userData as RandomTreasureMapModel);
			}
			this._BindUIEvent();
			this._InitView();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTreasureAtlasOpen, null, null, null, null);
		}

		// Token: 0x060102D8 RID: 66264 RVA: 0x00482B4D File Offset: 0x00480F4D
		protected override void _OnCloseFrame()
		{
			this._ClearData();
			this._UnBindUIEvent();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTreasureAtlasClose, null, null, null, null);
		}

		// Token: 0x060102D9 RID: 66265 RVA: 0x00482B6E File Offset: 0x00480F6E
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/RandomTreasureFrame/RandomTreasureAtlas";
		}

		// Token: 0x060102DA RID: 66266 RVA: 0x00482B75 File Offset: 0x00480F75
		private void _BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTreasureAtlasInfoSync, new ClientEventSystem.UIEventHandler(this._OnTreasureSyncAtlasInfo));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnChangeTreasureDigSelectMap, new ClientEventSystem.UIEventHandler(this._OnChangeTreasureDigSelectMap));
		}

		// Token: 0x060102DB RID: 66267 RVA: 0x00482BAD File Offset: 0x00480FAD
		private void _UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTreasureAtlasInfoSync, new ClientEventSystem.UIEventHandler(this._OnTreasureSyncAtlasInfo));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnChangeTreasureDigSelectMap, new ClientEventSystem.UIEventHandler(this._OnChangeTreasureDigSelectMap));
		}

		// Token: 0x060102DC RID: 66268 RVA: 0x00482BE8 File Offset: 0x00480FE8
		private void _InitView()
		{
			this.mapModelList = DataManager<RandomTreasureDataManager>.GetInstance().GetTotalMapModelList();
			if (this.mapModelList == null)
			{
				return;
			}
			if (this.mRandomTreasureSelectMapList == null)
			{
				this.mRandomTreasureSelectMapList = new List<ComRandomTreasureSelectMap>();
			}
			else
			{
				this.mRandomTreasureSelectMapList.Clear();
			}
			for (int i = 0; i < this.mapModelList.Count; i++)
			{
				if (this.mapModelList[i] == null)
				{
					Logger.LogErrorFormat("[RandomTreasureAtlas] - _InitView mapModel is null, index is {0}", new object[]
					{
						i
					});
				}
				else
				{
					GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("UIFlatten/Prefabs/RandomTreasureFrame/RandomTreasureSelectMap", true, 0U);
					Utility.AttachTo(gameObject, this.mContent, false);
					if (!(gameObject == null))
					{
						ComRandomTreasureSelectMap component = gameObject.GetComponent<ComRandomTreasureSelectMap>();
						if (this.mRandomTreasureSelectMapList != null && component != null)
						{
							this.mRandomTreasureSelectMapList.Add(component);
						}
					}
				}
			}
			if (this.mSelectMapMask)
			{
				this.mSelectMapMask.transform.SetAsLastSibling();
			}
		}

		// Token: 0x060102DD RID: 66269 RVA: 0x00482D00 File Offset: 0x00481100
		private void _RefreshData()
		{
			this.mapModelList = DataManager<RandomTreasureDataManager>.GetInstance().GetTotalMapModelList();
			if (this.mapModelList == null)
			{
				return;
			}
			if (this.mRandomTreasureSelectMapList == null)
			{
				return;
			}
			int count = this.mRandomTreasureSelectMapList.Count;
			int count2 = this.mapModelList.Count;
			if (count != count2)
			{
				Logger.LogErrorFormat("[RandomTreasureAtlas] - RefreshData selectMap count is {0}, mapModel count is {1}", new object[]
				{
					count,
					count2
				});
				return;
			}
			for (int i = 0; i < count2; i++)
			{
				RandomTreasureMapModel model = this.mapModelList[i];
				ComRandomTreasureSelectMap comRandomTreasureSelectMap = this.mRandomTreasureSelectMapList[i];
				if (!(comRandomTreasureSelectMap == null))
				{
					if (comRandomTreasureSelectMap != null)
					{
						comRandomTreasureSelectMap.RefreshView(model);
					}
				}
			}
		}

		// Token: 0x060102DE RID: 66270 RVA: 0x00482DCC File Offset: 0x004811CC
		private void _ClearData()
		{
			if (this.mapModelList != null)
			{
				this.mapModelList.Clear();
				this.mapModelList = null;
			}
			this.mThisMapModel = null;
			if (this.mRandomTreasureSelectMapList != null)
			{
				for (int i = 0; i < this.mRandomTreasureSelectMapList.Count; i++)
				{
					ComRandomTreasureSelectMap comRandomTreasureSelectMap = this.mRandomTreasureSelectMapList[i];
					if (comRandomTreasureSelectMap != null)
					{
						comRandomTreasureSelectMap.ReleaseThisMapSelect();
					}
				}
				this.mRandomTreasureSelectMapList.Clear();
			}
			this.mThisSelectMap = null;
		}

		// Token: 0x060102DF RID: 66271 RVA: 0x00482E58 File Offset: 0x00481258
		private void _ResetSelectMaskPos(bool bShow)
		{
			if (this.mSelectMapMask)
			{
				if (!bShow)
				{
					this.mSelectMapMask.CustomActive(false);
					return;
				}
				if (this.mThisSelectMap == null)
				{
					return;
				}
				RectTransform component = this.mSelectMapMask.GetComponent<RectTransform>();
				RectTransform component2 = this.mThisSelectMap.gameObject.GetComponent<RectTransform>();
				if (component == null || component2 == null)
				{
					return;
				}
				component.anchoredPosition = component2.anchoredPosition;
				this.mSelectMapMask.CustomActive(true);
			}
		}

		// Token: 0x060102E0 RID: 66272 RVA: 0x00482EE8 File Offset: 0x004812E8
		private void _ResetSelectMaskEffect(bool bShow)
		{
			if (this.mSelectMapMaskEffUI)
			{
				if (bShow)
				{
					this.mSelectMapMaskEffUI.CustomActive(false);
					this.mSelectMapMaskEffUI.CustomActive(true);
				}
				else
				{
					this.mSelectMapMaskEffUI.CustomActive(false);
				}
			}
		}

		// Token: 0x060102E1 RID: 66273 RVA: 0x00482F34 File Offset: 0x00481334
		private void _TrySetChangeSelectMap(ComRandomTreasureSelectMap selectMap)
		{
			if (selectMap == null)
			{
				return;
			}
			this.mThisSelectMap = selectMap;
			this._ResetSelectMaskPos(true);
		}

		// Token: 0x060102E2 RID: 66274 RVA: 0x00482F54 File Offset: 0x00481354
		private void _TrySetChangeSelectMap()
		{
			if (this.mRandomTreasureSelectMapList == null)
			{
				return;
			}
			if (this.mThisSelectMap == null && this.mThisMapModel != null)
			{
				for (int i = 0; i < this.mRandomTreasureSelectMapList.Count; i++)
				{
					ComRandomTreasureSelectMap comRandomTreasureSelectMap = this.mRandomTreasureSelectMapList[i];
					if (!(comRandomTreasureSelectMap == null))
					{
						if (comRandomTreasureSelectMap.GetCurrMapModel() != null)
						{
							if (comRandomTreasureSelectMap.GetCurrMapModel().mapId == this.mThisMapModel.mapId)
							{
								this.mThisSelectMap = comRandomTreasureSelectMap;
								break;
							}
						}
					}
				}
			}
			this._ResetSelectMaskPos(true);
		}

		// Token: 0x060102E3 RID: 66275 RVA: 0x00483001 File Offset: 0x00481401
		private void _OnTreasureSyncAtlasInfo(UIEvent uiEvent)
		{
			this._RefreshData();
			this._TrySetChangeSelectMap();
		}

		// Token: 0x060102E4 RID: 66276 RVA: 0x00483010 File Offset: 0x00481410
		private void _OnChangeTreasureDigSelectMap(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			ComRandomTreasureSelectMap comRandomTreasureSelectMap = uiEvent.Param1 as ComRandomTreasureSelectMap;
			if (comRandomTreasureSelectMap == null)
			{
				return;
			}
			this._TrySetChangeSelectMap(comRandomTreasureSelectMap);
		}

		// Token: 0x060102E5 RID: 66277 RVA: 0x00483044 File Offset: 0x00481444
		protected override void _bindExUI()
		{
			this.mMaskClose = this.mBind.GetCom<Button>("MaskClose");
			if (null != this.mMaskClose)
			{
				this.mMaskClose.onClick.AddListener(new UnityAction(this._onMaskCloseButtonClick));
			}
			this.mComUIFade = this.mBind.GetCom<ComRandomTreasureUIFade>("ComUIFade");
			this.mContent = this.mBind.GetGameObject("Content");
			this.mSelectMapMask = this.mBind.GetGameObject("SelectMapMask");
			this.mSelectMapMaskEffUI = this.mBind.GetGameObject("SelectMapMaskEffUI");
			this.mBtnClose = this.mBind.GetCom<Button>("BtnClose");
			if (null != this.mBtnClose)
			{
				this.mBtnClose.onClick.AddListener(new UnityAction(this._onBtnCloseButtonClick));
			}
			if (this.blackMask != null)
			{
				this.mParentBlackMask = this.blackMask.GetComponent<Button>();
				if (this.mParentBlackMask)
				{
					this.mParentBlackMask.onClick.AddListener(new UnityAction(this._onBtnParentMaskClick));
				}
			}
		}

		// Token: 0x060102E6 RID: 66278 RVA: 0x00483180 File Offset: 0x00481580
		protected override void _unbindExUI()
		{
			if (null != this.mMaskClose)
			{
				this.mMaskClose.onClick.RemoveListener(new UnityAction(this._onMaskCloseButtonClick));
			}
			this.mMaskClose = null;
			this.mComUIFade = null;
			this.mContent = null;
			this.mSelectMapMask = null;
			this.mSelectMapMaskEffUI = null;
			if (null != this.mBtnClose)
			{
				this.mBtnClose.onClick.RemoveListener(new UnityAction(this._onBtnCloseButtonClick));
			}
			this.mBtnClose = null;
			if (null != this.mParentBlackMask)
			{
				this.mParentBlackMask.onClick.RemoveListener(new UnityAction(this._onBtnParentMaskClick));
			}
			this.mParentBlackMask = null;
		}

		// Token: 0x060102E7 RID: 66279 RVA: 0x00483245 File Offset: 0x00481645
		private void _onMaskCloseButtonClick()
		{
			base.Close(false);
		}

		// Token: 0x060102E8 RID: 66280 RVA: 0x0048324E File Offset: 0x0048164E
		private void _onBtnCloseButtonClick()
		{
		}

		// Token: 0x060102E9 RID: 66281 RVA: 0x00483250 File Offset: 0x00481650
		private void _onBtnParentMaskClick()
		{
			if (this.GetState() == EFrameState.Open)
			{
				base.Close(false);
			}
		}

		// Token: 0x0400A391 RID: 41873
		public const string SELECT_SHOW_MAP_RES_PATH = "UIFlatten/Prefabs/RandomTreasureFrame/RandomTreasureSelectMap";

		// Token: 0x0400A392 RID: 41874
		public const string ATLET_FRAME_PATH = "UIFlatten/Prefabs/RandomTreasureFrame/RandomTreasureAtlas";

		// Token: 0x0400A393 RID: 41875
		private List<RandomTreasureMapModel> mapModelList;

		// Token: 0x0400A394 RID: 41876
		private RandomTreasureMapModel mThisMapModel;

		// Token: 0x0400A395 RID: 41877
		private List<ComRandomTreasureSelectMap> mRandomTreasureSelectMapList = new List<ComRandomTreasureSelectMap>();

		// Token: 0x0400A396 RID: 41878
		private ComRandomTreasureSelectMap mThisSelectMap;

		// Token: 0x0400A397 RID: 41879
		private Button mMaskClose;

		// Token: 0x0400A398 RID: 41880
		private ComRandomTreasureUIFade mComUIFade;

		// Token: 0x0400A399 RID: 41881
		private GameObject mContent;

		// Token: 0x0400A39A RID: 41882
		private GameObject mSelectMapMask;

		// Token: 0x0400A39B RID: 41883
		private GameObject mSelectMapMaskEffUI;

		// Token: 0x0400A39C RID: 41884
		private Button mBtnClose;

		// Token: 0x0400A39D RID: 41885
		private Button mParentBlackMask;
	}
}
