using System;

namespace behaviac
{
	// Token: 0x02002A94 RID: 10900
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_li_node9 : Condition
	{
		// Token: 0x06013E4A RID: 81482 RVA: 0x005F74B2 File Offset: 0x005F58B2
		public Condition_bt_Guanka_apc_Mofashi_li_node9()
		{
			this.opl_p0 = 4500;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013E4B RID: 81483 RVA: 0x005F74E8 File Offset: 0x005F58E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8BE RID: 55486
		private int opl_p0;

		// Token: 0x0400D8BF RID: 55487
		private int opl_p1;

		// Token: 0x0400D8C0 RID: 55488
		private int opl_p2;

		// Token: 0x0400D8C1 RID: 55489
		private int opl_p3;
	}
}
