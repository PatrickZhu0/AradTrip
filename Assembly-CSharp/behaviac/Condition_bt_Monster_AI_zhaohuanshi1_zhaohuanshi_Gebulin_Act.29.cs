using System;

namespace behaviac
{
	// Token: 0x0200405B RID: 16475
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node51 : Condition
	{
		// Token: 0x06016815 RID: 92181 RVA: 0x006CF80F File Offset: 0x006CDC0F
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node51()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06016816 RID: 92182 RVA: 0x006CF844 File Offset: 0x006CDC44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401005F RID: 65631
		private int opl_p0;

		// Token: 0x04010060 RID: 65632
		private int opl_p1;

		// Token: 0x04010061 RID: 65633
		private int opl_p2;

		// Token: 0x04010062 RID: 65634
		private int opl_p3;
	}
}
