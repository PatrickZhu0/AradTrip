using System;

namespace behaviac
{
	// Token: 0x020028B3 RID: 10419
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node74 : Condition
	{
		// Token: 0x06013AA0 RID: 80544 RVA: 0x005DF31B File Offset: 0x005DD71B
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node74()
		{
			this.opl_p0 = 1703;
		}

		// Token: 0x06013AA1 RID: 80545 RVA: 0x005DF330 File Offset: 0x005DD730
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4FD RID: 54525
		private int opl_p0;
	}
}
