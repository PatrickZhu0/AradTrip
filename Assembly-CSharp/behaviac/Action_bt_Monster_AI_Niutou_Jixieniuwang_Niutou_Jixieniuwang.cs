using System;

namespace behaviac
{
	// Token: 0x020036FA RID: 14074
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Niutou_Jixieniuwang_Niutou_Jixieniuwang_Zhaohuan_wudi_node8 : Action
	{
		// Token: 0x06015603 RID: 87555 RVA: 0x00672FFB File Offset: 0x006713FB
		public Action_bt_Monster_AI_Niutou_Jixieniuwang_Niutou_Jixieniuwang_Zhaohuan_wudi_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 540101;
			this.method_p2 = 60000;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x06015604 RID: 87556 RVA: 0x00673035 File Offset: 0x00671435
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFC9 RID: 61385
		private BE_Target method_p0;

		// Token: 0x0400EFCA RID: 61386
		private int method_p1;

		// Token: 0x0400EFCB RID: 61387
		private int method_p2;

		// Token: 0x0400EFCC RID: 61388
		private int method_p3;

		// Token: 0x0400EFCD RID: 61389
		private int method_p4;
	}
}
