using System;

namespace behaviac
{
	// Token: 0x02003CFF RID: 15615
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node8 : Action
	{
		// Token: 0x0601619D RID: 90525 RVA: 0x006AE3EF File Offset: 0x006AC7EF
		public Action_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570154;
		}

		// Token: 0x0601619E RID: 90526 RVA: 0x006AE410 File Offset: 0x006AC810
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA37 RID: 64055
		private BE_Target method_p0;

		// Token: 0x0400FA38 RID: 64056
		private int method_p1;
	}
}
