using System;

namespace behaviac
{
	// Token: 0x02003B00 RID: 15104
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_des_node8 : Condition
	{
		// Token: 0x06015DBB RID: 89531 RVA: 0x0069AEC1 File Offset: 0x006992C1
		public Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_des_node8()
		{
			this.opl_p0 = 31301;
		}

		// Token: 0x06015DBC RID: 89532 RVA: 0x0069AED4 File Offset: 0x006992D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6B5 RID: 63157
		private int opl_p0;
	}
}
