using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001424 RID: 5156
	[ExecuteInEditMode]
	public class AdventureTeamPassBlessExpPoolBind : MonoBehaviour
	{
		// Token: 0x0600C7F2 RID: 51186 RVA: 0x0030719C File Offset: 0x0030559C
		private void Awake()
		{
			this._InitView();
		}

		// Token: 0x0600C7F3 RID: 51187 RVA: 0x003071A4 File Offset: 0x003055A4
		private void OnDestroy()
		{
			this.bExpPoolIdleEffectInited = false;
			this.bExpPoolRiseupEffectInited = false;
			this.bExpPoolFillupEffectInited = false;
			this.bExpPoolFullFlyingEffectInited = false;
			this.mExpPoolIdle = null;
			this.mExpPoolRiseup = null;
			this.mExpPoolFillup = null;
			this.mExpPoolFullFlying = null;
			this.mExpPoolLiquidRen = null;
			this.mExpPoolLiquidMat = null;
			this.totalFlyPathPointCount = 0;
			this.totalflyPathPostions = null;
			this.isFlying = false;
			if (this.flyTween != null)
			{
				TweenExtensions.Kill(this.flyTween, false);
			}
			this.flyTween = null;
			this.flyTarget = null;
			if (this.waitToRiseupExp != null)
			{
				base.StopCoroutine(this.waitToRiseupExp);
				this.waitToRiseupExp = null;
			}
			this._RemoveAllDelegateHandler(this.ExpRiseupToFullHandler);
			this._RemoveAllDelegateHandler(this.ExpRiseupStartHandler);
			this._RemoveAllDelegateHandler(this.ExpFlyToTargetHandler);
			this._RemoveAllDelegateHandler(this.ExpRiseupEndHandler);
			this.tr_exp_percent_format = string.Empty;
			if (this.waitToPlayExpFullEffect != null)
			{
				base.StopCoroutine(this.waitToPlayExpFullEffect);
				this.waitToPlayExpFullEffect = null;
			}
			if (this.waitToPlayExpRiseupEffect != null)
			{
				base.StopCoroutine(this.waitToPlayExpRiseupEffect);
				this.waitToPlayExpRiseupEffect = null;
			}
		}

		// Token: 0x0600C7F4 RID: 51188 RVA: 0x003072C8 File Offset: 0x003056C8
		private void _RemoveAllDelegateHandler(Action handler)
		{
			if (handler != null)
			{
				Delegate[] invocationList = handler.GetInvocationList();
				if (invocationList != null)
				{
					for (int i = 0; i < invocationList.Length; i++)
					{
						handler = (Action)Delegate.Remove(handler, invocationList[i] as Action);
					}
				}
			}
			handler = null;
		}

		// Token: 0x0600C7F5 RID: 51189 RVA: 0x00307314 File Offset: 0x00305714
		private void _InitView()
		{
			if (this.mHalfPoolLiguidAnimCurve != null && this.mHalfPoolLiguidAnimCurve.length > 0)
			{
				this.mEmptyPoolLiquidHeight = this.mHalfPoolLiguidAnimCurve[0].value;
				this.mFullPoolLiquidHeight = this.mHalfPoolLiguidAnimCurve[this.mHalfPoolLiguidAnimCurve.length - 1].value;
			}
			this.totalFlyPathPointCount = this.flyPathPointCount + 1;
			this.totalflyPathPostions = new Vector3[this.totalFlyPathPointCount];
			this.tr_exp_percent_format = TR.Value("adventure_team_pass_bless_get_exp_percent");
		}

		// Token: 0x0600C7F6 RID: 51190 RVA: 0x003073AC File Offset: 0x003057AC
		private GameObject _LoadEffectByResPath(string effectPath)
		{
			GameObject result = null;
			if (string.IsNullOrEmpty(effectPath))
			{
				return result;
			}
			return Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(effectPath, true, 0U);
		}

		// Token: 0x0600C7F7 RID: 51191 RVA: 0x003073D8 File Offset: 0x003057D8
		public void InitExpPoolIdleEffect()
		{
			if (this.bExpPoolIdleEffectInited)
			{
				return;
			}
			this.mExpPoolIdle = this._LoadEffectByResPath("Effects/UI/Prefab/EffUI_yongbingtuan/Prefab/EffUI_yongbingtuan_daiji");
			Utility.AttachTo(this.mExpPoolIdle, this.mEffectsRoot, false);
			if (this.mExpPoolIdle != null && this.mExpPoolIdle.transform.childCount > 0)
			{
				Transform child = this.mExpPoolIdle.transform.GetChild(0);
				if (child != null)
				{
					this.mExpPoolLiquidRen = child.GetComponent<MeshRenderer>();
					if (this.mExpPoolLiquidRen != null)
					{
						this.mExpPoolLiquidMat = this.mExpPoolLiquidRen.material;
					}
					this._ControlExpHeight(this.mEmptyPoolLiquidHeight);
				}
			}
			this.mExpPoolIdle.CustomActive(true);
			this.bExpPoolIdleEffectInited = true;
		}

		// Token: 0x0600C7F8 RID: 51192 RVA: 0x003074A8 File Offset: 0x003058A8
		public void StartExpRiseupToHeight(int startPercent, int endPercent, bool fakePlayAnim = false)
		{
			float num = this._GetHeightByPercent((float)startPercent / 100f);
			float num2 = this._GetHeightByPercent((float)endPercent / 100f);
			float num3 = num2 - num;
			num3 = ((num3 < 0f) ? (-num3) : num3);
			if (num3 <= 0.001f)
			{
				this._ControlExpHeight(num2);
				this._SetPercentText(endPercent.ToString());
			}
			else
			{
				this._ControlExpHeight(num);
				this._SetPercentText(startPercent.ToString());
				if (this.waitToRiseupExp != null)
				{
					base.StopCoroutine(this.waitToRiseupExp);
				}
				if (endPercent > startPercent && this.ExpRiseupStartHandler != null)
				{
					this.ExpRiseupStartHandler();
				}
				this.waitToRiseupExp = base.StartCoroutine(this._WaitToRiseupExp(startPercent, endPercent));
				if (!fakePlayAnim && this.ExpRiseupEndHandler != null)
				{
					this.ExpRiseupEndHandler();
				}
			}
		}

		// Token: 0x0600C7F9 RID: 51193 RVA: 0x00307598 File Offset: 0x00305998
		private IEnumerator _WaitToRiseupExp(int startPercent, int endPercent)
		{
			int deltaPercent = endPercent - startPercent;
			bool bAddup = true;
			if (deltaPercent < 0)
			{
				bAddup = false;
			}
			int tempPercent = startPercent;
			float ftempPercent = 0f;
			deltaPercent = ((deltaPercent <= 0) ? (-deltaPercent) : deltaPercent);
			if (deltaPercent == 0)
			{
				yield break;
			}
			float duration = 0f;
			if (bAddup)
			{
				duration = this.mPoolLiquidRiseupTime / (float)deltaPercent;
			}
			else
			{
				duration = this.mPoolLiquidGrowdownTime / (float)deltaPercent;
			}
			while (deltaPercent != 0 && tempPercent <= 100 && tempPercent >= 0)
			{
				if (bAddup)
				{
					tempPercent++;
					if (tempPercent == 100)
					{
						if (this.ExpRiseupToFullHandler != null)
						{
							this.ExpRiseupToFullHandler();
						}
					}
					else if (tempPercent > 100)
					{
						yield break;
					}
				}
				else
				{
					tempPercent--;
					if (tempPercent < 0)
					{
						yield break;
					}
				}
				this._SetPercentText(tempPercent.ToString());
				ftempPercent = (float)tempPercent / 100f;
				this._ControlExpHeight(this._GetHeightByPercent(ftempPercent));
				deltaPercent = endPercent - tempPercent;
				yield return Yielders.GetWaitForSeconds(duration);
			}
			yield break;
		}

		// Token: 0x0600C7FA RID: 51194 RVA: 0x003075C4 File Offset: 0x003059C4
		private float _GetHeightByPercent(float percent)
		{
			if (percent > 1f)
			{
				percent = 1f;
			}
			else if (percent < 0f)
			{
				percent = 0f;
			}
			if (this.mHalfPoolLiguidAnimCurve != null)
			{
				return this.mHalfPoolLiguidAnimCurve.Evaluate(percent);
			}
			return 0f;
		}

		// Token: 0x0600C7FB RID: 51195 RVA: 0x00307618 File Offset: 0x00305A18
		private void _ControlExpHeight(float height)
		{
			if (height < this.mEmptyPoolLiquidHeight)
			{
				height = this.mEmptyPoolLiquidHeight;
			}
			if (height > this.mFullPoolLiquidHeight)
			{
				height = this.mFullPoolLiquidHeight;
			}
			if (this.mExpPoolLiquidMat != null)
			{
				this.mExpPoolLiquidMat.SetFloat("_Quantity", height);
			}
		}

		// Token: 0x0600C7FC RID: 51196 RVA: 0x0030766F File Offset: 0x00305A6F
		private void _SetPercentText(string percent)
		{
			if (this.mPoolLiquidPercentText)
			{
				this.mPoolLiquidPercentText.text = string.Format(this.tr_exp_percent_format, percent);
			}
		}

		// Token: 0x0600C7FD RID: 51197 RVA: 0x00307698 File Offset: 0x00305A98
		public void InitExpPoolRiseupEffect()
		{
			if (this.bExpPoolRiseupEffectInited)
			{
				return;
			}
			this.mExpPoolRiseup = this._LoadEffectByResPath("Effects/UI/Prefab/EffUI_yongbingtuan/Prefab/EffUI_yongbingtuan_yaojizengzhang");
			this.mExpPoolRiseup.CustomActive(false);
			Utility.AttachTo(this.mExpPoolRiseup, this.mEffectsRoot, false);
			this.bExpPoolRiseupEffectInited = true;
		}

		// Token: 0x0600C7FE RID: 51198 RVA: 0x003076E8 File Offset: 0x00305AE8
		public void SetExpPoolRiseupShow(bool bShow)
		{
			if (this.mExpPoolRiseup)
			{
				if (!bShow)
				{
					this.mExpPoolRiseup.CustomActive(false);
				}
				else
				{
					if (this.waitToPlayExpRiseupEffect != null)
					{
						base.StopCoroutine(this.waitToPlayExpRiseupEffect);
					}
					this.waitToPlayExpRiseupEffect = base.StartCoroutine(this._WaitToPlayExpRiseupEffect());
				}
			}
		}

		// Token: 0x0600C7FF RID: 51199 RVA: 0x00307748 File Offset: 0x00305B48
		private IEnumerator _WaitToPlayExpRiseupEffect()
		{
			this.mExpPoolRiseup.CustomActive(false);
			this.mExpPoolRiseup.CustomActive(true);
			yield return Yielders.GetWaitForSeconds(this.mEffectExpRiseupDuration);
			this.mExpPoolRiseup.CustomActive(false);
			yield break;
		}

		// Token: 0x0600C800 RID: 51200 RVA: 0x00307764 File Offset: 0x00305B64
		public void InitExpPoolFillupEffect()
		{
			if (this.bExpPoolFillupEffectInited)
			{
				return;
			}
			this.mExpPoolFillup = this._LoadEffectByResPath("Effects/UI/Prefab/EffUI_yongbingtuan/Prefab/EffUI_yongbingtuan_manpin");
			this.mExpPoolFillup.CustomActive(false);
			Utility.AttachTo(this.mExpPoolFillup, this.mEffectsRoot, false);
			this.bExpPoolFillupEffectInited = true;
		}

		// Token: 0x0600C801 RID: 51201 RVA: 0x003077B4 File Offset: 0x00305BB4
		public void SetExpPoolFillupShow(bool bShow)
		{
			if (this.mExpPoolFillup)
			{
				if (!bShow)
				{
					this.mExpPoolFillup.CustomActive(false);
				}
				else
				{
					if (this.waitToPlayExpFullEffect != null)
					{
						base.StopCoroutine(this.waitToPlayExpFullEffect);
					}
					this.waitToPlayExpFullEffect = base.StartCoroutine(this._WaitToPlayExpFullEffect());
				}
			}
		}

		// Token: 0x0600C802 RID: 51202 RVA: 0x00307814 File Offset: 0x00305C14
		private IEnumerator _WaitToPlayExpFullEffect()
		{
			this.mExpPoolFillup.CustomActive(false);
			this.mExpPoolFillup.CustomActive(true);
			yield return Yielders.GetWaitForSeconds(this.mEffectExpFullDuration);
			this.mExpPoolFillup.CustomActive(false);
			yield break;
		}

		// Token: 0x0600C803 RID: 51203 RVA: 0x00307830 File Offset: 0x00305C30
		public void InitExpPoolFullFlyingEffect()
		{
			if (this.bExpPoolFullFlyingEffectInited)
			{
				return;
			}
			this.mExpPoolFullFlying = this._LoadEffectByResPath("Effects/UI/Prefab/EffUI_yongbingtuan/Prefab/EffUI_yongbingtuan_feixing");
			this.mExpPoolFullFlying.CustomActive(false);
			Utility.AttachTo(this.mExpPoolFullFlying, this.mEffectsRoot, false);
			this.bExpPoolFullFlyingEffectInited = true;
		}

		// Token: 0x0600C804 RID: 51204 RVA: 0x00307880 File Offset: 0x00305C80
		public void StartFullExpFlyingToTarget(GameObject flyTarget)
		{
			if (this.mExpPoolFullFlying == null || this.flyStartPoint == null || flyTarget == null)
			{
				return;
			}
			this.flyTarget = flyTarget;
			Vector3 position = this.flyStartPoint.transform.position;
			Vector3 position2 = flyTarget.transform.position;
			for (int i = 0; i < this.totalFlyPathPointCount; i++)
			{
				Vector3 vector = this.SampleParabola(position, position2, this.flyPathRadian, (float)i / (float)this.flyPathPointCount);
				if (this.totalflyPathPostions != null && this.totalflyPathPostions.Length >= this.totalFlyPathPointCount)
				{
					this.totalflyPathPostions[i] = vector;
				}
			}
			if (this.totalflyPathPostions != null && this.totalflyPathPostions.Length > 0)
			{
				if (this.flyTween != null)
				{
					TweenExtensions.Kill(this.flyTween, false);
				}
				this.mExpPoolFullFlying.transform.position = position;
				this.flyTween = TweenSettingsExtensions.OnComplete<TweenerCore<Vector3, Path, PathOptions>>(TweenSettingsExtensions.OnStart<TweenerCore<Vector3, Path, PathOptions>>(TweenSettingsExtensions.SetDelay<TweenerCore<Vector3, Path, PathOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Path, PathOptions>>(ShortcutExtensions.DOPath(this.mExpPoolFullFlying.transform, this.totalflyPathPostions, this.flyDuration, 1, 3, 5, new Color?(Color.red)), this.flyEaseCurveType), this.flyDelayTime), new TweenCallback(this._OnFlyToTargetStart)), new TweenCallback(this._OnFlyToTargetCompete));
			}
		}

		// Token: 0x0600C805 RID: 51205 RVA: 0x003079E8 File Offset: 0x00305DE8
		private void _OnFlyToTargetStart()
		{
			this.isFlying = true;
			this.mExpPoolFullFlying.CustomActive(true);
		}

		// Token: 0x0600C806 RID: 51206 RVA: 0x003079FD File Offset: 0x00305DFD
		private void _OnFlyToTargetCompete()
		{
			this.mExpPoolFullFlying.CustomActive(false);
			this.isFlying = false;
			if (this.ExpFlyToTargetHandler != null)
			{
				this.ExpFlyToTargetHandler();
			}
		}

		// Token: 0x0600C807 RID: 51207 RVA: 0x00307A28 File Offset: 0x00305E28
		private void OnDrawGizmos()
		{
			if (this.flyStartPoint == null || this.flyTarget == null)
			{
				return;
			}
			Vector3 position = this.flyStartPoint.transform.position;
			Vector3 position2 = this.flyTarget.transform.position;
			Gizmos.color = Color.red;
			Gizmos.DrawLine(position, position2);
			Vector3 vector = position;
			for (float num = 0f; num < (float)(this.flyPathPointCount + 1); num += 1f)
			{
				if (this.flyPathPointCount == 0)
				{
					return;
				}
				Vector3 vector2 = this.SampleParabola(position, position2, this.flyPathRadian, num / (float)this.flyPathPointCount);
				Gizmos.color = ((num % 2f != 0f) ? Color.green : Color.blue);
				Gizmos.DrawLine(vector, vector2);
				vector = vector2;
			}
		}

		// Token: 0x0600C808 RID: 51208 RVA: 0x00307B04 File Offset: 0x00305F04
		private Vector3 SampleParabola(Vector3 start, Vector3 end, float height, float t)
		{
			float num = t * 2f - 1f;
			if (Mathf.Abs(start.y - end.y) < 0.1f)
			{
				Vector3 vector = end - start;
				Vector3 result = start + t * vector;
				result.y += (-num * num + 1f) * height;
				return result;
			}
			Vector3 vector2 = end - start;
			Vector3 vector3 = end - new Vector3(start.x, end.y, start.z);
			Vector3 vector4 = Vector3.Cross(vector2, vector3);
			Vector3 vector5 = Vector3.Cross(vector4, vector2);
			if (end.y > start.y)
			{
				vector5 = -vector5;
			}
			Vector3 vector6 = start + t * vector2;
			return vector6 + (-num * num + 1f) * height * vector5.normalized;
		}

		// Token: 0x0600C809 RID: 51209 RVA: 0x00307C00 File Offset: 0x00306000
		public Vector3 Parabola(Vector3 start, Vector3 end, float height, float t)
		{
			Func<float, float> func = (float x) => -4f * height * x * x + 4f * height * x;
			Vector3 vector = Vector3.Lerp(start, end, t);
			return new Vector3(vector.x, func(t) + Mathf.Lerp(start.y, end.y, t), vector.z);
		}

		// Token: 0x0600C80A RID: 51210 RVA: 0x00307C64 File Offset: 0x00306064
		public Vector2 Parabola(Vector2 start, Vector2 end, float height, float t)
		{
			Func<float, float> func = (float x) => -4f * height * x * x + 4f * height * x;
			return new Vector2(Vector2.Lerp(start, end, t).x, func(t) + Mathf.Lerp(start.y, end.y, t));
		}

		// Token: 0x04007305 RID: 29445
		private const string EFFUI_EXP_POOL_IDLE_RES_PATH = "Effects/UI/Prefab/EffUI_yongbingtuan/Prefab/EffUI_yongbingtuan_daiji";

		// Token: 0x04007306 RID: 29446
		private const string EFFUI_EXP_POOL_RISE_UP_RES_PATH = "Effects/UI/Prefab/EffUI_yongbingtuan/Prefab/EffUI_yongbingtuan_yaojizengzhang";

		// Token: 0x04007307 RID: 29447
		private const string EFFUI_EXP_POOL_FILL_UP_RES_PATH = "Effects/UI/Prefab/EffUI_yongbingtuan/Prefab/EffUI_yongbingtuan_manpin";

		// Token: 0x04007308 RID: 29448
		private const string EFFUI_EXP_FULL_FLYING_RES_PATH = "Effects/UI/Prefab/EffUI_yongbingtuan/Prefab/EffUI_yongbingtuan_feixing";

		// Token: 0x04007309 RID: 29449
		[SerializeField]
		[Header("特效挂载根节点")]
		private GameObject mEffectsRoot;

		// Token: 0x0400730A RID: 29450
		[Space(5f)]
		[SerializeField]
		[Header("空-液体高度 - 只用于显示")]
		[Range(0f, 1f)]
		private float mEmptyPoolLiquidHeight = 0.1f;

		// Token: 0x0400730B RID: 29451
		[SerializeField]
		[Header("满-液体高度 - 只用于显示")]
		[Range(0f, 1f)]
		private float mFullPoolLiquidHeight = 0.67f;

		// Token: 0x0400730C RID: 29452
		[SerializeField]
		[Header("半-液体高度")]
		[Range(0f, 1f)]
		private float mHalfPoolLiquidHeight = 0.41f;

		// Token: 0x0400730D RID: 29453
		[SerializeField]
		[Header("液体高度百分比")]
		private Text mPoolLiquidPercentText;

		// Token: 0x0400730E RID: 29454
		[SerializeField]
		[Header("液体每次上涨一定量的时间")]
		private float mPoolLiquidRiseupTime = 2f;

		// Token: 0x0400730F RID: 29455
		[SerializeField]
		[Header("半瓶 - 液体上涨高度曲线")]
		private AnimationCurve mHalfPoolLiguidAnimCurve;

		// Token: 0x04007310 RID: 29456
		[SerializeField]
		[Header("液体每次下降一定量的时间")]
		private float mPoolLiquidGrowdownTime = 1f;

		// Token: 0x04007311 RID: 29457
		[Space(10f)]
		[Header("经验飞行轨迹 主要依赖于终点配置 见每个终点")]
		[SerializeField]
		[Header("经验飞行起点")]
		private GameObject flyStartPoint;

		// Token: 0x04007312 RID: 29458
		[SerializeField]
		[Header("经验飞行缓动曲线")]
		private AnimationCurve flyEaseCurveType;

		// Token: 0x04007313 RID: 29459
		[SerializeField]
		[Header("经验飞行轨迹点数目，不包括起点，但包括终点")]
		private int flyPathPointCount = 20;

		// Token: 0x04007314 RID: 29460
		[Header("经验飞行时间")]
		[SerializeField]
		private float flyDuration = 1f;

		// Token: 0x04007315 RID: 29461
		[Header("经验飞行轨迹弧度")]
		[SerializeField]
		private float flyPathRadian = 1f;

		// Token: 0x04007316 RID: 29462
		[Header("经验飞行间隔时间，每次飞行前后的时间间隔")]
		[SerializeField]
		private float flyDelayTime = 0.5f;

		// Token: 0x04007317 RID: 29463
		[Space(5f)]
		[Header("### 特效本身相关 ###")]
		[SerializeField]
		[Header("液体经验涨满动画时长")]
		private float mEffectExpFullDuration = 3f;

		// Token: 0x04007318 RID: 29464
		[SerializeField]
		[Header("液体经验上涨动画时长")]
		private float mEffectExpRiseupDuration = 4f;

		// Token: 0x04007319 RID: 29465
		private bool bExpPoolIdleEffectInited;

		// Token: 0x0400731A RID: 29466
		private bool bExpPoolRiseupEffectInited;

		// Token: 0x0400731B RID: 29467
		private bool bExpPoolFillupEffectInited;

		// Token: 0x0400731C RID: 29468
		private bool bExpPoolFullFlyingEffectInited;

		// Token: 0x0400731D RID: 29469
		private GameObject mExpPoolIdle;

		// Token: 0x0400731E RID: 29470
		private GameObject mExpPoolRiseup;

		// Token: 0x0400731F RID: 29471
		private GameObject mExpPoolFillup;

		// Token: 0x04007320 RID: 29472
		private GameObject mExpPoolFullFlying;

		// Token: 0x04007321 RID: 29473
		private MeshRenderer mExpPoolLiquidRen;

		// Token: 0x04007322 RID: 29474
		private Material mExpPoolLiquidMat;

		// Token: 0x04007323 RID: 29475
		private int totalFlyPathPointCount;

		// Token: 0x04007324 RID: 29476
		private Vector3[] totalflyPathPostions;

		// Token: 0x04007325 RID: 29477
		private bool isFlying;

		// Token: 0x04007326 RID: 29478
		private Tweener flyTween;

		// Token: 0x04007327 RID: 29479
		private GameObject flyTarget;

		// Token: 0x04007328 RID: 29480
		private Coroutine waitToRiseupExp;

		// Token: 0x04007329 RID: 29481
		private Coroutine waitToPlayExpFullEffect;

		// Token: 0x0400732A RID: 29482
		private Coroutine waitToPlayExpRiseupEffect;

		// Token: 0x0400732B RID: 29483
		[HideInInspector]
		public Action ExpFlyToTargetHandler;

		// Token: 0x0400732C RID: 29484
		[HideInInspector]
		public Action ExpRiseupToFullHandler;

		// Token: 0x0400732D RID: 29485
		[HideInInspector]
		public Action ExpRiseupStartHandler;

		// Token: 0x0400732E RID: 29486
		[HideInInspector]
		public Action ExpRiseupEndHandler;

		// Token: 0x0400732F RID: 29487
		private string tr_exp_percent_format = string.Empty;
	}
}
