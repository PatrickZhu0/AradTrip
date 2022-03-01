using System;

namespace behaviac
{
	// Token: 0x02003024 RID: 12324
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node38 : Condition
	{
		// Token: 0x06014911 RID: 84241 RVA: 0x00630A8F File Offset: 0x0062EE8F
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node38()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x06014912 RID: 84242 RVA: 0x00630AC4 File Offset: 0x0062EEC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E26F RID: 57967
		private int opl_p0;

		// Token: 0x0400E270 RID: 57968
		private int opl_p1;

		// Token: 0x0400E271 RID: 57969
		private int opl_p2;

		// Token: 0x0400E272 RID: 57970
		private int opl_p3;
	}
}
