using System;

namespace behaviac
{
	// Token: 0x02003D0E RID: 15630
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Monster_Baixiaoyurenheti_des_hard_node0 : Condition
	{
		// Token: 0x060161B9 RID: 90553 RVA: 0x006AF01B File Offset: 0x006AD41B
		public Condition_bt_Monster_AI_Tuanben_hard_Monster_Baixiaoyurenheti_des_hard_node0()
		{
			this.opl_p0 = 21302;
		}

		// Token: 0x060161BA RID: 90554 RVA: 0x006AF030 File Offset: 0x006AD430
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA49 RID: 64073
		private int opl_p0;
	}
}
