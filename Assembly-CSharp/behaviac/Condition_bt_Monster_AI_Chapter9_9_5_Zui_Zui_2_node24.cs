using System;

namespace behaviac
{
	// Token: 0x020031F8 RID: 12792
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node24 : Condition
	{
		// Token: 0x06014C7C RID: 85116 RVA: 0x0064262D File Offset: 0x00640A2D
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node24()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570275;
		}

		// Token: 0x06014C7D RID: 85117 RVA: 0x00642650 File Offset: 0x00640A50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5D1 RID: 58833
		private BE_Target opl_p0;

		// Token: 0x0400E5D2 RID: 58834
		private BE_Equal opl_p1;

		// Token: 0x0400E5D3 RID: 58835
		private int opl_p2;
	}
}
