using System;
using System.Collections.Generic;
using GameClient;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020017FC RID: 6140
[RequireComponent(typeof(UniWebView))]
public class UniWebViewUtility : MonoBehaviour
{
	// Token: 0x0600F215 RID: 61973 RVA: 0x00414B25 File Offset: 0x00412F25
	private void Start()
	{
		UniWebViewLogger.Instance.LogLevel = UniWebViewLogger.Level.Off;
		this.showLog = false;
	}

	// Token: 0x0600F216 RID: 61974 RVA: 0x00414B3C File Offset: 0x00412F3C
	private UniWebView CreateWebView()
	{
		UniWebView uniWebView = base.GetComponent<UniWebView>();
		if (this.webViewNormal)
		{
			this.contentRect = this.webViewNormal.rectTransform.rect;
		}
		if (this.webViewChanged)
		{
			this.contentRect2 = this.webViewChanged.rectTransform.rect;
		}
		if (uniWebView == null)
		{
			uniWebView = this.webViewNormal.gameObject.AddComponent<UniWebView>();
		}
		if (uniWebView != null)
		{
			uniWebView.Frame = this.contentRect;
			uniWebView.ReferenceRectTransform = this.webViewNormal.rectTransform;
			uniWebView.SetShowSpinnerWhileLoading(true);
			uniWebView.SetSpinnerText("正在努力加载中...请稍候...");
			uniWebView.SetVerticalScrollBarEnabled(true);
			uniWebView.BackgroundColor = new Color(1f, 1f, 1f, 0f);
		}
		return uniWebView;
	}

	// Token: 0x0600F217 RID: 61975 RVA: 0x00414C1B File Offset: 0x0041301B
	public void InitWebView(bool needClearCache = false)
	{
		this.needClearCache = needClearCache;
		if (this.mUniWebView == null)
		{
			this.mUniWebView = this.CreateWebView();
			this.AddWebViewEventHandler();
		}
	}

	// Token: 0x0600F218 RID: 61976 RVA: 0x00414C48 File Offset: 0x00413048
	public void UnInitWebView()
	{
		if (this.mUniWebView != null)
		{
			this.RemoveWebViewEventHandler();
			this.HideWebView();
			this.TryClearWebCache();
			this.PageStarted = null;
			this.PageFinished = null;
			this.PageErrorReceived = null;
			this.PageLoadReveiveMsg = null;
			this.mUniWebView = null;
		}
	}

	// Token: 0x0600F219 RID: 61977 RVA: 0x00414C9B File Offset: 0x0041309B
	public void LoadUrl(string url)
	{
		if (this.mUniWebView != null)
		{
			this.mUniWebView.Load(url, false);
		}
	}

	// Token: 0x0600F21A RID: 61978 RVA: 0x00414CBB File Offset: 0x004130BB
	public void ReLoadUrl()
	{
		if (this.mUniWebView != null)
		{
			this.mUniWebView.Reload();
		}
	}

	// Token: 0x0600F21B RID: 61979 RVA: 0x00414CD9 File Offset: 0x004130D9
	public void ShowWebView()
	{
		if (this.mUniWebView != null)
		{
			this.mUniWebView.Show(false, UniWebViewTransitionEdge.None, 0.4f, null);
		}
	}

	// Token: 0x0600F21C RID: 61980 RVA: 0x00414D00 File Offset: 0x00413100
	public void ShowWebViewFade()
	{
		if (this.mUniWebView != null)
		{
			this.mUniWebView.Show(true, UniWebViewTransitionEdge.None, 0.4f, null);
		}
	}

	// Token: 0x0600F21D RID: 61981 RVA: 0x00414D27 File Offset: 0x00413127
	public void HideWebView()
	{
		if (this.mUniWebView != null)
		{
			this.mUniWebView.Stop();
			this.mUniWebView.Hide(false, UniWebViewTransitionEdge.None, 0.4f, null);
		}
	}

	// Token: 0x0600F21E RID: 61982 RVA: 0x00414D59 File Offset: 0x00413159
	public void HideWebViewFade()
	{
		if (this.mUniWebView != null)
		{
			this.mUniWebView.Stop();
			this.mUniWebView.Hide(true, UniWebViewTransitionEdge.None, 0.4f, null);
		}
	}

