using System;

namespace behaviac
{
	// Token: 0x0200380C RID: 14348
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node4 : Condition
	{
		// Token: 0x06015807 RID: 88071 RVA: 0x0067D521 File Offset: 0x0067B921
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node4()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521623;
		}

		// Token: 0x06015808 RID: 88072 RVA: 0x0067D544 File Offset: 0x0067B944
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F1CB RID: 61899
		private BE_Target opl_p0;

		// Token: 0x0400F1CC RID: 61900
		private BE_Equal opl_p1;

		// Token: 0x0400F1CD RID: 61901
		private int opl_p2;
	}
}
