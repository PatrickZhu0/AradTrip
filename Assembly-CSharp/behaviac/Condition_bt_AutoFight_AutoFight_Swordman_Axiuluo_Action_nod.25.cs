using System;

namespace behaviac
{
	// Token: 0x020028B8 RID: 10424
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node40 : Condition
	{
		// Token: 0x06013AAA RID: 80554 RVA: 0x005DF52F File Offset: 0x005DD92F
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node40()
		{
			this.opl_p0 = 1510;
		}

		// Token: 0x06013AAB RID: 80555 RVA: 0x005DF544 File Offset: 0x005DD944
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D508 RID: 54536
		private int opl_p0;
	}
}
