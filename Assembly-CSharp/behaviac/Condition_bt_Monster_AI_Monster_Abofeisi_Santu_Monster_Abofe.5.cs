using System;

namespace behaviac
{
	// Token: 0x020035E7 RID: 13799
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Abofeisi_Santu_Monster_Abofeisi_Santu_Event_node25 : Condition
	{
		// Token: 0x060153F6 RID: 87030 RVA: 0x006679FB File Offset: 0x00665DFB
		public Condition_bt_Monster_AI_Monster_Abofeisi_Santu_Monster_Abofeisi_Santu_Event_node25()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060153F7 RID: 87031 RVA: 0x00667A10 File Offset: 0x00665E10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDB3 RID: 60851
		private float opl_p0;
	}
}
