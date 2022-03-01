using System;

namespace behaviac
{
	// Token: 0x02002CF4 RID: 11508
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node44 : Condition
	{
		// Token: 0x060142D8 RID: 82648 RVA: 0x0060F1C1 File Offset: 0x0060D5C1
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node44()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 2000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060142D9 RID: 82649 RVA: 0x0060F1F8 File Offset: 0x0060D5F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC81 RID: 56449
		private int opl_p0;

		// Token: 0x0400DC82 RID: 56450
		private int opl_p1;

		// Token: 0x0400DC83 RID: 56451
		private int opl_p2;

		// Token: 0x0400DC84 RID: 56452
		private int opl_p3;
	}
}
