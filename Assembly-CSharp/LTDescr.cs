using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200019A RID: 410
public class LTDescr
{
	// Token: 0x06000C94 RID: 3220 RVA: 0x0003E6E2 File Offset: 0x0003CAE2
	public LTDescr cancel()
	{
		LeanTween.removeTween((int)this._id);
		return this;
	}

	// Token: 0x06000C95 RID: 3221 RVA: 0x0003E6F0 File Offset: 0x0003CAF0
	public void init()
	{
		this.hasInitiliazed = true;
		switch (this.type)
		{
		case TweenAction.MOVE_X:
			this.from.x = this.trans.position.x;
			break;
		case TweenAction.MOVE_Y:
			this.from.x = this.trans.position.y;
			break;
		case TweenAction.MOVE_Z:
			this.from.x = this.trans.position.z;
			break;
		case TweenAction.MOVE_LOCAL_X:
			this.from.x = this.trans.localPosition.x;
			break;
		case TweenAction.MOVE_LOCAL_Y:
			this.from.x = this.trans.localPosition.y;
			break;
		case TweenAction.MOVE_LOCAL_Z:
			this.from.x = this.trans.localPosition.z;
			break;
		case TweenAction.MOVE_CURVED:
		case TweenAction.MOVE_CURVED_LOCAL:
		case TweenAction.MOVE_SPLINE:
		case TweenAction.MOVE_SPLINE_LOCAL:
			this.from.x = 0f;
			break;
		case TweenAction.SCALE_X:
			this.from.x = this.trans.localScale.x;
			break;
		case TweenAction.SCALE_Y:
			this.from.x = this.trans.localScale.y;
			break;
		case TweenAction.SCALE_Z:
			this.from.x = this.trans.localScale.z;
			break;
		case TweenAction.ROTATE_X:
			this.from.x = this.trans.eulerAngles.x;
			this.to.x = LeanTween.closestRot(this.from.x, this.to.x);
			break;
		case TweenAction.ROTATE_Y:
			this.from.x = this.trans.eulerAngles.y;
			this.to.x = LeanTween.closestRot(this.from.x, this.to.x);
			break;
		case TweenAction.ROTATE_Z:
			this.from.x = this.trans.eulerAngles.z;
			this.to.x = LeanTween.closestRot(this.from.x, this.to.x);
			break;
		case TweenAction.ROTATE_AROUND:
			this.lastVal = 0f;
			this.from.x = 0f;
			this.origRotation = this.trans.rotation;
			break;
		case TweenAction.ROTATE_AROUND_LOCAL:
			this.lastVal = 0f;
			this.from.x = 0f;
			this.origRotation = this.trans.localRotation;
			break;
		case TweenAction.CANVAS_ROTATEAROUND:
		case TweenAction.CANVAS_ROTATEAROUND_LOCAL:
			this.lastVal = 0f;
			this.from.x = 0f;
			this.origRotation = this.rectTransform.rotation;
			break;
		case TweenAction.CANVAS_PLAYSPRITE:
			this.uiImage = this.trans.gameObject.GetComponent<Image>();
			this.from.x = 0f;
			break;
		case TweenAction.ALPHA:
		{
			SpriteRenderer component = this.trans.gameObject.GetComponent<SpriteRenderer>();
			if (component == null)
			{
				if (this.trans.gameObject.GetComponent<Renderer>() != null && this.trans.gameObject.GetComponent<Renderer>().material.HasProperty("_Color"))
				{
					this.from.x = this.trans.gameObject.GetComponent<Renderer>().material.color.a;
				}
				else if (this.trans.gameObject.GetComponent<Renderer>() != null && this.trans.gameObject.GetComponent<Renderer>().material.HasProperty("_TintColor"))
				{
					this.from.x = this.trans.gameObject.GetComponent<Renderer>().material.GetColor("_TintColor").a;
				}
				else if (this.trans.childCount > 0)
				{
					IEnumerator enumerator = this.trans.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							Transform transform = (Transform)obj;
							if (transform.gameObject.GetComponent<Renderer>() != null)
							{
								this.from.x = transform.gameObject.GetComponent<Renderer>().material.color.a;
								break;
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
			else
			{
				this.from.x = component.color.a;
			}
			break;
		}
		case TweenAction.TEXT_ALPHA:
			this.uiText = this.trans.gameObject.GetComponent<Text>();
			if (this.uiText != null)
			{
				this.from.x = this.uiText.color.a;
			}
			break;
		case TweenAction.CANVAS_ALPHA:
			this.uiImage = this.trans.gameObject.GetComponent<Image>();
			if (this.uiImage != null)
			{
				this.from.x = this.uiImage.color.a;
			}
			break;
		case TweenAction.ALPHA_VERTEX:
			this.from.x = (float)this.trans.GetComponent<MeshFilter>().mesh.colors32[0].a;
			break;
		case TweenAction.COLOR:
			if (this.trans.gameObject.GetComponent<Renderer>() == null || !this.trans.gameObject.GetComponent<Renderer>().material.HasProperty("_Color"))
			{
				if (this.trans.gameObject.GetComponent<Renderer>() != null && this.trans.gameObject.GetComponent<Renderer>().material.HasProperty("_TintColor"))
				{
					Color color = this.trans.gameObject.GetComponent<Renderer>().material.GetColor("_TintColor");
					this.setFromColor(color);
				}
				else if (this.trans.childCount > 0)
				{
					IEnumerator enumerator2 = this.trans.GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							object obj2 = enumerator2.Current;
							Transform transform2 = (Transform)obj2;
							if (transform2.gameObject.GetComponent<Renderer>() != null)
							{
								Color color2 = transform2.gameObject.GetComponent<Renderer>().material.color;
								this.setFromColor(color2);
								break;
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
			else
			{
				Color color3 = this.trans.gameObject.GetComponent<Renderer>().material.color;
				this.setFromColor(color3);
			}
			break;
		case TweenAction.CALLBACK_COLOR:
			this.diff = new Vector3(1f, 0f, 0f);
			break;
		case TweenAction.TEXT_COLOR:
			this.uiText = this.trans.gameObject.GetComponent<Text>();
			if (this.uiText != null)
			{
				this.setFromColor(this.uiText.color);
			}
			break;
		case TweenAction.CANVAS_COLOR:
			this.uiImage = this.trans.gameObject.GetComponent<Image>();
			if (this.uiImage != null)
			{
				this.setFromColor(this.uiImage.color);
			}
			break;
		case TweenAction.CALLBACK:
			if (this.onCompleteOnStart)
			{
				if (this.onComplete == null)
				{
					if (this.onCompleteObject != null)
					{
						this.onCompleteObject(this.onCompleteParam);
					}
				}
				else
				{
					this.onComplete();
				}
			}
			break;
		case TweenAction.MOVE:
			this.from = this.trans.position;
			break;
		case TweenAction.MOVE_LOCAL:
			this.from = this.trans.localPosition;
			break;
		case TweenAction.ROTATE:
		{
			this.from = this.trans.eulerAngles;
			float num = LeanTween.closestRot(this.from.x, this.to.x);
			float num2 = LeanTween.closestRot(this.from.y, this.to.y);
			this.to = new Vector3(num, num2, LeanTween.closestRot(this.from.z, this.to.z));
			break;
		}
		case TweenAction.ROTATE_LOCAL:
		{
			this.from = this.trans.localEulerAngles;
			float num3 = LeanTween.closestRot(this.from.x, this.to.x);
			float num4 = LeanTween.closestRot(this.from.y, this.to.y);
			this.to = new Vector3(num3, num4, LeanTween.closestRot(this.from.z, this.to.z));
			break;
		}
		case TweenAction.SCALE:
			this.from = this.trans.localScale;
			break;
		case TweenAction.GUI_MOVE:
			this.from = new Vector3(this.ltRect.rect.x, this.ltRect.rect.y, 0f);
			break;
		case TweenAction.GUI_MOVE_MARGIN:
			this.from = new Vector2(this.ltRect.margin.x, this.ltRect.margin.y);
			break;
		case TweenAction.GUI_SCALE:
			this.from = new Vector3(this.ltRect.rect.width, this.ltRect.rect.height, 0f);
			break;
		case TweenAction.GUI_ALPHA:
			this.from.x = this.ltRect.alpha;
			break;
		case TweenAction.GUI_ROTATE:
			if (!this.ltRect.rotateEnabled)
			{
				this.ltRect.rotateEnabled = true;
				this.ltRect.resetForRotation();
			}
			this.from.x = this.ltRect.rotation;
			break;
		case TweenAction.CANVAS_MOVE:
			this.from = this.rectTransform.anchoredPosition3D;
			break;
		case TweenAction.CANVAS_SCALE:
			this.from = this.rectTransform.localScale;
			break;
		}
		if (this.type != TweenAction.CALLBACK_COLOR && this.type != TweenAction.COLOR && this.type != TweenAction.TEXT_COLOR && this.type != TweenAction.CANVAS_COLOR)
		{
			this.diff = this.to - this.from;
		}
	}

	// Token: 0x06000C96 RID: 3222 RVA: 0x0003F278 File Offset: 0x0003D678
	public LTDescr pause()
	{
		if (this.direction != 0f)
		{
			this.directionLast = this.direction;
			this.direction = 0f;
		}
		return this;
	}

	// Token: 0x06000C97 RID: 3223 RVA: 0x0003F2A4 File Offset: 0x0003D6A4
	public void reset()
	{
		this.toggle = true;
		this.trans = null;
		this.passed = (this.delay = (this.lastVal = 0f));
		this.hasUpdateCallback = (this.useEstimatedTime = (this.useFrames = (this.hasInitiliazed = (this.onCompleteOnRepeat = (this.destroyOnComplete = (this.onCompleteOnStart = (this.useManualTime = false)))))));
		this.animationCurve = null;
		this.tweenType = LeanTweenType.linear;
		this.loopType = LeanTweenType.once;
		this.loopCount = 0;
		this.direction = (this.directionLast = 1f);
		this.onUpdateFloat = null;
		this.onUpdateVector2 = null;
		this.onUpdateVector3 = null;
		this.onUpdateFloatObject = null;
		this.onUpdateVector3Object = null;
		this.onUpdateColor = null;
		this.onComplete = null;
		this.onCompleteObject = null;
		this.onCompleteParam = null;
		this.point = Vector3.zero;
		this.rectTransform = null;
		this.uiText = null;
		this.uiImage = null;
		this.sprites = null;
		LTDescr.global_counter += 1U;
		if (LTDescr.global_counter > 32768U)
		{
			LTDescr.global_counter = 0U;
		}
	}

	// Token: 0x06000C98 RID: 3224 RVA: 0x0003F3DA File Offset: 0x0003D7DA
	public LTDescr resume()
	{
		this.direction = this.directionLast;
		return this;
	}

	// Token: 0x06000C99 RID: 3225 RVA: 0x0003F3E9 File Offset: 0x0003D7E9
	public LTDescr setAudio(object audio)
	{
		this.onCompleteParam = audio;
		return this;
	}

	// Token: 0x06000C9A RID: 3226 RVA: 0x0003F3F3 File Offset: 0x0003D7F3
	public LTDescr setAxis(Vector3 axis)
	{
		this.axis = axis;
		return this;
	}

	// Token: 0x06000C9B RID: 3227 RVA: 0x0003F3FD File Offset: 0x0003D7FD
	public LTDescr setDelay(float delay)
	{
		if (this.useEstimatedTime)
		{
			this.delay = delay;
		}
		else
		{
			this.delay = delay;
		}
		return this;
	}

	// Token: 0x06000C9C RID: 3228 RVA: 0x0003F41E File Offset: 0x0003D81E
	public LTDescr setDestroyOnComplete(bool doesDestroy)
	{
		this.destroyOnComplete = doesDestroy;
		return this;
	}

	// Token: 0x06000C9D RID: 3229 RVA: 0x0003F428 File Offset: 0x0003D828
	public LTDescr setDiff(Vector3 diff)
	{
		this.diff = diff;
		return this;
	}

	// Token: 0x06000C9E RID: 3230 RVA: 0x0003F432 File Offset: 0x0003D832
	public LTDescr setEase(LeanTweenType easeType)
	{
		this.tweenType = easeType;
		return this;
	}

	// Token: 0x06000C9F RID: 3231 RVA: 0x0003F43C File Offset: 0x0003D83C
	public LTDescr setEase(AnimationCurve easeCurve)
	{
		this.animationCurve = easeCurve;
		return this;
	}

	// Token: 0x06000CA0 RID: 3232 RVA: 0x0003F446 File Offset: 0x0003D846
	public LTDescr setFrameRate(float frameRate)
	{
		this.time = (float)this.sprites.Length / frameRate;
		return this;
	}

	// Token: 0x06000CA1 RID: 3233 RVA: 0x0003F45A File Offset: 0x0003D85A
	public LTDescr setFrom(float from)
	{
		return this.setFrom(new Vector3(from, 0f, 0f));
	}

	// Token: 0x06000CA2 RID: 3234 RVA: 0x0003F472 File Offset: 0x0003D872
	public LTDescr setFrom(Vector3 from)
	{
		if (this.trans != null)
		{
			this.init();
		}
		this.from = from;
		this.diff = this.to - this.from;
		return this;
	}

	// Token: 0x06000CA3 RID: 3235 RVA: 0x0003F4AC File Offset: 0x0003D8AC
	public LTDescr setFromColor(Color col)
	{
		this.from = new Vector3(0f, col.a, 0f);
		this.diff = new Vector3(1f, 0f, 0f);
		this.axis = new Vector3(col.r, col.g, col.b);
		return this;
	}

	// Token: 0x06000CA4 RID: 3236 RVA: 0x0003F510 File Offset: 0x0003D910
	public LTDescr setHasInitialized(bool has)
	{
		this.hasInitiliazed = has;
		return this;
	}

	// Token: 0x06000CA5 RID: 3237 RVA: 0x0003F51A File Offset: 0x0003D91A
	public LTDescr setId(uint id)
	{
		this._id = id;
		this.counter = LTDescr.global_counter;
		return this;
	}

	// Token: 0x06000CA6 RID: 3238 RVA: 0x0003F52F File Offset: 0x0003D92F
	public LTDescr setLoopClamp()
	{
		this.loopType = LeanTweenType.clamp;
		if (this.loopCount == 0)
		{
			this.loopCount = -1;
		}
		return this;
	}

	// Token: 0x06000CA7 RID: 3239 RVA: 0x0003F54C File Offset: 0x0003D94C
	public LTDescr setLoopCount(int loopCount)
	{
		this.loopCount = loopCount;
		return this;
	}

	// Token: 0x06000CA8 RID: 3240 RVA: 0x0003F556 File Offset: 0x0003D956
	public LTDescr setLoopOnce()
	{
		this.loopType = LeanTweenType.once;
		return this;
	}

	// Token: 0x06000CA9 RID: 3241 RVA: 0x0003F561 File Offset: 0x0003D961
	public LTDescr setLoopPingPong()
	{
		this.loopType = LeanTweenType.pingPong;
		if (this.loopCount == 0)
		{
			this.loopCount = -1;
		}
		return this;
	}

	// Token: 0x06000CAA RID: 3242 RVA: 0x0003F57E File Offset: 0x0003D97E
	public LTDescr setLoopType(LeanTweenType loopType)
	{
		this.loopType = loopType;
		return this;
	}

	// Token: 0x06000CAB RID: 3243 RVA: 0x0003F588 File Offset: 0x0003D988
	public LTDescr setOnComplete(Action onComplete)
	{
		this.onComplete = onComplete;
		return this;
	}

	// Token: 0x06000CAC RID: 3244 RVA: 0x0003F592 File Offset: 0x0003D992
	public LTDescr setOnComplete(Action<object> onComplete)
	{
		this.onCompleteObject = onComplete;
		return this;
	}

	// Token: 0x06000CAD RID: 3245 RVA: 0x0003F59C File Offset: 0x0003D99C
	public LTDescr setOnComplete(Action<object> onComplete, object onCompleteParam)
	{
		this.onCompleteObject = onComplete;
		if (onCompleteParam != null)
		{
			this.onCompleteParam = onCompleteParam;
		}
		return this;
	}

	// Token: 0x06000CAE RID: 3246 RVA: 0x0003F5B3 File Offset: 0x0003D9B3
	public LTDescr setOnCompleteOnRepeat(bool isOn)
	{
		this.onCompleteOnRepeat = isOn;
		return this;
	}

	// Token: 0x06000CAF RID: 3247 RVA: 0x0003F5BD File Offset: 0x0003D9BD
	public LTDescr setOnCompleteOnStart(bool isOn)
	{
		this.onCompleteOnStart = isOn;
		return this;
	}

	// Token: 0x06000CB0 RID: 3248 RVA: 0x0003F5C7 File Offset: 0x0003D9C7
	public LTDescr setOnCompleteParam(object onCompleteParam)
	{
		this.onCompleteParam = onCompleteParam;
		return this;
	}

	// Token: 0x06000CB1 RID: 3249 RVA: 0x0003F5D1 File Offset: 0x0003D9D1
	public LTDescr setOnUpdate(Action<float> onUpdate)
	{
		this.onUpdateFloat = onUpdate;
		this.hasUpdateCallback = true;
		return this;
	}

	// Token: 0x06000CB2 RID: 3250 RVA: 0x0003F5E2 File Offset: 0x0003D9E2
	public LTDescr setOnUpdate(Action<Color> onUpdate)
	{
		this.onUpdateColor = onUpdate;
		this.hasUpdateCallback = true;
		return this;
	}

	// Token: 0x06000CB3 RID: 3251 RVA: 0x0003F5F3 File Offset: 0x0003D9F3
	public LTDescr setOnUpdate(Action<Vector2> onUpdate, object onUpdateParam = null)
	{
		this.onUpdateVector2 = onUpdate;
		this.hasUpdateCallback = true;
		if (onUpdateParam != null)
		{
			this.onUpdateParam = onUpdateParam;
		}
		return this;
	}

	// Token: 0x06000CB4 RID: 3252 RVA: 0x0003F611 File Offset: 0x0003DA11
	public LTDescr setOnUpdate(Action<Vector3> onUpdate, object onUpdateParam = null)
	{
		this.onUpdateVector3 = onUpdate;
		this.hasUpdateCallback = true;
		if (onUpdateParam != null)
		{
			this.onUpdateParam = onUpdateParam;
		}
		return this;
	}

	// Token: 0x06000CB5 RID: 3253 RVA: 0x0003F62F File Offset: 0x0003DA2F
	public LTDescr setOnUpdate(Action<float, object> onUpdate, object onUpdateParam = null)
	{
		this.onUpdateFloatObject = onUpdate;
		this.hasUpdateCallback = true;
		if (onUpdateParam != null)
		{
			this.onUpdateParam = onUpdateParam;
		}
		return this;
	}

	// Token: 0x06000CB6 RID: 3254 RVA: 0x0003F64D File Offset: 0x0003DA4D
	public LTDescr setOnUpdate(Action<Vector3, object> onUpdate, object onUpdateParam = null)
	{
		this.onUpdateVector3Object = onUpdate;
		this.hasUpdateCallback = true;
		if (onUpdateParam != null)
		{
			this.onUpdateParam = onUpdateParam;
		}
		return this;
	}

	// Token: 0x06000CB7 RID: 3255 RVA: 0x0003F66B File Offset: 0x0003DA6B
	public LTDescr setOnUpdateColor(Action<Color> onUpdate)
	{
		this.onUpdateColor = onUpdate;
		this.hasUpdateCallback = true;
		return this;
	}

	// Token: 0x06000CB8 RID: 3256 RVA: 0x0003F67C File Offset: 0x0003DA7C
	public LTDescr setOnUpdateObject(Action<float, object> onUpdate)
	{
		this.onUpdateFloatObject = onUpdate;
		this.hasUpdateCallback = true;
		return this;
	}

	// Token: 0x06000CB9 RID: 3257 RVA: 0x0003F68D File Offset: 0x0003DA8D
	public LTDescr setOnUpdateParam(object onUpdateParam)
	{
		this.onUpdateParam = onUpdateParam;
		return this;
	}

	// Token: 0x06000CBA RID: 3258 RVA: 0x0003F697 File Offset: 0x0003DA97
	public LTDescr setOnUpdateVector2(Action<Vector2> onUpdate)
	{
		this.onUpdateVector2 = onUpdate;
		this.hasUpdateCallback = true;
		return this;
	}

	// Token: 0x06000CBB RID: 3259 RVA: 0x0003F6A8 File Offset: 0x0003DAA8
	public LTDescr setOnUpdateVector3(Action<Vector3> onUpdate)
	{
		this.onUpdateVector3 = onUpdate;
		this.hasUpdateCallback = true;
		return this;
	}

	// Token: 0x06000CBC RID: 3260 RVA: 0x0003F6BC File Offset: 0x0003DABC
	public LTDescr setOrientToPath(bool doesOrient)
	{
		if (this.type == TweenAction.MOVE_CURVED || this.type == TweenAction.MOVE_CURVED_LOCAL)
		{
			if (this.path == null)
			{
				this.path = new LTBezierPath();
			}
			this.path.orientToPath = doesOrient;
		}
		else
		{
			this.spline.orientToPath = doesOrient;
		}
		return this;
	}

	// Token: 0x06000CBD RID: 3261 RVA: 0x0003F715 File Offset: 0x0003DB15
	public LTDescr setOrientToPath2d(bool doesOrient2d)
	{
		this.setOrientToPath(doesOrient2d);
		if (this.type == TweenAction.MOVE_CURVED || this.type == TweenAction.MOVE_CURVED_LOCAL)
		{
			this.path.orientToPath2d = doesOrient2d;
		}
		else
		{
			this.spline.orientToPath2d = doesOrient2d;
		}
		return this;
	}

	// Token: 0x06000CBE RID: 3262 RVA: 0x0003F755 File Offset: 0x0003DB55
	public LTDescr setPath(LTBezierPath path)
	{
		this.path = path;
		return this;
	}

	// Token: 0x06000CBF RID: 3263 RVA: 0x0003F75F File Offset: 0x0003DB5F
	public LTDescr setPoint(Vector3 point)
	{
		this.point = point;
		return this;
	}

	// Token: 0x06000CC0 RID: 3264 RVA: 0x0003F769 File Offset: 0x0003DB69
	public LTDescr setRect(LTRect rect)
	{
		this.ltRect = rect;
		return this;
	}

	// Token: 0x06000CC1 RID: 3265 RVA: 0x0003F773 File Offset: 0x0003DB73
	public LTDescr setRect(Rect rect)
	{
		this.ltRect = new LTRect(rect);
		return this;
	}

	// Token: 0x06000CC2 RID: 3266 RVA: 0x0003F782 File Offset: 0x0003DB82
	public LTDescr setRect(RectTransform rect)
	{
		this.rectTransform = rect;
		return this;
	}

	// Token: 0x06000CC3 RID: 3267 RVA: 0x0003F78C File Offset: 0x0003DB8C
	public LTDescr setRepeat(int repeat)
	{
		this.loopCount = repeat;
		if ((repeat > 1 && this.loopType == LeanTweenType.once) || (repeat < 0 && this.loopType == LeanTweenType.once))
		{
			this.loopType = LeanTweenType.clamp;
		}
		if (this.type == TweenAction.CALLBACK || this.type == TweenAction.CALLBACK_COLOR)
		{
			this.setOnCompleteOnRepeat(true);
		}
		return this;
	}

	// Token: 0x06000CC4 RID: 3268 RVA: 0x0003F7F3 File Offset: 0x0003DBF3
	public LTDescr setSprites(Sprite[] sprites)
	{
		this.sprites = sprites;
		return this;
	}

	// Token: 0x06000CC5 RID: 3269 RVA: 0x0003F7FD File Offset: 0x0003DBFD
	public LTDescr setTime(float time)
	{
		this.time = time;
		return this;
	}

	// Token: 0x06000CC6 RID: 3270 RVA: 0x0003F807 File Offset: 0x0003DC07
	public LTDescr setTo(Vector3 to)
	{
		if (this.hasInitiliazed)
		{
			this.to = to;
			this.diff = to - this.from;
		}
		else
		{
			this.to = to;
		}
		return this;
	}

	// Token: 0x06000CC7 RID: 3271 RVA: 0x0003F83A File Offset: 0x0003DC3A
	public LTDescr setUseEstimatedTime(bool useEstimatedTime)
	{
		this.useEstimatedTime = useEstimatedTime;
		return this;
	}

	// Token: 0x06000CC8 RID: 3272 RVA: 0x0003F844 File Offset: 0x0003DC44
	public LTDescr setUseFrames(bool useFrames)
	{
		this.useFrames = useFrames;
		return this;
	}

	// Token: 0x06000CC9 RID: 3273 RVA: 0x0003F84E File Offset: 0x0003DC4E
	public LTDescr setUseManualTime(bool useManualTime)
	{
		this.useManualTime = useManualTime;
		return this;
	}

	// Token: 0x06000CCA RID: 3274 RVA: 0x0003F858 File Offset: 0x0003DC58
	public override string ToString()
	{
		object[] args = new object[]
		{
			(!(this.trans == null)) ? ("gameObject:" + this.trans.gameObject) : "gameObject:null",
			" toggle:",
			this.toggle,
			" passed:",
			this.passed,
			" time:",
			this.time,
			" delay:",
			this.delay,
			" from:",
			this.from,
			" to:",
			this.to,
			" type:",
			this.type,
			" ease:",
			this.tweenType,
			" useEstimatedTime:",
			this.useEstimatedTime,
			" id:",
			this.id,
			" hasInitiliazed:",
			this.hasInitiliazed
		};
		return string.Concat(args);
	}

	// Token: 0x170001DA RID: 474
	// (get) Token: 0x06000CCB RID: 3275 RVA: 0x0003F9A6 File Offset: 0x0003DDA6
	public int id
	{
		get
		{
			return this.uniqueId;
		}
	}

	// Token: 0x170001DB RID: 475
	// (get) Token: 0x06000CCC RID: 3276 RVA: 0x0003F9B0 File Offset: 0x0003DDB0
	public int uniqueId
	{
		get
		{
			return (int)(this._id | this.counter << 16);
		}
	}

	// Token: 0x040008AA RID: 2218
	private uint _id;

	// Token: 0x040008AB RID: 2219
	public AnimationCurve animationCurve;

	// Token: 0x040008AC RID: 2220
	public Vector3 axis;

	// Token: 0x040008AD RID: 2221
	public uint counter;

	// Token: 0x040008AE RID: 2222
	public float delay;

	// Token: 0x040008AF RID: 2223
	public bool destroyOnComplete;

	// Token: 0x040008B0 RID: 2224
	public Vector3 diff;

	// Token: 0x040008B1 RID: 2225
	public float direction;

	// Token: 0x040008B2 RID: 2226
	public float directionLast;

	// Token: 0x040008B3 RID: 2227
	public Vector3 from;

	// Token: 0x040008B4 RID: 2228
	private static uint global_counter;

	// Token: 0x040008B5 RID: 2229
	public bool hasInitiliazed;

	// Token: 0x040008B6 RID: 2230
	public bool hasPhysics;

	// Token: 0x040008B7 RID: 2231
	public bool hasUpdateCallback;

	// Token: 0x040008B8 RID: 2232
	public float lastVal;

	// Token: 0x040008B9 RID: 2233
	public int loopCount;

	// Token: 0x040008BA RID: 2234
	public LeanTweenType loopType;

	// Token: 0x040008BB RID: 2235
	public LTRect ltRect;

	// Token: 0x040008BC RID: 2236
	public Action onComplete;

	// Token: 0x040008BD RID: 2237
	public Action<object> onCompleteObject;

	// Token: 0x040008BE RID: 2238
	public bool onCompleteOnRepeat;

	// Token: 0x040008BF RID: 2239
	public bool onCompleteOnStart;

	// Token: 0x040008C0 RID: 2240
	public object onCompleteParam;

	// Token: 0x040008C1 RID: 2241
	public Action<Color> onUpdateColor;

	// Token: 0x040008C2 RID: 2242
	public Action<float> onUpdateFloat;

	// Token: 0x040008C3 RID: 2243
	public Action<float, object> onUpdateFloatObject;

	// Token: 0x040008C4 RID: 2244
	public object onUpdateParam;

	// Token: 0x040008C5 RID: 2245
	public Action<Vector2> onUpdateVector2;

	// Token: 0x040008C6 RID: 2246
	public Action<Vector3> onUpdateVector3;

	// Token: 0x040008C7 RID: 2247
	public Action<Vector3, object> onUpdateVector3Object;

	// Token: 0x040008C8 RID: 2248
	public Quaternion origRotation;

	// Token: 0x040008C9 RID: 2249
	public float passed;

	// Token: 0x040008CA RID: 2250
	public LTBezierPath path;

	// Token: 0x040008CB RID: 2251
	public Vector3 point;

	// Token: 0x040008CC RID: 2252
	public RectTransform rectTransform;

	// Token: 0x040008CD RID: 2253
	public LTSpline spline;

	// Token: 0x040008CE RID: 2254
	public Sprite[] sprites;

	// Token: 0x040008CF RID: 2255
	public float time;

	// Token: 0x040008D0 RID: 2256
	public Vector3 to;

	// Token: 0x040008D1 RID: 2257
	public bool toggle;

	// Token: 0x040008D2 RID: 2258
	public Transform trans;

	// Token: 0x040008D3 RID: 2259
	public LeanTweenType tweenType;

	// Token: 0x040008D4 RID: 2260
	public TweenAction type;

	// Token: 0x040008D5 RID: 2261
	public Image uiImage;

	// Token: 0x040008D6 RID: 2262
	public Text uiText;

	// Token: 0x040008D7 RID: 2263
	public bool useEstimatedTime;

	// Token: 0x040008D8 RID: 2264
	public bool useFrames;

	// Token: 0x040008D9 RID: 2265
	public bool useManualTime;
}
