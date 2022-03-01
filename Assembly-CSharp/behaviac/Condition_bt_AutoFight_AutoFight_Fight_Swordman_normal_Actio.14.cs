using System;

namespace behaviac
{
	// Token: 0x0200244C RID: 9292
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node40 : Condition
	{
		// Token: 0x060131EC RID: 78316 RVA: 0x005AC047 File Offset: 0x005AA447
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node40()
		{
			this.opl_p0 = 1512;
		}

		// Token: 0x060131ED RID: 78317 RVA: 0x005AC05C File Offset: 0x005AA45C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC15 RID: 52245
		private int opl_p0;
	}
}
