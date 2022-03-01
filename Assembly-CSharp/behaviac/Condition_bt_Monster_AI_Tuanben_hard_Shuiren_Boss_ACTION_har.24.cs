using System;

namespace behaviac
{
	// Token: 0x02003D61 RID: 15713
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node39 : Condition
	{
		// Token: 0x06016258 RID: 90712 RVA: 0x006B12E3 File Offset: 0x006AF6E3
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node39()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06016259 RID: 90713 RVA: 0x006B1318 File Offset: 0x006AF718
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAB1 RID: 64177
		private int opl_p0;

		// Token: 0x0400FAB2 RID: 64178
		private int opl_p1;

		// Token: 0x0400FAB3 RID: 64179
		private int opl_p2;

		// Token: 0x0400FAB4 RID: 64180
		private int opl_p3;
	}
}
