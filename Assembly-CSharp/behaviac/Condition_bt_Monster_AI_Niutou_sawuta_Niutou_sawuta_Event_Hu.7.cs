using System;

namespace behaviac
{
	// Token: 0x0200371F RID: 14111
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node16 : Condition
	{
		// Token: 0x0601564B RID: 87627 RVA: 0x00674487 File Offset: 0x00672887
		public Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node16()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 528401;
		}

		// Token: 0x0601564C RID: 87628 RVA: 0x006744A8 File Offset: 0x006728A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F017 RID: 61463
		private BE_Target opl_p0;

		// Token: 0x0400F018 RID: 61464
		private BE_Equal opl_p1;

		// Token: 0x0400F019 RID: 61465
		private int opl_p2;
	}
}
