using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020016EE RID: 5870
	public class MagicBoxFrame : ClientFrame
	{
		// Token: 0x0600E5F2 RID: 58866 RVA: 0x003BF1CB File Offset: 0x003BD5CB
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Jar/MagicboxFrame";
		}

		// Token: 0x0600E5F3 RID: 58867 RVA: 0x003BF1D2 File Offset: 0x003BD5D2
		protected override void _OnOpenFrame()
		{
			this.ShowItem();
		}

		// Token: 0x0600E5F4 RID: 58868 RVA: 0x003BF1DA File Offset: 0x003BD5DA
		protected override void _OnCloseFrame()
		{
			this.m_kData = null;
			DataManager<MagicBoxDataManager>.GetInstance().Clear();
		}

		// Token: 0x0600E5F5 RID: 58869 RVA: 0x003BF1F0 File Offset: 0x003BD5F0
		private void ShowItem()
		{
			this.m_kData = (this.userData as MagicBoxFrame.MagicBoxResultFrameData);
			int num = 0;
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(800002001, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			JarBonus tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<JarBonus>(tableItem.ID, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				int num2 = (DataManager<CountDataManager>.GetInstance().GetCount(tableItem2.CounterKey) + tableItem2.ComboBuyNum) / tableItem2.ComboBuyNum;
				int num3 = Mathf.CeilToInt((float)num2 / (float)tableItem2.ExBonusNum_1 + 0.1f);
				if (num3 < 1)
				{
					num = tableItem2.ExBonusNum_1 - num2;
				}
				else
				{
					num = num3 * tableItem2.ExBonusNum_1 - num2;
				}
			}
			if (this.m_kData.itemRewards.Count > 0 && this.m_kData.ItemDoubleRewards.Count > 0)
			{
				this.useAll_8Rect.gameObject.CustomActive(true);
				this.rewardItemRect.gameObject.CustomActive(false);
				this.doubleRewardItemRect.gameObject.CustomActive(false);
				this._ShowOpenMagicBoxItem(this.m_kData, this.m_comGetItemList);
				this._ShowOpenMagicBoxDoubleItem(this.m_kData, this.m_comGetDoubleItemList);
				this.useAllText.text = "再开启" + num + "个神秘匣子即可获得1次双倍奖励";
			}
			else if (this.m_kData.itemRewards.Count > 0)
			{
				this.rewardItemRect.gameObject.CustomActive(true);
				this.useAll_8Rect.gameObject.CustomActive(false);
				this.doubleRewardItemRect.gameObject.CustomActive(false);
				this._ShowOpenMagicBoxItem(this.m_kData, this.m_comGetItemListReward);
				this.rewardItemText.text = "再开启" + num + "个神秘匣子即可获得1次双倍奖励";
			}
			else if (this.m_kData.ItemDoubleRewards.Count > 0)
			{
				this.doubleRewardItemRect.gameObject.CustomActive(true);
				this.useAll_8Rect.gameObject.CustomActive(false);
				this.rewardItemRect.gameObject.CustomActive(false);
				this._ShowOpenMagicBoxDoubleItem(this.m_kData, this.m_comGetDoubleListDoubleReward);
				this.doubleRewardText.text = "再开启" + num + "个神秘匣子即可获得1次双倍奖励";
			}
		}

		// Token: 0x0600E5F6 RID: 58870 RVA: 0x003BF450 File Offset: 0x003BD850
		private void _ShowOpenMagicBoxItem(MagicBoxFrame.MagicBoxResultFrameData data, ComUIListScript script)
		{
			if (data == null)
			{
				return;
			}
			for (int i = 0; i < data.itemRewards.Count; i++)
			{
				for (int j = i + 1; j < data.itemRewards.Count; j++)
				{
					if (data.itemRewards[i].Quality < data.itemRewards[j].Quality)
					{
						ItemData value = data.itemRewards[i];
						data.itemRewards[i] = data.itemRewards[j];
						data.itemRewards[j] = value;
					}
				}
			}
			script.Initialize();
			script.onBindItem = ((GameObject var) => this.CreateComItem(Utility.FindGameObject(var, "ItemParent", true)));
			script.onItemVisiable = delegate(ComUIListElementScript var)
			{
				if (data.itemRewards != null)
				{
					List<ItemData> itemRewards = data.itemRewards;
					if (var.m_index >= 0 && var.m_index < itemRewards.Count)
					{
						ComItem comItem = var.gameObjectBindScript as ComItem;
						comItem.Setup(itemRewards[var.m_index], delegate(GameObject var1, ItemData var2)
						{
							DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
						});
						Utility.GetComponetInChild<Text>(var.gameObject, "Name").text = string.Concat(new object[]
						{
							itemRewards[var.m_index].GetColorName(string.Empty, false),
							" ",
							itemRewards[var.m_index].Count,
							"个"
						});
					}
				}
			};
			if (data.itemRewards != null)
			{
				script.SetElementAmount(data.itemRewards.Count);
			}
			else
			{
				script.SetElementAmount(0);
			}
		}

		// Token: 0x0600E5F7 RID: 58871 RVA: 0x003BF598 File Offset: 0x003BD998
		private void _ShowOpenMagicBoxDoubleItem(MagicBoxFrame.MagicBoxResultFrameData data, ComUIListScript script)
		{
			if (data == null)
			{
				return;
			}
			for (int i = 0; i < data.ItemDoubleRewards.Count; i++)
			{
				for (int j = i + 1; j < data.ItemDoubleRewards.Count; j++)
				{
					if (data.ItemDoubleRewards[i].Quality < data.ItemDoubleRewards[j].Quality)
					{
						ItemData value = data.ItemDoubleRewards[i];
						data.ItemDoubleRewards[i] = data.ItemDoubleRewards[j];
						data.ItemDoubleRewards[j] = value;
					}
				}
			}
			script.Initialize();
			script.onBindItem = ((GameObject var) => this.CreateComItem(Utility.FindGameObject(var, "ItemParent", true)));
			script.onItemVisiable = delegate(ComUIListElementScript var)
			{
				if (data.ItemDoubleRewards != null)
				{
					List<ItemData> itemDoubleRewards = data.ItemDoubleRewards;
					if (var.m_index >= 0 && var.m_index < itemDoubleRewards.Count)
					{
						ComItem comItem = var.gameObjectBindScript as ComItem;
						comItem.Setup(itemDoubleRewards[var.m_index], delegate(GameObject var1, ItemData var2)
						{
							DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
						});
						Utility.GetComponetInChild<Text>(var.gameObject, "Name").text = string.Concat(new object[]
						{
							itemDoubleRewards[var.m_index].GetColorName(string.Empty, false),
							" ",
							itemDoubleRewards[var.m_index].Count,
							"个"
						});
					}
				}
			};
			script.SetElementAmount(data.ItemDoubleRewards.Count);
		}

		// Token: 0x0600E5F8 RID: 58872 RVA: 0x003BF6C2 File Offset: 0x003BDAC2
		[UIEventHandle("UseAll_8/Title/Close")]
		private void OnCloseClick()
		{
			this.frameMgr.CloseFrame<MagicBoxFrame>(this, false);
		}

		// Token: 0x0600E5F9 RID: 58873 RVA: 0x003BF6D1 File Offset: 0x003BDAD1
		[UIEventHandle("RewardItem/close")]
		private void RewardClose()
		{
			this.OnCloseClick();
		}

		// Token: 0x0600E5FA RID: 58874 RVA: 0x003BF6D9 File Offset: 0x003BDAD9
		[UIEventHandle("DoubleRewardItem/close")]
		private void DoubleRewardClose()
		{
			this.OnCloseClick();
		}

		// Token: 0x04008B40 RID: 35648
		private MagicBoxFrame.MagicBoxResultFrameData m_kData;

		// Token: 0x04008B41 RID: 35649
		[UIControl("UseAll_8/LeftItemList/Scroll View", null, 0)]
		private ComUIListScript m_comGetItemList;

		// Token: 0x04008B42 RID: 35650
		[UIControl("UseAll_8/RightItemList/Scroll View", null, 0)]
		private ComUIListScript m_comGetDoubleItemList;

		// Token: 0x04008B43 RID: 35651
		[UIControl("RewardItem/Scroll View", null, 0)]
		private ComUIListScript m_comGetItemListReward;

		// Token: 0x04008B44 RID: 35652
		[UIControl("DoubleRewardItem/Scroll View", null, 0)]
		private ComUIListScript m_comGetDoubleListDoubleReward;

		// Token: 0x04008B45 RID: 35653
		[UIControl("UseAll_8", null, 0)]
		private RectTransform useAll_8Rect;

		// Token: 0x04008B46 RID: 35654
		[UIControl("RewardItem", null, 0)]
		private RectTransform rewardItemRect;

		// Token: 0x04008B47 RID: 35655
		[UIControl("DoubleRewardItem", null, 0)]
		private RectTransform doubleRewardItemRect;

		// Token: 0x04008B48 RID: 35656
		[UIControl("UseAll_8/Text", null, 0)]
		private Text useAllText;

		// Token: 0x04008B49 RID: 35657
		[UIControl("RewardItem/Text", null, 0)]
		private Text rewardItemText;

		// Token: 0x04008B4A RID: 35658
		[UIControl("DoubleRewardItem/Text", null, 0)]
		private Text doubleRewardText;

		// Token: 0x020016EF RID: 5871
		public class MagicBoxResultFrameData
		{
			// Token: 0x04008B4B RID: 35659
			public List<ItemData> itemRewards;

			// Token: 0x04008B4C RID: 35660
			public List<ItemData> ItemDoubleRewards;
		}
	}
}
