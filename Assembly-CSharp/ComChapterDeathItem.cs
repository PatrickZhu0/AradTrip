using System;
using GameClient;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000E7D RID: 3709
public class ComChapterDeathItem : MonoBehaviour
{
	// Token: 0x060092F2 RID: 37618 RVA: 0x001B4C0C File Offset: 0x001B300C
	protected void _bindExUI()
	{
		this.mImage = this.mBind.GetGameObject("image");
		this.mText = this.mBind.GetCom<Text>("text");
		this.mItemlist = this.mBind.GetCom<ComItemList>("itemlist");
		this.mButton = this.mBind.GetCom<Button>("button");
		this.mDropItemGray = this.mBind.GetCom<UIGray>("isGetReward");
		this.mFg = this.mBind.GetGameObject("Fg");
		this.mBoxState = this.mBind.GetCom<Image>("boxState");
		this.mTeXiao = this.mBind.GetGameObject("TeXiao");
		this.mTeXiaoQuan = this.mBind.GetGameObject("TeXiaoQuan");
		this.mLimitLevel = this.mBind.GetCom<Text>("LimitLevel");
	}

	// Token: 0x060092F3 RID: 37619 RVA: 0x001B4CF8 File Offset: 0x001B30F8
	protected void _unbindExUI()
	{
		this.mImage = null;
		this.mText = null;
		this.mItemlist = null;
		this.mButton.onClick.RemoveAllListeners();
		this.mButton = null;
		this.mDropItemGray = null;
		this.mFg = null;
		this.mBoxState = null;
		this.mTeXiao = null;
		this.mTeXiaoQuan = null;
		this.mLimitLevel = null;
	}

	// Token: 0x060092F4 RID: 37620 RVA: 0x001B4D5B File Offset: 0x001B315B
	private void Awake()
	{
		this._bindExUI();
	}

	// Token: 0x060092F5 RID: 37621 RVA: 0x001B4D63 File Offset: 0x001B3163
	private void OnDestroy()
	{
		this._unbindExUI();
	}

	// Token: 0x060092F6 RID: 37622 RVA: 0x001B4D6B File Offset: 0x001B316B
	private void _setLevel(int start, int end)
	{
		if (null != this.mText)
		{
			this.mText.text = string.Format("{0}-{1}层", start, end);
		}
	}

	// Token: 0x060092F7 RID: 37623 RVA: 0x001B4DA0 File Offset: 0x001B31A0
	private void _setLevelLimit(int level)
	{
		this.mLimitLevel.gameObject.CustomActive(false);
		if (null != this.mLimitLevel)
		{
			this.mLimitLevel.gameObject.CustomActive(false);
		}
		DeathTowerAwardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DeathTowerAwardTable>(level, string.Empty, string.Empty);
		if (tableItem == null)
		{
			Logger.LogErrorFormat("DeathTowerAwardTableData is null", new object[0]);
			return;
		}
		int limitLevel = tableItem.LimitLevel;
		if (limitLevel == 0)
		{
			Logger.LogErrorFormat("LimitLevel is null", new object[0]);
			return;
		}
		if (limitLevel != 0 && limitLevel > (int)DataManager<PlayerBaseData>.GetInstance().Level && null != this.mLimitLevel)
		{
			this.mLimitLevel.gameObject.CustomActive(true);
			this.mLimitLevel.text = string.Format("{0}级开启", limitLevel);
		}
	}

	// Token: 0x060092F8 RID: 37624 RVA: 0x001B4E7E File Offset: 0x001B327E
	public void SetIndex(int i)
	{
		this.mIndex = i;
		this._setLevel(i * 5 + 1, i * 5 + 5);
		this._setLevelLimit(i * 5 + 1);
	}

	// Token: 0x060092F9 RID: 37625 RVA: 0x001B4EA2 File Offset: 0x001B32A2
	public void UpdateLimitLevel(int i)
	{
		this._setLevelLimit(i * 5 + 1);
	}

	// Token: 0x060092FA RID: 37626 RVA: 0x001B4EAF File Offset: 0x001B32AF
	public void SetMask(int mask)
	{
		this.mMask = mask;
		this.mFg.SetActive(this._isGetReward());
		this.mDropItemGray.enabled = this._isGetReward();
	}

	// Token: 0x060092FB RID: 37627 RVA: 0x001B4EDA File Offset: 0x001B32DA
	private bool _isGetReward()
	{
		return (this.mMask & 1 << this.mIndex) > 0;
	}

	// Token: 0x060092FC RID: 37628 RVA: 0x001B4EF4 File Offset: 0x001B32F4
	public void SetClick(ComChapterDeathItem.ChapterDeadItemAction cb)
	{
		if (null != this.mButton)
		{
			this.mButton.onClick.AddListener(delegate()
			{
				if (this.mState == ComChapterDeathItem.eState.Pass)
				{
					if (!this._isGetReward() && cb != null)
					{
						cb(this.mState);
					}
				}
				else if (cb != null)
				{
					cb(this.mState);
				}
			});
		}
	}

