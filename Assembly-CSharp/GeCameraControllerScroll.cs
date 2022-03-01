using System;
using UnityEngine;

// Token: 0x02000D70 RID: 3440
public class GeCameraControllerScroll : MonoBehaviour
{
	// Token: 0x17001899 RID: 6297
	// (get) Token: 0x06008B90 RID: 35728 RVA: 0x0019B2F3 File Offset: 0x001996F3
	public Vector3 MinXLimitRange
	{
		get
		{
			return this.m_MinLimitRange;
		}
	}

	// Token: 0x1700189A RID: 6298
	// (get) Token: 0x06008B91 RID: 35729 RVA: 0x0019B2FB File Offset: 0x001996FB
	public Vector3 MaxXLimitRange
	{
		get
		{
			return this.m_MaxLimitRange;
		}
	}

	// Token: 0x06008B92 RID: 35730 RVA: 0x0019B304 File Offset: 0x00199704
	public bool Init(GeCamera camera)
	{
		if (camera == null)
		{
			return false;
		}
		for (int i = 0; i < 3; i++)
		{
			this.m_LockAxis[i] = false;
		}
		this.m_Camera = camera;
		this.pauseUpdate = false;
		return true;
	}

	// Token: 0x06008B93 RID: 35731 RVA: 0x0019B344 File Offset: 0x00199744
	public void AttachTo(GeEntity entity, float lookHeight, float pitchAngle, float distance)
	{
		this.m_Distance = distance;
		this.m_LookHeight = lookHeight;
		this.m_PitchAngle = pitchAngle;
		if (this.m_Camera != null)
		{
			this.m_Camera.SetLookDir(new Vector3(pitchAngle, 0f, 0f));
		}
		this.m_CtrlOffset = new Vector3(0f, this.m_LookHeight, 0f);
		this.m_CtrlOffset.y = this.m_CtrlOffset.y + Mathf.Sin(pitchAngle * 0.017453292f) * distance;
		this.m_CtrlOffset.z = this.m_CtrlOffset.z - Mathf.Cos(pitchAngle * 0.017453292f) * distance;
		this.m_Entity = entity;
		this.ForceUpdate();
	}

	// Token: 0x06008B94 RID: 35732 RVA: 0x0019B3F8 File Offset: 0x001997F8
	public void SetLimitRange(float xMinLimit, float yMinLimit, float zMinLimit, float xMaxLimit, float yMaxLimit, float zMaxLimit)
	{
		this.m_MinLimitRange.x = xMinLimit;
		this.m_MinLimitRange.y = yMinLimit;
		this.m_MinLimitRange.z = zMinLimit;
		this.m_MaxLimitRange.x = xMaxLimit;
		this.m_MaxLimitRange.y = yMaxLimit;
		this.m_MaxLimitRange.z = zMaxLimit;
		this.m_LockAxis[0] = (xMinLimit == xMaxLimit);
		this.m_LockAxis[1] = (yMinLimit == yMaxLimit);
		this.m_LockAxis[2] = (zMinLimit == zMaxLimit);
	}

	// Token: 0x06008B95 RID: 35733 RVA: 0x0019B477 File Offset: 0x00199877
	public void SetXLimitOffset(float min, float max)
	{
		this.m_MinXLimitOffset = min;
		this.m_MaxXLimitOffset = max;
	}

	// Token: 0x06008B96 RID: 35734 RVA: 0x0019B487 File Offset: 0x00199887
	public void SetMotorLimit(float xMotorLimit, float yMotorLimit, float zMotorLimit)
	{
		this.m_MotorLimit.x = xMotorLimit;
		this.m_MotorLimit.y = yMotorLimit;
		this.m_MotorLimit.z = zMotorLimit;
	}

	// Token: 0x06008B97 RID: 35735 RVA: 0x0019B4AD File Offset: 0x001998AD
	private void Start()
	{
	}

