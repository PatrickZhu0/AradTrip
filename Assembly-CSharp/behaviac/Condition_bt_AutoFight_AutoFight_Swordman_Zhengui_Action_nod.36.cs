using System;

namespace behaviac
{
	// Token: 0x020029AC RID: 10668
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node109 : Condition
	{
		// Token: 0x06013C8C RID: 81036 RVA: 0x005EABDB File Offset: 0x005E8FDB
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node109()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013C8D RID: 81037 RVA: 0x005EAC10 File Offset: 0x005E9010
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6F6 RID: 55030
		private int opl_p0;

		// Token: 0x0400D6F7 RID: 55031
		private int opl_p1;

		// Token: 0x0400D6F8 RID: 55032
		private int opl_p2;

		// Token: 0x0400D6F9 RID: 55033
		private int opl_p3;
	}
}
