using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020019C7 RID: 6599
	public class ComRandomTreasureMapSite : MonoBehaviour
	{
		// Token: 0x06010280 RID: 66176 RVA: 0x004805E8 File Offset: 0x0047E9E8
		private void OnDestroy()
		{
			if (this.mDigSiteBtnList != null)
			{
				for (int i = 0; i < this.mDigSiteBtnList.Count; i++)
				{
					Object.Destroy(this.mDigSiteBtnList[i].gameObject);
				}
				this.mDigSiteBtnList.Clear();
				this.mDigSiteBtnList = null;
			}
			this.bInited = false;
		}

		// Token: 0x06010281 RID: 66177 RVA: 0x0048064C File Offset: 0x0047EA4C
		private bool _CheckMapSitePosMatchBtnCount()
		{
			bool result = false;
			if (this.mDigSiteBtnList == null)
			{
				Logger.LogError("[ComRandomTreasureMapSite] - RefreshMapSite mDigSiteBtnList is null");
				return result;
			}
			if (this.mDigSitePositions == null)
			{
				Logger.LogError("[ComRandomTreasureMapSite] - RefreshMapSite mDigSitePositions is null");
				return result;
			}
			if (this.mDigSitePositions.Length != this.mDigSiteBtnList.Count)
			{
				Logger.LogError("[ComRandomTreasureMapSite] - Start mDigSitePositions.Length != mDigSiteBtnList.Count");
				return result;
			}
			return true;
		}

		// Token: 0x06010282 RID: 66178 RVA: 0x004806B0 File Offset: 0x0047EAB0
		public void InitView()
		{
			if (this.bInited)
			{
				return;
			}
			if (this.mDigSitePositions != null)
			{
				if (this.mDigSiteBtnList != null)
				{
					this.mDigSiteBtnList.Clear();
				}
				for (int i = 0; i < this.mDigSitePositions.Length; i++)
				{
					this.mDigSitePositions[i].CustomActive(false);
					GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("UIFlatten/Prefabs/RandomTreasureFrame/RandomTreasureSiteBtn", true, 0U);
					Utility.AttachTo(gameObject, this.mDigSitePositions[i], false);
					if (gameObject)
					{
						gameObject.transform.localPosition = Vector3.zero;
					}
					if (!(gameObject == null))
					{
						ComRandomTreasureSiteBtn component = gameObject.GetComponent<ComRandomTreasureSiteBtn>();
						if (component != null && this.mDigSiteBtnList != null)
						{
							this.mDigSiteBtnList.Add(component);
						}
					}
				}
				if (this.mDigSitePositions.Length != this.mDigSiteBtnList.Count)
				{
					Logger.LogError("[ComRandomTreasureMapSite] - Start mDigSitePositions.Length != mDigSiteBtnList.Count");
				}
			}
			this.CustomActive(false);
			this.bInited = true;
		}

		// Token: 0x06010283 RID: 66179 RVA: 0x004807B8 File Offset: 0x0047EBB8
		public void RefreshMapSite(RandomTreasureMapDigSiteModel mapSiteModel)
		{
			if (mapSiteModel == null)
			{
				Logger.LogError("[ComRandomTreasureMapSite] - RefreshMapSite mapSiteModel is null");
				return;
			}
			if (!this._CheckMapSitePosMatchBtnCount())
			{
				return;
			}
			int index = mapSiteModel.index;
			if (index < this.mDigSitePositions.Length && index < this.mDigSiteBtnList.Count)
			{
				GameObject parent = this.mDigSitePositions[index];
				this.mDigSiteBtnList[index].Refresh(mapSiteModel, parent);
			}
		}

		// Token: 0x06010284 RID: 66180 RVA: 0x00480828 File Offset: 0x0047EC28
		public void RefreshMapSite(RandomTreasureMapModel mapModels)
		{
			if (mapModels == null || mapModels.mapTotalDigSites == null)
			{
				Logger.LogError("[ComRandomTreasureMapSite] - RefreshMapSite mapModel is null");
				return;
			}
			if (!this._CheckMapSitePosMatchBtnCount())
			{
				return;
			}
			for (int i = 0; i < mapModels.mapTotalDigSites.Count; i++)
			{
				RandomTreasureMapDigSiteModel randomTreasureMapDigSiteModel = mapModels.mapTotalDigSites[i];
				if (randomTreasureMapDigSiteModel != null)
				{
					int index = randomTreasureMapDigSiteModel.index;
					if (index < this.mDigSitePositions.Length && index < this.mDigSiteBtnList.Count)
					{
						GameObject parent = this.mDigSitePositions[index];
						this.mDigSiteBtnList[index].Refresh(randomTreasureMapDigSiteModel, parent);
					}
				}
			}
		}

		// Token: 0x0400A32F RID: 41775
		public const string SITE_BUTTON_RES_PATH = "UIFlatten/Prefabs/RandomTreasureFrame/RandomTreasureSiteBtn";

		// Token: 0x0400A330 RID: 41776
		private bool bInited;

		// Token: 0x0400A331 RID: 41777
		[SerializeField]
		private GameObject[] mDigSitePositions;

		// Token: 0x0400A332 RID: 41778
		private List<ComRandomTreasureSiteBtn> mDigSiteBtnList = new List<ComRandomTreasureSiteBtn>();
	}
}
