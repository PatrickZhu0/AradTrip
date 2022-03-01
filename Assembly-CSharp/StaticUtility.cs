using System;
using System.Collections.Generic;
using GameClient;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000205 RID: 517
public static class StaticUtility
{
	// Token: 0x0600108C RID: 4236 RVA: 0x000557FE File Offset: 0x00053BFE
	public static bool Contains(this string source, string value, StringComparison comparisonType)
	{
		return source.IndexOf(value, comparisonType) >= 0;
	}

	// Token: 0x0600108D RID: 4237 RVA: 0x0005580E File Offset: 0x00053C0E
	public static void CustomActive(this MonoBehaviour com, bool bActive)
	{
		if (com == null)
		{
			return;
		}
		if (com != null)
		{
			com.gameObject.CustomActive(bActive);
		}
	}

	// Token: 0x0600108E RID: 4238 RVA: 0x00055835 File Offset: 0x00053C35
	public static void CustomActive(this CanvasGroup canvasGroup, bool bActive)
	{
		if (null == canvasGroup)
		{
			return;
		}
		canvasGroup.alpha = ((!bActive) ? 0f : 1f);
	}

	// Token: 0x0600108F RID: 4239 RVA: 0x0005585F File Offset: 0x00053C5F
	public static void CustomActive(this GameObject gameObject, bool bActive)
	{
		if (gameObject == null)
		{
			return;
		}
		if (gameObject.activeSelf != bActive)
		{
			gameObject.SetActive(bActive);
		}
	}

	// Token: 0x06001090 RID: 4240 RVA: 0x00055881 File Offset: 0x00053C81
	public static void SafeAdd<T1, T2>(this Dictionary<T1, T2> dic, T1 key, T2 value)
	{
		if (dic == null)
		{
			return;
		}
		if (dic.ContainsKey(key))
		{
			dic[key] = value;
		}
		else
		{
			dic.Add(key, value);
		}
	}

	// Token: 0x06001091 RID: 4241 RVA: 0x000558AB File Offset: 0x00053CAB
	public static bool IsNull(this object obj)
	{
		return object.ReferenceEquals(obj, null);
	}

	// Token: 0x06001092 RID: 4242 RVA: 0x000558B4 File Offset: 0x00053CB4
	public static void SafeRemove<T1, T2>(this Dictionary<T1, T2> dic, T1 key)
	{
		if (dic == null)
		{
			return;
		}
		if (dic.ContainsKey(key))
		{
			dic.Remove(key);
		}
	}

	// Token: 0x06001093 RID: 4243 RVA: 0x000558D4 File Offset: 0x00053CD4
	public static T2 SafeGetValue<T1, T2>(this Dictionary<T1, T2> dic, T1 key)
	{
		if (dic == null)
		{
			return default(T2);
		}
		if (dic.ContainsKey(key))
		{
			return dic[key];
		}
		return default(T2);
	}

	// Token: 0x06001094 RID: 4244 RVA: 0x00055910 File Offset: 0x00053D10
	public static void SafeSetBtnCallBack(ComCommonBind bind, string name, UnityAction callBack)
	{
		if (bind == null)
		{
			return;
		}
		Button com = bind.GetCom<Button>(name);
		if (com != null && callBack != null)
		{
			com.onClick.RemoveAllListeners();
			com.onClick.AddListener(callBack);
		}
	}

	// Token: 0x06001095 RID: 4245 RVA: 0x0005595C File Offset: 0x00053D5C
	public static void SafeRmvBtnCallBack(ComCommonBind bind, string name, UnityAction callBack)
	{
		if (bind == null)
		{
			return;
		}
		Button com = bind.GetCom<Button>(name);
		if (com != null && callBack != null)
		{
			com.onClick.RemoveListener(callBack);
		}
	}

	// Token: 0x06001096 RID: 4246 RVA: 0x0005599C File Offset: 0x00053D9C
	public static void SafeSetText(ComCommonBind bind, string name, string text)
	{
		if (bind == null)
		{
			return;
		}
		Text com = bind.GetCom<Text>(name);
		if (com != null)
		{
			com.text = text;
		}
	}

	// Token: 0x06001097 RID: 4247 RVA: 0x000559D4 File Offset: 0x00053DD4
	public static void SafeSetVisible<T>(ComCommonBind bind, string name, bool bVisible) where T : Component
	{
		if (bind == null)
		{
			return;
		}
		T com = bind.GetCom<T>(name);
		if (com != null)
		{
			com.gameObject.CustomActive(bVisible);
		}
	}

