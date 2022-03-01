using System;

namespace behaviac
{
	// Token: 0x02003D20 RID: 15648
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Monster_Hongxiaoyurenheti_des_hard_node0 : Condition
	{
		// Token: 0x060161DB RID: 90587 RVA: 0x006AFA27 File Offset: 0x006ADE27
		public Condition_bt_Monster_AI_Tuanben_hard_Monster_Hongxiaoyurenheti_des_hard_node0()
		{
			this.opl_p0 = 21301;
		}

		// Token: 0x060161DC RID: 90588 RVA: 0x006AFA3C File Offset: 0x006ADE3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA5E RID: 64094
		private int opl_p0;
	}
}
