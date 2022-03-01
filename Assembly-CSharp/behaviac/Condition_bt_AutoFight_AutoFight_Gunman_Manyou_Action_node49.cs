using System;

namespace behaviac
{
	// Token: 0x0200262F RID: 9775
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node49 : Condition
	{
		// Token: 0x060135A4 RID: 79268 RVA: 0x005C19E9 File Offset: 0x005BFDE9
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node49()
		{
			this.opl_p0 = 1005;
		}

		// Token: 0x060135A5 RID: 79269 RVA: 0x005C19FC File Offset: 0x005BFDFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFF3 RID: 53235
		private int opl_p0;
	}
}