	// Token: 0x06008B98 RID: 35736 RVA: 0x0019B4AF File Offset: 0x001998AF
	public void MoveCamera(float off, float timelen)
	{
		if (timelen > 0f)
		{
			this.targetOffset = off;
			this.m_MoveTimeLen = timelen;
			this.m_MoveTimePos = 0f;
		}
	}

	// Token: 0x06008B99 RID: 35737 RVA: 0x0019B4D5 File Offset: 0x001998D5
	public float GetOffset()
	{
		return this.offset;
	}

	// Token: 0x06008B9A RID: 35738 RVA: 0x0019B4DD File Offset: 0x001998DD
	public void ForceUpdate()
	{
		this.LateUpdate();
	}

	// Token: 0x06008B9B RID: 35739 RVA: 0x0019B4E8 File Offset: 0x001998E8
	private void LateUpdate()
	{
		this.UpdateCameraPull();
		if (this.pauseUpdate)
		{
			return;
		}
		if (this.m_Entity == null)
		{
			return;
		}
		this._UpdateXOffsetLimit();
		float num = this.offset;
		Vector3 localPosition;
		if (this.m_MoveTimePos < this.m_MoveTimeLen)
		{
			this.m_MoveTimePos += Time.deltaTime;
			localPosition = base.gameObject.transform.localPosition;
			float num2 = this.m_MoveTimePos / this.m_MoveTimeLen * this.targetOffset;
			if (this.targetOffset > 0f)
			{
				num2 = Mathf.Min(num2, this.targetOffset);
			}
			if (this.targetOffset < 0f)
			{
				num2 = Mathf.Max(num2, this.targetOffset);
			}
			num = this.offset + num2;
		}
		else
		{
			if (this.m_MoveTimeLen > 0f)
			{
				this.offset += this.targetOffset;
				num = this.offset;
				this.m_MoveTimeLen = 0f;
			}
			localPosition = base.gameObject.transform.localPosition;
		}
		Vector3 position = this.m_Entity.GetPosition();
		position.x += num;
		float num3 = position.x - localPosition.x;
		num3 -= Mathf.Clamp(num3, -this.m_MotorLimit.x, this.m_MotorLimit.x);
		float num4 = num3 + localPosition.x;
		float num5 = position.y - localPosition.y;
		num5 -= Mathf.Clamp(num5, -this.m_MotorLimit.y, this.m_MotorLimit.y);
		float num6 = num5 + localPosition.y;
		float num7 = position.z - localPosition.z;
		num7 -= Mathf.Clamp(num7, -this.m_MotorLimit.z, this.m_MotorLimit.z);
		float num8 = num7 + localPosition.z;
		if (!this.m_LockAxis[0])
		{
			localPosition.x = Mathf.Clamp(num4 + this.m_CtrlOffset.x, this.m_MinLimitRange.x + this.m_MinXLimitOffset, this.m_MaxLimitRange.x + this.m_MaxXLimitOffset);
		}
		else
		{
			localPosition.x = this.m_CtrlOffset.x;
		}
		if (!this.m_LockAxis[1])
		{
			localPosition.y = Mathf.Clamp(num6 + this.m_CtrlOffset.y, this.m_MinLimitRange.y, this.m_MaxLimitRange.y);
		}
		else
		{
			localPosition.y = this.m_CtrlOffset.y;
		}
		if (!this.m_LockAxis[2])
		{
			localPosition.z = Mathf.Clamp(num8 + this.m_CtrlOffset.z, this.m_MinLimitRange.z, this.m_MaxLimitRange.z);
		}
		else
		{
			localPosition.z = this.m_CtrlOffset.z;
		}
		base.gameObject.transform.localPosition = localPosition;
		this.SetXLimitOffset(0f, 0f);
	}

	// Token: 0x06008B9C RID: 35740 RVA: 0x0019B800 File Offset: 0x00199C00
	public void SetCameraPos(Vector3 offset)
	{
		offset.x = Mathf.Clamp(offset.x, this.m_MinLimitRange.x + this.m_MinXLimitOffset, this.m_MaxLimitRange.x + this.m_MaxXLimitOffset);
		base.gameObject.transform.localPosition = offset;
	}

