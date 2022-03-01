using System;

namespace behaviac
{
	// Token: 0x0200281F RID: 10271
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node66 : Condition
	{
		// Token: 0x0601397C RID: 80252 RVA: 0x005D8A2E File Offset: 0x005D6E2E
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node66()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 370600;
		}

		// Token: 0x0601397D RID: 80253 RVA: 0x005D8A50 File Offset: 0x005D6E50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3D7 RID: 54231
		private BE_Target opl_p0;

		// Token: 0x0400D3D8 RID: 54232
		private BE_Equal opl_p1;

		// Token: 0x0400D3D9 RID: 54233
		private int opl_p2;
	}
}
