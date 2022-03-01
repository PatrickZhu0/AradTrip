using System;

namespace behaviac
{
	// Token: 0x02003B6F RID: 15215
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node50 : Condition
	{
		// Token: 0x06015E93 RID: 89747 RVA: 0x0069E263 File Offset: 0x0069C663
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node50()
		{
			this.opl_p0 = 50000;
			this.opl_p1 = 50000;
			this.opl_p2 = 50000;
			this.opl_p3 = 50000;
		}

		// Token: 0x06015E94 RID: 89748 RVA: 0x0069E298 File Offset: 0x0069C698
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F758 RID: 63320
		private int opl_p0;

		// Token: 0x0400F759 RID: 63321
		private int opl_p1;

		// Token: 0x0400F75A RID: 63322
		private int opl_p2;

		// Token: 0x0400F75B RID: 63323
		private int opl_p3;
	}
}