	// Token: 0x06008B9D RID: 35741 RVA: 0x0019B855 File Offset: 0x00199C55
	public void SetCameraPosition(Vector3 offset)
	{
		base.gameObject.transform.localPosition = offset;
	}

	// Token: 0x06008B9E RID: 35742 RVA: 0x0019B868 File Offset: 0x00199C68
	public Vector3 GetCameraPosition()
	{
		return base.gameObject.transform.localPosition;
	}

	// Token: 0x06008B9F RID: 35743 RVA: 0x0019B87C File Offset: 0x00199C7C
	public bool IsInSceneLeftEdge()
	{
		float x = base.gameObject.transform.localPosition.x;
		return x <= this.m_MinLimitRange.x + this.m_MinXLimitOffset;
	}

	// Token: 0x06008BA0 RID: 35744 RVA: 0x0019B8BC File Offset: 0x00199CBC
	public bool IsInSceneRightEdge()
	{
		float x = base.gameObject.transform.localPosition.x;
		return x >= this.m_MaxLimitRange.x + this.m_MaxXLimitOffset;
	}

	// Token: 0x06008BA1 RID: 35745 RVA: 0x0019B8FC File Offset: 0x00199CFC
	private void _UpdateXOffsetLimit()
	{
		if (this.m_Camera != null)
		{
			Camera camera = this.m_Camera.GetCamera();
			if (null != camera && camera.aspect != this.m_CurAspect)
			{
				this.m_CurAspect = camera.aspect;
			}
		}
	}

	// Token: 0x06008BA2 RID: 35746 RVA: 0x0019B94C File Offset: 0x00199D4C
	protected void ResetData()
	{
		if (this.m_MoveTimePos == 0f || this.m_MoveTimeLen == 0f)
		{
			return;
		}
		this.m_MoveTimePos = this.m_MoveTimeLen - Time.deltaTime;
		this.LateUpdate();
		this.LateUpdate();
	}

	// Token: 0x06008BA3 RID: 35747 RVA: 0x0019B998 File Offset: 0x00199D98
	public void SetPause(bool flag)
	{
		this.pauseUpdate = flag;
	}

	// Token: 0x06008BA4 RID: 35748 RVA: 0x0019B9A4 File Offset: 0x00199DA4
	public void StartCameraPull(Vector3 targetPos, float speed, float targetSize)
	{
		if (!this.isPulling)
		{
			this.originalSize = this.m_Camera.GetCamera().orthographicSize;
		}
		this.pullTargetPos = targetPos;
		this.pullSpeed = speed;
		this.pullTargetSize = targetSize;
		this.time = 0;
		this.isPulling = true;
	}

	// Token: 0x06008BA5 RID: 35749 RVA: 0x0019B9F8 File Offset: 0x00199DF8
	private void UpdateCameraPull()
	{
		if (!this.isPulling)
		{
			return;
		}
		this.time += this.deletaTime;
		this.m_Camera.GetCamera().transform.localPosition = Vector3.Lerp(this.m_Camera.GetCamera().transform.localPosition, this.pullTargetPos, (float)this.time / 1000f * this.pullSpeed);
		this.m_Camera.GetCamera().orthographicSize = Mathf.Lerp(this.m_Camera.GetCamera().orthographicSize, this.pullTargetSize, (float)this.time / 1000f * this.pullSpeed);
		if (this.m_Camera.GetCamera().transform.localPosition == this.pullTargetPos && this.m_Camera.GetCamera().orthographicSize == this.pullTargetSize)
		{
			this.isPulling = false;
		}
	}

