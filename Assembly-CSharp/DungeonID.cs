using System;

// Token: 0x020041E0 RID: 16864
public class DungeonID
{
	// Token: 0x060174F6 RID: 95478 RVA: 0x0072C5CD File Offset: 0x0072A9CD
	public DungeonID(int id)
	{
		this.dungeonID = id;
	}

	// Token: 0x17001FB6 RID: 8118
	// (get) Token: 0x060174F7 RID: 95479 RVA: 0x0072C5DC File Offset: 0x0072A9DC
	// (set) Token: 0x060174F8 RID: 95480 RVA: 0x0072C5E4 File Offset: 0x0072A9E4
	public int dungeonID
	{
		get
		{
			return this.mDungeonID;
		}
		set
		{
			if (this.mDungeonID != value)
			{
				this.mDungeonID = value;
				this._decode();
			}
		}
	}

	// Token: 0x17001FB7 RID: 8119
	// (get) Token: 0x060174F9 RID: 95481 RVA: 0x0072C5FF File Offset: 0x0072A9FF
	public int dungeonIDWithOutDiff
	{
		get
		{
			return this._encode(DungeonID.eEncodeFlag.WithoutDiff);
		}
	}

	// Token: 0x17001FB8 RID: 8120
	// (get) Token: 0x060174FA RID: 95482 RVA: 0x0072C608 File Offset: 0x0072AA08
	public int dungeonIDWithOutPrestory
	{
		get
		{
			return this._encode(DungeonID.eEncodeFlag.WithoutPrestory);
		}
	}

	// Token: 0x17001FB9 RID: 8121
	// (get) Token: 0x060174FB RID: 95483 RVA: 0x0072C611 File Offset: 0x0072AA11
	// (set) Token: 0x060174FC RID: 95484 RVA: 0x0072C619 File Offset: 0x0072AA19
	public int chapterID
	{
		get
		{
			return this.mChapterID;
		}
		set
		{
			if (this.mChapterID != value)
			{
				this.mChapterID = value;
				this.mDungeonID = this._encode(DungeonID.eEncodeFlag.All);
			}
		}
	}

	// Token: 0x17001FBA RID: 8122
	// (get) Token: 0x060174FD RID: 95485 RVA: 0x0072C63C File Offset: 0x0072AA3C
	// (set) Token: 0x060174FE RID: 95486 RVA: 0x0072C644 File Offset: 0x0072AA44
	public int levelID
	{
		get
		{
			return this.mLevelID;
		}
		set
		{
			if (this.mLevelID != value)
			{
				this.mLevelID = value;
				this.mDungeonID = this._encode(DungeonID.eEncodeFlag.All);
			}
		}
	}

	// Token: 0x17001FBB RID: 8123
	// (get) Token: 0x060174FF RID: 95487 RVA: 0x0072C667 File Offset: 0x0072AA67
	// (set) Token: 0x06017500 RID: 95488 RVA: 0x0072C66F File Offset: 0x0072AA6F
	public int prestoryID
	{
		get
		{
			return this.mPrestoryID;
		}
		set
		{
			if (this.mPrestoryID != value)
			{
				this.mPrestoryID = value;
				this.mDungeonID = this._encode(DungeonID.eEncodeFlag.All);
			}
		}
	}

	// Token: 0x17001FBC RID: 8124
	// (get) Token: 0x06017501 RID: 95489 RVA: 0x0072C692 File Offset: 0x0072AA92
	// (set) Token: 0x06017502 RID: 95490 RVA: 0x0072C69A File Offset: 0x0072AA9A
	public int diffID
	{
		get
		{
			return this.mDiffID;
		}
		set
		{
			if (this.mDiffID != value)
			{
				this.mDiffID = value;
				this.mDungeonID = this._encode(DungeonID.eEncodeFlag.All);
			}
		}
	}

	// Token: 0x06017503 RID: 95491 RVA: 0x0072C6C0 File Offset: 0x0072AAC0
	private void _decode()
	{
		int num = this.mDungeonID;
		this.mDiffID = num % 10;
		num /= 10;
		this.mPrestoryID = num % 100;
		num /= 100;
		this.mLevelID = num % 100;
		num /= 100;
		this.mChapterID = num;
	}

	// Token: 0x06017504 RID: 95492 RVA: 0x0072C708 File Offset: 0x0072AB08
	private int _encode(DungeonID.eEncodeFlag flag = DungeonID.eEncodeFlag.All)
	{
		int num = 0;
		if ((flag & DungeonID.eEncodeFlag.Chapter) > (DungeonID.eEncodeFlag)0)
		{
			num += this.mChapterID;
		}
		num *= 100;
		if ((flag & DungeonID.eEncodeFlag.Level) > (DungeonID.eEncodeFlag)0)
		{
			num += this.mLevelID;
		}
		num *= 100;
		if ((flag & DungeonID.eEncodeFlag.Prestory) > (DungeonID.eEncodeFlag)0)
		{
			num += this.mPrestoryID;
		}
		num *= 10;
		if ((flag & DungeonID.eEncodeFlag.Diff) > (DungeonID.eEncodeFlag)0)
		{
			num += this.mDiffID;
		}
		return num;
	}

	// Token: 0x04010C16 RID: 68630
	private int mChapterID;

	// Token: 0x04010C17 RID: 68631
	private int mLevelID;

	// Token: 0x04010C18 RID: 68632
	private int mPrestoryID;

	// Token: 0x04010C19 RID: 68633
	private int mDiffID;

	// Token: 0x04010C1A RID: 68634
	protected int mDungeonID;

	// Token: 0x020041E1 RID: 16865
	private enum eEncodeFlag
	{
		// Token: 0x04010C1C RID: 68636
		Chapter = 1,
		// Token: 0x04010C1D RID: 68637
		Level,
		// Token: 0x04010C1E RID: 68638
		Prestory = 4,
		// Token: 0x04010C1F RID: 68639
		Diff = 8,
		// Token: 0x04010C20 RID: 68640
		WithoutDiff = 7,
		// Token: 0x04010C21 RID: 68641
		WithoutPrestory = 3,
		// Token: 0x04010C22 RID: 68642
		All = 15
	}
}
