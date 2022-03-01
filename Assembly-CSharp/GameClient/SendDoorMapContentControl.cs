using System;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020017CB RID: 6091
	public class SendDoorMapContentControl : MonoBehaviour
	{
		// Token: 0x0600F03D RID: 61501 RVA: 0x0040A938 File Offset: 0x00408D38
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600F03E RID: 61502 RVA: 0x0040A940 File Offset: 0x00408D40
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600F03F RID: 61503 RVA: 0x0040A94E File Offset: 0x00408D4E
		private void BindEvents()
		{
		}

		// Token: 0x0600F040 RID: 61504 RVA: 0x0040A950 File Offset: 0x00408D50
		private void UnBindEvents()
		{
		}

		// Token: 0x0600F041 RID: 61505 RVA: 0x0040A952 File Offset: 0x00408D52
		private void ClearData()
		{
			this.tabType = CityTeleportTable.eTabType.TabType_None;
			this.eastCountyViewItem = null;
			this.NewLandViewItem = null;
		}

		// Token: 0x0600F042 RID: 61506 RVA: 0x0040A96C File Offset: 0x00408D6C
		public void ShowMapContent(CityTeleportTable.eTabType modelType)
		{
			this.ResetContentRoot();
			this.tabType = modelType;
			switch (modelType)
			{
			case CityTeleportTable.eTabType.AlardLand:
				this.OnAlardClick();
				break;
			case CityTeleportTable.eTabType.EastCountry:
				this.OnEastCoutryClick();
				break;
			case CityTeleportTable.eTabType.NewLand:
				this.OnNewLandClick();
				break;
			}
		}

		// Token: 0x0600F043 RID: 61507 RVA: 0x0040A9C8 File Offset: 0x00408DC8
		private void OnAlardClick()
		{
			if (this.alardRoot != null && !this.alardRoot.activeSelf)
			{
				this.alardRoot.CustomActive(true);
			}
			if (this.alardViewItem == null)
			{
				this.alardViewItem = this.LoadContentBaseView(this.alardRoot);
				if (this.alardViewItem != null)
				{
					this.alardViewItem.InitMapData(this.tabType);
				}
			}
		}

		// Token: 0x0600F044 RID: 61508 RVA: 0x0040AA48 File Offset: 0x00408E48
		private void OnEastCoutryClick()
		{
			if (this.eastCountryRoot != null && !this.eastCountryRoot.activeSelf)
			{
				this.eastCountryRoot.CustomActive(true);
			}
			if (this.eastCountyViewItem == null)
			{
				this.eastCountyViewItem = this.LoadContentBaseView(this.eastCountryRoot);
				if (this.eastCountyViewItem != null)
				{
					this.eastCountyViewItem.InitMapData(this.tabType);
				}
			}
		}

		// Token: 0x0600F045 RID: 61509 RVA: 0x0040AAC8 File Offset: 0x00408EC8
		private void OnNewLandClick()
		{
			if (this.newLandRoot != null && !this.newLandRoot.activeSelf)
			{
				this.newLandRoot.CustomActive(true);
			}
			if (this.NewLandViewItem == null)
			{
				this.NewLandViewItem = this.LoadContentBaseView(this.newLandRoot);
				if (this.NewLandViewItem != null)
				{
					this.NewLandViewItem.InitMapData(this.tabType);
				}
			}
		}

		// Token: 0x0600F046 RID: 61510 RVA: 0x0040AB47 File Offset: 0x00408F47
		private void ResetContentRoot()
		{
			this.alardRoot.CustomActive(false);
			this.eastCountryRoot.CustomActive(false);
			this.newLandRoot.CustomActive(false);
		}

		// Token: 0x0600F047 RID: 61511 RVA: 0x0040AB70 File Offset: 0x00408F70
		private SendDoorMapContentItem LoadContentBaseView(GameObject contentRoot)
		{
			if (contentRoot == null)
			{
				return null;
			}
			SendDoorMapContentItem result = null;
			UIPrefabWrapper component = contentRoot.GetComponent<UIPrefabWrapper>();
			if (component != null)
			{
				GameObject gameObject = component.LoadUIPrefab();
				if (gameObject != null)
				{
					gameObject.transform.SetParent(contentRoot.transform, false);
					result = gameObject.GetComponent<SendDoorMapContentItem>();
				}
			}
			return result;
		}

		// Token: 0x04009345 RID: 37701
		private CityTeleportTable.eTabType tabType;

		// Token: 0x04009346 RID: 37702
		private SendDoorModelData sendDoorModelData;

		// Token: 0x04009347 RID: 37703
		[Space(15f)]
		[Header("AuctionNewContent")]
		[SerializeField]
		private GameObject alardRoot;

		// Token: 0x04009348 RID: 37704
		[SerializeField]
		private GameObject eastCountryRoot;

		// Token: 0x04009349 RID: 37705
		[SerializeField]
		private GameObject newLandRoot;

		// Token: 0x0400934A RID: 37706
		private SendDoorMapContentItem alardViewItem;

		// Token: 0x0400934B RID: 37707
		private SendDoorMapContentItem eastCountyViewItem;

		// Token: 0x0400934C RID: 37708
		private SendDoorMapContentItem NewLandViewItem;
	}
}
