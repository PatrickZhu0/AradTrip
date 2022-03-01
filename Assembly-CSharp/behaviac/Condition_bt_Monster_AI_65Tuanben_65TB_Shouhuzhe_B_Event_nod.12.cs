using System;

namespace behaviac
{
	// Token: 0x02002C76 RID: 11382
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node21 : Condition
	{
		// Token: 0x060141E5 RID: 82405 RVA: 0x0060AA0F File Offset: 0x00608E0F
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node21()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x060141E6 RID: 82406 RVA: 0x0060AA24 File Offset: 0x00608E24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBA8 RID: 56232
		private float opl_p0;
	}
}
