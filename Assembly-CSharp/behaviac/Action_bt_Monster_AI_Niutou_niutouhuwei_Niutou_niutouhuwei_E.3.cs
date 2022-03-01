using System;

namespace behaviac
{
	// Token: 0x02003710 RID: 14096
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Niutou_niutouhuwei_Niutou_niutouhuwei_Event_Hundun_node9 : Action
	{
		// Token: 0x0601562E RID: 87598 RVA: 0x00673C0F File Offset: 0x0067200F
		public Action_bt_Monster_AI_Niutou_niutouhuwei_Niutou_niutouhuwei_Event_Hundun_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 528401;
		}

		// Token: 0x0601562F RID: 87599 RVA: 0x00673C30 File Offset: 0x00672030
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFF8 RID: 61432
		private BE_Target method_p0;

		// Token: 0x0400EFF9 RID: 61433
		private int method_p1;
	}
}
