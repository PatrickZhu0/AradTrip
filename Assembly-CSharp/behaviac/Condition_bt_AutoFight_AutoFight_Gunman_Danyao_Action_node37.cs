using System;

namespace behaviac
{
	// Token: 0x020025A7 RID: 9639
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node37 : Condition
	{
		// Token: 0x06013495 RID: 78997 RVA: 0x005BC3BF File Offset: 0x005BA7BF
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node37()
		{
			this.opl_p0 = 1309;
		}

		// Token: 0x06013496 RID: 78998 RVA: 0x005BC3D4 File Offset: 0x005BA7D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CECA RID: 52938
		private int opl_p0;
	}
}
