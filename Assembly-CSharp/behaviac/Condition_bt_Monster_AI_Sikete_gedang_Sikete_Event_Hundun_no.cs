using System;

namespace behaviac
{
	// Token: 0x02003735 RID: 14133
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Sikete_gedang_Sikete_Event_Hundun_node2 : Condition
	{
		// Token: 0x06015675 RID: 87669 RVA: 0x00675353 File Offset: 0x00673753
		public Condition_bt_Monster_AI_Sikete_gedang_Sikete_Event_Hundun_node2()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06015676 RID: 87670 RVA: 0x00675368 File Offset: 0x00673768
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F043 RID: 61507
		private float opl_p0;
	}
}
