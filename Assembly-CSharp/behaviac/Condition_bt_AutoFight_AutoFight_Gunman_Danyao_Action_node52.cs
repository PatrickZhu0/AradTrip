using System;

namespace behaviac
{
	// Token: 0x020025AB RID: 9643
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node52 : Condition
	{
		// Token: 0x0601349D RID: 79005 RVA: 0x005BC573 File Offset: 0x005BA973
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node52()
		{
			this.opl_p0 = 1011;
		}

		// Token: 0x0601349E RID: 79006 RVA: 0x005BC588 File Offset: 0x005BA988
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CED2 RID: 52946
		private int opl_p0;
	}
}
