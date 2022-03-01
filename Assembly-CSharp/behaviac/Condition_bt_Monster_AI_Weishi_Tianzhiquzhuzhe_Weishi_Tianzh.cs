using System;

namespace behaviac
{
	// Token: 0x02003DFB RID: 15867
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_Tianzhiquzhuzhe_Weishi_Tianzhiquzhuzhe_Event_Hundun_node4 : Condition
	{
		// Token: 0x06016380 RID: 91008 RVA: 0x006B79B2 File Offset: 0x006B5DB2
		public Condition_bt_Monster_AI_Weishi_Tianzhiquzhuzhe_Weishi_Tianzhiquzhuzhe_Event_Hundun_node4()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06016381 RID: 91009 RVA: 0x006B79C8 File Offset: 0x006B5DC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBE6 RID: 64486
		private float opl_p0;
	}
}
