using System;

namespace behaviac
{
	// Token: 0x02003DE1 RID: 15841
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangputong_node11 : Action
	{
		// Token: 0x0601634F RID: 90959 RVA: 0x006B69ED File Offset: 0x006B4DED
		public Action_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangputong_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2501;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06016350 RID: 90960 RVA: 0x006B6A27 File Offset: 0x006B4E27
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBB4 RID: 64436
		private BE_Target method_p0;

		// Token: 0x0400FBB5 RID: 64437
		private int method_p1;

		// Token: 0x0400FBB6 RID: 64438
		private int method_p2;

		// Token: 0x0400FBB7 RID: 64439
		private int method_p3;

		// Token: 0x0400FBB8 RID: 64440
		private int method_p4;
	}
}
