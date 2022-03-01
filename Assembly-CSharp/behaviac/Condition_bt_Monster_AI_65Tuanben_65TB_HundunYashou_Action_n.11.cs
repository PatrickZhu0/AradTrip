using System;

namespace behaviac
{
	// Token: 0x02002B94 RID: 11156
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node23 : Condition
	{
		// Token: 0x06014034 RID: 81972 RVA: 0x006023FD File Offset: 0x006007FD
		public Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node23()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06014035 RID: 81973 RVA: 0x00602434 File Offset: 0x00600834
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA28 RID: 55848
		private int opl_p0;

		// Token: 0x0400DA29 RID: 55849
		private int opl_p1;

		// Token: 0x0400DA2A RID: 55850
		private int opl_p2;

		// Token: 0x0400DA2B RID: 55851
		private int opl_p3;
	}
}
