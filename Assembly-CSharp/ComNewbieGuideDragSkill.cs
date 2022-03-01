using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using GameClient;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000FEE RID: 4078
public class ComNewbieGuideDragSkill : ComNewbieGuideBase
{
	// Token: 0x06009B86 RID: 39814 RVA: 0x001E479C File Offset: 0x001E2B9C
	public sealed override void StartInit(params object[] args)
	{
		base.StartInit(args);
		if (args != null)
		{
			this.guideDrag1 = default(ComNewbieGuideDragSkill.stButtonTipsGuideArg);
			int num = 0;
			this.guideDrag1.DecodeFromArgs(args, ref num);
			this.guideDrag2.DecodeFromArgs(args, ref num);
			int num2 = args.Length - num;
			if (num2 >= 1 && (eNewbieGuideAgrsName)args[num] == eNewbieGuideAgrsName.SaveBoot)
			{
				this.mSendSaveBoot = true;
			}
			if (num2 >= 2 && (eNewbieGuideAgrsName)args[num + 1] == eNewbieGuideAgrsName.PauseBattle)
			{
				this.mTryPauseBattle = true;
			}
			if (num2 >= 3 && args[8] as string != string.Empty)
			{
				this.mHighLightPointPath = (args[num + 2] as string);
			}
		}
	}

