using System;

namespace behaviac
{
	// Token: 0x02003305 RID: 13061
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node17 : Condition
	{
		// Token: 0x06014E74 RID: 85620 RVA: 0x0064C3D9 File Offset: 0x0064A7D9
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node17()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06014E75 RID: 85621 RVA: 0x0064C410 File Offset: 0x0064A810
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E762 RID: 59234
		private int opl_p0;

		// Token: 0x0400E763 RID: 59235
		private int opl_p1;

		// Token: 0x0400E764 RID: 59236
		private int opl_p2;

		// Token: 0x0400E765 RID: 59237
		private int opl_p3;
	}
}
