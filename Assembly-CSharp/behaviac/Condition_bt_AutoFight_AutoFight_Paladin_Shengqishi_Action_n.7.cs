using System;

namespace behaviac
{
	// Token: 0x0200281B RID: 10267
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node61 : Condition
	{
		// Token: 0x06013974 RID: 80244 RVA: 0x005D8892 File Offset: 0x005D6C92
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node61()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 372400;
		}

		// Token: 0x06013975 RID: 80245 RVA: 0x005D88B4 File Offset: 0x005D6CB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3D0 RID: 54224
		private BE_Target opl_p0;

		// Token: 0x0400D3D1 RID: 54225
		private BE_Equal opl_p1;

		// Token: 0x0400D3D2 RID: 54226
		private int opl_p2;
	}
}
