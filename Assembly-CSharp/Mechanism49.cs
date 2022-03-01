using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x020043EE RID: 17390
public class Mechanism49 : BeMechanism
{
	// Token: 0x06018232 RID: 98866 RVA: 0x0078171F File Offset: 0x0077FB1F
	public Mechanism49(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018233 RID: 98867 RVA: 0x0078172C File Offset: 0x0077FB2C
	public override void OnInit()
	{
		this.monsterID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.skillID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x06018234 RID: 98868 RVA: 0x0078178C File Offset: 0x0077FB8C
	public override void OnUpdate(int deltaTime)
	{
		if (base.owner != null && this.monster == null)
		{
			List<BeActor> list = ListPool<BeActor>.Get();
			base.owner.CurrentBeScene.FindMonsterByID(list, this.monsterID, true);
			if (list.Count > 0)
			{
				this.monster = list[0];
				if (this.monster != null)
				{
					this.monster.RegisterEvent(BeEventType.onStateChange, delegate(object[] args)
					{
						ActionState actionState = (ActionState)args[0];
						if (actionState != ActionState.AS_CASTSKILL || (actionState == ActionState.AS_CASTSKILL && this.monster.m_iCurSkillID != this.skillID))
						{
							for (int i = 0; i < this.data.ValueC.Count; i++)
							{
								int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueC[i], this.level, true);
								base.owner.buffController.RemoveBuff(valueFromUnionCell, 0, 0);
							}
						}
					});
				}
			}
			ListPool<BeActor>.Release(list);
		}
	}

	// Token: 0x0401168B RID: 71307
	private int monsterID;

	// Token: 0x0401168C RID: 71308
	private int skillID;

	// Token: 0x0401168D RID: 71309
	private BeActor monster;
}
