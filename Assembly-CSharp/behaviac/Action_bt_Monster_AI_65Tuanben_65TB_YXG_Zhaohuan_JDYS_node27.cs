using System;

namespace behaviac
{
	// Token: 0x02002D45 RID: 11589
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node27 : Action
	{
		// Token: 0x0601436F RID: 82799 RVA: 0x00612689 File Offset: 0x00610A89
		public Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node27()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521973;
		}

		// Token: 0x06014370 RID: 82800 RVA: 0x006126AA File Offset: 0x00610AAA
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD36 RID: 56630
		private BE_Target method_p0;

		// Token: 0x0400DD37 RID: 56631
		private int method_p1;
	}
}
