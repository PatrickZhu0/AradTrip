using System;

namespace behaviac
{
	// Token: 0x02003D99 RID: 15769
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Xianfeng_Event_hard_node2 : Action
	{
		// Token: 0x060162C5 RID: 90821 RVA: 0x006B41CB File Offset: 0x006B25CB
		public Action_bt_Monster_AI_Tuanben_hard_Xianfeng_Event_hard_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 30;
			this.method_p2 = 900000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x060162C6 RID: 90822 RVA: 0x006B4202 File Offset: 0x006B2602
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB14 RID: 64276
		private BE_Target method_p0;

		// Token: 0x0400FB15 RID: 64277
		private int method_p1;

		// Token: 0x0400FB16 RID: 64278
		private int method_p2;

		// Token: 0x0400FB17 RID: 64279
		private int method_p3;

		// Token: 0x0400FB18 RID: 64280
		private int method_p4;
	}
}
