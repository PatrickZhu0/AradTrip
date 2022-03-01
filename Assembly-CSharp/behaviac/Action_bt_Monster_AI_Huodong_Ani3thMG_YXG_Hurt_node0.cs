using System;

namespace behaviac
{
	// Token: 0x02003568 RID: 13672
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Hurt_node0 : Action
	{
		// Token: 0x06015309 RID: 86793 RVA: 0x00662F60 File Offset: 0x00661360
		public Action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Hurt_node0()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 150;
			this.method_p1 = 0;
		}

		// Token: 0x0601530A RID: 86794 RVA: 0x00662F84 File Offset: 0x00661384
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400ECC0 RID: 60608
		private int method_p0;

		// Token: 0x0400ECC1 RID: 60609
		private int method_p1;
	}
}
