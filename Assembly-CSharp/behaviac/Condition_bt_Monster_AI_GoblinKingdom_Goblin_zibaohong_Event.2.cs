using System;

namespace behaviac
{
	// Token: 0x0200336F RID: 13167
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_zibaohong_Event_node3 : Condition
	{
		// Token: 0x06014F3C RID: 85820 RVA: 0x00650133 File Offset: 0x0064E533
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_zibaohong_Event_node3()
		{
			this.opl_p0 = 800;
			this.opl_p1 = 800;
			this.opl_p2 = 800;
			this.opl_p3 = 800;
		}

		// Token: 0x06014F3D RID: 85821 RVA: 0x00650168 File Offset: 0x0064E568
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E802 RID: 59394
		private int opl_p0;

		// Token: 0x0400E803 RID: 59395
		private int opl_p1;

		// Token: 0x0400E804 RID: 59396
		private int opl_p2;

		// Token: 0x0400E805 RID: 59397
		private int opl_p3;
	}
}
