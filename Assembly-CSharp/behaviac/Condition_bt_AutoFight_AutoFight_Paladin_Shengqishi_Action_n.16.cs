using System;

namespace behaviac
{
	// Token: 0x02002827 RID: 10279
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node71 : Condition
	{
		// Token: 0x0601398C RID: 80268 RVA: 0x005D8D66 File Offset: 0x005D7166
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node71()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 370800;
		}

		// Token: 0x0601398D RID: 80269 RVA: 0x005D8D88 File Offset: 0x005D7188
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3E5 RID: 54245
		private BE_Target opl_p0;

		// Token: 0x0400D3E6 RID: 54246
		private BE_Equal opl_p1;

		// Token: 0x0400D3E7 RID: 54247
		private int opl_p2;
	}
}
