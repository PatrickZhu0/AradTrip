using System;

namespace behaviac
{
	// Token: 0x02003B4E RID: 15182
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node5 : Action
	{
		// Token: 0x06015E51 RID: 89681 RVA: 0x0069D707 File Offset: 0x0069BB07
		public Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node5()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570070;
			this.method_p2 = 0;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015E52 RID: 89682 RVA: 0x0069D73E File Offset: 0x0069BB3E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F71E RID: 63262
		private BE_Target method_p0;

		// Token: 0x0400F71F RID: 63263
		private int method_p1;

		// Token: 0x0400F720 RID: 63264
		private int method_p2;

		// Token: 0x0400F721 RID: 63265
		private int method_p3;

		// Token: 0x0400F722 RID: 63266
		private int method_p4;
	}
}
