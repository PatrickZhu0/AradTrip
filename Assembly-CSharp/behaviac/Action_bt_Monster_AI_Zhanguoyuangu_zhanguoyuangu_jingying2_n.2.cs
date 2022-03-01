using System;

namespace behaviac
{
	// Token: 0x02003F54 RID: 16212
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node11 : Action
	{
		// Token: 0x06016617 RID: 91671 RVA: 0x006C5255 File Offset: 0x006C3655
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570217;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06016618 RID: 91672 RVA: 0x006C528F File Offset: 0x006C368F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE4C RID: 65100
		private BE_Target method_p0;

		// Token: 0x0400FE4D RID: 65101
		private int method_p1;

		// Token: 0x0400FE4E RID: 65102
		private int method_p2;

		// Token: 0x0400FE4F RID: 65103
		private int method_p3;

		// Token: 0x0400FE50 RID: 65104
		private int method_p4;
	}
}
