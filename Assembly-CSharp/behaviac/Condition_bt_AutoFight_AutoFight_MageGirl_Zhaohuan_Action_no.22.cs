using System;

namespace behaviac
{
	// Token: 0x02002765 RID: 10085
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node29 : Condition
	{
		// Token: 0x0601380B RID: 79883 RVA: 0x005CFF73 File Offset: 0x005CE373
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node29()
		{
			this.opl_p0 = 2006;
		}

		// Token: 0x0601380C RID: 79884 RVA: 0x005CFF88 File Offset: 0x005CE388
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D26C RID: 53868
		private int opl_p0;
	}
}
