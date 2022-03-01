using System;

namespace behaviac
{
	// Token: 0x0200302D RID: 12333
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node13 : Condition
	{
		// Token: 0x06014922 RID: 84258 RVA: 0x006315FF File Offset: 0x0062F9FF
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node13()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06014923 RID: 84259 RVA: 0x00631614 File Offset: 0x0062FA14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E280 RID: 57984
		private float opl_p0;
	}
}
