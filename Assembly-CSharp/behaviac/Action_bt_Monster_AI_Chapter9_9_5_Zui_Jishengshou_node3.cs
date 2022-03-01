using System;

namespace behaviac
{
	// Token: 0x020031D6 RID: 12758
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_Jishengshou_node3 : Action
	{
		// Token: 0x06014C3D RID: 85053 RVA: 0x00641786 File Offset: 0x0063FB86
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_Jishengshou_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 38;
			this.method_p2 = 3500;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014C3E RID: 85054 RVA: 0x006417BE File Offset: 0x0063FBBE
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E592 RID: 58770
		private BE_Target method_p0;

		// Token: 0x0400E593 RID: 58771
		private int method_p1;

		// Token: 0x0400E594 RID: 58772
		private int method_p2;

		// Token: 0x0400E595 RID: 58773
		private int method_p3;

		// Token: 0x0400E596 RID: 58774
		private int method_p4;
	}
}
