using System;

namespace behaviac
{
	// Token: 0x02003D1F RID: 15647
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Monster_Hongxiaoyurenheti_des_hard_node8 : Condition
	{
		// Token: 0x060161D9 RID: 90585 RVA: 0x006AF9E1 File Offset: 0x006ADDE1
		public Condition_bt_Monster_AI_Tuanben_hard_Monster_Hongxiaoyurenheti_des_hard_node8()
		{
			this.opl_p0 = 31301;
		}

		// Token: 0x060161DA RID: 90586 RVA: 0x006AF9F4 File Offset: 0x006ADDF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA5D RID: 64093
		private int opl_p0;
	}
}
