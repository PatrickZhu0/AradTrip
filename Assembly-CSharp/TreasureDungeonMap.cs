using System;
using System.Collections.Generic;
using GameClient;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000F92 RID: 3986
public class TreasureDungeonMap : MonoBehaviour
{
	// Token: 0x06009A29 RID: 39465 RVA: 0x001DADC4 File Offset: 0x001D91C4
	public TreasureDungeonMap()
	{
		int[][] array = new int[16][];
		array[0] = new int[2];
		int num = 1;
		int[] array2 = new int[2];
		array2[0] = 1;
		array[num] = array2;
		array[2] = new int[]
		{
			1,
			90
		};
		int num2 = 3;
		int[] array3 = new int[2];
		array3[0] = 2;
		array[num2] = array3;
		array[4] = new int[]
		{
			1,
			180
		};
		int num3 = 5;
		int[] array4 = new int[2];
		array4[0] = 3;
		array[num3] = array4;
		array[6] = new int[]
		{
			2,
			90
		};
		array[7] = new int[]
		{
			4,
			90
		};
		array[8] = new int[]
		{
			1,
			270
		};
		array[9] = new int[]
		{
			2,
			270
		};
		array[10] = new int[]
		{
			3,
			270
		};
		int num4 = 11;
		int[] array5 = new int[2];
		array5[0] = 4;
		array[num4] = array5;
		array[12] = new int[]
		{
			2,
			180
		};
		array[13] = new int[]
		{
			4,
			270
		};
		array[14] = new int[]
		{
			4,
			180
		};
		int num5 = 15;
		int[] array6 = new int[2];
		array6[0] = 5;
		array[num5] = array6;
		this.mapSpriteIndex = array;
		this.mCurrentBossX = -1;
		this.mCurrentBossY = -1;
		this.mFixedOffset = Vector2.zero;
		this.mFixedSize = Vector2.zero;
		this.mMapSizeEventParam = new TreasureDungeonMap.UITreasureEventParam();
		this.ClearFgImagePosList = new List<Vector2>();
		base..ctor();
	}

	// Token: 0x06009A2A RID: 39466 RVA: 0x001DAFBC File Offset: 0x001D93BC
	public void SetViewPortData(int playerPosX, int playerPosY)
	{
		int num = ((int)this.viewPortData.x - 1) / 2;
		int num2 = ((int)this.viewPortData.y - 1) / 2;
		int num3 = playerPosX - num;
		int num4 = playerPosY - num2;
		int num5 = playerPosX + num;
		int num6 = playerPosY + num2;
		if (num3 < this.minX)
		{
			num3 = this.minX;
			num5 = this.minX + (int)this.viewPortData.x - 1;
		}
		if (num4 < this.minY)
		{
			num4 = this.minY;
			num6 = this.minY + (int)this.viewPortData.y - 1;
		}
		if (num5 > this.maxX)
		{
			num5 = this.maxX;
			num3 = num5 - (int)this.viewPortData.x + 1;
		}
		if (num6 > this.maxY)
		{
			num6 = this.maxY;
			num4 = num6 - (int)this.viewPortData.y + 1;
		}
		for (int i = num3; i <= num5; i++)
		{
			for (int j = num4; j <= num6; j++)
			{
				this.SetRoomState(i, j, num3, num4);
			}
		}
	}

	// Token: 0x06009A2B RID: 39467 RVA: 0x001DB0DC File Offset: 0x001D94DC
	private void SetRoomState(int x, int y, int startX, int startY)
	{
		int num = this.FindRoomGrahpicIndex(this.mSmallMapGraphicInfoList, x - startX + 1, y - startY + 1);
		int num2 = this.FindRoomGrahpicIndex(this.mDungeonGraphicInfoList, x, y);
		if (num >= 0)
		{
			if (num2 >= 0)
			{
				this.mSmallMapGraphicInfoList[num].CopyRoomState(this.mDungeonGraphicInfoList[num2]);
			}
			else
			{
				this.mSmallMapGraphicInfoList[num].Hide();
			}
		}
	}

