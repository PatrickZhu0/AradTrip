using System;

namespace behaviac
{
	// Token: 0x02002442 RID: 9282
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node21 : Condition
	{
		// Token: 0x060131D9 RID: 78297 RVA: 0x005ABC13 File Offset: 0x005AA013
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node21()
		{
			this.opl_p0 = 1505;
		}

		// Token: 0x060131DA RID: 78298 RVA: 0x005ABC28 File Offset: 0x005AA028
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC02 RID: 52226
		private int opl_p0;
	}
}
