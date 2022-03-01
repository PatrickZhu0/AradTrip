using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000FA6 RID: 4006
public class HGBossCameraTween : MonoBehaviour
{
	// Token: 0x06009A8B RID: 39563 RVA: 0x001DE03E File Offset: 0x001DC43E
	private void Awake()
	{
		this.cachedCamera = base.gameObject.GetComponent<Camera>();
		this.cachedTransform = base.gameObject.transform;
		this.cachedPosition = Vector3.zero;
		this.cachedSize = 3f;
	}

	// Token: 0x06009A8C RID: 39564 RVA: 0x001DE078 File Offset: 0x001DC478
	private IEnumerator UpdateTween()
	{
		float time = Time.realtimeSinceStartup - this.beginTime;
		while (time < this.timeLength)
		{
			time = Mathf.Repeat(time, this.timeLength) / this.timeLength;
			if (this.from)
			{
				float num = this.positionCurve.Evaluate(time);
				this.cachedTransform.localPosition = Vector3.Lerp(this.cachedPosition, this.targetPos, num);
				float num2 = this.scaleCurve.Evaluate(time);
				this.cachedCamera.orthographicSize = Mathf.Lerp(this.cachedSize, this.targetSize, num2);
			}
			else
			{
				float num3 = this.positionCurve.Evaluate(time);
				this.cachedTransform.localPosition = Vector3.Lerp(this.targetPos, this.cachedPosition, num3);
				float num4 = this.scaleCurve.Evaluate(time);
				this.cachedCamera.orthographicSize = Mathf.Lerp(this.targetSize, this.cachedSize, num4);
			}
			yield return Yielders.EndOfFrame;
			time = Time.realtimeSinceStartup - this.beginTime;
			Logger.LogErrorFormat("camera:({0},{1},{2})", new object[]
			{
				this.cachedTransform.localPosition.x,
				this.cachedTransform.localPosition.y,
				this.cachedTransform.localPosition.z
			});
		}
		if (this.callback != null)
		{
			this.callback(this.from);
		}
		this.cachedTransform.localPosition = this.cachedPosition;
		this.cachedCamera.orthographicSize = this.cachedSize;
		this.bUpdate = false;
		yield break;
	}

	// Token: 0x06009A8D RID: 39565 RVA: 0x001DE094 File Offset: 0x001DC494
	public void StartTween(bool from = true)
	{
		this.from = from;
		if (!this.bUpdate)
		{
			this.bUpdate = true;
			this.beginTime = Time.realtimeSinceStartup;
			this.cachedSize = this.cachedCamera.orthographicSize;
			base.StartCoroutine(this.UpdateTween());
		}
	}

	// Token: 0x06009A8E RID: 39566 RVA: 0x001DE0E3 File Offset: 0x001DC4E3
	public void SetStartPos(Vector3 targetPos)
	{
		this.targetPos = targetPos;
		this.cachedTransform.localPosition = targetPos;
		this.cachedCamera.orthographicSize = this.targetSize;
	}

	// Token: 0x06009A8F RID: 39567 RVA: 0x001DE109 File Offset: 0x001DC509
	public void RestorePos()
	{
		this.cachedTransform.localPosition = this.cachedPosition;
		this.cachedCamera.orthographicSize = this.cachedSize;
	}

	// Token: 0x04005021 RID: 20513
	public AnimationCurve positionCurve;

	// Token: 0x04005022 RID: 20514
	public AnimationCurve scaleCurve;

	// Token: 0x04005023 RID: 20515
	private Vector3 targetPos;

	// Token: 0x04005024 RID: 20516
	public float targetSize;

	// Token: 0x04005025 RID: 20517
	public float timeLength = 3f;

	// Token: 0x04005026 RID: 20518
	public string bgPrefab = string.Empty;

	// Token: 0x04005027 RID: 20519
	public float blackTime = 0.6f;

	// Token: 0x04005028 RID: 20520
	public float blackFadeOutTime = 0.5f;

	// Token: 0x04005029 RID: 20521
	private Camera cachedCamera;

	// Token: 0x0400502A RID: 20522
	private Transform cachedTransform;

	// Token: 0x0400502B RID: 20523
	private Vector3 cachedPosition;

	// Token: 0x0400502C RID: 20524
	private float cachedSize;

	// Token: 0x0400502D RID: 20525
	private float beginTime;

	// Token: 0x0400502E RID: 20526
	private bool bUpdate;

	// Token: 0x0400502F RID: 20527
	private bool from;

	// Token: 0x04005030 RID: 20528
	public HGBossCameraTween.HGBossCameraTweenFinishCallBack callback;

	// Token: 0x02000FA7 RID: 4007
	// (Invoke) Token: 0x06009A91 RID: 39569
	public delegate void HGBossCameraTweenFinishCallBack(bool from);
}
