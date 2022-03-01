using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C1D RID: 7197
	public class TeamRewardPreviewFrame : ClientFrame
	{
		// Token: 0x06011A6E RID: 72302 RVA: 0x0052A7DC File Offset: 0x00528BDC
		protected override void _bindExUI()
		{
			this.mComUIList = this.mBind.GetCom<ComUIListScript>("ComUIList");
		}

		// Token: 0x06011A6F RID: 72303 RVA: 0x0052A7F4 File Offset: 0x00528BF4
		protected override void _unbindExUI()
		{
			this.mComUIList = null;
		}

		// Token: 0x06011A70 RID: 72304 RVA: 0x0052A7FD File Offset: 0x00528BFD
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Team/TeamRewardPreviewFrame";
		}

		// Token: 0x06011A71 RID: 72305 RVA: 0x0052A804 File Offset: 0x00528C04
		protected override void _OnOpenFrame()
		{
			this.InitUIList();
			this.InitData();
			this.OnSetElmentCount();
		}

		// Token: 0x06011A72 RID: 72306 RVA: 0x0052A818 File Offset: 0x00528C18
		protected override void _OnCloseFrame()
		{
			this.UnInitUIList();
			this.items.Clear();
		}

		// Token: 0x06011A73 RID: 72307 RVA: 0x0052A82C File Offset: 0x00528C2C
		private void InitUIList()
		{
			if (this.mComUIList != null)
			{
				this.mComUIList.Initialize();
				ComUIListScript comUIListScript = this.mComUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mComUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x06011A74 RID: 72308 RVA: 0x0052A8A4 File Offset: 0x00528CA4
		private void UnInitUIList()
		{
			if (this.mComUIList != null)
			{
				ComUIListScript comUIListScript = this.mComUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mComUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x06011A75 RID: 72309 RVA: 0x0052A910 File Offset: 0x00528D10
		private ComCommonBind OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<ComCommonBind>();
		}

		// Token: 0x06011A76 RID: 72310 RVA: 0x0052A918 File Offset: 0x00528D18
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			ComCommonBind comCommonBind = item.gameObjectBindScript as ComCommonBind;
			if (comCommonBind != null && item.m_index >= 0 && item.m_index < this.items.Count)
			{
				int index = item.m_index;
				this.UpdateItemInfo(comCommonBind, index);
			}
		}

		// Token: 0x06011A77 RID: 72311 RVA: 0x0052A970 File Offset: 0x00528D70
		private void UpdateItemInfo(ComCommonBind comBind, int index)
		{
			if (comBind == null)
			{
				return;
			}
			if (index < 0 || index >= this.items.Count)
			{
				return;
			}
			ItemData itemData = this.items[index];
			if (itemData == null)
			{
				return;
			}
			Image com = comBind.GetCom<Image>("backgroud");
			Image com2 = comBind.GetCom<Image>("Icon");
			Text com3 = comBind.GetCom<Text>("Count");
			Text com4 = comBind.GetCom<Text>("name");
			Button com5 = comBind.GetCom<Button>("Iconbtn");
			if (com != null)
			{
				ETCImageLoader.LoadSprite(ref com, itemData.GetQualityInfo().Background, true);
			}
			if (com2 != null)
			{
				ETCImageLoader.LoadSprite(ref com2, itemData.Icon, true);
			}
			if (com3 != null)
			{
				com3.text = itemData.Count.ToString();
			}
			if (com4 != null)
			{
				com4.text = itemData.GetColorName(string.Empty, false);
			}
			if (com5 != null)
			{
				com5.onClick.RemoveAllListeners();
				com5.onClick.AddListener(delegate()
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
				});
			}
		}

		// Token: 0x06011A78 RID: 72312 RVA: 0x0052AAC8 File Offset: 0x00528EC8
		private void InitData()
		{
			if (this.items == null)
			{
				this.items = new List<ItemData>();
			}
			this.items.Clear();
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<TeamRewardTable>())
			{
				TeamRewardTable teamRewardTable = keyValuePair.Value as TeamRewardTable;
				if (teamRewardTable != null)
				{
					if (teamRewardTable.Type != 1)
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable(teamRewardTable.Reward, 100, 0);
						if (itemData != null)
						{
							itemData.Count = teamRewardTable.Num;
							this.items.Add(itemData);
						}
					}
				}
			}
			this.items.Sort(delegate(ItemData x, ItemData y)
			{
				if (x.Quality != y.Quality)
				{
					return y.Quality - x.Quality;
				}
				return x.TableID - y.TableID;
			});
		}

		// Token: 0x06011A79 RID: 72313 RVA: 0x0052ABA2 File Offset: 0x00528FA2
		private void OnSetElmentCount()
		{
			if (this.mComUIList != null)
			{
				this.mComUIList.SetElementAmount(this.items.Count);
			}
		}

		// Token: 0x0400B7ED RID: 47085
		private ComUIListScript mComUIList;

		// Token: 0x0400B7EE RID: 47086
		private List<ItemData> items = new List<ItemData>();
	}
}
