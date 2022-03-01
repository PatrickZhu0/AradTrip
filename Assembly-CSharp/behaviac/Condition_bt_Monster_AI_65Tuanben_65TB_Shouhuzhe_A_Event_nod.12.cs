using System;

namespace behaviac
{
	// Token: 0x02002C4D RID: 11341
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node21 : Condition
	{
		// Token: 0x06014196 RID: 82326 RVA: 0x006090B3 File Offset: 0x006074B3
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node21()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06014197 RID: 82327 RVA: 0x006090C8 File Offset: 0x006074C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB5E RID: 56158
		private float opl_p0;
	}
}
