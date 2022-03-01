using System;
using System.Collections;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using Spine;
using Spine.Unity;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015C1 RID: 5569
	public class EquipHandbookFrame : ClientFrame
	{
		// Token: 0x0600D9D5 RID: 55765 RVA: 0x0036AD94 File Offset: 0x00369194
		public static void OpenLinkFrame(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return;
			}
			try
			{
				DataManager<EquipHandbookDataManager>.GetInstance().TabSelectedIndex = int.Parse(value);
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<EquipHandbookFrame>(null, false);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<EquipHandbookFrame>(FrameLayer.Middle, null, string.Empty);
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
			}
		}

		// Token: 0x0600D9D6 RID: 55766 RVA: 0x0036AE04 File Offset: 0x00369204
		protected override void _bindExUI()
		{
			this.mTabRoot = this.mBind.GetGameObject("tabRoot");
			this.mLeftRoot = this.mBind.GetGameObject("leftRoot");
			this.mRightSourceRoot = this.mBind.GetGameObject("rightSourceRoot");
			this.mRightCommentRoot = this.mBind.GetGameObject("rightCommentRoot");
			this.mRightPreviewRoot = this.mBind.GetGameObject("rightPreviewRoot");
			this.mTabName = this.mBind.GetCom<Text>("tabName");
			this.mClosePreviewButton = this.mBind.GetCom<Button>("closePreviewButton");
			this.mClosePreviewButton.onClick.AddListener(new UnityAction(this._onClosePreviewButtonButtonClick));
			this.mTryEquipButton = this.mBind.GetCom<Button>("tryEquipButton");
			this.mTryEquipButton.onClick.AddListener(new UnityAction(this._onTryEquipButtonButtonClick));
			this.mDetailButton = this.mBind.GetCom<Button>("detailButton");
			this.mDetailButton.onClick.AddListener(new UnityAction(this._onDetailButtonButtonClick));
			this.mLeftGirdToggleGroup = this.mBind.GetCom<ToggleGroup>("leftGirdToggleGroup");
			this.mRightRoot = this.mBind.GetCom<CanvasGroup>("rightRoot");
			this.mTabToggleGroup = this.mBind.GetCom<ToggleGroup>("tabToggleGroup");
			this.mDetailEquip = this.mBind.GetCom<ComEquipHandbookItem>("detailEquip");
			this.mSourceEmptyRoot = this.mBind.GetGameObject("sourceEmptyRoot");
			this.mCommentEmptyRoot = this.mBind.GetGameObject("commentEmptyRoot");
			this.mCloseButton = this.mBind.GetCom<Button>("closeButton");
			this.mCloseButton.onClick.AddListener(new UnityAction(this._onCloseButtonButtonClick));
			this.mModelRT = this.mBind.GetGameObject("modelRT");
			this.mEquipName = this.mBind.GetCom<Text>("equipName");
			this.mArrowState = this.mBind.GetCom<Image>("ArrowState");
			this.mDifferenceScore = this.mBind.GetCom<Text>("differenceScore");
			this.mTatleScore = this.mBind.GetCom<Text>("tatleScore");
			this.mSocreRoot = this.mBind.GetGameObject("SocreRoot");
			this.mSkeletonAnimation = this.mBind.GetCom<SkeletonAnimation>("SkeletonAnimation");
			this.mLeftRootComUIList = this.mBind.GetCom<ComUIListScript>("LeftRootComUIList");
			this.mSecendsocreRoot = this.mBind.GetGameObject("secendsocreRoot");
			this.mPerfectRoot = this.mBind.GetGameObject("perfectRoot");
			this.mLeftImg = this.mBind.GetCom<Image>("leftImg");
			this.mRightImg = this.mBind.GetCom<Image>("rightImg");
			this.mLeftRootScrollRect = this.mBind.GetCom<ScrollRect>("LeftRootScrollRect");
			this.mContent = this.mBind.GetCom<RectTransform>("Content");
			this.mSRScrollRect = this.mBind.GetCom<ScrollRect>("SRScrollRect");
			this.mCRScrollRect = this.mBind.GetCom<ScrollRect>("CRScrollRect");
		}

		// Token: 0x0600D9D7 RID: 55767 RVA: 0x0036B144 File Offset: 0x00369544
		protected override void _unbindExUI()
		{
			this.mTabRoot = null;
			this.mLeftRoot = null;
			this.mRightSourceRoot = null;
			this.mRightCommentRoot = null;
			this.mRightPreviewRoot = null;
			this.mTabName = null;
			this.mClosePreviewButton.onClick.RemoveListener(new UnityAction(this._onClosePreviewButtonButtonClick));
			this.mClosePreviewButton = null;
			this.mTryEquipButton.onClick.RemoveListener(new UnityAction(this._onTryEquipButtonButtonClick));
			this.mTryEquipButton = null;
			this.mDetailButton.onClick.RemoveListener(new UnityAction(this._onDetailButtonButtonClick));
			this.mDetailButton = null;
			this.mLeftGirdToggleGroup = null;
			this.mRightRoot = null;
			this.mTabToggleGroup = null;
			this.mDetailEquip = null;
			this.mSourceEmptyRoot = null;
			this.mCommentEmptyRoot = null;
			this.mCloseButton.onClick.RemoveListener(new UnityAction(this._onCloseButtonButtonClick));
			this.mCloseButton = null;
			this.mModelRT = null;
			this.mEquipName = null;
			this.mArrowState = null;
			this.mDifferenceScore = null;
			this.mTatleScore = null;
			this.mSocreRoot = null;
			this.mSkeletonAnimation = null;
			this.mLeftRootComUIList = null;
			this.mSecendsocreRoot = null;
			this.mPerfectRoot = null;
			this.mLeftImg = null;
			this.mRightImg = null;
			this.mLeftRootScrollRect = null;
			this.mContent = null;
			this.mSRScrollRect = null;
			this.mCRScrollRect = null;
		}

		// Token: 0x0600D9D8 RID: 55768 RVA: 0x0036B2A1 File Offset: 0x003696A1
		private void _onClosePreviewButtonButtonClick()
		{
			this.mRightPreviewRoot.CustomActive(false);
			this.mRightRoot.CustomActive(true);
			this._onGirdItemClick(this.itemid, this.mcurrentSelectTab, this.mcurrentSelectItem, false);
		}

		// Token: 0x0600D9D9 RID: 55769 RVA: 0x0036B2D4 File Offset: 0x003696D4
		private void _onTryEquipButtonButtonClick()
		{
			this.mRightPreviewRoot.CustomActive(true);
			this.mRightRoot.CustomActive(false);
			this._setEquipName(this.itemid);
			this._initModel(this.itemid);
		}

		// Token: 0x0600D9DA RID: 55770 RVA: 0x0036B306 File Offset: 0x00369706
		private void _onDetailButtonButtonClick()
		{
			this._showTips(this.itemid);
		}

		// Token: 0x0600D9DB RID: 55771 RVA: 0x0036B314 File Offset: 0x00369714
		private void _onCloseButtonButtonClick()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<EquipHandbookFrame>(this, false);
		}

		// Token: 0x0600D9DC RID: 55772 RVA: 0x0036B322 File Offset: 0x00369722
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/EquipHandbookFrame/EquipHandbookFrame";
		}

		// Token: 0x0600D9DD RID: 55773 RVA: 0x0036B329 File Offset: 0x00369729
		protected override void _OnOpenFrame()
		{
			this.bIsPlayAnimation = false;
			this.mLastSelectedIndex = -1;
			this.mLeftRootComUIList.Initialize();
			this._createTabs();
			this._selectDefalutTab();
		}

		// Token: 0x0600D9DE RID: 55774 RVA: 0x0036B350 File Offset: 0x00369750
		private void _createTabs()
		{
			string prefabPath = this.mBind.GetPrefabPath("tabUnit");
			this.mBind.ClearCacheBinds(prefabPath);
			List<EquipHandbookTabData> equipTabs = DataManager<EquipHandbookDataManager>.GetInstance().equipTabs;
			for (int i = 0; i < equipTabs.Count; i++)
			{
				ComCommonBind comCommonBind = this.mBind.LoadExtraBind(prefabPath);
				Utility.AttachTo(comCommonBind.gameObject, this.mTabRoot, false);
				EquipHandbookTabData data = equipTabs[i];
				if (data != null)
				{
					data.bind = comCommonBind;
					Toggle com = comCommonBind.GetCom<Toggle>("toggle");
					Text com2 = comCommonBind.GetCom<Text>("diablename");
					Text com3 = comCommonBind.GetCom<Text>("name");
					com3.text = data.name;
					com2.text = data.name;
					com.group = this.mTabToggleGroup;
					int index = i;
					com.onValueChanged.RemoveAllListeners();
					com.onValueChanged.AddListener(delegate(bool isOn)
					{
						this._changeTabStatus(isOn, data);
						if (this.mRightPreviewRoot.gameObject.activeSelf)
						{
							this.mRightPreviewRoot.CustomActive(false);
						}
						if (isOn && this.mLastSelectedIndex != index)
						{
							this.mLastSelectedIndex = index;
							DataManager<EquipHandbookDataManager>.GetInstance().TabSelectedIndex = index;
							this._stopCoroutineCurrentTabClick();
							this.mCurrentTabClick = this.mBind.StartCoroutine(this._onTabClickWithAnimate(isOn, data));
						}
					});
				}
			}
		}

		// Token: 0x0600D9DF RID: 55775 RVA: 0x0036B47A File Offset: 0x0036987A
		private void _stopCoroutineCurrentTabClick()
		{
			if (this.mCurrentTabClick != null)
			{
				this.mBind.StopCoroutine(this.mCurrentTabClick);
				this.mCurrentTabClick = null;
			}
		}

		// Token: 0x0600D9E0 RID: 55776 RVA: 0x0036B4A0 File Offset: 0x003698A0
		private void _changeTabStatus(bool isOn, EquipHandbookTabData data)
		{
			ComCommonBind bind = data.bind;
			if (null == bind)
			{
				return;
			}
			GameObject gameObject = bind.GetGameObject("disableRoot");
			GameObject gameObject2 = bind.GetGameObject("enableRoot");
			gameObject.CustomActive(!isOn);
			gameObject2.CustomActive(isOn);
			this.mTabName.text = data.name;
		}

		// Token: 0x0600D9E1 RID: 55777 RVA: 0x0036B4FC File Offset: 0x003698FC
		private void _selectDefalutTab()
		{
			List<EquipHandbookTabData> equipTabs = DataManager<EquipHandbookDataManager>.GetInstance().equipTabs;
			int tabSelectedIndex = DataManager<EquipHandbookDataManager>.GetInstance().TabSelectedIndex;
			if (tabSelectedIndex >= 0 && tabSelectedIndex < equipTabs.Count)
			{
				ComCommonBind bind = equipTabs[tabSelectedIndex].bind;
				if (null != bind)
				{
					Toggle com = bind.GetCom<Toggle>("toggle");
					com.isOn = true;
				}
			}
		}

		// Token: 0x0600D9E2 RID: 55778 RVA: 0x0036B560 File Offset: 0x00369960
		private void _playAnimation()
		{
			this.mSkeletonAnimation.CustomActive(true);
			AnimationState state = this.mSkeletonAnimation.state;
			this.mSkeletonAnimation.skeleton.SetToSetupPose();
			state.ClearTracks();
			state.SetAnimation(0, "tujian", false);
			state.Complete += this.SpineAnimationState_Complete;
		}

		// Token: 0x0600D9E3 RID: 55779 RVA: 0x0036B5BB File Offset: 0x003699BB
		private void SpineAnimationState_Complete(TrackEntry trackEntry)
		{
			this.mSkeletonAnimation.CustomActive(false);
		}

		// Token: 0x0600D9E4 RID: 55780 RVA: 0x0036B5CC File Offset: 0x003699CC
		private void _initModel(int itemid)
		{
			if (this.mModelRT != null && this.m_AvatarRenderer == null)
			{
				this.m_AvatarRenderer = this.mModelRT.GetComponent<GeAvatarRendererEx>();
			}
			JobTable tableItem = Singleton<TableManager>.instance.GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogError("职业ID找不到 " + DataManager<PlayerBaseData>.GetInstance().JobTableID.ToString() + "\n");
			}
			else
			{
				ResTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 == null)
				{
					Logger.LogError("职业ID Mode表 找不到 " + DataManager<PlayerBaseData>.GetInstance().JobTableID.ToString() + "\n");
				}
				else
				{
					this.m_AvatarRenderer.ClearAvatar();
					this.m_AvatarRenderer.LoadAvatar(tableItem2.ModelPath, -1);
					DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromCurrentEquiped(this.m_AvatarRenderer, null, false);
					DataManager<PlayerBaseData>.GetInstance().AvatarEquipWeapon(this.m_AvatarRenderer, DataManager<PlayerBaseData>.GetInstance().JobTableID, itemid, null, false);
					this.m_AvatarRenderer.AttachAvatar("Aureole", "Effects/Scene_effects/Effectui/EffUI_chuangjue_fazhen_JS", "[actor]Orign", false, true, false, 0f);
					this.m_AvatarRenderer.ChangeAction("Anim_Show_Idle", 1f, true);
				}
			}
		}

		// Token: 0x0600D9E5 RID: 55781 RVA: 0x0036B739 File Offset: 0x00369B39
		private void _clearModel()
		{
			if (this.m_AvatarRenderer != null)
			{
				this.m_AvatarRenderer.ClearAvatar();
				this.m_AvatarRenderer = null;
			}
		}

		// Token: 0x0600D9E6 RID: 55782 RVA: 0x0036B760 File Offset: 0x00369B60
		private void _setEquipName(int itemid)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemid, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(tableItem.ID);
				ItemData.QualityInfo qualityInfo = commonItemTableDataByID.GetQualityInfo();
				this.mEquipName.text = TR.Value("equiphandbook_equip_name", commonItemTableDataByID.GetColorName(string.Empty, false), qualityInfo.ColStr);
			}
		}

		// Token: 0x0600D9E7 RID: 55783 RVA: 0x0036B7C8 File Offset: 0x00369BC8
		private bool _setTryOnBtnIsShow(int itemid)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemid, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (tableItem.Type != ItemTable.eType.EQUIP)
				{
					return false;
				}
				if (tableItem.SubType != ItemTable.eSubType.WEAPON)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600D9E8 RID: 55784 RVA: 0x0036B810 File Offset: 0x00369C10
		private IEnumerator _onTabClickWithAnimate(bool isOn, EquipHandbookTabData data)
		{
			this.mSkeletonAnimation.CustomActive(false);
			if (this.bIsPlayAnimation)
			{
				this._clearGirdItems(data);
				this._playAnimation();
				yield return Yielders.GetWaitForSeconds(0.55f);
			}
			this._onTabclick(data);
			yield break;
		}

		// Token: 0x0600D9E9 RID: 55785 RVA: 0x0036B834 File Offset: 0x00369C34
		private void _clearGirdItems(EquipHandbookTabData data)
		{
			string prefabPath = this.mBind.GetPrefabPath("titleRoot");
			string prefabPath2 = this.mBind.GetPrefabPath("girdRoot");
			string prefabPath3 = this.mBind.GetPrefabPath("girdItemPath");
			this.mBind.ClearCacheBinds(prefabPath3);
			this.mBind.ClearCacheBinds(prefabPath2);
			this.mBind.ClearCacheBinds(prefabPath);
			this.mLeftRoot.CustomActive(false);
			this.mRightRoot.CustomActive(false);
			this.mSocreRoot.CustomActive(false);
		}

		// Token: 0x0600D9EA RID: 55786 RVA: 0x0036B8BC File Offset: 0x00369CBC
		private void _onTabclick(EquipHandbookTabData data)
		{
			this.bIsPlayAnimation = true;
			this.mLeftRoot.CustomActive(true);
			this.mRightRoot.CustomActive(true);
			int itemCount = 0;
			List<Vector2> list = new List<Vector2>();
			if (data.isShowEquipScore)
			{
				this.mSocreRoot.CustomActive(true);
				this.mSecendsocreRoot.CustomActive(true);
				this.mPerfectRoot.CustomActive(false);
				itemCount = 1;
				int playerWeaponScore = DataManager<EquipHandbookDataManager>.GetInstance().GetPlayerWeaponScore();
				int playerArmorScore = DataManager<EquipHandbookDataManager>.GetInstance().GetPlayerArmorScore();
				int playerJewelryScore = DataManager<EquipHandbookDataManager>.GetInstance().GetPlayerJewelryScore();
				bool flag = false;
				this.mRecommendEquips = data.GetRecommendedCollect(playerWeaponScore, playerArmorScore, playerJewelryScore, ref flag);
				if (flag)
				{
					this.mSecendsocreRoot.CustomActive(false);
					this.mPerfectRoot.CustomActive(true);
				}
				else
				{
					int num = 0;
					for (int i = 0; i < this.mRecommendEquips.Count; i++)
					{
						num += this.mRecommendEquips[i].baseScore;
					}
					this.mTatleScore.text = num.ToString();
					int num2 = num - DataManager<EquipHandbookDataManager>.GetInstance().sumPlayerEquipCollectScore;
					if (num2 > 0)
					{
						this.mDifferenceScore.text = num2.ToString();
					}
					else
					{
						this.mSecendsocreRoot.CustomActive(false);
						this.mPerfectRoot.CustomActive(true);
					}
				}
				list.Add(this._getCellVector(this.mRecommendEquips.Count));
			}
			else
			{
				this.mSocreRoot.CustomActive(false);
				itemCount = data.collectIDs.Count;
				for (int j = 0; j < itemCount; j++)
				{
					list.Add(this._getCellVector(data.collectIDs[j].itemIDs.Count));
				}
			}
			this.mLeftRootComUIList.ResetContentPosition();
			this.mLeftRootComUIList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0 && itemCount != 0 && item.m_index < itemCount)
				{
					string prefabPath = this.mBind.GetPrefabPath("girdItemPath");
					ComCommonBind component = item.GetComponent<ComCommonBind>();
					GameObject gameObject = component.GetGameObject("EquipHandbookLeftTitleRoot");
					GameObject gameObject2 = component.GetGameObject("EquipHandbookLeftGirdRoot");
					if (data.isShowEquipScore)
					{
						gameObject.CustomActive(false);
						this._createGirdItemUnit(prefabPath, this.mRecommendEquips, gameObject2, data);
					}
					else
					{
						EquipHandbookTabCollectionData equipHandbookTabCollectionData = data.collectIDs[item.m_index];
						if (data.type == EquipHandbookContentTable.eType.Collect)
						{
							gameObject.CustomActive(true);
							ComCommonBind component2 = gameObject.GetComponent<ComCommonBind>();
							Text com = component2.GetCom<Text>("textLevel");
							Text com2 = component2.GetCom<Text>("textName");
							com.text = equipHandbookTabCollectionData.level.ToString();
							com2.text = equipHandbookTabCollectionData.name;
						}
						else
						{
							gameObject.CustomActive(false);
						}
						this._createGirdItemUnit(prefabPath, equipHandbookTabCollectionData.itemIDs, gameObject2, data);
					}
				}
			};
			this.mLeftRootComUIList.SetElementAmount(itemCount, list);
			this._stopCoroutineSelectCurrentLevelGridItem();
			this.mSelectCurrentLevelGridItem = this.mBind.StartCoroutine(this._selectDefauteGridItem(data));
		}

		// Token: 0x0600D9EB RID: 55787 RVA: 0x0036BB1A File Offset: 0x00369F1A
		private void _stopCoroutineSelectCurrentLevelGridItem()
		{
			if (this.mSelectCurrentLevelGridItem != null)
			{
				this.mBind.StopCoroutine(this.mSelectCurrentLevelGridItem);
				this.mSelectCurrentLevelGridItem = null;
			}
		}

		// Token: 0x0600D9EC RID: 55788 RVA: 0x0036BB40 File Offset: 0x00369F40
		private Vector2 _getCellVector(int cellCount)
		{
			float num;
			if (cellCount % 4 != 0)
			{
				num = (float)Math.Ceiling(cellCount / 4);
			}
			else
			{
				num = (float)Math.Ceiling(cellCount / 4) - 1f;
			}
			Vector2 result = default(Vector2);
			result.x = 662f;
			result.y = 223f + num * 213f;
			return result;
		}

		// Token: 0x0600D9ED RID: 55789 RVA: 0x0036BBB8 File Offset: 0x00369FB8
		private void _createGirdItemUnit(string path, List<EquipHandbookEquipItemData> itemIDs, GameObject root, EquipHandbookTabData tabdata)
		{
			if (null == root)
			{
				return;
			}
			ComCommonBind component = root.GetComponent<ComCommonBind>();
			component.ClearCacheBinds(path);
			for (int i = 0; i < itemIDs.Count; i++)
			{
				EquipHandbookEquipItemData equipItemData = itemIDs[i];
				ComCommonBind comCommonBind = component.LoadExtraBind(path);
				Utility.AttachTo(comCommonBind.gameObject, root, false);
				ComEquipHandbookItem com = comCommonBind.GetCom<ComEquipHandbookItem>("equipHandbookItem");
				Toggle com2 = comCommonBind.GetCom<Toggle>("toggle");
				GameObject xuanzhongEffects = comCommonBind.GetGameObject("xuanzhong");
				int itemId = equipItemData.id;
				equipItemData.bind = comCommonBind;
				com.SetItemId(itemId);
				if (tabdata.isShowEquipScore)
				{
					com.gostate.CustomActive(true);
					com.SetItemState(equipItemData);
				}
				else
				{
					com.gostate.CustomActive(false);
				}
				xuanzhongEffects.CustomActive(false);
				com2.group = this.mLeftGirdToggleGroup;
				com2.onValueChanged.RemoveAllListeners();
				com2.onValueChanged.AddListener(delegate(bool isOn)
				{
					xuanzhongEffects.CustomActive(isOn);
					if (isOn)
					{
						this.mSelectItemID = itemId;
						this._onGirdItemClick(itemId, tabdata, equipItemData, true);
					}
				});
				if (this.mSelectItemID == itemId)
				{
					com2.isOn = true;
				}
			}
		}

		// Token: 0x0600D9EE RID: 55790 RVA: 0x0036BD28 File Offset: 0x0036A128
		private IEnumerator _selectDefauteGridItem(EquipHandbookTabData data)
		{
			if (data == null)
			{
				yield break;
			}
			if (data.isShowEquipScore)
			{
				if (this.mRecommendEquips.Count <= 0)
				{
					this.mRightRoot.CustomActive(false);
					yield break;
				}
				ComCommonBind bind2 = this.mRecommendEquips[0].bind;
				if (null == bind2)
				{
					yield break;
				}
				Toggle com = bind2.GetCom<Toggle>("toggle");
				com.isOn = true;
				yield break;
			}
			else
			{
				this.mRightRoot.CustomActive(false);
				float PosYy = 0f;
				float fMinY = this.mContent.GetComponent<RectTransform>().offsetMax.y;
				float fMaxY = this.mContent.GetComponent<RectTransform>().offsetMin.y;
				float fHeight = Math.Abs(fMaxY - fMinY);
				int index = 0;
				int splitLevel = DataManager<EquipHandbookDataManager>.GetInstance().GetSplitLevel(data.collectIDs, (EquipHandbookCollectionTable.eScreenType)data.type);
				if (splitLevel > 0)
				{
					for (int i = 0; i < data.collectIDs.Count; i++)
					{
						float num;
						if (data.collectIDs[i].itemIDs.Count % 4 != 0)
						{
							num = (float)Math.Ceiling(data.collectIDs[i].itemIDs.Count / 4);
						}
						else
						{
							num = (float)Math.Ceiling(data.collectIDs[i].itemIDs.Count / 4) - 1f;
						}
						if (splitLevel == data.collectIDs[i].level)
						{
							index = i;
							float verticalNormalizedPosition = 1f - PosYy / (fHeight - this.fViewPortPos);
							this.mLeftRootScrollRect.verticalNormalizedPosition = verticalNormalizedPosition;
							break;
						}
						PosYy += 223f + num * 213f + 40f;
					}
				}
				yield return Yielders.GetWaitForSeconds(0.1f);
				this.mRightRoot.CustomActive(true);
				if (data.collectIDs.Count <= 0)
				{
					this.mRightRoot.CustomActive(false);
					yield break;
				}
				EquipHandbookTabCollectionData collectData = data.collectIDs[index];
				if (collectData.itemIDs.Count <= 0)
				{
					yield break;
				}
				ComCommonBind bind = collectData.itemIDs[0].bind;
				if (null == bind)
				{
					yield break;
				}
				Toggle toggle = bind.GetCom<Toggle>("toggle");
				toggle.isOn = true;
				yield break;
			}
		}

		// Token: 0x0600D9EF RID: 55791 RVA: 0x0036BD4C File Offset: 0x0036A14C
		private void _onGirdItemClick(int itemId, EquipHandbookTabData tabdata, EquipHandbookEquipItemData data, bool isFlag)
		{
			if (isFlag && this.itemid == itemId)
			{
				return;
			}
			this.itemid = itemId;
			this.mcurrentSelectTab = tabdata;
			this.mcurrentSelectItem = data;
			if (this.mRightPreviewRoot.gameObject.activeSelf)
			{
				if (this._setTryOnBtnIsShow(this.itemid))
				{
					this._setEquipName(this.itemid);
					this._initModel(this.itemid);
					return;
				}
				this.mRightPreviewRoot.CustomActive(false);
				this.mRightRoot.CustomActive(true);
			}
			this.mDetailEquip.SetItemId(itemId);
			if (tabdata.isShowEquipScore)
			{
				this.mDetailEquip.gostate.CustomActive(true);
				this.mDetailEquip.SetItemState(data);
			}
			else
			{
				this.mDetailEquip.gostate.CustomActive(false);
			}
			if (this._setTryOnBtnIsShow(itemId))
			{
				this.mBind.GetSprite("anniu", ref this.mRightImg);
				this.mBind.GetSprite("anniu", ref this.mLeftImg);
				this.mTryEquipButton.image.raycastTarget = true;
			}
			else
			{
				this.mBind.GetSprite("grey", ref this.mRightImg);
				this.mBind.GetSprite("grey", ref this.mLeftImg);
				this.mTryEquipButton.image.raycastTarget = false;
			}
			string prefabPath = this.mBind.GetPrefabPath("commentUnit");
			string prefabPath2 = this.mBind.GetPrefabPath("sourceUnit");
			this.mBind.ClearCacheBinds(prefabPath);
			this.mBind.ClearCacheBinds(prefabPath2);
			this.mSourceEmptyRoot.CustomActive(true);
			this.mCommentEmptyRoot.CustomActive(true);
			this._stopCoroutineCommentNodesAndClear();
			EquipHandbookAttachedTable tableItem = Singleton<TableManager>.instance.GetTableItem<EquipHandbookAttachedTable>(itemId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			List<string> list = new List<string>();
			for (int i = 0; i < tableItem.EquipHandbookCommentIDs.Count; i++)
			{
				this.mCommentEmptyRoot.CustomActive(false);
				int commentID = tableItem.EquipHandbookCommentIDs[i];
				EquipHandbookCommentTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<EquipHandbookCommentTable>(commentID, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					ComCommonBind comCommonBind = this.mBind.LoadExtraBind(prefabPath);
					Utility.AttachTo(comCommonBind.gameObject, this.mRightCommentRoot, false);
					list.Add(commentID.ToString());
					this.mCommentNodes.Add(new EquipHandbookFrame.CommentNode(commentID, comCommonBind, tableItem2.SortOrder));
					Text com = comCommonBind.GetCom<Text>("likeWord");
					GameObject gameObject = comCommonBind.GetGameObject("bgBoard");
					Image com2 = comCommonBind.GetCom<Image>("likeImage");
					Text com3 = comCommonBind.GetCom<Text>("likeNum");
					Button com4 = comCommonBind.GetCom<Button>("likeButton");
					gameObject.CustomActive(i % 2 == 1);
					com.text = tableItem2.Comment;
					com3.text = "?";
					int idx = i;
					com4.onClick.RemoveAllListeners();
					com4.onClick.AddListener(delegate()
					{
						if (this.mCommentNodes.Count > idx)
						{
							this.mCommentNodes[idx].bind.StartCoroutine(this._equipLike(itemId, commentID));
						}
					});
				}
			}
			if (this.mCommentNodes.Count > 0)
			{
				this.mCommentNodes[0].bind.StartCoroutine(this._queryLike(itemId, list.ToArray()));
			}
			this.mCRScrollRect.verticalNormalizedPosition = 1f;
			IEnumerator sourceInfos = DataManager<ItemSourceInfoTableManager>.GetInstance().GetSourceInfos(itemId);
			int num = 0;
			while (sourceInfos.MoveNext())
			{
				this.mSourceEmptyRoot.CustomActive(false);
				ISourceInfo info = sourceInfos.Current as ISourceInfo;
				if (info != null)
				{
					ComCommonBind comCommonBind2 = this.mBind.LoadExtraBind(prefabPath2);
					Utility.AttachTo(comCommonBind2.gameObject, this.mRightSourceRoot, false);
					num++;
					Text com5 = comCommonBind2.GetCom<Text>("desc");
					Button com6 = comCommonBind2.GetCom<Button>("onClickLink");
					string sourceInfoName = DataManager<ItemSourceInfoTableManager>.GetInstance().GetSourceInfoName(info);
					string linkString = DataManager<ItemSourceInfoTableManager>.GetInstance().GetSourceInfoLink(info);
					com5.text = sourceInfoName;
					com6.onClick.RemoveAllListeners();
					com6.onClick.AddListener(delegate()
					{
						if (ItemSourceInfoUtility.IsLinkFunctionOpen(info))
						{
							DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(linkString, null, false);
							Singleton<ClientSystemManager>.instance.CloseFrame<EquipHandbookFrame>(this, false);
						}
						else
						{
							SystemNotifyManager.SystemNotify(1013, string.Empty);
						}
					});
				}
			}
			this.mSRScrollRect.verticalNormalizedPosition = 1f;
			if (num > 6)
			{
				this.mSRScrollRect.enabled = true;
			}
			else
			{
				this.mSRScrollRect.enabled = false;
			}
		}

		// Token: 0x0600D9F0 RID: 55792 RVA: 0x0036C248 File Offset: 0x0036A648
		private void _stopCoroutineCommentNodesAndClear()
		{
			for (int i = 0; i < this.mCommentNodes.Count; i++)
			{
				if (this.mCommentNodes[i] != null && this.mCommentNodes[i].bind != null)
				{
					this.mCommentNodes[i].bind.StopAllCoroutines();
				}
			}
			this.mCommentNodes.Clear();
		}

		// Token: 0x0600D9F1 RID: 55793 RVA: 0x0036C2BF File Offset: 0x0036A6BF
		protected override void _OnCloseFrame()
		{
			this._clear();
			this._stopCoroutineCommentNodesAndClear();
			this._stopCoroutineSelectCurrentLevelGridItem();
			this._stopCoroutineCurrentTabClick();
		}

		// Token: 0x0600D9F2 RID: 55794 RVA: 0x0036C2DC File Offset: 0x0036A6DC
		private IEnumerator _queryLike(int itemId, string[] commentids)
		{
			BaseWaitHttpRequest req = new BaseWaitHttpRequest();
			req.url = string.Format("http://{0}/query_likes?accId={1}&roleId={2}&itemId={3}&comments={4}", new object[]
			{
				this.kCommentAddress,
				ClientApplication.playerinfo.accid,
				ClientApplication.playerinfo.GetSelectRoleBaseInfoByLogin().roleId,
				itemId,
				string.Join(",", commentids)
			});
			yield return req;
			if (req.GetResult() == BaseWaitHttpRequest.eState.Success)
			{
				EquipHandbookEquipQueryData resultJson = req.GetResultJson<EquipHandbookEquipQueryData>();
				this._refreshCommentNode(resultJson, true);
			}
			yield break;
		}

		// Token: 0x0600D9F3 RID: 55795 RVA: 0x0036C308 File Offset: 0x0036A708
		private void _refreshCommentNode(EquipHandbookEquipQueryData data, bool isRefresh)
		{
			if (null == this.mBind)
			{
				return;
			}
			if (data == null || data.code != 0)
			{
				return;
			}
			for (int i = 0; i < data.itemcomments.Count; i++)
			{
				EquipHandbookCommentData equipHandbookCommentData = data.itemcomments[i];
				EquipHandbookFrame.CommentNode commentNode = this._findCommentNode(equipHandbookCommentData.id);
				if (commentNode != null)
				{
					ComCommonBind bind = commentNode.bind;
					commentNode.count = equipHandbookCommentData.count;
					Image com = bind.GetCom<Image>("likeImage");
					Text com2 = bind.GetCom<Text>("likeNum");
					if (equipHandbookCommentData.selflike == 1)
					{
						this.mBind.GetSprite("containselflike", ref com);
					}
					else
					{
						this.mBind.GetSprite("otherlike", ref com);
					}
					com2.text = equipHandbookCommentData.count.ToString();
				}
			}
			if (isRefresh)
			{
				this._refreshEquipHandbookCommentSort();
			}
		}

		// Token: 0x0600D9F4 RID: 55796 RVA: 0x0036C400 File Offset: 0x0036A800
		private void _refreshEquipHandbookCommentSort()
		{
			this.mCommentNodes.Sort();
			for (int i = 0; i < this.mCommentNodes.Count; i++)
			{
				EquipHandbookCommentTable tableItem = Singleton<TableManager>.instance.GetTableItem<EquipHandbookCommentTable>(this.mCommentNodes[i].id, string.Empty, string.Empty);
				if (tableItem != null)
				{
					ComCommonBind bind = this.mCommentNodes[i].bind;
					Text com = bind.GetCom<Text>("likeWord");
					GameObject gameObject = bind.GetGameObject("bgBoard");
					Image com2 = bind.GetCom<Image>("likeImage");
					Text com3 = bind.GetCom<Text>("likeNum");
					gameObject.CustomActive(i % 2 == 1);
					com.text = tableItem.Comment;
					com3.text = this.mCommentNodes[i].count.ToString();
					bind.transform.SetAsLastSibling();
				}
			}
		}

		// Token: 0x0600D9F5 RID: 55797 RVA: 0x0036C4F8 File Offset: 0x0036A8F8
		private EquipHandbookFrame.CommentNode _findCommentNode(int commentId)
		{
			for (int i = 0; i < this.mCommentNodes.Count; i++)
			{
				if (this.mCommentNodes[i].id == commentId)
				{
					return this.mCommentNodes[i];
				}
			}
			return null;
		}

		// Token: 0x0600D9F6 RID: 55798 RVA: 0x0036C548 File Offset: 0x0036A948
		private IEnumerator _equipLike(int itemId, int commentId)
		{
			BaseWaitHttpRequest req = new BaseWaitHttpRequest();
			req.url = string.Format("http://{0}/like_item?accId={1}&roleId={2}&itemId={3}&commentId={4}", new object[]
			{
				this.kCommentAddress,
				ClientApplication.playerinfo.accid,
				ClientApplication.playerinfo.GetSelectRoleBaseInfoByLogin().roleId,
				itemId,
				commentId
			});
			yield return req;
			if (req.GetResult() == BaseWaitHttpRequest.eState.Success)
			{
				EquipHandbookEquipQueryData resultJson = req.GetResultJson<EquipHandbookEquipQueryData>();
				this._refreshCommentNode(resultJson, false);
			}
			yield break;
		}

		// Token: 0x0600D9F7 RID: 55799 RVA: 0x0036C574 File Offset: 0x0036A974
		private void _showTips(int itemId)
		{
			ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(itemId);
			commonItemTableDataByID.RefreshRateScore();
			if (commonItemTableDataByID != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(commonItemTableDataByID, null, 4, true, false, true);
			}
		}

		// Token: 0x0600D9F8 RID: 55800 RVA: 0x0036C5A9 File Offset: 0x0036A9A9
		private void _clear()
		{
			this._clearModel();
			this.itemid = 0;
			this.mSelectItemID = 0;
			this.bIsPlayAnimation = false;
			this.mLastSelectedIndex = -1;
			this.mLeftRootComUIList.onItemVisiable = null;
			this.mcurrentSelectTab = null;
			this.mcurrentSelectItem = null;
		}

		// Token: 0x0400801B RID: 32795
		private int itemid;

		// Token: 0x0400801C RID: 32796
		private GeAvatarRendererEx m_AvatarRenderer;

		// Token: 0x0400801D RID: 32797
		private bool bIsPlayAnimation;

		// Token: 0x0400801E RID: 32798
		private int mLastSelectedIndex = -1;

		// Token: 0x0400801F RID: 32799
		private float fViewPortPos = 726f;

		// Token: 0x04008020 RID: 32800
		private int mSelectItemID;

		// Token: 0x04008021 RID: 32801
		private EquipHandbookTabData mcurrentSelectTab;

		// Token: 0x04008022 RID: 32802
		private EquipHandbookEquipItemData mcurrentSelectItem;

		// Token: 0x04008023 RID: 32803
		private GameObject mTabRoot;

		// Token: 0x04008024 RID: 32804
		private GameObject mLeftRoot;

		// Token: 0x04008025 RID: 32805
		private GameObject mRightSourceRoot;

		// Token: 0x04008026 RID: 32806
		private GameObject mRightCommentRoot;

		// Token: 0x04008027 RID: 32807
		private GameObject mRightPreviewRoot;

		// Token: 0x04008028 RID: 32808
		private Text mTabName;

		// Token: 0x04008029 RID: 32809
		private Button mClosePreviewButton;

		// Token: 0x0400802A RID: 32810
		private Button mTryEquipButton;

		// Token: 0x0400802B RID: 32811
		private Button mDetailButton;

		// Token: 0x0400802C RID: 32812
		private ToggleGroup mLeftGirdToggleGroup;

		// Token: 0x0400802D RID: 32813
		private CanvasGroup mRightRoot;

		// Token: 0x0400802E RID: 32814
		private ToggleGroup mTabToggleGroup;

		// Token: 0x0400802F RID: 32815
		private ComEquipHandbookItem mDetailEquip;

		// Token: 0x04008030 RID: 32816
		private GameObject mSourceEmptyRoot;

		// Token: 0x04008031 RID: 32817
		private GameObject mCommentEmptyRoot;

		// Token: 0x04008032 RID: 32818
		private Button mCloseButton;

		// Token: 0x04008033 RID: 32819
		private GameObject mModelRT;

		// Token: 0x04008034 RID: 32820
		private Text mEquipName;

		// Token: 0x04008035 RID: 32821
		private Image mArrowState;

		// Token: 0x04008036 RID: 32822
		private Text mDifferenceScore;

		// Token: 0x04008037 RID: 32823
		private Text mTatleScore;

		// Token: 0x04008038 RID: 32824
		private GameObject mSocreRoot;

		// Token: 0x04008039 RID: 32825
		private SkeletonAnimation mSkeletonAnimation;

		// Token: 0x0400803A RID: 32826
		private ComUIListScript mLeftRootComUIList;

		// Token: 0x0400803B RID: 32827
		private GameObject mSecendsocreRoot;

		// Token: 0x0400803C RID: 32828
		private GameObject mPerfectRoot;

		// Token: 0x0400803D RID: 32829
		private Image mLeftImg;

		// Token: 0x0400803E RID: 32830
		private Image mRightImg;

		// Token: 0x0400803F RID: 32831
		private ScrollRect mLeftRootScrollRect;

		// Token: 0x04008040 RID: 32832
		private RectTransform mContent;

		// Token: 0x04008041 RID: 32833
		private ScrollRect mSRScrollRect;

		// Token: 0x04008042 RID: 32834
		private ScrollRect mCRScrollRect;

		// Token: 0x04008043 RID: 32835
		private Coroutine mCurrentTabClick;

		// Token: 0x04008044 RID: 32836
		private Coroutine mSelectCurrentLevelGridItem;

		// Token: 0x04008045 RID: 32837
		private List<EquipHandbookEquipItemData> mRecommendEquips;

		// Token: 0x04008046 RID: 32838
		private List<EquipHandbookFrame.CommentNode> mCommentNodes = new List<EquipHandbookFrame.CommentNode>();

		// Token: 0x04008047 RID: 32839
		private readonly string kCommentAddress = ClientApplication.commentServerAddr;

		// Token: 0x020015C2 RID: 5570
		private class CommentNode : IComparable<EquipHandbookFrame.CommentNode>
		{
			// Token: 0x0600D9F9 RID: 55801 RVA: 0x0036C5E7 File Offset: 0x0036A9E7
			public CommentNode(int id, ComCommonBind bind, int sortOrder)
			{
				this.id = id;
				this.bind = bind;
				this.sortOrder = sortOrder;
			}

			// Token: 0x17001C38 RID: 7224
			// (get) Token: 0x0600D9FB RID: 55803 RVA: 0x0036C60D File Offset: 0x0036AA0D
			// (set) Token: 0x0600D9FA RID: 55802 RVA: 0x0036C604 File Offset: 0x0036AA04
			public int id { get; private set; }

			// Token: 0x17001C39 RID: 7225
			// (get) Token: 0x0600D9FD RID: 55805 RVA: 0x0036C61E File Offset: 0x0036AA1E
			// (set) Token: 0x0600D9FC RID: 55804 RVA: 0x0036C615 File Offset: 0x0036AA15
			public ComCommonBind bind { get; private set; }

			// Token: 0x17001C3A RID: 7226
			// (get) Token: 0x0600D9FF RID: 55807 RVA: 0x0036C62F File Offset: 0x0036AA2F
			// (set) Token: 0x0600D9FE RID: 55806 RVA: 0x0036C626 File Offset: 0x0036AA26
			public int count { get; set; }

			// Token: 0x17001C3B RID: 7227
			// (get) Token: 0x0600DA01 RID: 55809 RVA: 0x0036C640 File Offset: 0x0036AA40
			// (set) Token: 0x0600DA00 RID: 55808 RVA: 0x0036C637 File Offset: 0x0036AA37
			public int sortOrder { get; set; }

			// Token: 0x0600DA02 RID: 55810 RVA: 0x0036C648 File Offset: 0x0036AA48
			public int CompareTo(EquipHandbookFrame.CommentNode other)
			{
				if (this.count == other.count)
				{
					return this.sortOrder - other.sortOrder;
				}
				return other.count - this.count;
			}
		}
	}
}
