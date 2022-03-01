using System;
using UnityEngine;

// Token: 0x0200019C RID: 412
public class LTGUI
{
	// Token: 0x06000CCF RID: 3279 RVA: 0x0003F9F0 File Offset: 0x0003DDF0
	public static bool checkOnScreen(Rect rect)
	{
		bool flag = rect.x + rect.width < 0f;
		bool flag2 = rect.x > (float)Screen.width;
		bool flag3 = rect.y > (float)Screen.height;
		bool flag4 = rect.y + rect.height < 0f;
		return !flag && !flag2 && !flag3 && !flag4;
	}

	// Token: 0x06000CD0 RID: 3280 RVA: 0x0003FA64 File Offset: 0x0003DE64
	public static bool checkWithinRect(Vector2 vec2, Rect rect)
	{
		vec2.y = (float)Screen.height - vec2.y;
		return vec2.x > rect.x && vec2.x < rect.x + rect.width && vec2.y > rect.y && vec2.y < rect.y + rect.height;
	}

	// Token: 0x06000CD1 RID: 3281 RVA: 0x0003FAE4 File Offset: 0x0003DEE4
	public static void destroy(int id)
	{
		int num = id & 65535;
		int num2 = id >> 16;
		if (id >= 0 && LTGUI.levels[num] != null && LTGUI.levels[num].hasInitiliazed && LTGUI.levels[num].counter == num2)
		{
			LTGUI.levels[num] = null;
		}
	}

	// Token: 0x06000CD2 RID: 3282 RVA: 0x0003FB3C File Offset: 0x0003DF3C
	public static void destroyAll(int depth)
	{
		int num = depth * LTGUI.RECTS_PER_LEVEL + LTGUI.RECTS_PER_LEVEL;
		int num2 = depth * LTGUI.RECTS_PER_LEVEL;
		while (LTGUI.levels != null && num2 < num)
		{
			LTGUI.levels[num2] = null;
			num2++;
		}
	}

	// Token: 0x06000CD3 RID: 3283 RVA: 0x0003FB84 File Offset: 0x0003DF84
	public static LTRect element(LTRect rect, int depth)
	{
		LTGUI.isGUIEnabled = true;
		LTGUI.init();
		int num = depth * LTGUI.RECTS_PER_LEVEL + LTGUI.RECTS_PER_LEVEL;
		int num2 = 0;
		if (rect != null)
		{
			LTGUI.destroy(rect.id);
		}
		if (rect != null && rect.type == LTGUI.Element_Type.Label && rect.style != null && rect.style.normal.textColor.a <= 0f)
		{
			Debug.LogWarning("Your GUI normal color has an alpha of zero, and will not be rendered.");
		}
		if (rect != null && rect.relativeRect.width == float.PositiveInfinity)
		{
			rect.relativeRect = new Rect(0f, 0f, (float)Screen.width, (float)Screen.height);
		}
		for (int i = depth * LTGUI.RECTS_PER_LEVEL; i < num; i++)
		{
			LTGUI.r = LTGUI.levels[i];
			if (LTGUI.r == null)
			{
				LTGUI.r = rect;
				if (LTGUI.r != null)
				{
					LTGUI.r.rotateEnabled = true;
					LTGUI.r.alphaEnabled = true;
					LTGUI.r.setId(i, LTGUI.global_counter);
				}
				LTGUI.levels[i] = LTGUI.r;
				if (num2 >= LTGUI.levelDepths[depth])
				{
					LTGUI.levelDepths[depth] = num2 + 1;
				}
				LTGUI.global_counter++;
				return LTGUI.r;
			}
			num2++;
		}
		Debug.LogError("You ran out of GUI Element spaces");
		return null;
	}

	// Token: 0x06000CD4 RID: 3284 RVA: 0x0003FCEC File Offset: 0x0003E0EC
	public static Vector2 firstTouch()
	{
		if (Input.touchCount > 0)
		{
			return Input.touches[0].position;
		}
		if (Input.GetMouseButton(0))
		{
			return Input.mousePosition;
		}
		return new Vector2(float.NegativeInfinity, float.NegativeInfinity);
	}

