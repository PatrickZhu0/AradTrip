using System;
using System.Collections.Generic;
using GameClient;
using GamePool;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

// Token: 0x02000FEB RID: 4075
public class ComNewbieGuideBattleDrugDrag : ComNewbieGuideBase
{
	// Token: 0x06009B7A RID: 39802 RVA: 0x001E3F9C File Offset: 0x001E239C
	public override void StartInit(params object[] args)
	{
		base.StartInit(args);
		if (args != null)
		{
			if (args.Length >= 2)
			{
				this.mFrameType = (args[0] as string);
				this.mComRoot = (args[1] as string);
			}
			if (args.Length >= 3)
			{
				this.mTextTips = (args[2] as string);
			}
			if (args.Length >= 4)
			{
				this.mAnchor = (ComNewbieGuideBase.eNewbieGuideAnchor)args[3];
			}
			if (args.Length >= 5)
			{
				this.mTextTipType = (TextTipType)args[4];
			}
			if (args.Length >= 6)
			{
				this.mLocalPos = (Vector3)args[5];
			}
			if (args.Length >= 7 && (eNewbieGuideAgrsName)args[6] == eNewbieGuideAgrsName.SaveBoot)
			{
				this.mSendSaveBoot = true;
			}
			if (args.Length >= 8 && (eNewbieGuideAgrsName)args[7] == eNewbieGuideAgrsName.PauseBattle)
			{
				this.mTryPauseBattle = true;
			}
			if (args.Length >= 9 && args[8] as string != string.Empty)
			{
				this.mHighLightPointPath = (args[8] as string);
			}
		}
	}

	// Token: 0x06009B7B RID: 39803 RVA: 0x001E40A4 File Offset: 0x001E24A4
	protected override ComNewbieGuideBase.GuideState _init()
	{
		IGameBind gameBind = null;
		if (this.mFrameType == "ClientSystemBattle")
		{
			gameBind = (Singleton<ClientSystemManager>.instance.CurrentSystem as IGameBind);
		}
		else
		{
			IClientFrameManager instance = Singleton<ClientSystemManager>.instance;
			if (instance.IsFrameOpen(this.mFrameType))
			{
				gameBind = (instance.GetFrame(this.mFrameType) as IGameBind);
			}
		}
		if (gameBind == null)
		{
			return ComNewbieGuideBase.GuideState.Wait;
		}
		if (this.mHighLightPointPath != string.Empty)
		{
			RectTransform component = gameBind.GetComponent<RectTransform>(this.mHighLightPointPath);
			if (component == null)
			{
				return ComNewbieGuideBase.GuideState.Exception;
			}
			base.AddCanvasCom(component.gameObject, true);
		}
		RectTransform component2 = gameBind.GetComponent<RectTransform>(this.mComRoot);
		if (component2 == null)
		{
			Logger.LogErrorFormat(" path {0} is not a UI GameObject", new object[]
			{
				this.mComRoot
			});
			return ComNewbieGuideBase.GuideState.Exception;
		}
		List<Component> list = ListPool<Component>.Get();
		if (list == null)
		{
			Logger.LogError("ListPool get coms is null");
			return ComNewbieGuideBase.GuideState.Exception;
		}
		component2.gameObject.GetComponents<Component>(list);
		for (int i = 0; i < list.Count; i++)
		{
			Component component3 = list[i];
			if (component3 is IPointerClickHandler)
			{
				if (this.m_pointerClickHandleList == null)
				{
					this.m_pointerClickHandleList = ListPool<Component>.Get();
				}
				this.m_pointerClickHandleList.Add(component3);
			}
		}
		if (this.m_pointerClickHandleList == null)
		{
			Logger.LogErrorFormat(" path {0}  Do not have a IPointerClickHandler Component", new object[]
			{
				this.mComRoot
			});
			return ComNewbieGuideBase.GuideState.Exception;
		}
		ListPool<Component>.Release(list);
		GameObject root = base.AddBattleDrugDrag(component2.gameObject, new UnityAction(this._OnClickDrugDrag), null, 1f);
		if (this.mTextTips.Length > 0)
		{
			base.AddTextTips(root, this.mAnchor, this.mTextTips, this.mTextTipType, this.mLocalPos);
		}
		return ComNewbieGuideBase.GuideState.Normal;
	}

	// Token: 0x06009B7C RID: 39804 RVA: 0x001E427C File Offset: 0x001E267C
	private void _OnClickDrugDrag()
	{
		PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
		for (int i = 0; i < this.m_pointerClickHandleList.Count; i++)
		{
			IPointerClickHandler pointerClickHandler = this.m_pointerClickHandleList[i] as IPointerClickHandler;
			if (pointerClickHandler != null)
			{
				IPointerDownHandler pointerDownHandler = pointerClickHandler as IPointerDownHandler;
				if (pointerDownHandler != null)
				{
					pointerDownHandler.OnPointerDown(pointerEventData);
				}
				pointerClickHandler.OnPointerClick(pointerEventData);
			}
		}
		ListPool<Component>.Release(this.m_pointerClickHandleList);
	}

	// Token: 0x06009B7D RID: 39805 RVA: 0x001E42EE File Offset: 0x001E26EE
	protected override void _update()
	{
	}

	// Token: 0x04005503 RID: 21763
	private List<Component> m_pointerClickHandleList;
}
