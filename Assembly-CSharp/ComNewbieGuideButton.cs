using System;
using System.Collections.Generic;
using GameClient;
using GamePool;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000FEC RID: 4076
public class ComNewbieGuideButton : ComNewbieGuideBase
{
	// Token: 0x06009B7F RID: 39807 RVA: 0x001E42F8 File Offset: 0x001E26F8
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

	// Token: 0x06009B80 RID: 39808 RVA: 0x001E4400 File Offset: 0x001E2800
	protected override ComNewbieGuideBase.GuideState _init()
	{
		if (this.m_pointerClickHandleList != null)
		{
			ListPool<Component>.Release(this.m_pointerClickHandleList);
			this.m_pointerClickHandleList = null;
		}
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
		if (this.mComRoot == "midddle_back/rock1/btCharge")
		{
			HGButton button = gameBind.GetComponent<HGButton>(this.mComRoot);
			if (button == null)
			{
				Logger.LogErrorFormat("button is nil with path {0}", new object[]
				{
					this.mComRoot
				});
				return ComNewbieGuideBase.GuideState.Exception;
			}
			GameObject root = base.AddHGButtonTips(button.gameObject, delegate(bool var)
			{
				button.onUpDown.Invoke(var);
			}, null, 1f);
			if (this.mTextTips.Length > 0)
			{
				base.AddTextTips(root, this.mAnchor, this.mTextTips, this.mTextTipType, this.mLocalPos);
			}
		}
		else
		{
			RectTransform component2 = gameBind.GetComponent<RectTransform>(this.mComRoot);
			if (component2 == null)
			{
				if (this.mGuideControl != null)
				{
				}
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
			GameObject root2 = base.AddButtonTips(component2.gameObject, new UnityAction(this._OnClickButtonAction), null, 1f);
			if (this.mTextTips.Length > 0)
			{
				base.AddTextTips(root2, this.mAnchor, this.mTextTips, this.mTextTipType, this.mLocalPos);
			}
		}
		return ComNewbieGuideBase.GuideState.Normal;
	}

	// Token: 0x06009B81 RID: 39809 RVA: 0x001E46B0 File Offset: 0x001E2AB0
	private void _OnClickButtonAction()
	{
		if (this.m_pointerClickHandleList == null)
		{
			return;
		}
		PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
		if (pointerEventData == null)
		{
			return;
		}
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

	// Token: 0x04005504 RID: 21764
	private List<Component> m_pointerClickHandleList;
}
