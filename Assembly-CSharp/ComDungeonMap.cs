using System;
using System.Collections.Generic;
using GameClient;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000ED0 RID: 3792
[ExecuteInEditMode]
public class ComDungeonMap : MonoBehaviour
{
	// Token: 0x17001909 RID: 6409
	// (get) Token: 0x06009512 RID: 38162 RVA: 0x001C0586 File Offset: 0x001BE986
	private DungeonGraphicInfo[] dungeonGraphicInfoList
	{
		get
		{
			return this.mDungeonGraphicInfoList;
		}
	}

	// Token: 0x06009513 RID: 38163 RVA: 0x001C0590 File Offset: 0x001BE990
	private void _initBackground()
	{
		int num = Mathf.Max(4, (int)this.mFixedSize.x);
		int num2 = (int)this.mFixedSize.y;
		RectTransform component = base.gameObject.GetComponent<RectTransform>();
		component.sizeDelta = new Vector2((float)(num * this.mSizeUnit) + this.mDeltaFix.x * 2f, (float)(num2 * this.mSizeUnit) + this.mDeltaFix.y * 2f);
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
		component2.offsetMin = new Vector2(0f, (float)(-(float)this.mSizeUnit + 10));
		component2.offsetMax = new Vector2(0f, 0f);
		Image component3 = this.mRoot.GetComponent<Image>();
		component3.type = 1;
		component3.sprite = this.mBackRoundImage;
		component3.material = this.mBackRoundMaterial;
		component3.color = new Color(1f, 1f, 1f, 0.5f);
		if (null != this.mButton)
		{
			RectTransform component4 = this.mButton.GetComponent<RectTransform>();
			component4.anchorMin = new Vector2(1f, 1f);
			component4.anchorMax = new Vector2(1f, 1f);
			component4.offsetMin = new Vector2((float)(-(float)this.mSizeUnit / 2) - this.mDeltaFix.x, (float)(-(float)this.mSizeUnit / 2) - this.mDeltaFix.y);
			component4.offsetMax = new Vector2(0f, 0f);
			Image component5 = this.mButton.GetComponent<Image>();
			component5.type = 1;
			component5.sprite = this.mBackRoundImage;
			component5.material = this.mBackRoundMaterial;
			Button component6 = this.mButton.GetComponent<Button>();
			component6.onClick.RemoveAllListeners();
			component6.onClick.AddListener(delegate()
			{
				this.mRoot.SetActive(!this.mRoot.activeSelf);
			});
		}
	}

	// Token: 0x06009514 RID: 38164 RVA: 0x001C0818 File Offset: 0x001BEC18
	private string _getMapItemName(int x, int y)
	{
		return string.Format("{0},{1}", x, y);
	}

	// Token: 0x06009515 RID: 38165 RVA: 0x001C0830 File Offset: 0x001BEC30
	private int _getIndex(IDungeonConnectData item)
	{
		int num = 1;
		int num2 = 0;
		for (int i = 0; i < 4; i++)
		{
			if (item.GetIsConnect(i))
			{
				num2 += num;
			}
			num *= 2;
		}
		return num2;
	}

	// Token: 0x06009516 RID: 38166 RVA: 0x001C0868 File Offset: 0x001BEC68
	private Image _createTag(string name, Sprite sprite, GameObject root, float scale)
	{
		GameObject gameObject = new GameObject(name, new Type[]
		{
			typeof(Image)
		});
		Utility.AttachTo(gameObject, root, false);
		RectTransform component = gameObject.GetComponent<RectTransform>();
		component.offsetMin = new Vector2(-15f, -15f);
		component.offsetMax = new Vector2(15f, 15f);
		component.anchorMax = new Vector2(0.5f, 0.5f);
		component.anchorMin = new Vector2(0.5f, 0.5f);
		Image component2 = gameObject.GetComponent<Image>();
		component2.sprite = sprite;
		component2.SetNativeSize();
		component2.GetComponent<RectTransform>().localScale = Vector3.one * scale;
		return component2;
	}

