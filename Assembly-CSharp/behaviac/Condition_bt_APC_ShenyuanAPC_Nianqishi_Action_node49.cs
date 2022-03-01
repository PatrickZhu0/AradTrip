using System;

namespace behaviac
{
	// Token: 0x02001EAD RID: 7853
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node49 : Condition
	{
		// Token: 0x06012702 RID: 75522 RVA: 0x005649EE File Offset: 0x00562DEE
		public Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node49()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012703 RID: 75523 RVA: 0x00564A24 File Offset: 0x00562E24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0EE RID: 49390
		private int opl_p0;

		// Token: 0x0400C0EF RID: 49391
		private int opl_p1;

		// Token: 0x0400C0F0 RID: 49392
		private int opl_p2;

		// Token: 0x0400C0F1 RID: 49393
		private int opl_p3;
	}
}
