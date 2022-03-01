using System;

namespace behaviac
{
	// Token: 0x020025C9 RID: 9673
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node107 : Condition
	{
		// Token: 0x060134D9 RID: 79065 RVA: 0x005BD1EA File Offset: 0x005BB5EA
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node107()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 130301;
		}

		// Token: 0x060134DA RID: 79066 RVA: 0x005BD20C File Offset: 0x005BB60C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF15 RID: 53013
		private BE_Target opl_p0;

		// Token: 0x0400CF16 RID: 53014
		private BE_Equal opl_p1;

		// Token: 0x0400CF17 RID: 53015
		private int opl_p2;
	}
}
