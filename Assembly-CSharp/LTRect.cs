using System;
using UnityEngine;

// Token: 0x0200019E RID: 414
[Serializable]
public class LTRect
{
	// Token: 0x06000CE0 RID: 3296 RVA: 0x00040428 File Offset: 0x0003E828
	public LTRect()
	{
		this.alpha = 1f;
		this.relativeRect = new Rect(0f, 0f, float.PositiveInfinity, float.PositiveInfinity);
		this.color = Color.white;
		this._id = -1;
		this.reset();
		this.rotateEnabled = (this.alphaEnabled = true);
		this._rect = new Rect(0f, 0f, 1f, 1f);
	}

	// Token: 0x06000CE1 RID: 3297 RVA: 0x000404AC File Offset: 0x0003E8AC
	public LTRect(Rect rect)
	{
		this.alpha = 1f;
		this.relativeRect = new Rect(0f, 0f, float.PositiveInfinity, float.PositiveInfinity);
		this.color = Color.white;
		this._id = -1;
		this._rect = rect;
		this.reset();
	}

	// Token: 0x06000CE2 RID: 3298 RVA: 0x00040508 File Offset: 0x0003E908
	public LTRect(float x, float y, float width, float height)
	{
		this.alpha = 1f;
		this.relativeRect = new Rect(0f, 0f, float.PositiveInfinity, float.PositiveInfinity);
		this.color = Color.white;
		this._id = -1;
		this._rect = new Rect(x, y, width, height);
		this.alpha = 1f;
		this.rotation = 0f;
		this.rotateEnabled = (this.alphaEnabled = false);
	}

	// Token: 0x06000CE3 RID: 3299 RVA: 0x00040590 File Offset: 0x0003E990
	public LTRect(float x, float y, float width, float height, float alpha)
	{
		this.alpha = 1f;
		this.relativeRect = new Rect(0f, 0f, float.PositiveInfinity, float.PositiveInfinity);
		this.color = Color.white;
		this._id = -1;
		this._rect = new Rect(x, y, width, height);
		this.alpha = alpha;
		this.rotation = 0f;
		this.rotateEnabled = (this.alphaEnabled = false);
	}

	// Token: 0x06000CE4 RID: 3300 RVA: 0x00040614 File Offset: 0x0003EA14
	public LTRect(float x, float y, float width, float height, float alpha, float rotation)
	{
		this.alpha = 1f;
		this.relativeRect = new Rect(0f, 0f, float.PositiveInfinity, float.PositiveInfinity);
		this.color = Color.white;
		this._id = -1;
		this._rect = new Rect(x, y, width, height);
		this.alpha = alpha;
		this.rotation = rotation;
		this.rotateEnabled = (this.alphaEnabled = false);
		if (rotation != 0f)
		{
			this.rotateEnabled = true;
			this.resetForRotation();
		}
	}

	// Token: 0x06000CE5 RID: 3301 RVA: 0x000406AC File Offset: 0x0003EAAC
	public void reset()
	{
		this.alpha = 1f;
		this.rotation = 0f;
		this.rotateEnabled = (this.alphaEnabled = false);
		this.margin = Vector2.zero;
		this.sizeByHeight = false;
		this.useColor = false;
	}

	// Token: 0x06000CE6 RID: 3302 RVA: 0x000406F8 File Offset: 0x0003EAF8
	public void resetForRotation()
	{
		Vector3 vector;
		vector..ctor(GUI.matrix[0, 0], GUI.matrix[1, 1], GUI.matrix[2, 2]);
		if (this.pivot == Vector2.zero)
		{
			this.pivot = new Vector2((this._rect.x + this._rect.width * 0.5f) * vector.x + GUI.matrix[0, 3], (this._rect.y + this._rect.height * 0.5f) * vector.y + GUI.matrix[1, 3]);
		}
	}

	// Token: 0x06000CE7 RID: 3303 RVA: 0x000407C5 File Offset: 0x0003EBC5
	public LTRect setAlpha(float alpha)
	{
		this.alpha = alpha;
		return this;
	}

	// Token: 0x06000CE8 RID: 3304 RVA: 0x000407CF File Offset: 0x0003EBCF
	public LTRect setColor(Color color)
	{
		this.color = color;
		this.useColor = true;
		return this;
	}

	// Token: 0x06000CE9 RID: 3305 RVA: 0x000407E0 File Offset: 0x0003EBE0
	public LTRect setFontScaleToFit(bool fontScaleToFit)
	{
		this.fontScaleToFit = fontScaleToFit;
		return this;
	}

	// Token: 0x06000CEA RID: 3306 RVA: 0x000407EA File Offset: 0x0003EBEA
	public void setId(int id, int counter)
	{
		this._id = id;
		this.counter = counter;
	}

	// Token: 0x06000CEB RID: 3307 RVA: 0x000407FA File Offset: 0x0003EBFA
	public LTRect setLabel(string str)
	{
		this.labelStr = str;
		return this;
	}

	// Token: 0x06000CEC RID: 3308 RVA: 0x00040804 File Offset: 0x0003EC04
	public LTRect setSizeByHeight(bool sizeByHeight)
	{
		this.sizeByHeight = sizeByHeight;
		return this;
	}

	// Token: 0x06000CED RID: 3309 RVA: 0x0004080E File Offset: 0x0003EC0E
	public LTRect setStyle(GUIStyle style)
	{
		this.style = style;
		return this;
	}

	// Token: 0x06000CEE RID: 3310 RVA: 0x00040818 File Offset: 0x0003EC18
	public LTRect setUseSimpleScale(bool useSimpleScale)
	{
		this.useSimpleScale = useSimpleScale;
		this.relativeRect = new Rect(0f, 0f, (float)Screen.width, (float)Screen.height);
		return this;
	}

