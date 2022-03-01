using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000ED3 RID: 3795
[ExecuteInEditMode]
public class ComDungeonUnitMap : MonoBehaviour
{
	// Token: 0x06009536 RID: 38198 RVA: 0x001C1EFC File Offset: 0x001C02FC
	private void _initBackground()
	{
		int weidth = this.mDungeonData.GetWeidth();
		int height = this.mDungeonData.GetHeight();
		RectTransform component = base.gameObject.GetComponent<RectTransform>();
		component.sizeDelta = new Vector2((float)(weidth * this.mSizeUnit), (float)(height * this.mSizeUnit));
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
		RectTransform component2 = this.mRoot.GetComponent<RectTransform>();
		component2.anchorMin = new Vector2(0f, 0f);
		component2.anchorMax = new Vector2(1f, 1f);
		component2.offsetMin = Vector2.zero;
		component2.offsetMax = Vector2.zero;
		component2.anchoredPosition = new Vector2(0f, (float)(-(float)this.mSizeUnit));
		Image component3 = this.mRoot.GetComponent<Image>();
		component3.type = 1;
		component3.color = Color.clear;
	}

	// Token: 0x06009537 RID: 38199 RVA: 0x001C2030 File Offset: 0x001C0430
	private string _getMapItemName(int x, int y)
	{
		return string.Format("{0},{1}", x, y);
	}

	// Token: 0x06009538 RID: 38200 RVA: 0x001C2048 File Offset: 0x001C0448
	private void _loadDungeon()
	{
		this.mImageObjectList = new Image[this.mDungeonData.GetAreaConnectListLength()];
		for (int i = 0; i < this.mDungeonData.GetAreaConnectListLength(); i++)
		{
			IDungeonConnectData areaConnectList = this.mDungeonData.GetAreaConnectList(i);
			int positionX = areaConnectList.GetPositionX();
			int num = this.mDungeonData.GetHeight() - (areaConnectList.GetPositionY() + 1);
			GameObject gameObject = new GameObject(this._getMapItemName(areaConnectList.GetPositionX(), areaConnectList.GetPositionY()), new Type[]
			{
				typeof(Image)
			});
			Utility.AttachTo(gameObject, this.mRoot, false);
			RectTransform component = gameObject.GetComponent<RectTransform>();
			component.pivot = Vector2.zero;
			component.anchorMin = Vector2.zero;
			component.anchorMax = Vector2.zero;
			component.offsetMin = new Vector2((float)(positionX * this.mSizeUnit), (float)(num * this.mSizeUnit));
			component.offsetMax = new Vector2((float)(positionX * this.mSizeUnit + this.mSizeUnit), (float)(num * this.mSizeUnit + this.mSizeUnit));
			Image component2 = gameObject.GetComponent<Image>();
			component2.type = 0;
			component2.sprite = this.mItemImage;
			if (areaConnectList.IsStart())
			{
				this.mStartObject = new GameObject("start", new Type[]
				{
					typeof(Image)
				});
				Utility.AttachTo(this.mStartObject, gameObject, false);
				RectTransform component3 = this.mStartObject.GetComponent<RectTransform>();
				component3.offsetMin = new Vector2(-15f, -15f);
				component3.offsetMax = new Vector2(15f, 15f);
				component3.anchorMax = new Vector2(0.5f, 0.5f);
				component3.anchorMin = new Vector2(0.5f, 0.5f);
				Image component4 = this.mStartObject.GetComponent<Image>();
				component4.sprite = this.mStartSprite;
			}
			if (areaConnectList.IsBoss())
			{
				this.mBossObject = new GameObject("boss", new Type[]
				{
					typeof(Image)
				});
				Utility.AttachTo(this.mBossObject, gameObject, false);
				RectTransform component5 = this.mBossObject.GetComponent<RectTransform>();
				component5.offsetMin = new Vector2(-15f, -15f);
				component5.offsetMax = new Vector2(15f, 15f);
				component5.anchorMax = new Vector2(0.5f, 0.5f);
				component5.anchorMin = new Vector2(0.5f, 0.5f);
				Image component6 = this.mBossObject.GetComponent<Image>();
				component6.sprite = this.mBossSprite;
				this.mBossX = areaConnectList.GetPositionX();
				this.mBossY = areaConnectList.GetPositionY();
			}
			int num2 = 1;
			int num3 = 0;
			for (int j = 0; j < 4; j++)
			{
				if (areaConnectList.GetIsConnect(j))
				{
					num3 += num2;
				}
				num2 *= 2;
			}
			component2.sprite = this.mImageList[num3];
			this.mImageObjectList[i] = component2;
		}
	}

