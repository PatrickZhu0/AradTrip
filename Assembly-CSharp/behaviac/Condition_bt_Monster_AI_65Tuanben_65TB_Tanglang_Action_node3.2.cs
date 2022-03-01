using System;

namespace behaviac
{
	// Token: 0x02002C8D RID: 11405
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node31 : Condition
	{
		// Token: 0x06014211 RID: 82449 RVA: 0x0060BA4D File Offset: 0x00609E4D
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node31()
		{
			this.opl_p0 = 4500;
			this.opl_p1 = 4500;
			this.opl_p2 = 4500;
			this.opl_p3 = 4500;
		}

		// Token: 0x06014212 RID: 82450 RVA: 0x0060BA84 File Offset: 0x00609E84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBCD RID: 56269
		private int opl_p0;

		// Token: 0x0400DBCE RID: 56270
		private int opl_p1;

		// Token: 0x0400DBCF RID: 56271
		private int opl_p2;

		// Token: 0x0400DBD0 RID: 56272
		private int opl_p3;
	}
}
