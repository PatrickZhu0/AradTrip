using System;

namespace behaviac
{
	// Token: 0x02003B82 RID: 15234
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node12 : Action
	{
		// Token: 0x06015EB6 RID: 89782 RVA: 0x0069F9D5 File Offset: 0x0069DDD5
		public Action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node12()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Enemy;
			this.method_p1 = 570153;
			this.method_p2 = 6000000;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x06015EB7 RID: 89783 RVA: 0x0069FA0F File Offset: 0x0069DE0F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F779 RID: 63353
		private BE_Target method_p0;

		// Token: 0x0400F77A RID: 63354
		private int method_p1;

		// Token: 0x0400F77B RID: 63355
		private int method_p2;

		// Token: 0x0400F77C RID: 63356
		private int method_p3;

		// Token: 0x0400F77D RID: 63357
		private int method_p4;
	}
}
