using System;

namespace behaviac
{
	// Token: 0x02003E00 RID: 15872
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_Tianzhiquzhuzhe_Weishi_Tianzhiquzhuzhe_Event_Hundun_node9 : Condition
	{
		// Token: 0x0601638A RID: 91018 RVA: 0x006B7BC6 File Offset: 0x006B5FC6
		public Condition_bt_Monster_AI_Weishi_Tianzhiquzhuzhe_Weishi_Tianzhiquzhuzhe_Event_Hundun_node9()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.GRAPED;
		}

		// Token: 0x0601638B RID: 91019 RVA: 0x006B7BE4 File Offset: 0x006B5FE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBF1 RID: 64497
		private BE_Target opl_p0;

		// Token: 0x0400FBF2 RID: 64498
		private BE_Equal opl_p1;

		// Token: 0x0400FBF3 RID: 64499
		private BE_State opl_p2;
	}
}
