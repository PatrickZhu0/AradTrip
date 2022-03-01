using System;

namespace behaviac
{
	// Token: 0x0200296A RID: 10602
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node21 : Condition
	{
		// Token: 0x06013C09 RID: 80905 RVA: 0x005E7B87 File Offset: 0x005E5F87
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node21()
		{
			this.opl_p0 = 1606;
		}

		// Token: 0x06013C0A RID: 80906 RVA: 0x005E7B9C File Offset: 0x005E5F9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D66F RID: 54895
		private int opl_p0;
	}
}
