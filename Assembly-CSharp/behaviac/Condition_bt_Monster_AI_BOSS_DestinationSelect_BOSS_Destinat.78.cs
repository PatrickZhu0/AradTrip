using System;

namespace behaviac
{
	// Token: 0x02003027 RID: 12327
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node5 : Condition
	{
		// Token: 0x06014916 RID: 84246 RVA: 0x00631428 File Offset: 0x0062F828
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node5()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06014917 RID: 84247 RVA: 0x0063143C File Offset: 0x0062F83C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E274 RID: 57972
		private float opl_p0;
	}
}
