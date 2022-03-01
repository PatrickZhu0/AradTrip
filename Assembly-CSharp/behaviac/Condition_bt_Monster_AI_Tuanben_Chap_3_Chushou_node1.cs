using System;

namespace behaviac
{
	// Token: 0x02003826 RID: 14374
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Chushou_node1 : Condition
	{
		// Token: 0x06015838 RID: 88120 RVA: 0x0067E409 File Offset: 0x0067C809
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Chushou_node1()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521638;
		}

		// Token: 0x06015839 RID: 88121 RVA: 0x0067E42C File Offset: 0x0067C82C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F1F4 RID: 61940
		private BE_Target opl_p0;

		// Token: 0x0400F1F5 RID: 61941
		private BE_Equal opl_p1;

		// Token: 0x0400F1F6 RID: 61942
		private int opl_p2;
	}
}
