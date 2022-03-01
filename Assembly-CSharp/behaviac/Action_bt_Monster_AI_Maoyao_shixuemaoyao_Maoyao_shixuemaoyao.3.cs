using System;

namespace behaviac
{
	// Token: 0x020035C7 RID: 13767
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_node17 : Action
	{
		// Token: 0x060153B9 RID: 86969 RVA: 0x0066643F File Offset: 0x0066483F
		public Action_bt_Monster_AI_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_node17()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 30;
			this.method_p2 = -1;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x060153BA RID: 86970 RVA: 0x00666472 File Offset: 0x00664872
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED7B RID: 60795
		private BE_Target method_p0;

		// Token: 0x0400ED7C RID: 60796
		private int method_p1;

		// Token: 0x0400ED7D RID: 60797
		private int method_p2;

		// Token: 0x0400ED7E RID: 60798
		private int method_p3;

		// Token: 0x0400ED7F RID: 60799
		private int method_p4;
	}
}
