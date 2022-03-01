using System;

namespace behaviac
{
	// Token: 0x020025F5 RID: 9717
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node4 : Condition
	{
		// Token: 0x06013530 RID: 79152 RVA: 0x005BFFD1 File Offset: 0x005BE3D1
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node4()
		{
			this.opl_p0 = 1108;
		}

		// Token: 0x06013531 RID: 79153 RVA: 0x005BFFE4 File Offset: 0x005BE3E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF79 RID: 53113
		private int opl_p0;
	}
}