	// Token: 0x06000CD5 RID: 3285 RVA: 0x0003FD3C File Offset: 0x0003E13C
	public static bool hasNoOverlap(Rect rect, int depth)
	{
		LTGUI.initRectCheck();
		bool result = true;
		bool flag = false;
		for (int i = 0; i < LTGUI.buttonLevels.Length; i++)
		{
			if (LTGUI.buttonLevels[i] >= 0)
			{
				if (LTGUI.buttonLastFrame[i] + 1 < Time.frameCount)
				{
					LTGUI.buttonLevels[i] = -1;
				}
				else if (LTGUI.buttonLevels[i] > depth && LTGUI.pressedWithinRect(LTGUI.buttons[i]))
				{
					result = false;
				}
			}
			if (!flag && LTGUI.buttonLevels[i] < 0)
			{
				flag = true;
				LTGUI.buttonLevels[i] = depth;
				LTGUI.buttons[i] = rect;
				LTGUI.buttonLastFrame[i] = Time.frameCount;
			}
		}
		return result;
	}

	// Token: 0x06000CD6 RID: 3286 RVA: 0x0003FDFB File Offset: 0x0003E1FB
	public static void init()
	{
		if (LTGUI.levels == null)
		{
			LTGUI.levels = new LTRect[LTGUI.RECT_LEVELS * LTGUI.RECTS_PER_LEVEL];
			LTGUI.levelDepths = new int[LTGUI.RECT_LEVELS];
		}
	}

	// Token: 0x06000CD7 RID: 3287 RVA: 0x0003FE2C File Offset: 0x0003E22C
	public static void initRectCheck()
	{
		if (LTGUI.buttons == null)
		{
			LTGUI.buttons = new Rect[LTGUI.BUTTONS_MAX];
			LTGUI.buttonLevels = new int[LTGUI.BUTTONS_MAX];
			LTGUI.buttonLastFrame = new int[LTGUI.BUTTONS_MAX];
			for (int i = 0; i < LTGUI.buttonLevels.Length; i++)
			{
				LTGUI.buttonLevels[i] = -1;
			}
		}
	}

	// Token: 0x06000CD8 RID: 3288 RVA: 0x0003FE90 File Offset: 0x0003E290
	public static LTRect label(LTRect rect, string label, int depth)
	{
		rect.type = LTGUI.Element_Type.Label;
		rect.labelStr = label;
		return LTGUI.element(rect, depth);
	}

	// Token: 0x06000CD9 RID: 3289 RVA: 0x0003FEA7 File Offset: 0x0003E2A7
	public static LTRect label(Rect rect, string label, int depth)
	{
		return LTGUI.label(new LTRect(rect), label, depth);
	}

	// Token: 0x06000CDA RID: 3290 RVA: 0x0003FEB8 File Offset: 0x0003E2B8
	public static bool pressedWithinRect(Rect rect)
	{
		Vector2 vector = LTGUI.firstTouch();
		if (vector.x < 0f)
		{
			return false;
		}
		float num = (float)Screen.height - vector.y;
		return vector.x > rect.x && vector.x < rect.x + rect.width && num > rect.y && num < rect.y + rect.height;
	}

	// Token: 0x06000CDB RID: 3291 RVA: 0x0003FF40 File Offset: 0x0003E340
	public static void reset()
	{
		if (LTGUI.isGUIEnabled)
		{
			LTGUI.isGUIEnabled = false;
			for (int i = 0; i < LTGUI.levels.Length; i++)
			{
				LTGUI.levels[i] = null;
			}
			for (int j = 0; j < LTGUI.levelDepths.Length; j++)
			{
				LTGUI.levelDepths[j] = 0;
			}
		}
	}

	// Token: 0x06000CDC RID: 3292 RVA: 0x0003FF9D File Offset: 0x0003E39D
	public static LTRect texture(LTRect rect, Texture texture, int depth)
	{
		rect.type = LTGUI.Element_Type.Texture;
		rect.texture = texture;
		return LTGUI.element(rect, depth);
	}

	// Token: 0x06000CDD RID: 3293 RVA: 0x0003FFB4 File Offset: 0x0003E3B4
	public static LTRect texture(Rect rect, Texture texture, int depth)
	{
		return LTGUI.texture(new LTRect(rect), texture, depth);
	}

