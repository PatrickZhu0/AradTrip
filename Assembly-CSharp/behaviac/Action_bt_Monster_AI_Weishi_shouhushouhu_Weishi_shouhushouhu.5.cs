using System;

namespace behaviac
{
	// Token: 0x02003DE7 RID: 15847
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangwangzhe_node6 : Action
	{
		// Token: 0x0601635A RID: 90970 RVA: 0x006B6E71 File Offset: 0x006B5271
		public Action_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangwangzhe_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2404;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x0601635B RID: 90971 RVA: 0x006B6EAB File Offset: 0x006B52AB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBBF RID: 64447
		private BE_Target method_p0;

		// Token: 0x0400FBC0 RID: 64448
		private int method_p1;

		// Token: 0x0400FBC1 RID: 64449
		private int method_p2;

		// Token: 0x0400FBC2 RID: 64450
		private int method_p3;

		// Token: 0x0400FBC3 RID: 64451
		private int method_p4;
	}
}
