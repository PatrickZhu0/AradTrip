using System;

namespace behaviac
{
	// Token: 0x02003F63 RID: 16227
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying3_node11 : Action
	{
		// Token: 0x06016634 RID: 91700 RVA: 0x006C5AC9 File Offset: 0x006C3EC9
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying3_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570217;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06016635 RID: 91701 RVA: 0x006C5B03 File Offset: 0x006C3F03
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE74 RID: 65140
		private BE_Target method_p0;

		// Token: 0x0400FE75 RID: 65141
		private int method_p1;

		// Token: 0x0400FE76 RID: 65142
		private int method_p2;

		// Token: 0x0400FE77 RID: 65143
		private int method_p3;

		// Token: 0x0400FE78 RID: 65144
		private int method_p4;
	}
}
