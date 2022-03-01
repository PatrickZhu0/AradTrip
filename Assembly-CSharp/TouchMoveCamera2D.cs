using System;
using GameClient;
using UnityEngine;

// Token: 0x02000FB7 RID: 4023
public class TouchMoveCamera2D : MonoBehaviour
{
	// Token: 0x17001942 RID: 6466
	// (get) Token: 0x06009ACF RID: 39631 RVA: 0x001DED0D File Offset: 0x001DD10D
	// (set) Token: 0x06009ACE RID: 39630 RVA: 0x001DED04 File Offset: 0x001DD104
	public Transform PlayerTransform
	{
		get
		{
			return this.playerTransform;
		}
		set
		{
			this.playerTransform = value;
		}
	}

	// Token: 0x06009AD0 RID: 39632 RVA: 0x001DED15 File Offset: 0x001DD115
	public void Start()
	{
		this.originPos = base.transform.localPosition;
	}

	// Token: 0x06009AD1 RID: 39633 RVA: 0x001DED28 File Offset: 0x001DD128
	private void _limitPos()
	{
		Vector3 localPosition = base.transform.localPosition;
		localPosition.x = Mathf.Clamp(localPosition.x, this.originPos.x + this.offsetLimitWidth.x, this.originPos.x + this.offsetLimitWidth.y);
		localPosition.y = Mathf.Clamp(localPosition.y, this.originPos.y + this.offsetLimitHieght.x, this.originPos.y + this.offsetLimitHieght.y);
		base.transform.localPosition = localPosition;
	}

	// Token: 0x06009AD2 RID: 39634 RVA: 0x001DEDCF File Offset: 0x001DD1CF
	public void UpdateMapPos()
	{
		if (this.playerTransform != null && this.bEnabled)
		{
			this._setMapPosByPlayerPos(this.playerTransform.position);
		}
	}

	// Token: 0x06009AD3 RID: 39635 RVA: 0x001DEE00 File Offset: 0x001DD200
	private void _setMapPosByPlayerPos(Vector3 playerWorldPos)
	{
		Vector3 vector = Singleton<ClientSystemManager>.GetInstance().UICamera.WorldToScreenPoint(playerWorldPos);
		float num = (float)Screen.height / 3f;
		float num2 = (float)(Screen.height * 2) / 3f;
		float num3 = (float)Screen.height / 2f;
		if (vector.y < num || vector.y > num2)
		{
			Vector3 localPosition = base.transform.localPosition;
			localPosition.y += num3 - vector.y;
			base.transform.localPosition = localPosition;
			this._limitPos();
		}
	}

	// Token: 0x06009AD4 RID: 39636 RVA: 0x001DEE98 File Offset: 0x001DD298
	private void MoveBegin(Vector3 point)
	{
		this.beginPos = point;
		this.speed = Vector3.zero;
		this.timer = 0f;
	}

	// Token: 0x06009AD5 RID: 39637 RVA: 0x001DEEBC File Offset: 0x001DD2BC
	private void Moveing(Vector3 point)
	{
		this.endPos = point;
		Vector3 vector;
		vector..ctor(this.beginPos.x, this.beginPos.y, 0f);
		Vector3 vector2;
		vector2..ctor(this.endPos.x, this.endPos.y, 0f);
		this.speed = vector2 - vector;
	}

	// Token: 0x06009AD6 RID: 39638 RVA: 0x001DEF26 File Offset: 0x001DD326
	private void MoveEnd(Vector3 point)
	{
		this.MoveBegin(point);
	}

	// Token: 0x06009AD7 RID: 39639 RVA: 0x001DEF30 File Offset: 0x001DD330
	private void UpdateTargetPositionInComputer()
	{
		if (Input.GetMouseButtonDown(0))
		{
			this.MoveBegin(Input.mousePosition);
		}
		else if (Input.GetMouseButton(0))
		{
			this.timer += Time.deltaTime;
			if (this.timer > this.offsetTime)
			{
				this.Moveing(Input.mousePosition);
			}
		}
		else if (Input.GetMouseButtonUp(0))
		{
			this.MoveEnd(Input.mousePosition);
		}
	}

	// Token: 0x06009AD8 RID: 39640 RVA: 0x001DEFAC File Offset: 0x001DD3AC
	private void UpdateTargetPositonInMobile()
	{
		if (Input.touchCount == 0)
		{
			return;
		}
		if (Input.touchCount == 1)
		{
			if (Input.GetTouch(0).phase == null)
			{
				this.MoveBegin(Input.GetTouch(0).position);
			}
			else if (Input.GetTouch(0).phase == 1)
			{
				this.timer += Time.deltaTime;
				if (this.timer > this.offsetTime)
				{
					this.Moveing(Input.GetTouch(0).position);
				}
			}
			else if (Input.GetTouch(0).phase == 3)
			{
				this.MoveEnd(Input.GetTouch(0).position);
			}
		}
	}

	// Token: 0x06009AD9 RID: 39641 RVA: 0x001DF084 File Offset: 0x001DD484
	public void Update()
	{
		if (!this.bEnabled)
		{
			return;
		}
		if (this.count == 0)
		{
			this.UpdateMapPos();
		}
		this.count++;
		this.UpdateTargetPositonInMobile();
		if (this.speed == Vector3.zero)
		{
			return;
		}
		float num = base.transform.position.x;
		float num2 = base.transform.position.y;
		num += this.speed.x;
		num2 += this.speed.y;
		Vector3 position;
		position..ctor(num, num2, base.transform.position.z);
		base.transform.position = position;
		this._limitPos();
		this.beginPos = this.endPos;
		if ((double)Mathf.Abs(this.speed.x) < 1E-05 && (double)Mathf.Abs(this.speed.y) < 1E-05)
		{
			this.speed = Vector3.zero;
		}
	}

	// Token: 0x0400504C RID: 20556
	public bool bEnabled;

	// Token: 0x0400504D RID: 20557
	public float offsetTime = 0.1f;

	// Token: 0x0400504E RID: 20558
	public Vector2 offsetLimitWidth = Vector2.zero;

	// Token: 0x0400504F RID: 20559
	public Vector2 offsetLimitHieght = Vector2.zero;

	// Token: 0x04005050 RID: 20560
	private Vector2 beginPos = Vector2.zero;

	// Token: 0x04005051 RID: 20561
	private Vector2 endPos = Vector2.zero;

	// Token: 0x04005052 RID: 20562
	private Vector3 speed = Vector3.zero;

	// Token: 0x04005053 RID: 20563
	private float timer;

	// Token: 0x04005054 RID: 20564
	private Vector2 offset = Vector2.zero;

	// Token: 0x04005055 RID: 20565
	private Vector3 originPos;

	// Token: 0x04005056 RID: 20566
	private Transform playerTransform;

	// Token: 0x04005057 RID: 20567
	private int count;
}
