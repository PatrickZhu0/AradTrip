using System;

namespace behaviac
{
	// Token: 0x020037C1 RID: 14273
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node7 : Condition
	{
		// Token: 0x06015782 RID: 87938 RVA: 0x0067AEF3 File Offset: 0x006792F3
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node7()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521619;
		}

		// Token: 0x06015783 RID: 87939 RVA: 0x0067AF14 File Offset: 0x00679314
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F134 RID: 61748
		private BE_Target opl_p0;

		// Token: 0x0400F135 RID: 61749
		private BE_Equal opl_p1;

		// Token: 0x0400F136 RID: 61750
		private int opl_p2;
	}
}
