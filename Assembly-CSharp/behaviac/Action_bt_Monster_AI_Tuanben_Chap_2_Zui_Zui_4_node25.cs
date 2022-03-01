using System;

namespace behaviac
{
	// Token: 0x0200381E RID: 14366
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node25 : Action
	{
		// Token: 0x0601582B RID: 88107 RVA: 0x0067DB37 File Offset: 0x0067BF37
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node25()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521660;
		}

		// Token: 0x0601582C RID: 88108 RVA: 0x0067DB58 File Offset: 0x0067BF58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F1EB RID: 61931
		private BE_Target method_p0;

		// Token: 0x0400F1EC RID: 61932
		private int method_p1;
	}
}
