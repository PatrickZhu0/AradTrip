using System;
using Battle;
using GameClient;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000EB7 RID: 3767
public class ComDrug : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IComparable<ComDrug>, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06009476 RID: 38006 RVA: 0x001BD5ED File Offset: 0x001BB9ED
	public int CompareTo(ComDrug other)
	{
		if (this.mTable == null)
		{
			return 1;
		}
		if (other.mTable == null)
		{
			return 0;
		}
		return this.mTable.DefualtUsePriority - other.mTable.DefualtUsePriority;
	}

	// Token: 0x06009477 RID: 38007 RVA: 0x001BD620 File Offset: 0x001BBA20
	private void Update()
	{
		if (this.isPointerDown && !this.longPressTriggered && Time.time - this.timePressStarted > this.durationThreshold)
		{
			this.longPressTriggered = true;
			this.onLongPress.Invoke();
		}
	}

	// Token: 0x17001907 RID: 6407
	// (get) Token: 0x06009478 RID: 38008 RVA: 0x001BD66C File Offset: 0x001BBA6C
	// (set) Token: 0x06009479 RID: 38009 RVA: 0x001BD674 File Offset: 0x001BBA74
	public ItemTable.eSubType itemSubType { get; private set; }

	// Token: 0x0600947A RID: 38010 RVA: 0x001BD67D File Offset: 0x001BBA7D
	public void SetCount(int cnt)
	{
		this.mLeftCount = cnt;
		if (this.mCount == null)
		{
			return;
		}
		this.mCount.text = cnt.ToString();
	}

	// Token: 0x0600947B RID: 38011 RVA: 0x001BD6B0 File Offset: 0x001BBAB0
	public void SetItemID(int id)
	{
		this.mItemId = id;
		ItemData itemByTableID = DataManager<ItemDataManager>.GetInstance().GetItemByTableID(this.mItemId, true, true);
		if (itemByTableID == null)
		{
			this.itemSubType = ItemTable.eSubType.ST_NONE;
		}
		else
		{
			this.itemSubType = (ItemTable.eSubType)itemByTableID.SubType;
		}
		if (null != this.mIcon)
		{
			if (itemByTableID == null)
			{
				this.mIcon.color = Color.clear;
			}
			else
			{
				this.mIcon.color = Color.white;
				ETCImageLoader.LoadSprite(ref this.mIcon, itemByTableID.Icon, true);
			}
		}
		this.mTable = ChapterBattlePotionSetUtiilty.GetItemConfigTalbeByID(this.mItemId);
	}

	// Token: 0x0600947C RID: 38012 RVA: 0x001BD758 File Offset: 0x001BBB58
	public bool StartCD(float cd)
	{
		if (this.mState == ComDrug.eState.onReady)
		{
			this.mCD = cd;
			this.mCurrent = this.mCD;
			this.mState = ComDrug.eState.onCooldown;
			if (this.mButton != null)
			{
				this.mButton.interactable = false;
			}
			if (this.mBar != null)
			{
				this.mBar.enabled = true;
			}
			return true;
		}
		return false;
	}

	// Token: 0x0600947D RID: 38013 RVA: 0x001BD7C7 File Offset: 0x001BBBC7
	public bool IsCD()
	{
		return this.mState == ComDrug.eState.onCooldown;
	}

	// Token: 0x0600947E RID: 38014 RVA: 0x001BD7D4 File Offset: 0x001BBBD4
	public void PlayEffect()
	{
		MonoSingleton<AudioManager>.instance.PlaySound(7);
		if (this.mTable == null)
		{
			return;
		}
		for (int i = 0; i < this.mTable.UseItemEffect.Count; i++)
		{
			this._playerEffect(this.mTable.UseItemEffect[i]);
		}
	}

	// Token: 0x0600947F RID: 38015 RVA: 0x001BD834 File Offset: 0x001BBC34
	private void _playerEffect(string path)
	{
		BattlePlayer localPlayer = BattleMain.instance.GetLocalPlayer(0UL);
		if (localPlayer == null)
		{
			return;
		}
		BeActor playerActor = localPlayer.playerActor;
		if (playerActor == null)
		{
			return;
		}
		if (playerActor.CurrentBeScene.currentGeScene.CreateEffect(path, 0f, playerActor.GetGePosition(PositionType.BODY), 1f, 1f, false, false) == null)
		{
			return;
		}
	}

	// Token: 0x06009480 RID: 38016 RVA: 0x001BD894 File Offset: 0x001BBC94
	public void RealUpdate()
	{
		if (this.mState == ComDrug.eState.onCooldown)
		{
			this.mCurrent -= Time.deltaTime;
			this.mBar.fillAmount = 1f - Mathf.Clamp01(1f - this.mCurrent / this.mCD);
			if (this.mCountDown != null)
			{
				this.mCountDown.CustomActive(true);
				float num = this.mCurrent * 1000f / 1000f;
				if (num > 1f)
				{
					this.mCountDown.text = string.Format("{0:0}", num);
				}
				else
				{
					this.mCountDown.text = string.Format("{0:F1}", num);
				}
			}
			if (this.mCurrent <= 0f)
			{
				this.mCountDown.CustomActive(false);
				this.mState = ComDrug.eState.onReady;
				this.mButton.interactable = true;
				this.mBar.enabled = false;
			}
		}
	}

	// Token: 0x06009481 RID: 38017 RVA: 0x001BD999 File Offset: 0x001BBD99
	public void SetMode(ComDrug.eMode mode)
	{
		this.mMode = mode;
	}

	// Token: 0x06009482 RID: 38018 RVA: 0x001BD9A4 File Offset: 0x001BBDA4
	public void OnPointerDown(PointerEventData eventData)
	{
		if (base.gameObject.name == "Item0")
		{
			this.timePressStarted = Time.time;
			this.isPointerDown = true;
			this.longPressTriggered = false;
		}
		this.mModeState = ComDrug.eModeState.onClickDown;
		if (this.mMode == ComDrug.eMode.Drag)
		{
			this.OnPointerUp(eventData);
		}
	}

	// Token: 0x06009483 RID: 38019 RVA: 0x001BDA00 File Offset: 0x001BBE00
	public void OnPointerUp(PointerEventData eventData)
	{
		if (base.gameObject.name == "Item0")
		{
			this.isPointerDown = false;
		}
		if (this.mModeState != ComDrug.eModeState.onNone)
		{
			if (this.mModeState != ComDrug.eModeState.onClickDown)
			{
				if (this.mModeState == ComDrug.eModeState.onDrag)
				{
					this.onDragRight.Invoke();
				}
			}
			this.mModeState = ComDrug.eModeState.onNone;
		}
	}

	// Token: 0x06009484 RID: 38020 RVA: 0x001BDA68 File Offset: 0x001BBE68
	public void OnDrag(PointerEventData eventData)
	{
		if (base.gameObject.name == "Item0")
		{
			Vector2 left = Vector2.left;
			Vector2 vector = eventData.position - eventData.pressPosition;
			float num = Vector2.Dot(left, vector);
			if (num > 0f && vector.magnitude > this.deltaSplit)
			{
				ComDrugTipsBar.instance.SetDrugcolumnState();
				this.OnPointerUp(eventData);
			}
		}
		if (this.mModeState == ComDrug.eModeState.onClickDown)
		{
			Vector2 right = Vector2.right;
			Vector2 vector2 = eventData.position - eventData.pressPosition;
			float num2 = Vector2.Dot(right, vector2);
			if (num2 > 0f && vector2.magnitude > this.deltaSplit)
			{
				this.mModeState = ComDrug.eModeState.onDrag;
				this.OnPointerUp(eventData);
			}
		}
	}

	// Token: 0x06009485 RID: 38021 RVA: 0x001BDB38 File Offset: 0x001BBF38
	public void OnPointerClick(PointerEventData eventData)
	{
		if (base.gameObject.name == "Item0" && !this.longPressTriggered)
		{
			this.onClick.Invoke();
		}
	}

	// Token: 0x04004B37 RID: 19255
	public Button mButton;

	// Token: 0x04004B38 RID: 19256
	public Text mCount;

	// Token: 0x04004B39 RID: 19257
	public Image mBar;

	// Token: 0x04004B3A RID: 19258
	public Text mCountDown;

	// Token: 0x04004B3B RID: 19259
	public Image mIcon;

	// Token: 0x04004B3C RID: 19260
	public DungeonItem.eType mType;

	// Token: 0x04004B3D RID: 19261
	public int mItemId;

	// Token: 0x04004B3E RID: 19262
	public bool locked;

	// Token: 0x04004B3F RID: 19263
	public float durationThreshold = 0.5f;

	// Token: 0x04004B40 RID: 19264
	public UnityEvent onLongPress = new UnityEvent();

	// Token: 0x04004B41 RID: 19265
	private bool isPointerDown;

	// Token: 0x04004B42 RID: 19266
	private bool longPressTriggered;

	// Token: 0x04004B43 RID: 19267
	private float timePressStarted;

	// Token: 0x04004B45 RID: 19269
	private ComDrug.eState mState;

	// Token: 0x04004B46 RID: 19270
	private float mCD;

	// Token: 0x04004B47 RID: 19271
	private float mCurrent;

	// Token: 0x04004B48 RID: 19272
	public int mLeftCount;

	// Token: 0x04004B49 RID: 19273
	private ItemConfigTable mTable;

	// Token: 0x04004B4A RID: 19274
	public UnityEvent onClick = new UnityEvent();

	// Token: 0x04004B4B RID: 19275
	public float deltaSplit = 20f;

	// Token: 0x04004B4C RID: 19276
	public UnityEvent onDragRight = new UnityEvent();

	// Token: 0x04004B4D RID: 19277
	private ComDrug.eModeState mModeState;

	// Token: 0x04004B4E RID: 19278
	private ComDrug.eMode mMode = ComDrug.eMode.Click;

	// Token: 0x02000EB8 RID: 3768
	private enum eState
	{
		// Token: 0x04004B50 RID: 19280
		onReady,
		// Token: 0x04004B51 RID: 19281
		onCooldown
	}

	// Token: 0x02000EB9 RID: 3769
	public enum eModeState
	{
		// Token: 0x04004B53 RID: 19283
		onNone,
		// Token: 0x04004B54 RID: 19284
		onClickDown,
		// Token: 0x04004B55 RID: 19285
		onDrag
	}

	// Token: 0x02000EBA RID: 3770
	public enum eMode
	{
		// Token: 0x04004B57 RID: 19287
		Drag,
		// Token: 0x04004B58 RID: 19288
		Click
	}
}
