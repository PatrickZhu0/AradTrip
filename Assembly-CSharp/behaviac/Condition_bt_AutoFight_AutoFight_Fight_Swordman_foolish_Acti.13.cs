using System;

namespace behaviac
{
	// Token: 0x02002290 RID: 8848
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node27 : Condition
	{
		// Token: 0x06012EA0 RID: 77472 RVA: 0x005942DA File Offset: 0x005926DA
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node27()
		{
			this.opl_p0 = 1510;
		}

		// Token: 0x06012EA1 RID: 77473 RVA: 0x005942F0 File Offset: 0x005926F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8AC RID: 51372
		private int opl_p0;
	}
}
