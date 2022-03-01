using System;

// Token: 0x0200432D RID: 17197
public class Mechanism163 : BeMechanism
{
	// Token: 0x06017CAA RID: 97450 RVA: 0x007589A5 File Offset: 0x00756DA5
	public Mechanism163(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017CAB RID: 97451 RVA: 0x007589C4 File Offset: 0x00756DC4
	public override void OnInit()
	{
		this.m_durTime = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.m_speedRelated = (TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true) == 0);
		this.m_text = this.data.StringValueA[0];
	}

	// Token: 0x06017CAC RID: 97452 RVA: 0x00758A44 File Offset: 0x00756E44
	public override void OnStart()
	{
		if (this.m_speedRelated)
		{
			this.m_spellBar = base.owner.StartSpellBar(eDungeonCharactorBar.Progress, this.m_durTime, true, this.m_text, false);
		}
		else
		{
			this.m_spellBar = base.owner.StartSpellBar(eDungeonCharactorBar.Buff, this.m_durTime, true, this.m_text, false);
		}
		if (this.m_spellBar != null)
		{
			this.m_spellBar.alwaysRefreshUI = true;
		}
	}

	// Token: 0x06017CAD RID: 97453 RVA: 0x00758AB9 File Offset: 0x00756EB9
	public override void OnFinish()
	{
		base.OnFinish();
		if (this.m_spellBar != null)
		{
			if (this.m_speedRelated)
			{
				base.owner.StopSpellBar(eDungeonCharactorBar.Progress, true);
			}
			else
			{
				base.owner.StopSpellBar(eDungeonCharactorBar.Buff, true);
			}
		}
	}

	// Token: 0x040111DC RID: 70108
	private int m_durTime;

	// Token: 0x040111DD RID: 70109
	private string m_text = string.Empty;

	// Token: 0x040111DE RID: 70110
	private SpellBar m_spellBar;

	// Token: 0x040111DF RID: 70111
	private bool m_speedRelated = true;
}
