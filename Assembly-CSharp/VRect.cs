using System;

// Token: 0x02000195 RID: 405
public struct VRect
{
	// Token: 0x06000C51 RID: 3153 RVA: 0x0003D6E0 File Offset: 0x0003BAE0
	public VRect(int left, int top, int width, int height)
	{
		this.m_XMin = left;
		this.m_YMin = top;
		this.m_Width = width;
		this.m_Height = height;
	}

	// Token: 0x06000C52 RID: 3154 RVA: 0x0003D6FF File Offset: 0x0003BAFF
	public VRect(VRect source)
	{
		this.m_XMin = source.m_XMin;
		this.m_YMin = source.m_YMin;
		this.m_Width = source.m_Width;
		this.m_Height = source.m_Height;
	}

	// Token: 0x06000C53 RID: 3155 RVA: 0x0003D735 File Offset: 0x0003BB35
	public static VRect MinMaxRect(int left, int top, int right, int bottom)
	{
		return new VRect(left, top, right - left, bottom - top);
	}

	// Token: 0x06000C54 RID: 3156 RVA: 0x0003D744 File Offset: 0x0003BB44
	public void Set(int left, int top, int width, int height)
	{
		this.m_XMin = left;
		this.m_YMin = top;
		this.m_Width = width;
		this.m_Height = height;
	}

	// Token: 0x170001CD RID: 461
	// (get) Token: 0x06000C55 RID: 3157 RVA: 0x0003D763 File Offset: 0x0003BB63
	// (set) Token: 0x06000C56 RID: 3158 RVA: 0x0003D76B File Offset: 0x0003BB6B
	public int x
	{
		get
		{
			return this.m_XMin;
		}
		set
		{
			this.m_XMin = value;
		}
	}

	// Token: 0x170001CE RID: 462
	// (get) Token: 0x06000C57 RID: 3159 RVA: 0x0003D774 File Offset: 0x0003BB74
	// (set) Token: 0x06000C58 RID: 3160 RVA: 0x0003D77C File Offset: 0x0003BB7C
	public int y
	{
		get
		{
			return this.m_YMin;
		}
		set
		{
			this.m_YMin = value;
		}
	}

	// Token: 0x170001CF RID: 463
	// (get) Token: 0x06000C59 RID: 3161 RVA: 0x0003D785 File Offset: 0x0003BB85
	// (set) Token: 0x06000C5A RID: 3162 RVA: 0x0003D798 File Offset: 0x0003BB98
	public VInt2 position
	{
		get
		{
			return new VInt2(this.m_XMin, this.m_YMin);
		}
		set
		{
			this.m_XMin = value.x;
			this.m_YMin = value.y;
		}
	}

	// Token: 0x170001D0 RID: 464
	// (get) Token: 0x06000C5B RID: 3163 RVA: 0x0003D7B4 File Offset: 0x0003BBB4
	// (set) Token: 0x06000C5C RID: 3164 RVA: 0x0003D7D9 File Offset: 0x0003BBD9
	public VInt2 center
	{
		get
		{
			return new VInt2(this.x + (this.m_Width >> 1), this.y + (this.m_Height >> 1));
		}
		set
		{
			this.m_XMin = value.x - (this.m_Width >> 1);
			this.m_YMin = value.y - (this.m_Height >> 1);
		}
	}

	// Token: 0x170001D1 RID: 465
	// (get) Token: 0x06000C5D RID: 3165 RVA: 0x0003D807 File Offset: 0x0003BC07
	// (set) Token: 0x06000C5E RID: 3166 RVA: 0x0003D81A File Offset: 0x0003BC1A
	public VInt2 min
	{
		get
		{
			return new VInt2(this.xMin, this.yMin);
		}
		set
		{
			this.xMin = value.x;
			this.yMin = value.y;
		}
	}

	// Token: 0x170001D2 RID: 466
	// (get) Token: 0x06000C5F RID: 3167 RVA: 0x0003D836 File Offset: 0x0003BC36
	// (set) Token: 0x06000C60 RID: 3168 RVA: 0x0003D849 File Offset: 0x0003BC49
	public VInt2 max
	{
		get
		{
			return new VInt2(this.xMax, this.yMax);
		}
		set
		{
			this.xMax = value.x;
			this.yMax = value.y;
		}
	}

