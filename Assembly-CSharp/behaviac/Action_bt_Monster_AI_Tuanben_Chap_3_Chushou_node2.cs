using System;

namespace behaviac
{
	// Token: 0x02003827 RID: 14375
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_node2 : Action
	{
		// Token: 0x0601583A RID: 88122 RVA: 0x0067E46B File Offset: 0x0067C86B
		public Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521782;
			this.method_p2 = -1;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x0601583B RID: 88123 RVA: 0x0067E4A1 File Offset: 0x0067C8A1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F1F7 RID: 61943
		private BE_Target method_p0;

		// Token: 0x0400F1F8 RID: 61944
		private int method_p1;

		// Token: 0x0400F1F9 RID: 61945
		private int method_p2;

		// Token: 0x0400F1FA RID: 61946
		private int method_p3;

		// Token: 0x0400F1FB RID: 61947
		private int method_p4;
	}
}
