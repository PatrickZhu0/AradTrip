using System;

namespace behaviac
{
	// Token: 0x02002712 RID: 10002
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node14 : Condition
	{
		// Token: 0x06013766 RID: 79718 RVA: 0x005CC6F9 File Offset: 0x005CAAF9
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node14()
		{
			this.opl_p0 = 2111;
		}

		// Token: 0x06013767 RID: 79719 RVA: 0x005CC70C File Offset: 0x005CAB0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1C0 RID: 53696
		private int opl_p0;
	}
}
