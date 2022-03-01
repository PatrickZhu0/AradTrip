using System;

namespace behaviac
{
	// Token: 0x0200377E RID: 14206
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node63 : Condition
	{
		// Token: 0x06015703 RID: 87811 RVA: 0x006774F6 File Offset: 0x006758F6
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node63()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x06015704 RID: 87812 RVA: 0x0067750C File Offset: 0x0067590C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0C2 RID: 61634
		private float opl_p0;
	}
}
