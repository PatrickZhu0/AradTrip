using System;

namespace behaviac
{
	// Token: 0x02003D31 RID: 15665
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node8 : Condition
	{
		// Token: 0x060161FB RID: 90619 RVA: 0x006B03ED File Offset: 0x006AE7ED
		public Condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node8()
		{
			this.opl_p0 = 21300;
		}

		// Token: 0x060161FC RID: 90620 RVA: 0x006B0400 File Offset: 0x006AE800
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA72 RID: 64114
		private int opl_p0;
	}
}
