using System;

namespace behaviac
{
	// Token: 0x02002261 RID: 8801
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node14 : Condition
	{
		// Token: 0x06012E4A RID: 77386 RVA: 0x00591BEB File Offset: 0x0058FFEB
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node14()
		{
			this.opl_p0 = 1715;
		}

		// Token: 0x06012E4B RID: 77387 RVA: 0x00591C00 File Offset: 0x00590000
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C859 RID: 51289
		private int opl_p0;
	}
}
