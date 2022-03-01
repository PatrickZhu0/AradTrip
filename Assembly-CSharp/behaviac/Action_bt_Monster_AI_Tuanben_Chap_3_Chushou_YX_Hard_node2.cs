using System;

namespace behaviac
{
	// Token: 0x02003832 RID: 14386
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_node2 : Action
	{
		// Token: 0x0601584D RID: 88141 RVA: 0x0067E9C2 File Offset: 0x0067CDC2
		public Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521683;
			this.method_p2 = -1;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x0601584E RID: 88142 RVA: 0x0067E9F8 File Offset: 0x0067CDF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F210 RID: 61968
		private BE_Target method_p0;

		// Token: 0x0400F211 RID: 61969
		private int method_p1;

		// Token: 0x0400F212 RID: 61970
		private int method_p2;

		// Token: 0x0400F213 RID: 61971
		private int method_p3;

		// Token: 0x0400F214 RID: 61972
		private int method_p4;
	}
}
