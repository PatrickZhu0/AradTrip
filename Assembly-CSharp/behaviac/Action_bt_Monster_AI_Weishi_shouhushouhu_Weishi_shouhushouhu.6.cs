using System;

namespace behaviac
{
	// Token: 0x02003DEC RID: 15852
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangwangzhe_node11 : Action
	{
		// Token: 0x06016364 RID: 90980 RVA: 0x006B6FF5 File Offset: 0x006B53F5
		public Action_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangwangzhe_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2504;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06016365 RID: 90981 RVA: 0x006B702F File Offset: 0x006B542F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBCA RID: 64458
		private BE_Target method_p0;

		// Token: 0x0400FBCB RID: 64459
		private int method_p1;

		// Token: 0x0400FBCC RID: 64460
		private int method_p2;

		// Token: 0x0400FBCD RID: 64461
		private int method_p3;

		// Token: 0x0400FBCE RID: 64462
		private int method_p4;
	}
}
