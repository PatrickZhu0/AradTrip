using System;

namespace behaviac
{
	// Token: 0x02002761 RID: 10081
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node7 : Condition
	{
		// Token: 0x06013803 RID: 79875 RVA: 0x005CFDBF File Offset: 0x005CE1BF
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node7()
		{
			this.opl_p0 = 2007;
		}

		// Token: 0x06013804 RID: 79876 RVA: 0x005CFDD4 File Offset: 0x005CE1D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D264 RID: 53860
		private int opl_p0;
	}
}
