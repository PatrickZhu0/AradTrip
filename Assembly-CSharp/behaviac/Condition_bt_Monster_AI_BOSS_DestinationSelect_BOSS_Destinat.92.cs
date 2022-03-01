using System;

namespace behaviac
{
	// Token: 0x0200303C RID: 12348
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node33 : Condition
	{
		// Token: 0x06014940 RID: 84288 RVA: 0x00631A9B File Offset: 0x0062FE9B
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node33()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06014941 RID: 84289 RVA: 0x00631AB0 File Offset: 0x0062FEB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E29E RID: 58014
		private float opl_p0;
	}
}
