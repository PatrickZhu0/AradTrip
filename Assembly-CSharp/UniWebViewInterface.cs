using System;
using UnityEngine;

// Token: 0x02004A48 RID: 19016
public class UniWebViewInterface
{
	// Token: 0x0601B797 RID: 112535 RVA: 0x00877BED File Offset: 0x00875FED
	public static void SetLogLevel(int level)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("setLogLevel", new object[]
		{
			level
		});
	}

	// Token: 0x0601B798 RID: 112536 RVA: 0x00877C14 File Offset: 0x00876014
	public static void Init(string name, int x, int y, int width, int height)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("init", new object[]
		{
			name,
			x,
			y,
			width,
			height
		});
	}

	// Token: 0x0601B799 RID: 112537 RVA: 0x00877C64 File Offset: 0x00876064
	public static void Destroy(string name)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("destroy", new object[]
		{
			name
		});
	}

	// Token: 0x0601B79A RID: 112538 RVA: 0x00877C84 File Offset: 0x00876084
	public static void Load(string name, string url, bool skipEncoding)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("load", new object[]
		{
			name,
			url
		});
	}

	// Token: 0x0601B79B RID: 112539 RVA: 0x00877CA8 File Offset: 0x008760A8
	public static void LoadHTMLString(string name, string html, string baseUrl, bool skipEncoding)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("loadHTMLString", new object[]
		{
			name,
			html,
			baseUrl
		});
	}

	// Token: 0x0601B79C RID: 112540 RVA: 0x00877CD0 File Offset: 0x008760D0
	public static void Reload(string name)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("reload", new object[]
		{
			name
		});
	}

	// Token: 0x0601B79D RID: 112541 RVA: 0x00877CF0 File Offset: 0x008760F0
	public static void Stop(string name)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("stop", new object[]
		{
			name
		});
	}

	// Token: 0x0601B79E RID: 112542 RVA: 0x00877D10 File Offset: 0x00876110
	public static string GetUrl(string name)
	{
		UniWebViewInterface.CheckPlatform();
		return UniWebViewInterface.plugin.CallStatic<string>("getUrl", new object[]
		{
			name
		});
	}

	// Token: 0x0601B79F RID: 112543 RVA: 0x00877D30 File Offset: 0x00876130
	public static void SetFrame(string name, int x, int y, int width, int height)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("setFrame", new object[]
		{
			name,
			x,
			y,
			width,
			height
		});
	}

	// Token: 0x0601B7A0 RID: 112544 RVA: 0x00877D80 File Offset: 0x00876180
	public static void SetPosition(string name, int x, int y)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("setPosition", new object[]
		{
			name,
			x,
			y
		});
	}

	// Token: 0x0601B7A1 RID: 112545 RVA: 0x00877DB2 File Offset: 0x008761B2
	public static void SetSize(string name, int width, int height)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("setSize", new object[]
		{
			name,
			width,
			height
		});
	}

	// Token: 0x0601B7A2 RID: 112546 RVA: 0x00877DE4 File Offset: 0x008761E4
	public static bool Show(string name, bool fade, int edge, float duration, string identifier)
	{
		UniWebViewInterface.CheckPlatform();
		return UniWebViewInterface.plugin.CallStatic<bool>("show", new object[]
		{
			name,
			fade,
			edge,
			duration,
			identifier
		});
	}

	// Token: 0x0601B7A3 RID: 112547 RVA: 0x00877E24 File Offset: 0x00876224
	public static bool Hide(string name, bool fade, int edge, float duration, string identifier)
	{
		UniWebViewInterface.CheckPlatform();
		return UniWebViewInterface.plugin.CallStatic<bool>("hide", new object[]
		{
			name,
			fade,
			edge,
			duration,
			identifier
		});
	}

	// Token: 0x0601B7A4 RID: 112548 RVA: 0x00877E64 File Offset: 0x00876264
	public static bool AnimateTo(string name, int x, int y, int width, int height, float duration, float delay, string identifier)
	{
		UniWebViewInterface.CheckPlatform();
		return UniWebViewInterface.plugin.CallStatic<bool>("animateTo", new object[]
		{
			name,
			x,
			y,
			width,
			height,
			duration,
			delay,
			identifier
		});
	}

	// Token: 0x0601B7A5 RID: 112549 RVA: 0x00877ECD File Offset: 0x008762CD
	public static void AddJavaScript(string name, string jsString, string identifier)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("addJavaScript", new object[]
		{
			name,
			jsString,
			identifier
		});
	}

	// Token: 0x0601B7A6 RID: 112550 RVA: 0x00877EF5 File Offset: 0x008762F5
	public static void EvaluateJavaScript(string name, string jsString, string identifier)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("evaluateJavaScript", new object[]
		{
			name,
			jsString,
			identifier
		});
	}

	// Token: 0x0601B7A7 RID: 112551 RVA: 0x00877F1D File Offset: 0x0087631D
	public static void AddUrlScheme(string name, string scheme)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("addUrlScheme", new object[]
		{
			name,
			scheme
		});
	}

	// Token: 0x0601B7A8 RID: 112552 RVA: 0x00877F41 File Offset: 0x00876341
	public static void RemoveUrlScheme(string name, string scheme)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("removeUrlScheme", new object[]
		{
			name,
			scheme
		});
	}

	// Token: 0x0601B7A9 RID: 112553 RVA: 0x00877F65 File Offset: 0x00876365
	public static void AddSslExceptionDomain(string name, string domain)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("addSslExceptionDomain", new object[]
		{
			name,
			domain
		});
	}

	// Token: 0x0601B7AA RID: 112554 RVA: 0x00877F89 File Offset: 0x00876389
	public static void RemoveSslExceptionDomain(string name, string domain)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("removeSslExceptionDomain", new object[]
		{
			name,
			domain
		});
	}

	// Token: 0x0601B7AB RID: 112555 RVA: 0x00877FAD File Offset: 0x008763AD
	public static void AddPermissionTrustDomain(string name, string domain)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("addPermissionTrustDomain", new object[]
		{
			name,
			domain
		});
	}

	// Token: 0x0601B7AC RID: 112556 RVA: 0x00877FD1 File Offset: 0x008763D1
	public static void RemovePermissionTrustDomain(string name, string domain)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("removePermissionTrustDomain", new object[]
		{
			name,
			domain
		});
	}

	// Token: 0x0601B7AD RID: 112557 RVA: 0x00877FF5 File Offset: 0x008763F5
	public static void SetHeaderField(string name, string key, string value)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("setHeaderField", new object[]
		{
			name,
			key,
			value
		});
	}

	// Token: 0x0601B7AE RID: 112558 RVA: 0x0087801D File Offset: 0x0087641D
	public static void SetUserAgent(string name, string userAgent)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("setUserAgent", new object[]
		{
			name,
			userAgent
		});
	}

	// Token: 0x0601B7AF RID: 112559 RVA: 0x00878041 File Offset: 0x00876441
	public static string GetUserAgent(string name)
	{
		UniWebViewInterface.CheckPlatform();
		return UniWebViewInterface.plugin.CallStatic<string>("getUserAgent", new object[]
		{
			name
		});
	}

	// Token: 0x0601B7B0 RID: 112560 RVA: 0x00878061 File Offset: 0x00876461
	public static void SetAllowAutoPlay(bool flag)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("setAllowAutoPlay", new object[]
		{
			flag
		});
	}

	// Token: 0x0601B7B1 RID: 112561 RVA: 0x00878086 File Offset: 0x00876486
	public static void SetAllowJavaScriptOpenWindow(bool flag)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("setAllowJavaScriptOpenWindow", new object[]
		{
			flag
		});
	}

	// Token: 0x0601B7B2 RID: 112562 RVA: 0x008780AB File Offset: 0x008764AB
	public static void SetJavaScriptEnabled(bool enabled)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("setJavaScriptEnabled", new object[]
		{
			enabled
		});
	}

	// Token: 0x0601B7B3 RID: 112563 RVA: 0x008780D0 File Offset: 0x008764D0
	public static void CleanCache(string name)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("cleanCache", new object[]
		{
			name
		});
	}

	// Token: 0x0601B7B4 RID: 112564 RVA: 0x008780F0 File Offset: 0x008764F0
	public static void ClearCookies()
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("clearCookies", new object[0]);
	}

	// Token: 0x0601B7B5 RID: 112565 RVA: 0x0087810C File Offset: 0x0087650C
	public static void SetCookie(string url, string cookie, bool skipEncoding)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("setCookie", new object[]
		{
			url,
			cookie
		});
	}

	// Token: 0x0601B7B6 RID: 112566 RVA: 0x00878130 File Offset: 0x00876530
	public static string GetCookie(string url, string key, bool skipEncoding)
	{
		UniWebViewInterface.CheckPlatform();
		return UniWebViewInterface.plugin.CallStatic<string>("getCookie", new object[]
		{
			url,
			key
		});
	}

	// Token: 0x0601B7B7 RID: 112567 RVA: 0x00878154 File Offset: 0x00876554
	public static void ClearHttpAuthUsernamePassword(string host, string realm)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("clearHttpAuthUsernamePassword", new object[]
		{
			host,
			realm
		});
	}

	// Token: 0x0601B7B8 RID: 112568 RVA: 0x00878178 File Offset: 0x00876578
	public static void SetBackgroundColor(string name, float r, float g, float b, float a)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("setBackgroundColor", new object[]
		{
			name,
			r,
			g,
			b,
			a
		});
	}

	// Token: 0x0601B7B9 RID: 112569 RVA: 0x008781C8 File Offset: 0x008765C8
	public static void SetWebViewAlpha(string name, float alpha)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("setWebViewAlpha", new object[]
		{
			name,
			alpha
		});
	}

	// Token: 0x0601B7BA RID: 112570 RVA: 0x008781F1 File Offset: 0x008765F1
	public static float GetWebViewAlpha(string name)
	{
		UniWebViewInterface.CheckPlatform();
		return UniWebViewInterface.plugin.CallStatic<float>("getWebViewAlpha", new object[]
		{
			name
		});
	}

	// Token: 0x0601B7BB RID: 112571 RVA: 0x00878211 File Offset: 0x00876611
	public static void SetShowSpinnerWhileLoading(string name, bool show)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("setShowSpinnerWhileLoading", new object[]
		{
			name,
			show
		});
	}

	// Token: 0x0601B7BC RID: 112572 RVA: 0x0087823A File Offset: 0x0087663A
	public static void SetSpinnerText(string name, string text)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("setSpinnerText", new object[]
		{
			name,
			text
		});
	}

	// Token: 0x0601B7BD RID: 112573 RVA: 0x0087825E File Offset: 0x0087665E
	public static bool CanGoBack(string name)
	{
		UniWebViewInterface.CheckPlatform();
		return UniWebViewInterface.plugin.CallStatic<bool>("canGoBack", new object[]
		{
			name
		});
	}

	// Token: 0x0601B7BE RID: 112574 RVA: 0x0087827E File Offset: 0x0087667E
	public static bool CanGoForward(string name)
	{
		UniWebViewInterface.CheckPlatform();
		return UniWebViewInterface.plugin.CallStatic<bool>("canGoForward", new object[]
		{
			name
		});
	}

	// Token: 0x0601B7BF RID: 112575 RVA: 0x0087829E File Offset: 0x0087669E
	public static void GoBack(string name)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("goBack", new object[]
		{
			name
		});
	}

	// Token: 0x0601B7C0 RID: 112576 RVA: 0x008782BE File Offset: 0x008766BE
	public static void GoForward(string name)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("goForward", new object[]
		{
			name
		});
	}

	// Token: 0x0601B7C1 RID: 112577 RVA: 0x008782DE File Offset: 0x008766DE
	public static void SetOpenLinksInExternalBrowser(string name, bool flag)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("setOpenLinksInExternalBrowser", new object[]
		{
			name,
			flag
		});
	}

	// Token: 0x0601B7C2 RID: 112578 RVA: 0x00878307 File Offset: 0x00876707
	public static void SetHorizontalScrollBarEnabled(string name, bool enabled)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("setHorizontalScrollBarEnabled", new object[]
		{
			name,
			enabled
		});
	}

	// Token: 0x0601B7C3 RID: 112579 RVA: 0x00878330 File Offset: 0x00876730
	public static void SetVerticalScrollBarEnabled(string name, bool enabled)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("setVerticalScrollBarEnabled", new object[]
		{
			name,
			enabled
		});
	}

	// Token: 0x0601B7C4 RID: 112580 RVA: 0x00878359 File Offset: 0x00876759
	public static void SetBouncesEnabled(string name, bool enabled)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("setBouncesEnabled", new object[]
		{
			name,
			enabled
		});
	}

	// Token: 0x0601B7C5 RID: 112581 RVA: 0x00878382 File Offset: 0x00876782
	public static void SetZoomEnabled(string name, bool enabled)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("setZoomEnabled", new object[]
		{
			name,
			enabled
		});
	}

	// Token: 0x0601B7C6 RID: 112582 RVA: 0x008783AB File Offset: 0x008767AB
	public static void SetBackButtonEnabled(string name, bool enabled)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("setBackButtonEnabled", new object[]
		{
			name,
			enabled
		});
	}

	// Token: 0x0601B7C7 RID: 112583 RVA: 0x008783D4 File Offset: 0x008767D4
	public static void SetUseWideViewPort(string name, bool use)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("setUseWideViewPort", new object[]
		{
			name,
			use
		});
	}

	// Token: 0x0601B7C8 RID: 112584 RVA: 0x008783FD File Offset: 0x008767FD
	public static void SetLoadWithOverviewMode(string name, bool overview)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("setLoadWithOverviewMode", new object[]
		{
			name,
			overview
		});
	}

	// Token: 0x0601B7C9 RID: 112585 RVA: 0x00878426 File Offset: 0x00876826
	public static void SetImmersiveModeEnabled(string name, bool enabled)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("setImmersiveModeEnabled", new object[]
		{
			name,
			enabled
		});
	}

	// Token: 0x0601B7CA RID: 112586 RVA: 0x0087844F File Offset: 0x0087684F
	public static void SetWebContentsDebuggingEnabled(bool enabled)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("setWebContentsDebuggingEnabled", new object[]
		{
			enabled
		});
	}

	// Token: 0x0601B7CB RID: 112587 RVA: 0x00878474 File Offset: 0x00876874
	public static void ShowWebViewDialog(string name, bool show)
	{
		UniWebViewInterface.CheckPlatform();
		UniWebViewInterface.plugin.CallStatic("showWebViewDialog", new object[]
		{
			name,
			show
		});
	}

	// Token: 0x0601B7CC RID: 112588 RVA: 0x0087849D File Offset: 0x0087689D
	public static void CheckPlatform()
	{
		if (!UniWebViewInterface.correctPlatform)
		{
			throw new InvalidOperationException("Method can only be performed on Android.");
		}
	}

	// Token: 0x040131D1 RID: 78289
	private static AndroidJavaClass plugin = new AndroidJavaClass("com.onevcat.uniwebview.UniWebViewInterface");

	// Token: 0x040131D2 RID: 78290
	private static bool correctPlatform = Application.platform == 11;
}
