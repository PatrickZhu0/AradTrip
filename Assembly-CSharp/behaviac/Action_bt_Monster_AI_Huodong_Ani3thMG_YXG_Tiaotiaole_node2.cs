using System;

namespace behaviac
{
	// Token: 0x0200356B RID: 13675
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Tiaotiaole_node2 : Action
	{
		// Token: 0x0601530E RID: 86798 RVA: 0x006630D8 File Offset: 0x006614D8
		public Action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Tiaotiaole_node2()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 28000;
			this.method_p1 = 0;
		}

		// Token: 0x0601530F RID: 86799 RVA: 0x006630FC File Offset: 0x006614FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400ECC7 RID: 60615
		private int method_p0;

		// Token: 0x0400ECC8 RID: 60616
		private int method_p1;
	}
}
