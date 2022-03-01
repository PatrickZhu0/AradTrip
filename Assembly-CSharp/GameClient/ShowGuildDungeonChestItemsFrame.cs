using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200166A RID: 5738
	internal class ShowGuildDungeonChestItemsFrame : ClientFrame
	{
		// Token: 0x0600E1A9 RID: 57769 RVA: 0x0039E9B0 File Offset: 0x0039CDB0
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/ShowActivityAwardItems";
		}

		// Token: 0x0600E1AA RID: 57770 RVA: 0x0039E9B8 File Offset: 0x0039CDB8
		protected override void _OnOpenFrame()
		{
			List<GuildDungeonActivityChestItem> list = this.userData as List<GuildDungeonActivityChestItem>;
			if (list == null)
			{
				Logger.LogError("open ShowGuildDungeonChestItemsFrame frame data is null");
				return;
			}
			base.StartCoroutine(this._ExplodeJar(list));
		}

		// Token: 0x0600E1AB RID: 57771 RVA: 0x0039E9F0 File Offset: 0x0039CDF0
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

		// Token: 0x0600E1AC RID: 57772 RVA: 0x0039EA30 File Offset: 0x0039CE30
		protected void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.MagicJarUseSuccess, new ClientEventSystem.UIEventHandler(this._OnJarUseSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.MagicJarUseFail, new ClientEventSystem.UIEventHandler(this._OnJarUseFail));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PlayerDataBaseUpdated, new ClientEventSystem.UIEventHandler(this._OnMoneyChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.JarFreeTimeChanged, new ClientEventSystem.UIEventHandler(this._OnFreeTimeChanged));
		}

		// Token: 0x0600E1AD RID: 57773 RVA: 0x0039EAA8 File Offset: 0x0039CEA8
		protected void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.MagicJarUseSuccess, new ClientEventSystem.UIEventHandler(this._OnJarUseSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.MagicJarUseFail, new ClientEventSystem.UIEventHandler(this._OnJarUseFail));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PlayerDataBaseUpdated, new ClientEventSystem.UIEventHandler(this._OnMoneyChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.JarFreeTimeChanged, new ClientEventSystem.UIEventHandler(this._OnFreeTimeChanged));
		}

		// Token: 0x0600E1AE RID: 57774 RVA: 0x0039EB20 File Offset: 0x0039CF20
		private IEnumerator _ExplodeJar(List<GuildDungeonActivityChestItem> a_frameData)
		{
			this.m_explodeProgress.gameObject.SetActive(false);
			this.m_explodeProgress.value = 0f;
			this.m_explodeRandomName.gameObject.SetActive(false);
			this.m_explodeRandomName.text = string.Empty;
			this.m_labBuyResult.gameObject.SetActive(false);
			this.m_objItem_x1.SetActive(false);
			this.m_objFinalItem_x1.SetActive(false);
			this.m_objEffectItem_x1.SetActive(false);
			this.m_objItem_x10.SetActive(true);
			this.m_objFinalItem_x10.SetActive(false);
			this.m_objEffectItem_x10.SetActive(false);
			this.m_objScore.SetActive(false);
			this.m_objBuyRoot.SetActive(false);
			this.m_objCustomOpen.SetActive(false);
			for (int i = 0; i < 1; i++)
			{
				if (i >= this.m_singleItemInfo.Count)
				{
					this.m_singleItemInfo.Add(this._InitItemUI(this.m_objItem_x1, i, "UIFlatten/Prefabs/Jar/JarItem_One"));
					yield return Yielders.EndOfFrame;
				}
			}
			for (int j = 0; j < 10; j++)
			{
				if (j >= this.m_multiItemInfos.Count)
				{
					this.m_multiItemInfos.Add(this._InitItemUI(this.m_objItem_x10, j, "UIFlatten/Prefabs/Jar/JarItem"));
					yield return Yielders.EndOfFrame;
				}
			}
			DOTweenAnimation[] anims = this.m_labScoreRate.GetComponents<DOTweenAnimation>();
			for (int k = 0; k < anims.Length; k++)
			{
				anims[k].DORewind();
				anims[k].isActive = false;
			}
			string strJarModelPath = "Actor/NPC_Guildbox/Prefabs/p_NPC_Guildbox_UI";
			GameObject objJarEffect = Singleton<AssetLoader>.GetInstance().LoadRes(strJarModelPath, true, 0U).obj as GameObject;
			objJarEffect.transform.SetParent(this.m_objExplodeRoot.transform, false);
			objJarEffect.SetActive(true);
			if (!ShowGuildDungeonChestItemsFrame.bSkipExplode)
			{
				yield return Yielders.GetWaitForSeconds(0.5f);
			}
			if (!ShowGuildDungeonChestItemsFrame.bSkipExplode)
			{
				MonoSingleton<AudioManager>.instance.PlaySound(21);
			}
			this.m_objExplodeRoot.CustomActive(true);
			if (this.btnExplodeBack != null)
			{
				this.btnExplodeBack.CustomActive(false);
			}
			if (this.txtSkip != null)
			{
				this.txtSkip.CustomActive(false);
			}
			float maxTime = 1.2f;
			this.m_explodeProgress.value = 0f;
			float startTime = Time.time;
			float elapsed = 0f;
			while (elapsed < maxTime)
			{
				if (ShowGuildDungeonChestItemsFrame.bSkipExplode)
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
			if (this.btnExplodeBack != null)
			{
				this.btnExplodeBack.CustomActive(false);
			}
			if (this.txtSkip != null)
			{
				this.txtSkip.CustomActive(false);
			}
			if (!ShowGuildDungeonChestItemsFrame.bSkipExplode)
			{
			}
			this.m_objExplodeRoot.CustomActive(false);
			yield return Yielders.EndOfFrame;
			this.frameMgr.CloseFrame<ShowGuildDungeonChestItemsFrame>(this, false);
			for (int l = 0; l < a_frameData.Count; l++)
			{
				SystemNotifyManager.SysNotifyGetNewItemEffect(a_frameData[l].itemData, a_frameData[l].isHighValue, string.Empty);
			}
			yield break;
		}

		// Token: 0x0600E1AF RID: 57775 RVA: 0x0039EB44 File Offset: 0x0039CF44
		private ShowGuildDungeonChestItemsFrame.ItemInfo _InitItemUI(GameObject a_objItemGroup, int a_nIdx, string strJarItemPrefab)
		{
			ShowGuildDungeonChestItemsFrame.ItemInfo itemInfo = new ShowGuildDungeonChestItemsFrame.ItemInfo();
			GameObject gameObject = Utility.FindGameObject(a_objItemGroup, string.Format("Final/ItemRoot_{0}", a_nIdx), true);
			GameObject gameObject2 = Utility.FindGameObject(a_objItemGroup, string.Format("Final/ItemRoot_{0}", a_nIdx), true);
			GameObject gameObject3 = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(strJarItemPrefab, true, 0U);
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
			itemInfo.tranRoot.gameObject.CustomActive(false);
			return itemInfo;
		}

		// Token: 0x0600E1B0 RID: 57776 RVA: 0x0039EC70 File Offset: 0x0039D070
		private IEnumerator _PlayItemsEffect(ShowItemsFrameData a_frameData, List<ShowGuildDungeonChestItemsFrame.ItemInfo> a_arrItemInfos, GameObject a_objItemsRoot, GameObject a_objJarEffect, bool bSingleJar)
		{
			ShowGuildDungeonChestItemsFrame.<_PlayItemsEffect>c__Iterator1.<_PlayItemsEffect>c__AnonStorey3 <_PlayItemsEffect>c__AnonStorey = new ShowGuildDungeonChestItemsFrame.<_PlayItemsEffect>c__Iterator1.<_PlayItemsEffect>c__AnonStorey3();
			<_PlayItemsEffect>c__AnonStorey.<>f__ref$1 = this;
			<_PlayItemsEffect>c__AnonStorey.a_arrItemInfos = a_arrItemInfos;
			float fInterval = 0f;
			float fStay = 0f;
			ShowItemsCfg cfg = base.GetFrame().GetComponent<ShowItemsCfg>();
			if (cfg != null)
			{
				fInterval = cfg.fAniInterval;
				fStay = cfg.fHighValueItemAniStayTime;
			}
			List<JarBonus> arrBonus = a_frameData.items.GetRange(1, a_frameData.items.Count - 1);
			int i;
			for (i = 0; i < <_PlayItemsEffect>c__AnonStorey.a_arrItemInfos.Count; i++)
			{
				this._SetupItemInfo(<_PlayItemsEffect>c__AnonStorey.a_arrItemInfos[i], arrBonus[i]);
				<_PlayItemsEffect>c__AnonStorey.a_arrItemInfos[i].tranRoot.gameObject.CustomActive(true);
				DOTweenAnimation[] anims = <_PlayItemsEffect>c__AnonStorey.a_arrItemInfos[i].tranRoot.GetComponents<DOTweenAnimation>();
				for (int j = 0; j < anims.Length; j++)
				{
					string id = anims[j].id;
					if (id != null && id == "scale")
					{
						TweenSettingsExtensions.OnComplete<Tween>(anims[j].tween, delegate()
						{
							Debug.LogWarning("scale complete");
							this._SetupCardPar(<_PlayItemsEffect>c__AnonStorey.a_arrItemInfos[i]);
						});
						TweenExtensions.Restart(anims[j].tween, true);
					}
					else if (id != null && id == "move")
					{
						TweenSettingsExtensions.OnComplete<Tween>(anims[j].tween, delegate()
						{
							Debug.LogWarning("move complete");
						});
						TweenExtensions.Restart(anims[j].tween, true);
					}
				}
				float fTime = fInterval;
				if (<_PlayItemsEffect>c__AnonStorey.a_arrItemInfos[i].bonus.bHighValue)
				{
					fTime += fStay;
				}
				yield return Yielders.GetWaitForSeconds(fTime);
			}
			DataManager<JarDataManager>.GetInstance().RequestJarBuyRecord(a_frameData.data.nID);
			this._CloseAutoOpen();
			Object.Destroy(a_objJarEffect);
			yield return 0;
			yield break;
		}

		// Token: 0x0600E1B1 RID: 57777 RVA: 0x0039ECA4 File Offset: 0x0039D0A4
		private IEnumerator _AutoOpenCountdown(List<ShowGuildDungeonChestItemsFrame.ItemInfo> a_arrItemInfos)
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

		// Token: 0x0600E1B2 RID: 57778 RVA: 0x0039ECC8 File Offset: 0x0039D0C8
		private void _PlayTurnoverEffects(List<ShowGuildDungeonChestItemsFrame.ItemInfo> a_arrItemInfos)
		{
			bool flag = false;
			for (int i = 0; i < a_arrItemInfos.Count; i++)
			{
				ShowGuildDungeonChestItemsFrame.ItemInfo itemInfo = a_arrItemInfos[i];
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

		// Token: 0x0600E1B3 RID: 57779 RVA: 0x0039EE38 File Offset: 0x0039D238
		private void _SetupCardPar(ShowGuildDungeonChestItemsFrame.ItemInfo a_itemInfo)
		{
			switch (a_itemInfo.bonus.item.GetQualityInfo().Quality)
			{
			case ItemTable.eColor.GREEN:
			{
				GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadRes("Effects/UI/Prefab/EffUI_pinji/Prefab/EffUI_pinjiguang_lvse", true, 0U).obj as GameObject;
				gameObject.transform.SetParent(a_itemInfo.tranParFront, false);
				gameObject.SetActive(true);
				break;
			}
			case ItemTable.eColor.PINK:
			{
				GameObject gameObject2 = Singleton<AssetLoader>.GetInstance().LoadRes("Effects/UI/Prefab/EffUI_pinji/Prefab/EffUI_pinjiguang_fense", true, 0U).obj as GameObject;
				gameObject2.transform.SetParent(a_itemInfo.tranParFront, false);
				gameObject2.SetActive(true);
				break;
			}
			case ItemTable.eColor.YELLOW:
			{
				GameObject gameObject3 = Singleton<AssetLoader>.GetInstance().LoadRes("Effects/UI/Prefab/EffUI_pinji/Prefab/EffUI_pinjiguang_jinse", true, 0U).obj as GameObject;
				gameObject3.transform.SetParent(a_itemInfo.tranParFront, false);
				gameObject3.SetActive(true);
				break;
			}
			default:
				if (a_itemInfo.bonus.bHighValue)
				{
					GameObject gameObject4 = Singleton<AssetLoader>.GetInstance().LoadRes("Effects/UI/Prefab/EffUI_pinji/Prefab/EffUI_pinjiguang_zise", true, 0U).obj as GameObject;
					gameObject4.transform.SetParent(a_itemInfo.tranParFront, false);
					gameObject4.SetActive(true);
				}
				break;
			}
			if (a_itemInfo.bonus.bHighValue)
			{
				GameObject gameObject5 = Singleton<AssetLoader>.GetInstance().LoadRes("Effects/Scene_effects/EffectUI/Fanka/EffUI_fan", true, 0U).obj as GameObject;
				gameObject5.transform.SetParent(a_itemInfo.tranParTurnover, false);
				gameObject5.SetActive(true);
			}
		}

		// Token: 0x0600E1B4 RID: 57780 RVA: 0x0039EFB8 File Offset: 0x0039D3B8
		private void _SetupItemInfo(ShowGuildDungeonChestItemsFrame.ItemInfo a_itemInfo, JarBonus a_bonus)
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
			a_itemInfo.btnBack.gameObject.SetActive(false);
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
			a_itemInfo.comItemEffect.Setup(a_itemInfo.bonus.item, delegate(GameObject var1, ItemData var2)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
			});
			a_itemInfo.labNameEffect.text = a_itemInfo.bonus.item.GetColorName(string.Empty, false);
		}

		// Token: 0x0600E1B5 RID: 57781 RVA: 0x0039F1CC File Offset: 0x0039D5CC
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
			component.onClick.RemoveAllListeners();
			component.onClick.AddListener(delegate()
			{
				ShowItemsFrame.bSkipExplode = true;
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
					DataManager<JarDataManager>.GetInstance().RequestBuyJar(a_frameData.data, buyInfo, 0U, 0U);
				}, "common_money_cost", null);
			});
			Utility.GetComponetInChild<Text>(gameObject, "Time").text = TR.Value("magicjar_buy_again_time", buyInfo.nBuyCount);
			Text componetInChild = Utility.GetComponetInChild<Text>(gameObject, "Price/Count");
			Image componetInChild2 = Utility.GetComponetInChild<Image>(gameObject, "Price/Icon");
			if (buyInfo.arrCosts != null)
			{
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
			}
			this._SetupFreeCD(gameObject, buyInfo);
		}

		// Token: 0x0600E1B6 RID: 57782 RVA: 0x0039F4EC File Offset: 0x0039D8EC
		private void _OnShowTips(int result)
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(result, 100, 0);
			if (itemData == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
		}

		// Token: 0x0600E1B7 RID: 57783 RVA: 0x0039F51A File Offset: 0x0039D91A
		private void _CloseAutoOpen()
		{
			this.m_objCustomOpen.SetActive(false);
			if (this.m_coroutine != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.m_coroutine);
				this.m_coroutine = null;
			}
		}

		// Token: 0x0600E1B8 RID: 57784 RVA: 0x0039F54C File Offset: 0x0039D94C
		private void _OpenHighValueCard(List<ShowGuildDungeonChestItemsFrame.ItemInfo> a_arrItemInfos)
		{
			for (int i = 0; i < a_arrItemInfos.Count; i++)
			{
				ShowGuildDungeonChestItemsFrame.ItemInfo itemInfo = a_arrItemInfos[i];
				if (itemInfo.bonus.bHighValue && !itemInfo.comCardEffect.bFinished)
				{
					itemInfo.animator.enabled = true;
					itemInfo.btnBack.onClick.RemoveAllListeners();
				}
			}
		}

		// Token: 0x0600E1B9 RID: 57785 RVA: 0x0039F5B4 File Offset: 0x0039D9B4
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

		// Token: 0x0600E1BA RID: 57786 RVA: 0x0039F66A File Offset: 0x0039DA6A
		private void _OnJarUseSuccess(UIEvent a_event)
		{
			this.frameMgr.CloseFrame<ShowGuildDungeonChestItemsFrame>(this, false);
		}

		// Token: 0x0600E1BB RID: 57787 RVA: 0x0039F679 File Offset: 0x0039DA79
		private void _OnJarUseFail(UIEvent a_event)
		{
			this.frameMgr.CloseFrame<ShowGuildDungeonChestItemsFrame>(this, false);
		}

		// Token: 0x0600E1BC RID: 57788 RVA: 0x0039F688 File Offset: 0x0039DA88
		private void _OnMoneyChanged(UIEvent a_event)
		{
			this._SetupBuybtns(this.userData as ShowItemsFrameData);
		}

		// Token: 0x0600E1BD RID: 57789 RVA: 0x0039F69B File Offset: 0x0039DA9B
		private void _OnFreeTimeChanged(UIEvent a_event)
		{
			this._SetupBuybtns(this.userData as ShowItemsFrameData);
		}

		// Token: 0x0600E1BE RID: 57790 RVA: 0x0039F6AE File Offset: 0x0039DAAE
		[UIEventHandle("Result/Buy/Func")]
		private void _OnReturnClicked()
		{
			this.frameMgr.CloseFrame<ShowGuildDungeonChestItemsFrame>(this, false);
		}

		// Token: 0x0600E1BF RID: 57791 RVA: 0x0039F6BD File Offset: 0x0039DABD
		[UIEventHandle("Result/CustomOpen/Open")]
		private void _OnCustomOpenClicked()
		{
		}

		// Token: 0x0600E1C0 RID: 57792 RVA: 0x0039F6C0 File Offset: 0x0039DAC0
		protected override void _bindExUI()
		{
			this.mRewardItem = this.mBind.GetGameObject("rewardItem");
			this.mText = this.mBind.GetCom<Text>("text");
			float time = Time.time;
			this.btnExplodeBack = this.mBind.GetCom<Button>("btnExplodeBack");
			if (this.btnExplodeBack != null)
			{
				this.btnExplodeBack.onClick.RemoveAllListeners();
				this.btnExplodeBack.onClick.AddListener(delegate()
				{
				});
			}
			this.txtSkip = this.mBind.GetCom<Text>("txtSkip");
			this.goGongxihuode = this.mBind.GetGameObject("gongxihuode");
			this.goBg1 = this.mBind.GetGameObject("BG (1)");
			this.goBg3 = this.mBind.GetGameObject("BG (3)");
			this.goGongxihuode_1 = this.mBind.GetGameObject("gongxihuode_1");
			this.goBg1_1 = this.mBind.GetGameObject("BG (1)_1");
			this.goBg3_1 = this.mBind.GetGameObject("BG (3)_1");
		}

		// Token: 0x0600E1C1 RID: 57793 RVA: 0x0039F800 File Offset: 0x0039DC00
		protected override void _unbindExUI()
		{
			this.mRewardItem = null;
			this.mText = null;
			this.btnExplodeBack = null;
			this.txtSkip = null;
			this.goGongxihuode = null;
			this.goBg1 = null;
			this.goBg3 = null;
			this.goGongxihuode_1 = null;
			this.goBg1_1 = null;
			this.goBg3_1 = null;
		}

		// Token: 0x04008668 RID: 34408
		[UIObject("Explode")]
		private GameObject m_objExplodeRoot;

		// Token: 0x04008669 RID: 34409
		[UIControl("Explode/Progress", null, 0)]
		private Slider m_explodeProgress;

		// Token: 0x0400866A RID: 34410
		[UIControl("Explode/Progress/Name", null, 0)]
		private Text m_explodeRandomName;

		// Token: 0x0400866B RID: 34411
		[UIControl("Result/Desc", null, 0)]
		private Text m_labBuyResult;

		// Token: 0x0400866C RID: 34412
		[UIObject("Result/ItemGroup/10")]
		private GameObject m_objItem_x10;

		// Token: 0x0400866D RID: 34413
		[UIObject("Result/ItemGroup/10/Final")]
		private GameObject m_objFinalItem_x10;

		// Token: 0x0400866E RID: 34414
		[UIObject("Result/ItemGroup/10/Effect")]
		private GameObject m_objEffectItem_x10;

		// Token: 0x0400866F RID: 34415
		[UIObject("Result/ItemGroup/1")]
		private GameObject m_objItem_x1;

		// Token: 0x04008670 RID: 34416
		[UIObject("Result/ItemGroup/1/Final")]
		private GameObject m_objFinalItem_x1;

		// Token: 0x04008671 RID: 34417
		[UIObject("Result/ItemGroup/1/Effect")]
		private GameObject m_objEffectItem_x1;

		// Token: 0x04008672 RID: 34418
		[UIObject("Result/Score")]
		private GameObject m_objScore;

		// Token: 0x04008673 RID: 34419
		[UIControl("Result/Score/Desc", null, 0)]
		private Text m_labScoreDesc;

		// Token: 0x04008674 RID: 34420
		[UIControl("Result/Score/Rate", null, 0)]
		private Text m_labScoreRate;

		// Token: 0x04008675 RID: 34421
		[UIObject("Result/Buy")]
		private GameObject m_objBuyRoot;

		// Token: 0x04008676 RID: 34422
		[UIObject("Result/Mask")]
		private GameObject m_objMask;

		// Token: 0x04008677 RID: 34423
		[UIObject("Result/CustomOpen")]
		private GameObject m_objCustomOpen;

		// Token: 0x04008678 RID: 34424
		[UIControl("Result/CustomOpen/Desc", null, 0)]
		private Text m_labCustomOpenDesc;

		// Token: 0x04008679 RID: 34425
		[UIControl("Result/CustomOpen/Open", null, 0)]
		private Button m_btnCustomOpen;

		// Token: 0x0400867A RID: 34426
		private List<ShowGuildDungeonChestItemsFrame.ItemInfo> m_multiItemInfos = new List<ShowGuildDungeonChestItemsFrame.ItemInfo>();

		// Token: 0x0400867B RID: 34427
		private List<ShowGuildDungeonChestItemsFrame.ItemInfo> m_singleItemInfo = new List<ShowGuildDungeonChestItemsFrame.ItemInfo>();

		// Token: 0x0400867C RID: 34428
		private Coroutine m_coroutine;

		// Token: 0x0400867D RID: 34429
		private GameObject mRewardItem;

		// Token: 0x0400867E RID: 34430
		private Text mText;

		// Token: 0x0400867F RID: 34431
		private Button btnExplodeBack;

		// Token: 0x04008680 RID: 34432
		private Text txtSkip;

		// Token: 0x04008681 RID: 34433
		private GameObject goGongxihuode;

		// Token: 0x04008682 RID: 34434
		private GameObject goBg1;

		// Token: 0x04008683 RID: 34435
		private GameObject goBg3;

		// Token: 0x04008684 RID: 34436
		private GameObject goGongxihuode_1;

		// Token: 0x04008685 RID: 34437
		private GameObject goBg1_1;

		// Token: 0x04008686 RID: 34438
		private GameObject goBg3_1;

		// Token: 0x04008687 RID: 34439
		public static bool bSkipExplode;

		// Token: 0x0200166B RID: 5739
		private class ItemInfo
		{
			// Token: 0x0400868A RID: 34442
			public JarBonus bonus;

			// Token: 0x0400868B RID: 34443
			public Text labName;

			// Token: 0x0400868C RID: 34444
			public ComItem comItem;

			// Token: 0x0400868D RID: 34445
			public ComCardEffect comCardEffect;

			// Token: 0x0400868E RID: 34446
			public RectTransform tranRoot;

			// Token: 0x0400868F RID: 34447
			public Animator animator;

			// Token: 0x04008690 RID: 34448
			public ComItem comItemEffect;

			// Token: 0x04008691 RID: 34449
			public Text labNameEffect;

			// Token: 0x04008692 RID: 34450
			public Button btnBack;

			// Token: 0x04008693 RID: 34451
			public Image imgBack;

			// Token: 0x04008694 RID: 34452
			public Transform tranParBack;

			// Token: 0x04008695 RID: 34453
			public Transform tranParFront;

			// Token: 0x04008696 RID: 34454
			public Transform tranParTurnover;
		}
	}
}
