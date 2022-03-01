using System;

namespace behaviac
{
	// Token: 0x02002C44 RID: 11332
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node11 : Action
	{
		// Token: 0x06014184 RID: 82308 RVA: 0x00608D73 File Offset: 0x00607173
		public Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521983;
		}

		// Token: 0x06014185 RID: 82309 RVA: 0x00608D94 File Offset: 0x00607194
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB4B RID: 56139
		private BE_Target method_p0;

		// Token: 0x0400DB4C RID: 56140
		private int method_p1;
	}
}
