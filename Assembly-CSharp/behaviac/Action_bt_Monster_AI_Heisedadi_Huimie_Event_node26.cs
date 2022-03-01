using System;

namespace behaviac
{
	// Token: 0x0200343C RID: 13372
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Huimie_Event_node26 : Action
	{
		// Token: 0x060150C6 RID: 86214 RVA: 0x006573C2 File Offset: 0x006557C2
		public Action_bt_Monster_AI_Heisedadi_Huimie_Event_node26()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 29;
			this.method_p2 = 3000;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060150C7 RID: 86215 RVA: 0x006573FA File Offset: 0x006557FA
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E996 RID: 59798
		private BE_Target method_p0;

		// Token: 0x0400E997 RID: 59799
		private int method_p1;

		// Token: 0x0400E998 RID: 59800
		private int method_p2;

		// Token: 0x0400E999 RID: 59801
		private int method_p3;

		// Token: 0x0400E99A RID: 59802
		private int method_p4;
	}
}
