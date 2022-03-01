using System;

namespace behaviac
{
	// Token: 0x02003AB5 RID: 15029
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node8 : Action
	{
		// Token: 0x06015D2C RID: 89388 RVA: 0x00697E5F File Offset: 0x0069625F
		public Action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570154;
		}

		// Token: 0x06015D2D RID: 89389 RVA: 0x00697E80 File Offset: 0x00696280
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F64C RID: 63052
		private BE_Target method_p0;

		// Token: 0x0400F64D RID: 63053
		private int method_p1;
	}
}
