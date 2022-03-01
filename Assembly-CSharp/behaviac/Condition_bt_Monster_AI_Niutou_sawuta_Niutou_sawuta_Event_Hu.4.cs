using System;

namespace behaviac
{
	// Token: 0x0200371A RID: 14106
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node5 : Condition
	{
		// Token: 0x06015641 RID: 87617 RVA: 0x006742B7 File Offset: 0x006726B7
		public Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node5()
		{
			this.opl_p0 = 5310;
		}

		// Token: 0x06015642 RID: 87618 RVA: 0x006742CC File Offset: 0x006726CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F00E RID: 61454
		private int opl_p0;
	}
}
