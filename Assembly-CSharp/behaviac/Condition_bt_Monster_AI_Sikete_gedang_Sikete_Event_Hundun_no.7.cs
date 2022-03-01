using System;

namespace behaviac
{
	// Token: 0x0200373D RID: 14141
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Sikete_gedang_Sikete_Event_Hundun_node16 : Condition
	{
		// Token: 0x06015685 RID: 87685 RVA: 0x0067563F File Offset: 0x00673A3F
		public Condition_bt_Monster_AI_Sikete_gedang_Sikete_Event_Hundun_node16()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 528401;
		}

		// Token: 0x06015686 RID: 87686 RVA: 0x00675660 File Offset: 0x00673A60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F054 RID: 61524
		private BE_Target opl_p0;

		// Token: 0x0400F055 RID: 61525
		private BE_Equal opl_p1;

		// Token: 0x0400F056 RID: 61526
		private int opl_p2;
	}
}
