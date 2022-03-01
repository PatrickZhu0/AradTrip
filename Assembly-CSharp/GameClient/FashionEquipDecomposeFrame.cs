using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020016B7 RID: 5815
	public class FashionEquipDecomposeFrame : ClientFrame
	{
		// Token: 0x0600E407 RID: 58375 RVA: 0x003AF298 File Offset: 0x003AD698
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Package/FashionEquipDecompose";
		}

		// Token: 0x0600E408 RID: 58376 RVA: 0x003AF2A0 File Offset: 0x003AD6A0
		protected override void _OnOpenFrame()
		{
			this.itemIDs = new List<ulong>();
			if (this.userData != null && this.userData is List<ulong>)
			{
				this.itemIDs = (List<ulong>)this.userData;
			}
			this.InitDecomposeTableData();
			this.BindUIEvent();
			this.UpdateUI();
		}

		// Token: 0x0600E409 RID: 58377 RVA: 0x003AF2F6 File Offset: 0x003AD6F6
		protected override void _OnCloseFrame()
		{
			this.itemIDs = null;
			this.UnBindUIEvent();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.CloseFashionEquipDecompose, null, null, null, null);
		}

		// Token: 0x0600E40A RID: 58378 RVA: 0x003AF318 File Offset: 0x003AD718
		protected override void _bindExUI()
		{
			this.Cancel = this.mBind.GetCom<Button>("Cancel");
			this.Cancel.SafeSetOnClickListener(delegate
			{
				this.frameMgr.CloseFrame<FashionEquipDecomposeFrame>(this, false);
			});
			this.Confirm = this.mBind.GetCom<Button>("Confirm");
			this.Confirm.SafeSetOnClickListener(delegate
			{
				if (this.itemIDs != null)
				{
					List<ulong> list = new List<ulong>();
					if (list != null)
					{
						for (int i = 0; i < this.itemIDs.Count; i++)
						{
							ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(this.itemIDs[i]);
							if (item != null)
							{
								if (item.Quality > ItemTable.eColor.PURPLE || item.ThirdType == ItemTable.eThirdType.FASHION_FESTIVAL || item.SuitID == 101139)
								{
									list.Add(this.itemIDs[i]);
								}
							}
						}
						list.Sort(delegate(ulong x, ulong y)
						{
							ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(x);
							ItemData item3 = DataManager<ItemDataManager>.GetInstance().GetItem(y);
							if (item2 == null || item3 == null)
							{
								return -1;
							}
							if (item2.Quality != item3.Quality)
							{
								return item3.Quality - item2.Quality;
							}
							return item2.TableID - item3.TableID;
						});
						ulong[] ids = this.itemIDs.ToArray();
						if (list.Count == 0)
						{
							DataManager<ItemDataManager>.GetInstance().SendDecomposeItem(ids, true);
						}
						else
						{
							SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(683, string.Empty, string.Empty);
							int value = tableItem.Value;
							SystemNotifyManager.SysNotifyMsgBoxCancelOk(this.GetMultiDecomposeTipDesc(list), string.Empty, string.Empty, null, delegate()
							{
								DataManager<ItemDataManager>.GetInstance().SendDecomposeItem(ids, true);
							}, (float)value, false, null, true);
						}
					}
				}
			});
			this.itemsRoot = this.mBind.GetGameObject("itemsRoot");
			this.itemTemplate = this.mBind.GetGameObject("itemTemplate");
			this.noItemTips = this.mBind.GetGameObject("noItemTips");
		}

		// Token: 0x0600E40B RID: 58379 RVA: 0x003AF3C1 File Offset: 0x003AD7C1
		protected override void _unbindExUI()
		{
			this.Cancel = null;
			this.Confirm = null;
			this.itemsRoot = null;
			this.itemTemplate = null;
			this.noItemTips = null;
		}

		// Token: 0x0600E40C RID: 58380 RVA: 0x003AF3E6 File Offset: 0x003AD7E6
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SelectFashionEquipToDecompose, new ClientEventSystem.UIEventHandler(this._OnSelectFashionEquipToDecompose));
		}

		// Token: 0x0600E40D RID: 58381 RVA: 0x003AF403 File Offset: 0x003AD803
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SelectFashionEquipToDecompose, new ClientEventSystem.UIEventHandler(this._OnSelectFashionEquipToDecompose));
		}

		// Token: 0x0600E40E RID: 58382 RVA: 0x003AF420 File Offset: 0x003AD820
		private string GetMultiDecomposeTipDesc(List<ulong> guids)
		{
			if (guids == null)
			{
				return string.Empty;
			}
			if (guids.Count == 0)
			{
				return string.Empty;
			}
			if (guids.Count != 1)
			{
				string text = string.Empty;
				int num = 0;
				while (num < guids.Count && num < 6)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(guids[num]);
					if (item != null)
					{
						text += TR.Value("decompose_fashion_name", item.GetColorName(string.Empty, false));
					}
					num++;
				}
				return TR.Value("decompose_multiple_fashion_tips", text, guids.Count);
			}
			ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(guids[0]);
			if (item2 != null)
			{
				return TR.Value("decompose_one_fashion_tips", item2.GetQualityDesc(), item2.GetColorName(string.Empty, false));
			}
			return string.Empty;
		}

		// Token: 0x0600E40F RID: 58383 RVA: 0x003AF50C File Offset: 0x003AD90C
		private void InitDecomposeTableData()
		{
			if (FashionEquipDecomposeFrame.decomposeKey2InscriptionID != null && FashionEquipDecomposeFrame.fashionTableID2InscriptionID != null && (FashionEquipDecomposeFrame.decomposeKey2InscriptionID.Count == 0 || FashionEquipDecomposeFrame.fashionTableID2InscriptionID.Count == 0))
			{
				FashionEquipDecomposeFrame.decomposeKey2InscriptionID.Clear();
				FashionEquipDecomposeFrame.fashionTableID2InscriptionID.Clear();
				Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<FashionDecomposeTable>();
				if (table != null)
				{
					foreach (KeyValuePair<int, object> keyValuePair in table)
					{
						FashionDecomposeTable fashionDecomposeTable = keyValuePair.Value as FashionDecomposeTable;
						if (fashionDecomposeTable != null)
						{
							FashionEquipDecomposeFrame.DecomposeKey key = new FashionEquipDecomposeFrame.DecomposeKey
							{
								eSubType = (ItemTable.eSubType)fashionDecomposeTable.SubType,
								eThirdType = (ItemTable.eThirdType)fashionDecomposeTable.ThirdType,
								eColor = (ItemTable.eColor)fashionDecomposeTable.Color
							};
							List<int> list = new List<int>();
							list.AddRange(fashionDecomposeTable.Text);
							FashionEquipDecomposeFrame.decomposeKey2InscriptionID.SafeAdd(key, list);
							if (fashionDecomposeTable.FashionID > 0)
							{
								List<int> list2 = new List<int>();
								list2.AddRange(fashionDecomposeTable.Text);
								FashionEquipDecomposeFrame.fashionTableID2InscriptionID.SafeAdd(fashionDecomposeTable.FashionID, list2);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600E410 RID: 58384 RVA: 0x003AF630 File Offset: 0x003ADA30
		private void UpdateUI()
		{
			bool flag = this.itemIDs == null || this.itemIDs.Count == 0;
			this.Confirm.SafeSetGray(flag, true);
			this.noItemTips.CustomActive(flag);
			this.itemsRoot.CustomActive(!flag);
			this.UpdateDecomposeItems();
		}

		// Token: 0x0600E411 RID: 58385 RVA: 0x003AF688 File Offset: 0x003ADA88
		private List<int> CalcDecomposeInscriptionList()
		{
			if (FashionEquipDecomposeFrame.decomposeKey2InscriptionID == null || FashionEquipDecomposeFrame.fashionTableID2InscriptionID == null)
			{
				return null;
			}
			if (this.itemIDs == null)
			{
				return null;
			}
			List<int> list = new List<int>();
			if (list == null)
			{
				return null;
			}
			for (int i = 0; i < this.itemIDs.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(this.itemIDs[i]);
				if (item != null)
				{
					if (FashionEquipDecomposeFrame.fashionTableID2InscriptionID.ContainsKey(item.TableID))
					{
						list.AddRange(FashionEquipDecomposeFrame.fashionTableID2InscriptionID[item.TableID]);
					}
					else if (item.TableData != null)
					{
						FashionEquipDecomposeFrame.DecomposeKey decomposeKey = new FashionEquipDecomposeFrame.DecomposeKey
						{
							eSubType = (ItemTable.eSubType)item.SubType,
							eThirdType = item.ThirdType,
							eColor = item.TableData.Color
						};
						if (decomposeKey != null)
						{
							if (FashionEquipDecomposeFrame.decomposeKey2InscriptionID.ContainsKey(decomposeKey))
							{
								list.AddRange(FashionEquipDecomposeFrame.decomposeKey2InscriptionID[decomposeKey]);
							}
						}
					}
				}
			}
			list.Sort(delegate(int a, int b)
			{
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(a, 100, 0);
				ItemData itemData2 = ItemDataManager.CreateItemDataFromTable(b, 100, 0);
				if (itemData != null && itemData2 != null)
				{
					return itemData2.Quality.CompareTo(itemData.Quality);
				}
				return 0;
			});
			return list;
		}

		// Token: 0x0600E412 RID: 58386 RVA: 0x003AF7CC File Offset: 0x003ADBCC
		private void UpdateDecomposeItems()
		{
			if (this.itemsRoot == null)
			{
				return;
			}
			if (this.itemTemplate == null)
			{
				return;
			}
			for (int i = 0; i < this.itemsRoot.transform.childCount; i++)
			{
				GameObject gameObject = this.itemsRoot.transform.GetChild(i).gameObject;
				Object.Destroy(gameObject);
			}
			List<int> list = this.CalcDecomposeInscriptionList();
			if (list == null)
			{
				return;
			}
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			if (dictionary == null)
			{
				return;
			}
			for (int j = 0; j < list.Count; j++)
			{
				int key = list[j];
				int num = dictionary.SafeGetValue(key);
				num++;
				dictionary.SafeAdd(key, 1);
				if (dictionary.Count > 5)
				{
					break;
				}
			}
			foreach (KeyValuePair<int, int> keyValuePair in dictionary)
			{
				int key2 = keyValuePair.Key;
				GameObject gameObject2 = Object.Instantiate<GameObject>(this.itemTemplate.gameObject);
				Utility.AttachTo(gameObject2, this.itemsRoot, false);
				gameObject2.CustomActive(true);
				ComCommonBind component = gameObject2.GetComponent<ComCommonBind>();
				if (!(component == null))
				{
					ComItem com = component.GetCom<ComItem>("Item");
					if (!(com == null))
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable(key2, 100, 0);
						if (itemData != null)
						{
							itemData.Count = keyValuePair.Value;
							com.Setup(itemData, delegate(GameObject go, ItemData item)
							{
								DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
							});
							Text com2 = component.GetCom<Text>("name");
							com2.SafeSetText(CommonUtility.GetItemColorName(itemData.TableData));
						}
					}
				}
			}
		}

		// Token: 0x0600E413 RID: 58387 RVA: 0x003AF9C4 File Offset: 0x003ADDC4
		private void _OnSelectFashionEquipToDecompose(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			if (this.itemIDs == null)
			{
				return;
			}
			ulong item = (ulong)uiEvent.Param1;
			bool flag = (bool)uiEvent.Param2;
			if (flag)
			{
				this.itemIDs.Add(item);
			}
			else
			{
				this.itemIDs.Remove(item);
			}
			this.UpdateUI();
		}

		// Token: 0x040088F4 RID: 35060
		private List<ulong> itemIDs;

		// Token: 0x040088F5 RID: 35061
		private static Dictionary<FashionEquipDecomposeFrame.DecomposeKey, List<int>> decomposeKey2InscriptionID = new Dictionary<FashionEquipDecomposeFrame.DecomposeKey, List<int>>();

		// Token: 0x040088F6 RID: 35062
		private static Dictionary<int, List<int>> fashionTableID2InscriptionID = new Dictionary<int, List<int>>();

		// Token: 0x040088F7 RID: 35063
		private const int maxInscriptionIDNum = 5;

		// Token: 0x040088F8 RID: 35064
		private Button Cancel;

		// Token: 0x040088F9 RID: 35065
		private Button Confirm;

		// Token: 0x040088FA RID: 35066
		private GameObject itemsRoot;

		// Token: 0x040088FB RID: 35067
		private GameObject itemTemplate;

		// Token: 0x040088FC RID: 35068
		private GameObject noItemTips;

		// Token: 0x020016B8 RID: 5816
		public class DecomposeKey
		{
			// Token: 0x0600E41B RID: 58395 RVA: 0x003AFC5C File Offset: 0x003AE05C
			public override bool Equals(object obj)
			{
				FashionEquipDecomposeFrame.DecomposeKey decomposeKey = obj as FashionEquipDecomposeFrame.DecomposeKey;
				return decomposeKey != null && (decomposeKey.eSubType == this.eSubType && decomposeKey.eThirdType == this.eThirdType) && decomposeKey.eColor == this.eColor;
			}

			// Token: 0x0600E41C RID: 58396 RVA: 0x003AFCAB File Offset: 0x003AE0AB
			public override int GetHashCode()
			{
				return this.eSubType.GetHashCode() + this.eThirdType.GetHashCode() + this.eColor.GetHashCode();
			}

			// Token: 0x04008900 RID: 35072
			public ItemTable.eSubType eSubType;

			// Token: 0x04008901 RID: 35073
			public ItemTable.eThirdType eThirdType;

			// Token: 0x04008902 RID: 35074
			public ItemTable.eColor eColor;
		}
	}
}
