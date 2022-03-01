using System;

namespace behaviac
{
	// Token: 0x0200302A RID: 12330
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node9 : Condition
	{
		// Token: 0x0601491C RID: 84252 RVA: 0x00631513 File Offset: 0x0062F913
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node9()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x0601491D RID: 84253 RVA: 0x00631528 File Offset: 0x0062F928
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E27A RID: 57978
		private float opl_p0;
	}
}
