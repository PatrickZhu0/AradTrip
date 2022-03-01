using System;

namespace behaviac
{
	// Token: 0x02002988 RID: 10632
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node30 : Condition
	{
		// Token: 0x06013C44 RID: 80964 RVA: 0x005E9BD3 File Offset: 0x005E7FD3
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node30()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013C45 RID: 80965 RVA: 0x005E9C08 File Offset: 0x005E8008
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6AB RID: 54955
		private int opl_p0;

		// Token: 0x0400D6AC RID: 54956
		private int opl_p1;

		// Token: 0x0400D6AD RID: 54957
		private int opl_p2;

		// Token: 0x0400D6AE RID: 54958
		private int opl_p3;
	}
}
