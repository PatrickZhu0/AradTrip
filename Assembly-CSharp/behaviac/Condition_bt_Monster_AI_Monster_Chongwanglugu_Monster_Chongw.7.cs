using System;

namespace behaviac
{
	// Token: 0x020035FA RID: 13818
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node36 : Condition
	{
		// Token: 0x0601541A RID: 87066 RVA: 0x00668522 File Offset: 0x00666922
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node36()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601541B RID: 87067 RVA: 0x00668558 File Offset: 0x00666958
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDD2 RID: 60882
		private int opl_p0;

		// Token: 0x0400EDD3 RID: 60883
		private int opl_p1;

		// Token: 0x0400EDD4 RID: 60884
		private int opl_p2;

		// Token: 0x0400EDD5 RID: 60885
		private int opl_p3;
	}
}
