using System;

namespace behaviac
{
	// Token: 0x020029A8 RID: 10664
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node52 : Condition
	{
		// Token: 0x06013C84 RID: 81028 RVA: 0x005EAA27 File Offset: 0x005E8E27
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node52()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 4000;
			this.opl_p2 = 4000;
			this.opl_p3 = 4000;
		}

		// Token: 0x06013C85 RID: 81029 RVA: 0x005EAA5C File Offset: 0x005E8E5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6EE RID: 55022
		private int opl_p0;

		// Token: 0x0400D6EF RID: 55023
		private int opl_p1;

		// Token: 0x0400D6F0 RID: 55024
		private int opl_p2;

		// Token: 0x0400D6F1 RID: 55025
		private int opl_p3;
	}
}
