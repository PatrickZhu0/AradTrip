using System;
using System.Collections.Generic;
using DG.Tweening;
using GamePool;
using LimitTimeGift;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BB6 RID: 7094
	internal class StrengthenResultFrame : ClientFrame
	{
		// Token: 0x060115C4 RID: 71108 RVA: 0x005075D6 File Offset: 0x005059D6
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/StrengthenResult";
		}

		// Token: 0x060115C5 RID: 71109 RVA: 0x005075DD File Offset: 0x005059DD
		private void _OnClickStopStrengthen()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.IntterruptContineStrengthen, null, null, null, null);
			this.frameMgr.CloseFrame<StrengthenResultFrame>(this, false);
		}

		// Token: 0x060115C6 RID: 71110 RVA: 0x005075FF File Offset: 0x005059FF
		private void _OnClickContinueStrengthen()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.StrengthenContinue, null, null, null, null);
			this.frameMgr.CloseFrame<StrengthenResultFrame>(this, false);
		}

		// Token: 0x060115C7 RID: 71111 RVA: 0x00507624 File Offset: 0x00505A24
		private void _InitAnimations()
		{
			StrengthenResultUserData strengthenResultUserData = this.userData as StrengthenResultUserData;
			GameObject gameObject = this.mBind.GetGameObject("StrengthenAnimation");
			gameObject.CustomActive(strengthenResultUserData.NeedBeforeAnimation);
			if (!strengthenResultUserData.NeedBeforeAnimation)
			{
				List<DOTweenAnimation> list = ListPool<DOTweenAnimation>.Get();
				this.frame.GetComponentsInChildren<DOTweenAnimation>(true, list);
				for (int i = 0; i < list.Count; i++)
				{
					list[i].delay -= 2.5f;
				}
				ListPool<DOTweenAnimation>.Release(list);
				List<GeUIEffectParticle> list2 = ListPool<GeUIEffectParticle>.Get();
				this.frame.GetComponentsInChildren<GeUIEffectParticle>(true, list2);
				for (int j = 0; j < list2.Count; j++)
				{
					GeUIParticleEmitterBase geUIParticleEmitterBase = list2[j].SafeGetEmitter();
					geUIParticleEmitterBase.delayEmit -= 2.5f;
				}
				ListPool<GeUIEffectParticle>.Release(list2);
			}
		}

		// Token: 0x060115C8 RID: 71112 RVA: 0x0050770C File Offset: 0x00505B0C
		protected override void _OnOpenFrame()
		{
			StrengthenResultUserData strengthenResultUserData = this.userData as StrengthenResultUserData;
			if (strengthenResultUserData == null)
			{
				Logger.LogError("StrengthenResultFrame resultData");
				return;
			}
			this._InitAnimations();
			string text = "ok_10down";
			if (strengthenResultUserData.EquipData != null && strengthenResultUserData.EquipData.StrengthenLevel > 10)
			{
				text = "ok_10up";
			}
			this.m_description = Utility.FindComponent<Text>(this.frame, text + "/common_black/itemname", true);
			this.m_descIgnore = Utility.FindComponent<Text>(this.frame, text + "/common_black/desc", true);
			this.m_textSuccessTitle = Utility.FindComponent<Text>(this.frame, text + "/common_black/TitleBg/Title", true);
			this.m_kBtnStop0 = Utility.FindComponent<Button>(this.frame, text + "/BtnStop", true);
			this.m_kBtnStop0.CustomActive(false);
			this.m_kBtnStop1 = Utility.FindComponent<Button>(this.frame, "failed/BtnStop", true);
			this.m_kBtnStop1.CustomActive(false);
			this.m_kBtnContinue0 = Utility.FindComponent<Button>(this.frame, text + "/BtnContinue", true);
			this.m_kBtnContinue0.CustomActive(false);
			this.m_kBtnContinue1 = Utility.FindComponent<Button>(this.frame, "failed/BtnContinue", true);
			this.m_kBtnContinue1.CustomActive(false);
			this.m_kBtnStop0.onClick.RemoveAllListeners();
			this.m_kBtnStop0.onClick.AddListener(new UnityAction(this._OnClickStopStrengthen));
			this.m_kBtnStop1.onClick.RemoveAllListeners();
			this.m_kBtnStop1.onClick.AddListener(new UnityAction(this._OnClickStopStrengthen));
			this.m_kBtnContinue0.onClick.RemoveAllListeners();
			this.m_kBtnContinue0.onClick.AddListener(new UnityAction(this._OnClickContinueStrengthen));
			this.m_kBtnContinue1.onClick.RemoveAllListeners();
			this.m_kBtnContinue1.onClick.AddListener(new UnityAction(this._OnClickContinueStrengthen));
			GameObject gameObject = null;
			GameObject gameObject2 = Utility.FindChild(this.frame, text);
			gameObject2.CustomActive(strengthenResultUserData.uiCode == 0U);
			if (gameObject2.activeSelf)
			{
				gameObject = gameObject2;
			}
			GameObject gameObject3 = Utility.FindChild(this.frame, "failed_broken");
			gameObject3.CustomActive(strengthenResultUserData.uiCode == 1000019U);
			if (gameObject3.activeSelf)
			{
				gameObject = gameObject3;
			}
			GameObject gameObject4 = Utility.FindChild(this.frame, "failed_zero");
			gameObject4.CustomActive(strengthenResultUserData.uiCode == 1000018U);
			if (gameObject4.activeSelf)
			{
				gameObject = gameObject4;
			}
			GameObject gameObject5 = Utility.FindChild(this.frame, "failed");
			gameObject5.CustomActive(strengthenResultUserData.uiCode == 1000016U || strengthenResultUserData.uiCode == 1000017U || strengthenResultUserData.uiCode == 1000048U);
			if (gameObject5.activeSelf)
			{
				gameObject = gameObject5;
			}
			if (gameObject == gameObject2)
			{
				Text text2 = Utility.FindComponent<Text>(gameObject2, "common_black/hint", true);
				if (text2 != null && strengthenResultUserData.EquipData != null)
				{
					if (strengthenResultUserData.EquipData.EquipType == EEquipType.ET_COMMON)
					{
						text2.text = "装备强化至+" + strengthenResultUserData.EquipData.StrengthenLevel;
					}
					else if (strengthenResultUserData.EquipData.EquipType == EEquipType.ET_REDMARK)
					{
						text2.text = "装备激化至+" + strengthenResultUserData.EquipData.StrengthenLevel;
					}
				}
			}
			else if (gameObject == gameObject5)
			{
				Text text3 = Utility.FindComponent<Text>(gameObject5, "common_black/hint", true);
				Text text4 = Utility.FindComponent<Text>(gameObject5, "TitleBg/Title", true);
				if (text3 != null && strengthenResultUserData.EquipData != null)
				{
					text3.text = "装备降级至+" + strengthenResultUserData.EquipData.StrengthenLevel;
					text3.enabled = (strengthenResultUserData.uiCode != 1000048U);
				}
				if (text4 != null && strengthenResultUserData.EquipData != null && strengthenResultUserData.EquipData.EquipType == EEquipType.ET_REDMARK)
				{
					text4.text = TR.Value("growth_faild");
				}
			}
			if (strengthenResultUserData.uiCode == 0U)
			{
				MonoSingleton<AudioManager>.instance.PlaySound(12);
			}
			else
			{
				MonoSingleton<AudioManager>.instance.PlaySound(11);
			}
			if (strengthenResultUserData.uiCode == 0U)
			{
				ComItem comItem = base.CreateComItem(Utility.FindChild(this.frame, text + "/common_black/ItemParent"));
				this.m_arrComItems.Add(comItem);
				comItem.SetActive(true);
				comItem.Setup(strengthenResultUserData.EquipData, null);
				if (strengthenResultUserData.EquipData.EquipType == EEquipType.ET_REDMARK && this.m_textSuccessTitle != null)
				{
					this.m_textSuccessTitle.text = TR.Value("growth_success");
				}
				if (strengthenResultUserData.bContinue)
				{
					this.m_kBtnStop0.CustomActive(true);
					this.m_kBtnContinue0.CustomActive(false);
				}
				else
				{
					this.m_kBtnStop0.CustomActive(false);
					this.m_kBtnContinue0.CustomActive(true);
				}
				this.m_kBtnStop0.CustomActive(false);
				this.m_kBtnContinue0.CustomActive(false);
				string text5 = string.Format("+{0} {1}", strengthenResultUserData.EquipData.StrengthenLevel, strengthenResultUserData.EquipData.Name);
				this.m_description.text = text5;
				List<string> strengthenDescs = strengthenResultUserData.EquipData.GetStrengthenDescs();
				string text6 = string.Empty;
				for (int i = 0; i < strengthenDescs.Count; i++)
				{
					if (!string.IsNullOrEmpty(text6))
					{
						text6 += "\n";
					}
					text6 += strengthenDescs[i];
				}
				this.m_descIgnore.text = text6;
			}
			else if (strengthenResultUserData.uiCode == 1000018U)
			{
				GameObject gameObject6 = Utility.FindChild(gameObject4, "common_black/Items");
				GameObject gameObject7 = Utility.FindChild(gameObject6, "Item");
				gameObject7.CustomActive(false);
				if (strengthenResultUserData.EquipData.EquipType == EEquipType.ET_COMMON)
				{
					if (this.m_textZero != null)
					{
						this.m_textZero.text = TR.Value("strenghten_result_failed_zero");
					}
				}
				else if (strengthenResultUserData.EquipData.EquipType == EEquipType.ET_REDMARK)
				{
					if (this.m_textZero != null)
					{
						this.m_textZero.text = TR.Value("growth_result_failed_zero");
					}
					if (this.m_textZeroTitle != null)
					{
						this.m_textZeroTitle.text = TR.Value("growth_faild");
					}
				}
				if (this.comItemZero == null)
				{
					this.comItemZero = base.CreateComItem(this.m_goZeroItem);
				}
				this.comItemZero.Setup(strengthenResultUserData.EquipData, null);
				int num = 0;
				while (strengthenResultUserData.BrokenItems != null && num < strengthenResultUserData.BrokenItems.Count)
				{
					GameObject gameObject8 = Object.Instantiate<GameObject>(gameObject7);
					Utility.AttachTo(gameObject8, gameObject6, false);
					gameObject8.CustomActive(true);
					ComItem comItem2 = base.CreateComItem(Utility.FindChild(gameObject8, "ItemParent"));
					this.m_arrComItems.Add(comItem2);
					comItem2.Setup(strengthenResultUserData.BrokenItems[num], null);
					Text text7 = Utility.FindComponent<Text>(gameObject8, "itemname", true);
					ItemData itemData = strengthenResultUserData.BrokenItems[num];
					string text8 = string.Empty;
					if (itemData.Type == ItemTable.eType.INCOME)
					{
						text8 = string.Format("{0}", itemData.Name);
					}
					else
					{
						text8 = string.Format("{0}", itemData.Name);
					}
					text7.text = text8;
					num++;
				}
			}
			else if (strengthenResultUserData.uiCode == 1000019U)
			{
				GameObject gameObject9 = Utility.FindChild(gameObject3, "Items");
				GameObject gameObject10 = Utility.FindChild(gameObject9, "Item");
				if (gameObject10 != null)
				{
					gameObject10.CustomActive(false);
				}
				if (strengthenResultUserData.EquipData.EquipType == EEquipType.ET_REDMARK && this.m_textBrokenTitle != null)
				{
					this.m_textBrokenTitle.text = TR.Value("growth_faild");
				}
				this.m_textBroken.text = TR.Value("strenghten_result_broken");
				int num2 = 0;
				while (strengthenResultUserData.BrokenItems != null && num2 < strengthenResultUserData.BrokenItems.Count)
				{
					GameObject gameObject11 = Object.Instantiate<GameObject>(gameObject10);
					Utility.AttachTo(gameObject11, gameObject9, false);
					gameObject11.CustomActive(true);
					ComItem comItem3 = base.CreateComItem(Utility.FindChild(gameObject11, "ItemParent"));
					this.m_arrComItems.Add(comItem3);
					comItem3.Setup(strengthenResultUserData.BrokenItems[num2], null);
					Text text9 = Utility.FindComponent<Text>(gameObject11, "itemname", true);
					ItemData itemData2 = strengthenResultUserData.BrokenItems[num2];
					string text10 = string.Empty;
					if (itemData2.Type == ItemTable.eType.INCOME)
					{
						text10 = string.Format("{0}", itemData2.Name);
					}
					else
					{
						text10 = string.Format("{0}", itemData2.Name);
					}
					text9.text = text10;
					num2++;
				}
			}
			else
			{
				if (strengthenResultUserData.bContinue)
				{
					this.m_kBtnStop1.CustomActive(true);
					this.m_kBtnContinue1.CustomActive(false);
				}
				else
				{
					this.m_kBtnStop1.CustomActive(false);
					this.m_kBtnContinue1.CustomActive(true);
				}
				this.m_kBtnStop1.CustomActive(false);
				this.m_kBtnContinue1.CustomActive(false);
				ComItem comItem4 = base.CreateComItem(Utility.FindChild(gameObject5, "common_black/ItemParent"));
				this.m_arrComItems.Add(comItem4);
				comItem4.Setup(strengthenResultUserData.EquipData, null);
				Text text11 = Utility.FindComponent<Text>(gameObject5, "common_black/itemname", true);
				string text12 = string.Format("+{0} {1}", strengthenResultUserData.EquipData.StrengthenLevel, strengthenResultUserData.EquipData.Name);
				text11.text = text12;
			}
		}

		// Token: 0x060115C9 RID: 71113 RVA: 0x00508110 File Offset: 0x00506510
		protected override void _OnCloseFrame()
		{
			Singleton<LimitTimeGiftFrameManager>.GetInstance().WaitToShowLimitTimeGiftFrame();
			if (this.comItemZero != null)
			{
				this.comItemZero.Setup(null, null);
				this.comItemZero = null;
			}
			this.m_arrComItems.Clear();
			this.m_kBtnStop0.onClick.RemoveAllListeners();
			this.m_kBtnStop0 = null;
			this.m_kBtnStop1.onClick.RemoveAllListeners();
			this.m_kBtnStop1 = null;
			this.m_kBtnContinue0.onClick.RemoveAllListeners();
			this.m_kBtnContinue0 = null;
			this.m_kBtnContinue1.onClick.RemoveAllListeners();
			this.m_kBtnContinue1 = null;
		}

		// Token: 0x060115CA RID: 71114 RVA: 0x005081B3 File Offset: 0x005065B3
		[UIEventHandle("ok_10down/close")]
		private void _OnClose()
		{
			this.frameMgr.CloseFrame<StrengthenResultFrame>(this, false);
		}

		// Token: 0x060115CB RID: 71115 RVA: 0x005081C2 File Offset: 0x005065C2
		[UIEventHandle("ok_10down/close_1")]
		private void _OnClose_1()
		{
			this.frameMgr.CloseFrame<StrengthenResultFrame>(this, false);
		}

		// Token: 0x060115CC RID: 71116 RVA: 0x005081D1 File Offset: 0x005065D1
		[UIEventHandle("ok_10down/close_2")]
		private void _OnClose_2()
		{
			this.frameMgr.CloseFrame<StrengthenResultFrame>(this, false);
		}

		// Token: 0x060115CD RID: 71117 RVA: 0x005081E0 File Offset: 0x005065E0
		[UIEventHandle("ok_10up/close")]
		private void _OnUpClose()
		{
			this.frameMgr.CloseFrame<StrengthenResultFrame>(this, false);
		}

		// Token: 0x060115CE RID: 71118 RVA: 0x005081EF File Offset: 0x005065EF
		[UIEventHandle("ok_10up/close_1")]
		private void _OnUpClose_1()
		{
			this.frameMgr.CloseFrame<StrengthenResultFrame>(this, false);
		}

		// Token: 0x060115CF RID: 71119 RVA: 0x005081FE File Offset: 0x005065FE
		[UIEventHandle("ok_10up/close_2")]
		private void _OnUpClose_2()
		{
			this.frameMgr.CloseFrame<StrengthenResultFrame>(this, false);
		}

		// Token: 0x060115D0 RID: 71120 RVA: 0x0050820D File Offset: 0x0050660D
		[UIEventHandle("failed_broken/close")]
		private void _OnClose2()
		{
			this.frameMgr.CloseFrame<StrengthenResultFrame>(this, false);
		}

		// Token: 0x060115D1 RID: 71121 RVA: 0x0050821C File Offset: 0x0050661C
		[UIEventHandle("failed_zero/close")]
		private void _OnClose4()
		{
			this.frameMgr.CloseFrame<StrengthenResultFrame>(this, false);
		}

		// Token: 0x060115D2 RID: 71122 RVA: 0x0050822B File Offset: 0x0050662B
		[UIEventHandle("failed/close")]
		private void _OnClose3()
		{
			this.frameMgr.CloseFrame<StrengthenResultFrame>(this, false);
		}

		// Token: 0x060115D3 RID: 71123 RVA: 0x0050823A File Offset: 0x0050663A
		[UIEventHandle("failed/close_1")]
		private void _OnClose3_1()
		{
			this.frameMgr.CloseFrame<StrengthenResultFrame>(this, false);
		}

		// Token: 0x060115D4 RID: 71124 RVA: 0x00508249 File Offset: 0x00506649
		[UIEventHandle("failed/close_2")]
		private void _OnClose3_2()
		{
			this.frameMgr.CloseFrame<StrengthenResultFrame>(this, false);
		}

		// Token: 0x0400B41E RID: 46110
		private List<ComItem> m_arrComItems = new List<ComItem>();

		// Token: 0x0400B41F RID: 46111
		private Text m_description;

		// Token: 0x0400B420 RID: 46112
		private Text m_descIgnore;

		// Token: 0x0400B421 RID: 46113
		private Text m_textSuccessTitle;

		// Token: 0x0400B422 RID: 46114
		[UIControl("failed_broken/Title", null, 0)]
		private Text m_textBroken;

		// Token: 0x0400B423 RID: 46115
		[UIControl("failed_zero/Title", null, 0)]
		private Text m_textZero;

		// Token: 0x0400B424 RID: 46116
		[UIControl("failed_broken/TitleBg/Title", null, 0)]
		private Text m_textBrokenTitle;

		// Token: 0x0400B425 RID: 46117
		[UIControl("failed_zero/TitleBg/Title", null, 0)]
		private Text m_textZeroTitle;

		// Token: 0x0400B426 RID: 46118
		private ComItem comItemZero;

		// Token: 0x0400B427 RID: 46119
		[UIObject("failed_zero/common_black/ItemParent")]
		private GameObject m_goZeroItem;

		// Token: 0x0400B428 RID: 46120
		private Button m_kBtnStop0;

		// Token: 0x0400B429 RID: 46121
		private Button m_kBtnStop1;

		// Token: 0x0400B42A RID: 46122
		private Button m_kBtnContinue0;

		// Token: 0x0400B42B RID: 46123
		private Button m_kBtnContinue1;
	}
}
