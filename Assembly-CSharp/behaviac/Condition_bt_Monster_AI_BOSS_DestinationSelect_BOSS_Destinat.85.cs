using System;

namespace behaviac
{
	// Token: 0x02003031 RID: 12337
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node18 : Condition
	{
		// Token: 0x0601492A RID: 84266 RVA: 0x00631733 File Offset: 0x0062FB33
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node18()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x0601492B RID: 84267 RVA: 0x00631768 File Offset: 0x0062FB68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E287 RID: 57991
		private int opl_p0;

		// Token: 0x0400E288 RID: 57992
		private int opl_p1;

		// Token: 0x0400E289 RID: 57993
		private int opl_p2;

		// Token: 0x0400E28A RID: 57994
		private int opl_p3;
	}
}
