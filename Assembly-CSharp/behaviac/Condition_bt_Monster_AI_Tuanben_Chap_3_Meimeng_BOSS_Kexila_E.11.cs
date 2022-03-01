using System;

namespace behaviac
{
	// Token: 0x0200396A RID: 14698
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node68 : Condition
	{
		// Token: 0x06015AAB RID: 88747 RVA: 0x0068B3B1 File Offset: 0x006897B1
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node68()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570212;
		}

		// Token: 0x06015AAC RID: 88748 RVA: 0x0068B3D4 File Offset: 0x006897D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F450 RID: 62544
		private BE_Target opl_p0;

		// Token: 0x0400F451 RID: 62545
		private BE_Equal opl_p1;

		// Token: 0x0400F452 RID: 62546
		private int opl_p2;
	}
}
