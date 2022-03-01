using System;

namespace behaviac
{
	// Token: 0x020025A2 RID: 9634
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node16 : Condition
	{
		// Token: 0x0601348B RID: 78987 RVA: 0x005BC1C5 File Offset: 0x005BA5C5
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node16()
		{
			this.opl_p0 = 0.05f;
		}

		// Token: 0x0601348C RID: 78988 RVA: 0x005BC1D8 File Offset: 0x005BA5D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEC1 RID: 52929
		private float opl_p0;
	}
}