	// Token: 0x06009B87 RID: 39815 RVA: 0x001E4854 File Offset: 0x001E2C54
	private GameObject LoadGuidePrefab(string path, int canvasOrder = 805)
	{
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(path, true, 0U);
		gameObject.name = "NewbieButtonType";
		this.mCachedObject.Add(gameObject);
		Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.TopLayer, false);
		gameObject.transform.SetAsLastSibling();
		if (gameObject.GetComponent<GraphicRaycaster>() == null)
		{
			gameObject.AddComponent<GraphicRaycaster>();
		}
		if (canvasOrder > 0)
		{
			base.AddCanvasComEx(gameObject, false, canvasOrder);
		}
		return gameObject;
	}

	// Token: 0x06009B88 RID: 39816 RVA: 0x001E48CC File Offset: 0x001E2CCC
	private void SyncPosition(GameObject tips, GameObject root)
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

	// Token: 0x06009B89 RID: 39817 RVA: 0x001E494C File Offset: 0x001E2D4C
	private IEnumerator TweenShow(RectTransform dragRect, RectTransform startRect, RectTransform endRect, float waittime, float loopDurarion)
	{
		yield return Yielders.GetWaitForSeconds(waittime);
		dragRect.gameObject.CustomActive(true);
		dragRect.position = startRect.position;
		this.dragTween = TweenSettingsExtensions.SetLoops<TweenerCore<Vector3, Vector3, VectorOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(DOTween.To(() => dragRect.position, delegate(Vector3 pos)
		{
			dragRect.position = pos;
		}, endRect.position, loopDurarion), 6), -1);
		if (this.dragTween != null)
		{
			this.dragTween.target = dragRect.gameObject;
		}
		yield break;
	}

	// Token: 0x06009B8A RID: 39818 RVA: 0x001E498C File Offset: 0x001E2D8C
	protected sealed override ComNewbieGuideBase.GuideState _init()
	{
		IGameBind gameBind = this._getBind(this.guideDrag1);
		IGameBind gameBind2 = this._getBind(this.guideDrag2);
		if (gameBind == null || gameBind2 == null)
		{
			Logger.LogError("SkillGuide Error, �����ϸ������Ͻ����㱨�����Ҫ��ӡ����ͳ��");
			return ComNewbieGuideBase.GuideState.Wait;
		}
		RectTransform component = gameBind.GetComponent<RectTransform>(this.guideDrag1.MComRoot);
		if (component == null)
		{
			Logger.LogError("SkillGuide Error, dragRoot == null");
			return ComNewbieGuideBase.GuideState.Exception;
		}
		base.AddCanvasCom(component.gameObject, false);
		GraphicRaycaster g1 = component.gameObject.AddComponent<GraphicRaycaster>();
		RectTransform component2 = gameBind2.GetComponent<RectTransform>(this.guideDrag2.MComRoot);
		if (component2 == null)
		{
			Logger.LogError("SkillGuide Error, dropRoot == null");
			return ComNewbieGuideBase.GuideState.Exception;
		}
		base.AddCanvasCom(component2.gameObject, false);
		GraphicRaycaster g2 = component2.gameObject.AddComponent<GraphicRaycaster>();
		this.LoadGuidePrefab("UIFlatten/Prefabs/NewbieGuide/BgMask", 800);
		GameObject gameObject = this.LoadGuidePrefab("UIFlatten/Prefabs/NewbieGuide/DragFinger", 810);
		if (gameObject == null)
		{
			Logger.LogError("SkillGuide Error, dragFinger == null");
			return ComNewbieGuideBase.GuideState.Exception;
		}
		gameObject.CustomActive(false);
		RectTransform rectTransform = gameObject.transform.rectTransform();
		if (rectTransform == null)
		{
			Logger.LogError("SkillGuide Error, dragRect == null");
			return ComNewbieGuideBase.GuideState.Exception;
		}
		base.StartCoroutine(this.TweenShow(rectTransform, component, component2, 1f, 2f));
		GameObject dragTextTip = this.AddTextTips(base.AddButtonTipNoAutoComplete(component.gameObject, delegate
		{
		}, null, 1f), this.guideDrag1);
		GameObject dropTextTip = this.AddTextTips(base.AddButtonTipNoAutoComplete(component2.gameObject, delegate
		{
		}, null, 1f), this.guideDrag2);
		if (dragTextTip == null || dropTextTip == null)
		{
			Logger.LogError("SkillGuide Error, dragTextTip == null or dropTextTip == null");
			return ComNewbieGuideBase.GuideState.Exception;
		}
		dropTextTip.CustomActive(false);
		Drag_Me componentInChildren = component.GetComponentInChildren<Drag_Me>();
		Drop_Me componentInChildren2 = component2.GetComponentInChildren<Drop_Me>();
		DragGuideCom dragGuideCom;
		DropGuideCom dropGuideCom;
		if (componentInChildren == null || componentInChildren2 == null)
		{
			ComDrag componentInChildren3 = component.GetComponentInChildren<ComDrag>();
			ComDrag componentInChildren4 = component2.GetComponentInChildren<ComDrag>();
			dragGuideCom = componentInChildren3.gameObject.AddComponent<DragGuideCom>();
			dropGuideCom = componentInChildren4.gameObject.AddComponent<DropGuideCom>();
		}
		else
		{
			dragGuideCom = componentInChildren.gameObject.AddComponent<DragGuideCom>();
			dropGuideCom = componentInChildren2.gameObject.AddComponent<DropGuideCom>();
		}
		if (dragGuideCom == null || dropGuideCom == null)
		{
			Logger.LogError("SkillGuide Error, dragCom == null or dropCom == null");
			return ComNewbieGuideBase.GuideState.Exception;
		}
		dragGuideCom.eventOnBeginDrag = delegate(PointerEventData data)
		{
			this.step = 1;
			dropTextTip.CustomActive(true);
			dragTextTip.CustomActive(false);
		};
		dragGuideCom.eventOnEndDrag = delegate(PointerEventData data)
		{
			if (this.step == 1)
			{
				dropTextTip.CustomActive(false);
				dragTextTip.CustomActive(true);
			}
		};
		dropGuideCom.eventOnDrop = delegate(PointerEventData data)
		{
			if (this.dragTween != null)
			{
				DOTween.Kill(this.dragTween.target, false);
				this.dragTween = null;
			}
			this._complete();
			Object.Destroy(g1);
			Object.Destroy(g2);
			this.step = 2;
		};
		return ComNewbieGuideBase.GuideState.Normal;
	}

	// Token: 0x06009B8B RID: 39819 RVA: 0x001E4C90 File Offset: 0x001E3090
	private IGameBind _getBind(ComNewbieGuideDragSkill.stButtonTipsGuideArg arg)
	{
		IGameBind result = null;
		if (arg.MFrameType == "ClientSystemBattle")
		{
			result = (Singleton<ClientSystemManager>.instance.CurrentSystem as IGameBind);
		}
		else
		{
			IClientFrameManager instance = Singleton<ClientSystemManager>.instance;
			if (instance.IsFrameOpen(arg.MFrameType))
			{
				result = (instance.GetFrame(arg.MFrameType) as IGameBind);
			}
		}
		return result;
	}

	// Token: 0x06009B8C RID: 39820 RVA: 0x001E4CF6 File Offset: 0x001E30F6
	private GameObject AddTextTips(GameObject parent, ComNewbieGuideDragSkill.stButtonTipsGuideArg tipsArg)
	{
		return base.AddTextTips(Utility.FindGameObject(parent, "Button", true), tipsArg.MAnchor, tipsArg.MTextTips, tipsArg.MTextTipType, tipsArg.MLocalPos);
	}

	// Token: 0x04005505 RID: 21765
	private const string bgPath = "UIFlatten/Prefabs/NewbieGuide/BgMask";

	// Token: 0x04005506 RID: 21766
	private const string dragFingerPath = "UIFlatten/Prefabs/NewbieGuide/DragFinger";

	// Token: 0x04005507 RID: 21767
	private Tween dragTween;

	// Token: 0x04005508 RID: 21768
	private ComNewbieGuideDragSkill.stButtonTipsGuideArg guideDrag1;

	// Token: 0x04005509 RID: 21769
	private ComNewbieGuideDragSkill.stButtonTipsGuideArg guideDrag2;

	// Token: 0x0400550A RID: 21770
	private int step;

	// Token: 0x0400550B RID: 21771
	public static GameObject sCurrentDrapObject;

	// Token: 0x02000FEF RID: 4079
	private struct stButtonTipsGuideArg
	{
		// Token: 0x17001947 RID: 6471
		// (get) Token: 0x06009B8F RID: 39823 RVA: 0x001E4D2A File Offset: 0x001E312A
		public string MFrameType
		{
			get
			{
				return this.mFrameType;
			}
		}

		// Token: 0x17001948 RID: 6472
		// (get) Token: 0x06009B90 RID: 39824 RVA: 0x001E4D32 File Offset: 0x001E3132
		public string MComRoot
		{
			get
			{
				return this.mComRoot;
			}
		}

		// Token: 0x17001949 RID: 6473
		// (get) Token: 0x06009B91 RID: 39825 RVA: 0x001E4D3A File Offset: 0x001E313A
		public string MTextTips
		{
			get
			{
				return this.mTextTips;
			}
		}

		// Token: 0x1700194A RID: 6474
		// (get) Token: 0x06009B92 RID: 39826 RVA: 0x001E4D42 File Offset: 0x001E3142
		public ComNewbieGuideBase.eNewbieGuideAnchor MAnchor
		{
			get
			{
				return this.mAnchor;
			}
		}

		// Token: 0x1700194B RID: 6475
		// (get) Token: 0x06009B93 RID: 39827 RVA: 0x001E4D4A File Offset: 0x001E314A
		public TextTipType MTextTipType
		{
			get
			{
				return this.mTextTipType;
			}
		}

		// Token: 0x1700194C RID: 6476
		// (get) Token: 0x06009B94 RID: 39828 RVA: 0x001E4D52 File Offset: 0x001E3152
		public Vector3 MLocalPos
		{
			get
			{
				return this.mLocalPos;
			}
		}

		// Token: 0x06009B95 RID: 39829 RVA: 0x001E4D5C File Offset: 0x001E315C
		public void DecodeFromArgs(object[] args, ref int start)
		{
			int num = start;
			int num2 = args.Length - start;
			if (num2 >= 2)
			{
				this.mFrameType = (args[num] as string);
				this.mComRoot = (args[num + 1] as string);
				num += 2;
			}
			if (num2 >= 3)
			{
				this.mTextTips = (args[num] as string);
				num++;
			}
			if (num2 >= 4)
			{
				this.mAnchor = (ComNewbieGuideBase.eNewbieGuideAnchor)args[num];
				num++;
			}
			if (num2 >= 5)
			{
				this.mTextTipType = (TextTipType)args[num];
				num++;
			}
			if (num2 >= 6)
			{
				this.mLocalPos = (Vector3)args[num];
				num++;
			}
			start = num;
		}

		// Token: 0x0400550E RID: 21774
		private string mFrameType;

		// Token: 0x0400550F RID: 21775
		private string mComRoot;

		// Token: 0x04005510 RID: 21776
		private string mTextTips;

		// Token: 0x04005511 RID: 21777
		private ComNewbieGuideBase.eNewbieGuideAnchor mAnchor;

		// Token: 0x04005512 RID: 21778
		private TextTipType mTextTipType;

		// Token: 0x04005513 RID: 21779
		private Vector3 mLocalPos;
	}
}
