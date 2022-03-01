using System;
using GameClient;

// Token: 0x02004340 RID: 17216
public class Mechanism2010 : BeMechanism
{
	// Token: 0x06017D46 RID: 97606 RVA: 0x0075CE2E File Offset: 0x0075B22E
	public Mechanism2010(int id, int lv) : base(id, lv)
	{
	}

	// Token: 0x06017D47 RID: 97607 RVA: 0x0075CE38 File Offset: 0x0075B238
	public override void OnInit()
	{
		base.OnInit();
		this.time = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x06017D48 RID: 97608 RVA: 0x0075CE68 File Offset: 0x0075B268
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.CurrentBeScene.RegisterEvent(BeEventSceneType.onClear, delegate(object[] args)
		{
			int num = base.owner.CurrentBeScene.mBattle.dungeonManager.GetDungeonDataManager().AllFightTime(true);
			if (num <= this.time * 1000 && base.owner.CurrentBeBattle.HasFlag(BattleFlagType.Eff_Devilddom_hidden_room))
			{
				base.owner.CurrentBeScene.OpenEggDoor();
				PVEBattle pvebattle = base.owner.CurrentBeBattle as PVEBattle;
				if (pvebattle != null)
				{
					pvebattle.SetEggRoom(true);
				}
			}
		});
	}

	// Token: 0x04011268 RID: 70248
	private int time;
}
