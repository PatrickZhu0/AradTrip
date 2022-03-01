using System;

namespace behaviac
{
	// Token: 0x02003DFE RID: 15870
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_Tianzhiquzhuzhe_Weishi_Tianzhiquzhuzhe_Event_Hundun_node7 : Condition
	{
		// Token: 0x06016386 RID: 91014 RVA: 0x006B7AD3 File Offset: 0x006B5ED3
		public Condition_bt_Monster_AI_Weishi_Tianzhiquzhuzhe_Weishi_Tianzhiquzhuzhe_Event_Hundun_node7()
		{
			this.opl_p0 = 5326;
		}

		// Token: 0x06016387 RID: 91015 RVA: 0x006B7AE8 File Offset: 0x006B5EE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBEE RID: 64494
		private int opl_p0;
	}
}