	// Token: 0x060092FD RID: 37629 RVA: 0x001B4F44 File Offset: 0x001B3344
	public void SetSelect(bool isSelect)
	{
		this.mImage.SetActive(isSelect);
		if (!isSelect)
		{
			GameObject gameObject = null;
			GeEffectProxy componentInChildren = this.mTeXiaoQuan.GetComponentInChildren<GeEffectProxy>();
			if (componentInChildren != null)
			{
				gameObject = componentInChildren.gameObject;
			}
			if (gameObject != null)
			{
				Object.DestroyImmediate(gameObject);
			}
		}
		else if (this._isGetReward())
		{
			GameObject gameObject2 = Singleton<AssetLoader>.instance.LoadResAsGameObject("Effects/Scene_effects/EffectUI/EffUI_quan", true, 0U);
			gameObject2 = Singleton<AssetLoader>.instance.LoadResAsGameObject("Effects/Scene_effects/EffectUI/EffUI_quan", true, 0U);
			if (gameObject2 != null)
			{
				Utility.AttachTo(gameObject2, this.mTeXiaoQuan, false);
			}
		}
	}

	// Token: 0x060092FE RID: 37630 RVA: 0x001B4FE3 File Offset: 0x001B33E3
	public void SetItems(ComItemList.Items[] list)
	{
		this.mItemlist.SetItems(list);
	}

	// Token: 0x060092FF RID: 37631 RVA: 0x001B4FF4 File Offset: 0x001B33F4
	public void SetState(ComChapterDeathItem.eState state)
	{
		this.mState = state;
		if (this._isGetReward())
		{
			this.mBind.GetSprite("open", ref this.mBoxState);
		}
		else
		{
			this.mBind.GetSprite("close", ref this.mBoxState);
		}
		this.mDropItemGray.SetEnable(this.mDropItemGray.enabled);
		if (!this._isGetReward())
		{
			RectTransform component = this.mBoxState.gameObject.GetComponent<RectTransform>();
			component.localScale = new Vector3(1.8f, 1.8f, 1f);
		}
		else
		{
			RectTransform component2 = this.mBoxState.gameObject.GetComponent<RectTransform>();
			component2.localScale = new Vector3(1f, 1f, 1f);
		}
		this.mDropItemGray.enabled = false;
		if (state != ComChapterDeathItem.eState.Lock)
		{
			if (state != ComChapterDeathItem.eState.Pass)
			{
				if (state != ComChapterDeathItem.eState.Unlock)
				{
				}
			}
			else
			{
				GameObject gameObject = null;
				GeEffectProxy componentInChildren = this.mTeXiao.GetComponentInChildren<GeEffectProxy>();
				if (componentInChildren != null)
				{
					gameObject = componentInChildren.gameObject;
				}
				if (gameObject != null)
				{
					Object.DestroyImmediate(gameObject);
				}
				if (!this._isGetReward())
				{
					GameObject gameObject2 = Singleton<AssetLoader>.instance.LoadResAsGameObject("Effects/Scene_effects/EffectUI/EffUI_xiangzi", true, 0U);
					if (gameObject2 != null)
					{
						Utility.AttachTo(gameObject2, this.mTeXiao, false);
					}
				}
			}
		}
		else
		{
			this.mDropItemGray.enabled = true;
		}
	}

	// Token: 0x040049F2 RID: 18930
	private const string TeXiaoQuan = "Effects/Scene_effects/EffectUI/EffUI_quan";

	// Token: 0x040049F3 RID: 18931
	private const string TeXiaoGuang = "Effects/Scene_effects/EffectUI/EffUI_xiangzi";

	// Token: 0x040049F4 RID: 18932
	private const string TeXiaoQuanPath = "EffUI_quan(Clone)";

	// Token: 0x040049F5 RID: 18933
	private const string TeXiaoGuangPath = "EffUI_item_cheng(Clone)";

	// Token: 0x040049F6 RID: 18934
	public ComCommonBind mBind;

	// Token: 0x040049F7 RID: 18935
	private GameObject mImage;

	// Token: 0x040049F8 RID: 18936
	private Text mText;

	// Token: 0x040049F9 RID: 18937
	private ComItemList mItemlist;

	// Token: 0x040049FA RID: 18938
	private Button mButton;

	// Token: 0x040049FB RID: 18939
	private UIGray mDropItemGray;

	// Token: 0x040049FC RID: 18940
	private GameObject mFg;

	// Token: 0x040049FD RID: 18941
	private Image mBoxState;

	// Token: 0x040049FE RID: 18942
	private GameObject mTeXiao;

	// Token: 0x040049FF RID: 18943
	private GameObject mTeXiaoQuan;

	// Token: 0x04004A00 RID: 18944
	private Text mLimitLevel;

	// Token: 0x04004A01 RID: 18945
	private ComChapterDeathItem.eState mState;

	// Token: 0x04004A02 RID: 18946
	private int mMask;

	// Token: 0x04004A03 RID: 18947
	private int mIndex;

	// Token: 0x02000E7E RID: 3710
	public enum eState
	{
		// Token: 0x04004A05 RID: 18949
		Lock,
		// Token: 0x04004A06 RID: 18950
		Unlock,
		// Token: 0x04004A07 RID: 18951
		Pass
	}

	// Token: 0x02000E7F RID: 3711
	// (Invoke) Token: 0x06009301 RID: 37633
	public delegate void ChapterDeadItemAction(ComChapterDeathItem.eState st);
}
