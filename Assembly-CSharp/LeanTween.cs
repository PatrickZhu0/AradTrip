using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001A1 RID: 417
public class LeanTween : MonoSingleton<LeanTween>
{
	// Token: 0x06000D11 RID: 3345 RVA: 0x00041374 File Offset: 0x0003F774
	static LeanTween()
	{
		Keyframe[] array = new Keyframe[]
		{
			new Keyframe(0f, 0f),
			new Keyframe(0.112586f, 0.9976035f),
			new Keyframe(0.3120486f, -0.1720615f),
			new Keyframe(0.4316337f, 0.07030682f),
			new Keyframe(0.5524869f, -0.03141804f),
			new Keyframe(0.6549395f, 0.003909959f),
			new Keyframe(0.770987f, -0.009817753f),
			new Keyframe(0.8838775f, 0.001939224f),
			new Keyframe(1f, 0f)
		};
		LeanTween.punch = new AnimationCurve(array);
		Keyframe[] array2 = new Keyframe[]
		{
			new Keyframe(0f, 0f),
			new Keyframe(0.25f, 1f),
			new Keyframe(0.75f, -1f),
			new Keyframe(1f, 0f)
		};
		LeanTween.shake = new AnimationCurve(array2);
		LeanTween.startSearch = 0;
		LeanTween.eventsMaxSearch = 0;
		LeanTween.EVENTS_MAX = 10;
		LeanTween.LISTENERS_MAX = 10;
		LeanTween.INIT_LISTENERS_MAX = LeanTween.LISTENERS_MAX;
	}

	// Token: 0x06000D13 RID: 3347 RVA: 0x0004158C File Offset: 0x0003F98C
	public static Vector3[] add(Vector3[] a, Vector3 b)
	{
		Vector3[] array = new Vector3[a.Length];
		LeanTween.i = 0;
		while (LeanTween.i < a.Length)
		{
			array[LeanTween.i] = a[LeanTween.i] + b;
			LeanTween.i++;
		}
		return array;
	}

	// Token: 0x06000D14 RID: 3348 RVA: 0x000415ED File Offset: 0x0003F9ED
	public static void addListener(int eventId, Action<LTEvent> callback)
	{
		LeanTween.addListener(LeanTween.tweenEmpty, eventId, callback);
	}

	// Token: 0x06000D15 RID: 3349 RVA: 0x000415FC File Offset: 0x0003F9FC
	public static void addListener(GameObject caller, int eventId, Action<LTEvent> callback)
	{
		if (LeanTween.eventListeners == null)
		{
			LeanTween.INIT_LISTENERS_MAX = LeanTween.LISTENERS_MAX;
			LeanTween.eventListeners = new Action<LTEvent>[LeanTween.EVENTS_MAX * LeanTween.LISTENERS_MAX];
			LeanTween.goListeners = new GameObject[LeanTween.EVENTS_MAX * LeanTween.LISTENERS_MAX];
		}
		LeanTween.i = 0;
		while (LeanTween.i < LeanTween.INIT_LISTENERS_MAX)
		{
			int num = eventId * LeanTween.INIT_LISTENERS_MAX + LeanTween.i;
			if (LeanTween.goListeners[num] == null || LeanTween.eventListeners[num] == null)
			{
				LeanTween.eventListeners[num] = callback;
				LeanTween.goListeners[num] = caller;
				if (LeanTween.i >= LeanTween.eventsMaxSearch)
				{
					LeanTween.eventsMaxSearch = LeanTween.i + 1;
				}
				return;
			}
			if (LeanTween.goListeners[num] == caller && object.Equals(LeanTween.eventListeners[num], callback))
			{
				return;
			}
			LeanTween.i++;
		}
		Debug.LogError("You ran out of areas to add listeners, consider increasing INIT_LISTENERS_MAX, ex: LeanTween.INIT_LISTENERS_MAX = " + LeanTween.INIT_LISTENERS_MAX * 2);
	}

	// Token: 0x06000D16 RID: 3350 RVA: 0x00041705 File Offset: 0x0003FB05
	public static LTDescr alpha(LTRect ltRect, float to, float time)
	{
		ltRect.alphaEnabled = true;
		return LeanTween.pushNewTween(LeanTween.tweenEmpty, new Vector3(to, 0f, 0f), time, TweenAction.GUI_ALPHA, LeanTween.options().setRect(ltRect));
	}

