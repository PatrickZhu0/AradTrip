using System;

namespace behaviac
{
	// Token: 0x02002632 RID: 9778
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node38 : Condition
	{
		// Token: 0x060135AA RID: 79274 RVA: 0x005C1B23 File Offset: 0x005BFF23
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node38()
		{
			this.opl_p0 = 3800;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060135AB RID: 79275 RVA: 0x005C1B58 File Offset: 0x005BFF58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFF7 RID: 53239
		private int opl_p0;

		// Token: 0x0400CFF8 RID: 53240
		private int opl_p1;

		// Token: 0x0400CFF9 RID: 53241
		private int opl_p2;

		// Token: 0x0400CFFA RID: 53242
		private int opl_p3;
	}
}
