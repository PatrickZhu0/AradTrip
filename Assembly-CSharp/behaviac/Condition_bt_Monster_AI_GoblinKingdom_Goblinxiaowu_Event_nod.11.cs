using System;

namespace behaviac
{
	// Token: 0x020032EE RID: 13038
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node41 : Condition
	{
		// Token: 0x06014E49 RID: 85577 RVA: 0x0064B3C2 File Offset: 0x006497C2
		public Condition_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node41()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06014E4A RID: 85578 RVA: 0x0064B3D8 File Offset: 0x006497D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E732 RID: 59186
		private float opl_p0;
	}
}
