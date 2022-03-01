using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// Token: 0x02004A38 RID: 19000
public class UniWebView : MonoBehaviour
{
	// Token: 0x14000088 RID: 136
	// (add) Token: 0x0601B6FD RID: 112381 RVA: 0x00876718 File Offset: 0x00874B18
	// (remove) Token: 0x0601B6FE RID: 112382 RVA: 0x00876750 File Offset: 0x00874B50
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event UniWebView.PageStartedDelegate OnPageStarted;

	// Token: 0x14000089 RID: 137
	// (add) Token: 0x0601B6FF RID: 112383 RVA: 0x00876788 File Offset: 0x00874B88
	// (remove) Token: 0x0601B700 RID: 112384 RVA: 0x008767C0 File Offset: 0x00874BC0
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event UniWebView.PageFinishedDelegate OnPageFinished;

	// Token: 0x1400008A RID: 138
	// (add) Token: 0x0601B701 RID: 112385 RVA: 0x008767F8 File Offset: 0x00874BF8
	// (remove) Token: 0x0601B702 RID: 112386 RVA: 0x00876830 File Offset: 0x00874C30
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event UniWebView.PageErrorReceivedDelegate OnPageErrorReceived;

	// Token: 0x1400008B RID: 139
	// (add) Token: 0x0601B703 RID: 112387 RVA: 0x00876868 File Offset: 0x00874C68
	// (remove) Token: 0x0601B704 RID: 112388 RVA: 0x008768A0 File Offset: 0x00874CA0
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event UniWebView.MessageReceivedDelegate OnMessageReceived;

	// Token: 0x1400008C RID: 140
	// (add) Token: 0x0601B705 RID: 112389 RVA: 0x008768D8 File Offset: 0x00874CD8
	// (remove) Token: 0x0601B706 RID: 112390 RVA: 0x00876910 File Offset: 0x00874D10
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event UniWebView.ShouldCloseDelegate OnShouldClose;

	// Token: 0x1400008D RID: 141
	// (add) Token: 0x0601B707 RID: 112391 RVA: 0x00876948 File Offset: 0x00874D48
	// (remove) Token: 0x0601B708 RID: 112392 RVA: 0x00876980 File Offset: 0x00874D80
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event UniWebView.KeyCodeReceivedDelegate OnKeyCodeReceived;

	// Token: 0x1400008E RID: 142
	// (add) Token: 0x0601B709 RID: 112393 RVA: 0x008769B8 File Offset: 0x00874DB8
	// (remove) Token: 0x0601B70A RID: 112394 RVA: 0x008769F0 File Offset: 0x00874DF0
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event UniWebView.OreintationChangedDelegate OnOreintationChanged;

	// Token: 0x1700245A RID: 9306
	// (get) Token: 0x0601B70B RID: 112395 RVA: 0x00876A26 File Offset: 0x00874E26
	// (set) Token: 0x0601B70C RID: 112396 RVA: 0x00876A2E File Offset: 0x00874E2E
	public Rect Frame
	{
		get
		{
			return this.frame;
		}
		set
		{
			this.frame = value;
			this.UpdateFrame();
		}
	}

	// Token: 0x1700245B RID: 9307
	// (get) Token: 0x0601B70D RID: 112397 RVA: 0x00876A3D File Offset: 0x00874E3D
	// (set) Token: 0x0601B70E RID: 112398 RVA: 0x00876A45 File Offset: 0x00874E45
	public RectTransform ReferenceRectTransform
	{
		get
		{
			return this.referenceRectTransform;
		}
		set
		{
			this.referenceRectTransform = value;
			this.UpdateFrame();
		}
	}

	// Token: 0x1700245C RID: 9308
	// (get) Token: 0x0601B70F RID: 112399 RVA: 0x00876A54 File Offset: 0x00874E54
	public string Url
	{
		get
		{
			return UniWebViewInterface.GetUrl(this.listener.Name);
		}
	}

