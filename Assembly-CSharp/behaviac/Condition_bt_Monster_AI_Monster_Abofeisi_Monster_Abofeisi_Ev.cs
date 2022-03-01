using System;

namespace behaviac
{
	// Token: 0x020035D9 RID: 13785
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node3 : Condition
	{
		// Token: 0x060153DB RID: 87003 RVA: 0x006672A3 File Offset: 0x006656A3
		public Condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node3()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060153DC RID: 87004 RVA: 0x006672B8 File Offset: 0x006656B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED9E RID: 60830
		private float opl_p0;
	}
}
