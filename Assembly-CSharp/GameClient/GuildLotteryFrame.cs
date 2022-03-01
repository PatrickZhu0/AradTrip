using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001627 RID: 5671
	internal class GuildLotteryFrame : ClientFrame
	{
		// Token: 0x0600DEAB RID: 57003 RVA: 0x0038A891 File Offset: 0x00388C91
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildLottery";
		}

		// Token: 0x0600DEAC RID: 57004 RVA: 0x0038A898 File Offset: 0x00388C98
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

		// Token: 0x0600DEAD RID: 57005 RVA: 0x0038A8D6 File Offset: 0x00388CD6
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

		// Token: 0x0600DEAE RID: 57006 RVA: 0x0038A918 File Offset: 0x00388D18
		protected void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.MagicJarUseSuccess, new ClientEventSystem.UIEventHandler(this._OnJarUseSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.MagicJarUseFail, new ClientEventSystem.UIEventHandler(this._OnJarUseFail));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PlayerDataBaseUpdated, new ClientEventSystem.UIEventHandler(this._OnMoneyChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.JarFreeTimeChanged, new ClientEventSystem.UIEventHandler(this._OnFreeTimeChanged));
		}

		// Token: 0x0600DEAF RID: 57007 RVA: 0x0038A990 File Offset: 0x00388D90
		protected void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.MagicJarUseSuccess, new ClientEventSystem.UIEventHandler(this._OnJarUseSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.MagicJarUseFail, new ClientEventSystem.UIEventHandler(this._OnJarUseFail));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PlayerDataBaseUpdated, new ClientEventSystem.UIEventHandler(this._OnMoneyChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.JarFreeTimeChanged, new ClientEventSystem.UIEventHandler(this._OnFreeTimeChanged));
		}

		// Token: 0x0600DEB0 RID: 57008 RVA: 0x0038AA08 File Offset: 0x00388E08
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
			imgRandomBG.gameObject.SetActive(false);
			Image imgRandomIcon = Utility.GetComponetInChild<Image>(objJarEffect, "p_Pot02/Bone007/Dummy001/Icon");
			imgRandomIcon.gameObject.SetActive(false);
			if (jarData.arrRealBonusItems.Count > 0)
			{
				animRandom.onStepComplete.RemoveAllListeners();
				animRandom.onStepComplete.AddListener(delegate()
				{
					int index = Random.Range(0, jarData.arrRealBonusItems.Count - 1);
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(jarData.arrRealBonusItems[index].ItemID, 100, 0);
					itemData.Count = jarData.arrRealBonusItems[index].Count;
					itemData.Name = jarData.arrRealBonusItems[index].Name;
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
			yield return Yielders.GetWaitForSeconds(0.5f);
			MonoSingleton<AudioManager>.instance.PlaySound(21);
			this.m_explodeProgress.gameObject.SetActive(true);
			this.m_explodeRandomName.gameObject.SetActive(true);
			TweenExtensions.Restart(animRandom.tween, true);
			float maxTime = 2.2f;
			this.m_explodeProgress.value = 0f;
			float startTime = Time.time;
			float elapsed = 0f;
			while (elapsed < maxTime)
			{
				elapsed = Time.time - startTime;
				this.m_explodeProgress.value = elapsed / maxTime;
				yield return Yielders.EndOfFrame;
			}
			this.m_explodeProgress.value = 1f;
			this.m_explodeProgress.gameObject.SetActive(false);
			this.m_explodeRandomName.gameObject.SetActive(false);
			animRandom.gameObject.SetActive(false);
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

		// Token: 0x0600DEB1 RID: 57009 RVA: 0x0038AA2C File Offset: 0x00388E2C
		private GuildLotteryFrame.ItemInfo _InitItemUI(GameObject a_objItemGroup, int a_nIdx)
		{
			GuildLotteryFrame.ItemInfo itemInfo = new GuildLotteryFrame.ItemInfo();
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

		// Token: 0x0600DEB2 RID: 57010 RVA: 0x0038AB74 File Offset: 0x00388F74
		private IEnumerator _PlayItemsEffect(ShowItemsFrameData a_frameData, List<GuildLotteryFrame.ItemInfo> a_arrItemInfos, GameObject a_objItemsRoot, GameObject a_objJarEffect)
		{
			List<JarBonus> arrBonus = a_frameData.items.GetRange(1, a_frameData.items.Count - 1);
			for (int i = 0; i < a_arrItemInfos.Count; i++)
			{
				this._SetupItemInfo(a_arrItemInfos[i], arrBonus[i]);
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
				for (int j = 0; j < a_arrItemInfos.Count; j++)
				{
					if (!a_arrItemInfos[j].comCardEffect.bFinished)
					{
						bNeedWait = true;
						break;
					}
					a_arrItemInfos[j].animator.enabled = false;
				}
				if (!bNeedWait)
				{
					break;
				}
				yield return Yielders.GetWaitForSeconds(0.1f);
			}
			this._CloseAutoOpen();
			Object.Destroy(a_objJarEffect);
			yield break;
		}

		// Token: 0x0600DEB3 RID: 57011 RVA: 0x0038ABAC File Offset: 0x00388FAC
		private IEnumerator _AutoOpenCountdown(List<GuildLotteryFrame.ItemInfo> a_arrItemInfos)
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

		// Token: 0x0600DEB4 RID: 57012 RVA: 0x0038ABD0 File Offset: 0x00388FD0
		private void _PlayTurnoverEffects(List<GuildLotteryFrame.ItemInfo> a_arrItemInfos)
		{
			bool flag = false;
			for (int i = 0; i < a_arrItemInfos.Count; i++)
			{
				GuildLotteryFrame.ItemInfo itemInfo = a_arrItemInfos[i];
				if (!itemInfo.bonus.bHighValue)
				{
					itemInfo.animator.enabled = true;
					itemInfo.btnBack.onClick.RemoveAllListeners();
				}
				else
				{
					itemInfo.animator.enabled = false;
					itemInfo.btnBack.onClick.RemoveAllListeners();
					itemInfo.btnBack.onClick.AddListener(delegate()
					{
						itemInfo.animator.enabled = true;
					});
					flag = true;
				}
			}
			if (flag)
			{
				this.m_objCustomOpen.SetActive(true);
				if (this.m_coroutine != null)
				{
					MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.m_coroutine);
					this.m_coroutine = null;
				}
				this.m_coroutine = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._AutoOpenCountdown(a_arrItemInfos));
				this.m_btnCustomOpen.onClick.RemoveAllListeners();
				this.m_btnCustomOpen.onClick.AddListener(delegate()
				{
					this._CloseAutoOpen();
					this._OpenHighValueCard(a_arrItemInfos);
				});
			}
			else
			{
				this.m_objCustomOpen.SetActive(false);
			}
		}

		// Token: 0x0600DEB5 RID: 57013 RVA: 0x0038AD40 File Offset: 0x00389140
		private void _SetupCardPar(GuildLotteryFrame.ItemInfo a_itemInfo)
		{
			switch (a_itemInfo.bonus.item.GetQualityInfo().Quality)
			{
			case ItemTable.eColor.GREEN:
			{
				GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadRes("Effects/Scene_effects/EffectUI/Fanka/EffUI_pinjikuang_4bei", true, 0U).obj as GameObject;
				gameObject.transform.SetParent(a_itemInfo.tranParBack, false);
				gameObject.SetActive(true);
				GameObject gameObject2 = Singleton<AssetLoader>.GetInstance().LoadRes("Effects/Scene_effects/EffectUI/Fanka/EffUI_pinjikuang_4", true, 0U).obj as GameObject;
				gameObject2.transform.SetParent(a_itemInfo.tranParFront, false);
				gameObject2.SetActive(true);
				break;
			}
			case ItemTable.eColor.PINK:
			{
				GameObject gameObject3 = Singleton<AssetLoader>.GetInstance().LoadRes("Effects/Scene_effects/EffectUI/Fanka/EffUI_pinjikuang_5bei", true, 0U).obj as GameObject;
				gameObject3.transform.SetParent(a_itemInfo.tranParBack, false);
				gameObject3.SetActive(true);
				GameObject gameObject4 = Singleton<AssetLoader>.GetInstance().LoadRes("Effects/Scene_effects/EffectUI/Fanka/EffUI_pinjikuang_5", true, 0U).obj as GameObject;
				gameObject4.transform.SetParent(a_itemInfo.tranParFront, false);
				gameObject4.SetActive(true);
				break;
			}
			case ItemTable.eColor.YELLOW:
			{
				GameObject gameObject5 = Singleton<AssetLoader>.GetInstance().LoadRes("Effects/Scene_effects/EffectUI/Fanka/EffUI_pinjikuang_6bei", true, 0U).obj as GameObject;
				gameObject5.transform.SetParent(a_itemInfo.tranParBack, false);
				gameObject5.SetActive(true);
				GameObject gameObject6 = Singleton<AssetLoader>.GetInstance().LoadRes("Effects/Scene_effects/EffectUI/Fanka/EffUI_pinjikuang_6", true, 0U).obj as GameObject;
				gameObject6.transform.SetParent(a_itemInfo.tranParFront, false);
				gameObject6.SetActive(true);
				break;
			}
			default:
				if (a_itemInfo.bonus.bHighValue)
				{
					GameObject gameObject7 = Singleton<AssetLoader>.GetInstance().LoadRes("Effects/Scene_effects/EffectUI/Fanka/EffUI_pinjikuang_3bei", true, 0U).obj as GameObject;
					gameObject7.transform.SetParent(a_itemInfo.tranParBack, false);
					gameObject7.SetActive(true);
					GameObject gameObject8 = Singleton<AssetLoader>.GetInstance().LoadRes("Effects/Scene_effects/EffectUI/Fanka/EffUI_pinjikuang_3", true, 0U).obj as GameObject;
					gameObject8.transform.SetParent(a_itemInfo.tranParFront, false);
					gameObject8.SetActive(true);
				}
				break;
			}
			if (a_itemInfo.bonus.bHighValue)
			{
				GameObject gameObject9 = Singleton<AssetLoader>.GetInstance().LoadRes("Effects/Scene_effects/EffectUI/Fanka/EffUI_fan", true, 0U).obj as GameObject;
				gameObject9.transform.SetParent(a_itemInfo.tranParTurnover, false);
				gameObject9.SetActive(true);
			}
		}

		// Token: 0x0600DEB6 RID: 57014 RVA: 0x0038AFA0 File Offset: 0x003893A0
		private void _SetupItemInfo(GuildLotteryFrame.ItemInfo a_itemInfo, JarBonus a_bonus)
		{
			for (int i = 0; i < a_itemInfo.tranParBack.childCount; i++)
			{
				Object.Destroy(a_itemInfo.tranParBack.GetChild(i).gameObject);
			}
			for (int j = 0; j < a_itemInfo.tranParFront.childCount; j++)
			{
				Object.Destroy(a_itemInfo.tranParFront.GetChild(j).gameObject);
			}
			for (int k = 0; k < a_itemInfo.tranParTurnover.childCount; k++)
			{
				Object.Destroy(a_itemInfo.tranParTurnover.GetChild(k).gameObject);
			}
			a_itemInfo.btnBack.gameObject.SetActive(true);
			a_itemInfo.btnBack.onClick.RemoveAllListeners();
			a_itemInfo.comCardEffect.bFinished = false;
			string path;
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
			ETCImageLoader.LoadSprite(ref a_itemInfo.imgBack, path, true);
			a_itemInfo.tranRoot.localRotation = Quaternion.identity;
			a_itemInfo.tranRoot.localScale = new Vector3(1f, 1f, 1f);
			for (int l = 0; l < a_itemInfo.tranRoot.childCount; l++)
			{
				Transform child = a_itemInfo.tranRoot.GetChild(l);
				child.localRotation = Quaternion.identity;
				child.localScale = new Vector3(1f, 1f, 1f);
			}
			a_itemInfo.bonus = a_bonus;
			a_itemInfo.comItem.Setup(a_itemInfo.bonus.item, delegate(GameObject var1, ItemData var2)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
			});
			a_itemInfo.labName.text = a_itemInfo.bonus.item.GetColorName(string.Empty, false);
			a_itemInfo.comItemEffect.Setup(a_itemInfo.bonus.item, delegate(GameObject var1, ItemData var2)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
			});
			a_itemInfo.labNameEffect.text = a_itemInfo.bonus.item.GetColorName(string.Empty, false);
			this._SetupCardPar(a_itemInfo);
		}

		// Token: 0x0600DEB7 RID: 57015 RVA: 0x0038B20C File Offset: 0x0038960C
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
			JarBuyInfo buyInfo = a_frameData.buyInfo;
			Button component = gameObject.GetComponent<Button>();
			component.onClick.RemoveAllListeners();
			component.onClick.AddListener(delegate()
			{
				ShowItemsFrame.bSkipExplode = false;
				if (buyInfo.nFreeCount > 0)
				{
					DataManager<JarDataManager>.GetInstance().RequestBuyJar(a_frameData.data, buyInfo, 0U, 0U);
					return;
				}
				CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
				for (int k = 0; k < buyInfo.arrCosts.Count; k++)
				{
					JarBuyCost jarBuyCost2 = buyInfo.arrCosts[k];
					int realCostCount2 = jarBuyCost2.GetRealCostCount(buyInfo.nBuyCount);
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
				DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
				{
				}, "common_money_cost", null);
			});
			Utility.GetComponetInChild<Text>(gameObject, "Time").text = TR.Value("magicjar_buy_again_time", buyInfo.nBuyCount);
			Text componetInChild = Utility.GetComponetInChild<Text>(gameObject, "Price/Count");
			Image componetInChild2 = Utility.GetComponetInChild<Image>(gameObject, "Price/Icon");
			for (int j = 0; j < buyInfo.arrCosts.Count; j++)
			{
				JarBuyCost jarBuyCost = buyInfo.arrCosts[j];
				int realCostCount = jarBuyCost.GetRealCostCount(buyInfo.nBuyCount);
				if (realCostCount <= DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(jarBuyCost.item.TableID, true))
				{
					componetInChild.text = realCostCount.ToString();
					ETCImageLoader.LoadSprite(ref componetInChild2, jarBuyCost.item.Icon, true);
					break;
				}
				if (j == buyInfo.arrCosts.Count - 1)
				{
					componetInChild.text = TR.Value("color_red", realCostCount);
					ETCImageLoader.LoadSprite(ref componetInChild2, jarBuyCost.item.Icon, true);
				}
			}
			this._SetupFreeCD(gameObject, buyInfo);
		}

		// Token: 0x0600DEB8 RID: 57016 RVA: 0x0038B3FC File Offset: 0x003897FC
		private void _CloseAutoOpen()
		{
			this.m_objCustomOpen.SetActive(false);
			if (this.m_coroutine != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.m_coroutine);
				this.m_coroutine = null;
			}
		}

		// Token: 0x0600DEB9 RID: 57017 RVA: 0x0038B42C File Offset: 0x0038982C
		private void _OpenHighValueCard(List<GuildLotteryFrame.ItemInfo> a_arrItemInfos)
		{
			for (int i = 0; i < a_arrItemInfos.Count; i++)
			{
				GuildLotteryFrame.ItemInfo itemInfo = a_arrItemInfos[i];
				if (itemInfo.bonus.bHighValue && !itemInfo.comCardEffect.bFinished)
				{
					itemInfo.animator.enabled = true;
					itemInfo.btnBack.onClick.RemoveAllListeners();
				}
			}
		}

		// Token: 0x0600DEBA RID: 57018 RVA: 0x0038B494 File Offset: 0x00389894
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

		// Token: 0x0600DEBB RID: 57019 RVA: 0x0038B54A File Offset: 0x0038994A
		private void _OnJarUseSuccess(UIEvent a_event)
		{
			this.frameMgr.CloseFrame<GuildLotteryFrame>(this, false);
		}

		// Token: 0x0600DEBC RID: 57020 RVA: 0x0038B559 File Offset: 0x00389959
		private void _OnJarUseFail(UIEvent a_event)
		{
			this.frameMgr.CloseFrame<GuildLotteryFrame>(this, false);
		}

		// Token: 0x0600DEBD RID: 57021 RVA: 0x0038B568 File Offset: 0x00389968
		private void _OnMoneyChanged(UIEvent a_event)
		{
			this._SetupBuybtns(this.userData as ShowItemsFrameData);
		}

		// Token: 0x0600DEBE RID: 57022 RVA: 0x0038B57B File Offset: 0x0038997B
		private void _OnFreeTimeChanged(UIEvent a_event)
		{
			this._SetupBuybtns(this.userData as ShowItemsFrameData);
		}

		// Token: 0x0600DEBF RID: 57023 RVA: 0x0038B58E File Offset: 0x0038998E
		[UIEventHandle("Result/Buy/Func")]
		private void _OnReturnClicked()
		{
			this.frameMgr.CloseFrame<GuildLotteryFrame>(this, false);
		}

		// Token: 0x0600DEC0 RID: 57024 RVA: 0x0038B59D File Offset: 0x0038999D
		[UIEventHandle("Result/CustomOpen/Open")]
		private void _OnCustomOpenClicked()
		{
		}

		// Token: 0x04008404 RID: 33796
		[UIObject("Explode")]
		private GameObject m_objExplodeRoot;

		// Token: 0x04008405 RID: 33797
		[UIControl("Explode/Progress", null, 0)]
		private Slider m_explodeProgress;

		// Token: 0x04008406 RID: 33798
		[UIControl("Explode/Progress/Name", null, 0)]
		private Text m_explodeRandomName;

		// Token: 0x04008407 RID: 33799
		[UIControl("Result/Desc", null, 0)]
		private Text m_labBuyResult;

		// Token: 0x04008408 RID: 33800
		[UIObject("Result/ItemGroup/10")]
		private GameObject m_objItem_x10;

		// Token: 0x04008409 RID: 33801
		[UIObject("Result/ItemGroup/10/Final")]
		private GameObject m_objFinalItem_x10;

		// Token: 0x0400840A RID: 33802
		[UIObject("Result/ItemGroup/10/Effect")]
		private GameObject m_objEffectItem_x10;

		// Token: 0x0400840B RID: 33803
		[UIObject("Result/ItemGroup/1")]
		private GameObject m_objItem_x1;

		// Token: 0x0400840C RID: 33804
		[UIObject("Result/ItemGroup/1/Final")]
		private GameObject m_objFinalItem_x1;

		// Token: 0x0400840D RID: 33805
		[UIObject("Result/ItemGroup/1/Effect")]
		private GameObject m_objEffectItem_x1;

		// Token: 0x0400840E RID: 33806
		[UIObject("Result/Score")]
		private GameObject m_objScore;

		// Token: 0x0400840F RID: 33807
		[UIControl("Result/Score/Desc", null, 0)]
		private Text m_labScoreDesc;

		// Token: 0x04008410 RID: 33808
		[UIControl("Result/Score/Rate", null, 0)]
		private Text m_labScoreRate;

		// Token: 0x04008411 RID: 33809
		[UIObject("Result/Buy")]
		private GameObject m_objBuyRoot;

		// Token: 0x04008412 RID: 33810
		[UIObject("Result/Mask")]
		private GameObject m_objMask;

		// Token: 0x04008413 RID: 33811
		[UIObject("Result/CustomOpen")]
		private GameObject m_objCustomOpen;

		// Token: 0x04008414 RID: 33812
		[UIControl("Result/CustomOpen/Desc", null, 0)]
		private Text m_labCustomOpenDesc;

		// Token: 0x04008415 RID: 33813
		[UIControl("Result/CustomOpen/Open", null, 0)]
		private Button m_btnCustomOpen;

		// Token: 0x04008416 RID: 33814
		private List<GuildLotteryFrame.ItemInfo> m_multiItemInfos = new List<GuildLotteryFrame.ItemInfo>();

		// Token: 0x04008417 RID: 33815
		private List<GuildLotteryFrame.ItemInfo> m_singleItemInfo = new List<GuildLotteryFrame.ItemInfo>();

		// Token: 0x04008418 RID: 33816
		private Coroutine m_coroutine;

		// Token: 0x02001628 RID: 5672
		private class ItemInfo
		{
			// Token: 0x0400841B RID: 33819
			public JarBonus bonus;

			// Token: 0x0400841C RID: 33820
			public Text labName;

			// Token: 0x0400841D RID: 33821
			public ComItem comItem;

			// Token: 0x0400841E RID: 33822
			public ComCardEffect comCardEffect;

			// Token: 0x0400841F RID: 33823
			public RectTransform tranRoot;

			// Token: 0x04008420 RID: 33824
			public Animator animator;

			// Token: 0x04008421 RID: 33825
			public ComItem comItemEffect;

			// Token: 0x04008422 RID: 33826
			public Text labNameEffect;

			// Token: 0x04008423 RID: 33827
			public Button btnBack;

			// Token: 0x04008424 RID: 33828
			public Image imgBack;

			// Token: 0x04008425 RID: 33829
			public Transform tranParBack;

			// Token: 0x04008426 RID: 33830
			public Transform tranParFront;

			// Token: 0x04008427 RID: 33831
			public Transform tranParTurnover;
		}
	}
}
