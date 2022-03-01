using System;

namespace behaviac
{
	// Token: 0x02002256 RID: 8790
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node59 : Condition
	{
		// Token: 0x06012E34 RID: 77364 RVA: 0x005916BC File Offset: 0x0058FABC
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node59()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06012E35 RID: 77365 RVA: 0x005916D0 File Offset: 0x0058FAD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C839 RID: 51257
		private float opl_p0;
	}
}
