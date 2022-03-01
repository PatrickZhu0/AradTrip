using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001700 RID: 5888
	internal class ShowItemsFrame : ClientFrame
	{
		// Token: 0x0600E731 RID: 59185 RVA: 0x003CD911 File Offset: 0x003CBD11
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Jar/ShowItems";
		}

		// Token: 0x0600E732 RID: 59186 RVA: 0x003CD918 File Offset: 0x003CBD18
		protected override void _OnOpenFrame()
		{
			ShowItemsFrameData showItemsFrameData = this.userData as ShowItemsFrameData;
			if (showItemsFrameData == null)
			{
				Logger.LogError("open ShowItemsFrame frame data is null");
				return;
			}
			base.StartCoroutine(this._ExplodeJar(showItemsFrameData));
			this._RegisterUIEvent();
		}

		// Token: 0x0600E733 RID: 59187 RVA: 0x003CD956 File Offset: 0x003CBD56
		protected override void _OnCloseFrame()
		{
			this.m_multiItemInfos.Clear();
			this.m_singleItemInfo.Clear();
			if (this.m_coroutine != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.m_coroutine);
				this.m_coroutine = null;
			}
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600E734 RID: 59188 RVA: 0x003CD998 File Offset: 0x003CBD98
		protected void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.MagicJarUseSuccess, new ClientEventSystem.UIEventHandler(this._OnJarUseSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.MagicJarUseFail, new ClientEventSystem.UIEventHandler(this._OnJarUseFail));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PlayerDataBaseUpdated, new ClientEventSystem.UIEventHandler(this._OnMoneyChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.JarFreeTimeChanged, new ClientEventSystem.UIEventHandler(this._OnFreeTimeChanged));
		}

		// Token: 0x0600E735 RID: 59189 RVA: 0x003CDA10 File Offset: 0x003CBE10
		protected void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.MagicJarUseSuccess, new ClientEventSystem.UIEventHandler(this._OnJarUseSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.MagicJarUseFail, new ClientEventSystem.UIEventHandler(this._OnJarUseFail));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PlayerDataBaseUpdated, new ClientEventSystem.UIEventHandler(this._OnMoneyChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.JarFreeTimeChanged, new ClientEventSystem.UIEventHandler(this._OnFreeTimeChanged));
		}

		// Token: 0x0600E736 RID: 59190 RVA: 0x003CDA88 File Offset: 0x003CBE88
		private IEnumerator _ExplodeJar(ShowItemsFrameData a_frameData)
		{
			JarData jarData = a_frameData.data;
			bool bSingleJar = a_frameData.items.Count <= 2;
			this.m_explodeProgress.gameObject.SetActive(false);
			this.m_explodeProgress.value = 0f;
			this.m_explodeRandomName.gameObject.SetActive(false);
			this.m_explodeRandomName.text = string.Empty;
			this.m_labBuyResult.gameObject.SetActive(false);
			this.m_objItem_x1.SetActive(bSingleJar);
			this.m_objFinalItem_x1.SetActive(false);
			this.m_objEffectItem_x1.SetActive(false);
			this.m_objItem_x10.SetActive(!bSingleJar);
			this.m_objFinalItem_x10.SetActive(false);
			this.m_objEffectItem_x10.SetActive(false);
			this.m_objScore.SetActive(false);
			this.m_objBuyRoot.SetActive(false);
			this.m_objCustomOpen.SetActive(false);
			for (int i = 0; i < 1; i++)
			{
				if (i >= this.m_singleItemInfo.Count)
				{
					this.m_singleItemInfo.Add(this._InitItemUI(this.m_objItem_x1, i));
					yield return Yielders.EndOfFrame;
				}
			}
			for (int j = 0; j < 10; j++)
			{
				if (j >= this.m_multiItemInfos.Count)
				{
					this.m_multiItemInfos.Add(this._InitItemUI(this.m_objItem_x10, j));
					yield return Yielders.EndOfFrame;
				}
			}
			DOTweenAnimation[] anims = this.m_labScoreRate.GetComponents<DOTweenAnimation>();
			for (int k = 0; k < anims.Length; k++)
			{
				anims[k].DORewind();
				anims[k].isActive = false;
			}
			GameObject objJarEffect = Singleton<AssetLoader>.GetInstance().LoadRes(jarData.strJarModelPath, true, 0U).obj as GameObject;
			objJarEffect.transform.SetParent(this.m_objExplodeRoot.transform, false);
			objJarEffect.SetActive(true);
			DOTweenAnimation animRandom = Utility.GetComponetInChild<DOTweenAnimation>(objJarEffect, "p_Pot02/Bone007/Dummy001");
			Image imgRandomBG = Utility.GetComponetInChild<Image>(objJarEffect, "p_Pot02/Bone007/Dummy001/BG");
			if (imgRandomBG != null)
			{
				imgRandomBG.gameObject.SetActive(false);
			}
			Image imgRandomIcon = Utility.GetComponetInChild<Image>(objJarEffect, "p_Pot02/Bone007/Dummy001/Icon");
			if (imgRandomIcon != null)
			{
				imgRandomIcon.gameObject.SetActive(false);
			}
			if (jarData.arrRealBonusItems.Count > 0)
			{
				animRandom.onStepComplete.RemoveAllListeners();
				animRandom.onStepComplete.AddListener(delegate()
				{
					int index = Random.Range(0, jarData.arrRealBonusItems.Count - 1);
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(jarData.arrRealBonusItems[index].ItemID, 100, 0);
					itemData.Count = jarData.arrRealBonusItems[index].Count;
					this.m_explodeRandomName.text = itemData.GetColorName(string.Empty, false);
				});
				animRandom.onComplete.RemoveAllListeners();
				animRandom.onComplete.AddListener(delegate()
				{
					ItemData item = a_frameData.items[1].item;
					this.m_explodeRandomName.text = item.GetColorName(string.Empty, false);
				});
			}
			else
			{
				this.m_explodeRandomName.text = string.Empty;
			}
			if (!ShowItemsFrame.bSkipExplode)
			{
				yield return Yielders.GetWaitForSeconds(0.5f);
			}
			if (!ShowItemsFrame.bSkipExplode)
			{
				MonoSingleton<AudioManager>.instance.PlaySound(21);
			}
			this.m_explodeProgress.gameObject.SetActive(true);
			this.m_explodeRandomName.gameObject.SetActive(true);
			TweenExtensions.Restart(animRandom.tween, true);
			float maxTime = 2.2f;
			this.m_explodeProgress.value = 0f;
			float startTime = Time.time;
			float elapsed = 0f;
			while (elapsed < maxTime)
			{
				if (ShowItemsFrame.bSkipExplode)
				{
					break;
				}
				elapsed = Time.time - startTime;
				this.m_explodeProgress.value = elapsed / maxTime;
				yield return Yielders.EndOfFrame;
			}
			this.m_explodeProgress.value = 1f;
			this.m_explodeProgress.gameObject.SetActive(false);
			this.m_explodeRandomName.gameObject.SetActive(false);
			animRandom.gameObject.SetActive(false);
			this.m_objExplodeRoot.CustomActive(false);
			yield return Yielders.EndOfFrame;
			if (bSingleJar)
			{
				yield return this._PlayItemsEffect(a_frameData, this.m_singleItemInfo, this.m_objEffectItem_x1, objJarEffect);
			}
			else
			{
				yield return this._PlayItemsEffect(a_frameData, this.m_multiItemInfos, this.m_objEffectItem_x10, objJarEffect);
			}
			if (a_frameData.scoreItemData != null && a_frameData.scoreItemData.Count > 0)
			{
				this.m_objScore.SetActive(true);
				this.m_labScoreDesc.text = TR.Value("jar_get_score_base", a_frameData.scoreItemData.GetColorName(string.Empty, false), a_frameData.scoreItemData.Count);
				if (a_frameData.scoreRate > 1)
				{
					this.m_labScoreRate.gameObject.SetActive(true);
					this.m_labScoreRate.text = TR.Value("jar_get_score_rate", a_frameData.scoreRate);
					DOTweenAnimation[] components = this.m_labScoreRate.GetComponents<DOTweenAnimation>();
					for (int l = 0; l < components.Length; l++)
					{
						components[l].isActive = true;
						if (components[l].tween == null)
						{
							components[l].CreateTween();
						}
						TweenExtensions.Restart(components[l].tween, true);
					}
				}
				else
				{
					this.m_labScoreRate.gameObject.SetActive(false);
				}
			}
			yield return Yielders.GetWaitForSeconds(0.25f);
			this._SetupBuybtns(a_frameData);
			this.m_objBuyRoot.SetActive(true);
			yield break;
		}

		// Token: 0x0600E737 RID: 59191 RVA: 0x003CDAAC File Offset: 0x003CBEAC
		private ShowItemsFrame.ItemInfo _InitItemUI(GameObject a_objItemGroup, int a_nIdx)
		{
			ShowItemsFrame.ItemInfo itemInfo = new ShowItemsFrame.ItemInfo();
			GameObject gameObject = Utility.FindGameObject(a_objItemGroup, string.Format("Final/ItemRoot_{0}", a_nIdx), true);
			itemInfo.labName = Utility.GetComponetInChild<Text>(gameObject, "Name");
			itemInfo.comItem = base.CreateComItem(Utility.FindGameObject(gameObject, "Item", true));
			GameObject gameObject2 = Utility.FindGameObject(a_objItemGroup, string.Format("Effect/Icon{0:D2}", a_nIdx + 1), true);
			GameObject gameObject3 = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("UIFlatten/Prefabs/Jar/Card", true, 0U);
			gameObject3.transform.SetParent(gameObject2.transform, false);
			itemInfo.tranRoot = gameObject3.GetComponent<RectTransform>();
			itemInfo.animator = gameObject3.GetComponent<Animator>();
			itemInfo.comCardEffect = gameObject3.GetComponent<ComCardEffect>();
			itemInfo.comItemEffect = base.CreateComItem(Utility.FindGameObject(gameObject3, "Content/Front/Item", true));
			itemInfo.labNameEffect = Utility.GetComponetInChild<Text>(gameObject3, "Content/Front/Name");
			itemInfo.btnBack = Utility.GetComponetInChild<Button>(gameObject3, "Content/Back");
			itemInfo.imgBack = Utility.GetComponetInChild<Image>(gameObject3, "Content/Back");
			itemInfo.tranParFront = Utility.FindGameObject(gameObject3, "Content/Front/ParFront", true).transform;
			itemInfo.tranParBack = Utility.FindGameObject(gameObject3, "Content/Back/ParBack", true).transform;
			itemInfo.tranParTurnover = Utility.FindGameObject(gameObject3, "ParTurnover", true).transform;
			return itemInfo;
		}

		// Token: 0x0600E738 RID: 59192 RVA: 0x003CDBF4 File Offset: 0x003CBFF4
		private IEnumerator _PlayItemsEffect(ShowItemsFrameData a_frameData, List<ShowItemsFrame.ItemInfo> a_arrItemInfos, GameObject a_objItemsRoot, GameObject a_objJarEffect)
		{
			List<JarBonus> arrBonus = a_frameData.items.GetRange(1, a_frameData.items.Count - 1);
			if (arrBonus != null)
			{
				int num = 0;
				while (num < a_arrItemInfos.Count && num < arrBonus.Count)
				{
					this._SetupItemInfo(a_arrItemInfos[num], arrBonus[num]);
					num++;
				}
			}
			Toggle toggle = a_objItemsRoot.GetComponent<Toggle>();
			toggle.isOn = false;
			a_objItemsRoot.SetActive(true);
			Animator anim = a_objItemsRoot.GetComponent<Animator>();
			anim.enabled = true;
			while (!toggle.isOn)
			{
				yield return Yielders.EndOfFrame;
			}
			anim.enabled = false;
			this._PlayTurnoverEffects(a_arrItemInfos);
			for (;;)
			{
				bool bNeedWait = false;
				for (int i = 0; i < a_arrItemInfos.Count; i++)
				{
					if (!a_arrItemInfos[i].comCardEffect.bFinished)
					{
						bNeedWait = true;
						break;
					}
					a_arrItemInfos[i].animator.enabled = false;
				}
				if (!bNeedWait)
				{
					break;
				}
				yield return Yielders.GetWaitForSeconds(0.1f);
			}
			DataManager<JarDataManager>.GetInstance().RequestJarBuyRecord(a_frameData.data.nID);
			this._CloseAutoOpen();
			Object.Destroy(a_objJarEffect);
			yield break;
		}

		// Token: 0x0600E739 RID: 59193 RVA: 0x003CDC2C File Offset: 0x003CC02C
		private IEnumerator _AutoOpenCountdown(List<ShowItemsFrame.ItemInfo> a_arrItemInfos)
		{
			for (int i = 5; i > 0; i--)
			{
				this.m_labCustomOpenDesc.text = TR.Value("jar_auto_open", i);
				yield return Yielders.GetWaitForSeconds(1f);
			}
			this._OpenHighValueCard(a_arrItemInfos);
			this.m_objCustomOpen.SetActive(false);
			this.m_coroutine = null;
			yield break;
		}

		// Token: 0x0600E73A RID: 59194 RVA: 0x003CDC50 File Offset: 0x003CC050
		private void _PlayTurnoverEffects(List<ShowItemsFrame.ItemInfo> a_arrItemInfos)
		{
			bool flag = false;
			if (a_arrItemInfos != null)
			{
				for (int i = 0; i < a_arrItemInfos.Count; i++)
				{
					ShowItemsFrame.ItemInfo itemInfo = a_arrItemInfos[i];
					if (itemInfo != null)
					{
						if (itemInfo.bonus != null)
						{
							if (!itemInfo.bonus.bHighValue)
							{
								if (itemInfo.animator != null)
								{
									itemInfo.animator.enabled = true;
								}
								if (itemInfo.btnBack != null)
								{
									itemInfo.btnBack.onClick.RemoveAllListeners();
								}
							}
							else
							{
								if (itemInfo.animator != null)
								{
									itemInfo.animator.enabled = false;
								}
								if (itemInfo.btnBack != null)
								{
									itemInfo.btnBack.onClick.RemoveAllListeners();
									itemInfo.btnBack.onClick.AddListener(delegate()
									{
										if (itemInfo != null && itemInfo.animator != null)
										{
											itemInfo.animator.enabled = true;
										}
									});
								}
								flag = true;
							}
						}
					}
				}
			}
			if (flag)
			{
				this.m_objCustomOpen.CustomActive(true);
				if (this.m_coroutine != null)
				{
					MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.m_coroutine);
					this.m_coroutine = null;
				}
				this.m_coroutine = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._AutoOpenCountdown(a_arrItemInfos));
				if (this.m_btnCustomOpen != null)
				{
					this.m_btnCustomOpen.onClick.RemoveAllListeners();
					this.m_btnCustomOpen.onClick.AddListener(delegate()
					{
						this._CloseAutoOpen();
						this._OpenHighValueCard(a_arrItemInfos);
					});
				}
			}
			else
			{
				this.m_objCustomOpen.CustomActive(false);
			}
		}

		// Token: 0x0600E73B RID: 59195 RVA: 0x003CDE54 File Offset: 0x003CC254
		private void _SetupCardPar(ShowItemsFrame.ItemInfo a_itemInfo)
		{
			if (a_itemInfo == null || a_itemInfo.bonus == null || a_itemInfo.bonus.item == null)
			{
				return;
			}
			ItemData.QualityInfo qualityInfo = a_itemInfo.bonus.item.GetQualityInfo();
			if (qualityInfo == null)
			{
				return;
			}
			ItemTable.eColor quality = qualityInfo.Quality;
			string text = string.Empty;
			string text2 = string.Empty;
			switch (quality)
			{
			case ItemTable.eColor.GREEN:
				text = "Effects/Scene_effects/EffectUI/Fanka/EffUI_pinjikuang_4bei";
				text2 = "Effects/Scene_effects/EffectUI/Fanka/EffUI_pinjikuang_4";
				break;
			case ItemTable.eColor.PINK:
				text = "Effects/Scene_effects/EffectUI/Fanka/EffUI_pinjikuang_5bei";
				text2 = "Effects/Scene_effects/EffectUI/Fanka/EffUI_pinjikuang_5";
				break;
			case ItemTable.eColor.YELLOW:
				text = "Effects/Scene_effects/EffectUI/Fanka/EffUI_pinjikuang_6bei";
				text2 = "Effects/Scene_effects/EffectUI/Fanka/EffUI_pinjikuang_6";
				break;
			default:
				if (a_itemInfo.bonus.bHighValue)
				{
					text = "Effects/Scene_effects/EffectUI/Fanka/EffUI_pinjikuang_3bei";
					text2 = "Effects/Scene_effects/EffectUI/Fanka/EffUI_pinjikuang_3";
				}
				break;
			}
			if (!string.IsNullOrEmpty(text) && a_itemInfo.tranParBack != null)
			{
				GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(text, true, 0U);
				if (gameObject != null)
				{
					gameObject.transform.SetParent(a_itemInfo.tranParBack, false);
					gameObject.SetActive(true);
				}
			}
			if (!string.IsNullOrEmpty(text2) && a_itemInfo.tranParFront != null)
			{
				GameObject gameObject2 = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(text2, true, 0U);
				if (gameObject2 != null)
				{
					gameObject2.transform.SetParent(a_itemInfo.tranParFront, false);
					gameObject2.SetActive(true);
				}
			}
			if (a_itemInfo.bonus.bHighValue && a_itemInfo.tranParTurnover != null)
			{
				GameObject gameObject3 = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("Effects/Scene_effects/EffectUI/Fanka/EffUI_fan", true, 0U);
				if (gameObject3 != null)
				{
					gameObject3.transform.SetParent(a_itemInfo.tranParTurnover, false);
					gameObject3.SetActive(true);
				}
			}
		}

		// Token: 0x0600E73C RID: 59196 RVA: 0x003CE020 File Offset: 0x003CC420
		private void DestroyAllChild(Transform transform)
		{
			if (transform == null)
			{
				return;
			}
			for (int i = 0; i < transform.childCount; i++)
			{
				Object.Destroy(transform.GetChild(i).gameObject);
			}
		}

		// Token: 0x0600E73D RID: 59197 RVA: 0x003CE064 File Offset: 0x003CC464
		private void _SetupItemInfo(ShowItemsFrame.ItemInfo a_itemInfo, JarBonus a_bonus)
		{
			if (a_itemInfo == null)
			{
				return;
			}
			if (a_bonus == null)
			{
				return;
			}
			this.DestroyAllChild(a_itemInfo.tranParBack);
			this.DestroyAllChild(a_itemInfo.tranParFront);
			this.DestroyAllChild(a_itemInfo.tranParTurnover);
			a_itemInfo.btnBack.CustomActive(true);
			a_itemInfo.btnBack.SafeRemoveAllListener();
			if (a_itemInfo.comCardEffect != null)
			{
				a_itemInfo.comCardEffect.bFinished = false;
			}
			string path = string.Empty;
			if (a_bonus.item != null)
			{
				switch (a_bonus.item.Quality)
				{
				case ItemTable.eColor.GREEN:
					path = "UI/Image/Packed/p_UI_Kapai.png:UI_Kapai_Lvse";
					break;
				case ItemTable.eColor.PINK:
					path = "UI/Image/Packed/p_UI_Kapai.png:UI_Kapai_Fense";
					break;
				case ItemTable.eColor.YELLOW:
					path = "UI/Image/Packed/p_UI_Kapai.png:UI_Kapai_Jinse";
					break;
				default:
					path = "UI/Image/Packed/p_UI_Kapai.png:UI_Kapai_Huise";
					break;
				}
			}
			a_itemInfo.imgBack.SafeSetImage(path, false);
			if (a_itemInfo.tranRoot != null)
			{
				a_itemInfo.tranRoot.localRotation = Quaternion.identity;
				a_itemInfo.tranRoot.localScale = new Vector3(1f, 1f, 1f);
				for (int i = 0; i < a_itemInfo.tranRoot.childCount; i++)
				{
					Transform child = a_itemInfo.tranRoot.GetChild(i);
					child.localRotation = Quaternion.identity;
					child.localScale = new Vector3(1f, 1f, 1f);
				}
			}
			a_itemInfo.bonus = a_bonus;
			if (a_itemInfo.comItem != null && a_itemInfo.bonus.item != null)
			{
				a_itemInfo.comItem.Setup(a_itemInfo.bonus.item, delegate(GameObject var1, ItemData var2)
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
				});
				a_itemInfo.labName.SafeSetText(a_itemInfo.bonus.item.GetColorName(string.Empty, false));
			}
			if (a_itemInfo.comItemEffect != null && a_itemInfo.bonus.item != null)
			{
				a_itemInfo.comItemEffect.Setup(a_itemInfo.bonus.item, delegate(GameObject var1, ItemData var2)
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
				});
				a_itemInfo.labNameEffect.SafeSetText(a_itemInfo.bonus.item.GetColorName(string.Empty, false));
			}
			this._SetupCardPar(a_itemInfo);
		}

		// Token: 0x0600E73E RID: 59198 RVA: 0x003CE2CC File Offset: 0x003CC6CC
		private void _SetupBuybtns(ShowItemsFrameData a_frameData)
		{
			for (int i = 1; i < this.m_objBuyRoot.transform.childCount; i++)
			{
				this.m_objBuyRoot.transform.GetChild(i).gameObject.SetActive(false);
			}
			if (a_frameData.buyInfo == null)
			{
				return;
			}
			GameObject gameObject = this.m_objBuyRoot.transform.GetChild(1).gameObject;
			gameObject.SetActive(true);
			this.mRewardItem.CustomActive(false);
			if (a_frameData.data.eType == JarBonus.eType.EqrecoJar)
			{
				gameObject.SetActive(false);
				if (a_frameData.items != null && a_frameData.items.Count != 0)
				{
					ItemData item = a_frameData.items[0].item;
					if (item != null && item.TableID != 600000007)
					{
						ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
						if (tableItem != null)
						{
							this.mText.text = tableItem.Name;
						}
						this.mRewardItem.CustomActive(true);
						ComItem comItem = this.mRewardItem.GetComponentInChildren<ComItem>();
						if (comItem == null)
						{
							comItem = base.CreateComItem(this.mRewardItem);
						}
						int result = item.TableID;
						comItem.Setup(item, delegate(GameObject Obj, ItemData sitem)
						{
							this._OnShowTips(result);
						});
					}
				}
			}
			JarBuyInfo buyInfo = a_frameData.buyInfo;
			Button component = gameObject.GetComponent<Button>();
			if (ActivityJarFrame.frameType == ActivityJarFrameType.Artifact && ActivityJarFrame.GetArtifactJarDiscountTimes() <= 0 && buyInfo.nBuyCount > 1)
			{
				UIGray uigray = component.gameObject.SafeAddComponent(true);
				if (uigray != null)
				{
					uigray.enabled = false;
					uigray.enabled = true;
				}
				component.interactable = false;
			}
			else
			{
				UIGray uigray2 = component.gameObject.SafeAddComponent(true);
				if (uigray2 != null)
				{
					uigray2.enabled = true;
					uigray2.enabled = false;
				}
				component.interactable = true;
			}
			component.onClick.RemoveAllListeners();
			component.onClick.AddListener(delegate()
			{
				ShowItemsFrame.bSkipExplode = false;
				if (buyInfo.nFreeCount > 0)
				{
					DataManager<JarDataManager>.GetInstance().RequestBuyJar(a_frameData.data, buyInfo, ActivityJarFrame.GetArtifactActivityID(), 0U);
					return;
				}
				int discountItemCount = 0;
				int certificateItemCount = 0;
				if (buyInfo.nBuyCount == 10 && a_frameData.data.eType == JarBonus.eType.MagicJar)
				{
					discountItemCount = DataManager<JarDataManager>.GetInstance().GetMagicPotDiscountCount();
					certificateItemCount = DataManager<JarDataManager>.GetInstance().GetMagicPotCredentialsCount(buyInfo);
				}
				CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
				for (int k = 0; k < buyInfo.arrCosts.Count; k++)
				{
					JarBuyCost jarBuyCost2 = buyInfo.arrCosts[k];
					int realCostCount2 = jarBuyCost2.GetRealCostCount(buyInfo.nBuyCount);
					ActivityJarFrame.AdjustCostByActivityDiscount(ref realCostCount2, jarBuyCost2.item.Count, buyInfo.nBuyCount);
					if (buyInfo.nBuyCount == 10 && a_frameData.data.eType == JarBonus.eType.MagicJar && jarBuyCost2.item.Type == ItemTable.eType.INCOME && discountItemCount > 0 && certificateItemCount < 10)
					{
						ItemTable magicPotDiscountTableData3 = DataManager<JarDataManager>.GetInstance().GetMagicPotDiscountTableData();
						int nCount = realCostCount2 * magicPotDiscountTableData3.DiscountCouponProp / 100;
						costInfo.nMoneyID = jarBuyCost2.item.TableID;
						costInfo.nCount = nCount;
						break;
					}
					if (realCostCount2 <= DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(jarBuyCost2.item.TableID, true))
					{
						costInfo.nMoneyID = jarBuyCost2.item.TableID;
						costInfo.nCount = realCostCount2;
						break;
					}
					if (k == buyInfo.arrCosts.Count - 1)
					{
						costInfo.nMoneyID = jarBuyCost2.item.TableID;
						costInfo.nCount = realCostCount2;
					}
				}
				UnityAction unityAction = delegate()
				{
					DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
					{
						if (buyInfo.nBuyCount == 10 && a_frameData.data.eType == JarBonus.eType.MagicJar && discountItemCount > 0 && certificateItemCount < 10)
						{
							int id = DataManager<JarDataManager>.GetInstance().GetMagicPotDiscountTableData().ID;
							DataManager<JarDataManager>.GetInstance().RequestBuyJar(a_frameData.data, buyInfo, ActivityJarFrame.GetArtifactActivityID(), (uint)id);
							return;
						}
						DataManager<JarDataManager>.GetInstance().RequestBuyJar(a_frameData.data, buyInfo, ActivityJarFrame.GetArtifactActivityID(), 0U);
					}, "common_money_cost", null);
				};
				unityAction.Invoke();
			});
			Utility.GetComponetInChild<Text>(gameObject, "Time").text = TR.Value("magicjar_buy_again_time", buyInfo.nBuyCount);
			Text componetInChild = Utility.GetComponetInChild<Text>(gameObject, "Price/Count");
			Image componetInChild2 = Utility.GetComponetInChild<Image>(gameObject, "Price/Icon");
			Image image = null;
			GameObject gameObject2 = null;
			Text text = null;
			int num = 0;
			int num2 = 0;
			if (buyInfo.nBuyCount == 10 && a_frameData.data.eType == JarBonus.eType.MagicJar)
			{
				GameObject gameObject3 = Utility.FindGameObject(gameObject, "DiscountRoot", true);
				image = Utility.GetComponetInChild<Image>(gameObject, "DiscountRoot/Icon");
				Text componetInChild3 = Utility.GetComponetInChild<Text>(gameObject, "DiscountRoot/Count");
				gameObject2 = Utility.FindGameObject(gameObject, "Price/Line", true);
				text = Utility.GetComponetInChild<Text>(gameObject, "Price/DiscountPrice");
				if (gameObject2 != null)
				{
					gameObject2.CustomActive(false);
				}
				if (gameObject3 != null)
				{
					gameObject3.CustomActive(false);
				}
				if (text != null)
				{
					text.CustomActive(false);
				}
				num = DataManager<JarDataManager>.GetInstance().GetMagicPotDiscountCount();
				num2 = DataManager<JarDataManager>.GetInstance().GetMagicPotCredentialsCount(buyInfo);
				if (num > 0 && num2 < 10)
				{
					if (gameObject3 != null)
					{
						gameObject3.CustomActive(true);
					}
					ItemTable magicPotDiscountTableData = DataManager<JarDataManager>.GetInstance().GetMagicPotDiscountTableData();
					if (image != null)
					{
						ETCImageLoader.LoadSprite(ref image, magicPotDiscountTableData.Icon, true);
					}
					if (componetInChild3 != null)
					{
						componetInChild3.text = string.Format("1/{0}", num);
					}
				}
			}
			if (buyInfo.arrCosts != null)
			{
				for (int j = 0; j < buyInfo.arrCosts.Count; j++)
				{
					JarBuyCost jarBuyCost = buyInfo.arrCosts[j];
					int realCostCount = jarBuyCost.GetRealCostCount(buyInfo.nBuyCount);
					ActivityJarFrame.AdjustCostByActivityDiscount(ref realCostCount, jarBuyCost.item.Count, buyInfo.nBuyCount);
					if (buyInfo.nBuyCount == 10 && a_frameData.data.eType == JarBonus.eType.MagicJar && jarBuyCost.item.Type == ItemTable.eType.INCOME && num > 0 && num2 < 10)
					{
						ItemTable magicPotDiscountTableData2 = DataManager<JarDataManager>.GetInstance().GetMagicPotDiscountTableData();
						int num3 = realCostCount * magicPotDiscountTableData2.DiscountCouponProp / 100;
						if (gameObject2 != null)
						{
							gameObject2.CustomActive(true);
						}
						if (text != null)
						{
							text.CustomActive(true);
						}
						if (num3 <= DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(jarBuyCost.item.TableID, true))
						{
							componetInChild.text = TR.Value("color_yellow", realCostCount);
							if (text != null)
							{
								text.text = TR.Value("color_white", num3);
							}
							ETCImageLoader.LoadSprite(ref componetInChild2, jarBuyCost.item.Icon, true);
						}
						else
						{
							componetInChild.text = TR.Value("color_yellow", realCostCount);
							ETCImageLoader.LoadSprite(ref componetInChild2, jarBuyCost.item.Icon, true);
							if (text != null)
							{
								text.text = TR.Value("color_red", num3);
							}
						}
						break;
					}
					if (realCostCount <= DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(jarBuyCost.item.TableID, true))
					{
						componetInChild.text = TR.Value("color_white", realCostCount);
						ETCImageLoader.LoadSprite(ref componetInChild2, jarBuyCost.item.Icon, true);
						break;
					}
					if (j == buyInfo.arrCosts.Count - 1)
					{
						componetInChild.text = TR.Value("color_red", realCostCount);
						ETCImageLoader.LoadSprite(ref componetInChild2, jarBuyCost.item.Icon, true);
					}
				}
			}
			this._SetupFreeCD(gameObject, buyInfo);
		}

		// Token: 0x0600E73F RID: 59199 RVA: 0x003CE950 File Offset: 0x003CCD50
		private void _OnShowTips(int result)
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(result, 100, 0);
			if (itemData == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
		}

		// Token: 0x0600E740 RID: 59200 RVA: 0x003CE97E File Offset: 0x003CCD7E
		private void _CloseAutoOpen()
		{
			this.m_objCustomOpen.SetActive(false);
			if (this.m_coroutine != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.m_coroutine);
				this.m_coroutine = null;
			}
		}

		// Token: 0x0600E741 RID: 59201 RVA: 0x003CE9B0 File Offset: 0x003CCDB0
		private void _OpenHighValueCard(List<ShowItemsFrame.ItemInfo> a_arrItemInfos)
		{
			for (int i = 0; i < a_arrItemInfos.Count; i++)
			{
				ShowItemsFrame.ItemInfo itemInfo = a_arrItemInfos[i];
				if (itemInfo.bonus.bHighValue && !itemInfo.comCardEffect.bFinished)
				{
					itemInfo.animator.enabled = true;
					itemInfo.btnBack.onClick.RemoveAllListeners();
				}
			}
		}

		// Token: 0x0600E742 RID: 59202 RVA: 0x003CEA18 File Offset: 0x003CCE18
		private void _SetupFreeCD(GameObject a_objBuy, JarBuyInfo a_buyInfo)
		{
			GameObject gameObject = Utility.FindGameObject(a_objBuy, "Price", true);
			GameObject gameObject2 = Utility.FindGameObject(a_objBuy, "Free", false);
			if (a_buyInfo.nMaxFreeCount > 0)
			{
				if (gameObject2 != null)
				{
					gameObject2.SetActive(a_buyInfo.nFreeCount > 0);
					Text component = gameObject2.GetComponent<Text>();
					component.text = TR.Value("jar_free", a_buyInfo.nFreeCount, a_buyInfo.nMaxFreeCount);
				}
				gameObject.gameObject.SetActive(a_buyInfo.nFreeCount <= 0);
			}
			else
			{
				if (gameObject2 != null)
				{
					gameObject2.SetActive(false);
				}
				gameObject.gameObject.SetActive(true);
			}
		}

		// Token: 0x0600E743 RID: 59203 RVA: 0x003CEACE File Offset: 0x003CCECE
		private void _OnJarUseSuccess(UIEvent a_event)
		{
			this.frameMgr.CloseFrame<ShowItemsFrame>(this, false);
		}

		// Token: 0x0600E744 RID: 59204 RVA: 0x003CEADD File Offset: 0x003CCEDD
		private void _OnJarUseFail(UIEvent a_event)
		{
			this.frameMgr.CloseFrame<ShowItemsFrame>(this, false);
		}

		// Token: 0x0600E745 RID: 59205 RVA: 0x003CEAEC File Offset: 0x003CCEEC
		private void _OnMoneyChanged(UIEvent a_event)
		{
			this._SetupBuybtns(this.userData as ShowItemsFrameData);
		}

		// Token: 0x0600E746 RID: 59206 RVA: 0x003CEAFF File Offset: 0x003CCEFF
		private void _OnFreeTimeChanged(UIEvent a_event)
		{
			this._SetupBuybtns(this.userData as ShowItemsFrameData);
		}

		// Token: 0x0600E747 RID: 59207 RVA: 0x003CEB12 File Offset: 0x003CCF12
		[UIEventHandle("Result/Buy/Func")]
		private void _OnReturnClicked()
		{
			this.frameMgr.CloseFrame<ShowItemsFrame>(this, false);
		}

		// Token: 0x0600E748 RID: 59208 RVA: 0x003CEB21 File Offset: 0x003CCF21
		[UIEventHandle("Result/CustomOpen/Open")]
		private void _OnCustomOpenClicked()
		{
		}

		// Token: 0x0600E749 RID: 59209 RVA: 0x003CEB23 File Offset: 0x003CCF23
		protected override void _bindExUI()
		{
			this.mRewardItem = this.mBind.GetGameObject("rewardItem");
			this.mText = this.mBind.GetCom<Text>("text");
		}

		// Token: 0x0600E74A RID: 59210 RVA: 0x003CEB51 File Offset: 0x003CCF51
		protected override void _unbindExUI()
		{
			this.mRewardItem = null;
			this.mText = null;
		}

		// Token: 0x04008C2C RID: 35884
		[UIObject("Explode")]
		private GameObject m_objExplodeRoot;

		// Token: 0x04008C2D RID: 35885
		[UIControl("Explode/Progress", null, 0)]
		private Slider m_explodeProgress;

		// Token: 0x04008C2E RID: 35886
		[UIControl("Explode/Progress/Name", null, 0)]
		private Text m_explodeRandomName;

		// Token: 0x04008C2F RID: 35887
		[UIControl("Result/Desc", null, 0)]
		private Text m_labBuyResult;

		// Token: 0x04008C30 RID: 35888
		[UIObject("Result/ItemGroup/10")]
		private GameObject m_objItem_x10;

		// Token: 0x04008C31 RID: 35889
		[UIObject("Result/ItemGroup/10/Final")]
		private GameObject m_objFinalItem_x10;

		// Token: 0x04008C32 RID: 35890
		[UIObject("Result/ItemGroup/10/Effect")]
		private GameObject m_objEffectItem_x10;

		// Token: 0x04008C33 RID: 35891
		[UIObject("Result/ItemGroup/1")]
		private GameObject m_objItem_x1;

		// Token: 0x04008C34 RID: 35892
		[UIObject("Result/ItemGroup/1/Final")]
		private GameObject m_objFinalItem_x1;

		// Token: 0x04008C35 RID: 35893
		[UIObject("Result/ItemGroup/1/Effect")]
		private GameObject m_objEffectItem_x1;

		// Token: 0x04008C36 RID: 35894
		[UIObject("Result/Score")]
		private GameObject m_objScore;

		// Token: 0x04008C37 RID: 35895
		[UIControl("Result/Score/Desc", null, 0)]
		private Text m_labScoreDesc;

		// Token: 0x04008C38 RID: 35896
		[UIControl("Result/Score/Rate", null, 0)]
		private Text m_labScoreRate;

		// Token: 0x04008C39 RID: 35897
		[UIObject("Result/Buy")]
		private GameObject m_objBuyRoot;

		// Token: 0x04008C3A RID: 35898
		[UIObject("Result/Mask")]
		private GameObject m_objMask;

		// Token: 0x04008C3B RID: 35899
		[UIObject("Result/CustomOpen")]
		private GameObject m_objCustomOpen;

		// Token: 0x04008C3C RID: 35900
		[UIControl("Result/CustomOpen/Desc", null, 0)]
		private Text m_labCustomOpenDesc;

		// Token: 0x04008C3D RID: 35901
		[UIControl("Result/CustomOpen/Open", null, 0)]
		private Button m_btnCustomOpen;

		// Token: 0x04008C3E RID: 35902
		public static bool bSkipExplode;

		// Token: 0x04008C3F RID: 35903
		private List<ShowItemsFrame.ItemInfo> m_multiItemInfos = new List<ShowItemsFrame.ItemInfo>();

		// Token: 0x04008C40 RID: 35904
		private List<ShowItemsFrame.ItemInfo> m_singleItemInfo = new List<ShowItemsFrame.ItemInfo>();

		// Token: 0x04008C41 RID: 35905
		private Coroutine m_coroutine;

		// Token: 0x04008C42 RID: 35906
		private GameObject mRewardItem;

		// Token: 0x04008C43 RID: 35907
		private Text mText;

		// Token: 0x02001701 RID: 5889
		private class ItemInfo
		{
			// Token: 0x04008C46 RID: 35910
			public JarBonus bonus;

			// Token: 0x04008C47 RID: 35911
			public Text labName;

			// Token: 0x04008C48 RID: 35912
			public ComItem comItem;

			// Token: 0x04008C49 RID: 35913
			public ComCardEffect comCardEffect;

			// Token: 0x04008C4A RID: 35914
			public RectTransform tranRoot;

			// Token: 0x04008C4B RID: 35915
			public Animator animator;

			// Token: 0x04008C4C RID: 35916
			public ComItem comItemEffect;

			// Token: 0x04008C4D RID: 35917
			public Text labNameEffect;

			// Token: 0x04008C4E RID: 35918
			public Button btnBack;

			// Token: 0x04008C4F RID: 35919
			public Image imgBack;

			// Token: 0x04008C50 RID: 35920
			public Transform tranParBack;

			// Token: 0x04008C51 RID: 35921
			public Transform tranParFront;

			// Token: 0x04008C52 RID: 35922
			public Transform tranParTurnover;
		}
	}
}
