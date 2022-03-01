using System;

namespace behaviac
{
	// Token: 0x020035EB RID: 13803
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Bantuzu_yetuaimuli_Monster_Bantuzu_yetuaimuli_Event_yetuaimuli_node2 : Condition
	{
		// Token: 0x060153FD RID: 87037 RVA: 0x00667DFB File Offset: 0x006661FB
		public Condition_bt_Monster_AI_Monster_Bantuzu_yetuaimuli_Monster_Bantuzu_yetuaimuli_Event_yetuaimuli_node2()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060153FE RID: 87038 RVA: 0x00667E10 File Offset: 0x00666210
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDB7 RID: 60855
		private float opl_p0;
	}
}
