using System;

namespace behaviac
{
	// Token: 0x02002BA6 RID: 11174
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node5 : Condition
	{
		// Token: 0x06014054 RID: 82004 RVA: 0x006035A2 File Offset: 0x006019A2
		public Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node5()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 2000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06014055 RID: 82005 RVA: 0x006035D8 File Offset: 0x006019D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA4C RID: 55884
		private int opl_p0;

		// Token: 0x0400DA4D RID: 55885
		private int opl_p1;

		// Token: 0x0400DA4E RID: 55886
		private int opl_p2;

		// Token: 0x0400DA4F RID: 55887
		private int opl_p3;
	}
}
