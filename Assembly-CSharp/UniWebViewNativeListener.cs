using System;
using UnityEngine;

// Token: 0x02004A44 RID: 19012
public class UniWebViewNativeListener : MonoBehaviour
{
	// Token: 0x17002467 RID: 9319
	// (get) Token: 0x0601B789 RID: 112521 RVA: 0x008779D1 File Offset: 0x00875DD1
	public string Name
	{
		get
		{
			return base.gameObject.name;
		}
	}

	// Token: 0x0601B78A RID: 112522 RVA: 0x008779DE File Offset: 0x00875DDE
	private void PageStarted(string url)
	{
		UniWebViewLogger.Instance.Info("Page Started Event. Url: " + url);
		this.webView.InternalOnPageStarted(url);
	}

	// Token: 0x0601B78B RID: 112523 RVA: 0x00877A04 File Offset: 0x00875E04
	private void PageFinished(string result)
	{
		UniWebViewLogger.Instance.Info("Page Finished Event. Url: " + result);
		UniWebViewNativeResultPayload payload = JsonUtility.FromJson<UniWebViewNativeResultPayload>(result);
		this.webView.InternalOnPageFinished(payload);
	}

	// Token: 0x0601B78C RID: 112524 RVA: 0x00877A3C File Offset: 0x00875E3C
	private void PageErrorReceived(string result)
	{
		UniWebViewLogger.Instance.Info("Page Error Received Event. Result: " + result);
		UniWebViewNativeResultPayload payload = JsonUtility.FromJson<UniWebViewNativeResultPayload>(result);
		this.webView.InternalOnPageErrorReceived(payload);
	}

	// Token: 0x0601B78D RID: 112525 RVA: 0x00877A71 File Offset: 0x00875E71
	private void ShowTransitionFinished(string identifer)
	{
		UniWebViewLogger.Instance.Info("Show Transition Finished Event. Identifier: " + identifer);
		this.webView.InternalOnShowTransitionFinished(identifer);
	}

	// Token: 0x0601B78E RID: 112526 RVA: 0x00877A94 File Offset: 0x00875E94
	private void HideTransitionFinished(string identifer)
	{
		UniWebViewLogger.Instance.Info("Hide Transition Finished Event. Identifier: " + identifer);
		this.webView.InternalOnHideTransitionFinished(identifer);
	}

	// Token: 0x0601B78F RID: 112527 RVA: 0x00877AB7 File Offset: 0x00875EB7
	private void AnimateToFinished(string identifer)
	{
		UniWebViewLogger.Instance.Info("Animate To Finished Event. Identifier: " + identifer);
		this.webView.InternalOnAnimateToFinished(identifer);
	}

	// Token: 0x0601B790 RID: 112528 RVA: 0x00877ADC File Offset: 0x00875EDC
	private void AddJavaScriptFinished(string result)
	{
		UniWebViewLogger.Instance.Info("Add JavaScript Finished Event. Result: " + result);
		UniWebViewNativeResultPayload payload = JsonUtility.FromJson<UniWebViewNativeResultPayload>(result);
		this.webView.InternalOnAddJavaScriptFinished(payload);
	}

	// Token: 0x0601B791 RID: 112529 RVA: 0x00877B14 File Offset: 0x00875F14
	private void EvalJavaScriptFinished(string result)
	{
		UniWebViewLogger.Instance.Info("Eval JavaScript Finished Event. Result: " + result);
		UniWebViewNativeResultPayload payload = JsonUtility.FromJson<UniWebViewNativeResultPayload>(result);
		this.webView.InternalOnEvalJavaScriptFinished(payload);
	}

	// Token: 0x0601B792 RID: 112530 RVA: 0x00877B49 File Offset: 0x00875F49
	private void MessageReceived(string result)
	{
		UniWebViewLogger.Instance.Info("Message Received Event. Result: " + result);
		this.webView.InternalOnMessageReceived(result);
	}

	// Token: 0x0601B793 RID: 112531 RVA: 0x00877B6C File Offset: 0x00875F6C
	private void WebViewKeyDown(string keyCode)
	{
		UniWebViewLogger.Instance.Info("Web View Key Down: " + keyCode);
		int keyCode2;
		if (int.TryParse(keyCode, out keyCode2))
		{
			this.webView.InternalOnWebViewKeyDown(keyCode2);
		}
		else
		{
			UniWebViewLogger.Instance.Critical("Failed in converting key code: " + keyCode);
		}
	}

	// Token: 0x0601B794 RID: 112532 RVA: 0x00877BC1 File Offset: 0x00875FC1
	private void WebViewDone()
	{
		UniWebViewLogger.Instance.Info("Web View Done Event.");
		this.webView.InternalOnShouldClose();
	}

	// Token: 0x040131C4 RID: 78276
	[HideInInspector]
	public UniWebView webView;
}
