using System;

namespace behaviac
{
	// Token: 0x02002934 RID: 10548
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node66 : Condition
	{
		// Token: 0x06013B9E RID: 80798 RVA: 0x005E50F7 File Offset: 0x005E34F7
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node66()
		{
			this.opl_p0 = 1918;
		}

		// Token: 0x06013B9F RID: 80799 RVA: 0x005E510C File Offset: 0x005E350C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D604 RID: 54788
		private int opl_p0;
	}
}