	// Token: 0x06009539 RID: 38201 RVA: 0x001C2360 File Offset: 0x001C0760
	public void SetActive(bool active)
	{
		if (!this.mInited)
		{
			return;
		}
		if (this.mActived != active)
		{
			this.mActived = active;
			this.mStartObject.CustomActive(this.mActived);
			this.mBossObject.CustomActive(this.mActived);
			for (int i = 0; i < this.mImageObjectList.Length; i++)
			{
				Image image = this.mImageObjectList[i];
				if (this.mActived)
				{
					image.color = Color.white;
				}
				else
				{
					image.color = Color.grey;
				}
			}
		}
	}

	// Token: 0x0600953A RID: 38202 RVA: 0x001C23F6 File Offset: 0x001C07F6
	public void SetDungeonData(IDungeonData scene)
	{
		if (scene == null)
		{
			return;
		}
		this.mDungeonData = scene;
		this._initBackground();
		this._loadDungeon();
		this._initData();
		this.mInited = true;
	}

	// Token: 0x0600953B RID: 38203 RVA: 0x001C241F File Offset: 0x001C081F
	private void _initData()
	{
	}

	// Token: 0x0600953C RID: 38204 RVA: 0x001C2424 File Offset: 0x001C0824
	public void SetStartPosition(int x, int y)
	{
		if (!this.mInited)
		{
			return;
		}
		if (x == this.mBossX && y == this.mBossY && this.mBossX != -1 && this.mBossY != -1)
		{
			this.mStartObject.SetActive(false);
		}
		else
		{
			GameObject gameObject = Utility.FindGameObject(this.mRoot, this._getMapItemName(x, y), true);
			if (gameObject != null)
			{
				Utility.AttachTo(this.mStartObject, gameObject, false);
			}
		}
	}

	// Token: 0x0600953D RID: 38205 RVA: 0x001C24AC File Offset: 0x001C08AC
	private void Update()
	{
	}

	// Token: 0x04004C10 RID: 19472
	public int mSizeUnit = 100;

	// Token: 0x04004C11 RID: 19473
	public Sprite mItemImage;

	// Token: 0x04004C12 RID: 19474
	public Sprite mBossSprite;

	// Token: 0x04004C13 RID: 19475
	public Sprite mStartSprite;

	// Token: 0x04004C14 RID: 19476
	public Sprite[] mImageList = new Sprite[9];

	// Token: 0x04004C15 RID: 19477
	public bool mIsPlay = true;

	// Token: 0x04004C16 RID: 19478
	public IDungeonData mDungeonData;

	// Token: 0x04004C17 RID: 19479
	private GameObject mRoot;

	// Token: 0x04004C18 RID: 19480
	private int mBossX = -1;

	// Token: 0x04004C19 RID: 19481
	private int mBossY = -1;

	// Token: 0x04004C1A RID: 19482
	private bool mInited;

	// Token: 0x04004C1B RID: 19483
	private GameObject mStartObject;

	// Token: 0x04004C1C RID: 19484
	private GameObject mBossObject;

	// Token: 0x04004C1D RID: 19485
	private Image[] mImageObjectList = new Image[0];

	// Token: 0x04004C1E RID: 19486
	private bool mActived = true;
}
