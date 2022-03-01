using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000ED2 RID: 3794
[ExecuteInEditMode]
public class ComDungeonMapCombine : MonoBehaviour
{
	// Token: 0x0600952F RID: 38191 RVA: 0x001C1B97 File Offset: 0x001BFF97
	public void SetDungeonMap(DDungeonMapData data)
	{
		this.mMapdata = data;
		this._loadMap();
	}

	// Token: 0x06009530 RID: 38192 RVA: 0x001C1BA6 File Offset: 0x001BFFA6
	public void OnDestroy()
	{
		if (null != this.mMapdata)
		{
			this.mMapdata = null;
		}
	}

	// Token: 0x06009531 RID: 38193 RVA: 0x001C1BC0 File Offset: 0x001BFFC0
	public void SetDungeonID(int id)
	{
		this.mDungeonID = id / 10 * 10;
		this._updateMapTips();
	}

	// Token: 0x06009532 RID: 38194 RVA: 0x001C1BD8 File Offset: 0x001BFFD8
	private void _updateMapTips()
	{
		for (int i = 0; i < this.mUnitMapList.Length; i++)
		{
			DDungeonMapUnitData ddungeonMapUnitData = this.mMapdata.dungeonList[i];
			ComDungeonUnitMap comDungeonUnitMap = this.mUnitMapList[i];
			if (ddungeonMapUnitData.dungeonid == this.mDungeonID)
			{
				comDungeonUnitMap.transform.SetAsLastSibling();
				comDungeonUnitMap.SetActive(true);
			}
			else
			{
				comDungeonUnitMap.transform.SetAsFirstSibling();
				comDungeonUnitMap.SetActive(false);
			}
		}
	}

	// Token: 0x06009533 RID: 38195 RVA: 0x001C1C50 File Offset: 0x001C0050
	private void _loadMap()
	{
		DDungeonMapUnitData[] dungeonList = this.mMapdata.dungeonList;
		if (this.mRoot != null)
		{
			Object.DestroyImmediate(this.mRoot);
		}
		this.mRoot = new GameObject("Background", new Type[]
		{
			typeof(Image)
		});
		Utility.AttachTo(this.mRoot, base.gameObject, false);
		this.mRoot.transform.SetAsFirstSibling();
		RectTransform component = this.mRoot.GetComponent<RectTransform>();
		component.anchorMin = new Vector2(0.5f, 0.5f);
		component.anchorMax = new Vector2(0.5f, 0.5f);
		component.offsetMin = new Vector2((float)(-(float)this.mSizeUnit * this.mMapdata.weith / 2 - this.mOffset), (float)(-(float)this.mSizeUnit * this.mMapdata.heigth / 2 - this.mOffset));
		component.offsetMax = new Vector2((float)(this.mSizeUnit * this.mMapdata.weith / 2 + this.mOffset), (float)(this.mSizeUnit * this.mMapdata.heigth / 2 + this.mOffset));
		Image component2 = this.mRoot.GetComponent<Image>();
		component2.type = 1;
		component2.sprite = this.mBackground;
		this.mUnitMapList = new ComDungeonUnitMap[dungeonList.Length];
		for (int i = 0; i < dungeonList.Length; i++)
		{
			DDungeonMapUnitData ddungeonMapUnitData = dungeonList[i];
			GameObject gameObject = new GameObject(i.ToString(), new Type[]
			{
				typeof(ComDungeonUnitMap),
				typeof(RectTransform)
			});
			Utility.AttachTo(gameObject, this.mRoot, false);
			ComDungeonUnitMap component3 = gameObject.GetComponent<ComDungeonUnitMap>();
			component3.mImageList = this.mImageList;
			component3.mSizeUnit = this.mSizeUnit;
			component3.mStartSprite = this.mStartSprite;
			component3.mBossSprite = this.mBossSprite;
			component3.mIsPlay = this.mIsPlay;
			component3.SetDungeonData(ddungeonMapUnitData.dungeon);
			this.mUnitMapList[i] = component3;
			RectTransform component4 = gameObject.GetComponent<RectTransform>();
			component4.anchoredPosition = new Vector2((float)(ddungeonMapUnitData.posx * this.mSizeUnit / 2), (float)(ddungeonMapUnitData.posy * this.mSizeUnit / 2));
		}
	}

	// Token: 0x06009534 RID: 38196 RVA: 0x001C1EA9 File Offset: 0x001C02A9
	private void Update()
	{
	}

	// Token: 0x04004C04 RID: 19460
	public bool mIsPlay;

	// Token: 0x04004C05 RID: 19461
	public int mOffset = 10;

	// Token: 0x04004C06 RID: 19462
	public int mSizeUnit = 100;

	// Token: 0x04004C07 RID: 19463
	public DDungeonMapData mMapdata;

	// Token: 0x04004C08 RID: 19464
	public Sprite mBackground;

	// Token: 0x04004C09 RID: 19465
	public Sprite mItemImage;

	// Token: 0x04004C0A RID: 19466
	public Sprite mBossSprite;

	// Token: 0x04004C0B RID: 19467
	public Sprite mStartSprite;

	// Token: 0x04004C0C RID: 19468
	public Sprite[] mImageList = new Sprite[9];

	// Token: 0x04004C0D RID: 19469
	private ComDungeonUnitMap[] mUnitMapList = new ComDungeonUnitMap[0];

	// Token: 0x04004C0E RID: 19470
	private GameObject mRoot;

	// Token: 0x04004C0F RID: 19471
	public int mDungeonID;
}
