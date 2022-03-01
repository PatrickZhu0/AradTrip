using System;

namespace behaviac
{
	// Token: 0x02001E51 RID: 7761
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node12 : Condition
	{
		// Token: 0x0601264F RID: 75343 RVA: 0x005602E0 File Offset: 0x0055E6E0
		public Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node12()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012650 RID: 75344 RVA: 0x00560314 File Offset: 0x0055E714
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C036 RID: 49206
		private int opl_p0;

		// Token: 0x0400C037 RID: 49207
		private int opl_p1;

		// Token: 0x0400C038 RID: 49208
		private int opl_p2;

		// Token: 0x0400C039 RID: 49209
		private int opl_p3;
	}
}
