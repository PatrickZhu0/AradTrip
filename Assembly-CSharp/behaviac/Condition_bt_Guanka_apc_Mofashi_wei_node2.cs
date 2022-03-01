using System;

namespace behaviac
{
	// Token: 0x02002AA1 RID: 10913
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_wei_node2 : Condition
	{
		// Token: 0x06013E63 RID: 81507 RVA: 0x005F8006 File Offset: 0x005F6406
		public Condition_bt_Guanka_apc_Mofashi_wei_node2()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013E64 RID: 81508 RVA: 0x005F803C File Offset: 0x005F643C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8D6 RID: 55510
		private int opl_p0;

		// Token: 0x0400D8D7 RID: 55511
		private int opl_p1;

		// Token: 0x0400D8D8 RID: 55512
		private int opl_p2;

		// Token: 0x0400D8D9 RID: 55513
		private int opl_p3;
	}
}
