using System;

namespace behaviac
{
	// Token: 0x02003B54 RID: 15188
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node17 : Action
	{
		// Token: 0x06015E5D RID: 89693 RVA: 0x0069D90F File Offset: 0x0069BD0F
		public Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node17()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570070;
			this.method_p2 = 0;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015E5E RID: 89694 RVA: 0x0069D946 File Offset: 0x0069BD46
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F729 RID: 63273
		private BE_Target method_p0;

		// Token: 0x0400F72A RID: 63274
		private int method_p1;

		// Token: 0x0400F72B RID: 63275
		private int method_p2;

		// Token: 0x0400F72C RID: 63276
		private int method_p3;

		// Token: 0x0400F72D RID: 63277
		private int method_p4;
	}
}
