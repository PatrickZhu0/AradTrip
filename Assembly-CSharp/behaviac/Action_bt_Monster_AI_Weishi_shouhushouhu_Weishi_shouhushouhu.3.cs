using System;

namespace behaviac
{
	// Token: 0x02003DDC RID: 15836
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangputong_node6 : Action
	{
		// Token: 0x06016345 RID: 90949 RVA: 0x006B6869 File Offset: 0x006B4C69
		public Action_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangputong_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2401;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06016346 RID: 90950 RVA: 0x006B68A3 File Offset: 0x006B4CA3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBA9 RID: 64425
		private BE_Target method_p0;

		// Token: 0x0400FBAA RID: 64426
		private int method_p1;

		// Token: 0x0400FBAB RID: 64427
		private int method_p2;

		// Token: 0x0400FBAC RID: 64428
		private int method_p3;

		// Token: 0x0400FBAD RID: 64429
		private int method_p4;
	}
}
