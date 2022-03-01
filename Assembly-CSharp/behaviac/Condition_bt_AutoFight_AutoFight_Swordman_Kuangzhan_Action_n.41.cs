using System;

namespace behaviac
{
	// Token: 0x0200297A RID: 10618
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node1 : Condition
	{
		// Token: 0x06013C29 RID: 80937 RVA: 0x005E8347 File Offset: 0x005E6747
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node1()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 160900;
		}

		// Token: 0x06013C2A RID: 80938 RVA: 0x005E8368 File Offset: 0x005E6768
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D68F RID: 54927
		private BE_Target opl_p0;

		// Token: 0x0400D690 RID: 54928
		private BE_Equal opl_p1;

		// Token: 0x0400D691 RID: 54929
		private int opl_p2;
	}
}
