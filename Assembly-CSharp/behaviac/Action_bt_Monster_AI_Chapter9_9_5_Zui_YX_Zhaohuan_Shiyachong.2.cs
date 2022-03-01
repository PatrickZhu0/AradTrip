using System;

namespace behaviac
{
	// Token: 0x020031E4 RID: 12772
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_YX_Zhaohuan_Shiyachong_node3 : Action
	{
		// Token: 0x06014C56 RID: 85078 RVA: 0x00641EBD File Offset: 0x006402BD
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_YX_Zhaohuan_Shiyachong_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570264;
			this.method_p2 = 100;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014C57 RID: 85079 RVA: 0x00641EF5 File Offset: 0x006402F5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5AF RID: 58799
		private BE_Target method_p0;

		// Token: 0x0400E5B0 RID: 58800
		private int method_p1;

		// Token: 0x0400E5B1 RID: 58801
		private int method_p2;

		// Token: 0x0400E5B2 RID: 58802
		private int method_p3;

		// Token: 0x0400E5B3 RID: 58803
		private int method_p4;
	}
}
