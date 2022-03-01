using System;

namespace behaviac
{
	// Token: 0x0200302E RID: 12334
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node14 : Condition
	{
		// Token: 0x06014924 RID: 84260 RVA: 0x00631647 File Offset: 0x0062FA47
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node14()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06014925 RID: 84261 RVA: 0x0063167C File Offset: 0x0062FA7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E281 RID: 57985
		private int opl_p0;

		// Token: 0x0400E282 RID: 57986
		private int opl_p1;

		// Token: 0x0400E283 RID: 57987
		private int opl_p2;

		// Token: 0x0400E284 RID: 57988
		private int opl_p3;
	}
}
