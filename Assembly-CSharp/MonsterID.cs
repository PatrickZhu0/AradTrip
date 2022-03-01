using System;

// Token: 0x02004203 RID: 16899
public class MonsterID
{
	// Token: 0x17001FE2 RID: 8162
	// (get) Token: 0x0601762E RID: 95790 RVA: 0x007312B5 File Offset: 0x0072F6B5
	// (set) Token: 0x0601762F RID: 95791 RVA: 0x007312BD File Offset: 0x0072F6BD
	public int resID
	{
		get
		{
			return this.mResID;
		}
		set
		{
			this.mResID = value;
			this._decodeID();
		}
	}

	// Token: 0x17001FE3 RID: 8163
	// (get) Token: 0x06017630 RID: 95792 RVA: 0x007312CC File Offset: 0x0072F6CC
	// (set) Token: 0x06017631 RID: 95793 RVA: 0x007312D4 File Offset: 0x0072F6D4
	public int monsterID
	{
		get
		{
			return this.mMonsterID;
		}
		set
		{
			if (this.mMonsterID != value && value > 0)
			{
				this.mMonsterID = value;
				this._encodeID();
			}
		}
	}

	// Token: 0x17001FE4 RID: 8164
	// (get) Token: 0x06017632 RID: 95794 RVA: 0x007312F6 File Offset: 0x0072F6F6
	// (set) Token: 0x06017633 RID: 95795 RVA: 0x007312FE File Offset: 0x0072F6FE
	public int monsterLevel
	{
		get
		{
			return this.mMonsterLevel;
		}
		set
		{
			if (this.mMonsterLevel != value && value >= 0)
			{
				this.mMonsterLevel = value;
				this._encodeID();
			}
		}
	}

	// Token: 0x17001FE5 RID: 8165
	// (get) Token: 0x06017634 RID: 95796 RVA: 0x00731320 File Offset: 0x0072F720
	// (set) Token: 0x06017635 RID: 95797 RVA: 0x00731328 File Offset: 0x0072F728
	public int monsterTypeID
	{
		get
		{
			return this.mMonsterTypeID;
		}
		set
		{
			if (this.mMonsterTypeID != value && value > 0)
			{
				this.mMonsterTypeID = value;
				this._encodeID();
			}
		}
	}

	// Token: 0x17001FE6 RID: 8166
	// (get) Token: 0x06017636 RID: 95798 RVA: 0x0073134A File Offset: 0x0072F74A
	// (set) Token: 0x06017637 RID: 95799 RVA: 0x00731352 File Offset: 0x0072F752
	public int monsterDiffcute
	{
		get
		{
			return this.mMonsterDiffcute;
		}
		set
		{
			if (this.mMonsterDiffcute != value && value > 0)
			{
				this.mMonsterDiffcute = value;
				this._encodeID();
			}
		}
	}

	// Token: 0x06017638 RID: 95800 RVA: 0x00731374 File Offset: 0x0072F774
	private void _decodeID()
	{
		int num = this.mResID;
		this.mMonsterDiffcute = num % 10;
		num /= 10;
		this.mMonsterTypeID = num % 10;
		num /= 10;
		this.mMonsterLevel = num % 100;
		num /= 100;
		this.mMonsterID = num % 1000;
	}

	// Token: 0x06017639 RID: 95801 RVA: 0x007313C4 File Offset: 0x0072F7C4
	private void _encodeID()
	{
		this.mResID = this.mMonsterID % 1000;
		this.mResID *= 100;
		this.mResID += this.mMonsterLevel % 100;
		this.mResID *= 10;
		this.mResID += this.mMonsterTypeID % 10;
		this.mResID *= 10;
		this.mResID += this.mMonsterDiffcute % 10;
	}

	// Token: 0x04010CC2 RID: 68802
	private const int kDiffculte = 10;

	// Token: 0x04010CC3 RID: 68803
	private const int kTypeID = 10;

	// Token: 0x04010CC4 RID: 68804
	private const int kLevel = 100;

	// Token: 0x04010CC5 RID: 68805
	private const int kID = 1000;

	// Token: 0x04010CC6 RID: 68806
	private int mMonsterID;

	// Token: 0x04010CC7 RID: 68807
	private int mMonsterLevel;

	// Token: 0x04010CC8 RID: 68808
	private int mMonsterTypeID;

	// Token: 0x04010CC9 RID: 68809
	private int mMonsterDiffcute;

	// Token: 0x04010CCA RID: 68810
	private int mResID;
}
