using System;

namespace behaviac
{
	// Token: 0x0200406E RID: 16494
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node14 : Condition
	{
		// Token: 0x0601683A RID: 92218 RVA: 0x006D0DB3 File Offset: 0x006CF1B3
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node14()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x0601683B RID: 92219 RVA: 0x006D0DE8 File Offset: 0x006CF1E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010083 RID: 65667
		private int opl_p0;

		// Token: 0x04010084 RID: 65668
		private int opl_p1;

		// Token: 0x04010085 RID: 65669
		private int opl_p2;

		// Token: 0x04010086 RID: 65670
		private int opl_p3;
	}
}
