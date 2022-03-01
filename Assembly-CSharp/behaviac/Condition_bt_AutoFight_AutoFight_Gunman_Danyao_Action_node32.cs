using System;

namespace behaviac
{
	// Token: 0x020025BE RID: 9662
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node32 : Condition
	{
		// Token: 0x060134C3 RID: 79043 RVA: 0x005BCD49 File Offset: 0x005BB149
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node32()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x060134C4 RID: 79044 RVA: 0x005BCD5C File Offset: 0x005BB15C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF01 RID: 52993
		private float opl_p0;
	}
}
