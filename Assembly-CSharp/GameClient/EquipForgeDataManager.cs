using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x0200123F RID: 4671
	internal class EquipForgeDataManager : DataManager<EquipForgeDataManager>
	{
		// Token: 0x0600B39B RID: 45979 RVA: 0x0027F7DC File Offset: 0x0027DBDC
		public override void Initialize()
		{
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<EquipForgeTable>())
			{
				int key = keyValuePair.Key;
				Dictionary<int, object>.Enumerator enumerator;
				KeyValuePair<int, object> keyValuePair2 = enumerator.Current;
				EquipForgeTable equipForgeTable = keyValuePair2.Value as EquipForgeTable;
				EquipForgeDataManager.ForgeInfo forgeInfo = new EquipForgeDataManager.ForgeInfo();
				forgeInfo.itemData = ItemDataManager.CreateItemDataFromTable(key, 100, 0);
				forgeInfo.nRecommendLevel = equipForgeTable.RecommendLevel;
				forgeInfo.arrRecommendJobs = equipForgeTable.RecommendJobs;
				for (int i = 0; i < equipForgeTable.Material.Count; i++)
				{
					string[] array = equipForgeTable.Material[i].Split(new char[]
					{
						'_'
					});
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(int.Parse(array[0]), 100, 0);
					itemData.Count = int.Parse(array[1]);
					forgeInfo.arrMaterials.Add(itemData);
				}
				for (int j = 0; j < equipForgeTable.Price.Count; j++)
				{
					string[] array2 = equipForgeTable.Price[j].Split(new char[]
					{
						'_'
					});
					ItemData itemData2 = ItemDataManager.CreateItemDataFromTable(int.Parse(array2[0]), 100, 0);
					itemData2.Count = int.Parse(array2[1]);
					forgeInfo.arrPrices.Add(itemData2);
				}
				for (int k = 0; k < forgeInfo.arrRecommendJobs.Count; k++)
				{
					JobTable tableItem = Singleton<TableManager>.instance.GetTableItem<JobTable>(forgeInfo.arrRecommendJobs[k], string.Empty, string.Empty);
					if (tableItem != null && tableItem.Open > 0)
					{
						EquipForgeDataManager.TreeForgeInfo treeForgeInfo = this._FindTreeForgeInfo(this.m_treeForgeInfo, new string[]
						{
							tableItem.Name
						});
						if (treeForgeInfo == null)
						{
							treeForgeInfo = new EquipForgeDataManager.TreeForgeInfo();
							treeForgeInfo.strKey = tableItem.Name;
							treeForgeInfo.parent = this.m_treeForgeInfo;
							this.m_treeForgeInfo.arrInfos.Add(treeForgeInfo);
							treeForgeInfo.bSuitable = false;
							treeForgeInfo.bCanForge = false;
							treeForgeInfo.param = forgeInfo.arrRecommendJobs[k];
						}
						EquipForgeDataManager.TreeForgeInfo treeForgeInfo2 = this._FindTreeForgeInfo(treeForgeInfo, new string[]
						{
							equipForgeTable.MainTypeName
						});
						if (treeForgeInfo2 == null)
						{
							treeForgeInfo2 = new EquipForgeDataManager.TreeForgeInfo();
							treeForgeInfo2.strKey = equipForgeTable.MainTypeName;
							treeForgeInfo2.parent = treeForgeInfo;
							treeForgeInfo.arrInfos.Add(treeForgeInfo2);
							treeForgeInfo2.bSuitable = false;
							treeForgeInfo2.bCanForge = false;
						}
						EquipForgeDataManager.TreeForgeInfo treeForgeInfo3 = this._FindTreeForgeInfo(treeForgeInfo2, new string[]
						{
							equipForgeTable.SubTypeName
						});
						if (treeForgeInfo3 == null)
						{
							treeForgeInfo3 = new EquipForgeDataManager.TreeForgeInfo();
							treeForgeInfo3.strKey = equipForgeTable.SubTypeName;
							treeForgeInfo3.parent = treeForgeInfo2;
							treeForgeInfo2.arrInfos.Add(treeForgeInfo3);
							treeForgeInfo3.bSuitable = false;
							treeForgeInfo3.bCanForge = false;
						}
						string text = forgeInfo.itemData.TableID.ToString();
						EquipForgeDataManager.TreeForgeInfo treeForgeInfo4 = this._FindTreeForgeInfo(treeForgeInfo3, new string[]
						{
							text
						});
						if (treeForgeInfo4 == null)
						{
							treeForgeInfo4 = new EquipForgeDataManager.TreeForgeInfo();
							treeForgeInfo4.strKey = text;
							treeForgeInfo4.parent = treeForgeInfo3;
							treeForgeInfo3.arrInfos.Add(treeForgeInfo4);
							treeForgeInfo4.bSuitable = false;
							treeForgeInfo4.bCanForge = false;
						}
						treeForgeInfo4.param = forgeInfo;
					}
				}
			}
		}

		// Token: 0x0600B39C RID: 45980 RVA: 0x0027FB4C File Offset: 0x0027DF4C
		public override void Clear()
		{
			this.m_treeForgeInfo = new EquipForgeDataManager.TreeForgeInfo();
		}

		// Token: 0x0600B39D RID: 45981 RVA: 0x0027FB59 File Offset: 0x0027DF59
		public EquipForgeDataManager.TreeForgeInfo GetTreeForgeInfo()
		{
			return this.m_treeForgeInfo;
		}

		// Token: 0x0600B39E RID: 45982 RVA: 0x0027FB61 File Offset: 0x0027DF61
		public bool CheckRedPoint()
		{
			return this._CheckRedPoint(this.m_treeForgeInfo);
		}

		// Token: 0x0600B39F RID: 45983 RVA: 0x0027FB6F File Offset: 0x0027DF6F
		public void UpdateSuitable()
		{
			this._UpdateSuitable(this.m_treeForgeInfo);
		}

		// Token: 0x0600B3A0 RID: 45984 RVA: 0x0027FB7D File Offset: 0x0027DF7D
		public void UpdateCanForge()
		{
			this._UpdateCanForge(this.m_treeForgeInfo);
		}

		// Token: 0x0600B3A1 RID: 45985 RVA: 0x0027FB8C File Offset: 0x0027DF8C
		public bool IsEquipSuitable(EquipForgeDataManager.ForgeInfo a_equip)
		{
			int num = (int)(DataManager<PlayerBaseData>.GetInstance().Level - 30);
			int level = (int)DataManager<PlayerBaseData>.GetInstance().Level;
			return a_equip.nRecommendLevel >= num && a_equip.nRecommendLevel <= level;
		}

		// Token: 0x0600B3A2 RID: 45986 RVA: 0x0027FBD0 File Offset: 0x0027DFD0
		public EquipForgeDataManager.CheckForgeResult CheckEquipCanForge(EquipForgeDataManager.ForgeInfo a_info)
		{
			EquipForgeDataManager.CheckForgeResult checkForgeResult = new EquipForgeDataManager.CheckForgeResult();
			for (int i = a_info.arrMaterials.Count - 1; i >= 0; i--)
			{
				ItemData itemData = a_info.arrMaterials[i];
				if (itemData.Count > DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(itemData.TableID, true))
				{
					checkForgeResult.eType = EquipForgeDataManager.CheckForgeResult.EType.LessMaterial;
					checkForgeResult.userData = itemData;
					return checkForgeResult;
				}
			}
			for (int j = 0; j < a_info.arrPrices.Count; j++)
			{
				ItemData itemData2 = a_info.arrPrices[j];
				if (itemData2.Count > DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(itemData2.TableID, true))
				{
					checkForgeResult.eType = EquipForgeDataManager.CheckForgeResult.EType.LessPrice;
					checkForgeResult.userData = itemData2;
					return checkForgeResult;
				}
			}
			checkForgeResult.eType = EquipForgeDataManager.CheckForgeResult.EType.CanForge;
			return checkForgeResult;
		}

		// Token: 0x0600B3A3 RID: 45987 RVA: 0x0027FC9C File Offset: 0x0027E09C
		public void ForgeEquip(int a_nEquipID)
		{
			SceneEquipMakeReq sceneEquipMakeReq = new SceneEquipMakeReq();
			sceneEquipMakeReq.equipId = (uint)a_nEquipID;
			NetManager.Instance().SendCommand<SceneEquipMakeReq>(ServerType.GATE_SERVER, sceneEquipMakeReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneEquipMakeRet>(delegate(SceneEquipMakeRet msgRet)
			{
				if (msgRet == null)
				{
					return;
				}
				if (msgRet.code != 0U)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.EquipForgeFail, msgRet.code, null, null, null);
				}
				else
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.EquipForgeSuccess, a_nEquipID, null, null, null);
				}
			}, true, 15f, null);
		}

		// Token: 0x0600B3A4 RID: 45988 RVA: 0x0027FCF4 File Offset: 0x0027E0F4
		private bool _CheckRedPoint(EquipForgeDataManager.TreeForgeInfo a_treeForgeInfo)
		{
			bool result = false;
			for (int i = 0; i < a_treeForgeInfo.arrInfos.Count; i++)
			{
				EquipForgeDataManager.TreeForgeInfo treeForgeInfo = a_treeForgeInfo.arrInfos[i];
				EquipForgeDataManager.ForgeInfo forgeInfo = treeForgeInfo.param as EquipForgeDataManager.ForgeInfo;
				if (forgeInfo != null)
				{
					if (this.CheckEquipCanForge(forgeInfo).eType == EquipForgeDataManager.CheckForgeResult.EType.CanForge)
					{
						result = true;
						break;
					}
				}
				else
				{
					result = this._CheckRedPoint(treeForgeInfo);
				}
			}
			return result;
		}

		// Token: 0x0600B3A5 RID: 45989 RVA: 0x0027FD64 File Offset: 0x0027E164
		private EquipForgeDataManager.TreeForgeInfo _FindTreeForgeInfo(EquipForgeDataManager.TreeForgeInfo a_info, params string[] a_keys)
		{
			EquipForgeDataManager.TreeForgeInfo treeForgeInfo = a_info;
			foreach (string b in a_keys)
			{
				bool flag = false;
				for (int j = 0; j < treeForgeInfo.arrInfos.Count; j++)
				{
					if (treeForgeInfo.arrInfos[j].strKey == b)
					{
						treeForgeInfo = treeForgeInfo.arrInfos[j];
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return null;
				}
			}
			return treeForgeInfo;
		}

		// Token: 0x0600B3A6 RID: 45990 RVA: 0x0027FDE8 File Offset: 0x0027E1E8
		private void _UpdateSuitable(EquipForgeDataManager.TreeForgeInfo a_treeForgeInfo)
		{
			for (int i = 0; i < a_treeForgeInfo.arrInfos.Count; i++)
			{
				EquipForgeDataManager.TreeForgeInfo treeForgeInfo = a_treeForgeInfo.arrInfos[i];
				treeForgeInfo.bSuitable = false;
				EquipForgeDataManager.ForgeInfo forgeInfo = treeForgeInfo.param as EquipForgeDataManager.ForgeInfo;
				if (forgeInfo != null)
				{
					bool flag = this.IsEquipSuitable(forgeInfo);
					if (flag)
					{
						while (treeForgeInfo != null)
						{
							treeForgeInfo.bSuitable = true;
							treeForgeInfo = treeForgeInfo.parent;
						}
					}
				}
				else
				{
					this._UpdateSuitable(treeForgeInfo);
				}
			}
		}

		// Token: 0x0600B3A7 RID: 45991 RVA: 0x0027FE6C File Offset: 0x0027E26C
		private void _UpdateCanForge(EquipForgeDataManager.TreeForgeInfo a_treeForgeInfo)
		{
			for (int i = 0; i < a_treeForgeInfo.arrInfos.Count; i++)
			{
				EquipForgeDataManager.TreeForgeInfo treeForgeInfo = a_treeForgeInfo.arrInfos[i];
				treeForgeInfo.bCanForge = false;
				EquipForgeDataManager.ForgeInfo forgeInfo = treeForgeInfo.param as EquipForgeDataManager.ForgeInfo;
				if (forgeInfo != null)
				{
					if (this.CheckEquipCanForge(forgeInfo).eType == EquipForgeDataManager.CheckForgeResult.EType.CanForge)
					{
						while (treeForgeInfo != null)
						{
							treeForgeInfo.bCanForge = true;
							treeForgeInfo = treeForgeInfo.parent;
						}
					}
				}
				else
				{
					this._UpdateCanForge(treeForgeInfo);
				}
			}
		}

		// Token: 0x04006545 RID: 25925
		private EquipForgeDataManager.TreeForgeInfo m_treeForgeInfo = new EquipForgeDataManager.TreeForgeInfo();

		// Token: 0x02001240 RID: 4672
		public class CheckForgeResult
		{
			// Token: 0x04006546 RID: 25926
			public EquipForgeDataManager.CheckForgeResult.EType eType;

			// Token: 0x04006547 RID: 25927
			public object userData;

			// Token: 0x02001241 RID: 4673
			public enum EType
			{
				// Token: 0x04006549 RID: 25929
				CanForge,
				// Token: 0x0400654A RID: 25930
				LessPrice,
				// Token: 0x0400654B RID: 25931
				LessMaterial
			}
		}

		// Token: 0x02001242 RID: 4674
		public class ForgeInfo
		{
			// Token: 0x0400654C RID: 25932
			public int nRecommendLevel;

			// Token: 0x0400654D RID: 25933
			public IList<int> arrRecommendJobs;

			// Token: 0x0400654E RID: 25934
			public ItemData itemData;

			// Token: 0x0400654F RID: 25935
			public List<ItemData> arrMaterials = new List<ItemData>();

			// Token: 0x04006550 RID: 25936
			public List<ItemData> arrPrices = new List<ItemData>();
		}

		// Token: 0x02001243 RID: 4675
		public class TreeForgeInfo
		{
			// Token: 0x04006551 RID: 25937
			public string strKey;

			// Token: 0x04006552 RID: 25938
			public EquipForgeDataManager.TreeForgeInfo parent;

			// Token: 0x04006553 RID: 25939
			public List<EquipForgeDataManager.TreeForgeInfo> arrInfos = new List<EquipForgeDataManager.TreeForgeInfo>();

			// Token: 0x04006554 RID: 25940
			public bool bSuitable;

			// Token: 0x04006555 RID: 25941
			public bool bCanForge;

			// Token: 0x04006556 RID: 25942
			public object param;
		}
	}
}
