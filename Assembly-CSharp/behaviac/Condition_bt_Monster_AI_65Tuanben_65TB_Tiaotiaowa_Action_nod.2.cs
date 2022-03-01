using System;

namespace behaviac
{
	// Token: 0x02002CD6 RID: 11478
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node30 : Condition
	{
		// Token: 0x0601429C RID: 82588 RVA: 0x0060E6C3 File Offset: 0x0060CAC3
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node30()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 1500;
			this.opl_p2 = 6000;
			this.opl_p3 = 6000;
		}

		// Token: 0x0601429D RID: 82589 RVA: 0x0060E6F8 File Offset: 0x0060CAF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC4D RID: 56397
		private int opl_p0;

		// Token: 0x0400DC4E RID: 56398
		private int opl_p1;

		// Token: 0x0400DC4F RID: 56399
		private int opl_p2;

		// Token: 0x0400DC50 RID: 56400
		private int opl_p3;
	}
}