	// Token: 0x06009517 RID: 38167 RVA: 0x001C0920 File Offset: 0x001BED20
	private void _loadDungeon()
	{
		if (null != this.mText)
		{
			DungeonID dungeonID = new DungeonID(DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonId);
			string arg = (dungeonID.prestoryID <= 0) ? ChapterUtility.GetHardString(dungeonID.diffID) : string.Empty;
			if (DataManager<ActivityDungeonDataManager>.GetInstance()._judgeDungeonIDIsRotteneterHell(dungeonID.dungeonID))
			{
				arg = "王者";
			}
			DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (tableItem.SubType == DungeonTable.eSubType.S_CITYMONSTER || tableItem.SubType == DungeonTable.eSubType.S_GUILD_DUNGEON)
				{
					arg = string.Empty;
				}
				else if (tableItem.SubType == DungeonTable.eSubType.S_WEEK_HELL || tableItem.SubType == DungeonTable.eSubType.S_WEEK_HELL_PER || tableItem.SubType == DungeonTable.eSubType.S_ANNIVERSARY_HARD || tableItem.SubType == DungeonTable.eSubType.S_ANNIVERSARY_HARD)
				{
					arg = "王者";
				}
				else if (tableItem.SubType == DungeonTable.eSubType.S_RAID_DUNGEON)
				{
					int num = DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonId / 1000;
					int num2 = num % 10;
					if (num2 == 1)
					{
						arg = "噩梦";
					}
				}
			}
			this.mText.text = string.Format("<color=#14c5ff>{0}</color>{1}", arg, this.mDungeonData.GetName());
		}
		this.mDungeonGraphicInfoList = new DungeonGraphicInfo[this.mDungeonData.GetAreaConnectListLength()];
		for (int i = 0; i < this.mDungeonData.GetAreaConnectListLength(); i++)
		{
			IDungeonConnectData areaConnectList = this.mDungeonData.GetAreaConnectList(i);
			int positionX = areaConnectList.GetPositionX();
			int num3 = this.mDungeonData.GetHeight() - (areaConnectList.GetPositionY() + 1);
			GameObject gameObject = new GameObject(this._getMapItemName(areaConnectList.GetPositionX(), areaConnectList.GetPositionY()), new Type[]
			{
				typeof(Image)
			});
			GameObject gameObject2 = new GameObject(this._getMapItemName(areaConnectList.GetPositionX(), areaConnectList.GetPositionY()), new Type[]
			{
				typeof(Image)
			});
			Utility.AttachTo(gameObject2, gameObject, false);
			Utility.AttachTo(gameObject, this.mRoot, false);
			RectTransform component = gameObject.GetComponent<RectTransform>();
			component.pivot = Vector2.zero;
			component.anchorMin = Vector2.zero;
			component.anchorMax = Vector2.zero;
			int num4 = this.mSizeUnit - 8;
			component.offsetMin = new Vector2((float)(positionX * this.mSizeUnit) + this.mDeltaFix.x + 2f, (float)(num3 * this.mSizeUnit) + this.mDeltaFix.y + 2f) - this.mFixedOffset * (float)this.mSizeUnit;
			component.offsetMax = new Vector2((float)(positionX * this.mSizeUnit + this.mSizeUnit) + this.mDeltaFix.x - 2f, (float)(num3 * this.mSizeUnit + this.mSizeUnit) + this.mDeltaFix.y - 2f) - this.mFixedOffset * (float)this.mSizeUnit;
			RectTransform component2 = gameObject2.GetComponent<RectTransform>();
			component2.pivot = Vector2.one * 0.5f;
			component2.anchorMin = Vector2.zero;
			component2.anchorMax = Vector2.one;
			component2.offsetMin = Vector2.zero;
			component2.offsetMax = Vector2.zero;
			Image component3 = gameObject.GetComponent<Image>();
			component3.sprite = this.mItemImage;
			component3.material = this.mItemMaterial;
			component3.type = 0;
			Image component4 = gameObject2.GetComponent<Image>();
			component4.type = 0;
			component4.sprite = this.mItemImage;
			component4.material = this.mItemMaterial;
			DungeonGraphicInfo dungeonGraphicInfo = this.mDungeonGraphicInfoList[i];
			dungeonGraphicInfo.image = component4;
			dungeonGraphicInfo.imageFg = this._createTag("imageFg", null, gameObject, 1f);
			dungeonGraphicInfo.imageBoard = component3;
			dungeonGraphicInfo.x = areaConnectList.GetPositionX();
			dungeonGraphicInfo.y = areaConnectList.GetPositionY();
			dungeonGraphicInfo.state = DungeonGraphicInfo.State.DS_CLOSE;
			dungeonGraphicInfo.visited = false;
			dungeonGraphicInfo.id = areaConnectList.GetId();
			dungeonGraphicInfo.type = eDungeonGraphicType.Normal;
			dungeonGraphicInfo.imageBoard.enabled = false;
			dungeonGraphicInfo.imageFg.enabled = false;
			dungeonGraphicInfo.image.enabled = false;
			dungeonGraphicInfo.image.sprite = this.mImageList[0];
			dungeonGraphicInfo.image.material = this.mImageMaterial;
			if (areaConnectList.IsStart())
			{
				dungeonGraphicInfo.imageBoard.enabled = true;
				dungeonGraphicInfo.imageFg.enabled = true;
				dungeonGraphicInfo.imageFg.sprite = this.mStartSprite;
				dungeonGraphicInfo.imageFg.material = this.mStartMaterial;
				dungeonGraphicInfo.image.enabled = true;
				dungeonGraphicInfo.image.sprite = this.mImageList[this._getIndex(areaConnectList)];
				dungeonGraphicInfo.image.material = this.mImageMaterial;
				dungeonGraphicInfo.state = DungeonGraphicInfo.State.DS_IN;
				dungeonGraphicInfo.visited = true;
				dungeonGraphicInfo.type = eDungeonGraphicType.Start;
			}
			if (areaConnectList.IsBoss())
			{
				dungeonGraphicInfo.imageBoard.enabled = true;
				dungeonGraphicInfo.imageFg.enabled = true;
				dungeonGraphicInfo.imageFg.sprite = this.mBossSprite;
				dungeonGraphicInfo.imageFg.material = this.mBossMaterial;
				dungeonGraphicInfo.type = eDungeonGraphicType.Boss;
			}
			if (areaConnectList.IsEgg())
			{
				gameObject.CustomActive(false);
				this.eggRoom = gameObject;
			}
			this.mDungeonGraphicInfoList[i] = dungeonGraphicInfo;
		}
		this.UpdateDungoenGraphicInfo();
	}

	// Token: 0x06009518 RID: 38168 RVA: 0x001C0EE2 File Offset: 0x001BF2E2
	public void SetEggRoomState(bool flag)
	{
		if (this.eggRoom != null)
		{
			this.eggRoom.CustomActive(flag);
		}
	}

	// Token: 0x06009519 RID: 38169 RVA: 0x001C0F04 File Offset: 0x001BF304
	public void SetDropProgress(uint index)
	{
		if (this.mDungeonGraphicInfoList == null)
		{
			return;
		}
		for (int i = 0; i < this.mDungeonGraphicInfoList.Length - 1; i++)
		{
			bool flag = (index & 1U) == 0U;
			index >>= 1;
			DungeonGraphicInfo dungeonGraphicInfo = this.mDungeonGraphicInfoList[i];
			if (flag)
			{
				dungeonGraphicInfo.imageFg.enabled = true;
				dungeonGraphicInfo.imageFg.sprite = this.mChestSprite;
				dungeonGraphicInfo.imageFg.material = null;
				dungeonGraphicInfo.type = eDungeonGraphicType.Chest;
			}
			else
			{
				dungeonGraphicInfo.imageFg.enabled = false;
				dungeonGraphicInfo.type = eDungeonGraphicType.Normal;
			}
			this.mDungeonGraphicInfoList[i] = dungeonGraphicInfo;
		}
	}

	// Token: 0x0600951A RID: 38170 RVA: 0x001C0FBC File Offset: 0x001BF3BC
	public void SetHell(DungeonHellMode mode, int id)
	{
		Sprite sprite = null;
		this.mHellMode = mode;
		switch (mode)
		{
		case DungeonHellMode.Normal:
			sprite = this.mHellSprite[0];
			break;
		case DungeonHellMode.Hard:
			sprite = this.mHellSprite[1];
			break;
		case DungeonHellMode.Hard_Ultimate:
			sprite = this.mHellSprite[2];
			break;
		}
		for (int i = 0; i < this.mDungeonGraphicInfoList.Length; i++)
		{
			DungeonGraphicInfo dungeonGraphicInfo = this.mDungeonGraphicInfoList[i];
			if (dungeonGraphicInfo.id == id)
			{
				dungeonGraphicInfo.imageFg.sprite = sprite;
				dungeonGraphicInfo.imageFg.material = this.mHellSpriteMaterial;
				dungeonGraphicInfo.imageFg.enabled = true;
				dungeonGraphicInfo.imageBoard.enabled = true;
				dungeonGraphicInfo.type = eDungeonGraphicType.Hell;
				this.mDungeonGraphicInfoList[i] = dungeonGraphicInfo;
				if (mode == DungeonHellMode.Hard_Ultimate)
				{
					if (dungeonGraphicInfo.imageFg.gameObject != null)
					{
						RectTransform component = dungeonGraphicInfo.imageFg.gameObject.GetComponent<RectTransform>();
						if (component != null)
						{
							component.offsetMin = new Vector2(-20f, -20f);
							component.offsetMax = new Vector2(20f, 20f);
						}
					}
					dungeonGraphicInfo.type = eDungeonGraphicType.Hell;
				}
				break;
			}
		}
	}

	// Token: 0x0600951B RID: 38171 RVA: 0x001C111C File Offset: 0x001BF51C
	public void ShowHellEffect()
	{
		for (int i = 0; i < this.mDungeonGraphicInfoList.Length; i++)
		{
			DungeonGraphicInfo dungeonGraphicInfo = this.mDungeonGraphicInfoList[i];
			if (dungeonGraphicInfo.type == eDungeonGraphicType.Hell)
			{
				if (dungeonGraphicInfo.imageFg.gameObject != null && dungeonGraphicInfo.imageFg.gameObject.transform != null && dungeonGraphicInfo.imageFg.gameObject.transform.parent != null && dungeonGraphicInfo.imageFg.gameObject.transform.parent.gameObject != null)
				{
					this.mHellEffect = Singleton<AssetLoader>.instance.LoadResAsGameObject("Effects/UI/Prefab/EffUI_Shenyuan/Prefab/EffUI_Shenyuan_02", true, 0U);
					if (this.mHellEffect != null)
					{
						this.mHellEffect.transform.localPosition = new Vector3(23f, 23f, 0f);
						Utility.AttachTo(this.mHellEffect, dungeonGraphicInfo.imageFg.gameObject.transform.parent.gameObject, false);
					}
				}
				break;
			}
		}
	}

	// Token: 0x0600951C RID: 38172 RVA: 0x001C1254 File Offset: 0x001BF654
	public void InitTreasureMapDungeonUI()
	{
		int width = 5;
		int height = 5;
		this.ResizeMap(width, height);
	}

	// Token: 0x0600951D RID: 38173 RVA: 0x001C1270 File Offset: 0x001BF670
	public void ResizeMap(int width, int height)
	{
		if (base.gameObject.IsNull())
		{
			return;
		}
		RectTransform component = base.gameObject.GetComponent<RectTransform>();
		component.sizeDelta = new Vector2((float)(width * this.mSizeUnit) + this.mDeltaFix.x * 2f, (float)(height * this.mSizeUnit) + this.mDeltaFix.y * 2f);
		if (this.mTextRoot.IsNull())
		{
			return;
		}
		this.mTextRoot.SetActive(false);
	}

	// Token: 0x0600951E RID: 38174 RVA: 0x001C12F8 File Offset: 0x001BF6F8
	private void _fixDungeonData(IDungeonData data)
	{
		int weidth = data.GetWeidth();
		int height = data.GetHeight();
		IDungeonConnectData areaConnectList = data.GetAreaConnectList(0);
		int num = areaConnectList.GetPositionX();
		int num2 = areaConnectList.GetPositionY();
		int num3 = areaConnectList.GetPositionX();
		int num4 = areaConnectList.GetPositionY();
		for (int i = 0; i < data.GetAreaConnectListLength(); i++)
		{
			IDungeonConnectData areaConnectList2 = data.GetAreaConnectList(i);
			num = Math.Min(num, areaConnectList2.GetPositionX());
			num2 = Math.Min(num2, areaConnectList2.GetPositionY());
			num3 = Math.Max(num3, areaConnectList2.GetPositionX());
			num4 = Math.Max(num4, areaConnectList2.GetPositionY());
		}
		int num5 = num3 - num + 1;
		int num6 = num4 - num2 + 1;
		this.mFixedSize = new Vector2((float)num5, (float)num6);
		this.mFixedOffset = new Vector2((float)num, (float)(height - num4 - 1));
	}

	// Token: 0x0600951F RID: 38175 RVA: 0x001C13D3 File Offset: 0x001BF7D3
	public void SetDungeonData(IDungeonData scene)
	{
		this.mDungeonData = scene;
		this._fixDungeonData(scene);
		this._initBackground();
		this._loadDungeon();
		this._initData();
		this._updateText();
	}

	// Token: 0x06009520 RID: 38176 RVA: 0x001C13FC File Offset: 0x001BF7FC
	private void OnDestroy()
	{
		if (this.mDungeonData != null)
		{
			for (int i = 0; i < this.mDungeonData.GetAreaConnectListLength(); i++)
			{
			}
			this.mDungeonData = null;
		}
	}

	// Token: 0x06009521 RID: 38177 RVA: 0x001C1438 File Offset: 0x001BF838
	private void _updateText()
	{
		if (null != this.mTextGold)
		{
			this.mTextGold.text = "0";
		}
		if (null != this.mTextBox)
		{
			this.mTextBox.text = "0";
		}
	}

	// Token: 0x06009522 RID: 38178 RVA: 0x001C1488 File Offset: 0x001BF888
	public void UpdateDungoenGraphicInfo()
	{
		this.mDungoenBlinkList.Clear();
		for (int i = 0; i < this.mDungeonGraphicInfoList.Length; i++)
		{
			DungeonGraphicInfo dungeonGraphicInfo = this.mDungeonGraphicInfoList[i];
			DungeonGraphicInfo.State state = dungeonGraphicInfo.state;
			if (state != DungeonGraphicInfo.State.DS_IN)
			{
				if (state != DungeonGraphicInfo.State.DS_CLOSE)
				{
					if (state == DungeonGraphicInfo.State.DS_OPEN)
					{
						if (dungeonGraphicInfo.image)
						{
							this.mDungoenBlinkList.Add(dungeonGraphicInfo.image);
						}
						if (dungeonGraphicInfo.imageBoard)
						{
							this.mDungoenBlinkList.Add(dungeonGraphicInfo.imageBoard);
						}
					}
				}
				else
				{
					if (dungeonGraphicInfo.image)
					{
						dungeonGraphicInfo.image.color = this.mDarkColor;
					}
					if (dungeonGraphicInfo.imageBoard)
					{
						dungeonGraphicInfo.imageBoard.color = this.mDarkColor;
					}
				}
			}
			else
			{
				if (dungeonGraphicInfo.image)
				{
					dungeonGraphicInfo.image.color = Color.white;
				}
				if (dungeonGraphicInfo.imageBoard)
				{
					dungeonGraphicInfo.imageBoard.color = Color.white;
				}
			}
		}
	}

	// Token: 0x06009523 RID: 38179 RVA: 0x001C15CC File Offset: 0x001BF9CC
	private void _initData()
	{
		this.mGlodCount = 0;
		this.mBoxCount = 0;
	}

	// Token: 0x06009524 RID: 38180 RVA: 0x001C15DC File Offset: 0x001BF9DC
	public void AddGlod(int glod)
	{
		this.mGlodCount += glod;
		if (this.mTextGold != null)
		{
			this.mTextGold.text = this.mGlodCount.ToString();
		}
		GameObject go = Singleton<AssetLoader>.instance.LoadResAsGameObject("Effects/Scene_effects/EffectUI/EffUI_huoqu_guo", true, 0U);
		Utility.AttachTo(go, this.mTextGoldRoot, false);
	}

	// Token: 0x06009525 RID: 38181 RVA: 0x001C1644 File Offset: 0x001BFA44
	public void AddBox(int box)
	{
		this.mBoxCount += box;
		if (this.mTextBox != null)
		{
			this.mTextBox.text = this.mBoxCount.ToString();
		}
		GameObject go = Singleton<AssetLoader>.instance.LoadResAsGameObject("Effects/Scene_effects/EffectUI/EffUI_huoqu_guo", true, 0U);
		Utility.AttachTo(go, this.mTextBoxRoot, false);
	}

	// Token: 0x06009526 RID: 38182 RVA: 0x001C16AC File Offset: 0x001BFAAC
	private IDungeonConnectData _getConnect(int x, int y)
	{
		for (int i = 0; i < this.mDungeonData.GetAreaConnectListLength(); i++)
		{
			IDungeonConnectData areaConnectList = this.mDungeonData.GetAreaConnectList(i);
			if (areaConnectList.GetPositionX() == x && areaConnectList.GetPositionY() == y)
			{
				return areaConnectList;
			}
		}
		return null;
	}

	// Token: 0x06009527 RID: 38183 RVA: 0x001C1700 File Offset: 0x001BFB00
	private DungeonGraphicInfo _getDungeonGraphicInfo(int x, int y)
	{
		for (int i = 0; i < this.mDungeonGraphicInfoList.Length; i++)
		{
			if (this.mDungeonGraphicInfoList[i].x == x && this.mDungeonGraphicInfoList[i].y == y)
			{
				return this.mDungeonGraphicInfoList[i];
			}
		}
		return default(DungeonGraphicInfo);
	}

	// Token: 0x06009528 RID: 38184 RVA: 0x001C1770 File Offset: 0x001BFB70
	public void SetStartPosition(int x, int y)
	{
		for (int i = 0; i < this.mDungeonGraphicInfoList.Length; i++)
		{
			DungeonGraphicInfo dungeonGraphicInfo = this.mDungeonGraphicInfoList[i];
			dungeonGraphicInfo.state = DungeonGraphicInfo.State.DS_CLOSE;
			if (dungeonGraphicInfo.x == this.mCurrentX && dungeonGraphicInfo.y == this.mCurrentY)
			{
				eDungeonGraphicType type = dungeonGraphicInfo.type;
				if (type == eDungeonGraphicType.Start || type == eDungeonGraphicType.Normal)
				{
					dungeonGraphicInfo.imageFg.enabled = false;
				}
			}
			if (dungeonGraphicInfo.x == x && dungeonGraphicInfo.y == y)
			{
				dungeonGraphicInfo.image.enabled = true;
				dungeonGraphicInfo.image.sprite = this.mImageList[this._getIndex(this._getConnect(x, y))];
				dungeonGraphicInfo.image.material = this.mImageMaterial;
				dungeonGraphicInfo.imageBoard.enabled = true;
				dungeonGraphicInfo.state = DungeonGraphicInfo.State.DS_IN;
				dungeonGraphicInfo.imageFg.enabled = true;
				dungeonGraphicInfo.visited = true;
				eDungeonGraphicType type2 = dungeonGraphicInfo.type;
				if (type2 == eDungeonGraphicType.Start || type2 == eDungeonGraphicType.Normal)
				{
					dungeonGraphicInfo.imageFg.sprite = this.mStartSprite;
					dungeonGraphicInfo.imageFg.material = this.mStartMaterial;
				}
			}
			this.mDungeonGraphicInfoList[i] = dungeonGraphicInfo;
		}
		this.UpdateDungoenGraphicInfo();
		this.mCurrentX = x;
		this.mCurrentY = y;
	}

	// Token: 0x06009529 RID: 38185 RVA: 0x001C18F0 File Offset: 0x001BFCF0
	public void SetOpenPosition(int x, int y)
	{
		for (int i = 0; i < this.mDungeonGraphicInfoList.Length; i++)
		{
			DungeonGraphicInfo dungeonGraphicInfo = this.mDungeonGraphicInfoList[i];
			DungeonGraphicInfo.State state = DungeonGraphicInfo.State.DS_CLOSE;
			if (dungeonGraphicInfo.x == x && dungeonGraphicInfo.y == y)
			{
				state = DungeonGraphicInfo.State.DS_IN;
			}
			dungeonGraphicInfo.state = state;
			this.mDungeonGraphicInfoList[i] = dungeonGraphicInfo;
		}
		this.ChangeLinkMapState(x, y, DungeonGraphicInfo.State.DS_OPEN);
		this.UpdateDungoenGraphicInfo();
	}

	// Token: 0x0600952A RID: 38186 RVA: 0x001C1970 File Offset: 0x001BFD70
	public void ChangeLinkMapState(int x, int y, DungeonGraphicInfo.State state)
	{
		int num = Array.FindIndex<DungeonGraphicInfo>(this.mDungeonGraphicInfoList, (DungeonGraphicInfo v) => v.x == x && v.y == y);
		if (num >= 0)
		{
			IDungeonConnectData areaConnectList = this.mDungeonData.GetAreaConnectList(num);
			for (int i = 0; i < 4; i++)
			{
				if (areaConnectList.GetIsConnect(i))
				{
					int num2;
					this.mDungeonData.GetSideByType(x, y, (TransportDoorType)i, out num2);
					if (num2 >= 0)
					{
						DungeonGraphicInfo dungeonGraphicInfo = this.mDungeonGraphicInfoList[num2];
						dungeonGraphicInfo.state = state;
						dungeonGraphicInfo.image.enabled = true;
						dungeonGraphicInfo.imageBoard.enabled = true;
						this.mDungeonGraphicInfoList[num2] = dungeonGraphicInfo;
					}
				}
			}
		}
	}

	// Token: 0x0600952B RID: 38187 RVA: 0x001C1A48 File Offset: 0x001BFE48
	private void Update()
	{
		if (this.mDungoenBlinkList.Count > 0)
		{
			float num = Mathf.Repeat(Time.realtimeSinceStartup, this.mBlinkTime) / this.mBlinkTime;
			float num2 = this.mBlinkCurve.Evaluate(num);
			Color color = Color.Lerp(Color.white, this.mDarkColor, num2);
			for (int i = 0; i < this.mDungoenBlinkList.Count; i++)
			{
				Image image = this.mDungoenBlinkList[i];
				image.color = color;
			}
		}
		if (this.mHellEffect == null)
		{
			return;
		}
		this.mTimeStamp += Time.deltaTime;
		if (this.mTimeStamp > 4f)
		{
			Object.Destroy(this.mHellEffect);
			this.mHellEffect = null;
		}
	}

	// Token: 0x04004BD8 RID: 19416
	public int mSizeUnit = 100;

	// Token: 0x04004BD9 RID: 19417
	public Vector2 mDeltaFix;

	// Token: 0x04004BDA RID: 19418
	public Vector2 mTextFix;

	// Token: 0x04004BDB RID: 19419
	public Sprite mBackRoundImage;

	// Token: 0x04004BDC RID: 19420
	public Material mBackRoundMaterial;

	// Token: 0x04004BDD RID: 19421
	public Sprite mItemImage;

	// Token: 0x04004BDE RID: 19422
	public Material mItemMaterial;

	// Token: 0x04004BDF RID: 19423
	public Sprite mBossSprite;

	// Token: 0x04004BE0 RID: 19424
	public Material mBossMaterial;

	// Token: 0x04004BE1 RID: 19425
	public Sprite mStartSprite;

	// Token: 0x04004BE2 RID: 19426
	public Material mStartMaterial;

	// Token: 0x04004BE3 RID: 19427
	public Sprite mChestSprite;

	// Token: 0x04004BE4 RID: 19428
	private const int kMaxHell = 3;

	// Token: 0x04004BE5 RID: 19429
	public Sprite[] mHellSprite = new Sprite[3];

	// Token: 0x04004BE6 RID: 19430
	public Material mHellSpriteMaterial;

	// Token: 0x04004BE7 RID: 19431
	[Space]
	public Sprite[] mImageList = new Sprite[9];

	// Token: 0x04004BE8 RID: 19432
	public Material mImageMaterial;

	// Token: 0x04004BE9 RID: 19433
	public IDungeonData mDungeonData;

	// Token: 0x04004BEA RID: 19434
	private GameObject mRoot;

	// Token: 0x04004BEB RID: 19435
	private GameObject eggRoom;

	// Token: 0x04004BEC RID: 19436
	public Text mText;

	// Token: 0x04004BED RID: 19437
	public GameObject mButton;

	// Token: 0x04004BEE RID: 19438
	public GameObject mTextRoot;

	// Token: 0x04004BEF RID: 19439
	[Header("地图开启动画设置")]
	public Color mDarkColor;

	// Token: 0x04004BF0 RID: 19440
	public AnimationCurve mBlinkCurve;

	// Token: 0x04004BF1 RID: 19441
	public float mBlinkTime;

	// Token: 0x04004BF2 RID: 19442
	[Space]
	public Text mTextGold;

	// Token: 0x04004BF3 RID: 19443
	public Text mTextBox;

	// Token: 0x04004BF4 RID: 19444
	public GameObject mTextBoxRoot;

	// Token: 0x04004BF5 RID: 19445
	public GameObject mTextGoldRoot;

	// Token: 0x04004BF6 RID: 19446
	private int mGlodCount;

	// Token: 0x04004BF7 RID: 19447
	private int mBoxCount;

	// Token: 0x04004BF8 RID: 19448
	private DungeonGraphicInfo[] mDungeonGraphicInfoList;

	// Token: 0x04004BF9 RID: 19449
	private List<Image> mDungoenBlinkList = new List<Image>();

	// Token: 0x04004BFA RID: 19450
	private int mCurrentX = -1;

	// Token: 0x04004BFB RID: 19451
	private int mCurrentY = -1;

	// Token: 0x04004BFC RID: 19452
	private GameObject mHellEffect;

	// Token: 0x04004BFD RID: 19453
	private float mTimeStamp;

	// Token: 0x04004BFE RID: 19454
	private DungeonHellMode mHellMode;

	// Token: 0x04004BFF RID: 19455
	private Vector2 mFixedOffset = Vector2.zero;

	// Token: 0x04004C00 RID: 19456
	private Vector2 mFixedSize = Vector2.zero;

	// Token: 0x04004C01 RID: 19457
	public bool mIsPlay = true;

	// Token: 0x02000ED1 RID: 3793
	private class Range
	{
		// Token: 0x04004C02 RID: 19458
		private int min;

		// Token: 0x04004C03 RID: 19459
		private int max;
	}
}
