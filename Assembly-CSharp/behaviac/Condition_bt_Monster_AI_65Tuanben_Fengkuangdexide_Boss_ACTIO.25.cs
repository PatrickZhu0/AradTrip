using System;

namespace behaviac
{
	// Token: 0x02002ED2 RID: 11986
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node62 : Condition
	{
		// Token: 0x0601467E RID: 83582 RVA: 0x00622A36 File Offset: 0x00620E36
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node62()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570297;
		}

		// Token: 0x0601467F RID: 83583 RVA: 0x00622A58 File Offset: 0x00620E58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFED RID: 57325
		private BE_Target opl_p0;

		// Token: 0x0400DFEE RID: 57326
		private BE_Equal opl_p1;

		// Token: 0x0400DFEF RID: 57327
		private int opl_p2;
	}
}
