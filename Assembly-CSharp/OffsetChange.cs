using System;
using UnityEngine;

// Token: 0x02000D36 RID: 3382
public class OffsetChange : MonoBehaviour
{
	// Token: 0x060089FD RID: 35325 RVA: 0x00193562 File Offset: 0x00191962
	private void Awake()
	{
		this.Memory();
	}

	// Token: 0x060089FE RID: 35326 RVA: 0x0019356C File Offset: 0x0019196C
	private void Memory()
	{
		this._LoopCount = this.LoopCount;
		this._AStartTime = this.AStartTime;
		this._AXSpeed = this.AXSpeed;
		this._AYSpeed = this.AYSpeed;
		this._BStartTime = this.BStartTime;
		this._BXSpeed = this.BXSpeed;
		this._BYSpeed = this.BYSpeed;
		this._yoffset = this.yoffset;
		this._xoffset = this.xoffset;
		this._prevXoffset = this.prevXoffset;
		this._prevYoffset = this.prevYoffset;
		this._bFirstEnter = this.bFirstEnter;
		this._timer = this.timer;
		this._UseMaterial = this.UseMaterial;
	}

	// Token: 0x060089FF RID: 35327 RVA: 0x00193624 File Offset: 0x00191A24
	private void Start()
	{
		this.UseMaterial = base.GetComponent<Renderer>().material;
		if (this.AXSpeed > 0f)
		{
			this.xoffset = -1f;
		}
		else if (this.AXSpeed < 0f)
		{
			this.xoffset = 1f;
		}
		else
		{
			this.xoffset = 0f;
		}
		if (this.AYSpeed > 0f)
		{
			this.yoffset = -1f;
		}
		else if (this.AYSpeed < 0f)
		{
			this.yoffset = 1f;
		}
		else
		{
			this.yoffset = 0f;
		}
	}

	// Token: 0x06008A00 RID: 35328 RVA: 0x001936D8 File Offset: 0x00191AD8
	private void Update()
	{
		if (null == this.UseMaterial)
		{
			return;
		}
		float num = (!this.ignoreTimeScale) ? Time.deltaTime : Time.deltaTime;
		this.timer += num;
		if (this.LoopCount <= 0f)
		{
			this.xoffset += num * this.AXSpeed;
			this.yoffset += num * this.AYSpeed;
			if (this.xoffset > 1f)
			{
				this.xoffset = -1f;
			}
			if (this.yoffset > 1f)
			{
				this.yoffset = -1f;
			}
			if (this.xoffset < -1f)
			{
				this.xoffset = 1f;
			}
			if (this.yoffset < -1f)
			{
				this.yoffset = 1f;
			}
		}
		else if (this.LoopCount == 1f)
		{
			if (this.timer >= this.AStartTime)
			{
				this.xoffset += num * this.AXSpeed;
				this.yoffset += num * this.AYSpeed;
				if (this.xoffset > 1f)
				{
					this.xoffset = 1f;
				}
				if (this.xoffset < -1f)
				{
					this.xoffset = -1f;
				}
				if (this.yoffset > 1f)
				{
					this.yoffset = 1f;
				}
				if (this.yoffset < -1f)
				{
					this.yoffset = -1f;
				}
			}
		}
		else if (this.timer >= this.AStartTime)
		{
			if (this.timer < this.BStartTime)
			{
				this.xoffset += num * this.AXSpeed;
				this.yoffset += num * this.AYSpeed;
				if (this.xoffset > 1f)
				{
					this.xoffset = 1f;
				}
				if (this.xoffset < -1f)
				{
					this.xoffset = -1f;
				}
				if (this.yoffset > 1f)
				{
					this.yoffset = 1f;
				}
				if (this.yoffset < -1f)
				{
					this.yoffset = -1f;
				}
			}
			else
			{
				if (this.bFirstEnter)
				{
					if (this.BXSpeed > 0f)
					{
						this.xoffset = -1f;
					}
					else if (this.BXSpeed < 0f)
					{
						this.xoffset = 1f;
					}
					else
					{
						this.xoffset = 0f;
					}
					if (this.BYSpeed > 0f)
					{
						this.yoffset = -1f;
					}
					else if (this.BYSpeed < 0f)
					{
						this.yoffset = 1f;
					}
					else
					{
						this.yoffset = 0f;
					}
					this.bFirstEnter = false;
				}
				this.xoffset += num * this.BXSpeed;
				this.yoffset += num * this.BYSpeed;
				if (this.xoffset > 1f)
				{
					this.xoffset = 1f;
				}
				if (this.xoffset < -1f)
				{
					this.xoffset = -1f;
				}
				if (this.yoffset > 1f)
				{
					this.yoffset = 1f;
				}
				if (this.yoffset < -1f)
				{
					this.yoffset = -1f;
				}
			}
		}
		if (this.prevXoffset != this.xoffset || this.prevYoffset != this.yoffset)
		{
			this.UseMaterial.SetTextureOffset("_MainTex", new Vector2(this.xoffset, this.yoffset));
		}
		this.prevXoffset = this.xoffset;
		this.prevYoffset = this.yoffset;
	}