	// Token: 0x06000D17 RID: 3351 RVA: 0x00041736 File Offset: 0x0003FB36
	public static LTDescr alpha(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.ALPHA, LeanTween.options());
	}

	// Token: 0x06000D18 RID: 3352 RVA: 0x00041756 File Offset: 0x0003FB56
	public static LTDescr alpha(RectTransform rectTrans, float to, float time)
	{
		return LeanTween.pushNewTween(rectTrans.gameObject, new Vector3(to, 0f, 0f), time, TweenAction.CANVAS_ALPHA, LeanTween.options().setRect(rectTrans));
	}

	// Token: 0x06000D19 RID: 3353 RVA: 0x00041781 File Offset: 0x0003FB81
	public static LTDescr alphaVertex(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.ALPHA_VERTEX, LeanTween.options());
	}

	// Token: 0x06000D1A RID: 3354 RVA: 0x000417A4 File Offset: 0x0003FBA4
	private static void cancel(int uniqueId)
	{
		if (uniqueId >= 0)
		{
			LeanTween.init();
			int num = uniqueId & 65535;
			int num2 = uniqueId >> 16;
			if (LeanTween.tweens[num].hasInitiliazed && (ulong)LeanTween.tweens[num].counter == (ulong)((long)num2))
			{
				LeanTween.removeTween(num);
			}
		}
	}

	// Token: 0x06000D1B RID: 3355 RVA: 0x000417F8 File Offset: 0x0003FBF8
	public static void cancel(GameObject gameObject)
	{
		LeanTween.init();
		Transform transform = gameObject.transform;
		for (int i = 0; i <= LeanTween.tweenMaxSearch; i++)
		{
			if (LeanTween.tweens[i].toggle && LeanTween.tweens[i].trans == transform)
			{
				LeanTween.removeTween(i);
			}
		}
	}

	// Token: 0x06000D1C RID: 3356 RVA: 0x00041858 File Offset: 0x0003FC58
	public static void cancel(LTRect ltRect, int uniqueId)
	{
		if (uniqueId >= 0)
		{
			LeanTween.init();
			int num = uniqueId & 65535;
			int num2 = uniqueId >> 16;
			if (LeanTween.tweens[num].ltRect == ltRect && (ulong)LeanTween.tweens[num].counter == (ulong)((long)num2))
			{
				LeanTween.removeTween(num);
			}
		}
	}

	// Token: 0x06000D1D RID: 3357 RVA: 0x000418AC File Offset: 0x0003FCAC
	public static void cancel(GameObject gameObject, int uniqueId)
	{
		if (uniqueId >= 0)
		{
			LeanTween.init();
			int num = uniqueId & 65535;
			int num2 = uniqueId >> 16;
			if (LeanTween.tweens[num].trans == null || (LeanTween.tweens[num].trans.gameObject == gameObject && (ulong)LeanTween.tweens[num].counter == (ulong)((long)num2)))
			{
				LeanTween.removeTween(num);
			}
		}
	}

	// Token: 0x06000D1E RID: 3358 RVA: 0x00041920 File Offset: 0x0003FD20
	public static void cancelAll(bool callComplete)
	{
		LeanTween.init();
		for (int i = 0; i <= LeanTween.tweenMaxSearch; i++)
		{
			if (LeanTween.tweens[i].trans != null)
			{
				if (callComplete && LeanTween.tweens[i].onComplete != null)
				{
					LeanTween.tweens[i].onComplete();
				}
				LeanTween.removeTween(i);
			}
		}
	}

	// Token: 0x06000D1F RID: 3359 RVA: 0x00041990 File Offset: 0x0003FD90
	private static float clerp(float start, float end, float val)
	{
		float num = 0f;
		float num2 = 360f;
		float num3 = Mathf.Abs((num2 - num) / 2f);
		if (end - start < -num3)
		{
			float num4 = (num2 - start + end) * val;
			return start + num4;
		}
		if (end - start > num3)
		{
			float num4 = -(num2 - end + start) * val;
			return start + num4;
		}
		return start + (end - start) * val;
	}

	// Token: 0x06000D20 RID: 3360 RVA: 0x000419F4 File Offset: 0x0003FDF4
	public static float closestRot(float from, float to)
	{
		float num = 0f - (360f - to);
		float num2 = 360f + to;
		float num3 = Mathf.Abs(to - from);
		float num4 = Mathf.Abs(num - from);
		float num5 = Mathf.Abs(num2 - from);
		if (num3 < num4 && num3 < num5)
		{
			return to;
		}
		if (num4 < num5)
		{
			return num;
		}
		return num2;
	}

	// Token: 0x06000D21 RID: 3361 RVA: 0x00041A54 File Offset: 0x0003FE54
	public static LTDescr color(GameObject gameObject, Color to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(1f, to.a, 0f), time, TweenAction.COLOR, LeanTween.options().setPoint(new Vector3(to.r, to.g, to.b)));
	}

	// Token: 0x06000D22 RID: 3362 RVA: 0x00041AA4 File Offset: 0x0003FEA4
	public static LTDescr color(RectTransform rectTrans, Color to, float time)
	{
		return LeanTween.pushNewTween(rectTrans.gameObject, new Vector3(1f, to.a, 0f), time, TweenAction.CANVAS_COLOR, LeanTween.options().setRect(rectTrans).setPoint(new Vector3(to.r, to.g, to.b)));
	}

	// Token: 0x06000D23 RID: 3363 RVA: 0x00041AFF File Offset: 0x0003FEFF
	public static LTDescr delayedCall(float delayTime, Action<object> callback)
	{
		return LeanTween.pushNewTween(LeanTween.tweenEmpty, Vector3.zero, delayTime, TweenAction.CALLBACK, LeanTween.options().setOnComplete(callback));
	}

	// Token: 0x06000D24 RID: 3364 RVA: 0x00041B1E File Offset: 0x0003FF1E
	public static LTDescr delayedCall(float delayTime, Action callback)
	{
		return LeanTween.pushNewTween(LeanTween.tweenEmpty, Vector3.zero, delayTime, TweenAction.CALLBACK, LeanTween.options().setOnComplete(callback));
	}

	// Token: 0x06000D25 RID: 3365 RVA: 0x00041B3D File Offset: 0x0003FF3D
	public static LTDescr delayedCall(GameObject gameObject, float delayTime, Action<object> callback)
	{
		return LeanTween.pushNewTween(gameObject, Vector3.zero, delayTime, TweenAction.CALLBACK, LeanTween.options().setOnComplete(callback));
	}

	// Token: 0x06000D26 RID: 3366 RVA: 0x00041B58 File Offset: 0x0003FF58
	public static LTDescr delayedCall(GameObject gameObject, float delayTime, Action callback)
	{
		return LeanTween.pushNewTween(gameObject, Vector3.zero, delayTime, TweenAction.CALLBACK, LeanTween.options().setOnComplete(callback));
	}

	// Token: 0x06000D27 RID: 3367 RVA: 0x00041B73 File Offset: 0x0003FF73
	public static LTDescr delayedSound(AudioClip audio, Vector3 pos, float volume)
	{
		return LeanTween.pushNewTween(LeanTween.tweenEmpty, pos, 0f, TweenAction.DELAYED_SOUND, LeanTween.options().setTo(pos).setFrom(new Vector3(volume, 0f, 0f)).setAudio(audio));
	}

	// Token: 0x06000D28 RID: 3368 RVA: 0x00041BAD File Offset: 0x0003FFAD
	public static LTDescr delayedSound(GameObject gameObject, AudioClip audio, Vector3 pos, float volume)
	{
		return LeanTween.pushNewTween(gameObject, pos, 0f, TweenAction.DELAYED_SOUND, LeanTween.options().setTo(pos).setFrom(new Vector3(volume, 0f, 0f)).setAudio(audio));
	}

	// Token: 0x06000D29 RID: 3369 RVA: 0x00041BE4 File Offset: 0x0003FFE4
	public static LTDescr description(int uniqueId)
	{
		int num = uniqueId & 65535;
		int num2 = uniqueId >> 16;
		if (LeanTween.tweens[num] != null && LeanTween.tweens[num].uniqueId == uniqueId && (ulong)LeanTween.tweens[num].counter == (ulong)((long)num2))
		{
			return LeanTween.tweens[num];
		}
		for (int i = 0; i <= LeanTween.tweenMaxSearch; i++)
		{
			if (LeanTween.tweens[i].uniqueId == uniqueId && (ulong)LeanTween.tweens[i].counter == (ulong)((long)num2))
			{
				return LeanTween.tweens[i];
			}
		}
		return null;
	}

	// Token: 0x06000D2A RID: 3370 RVA: 0x00041C7D File Offset: 0x0004007D
	public static LTDescr destroyAfter(LTRect rect, float delayTime)
	{
		return LeanTween.pushNewTween(LeanTween.tweenEmpty, Vector3.zero, delayTime, TweenAction.CALLBACK, LeanTween.options().setRect(rect).setDestroyOnComplete(true));
	}

	// Token: 0x06000D2B RID: 3371 RVA: 0x00041CA2 File Offset: 0x000400A2
	public static void dispatchEvent(int eventId)
	{
		LeanTween.dispatchEvent(eventId, null);
	}

	// Token: 0x06000D2C RID: 3372 RVA: 0x00041CAC File Offset: 0x000400AC
	public static void dispatchEvent(int eventId, object data)
	{
		for (int i = 0; i < LeanTween.eventsMaxSearch; i++)
		{
			int num = eventId * LeanTween.INIT_LISTENERS_MAX + i;
			if (LeanTween.eventListeners[num] != null)
			{
				if (LeanTween.goListeners[num] != null)
				{
					LeanTween.eventListeners[num](new LTEvent(eventId, data));
				}
				else
				{
					LeanTween.eventListeners[num] = null;
				}
			}
		}
	}

	// Token: 0x06000D2D RID: 3373 RVA: 0x00041D18 File Offset: 0x00040118
	public static void drawBezierPath(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
	{
		Vector3 vector = a;
		Vector3 vector2 = -a + 3f * (b - c) + d;
		Vector3 vector3 = 3f * (a + c) - 6f * b;
		Vector3 vector4 = 3f * (b - a);
		for (float num = 1f; num <= 30f; num += 1f)
		{
			float num2 = num / 30f;
			Vector3 vector5 = ((vector2 * num2 + vector3) * num2 + vector4) * num2 + a;
			Gizmos.DrawLine(vector, vector5);
			vector = vector5;
		}
	}

	// Token: 0x06000D2E RID: 3374 RVA: 0x00041DE0 File Offset: 0x000401E0
	private static float easeInBack(float start, float end, float val)
	{
		end -= start;
		val /= 1f;
		float num = 1.70158f;
		return end * val * val * ((num + 1f) * val - num) + start;
	}

	// Token: 0x06000D2F RID: 3375 RVA: 0x00041E14 File Offset: 0x00040214
	private static float easeInBounce(float start, float end, float val)
	{
		end -= start;
		float num = 1f;
		return end - LeanTween.easeOutBounce(0f, end, num - val) + start;
	}

	// Token: 0x06000D30 RID: 3376 RVA: 0x00041E3E File Offset: 0x0004023E
	private static float easeInCirc(float start, float end, float val)
	{
		end -= start;
		return -end * (Mathf.Sqrt(1f - val * val) - 1f) + start;
	}

	// Token: 0x06000D31 RID: 3377 RVA: 0x00041E5E File Offset: 0x0004025E
	private static float easeInCubic(float start, float end, float val)
	{
		end -= start;
		return end * val * val * val + start;
	}

	// Token: 0x06000D32 RID: 3378 RVA: 0x00041E70 File Offset: 0x00040270
	private static float easeInElastic(float start, float end, float val)
	{
		end -= start;
		float num = 1f;
		float num2 = num * 0.3f;
		float num3 = 0f;
		if (val == 0f)
		{
			return start;
		}
		val /= num;
		if (val == 1f)
		{
			return start + end;
		}
		float num4;
		if (num3 == 0f || num3 < Mathf.Abs(end))
		{
			num3 = end;
			num4 = num2 / 4f;
		}
		else
		{
			num4 = num2 / 6.283185f * Mathf.Asin(end / num3);
		}
		val -= 1f;
		return -(num3 * Mathf.Pow(2f, 10f * val) * Mathf.Sin((val * num - num4) * 6.283185f / num2)) + start;
	}

	// Token: 0x06000D33 RID: 3379 RVA: 0x00041F26 File Offset: 0x00040326
	private static float easeInExpo(float start, float end, float val)
	{
		end -= start;
		return end * Mathf.Pow(2f, 10f * (val / 1f - 1f)) + start;
	}

	// Token: 0x06000D34 RID: 3380 RVA: 0x00041F50 File Offset: 0x00040350
	private static float easeInOutBack(float start, float end, float val)
	{
		float num = 1.70158f;
		end -= start;
		val /= 0.5f;
		if (val < 1f)
		{
			num *= 1.525f;
			return end / 2f * (val * val * ((num + 1f) * val - num)) + start;
		}
		val -= 2f;
		num *= 1.525f;
		return end / 2f * (val * val * ((num + 1f) * val + num) + 2f) + start;
	}

	// Token: 0x06000D35 RID: 3381 RVA: 0x00041FD0 File Offset: 0x000403D0
	private static float easeInOutBounce(float start, float end, float val)
	{
		end -= start;
		float num = 1f;
		if (val < num / 2f)
		{
			return LeanTween.easeInBounce(0f, end, val * 2f) * 0.5f + start;
		}
		return LeanTween.easeOutBounce(0f, end, val * 2f - num) * 0.5f + end * 0.5f + start;
	}

	// Token: 0x06000D36 RID: 3382 RVA: 0x00042034 File Offset: 0x00040434
	private static float easeInOutCirc(float start, float end, float val)
	{
		val /= 0.5f;
		end -= start;
		if (val < 1f)
		{
			return -end / 2f * (Mathf.Sqrt(1f - val * val) - 1f) + start;
		}
		val -= 2f;
		return end / 2f * (Mathf.Sqrt(1f - val * val) + 1f) + start;
	}

	// Token: 0x06000D37 RID: 3383 RVA: 0x000420A4 File Offset: 0x000404A4
	private static float easeInOutCubic(float start, float end, float val)
	{
		val /= 0.5f;
		end -= start;
		if (val < 1f)
		{
			return end / 2f * val * val * val + start;
		}
		val -= 2f;
		return end / 2f * (val * val * val + 2f) + start;
	}

	// Token: 0x06000D38 RID: 3384 RVA: 0x000420F8 File Offset: 0x000404F8
	private static float easeInOutElastic(float start, float end, float val)
	{
		end -= start;
		float num = 1f;
		float num2 = num * 0.3f;
		float num3 = 0f;
		if (val == 0f)
		{
			return start;
		}
		val /= num / 2f;
		if (val == 2f)
		{
			return start + end;
		}
		float num4;
		if (num3 == 0f || num3 < Mathf.Abs(end))
		{
			num3 = end;
			num4 = num2 / 4f;
		}
		else
		{
			num4 = num2 / 6.283185f * Mathf.Asin(end / num3);
		}
		if (val < 1f)
		{
			val -= 1f;
			return -0.5f * (num3 * Mathf.Pow(2f, 10f * val) * Mathf.Sin((val * num - num4) * 6.283185f / num2)) + start;
		}
		val -= 1f;
		return num3 * Mathf.Pow(2f, -10f * val) * Mathf.Sin((val * num - num4) * 6.283185f / num2) * 0.5f + end + start;
	}

	// Token: 0x06000D39 RID: 3385 RVA: 0x00042200 File Offset: 0x00040600
	private static float easeInOutExpo(float start, float end, float val)
	{
		val /= 0.5f;
		end -= start;
		if (val < 1f)
		{
			return end / 2f * Mathf.Pow(2f, 10f * (val - 1f)) + start;
		}
		val -= 1f;
		return end / 2f * (-Mathf.Pow(2f, -10f * val) + 2f) + start;
	}

	// Token: 0x06000D3A RID: 3386 RVA: 0x00042274 File Offset: 0x00040674
	private static float easeInOutQuad(float start, float end, float val)
	{
		val /= 0.5f;
		end -= start;
		if (val < 1f)
		{
			return end / 2f * val * val + start;
		}
		val -= 1f;
		return -end / 2f * (val * (val - 2f) - 1f) + start;
	}

	// Token: 0x06000D3B RID: 3387 RVA: 0x000422CC File Offset: 0x000406CC
	private static float easeInOutQuadOpt(float start, float diff, float ratioPassed)
	{
		ratioPassed /= 0.5f;
		if (ratioPassed < 1f)
		{
			return diff / 2f * ratioPassed * ratioPassed + start;
		}
		ratioPassed -= 1f;
		return -diff / 2f * (ratioPassed * (ratioPassed - 2f) - 1f) + start;
	}

	// Token: 0x06000D3C RID: 3388 RVA: 0x00042320 File Offset: 0x00040720
	private static float easeInOutQuart(float start, float end, float val)
	{
		val /= 0.5f;
		end -= start;
		if (val < 1f)
		{
			return end / 2f * val * val * val * val + start;
		}
		val -= 2f;
		return -end / 2f * (val * val * val * val - 2f) + start;
	}

	// Token: 0x06000D3D RID: 3389 RVA: 0x0004237C File Offset: 0x0004077C
	private static float easeInOutQuint(float start, float end, float val)
	{
		val /= 0.5f;
		end -= start;
		if (val < 1f)
		{
			return end / 2f * val * val * val * val * val + start;
		}
		val -= 2f;
		return end / 2f * (val * val * val * val * val + 2f) + start;
	}

	// Token: 0x06000D3E RID: 3390 RVA: 0x000423D8 File Offset: 0x000407D8
	private static float easeInOutSine(float start, float end, float val)
	{
		end -= start;
		return -end / 2f * (Mathf.Cos(3.141593f * val / 1f) - 1f) + start;
	}

	// Token: 0x06000D3F RID: 3391 RVA: 0x00042402 File Offset: 0x00040802
	private static float easeInQuad(float start, float end, float val)
	{
		end -= start;
		return end * val * val + start;
	}

	// Token: 0x06000D40 RID: 3392 RVA: 0x00042410 File Offset: 0x00040810
	private static float easeInQuadOpt(float start, float diff, float ratioPassed)
	{
		return diff * ratioPassed * ratioPassed + start;
	}

	// Token: 0x06000D41 RID: 3393 RVA: 0x00042419 File Offset: 0x00040819
	private static float easeInQuart(float start, float end, float val)
	{
		end -= start;
		return end * val * val * val * val + start;
	}

	// Token: 0x06000D42 RID: 3394 RVA: 0x0004242B File Offset: 0x0004082B
	private static float easeInQuint(float start, float end, float val)
	{
		end -= start;
		return end * val * val * val * val * val + start;
	}

	// Token: 0x06000D43 RID: 3395 RVA: 0x0004243F File Offset: 0x0004083F
	private static float easeInSine(float start, float end, float val)
	{
		end -= start;
		return -end * Mathf.Cos(val / 1f * 1.570796f) + end + start;
	}

	// Token: 0x06000D44 RID: 3396 RVA: 0x00042460 File Offset: 0x00040860
	private static float easeOutBack(float start, float end, float val)
	{
		float num = 1.70158f;
		end -= start;
		val = val / 1f - 1f;
		return end * (val * val * ((num + 1f) * val + num) + 1f) + start;
	}

	// Token: 0x06000D45 RID: 3397 RVA: 0x000424A0 File Offset: 0x000408A0
	private static float easeOutBounce(float start, float end, float val)
	{
		val /= 1f;
		end -= start;
		if (val < 0.3636364f)
		{
			return end * (7.5625f * val * val) + start;
		}
		if (val < 0.7272727f)
		{
			val -= 0.5454546f;
			return end * (7.5625f * val * val + 0.75f) + start;
		}
		if ((double)val < 0.9090909090909091)
		{
			val -= 0.8181818f;
			return end * (7.5625f * val * val + 0.9375f) + start;
		}
		val -= 0.9545454f;
		return end * (7.5625f * val * val + 0.984375f) + start;
	}

	// Token: 0x06000D46 RID: 3398 RVA: 0x00042545 File Offset: 0x00040945
	private static float easeOutCirc(float start, float end, float val)
	{
		val -= 1f;
		end -= start;
		return end * Mathf.Sqrt(1f - val * val) + start;
	}

	// Token: 0x06000D47 RID: 3399 RVA: 0x00042567 File Offset: 0x00040967
	private static float easeOutCubic(float start, float end, float val)
	{
		val -= 1f;
		end -= start;
		return end * (val * val * val + 1f) + start;
	}

	// Token: 0x06000D48 RID: 3400 RVA: 0x00042588 File Offset: 0x00040988
	private static float easeOutElastic(float start, float end, float val)
	{
		end -= start;
		float num = 1f;
		float num2 = num * 0.3f;
		float num3 = 0f;
		if (val == 0f)
		{
			return start;
		}
		val /= num;
		if (val == 1f)
		{
			return start + end;
		}
		float num4;
		if (num3 == 0f || num3 < Mathf.Abs(end))
		{
			num3 = end;
			num4 = num2 / 4f;
		}
		else
		{
			num4 = num2 / 6.283185f * Mathf.Asin(end / num3);
		}
		return num3 * Mathf.Pow(2f, -10f * val) * Mathf.Sin((val * num - num4) * 6.283185f / num2) + end + start;
	}

	// Token: 0x06000D49 RID: 3401 RVA: 0x00042636 File Offset: 0x00040A36
	private static float easeOutExpo(float start, float end, float val)
	{
		end -= start;
		return end * (-Mathf.Pow(2f, -10f * val / 1f) + 1f) + start;
	}

	// Token: 0x06000D4A RID: 3402 RVA: 0x0004265F File Offset: 0x00040A5F
	private static float easeOutQuad(float start, float end, float val)
	{
		end -= start;
		return -end * val * (val - 2f) + start;
	}

	// Token: 0x06000D4B RID: 3403 RVA: 0x00042674 File Offset: 0x00040A74
	private static float easeOutQuadOpt(float start, float diff, float ratioPassed)
	{
		return -diff * ratioPassed * (ratioPassed - 2f) + start;
	}

	// Token: 0x06000D4C RID: 3404 RVA: 0x00042684 File Offset: 0x00040A84
	private static float easeOutQuart(float start, float end, float val)
	{
		val -= 1f;
		end -= start;
		return -end * (val * val * val * val - 1f) + start;
	}

	// Token: 0x06000D4D RID: 3405 RVA: 0x000426A6 File Offset: 0x00040AA6
	private static float easeOutQuint(float start, float end, float val)
	{
		val -= 1f;
		end -= start;
		return end * (val * val * val * val * val + 1f) + start;
	}

	// Token: 0x06000D4E RID: 3406 RVA: 0x000426C9 File Offset: 0x00040AC9
	private static float easeOutSine(float start, float end, float val)
	{
		end -= start;
		return end * Mathf.Sin(val / 1f * 1.570796f) + start;
	}

	// Token: 0x06000D4F RID: 3407 RVA: 0x000426E6 File Offset: 0x00040AE6
	public static void init()
	{
		LeanTween.init(LeanTween.maxTweens);
	}

	// Token: 0x06000D50 RID: 3408 RVA: 0x000426F4 File Offset: 0x00040AF4
	public static void init(int maxSimultaneousTweens)
	{
		if (LeanTween.tweens == null)
		{
			LeanTween.maxTweens = maxSimultaneousTweens;
			LeanTween.tweens = new LTDescr[LeanTween.maxTweens];
			LeanTween.tweensFinished = new int[LeanTween.maxTweens];
			LeanTween._tweenEmpty = new GameObject();
			LeanTween._tweenEmpty.name = "~LeanTween";
			LeanTween._tweenEmpty.AddComponent(typeof(LeanTween));
			LeanTween._tweenEmpty.isStatic = true;
			LeanTween._tweenEmpty.hideFlags = 61;
			Object.DontDestroyOnLoad(LeanTween._tweenEmpty);
			for (int i = 0; i < LeanTween.maxTweens; i++)
			{
				LeanTween.tweens[i] = new LTDescr();
			}
		}
	}

	// Token: 0x06000D51 RID: 3409 RVA: 0x000427A0 File Offset: 0x00040BA0
	public static bool IsInitialised()
	{
		return LeanTween.tweens != null;
	}

	// Token: 0x06000D52 RID: 3410 RVA: 0x000427B0 File Offset: 0x00040BB0
	public static bool isTweening(LTRect ltRect)
	{
		for (int i = 0; i <= LeanTween.tweenMaxSearch; i++)
		{
			if (LeanTween.tweens[i].toggle && LeanTween.tweens[i].ltRect == ltRect)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000D53 RID: 3411 RVA: 0x000427FC File Offset: 0x00040BFC
	public static bool isTweening(int uniqueId)
	{
		int num = uniqueId & 65535;
		int num2 = uniqueId >> 16;
		return num >= 0 && num < LeanTween.maxTweens && (ulong)LeanTween.tweens[num].counter == (ulong)((long)num2) && LeanTween.tweens[num].toggle;
	}

	// Token: 0x06000D54 RID: 3412 RVA: 0x00042850 File Offset: 0x00040C50
	public static bool isTweening(GameObject gameObject = null)
	{
		if (gameObject == null)
		{
			for (int i = 0; i <= LeanTween.tweenMaxSearch; i++)
			{
				if (LeanTween.tweens[i].toggle)
				{
					return true;
				}
			}
			return false;
		}
		Transform transform = gameObject.transform;
		for (int j = 0; j <= LeanTween.tweenMaxSearch; j++)
		{
			if (LeanTween.tweens[j].toggle && LeanTween.tweens[j].trans == transform)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000D55 RID: 3413 RVA: 0x000428DC File Offset: 0x00040CDC
	private static float linear(float start, float end, float val)
	{
		return Mathf.Lerp(start, end, val);
	}

	// Token: 0x06000D56 RID: 3414 RVA: 0x000428E6 File Offset: 0x00040CE6
	public static object logError(string error)
	{
		if (LeanTween.throwErrors)
		{
			Debug.LogError(error);
		}
		else
		{
			Debug.Log(error);
		}
		return null;
	}

	// Token: 0x06000D57 RID: 3415 RVA: 0x00042904 File Offset: 0x00040D04
	public static LTDescr move(LTRect ltRect, Vector2 to, float time)
	{
		return LeanTween.pushNewTween(LeanTween.tweenEmpty, to, time, TweenAction.GUI_MOVE, LeanTween.options().setRect(ltRect));
	}

	// Token: 0x06000D58 RID: 3416 RVA: 0x00042924 File Offset: 0x00040D24
	public static LTDescr move(GameObject gameObject, Vector2 to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to.x, to.y, gameObject.transform.position.z), time, TweenAction.MOVE, LeanTween.options());
	}

	// Token: 0x06000D59 RID: 3417 RVA: 0x00042965 File Offset: 0x00040D65
	public static LTDescr move(GameObject gameObject, Vector3 to, float time)
	{
		return LeanTween.pushNewTween(gameObject, to, time, TweenAction.MOVE, LeanTween.options());
	}

	// Token: 0x06000D5A RID: 3418 RVA: 0x00042978 File Offset: 0x00040D78
	public static LTDescr move(GameObject gameObject, Vector3[] to, float time)
	{
		LeanTween.descr = LeanTween.options();
		if (LeanTween.descr.path == null)
		{
			LeanTween.descr.path = new LTBezierPath(to);
		}
		else
		{
			LeanTween.descr.path.setPoints(to);
		}
		return LeanTween.pushNewTween(gameObject, new Vector3(1f, 0f, 0f), time, TweenAction.MOVE_CURVED, LeanTween.descr);
	}

	// Token: 0x06000D5B RID: 3419 RVA: 0x000429E4 File Offset: 0x00040DE4
	public static LTDescr move(RectTransform rectTrans, Vector3 to, float time)
	{
		return LeanTween.pushNewTween(rectTrans.gameObject, to, time, TweenAction.CANVAS_MOVE, LeanTween.options().setRect(rectTrans));
	}

	// Token: 0x06000D5C RID: 3420 RVA: 0x00042A00 File Offset: 0x00040E00
	public static LTDescr moveLocal(GameObject gameObject, Vector3 to, float time)
	{
		return LeanTween.pushNewTween(gameObject, to, time, TweenAction.MOVE_LOCAL, LeanTween.options());
	}

	// Token: 0x06000D5D RID: 3421 RVA: 0x00042A14 File Offset: 0x00040E14
	public static LTDescr moveLocal(GameObject gameObject, Vector3[] to, float time)
	{
		LeanTween.descr = LeanTween.options();
		if (LeanTween.descr.path == null)
		{
			LeanTween.descr.path = new LTBezierPath(to);
		}
		else
		{
			LeanTween.descr.path.setPoints(to);
		}
		return LeanTween.pushNewTween(gameObject, new Vector3(1f, 0f, 0f), time, TweenAction.MOVE_CURVED_LOCAL, LeanTween.descr);
	}

	// Token: 0x06000D5E RID: 3422 RVA: 0x00042A80 File Offset: 0x00040E80
	public static LTDescr moveLocalX(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.MOVE_LOCAL_X, LeanTween.options());
	}

	// Token: 0x06000D5F RID: 3423 RVA: 0x00042A9F File Offset: 0x00040E9F
	public static LTDescr moveLocalY(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.MOVE_LOCAL_Y, LeanTween.options());
	}

	// Token: 0x06000D60 RID: 3424 RVA: 0x00042ABE File Offset: 0x00040EBE
	public static LTDescr moveLocalZ(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.MOVE_LOCAL_Z, LeanTween.options());
	}

	// Token: 0x06000D61 RID: 3425 RVA: 0x00042ADD File Offset: 0x00040EDD
	public static LTDescr moveMargin(LTRect ltRect, Vector2 to, float time)
	{
		return LeanTween.pushNewTween(LeanTween.tweenEmpty, to, time, TweenAction.GUI_MOVE_MARGIN, LeanTween.options().setRect(ltRect));
	}

	// Token: 0x06000D62 RID: 3426 RVA: 0x00042AFD File Offset: 0x00040EFD
	public static LTDescr moveSpline(GameObject gameObject, Vector3[] to, float time)
	{
		LeanTween.descr = LeanTween.options();
		LeanTween.descr.spline = new LTSpline(to);
		return LeanTween.pushNewTween(gameObject, new Vector3(1f, 0f, 0f), time, TweenAction.MOVE_SPLINE, LeanTween.descr);
	}

	// Token: 0x06000D63 RID: 3427 RVA: 0x00042B3A File Offset: 0x00040F3A
	public static LTDescr moveSplineLocal(GameObject gameObject, Vector3[] to, float time)
	{
		LeanTween.descr = LeanTween.options();
		LeanTween.descr.spline = new LTSpline(to);
		return LeanTween.pushNewTween(gameObject, new Vector3(1f, 0f, 0f), time, TweenAction.MOVE_SPLINE_LOCAL, LeanTween.descr);
	}

	// Token: 0x06000D64 RID: 3428 RVA: 0x00042B78 File Offset: 0x00040F78
	public static LTDescr moveX(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.MOVE_X, LeanTween.options());
	}

	// Token: 0x06000D65 RID: 3429 RVA: 0x00042B97 File Offset: 0x00040F97
	public static LTDescr moveY(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.MOVE_Y, LeanTween.options());
	}

	// Token: 0x06000D66 RID: 3430 RVA: 0x00042BB6 File Offset: 0x00040FB6
	public static LTDescr moveZ(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.MOVE_Z, LeanTween.options());
	}

	// Token: 0x06000D67 RID: 3431 RVA: 0x00042BD5 File Offset: 0x00040FD5
	public void OnLevelWasLoaded(int lvl)
	{
		LTGUI.reset();
	}

	// Token: 0x06000D68 RID: 3432 RVA: 0x00042BDC File Offset: 0x00040FDC
	public static LTDescr options()
	{
		LeanTween.init();
		LeanTween.j = 0;
		LeanTween.i = LeanTween.startSearch;
		while (LeanTween.j < LeanTween.maxTweens)
		{
			if (LeanTween.i >= LeanTween.maxTweens - 1)
			{
				LeanTween.i = 0;
			}
			if (!LeanTween.tweens[LeanTween.i].toggle)
			{
				if (LeanTween.i + 1 > LeanTween.tweenMaxSearch)
				{
					LeanTween.tweenMaxSearch = LeanTween.i + 1;
				}
				LeanTween.startSearch = LeanTween.i + 1;
				break;
			}
			LeanTween.j++;
			if (LeanTween.j >= LeanTween.maxTweens)
			{
				return LeanTween.logError("LeanTween - You have run out of available spaces for tweening. To avoid this error increase the number of spaces to available for tweening when you initialize the LeanTween class ex: LeanTween.init( " + LeanTween.maxTweens * 2 + " );") as LTDescr;
			}
			LeanTween.i++;
		}
		LeanTween.tweens[LeanTween.i].reset();
		LeanTween.tweens[LeanTween.i].setId((uint)LeanTween.i);
		return LeanTween.tweens[LeanTween.i];
	}

	// Token: 0x06000D69 RID: 3433 RVA: 0x00042CEA File Offset: 0x000410EA
	public static LTDescr options(LTDescr seed)
	{
		Debug.LogError("error this function is no longer used");
		return null;
	}

	// Token: 0x06000D6A RID: 3434 RVA: 0x00042CF8 File Offset: 0x000410F8
	public static void pause(int uniqueId)
	{
		int num = uniqueId & 65535;
		int num2 = uniqueId >> 16;
		if ((ulong)LeanTween.tweens[num].counter == (ulong)((long)num2))
		{
			LeanTween.tweens[num].pause();
		}
	}

	// Token: 0x06000D6B RID: 3435 RVA: 0x00042D34 File Offset: 0x00041134
	public static void pause(GameObject gameObject)
	{
		Transform transform = gameObject.transform;
		for (int i = 0; i <= LeanTween.tweenMaxSearch; i++)
		{
			if (LeanTween.tweens[i].trans == transform)
			{
				LeanTween.tweens[i].pause();
			}
		}
	}

	// Token: 0x06000D6C RID: 3436 RVA: 0x00042D82 File Offset: 0x00041182
	[Obsolete("Use 'pause( id )' instead")]
	public static void pause(GameObject gameObject, int uniqueId)
	{
		LeanTween.pause(uniqueId);
	}

	// Token: 0x06000D6D RID: 3437 RVA: 0x00042D8C File Offset: 0x0004118C
	public static void pauseAll()
	{
		LeanTween.init();
		for (int i = 0; i <= LeanTween.tweenMaxSearch; i++)
		{
			LeanTween.tweens[i].pause();
		}
	}

	// Token: 0x06000D6E RID: 3438 RVA: 0x00042DC4 File Offset: 0x000411C4
	public static LTDescr play(RectTransform rectTransform, Sprite[] sprites)
	{
		float num = 0.25f;
		float time = num * (float)sprites.Length;
		return LeanTween.pushNewTween(rectTransform.gameObject, new Vector3((float)sprites.Length - 1f, 0f, 0f), time, TweenAction.CANVAS_PLAYSPRITE, LeanTween.options().setSprites(sprites).setRepeat(-1));
	}

	// Token: 0x06000D6F RID: 3439 RVA: 0x00042E18 File Offset: 0x00041218
	public static LTDescr playFrameOpen(GameObject frameroot, GameObject blackMask = null, Action OnCompleteaction = null)
	{
		LTDescr ltdescr = LeanTween.value(frameroot, 0f, 1f, MonoSingleton<LeanTween>.instance.frameOpenTime);
		ltdescr.setOnComplete(OnCompleteaction);
		ltdescr.setOnUpdate(delegate(float scaleValue)
		{
			frameroot.transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
		});
		ltdescr.animationCurve = MonoSingleton<LeanTween>.instance.frameOpenTween;
		if (blackMask)
		{
			CanvasRenderer render = blackMask.GetComponent<CanvasRenderer>();
			if (render)
			{
				LTDescr ltdescr2 = LeanTween.value(blackMask, 0f, 1f, MonoSingleton<LeanTween>.instance.frameOpenTime);
				ltdescr2.setOnUpdate(delegate(float alphaValue)
				{
					render.SetAlpha(alphaValue);
				});
			}
		}
		return ltdescr;
	}

	// Token: 0x06000D70 RID: 3440 RVA: 0x00042EDC File Offset: 0x000412DC
	public static LTDescr playFrameClose(GameObject frameroot, GameObject blackMask = null, Action OnCompleteaction = null)
	{
		LTDescr ltdescr = LeanTween.value(frameroot, 0f, 1f, MonoSingleton<LeanTween>.instance.frameCloseTime);
		if (ltdescr != null)
		{
			ltdescr.setOnComplete(OnCompleteaction);
			ltdescr.setOnUpdate(delegate(float scaleValue)
			{
				frameroot.transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
			});
			ltdescr.animationCurve = MonoSingleton<LeanTween>.instance.frameCloseTween;
		}
		if (blackMask)
		{
			CanvasRenderer render = blackMask.GetComponent<CanvasRenderer>();
			if (render)
			{
				LTDescr ltdescr2 = LeanTween.value(blackMask, 1f, 0f, MonoSingleton<LeanTween>.instance.frameOpenTime);
				ltdescr2.setOnUpdate(delegate(float alphaValue)
				{
					render.SetAlpha(alphaValue);
				});
			}
		}
		return ltdescr;
	}

	// Token: 0x06000D71 RID: 3441 RVA: 0x00042FA4 File Offset: 0x000413A4
	private static LTDescr pushNewTween(GameObject gameObject, Vector3 to, float time, TweenAction tweenAction, LTDescr tween)
	{
		LeanTween.init(LeanTween.maxTweens);
		if (gameObject == null || tween == null)
		{
			return null;
		}
		tween.trans = gameObject.transform;
		tween.to = to;
		tween.time = time;
		tween.type = tweenAction;
		return tween;
	}

	// Token: 0x06000D72 RID: 3442 RVA: 0x00042FF7 File Offset: 0x000413F7
	public static bool removeListener(int eventId, Action<LTEvent> callback)
	{
		return LeanTween.removeListener(LeanTween.tweenEmpty, eventId, callback);
	}

	// Token: 0x06000D73 RID: 3443 RVA: 0x00043008 File Offset: 0x00041408
	public static bool removeListener(GameObject caller, int eventId, Action<LTEvent> callback)
	{
		LeanTween.i = 0;
		while (LeanTween.i < LeanTween.eventsMaxSearch)
		{
			int num = eventId * LeanTween.INIT_LISTENERS_MAX + LeanTween.i;
			if (LeanTween.goListeners[num] == caller && object.Equals(LeanTween.eventListeners[num], callback))
			{
				LeanTween.eventListeners[num] = null;
				LeanTween.goListeners[num] = null;
				return true;
			}
			LeanTween.i++;
		}
		return false;
	}

	// Token: 0x06000D74 RID: 3444 RVA: 0x00043080 File Offset: 0x00041480
	public static void removeTween(int i)
	{
		if (LeanTween.tweens[i].toggle)
		{
			LeanTween.tweens[i].toggle = false;
			if (LeanTween.tweens[i].destroyOnComplete)
			{
				if (LeanTween.tweens[i].ltRect != null)
				{
					LTGUI.destroy(LeanTween.tweens[i].ltRect.id);
				}
				else if (LeanTween.tweens[i].trans.gameObject != LeanTween._tweenEmpty)
				{
					Object.Destroy(LeanTween.tweens[i].trans.gameObject);
				}
			}
			LeanTween.startSearch = i;
			if (i + 1 >= LeanTween.tweenMaxSearch)
			{
				LeanTween.startSearch = 0;
			}
		}
	}

	// Token: 0x06000D75 RID: 3445 RVA: 0x00043137 File Offset: 0x00041537
	public static void reset()
	{
		LeanTween.tweens = null;
	}

	// Token: 0x06000D76 RID: 3446 RVA: 0x00043140 File Offset: 0x00041540
	public static void resume(int uniqueId)
	{
		int num = uniqueId & 65535;
		int num2 = uniqueId >> 16;
		if ((ulong)LeanTween.tweens[num].counter == (ulong)((long)num2))
		{
			LeanTween.tweens[num].resume();
		}
	}

	// Token: 0x06000D77 RID: 3447 RVA: 0x0004317C File Offset: 0x0004157C
	public static void resume(GameObject gameObject)
	{
		Transform transform = gameObject.transform;
		for (int i = 0; i <= LeanTween.tweenMaxSearch; i++)
		{
			if (LeanTween.tweens[i].trans == transform)
			{
				LeanTween.tweens[i].resume();
			}
		}
	}

	// Token: 0x06000D78 RID: 3448 RVA: 0x000431CA File Offset: 0x000415CA
	[Obsolete("Use 'resume( id )' instead")]
	public static void resume(GameObject gameObject, int uniqueId)
	{
		LeanTween.resume(uniqueId);
	}

	// Token: 0x06000D79 RID: 3449 RVA: 0x000431D4 File Offset: 0x000415D4
	public static void resumeAll()
	{
		LeanTween.init();
		for (int i = 0; i <= LeanTween.tweenMaxSearch; i++)
		{
			LeanTween.tweens[i].resume();
		}
	}

	// Token: 0x06000D7A RID: 3450 RVA: 0x00043209 File Offset: 0x00041609
	public static LTDescr rotate(LTRect ltRect, float to, float time)
	{
		return LeanTween.pushNewTween(LeanTween.tweenEmpty, new Vector3(to, 0f, 0f), time, TweenAction.GUI_ROTATE, LeanTween.options().setRect(ltRect));
	}

	// Token: 0x06000D7B RID: 3451 RVA: 0x00043233 File Offset: 0x00041633
	public static LTDescr rotate(GameObject gameObject, Vector3 to, float time)
	{
		return LeanTween.pushNewTween(gameObject, to, time, TweenAction.ROTATE, LeanTween.options());
	}

	// Token: 0x06000D7C RID: 3452 RVA: 0x00043244 File Offset: 0x00041644
	public static LTDescr rotate(RectTransform rectTrans, float to, float time)
	{
		return LeanTween.pushNewTween(rectTrans.gameObject, new Vector3(to, 0f, 0f), time, TweenAction.CANVAS_ROTATEAROUND, LeanTween.options().setRect(rectTrans).setAxis(Vector3.forward));
	}

	// Token: 0x06000D7D RID: 3453 RVA: 0x00043279 File Offset: 0x00041679
	public static LTDescr rotateAround(GameObject gameObject, Vector3 axis, float add, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(add, 0f, 0f), time, TweenAction.ROTATE_AROUND, LeanTween.options().setAxis(axis));
	}

	// Token: 0x06000D7E RID: 3454 RVA: 0x0004329F File Offset: 0x0004169F
	public static LTDescr rotateAround(RectTransform rectTrans, Vector3 axis, float to, float time)
	{
		return LeanTween.pushNewTween(rectTrans.gameObject, new Vector3(to, 0f, 0f), time, TweenAction.CANVAS_ROTATEAROUND, LeanTween.options().setRect(rectTrans).setAxis(axis));
	}

	// Token: 0x06000D7F RID: 3455 RVA: 0x000432D0 File Offset: 0x000416D0
	public static LTDescr rotateAroundLocal(GameObject gameObject, Vector3 axis, float add, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(add, 0f, 0f), time, TweenAction.ROTATE_AROUND_LOCAL, LeanTween.options().setAxis(axis));
	}

	// Token: 0x06000D80 RID: 3456 RVA: 0x000432F6 File Offset: 0x000416F6
	public static LTDescr rotateAroundLocal(RectTransform rectTrans, Vector3 axis, float to, float time)
	{
		return LeanTween.pushNewTween(rectTrans.gameObject, new Vector3(to, 0f, 0f), time, TweenAction.CANVAS_ROTATEAROUND_LOCAL, LeanTween.options().setRect(rectTrans).setAxis(axis));
	}

	// Token: 0x06000D81 RID: 3457 RVA: 0x00043327 File Offset: 0x00041727
	public static LTDescr rotateLocal(GameObject gameObject, Vector3 to, float time)
	{
		return LeanTween.pushNewTween(gameObject, to, time, TweenAction.ROTATE_LOCAL, LeanTween.options());
	}

	// Token: 0x06000D82 RID: 3458 RVA: 0x00043338 File Offset: 0x00041738
	public static LTDescr rotateX(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.ROTATE_X, LeanTween.options());
	}

	// Token: 0x06000D83 RID: 3459 RVA: 0x00043358 File Offset: 0x00041758
	public static LTDescr rotateY(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.ROTATE_Y, LeanTween.options());
	}

	// Token: 0x06000D84 RID: 3460 RVA: 0x00043378 File Offset: 0x00041778
	public static LTDescr rotateZ(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.ROTATE_Z, LeanTween.options());
	}

	// Token: 0x06000D85 RID: 3461 RVA: 0x00043398 File Offset: 0x00041798
	public static LTDescr scale(LTRect ltRect, Vector2 to, float time)
	{
		return LeanTween.pushNewTween(LeanTween.tweenEmpty, to, time, TweenAction.GUI_SCALE, LeanTween.options().setRect(ltRect));
	}

	// Token: 0x06000D86 RID: 3462 RVA: 0x000433B8 File Offset: 0x000417B8
	public static LTDescr scale(GameObject gameObject, Vector3 to, float time)
	{
		return LeanTween.pushNewTween(gameObject, to, time, TweenAction.SCALE, LeanTween.options());
	}

	// Token: 0x06000D87 RID: 3463 RVA: 0x000433C9 File Offset: 0x000417C9
	public static LTDescr scale(RectTransform rectTrans, Vector3 to, float time)
	{
		return LeanTween.pushNewTween(rectTrans.gameObject, to, time, TweenAction.CANVAS_SCALE, LeanTween.options().setRect(rectTrans));
	}

	// Token: 0x06000D88 RID: 3464 RVA: 0x000433E5 File Offset: 0x000417E5
	public static LTDescr scaleX(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.SCALE_X, LeanTween.options());
	}

	// Token: 0x06000D89 RID: 3465 RVA: 0x00043405 File Offset: 0x00041805
	public static LTDescr scaleY(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.SCALE_Y, LeanTween.options());
	}

	// Token: 0x06000D8A RID: 3466 RVA: 0x00043425 File Offset: 0x00041825
	public static LTDescr scaleZ(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.SCALE_Z, LeanTween.options());
	}

	// Token: 0x06000D8B RID: 3467 RVA: 0x00043448 File Offset: 0x00041848
	private static float spring(float start, float end, float val)
	{
		val = Mathf.Clamp01(val);
		val = (Mathf.Sin(val * 3.141593f * (0.2f + 2.5f * val * val * val)) * Mathf.Pow(1f - val, 2.2f) + val) * (1f + 1.2f * (1f - val));
		return start + (end - start) * val;
	}

	// Token: 0x06000D8C RID: 3468 RVA: 0x000434AC File Offset: 0x000418AC
	public static LTDescr textAlpha(RectTransform rectTransform, float to, float time)
	{
		return LeanTween.pushNewTween(rectTransform.gameObject, new Vector3(to, 0f, 0f), time, TweenAction.TEXT_ALPHA, LeanTween.options());
	}

	// Token: 0x06000D8D RID: 3469 RVA: 0x000434D4 File Offset: 0x000418D4
	private static void textAlphaRecursive(Transform trans, float val)
	{
		Text component = trans.gameObject.GetComponent<Text>();
		if (component != null)
		{
			Color color = component.color;
			color.a = val;
			component.color = color;
		}
		if (trans.childCount > 0)
		{
			IEnumerator enumerator = trans.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Transform transform = (Transform)obj;
					LeanTween.textAlphaRecursive(transform, val);
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable == null)
				{
				}
				disposable.Dispose();
			}
		}
	}

	// Token: 0x06000D8E RID: 3470 RVA: 0x00043574 File Offset: 0x00041974
	public static LTDescr textColor(RectTransform rectTransform, Color to, float time)
	{
		return LeanTween.pushNewTween(rectTransform.gameObject, new Vector3(1f, to.a, 0f), time, TweenAction.TEXT_COLOR, LeanTween.options().setPoint(new Vector3(to.r, to.g, to.b)));
	}

	// Token: 0x06000D8F RID: 3471 RVA: 0x000435CC File Offset: 0x000419CC
	private static Color tweenColor(LTDescr tween, float val)
	{
		Vector3 vector = tween.point - tween.axis;
		float num = tween.to.y - tween.from.y;
		return new Color(tween.axis.x + vector.x * val, tween.axis.y + vector.y * val, tween.axis.z + vector.z * val, tween.from.y + num * val);
	}

	// Token: 0x06000D90 RID: 3472 RVA: 0x00043656 File Offset: 0x00041A56
	private static float tweenOnCurve(LTDescr tweenDescr, float ratioPassed)
	{
		return tweenDescr.from.x + tweenDescr.diff.x * tweenDescr.animationCurve.Evaluate(ratioPassed);
	}

	// Token: 0x06000D91 RID: 3473 RVA: 0x0004367C File Offset: 0x00041A7C
	private static Vector3 tweenOnCurveVector(LTDescr tweenDescr, float ratioPassed)
	{
		float num = tweenDescr.animationCurve.Evaluate(ratioPassed);
		return new Vector3(tweenDescr.from.x + tweenDescr.diff.x * num, tweenDescr.from.y + tweenDescr.diff.y * num, tweenDescr.from.z + tweenDescr.diff.z * num);
	}

	// Token: 0x06000D92 RID: 3474 RVA: 0x000436E8 File Offset: 0x00041AE8
	public static void update()
	{
		if (LeanTween.frameRendered != Time.frameCount)
		{
			LeanTween.init();
			LeanTween.dtEstimated = Time.realtimeSinceStartup - LeanTween.previousRealTime;
			if (LeanTween.dtEstimated > 0.2f)
			{
				LeanTween.dtEstimated = 0.2f;
			}
			LeanTween.previousRealTime = Time.realtimeSinceStartup;
			LeanTween.dtActual = Time.deltaTime;
			LeanTween.maxTweenReached = 0;
			LeanTween.finishedCnt = 0;
			int num = 0;
			while (num <= LeanTween.tweenMaxSearch && num < LeanTween.maxTweens)
			{
				if (LeanTween.tweens[num].toggle)
				{
					LeanTween.maxTweenReached = num;
					LeanTween.tween = LeanTween.tweens[num];
					LeanTween.trans = LeanTween.tween.trans;
					LeanTween.timeTotal = LeanTween.tween.time;
					LeanTween.tweenAction = LeanTween.tween.type;
					LeanTween.dt = LeanTween.dtActual;
					if (LeanTween.tween.useEstimatedTime)
					{
						LeanTween.dt = LeanTween.dtEstimated;
						LeanTween.timeTotal = LeanTween.tween.time;
					}
					else if (LeanTween.tween.useFrames)
					{
						LeanTween.dt = 1f;
					}
					else if (LeanTween.tween.useManualTime)
					{
						LeanTween.dt = LeanTween.dtManual;
					}
					else if (LeanTween.tween.direction == 0f)
					{
						LeanTween.dt = 0f;
					}
					if (LeanTween.trans == null)
					{
						LeanTween.removeTween(num);
					}
					else
					{
						LeanTween.isTweenFinished = false;
						if (LeanTween.tween.delay <= 0f)
						{
							if (LeanTween.tween.passed + LeanTween.dt > LeanTween.tween.time && LeanTween.tween.direction > 0f)
							{
								LeanTween.isTweenFinished = true;
								LeanTween.tween.passed = LeanTween.tween.time;
							}
							else if (LeanTween.tween.direction < 0f && LeanTween.tween.passed - LeanTween.dt < 0f)
							{
								LeanTween.isTweenFinished = true;
								LeanTween.tween.passed = float.Epsilon;
							}
						}
						if (!LeanTween.tween.hasInitiliazed && (((double)LeanTween.tween.passed == 0.0 && (double)LeanTween.tween.delay == 0.0) || (double)LeanTween.tween.passed > 0.0))
						{
							LeanTween.tween.init();
						}
						if (LeanTween.tween.delay <= 0f)
						{
							if (LeanTween.timeTotal <= 0f)
							{
								LeanTween.ratioPassed = 0f;
							}
							else
							{
								LeanTween.ratioPassed = LeanTween.tween.passed / LeanTween.timeTotal;
							}
							if (LeanTween.ratioPassed > 1f)
							{
								LeanTween.ratioPassed = 1f;
							}
							else if (LeanTween.ratioPassed < 0f)
							{
								LeanTween.ratioPassed = 0f;
							}
							if (LeanTween.tweenAction < TweenAction.MOVE_X || LeanTween.tweenAction >= TweenAction.MOVE)
							{
								if (LeanTween.tweenAction >= TweenAction.MOVE)
								{
									if (LeanTween.tween.animationCurve != null)
									{
										LeanTween.newVect = LeanTween.tweenOnCurveVector(LeanTween.tween, LeanTween.ratioPassed);
									}
									else if (LeanTween.tween.tweenType == LeanTweenType.linear)
									{
										LeanTween.newVect = new Vector3(LeanTween.tween.from.x + LeanTween.tween.diff.x * LeanTween.ratioPassed, LeanTween.tween.from.y + LeanTween.tween.diff.y * LeanTween.ratioPassed, LeanTween.tween.from.z + LeanTween.tween.diff.z * LeanTween.ratioPassed);
									}
									else if (LeanTween.tween.tweenType < LeanTweenType.linear)
									{
										LeanTween.newVect = new Vector3(LeanTween.tween.from.x + LeanTween.tween.diff.x * LeanTween.ratioPassed, LeanTween.tween.from.y + LeanTween.tween.diff.y * LeanTween.ratioPassed, LeanTween.tween.from.z + LeanTween.tween.diff.z * LeanTween.ratioPassed);
									}
									else
									{
										switch (LeanTween.tween.tweenType)
										{
										case LeanTweenType.easeOutQuad:
										{
											float num2 = LeanTween.easeOutQuadOpt(LeanTween.tween.from.x, LeanTween.tween.diff.x, LeanTween.ratioPassed);
											float num3 = LeanTween.easeOutQuadOpt(LeanTween.tween.from.y, LeanTween.tween.diff.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num2, num3, LeanTween.easeOutQuadOpt(LeanTween.tween.from.z, LeanTween.tween.diff.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeInQuad:
										{
											float num4 = LeanTween.easeInQuadOpt(LeanTween.tween.from.x, LeanTween.tween.diff.x, LeanTween.ratioPassed);
											float num5 = LeanTween.easeInQuadOpt(LeanTween.tween.from.y, LeanTween.tween.diff.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num4, num5, LeanTween.easeInQuadOpt(LeanTween.tween.from.z, LeanTween.tween.diff.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeInOutQuad:
										{
											float num6 = LeanTween.easeInOutQuadOpt(LeanTween.tween.from.x, LeanTween.tween.diff.x, LeanTween.ratioPassed);
											float num7 = LeanTween.easeInOutQuadOpt(LeanTween.tween.from.y, LeanTween.tween.diff.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num6, num7, LeanTween.easeInOutQuadOpt(LeanTween.tween.from.z, LeanTween.tween.diff.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeInCubic:
										{
											float num8 = LeanTween.easeInCubic(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num9 = LeanTween.easeInCubic(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num8, num9, LeanTween.easeInCubic(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeOutCubic:
										{
											float num10 = LeanTween.easeOutCubic(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num11 = LeanTween.easeOutCubic(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num10, num11, LeanTween.easeOutCubic(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeInOutCubic:
										{
											float num12 = LeanTween.easeInOutCubic(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num13 = LeanTween.easeInOutCubic(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num12, num13, LeanTween.easeInOutCubic(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeInQuart:
										{
											float num14 = LeanTween.easeInQuart(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num15 = LeanTween.easeInQuart(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num14, num15, LeanTween.easeInQuart(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeOutQuart:
										{
											float num16 = LeanTween.easeOutQuart(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num17 = LeanTween.easeOutQuart(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num16, num17, LeanTween.easeOutQuart(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeInOutQuart:
										{
											float num18 = LeanTween.easeInOutQuart(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num19 = LeanTween.easeInOutQuart(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num18, num19, LeanTween.easeInOutQuart(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeInQuint:
										{
											float num20 = LeanTween.easeInQuint(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num21 = LeanTween.easeInQuint(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num20, num21, LeanTween.easeInQuint(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeOutQuint:
										{
											float num22 = LeanTween.easeOutQuint(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num23 = LeanTween.easeOutQuint(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num22, num23, LeanTween.easeOutQuint(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeInOutQuint:
										{
											float num24 = LeanTween.easeInOutQuint(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num25 = LeanTween.easeInOutQuint(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num24, num25, LeanTween.easeInOutQuint(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeInSine:
										{
											float num26 = LeanTween.easeInSine(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num27 = LeanTween.easeInSine(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num26, num27, LeanTween.easeInSine(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeOutSine:
										{
											float num28 = LeanTween.easeOutSine(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num29 = LeanTween.easeOutSine(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num28, num29, LeanTween.easeOutSine(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeInOutSine:
										{
											float num30 = LeanTween.easeInOutSine(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num31 = LeanTween.easeInOutSine(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num30, num31, LeanTween.easeInOutSine(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeInExpo:
										{
											float num32 = LeanTween.easeInExpo(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num33 = LeanTween.easeInExpo(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num32, num33, LeanTween.easeInExpo(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeOutExpo:
										{
											float num34 = LeanTween.easeOutExpo(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num35 = LeanTween.easeOutExpo(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num34, num35, LeanTween.easeOutExpo(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeInOutExpo:
										{
											float num36 = LeanTween.easeInOutExpo(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num37 = LeanTween.easeInOutExpo(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num36, num37, LeanTween.easeInOutExpo(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeInCirc:
										{
											float num38 = LeanTween.easeInCirc(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num39 = LeanTween.easeInCirc(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num38, num39, LeanTween.easeInCirc(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeOutCirc:
										{
											float num40 = LeanTween.easeOutCirc(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num41 = LeanTween.easeOutCirc(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num40, num41, LeanTween.easeOutCirc(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeInOutCirc:
										{
											float num42 = LeanTween.easeInOutCirc(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num43 = LeanTween.easeInOutCirc(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num42, num43, LeanTween.easeInOutCirc(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeInBounce:
										{
											float num44 = LeanTween.easeInBounce(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num45 = LeanTween.easeInBounce(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num44, num45, LeanTween.easeInBounce(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeOutBounce:
										{
											float num46 = LeanTween.easeOutBounce(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num47 = LeanTween.easeOutBounce(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num46, num47, LeanTween.easeOutBounce(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeInOutBounce:
										{
											float num48 = LeanTween.easeInOutBounce(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num49 = LeanTween.easeInOutBounce(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num48, num49, LeanTween.easeInOutBounce(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeInBack:
										{
											float num50 = LeanTween.easeInBack(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num51 = LeanTween.easeInBack(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num50, num51, LeanTween.easeInBack(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeOutBack:
										{
											float num52 = LeanTween.easeOutBack(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num53 = LeanTween.easeOutBack(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num52, num53, LeanTween.easeOutBack(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeInOutBack:
										{
											float num54 = LeanTween.easeInOutBack(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num55 = LeanTween.easeInOutBack(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num54, num55, LeanTween.easeInOutBack(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeInElastic:
										{
											float num56 = LeanTween.easeInElastic(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num57 = LeanTween.easeInElastic(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num56, num57, LeanTween.easeInElastic(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeOutElastic:
										{
											float num58 = LeanTween.easeOutElastic(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num59 = LeanTween.easeOutElastic(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num58, num59, LeanTween.easeOutElastic(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeInOutElastic:
										{
											float num60 = LeanTween.easeInOutElastic(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num61 = LeanTween.easeInOutElastic(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num60, num61, LeanTween.easeInOutElastic(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeSpring:
										{
											float num62 = LeanTween.spring(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
											float num63 = LeanTween.spring(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed);
											LeanTween.newVect = new Vector3(num62, num63, LeanTween.spring(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
											break;
										}
										case LeanTweenType.easeShake:
										case LeanTweenType.punch:
											if (LeanTween.tween.tweenType != LeanTweenType.punch)
											{
												if (LeanTween.tween.tweenType == LeanTweenType.easeShake)
												{
													LeanTween.tween.animationCurve = LeanTween.shake;
												}
											}
											else
											{
												LeanTween.tween.animationCurve = LeanTween.punch;
											}
											LeanTween.tween.to = LeanTween.tween.from + LeanTween.tween.to;
											LeanTween.tween.diff = LeanTween.tween.to - LeanTween.tween.from;
											if (LeanTween.tweenAction == TweenAction.ROTATE || LeanTween.tweenAction == TweenAction.ROTATE_LOCAL)
											{
												float num64 = LeanTween.closestRot(LeanTween.tween.from.x, LeanTween.tween.to.x);
												float num65 = LeanTween.closestRot(LeanTween.tween.from.y, LeanTween.tween.to.y);
												LeanTween.tween.to = new Vector3(num64, num65, LeanTween.closestRot(LeanTween.tween.from.z, LeanTween.tween.to.z));
											}
											LeanTween.newVect = LeanTween.tweenOnCurveVector(LeanTween.tween, LeanTween.ratioPassed);
											break;
										}
									}
									IL_2E27:
									if (LeanTween.tweenAction == TweenAction.MOVE)
									{
										LeanTween.trans.position = LeanTween.newVect;
										goto IL_306B;
									}
									if (LeanTween.tweenAction == TweenAction.MOVE_LOCAL)
									{
										LeanTween.trans.localPosition = LeanTween.newVect;
										goto IL_306B;
									}
									if (LeanTween.tweenAction == TweenAction.ROTATE)
									{
										LeanTween.trans.eulerAngles = LeanTween.newVect;
										goto IL_306B;
									}
									if (LeanTween.tweenAction == TweenAction.ROTATE_LOCAL)
									{
										LeanTween.trans.localEulerAngles = LeanTween.newVect;
										goto IL_306B;
									}
									if (LeanTween.tweenAction == TweenAction.SCALE)
									{
										LeanTween.trans.localScale = LeanTween.newVect;
										goto IL_306B;
									}
									if (LeanTween.tweenAction == TweenAction.GUI_MOVE)
									{
										LeanTween.tween.ltRect.rect = new Rect(LeanTween.newVect.x, LeanTween.newVect.y, LeanTween.tween.ltRect.rect.width, LeanTween.tween.ltRect.rect.height);
										goto IL_306B;
									}
									if (LeanTween.tweenAction == TweenAction.GUI_MOVE_MARGIN)
									{
										LeanTween.tween.ltRect.margin = new Vector2(LeanTween.newVect.x, LeanTween.newVect.y);
										goto IL_306B;
									}
									if (LeanTween.tweenAction == TweenAction.GUI_SCALE)
									{
										LeanTween.tween.ltRect.rect = new Rect(LeanTween.tween.ltRect.rect.x, LeanTween.tween.ltRect.rect.y, LeanTween.newVect.x, LeanTween.newVect.y);
										goto IL_306B;
									}
									if (LeanTween.tweenAction == TweenAction.GUI_ALPHA)
									{
										LeanTween.tween.ltRect.alpha = LeanTween.newVect.x;
										goto IL_306B;
									}
									if (LeanTween.tweenAction == TweenAction.GUI_ROTATE)
									{
										LeanTween.tween.ltRect.rotation = LeanTween.newVect.x;
										goto IL_306B;
									}
									if (LeanTween.tweenAction == TweenAction.CANVAS_MOVE)
									{
										LeanTween.tween.rectTransform.anchoredPosition3D = LeanTween.newVect;
										goto IL_306B;
									}
									if (LeanTween.tweenAction == TweenAction.CANVAS_SCALE)
									{
										LeanTween.tween.rectTransform.localScale = LeanTween.newVect;
										goto IL_306B;
									}
									goto IL_306B;
									goto IL_2E27;
								}
							}
							else
							{
								if (LeanTween.tween.animationCurve != null)
								{
									LeanTween.val = LeanTween.tweenOnCurve(LeanTween.tween, LeanTween.ratioPassed);
								}
								else
								{
									switch (LeanTween.tween.tweenType)
									{
									case LeanTweenType.linear:
										LeanTween.val = LeanTween.tween.from.x + LeanTween.tween.diff.x * LeanTween.ratioPassed;
										break;
									case LeanTweenType.easeOutQuad:
										LeanTween.val = LeanTween.easeOutQuadOpt(LeanTween.tween.from.x, LeanTween.tween.diff.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInQuad:
										LeanTween.val = LeanTween.easeInQuadOpt(LeanTween.tween.from.x, LeanTween.tween.diff.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInOutQuad:
										LeanTween.val = LeanTween.easeInOutQuadOpt(LeanTween.tween.from.x, LeanTween.tween.diff.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInCubic:
										LeanTween.val = LeanTween.easeInCubic(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeOutCubic:
										LeanTween.val = LeanTween.easeOutCubic(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInOutCubic:
										LeanTween.val = LeanTween.easeInOutCubic(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInQuart:
										LeanTween.val = LeanTween.easeInQuart(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeOutQuart:
										LeanTween.val = LeanTween.easeOutQuart(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInOutQuart:
										LeanTween.val = LeanTween.easeInOutQuart(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInQuint:
										LeanTween.val = LeanTween.easeInQuint(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeOutQuint:
										LeanTween.val = LeanTween.easeOutQuint(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInOutQuint:
										LeanTween.val = LeanTween.easeInOutQuint(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInSine:
										LeanTween.val = LeanTween.easeInSine(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeOutSine:
										LeanTween.val = LeanTween.easeOutSine(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInOutSine:
										LeanTween.val = LeanTween.easeInOutSine(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInExpo:
										LeanTween.val = LeanTween.easeInExpo(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeOutExpo:
										LeanTween.val = LeanTween.easeOutExpo(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInOutExpo:
										LeanTween.val = LeanTween.easeInOutExpo(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInCirc:
										LeanTween.val = LeanTween.easeInCirc(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeOutCirc:
										LeanTween.val = LeanTween.easeOutCirc(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInOutCirc:
										LeanTween.val = LeanTween.easeInOutCirc(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInBounce:
										LeanTween.val = LeanTween.easeInBounce(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeOutBounce:
										LeanTween.val = LeanTween.easeOutBounce(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInOutBounce:
										LeanTween.val = LeanTween.easeInOutBounce(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInBack:
										LeanTween.val = LeanTween.easeInBack(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeOutBack:
										LeanTween.val = LeanTween.easeOutBack(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInOutBack:
										LeanTween.val = LeanTween.easeInOutElastic(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInElastic:
										LeanTween.val = LeanTween.easeInElastic(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeOutElastic:
										LeanTween.val = LeanTween.easeOutElastic(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInOutElastic:
										LeanTween.val = LeanTween.easeInOutElastic(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeSpring:
										LeanTween.val = LeanTween.spring(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeShake:
									case LeanTweenType.punch:
										if (LeanTween.tween.tweenType != LeanTweenType.punch)
										{
											if (LeanTween.tween.tweenType == LeanTweenType.easeShake)
											{
												LeanTween.tween.animationCurve = LeanTween.shake;
											}
										}
										else
										{
											LeanTween.tween.animationCurve = LeanTween.punch;
										}
										LeanTween.tween.to.x = LeanTween.tween.from.x + LeanTween.tween.to.x;
										LeanTween.tween.diff.x = LeanTween.tween.to.x - LeanTween.tween.from.x;
										LeanTween.val = LeanTween.tweenOnCurve(LeanTween.tween, LeanTween.ratioPassed);
										break;
									default:
										LeanTween.val = LeanTween.tween.from.x + LeanTween.tween.diff.x * LeanTween.ratioPassed;
										break;
									}
								}
								if (LeanTween.tweenAction == TweenAction.MOVE_X)
								{
									LeanTween.trans.position = new Vector3(LeanTween.val, LeanTween.trans.position.y, LeanTween.trans.position.z);
								}
								else if (LeanTween.tweenAction == TweenAction.MOVE_Y)
								{
									LeanTween.trans.position = new Vector3(LeanTween.trans.position.x, LeanTween.val, LeanTween.trans.position.z);
								}
								else if (LeanTween.tweenAction == TweenAction.MOVE_Z)
								{
									LeanTween.trans.position = new Vector3(LeanTween.trans.position.x, LeanTween.trans.position.y, LeanTween.val);
								}
								if (LeanTween.tweenAction == TweenAction.MOVE_LOCAL_X)
								{
									LeanTween.trans.localPosition = new Vector3(LeanTween.val, LeanTween.trans.localPosition.y, LeanTween.trans.localPosition.z);
								}
								else if (LeanTween.tweenAction == TweenAction.MOVE_LOCAL_Y)
								{
									LeanTween.trans.localPosition = new Vector3(LeanTween.trans.localPosition.x, LeanTween.val, LeanTween.trans.localPosition.z);
								}
								else if (LeanTween.tweenAction == TweenAction.MOVE_LOCAL_Z)
								{
									LeanTween.trans.localPosition = new Vector3(LeanTween.trans.localPosition.x, LeanTween.trans.localPosition.y, LeanTween.val);
								}
								else if (LeanTween.tweenAction == TweenAction.MOVE_CURVED)
								{
									if (LeanTween.tween.path.orientToPath)
									{
										if (LeanTween.tween.path.orientToPath2d)
										{
											LeanTween.tween.path.place2d(LeanTween.trans, LeanTween.val);
										}
										else
										{
											LeanTween.tween.path.place(LeanTween.trans, LeanTween.val);
										}
									}
									else
									{
										LeanTween.trans.position = LeanTween.tween.path.point(LeanTween.val);
									}
								}
								else if (LeanTween.tweenAction == TweenAction.MOVE_CURVED_LOCAL)
								{
									if (LeanTween.tween.path.orientToPath)
									{
										if (LeanTween.tween.path.orientToPath2d)
										{
											LeanTween.tween.path.placeLocal2d(LeanTween.trans, LeanTween.val);
										}
										else
										{
											LeanTween.tween.path.placeLocal(LeanTween.trans, LeanTween.val);
										}
									}
									else
									{
										LeanTween.trans.localPosition = LeanTween.tween.path.point(LeanTween.val);
									}
								}
								else if (LeanTween.tweenAction == TweenAction.MOVE_SPLINE)
								{
									if (LeanTween.tween.spline.orientToPath)
									{
										if (LeanTween.tween.spline.orientToPath2d)
										{
											LeanTween.tween.spline.place2d(LeanTween.trans, LeanTween.val);
										}
										else
										{
											LeanTween.tween.spline.place(LeanTween.trans, LeanTween.val);
										}
									}
									else
									{
										LeanTween.trans.position = LeanTween.tween.spline.point(LeanTween.val);
									}
								}
								else if (LeanTween.tweenAction == TweenAction.MOVE_SPLINE_LOCAL)
								{
									if (LeanTween.tween.spline.orientToPath)
									{
										if (LeanTween.tween.spline.orientToPath2d)
										{
											LeanTween.tween.spline.placeLocal2d(LeanTween.trans, LeanTween.val);
										}
										else
										{
											LeanTween.tween.spline.placeLocal(LeanTween.trans, LeanTween.val);
										}
									}
									else
									{
										LeanTween.trans.localPosition = LeanTween.tween.spline.point(LeanTween.val);
									}
								}
								else if (LeanTween.tweenAction == TweenAction.SCALE_X)
								{
									LeanTween.trans.localScale = new Vector3(LeanTween.val, LeanTween.trans.localScale.y, LeanTween.trans.localScale.z);
								}
								else if (LeanTween.tweenAction == TweenAction.SCALE_Y)
								{
									LeanTween.trans.localScale = new Vector3(LeanTween.trans.localScale.x, LeanTween.val, LeanTween.trans.localScale.z);
								}
								else if (LeanTween.tweenAction == TweenAction.SCALE_Z)
								{
									LeanTween.trans.localScale = new Vector3(LeanTween.trans.localScale.x, LeanTween.trans.localScale.y, LeanTween.val);
								}
								else if (LeanTween.tweenAction == TweenAction.ROTATE_X)
								{
									LeanTween.trans.eulerAngles = new Vector3(LeanTween.val, LeanTween.trans.eulerAngles.y, LeanTween.trans.eulerAngles.z);
								}
								else if (LeanTween.tweenAction == TweenAction.ROTATE_Y)
								{
									LeanTween.trans.eulerAngles = new Vector3(LeanTween.trans.eulerAngles.x, LeanTween.val, LeanTween.trans.eulerAngles.z);
								}
								else if (LeanTween.tweenAction == TweenAction.ROTATE_Z)
								{
									LeanTween.trans.eulerAngles = new Vector3(LeanTween.trans.eulerAngles.x, LeanTween.trans.eulerAngles.y, LeanTween.val);
								}
								else if (LeanTween.tweenAction == TweenAction.ROTATE_AROUND)
								{
									Vector3 localPosition = LeanTween.trans.localPosition;
									LeanTween.trans.RotateAround(LeanTween.trans.TransformPoint(LeanTween.tween.point), LeanTween.tween.axis, -LeanTween.val);
									Vector3 vector = localPosition - LeanTween.trans.localPosition;
									LeanTween.trans.localPosition = localPosition - vector;
									LeanTween.trans.rotation = LeanTween.tween.origRotation;
									LeanTween.trans.RotateAround(LeanTween.trans.TransformPoint(LeanTween.tween.point), LeanTween.tween.axis, LeanTween.val);
								}
								else if (LeanTween.tweenAction == TweenAction.ROTATE_AROUND_LOCAL)
								{
									Vector3 localPosition2 = LeanTween.trans.localPosition;
									LeanTween.trans.RotateAround(LeanTween.trans.TransformPoint(LeanTween.tween.point), LeanTween.trans.TransformDirection(LeanTween.tween.axis), -LeanTween.val);
									Vector3 vector2 = localPosition2 - LeanTween.trans.localPosition;
									LeanTween.trans.localPosition = localPosition2 - vector2;
									LeanTween.trans.localRotation = LeanTween.tween.origRotation;
									LeanTween.trans.RotateAround(LeanTween.trans.TransformPoint(LeanTween.tween.point), LeanTween.trans.TransformDirection(LeanTween.tween.axis), LeanTween.val);
								}
								else if (LeanTween.tweenAction == TweenAction.ALPHA)
								{
									SpriteRenderer component = LeanTween.trans.gameObject.GetComponent<SpriteRenderer>();
									if (component != null)
									{
										component.color = new Color(component.color.r, component.color.g, component.color.b, LeanTween.val);
									}
									else
									{
										if (LeanTween.trans.gameObject.GetComponent<Renderer>() != null)
										{
											foreach (Material material in LeanTween.trans.gameObject.GetComponent<Renderer>().materials)
											{
												if (material.HasProperty("_Color"))
												{
													material.color = new Color(material.color.r, material.color.g, material.color.b, LeanTween.val);
												}
												else if (material.HasProperty("_TintColor"))
												{
													Color color = material.GetColor("_TintColor");
													material.SetColor("_TintColor", new Color(color.r, color.g, color.b, LeanTween.val));
												}
											}
										}
										if (LeanTween.trans.childCount > 0)
										{
											IEnumerator enumerator = LeanTween.trans.GetEnumerator();
											try
											{
												while (enumerator.MoveNext())
												{
													object obj = enumerator.Current;
													Transform transform = (Transform)obj;
													if (transform.gameObject.GetComponent<Renderer>() != null)
													{
														foreach (Material material2 in transform.gameObject.GetComponent<Renderer>().materials)
														{
															material2.color = new Color(material2.color.r, material2.color.g, material2.color.b, LeanTween.val);
														}
													}
												}
											}
											finally
											{
												IDisposable disposable = enumerator as IDisposable;
												if (disposable == null)
												{
												}
												disposable.Dispose();
											}
										}
									}
								}
								else if (LeanTween.tweenAction == TweenAction.ALPHA_VERTEX)
								{
									Mesh mesh = LeanTween.trans.GetComponent<MeshFilter>().mesh;
									Vector3[] vertices = mesh.vertices;
									Color32[] array = new Color32[vertices.Length];
									Color32 color2 = mesh.colors32[0];
									color2 = new Color((float)color2.r, (float)color2.g, (float)color2.b, LeanTween.val);
									for (int k = 0; k < vertices.Length; k++)
									{
										array[k] = color2;
									}
									mesh.colors32 = array;
								}
								else if (LeanTween.tweenAction == TweenAction.COLOR || LeanTween.tweenAction == TweenAction.CALLBACK_COLOR)
								{
									Color color3 = LeanTween.tweenColor(LeanTween.tween, LeanTween.val);
									if (LeanTween.tweenAction == TweenAction.COLOR)
									{
										if (LeanTween.trans.gameObject.GetComponent<Renderer>() != null)
										{
											foreach (Material material3 in LeanTween.trans.gameObject.GetComponent<Renderer>().materials)
											{
												material3.color = color3;
											}
										}
										if (LeanTween.trans.childCount > 0)
										{
											IEnumerator enumerator2 = LeanTween.trans.GetEnumerator();
											try
											{
												while (enumerator2.MoveNext())
												{
													object obj2 = enumerator2.Current;
													Transform transform2 = (Transform)obj2;
													if (transform2.gameObject.GetComponent<Renderer>() != null)
													{
														foreach (Material material4 in transform2.gameObject.GetComponent<Renderer>().materials)
														{
															material4.color = color3;
														}
													}
												}
											}
											finally
											{
												IDisposable disposable2 = enumerator2 as IDisposable;
												if (disposable2 == null)
												{
												}
												disposable2.Dispose();
											}
										}
									}
									if (LeanTween.tween.onUpdateColor != null)
									{
										LeanTween.tween.onUpdateColor(color3);
									}
								}
								else if (LeanTween.tweenAction == TweenAction.CANVAS_ALPHA)
								{
									Color color4 = LeanTween.tween.uiImage.color;
									color4.a = LeanTween.val;
									LeanTween.tween.uiImage.color = color4;
								}
								else if (LeanTween.tweenAction == TweenAction.CANVAS_COLOR)
								{
									Color color5 = LeanTween.tweenColor(LeanTween.tween, LeanTween.val);
									LeanTween.tween.uiImage.color = color5;
									if (LeanTween.tween.onUpdateColor != null)
									{
										LeanTween.tween.onUpdateColor(color5);
									}
								}
								else if (LeanTween.tweenAction == TweenAction.TEXT_ALPHA)
								{
									LeanTween.textAlphaRecursive(LeanTween.trans, LeanTween.val);
								}
								else if (LeanTween.tweenAction == TweenAction.TEXT_COLOR)
								{
									Color color6 = LeanTween.tweenColor(LeanTween.tween, LeanTween.val);
									LeanTween.tween.uiText.color = color6;
									if (LeanTween.tween.onUpdateColor != null)
									{
										LeanTween.tween.onUpdateColor(color6);
									}
									if (LeanTween.trans.childCount > 0)
									{
										IEnumerator enumerator3 = LeanTween.trans.GetEnumerator();
										try
										{
											while (enumerator3.MoveNext())
											{
												object obj3 = enumerator3.Current;
												Transform transform3 = (Transform)obj3;
												Text component2 = transform3.gameObject.GetComponent<Text>();
												if (component2 != null)
												{
													component2.color = color6;
												}
											}
										}
										finally
										{
											IDisposable disposable3 = enumerator3 as IDisposable;
											if (disposable3 == null)
											{
											}
											disposable3.Dispose();
										}
									}
								}
								else if (LeanTween.tweenAction == TweenAction.CANVAS_ROTATEAROUND)
								{
									RectTransform rectTransform = LeanTween.tween.rectTransform;
									Vector3 localPosition3 = rectTransform.localPosition;
									rectTransform.RotateAround(rectTransform.TransformPoint(LeanTween.tween.point), LeanTween.tween.axis, -LeanTween.val);
									Vector3 vector3 = localPosition3 - rectTransform.localPosition;
									rectTransform.localPosition = localPosition3 - vector3;
									rectTransform.rotation = LeanTween.tween.origRotation;
									rectTransform.RotateAround(rectTransform.TransformPoint(LeanTween.tween.point), LeanTween.tween.axis, LeanTween.val);
								}
								else if (LeanTween.tweenAction == TweenAction.CANVAS_ROTATEAROUND_LOCAL)
								{
									RectTransform rectTransform2 = LeanTween.tween.rectTransform;
									Vector3 localPosition4 = rectTransform2.localPosition;
									rectTransform2.RotateAround(rectTransform2.TransformPoint(LeanTween.tween.point), rectTransform2.TransformDirection(LeanTween.tween.axis), -LeanTween.val);
									Vector3 vector4 = localPosition4 - rectTransform2.localPosition;
									rectTransform2.localPosition = localPosition4 - vector4;
									rectTransform2.rotation = LeanTween.tween.origRotation;
									rectTransform2.RotateAround(rectTransform2.TransformPoint(LeanTween.tween.point), rectTransform2.TransformDirection(LeanTween.tween.axis), LeanTween.val);
								}
								else if (LeanTween.tweenAction == TweenAction.CANVAS_PLAYSPRITE)
								{
									int num66 = (int)Mathf.Round(LeanTween.val);
									LeanTween.tween.uiImage.sprite = LeanTween.tween.sprites[num66];
								}
							}
							IL_306B:
							if (LeanTween.tween.hasUpdateCallback)
							{
								if (LeanTween.tween.onUpdateFloat != null)
								{
									LeanTween.tween.onUpdateFloat(LeanTween.val);
								}
								else if (LeanTween.tween.onUpdateFloatObject != null)
								{
									LeanTween.tween.onUpdateFloatObject(LeanTween.val, LeanTween.tween.onUpdateParam);
								}
								else if (LeanTween.tween.onUpdateVector3Object != null)
								{
									LeanTween.tween.onUpdateVector3Object(LeanTween.newVect, LeanTween.tween.onUpdateParam);
								}
								else if (LeanTween.tween.onUpdateVector3 != null)
								{
									LeanTween.tween.onUpdateVector3(LeanTween.newVect);
								}
								else if (LeanTween.tween.onUpdateVector2 != null)
								{
									LeanTween.tween.onUpdateVector2(new Vector2(LeanTween.newVect.x, LeanTween.newVect.y));
								}
							}
						}
						if (LeanTween.isTweenFinished)
						{
							if (LeanTween.tween.loopType == LeanTweenType.once || LeanTween.tween.loopCount == 1)
							{
								LeanTween.tweensFinished[LeanTween.finishedCnt] = num;
								LeanTween.finishedCnt++;
								if (LeanTween.tweenAction == TweenAction.GUI_ROTATE)
								{
									LeanTween.tween.ltRect.rotateFinished = true;
								}
								if (LeanTween.tweenAction == TweenAction.DELAYED_SOUND)
								{
									AudioSource.PlayClipAtPoint((AudioClip)LeanTween.tween.onCompleteParam, LeanTween.tween.to, LeanTween.tween.from.x);
								}
							}
							else
							{
								if ((LeanTween.tween.loopCount < 0 && LeanTween.tween.type == TweenAction.CALLBACK) || LeanTween.tween.onCompleteOnRepeat)
								{
									if (LeanTween.tweenAction == TweenAction.DELAYED_SOUND)
									{
										AudioSource.PlayClipAtPoint((AudioClip)LeanTween.tween.onCompleteParam, LeanTween.tween.to, LeanTween.tween.from.x);
									}
									if (LeanTween.tween.onComplete != null)
									{
										LeanTween.tween.onComplete();
									}
									else if (LeanTween.tween.onCompleteObject != null)
									{
										LeanTween.tween.onCompleteObject(LeanTween.tween.onCompleteParam);
									}
								}
								if (LeanTween.tween.loopCount >= 1)
								{
									LeanTween.tween.loopCount--;
								}
								if (LeanTween.tween.loopType == LeanTweenType.pingPong)
								{
									LeanTween.tween.direction = 0f - LeanTween.tween.direction;
								}
								else
								{
									LeanTween.tween.passed = float.Epsilon;
								}
							}
						}
						else if (LeanTween.tween.delay <= 0f)
						{
							LeanTween.tween.passed += LeanTween.dt * LeanTween.tween.direction;
						}
						else
						{
							LeanTween.tween.delay -= LeanTween.dt;
							if (LeanTween.tween.delay < 0f)
							{
								LeanTween.tween.passed = 0f;
								LeanTween.tween.delay = 0f;
							}
						}
					}
				}
				num++;
			}
			LeanTween.tweenMaxSearch = LeanTween.maxTweenReached;
			LeanTween.frameRendered = Time.frameCount;
			for (int n = 0; n < LeanTween.finishedCnt; n++)
			{
				LeanTween.j = LeanTween.tweensFinished[n];
				LeanTween.tween = LeanTween.tweens[LeanTween.j];
				if (LeanTween.tween.onComplete != null)
				{
					LeanTween.removeTween(LeanTween.j);
					LeanTween.tween.onComplete();
				}
				else if (LeanTween.tween.onCompleteObject != null)
				{
					LeanTween.removeTween(LeanTween.j);
					LeanTween.tween.onCompleteObject(LeanTween.tween.onCompleteParam);
				}
				else
				{
					LeanTween.removeTween(LeanTween.j);
				}
			}
		}
	}

	// Token: 0x06000D93 RID: 3475 RVA: 0x00046B90 File Offset: 0x00044F90
	public void Update()
	{
		LeanTween.update();
	}

	// Token: 0x06000D94 RID: 3476 RVA: 0x00046B97 File Offset: 0x00044F97
	public static LTDescr value(GameObject gameObject, float from, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.CALLBACK, LeanTween.options().setFrom(new Vector3(from, 0f, 0f)));
	}

	// Token: 0x06000D95 RID: 3477 RVA: 0x00046BCC File Offset: 0x00044FCC
	public static LTDescr value(GameObject gameObject, Color from, Color to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(1f, to.a, 0f), time, TweenAction.CALLBACK_COLOR, LeanTween.options().setPoint(new Vector3(to.r, to.g, to.b)).setFromColor(from).setHasInitialized(false));
	}

	// Token: 0x06000D96 RID: 3478 RVA: 0x00046C28 File Offset: 0x00045028
	public static LTDescr value(GameObject gameObject, Vector2 from, Vector2 to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to.x, to.y, 0f), time, TweenAction.VALUE3, LeanTween.options().setTo(new Vector3(to.x, to.y, 0f)).setFrom(new Vector3(from.x, from.y, 0f)));
	}

	// Token: 0x06000D97 RID: 3479 RVA: 0x00046C95 File Offset: 0x00045095
	public static LTDescr value(GameObject gameObject, Vector3 from, Vector3 to, float time)
	{
		return LeanTween.pushNewTween(gameObject, to, time, TweenAction.VALUE3, LeanTween.options().setFrom(from));
	}

	// Token: 0x06000D98 RID: 3480 RVA: 0x00046CAC File Offset: 0x000450AC
	public static LTDescr value(GameObject gameObject, Action<float> callOnUpdate, float from, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.CALLBACK, LeanTween.options().setTo(new Vector3(to, 0f, 0f)).setFrom(new Vector3(from, 0f, 0f)).setOnUpdate(callOnUpdate));
	}

	// Token: 0x06000D99 RID: 3481 RVA: 0x00046D08 File Offset: 0x00045108
	public static LTDescr value(GameObject gameObject, Action<Color> callOnUpdate, Color from, Color to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(1f, to.a, 0f), time, TweenAction.CALLBACK_COLOR, LeanTween.options().setPoint(new Vector3(to.r, to.g, to.b)).setAxis(new Vector3(from.r, from.g, from.b)).setFrom(new Vector3(0f, from.a, 0f)).setHasInitialized(false).setOnUpdateColor(callOnUpdate));
	}

	// Token: 0x06000D9A RID: 3482 RVA: 0x00046DA0 File Offset: 0x000451A0
	public static LTDescr value(GameObject gameObject, Action<Vector2> callOnUpdate, Vector2 from, Vector2 to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to.x, to.y, 0f), time, TweenAction.VALUE3, LeanTween.options().setTo(new Vector3(to.x, to.y, 0f)).setFrom(new Vector3(from.x, from.y, 0f)).setOnUpdateVector2(callOnUpdate));
	}

	// Token: 0x06000D9B RID: 3483 RVA: 0x00046E14 File Offset: 0x00045214
	public static LTDescr value(GameObject gameObject, Action<Vector3> callOnUpdate, Vector3 from, Vector3 to, float time)
	{
		return LeanTween.pushNewTween(gameObject, to, time, TweenAction.VALUE3, LeanTween.options().setTo(to).setFrom(from).setOnUpdateVector3(callOnUpdate));
	}

	// Token: 0x06000D9C RID: 3484 RVA: 0x00046E38 File Offset: 0x00045238
	public static LTDescr value(GameObject gameObject, Action<float, object> callOnUpdate, float from, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.CALLBACK, LeanTween.options().setTo(new Vector3(to, 0f, 0f)).setFrom(new Vector3(from, 0f, 0f)).setOnUpdateObject(callOnUpdate));
	}

	// Token: 0x170001E3 RID: 483
	// (get) Token: 0x06000D9D RID: 3485 RVA: 0x00046E94 File Offset: 0x00045294
	public static int maxSearch
	{
		get
		{
			return LeanTween.tweenMaxSearch;
		}
	}

	// Token: 0x170001E4 RID: 484
	// (get) Token: 0x06000D9E RID: 3486 RVA: 0x00046E9B File Offset: 0x0004529B
	public static GameObject tweenEmpty
	{
		get
		{
			LeanTween.init(LeanTween.maxTweens);
			return LeanTween._tweenEmpty;
		}
	}

	// Token: 0x0400090B RID: 2315
	private static GameObject _tweenEmpty;

	// Token: 0x0400090C RID: 2316
	public static LTDescr descr;

	// Token: 0x0400090D RID: 2317
	private static float dt;

	// Token: 0x0400090E RID: 2318
	private static float dtActual;

	// Token: 0x0400090F RID: 2319
	private static float dtEstimated;

	// Token: 0x04000910 RID: 2320
	public static float dtManual;

	// Token: 0x04000911 RID: 2321
	private static Action<LTEvent>[] eventListeners;

	// Token: 0x04000912 RID: 2322
	public static int EVENTS_MAX;

	// Token: 0x04000913 RID: 2323
	private static int eventsMaxSearch;

	// Token: 0x04000914 RID: 2324
	private static int finishedCnt;

	// Token: 0x04000915 RID: 2325
	private static int frameRendered = -1;

	// Token: 0x04000916 RID: 2326
	private static GameObject[] goListeners;

	// Token: 0x04000917 RID: 2327
	private static int i;

	// Token: 0x04000918 RID: 2328
	private static int INIT_LISTENERS_MAX;

	// Token: 0x04000919 RID: 2329
	private static bool isTweenFinished;

	// Token: 0x0400091A RID: 2330
	private static int j;

	// Token: 0x0400091B RID: 2331
	public static int LISTENERS_MAX;

	// Token: 0x0400091C RID: 2332
	private static int maxTweenReached;

	// Token: 0x0400091D RID: 2333
	private static int maxTweens = 400;

	// Token: 0x0400091E RID: 2334
	private static Vector3 newVect;

	// Token: 0x0400091F RID: 2335
	private static float previousRealTime;

	// Token: 0x04000920 RID: 2336
	private static AnimationCurve punch;

	// Token: 0x04000921 RID: 2337
	private static float ratioPassed;

	// Token: 0x04000922 RID: 2338
	private static AnimationCurve shake;

	// Token: 0x04000923 RID: 2339
	public static int startSearch;

	// Token: 0x04000924 RID: 2340
	public static float tau = 6.283185f;

	// Token: 0x04000925 RID: 2341
	public static bool throwErrors = true;

	// Token: 0x04000926 RID: 2342
	private static float timeTotal;

	// Token: 0x04000927 RID: 2343
	private static Transform trans;

	// Token: 0x04000928 RID: 2344
	private static LTDescr tween;

	// Token: 0x04000929 RID: 2345
	private static TweenAction tweenAction;

	// Token: 0x0400092A RID: 2346
	private static int tweenMaxSearch = -1;

	// Token: 0x0400092B RID: 2347
	private static LTDescr[] tweens;

	// Token: 0x0400092C RID: 2348
	private static int[] tweensFinished;

	// Token: 0x0400092D RID: 2349
	private static float val;

	// Token: 0x0400092E RID: 2350
	public AnimationCurve frameOpenTween;

	// Token: 0x0400092F RID: 2351
	public float frameOpenTime = 0.1f;

	// Token: 0x04000930 RID: 2352
	public AnimationCurve frameCloseTween;

	// Token: 0x04000931 RID: 2353
	public float frameCloseTime = 0.1f;

	// Token: 0x04000932 RID: 2354
	public GameObject frameBlackMask;

	// Token: 0x04000933 RID: 2355
	public AnimationCurve buttonTween;

	// Token: 0x04000934 RID: 2356
	public Vector3 buttonPressScale;

	// Token: 0x04000935 RID: 2357
	public float cameraOrthoSize = 3f;

	// Token: 0x04000936 RID: 2358
	public float LevelUpNotifyDelay = 1f;

	// Token: 0x04000937 RID: 2359
	public float loadWaitTime;

	// Token: 0x04000938 RID: 2360
	public bool useVoteEnterLoadingProtect = true;
}
