using System;

namespace behaviac
{
	// Token: 0x02002C7A RID: 11386
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node27 : Action
	{
		// Token: 0x060141ED RID: 82413 RVA: 0x0060ABAB File Offset: 0x00608FAB
		public Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node27()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522111;
			this.method_p2 = 500;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x060141EE RID: 82414 RVA: 0x0060ABE6 File Offset: 0x00608FE6
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBAF RID: 56239
		private BE_Target method_p0;

		// Token: 0x0400DBB0 RID: 56240
		private int method_p1;

		// Token: 0x0400DBB1 RID: 56241
		private int method_p2;

		// Token: 0x0400DBB2 RID: 56242
		private int method_p3;

		// Token: 0x0400DBB3 RID: 56243
		private int method_p4;
	}
}
