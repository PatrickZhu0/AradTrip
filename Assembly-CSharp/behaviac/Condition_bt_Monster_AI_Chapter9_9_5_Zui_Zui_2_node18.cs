using System;

namespace behaviac
{
	// Token: 0x020031F1 RID: 12785
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node18 : Condition
	{
		// Token: 0x06014C6E RID: 85102 RVA: 0x00642400 File Offset: 0x00640800
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node18()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570275;
		}

		// Token: 0x06014C6F RID: 85103 RVA: 0x00642424 File Offset: 0x00640824
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5C6 RID: 58822
		private BE_Target opl_p0;

		// Token: 0x0400E5C7 RID: 58823
		private BE_Equal opl_p1;

		// Token: 0x0400E5C8 RID: 58824
		private int opl_p2;
	}
}
