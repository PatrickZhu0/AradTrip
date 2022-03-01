using System;

namespace behaviac
{
	// Token: 0x0200263B RID: 9787
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node27 : Condition
	{
		// Token: 0x060135BC RID: 79292 RVA: 0x005C1F05 File Offset: 0x005C0305
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node27()
		{
			this.opl_p0 = 1000;
		}

		// Token: 0x060135BD RID: 79293 RVA: 0x005C1F18 File Offset: 0x005C0318
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D00B RID: 53259
		private int opl_p0;
	}
}
