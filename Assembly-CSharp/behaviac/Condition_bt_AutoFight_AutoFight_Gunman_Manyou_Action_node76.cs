using System;

namespace behaviac
{
	// Token: 0x02002626 RID: 9766
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node76 : Condition
	{
		// Token: 0x06013592 RID: 79250 RVA: 0x005C1607 File Offset: 0x005BFA07
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node76()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013593 RID: 79251 RVA: 0x005C163C File Offset: 0x005BFA3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFDF RID: 53215
		private int opl_p0;

		// Token: 0x0400CFE0 RID: 53216
		private int opl_p1;

		// Token: 0x0400CFE1 RID: 53217
		private int opl_p2;

		// Token: 0x0400CFE2 RID: 53218
		private int opl_p3;
	}
}
