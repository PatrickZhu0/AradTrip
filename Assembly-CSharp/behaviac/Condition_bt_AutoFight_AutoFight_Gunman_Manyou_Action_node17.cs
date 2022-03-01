using System;

namespace behaviac
{
	// Token: 0x02002600 RID: 9728
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node17 : Condition
	{
		// Token: 0x06013546 RID: 79174 RVA: 0x005C04C3 File Offset: 0x005BE8C3
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node17()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013547 RID: 79175 RVA: 0x005C04F8 File Offset: 0x005BE8F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF91 RID: 53137
		private int opl_p0;

		// Token: 0x0400CF92 RID: 53138
		private int opl_p1;

		// Token: 0x0400CF93 RID: 53139
		private int opl_p2;

		// Token: 0x0400CF94 RID: 53140
		private int opl_p3;
	}
}
