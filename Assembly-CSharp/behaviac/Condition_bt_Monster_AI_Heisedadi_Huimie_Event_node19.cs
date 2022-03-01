using System;

namespace behaviac
{
	// Token: 0x0200342D RID: 13357
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Event_node19 : Condition
	{
		// Token: 0x060150A8 RID: 86184 RVA: 0x00656C1E File Offset: 0x0065501E
		public Condition_bt_Monster_AI_Heisedadi_Huimie_Event_node19()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 29;
		}

		// Token: 0x060150A9 RID: 86185 RVA: 0x00656C3C File Offset: 0x0065503C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E977 RID: 59767
		private BE_Target opl_p0;

		// Token: 0x0400E978 RID: 59768
		private BE_Equal opl_p1;

		// Token: 0x0400E979 RID: 59769
		private int opl_p2;
	}
}
