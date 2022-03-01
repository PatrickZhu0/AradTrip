using System;

namespace behaviac
{
	// Token: 0x02001ECD RID: 7885
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Event_Chiyao_node1 : Action
	{
		// Token: 0x06012740 RID: 75584 RVA: 0x00565F83 File Offset: 0x00564383
		public Action_bt_AutoFight_AutoFight_Event_Chiyao_node1()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 40;
			this.method_p2 = 100;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06012741 RID: 75585 RVA: 0x00565FB7 File Offset: 0x005643B7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C12E RID: 49454
		private BE_Target method_p0;

		// Token: 0x0400C12F RID: 49455
		private int method_p1;

		// Token: 0x0400C130 RID: 49456
		private int method_p2;

		// Token: 0x0400C131 RID: 49457
		private int method_p3;

		// Token: 0x0400C132 RID: 49458
		private int method_p4;
	}
}
