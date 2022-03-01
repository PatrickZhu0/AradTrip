using System;

namespace behaviac
{
	// Token: 0x02003037 RID: 12343
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node26 : Condition
	{
		// Token: 0x06014936 RID: 84278 RVA: 0x0063190B File Offset: 0x0062FD0B
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node26()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06014937 RID: 84279 RVA: 0x00631940 File Offset: 0x0062FD40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E293 RID: 58003
		private int opl_p0;

		// Token: 0x0400E294 RID: 58004
		private int opl_p1;

		// Token: 0x0400E295 RID: 58005
		private int opl_p2;

		// Token: 0x0400E296 RID: 58006
		private int opl_p3;
	}
}
