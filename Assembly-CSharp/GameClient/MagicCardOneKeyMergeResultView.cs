using System;
using System.Collections.Generic;
using Protocol;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001745 RID: 5957
	public class MagicCardOneKeyMergeResultView : MonoBehaviour
	{
		// Token: 0x0600E9EF RID: 59887 RVA: 0x003DF443 File Offset: 0x003DD843
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600E9F0 RID: 59888 RVA: 0x003DF44B File Offset: 0x003DD84B
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600E9F1 RID: 59889 RVA: 0x003DF45C File Offset: 0x003DD85C
		private void BindEvents()
		{
			if (this.okButton != null)
			{
				this.okButton.onClick.RemoveAllListeners();
				this.okButton.onClick.AddListener(new UnityAction(this.OkButtonClick));
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OkButtonClick));
			}
			if (this.magicCardItemList != null)
			{
				this.magicCardItemList.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.magicCardItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnMagicCardItemVisible));
			}
		}

		// Token: 0x0600E9F2 RID: 59890 RVA: 0x003DF528 File Offset: 0x003DD928
		private void UnBindEvents()
		{
			if (this.okButton != null)
			{
				this.okButton.onClick.RemoveAllListeners();
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.magicCardItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.magicCardItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnMagicCardItemVisible));
			}
		}

		// Token: 0x0600E9F3 RID: 59891 RVA: 0x003DF5AF File Offset: 0x003DD9AF
		private void ClearData()
		{
			this._oneKeyRes = null;
			this._itemRewardDataList.Clear();
		}

		// Token: 0x0600E9F4 RID: 59892 RVA: 0x003DF5C3 File Offset: 0x003DD9C3
		public void InitData()
		{
			this._oneKeyRes = DataManager<MagicCardMergeDataManager>.GetInstance().OneKeyMergeRes;
			if (this._oneKeyRes == null)
			{
				Logger.LogErrorFormat("MagicCardOneKeyMergeResultView OneKeyMergeRes is null", new object[0]);
				return;
			}
			this.InitOneKeyMergeResultData();
			this.InitView();
		}

		// Token: 0x0600E9F5 RID: 59893 RVA: 0x003DF600 File Offset: 0x003DDA00
		private void InitOneKeyMergeResultData()
		{
			for (int i = 0; i < this._oneKeyRes.items.Length; i++)
			{
				if (this._oneKeyRes.items[i] != null)
				{
					this._itemRewardDataList.Add(this._oneKeyRes.items[i]);
				}
			}
			MagicCardMergeUtility.SortMagicCardMergeResultData(this._itemRewardDataList);
		}

		// Token: 0x0600E9F6 RID: 59894 RVA: 0x003DF660 File Offset: 0x003DDA60
		private void InitView()
		{
			this.InitCommonView();
			this.InitRewardItemList();
			this.InitResultText();
		}

		// Token: 0x0600E9F7 RID: 59895 RVA: 0x003DF674 File Offset: 0x003DDA74
		private void InitCommonView()
		{
			if (this.title != null)
			{
				this.title.text = TR.Value("magic_card_merge_result_title");
			}
		}

		// Token: 0x0600E9F8 RID: 59896 RVA: 0x003DF69C File Offset: 0x003DDA9C
		private void InitRewardItemList()
		{
			int count = this._itemRewardDataList.Count;
			if (this.magicCardItemList != null)
			{
				this.magicCardItemList.SetElementAmount(count);
			}
		}

		// Token: 0x0600E9F9 RID: 59897 RVA: 0x003DF6D4 File Offset: 0x003DDAD4
		private void InitResultText()
		{
			if (this.resultText == null)
			{
				return;
			}
			MagicCardCompOneKeyEndReason endReason = (MagicCardCompOneKeyEndReason)this._oneKeyRes.endReason;
			int compTimes = (int)this._oneKeyRes.compTimes;
			int consumeBindGolds = (int)this._oneKeyRes.consumeBindGolds;
			int comsumeGolds = (int)this._oneKeyRes.comsumeGolds;
			if (endReason == MagicCardCompOneKeyEndReason.MCCER_ITEMPACK_FULL)
			{
				string text = TR.Value("magic_card_merge_result_content_package_full_without_gold", compTimes, consumeBindGolds);
				if (DataManager<MagicCardMergeDataManager>.GetInstance().IsMagicCardOneKeyMergeUserGold)
				{
					text = TR.Value("magic_card_merge_result_content_package_full_with_gold", compTimes, consumeBindGolds, comsumeGolds);
				}
				this.resultText.text = text;
			}
			else
			{
				string text2 = TR.Value("magic_card_merge_result_content_without_gold", compTimes, consumeBindGolds);
				if (DataManager<MagicCardMergeDataManager>.GetInstance().IsMagicCardOneKeyMergeUserGold)
				{
					text2 = TR.Value("magic_card_merge_result_content_with_gold", compTimes, consumeBindGolds, comsumeGolds);
				}
				this.resultText.text = text2;
			}
		}

		// Token: 0x0600E9FA RID: 59898 RVA: 0x003DF7D4 File Offset: 0x003DDBD4
		private void OnMagicCardItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.magicCardItemList == null)
			{
				return;
			}
			if (this._itemRewardDataList == null)
			{
				return;
			}
			if (this._itemRewardDataList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._itemRewardDataList.Count)
			{
				return;
			}
			ItemReward itemReward = this._itemRewardDataList[item.m_index];
			MagicCardMergeItem component = item.GetComponent<MagicCardMergeItem>();
			if (itemReward != null && component != null)
			{
				component.InitItem(itemReward);
			}
		}

		// Token: 0x0600E9FB RID: 59899 RVA: 0x003DF873 File Offset: 0x003DDC73
		private void OkButtonClick()
		{
			this.OnCloseFrame();
		}

		// Token: 0x0600E9FC RID: 59900 RVA: 0x003DF87B File Offset: 0x003DDC7B
		private void OnCloseFrame()
		{
			DataManager<MagicCardMergeDataManager>.GetInstance().ResetOneKeyMergeRes();
			MagicCardMergeUtility.OnCloseMagicCardOneKeyMergeResultFrame();
		}

		// Token: 0x04008DDE RID: 36318
		private SceneMagicCardCompOneKeyRes _oneKeyRes;

		// Token: 0x04008DDF RID: 36319
		private List<ItemReward> _itemRewardDataList = new List<ItemReward>();

		// Token: 0x04008DE0 RID: 36320
		[Space(10f)]
		[Header("Content")]
		[SerializeField]
		private Text title;

		// Token: 0x04008DE1 RID: 36321
		[SerializeField]
		private ComUIListScriptEx magicCardItemList;

		// Token: 0x04008DE2 RID: 36322
		[Space(10f)]
		[Header("Text")]
		[SerializeField]
		private Text resultText;

		// Token: 0x04008DE3 RID: 36323
		[SerializeField]
		private Button okButton;

		// Token: 0x04008DE4 RID: 36324
		[SerializeField]
		private Button closeButton;
	}
}