	// Token: 0x06000CDE RID: 3294 RVA: 0x0003FFC4 File Offset: 0x0003E3C4
	public static void update(int updateLevel)
	{
		if (LTGUI.isGUIEnabled)
		{
			LTGUI.init();
			if (LTGUI.levelDepths[updateLevel] > 0)
			{
				LTGUI.color = GUI.color;
				int num = updateLevel * LTGUI.RECTS_PER_LEVEL;
				int num2 = num + LTGUI.levelDepths[updateLevel];
				for (int i = num; i < num2; i++)
				{
					LTGUI.r = LTGUI.levels[i];
					if (LTGUI.r != null)
					{
						if (LTGUI.r.useColor)
						{
							GUI.color = LTGUI.r.color;
						}
						if (LTGUI.r.type == LTGUI.Element_Type.Label)
						{
							if (LTGUI.r.style != null)
							{
								GUI.skin.label = LTGUI.r.style;
							}
							if (LTGUI.r.useSimpleScale)
							{
								GUI.Label(new Rect((LTGUI.r.rect.x + LTGUI.r.margin.x + LTGUI.r.relativeRect.x) * LTGUI.r.relativeRect.width, (LTGUI.r.rect.y + LTGUI.r.margin.y + LTGUI.r.relativeRect.y) * LTGUI.r.relativeRect.height, LTGUI.r.rect.width * LTGUI.r.relativeRect.width, LTGUI.r.rect.height * LTGUI.r.relativeRect.height), LTGUI.r.labelStr);
							}
							else
							{
								GUI.Label(new Rect(LTGUI.r.rect.x + LTGUI.r.margin.x, LTGUI.r.rect.y + LTGUI.r.margin.y, LTGUI.r.rect.width, LTGUI.r.rect.height), LTGUI.r.labelStr);
							}
						}
						else if (LTGUI.r.type == LTGUI.Element_Type.Texture && LTGUI.r.texture != null)
						{
							Vector2 vector = LTGUI.r.useSimpleScale ? new Vector2(0f, LTGUI.r.rect.height * LTGUI.r.relativeRect.height) : new Vector2(LTGUI.r.rect.width, LTGUI.r.rect.height);
							if (LTGUI.r.sizeByHeight)
							{
								vector.x = (float)LTGUI.r.texture.width / (float)LTGUI.r.texture.height * vector.y;
							}
							if (LTGUI.r.useSimpleScale)
							{
								GUI.DrawTexture(new Rect((LTGUI.r.rect.x + LTGUI.r.margin.x + LTGUI.r.relativeRect.x) * LTGUI.r.relativeRect.width, (LTGUI.r.rect.y + LTGUI.r.margin.y + LTGUI.r.relativeRect.y) * LTGUI.r.relativeRect.height, vector.x, vector.y), LTGUI.r.texture);
							}
							else
							{
								GUI.DrawTexture(new Rect(LTGUI.r.rect.x + LTGUI.r.margin.x, LTGUI.r.rect.y + LTGUI.r.margin.y, vector.x, vector.y), LTGUI.r.texture);
							}
						}
					}
				}
				GUI.color = LTGUI.color;
			}
		}
	}

	// Token: 0x040008DC RID: 2268
	private static int[] buttonLastFrame;

	// Token: 0x040008DD RID: 2269
	private static int[] buttonLevels;

	// Token: 0x040008DE RID: 2270
	private static Rect[] buttons;

	// Token: 0x040008DF RID: 2271
	public static int BUTTONS_MAX = 24;

	// Token: 0x040008E0 RID: 2272
	private static Color color = Color.white;

	// Token: 0x040008E1 RID: 2273
	private static int global_counter = 0;

	// Token: 0x040008E2 RID: 2274
	private static bool isGUIEnabled = false;

	// Token: 0x040008E3 RID: 2275
	private static int[] levelDepths;

	// Token: 0x040008E4 RID: 2276
	private static LTRect[] levels;

	// Token: 0x040008E5 RID: 2277
	private static LTRect r;

	// Token: 0x040008E6 RID: 2278
	public static int RECT_LEVELS = 5;

	// Token: 0x040008E7 RID: 2279
	public static int RECTS_PER_LEVEL = 10;

	// Token: 0x0200019D RID: 413
	public enum Element_Type
	{
		// Token: 0x040008E9 RID: 2281
		Texture,
		// Token: 0x040008EA RID: 2282
		Label
	}
}
