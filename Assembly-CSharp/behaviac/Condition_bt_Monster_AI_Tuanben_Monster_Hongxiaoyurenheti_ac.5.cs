using System;

namespace behaviac
{
	// Token: 0x02003AFB RID: 15099
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node3 : Condition
	{
		// Token: 0x06015DB2 RID: 89522 RVA: 0x0069AA06 File Offset: 0x00698E06
		public Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node3()
		{
			this.opl_p0 = 21021;
		}

		// Token: 0x06015DB3 RID: 89523 RVA: 0x0069AA1C File Offset: 0x00698E1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6AC RID: 63148
		private int opl_p0;
	}
}
