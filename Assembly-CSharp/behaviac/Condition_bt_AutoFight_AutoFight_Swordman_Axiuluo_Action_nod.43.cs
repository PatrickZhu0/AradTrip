using System;

namespace behaviac
{
	// Token: 0x020028CF RID: 10447
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node56 : Condition
	{
		// Token: 0x06013AD8 RID: 80600 RVA: 0x005DFFE9 File Offset: 0x005DE3E9
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node56()
		{
			this.opl_p0 = 1701;
		}

		// Token: 0x06013AD9 RID: 80601 RVA: 0x005DFFFC File Offset: 0x005DE3FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D539 RID: 54585
		private int opl_p0;
	}
}