	// Token: 0x06008BA6 RID: 35750 RVA: 0x0019BAF4 File Offset: 0x00199EF4
	public void RestoreCameraPull(float speed)
	{
		if (speed == 0f)
		{
			this.time = 0;
			this.isPulling = false;
			this.m_Camera.GetCamera().orthographicSize = this.originalSize;
			this.m_Camera.GetCamera().transform.localPosition = Vector3.zero;
		}
		else
		{
			this.pullTargetPos = Vector3.zero;
			this.pullSpeed = speed;
			this.pullTargetSize = this.originalSize;
			this.time = 0;
			this.isPulling = true;
		}
	}

	// Token: 0x06008BA7 RID: 35751 RVA: 0x0019BB7C File Offset: 0x00199F7C
	public void ResetCamera()
	{
		Camera camera = this.m_Camera.GetCamera();
		if (camera != null)
		{
			camera.transform.localPosition = Vector3.zero;
		}
	}

	// Token: 0x040044D8 RID: 17624
	public float m_From = -500f;

	// Token: 0x040044D9 RID: 17625
	public float m_To = 500f;

	// Token: 0x040044DA RID: 17626
	public float m_Limit = 8f;

	// Token: 0x040044DB RID: 17627
	public float m_FollowThreshold = 1f;

	// Token: 0x040044DC RID: 17628
	public float m_UnfollowThreshold = 0.05f;

	// Token: 0x040044DD RID: 17629
	public bool m_UsePreSetting = true;

	// Token: 0x040044DE RID: 17630
	public float m_SmoothTime = 0.3f;

	// Token: 0x040044DF RID: 17631
	private Vector3 Velocity = new Vector3(0f, 0f, 0f);

	// Token: 0x040044E0 RID: 17632
	private GeCamera m_Camera;

	// Token: 0x040044E1 RID: 17633
	private GeEntity m_Entity;

	// Token: 0x040044E2 RID: 17634
	public Vector3 m_CtrlOffset = new Vector3(0f, 0f, 0f);

	// Token: 0x040044E3 RID: 17635
	private Vector3 m_MinLimitRange = new Vector3(-100000f, -100000f, -100000f);

	// Token: 0x040044E4 RID: 17636
	private Vector3 m_MaxLimitRange = new Vector3(100000f, 100000f, 100000f);

	// Token: 0x040044E5 RID: 17637
	private float m_MinXLimitOffset;

	// Token: 0x040044E6 RID: 17638
	private float m_MaxXLimitOffset;

	// Token: 0x040044E7 RID: 17639
	private float m_CurAspect = 1f;

	// Token: 0x040044E8 RID: 17640
	private Vector3 m_MotorLimit = new Vector3(0f, 0f, 0f);

	// Token: 0x040044E9 RID: 17641
	private float m_Distance = 10f;

	// Token: 0x040044EA RID: 17642
	private float m_LookHeight = 1f;

	// Token: 0x040044EB RID: 17643
	private float m_PitchAngle = 10f;

	// Token: 0x040044EC RID: 17644
	protected bool[] m_LockAxis = new bool[3];

	// Token: 0x040044ED RID: 17645
	protected float m_MoveTimeLen;

	// Token: 0x040044EE RID: 17646
	protected float m_MoveTimePos;

	// Token: 0x040044EF RID: 17647
	protected Vector3 m_TargetPosition = new Vector3(0f, 0f, 0f);

	// Token: 0x040044F0 RID: 17648
	protected float offset;

	// Token: 0x040044F1 RID: 17649
	protected float targetOffset;

	// Token: 0x040044F2 RID: 17650
	protected bool pauseUpdate;

	// Token: 0x040044F3 RID: 17651
	private Vector3 pullTargetPos = Vector3.zero;

	// Token: 0x040044F4 RID: 17652
	private float pullSpeed;

	// Token: 0x040044F5 RID: 17653
	private float pullTargetSize;

	// Token: 0x040044F6 RID: 17654
	private int deletaTime = 32;

	// Token: 0x040044F7 RID: 17655
	private bool isPulling;

	// Token: 0x040044F8 RID: 17656
	private int time;

	// Token: 0x040044F9 RID: 17657
	private float originalSize;
}
