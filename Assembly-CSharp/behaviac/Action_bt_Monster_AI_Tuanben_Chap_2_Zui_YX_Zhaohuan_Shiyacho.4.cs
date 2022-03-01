using System;

namespace behaviac
{
	// Token: 0x020037F9 RID: 14329
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_Hard_node3 : Action
	{
		// Token: 0x060157E6 RID: 88038 RVA: 0x0067CB19 File Offset: 0x0067AF19
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_Hard_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521675;
			this.method_p2 = 100;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060157E7 RID: 88039 RVA: 0x0067CB51 File Offset: 0x0067AF51
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F1AD RID: 61869
		private BE_Target method_p0;

		// Token: 0x0400F1AE RID: 61870
		private int method_p1;

		// Token: 0x0400F1AF RID: 61871
		private int method_p2;

		// Token: 0x0400F1B0 RID: 61872
		private int method_p3;

		// Token: 0x0400F1B1 RID: 61873
		private int method_p4;
	}
}
