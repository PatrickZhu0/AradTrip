using System;

namespace behaviac
{
	// Token: 0x02003F5E RID: 16222
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying3_node6 : Action
	{
		// Token: 0x0601662A RID: 91690 RVA: 0x006C5945 File Offset: 0x006C3D45
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying3_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570231;
			this.method_p2 = 30000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x0601662B RID: 91691 RVA: 0x006C597F File Offset: 0x006C3D7F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE69 RID: 65129
		private BE_Target method_p0;

		// Token: 0x0400FE6A RID: 65130
		private int method_p1;

		// Token: 0x0400FE6B RID: 65131
		private int method_p2;

		// Token: 0x0400FE6C RID: 65132
		private int method_p3;

		// Token: 0x0400FE6D RID: 65133
		private int method_p4;
	}
}
