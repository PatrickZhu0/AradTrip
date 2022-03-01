using System;
using System.Collections.Generic;

// Token: 0x02004275 RID: 17013
public class Mechanism1042 : BeMechanism
{
	// Token: 0x060178B3 RID: 96435 RVA: 0x0073EACB File Offset: 0x0073CECB
	public Mechanism1042(int id, int level) : base(id, level)
	{
	}

	// Token: 0x060178B4 RID: 96436 RVA: 0x0073EAD8 File Offset: 0x0073CED8
	public override void OnInit()
	{
		base.OnInit();
		this.entityId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.m_CreateOnGround = (TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true) != 0);
	}

	// Token: 0x060178B5 RID: 96437 RVA: 0x0073EB47 File Offset: 0x0073CF47
	public override void OnStart()
	{
		base.OnStart();
		this.CreateEntity();
	}

	// Token: 0x060178B6 RID: 96438 RVA: 0x0073EB58 File Offset: 0x0073CF58
	private void CreateEntity()
	{
		if (base.owner.CurrentBeBattle == null)
		{
			return;
		}
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		if (allPlayers != null)
		{
			for (int i = 0; i < allPlayers.Count; i++)
			{
				if (allPlayers[i].playerActor != null)
				{
					VInt3 position = allPlayers[i].playerActor.GetPosition();
					if (this.m_CreateOnGround)
					{
						position.z = 0;
					}
					base.owner.AddEntity(this.entityId, position, 1, 0);
				}
			}
		}
	}

	// Token: 0x04010EAE RID: 69294
	private int entityId;

	// Token: 0x04010EAF RID: 69295
	protected bool m_CreateOnGround;
}
