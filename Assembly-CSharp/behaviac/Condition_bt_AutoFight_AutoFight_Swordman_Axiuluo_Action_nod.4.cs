using System;

namespace behaviac
{
	// Token: 0x0200289D RID: 10397
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node91 : Condition
	{
		// Token: 0x06013A74 RID: 80500 RVA: 0x005DE87B File Offset: 0x005DCC7B
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node91()
		{
			this.opl_p0 = 1709;
		}

		// Token: 0x06013A75 RID: 80501 RVA: 0x005DE890 File Offset: 0x005DCC90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4CF RID: 54479
		private int opl_p0;
	}
}
