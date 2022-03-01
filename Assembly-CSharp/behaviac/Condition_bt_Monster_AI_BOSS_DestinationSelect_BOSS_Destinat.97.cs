using System;

namespace behaviac
{
	// Token: 0x02003045 RID: 12357
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node9 : Condition
	{
		// Token: 0x06014951 RID: 84305 RVA: 0x0063260B File Offset: 0x00630A0B
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node9()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06014952 RID: 84306 RVA: 0x00632620 File Offset: 0x00630A20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2AF RID: 58031
		private float opl_p0;
	}
}
