using System;

namespace behaviac
{
	// Token: 0x02003619 RID: 13849
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node18 : Condition
	{
		// Token: 0x06015457 RID: 87127 RVA: 0x00669BCF File Offset: 0x00667FCF
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node18()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06015458 RID: 87128 RVA: 0x00669C04 File Offset: 0x00668004
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = false;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE10 RID: 60944
		private int opl_p0;

		// Token: 0x0400EE11 RID: 60945
		private int opl_p1;

		// Token: 0x0400EE12 RID: 60946
		private int opl_p2;

		// Token: 0x0400EE13 RID: 60947
		private int opl_p3;
	}
}
