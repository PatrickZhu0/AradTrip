using System;

namespace behaviac
{
	// Token: 0x02003EAE RID: 16046
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node10 : Condition
	{
		// Token: 0x060164DA RID: 91354 RVA: 0x006BEAF5 File Offset: 0x006BCEF5
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node10()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x060164DB RID: 91355 RVA: 0x006BEB08 File Offset: 0x006BCF08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD0F RID: 64783
		private float opl_p0;
	}
}