	// Token: 0x040043CF RID: 17359
	public float LoopCount = 1f;

	// Token: 0x040043D0 RID: 17360
	public float AStartTime;

	// Token: 0x040043D1 RID: 17361
	public float AXSpeed;

	// Token: 0x040043D2 RID: 17362
	public float AYSpeed = 1f;

	// Token: 0x040043D3 RID: 17363
	public float BStartTime = 3f;

	// Token: 0x040043D4 RID: 17364
	public float BXSpeed;

	// Token: 0x040043D5 RID: 17365
	public float BYSpeed = 1f;

	// Token: 0x040043D6 RID: 17366
	private float xoffset = -1f;

	// Token: 0x040043D7 RID: 17367
	private float yoffset = -1f;

	// Token: 0x040043D8 RID: 17368
	private float prevXoffset = -10f;

	// Token: 0x040043D9 RID: 17369
	private float prevYoffset = -10f;

	// Token: 0x040043DA RID: 17370
	private bool bFirstEnter = true;

	// Token: 0x040043DB RID: 17371
	private float timer;

	// Token: 0x040043DC RID: 17372
	private Material UseMaterial;

	// Token: 0x040043DD RID: 17373
	public bool ignoreTimeScale;

	// Token: 0x040043DE RID: 17374
	[HideInInspector]
	public float _LoopCount;

	// Token: 0x040043DF RID: 17375
	[HideInInspector]
	public float _AStartTime;

	// Token: 0x040043E0 RID: 17376
	[HideInInspector]
	public float _AXSpeed;

	// Token: 0x040043E1 RID: 17377
	[HideInInspector]
	public float _AYSpeed;

	// Token: 0x040043E2 RID: 17378
	[HideInInspector]
	public float _BStartTime;

	// Token: 0x040043E3 RID: 17379
	[HideInInspector]
	public float _BXSpeed;

	// Token: 0x040043E4 RID: 17380
	[HideInInspector]
	public float _BYSpeed;

	// Token: 0x040043E5 RID: 17381
	[HideInInspector]
	public float _xoffset;

	// Token: 0x040043E6 RID: 17382
	[HideInInspector]
	public float _yoffset;

	// Token: 0x040043E7 RID: 17383
	[HideInInspector]
	public float _prevXoffset;

	// Token: 0x040043E8 RID: 17384
	[HideInInspector]
	public float _prevYoffset;

	// Token: 0x040043E9 RID: 17385
	[HideInInspector]
	public bool _bFirstEnter;

	// Token: 0x040043EA RID: 17386
	[HideInInspector]
	public float _timer;

	// Token: 0x040043EB RID: 17387
	[HideInInspector]
	public Material _UseMaterial;
}
