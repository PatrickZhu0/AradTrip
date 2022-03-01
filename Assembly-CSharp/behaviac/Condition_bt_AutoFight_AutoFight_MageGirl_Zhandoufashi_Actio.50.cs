using System;

namespace behaviac
{
	// Token: 0x02002742 RID: 10050
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node33 : Condition
	{
		// Token: 0x060137C6 RID: 79814 RVA: 0x005CDB67 File Offset: 0x005CBF67
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node33()
		{
			this.opl_p0 = 2010;
		}

		// Token: 0x060137C7 RID: 79815 RVA: 0x005CDB7C File Offset: 0x005CBF7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D220 RID: 53792
		private int opl_p0;
	}
}