	// Token: 0x06000CEF RID: 3311 RVA: 0x00040843 File Offset: 0x0003EC43
	public LTRect setUseSimpleScale(bool useSimpleScale, Rect relativeRect)
	{
		this.useSimpleScale = useSimpleScale;
		this.relativeRect = relativeRect;
		return this;
	}

	// Token: 0x06000CF0 RID: 3312 RVA: 0x00040854 File Offset: 0x0003EC54
	public override string ToString()
	{
		object[] args = new object[]
		{
			"x:",
			this._rect.x,
			" y:",
			this._rect.y,
			" width:",
			this._rect.width,
			" height:",
			this._rect.height
		};
		return string.Concat(args);
	}

	// Token: 0x170001DC RID: 476
	// (get) Token: 0x06000CF1 RID: 3313 RVA: 0x000408DA File Offset: 0x0003ECDA
	public bool hasInitiliazed
	{
		get
		{
			return this._id != -1;
		}
	}

	// Token: 0x170001DD RID: 477
	// (get) Token: 0x06000CF2 RID: 3314 RVA: 0x000408E8 File Offset: 0x0003ECE8
	// (set) Token: 0x06000CF3 RID: 3315 RVA: 0x000408F5 File Offset: 0x0003ECF5
	public float height
	{
		get
		{
			return this._rect.height;
		}
		set
		{
			this._rect.height = value;
		}
	}

	// Token: 0x170001DE RID: 478
	// (get) Token: 0x06000CF4 RID: 3316 RVA: 0x00040903 File Offset: 0x0003ED03
	public int id
	{
		get
		{
			return this._id | this.counter << 16;
		}
	}

	// Token: 0x170001DF RID: 479
	// (get) Token: 0x06000CF5 RID: 3317 RVA: 0x00040918 File Offset: 0x0003ED18
	// (set) Token: 0x06000CF6 RID: 3318 RVA: 0x00040A55 File Offset: 0x0003EE55
	public Rect rect
	{
		get
		{
			if (LTRect.colorTouched)
			{
				LTRect.colorTouched = false;
				GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, 1f);
			}
			if (this.rotateEnabled)
			{
				if (this.rotateFinished)
				{
					this.rotateFinished = false;
					this.rotateEnabled = false;
					this.pivot = Vector2.zero;
				}
				else
				{
					GUIUtility.RotateAroundPivot(this.rotation, this.pivot);
				}
			}
			if (this.alphaEnabled)
			{
				GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, this.alpha);
				LTRect.colorTouched = true;
			}
			if (this.fontScaleToFit)
			{
				if (this.useSimpleScale)
				{
					this.style.fontSize = (int)(this._rect.height * this.relativeRect.height);
				}
				else
				{
					this.style.fontSize = (int)this._rect.height;
				}
			}
			return this._rect;
		}
		set
		{
			this._rect = value;
		}
	}

	// Token: 0x170001E0 RID: 480
	// (get) Token: 0x06000CF7 RID: 3319 RVA: 0x00040A5E File Offset: 0x0003EE5E
	// (set) Token: 0x06000CF8 RID: 3320 RVA: 0x00040A6B File Offset: 0x0003EE6B
	public float width
	{
		get
		{
			return this._rect.width;
		}
		set
		{
			this._rect.width = value;
		}
	}

	// Token: 0x170001E1 RID: 481
	// (get) Token: 0x06000CF9 RID: 3321 RVA: 0x00040A79 File Offset: 0x0003EE79
	// (set) Token: 0x06000CFA RID: 3322 RVA: 0x00040A86 File Offset: 0x0003EE86
	public float x
	{
		get
		{
			return this._rect.x;
		}
		set
		{
			this._rect.x = value;
		}
	}

	// Token: 0x170001E2 RID: 482
	// (get) Token: 0x06000CFB RID: 3323 RVA: 0x00040A94 File Offset: 0x0003EE94
	// (set) Token: 0x06000CFC RID: 3324 RVA: 0x00040AA1 File Offset: 0x0003EEA1
	public float y
	{
		get
		{
			return this._rect.y;
		}
		set
		{
			this._rect.y = value;
		}
	}

	// Token: 0x040008EB RID: 2283
	private int _id;

	// Token: 0x040008EC RID: 2284
	public Rect _rect;

	// Token: 0x040008ED RID: 2285
	public float alpha;

	// Token: 0x040008EE RID: 2286
	public bool alphaEnabled;

	// Token: 0x040008EF RID: 2287
	public Color color;

	// Token: 0x040008F0 RID: 2288
	public static bool colorTouched;

	// Token: 0x040008F1 RID: 2289
	[HideInInspector]
	public int counter;

	// Token: 0x040008F2 RID: 2290
	public bool fontScaleToFit;

	// Token: 0x040008F3 RID: 2291
	public string labelStr;

	// Token: 0x040008F4 RID: 2292
	public Vector2 margin;

	// Token: 0x040008F5 RID: 2293
	public Vector2 pivot;

	// Token: 0x040008F6 RID: 2294
	public Rect relativeRect;

	// Token: 0x040008F7 RID: 2295
	public bool rotateEnabled;

	// Token: 0x040008F8 RID: 2296
	[HideInInspector]
	public bool rotateFinished;

	// Token: 0x040008F9 RID: 2297
	public float rotation;

	// Token: 0x040008FA RID: 2298
	public bool sizeByHeight;

	// Token: 0x040008FB RID: 2299
	public GUIStyle style;

	// Token: 0x040008FC RID: 2300
	public Texture texture;

	// Token: 0x040008FD RID: 2301
	public LTGUI.Element_Type type;

	// Token: 0x040008FE RID: 2302
	public bool useColor;

	// Token: 0x040008FF RID: 2303
	public bool useSimpleScale;
}
