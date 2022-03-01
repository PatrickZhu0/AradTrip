using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using GameClient;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02001005 RID: 4101
[LoggerModel("NewbieGuide")]
public class ComNewbieGuideBase : MonoBehaviour
{
	// Token: 0x06009BD4 RID: 39892 RVA: 0x001E1F2B File Offset: 0x001E032B
	public ComNewbieGuideBase()
	{
		this.mBaseState = ComNewbieGuideBase.eNewbieGuideBaseState.None;
	}

	// Token: 0x06009BD5 RID: 39893 RVA: 0x001E1F68 File Offset: 0x001E0368
	public void ClearData()
	{
		bool flag = SwitchFunctionUtility.IsOpen(14);
		this.mHighLightPointPath = string.Empty;
		this.mProtectTime = 0f;
		this.mTimeIntreval = 0f;
		this.mTryResumeBattle = false;
		this.mBaseState = ComNewbieGuideBase.eNewbieGuideBaseState.None;
		if (this.mTryPauseBattle)
		{
			this._tryResumeBattle();
		}
		else if (this.mTryPauseBattleAI)
		{
			this._tryResumeBattleEnemyAI();
		}
		for (int i = 0; i < this.mComponents.Count; i++)
		{
			if (this.mComponents[i] != null)
			{
				if (flag)
				{
					Canvas canvas = this.mComponents[i] as Canvas;
					if (canvas != null)
					{
						canvas.enabled = false;
					}
				}
				Object.Destroy(this.mComponents[i]);
			}
			this.mComponents[i] = null;
		}
		this.mComponents.Clear();
		for (int j = 0; j < this.mCachedObject.Count; j++)
		{
			GameObject gameObject = this.mCachedObject[j];
			if (gameObject != null)
			{
				Button[] componentsInChildren = gameObject.GetComponentsInChildren<Button>();
				int k = 0;
				int num = componentsInChildren.Length;
				while (k < num)
				{
					if (null != componentsInChildren[k])
					{
						componentsInChildren[k].onClick.RemoveAllListeners();
					}
					k++;
				}
				Toggle[] componentsInChildren2 = gameObject.GetComponentsInChildren<Toggle>();
				int l = 0;
				int num2 = componentsInChildren2.Length;
				while (l < num2)
				{
					if (null != componentsInChildren2[l])
					{
						componentsInChildren2[l].onValueChanged.RemoveAllListeners();
					}
					l++;
				}
				if (flag)
				{
					gameObject.CustomActive(false);
					Object.Destroy(gameObject, 0.1f);
				}
				else
				{
					Object.Destroy(gameObject);
				}
			}
			this.mCachedObject[j] = null;
		}
		this.mCachedObject.Clear();
		this.mTipsObject.Clear();
		this.mRootObject.Clear();
		Object.Destroy(this);
	}

	// Token: 0x06009BD6 RID: 39894 RVA: 0x001E2178 File Offset: 0x001E0578
	public virtual void StartInit(params object[] args)
	{
		this.mBaseState = ComNewbieGuideBase.eNewbieGuideBaseState.Init;
		this.mFrameType = string.Empty;
		this.mComRoot = string.Empty;
		this.mAnchor = ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft;
		this.mTextTips = string.Empty;
		this.mTextTipType = TextTipType.TextTipType_One;
		this.mLocalPos = default(Vector3);
		this.mProtectTime = 0f;
		this.mHighLightPointPath = string.Empty;
	}

	// Token: 0x06009BD7 RID: 39895 RVA: 0x001E21E0 File Offset: 0x001E05E0
	protected virtual ComNewbieGuideBase.GuideState _init()
	{
		return ComNewbieGuideBase.GuideState.Normal;
	}

	// Token: 0x06009BD8 RID: 39896 RVA: 0x001E21E3 File Offset: 0x001E05E3
	public void BaseComplete()
	{
		this.mBaseState = ComNewbieGuideBase.eNewbieGuideBaseState.Complete;
	}

	// Token: 0x06009BD9 RID: 39897 RVA: 0x001E21EC File Offset: 0x001E05EC
	public void SetShow(bool bShow)
	{
		if (bShow)
		{
			for (int i = 0; i < this.mCachedObject.Count; i++)
			{
				if (!(this.mCachedObject[i] == null))
				{
					this.mCachedObject[i].SetActive(true);
				}
			}
			for (int j = 0; j < this.mTipsObject.Count; j++)
			{
				if (!(this.mTipsObject[j] == null))
				{
					this.mTipsObject[j].SetActive(true);
				}
			}
		}
		else
		{
			for (int k = 0; k < this.mCachedObject.Count; k++)
			{
				if (!(this.mCachedObject[k] == null))
				{
					this.mCachedObject[k].SetActive(false);
				}
			}
			for (int l = 0; l < this.mTipsObject.Count; l++)
			{
				if (!(this.mTipsObject[l] == null))
				{
					this.mTipsObject[l].SetActive(false);
				}
			}
		}
	}

	// Token: 0x06009BDA RID: 39898 RVA: 0x001E232C File Offset: 0x001E072C
	protected void _complete(Button ClickBtn)
	{
		if (this.mGuideControl != null)
		{
			if (this.mTimeIntreval < this.mProtectTime)
			{
				return;
			}
			if (ClickBtn != null)
			{
				ClickBtn.enabled = false;
				ClickBtn.interactable = false;
			}
			this.mGuideControl.ControlComplete();
		}
		else if (ClickBtn != null)
		{
			Logger.LogErrorFormat("task base control is nil in [_complete] with button, ClickBtn Name = {0}", new object[]
			{
				ClickBtn.name
			});
		}
		else
		{
			Logger.LogError("task base control is nil in [_complete] with button");
		}
	}

