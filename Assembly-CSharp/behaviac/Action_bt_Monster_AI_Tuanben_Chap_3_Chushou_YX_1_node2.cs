using System;

namespace behaviac
{
	// Token: 0x0200382E RID: 14382
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_1_node2 : Action
	{
		// Token: 0x06015846 RID: 88134 RVA: 0x0067E7D2 File Offset: 0x0067CBD2
		public Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_1_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521662;
			this.method_p2 = -1;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x06015847 RID: 88135 RVA: 0x0067E808 File Offset: 0x0067CC08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F207 RID: 61959
		private BE_Target method_p0;

		// Token: 0x0400F208 RID: 61960
		private int method_p1;

		// Token: 0x0400F209 RID: 61961
		private int method_p2;

		// Token: 0x0400F20A RID: 61962
		private int method_p3;

		// Token: 0x0400F20B RID: 61963
		private int method_p4;
	}
}
