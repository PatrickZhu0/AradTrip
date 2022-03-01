using System;

namespace behaviac
{
	// Token: 0x02003730 RID: 14128
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node18 : Action
	{
		// Token: 0x0601566C RID: 87660 RVA: 0x00674D19 File Offset: 0x00673119
		public Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node18()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 538803;
			this.method_p2 = 60000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x0601566D RID: 87661 RVA: 0x00674D53 File Offset: 0x00673153
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F038 RID: 61496
		private BE_Target method_p0;

		// Token: 0x0400F039 RID: 61497
		private int method_p1;

		// Token: 0x0400F03A RID: 61498
		private int method_p2;

		// Token: 0x0400F03B RID: 61499
		private int method_p3;

		// Token: 0x0400F03C RID: 61500
		private int method_p4;
	}
}
