using System;

namespace behaviac
{
	// Token: 0x02004027 RID: 16423
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node11 : Condition
	{
		// Token: 0x060167AF RID: 92079 RVA: 0x006CDD0B File Offset: 0x006CC10B
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node11()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060167B0 RID: 92080 RVA: 0x006CDD40 File Offset: 0x006CC140
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFFB RID: 65531
		private int opl_p0;

		// Token: 0x0400FFFC RID: 65532
		private int opl_p1;

		// Token: 0x0400FFFD RID: 65533
		private int opl_p2;

		// Token: 0x0400FFFE RID: 65534
		private int opl_p3;
	}
}
