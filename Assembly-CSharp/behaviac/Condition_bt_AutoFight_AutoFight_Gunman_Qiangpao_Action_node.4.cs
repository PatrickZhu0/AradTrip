using System;

namespace behaviac
{
	// Token: 0x02002641 RID: 9793
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node94 : Condition
	{
		// Token: 0x060135C7 RID: 79303 RVA: 0x005C36A7 File Offset: 0x005C1AA7
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node94()
		{
			this.opl_p0 = 1015;
		}

		// Token: 0x060135C8 RID: 79304 RVA: 0x005C36BC File Offset: 0x005C1ABC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D016 RID: 53270
		private int opl_p0;
	}
}
