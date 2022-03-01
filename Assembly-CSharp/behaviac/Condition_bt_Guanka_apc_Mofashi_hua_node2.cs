using System;

namespace behaviac
{
	// Token: 0x02002A81 RID: 10881
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_hua_node2 : Condition
	{
		// Token: 0x06013E27 RID: 81447 RVA: 0x005F68BA File Offset: 0x005F4CBA
		public Condition_bt_Guanka_apc_Mofashi_hua_node2()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013E28 RID: 81448 RVA: 0x005F68F0 File Offset: 0x005F4CF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D89A RID: 55450
		private int opl_p0;

		// Token: 0x0400D89B RID: 55451
		private int opl_p1;

		// Token: 0x0400D89C RID: 55452
		private int opl_p2;

		// Token: 0x0400D89D RID: 55453
		private int opl_p3;
	}
}
