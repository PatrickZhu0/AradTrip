using System;

namespace behaviac
{
	// Token: 0x02003DC8 RID: 15816
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node18 : Action
	{
		// Token: 0x0601631F RID: 90911 RVA: 0x006B59FE File Offset: 0x006B3DFE
		public Action_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node18()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 52172;
			this.method_p2 = 100000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06016320 RID: 90912 RVA: 0x006B5A38 File Offset: 0x006B3E38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB7C RID: 64380
		private BE_Target method_p0;

		// Token: 0x0400FB7D RID: 64381
		private int method_p1;

		// Token: 0x0400FB7E RID: 64382
		private int method_p2;

		// Token: 0x0400FB7F RID: 64383
		private int method_p3;

		// Token: 0x0400FB80 RID: 64384
		private int method_p4;
	}
}
