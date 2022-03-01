using System;

namespace behaviac
{
	// Token: 0x02002C81 RID: 11393
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_Destination_node10 : Condition
	{
		// Token: 0x060141FA RID: 82426 RVA: 0x0060B447 File Offset: 0x00609847
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_Destination_node10()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060141FB RID: 82427 RVA: 0x0060B45C File Offset: 0x0060985C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBC0 RID: 56256
		private float opl_p0;
	}
}
