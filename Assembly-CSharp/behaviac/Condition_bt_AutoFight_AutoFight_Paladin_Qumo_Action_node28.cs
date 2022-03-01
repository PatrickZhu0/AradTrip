using System;

namespace behaviac
{
	// Token: 0x020027CC RID: 10188
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node28 : Condition
	{
		// Token: 0x060138D7 RID: 80087 RVA: 0x005D4AF9 File Offset: 0x005D2EF9
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node28()
		{
			this.opl_p0 = 0.28f;
		}

		// Token: 0x060138D8 RID: 80088 RVA: 0x005D4B0C File Offset: 0x005D2F0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D337 RID: 54071
		private float opl_p0;
	}
}
