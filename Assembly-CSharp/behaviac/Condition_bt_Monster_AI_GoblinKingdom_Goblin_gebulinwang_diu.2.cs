using System;

namespace behaviac
{
	// Token: 0x02003324 RID: 13092
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node4 : Condition
	{
		// Token: 0x06014EAE RID: 85678 RVA: 0x0064D7D5 File Offset: 0x0064BBD5
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node4()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.6f;
		}

		// Token: 0x06014EAF RID: 85679 RVA: 0x0064D7F8 File Offset: 0x0064BBF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E798 RID: 59288
		private HMType opl_p0;

		// Token: 0x0400E799 RID: 59289
		private BE_Operation opl_p1;

		// Token: 0x0400E79A RID: 59290
		private float opl_p2;
	}
}
