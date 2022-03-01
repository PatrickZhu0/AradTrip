using System;

// Token: 0x02004394 RID: 17300
public class Mechanism2089 : BeMechanism
{
	// Token: 0x06017FC4 RID: 98244 RVA: 0x0076EC42 File Offset: 0x0076D042
	public Mechanism2089(int id, int level) : base(id, level)
	{
	}

	// Token: 0x17002005 RID: 8197
	// (get) Token: 0x06017FC5 RID: 98245 RVA: 0x0076EC58 File Offset: 0x0076D058
	public int ChaserMaxCount
	{
		get
		{
			return this.m_ChaserMaxCount;
		}
	}

	// Token: 0x17002006 RID: 8198
	// (get) Token: 0x06017FC6 RID: 98246 RVA: 0x0076EC60 File Offset: 0x0076D060
	public int ChaserCreateProb
	{
		get
		{
			return this.m_ChaserCreateProb;
		}
	}

	// Token: 0x17002007 RID: 8199
	// (get) Token: 0x06017FC7 RID: 98247 RVA: 0x0076EC68 File Offset: 0x0076D068
	public int BigChaserCreateProb
	{
		get
		{
			return this.m_BigChaserCreateProb;
		}
	}

	// Token: 0x17002008 RID: 8200
	// (get) Token: 0x06017FC8 RID: 98248 RVA: 0x0076EC70 File Offset: 0x0076D070
	public Mechanism2089.ComboScale ComboChaserScale
	{
		get
		{
			return this.m_ComboChaserScale;
		}
	}

	// Token: 0x17002009 RID: 8201
	// (get) Token: 0x06017FC9 RID: 98249 RVA: 0x0076EC78 File Offset: 0x0076D078
	public int KnifeCount
	{
		get
		{
			return this.m_knifeCount;
		}
	}

	// Token: 0x06017FCA RID: 98250 RVA: 0x0076EC80 File Offset: 0x0076D080
	public int ChaserScale(int i)
	{
		if (i >= this.m_ChaserScale.Length)
		{
			return 0;
		}
		return this.m_ChaserScale[i];
	}

	// Token: 0x06017FCB RID: 98251 RVA: 0x0076EC9C File Offset: 0x0076D09C
	public override void OnInit()
	{
		if (this.data.ValueA.Count > 0)
		{
			this.m_ChaserMaxCount = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		}
		if (this.data.ValueB.Count > 0)
		{
			this.m_ChaserCreateProb = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		}
		if (this.data.ValueC.Count > 0)
		{
			this.m_ComboChaserScale.combo = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
			this.m_ComboChaserScale.scale = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.data.ValueC[1], this.level, true), GlobalLogic.VALUE_1000);
		}
		else
		{
			this.m_ComboChaserScale.combo = -1;
			this.m_ComboChaserScale.scale = VFactor.zero;
		}
		if (this.data.ValueD.Count > 0)
		{
			for (int i = 0; i < this.data.ValueD.Count; i++)
			{
				this.m_ChaserScale[i] = TableManager.GetValueFromUnionCell(this.data.ValueD[i], this.level, true);
			}
		}
		else
		{
			for (int j = 0; j < 5; j++)
			{
				this.m_ChaserScale[j] = 0;
			}
		}
		if (this.data.ValueE.Count > 0)
		{
			this.m_knifeCount = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		}
		if (this.data.ValueF.Count > 0)
		{
			this.m_BigChaserCreateProb = TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true);
		}
		if (this.data.ValueG.Count > 0)
		{
			this.m_ChaserCreateTime = TableManager.GetValueFromUnionCell(this.data.ValueG[0], this.level, true);
		}
	}

	// Token: 0x06017FCC RID: 98252 RVA: 0x0076EEFB File Offset: 0x0076D2FB
	public override void OnStart()
	{
		base.OnStart();
		this.GetChaserMgr();
		if (this.mChaserMgr == null)
		{
			return;
		}
		this.mChaserMgr.OffsetChaserCreateTime(this.m_ChaserCreateTime);
		this.m_isOffsetCreateTime = true;
	}

	// Token: 0x06017FCD RID: 98253 RVA: 0x0076EF2D File Offset: 0x0076D32D
	public override void OnFinish()
	{
		base.OnFinish();
		this.GetChaserMgr();
		if (this.mChaserMgr == null)
		{
			return;
		}
		if (this.m_isOffsetCreateTime)
		{
			this.mChaserMgr.OffsetChaserCreateTime(-this.m_ChaserCreateTime);
			this.m_isOffsetCreateTime = false;
		}
	}

	// Token: 0x06017FCE RID: 98254 RVA: 0x0076EF6C File Offset: 0x0076D36C
	private void GetChaserMgr()
	{
		if (base.owner == null)
		{
			return;
		}
		if (this.mChaserMgr != null)
		{
			return;
		}
		BeMechanism mechanism = base.owner.GetMechanism(Mechanism2072.ChaserMgrID);
		if (mechanism == null)
		{
			return;
		}
		Mechanism2072 mechanism2 = mechanism as Mechanism2072;
		this.mChaserMgr = mechanism2;
	}

	// Token: 0x0401145F RID: 70751
	private int m_ChaserMaxCount;

	// Token: 0x04011460 RID: 70752
	private int m_ChaserCreateProb;

	// Token: 0x04011461 RID: 70753
	private int m_BigChaserCreateProb;

	// Token: 0x04011462 RID: 70754
	private Mechanism2089.ComboScale m_ComboChaserScale;

	// Token: 0x04011463 RID: 70755
	private int[] m_ChaserScale = new int[5];

	// Token: 0x04011464 RID: 70756
	private int m_knifeCount;

	// Token: 0x04011465 RID: 70757
	private int m_ChaserCreateTime;

	// Token: 0x04011466 RID: 70758
	private bool m_isOffsetCreateTime;

	// Token: 0x04011467 RID: 70759
	private Mechanism2072 mChaserMgr;

	// Token: 0x02004395 RID: 17301
	public struct ComboScale
	{
		// Token: 0x04011468 RID: 70760
		public int combo;

		// Token: 0x04011469 RID: 70761
		public VFactor scale;
	}
}
