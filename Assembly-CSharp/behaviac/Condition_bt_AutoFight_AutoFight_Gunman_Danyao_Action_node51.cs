using System;

namespace behaviac
{
	// Token: 0x020025AA RID: 9642
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node51 : Condition
	{
		// Token: 0x0601349B RID: 79003 RVA: 0x005BC52D File Offset: 0x005BA92D
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node51()
		{
			this.opl_p0 = 0.05f;
		}

		// Token: 0x0601349C RID: 79004 RVA: 0x005BC540 File Offset: 0x005BA940
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CED1 RID: 52945
		private float opl_p0;
	}
}
