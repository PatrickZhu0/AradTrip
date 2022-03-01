using System;

namespace behaviac
{
	// Token: 0x020022C1 RID: 8897
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node54 : Condition
	{
		// Token: 0x06012EFD RID: 77565 RVA: 0x00596AF5 File Offset: 0x00594EF5
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node54()
		{
			this.opl_p0 = 1909;
		}

		// Token: 0x06012EFE RID: 77566 RVA: 0x00596B08 File Offset: 0x00594F08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C910 RID: 51472
		private int opl_p0;
	}
}
