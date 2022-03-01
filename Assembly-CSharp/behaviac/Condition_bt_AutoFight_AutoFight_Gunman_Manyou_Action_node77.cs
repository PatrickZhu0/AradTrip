using System;

namespace behaviac
{
	// Token: 0x02002627 RID: 9767
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node77 : Condition
	{
		// Token: 0x06013594 RID: 79252 RVA: 0x005C1681 File Offset: 0x005BFA81
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node77()
		{
			this.opl_p0 = 1009;
		}

		// Token: 0x06013595 RID: 79253 RVA: 0x005C1694 File Offset: 0x005BFA94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFE3 RID: 53219
		private int opl_p0;
	}
}