	// Token: 0x0600F21F RID: 61983 RVA: 0x00414D8B File Offset: 0x0041318B
	public void GoBackWebView()
	{
		if (this.mUniWebView != null && this.mUniWebView.CanGoBack)
		{
			this.mUniWebView.GoBack();
		}
	}

	// Token: 0x0600F220 RID: 61984 RVA: 0x00414DB9 File Offset: 0x004131B9
	public bool CanWebViewGoBack()
	{
		return this.mUniWebView != null && this.mUniWebView.CanGoBack;
	}

	// Token: 0x0600F221 RID: 61985 RVA: 0x00414DD9 File Offset: 0x004131D9
	public void TweenMoveTo(float durationTime)
	{
		if (this.mUniWebView != null)
		{
			this.mUniWebView.AnimateTo(this.mUniWebView.Frame, durationTime, 0f, null);
		}
	}

	// Token: 0x0600F222 RID: 61986 RVA: 0x00414E0C File Offset: 0x0041320C
	public void ResetWebViewShow(bool toOriginal, float duration)
	{
		if (this.mUniWebView != null)
		{
			if (toOriginal)
			{
				this.mUniWebView.Frame = this.contentRect;
				this.mUniWebView.ReferenceRectTransform = this.webViewNormal.rectTransform;
			}
			else
			{
				this.contentRect2 = new Rect(this.contentRect2.x, this.contentRect2.y, this.contentRect2.width, this.contentRect.height - (float)this.bottomOffset);
				this.mUniWebView.Frame = this.contentRect2;
				this.mUniWebView.ReferenceRectTransform = this.webViewChanged.rectTransform;
			}
			this.mUniWebView.UpdateFrame();
		}
	}

	// Token: 0x0600F223 RID: 61987 RVA: 0x00414ECD File Offset: 0x004132CD
	public void AddJS(string js, Action<UniWebViewNativeResultPayload> cb = null)
	{
		if (this.mUniWebView != null)
		{
			this.mUniWebView.AddJavaScript(js, cb);
		}
	}

	// Token: 0x0600F224 RID: 61988 RVA: 0x00414EED File Offset: 0x004132ED
	public void ExcuteJS(string js, Action<UniWebViewNativeResultPayload> cb = null)
	{
		if (this.mUniWebView != null)
		{
			this.mUniWebView.EvaluateJavaScript(js, cb);
		}
	}

	// Token: 0x0600F225 RID: 61989 RVA: 0x00414F0D File Offset: 0x0041330D
	public void OnUpdate(float deltaTime)
	{
		if (this.PageViewUpdate != null && this.updateFlag)
		{
			this.PageViewUpdate();
			this.updateFlag = false;
		}
	}

	// Token: 0x0600F226 RID: 61990 RVA: 0x00414F37 File Offset: 0x00413337
	private void TryClearWebCache()
	{
		if (this.needClearCache && this.mUniWebView != null)
		{
			this.mUniWebView.CleanCache();
		}
	}

	// Token: 0x0600F227 RID: 61991 RVA: 0x00414F60 File Offset: 0x00413360
	private void AddUrlSchemes(string scheme)
	{
		if (this.mUniWebView != null && !string.IsNullOrEmpty(scheme))
		{
			this.mUniWebView.AddUrlScheme(scheme);
			if (this.urlSchemeList == null)
			{
				return;
			}
			if (!this.urlSchemeList.Contains(scheme))
			{
				this.urlSchemeList.Add(scheme);
			}
		}
	}

	// Token: 0x0600F228 RID: 61992 RVA: 0x00414FC0 File Offset: 0x004133C0
	private void RemoveAllUrlSchemes()
	{
		if (this.urlSchemeList == null)
		{
			return;
		}
		if (this.mUniWebView != null)
		{
			for (int i = 0; i < this.urlSchemeList.Count; i++)
			{
				this.mUniWebView.RemoveUrlScheme(this.urlSchemeList[i]);
			}
		}
		this.urlSchemeList = null;
	}

