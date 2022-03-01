using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000DBA RID: 3514
	public class ClientFrame : GameBindSystem, IClientFrame, IGameBind
	{
		// Token: 0x06008E10 RID: 36368 RVA: 0x00003532 File Offset: 0x00001932
		public ClientFrame()
		{
			this._global = false;
			this.m_ForbidFadeIn = false;
		}

		// Token: 0x06008E11 RID: 36369 RVA: 0x00003569 File Offset: 0x00001969
		protected IEnumerator StartCoroutine(IEnumerator enumerator)
		{
			if (enumerator != null)
			{
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(enumerator);
				this.m_akActivedCoroutines.Add(enumerator);
			}
			return enumerator;
		}

		// Token: 0x06008E12 RID: 36370 RVA: 0x0000358A File Offset: 0x0000198A
		public void StopCoroutine(IEnumerator enumerator)
		{
			MonoSingleton<GameFrameWork>.instance.StopCoroutine(enumerator);
			this.m_akActivedCoroutines.Remove(enumerator);
		}

		// Token: 0x06008E13 RID: 36371 RVA: 0x000035A4 File Offset: 0x000019A4
		private void StopAllCoroutine()
		{
			for (int i = 0; i < this.m_akActivedCoroutines.Count; i++)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.m_akActivedCoroutines[i]);
			}
			this.m_akActivedCoroutines.Clear();
		}

		// Token: 0x06008E14 RID: 36372 RVA: 0x000035EE File Offset: 0x000019EE
		public static IClientFrame OpenTargetFrame<T>(FrameLayer eLayer = FrameLayer.Middle, object userData = null) where T : ClientFrame, new()
		{
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<T>((T)((object)null)))
			{
				return Singleton<ClientSystemManager>.GetInstance().OpenFrame<T>(eLayer, userData, string.Empty);
			}
			return Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(T));
		}

		// Token: 0x06008E15 RID: 36373 RVA: 0x0000362C File Offset: 0x00001A2C
		protected void _AddButton(string path, UnityAction callBack)
		{
			Button button = Utility.FindComponent<Button>(this.frame, path, true);
			if (null != button)
			{
				button.onClick.AddListener(callBack);
			}
			if (this.buttons == null)
			{
				this.buttons = new List<object>();
			}
			this.buttons.Add(button);
		}

		// Token: 0x06008E16 RID: 36374 RVA: 0x00003684 File Offset: 0x00001A84
		protected void _RemoveAllButtons()
		{
			if (this.buttons == null)
			{
				return;
			}
			for (int i = 0; i < this.buttons.Count; i++)
			{
				Button button = this.buttons[i] as Button;
				if (null != button)
				{
					button.onClick.RemoveAllListeners();
				}
			}
			this.buttons.Clear();
		}

		// Token: 0x06008E17 RID: 36375 RVA: 0x000036F0 File Offset: 0x00001AF0
		protected void _AddChildFrame(int id, IClientFrame clientFrame)
		{
			if (this.childFrames == null)
			{
				this.childFrames = new List<KeyValuePair<int, IClientFrame>>();
			}
			if (clientFrame != null)
			{
				int num = this._FindChildFrame(id);
				for (int i = 0; i < this.childFrames.Count; i++)
				{
					if (this.childFrames[i].Key == id)
					{
						num = i;
						break;
					}
				}
				if (num == -1)
				{
					this.childFrames.Add(new KeyValuePair<int, IClientFrame>(id, clientFrame));
				}
				else
				{
					Logger.LogErrorFormat("add child frame repeated id = {0}", new object[]
					{
						id
					});
				}
			}
		}

		// Token: 0x06008E18 RID: 36376 RVA: 0x00003798 File Offset: 0x00001B98
		protected int _FindChildFrame(int id)
		{
			int result = -1;
			if (this.childFrames != null)
			{
				for (int i = 0; i < this.childFrames.Count; i++)
				{
					if (this.childFrames[i].Key == id)
					{
						result = i;
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x06008E19 RID: 36377 RVA: 0x000037F0 File Offset: 0x00001BF0
		protected IClientFrame _GetChildFrame(int id)
		{
			int num = this._FindChildFrame(id);
			if (num == -1)
			{
				return null;
			}
			return this.childFrames[num].Value;
		}

		// Token: 0x06008E1A RID: 36378 RVA: 0x00003824 File Offset: 0x00001C24
		protected void _CloseAllChildFrames()
		{
			if (this.childFrames != null)
			{
				for (int i = 0; i < this.childFrames.Count; i++)
				{
					KeyValuePair<int, IClientFrame> keyValuePair = this.childFrames[i];
					if (keyValuePair.Value != null)
					{
						keyValuePair.Value.Close(true);
					}
				}
				this.childFrames.Clear();
			}
		}

		// Token: 0x06008E1B RID: 36379 RVA: 0x0000388C File Offset: 0x00001C8C
		public ComItem CreateComItem(GameObject goParent)
		{
			ComItem comItem = ComItemManager.Create(goParent);
			if (comItem != null)
			{
				if (this.m_akComItemList == null)
				{
					this.m_akComItemList = new List<ComItem>();
				}
				this.m_akComItemList.Add(comItem);
			}
			return comItem;
		}

		// Token: 0x06008E1C RID: 36380 RVA: 0x000038D0 File Offset: 0x00001CD0
		private void DestroyComItems()
		{
			if (this.m_akComItemList != null)
			{
				for (int i = 0; i < this.m_akComItemList.Count; i++)
				{
					if (this.m_akComItemList[i] != null)
					{
						ComItemManager.Destroy(this.m_akComItemList[i]);
					}
				}
				this.m_akComItemList.Clear();
			}
		}

		// Token: 0x06008E1D RID: 36381 RVA: 0x00003937 File Offset: 0x00001D37
		public virtual void Init()
		{
		}

		// Token: 0x06008E1E RID: 36382 RVA: 0x00003939 File Offset: 0x00001D39
		public virtual void Clear()
		{
		}

		// Token: 0x06008E1F RID: 36383 RVA: 0x0000393B File Offset: 0x00001D3B
		public string GetName()
		{
			if (this.frame != null)
			{
				return this.frame.name;
			}
			return "UnKnown";
		}

		// Token: 0x06008E20 RID: 36384 RVA: 0x0000395F File Offset: 0x00001D5F
		public string GetFrameName()
		{
			return this.mFrameName;
		}

		// Token: 0x06008E21 RID: 36385 RVA: 0x00003967 File Offset: 0x00001D67
		public void SetFrameName(string name)
		{
			this.mFrameName = name;
		}

		// Token: 0x06008E22 RID: 36386 RVA: 0x00003970 File Offset: 0x00001D70
		public void SetGlobal(bool isGlobal)
		{
			if (this._global != isGlobal)
			{
				this._global = isGlobal;
				if (this.frame != null && this._global)
				{
					this.frame.tag = "GlobalFrame";
				}
			}
		}

		// Token: 0x06008E23 RID: 36387 RVA: 0x000039BC File Offset: 0x00001DBC
		public bool IsGlobal()
		{
			return this._global;
		}

		// Token: 0x06008E24 RID: 36388 RVA: 0x000039C4 File Offset: 0x00001DC4
		public void SetVisible(bool bVisible)
		{
			if (this.frame != null)
			{
				this.frame.CustomActive(bVisible);
			}
		}

		// Token: 0x06008E25 RID: 36389 RVA: 0x000039E3 File Offset: 0x00001DE3
		public void SetForbidFadeIn(bool Forbid)
		{
			this.m_ForbidFadeIn = Forbid;
		}

		// Token: 0x06008E26 RID: 36390 RVA: 0x000039EC File Offset: 0x00001DEC
		public void SetManager(IClientFrameManager mgr)
		{
			this.frameMgr = mgr;
		}

		// Token: 0x06008E27 RID: 36391 RVA: 0x000039F5 File Offset: 0x00001DF5
		public bool IsOpen()
		{
			return this.m_state != EFrameState.Close;
		}

		// Token: 0x06008E28 RID: 36392 RVA: 0x00003A03 File Offset: 0x00001E03
		public bool IsHidden()
		{
			return this.m_state != EFrameState.Close && this.m_state == EFrameState.Hidden;
		}

		// Token: 0x06008E29 RID: 36393 RVA: 0x00003A1C File Offset: 0x00001E1C
		public virtual bool NeedMutex()
		{
			return true;
		}

		// Token: 0x06008E2A RID: 36394 RVA: 0x00003A1F File Offset: 0x00001E1F
		public virtual bool RemoveRefOnClose()
		{
			return ClientSystemManager.sRemoveRefOnClose;
		}

		// Token: 0x06008E2B RID: 36395 RVA: 0x00003A28 File Offset: 0x00001E28
		public void Show(bool isShow, Type type = null)
		{
			if (this.frame != null)
			{
				if (isShow)
				{
					if (this.mComClienFrame != null && this.mComClienFrame.IsNeedFade())
					{
						this.FadeInSpecial(true);
					}
					else
					{
						this.frame.SetActive(isShow);
						this.m_state = EFrameState.Open;
					}
				}
				else
				{
					if (this.mComClienFrame != null && this.mComClienFrame.IsNeedFade())
					{
						this.FadeOutSpecial();
					}
					else
					{
						this.frame.CustomActive(isShow);
					}
					this.m_state = EFrameState.Hidden;
				}
			}
		}

		// Token: 0x06008E2C RID: 36396 RVA: 0x00003AC4 File Offset: 0x00001EC4
		public virtual bool IsNeedUpdate()
		{
			return false;
		}

		// Token: 0x06008E2D RID: 36397 RVA: 0x00003AC7 File Offset: 0x00001EC7
		public virtual EFrameState GetState()
		{
			return this.m_state;
		}

		// Token: 0x06008E2E RID: 36398 RVA: 0x00003ACF File Offset: 0x00001ECF
		public string GetGroupTag()
		{
			if (this.mComClienFrame != null)
			{
				return this.mComClienFrame.GetGroupTag();
			}
			return string.Empty;
		}

		// Token: 0x06008E2F RID: 36399 RVA: 0x00003AED File Offset: 0x00001EED
		public eFrameType GetFrameType()
		{
			if (this.mComClienFrame != null)
			{
				return this.mComClienFrame.GetFrameType();
			}
			return eFrameType.Null;
		}

		// Token: 0x06008E30 RID: 36400 RVA: 0x00003B07 File Offset: 0x00001F07
		public bool IsNeedClearWhenChangeScene()
		{
			return this.mComClienFrame != null && this.mComClienFrame.IsNeedClearWhenChangeScene();
		}

		// Token: 0x06008E31 RID: 36401 RVA: 0x00003B21 File Offset: 0x00001F21
		public bool IsFullScreenFrameNeedBeClose()
		{
			return this.mComClienFrame != null && this.mComClienFrame.IsFullScreenFrame() && this.mComClienFrame.IsFullScreenFrameNeedBeClose();
		}

		// Token: 0x06008E32 RID: 36402 RVA: 0x00003B4D File Offset: 0x00001F4D
		public void SetIsNeedClearWhenChangeScene(bool bFlag)
		{
			if (this.mComClienFrame != null)
			{
				this.mComClienFrame.SetIsNeedClearWhenChangeScene(bFlag);
			}
		}

		// Token: 0x06008E33 RID: 36403 RVA: 0x00003B66 File Offset: 0x00001F66
		public FrameLayer GetLayer()
		{
			if (this.mComClienFrame != null)
			{
				return this.mComClienFrame.GetLayer();
			}
			return FrameLayer.Invalid;
		}

		// Token: 0x06008E34 RID: 36404 RVA: 0x00003B80 File Offset: 0x00001F80
		private void _initCommonBind()
		{
			if (null != this.frame)
			{
				this.mBind = this.frame.GetComponent<ComCommonBind>();
				this._bindExUI();
			}
		}

		// Token: 0x06008E35 RID: 36405 RVA: 0x00003BAA File Offset: 0x00001FAA
		private void _uninitCommonBind()
		{
			if (null != this.mBind)
			{
				this._unbindExUI();
				this.mBind.ClearAllCacheBinds();
				this.mBind = null;
			}
		}

		// Token: 0x06008E36 RID: 36406 RVA: 0x00003BD8 File Offset: 0x00001FD8
		public void Open(GameObject root, object userData = null, FrameLayer layer = FrameLayer.Invalid)
		{
			if (this.IsOpen())
			{
				return;
			}
			this.m_state = EFrameState.Open;
			this.userData = userData;
			this.root = root;
			this.frame = this._loadResGameObject();
			if (this.frame == null)
			{
				Logger.LogErrorFormat("OpenFrame时 [_loadResGameObject] 失败, mFrameName = {0}", new object[]
				{
					this.mFrameName
				});
				return;
			}
			this.mClientFrameBinder = this.frame.AddComponent<ClientFrameBinder>();
			if (this.mClientFrameBinder != null)
			{
				this.mClientFrameBinder.clientFrame = this;
				this.mClientFrameBinder.frame = this.frame;
			}
			this._initClientFrameCom();
			if (this.mComClienFrame != null)
			{
				ComClientFrame comClientFrame = this.mComClienFrame as ComClientFrame;
				if (comClientFrame != null && layer != FrameLayer.Invalid)
				{
					comClientFrame.mLayer = layer;
				}
				if (comClientFrame != null && comClientFrame.bUseBlackMask && MonoSingleton<LeanTween>.instance.frameBlackMask)
				{
					this.blackMask = Object.Instantiate<GameObject>(MonoSingleton<LeanTween>.instance.frameBlackMask);
					this.blackMask.transform.SetParent(root.transform, false);
					if (comClientFrame.bBlackMaskClickAutoClose)
					{
						bool closeWithGC = comClientFrame.bNewCloseNeedGC;
						Button component = this.blackMask.GetComponent<Button>();
						component.onClick.RemoveAllListeners();
						component.onClick.AddListener(delegate()
						{
							this.frameMgr.CloseFrame<ClientFrame>(this, false);
							if (closeWithGC)
							{
								MonoSingleton<AssetGabageCollector>.instance.ClearUnusedAsset(null, false);
							}
							Singleton<AssetGabageCollectorHelper>.instance.AddGCPurgeTick(AssetGCTickType.UIFrame);
						});
					}
				}
			}
			this.frame.transform.SetParent(root.transform, false);
			if (this._global)
			{
				this.frame.tag = "GlobalFrame";
			}
			this._initCommonBind();
			this.AttachContent();
			this._OnLoadPrefabFinish();
			if (this._isInitWithGameBindSystem())
			{
				base.InitBindSystem(this.frame);
			}
			this._InitFrameAnimation();
			this._TryAddBack2Frame();
			this._InitFrameTweenTrigger();
			this._Open();
			this.FadeIn(false);
		}

		// Token: 0x06008E37 RID: 36407 RVA: 0x00003DD8 File Offset: 0x000021D8
		private GameObject _loadResGameObject()
		{
			if (this._isLoadFromPool())
			{
				return Singleton<CGameObjectPool>.instance.GetGameObject(this.GetPrefabPath(), enResourceType.UIPrefab, 0U);
			}
			return Singleton<AssetLoader>.instance.LoadResAsGameObject(this.GetPrefabPath(), true, 0U);
		}

		// Token: 0x06008E38 RID: 36408 RVA: 0x00003E0C File Offset: 0x0000220C
		private void _unloadResGameObject()
		{
			if (this.frame != null)
			{
				this.frame.transform.SetParent(null, false);
			}
			if (this._isLoadFromPool())
			{
				Singleton<CGameObjectPool>.instance.RecycleGameObject(this.frame);
			}
			else
			{
				Object.Destroy(this.frame);
			}
			this.frame = null;
		}

		// Token: 0x06008E39 RID: 36409 RVA: 0x00003E6E File Offset: 0x0000226E
		protected virtual bool _isLoadFromPool()
		{
			return false;
		}

		// Token: 0x06008E3A RID: 36410 RVA: 0x00003E71 File Offset: 0x00002271
		private bool _isInitWithGameBindSystem()
		{
			return this.mComClienFrame == null || this.mComClienFrame.IsInitWithGameBindSystem();
		}

		// Token: 0x06008E3B RID: 36411 RVA: 0x00003E8B File Offset: 0x0000228B
		protected virtual void _bindExUI()
		{
		}

		// Token: 0x06008E3C RID: 36412 RVA: 0x00003E8D File Offset: 0x0000228D
		protected virtual void _unbindExUI()
		{
		}

		// Token: 0x06008E3D RID: 36413 RVA: 0x00003E8F File Offset: 0x0000228F
		protected virtual bool _IsLoadingFrame()
		{
			return false;
		}

		// Token: 0x06008E3E RID: 36414 RVA: 0x00003E94 File Offset: 0x00002294
		private void _initClientFrameCom()
		{
			if (this.frame != null)
			{
				ComClientFrame component = this.frame.GetComponent<ComClientFrame>();
				this.mComClienFrame = component;
			}
			if (this.mComClienFrame != null)
			{
				this.mComClienFrame.SetCurrentFrame(base.GetType().FullName);
			}
			this.UpdateRoot();
		}

		// Token: 0x06008E3F RID: 36415 RVA: 0x00003EEC File Offset: 0x000022EC
		public void UpdateRoot()
		{
		}

		// Token: 0x06008E40 RID: 36416 RVA: 0x00003EF0 File Offset: 0x000022F0
		protected void _updateRoot()
		{
			if (this.mComClienFrame != null)
			{
				GameObject gameObject = this.frame;
				while (gameObject.transform.parent != null && gameObject.transform.parent != this.root.transform)
				{
					gameObject = gameObject.transform.parent.gameObject;
					ComClientFrame component = gameObject.GetComponent<ComClientFrame>();
					if (component != null)
					{
						return;
					}
				}
				if (gameObject.transform.parent != null)
				{
					this.root = Singleton<ClientSystemManager>.instance.GetLayer(this.mComClienFrame.GetLayer());
					if (null != gameObject && null != this.root)
					{
						gameObject.transform.SetParent(this.root.transform, false);
					}
				}
			}
		}

		// Token: 0x06008E41 RID: 36417 RVA: 0x00003FD4 File Offset: 0x000023D4
		protected void _updateClientFrameAttr()
		{
			if (this.frame != null && this.mComClienFrame != null)
			{
				this.frame.transform.SetSiblingIndex(this.mComClienFrame.GetZOrder());
			}
		}

		// Token: 0x06008E42 RID: 36418 RVA: 0x00004010 File Offset: 0x00002410
		public void Close(bool bCloseImmediately = false)
		{
			if (!this.IsOpen())
			{
				return;
			}
			this._notifyFrameIsOpen(false);
			if (!bCloseImmediately)
			{
				bool flag = this.FadeOut(true);
				if (flag)
				{
					this._Close();
				}
			}
			else
			{
				this._Close();
			}
		}

		// Token: 0x06008E43 RID: 36419 RVA: 0x00004055 File Offset: 0x00002455
		protected virtual bool GetNeedAutoFadeIn()
		{
			return true;
		}

		// Token: 0x06008E44 RID: 36420 RVA: 0x00004058 File Offset: 0x00002458
		protected virtual bool GetNeedOpenSound()
		{
			return false;
		}

		// Token: 0x06008E45 RID: 36421 RVA: 0x0000405B File Offset: 0x0000245B
		protected virtual bool GetNeedCloseSound()
		{
			return false;
		}

		// Token: 0x06008E46 RID: 36422 RVA: 0x00004060 File Offset: 0x00002460
		public void FadeInSpecial(bool bForce = false)
		{
			this.invokeDelayFade.eEFadeDelayState = EFadeDelayState.EFDS_IN;
			this.invokeDelayFade.fStart = Time.time;
			this.invokeDelayFade.fDelay = 0.05f;
			this.invokeDelayFade.callback = delegate()
			{
				this.FadeIn(bForce);
			};
			InvokeMethod.AddUniqueInvoke(this.invokeDelayFade);
		}

		// Token: 0x06008E47 RID: 36423 RVA: 0x000040D0 File Offset: 0x000024D0
		public void FadeOutSpecial()
		{
			this.invokeDelayFade.eEFadeDelayState = EFadeDelayState.EFDS_OUT;
			this.invokeDelayFade.fStart = Time.time;
			this.invokeDelayFade.fDelay = 0.1f;
			this.invokeDelayFade.callback = delegate()
			{
				this.FadeOut(false);
			};
			InvokeMethod.AddUniqueInvoke(this.invokeDelayFade);
		}

		// Token: 0x06008E48 RID: 36424 RVA: 0x0000412C File Offset: 0x0000252C
		protected bool FadeIn(bool bForce = false)
		{
			try
			{
				if (this.m_ForbidFadeIn)
				{
					return false;
				}
				if (bForce || this.GetNeedAutoFadeIn())
				{
					if (this.animationTrigger != null)
					{
						if (this.m_state != EFrameState.FadeIn)
						{
							this.m_state = EFrameState.FadeIn;
							this.animationTrigger.DoPlay(UIFrameScript.FunctionType.FT_FADEIN, new UnityAction(this.OnFadeInOver));
							this._TryFadeInBack();
						}
						return false;
					}
					if (this.tweenTriggers != null)
					{
						if (this.m_state != EFrameState.FadeIn)
						{
							this.m_state = EFrameState.FadeIn;
							this.tweenTriggers.FadeIn(new UnityAction(this.OnFadeInOver));
							this._TryFadeInBack();
						}
						return false;
					}
					if (this.mComClienFrame != null)
					{
						ComClientFrame comClientFrame = this.mComClienFrame as ComClientFrame;
						if (comClientFrame.bUseFadeIn)
						{
							this.m_state = EFrameState.FadeIn;
							LeanTween.playFrameOpen(this.frame, this.blackMask, new Action(this.OnFadeInOver));
							this._TryFadeInBack();
							return false;
						}
					}
				}
				if (this.m_state == EFrameState.Open)
				{
					this._notifyFrameIsOpen(true);
				}
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("[FadeIn]FadeIn出错:{0}", new object[]
				{
					ex.ToString()
				});
			}
			return true;
		}

		// Token: 0x06008E49 RID: 36425 RVA: 0x00004298 File Offset: 0x00002698
		private void OnFadeInOver()
		{
			EFrameState state = this.m_state;
			if (state == EFrameState.FadeIn)
			{
				this.m_state = EFrameState.Open;
				this._notifyFrameIsOpen(true);
			}
			if (this.onFadeInEnd != null)
			{
				this.onFadeInEnd();
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.FadeInOver, this.mFrameName, null, null, null);
			GlobalEventSystem.GetInstance().SendUIEvent(EUIEventID.FadeInOver, this.mFrameName, null, null, null);
		}

		// Token: 0x06008E4A RID: 36426 RVA: 0x00004311 File Offset: 0x00002711
		private void _CoreOpen()
		{
		}

		// Token: 0x06008E4B RID: 36427 RVA: 0x00004313 File Offset: 0x00002713
		private void _CoreClose()
		{
		}

		// Token: 0x06008E4C RID: 36428 RVA: 0x00004318 File Offset: 0x00002718
		private void _Open()
		{
			this.m_state = EFrameState.Open;
			this._CoreOpen();
			this._OnOpenFrame();
			if (this.GetNeedOpenSound())
			{
				MonoSingleton<AudioManager>.instance.PlaySound("Sound/UI/ui_window_open", AudioType.AudioEffect, 1f, false, null, false, false, null, 1f);
			}
		}

		// Token: 0x06008E4D RID: 36429 RVA: 0x00004364 File Offset: 0x00002764
		private void _InitFrameAnimation()
		{
			this.animationTrigger = this.frame.transform.GetComponent<UIFrameScript>();
			if (this.animationTrigger != null)
			{
				this.animationTrigger.Initialize();
			}
			if (!this._IsLoadingFrame())
			{
				UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SceneLoadFinish, new ClientEventSystem.UIEventHandler(this.OnSceneLoadFinish));
			}
		}

		// Token: 0x06008E4E RID: 36430 RVA: 0x000043C9 File Offset: 0x000027C9
		private void _InitFrameTweenTrigger()
		{
			this.tweenTriggers = this.frame.transform.GetComponent<DoTweenTrigger>();
			if (this.tweenTriggers != null)
			{
				this.tweenTriggers.Initialize();
			}
		}

		// Token: 0x06008E4F RID: 36431 RVA: 0x000043FD File Offset: 0x000027FD
		private void _TryAddBack2Frame()
		{
			if (this.animationTrigger != null)
			{
				this.animationTrigger.DoPlay(UIFrameScript.FunctionType.FT_ADDBACK, null);
			}
		}

		// Token: 0x06008E50 RID: 36432 RVA: 0x00004420 File Offset: 0x00002820
		private void _TryFadeInBack()
		{
			if (this.frame.transform.parent != null && this.frame.transform.name + "parent" == this.frame.transform.parent.name)
			{
				DoTweenTrigger component = this.frame.transform.parent.GetComponent<DoTweenTrigger>();
				if (component != null)
				{
					component.FadeIn(null);
				}
			}
		}

		// Token: 0x06008E51 RID: 36433 RVA: 0x000044AC File Offset: 0x000028AC
		private void _TryFadeOutBack()
		{
			if (this.frame.transform.parent != null && this.frame.transform.name + "parent" == this.frame.transform.parent.name)
			{
				DoTweenTrigger component = this.frame.transform.parent.GetComponent<DoTweenTrigger>();
				if (component != null)
				{
					component.FadeOut(null);
				}
			}
		}

		// Token: 0x06008E52 RID: 36434 RVA: 0x00004538 File Offset: 0x00002938
		protected bool FadeOut(bool bClose = true)
		{
			bool result = true;
			try
			{
				if (this.GetNeedCloseSound())
				{
					MonoSingleton<AudioManager>.instance.PlaySound("Sound/UI/ui_window_close", AudioType.AudioEffect, 1f, false, null, false, false, null, 1f);
				}
				UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SceneLoadFinish, new ClientEventSystem.UIEventHandler(this.OnSceneLoadFinish));
				if (this.animationTrigger != null)
				{
					this.m_state = ((!bClose) ? EFrameState.Hidden : EFrameState.FadeOut);
					this.animationTrigger.DoPlay(UIFrameScript.FunctionType.FT_FADEOUT, new UnityAction(this.OnFadeOutOver));
					this._TryFadeOutBack();
					result = false;
				}
				else if (this.tweenTriggers != null)
				{
					this.m_state = ((!bClose) ? EFrameState.Hidden : EFrameState.FadeOut);
					this.tweenTriggers.FadeOut(new UnityAction(this.OnFadeOutOver));
					this._TryFadeOutBack();
					result = false;
				}
				else if (this.mComClienFrame != null)
				{
					ComClientFrame comClientFrame = this.mComClienFrame as ComClientFrame;
					if (comClientFrame.bUseFadeOut)
					{
						this.m_state = ((!bClose) ? EFrameState.Hidden : EFrameState.FadeOut);
						LeanTween.playFrameClose(this.frame, this.blackMask, new Action(this.OnFadeOutOver));
						this._TryFadeOutBack();
						result = false;
					}
				}
				if (this.m_state == EFrameState.Hidden || this.m_state == EFrameState.FadeOut)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.FadeOutOver, this.mFrameName, null, null, null);
				}
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("[FADEOUT]fadeout出错:{0}", new object[]
				{
					ex.ToString()
				});
			}
			return result;
		}

		// Token: 0x06008E53 RID: 36435 RVA: 0x000046EC File Offset: 0x00002AEC
		private void OnFadeOutOver()
		{
			EFrameState state = this.m_state;
			if (state != EFrameState.FadeOut)
			{
				if (state != EFrameState.Hidden)
				{
				}
			}
			else
			{
				this._Close();
			}
		}

		// Token: 0x170018D0 RID: 6352
		// (get) Token: 0x06008E54 RID: 36436 RVA: 0x00004723 File Offset: 0x00002B23
		// (set) Token: 0x06008E55 RID: 36437 RVA: 0x0000472B File Offset: 0x00002B2B
		public Action<IClientFrame> CloseCallBack
		{
			get
			{
				return this.closeCallBack;
			}
			set
			{
				this.closeCallBack = value;
			}
		}

		// Token: 0x06008E56 RID: 36438 RVA: 0x00004734 File Offset: 0x00002B34
		private void _notifyFrameIsOpen(bool isOpen)
		{
			if (this.mComClienFrame == null)
			{
				return;
			}
			if (!this.mComClienFrame.IsFullScreenFrame())
			{
				return;
			}
			if (isOpen)
			{
				Singleton<ClientSystemManager>.instance.NotifyFrameIsOpen(this);
			}
			else
			{
				Singleton<ClientSystemManager>.instance.NotifyFrameIsClose(this);
			}
		}

		// Token: 0x06008E57 RID: 36439 RVA: 0x00004774 File Offset: 0x00002B74
		private void _Close()
		{
			if (this.frameMgr != null)
			{
				this.frameMgr.OnFrameClose(this, this.RemoveRefOnClose());
			}
			this.m_state = EFrameState.Close;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SceneLoadFinish, new ClientEventSystem.UIEventHandler(this.OnSceneLoadFinish));
			this.StopAllCoroutine();
			InvokeMethod.RemoveUniqueInvoke(this.invokeDelayFade);
			this._CoreClose();
			if (this.CloseCallBack != null)
			{
				this.CloseCallBack(this);
				this.CloseCallBack = null;
			}
			this._OnCloseFrame();
			this.userData = null;
			this._uninitCommonBind();
			if (null != this.mClientFrameBinder)
			{
				this.mClientFrameBinder.OnCloseFrame();
			}
			if (this.GetLayer() == FrameLayer.Middle && null != this.frame)
			{
				ComClientFrame component = this.frame.GetComponent<ComClientFrame>();
				if (component != null && component.mFrameType == eFrameType.FullScreen)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.MiddleFrameClose, null, null, null, null);
				}
			}
			this.DestroyComItems();
			this._RemoveAllButtons();
			this._CloseAllChildFrames();
			if (this._isInitWithGameBindSystem())
			{
				base.ExistBindSystem();
			}
			this.onFadeInEnd = null;
			if (this.animationTrigger != null)
			{
				this.animationTrigger.DoPlay(UIFrameScript.FunctionType.FT_REMOVEBACK, null);
			}
			if (this.blackMask != null)
			{
				this.blackMask.transform.SetParent(null, false);
				Object.Destroy(this.blackMask);
				this.blackMask = null;
			}
			this._unloadResGameObject();
			this.root = null;
			this.mComClienFrame = null;
			UIEvent uievent = new UIEvent();
			uievent.EventID = EUIEventID.FrameClose;
			uievent.Param1 = this.mFrameName;
			uievent.Param2 = base.GetType();
			GlobalEventSystem.GetInstance().SendUIEvent(uievent);
		}

		// Token: 0x06008E58 RID: 36440 RVA: 0x0000493D File Offset: 0x00002D3D
		public void Update(float timeElapsed)
		{
			this._OnUpdate(timeElapsed);
		}

		// Token: 0x06008E59 RID: 36441 RVA: 0x00004946 File Offset: 0x00002D46
		public virtual string GetPrefabPath()
		{
			return string.Empty;
		}

		// Token: 0x06008E5A RID: 36442 RVA: 0x0000494D File Offset: 0x00002D4D
		protected virtual bool AttachContent()
		{
			return false;
		}

		// Token: 0x06008E5B RID: 36443 RVA: 0x00004950 File Offset: 0x00002D50
		protected virtual void _OnOpenFrame()
		{
		}

		// Token: 0x06008E5C RID: 36444 RVA: 0x00004952 File Offset: 0x00002D52
		private void OnSceneLoadFinish(UIEvent uiEvent)
		{
			this.OnSceneLoadFinish();
		}

		// Token: 0x06008E5D RID: 36445 RVA: 0x0000495A File Offset: 0x00002D5A
		protected virtual void OnSceneLoadFinish()
		{
		}

		// Token: 0x06008E5E RID: 36446 RVA: 0x0000495C File Offset: 0x00002D5C
		protected virtual void _OnDoTweenEnd()
		{
			this.frame.gameObject.SetActive(false);
		}

		// Token: 0x06008E5F RID: 36447 RVA: 0x0000496F File Offset: 0x00002D6F
		protected virtual void _OnLoadPrefabFinish()
		{
		}

		// Token: 0x06008E60 RID: 36448 RVA: 0x00004971 File Offset: 0x00002D71
		protected virtual void _OnCloseFrame()
		{
		}

		// Token: 0x06008E61 RID: 36449 RVA: 0x00004973 File Offset: 0x00002D73
		protected virtual void _OnUpdate(float timeElapsed)
		{
		}

		// Token: 0x06008E62 RID: 36450 RVA: 0x00004978 File Offset: 0x00002D78
		public T GetComponent<T>(string name) where T : Component
		{
			if (this._isInitWithGameBindSystem())
			{
				return base.GetComponentByName<T>(name);
			}
			GameObject gameObject = Utility.FindChild(this.frame, name);
			if (gameObject == null)
			{
				return (T)((object)null);
			}
			return gameObject.GetComponent<T>();
		}

		// Token: 0x06008E63 RID: 36451 RVA: 0x000049BE File Offset: 0x00002DBE
		public T GetComponentInChildren<T>(string name) where T : Component
		{
			if (this._isInitWithGameBindSystem())
			{
				return base.GetComponentInChilderByName<T>(name);
			}
			return Utility.GetComponetInChild<T>(this.frame, name);
		}

		// Token: 0x06008E64 RID: 36452 RVA: 0x000049E0 File Offset: 0x00002DE0
		public virtual IEnumerator LoadingOpenPost()
		{
			yield return null;
			yield break;
		}

		// Token: 0x06008E65 RID: 36453 RVA: 0x000049F4 File Offset: 0x00002DF4
		public int GetSiblingIndex()
		{
			return this.frame.transform.parent.GetSiblingIndex();
		}

		// Token: 0x06008E66 RID: 36454 RVA: 0x00004A0B File Offset: 0x00002E0B
		public void SetSiblingIndex(int index)
		{
			this.frame.transform.parent.SetSiblingIndex(index);
		}

		// Token: 0x06008E67 RID: 36455 RVA: 0x00004A23 File Offset: 0x00002E23
		public GameObject GetFrame()
		{
			return this.frame;
		}

		// Token: 0x04004684 RID: 18052
		private List<IEnumerator> m_akActivedCoroutines = new List<IEnumerator>();

		// Token: 0x04004685 RID: 18053
		protected List<object> buttons;

		// Token: 0x04004686 RID: 18054
		protected List<KeyValuePair<int, IClientFrame>> childFrames;

		// Token: 0x04004687 RID: 18055
		protected IClientFrameManager frameMgr;

		// Token: 0x04004688 RID: 18056
		protected GameObject frame;

		// Token: 0x04004689 RID: 18057
		protected GameObject content;

		// Token: 0x0400468A RID: 18058
		protected GameObject root;

		// Token: 0x0400468B RID: 18059
		protected GameObject blackMask;

		// Token: 0x0400468C RID: 18060
		protected object userData;

		// Token: 0x0400468D RID: 18061
		protected string mFrameName;

		// Token: 0x0400468E RID: 18062
		protected EFrameState m_state;

		// Token: 0x0400468F RID: 18063
		protected EFadeDelayState m_eEFadeDelayState;

		// Token: 0x04004690 RID: 18064
		private float m_fFadeStart;

		// Token: 0x04004691 RID: 18065
		protected DoTweenTrigger tweenTriggers;

		// Token: 0x04004692 RID: 18066
		protected UIFrameScript animationTrigger;

		// Token: 0x04004693 RID: 18067
		protected ClientFrameBinder mClientFrameBinder;

		// Token: 0x04004694 RID: 18068
		protected IComClientFrame mComClienFrame;

		// Token: 0x04004695 RID: 18069
		protected ComCommonBind mBind;

		// Token: 0x04004696 RID: 18070
		protected bool _global;

		// Token: 0x04004697 RID: 18071
		protected bool m_ForbidFadeIn;

		// Token: 0x04004698 RID: 18072
		protected ClientFrame.OnFadeInEnd onFadeInEnd;

		// Token: 0x04004699 RID: 18073
		protected List<ComItem> m_akComItemList;

		// Token: 0x0400469A RID: 18074
		private ClientFrame.InvokeDelayFade invokeDelayFade = new ClientFrame.InvokeDelayFade(0f, 0f, null);

		// Token: 0x0400469B RID: 18075
		private Action<IClientFrame> closeCallBack;

		// Token: 0x02000DBB RID: 3515
		// (Invoke) Token: 0x06008E6A RID: 36458
		public delegate void OnFadeInEnd();

		// Token: 0x02000DBC RID: 3516
		private class InvokeDelayFade : InvokeMethod.TaskManager.Invoke
		{
			// Token: 0x06008E6D RID: 36461 RVA: 0x00004A9C File Offset: 0x00002E9C
			public InvokeDelayFade(float fStart, float fDelay, UnityAction callback) : base(fStart, fDelay, callback, null)
			{
			}

			// Token: 0x0400469C RID: 18076
			public EFadeDelayState eEFadeDelayState;
		}
	}
}
