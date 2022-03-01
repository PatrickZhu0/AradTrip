using System;

namespace behaviac
{
	// Token: 0x0200382A RID: 14378
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_node2 : Action
	{
		// Token: 0x0601583F RID: 88127 RVA: 0x0067E5E2 File Offset: 0x0067C9E2
		public Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521662;
			this.method_p2 = -1;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x06015840 RID: 88128 RVA: 0x0067E618 File Offset: 0x0067CA18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F1FE RID: 61950
		private BE_Target method_p0;

		// Token: 0x0400F1FF RID: 61951
		private int method_p1;

		// Token: 0x0400F200 RID: 61952
		private int method_p2;

		// Token: 0x0400F201 RID: 61953
		private int method_p3;

		// Token: 0x0400F202 RID: 61954
		private int method_p4;
	}
}