	// Token: 0x0600F229 RID: 61993 RVA: 0x00415024 File Offset: 0x00413424
	private bool HasUrlScheme(string urlScheme)
	{
		return this.urlSchemeList != null && this.urlSchemeList.Count != 0 && this.urlSchemeList.Contains(urlScheme);
	}

	// Token: 0x0600F22A RID: 61994 RVA: 0x00415058 File Offset: 0x00413458
	private void OnKeyboardShowOut(string res)
	{
		bool flag = false;
		if (res.Equals("0"))
		{
			flag = false;
		}
		else if (res.Equals("1"))
		{
			flag = true;
		}
		if (flag && SDKInterface.instance.GetKeyboardSize() > 0)
		{
			this.bottomOffset = SDKInterface.instance.GetKeyboardSize();
			this.ResetWebViewShow(false, 0.5f);
		}
		else
		{
			this.bottomOffset = 0;
			this.ResetWebViewShow(true, 0.5f);
		}
	}

	// Token: 0x0600F22B RID: 61995 RVA: 0x004150DC File Offset: 0x004134DC
	private void AddWebViewEventHandler()
	{
		if (this.mUniWebView != null)
		{
			this.mUniWebView.OnPageStarted += this.OnPageStart;
			this.mUniWebView.OnPageFinished += this.OnPageFinish;
			this.mUniWebView.OnPageErrorReceived += this.OnPageError;
			this.mUniWebView.OnMessageReceived += this.OnPageMsgReceived;
			this.mUniWebView.OnShouldClose += ((UniWebView view) => false);
			Singleton<PluginManager>.GetInstance().AddKeyboardShowListener(new SDKInterface.KeyboardShowOut(this.OnKeyboardShowOut));
		}
	}

	// Token: 0x0600F22C RID: 61996 RVA: 0x00415194 File Offset: 0x00413594
	private void RemoveWebViewEventHandler()
	{
		if (this.mUniWebView != null)
		{
			this.mUniWebView.OnPageStarted -= this.OnPageStart;
			this.mUniWebView.OnPageFinished -= this.OnPageFinish;
			this.mUniWebView.OnPageErrorReceived -= this.OnPageError;
			this.mUniWebView.OnMessageReceived -= this.OnPageMsgReceived;
			Singleton<PluginManager>.GetInstance().RemoveKeyboardShowListener();
		}
	}

	// Token: 0x0600F22D RID: 61997 RVA: 0x00415218 File Offset: 0x00413618
	private void OnLoadPageStarted(UIEvent uiEvent)
	{
		if (this.PageStarted != null)
		{
			this.PageStarted();
		}
	}

	// Token: 0x0600F22E RID: 61998 RVA: 0x00415230 File Offset: 0x00413630
	private void OnLoadPageFinished(UIEvent uiEvent)
	{
		if (this.PageFinished != null)
		{
			this.PageFinished();
		}
	}

	// Token: 0x0600F22F RID: 61999 RVA: 0x00415248 File Offset: 0x00413648
	private void OnLoadPageError(UIEvent uiEvent)
	{
		if (this.PageErrorReceived != null)
		{
			this.PageErrorReceived();
		}
	}

	// Token: 0x0600F230 RID: 62000 RVA: 0x00415260 File Offset: 0x00413660
	private void OnPageMsgReceived(UniWebView view, UniWebViewMessage message)
	{
		this.WebViewLog("OnPageMsgReceived : " + message.RawMessage);
		if (message.Equals(null))
		{
			return;
		}
		this.WebViewLog("OnPageMsgReceived rec scheme = " + message.Scheme);
		this.WebViewLog("OnPageMsgReceived rec path = " + message.Path);
		this.WebViewLog("OnPageMsgReceived rec rawMessage = " + message.RawMessage);
		if (this.PageLoadReveiveMsg != null)
		{
			this.PageLoadReveiveMsg(message);
		}
	}

	// Token: 0x0600F231 RID: 62001 RVA: 0x004152F4 File Offset: 0x004136F4
	private void OnPageStart(UniWebView view, string loadingUrl)
	{
		this.WebViewLog(" OnPageStart Loading start url = " + loadingUrl);
	}

