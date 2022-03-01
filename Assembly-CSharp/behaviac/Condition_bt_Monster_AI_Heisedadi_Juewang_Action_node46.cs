using System;

namespace behaviac
{
	// Token: 0x02003467 RID: 13415
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node46 : Condition
	{
		// Token: 0x06015119 RID: 86297 RVA: 0x006594B9 File Offset: 0x006578B9
		public Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node46()
		{
			this.opl_p0 = 6210;
		}

		// Token: 0x0601511A RID: 86298 RVA: 0x006594CC File Offset: 0x006578CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA1A RID: 59930
		private int opl_p0;
	}
}
