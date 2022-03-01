using System;

namespace behaviac
{
	// Token: 0x02003645 RID: 13893
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node17 : Condition
	{
		// Token: 0x060154AD RID: 87213 RVA: 0x0066B72E File Offset: 0x00669B2E
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node17()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x060154AE RID: 87214 RVA: 0x0066B764 File Offset: 0x00669B64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE65 RID: 61029
		private int opl_p0;

		// Token: 0x0400EE66 RID: 61030
		private int opl_p1;

		// Token: 0x0400EE67 RID: 61031
		private int opl_p2;

		// Token: 0x0400EE68 RID: 61032
		private int opl_p3;
	}
}
