using System;

namespace behaviac
{
	// Token: 0x02003301 RID: 13057
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node16 : Condition
	{
		// Token: 0x06014E6C RID: 85612 RVA: 0x0064C2A1 File Offset: 0x0064A6A1
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node16()
		{
			this.opl_p0 = 1000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06014E6D RID: 85613 RVA: 0x0064C2D8 File Offset: 0x0064A6D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E759 RID: 59225
		private int opl_p0;

		// Token: 0x0400E75A RID: 59226
		private int opl_p1;

		// Token: 0x0400E75B RID: 59227
		private int opl_p2;

		// Token: 0x0400E75C RID: 59228
		private int opl_p3;
	}
}
