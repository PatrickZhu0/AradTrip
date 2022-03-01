using System;

namespace behaviac
{
	// Token: 0x02003837 RID: 14391
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_1_node1 : Action
	{
		// Token: 0x06015856 RID: 88150 RVA: 0x0067EC14 File Offset: 0x0067D014
		public Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_1_node1()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 60000;
			this.method_p1 = 1;
		}

		// Token: 0x06015857 RID: 88151 RVA: 0x0067EC38 File Offset: 0x0067D038
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F21E RID: 61982
		private int method_p0;

		// Token: 0x0400F21F RID: 61983
		private int method_p1;
	}
}
