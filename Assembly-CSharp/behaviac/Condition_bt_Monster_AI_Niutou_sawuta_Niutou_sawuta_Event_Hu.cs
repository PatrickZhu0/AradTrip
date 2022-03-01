using System;

namespace behaviac
{
	// Token: 0x02003717 RID: 14103
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node2 : Condition
	{
		// Token: 0x0601563B RID: 87611 RVA: 0x0067419D File Offset: 0x0067259D
		public Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node2()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x0601563C RID: 87612 RVA: 0x006741B0 File Offset: 0x006725B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F006 RID: 61446
		private float opl_p0;
	}
}
