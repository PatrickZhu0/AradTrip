using System;

namespace behaviac
{
	// Token: 0x02003469 RID: 13417
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node3 : Condition
	{
		// Token: 0x0601511D RID: 86301 RVA: 0x00659562 File Offset: 0x00657962
		public Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node3()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x0601511E RID: 86302 RVA: 0x00659578 File Offset: 0x00657978
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA1E RID: 59934
		private float opl_p0;
	}
}
