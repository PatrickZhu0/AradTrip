using System;

namespace behaviac
{
	// Token: 0x020025A3 RID: 9635
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node17 : Condition
	{
		// Token: 0x0601348D RID: 78989 RVA: 0x005BC20B File Offset: 0x005BA60B
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node17()
		{
			this.opl_p0 = 1300;
		}

		// Token: 0x0601348E RID: 78990 RVA: 0x005BC220 File Offset: 0x005BA620
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEC2 RID: 52930
		private int opl_p0;
	}
}
