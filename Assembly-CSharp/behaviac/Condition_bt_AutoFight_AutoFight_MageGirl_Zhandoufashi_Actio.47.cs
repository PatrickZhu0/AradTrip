using System;

namespace behaviac
{
	// Token: 0x0200273E RID: 10046
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node71 : Condition
	{
		// Token: 0x060137BE RID: 79806 RVA: 0x005CD9B3 File Offset: 0x005CBDB3
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node71()
		{
			this.opl_p0 = 2008;
		}

		// Token: 0x060137BF RID: 79807 RVA: 0x005CD9C8 File Offset: 0x005CBDC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D218 RID: 53784
		private int opl_p0;
	}
}
