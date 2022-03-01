using System;
using System.Collections.Generic;
using System.Diagnostics;
using GameClient;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

// Token: 0x02000E82 RID: 3714
[ExecuteInEditMode]
public class ComChapterDungeonUnit : MonoBehaviour
{
	// Token: 0x0600930D RID: 37645 RVA: 0x001B5980 File Offset: 0x001B3D80
	protected void _bindExUI()
	{
		this.mName = this.mBind.GetCom<Text>("Name");
		this.mLevel = this.mBind.GetCom<Text>("Level");
		this.mLockRoot = this.mBind.GetGameObject("LockRoot");
		this.mTypeName = this.mBind.GetCom<Text>("TypeName");
		this.mCheckRoot = this.mBind.GetGameObject("CheckRoot");
		this.mNormalRoot = this.mBind.GetGameObject("NormalRoot");
		this.mDungeonUnit = this.mBind.GetCom<ComChapterDungeonUnit>("DungeonUnit");
		this.mMissionFlag = this.mBind.GetGameObject("MissionFlag");
		this.mSelect = this.mBind.GetCom<Toggle>("Select");
		if (this.mSelect != null)
		{
			this.mSelect.onValueChanged.AddListener(new UnityAction<bool>(this._onSelectToggleValueChange));
		}
		this.mBackground = this.mBind.GetCom<Image>("Background");
		this.mCharactorIcon = this.mBind.GetCom<Image>("CharactorIcon");
		this.mOrderNumber = this.mBind.GetCom<Text>("OrderNumber");
		this.mSourcePosition = this.mBind.GetCom<RectTransform>("sourcePosition");
		this.mTargetPosition = this.mBind.GetCom<RectTransform>("targetPosition");
		this.mTargetRightPosition = this.mBind.GetCom<RectTransform>("targetRightPosition");
		this.mAngleGraph = this.mBind.GetCom<TriangleGraph>("angleGraph");
		this.mThumbRoot = this.mBind.GetCom<RectTransform>("thumbRoot");
		this.mOpenEffect = this.mBind.GetGameObject("openEffect");
		this.mEffectRoot = this.mBind.GetGameObject("effectRoot");
		this.challengeFlag = this.mBind.GetGameObject("challengeFlag");
		this.mSpecialUnlockTipRoot = this.mBind.GetGameObject("specialUnlockTipRoot");
		this.mUnlockTipText = this.mBind.GetCom<Text>("unlockTipText");
		this.mHelp = this.mBind.GetCom<HelpAssistant>("Help");
		this.mLvR = this.mBind.GetGameObject("LvR");
		this.mEliteBg = this.mBind.GetGameObject("eliteBg");
		this.mEffUI = this.mBind.GetGameObject("effUI");
		this.mPreview = this.mBind.GetCom<Button>("preview");
		this.mPreview.SafeSetOnClickListener(delegate
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<EliteDungeonPreviewFrame>(FrameLayer.Middle, null, string.Empty);
		});
		this.mUnlockProcess = this.mBind.GetCom<Slider>("unlockProcess");
		this.mUnlockValue = this.mBind.GetCom<Text>("unlockValue");
	}

	// Token: 0x0600930E RID: 37646 RVA: 0x001B5C60 File Offset: 0x001B4060
	protected void _unbindExUI()
	{
		this.mName = null;
		this.mLevel = null;
		this.mLockRoot = null;
		this.mTypeName = null;
		this.mCheckRoot = null;
		this.mNormalRoot = null;
		this.mDungeonUnit = null;
		this.mMissionFlag = null;
		if (this.mSelect != null)
		{
			this.mSelect.onValueChanged.RemoveListener(new UnityAction<bool>(this._onSelectToggleValueChange));
		}
		this.mSelect = null;
		this.mBackground = null;
		this.mCharactorIcon = null;
		this.mOrderNumber = null;
		this.mSourcePosition = null;
		this.mTargetPosition = null;
		this.mTargetRightPosition = null;
		this.mAngleGraph = null;
		this.mThumbRoot = null;
		this.mOpenEffect = null;
		this.mEffectRoot = null;
		this.challengeFlag = null;
		this.mSpecialUnlockTipRoot = null;
		this.mUnlockTipText = null;
		this.mHelp = null;
		this.mLvR = null;
		this.mEliteBg = null;
		this.mEffUI = null;
		this.mPreview = null;
		this.mUnlockProcess = null;
		this.mUnlockValue = null;
	}

	// Token: 0x0600930F RID: 37647 RVA: 0x001B5D65 File Offset: 0x001B4165
	private void _onSelectToggleValueChange(bool changed)
	{
		this.mCheckRoot.SetActive(changed);
		this.mNormalRoot.SetActive(!changed);
		this.mOpenEffect.SetActive(changed);
	}

	// Token: 0x06009310 RID: 37648 RVA: 0x001B5D8E File Offset: 0x001B418E
	public void Awake()
	{
		this.dungeonID = 0;
		this._bindExUI();
	}

	// Token: 0x06009311 RID: 37649 RVA: 0x001B5D9D File Offset: 0x001B419D
	private void OnDestroy()
	{
		this.dungeonID = 0;
		this._unbindExUI();
	}

	// Token: 0x17001903 RID: 6403
	// (get) Token: 0x06009312 RID: 37650 RVA: 0x001B5DAC File Offset: 0x001B41AC
	public bool isLock
	{
		get
		{
			return this.mState == ComChapterDungeonUnit.eState.Locked;
		}
	}

	// Token: 0x06009313 RID: 37651 RVA: 0x001B5DB7 File Offset: 0x001B41B7
	public void SetDungeonType(ComChapterDungeonUnit.eDungeonType type)
	{
		this.mDungeonType = ComChapterDungeonUnit.eDungeonType.Normal;
	}

	// Token: 0x06009314 RID: 37652 RVA: 0x001B5DC0 File Offset: 0x001B41C0
	public void SetBackgroud(string spritePath)
	{
		if (spritePath == null)
		{
			this.mBackground.sprite = null;
		}
		else
		{
			ETCImageLoader.LoadSprite(ref this.mBackground, spritePath, true);
		}
	}

	// Token: 0x06009315 RID: 37653 RVA: 0x001B5DE8 File Offset: 0x001B41E8
	public void SetCharactorSprite(string spritePath)
	{
		if (spritePath == null || spritePath.Length <= 0)
		{
			this.mCharactorIcon.sprite = null;
		}
		else
		{
			ETCImageLoader.LoadSprite(ref this.mCharactorIcon, spritePath, true);
		}
		RectTransform rectTransform = this.mCharactorIcon.rectTransform;
		float y = rectTransform.sizeDelta.y;
		this.mCharactorIcon.SetNativeSize();
		this.mCharactorIcon.CustomActive(null != this.mCharactorIcon.sprite);
		float y2 = rectTransform.sizeDelta.y;
		rectTransform.sizeDelta *= y / y2;
		rectTransform.localScale = Vector3.one;
	}

	// Token: 0x06009316 RID: 37654 RVA: 0x001B5E98 File Offset: 0x001B4298
	public void SetState(ComChapterDungeonUnit.eState state)
	{
		bool active = false;
		this.mState = state;
		this.mSelect.interactable = true;
		switch (state)
		{
		case ComChapterDungeonUnit.eState.Locked:
			active = true;
			this.mSelect.interactable = false;
			break;
		}
		this.mLockRoot.SetActive(active);
		this.mEffUI.CustomActive(this.mState != ComChapterDungeonUnit.eState.Locked);
		if (TeamUtility.IsEliteDungeonID(this.dungeonID))
		{
			this.mPreview.CustomActive(this.mState == ComChapterDungeonUnit.eState.Locked);
			this.mUnlockProcess.CustomActive(this.mState == ComChapterDungeonUnit.eState.Locked);
			List<int> currentChapterNormalDungeonIDs = EliteDungeonPreviewFrame.GetCurrentChapterNormalDungeonIDs();
			int num = 0;
			if (currentChapterNormalDungeonIDs != null && currentChapterNormalDungeonIDs.Count > 0)
			{
				num = currentChapterNormalDungeonIDs.Count;
			}
			this.mUnlockValue.SafeSetText(string.Format("{0}/{1}", EliteDungeonPreviewFrame.GetSSSDungeonNum(), num));
			float value = 1f;
			if (num > 0)
			{
				value = (float)EliteDungeonPreviewFrame.GetSSSDungeonNum() / (float)num;
			}
			this.mUnlockProcess.SafeSetValue(value);
			if (state == ComChapterDungeonUnit.eState.Locked)
			{
				this.SetHelpType(HelpFrame.HelpType.HT_NONE);
			}
			else
			{
				this.SetHelpType(HelpFrame.HelpType.HT_ELITE_DUNGEON);
			}
		}
		else
		{
			this.mPreview.CustomActive(false);
			this.mUnlockProcess.CustomActive(false);
			this.SetHelpType(HelpFrame.HelpType.HT_NONE);
		}
	}

	// Token: 0x06009317 RID: 37655 RVA: 0x001B5FFC File Offset: 0x001B43FC
	public void SetType(ComChapterDungeonUnit.eMissionType type)
	{
		if (this.mTypeName != null)
		{
			this.mTypeName.text = string.Empty;
		}
		this.mType = type;
		this.mMissionFlag.SetActive(false);
		ComChapterDungeonUnit.eMissionType eMissionType = this.mType;
		if (eMissionType != ComChapterDungeonUnit.eMissionType.Main)
		{
			if (eMissionType == ComChapterDungeonUnit.eMissionType.Other)
			{
				this.mMissionFlag.SetActive(true);
			}
		}
		else
		{
			this.mMissionFlag.SetActive(true);
		}
	}

	// Token: 0x06009318 RID: 37656 RVA: 0x001B607D File Offset: 0x001B447D
	public void SetDungeonID(int id)
	{
		this.dungeonID = id;
	}

	// Token: 0x06009319 RID: 37657 RVA: 0x001B6086 File Offset: 0x001B4486
	public void SetName(string name, string level)
	{
		this.mName.text = name;
		this.mLevel.text = level;
	}

	// Token: 0x0600931A RID: 37658 RVA: 0x001B60A0 File Offset: 0x001B44A0
	public void SetIsChallenging(bool value)
	{
		this.challengeFlag.CustomActive(value);
	}

	// Token: 0x0600931B RID: 37659 RVA: 0x001B60AE File Offset: 0x001B44AE
	public void SetHelpType(HelpFrame.HelpType helpType)
	{
		if (this.mHelp != null)
		{
			this.mHelp.eType = helpType;
			this.mHelp.CustomActive(helpType != HelpFrame.HelpType.HT_NONE);
		}
	}

	// Token: 0x0600931C RID: 37660 RVA: 0x001B60E0 File Offset: 0x001B44E0
	public void ShowEliteBg(bool value)
	{
		this.mEliteBg.CustomActive(value);
		if (this.mEffUI != null)
		{
			RectTransform component = this.mEffUI.GetComponent<RectTransform>();
			for (int i = 0; i < component.childCount; i++)
			{
				Object.Destroy(component.GetChild(i).gameObject);
			}
			if (value)
			{
				GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadRes("Effects/UI/Prefab/EffUI_juqingguanka/Prefab/Eff_UI_juqingguanka_Jingyingdixiacheng", true, 0U).obj as GameObject;
				if (gameObject != null)
				{
					gameObject.transform.SetParent(component, false);
					gameObject.SetActive(true);
				}
			}
			this.mEffUI.CustomActive(this.mState != ComChapterDungeonUnit.eState.Locked);
		}
	}

	// Token: 0x0600931D RID: 37661 RVA: 0x001B6197 File Offset: 0x001B4597
	public void SetExtarLockTipText(string tipText)
	{
		this.mUnlockTipText.SafeSetText(tipText);
		this.mSpecialUnlockTipRoot.CustomActive(!string.IsNullOrEmpty(tipText));
	}

	// Token: 0x0600931E RID: 37662 RVA: 0x001B61B9 File Offset: 0x001B45B9
	public void ShowDungeonLvLimit(bool bShow)
	{
		this.mLvR.CustomActive(bShow);
	}

	// Token: 0x0600931F RID: 37663 RVA: 0x001B61C8 File Offset: 0x001B45C8
	public void SetEffect(string effectPath)
	{
		if (this.bIsLoadEffect)
		{
			return;
		}
		if (this.mEffectRoot != null)
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(effectPath, true, 0U);
			if (gameObject != null)
			{
				Utility.AttachTo(gameObject, this.mEffectRoot, false);
				this.bIsLoadEffect = true;
			}
		}
	}

	// Token: 0x06009320 RID: 37664 RVA: 0x001B6220 File Offset: 0x001B4620
	[Conditional("UNITY_EDITOR")]
	public void OnDrawGizmosSelected()
	{
		if (!Application.isPlaying)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(base.gameObject.transform.position, 20f);
			Gizmos.color = Color.white;
		}
	}

	// Token: 0x04004A0E RID: 18958
	public ComCommonBind mBind;

	// Token: 0x04004A0F RID: 18959
	private Text mName;

	// Token: 0x04004A10 RID: 18960
	private Text mLevel;

	// Token: 0x04004A11 RID: 18961
	private GameObject mLockRoot;

	// Token: 0x04004A12 RID: 18962
	private Text mTypeName;

	// Token: 0x04004A13 RID: 18963
	private GameObject mCheckRoot;

	// Token: 0x04004A14 RID: 18964
	private GameObject mNormalRoot;

	// Token: 0x04004A15 RID: 18965
	private ComChapterDungeonUnit mDungeonUnit;

	// Token: 0x04004A16 RID: 18966
	private GameObject mMissionFlag;

	// Token: 0x04004A17 RID: 18967
	private Toggle mSelect;

	// Token: 0x04004A18 RID: 18968
	private Image mBackground;

	// Token: 0x04004A19 RID: 18969
	private Image mCharactorIcon;

	// Token: 0x04004A1A RID: 18970
	private Text mOrderNumber;

	// Token: 0x04004A1B RID: 18971
	private RectTransform mSourcePosition;

	// Token: 0x04004A1C RID: 18972
	private RectTransform mTargetPosition;

	// Token: 0x04004A1D RID: 18973
	private RectTransform mTargetRightPosition;

	// Token: 0x04004A1E RID: 18974
	private TriangleGraph mAngleGraph;

	// Token: 0x04004A1F RID: 18975
	private RectTransform mThumbRoot;

	// Token: 0x04004A20 RID: 18976
	private GameObject mOpenEffect;

	// Token: 0x04004A21 RID: 18977
	private GameObject mEffectRoot;

	// Token: 0x04004A22 RID: 18978
	private GameObject challengeFlag;

	// Token: 0x04004A23 RID: 18979
	private GameObject mSpecialUnlockTipRoot;

	// Token: 0x04004A24 RID: 18980
	private Text mUnlockTipText;

	// Token: 0x04004A25 RID: 18981
	private HelpAssistant mHelp;

	// Token: 0x04004A26 RID: 18982
	private GameObject mLvR;

	// Token: 0x04004A27 RID: 18983
	private GameObject mEliteBg;

	// Token: 0x04004A28 RID: 18984
	private GameObject mEffUI;

	// Token: 0x04004A29 RID: 18985
	private Button mPreview;

	// Token: 0x04004A2A RID: 18986
	private Slider mUnlockProcess;

	// Token: 0x04004A2B RID: 18987
	private Text mUnlockValue;

	// Token: 0x04004A2C RID: 18988
	public ComChapterDungeonUnit.eMissionType mType;

	// Token: 0x04004A2D RID: 18989
	public ComChapterDungeonUnit.eState mState;

	// Token: 0x04004A2E RID: 18990
	public ComChapterDungeonUnit.eDungeonType mDungeonType;

	// Token: 0x04004A2F RID: 18991
	private int dungeonID;

	// Token: 0x04004A30 RID: 18992
	private bool mIsLock;

	// Token: 0x04004A31 RID: 18993
	private bool bIsLoadEffect;

	// Token: 0x04004A32 RID: 18994
	private const string eliteEffUIPath = "Effects/UI/Prefab/EffUI_juqingguanka/Prefab/Eff_UI_juqingguanka_Jingyingdixiacheng";

	// Token: 0x02000E83 RID: 3715
	public enum eMissionType
	{
		// Token: 0x04004A35 RID: 18997
		None = -1,
		// Token: 0x04004A36 RID: 18998
		Main,
		// Token: 0x04004A37 RID: 18999
		Other
	}

	// Token: 0x02000E84 RID: 3716
	public enum eState
	{
		// Token: 0x04004A39 RID: 19001
		Locked,
		// Token: 0x04004A3A RID: 19002
		Unlock,
		// Token: 0x04004A3B RID: 19003
		Passed,
		// Token: 0x04004A3C RID: 19004
		LockPassed
	}

	// Token: 0x02000E85 RID: 3717
	public enum eDungeonType
	{
		// Token: 0x04004A3E RID: 19006
		Normal,
		// Token: 0x04004A3F RID: 19007
		Prestory
	}
}
