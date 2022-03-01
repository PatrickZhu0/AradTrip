using System;

namespace behaviac
{
	// Token: 0x02003197 RID: 12695
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Zhengchangtai_node3 : Action
	{
		// Token: 0x06014BC3 RID: 84931 RVA: 0x0063EBEF File Offset: 0x0063CFEF
		public Action_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Zhengchangtai_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521782;
			this.method_p2 = 100;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x06014BC4 RID: 84932 RVA: 0x0063EC27 File Offset: 0x0063D027
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E532 RID: 58674
		private BE_Target method_p0;

		// Token: 0x0400E533 RID: 58675
		private int method_p1;

		// Token: 0x0400E534 RID: 58676
		private int method_p2;

		// Token: 0x0400E535 RID: 58677
		private int method_p3;

		// Token: 0x0400E536 RID: 58678
		private int method_p4;
	}
}
