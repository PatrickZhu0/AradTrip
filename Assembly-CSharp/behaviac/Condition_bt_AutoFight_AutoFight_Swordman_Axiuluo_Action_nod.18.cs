using System;

namespace behaviac
{
	// Token: 0x020028AF RID: 10415
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node21 : Condition
	{
		// Token: 0x06013A98 RID: 80536 RVA: 0x005DF16B File Offset: 0x005DD56B
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node21()
		{
			this.opl_p0 = 1521;
		}

		// Token: 0x06013A99 RID: 80537 RVA: 0x005DF180 File Offset: 0x005DD580
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4F5 RID: 54517
		private int opl_p0;
	}
}
