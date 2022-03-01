using System;

namespace behaviac
{
	// Token: 0x02002781 RID: 10113
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node38 : Condition
	{
		// Token: 0x06013843 RID: 79939 RVA: 0x005D0B5F File Offset: 0x005CEF5F
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node38()
		{
			this.opl_p0 = 2004;
		}

		// Token: 0x06013844 RID: 79940 RVA: 0x005D0B74 File Offset: 0x005CEF74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2A4 RID: 53924
		private int opl_p0;
	}
}
