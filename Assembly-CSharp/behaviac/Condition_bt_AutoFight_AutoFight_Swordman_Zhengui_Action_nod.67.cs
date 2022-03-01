using System;

namespace behaviac
{
	// Token: 0x020029D4 RID: 10708
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node131 : Condition
	{
		// Token: 0x06013CDC RID: 81116 RVA: 0x005EBD7E File Offset: 0x005EA17E
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node131()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 181101;
		}

		// Token: 0x06013CDD RID: 81117 RVA: 0x005EBDA0 File Offset: 0x005EA1A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D74C RID: 55116
		private BE_Target opl_p0;

		// Token: 0x0400D74D RID: 55117
		private BE_Equal opl_p1;

		// Token: 0x0400D74E RID: 55118
		private int opl_p2;
	}
}
