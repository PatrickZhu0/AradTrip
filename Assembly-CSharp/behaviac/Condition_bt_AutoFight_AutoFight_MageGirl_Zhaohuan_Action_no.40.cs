using System;

namespace behaviac
{
	// Token: 0x0200277D RID: 10109
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node33 : Condition
	{
		// Token: 0x0601383B RID: 79931 RVA: 0x005D09AB File Offset: 0x005CEDAB
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node33()
		{
			this.opl_p0 = 2010;
		}

		// Token: 0x0601383C RID: 79932 RVA: 0x005D09C0 File Offset: 0x005CEDC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D29C RID: 53916
		private int opl_p0;
	}
}
