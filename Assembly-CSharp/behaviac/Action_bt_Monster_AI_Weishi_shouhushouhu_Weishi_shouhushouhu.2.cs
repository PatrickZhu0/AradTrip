using System;

namespace behaviac
{
	// Token: 0x02003DD6 RID: 15830
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangmaoxian_node11 : Action
	{
		// Token: 0x0601633A RID: 90938 RVA: 0x006B63E5 File Offset: 0x006B47E5
		public Action_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangmaoxian_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2502;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x0601633B RID: 90939 RVA: 0x006B641F File Offset: 0x006B481F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB9E RID: 64414
		private BE_Target method_p0;

		// Token: 0x0400FB9F RID: 64415
		private int method_p1;

		// Token: 0x0400FBA0 RID: 64416
		private int method_p2;

		// Token: 0x0400FBA1 RID: 64417
		private int method_p3;

		// Token: 0x0400FBA2 RID: 64418
		private int method_p4;
	}
}