	// Token: 0x06009BDB RID: 39899 RVA: 0x001E23BA File Offset: 0x001E07BA
	protected void _complete()
	{
		if (this.mGuideControl != null)
		{
			if (this.mTimeIntreval < this.mProtectTime)
			{
				return;
			}
			this.mGuideControl.ControlComplete();
		}
		else
		{
			Logger.LogError("task base control is nil in [_complete]");
		}
	}

	// Token: 0x06009BDC RID: 39900 RVA: 0x001E23FC File Offset: 0x001E07FC
	protected void _complete(bool bEnd)
	{
		if (this.mGuideControl != null)
		{
			if (this.mTimeIntreval < this.mProtectTime)
			{
				return;
			}
			this.mGuideControl.ControlComplete();
		}
		else
		{
			Logger.LogErrorFormat("task base control is nil, bEnd = {0}", new object[]
			{
				bEnd
			});
		}
	}

	// Token: 0x06009BDD RID: 39901 RVA: 0x001E2455 File Offset: 0x001E0855
	private void _wait()
	{
		if (this.mGuideControl != null)
		{
			this.mGuideControl.ControlWait();
		}
		else
		{
			Logger.LogError("task base control is nil in [_wait]");
		}
	}

	// Token: 0x06009BDE RID: 39902 RVA: 0x001E2482 File Offset: 0x001E0882
	protected void _exception()
	{
		if (this.mGuideControl != null)
		{
			this.mGuideControl.ControlException();
		}
		else
		{
			Logger.LogError("task base control is nil in [_exception]");
		}
	}

	// Token: 0x06009BDF RID: 39903 RVA: 0x001E24B0 File Offset: 0x001E08B0
	private void Update()
	{
		this.mTimeIntreval += Time.deltaTime;
		if (this.mBaseState == ComNewbieGuideBase.eNewbieGuideBaseState.Init)
		{
			ComNewbieGuideBase.GuideState guideState = this._init();
			if (guideState == ComNewbieGuideBase.GuideState.Normal)
			{
				this.mBaseState = ComNewbieGuideBase.eNewbieGuideBaseState.Guide;
			}
			else if (guideState == ComNewbieGuideBase.GuideState.Wait)
			{
				this._wait();
				this.mBaseState = ComNewbieGuideBase.eNewbieGuideBaseState.Guide;
			}
			else
			{
				this._exception();
				this.mBaseState = ComNewbieGuideBase.eNewbieGuideBaseState.Complete;
			}
		}
		else if (this.mBaseState == ComNewbieGuideBase.eNewbieGuideBaseState.Guide)
		{
			this._update();
			if (this.mTipsObject != null && this.mRootObject != null)
			{
				int num = 0;
				while (num < this.mTipsObject.Count && num < this.mRootObject.Count)
				{
					if (this.mTipsObject[num] != null && this.mRootObject[num] != null)
					{
						this._updateTipPosition(this.mTipsObject[num], this.mRootObject[num]);
					}
					num++;
				}
			}
		}
		else if (this.mBaseState == ComNewbieGuideBase.eNewbieGuideBaseState.Complete)
		{
			this.ClearData();
		}
	}

	// Token: 0x06009BE0 RID: 39904 RVA: 0x001E25D7 File Offset: 0x001E09D7
	private void OnDestroy()
	{
	}

	// Token: 0x06009BE1 RID: 39905 RVA: 0x001E25D9 File Offset: 0x001E09D9
	protected virtual void _update()
	{
	}

	// Token: 0x06009BE2 RID: 39906 RVA: 0x001E25DB File Offset: 0x001E09DB
	private void _save()
	{
		if (this.mGuideControl != null)
		{
			this.mGuideControl.ControlSave();
		}
		else
		{
			Logger.LogError("task base control is nil in [_save]");
		}
	}

	// Token: 0x06009BE3 RID: 39907 RVA: 0x001E2608 File Offset: 0x001E0A08
	public void SetTaskBaseNewbieGuideControl(ComNewbieGuideControl taskBase)
	{
		this.mGuideControl = taskBase;
	}

	// Token: 0x06009BE4 RID: 39908 RVA: 0x001E2614 File Offset: 0x001E0A14
	public void AddCanvasCom(GameObject obj, bool r = false)
	{
		if (obj == null)
		{
			return;
		}
		obj.layer = 5;
		Canvas canvas = obj.GetComponent<Canvas>();
		if (null == canvas)
		{
			canvas = obj.AddComponent<Canvas>();
			canvas.overrideSorting = true;
			canvas.sortingOrder = 805;
			this.mComponents.Add(canvas);
		}
		else
		{
			canvas.overrideSorting = true;
			canvas.sortingOrder = 805;
		}
		if (r)
		{
			for (int i = 0; i < obj.transform.childCount; i++)
			{
				this.AddCanvasCom(obj.transform.GetChild(i).gameObject, r);
			}
		}
	}

	// Token: 0x06009BE5 RID: 39909 RVA: 0x001E26C0 File Offset: 0x001E0AC0
	public void AddCanvasComEx(GameObject obj, bool r = false, int iLayer = 805)
	{
		if (obj == null)
		{
			return;
		}
		obj.layer = 5;
		Canvas canvas = obj.GetComponent<Canvas>();
		if (null == canvas)
		{
			canvas = obj.AddComponent<Canvas>();
			canvas.overrideSorting = true;
			canvas.sortingOrder = iLayer;
			this.mComponents.Add(canvas);
		}
		else
		{
			canvas.overrideSorting = true;
			canvas.sortingOrder = iLayer;
		}
		if (r)
		{
			for (int i = 0; i < obj.transform.childCount; i++)
			{
				this.AddCanvasComEx(obj.transform.GetChild(i).gameObject, r, iLayer + 1);
			}
		}
	}

