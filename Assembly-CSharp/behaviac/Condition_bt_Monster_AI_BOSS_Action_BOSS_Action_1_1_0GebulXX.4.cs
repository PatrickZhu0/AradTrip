using System;

namespace behaviac
{
	// Token: 0x02002F38 RID: 12088
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_1_1_0GebulXX_Action_node9 : Condition
	{
		// Token: 0x06014741 RID: 83777 RVA: 0x00627576 File Offset: 0x00625976
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_1_1_0GebulXX_Action_node9()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06014742 RID: 83778 RVA: 0x006275AC File Offset: 0x006259AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0B1 RID: 57521
		private int opl_p0;

		// Token: 0x0400E0B2 RID: 57522
		private int opl_p1;

		// Token: 0x0400E0B3 RID: 57523
		private int opl_p2;

		// Token: 0x0400E0B4 RID: 57524
		private int opl_p3;
	}
}