	// Token: 0x170001D3 RID: 467
	// (get) Token: 0x06000C61 RID: 3169 RVA: 0x0003D865 File Offset: 0x0003BC65
	// (set) Token: 0x06000C62 RID: 3170 RVA: 0x0003D86D File Offset: 0x0003BC6D
	public int width
	{
		get
		{
			return this.m_Width;
		}
		set
		{
			this.m_Width = value;
		}
	}

	// Token: 0x170001D4 RID: 468
	// (get) Token: 0x06000C63 RID: 3171 RVA: 0x0003D876 File Offset: 0x0003BC76
	// (set) Token: 0x06000C64 RID: 3172 RVA: 0x0003D87E File Offset: 0x0003BC7E
	public int height
	{
		get
		{
			return this.m_Height;
		}
		set
		{
			this.m_Height = value;
		}
	}

	// Token: 0x170001D5 RID: 469
	// (get) Token: 0x06000C65 RID: 3173 RVA: 0x0003D887 File Offset: 0x0003BC87
	// (set) Token: 0x06000C66 RID: 3174 RVA: 0x0003D89A File Offset: 0x0003BC9A
	public VInt2 size
	{
		get
		{
			return new VInt2(this.m_Width, this.m_Height);
		}
		set
		{
			this.m_Width = value.x;
			this.m_Height = value.y;
		}
	}

	// Token: 0x170001D6 RID: 470
	// (get) Token: 0x06000C67 RID: 3175 RVA: 0x0003D8B6 File Offset: 0x0003BCB6
	// (set) Token: 0x06000C68 RID: 3176 RVA: 0x0003D8C0 File Offset: 0x0003BCC0
	public int xMin
	{
		get
		{
			return this.m_XMin;
		}
		set
		{
			int xMax = this.xMax;
			this.m_XMin = value;
			this.m_Width = xMax - this.m_XMin;
		}
	}

	// Token: 0x170001D7 RID: 471
	// (get) Token: 0x06000C69 RID: 3177 RVA: 0x0003D8E9 File Offset: 0x0003BCE9
	// (set) Token: 0x06000C6A RID: 3178 RVA: 0x0003D8F4 File Offset: 0x0003BCF4
	public int yMin
	{
		get
		{
			return this.m_YMin;
		}
		set
		{
			int yMax = this.yMax;
			this.m_YMin = value;
			this.m_Height = yMax - this.m_YMin;
		}
	}

	// Token: 0x170001D8 RID: 472
	// (get) Token: 0x06000C6B RID: 3179 RVA: 0x0003D91D File Offset: 0x0003BD1D
	// (set) Token: 0x06000C6C RID: 3180 RVA: 0x0003D92C File Offset: 0x0003BD2C
	public int xMax
	{
		get
		{
			return this.m_Width + this.m_XMin;
		}
		set
		{
			this.m_Width = value - this.m_XMin;
		}
	}

	// Token: 0x170001D9 RID: 473
	// (get) Token: 0x06000C6D RID: 3181 RVA: 0x0003D93C File Offset: 0x0003BD3C
	// (set) Token: 0x06000C6E RID: 3182 RVA: 0x0003D94B File Offset: 0x0003BD4B
	public int yMax
	{
		get
		{
			return this.m_Height + this.m_YMin;
		}
		set
		{
			this.m_Height = value - this.m_YMin;
		}
	}

	// Token: 0x06000C6F RID: 3183 RVA: 0x0003D95C File Offset: 0x0003BD5C
	public override string ToString()
	{
		object[] args = new object[]
		{
			this.x,
			this.y,
			this.width,
			this.height
		};
		return string.Format("(x:{0:F2}, y:{1:F2}, width:{2:F2}, height:{3:F2})", args);
	}

	// Token: 0x06000C70 RID: 3184 RVA: 0x0003D9B4 File Offset: 0x0003BDB4
	public string ToString(string format)
	{
		object[] args = new object[]
		{
			this.x.ToString(format),
			this.y.ToString(format),
			this.width.ToString(format),
			this.height.ToString(format)
		};
		return string.Format("(x:{0}, y:{1}, width:{2}, height:{3})", args);
	}

