using System;

namespace behaviac
{
	// Token: 0x02002A31 RID: 10801
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Feiwuzhifengtianyu_node9 : Condition
	{
		// Token: 0x06013D8F RID: 81295 RVA: 0x005F1F7E File Offset: 0x005F037E
		public Condition_bt_Guanka_apc_Feiwuzhifengtianyu_node9()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013D90 RID: 81296 RVA: 0x005F1FB4 File Offset: 0x005F03B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7FE RID: 55294
		private int opl_p0;

		// Token: 0x0400D7FF RID: 55295
		private int opl_p1;

		// Token: 0x0400D800 RID: 55296
		private int opl_p2;

		// Token: 0x0400D801 RID: 55297
		private int opl_p3;
	}
}
