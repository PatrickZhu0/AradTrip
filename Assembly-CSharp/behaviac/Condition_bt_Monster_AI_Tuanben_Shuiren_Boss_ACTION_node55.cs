using System;

namespace behaviac
{
	// Token: 0x02003B73 RID: 15219
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node55 : Condition
	{
		// Token: 0x06015E9B RID: 89755 RVA: 0x0069E41B File Offset: 0x0069C81B
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node55()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 2500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1000;
		}

		// Token: 0x06015E9C RID: 89756 RVA: 0x0069E450 File Offset: 0x0069C850
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F760 RID: 63328
		private int opl_p0;

		// Token: 0x0400F761 RID: 63329
		private int opl_p1;

		// Token: 0x0400F762 RID: 63330
		private int opl_p2;

		// Token: 0x0400F763 RID: 63331
		private int opl_p3;
	}
}
