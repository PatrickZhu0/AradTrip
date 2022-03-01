using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001995 RID: 6549
	public class PkLadderAwardFrame : ClientFrame
	{
		// Token: 0x0600FEF6 RID: 65270 RVA: 0x00469275 File Offset: 0x00467675
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk/PkLadderAward";
		}

		// Token: 0x0600FEF7 RID: 65271 RVA: 0x0046927C File Offset: 0x0046767C
		protected override void _OnOpenFrame()
		{
			this.InitInterface();
			this.BindUIEvent();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.pkGuideEnd, null, null, null, null);
		}

		// Token: 0x0600FEF8 RID: 65272 RVA: 0x0046929D File Offset: 0x0046769D
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.pkGuideStart, null, null, null, null);
			this.ClearData();
			this.UnBindUIEvent();
		}

		// Token: 0x0600FEF9 RID: 65273 RVA: 0x004692BE File Offset: 0x004676BE
		private void ClearData()
		{
			this.ObjList.Clear();
			this.ShowTipItemData1.Clear();
			this.ShowTipItemData2.Clear();
		}

		// Token: 0x0600FEFA RID: 65274 RVA: 0x004692E1 File Offset: 0x004676E1
		protected void BindUIEvent()
		{
		}

		// Token: 0x0600FEFB RID: 65275 RVA: 0x004692E3 File Offset: 0x004676E3
		protected void UnBindUIEvent()
		{
		}

		// Token: 0x0600FEFC RID: 65276 RVA: 0x004692E5 File Offset: 0x004676E5
		[UIEventHandle("middle/title/btClose")]
		private void OnClose()
		{
			this.frameMgr.CloseFrame<PkLadderAwardFrame>(this, false);
		}

		// Token: 0x0600FEFD RID: 65277 RVA: 0x004692F4 File Offset: 0x004676F4
		private void OnShowItemTip1(int iIndex)
		{
			if (iIndex >= this.ShowTipItemData1.Count)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(this.ShowTipItemData1[iIndex], null, 4, true, false, true);
		}

		// Token: 0x0600FEFE RID: 65278 RVA: 0x00469323 File Offset: 0x00467723
		private void OnShowItemTip2(int iIndex)
		{
			if (iIndex >= this.ShowTipItemData2.Count)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(this.ShowTipItemData2[iIndex], null, 4, true, false, true);
		}

		// Token: 0x0600FEFF RID: 65279 RVA: 0x00469354 File Offset: 0x00467754
		private void InitInterface()
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<SeasonDailyTable>();
			Dictionary<int, object>.Enumerator enumerator = table.GetEnumerator();
			int num = 0;
			while (enumerator.MoveNext())
			{
				KeyValuePair<int, object> keyValuePair = enumerator.Current;
				SeasonDailyTable seasonDailyTable = keyValuePair.Value as SeasonDailyTable;
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.elePath, true, 0U);
				if (!(gameObject == null))
				{
					Utility.AttachTo(gameObject, this.AwardRoot, false);
					this.ObjList.Add(gameObject);
					Text[] componentsInChildren = gameObject.GetComponentsInChildren<Text>();
					for (int i = 0; i < componentsInChildren.Length; i++)
					{
						if (componentsInChildren[i].name == "score" && seasonDailyTable.MatchScore.Count > 1)
						{
							componentsInChildren[i].text = string.Format("{0}+", seasonDailyTable.MatchScore[0]);
						}
					}
					RectTransform[] componentsInChildren2 = gameObject.GetComponentsInChildren<RectTransform>();
					for (int j = 0; j < componentsInChildren2.Length; j++)
					{
						if (componentsInChildren2[j].name == "pos1")
						{
							if (seasonDailyTable.Rewards.Count >= 1)
							{
								string[] array = seasonDailyTable.Rewards[0].Split(new char[]
								{
									','
								});
								ItemData itemData = ItemDataManager.CreateItemDataFromTable(int.Parse(array[0]), 100, 0);
								if (itemData != null)
								{
									itemData.Count = int.Parse(array[1]);
									ComItem comItem = base.CreateComItem(componentsInChildren2[j].gameObject);
									int idx = num;
									comItem.Setup(itemData, delegate(GameObject obj, ItemData item)
									{
										this.OnShowItemTip1(idx);
									});
									this.ShowTipItemData1.Add(itemData);
								}
							}
						}
						else if (componentsInChildren2[j].name == "pos2" && seasonDailyTable.Rewards.Count >= 2)
						{
							string[] array2 = seasonDailyTable.Rewards[1].Split(new char[]
							{
								','
							});
							ItemData itemData2 = ItemDataManager.CreateItemDataFromTable(int.Parse(array2[0]), 100, 0);
							if (itemData2 != null)
							{
								itemData2.Count = int.Parse(array2[1]);
								ComItem comItem2 = base.CreateComItem(componentsInChildren2[j].gameObject);
								int idx = num;
								comItem2.Setup(itemData2, delegate(GameObject obj, ItemData item)
								{
									this.OnShowItemTip2(idx);
								});
								this.ShowTipItemData2.Add(itemData2);
							}
						}
					}
					num++;
				}
			}
		}

		// Token: 0x0400A0D0 RID: 41168
		private string elePath = "UIFlatten/Prefabs/Pk/PkLadderAwardEle";

		// Token: 0x0400A0D1 RID: 41169
		private List<GameObject> ObjList = new List<GameObject>();

		// Token: 0x0400A0D2 RID: 41170
		private List<ItemData> ShowTipItemData1 = new List<ItemData>();

		// Token: 0x0400A0D3 RID: 41171
		private List<ItemData> ShowTipItemData2 = new List<ItemData>();

		// Token: 0x0400A0D4 RID: 41172
		[UIObject("middle/Scroll View/Viewport/Content")]
		protected GameObject AwardRoot;
	}
}
