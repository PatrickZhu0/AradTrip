using System;

namespace behaviac
{
	// Token: 0x02002962 RID: 10594
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node74 : Condition
	{
		// Token: 0x06013BF9 RID: 80889 RVA: 0x005E7821 File Offset: 0x005E5C21
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node74()
		{
			this.opl_p0 = 1608;
		}

		// Token: 0x06013BFA RID: 80890 RVA: 0x005E7834 File Offset: 0x005E5C34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D65F RID: 54879
		private int opl_p0;
	}
}
