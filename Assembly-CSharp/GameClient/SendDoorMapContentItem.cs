using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017CD RID: 6093
	public class SendDoorMapContentItem : MonoBehaviour
	{
		// Token: 0x0600F04A RID: 61514 RVA: 0x0040ABF3 File Offset: 0x00408FF3
		private void ResetData()
		{
			this.townIDs.Clear();
			this.mapTowns.Clear();
			this.lastSelect = null;
		}

		// Token: 0x0600F04B RID: 61515 RVA: 0x0040AC14 File Offset: 0x00409014
		public void InitMapData(CityTeleportTable.eTabType tabType)
		{
			List<int> dataByType = this.GetDataByType(tabType);
			if (dataByType != null)
			{
				this.townIDs = new List<int>();
				this.townIDs.AddRange(dataByType);
				this.mapTowns = new Dictionary<int, TownItemData>();
				for (int i = 0; i < this.townIDs.Count; i++)
				{
					CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(this.townIDs[i], string.Empty, string.Empty);
					if (tableItem != null)
					{
						TownItemData townItemData = new TownItemData
						{
							id = this.townIDs[i],
							name = tableItem.Name,
							minLv = tableItem.LevelLimit
						};
						if (!this.mapTowns.ContainsKey(townItemData.id))
						{
							this.mapTowns.Add(townItemData.id, townItemData);
						}
					}
				}
			}
			this.ShowTowns();
		}

		// Token: 0x0600F04C RID: 61516 RVA: 0x0040ACFC File Offset: 0x004090FC
		private void ShowTowns()
		{
			ComCommonBind component = base.transform.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			GameObject gameObject = component.GetGameObject("cities");
			if (gameObject == null)
			{
				return;
			}
			if (this.townIDs == null)
			{
				return;
			}
			for (int i = 0; i < this.townIDs.Count; i++)
			{
				Transform child = gameObject.transform.GetChild(i);
				if (child != null)
				{
					GameObject gameObject2 = this.LoadTownItemView(child.gameObject);
					if (gameObject2 != null)
					{
						this.SetTownView(this.townIDs[i], gameObject2);
					}
				}
			}
		}

		// Token: 0x0600F04D RID: 61517 RVA: 0x0040ADAC File Offset: 0x004091AC
		private void SetTownView(int id, GameObject townView)
		{
			if (townView == null)
			{
				return;
			}
			TownItemData townData = null;
			if (this.mapTowns.TryGetValue(id, out townData))
			{
				townView.CustomActive((int)DataManager<PlayerBaseData>.GetInstance().Level >= townData.minLv);
				Button cityBtn = townView.GetComponent<Button>();
				if (cityBtn != null)
				{
					cityBtn.SafeRemoveAllListener();
					cityBtn.SafeAddOnClickListener(delegate
					{
						this.OnTownBtnClick(cityBtn, townData.id);
					});
				}
				ComCommonBind component = townView.GetComponent<ComCommonBind>();
				if (component != null)
				{
					Text com = component.GetCom<Text>("name");
					com.SafeSetText(townData.name);
				}
			}
		}

		// Token: 0x0600F04E RID: 61518 RVA: 0x0040AE90 File Offset: 0x00409290
		private void OnTownBtnClick(Button btn, int townId)
		{
			TownItemData townItemData = null;
			if (this.mapTowns.TryGetValue(townId, out townItemData))
			{
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(string.Format(TR.Value("sendDoorSureTip"), townItemData.name), delegate()
				{
					this.GotoTheTown(townId);
				}, null, 0f, false);
			}
			if (btn != null)
			{
				if (this.lastSelect != null)
				{
					this.lastSelect.CustomActive(false);
				}
				GameObject gameObject = Utility.FindChild(btn.gameObject, "select");
				if (gameObject != null)
				{
					gameObject.CustomActive(true);
					this.lastSelect = gameObject;
				}
			}
		}

		// Token: 0x0600F04F RID: 61519 RVA: 0x0040AF4C File Offset: 0x0040934C
		private void GotoTheTown(int id)
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			if (Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(id, string.Empty, string.Empty) == null)
			{
				return;
			}
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemTown._NetSyncChangeScene(new SceneParams
			{
				currSceneID = clientSystemTown.CurrentSceneID,
				currDoorID = 0,
				targetSceneID = id,
				targetDoorID = 0
			}, false));
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MiyaSendDoorFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<MiyaSendDoorFrame>(null, false);
			}
		}

		// Token: 0x0600F050 RID: 61520 RVA: 0x0040AFE4 File Offset: 0x004093E4
		private GameObject LoadTownItemView(GameObject contentRoot)
		{
			if (contentRoot == null)
			{
				return null;
			}
			UIPrefabWrapper component = contentRoot.GetComponent<UIPrefabWrapper>();
			if (component != null)
			{
				GameObject gameObject = component.LoadUIPrefab();
				if (gameObject != null)
				{
					gameObject.transform.SetParent(contentRoot.transform, false);
					return gameObject;
				}
			}
			return null;
		}

		// Token: 0x0600F051 RID: 61521 RVA: 0x0040B03C File Offset: 0x0040943C
		private List<int> GetDataByType(CityTeleportTable.eTabType tabType)
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<CityTeleportTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					CityTeleportTable cityTeleportTable = keyValuePair.Value as CityTeleportTable;
					if (cityTeleportTable != null && cityTeleportTable.TabType == tabType)
					{
						return cityTeleportTable.CityID.ToList<int>();
					}
				}
			}
			return null;
		}

		// Token: 0x0600F052 RID: 61522 RVA: 0x0040B0A6 File Offset: 0x004094A6
		private void OnDestroy()
		{
			this.ResetData();
		}

		// Token: 0x04009350 RID: 37712
		private List<int> townIDs = new List<int>();

		// Token: 0x04009351 RID: 37713
		private Dictionary<int, TownItemData> mapTowns = new Dictionary<int, TownItemData>();

		// Token: 0x04009352 RID: 37714
		private GameObject lastSelect;
	}
}
