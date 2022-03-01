using System;

namespace behaviac
{
	// Token: 0x02003616 RID: 13846
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node14 : Condition
	{
		// Token: 0x06015451 RID: 87121 RVA: 0x00669AE3 File Offset: 0x00667EE3
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node14()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06015452 RID: 87122 RVA: 0x00669B18 File Offset: 0x00667F18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE0A RID: 60938
		private int opl_p0;

		// Token: 0x0400EE0B RID: 60939
		private int opl_p1;

		// Token: 0x0400EE0C RID: 60940
		private int opl_p2;

		// Token: 0x0400EE0D RID: 60941
		private int opl_p3;
	}
}
