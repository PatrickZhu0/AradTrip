using System;

namespace behaviac
{
	// Token: 0x02002EB6 RID: 11958
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node83 : Condition
	{
		// Token: 0x06014646 RID: 83526 RVA: 0x0062209A File Offset: 0x0062049A
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node83()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570297;
		}

		// Token: 0x06014647 RID: 83527 RVA: 0x006220BC File Offset: 0x006204BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFB9 RID: 57273
		private BE_Target opl_p0;

		// Token: 0x0400DFBA RID: 57274
		private BE_Equal opl_p1;

		// Token: 0x0400DFBB RID: 57275
		private int opl_p2;
	}
}
