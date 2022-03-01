using System;

namespace behaviac
{
	// Token: 0x02002813 RID: 10259
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node46 : Condition
	{
		// Token: 0x06013964 RID: 80228 RVA: 0x005D855A File Offset: 0x005D695A
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node46()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 370300;
		}

		// Token: 0x06013965 RID: 80229 RVA: 0x005D857C File Offset: 0x005D697C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3C2 RID: 54210
		private BE_Target opl_p0;

		// Token: 0x0400D3C3 RID: 54211
		private BE_Equal opl_p1;

		// Token: 0x0400D3C4 RID: 54212
		private int opl_p2;
	}
}
