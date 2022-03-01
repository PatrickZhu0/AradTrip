using System;

namespace behaviac
{
	// Token: 0x020036AB RID: 13995
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node7 : Condition
	{
		// Token: 0x06015570 RID: 87408 RVA: 0x0066FFA8 File Offset: 0x0066E3A8
		public Condition_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node7()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06015571 RID: 87409 RVA: 0x0066FFDC File Offset: 0x0066E3DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF44 RID: 61252
		private int opl_p0;

		// Token: 0x0400EF45 RID: 61253
		private int opl_p1;

		// Token: 0x0400EF46 RID: 61254
		private int opl_p2;

		// Token: 0x0400EF47 RID: 61255
		private int opl_p3;
	}
}
