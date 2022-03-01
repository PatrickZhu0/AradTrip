using System;

namespace behaviac
{
	// Token: 0x02003575 RID: 13685
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_Event_node2 : Action
	{
		// Token: 0x0601531F RID: 86815 RVA: 0x006635CA File Offset: 0x006619CA
		public Action_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522093;
			this.method_p2 = 1000;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015320 RID: 86816 RVA: 0x00663605 File Offset: 0x00661A05
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECDE RID: 60638
		private BE_Target method_p0;

		// Token: 0x0400ECDF RID: 60639
		private int method_p1;

		// Token: 0x0400ECE0 RID: 60640
		private int method_p2;

		// Token: 0x0400ECE1 RID: 60641
		private int method_p3;

		// Token: 0x0400ECE2 RID: 60642
		private int method_p4;
	}
}
