using System;

namespace behaviac
{
	// Token: 0x020038BD RID: 14525
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node68 : Condition
	{
		// Token: 0x06015959 RID: 88409 RVA: 0x00683EDD File Offset: 0x006822DD
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node68()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570218;
		}

		// Token: 0x0601595A RID: 88410 RVA: 0x00683F00 File Offset: 0x00682300
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F302 RID: 62210
		private BE_Target opl_p0;

		// Token: 0x0400F303 RID: 62211
		private BE_Equal opl_p1;

		// Token: 0x0400F304 RID: 62212
		private int opl_p2;
	}
}
