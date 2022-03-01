using System;

namespace behaviac
{
	// Token: 0x0200382F RID: 14383
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_1_node1 : Action
	{
		// Token: 0x06015848 RID: 88136 RVA: 0x0067E834 File Offset: 0x0067CC34
		public Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_1_node1()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 60000;
			this.method_p1 = 1;
		}

		// Token: 0x06015849 RID: 88137 RVA: 0x0067E858 File Offset: 0x0067CC58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F20C RID: 61964
		private int method_p0;

		// Token: 0x0400F20D RID: 61965
		private int method_p1;
	}
}
