using System;

namespace behaviac
{
	// Token: 0x020022EC RID: 8940
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node59 : Condition
	{
		// Token: 0x06012F51 RID: 77649 RVA: 0x0059A37D File Offset: 0x0059877D
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node59()
		{
			this.opl_p0 = 1906;
		}

		// Token: 0x06012F52 RID: 77650 RVA: 0x0059A390 File Offset: 0x00598790
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C965 RID: 51557
		private int opl_p0;
	}
}
