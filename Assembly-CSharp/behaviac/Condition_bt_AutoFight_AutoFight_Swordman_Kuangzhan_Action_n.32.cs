using System;

namespace behaviac
{
	// Token: 0x0200296E RID: 10606
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node29 : Condition
	{
		// Token: 0x06013C11 RID: 80913 RVA: 0x005E7D23 File Offset: 0x005E6123
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node29()
		{
			this.opl_p0 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p1 = 3;
		}

		// Token: 0x06013C12 RID: 80914 RVA: 0x005E7D3C File Offset: 0x005E613C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckLastResult(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D677 RID: 54903
		private BE_Operation opl_p0;

		// Token: 0x0400D678 RID: 54904
		private int opl_p1;
	}
}
