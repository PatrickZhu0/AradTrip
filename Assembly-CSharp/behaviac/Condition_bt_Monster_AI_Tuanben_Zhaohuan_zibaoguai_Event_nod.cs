using System;

namespace behaviac
{
	// Token: 0x02003B7C RID: 15228
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node13 : Condition
	{
		// Token: 0x06015EAA RID: 89770 RVA: 0x0069F7D8 File Offset: 0x0069DBD8
		public Condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node13()
		{
			this.opl_p0 = 570153;
		}

		// Token: 0x06015EAB RID: 89771 RVA: 0x0069F7EC File Offset: 0x0069DBEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_PlayerHaveBuff(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F771 RID: 63345
		private int opl_p0;
	}
}
