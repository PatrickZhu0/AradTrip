using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x02000246 RID: 582
public class TweenPosArc : MonoBehaviour
{
	// Token: 0x06001321 RID: 4897 RVA: 0x000669B0 File Offset: 0x00064DB0
	private void Start()
	{
		this.countDelayTime = this.delayTime;
		this.goldPosition = base.transform;
		this.gamePointInit = this.goldPosition.transform.position;
		this.randomAngle1 = (float)Random.Range(60, 120);
		this.randomAngle2 = (float)Random.Range(-60, -120);
		float[] array = new float[]
		{
			this.randomAngle1,
			this.randomAngle2
		};
		this.randomAngle = array[Random.Range(0, array.Length)];
		this.radiusX1 = Mathf.Sin(this.randomAngle * 3.1415927f / 180f) * this.radius1;
		this.radiusY1 = Mathf.Cos(this.randomAngle * 3.1415927f / 180f) * this.radius1;
		this.radiusX2 = Mathf.Sin(this.randomAngle * 3.1415927f / 180f) * this.radius2;
		this.radiusY2 = Mathf.Cos(this.randomAngle * 3.1415927f / 180f) * this.radius2;
		this.heigaht2 = this.targetPosition.transform.position.y * this.percent;
		if (this.targetPosition)
		{
			this.Init();
		}
		else
		{
			Debug.LogWarning("没有查到追寻物体");
		}
	}

	// Token: 0x06001322 RID: 4898 RVA: 0x00066B10 File Offset: 0x00064F10
	public void Init()
	{
		this.goPosition = Utility.FindThatChild("Body", this.targetPosition, false);
		if (this.goPosition == null)
		{
			return;
		}
		this.countDelayTime = this.delayTime;
		this.mState = TweenPosArc.eTweenPosState.None;
		this.gamePoint1 = this.gamePointInit;
		this.gamePoint2 = new Vector3(this.gamePointInit.x + this.radiusX1, this.gamePointInit.y, this.gamePointInit.z + this.radiusY1);
		this.gamePoint3 = new Vector3(this.gamePointInit.x + this.radiusX2, this.gamePointInit.y + this.heigaht2, this.gamePointInit.z + this.radiusY2);
		this.gamePoint4 = this.goPosition.transform.position;
		this.gamePoint5 = this.goPosition.transform.position;
		this.point = new List<Vector3>();
		for (int i = 0; i < 200; i++)
		{
			Vector3 vector = Vector3.Lerp(this.gamePoint1, this.gamePoint2, (float)i / this.conmat);
			Vector3 vector2 = Vector3.Lerp(this.gamePoint2, this.gamePoint3, (float)i / this.conmat);
			Vector3 vector3 = Vector3.Lerp(this.gamePoint3, this.gamePoint4, (float)i / this.conmat);
			Vector3 vector4 = Vector3.Lerp(this.gamePoint4, this.gamePoint5, (float)i / this.conmat);
			Vector3 vector5 = Vector3.Lerp(vector, vector2, (float)i / this.conmat);
			Vector3 vector6 = Vector3.Lerp(vector2, vector3, (float)i / this.conmat);
			Vector3 vector7 = Vector3.Lerp(vector3, vector4, (float)i / this.conmat);
			Vector3 vector8 = Vector3.Lerp(vector5, vector6, (float)i / this.conmat);
			Vector3 vector9 = Vector3.Lerp(vector6, vector7, (float)i / this.conmat);
			Vector3 item = Vector3.Lerp(vector8, vector9, (float)i / this.conmat);
			this.point.Add(item);
		}
	}

	// Token: 0x06001323 RID: 4899 RVA: 0x00066D1A File Offset: 0x0006511A
	private void OnDisable()
	{
		if (this.mState != TweenPosArc.eTweenPosState.Played)
		{
			this.isPlay = false;
			this.onFinish.Invoke();
			this.mState = TweenPosArc.eTweenPosState.Played;
		}
	}