	// Token: 0x06001098 RID: 4248 RVA: 0x00055A1C File Offset: 0x00053E1C
	public static void SafeSetVisible(ComCommonBind bind, string name, bool bVisible)
	{
		if (bind == null)
		{
			return;
		}
		GameObject gameObject = bind.GetGameObject(name);
		if (gameObject != null)
		{
			gameObject.CustomActive(bVisible);
		}
	}

	// Token: 0x06001099 RID: 4249 RVA: 0x00055A54 File Offset: 0x00053E54
	public static void SafeSetImage(ComCommonBind bind, string name, string path)
	{
		if (bind == null)
		{
			return;
		}
		Image com = bind.GetCom<Image>(name);
		if (com != null)
		{
			ETCImageLoader.LoadSprite(ref com, path, true);
		}
	}

	// Token: 0x0600109A RID: 4250 RVA: 0x00055A8C File Offset: 0x00053E8C
	public static void ReCalculateRectSizeByLayout(RectTransform rect, RectTransform.Axis axis)
	{
		rect.SetSizeWithCurrentAnchors(axis, LayoutUtility.GetPreferredSize(rect, axis));
	}

	// Token: 0x0600109B RID: 4251 RVA: 0x00055A9C File Offset: 0x00053E9C
	public static T SafeAddComponent<T>(this GameObject gameObject, bool deleteOrigin = true) where T : MonoBehaviour
	{
		if (null == gameObject)
		{
			return (T)((object)null);
		}
		T t = gameObject.GetComponent<T>();
		if (null != t)
		{
			if (!deleteOrigin)
			{
				return t;
			}
			Object.Destroy(t);
			t = (T)((object)null);
		}
		return gameObject.AddComponent<T>();
	}

	// Token: 0x0600109C RID: 4252 RVA: 0x00055AF9 File Offset: 0x00053EF9
	public static T SafeGet<T>(this T[] array, int index) where T : class
	{
		if (index < 0 || index >= array.Length)
		{
			return (T)((object)null);
		}
		return array[index];
	}

	// Token: 0x0600109D RID: 4253 RVA: 0x00055B19 File Offset: 0x00053F19
	public static void SafeSetText(this Text text, string str)
	{
		if (text == null)
		{
			return;
		}
		text.text = str;
	}

	// Token: 0x0600109E RID: 4254 RVA: 0x00055B2F File Offset: 0x00053F2F
	public static void SafeSetColor(this Text text, Color color)
	{
		if (text == null)
		{
			return;
		}
		text.color = color;
	}

	// Token: 0x0600109F RID: 4255 RVA: 0x00055B45 File Offset: 0x00053F45
	public static void SafeSetValueChangeListener(this Slider slider, UnityAction<float> callBack)
	{
		if (slider == null)
		{
			return;
		}
		slider.onValueChanged.RemoveAllListeners();
		slider.onValueChanged.AddListener(callBack);
	}

	// Token: 0x060010A0 RID: 4256 RVA: 0x00055B6B File Offset: 0x00053F6B
	public static void SafeSetValue(this Slider slider, float value)
	{
		if (slider == null)
		{
			return;
		}
		slider.value = value;
	}

	// Token: 0x060010A1 RID: 4257 RVA: 0x00055B81 File Offset: 0x00053F81
	public static void SafeSetEnable(this ComButtonEnbale comButtonEnbale, bool bEnable)
	{
		if (comButtonEnbale == null)
		{
			return;
		}
		comButtonEnbale.SetEnable(bEnable);
	}

	// Token: 0x060010A2 RID: 4258 RVA: 0x00055B97 File Offset: 0x00053F97
	public static void SafeSetImage(this Image img, string path, bool setNativeSize = false)
	{
		if (img == null || path == null || path == string.Empty)
		{
			return;
		}
		ETCImageLoader.LoadSprite(ref img, path, true);
		if (setNativeSize)
		{
			img.SetNativeSize();
		}
	}

	// Token: 0x060010A3 RID: 4259 RVA: 0x00055BD2 File Offset: 0x00053FD2
	public static void SafeAddOnClickListener(this Button button, UnityAction callBack)
	{
		if (button == null || callBack == null)
		{
			return;
		}
		button.onClick.RemoveListener(callBack);
		button.onClick.AddListener(callBack);
	}