	// Token: 0x0601B710 RID: 112400 RVA: 0x00876A68 File Offset: 0x00874E68
	public void UpdateFrame()
	{
		Rect rect = this.NextFrameRect();
		UniWebViewInterface.SetFrame(this.listener.Name, (int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height);
	}

	// Token: 0x0601B711 RID: 112401 RVA: 0x00876AAC File Offset: 0x00874EAC
	private Rect NextFrameRect()
	{
		if (this.referenceRectTransform == null)
		{
			UniWebViewLogger.Instance.Info("Using Frame setting to determine web view frame.");
			return this.frame;
		}
		UniWebViewLogger.Instance.Info("Using reference RectTransform to determine web view frame.");
		Vector3[] array = new Vector3[4];
		this.referenceRectTransform.GetWorldCorners(array);
		Vector3 vector = array[0];
		Vector3 vector2 = array[1];
		Vector3 vector3 = array[2];
		Vector3 vector4 = array[3];
		Canvas componentInParent = this.referenceRectTransform.GetComponentInParent<Canvas>();
		RenderMode renderMode = componentInParent.renderMode;
		if (renderMode != null)
		{
			if (renderMode == 1 || renderMode == 2)
			{
				Camera worldCamera = componentInParent.worldCamera;
				if (worldCamera == null)
				{
					UniWebViewLogger.Instance.Critical("You need a render camera \n                        or event camera to use RectTransform to determine correct \n                        frame for UniWebView.");
					UniWebViewLogger.Instance.Info("No camera found. Fall back to ScreenSpaceOverlay mode.");
				}
				else
				{
					vector = worldCamera.WorldToScreenPoint(vector);
					vector2 = worldCamera.WorldToScreenPoint(vector2);
					vector3 = worldCamera.WorldToScreenPoint(vector3);
					vector4 = worldCamera.WorldToScreenPoint(vector4);
				}
			}
		}
		float x = vector2.x;
		float num = (float)Screen.height - vector2.y;
		float num2 = vector4.x - vector2.x;
		float num3 = vector2.y - vector4.y;
		return new Rect(x, num, num2, num3);
	}

	// Token: 0x0601B712 RID: 112402 RVA: 0x00876C1C File Offset: 0x0087501C
	private void Awake()
	{
		GameObject gameObject = new GameObject(this.id);
		this.listener = gameObject.AddComponent<UniWebViewNativeListener>();
		gameObject.transform.parent = base.transform;
		this.listener.webView = this;
		Rect rect;
		if (this.fullScreen)
		{
			rect..ctor(0f, 0f, (float)Screen.width, (float)Screen.height);
		}
		else
		{
			rect = this.NextFrameRect();
		}
		UniWebViewInterface.Init(this.listener.Name, (int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height);
		this.isPortrait = (Screen.height >= Screen.width);
	}

	// Token: 0x0601B713 RID: 112403 RVA: 0x00876CD8 File Offset: 0x008750D8
	private void Start()
	{
		if (this.showOnStart)
		{
			this.Show(false, UniWebViewTransitionEdge.None, 0.4f, null);
		}
		if (!string.IsNullOrEmpty(this.urlOnStart))
		{
			this.Load(this.urlOnStart, false);
		}
		if (this.useToolbar)
		{
			bool onTop = this.toolbarPosition == UniWebViewToolbarPosition.Top;
			this.SetShowToolbar(true, false, onTop, this.fullScreen);
		}
		this.started = true;
	}

	// Token: 0x0601B714 RID: 112404 RVA: 0x00876D48 File Offset: 0x00875148
	private void Update()
	{
		bool flag = Screen.height >= Screen.width;
		if (this.isPortrait != flag)
		{
			this.isPortrait = flag;
			if (this.OnOreintationChanged != null)
			{
				this.OnOreintationChanged(this, (!this.isPortrait) ? 3 : 1);
			}
			if (this.referenceRectTransform != null)
			{
				this.UpdateFrame();
			}
		}
	}

	// Token: 0x0601B715 RID: 112405 RVA: 0x00876DB8 File Offset: 0x008751B8
	private void OnEnable()
	{
		if (this.started)
		{
			this.Show(false, UniWebViewTransitionEdge.None, 0.4f, null);
		}
	}

	// Token: 0x0601B716 RID: 112406 RVA: 0x00876DD4 File Offset: 0x008751D4
	private void OnDisable()
	{
		if (this.started)
		{
			this.Hide(false, UniWebViewTransitionEdge.None, 0.4f, null);
		}
	}

	// Token: 0x0601B717 RID: 112407 RVA: 0x00876DF0 File Offset: 0x008751F0
	public void Load(string url, bool skipEncoding = false)
	{
		UniWebViewInterface.Load(this.listener.Name, url, skipEncoding);
	}

	// Token: 0x0601B718 RID: 112408 RVA: 0x00876E04 File Offset: 0x00875204
	public void LoadHTMLString(string htmlString, string baseUrl, bool skipEncoding = false)
	{
		UniWebViewInterface.LoadHTMLString(this.listener.Name, htmlString, baseUrl, skipEncoding);
	}

	// Token: 0x0601B719 RID: 112409 RVA: 0x00876E19 File Offset: 0x00875219
	public void Reload()
	{
		UniWebViewInterface.Reload(this.listener.Name);
	}

	// Token: 0x0601B71A RID: 112410 RVA: 0x00876E2B File Offset: 0x0087522B
	public void Stop()
	{
		UniWebViewInterface.Stop(this.listener.Name);
	}

	// Token: 0x1700245D RID: 9309
	// (get) Token: 0x0601B71B RID: 112411 RVA: 0x00876E3D File Offset: 0x0087523D
	public bool CanGoBack
	{
		get
		{
			return UniWebViewInterface.CanGoBack(this.listener.name);
		}
	}

	// Token: 0x1700245E RID: 9310
	// (get) Token: 0x0601B71C RID: 112412 RVA: 0x00876E4F File Offset: 0x0087524F
	public bool CanGoForward
	{
		get
		{
			return UniWebViewInterface.CanGoForward(this.listener.name);
		}
	}

	// Token: 0x0601B71D RID: 112413 RVA: 0x00876E61 File Offset: 0x00875261
	public void GoBack()
	{
		UniWebViewInterface.GoBack(this.listener.Name);
	}

	// Token: 0x0601B71E RID: 112414 RVA: 0x00876E73 File Offset: 0x00875273
	public void GoForward()
	{
		UniWebViewInterface.GoForward(this.listener.Name);
	}

	// Token: 0x0601B71F RID: 112415 RVA: 0x00876E85 File Offset: 0x00875285
	public void SetOpenLinksInExternalBrowser(bool flag)
	{
		UniWebViewInterface.SetOpenLinksInExternalBrowser(this.listener.Name, flag);
	}

	// Token: 0x0601B720 RID: 112416 RVA: 0x00876E98 File Offset: 0x00875298
	public bool Show(bool fade = false, UniWebViewTransitionEdge edge = UniWebViewTransitionEdge.None, float duration = 0.4f, Action completionHandler = null)
	{
		string text = Guid.NewGuid().ToString();
		bool flag = UniWebViewInterface.Show(this.listener.Name, fade, (int)edge, duration, text);
		if (flag && completionHandler != null)
		{
			this.actions.Add(text, completionHandler);
		}
		return flag;
	}

	// Token: 0x0601B721 RID: 112417 RVA: 0x00876EEC File Offset: 0x008752EC
	public bool Hide(bool fade = false, UniWebViewTransitionEdge edge = UniWebViewTransitionEdge.None, float duration = 0.4f, Action completionHandler = null)
	{
		string text = Guid.NewGuid().ToString();
		bool flag = UniWebViewInterface.Hide(this.listener.Name, fade, (int)edge, duration, text);
		if (flag && completionHandler != null)
		{
			this.actions.Add(text, completionHandler);
		}
		return flag;
	}

	// Token: 0x0601B722 RID: 112418 RVA: 0x00876F40 File Offset: 0x00875340
	public bool AnimateTo(Rect frame, float duration, float delay = 0f, Action completionHandler = null)
	{
		string text = Guid.NewGuid().ToString();
		bool flag = UniWebViewInterface.AnimateTo(this.listener.Name, (int)frame.x, (int)frame.y, (int)frame.width, (int)frame.height, duration, delay, text);
		if (flag)
		{
			this.frame = frame;
			if (completionHandler != null)
			{
				this.actions.Add(text, completionHandler);
			}
		}
		return flag;
	}

	// Token: 0x0601B723 RID: 112419 RVA: 0x00876FB8 File Offset: 0x008753B8
	public void AddJavaScript(string jsString, Action<UniWebViewNativeResultPayload> completionHandler = null)
	{
		string text = Guid.NewGuid().ToString();
		UniWebViewInterface.AddJavaScript(this.listener.Name, jsString, text);
		if (completionHandler != null)
		{
			this.payloadActions.Add(text, completionHandler);
		}
	}

	// Token: 0x0601B724 RID: 112420 RVA: 0x00877000 File Offset: 0x00875400
	public void EvaluateJavaScript(string jsString, Action<UniWebViewNativeResultPayload> completionHandler = null)
	{
		string text = Guid.NewGuid().ToString();
		UniWebViewInterface.EvaluateJavaScript(this.listener.Name, jsString, text);
		if (completionHandler != null)
		{
			this.payloadActions.Add(text, completionHandler);
		}
	}

	// Token: 0x0601B725 RID: 112421 RVA: 0x00877048 File Offset: 0x00875448
	public void AddUrlScheme(string scheme)
	{
		if (scheme == null)
		{
			UniWebViewLogger.Instance.Critical("The scheme should not be null.");
			return;
		}
		if (scheme.Contains("://"))
		{
			UniWebViewLogger.Instance.Critical("The scheme should not include invalid characters '://'");
			return;
		}
		UniWebViewInterface.AddUrlScheme(this.listener.Name, scheme);
	}

	// Token: 0x0601B726 RID: 112422 RVA: 0x0087709C File Offset: 0x0087549C
	public void RemoveUrlScheme(string scheme)
	{
		if (scheme == null)
		{
			UniWebViewLogger.Instance.Critical("The scheme should not be null.");
			return;
		}
		if (scheme.Contains("://"))
		{
			UniWebViewLogger.Instance.Critical("The scheme should not include invalid characters '://'");
			return;
		}
		UniWebViewInterface.RemoveUrlScheme(this.listener.Name, scheme);
	}

	// Token: 0x0601B727 RID: 112423 RVA: 0x008770F0 File Offset: 0x008754F0
	public void AddSslExceptionDomain(string domain)
	{
		if (domain == null)
		{
			UniWebViewLogger.Instance.Critical("The domain should not be null.");
			return;
		}
		if (domain.Contains("://"))
		{
			UniWebViewLogger.Instance.Critical("The domain should not include invalid characters '://'");
			return;
		}
		UniWebViewInterface.AddSslExceptionDomain(this.listener.Name, domain);
	}

	// Token: 0x0601B728 RID: 112424 RVA: 0x00877144 File Offset: 0x00875544
	public void RemoveSslExceptionDomain(string domain)
	{
		if (domain == null)
		{
			UniWebViewLogger.Instance.Critical("The domain should not be null.");
			return;
		}
		if (domain.Contains("://"))
		{
			UniWebViewLogger.Instance.Critical("The domain should not include invalid characters '://'");
			return;
		}
		UniWebViewInterface.RemoveSslExceptionDomain(this.listener.Name, domain);
	}

	// Token: 0x0601B729 RID: 112425 RVA: 0x00877198 File Offset: 0x00875598
	public void SetHeaderField(string key, string value)
	{
		if (key == null)
		{
			UniWebViewLogger.Instance.Critical("Header key should not be null.");
			return;
		}
		UniWebViewInterface.SetHeaderField(this.listener.Name, key, value);
	}

	// Token: 0x0601B72A RID: 112426 RVA: 0x008771C2 File Offset: 0x008755C2
	public void SetUserAgent(string agent)
	{
		UniWebViewInterface.SetUserAgent(this.listener.Name, agent);
	}

	// Token: 0x0601B72B RID: 112427 RVA: 0x008771D5 File Offset: 0x008755D5
	public string GetUserAgent()
	{
		return UniWebViewInterface.GetUserAgent(this.listener.Name);
	}

	// Token: 0x0601B72C RID: 112428 RVA: 0x008771E7 File Offset: 0x008755E7
	public static void SetAllowAutoPlay(bool flag)
	{
		UniWebViewInterface.SetAllowAutoPlay(flag);
	}

	// Token: 0x0601B72D RID: 112429 RVA: 0x008771EF File Offset: 0x008755EF
	public static void SetAllowInlinePlay(bool flag)
	{
	}

	// Token: 0x0601B72E RID: 112430 RVA: 0x008771F1 File Offset: 0x008755F1
	public static void SetJavaScriptEnabled(bool enabled)
	{
		UniWebViewInterface.SetJavaScriptEnabled(enabled);
	}

	// Token: 0x0601B72F RID: 112431 RVA: 0x008771F9 File Offset: 0x008755F9
	public static void SetAllowJavaScriptOpenWindow(bool flag)
	{
		UniWebViewInterface.SetAllowJavaScriptOpenWindow(flag);
	}

	// Token: 0x0601B730 RID: 112432 RVA: 0x00877201 File Offset: 0x00875601
	public void CleanCache()
	{
		UniWebViewInterface.CleanCache(this.listener.Name);
	}

	// Token: 0x0601B731 RID: 112433 RVA: 0x00877213 File Offset: 0x00875613
	public static void ClearCookies()
	{
		UniWebViewInterface.ClearCookies();
	}

	// Token: 0x0601B732 RID: 112434 RVA: 0x0087721A File Offset: 0x0087561A
	public static void SetCookie(string url, string cookie, bool skipEncoding = false)
	{
		UniWebViewInterface.SetCookie(url, cookie, skipEncoding);
	}

	// Token: 0x0601B733 RID: 112435 RVA: 0x00877224 File Offset: 0x00875624
	public static string GetCookie(string url, string key, bool skipEncoding = false)
	{
		return UniWebViewInterface.GetCookie(url, key, skipEncoding);
	}

	// Token: 0x0601B734 RID: 112436 RVA: 0x0087722E File Offset: 0x0087562E
	public static void ClearHttpAuthUsernamePassword(string host, string realm)
	{
		UniWebViewInterface.ClearHttpAuthUsernamePassword(host, realm);
	}

	// Token: 0x1700245F RID: 9311
	// (get) Token: 0x0601B735 RID: 112437 RVA: 0x00877237 File Offset: 0x00875637
	// (set) Token: 0x0601B736 RID: 112438 RVA: 0x0087723F File Offset: 0x0087563F
	public Color BackgroundColor
	{
		get
		{
			return this.backgroundColor;
		}
		set
		{
			this.backgroundColor = value;
			UniWebViewInterface.SetBackgroundColor(this.listener.Name, value.r, value.g, value.b, value.a);
		}
	}

	// Token: 0x17002460 RID: 9312
	// (get) Token: 0x0601B737 RID: 112439 RVA: 0x00877274 File Offset: 0x00875674
	// (set) Token: 0x0601B738 RID: 112440 RVA: 0x00877286 File Offset: 0x00875686
	public float Alpha
	{
		get
		{
			return UniWebViewInterface.GetWebViewAlpha(this.listener.Name);
		}
		set
		{
			UniWebViewInterface.SetWebViewAlpha(this.listener.Name, value);
		}
	}

	// Token: 0x0601B739 RID: 112441 RVA: 0x00877299 File Offset: 0x00875699
	public void SetShowSpinnerWhileLoading(bool flag)
	{
		UniWebViewInterface.SetShowSpinnerWhileLoading(this.listener.Name, flag);
	}

	// Token: 0x0601B73A RID: 112442 RVA: 0x008772AC File Offset: 0x008756AC
	public void SetSpinnerText(string text)
	{
		UniWebViewInterface.SetSpinnerText(this.listener.Name, text);
	}

	// Token: 0x0601B73B RID: 112443 RVA: 0x008772BF File Offset: 0x008756BF
	public void SetHorizontalScrollBarEnabled(bool enabled)
	{
		UniWebViewInterface.SetHorizontalScrollBarEnabled(this.listener.Name, enabled);
	}

	// Token: 0x0601B73C RID: 112444 RVA: 0x008772D2 File Offset: 0x008756D2
	public void SetVerticalScrollBarEnabled(bool enabled)
	{
		UniWebViewInterface.SetVerticalScrollBarEnabled(this.listener.Name, enabled);
	}

	// Token: 0x0601B73D RID: 112445 RVA: 0x008772E5 File Offset: 0x008756E5
	public void SetBouncesEnabled(bool enabled)
	{
		UniWebViewInterface.SetBouncesEnabled(this.listener.Name, enabled);
	}

	// Token: 0x0601B73E RID: 112446 RVA: 0x008772F8 File Offset: 0x008756F8
	public void SetZoomEnabled(bool enabled)
	{
		UniWebViewInterface.SetZoomEnabled(this.listener.Name, enabled);
	}

	// Token: 0x0601B73F RID: 112447 RVA: 0x0087730B File Offset: 0x0087570B
	public void AddPermissionTrustDomain(string domain)
	{
		UniWebViewInterface.AddPermissionTrustDomain(this.listener.Name, domain);
	}

	// Token: 0x0601B740 RID: 112448 RVA: 0x0087731E File Offset: 0x0087571E
	public void RemovePermissionTrustDomain(string domain)
	{
		UniWebViewInterface.RemovePermissionTrustDomain(this.listener.Name, domain);
	}

	// Token: 0x0601B741 RID: 112449 RVA: 0x00877331 File Offset: 0x00875731
	public void SetBackButtonEnabled(bool enabled)
	{
		UniWebViewInterface.SetBackButtonEnabled(this.listener.Name, enabled);
	}

	// Token: 0x0601B742 RID: 112450 RVA: 0x00877344 File Offset: 0x00875744
	public void SetUseWideViewPort(bool flag)
	{
		UniWebViewInterface.SetUseWideViewPort(this.listener.Name, flag);
	}

	// Token: 0x0601B743 RID: 112451 RVA: 0x00877357 File Offset: 0x00875757
	public void SetLoadWithOverviewMode(bool flag)
	{
		UniWebViewInterface.SetLoadWithOverviewMode(this.listener.Name, flag);
	}

	// Token: 0x0601B744 RID: 112452 RVA: 0x0087736A File Offset: 0x0087576A
	public void SetImmersiveModeEnabled(bool enabled)
	{
		UniWebViewInterface.SetImmersiveModeEnabled(this.listener.Name, enabled);
	}

	// Token: 0x0601B745 RID: 112453 RVA: 0x0087737D File Offset: 0x0087577D
	public void SetShowToolbar(bool show, bool animated = false, bool onTop = true, bool adjustInset = false)
	{
	}

	// Token: 0x0601B746 RID: 112454 RVA: 0x0087737F File Offset: 0x0087577F
	public void SetToolbarDoneButtonText(string text)
	{
	}

	// Token: 0x0601B747 RID: 112455 RVA: 0x00877381 File Offset: 0x00875781
	public static void SetWebContentsDebuggingEnabled(bool enabled)
	{
		UniWebViewInterface.SetWebContentsDebuggingEnabled(enabled);
	}

	// Token: 0x0601B748 RID: 112456 RVA: 0x00877389 File Offset: 0x00875789
	public void SetWindowUserResizeEnabled(bool enabled)
	{
	}

	// Token: 0x0601B749 RID: 112457 RVA: 0x0087738C File Offset: 0x0087578C
	public void GetHTMLContent(Action<string> handler)
	{
		this.EvaluateJavaScript("document.documentElement.outerHTML", delegate(UniWebViewNativeResultPayload payload)
		{
			if (handler != null)
			{
				handler(payload.data);
			}
		});
	}

	// Token: 0x0601B74A RID: 112458 RVA: 0x008773BD File Offset: 0x008757BD
	private void OnDestroy()
	{
		UniWebViewInterface.Destroy(this.listener.Name);
		Object.Destroy(this.listener.gameObject);
	}

	// Token: 0x0601B74B RID: 112459 RVA: 0x008773DF File Offset: 0x008757DF
	private void OnApplicationPause(bool pause)
	{
		UniWebViewInterface.ShowWebViewDialog(this.listener.Name, !pause);
	}

	// Token: 0x0601B74C RID: 112460 RVA: 0x008773F8 File Offset: 0x008757F8
	internal void InternalOnShowTransitionFinished(string identifier)
	{
		Action action;
		if (this.actions.TryGetValue(identifier, out action))
		{
			action();
			this.actions.Remove(identifier);
		}
	}

	// Token: 0x0601B74D RID: 112461 RVA: 0x0087742C File Offset: 0x0087582C
	internal void InternalOnHideTransitionFinished(string identifier)
	{
		Action action;
		if (this.actions.TryGetValue(identifier, out action))
		{
			action();
			this.actions.Remove(identifier);
		}
	}

	// Token: 0x0601B74E RID: 112462 RVA: 0x00877460 File Offset: 0x00875860
	internal void InternalOnAnimateToFinished(string identifier)
	{
		Action action;
		if (this.actions.TryGetValue(identifier, out action))
		{
			action();
			this.actions.Remove(identifier);
		}
	}

	// Token: 0x0601B74F RID: 112463 RVA: 0x00877494 File Offset: 0x00875894
	internal void InternalOnAddJavaScriptFinished(UniWebViewNativeResultPayload payload)
	{
		string identifier = payload.identifier;
		Action<UniWebViewNativeResultPayload> action;
		if (this.payloadActions.TryGetValue(identifier, out action))
		{
			action(payload);
			this.payloadActions.Remove(identifier);
		}
	}

	// Token: 0x0601B750 RID: 112464 RVA: 0x008774D0 File Offset: 0x008758D0
	internal void InternalOnEvalJavaScriptFinished(UniWebViewNativeResultPayload payload)
	{
		string identifier = payload.identifier;
		Action<UniWebViewNativeResultPayload> action;
		if (this.payloadActions.TryGetValue(identifier, out action))
		{
			action(payload);
			this.payloadActions.Remove(identifier);
		}
	}

	// Token: 0x0601B751 RID: 112465 RVA: 0x0087750C File Offset: 0x0087590C
	internal void InternalOnPageFinished(UniWebViewNativeResultPayload payload)
	{
		if (this.OnPageFinished != null)
		{
			int statusCode = -1;
			if (int.TryParse(payload.resultCode, out statusCode))
			{
				this.OnPageFinished(this, statusCode, payload.data);
			}
			else
			{
				UniWebViewLogger.Instance.Critical("Invalid status code received: " + payload.resultCode);
			}
		}
	}

	// Token: 0x0601B752 RID: 112466 RVA: 0x0087756A File Offset: 0x0087596A
	internal void InternalOnPageStarted(string url)
	{
		if (this.OnPageStarted != null)
		{
			this.OnPageStarted(this, url);
		}
	}

	// Token: 0x0601B753 RID: 112467 RVA: 0x00877584 File Offset: 0x00875984
	internal void InternalOnPageErrorReceived(UniWebViewNativeResultPayload payload)
	{
		if (this.OnPageErrorReceived != null)
		{
			int errorCode = -1;
			if (int.TryParse(payload.resultCode, out errorCode))
			{
				this.OnPageErrorReceived(this, errorCode, payload.data);
			}
			else
			{
				UniWebViewLogger.Instance.Critical("Invalid error code received: " + payload.resultCode);
			}
		}
	}

	// Token: 0x0601B754 RID: 112468 RVA: 0x008775E4 File Offset: 0x008759E4
	internal void InternalOnMessageReceived(string result)
	{
		UniWebViewMessage message = new UniWebViewMessage(result);
		if (this.OnMessageReceived != null)
		{
			this.OnMessageReceived(this, message);
		}
	}

	// Token: 0x0601B755 RID: 112469 RVA: 0x00877611 File Offset: 0x00875A11
	internal void InternalOnWebViewKeyDown(int keyCode)
	{
		if (this.OnKeyCodeReceived != null)
		{
			this.OnKeyCodeReceived(this, keyCode);
		}
	}

	// Token: 0x0601B756 RID: 112470 RVA: 0x0087762C File Offset: 0x00875A2C
	internal void InternalOnShouldClose()
	{
		if (this.OnShouldClose != null)
		{
			bool flag = this.OnShouldClose(this);
			if (flag)
			{
				Object.Destroy(this);
			}
		}
		else
		{
			Object.Destroy(this);
		}
	}

	// Token: 0x040131AA RID: 78250
	private string id = Guid.NewGuid().ToString();

	// Token: 0x040131AB RID: 78251
	private UniWebViewNativeListener listener;

	// Token: 0x040131AC RID: 78252
	private bool isPortrait;

	// Token: 0x040131AD RID: 78253
	[SerializeField]
	private string urlOnStart;

	// Token: 0x040131AE RID: 78254
	[SerializeField]
	private bool showOnStart;

	// Token: 0x040131AF RID: 78255
	private Dictionary<string, Action> actions = new Dictionary<string, Action>();

	// Token: 0x040131B0 RID: 78256
	private Dictionary<string, Action<UniWebViewNativeResultPayload>> payloadActions = new Dictionary<string, Action<UniWebViewNativeResultPayload>>();

	// Token: 0x040131B1 RID: 78257
	[SerializeField]
	private bool fullScreen;

	// Token: 0x040131B2 RID: 78258
	[SerializeField]
	private Rect frame;

	// Token: 0x040131B3 RID: 78259
	[SerializeField]
	private RectTransform referenceRectTransform;

	// Token: 0x040131B4 RID: 78260
	[SerializeField]
	private bool useToolbar;

	// Token: 0x040131B5 RID: 78261
	[SerializeField]
	private UniWebViewToolbarPosition toolbarPosition;

	// Token: 0x040131B6 RID: 78262
	private bool started;

	// Token: 0x040131B7 RID: 78263
	private Color backgroundColor = Color.white;

	// Token: 0x02004A39 RID: 19001
	// (Invoke) Token: 0x0601B758 RID: 112472
	public delegate void PageStartedDelegate(UniWebView webView, string url);

	// Token: 0x02004A3A RID: 19002
	// (Invoke) Token: 0x0601B75C RID: 112476
	public delegate void PageFinishedDelegate(UniWebView webView, int statusCode, string url);

	// Token: 0x02004A3B RID: 19003
	// (Invoke) Token: 0x0601B760 RID: 112480
	public delegate void PageErrorReceivedDelegate(UniWebView webView, int errorCode, string errorMessage);

	// Token: 0x02004A3C RID: 19004
	// (Invoke) Token: 0x0601B764 RID: 112484
	public delegate void MessageReceivedDelegate(UniWebView webView, UniWebViewMessage message);

	// Token: 0x02004A3D RID: 19005
	// (Invoke) Token: 0x0601B768 RID: 112488
	public delegate bool ShouldCloseDelegate(UniWebView webView);

	// Token: 0x02004A3E RID: 19006
	// (Invoke) Token: 0x0601B76C RID: 112492
	public delegate void KeyCodeReceivedDelegate(UniWebView webView, int keyCode);

	// Token: 0x02004A3F RID: 19007
	// (Invoke) Token: 0x0601B770 RID: 112496
	public delegate void OreintationChangedDelegate(UniWebView webView, ScreenOrientation orientation);
}
