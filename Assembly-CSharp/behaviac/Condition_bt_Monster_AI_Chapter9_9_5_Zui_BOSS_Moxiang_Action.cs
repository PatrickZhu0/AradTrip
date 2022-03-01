using System;

namespace behaviac
{
	// Token: 0x0200319A RID: 12698
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node3 : Condition
	{
		// Token: 0x06014BC7 RID: 84935 RVA: 0x0063ED72 File Offset: 0x0063D172
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node3()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570270;
		}

		// Token: 0x06014BC8 RID: 84936 RVA: 0x0063ED94 File Offset: 0x0063D194
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E537 RID: 58679
		private BE_Target opl_p0;

		// Token: 0x0400E538 RID: 58680
		private BE_Equal opl_p1;

		// Token: 0x0400E539 RID: 58681
		private int opl_p2;
	}
}