	// Token: 0x060010A4 RID: 4260 RVA: 0x00055C00 File Offset: 0x00054000
	public static void SafeSetOnClickListener(this Button button, UnityAction callBack)
	{
		if (button == null || callBack == null)
		{
			return;
		}
		ButtonCD component = button.GetComponent<ButtonCD>();
		if (component != null)
		{
			component.SetCallBack(callBack);
			return;
		}
		button.onClick.RemoveAllListeners();
		button.onClick.AddListener(callBack);
	}

	// Token: 0x060010A5 RID: 4261 RVA: 0x00055C54 File Offset: 0x00054054
	public static void SafeSetGray(this Slider slider, bool bGray)
	{
		if (slider == null)
		{
			return;
		}
		UIGray uigray = slider.gameObject.SafeAddComponent(false);
		if (uigray == null)
		{
			return;
		}
		uigray.enabled = false;
		uigray.enabled = bGray;
		slider.interactable = !bGray;
	}

	// Token: 0x060010A6 RID: 4262 RVA: 0x00055CA0 File Offset: 0x000540A0
	public static void SafeSetGray(this Button button, bool bGray, bool bCanNotClick = true)
	{
		if (button == null)
		{
			return;
		}
		UIGray uigray = button.gameObject.SafeAddComponent(false);
		if (uigray == null)
		{
			return;
		}
		uigray.enabled = false;
		uigray.enabled = bGray;
		if (bGray && bCanNotClick)
		{
			button.interactable = false;
			button.image.raycastTarget = false;
		}
		else
		{
			button.interactable = true;
			button.image.raycastTarget = true;
		}
	}

	// Token: 0x060010A7 RID: 4263 RVA: 0x00055D1C File Offset: 0x0005411C
	public static void SafeSetGray(this Toggle toggle, bool bGray, bool bCanNotClick = true)
	{
		if (toggle == null)
		{
			return;
		}
		UIGray uigray = toggle.gameObject.SafeAddComponent(false);
		if (uigray == null)
		{
			return;
		}
		uigray.enabled = false;
		uigray.enabled = bGray;
		if (bGray && bCanNotClick)
		{
			toggle.interactable = false;
			toggle.image.raycastTarget = false;
		}
		else
		{
			toggle.interactable = true;
			toggle.image.raycastTarget = true;
		}
	}

	// Token: 0x060010A8 RID: 4264 RVA: 0x00055D95 File Offset: 0x00054195
	public static void SafeRemoveOnClickListener(this Button button, UnityAction callBack)
	{
		if (button == null || callBack == null)
		{
			return;
		}
		button.onClick.RemoveListener(callBack);
	}

	// Token: 0x060010A9 RID: 4265 RVA: 0x00055DB6 File Offset: 0x000541B6
	public static void SafeRemoveAllListener(this Button button)
	{
		if (button == null)
		{
			return;
		}
		button.onClick.RemoveAllListeners();
	}

	// Token: 0x060010AA RID: 4266 RVA: 0x00055DD0 File Offset: 0x000541D0
	public static void SafeAddOnValueChangedListener(this Toggle toggle, UnityAction<bool> callBack)
	{
		if (toggle == null || callBack == null)
		{
			return;
		}
		toggle.onValueChanged.RemoveListener(callBack);
		toggle.onValueChanged.AddListener(callBack);
	}

	// Token: 0x060010AB RID: 4267 RVA: 0x00055E00 File Offset: 0x00054200
	public static void SafeSetOnValueChangedListener(this Toggle toggle, UnityAction<bool> callBack)
	{
		if (toggle == null || callBack == null)
		{
			return;
		}
		ToggleCD component = toggle.GetComponent<ToggleCD>();
		if (component != null)
		{
			component.SetCallBack(callBack);
			return;
		}
		toggle.onValueChanged.RemoveAllListeners();
		toggle.onValueChanged.AddListener(callBack);
	}

	// Token: 0x060010AC RID: 4268 RVA: 0x00055E52 File Offset: 0x00054252
	public static void SafeRemoveOnValueChangedListener(this Toggle toggle, UnityAction<bool> callBack)
	{
		if (toggle == null || callBack == null)
		{
			return;
		}
		toggle.onValueChanged.RemoveListener(callBack);
	}

	// Token: 0x060010AD RID: 4269 RVA: 0x00055E73 File Offset: 0x00054273
	public static void SafeSetToggleOnState(this Toggle toggle, bool isOn)
	{
		if (toggle == null)
		{
			return;
		}
		toggle.isOn = isOn;
	}
}
