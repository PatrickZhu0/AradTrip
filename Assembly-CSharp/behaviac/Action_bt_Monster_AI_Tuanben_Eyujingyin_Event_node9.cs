using System;

namespace behaviac
{
	// Token: 0x02003994 RID: 14740
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Eyujingyin_Event_node9 : Action
	{
		// Token: 0x06015AFD RID: 88829 RVA: 0x0068CE2A File Offset: 0x0068B22A
		public Action_bt_Monster_AI_Tuanben_Eyujingyin_Event_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "哈哈，居然捡到一个炮弹！";
			this.method_p1 = 1f;
			this.method_p2 = 0;
		}

		// Token: 0x06015AFE RID: 88830 RVA: 0x0068CE56 File Offset: 0x0068B256
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F496 RID: 62614
		private string method_p0;

		// Token: 0x0400F497 RID: 62615
		private float method_p1;

		// Token: 0x0400F498 RID: 62616
		private int method_p2;
	}
}