	// Token: 0x06009BE6 RID: 39910 RVA: 0x001E2768 File Offset: 0x001E0B68
	public void _clickEffect()
	{
		for (int i = 0; i < this.mCachedObject.Count; i++)
		{
			GameObject gameObject = this.mCachedObject[i];
			if (!(gameObject == null))
			{
				if (gameObject.name == "NewbieButtonType")
				{
					GeUIEffectParticle[] componentsInChildren = gameObject.GetComponentsInChildren<GeUIEffectParticle>();
					for (int j = 0; j < componentsInChildren.Length; j++)
					{
						if (!(componentsInChildren[j].gameObject == null))
						{
							if (componentsInChildren[j].name == "UIEffectParticle")
							{
								componentsInChildren[j].RestartEmit();
								break;
							}
						}
					}
					break;
				}
			}
		}
	}

	// Token: 0x06009BE7 RID: 39911 RVA: 0x001E2820 File Offset: 0x001E0C20
	public void AddToCachedObject(GameObject go)
	{
		this.mCachedObject.Add(go);
	}

	// Token: 0x06009BE8 RID: 39912 RVA: 0x001E2830 File Offset: 0x001E0C30
	public GameObject AddButtonTips(GameObject buttonRoot, UnityAction action, GameObject fromRoot = null, float time = 1f)
	{
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/NewbieGuide/ButtonTips", true, 0U);
		gameObject.name = "NewbieButtonType";
		this.mCachedObject.Add(gameObject);
		GameObject button = Utility.FindGameObject(gameObject, "Button", true);
		if (button == null)
		{
			Logger.LogError("Add button is null when [AddButtonTips]");
			return null;
		}
		Button buttonCom = button.GetComponent<Button>();
		if (buttonCom == null)
		{
			Logger.LogError("Add buttonCom is null when [AddButtonTips]");
			return null;
		}
		buttonCom.onClick.AddListener(delegate()
		{
			if (action != null)
			{
				action.Invoke();
			}
			this._complete(buttonCom);
		});
		GameObject gameObject2 = Utility.FindGameObject(gameObject, "HGButton", true);
		if (gameObject2 == null)
		{
			Logger.LogError("Add HGbutton is null when [AddButtonTips]");
			return null;
		}
		gameObject2.gameObject.SetActive(false);
		GameObject gameObject3 = Utility.FindGameObject(gameObject, "click", true);
		if (gameObject3 == null)
		{
			Logger.LogError("Add clickobj is null when [AddButtonTips]");
			return null;
		}
		Button component = gameObject3.GetComponent<Button>();
		component.onClick.AddListener(new UnityAction(this._clickEffect));
		Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.TopLayer, false);
		gameObject.transform.SetAsLastSibling();
		this.AddCanvasCom(buttonRoot, false);
		this.mTipsObject.Add(button);
		this.mRootObject.Add(buttonRoot);
		GameObject tips = Utility.FindGameObject(button, "Finger", true);
		if (tips != null)
		{
			RectTransform component2 = tips.GetComponent<RectTransform>();
			this._updateFingerDirection(component2, this.mAnchor);
			if (fromRoot != null)
			{
				TweenSettingsExtensions.From<TweenerCore<Vector3, Vector3, VectorOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(DOTween.To(() => button.transform.localPosition, delegate(Vector3 r)
				{
					tips.transform.localPosition = r;
				}, fromRoot.transform.localPosition, time), 6));
			}
		}
		return button;
	}

	// Token: 0x06009BE9 RID: 39913 RVA: 0x001E2A38 File Offset: 0x001E0E38
	public GameObject AddHGButtonTips(GameObject buttonRoot, UnityAction<bool> action, GameObject fromRoot = null, float time = 1f)
	{
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/NewbieGuide/ButtonTips", true, 0U);
		gameObject.name = "NewbieButtonType";
		this.mCachedObject.Add(gameObject);
		GameObject button = Utility.FindGameObject(gameObject, "HGButton", true);
		HGButton component = button.GetComponent<HGButton>();
		component.onUpDown.AddListener(new UnityAction<bool>(this._complete));
		component.onUpDown.AddListener(action);
		GameObject gameObject2 = Utility.FindGameObject(gameObject, "Button", true);
		gameObject2.gameObject.SetActive(false);
		GameObject gameObject3 = Utility.FindGameObject(gameObject, "click", true);
		Button component2 = gameObject3.GetComponent<Button>();
		component2.onClick.AddListener(new UnityAction(this._clickEffect));
		Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.TopLayer, false);
		gameObject.transform.SetAsLastSibling();
		this.AddCanvasCom(buttonRoot, false);
		this.mTipsObject.Add(button);
		this.mRootObject.Add(buttonRoot);
		GameObject tips = Utility.FindGameObject(button, "Finger", true);
		if (tips != null)
		{
			RectTransform component3 = tips.GetComponent<RectTransform>();
			this._updateFingerDirection(component3, this.mAnchor);
			if (fromRoot != null)
			{
				TweenSettingsExtensions.From<TweenerCore<Vector3, Vector3, VectorOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(DOTween.To(() => button.transform.localPosition, delegate(Vector3 r)
				{
					tips.transform.localPosition = r;
				}, fromRoot.transform.localPosition, time), 6));
			}
		}
		return button;
	}

	// Token: 0x06009BEA RID: 39914 RVA: 0x001E2BCC File Offset: 0x001E0FCC
	public GameObject AddBattleDrugDrag(GameObject buttonRoot, UnityAction action, GameObject fromRoot = null, float time = 1f)
	{
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/NewbieGuide/BattleDrugDragTips", true, 0U);
		gameObject.name = "NewbieDrugDragType";
		this.mCachedObject.Add(gameObject);
		GameObject button = Utility.FindGameObject(gameObject, "Button", true);
		if (button == null)
		{
			Logger.LogError("Add button is null when [AddButtonTips]");
			return null;
		}
		Button buttonCom = button.GetComponent<Button>();
		if (buttonCom == null)
		{
			Logger.LogError("Add buttonCom is null when [AddButtonTips]");
			return null;
		}
		buttonCom.onClick.AddListener(delegate()
		{
			if (action != null)
			{
				action.Invoke();
			}
			this._complete(buttonCom);
		});
		GameObject gameObject2 = Utility.FindGameObject(gameObject, "click", true);
		if (gameObject2 == null)
		{
			Logger.LogError("Add clickobj is null when [AddButtonTips]");
			return null;
		}
		Button component = gameObject2.GetComponent<Button>();
		component.onClick.AddListener(new UnityAction(this._clickEffect));
		Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.TopLayer, false);
		gameObject.transform.SetAsLastSibling();
		this.AddCanvasCom(buttonRoot, false);
		this.mTipsObject.Add(button);
		this.mRootObject.Add(buttonRoot);
		GameObject tips = Utility.FindGameObject(button, "Finger", true);
		if (tips != null)
		{
			RectTransform component2 = tips.GetComponent<RectTransform>();
			this._updateFingerDirection(component2, this.mAnchor);
			if (fromRoot != null)
			{
				TweenSettingsExtensions.From<TweenerCore<Vector3, Vector3, VectorOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(DOTween.To(() => button.transform.localPosition, delegate(Vector3 r)
				{
					tips.transform.localPosition = r;
				}, fromRoot.transform.localPosition, time), 6));
			}
		}
		return button;
	}

	// Token: 0x06009BEB RID: 39915 RVA: 0x001E2DA0 File Offset: 0x001E11A0
	public GameObject AddButtonTipNoAutoComplete(GameObject buttonRoot, UnityAction action, GameObject fromRoot = null, float time = 1f)
	{
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/NewbieGuide/ButtonTipsDrag", true, 0U);
		gameObject.name = "NewbieButtonType";
		this.mCachedObject.Add(gameObject);
		GameObject button = Utility.FindGameObject(gameObject, "Button", true);
		GameObject gameObject2 = Utility.FindGameObject(gameObject, "click", true);
		Button component = gameObject2.GetComponent<Button>();
		component.onClick.AddListener(new UnityAction(this._clickEffect));
		Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.TopLayer, false);
		gameObject.transform.SetAsLastSibling();
		this.mTipsObject.Add(button);
		this.mRootObject.Add(buttonRoot);
		GameObject tips = Utility.FindGameObject(button, "Finger", true);
		if (tips != null)
		{
			RectTransform component2 = tips.GetComponent<RectTransform>();
			this._updateFingerDirection(component2, this.mAnchor);
			if (fromRoot != null)
			{
				TweenSettingsExtensions.From<TweenerCore<Vector3, Vector3, VectorOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(DOTween.To(() => button.transform.localPosition, delegate(Vector3 r)
				{
					tips.transform.localPosition = r;
				}, fromRoot.transform.localPosition, time), 6));
			}
		}
		return gameObject;
	}

	// Token: 0x06009BEC RID: 39916 RVA: 0x001E2ED8 File Offset: 0x001E12D8
	public GameObject AddIntroductionTips(GameObject buttonRoot)
	{
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/NewbieGuide/IntroductionTips", true, 0U);
		this.mCachedObject.Add(gameObject);
		GameObject gameObject2 = Utility.FindGameObject(gameObject, "Button", true);
		Button buttonCom = gameObject2.GetComponent<Button>();
		buttonCom.onClick.AddListener(delegate()
		{
			this._complete(buttonCom);
		});
		this.AddCanvasCom(buttonRoot, false);
		GameObject gameObject3 = Utility.FindGameObject(gameObject, "Pos", true);
		Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.TopLayer, false);
		gameObject.transform.SetAsLastSibling();
		this.mTipsObject.Add(gameObject3);
		this.mRootObject.Add(buttonRoot);
		return gameObject3;
	}

	// Token: 0x06009BED RID: 39917 RVA: 0x001E2F90 File Offset: 0x001E1390
	public void AddIntroductionTips2()
	{
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/NewbieGuide/IntroductionTips2", true, 0U);
		this.mCachedObject.Add(gameObject);
		GameObject gameObject2 = Utility.FindGameObject(gameObject, "Button", true);
		Button buttonCom = gameObject2.GetComponent<Button>();
		buttonCom.onClick.AddListener(delegate()
		{
			this._complete(buttonCom);
		});
		GameObject gameObject3 = Utility.FindGameObject(gameObject, "middle/content", true);
		Text component = gameObject3.GetComponent<Text>();
		component.text = this.mTextTips;
		Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.TopLayer, false);
		gameObject.transform.SetAsLastSibling();
	}

	// Token: 0x06009BEE RID: 39918 RVA: 0x001E303C File Offset: 0x001E143C
	public GameObject AddPassThroughTips(GameObject buttonRoot, GameObject ShowAreaRoot, UnityAction action)
	{
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/NewbieGuide/PassThroughTips", true, 0U);
		this.mCachedObject.Add(gameObject);
		GameObject gameObject2 = Utility.FindGameObject(gameObject, "Button", true);
		Button buttonCom = gameObject2.GetComponent<Button>();
		buttonCom.onClick.AddListener(delegate()
		{
			this._complete(buttonCom);
		});
		buttonCom.onClick.AddListener(action);
		Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.TopLayer, false);
		gameObject.transform.SetAsLastSibling();
		GameObject gameObject3 = Utility.FindGameObject(gameObject, "ShowArea", true);
		if (ShowAreaRoot != null)
		{
			this.mTipsObject.Add(gameObject3);
			this.mRootObject.Add(ShowAreaRoot);
		}
		else
		{
			gameObject3.SetActive(false);
		}
		return gameObject3;
	}

	// Token: 0x06009BEF RID: 39919 RVA: 0x001E3114 File Offset: 0x001E1514
	public bool AddShowImage(string ShowImagePath)
	{
		Sprite sprite = Singleton<AssetLoader>.instance.LoadRes(ShowImagePath, typeof(Sprite), true, 0U).obj as Sprite;
		if (sprite == null)
		{
			return false;
		}
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/NewbieGuide/ShowImage", true, 0U);
		this.mCachedObject.Add(gameObject);
		GameObject gameObject2 = Utility.FindGameObject(gameObject, "Button", true);
		Button buttonCom = gameObject2.GetComponent<Button>();
		buttonCom.onClick.AddListener(delegate()
		{
			this._complete(buttonCom);
		});
		GameObject gameObject3 = Utility.FindGameObject(gameObject, "pos", true);
		Image component = gameObject3.GetComponent<Image>();
		ETCImageLoader.LoadSprite(ref component, ShowImagePath, true);
		Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.TopLayer, false);
		gameObject.transform.SetAsLastSibling();
		return true;
	}

	// Token: 0x06009BF0 RID: 39920 RVA: 0x001E31F0 File Offset: 0x001E15F0
	public bool AddStress(GameObject SourceObj)
	{
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/NewbieGuide/Stress", true, 0U);
		this.mCachedObject.Add(gameObject);
		Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.TopLayer, false);
		gameObject.transform.SetAsLastSibling();
		this.AddCanvasCom(SourceObj, false);
		this.mRootObject.Add(SourceObj);
		GameObject item = Utility.FindGameObject(gameObject, "pos", true);
		this.mTipsObject.Add(item);
		return true;
	}

	// Token: 0x06009BF1 RID: 39921 RVA: 0x001E3268 File Offset: 0x001E1668
	public bool AddOpenEyes()
	{
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/NewbieGuide/guidetownstart", true, 0U);
		this.mCachedObject.Add(gameObject);
		Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.TopLayer, false);
		gameObject.transform.SetAsLastSibling();
		return true;
	}

	// Token: 0x06009BF2 RID: 39922 RVA: 0x001E32B0 File Offset: 0x001E16B0
	public GameObject AddWaitTips(GameObject buttonRoot, bool mbPathThrough)
	{
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/NewbieGuide/WaitTips", true, 0U);
		this.mCachedObject.Add(gameObject);
		if (buttonRoot != null)
		{
			this.AddCanvasCom(buttonRoot, false);
		}
		GameObject gameObject2 = Utility.FindGameObject(gameObject, "Pos", true);
		Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.TopLayer, false);
		gameObject.transform.SetAsLastSibling();
		if (mbPathThrough)
		{
			GameObject gameObject3 = Utility.FindGameObject(gameObject, "cover", true);
			gameObject3.GetComponentInChildren<Image>().raycastTarget = false;
		}
		this.mTipsObject.Add(gameObject2);
		if (buttonRoot != null)
		{
			this.mRootObject.Add(buttonRoot);
		}
		return gameObject2;
	}

	// Token: 0x06009BF3 RID: 39923 RVA: 0x001E335C File Offset: 0x001E175C
	public void AddWaitTips()
	{
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/NewbieGuide/WaitTips", true, 0U);
		this.mCachedObject.Add(gameObject);
		Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.TopLayer, false);
		gameObject.transform.SetAsLastSibling();
		GameObject gameObject2 = Utility.FindGameObject(gameObject, "Pos", true);
		gameObject2.SetActive(false);
		GameObject gameObject3 = Utility.FindGameObject(gameObject, "cover", true);
		gameObject3.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
	}

	// Token: 0x06009BF4 RID: 39924 RVA: 0x001E33E8 File Offset: 0x001E17E8
	public GameObject AddCover()
	{
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/NewbieGuide/Cover", true, 0U);
		this.mCachedObject.Add(gameObject);
		Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.TopLayer, false);
		gameObject.transform.SetAsLastSibling();
		return gameObject;
	}

	// Token: 0x06009BF5 RID: 39925 RVA: 0x001E3430 File Offset: 0x001E1830
	public bool AddNewIconUnlock(string LoadResFile, string TargetRootPath, string IconPath, string IconName)
	{
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(LoadResFile, true, 0U);
		if (gameObject == null)
		{
			return false;
		}
		this.mCachedObject.Add(gameObject);
		Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.TopLayer, false);
		gameObject.transform.SetAsLastSibling();
		if (TargetRootPath != string.Empty)
		{
			GameObject gameObject2 = Utility.FindGameObject(TargetRootPath, true);
			if (gameObject2 != null)
			{
				GameObject gameObject3 = Utility.FindGameObject(gameObject, "bg", true);
				if (gameObject3 != null)
				{
					RectTransform child = gameObject3.GetComponent<RectTransform>();
					RectTransform component = gameObject2.GetComponent<RectTransform>();
					Vector3 position = component.position;
					Tweener tweener = DOTween.To(() => child.position, delegate(Vector3 r)
					{
						child.position = r;
					}, position, 1f);
					TweenSettingsExtensions.SetDelay<Tweener>(tweener, 1f);
					TweenSettingsExtensions.SetEase<Tweener>(tweener, 1);
				}
			}
		}
		if (IconPath != string.Empty)
		{
			GameObject gameObject4 = Utility.FindGameObject(gameObject, "bg/Icon", true);
			if (gameObject4 == null)
			{
				return false;
			}
			Image component2 = gameObject4.GetComponent<Image>();
			ETCImageLoader.LoadSprite(ref component2, IconPath, true);
		}
		if (IconName != string.Empty)
		{
			GameObject gameObject5 = Utility.FindGameObject(gameObject, "bg/Name", true);
			if (gameObject5 == null)
			{
				return false;
			}
			Text component3 = gameObject5.GetComponent<Text>();
			component3.text = IconName;
		}
		return true;
	}

	// Token: 0x06009BF6 RID: 39926 RVA: 0x001E35A0 File Offset: 0x001E19A0
	public bool AddEffect(string LoadResFile)
	{
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(LoadResFile, true, 0U);
		if (gameObject == null)
		{
			return false;
		}
		this.mCachedObject.Add(gameObject);
		Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.TopLayer, false);
		gameObject.transform.SetAsLastSibling();
		return true;
	}

	// Token: 0x06009BF7 RID: 39927 RVA: 0x001E35F4 File Offset: 0x001E19F4
	public GameObject AddTouchedTips(GameObject buttonRoot, UnityAction action, UnityAction up)
	{
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/NewbieGuide/TouchTips", true, 0U);
		this.mCachedObject.Add(gameObject);
		GameObject gameObject2 = Utility.FindGameObject(gameObject, "Drag", true);
		ETCTouchPad buttonCom = gameObject2.GetComponent<ETCTouchPad>();
		buttonCom.onTouchStart.AddListener(action);
		buttonCom.onTouchUp.AddListener(up);
		buttonCom.onTouchUp.AddListener(delegate()
		{
			this._complete(buttonCom);
		});
		Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.TopLayer, false);
		gameObject.transform.SetAsLastSibling();
		this.mTipsObject.Add(gameObject2);
		this.mRootObject.Add(buttonRoot);
		return gameObject2;
	}

	// Token: 0x06009BF8 RID: 39928 RVA: 0x001E36B8 File Offset: 0x001E1AB8
	public GameObject AddDragTips(GameObject root, UnityAction<Vector2> move, UnityAction up, ComNewbieGuideBase.eNewbieGuideAnchor anchor)
	{
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/NewbieGuide/DragTips", true, 0U);
		this.mCachedObject.Add(gameObject);
		GameObject gameObject2 = Utility.FindGameObject(gameObject, "Drag", true);
		ETCTouchPad component = gameObject2.GetComponent<ETCTouchPad>();
		Image component2 = gameObject2.GetComponent<Image>();
		component2.enabled = false;
		Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.TopLayer, false);
		gameObject.transform.SetAsLastSibling();
		this._updateTipPosition(gameObject2, root);
		return gameObject2;
	}

	// Token: 0x06009BF9 RID: 39929 RVA: 0x001E372C File Offset: 0x001E1B2C
	public GameObject AddTextTips(GameObject root, ComNewbieGuideBase.eNewbieGuideAnchor anchor, string content, TextTipType eTextTipType = TextTipType.TextTipType_One, Vector3 localPos = default(Vector3))
	{
		if (root == null)
		{
			Logger.LogError("root is nil");
			return null;
		}
		if (string.IsNullOrEmpty(content))
		{
			return null;
		}
		GameObject gameObject;
		if (eTextTipType == TextTipType.TextTipType_One)
		{
			gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/NewbieGuide/TextTips", true, 0U);
		}
		else if (eTextTipType == TextTipType.TextTipType_Two)
		{
			gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/NewbieGuide/TextTipsTwo", true, 0U);
		}
		else if (eTextTipType == TextTipType.TextTipType_Three)
		{
			gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/NewbieGuide/TextTipsThree", true, 0U);
		}
		else
		{
			gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/NewbieGuide/TextTips", true, 0U);
		}
		if (gameObject == null)
		{
			return null;
		}
		this._updateAnchor(gameObject.GetComponent<RectTransform>(), anchor, localPos);
		GameObject gameObject2 = Utility.FindGameObject(gameObject, "Text", true);
		Text component = gameObject2.GetComponent<Text>();
		component.text = content;
		Utility.AttachTo(gameObject, root, false);
		this.mCachedObject.Add(gameObject);
		return gameObject;
	}

	// Token: 0x06009BFA RID: 39930 RVA: 0x001E381C File Offset: 0x001E1C1C
	public void AddLoopTips(GameObject root, ComNewbieGuideBase.eNewbieGuideAnchor anchor)
	{
		GameObject item = Singleton<AssetLoader>.instance.LoadResAsGameObject(string.Empty, true, 0U);
		this.mCachedObject.Add(item);
	}

	// Token: 0x06009BFB RID: 39931 RVA: 0x001E3848 File Offset: 0x001E1C48
	private void _updateTipPosition(GameObject tips, GameObject root)
	{
		RectTransform component = root.GetComponent<RectTransform>();
		RectTransform component2 = tips.GetComponent<RectTransform>();
		component2.position = component.position;
		component2.pivot = component.pivot;
		component2.anchorMin = new Vector2(0.5f, 0.5f);
		component2.anchorMax = new Vector2(0.5f, 0.5f);
		Rect rect = component.rect;
		component2.sizeDelta = new Vector2(rect.width, rect.height);
	}

	// Token: 0x06009BFC RID: 39932 RVA: 0x001E38C5 File Offset: 0x001E1CC5
	private void _tryPauseBattle()
	{
	}

	// Token: 0x06009BFD RID: 39933 RVA: 0x001E38C7 File Offset: 0x001E1CC7
	private void _tryResumeBattle()
	{
	}

	// Token: 0x06009BFE RID: 39934 RVA: 0x001E38CC File Offset: 0x001E1CCC
	private void _tryResumeBattleEnemyAI()
	{
		BeScene main = BattleMain.instance.Main;
		if (main != null)
		{
			main.isTickAI = true;
		}
	}

	// Token: 0x06009BFF RID: 39935 RVA: 0x001E38F4 File Offset: 0x001E1CF4
	private void _tryPauseBattleEnemyAI()
	{
		BeScene main = BattleMain.instance.Main;
		if (main != null)
		{
			main.isTickAI = false;
		}
	}

	// Token: 0x06009C00 RID: 39936 RVA: 0x001E3919 File Offset: 0x001E1D19
	public void AddFingerTips()
	{
	}

	// Token: 0x06009C01 RID: 39937 RVA: 0x001E391C File Offset: 0x001E1D1C
	public bool AddDialog(int id, UnityAction action)
	{
		TaskDialogFrame.OnDialogOver onDialogOver = new TaskDialogFrame.OnDialogOver();
		onDialogOver.AddListener(new UnityAction(this._complete));
		if (action != null)
		{
			onDialogOver.AddListener(action);
		}
		DataManager<MissionManager>.GetInstance().CloseAllDialog();
		return DataManager<MissionManager>.GetInstance().CreateDialogFrame(id, 0, onDialogOver) != null;
	}

	// Token: 0x06009C02 RID: 39938 RVA: 0x001E3971 File Offset: 0x001E1D71
	public void RemoveButtonTips()
	{
	}

	// Token: 0x06009C03 RID: 39939 RVA: 0x001E3973 File Offset: 0x001E1D73
	public void RemoveFingerTips()
	{
	}

	// Token: 0x06009C04 RID: 39940 RVA: 0x001E3978 File Offset: 0x001E1D78
	private void _updateAnchor(RectTransform rect, ComNewbieGuideBase.eNewbieGuideAnchor anchor, Vector3 localPos = default(Vector3))
	{
		switch (anchor)
		{
		case ComNewbieGuideBase.eNewbieGuideAnchor.Top:
			rect.anchorMin = new Vector2(0.5f, 1f);
			rect.anchorMax = new Vector2(0.5f, 1f);
			rect.pivot = new Vector2(0.5f, 0f);
			break;
		case ComNewbieGuideBase.eNewbieGuideAnchor.Buttom:
			rect.anchorMin = new Vector2(0.5f, 0f);
			rect.anchorMax = new Vector2(0.5f, 0f);
			rect.pivot = new Vector2(0.5f, 1f);
			break;
		case ComNewbieGuideBase.eNewbieGuideAnchor.Left:
			rect.anchorMin = new Vector2(0f, 0.5f);
			rect.anchorMax = new Vector2(0f, 0.5f);
			rect.pivot = new Vector2(1f, 0.5f);
			break;
		case ComNewbieGuideBase.eNewbieGuideAnchor.Right:
			rect.anchorMin = new Vector2(1f, 0.5f);
			rect.anchorMax = new Vector2(1f, 0.5f);
			rect.pivot = new Vector2(0f, 0.5f);
			break;
		case ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft:
			rect.anchorMin = new Vector2(0f, 1f);
			rect.anchorMax = new Vector2(0f, 1f);
			rect.pivot = new Vector2(1f, 0f);
			break;
		case ComNewbieGuideBase.eNewbieGuideAnchor.TopRight:
			rect.anchorMin = new Vector2(1f, 1f);
			rect.anchorMax = new Vector2(1f, 1f);
			rect.pivot = new Vector2(0f, 0f);
			break;
		case ComNewbieGuideBase.eNewbieGuideAnchor.ButtomLeft:
			rect.anchorMin = new Vector2(0f, 0f);
			rect.anchorMax = new Vector2(0f, 0f);
			rect.pivot = new Vector2(1f, 1f);
			break;
		case ComNewbieGuideBase.eNewbieGuideAnchor.ButtomRight:
			rect.anchorMin = new Vector2(1f, 0f);
			rect.anchorMax = new Vector2(1f, 0f);
			rect.pivot = new Vector2(0f, 1f);
			break;
		case ComNewbieGuideBase.eNewbieGuideAnchor.Center:
			rect.anchorMin = new Vector2(0.5f, 0.5f);
			rect.anchorMax = new Vector2(0.5f, 0.5f);
			rect.pivot = new Vector2(0.5f, 0f);
			break;
		}
		rect.localPosition = localPos;
	}

	// Token: 0x06009C05 RID: 39941 RVA: 0x001E3C20 File Offset: 0x001E2020
	private void _updateFingerDirection(RectTransform rect, ComNewbieGuideBase.eNewbieGuideAnchor anchor)
	{
		switch (anchor)
		{
		case ComNewbieGuideBase.eNewbieGuideAnchor.Top:
		{
			Quaternion localRotation = rect.localRotation;
			localRotation.z = 140f;
			rect.localRotation = localRotation;
			break;
		}
		case ComNewbieGuideBase.eNewbieGuideAnchor.Buttom:
		{
			Quaternion localRotation2 = rect.localRotation;
			localRotation2.z = -40f;
			rect.localRotation = localRotation2;
			break;
		}
		case ComNewbieGuideBase.eNewbieGuideAnchor.Left:
		{
			Quaternion localRotation3 = rect.localRotation;
			localRotation3.z = 122f;
			rect.localRotation = localRotation3;
			break;
		}
		case ComNewbieGuideBase.eNewbieGuideAnchor.Right:
		{
			Quaternion localRotation4 = rect.localRotation;
			localRotation4.z = 55f;
			rect.localRotation = localRotation4;
			break;
		}
		case ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft:
			rect.localScale = new Vector3(-1f, -1f, 1f);
			rect.localRotation = Quaternion.Euler(0f, 0f, 0f);
			break;
		case ComNewbieGuideBase.eNewbieGuideAnchor.TopRight:
			rect.localScale = new Vector3(1f, -1f, 1f);
			rect.localRotation = Quaternion.Euler(0f, 0f, 0f);
			break;
		case ComNewbieGuideBase.eNewbieGuideAnchor.ButtomLeft:
			rect.localScale = new Vector3(-1f, 1f, 1f);
			rect.localRotation = Quaternion.Euler(0f, 0f, 0f);
			break;
		case ComNewbieGuideBase.eNewbieGuideAnchor.ButtomRight:
			rect.localScale = new Vector3(1f, 1f, 1f);
			rect.localRotation = Quaternion.Euler(0f, 0f, 0f);
			break;
		case ComNewbieGuideBase.eNewbieGuideAnchor.Center:
		{
			Quaternion localRotation5 = rect.localRotation;
			localRotation5.z = 45f;
			rect.localRotation = localRotation5;
			break;
		}
		}
	}

	// Token: 0x0400554B RID: 21835
	private const string kButtonTipsPath = "UIFlatten/Prefabs/NewbieGuide/ButtonTips";

	// Token: 0x0400554C RID: 21836
	private const string kDragTipsPath = "UIFlatten/Prefabs/NewbieGuide/DragTips";

	// Token: 0x0400554D RID: 21837
	private const string kTouchTipsPath = "UIFlatten/Prefabs/NewbieGuide/TouchTips";

	// Token: 0x0400554E RID: 21838
	private const string kIntroductionTipsPath = "UIFlatten/Prefabs/NewbieGuide/IntroductionTips";

	// Token: 0x0400554F RID: 21839
	private const string kIntroductionTipsPath2 = "UIFlatten/Prefabs/NewbieGuide/IntroductionTips2";

	// Token: 0x04005550 RID: 21840
	private const string kPassThroughTipsPath = "UIFlatten/Prefabs/NewbieGuide/PassThroughTips";

	// Token: 0x04005551 RID: 21841
	public const string kWaitTipsPath = "UIFlatten/Prefabs/NewbieGuide/WaitTips";

	// Token: 0x04005552 RID: 21842
	private const string kCoverPath = "UIFlatten/Prefabs/NewbieGuide/Cover";

	// Token: 0x04005553 RID: 21843
	private const string kShowImagePath = "UIFlatten/Prefabs/NewbieGuide/ShowImage";

	// Token: 0x04005554 RID: 21844
	private const string kTextTipsOnePath = "UIFlatten/Prefabs/NewbieGuide/TextTips";

	// Token: 0x04005555 RID: 21845
	private const string kTextTipsTwoPath = "UIFlatten/Prefabs/NewbieGuide/TextTipsTwo";

	// Token: 0x04005556 RID: 21846
	private const string kTextTipsThreePath = "UIFlatten/Prefabs/NewbieGuide/TextTipsThree";

	// Token: 0x04005557 RID: 21847
	private const string kFingerTipsPath = "";

	// Token: 0x04005558 RID: 21848
	private const string kLoopTipsPath = "";

	// Token: 0x04005559 RID: 21849
	private const string kStressPath = "UIFlatten/Prefabs/NewbieGuide/Stress";

	// Token: 0x0400555A RID: 21850
	private const string kOpenEyesPath = "UIFlatten/Prefabs/NewbieGuide/guidetownstart";

	// Token: 0x0400555B RID: 21851
	private const string kBattleDrugDrag = "UIFlatten/Prefabs/NewbieGuide/BattleDrugDragTips";

	// Token: 0x0400555C RID: 21852
	protected ComNewbieGuideControl mGuideControl;

	// Token: 0x0400555D RID: 21853
	protected ComNewbieGuideBase.eNewbieGuideBaseState mBaseState;

	// Token: 0x0400555E RID: 21854
	public int mSortOrder;

	// Token: 0x0400555F RID: 21855
	public bool mIsButton;

	// Token: 0x04005560 RID: 21856
	public bool mIsFinger;

	// Token: 0x04005561 RID: 21857
	private float mTimeIntreval;

	// Token: 0x04005562 RID: 21858
	protected List<GameObject> mCachedObject = new List<GameObject>();

	// Token: 0x04005563 RID: 21859
	private List<GameObject> mTipsObject = new List<GameObject>();

	// Token: 0x04005564 RID: 21860
	private List<GameObject> mRootObject = new List<GameObject>();

	// Token: 0x04005565 RID: 21861
	private List<Component> mComponents = new List<Component>();

	// Token: 0x04005566 RID: 21862
	public string mFrameType;

	// Token: 0x04005567 RID: 21863
	public string mComRoot;

	// Token: 0x04005568 RID: 21864
	public ComNewbieGuideBase.eNewbieGuideAnchor mAnchor;

	// Token: 0x04005569 RID: 21865
	public string mHighLightPointPath;

	// Token: 0x0400556A RID: 21866
	public string mTextTips;

	// Token: 0x0400556B RID: 21867
	public TextTipType mTextTipType;

	// Token: 0x0400556C RID: 21868
	public Vector3 mLocalPos;

	// Token: 0x0400556D RID: 21869
	public bool mSendSaveBoot;

	// Token: 0x0400556E RID: 21870
	public bool mTryPauseBattle;

	// Token: 0x0400556F RID: 21871
	public bool mTryResumeBattle;

	// Token: 0x04005570 RID: 21872
	public bool mTryPauseBattleAI;

	// Token: 0x04005571 RID: 21873
	public float mProtectTime;

	// Token: 0x02001006 RID: 4102
	protected enum eNewbieGuideBaseState
	{
		// Token: 0x04005573 RID: 21875
		None,
		// Token: 0x04005574 RID: 21876
		Init,
		// Token: 0x04005575 RID: 21877
		Guide,
		// Token: 0x04005576 RID: 21878
		Complete
	}

	// Token: 0x02001007 RID: 4103
	public enum GuideState
	{
		// Token: 0x04005578 RID: 21880
		Normal,
		// Token: 0x04005579 RID: 21881
		Wait,
		// Token: 0x0400557A RID: 21882
		Exception
	}

	// Token: 0x02001008 RID: 4104
	public enum eNewbieGuideAnchor
	{
		// Token: 0x0400557C RID: 21884
		Top,
		// Token: 0x0400557D RID: 21885
		Buttom,
		// Token: 0x0400557E RID: 21886
		Left,
		// Token: 0x0400557F RID: 21887
		Right,
		// Token: 0x04005580 RID: 21888
		TopLeft,
		// Token: 0x04005581 RID: 21889
		TopRight,
		// Token: 0x04005582 RID: 21890
		ButtomLeft,
		// Token: 0x04005583 RID: 21891
		ButtomRight,
		// Token: 0x04005584 RID: 21892
		Center
	}
}