	// Token: 0x0600F232 RID: 62002 RVA: 0x00415308 File Offset: 0x00413708
	private void OnPageFinish(UniWebView view, int statusCode, string url)
	{
		if (statusCode == 200)
		{
			this.updateFlag = true;
		}
		this.WebViewLog("OnPageFinished error url : " + this.errorCacheUrl);
		this.WebViewLog(string.Concat(new object[]
		{
			"OnPageFinished success = ",
			statusCode,
			" url = ",
			url
		}));
	}

	// Token: 0x0600F233 RID: 62003 RVA: 0x0041536C File Offset: 0x0041376C
	private void OnPageError(UniWebView view, int errorCode, string errorMsg)
	{
		this.WebViewLog("OnPageErrorReceived error url : " + this.errorCacheUrl);
		this.WebViewLog(string.Concat(new object[]
		{
			"OnPageErrorReceived errorCode = ",
			errorCode,
			" errorMsg = ",
			errorMsg
		}));
	}

	// Token: 0x0600F234 RID: 62004 RVA: 0x004153BD File Offset: 0x004137BD
	private void SetLoadingTextActive(bool active)
	{
	}

	// Token: 0x0600F235 RID: 62005 RVA: 0x004153BF File Offset: 0x004137BF
	private void WebViewLog(string msg)
	{
		if (this.showLog)
		{
			Debug.Log(msg);
		}
	}

	// Token: 0x040094BE RID: 38078
	public const string LoadingNote = "正在努力加载中...请稍候...";

	// Token: 0x040094BF RID: 38079
	public Image webViewNormal;

	// Token: 0x040094C0 RID: 38080
	public Image webViewChanged;

	// Token: 0x040094C1 RID: 38081
	public GameObject loadingTextGo;

	// Token: 0x040094C2 RID: 38082
	private UniWebView mUniWebView;

	// Token: 0x040094C3 RID: 38083
	private Rect contentRect;

	// Token: 0x040094C4 RID: 38084
	private Rect contentRect2;

	// Token: 0x040094C5 RID: 38085
	private int bottomOffset;

	// Token: 0x040094C6 RID: 38086
	private bool needClearCache;

	// Token: 0x040094C7 RID: 38087
	private string currCacheUrl = string.Empty;

	// Token: 0x040094C8 RID: 38088
	private string errorCacheUrl = string.Empty;

	// Token: 0x040094C9 RID: 38089
	private bool beloadErrorUrl;

	// Token: 0x040094CA RID: 38090
	private List<string> urlSchemeList = new List<string>();

	// Token: 0x040094CB RID: 38091
	private bool showLog;

	// Token: 0x040094CC RID: 38092
	private bool updateFlag;

	// Token: 0x040094CD RID: 38093
	[HideInInspector]
	public UniWebViewUtility.OnPageViewUpdate PageViewUpdate;

	// Token: 0x040094CE RID: 38094
	private UniWebViewUtility.OnPageStarted PageStarted;

	// Token: 0x040094CF RID: 38095
	private UniWebViewUtility.OnPageFinished PageFinished;

	// Token: 0x040094D0 RID: 38096
	private UniWebViewUtility.OnPageErrorReceived PageErrorReceived;

	// Token: 0x040094D1 RID: 38097
	[HideInInspector]
	public UniWebViewUtility.OnPageLoadReceiveMsg PageLoadReveiveMsg;

	// Token: 0x020017FD RID: 6141
	// (Invoke) Token: 0x0600F238 RID: 62008
	public delegate void OnPageViewUpdate();

	// Token: 0x020017FE RID: 6142
	// (Invoke) Token: 0x0600F23C RID: 62012
	public delegate void OnPageStarted();

	// Token: 0x020017FF RID: 6143
	// (Invoke) Token: 0x0600F240 RID: 62016
	public delegate void OnPageFinished();

	// Token: 0x02001800 RID: 6144
	// (Invoke) Token: 0x0600F244 RID: 62020
	public delegate void OnPageErrorReceived();

	// Token: 0x02001801 RID: 6145
	// (Invoke) Token: 0x0600F248 RID: 62024
	public delegate void OnPageLoadReceiveMsg(UniWebViewMessage msg);
}
