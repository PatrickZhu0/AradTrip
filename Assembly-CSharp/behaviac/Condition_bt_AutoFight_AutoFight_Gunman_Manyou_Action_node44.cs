using System;

namespace behaviac
{
	// Token: 0x0200261B RID: 9755
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node44 : Condition
	{
		// Token: 0x0601357C RID: 79228 RVA: 0x005C1115 File Offset: 0x005BF515
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node44()
		{
			this.opl_p0 = 1008;
		}

		// Token: 0x0601357D RID: 79229 RVA: 0x005C1128 File Offset: 0x005BF528
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFC7 RID: 53191
		private int opl_p0;
	}
}
