using System;

namespace behaviac
{
	// Token: 0x020037BC RID: 14268
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node1 : Condition
	{
		// Token: 0x06015779 RID: 87929 RVA: 0x0067AC05 File Offset: 0x00679005
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node1()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521618;
		}

		// Token: 0x0601577A RID: 87930 RVA: 0x0067AC28 File Offset: 0x00679028
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F128 RID: 61736
		private BE_Target opl_p0;

		// Token: 0x0400F129 RID: 61737
		private BE_Equal opl_p1;

		// Token: 0x0400F12A RID: 61738
		private int opl_p2;
	}
}
