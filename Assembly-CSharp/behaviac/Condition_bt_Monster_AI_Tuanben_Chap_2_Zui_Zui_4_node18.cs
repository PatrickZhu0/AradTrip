using System;

namespace behaviac
{
	// Token: 0x02003816 RID: 14358
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node18 : Condition
	{
		// Token: 0x0601581B RID: 88091 RVA: 0x0067D8A8 File Offset: 0x0067BCA8
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node18()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521660;
		}

		// Token: 0x0601581C RID: 88092 RVA: 0x0067D8CC File Offset: 0x0067BCCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F1DD RID: 61917
		private BE_Target opl_p0;

		// Token: 0x0400F1DE RID: 61918
		private BE_Equal opl_p1;

		// Token: 0x0400F1DF RID: 61919
		private int opl_p2;
	}
}
