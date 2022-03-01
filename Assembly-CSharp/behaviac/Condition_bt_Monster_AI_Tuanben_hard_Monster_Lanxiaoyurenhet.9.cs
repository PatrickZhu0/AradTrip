using System;

namespace behaviac
{
	// Token: 0x02003D32 RID: 15666
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node0 : Condition
	{
		// Token: 0x060161FD RID: 90621 RVA: 0x006B0433 File Offset: 0x006AE833
		public Condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node0()
		{
			this.opl_p0 = 21300;
		}

		// Token: 0x060161FE RID: 90622 RVA: 0x006B0448 File Offset: 0x006AE848
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA73 RID: 64115
		private int opl_p0;
	}
}
