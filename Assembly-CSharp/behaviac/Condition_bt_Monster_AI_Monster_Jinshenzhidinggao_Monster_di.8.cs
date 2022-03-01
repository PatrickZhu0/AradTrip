using System;

namespace behaviac
{
	// Token: 0x02003692 RID: 13970
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node6 : Condition
	{
		// Token: 0x06015541 RID: 87361 RVA: 0x0066F0E5 File Offset: 0x0066D4E5
		public Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node6()
		{
			this.opl_p0 = 20000;
			this.opl_p1 = 20000;
			this.opl_p2 = 20000;
			this.opl_p3 = 20000;
		}

		// Token: 0x06015542 RID: 87362 RVA: 0x0066F11C File Offset: 0x0066D51C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF02 RID: 61186
		private int opl_p0;

		// Token: 0x0400EF03 RID: 61187
		private int opl_p1;

		// Token: 0x0400EF04 RID: 61188
		private int opl_p2;

		// Token: 0x0400EF05 RID: 61189
		private int opl_p3;
	}
}
