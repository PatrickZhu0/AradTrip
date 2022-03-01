using System;

namespace behaviac
{
	// Token: 0x02003D0D RID: 15629
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Monster_Baixiaoyurenheti_des_hard_node8 : Condition
	{
		// Token: 0x060161B7 RID: 90551 RVA: 0x006AEFD5 File Offset: 0x006AD3D5
		public Condition_bt_Monster_AI_Tuanben_hard_Monster_Baixiaoyurenheti_des_hard_node8()
		{
			this.opl_p0 = 21302;
		}

		// Token: 0x060161B8 RID: 90552 RVA: 0x006AEFE8 File Offset: 0x006AD3E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA48 RID: 64072
		private int opl_p0;
	}
}
