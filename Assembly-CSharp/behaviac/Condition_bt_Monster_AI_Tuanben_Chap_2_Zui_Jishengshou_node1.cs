using System;

namespace behaviac
{
	// Token: 0x020037B7 RID: 14263
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node1 : Condition
	{
		// Token: 0x06015770 RID: 87920 RVA: 0x0067A919 File Offset: 0x00678D19
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node1()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521617;
		}

		// Token: 0x06015771 RID: 87921 RVA: 0x0067A93C File Offset: 0x00678D3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F11C RID: 61724
		private BE_Target opl_p0;

		// Token: 0x0400F11D RID: 61725
		private BE_Equal opl_p1;

		// Token: 0x0400F11E RID: 61726
		private int opl_p2;
	}
}
