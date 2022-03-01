using System;

namespace behaviac
{
	// Token: 0x0200341E RID: 13342
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Event_node0 : Condition
	{
		// Token: 0x0601508B RID: 86155 RVA: 0x006566F7 File Offset: 0x00654AF7
		public Condition_bt_Monster_AI_Heisedadi_Huimie_Event_node0()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521750;
		}

		// Token: 0x0601508C RID: 86156 RVA: 0x00656718 File Offset: 0x00654B18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E95D RID: 59741
		private BE_Target opl_p0;

		// Token: 0x0400E95E RID: 59742
		private BE_Equal opl_p1;

		// Token: 0x0400E95F RID: 59743
		private int opl_p2;
	}
}
