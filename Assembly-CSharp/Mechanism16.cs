using System;
using ProtoTable;

// Token: 0x02004328 RID: 17192
public class Mechanism16 : BeMechanism
{
	// Token: 0x06017C96 RID: 97430 RVA: 0x00758116 File Offset: 0x00756516
	public Mechanism16(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017C97 RID: 97431 RVA: 0x00758120 File Offset: 0x00756520
	public override void OnInit()
	{
		this.effectID = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.duration = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.hitPercent = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x06017C98 RID: 97432 RVA: 0x007581A5 File Offset: 0x007565A5
	public override void OnStart()
	{
		base.owner.RegisterEvent(BeEventType.onHit, delegate(object[] args)
		{
			BeActor beActor = (BeActor)args[2];
			if (beActor != null && beActor.GetEntityData() != null && !beActor.GetEntityData().isPet)
			{
				this.OnHit(beActor);
			}
		});
	}

	// Token: 0x06017C99 RID: 97433 RVA: 0x007581C4 File Offset: 0x007565C4
	private void OnHit(BeActor attacker)
	{
		int spellBarDuration = attacker.GetSpellBarDuration(eDungeonCharactorBar.Fire);
		if (spellBarDuration <= 0)
		{
			SpellBar spellBar = attacker.StartSpellBar(eDungeonCharactorBar.Fire, this.duration, true, "爆炸", false);
			spellBar.autoAcc = false;
			spellBar.reverse = true;
		}
		attacker.AddSpellBarProgress(eDungeonCharactorBar.Fire, new VFactor((long)this.hitPercent, 100L));
		int spelBarProgress = attacker.GetSpelBarProgress(eDungeonCharactorBar.Fire);
		if (spelBarProgress >= 1)
		{
			EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(this.effectID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				base.owner.TryAddEntity(tableItem, attacker.GetPosition(), 1);
			}
		}
	}

	// Token: 0x040111C6 RID: 70086
	private int effectID;

	// Token: 0x040111C7 RID: 70087
	private new int duration;

	// Token: 0x040111C8 RID: 70088
	private int hitPercent;

	// Token: 0x040111C9 RID: 70089
	private const string BUFF_TEXT = "爆炸";
}