	// Token: 0x06001324 RID: 4900 RVA: 0x00066D44 File Offset: 0x00065144
	private void Update()
	{
		this.Init();
		if (this.goPosition == null)
		{
			return;
		}
		this.Timer += Time.deltaTime;
		if (this.Timer > this.TimeSoeed && this.isPlay)
		{
			this.Timer = 0f;
			this.goldPosition.transform.localPosition = Vector3.Lerp(this.point[this.i - 1], this.point[this.i], 1f);
			this.i++;
			if (this.i >= this.point.Count)
			{
				this.i = 1;
			}
			if (Vector3.Distance(this.goldPosition.transform.position, this.gamePoint5) < 0.01f)
			{
				this.isRemove = false;
			}
		}
		if (!this.isRemove)
		{
			this.delayTime -= Time.deltaTime;
			if (this.delayTime < 0f)
			{
				this.isPlay = false;
				this.onFinish.Invoke();
				this.mState = TweenPosArc.eTweenPosState.Played;
			}
		}
	}

	// Token: 0x04000CD8 RID: 3288
	public GameObject targetPosition;

	// Token: 0x04000CD9 RID: 3289
	private GameObject goPosition;

	// Token: 0x04000CDA RID: 3290
	public UnityEvent onFinish = new UnityEvent();

	// Token: 0x04000CDB RID: 3291
	public float delayTime;

	// Token: 0x04000CDC RID: 3292
	private float countDelayTime;

	// Token: 0x04000CDD RID: 3293
	private List<Vector3> point = new List<Vector3>();

	// Token: 0x04000CDE RID: 3294
	private Vector3 gamePointInit;

	// Token: 0x04000CDF RID: 3295
	private Vector3 gamePoint1;

	// Token: 0x04000CE0 RID: 3296
	private Vector3 gamePoint2;

	// Token: 0x04000CE1 RID: 3297
	private Vector3 gamePoint3;

	// Token: 0x04000CE2 RID: 3298
	private Vector3 gamePoint4;

	// Token: 0x04000CE3 RID: 3299
	private Vector3 gamePoint5;

	// Token: 0x04000CE4 RID: 3300
	private Transform goldPosition;

	// Token: 0x04000CE5 RID: 3301
	public float TimeSoeed = 0.001f;

	// Token: 0x04000CE6 RID: 3302
	private float Timer;

	// Token: 0x04000CE7 RID: 3303
	private bool isPlay = true;

	// Token: 0x04000CE8 RID: 3304
	private bool isRemove = true;

	// Token: 0x04000CE9 RID: 3305
	private float percent = 0.35f;

	// Token: 0x04000CEA RID: 3306
	private float radius1 = 2f;

	// Token: 0x04000CEB RID: 3307
	private float radius2 = 3f;

	// Token: 0x04000CEC RID: 3308
	private float radiusX1;

	// Token: 0x04000CED RID: 3309
	private float radiusY1;

	// Token: 0x04000CEE RID: 3310
	private float radiusX2;

	// Token: 0x04000CEF RID: 3311
	private float radiusY2;

	// Token: 0x04000CF0 RID: 3312
	private float heigaht2;

	// Token: 0x04000CF1 RID: 3313
	private float randomAngle1;

	// Token: 0x04000CF2 RID: 3314
	private float randomAngle2;

	// Token: 0x04000CF3 RID: 3315
	private float randomAngle;

	// Token: 0x04000CF4 RID: 3316
	private float conmat = 15f;

	// Token: 0x04000CF5 RID: 3317
	private int i = 1;

	// Token: 0x04000CF6 RID: 3318
	private TweenPosArc.eTweenPosState mState;

	// Token: 0x02000247 RID: 583
	private enum eTweenPosState
	{
		// Token: 0x04000CF8 RID: 3320
		None,
		// Token: 0x04000CF9 RID: 3321
		Played,
		// Token: 0x04000CFA RID: 3322
		Finish
	}
}
