using System;

namespace behaviac
{
	// Token: 0x02003109 RID: 12553
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node1 : Condition
	{
		// Token: 0x06014ABD RID: 84669 RVA: 0x00639954 File Offset: 0x00637D54
		public Condition_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node1()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 522065;
		}

		// Token: 0x06014ABE RID: 84670 RVA: 0x00639978 File Offset: 0x00637D78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E42E RID: 58414
		private BE_Target opl_p0;

		// Token: 0x0400E42F RID: 58415
		private BE_Equal opl_p1;

		// Token: 0x0400E430 RID: 58416
		private int opl_p2;
	}
}
