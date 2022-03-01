using System;

namespace behaviac
{
	// Token: 0x02002726 RID: 10022
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node55 : Condition
	{
		// Token: 0x0601378E RID: 79758 RVA: 0x005CCF7B File Offset: 0x005CB37B
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node55()
		{
			this.opl_p0 = 2313;
		}

		// Token: 0x0601378F RID: 79759 RVA: 0x005CCF90 File Offset: 0x005CB390
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1E8 RID: 53736
		private int opl_p0;
	}
}
