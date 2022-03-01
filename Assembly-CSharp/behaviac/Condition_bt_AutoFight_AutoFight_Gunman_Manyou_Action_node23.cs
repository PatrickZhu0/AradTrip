using System;

namespace behaviac
{
	// Token: 0x02002604 RID: 9732
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node23 : Condition
	{
		// Token: 0x0601354E RID: 79182 RVA: 0x005C0677 File Offset: 0x005BEA77
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node23()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x0601354F RID: 79183 RVA: 0x005C06AC File Offset: 0x005BEAAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF99 RID: 53145
		private int opl_p0;

		// Token: 0x0400CF9A RID: 53146
		private int opl_p1;

		// Token: 0x0400CF9B RID: 53147
		private int opl_p2;

		// Token: 0x0400CF9C RID: 53148
		private int opl_p3;
	}
}