	// Token: 0x06000C71 RID: 3185 RVA: 0x0003DA1C File Offset: 0x0003BE1C
	public bool Contains(VInt2 point)
	{
		return point.x >= this.xMin && point.x < this.xMax && point.y >= this.yMin && point.y < this.yMax;
	}

	// Token: 0x06000C72 RID: 3186 RVA: 0x0003DA74 File Offset: 0x0003BE74
	public bool Contains(VInt3 point)
	{
		return point.x >= this.xMin && point.x < this.xMax && point.y >= this.yMin && point.y < this.yMax;
	}

	// Token: 0x06000C73 RID: 3187 RVA: 0x0003DACC File Offset: 0x0003BECC
	public bool Contains(VInt3 point, bool allowInverse)
	{
		if (!allowInverse)
		{
			return this.Contains(point);
		}
		bool flag = false;
		if (((float)this.width < 0f && point.x <= this.xMin && point.x > this.xMax) || ((float)this.width >= 0f && point.x >= this.xMin && point.x < this.xMax))
		{
			flag = true;
		}
		return flag && (((float)this.height < 0f && point.y <= this.yMin && point.y > this.yMax) || ((float)this.height >= 0f && point.y >= this.yMin && point.y < this.yMax));
	}

	// Token: 0x06000C74 RID: 3188 RVA: 0x0003DBCC File Offset: 0x0003BFCC
	private static VRect OrderMinMax(VRect rect)
	{
		if (rect.xMin > rect.xMax)
		{
			int xMin = rect.xMin;
			rect.xMin = rect.xMax;
			rect.xMax = xMin;
		}
		if (rect.yMin > rect.yMax)
		{
			int yMin = rect.yMin;
			rect.yMin = rect.yMax;
			rect.yMax = yMin;
		}
		return rect;
	}

	// Token: 0x06000C75 RID: 3189 RVA: 0x0003DC3C File Offset: 0x0003C03C
	public bool Overlaps(VRect other)
	{
		return other.xMax > this.xMin && other.xMin < this.xMax && other.yMax > this.yMin && other.yMin < this.yMax;
	}

	// Token: 0x06000C76 RID: 3190 RVA: 0x0003DC94 File Offset: 0x0003C094
	public bool Overlaps(VRect other, bool allowInverse)
	{
		VRect rect = this;
		if (allowInverse)
		{
			rect = VRect.OrderMinMax(rect);
			other = VRect.OrderMinMax(other);
		}
		return rect.Overlaps(other);
	}

	// Token: 0x06000C77 RID: 3191 RVA: 0x0003DCC8 File Offset: 0x0003C0C8
	public override int GetHashCode()
	{
		return this.x.GetHashCode() ^ this.width.GetHashCode() << 2 ^ this.y.GetHashCode() >> 2 ^ this.height.GetHashCode() >> 1;
	}

	// Token: 0x06000C78 RID: 3192 RVA: 0x0003DD30 File Offset: 0x0003C130
	public override bool Equals(object other)
	{
		if (!(other is VRect))
		{
			return false;
		}
		VRect vrect = (VRect)other;
		return this.x.Equals(vrect.x) && this.y.Equals(vrect.y) && this.width.Equals(vrect.width) && this.height.Equals(vrect.height);
	}

	// Token: 0x06000C79 RID: 3193 RVA: 0x0003DDB8 File Offset: 0x0003C1B8
	public static bool operator !=(VRect lhs, VRect rhs)
	{
		return lhs.x != rhs.x || lhs.y != rhs.y || lhs.width != rhs.width || lhs.height != rhs.height;
	}

	// Token: 0x06000C7A RID: 3194 RVA: 0x0003DE14 File Offset: 0x0003C214
	public static bool operator ==(VRect lhs, VRect rhs)
	{
		return lhs.x == rhs.x && lhs.y == rhs.y && lhs.width == rhs.width && lhs.height == rhs.height;
	}

	// Token: 0x04000894 RID: 2196
	private int m_XMin;

	// Token: 0x04000895 RID: 2197
	private int m_YMin;

	// Token: 0x04000896 RID: 2198
	private int m_Width;

	// Token: 0x04000897 RID: 2199
	private int m_Height;
}