	// Token: 0x06009A2C RID: 39468 RVA: 0x001DB158 File Offset: 0x001D9558
	private int FindRoomGrahpicIndex(TreasureDungeonMap.RoomInfo[] list, int x, int y)
	{
		for (int i = 0; i < list.Length; i++)
		{
			if (list[i].x == x && list[i].y == y)
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x06009A2D RID: 39469 RVA: 0x001DB1A0 File Offset: 0x001D95A0
	private string _getMapItemName(int x, int y)
	{
		return string.Format("{0},{1}", x, y);
	}

	// Token: 0x06009A2E RID: 39470 RVA: 0x001DB1B8 File Offset: 0x001D95B8
	private int _getIndex(IDungeonConnectData item)
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			num *= 2;
			if (item.GetIsConnect(i))
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x06009A2F RID: 39471 RVA: 0x001DB1F0 File Offset: 0x001D95F0
	private Image _createTag(string name, Sprite sprite, GameObject root, float scale)
	{
		GameObject gameObject = new GameObject(name, new Type[]
		{
			typeof(Image)
		});
		Utility.AttachTo(gameObject, root, false);
		RectTransform component = gameObject.GetComponent<RectTransform>();
		component.offsetMin = new Vector2(-23f, -23f);
		component.offsetMax = new Vector2(23f, 23f);
		component.anchorMax = new Vector2(0.5f, 0.5f);
		component.anchorMin = new Vector2(0.5f, 0.5f);
		Image component2 = gameObject.GetComponent<Image>();
		component2.sprite = sprite;
		component2.SetNativeSize();
		component2.GetComponent<RectTransform>().localScale = Vector3.one * scale;
		return component2;
	}

	// Token: 0x06009A30 RID: 39472 RVA: 0x001DB2A8 File Offset: 0x001D96A8
	public void RefreshBoss(int x, int y, bool isFade)
	{
		if (this.openAllRoomTag)
		{
			isFade = true;
		}
		if (!isFade)
		{
			int num = this.FindRoomGrahpicIndex(this.mDungeonGraphicInfoList, this.mCurrentBossX, this.mCurrentBossY);
			if (num >= 0)
			{
				TreasureDungeonMap.RoomInfo roomInfo = this.mDungeonGraphicInfoList[num];
				roomInfo.imageMonster.enabled = false;
				this.mDungeonGraphicInfoList[num] = roomInfo;
			}
		}
		else
		{
			bool flag = false;
			if (this.mCurrentBossX != x || this.mCurrentBossY != y || this.isNearByBoss != isFade)
			{
				flag = true;
			}
			if (!flag)
			{
				return;
			}
			for (int i = 0; i < this.mDungeonGraphicInfoList.Length; i++)
			{
				TreasureDungeonMap.RoomInfo roomInfo2 = this.mDungeonGraphicInfoList[i];
				if (roomInfo2.x == this.mCurrentBossX && roomInfo2.y == this.mCurrentBossY)
				{
					roomInfo2.imageMonster.enabled = false;
					if (!roomInfo2.visited)
					{
						roomInfo2.imageBoard.enabled = false;
					}
				}
				if (roomInfo2.x == x && roomInfo2.y == y)
				{
					roomInfo2.imageBoard.enabled = true;
					roomInfo2.imageMonster.enabled = true;
				}
				this.mDungeonGraphicInfoList[i] = roomInfo2;
			}
		}
		this.mCurrentBossX = x;
		this.mCurrentBossY = y;
		this.isNearByBoss = isFade;
		this.SetViewPortData(this.mCurrentX, this.mCurrentY);
	}

	// Token: 0x06009A31 RID: 39473 RVA: 0x001DB434 File Offset: 0x001D9834
	private void _fixDungeonData(IDungeonData data)
	{
		int weidth = data.GetWeidth();
		int height = data.GetHeight();
		IDungeonConnectData areaConnectList = data.GetAreaConnectList(0);
		this.minX = areaConnectList.GetPositionX();
		this.minY = areaConnectList.GetPositionY();
		this.maxX = areaConnectList.GetPositionX();
		this.maxY = areaConnectList.GetPositionY();
		for (int i = 0; i < data.GetAreaConnectListLength(); i++)
		{
			IDungeonConnectData areaConnectList2 = data.GetAreaConnectList(i);
			this.minX = Math.Min(this.minX, areaConnectList2.GetPositionX());
			this.minY = Math.Min(this.minY, areaConnectList2.GetPositionY());
			this.maxX = Math.Max(this.maxX, areaConnectList2.GetPositionX());
			this.maxY = Math.Max(this.maxY, areaConnectList2.GetPositionY());
		}
		int num = this.maxX - this.minX + 1;
		int num2 = this.maxY - this.minY + 1;
		this.mFixedSize = new Vector2((float)num, (float)num2);
		this.mFixedOffset = new Vector2((float)this.minX, (float)(height - this.maxY - 1));
	}

	// Token: 0x06009A32 RID: 39474 RVA: 0x001DB558 File Offset: 0x001D9958
	private void _initBackground(int width, int height, ref GameObject root, GameObject parent)
	{
		int num = Mathf.Max(4, width);
		RectTransform component = parent.GetComponent<RectTransform>();
		component.sizeDelta = new Vector2((float)(num * this.mSizeUnit) + this.mDeltaFix.x * 2f, (float)(height * this.mSizeUnit) + this.mDeltaFix.y * 2f);
		if (root != null)
		{
			Object.DestroyImmediate(root);
		}
		root = new GameObject("Background", new Type[]
		{
			typeof(Image)
		});
		Utility.AttachTo(root, parent, false);
		root.transform.SetAsFirstSibling();
		RectTransform component2 = root.GetComponent<RectTransform>();
		component2.anchorMin = new Vector2(0f, 0f);
		component2.anchorMax = new Vector2(1f, 1f);
		component2.offsetMin = new Vector2(0f, (float)(-(float)this.mSizeUnit + 10));
		component2.offsetMax = new Vector2(0f, 0f);
		Image component3 = root.GetComponent<Image>();
		component3.type = 1;
		component3.sprite = this.mBackRoundImage;
		component3.color = new Color(1f, 1f, 1f, 0.5f);
	}

	// Token: 0x06009A33 RID: 39475 RVA: 0x001DB6A4 File Offset: 0x001D9AA4
	private void _loadDungeon()
	{
		DungeonID dungeonID = new DungeonID(DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonId);
		string hardString = ChapterUtility.GetHardString(3);
		if (null != this.mText)
		{
			this.mText.text = string.Format("<color=#14c5ff>{0}</color>{1}", hardString, this.mDungeonData.GetName());
			if (null != this.mMiniMapText)
			{
				this.mMiniMapText.text = this.mText.text;
			}
		}
		this.mDungeonGraphicInfoList = new TreasureDungeonMap.RoomInfo[(int)(this.mFixedSize.x * this.mFixedSize.y)];
		for (int i = this.minX; i <= this.maxX; i++)
		{
			for (int j = this.minY; j <= this.maxY; j++)
			{
				IDungeonConnectData dungeonConnectData = this._getConnect(i, j);
				TreasureDungeonMap.RoomInfo roomInfo = this.mDungeonGraphicInfoList[i - this.minX + (j - this.minY) * (int)this.mFixedSize.x];
				int id = -1;
				if (dungeonConnectData != null)
				{
					id = dungeonConnectData.GetId();
				}
				this.CreateMapUnit(i, j, this.mRoot, ref roomInfo, id, false);
				roomInfo.imageBoard.enabled = true;
				roomInfo.imageBoard.sprite = this.mItemImage;
				if (dungeonConnectData != null)
				{
					TreasureMapGenerator.ROOM_TYPE treasureType = (TreasureMapGenerator.ROOM_TYPE)dungeonConnectData.GetTreasureType();
					int num = this._getIndex(dungeonConnectData);
					int num2 = this.mapSpriteIndex[num][0];
					roomInfo.image.sprite = this.mImageList[num2 + 5];
					roomInfo.image.transform.Rotate(new Vector3(0f, 0f, (float)this.mapSpriteIndex[num][1]));
					roomInfo.type = treasureType;
					switch (treasureType)
					{
					case TreasureMapGenerator.ROOM_TYPE.END_ROOM:
						roomInfo.imageBoard.enabled = true;
						roomInfo.imageFg.enabled = true;
						roomInfo.imageFg.sprite = this.mTreasureSprite;
						roomInfo.imageFg.rectTransform.localScale = Vector3.one * this.fgImageScale;
						break;
					case TreasureMapGenerator.ROOM_TYPE.KEY_ROOM:
						roomInfo.imageFg.sprite = this.mKeySprite;
						break;
					case TreasureMapGenerator.ROOM_TYPE.MAP_ROOM:
						roomInfo.imageFg.sprite = this.mMapSprite;
						break;
					case TreasureMapGenerator.ROOM_TYPE.DROPITEM_ROOM:
						roomInfo.imageFg.sprite = this.mBoxSprite;
						roomInfo.imageFg.rectTransform.localScale = Vector3.one * this.fgImageScale;
						break;
					case TreasureMapGenerator.ROOM_TYPE.BORN_ROOM:
						roomInfo.imageBoard.enabled = true;
						roomInfo.imageBoard.sprite = this.mItemImage2;
						roomInfo.imagePlayer.enabled = true;
						roomInfo.imagePlayer.sprite = this.mStartSprite;
						roomInfo.state = TreasureDungeonMap.State.DS_IN;
						roomInfo.visited = true;
						this.mCurrentX = dungeonConnectData.GetPositionX();
						this.mCurrentY = dungeonConnectData.GetPositionY();
						break;
					}
				}
				this.mDungeonGraphicInfoList[i - this.minX + (j - this.minY) * (int)this.mFixedSize.x] = roomInfo;
			}
		}
	}

	// Token: 0x06009A34 RID: 39476 RVA: 0x001DBA1C File Offset: 0x001D9E1C
	private void _initSmallMapRoot()
	{
		int num = (int)this.viewPortData.x * (int)this.viewPortData.y;
		this.mSmallMapGraphicInfoList = new TreasureDungeonMap.RoomInfo[num];
		for (int i = 0; i < num; i++)
		{
			int num2 = i % 5;
			int num3 = i / 5;
			TreasureDungeonMap.RoomInfo roomInfo = this.mSmallMapGraphicInfoList[i];
			this.CreateMapUnit(num2 + 1, num3 + 1, this.mMiniRoot, ref roomInfo, i, true);
			this.mSmallMapGraphicInfoList[i] = roomInfo;
		}
	}

	// Token: 0x06009A35 RID: 39477 RVA: 0x001DBAA8 File Offset: 0x001D9EA8
	private void CreateMapUnit(int posX, int posY, GameObject root, ref TreasureDungeonMap.RoomInfo dgi, int id = 0, bool isSmallMap = false)
	{
		GameObject gameObject = new GameObject(this._getMapItemName(posX, posY), new Type[]
		{
			typeof(Image)
		});
		GameObject gameObject2 = new GameObject(this._getMapItemName(posX, posY), new Type[]
		{
			typeof(Image)
		});
		int num = this.mDungeonData.GetHeight() - (posY + 1);
		Utility.AttachTo(gameObject2, gameObject, false);
		Utility.AttachTo(gameObject, root, false);
		RectTransform component = gameObject.GetComponent<RectTransform>();
		component.pivot = Vector2.zero;
		component.anchorMin = Vector2.zero;
		component.anchorMax = Vector2.zero;
		int num2 = this.mSizeUnit - 8;
		if (isSmallMap)
		{
			Vector2 vector;
			vector..ctor(1f, 0f);
			component.offsetMin = new Vector2((float)(posX * this.mSizeUnit) + this.mDeltaFix.x + 2f, (float)(num * this.mSizeUnit) + this.mDeltaFix.y + 2f) - vector * (float)this.mSizeUnit;
			component.offsetMax = new Vector2((float)(posX * this.mSizeUnit + this.mSizeUnit) + this.mDeltaFix.x - 2f, (float)(num * this.mSizeUnit + this.mSizeUnit) + this.mDeltaFix.y - 2f) - vector * (float)this.mSizeUnit;
		}
		else
		{
			component.offsetMin = new Vector2((float)(posX * this.mSizeUnit) + this.mDeltaFix.x + 2f, (float)(num * this.mSizeUnit) + this.mDeltaFix.y + 2f) - this.mFixedOffset * (float)this.mSizeUnit;
			component.offsetMax = new Vector2((float)(posX * this.mSizeUnit + this.mSizeUnit) + this.mDeltaFix.x - 2f, (float)(num * this.mSizeUnit + this.mSizeUnit) + this.mDeltaFix.y - 2f) - this.mFixedOffset * (float)this.mSizeUnit;
		}
		RectTransform component2 = gameObject2.GetComponent<RectTransform>();
		component2.pivot = Vector2.one * 0.5f;
		component2.anchorMin = Vector2.zero;
		component2.anchorMax = Vector2.one;
		component2.offsetMin = Vector2.zero;
		component2.offsetMax = Vector2.zero;
		Image component3 = gameObject.GetComponent<Image>();
		component3.sprite = this.mItemImage;
		component3.type = 0;
		Image component4 = gameObject2.GetComponent<Image>();
		component4.type = 0;
		dgi.image = component4;
		dgi.imageFg = this._createTag("imageFg", null, gameObject, 1f);
		dgi.imageMonster = this._createTag("imageMonster", null, gameObject, 1f);
		dgi.imagePlayer = this._createTag("imagePlayer", null, gameObject, 1f);
		dgi.imageBoard = component3;
		dgi.x = posX;
		dgi.y = posY;
		dgi.state = TreasureDungeonMap.State.DS_CLOSE;
		dgi.visited = false;
		dgi.id = id;
		dgi.imageBoard.enabled = false;
		dgi.imageFg.enabled = false;
		dgi.image.enabled = false;
		dgi.imageMonster.enabled = false;
		dgi.imagePlayer.enabled = false;
		dgi.imagePlayer.sprite = this.mStartSprite;
		dgi.imageMonster.sprite = this.mMonsterSprite;
	}

	// Token: 0x06009A36 RID: 39478 RVA: 0x001DBE4C File Offset: 0x001DA24C
	private void _initButtonEvent()
	{
		this.mBigMapBtn = this.mMapRoot.GetComponent<Button>();
		this.mMiniMapBtn = this.mMiniMapRoot.GetComponent<Button>();
		if (this.mBigMapBtn)
		{
			this.mBigMapBtn.onClick.AddListener(new UnityAction(this._onBigMapButtonClick));
		}
		if (this.mMiniMapBtn)
		{
			this.mMiniMapBtn.onClick.AddListener(new UnityAction(this._onMiniMapButtonClick));
		}
	}

	// Token: 0x06009A37 RID: 39479 RVA: 0x001DBED3 File Offset: 0x001DA2D3
	private void _onBigMapButtonClick()
	{
		this._setMapState(true);
	}

	// Token: 0x06009A38 RID: 39480 RVA: 0x001DBEDC File Offset: 0x001DA2DC
	private void _onMiniMapButtonClick()
	{
		this._setMapState(false);
	}

	// Token: 0x06009A39 RID: 39481 RVA: 0x001DBEE8 File Offset: 0x001DA2E8
	private void _setMapState(bool mMimiMapActive)
	{
		if (this.mMapRoot)
		{
			this.mMapRoot.SetActive(!mMimiMapActive);
		}
		if (this.mMiniMapRoot)
		{
			this.mMiniMapRoot.SetActive(mMimiMapActive);
		}
		if (mMimiMapActive)
		{
			this.mMapSizeEventParam.width = (int)this.viewPortData.x;
			this.mMapSizeEventParam.height = (int)this.viewPortData.y;
		}
		else
		{
			this.mMapSizeEventParam.width = (int)this.mFixedSize.x;
			this.mMapSizeEventParam.height = (int)this.mFixedSize.y;
		}
		UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TreasureMapSizeChange, this.mMapSizeEventParam, null, null, null);
	}

	// Token: 0x06009A3A RID: 39482 RVA: 0x001DBFB0 File Offset: 0x001DA3B0
	public void SetDungeonData(IDungeonData scene)
	{
		this.mDungeonData = scene;
		this._fixDungeonData(scene);
		this._initBackground((int)this.mFixedSize.x, (int)this.mFixedSize.y, ref this.mRoot, this.mMapRoot);
		this._loadDungeon();
		this._initBackground((int)this.viewPortData.x, (int)this.viewPortData.y, ref this.mMiniRoot, this.mMiniMapRoot);
		this._initSmallMapRoot();
		this._initButtonEvent();
		if (this.mMapRoot)
		{
			this.mMapRoot.SetActive(false);
		}
	}

	// Token: 0x06009A3B RID: 39483 RVA: 0x001DC04D File Offset: 0x001DA44D
	private void OnDestroy()
	{
		if (this.mDungeonData != null)
		{
			this.mDungeonData = null;
		}
	}

	// Token: 0x06009A3C RID: 39484 RVA: 0x001DC064 File Offset: 0x001DA464
	public void UpdateDungoenGraphicInfo(TreasureDungeonMap.RoomInfo[] roomGraphicInfo, List<Image> imageList)
	{
		imageList.Clear();
		foreach (TreasureDungeonMap.RoomInfo roomInfo in roomGraphicInfo)
		{
			TreasureDungeonMap.State state = roomInfo.state;
			if (state != TreasureDungeonMap.State.DS_IN)
			{
				if (state != TreasureDungeonMap.State.DS_CLOSE)
				{
					if (state == TreasureDungeonMap.State.DS_OPEN)
					{
						if (roomInfo.image)
						{
							imageList.Add(roomInfo.image);
						}
						if (roomInfo.imageBoard)
						{
							imageList.Add(roomInfo.imageBoard);
						}
					}
				}
				else
				{
					if (roomInfo.image)
					{
						roomInfo.image.color = this.mDarkColor;
					}
					if (roomInfo.imageBoard)
					{
						roomInfo.imageBoard.color = this.mDarkColor;
					}
				}
			}
			else
			{
				if (roomInfo.image)
				{
					roomInfo.image.color = Color.white;
				}
				if (roomInfo.imageBoard)
				{
					roomInfo.imageBoard.color = Color.white;
				}
			}
		}
	}

	// Token: 0x06009A3D RID: 39485 RVA: 0x001DC190 File Offset: 0x001DA590
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

	// Token: 0x06009A3E RID: 39486 RVA: 0x001DC1E4 File Offset: 0x001DA5E4
	public void SetStartPosition(int x, int y)
	{
		for (int i = 0; i < this.mDungeonGraphicInfoList.Length; i++)
		{
			TreasureDungeonMap.RoomInfo roomInfo = this.mDungeonGraphicInfoList[i];
			roomInfo.state = TreasureDungeonMap.State.DS_CLOSE;
			if (roomInfo.x == this.mCurrentX && roomInfo.y == this.mCurrentY)
			{
				roomInfo.imagePlayer.enabled = false;
			}
			if (roomInfo.x == x && roomInfo.y == y)
			{
				roomInfo.image.enabled = true;
				int num = this._getIndex(this._getConnect(roomInfo.x, roomInfo.y));
				int num2 = this.mapSpriteIndex[num][0];
				roomInfo.image.sprite = this.mImageList[num2];
				roomInfo.imageBoard.enabled = true;
				roomInfo.imageBoard.sprite = this.mItemImage2;
				roomInfo.state = TreasureDungeonMap.State.DS_IN;
				roomInfo.imagePlayer.enabled = true;
				roomInfo.visited = true;
				TreasureMapGenerator.ROOM_TYPE type = roomInfo.type;
				if (type == TreasureMapGenerator.ROOM_TYPE.KEY_ROOM || type == TreasureMapGenerator.ROOM_TYPE.MAP_ROOM || type == TreasureMapGenerator.ROOM_TYPE.DROPITEM_ROOM)
				{
					if (!this.IsRoomFgImageClose(x, y))
					{
						roomInfo.imageFg.enabled = true;
					}
				}
			}
			this.mDungeonGraphicInfoList[i] = roomInfo;
		}
		this.mCurrentX = x;
		this.mCurrentY = y;
	}

	// Token: 0x06009A3F RID: 39487 RVA: 0x001DC358 File Offset: 0x001DA758
	public void SetOpenPosition(int x, int y)
	{
		for (int i = 0; i < this.mDungeonGraphicInfoList.Length; i++)
		{
			TreasureDungeonMap.RoomInfo roomInfo = this.mDungeonGraphicInfoList[i];
			TreasureDungeonMap.State state = TreasureDungeonMap.State.DS_CLOSE;
			if (roomInfo.x == x && roomInfo.y == y)
			{
				state = TreasureDungeonMap.State.DS_IN;
			}
			roomInfo.state = state;
			this.mDungeonGraphicInfoList[i] = roomInfo;
		}
	}

	// Token: 0x06009A40 RID: 39488 RVA: 0x001DC3C8 File Offset: 0x001DA7C8
	public void OpenAllRoom()
	{
		if (!this.openAllRoomTag)
		{
			for (int i = 0; i < this.mDungeonGraphicInfoList.Length; i++)
			{
				TreasureDungeonMap.RoomInfo roomInfo = this.mDungeonGraphicInfoList[i];
				if (roomInfo.state != TreasureDungeonMap.State.DS_IN && !roomInfo.visited)
				{
					roomInfo.visited = true;
					roomInfo.imageBoard.enabled = true;
					if (roomInfo.id != -1)
					{
						roomInfo.image.enabled = true;
						int num = this._getIndex(this._getConnect(roomInfo.x, roomInfo.y));
						int num2 = this.mapSpriteIndex[num][0];
						roomInfo.image.sprite = this.mImageList[num2 + 5];
					}
					if (roomInfo.x == this.mCurrentBossX && roomInfo.y == this.mCurrentBossY)
					{
						roomInfo.imageMonster.enabled = true;
					}
					switch (roomInfo.type)
					{
					case TreasureMapGenerator.ROOM_TYPE.KEY_ROOM:
						roomInfo.imageFg.enabled = true;
						break;
					case TreasureMapGenerator.ROOM_TYPE.MAP_ROOM:
						roomInfo.imageFg.enabled = true;
						break;
					case TreasureMapGenerator.ROOM_TYPE.DROPITEM_ROOM:
						roomInfo.imageFg.enabled = true;
						break;
					}
					this.mDungeonGraphicInfoList[i] = roomInfo;
				}
			}
			this.SetViewPortData(this.mCurrentX, this.mCurrentX);
		}
		this.openAllRoomTag = true;
	}

	// Token: 0x06009A41 RID: 39489 RVA: 0x001DC54C File Offset: 0x001DA94C
	private bool IsRoomFgImageClose(int x, int y)
	{
		for (int i = 0; i < this.ClearFgImagePosList.Count; i++)
		{
			if (this.ClearFgImagePosList[i].x == (float)x && this.ClearFgImagePosList[i].y == (float)y)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06009A42 RID: 39490 RVA: 0x001DC5B0 File Offset: 0x001DA9B0
	public void ClearCurrentRoomSpecialTag(TreasureMapGenerator.ROOM_TYPE type)
	{
		int num = this.FindRoomGrahpicIndex(this.mDungeonGraphicInfoList, this.mCurrentX, this.mCurrentY);
		if (num >= 0 && num < this.mDungeonGraphicInfoList.Length)
		{
			TreasureDungeonMap.RoomInfo roomInfo = this.mDungeonGraphicInfoList[num];
			if (roomInfo.type == type)
			{
				if (type == TreasureMapGenerator.ROOM_TYPE.MAP_ROOM)
				{
					this._setMapState(false);
				}
				roomInfo.imageFg.enabled = false;
				this.SetViewPortData(this.mCurrentX, this.mCurrentY);
				this.ClearFgImagePosList.Add(new Vector2((float)this.mCurrentX, (float)this.mCurrentY));
			}
		}
	}

	// Token: 0x06009A43 RID: 39491 RVA: 0x001DC655 File Offset: 0x001DAA55
	private void Update()
	{
	}

	// Token: 0x04004F79 RID: 20345
	public int mSizeUnit = 50;

	// Token: 0x04004F7A RID: 20346
	public Vector2 mDeltaFix = new Vector2(15f, 15f);

	// Token: 0x04004F7B RID: 20347
	public Vector2 mTextFix = new Vector2(3f, 2.1f);

	// Token: 0x04004F7C RID: 20348
	public Sprite mBackRoundImage;

	// Token: 0x04004F7D RID: 20349
	public Sprite mItemImage;

	// Token: 0x04004F7E RID: 20350
	public Sprite mItemImage2;

	// Token: 0x04004F7F RID: 20351
	public Sprite mTreasureSprite;

	// Token: 0x04004F80 RID: 20352
	public Sprite mStartSprite;

	// Token: 0x04004F81 RID: 20353
	public Sprite mMonsterSprite;

	// Token: 0x04004F82 RID: 20354
	public Sprite mBoxSprite;

	// Token: 0x04004F83 RID: 20355
	public Sprite mKeySprite;

	// Token: 0x04004F84 RID: 20356
	public Sprite mMapSprite;

	// Token: 0x04004F85 RID: 20357
	public float fgImageScale = 0.85f;

	// Token: 0x04004F86 RID: 20358
	[Space]
	public Sprite[] mImageList = new Sprite[10];

	// Token: 0x04004F87 RID: 20359
	private IDungeonData mDungeonData;

	// Token: 0x04004F88 RID: 20360
	public Text mText;

	// Token: 0x04004F89 RID: 20361
	public GameObject mMapRoot;

	// Token: 0x04004F8A RID: 20362
	public Text mMiniMapText;

	// Token: 0x04004F8B RID: 20363
	public GameObject mMiniMapRoot;

	// Token: 0x04004F8C RID: 20364
	[Header("地图开启动画设置")]
	public Color mDarkColor;

	// Token: 0x04004F8D RID: 20365
	public AnimationCurve mBlinkCurve;

	// Token: 0x04004F8E RID: 20366
	public float mBlinkTime;

	// Token: 0x04004F8F RID: 20367
	private TreasureDungeonMap.RoomInfo[] mDungeonGraphicInfoList;

	// Token: 0x04004F90 RID: 20368
	private List<Image> mDungoenBlinkList = new List<Image>();

	// Token: 0x04004F91 RID: 20369
	private TreasureDungeonMap.RoomInfo[] mSmallMapGraphicInfoList;

	// Token: 0x04004F92 RID: 20370
	private List<Image> mSmallMapList = new List<Image>();

	// Token: 0x04004F93 RID: 20371
	private int mCurrentX = -1;

	// Token: 0x04004F94 RID: 20372
	private int mCurrentY = -1;

	// Token: 0x04004F95 RID: 20373
	private Vector2 viewPortData = new Vector2(5f, 5f);

	// Token: 0x04004F96 RID: 20374
	private int[][] mapSpriteIndex;

	// Token: 0x04004F97 RID: 20375
	private int mCurrentBossX;

	// Token: 0x04004F98 RID: 20376
	private int mCurrentBossY;

	// Token: 0x04004F99 RID: 20377
	private bool isNearByBoss;

	// Token: 0x04004F9A RID: 20378
	private Vector2 mFixedOffset;

	// Token: 0x04004F9B RID: 20379
	private Vector2 mFixedSize;

	// Token: 0x04004F9C RID: 20380
	private int minX;

	// Token: 0x04004F9D RID: 20381
	private int minY;

	// Token: 0x04004F9E RID: 20382
	private int maxX;

	// Token: 0x04004F9F RID: 20383
	private int maxY;

	// Token: 0x04004FA0 RID: 20384
	private GameObject mRoot;

	// Token: 0x04004FA1 RID: 20385
	private GameObject mMiniRoot;

	// Token: 0x04004FA2 RID: 20386
	private Button mBigMapBtn;

	// Token: 0x04004FA3 RID: 20387
	private Button mMiniMapBtn;

	// Token: 0x04004FA4 RID: 20388
	private TreasureDungeonMap.UITreasureEventParam mMapSizeEventParam;

	// Token: 0x04004FA5 RID: 20389
	private bool openAllRoomTag;

	// Token: 0x04004FA6 RID: 20390
	private List<Vector2> ClearFgImagePosList;

	// Token: 0x02000F93 RID: 3987
	public enum State
	{
		// Token: 0x04004FA8 RID: 20392
		DS_NONE,
		// Token: 0x04004FA9 RID: 20393
		DS_IN,
		// Token: 0x04004FAA RID: 20394
		DS_CLOSE,
		// Token: 0x04004FAB RID: 20395
		DS_OPEN
	}

	// Token: 0x02000F94 RID: 3988
	public struct RoomInfo
	{
		// Token: 0x06009A44 RID: 39492 RVA: 0x001DC658 File Offset: 0x001DAA58
		public void CopyRoomState(TreasureDungeonMap.RoomInfo room)
		{
			this.image.sprite = room.image.sprite;
			this.image.material = room.image.material;
			this.image.enabled = room.image.enabled;
			this.image.transform.rotation = room.image.transform.rotation;
			this.imageFg.sprite = room.imageFg.sprite;
			this.imageFg.material = room.imageFg.material;
			this.imageFg.enabled = room.imageFg.enabled;
			this.imageFg.rectTransform.localScale = room.imageFg.rectTransform.localScale;
			this.imageBoard.sprite = room.imageBoard.sprite;
			this.imageBoard.material = room.imageBoard.material;
			this.imageBoard.enabled = room.imageBoard.enabled;
			this.imageMonster.sprite = room.imageMonster.sprite;
			this.imageMonster.material = room.imageMonster.material;
			this.imageMonster.enabled = room.imageMonster.enabled;
			this.imagePlayer.sprite = room.imagePlayer.sprite;
			this.imagePlayer.material = room.imagePlayer.material;
			this.imagePlayer.enabled = room.imagePlayer.enabled;
			this.state = room.state;
			this.visited = room.visited;
		}

		// Token: 0x06009A45 RID: 39493 RVA: 0x001DC81A File Offset: 0x001DAC1A
		public void Hide()
		{
			this.image.enabled = false;
			this.imageFg.enabled = false;
			this.imageMonster.enabled = false;
			this.imagePlayer.enabled = false;
		}

		// Token: 0x04004FAC RID: 20396
		public Image image;

		// Token: 0x04004FAD RID: 20397
		public Image imageFg;

		// Token: 0x04004FAE RID: 20398
		public Image imageBoard;

		// Token: 0x04004FAF RID: 20399
		public Image imageMonster;

		// Token: 0x04004FB0 RID: 20400
		public Image imagePlayer;

		// Token: 0x04004FB1 RID: 20401
		public int x;

		// Token: 0x04004FB2 RID: 20402
		public int y;

		// Token: 0x04004FB3 RID: 20403
		public TreasureDungeonMap.State state;

		// Token: 0x04004FB4 RID: 20404
		public bool visited;

		// Token: 0x04004FB5 RID: 20405
		public int id;

		// Token: 0x04004FB6 RID: 20406
		public TreasureMapGenerator.ROOM_TYPE type;
	}

	// Token: 0x02000F95 RID: 3989
	public class UITreasureEventParam
	{
		// Token: 0x04004FB7 RID: 20407
		public int width;

		// Token: 0x04004FB8 RID: 20408
		public int height;
	}
}
